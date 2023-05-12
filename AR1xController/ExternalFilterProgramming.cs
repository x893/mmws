using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AR1xController
{
	public class ExternalFilterProgramming : UserControl
	{
		public ExternalFilterProgramming()
		{
			m_MainForm = m_GuiManager.MainTsForm;
			m_ExternalFilterProgConfigParams = m_GuiManager.TsParams.ExternalFilterProgConfigParams;
			m_ExternalFilterCoeffRAMConfigParams = m_GuiManager.TsParams.ExternalFilterCoeffRAMConfigParams;
			InitializeComponent();
			string directoryName = Path.GetDirectoryName(Application.StartupPath);
			string text = string.Concat(new string[]
			{
				directoryName + "\\Clients\\AR1xController\\FilterProgCoeffRAMData.csv"
			});
			loadFileFilterprogCoeffRAMData(text);
			dataGridViewFilterprogCoeffRAM.Update();
			dataGridViewFilterprogCoeffRAM.Refresh();
			m_cboRFCoeffRamFilePath.Text = text;
		}

		public void DisableFilterProgramFor16XXARDevice()
		{
			if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR14xxDevice)
			{
				m_grpExtFilterprogCfg.Enabled = false;
				m_grpExtFilterprogCfgCoeffRam.Enabled = false;
				dataGridViewFilterprogCoeffRAM.Visible = false;
				return;
			}
			if (GlobalRef.g_AR16xxDevice || GlobalRef.g_AR1843Device || GlobalRef.g_AR6843Device || GlobalRef.g_AR2243Device)
			{
				m_grpExtFilterprogCfg.Enabled = true;
				m_grpExtFilterprogCfgCoeffRam.Enabled = true;
				dataGridViewFilterprogCoeffRAM.Visible = true;
			}
		}

		private int iSetExtFilterEProgConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetExternalFilterProgConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetExtFilterEProgConfigConfig()
		{
			iSetExtFilterEProgConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetExtFilterEProgCfgAsync()
		{
			new del_v_v(iSetExtFilterEProgConfigConfig).BeginInvoke(null, null);
		}

		private void m_btnExtFilterEProgCfgSet_Click(object sender, EventArgs p1)
		{
			iSetExtFilterEProgCfgAsync();
		}

		public bool UpdateExternalFilterProgConfigDataFromGUI()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateExternalFilterProgConfigDataFromGUI);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_ExternalFilterProgConfigParams.ProfileIndex = (char)m_nudProfileIndex.Value;
				m_ExternalFilterProgConfigParams.PFFilterCoeffStartIndex = (char)m_nudPFCoeffiStartIndex.Value;
				m_ExternalFilterProgConfigParams.ProgFilterLength = (char)m_nudProgFilterlength.Value;
				m_ExternalFilterProgConfigParams.FreqShiftFactor = (double)m_nudProgFilterFreqShiftFactor.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateExternalFilterConfigGui(RootObject jobject, int p1, int profId)
		{
			m_nudProfileIndex.Value = jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs[profId].rlRfProgFiltConf_t.profileId;
			m_nudPFCoeffiStartIndex.Value = jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs[profId].rlRfProgFiltConf_t.coeffStartIdx;
			m_nudProgFilterlength.Value = jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs[profId].rlRfProgFiltConf_t.progFiltLen;
			m_nudProgFilterFreqShiftFactor.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs[profId].rlRfProgFiltConf_t.progFiltFreqShift_Fs;
			return true;
		}

		public bool UpdateExternalFilterProgConfigData(RootObject jobject, int p1)
		{
			bool result;
			try
			{
				string[] array = new string[]
				{
					"mmWaveDevices[0]",
					"mmWaveDevices[1]",
					"mmWaveDevices[2]",
					"mmWaveDevices[3]"
				};
				if (jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs.Count == 0)
				{
					string msg = string.Format("Missing Program Filter Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg);
				}
				else if (!GlobalRef.g_AR12xxDevice)
				{
					UpdateExternalFilterConfigGui(jobject, p1, 0);
					string path = Path.GetDirectoryName(Application.StartupPath) + "\\Clients\\AR1xController\\ProgFilter.csv";
					if (File.Exists(path))
					{
						File.Delete(path);
					}
					StreamWriter streamWriter = new StreamWriter(path);
					string value = "Profile ID;PF Coeff Start index ;Prog Filter Len;Freq Shift Factor (Fs)";
					streamWriter.WriteLine(value);
					int count = GlobalRef.jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs.Count;
					for (int i = 0; i < count; i++)
					{
						string text = jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs[i].rlRfProgFiltConf_t.profileId + ";";
						text = text + jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs[i].rlRfProgFiltConf_t.coeffStartIdx + ";";
						text = text + jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs[i].rlRfProgFiltConf_t.progFiltLen + ";";
						text += (decimal)jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs[0].rlRfProgFiltConf_t.progFiltFreqShift_Fs;
						streamWriter.WriteLine(text);
					}
					streamWriter.Close();
				}
				if (jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltCoeff_t.isConfigured == 0)
				{
					string msg2 = string.Format("Missing Program Filter Coefficients Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg2);
				}
				else if (!GlobalRef.g_AR12xxDevice)
				{
					string path2 = Path.GetDirectoryName(Application.StartupPath) + "\\Clients\\AR1xController\\FilterProgCoeffRAMData.csv";
					if (File.Exists(path2))
					{
						File.Delete(path2);
					}
					StreamWriter streamWriter2 = new StreamWriter(path2);
					string value2 = "RAM Coeffient";
					streamWriter2.WriteLine(value2);
					int count2 = GlobalRef.jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs.Count;
					for (int j = 0; j < count2; j++)
					{
						int coeffStartIdx = jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs[j].rlRfProgFiltConf_t.coeffStartIdx;
						int num = coeffStartIdx + jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltConfs[j].rlRfProgFiltConf_t.progFiltLen;
						for (int k = coeffStartIdx; k < num; k++)
						{
							string value3 = jobject.mmWaveDevices[p1].rfConfig.rlRfProgFiltCoeff_t.coeffArray[k].ToString();
							streamWriter2.WriteLine(value3);
						}
					}
					streamWriter2.Close();
				}
				result = true;
			}
			catch
			{
				string msg3 = string.Format("Ext Filter Programming Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg3);
				result = false;
			}
			return result;
		}

		public bool UpdateExternalFilterProgConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateExternalFilterProgConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudProfileIndex.Value = m_ExternalFilterProgConfigParams.ProfileIndex;
				m_nudPFCoeffiStartIndex.Value = m_ExternalFilterProgConfigParams.PFFilterCoeffStartIndex;
				m_nudProgFilterlength.Value = m_ExternalFilterProgConfigParams.ProgFilterLength;
				m_nudProgFilterFreqShiftFactor.Value = (decimal)m_ExternalFilterProgConfigParams.FreqShiftFactor;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetExtFilterCoeffiRAMConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetExternalFilterCoefficientRAMConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetExtFilterCoeffiRAMConfigConfig()
		{
			iSetExtFilterCoeffiRAMConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iSetExtFilterCoeffiRAMCfgAsync()
		{
			new del_v_v(iSetExtFilterCoeffiRAMConfigConfig).BeginInvoke(null, null);
		}

		private void m_btnExtFilterEffRamSet_Click(object sender, EventArgs p1)
		{
			iSetExtFilterCoeffiRAMCfgAsync();
		}

		public bool UpdateExternalFilterCoeffRAMConfigDataFromGUI()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateExternalFilterCoeffRAMConfigDataFromGUI);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateExternalFilterCoeffRAMConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateExternalFilterCoeffRAMConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private void m000033(object sender, EventArgs p1)
		{
			openFileDialog3.InitialDirectory = "D:";
			openFileDialog3.RestoreDirectory = true;
			string text = iHandleBrowseFiles("CSV", m_cboRFCoeffRamFilePath.Text);
			if (!string.IsNullOrEmpty(text))
			{
				iSetPathInCombo(text, m_cboRFCoeffRamFilePath);
			}
		}

		private string iHandleBrowseFiles(string file_type, string current_path)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (!(file_type == "FW") && !(file_type == "BIN"))
			{
				if (!(file_type == "INI"))
				{
					if (!(file_type == "DLL"))
					{
						if (file_type == "CSV")
						{
							openFileDialog.Title = "Browse for CSV file";
							openFileDialog.Filter = "CSV files (*.csv)|*.CSV";
						}
					}
					else
					{
						openFileDialog.Title = "Browse for DLL file";
						openFileDialog.Filter = "DLL File (*.dll)|*.dll";
					}
				}
				else
				{
					openFileDialog.Title = "Browse for INI file";
					openFileDialog.Filter = "INI File (*.ini)|*.ini";
				}
			}
			else
			{
				openFileDialog.Title = "Browse for bin file";
				openFileDialog.Filter = "Binary Files (*.bin)|*.bin";
			}
			openFileDialog.RestoreDirectory = true;
			if (!string.IsNullOrEmpty(current_path) && File.Exists(current_path))
			{
				openFileDialog.InitialDirectory = Path.GetDirectoryName(current_path);
			}
			openFileDialog.ShowDialog();
			return openFileDialog.FileName;
		}

		private void iSetPathInCombo(string path, ComboBox combo)
		{
			if (base.InvokeRequired)
			{
				del_SetPathInCombo method = new del_SetPathInCombo(iSetPathInCombo);
				base.Invoke(method, new object[]
				{
					path,
					combo
				});
				return;
			}
			if (string.IsNullOrEmpty(path))
			{
				return;
			}
			if (!combo.Items.Contains(path))
			{
				if (combo.Items.Count >= Constants.MaxPaths)
				{
					combo.Items.Remove(combo.Items[combo.Items.Count - 1]);
				}
				combo.Items.Insert(0, path);
			}
			else
			{
				combo.Items.Remove(path);
				combo.Items.Insert(0, path);
			}
			combo.SelectedIndex = combo.FindStringExact(path);
		}

		private void m000034(object sender, EventArgs p1)
		{
			dataGridViewFilterprogCoeffRAM.Rows.Clear();
			dataGridViewFilterprogCoeffRAM.ColumnCount = 0;
			dataGridViewFilterprogCoeffRAM.DataSource = null;
			loadFileFilterprogCoeffRAMData(m_cboRFCoeffRamFilePath.Text);
		}

		private void loadFileFilterprogCoeffRAMData(string filename)
		{
			try
			{
				delimiter = ';';
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			try
			{
				if (File.Exists(filename))
				{
					StreamReader streamReader = new StreamReader(filename);
					if (streamReader.Peek() != -1)
					{
						string[] array = streamReader.ReadLine().Split(new char[]
						{
							delimiter
						});
						int num = array.Count<string>();
						num--;
						for (int i = 0; i <= num; i++)
						{
							DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
							dataGridViewTextBoxColumn.Name = array[i];
							dataGridViewTextBoxColumn.HeaderText = array[i];
							dataGridViewTextBoxColumn.Width = 80;
							dataGridViewFilterprogCoeffRAM.Columns.Add(dataGridViewTextBoxColumn);
						}
					}
					else
					{
						MessageBox.Show("File is Empty!!");
					}
					while (streamReader.Peek() != -1)
					{
						string[] array = streamReader.ReadLine().Split(new char[]
						{
							delimiter
						});
						DataGridViewRowCollection rows = dataGridViewFilterprogCoeffRAM.Rows;
						object[] values = array;
						rows.Add(values);
						dataGridViewFilterprogCoeffRAM.Update();
						dataGridViewFilterprogCoeffRAM.Refresh();
					}
					streamReader.Close();
				}
				else
				{
					MessageBox.Show("AR1xController folder doesn't have FilterProgCoeffRAMData.csv. Please place it back!!");
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.ToString());
			}
		}

		private void m000035(object sender, EventArgs p1)
		{
			saveFilterprogCoeffRAMDataToFile(m_cboRFCoeffRamFilePath.Text);
			f0001a2.Enabled = true;
			f0001a3.ForeColor = Color.FromArgb(34, 139, 34);
		}

		private void saveFilterprogCoeffRAMDataToFile(string filename)
		{
			try
			{
				delimiter = ';';
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			try
			{
				StreamWriter streamWriter = new StreamWriter(filename, false);
				string text = "";
				int num = dataGridViewFilterprogCoeffRAM.ColumnCount - 1;
				if (num >= 0)
				{
					text = dataGridViewFilterprogCoeffRAM.Columns[0].HeaderText;
				}
				for (int i = 1; i <= num; i++)
				{
					text = text + delimiter.ToString() + dataGridViewFilterprogCoeffRAM.Columns[i].HeaderText;
				}
				streamWriter.WriteLine(text);
				foreach (object obj in ((IEnumerable)dataGridViewFilterprogCoeffRAM.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if (!dataGridViewRow.IsNewRow)
					{
						string text2 = dataGridViewRow.Cells[0].Value.ToString();
						for (int j = 1; j <= num; j++)
						{
							text2 = text2 + delimiter.ToString() + dataGridViewRow.Cells[j].Value.ToString();
						}
						streamWriter.WriteLine(text2);
					}
				}
				streamWriter.Flush();
				streamWriter.Close();
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.ToString());
			}
		}

		public void ExtFiltActivate()
		{
			int i = 0;
			int num = 0;
			int rowCount = dataGridViewFilterprogCoeffRAM.RowCount;
			int num2 = 0;
			m_GuiManager.ScriptOps.UpdateNSetProgramFilterCoeffRAMConfigDataClear(1);
			foreach (object obj in ((IEnumerable)dataGridViewFilterprogCoeffRAM.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (num >= rowCount - 1)
				{
					break;
				}
				while (i < rowCount - (rowCount - 1))
				{
					if (num2 != rowCount - 1)
					{
						GlobalRef.CoeffRAM[num2] = Convert.ToInt16(dataGridViewRow.Cells[0].Value);
					}
					i++;
				}
				i = 0;
				num++;
				num2++;
			}
			bool flag = m_GuiManager.ScriptOps.iSetExternalFilterCoefficientRAMConfig_Gui(true, false) != 0;
			Thread.Sleep(200);
			if (flag)
			{
				string full_command = string.Format("Filter Program Coeff RAM Data Config {0} failed, stoping.", new object[]
				{
					i
				});
				m_GuiManager.RecordLog(11, full_command);
				return;
			}
		}

		private void m000036(object sender, EventArgs p1)
		{
			int i = 0;
			int num = 0;
			int rowCount = dataGridViewFilterprogCoeffRAM.RowCount;
			int num2 = 0;
			m_GuiManager.ScriptOps.UpdateNSetProgramFilterCoeffRAMConfigDataClear(1);
			foreach (object obj in ((IEnumerable)dataGridViewFilterprogCoeffRAM.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (num >= rowCount - 1)
				{
					break;
				}
				while (i < rowCount - (rowCount - 1))
				{
					if (num2 != rowCount - 1)
					{
						GlobalRef.CoeffRAM[num2] = Convert.ToInt16(dataGridViewRow.Cells[0].Value);
					}
					i++;
				}
				i = 0;
				num++;
				num2++;
			}
			bool flag = m_GuiManager.ScriptOps.iSetExternalFilterCoefficientRAMConfig_Gui(true, false) != 0;
			Thread.Sleep(200);
			if (flag)
			{
				string full_command = string.Format("Filter Program Coeff RAM Data Config {0} failed, stoping.", new object[]
				{
					i
				});
				m_GuiManager.RecordLog(11, full_command);
				return;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.m_grpExtFilterprogCfg = new System.Windows.Forms.GroupBox();
            this.m_nudProgFilterFreqShiftFactor = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.m_nudProgFilterlength = new System.Windows.Forms.NumericUpDown();
            this.m_nudPFCoeffiStartIndex = new System.Windows.Forms.NumericUpDown();
            this.m_nudProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnExtFilterEProgCfgSet = new System.Windows.Forms.Button();
            this.m_grpExtFilterprogCfgCoeffRam = new System.Windows.Forms.GroupBox();
            this.dataGridViewFilterprogCoeffRAM = new System.Windows.Forms.DataGridView();
            this.f0001a2 = new System.Windows.Forms.Button();
            this.f0001a3 = new System.Windows.Forms.Button();
            this.f0001a4 = new System.Windows.Forms.Button();
            this.f0001a5 = new System.Windows.Forms.Button();
            this.m_cboRFCoeffRamFilePath = new System.Windows.Forms.ComboBox();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.m_grpExtFilterprogCfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudProgFilterFreqShiftFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudProgFilterlength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPFCoeffiStartIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudProfileIndex)).BeginInit();
            this.m_grpExtFilterprogCfgCoeffRam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilterprogCoeffRAM)).BeginInit();
            this.SuspendLayout();
            // 
            // m_grpExtFilterprogCfg
            // 
            this.m_grpExtFilterprogCfg.Controls.Add(this.m_nudProgFilterFreqShiftFactor);
            this.m_grpExtFilterprogCfg.Controls.Add(this.label1);
            this.m_grpExtFilterprogCfg.Controls.Add(this.m_nudProgFilterlength);
            this.m_grpExtFilterprogCfg.Controls.Add(this.m_nudPFCoeffiStartIndex);
            this.m_grpExtFilterprogCfg.Controls.Add(this.m_nudProfileIndex);
            this.m_grpExtFilterprogCfg.Controls.Add(this.label4);
            this.m_grpExtFilterprogCfg.Controls.Add(this.label3);
            this.m_grpExtFilterprogCfg.Controls.Add(this.label2);
            this.m_grpExtFilterprogCfg.Controls.Add(this.m_btnExtFilterEProgCfgSet);
            this.m_grpExtFilterprogCfg.Location = new System.Drawing.Point(27, 24);
            this.m_grpExtFilterprogCfg.Name = "m_grpExtFilterprogCfg";
            this.m_grpExtFilterprogCfg.Size = new System.Drawing.Size(254, 222);
            this.m_grpExtFilterprogCfg.TabIndex = 0;
            this.m_grpExtFilterprogCfg.TabStop = false;
            this.m_grpExtFilterprogCfg.Text = "Program Filter Prog Config";
            // 
            // m_nudProgFilterFreqShiftFactor
            // 
            this.m_nudProgFilterFreqShiftFactor.DecimalPlaces = 2;
            this.m_nudProgFilterFreqShiftFactor.Location = new System.Drawing.Point(123, 130);
            this.m_nudProgFilterFreqShiftFactor.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_nudProgFilterFreqShiftFactor.Name = "m_nudProgFilterFreqShiftFactor";
            this.m_nudProgFilterFreqShiftFactor.Size = new System.Drawing.Size(92, 20);
            this.m_nudProgFilterFreqShiftFactor.TabIndex = 8;
            this.m_nudProgFilterFreqShiftFactor.Value = new decimal(new int[] {
            45,
            0,
            0,
            131072});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Freq Shift Factor (Fs)";
            // 
            // m_nudProgFilterlength
            // 
            this.m_nudProgFilterlength.Location = new System.Drawing.Point(123, 100);
            this.m_nudProgFilterlength.Name = "m_nudProgFilterlength";
            this.m_nudProgFilterlength.Size = new System.Drawing.Size(92, 20);
            this.m_nudProgFilterlength.TabIndex = 6;
            // 
            // m_nudPFCoeffiStartIndex
            // 
            this.m_nudPFCoeffiStartIndex.Location = new System.Drawing.Point(123, 70);
            this.m_nudPFCoeffiStartIndex.Name = "m_nudPFCoeffiStartIndex";
            this.m_nudPFCoeffiStartIndex.Size = new System.Drawing.Size(92, 20);
            this.m_nudPFCoeffiStartIndex.TabIndex = 5;
            // 
            // m_nudProfileIndex
            // 
            this.m_nudProfileIndex.Location = new System.Drawing.Point(123, 40);
            this.m_nudProfileIndex.Name = "m_nudProfileIndex";
            this.m_nudProfileIndex.Size = new System.Drawing.Size(92, 20);
            this.m_nudProfileIndex.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Prog Filter len";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "PF Coeff Start index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profile index";
            // 
            // m_btnExtFilterEProgCfgSet
            // 
            this.m_btnExtFilterEProgCfgSet.Location = new System.Drawing.Point(140, 178);
            this.m_btnExtFilterEProgCfgSet.Name = "m_btnExtFilterEProgCfgSet";
            this.m_btnExtFilterEProgCfgSet.Size = new System.Drawing.Size(75, 31);
            this.m_btnExtFilterEProgCfgSet.TabIndex = 0;
            this.m_btnExtFilterEProgCfgSet.Text = "Set";
            this.m_btnExtFilterEProgCfgSet.UseVisualStyleBackColor = true;
            // 
            // m_grpExtFilterprogCfgCoeffRam
            // 
            this.m_grpExtFilterprogCfgCoeffRam.Controls.Add(this.dataGridViewFilterprogCoeffRAM);
            this.m_grpExtFilterprogCfgCoeffRam.Controls.Add(this.f0001a2);
            this.m_grpExtFilterprogCfgCoeffRam.Controls.Add(this.f0001a3);
            this.m_grpExtFilterprogCfgCoeffRam.Controls.Add(this.f0001a4);
            this.m_grpExtFilterprogCfgCoeffRam.Controls.Add(this.f0001a5);
            this.m_grpExtFilterprogCfgCoeffRam.Controls.Add(this.m_cboRFCoeffRamFilePath);
            this.m_grpExtFilterprogCfgCoeffRam.Location = new System.Drawing.Point(296, 24);
            this.m_grpExtFilterprogCfgCoeffRam.Name = "m_grpExtFilterprogCfgCoeffRam";
            this.m_grpExtFilterprogCfgCoeffRam.Size = new System.Drawing.Size(549, 236);
            this.m_grpExtFilterprogCfgCoeffRam.TabIndex = 1;
            this.m_grpExtFilterprogCfgCoeffRam.TabStop = false;
            this.m_grpExtFilterprogCfgCoeffRam.Text = "Program Filter Coefficient RAM";
            // 
            // dataGridViewFilterprogCoeffRAM
            // 
            this.dataGridViewFilterprogCoeffRAM.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewFilterprogCoeffRAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilterprogCoeffRAM.Location = new System.Drawing.Point(12, 77);
            this.dataGridViewFilterprogCoeffRAM.Name = "dataGridViewFilterprogCoeffRAM";
            this.dataGridViewFilterprogCoeffRAM.Size = new System.Drawing.Size(121, 150);
            this.dataGridViewFilterprogCoeffRAM.TabIndex = 8;
            // 
            // f0001a2
            // 
            this.f0001a2.Location = new System.Drawing.Point(465, 71);
            this.f0001a2.Name = "f0001a2";
            this.f0001a2.Size = new System.Drawing.Size(75, 23);
            this.f0001a2.TabIndex = 7;
            this.f0001a2.Text = "Activate";
            this.f0001a2.UseVisualStyleBackColor = true;
            // 
            // f0001a3
            // 
            this.f0001a3.Location = new System.Drawing.Point(367, 71);
            this.f0001a3.Name = "f0001a3";
            this.f0001a3.Size = new System.Drawing.Size(75, 23);
            this.f0001a3.TabIndex = 6;
            this.f0001a3.Text = "Save";
            this.f0001a3.UseVisualStyleBackColor = true;
            // 
            // f0001a4
            // 
            this.f0001a4.Location = new System.Drawing.Point(465, 29);
            this.f0001a4.Name = "f0001a4";
            this.f0001a4.Size = new System.Drawing.Size(75, 23);
            this.f0001a4.TabIndex = 5;
            this.f0001a4.Text = "Load";
            this.f0001a4.UseVisualStyleBackColor = true;
            // 
            // f0001a5
            // 
            this.f0001a5.Location = new System.Drawing.Point(367, 29);
            this.f0001a5.Name = "f0001a5";
            this.f0001a5.Size = new System.Drawing.Size(75, 23);
            this.f0001a5.TabIndex = 4;
            this.f0001a5.Text = "Browse";
            this.f0001a5.UseVisualStyleBackColor = true;
            // 
            // m_cboRFCoeffRamFilePath
            // 
            this.m_cboRFCoeffRamFilePath.FormattingEnabled = true;
            this.m_cboRFCoeffRamFilePath.Location = new System.Drawing.Point(12, 29);
            this.m_cboRFCoeffRamFilePath.Name = "m_cboRFCoeffRamFilePath";
            this.m_cboRFCoeffRamFilePath.Size = new System.Drawing.Size(349, 21);
            this.m_cboRFCoeffRamFilePath.TabIndex = 3;
            this.m_cboRFCoeffRamFilePath.Text = "C:\\RadarStudio\\Clients\\AR1xController\\FilterProgCoeffRAMData.csv";
            // 
            // ExternalFilterProgramming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_grpExtFilterprogCfgCoeffRam);
            this.Controls.Add(this.m_grpExtFilterprogCfg);
            this.Name = "ExternalFilterProgramming";
            this.Size = new System.Drawing.Size(1037, 509);
            this.m_grpExtFilterprogCfg.ResumeLayout(false);
            this.m_grpExtFilterprogCfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudProgFilterFreqShiftFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudProgFilterlength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPFCoeffiStartIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudProfileIndex)).EndInit();
            this.m_grpExtFilterprogCfgCoeffRam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilterprogCoeffRAM)).EndInit();
            this.ResumeLayout(false);

		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		private ExternalFilterProgConfigParams m_ExternalFilterProgConfigParams;

		private ExternalFilterCoeffRAMConfigParams m_ExternalFilterCoeffRAMConfigParams;

		private char delimiter;

		private IContainer components;

		private GroupBox m_grpExtFilterprogCfg;

		private Button m_btnExtFilterEProgCfgSet;

		private GroupBox m_grpExtFilterprogCfgCoeffRam;

		private NumericUpDown m_nudProgFilterlength;

		private NumericUpDown m_nudPFCoeffiStartIndex;

		private NumericUpDown m_nudProfileIndex;

		private Label label4;

		private Label label3;

		private Label label2;

		private ComboBox m_cboRFCoeffRamFilePath;

		private Button f0001a2;

		private Button f0001a3;

		private Button f0001a4;

		private Button f0001a5;

		private OpenFileDialog openFileDialog3;

		private DataGridView dataGridViewFilterprogCoeffRAM;

		private NumericUpDown m_nudProgFilterFreqShiftFactor;

		private Label label1;
	}
}
