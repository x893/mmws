using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AR1xController
{
	public partial class PerChirpManager : Form
	{
		public PerChirpManager()
		{
			string text = string.Concat(
                Path.GetDirectoryName(Application.StartupPath), "\\Clients\\AR1xController\\ChirpPhaseShifterConfigData.csv"
			);
			InitializeComponent();

			int p;
			if (GlobalRef.g_RadarDeviceId == 1U)
				p = 0;
			else if (GlobalRef.g_RadarDeviceId == 2U)
				p = 1;
			else if (GlobalRef.g_RadarDeviceId == 4U)
				p = 2;
			else
			{
				if (GlobalRef.g_RadarDeviceId != 8U)
				{
					MessageBox.Show("Choose any one device!");
					return;
				}
				p = 3;
			}
			loadPerChirpData(GlobalRef.jobject, p);
			m_cboADCDataFileChirpBasedPhaseShifterConfig.Text = text;
		}

		public GuiManager GuiManager
		{
			get
			{
				return m_GuiManager;
			}
			set
			{
				m_GuiManager = value;
			}
		}

		private void m_btnBrowse_Click(object sender, EventArgs p1)
		{
			openFileDialog2.InitialDirectory = "D:";
			openFileDialog2.RestoreDirectory = true;
			string text = iHandleBrowseFiles("CSV", m_cboADCDataFileChirpBasedPhaseShifterConfig.Text);
			if (!string.IsNullOrEmpty(text))
			{
				iSetPathInCombo(text, m_cboADCDataFileChirpBasedPhaseShifterConfig);
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
				base.Invoke(new del_SetPathInCombo(iSetPathInCombo),
					path,
					combo
				);
				return;
			}
			if (string.IsNullOrEmpty(path))
				return;

			if (!combo.Items.Contains(path))
			{
				if (combo.Items.Count >= Constants.MaxPaths)
					combo.Items.Remove(combo.Items[combo.Items.Count - 1]);
				combo.Items.Insert(0, path);
			}
			else
			{
				combo.Items.Remove(path);
				combo.Items.Insert(0, path);
			}
			combo.SelectedIndex = combo.FindStringExact(path);
		}

		private void loadPerChirpData(RootObject jobject, int p1)
		{
			if (jobject.mmWaveDevices[p1].rfConfig.p000015.Count == 0)
			{
				MessageBox.Show("No Per-Chirp based Phase Shifter have been configured for this device!");
				return;
			}
			string text = "Chirp Start Idx;Chirp End Idx;Phase Shifter TX0(deg);Phase Shifter TX1(deg);Phase Shifter TX2(deg)";
			int count = GlobalRef.jobject.mmWaveDevices[p1].rfConfig.p000015.Count;
			string[] array = new string[512];
			for (int i = 0; i < count; i++)
			{
				string text2 = jobject.mmWaveDevices[p1].rfConfig.p000015[i].rlRfPhaseShiftCfg_t.chirpStartIdx + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.p000015[i].rlRfPhaseShiftCfg_t.chirpEndIdx + ";";
				text2 = text2 + (double)jobject.mmWaveDevices[p1].rfConfig.p000015[i].rlRfPhaseShiftCfg_t.tx0PhaseShift * 360.0 / 64.0 + ";";
				text2 = text2 + (double)jobject.mmWaveDevices[p1].rfConfig.p000015[i].rlRfPhaseShiftCfg_t.tx1PhaseShift * 360.0 / 64.0 + ";";
				text2 += (double)jobject.mmWaveDevices[p1].rfConfig.p000015[i].rlRfPhaseShiftCfg_t.tx2PhaseShift * 360.0 / 64.0;
				array[i] = text2;
			}
			try
			{
				delimiter = ';';
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				base.Close();
			}
			try
			{
				string[] array2 = text.Split(new char[]
				{
					delimiter
				});
				int num = array2.Count<string>();
				num--;
				for (int j = 0; j <= num; j++)
				{
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumn.Name = array2[j];
					dataGridViewTextBoxColumn.HeaderText = array2[j];
					dataGridViewTextBoxColumn.Width = 80;
					dataGridView2.Columns.Add(dataGridViewTextBoxColumn);
				}
				for (int k = 0; k < count; k++)
				{
					array2 = array[k].Split(new char[]
					{
						delimiter
					});
					DataGridViewRowCollection rows = dataGridView2.Rows;
					object[] values = array2;
					rows.Add(values);
					dataGridView2.Update();
					dataGridView2.Refresh();
					dataGridView2.Update();
					dataGridView2.Refresh();
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.ToString());
			}
		}

		private void loadFileData(string filename)
		{
			try
			{
				delimiter = ';';
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				base.Close();
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
							dataGridView2.Columns.Add(dataGridViewTextBoxColumn);
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
						DataGridViewRowCollection rows = dataGridView2.Rows;
						object[] values = array;
						rows.Add(values);
						dataGridView2.Update();
						dataGridView2.Refresh();
						dataGridView2.Update();
						dataGridView2.Refresh();
					}
					streamReader.Close();
				}
				else
				{
					MessageBox.Show("No File is Selected!!");
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.ToString());
			}
		}

		private void saveDataToFile(string filename)
		{
			try
			{
				delimiter = ';';
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				base.Close();
			}
			try
			{
				StreamWriter streamWriter = new StreamWriter(filename, false);
				string text = "";
				int num = dataGridView2.ColumnCount - 1;
				if (num >= 0)
				{
					text = dataGridView2.Columns[0].HeaderText;
				}
				for (int i = 1; i <= num; i++)
				{
					text = text + delimiter.ToString() + dataGridView2.Columns[i].HeaderText;
				}
				streamWriter.WriteLine(text);
				foreach (object obj in ((IEnumerable)dataGridView2.Rows))
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

		private void m_btnLoad_Click(object sender, EventArgs p1)
		{
			dataGridView2.Rows.Clear();
			dataGridView2.ColumnCount = 0;
			dataGridView2.DataSource = null;
			loadFileData(m_cboADCDataFileChirpBasedPhaseShifterConfig.Text);
		}

		private void m_btnSave_Click(object sender, EventArgs p1)
		{
			int num = 0;
			saveDataToFile(m_cboADCDataFileChirpBasedPhaseShifterConfig.Text);
			foreach (object obj in ((IEnumerable)dataGridView2.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				ChirpPhaseShifterParams[num].ChirpStartIndex = Convert.ToUInt16(dataGridViewRow.Cells[0].Value);
				ChirpPhaseShifterParams[num].ChirpEndIndex = Convert.ToUInt16(dataGridViewRow.Cells[1].Value);
				ChirpPhaseShifterParams[num].tx0PhaseShifter = (ushort)(Convert.ToDouble(dataGridViewRow.Cells[2].Value) * 64.0 / 360.0);
				ChirpPhaseShifterParams[num].tx1PhaseShifter = (ushort)(Convert.ToDouble(dataGridViewRow.Cells[3].Value) * 64.0 / 360.0);
				ChirpPhaseShifterParams[num].tx2PhaseShifter = (ushort)(Convert.ToDouble(dataGridViewRow.Cells[4].Value) * 64.0 / 360.0);
				num++;
			}
			m_btnChirpPhaseShifterActivate.Enabled = true;
			m_btnChirpPhaseShifterSave.ForeColor = Color.FromArgb(34, 139, 34);
		}

		private void m_btnActivate_Click(object sender, EventArgs p1)
		{
			int i = 0;
			int num = 0;
			int rowCount = dataGridView2.RowCount;
			foreach (object obj in ((IEnumerable)dataGridView2.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (num >= rowCount - 1)
				{
					break;
				}
				while (i < rowCount - (rowCount - 1))
				{
					ChirpPhaseShifterParams[i].ChirpStartIndex = Convert.ToUInt16(dataGridViewRow.Cells[0].Value);
					ChirpPhaseShifterParams[i].ChirpEndIndex = Convert.ToUInt16(dataGridViewRow.Cells[1].Value);
					ChirpPhaseShifterParams[i].tx0PhaseShifter = (ushort)(Convert.ToDouble(dataGridViewRow.Cells[2].Value) * 64.0 / 360.0);
					ChirpPhaseShifterParams[i].tx1PhaseShifter = (ushort)(Convert.ToDouble(dataGridViewRow.Cells[3].Value) * 64.0 / 360.0);
					ChirpPhaseShifterParams[i].tx2PhaseShifter = (ushort)(Convert.ToDouble(dataGridViewRow.Cells[4].Value) * 64.0 / 360.0);
					if (m_GuiManager.ScriptOps.UpdateNSetChirpBasedPhaseShifterConfigData((ushort)GlobalRef.g_RadarDeviceId, ChirpPhaseShifterParams[i].ChirpStartIndex, ChirpPhaseShifterParams[i].ChirpEndIndex, ChirpPhaseShifterParams[i].tx0PhaseShifter, ChirpPhaseShifterParams[i].tx1PhaseShifter, ChirpPhaseShifterParams[i].tx2PhaseShifter) != 0)
					{
						string full_command = string.Format("Chirp Base Phase Shifter Config {0} failed, stoping.", new object[]
						{
							i
						});
						m_GuiManager.RecordLog(11, full_command);
						return;
					}
					i++;
				}
				i = 0;
				num++;
			}
		}

		private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs p1)
		{
			m_btnChirpPhaseShifterSave.ForeColor = Color.Red;
		}

		private void ProfManager_Load(object sender, EventArgs p1)
		{
		}

		private AR1xxxExtOpps m_AR1xxxExtOpps = GlobalRef.AR1xxxExtOpps;
		private GuiManager m_GuiManager = GlobalRef.GuiManager;
		private char delimiter;
		private ChirpPhaseShifterConfigParams[] ChirpPhaseShifterParams = new ChirpPhaseShifterConfigParams[1024];
	}
}
