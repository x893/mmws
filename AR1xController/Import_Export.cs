using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AR1xController
{
	public class Import_Export : UserControl
	{
		public Import_Export()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_GuiManager.ScriptOps.Init_Setup();
			this.m_GuiManager.ScriptOps.Init_JSON_1();
			this.m_GuiManager.ScriptOps.getMmwaveDevIndex(0);
			this.m_btnDevice0.Visible = false;
			this.m_btnDevice1.Visible = false;
			this.m_btnDevice2.Visible = false;
			this.m_btnDevice3.Visible = false;
			this.m_btnDevice0.Checked = false;
			this.m_btnDevice1.Checked = false;
			this.m_btnDevice2.Checked = false;
			this.m_btnDevice3.Checked = false;
			this.m_btnSingleFrame.Enabled = false;
			this.m_btnAdvFrame.Enabled = false;
			this.m_btnContWave.Enabled = false;
		}

		private void label1_Click(object sender, EventArgs p1)
		{
		}

		private void textBox1_TextChanged(object sender, EventArgs p1)
		{
		}

		private void button1_Click(object sender, EventArgs p1)
		{
			string text = this.iHandleBrowseFiles("Setup_JSON", this.m_CaptureSetupFile.Text);
			if (!string.IsNullOrEmpty(text))
			{
				this.iSetPathInCombo(text, this.m_CaptureSetupFile);
			}
		}

		private string iHandleBrowseFiles(string file_type, string current_path)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (!(file_type == "FW") && !(file_type == "NVS"))
			{
				if (!(file_type == "INI"))
				{
					if (!(file_type == "DLL"))
					{
						if (!(file_type == "Setup_JSON"))
						{
							if (file_type == "mmWave_JSON")
							{
								openFileDialog.Title = "Browse for JSON mmWave file";
								openFileDialog.Filter = "JSON File (*.mmwave.json)|*.mmwave.json";
							}
						}
						else
						{
							openFileDialog.Title = "Browse for JSON Capture Setup file";
							openFileDialog.Filter = "JSON File (*.setup.json)|*.setup.json";
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
				openFileDialog.Title = "Browse for firmware file";
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

		public void iSetPathInSetupAndmmWave(string deviceType)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.iSetPathInSetupAndmmWave);
				base.Invoke(method, new object[]
				{
					deviceType
				});
				return;
			}
			string directoryName = Path.GetDirectoryName(Application.StartupPath);
			if (deviceType == "12xx")
			{
				this.m_CaptureSetupFile.Text = directoryName + "\\JSONSampleFiles\\12xx\\12xx.setup.json";
				this.m_jsonfile.Text = directoryName + "\\JSONSampleFiles\\12xx\\12xx.mmwave.json";
				return;
			}
			if (deviceType == "14xx")
			{
				this.m_CaptureSetupFile.Text = directoryName + "\\JSONSampleFiles\\14xx\\14xx.setup.json";
				this.m_jsonfile.Text = directoryName + "\\JSONSampleFiles\\14xx\\14xx.mmwave.json";
				return;
			}
			if (deviceType == "16xx")
			{
				this.m_CaptureSetupFile.Text = directoryName + "\\JSONSampleFiles\\16xx\\16xx.setup.json";
				this.m_jsonfile.Text = directoryName + "\\JSONSampleFiles\\16xx\\16xx.mmwave.json";
				return;
			}
			if (deviceType == "18xx")
			{
				this.m_CaptureSetupFile.Text = directoryName + "\\JSONSampleFiles\\18xx\\18xx.setup.json";
				this.m_jsonfile.Text = directoryName + "\\JSONSampleFiles\\18xx\\18xx.mmwave.json";
				return;
			}
			if (deviceType == "68xx")
			{
				this.m_CaptureSetupFile.Text = directoryName + "\\JSONSampleFiles\\68xx\\68xx.setup.json";
				this.m_jsonfile.Text = directoryName + "\\JSONSampleFiles\\68xx\\68xx.mmwave.json";
			}
		}

		public string GetPathforCaptureImport()
		{
			return this.m_CaptureSetupFile.Text;
		}

		private void m_btnImportCapture_Click(object sender, EventArgs p1)
		{
			string pathforCaptureImport = this.GetPathforCaptureImport();
			this.CaptureImport(pathforCaptureImport);
		}

		public int CaptureImport(string capturePath)
		{
			GlobalRef.jsonExecution = true;
			int num = this.m_GuiManager.ScriptOps.NumberDevices();
			if (num == 1)
			{
				string full_command = string.Format("Single Chip Configuration", new object[0]);
				this.m_GuiManager.RecordLog(0, full_command);
			}
			else if (num >= 1)
			{
				string full_command2 = string.Format("Multi Chip/ Cascade Configuration", new object[0]);
				this.m_GuiManager.RecordLog(0, full_command2);
			}
			if (string.IsNullOrEmpty(capturePath))
			{
				string msg = string.Format("Provide Valid Capture Setup File Path", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg);
				return -1;
			}
			string text = "";
			try
			{
				text = File.ReadAllText(capturePath);
			}
			catch (IOException)
			{
				string msg2 = string.Format("Invalid Capture Setup File Path", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg2);
				return -1;
			}
			try
			{
				if (text == string.Empty)
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				string msg3 = string.Format("Capture Setup data is empty", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg3);
				return -1;
			}
			try
			{
				GlobalRef.dobject = JsonConvert.DeserializeObject<SetupObject>(text);
			}
			catch (Exception)
			{
				string msg4 = string.Format("Invalid Capture Setup JSON File", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg4);
				return -1;
			}
			this.m_GuiManager.ScriptOps.Init_Setup();
			JObject jobject = JObject.Parse(text);
			if (jobject.SelectToken("createdByVersion") == null)
			{
				GlobalRef.dobject.createdByVersion = "";
			}
			if (jobject.SelectToken("createdOn") == null)
			{
				GlobalRef.dobject.createdOn = DateTime.Now;
			}
			if (jobject.SelectToken("configUsed") == null)
			{
				GlobalRef.dobject.configUsed = "";
			}
			if (jobject.SelectToken("captureHardware") == null)
			{
				GlobalRef.dobject.captureHardware = "";
			}
			if (jobject.SelectToken("DCA1000Config") == null)
			{
				GlobalRef.dobject.DCA1000Config = new DCA1000Config();
				GlobalRef.dobject.DCA1000Config.dataLoggingMode = "";
				GlobalRef.dobject.DCA1000Config.dataTransferMode = "";
				GlobalRef.dobject.DCA1000Config.dataCaptureMode = "";
				GlobalRef.dobject.DCA1000Config.packetSequenceEnable = 0;
				GlobalRef.dobject.DCA1000Config.packetDelay_us = 0;
			}
			if (jobject.SelectToken("mmWaveDevice") == null)
			{
				GlobalRef.dobject.mmWaveDevice = "";
			}
			if (jobject.SelectToken("operatingFreq") == null)
			{
				GlobalRef.dobject.operatingFreq = 0;
			}
			if (jobject.SelectToken("mmWaveDeviceConfig") == null)
			{
				GlobalRef.dobject.mmWaveDeviceConfig = new MmWaveDeviceConfig();
				GlobalRef.dobject.mmWaveDeviceConfig.p00001f = "";
				GlobalRef.dobject.mmWaveDeviceConfig.RS232BaudRate = "";
				GlobalRef.dobject.mmWaveDeviceConfig.radarSSFirmware = "";
				GlobalRef.dobject.mmWaveDeviceConfig.masterSSFirmware = "";
			}
			if (jobject.SelectToken("capturedFiles") == null)
			{
				GlobalRef.dobject.capturedFiles = new CapturedFiles();
				GlobalRef.dobject.capturedFiles.numFilesCollected = 0;
				GlobalRef.dobject.capturedFiles.fileBasePath = "";
			}
			this.iSetPathInCombo(GlobalRef.dobject.configUsed, this.m_jsonfile);
			this.m_GuiManager.ScriptOps.m0000a3(GlobalRef.dobject);
			GlobalRef.jsonExecution = false;
			return 0;
		}

		public string GetPathforJsonImport()
		{
			return this.m_jsonfile.Text;
		}

		private void button5_Click(object sender, EventArgs p1)
		{
			this.m_btnDevice0.Visible = false;
			this.m_btnDevice1.Visible = false;
			this.m_btnDevice2.Visible = false;
			this.m_btnDevice3.Visible = false;
			this.m_btnDevice0.Checked = false;
			this.m_btnDevice1.Checked = false;
			this.m_btnDevice2.Checked = false;
			this.m_btnDevice3.Checked = false;
			this.m_btnSingleFrame.Enabled = false;
			this.m_btnAdvFrame.Enabled = false;
			this.m_btnContWave.Enabled = false;
			this.jsonImport(this.GetPathforJsonImport());
			this.m_btnDevice0.Visible = (this.devPresent[0] == 1);
			this.m_btnDevice1.Visible = (this.devPresent[1] == 1);
			this.m_btnDevice2.Visible = (this.devPresent[2] == 1);
			this.m_btnDevice3.Visible = (this.devPresent[3] == 1);
			this.m_btnDevice0.Checked = (this.devSelected == 0);
			this.m_btnDevice1.Checked = (this.devSelected == 1);
			this.m_btnDevice2.Checked = (this.devSelected == 2);
			this.m_btnDevice3.Checked = (this.devSelected == 3);
		}

		private int iSetImportExport_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.m0000a4();
		}

		private void iSetImportExport()
		{
			this.iSetImportExport_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iImportExport()
		{
			new del_v_v(this.iSetImportExport).BeginInvoke(null, null);
		}

		private void m_btnSetup_Click(object sender, EventArgs p1)
		{
			this.iImportExport();
		}

		private void m_BrowseMmwave_Click(object sender, EventArgs p1)
		{
			string text = this.iHandleBrowseFiles("mmWave_JSON", this.m_jsonfile.Text);
			if (!string.IsNullOrEmpty(text))
			{
				this.iSetPathInCombo(text, this.m_jsonfile);
			}
		}

		public int GetDeviceId()
		{
			return this.devSelected;
		}

		public int SetDeviceId(int devId)
		{
			if (devId >= 0 && devId < 4)
			{
				this.devSelected = devId;
				return 0;
			}
			string msg = string.Format("Invalid device ID", new object[0]);
			GlobalRef.LuaWrapper.PrintError(msg);
			return -1;
		}

		public int jsonImport(string jsonPath)
		{
			GlobalRef.jsonExecution = true;
			try
			{
				if (!this.m_GuiManager.ScriptOps.iChecks())
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				string msg = string.Format("No device is connected", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg);
				return -1;
			}
			int num = this.m_GuiManager.ScriptOps.NumberDevices();
			if (num == 1)
			{
				string full_command = string.Format("Single Chip Configuration", new object[0]);
				this.m_GuiManager.RecordLog(0, full_command);
			}
			else if (num >= 1)
			{
				string full_command2 = string.Format("Multi Chip/ Cascade Configuration", new object[0]);
				this.m_GuiManager.RecordLog(0, full_command2);
			}
			if (string.IsNullOrEmpty(jsonPath))
			{
				string msg2 = string.Format("Provide Valid File Path", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg2);
				return -1;
			}
			string text = "";
			try
			{
				text = File.ReadAllText(jsonPath);
			}
			catch (IOException)
			{
				string msg3 = string.Format("Invalid File Path", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg3);
				return -1;
			}
			try
			{
				if (text == string.Empty)
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				string msg4 = string.Format("JSON data is empty", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg4);
				return -1;
			}
			try
			{
				GlobalRef.jobject = JsonConvert.DeserializeObject<RootObject>(text);
			}
			catch (Exception)
			{
				string msg5 = string.Format("Invalid File", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg5);
				return -1;
			}
			this.m_GuiManager.ScriptOps.Init_JSON_1();
			JArray jarray = (JArray)JObject.Parse(text)["mmWaveDevices"];
			this.length = jarray.Count;
			try
			{
				if (this.length != this.m_GuiManager.ScriptOps.NumberDevices())
				{
					throw new Exception();
				}
				string full_command3 = string.Format("No of devices connected and the no of devices in the json config are matching", new object[0]);
				this.m_GuiManager.RecordLog(0, full_command3);
			}
			catch (Exception)
			{
				string msg6 = string.Format(" There is a mismatch between the number of devices connected and the no of devices in the json config", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg6);
				return -1;
			}
			JObject jobject = JObject.Parse(text);
			for (int i = 0; i < this.length; i++)
			{
				if (GlobalRef.jobject.mmWaveDevices[i].mmWaveDeviceId == 0)
				{
					this.devPresent[0] = 1;
				}
				else if (GlobalRef.jobject.mmWaveDevices[i].mmWaveDeviceId == 1)
				{
					this.devPresent[1] = 1;
				}
				else if (GlobalRef.jobject.mmWaveDevices[i].mmWaveDeviceId == 2)
				{
					this.devPresent[2] = 1;
				}
				else if (GlobalRef.jobject.mmWaveDevices[i].mmWaveDeviceId == 3)
				{
					this.devPresent[3] = 1;
				}
			}
			if (this.devPresent[0] == 1)
			{
				this.devSelected = 0;
			}
			else if (this.devPresent[1] == 1)
			{
				this.devSelected = 1;
			}
			else if (this.devPresent[2] == 1)
			{
				this.devSelected = 2;
			}
			else if (this.devPresent[3] == 1)
			{
				this.devSelected = 3;
			}
			else
			{
				this.devSelected = -1;
			}
			string[] array = new string[]
			{
				"mmWaveDevices[0]",
				"mmWaveDevices[1]",
				"mmWaveDevices[2]",
				"mmWaveDevices[3]"
			};
			int num2 = 0;
			for (int j = 0; j < this.length; j++)
			{
				while (this.devPresent[num2] == 0 && num2 < 4)
				{
					num2++;
				}
				if (num2 == 4)
				{
					string msg7 = string.Format(" device Id is out of bound", new object[0]);
					GlobalRef.LuaWrapper.PrintError(msg7);
					return -1;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig") == null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig = new RfConfig();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.waveformType = "legacyFrameChirp";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.MIMOScheme = "TDM";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlCalibrationDataFile = "";
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlChanCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlChanCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlChanCfg_t = new RlChanCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlChanCfg_t.p000006 = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlChanCfg_t.p000007 = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlChanCfg_t.cascading = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlChanCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlAdcOutCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdcOutCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdcOutCfg_t = new RlAdcOutCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdcOutCfg_t.fmt = new Fmt();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdcOutCfg_t.fmt.b2AdcBits = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdcOutCfg_t.fmt.b8FullScaleReducFctr = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdcOutCfg_t.fmt.b2AdcOutFmt = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdcOutCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlLowPowerModeCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlLowPowerModeCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlLowPowerModeCfg_t = new RlLowPowerModeCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlLowPowerModeCfg_t.lpAdcMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlLowPowerModeCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlProfiles") == null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlProfiles = new List<RlProfiles>();
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlChirps") == null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlChirps = new List<RlChirps>();
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlAdvChirpCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvChirpCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvChirpCfg_t = new RlAdvChirpCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvChirpCfg_t.chirpParamIdx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvChirpCfg_t.resetMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvChirpCfg_t.patternMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvChirpCfg_t.resetPeriod = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvChirpCfg_t.fixedDeltaInc = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvChirpCfg_t.paramUpdatePeriod = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvChirpCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfCalMonTimeUntConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfCalMonTimeUntConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfCalMonTimeUntConf_t = new RlRfCalMonTimeUntConfT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfCalMonTimeUntConf_t.calibMonTimeUnit = 1;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfCalMonTimeUntConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfCalMonFreqLimitConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfCalMonFreqLimitConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfCalMonFreqLimitConf_t = new RlRfCalMonFreqLimitConfT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfCalMonFreqLimitConf_t.freqLimitHigh_GHz = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfCalMonFreqLimitConf_t.freqLimitLow_GHz = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfCalMonFreqLimitConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfInitCalConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfInitCalConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfInitCalConf_t = new RlRfInitCalConfT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfInitCalConf_t.calibEnMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfInitCalConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRunTimeCalibConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRunTimeCalibConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRunTimeCalibConf_t = new RlRunTimeCalibConfT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRunTimeCalibConf_t.oneTimeCalibEnMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRunTimeCalibConf_t.periodicCalibEnMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRunTimeCalibConf_t.calibPeriodicity = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRunTimeCalibConf_t.reportEn = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRunTimeCalibConf_t.txPowerCalMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRunTimeCalibConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlFrameCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlFrameCfg_t.isConfigured = 1;
					this.m_btnSingleFrame.Enabled = true;
					this.m_btnSingleFrame.Checked = true;
					this.m_btnAdvFrame.Checked = false;
					this.m_btnContWave.Checked = false;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlFrameCfg_t = new RlFrameCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlFrameCfg_t.chirpStartIdx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlFrameCfg_t.chirpEndIdx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlFrameCfg_t.numFrames = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlFrameCfg_t.numLoops = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlFrameCfg_t.framePeriodicity_msec = 0f;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlFrameCfg_t.numDummyChirpsAtEnd = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlFrameCfg_t.frameTriggerDelay = 0f;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlFrameCfg_t.triggerSelect = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlFrameCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlAdvFrameCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.isConfigured = 1;
					this.m_btnAdvFrame.Enabled = true;
					this.m_btnAdvFrame.Checked = true;
					this.m_btnSingleFrame.Checked = false;
					this.m_btnContWave.Checked = false;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t = new RlAdvFrameCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameSeq = new FrameSeq();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameSeq.numOfSubFrames = 1;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameSeq.forceProfile = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameSeq.numFrames = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameSeq.triggerSelect = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameSeq.frameTrigDelay_usec = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameSeq.loopBackCfg = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameTrigger = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg = new List<SubFrameCfg>();
					for (int k = 0; k < 4; k++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg.Add(new SubFrameCfg());
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[k].rlSubFrameCfg_t = new RlSubFrameCfgT();
					}
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameData = new FrameData();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameData.numSubFrames = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameData.subframeDataCfg = new List<SubframeDataCfg>();
					for (int l = 0; l < 4; l++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameData.subframeDataCfg.Add(new SubframeDataCfg());
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.frameData.subframeDataCfg[l].rlSubFrameDataCfg_t = new RlSubFrameDataCfgT();
					}
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlAdvFrameCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlContModeCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeCfg_t.isConfigured = 1;
					this.m_btnContWave.Enabled = true;
					this.m_btnContWave.Checked = true;
					this.m_btnAdvFrame.Checked = false;
					this.m_btnSingleFrame.Checked = false;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeCfg_t = new RlContModeCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeCfg_t.startFreqConst_GHz = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeCfg_t.digOutSampleRate = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeCfg_t.rxGain_dB = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeCfg_t.hpfCornerFreq1 = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeCfg_t.hpfCornerFreq2 = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeCfg_t.txOutPowerBackoffCode = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeCfg_t.txPhaseShifter = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeCfg_t.vcoSelect = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlContModeEn_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeEn_t.isConfigured = 1;
					this.m_btnContWave.Enabled = true;
					this.m_btnContWave.Checked = true;
					this.m_btnAdvFrame.Checked = false;
					this.m_btnSingleFrame.Checked = false;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeEn_t = new RlContModeEnT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeEn_t.contModeEn = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlContModeEn_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlBpmModeCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000010.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000010 = new c0001d2();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000010.b2SrcSel = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000010.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlBpmKCounterSel_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlBpmKCounterSel_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlBpmKCounterSel_t = new RlBpmKCounterSelT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlBpmKCounterSel_t.b1BpmKEnd = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlBpmKCounterSel_t.b1BpmKStart = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlBpmKCounterSel_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlBpmCommonCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000011.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000011 = new c0001d5();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000011.mode = new Mode();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000011.mode.b2SrcSel = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000011.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlBpmChirps") == null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000012 = new List<c0001d7>();
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfDevCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000013.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000013 = new c0001d8();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000013.aeDirection = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000013.aeControl = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000013.p000009 = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000013.p00000a = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000013.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfMiscConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfMiscConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfMiscConf_t = new RlRfMiscConfT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfMiscConf_t.miscCtl = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfMiscConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfTxFreqPwrLimitMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t = new RlRfTxFreqPwrLimitMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitLowTx0 = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitLowTx1 = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitLowTx2 = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitHighTx0 = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitHighTx1 = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitHighTx2 = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t.tx0PwrBackOff = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t.tx1PwrBackOff = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t.tx2PwrBackOff = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfTxFreqPwrLimitMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlDynPwrSave_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlDynPwrSave_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlDynPwrSave_t = new RlDynPwrSaveT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlDynPwrSave_t.p00000b = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlDynPwrSave_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlGpAdcCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000014.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000014 = new c0001de();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000014.enable = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000014.bufferEnable = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000014.numOfSamples = new List<RlGpAdcSamples>();
					for (int m = 0; m < 6; m++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000014.numOfSamples.Add(new RlGpAdcSamples());
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000014.numOfSamples[m].rlGpAdcSamples_t = new RlGpAdcSamplesT();
					}
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000014.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfPhaseShiftCfgs") == null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.p000015 = new List<RlRfPhaseShiftCfgT>();
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlInterChirpBlkCtrlCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t = new RlInterChirpBlkCtrlCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02RfTurnOffTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx13RfTurnOffTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02BbTurnOffTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx12BbTurnOffTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02RfPreEnTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx13RfPreEnTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02BbPreEnTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx13BbPreEnTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02RfTurnOnTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx13RfTurnOnTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02BbTurnOnTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rx13BbTurnOnTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rxLoChainTurnOffTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.txLoChainTurnOffTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.rxLoChainTurnOnTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.txLoChainTurnOnTime_us = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterChirpBlkCtrlCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfProgFiltCoeff_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfProgFiltCoeff_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfProgFiltCoeff_t = new RlRfProgFiltCoeffT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfProgFiltCoeff_t.coeffArray = new List<int>();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfProgFiltCoeff_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfProgFiltConfs") == null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfProgFiltConfs = new List<RlRfProgFiltConfT>();
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlInterRxGainPhConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterRxGainPhConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterRxGainPhConf_t = new RlInterRxGainPhConf();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterRxGainPhConf_t.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterRxGainPhConf_t.digRxGain = new List<double>();
					for (int n = 0; n < 4; n++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterRxGainPhConf_t.digRxGain.Add(0.0);
					}
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterRxGainPhConf_t.digRxPhShift = new List<double>();
					for (int num3 = 0; num3 < 4; num3++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterRxGainPhConf_t.digRxPhShift.Add(0.0);
					}
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlInterRxGainPhConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlTestSource_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t = new RlTestSourceT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t.rlTestSourceObjects = new List<RlTestSourceObjects>();
					for (int num4 = 0; num4 < 2; num4++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t.rlTestSourceObjects.Add(new RlTestSourceObjects());
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t.rlTestSourceObjects[num4].rlTestSourceObject_t = new RlTestSourceObjectT();
					}
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t.rlTestSourceRxAntPos = new List<RlTestSourceRxAntPos>();
					for (int num4 = 0; num4 < 4; num4++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t.rlTestSourceRxAntPos.Add(new RlTestSourceRxAntPos());
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t.rlTestSourceRxAntPos[num4].rlTestSourceAntPos_t = new RlTestSourceAntPosT();
					}
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t.rlTestSourceTxAntPos = new List<RlTestSourceTxAntPos>();
					for (int num4 = 0; num4 < 3; num4++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t.rlTestSourceTxAntPos.Add(new RlTestSourceTxAntPos());
						GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t.rlTestSourceTxAntPos[num4].rlTestSourceAntPos_t = new RlTestSourceAntPosT2();
					}
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSource_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlTestSourceEnable_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSourceEnable_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSourceEnable_t = new RlTestSourceEnableT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSourceEnable_t.tsEnable = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlTestSourceEnable_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfLdoBypassCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfLdoBypassCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfLdoBypassCfg_t = new RlRfLdoBypassCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfLdoBypassCfg_t.ldoBypassEnable = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfLdoBypassCfg_t.supplyMonIrDrop = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfLdoBypassCfg_t.ioSupplyIndicator = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfLdoBypassCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfPALoopbackCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPALoopbackCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPALoopbackCfg_t = new RlRfPALoopbackCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPALoopbackCfg_t.paLoopbackFreq_MHz = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPALoopbackCfg_t.p00000c = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPALoopbackCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfPSLoopbackCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPSLoopbackCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPSLoopbackCfg_t = new RlRfPSLoopbackCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPSLoopbackCfg_t.psLoopbackFreq_KHz = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPSLoopbackCfg_t.p00000d = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPSLoopbackCfg_t.psLoopbackTxId = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPSLoopbackCfg_t.pgaGainIndex = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfPSLoopbackCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlRfIFLoopbackCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfIFLoopbackCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfIFLoopbackCfg_t = new RlRfIFLoopbackCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfIFLoopbackCfg_t.ifLoopbackFreq = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfIFLoopbackCfg_t.ifLoopbackEn = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlRfIFLoopbackCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlLoopbackBursts") == null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlLoopbackBursts = new List<RlLoopbackBursts>();
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rllatentFault_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rllatentFault_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rllatentFault_t = new RllatentFaultT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rllatentFault_t.testEn1 = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rllatentFault_t.testEn2 = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rllatentFault_t.repMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rllatentFault_t.testMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rllatentFault_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlperiodicTest_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlperiodicTest_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlperiodicTest_t = new RlperiodicTestT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlperiodicTest_t.periodicity_msec = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlperiodicTest_t.testEn = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlperiodicTest_t.repMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlperiodicTest_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rltestPattern_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t = new RltestPatternT();
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.testPatGenCtrl = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.testPatGenTime = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.testPatrnPktSize = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.numTestPtrnPkts = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.testPatRx0Icfg = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.testPatRx0Qcfg = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.testPatRx1Icfg = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.testPatRx1Qcfg = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.testPatRx2Icfg = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.testPatRx2Qcfg = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.testPatRx3Icfg = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.testPatRx3Qcfg = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rltestPattern_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlDynChirpCfgs") == null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlDynChirpCfgs = new List<RlDynChirpCfgs>();
				}
				if (jobject.SelectToken(array[num2] + ".rfConfig.rlDynPerChirpPhShftCfgs") == null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rfConfig.rlDynPerChirpPhShftCfgs = new List<RlDynPerChirpPhShftCfgs>();
				}
				if (jobject.SelectToken(array[num2] + ".rawDataCaptureConfig") == null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig = new RawDataCaptureConfig();
				}
				if (jobject.SelectToken(array[num2] + ".rawDataCaptureConfig.rlDevDataFmtCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataFmtCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataFmtCfg_t = new RlDevDataFmtCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataFmtCfg_t.iqSwapSel = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataFmtCfg_t.chInterleave = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataFmtCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rawDataCaptureConfig.rlDevDataPathCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathCfg_t = new RlDevDataPathCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathCfg_t.intfSel = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathCfg_t.p000016 = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathCfg_t.p000017 = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathCfg_t.cqConfig = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathCfg_t.cq0TransSize = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathCfg_t.cq1TransSize = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathCfg_t.cq2TransSize = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rawDataCaptureConfig.rlDevLaneEnable_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevLaneEnable_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevLaneEnable_t = new RlDevLaneEnableT();
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevLaneEnable_t.laneEn = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevLaneEnable_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rawDataCaptureConfig.rlDevDataPathClkCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathClkCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathClkCfg_t = new RlDevDataPathClkCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathClkCfg_t.p000018 = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathClkCfg_t.dataRate_Mbps = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevDataPathClkCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rawDataCaptureConfig.rlDevLvdsLaneCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevLvdsLaneCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevLvdsLaneCfg_t = new RlDevLvdsLaneCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevLvdsLaneCfg_t.laneFmtMap = 0;
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevLvdsLaneCfg_t.laneParamCfg = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevLvdsLaneCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rawDataCaptureConfig.rlDevCsi2Cfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevCsi2Cfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevCsi2Cfg_t = new RlDevCsi2CfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevCsi2Cfg_t.lanePosPolSel = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevCsi2Cfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".rawDataCaptureConfig.rlDevMiscCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevMiscCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevMiscCfg_t = new RlDevMiscCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevMiscCfg_t.p00000a = "0";
					GlobalRef.jobject.mmWaveDevices[num2].rawDataCaptureConfig.rlDevMiscCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig") == null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig = new MonitoringConfig1();
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlMonDigEnables_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlMonDigEnables_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlMonDigEnables_t = new RlMonDigEnablesT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlMonDigEnables_t.enMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlMonDigEnables_t.testMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlMonDigEnables_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlDigMonPeriodicConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlDigMonPeriodicConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlDigMonPeriodicConf_t = new RlDigMonPeriodicConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlDigMonPeriodicConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlDigMonPeriodicConf_t.periodicEnableMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlDigMonPeriodicConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlMonAnaEnables_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlMonAnaEnables_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlMonAnaEnables_t = new RlMonAnaEnablesT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlMonAnaEnables_t.enMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlMonAnaEnables_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlTempMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTempMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTempMonConf_t = new RlTempMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTempMonConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTempMonConf_t.anaTempThreshMin = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTempMonConf_t.anaTempThreshMax = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTempMonConf_t.digTempThreshMin = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTempMonConf_t.digTempThreshMax = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTempMonConf_t.tempDiffThresh = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTempMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlRxGainPhaseMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t = new RlRxGainPhaseMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.rfFreqBitMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.txSel = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainAbsThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainFlatnessErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal = new List<List<double>>();
					for (int num5 = 0; num5 < 3; num5++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal.Add(new List<double>());
						for (int num6 = 0; num6 < 8; num6++)
						{
							GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[num5].Add(0.0);
						}
					}
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal = new List<List<double>>();
					for (int num5 = 0; num5 < 3; num5++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal.Add(new List<double>());
						for (int num7 = 0; num7 < 8; num7++)
						{
							GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[num5].Add(0.0);
						}
					}
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxGainPhaseMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlRxNoiseMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxNoiseMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxNoiseMonConf_t = new RlRxNoiseMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxNoiseMonConf_t.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxNoiseMonConf_t.rfFreqBitMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxNoiseMonConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxNoiseMonConf_t.noiseThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxNoiseMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlRxIfStageMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIfStageMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIfStageMonConf_t = new RlRxIfStageMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIfStageMonConf_t.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIfStageMonConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIfStageMonConf_t.hpfCutoffErrThresh = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIfStageMonConf_t.lpfCutoffErrThresh = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIfStageMonConf_t.ifaGainErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIfStageMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlAllTxPowMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t = new RlAllTxPowMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg = new Tx0PowrMonCfg();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.rfFreqBitMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.txPowAbsErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.txPowFlatnessErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg = new Tx1PowrMonCfg();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.rfFreqBitMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.txPowAbsErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.txPowFlatnessErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg = new Tx2PowrMonCfg();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.rfFreqBitMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.txPowAbsErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.txPowFlatnessErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxPowMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlAllTxBallBreakMonCfg_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t = new RlAllTxBallBreakMonCfgT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t.p000019 = new c000213();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t.p000019.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t.p000019.txReflCoeffMagThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t.p00001a = new c000214();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t.p00001a.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t.p00001a.txReflCoeffMagThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t.p00001b = new c000215();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t.p00001b.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t.p00001b.txReflCoeffMagThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBallBreakMonCfg_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlTxGainPhaseMismatchMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t = new RlTxGainPhaseMismatchMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.rfFreqBitMask = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txEn = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal = new List<List<double>>();
					for (int num8 = 0; num8 < 3; num8++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal.Add(new List<double>());
						for (int num9 = 0; num9 < 6; num9++)
						{
							GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[num8].Add(0.0);
						}
					}
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal = new List<List<double>>();
					for (int num8 = 0; num8 < 3; num8++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal.Add(new List<double>());
						for (int num10 = 0; num10 < 6; num10++)
						{
							GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[num8].Add(0.0);
						}
					}
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlAllTxBpmMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t = new RlAllTxBpmMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001c = new c000218();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.rxEn = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.txBpmPhaseErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.txBpmAmplErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001d = new c000219();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.rxEn = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.txBpmPhaseErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.txBpmAmplErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001e = new c00021a();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.rxEn = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.txBpmPhaseErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.txBpmAmplErrThresh = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxBpmMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlSynthFreqMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSynthFreqMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSynthFreqMonConf_t = new RlSynthFreqMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSynthFreqMonConf_t.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSynthFreqMonConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSynthFreqMonConf_t.freqErrThresh = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSynthFreqMonConf_t.monStartTime = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSynthFreqMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlExtAnaSignalsMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlExtAnaSignalsMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlExtAnaSignalsMonConf_t = new RlExtAnaSignalsMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlExtAnaSignalsMonConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlExtAnaSignalsMonConf_t.signalInpEnables = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlExtAnaSignalsMonConf_t.signalBuffEnables = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlExtAnaSignalsMonConf_t.signalSettlingTime = new List<double>();
					for (int num11 = 0; num11 < 6; num11++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlExtAnaSignalsMonConf_t.signalSettlingTime.Add(0.0);
					}
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh = new List<double>();
					for (int num11 = 0; num11 < 12; num11++)
					{
						GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh.Add(0.0);
					}
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlExtAnaSignalsMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlAllTxIntAnaSignalsMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t = new RlAllTxIntAnaSignalsMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx0IntAnaSgnlMonCfg = new Tx0IntAnaSgnlMonCfg();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx0IntAnaSgnlMonCfg.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx0IntAnaSgnlMonCfg.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx1IntAnaSgnlMonCfg = new Tx1IntAnaSgnlMonCfg();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx1IntAnaSgnlMonCfg.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx1IntAnaSgnlMonCfg.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx2IntAnaSgnlMonCfg = new Tx2IntAnaSgnlMonCfg();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx2IntAnaSgnlMonCfg.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx2IntAnaSgnlMonCfg.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlRxIntAnaSignalsMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIntAnaSignalsMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIntAnaSignalsMonConf_t = new RlRxIntAnaSignalsMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIntAnaSignalsMonConf_t.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIntAnaSignalsMonConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxIntAnaSignalsMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlPmClkLoIntAnaSignalsMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlPmClkLoIntAnaSignalsMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlPmClkLoIntAnaSignalsMonConf_t = new RlPmClkLoIntAnaSignalsMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlPmClkLoIntAnaSignalsMonConf_t.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlPmClkLoIntAnaSignalsMonConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlPmClkLoIntAnaSignalsMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlGpadcIntAnaSignalsMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlGpadcIntAnaSignalsMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlGpadcIntAnaSignalsMonConf_t = new RlGpadcIntAnaSignalsMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlGpadcIntAnaSignalsMonConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlGpadcIntAnaSignalsMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlPllContrVoltMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlPllContrVoltMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlPllContrVoltMonConf_t = new RlPllContrVoltMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlPllContrVoltMonConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlPllContrVoltMonConf_t.signalEnables = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlPllContrVoltMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlDualClkCompMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlDualClkCompMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlDualClkCompMonConf_t = new RlDualClkCompMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlDualClkCompMonConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlDualClkCompMonConf_t.dccPairEnables = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlDualClkCompMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlRxSatMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxSatMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxSatMonConf_t = new RlRxSatMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxSatMonConf_t.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxSatMonConf_t.satMonSel = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxSatMonConf_t.primarySliceDuration = 0.0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxSatMonConf_t.numSlices = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxSatMonConf_t.rxChannelMask = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxSatMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlSigImgMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSigImgMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSigImgMonConf_t = new RlSigImgMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSigImgMonConf_t.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSigImgMonConf_t.numSlices = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSigImgMonConf_t.timeSliceNumSamples = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlSigImgMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlRxMixInPwrMonConf_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxMixInPwrMonConf_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxMixInPwrMonConf_t = new RlRxMixInPwrMonConfT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxMixInPwrMonConf_t.profileIndx = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxMixInPwrMonConf_t.reportMode = 0;
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxMixInPwrMonConf_t.txEnable = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxMixInPwrMonConf_t.thresholds = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlRxMixInPwrMonConf_t.isConfigured = 0;
				}
				if (jobject.SelectToken(array[num2] + ".monitoringConfig.rlAnaFaultInj_t") != null)
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.isConfigured = 1;
				}
				else
				{
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t = new RlAnaFaultInjT();
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.rxGainDrop = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.rxPhInv = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.rxHighNoise = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.rxIfStagesFault = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.rxLoAmpFault = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.txLoAmpFault = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.txGainDrop = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.txPhInv = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.synthFault = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.supplyLdoFault = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.miscFault = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.miscThreshFault = "0";
					GlobalRef.jobject.mmWaveDevices[num2].monitoringConfig.rlAnaFaultInj_t.isConfigured = 0;
				}
				if (GlobalRef.jobject.mmWaveDevices[num2].rfConfig.waveformType == "legacyFrameChirp")
				{
					this.m_btnSingleFrame.Enabled = true;
					this.m_btnSingleFrame.Checked = true;
				}
				else if (GlobalRef.jobject.mmWaveDevices[num2].rfConfig.waveformType == "advancedFrameChirp")
				{
					this.m_btnAdvFrame.Enabled = true;
					this.m_btnAdvFrame.Checked = true;
				}
				else if (GlobalRef.jobject.mmWaveDevices[num2].rfConfig.waveformType == "continuousWave")
				{
					this.m_btnContWave.Enabled = true;
					this.m_btnContWave.Checked = true;
				}
				num2++;
			}
			GlobalRef.jsonExecution = false;
			return 0;
		}

		private void m_BtnLoad_Click(object sender, EventArgs p1)
		{
			this.m_GuiManager.ScriptOps.m0000a5(GlobalRef.jobject);
		}

		private void iExecuteMmwave()
		{
			this.m_GuiManager.ScriptOps.m0000a6(GlobalRef.jobject);
		}

		private void m_BtnConfigureDevice_Click(object sender, EventArgs p1)
		{
			GlobalRef.dobject.configUsed = this.m_jsonfile.Text;
			new del_v_v(this.iExecuteMmwave).BeginInvoke(null, null);
		}

		public string GetPathforJsonExport()
		{
			return this.m_jsonfile.Text;
		}

		private string iHandleSaveFiles(string file_type, string current_path)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (!(file_type == "Setup_JSON"))
			{
				if (file_type == "mmWave_JSON")
				{
					saveFileDialog.Title = "Export mmWave JSON file";
					saveFileDialog.Filter = "JSON File (*.mmwave.json)|*.mmwave.json";
				}
			}
			else
			{
				saveFileDialog.Title = "Export Setup JSON file";
				saveFileDialog.Filter = "JSON File (*.setup.json)|*.setup.json";
			}
			saveFileDialog.RestoreDirectory = true;
			if (!string.IsNullOrEmpty(current_path) && File.Exists(current_path))
			{
				saveFileDialog.InitialDirectory = Path.GetDirectoryName(current_path);
			}
			saveFileDialog.ShowDialog();
			return saveFileDialog.FileName;
		}

		public bool getSingleFrameStatus()
		{
			return this.m_btnSingleFrame.Checked;
		}

		public bool getAdvancedFrameStatus()
		{
			return this.m_btnAdvFrame.Checked;
		}

		public bool getContWaveStatus()
		{
			return this.m_btnContWave.Checked;
		}

		public void TriggerExport(string CapturePath, string mmWavePath)
		{
			GlobalRef.dobject.createdByVersion = "1.0.0.0";
			GlobalRef.dobject.createdOn = DateTime.Now;
			GlobalRef.dobject.configUsed = this.m_jsonfile.Text;
			if (!GlobalRef.g_RFDataCaptureMode)
			{
				GlobalRef.dobject.DCA1000Config = null;
			}
			this.jsonExport(CapturePath, mmWavePath);
		}

		public void TransferFiles_ExportJSON(string jsonPath_Capture, string jsonPath_mmwave)
		{
			if (GlobalRef.jobject.configGenerator.isConfigured == 1 && GlobalRef.jobject.currentVersion.isConfigured == 1 && GlobalRef.jobject.lastBackwardCompatibleVersion.isConfigured == 1 && GlobalRef.jobject.systemConfig.isConfigured == 1)
			{
				int num = 0;
				while ((long)num < (long)((ulong)GlobalRef.g_NumOfRadarDevicesDetected))
				{
					if (GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlChanCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlAdcOutCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlLowPowerModeCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlProfiles.Count == 0 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlChirps.Count == 0 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlRfCalMonTimeUntConf_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlRfCalMonFreqLimitConf_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlRfInitCalConf_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlRunTimeCalibConf_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlFrameCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlRfLdoBypassCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rawDataCaptureConfig.rlDevDataFmtCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rawDataCaptureConfig.rlDevDataPathCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rawDataCaptureConfig.rlDevLaneEnable_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rawDataCaptureConfig.rlDevDataPathClkCfg_t.isConfigured != 1)
					{
						GlobalRef.jobject.configGenerator.isConfigIntermediate = 1;
						break;
					}
					GlobalRef.jobject.configGenerator.isConfigIntermediate = 0;
					num++;
				}
			}
			this.jsonExport(jsonPath_Capture, jsonPath_mmwave);
		}

		private void m_BtnExport_Click(object sender, EventArgs p1)
		{
			if (GlobalRef.jobject.configGenerator.isConfigured == 1 && GlobalRef.jobject.currentVersion.isConfigured == 1 && GlobalRef.jobject.lastBackwardCompatibleVersion.isConfigured == 1 && GlobalRef.jobject.systemConfig.isConfigured == 1)
			{
				int num = 0;
				while ((long)num < (long)((ulong)GlobalRef.g_NumOfRadarDevicesDetected))
				{
					if (GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlChanCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlAdcOutCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlLowPowerModeCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlProfiles.Count == 0 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlChirps.Count == 0 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlRfCalMonTimeUntConf_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlRfCalMonFreqLimitConf_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlRfInitCalConf_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlRunTimeCalibConf_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlFrameCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rfConfig.rlRfLdoBypassCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rawDataCaptureConfig.rlDevDataFmtCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rawDataCaptureConfig.rlDevDataPathCfg_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rawDataCaptureConfig.rlDevLaneEnable_t.isConfigured != 1 || GlobalRef.jobject.mmWaveDevices[num].rawDataCaptureConfig.rlDevDataPathClkCfg_t.isConfigured != 1)
					{
						GlobalRef.jobject.configGenerator.isConfigIntermediate = 1;
						break;
					}
					GlobalRef.jobject.configGenerator.isConfigIntermediate = 0;
					num++;
				}
			}
			this.ConfigFile = this.m_jsonfile.Text;
			GlobalRef.LuaWrapper.PrintWarning("Provide the path and filename for the Export of Capture Setup JSON configuration.");
			string text = this.iHandleSaveFiles("Setup_JSON", this.m_CaptureSetupFile.Text);
			if (!string.IsNullOrEmpty(text))
			{
				this.iSetPathInCombo(text, this.m_CaptureSetupFile);
			}
			GlobalRef.LuaWrapper.PrintWarning("Provide the path and filename for the Export of mmWave JSON configuration.");
			string text2 = this.iHandleSaveFiles("mmWave_JSON", this.m_jsonfile.Text);
			if (!string.IsNullOrEmpty(text2))
			{
				this.iSetPathInCombo(text2, this.m_jsonfile);
			}
			this.jsonExport(this.m_CaptureSetupFile.Text, this.m_jsonfile.Text);
		}

		public int jsonExport(string jsonPath_Capture, string jsonPath_mmwave)
		{
			GlobalRef.jsonExecution = true;
			GlobalRef.dobject.createdByVersion = "2.1.0";
			GlobalRef.dobject.createdOn = DateTime.Now;
			GlobalRef.jobject.configGenerator.createdBy = "mmWaveStudio";
			if (GlobalRef.lua_method == 1)
			{
				this.ConfigFile = this.m_jsonfile.Text;
			}
			GlobalRef.dobject.configUsed = jsonPath_mmwave;
			if (!GlobalRef.g_RFDataCaptureMode)
			{
				GlobalRef.dobject.DCA1000Config = null;
			}
			this.m_GuiManager.ScriptOps.getCaptureCard(GlobalRef.dobject);
			this.m_GuiManager.ScriptOps.GetEthernetConfig(GlobalRef.dobject);
			this.m_GuiManager.ScriptOps.ConnectUpdate(GlobalRef.dobject);
			if (GlobalRef.g_4ChipCascade || GlobalRef.g_2ChipCascade)
			{
				this.m_GuiManager.ScriptOps.GetCapturedFilesInfo();
			}
			this.m_GuiManager.ScriptOps.GetAdditionalCapturedFilesInfo();
			if (string.IsNullOrEmpty(jsonPath_Capture))
			{
				string msg = string.Format("Provide non-empty file path", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg);
				return -1;
			}
			if (string.IsNullOrEmpty(jsonPath_mmwave))
			{
				string msg2 = string.Format("Provide non-empty file path", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg2);
				return -1;
			}
			string path = Path.GetDirectoryName(Application.StartupPath) + "\\Clients\\AR1xController\\JSONTemp.mmave.json";
			try
			{
				string contents = JsonConvert.SerializeObject(GlobalRef.dobject, Formatting.Indented, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				string contents2 = JsonConvert.SerializeObject(GlobalRef.jobject, Formatting.Indented, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				File.WriteAllText(jsonPath_Capture, contents);
				File.WriteAllText(jsonPath_mmwave, contents2);
			}
			catch (Exception)
			{
				string msg3 = string.Format("Invalid File", new object[0]);
				GlobalRef.LuaWrapper.PrintError(msg3);
				return -1;
			}
			int result;
			try
			{
				StreamReader streamReader = new StreamReader(jsonPath_mmwave);
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				StreamWriter streamWriter = new StreamWriter(path);
				int[] array = new int[1000];
				int[] array2 = new int[1000];
				int[] array3 = new int[1000];
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int[] array4 = new int[25];
				int num4 = 0;
				int num5 = 0;
				string text = streamReader.ReadLine();
				num3++;
				while (text != null)
				{
					if (-1 != text.IndexOf("{"))
					{
						array4[num4] = num3;
						num4++;
					}
					if (-1 != text.IndexOf("}"))
					{
						num4--;
						if (num5 == 1)
						{
							array[num2] = array4[num4];
							array2[num2] = num3;
							num2++;
							num5 = 0;
						}
					}
					if (-1 != text.IndexOf("\"isConfigured\": 0"))
					{
						num5 = 1;
					}
					else if (-1 != text.IndexOf("\"isConfigured\": 1"))
					{
						array3[num] = num3 - 1;
						num++;
					}
					text = streamReader.ReadLine();
					num3++;
				}
				streamReader.Close();
				num3 = 0;
				streamReader = new StreamReader(jsonPath_mmwave);
				text = streamReader.ReadLine();
				num3++;
				int num6 = 1;
				int num7 = 0;
				int num8 = 0;
				while (text != null)
				{
					if (num3 == array[num7])
					{
						num6 = 0;
					}
					if (num6 == 1)
					{
						if (num3 == array3[num8])
						{
							text = text.Trim(new char[]
							{
								','
							});
							num8++;
						}
						streamWriter.WriteLine(text);
					}
					if (num3 == array2[num7])
					{
						num6 = 1;
						num7++;
					}
					text = streamReader.ReadLine();
					num3++;
				}
				streamWriter.Close();
				streamReader.Close();
				streamReader = new StreamReader(path);
				streamWriter = new StreamWriter(jsonPath_mmwave);
				num3 = 0;
				text = streamReader.ReadLine();
				num3++;
				while (text != null)
				{
					if (-1 != text.IndexOf("},"))
					{
						string text2 = streamReader.ReadLine();
						if (-1 != text2.IndexOf("}"))
						{
							text = text.Trim(new char[]
							{
								','
							});
							streamWriter.WriteLine(text);
							streamWriter.WriteLine(text2);
						}
						else
						{
							streamWriter.WriteLine(text);
							if (-1 == text2.IndexOf("isConfigured"))
							{
								streamWriter.WriteLine(text2);
							}
						}
					}
					else if (-1 == text.IndexOf("isConfigured"))
					{
						streamWriter.WriteLine(text);
					}
					text = streamReader.ReadLine();
					num3++;
				}
				streamWriter.Close();
				streamReader.Close();
				File.Delete(path);
				GlobalRef.LuaWrapper.PrintWarning("Export Operation was successful!");
				GlobalRef.lua_method = 0;
				GlobalRef.jsonExecution = false;
				result = 0;
			}
			catch
			{
				GlobalRef.LuaWrapper.PrintWarning("Export Operation was not successful!");
				GlobalRef.lua_method = 1;
				result = -1;
			}
			return result;
		}

		private void m_btnDevice0_CheckedChanged(object sender, EventArgs p1)
		{
			this.SetDeviceId(0);
		}

		private void m_btnDevice1_CheckedChanged(object sender, EventArgs p1)
		{
			this.SetDeviceId(1);
		}

		private void m_btnDevice2_CheckedChanged(object sender, EventArgs p1)
		{
			this.SetDeviceId(2);
		}

		private void m_btnDevice3_CheckedChanged(object sender, EventArgs p1)
		{
			this.SetDeviceId(3);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.m_CaptureSetupFile = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.m_btnBrowseCapture = new System.Windows.Forms.Button();
            this.m_btnImportCapture = new System.Windows.Forms.Button();
            this.m_btnSetup = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.m_jsonfile = new System.Windows.Forms.ComboBox();
            this.m_BrowseMmwave = new System.Windows.Forms.Button();
            this.m_BtnImport = new System.Windows.Forms.Button();
            this.m_BtnLoad = new System.Windows.Forms.Button();
            this.m_BtnConfigureDevice = new System.Windows.Forms.Button();
            this.m_btnDevice0 = new System.Windows.Forms.RadioButton();
            this.m_btnDevice1 = new System.Windows.Forms.RadioButton();
            this.m_btnDevice2 = new System.Windows.Forms.RadioButton();
            this.m_btnDevice3 = new System.Windows.Forms.RadioButton();
            this.m_BtnExport = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.m_btnSingleFrame = new System.Windows.Forms.RadioButton();
            this.m_btnAdvFrame = new System.Windows.Forms.RadioButton();
            this.m_btnContWave = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(320, 49);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 14);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "* Files should be in JSON format *\r\n";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_CaptureSetupFile
            // 
            this.m_CaptureSetupFile.FormattingEnabled = true;
            this.m_CaptureSetupFile.Location = new System.Drawing.Point(74, 122);
            this.m_CaptureSetupFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_CaptureSetupFile.Name = "m_CaptureSetupFile";
            this.m_CaptureSetupFile.Size = new System.Drawing.Size(332, 21);
            this.m_CaptureSetupFile.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(74, 97);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(223, 14);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Capture Setup File";
            // 
            // m_btnBrowseCapture
            // 
            this.m_btnBrowseCapture.Location = new System.Drawing.Point(418, 117);
            this.m_btnBrowseCapture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnBrowseCapture.Name = "m_btnBrowseCapture";
            this.m_btnBrowseCapture.Size = new System.Drawing.Size(34, 28);
            this.m_btnBrowseCapture.TabIndex = 3;
            this.m_btnBrowseCapture.Text = "...";
            this.m_btnBrowseCapture.UseVisualStyleBackColor = true;
            // 
            // m_btnImportCapture
            // 
            this.m_btnImportCapture.Location = new System.Drawing.Point(474, 117);
            this.m_btnImportCapture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnImportCapture.Name = "m_btnImportCapture";
            this.m_btnImportCapture.Size = new System.Drawing.Size(88, 28);
            this.m_btnImportCapture.TabIndex = 4;
            this.m_btnImportCapture.Text = "Import";
            this.m_btnImportCapture.UseVisualStyleBackColor = true;
            // 
            // m_btnSetup
            // 
            this.m_btnSetup.Location = new System.Drawing.Point(578, 117);
            this.m_btnSetup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnSetup.Name = "m_btnSetup";
            this.m_btnSetup.Size = new System.Drawing.Size(88, 28);
            this.m_btnSetup.TabIndex = 5;
            this.m_btnSetup.Text = "Setup";
            this.m_btnSetup.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Window;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(74, 162);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(223, 14);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "mmWave Configuration File";
            // 
            // m_jsonfile
            // 
            this.m_jsonfile.FormattingEnabled = true;
            this.m_jsonfile.Location = new System.Drawing.Point(74, 189);
            this.m_jsonfile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_jsonfile.Name = "m_jsonfile";
            this.m_jsonfile.Size = new System.Drawing.Size(332, 21);
            this.m_jsonfile.TabIndex = 7;
            // 
            // m_BrowseMmwave
            // 
            this.m_BrowseMmwave.Location = new System.Drawing.Point(418, 184);
            this.m_BrowseMmwave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_BrowseMmwave.Name = "m_BrowseMmwave";
            this.m_BrowseMmwave.Size = new System.Drawing.Size(34, 28);
            this.m_BrowseMmwave.TabIndex = 8;
            this.m_BrowseMmwave.Text = "...";
            this.m_BrowseMmwave.UseVisualStyleBackColor = true;
            // 
            // m_BtnImport
            // 
            this.m_BtnImport.Location = new System.Drawing.Point(474, 184);
            this.m_BtnImport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_BtnImport.Name = "m_BtnImport";
            this.m_BtnImport.Size = new System.Drawing.Size(88, 28);
            this.m_BtnImport.TabIndex = 9;
            this.m_BtnImport.Text = "Import";
            this.m_BtnImport.UseVisualStyleBackColor = true;
            // 
            // m_BtnLoad
            // 
            this.m_BtnLoad.Location = new System.Drawing.Point(578, 184);
            this.m_BtnLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_BtnLoad.Name = "m_BtnLoad";
            this.m_BtnLoad.Size = new System.Drawing.Size(88, 28);
            this.m_BtnLoad.TabIndex = 10;
            this.m_BtnLoad.Text = "Load";
            this.m_BtnLoad.UseVisualStyleBackColor = true;
            // 
            // m_BtnConfigureDevice
            // 
            this.m_BtnConfigureDevice.Location = new System.Drawing.Point(683, 184);
            this.m_BtnConfigureDevice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_BtnConfigureDevice.Name = "m_BtnConfigureDevice";
            this.m_BtnConfigureDevice.Size = new System.Drawing.Size(107, 28);
            this.m_BtnConfigureDevice.TabIndex = 11;
            this.m_BtnConfigureDevice.Text = "Configure Device";
            this.m_BtnConfigureDevice.UseVisualStyleBackColor = true;
            // 
            // m_btnDevice0
            // 
            this.m_btnDevice0.AutoSize = true;
            this.m_btnDevice0.Location = new System.Drawing.Point(8, 7);
            this.m_btnDevice0.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnDevice0.Name = "m_btnDevice0";
            this.m_btnDevice0.Size = new System.Drawing.Size(68, 17);
            this.m_btnDevice0.TabIndex = 12;
            this.m_btnDevice0.TabStop = true;
            this.m_btnDevice0.Text = "Device 0";
            this.m_btnDevice0.UseVisualStyleBackColor = true;
            // 
            // m_btnDevice1
            // 
            this.m_btnDevice1.AutoSize = true;
            this.m_btnDevice1.Location = new System.Drawing.Point(93, 7);
            this.m_btnDevice1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnDevice1.Name = "m_btnDevice1";
            this.m_btnDevice1.Size = new System.Drawing.Size(68, 17);
            this.m_btnDevice1.TabIndex = 13;
            this.m_btnDevice1.TabStop = true;
            this.m_btnDevice1.Text = "Device 1";
            this.m_btnDevice1.UseVisualStyleBackColor = true;
            // 
            // m_btnDevice2
            // 
            this.m_btnDevice2.AutoSize = true;
            this.m_btnDevice2.Location = new System.Drawing.Point(185, 7);
            this.m_btnDevice2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnDevice2.Name = "m_btnDevice2";
            this.m_btnDevice2.Size = new System.Drawing.Size(68, 17);
            this.m_btnDevice2.TabIndex = 14;
            this.m_btnDevice2.TabStop = true;
            this.m_btnDevice2.Text = "Device 2";
            this.m_btnDevice2.UseVisualStyleBackColor = true;
            // 
            // m_btnDevice3
            // 
            this.m_btnDevice3.AutoSize = true;
            this.m_btnDevice3.Location = new System.Drawing.Point(275, 7);
            this.m_btnDevice3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnDevice3.Name = "m_btnDevice3";
            this.m_btnDevice3.Size = new System.Drawing.Size(68, 17);
            this.m_btnDevice3.TabIndex = 15;
            this.m_btnDevice3.TabStop = true;
            this.m_btnDevice3.Text = "Device 3";
            this.m_btnDevice3.UseVisualStyleBackColor = true;
            // 
            // m_BtnExport
            // 
            this.m_BtnExport.Location = new System.Drawing.Point(474, 240);
            this.m_BtnExport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_BtnExport.Name = "m_BtnExport";
            this.m_BtnExport.Size = new System.Drawing.Size(88, 28);
            this.m_BtnExport.TabIndex = 16;
            this.m_BtnExport.Text = "Export";
            this.m_BtnExport.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Window;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(88, 301);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(168, 14);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "Select the Waveform type";
            // 
            // m_btnSingleFrame
            // 
            this.m_btnSingleFrame.AutoSize = true;
            this.m_btnSingleFrame.Location = new System.Drawing.Point(7, 6);
            this.m_btnSingleFrame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnSingleFrame.Name = "m_btnSingleFrame";
            this.m_btnSingleFrame.Size = new System.Drawing.Size(113, 17);
            this.m_btnSingleFrame.TabIndex = 18;
            this.m_btnSingleFrame.TabStop = true;
            this.m_btnSingleFrame.Text = "Single Frame Chirp";
            this.m_btnSingleFrame.UseVisualStyleBackColor = true;
            // 
            // m_btnAdvFrame
            // 
            this.m_btnAdvFrame.AutoSize = true;
            this.m_btnAdvFrame.Location = new System.Drawing.Point(7, 28);
            this.m_btnAdvFrame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnAdvFrame.Name = "m_btnAdvFrame";
            this.m_btnAdvFrame.Size = new System.Drawing.Size(133, 17);
            this.m_btnAdvFrame.TabIndex = 19;
            this.m_btnAdvFrame.TabStop = true;
            this.m_btnAdvFrame.Text = "Advanced Frame Chirp";
            this.m_btnAdvFrame.UseVisualStyleBackColor = true;
            // 
            // m_btnContWave
            // 
            this.m_btnContWave.AutoSize = true;
            this.m_btnContWave.Location = new System.Drawing.Point(7, 50);
            this.m_btnContWave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.m_btnContWave.Name = "m_btnContWave";
            this.m_btnContWave.Size = new System.Drawing.Size(110, 17);
            this.m_btnContWave.TabIndex = 20;
            this.m_btnContWave.TabStop = true;
            this.m_btnContWave.Text = "Continuous Wave";
            this.m_btnContWave.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnDevice3);
            this.panel1.Controls.Add(this.m_btnDevice2);
            this.panel1.Controls.Add(this.m_btnDevice1);
            this.panel1.Controls.Add(this.m_btnDevice0);
            this.panel1.Location = new System.Drawing.Point(67, 240);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 35);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btnContWave);
            this.panel2.Controls.Add(this.m_btnAdvFrame);
            this.panel2.Controls.Add(this.m_btnSingleFrame);
            this.panel2.Location = new System.Drawing.Point(74, 318);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 76);
            this.panel2.TabIndex = 22;
            // 
            // Import_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.m_BtnExport);
            this.Controls.Add(this.m_BtnConfigureDevice);
            this.Controls.Add(this.m_BtnLoad);
            this.Controls.Add(this.m_BtnImport);
            this.Controls.Add(this.m_BrowseMmwave);
            this.Controls.Add(this.m_jsonfile);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.m_btnSetup);
            this.Controls.Add(this.m_btnImportCapture);
            this.Controls.Add(this.m_btnBrowseCapture);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.m_CaptureSetupFile);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Import_Export";
            this.Size = new System.Drawing.Size(956, 463);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		public int length;

		private int[] devPresent = new int[4];

		private int devSelected;

		private string ConfigFile = "";

		private IContainer components;

		private TextBox textBox1;

		private ComboBox m_CaptureSetupFile;

		private TextBox textBox2;

		private Button m_btnBrowseCapture;

		private Button m_btnImportCapture;

		private Button m_btnSetup;

		private TextBox textBox3;

		private ComboBox m_jsonfile;

		private Button m_BrowseMmwave;

		private Button m_BtnImport;

		private Button m_BtnLoad;

		private Button m_BtnConfigureDevice;

		private RadioButton m_btnDevice0;

		private RadioButton m_btnDevice1;

		private RadioButton m_btnDevice2;

		private RadioButton m_btnDevice3;

		private Button m_BtnExport;

		private TextBox textBox4;

		private RadioButton m_btnSingleFrame;

		private RadioButton m_btnAdvFrame;

		private RadioButton m_btnContWave;

		private Panel panel1;

		private Panel panel2;
	}
}
