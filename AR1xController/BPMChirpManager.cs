using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AR1xController
{
	public partial class BPMChirpManager : Form
	{
		public BPMChirpManager()
		{
			string directoryName = Path.GetDirectoryName(Application.StartupPath);
			string text = string.Concat(new string[]
			{
				directoryName + "\\Clients\\AR1xController\\BPMData.csv"
			});
			InitializeComponent();
			int p;
			if (GlobalRef.g_RadarDeviceId == 1U)
			{
				p = 0;
			}
			else if (GlobalRef.g_RadarDeviceId == 2U)
			{
				p = 1;
			}
			else if (GlobalRef.g_RadarDeviceId == 4U)
			{
				p = 2;
			}
			else
			{
				if (GlobalRef.g_RadarDeviceId != 8U)
				{
					MessageBox.Show("Choose any one device!");
					return;
				}
				p = 3;
			}
			loadBPMChirpData(GlobalRef.jobject, p);
			m_cboADCDataFileBPMConfig.Text = text;
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
			string text = iHandleBrowseFiles("CSV", m_cboADCDataFileBPMConfig.Text);
			if (!string.IsNullOrEmpty(text))
			{
				iSetPathInCombo(text, m_cboADCDataFileBPMConfig);
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

		private void loadBPMChirpData(RootObject jobject, int p1)
		{
			if (jobject.mmWaveDevices[p1].rfConfig.p000012.Count == 0)
			{
				MessageBox.Show("No BPM Chirps have been configured for this device!");
				return;
			}
			string text = "Chirp Start Idx;Chirp End Idx;TX0 Off;TX0 On;TX1 Off;TX1 On;TX2 Off;TX2 On";
			int count = GlobalRef.jobject.mmWaveDevices[p1].rfConfig.p000012.Count;
			string[] array = new string[512];
			for (int i = 0; i < count; i++)
			{
				string text2 = jobject.mmWaveDevices[p1].rfConfig.p000012[i].p000008.chirpStartIdx + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.p000012[i].p000008.chirpEndIdx + ";";
				text2 = text2 + (int)(Convert.ToUInt16(jobject.mmWaveDevices[p1].rfConfig.p000012[i].p000008.constBpmVal, 16) & 1) + ";";
				text2 = text2 + (Convert.ToUInt16(jobject.mmWaveDevices[p1].rfConfig.p000012[i].p000008.constBpmVal, 16) >> 1 & 1) + ";";
				text2 = text2 + (Convert.ToUInt16(jobject.mmWaveDevices[p1].rfConfig.p000012[i].p000008.constBpmVal, 16) >> 2 & 1) + ";";
				text2 = text2 + (Convert.ToUInt16(jobject.mmWaveDevices[p1].rfConfig.p000012[i].p000008.constBpmVal, 16) >> 3 & 1) + ";";
				text2 = text2 + (Convert.ToUInt16(jobject.mmWaveDevices[p1].rfConfig.p000012[i].p000008.constBpmVal, 16) >> 4 & 1) + ";";
				text2 += (Convert.ToUInt16(jobject.mmWaveDevices[p1].rfConfig.p000012[i].p000008.constBpmVal, 16) >> 5 & 1);
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
			loadFileData(m_cboADCDataFileBPMConfig.Text);
		}

		private void m_btnSave_Click(object sender, EventArgs p1)
		{
			int num = 0;
			saveDataToFile(m_cboADCDataFileBPMConfig.Text);
			foreach (object obj in ((IEnumerable)dataGridView2.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				f0001fa[num].ChirpStartIndex = Convert.ToUInt16(dataGridViewRow.Cells[0].Value);
				f0001fa[num].ChirpEndIndex = Convert.ToUInt16(dataGridViewRow.Cells[1].Value);
				f0001fa[num].tx0Disable = Convert.ToUInt16(dataGridViewRow.Cells[2].Value);
				f0001fa[num].tx0Enable = Convert.ToUInt16(dataGridViewRow.Cells[3].Value);
				f0001fa[num].tx1Disable = Convert.ToUInt16(dataGridViewRow.Cells[4].Value);
				f0001fa[num].tx1Enable = Convert.ToUInt16(dataGridViewRow.Cells[5].Value);
				f0001fa[num].tx2Disable = Convert.ToUInt16(dataGridViewRow.Cells[6].Value);
				f0001fa[num].tx2Enable = Convert.ToUInt16(dataGridViewRow.Cells[7].Value);
				num++;
			}
			m_btnBPMChirpActivate.Enabled = true;
			m_btnBPMChirpSave.ForeColor = Color.FromArgb(34, 139, 34);
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
					f0001fa[i].ChirpStartIndex = Convert.ToUInt16(dataGridViewRow.Cells[0].Value);
					f0001fa[i].ChirpEndIndex = Convert.ToUInt16(dataGridViewRow.Cells[1].Value);
					f0001fa[i].tx0Disable = Convert.ToUInt16(dataGridViewRow.Cells[2].Value);
					f0001fa[i].tx0Enable = Convert.ToUInt16(dataGridViewRow.Cells[3].Value);
					f0001fa[i].tx1Disable = Convert.ToUInt16(dataGridViewRow.Cells[4].Value);
					f0001fa[i].tx1Enable = Convert.ToUInt16(dataGridViewRow.Cells[5].Value);
					f0001fa[i].tx2Disable = Convert.ToUInt16(dataGridViewRow.Cells[6].Value);
					f0001fa[i].tx2Enable = Convert.ToUInt16(dataGridViewRow.Cells[7].Value);
					if (m_GuiManager.ScriptOps.UpdateNSetBPMChirpConfigData((ushort)GlobalRef.g_RadarDeviceId, f0001fa[i].ChirpStartIndex, f0001fa[i].ChirpEndIndex, f0001fa[i].tx0Disable, f0001fa[i].tx0Enable, f0001fa[i].tx1Disable, f0001fa[i].tx1Enable, f0001fa[i].tx2Disable, f0001fa[i].tx2Enable) != 0)
					{
						string full_command = string.Format("BPM Config {0} failed, stoping.", new object[]
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
			m_btnBPMChirpSave.ForeColor = Color.Red;
		}

		private void ProfManager_Load(object sender, EventArgs p1)
		{
		}

		private AR1xxxExtOpps m_AR1xxxExtOpps = GlobalRef.AR1xxxExtOpps;
		private GuiManager m_GuiManager = GlobalRef.GuiManager;
		private char delimiter;
		private BpmConfigParams[] f0001fa = new BpmConfigParams[1024];
	}
}
