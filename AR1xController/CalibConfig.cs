using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class CalibConfig : UserControl
	{
		public CalibConfig()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_TimeUnitConfigParameters = this.m_GuiManager.TsParams.TimeUnitConfigParameters;
			this.m_RFInitCalibConfigParameters = this.m_GuiManager.TsParams.RFInitCalibConfigParameters;
			this.m_RunTimeCalibConfigParameters = this.m_GuiManager.TsParams.RunTimeCalibConfigParameters;
			this.m_cboTxPowerCalMode.SelectedIndex = 0;
		}

		public bool UpdateCalibConfig(RootObject jobject, int p1)
		{
			bool result;
			try
			{
				if (jobject.mmWaveDevices[p1].rfConfig.rlRfCalMonTimeUntConf_t.isConfigured == 0)
				{
					string msg = string.Format("Missing Calibration Monitoring Time Unit Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg);
				}
				else
				{
					this.m_nudTimeUnit.Value = jobject.mmWaveDevices[p1].rfConfig.rlRfCalMonTimeUntConf_t.calibMonTimeUnit;
					int count = GlobalRef.jobject.mmWaveDevices.Count;
					this.m_nudNumCascadeDev.Value = count;
					this.m_nudDeviceId.Value = jobject.mmWaveDevices[p1].mmWaveDeviceId;
				}
				if (jobject.mmWaveDevices[p1].rfConfig.rlRfInitCalConf_t.isConfigured == 0)
				{
					string msg2 = string.Format("Missing RF Init Calibration Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg2);
				}
				else
				{
					int num = Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlRfInitCalConf_t.calibEnMask, 16);
					this.m_chkLODist.Checked = ((num & 16) >> 4 == 1);
					this.f000131.Checked = ((num & 32) >> 5 == 1);
					this.m_chkHPFCutoff.Checked = ((num & 64) >> 6 == 1);
					this.m_chkLPFCutoff.Checked = ((num & 128) >> 7 == 1);
					this.m_chkPeakDetector.Checked = ((num & 256) >> 8 == 1);
					this.m_chkTxPower.Checked = ((num & 512) >> 9 == 1);
					this.m_chkRxGain.Checked = ((num & 1024) >> 10 == 1);
					this.m_chkTxPhase.Checked = ((num & 256) >> 11 == 1);
					this.f000130.Checked = ((num & 4096) >> 12 == 1);
				}
				if (jobject.mmWaveDevices[p1].rfConfig.rlRunTimeCalibConf_t.isConfigured == 0)
				{
					string msg3 = string.Format("Missing Run Time Calibration Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg3);
				}
				else
				{
					int num2 = Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlRunTimeCalibConf_t.oneTimeCalibEnMask, 16);
					int num3 = Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlRunTimeCalibConf_t.periodicCalibEnMask, 16);
					this.m_chkOneTimeCalibLODist.Checked = ((num2 & 16) >> 4 == 1);
					this.m_chkOneTimeCalibTxPower.Checked = ((num2 & 512) >> 9 == 1);
					this.m_chkOneTimeCalibRxGain.Checked = ((num2 & 1024) >> 10 == 1);
					this.m_chkOneTimeCalibPDCal.Checked = ((num2 & 256) >> 8 == 1);
					this.m_chkPeriodicCalibLODist.Checked = ((num3 & 16) >> 4 == 1);
					this.m_chkPeriodicCalibTxPower.Checked = ((num3 & 512) >> 9 == 1);
					this.m_chkPeriodicCalibRxGain.Checked = ((num3 & 1024) >> 10 == 1);
					this.m_chkPeriodicCalibPDCal.Checked = ((num3 & 256) >> 8 == 1);
					this.m_nudCalibPeriodicity.Value = jobject.mmWaveDevices[p1].rfConfig.rlRunTimeCalibConf_t.calibPeriodicity;
					this.m_chkEnableCalReport.Checked = (jobject.mmWaveDevices[p1].rfConfig.rlRunTimeCalibConf_t.reportEn == 1);
					this.m_cboTxPowerCalMode.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlRunTimeCalibConf_t.txPowerCalMode;
				}
				result = true;
			}
			catch
			{
				string msg4 = string.Format("Calib Config Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg4);
				result = false;
			}
			return result;
		}

		private int iSetTimeUnitConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetTimeUnitConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetTimeUnitConfig()
		{
			this.iSetTimeUnitConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetTimeUnitConfigAsync()
		{
			new del_v_v(this.iSetTimeUnitConfig).BeginInvoke(null, null);
		}

		private void m_btnTimeUnitSet_Click(object sender, EventArgs p1)
		{
			this.iSetTimeUnitConfigAsync();
		}

		public bool UpdateTimeUnitConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateTimeUnitConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_TimeUnitConfigParameters.CalinMonTimeUnit = (ushort)this.m_nudTimeUnit.Value;
				this.m_TimeUnitConfigParameters.NumOfCascadeDevices = (char)this.m_nudNumCascadeDev.Value;
				this.m_TimeUnitConfigParameters.DevId = (char)this.m_nudDeviceId.Value;
				int num = this.m_chkDisableLogging.Checked ? 1 : 0;
				string full_command = string.Format("ar1.DisableMonitoringLogging({0})", num);
				this.m_GuiManager.RecordLog(0, full_command);
				string full_command2 = string.Format("Status: Passed", new object[0]);
				this.m_GuiManager.RecordLog(0, full_command2);
				if (num == 1)
				{
					GlobalRef.g_DisableReportLogging = true;
				}
				else if (num == 0)
				{
					GlobalRef.g_DisableReportLogging = false;
				}
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateTimeUnitConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateTimeUnitConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudTimeUnit.Value = this.m_TimeUnitConfigParameters.CalinMonTimeUnit;
				this.m_nudNumCascadeDev.Value = this.m_TimeUnitConfigParameters.NumOfCascadeDevices;
				this.m_nudDeviceId.Value = this.m_TimeUnitConfigParameters.DevId;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetRFInitCalibConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetRFInitCalibConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFInitCalibConfig()
		{
			this.iSetRFInitCalibConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetRFInitCalibConfigAsync()
		{
			new del_v_v(this.iSetRFInitCalibConfig).BeginInvoke(null, null);
		}

		private void m_btnRFInitCalibSet_Click(object sender, EventArgs p1)
		{
			this.iSetRFInitCalibConfigAsync();
		}

		public bool UpdateRFInitCalibConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRFInitCalibConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RFInitCalibConfigParameters.LODist = (this.m_chkLODist.Checked ? 1U : 0U);
				this.m_RFInitCalibConfigParameters.RXADCDC = (this.f000131.Checked ? 1U : 0U);
				this.m_RFInitCalibConfigParameters.HPFCutoff = (this.m_chkHPFCutoff.Checked ? 1U : 0U);
				this.m_RFInitCalibConfigParameters.LPFCutoff = (this.m_chkLPFCutoff.Checked ? 1U : 0U);
				this.m_RFInitCalibConfigParameters.PeakDetector = (this.m_chkPeakDetector.Checked ? 1U : 0U);
				this.m_RFInitCalibConfigParameters.TXPower = (this.m_chkTxPower.Checked ? 1U : 0U);
				this.m_RFInitCalibConfigParameters.RXGain = (this.m_chkRxGain.Checked ? 1U : 0U);
				this.m_RFInitCalibConfigParameters.TXPhase = (this.m_chkTxPhase.Checked ? 1U : 0U);
				this.m_RFInitCalibConfigParameters.RXIQMM = (this.f000130.Checked ? 1U : 0U);
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRFInitCalibConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRFInitCalibConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_chkLODist.Checked = (this.m_RFInitCalibConfigParameters.LODist == 1U);
				this.f000131.Checked = (this.m_RFInitCalibConfigParameters.RXADCDC == 1U);
				this.m_chkHPFCutoff.Checked = (this.m_RFInitCalibConfigParameters.HPFCutoff == 1U);
				this.m_chkLPFCutoff.Checked = (this.m_RFInitCalibConfigParameters.LPFCutoff == 1U);
				this.m_chkPeakDetector.Checked = (this.m_RFInitCalibConfigParameters.PeakDetector == 1U);
				this.m_chkTxPower.Checked = (this.m_RFInitCalibConfigParameters.TXPower == 1U);
				this.m_chkRxGain.Checked = (this.m_RFInitCalibConfigParameters.RXGain == 1U);
				this.m_chkTxPhase.Checked = (this.m_RFInitCalibConfigParameters.TXPhase == 1U);
				this.f000130.Checked = (this.m_RFInitCalibConfigParameters.RXIQMM == 1U);
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetRunTimeCalibConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetRunTimeCalibConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRunTimeCalibConfig()
		{
			this.iSetRunTimeCalibConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetRunTimeCalibConfigAsync()
		{
			new del_v_v(this.iSetRunTimeCalibConfig).BeginInvoke(null, null);
		}

		private void m_btnRunTimeCalibCfgSet_Click(object sender, EventArgs p1)
		{
			this.iSetRunTimeCalibConfigAsync();
		}

		public bool UpdateRunTimeCalibConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRunTimeCalibConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RunTimeCalibConfigParameters.OneTimeLODist = (this.m_chkOneTimeCalibLODist.Checked ? 1U : 0U);
				this.m_RunTimeCalibConfigParameters.OneTimeTXPower = (this.m_chkOneTimeCalibTxPower.Checked ? 1U : 0U);
				this.m_RunTimeCalibConfigParameters.OneTimeRXGain = (this.m_chkOneTimeCalibRxGain.Checked ? 1U : 0U);
				this.m_RunTimeCalibConfigParameters.OneTimePDCal = (this.m_chkOneTimeCalibPDCal.Checked ? 1U : 0U);
				this.m_RunTimeCalibConfigParameters.PeriodiCalibLODist = (this.m_chkPeriodicCalibLODist.Checked ? 1U : 0U);
				this.m_RunTimeCalibConfigParameters.PeriodiCalibTXPower = (this.m_chkPeriodicCalibTxPower.Checked ? 1U : 0U);
				this.m_RunTimeCalibConfigParameters.PeriodiCalibRXGain = (this.m_chkPeriodicCalibRxGain.Checked ? 1U : 0U);
				this.m_RunTimeCalibConfigParameters.PeriodiCalibPDCal = (this.m_chkPeriodicCalibPDCal.Checked ? 1U : 0U);
				this.m_RunTimeCalibConfigParameters.CalibPeriodicity = (uint)this.m_nudCalibPeriodicity.Value;
				this.m_RunTimeCalibConfigParameters.EnableCalReport = (this.m_chkEnableCalReport.Checked ? '\u0001' : '\0');
				this.m_RunTimeCalibConfigParameters.TxPowerCalMode = (char)this.m_cboTxPowerCalMode.SelectedIndex;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRunTimeCalibConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRunTimeCalibConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_chkOneTimeCalibLODist.Checked = (this.m_RunTimeCalibConfigParameters.OneTimeLODist == 1U);
				this.m_chkOneTimeCalibTxPower.Checked = (this.m_RunTimeCalibConfigParameters.OneTimeTXPower == 1U);
				this.m_chkOneTimeCalibRxGain.Checked = (this.m_RunTimeCalibConfigParameters.OneTimeRXGain == 1U);
				this.m_chkOneTimeCalibPDCal.Checked = (this.m_RunTimeCalibConfigParameters.OneTimePDCal == 1U);
				this.m_chkPeriodicCalibLODist.Checked = (this.m_RunTimeCalibConfigParameters.PeriodiCalibLODist == 1U);
				this.m_chkPeriodicCalibTxPower.Checked = (this.m_RunTimeCalibConfigParameters.PeriodiCalibTXPower == 1U);
				this.m_chkPeriodicCalibRxGain.Checked = (this.m_RunTimeCalibConfigParameters.PeriodiCalibRXGain == 1U);
				this.m_chkPeriodicCalibPDCal.Checked = (this.m_RunTimeCalibConfigParameters.PeriodiCalibPDCal == 1U);
				this.m_nudCalibPeriodicity.Value = this.m_RunTimeCalibConfigParameters.CalibPeriodicity;
				this.m_chkEnableCalReport.Checked = (this.m_RunTimeCalibConfigParameters.EnableCalReport == '\u0001');
				this.m_cboTxPowerCalMode.SelectedIndex = (int)this.m_RunTimeCalibConfigParameters.TxPowerCalMode;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeRFInitializationCalibStatus(uint RadarDeviceId, uint CalibStatus, uint CalibUpdate, int Temperature, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				delegate0fc method = new delegate0fc(this.CascadeRFInitializationCalibStatus);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					CalibStatus,
					CalibUpdate,
					Temperature,
					TimeStamp
				});
			}
			else if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
			{
				if (RadarDeviceId == 1U)
				{
					if ((CalibStatus >> 1 & 1U) == 1U)
					{
						this.m_lblRFInitApllcalStatus.Text = "P";
						this.m_lblRFInitApllcalStatus.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRFInitApllcalStatus.Text = "F";
						this.m_lblRFInitApllcalStatus.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 1 & 1U) == 1U)
					{
						this.m_lblRFInitApllcalUpdate.Text = "Y";
						this.m_lblRFInitApllcalUpdate.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRFInitApllcalUpdate.Text = "N";
						this.m_lblRFInitApllcalUpdate.ForeColor = Color.Red;
					}
					string text = string.Format("APLL Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 1 & 1U,
						CalibUpdate >> 1 & 1U
					});
					if ((CalibStatus >> 2 & 1U) == 1U)
					{
						this.f000149.Text = "P";
						this.f000149.ForeColor = Color.Green;
					}
					else
					{
						this.f000149.Text = "F";
						this.f000149.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 2 & 1U) == 1U)
					{
						this.f000165.Text = "Y";
						this.f000165.ForeColor = Color.Green;
					}
					else
					{
						this.f000165.Text = "N";
						this.f000165.ForeColor = Color.Red;
					}
					string text2 = string.Format("SynthVCO1 Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 2 & 1U,
						CalibUpdate >> 2 & 1U
					});
					if ((CalibStatus >> 3 & 1U) == 1U)
					{
						this.f000148.Text = "P";
						this.f000148.ForeColor = Color.Green;
					}
					else
					{
						this.f000148.Text = "F";
						this.f000148.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 3 & 1U) == 1U)
					{
						this.f000164.Text = "Y";
						this.f000164.ForeColor = Color.Green;
					}
					else
					{
						this.f000164.Text = "N";
						this.f000164.ForeColor = Color.Red;
					}
					string text3 = string.Format("SynthVCO2 Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 3 & 1U,
						CalibUpdate >> 3 & 1U
					});
					if ((CalibStatus >> 4 & 1U) == 1U)
					{
						this.f000146.Text = "P";
						this.f000146.ForeColor = Color.Green;
					}
					else
					{
						this.f000146.Text = "F";
						this.f000146.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 4 & 1U) == 1U)
					{
						this.f000163.Text = "Y";
						this.f000163.ForeColor = Color.Green;
					}
					else
					{
						this.f000163.Text = "N";
						this.f000163.ForeColor = Color.Red;
					}
					string text4 = string.Format("LODist Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 4 & 1U,
						CalibUpdate >> 4 & 1U
					});
					if ((CalibStatus >> 5 & 1U) == 1U)
					{
						this.f000144.Text = "P";
						this.f000144.ForeColor = Color.Green;
					}
					else
					{
						this.f000144.Text = "F";
						this.f000144.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 5 & 1U) == 1U)
					{
						this.f000162.Text = "Y";
						this.f000162.ForeColor = Color.Green;
					}
					else
					{
						this.f000162.Text = "N";
						this.f000162.ForeColor = Color.Red;
					}
					string text5 = string.Format("RxADCDC Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 5 & 1U,
						CalibUpdate >> 5 & 1U
					});
					if ((CalibStatus >> 6 & 1U) == 1U)
					{
						this.f000147.Text = "P";
						this.f000147.ForeColor = Color.Green;
					}
					else
					{
						this.f000147.Text = "F";
						this.f000147.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 6 & 1U) == 1U)
					{
						this.f000161.Text = "Y";
						this.f000161.ForeColor = Color.Green;
					}
					else
					{
						this.f000161.Text = "N";
						this.f000161.ForeColor = Color.Red;
					}
					string text6 = string.Format("HPFcutoff Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 6 & 1U,
						CalibUpdate >> 6 & 1U
					});
					if ((CalibStatus >> 7 & 1U) == 1U)
					{
						this.f000145.Text = "P";
						this.f000145.ForeColor = Color.Green;
					}
					else
					{
						this.f000145.Text = "F";
						this.f000145.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 7 & 1U) == 1U)
					{
						this.f000160.Text = "Y";
						this.f000160.ForeColor = Color.Green;
					}
					else
					{
						this.f000160.Text = "N";
						this.f000160.ForeColor = Color.Red;
					}
					string text7 = string.Format("LPFcutoff Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 7 & 1U,
						CalibUpdate >> 7 & 1U
					});
					if ((CalibStatus >> 8 & 1U) == 1U)
					{
						this.m_lblPeakDetector.Text = "P";
						this.m_lblPeakDetector.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblPeakDetector.Text = "F";
						this.m_lblPeakDetector.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 8 & 1U) == 1U)
					{
						this.m_lblPeakDetectorUpdate.Text = "Y";
						this.m_lblPeakDetectorUpdate.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblPeakDetectorUpdate.Text = "N";
						this.m_lblPeakDetectorUpdate.ForeColor = Color.Red;
					}
					string text8 = string.Format("PeakDetector Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 8 & 1U,
						CalibUpdate >> 8 & 1U
					});
					if ((CalibStatus >> 9 & 1U) == 1U)
					{
						this.m_lblRFTxPower.Text = "P";
						this.m_lblRFTxPower.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRFTxPower.Text = "F";
						this.m_lblRFTxPower.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 9 & 1U) == 1U)
					{
						this.m_lblRFTxPowerUpdate.Text = "Y";
						this.m_lblRFTxPowerUpdate.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRFTxPowerUpdate.Text = "N";
						this.m_lblRFTxPowerUpdate.ForeColor = Color.Red;
					}
					string text9 = string.Format("TxPower Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 9 & 1U,
						CalibUpdate >> 9 & 1U
					});
					if ((CalibStatus >> 10 & 1U) == 1U)
					{
						this.m_lblRxGain.Text = "P";
						this.m_lblRxGain.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRxGain.Text = "F";
						this.m_lblRxGain.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 10 & 1U) == 1U)
					{
						this.m_lblRxGainUpdate.Text = "Y";
						this.m_lblRxGainUpdate.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRxGainUpdate.Text = "N";
						this.m_lblRxGainUpdate.ForeColor = Color.Red;
					}
					string text10 = string.Format("RxGain Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 10 & 1U,
						CalibUpdate >> 10 & 1U
					});
					if ((CalibStatus >> 11 & 1U) == 1U)
					{
						this.m_lblTxPhase.Text = "P";
						this.m_lblTxPhase.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblTxPhase.Text = "F";
						this.m_lblTxPhase.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 11 & 1U) == 1U)
					{
						this.m_lblTxPhaseUpdate.Text = "Y";
						this.m_lblTxPhaseUpdate.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblTxPhaseUpdate.Text = "N";
						this.m_lblRFInitApllcalUpdate.ForeColor = Color.Red;
					}
					string text11 = string.Format("TxPhase Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 11 & 1U,
						CalibUpdate >> 11 & 1U
					});
					if ((CalibStatus >> 12 & 1U) == 1U)
					{
						this.f000169.Text = "P";
						this.f000169.ForeColor = Color.Green;
					}
					else
					{
						this.f000169.Text = "F";
						this.f000169.ForeColor = Color.Red;
					}
					if ((CalibUpdate >> 12 & 1U) == 1U)
					{
						this.f00015f.Text = "Y";
						this.f00015f.ForeColor = Color.Green;
					}
					else
					{
						this.f00015f.Text = "N";
						this.f00015f.ForeColor = Color.Red;
					}
					string text12 = string.Format("RxIQMM Status, Update: {0}, {1}; ", new object[]
					{
						CalibStatus >> 12 & 1U,
						CalibUpdate >> 12 & 1U
					});
					this.m_lblTemperature.Text = Convert.ToString(Temperature);
					this.m_lblTimeStamp.Text = Convert.ToString(TimeStamp);
					string text13 = string.Format("Time stamp, Temperture: {0},{1}; ", new object[]
					{
						Convert.ToString(TimeStamp),
						Convert.ToString(Temperature)
					});
					string full_command = string.Concat(new string[]
					{
						text13,
						text,
						text2,
						text3,
						text4,
						text5,
						text6,
						text7,
						text8,
						text9,
						text10,
						text11,
						text12
					});
					GlobalRef.GuiManager.RecordLog(0, full_command);
				}
			}
			else
			{
				if ((CalibStatus >> 1 & 1U) == 1U)
				{
					this.m_lblRFInitApllcalStatus.Text = "P";
					this.m_lblRFInitApllcalStatus.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRFInitApllcalStatus.Text = "F";
					this.m_lblRFInitApllcalStatus.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 1 & 1U) == 1U)
				{
					this.m_lblRFInitApllcalUpdate.Text = "Y";
					this.m_lblRFInitApllcalUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRFInitApllcalUpdate.Text = "N";
					this.m_lblRFInitApllcalUpdate.ForeColor = Color.Red;
				}
				string text14 = string.Format("APLL Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 1 & 1U,
					CalibUpdate >> 1 & 1U
				});
				if ((CalibStatus >> 2 & 1U) == 1U)
				{
					this.f000149.Text = "P";
					this.f000149.ForeColor = Color.Green;
				}
				else
				{
					this.f000149.Text = "F";
					this.f000149.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 2 & 1U) == 1U)
				{
					this.f000165.Text = "Y";
					this.f000165.ForeColor = Color.Green;
				}
				else
				{
					this.f000165.Text = "N";
					this.f000165.ForeColor = Color.Red;
				}
				string text15 = string.Format("SynthVCO1 Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 2 & 1U,
					CalibUpdate >> 2 & 1U
				});
				if ((CalibStatus >> 3 & 1U) == 1U)
				{
					this.f000148.Text = "P";
					this.f000148.ForeColor = Color.Green;
				}
				else
				{
					this.f000148.Text = "F";
					this.f000148.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 3 & 1U) == 1U)
				{
					this.f000164.Text = "Y";
					this.f000164.ForeColor = Color.Green;
				}
				else
				{
					this.f000164.Text = "N";
					this.f000164.ForeColor = Color.Red;
				}
				string text16 = string.Format("SynthVCO2 Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 3 & 1U,
					CalibUpdate >> 3 & 1U
				});
				if ((CalibStatus >> 4 & 1U) == 1U)
				{
					this.f000146.Text = "P";
					this.f000146.ForeColor = Color.Green;
				}
				else
				{
					this.f000146.Text = "F";
					this.f000146.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 4 & 1U) == 1U)
				{
					this.f000163.Text = "Y";
					this.f000163.ForeColor = Color.Green;
				}
				else
				{
					this.f000163.Text = "N";
					this.f000163.ForeColor = Color.Red;
				}
				string text17 = string.Format("LODist Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 4 & 1U,
					CalibUpdate >> 4 & 1U
				});
				if ((CalibStatus >> 5 & 1U) == 1U)
				{
					this.f000144.Text = "P";
					this.f000144.ForeColor = Color.Green;
				}
				else
				{
					this.f000144.Text = "F";
					this.f000144.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 5 & 1U) == 1U)
				{
					this.f000162.Text = "Y";
					this.f000162.ForeColor = Color.Green;
				}
				else
				{
					this.f000162.Text = "N";
					this.f000162.ForeColor = Color.Red;
				}
				string text18 = string.Format("RxADCDC Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 5 & 1U,
					CalibUpdate >> 5 & 1U
				});
				if ((CalibStatus >> 6 & 1U) == 1U)
				{
					this.f000147.Text = "P";
					this.f000147.ForeColor = Color.Green;
				}
				else
				{
					this.f000147.Text = "F";
					this.f000147.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 6 & 1U) == 1U)
				{
					this.f000161.Text = "Y";
					this.f000161.ForeColor = Color.Green;
				}
				else
				{
					this.f000161.Text = "N";
					this.f000161.ForeColor = Color.Red;
				}
				string text19 = string.Format("HPFcutoff Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 6 & 1U,
					CalibUpdate >> 6 & 1U
				});
				if ((CalibStatus >> 7 & 1U) == 1U)
				{
					this.f000145.Text = "P";
					this.f000145.ForeColor = Color.Green;
				}
				else
				{
					this.f000145.Text = "F";
					this.f000145.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 7 & 1U) == 1U)
				{
					this.f000160.Text = "Y";
					this.f000160.ForeColor = Color.Green;
				}
				else
				{
					this.f000160.Text = "N";
					this.f000160.ForeColor = Color.Red;
				}
				string text20 = string.Format("LPFcutoff Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 7 & 1U,
					CalibUpdate >> 7 & 1U
				});
				if ((CalibStatus >> 8 & 1U) == 1U)
				{
					this.m_lblPeakDetector.Text = "P";
					this.m_lblPeakDetector.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblPeakDetector.Text = "F";
					this.m_lblPeakDetector.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 8 & 1U) == 1U)
				{
					this.m_lblPeakDetectorUpdate.Text = "Y";
					this.m_lblPeakDetectorUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblPeakDetectorUpdate.Text = "N";
					this.m_lblPeakDetectorUpdate.ForeColor = Color.Red;
				}
				string text21 = string.Format("PeakDetector Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 8 & 1U,
					CalibUpdate >> 8 & 1U
				});
				if ((CalibStatus >> 9 & 1U) == 1U)
				{
					this.m_lblRFTxPower.Text = "P";
					this.m_lblRFTxPower.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRFTxPower.Text = "F";
					this.m_lblRFTxPower.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 9 & 1U) == 1U)
				{
					this.m_lblRFTxPowerUpdate.Text = "Y";
					this.m_lblRFTxPowerUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRFTxPowerUpdate.Text = "N";
					this.m_lblRFTxPowerUpdate.ForeColor = Color.Red;
				}
				string text22 = string.Format("TxPower Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 9 & 1U,
					CalibUpdate >> 9 & 1U
				});
				if ((CalibStatus >> 10 & 1U) == 1U)
				{
					this.m_lblRxGain.Text = "P";
					this.m_lblRxGain.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRxGain.Text = "F";
					this.m_lblRxGain.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 10 & 1U) == 1U)
				{
					this.m_lblRxGainUpdate.Text = "Y";
					this.m_lblRxGainUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRxGainUpdate.Text = "N";
					this.m_lblRxGainUpdate.ForeColor = Color.Red;
				}
				string text23 = string.Format("RxGain Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 10 & 1U,
					CalibUpdate >> 10 & 1U
				});
				if ((CalibStatus >> 11 & 1U) == 1U)
				{
					this.m_lblTxPhase.Text = "P";
					this.m_lblTxPhase.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblTxPhase.Text = "F";
					this.m_lblTxPhase.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 11 & 1U) == 1U)
				{
					this.m_lblTxPhaseUpdate.Text = "Y";
					this.m_lblTxPhaseUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblTxPhaseUpdate.Text = "N";
					this.m_lblRFInitApllcalUpdate.ForeColor = Color.Red;
				}
				string text24 = string.Format("TxPhase Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 11 & 1U,
					CalibUpdate >> 11 & 1U
				});
				if ((CalibStatus >> 12 & 1U) == 1U)
				{
					this.f000169.Text = "P";
					this.f000169.ForeColor = Color.Green;
				}
				else
				{
					this.f000169.Text = "F";
					this.f000169.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 12 & 1U) == 1U)
				{
					this.f00015f.Text = "Y";
					this.f00015f.ForeColor = Color.Green;
				}
				else
				{
					this.f00015f.Text = "N";
					this.f00015f.ForeColor = Color.Red;
				}
				string text25 = string.Format("RxIQMM Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 12 & 1U,
					CalibUpdate >> 12 & 1U
				});
				this.m_lblTemperature.Text = Convert.ToString(Temperature);
				this.m_lblTimeStamp.Text = Convert.ToString(TimeStamp);
				string text26 = string.Format("Time stamp, Temperture: {0},{1}; ", new object[]
				{
					Convert.ToString(TimeStamp),
					Convert.ToString(Temperature)
				});
				string text27 = string.Format("[DeviceId-{0}] ", RadarDeviceId);
				string full_command2 = string.Concat(new string[]
				{
					text27,
					text26,
					text14,
					text15,
					text16,
					text17,
					text18,
					text19,
					text20,
					text21,
					text22,
					text23,
					text24,
					text25
				});
				GlobalRef.GuiManager.RecordLog(0, full_command2);
			}
			return true;
		}

		public bool RFInitializationCalibStatusToCascadeDevices(uint RadarDeviceId, uint CalibStatus, uint CalibUpdate, int Temperature, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				delegate0fc method = new delegate0fc(this.RFInitializationCalibStatusToCascadeDevices);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					CalibStatus,
					CalibUpdate,
					Temperature,
					TimeStamp
				});
			}
			else if (RadarDeviceId == 0U)
			{
				if ((CalibStatus >> 1 & 1U) == 1U)
				{
					this.m_lblRFInitApllcalStatus.Text = "P";
					this.m_lblRFInitApllcalStatus.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRFInitApllcalStatus.Text = "F";
					this.m_lblRFInitApllcalStatus.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 1 & 1U) == 1U)
				{
					this.m_lblRFInitApllcalUpdate.Text = "Y";
					this.m_lblRFInitApllcalUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRFInitApllcalUpdate.Text = "N";
					this.m_lblRFInitApllcalUpdate.ForeColor = Color.Red;
				}
				string text = string.Format("APLL Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 1 & 1U,
					CalibUpdate >> 1 & 1U
				});
				if ((CalibStatus >> 2 & 1U) == 1U)
				{
					this.f000149.Text = "P";
					this.f000149.ForeColor = Color.Green;
				}
				else
				{
					this.f000149.Text = "F";
					this.f000149.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 2 & 1U) == 1U)
				{
					this.f000165.Text = "Y";
					this.f000165.ForeColor = Color.Green;
				}
				else
				{
					this.f000165.Text = "N";
					this.f000165.ForeColor = Color.Red;
				}
				string text2 = string.Format("SynthVCO1 Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 2 & 1U,
					CalibUpdate >> 2 & 1U
				});
				if ((CalibStatus >> 3 & 1U) == 1U)
				{
					this.f000148.Text = "P";
					this.f000148.ForeColor = Color.Green;
				}
				else
				{
					this.f000148.Text = "F";
					this.f000148.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 3 & 1U) == 1U)
				{
					this.f000164.Text = "Y";
					this.f000164.ForeColor = Color.Green;
				}
				else
				{
					this.f000164.Text = "N";
					this.f000164.ForeColor = Color.Red;
				}
				string text3 = string.Format("SynthVCO2 Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 3 & 1U,
					CalibUpdate >> 3 & 1U
				});
				if ((CalibStatus >> 4 & 1U) == 1U)
				{
					this.f000146.Text = "P";
					this.f000146.ForeColor = Color.Green;
				}
				else
				{
					this.f000146.Text = "F";
					this.f000146.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 4 & 1U) == 1U)
				{
					this.f000163.Text = "Y";
					this.f000163.ForeColor = Color.Green;
				}
				else
				{
					this.f000163.Text = "N";
					this.f000163.ForeColor = Color.Red;
				}
				string text4 = string.Format("LODist Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 4 & 1U,
					CalibUpdate >> 4 & 1U
				});
				if ((CalibStatus >> 5 & 1U) == 1U)
				{
					this.f000144.Text = "P";
					this.f000144.ForeColor = Color.Green;
				}
				else
				{
					this.f000144.Text = "F";
					this.f000144.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 5 & 1U) == 1U)
				{
					this.f000162.Text = "Y";
					this.f000162.ForeColor = Color.Green;
				}
				else
				{
					this.f000162.Text = "N";
					this.f000162.ForeColor = Color.Red;
				}
				string text5 = string.Format("RxADCDC Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 5 & 1U,
					CalibUpdate >> 5 & 1U
				});
				if ((CalibStatus >> 6 & 1U) == 1U)
				{
					this.f000147.Text = "P";
					this.f000147.ForeColor = Color.Green;
				}
				else
				{
					this.f000147.Text = "F";
					this.f000147.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 6 & 1U) == 1U)
				{
					this.f000161.Text = "Y";
					this.f000161.ForeColor = Color.Green;
				}
				else
				{
					this.f000161.Text = "N";
					this.f000161.ForeColor = Color.Red;
				}
				string text6 = string.Format("HPFcutoff Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 6 & 1U,
					CalibUpdate >> 6 & 1U
				});
				if ((CalibStatus >> 7 & 1U) == 1U)
				{
					this.f000145.Text = "P";
					this.f000145.ForeColor = Color.Green;
				}
				else
				{
					this.f000145.Text = "F";
					this.f000145.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 7 & 1U) == 1U)
				{
					this.f000160.Text = "Y";
					this.f000160.ForeColor = Color.Green;
				}
				else
				{
					this.f000160.Text = "N";
					this.f000160.ForeColor = Color.Red;
				}
				string text7 = string.Format("LPFcutoff Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 7 & 1U,
					CalibUpdate >> 7 & 1U
				});
				if ((CalibStatus >> 8 & 1U) == 1U)
				{
					this.m_lblPeakDetector.Text = "P";
					this.m_lblPeakDetector.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblPeakDetector.Text = "F";
					this.m_lblPeakDetector.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 8 & 1U) == 1U)
				{
					this.m_lblPeakDetectorUpdate.Text = "Y";
					this.m_lblPeakDetectorUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblPeakDetectorUpdate.Text = "N";
					this.m_lblPeakDetectorUpdate.ForeColor = Color.Red;
				}
				string text8 = string.Format("PeakDetector Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 8 & 1U,
					CalibUpdate >> 8 & 1U
				});
				if ((CalibStatus >> 9 & 1U) == 1U)
				{
					this.m_lblRFTxPower.Text = "P";
					this.m_lblRFTxPower.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRFTxPower.Text = "F";
					this.m_lblRFTxPower.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 9 & 1U) == 1U)
				{
					this.m_lblRFTxPowerUpdate.Text = "Y";
					this.m_lblRFTxPowerUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRFTxPowerUpdate.Text = "N";
					this.m_lblRFTxPowerUpdate.ForeColor = Color.Red;
				}
				string text9 = string.Format("TxPower Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 9 & 1U,
					CalibUpdate >> 9 & 1U
				});
				if ((CalibStatus >> 10 & 1U) == 1U)
				{
					this.m_lblRxGain.Text = "P";
					this.m_lblRxGain.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRxGain.Text = "F";
					this.m_lblRxGain.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 10 & 1U) == 1U)
				{
					this.m_lblRxGainUpdate.Text = "Y";
					this.m_lblRxGainUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRxGainUpdate.Text = "N";
					this.m_lblRxGainUpdate.ForeColor = Color.Red;
				}
				string text10 = string.Format("RxGain Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 10 & 1U,
					CalibUpdate >> 10 & 1U
				});
				if ((CalibStatus >> 11 & 1U) == 1U)
				{
					this.m_lblTxPhase.Text = "P";
					this.m_lblTxPhase.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblTxPhase.Text = "F";
					this.m_lblTxPhase.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 11 & 1U) == 1U)
				{
					this.m_lblTxPhaseUpdate.Text = "Y";
					this.m_lblTxPhaseUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblTxPhaseUpdate.Text = "N";
					this.m_lblRFInitApllcalUpdate.ForeColor = Color.Red;
				}
				string text11 = string.Format("TxPhase Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 11 & 1U,
					CalibUpdate >> 11 & 1U
				});
				if ((CalibStatus >> 12 & 1U) == 1U)
				{
					this.f000169.Text = "P";
					this.f000169.ForeColor = Color.Green;
				}
				else
				{
					this.f000169.Text = "F";
					this.f000169.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 12 & 1U) == 1U)
				{
					this.f00015f.Text = "Y";
					this.f00015f.ForeColor = Color.Green;
				}
				else
				{
					this.f00015f.Text = "N";
					this.f00015f.ForeColor = Color.Red;
				}
				string text12 = string.Format("RxIQMM Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 12 & 1U,
					CalibUpdate >> 12 & 1U
				});
				this.m_lblTemperature.Text = Convert.ToString(Temperature);
				this.m_lblTimeStamp.Text = Convert.ToString(TimeStamp);
				string text13 = string.Format("Time stamp, Temperture: {0},{1}; ", new object[]
				{
					Convert.ToString(TimeStamp),
					Convert.ToString(Temperature)
				});
				string full_command = string.Concat(new string[]
				{
					text13,
					text,
					text2,
					text3,
					text4,
					text5,
					text6,
					text7,
					text8,
					text9,
					text10,
					text11,
					text12
				});
				GlobalRef.GuiManager.RecordLog(0, full_command);
			}
			else if (RadarDeviceId == 1U)
			{
				if ((CalibStatus >> 1 & 1U) == 1U)
				{
					this.m_lblRadarDevice2RFInitApllcalStatus.Text = "P";
					this.m_lblRadarDevice2RFInitApllcalStatus.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice2RFInitApllcalStatus.Text = "F";
					this.m_lblRadarDevice2RFInitApllcalStatus.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 1 & 1U) == 1U)
				{
					this.m_lblRadarDevice2RFInitApllcalUpdate.Text = "Y";
					this.m_lblRadarDevice2RFInitApllcalUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice2RFInitApllcalUpdate.Text = "N";
					this.m_lblRadarDevice2RFInitApllcalUpdate.ForeColor = Color.Red;
				}
				string text14 = string.Format("APLL Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 1 & 1U,
					CalibUpdate >> 1 & 1U
				});
				if ((CalibStatus >> 2 & 1U) == 1U)
				{
					this.f000143.Text = "P";
					this.f000143.ForeColor = Color.Green;
				}
				else
				{
					this.f000143.Text = "F";
					this.f000143.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 2 & 1U) == 1U)
				{
					this.f00015e.Text = "Y";
					this.f00015e.ForeColor = Color.Green;
				}
				else
				{
					this.f00015e.Text = "N";
					this.f00015e.ForeColor = Color.Red;
				}
				string text15 = string.Format("SynthVCO1 Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 2 & 1U,
					CalibUpdate >> 2 & 1U
				});
				if ((CalibStatus >> 3 & 1U) == 1U)
				{
					this.f000142.Text = "P";
					this.f000142.ForeColor = Color.Green;
				}
				else
				{
					this.f000142.Text = "F";
					this.f000142.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 3 & 1U) == 1U)
				{
					this.f00015d.Text = "Y";
					this.f00015d.ForeColor = Color.Green;
				}
				else
				{
					this.f00015d.Text = "N";
					this.f00015d.ForeColor = Color.Red;
				}
				string text16 = string.Format("SynthVCO2 Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 3 & 1U,
					CalibUpdate >> 3 & 1U
				});
				if ((CalibStatus >> 4 & 1U) == 1U)
				{
					this.f000140.Text = "P";
					this.f000140.ForeColor = Color.Green;
				}
				else
				{
					this.f000140.Text = "F";
					this.f000140.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 4 & 1U) == 1U)
				{
					this.m_lblRadarDevice2RFInitLODistUpdate.Text = "Y";
					this.m_lblRadarDevice2RFInitLODistUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice2RFInitLODistUpdate.Text = "N";
					this.m_lblRadarDevice2RFInitLODistUpdate.ForeColor = Color.Red;
				}
				string text17 = string.Format("LODist Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 4 & 1U,
					CalibUpdate >> 4 & 1U
				});
				if ((CalibStatus >> 5 & 1U) == 1U)
				{
					this.f00013e.Text = "P";
					this.f00013e.ForeColor = Color.Green;
				}
				else
				{
					this.f00013e.Text = "F";
					this.f00013e.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 5 & 1U) == 1U)
				{
					this.f00015c.Text = "Y";
					this.f00015c.ForeColor = Color.Green;
				}
				else
				{
					this.f00015c.Text = "N";
					this.f00015c.ForeColor = Color.Red;
				}
				string text18 = string.Format("RxADCDC Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 5 & 1U,
					CalibUpdate >> 5 & 1U
				});
				if ((CalibStatus >> 6 & 1U) == 1U)
				{
					this.f000141.Text = "P";
					this.f000141.ForeColor = Color.Green;
				}
				else
				{
					this.f000141.Text = "F";
					this.f000141.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 6 & 1U) == 1U)
				{
					this.f00015b.Text = "Y";
					this.f00015b.ForeColor = Color.Green;
				}
				else
				{
					this.f00015b.Text = "N";
					this.f00015b.ForeColor = Color.Red;
				}
				string text19 = string.Format("HPFcutoff Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 6 & 1U,
					CalibUpdate >> 6 & 1U
				});
				if ((CalibStatus >> 7 & 1U) == 1U)
				{
					this.f00013f.Text = "P";
					this.f00013f.ForeColor = Color.Green;
				}
				else
				{
					this.f00013f.Text = "F";
					this.f00013f.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 7 & 1U) == 1U)
				{
					this.f00015a.Text = "Y";
					this.f00015a.ForeColor = Color.Green;
				}
				else
				{
					this.f00015a.Text = "N";
					this.f00015a.ForeColor = Color.Red;
				}
				string text20 = string.Format("LPFcutoff Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 7 & 1U,
					CalibUpdate >> 7 & 1U
				});
				if ((CalibStatus >> 8 & 1U) == 1U)
				{
					this.m_lblRadarDevice2PeakDetector.Text = "P";
					this.m_lblRadarDevice2PeakDetector.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice2PeakDetector.Text = "F";
					this.m_lblRadarDevice2PeakDetector.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 8 & 1U) == 1U)
				{
					this.m_lblRadarDevice2PeakDetectorUpdate.Text = "Y";
					this.m_lblRadarDevice2PeakDetectorUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice2PeakDetectorUpdate.Text = "N";
					this.m_lblRadarDevice2PeakDetectorUpdate.ForeColor = Color.Red;
				}
				string text21 = string.Format("PeakDetector Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 8 & 1U,
					CalibUpdate >> 8 & 1U
				});
				if ((CalibStatus >> 9 & 1U) == 1U)
				{
					this.m_lblRadarDevice2RFTxPower.Text = "P";
					this.m_lblRadarDevice2RFTxPower.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice2RFTxPower.Text = "F";
					this.m_lblRadarDevice2RFTxPower.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 9 & 1U) == 1U)
				{
					this.m_lblRadarDevice2RFTxPowerUpdate.Text = "Y";
					this.m_lblRadarDevice2RFTxPowerUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice2RFTxPowerUpdate.Text = "N";
					this.m_lblRadarDevice2RFTxPowerUpdate.ForeColor = Color.Red;
				}
				string text22 = string.Format("TxPower Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 9 & 1U,
					CalibUpdate >> 9 & 1U
				});
				if ((CalibStatus >> 10 & 1U) == 1U)
				{
					this.m_lblRadarDevice2RxGain.Text = "P";
					this.m_lblRadarDevice2RxGain.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice2RxGain.Text = "F";
					this.m_lblRadarDevice2RxGain.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 10 & 1U) == 1U)
				{
					this.m_lblRadarDevice2RxGainUpdate.Text = "Y";
					this.m_lblRadarDevice2RxGainUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice2RxGainUpdate.Text = "N";
					this.m_lblRadarDevice2RxGainUpdate.ForeColor = Color.Red;
				}
				string text23 = string.Format("RxGain Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 10 & 1U,
					CalibUpdate >> 10 & 1U
				});
				if ((CalibStatus >> 11 & 1U) == 1U)
				{
					this.m_lblRadarDevice2TxPhase.Text = "P";
					this.m_lblRadarDevice2TxPhase.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice2TxPhase.Text = "F";
					this.m_lblRadarDevice2TxPhase.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 11 & 1U) == 1U)
				{
					this.m_lblRadarDevice2TxPhaseUpdate.Text = "Y";
					this.m_lblRadarDevice2TxPhaseUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice2TxPhaseUpdate.Text = "N";
					this.m_lblRadarDevice2TxPhaseUpdate.ForeColor = Color.Red;
				}
				string text24 = string.Format("TxPhase Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 11 & 1U,
					CalibUpdate >> 11 & 1U
				});
				if ((CalibStatus >> 12 & 1U) == 1U)
				{
					this.f000168.Text = "P";
					this.f000168.ForeColor = Color.Green;
				}
				else
				{
					this.f000168.Text = "F";
					this.f000168.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 12 & 1U) == 1U)
				{
					this.f000159.Text = "Y";
					this.f000159.ForeColor = Color.Green;
				}
				else
				{
					this.f000159.Text = "N";
					this.f000159.ForeColor = Color.Red;
				}
				string text25 = string.Format("RxIQMM Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 12 & 1U,
					CalibUpdate >> 12 & 1U
				});
				this.m_lblRadarDevice2Temperature.Text = Convert.ToString(Temperature);
				this.m_lblRadarDevice2TimeStamp.Text = Convert.ToString(TimeStamp);
				string text26 = string.Format("Time stamp, Temperture: {0},{1}; ", new object[]
				{
					Convert.ToString(TimeStamp),
					Convert.ToString(Temperature)
				});
				string full_command2 = string.Concat(new string[]
				{
					text26,
					text14,
					text15,
					text16,
					text17,
					text18,
					text19,
					text20,
					text21,
					text22,
					text23,
					text24,
					text25
				});
				GlobalRef.GuiManager.RecordLog(0, full_command2);
			}
			else if (RadarDeviceId == 2U)
			{
				if ((CalibStatus >> 1 & 1U) == 1U)
				{
					this.m_lblRadarDevice3RFInitApllcalStatus.Text = "P";
					this.m_lblRadarDevice3RFInitApllcalStatus.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice3RFInitApllcalStatus.Text = "F";
					this.m_lblRadarDevice3RFInitApllcalStatus.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 1 & 1U) == 1U)
				{
					this.m_lblRadarDevice3RFInitApllcalUpdate.Text = "Y";
					this.m_lblRadarDevice3RFInitApllcalUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice3RFInitApllcalUpdate.Text = "N";
					this.m_lblRadarDevice3RFInitApllcalUpdate.ForeColor = Color.Red;
				}
				string text27 = string.Format("APLL Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 1 & 1U,
					CalibUpdate >> 1 & 1U
				});
				if ((CalibStatus >> 2 & 1U) == 1U)
				{
					this.f00013d.Text = "P";
					this.f00013d.ForeColor = Color.Green;
				}
				else
				{
					this.f00013d.Text = "F";
					this.f00013d.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 2 & 1U) == 1U)
				{
					this.f000158.Text = "Y";
					this.f000158.ForeColor = Color.Green;
				}
				else
				{
					this.f000158.Text = "N";
					this.f000158.ForeColor = Color.Red;
				}
				string text28 = string.Format("SynthVCO1 Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 2 & 1U,
					CalibUpdate >> 2 & 1U
				});
				if ((CalibStatus >> 3 & 1U) == 1U)
				{
					this.f00013c.Text = "P";
					this.f00013c.ForeColor = Color.Green;
				}
				else
				{
					this.f00013c.Text = "F";
					this.f00013c.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 3 & 1U) == 1U)
				{
					this.f000157.Text = "Y";
					this.f000157.ForeColor = Color.Green;
				}
				else
				{
					this.f000157.Text = "N";
					this.f000157.ForeColor = Color.Red;
				}
				string text29 = string.Format("SynthVCO2 Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 3 & 1U,
					CalibUpdate >> 3 & 1U
				});
				if ((CalibStatus >> 4 & 1U) == 1U)
				{
					this.f00013a.Text = "P";
					this.f00013a.ForeColor = Color.Green;
				}
				else
				{
					this.f00013a.Text = "F";
					this.f00013a.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 4 & 1U) == 1U)
				{
					this.m_lblRadarDevice3RFInitLODistUpdate.Text = "Y";
					this.m_lblRadarDevice3RFInitLODistUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice3RFInitLODistUpdate.Text = "N";
					this.m_lblRadarDevice3RFInitLODistUpdate.ForeColor = Color.Red;
				}
				string text30 = string.Format("LODist Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 4 & 1U,
					CalibUpdate >> 4 & 1U
				});
				if ((CalibStatus >> 5 & 1U) == 1U)
				{
					this.f000138.Text = "P";
					this.f000138.ForeColor = Color.Green;
				}
				else
				{
					this.f000138.Text = "F";
					this.f000138.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 5 & 1U) == 1U)
				{
					this.f000156.Text = "Y";
					this.f000156.ForeColor = Color.Green;
				}
				else
				{
					this.f000156.Text = "N";
					this.f000156.ForeColor = Color.Red;
				}
				string text31 = string.Format("RxADCDC Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 5 & 1U,
					CalibUpdate >> 5 & 1U
				});
				if ((CalibStatus >> 6 & 1U) == 1U)
				{
					this.f00013b.Text = "P";
					this.f00013b.ForeColor = Color.Green;
				}
				else
				{
					this.f00013b.Text = "F";
					this.f00013b.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 6 & 1U) == 1U)
				{
					this.f000155.Text = "Y";
					this.f000155.ForeColor = Color.Green;
				}
				else
				{
					this.f000155.Text = "N";
					this.f000155.ForeColor = Color.Red;
				}
				string text32 = string.Format("HPFcutoff Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 6 & 1U,
					CalibUpdate >> 6 & 1U
				});
				if ((CalibStatus >> 7 & 1U) == 1U)
				{
					this.f000139.Text = "P";
					this.f000139.ForeColor = Color.Green;
				}
				else
				{
					this.f000139.Text = "F";
					this.f000139.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 7 & 1U) == 1U)
				{
					this.f000154.Text = "Y";
					this.f000154.ForeColor = Color.Green;
				}
				else
				{
					this.f000154.Text = "N";
					this.f000154.ForeColor = Color.Red;
				}
				string text33 = string.Format("LPFcutoff Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 7 & 1U,
					CalibUpdate >> 7 & 1U
				});
				if ((CalibStatus >> 8 & 1U) == 1U)
				{
					this.m_lblRadarDevice3PeakDetector.Text = "P";
					this.m_lblRadarDevice3PeakDetector.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice3PeakDetector.Text = "F";
					this.m_lblRadarDevice3PeakDetector.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 8 & 1U) == 1U)
				{
					this.m_lblRadarDevice3PeakDetectorUpdate.Text = "Y";
					this.m_lblRadarDevice3PeakDetectorUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice3PeakDetectorUpdate.Text = "N";
					this.m_lblRadarDevice3PeakDetectorUpdate.ForeColor = Color.Red;
				}
				string text34 = string.Format("PeakDetector Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 8 & 1U,
					CalibUpdate >> 8 & 1U
				});
				if ((CalibStatus >> 9 & 1U) == 1U)
				{
					this.m_lblRadarDevice3RFTxPower.Text = "P";
					this.m_lblRadarDevice3RFTxPower.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice3RFTxPower.Text = "F";
					this.m_lblRadarDevice3RFTxPower.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 9 & 1U) == 1U)
				{
					this.m_lblRadarDevice3RFTxPowerUpdate.Text = "Y";
					this.m_lblRadarDevice3RFTxPowerUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice3RFTxPowerUpdate.Text = "N";
					this.m_lblRadarDevice3RFTxPowerUpdate.ForeColor = Color.Red;
				}
				string text35 = string.Format("TxPower Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 9 & 1U,
					CalibUpdate >> 9 & 1U
				});
				if ((CalibStatus >> 10 & 1U) == 1U)
				{
					this.m_lblRadarDevice3RxGain.Text = "P";
					this.m_lblRadarDevice3RxGain.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice3RxGain.Text = "F";
					this.m_lblRadarDevice3RxGain.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 10 & 1U) == 1U)
				{
					this.m_lblRadarDevice3RxGainUpdate.Text = "Y";
					this.m_lblRadarDevice3RxGainUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice3RxGainUpdate.Text = "N";
					this.m_lblRadarDevice3RxGainUpdate.ForeColor = Color.Red;
				}
				string text36 = string.Format("RxGain Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 10 & 1U,
					CalibUpdate >> 10 & 1U
				});
				if ((CalibStatus >> 11 & 1U) == 1U)
				{
					this.m_lblRadarDevice3TxPhase.Text = "P";
					this.m_lblRadarDevice3TxPhase.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice3TxPhase.Text = "F";
					this.m_lblRadarDevice3TxPhase.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 11 & 1U) == 1U)
				{
					this.m_lblRadarDevice3TxPhaseUpdate.Text = "Y";
					this.m_lblRadarDevice3TxPhaseUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice3TxPhaseUpdate.Text = "N";
					this.m_lblRadarDevice3TxPhaseUpdate.ForeColor = Color.Red;
				}
				string text37 = string.Format("TxPhase Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 11 & 1U,
					CalibUpdate >> 11 & 1U
				});
				if ((CalibStatus >> 12 & 1U) == 1U)
				{
					this.f000167.Text = "P";
					this.f000167.ForeColor = Color.Green;
				}
				else
				{
					this.f000167.Text = "F";
					this.f000167.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 12 & 1U) == 1U)
				{
					this.f000153.Text = "Y";
					this.f000153.ForeColor = Color.Green;
				}
				else
				{
					this.f000153.Text = "N";
					this.f000153.ForeColor = Color.Red;
				}
				string text38 = string.Format("RxIQMM Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 12 & 1U,
					CalibUpdate >> 12 & 1U
				});
				this.m_lblRadarDevice3Temperature.Text = Convert.ToString(Temperature);
				this.m_lblRadarDevice3TimeStamp.Text = Convert.ToString(TimeStamp);
				string text39 = string.Format("Time stamp, Temperture: {0},{1}; ", new object[]
				{
					Convert.ToString(TimeStamp),
					Convert.ToString(Temperature)
				});
				string full_command3 = string.Concat(new string[]
				{
					text39,
					text27,
					text28,
					text29,
					text30,
					text31,
					text32,
					text33,
					text34,
					text35,
					text36,
					text37,
					text38
				});
				GlobalRef.GuiManager.RecordLog(0, full_command3);
			}
			else if (RadarDeviceId == 3U)
			{
				if ((CalibStatus >> 1 & 1U) == 1U)
				{
					this.m_lblRadarDevice4RFInitApllcalStatus.Text = "P";
					this.m_lblRadarDevice4RFInitApllcalStatus.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice4RFInitApllcalStatus.Text = "F";
					this.m_lblRadarDevice4RFInitApllcalStatus.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 1 & 1U) == 1U)
				{
					this.m_lblRadarDevice4RFInitApllcalUpdate.Text = "Y";
					this.m_lblRadarDevice4RFInitApllcalUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice4RFInitApllcalUpdate.Text = "N";
					this.m_lblRadarDevice4RFInitApllcalUpdate.ForeColor = Color.Red;
				}
				string text40 = string.Format("APLL Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 1 & 1U,
					CalibUpdate >> 1 & 1U
				});
				if ((CalibStatus >> 2 & 1U) == 1U)
				{
					this.f000137.Text = "P";
					this.f000137.ForeColor = Color.Green;
				}
				else
				{
					this.f000137.Text = "F";
					this.f000137.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 2 & 1U) == 1U)
				{
					this.f000152.Text = "Y";
					this.f000152.ForeColor = Color.Green;
				}
				else
				{
					this.f000152.Text = "N";
					this.f000152.ForeColor = Color.Red;
				}
				string text41 = string.Format("SynthVCO1 Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 2 & 1U,
					CalibUpdate >> 2 & 1U
				});
				if ((CalibStatus >> 3 & 1U) == 1U)
				{
					this.f000136.Text = "P";
					this.f000136.ForeColor = Color.Green;
				}
				else
				{
					this.f000136.Text = "F";
					this.f000136.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 3 & 1U) == 1U)
				{
					this.f000151.Text = "Y";
					this.f000151.ForeColor = Color.Green;
				}
				else
				{
					this.f000151.Text = "N";
					this.f000151.ForeColor = Color.Red;
				}
				string text42 = string.Format("SynthVCO2 Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 3 & 1U,
					CalibUpdate >> 3 & 1U
				});
				if ((CalibStatus >> 4 & 1U) == 1U)
				{
					this.f000134.Text = "P";
					this.f000134.ForeColor = Color.Green;
				}
				else
				{
					this.f000134.Text = "F";
					this.f000134.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 4 & 1U) == 1U)
				{
					this.m_lblRadarDevice4RFInitLODistUpdate.Text = "Y";
					this.m_lblRadarDevice4RFInitLODistUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice4RFInitLODistUpdate.Text = "N";
					this.m_lblRadarDevice4RFInitLODistUpdate.ForeColor = Color.Red;
				}
				string text43 = string.Format("LODist Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 4 & 1U,
					CalibUpdate >> 4 & 1U
				});
				if ((CalibStatus >> 5 & 1U) == 1U)
				{
					this.f000132.Text = "P";
					this.f000132.ForeColor = Color.Green;
				}
				else
				{
					this.f000132.Text = "F";
					this.f000132.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 5 & 1U) == 1U)
				{
					this.f000150.Text = "Y";
					this.f000150.ForeColor = Color.Green;
				}
				else
				{
					this.f000150.Text = "N";
					this.f000150.ForeColor = Color.Red;
				}
				string text44 = string.Format("RxADCDC Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 5 & 1U,
					CalibUpdate >> 5 & 1U
				});
				if ((CalibStatus >> 6 & 1U) == 1U)
				{
					this.f000135.Text = "P";
					this.f000135.ForeColor = Color.Green;
				}
				else
				{
					this.f000135.Text = "F";
					this.f000135.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 6 & 1U) == 1U)
				{
					this.f00014f.Text = "Y";
					this.f00014f.ForeColor = Color.Green;
				}
				else
				{
					this.f00014f.Text = "N";
					this.f00014f.ForeColor = Color.Red;
				}
				string text45 = string.Format("HPFcutoff Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 6 & 1U,
					CalibUpdate >> 6 & 1U
				});
				if ((CalibStatus >> 7 & 1U) == 1U)
				{
					this.f000133.Text = "P";
					this.f000133.ForeColor = Color.Green;
				}
				else
				{
					this.f000133.Text = "F";
					this.f000133.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 7 & 1U) == 1U)
				{
					this.f00014e.Text = "Y";
					this.f00014e.ForeColor = Color.Green;
				}
				else
				{
					this.f00014e.Text = "N";
					this.f00014e.ForeColor = Color.Red;
				}
				string text46 = string.Format("LPFcutoff Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 7 & 1U,
					CalibUpdate >> 7 & 1U
				});
				if ((CalibStatus >> 8 & 1U) == 1U)
				{
					this.m_lblRadarDevice4PeakDetector.Text = "P";
					this.m_lblRadarDevice4PeakDetector.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice4PeakDetector.Text = "F";
					this.m_lblRadarDevice4PeakDetector.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 8 & 1U) == 1U)
				{
					this.m_lblRadarDevice4PeakDetectorUpdate.Text = "Y";
					this.m_lblRadarDevice4PeakDetectorUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice4PeakDetectorUpdate.Text = "N";
					this.m_lblRadarDevice4PeakDetectorUpdate.ForeColor = Color.Red;
				}
				string text47 = string.Format("PeakDetector Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 8 & 1U,
					CalibUpdate >> 8 & 1U
				});
				if ((CalibStatus >> 9 & 1U) == 1U)
				{
					this.m_lblRadarDevice4RFTxPower.Text = "P";
					this.m_lblRadarDevice4RFTxPower.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice4RFTxPower.Text = "F";
					this.m_lblRadarDevice4RFTxPower.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 9 & 1U) == 1U)
				{
					this.m_lblRadarDevice4RFTxPowerUpdate.Text = "Y";
					this.m_lblRadarDevice4RFTxPowerUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice4RFTxPowerUpdate.Text = "N";
					this.m_lblRadarDevice4RFTxPowerUpdate.ForeColor = Color.Red;
				}
				string text48 = string.Format("TxPower Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 9 & 1U,
					CalibUpdate >> 9 & 1U
				});
				if ((CalibStatus >> 10 & 1U) == 1U)
				{
					this.m_lblRadarDevice4RxGain.Text = "P";
					this.m_lblRadarDevice4RxGain.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice4RxGain.Text = "F";
					this.m_lblRadarDevice4RxGain.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 10 & 1U) == 1U)
				{
					this.m_lblRadarDevice4RxGainUpdate.Text = "Y";
					this.m_lblRadarDevice4RxGainUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice4RxGainUpdate.Text = "N";
					this.m_lblRadarDevice4RxGainUpdate.ForeColor = Color.Red;
				}
				string text49 = string.Format("RxGain Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 10 & 1U,
					CalibUpdate >> 10 & 1U
				});
				if ((CalibStatus >> 11 & 1U) == 1U)
				{
					this.m_lblRadarDevice4TxPhase.Text = "P";
					this.m_lblRadarDevice4TxPhase.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice4TxPhase.Text = "F";
					this.m_lblRadarDevice4TxPhase.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 11 & 1U) == 1U)
				{
					this.m_lblRadarDevice4TxPhaseUpdate.Text = "Y";
					this.m_lblRadarDevice4TxPhaseUpdate.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRadarDevice4TxPhaseUpdate.Text = "N";
					this.m_lblRadarDevice4TxPhaseUpdate.ForeColor = Color.Red;
				}
				string text50 = string.Format("TxPhase Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 11 & 1U,
					CalibUpdate >> 11 & 1U
				});
				if ((CalibStatus >> 12 & 1U) == 1U)
				{
					this.f000166.Text = "P";
					this.f000166.ForeColor = Color.Green;
				}
				else
				{
					this.f000166.Text = "F";
					this.f000166.ForeColor = Color.Red;
				}
				if ((CalibUpdate >> 12 & 1U) == 1U)
				{
					this.f00014d.Text = "Y";
					this.f00014d.ForeColor = Color.Green;
				}
				else
				{
					this.f00014d.Text = "N";
					this.f00014d.ForeColor = Color.Red;
				}
				string text51 = string.Format("RxIQMM Status, Update: {0}, {1}; ", new object[]
				{
					CalibStatus >> 12 & 1U,
					CalibUpdate >> 12 & 1U
				});
				this.m_lblRadarDevice4Temperature.Text = Convert.ToString(Temperature);
				this.m_lblRadarDevice4TimeStamp.Text = Convert.ToString(TimeStamp);
				string text52 = string.Format("Time stamp, Temperture: {0},{1}; ", new object[]
				{
					Convert.ToString(TimeStamp),
					Convert.ToString(Temperature)
				});
				string full_command4 = string.Concat(new string[]
				{
					text52,
					text40,
					text41,
					text42,
					text43,
					text44,
					text45,
					text46,
					text47,
					text48,
					text49,
					text50,
					text51
				});
				GlobalRef.GuiManager.RecordLog(0, full_command4);
			}
			return true;
		}

		public void EnableDisbleRFInitCalibStatusWithRespectiveRadarDevices(ushort numberOfRadarDevicesDetected)
		{
			if (numberOfRadarDevicesDetected == 1)
			{
				this.m_lblRFInitApllcalStatus.Visible = true;
				this.f000149.Visible = true;
				this.f000148.Visible = true;
				this.f000146.Visible = true;
				this.f000144.Visible = true;
				this.f000147.Visible = true;
				this.f000145.Visible = true;
				this.m_lblPeakDetector.Visible = true;
				this.m_lblRFTxPower.Visible = true;
				this.m_lblRxGain.Visible = true;
				this.f000169.Visible = true;
				this.m_lblTemperature.Visible = true;
				this.m_lblTimeStamp.Visible = true;
				this.m_lblRFInitApllcalUpdate.Visible = true;
				this.f000165.Visible = true;
				this.f000164.Visible = true;
				this.f000163.Visible = true;
				this.f000162.Visible = true;
				this.f000161.Visible = true;
				this.f000160.Visible = true;
				this.m_lblPeakDetectorUpdate.Visible = true;
				this.m_lblRFTxPowerUpdate.Visible = true;
				this.m_lblRxGainUpdate.Visible = true;
				this.f00015f.Visible = true;
				this.lblRadarDevice2Status.Visible = false;
				this.lblRadarDevice2Update.Visible = false;
				this.m_lblRadarDevice2RFInitApllcalStatus.Visible = false;
				this.f000143.Visible = false;
				this.f000142.Visible = false;
				this.f000140.Visible = false;
				this.f00013e.Visible = false;
				this.f000141.Visible = false;
				this.f00013f.Visible = false;
				this.m_lblRadarDevice2PeakDetector.Visible = false;
				this.m_lblRadarDevice2RFTxPower.Visible = false;
				this.m_lblRadarDevice2RxGain.Visible = false;
				this.m_lblRadarDevice2TxPhase.Visible = false;
				this.f000168.Visible = false;
				this.m_lblRadarDevice2Temperature.Visible = false;
				this.m_lblRadarDevice2TimeStamp.Visible = false;
				this.m_lblRadarDevice2RFInitApllcalUpdate.Visible = false;
				this.f00015e.Visible = false;
				this.f00015d.Visible = false;
				this.m_lblRadarDevice2RFInitLODistUpdate.Visible = false;
				this.f00015c.Visible = false;
				this.f00015b.Visible = false;
				this.f00015a.Visible = false;
				this.m_lblRadarDevice2PeakDetectorUpdate.Visible = false;
				this.m_lblRadarDevice2RFTxPowerUpdate.Visible = false;
				this.m_lblRadarDevice2RxGainUpdate.Visible = false;
				this.m_lblRadarDevice2TxPhaseUpdate.Visible = false;
				this.f000159.Visible = false;
				this.lblRadarDevice3Status.Visible = false;
				this.lblRadarDevice3Update.Visible = false;
				this.m_lblRadarDevice3RFInitApllcalStatus.Visible = false;
				this.f00013d.Visible = false;
				this.f00013c.Visible = false;
				this.f00013a.Visible = false;
				this.f000138.Visible = false;
				this.f00013b.Visible = false;
				this.f000139.Visible = false;
				this.m_lblRadarDevice3PeakDetector.Visible = false;
				this.m_lblRadarDevice3RFTxPower.Visible = false;
				this.m_lblRadarDevice3RxGain.Visible = false;
				this.m_lblRadarDevice3TxPhase.Visible = false;
				this.f000167.Visible = false;
				this.m_lblRadarDevice3Temperature.Visible = false;
				this.m_lblRadarDevice3TimeStamp.Visible = false;
				this.m_lblRadarDevice3RFInitApllcalUpdate.Visible = false;
				this.f000158.Visible = false;
				this.f000157.Visible = false;
				this.m_lblRadarDevice3RFInitLODistUpdate.Visible = false;
				this.f000156.Visible = false;
				this.f000155.Visible = false;
				this.f000154.Visible = false;
				this.m_lblRadarDevice3PeakDetectorUpdate.Visible = false;
				this.m_lblRadarDevice3RFTxPowerUpdate.Visible = false;
				this.m_lblRadarDevice3RxGainUpdate.Visible = false;
				this.m_lblRadarDevice3TxPhaseUpdate.Visible = false;
				this.f000153.Visible = false;
				this.lblRadarDevice4Status.Visible = false;
				this.lblRadarDevice4Update.Visible = false;
				this.m_lblRadarDevice4RFInitApllcalStatus.Visible = false;
				this.f000137.Visible = false;
				this.f000136.Visible = false;
				this.f000134.Visible = false;
				this.f000132.Visible = false;
				this.f000135.Visible = false;
				this.f000133.Visible = false;
				this.m_lblRadarDevice4PeakDetector.Visible = false;
				this.m_lblRadarDevice4RFTxPower.Visible = false;
				this.m_lblRadarDevice4RxGain.Visible = false;
				this.m_lblRadarDevice4TxPhase.Visible = false;
				this.f000166.Visible = false;
				this.m_lblRadarDevice4Temperature.Visible = false;
				this.m_lblRadarDevice4TimeStamp.Visible = false;
				this.m_lblRadarDevice4RFInitApllcalUpdate.Visible = false;
				this.f000152.Visible = false;
				this.f000151.Visible = false;
				this.m_lblRadarDevice4RFInitLODistUpdate.Visible = false;
				this.f000150.Visible = false;
				this.f00014f.Visible = false;
				this.f00014e.Visible = false;
				this.m_lblRadarDevice4PeakDetectorUpdate.Visible = false;
				this.m_lblRadarDevice4RFTxPowerUpdate.Visible = false;
				this.m_lblRadarDevice4RxGainUpdate.Visible = false;
				this.m_lblRadarDevice4TxPhaseUpdate.Visible = false;
				this.f00014d.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 2)
			{
				this.m_lblRFInitApllcalStatus.Visible = true;
				this.f000149.Visible = true;
				this.f000148.Visible = true;
				this.f000146.Visible = true;
				this.f000144.Visible = true;
				this.f000147.Visible = true;
				this.f000145.Visible = true;
				this.m_lblPeakDetector.Visible = true;
				this.m_lblRFTxPower.Visible = true;
				this.m_lblRxGain.Visible = true;
				this.m_lblTxPhase.Visible = true;
				this.f000169.Visible = true;
				this.m_lblTemperature.Visible = true;
				this.m_lblTimeStamp.Visible = true;
				this.m_lblRFInitApllcalUpdate.Visible = true;
				this.f000165.Visible = true;
				this.f000164.Visible = true;
				this.f000163.Visible = true;
				this.f000162.Visible = true;
				this.f000161.Visible = true;
				this.f000160.Visible = true;
				this.m_lblPeakDetectorUpdate.Visible = true;
				this.m_lblRFTxPowerUpdate.Visible = true;
				this.m_lblRxGainUpdate.Visible = true;
				this.m_lblTxPhaseUpdate.Visible = true;
				this.f00015f.Visible = true;
				this.lblRadarDevice2Status.Visible = true;
				this.lblRadarDevice2Update.Visible = true;
				this.m_lblRadarDevice2RFInitApllcalStatus.Visible = true;
				this.f000143.Visible = true;
				this.f000142.Visible = true;
				this.f000140.Visible = true;
				this.f00013e.Visible = true;
				this.f000141.Visible = true;
				this.f00013f.Visible = true;
				this.m_lblRadarDevice2PeakDetector.Visible = true;
				this.m_lblRadarDevice2RFTxPower.Visible = true;
				this.m_lblRadarDevice2RxGain.Visible = true;
				this.m_lblRadarDevice2TxPhase.Visible = true;
				this.f000168.Visible = true;
				this.m_lblRadarDevice2Temperature.Visible = true;
				this.m_lblRadarDevice2TimeStamp.Visible = true;
				this.m_lblRadarDevice2RFInitApllcalUpdate.Visible = true;
				this.f00015e.Visible = true;
				this.f00015d.Visible = true;
				this.m_lblRadarDevice2RFInitLODistUpdate.Visible = true;
				this.f00015c.Visible = true;
				this.f00015b.Visible = true;
				this.f00015a.Visible = true;
				this.m_lblRadarDevice2PeakDetectorUpdate.Visible = true;
				this.m_lblRadarDevice2RFTxPowerUpdate.Visible = true;
				this.m_lblRadarDevice2RxGainUpdate.Visible = true;
				this.m_lblRadarDevice2TxPhaseUpdate.Visible = true;
				this.f000159.Visible = true;
				this.lblRadarDevice3Status.Visible = false;
				this.lblRadarDevice3Update.Visible = false;
				this.m_lblRadarDevice3RFInitApllcalStatus.Visible = false;
				this.f00013d.Visible = false;
				this.f00013c.Visible = false;
				this.f00013a.Visible = false;
				this.f000138.Visible = false;
				this.f00013b.Visible = false;
				this.f000139.Visible = false;
				this.m_lblRadarDevice3PeakDetector.Visible = false;
				this.m_lblRadarDevice3RFTxPower.Visible = false;
				this.m_lblRadarDevice3RxGain.Visible = false;
				this.m_lblRadarDevice3TxPhase.Visible = false;
				this.f000167.Visible = false;
				this.m_lblRadarDevice3Temperature.Visible = false;
				this.m_lblRadarDevice3TimeStamp.Visible = false;
				this.m_lblRadarDevice3RFInitApllcalUpdate.Visible = false;
				this.f000158.Visible = false;
				this.f000157.Visible = false;
				this.m_lblRadarDevice3RFInitLODistUpdate.Visible = false;
				this.f000156.Visible = false;
				this.f000155.Visible = false;
				this.f000154.Visible = false;
				this.m_lblRadarDevice3PeakDetectorUpdate.Visible = false;
				this.m_lblRadarDevice3RFTxPowerUpdate.Visible = false;
				this.m_lblRadarDevice3RxGainUpdate.Visible = false;
				this.m_lblRadarDevice3TxPhaseUpdate.Visible = false;
				this.f000153.Visible = false;
				this.lblRadarDevice4Status.Visible = false;
				this.lblRadarDevice4Update.Visible = false;
				this.m_lblRadarDevice4RFInitApllcalStatus.Visible = false;
				this.f000137.Visible = false;
				this.f000136.Visible = false;
				this.f000134.Visible = false;
				this.f000132.Visible = false;
				this.f000135.Visible = false;
				this.f000133.Visible = false;
				this.m_lblRadarDevice4PeakDetector.Visible = false;
				this.m_lblRadarDevice4RFTxPower.Visible = false;
				this.m_lblRadarDevice4RxGain.Visible = false;
				this.m_lblRadarDevice4TxPhase.Visible = false;
				this.f000166.Visible = false;
				this.m_lblRadarDevice4Temperature.Visible = false;
				this.m_lblRadarDevice4TimeStamp.Visible = false;
				this.m_lblRadarDevice4RFInitApllcalUpdate.Visible = false;
				this.f000152.Visible = false;
				this.f000151.Visible = false;
				this.m_lblRadarDevice4RFInitLODistUpdate.Visible = false;
				this.f000150.Visible = false;
				this.f00014f.Visible = false;
				this.f00014e.Visible = false;
				this.m_lblRadarDevice4PeakDetectorUpdate.Visible = false;
				this.m_lblRadarDevice4RFTxPowerUpdate.Visible = false;
				this.m_lblRadarDevice4RxGainUpdate.Visible = false;
				this.m_lblRadarDevice4TxPhaseUpdate.Visible = false;
				this.f00014d.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 4)
			{
				this.m_lblRFInitApllcalStatus.Visible = true;
				this.f000149.Visible = true;
				this.f000148.Visible = true;
				this.f000146.Visible = true;
				this.f000144.Visible = true;
				this.f000147.Visible = true;
				this.f000145.Visible = true;
				this.m_lblPeakDetector.Visible = true;
				this.m_lblRFTxPower.Visible = true;
				this.m_lblRxGain.Visible = true;
				this.m_lblTxPhase.Visible = true;
				this.f000169.Visible = true;
				this.m_lblTemperature.Visible = true;
				this.m_lblTimeStamp.Visible = true;
				this.m_lblRFInitApllcalUpdate.Visible = true;
				this.f000165.Visible = true;
				this.f000164.Visible = true;
				this.f000163.Visible = true;
				this.f000162.Visible = true;
				this.f000161.Visible = true;
				this.f000160.Visible = true;
				this.m_lblPeakDetectorUpdate.Visible = true;
				this.m_lblRFTxPowerUpdate.Visible = true;
				this.m_lblRxGainUpdate.Visible = true;
				this.m_lblTxPhaseUpdate.Visible = true;
				this.f00015f.Visible = true;
				this.lblRadarDevice2Status.Visible = true;
				this.lblRadarDevice2Update.Visible = true;
				this.m_lblRadarDevice2RFInitApllcalStatus.Visible = true;
				this.f000143.Visible = true;
				this.f000142.Visible = true;
				this.f000140.Visible = true;
				this.f00013e.Visible = true;
				this.f000141.Visible = true;
				this.f00013f.Visible = true;
				this.m_lblRadarDevice2PeakDetector.Visible = true;
				this.m_lblRadarDevice2RFTxPower.Visible = true;
				this.m_lblRadarDevice2RxGain.Visible = true;
				this.m_lblRadarDevice2TxPhase.Visible = true;
				this.f000168.Visible = true;
				this.m_lblRadarDevice2Temperature.Visible = true;
				this.m_lblRadarDevice2TimeStamp.Visible = true;
				this.m_lblRadarDevice2RFInitApllcalUpdate.Visible = true;
				this.f00015e.Visible = true;
				this.f00015d.Visible = true;
				this.m_lblRadarDevice2RFInitLODistUpdate.Visible = true;
				this.f00015c.Visible = true;
				this.f00015b.Visible = true;
				this.f00015a.Visible = true;
				this.m_lblRadarDevice2PeakDetectorUpdate.Visible = true;
				this.m_lblRadarDevice2RFTxPowerUpdate.Visible = true;
				this.m_lblRadarDevice2RxGainUpdate.Visible = true;
				this.m_lblRadarDevice2TxPhaseUpdate.Visible = true;
				this.f000159.Visible = true;
				this.lblRadarDevice3Status.Visible = true;
				this.lblRadarDevice3Update.Visible = true;
				this.m_lblRadarDevice3RFInitApllcalStatus.Visible = true;
				this.f00013d.Visible = true;
				this.f00013c.Visible = true;
				this.f00013a.Visible = true;
				this.f000138.Visible = true;
				this.f00013b.Visible = true;
				this.f000139.Visible = true;
				this.m_lblRadarDevice3PeakDetector.Visible = true;
				this.m_lblRadarDevice3RFTxPower.Visible = true;
				this.m_lblRadarDevice3RxGain.Visible = true;
				this.m_lblRadarDevice3TxPhase.Visible = true;
				this.f000167.Visible = true;
				this.m_lblRadarDevice3Temperature.Visible = true;
				this.m_lblRadarDevice3TimeStamp.Visible = true;
				this.m_lblRadarDevice3RFInitApllcalUpdate.Visible = true;
				this.f000158.Visible = true;
				this.f000157.Visible = true;
				this.m_lblRadarDevice3RFInitLODistUpdate.Visible = true;
				this.f000156.Visible = true;
				this.f000155.Visible = true;
				this.f000154.Visible = true;
				this.m_lblRadarDevice3PeakDetectorUpdate.Visible = true;
				this.m_lblRadarDevice3RFTxPowerUpdate.Visible = true;
				this.m_lblRadarDevice3RxGainUpdate.Visible = true;
				this.m_lblRadarDevice3TxPhaseUpdate.Visible = true;
				this.f000153.Visible = true;
				this.lblRadarDevice4Status.Visible = true;
				this.lblRadarDevice4Update.Visible = true;
				this.m_lblRadarDevice4RFInitApllcalStatus.Visible = true;
				this.f000137.Visible = true;
				this.f000136.Visible = true;
				this.f000134.Visible = true;
				this.f000132.Visible = true;
				this.f000135.Visible = true;
				this.f000133.Visible = true;
				this.m_lblRadarDevice4PeakDetector.Visible = true;
				this.m_lblRadarDevice4RFTxPower.Visible = true;
				this.m_lblRadarDevice4RxGain.Visible = true;
				this.m_lblRadarDevice4TxPhase.Visible = true;
				this.f000166.Visible = true;
				this.m_lblRadarDevice4Temperature.Visible = true;
				this.m_lblRadarDevice4TimeStamp.Visible = true;
				this.m_lblRadarDevice4RFInitApllcalUpdate.Visible = true;
				this.f000152.Visible = true;
				this.f000151.Visible = true;
				this.m_lblRadarDevice4RFInitLODistUpdate.Visible = true;
				this.f000150.Visible = true;
				this.f00014f.Visible = true;
				this.f00014e.Visible = true;
				this.m_lblRadarDevice4PeakDetectorUpdate.Visible = true;
				this.m_lblRadarDevice4RFTxPowerUpdate.Visible = true;
				this.m_lblRadarDevice4RxGainUpdate.Visible = true;
				this.m_lblRadarDevice4TxPhaseUpdate.Visible = true;
				this.f00014d.Visible = true;
				return;
			}
			this.m_lblRFInitApllcalStatus.Visible = false;
			this.f000149.Visible = false;
			this.f000148.Visible = false;
			this.f000146.Visible = false;
			this.f000144.Visible = false;
			this.f000147.Visible = false;
			this.f000145.Visible = false;
			this.m_lblPeakDetector.Visible = false;
			this.m_lblRFTxPower.Visible = false;
			this.m_lblRxGain.Visible = false;
			this.f000169.Visible = false;
			this.m_lblTemperature.Visible = false;
			this.m_lblTimeStamp.Visible = false;
			this.m_lblRFInitApllcalUpdate.Visible = false;
			this.f000165.Visible = false;
			this.f000164.Visible = false;
			this.f000163.Visible = false;
			this.f000162.Visible = false;
			this.f000161.Visible = false;
			this.f000160.Visible = false;
			this.m_lblPeakDetectorUpdate.Visible = false;
			this.m_lblRFTxPowerUpdate.Visible = false;
			this.m_lblRxGainUpdate.Visible = false;
			this.f00015f.Visible = false;
			this.lblRadarDevice2Status.Visible = false;
			this.lblRadarDevice2Update.Visible = false;
			this.m_lblRadarDevice2RFInitApllcalStatus.Visible = false;
			this.f000143.Visible = false;
			this.f000142.Visible = false;
			this.f000140.Visible = false;
			this.f00013e.Visible = false;
			this.f000141.Visible = false;
			this.f00013f.Visible = false;
			this.m_lblRadarDevice2PeakDetector.Visible = false;
			this.m_lblRadarDevice2RFTxPower.Visible = false;
			this.m_lblRadarDevice2RxGain.Visible = false;
			this.f000168.Visible = false;
			this.m_lblRadarDevice2Temperature.Visible = false;
			this.m_lblRadarDevice2TimeStamp.Visible = false;
			this.m_lblRadarDevice2RFInitApllcalUpdate.Visible = false;
			this.f00015e.Visible = false;
			this.f00015d.Visible = false;
			this.m_lblRadarDevice2RFInitLODistUpdate.Visible = false;
			this.f00015c.Visible = false;
			this.f00015b.Visible = false;
			this.f00015a.Visible = false;
			this.m_lblRadarDevice2PeakDetectorUpdate.Visible = false;
			this.m_lblRadarDevice2RFTxPowerUpdate.Visible = false;
			this.m_lblRadarDevice2RxGainUpdate.Visible = false;
			this.f000159.Visible = false;
			this.lblRadarDevice3Status.Visible = false;
			this.lblRadarDevice3Update.Visible = false;
			this.m_lblRadarDevice3RFInitApllcalStatus.Visible = false;
			this.f00013d.Visible = false;
			this.f00013c.Visible = false;
			this.f00013a.Visible = false;
			this.f000138.Visible = false;
			this.f00013b.Visible = false;
			this.f000139.Visible = false;
			this.m_lblRadarDevice3PeakDetector.Visible = false;
			this.m_lblRadarDevice3RFTxPower.Visible = false;
			this.m_lblRadarDevice3RxGain.Visible = false;
			this.f000167.Visible = false;
			this.m_lblRadarDevice3Temperature.Visible = false;
			this.m_lblRadarDevice3TimeStamp.Visible = false;
			this.m_lblRadarDevice3RFInitApllcalUpdate.Visible = false;
			this.f000158.Visible = false;
			this.f000157.Visible = false;
			this.m_lblRadarDevice3RFInitLODistUpdate.Visible = false;
			this.f000156.Visible = false;
			this.f000155.Visible = false;
			this.f000154.Visible = false;
			this.m_lblRadarDevice3PeakDetectorUpdate.Visible = false;
			this.m_lblRadarDevice3RFTxPowerUpdate.Visible = false;
			this.m_lblRadarDevice3RxGainUpdate.Visible = false;
			this.f000153.Visible = false;
			this.lblRadarDevice4Status.Visible = false;
			this.lblRadarDevice4Update.Visible = false;
			this.m_lblRadarDevice4RFInitApllcalStatus.Visible = false;
			this.f000137.Visible = false;
			this.f000136.Visible = false;
			this.f000134.Visible = false;
			this.f000132.Visible = false;
			this.f000135.Visible = false;
			this.f000133.Visible = false;
			this.m_lblRadarDevice4PeakDetector.Visible = false;
			this.m_lblRadarDevice4RFTxPower.Visible = false;
			this.m_lblRadarDevice4RxGain.Visible = false;
			this.f000166.Visible = false;
			this.m_lblRadarDevice4Temperature.Visible = false;
			this.m_lblRadarDevice4TimeStamp.Visible = false;
			this.m_lblRadarDevice4RFInitApllcalUpdate.Visible = false;
			this.f000152.Visible = false;
			this.f000151.Visible = false;
			this.m_lblRadarDevice4RFInitLODistUpdate.Visible = false;
			this.f000150.Visible = false;
			this.f00014f.Visible = false;
			this.f00014e.Visible = false;
			this.m_lblRadarDevice4PeakDetectorUpdate.Visible = false;
			this.m_lblRadarDevice4RFTxPowerUpdate.Visible = false;
			this.m_lblRadarDevice4RxGainUpdate.Visible = false;
			this.f00014d.Visible = false;
		}

		public void ResetTheRFInitCalibReportOfRadarDevice1Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheRFInitCalibReportOfRadarDevice1Status);
				base.Invoke(method);
				return;
			}
			this.m_lblRFInitApllcalStatus.Text = "F";
			this.m_lblRFInitApllcalStatus.ForeColor = Color.Red;
			this.f000149.Text = "F";
			this.f000149.ForeColor = Color.Red;
			this.f000148.Text = "F";
			this.f000148.ForeColor = Color.Red;
			this.f000146.Text = "F";
			this.f000146.ForeColor = Color.Red;
			this.f000144.Text = "F";
			this.f000144.ForeColor = Color.Red;
			this.f000147.Text = "F";
			this.f000147.ForeColor = Color.Red;
			this.f000145.Text = "F";
			this.f000145.ForeColor = Color.Red;
			this.m_lblPeakDetector.Text = "F";
			this.m_lblPeakDetector.ForeColor = Color.Red;
			this.m_lblRFTxPower.Text = "F";
			this.m_lblRFTxPower.ForeColor = Color.Red;
			this.m_lblRxGain.Text = "F";
			this.m_lblRxGain.ForeColor = Color.Red;
			this.f000169.Text = "F";
			this.f000169.ForeColor = Color.Red;
			this.m_lblTemperature.Text = "0";
			this.m_lblTimeStamp.Text = "0";
			this.m_lblRFInitApllcalUpdate.Text = "N";
			this.m_lblRFInitApllcalUpdate.ForeColor = Color.Red;
			this.f000165.Text = "N";
			this.f000165.ForeColor = Color.Red;
			this.f000164.Text = "N";
			this.f000164.ForeColor = Color.Red;
			this.f000163.Text = "N";
			this.f000163.ForeColor = Color.Red;
			this.f000162.Text = "N";
			this.f000162.ForeColor = Color.Red;
			this.f000161.Text = "N";
			this.f000161.ForeColor = Color.Red;
			this.f000160.Text = "N";
			this.f000160.ForeColor = Color.Red;
			this.m_lblPeakDetectorUpdate.Text = "N";
			this.m_lblPeakDetectorUpdate.ForeColor = Color.Red;
			this.m_lblRFTxPowerUpdate.Text = "N";
			this.m_lblRFTxPowerUpdate.ForeColor = Color.Red;
			this.m_lblRxGainUpdate.Text = "N";
			this.m_lblRxGainUpdate.ForeColor = Color.Red;
			this.f00015f.Text = "N";
			this.f00015f.ForeColor = Color.Red;
		}

		public void ResetTheRFInitCalibReportOfRadarDevice2Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheRFInitCalibReportOfRadarDevice2Status);
				base.Invoke(method);
				return;
			}
			this.m_lblRadarDevice2RFInitApllcalStatus.Text = "F";
			this.f000143.Text = "F";
			this.f000142.Text = "F";
			this.f000140.Text = "F";
			this.f00013e.Text = "F";
			this.f000141.Text = "F";
			this.f00013f.Text = "F";
			this.m_lblRadarDevice2PeakDetector.Text = "F";
			this.m_lblRadarDevice2RFTxPower.Text = "F";
			this.m_lblRadarDevice2RxGain.Text = "F";
			this.f000168.Text = "F";
			this.m_lblRadarDevice2Temperature.Text = "0";
			this.m_lblRadarDevice2TimeStamp.Text = "0";
			this.m_lblRadarDevice2RFInitApllcalUpdate.Text = "N";
			this.f00015e.Text = "N";
			this.f00015d.Text = "N";
			this.m_lblRadarDevice2RFInitLODistUpdate.Text = "N";
			this.f00015c.Text = "N";
			this.f00015b.Text = "N";
			this.f00015a.Text = "N";
			this.m_lblRadarDevice2PeakDetectorUpdate.Text = "N";
			this.m_lblRadarDevice2RFTxPowerUpdate.Text = "N";
			this.m_lblRadarDevice2RxGainUpdate.Text = "N";
			this.f000159.Text = "N";
		}

		public void ResetTheRFInitCalibReportOfRadarDevice3Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheRFInitCalibReportOfRadarDevice3Status);
				base.Invoke(method);
				return;
			}
			this.m_lblRadarDevice3RFInitApllcalStatus.Text = "F";
			this.f00013d.Text = "F";
			this.f00013c.Text = "F";
			this.f00013a.Text = "F";
			this.f000138.Text = "F";
			this.f00013b.Text = "F";
			this.f000139.Text = "F";
			this.m_lblRadarDevice3PeakDetector.Text = "F";
			this.m_lblRadarDevice3RFTxPower.Text = "F";
			this.m_lblRadarDevice3RxGain.Text = "F";
			this.f000167.Text = "F";
			this.m_lblRadarDevice3Temperature.Text = "0";
			this.m_lblRadarDevice3TimeStamp.Text = "0";
			this.m_lblRadarDevice3RFInitApllcalUpdate.Text = "N";
			this.f000158.Text = "N";
			this.f000157.Text = "N";
			this.m_lblRadarDevice3RFInitLODistUpdate.Text = "N";
			this.f000156.Text = "N";
			this.f000155.Text = "N";
			this.f000154.Text = "N";
			this.m_lblRadarDevice3PeakDetectorUpdate.Text = "N";
			this.m_lblRadarDevice3RFTxPowerUpdate.Text = "N";
			this.m_lblRadarDevice3RxGainUpdate.Text = "N";
			this.f000153.Text = "N";
		}

		public void ResetTheRFInitCalibReportOfRadarDevice4Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheRFInitCalibReportOfRadarDevice4Status);
				base.Invoke(method);
				return;
			}
			this.m_lblRadarDevice4RFInitApllcalStatus.Text = "F";
			this.f000137.Text = "F";
			this.f000136.Text = "F";
			this.f000134.Text = "F";
			this.f000132.Text = "F";
			this.f000135.Text = "F";
			this.f000133.Text = "F";
			this.m_lblRadarDevice4PeakDetector.Text = "F";
			this.m_lblRadarDevice4RFTxPower.Text = "F";
			this.m_lblRadarDevice4RxGain.Text = "F";
			this.f000166.Text = "F";
			this.m_lblRadarDevice4Temperature.Text = "0";
			this.m_lblRadarDevice4TimeStamp.Text = "0";
			this.m_lblRadarDevice4RFInitApllcalUpdate.Text = "N";
			this.f000152.Text = "N";
			this.f000151.Text = "N";
			this.m_lblRadarDevice4RFInitLODistUpdate.Text = "N";
			this.f000150.Text = "N";
			this.f00014f.Text = "N";
			this.f00014e.Text = "N";
			this.m_lblRadarDevice4PeakDetectorUpdate.Text = "N";
			this.m_lblRadarDevice4RFTxPowerUpdate.Text = "N";
			this.m_lblRadarDevice4RxGainUpdate.Text = "N";
			this.f00014d.Text = "N";
		}

		public bool RFRunTimeCalibStatusReport(uint RadarDeviceId, uint ErrorFlag, uint UpdateStatus, int Temperature, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				delegate0fc method = new delegate0fc(this.RFRunTimeCalibStatusReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					ErrorFlag,
					UpdateStatus,
					Temperature,
					TimeStamp
				});
			}
			else
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				if (RadarDeviceId == 1U)
				{
					if ((ErrorFlag >> 1 & 1U) == 1U)
					{
						this.m_lblRunTimeApllcalStatus.Text = "P";
						this.m_lblRunTimeApllcalStatus.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeApllcalStatus.Text = "F";
						this.m_lblRunTimeApllcalStatus.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 2 & 1U) == 1U)
					{
						this.m_lblRunTimeVCO.Text = "P";
						this.m_lblRunTimeVCO.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeVCO.Text = "F";
						this.m_lblRunTimeVCO.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 3 & 1U) == 1U)
					{
						this.m_lblRunTimeVCO2.Text = "P";
						this.m_lblRunTimeVCO2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeVCO2.Text = "F";
						this.m_lblRunTimeVCO2.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 4 & 1U) == 1U)
					{
						this.m_lblRunTimeLODist.Text = "P";
						this.m_lblRunTimeLODist.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeLODist.Text = "F";
						this.m_lblRunTimeLODist.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 8 & 1U) == 1U)
					{
						this.m_lblRunTimePDCal.Text = "P";
						this.m_lblRunTimePDCal.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimePDCal.Text = "F";
						this.m_lblRunTimePDCal.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 9 & 1U) == 1U)
					{
						this.m_lblRunTimeTxPower.Text = "P";
						this.m_lblRunTimeTxPower.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeTxPower.Text = "F";
						this.m_lblRunTimeTxPower.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 10 & 1U) == 1U)
					{
						this.m_lblRunTimeRxGain.Text = "P";
						this.m_lblRunTimeRxGain.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeRxGain.Text = "F";
						this.m_lblRunTimeRxGain.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 1 & 1U) == 1U)
					{
						this.m_lblRunTimeApllcalStatus2.Text = "Y";
						this.m_lblRunTimeApllcalStatus2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeApllcalStatus2.Text = "N";
						this.m_lblRunTimeApllcalStatus2.ForeColor = Color.Red;
					}
					string text = string.Format("APLL Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 1 & 1U,
						UpdateStatus >> 1 & 1U
					});
					if ((UpdateStatus >> 2 & 1U) == 1U)
					{
						this.m_lblRunTimeVCO22.Text = "Y";
						this.m_lblRunTimeVCO22.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeVCO22.Text = "N";
						this.m_lblRunTimeVCO22.ForeColor = Color.Red;
					}
					string text2 = string.Format("VCO1 Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 2 & 1U,
						UpdateStatus >> 2 & 1U
					});
					if ((UpdateStatus >> 3 & 1U) == 1U)
					{
						this.m_lblRunTimeVCO2Update.Text = "Y";
						this.m_lblRunTimeVCO2Update.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeVCO2Update.Text = "N";
						this.m_lblRunTimeVCO2Update.ForeColor = Color.Red;
					}
					string text3 = string.Format("VCO2 Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 3 & 1U,
						UpdateStatus >> 3 & 1U
					});
					if ((UpdateStatus >> 4 & 1U) == 1U)
					{
						this.m_lblRunTimeLODist2.Text = "Y";
						this.m_lblRunTimeLODist2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeLODist2.Text = "N";
						this.m_lblRunTimeLODist2.ForeColor = Color.Red;
					}
					string text4 = string.Format("LODist Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 4 & 1U,
						UpdateStatus >> 4 & 1U
					});
					if ((UpdateStatus >> 8 & 1U) == 1U)
					{
						this.m_lblRunTimePDCal2.Text = "Y";
						this.m_lblRunTimePDCal2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimePDCal2.Text = "N";
						this.m_lblRunTimePDCal2.ForeColor = Color.Red;
					}
					string text5 = string.Format("PDCal Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 8 & 1U,
						UpdateStatus >> 8 & 1U
					});
					if ((UpdateStatus >> 9 & 1U) == 1U)
					{
						this.m_lblRunTimeTxPower2.Text = "Y";
						this.m_lblRunTimeTxPower2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeTxPower2.Text = "N";
						this.m_lblRunTimeTxPower2.ForeColor = Color.Red;
					}
					string text6 = string.Format("TxPower Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 9 & 1U,
						UpdateStatus >> 9 & 1U
					});
					if ((UpdateStatus >> 10 & 1U) == 1U)
					{
						this.m_lblRunTimeRxGain2.Text = "Y";
						this.m_lblRunTimeRxGain2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeRxGain2.Text = "N";
						this.m_lblRunTimeRxGain2.ForeColor = Color.Red;
					}
					string text7 = string.Format("RxPower Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 10 & 1U,
						UpdateStatus >> 10 & 1U
					});
					this.m_lblRunTimeTemp.Text = Convert.ToString(Temperature);
					this.m_lblRunTimeTimeStamp.Text = Convert.ToString(TimeStamp);
					string text8 = string.Format("Time stamp, Temperature: {0},{1}; ", new object[]
					{
						Convert.ToString(TimeStamp),
						Convert.ToString(Temperature)
					});
					string full_command = string.Concat(new string[]
					{
						text8,
						text,
						text2,
						text3,
						text4,
						text5,
						text6,
						text7
					});
					GlobalRef.GuiManager.RecordLog(0, full_command);
					Convert.ToInt16(Temperature);
				}
			}
			return true;
		}

		public bool CascadeRFRunTimeCalibStatusReport(uint RadarDeviceId, uint ErrorFlag, uint UpdateStatus, int Temperature, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				delegate0fc method = new delegate0fc(this.CascadeRFRunTimeCalibStatusReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					ErrorFlag,
					UpdateStatus,
					Temperature,
					TimeStamp
				});
			}
			else
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				if (RadarDeviceId == 0U)
				{
					if ((ErrorFlag >> 1 & 1U) == 1U)
					{
						this.m_lblRunTimeApllcalStatus.Text = "P";
						this.m_lblRunTimeApllcalStatus.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeApllcalStatus.Text = "F";
						this.m_lblRunTimeApllcalStatus.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 2 & 1U) == 1U)
					{
						this.m_lblRunTimeVCO.Text = "P";
						this.m_lblRunTimeVCO.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeVCO.Text = "F";
						this.m_lblRunTimeVCO.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 3 & 1U) == 1U)
					{
						this.m_lblRunTimeVCO2.Text = "P";
						this.m_lblRunTimeVCO2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeVCO2.Text = "F";
						this.m_lblRunTimeVCO2.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 4 & 1U) == 1U)
					{
						this.m_lblRunTimeLODist.Text = "P";
						this.m_lblRunTimeLODist.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeLODist.Text = "F";
						this.m_lblRunTimeLODist.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 8 & 1U) == 1U)
					{
						this.m_lblRunTimePDCal.Text = "P";
						this.m_lblRunTimePDCal.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimePDCal.Text = "F";
						this.m_lblRunTimePDCal.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 9 & 1U) == 1U)
					{
						this.m_lblRunTimeTxPower.Text = "P";
						this.m_lblRunTimeTxPower.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeTxPower.Text = "F";
						this.m_lblRunTimeTxPower.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 10 & 1U) == 1U)
					{
						this.m_lblRunTimeRxGain.Text = "P";
						this.m_lblRunTimeRxGain.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeRxGain.Text = "F";
						this.m_lblRunTimeRxGain.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 1 & 1U) == 1U)
					{
						this.m_lblRunTimeApllcalStatus2.Text = "Y";
						this.m_lblRunTimeApllcalStatus2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeApllcalStatus2.Text = "N";
						this.m_lblRunTimeApllcalStatus2.ForeColor = Color.Red;
					}
					string text = string.Format("APLL Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 1 & 1U,
						UpdateStatus >> 1 & 1U
					});
					if ((UpdateStatus >> 2 & 1U) == 1U)
					{
						this.m_lblRunTimeVCO22.Text = "Y";
						this.m_lblRunTimeVCO22.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeVCO22.Text = "N";
						this.m_lblRunTimeVCO22.ForeColor = Color.Red;
					}
					string text2 = string.Format("VCO1 Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 2 & 1U,
						UpdateStatus >> 2 & 1U
					});
					if ((UpdateStatus >> 3 & 1U) == 1U)
					{
						this.m_lblRunTimeVCO2Update.Text = "Y";
						this.m_lblRunTimeVCO2Update.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeVCO2Update.Text = "N";
						this.m_lblRunTimeVCO2Update.ForeColor = Color.Red;
					}
					string text3 = string.Format("VCO2 Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 3 & 1U,
						UpdateStatus >> 3 & 1U
					});
					if ((UpdateStatus >> 4 & 1U) == 1U)
					{
						this.m_lblRunTimeLODist2.Text = "Y";
						this.m_lblRunTimeLODist2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeLODist2.Text = "N";
						this.m_lblRunTimeLODist2.ForeColor = Color.Red;
					}
					string text4 = string.Format("LODist Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 4 & 1U,
						UpdateStatus >> 4 & 1U
					});
					if ((UpdateStatus >> 8 & 1U) == 1U)
					{
						this.m_lblRunTimePDCal2.Text = "Y";
						this.m_lblRunTimePDCal2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimePDCal2.Text = "N";
						this.m_lblRunTimePDCal2.ForeColor = Color.Red;
					}
					string text5 = string.Format("PDCal Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 8 & 1U,
						UpdateStatus >> 8 & 1U
					});
					if ((UpdateStatus >> 9 & 1U) == 1U)
					{
						this.m_lblRunTimeTxPower2.Text = "Y";
						this.m_lblRunTimeTxPower2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeTxPower2.Text = "N";
						this.m_lblRunTimeTxPower2.ForeColor = Color.Red;
					}
					string text6 = string.Format("TxPower Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 9 & 1U,
						UpdateStatus >> 9 & 1U
					});
					if ((UpdateStatus >> 10 & 1U) == 1U)
					{
						this.m_lblRunTimeRxGain2.Text = "Y";
						this.m_lblRunTimeRxGain2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRunTimeRxGain2.Text = "N";
						this.m_lblRunTimeRxGain2.ForeColor = Color.Red;
					}
					string text7 = string.Format("RxPower Status, Update: {0}, {1}; ", new object[]
					{
						ErrorFlag >> 10 & 1U,
						UpdateStatus >> 10 & 1U
					});
					this.m_lblRunTimeTemp.Text = Convert.ToString(Temperature);
					this.m_lblRunTimeTimeStamp.Text = Convert.ToString(TimeStamp);
					string text8 = string.Format("Time stamp, Temperature: {0},{1}; ", new object[]
					{
						Convert.ToString(TimeStamp),
						Convert.ToString(Temperature)
					});
					string.Concat(new string[]
					{
						text8,
						text,
						text2,
						text3,
						text4,
						text5,
						text6,
						text7
					});
					Convert.ToInt16(Temperature);
				}
				else if (RadarDeviceId == 1U)
				{
					if ((ErrorFlag >> 1 & 1U) == 1U)
					{
						this.m_lblRadarDevice2RunTimeApllcalStatus.Text = "P";
						this.m_lblRadarDevice2RunTimeApllcalStatus.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice2RunTimeApllcalStatus.Text = "F";
						this.m_lblRadarDevice2RunTimeApllcalStatus.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 2 & 1U) == 1U)
					{
						this.m_lblrRadarDevice2RunTimeVCO.Text = "P";
						this.m_lblrRadarDevice2RunTimeVCO.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblrRadarDevice2RunTimeVCO.Text = "F";
						this.m_lblrRadarDevice2RunTimeVCO.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 3 & 1U) == 1U)
					{
						this.m_lblrRadarDevice2RunTimeVCO2.Text = "P";
						this.m_lblrRadarDevice2RunTimeVCO2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblrRadarDevice2RunTimeVCO2.Text = "F";
						this.m_lblrRadarDevice2RunTimeVCO2.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 4 & 1U) == 1U)
					{
						this.m_lblRadarDevice2RunTimeLODist.Text = "P";
						this.m_lblRadarDevice2RunTimeLODist.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice2RunTimeLODist.Text = "F";
						this.m_lblRadarDevice2RunTimeLODist.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 9 & 1U) == 1U)
					{
						this.m_lblRadarDevice2RunTimeTxPower.Text = "P";
						this.m_lblRadarDevice2RunTimeTxPower.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice2RunTimeTxPower.Text = "F";
						this.m_lblRadarDevice2RunTimeTxPower.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 10 & 1U) == 1U)
					{
						this.m_lblRadarDevice2RunTimeRxGain.Text = "P";
						this.m_lblRadarDevice2RunTimeRxGain.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice2RunTimeRxGain.Text = "F";
						this.m_lblRadarDevice2RunTimeRxGain.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 1 & 1U) == 1U)
					{
						this.m_lblRadarDevice2RunTimeApllcalStatus2.Text = "Y";
						this.m_lblRadarDevice2RunTimeApllcalStatus2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice2RunTimeApllcalStatus2.Text = "N";
						this.m_lblRadarDevice2RunTimeApllcalStatus2.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 2 & 1U) == 1U)
					{
						this.f00014c.Text = "Y";
						this.f00014c.ForeColor = Color.Green;
					}
					else
					{
						this.f00014c.Text = "N";
						this.f00014c.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 3 & 1U) == 1U)
					{
						this.m_lblrRadarDevice2RunTimeVCO2Update.Text = "Y";
						this.m_lblrRadarDevice2RunTimeVCO2Update.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblrRadarDevice2RunTimeVCO2Update.Text = "N";
						this.m_lblrRadarDevice2RunTimeVCO2Update.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 4 & 1U) == 1U)
					{
						this.m_lblRadarDevice2RunTimeLODist2.Text = "Y";
						this.m_lblRadarDevice2RunTimeLODist2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice2RunTimeLODist2.Text = "N";
						this.m_lblRadarDevice2RunTimeLODist2.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 9 & 1U) == 1U)
					{
						this.m_lblRadarDevice2RunTimeTxPower2.Text = "Y";
						this.m_lblRadarDevice2RunTimeTxPower2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice2RunTimeTxPower2.Text = "N";
						this.m_lblRadarDevice2RunTimeTxPower2.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 10 & 1U) == 1U)
					{
						this.m_lblRadarDevice2RunTimeRxGain2.Text = "Y";
						this.m_lblRadarDevice2RunTimeRxGain2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice2RunTimeRxGain2.Text = "N";
						this.m_lblRadarDevice2RunTimeRxGain2.ForeColor = Color.Red;
					}
					this.m_lblRadarDevice2RunTimeTemp.Text = Convert.ToString(Temperature);
					this.m_lblRadarDevice2RunTimeTimeStamp.Text = Convert.ToString(TimeStamp);
				}
				else if (RadarDeviceId == 2U)
				{
					if ((ErrorFlag >> 1 & 1U) == 1U)
					{
						this.m_lblRadarDevice3RunTimeApllcalStatus.Text = "P";
						this.m_lblRadarDevice3RunTimeApllcalStatus.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice3RunTimeApllcalStatus.Text = "F";
						this.m_lblRadarDevice3RunTimeApllcalStatus.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 2 & 1U) == 1U)
					{
						this.m_lblrRadarDevice3RunTimeVCO.Text = "P";
						this.m_lblrRadarDevice3RunTimeVCO.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblrRadarDevice3RunTimeVCO.Text = "F";
						this.m_lblrRadarDevice3RunTimeVCO.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 3 & 1U) == 1U)
					{
						this.m_lblrRadarDevice3RunTimeVCO2.Text = "P";
						this.m_lblrRadarDevice3RunTimeVCO2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblrRadarDevice3RunTimeVCO2.Text = "F";
						this.m_lblrRadarDevice3RunTimeVCO2.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 4 & 1U) == 1U)
					{
						this.m_lblRadarDevice3RunTimeLODist.Text = "P";
						this.m_lblRadarDevice3RunTimeLODist.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice3RunTimeLODist.Text = "F";
						this.m_lblRadarDevice3RunTimeLODist.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 9 & 1U) == 1U)
					{
						this.m_lblRadarDevice3RunTimeTxPower.Text = "P";
						this.m_lblRadarDevice3RunTimeTxPower.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice3RunTimeTxPower.Text = "F";
						this.m_lblRadarDevice3RunTimeTxPower.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 10 & 1U) == 1U)
					{
						this.m_lblRadarDevice3RunTimeRxGain.Text = "P";
						this.m_lblRadarDevice3RunTimeRxGain.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice3RunTimeRxGain.Text = "F";
						this.m_lblRadarDevice3RunTimeRxGain.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 1 & 1U) == 1U)
					{
						this.m_lblRadarDevice3RunTimeApllcalStatus3.Text = "Y";
						this.m_lblRadarDevice3RunTimeApllcalStatus3.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice3RunTimeApllcalStatus3.Text = "N";
						this.m_lblRadarDevice3RunTimeApllcalStatus3.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 2 & 1U) == 1U)
					{
						this.f00014b.Text = "Y";
						this.f00014b.ForeColor = Color.Green;
					}
					else
					{
						this.f00014b.Text = "N";
						this.f00014b.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 3 & 1U) == 1U)
					{
						this.m_lblrRadarDevice3RunTimeVCO2Update.Text = "Y";
						this.m_lblrRadarDevice3RunTimeVCO2Update.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblrRadarDevice3RunTimeVCO2Update.Text = "N";
						this.m_lblrRadarDevice3RunTimeVCO2Update.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 4 & 1U) == 1U)
					{
						this.m_lblRadarDevice2RunTimeLODist3.Text = "Y";
						this.m_lblRadarDevice2RunTimeLODist3.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice2RunTimeLODist3.Text = "N";
						this.m_lblRadarDevice2RunTimeLODist3.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 9 & 1U) == 1U)
					{
						this.m_lblRadarDevice3RunTimeTxPower2.Text = "Y";
						this.m_lblRadarDevice3RunTimeTxPower2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice3RunTimeTxPower2.Text = "N";
						this.m_lblRadarDevice3RunTimeTxPower2.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 10 & 1U) == 1U)
					{
						this.m_lblRadarDevice3RunTimeRxGain2.Text = "Y";
						this.m_lblRadarDevice3RunTimeRxGain2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice3RunTimeRxGain2.Text = "N";
						this.m_lblRadarDevice3RunTimeRxGain2.ForeColor = Color.Red;
					}
					this.m_lblRadarDevice3RunTimeTemp.Text = Convert.ToString(Temperature);
					this.m_lblRadarDevice3RunTimeTimeStamp.Text = Convert.ToString(TimeStamp);
				}
				else if (RadarDeviceId == 3U)
				{
					if ((ErrorFlag >> 1 & 1U) == 1U)
					{
						this.m_lblRadarDevice4RunTimeApllcalStatus.Text = "P";
						this.m_lblRadarDevice4RunTimeApllcalStatus.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice4RunTimeApllcalStatus.Text = "F";
						this.m_lblRadarDevice4RunTimeApllcalStatus.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 2 & 1U) == 1U)
					{
						this.m_lblrRadarDevice4RunTimeVCO.Text = "P";
						this.m_lblrRadarDevice4RunTimeVCO.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblrRadarDevice4RunTimeVCO.Text = "F";
						this.m_lblrRadarDevice4RunTimeVCO.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 3 & 1U) == 1U)
					{
						this.m_lblrRadarDevice4RunTimeVCO2.Text = "P";
						this.m_lblrRadarDevice4RunTimeVCO2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblrRadarDevice4RunTimeVCO2.Text = "F";
						this.m_lblrRadarDevice4RunTimeVCO2.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 4 & 1U) == 1U)
					{
						this.m_lblRadarDevice4RunTimeLODist.Text = "P";
						this.m_lblRadarDevice4RunTimeLODist.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice4RunTimeLODist.Text = "F";
						this.m_lblRadarDevice4RunTimeLODist.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 9 & 1U) == 1U)
					{
						this.m_lblRadarDevice4RunTimeTxPower.Text = "P";
						this.m_lblRadarDevice4RunTimeTxPower.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice4RunTimeTxPower.Text = "F";
						this.m_lblRadarDevice4RunTimeTxPower.ForeColor = Color.Red;
					}
					if ((ErrorFlag >> 10 & 1U) == 1U)
					{
						this.m_lblRadarDevice4RunTimeRxGain.Text = "P";
						this.m_lblRadarDevice4RunTimeRxGain.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice4RunTimeRxGain.Text = "F";
						this.m_lblRadarDevice4RunTimeRxGain.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 1 & 1U) == 1U)
					{
						this.m_lblRadarDevice4RunTimeApllcalStatus4.Text = "Y";
						this.m_lblRadarDevice4RunTimeApllcalStatus4.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice4RunTimeApllcalStatus4.Text = "N";
						this.m_lblRadarDevice4RunTimeApllcalStatus4.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 2 & 1U) == 1U)
					{
						this.f00014a.Text = "Y";
						this.f00014a.ForeColor = Color.Green;
					}
					else
					{
						this.f00014a.Text = "N";
						this.f00014a.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 3 & 1U) == 1U)
					{
						this.m_lblrRadarDevice4RunTimeVCO2Update.Text = "Y";
						this.m_lblrRadarDevice4RunTimeVCO2Update.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblrRadarDevice4RunTimeVCO2Update.Text = "N";
						this.m_lblrRadarDevice4RunTimeVCO2Update.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 4 & 1U) == 1U)
					{
						this.m_lblRadarDevice2RunTimeLODist4.Text = "Y";
						this.m_lblRadarDevice2RunTimeLODist4.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice2RunTimeLODist4.Text = "N";
						this.m_lblRadarDevice2RunTimeLODist4.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 9 & 1U) == 1U)
					{
						this.m_lblRadarDevice4RunTimeTxPower2.Text = "Y";
						this.m_lblRadarDevice4RunTimeTxPower2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice4RunTimeTxPower2.Text = "N";
						this.m_lblRadarDevice4RunTimeTxPower2.ForeColor = Color.Red;
					}
					if ((UpdateStatus >> 10 & 1U) == 1U)
					{
						this.m_lblRadarDevice4RunTimeRxGain2.Text = "Y";
						this.m_lblRadarDevice4RunTimeRxGain2.ForeColor = Color.Green;
					}
					else
					{
						this.m_lblRadarDevice4RunTimeRxGain2.Text = "N";
						this.m_lblRadarDevice4RunTimeRxGain2.ForeColor = Color.Red;
					}
					this.m_lblRadarDevice4RunTimeTemp.Text = Convert.ToString(Temperature);
					this.m_lblRadarDevice4RunTimeTimeStamp.Text = Convert.ToString(TimeStamp);
					Convert.ToInt16(Temperature);
				}
			}
			return true;
		}

		public void EnableDisbleRunTimeCalibStatusWithRespectiveRadarDevices(ushort numberOfRadarDevicesDetected)
		{
			if (numberOfRadarDevicesDetected == 1)
			{
				this.m_lblRunTimeApllcalStatus.Visible = true;
				this.m_lblRunTimeVCO.Visible = true;
				this.m_lblRunTimeVCO2.Visible = true;
				this.m_lblRunTimeLODist.Visible = true;
				this.m_lblRunTimeTxPower.Visible = true;
				this.m_lblRunTimeRxGain.Visible = true;
				this.m_lblRunTimeApllcalStatus2.Visible = true;
				this.m_lblRunTimeVCO22.Visible = true;
				this.m_lblRunTimeVCO2Update.Visible = true;
				this.m_lblRunTimeLODist2.Visible = true;
				this.m_lblRunTimeTxPower2.Visible = true;
				this.m_lblRunTimeRxGain2.Visible = true;
				this.m_lblRunTimeTemp.Visible = true;
				this.m_lblRunTimeTimeStamp.Visible = true;
				this.m_lblRadarDevice2RunTimeApllcalStatus.Visible = false;
				this.m_lblrRadarDevice2RunTimeVCO.Visible = false;
				this.m_lblrRadarDevice2RunTimeVCO2.Visible = false;
				this.m_lblRadarDevice2RunTimeLODist.Visible = false;
				this.m_lblRadarDevice2RunTimeTxPower.Visible = false;
				this.m_lblRadarDevice2RunTimeRxGain.Visible = false;
				this.m_lblRadarDevice2RunTimeApllcalStatus2.Visible = false;
				this.f00014c.Visible = false;
				this.m_lblrRadarDevice2RunTimeVCO2Update.Visible = false;
				this.m_lblRadarDevice2RunTimeLODist2.Visible = false;
				this.m_lblRadarDevice2RunTimeTxPower2.Visible = false;
				this.m_lblRadarDevice2RunTimeRxGain2.Visible = false;
				this.m_lblRadarDevice2RunTimeTemp.Visible = false;
				this.m_lblRadarDevice2RunTimeTimeStamp.Visible = false;
				this.m_lblRadarDevice3RunTimeApllcalStatus.Visible = false;
				this.m_lblrRadarDevice3RunTimeVCO.Visible = false;
				this.m_lblrRadarDevice3RunTimeVCO2.Visible = false;
				this.m_lblRadarDevice3RunTimeLODist.Visible = false;
				this.m_lblRadarDevice3RunTimeTxPower.Visible = false;
				this.m_lblRadarDevice3RunTimeRxGain.Visible = false;
				this.m_lblRadarDevice3RunTimeApllcalStatus3.Visible = false;
				this.f00014b.Visible = false;
				this.m_lblrRadarDevice3RunTimeVCO2Update.Visible = false;
				this.m_lblRadarDevice2RunTimeLODist3.Visible = false;
				this.m_lblRadarDevice3RunTimeTxPower2.Visible = false;
				this.m_lblRadarDevice3RunTimeRxGain2.Visible = false;
				this.m_lblRadarDevice3RunTimeTemp.Visible = false;
				this.m_lblRadarDevice3RunTimeTimeStamp.Visible = false;
				this.m_lblRadarDevice4RunTimeApllcalStatus.Visible = false;
				this.m_lblrRadarDevice4RunTimeVCO.Visible = false;
				this.m_lblrRadarDevice4RunTimeVCO2.Visible = false;
				this.m_lblRadarDevice4RunTimeLODist.Visible = false;
				this.m_lblRadarDevice4RunTimeTxPower.Visible = false;
				this.m_lblRadarDevice4RunTimeRxGain.Visible = false;
				this.m_lblRadarDevice4RunTimeApllcalStatus4.Visible = false;
				this.f00014a.Visible = false;
				this.m_lblrRadarDevice4RunTimeVCO2Update.Visible = false;
				this.m_lblRadarDevice2RunTimeLODist4.Visible = false;
				this.m_lblRadarDevice4RunTimeTxPower2.Visible = false;
				this.m_lblRadarDevice4RunTimeRxGain2.Visible = false;
				this.m_lblRadarDevice4RunTimeTemp.Visible = false;
				this.m_lblRadarDevice4RunTimeTimeStamp.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 2)
			{
				this.m_lblRunTimeApllcalStatus.Visible = true;
				this.m_lblRunTimeVCO.Visible = true;
				this.m_lblRunTimeVCO2.Visible = true;
				this.m_lblRunTimeLODist.Visible = true;
				this.m_lblRunTimeTxPower.Visible = true;
				this.m_lblRunTimeRxGain.Visible = true;
				this.m_lblRunTimeApllcalStatus2.Visible = true;
				this.m_lblRunTimeVCO22.Visible = true;
				this.m_lblRunTimeVCO2Update.Visible = true;
				this.m_lblRunTimeLODist2.Visible = true;
				this.m_lblRunTimeTxPower2.Visible = true;
				this.m_lblRunTimeRxGain2.Visible = true;
				this.m_lblRunTimeTemp.Visible = true;
				this.m_lblRunTimeTimeStamp.Visible = true;
				this.m_lblRadarDevice2RunTimeApllcalStatus.Visible = true;
				this.m_lblrRadarDevice2RunTimeVCO.Visible = true;
				this.m_lblrRadarDevice2RunTimeVCO2.Visible = true;
				this.m_lblRadarDevice2RunTimeLODist.Visible = true;
				this.m_lblRadarDevice2RunTimeTxPower.Visible = true;
				this.m_lblRadarDevice2RunTimeRxGain.Visible = true;
				this.m_lblRadarDevice2RunTimeApllcalStatus2.Visible = true;
				this.f00014c.Visible = true;
				this.m_lblrRadarDevice2RunTimeVCO2Update.Visible = true;
				this.m_lblRadarDevice2RunTimeLODist2.Visible = true;
				this.m_lblRadarDevice2RunTimeTxPower2.Visible = true;
				this.m_lblRadarDevice2RunTimeRxGain2.Visible = true;
				this.m_lblRadarDevice2RunTimeTemp.Visible = true;
				this.m_lblRadarDevice2RunTimeTimeStamp.Visible = true;
				this.m_lblRadarDevice3RunTimeApllcalStatus.Visible = false;
				this.m_lblrRadarDevice3RunTimeVCO.Visible = false;
				this.m_lblrRadarDevice3RunTimeVCO2.Visible = false;
				this.m_lblRadarDevice3RunTimeLODist.Visible = false;
				this.m_lblRadarDevice3RunTimeTxPower.Visible = false;
				this.m_lblRadarDevice3RunTimeRxGain.Visible = false;
				this.m_lblRadarDevice3RunTimeApllcalStatus3.Visible = false;
				this.f00014b.Visible = false;
				this.m_lblrRadarDevice3RunTimeVCO2Update.Visible = false;
				this.m_lblRadarDevice2RunTimeLODist3.Visible = false;
				this.m_lblRadarDevice3RunTimeTxPower2.Visible = false;
				this.m_lblRadarDevice3RunTimeRxGain2.Visible = false;
				this.m_lblRadarDevice3RunTimeTemp.Visible = false;
				this.m_lblRadarDevice3RunTimeTimeStamp.Visible = false;
				this.m_lblRadarDevice4RunTimeApllcalStatus.Visible = false;
				this.m_lblrRadarDevice4RunTimeVCO.Visible = false;
				this.m_lblrRadarDevice4RunTimeVCO2.Visible = false;
				this.m_lblRadarDevice4RunTimeLODist.Visible = false;
				this.m_lblRadarDevice4RunTimeTxPower.Visible = false;
				this.m_lblRadarDevice4RunTimeRxGain.Visible = false;
				this.m_lblRadarDevice4RunTimeApllcalStatus4.Visible = false;
				this.f00014a.Visible = false;
				this.m_lblrRadarDevice4RunTimeVCO2Update.Visible = false;
				this.m_lblRadarDevice2RunTimeLODist4.Visible = false;
				this.m_lblRadarDevice4RunTimeTxPower2.Visible = false;
				this.m_lblRadarDevice4RunTimeRxGain2.Visible = false;
				this.m_lblRadarDevice4RunTimeTemp.Visible = false;
				this.m_lblRadarDevice4RunTimeTimeStamp.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 4)
			{
				this.m_lblRunTimeApllcalStatus.Visible = true;
				this.m_lblRunTimeVCO.Visible = true;
				this.m_lblRunTimeVCO2.Visible = true;
				this.m_lblRunTimeLODist.Visible = true;
				this.m_lblRunTimeTxPower.Visible = true;
				this.m_lblRunTimeRxGain.Visible = true;
				this.m_lblRunTimeApllcalStatus2.Visible = true;
				this.m_lblRunTimeVCO22.Visible = true;
				this.m_lblRunTimeVCO2Update.Visible = true;
				this.m_lblRunTimeLODist2.Visible = true;
				this.m_lblRunTimeTxPower2.Visible = true;
				this.m_lblRunTimeRxGain2.Visible = true;
				this.m_lblRunTimeTemp.Visible = true;
				this.m_lblRunTimeTimeStamp.Visible = true;
				this.m_lblRadarDevice2RunTimeApllcalStatus.Visible = true;
				this.m_lblrRadarDevice2RunTimeVCO.Visible = true;
				this.m_lblrRadarDevice2RunTimeVCO2.Visible = true;
				this.m_lblRadarDevice2RunTimeLODist.Visible = true;
				this.m_lblRadarDevice2RunTimeTxPower.Visible = true;
				this.m_lblRadarDevice2RunTimeRxGain.Visible = true;
				this.m_lblRadarDevice2RunTimeApllcalStatus2.Visible = true;
				this.f00014c.Visible = true;
				this.m_lblrRadarDevice2RunTimeVCO2Update.Visible = true;
				this.m_lblRadarDevice2RunTimeLODist2.Visible = true;
				this.m_lblRadarDevice2RunTimeTxPower2.Visible = true;
				this.m_lblRadarDevice2RunTimeRxGain2.Visible = true;
				this.m_lblRadarDevice2RunTimeTemp.Visible = true;
				this.m_lblRadarDevice2RunTimeTimeStamp.Visible = true;
				this.m_lblRadarDevice3RunTimeApllcalStatus.Visible = true;
				this.m_lblrRadarDevice3RunTimeVCO.Visible = true;
				this.m_lblrRadarDevice3RunTimeVCO2.Visible = true;
				this.m_lblRadarDevice3RunTimeLODist.Visible = true;
				this.m_lblRadarDevice3RunTimeTxPower.Visible = true;
				this.m_lblRadarDevice3RunTimeRxGain.Visible = true;
				this.m_lblRadarDevice3RunTimeApllcalStatus3.Visible = true;
				this.f00014b.Visible = true;
				this.m_lblrRadarDevice3RunTimeVCO2Update.Visible = true;
				this.m_lblRadarDevice2RunTimeLODist3.Visible = true;
				this.m_lblRadarDevice3RunTimeTxPower2.Visible = true;
				this.m_lblRadarDevice3RunTimeRxGain2.Visible = true;
				this.m_lblRadarDevice3RunTimeTemp.Visible = true;
				this.m_lblRadarDevice3RunTimeTimeStamp.Visible = true;
				this.m_lblRadarDevice4RunTimeApllcalStatus.Visible = true;
				this.m_lblrRadarDevice4RunTimeVCO.Visible = true;
				this.m_lblrRadarDevice4RunTimeVCO2.Visible = true;
				this.m_lblRadarDevice4RunTimeLODist.Visible = true;
				this.m_lblRadarDevice4RunTimeTxPower.Visible = true;
				this.m_lblRadarDevice4RunTimeRxGain.Visible = true;
				this.m_lblRadarDevice4RunTimeApllcalStatus4.Visible = true;
				this.f00014a.Visible = true;
				this.m_lblrRadarDevice4RunTimeVCO2Update.Visible = true;
				this.m_lblRadarDevice2RunTimeLODist4.Visible = true;
				this.m_lblRadarDevice4RunTimeTxPower2.Visible = true;
				this.m_lblRadarDevice4RunTimeRxGain2.Visible = true;
				this.m_lblRadarDevice4RunTimeTemp.Visible = true;
				this.m_lblRadarDevice4RunTimeTimeStamp.Visible = true;
				return;
			}
			this.m_lblRunTimeApllcalStatus.Visible = false;
			this.m_lblRunTimeVCO.Visible = false;
			this.m_lblRunTimeVCO2.Visible = false;
			this.m_lblRunTimeLODist.Visible = false;
			this.m_lblRunTimeTxPower.Visible = false;
			this.m_lblRunTimeRxGain.Visible = false;
			this.m_lblRunTimeApllcalStatus2.Visible = false;
			this.m_lblRunTimeVCO22.Visible = false;
			this.m_lblRunTimeVCO2Update.Visible = false;
			this.m_lblRunTimeLODist2.Visible = false;
			this.m_lblRunTimeTxPower2.Visible = false;
			this.m_lblRunTimeRxGain2.Visible = false;
			this.m_lblRunTimeTemp.Visible = false;
			this.m_lblRunTimeTimeStamp.Visible = false;
			this.m_lblRadarDevice2RunTimeApllcalStatus.Visible = false;
			this.m_lblrRadarDevice2RunTimeVCO.Visible = false;
			this.m_lblrRadarDevice2RunTimeVCO2.Visible = false;
			this.m_lblRadarDevice2RunTimeLODist.Visible = false;
			this.m_lblRadarDevice2RunTimeTxPower.Visible = false;
			this.m_lblRadarDevice2RunTimeRxGain.Visible = false;
			this.m_lblRadarDevice2RunTimeApllcalStatus2.Visible = false;
			this.f00014c.Visible = false;
			this.m_lblrRadarDevice2RunTimeVCO2Update.Visible = false;
			this.m_lblRadarDevice2RunTimeLODist2.Visible = false;
			this.m_lblRadarDevice2RunTimeTxPower2.Visible = false;
			this.m_lblRadarDevice2RunTimeRxGain2.Visible = false;
			this.m_lblRadarDevice2RunTimeTemp.Visible = false;
			this.m_lblRadarDevice2RunTimeTimeStamp.Visible = false;
			this.m_lblRadarDevice3RunTimeApllcalStatus.Visible = false;
			this.m_lblrRadarDevice3RunTimeVCO.Visible = false;
			this.m_lblrRadarDevice3RunTimeVCO2.Visible = false;
			this.m_lblRadarDevice3RunTimeLODist.Visible = false;
			this.m_lblRadarDevice3RunTimeTxPower.Visible = false;
			this.m_lblRadarDevice3RunTimeRxGain.Visible = false;
			this.m_lblRadarDevice3RunTimeApllcalStatus3.Visible = false;
			this.f00014b.Visible = false;
			this.m_lblrRadarDevice3RunTimeVCO2Update.Visible = false;
			this.m_lblRadarDevice2RunTimeLODist3.Visible = false;
			this.m_lblRadarDevice3RunTimeTxPower2.Visible = false;
			this.m_lblRadarDevice3RunTimeRxGain2.Visible = false;
			this.m_lblRadarDevice3RunTimeTemp.Visible = false;
			this.m_lblRadarDevice3RunTimeTimeStamp.Visible = false;
			this.m_lblRadarDevice4RunTimeApllcalStatus.Visible = false;
			this.m_lblrRadarDevice4RunTimeVCO.Visible = false;
			this.m_lblrRadarDevice4RunTimeVCO2.Visible = false;
			this.m_lblRadarDevice4RunTimeLODist.Visible = false;
			this.m_lblRadarDevice4RunTimeTxPower.Visible = false;
			this.m_lblRadarDevice4RunTimeRxGain.Visible = false;
			this.m_lblRadarDevice4RunTimeApllcalStatus4.Visible = false;
			this.f00014a.Visible = false;
			this.m_lblrRadarDevice4RunTimeVCO2Update.Visible = false;
			this.m_lblRadarDevice2RunTimeLODist4.Visible = false;
			this.m_lblRadarDevice4RunTimeTxPower2.Visible = false;
			this.m_lblRadarDevice4RunTimeRxGain2.Visible = false;
			this.m_lblRadarDevice4RunTimeTemp.Visible = false;
			this.m_lblRadarDevice4RunTimeTimeStamp.Visible = false;
		}

		public void ResetTheRunTimeReportOfRadarDevice1Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheRunTimeReportOfRadarDevice1Status);
				base.Invoke(method);
				return;
			}
			this.m_lblRunTimeApllcalStatus.Text = "F";
			this.m_lblRunTimeApllcalStatus.ForeColor = Color.Red;
			this.m_lblRunTimeVCO.Text = "F";
			this.m_lblRunTimeVCO.ForeColor = Color.Red;
			this.m_lblRunTimeVCO2.Text = "F";
			this.m_lblRunTimeVCO2.ForeColor = Color.Red;
			this.m_lblRunTimeLODist.Text = "F";
			this.m_lblRunTimeLODist.ForeColor = Color.Red;
			this.m_lblRunTimePDCal.Text = "F";
			this.m_lblRunTimePDCal.ForeColor = Color.Red;
			this.m_lblRunTimeTxPower.Text = "F";
			this.m_lblRunTimeTxPower.ForeColor = Color.Red;
			this.m_lblRunTimeRxGain.Text = "F";
			this.m_lblRunTimeRxGain.ForeColor = Color.Red;
			this.m_lblRunTimeApllcalStatus2.Text = "N";
			this.m_lblRunTimeApllcalStatus2.ForeColor = Color.Red;
			this.m_lblRunTimeVCO22.Text = "N";
			this.m_lblRunTimeVCO22.ForeColor = Color.Red;
			this.m_lblRunTimeVCO2Update.Text = "N";
			this.m_lblRunTimeVCO2Update.ForeColor = Color.Red;
			this.m_lblRunTimeLODist2.Text = "N";
			this.m_lblRunTimeLODist2.ForeColor = Color.Red;
			this.m_lblRunTimePDCal2.Text = "N";
			this.m_lblRunTimePDCal2.ForeColor = Color.Red;
			this.m_lblRunTimeTxPower2.Text = "N";
			this.m_lblRunTimeTxPower2.ForeColor = Color.Red;
			this.m_lblRunTimeRxGain2.Text = "N";
			this.m_lblRunTimeRxGain2.ForeColor = Color.Red;
			this.m_lblRunTimeTemp.Text = "0";
			this.m_lblRunTimeTimeStamp.Text = "0";
		}

		public void ResetTheRunTimeReportOfRadarDevice2Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheRunTimeReportOfRadarDevice2Status);
				base.Invoke(method);
				return;
			}
			this.m_lblRadarDevice2RunTimeApllcalStatus.Text = "F";
			this.m_lblrRadarDevice2RunTimeVCO.Text = "F";
			this.m_lblrRadarDevice2RunTimeVCO2.Text = "F";
			this.m_lblRadarDevice2RunTimeLODist.Text = "F";
			this.m_lblRadarDevice2RunTimeTxPower.Text = "F";
			this.m_lblRadarDevice2RunTimeRxGain.Text = "F";
			this.m_lblRadarDevice2RunTimeApllcalStatus2.Text = "N";
			this.f00014c.Text = "N";
			this.m_lblrRadarDevice2RunTimeVCO2Update.Text = "N";
			this.m_lblRadarDevice2RunTimeLODist2.Text = "N";
			this.m_lblRadarDevice2RunTimeTxPower2.Text = "N";
			this.m_lblRadarDevice2RunTimeRxGain2.Text = "N";
			this.m_lblRadarDevice2RunTimeTemp.Text = "0";
			this.m_lblRadarDevice2RunTimeTimeStamp.Text = "0";
		}

		public void ResetTheRunTimeReportOfRadarDevice3Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheRunTimeReportOfRadarDevice3Status);
				base.Invoke(method);
				return;
			}
			this.m_lblRadarDevice3RunTimeApllcalStatus.Text = "F";
			this.m_lblrRadarDevice3RunTimeVCO.Text = "F";
			this.m_lblrRadarDevice3RunTimeVCO2.Text = "F";
			this.m_lblRadarDevice3RunTimeLODist.Text = "F";
			this.m_lblRadarDevice3RunTimeTxPower.Text = "F";
			this.m_lblRadarDevice3RunTimeRxGain.Text = "F";
			this.m_lblRadarDevice3RunTimeApllcalStatus3.Text = "N";
			this.f00014b.Text = "N";
			this.m_lblrRadarDevice3RunTimeVCO2Update.Text = "N";
			this.m_lblRadarDevice2RunTimeLODist3.Text = "N";
			this.m_lblRadarDevice3RunTimeTxPower2.Text = "N";
			this.m_lblRadarDevice3RunTimeRxGain2.Text = "N";
			this.m_lblRadarDevice3RunTimeTemp.Text = "0";
			this.m_lblRadarDevice3RunTimeTimeStamp.Text = "0";
		}

		public void ResetTheRunTimeReportOfRadarDevice4Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheRunTimeReportOfRadarDevice4Status);
				base.Invoke(method);
				return;
			}
			this.m_lblRadarDevice4RunTimeApllcalStatus.Text = "F";
			this.m_lblrRadarDevice4RunTimeVCO.Text = "F";
			this.m_lblrRadarDevice4RunTimeVCO2.Text = "F";
			this.m_lblRadarDevice4RunTimeLODist.Text = "F";
			this.m_lblRadarDevice4RunTimeTxPower.Text = "F";
			this.m_lblRadarDevice4RunTimeRxGain.Text = "F";
			this.m_lblRadarDevice4RunTimeApllcalStatus4.Text = "N";
			this.f00014a.Text = "N";
			this.m_lblrRadarDevice4RunTimeVCO2Update.Text = "N";
			this.m_lblRadarDevice2RunTimeLODist4.Text = "N";
			this.m_lblRadarDevice4RunTimeTxPower2.Text = "N";
			this.m_lblRadarDevice4RunTimeRxGain2.Text = "N";
			this.m_lblRadarDevice4RunTimeTemp.Text = "0";
			this.m_lblRadarDevice4RunTimeTimeStamp.Text = "0";
		}

		public uint RFTimeUnitStatusReport(uint RadarDeviceId, ushort TimingFailureCode)
		{
			if (base.InvokeRequired)
			{
				del_b_u method = new del_b_u(this.RFTimeUnitStatusReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					TimingFailureCode
				});
			}
			else if (RadarDeviceId == 1U)
			{
				if ((TimingFailureCode >> 1 & 1) == 1)
				{
					this.m_lblTotalMonAndCalibTimeFit.Text = "F";
					this.m_lblTotalMonAndCalibTimeFit.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblTotalMonAndCalibTimeFit.Text = "P";
					this.m_lblTotalMonAndCalibTimeFit.ForeColor = Color.Green;
				}
				if ((TimingFailureCode >> 2 & 1) == 1)
				{
					this.m_lblPeriodicMonAndCalibTimeFit.Text = "F";
					this.m_lblPeriodicMonAndCalibTimeFit.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblPeriodicMonAndCalibTimeFit.Text = "P";
					this.m_lblPeriodicMonAndCalibTimeFit.ForeColor = Color.Green;
				}
				if ((TimingFailureCode >> 3 & 1) == 1)
				{
					this.m_lblRunTimingViolation.Text = "F";
					this.m_lblRunTimingViolation.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblRunTimingViolation.Text = "P";
					this.m_lblRunTimingViolation.ForeColor = Color.Green;
				}
			}
			return 0U;
		}

		public uint CascadeRFTimeUnitStatusReport(uint RadarDeviceId, ushort TimingFailureCode)
		{
			if (base.InvokeRequired)
			{
				del_b_u method = new del_b_u(this.CascadeRFTimeUnitStatusReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					TimingFailureCode
				});
			}
			else if (RadarDeviceId == 0U)
			{
				if ((TimingFailureCode >> 1 & 1) == 1)
				{
					this.m_lblTotalMonAndCalibTimeFit.Text = "F";
					this.m_lblTotalMonAndCalibTimeFit.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblTotalMonAndCalibTimeFit.Text = "P";
					this.m_lblTotalMonAndCalibTimeFit.ForeColor = Color.Green;
				}
				if ((TimingFailureCode >> 2 & 1) == 1)
				{
					this.m_lblPeriodicMonAndCalibTimeFit.Text = "F";
					this.m_lblPeriodicMonAndCalibTimeFit.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblPeriodicMonAndCalibTimeFit.Text = "P";
					this.m_lblPeriodicMonAndCalibTimeFit.ForeColor = Color.Green;
				}
				if ((TimingFailureCode >> 3 & 1) == 1)
				{
					this.m_lblRunTimingViolation.Text = "F";
					this.m_lblRunTimingViolation.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblRunTimingViolation.Text = "P";
					this.m_lblRunTimingViolation.ForeColor = Color.Green;
				}
			}
			else if (RadarDeviceId == 1U)
			{
				if ((TimingFailureCode >> 1 & 1) == 1)
				{
					this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Text = "F";
					this.m_lblRadarDevice2TotalMonAndCalibTimeFit.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Text = "P";
					this.m_lblRadarDevice2TotalMonAndCalibTimeFit.ForeColor = Color.Green;
				}
				if ((TimingFailureCode >> 2 & 1) == 1)
				{
					this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Text = "F";
					this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Text = "P";
					this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.ForeColor = Color.Green;
				}
				if ((TimingFailureCode >> 3 & 1) == 1)
				{
					this.m_lblRadarDevice2RunTimingViolation.Text = "F";
					this.m_lblRadarDevice2RunTimingViolation.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblRadarDevice2RunTimingViolation.Text = "P";
					this.m_lblRadarDevice2RunTimingViolation.ForeColor = Color.Green;
				}
			}
			else if (RadarDeviceId == 2U)
			{
				if ((TimingFailureCode >> 1 & 1) == 1)
				{
					this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Text = "F";
					this.m_lblRadarDevice3TotalMonAndCalibTimeFit.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Text = "P";
					this.m_lblRadarDevice3TotalMonAndCalibTimeFit.ForeColor = Color.Green;
				}
				if ((TimingFailureCode >> 2 & 1) == 1)
				{
					this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Text = "F";
					this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Text = "P";
					this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.ForeColor = Color.Green;
				}
				if ((TimingFailureCode >> 3 & 1) == 1)
				{
					this.m_lblRadarDevice3RunTimingViolation.Text = "F";
					this.m_lblRadarDevice3RunTimingViolation.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblRadarDevice3RunTimingViolation.Text = "P";
					this.m_lblRadarDevice3RunTimingViolation.ForeColor = Color.Green;
				}
			}
			else if (RadarDeviceId == 3U)
			{
				if ((TimingFailureCode >> 1 & 1) == 1)
				{
					this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Text = "F";
					this.m_lblRadarDevice4TotalMonAndCalibTimeFit.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Text = "P";
					this.m_lblRadarDevice4TotalMonAndCalibTimeFit.ForeColor = Color.Green;
				}
				if ((TimingFailureCode >> 2 & 1) == 1)
				{
					this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Text = "F";
					this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Text = "P";
					this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.ForeColor = Color.Green;
				}
				if ((TimingFailureCode >> 3 & 1) == 1)
				{
					this.m_lblRadarDevice4RunTimingViolation.Text = "F";
					this.m_lblRadarDevice4RunTimingViolation.ForeColor = Color.Red;
				}
				else
				{
					this.m_lblRadarDevice4RunTimingViolation.Text = "P";
					this.m_lblRadarDevice4RunTimingViolation.ForeColor = Color.Green;
				}
			}
			return 0U;
		}

		public void EnableDisbleTimeUnitStatusReportWithRespectiveRadarDevices(ushort numberOfRadarDevicesDetected)
		{
			if (numberOfRadarDevicesDetected == 1)
			{
				this.m_lblTotalMonTimeFit.Visible = false;
				this.m_lblTotalMonAndCalibTimeFit.Visible = true;
				this.m_lblRunTimingViolation.Visible = true;
				this.m_lblPeriodicMonAndCalibTimeFit.Visible = true;
				this.m_lblRadarDevice2TotalMonTimeFit.Visible = false;
				this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Visible = false;
				this.m_lblRadarDevice2RunTimingViolation.Visible = false;
				this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Visible = false;
				this.m_lblRadarDevice3TotalMonTimeFit.Visible = false;
				this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Visible = false;
				this.m_lblRadarDevice3RunTimingViolation.Visible = false;
				this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Visible = false;
				this.m_lblRadarDevice4TotalMonTimeFit.Visible = false;
				this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Visible = false;
				this.m_lblRadarDevice4RunTimingViolation.Visible = false;
				this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 2)
			{
				this.m_lblTotalMonTimeFit.Visible = false;
				this.m_lblTotalMonAndCalibTimeFit.Visible = true;
				this.m_lblRunTimingViolation.Visible = true;
				this.m_lblPeriodicMonAndCalibTimeFit.Visible = true;
				this.m_lblRadarDevice2TotalMonTimeFit.Visible = false;
				this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Visible = true;
				this.m_lblRadarDevice2RunTimingViolation.Visible = true;
				this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Visible = true;
				this.m_lblRadarDevice3TotalMonTimeFit.Visible = false;
				this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Visible = false;
				this.m_lblRadarDevice3RunTimingViolation.Visible = false;
				this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Visible = false;
				this.m_lblRadarDevice4TotalMonTimeFit.Visible = false;
				this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Visible = false;
				this.m_lblRadarDevice4RunTimingViolation.Visible = false;
				this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 4)
			{
				this.m_lblTotalMonTimeFit.Visible = false;
				this.m_lblTotalMonAndCalibTimeFit.Visible = true;
				this.m_lblRunTimingViolation.Visible = true;
				this.m_lblPeriodicMonAndCalibTimeFit.Visible = true;
				this.m_lblRadarDevice2TotalMonTimeFit.Visible = false;
				this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Visible = true;
				this.m_lblRadarDevice2RunTimingViolation.Visible = true;
				this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Visible = true;
				this.m_lblRadarDevice3TotalMonTimeFit.Visible = false;
				this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Visible = true;
				this.m_lblRadarDevice3RunTimingViolation.Visible = true;
				this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Visible = true;
				this.m_lblRadarDevice4TotalMonTimeFit.Visible = false;
				this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Visible = true;
				this.m_lblRadarDevice4RunTimingViolation.Visible = true;
				this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Visible = true;
				return;
			}
			this.m_lblTotalMonTimeFit.Visible = false;
			this.m_lblTotalMonAndCalibTimeFit.Visible = false;
			this.m_lblRunTimingViolation.Visible = false;
			this.m_lblPeriodicMonAndCalibTimeFit.Visible = false;
			this.m_lblRadarDevice2TotalMonTimeFit.Visible = false;
			this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Visible = false;
			this.m_lblRadarDevice2RunTimingViolation.Visible = false;
			this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Visible = false;
			this.m_lblRadarDevice3TotalMonTimeFit.Visible = false;
			this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Visible = false;
			this.m_lblRadarDevice3RunTimingViolation.Visible = false;
			this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Visible = false;
			this.m_lblRadarDevice4TotalMonTimeFit.Visible = false;
			this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Visible = false;
			this.m_lblRadarDevice4RunTimingViolation.Visible = false;
			this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Visible = false;
		}

		public void ResetTheTimeUnitReportOfRadarDevice1Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheTimeUnitReportOfRadarDevice1Status);
				base.Invoke(method);
				return;
			}
			this.m_lblTotalMonTimeFit.Text = "P";
			this.m_lblTotalMonTimeFit.ForeColor = Color.Green;
			this.m_lblTotalMonAndCalibTimeFit.Text = "P";
			this.m_lblTotalMonAndCalibTimeFit.ForeColor = Color.Green;
			this.m_lblRunTimingViolation.Text = "P";
			this.m_lblRunTimingViolation.ForeColor = Color.Green;
			this.m_lblPeriodicMonAndCalibTimeFit.Text = "P";
			this.m_lblPeriodicMonAndCalibTimeFit.ForeColor = Color.Green;
		}

		public void ResetTheTimeUnitReportOfRadarDevice2Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheTimeUnitReportOfRadarDevice2Status);
				base.Invoke(method);
				return;
			}
			this.m_lblRadarDevice2TotalMonTimeFit.Text = "F";
			this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Text = "F";
			this.m_lblRadarDevice2RunTimingViolation.Text = "F";
			this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Text = "F";
		}

		public void ResetTheTimeUnitReportOfRadarDevice3Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheTimeUnitReportOfRadarDevice3Status);
				base.Invoke(method);
				return;
			}
			this.m_lblRadarDevice3TotalMonTimeFit.Text = "F";
			this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Text = "F";
			this.m_lblRadarDevice3RunTimingViolation.Text = "F";
			this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Text = "F";
		}

		public void ResetTheTimeUnitReportOfRadarDevice4Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.ResetTheTimeUnitReportOfRadarDevice4Status);
				base.Invoke(method);
				return;
			}
			this.m_lblRadarDevice4TotalMonTimeFit.Text = "F";
			this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Text = "F";
			this.m_lblRadarDevice4RunTimingViolation.Text = "F";
			this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Text = "F";
		}

		public int DisableMonitoringLogging(uint mode)
		{
			if (base.InvokeRequired)
			{
				del_i_u method = new del_i_u(this.DisableMonitoringLogging);
				return (int)base.Invoke(method, new object[]
				{
					mode
				});
			}
			string full_command = string.Format("ar1.DisableMonitoringLogging({0})", mode);
			this.m_GuiManager.RecordLog(0, full_command);
			string full_command2 = string.Format("Status: Passed", new object[0]);
			this.m_GuiManager.RecordLog(0, full_command2);
			if (mode == 1U)
			{
				this.m_chkDisableLogging.Checked = true;
				GlobalRef.g_DisableReportLogging = true;
			}
			else if (mode == 0U)
			{
				this.m_chkDisableLogging.Checked = false;
				GlobalRef.g_DisableReportLogging = false;
			}
			return 0;
		}

		private void m00000b(object sender, EventArgs p1)
		{
		}

		private void CalibConfig_Load(object sender, EventArgs p1)
		{
		}

		private void m_grpRFInitCalibReportCfg_Enter(object sender, EventArgs p1)
		{
		}

		private void label11_Click(object sender, EventArgs p1)
		{
		}

		private void label42_Click(object sender, EventArgs p1)
		{
		}

		private void label41_Click(object sender, EventArgs p1)
		{
		}

		private void m_chkDisableLogging_CheckedChanged(object sender, EventArgs p1)
		{
			if (this.m_chkDisableLogging.Checked)
			{
				GlobalRef.g_DisableReportLogging = true;
				return;
			}
			GlobalRef.g_DisableReportLogging = false;
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
			this.m_grpTimeUnitCfg = new GroupBox();
			this.m_nudDeviceId = new NumericUpDown();
			this.m_nudNumCascadeDev = new NumericUpDown();
			this.m_nudTimeUnit = new NumericUpDown();
			this.m_btnTimeUnitSet = new Button();
			this.m_lblDeviceId = new Label();
			this.m_lblNumOfCasCadeDev = new Label();
			this.m_lblCalibMonTimeUnit = new Label();
			this.m_grpTimeUnitReportCfg = new GroupBox();
			this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit = new Label();
			this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit = new Label();
			this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit = new Label();
			this.m_lblPeriodicMonAndCalibTimeFit = new Label();
			this.label12 = new Label();
			this.m_lblRadarDevice4RunTimingViolation = new Label();
			this.m_lblRadarDevice3RunTimingViolation = new Label();
			this.m_lblRadarDevice2RunTimingViolation = new Label();
			this.m_lblRunTimingViolation = new Label();
			this.m_lblRadarDevice4TotalMonAndCalibTimeFit = new Label();
			this.m_lblRadarDevice3TotalMonAndCalibTimeFit = new Label();
			this.m_lblRadarDevice2TotalMonAndCalibTimeFit = new Label();
			this.m_lblTotalMonAndCalibTimeFit = new Label();
			this.m_lblRadarDevice4TotalMonTimeFit = new Label();
			this.m_lblRadarDevice3TotalMonTimeFit = new Label();
			this.m_lblRadarDevice2TotalMonTimeFit = new Label();
			this.m_lblTotalMonTimeFit = new Label();
			this.label21 = new Label();
			this.label20 = new Label();
			this.m_grpRFInitCalibCfg = new GroupBox();
			this.m_chkTxPhase = new CheckBox();
			this.m_btnRFInitCalibSet = new Button();
			this.m_chkRxGain = new CheckBox();
			this.m_chkTxPower = new CheckBox();
			this.m_chkPeakDetector = new CheckBox();
			this.m_chkLPFCutoff = new CheckBox();
			this.f000130 = new CheckBox();
			this.m_chkHPFCutoff = new CheckBox();
			this.f000131 = new CheckBox();
			this.m_chkLODist = new CheckBox();
			this.label4 = new Label();
			this.m_grpRFInitCalibReportCfg = new GroupBox();
			this.m_lblRadarDevice4TxPhaseUpdate = new Label();
			this.m_lblRadarDevice4TxPhase = new Label();
			this.m_lblRadarDevice3TxPhaseUpdate = new Label();
			this.m_lblRadarDevice3TxPhase = new Label();
			this.m_lblRadarDevice2TxPhaseUpdate = new Label();
			this.m_lblRadarDevice2TxPhase = new Label();
			this.m_lblTxPhaseUpdate = new Label();
			this.m_lblTxPhase = new Label();
			this.label19 = new Label();
			this.m_lblRadarDevice4TimeStamp = new Label();
			this.m_lblRadarDevice4Temperature = new Label();
			this.m_lblRadarDevice3TimeStamp = new Label();
			this.m_lblRadarDevice3Temperature = new Label();
			this.m_lblRadarDevice2TimeStamp = new Label();
			this.m_lblRadarDevice2Temperature = new Label();
			this.f00014d = new Label();
			this.m_lblRadarDevice4RxGainUpdate = new Label();
			this.m_lblRadarDevice4RFTxPowerUpdate = new Label();
			this.m_lblRadarDevice4PeakDetectorUpdate = new Label();
			this.f00014e = new Label();
			this.f00014f = new Label();
			this.f000150 = new Label();
			this.m_lblRadarDevice4RFInitLODistUpdate = new Label();
			this.f000151 = new Label();
			this.f000152 = new Label();
			this.m_lblRadarDevice4RFInitApllcalUpdate = new Label();
			this.f000153 = new Label();
			this.m_lblRadarDevice3RxGainUpdate = new Label();
			this.m_lblRadarDevice3RFTxPowerUpdate = new Label();
			this.m_lblRadarDevice3PeakDetectorUpdate = new Label();
			this.f000154 = new Label();
			this.f000155 = new Label();
			this.f000156 = new Label();
			this.m_lblRadarDevice3RFInitLODistUpdate = new Label();
			this.f000157 = new Label();
			this.f000158 = new Label();
			this.m_lblRadarDevice3RFInitApllcalUpdate = new Label();
			this.f000159 = new Label();
			this.m_lblRadarDevice2RxGainUpdate = new Label();
			this.m_lblRadarDevice2RFTxPowerUpdate = new Label();
			this.m_lblRadarDevice2PeakDetectorUpdate = new Label();
			this.f00015a = new Label();
			this.f00015b = new Label();
			this.f00015c = new Label();
			this.m_lblRadarDevice2RFInitLODistUpdate = new Label();
			this.f00015d = new Label();
			this.f00015e = new Label();
			this.m_lblRadarDevice2RFInitApllcalUpdate = new Label();
			this.f00015f = new Label();
			this.m_lblRxGainUpdate = new Label();
			this.m_lblRFTxPowerUpdate = new Label();
			this.m_lblPeakDetectorUpdate = new Label();
			this.f000160 = new Label();
			this.f000161 = new Label();
			this.f000162 = new Label();
			this.f000163 = new Label();
			this.f000164 = new Label();
			this.f000165 = new Label();
			this.m_lblRFInitApllcalUpdate = new Label();
			this.m_lblTimeStamp = new Label();
			this.m_lblTemperature = new Label();
			this.label62 = new Label();
			this.label61 = new Label();
			this.f000166 = new Label();
			this.f000167 = new Label();
			this.f000168 = new Label();
			this.f000169 = new Label();
			this.m_lblRadarDevice4RxGain = new Label();
			this.m_lblRadarDevice3RxGain = new Label();
			this.m_lblRadarDevice2RxGain = new Label();
			this.m_lblRxGain = new Label();
			this.m_lblRadarDevice4PeakDetector = new Label();
			this.m_lblRadarDevice3PeakDetector = new Label();
			this.m_lblRadarDevice2PeakDetector = new Label();
			this.m_lblPeakDetector = new Label();
			this.lblRadarDevice4Update = new Label();
			this.lblRadarDevice4Status = new Label();
			this.lblRadarDevice3Update = new Label();
			this.lblRadarDevice3Status = new Label();
			this.lblRadarDevice2Update = new Label();
			this.lblRadarDevice2Status = new Label();
			this.label13 = new Label();
			this.label11 = new Label();
			this.label10 = new Label();
			this.label39 = new Label();
			this.label38 = new Label();
			this.f000132 = new Label();
			this.f000133 = new Label();
			this.m_lblRadarDevice4RFTxPower = new Label();
			this.f000134 = new Label();
			this.f000135 = new Label();
			this.f000136 = new Label();
			this.f000137 = new Label();
			this.m_lblRadarDevice4RFInitApllcalStatus = new Label();
			this.f000138 = new Label();
			this.f000139 = new Label();
			this.m_lblRadarDevice3RFTxPower = new Label();
			this.f00013a = new Label();
			this.f00013b = new Label();
			this.f00013c = new Label();
			this.f00013d = new Label();
			this.m_lblRadarDevice3RFInitApllcalStatus = new Label();
			this.f00013e = new Label();
			this.f00013f = new Label();
			this.m_lblRadarDevice2RFTxPower = new Label();
			this.f000140 = new Label();
			this.f000141 = new Label();
			this.f000142 = new Label();
			this.f000143 = new Label();
			this.m_lblRadarDevice2RFInitApllcalStatus = new Label();
			this.f000144 = new Label();
			this.f000145 = new Label();
			this.m_lblRFTxPower = new Label();
			this.f000146 = new Label();
			this.f000147 = new Label();
			this.f000148 = new Label();
			this.f000149 = new Label();
			this.m_lblRFInitApllcalStatus = new Label();
			this.label17 = new Label();
			this.label15 = new Label();
			this.label16 = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.label7 = new Label();
			this.label6 = new Label();
			this.label5 = new Label();
			this.m_grpRunTimeCalibAndTriggerCfg = new GroupBox();
			this.m_chkPeriodicCalibPDCal = new CheckBox();
			this.m_chkOneTimeCalibPDCal = new CheckBox();
			this.m_cboTxPowerCalMode = new ComboBox();
			this.label14 = new Label();
			this.m_chkEnableCalReport = new CheckBox();
			this.m_nudCalibPeriodicity = new NumericUpDown();
			this.m_chkPeriodicCalibRxGain = new CheckBox();
			this.m_chkPeriodicCalibTxPower = new CheckBox();
			this.m_chkPeriodicCalibLODist = new CheckBox();
			this.m_chkOneTimeCalibRxGain = new CheckBox();
			this.m_chkOneTimeCalibTxPower = new CheckBox();
			this.m_chkOneTimeCalibLODist = new CheckBox();
			this.m_btnRunTimeCalibCfgSet = new Button();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.m_grpRunTimeCalibAndTriggerReportCfg = new GroupBox();
			this.m_lblRunTimePDCal2 = new Label();
			this.label40 = new Label();
			this.m_lblRunTimePDCal = new Label();
			this.label18 = new Label();
			this.m_lblRadarDevice4RunTimeTemp = new Label();
			this.m_lblRadarDevice3RunTimeTemp = new Label();
			this.m_lblRadarDevice2RunTimeTemp = new Label();
			this.m_lblRunTimeTemp = new Label();
			this.m_lblRadarDevice4RunTimeTimeStamp = new Label();
			this.m_lblRadarDevice3RunTimeTimeStamp = new Label();
			this.m_lblRadarDevice2RunTimeTimeStamp = new Label();
			this.m_lblRunTimeTimeStamp = new Label();
			this.m_lblRadarDevice4RunTimeRxGain2 = new Label();
			this.m_lblRadarDevice3RunTimeRxGain2 = new Label();
			this.m_lblRadarDevice2RunTimeRxGain2 = new Label();
			this.m_lblRunTimeRxGain2 = new Label();
			this.m_lblRadarDevice4RunTimeTxPower2 = new Label();
			this.m_lblRadarDevice3RunTimeTxPower2 = new Label();
			this.m_lblRadarDevice2RunTimeTxPower2 = new Label();
			this.m_lblRunTimeTxPower2 = new Label();
			this.m_lblRadarDevice2RunTimeLODist4 = new Label();
			this.m_lblRadarDevice2RunTimeLODist3 = new Label();
			this.m_lblRadarDevice2RunTimeLODist2 = new Label();
			this.m_lblRunTimeLODist2 = new Label();
			this.m_lblrRadarDevice4RunTimeVCO2Update = new Label();
			this.m_lblrRadarDevice3RunTimeVCO2Update = new Label();
			this.m_lblrRadarDevice2RunTimeVCO2Update = new Label();
			this.m_lblRunTimeVCO2Update = new Label();
			this.f00014a = new Label();
			this.f00014b = new Label();
			this.f00014c = new Label();
			this.m_lblRunTimeVCO22 = new Label();
			this.m_lblRadarDevice4RunTimeApllcalStatus4 = new Label();
			this.m_lblRadarDevice3RunTimeApllcalStatus3 = new Label();
			this.m_lblRadarDevice2RunTimeApllcalStatus2 = new Label();
			this.m_lblRunTimeApllcalStatus2 = new Label();
			this.m_lblRadarDevice4RunTimeRxGain = new Label();
			this.m_lblRadarDevice3RunTimeRxGain = new Label();
			this.m_lblRadarDevice2RunTimeRxGain = new Label();
			this.m_lblRunTimeRxGain = new Label();
			this.m_lblRadarDevice4RunTimeTxPower = new Label();
			this.m_lblRadarDevice3RunTimeTxPower = new Label();
			this.m_lblRadarDevice2RunTimeTxPower = new Label();
			this.m_lblRunTimeTxPower = new Label();
			this.m_lblRadarDevice4RunTimeLODist = new Label();
			this.m_lblRadarDevice3RunTimeLODist = new Label();
			this.m_lblRadarDevice2RunTimeLODist = new Label();
			this.m_lblRunTimeLODist = new Label();
			this.m_lblrRadarDevice4RunTimeVCO2 = new Label();
			this.m_lblrRadarDevice3RunTimeVCO2 = new Label();
			this.m_lblrRadarDevice2RunTimeVCO2 = new Label();
			this.m_lblRunTimeVCO2 = new Label();
			this.m_lblrRadarDevice4RunTimeVCO = new Label();
			this.m_lblrRadarDevice3RunTimeVCO = new Label();
			this.m_lblrRadarDevice2RunTimeVCO = new Label();
			this.m_lblRunTimeVCO = new Label();
			this.m_lblRadarDevice4RunTimeApllcalStatus = new Label();
			this.m_lblRadarDevice3RunTimeApllcalStatus = new Label();
			this.m_lblRadarDevice2RunTimeApllcalStatus = new Label();
			this.m_lblRunTimeApllcalStatus = new Label();
			this.label37 = new Label();
			this.label36 = new Label();
			this.label35 = new Label();
			this.label34 = new Label();
			this.label33 = new Label();
			this.label32 = new Label();
			this.label31 = new Label();
			this.label30 = new Label();
			this.label29 = new Label();
			this.label28 = new Label();
			this.label27 = new Label();
			this.label26 = new Label();
			this.label25 = new Label();
			this.label24 = new Label();
			this.label23 = new Label();
			this.label22 = new Label();
			this.m_chkDisableLogging = new CheckBox();
			this.m_grpTimeUnitCfg.SuspendLayout();
			((ISupportInitialize)this.m_nudDeviceId).BeginInit();
			((ISupportInitialize)this.m_nudNumCascadeDev).BeginInit();
			((ISupportInitialize)this.m_nudTimeUnit).BeginInit();
			this.m_grpTimeUnitReportCfg.SuspendLayout();
			this.m_grpRFInitCalibCfg.SuspendLayout();
			this.m_grpRFInitCalibReportCfg.SuspendLayout();
			this.m_grpRunTimeCalibAndTriggerCfg.SuspendLayout();
			((ISupportInitialize)this.m_nudCalibPeriodicity).BeginInit();
			this.m_grpRunTimeCalibAndTriggerReportCfg.SuspendLayout();
			base.SuspendLayout();
			this.m_grpTimeUnitCfg.Controls.Add(this.m_chkDisableLogging);
			this.m_grpTimeUnitCfg.Controls.Add(this.m_nudDeviceId);
			this.m_grpTimeUnitCfg.Controls.Add(this.m_nudNumCascadeDev);
			this.m_grpTimeUnitCfg.Controls.Add(this.m_nudTimeUnit);
			this.m_grpTimeUnitCfg.Controls.Add(this.m_btnTimeUnitSet);
			this.m_grpTimeUnitCfg.Controls.Add(this.m_lblDeviceId);
			this.m_grpTimeUnitCfg.Controls.Add(this.m_lblNumOfCasCadeDev);
			this.m_grpTimeUnitCfg.Controls.Add(this.m_lblCalibMonTimeUnit);
			this.m_grpTimeUnitCfg.Location = new Point(17, 30);
			this.m_grpTimeUnitCfg.Margin = new Padding(4, 4, 4, 4);
			this.m_grpTimeUnitCfg.Name = "m_grpTimeUnitCfg";
			this.m_grpTimeUnitCfg.Padding = new Padding(4, 4, 4, 4);
			this.m_grpTimeUnitCfg.Size = new Size(357, 204);
			this.m_grpTimeUnitCfg.TabIndex = 1;
			this.m_grpTimeUnitCfg.TabStop = false;
			this.m_grpTimeUnitCfg.Text = "Time Unit Config";
			this.m_nudDeviceId.Location = new Point(215, 111);
			this.m_nudDeviceId.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudDeviceId = this.m_nudDeviceId;
			int[] array = new int[4];
			array[0] = 3;
			nudDeviceId.Maximum = new decimal(array);
			this.m_nudDeviceId.Name = "m_nudDeviceId";
			this.m_nudDeviceId.Size = new Size(103, 22);
			this.m_nudDeviceId.TabIndex = 6;
			this.m_nudNumCascadeDev.Location = new Point(215, 74);
			this.m_nudNumCascadeDev.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudNumCascadeDev = this.m_nudNumCascadeDev;
			int[] array2 = new int[4];
			array2[0] = 4;
			nudNumCascadeDev.Maximum = new decimal(array2);
			NumericUpDown nudNumCascadeDev2 = this.m_nudNumCascadeDev;
			int[] array3 = new int[4];
			array3[0] = 1;
			nudNumCascadeDev2.Minimum = new decimal(array3);
			this.m_nudNumCascadeDev.Name = "m_nudNumCascadeDev";
			this.m_nudNumCascadeDev.Size = new Size(103, 22);
			this.m_nudNumCascadeDev.TabIndex = 5;
			NumericUpDown nudNumCascadeDev3 = this.m_nudNumCascadeDev;
			int[] array4 = new int[4];
			array4[0] = 1;
			nudNumCascadeDev3.Value = new decimal(array4);
			this.m_nudTimeUnit.Location = new Point(215, 39);
			this.m_nudTimeUnit.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudTimeUnit = this.m_nudTimeUnit;
			int[] array5 = new int[4];
			array5[0] = 1000;
			nudTimeUnit.Maximum = new decimal(array5);
			NumericUpDown nudTimeUnit2 = this.m_nudTimeUnit;
			int[] array6 = new int[4];
			array6[0] = 1;
			nudTimeUnit2.Minimum = new decimal(array6);
			this.m_nudTimeUnit.Name = "m_nudTimeUnit";
			this.m_nudTimeUnit.Size = new Size(103, 22);
			this.m_nudTimeUnit.TabIndex = 4;
			NumericUpDown nudTimeUnit3 = this.m_nudTimeUnit;
			int[] array7 = new int[4];
			array7[0] = 1;
			nudTimeUnit3.Value = new decimal(array7);
			this.m_btnTimeUnitSet.Location = new Point(240, 156);
			this.m_btnTimeUnitSet.Margin = new Padding(4, 4, 4, 4);
			this.m_btnTimeUnitSet.Name = "m_btnTimeUnitSet";
			this.m_btnTimeUnitSet.Size = new Size(100, 34);
			this.m_btnTimeUnitSet.TabIndex = 3;
			this.m_btnTimeUnitSet.Text = "Set";
			this.m_btnTimeUnitSet.UseVisualStyleBackColor = true;
			this.m_btnTimeUnitSet.Click += this.m_btnTimeUnitSet_Click;
			this.m_lblDeviceId.AutoSize = true;
			this.m_lblDeviceId.Location = new Point(21, 111);
			this.m_lblDeviceId.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDeviceId.Name = "m_lblDeviceId";
			this.m_lblDeviceId.Size = new Size(66, 17);
			this.m_lblDeviceId.TabIndex = 2;
			this.m_lblDeviceId.Text = "Device Id";
			this.m_lblNumOfCasCadeDev.AutoSize = true;
			this.m_lblNumOfCasCadeDev.Location = new Point(21, 74);
			this.m_lblNumOfCasCadeDev.Margin = new Padding(4, 0, 4, 0);
			this.m_lblNumOfCasCadeDev.Name = "m_lblNumOfCasCadeDev";
			this.m_lblNumOfCasCadeDev.Size = new Size(111, 17);
			this.m_lblNumOfCasCadeDev.TabIndex = 1;
			this.m_lblNumOfCasCadeDev.Text = "Num of  Devices";
			this.m_lblCalibMonTimeUnit.AutoSize = true;
			this.m_lblCalibMonTimeUnit.Location = new Point(21, 39);
			this.m_lblCalibMonTimeUnit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblCalibMonTimeUnit.Name = "m_lblCalibMonTimeUnit";
			this.m_lblCalibMonTimeUnit.Size = new Size(134, 17);
			this.m_lblCalibMonTimeUnit.TabIndex = 0;
			this.m_lblCalibMonTimeUnit.Text = "Calib Mon Time Unit";
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblPeriodicMonAndCalibTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.label12);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice4RunTimingViolation);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice3RunTimingViolation);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimingViolation);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRunTimingViolation);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice4TotalMonAndCalibTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice3TotalMonAndCalibTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice2TotalMonAndCalibTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblTotalMonAndCalibTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice4TotalMonTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice3TotalMonTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblRadarDevice2TotalMonTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.m_lblTotalMonTimeFit);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.label21);
			this.m_grpTimeUnitReportCfg.Controls.Add(this.label20);
			this.m_grpTimeUnitReportCfg.Location = new Point(12, 245);
			this.m_grpTimeUnitReportCfg.Margin = new Padding(4, 4, 4, 4);
			this.m_grpTimeUnitReportCfg.Name = "m_grpTimeUnitReportCfg";
			this.m_grpTimeUnitReportCfg.Padding = new Padding(4, 4, 4, 4);
			this.m_grpTimeUnitReportCfg.Size = new Size(275, 167);
			this.m_grpTimeUnitReportCfg.TabIndex = 0;
			this.m_grpTimeUnitReportCfg.TabStop = false;
			this.m_grpTimeUnitReportCfg.Text = "Time Unit Failure Report";
			this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.AutoSize = true;
			this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Location = new Point(245, 65);
			this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Name = "m_lblRadarDevice4PeriodicMonAndCalibTimeFit";
			this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Size = new Size(17, 17);
			this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.TabIndex = 32;
			this.m_lblRadarDevice4PeriodicMonAndCalibTimeFit.Text = "P";
			this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.AutoSize = true;
			this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Location = new Point(211, 65);
			this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Name = "m_lblRadarDevice3PeriodicMonAndCalibTimeFit";
			this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Size = new Size(17, 17);
			this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.TabIndex = 31;
			this.m_lblRadarDevice3PeriodicMonAndCalibTimeFit.Text = "P";
			this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.AutoSize = true;
			this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Location = new Point(175, 65);
			this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Name = "m_lblRadarDevice2PeriodicMonAndCalibTimeFit";
			this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Size = new Size(17, 17);
			this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.TabIndex = 30;
			this.m_lblRadarDevice2PeriodicMonAndCalibTimeFit.Text = "P";
			this.m_lblPeriodicMonAndCalibTimeFit.AutoSize = true;
			this.m_lblPeriodicMonAndCalibTimeFit.Location = new Point(140, 65);
			this.m_lblPeriodicMonAndCalibTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblPeriodicMonAndCalibTimeFit.Name = "m_lblPeriodicMonAndCalibTimeFit";
			this.m_lblPeriodicMonAndCalibTimeFit.Size = new Size(17, 17);
			this.m_lblPeriodicMonAndCalibTimeFit.TabIndex = 29;
			this.m_lblPeriodicMonAndCalibTimeFit.Text = "P";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(1, 65);
			this.label12.Margin = new Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new Size(113, 17);
			this.label12.TabIndex = 28;
			this.label12.Text = "Periodic Time Fit";
			this.m_lblRadarDevice4RunTimingViolation.AutoSize = true;
			this.m_lblRadarDevice4RunTimingViolation.Location = new Point(245, 97);
			this.m_lblRadarDevice4RunTimingViolation.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RunTimingViolation.Name = "m_lblRadarDevice4RunTimingViolation";
			this.m_lblRadarDevice4RunTimingViolation.Size = new Size(17, 17);
			this.m_lblRadarDevice4RunTimingViolation.TabIndex = 27;
			this.m_lblRadarDevice4RunTimingViolation.Text = "P";
			this.m_lblRadarDevice3RunTimingViolation.AutoSize = true;
			this.m_lblRadarDevice3RunTimingViolation.Location = new Point(211, 97);
			this.m_lblRadarDevice3RunTimingViolation.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RunTimingViolation.Name = "m_lblRadarDevice3RunTimingViolation";
			this.m_lblRadarDevice3RunTimingViolation.Size = new Size(17, 17);
			this.m_lblRadarDevice3RunTimingViolation.TabIndex = 26;
			this.m_lblRadarDevice3RunTimingViolation.Text = "P";
			this.m_lblRadarDevice2RunTimingViolation.AutoSize = true;
			this.m_lblRadarDevice2RunTimingViolation.Location = new Point(175, 97);
			this.m_lblRadarDevice2RunTimingViolation.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimingViolation.Name = "m_lblRadarDevice2RunTimingViolation";
			this.m_lblRadarDevice2RunTimingViolation.Size = new Size(17, 17);
			this.m_lblRadarDevice2RunTimingViolation.TabIndex = 25;
			this.m_lblRadarDevice2RunTimingViolation.Text = "P";
			this.m_lblRunTimingViolation.AutoSize = true;
			this.m_lblRunTimingViolation.Location = new Point(140, 97);
			this.m_lblRunTimingViolation.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimingViolation.Name = "m_lblRunTimingViolation";
			this.m_lblRunTimingViolation.Size = new Size(17, 17);
			this.m_lblRunTimingViolation.TabIndex = 24;
			this.m_lblRunTimingViolation.Text = "P";
			this.m_lblRadarDevice4TotalMonAndCalibTimeFit.AutoSize = true;
			this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Location = new Point(245, 34);
			this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Name = "m_lblRadarDevice4TotalMonAndCalibTimeFit";
			this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Size = new Size(17, 17);
			this.m_lblRadarDevice4TotalMonAndCalibTimeFit.TabIndex = 23;
			this.m_lblRadarDevice4TotalMonAndCalibTimeFit.Text = "P";
			this.m_lblRadarDevice3TotalMonAndCalibTimeFit.AutoSize = true;
			this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Location = new Point(211, 34);
			this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Name = "m_lblRadarDevice3TotalMonAndCalibTimeFit";
			this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Size = new Size(17, 17);
			this.m_lblRadarDevice3TotalMonAndCalibTimeFit.TabIndex = 22;
			this.m_lblRadarDevice3TotalMonAndCalibTimeFit.Text = "P";
			this.m_lblRadarDevice2TotalMonAndCalibTimeFit.AutoSize = true;
			this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Location = new Point(175, 34);
			this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Name = "m_lblRadarDevice2TotalMonAndCalibTimeFit";
			this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Size = new Size(17, 17);
			this.m_lblRadarDevice2TotalMonAndCalibTimeFit.TabIndex = 21;
			this.m_lblRadarDevice2TotalMonAndCalibTimeFit.Text = "P";
			this.m_lblTotalMonAndCalibTimeFit.AutoSize = true;
			this.m_lblTotalMonAndCalibTimeFit.Location = new Point(140, 34);
			this.m_lblTotalMonAndCalibTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblTotalMonAndCalibTimeFit.Name = "m_lblTotalMonAndCalibTimeFit";
			this.m_lblTotalMonAndCalibTimeFit.Size = new Size(17, 17);
			this.m_lblTotalMonAndCalibTimeFit.TabIndex = 20;
			this.m_lblTotalMonAndCalibTimeFit.Text = "P";
			this.m_lblRadarDevice4TotalMonTimeFit.AutoSize = true;
			this.m_lblRadarDevice4TotalMonTimeFit.Location = new Point(245, 127);
			this.m_lblRadarDevice4TotalMonTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4TotalMonTimeFit.Name = "m_lblRadarDevice4TotalMonTimeFit";
			this.m_lblRadarDevice4TotalMonTimeFit.Size = new Size(17, 17);
			this.m_lblRadarDevice4TotalMonTimeFit.TabIndex = 19;
			this.m_lblRadarDevice4TotalMonTimeFit.Text = "P";
			this.m_lblRadarDevice4TotalMonTimeFit.Visible = false;
			this.m_lblRadarDevice3TotalMonTimeFit.AutoSize = true;
			this.m_lblRadarDevice3TotalMonTimeFit.Location = new Point(211, 127);
			this.m_lblRadarDevice3TotalMonTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3TotalMonTimeFit.Name = "m_lblRadarDevice3TotalMonTimeFit";
			this.m_lblRadarDevice3TotalMonTimeFit.Size = new Size(17, 17);
			this.m_lblRadarDevice3TotalMonTimeFit.TabIndex = 18;
			this.m_lblRadarDevice3TotalMonTimeFit.Text = "P";
			this.m_lblRadarDevice3TotalMonTimeFit.Visible = false;
			this.m_lblRadarDevice2TotalMonTimeFit.AutoSize = true;
			this.m_lblRadarDevice2TotalMonTimeFit.Location = new Point(175, 127);
			this.m_lblRadarDevice2TotalMonTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2TotalMonTimeFit.Name = "m_lblRadarDevice2TotalMonTimeFit";
			this.m_lblRadarDevice2TotalMonTimeFit.Size = new Size(17, 17);
			this.m_lblRadarDevice2TotalMonTimeFit.TabIndex = 17;
			this.m_lblRadarDevice2TotalMonTimeFit.Text = "P";
			this.m_lblRadarDevice2TotalMonTimeFit.Visible = false;
			this.m_lblTotalMonTimeFit.AutoSize = true;
			this.m_lblTotalMonTimeFit.Location = new Point(140, 127);
			this.m_lblTotalMonTimeFit.Margin = new Padding(4, 0, 4, 0);
			this.m_lblTotalMonTimeFit.Name = "m_lblTotalMonTimeFit";
			this.m_lblTotalMonTimeFit.Size = new Size(17, 17);
			this.m_lblTotalMonTimeFit.TabIndex = 16;
			this.m_lblTotalMonTimeFit.Text = "P";
			this.m_lblTotalMonTimeFit.Visible = false;
			this.label21.AutoSize = true;
			this.label21.Location = new Point(0, 97);
			this.label21.Margin = new Padding(4, 0, 4, 0);
			this.label21.Name = "label21";
			this.label21.Size = new Size(127, 17);
			this.label21.TabIndex = 6;
			this.label21.Text = "Run Time Violation";
			this.label20.AutoSize = true;
			this.label20.Location = new Point(1, 34);
			this.label20.Margin = new Padding(4, 0, 4, 0);
			this.label20.Name = "label20";
			this.label20.Size = new Size(113, 17);
			this.label20.TabIndex = 5;
			this.label20.Text = "Cal Now Time Fit";
			this.m_grpRFInitCalibCfg.Controls.Add(this.m_chkTxPhase);
			this.m_grpRFInitCalibCfg.Controls.Add(this.m_btnRFInitCalibSet);
			this.m_grpRFInitCalibCfg.Controls.Add(this.m_chkRxGain);
			this.m_grpRFInitCalibCfg.Controls.Add(this.m_chkTxPower);
			this.m_grpRFInitCalibCfg.Controls.Add(this.m_chkPeakDetector);
			this.m_grpRFInitCalibCfg.Controls.Add(this.m_chkLPFCutoff);
			this.m_grpRFInitCalibCfg.Controls.Add(this.f000130);
			this.m_grpRFInitCalibCfg.Controls.Add(this.m_chkHPFCutoff);
			this.m_grpRFInitCalibCfg.Controls.Add(this.f000131);
			this.m_grpRFInitCalibCfg.Controls.Add(this.m_chkLODist);
			this.m_grpRFInitCalibCfg.Controls.Add(this.label4);
			this.m_grpRFInitCalibCfg.Location = new Point(399, 30);
			this.m_grpRFInitCalibCfg.Margin = new Padding(4, 4, 4, 4);
			this.m_grpRFInitCalibCfg.Name = "m_grpRFInitCalibCfg";
			this.m_grpRFInitCalibCfg.Padding = new Padding(4, 4, 4, 4);
			this.m_grpRFInitCalibCfg.Size = new Size(527, 204);
			this.m_grpRFInitCalibCfg.TabIndex = 2;
			this.m_grpRFInitCalibCfg.TabStop = false;
			this.m_grpRFInitCalibCfg.Text = "RF Init Calibration config";
			this.m_chkTxPhase.AutoSize = true;
			this.m_chkTxPhase.Checked = true;
			this.m_chkTxPhase.CheckState = CheckState.Checked;
			this.m_chkTxPhase.Location = new Point(273, 112);
			this.m_chkTxPhase.Margin = new Padding(4, 4, 4, 4);
			this.m_chkTxPhase.Name = "m_chkTxPhase";
			this.m_chkTxPhase.Size = new Size(85, 21);
			this.m_chkTxPhase.TabIndex = 11;
			this.m_chkTxPhase.Text = "TxPhase";
			this.m_chkTxPhase.UseVisualStyleBackColor = true;
			this.m_btnRFInitCalibSet.Location = new Point(411, 151);
			this.m_btnRFInitCalibSet.Margin = new Padding(4, 4, 4, 4);
			this.m_btnRFInitCalibSet.Name = "m_btnRFInitCalibSet";
			this.m_btnRFInitCalibSet.Size = new Size(100, 34);
			this.m_btnRFInitCalibSet.TabIndex = 10;
			this.m_btnRFInitCalibSet.Text = "Set";
			this.m_btnRFInitCalibSet.UseVisualStyleBackColor = true;
			this.m_btnRFInitCalibSet.Click += this.m_btnRFInitCalibSet_Click;
			this.m_chkRxGain.AutoSize = true;
			this.m_chkRxGain.Checked = true;
			this.m_chkRxGain.CheckState = CheckState.Checked;
			this.m_chkRxGain.Location = new Point(155, 112);
			this.m_chkRxGain.Margin = new Padding(4, 4, 4, 4);
			this.m_chkRxGain.Name = "m_chkRxGain";
			this.m_chkRxGain.Size = new Size(80, 21);
			this.m_chkRxGain.TabIndex = 9;
			this.m_chkRxGain.Text = "Rx Gain";
			this.m_chkRxGain.UseVisualStyleBackColor = true;
			this.m_chkTxPower.AutoSize = true;
			this.m_chkTxPower.Checked = true;
			this.m_chkTxPower.CheckState = CheckState.Checked;
			this.m_chkTxPower.Location = new Point(416, 71);
			this.m_chkTxPower.Margin = new Padding(4, 4, 4, 4);
			this.m_chkTxPower.Name = "m_chkTxPower";
			this.m_chkTxPower.Size = new Size(88, 21);
			this.m_chkTxPower.TabIndex = 7;
			this.m_chkTxPower.Text = "Tx Power";
			this.m_chkTxPower.UseVisualStyleBackColor = true;
			this.m_chkPeakDetector.AutoSize = true;
			this.m_chkPeakDetector.Checked = true;
			this.m_chkPeakDetector.CheckState = CheckState.Checked;
			this.m_chkPeakDetector.Location = new Point(273, 71);
			this.m_chkPeakDetector.Margin = new Padding(4, 4, 4, 4);
			this.m_chkPeakDetector.Name = "m_chkPeakDetector";
			this.m_chkPeakDetector.Size = new Size(120, 21);
			this.m_chkPeakDetector.TabIndex = 6;
			this.m_chkPeakDetector.Text = "Peak Detector";
			this.m_chkPeakDetector.UseVisualStyleBackColor = true;
			this.m_chkLPFCutoff.AutoSize = true;
			this.m_chkLPFCutoff.Checked = true;
			this.m_chkLPFCutoff.CheckState = CheckState.Checked;
			this.m_chkLPFCutoff.Location = new Point(155, 71);
			this.m_chkLPFCutoff.Margin = new Padding(4, 4, 4, 4);
			this.m_chkLPFCutoff.Name = "m_chkLPFCutoff";
			this.m_chkLPFCutoff.Size = new Size(96, 21);
			this.m_chkLPFCutoff.TabIndex = 5;
			this.m_chkLPFCutoff.Text = "LPF Cutoff";
			this.m_chkLPFCutoff.UseVisualStyleBackColor = true;
			this.f000130.AutoSize = true;
			this.f000130.Checked = true;
			this.f000130.CheckState = CheckState.Checked;
			this.f000130.Location = new Point(416, 112);
			this.f000130.Margin = new Padding(4, 4, 4, 4);
			this.f000130.Name = "m_chkRxIQMM";
			this.f000130.Size = new Size(86, 21);
			this.f000130.TabIndex = 4;
			this.f000130.Text = "Rx IQMM";
			this.f000130.UseVisualStyleBackColor = true;
			this.f000130.CheckedChanged += this.m00000b;
			this.m_chkHPFCutoff.AutoSize = true;
			this.m_chkHPFCutoff.Checked = true;
			this.m_chkHPFCutoff.CheckState = CheckState.Checked;
			this.m_chkHPFCutoff.Location = new Point(416, 31);
			this.m_chkHPFCutoff.Margin = new Padding(4, 4, 4, 4);
			this.m_chkHPFCutoff.Name = "m_chkHPFCutoff";
			this.m_chkHPFCutoff.Size = new Size(98, 21);
			this.m_chkHPFCutoff.TabIndex = 3;
			this.m_chkHPFCutoff.Text = "HPF Cutoff";
			this.m_chkHPFCutoff.UseVisualStyleBackColor = true;
			this.f000131.AutoSize = true;
			this.f000131.Checked = true;
			this.f000131.CheckState = CheckState.Checked;
			this.f000131.Location = new Point(273, 31);
			this.f000131.Margin = new Padding(4, 4, 4, 4);
			this.f000131.Name = "m_chkRxADCDC";
			this.f000131.Size = new Size(101, 21);
			this.f000131.TabIndex = 2;
			this.f000131.Text = "Rx ADC DC";
			this.f000131.UseVisualStyleBackColor = true;
			this.m_chkLODist.AutoSize = true;
			this.m_chkLODist.Checked = true;
			this.m_chkLODist.CheckState = CheckState.Checked;
			this.m_chkLODist.Location = new Point(155, 31);
			this.m_chkLODist.Margin = new Padding(4, 4, 4, 4);
			this.m_chkLODist.Name = "m_chkLODist";
			this.m_chkLODist.Size = new Size(73, 21);
			this.m_chkLODist.TabIndex = 1;
			this.m_chkLODist.Text = "LODist";
			this.m_chkLODist.UseVisualStyleBackColor = true;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(21, 32);
			this.label4.Margin = new Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(105, 17);
			this.label4.TabIndex = 0;
			this.label4.Text = "Calib Ena Mask";
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4TxPhaseUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4TxPhase);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3TxPhaseUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3TxPhase);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2TxPhaseUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2TxPhase);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblTxPhaseUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblTxPhase);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label19);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4TimeStamp);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4Temperature);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3TimeStamp);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3Temperature);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2TimeStamp);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2Temperature);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00014d);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4RxGainUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4RFTxPowerUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4PeakDetectorUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00014e);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00014f);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000150);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4RFInitLODistUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000151);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000152);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4RFInitApllcalUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000153);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3RxGainUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3RFTxPowerUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3PeakDetectorUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000154);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000155);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000156);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3RFInitLODistUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000157);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000158);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3RFInitApllcalUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000159);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2RxGainUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2RFTxPowerUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2PeakDetectorUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00015a);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00015b);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00015c);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2RFInitLODistUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00015d);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00015e);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2RFInitApllcalUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00015f);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRxGainUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRFTxPowerUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblPeakDetectorUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000160);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000161);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000162);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000163);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000164);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000165);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRFInitApllcalUpdate);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblTimeStamp);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblTemperature);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label62);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label61);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000166);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000167);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000168);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000169);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4RxGain);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3RxGain);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2RxGain);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRxGain);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4PeakDetector);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3PeakDetector);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2PeakDetector);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblPeakDetector);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.lblRadarDevice4Update);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.lblRadarDevice4Status);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.lblRadarDevice3Update);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.lblRadarDevice3Status);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.lblRadarDevice2Update);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.lblRadarDevice2Status);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label13);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label11);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label10);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label39);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label38);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000132);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000133);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4RFTxPower);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000134);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000135);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000136);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000137);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice4RFInitApllcalStatus);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000138);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000139);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3RFTxPower);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00013a);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00013b);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00013c);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00013d);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice3RFInitApllcalStatus);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00013e);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f00013f);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2RFTxPower);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000140);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000141);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000142);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000143);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRadarDevice2RFInitApllcalStatus);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000144);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000145);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRFTxPower);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000146);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000147);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000148);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.f000149);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.m_lblRFInitApllcalStatus);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label17);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label15);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label16);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label9);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label8);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label7);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label6);
			this.m_grpRFInitCalibReportCfg.Controls.Add(this.label5);
			this.m_grpRFInitCalibReportCfg.Location = new Point(299, 245);
			this.m_grpRFInitCalibReportCfg.Margin = new Padding(4, 4, 4, 4);
			this.m_grpRFInitCalibReportCfg.Name = "m_grpRFInitCalibReportCfg";
			this.m_grpRFInitCalibReportCfg.Padding = new Padding(4, 4, 4, 4);
			this.m_grpRFInitCalibReportCfg.Size = new Size(669, 393);
			this.m_grpRFInitCalibReportCfg.TabIndex = 3;
			this.m_grpRFInitCalibReportCfg.TabStop = false;
			this.m_grpRFInitCalibReportCfg.Text = "RF Init Calibration Summary Report";
			this.m_grpRFInitCalibReportCfg.Enter += this.m_grpRFInitCalibReportCfg_Enter;
			this.m_lblRadarDevice4TxPhaseUpdate.AutoSize = true;
			this.m_lblRadarDevice4TxPhaseUpdate.Location = new Point(615, 297);
			this.m_lblRadarDevice4TxPhaseUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4TxPhaseUpdate.Name = "m_lblRadarDevice4TxPhaseUpdate";
			this.m_lblRadarDevice4TxPhaseUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice4TxPhaseUpdate.TabIndex = 167;
			this.m_lblRadarDevice4TxPhaseUpdate.Text = "N";
			this.m_lblRadarDevice4TxPhase.AutoSize = true;
			this.m_lblRadarDevice4TxPhase.Location = new Point(556, 298);
			this.m_lblRadarDevice4TxPhase.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4TxPhase.Name = "m_lblRadarDevice4TxPhase";
			this.m_lblRadarDevice4TxPhase.Size = new Size(16, 17);
			this.m_lblRadarDevice4TxPhase.TabIndex = 166;
			this.m_lblRadarDevice4TxPhase.Text = "F";
			this.m_lblRadarDevice3TxPhaseUpdate.AutoSize = true;
			this.m_lblRadarDevice3TxPhaseUpdate.Location = new Point(467, 298);
			this.m_lblRadarDevice3TxPhaseUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3TxPhaseUpdate.Name = "m_lblRadarDevice3TxPhaseUpdate";
			this.m_lblRadarDevice3TxPhaseUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice3TxPhaseUpdate.TabIndex = 165;
			this.m_lblRadarDevice3TxPhaseUpdate.Text = "N";
			this.m_lblRadarDevice3TxPhase.AutoSize = true;
			this.m_lblRadarDevice3TxPhase.Location = new Point(421, 298);
			this.m_lblRadarDevice3TxPhase.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3TxPhase.Name = "m_lblRadarDevice3TxPhase";
			this.m_lblRadarDevice3TxPhase.Size = new Size(16, 17);
			this.m_lblRadarDevice3TxPhase.TabIndex = 164;
			this.m_lblRadarDevice3TxPhase.Text = "F";
			this.m_lblRadarDevice2TxPhaseUpdate.AutoSize = true;
			this.m_lblRadarDevice2TxPhaseUpdate.Location = new Point(327, 298);
			this.m_lblRadarDevice2TxPhaseUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2TxPhaseUpdate.Name = "m_lblRadarDevice2TxPhaseUpdate";
			this.m_lblRadarDevice2TxPhaseUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice2TxPhaseUpdate.TabIndex = 163;
			this.m_lblRadarDevice2TxPhaseUpdate.Text = "N";
			this.m_lblRadarDevice2TxPhase.AutoSize = true;
			this.m_lblRadarDevice2TxPhase.Location = new Point(280, 298);
			this.m_lblRadarDevice2TxPhase.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2TxPhase.Name = "m_lblRadarDevice2TxPhase";
			this.m_lblRadarDevice2TxPhase.Size = new Size(16, 17);
			this.m_lblRadarDevice2TxPhase.TabIndex = 162;
			this.m_lblRadarDevice2TxPhase.Text = "F";
			this.m_lblTxPhaseUpdate.AutoSize = true;
			this.m_lblTxPhaseUpdate.Location = new Point(195, 295);
			this.m_lblTxPhaseUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblTxPhaseUpdate.Name = "m_lblTxPhaseUpdate";
			this.m_lblTxPhaseUpdate.Size = new Size(18, 17);
			this.m_lblTxPhaseUpdate.TabIndex = 161;
			this.m_lblTxPhaseUpdate.Text = "N";
			this.m_lblTxPhaseUpdate.Click += this.label42_Click;
			this.m_lblTxPhase.AutoSize = true;
			this.m_lblTxPhase.Location = new Point(140, 295);
			this.m_lblTxPhase.Margin = new Padding(4, 0, 4, 0);
			this.m_lblTxPhase.Name = "m_lblTxPhase";
			this.m_lblTxPhase.Size = new Size(16, 17);
			this.m_lblTxPhase.TabIndex = 160;
			this.m_lblTxPhase.Text = "F";
			this.m_lblTxPhase.Click += this.label41_Click;
			this.label19.AutoSize = true;
			this.label19.Location = new Point(9, 299);
			this.label19.Margin = new Padding(4, 0, 4, 0);
			this.label19.Name = "label19";
			this.label19.Size = new Size(63, 17);
			this.label19.TabIndex = 159;
			this.label19.Text = "TxPhase";
			this.m_lblRadarDevice4TimeStamp.AutoSize = true;
			this.m_lblRadarDevice4TimeStamp.Location = new Point(557, 372);
			this.m_lblRadarDevice4TimeStamp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4TimeStamp.Name = "m_lblRadarDevice4TimeStamp";
			this.m_lblRadarDevice4TimeStamp.Size = new Size(16, 17);
			this.m_lblRadarDevice4TimeStamp.TabIndex = 158;
			this.m_lblRadarDevice4TimeStamp.Text = "0";
			this.m_lblRadarDevice4Temperature.AutoSize = true;
			this.m_lblRadarDevice4Temperature.Location = new Point(557, 347);
			this.m_lblRadarDevice4Temperature.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4Temperature.Name = "m_lblRadarDevice4Temperature";
			this.m_lblRadarDevice4Temperature.Size = new Size(16, 17);
			this.m_lblRadarDevice4Temperature.TabIndex = 157;
			this.m_lblRadarDevice4Temperature.Text = "0";
			this.m_lblRadarDevice3TimeStamp.AutoSize = true;
			this.m_lblRadarDevice3TimeStamp.Location = new Point(423, 372);
			this.m_lblRadarDevice3TimeStamp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3TimeStamp.Name = "m_lblRadarDevice3TimeStamp";
			this.m_lblRadarDevice3TimeStamp.Size = new Size(16, 17);
			this.m_lblRadarDevice3TimeStamp.TabIndex = 156;
			this.m_lblRadarDevice3TimeStamp.Text = "0";
			this.m_lblRadarDevice3Temperature.AutoSize = true;
			this.m_lblRadarDevice3Temperature.Location = new Point(423, 347);
			this.m_lblRadarDevice3Temperature.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3Temperature.Name = "m_lblRadarDevice3Temperature";
			this.m_lblRadarDevice3Temperature.Size = new Size(16, 17);
			this.m_lblRadarDevice3Temperature.TabIndex = 155;
			this.m_lblRadarDevice3Temperature.Text = "0";
			this.m_lblRadarDevice2TimeStamp.AutoSize = true;
			this.m_lblRadarDevice2TimeStamp.Location = new Point(280, 372);
			this.m_lblRadarDevice2TimeStamp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2TimeStamp.Name = "m_lblRadarDevice2TimeStamp";
			this.m_lblRadarDevice2TimeStamp.Size = new Size(16, 17);
			this.m_lblRadarDevice2TimeStamp.TabIndex = 154;
			this.m_lblRadarDevice2TimeStamp.Text = "0";
			this.m_lblRadarDevice2Temperature.AutoSize = true;
			this.m_lblRadarDevice2Temperature.Location = new Point(280, 347);
			this.m_lblRadarDevice2Temperature.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2Temperature.Name = "m_lblRadarDevice2Temperature";
			this.m_lblRadarDevice2Temperature.Size = new Size(16, 17);
			this.m_lblRadarDevice2Temperature.TabIndex = 153;
			this.m_lblRadarDevice2Temperature.Text = "0";
			this.f00014d.AutoSize = true;
			this.f00014d.Location = new Point(615, 322);
			this.f00014d.Margin = new Padding(4, 0, 4, 0);
			this.f00014d.Name = "m_lblRadarDevice4RxIQMMUpdate";
			this.f00014d.Size = new Size(18, 17);
			this.f00014d.TabIndex = 150;
			this.f00014d.Text = "N";
			this.m_lblRadarDevice4RxGainUpdate.AutoSize = true;
			this.m_lblRadarDevice4RxGainUpdate.Location = new Point(615, 274);
			this.m_lblRadarDevice4RxGainUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RxGainUpdate.Name = "m_lblRadarDevice4RxGainUpdate";
			this.m_lblRadarDevice4RxGainUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice4RxGainUpdate.TabIndex = 148;
			this.m_lblRadarDevice4RxGainUpdate.Text = "N";
			this.m_lblRadarDevice4RFTxPowerUpdate.AutoSize = true;
			this.m_lblRadarDevice4RFTxPowerUpdate.Location = new Point(615, 250);
			this.m_lblRadarDevice4RFTxPowerUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RFTxPowerUpdate.Name = "m_lblRadarDevice4RFTxPowerUpdate";
			this.m_lblRadarDevice4RFTxPowerUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice4RFTxPowerUpdate.TabIndex = 147;
			this.m_lblRadarDevice4RFTxPowerUpdate.Text = "N";
			this.m_lblRadarDevice4PeakDetectorUpdate.AutoSize = true;
			this.m_lblRadarDevice4PeakDetectorUpdate.Location = new Point(615, 225);
			this.m_lblRadarDevice4PeakDetectorUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4PeakDetectorUpdate.Name = "m_lblRadarDevice4PeakDetectorUpdate";
			this.m_lblRadarDevice4PeakDetectorUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice4PeakDetectorUpdate.TabIndex = 146;
			this.m_lblRadarDevice4PeakDetectorUpdate.Text = "N";
			this.f00014e.AutoSize = true;
			this.f00014e.Location = new Point(615, 201);
			this.f00014e.Margin = new Padding(4, 0, 4, 0);
			this.f00014e.Name = "m_lblRadarDevice4RFInitLPFUpdate";
			this.f00014e.Size = new Size(18, 17);
			this.f00014e.TabIndex = 145;
			this.f00014e.Text = "N";
			this.f00014f.AutoSize = true;
			this.f00014f.Location = new Point(615, 176);
			this.f00014f.Margin = new Padding(4, 0, 4, 0);
			this.f00014f.Name = "m_lblRadarDevice4RFInitHPFUpdate";
			this.f00014f.Size = new Size(18, 17);
			this.f00014f.TabIndex = 144;
			this.f00014f.Text = "N";
			this.f000150.AutoSize = true;
			this.f000150.Location = new Point(615, 151);
			this.f000150.Margin = new Padding(4, 0, 4, 0);
			this.f000150.Name = "m_lblRadarDevice4RFInitRXADC_DCUpdate";
			this.f000150.Size = new Size(18, 17);
			this.f000150.TabIndex = 143;
			this.f000150.Text = "N";
			this.m_lblRadarDevice4RFInitLODistUpdate.AutoSize = true;
			this.m_lblRadarDevice4RFInitLODistUpdate.Location = new Point(615, 127);
			this.m_lblRadarDevice4RFInitLODistUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RFInitLODistUpdate.Name = "m_lblRadarDevice4RFInitLODistUpdate";
			this.m_lblRadarDevice4RFInitLODistUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice4RFInitLODistUpdate.TabIndex = 142;
			this.m_lblRadarDevice4RFInitLODistUpdate.Text = "N";
			this.f000151.AutoSize = true;
			this.f000151.Location = new Point(615, 102);
			this.f000151.Margin = new Padding(4, 0, 4, 0);
			this.f000151.Name = "m_lblRadarDevice4RFInitVCO2Update";
			this.f000151.Size = new Size(18, 17);
			this.f000151.TabIndex = 141;
			this.f000151.Text = "N";
			this.f000152.AutoSize = true;
			this.f000152.Location = new Point(615, 78);
			this.f000152.Margin = new Padding(4, 0, 4, 0);
			this.f000152.Name = "m_lblRadarDevice4RFInitVCOUpdate";
			this.f000152.Size = new Size(18, 17);
			this.f000152.TabIndex = 140;
			this.f000152.Text = "N";
			this.m_lblRadarDevice4RFInitApllcalUpdate.AutoSize = true;
			this.m_lblRadarDevice4RFInitApllcalUpdate.Location = new Point(615, 53);
			this.m_lblRadarDevice4RFInitApllcalUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RFInitApllcalUpdate.Name = "m_lblRadarDevice4RFInitApllcalUpdate";
			this.m_lblRadarDevice4RFInitApllcalUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice4RFInitApllcalUpdate.TabIndex = 139;
			this.m_lblRadarDevice4RFInitApllcalUpdate.Text = "N";
			this.f000153.AutoSize = true;
			this.f000153.Location = new Point(468, 322);
			this.f000153.Margin = new Padding(4, 0, 4, 0);
			this.f000153.Name = "m_lblRadarDevice3RxIQMMUpdate";
			this.f000153.Size = new Size(18, 17);
			this.f000153.TabIndex = 136;
			this.f000153.Text = "N";
			this.m_lblRadarDevice3RxGainUpdate.AutoSize = true;
			this.m_lblRadarDevice3RxGainUpdate.Location = new Point(468, 274);
			this.m_lblRadarDevice3RxGainUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RxGainUpdate.Name = "m_lblRadarDevice3RxGainUpdate";
			this.m_lblRadarDevice3RxGainUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice3RxGainUpdate.TabIndex = 134;
			this.m_lblRadarDevice3RxGainUpdate.Text = "N";
			this.m_lblRadarDevice3RFTxPowerUpdate.AutoSize = true;
			this.m_lblRadarDevice3RFTxPowerUpdate.Location = new Point(468, 250);
			this.m_lblRadarDevice3RFTxPowerUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RFTxPowerUpdate.Name = "m_lblRadarDevice3RFTxPowerUpdate";
			this.m_lblRadarDevice3RFTxPowerUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice3RFTxPowerUpdate.TabIndex = 133;
			this.m_lblRadarDevice3RFTxPowerUpdate.Text = "N";
			this.m_lblRadarDevice3PeakDetectorUpdate.AutoSize = true;
			this.m_lblRadarDevice3PeakDetectorUpdate.Location = new Point(468, 225);
			this.m_lblRadarDevice3PeakDetectorUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3PeakDetectorUpdate.Name = "m_lblRadarDevice3PeakDetectorUpdate";
			this.m_lblRadarDevice3PeakDetectorUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice3PeakDetectorUpdate.TabIndex = 132;
			this.m_lblRadarDevice3PeakDetectorUpdate.Text = "N";
			this.f000154.AutoSize = true;
			this.f000154.Location = new Point(468, 201);
			this.f000154.Margin = new Padding(4, 0, 4, 0);
			this.f000154.Name = "m_lblRadarDevice3RFInitLPFUpdate";
			this.f000154.Size = new Size(18, 17);
			this.f000154.TabIndex = 131;
			this.f000154.Text = "N";
			this.f000155.AutoSize = true;
			this.f000155.Location = new Point(468, 176);
			this.f000155.Margin = new Padding(4, 0, 4, 0);
			this.f000155.Name = "m_lblRadarDevice3RFInitHPFUpdate";
			this.f000155.Size = new Size(18, 17);
			this.f000155.TabIndex = 130;
			this.f000155.Text = "N";
			this.f000156.AutoSize = true;
			this.f000156.Location = new Point(468, 151);
			this.f000156.Margin = new Padding(4, 0, 4, 0);
			this.f000156.Name = "m_lblRadarDevice3RFInitRXADC_DCUpdate";
			this.f000156.Size = new Size(18, 17);
			this.f000156.TabIndex = 129;
			this.f000156.Text = "N";
			this.m_lblRadarDevice3RFInitLODistUpdate.AutoSize = true;
			this.m_lblRadarDevice3RFInitLODistUpdate.Location = new Point(468, 127);
			this.m_lblRadarDevice3RFInitLODistUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RFInitLODistUpdate.Name = "m_lblRadarDevice3RFInitLODistUpdate";
			this.m_lblRadarDevice3RFInitLODistUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice3RFInitLODistUpdate.TabIndex = 128;
			this.m_lblRadarDevice3RFInitLODistUpdate.Text = "N";
			this.f000157.AutoSize = true;
			this.f000157.Location = new Point(468, 102);
			this.f000157.Margin = new Padding(4, 0, 4, 0);
			this.f000157.Name = "m_lblRadarDevice3RFInitVCO2Update";
			this.f000157.Size = new Size(18, 17);
			this.f000157.TabIndex = 127;
			this.f000157.Text = "N";
			this.f000158.AutoSize = true;
			this.f000158.Location = new Point(468, 78);
			this.f000158.Margin = new Padding(4, 0, 4, 0);
			this.f000158.Name = "m_lblRadarDevice3RFInitVCOUpdate";
			this.f000158.Size = new Size(18, 17);
			this.f000158.TabIndex = 126;
			this.f000158.Text = "N";
			this.m_lblRadarDevice3RFInitApllcalUpdate.AutoSize = true;
			this.m_lblRadarDevice3RFInitApllcalUpdate.Location = new Point(468, 53);
			this.m_lblRadarDevice3RFInitApllcalUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RFInitApllcalUpdate.Name = "m_lblRadarDevice3RFInitApllcalUpdate";
			this.m_lblRadarDevice3RFInitApllcalUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice3RFInitApllcalUpdate.TabIndex = 125;
			this.m_lblRadarDevice3RFInitApllcalUpdate.Text = "N";
			this.f000159.AutoSize = true;
			this.f000159.Location = new Point(328, 322);
			this.f000159.Margin = new Padding(4, 0, 4, 0);
			this.f000159.Name = "m_lblRadarDevice2RxIQMMUpdate";
			this.f000159.Size = new Size(18, 17);
			this.f000159.TabIndex = 122;
			this.f000159.Text = "N";
			this.m_lblRadarDevice2RxGainUpdate.AutoSize = true;
			this.m_lblRadarDevice2RxGainUpdate.Location = new Point(328, 274);
			this.m_lblRadarDevice2RxGainUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RxGainUpdate.Name = "m_lblRadarDevice2RxGainUpdate";
			this.m_lblRadarDevice2RxGainUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice2RxGainUpdate.TabIndex = 120;
			this.m_lblRadarDevice2RxGainUpdate.Text = "N";
			this.m_lblRadarDevice2RFTxPowerUpdate.AutoSize = true;
			this.m_lblRadarDevice2RFTxPowerUpdate.Location = new Point(328, 250);
			this.m_lblRadarDevice2RFTxPowerUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RFTxPowerUpdate.Name = "m_lblRadarDevice2RFTxPowerUpdate";
			this.m_lblRadarDevice2RFTxPowerUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice2RFTxPowerUpdate.TabIndex = 119;
			this.m_lblRadarDevice2RFTxPowerUpdate.Text = "N";
			this.m_lblRadarDevice2PeakDetectorUpdate.AutoSize = true;
			this.m_lblRadarDevice2PeakDetectorUpdate.Location = new Point(328, 225);
			this.m_lblRadarDevice2PeakDetectorUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2PeakDetectorUpdate.Name = "m_lblRadarDevice2PeakDetectorUpdate";
			this.m_lblRadarDevice2PeakDetectorUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice2PeakDetectorUpdate.TabIndex = 118;
			this.m_lblRadarDevice2PeakDetectorUpdate.Text = "N";
			this.f00015a.AutoSize = true;
			this.f00015a.Location = new Point(328, 201);
			this.f00015a.Margin = new Padding(4, 0, 4, 0);
			this.f00015a.Name = "m_lblRadarDevice2RFInitLPFUpdate";
			this.f00015a.Size = new Size(18, 17);
			this.f00015a.TabIndex = 117;
			this.f00015a.Text = "N";
			this.f00015b.AutoSize = true;
			this.f00015b.Location = new Point(328, 176);
			this.f00015b.Margin = new Padding(4, 0, 4, 0);
			this.f00015b.Name = "m_lblRadarDevice2RFInitHPFUpdate";
			this.f00015b.Size = new Size(18, 17);
			this.f00015b.TabIndex = 116;
			this.f00015b.Text = "N";
			this.f00015c.AutoSize = true;
			this.f00015c.Location = new Point(328, 151);
			this.f00015c.Margin = new Padding(4, 0, 4, 0);
			this.f00015c.Name = "m_lblRadarDevice2RFInitRXADC_DCUpdate";
			this.f00015c.Size = new Size(18, 17);
			this.f00015c.TabIndex = 115;
			this.f00015c.Text = "N";
			this.m_lblRadarDevice2RFInitLODistUpdate.AutoSize = true;
			this.m_lblRadarDevice2RFInitLODistUpdate.Location = new Point(328, 127);
			this.m_lblRadarDevice2RFInitLODistUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RFInitLODistUpdate.Name = "m_lblRadarDevice2RFInitLODistUpdate";
			this.m_lblRadarDevice2RFInitLODistUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice2RFInitLODistUpdate.TabIndex = 114;
			this.m_lblRadarDevice2RFInitLODistUpdate.Text = "N";
			this.f00015d.AutoSize = true;
			this.f00015d.Location = new Point(328, 102);
			this.f00015d.Margin = new Padding(4, 0, 4, 0);
			this.f00015d.Name = "m_lblRadarDevice2RFInitVCO2Update";
			this.f00015d.Size = new Size(18, 17);
			this.f00015d.TabIndex = 113;
			this.f00015d.Text = "N";
			this.f00015e.AutoSize = true;
			this.f00015e.Location = new Point(328, 78);
			this.f00015e.Margin = new Padding(4, 0, 4, 0);
			this.f00015e.Name = "m_lblRadarDevice2RFInitVCOUpdate";
			this.f00015e.Size = new Size(18, 17);
			this.f00015e.TabIndex = 112;
			this.f00015e.Text = "N";
			this.m_lblRadarDevice2RFInitApllcalUpdate.AutoSize = true;
			this.m_lblRadarDevice2RFInitApllcalUpdate.Location = new Point(328, 53);
			this.m_lblRadarDevice2RFInitApllcalUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RFInitApllcalUpdate.Name = "m_lblRadarDevice2RFInitApllcalUpdate";
			this.m_lblRadarDevice2RFInitApllcalUpdate.Size = new Size(18, 17);
			this.m_lblRadarDevice2RFInitApllcalUpdate.TabIndex = 111;
			this.m_lblRadarDevice2RFInitApllcalUpdate.Text = "N";
			this.f00015f.AutoSize = true;
			this.f00015f.Location = new Point(195, 322);
			this.f00015f.Margin = new Padding(4, 0, 4, 0);
			this.f00015f.Name = "m_lblRxIQMMUpdate";
			this.f00015f.Size = new Size(18, 17);
			this.f00015f.TabIndex = 108;
			this.f00015f.Text = "N";
			this.m_lblRxGainUpdate.AutoSize = true;
			this.m_lblRxGainUpdate.Location = new Point(195, 274);
			this.m_lblRxGainUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRxGainUpdate.Name = "m_lblRxGainUpdate";
			this.m_lblRxGainUpdate.Size = new Size(18, 17);
			this.m_lblRxGainUpdate.TabIndex = 106;
			this.m_lblRxGainUpdate.Text = "N";
			this.m_lblRFTxPowerUpdate.AutoSize = true;
			this.m_lblRFTxPowerUpdate.Location = new Point(195, 250);
			this.m_lblRFTxPowerUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRFTxPowerUpdate.Name = "m_lblRFTxPowerUpdate";
			this.m_lblRFTxPowerUpdate.Size = new Size(18, 17);
			this.m_lblRFTxPowerUpdate.TabIndex = 105;
			this.m_lblRFTxPowerUpdate.Text = "N";
			this.m_lblPeakDetectorUpdate.AutoSize = true;
			this.m_lblPeakDetectorUpdate.Location = new Point(195, 225);
			this.m_lblPeakDetectorUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblPeakDetectorUpdate.Name = "m_lblPeakDetectorUpdate";
			this.m_lblPeakDetectorUpdate.Size = new Size(18, 17);
			this.m_lblPeakDetectorUpdate.TabIndex = 104;
			this.m_lblPeakDetectorUpdate.Text = "N";
			this.f000160.AutoSize = true;
			this.f000160.Location = new Point(195, 201);
			this.f000160.Margin = new Padding(4, 0, 4, 0);
			this.f000160.Name = "m_lblRFInitLPFUpdate";
			this.f000160.Size = new Size(18, 17);
			this.f000160.TabIndex = 103;
			this.f000160.Text = "N";
			this.f000161.AutoSize = true;
			this.f000161.Location = new Point(195, 176);
			this.f000161.Margin = new Padding(4, 0, 4, 0);
			this.f000161.Name = "m_lblRFInitHPFUpdate";
			this.f000161.Size = new Size(18, 17);
			this.f000161.TabIndex = 102;
			this.f000161.Text = "N";
			this.f000162.AutoSize = true;
			this.f000162.Location = new Point(195, 151);
			this.f000162.Margin = new Padding(4, 0, 4, 0);
			this.f000162.Name = "m_lblRFInitRXADC_DCUpdate";
			this.f000162.Size = new Size(18, 17);
			this.f000162.TabIndex = 101;
			this.f000162.Text = "N";
			this.f000163.AutoSize = true;
			this.f000163.Location = new Point(195, 127);
			this.f000163.Margin = new Padding(4, 0, 4, 0);
			this.f000163.Name = "m_lblRFInitLODistUpdate";
			this.f000163.Size = new Size(18, 17);
			this.f000163.TabIndex = 100;
			this.f000163.Text = "N";
			this.f000164.AutoSize = true;
			this.f000164.Location = new Point(195, 102);
			this.f000164.Margin = new Padding(4, 0, 4, 0);
			this.f000164.Name = "m_lblRFInitVCO2Update";
			this.f000164.Size = new Size(18, 17);
			this.f000164.TabIndex = 99;
			this.f000164.Text = "N";
			this.f000165.AutoSize = true;
			this.f000165.Location = new Point(195, 78);
			this.f000165.Margin = new Padding(4, 0, 4, 0);
			this.f000165.Name = "m_lblRFInitVCOUpdate";
			this.f000165.Size = new Size(18, 17);
			this.f000165.TabIndex = 98;
			this.f000165.Text = "N";
			this.m_lblRFInitApllcalUpdate.AutoSize = true;
			this.m_lblRFInitApllcalUpdate.Location = new Point(195, 53);
			this.m_lblRFInitApllcalUpdate.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRFInitApllcalUpdate.Name = "m_lblRFInitApllcalUpdate";
			this.m_lblRFInitApllcalUpdate.Size = new Size(18, 17);
			this.m_lblRFInitApllcalUpdate.TabIndex = 97;
			this.m_lblRFInitApllcalUpdate.Text = "N";
			this.m_lblTimeStamp.AutoSize = true;
			this.m_lblTimeStamp.Location = new Point(140, 372);
			this.m_lblTimeStamp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblTimeStamp.Name = "m_lblTimeStamp";
			this.m_lblTimeStamp.Size = new Size(16, 17);
			this.m_lblTimeStamp.TabIndex = 96;
			this.m_lblTimeStamp.Text = "0";
			this.m_lblTemperature.AutoSize = true;
			this.m_lblTemperature.Location = new Point(140, 347);
			this.m_lblTemperature.Margin = new Padding(4, 0, 4, 0);
			this.m_lblTemperature.Name = "m_lblTemperature";
			this.m_lblTemperature.Size = new Size(16, 17);
			this.m_lblTemperature.TabIndex = 95;
			this.m_lblTemperature.Text = "0";
			this.label62.AutoSize = true;
			this.label62.ForeColor = SystemColors.HotTrack;
			this.label62.Location = new Point(9, 372);
			this.label62.Margin = new Padding(4, 0, 4, 0);
			this.label62.Name = "label62";
			this.label62.Size = new Size(115, 17);
			this.label62.TabIndex = 94;
			this.label62.Text = "Time Stamp (ms)";
			this.label61.AutoSize = true;
			this.label61.ForeColor = SystemColors.HotTrack;
			this.label61.Location = new Point(9, 347);
			this.label61.Margin = new Padding(4, 0, 4, 0);
			this.label61.Name = "label61";
			this.label61.Size = new Size(119, 17);
			this.label61.TabIndex = 93;
			this.label61.Text = "Temperature (°C)";
			this.f000166.AutoSize = true;
			this.f000166.Location = new Point(557, 322);
			this.f000166.Margin = new Padding(4, 0, 4, 0);
			this.f000166.Name = "m_lblRadarDevice4RxIQMM";
			this.f000166.Size = new Size(16, 17);
			this.f000166.TabIndex = 92;
			this.f000166.Text = "F";
			this.f000167.AutoSize = true;
			this.f000167.Location = new Point(423, 322);
			this.f000167.Margin = new Padding(4, 0, 4, 0);
			this.f000167.Name = "m_lblRadarDevice3RxIQMM";
			this.f000167.Size = new Size(16, 17);
			this.f000167.TabIndex = 91;
			this.f000167.Text = "F";
			this.f000168.AutoSize = true;
			this.f000168.Location = new Point(280, 322);
			this.f000168.Margin = new Padding(4, 0, 4, 0);
			this.f000168.Name = "m_lblRadarDevice2RxIQMM";
			this.f000168.Size = new Size(16, 17);
			this.f000168.TabIndex = 90;
			this.f000168.Text = "F";
			this.f000169.AutoSize = true;
			this.f000169.Location = new Point(140, 322);
			this.f000169.Margin = new Padding(4, 0, 4, 0);
			this.f000169.Name = "m_lblRxIQMM";
			this.f000169.Size = new Size(16, 17);
			this.f000169.TabIndex = 89;
			this.f000169.Text = "F";
			this.m_lblRadarDevice4RxGain.AutoSize = true;
			this.m_lblRadarDevice4RxGain.Location = new Point(557, 274);
			this.m_lblRadarDevice4RxGain.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RxGain.Name = "m_lblRadarDevice4RxGain";
			this.m_lblRadarDevice4RxGain.Size = new Size(16, 17);
			this.m_lblRadarDevice4RxGain.TabIndex = 84;
			this.m_lblRadarDevice4RxGain.Text = "F";
			this.m_lblRadarDevice3RxGain.AutoSize = true;
			this.m_lblRadarDevice3RxGain.Location = new Point(423, 274);
			this.m_lblRadarDevice3RxGain.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RxGain.Name = "m_lblRadarDevice3RxGain";
			this.m_lblRadarDevice3RxGain.Size = new Size(16, 17);
			this.m_lblRadarDevice3RxGain.TabIndex = 83;
			this.m_lblRadarDevice3RxGain.Text = "F";
			this.m_lblRadarDevice2RxGain.AutoSize = true;
			this.m_lblRadarDevice2RxGain.Location = new Point(280, 274);
			this.m_lblRadarDevice2RxGain.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RxGain.Name = "m_lblRadarDevice2RxGain";
			this.m_lblRadarDevice2RxGain.Size = new Size(16, 17);
			this.m_lblRadarDevice2RxGain.TabIndex = 82;
			this.m_lblRadarDevice2RxGain.Text = "F";
			this.m_lblRxGain.AutoSize = true;
			this.m_lblRxGain.Location = new Point(140, 274);
			this.m_lblRxGain.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRxGain.Name = "m_lblRxGain";
			this.m_lblRxGain.Size = new Size(16, 17);
			this.m_lblRxGain.TabIndex = 81;
			this.m_lblRxGain.Text = "F";
			this.m_lblRadarDevice4PeakDetector.AutoSize = true;
			this.m_lblRadarDevice4PeakDetector.Location = new Point(557, 225);
			this.m_lblRadarDevice4PeakDetector.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4PeakDetector.Name = "m_lblRadarDevice4PeakDetector";
			this.m_lblRadarDevice4PeakDetector.Size = new Size(16, 17);
			this.m_lblRadarDevice4PeakDetector.TabIndex = 80;
			this.m_lblRadarDevice4PeakDetector.Text = "F";
			this.m_lblRadarDevice3PeakDetector.AutoSize = true;
			this.m_lblRadarDevice3PeakDetector.Location = new Point(423, 225);
			this.m_lblRadarDevice3PeakDetector.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3PeakDetector.Name = "m_lblRadarDevice3PeakDetector";
			this.m_lblRadarDevice3PeakDetector.Size = new Size(16, 17);
			this.m_lblRadarDevice3PeakDetector.TabIndex = 79;
			this.m_lblRadarDevice3PeakDetector.Text = "F";
			this.m_lblRadarDevice2PeakDetector.AutoSize = true;
			this.m_lblRadarDevice2PeakDetector.Location = new Point(280, 225);
			this.m_lblRadarDevice2PeakDetector.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2PeakDetector.Name = "m_lblRadarDevice2PeakDetector";
			this.m_lblRadarDevice2PeakDetector.Size = new Size(16, 17);
			this.m_lblRadarDevice2PeakDetector.TabIndex = 78;
			this.m_lblRadarDevice2PeakDetector.Text = "F";
			this.m_lblPeakDetector.AutoSize = true;
			this.m_lblPeakDetector.Location = new Point(140, 225);
			this.m_lblPeakDetector.Margin = new Padding(4, 0, 4, 0);
			this.m_lblPeakDetector.Name = "m_lblPeakDetector";
			this.m_lblPeakDetector.Size = new Size(16, 17);
			this.m_lblPeakDetector.TabIndex = 77;
			this.m_lblPeakDetector.Text = "F";
			this.lblRadarDevice4Update.AutoSize = true;
			this.lblRadarDevice4Update.ForeColor = SystemColors.HotTrack;
			this.lblRadarDevice4Update.Location = new Point(596, 32);
			this.lblRadarDevice4Update.Margin = new Padding(4, 0, 4, 0);
			this.lblRadarDevice4Update.Name = "lblRadarDevice4Update";
			this.lblRadarDevice4Update.Size = new Size(62, 17);
			this.lblRadarDevice4Update.TabIndex = 76;
			this.lblRadarDevice4Update.Text = "Updated";
			this.lblRadarDevice4Status.AutoSize = true;
			this.lblRadarDevice4Status.ForeColor = SystemColors.HotTrack;
			this.lblRadarDevice4Status.Location = new Point(540, 32);
			this.lblRadarDevice4Status.Margin = new Padding(4, 0, 4, 0);
			this.lblRadarDevice4Status.Name = "lblRadarDevice4Status";
			this.lblRadarDevice4Status.Size = new Size(48, 17);
			this.lblRadarDevice4Status.TabIndex = 75;
			this.lblRadarDevice4Status.Text = "Status";
			this.lblRadarDevice3Update.AutoSize = true;
			this.lblRadarDevice3Update.ForeColor = SystemColors.HotTrack;
			this.lblRadarDevice3Update.Location = new Point(451, 31);
			this.lblRadarDevice3Update.Margin = new Padding(4, 0, 4, 0);
			this.lblRadarDevice3Update.Name = "lblRadarDevice3Update";
			this.lblRadarDevice3Update.Size = new Size(62, 17);
			this.lblRadarDevice3Update.TabIndex = 74;
			this.lblRadarDevice3Update.Text = "Updated";
			this.lblRadarDevice3Status.AutoSize = true;
			this.lblRadarDevice3Status.ForeColor = SystemColors.HotTrack;
			this.lblRadarDevice3Status.Location = new Point(404, 31);
			this.lblRadarDevice3Status.Margin = new Padding(4, 0, 4, 0);
			this.lblRadarDevice3Status.Name = "lblRadarDevice3Status";
			this.lblRadarDevice3Status.Size = new Size(48, 17);
			this.lblRadarDevice3Status.TabIndex = 73;
			this.lblRadarDevice3Status.Text = "Status";
			this.lblRadarDevice2Update.AutoSize = true;
			this.lblRadarDevice2Update.ForeColor = SystemColors.HotTrack;
			this.lblRadarDevice2Update.Location = new Point(307, 32);
			this.lblRadarDevice2Update.Margin = new Padding(4, 0, 4, 0);
			this.lblRadarDevice2Update.Name = "lblRadarDevice2Update";
			this.lblRadarDevice2Update.Size = new Size(62, 17);
			this.lblRadarDevice2Update.TabIndex = 72;
			this.lblRadarDevice2Update.Text = "Updated";
			this.lblRadarDevice2Status.AutoSize = true;
			this.lblRadarDevice2Status.ForeColor = SystemColors.HotTrack;
			this.lblRadarDevice2Status.Location = new Point(257, 32);
			this.lblRadarDevice2Status.Margin = new Padding(4, 0, 4, 0);
			this.lblRadarDevice2Status.Name = "lblRadarDevice2Status";
			this.lblRadarDevice2Status.Size = new Size(48, 17);
			this.lblRadarDevice2Status.TabIndex = 71;
			this.lblRadarDevice2Status.Text = "Status";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(9, 322);
			this.label13.Margin = new Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new Size(64, 17);
			this.label13.TabIndex = 70;
			this.label13.Text = "Rx IQMM";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(9, 274);
			this.label11.Margin = new Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new Size(58, 17);
			this.label11.TabIndex = 68;
			this.label11.Text = "Rx Gain";
			this.label11.Click += this.label11_Click;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(9, 225);
			this.label10.Margin = new Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new Size(98, 17);
			this.label10.TabIndex = 67;
			this.label10.Text = "Peak Detector";
			this.label39.AutoSize = true;
			this.label39.ForeColor = SystemColors.HotTrack;
			this.label39.Location = new Point(177, 32);
			this.label39.Margin = new Padding(4, 0, 4, 0);
			this.label39.Name = "label39";
			this.label39.Size = new Size(62, 17);
			this.label39.TabIndex = 66;
			this.label39.Text = "Updated";
			this.label38.AutoSize = true;
			this.label38.ForeColor = SystemColors.HotTrack;
			this.label38.Location = new Point(121, 32);
			this.label38.Margin = new Padding(4, 0, 4, 0);
			this.label38.Name = "label38";
			this.label38.Size = new Size(48, 17);
			this.label38.TabIndex = 65;
			this.label38.Text = "Status";
			this.f000132.AutoSize = true;
			this.f000132.Location = new Point(557, 151);
			this.f000132.Margin = new Padding(4, 0, 4, 0);
			this.f000132.Name = "m_lblRadarDevice4RFInitRXADC_DC";
			this.f000132.Size = new Size(16, 17);
			this.f000132.TabIndex = 64;
			this.f000132.Text = "F";
			this.f000133.AutoSize = true;
			this.f000133.Location = new Point(557, 201);
			this.f000133.Margin = new Padding(4, 0, 4, 0);
			this.f000133.Name = "m_lblRadarDevice4RFInitLPF";
			this.f000133.Size = new Size(16, 17);
			this.f000133.TabIndex = 62;
			this.f000133.Text = "F";
			this.m_lblRadarDevice4RFTxPower.AutoSize = true;
			this.m_lblRadarDevice4RFTxPower.Location = new Point(557, 250);
			this.m_lblRadarDevice4RFTxPower.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RFTxPower.Name = "m_lblRadarDevice4RFTxPower";
			this.m_lblRadarDevice4RFTxPower.Size = new Size(16, 17);
			this.m_lblRadarDevice4RFTxPower.TabIndex = 57;
			this.m_lblRadarDevice4RFTxPower.Text = "F";
			this.f000134.AutoSize = true;
			this.f000134.Location = new Point(557, 127);
			this.f000134.Margin = new Padding(4, 0, 4, 0);
			this.f000134.Name = "m_lblRadarDevice4RFInitLODist";
			this.f000134.Size = new Size(16, 17);
			this.f000134.TabIndex = 56;
			this.f000134.Text = "F";
			this.f000135.AutoSize = true;
			this.f000135.Location = new Point(557, 176);
			this.f000135.Margin = new Padding(4, 0, 4, 0);
			this.f000135.Name = "m_lblRadarDevice4RFInitHPF";
			this.f000135.Size = new Size(16, 17);
			this.f000135.TabIndex = 55;
			this.f000135.Text = "F";
			this.f000136.AutoSize = true;
			this.f000136.Location = new Point(557, 102);
			this.f000136.Margin = new Padding(4, 0, 4, 0);
			this.f000136.Name = "m_lblRadarDevice4RFInitVCO2";
			this.f000136.Size = new Size(16, 17);
			this.f000136.TabIndex = 54;
			this.f000136.Text = "F";
			this.f000137.AutoSize = true;
			this.f000137.Location = new Point(557, 78);
			this.f000137.Margin = new Padding(4, 0, 4, 0);
			this.f000137.Name = "m_lblRadarDevice4RFInitVCO";
			this.f000137.Size = new Size(16, 17);
			this.f000137.TabIndex = 53;
			this.f000137.Text = "F";
			this.m_lblRadarDevice4RFInitApllcalStatus.AutoSize = true;
			this.m_lblRadarDevice4RFInitApllcalStatus.Location = new Point(557, 53);
			this.m_lblRadarDevice4RFInitApllcalStatus.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RFInitApllcalStatus.Name = "m_lblRadarDevice4RFInitApllcalStatus";
			this.m_lblRadarDevice4RFInitApllcalStatus.Size = new Size(16, 17);
			this.m_lblRadarDevice4RFInitApllcalStatus.TabIndex = 52;
			this.m_lblRadarDevice4RFInitApllcalStatus.Text = "F";
			this.f000138.AutoSize = true;
			this.f000138.Location = new Point(423, 151);
			this.f000138.Margin = new Padding(4, 0, 4, 0);
			this.f000138.Name = "m_lblRadarDevice3RFInitRXADC_DC";
			this.f000138.Size = new Size(16, 17);
			this.f000138.TabIndex = 51;
			this.f000138.Text = "F";
			this.f000139.AutoSize = true;
			this.f000139.Location = new Point(423, 201);
			this.f000139.Margin = new Padding(4, 0, 4, 0);
			this.f000139.Name = "m_lblRadarDevice3RFInitLPF";
			this.f000139.Size = new Size(16, 17);
			this.f000139.TabIndex = 49;
			this.f000139.Text = "F";
			this.m_lblRadarDevice3RFTxPower.AutoSize = true;
			this.m_lblRadarDevice3RFTxPower.Location = new Point(423, 250);
			this.m_lblRadarDevice3RFTxPower.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RFTxPower.Name = "m_lblRadarDevice3RFTxPower";
			this.m_lblRadarDevice3RFTxPower.Size = new Size(16, 17);
			this.m_lblRadarDevice3RFTxPower.TabIndex = 44;
			this.m_lblRadarDevice3RFTxPower.Text = "F";
			this.f00013a.AutoSize = true;
			this.f00013a.Location = new Point(423, 127);
			this.f00013a.Margin = new Padding(4, 0, 4, 0);
			this.f00013a.Name = "m_lblRadarDevice3RFInitLODist";
			this.f00013a.Size = new Size(16, 17);
			this.f00013a.TabIndex = 43;
			this.f00013a.Text = "F";
			this.f00013b.AutoSize = true;
			this.f00013b.Location = new Point(423, 176);
			this.f00013b.Margin = new Padding(4, 0, 4, 0);
			this.f00013b.Name = "m_lblRadarDevice3RFInitHPF";
			this.f00013b.Size = new Size(16, 17);
			this.f00013b.TabIndex = 42;
			this.f00013b.Text = "F";
			this.f00013c.AutoSize = true;
			this.f00013c.Location = new Point(423, 102);
			this.f00013c.Margin = new Padding(4, 0, 4, 0);
			this.f00013c.Name = "m_lblRadarDevice3RFInitVCO2";
			this.f00013c.Size = new Size(16, 17);
			this.f00013c.TabIndex = 41;
			this.f00013c.Text = "F";
			this.f00013d.AutoSize = true;
			this.f00013d.Location = new Point(423, 78);
			this.f00013d.Margin = new Padding(4, 0, 4, 0);
			this.f00013d.Name = "m_lblRadarDevice3RFInitVCO";
			this.f00013d.Size = new Size(16, 17);
			this.f00013d.TabIndex = 40;
			this.f00013d.Text = "F";
			this.m_lblRadarDevice3RFInitApllcalStatus.AutoSize = true;
			this.m_lblRadarDevice3RFInitApllcalStatus.Location = new Point(423, 53);
			this.m_lblRadarDevice3RFInitApllcalStatus.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RFInitApllcalStatus.Name = "m_lblRadarDevice3RFInitApllcalStatus";
			this.m_lblRadarDevice3RFInitApllcalStatus.Size = new Size(16, 17);
			this.m_lblRadarDevice3RFInitApllcalStatus.TabIndex = 39;
			this.m_lblRadarDevice3RFInitApllcalStatus.Text = "F";
			this.f00013e.AutoSize = true;
			this.f00013e.Location = new Point(280, 151);
			this.f00013e.Margin = new Padding(4, 0, 4, 0);
			this.f00013e.Name = "m_lblRadarDevice2RFInitRXADC_DC";
			this.f00013e.Size = new Size(16, 17);
			this.f00013e.TabIndex = 38;
			this.f00013e.Text = "F";
			this.f00013f.AutoSize = true;
			this.f00013f.Location = new Point(280, 201);
			this.f00013f.Margin = new Padding(4, 0, 4, 0);
			this.f00013f.Name = "m_lblRadarDevice2RFInitLPF";
			this.f00013f.Size = new Size(16, 17);
			this.f00013f.TabIndex = 36;
			this.f00013f.Text = "F";
			this.m_lblRadarDevice2RFTxPower.AutoSize = true;
			this.m_lblRadarDevice2RFTxPower.Location = new Point(280, 250);
			this.m_lblRadarDevice2RFTxPower.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RFTxPower.Name = "m_lblRadarDevice2RFTxPower";
			this.m_lblRadarDevice2RFTxPower.Size = new Size(16, 17);
			this.m_lblRadarDevice2RFTxPower.TabIndex = 31;
			this.m_lblRadarDevice2RFTxPower.Text = "F";
			this.f000140.AutoSize = true;
			this.f000140.Location = new Point(280, 127);
			this.f000140.Margin = new Padding(4, 0, 4, 0);
			this.f000140.Name = "m_lblRadarDevice2RFInitLODist";
			this.f000140.Size = new Size(16, 17);
			this.f000140.TabIndex = 30;
			this.f000140.Text = "F";
			this.f000141.AutoSize = true;
			this.f000141.Location = new Point(280, 176);
			this.f000141.Margin = new Padding(4, 0, 4, 0);
			this.f000141.Name = "m_lblRadarDevice2RFInitHPF";
			this.f000141.Size = new Size(16, 17);
			this.f000141.TabIndex = 29;
			this.f000141.Text = "F";
			this.f000142.AutoSize = true;
			this.f000142.Location = new Point(280, 102);
			this.f000142.Margin = new Padding(4, 0, 4, 0);
			this.f000142.Name = "m_lblRadarDevice2RFInitVCO2";
			this.f000142.Size = new Size(16, 17);
			this.f000142.TabIndex = 28;
			this.f000142.Text = "F";
			this.f000143.AutoSize = true;
			this.f000143.Location = new Point(280, 78);
			this.f000143.Margin = new Padding(4, 0, 4, 0);
			this.f000143.Name = "m_lblRadarDevice2RFInitVCO";
			this.f000143.Size = new Size(16, 17);
			this.f000143.TabIndex = 27;
			this.f000143.Text = "F";
			this.m_lblRadarDevice2RFInitApllcalStatus.AutoSize = true;
			this.m_lblRadarDevice2RFInitApllcalStatus.Location = new Point(280, 53);
			this.m_lblRadarDevice2RFInitApllcalStatus.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RFInitApllcalStatus.Name = "m_lblRadarDevice2RFInitApllcalStatus";
			this.m_lblRadarDevice2RFInitApllcalStatus.Size = new Size(16, 17);
			this.m_lblRadarDevice2RFInitApllcalStatus.TabIndex = 26;
			this.m_lblRadarDevice2RFInitApllcalStatus.Text = "F";
			this.f000144.AutoSize = true;
			this.f000144.Location = new Point(140, 151);
			this.f000144.Margin = new Padding(4, 0, 4, 0);
			this.f000144.Name = "m_lblRFInitRXADC_DC";
			this.f000144.Size = new Size(16, 17);
			this.f000144.TabIndex = 25;
			this.f000144.Text = "F";
			this.f000145.AutoSize = true;
			this.f000145.Location = new Point(140, 201);
			this.f000145.Margin = new Padding(4, 0, 4, 0);
			this.f000145.Name = "m_lblRFInitLPF";
			this.f000145.Size = new Size(16, 17);
			this.f000145.TabIndex = 23;
			this.f000145.Text = "F";
			this.m_lblRFTxPower.AutoSize = true;
			this.m_lblRFTxPower.Location = new Point(140, 250);
			this.m_lblRFTxPower.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRFTxPower.Name = "m_lblRFTxPower";
			this.m_lblRFTxPower.Size = new Size(16, 17);
			this.m_lblRFTxPower.TabIndex = 18;
			this.m_lblRFTxPower.Text = "F";
			this.f000146.AutoSize = true;
			this.f000146.Location = new Point(140, 127);
			this.f000146.Margin = new Padding(4, 0, 4, 0);
			this.f000146.Name = "m_lblRFInitLODist";
			this.f000146.Size = new Size(16, 17);
			this.f000146.TabIndex = 17;
			this.f000146.Text = "F";
			this.f000147.AutoSize = true;
			this.f000147.Location = new Point(140, 176);
			this.f000147.Margin = new Padding(4, 0, 4, 0);
			this.f000147.Name = "m_lblRFInitHPF";
			this.f000147.Size = new Size(16, 17);
			this.f000147.TabIndex = 16;
			this.f000147.Text = "F";
			this.f000148.AutoSize = true;
			this.f000148.Location = new Point(140, 102);
			this.f000148.Margin = new Padding(4, 0, 4, 0);
			this.f000148.Name = "m_lblRFInitVCO2";
			this.f000148.Size = new Size(16, 17);
			this.f000148.TabIndex = 15;
			this.f000148.Text = "F";
			this.f000149.AutoSize = true;
			this.f000149.Location = new Point(140, 78);
			this.f000149.Margin = new Padding(4, 0, 4, 0);
			this.f000149.Name = "m_lblRFInitVCO";
			this.f000149.Size = new Size(16, 17);
			this.f000149.TabIndex = 14;
			this.f000149.Text = "F";
			this.m_lblRFInitApllcalStatus.AutoSize = true;
			this.m_lblRFInitApllcalStatus.Location = new Point(140, 53);
			this.m_lblRFInitApllcalStatus.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRFInitApllcalStatus.Name = "m_lblRFInitApllcalStatus";
			this.m_lblRFInitApllcalStatus.Size = new Size(16, 17);
			this.m_lblRFInitApllcalStatus.TabIndex = 13;
			this.m_lblRFInitApllcalStatus.Text = "F";
			this.label17.AutoSize = true;
			this.label17.Location = new Point(9, 151);
			this.label17.Margin = new Padding(4, 0, 4, 0);
			this.label17.Name = "label17";
			this.label17.Size = new Size(59, 17);
			this.label17.TabIndex = 12;
			this.label17.Text = "ADC DC";
			this.label15.AutoSize = true;
			this.label15.Location = new Point(9, 250);
			this.label15.Margin = new Padding(4, 0, 4, 0);
			this.label15.Name = "label15";
			this.label15.Size = new Size(69, 17);
			this.label15.TabIndex = 9;
			this.label15.Text = "TX Power";
			this.label16.AutoSize = true;
			this.label16.Location = new Point(9, 127);
			this.label16.Margin = new Padding(4, 0, 4, 0);
			this.label16.Name = "label16";
			this.label16.Size = new Size(55, 17);
			this.label16.TabIndex = 8;
			this.label16.Text = "LO Dist";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(9, 201);
			this.label9.Margin = new Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new Size(74, 17);
			this.label9.TabIndex = 7;
			this.label9.Text = "LPF Cutoff";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(9, 176);
			this.label8.Margin = new Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(76, 17);
			this.label8.TabIndex = 3;
			this.label8.Text = "HPF Cutoff";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(9, 102);
			this.label7.Margin = new Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(45, 17);
			this.label7.TabIndex = 2;
			this.label7.Text = "VCO2";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(9, 78);
			this.label6.Margin = new Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new Size(45, 17);
			this.label6.TabIndex = 1;
			this.label6.Text = "VCO1";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(9, 53);
			this.label5.Margin = new Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(70, 17);
			this.label5.TabIndex = 0;
			this.label5.Text = "APLL Cal ";
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_chkPeriodicCalibPDCal);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_chkOneTimeCalibPDCal);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_cboTxPowerCalMode);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.label14);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_chkEnableCalReport);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_nudCalibPeriodicity);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_chkPeriodicCalibRxGain);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_chkPeriodicCalibTxPower);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_chkPeriodicCalibLODist);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_chkOneTimeCalibRxGain);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_chkOneTimeCalibTxPower);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_chkOneTimeCalibLODist);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.m_btnRunTimeCalibCfgSet);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.label3);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.label2);
			this.m_grpRunTimeCalibAndTriggerCfg.Controls.Add(this.label1);
			this.m_grpRunTimeCalibAndTriggerCfg.Location = new Point(965, 30);
			this.m_grpRunTimeCalibAndTriggerCfg.Margin = new Padding(4, 4, 4, 4);
			this.m_grpRunTimeCalibAndTriggerCfg.Name = "m_grpRunTimeCalibAndTriggerCfg";
			this.m_grpRunTimeCalibAndTriggerCfg.Padding = new Padding(4, 4, 4, 4);
			this.m_grpRunTimeCalibAndTriggerCfg.Size = new Size(552, 204);
			this.m_grpRunTimeCalibAndTriggerCfg.TabIndex = 4;
			this.m_grpRunTimeCalibAndTriggerCfg.TabStop = false;
			this.m_grpRunTimeCalibAndTriggerCfg.Text = "Run Time Calibration And Trigger Config";
			this.m_chkPeriodicCalibPDCal.AutoSize = true;
			this.m_chkPeriodicCalibPDCal.Location = new Point(464, 79);
			this.m_chkPeriodicCalibPDCal.Margin = new Padding(4, 4, 4, 4);
			this.m_chkPeriodicCalibPDCal.Name = "m_chkPeriodicCalibPDCal";
			this.m_chkPeriodicCalibPDCal.Size = new Size(73, 21);
			this.m_chkPeriodicCalibPDCal.TabIndex = 15;
			this.m_chkPeriodicCalibPDCal.Text = "PD Cal";
			this.m_chkPeriodicCalibPDCal.UseVisualStyleBackColor = true;
			this.m_chkOneTimeCalibPDCal.AutoSize = true;
			this.m_chkOneTimeCalibPDCal.Location = new Point(464, 39);
			this.m_chkOneTimeCalibPDCal.Margin = new Padding(4, 4, 4, 4);
			this.m_chkOneTimeCalibPDCal.Name = "m_chkOneTimeCalibPDCal";
			this.m_chkOneTimeCalibPDCal.Size = new Size(73, 21);
			this.m_chkOneTimeCalibPDCal.TabIndex = 14;
			this.m_chkOneTimeCalibPDCal.Text = "PD Cal";
			this.m_chkOneTimeCalibPDCal.UseVisualStyleBackColor = true;
			this.m_cboTxPowerCalMode.DropDownStyle = ComboBoxStyle.DropDownList;
			this.m_cboTxPowerCalMode.FormattingEnabled = true;
			this.m_cboTxPowerCalMode.Items.AddRange(new object[]
			{
				"OLPC+CLPC",
				"OPLC"
			});
			this.m_cboTxPowerCalMode.Location = new Point(211, 156);
			this.m_cboTxPowerCalMode.Margin = new Padding(4, 4, 4, 4);
			this.m_cboTxPowerCalMode.Name = "m_cboTxPowerCalMode";
			this.m_cboTxPowerCalMode.Size = new Size(99, 24);
			this.m_cboTxPowerCalMode.TabIndex = 13;
			this.label14.AutoSize = true;
			this.label14.Location = new Point(25, 166);
			this.label14.Margin = new Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new Size(129, 17);
			this.label14.TabIndex = 12;
			this.label14.Text = "Tx Power Cal Mode";
			this.m_chkEnableCalReport.AutoSize = true;
			this.m_chkEnableCalReport.Location = new Point(327, 121);
			this.m_chkEnableCalReport.Margin = new Padding(4, 4, 4, 4);
			this.m_chkEnableCalReport.Name = "m_chkEnableCalReport";
			this.m_chkEnableCalReport.Size = new Size(145, 21);
			this.m_chkEnableCalReport.TabIndex = 11;
			this.m_chkEnableCalReport.Text = "Enable Cal Report";
			this.m_chkEnableCalReport.UseVisualStyleBackColor = true;
			this.m_nudCalibPeriodicity.Location = new Point(211, 118);
			this.m_nudCalibPeriodicity.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudCalibPeriodicity = this.m_nudCalibPeriodicity;
			int[] array8 = new int[4];
			array8[0] = 1000;
			nudCalibPeriodicity.Maximum = new decimal(array8);
			this.m_nudCalibPeriodicity.Name = "m_nudCalibPeriodicity";
			this.m_nudCalibPeriodicity.Size = new Size(100, 22);
			this.m_nudCalibPeriodicity.TabIndex = 10;
			NumericUpDown nudCalibPeriodicity2 = this.m_nudCalibPeriodicity;
			int[] array9 = new int[4];
			array9[0] = 25;
			nudCalibPeriodicity2.Value = new decimal(array9);
			this.m_chkPeriodicCalibRxGain.AutoSize = true;
			this.m_chkPeriodicCalibRxGain.Location = new Point(381, 79);
			this.m_chkPeriodicCalibRxGain.Margin = new Padding(4, 4, 4, 4);
			this.m_chkPeriodicCalibRxGain.Name = "m_chkPeriodicCalibRxGain";
			this.m_chkPeriodicCalibRxGain.Size = new Size(80, 21);
			this.m_chkPeriodicCalibRxGain.TabIndex = 9;
			this.m_chkPeriodicCalibRxGain.Text = "Rx Gain";
			this.m_chkPeriodicCalibRxGain.UseVisualStyleBackColor = true;
			this.m_chkPeriodicCalibTxPower.AutoSize = true;
			this.m_chkPeriodicCalibTxPower.Location = new Point(289, 79);
			this.m_chkPeriodicCalibTxPower.Margin = new Padding(4, 4, 4, 4);
			this.m_chkPeriodicCalibTxPower.Name = "m_chkPeriodicCalibTxPower";
			this.m_chkPeriodicCalibTxPower.Size = new Size(88, 21);
			this.m_chkPeriodicCalibTxPower.TabIndex = 8;
			this.m_chkPeriodicCalibTxPower.Text = "Tx Power";
			this.m_chkPeriodicCalibTxPower.UseVisualStyleBackColor = true;
			this.m_chkPeriodicCalibLODist.AutoSize = true;
			this.m_chkPeriodicCalibLODist.Location = new Point(211, 79);
			this.m_chkPeriodicCalibLODist.Margin = new Padding(4, 4, 4, 4);
			this.m_chkPeriodicCalibLODist.Name = "m_chkPeriodicCalibLODist";
			this.m_chkPeriodicCalibLODist.Size = new Size(73, 21);
			this.m_chkPeriodicCalibLODist.TabIndex = 7;
			this.m_chkPeriodicCalibLODist.Text = "LODist";
			this.m_chkPeriodicCalibLODist.UseVisualStyleBackColor = true;
			this.m_chkOneTimeCalibRxGain.AutoSize = true;
			this.m_chkOneTimeCalibRxGain.Location = new Point(381, 39);
			this.m_chkOneTimeCalibRxGain.Margin = new Padding(4, 4, 4, 4);
			this.m_chkOneTimeCalibRxGain.Name = "m_chkOneTimeCalibRxGain";
			this.m_chkOneTimeCalibRxGain.Size = new Size(80, 21);
			this.m_chkOneTimeCalibRxGain.TabIndex = 6;
			this.m_chkOneTimeCalibRxGain.Text = "Rx Gain";
			this.m_chkOneTimeCalibRxGain.UseVisualStyleBackColor = true;
			this.m_chkOneTimeCalibTxPower.AutoSize = true;
			this.m_chkOneTimeCalibTxPower.Location = new Point(289, 39);
			this.m_chkOneTimeCalibTxPower.Margin = new Padding(4, 4, 4, 4);
			this.m_chkOneTimeCalibTxPower.Name = "m_chkOneTimeCalibTxPower";
			this.m_chkOneTimeCalibTxPower.Size = new Size(88, 21);
			this.m_chkOneTimeCalibTxPower.TabIndex = 5;
			this.m_chkOneTimeCalibTxPower.Text = "Tx Power";
			this.m_chkOneTimeCalibTxPower.UseVisualStyleBackColor = true;
			this.m_chkOneTimeCalibLODist.AutoSize = true;
			this.m_chkOneTimeCalibLODist.Location = new Point(211, 41);
			this.m_chkOneTimeCalibLODist.Margin = new Padding(4, 4, 4, 4);
			this.m_chkOneTimeCalibLODist.Name = "m_chkOneTimeCalibLODist";
			this.m_chkOneTimeCalibLODist.Size = new Size(73, 21);
			this.m_chkOneTimeCalibLODist.TabIndex = 4;
			this.m_chkOneTimeCalibLODist.Text = "LODist";
			this.m_chkOneTimeCalibLODist.UseVisualStyleBackColor = true;
			this.m_btnRunTimeCalibCfgSet.Location = new Point(429, 156);
			this.m_btnRunTimeCalibCfgSet.Margin = new Padding(4, 4, 4, 4);
			this.m_btnRunTimeCalibCfgSet.Name = "m_btnRunTimeCalibCfgSet";
			this.m_btnRunTimeCalibCfgSet.Size = new Size(100, 34);
			this.m_btnRunTimeCalibCfgSet.TabIndex = 3;
			this.m_btnRunTimeCalibCfgSet.Text = "Set";
			this.m_btnRunTimeCalibCfgSet.UseVisualStyleBackColor = true;
			this.m_btnRunTimeCalibCfgSet.Click += this.m_btnRunTimeCalibCfgSet_Click;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(21, 118);
			this.label3.Margin = new Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(108, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Calib Periodicity";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(21, 79);
			this.label2.Margin = new Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(152, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Periodic Calib En Mask";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(21, 42);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(163, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "One Time Calib En Mask";
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimePDCal2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label40);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimePDCal);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label18);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice4RunTimeTemp);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice3RunTimeTemp);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeTemp);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeTemp);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice4RunTimeTimeStamp);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice3RunTimeTimeStamp);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeTimeStamp);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeTimeStamp);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice4RunTimeRxGain2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice3RunTimeRxGain2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeRxGain2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeRxGain2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice4RunTimeTxPower2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice3RunTimeTxPower2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeTxPower2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeTxPower2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeLODist4);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeLODist3);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeLODist2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeLODist2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblrRadarDevice4RunTimeVCO2Update);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblrRadarDevice3RunTimeVCO2Update);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblrRadarDevice2RunTimeVCO2Update);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeVCO2Update);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.f00014a);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.f00014b);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.f00014c);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeVCO22);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice4RunTimeApllcalStatus4);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice3RunTimeApllcalStatus3);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeApllcalStatus2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeApllcalStatus2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice4RunTimeRxGain);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice3RunTimeRxGain);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeRxGain);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeRxGain);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice4RunTimeTxPower);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice3RunTimeTxPower);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeTxPower);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeTxPower);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice4RunTimeLODist);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice3RunTimeLODist);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeLODist);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeLODist);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblrRadarDevice4RunTimeVCO2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblrRadarDevice3RunTimeVCO2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblrRadarDevice2RunTimeVCO2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeVCO2);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblrRadarDevice4RunTimeVCO);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblrRadarDevice3RunTimeVCO);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblrRadarDevice2RunTimeVCO);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeVCO);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice4RunTimeApllcalStatus);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice3RunTimeApllcalStatus);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRadarDevice2RunTimeApllcalStatus);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.m_lblRunTimeApllcalStatus);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label37);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label36);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label35);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label34);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label33);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label32);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label31);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label30);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label29);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label28);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label27);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label26);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label25);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label24);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label23);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Controls.Add(this.label22);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Location = new Point(981, 245);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Margin = new Padding(4, 4, 4, 4);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Name = "m_grpRunTimeCalibAndTriggerReportCfg";
			this.m_grpRunTimeCalibAndTriggerReportCfg.Padding = new Padding(4, 4, 4, 4);
			this.m_grpRunTimeCalibAndTriggerReportCfg.Size = new Size(543, 393);
			this.m_grpRunTimeCalibAndTriggerReportCfg.TabIndex = 5;
			this.m_grpRunTimeCalibAndTriggerReportCfg.TabStop = false;
			this.m_grpRunTimeCalibAndTriggerReportCfg.Text = "Run Time Calibration Report";
			this.m_lblRunTimePDCal2.AutoSize = true;
			this.m_lblRunTimePDCal2.Location = new Point(173, 278);
			this.m_lblRunTimePDCal2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimePDCal2.Name = "m_lblRunTimePDCal2";
			this.m_lblRunTimePDCal2.Size = new Size(18, 17);
			this.m_lblRunTimePDCal2.TabIndex = 75;
			this.m_lblRunTimePDCal2.Text = "N";
			this.label40.AutoSize = true;
			this.label40.Location = new Point(73, 278);
			this.label40.Margin = new Padding(4, 0, 4, 0);
			this.label40.Name = "label40";
			this.label40.Size = new Size(51, 17);
			this.label40.TabIndex = 74;
			this.label40.Text = "PD Cal";
			this.m_lblRunTimePDCal.AutoSize = true;
			this.m_lblRunTimePDCal.Location = new Point(173, 106);
			this.m_lblRunTimePDCal.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimePDCal.Name = "m_lblRunTimePDCal";
			this.m_lblRunTimePDCal.Size = new Size(16, 17);
			this.m_lblRunTimePDCal.TabIndex = 73;
			this.m_lblRunTimePDCal.Text = "F";
			this.label18.AutoSize = true;
			this.label18.Location = new Point(73, 106);
			this.label18.Margin = new Padding(4, 0, 4, 0);
			this.label18.Name = "label18";
			this.label18.Size = new Size(51, 17);
			this.label18.TabIndex = 72;
			this.label18.Text = "PD Cal";
			this.m_lblRadarDevice4RunTimeTemp.AutoSize = true;
			this.m_lblRadarDevice4RunTimeTemp.Location = new Point(460, 342);
			this.m_lblRadarDevice4RunTimeTemp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RunTimeTemp.Name = "m_lblRadarDevice4RunTimeTemp";
			this.m_lblRadarDevice4RunTimeTemp.Size = new Size(16, 17);
			this.m_lblRadarDevice4RunTimeTemp.TabIndex = 71;
			this.m_lblRadarDevice4RunTimeTemp.Text = "0";
			this.m_lblRadarDevice3RunTimeTemp.AutoSize = true;
			this.m_lblRadarDevice3RunTimeTemp.Location = new Point(375, 342);
			this.m_lblRadarDevice3RunTimeTemp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RunTimeTemp.Name = "m_lblRadarDevice3RunTimeTemp";
			this.m_lblRadarDevice3RunTimeTemp.Size = new Size(16, 17);
			this.m_lblRadarDevice3RunTimeTemp.TabIndex = 70;
			this.m_lblRadarDevice3RunTimeTemp.Text = "0";
			this.m_lblRadarDevice2RunTimeTemp.AutoSize = true;
			this.m_lblRadarDevice2RunTimeTemp.Location = new Point(275, 342);
			this.m_lblRadarDevice2RunTimeTemp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeTemp.Name = "m_lblRadarDevice2RunTimeTemp";
			this.m_lblRadarDevice2RunTimeTemp.Size = new Size(16, 17);
			this.m_lblRadarDevice2RunTimeTemp.TabIndex = 69;
			this.m_lblRadarDevice2RunTimeTemp.Text = "0";
			this.m_lblRunTimeTemp.AutoSize = true;
			this.m_lblRunTimeTemp.Location = new Point(173, 342);
			this.m_lblRunTimeTemp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeTemp.Name = "m_lblRunTimeTemp";
			this.m_lblRunTimeTemp.Size = new Size(16, 17);
			this.m_lblRunTimeTemp.TabIndex = 68;
			this.m_lblRunTimeTemp.Text = "0";
			this.m_lblRadarDevice4RunTimeTimeStamp.AutoSize = true;
			this.m_lblRadarDevice4RunTimeTimeStamp.Location = new Point(460, 367);
			this.m_lblRadarDevice4RunTimeTimeStamp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RunTimeTimeStamp.Name = "m_lblRadarDevice4RunTimeTimeStamp";
			this.m_lblRadarDevice4RunTimeTimeStamp.Size = new Size(16, 17);
			this.m_lblRadarDevice4RunTimeTimeStamp.TabIndex = 67;
			this.m_lblRadarDevice4RunTimeTimeStamp.Text = "0";
			this.m_lblRadarDevice3RunTimeTimeStamp.AutoSize = true;
			this.m_lblRadarDevice3RunTimeTimeStamp.Location = new Point(375, 367);
			this.m_lblRadarDevice3RunTimeTimeStamp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RunTimeTimeStamp.Name = "m_lblRadarDevice3RunTimeTimeStamp";
			this.m_lblRadarDevice3RunTimeTimeStamp.Size = new Size(16, 17);
			this.m_lblRadarDevice3RunTimeTimeStamp.TabIndex = 66;
			this.m_lblRadarDevice3RunTimeTimeStamp.Text = "0";
			this.m_lblRadarDevice2RunTimeTimeStamp.AutoSize = true;
			this.m_lblRadarDevice2RunTimeTimeStamp.Location = new Point(275, 367);
			this.m_lblRadarDevice2RunTimeTimeStamp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeTimeStamp.Name = "m_lblRadarDevice2RunTimeTimeStamp";
			this.m_lblRadarDevice2RunTimeTimeStamp.Size = new Size(16, 17);
			this.m_lblRadarDevice2RunTimeTimeStamp.TabIndex = 65;
			this.m_lblRadarDevice2RunTimeTimeStamp.Text = "0";
			this.m_lblRunTimeTimeStamp.AutoSize = true;
			this.m_lblRunTimeTimeStamp.Location = new Point(173, 367);
			this.m_lblRunTimeTimeStamp.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeTimeStamp.Name = "m_lblRunTimeTimeStamp";
			this.m_lblRunTimeTimeStamp.Size = new Size(16, 17);
			this.m_lblRunTimeTimeStamp.TabIndex = 64;
			this.m_lblRunTimeTimeStamp.Text = "0";
			this.m_lblRadarDevice4RunTimeRxGain2.AutoSize = true;
			this.m_lblRadarDevice4RunTimeRxGain2.Location = new Point(460, 321);
			this.m_lblRadarDevice4RunTimeRxGain2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RunTimeRxGain2.Name = "m_lblRadarDevice4RunTimeRxGain2";
			this.m_lblRadarDevice4RunTimeRxGain2.Size = new Size(18, 17);
			this.m_lblRadarDevice4RunTimeRxGain2.TabIndex = 63;
			this.m_lblRadarDevice4RunTimeRxGain2.Text = "N";
			this.m_lblRadarDevice3RunTimeRxGain2.AutoSize = true;
			this.m_lblRadarDevice3RunTimeRxGain2.Location = new Point(375, 321);
			this.m_lblRadarDevice3RunTimeRxGain2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RunTimeRxGain2.Name = "m_lblRadarDevice3RunTimeRxGain2";
			this.m_lblRadarDevice3RunTimeRxGain2.Size = new Size(18, 17);
			this.m_lblRadarDevice3RunTimeRxGain2.TabIndex = 62;
			this.m_lblRadarDevice3RunTimeRxGain2.Text = "N";
			this.m_lblRadarDevice2RunTimeRxGain2.AutoSize = true;
			this.m_lblRadarDevice2RunTimeRxGain2.Location = new Point(275, 321);
			this.m_lblRadarDevice2RunTimeRxGain2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeRxGain2.Name = "m_lblRadarDevice2RunTimeRxGain2";
			this.m_lblRadarDevice2RunTimeRxGain2.Size = new Size(18, 17);
			this.m_lblRadarDevice2RunTimeRxGain2.TabIndex = 61;
			this.m_lblRadarDevice2RunTimeRxGain2.Text = "N";
			this.m_lblRunTimeRxGain2.AutoSize = true;
			this.m_lblRunTimeRxGain2.Location = new Point(173, 321);
			this.m_lblRunTimeRxGain2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeRxGain2.Name = "m_lblRunTimeRxGain2";
			this.m_lblRunTimeRxGain2.Size = new Size(18, 17);
			this.m_lblRunTimeRxGain2.TabIndex = 60;
			this.m_lblRunTimeRxGain2.Text = "N";
			this.m_lblRadarDevice4RunTimeTxPower2.AutoSize = true;
			this.m_lblRadarDevice4RunTimeTxPower2.Location = new Point(460, 299);
			this.m_lblRadarDevice4RunTimeTxPower2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RunTimeTxPower2.Name = "m_lblRadarDevice4RunTimeTxPower2";
			this.m_lblRadarDevice4RunTimeTxPower2.Size = new Size(18, 17);
			this.m_lblRadarDevice4RunTimeTxPower2.TabIndex = 59;
			this.m_lblRadarDevice4RunTimeTxPower2.Text = "N";
			this.m_lblRadarDevice3RunTimeTxPower2.AutoSize = true;
			this.m_lblRadarDevice3RunTimeTxPower2.Location = new Point(375, 299);
			this.m_lblRadarDevice3RunTimeTxPower2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RunTimeTxPower2.Name = "m_lblRadarDevice3RunTimeTxPower2";
			this.m_lblRadarDevice3RunTimeTxPower2.Size = new Size(18, 17);
			this.m_lblRadarDevice3RunTimeTxPower2.TabIndex = 58;
			this.m_lblRadarDevice3RunTimeTxPower2.Text = "N";
			this.m_lblRadarDevice2RunTimeTxPower2.AutoSize = true;
			this.m_lblRadarDevice2RunTimeTxPower2.Location = new Point(275, 299);
			this.m_lblRadarDevice2RunTimeTxPower2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeTxPower2.Name = "m_lblRadarDevice2RunTimeTxPower2";
			this.m_lblRadarDevice2RunTimeTxPower2.Size = new Size(18, 17);
			this.m_lblRadarDevice2RunTimeTxPower2.TabIndex = 57;
			this.m_lblRadarDevice2RunTimeTxPower2.Text = "N";
			this.m_lblRunTimeTxPower2.AutoSize = true;
			this.m_lblRunTimeTxPower2.Location = new Point(173, 299);
			this.m_lblRunTimeTxPower2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeTxPower2.Name = "m_lblRunTimeTxPower2";
			this.m_lblRunTimeTxPower2.Size = new Size(18, 17);
			this.m_lblRunTimeTxPower2.TabIndex = 56;
			this.m_lblRunTimeTxPower2.Text = "N";
			this.m_lblRadarDevice2RunTimeLODist4.AutoSize = true;
			this.m_lblRadarDevice2RunTimeLODist4.Location = new Point(460, 260);
			this.m_lblRadarDevice2RunTimeLODist4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeLODist4.Name = "m_lblRadarDevice2RunTimeLODist4";
			this.m_lblRadarDevice2RunTimeLODist4.Size = new Size(18, 17);
			this.m_lblRadarDevice2RunTimeLODist4.TabIndex = 55;
			this.m_lblRadarDevice2RunTimeLODist4.Text = "N";
			this.m_lblRadarDevice2RunTimeLODist3.AutoSize = true;
			this.m_lblRadarDevice2RunTimeLODist3.Location = new Point(375, 260);
			this.m_lblRadarDevice2RunTimeLODist3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeLODist3.Name = "m_lblRadarDevice2RunTimeLODist3";
			this.m_lblRadarDevice2RunTimeLODist3.Size = new Size(18, 17);
			this.m_lblRadarDevice2RunTimeLODist3.TabIndex = 54;
			this.m_lblRadarDevice2RunTimeLODist3.Text = "N";
			this.m_lblRadarDevice2RunTimeLODist2.AutoSize = true;
			this.m_lblRadarDevice2RunTimeLODist2.Location = new Point(275, 260);
			this.m_lblRadarDevice2RunTimeLODist2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeLODist2.Name = "m_lblRadarDevice2RunTimeLODist2";
			this.m_lblRadarDevice2RunTimeLODist2.Size = new Size(18, 17);
			this.m_lblRadarDevice2RunTimeLODist2.TabIndex = 53;
			this.m_lblRadarDevice2RunTimeLODist2.Text = "N";
			this.m_lblRunTimeLODist2.AutoSize = true;
			this.m_lblRunTimeLODist2.Location = new Point(173, 256);
			this.m_lblRunTimeLODist2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeLODist2.Name = "m_lblRunTimeLODist2";
			this.m_lblRunTimeLODist2.Size = new Size(18, 17);
			this.m_lblRunTimeLODist2.TabIndex = 52;
			this.m_lblRunTimeLODist2.Text = "N";
			this.m_lblrRadarDevice4RunTimeVCO2Update.AutoSize = true;
			this.m_lblrRadarDevice4RunTimeVCO2Update.Location = new Point(460, 235);
			this.m_lblrRadarDevice4RunTimeVCO2Update.Margin = new Padding(4, 0, 4, 0);
			this.m_lblrRadarDevice4RunTimeVCO2Update.Name = "m_lblrRadarDevice4RunTimeVCO2Update";
			this.m_lblrRadarDevice4RunTimeVCO2Update.Size = new Size(18, 17);
			this.m_lblrRadarDevice4RunTimeVCO2Update.TabIndex = 51;
			this.m_lblrRadarDevice4RunTimeVCO2Update.Text = "N";
			this.m_lblrRadarDevice3RunTimeVCO2Update.AutoSize = true;
			this.m_lblrRadarDevice3RunTimeVCO2Update.Location = new Point(375, 235);
			this.m_lblrRadarDevice3RunTimeVCO2Update.Margin = new Padding(4, 0, 4, 0);
			this.m_lblrRadarDevice3RunTimeVCO2Update.Name = "m_lblrRadarDevice3RunTimeVCO2Update";
			this.m_lblrRadarDevice3RunTimeVCO2Update.Size = new Size(18, 17);
			this.m_lblrRadarDevice3RunTimeVCO2Update.TabIndex = 50;
			this.m_lblrRadarDevice3RunTimeVCO2Update.Text = "N";
			this.m_lblrRadarDevice2RunTimeVCO2Update.AutoSize = true;
			this.m_lblrRadarDevice2RunTimeVCO2Update.Location = new Point(275, 235);
			this.m_lblrRadarDevice2RunTimeVCO2Update.Margin = new Padding(4, 0, 4, 0);
			this.m_lblrRadarDevice2RunTimeVCO2Update.Name = "m_lblrRadarDevice2RunTimeVCO2Update";
			this.m_lblrRadarDevice2RunTimeVCO2Update.Size = new Size(18, 17);
			this.m_lblrRadarDevice2RunTimeVCO2Update.TabIndex = 49;
			this.m_lblrRadarDevice2RunTimeVCO2Update.Text = "N";
			this.m_lblRunTimeVCO2Update.AutoSize = true;
			this.m_lblRunTimeVCO2Update.Location = new Point(173, 235);
			this.m_lblRunTimeVCO2Update.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeVCO2Update.Name = "m_lblRunTimeVCO2Update";
			this.m_lblRunTimeVCO2Update.Size = new Size(18, 17);
			this.m_lblRunTimeVCO2Update.TabIndex = 48;
			this.m_lblRunTimeVCO2Update.Text = "N";
			this.f00014a.AutoSize = true;
			this.f00014a.Location = new Point(460, 212);
			this.f00014a.Margin = new Padding(4, 0, 4, 0);
			this.f00014a.Name = "m_lblrRadarDevice4RunTimeVCOU2";
			this.f00014a.Size = new Size(18, 17);
			this.f00014a.TabIndex = 47;
			this.f00014a.Text = "N";
			this.f00014b.AutoSize = true;
			this.f00014b.Location = new Point(375, 212);
			this.f00014b.Margin = new Padding(4, 0, 4, 0);
			this.f00014b.Name = "m_lblrRadarDevice3RunTimeVCOU2";
			this.f00014b.Size = new Size(18, 17);
			this.f00014b.TabIndex = 46;
			this.f00014b.Text = "N";
			this.f00014c.AutoSize = true;
			this.f00014c.Location = new Point(275, 212);
			this.f00014c.Margin = new Padding(4, 0, 4, 0);
			this.f00014c.Name = "m_lblrRadarDevice2RunTimeVCOU2";
			this.f00014c.Size = new Size(18, 17);
			this.f00014c.TabIndex = 45;
			this.f00014c.Text = "N";
			this.m_lblRunTimeVCO22.AutoSize = true;
			this.m_lblRunTimeVCO22.Location = new Point(173, 212);
			this.m_lblRunTimeVCO22.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeVCO22.Name = "m_lblRunTimeVCO22";
			this.m_lblRunTimeVCO22.Size = new Size(18, 17);
			this.m_lblRunTimeVCO22.TabIndex = 44;
			this.m_lblRunTimeVCO22.Text = "N";
			this.m_lblRadarDevice4RunTimeApllcalStatus4.AutoSize = true;
			this.m_lblRadarDevice4RunTimeApllcalStatus4.Location = new Point(460, 187);
			this.m_lblRadarDevice4RunTimeApllcalStatus4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RunTimeApllcalStatus4.Name = "m_lblRadarDevice4RunTimeApllcalStatus4";
			this.m_lblRadarDevice4RunTimeApllcalStatus4.Size = new Size(18, 17);
			this.m_lblRadarDevice4RunTimeApllcalStatus4.TabIndex = 43;
			this.m_lblRadarDevice4RunTimeApllcalStatus4.Text = "N";
			this.m_lblRadarDevice3RunTimeApllcalStatus3.AutoSize = true;
			this.m_lblRadarDevice3RunTimeApllcalStatus3.Location = new Point(375, 187);
			this.m_lblRadarDevice3RunTimeApllcalStatus3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RunTimeApllcalStatus3.Name = "m_lblRadarDevice3RunTimeApllcalStatus3";
			this.m_lblRadarDevice3RunTimeApllcalStatus3.Size = new Size(18, 17);
			this.m_lblRadarDevice3RunTimeApllcalStatus3.TabIndex = 42;
			this.m_lblRadarDevice3RunTimeApllcalStatus3.Text = "N";
			this.m_lblRadarDevice2RunTimeApllcalStatus2.AutoSize = true;
			this.m_lblRadarDevice2RunTimeApllcalStatus2.Location = new Point(275, 187);
			this.m_lblRadarDevice2RunTimeApllcalStatus2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeApllcalStatus2.Name = "m_lblRadarDevice2RunTimeApllcalStatus2";
			this.m_lblRadarDevice2RunTimeApllcalStatus2.Size = new Size(18, 17);
			this.m_lblRadarDevice2RunTimeApllcalStatus2.TabIndex = 41;
			this.m_lblRadarDevice2RunTimeApllcalStatus2.Text = "N";
			this.m_lblRunTimeApllcalStatus2.AutoSize = true;
			this.m_lblRunTimeApllcalStatus2.Location = new Point(173, 187);
			this.m_lblRunTimeApllcalStatus2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeApllcalStatus2.Name = "m_lblRunTimeApllcalStatus2";
			this.m_lblRunTimeApllcalStatus2.Size = new Size(18, 17);
			this.m_lblRunTimeApllcalStatus2.TabIndex = 40;
			this.m_lblRunTimeApllcalStatus2.Text = "N";
			this.m_lblRadarDevice4RunTimeRxGain.AutoSize = true;
			this.m_lblRadarDevice4RunTimeRxGain.Location = new Point(460, 150);
			this.m_lblRadarDevice4RunTimeRxGain.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RunTimeRxGain.Name = "m_lblRadarDevice4RunTimeRxGain";
			this.m_lblRadarDevice4RunTimeRxGain.Size = new Size(16, 17);
			this.m_lblRadarDevice4RunTimeRxGain.TabIndex = 39;
			this.m_lblRadarDevice4RunTimeRxGain.Text = "F";
			this.m_lblRadarDevice3RunTimeRxGain.AutoSize = true;
			this.m_lblRadarDevice3RunTimeRxGain.Location = new Point(375, 150);
			this.m_lblRadarDevice3RunTimeRxGain.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RunTimeRxGain.Name = "m_lblRadarDevice3RunTimeRxGain";
			this.m_lblRadarDevice3RunTimeRxGain.Size = new Size(16, 17);
			this.m_lblRadarDevice3RunTimeRxGain.TabIndex = 38;
			this.m_lblRadarDevice3RunTimeRxGain.Text = "F";
			this.m_lblRadarDevice2RunTimeRxGain.AutoSize = true;
			this.m_lblRadarDevice2RunTimeRxGain.Location = new Point(275, 150);
			this.m_lblRadarDevice2RunTimeRxGain.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeRxGain.Name = "m_lblRadarDevice2RunTimeRxGain";
			this.m_lblRadarDevice2RunTimeRxGain.Size = new Size(16, 17);
			this.m_lblRadarDevice2RunTimeRxGain.TabIndex = 37;
			this.m_lblRadarDevice2RunTimeRxGain.Text = "F";
			this.m_lblRunTimeRxGain.AutoSize = true;
			this.m_lblRunTimeRxGain.Location = new Point(173, 150);
			this.m_lblRunTimeRxGain.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeRxGain.Name = "m_lblRunTimeRxGain";
			this.m_lblRunTimeRxGain.Size = new Size(16, 17);
			this.m_lblRunTimeRxGain.TabIndex = 36;
			this.m_lblRunTimeRxGain.Text = "F";
			this.m_lblRadarDevice4RunTimeTxPower.AutoSize = true;
			this.m_lblRadarDevice4RunTimeTxPower.Location = new Point(460, 127);
			this.m_lblRadarDevice4RunTimeTxPower.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RunTimeTxPower.Name = "m_lblRadarDevice4RunTimeTxPower";
			this.m_lblRadarDevice4RunTimeTxPower.Size = new Size(16, 17);
			this.m_lblRadarDevice4RunTimeTxPower.TabIndex = 35;
			this.m_lblRadarDevice4RunTimeTxPower.Text = "F";
			this.m_lblRadarDevice3RunTimeTxPower.AutoSize = true;
			this.m_lblRadarDevice3RunTimeTxPower.Location = new Point(375, 127);
			this.m_lblRadarDevice3RunTimeTxPower.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RunTimeTxPower.Name = "m_lblRadarDevice3RunTimeTxPower";
			this.m_lblRadarDevice3RunTimeTxPower.Size = new Size(16, 17);
			this.m_lblRadarDevice3RunTimeTxPower.TabIndex = 34;
			this.m_lblRadarDevice3RunTimeTxPower.Text = "F";
			this.m_lblRadarDevice2RunTimeTxPower.AutoSize = true;
			this.m_lblRadarDevice2RunTimeTxPower.Location = new Point(275, 127);
			this.m_lblRadarDevice2RunTimeTxPower.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeTxPower.Name = "m_lblRadarDevice2RunTimeTxPower";
			this.m_lblRadarDevice2RunTimeTxPower.Size = new Size(16, 17);
			this.m_lblRadarDevice2RunTimeTxPower.TabIndex = 33;
			this.m_lblRadarDevice2RunTimeTxPower.Text = "F";
			this.m_lblRunTimeTxPower.AutoSize = true;
			this.m_lblRunTimeTxPower.Location = new Point(173, 127);
			this.m_lblRunTimeTxPower.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeTxPower.Name = "m_lblRunTimeTxPower";
			this.m_lblRunTimeTxPower.Size = new Size(16, 17);
			this.m_lblRunTimeTxPower.TabIndex = 32;
			this.m_lblRunTimeTxPower.Text = "F";
			this.m_lblRadarDevice4RunTimeLODist.AutoSize = true;
			this.m_lblRadarDevice4RunTimeLODist.Location = new Point(460, 89);
			this.m_lblRadarDevice4RunTimeLODist.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RunTimeLODist.Name = "m_lblRadarDevice4RunTimeLODist";
			this.m_lblRadarDevice4RunTimeLODist.Size = new Size(16, 17);
			this.m_lblRadarDevice4RunTimeLODist.TabIndex = 31;
			this.m_lblRadarDevice4RunTimeLODist.Text = "F";
			this.m_lblRadarDevice3RunTimeLODist.AutoSize = true;
			this.m_lblRadarDevice3RunTimeLODist.Location = new Point(375, 85);
			this.m_lblRadarDevice3RunTimeLODist.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RunTimeLODist.Name = "m_lblRadarDevice3RunTimeLODist";
			this.m_lblRadarDevice3RunTimeLODist.Size = new Size(16, 17);
			this.m_lblRadarDevice3RunTimeLODist.TabIndex = 30;
			this.m_lblRadarDevice3RunTimeLODist.Text = "F";
			this.m_lblRadarDevice2RunTimeLODist.AutoSize = true;
			this.m_lblRadarDevice2RunTimeLODist.Location = new Point(275, 89);
			this.m_lblRadarDevice2RunTimeLODist.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeLODist.Name = "m_lblRadarDevice2RunTimeLODist";
			this.m_lblRadarDevice2RunTimeLODist.Size = new Size(16, 17);
			this.m_lblRadarDevice2RunTimeLODist.TabIndex = 29;
			this.m_lblRadarDevice2RunTimeLODist.Text = "F";
			this.m_lblRunTimeLODist.AutoSize = true;
			this.m_lblRunTimeLODist.Location = new Point(173, 85);
			this.m_lblRunTimeLODist.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeLODist.Name = "m_lblRunTimeLODist";
			this.m_lblRunTimeLODist.Size = new Size(16, 17);
			this.m_lblRunTimeLODist.TabIndex = 28;
			this.m_lblRunTimeLODist.Text = "F";
			this.m_lblrRadarDevice4RunTimeVCO2.AutoSize = true;
			this.m_lblrRadarDevice4RunTimeVCO2.Location = new Point(460, 64);
			this.m_lblrRadarDevice4RunTimeVCO2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblrRadarDevice4RunTimeVCO2.Name = "m_lblrRadarDevice4RunTimeVCO2";
			this.m_lblrRadarDevice4RunTimeVCO2.Size = new Size(16, 17);
			this.m_lblrRadarDevice4RunTimeVCO2.TabIndex = 27;
			this.m_lblrRadarDevice4RunTimeVCO2.Text = "F";
			this.m_lblrRadarDevice3RunTimeVCO2.AutoSize = true;
			this.m_lblrRadarDevice3RunTimeVCO2.Location = new Point(375, 64);
			this.m_lblrRadarDevice3RunTimeVCO2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblrRadarDevice3RunTimeVCO2.Name = "m_lblrRadarDevice3RunTimeVCO2";
			this.m_lblrRadarDevice3RunTimeVCO2.Size = new Size(16, 17);
			this.m_lblrRadarDevice3RunTimeVCO2.TabIndex = 26;
			this.m_lblrRadarDevice3RunTimeVCO2.Text = "F";
			this.m_lblrRadarDevice2RunTimeVCO2.AutoSize = true;
			this.m_lblrRadarDevice2RunTimeVCO2.Location = new Point(275, 64);
			this.m_lblrRadarDevice2RunTimeVCO2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblrRadarDevice2RunTimeVCO2.Name = "m_lblrRadarDevice2RunTimeVCO2";
			this.m_lblrRadarDevice2RunTimeVCO2.Size = new Size(16, 17);
			this.m_lblrRadarDevice2RunTimeVCO2.TabIndex = 25;
			this.m_lblrRadarDevice2RunTimeVCO2.Text = "F";
			this.m_lblRunTimeVCO2.AutoSize = true;
			this.m_lblRunTimeVCO2.Location = new Point(173, 64);
			this.m_lblRunTimeVCO2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeVCO2.Name = "m_lblRunTimeVCO2";
			this.m_lblRunTimeVCO2.Size = new Size(16, 17);
			this.m_lblRunTimeVCO2.TabIndex = 24;
			this.m_lblRunTimeVCO2.Text = "F";
			this.m_lblrRadarDevice4RunTimeVCO.AutoSize = true;
			this.m_lblrRadarDevice4RunTimeVCO.Location = new Point(460, 42);
			this.m_lblrRadarDevice4RunTimeVCO.Margin = new Padding(4, 0, 4, 0);
			this.m_lblrRadarDevice4RunTimeVCO.Name = "m_lblrRadarDevice4RunTimeVCO";
			this.m_lblrRadarDevice4RunTimeVCO.Size = new Size(16, 17);
			this.m_lblrRadarDevice4RunTimeVCO.TabIndex = 23;
			this.m_lblrRadarDevice4RunTimeVCO.Text = "F";
			this.m_lblrRadarDevice3RunTimeVCO.AutoSize = true;
			this.m_lblrRadarDevice3RunTimeVCO.Location = new Point(375, 42);
			this.m_lblrRadarDevice3RunTimeVCO.Margin = new Padding(4, 0, 4, 0);
			this.m_lblrRadarDevice3RunTimeVCO.Name = "m_lblrRadarDevice3RunTimeVCO";
			this.m_lblrRadarDevice3RunTimeVCO.Size = new Size(16, 17);
			this.m_lblrRadarDevice3RunTimeVCO.TabIndex = 22;
			this.m_lblrRadarDevice3RunTimeVCO.Text = "F";
			this.m_lblrRadarDevice2RunTimeVCO.AutoSize = true;
			this.m_lblrRadarDevice2RunTimeVCO.Location = new Point(275, 42);
			this.m_lblrRadarDevice2RunTimeVCO.Margin = new Padding(4, 0, 4, 0);
			this.m_lblrRadarDevice2RunTimeVCO.Name = "m_lblrRadarDevice2RunTimeVCO";
			this.m_lblrRadarDevice2RunTimeVCO.Size = new Size(16, 17);
			this.m_lblrRadarDevice2RunTimeVCO.TabIndex = 21;
			this.m_lblrRadarDevice2RunTimeVCO.Text = "F";
			this.m_lblRunTimeVCO.AutoSize = true;
			this.m_lblRunTimeVCO.Location = new Point(173, 42);
			this.m_lblRunTimeVCO.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeVCO.Name = "m_lblRunTimeVCO";
			this.m_lblRunTimeVCO.Size = new Size(16, 17);
			this.m_lblRunTimeVCO.TabIndex = 20;
			this.m_lblRunTimeVCO.Text = "F";
			this.m_lblRadarDevice4RunTimeApllcalStatus.AutoSize = true;
			this.m_lblRadarDevice4RunTimeApllcalStatus.Location = new Point(460, 23);
			this.m_lblRadarDevice4RunTimeApllcalStatus.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4RunTimeApllcalStatus.Name = "m_lblRadarDevice4RunTimeApllcalStatus";
			this.m_lblRadarDevice4RunTimeApllcalStatus.Size = new Size(16, 17);
			this.m_lblRadarDevice4RunTimeApllcalStatus.TabIndex = 19;
			this.m_lblRadarDevice4RunTimeApllcalStatus.Text = "F";
			this.m_lblRadarDevice3RunTimeApllcalStatus.AutoSize = true;
			this.m_lblRadarDevice3RunTimeApllcalStatus.Location = new Point(375, 23);
			this.m_lblRadarDevice3RunTimeApllcalStatus.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3RunTimeApllcalStatus.Name = "m_lblRadarDevice3RunTimeApllcalStatus";
			this.m_lblRadarDevice3RunTimeApllcalStatus.Size = new Size(16, 17);
			this.m_lblRadarDevice3RunTimeApllcalStatus.TabIndex = 18;
			this.m_lblRadarDevice3RunTimeApllcalStatus.Text = "F";
			this.m_lblRadarDevice2RunTimeApllcalStatus.AutoSize = true;
			this.m_lblRadarDevice2RunTimeApllcalStatus.Location = new Point(275, 23);
			this.m_lblRadarDevice2RunTimeApllcalStatus.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2RunTimeApllcalStatus.Name = "m_lblRadarDevice2RunTimeApllcalStatus";
			this.m_lblRadarDevice2RunTimeApllcalStatus.Size = new Size(16, 17);
			this.m_lblRadarDevice2RunTimeApllcalStatus.TabIndex = 17;
			this.m_lblRadarDevice2RunTimeApllcalStatus.Text = "F";
			this.m_lblRunTimeApllcalStatus.AutoSize = true;
			this.m_lblRunTimeApllcalStatus.Location = new Point(173, 23);
			this.m_lblRunTimeApllcalStatus.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRunTimeApllcalStatus.Name = "m_lblRunTimeApllcalStatus";
			this.m_lblRunTimeApllcalStatus.Size = new Size(16, 17);
			this.m_lblRunTimeApllcalStatus.TabIndex = 16;
			this.m_lblRunTimeApllcalStatus.Text = "F";
			this.label37.AutoSize = true;
			this.label37.Location = new Point(73, 321);
			this.label37.Margin = new Padding(4, 0, 4, 0);
			this.label37.Name = "label37";
			this.label37.Size = new Size(58, 17);
			this.label37.TabIndex = 15;
			this.label37.Text = "Rx Gain";
			this.label36.AutoSize = true;
			this.label36.Location = new Point(73, 299);
			this.label36.Margin = new Padding(4, 0, 4, 0);
			this.label36.Name = "label36";
			this.label36.Size = new Size(66, 17);
			this.label36.TabIndex = 14;
			this.label36.Text = "Tx Power";
			this.label35.AutoSize = true;
			this.label35.Location = new Point(73, 257);
			this.label35.Margin = new Padding(4, 0, 4, 0);
			this.label35.Name = "label35";
			this.label35.Size = new Size(55, 17);
			this.label35.TabIndex = 13;
			this.label35.Text = "LO Dist";
			this.label34.AutoSize = true;
			this.label34.Location = new Point(73, 235);
			this.label34.Margin = new Padding(4, 0, 4, 0);
			this.label34.Name = "label34";
			this.label34.Size = new Size(45, 17);
			this.label34.TabIndex = 12;
			this.label34.Text = "VCO2";
			this.label33.AutoSize = true;
			this.label33.Location = new Point(73, 212);
			this.label33.Margin = new Padding(4, 0, 4, 0);
			this.label33.Name = "label33";
			this.label33.Size = new Size(45, 17);
			this.label33.TabIndex = 11;
			this.label33.Text = "VCO1";
			this.label32.AutoSize = true;
			this.label32.Location = new Point(73, 187);
			this.label32.Margin = new Padding(4, 0, 4, 0);
			this.label32.Name = "label32";
			this.label32.Size = new Size(42, 17);
			this.label32.TabIndex = 10;
			this.label32.Text = "APLL";
			this.label31.AutoSize = true;
			this.label31.Location = new Point(73, 150);
			this.label31.Margin = new Padding(4, 0, 4, 0);
			this.label31.Name = "label31";
			this.label31.Size = new Size(58, 17);
			this.label31.TabIndex = 9;
			this.label31.Text = "Rx Gain";
			this.label30.AutoSize = true;
			this.label30.Location = new Point(73, 127);
			this.label30.Margin = new Padding(4, 0, 4, 0);
			this.label30.Name = "label30";
			this.label30.Size = new Size(66, 17);
			this.label30.TabIndex = 8;
			this.label30.Text = "Tx Power";
			this.label29.AutoSize = true;
			this.label29.Location = new Point(73, 85);
			this.label29.Margin = new Padding(4, 0, 4, 0);
			this.label29.Name = "label29";
			this.label29.Size = new Size(55, 17);
			this.label29.TabIndex = 7;
			this.label29.Text = "LO Dist";
			this.label28.AutoSize = true;
			this.label28.Location = new Point(73, 64);
			this.label28.Margin = new Padding(4, 0, 4, 0);
			this.label28.Name = "label28";
			this.label28.Size = new Size(45, 17);
			this.label28.TabIndex = 6;
			this.label28.Text = "VCO2";
			this.label27.AutoSize = true;
			this.label27.Location = new Point(73, 42);
			this.label27.Margin = new Padding(4, 0, 4, 0);
			this.label27.Name = "label27";
			this.label27.Size = new Size(45, 17);
			this.label27.TabIndex = 5;
			this.label27.Text = "VCO1";
			this.label26.AutoSize = true;
			this.label26.Location = new Point(73, 23);
			this.label26.Margin = new Padding(4, 0, 4, 0);
			this.label26.Name = "label26";
			this.label26.Size = new Size(42, 17);
			this.label26.TabIndex = 4;
			this.label26.Text = "APLL";
			this.label25.AutoSize = true;
			this.label25.ForeColor = SystemColors.HotTrack;
			this.label25.Location = new Point(9, 367);
			this.label25.Margin = new Padding(4, 0, 4, 0);
			this.label25.Name = "label25";
			this.label25.Size = new Size(115, 17);
			this.label25.TabIndex = 3;
			this.label25.Text = "Time Stamp (ms)";
			this.label24.AutoSize = true;
			this.label24.ForeColor = SystemColors.HotTrack;
			this.label24.Location = new Point(9, 342);
			this.label24.Margin = new Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new Size(119, 17);
			this.label24.TabIndex = 2;
			this.label24.Text = "Temperature (°C)";
			this.label23.AutoSize = true;
			this.label23.ForeColor = SystemColors.HotTrack;
			this.label23.Location = new Point(9, 167);
			this.label23.Margin = new Padding(4, 0, 4, 0);
			this.label23.Name = "label23";
			this.label23.Size = new Size(62, 17);
			this.label23.TabIndex = 1;
			this.label23.Text = "Updated";
			this.label22.AutoSize = true;
			this.label22.ForeColor = SystemColors.HotTrack;
			this.label22.Location = new Point(9, 20);
			this.label22.Margin = new Padding(4, 0, 4, 0);
			this.label22.Name = "label22";
			this.label22.Size = new Size(48, 17);
			this.label22.TabIndex = 0;
			this.label22.Text = "Status";
			this.m_chkDisableLogging.AutoSize = true;
			this.m_chkDisableLogging.Location = new Point(21, 163);
			this.m_chkDisableLogging.Name = "m_chkDisableLogging";
			this.m_chkDisableLogging.Size = new Size(202, 21);
			this.m_chkDisableLogging.TabIndex = 7;
			this.m_chkDisableLogging.Text = "Disable Logging of Reports";
			this.m_chkDisableLogging.UseVisualStyleBackColor = true;
			this.m_chkDisableLogging.CheckedChanged += this.m_chkDisableLogging_CheckedChanged;
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.m_grpRunTimeCalibAndTriggerReportCfg);
			base.Controls.Add(this.m_grpRunTimeCalibAndTriggerCfg);
			base.Controls.Add(this.m_grpRFInitCalibReportCfg);
			base.Controls.Add(this.m_grpRFInitCalibCfg);
			base.Controls.Add(this.m_grpTimeUnitReportCfg);
			base.Controls.Add(this.m_grpTimeUnitCfg);
			base.Margin = new Padding(4, 4, 4, 4);
			base.Name = "CalibConfig";
			base.Size = new Size(1619, 654);
			base.Load += this.CalibConfig_Load;
			this.m_grpTimeUnitCfg.ResumeLayout(false);
			this.m_grpTimeUnitCfg.PerformLayout();
			((ISupportInitialize)this.m_nudDeviceId).EndInit();
			((ISupportInitialize)this.m_nudNumCascadeDev).EndInit();
			((ISupportInitialize)this.m_nudTimeUnit).EndInit();
			this.m_grpTimeUnitReportCfg.ResumeLayout(false);
			this.m_grpTimeUnitReportCfg.PerformLayout();
			this.m_grpRFInitCalibCfg.ResumeLayout(false);
			this.m_grpRFInitCalibCfg.PerformLayout();
			this.m_grpRFInitCalibReportCfg.ResumeLayout(false);
			this.m_grpRFInitCalibReportCfg.PerformLayout();
			this.m_grpRunTimeCalibAndTriggerCfg.ResumeLayout(false);
			this.m_grpRunTimeCalibAndTriggerCfg.PerformLayout();
			((ISupportInitialize)this.m_nudCalibPeriodicity).EndInit();
			this.m_grpRunTimeCalibAndTriggerReportCfg.ResumeLayout(false);
			this.m_grpRunTimeCalibAndTriggerReportCfg.PerformLayout();
			base.ResumeLayout(false);
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		private TimeUnitConfigParameters m_TimeUnitConfigParameters;

		private RFInitCalibConfigParameters m_RFInitCalibConfigParameters;

		private RunTimeCalibConfigParameters m_RunTimeCalibConfigParameters;

		private IContainer components;

		private GroupBox m_grpTimeUnitCfg;

		private GroupBox m_grpTimeUnitReportCfg;

		private GroupBox m_grpRFInitCalibCfg;

		private GroupBox m_grpRFInitCalibReportCfg;

		private GroupBox m_grpRunTimeCalibAndTriggerCfg;

		private GroupBox m_grpRunTimeCalibAndTriggerReportCfg;

		private NumericUpDown m_nudDeviceId;

		private NumericUpDown m_nudNumCascadeDev;

		private NumericUpDown m_nudTimeUnit;

		private Button m_btnTimeUnitSet;

		private Label m_lblDeviceId;

		private Label m_lblNumOfCasCadeDev;

		private Label m_lblCalibMonTimeUnit;

		private Button m_btnRunTimeCalibCfgSet;

		private Label label3;

		private Label label2;

		private Label label1;

		private Button m_btnRFInitCalibSet;

		private CheckBox m_chkRxGain;

		private CheckBox m_chkTxPower;

		private CheckBox m_chkPeakDetector;

		private CheckBox m_chkLPFCutoff;

		private CheckBox f000130;

		private CheckBox m_chkHPFCutoff;

		private CheckBox f000131;

		private CheckBox m_chkLODist;

		private Label label4;

		private NumericUpDown m_nudCalibPeriodicity;

		private CheckBox m_chkPeriodicCalibRxGain;

		private CheckBox m_chkPeriodicCalibTxPower;

		private CheckBox m_chkPeriodicCalibLODist;

		private CheckBox m_chkOneTimeCalibRxGain;

		private CheckBox m_chkOneTimeCalibTxPower;

		private CheckBox m_chkOneTimeCalibLODist;

		private Label label15;

		private Label label16;

		private Label label9;

		private Label label8;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label17;

		private Label f000132;

		private Label f000133;

		private Label m_lblRadarDevice4RFTxPower;

		private Label f000134;

		private Label f000135;

		private Label f000136;

		private Label f000137;

		private Label m_lblRadarDevice4RFInitApllcalStatus;

		private Label f000138;

		private Label f000139;

		private Label m_lblRadarDevice3RFTxPower;

		private Label f00013a;

		private Label f00013b;

		private Label f00013c;

		private Label f00013d;

		private Label m_lblRadarDevice3RFInitApllcalStatus;

		private Label f00013e;

		private Label f00013f;

		private Label m_lblRadarDevice2RFTxPower;

		private Label f000140;

		private Label f000141;

		private Label f000142;

		private Label f000143;

		private Label m_lblRadarDevice2RFInitApllcalStatus;

		private Label f000144;

		private Label f000145;

		private Label m_lblRFTxPower;

		private Label f000146;

		private Label f000147;

		private Label f000148;

		private Label f000149;

		private Label m_lblRFInitApllcalStatus;

		private Label label21;

		private Label label20;

		private Label label25;

		private Label label24;

		private Label label23;

		private Label label22;

		private Label m_lblRadarDevice4RunTimeApllcalStatus;

		private Label m_lblRadarDevice3RunTimeApllcalStatus;

		private Label m_lblRadarDevice2RunTimeApllcalStatus;

		private Label m_lblRunTimeApllcalStatus;

		private Label label37;

		private Label label36;

		private Label label35;

		private Label label34;

		private Label label33;

		private Label label32;

		private Label label31;

		private Label label30;

		private Label label29;

		private Label label28;

		private Label label27;

		private Label label26;

		private Label m_lblRadarDevice4RunTimeTemp;

		private Label m_lblRadarDevice3RunTimeTemp;

		private Label m_lblRadarDevice2RunTimeTemp;

		private Label m_lblRunTimeTemp;

		private Label m_lblRadarDevice4RunTimeTimeStamp;

		private Label m_lblRadarDevice3RunTimeTimeStamp;

		private Label m_lblRadarDevice2RunTimeTimeStamp;

		private Label m_lblRunTimeTimeStamp;

		private Label m_lblRadarDevice4RunTimeRxGain2;

		private Label m_lblRadarDevice3RunTimeRxGain2;

		private Label m_lblRadarDevice2RunTimeRxGain2;

		private Label m_lblRunTimeRxGain2;

		private Label m_lblRadarDevice4RunTimeTxPower2;

		private Label m_lblRadarDevice3RunTimeTxPower2;

		private Label m_lblRadarDevice2RunTimeTxPower2;

		private Label m_lblRunTimeTxPower2;

		private Label m_lblRadarDevice2RunTimeLODist4;

		private Label m_lblRadarDevice2RunTimeLODist3;

		private Label m_lblRadarDevice2RunTimeLODist2;

		private Label m_lblRunTimeLODist2;

		private Label m_lblrRadarDevice4RunTimeVCO2Update;

		private Label m_lblrRadarDevice3RunTimeVCO2Update;

		private Label m_lblrRadarDevice2RunTimeVCO2Update;

		private Label m_lblRunTimeVCO2Update;

		private Label f00014a;

		private Label f00014b;

		private Label f00014c;

		private Label m_lblRunTimeVCO22;

		private Label m_lblRadarDevice4RunTimeApllcalStatus4;

		private Label m_lblRadarDevice3RunTimeApllcalStatus3;

		private Label m_lblRadarDevice2RunTimeApllcalStatus2;

		private Label m_lblRunTimeApllcalStatus2;

		private Label m_lblRadarDevice4RunTimeRxGain;

		private Label m_lblRadarDevice3RunTimeRxGain;

		private Label m_lblRadarDevice2RunTimeRxGain;

		private Label m_lblRunTimeRxGain;

		private Label m_lblRadarDevice4RunTimeTxPower;

		private Label m_lblRadarDevice3RunTimeTxPower;

		private Label m_lblRadarDevice2RunTimeTxPower;

		private Label m_lblRunTimeTxPower;

		private Label m_lblRadarDevice4RunTimeLODist;

		private Label m_lblRadarDevice3RunTimeLODist;

		private Label m_lblRadarDevice2RunTimeLODist;

		private Label m_lblRunTimeLODist;

		private Label m_lblrRadarDevice4RunTimeVCO2;

		private Label m_lblrRadarDevice3RunTimeVCO2;

		private Label m_lblrRadarDevice2RunTimeVCO2;

		private Label m_lblRunTimeVCO2;

		private Label m_lblrRadarDevice4RunTimeVCO;

		private Label m_lblrRadarDevice3RunTimeVCO;

		private Label m_lblrRadarDevice2RunTimeVCO;

		private Label m_lblRunTimeVCO;

		private Label m_lblRadarDevice4RunTimingViolation;

		private Label m_lblRadarDevice3RunTimingViolation;

		private Label m_lblRadarDevice2RunTimingViolation;

		private Label m_lblRunTimingViolation;

		private Label m_lblRadarDevice4TotalMonAndCalibTimeFit;

		private Label m_lblRadarDevice3TotalMonAndCalibTimeFit;

		private Label m_lblRadarDevice2TotalMonAndCalibTimeFit;

		private Label m_lblTotalMonAndCalibTimeFit;

		private Label m_lblRadarDevice4TotalMonTimeFit;

		private Label m_lblRadarDevice3TotalMonTimeFit;

		private Label m_lblRadarDevice2TotalMonTimeFit;

		private Label m_lblTotalMonTimeFit;

		private Label label13;

		private Label label11;

		private Label label10;

		private Label label39;

		private Label label38;

		private Label lblRadarDevice2Status;

		private Label m_lblRadarDevice4TimeStamp;

		private Label m_lblRadarDevice4Temperature;

		private Label m_lblRadarDevice3TimeStamp;

		private Label m_lblRadarDevice3Temperature;

		private Label m_lblRadarDevice2TimeStamp;

		private Label m_lblRadarDevice2Temperature;

		private Label f00014d;

		private Label m_lblRadarDevice4RxGainUpdate;

		private Label m_lblRadarDevice4RFTxPowerUpdate;

		private Label m_lblRadarDevice4PeakDetectorUpdate;

		private Label f00014e;

		private Label f00014f;

		private Label f000150;

		private Label m_lblRadarDevice4RFInitLODistUpdate;

		private Label f000151;

		private Label f000152;

		private Label m_lblRadarDevice4RFInitApllcalUpdate;

		private Label f000153;

		private Label m_lblRadarDevice3RxGainUpdate;

		private Label m_lblRadarDevice3RFTxPowerUpdate;

		private Label m_lblRadarDevice3PeakDetectorUpdate;

		private Label f000154;

		private Label f000155;

		private Label f000156;

		private Label m_lblRadarDevice3RFInitLODistUpdate;

		private Label f000157;

		private Label f000158;

		private Label m_lblRadarDevice3RFInitApllcalUpdate;

		private Label f000159;

		private Label m_lblRadarDevice2RxGainUpdate;

		private Label m_lblRadarDevice2RFTxPowerUpdate;

		private Label m_lblRadarDevice2PeakDetectorUpdate;

		private Label f00015a;

		private Label f00015b;

		private Label f00015c;

		private Label m_lblRadarDevice2RFInitLODistUpdate;

		private Label f00015d;

		private Label f00015e;

		private Label m_lblRadarDevice2RFInitApllcalUpdate;

		private Label f00015f;

		private Label m_lblRxGainUpdate;

		private Label m_lblRFTxPowerUpdate;

		private Label m_lblPeakDetectorUpdate;

		private Label f000160;

		private Label f000161;

		private Label f000162;

		private Label f000163;

		private Label f000164;

		private Label f000165;

		private Label m_lblRFInitApllcalUpdate;

		private Label m_lblTimeStamp;

		private Label m_lblTemperature;

		private Label label62;

		private Label label61;

		private Label f000166;

		private Label f000167;

		private Label f000168;

		private Label f000169;

		private Label m_lblRadarDevice4RxGain;

		private Label m_lblRadarDevice3RxGain;

		private Label m_lblRadarDevice2RxGain;

		private Label m_lblRxGain;

		private Label m_lblRadarDevice4PeakDetector;

		private Label m_lblRadarDevice3PeakDetector;

		private Label m_lblRadarDevice2PeakDetector;

		private Label m_lblPeakDetector;

		private Label lblRadarDevice4Update;

		private Label lblRadarDevice4Status;

		private Label lblRadarDevice3Update;

		private Label lblRadarDevice3Status;

		private Label lblRadarDevice2Update;

		private Label label12;

		private Label m_lblRadarDevice4PeriodicMonAndCalibTimeFit;

		private Label m_lblRadarDevice3PeriodicMonAndCalibTimeFit;

		private Label m_lblRadarDevice2PeriodicMonAndCalibTimeFit;

		private Label m_lblPeriodicMonAndCalibTimeFit;

		private CheckBox m_chkEnableCalReport;

		private ComboBox m_cboTxPowerCalMode;

		private Label label14;

		private CheckBox m_chkPeriodicCalibPDCal;

		private CheckBox m_chkOneTimeCalibPDCal;

		private Label m_lblRunTimePDCal2;

		private Label label40;

		private Label m_lblRunTimePDCal;

		private Label label18;

		private CheckBox m_chkTxPhase;

		private Label label19;

		private Label m_lblTxPhaseUpdate;

		private Label m_lblTxPhase;

		private Label m_lblRadarDevice4TxPhaseUpdate;

		private Label m_lblRadarDevice4TxPhase;

		private Label m_lblRadarDevice3TxPhaseUpdate;

		private Label m_lblRadarDevice3TxPhase;

		private Label m_lblRadarDevice2TxPhaseUpdate;

		private Label m_lblRadarDevice2TxPhase;

		private CheckBox m_chkDisableLogging;
	}
}
