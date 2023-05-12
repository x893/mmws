using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AR1xController
{
	public partial class ProfManager : Form
	{
		public ProfManager()
		{
			string directoryName = Path.GetDirectoryName(Application.StartupPath);
			string text = string.Concat(new string[]
			{
				directoryName + "\\Clients\\AR1xController\\ProfConfigData.csv"
			});
			this.InitializeComponent();
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
			this.loadProfileData(GlobalRef.jobject, p);
			this.m_cboADCDataFileProfileConfig.Text = text;
		}

		public GuiManager GuiManager
		{
			get
			{
				return this.m_GuiManager;
			}
			set
			{
				this.m_GuiManager = value;
			}
		}

		private void m_btnBrowse_Click(object sender, EventArgs p1)
		{
			this.openFileDialog2.InitialDirectory = "D:";
			this.openFileDialog2.RestoreDirectory = true;
			string text = this.iHandleBrowseFiles("CSV", this.m_cboADCDataFileProfileConfig.Text);
			if (!string.IsNullOrEmpty(text))
			{
				this.iSetPathInCombo(text, this.m_cboADCDataFileProfileConfig);
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
				del_SetPathInCombo method = new del_SetPathInCombo(this.iSetPathInCombo);
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

		private void loadProfileData(RootObject jobject, int p1)
		{
			if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles.Count == 0)
			{
				MessageBox.Show("No Profiles have been configured!");
				return;
			}
			string text = "Profile ID;Start Freq(GHz);Frequency Slope(MHz/ us);Idle Time(us);TX Start Time(us);ADC Start Time(us);ADC Samples; Sample Rate(ksps);Ramp End Time(us);RX Gain(dB);RX Gain Target(dB);VCO Select; Force VCO Select; Retain Tx Cal LUT;Retain Rx  Cal LUT; HPF1 Corner Freq(kHz);HPF2 Corner Freq(k / M Hz);O / p Pwr Backoff Tx0(dB);O / p Pwr Backoff Tx1(dB);O / p Pwr Backoff Tx2(dB);Phase Shifter TX0(deg);Phase Shifter TX1(deg);Phase Shifter TX2(deg)";
			int count = GlobalRef.jobject.mmWaveDevices[p1].rfConfig.rlProfiles.Count;
			int num = 0;
			int num2 = 0;
			double num3 = 0.0;
			string[] array = new string[4];
			for (int i = 0; i < count; i++)
			{
				string text2 = jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.profileId + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.startFreqConst_GHz + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.freqSlopeConst_MHz_usec + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.idleTimeConst_usec + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txStartTime_usec + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.adcStartTimeConst_usec + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.numAdcSamples + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.digOutSampleRate + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.rampEndTime_usec + ";";
				text2 = text2 + (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.rxGain_dB, 16) & 63) + ";";
				if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 0)
				{
					num = 30;
				}
				else if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 1)
				{
					num = 34;
				}
				else if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 3)
				{
					num = 26;
				}
				text2 = text2 + num + ";";
				text2 = text2 + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.pfVcoSelect, 16) & 2) >> 1) + ";";
				text2 = text2 + (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.pfVcoSelect, 16) & 1) + ";";
				text2 = text2 + (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.pfCalLutUpdate, 16) & 1) + ";";
				text2 = text2 + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.pfCalLutUpdate, 16) & 2) >> 1) + ";";
				if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq1 == 0)
				{
					num2 = 175;
				}
				else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq1 == 1)
				{
					num2 = 235;
				}
				else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq1 == 2)
				{
					num2 = 350;
				}
				else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq1 == 3)
				{
					num2 = 700;
				}
				text2 = text2 + num2 + ";";
				if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq2 == 0)
				{
					num3 = 350.0;
				}
				else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq2 == 1)
				{
					num3 = 700.0;
				}
				else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq2 == 2)
				{
					num3 = 1.4;
				}
				else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq2 == 3)
				{
					num3 = 2.8;
				}
				text2 = text2 + num3 + ";";
				text2 = text2 + (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 255) + ";";
				text2 = text2 + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 65280) >> 8) + ";";
				text2 = text2 + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 16711680) >> 16) + ";";
				text2 = text2 + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txPhaseShifter, 16) & 255) >> 2) * 5 + ";";
				text2 = text2 + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txPhaseShifter, 16) & 65280) >> 10) * 5 + ";";
				text2 += ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txPhaseShifter, 16) & 16711680) >> 18) * 5;
				array[i] = text2;
			}
			try
			{
				this.delimiter = ';';
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
					this.delimiter
				});
				int num4 = array2.Count<string>();
				num4--;
				for (int j = 0; j <= num4; j++)
				{
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumn.Name = array2[j];
					dataGridViewTextBoxColumn.HeaderText = array2[j];
					dataGridViewTextBoxColumn.Width = 80;
					this.dataGridView2.Columns.Add(dataGridViewTextBoxColumn);
				}
				for (int k = 0; k < count; k++)
				{
					array2 = array[k].Split(new char[]
					{
						this.delimiter
					});
					DataGridViewRowCollection rows = this.dataGridView2.Rows;
					object[] values = array2;
					rows.Add(values);
					this.dataGridView2.Update();
					this.dataGridView2.Refresh();
					this.dataGridView2.Update();
					this.dataGridView2.Refresh();
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
				this.delimiter = ';';
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
							this.delimiter
						});
						int num = array.Count<string>();
						num--;
						for (int i = 0; i <= num; i++)
						{
							DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
							dataGridViewTextBoxColumn.Name = array[i];
							dataGridViewTextBoxColumn.HeaderText = array[i];
							dataGridViewTextBoxColumn.Width = 80;
							this.dataGridView2.Columns.Add(dataGridViewTextBoxColumn);
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
							this.delimiter
						});
						DataGridViewRowCollection rows = this.dataGridView2.Rows;
						object[] values = array;
						rows.Add(values);
						this.dataGridView2.Update();
						this.dataGridView2.Refresh();
						this.dataGridView2.Update();
						this.dataGridView2.Refresh();
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
				this.delimiter = ';';
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
				int num = this.dataGridView2.ColumnCount - 1;
				if (num >= 0)
				{
					text = this.dataGridView2.Columns[0].HeaderText;
				}
				for (int i = 1; i <= num; i++)
				{
					text = text + this.delimiter.ToString() + this.dataGridView2.Columns[i].HeaderText;
				}
				streamWriter.WriteLine(text);
				foreach (object obj in ((IEnumerable)this.dataGridView2.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if (!dataGridViewRow.IsNewRow)
					{
						string text2 = dataGridViewRow.Cells[0].Value.ToString();
						for (int j = 1; j <= num; j++)
						{
							text2 = text2 + this.delimiter.ToString() + dataGridViewRow.Cells[j].Value.ToString();
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
			this.dataGridView2.Rows.Clear();
			this.dataGridView2.ColumnCount = 0;
			this.dataGridView2.DataSource = null;
			this.loadFileData(this.m_cboADCDataFileProfileConfig.Text);
		}

		private void m_btnSave_Click(object sender, EventArgs p1)
		{
			int num = 0;
			this.saveDataToFile(this.m_cboADCDataFileProfileConfig.Text);
			foreach (object obj in ((IEnumerable)this.dataGridView2.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				this.ProfPrms[num].pprofileId = Convert.ToUInt16(dataGridViewRow.Cells[0].Value);
				this.ProfPrms[num].startFreqConst = Convert.ToSingle(dataGridViewRow.Cells[1].Value);
				this.ProfPrms[num].freqSlopeConst = Convert.ToSingle(dataGridViewRow.Cells[2].Value);
				this.ProfPrms[num].idleTimeConst = Convert.ToSingle(dataGridViewRow.Cells[3].Value);
				this.ProfPrms[num].txStartTime = Convert.ToSingle(dataGridViewRow.Cells[4].Value);
				this.ProfPrms[num].adcStartTimeConst = Convert.ToSingle(dataGridViewRow.Cells[5].Value);
				this.ProfPrms[num].pnumAdcSamples = Convert.ToUInt16(dataGridViewRow.Cells[6].Value);
				this.ProfPrms[num].digOutSampleRate = Convert.ToUInt16(dataGridViewRow.Cells[7].Value);
				this.ProfPrms[num].rampEndTime = Convert.ToSingle(dataGridViewRow.Cells[8].Value);
				this.ProfPrms[num].rxGain = Convert.ToUInt16(dataGridViewRow.Cells[9].Value);
				this.ProfPrms[num].rxGainTarget = Convert.ToUInt16(dataGridViewRow.Cells[10].Value);
				this.ProfPrms[num].VCOSelect = Convert.ToUInt16(dataGridViewRow.Cells[11].Value);
				this.ProfPrms[num].forceVCOSelect = Convert.ToUInt16(dataGridViewRow.Cells[12].Value);
				this.ProfPrms[num].retainTxCalibLUT = Convert.ToUInt16(dataGridViewRow.Cells[13].Value);
				this.ProfPrms[num].retainRxCalibLUT = Convert.ToUInt16(dataGridViewRow.Cells[14].Value);
				this.ProfPrms[num].hpfCornerFreq1 = Convert.ToUInt16(dataGridViewRow.Cells[15].Value);
				this.ProfPrms[num].hpfCornerFreq2 = Convert.ToUInt16(dataGridViewRow.Cells[16].Value);
				this.ProfPrms[num].tx1OutPowerBackoffCode = Convert.ToUInt32(dataGridViewRow.Cells[17].Value);
				this.ProfPrms[num].tx2OutPowerBackoffCode = Convert.ToUInt32(dataGridViewRow.Cells[18].Value);
				this.ProfPrms[num].tx3OutPowerBackoffCode = Convert.ToUInt32(dataGridViewRow.Cells[19].Value);
				this.ProfPrms[num].tx1PhaseShifter = Convert.ToSingle(dataGridViewRow.Cells[20].Value);
				this.ProfPrms[num].tx2PhaseShifter = Convert.ToSingle(dataGridViewRow.Cells[21].Value);
				this.ProfPrms[num].tx3PhaseShifter = Convert.ToSingle(dataGridViewRow.Cells[22].Value);
				num++;
			}
			this.m_btnActivate.Enabled = true;
			this.m_btnSave.ForeColor = Color.FromArgb(34, 139, 34);
		}

		private void m_btnActivate_Click(object sender, EventArgs p1)
		{
			int i = 0;
			int num = 0;
			int rowCount = this.dataGridView2.RowCount;
			foreach (object obj in ((IEnumerable)this.dataGridView2.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (num >= rowCount - 1)
				{
					break;
				}
				while (i < rowCount - (rowCount - 1))
				{
					this.ProfPrms[i].pprofileId = Convert.ToUInt16(dataGridViewRow.Cells[0].Value);
					this.ProfPrms[i].startFreqConst = Convert.ToSingle(dataGridViewRow.Cells[1].Value);
					this.ProfPrms[i].freqSlopeConst = Convert.ToSingle(dataGridViewRow.Cells[2].Value);
					this.ProfPrms[i].idleTimeConst = Convert.ToSingle(dataGridViewRow.Cells[3].Value);
					this.ProfPrms[i].txStartTime = Convert.ToSingle(dataGridViewRow.Cells[4].Value);
					this.ProfPrms[i].adcStartTimeConst = Convert.ToSingle(dataGridViewRow.Cells[5].Value);
					this.ProfPrms[i].pnumAdcSamples = Convert.ToUInt16(dataGridViewRow.Cells[6].Value);
					this.ProfPrms[i].digOutSampleRate = Convert.ToUInt16(dataGridViewRow.Cells[7].Value);
					this.ProfPrms[i].rampEndTime = Convert.ToSingle(dataGridViewRow.Cells[8].Value);
					this.ProfPrms[i].rxGain = Convert.ToUInt16(dataGridViewRow.Cells[9].Value);
					this.ProfPrms[i].rxGainTarget = Convert.ToUInt16(dataGridViewRow.Cells[10].Value);
					ushort num2;
					if (this.ProfPrms[i].rxGainTarget == 30)
					{
						num2 = 0;
					}
					else if (this.ProfPrms[i].rxGainTarget == 34)
					{
						num2 = 1;
					}
					else
					{
						if (this.ProfPrms[i].rxGainTarget != 26)
						{
							string msg = string.Format("Profile Config failed becuase configured invalid Rx Gain Target (Valid configuration: 30dB, 34dB and 26dB...!!!{0}", new object[]
							{
								i
							});
							GlobalRef.LuaWrapper.PrintError(msg);
							return;
						}
						num2 = 3;
					}
					num2 = (ushort)((int)this.ProfPrms[i].rxGain | (int)num2 << 6);
					this.ProfPrms[i].VCOSelect = Convert.ToUInt16(dataGridViewRow.Cells[11].Value);
					this.ProfPrms[i].forceVCOSelect = Convert.ToUInt16(dataGridViewRow.Cells[12].Value);
					uint num3 = (uint)((ushort)((int)this.ProfPrms[i].forceVCOSelect | (int)this.ProfPrms[i].VCOSelect << 1));
					this.ProfPrms[i].retainTxCalibLUT = Convert.ToUInt16(dataGridViewRow.Cells[13].Value);
					this.ProfPrms[i].retainRxCalibLUT = Convert.ToUInt16(dataGridViewRow.Cells[14].Value);
					uint num4 = (uint)((ushort)((int)this.ProfPrms[i].retainTxCalibLUT | (int)this.ProfPrms[i].retainRxCalibLUT << 1));
					this.ProfPrms[i].hpfCornerFreq1 = Convert.ToUInt16(dataGridViewRow.Cells[15].Value);
					uint num5;
					if (this.ProfPrms[i].hpfCornerFreq1 == 175)
					{
						num5 = 0U;
					}
					else if (this.ProfPrms[i].hpfCornerFreq1 == 235)
					{
						num5 = 1U;
					}
					else if (this.ProfPrms[i].hpfCornerFreq1 == 350)
					{
						num5 = 2U;
					}
					else
					{
						if (this.ProfPrms[i].hpfCornerFreq1 != 700)
						{
							string msg2 = string.Format("Profile Config {0} failed becuase configured invalid HPF CORNER FREQUENCY1 in kHz. (Valid configuration: 175 kHz, 235 kHz, 350 kHz, 700 kHz...!!!\n", new object[]
							{
								i
							});
							GlobalRef.LuaWrapper.PrintError(msg2);
							return;
						}
						num5 = 3U;
					}
					this.ProfPrms[i].hpfCornerFreq2 = Convert.ToUInt16(dataGridViewRow.Cells[16].Value);
					uint num6;
					if (this.ProfPrms[i].hpfCornerFreq2 == 350)
					{
						num6 = 0U;
					}
					else if (this.ProfPrms[i].hpfCornerFreq2 == 700)
					{
						num6 = 1U;
					}
					else if ((double)this.ProfPrms[i].hpfCornerFreq2 == 1.4)
					{
						num6 = 2U;
					}
					else
					{
						if ((double)this.ProfPrms[i].hpfCornerFreq2 != 2.8)
						{
							string msg3 = string.Format("Profile Config {0} failed becuase configured invalid HPF CORNER FREQUENCY2 in kHz OR MHz. (Valid configuration: 350kHz, 700kHz, 1.4MHz, 2.8MHz...!!!\n", new object[]
							{
								i
							});
							GlobalRef.LuaWrapper.PrintError(msg3);
							return;
						}
						num6 = 3U;
					}
					num6 = (num6 | num3 << 16 | num4 << 24);
					this.ProfPrms[i].tx1OutPowerBackoffCode = Convert.ToUInt32(dataGridViewRow.Cells[17].Value);
					this.ProfPrms[i].tx2OutPowerBackoffCode = Convert.ToUInt32(dataGridViewRow.Cells[18].Value);
					this.ProfPrms[i].tx3OutPowerBackoffCode = Convert.ToUInt32(dataGridViewRow.Cells[19].Value);
					this.ProfPrms[i].tx1PhaseShifter = Convert.ToSingle(dataGridViewRow.Cells[20].Value);
					this.ProfPrms[i].tx2PhaseShifter = Convert.ToSingle(dataGridViewRow.Cells[21].Value);
					this.ProfPrms[i].tx3PhaseShifter = Convert.ToSingle(dataGridViewRow.Cells[22].Value);
					if (this.m_AR1xxxExtOpps.SetProfile((ushort)GlobalRef.g_RadarDeviceId, this.ProfPrms[i].pprofileId, this.ProfPrms[i].startFreqConst, this.ProfPrms[i].idleTimeConst, this.ProfPrms[i].adcStartTimeConst, this.ProfPrms[i].rampEndTime, this.ProfPrms[i].tx1OutPowerBackoffCode, this.ProfPrms[i].tx2OutPowerBackoffCode, this.ProfPrms[i].tx3OutPowerBackoffCode, this.ProfPrms[i].tx1PhaseShifter, this.ProfPrms[i].tx2PhaseShifter, this.ProfPrms[i].tx3PhaseShifter, this.ProfPrms[i].freqSlopeConst, this.ProfPrms[i].txStartTime, this.ProfPrms[i].pnumAdcSamples, this.ProfPrms[i].digOutSampleRate, (uint)((ushort)num5), num6, (char)num2, 0) != 0)
					{
						string full_command = string.Format("Profile Config {0} failed, stopping.", new object[]
						{
							i
						});
						this.m_GuiManager.RecordLog(11, full_command);
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
			this.m_btnSave.ForeColor = Color.Red;
		}

		private void ProfManager_Load(object sender, EventArgs p1)
		{
		}

		private AR1xxxExtOpps m_AR1xxxExtOpps = GlobalRef.AR1xxxExtOpps;

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private char delimiter;

		public ProfParams[] ProfPrms = new ProfParams[16];
	}
}
