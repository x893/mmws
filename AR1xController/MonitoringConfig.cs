using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class MonitoringConfig : UserControl
	{
		public MonitoringConfig()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_MonitoringModeConfigParameters = this.m_GuiManager.TsParams.MonitoringModeConfigParameters;
			this.m_RFDigitalSysPeriodicConfigParameters = this.m_GuiManager.TsParams.RFDigitalSysPeriodicConfigParameters;
			this.m_RFDigitalSysLatentFaultConfigParameters = this.m_GuiManager.TsParams.RFDigitalSysLatentFaultConfigParameters;
			this.m_cboRFDigSysDigSysLatentFaultTestMode.SelectedIndex = 0;
			this.m_cboRFDigSysPeriodMonitoringMode.SelectedIndex = 0;
		}

		private int iSetMonitoringModeConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetMonitoringModeConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetMonitoringModeConfig()
		{
			this.iSetMonitoringModeConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void iSetMonitoringModeConfigAsync()
		{
			new del_v_v(this.iSetMonitoringModeConfig).BeginInvoke(null, null);
		}

		private void m_btnMonitoringModeConfigSet_Click(object sender, EventArgs p1)
		{
			this.iSetMonitoringModeConfigAsync();
		}

		public bool UpdateMonitoringModeConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateMonitoringModeConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMonitoringModeConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateMonitoringModeConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMonitoringRFEnablesConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateMonitoringRFEnablesConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMonitoringRFEnablesConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateMonitoringRFEnablesConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetRFDigitalSysPeriodicMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetRFDigitalSysPeriodicMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFDigitalSysPeriodicMonConfig()
		{
			this.iSetRFDigitalSysPeriodicMonConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetRFDigitalSysPeriodicMonConfigAsync()
		{
			new del_v_v(this.iSetRFDigitalSysPeriodicMonConfig).BeginInvoke(null, null);
		}

		private void m_btnRFDigitalSysPeriodicMonConfigSet_Click(object sender, EventArgs p1)
		{
			this.iSetRFDigitalSysPeriodicMonConfigAsync();
		}

		public bool UpdateRFDigitalSysPeriodicMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRFDigitalSysPeriodicMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RFDigitalSysPeriodicConfigParameters.ReportingMode = (char)this.m_cboRFDigSysPeriodMonitoringMode.SelectedIndex;
				this.m_RFDigitalSysPeriodicConfigParameters.PeriodicRegisterRead = (this.m_chbRFDigSysPeriodicRegisterRead.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysPeriodicConfigParameters.ESMTest = (this.f0001bc.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysPeriodicConfigParameters.DFESTC = (this.f0001bb.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysPeriodicConfigParameters.FrameTimigTest = (this.m_chbRFDigSysFrameTimingTest.Checked ? '\u0001' : '\0');
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRFDigitalSysPeriodicMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRFDigitalSysPeriodicMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_cboRFDigSysPeriodMonitoringMode.SelectedIndex = (int)this.m_RFDigitalSysPeriodicConfigParameters.ReportingMode;
				this.m_chbRFDigSysPeriodicRegisterRead.Checked = (this.m_RFDigitalSysPeriodicConfigParameters.PeriodicRegisterRead == '\u0001');
				this.f0001bc.Checked = (this.m_RFDigitalSysPeriodicConfigParameters.ESMTest == '\u0001');
				this.f0001bb.Checked = (this.m_RFDigitalSysPeriodicConfigParameters.DFESTC == '\u0001');
				this.m_chbRFDigSysFrameTimingTest.Checked = (this.m_RFDigitalSysPeriodicConfigParameters.FrameTimigTest == '\u0001');
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeRFDigitalPeriodicMonitoringReport(uint RadarDeviceId, uint DigPeriodicStatus, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_u_uc method = new del_u_u_uc(this.CascadeRFDigitalPeriodicMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					DigPeriodicStatus,
					TimeStamp
				});
			}
			else if (RadarDeviceId == 1U)
			{
				if ((DigPeriodicStatus & 1U) == 1U)
				{
					this.m_lblRFRFDigSysPeriodicRegisterRead.Text = "P";
					this.m_lblRFRFDigSysPeriodicRegisterRead.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRFRFDigSysPeriodicRegisterRead.Text = "F";
					this.m_lblRFRFDigSysPeriodicRegisterRead.ForeColor = Color.Red;
				}
				if ((DigPeriodicStatus >> 1 & 1U) == 1U)
				{
					this.f0001bd.Text = "P";
					this.f0001bd.ForeColor = Color.Green;
				}
				else
				{
					this.f0001bd.Text = "F";
					this.f0001bd.ForeColor = Color.Red;
				}
				if ((DigPeriodicStatus >> 2 & 1U) == 1U)
				{
					this.f0001be.Text = "P";
					this.f0001be.ForeColor = Color.Green;
				}
				else
				{
					this.f0001be.Text = "F";
					this.f0001be.ForeColor = Color.Red;
				}
				if ((DigPeriodicStatus >> 3 & 1U) == 1U)
				{
					this.m_lblRFRFDigSysPeriodFrameTimingTest.Text = "P";
					this.m_lblRFRFDigSysPeriodFrameTimingTest.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblRFRFDigSysPeriodFrameTimingTest.Text = "F";
					this.m_lblRFRFDigSysPeriodFrameTimingTest.ForeColor = Color.Red;
				}
				this.f0001bf.Text = Convert.ToString(TimeStamp);
				string empty = string.Empty;
				string empty2 = string.Empty;
				// "0x" + DigPeriodicStatus.ToString("x");
				Convert.ToString(TimeStamp);
			}
			else if (RadarDeviceId == 2U || RadarDeviceId != 3U)
			{
			}
			return true;
		}

		private int iSetRFDigitalSysLatentFaultMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetRFDigitalSysLatentFaultMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFDigitalSysLatentFaultMonConfig()
		{
			this.iSetRFDigitalSysLatentFaultMonConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetRFDigitalSysLatentFaultMonConfigAsync()
		{
			new del_v_v(this.iSetRFDigitalSysLatentFaultMonConfig).BeginInvoke(null, null);
		}

		private void m_btnRFDigitalSysLatentFaultMonConfigSet_Click(object sender, EventArgs p1)
		{
			this.iSetRFDigitalSysLatentFaultMonConfigAsync();
		}

		public bool UpdateMonitoringLatentFaultConfigData(RootObject jobject, int p1)
		{
			bool result;
			try
			{
				if (jobject.mmWaveDevices[p1].monitoringConfig == null)
				{
					string msg = string.Format("Missing Monitoring Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg);
				}
				else
				{
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.isConfigured == 0)
					{
						string msg2 = string.Format("Missing Digital Monitoring Enables Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg2);
					}
					else if (GlobalRef.g_AR12xxDevice)
					{
						this.m_chbCR4Lockstep.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 2) >> 1 == 1);
						this.m_chbVIMMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 8) >> 3 == 1);
						this.m_chbCRCMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 64) >> 6 == 1);
						this.m_chbRampGenECCMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 128) >> 7 == 1);
						this.m_chbDFEParityMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 256) >> 8 == 1);
						this.f0001c3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 512) >> 9 == 1);
						this.m_chbRampGenLockStepMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 1024) >> 10 == 1);
						this.m_chbFRCLockStepMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 2048) >> 11 == 1);
						this.m_chbESMMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 65536) >> 16 == 1);
						this.f0001c2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 131072) >> 17 == 1);
						this.f0001c1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 524288) >> 19 == 1);
						this.f0001c0.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 1048576) >> 20 == 1);
						this.m_chbFFTMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 16777216) >> 24 == 1);
						this.m_chbRTIMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 33554432) >> 25 == 1);
						this.m_chbPCRMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.enMask, 16) & 67108864) >> 26 == 1);
						this.m_cboRFDigSysDigSysLatentFaultTestMode.SelectedIndex = jobject.mmWaveDevices[p1].monitoringConfig.rlMonDigEnables_t.testMode;
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlDigMonPeriodicConf_t.isConfigured == 0)
					{
						string msg3 = string.Format("Missing Digital Monitoring Periodic Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg3);
					}
					else if (GlobalRef.g_AR12xxDevice)
					{
						this.m_cboRFDigSysPeriodMonitoringMode.SelectedIndex = jobject.mmWaveDevices[p1].monitoringConfig.rlDigMonPeriodicConf_t.reportMode;
						this.m_chbRFDigSysPeriodicRegisterRead.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlDigMonPeriodicConf_t.periodicEnableMask, 16) & 1) == 1);
						this.f0001bc.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlDigMonPeriodicConf_t.periodicEnableMask, 16) & 2) >> 1 == 1);
						this.f0001bb.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlDigMonPeriodicConf_t.periodicEnableMask, 16) & 4) >> 2 == 1);
						this.m_chbRFDigSysFrameTimingTest.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlDigMonPeriodicConf_t.periodicEnableMask, 16) & 8) >> 3 == 1);
					}
				}
				result = true;
			}
			catch
			{
				string msg4 = string.Format("Dig Monitoring Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg4);
				result = false;
			}
			return result;
		}

		public bool UpdateMonitoringRFDigitalSysLatentFaultConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateMonitoringRFDigitalSysLatentFaultConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RFDigitalSysLatentFaultConfigParameters.f00031c = (this.m_chbCR4Lockstep.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.VIMMOn = (this.m_chbVIMMon.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.CRCMOn = (this.m_chbCRCMon.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.RampGenECCMOn = (this.m_chbRampGenECCMon.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.DFEParityMOn = (this.m_chbDFEParityMon.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.f00031d = (this.f0001c3.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.RampGenLockStepMon = (this.m_chbRampGenLockStepMon.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.FRCLockStepMon = (this.m_chbFRCLockStepMon.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.WDTMon = '\0';
				this.m_RFDigitalSysLatentFaultConfigParameters.ESMMon = (this.m_chbESMMon.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.f00031e = (this.f0001c2.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.FRCMon = '\0';
				this.m_RFDigitalSysLatentFaultConfigParameters.f00031f = (this.f0001c1.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.f000320 = (this.f0001c0.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.DCCMon = '\0';
				this.m_RFDigitalSysLatentFaultConfigParameters.SOCCMon = '\0';
				this.m_RFDigitalSysLatentFaultConfigParameters.f000321 = '\0';
				this.m_RFDigitalSysLatentFaultConfigParameters.FFTMon = (this.m_chbFFTMon.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.RTIMon = (this.m_chbRTIMon.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.PCRMon = (this.m_chbPCRMon.Checked ? '\u0001' : '\0');
				this.m_RFDigitalSysLatentFaultConfigParameters.TestMode = (char)this.m_cboRFDigSysDigSysLatentFaultTestMode.SelectedIndex;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMonitoringRFDigitalSysLatentFaultConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateMonitoringRFDigitalSysLatentFaultConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_chbCR4Lockstep.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.f00031c == '\u0001');
				this.m_chbVIMMon.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.VIMMOn == '\u0001');
				this.m_chbCRCMon.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.CRCMOn == '\u0001');
				this.m_chbRampGenECCMon.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.RampGenECCMOn == '\u0001');
				this.m_chbDFEParityMon.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.DFEParityMOn == '\u0001');
				this.f0001c3.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.f00031d == '\u0001');
				this.m_chbRampGenLockStepMon.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.RampGenLockStepMon == '\u0001');
				this.m_chbFRCLockStepMon.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.FRCLockStepMon == '\u0001');
				this.m_chbESMMon.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.ESMMon == '\u0001');
				this.f0001c2.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.f00031e == '\u0001');
				this.f0001c1.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.f00031f == '\u0001');
				this.f0001c0.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.f000320 == '\u0001');
				this.m_chbFFTMon.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.FFTMon == '\u0001');
				this.m_chbRTIMon.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.RTIMon == '\u0001');
				this.m_chbPCRMon.Checked = (this.m_RFDigitalSysLatentFaultConfigParameters.PCRMon == '\u0001');
				this.m_cboRFDigSysDigSysLatentFaultTestMode.SelectedIndex = (int)this.m_RFDigitalSysLatentFaultConfigParameters.TestMode;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeRFDigitalLatentFaultMonitoringReport(uint RadarDeviceId, uint DigLatentFaultResult)
		{
			if (base.InvokeRequired)
			{
				del_u_u method = new del_u_u(this.CascadeRFDigitalLatentFaultMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					DigLatentFaultResult
				});
			}
			else if (RadarDeviceId == 1U)
			{
				if ((DigLatentFaultResult & 1U) == 1U)
				{
					this.m_lblLatentFaultROMCrcCheck.Text = "P";
					this.m_lblLatentFaultROMCrcCheck.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblLatentFaultROMCrcCheck.Text = "-";
					this.m_lblLatentFaultROMCrcCheck.ForeColor = Color.Black;
				}
				if ((DigLatentFaultResult >> 1 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultCR4LockStep.Text = "P";
					this.m_lblDigLatentFaultCR4LockStep.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultCR4LockStep.Text = "F";
					this.m_lblDigLatentFaultCR4LockStep.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 3 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultVIMMon.Text = "P";
					this.m_lblDigLatentFaultVIMMon.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultVIMMon.Text = "F";
					this.m_lblDigLatentFaultVIMMon.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 4 & 1U) == 1U)
				{
					this.m_lblLatentFaultDiagnosticTestCheck.Text = "P";
					this.m_lblLatentFaultDiagnosticTestCheck.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblLatentFaultDiagnosticTestCheck.Text = "-";
					this.m_lblLatentFaultDiagnosticTestCheck.ForeColor = Color.Black;
				}
				if ((DigLatentFaultResult >> 5 & 1U) == 1U)
				{
					this.f0001c6.Text = "P";
					this.f0001c6.ForeColor = Color.Green;
				}
				else
				{
					this.f0001c6.Text = "-";
					this.f0001c6.ForeColor = Color.Black;
				}
				if ((DigLatentFaultResult >> 6 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultCRCMon.Text = "P";
					this.m_lblDigLatentFaultCRCMon.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultCRCMon.Text = "F";
					this.m_lblDigLatentFaultCRCMon.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 7 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultRampGenECCMon.Text = "P";
					this.m_lblDigLatentFaultRampGenECCMon.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultRampGenECCMon.Text = "F";
					this.m_lblDigLatentFaultRampGenECCMon.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 8 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultDFEParityMon.Text = "P";
					this.m_lblDigLatentFaultDFEParityMon.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultDFEParityMon.Text = "F";
					this.m_lblDigLatentFaultDFEParityMon.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 9 & 1U) == 1U)
				{
					this.f0001ca.Text = "P";
					this.f0001ca.ForeColor = Color.Green;
				}
				else
				{
					this.f0001ca.Text = "F";
					this.f0001ca.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 10 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultRampGenLockStepMon.Text = "P";
					this.m_lblDigLatentFaultRampGenLockStepMon.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultRampGenLockStepMon.Text = "F";
					this.m_lblDigLatentFaultRampGenLockStepMon.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 11 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultFRCLockStepMon.Text = "P";
					this.m_lblDigLatentFaultFRCLockStepMon.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultFRCLockStepMon.Text = "F";
					this.m_lblDigLatentFaultFRCLockStepMon.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 12 & 1U) == 1U)
				{
					this.f0001c5.Text = "P";
					this.f0001c5.ForeColor = Color.Green;
				}
				else
				{
					this.f0001c5.Text = "-";
					this.f0001c5.ForeColor = Color.Black;
				}
				if ((DigLatentFaultResult >> 13 & 1U) == 1U)
				{
					this.m_lblLatentFaultRampGenMemPBIST.Text = "P";
					this.m_lblLatentFaultRampGenMemPBIST.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblLatentFaultRampGenMemPBIST.Text = "-";
					this.m_lblLatentFaultRampGenMemPBIST.ForeColor = Color.Black;
				}
				if ((DigLatentFaultResult >> 14 & 1U) == 1U)
				{
					this.f0001c4.Text = "P";
					this.f0001c4.ForeColor = Color.Green;
				}
				else
				{
					this.f0001c4.Text = "-";
					this.f0001c4.ForeColor = Color.Black;
				}
				if ((DigLatentFaultResult >> 15 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultWDTMon.Text = "P";
					this.m_lblDigLatentFaultWDTMon.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultWDTMon.Text = "-";
					this.m_lblDigLatentFaultWDTMon.ForeColor = Color.Black;
				}
				if ((DigLatentFaultResult >> 16 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultESMMon.Text = "P";
					this.m_lblDigLatentFaultESMMon.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultESMMon.Text = "F";
					this.m_lblDigLatentFaultESMMon.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 17 & 1U) == 1U)
				{
					this.f0001c9.Text = "P";
					this.f0001c9.ForeColor = Color.Green;
				}
				else
				{
					this.f0001c9.Text = "F";
					this.f0001c9.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 19 & 1U) == 1U)
				{
					this.f0001c8.Text = "P";
					this.f0001c8.ForeColor = Color.Green;
				}
				else
				{
					this.f0001c8.Text = "F";
					this.f0001c8.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 20 & 1U) == 1U)
				{
					this.f0001c7.Text = "P";
					this.f0001c7.ForeColor = Color.Green;
				}
				else
				{
					this.f0001c7.Text = "F";
					this.f0001c7.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 24 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultFFTMon.Text = "P";
					this.m_lblDigLatentFaultFFTMon.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultFFTMon.Text = "F";
					this.m_lblDigLatentFaultFFTMon.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 25 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultRTIMon.Text = "P";
					this.m_lblDigLatentFaultRTIMon.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultRTIMon.Text = "F";
					this.m_lblDigLatentFaultRTIMon.ForeColor = Color.Red;
				}
				if ((DigLatentFaultResult >> 26 & 1U) == 1U)
				{
					this.m_lblDigLatentFaultPCRMon.Text = "P";
					this.m_lblDigLatentFaultPCRMon.ForeColor = Color.Green;
				}
				else
				{
					this.m_lblDigLatentFaultPCRMon.Text = "F";
					this.m_lblDigLatentFaultPCRMon.ForeColor = Color.Red;
				}
				string empty = string.Empty;
				// "0x" + DigLatentFaultResult.ToString("x");
			}
			else if (RadarDeviceId == 2U || RadarDeviceId != 3U)
			{
			}
			return true;
		}

		public void m00003c()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.m00003c);
				base.Invoke(method);
			}
		}

		public void clrRFDigitalSystemLatentFaultReport()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.clrRFDigitalSystemLatentFaultReport);
				base.Invoke(method);
				return;
			}
			this.m_lblLatentFaultROMCrcCheck.Text = "-";
			this.m_lblLatentFaultROMCrcCheck.ForeColor = Color.Black;
			this.m_lblDigLatentFaultCR4LockStep.Text = "F";
			this.m_lblDigLatentFaultCR4LockStep.ForeColor = Color.Red;
			this.m_lblDigLatentFaultVIMMon.Text = "F";
			this.m_lblDigLatentFaultVIMMon.ForeColor = Color.Red;
			this.m_lblLatentFaultDiagnosticTestCheck.Text = "-";
			this.m_lblLatentFaultDiagnosticTestCheck.ForeColor = Color.Black;
			this.f0001c6.Text = "-";
			this.f0001c6.ForeColor = Color.Black;
			this.m_lblDigLatentFaultCRCMon.Text = "F";
			this.m_lblDigLatentFaultCRCMon.ForeColor = Color.Red;
			this.m_lblDigLatentFaultRampGenECCMon.Text = "F";
			this.m_lblDigLatentFaultRampGenECCMon.ForeColor = Color.Red;
			this.m_lblDigLatentFaultDFEParityMon.Text = "F";
			this.m_lblDigLatentFaultDFEParityMon.ForeColor = Color.Red;
			this.f0001ca.Text = "F";
			this.f0001ca.ForeColor = Color.Red;
			this.m_lblDigLatentFaultRampGenLockStepMon.Text = "F";
			this.m_lblDigLatentFaultRampGenLockStepMon.ForeColor = Color.Red;
			this.m_lblDigLatentFaultFRCLockStepMon.Text = "F";
			this.m_lblDigLatentFaultFRCLockStepMon.ForeColor = Color.Red;
			this.f0001c5.Text = "-";
			this.f0001c5.ForeColor = Color.Black;
			this.m_lblLatentFaultRampGenMemPBIST.Text = "-";
			this.m_lblLatentFaultRampGenMemPBIST.ForeColor = Color.Black;
			this.f0001c4.Text = "-";
			this.f0001c4.ForeColor = Color.Black;
			this.m_lblDigLatentFaultWDTMon.Text = "-";
			this.m_lblDigLatentFaultWDTMon.ForeColor = Color.Black;
			this.m_lblDigLatentFaultESMMon.Text = "F";
			this.m_lblDigLatentFaultESMMon.ForeColor = Color.Red;
			this.f0001c9.Text = "F";
			this.f0001c9.ForeColor = Color.Red;
			this.f0001c8.Text = "F";
			this.f0001c8.ForeColor = Color.Red;
			this.f0001c7.Text = "F";
			this.f0001c7.ForeColor = Color.Red;
			this.m_lblDigLatentFaultFFTMon.Text = "F";
			this.m_lblDigLatentFaultFFTMon.ForeColor = Color.Red;
			this.m_lblDigLatentFaultRTIMon.Text = "F";
			this.m_lblDigLatentFaultRTIMon.ForeColor = Color.Red;
			this.m_lblDigLatentFaultPCRMon.Text = "F";
			this.m_lblDigLatentFaultPCRMon.ForeColor = Color.Red;
		}

		public void m00003d()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.m00003d);
				base.Invoke(method);
				return;
			}
			this.m_lblRFRFDigSysPeriodicRegisterRead.Text = "F";
			this.m_lblRFRFDigSysPeriodicRegisterRead.ForeColor = Color.Red;
			this.f0001bd.Text = "F";
			this.f0001bd.ForeColor = Color.Red;
			this.f0001be.Text = "F";
			this.f0001be.ForeColor = Color.Red;
			this.m_lblRFRFDigSysPeriodFrameTimingTest.Text = "F";
			this.m_lblRFRFDigSysPeriodFrameTimingTest.ForeColor = Color.Red;
			this.f0001bf.Text = Convert.ToString(0);
		}

		public bool m00003e(uint RadarDeviceId, uint p1, uint PowerUpTime, int Reserved, uint Reserved2)
		{
			if (base.InvokeRequired)
			{
				delegate0fc method = new delegate0fc(this.m00003e);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					p1,
					PowerUpTime,
					Reserved,
					Reserved2
				});
			}
			else if (RadarDeviceId == 1U)
			{
				if ((p1 & 1U) == 1U)
				{
					this.m_lblBootUpROMCrcCheck.Text = "P";
				}
				else
				{
					this.m_lblBootUpROMCrcCheck.Text = "F";
				}
				if ((p1 >> 1 & 1U) == 1U)
				{
					this.m_lblBootUpCR4VimLockStep.Text = "P";
				}
				else
				{
					this.m_lblBootUpCR4VimLockStep.Text = "F";
				}
				if ((p1 >> 3 & 1U) == 1U)
				{
					this.m_lblBootUpVIMTest.Text = "P";
				}
				else
				{
					this.m_lblBootUpVIMTest.Text = "F";
				}
				if ((p1 >> 4 & 1U) == 1U)
				{
					this.m_lblBootUpSTCTest.Text = "P";
				}
				else
				{
					this.m_lblBootUpSTCTest.Text = "F";
				}
				if ((p1 >> 5 & 1U) == 1U)
				{
					this.f0001d2.Text = "P";
				}
				else
				{
					this.f0001d2.Text = "F";
				}
				if ((p1 >> 6 & 1U) == 1U)
				{
					this.m_lblBootUpCRCTest.Text = "P";
				}
				else
				{
					this.m_lblBootUpCRCTest.Text = "F";
				}
				if ((p1 >> 7 & 1U) == 1U)
				{
					this.m_lblBootUpRampGenMemECC.Text = "P";
				}
				else
				{
					this.m_lblBootUpRampGenMemECC.Text = "F";
				}
				if ((p1 >> 8 & 1U) == 1U)
				{
					this.m_lblBootUpDFEParity.Text = "P";
				}
				else
				{
					this.m_lblBootUpDFEParity.Text = "F";
				}
				if ((p1 >> 9 & 1U) == 1U)
				{
					this.f0001d1.Text = "P";
				}
				else
				{
					this.f0001d1.Text = "F";
				}
				if ((p1 >> 10 & 1U) == 1U)
				{
					this.m_lblBootUpRampGenLockStep.Text = "P";
				}
				else
				{
					this.m_lblBootUpRampGenLockStep.Text = "F";
				}
				if ((p1 >> 11 & 1U) == 1U)
				{
					this.m_lblBootUpFRCLockStep.Text = "P";
				}
				else
				{
					this.m_lblBootUpFRCLockStep.Text = "F";
				}
				if ((p1 >> 12 & 1U) == 1U)
				{
					this.f0001d0.Text = "P";
				}
				else
				{
					this.f0001d0.Text = "F";
				}
				if ((p1 >> 13 & 1U) == 1U)
				{
					this.f0001cf.Text = "P";
				}
				else
				{
					this.f0001cf.Text = "F";
				}
				if ((p1 >> 14 & 1U) == 1U)
				{
					this.f0001ce.Text = "P";
				}
				else
				{
					this.f0001ce.Text = "F";
				}
				if ((p1 >> 15 & 1U) == 1U)
				{
					this.m_lblBootUpWDT.Text = "P";
				}
				else
				{
					this.m_lblBootUpWDT.Text = "F";
				}
				if ((p1 >> 16 & 1U) == 1U)
				{
					this.m_lblBootUpESM.Text = "P";
				}
				else
				{
					this.m_lblBootUpESM.Text = "F";
				}
				if ((p1 >> 17 & 1U) == 1U)
				{
					this.f0001cd.Text = "P";
				}
				else
				{
					this.f0001cd.Text = "F";
				}
				if ((p1 >> 19 & 1U) == 1U)
				{
					this.f0001cc.Text = "P";
				}
				else
				{
					this.f0001cc.Text = "F";
				}
				if ((p1 >> 20 & 1U) == 1U)
				{
					this.f0001cb.Text = "P";
				}
				else
				{
					this.f0001cb.Text = "F";
				}
				if ((p1 >> 24 & 1U) == 1U)
				{
					this.m_lblBootUpFFT.Text = "P";
				}
				else
				{
					this.m_lblBootUpFFT.Text = "F";
				}
				if ((p1 >> 25 & 1U) == 1U)
				{
					this.m_lblBootUpRTI.Text = "P";
				}
				else
				{
					this.m_lblBootUpRTI.Text = "F";
				}
				if ((p1 >> 26 & 1U) == 1U)
				{
					this.m_lblBootUpPCR.Text = "P";
				}
				else
				{
					this.m_lblBootUpPCR.Text = "F";
				}
				this.m_lblBootUpPowerUpTime.Text = Convert.ToString(Math.Round(PowerUpTime / 200000.0, 1));
			}
			else if (RadarDeviceId == 2U || RadarDeviceId != 3U)
			{
			}
			return true;
		}

		public void m00003f()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.m00003f);
				base.Invoke(method);
				return;
			}
			this.m_lblBootUpROMCrcCheck.Text = "F";
			this.m_lblBootUpCR4VimLockStep.Text = "F";
			this.m_lblBootUpVIMTest.Text = "F";
			this.m_lblBootUpSTCTest.Text = "F";
			this.f0001d2.Text = "F";
			this.m_lblBootUpCRCTest.Text = "F";
			this.m_lblBootUpRampGenMemECC.Text = "F";
			this.m_lblBootUpDFEParity.Text = "F";
			this.f0001d1.Text = "F";
			this.m_lblBootUpRampGenLockStep.Text = "F";
			this.m_lblBootUpFRCLockStep.Text = "F";
			this.f0001d0.Text = "F";
			this.f0001cf.Text = "F";
			this.f0001ce.Text = "F";
			this.m_lblBootUpWDT.Text = "F";
			this.m_lblBootUpESM.Text = "F";
			this.f0001cd.Text = "F";
			this.f0001cc.Text = "F";
			this.f0001cb.Text = "F";
			this.m_lblBootUpFFT.Text = "F";
			this.m_lblBootUpRTI.Text = "F";
			this.m_lblBootUpPCR.Text = "F";
			this.m_lblBootUpPowerUpTime.Text = Convert.ToString(0);
		}

		public bool m000040(uint RadarDeviceId, byte FaultType, ushort LineNum, uint FaultLR, uint FaultPrevLR, uint FaultSPSR, uint FaultSP, uint FaultCauseAddress, ushort FaultErrorStatus, byte FaultErrorSource, byte FaultAXIErrorType, byte FaultAccessType, byte FaultRecoveryType)
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string empty5 = string.Empty;
			string empty6 = string.Empty;
			string empty7 = string.Empty;
			string empty8 = string.Empty;
			string empty9 = string.Empty;
			string empty10 = string.Empty;
			string empty11 = string.Empty;
			string empty12 = string.Empty;
			if (RadarDeviceId == 1U)
			{
				Convert.ToString(FaultType);
				Convert.ToString(LineNum);
				Convert.ToString(FaultLR);
				Convert.ToString(FaultPrevLR);
				Convert.ToString(FaultSPSR);
				Convert.ToString(FaultSP);
				Convert.ToString(FaultCauseAddress);
				Convert.ToString(FaultErrorStatus);
				Convert.ToString(FaultAXIErrorType);
				Convert.ToString(FaultAccessType);
				Convert.ToString(FaultRecoveryType);
				Convert.ToString(FaultErrorSource);
			}
			else if (RadarDeviceId == 2U || RadarDeviceId != 3U)
			{
			}
			return true;
		}

		public bool m000041(uint RadarDeviceId, uint ESMGroup1Error, uint ESMGroup2Error)
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (RadarDeviceId == 1U)
			{
				Convert.ToString(ESMGroup1Error);
				Convert.ToString(ESMGroup2Error);
			}
			else if (RadarDeviceId == 2U || RadarDeviceId != 3U)
			{
			}
			return true;
		}

		public bool MSSBootErrorAsyncReportData(uint RadarDeviceId, uint ErrorStatus)
		{
			string empty = string.Empty;
			if (RadarDeviceId == 1U)
			{
				Convert.ToString(ErrorStatus);
			}
			else if (RadarDeviceId == 2U || RadarDeviceId != 3U)
			{
			}
			return true;
		}

		public bool MSSRFErrorAsyncReportData(uint RadarDeviceId, uint ErrorStatusFlag)
		{
			string empty = string.Empty;
			if (RadarDeviceId == 1U)
			{
				Convert.ToString(ErrorStatusFlag);
			}
			else if (RadarDeviceId == 2U || RadarDeviceId != 3U)
			{
			}
			return true;
		}

		public bool m000042(uint RadarDeviceId, byte FaultType, byte Reserved, ushort LineNum, uint FaultLR, uint FaultPrevLR, uint FaultSPSR, uint FaultSP, uint FaultCauseAddress, ushort FaultErrorStatus, byte FaultErrorSource, byte FaultAXIErrorType, byte FaultAccessType, byte FaultRecoveryType, ushort Reserved2)
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string empty5 = string.Empty;
			string empty6 = string.Empty;
			string empty7 = string.Empty;
			string empty8 = string.Empty;
			string empty9 = string.Empty;
			string empty10 = string.Empty;
			string empty11 = string.Empty;
			string empty12 = string.Empty;
			string empty13 = string.Empty;
			string empty14 = string.Empty;
			if (RadarDeviceId == 1U)
			{
				Convert.ToString(FaultType);
				Convert.ToString(LineNum);
				Convert.ToString(FaultLR);
				Convert.ToString(FaultPrevLR);
				Convert.ToString(FaultSPSR);
				Convert.ToString(FaultSP);
				Convert.ToString(FaultCauseAddress);
				Convert.ToString(FaultErrorStatus);
				Convert.ToString(FaultAXIErrorType);
				Convert.ToString(FaultAccessType);
				Convert.ToString(FaultRecoveryType);
				Convert.ToString(FaultErrorSource);
				Convert.ToString(Reserved);
				Convert.ToString(Reserved2);
			}
			else if (RadarDeviceId == 2U || RadarDeviceId != 3U)
			{
			}
			return true;
		}

		public bool m000043(uint RadarDeviceId, uint ESMGroup1Error, uint ESMGroup2Error)
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (RadarDeviceId == 1U)
			{
				Convert.ToString(ESMGroup1Error);
				Convert.ToString(ESMGroup2Error);
			}
			else if (RadarDeviceId == 2U || RadarDeviceId != 3U)
			{
			}
			return true;
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
			this.m_grpRFDigSysLatentFaultCfg = new GroupBox();
			this.m_cboRFDigSysDigSysLatentFaultTestMode = new ComboBox();
			this.label2 = new Label();
			this.m_btnRFDigitalSysLatentFaultMonConfigSet = new Button();
			this.f0001c0 = new CheckBox();
			this.m_chbPCRMon = new CheckBox();
			this.m_chbRTIMon = new CheckBox();
			this.m_chbFFTMon = new CheckBox();
			this.m_chbRampGenLockStepMon = new CheckBox();
			this.f0001c1 = new CheckBox();
			this.f0001c2 = new CheckBox();
			this.m_chbESMMon = new CheckBox();
			this.m_chbFRCLockStepMon = new CheckBox();
			this.m_chbCR4Lockstep = new CheckBox();
			this.m_chbRampGenECCMon = new CheckBox();
			this.f0001c3 = new CheckBox();
			this.m_chbDFEParityMon = new CheckBox();
			this.m_chbCRCMon = new CheckBox();
			this.m_chbVIMMon = new CheckBox();
			this.m_grpRFDigSysPeriodicMonCfg = new GroupBox();
			this.m_btnRFDigitalSysPeriodicMonConfigSet = new Button();
			this.m_chbRFDigSysFrameTimingTest = new CheckBox();
			this.f0001bb = new CheckBox();
			this.f0001bc = new CheckBox();
			this.m_chbRFDigSysPeriodicRegisterRead = new CheckBox();
			this.m_cboRFDigSysPeriodMonitoringMode = new ComboBox();
			this.label25 = new Label();
			this.label14 = new Label();
			this.label27 = new Label();
			this.f0001bf = new Label();
			this.label29 = new Label();
			this.groupBox1 = new GroupBox();
			this.m_lblRFRFDigSysPeriodFrameTimingTest = new Label();
			this.f0001bd = new Label();
			this.f0001be = new Label();
			this.m_lblRFRFDigSysPeriodicRegisterRead = new Label();
			this.label33 = new Label();
			this.label32 = new Label();
			this.label31 = new Label();
			this.label30 = new Label();
			this.m_grpRFBootUpBistStatusGet = new GroupBox();
			this.m_lblDigLatentFaultPCRMon = new Label();
			this.f0001c4 = new Label();
			this.m_lblDigLatentFaultRTIMon = new Label();
			this.m_lblLatentFaultRampGenMemPBIST = new Label();
			this.m_lblDigLatentFaultFFTMon = new Label();
			this.f0001c5 = new Label();
			this.f0001c6 = new Label();
			this.m_lblLatentFaultDiagnosticTestCheck = new Label();
			this.f0001c7 = new Label();
			this.m_lblLatentFaultROMCrcCheck = new Label();
			this.f0001c8 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.f0001c9 = new Label();
			this.m_lblBootUpPowerUpTime = new Label();
			this.label1 = new Label();
			this.m_lblDigLatentFaultESMMon = new Label();
			this.m_lblDigLatentFaultWDTMon = new Label();
			this.m_lblBootUpRampGenMemECC = new Label();
			this.m_lblBootUpPCR = new Label();
			this.m_lblBootUpRTI = new Label();
			this.m_lblBootUpFFT = new Label();
			this.m_lblDigLatentFaultFRCLockStepMon = new Label();
			this.label166 = new Label();
			this.label165 = new Label();
			this.m_lblDigLatentFaultRampGenLockStepMon = new Label();
			this.label164 = new Label();
			this.m_lblDigLatentFaultDFEParityMon = new Label();
			this.m_lblBootUpROMCrcCheck = new Label();
			this.f0001ca = new Label();
			this.label26 = new Label();
			this.m_lblDigLatentFaultRampGenECCMon = new Label();
			this.f0001cb = new Label();
			this.f0001cc = new Label();
			this.f0001cd = new Label();
			this.m_lblDigLatentFaultCRCMon = new Label();
			this.m_lblDigLatentFaultVIMMon = new Label();
			this.m_lblBootUpESM = new Label();
			this.m_lblBootUpWDT = new Label();
			this.m_lblDigLatentFaultCR4LockStep = new Label();
			this.f0001ce = new Label();
			this.f0001cf = new Label();
			this.f0001d0 = new Label();
			this.m_lblBootUpFRCLockStep = new Label();
			this.m_lblBootUpRampGenLockStep = new Label();
			this.f0001d1 = new Label();
			this.m_lblBootUpDFEParity = new Label();
			this.m_lblBootUpCRCTest = new Label();
			this.f0001d2 = new Label();
			this.m_lblBootUpSTCTest = new Label();
			this.m_lblBootUpVIMTest = new Label();
			this.m_lblBootUpCR4VimLockStep = new Label();
			this.label84 = new Label();
			this.label85 = new Label();
			this.label87 = new Label();
			this.label88 = new Label();
			this.label54 = new Label();
			this.label55 = new Label();
			this.label56 = new Label();
			this.label57 = new Label();
			this.label58 = new Label();
			this.label59 = new Label();
			this.label60 = new Label();
			this.label61 = new Label();
			this.label62 = new Label();
			this.label63 = new Label();
			this.label64 = new Label();
			this.label65 = new Label();
			this.label66 = new Label();
			this.label68 = new Label();
			this.m_grpRFDigSysLatentFaultCfg.SuspendLayout();
			this.m_grpRFDigSysPeriodicMonCfg.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.m_grpRFBootUpBistStatusGet.SuspendLayout();
			base.SuspendLayout();
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_cboRFDigSysDigSysLatentFaultTestMode);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.label2);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_btnRFDigitalSysLatentFaultMonConfigSet);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.f0001c0);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_chbPCRMon);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_chbRTIMon);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_chbFFTMon);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_chbRampGenLockStepMon);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.f0001c1);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.f0001c2);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_chbESMMon);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_chbFRCLockStepMon);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_chbCR4Lockstep);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_chbRampGenECCMon);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.f0001c3);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_chbDFEParityMon);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_chbCRCMon);
			this.m_grpRFDigSysLatentFaultCfg.Controls.Add(this.m_chbVIMMon);
			this.m_grpRFDigSysLatentFaultCfg.Location = new Point(471, 11);
			this.m_grpRFDigSysLatentFaultCfg.Margin = new Padding(4, 4, 4, 4);
			this.m_grpRFDigSysLatentFaultCfg.Name = "m_grpRFDigSysLatentFaultCfg";
			this.m_grpRFDigSysLatentFaultCfg.Padding = new Padding(4, 4, 4, 4);
			this.m_grpRFDigSysLatentFaultCfg.Size = new Size(857, 145);
			this.m_grpRFDigSysLatentFaultCfg.TabIndex = 3;
			this.m_grpRFDigSysLatentFaultCfg.TabStop = false;
			this.m_grpRFDigSysLatentFaultCfg.Text = "RF Digital System Latent Fault Config";
			this.m_cboRFDigSysDigSysLatentFaultTestMode.DropDownStyle = ComboBoxStyle.DropDownList;
			this.m_cboRFDigSysDigSysLatentFaultTestMode.FormattingEnabled = true;
			this.m_cboRFDigSysDigSysLatentFaultTestMode.Items.AddRange(new object[]
			{
				"ProductionMode",
				"CharacterizationMode"
			});
			this.m_cboRFDigSysDigSysLatentFaultTestMode.Location = new Point(111, 108);
			this.m_cboRFDigSysDigSysLatentFaultTestMode.Margin = new Padding(4, 4, 4, 4);
			this.m_cboRFDigSysDigSysLatentFaultTestMode.Name = "m_cboRFDigSysDigSysLatentFaultTestMode";
			this.m_cboRFDigSysDigSysLatentFaultTestMode.Size = new Size(173, 24);
			this.m_cboRFDigSysDigSysLatentFaultTestMode.TabIndex = 28;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(5, 112);
			this.label2.Margin = new Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(71, 17);
			this.label2.TabIndex = 27;
			this.label2.Text = "TestMode";
			this.m_btnRFDigitalSysLatentFaultMonConfigSet.Location = new Point(593, 98);
			this.m_btnRFDigitalSysLatentFaultMonConfigSet.Margin = new Padding(4, 4, 4, 4);
			this.m_btnRFDigitalSysLatentFaultMonConfigSet.Name = "m_btnRFDigitalSysLatentFaultMonConfigSet";
			this.m_btnRFDigitalSysLatentFaultMonConfigSet.Size = new Size(100, 34);
			this.m_btnRFDigitalSysLatentFaultMonConfigSet.TabIndex = 24;
			this.m_btnRFDigitalSysLatentFaultMonConfigSet.Text = "Set";
			this.m_btnRFDigitalSysLatentFaultMonConfigSet.UseVisualStyleBackColor = true;
			this.m_btnRFDigitalSysLatentFaultMonConfigSet.Click += this.m_btnRFDigitalSysLatentFaultMonConfigSet_Click;
			this.f0001c0.AutoSize = true;
			this.f0001c0.Location = new Point(11, 80);
			this.f0001c0.Margin = new Padding(4, 4, 4, 4);
			this.f0001c0.Name = "m_chbATCMBTCMParityMon";
			this.f0001c0.Size = new Size(154, 21);
			this.f0001c0.TabIndex = 23;
			this.f0001c0.Text = "ATCM, BTCM Parity";
			this.f0001c0.UseVisualStyleBackColor = true;
			this.m_chbPCRMon.AutoSize = true;
			this.m_chbPCRMon.Location = new Point(419, 80);
			this.m_chbPCRMon.Margin = new Padding(4, 4, 4, 4);
			this.m_chbPCRMon.Name = "m_chbPCRMon";
			this.m_chbPCRMon.Size = new Size(89, 21);
			this.m_chbPCRMon.TabIndex = 22;
			this.m_chbPCRMon.Text = "PCR Mon";
			this.m_chbPCRMon.UseVisualStyleBackColor = true;
			this.m_chbRTIMon.AutoSize = true;
			this.m_chbRTIMon.Location = new Point(309, 80);
			this.m_chbRTIMon.Margin = new Padding(4, 4, 4, 4);
			this.m_chbRTIMon.Name = "m_chbRTIMon";
			this.m_chbRTIMon.Size = new Size(83, 21);
			this.m_chbRTIMon.TabIndex = 21;
			this.m_chbRTIMon.Text = "RTI Mon";
			this.m_chbRTIMon.UseVisualStyleBackColor = true;
			this.m_chbFFTMon.AutoSize = true;
			this.m_chbFFTMon.Location = new Point(180, 80);
			this.m_chbFFTMon.Margin = new Padding(4, 4, 4, 4);
			this.m_chbFFTMon.Name = "m_chbFFTMon";
			this.m_chbFFTMon.Size = new Size(86, 21);
			this.m_chbFFTMon.TabIndex = 20;
			this.m_chbFFTMon.Text = "FFT Mon";
			this.m_chbFFTMon.UseVisualStyleBackColor = true;
			this.m_chbRampGenLockStepMon.AutoSize = true;
			this.m_chbRampGenLockStepMon.Location = new Point(11, 49);
			this.m_chbRampGenLockStepMon.Margin = new Padding(4, 4, 4, 4);
			this.m_chbRampGenLockStepMon.Name = "m_chbRampGenLockStepMon";
			this.m_chbRampGenLockStepMon.Size = new Size(157, 21);
			this.m_chbRampGenLockStepMon.TabIndex = 16;
			this.m_chbRampGenLockStepMon.Text = "RampGen LockStep";
			this.m_chbRampGenLockStepMon.UseVisualStyleBackColor = true;
			this.f0001c1.AutoSize = true;
			this.f0001c1.Location = new Point(603, 49);
			this.f0001c1.Margin = new Padding(4, 4, 4, 4);
			this.f0001c1.Name = "m_chbATCMBTCNECCMon";
			this.f0001c1.Size = new Size(176, 21);
			this.f0001c1.TabIndex = 15;
			this.f0001c1.Text = "ATCM, BTCM ECC Mon";
			this.f0001c1.UseVisualStyleBackColor = true;
			this.f0001c2.AutoSize = true;
			this.f0001c2.Location = new Point(419, 49);
			this.f0001c2.Margin = new Padding(4, 4, 4, 4);
			this.f0001c2.Name = "m_chbDFESTCMon";
			this.f0001c2.Size = new Size(88, 21);
			this.f0001c2.TabIndex = 13;
			this.f0001c2.Text = "DFE STC";
			this.f0001c2.UseVisualStyleBackColor = true;
			this.m_chbESMMon.AutoSize = true;
			this.m_chbESMMon.Location = new Point(309, 49);
			this.m_chbESMMon.Margin = new Padding(4, 4, 4, 4);
			this.m_chbESMMon.Name = "m_chbESMMon";
			this.m_chbESMMon.Size = new Size(90, 21);
			this.m_chbESMMon.TabIndex = 12;
			this.m_chbESMMon.Text = "ESM Mon";
			this.m_chbESMMon.UseVisualStyleBackColor = true;
			this.m_chbFRCLockStepMon.AutoSize = true;
			this.m_chbFRCLockStepMon.Location = new Point(180, 49);
			this.m_chbFRCLockStepMon.Margin = new Padding(4, 4, 4, 4);
			this.m_chbFRCLockStepMon.Name = "m_chbFRCLockStepMon";
			this.m_chbFRCLockStepMon.Size = new Size(120, 21);
			this.m_chbFRCLockStepMon.TabIndex = 10;
			this.m_chbFRCLockStepMon.Text = "FRC LockStep";
			this.m_chbFRCLockStepMon.UseVisualStyleBackColor = true;
			this.m_chbCR4Lockstep.AutoSize = true;
			this.m_chbCR4Lockstep.Location = new Point(11, 18);
			this.m_chbCR4Lockstep.Margin = new Padding(4, 4, 4, 4);
			this.m_chbCR4Lockstep.Name = "m_chbCR4Lockstep";
			this.m_chbCR4Lockstep.Size = new Size(118, 21);
			this.m_chbCR4Lockstep.TabIndex = 9;
			this.m_chbCR4Lockstep.Text = "CR4 Lockstep";
			this.m_chbCR4Lockstep.UseVisualStyleBackColor = true;
			this.m_chbRampGenECCMon.AutoSize = true;
			this.m_chbRampGenECCMon.Location = new Point(419, 18);
			this.m_chbRampGenECCMon.Margin = new Padding(4, 4, 4, 4);
			this.m_chbRampGenECCMon.Name = "m_chbRampGenECCMon";
			this.m_chbRampGenECCMon.Size = new Size(160, 21);
			this.m_chbRampGenECCMon.TabIndex = 8;
			this.m_chbRampGenECCMon.Text = "RampGen  ECC Mon";
			this.m_chbRampGenECCMon.UseVisualStyleBackColor = true;
			this.f0001c3.AutoSize = true;
			this.f0001c3.Location = new Point(700, 18);
			this.f0001c3.Margin = new Padding(4, 4, 4, 4);
			this.f0001c3.Name = "m_chbDFEECCMon";
			this.f0001c3.Size = new Size(123, 21);
			this.f0001c3.TabIndex = 7;
			this.f0001c3.Text = "DFE  ECC Mon";
			this.f0001c3.UseVisualStyleBackColor = true;
			this.m_chbDFEParityMon.AutoSize = true;
			this.m_chbDFEParityMon.Location = new Point(603, 18);
			this.m_chbDFEParityMon.Margin = new Padding(4, 4, 4, 4);
			this.m_chbDFEParityMon.Name = "m_chbDFEParityMon";
			this.m_chbDFEParityMon.Size = new Size(97, 21);
			this.m_chbDFEParityMon.TabIndex = 6;
			this.m_chbDFEParityMon.Text = "DFE Parity";
			this.m_chbDFEParityMon.UseVisualStyleBackColor = true;
			this.m_chbCRCMon.AutoSize = true;
			this.m_chbCRCMon.Location = new Point(309, 18);
			this.m_chbCRCMon.Margin = new Padding(4, 4, 4, 4);
			this.m_chbCRCMon.Name = "m_chbCRCMon";
			this.m_chbCRCMon.Size = new Size(89, 21);
			this.m_chbCRCMon.TabIndex = 5;
			this.m_chbCRCMon.Text = "CRC Mon";
			this.m_chbCRCMon.UseVisualStyleBackColor = true;
			this.m_chbVIMMon.AutoSize = true;
			this.m_chbVIMMon.Location = new Point(180, 18);
			this.m_chbVIMMon.Margin = new Padding(4, 4, 4, 4);
			this.m_chbVIMMon.Name = "m_chbVIMMon";
			this.m_chbVIMMon.Size = new Size(84, 21);
			this.m_chbVIMMon.TabIndex = 4;
			this.m_chbVIMMon.Text = "VIM Mon";
			this.m_chbVIMMon.UseVisualStyleBackColor = true;
			this.m_grpRFDigSysPeriodicMonCfg.Controls.Add(this.m_btnRFDigitalSysPeriodicMonConfigSet);
			this.m_grpRFDigSysPeriodicMonCfg.Controls.Add(this.m_chbRFDigSysFrameTimingTest);
			this.m_grpRFDigSysPeriodicMonCfg.Controls.Add(this.f0001bb);
			this.m_grpRFDigSysPeriodicMonCfg.Controls.Add(this.f0001bc);
			this.m_grpRFDigSysPeriodicMonCfg.Controls.Add(this.m_chbRFDigSysPeriodicRegisterRead);
			this.m_grpRFDigSysPeriodicMonCfg.Controls.Add(this.m_cboRFDigSysPeriodMonitoringMode);
			this.m_grpRFDigSysPeriodicMonCfg.Controls.Add(this.label25);
			this.m_grpRFDigSysPeriodicMonCfg.Controls.Add(this.label14);
			this.m_grpRFDigSysPeriodicMonCfg.Location = new Point(475, 167);
			this.m_grpRFDigSysPeriodicMonCfg.Margin = new Padding(4, 4, 4, 4);
			this.m_grpRFDigSysPeriodicMonCfg.Name = "m_grpRFDigSysPeriodicMonCfg";
			this.m_grpRFDigSysPeriodicMonCfg.Padding = new Padding(4, 4, 4, 4);
			this.m_grpRFDigSysPeriodicMonCfg.Size = new Size(505, 160);
			this.m_grpRFDigSysPeriodicMonCfg.TabIndex = 4;
			this.m_grpRFDigSysPeriodicMonCfg.TabStop = false;
			this.m_grpRFDigSysPeriodicMonCfg.Text = "RF Digital System Periodic Mon Config";
			this.m_btnRFDigitalSysPeriodicMonConfigSet.Location = new Point(397, 113);
			this.m_btnRFDigitalSysPeriodicMonConfigSet.Margin = new Padding(4, 4, 4, 4);
			this.m_btnRFDigitalSysPeriodicMonConfigSet.Name = "m_btnRFDigitalSysPeriodicMonConfigSet";
			this.m_btnRFDigitalSysPeriodicMonConfigSet.Size = new Size(100, 34);
			this.m_btnRFDigitalSysPeriodicMonConfigSet.TabIndex = 11;
			this.m_btnRFDigitalSysPeriodicMonConfigSet.Text = "Set";
			this.m_btnRFDigitalSysPeriodicMonConfigSet.UseVisualStyleBackColor = true;
			this.m_btnRFDigitalSysPeriodicMonConfigSet.Click += this.m_btnRFDigitalSysPeriodicMonConfigSet_Click;
			this.m_chbRFDigSysFrameTimingTest.AutoSize = true;
			this.m_chbRFDigSysFrameTimingTest.Location = new Point(348, 87);
			this.m_chbRFDigSysFrameTimingTest.Margin = new Padding(4, 4, 4, 4);
			this.m_chbRFDigSysFrameTimingTest.Name = "m_chbRFDigSysFrameTimingTest";
			this.m_chbRFDigSysFrameTimingTest.Size = new Size(148, 21);
			this.m_chbRFDigSysFrameTimingTest.TabIndex = 6;
			this.m_chbRFDigSysFrameTimingTest.Text = "Frame Timing Test";
			this.m_chbRFDigSysFrameTimingTest.UseVisualStyleBackColor = true;
			this.f0001bb.AutoSize = true;
			this.f0001bb.Location = new Point(168, 86);
			this.f0001bb.Margin = new Padding(4, 4, 4, 4);
			this.f0001bb.Name = "m_chbRFDigSysDFESTC";
			this.f0001bb.Size = new Size(88, 21);
			this.f0001bb.TabIndex = 5;
			this.f0001bb.Text = "DFE STC";
			this.f0001bb.UseVisualStyleBackColor = true;
			this.f0001bc.AutoSize = true;
			this.f0001bc.Location = new Point(348, 55);
			this.f0001bc.Margin = new Padding(4, 4, 4, 4);
			this.f0001bc.Name = "m_chbRFDigSysESMTest";
			this.f0001bc.Size = new Size(91, 21);
			this.f0001bc.TabIndex = 4;
			this.f0001bc.Text = "ESM Test";
			this.f0001bc.UseVisualStyleBackColor = true;
			this.m_chbRFDigSysPeriodicRegisterRead.AutoSize = true;
			this.m_chbRFDigSysPeriodicRegisterRead.Location = new Point(168, 55);
			this.m_chbRFDigSysPeriodicRegisterRead.Margin = new Padding(4, 4, 4, 4);
			this.m_chbRFDigSysPeriodicRegisterRead.Name = "m_chbRFDigSysPeriodicRegisterRead";
			this.m_chbRFDigSysPeriodicRegisterRead.Size = new Size(176, 21);
			this.m_chbRFDigSysPeriodicRegisterRead.TabIndex = 3;
			this.m_chbRFDigSysPeriodicRegisterRead.Text = "Periodic Register Read";
			this.m_chbRFDigSysPeriodicRegisterRead.UseVisualStyleBackColor = true;
			this.m_cboRFDigSysPeriodMonitoringMode.DropDownStyle = ComboBoxStyle.DropDownList;
			this.m_cboRFDigSysPeriodMonitoringMode.FormattingEnabled = true;
			this.m_cboRFDigSysPeriodMonitoringMode.Items.AddRange(new object[]
			{
				"VerboseModeEveryMonPeiod",
				"QuietMode"
			});
			this.m_cboRFDigSysPeriodMonitoringMode.Location = new Point(168, 23);
			this.m_cboRFDigSysPeriodMonitoringMode.Margin = new Padding(4, 4, 4, 4);
			this.m_cboRFDigSysPeriodMonitoringMode.Name = "m_cboRFDigSysPeriodMonitoringMode";
			this.m_cboRFDigSysPeriodMonitoringMode.Size = new Size(237, 24);
			this.m_cboRFDigSysPeriodMonitoringMode.TabIndex = 2;
			this.label25.AutoSize = true;
			this.label25.Location = new Point(11, 55);
			this.label25.Margin = new Padding(4, 0, 4, 0);
			this.label25.Name = "label25";
			this.label25.Size = new Size(136, 17);
			this.label25.TabIndex = 1;
			this.label25.Text = "RF DIGSYS Periodic";
			this.label14.AutoSize = true;
			this.label14.Location = new Point(11, 23);
			this.label14.Margin = new Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new Size(109, 17);
			this.label14.TabIndex = 0;
			this.label14.Text = "Reporting Mode";
			this.label27.AutoSize = true;
			this.label27.ForeColor = SystemColors.HotTrack;
			this.label27.Location = new Point(5, 23);
			this.label27.Margin = new Padding(4, 0, 4, 0);
			this.label27.Name = "label27";
			this.label27.Size = new Size(83, 17);
			this.label27.TabIndex = 7;
			this.label27.Text = "Time Stamp";
			this.f0001bf.AutoSize = true;
			this.f0001bf.Location = new Point(200, 30);
			this.f0001bf.Margin = new Padding(4, 0, 4, 0);
			this.f0001bf.Name = "m_lblRFRFDigSysTimeStamp";
			this.f0001bf.Size = new Size(16, 17);
			this.f0001bf.TabIndex = 8;
			this.f0001bf.Text = "0";
			this.label29.AutoSize = true;
			this.label29.ForeColor = SystemColors.HotTrack;
			this.label29.Location = new Point(5, 49);
			this.label29.Margin = new Padding(4, 0, 4, 0);
			this.label29.Name = "label29";
			this.label29.Size = new Size(136, 17);
			this.label29.TabIndex = 9;
			this.label29.Text = "RF DIGSYS Periodic";
			this.groupBox1.Controls.Add(this.m_lblRFRFDigSysPeriodFrameTimingTest);
			this.groupBox1.Controls.Add(this.f0001bd);
			this.groupBox1.Controls.Add(this.f0001be);
			this.groupBox1.Controls.Add(this.m_lblRFRFDigSysPeriodicRegisterRead);
			this.groupBox1.Controls.Add(this.label33);
			this.groupBox1.Controls.Add(this.label32);
			this.groupBox1.Controls.Add(this.label31);
			this.groupBox1.Controls.Add(this.label30);
			this.groupBox1.Controls.Add(this.label27);
			this.groupBox1.Controls.Add(this.label29);
			this.groupBox1.Controls.Add(this.f0001bf);
			this.groupBox1.Location = new Point(1005, 167);
			this.groupBox1.Margin = new Padding(4, 4, 4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new Padding(4, 4, 4, 4);
			this.groupBox1.Size = new Size(340, 162);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "RF DIGSYS Periodic Mon Report";
			this.m_lblRFRFDigSysPeriodFrameTimingTest.AutoSize = true;
			this.m_lblRFRFDigSysPeriodFrameTimingTest.Location = new Point(200, 143);
			this.m_lblRFRFDigSysPeriodFrameTimingTest.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRFRFDigSysPeriodFrameTimingTest.Name = "m_lblRFRFDigSysPeriodFrameTimingTest";
			this.m_lblRFRFDigSysPeriodFrameTimingTest.Size = new Size(16, 17);
			this.m_lblRFRFDigSysPeriodFrameTimingTest.TabIndex = 17;
			this.m_lblRFRFDigSysPeriodFrameTimingTest.Text = "F";
			this.f0001bd.AutoSize = true;
			this.f0001bd.Location = new Point(200, 94);
			this.f0001bd.Margin = new Padding(4, 0, 4, 0);
			this.f0001bd.Name = "m_lblRFRFDigSysESMTest";
			this.f0001bd.Size = new Size(16, 17);
			this.f0001bd.TabIndex = 16;
			this.f0001bd.Text = "F";
			this.f0001be.AutoSize = true;
			this.f0001be.Location = new Point(200, 118);
			this.f0001be.Margin = new Padding(4, 0, 4, 0);
			this.f0001be.Name = "m_lblRFRFDigSysPeriodicDFESTC";
			this.f0001be.Size = new Size(16, 17);
			this.f0001be.TabIndex = 15;
			this.f0001be.Text = "F";
			this.m_lblRFRFDigSysPeriodicRegisterRead.AutoSize = true;
			this.m_lblRFRFDigSysPeriodicRegisterRead.Location = new Point(200, 69);
			this.m_lblRFRFDigSysPeriodicRegisterRead.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRFRFDigSysPeriodicRegisterRead.Name = "m_lblRFRFDigSysPeriodicRegisterRead";
			this.m_lblRFRFDigSysPeriodicRegisterRead.Size = new Size(16, 17);
			this.m_lblRFRFDigSysPeriodicRegisterRead.TabIndex = 14;
			this.m_lblRFRFDigSysPeriodicRegisterRead.Text = "F";
			this.label33.AutoSize = true;
			this.label33.Location = new Point(36, 143);
			this.label33.Margin = new Padding(4, 0, 4, 0);
			this.label33.Name = "label33";
			this.label33.Size = new Size(126, 17);
			this.label33.TabIndex = 13;
			this.label33.Text = "Frame Timing Test";
			this.label32.AutoSize = true;
			this.label32.Location = new Point(36, 94);
			this.label32.Margin = new Padding(4, 0, 4, 0);
			this.label32.Name = "label32";
			this.label32.Size = new Size(69, 17);
			this.label32.TabIndex = 12;
			this.label32.Text = "ESM Test";
			this.label31.AutoSize = true;
			this.label31.Location = new Point(36, 118);
			this.label31.Margin = new Padding(4, 0, 4, 0);
			this.label31.Name = "label31";
			this.label31.Size = new Size(66, 17);
			this.label31.TabIndex = 11;
			this.label31.Text = "DFE STC";
			this.label30.AutoSize = true;
			this.label30.Location = new Point(36, 69);
			this.label30.Margin = new Padding(4, 0, 4, 0);
			this.label30.Name = "label30";
			this.label30.Size = new Size(154, 17);
			this.label30.TabIndex = 10;
			this.label30.Text = "Periodic Register Read";
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultPCRMon);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001c4);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultRTIMon);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblLatentFaultRampGenMemPBIST);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultFFTMon);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001c5);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001c6);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblLatentFaultDiagnosticTestCheck);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001c7);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblLatentFaultROMCrcCheck);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001c8);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label4);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label3);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001c9);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpPowerUpTime);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label1);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultESMMon);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultWDTMon);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpRampGenMemECC);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpPCR);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpRTI);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpFFT);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultFRCLockStepMon);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label166);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label165);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultRampGenLockStepMon);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label164);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultDFEParityMon);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpROMCrcCheck);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001ca);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label26);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultRampGenECCMon);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001cb);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001cc);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001cd);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultCRCMon);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultVIMMon);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpESM);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpWDT);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblDigLatentFaultCR4LockStep);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001ce);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001cf);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001d0);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpFRCLockStep);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpRampGenLockStep);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001d1);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpDFEParity);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpCRCTest);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.f0001d2);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpSTCTest);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpVIMTest);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.m_lblBootUpCR4VimLockStep);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label84);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label85);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label87);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label88);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label54);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label55);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label56);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label57);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label58);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label59);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label60);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label61);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label62);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label63);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label64);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label65);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label66);
			this.m_grpRFBootUpBistStatusGet.Controls.Add(this.label68);
			this.m_grpRFBootUpBistStatusGet.Location = new Point(11, 7);
			this.m_grpRFBootUpBistStatusGet.Margin = new Padding(4, 4, 4, 4);
			this.m_grpRFBootUpBistStatusGet.Name = "m_grpRFBootUpBistStatusGet";
			this.m_grpRFBootUpBistStatusGet.Padding = new Padding(4, 4, 4, 4);
			this.m_grpRFBootUpBistStatusGet.Size = new Size(440, 636);
			this.m_grpRFBootUpBistStatusGet.TabIndex = 11;
			this.m_grpRFBootUpBistStatusGet.TabStop = false;
			this.m_grpRFBootUpBistStatusGet.Text = "RF BootUp BIST And Latent Fault Status Data";
			this.m_lblDigLatentFaultPCRMon.AutoSize = true;
			this.m_lblDigLatentFaultPCRMon.Location = new Point(307, 569);
			this.m_lblDigLatentFaultPCRMon.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultPCRMon.Name = "m_lblDigLatentFaultPCRMon";
			this.m_lblDigLatentFaultPCRMon.Size = new Size(16, 17);
			this.m_lblDigLatentFaultPCRMon.TabIndex = 13;
			this.m_lblDigLatentFaultPCRMon.Text = "F";
			this.f0001c4.AutoSize = true;
			this.f0001c4.Location = new Point(307, 375);
			this.f0001c4.Margin = new Padding(4, 0, 4, 0);
			this.f0001c4.Name = "m_lblLatentFaultPBIST";
			this.f0001c4.Size = new Size(13, 17);
			this.f0001c4.TabIndex = 152;
			this.f0001c4.Text = "-";
			this.m_lblDigLatentFaultRTIMon.AutoSize = true;
			this.m_lblDigLatentFaultRTIMon.Location = new Point(307, 544);
			this.m_lblDigLatentFaultRTIMon.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultRTIMon.Name = "m_lblDigLatentFaultRTIMon";
			this.m_lblDigLatentFaultRTIMon.Size = new Size(16, 17);
			this.m_lblDigLatentFaultRTIMon.TabIndex = 14;
			this.m_lblDigLatentFaultRTIMon.Text = "F";
			this.m_lblLatentFaultRampGenMemPBIST.AutoSize = true;
			this.m_lblLatentFaultRampGenMemPBIST.Location = new Point(307, 351);
			this.m_lblLatentFaultRampGenMemPBIST.Margin = new Padding(4, 0, 4, 0);
			this.m_lblLatentFaultRampGenMemPBIST.Name = "m_lblLatentFaultRampGenMemPBIST";
			this.m_lblLatentFaultRampGenMemPBIST.Size = new Size(13, 17);
			this.m_lblLatentFaultRampGenMemPBIST.TabIndex = 151;
			this.m_lblLatentFaultRampGenMemPBIST.Text = "-";
			this.m_lblDigLatentFaultFFTMon.AutoSize = true;
			this.m_lblDigLatentFaultFFTMon.Location = new Point(307, 519);
			this.m_lblDigLatentFaultFFTMon.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultFFTMon.Name = "m_lblDigLatentFaultFFTMon";
			this.m_lblDigLatentFaultFFTMon.Size = new Size(16, 17);
			this.m_lblDigLatentFaultFFTMon.TabIndex = 39;
			this.m_lblDigLatentFaultFFTMon.Text = "F";
			this.f0001c5.AutoSize = true;
			this.f0001c5.Location = new Point(307, 326);
			this.f0001c5.Margin = new Padding(4, 0, 4, 0);
			this.f0001c5.Name = "m_lblLatentFaultDFEMemPBIST";
			this.f0001c5.Size = new Size(13, 17);
			this.f0001c5.TabIndex = 150;
			this.f0001c5.Text = "-";
			this.f0001c6.AutoSize = true;
			this.f0001c6.Location = new Point(307, 154);
			this.f0001c6.Margin = new Padding(4, 0, 4, 0);
			this.f0001c6.Name = "m_lblLatentFaultCR4STC";
			this.f0001c6.Size = new Size(13, 17);
			this.f0001c6.TabIndex = 149;
			this.f0001c6.Text = "-";
			this.m_lblLatentFaultDiagnosticTestCheck.AutoSize = true;
			this.m_lblLatentFaultDiagnosticTestCheck.Location = new Point(307, 129);
			this.m_lblLatentFaultDiagnosticTestCheck.Margin = new Padding(4, 0, 4, 0);
			this.m_lblLatentFaultDiagnosticTestCheck.Name = "m_lblLatentFaultDiagnosticTestCheck";
			this.m_lblLatentFaultDiagnosticTestCheck.Size = new Size(13, 17);
			this.m_lblLatentFaultDiagnosticTestCheck.TabIndex = 148;
			this.m_lblLatentFaultDiagnosticTestCheck.Text = "-";
			this.f0001c7.AutoSize = true;
			this.f0001c7.Location = new Point(307, 496);
			this.f0001c7.Margin = new Padding(4, 0, 4, 0);
			this.f0001c7.Name = "m_lblDigLatentFaultATCMBTCMParityMon";
			this.f0001c7.Size = new Size(16, 17);
			this.f0001c7.TabIndex = 37;
			this.f0001c7.Text = "F";
			this.m_lblLatentFaultROMCrcCheck.AutoSize = true;
			this.m_lblLatentFaultROMCrcCheck.Location = new Point(307, 57);
			this.m_lblLatentFaultROMCrcCheck.Margin = new Padding(4, 0, 4, 0);
			this.m_lblLatentFaultROMCrcCheck.Name = "m_lblLatentFaultROMCrcCheck";
			this.m_lblLatentFaultROMCrcCheck.Size = new Size(13, 17);
			this.m_lblLatentFaultROMCrcCheck.TabIndex = 147;
			this.m_lblLatentFaultROMCrcCheck.Text = "-";
			this.f0001c8.AutoSize = true;
			this.f0001c8.Location = new Point(307, 471);
			this.f0001c8.Margin = new Padding(4, 0, 4, 0);
			this.f0001c8.Name = "m_lblDigLatentFaultATCMBTCMECCMon";
			this.f0001c8.Size = new Size(16, 17);
			this.f0001c8.TabIndex = 35;
			this.f0001c8.Text = "F";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(303, 23);
			this.label4.Margin = new Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(130, 17);
			this.label4.TabIndex = 146;
			this.label4.Text = "Latent Fault Report";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(181, 23);
			this.label3.Margin = new Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(102, 17);
			this.label3.TabIndex = 145;
			this.label3.Text = "BootUp Report";
			this.f0001c9.AutoSize = true;
			this.f0001c9.Location = new Point(307, 449);
			this.f0001c9.Margin = new Padding(4, 0, 4, 0);
			this.f0001c9.Name = "m_lblDigLatentFaultDFESTCMon";
			this.f0001c9.Size = new Size(16, 17);
			this.f0001c9.TabIndex = 34;
			this.f0001c9.Text = "F";
			this.m_lblBootUpPowerUpTime.AutoSize = true;
			this.m_lblBootUpPowerUpTime.Location = new Point(187, 607);
			this.m_lblBootUpPowerUpTime.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpPowerUpTime.Name = "m_lblBootUpPowerUpTime";
			this.m_lblBootUpPowerUpTime.Size = new Size(16, 17);
			this.m_lblBootUpPowerUpTime.TabIndex = 144;
			this.m_lblBootUpPowerUpTime.Text = "0";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(13, 607);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(132, 17);
			this.label1.TabIndex = 143;
			this.label1.Text = "PowerUp Time (ms)";
			this.m_lblDigLatentFaultESMMon.AutoSize = true;
			this.m_lblDigLatentFaultESMMon.Location = new Point(307, 425);
			this.m_lblDigLatentFaultESMMon.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultESMMon.Name = "m_lblDigLatentFaultESMMon";
			this.m_lblDigLatentFaultESMMon.Size = new Size(16, 17);
			this.m_lblDigLatentFaultESMMon.TabIndex = 32;
			this.m_lblDigLatentFaultESMMon.Text = "F";
			this.m_lblDigLatentFaultWDTMon.AutoSize = true;
			this.m_lblDigLatentFaultWDTMon.Location = new Point(307, 400);
			this.m_lblDigLatentFaultWDTMon.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultWDTMon.Name = "m_lblDigLatentFaultWDTMon";
			this.m_lblDigLatentFaultWDTMon.Size = new Size(13, 17);
			this.m_lblDigLatentFaultWDTMon.TabIndex = 30;
			this.m_lblDigLatentFaultWDTMon.Text = "-";
			this.m_lblBootUpRampGenMemECC.AutoSize = true;
			this.m_lblBootUpRampGenMemECC.Location = new Point(187, 203);
			this.m_lblBootUpRampGenMemECC.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpRampGenMemECC.Name = "m_lblBootUpRampGenMemECC";
			this.m_lblBootUpRampGenMemECC.Size = new Size(16, 17);
			this.m_lblBootUpRampGenMemECC.TabIndex = 142;
			this.m_lblBootUpRampGenMemECC.Text = "F";
			this.m_lblBootUpPCR.AutoSize = true;
			this.m_lblBootUpPCR.Location = new Point(187, 569);
			this.m_lblBootUpPCR.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpPCR.Name = "m_lblBootUpPCR";
			this.m_lblBootUpPCR.Size = new Size(16, 17);
			this.m_lblBootUpPCR.TabIndex = 141;
			this.m_lblBootUpPCR.Text = "F";
			this.m_lblBootUpRTI.AutoSize = true;
			this.m_lblBootUpRTI.Location = new Point(187, 544);
			this.m_lblBootUpRTI.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpRTI.Name = "m_lblBootUpRTI";
			this.m_lblBootUpRTI.Size = new Size(16, 17);
			this.m_lblBootUpRTI.TabIndex = 130;
			this.m_lblBootUpRTI.Text = "F";
			this.m_lblBootUpFFT.AutoSize = true;
			this.m_lblBootUpFFT.Location = new Point(187, 519);
			this.m_lblBootUpFFT.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpFFT.Name = "m_lblBootUpFFT";
			this.m_lblBootUpFFT.Size = new Size(16, 17);
			this.m_lblBootUpFFT.TabIndex = 129;
			this.m_lblBootUpFFT.Text = "F";
			this.m_lblDigLatentFaultFRCLockStepMon.AutoSize = true;
			this.m_lblDigLatentFaultFRCLockStepMon.Location = new Point(307, 302);
			this.m_lblDigLatentFaultFRCLockStepMon.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultFRCLockStepMon.Name = "m_lblDigLatentFaultFRCLockStepMon";
			this.m_lblDigLatentFaultFRCLockStepMon.Size = new Size(16, 17);
			this.m_lblDigLatentFaultFRCLockStepMon.TabIndex = 31;
			this.m_lblDigLatentFaultFRCLockStepMon.Text = "F";
			this.label166.AutoSize = true;
			this.label166.Location = new Point(13, 569);
			this.label166.Margin = new Padding(4, 0, 4, 0);
			this.label166.Name = "label166";
			this.label166.Size = new Size(68, 17);
			this.label166.TabIndex = 125;
			this.label166.Text = "PCR Test";
			this.label165.AutoSize = true;
			this.label165.Location = new Point(13, 544);
			this.label165.Margin = new Padding(4, 0, 4, 0);
			this.label165.Name = "label165";
			this.label165.Size = new Size(62, 17);
			this.label165.TabIndex = 124;
			this.label165.Text = "RTI Test";
			this.m_lblDigLatentFaultRampGenLockStepMon.AutoSize = true;
			this.m_lblDigLatentFaultRampGenLockStepMon.Location = new Point(307, 277);
			this.m_lblDigLatentFaultRampGenLockStepMon.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultRampGenLockStepMon.Name = "m_lblDigLatentFaultRampGenLockStepMon";
			this.m_lblDigLatentFaultRampGenLockStepMon.Size = new Size(16, 17);
			this.m_lblDigLatentFaultRampGenLockStepMon.TabIndex = 29;
			this.m_lblDigLatentFaultRampGenLockStepMon.Text = "F";
			this.label164.AutoSize = true;
			this.label164.Location = new Point(13, 519);
			this.label164.Margin = new Padding(4, 0, 4, 0);
			this.label164.Name = "label164";
			this.label164.Size = new Size(65, 17);
			this.label164.TabIndex = 123;
			this.label164.Text = "FFT Test";
			this.m_lblDigLatentFaultDFEParityMon.AutoSize = true;
			this.m_lblDigLatentFaultDFEParityMon.Location = new Point(307, 228);
			this.m_lblDigLatentFaultDFEParityMon.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultDFEParityMon.Name = "m_lblDigLatentFaultDFEParityMon";
			this.m_lblDigLatentFaultDFEParityMon.Size = new Size(16, 17);
			this.m_lblDigLatentFaultDFEParityMon.TabIndex = 28;
			this.m_lblDigLatentFaultDFEParityMon.Text = "F";
			this.m_lblBootUpROMCrcCheck.AutoSize = true;
			this.m_lblBootUpROMCrcCheck.Location = new Point(187, 57);
			this.m_lblBootUpROMCrcCheck.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpROMCrcCheck.Name = "m_lblBootUpROMCrcCheck";
			this.m_lblBootUpROMCrcCheck.Size = new Size(16, 17);
			this.m_lblBootUpROMCrcCheck.TabIndex = 116;
			this.m_lblBootUpROMCrcCheck.Text = "F";
			this.f0001ca.AutoSize = true;
			this.f0001ca.Location = new Point(307, 252);
			this.f0001ca.Margin = new Padding(4, 0, 4, 0);
			this.f0001ca.Name = "m_lblDigLatentFaultDFEECCMon";
			this.f0001ca.Size = new Size(16, 17);
			this.f0001ca.TabIndex = 27;
			this.f0001ca.Text = "F";
			this.label26.AutoSize = true;
			this.label26.Location = new Point(13, 57);
			this.label26.Margin = new Padding(4, 0, 4, 0);
			this.label26.Name = "label26";
			this.label26.Size = new Size(115, 17);
			this.label26.TabIndex = 115;
			this.label26.Text = "ROM CRC Check";
			this.m_lblDigLatentFaultRampGenECCMon.AutoSize = true;
			this.m_lblDigLatentFaultRampGenECCMon.Location = new Point(307, 203);
			this.m_lblDigLatentFaultRampGenECCMon.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultRampGenECCMon.Name = "m_lblDigLatentFaultRampGenECCMon";
			this.m_lblDigLatentFaultRampGenECCMon.Size = new Size(16, 17);
			this.m_lblDigLatentFaultRampGenECCMon.TabIndex = 26;
			this.m_lblDigLatentFaultRampGenECCMon.Text = "F";
			this.f0001cb.AutoSize = true;
			this.f0001cb.Location = new Point(187, 496);
			this.f0001cb.Margin = new Padding(4, 0, 4, 0);
			this.f0001cb.Name = "m_lblBootUpATCMBTCMParity";
			this.f0001cb.Size = new Size(16, 17);
			this.f0001cb.TabIndex = 73;
			this.f0001cb.Text = "F";
			this.f0001cc.AutoSize = true;
			this.f0001cc.Location = new Point(187, 471);
			this.f0001cc.Margin = new Padding(4, 0, 4, 0);
			this.f0001cc.Name = "m_lblBootUpATCMBTCMECC";
			this.f0001cc.Size = new Size(16, 17);
			this.f0001cc.TabIndex = 72;
			this.f0001cc.Text = "F";
			this.f0001cd.AutoSize = true;
			this.f0001cd.Location = new Point(187, 449);
			this.f0001cd.Margin = new Padding(4, 0, 4, 0);
			this.f0001cd.Name = "m_lblBootUpDFESTC";
			this.f0001cd.Size = new Size(16, 17);
			this.f0001cd.TabIndex = 70;
			this.f0001cd.Text = "F";
			this.m_lblDigLatentFaultCRCMon.AutoSize = true;
			this.m_lblDigLatentFaultCRCMon.Location = new Point(307, 178);
			this.m_lblDigLatentFaultCRCMon.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultCRCMon.Name = "m_lblDigLatentFaultCRCMon";
			this.m_lblDigLatentFaultCRCMon.Size = new Size(16, 17);
			this.m_lblDigLatentFaultCRCMon.TabIndex = 24;
			this.m_lblDigLatentFaultCRCMon.Text = "F";
			this.m_lblDigLatentFaultVIMMon.AutoSize = true;
			this.m_lblDigLatentFaultVIMMon.Location = new Point(307, 105);
			this.m_lblDigLatentFaultVIMMon.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultVIMMon.Name = "m_lblDigLatentFaultVIMMon";
			this.m_lblDigLatentFaultVIMMon.Size = new Size(16, 17);
			this.m_lblDigLatentFaultVIMMon.TabIndex = 25;
			this.m_lblDigLatentFaultVIMMon.Text = "F";
			this.m_lblBootUpESM.AutoSize = true;
			this.m_lblBootUpESM.Location = new Point(187, 425);
			this.m_lblBootUpESM.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpESM.Name = "m_lblBootUpESM";
			this.m_lblBootUpESM.Size = new Size(16, 17);
			this.m_lblBootUpESM.TabIndex = 69;
			this.m_lblBootUpESM.Text = "F";
			this.m_lblBootUpWDT.AutoSize = true;
			this.m_lblBootUpWDT.Location = new Point(187, 400);
			this.m_lblBootUpWDT.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpWDT.Name = "m_lblBootUpWDT";
			this.m_lblBootUpWDT.Size = new Size(16, 17);
			this.m_lblBootUpWDT.TabIndex = 68;
			this.m_lblBootUpWDT.Text = "F";
			this.m_lblDigLatentFaultCR4LockStep.AutoSize = true;
			this.m_lblDigLatentFaultCR4LockStep.Location = new Point(307, 81);
			this.m_lblDigLatentFaultCR4LockStep.Margin = new Padding(4, 0, 4, 0);
			this.m_lblDigLatentFaultCR4LockStep.Name = "m_lblDigLatentFaultCR4LockStep";
			this.m_lblDigLatentFaultCR4LockStep.Size = new Size(16, 17);
			this.m_lblDigLatentFaultCR4LockStep.TabIndex = 23;
			this.m_lblDigLatentFaultCR4LockStep.Text = "F";
			this.f0001ce.AutoSize = true;
			this.f0001ce.Location = new Point(187, 375);
			this.f0001ce.Margin = new Padding(4, 0, 4, 0);
			this.f0001ce.Name = "m_lblBootUpPBIST";
			this.f0001ce.Size = new Size(16, 17);
			this.f0001ce.TabIndex = 67;
			this.f0001ce.Text = "F";
			this.f0001cf.AutoSize = true;
			this.f0001cf.Location = new Point(187, 351);
			this.f0001cf.Margin = new Padding(4, 0, 4, 0);
			this.f0001cf.Name = "m_lblBootUpRampGenMemPBIST";
			this.f0001cf.Size = new Size(16, 17);
			this.f0001cf.TabIndex = 66;
			this.f0001cf.Text = "F";
			this.f0001d0.AutoSize = true;
			this.f0001d0.Location = new Point(187, 326);
			this.f0001d0.Margin = new Padding(4, 0, 4, 0);
			this.f0001d0.Name = "m_lblBootUpDFEMemPBIST";
			this.f0001d0.Size = new Size(16, 17);
			this.f0001d0.TabIndex = 65;
			this.f0001d0.Text = "F";
			this.m_lblBootUpFRCLockStep.AutoSize = true;
			this.m_lblBootUpFRCLockStep.Location = new Point(187, 302);
			this.m_lblBootUpFRCLockStep.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpFRCLockStep.Name = "m_lblBootUpFRCLockStep";
			this.m_lblBootUpFRCLockStep.Size = new Size(16, 17);
			this.m_lblBootUpFRCLockStep.TabIndex = 64;
			this.m_lblBootUpFRCLockStep.Text = "F";
			this.m_lblBootUpRampGenLockStep.AutoSize = true;
			this.m_lblBootUpRampGenLockStep.Location = new Point(187, 277);
			this.m_lblBootUpRampGenLockStep.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpRampGenLockStep.Name = "m_lblBootUpRampGenLockStep";
			this.m_lblBootUpRampGenLockStep.Size = new Size(16, 17);
			this.m_lblBootUpRampGenLockStep.TabIndex = 63;
			this.m_lblBootUpRampGenLockStep.Text = "F";
			this.f0001d1.AutoSize = true;
			this.f0001d1.Location = new Point(187, 252);
			this.f0001d1.Margin = new Padding(4, 0, 4, 0);
			this.f0001d1.Name = "m_lblBootUpDFEMemECC";
			this.f0001d1.Size = new Size(16, 17);
			this.f0001d1.TabIndex = 62;
			this.f0001d1.Text = "F";
			this.m_lblBootUpDFEParity.AutoSize = true;
			this.m_lblBootUpDFEParity.Location = new Point(187, 228);
			this.m_lblBootUpDFEParity.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpDFEParity.Name = "m_lblBootUpDFEParity";
			this.m_lblBootUpDFEParity.Size = new Size(16, 17);
			this.m_lblBootUpDFEParity.TabIndex = 61;
			this.m_lblBootUpDFEParity.Text = "F";
			this.m_lblBootUpCRCTest.AutoSize = true;
			this.m_lblBootUpCRCTest.Location = new Point(187, 178);
			this.m_lblBootUpCRCTest.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpCRCTest.Name = "m_lblBootUpCRCTest";
			this.m_lblBootUpCRCTest.Size = new Size(16, 17);
			this.m_lblBootUpCRCTest.TabIndex = 60;
			this.m_lblBootUpCRCTest.Text = "F";
			this.f0001d2.AutoSize = true;
			this.f0001d2.Location = new Point(187, 154);
			this.f0001d2.Margin = new Padding(4, 0, 4, 0);
			this.f0001d2.Name = "m_lblBootUpCR4STC";
			this.f0001d2.Size = new Size(16, 17);
			this.f0001d2.TabIndex = 59;
			this.f0001d2.Text = "F";
			this.m_lblBootUpSTCTest.AutoSize = true;
			this.m_lblBootUpSTCTest.Location = new Point(187, 129);
			this.m_lblBootUpSTCTest.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpSTCTest.Name = "m_lblBootUpSTCTest";
			this.m_lblBootUpSTCTest.Size = new Size(16, 17);
			this.m_lblBootUpSTCTest.TabIndex = 58;
			this.m_lblBootUpSTCTest.Text = "F";
			this.m_lblBootUpVIMTest.AutoSize = true;
			this.m_lblBootUpVIMTest.Location = new Point(187, 105);
			this.m_lblBootUpVIMTest.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpVIMTest.Name = "m_lblBootUpVIMTest";
			this.m_lblBootUpVIMTest.Size = new Size(16, 17);
			this.m_lblBootUpVIMTest.TabIndex = 57;
			this.m_lblBootUpVIMTest.Text = "F";
			this.m_lblBootUpCR4VimLockStep.AutoSize = true;
			this.m_lblBootUpCR4VimLockStep.Location = new Point(187, 81);
			this.m_lblBootUpCR4VimLockStep.Margin = new Padding(4, 0, 4, 0);
			this.m_lblBootUpCR4VimLockStep.Name = "m_lblBootUpCR4VimLockStep";
			this.m_lblBootUpCR4VimLockStep.Size = new Size(16, 17);
			this.m_lblBootUpCR4VimLockStep.TabIndex = 55;
			this.m_lblBootUpCR4VimLockStep.Text = "F";
			this.label84.AutoSize = true;
			this.label84.Location = new Point(13, 496);
			this.label84.Margin = new Padding(4, 0, 4, 0);
			this.label84.Name = "label84";
			this.label84.Size = new Size(132, 17);
			this.label84.TabIndex = 49;
			this.label84.Text = "ATCM, BTCM Parity";
			this.label85.AutoSize = true;
			this.label85.Location = new Point(13, 471);
			this.label85.Margin = new Padding(4, 0, 4, 0);
			this.label85.Name = "label85";
			this.label85.Size = new Size(123, 17);
			this.label85.TabIndex = 48;
			this.label85.Text = "ATCM, BTCM ECC";
			this.label87.AutoSize = true;
			this.label87.Location = new Point(13, 449);
			this.label87.Margin = new Padding(4, 0, 4, 0);
			this.label87.Name = "label87";
			this.label87.Size = new Size(66, 17);
			this.label87.TabIndex = 46;
			this.label87.Text = "DFE STC";
			this.label88.AutoSize = true;
			this.label88.Location = new Point(13, 425);
			this.label88.Margin = new Padding(4, 0, 4, 0);
			this.label88.Name = "label88";
			this.label88.Size = new Size(69, 17);
			this.label88.TabIndex = 45;
			this.label88.Text = "ESM Test";
			this.label54.AutoSize = true;
			this.label54.Location = new Point(13, 400);
			this.label54.Margin = new Padding(4, 0, 4, 0);
			this.label54.Name = "label54";
			this.label54.Size = new Size(72, 17);
			this.label54.TabIndex = 29;
			this.label54.Text = "WDT Test";
			this.label55.AutoSize = true;
			this.label55.Location = new Point(13, 375);
			this.label55.Margin = new Padding(4, 0, 4, 0);
			this.label55.Name = "label55";
			this.label55.Size = new Size(79, 17);
			this.label55.TabIndex = 28;
			this.label55.Text = "PBIST Test";
			this.label56.AutoSize = true;
			this.label56.Location = new Point(13, 351);
			this.label56.Margin = new Padding(4, 0, 4, 0);
			this.label56.Name = "label56";
			this.label56.Size = new Size(149, 17);
			this.label56.TabIndex = 27;
			this.label56.Text = "RampGen Mem PBIST";
			this.label57.AutoSize = true;
			this.label57.Location = new Point(13, 326);
			this.label57.Margin = new Padding(4, 0, 4, 0);
			this.label57.Name = "label57";
			this.label57.Size = new Size(132, 17);
			this.label57.TabIndex = 26;
			this.label57.Text = "DFE Memory PBIST";
			this.label58.AutoSize = true;
			this.label58.Location = new Point(13, 302);
			this.label58.Margin = new Padding(4, 0, 4, 0);
			this.label58.Name = "label58";
			this.label58.Size = new Size(98, 17);
			this.label58.TabIndex = 25;
			this.label58.Text = "FRC LockStep";
			this.label59.AutoSize = true;
			this.label59.Location = new Point(13, 277);
			this.label59.Margin = new Padding(4, 0, 4, 0);
			this.label59.Name = "label59";
			this.label59.Size = new Size(139, 17);
			this.label59.TabIndex = 24;
			this.label59.Text = "RampGen Lock Step";
			this.label60.AutoSize = true;
			this.label60.Location = new Point(13, 252);
			this.label60.Margin = new Padding(4, 0, 4, 0);
			this.label60.Name = "label60";
			this.label60.Size = new Size(100, 17);
			this.label60.TabIndex = 23;
			this.label60.Text = "DFE Mem ECC";
			this.label61.AutoSize = true;
			this.label61.Location = new Point(13, 228);
			this.label61.Margin = new Padding(4, 0, 4, 0);
			this.label61.Name = "label61";
			this.label61.Size = new Size(75, 17);
			this.label61.TabIndex = 22;
			this.label61.Text = "DFE Parity";
			this.label62.AutoSize = true;
			this.label62.Location = new Point(13, 203);
			this.label62.Margin = new Padding(4, 0, 4, 0);
			this.label62.Name = "label62";
			this.label62.Size = new Size(137, 17);
			this.label62.TabIndex = 21;
			this.label62.Text = "RampGen Mem ECC";
			this.label63.AutoSize = true;
			this.label63.Location = new Point(13, 178);
			this.label63.Margin = new Padding(4, 0, 4, 0);
			this.label63.Name = "label63";
			this.label63.Size = new Size(68, 17);
			this.label63.TabIndex = 20;
			this.label63.Text = "CRC Test";
			this.label64.AutoSize = true;
			this.label64.Location = new Point(13, 154);
			this.label64.Margin = new Padding(4, 0, 4, 0);
			this.label64.Name = "label64";
			this.label64.Size = new Size(66, 17);
			this.label64.TabIndex = 19;
			this.label64.Text = "CR4 STC";
			this.label65.AutoSize = true;
			this.label65.Location = new Point(13, 129);
			this.label65.Margin = new Padding(4, 0, 4, 0);
			this.label65.Name = "label65";
			this.label65.Size = new Size(137, 17);
			this.label65.TabIndex = 18;
			this.label65.Text = "Diagnostic STC Test";
			this.label66.AutoSize = true;
			this.label66.Location = new Point(13, 105);
			this.label66.Margin = new Padding(4, 0, 4, 0);
			this.label66.Name = "label66";
			this.label66.Size = new Size(63, 17);
			this.label66.TabIndex = 17;
			this.label66.Text = "VIM Test";
			this.label68.AutoSize = true;
			this.label68.Location = new Point(13, 81);
			this.label68.Margin = new Padding(4, 0, 4, 0);
			this.label68.Name = "label68";
			this.label68.Size = new Size(153, 17);
			this.label68.TabIndex = 15;
			this.label68.Text = "CR4 and VIM LockStep";
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.m_grpRFBootUpBistStatusGet);
			base.Controls.Add(this.m_grpRFDigSysPeriodicMonCfg);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.m_grpRFDigSysLatentFaultCfg);
			base.Margin = new Padding(4, 4, 4, 4);
			base.Name = "MonitoringConfig";
			base.Size = new Size(1977, 753);
			this.m_grpRFDigSysLatentFaultCfg.ResumeLayout(false);
			this.m_grpRFDigSysLatentFaultCfg.PerformLayout();
			this.m_grpRFDigSysPeriodicMonCfg.ResumeLayout(false);
			this.m_grpRFDigSysPeriodicMonCfg.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.m_grpRFBootUpBistStatusGet.ResumeLayout(false);
			this.m_grpRFBootUpBistStatusGet.PerformLayout();
			base.ResumeLayout(false);
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		private MonitoringModeConfigParameters m_MonitoringModeConfigParameters;

		private RFDigitalSysPeriodicConfigParameters m_RFDigitalSysPeriodicConfigParameters;

		private RFDigitalSysLatentFaultConfigParameters m_RFDigitalSysLatentFaultConfigParameters;

		private IContainer components;

		private GroupBox m_grpRFDigSysLatentFaultCfg;

		private GroupBox m_grpRFDigSysPeriodicMonCfg;

		private CheckBox m_chbRFDigSysFrameTimingTest;

		private CheckBox f0001bb;

		private CheckBox f0001bc;

		private CheckBox m_chbRFDigSysPeriodicRegisterRead;

		private ComboBox m_cboRFDigSysPeriodMonitoringMode;

		private Label label25;

		private Label label14;

		private Button m_btnRFDigitalSysPeriodicMonConfigSet;

		private GroupBox groupBox1;

		private Label m_lblRFRFDigSysPeriodFrameTimingTest;

		private Label f0001bd;

		private Label f0001be;

		private Label m_lblRFRFDigSysPeriodicRegisterRead;

		private Label label33;

		private Label label32;

		private Label label31;

		private Label label30;

		private Label label27;

		private Label label29;

		private Label f0001bf;

		private CheckBox f0001c0;

		private CheckBox m_chbPCRMon;

		private CheckBox m_chbRTIMon;

		private CheckBox m_chbFFTMon;

		private CheckBox m_chbRampGenLockStepMon;

		private CheckBox f0001c1;

		private CheckBox f0001c2;

		private CheckBox m_chbESMMon;

		private CheckBox m_chbFRCLockStepMon;

		private CheckBox m_chbCR4Lockstep;

		private CheckBox m_chbRampGenECCMon;

		private CheckBox f0001c3;

		private CheckBox m_chbDFEParityMon;

		private CheckBox m_chbCRCMon;

		private CheckBox m_chbVIMMon;

		private Button m_btnRFDigitalSysLatentFaultMonConfigSet;

		private ComboBox m_cboRFDigSysDigSysLatentFaultTestMode;

		private Label label2;

		private GroupBox m_grpRFBootUpBistStatusGet;

		private Label m_lblDigLatentFaultPCRMon;

		private Label f0001c4;

		private Label m_lblDigLatentFaultRTIMon;

		private Label m_lblLatentFaultRampGenMemPBIST;

		private Label m_lblDigLatentFaultFFTMon;

		private Label f0001c5;

		private Label f0001c6;

		private Label m_lblLatentFaultDiagnosticTestCheck;

		private Label f0001c7;

		private Label m_lblLatentFaultROMCrcCheck;

		private Label f0001c8;

		private Label label4;

		private Label label3;

		private Label f0001c9;

		private Label m_lblBootUpPowerUpTime;

		private Label label1;

		private Label m_lblDigLatentFaultESMMon;

		private Label m_lblDigLatentFaultWDTMon;

		private Label m_lblBootUpRampGenMemECC;

		private Label m_lblBootUpPCR;

		private Label m_lblBootUpRTI;

		private Label m_lblBootUpFFT;

		private Label m_lblDigLatentFaultFRCLockStepMon;

		private Label label166;

		private Label label165;

		private Label m_lblDigLatentFaultRampGenLockStepMon;

		private Label label164;

		private Label m_lblDigLatentFaultDFEParityMon;

		private Label m_lblBootUpROMCrcCheck;

		private Label f0001ca;

		private Label label26;

		private Label m_lblDigLatentFaultRampGenECCMon;

		private Label f0001cb;

		private Label f0001cc;

		private Label f0001cd;

		private Label m_lblDigLatentFaultCRCMon;

		private Label m_lblDigLatentFaultVIMMon;

		private Label m_lblBootUpESM;

		private Label m_lblBootUpWDT;

		private Label m_lblDigLatentFaultCR4LockStep;

		private Label f0001ce;

		private Label f0001cf;

		private Label f0001d0;

		private Label m_lblBootUpFRCLockStep;

		private Label m_lblBootUpRampGenLockStep;

		private Label f0001d1;

		private Label m_lblBootUpDFEParity;

		private Label m_lblBootUpCRCTest;

		private Label f0001d2;

		private Label m_lblBootUpSTCTest;

		private Label m_lblBootUpVIMTest;

		private Label m_lblBootUpCR4VimLockStep;

		private Label label84;

		private Label label85;

		private Label label87;

		private Label label88;

		private Label label54;

		private Label label55;

		private Label label56;

		private Label label57;

		private Label label58;

		private Label label59;

		private Label label60;

		private Label label61;

		private Label label62;

		private Label label63;

		private Label label64;

		private Label label65;

		private Label label66;

		private Label label68;
	}
}
