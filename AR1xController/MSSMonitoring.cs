using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class MSSMonitoring : UserControl
	{
		public MSSMonitoring()
		{
			InitializeComponent();
			m_MainForm = m_GuiManager.MainTsForm;
			m_MSSLatentFaultTestConfigParameters = m_GuiManager.TsParams.MSSLatentFaultTestConfigParameters;
			m_MSSPeriodicTestConfigParameters = m_GuiManager.TsParams.MSSPeriodicTestConfigParameters;
			m_cboMSSRFDigSysDigSysLatentFaultTestMode.SelectedIndex = 0;
		}

		private int iSetMSSRFDigitalSysLatentFaultMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetMSSLatentFaultMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetMSSRFDigitalSysLatentFaultMonConfig()
		{
			iSetMSSRFDigitalSysLatentFaultMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetMSSRFDigitalSysLatentFaultMonConfigAsync()
		{
			new del_v_v(iSetMSSRFDigitalSysLatentFaultMonConfig).BeginInvoke(null, null);
		}

		private void m_btnMSSRFDigitalSysLatentFaultMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetMSSRFDigitalSysLatentFaultMonConfigAsync();
		}

		public bool UpdateMonitoringMSSRFDigitalSysLatentFaultConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateMonitoringMSSRFDigitalSysLatentFaultConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MSSLatentFaultTestConfigParameters.f000322 = (m_chbMSSMibSPIMon.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.DMAMOn = (m_chbMSSDMAMon.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.RTIMOn = (m_chbMSSRTIMon.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.ESMMOn = (m_chbMSSESMMon.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.f000323 = (m_chbMSSEDMAMon.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.CRCMOn = (m_chbMSSCRCMon.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.VIMMon = (m_chbMSSVIMMon.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.MailBoxMon = (m_chbMSSMailBoxMon.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.LVDSPatternGenMon = (m_chbMSSLVDSPatternGenMon.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.CSI2PatternGenMon = (m_chbMSSCIS2PatternGenMon.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.GenNErrorMon = (m_chbMSSGenerateNERROR.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.MibSPISingleBitErrorMon = (m_chbMSSMibSPISingleBitError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.MibSPIDoubleBitErrorMon = (m_chbMSSMibSPIDoubleBitError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.DMAParityError = (m_chbMSSDMAParityError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.TCMARamSingleBitErrorMon = (m_chbMSSTCMARAM1BitError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.TCMBRamSingleBitErrorMon = (m_chbMSSTCMBRAM1BitError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.TCMARamDoubleBitErrorMon = (m_chbMSSTCMARAM2BitError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.TCMBRamDoubleBitErrorMon = (m_chbMSSTCMBRAM2BitError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.TCMARamParityErrorMon = (m_chbMSSTCMARAMParityError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.TCMBRamParityErrorMon = (m_chbMSSTCMBRAMParityError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.f000324 = (m_chbMSSDMAMPURegion.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.MSSMailBoxSingleBitErrorMon = (m_chbMSSMailBox1BitError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.MSSMailBoxDoubleBitErrorMon = (m_chbMSSMailBox2BitError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.BSSMailBoxSingleBitErrorMon = (m_chbBSSMailBox1BitError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.BSSMailBoxDoubleBitErrorMon = (m_chbBSSMailBox2BitError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.f000325 = (m_chbMSSEDMAMPUsSelfTest.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.EDMAParityMon = (m_chbMSSEDMAParitySelfTest.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.CSI2ParityMon = (m_chbMSSCSI2ParitySelfTest.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.DCCSelfTest = (m_chbMSSDCCError.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.PCRFaultGenTest = (m_chbMSSPCRFaultGenerator.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.ReportingMode = (char)m_nudMSSReportingMode.Value;
				m_MSSLatentFaultTestConfigParameters.TestMode = (char)m_cboMSSRFDigSysDigSysLatentFaultTestMode.SelectedIndex;
				m_MSSLatentFaultTestConfigParameters.DCCFaultInsertion = (m_chbDCCFaultInsertion.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.VIMRamParity = (m_chbVIMRamParity.Checked ? '\u0001' : '\0');
				m_MSSLatentFaultTestConfigParameters.SCI = (m_chbSCIBootTimeTest.Checked ? '\u0001' : '\0');
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMonitoringMSSConfigData(RootObject jobject, int p1)
		{
			bool result;
			try
			{
				if (jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.isConfigured == 0)
				{
					string msg = string.Format("Missing Latent Fault Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg);
				}
				else
				{
					m_chbMSSMibSPIMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 1) == 1);
					m_chbMSSDMAMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 2) >> 1 == 1);
					m_chbMSSRTIMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 8) >> 3 == 1);
					m_chbMSSESMMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 16) >> 4 == 1);
					m_chbMSSEDMAMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 32) >> 5 == 1);
					m_chbMSSCRCMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 64) >> 6 == 1);
					m_chbMSSVIMMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 128) >> 7 == 1);
					m_chbMSSMailBoxMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 512) >> 9 == 1);
					m_chbMSSLVDSPatternGenMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 1024) >> 10 == 1);
					m_chbMSSCIS2PatternGenMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 2048) >> 11 == 1);
					m_chbMSSGenerateNERROR.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 4096) >> 12 == 1);
					m_chbMSSMibSPISingleBitError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 8192) >> 13 == 1);
					m_chbMSSMibSPIDoubleBitError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 16384) >> 14 == 1);
					m_chbMSSDMAParityError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 32768) >> 15 == 1);
					m_chbMSSTCMARAM1BitError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 65536) >> 16 == 1);
					m_chbMSSTCMBRAM1BitError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 131072) >> 17 == 1);
					m_chbMSSTCMARAM2BitError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 262144) >> 18 == 1);
					m_chbMSSTCMBRAM2BitError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 524288) >> 19 == 1);
					m_chbMSSTCMARAMParityError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 1048576) >> 20 == 1);
					m_chbMSSTCMBRAMParityError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 2097152) >> 21 == 1);
					m_chbMSSDMAMPURegion.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 16777216) >> 24 == 1);
					m_chbMSSMailBox1BitError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 33554432) >> 25 == 1);
					m_chbMSSMailBox2BitError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 67108864) >> 26 == 1);
					m_chbBSSMailBox1BitError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 134217728) >> 27 == 1);
					m_chbBSSMailBox2BitError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 268435456) >> 28 == 1);
					m_chbMSSEDMAMPUsSelfTest.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 536870912) >> 29 == 1);
					m_chbMSSEDMAParitySelfTest.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 1073741824) >> 30 == 1);
					m_chbMSSCSI2ParitySelfTest.Checked = (((long)Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn1, 16) & 2147483648L) >> 31 == 1L);
					m_chbMSSDCCError.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn2, 16) & 1) == 1);
					m_chbDCCFaultInsertion.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn2, 16) & 2) >> 1 == 1);
					m_chbMSSPCRFaultGenerator.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn2, 16) & 4) >> 2 == 1);
					m_chbVIMRamParity.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn2, 16) & 8) >> 3 == 1);
					m_chbSCIBootTimeTest.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testEn2, 16) & 16) >> 4 == 1);
					m_nudMSSReportingMode.Value = jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.repMode;
					m_cboMSSRFDigSysDigSysLatentFaultTestMode.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rllatentFault_t.testMode;
				}
				if (jobject.mmWaveDevices[p1].rfConfig.rlperiodicTest_t.isConfigured == 0)
				{
					string msg2 = string.Format("Missing Periodic Test Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg2);
				}
				else
				{
					m_nudPeriodicity.Value = jobject.mmWaveDevices[p1].rfConfig.rlperiodicTest_t.periodicity_msec;
					m_chbPeriodicConfigRegisterReadEn.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlperiodicTest_t.testEn, 16) & 1) == 1);
					m_chbESMMonitoringSelfTest.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlperiodicTest_t.testEn, 16) & 2) >> 1 == 1);
					m_nudMSSPeriodcReportingMode.Value = jobject.mmWaveDevices[p1].rfConfig.rlperiodicTest_t.repMode;
				}
				result = true;
			}
			catch
			{
				string msg3 = string.Format("MSS Monitoring Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg3);
				result = false;
			}
			return result;
		}

		public bool UpdateMonitoringMSSRFDigitalSysLatentFaultConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				return (bool)base.Invoke(new del_b_v(UpdateMonitoringMSSRFDigitalSysLatentFaultConfigDataFrmCmdSrc));
			}
			bool result;
			try
			{
				m_chbMSSMibSPIMon.Checked = (m_MSSLatentFaultTestConfigParameters.f000322 == '\u0001');
				m_chbMSSDMAMon.Checked = (m_MSSLatentFaultTestConfigParameters.DMAMOn == '\u0001');
				m_chbMSSRTIMon.Checked = (m_MSSLatentFaultTestConfigParameters.RTIMOn == '\u0001');
				m_chbMSSESMMon.Checked = (m_MSSLatentFaultTestConfigParameters.ESMMOn == '\u0001');
				m_chbMSSEDMAMon.Checked = (m_MSSLatentFaultTestConfigParameters.f000323 == '\u0001');
				m_chbMSSCRCMon.Checked = (m_MSSLatentFaultTestConfigParameters.CRCMOn == '\u0001');
				m_chbMSSVIMMon.Checked = (m_MSSLatentFaultTestConfigParameters.VIMMon == '\u0001');
				m_chbMSSMailBoxMon.Checked = (m_MSSLatentFaultTestConfigParameters.MailBoxMon == '\u0001');
				m_chbMSSLVDSPatternGenMon.Checked = (m_MSSLatentFaultTestConfigParameters.LVDSPatternGenMon == '\u0001');
				m_chbMSSCIS2PatternGenMon.Checked = (m_MSSLatentFaultTestConfigParameters.CSI2PatternGenMon == '\u0001');
				m_chbMSSGenerateNERROR.Checked = (m_MSSLatentFaultTestConfigParameters.GenNErrorMon == '\u0001');
				m_chbMSSMibSPISingleBitError.Checked = (m_MSSLatentFaultTestConfigParameters.MibSPISingleBitErrorMon == '\u0001');
				m_chbMSSMibSPIDoubleBitError.Checked = (m_MSSLatentFaultTestConfigParameters.MibSPIDoubleBitErrorMon == '\u0001');
				m_chbMSSDMAParityError.Checked = (m_MSSLatentFaultTestConfigParameters.DMAParityError == '\u0001');
				m_chbMSSTCMARAM1BitError.Checked = (m_MSSLatentFaultTestConfigParameters.TCMARamSingleBitErrorMon == '\u0001');
				m_chbMSSTCMBRAM1BitError.Checked = (m_MSSLatentFaultTestConfigParameters.TCMBRamSingleBitErrorMon == '\u0001');
				m_chbMSSTCMARAM2BitError.Checked = (m_MSSLatentFaultTestConfigParameters.TCMARamDoubleBitErrorMon == '\u0001');
				m_chbMSSTCMBRAM2BitError.Checked = (m_MSSLatentFaultTestConfigParameters.TCMBRamDoubleBitErrorMon == '\u0001');
				m_chbMSSTCMARAMParityError.Checked = (m_MSSLatentFaultTestConfigParameters.TCMARamParityErrorMon == '\u0001');
				m_chbMSSTCMBRAMParityError.Checked = (m_MSSLatentFaultTestConfigParameters.TCMBRamParityErrorMon == '\u0001');
				m_chbMSSDMAMPURegion.Checked = (m_MSSLatentFaultTestConfigParameters.f000324 == '\u0001');
				m_chbMSSMailBox1BitError.Checked = (m_MSSLatentFaultTestConfigParameters.MSSMailBoxSingleBitErrorMon == '\u0001');
				m_chbMSSMailBox2BitError.Checked = (m_MSSLatentFaultTestConfigParameters.MSSMailBoxDoubleBitErrorMon == '\u0001');
				m_chbBSSMailBox1BitError.Checked = (m_MSSLatentFaultTestConfigParameters.BSSMailBoxSingleBitErrorMon == '\u0001');
				m_chbBSSMailBox2BitError.Checked = (m_MSSLatentFaultTestConfigParameters.BSSMailBoxDoubleBitErrorMon == '\u0001');
				m_chbMSSEDMAMPUsSelfTest.Checked = (m_MSSLatentFaultTestConfigParameters.f000325 == '\u0001');
				m_chbMSSEDMAParitySelfTest.Checked = (m_MSSLatentFaultTestConfigParameters.EDMAParityMon == '\u0001');
				m_chbMSSCSI2ParitySelfTest.Checked = (m_MSSLatentFaultTestConfigParameters.CSI2ParityMon == '\u0001');
				m_chbMSSDCCError.Checked = (m_MSSLatentFaultTestConfigParameters.DCCSelfTest == '\u0001');
				m_chbMSSPCRFaultGenerator.Checked = (m_MSSLatentFaultTestConfigParameters.PCRFaultGenTest == '\u0001');
				m_nudMSSReportingMode.Value = m_MSSLatentFaultTestConfigParameters.ReportingMode;
				m_cboMSSRFDigSysDigSysLatentFaultTestMode.SelectedIndex = (int)m_MSSLatentFaultTestConfigParameters.TestMode;
				m_chbDCCFaultInsertion.Checked = (m_MSSLatentFaultTestConfigParameters.DCCFaultInsertion == '\u0001');
				m_chbVIMRamParity.Checked = (m_MSSLatentFaultTestConfigParameters.VIMRamParity == '\u0001');
				m_chbSCIBootTimeTest.Checked = (m_MSSLatentFaultTestConfigParameters.SCI == '\u0001');
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool MSSLatentFaultMonitoringReport(uint RadarDeviceId, uint MSSLatentFaultResult, uint MSSLatentFault2Result, uint Reserved)
		{
			if (base.InvokeRequired)
			{
                base.Invoke(new delegate0107(MSSLatentFaultMonitoringReport),
                    RadarDeviceId,
                    MSSLatentFaultResult,
                    MSSLatentFault2Result,
                    Reserved
                );
			}
			else if (RadarDeviceId == 1U)
			{
				if ((MSSLatentFaultResult & 1U) == 1U)
				{
					m_lblMSSMibSPI.Text = "P";
					m_lblMSSMibSPI.ForeColor = Color.Green;
				}
				else
				{
					m_lblMSSMibSPI.Text = "F";
					m_lblMSSMibSPI.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 1 & 1U) == 1U)
				{
					m_lblDMAMon.Text = "P";
					m_lblDMAMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblDMAMon.Text = "F";
					m_lblDMAMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 3 & 1U) == 1U)
				{
					m_lblRTIMon.Text = "P";
					m_lblRTIMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblRTIMon.Text = "F";
					m_lblRTIMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 4 & 1U) == 1U)
				{
					m_lblESM.Text = "P";
					m_lblESM.ForeColor = Color.Green;
				}
				else
				{
					m_lblESM.Text = "F";
					m_lblESM.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 5 & 1U) == 1U)
				{
					m_lblEDMAMon.Text = "P";
					m_lblEDMAMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblEDMAMon.Text = "F";
					m_lblEDMAMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 6 & 1U) == 1U)
				{
					m_lblCRCMon.Text = "P";
					m_lblCRCMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblCRCMon.Text = "F";
					m_lblCRCMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 7 & 1U) == 1U)
				{
					m_lblVIMMon.Text = "P";
					m_lblVIMMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblVIMMon.Text = "F";
					m_lblVIMMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 9 & 1U) == 1U)
				{
					m_lblMaiBoxMon.Text = "P";
					m_lblMaiBoxMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblMaiBoxMon.Text = "F";
					m_lblMaiBoxMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 10 & 1U) == 1U)
				{
					m_lblLVDSPatternGenMon.Text = "P";
					m_lblLVDSPatternGenMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblLVDSPatternGenMon.Text = "F";
					m_lblLVDSPatternGenMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 11 & 1U) == 1U)
				{
					m_lblCSI2PatternGenMon.Text = "P";
					m_lblCSI2PatternGenMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblCSI2PatternGenMon.Text = "F";
					m_lblCSI2PatternGenMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 12 & 1U) == 1U)
				{
					m_lblGenNErrorMon.Text = "P";
					m_lblGenNErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblGenNErrorMon.Text = "F";
					m_lblGenNErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 13 & 1U) == 1U)
				{
					m_lblMibSPISingleBitErrorMon.Text = "P";
					m_lblMibSPISingleBitErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblMibSPISingleBitErrorMon.Text = "F";
					m_lblMibSPISingleBitErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 14 & 1U) == 1U)
				{
					m_lblMibSPIDoubleBitErrorMon.Text = "P";
					m_lblMibSPIDoubleBitErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblMibSPIDoubleBitErrorMon.Text = "F";
					m_lblMibSPIDoubleBitErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 15 & 1U) == 1U)
				{
					m_lblDMAParityMon.Text = "P";
					m_lblDMAParityMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblDMAParityMon.Text = "F";
					m_lblDMAParityMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 16 & 1U) == 1U)
				{
					m_lblTCMASingleBitErrorMon.Text = "P";
					m_lblTCMASingleBitErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblTCMASingleBitErrorMon.Text = "F";
					m_lblTCMASingleBitErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 17 & 1U) == 1U)
				{
					m_lblTCMBSingleBitErrorMon.Text = "P";
					m_lblTCMBSingleBitErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblTCMBSingleBitErrorMon.Text = "F";
					m_lblTCMBSingleBitErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 18 & 1U) == 1U)
				{
					m_lblTCMADoubleBitErrorMon.Text = "P";
					m_lblTCMADoubleBitErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblTCMADoubleBitErrorMon.Text = "F";
					m_lblTCMADoubleBitErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 19 & 1U) == 1U)
				{
					m_lblTCMBDoubleBitErrorMon.Text = "P";
					m_lblTCMBDoubleBitErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblTCMBDoubleBitErrorMon.Text = "F";
					m_lblTCMBDoubleBitErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 20 & 1U) == 1U)
				{
					m_lblTCMAParityErrorMon.Text = "P";
					m_lblTCMAParityErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblTCMAParityErrorMon.Text = "F";
					m_lblTCMAParityErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 21 & 1U) == 1U)
				{
					m_lblTCMBParityErrorMon.Text = "P";
					m_lblTCMBParityErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblTCMBParityErrorMon.Text = "F";
					m_lblTCMBParityErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 24 & 1U) == 1U)
				{
					m_lblDMAMPURegionErrorMon.Text = "P";
					m_lblDMAMPURegionErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblDMAMPURegionErrorMon.Text = "F";
					m_lblDMAMPURegionErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 25 & 1U) == 1U)
				{
					m_lblMSSMailBoxSingleBitErrorMon.Text = "P";
					m_lblMSSMailBoxSingleBitErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblMSSMailBoxSingleBitErrorMon.Text = "F";
					m_lblMSSMailBoxSingleBitErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 26 & 1U) == 1U)
				{
					m_lblMSSMailBoxDoubleBitErrorMon.Text = "P";
					m_lblMSSMailBoxDoubleBitErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblMSSMailBoxDoubleBitErrorMon.Text = "F";
					m_lblMSSMailBoxDoubleBitErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 27 & 1U) == 1U)
				{
					m_lblBSSMailBoxSingleBitErrorMon.Text = "P";
					m_lblBSSMailBoxSingleBitErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblBSSMailBoxSingleBitErrorMon.Text = "F";
					m_lblBSSMailBoxSingleBitErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 28 & 1U) == 1U)
				{
					m_lblBSSMailBoxDoubleBitErrorMon.Text = "P";
					m_lblBSSMailBoxDoubleBitErrorMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblBSSMailBoxDoubleBitErrorMon.Text = "F";
					m_lblBSSMailBoxDoubleBitErrorMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 29 & 1U) == 1U)
				{
					m_lblEDMAMPUMon.Text = "P";
					m_lblEDMAMPUMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblEDMAMPUMon.Text = "F";
					m_lblEDMAMPUMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 30 & 1U) == 1U)
				{
					m_lblEDMAParityMon.Text = "P";
					m_lblEDMAParityMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblEDMAParityMon.Text = "F";
					m_lblEDMAParityMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFaultResult >> 31 & 1U) == 1U)
				{
					m_lblCSI2ParityMon.Text = "P";
					m_lblCSI2ParityMon.ForeColor = Color.Green;
				}
				else
				{
					m_lblCSI2ParityMon.Text = "F";
					m_lblCSI2ParityMon.ForeColor = Color.Red;
				}
				if ((MSSLatentFault2Result & 1U) == 1U)
				{
					m_lblDCC.Text = "P";
					m_lblDCC.ForeColor = Color.Green;
				}
				else
				{
					m_lblDCC.Text = "F";
					m_lblDCC.ForeColor = Color.Red;
				}
				if ((MSSLatentFault2Result >> 1 & 1U) == 1U)
				{
					m_lblDCCFaultInsertion.Text = "P";
					m_lblDCCFaultInsertion.ForeColor = Color.Green;
				}
				else
				{
					m_lblDCCFaultInsertion.Text = "F";
					m_lblDCCFaultInsertion.ForeColor = Color.Red;
				}
				if ((MSSLatentFault2Result >> 2 & 1U) == 1U)
				{
					m_lblPCRFaultGen.Text = "P";
					m_lblPCRFaultGen.ForeColor = Color.Green;
				}
				else
				{
					m_lblPCRFaultGen.Text = "F";
					m_lblPCRFaultGen.ForeColor = Color.Red;
				}
				if ((MSSLatentFault2Result >> 3 & 1U) == 1U)
				{
					m_lblVIMRamParity.Text = "P";
					m_lblVIMRamParity.ForeColor = Color.Green;
				}
				else
				{
					m_lblVIMRamParity.Text = "F";
					m_lblVIMRamParity.ForeColor = Color.Red;
				}
				if ((MSSLatentFault2Result >> 4 & 1U) == 1U)
				{
					m_lblSCIBootSelfTest.Text = "P";
					m_lblSCIBootSelfTest.ForeColor = Color.Green;
				}
				else
				{
					m_lblSCIBootSelfTest.Text = "F";
					m_lblSCIBootSelfTest.ForeColor = Color.Red;
				}
			}
			else if (RadarDeviceId == 2U || RadarDeviceId != 3U)
			{
			}
			return true;
		}

		private int iSetMSSPeriodicTestMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetMSSPeriodicTestMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetMSSPeriodicTestMonConfig()
		{
			iSetMSSPeriodicTestMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetMSSPeriodicTestMonConfigAsync()
		{
			new del_v_v(iSetMSSPeriodicTestMonConfig).BeginInvoke(null, null);
		}

		private void m_btnMSSPeriodicTestConfigSet_Click(object sender, EventArgs p1)
		{
			iSetMSSPeriodicTestMonConfigAsync();
		}

		public bool UpdateMonitoringMSSPeriodicTestConfigData()
		{
			if (base.InvokeRequired)
			{
				return (bool)base.Invoke(new del_b_v(UpdateMonitoringMSSPeriodicTestConfigData));
			}
			bool result;
			try
			{
				m_MSSPeriodicTestConfigParameters.Periodicity = (uint)m_nudPeriodicity.Value;
				m_MSSPeriodicTestConfigParameters.PeriodicConfigRegReadEna =(byte) (m_chbPeriodicConfigRegisterReadEn.Checked ? 1 : 0);
				m_MSSPeriodicTestConfigParameters.ESMMonEna =(byte) (m_chbESMMonitoringSelfTest.Checked ? 1 : 0);
				m_MSSPeriodicTestConfigParameters.ReportingMode = (byte)m_nudMSSPeriodcReportingMode.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMonitoringMSSPeriodicTestConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				return (bool)base.Invoke(new del_b_v(UpdateMonitoringMSSPeriodicTestConfigDataFrmCmdSrc));
			}
			bool result;
			try
			{
				m_nudPeriodicity.Value = m_MSSPeriodicTestConfigParameters.Periodicity;
				m_chbPeriodicConfigRegisterReadEn.Checked = (m_MSSPeriodicTestConfigParameters.PeriodicConfigRegReadEna == 1);
				m_chbESMMonitoringSelfTest.Checked = (m_MSSPeriodicTestConfigParameters.ESMMonEna == 1);
				m_nudMSSPeriodcReportingMode.Value = m_MSSPeriodicTestConfigParameters.ReportingMode;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool MSSPeriodicTestMonitoringReport(uint RadarDeviceId, uint MSSPeriodicTestResult)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new del_u_u(MSSPeriodicTestMonitoringReport),
					RadarDeviceId,
					MSSPeriodicTestResult
				);
			}
			else
			{
				string empty = string.Empty;
				if (RadarDeviceId == 1U)
				{
					if ((MSSPeriodicTestResult & 1U) == 1U)
					{
						m_lblPeriodicReadBackSatReg.Text = "P";
						m_lblPeriodicReadBackSatReg.ForeColor = Color.Green;
					}
					else
					{
						m_lblPeriodicReadBackSatReg.Text = "F";
						m_lblPeriodicReadBackSatReg.ForeColor = Color.Red;
					}
					if ((MSSPeriodicTestResult >> 1 & 1U) == 1U)
					{
						m_lblESMSelfTest.Text = "P";
						m_lblESMSelfTest.ForeColor = Color.Green;
					}
					else
					{
						m_lblESMSelfTest.Text = "F";
						m_lblESMSelfTest.ForeColor = Color.Red;
					}
					// "0x" + MSSPeriodicTestResult.ToString("X");
				}
				else if (RadarDeviceId == 2U || RadarDeviceId != 3U)
				{
				}
			}
			return true;
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
            this.m_grpMSSRFDigSysLatentFaultCfg = new System.Windows.Forms.GroupBox();
            this.m_chbSCIBootTimeTest = new System.Windows.Forms.CheckBox();
            this.m_chbVIMRamParity = new System.Windows.Forms.CheckBox();
            this.m_chbDCCFaultInsertion = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_nudMSSReportingMode = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.m_chbMSSPCRFaultGenerator = new System.Windows.Forms.CheckBox();
            this.m_chbMSSDCCError = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_chbMSSCSI2ParitySelfTest = new System.Windows.Forms.CheckBox();
            this.m_chbMSSEDMAMPUsSelfTest = new System.Windows.Forms.CheckBox();
            this.m_chbBSSMailBox1BitError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSEDMAParitySelfTest = new System.Windows.Forms.CheckBox();
            this.m_chbBSSMailBox2BitError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSMailBox2BitError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSMailBox1BitError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSTCMARAMParityError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSTCMBRAM2BitError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSTCMARAM2BitError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSTCMBRAMParityError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSTCMBRAM1BitError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSDMAMPURegion = new System.Windows.Forms.CheckBox();
            this.m_chbMSSTCMARAM1BitError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSDMAParityError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSMibSPIDoubleBitError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSMibSPISingleBitError = new System.Windows.Forms.CheckBox();
            this.m_chbMSSGenerateNERROR = new System.Windows.Forms.CheckBox();
            this.m_chbMSSCIS2PatternGenMon = new System.Windows.Forms.CheckBox();
            this.m_chbMSSLVDSPatternGenMon = new System.Windows.Forms.CheckBox();
            this.m_chbMSSMailBoxMon = new System.Windows.Forms.CheckBox();
            this.m_chbMSSEDMAMon = new System.Windows.Forms.CheckBox();
            this.m_chbMSSDMAMon = new System.Windows.Forms.CheckBox();
            this.m_chbMSSMibSPIMon = new System.Windows.Forms.CheckBox();
            this.m_cboMSSRFDigSysDigSysLatentFaultTestMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnMSSRFDigitalSysLatentFaultMonConfigSet = new System.Windows.Forms.Button();
            this.m_chbMSSRTIMon = new System.Windows.Forms.CheckBox();
            this.m_chbMSSESMMon = new System.Windows.Forms.CheckBox();
            this.m_chbMSSCRCMon = new System.Windows.Forms.CheckBox();
            this.m_chbMSSVIMMon = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lblVIMRamParity = new System.Windows.Forms.Label();
            this.m_lblDCCFaultInsertion = new System.Windows.Forms.Label();
            this.m_lblSCIBootSelfTest = new System.Windows.Forms.Label();
            this.m_lblPCRFaultGen = new System.Windows.Forms.Label();
            this.m_lblDCC = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.m_lblTCMBParityErrorMon = new System.Windows.Forms.Label();
            this.m_lblCSI2ParityMon = new System.Windows.Forms.Label();
            this.m_lblEDMAParityMon = new System.Windows.Forms.Label();
            this.m_lblEDMAMPUMon = new System.Windows.Forms.Label();
            this.m_lblBSSMailBoxDoubleBitErrorMon = new System.Windows.Forms.Label();
            this.m_lblBSSMailBoxSingleBitErrorMon = new System.Windows.Forms.Label();
            this.m_lblMSSMailBoxDoubleBitErrorMon = new System.Windows.Forms.Label();
            this.m_lblMSSMailBoxSingleBitErrorMon = new System.Windows.Forms.Label();
            this.m_lblTCMBSingleBitErrorMon = new System.Windows.Forms.Label();
            this.m_lblTCMASingleBitErrorMon = new System.Windows.Forms.Label();
            this.m_lblDMAParityMon = new System.Windows.Forms.Label();
            this.m_lblMibSPIDoubleBitErrorMon = new System.Windows.Forms.Label();
            this.m_lblMibSPISingleBitErrorMon = new System.Windows.Forms.Label();
            this.m_lblGenNErrorMon = new System.Windows.Forms.Label();
            this.m_lblCSI2PatternGenMon = new System.Windows.Forms.Label();
            this.m_lblLVDSPatternGenMon = new System.Windows.Forms.Label();
            this.m_lblMaiBoxMon = new System.Windows.Forms.Label();
            this.m_lblVIMMon = new System.Windows.Forms.Label();
            this.m_lblCRCMon = new System.Windows.Forms.Label();
            this.m_lblEDMAMon = new System.Windows.Forms.Label();
            this.m_lblESM = new System.Windows.Forms.Label();
            this.m_lblRTIMon = new System.Windows.Forms.Label();
            this.m_lblDMAMon = new System.Windows.Forms.Label();
            this.m_lblMSSMibSPI = new System.Windows.Forms.Label();
            this.m_lblDMAMPURegionErrorMon = new System.Windows.Forms.Label();
            this.m_lblTCMADoubleBitErrorMon = new System.Windows.Forms.Label();
            this.m_lblTCMBDoubleBitErrorMon = new System.Windows.Forms.Label();
            this.m_lblTCMAParityErrorMon = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ww = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_btnMSSPeriodicTestConfigSet = new System.Windows.Forms.Button();
            this.m_nudMSSPeriodcReportingMode = new System.Windows.Forms.NumericUpDown();
            this.m_chbESMMonitoringSelfTest = new System.Windows.Forms.CheckBox();
            this.m_chbPeriodicConfigRegisterReadEn = new System.Windows.Forms.CheckBox();
            this.m_nudPeriodicity = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_lblESMSelfTest = new System.Windows.Forms.Label();
            this.m_lblPeriodicReadBackSatReg = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.m_grpMSSRFDigSysLatentFaultCfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMSSReportingMode)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMSSPeriodcReportingMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPeriodicity)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpMSSRFDigSysLatentFaultCfg
            // 
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbSCIBootTimeTest);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbVIMRamParity);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbDCCFaultInsertion);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.label4);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_nudMSSReportingMode);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.label3);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSPCRFaultGenerator);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSDCCError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.label1);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSCSI2ParitySelfTest);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSEDMAMPUsSelfTest);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbBSSMailBox1BitError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSEDMAParitySelfTest);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbBSSMailBox2BitError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSMailBox2BitError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSMailBox1BitError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSTCMARAMParityError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSTCMBRAM2BitError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSTCMARAM2BitError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSTCMBRAMParityError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSTCMBRAM1BitError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSDMAMPURegion);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSTCMARAM1BitError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSDMAParityError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSMibSPIDoubleBitError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSMibSPISingleBitError);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSGenerateNERROR);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSCIS2PatternGenMon);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSLVDSPatternGenMon);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSMailBoxMon);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSEDMAMon);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSDMAMon);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSMibSPIMon);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_cboMSSRFDigSysDigSysLatentFaultTestMode);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.label2);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_btnMSSRFDigitalSysLatentFaultMonConfigSet);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSRTIMon);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSESMMon);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSCRCMon);
            this.m_grpMSSRFDigSysLatentFaultCfg.Controls.Add(this.m_chbMSSVIMMon);
            this.m_grpMSSRFDigSysLatentFaultCfg.Location = new System.Drawing.Point(10, -3);
            this.m_grpMSSRFDigSysLatentFaultCfg.Name = "m_grpMSSRFDigSysLatentFaultCfg";
            this.m_grpMSSRFDigSysLatentFaultCfg.Size = new System.Drawing.Size(620, 223);
            this.m_grpMSSRFDigSysLatentFaultCfg.TabIndex = 4;
            this.m_grpMSSRFDigSysLatentFaultCfg.TabStop = false;
            this.m_grpMSSRFDigSysLatentFaultCfg.Text = "MSS Latent Fault Test Config";
            // 
            // m_chbSCIBootTimeTest
            // 
            this.m_chbSCIBootTimeTest.AutoSize = true;
            this.m_chbSCIBootTimeTest.Location = new System.Drawing.Point(71, 174);
            this.m_chbSCIBootTimeTest.Name = "m_chbSCIBootTimeTest";
            this.m_chbSCIBootTimeTest.Size = new System.Drawing.Size(43, 17);
            this.m_chbSCIBootTimeTest.TabIndex = 63;
            this.m_chbSCIBootTimeTest.Text = "SCI";
            this.m_chbSCIBootTimeTest.UseVisualStyleBackColor = true;
            // 
            // m_chbVIMRamParity
            // 
            this.m_chbVIMRamParity.AutoSize = true;
            this.m_chbVIMRamParity.Location = new System.Drawing.Point(487, 154);
            this.m_chbVIMRamParity.Name = "m_chbVIMRamParity";
            this.m_chbVIMRamParity.Size = new System.Drawing.Size(101, 17);
            this.m_chbVIMRamParity.TabIndex = 62;
            this.m_chbVIMRamParity.Text = "VIM RAM Parity";
            this.m_chbVIMRamParity.UseVisualStyleBackColor = true;
            // 
            // m_chbDCCFaultInsertion
            // 
            this.m_chbDCCFaultInsertion.AutoSize = true;
            this.m_chbDCCFaultInsertion.Location = new System.Drawing.Point(204, 154);
            this.m_chbDCCFaultInsertion.Name = "m_chbDCCFaultInsertion";
            this.m_chbDCCFaultInsertion.Size = new System.Drawing.Size(117, 17);
            this.m_chbDCCFaultInsertion.TabIndex = 61;
            this.m_chbDCCFaultInsertion.Text = "DCC Fault Insertion";
            this.m_chbDCCFaultInsertion.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Test En1";
            // 
            // m_nudMSSReportingMode
            // 
            this.m_nudMSSReportingMode.Location = new System.Drawing.Point(349, 195);
            this.m_nudMSSReportingMode.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_nudMSSReportingMode.Name = "m_nudMSSReportingMode";
            this.m_nudMSSReportingMode.Size = new System.Drawing.Size(80, 20);
            this.m_nudMSSReportingMode.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Reporting Mode";
            // 
            // m_chbMSSPCRFaultGenerator
            // 
            this.m_chbMSSPCRFaultGenerator.AutoSize = true;
            this.m_chbMSSPCRFaultGenerator.Location = new System.Drawing.Point(349, 154);
            this.m_chbMSSPCRFaultGenerator.Name = "m_chbMSSPCRFaultGenerator";
            this.m_chbMSSPCRFaultGenerator.Size = new System.Drawing.Size(97, 17);
            this.m_chbMSSPCRFaultGenerator.TabIndex = 57;
            this.m_chbMSSPCRFaultGenerator.Text = "PCR Fault Gen";
            this.m_chbMSSPCRFaultGenerator.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSDCCError
            // 
            this.m_chbMSSDCCError.AutoSize = true;
            this.m_chbMSSDCCError.Location = new System.Drawing.Point(71, 154);
            this.m_chbMSSDCCError.Name = "m_chbMSSDCCError";
            this.m_chbMSSDCCError.Size = new System.Drawing.Size(51, 17);
            this.m_chbMSSDCCError.TabIndex = 55;
            this.m_chbMSSDCCError.Text = "DCC ";
            this.m_chbMSSDCCError.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Test En2";
            // 
            // m_chbMSSCSI2ParitySelfTest
            // 
            this.m_chbMSSCSI2ParitySelfTest.AutoSize = true;
            this.m_chbMSSCSI2ParitySelfTest.Location = new System.Drawing.Point(487, 134);
            this.m_chbMSSCSI2ParitySelfTest.Name = "m_chbMSSCSI2ParitySelfTest";
            this.m_chbMSSCSI2ParitySelfTest.Size = new System.Drawing.Size(78, 17);
            this.m_chbMSSCSI2ParitySelfTest.TabIndex = 53;
            this.m_chbMSSCSI2ParitySelfTest.Text = "CSI2 Parity";
            this.m_chbMSSCSI2ParitySelfTest.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSEDMAMPUsSelfTest
            // 
            this.m_chbMSSEDMAMPUsSelfTest.AutoSize = true;
            this.m_chbMSSEDMAMPUsSelfTest.Location = new System.Drawing.Point(204, 134);
            this.m_chbMSSEDMAMPUsSelfTest.Name = "m_chbMSSEDMAMPUsSelfTest";
            this.m_chbMSSEDMAMPUsSelfTest.Size = new System.Drawing.Size(84, 17);
            this.m_chbMSSEDMAMPUsSelfTest.TabIndex = 52;
            this.m_chbMSSEDMAMPUsSelfTest.Text = "EDMA MPU";
            this.m_chbMSSEDMAMPUsSelfTest.UseVisualStyleBackColor = true;
            // 
            // m_chbBSSMailBox1BitError
            // 
            this.m_chbBSSMailBox1BitError.AutoSize = true;
            this.m_chbBSSMailBox1BitError.Location = new System.Drawing.Point(487, 114);
            this.m_chbBSSMailBox1BitError.Name = "m_chbBSSMailBox1BitError";
            this.m_chbBSSMailBox1BitError.Size = new System.Drawing.Size(130, 17);
            this.m_chbBSSMailBox1BitError.TabIndex = 51;
            this.m_chbBSSMailBox1BitError.Text = "BSS Mail Box 1 Bit Err";
            this.m_chbBSSMailBox1BitError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSEDMAParitySelfTest
            // 
            this.m_chbMSSEDMAParitySelfTest.AutoSize = true;
            this.m_chbMSSEDMAParitySelfTest.Location = new System.Drawing.Point(349, 134);
            this.m_chbMSSEDMAParitySelfTest.Name = "m_chbMSSEDMAParitySelfTest";
            this.m_chbMSSEDMAParitySelfTest.Size = new System.Drawing.Size(86, 17);
            this.m_chbMSSEDMAParitySelfTest.TabIndex = 50;
            this.m_chbMSSEDMAParitySelfTest.Text = "EDMA Parity";
            this.m_chbMSSEDMAParitySelfTest.UseVisualStyleBackColor = true;
            // 
            // m_chbBSSMailBox2BitError
            // 
            this.m_chbBSSMailBox2BitError.AutoSize = true;
            this.m_chbBSSMailBox2BitError.Location = new System.Drawing.Point(71, 134);
            this.m_chbBSSMailBox2BitError.Name = "m_chbBSSMailBox2BitError";
            this.m_chbBSSMailBox2BitError.Size = new System.Drawing.Size(130, 17);
            this.m_chbBSSMailBox2BitError.TabIndex = 49;
            this.m_chbBSSMailBox2BitError.Text = "BSS Mail Box 2 Bit Err";
            this.m_chbBSSMailBox2BitError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSMailBox2BitError
            // 
            this.m_chbMSSMailBox2BitError.AutoSize = true;
            this.m_chbMSSMailBox2BitError.Location = new System.Drawing.Point(349, 114);
            this.m_chbMSSMailBox2BitError.Name = "m_chbMSSMailBox2BitError";
            this.m_chbMSSMailBox2BitError.Size = new System.Drawing.Size(132, 17);
            this.m_chbMSSMailBox2BitError.TabIndex = 48;
            this.m_chbMSSMailBox2BitError.Text = "MSS Mail Box 2 Bit Err";
            this.m_chbMSSMailBox2BitError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSMailBox1BitError
            // 
            this.m_chbMSSMailBox1BitError.AutoSize = true;
            this.m_chbMSSMailBox1BitError.Location = new System.Drawing.Point(204, 114);
            this.m_chbMSSMailBox1BitError.Name = "m_chbMSSMailBox1BitError";
            this.m_chbMSSMailBox1BitError.Size = new System.Drawing.Size(132, 17);
            this.m_chbMSSMailBox1BitError.TabIndex = 47;
            this.m_chbMSSMailBox1BitError.Text = "MSS Mail Box 1 Bit Err";
            this.m_chbMSSMailBox1BitError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSTCMARAMParityError
            // 
            this.m_chbMSSTCMARAMParityError.AutoSize = true;
            this.m_chbMSSTCMARAMParityError.Location = new System.Drawing.Point(349, 94);
            this.m_chbMSSTCMARAMParityError.Name = "m_chbMSSTCMARAMParityError";
            this.m_chbMSSTCMARAMParityError.Size = new System.Drawing.Size(128, 17);
            this.m_chbMSSTCMARAMParityError.TabIndex = 46;
            this.m_chbMSSTCMARAMParityError.Text = "TCMA RAM Parity Err";
            this.m_chbMSSTCMARAMParityError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSTCMBRAM2BitError
            // 
            this.m_chbMSSTCMBRAM2BitError.AutoSize = true;
            this.m_chbMSSTCMBRAM2BitError.Location = new System.Drawing.Point(204, 94);
            this.m_chbMSSTCMBRAM2BitError.Name = "m_chbMSSTCMBRAM2BitError";
            this.m_chbMSSTCMBRAM2BitError.Size = new System.Drawing.Size(123, 17);
            this.m_chbMSSTCMBRAM2BitError.TabIndex = 45;
            this.m_chbMSSTCMBRAM2BitError.Text = "TCMB RAM 2 Bit Err";
            this.m_chbMSSTCMBRAM2BitError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSTCMARAM2BitError
            // 
            this.m_chbMSSTCMARAM2BitError.AutoSize = true;
            this.m_chbMSSTCMARAM2BitError.Location = new System.Drawing.Point(71, 94);
            this.m_chbMSSTCMARAM2BitError.Name = "m_chbMSSTCMARAM2BitError";
            this.m_chbMSSTCMARAM2BitError.Size = new System.Drawing.Size(123, 17);
            this.m_chbMSSTCMARAM2BitError.TabIndex = 44;
            this.m_chbMSSTCMARAM2BitError.Text = "TCMA RAM 2 Bit Err";
            this.m_chbMSSTCMARAM2BitError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSTCMBRAMParityError
            // 
            this.m_chbMSSTCMBRAMParityError.AutoSize = true;
            this.m_chbMSSTCMBRAMParityError.Location = new System.Drawing.Point(487, 94);
            this.m_chbMSSTCMBRAMParityError.Name = "m_chbMSSTCMBRAMParityError";
            this.m_chbMSSTCMBRAMParityError.Size = new System.Drawing.Size(128, 17);
            this.m_chbMSSTCMBRAMParityError.TabIndex = 43;
            this.m_chbMSSTCMBRAMParityError.Text = "TCMB RAM Parity Err";
            this.m_chbMSSTCMBRAMParityError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSTCMBRAM1BitError
            // 
            this.m_chbMSSTCMBRAM1BitError.AutoSize = true;
            this.m_chbMSSTCMBRAM1BitError.Location = new System.Drawing.Point(487, 74);
            this.m_chbMSSTCMBRAM1BitError.Name = "m_chbMSSTCMBRAM1BitError";
            this.m_chbMSSTCMBRAM1BitError.Size = new System.Drawing.Size(123, 17);
            this.m_chbMSSTCMBRAM1BitError.TabIndex = 42;
            this.m_chbMSSTCMBRAM1BitError.Text = "TCMB RAM 1 Bit Err";
            this.m_chbMSSTCMBRAM1BitError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSDMAMPURegion
            // 
            this.m_chbMSSDMAMPURegion.AutoSize = true;
            this.m_chbMSSDMAMPURegion.Location = new System.Drawing.Point(71, 114);
            this.m_chbMSSDMAMPURegion.Name = "m_chbMSSDMAMPURegion";
            this.m_chbMSSDMAMPURegion.Size = new System.Drawing.Size(114, 17);
            this.m_chbMSSDMAMPURegion.TabIndex = 41;
            this.m_chbMSSDMAMPURegion.Text = "DMA MPU Region";
            this.m_chbMSSDMAMPURegion.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSTCMARAM1BitError
            // 
            this.m_chbMSSTCMARAM1BitError.AutoSize = true;
            this.m_chbMSSTCMARAM1BitError.Location = new System.Drawing.Point(349, 74);
            this.m_chbMSSTCMARAM1BitError.Name = "m_chbMSSTCMARAM1BitError";
            this.m_chbMSSTCMARAM1BitError.Size = new System.Drawing.Size(123, 17);
            this.m_chbMSSTCMARAM1BitError.TabIndex = 40;
            this.m_chbMSSTCMARAM1BitError.Text = "TCMA RAM 1 Bit Err";
            this.m_chbMSSTCMARAM1BitError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSDMAParityError
            // 
            this.m_chbMSSDMAParityError.AutoSize = true;
            this.m_chbMSSDMAParityError.Location = new System.Drawing.Point(204, 74);
            this.m_chbMSSDMAParityError.Name = "m_chbMSSDMAParityError";
            this.m_chbMSSDMAParityError.Size = new System.Drawing.Size(95, 17);
            this.m_chbMSSDMAParityError.TabIndex = 38;
            this.m_chbMSSDMAParityError.Text = "DMA Parity Err";
            this.m_chbMSSDMAParityError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSMibSPIDoubleBitError
            // 
            this.m_chbMSSMibSPIDoubleBitError.AutoSize = true;
            this.m_chbMSSMibSPIDoubleBitError.Location = new System.Drawing.Point(71, 74);
            this.m_chbMSSMibSPIDoubleBitError.Name = "m_chbMSSMibSPIDoubleBitError";
            this.m_chbMSSMibSPIDoubleBitError.Size = new System.Drawing.Size(100, 17);
            this.m_chbMSSMibSPIDoubleBitError.TabIndex = 37;
            this.m_chbMSSMibSPIDoubleBitError.Text = "MibSPI 2 Bit Err";
            this.m_chbMSSMibSPIDoubleBitError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSMibSPISingleBitError
            // 
            this.m_chbMSSMibSPISingleBitError.AutoSize = true;
            this.m_chbMSSMibSPISingleBitError.Location = new System.Drawing.Point(487, 54);
            this.m_chbMSSMibSPISingleBitError.Name = "m_chbMSSMibSPISingleBitError";
            this.m_chbMSSMibSPISingleBitError.Size = new System.Drawing.Size(100, 17);
            this.m_chbMSSMibSPISingleBitError.TabIndex = 36;
            this.m_chbMSSMibSPISingleBitError.Text = "MibSPI 1 Bit Err";
            this.m_chbMSSMibSPISingleBitError.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSGenerateNERROR
            // 
            this.m_chbMSSGenerateNERROR.AutoSize = true;
            this.m_chbMSSGenerateNERROR.Location = new System.Drawing.Point(349, 54);
            this.m_chbMSSGenerateNERROR.Name = "m_chbMSSGenerateNERROR";
            this.m_chbMSSGenerateNERROR.Size = new System.Drawing.Size(128, 17);
            this.m_chbMSSGenerateNERROR.TabIndex = 35;
            this.m_chbMSSGenerateNERROR.Text = "NERROR Generation";
            this.m_chbMSSGenerateNERROR.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSCIS2PatternGenMon
            // 
            this.m_chbMSSCIS2PatternGenMon.AutoSize = true;
            this.m_chbMSSCIS2PatternGenMon.Location = new System.Drawing.Point(204, 54);
            this.m_chbMSSCIS2PatternGenMon.Name = "m_chbMSSCIS2PatternGenMon";
            this.m_chbMSSCIS2PatternGenMon.Size = new System.Drawing.Size(86, 17);
            this.m_chbMSSCIS2PatternGenMon.TabIndex = 34;
            this.m_chbMSSCIS2PatternGenMon.Text = "CSI2 Pattern";
            this.m_chbMSSCIS2PatternGenMon.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSLVDSPatternGenMon
            // 
            this.m_chbMSSLVDSPatternGenMon.AutoSize = true;
            this.m_chbMSSLVDSPatternGenMon.Location = new System.Drawing.Point(71, 54);
            this.m_chbMSSLVDSPatternGenMon.Name = "m_chbMSSLVDSPatternGenMon";
            this.m_chbMSSLVDSPatternGenMon.Size = new System.Drawing.Size(91, 17);
            this.m_chbMSSLVDSPatternGenMon.TabIndex = 33;
            this.m_chbMSSLVDSPatternGenMon.Text = "LVDS Pattern";
            this.m_chbMSSLVDSPatternGenMon.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSMailBoxMon
            // 
            this.m_chbMSSMailBoxMon.AutoSize = true;
            this.m_chbMSSMailBoxMon.Location = new System.Drawing.Point(487, 34);
            this.m_chbMSSMailBoxMon.Name = "m_chbMSSMailBoxMon";
            this.m_chbMSSMailBoxMon.Size = new System.Drawing.Size(63, 17);
            this.m_chbMSSMailBoxMon.TabIndex = 32;
            this.m_chbMSSMailBoxMon.Text = "MailBox";
            this.m_chbMSSMailBoxMon.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSEDMAMon
            // 
            this.m_chbMSSEDMAMon.AutoSize = true;
            this.m_chbMSSEDMAMon.Location = new System.Drawing.Point(71, 34);
            this.m_chbMSSEDMAMon.Name = "m_chbMSSEDMAMon";
            this.m_chbMSSEDMAMon.Size = new System.Drawing.Size(57, 17);
            this.m_chbMSSEDMAMon.TabIndex = 31;
            this.m_chbMSSEDMAMon.Text = "EDMA";
            this.m_chbMSSEDMAMon.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSDMAMon
            // 
            this.m_chbMSSDMAMon.AutoSize = true;
            this.m_chbMSSDMAMon.Location = new System.Drawing.Point(204, 14);
            this.m_chbMSSDMAMon.Name = "m_chbMSSDMAMon";
            this.m_chbMSSDMAMon.Size = new System.Drawing.Size(50, 17);
            this.m_chbMSSDMAMon.TabIndex = 30;
            this.m_chbMSSDMAMon.Text = "DMA";
            this.m_chbMSSDMAMon.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSMibSPIMon
            // 
            this.m_chbMSSMibSPIMon.AutoSize = true;
            this.m_chbMSSMibSPIMon.Location = new System.Drawing.Point(71, 14);
            this.m_chbMSSMibSPIMon.Name = "m_chbMSSMibSPIMon";
            this.m_chbMSSMibSPIMon.Size = new System.Drawing.Size(60, 17);
            this.m_chbMSSMibSPIMon.TabIndex = 29;
            this.m_chbMSSMibSPIMon.Text = "MibSPI";
            this.m_chbMSSMibSPIMon.UseVisualStyleBackColor = true;
            // 
            // m_cboMSSRFDigSysDigSysLatentFaultTestMode
            // 
            this.m_cboMSSRFDigSysDigSysLatentFaultTestMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMSSRFDigSysDigSysLatentFaultTestMode.FormattingEnabled = true;
            this.m_cboMSSRFDigSysDigSysLatentFaultTestMode.Items.AddRange(new object[] {
            "ProductionMode",
            "CharacterizationMode"});
            this.m_cboMSSRFDigSysDigSysLatentFaultTestMode.Location = new System.Drawing.Point(71, 196);
            this.m_cboMSSRFDigSysDigSysLatentFaultTestMode.Name = "m_cboMSSRFDigSysDigSysLatentFaultTestMode";
            this.m_cboMSSRFDigSysDigSysLatentFaultTestMode.Size = new System.Drawing.Size(131, 21);
            this.m_cboMSSRFDigSysDigSysLatentFaultTestMode.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "TestMode";
            // 
            // m_btnMSSRFDigitalSysLatentFaultMonConfigSet
            // 
            this.m_btnMSSRFDigitalSysLatentFaultMonConfigSet.Location = new System.Drawing.Point(489, 190);
            this.m_btnMSSRFDigitalSysLatentFaultMonConfigSet.Name = "m_btnMSSRFDigitalSysLatentFaultMonConfigSet";
            this.m_btnMSSRFDigitalSysLatentFaultMonConfigSet.Size = new System.Drawing.Size(75, 28);
            this.m_btnMSSRFDigitalSysLatentFaultMonConfigSet.TabIndex = 24;
            this.m_btnMSSRFDigitalSysLatentFaultMonConfigSet.Text = "Set";
            this.m_btnMSSRFDigitalSysLatentFaultMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSRTIMon
            // 
            this.m_chbMSSRTIMon.AutoSize = true;
            this.m_chbMSSRTIMon.Location = new System.Drawing.Point(349, 14);
            this.m_chbMSSRTIMon.Name = "m_chbMSSRTIMon";
            this.m_chbMSSRTIMon.Size = new System.Drawing.Size(44, 17);
            this.m_chbMSSRTIMon.TabIndex = 21;
            this.m_chbMSSRTIMon.Text = "RTI";
            this.m_chbMSSRTIMon.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSESMMon
            // 
            this.m_chbMSSESMMon.AutoSize = true;
            this.m_chbMSSESMMon.Location = new System.Drawing.Point(487, 14);
            this.m_chbMSSESMMon.Name = "m_chbMSSESMMon";
            this.m_chbMSSESMMon.Size = new System.Drawing.Size(49, 17);
            this.m_chbMSSESMMon.TabIndex = 12;
            this.m_chbMSSESMMon.Text = "ESM";
            this.m_chbMSSESMMon.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSCRCMon
            // 
            this.m_chbMSSCRCMon.AutoSize = true;
            this.m_chbMSSCRCMon.Location = new System.Drawing.Point(204, 34);
            this.m_chbMSSCRCMon.Name = "m_chbMSSCRCMon";
            this.m_chbMSSCRCMon.Size = new System.Drawing.Size(48, 17);
            this.m_chbMSSCRCMon.TabIndex = 5;
            this.m_chbMSSCRCMon.Text = "CRC";
            this.m_chbMSSCRCMon.UseVisualStyleBackColor = true;
            // 
            // m_chbMSSVIMMon
            // 
            this.m_chbMSSVIMMon.AutoSize = true;
            this.m_chbMSSVIMMon.Location = new System.Drawing.Point(349, 34);
            this.m_chbMSSVIMMon.Name = "m_chbMSSVIMMon";
            this.m_chbMSSVIMMon.Size = new System.Drawing.Size(45, 17);
            this.m_chbMSSVIMMon.TabIndex = 4;
            this.m_chbMSSVIMMon.Text = "VIM";
            this.m_chbMSSVIMMon.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_lblVIMRamParity);
            this.groupBox1.Controls.Add(this.m_lblDCCFaultInsertion);
            this.groupBox1.Controls.Add(this.m_lblSCIBootSelfTest);
            this.groupBox1.Controls.Add(this.m_lblPCRFaultGen);
            this.groupBox1.Controls.Add(this.m_lblDCC);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.m_lblTCMBParityErrorMon);
            this.groupBox1.Controls.Add(this.m_lblCSI2ParityMon);
            this.groupBox1.Controls.Add(this.m_lblEDMAParityMon);
            this.groupBox1.Controls.Add(this.m_lblEDMAMPUMon);
            this.groupBox1.Controls.Add(this.m_lblBSSMailBoxDoubleBitErrorMon);
            this.groupBox1.Controls.Add(this.m_lblBSSMailBoxSingleBitErrorMon);
            this.groupBox1.Controls.Add(this.m_lblMSSMailBoxDoubleBitErrorMon);
            this.groupBox1.Controls.Add(this.m_lblMSSMailBoxSingleBitErrorMon);
            this.groupBox1.Controls.Add(this.m_lblTCMBSingleBitErrorMon);
            this.groupBox1.Controls.Add(this.m_lblTCMASingleBitErrorMon);
            this.groupBox1.Controls.Add(this.m_lblDMAParityMon);
            this.groupBox1.Controls.Add(this.m_lblMibSPIDoubleBitErrorMon);
            this.groupBox1.Controls.Add(this.m_lblMibSPISingleBitErrorMon);
            this.groupBox1.Controls.Add(this.m_lblGenNErrorMon);
            this.groupBox1.Controls.Add(this.m_lblCSI2PatternGenMon);
            this.groupBox1.Controls.Add(this.m_lblLVDSPatternGenMon);
            this.groupBox1.Controls.Add(this.m_lblMaiBoxMon);
            this.groupBox1.Controls.Add(this.m_lblVIMMon);
            this.groupBox1.Controls.Add(this.m_lblCRCMon);
            this.groupBox1.Controls.Add(this.m_lblEDMAMon);
            this.groupBox1.Controls.Add(this.m_lblESM);
            this.groupBox1.Controls.Add(this.m_lblRTIMon);
            this.groupBox1.Controls.Add(this.m_lblDMAMon);
            this.groupBox1.Controls.Add(this.m_lblMSSMibSPI);
            this.groupBox1.Controls.Add(this.m_lblDMAMPURegionErrorMon);
            this.groupBox1.Controls.Add(this.m_lblTCMADoubleBitErrorMon);
            this.groupBox1.Controls.Add(this.m_lblTCMBDoubleBitErrorMon);
            this.groupBox1.Controls.Add(this.m_lblTCMAParityErrorMon);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.ww);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(9, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 359);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MSS Latent Fault Test Report";
            // 
            // m_lblVIMRamParity
            // 
            this.m_lblVIMRamParity.AutoSize = true;
            this.m_lblVIMRamParity.Location = new System.Drawing.Point(486, 320);
            this.m_lblVIMRamParity.Name = "m_lblVIMRamParity";
            this.m_lblVIMRamParity.Size = new System.Drawing.Size(13, 13);
            this.m_lblVIMRamParity.TabIndex = 65;
            this.m_lblVIMRamParity.Text = "F";
            // 
            // m_lblDCCFaultInsertion
            // 
            this.m_lblDCCFaultInsertion.AutoSize = true;
            this.m_lblDCCFaultInsertion.Location = new System.Drawing.Point(486, 300);
            this.m_lblDCCFaultInsertion.Name = "m_lblDCCFaultInsertion";
            this.m_lblDCCFaultInsertion.Size = new System.Drawing.Size(13, 13);
            this.m_lblDCCFaultInsertion.TabIndex = 64;
            this.m_lblDCCFaultInsertion.Text = "F";
            // 
            // m_lblSCIBootSelfTest
            // 
            this.m_lblSCIBootSelfTest.AutoSize = true;
            this.m_lblSCIBootSelfTest.Location = new System.Drawing.Point(172, 340);
            this.m_lblSCIBootSelfTest.Name = "m_lblSCIBootSelfTest";
            this.m_lblSCIBootSelfTest.Size = new System.Drawing.Size(13, 13);
            this.m_lblSCIBootSelfTest.TabIndex = 63;
            this.m_lblSCIBootSelfTest.Text = "F";
            // 
            // m_lblPCRFaultGen
            // 
            this.m_lblPCRFaultGen.AutoSize = true;
            this.m_lblPCRFaultGen.Location = new System.Drawing.Point(172, 320);
            this.m_lblPCRFaultGen.Name = "m_lblPCRFaultGen";
            this.m_lblPCRFaultGen.Size = new System.Drawing.Size(13, 13);
            this.m_lblPCRFaultGen.TabIndex = 62;
            this.m_lblPCRFaultGen.Text = "F";
            // 
            // m_lblDCC
            // 
            this.m_lblDCC.AutoSize = true;
            this.m_lblDCC.Location = new System.Drawing.Point(172, 300);
            this.m_lblDCC.Name = "m_lblDCC";
            this.m_lblDCC.Size = new System.Drawing.Size(13, 13);
            this.m_lblDCC.TabIndex = 61;
            this.m_lblDCC.Text = "F";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(3, 340);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(24, 13);
            this.label41.TabIndex = 60;
            this.label41.Text = "SCI";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(295, 320);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(82, 13);
            this.label40.TabIndex = 59;
            this.label40.Text = "VIM RAM Parity";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(3, 320);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(78, 13);
            this.label39.TabIndex = 58;
            this.label39.Text = "PCR Fault Gen";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(295, 300);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(98, 13);
            this.label38.TabIndex = 57;
            this.label38.Text = "DCC Fault Insertion";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(3, 300);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(29, 13);
            this.label37.TabIndex = 56;
            this.label37.Text = "DCC";
            // 
            // m_lblTCMBParityErrorMon
            // 
            this.m_lblTCMBParityErrorMon.AutoSize = true;
            this.m_lblTCMBParityErrorMon.Location = new System.Drawing.Point(486, 120);
            this.m_lblTCMBParityErrorMon.Name = "m_lblTCMBParityErrorMon";
            this.m_lblTCMBParityErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblTCMBParityErrorMon.TabIndex = 55;
            this.m_lblTCMBParityErrorMon.Text = "F";
            // 
            // m_lblCSI2ParityMon
            // 
            this.m_lblCSI2ParityMon.AutoSize = true;
            this.m_lblCSI2ParityMon.Location = new System.Drawing.Point(486, 280);
            this.m_lblCSI2ParityMon.Name = "m_lblCSI2ParityMon";
            this.m_lblCSI2ParityMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblCSI2ParityMon.TabIndex = 54;
            this.m_lblCSI2ParityMon.Text = "F";
            // 
            // m_lblEDMAParityMon
            // 
            this.m_lblEDMAParityMon.AutoSize = true;
            this.m_lblEDMAParityMon.Location = new System.Drawing.Point(486, 260);
            this.m_lblEDMAParityMon.Name = "m_lblEDMAParityMon";
            this.m_lblEDMAParityMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblEDMAParityMon.TabIndex = 53;
            this.m_lblEDMAParityMon.Text = "F";
            // 
            // m_lblEDMAMPUMon
            // 
            this.m_lblEDMAMPUMon.AutoSize = true;
            this.m_lblEDMAMPUMon.Location = new System.Drawing.Point(486, 240);
            this.m_lblEDMAMPUMon.Name = "m_lblEDMAMPUMon";
            this.m_lblEDMAMPUMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblEDMAMPUMon.TabIndex = 52;
            this.m_lblEDMAMPUMon.Text = "F";
            // 
            // m_lblBSSMailBoxDoubleBitErrorMon
            // 
            this.m_lblBSSMailBoxDoubleBitErrorMon.AutoSize = true;
            this.m_lblBSSMailBoxDoubleBitErrorMon.Location = new System.Drawing.Point(486, 220);
            this.m_lblBSSMailBoxDoubleBitErrorMon.Name = "m_lblBSSMailBoxDoubleBitErrorMon";
            this.m_lblBSSMailBoxDoubleBitErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblBSSMailBoxDoubleBitErrorMon.TabIndex = 51;
            this.m_lblBSSMailBoxDoubleBitErrorMon.Text = "F";
            // 
            // m_lblBSSMailBoxSingleBitErrorMon
            // 
            this.m_lblBSSMailBoxSingleBitErrorMon.AutoSize = true;
            this.m_lblBSSMailBoxSingleBitErrorMon.Location = new System.Drawing.Point(486, 200);
            this.m_lblBSSMailBoxSingleBitErrorMon.Name = "m_lblBSSMailBoxSingleBitErrorMon";
            this.m_lblBSSMailBoxSingleBitErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblBSSMailBoxSingleBitErrorMon.TabIndex = 50;
            this.m_lblBSSMailBoxSingleBitErrorMon.Text = "F";
            // 
            // m_lblMSSMailBoxDoubleBitErrorMon
            // 
            this.m_lblMSSMailBoxDoubleBitErrorMon.AutoSize = true;
            this.m_lblMSSMailBoxDoubleBitErrorMon.Location = new System.Drawing.Point(486, 180);
            this.m_lblMSSMailBoxDoubleBitErrorMon.Name = "m_lblMSSMailBoxDoubleBitErrorMon";
            this.m_lblMSSMailBoxDoubleBitErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblMSSMailBoxDoubleBitErrorMon.TabIndex = 49;
            this.m_lblMSSMailBoxDoubleBitErrorMon.Text = "F";
            // 
            // m_lblMSSMailBoxSingleBitErrorMon
            // 
            this.m_lblMSSMailBoxSingleBitErrorMon.AutoSize = true;
            this.m_lblMSSMailBoxSingleBitErrorMon.Location = new System.Drawing.Point(486, 160);
            this.m_lblMSSMailBoxSingleBitErrorMon.Name = "m_lblMSSMailBoxSingleBitErrorMon";
            this.m_lblMSSMailBoxSingleBitErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblMSSMailBoxSingleBitErrorMon.TabIndex = 48;
            this.m_lblMSSMailBoxSingleBitErrorMon.Text = "F";
            // 
            // m_lblTCMBSingleBitErrorMon
            // 
            this.m_lblTCMBSingleBitErrorMon.AutoSize = true;
            this.m_lblTCMBSingleBitErrorMon.Location = new System.Drawing.Point(486, 40);
            this.m_lblTCMBSingleBitErrorMon.Name = "m_lblTCMBSingleBitErrorMon";
            this.m_lblTCMBSingleBitErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblTCMBSingleBitErrorMon.TabIndex = 47;
            this.m_lblTCMBSingleBitErrorMon.Text = "F";
            // 
            // m_lblTCMASingleBitErrorMon
            // 
            this.m_lblTCMASingleBitErrorMon.AutoSize = true;
            this.m_lblTCMASingleBitErrorMon.Location = new System.Drawing.Point(486, 20);
            this.m_lblTCMASingleBitErrorMon.Name = "m_lblTCMASingleBitErrorMon";
            this.m_lblTCMASingleBitErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblTCMASingleBitErrorMon.TabIndex = 46;
            this.m_lblTCMASingleBitErrorMon.Text = "F";
            // 
            // m_lblDMAParityMon
            // 
            this.m_lblDMAParityMon.AutoSize = true;
            this.m_lblDMAParityMon.Location = new System.Drawing.Point(172, 280);
            this.m_lblDMAParityMon.Name = "m_lblDMAParityMon";
            this.m_lblDMAParityMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblDMAParityMon.TabIndex = 45;
            this.m_lblDMAParityMon.Text = "F";
            // 
            // m_lblMibSPIDoubleBitErrorMon
            // 
            this.m_lblMibSPIDoubleBitErrorMon.AutoSize = true;
            this.m_lblMibSPIDoubleBitErrorMon.Location = new System.Drawing.Point(172, 260);
            this.m_lblMibSPIDoubleBitErrorMon.Name = "m_lblMibSPIDoubleBitErrorMon";
            this.m_lblMibSPIDoubleBitErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblMibSPIDoubleBitErrorMon.TabIndex = 44;
            this.m_lblMibSPIDoubleBitErrorMon.Text = "F";
            // 
            // m_lblMibSPISingleBitErrorMon
            // 
            this.m_lblMibSPISingleBitErrorMon.AutoSize = true;
            this.m_lblMibSPISingleBitErrorMon.Location = new System.Drawing.Point(172, 240);
            this.m_lblMibSPISingleBitErrorMon.Name = "m_lblMibSPISingleBitErrorMon";
            this.m_lblMibSPISingleBitErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblMibSPISingleBitErrorMon.TabIndex = 43;
            this.m_lblMibSPISingleBitErrorMon.Text = "F";
            // 
            // m_lblGenNErrorMon
            // 
            this.m_lblGenNErrorMon.AutoSize = true;
            this.m_lblGenNErrorMon.Location = new System.Drawing.Point(172, 220);
            this.m_lblGenNErrorMon.Name = "m_lblGenNErrorMon";
            this.m_lblGenNErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblGenNErrorMon.TabIndex = 42;
            this.m_lblGenNErrorMon.Text = "F";
            // 
            // m_lblCSI2PatternGenMon
            // 
            this.m_lblCSI2PatternGenMon.AutoSize = true;
            this.m_lblCSI2PatternGenMon.Location = new System.Drawing.Point(172, 200);
            this.m_lblCSI2PatternGenMon.Name = "m_lblCSI2PatternGenMon";
            this.m_lblCSI2PatternGenMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblCSI2PatternGenMon.TabIndex = 41;
            this.m_lblCSI2PatternGenMon.Text = "F";
            // 
            // m_lblLVDSPatternGenMon
            // 
            this.m_lblLVDSPatternGenMon.AutoSize = true;
            this.m_lblLVDSPatternGenMon.Location = new System.Drawing.Point(172, 180);
            this.m_lblLVDSPatternGenMon.Name = "m_lblLVDSPatternGenMon";
            this.m_lblLVDSPatternGenMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblLVDSPatternGenMon.TabIndex = 40;
            this.m_lblLVDSPatternGenMon.Text = "F";
            // 
            // m_lblMaiBoxMon
            // 
            this.m_lblMaiBoxMon.AutoSize = true;
            this.m_lblMaiBoxMon.Location = new System.Drawing.Point(172, 160);
            this.m_lblMaiBoxMon.Name = "m_lblMaiBoxMon";
            this.m_lblMaiBoxMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblMaiBoxMon.TabIndex = 39;
            this.m_lblMaiBoxMon.Text = "F";
            // 
            // m_lblVIMMon
            // 
            this.m_lblVIMMon.AutoSize = true;
            this.m_lblVIMMon.Location = new System.Drawing.Point(172, 140);
            this.m_lblVIMMon.Name = "m_lblVIMMon";
            this.m_lblVIMMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblVIMMon.TabIndex = 38;
            this.m_lblVIMMon.Text = "F";
            // 
            // m_lblCRCMon
            // 
            this.m_lblCRCMon.AutoSize = true;
            this.m_lblCRCMon.Location = new System.Drawing.Point(172, 120);
            this.m_lblCRCMon.Name = "m_lblCRCMon";
            this.m_lblCRCMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblCRCMon.TabIndex = 37;
            this.m_lblCRCMon.Text = "F";
            // 
            // m_lblEDMAMon
            // 
            this.m_lblEDMAMon.AutoSize = true;
            this.m_lblEDMAMon.Location = new System.Drawing.Point(172, 100);
            this.m_lblEDMAMon.Name = "m_lblEDMAMon";
            this.m_lblEDMAMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblEDMAMon.TabIndex = 36;
            this.m_lblEDMAMon.Text = "F";
            // 
            // m_lblESM
            // 
            this.m_lblESM.AutoSize = true;
            this.m_lblESM.Location = new System.Drawing.Point(172, 80);
            this.m_lblESM.Name = "m_lblESM";
            this.m_lblESM.Size = new System.Drawing.Size(13, 13);
            this.m_lblESM.TabIndex = 35;
            this.m_lblESM.Text = "F";
            // 
            // m_lblRTIMon
            // 
            this.m_lblRTIMon.AutoSize = true;
            this.m_lblRTIMon.Location = new System.Drawing.Point(172, 60);
            this.m_lblRTIMon.Name = "m_lblRTIMon";
            this.m_lblRTIMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblRTIMon.TabIndex = 34;
            this.m_lblRTIMon.Text = "F";
            // 
            // m_lblDMAMon
            // 
            this.m_lblDMAMon.AutoSize = true;
            this.m_lblDMAMon.Location = new System.Drawing.Point(172, 40);
            this.m_lblDMAMon.Name = "m_lblDMAMon";
            this.m_lblDMAMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblDMAMon.TabIndex = 33;
            this.m_lblDMAMon.Text = "F";
            // 
            // m_lblMSSMibSPI
            // 
            this.m_lblMSSMibSPI.AutoSize = true;
            this.m_lblMSSMibSPI.Location = new System.Drawing.Point(172, 20);
            this.m_lblMSSMibSPI.Name = "m_lblMSSMibSPI";
            this.m_lblMSSMibSPI.Size = new System.Drawing.Size(13, 13);
            this.m_lblMSSMibSPI.TabIndex = 32;
            this.m_lblMSSMibSPI.Text = "F";
            // 
            // m_lblDMAMPURegionErrorMon
            // 
            this.m_lblDMAMPURegionErrorMon.AutoSize = true;
            this.m_lblDMAMPURegionErrorMon.Location = new System.Drawing.Point(486, 140);
            this.m_lblDMAMPURegionErrorMon.Name = "m_lblDMAMPURegionErrorMon";
            this.m_lblDMAMPURegionErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblDMAMPURegionErrorMon.TabIndex = 31;
            this.m_lblDMAMPURegionErrorMon.Text = "F";
            // 
            // m_lblTCMADoubleBitErrorMon
            // 
            this.m_lblTCMADoubleBitErrorMon.AutoSize = true;
            this.m_lblTCMADoubleBitErrorMon.Location = new System.Drawing.Point(486, 60);
            this.m_lblTCMADoubleBitErrorMon.Name = "m_lblTCMADoubleBitErrorMon";
            this.m_lblTCMADoubleBitErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblTCMADoubleBitErrorMon.TabIndex = 30;
            this.m_lblTCMADoubleBitErrorMon.Text = "F";
            // 
            // m_lblTCMBDoubleBitErrorMon
            // 
            this.m_lblTCMBDoubleBitErrorMon.AutoSize = true;
            this.m_lblTCMBDoubleBitErrorMon.Location = new System.Drawing.Point(486, 80);
            this.m_lblTCMBDoubleBitErrorMon.Name = "m_lblTCMBDoubleBitErrorMon";
            this.m_lblTCMBDoubleBitErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblTCMBDoubleBitErrorMon.TabIndex = 29;
            this.m_lblTCMBDoubleBitErrorMon.Text = "F";
            // 
            // m_lblTCMAParityErrorMon
            // 
            this.m_lblTCMAParityErrorMon.AutoSize = true;
            this.m_lblTCMAParityErrorMon.Location = new System.Drawing.Point(486, 100);
            this.m_lblTCMAParityErrorMon.Name = "m_lblTCMAParityErrorMon";
            this.m_lblTCMAParityErrorMon.Size = new System.Drawing.Size(13, 13);
            this.m_lblTCMAParityErrorMon.TabIndex = 28;
            this.m_lblTCMAParityErrorMon.Text = "F";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(295, 280);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(59, 13);
            this.label32.TabIndex = 27;
            this.label32.Text = "CSI2 Parity";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(295, 260);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(67, 13);
            this.label31.TabIndex = 26;
            this.label31.Text = "EDMA Parity";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(295, 240);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 13);
            this.label30.TabIndex = 25;
            this.label30.Text = "EDMA MPU";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(295, 220);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(111, 13);
            this.label29.TabIndex = 24;
            this.label29.Text = "BSS Mail Box 2 Bit Err";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(295, 120);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(109, 13);
            this.label25.TabIndex = 23;
            this.label25.Text = "TCMB RAM Parity Err";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(295, 100);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(109, 13);
            this.label26.TabIndex = 22;
            this.label26.Text = "TCMA RAM Parity Err";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(295, 80);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(104, 13);
            this.label27.TabIndex = 21;
            this.label27.Text = "TCMB RAM 2 Bit Err";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(295, 60);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 13);
            this.label28.TabIndex = 20;
            this.label28.Text = "TCMA RAM 2 Bit Err";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(295, 40);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(104, 13);
            this.label21.TabIndex = 19;
            this.label21.Text = "TCMB RAM 1 Bit Err";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(295, 20);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 13);
            this.label22.TabIndex = 18;
            this.label22.Text = "TCMA RAM 1 Bit Err";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 280);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(76, 13);
            this.label23.TabIndex = 17;
            this.label23.Text = "DMA Parity Err";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 260);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(81, 13);
            this.label24.TabIndex = 16;
            this.label24.Text = "MibSPI 2 Bit Err";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 240);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "MibSPI 1 Bit Err";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 220);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 13);
            this.label18.TabIndex = 14;
            this.label18.Text = "NError Generation";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 200);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "CSI2 Pattern";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 180);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 13);
            this.label20.TabIndex = 12;
            this.label20.Text = "LVDS Pattern";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "MailBox";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "VIM";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "CRC";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "EDMA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "ESM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "RTI";
            // 
            // ww
            // 
            this.ww.AutoSize = true;
            this.ww.Location = new System.Drawing.Point(3, 40);
            this.ww.Name = "ww";
            this.ww.Size = new System.Drawing.Size(31, 13);
            this.ww.TabIndex = 5;
            this.ww.Text = "DMA";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "MibSPI";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "DMA MPU Region";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(295, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "BSS Mail Box 1 Bit Err";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "MSS Mail Box 2 Bit Err";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "MSS Mail Box 1 Bit Err";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_btnMSSPeriodicTestConfigSet);
            this.groupBox2.Controls.Add(this.m_nudMSSPeriodcReportingMode);
            this.groupBox2.Controls.Add(this.m_chbESMMonitoringSelfTest);
            this.groupBox2.Controls.Add(this.m_chbPeriodicConfigRegisterReadEn);
            this.groupBox2.Controls.Add(this.m_nudPeriodicity);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(642, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 163);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MSS Periodic Test Config";
            // 
            // m_btnMSSPeriodicTestConfigSet
            // 
            this.m_btnMSSPeriodicTestConfigSet.Location = new System.Drawing.Point(89, 130);
            this.m_btnMSSPeriodicTestConfigSet.Name = "m_btnMSSPeriodicTestConfigSet";
            this.m_btnMSSPeriodicTestConfigSet.Size = new System.Drawing.Size(75, 28);
            this.m_btnMSSPeriodicTestConfigSet.TabIndex = 7;
            this.m_btnMSSPeriodicTestConfigSet.Text = "Set";
            this.m_btnMSSPeriodicTestConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_nudMSSPeriodcReportingMode
            // 
            this.m_nudMSSPeriodcReportingMode.Location = new System.Drawing.Point(90, 102);
            this.m_nudMSSPeriodcReportingMode.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_nudMSSPeriodcReportingMode.Name = "m_nudMSSPeriodcReportingMode";
            this.m_nudMSSPeriodcReportingMode.Size = new System.Drawing.Size(75, 20);
            this.m_nudMSSPeriodcReportingMode.TabIndex = 6;
            // 
            // m_chbESMMonitoringSelfTest
            // 
            this.m_chbESMMonitoringSelfTest.AutoSize = true;
            this.m_chbESMMonitoringSelfTest.Location = new System.Drawing.Point(90, 74);
            this.m_chbESMMonitoringSelfTest.Name = "m_chbESMMonitoringSelfTest";
            this.m_chbESMMonitoringSelfTest.Size = new System.Drawing.Size(143, 17);
            this.m_chbESMMonitoringSelfTest.TabIndex = 5;
            this.m_chbESMMonitoringSelfTest.Text = "ESM Monitoring SelfTest";
            this.m_chbESMMonitoringSelfTest.UseVisualStyleBackColor = true;
            // 
            // m_chbPeriodicConfigRegisterReadEn
            // 
            this.m_chbPeriodicConfigRegisterReadEn.AutoSize = true;
            this.m_chbPeriodicConfigRegisterReadEn.Location = new System.Drawing.Point(90, 50);
            this.m_chbPeriodicConfigRegisterReadEn.Name = "m_chbPeriodicConfigRegisterReadEn";
            this.m_chbPeriodicConfigRegisterReadEn.Size = new System.Drawing.Size(165, 17);
            this.m_chbPeriodicConfigRegisterReadEn.TabIndex = 4;
            this.m_chbPeriodicConfigRegisterReadEn.Text = "Periodic Config Reg Read En";
            this.m_chbPeriodicConfigRegisterReadEn.UseVisualStyleBackColor = true;
            // 
            // m_nudPeriodicity
            // 
            this.m_nudPeriodicity.Location = new System.Drawing.Point(89, 18);
            this.m_nudPeriodicity.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.m_nudPeriodicity.Name = "m_nudPeriodicity";
            this.m_nudPeriodicity.Size = new System.Drawing.Size(75, 20);
            this.m_nudPeriodicity.TabIndex = 3;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(5, 108);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(83, 13);
            this.label34.TabIndex = 2;
            this.label34.Text = "Reporting Mode";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(5, 51);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(64, 13);
            this.label33.TabIndex = 1;
            this.label33.Text = "Test Enable";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Periodicity (ms)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_lblESMSelfTest);
            this.groupBox3.Controls.Add(this.m_lblPeriodicReadBackSatReg);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Location = new System.Drawing.Point(642, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 83);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MSS Periodic Test Status";
            // 
            // m_lblESMSelfTest
            // 
            this.m_lblESMSelfTest.AutoSize = true;
            this.m_lblESMSelfTest.Location = new System.Drawing.Point(215, 50);
            this.m_lblESMSelfTest.Name = "m_lblESMSelfTest";
            this.m_lblESMSelfTest.Size = new System.Drawing.Size(13, 13);
            this.m_lblESMSelfTest.TabIndex = 3;
            this.m_lblESMSelfTest.Text = "F";
            // 
            // m_lblPeriodicReadBackSatReg
            // 
            this.m_lblPeriodicReadBackSatReg.AutoSize = true;
            this.m_lblPeriodicReadBackSatReg.Location = new System.Drawing.Point(215, 25);
            this.m_lblPeriodicReadBackSatReg.Name = "m_lblPeriodicReadBackSatReg";
            this.m_lblPeriodicReadBackSatReg.Size = new System.Drawing.Size(13, 13);
            this.m_lblPeriodicReadBackSatReg.TabIndex = 2;
            this.m_lblPeriodicReadBackSatReg.Text = "F";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(8, 50);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(75, 13);
            this.label36.TabIndex = 1;
            this.label36.Text = "ESM Self-Test";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(8, 25);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(191, 13);
            this.label35.TabIndex = 0;
            this.label35.Text = "Periodic Read Back of Static Registers";
            // 
            // MSSMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_grpMSSRFDigSysLatentFaultCfg);
            this.Name = "MSSMonitoring";
            this.Size = new System.Drawing.Size(910, 588);
            this.m_grpMSSRFDigSysLatentFaultCfg.ResumeLayout(false);
            this.m_grpMSSRFDigSysLatentFaultCfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMSSReportingMode)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMSSPeriodcReportingMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPeriodicity)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		private MSSLatentFaultTestConfigParameters m_MSSLatentFaultTestConfigParameters;

		private MSSPeriodicTestConfigParameters m_MSSPeriodicTestConfigParameters;

		private IContainer components;

		private GroupBox m_grpMSSRFDigSysLatentFaultCfg;

		private ComboBox m_cboMSSRFDigSysDigSysLatentFaultTestMode;

		private Label label2;

		private Button m_btnMSSRFDigitalSysLatentFaultMonConfigSet;

		private CheckBox m_chbMSSRTIMon;

		private CheckBox m_chbMSSESMMon;

		private CheckBox m_chbMSSCRCMon;

		private CheckBox m_chbMSSVIMMon;

		private CheckBox m_chbMSSMibSPIMon;

		private CheckBox m_chbMSSDMAMon;

		private CheckBox m_chbMSSEDMAMon;

		private CheckBox m_chbMSSDMAParityError;

		private CheckBox m_chbMSSMibSPIDoubleBitError;

		private CheckBox m_chbMSSMibSPISingleBitError;

		private CheckBox m_chbMSSGenerateNERROR;

		private CheckBox m_chbMSSCIS2PatternGenMon;

		private CheckBox m_chbMSSLVDSPatternGenMon;

		private CheckBox m_chbMSSMailBoxMon;

		private CheckBox m_chbMSSTCMARAM1BitError;

		private CheckBox m_chbMSSDMAMPURegion;

		private CheckBox m_chbMSSTCMARAMParityError;

		private CheckBox m_chbMSSTCMBRAM2BitError;

		private CheckBox m_chbMSSTCMARAM2BitError;

		private CheckBox m_chbMSSTCMBRAMParityError;

		private CheckBox m_chbMSSTCMBRAM1BitError;

		private CheckBox m_chbMSSMailBox1BitError;

		private CheckBox m_chbMSSCSI2ParitySelfTest;

		private CheckBox m_chbMSSEDMAMPUsSelfTest;

		private CheckBox m_chbBSSMailBox1BitError;

		private CheckBox m_chbMSSEDMAParitySelfTest;

		private CheckBox m_chbBSSMailBox2BitError;

		private CheckBox m_chbMSSMailBox2BitError;

		private Label label1;

		private Label label3;

		private CheckBox m_chbMSSPCRFaultGenerator;

		private CheckBox m_chbMSSDCCError;

		private NumericUpDown m_nudMSSReportingMode;

		private Label label4;

		private GroupBox groupBox1;

		private Label label9;

		private Label label10;

		private Label ww;

		private Label label12;

		private Label label8;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label13;

		private Label label14;

		private Label label15;

		private Label label16;

		private Label label17;

		private Label label18;

		private Label label19;

		private Label label20;

		private Label label25;

		private Label label26;

		private Label label27;

		private Label label28;

		private Label label21;

		private Label label22;

		private Label label23;

		private Label label24;

		private Label label32;

		private Label label31;

		private Label label30;

		private Label label29;

		private Label m_lblMaiBoxMon;

		private Label m_lblVIMMon;

		private Label m_lblCRCMon;

		private Label m_lblEDMAMon;

		private Label m_lblESM;

		private Label m_lblRTIMon;

		private Label m_lblDMAMon;

		private Label m_lblMSSMibSPI;

		private Label m_lblDMAMPURegionErrorMon;

		private Label m_lblTCMADoubleBitErrorMon;

		private Label m_lblTCMBDoubleBitErrorMon;

		private Label m_lblTCMAParityErrorMon;

		private Label m_lblTCMBParityErrorMon;

		private Label m_lblCSI2ParityMon;

		private Label m_lblEDMAParityMon;

		private Label m_lblEDMAMPUMon;

		private Label m_lblBSSMailBoxDoubleBitErrorMon;

		private Label m_lblBSSMailBoxSingleBitErrorMon;

		private Label m_lblMSSMailBoxDoubleBitErrorMon;

		private Label m_lblMSSMailBoxSingleBitErrorMon;

		private Label m_lblTCMBSingleBitErrorMon;

		private Label m_lblTCMASingleBitErrorMon;

		private Label m_lblDMAParityMon;

		private Label m_lblMibSPIDoubleBitErrorMon;

		private Label m_lblMibSPISingleBitErrorMon;

		private Label m_lblGenNErrorMon;

		private Label m_lblCSI2PatternGenMon;

		private Label m_lblLVDSPatternGenMon;

		private GroupBox groupBox2;

		private Button m_btnMSSPeriodicTestConfigSet;

		private NumericUpDown m_nudMSSPeriodcReportingMode;

		private CheckBox m_chbESMMonitoringSelfTest;

		private CheckBox m_chbPeriodicConfigRegisterReadEn;

		private NumericUpDown m_nudPeriodicity;

		private Label label34;

		private Label label33;

		private Label label11;

		private GroupBox groupBox3;

		private Label m_lblESMSelfTest;

		private Label m_lblPeriodicReadBackSatReg;

		private Label label36;

		private Label label35;

		private CheckBox m_chbSCIBootTimeTest;

		private CheckBox m_chbVIMRamParity;

		private CheckBox m_chbDCCFaultInsertion;

		private Label m_lblVIMRamParity;

		private Label m_lblDCCFaultInsertion;

		private Label m_lblSCIBootSelfTest;

		private Label m_lblPCRFaultGen;

		private Label m_lblDCC;

		private Label label41;

		private Label label40;

		private Label label39;

		private Label label38;

		private Label label37;
	}
}
