using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class c0000b1 : UserControl
	{
		public c0000b1()
		{
			InitializeComponent();
			m_MainForm = m_GuiManager.MainTsForm;
			m_MonExternalAnalogSignalConfigParameters = m_GuiManager.TsParams.MonExternalAnalogSignalConfigParameters;
			m_MonInternalTx1AnalogSignalConfigParameters = m_GuiManager.TsParams.MonInternalTx1AnalogSignalConfigParameters;
			m_MonInternalTx2AnalogSignalConfigParameters = m_GuiManager.TsParams.MonInternalTx2AnalogSignalConfigParameters;
			m_MonInternalTx3AnalogSignalConfigParameters = m_GuiManager.TsParams.MonInternalTx3AnalogSignalConfigParameters;
			m_MonInternalRxAnalogSignalConfigParameters = m_GuiManager.TsParams.MonInternalRxAnalogSignalConfigParameters;
			m_MonInternalPMCLKLOAnalogSignalConfigParameters = m_GuiManager.TsParams.MonInternalPMCLKLOAnalogSignalConfigParameters;
			m_MonInternalGPADCAnalogSignalConfigParameters = m_GuiManager.TsParams.MonInternalGPADCAnalogSignalConfigParameters;
			m_MonPLLControlVoltageConfigParameters = m_GuiManager.TsParams.MonPLLControlVoltageConfigParameters;
			m_MonDualClockCompConfigParameters = m_GuiManager.TsParams.MonDualClockCompConfigParameters;
			m_cboPMCLKSync20GSigSelect.SelectedIndex = 0;
		}

		private int iSetExternalAnalogSignalsMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetExternalAnalogSignalsMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetExternalAnalogSignalsMonConfig()
		{
			iSetExternalAnalogSignalsMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetExternalAnalogSignalsMonConfigAsync()
		{
			new del_v_v(iSetExternalAnalogSignalsMonConfig).BeginInvoke(null, null);
		}

		private void m_btnExternalAnalogSignalsMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetExternalAnalogSignalsMonConfigAsync();
		}

		public bool UpdateExternalAnalogSignalsMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateExternalAnalogSignalsMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonExternalAnalogSignalConfigParameters.ReportingMode = (char)m_nudExtAnalogSigMonReportingMode.Value;
				m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogTest1 = (m_chbExtAnalogSigMonSigIPEnaAnaTest1.Checked ? '\u0001' : '\0');
				m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogTest2 = (m_chbExtAnalogSigMonSigIPEnaAnaTest2.Checked ? '\u0001' : '\0');
				m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogTest3 = (m_chbExtAnalogSigMonSigIPEnaAnaTest3.Checked ? '\u0001' : '\0');
				m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogTest4 = (m_chbExtAnalogSigMonSigIPEnaAnaTest4.Checked ? '\u0001' : '\0');
				m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogMux = (m_chbExtAnalogSigMonSigIPEnaAnaMux.Checked ? '\u0001' : '\0');
				m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogVSense = (m_chbExtAnalogSigMonSigIPEnaVSense.Checked ? '\u0001' : '\0');
				m_MonExternalAnalogSignalConfigParameters.SigBufEnaAnalogTest1 = (m_chbExtAnalogSigMonSigBufEnaAnaTest1.Checked ? '\u0001' : '\0');
				m_MonExternalAnalogSignalConfigParameters.SigBufEnaAnalogTest2 = (m_chbExtAnalogSigMonSigBufEnaAnaTest2.Checked ? '\u0001' : '\0');
				m_MonExternalAnalogSignalConfigParameters.SigBufEnaAnalogTest3 = (m_chbExtAnalogSigMonSigBufEnaAnaTest3.Checked ? '\u0001' : '\0');
				m_MonExternalAnalogSignalConfigParameters.SigBufEnaAnalogTest4 = (m_chbExtAnalogSigMonSigBufEnaAnaTest4.Checked ? '\u0001' : '\0');
				m_MonExternalAnalogSignalConfigParameters.SigBufEnaAnalogMux = (m_chbExtAnalogSigMonSigBufEnaAnaMux.Checked ? '\u0001' : '\0');
				m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogTest1 = (double)m_nudExtAnalogSigMonSigSettlingTimeAnaTest1.Value;
				m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogTest2 = (double)m_nudExtAnalogSigMonSigSettlingTimeAnaTest2.Value;
				m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogTest3 = (double)m_nudExtAnalogSigMonSigSettlingTimeAnaTest3.Value;
				m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogTest4 = (double)m_nudExtAnalogSigMonSigSettlingTimeAnaTest4.Value;
				m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogMux = (double)m_nudExtAnalogSigMonSigSettlingTimeAnaMux.Value;
				m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogVSense = (double)m_nudExtAnalogSigMonSigSettlingTimeAnaVSense.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogTest1 = (double)m_nudExtAnalogSigMonSigThresholdMinAnaTest1.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogTest2 = (double)m_nudExtAnalogSigMonSigThresholdMinAnaTest2.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogTest3 = (double)m_nudExtAnalogSigMonSigThresholdMinAnaTest3.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogTest4 = (double)m_nudExtAnalogSigMonSigThresholdMinAnaTest4.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogMux = (double)m_nudExtAnalogSigMonSigThresholdMinAnaMux.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogVSense = (double)m_nudExtAnalogSigMonSigThresholdMinAnaVSense.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogTest1 = (double)m_nudExtAnalogSigMonSigThresholdMaxAnaTest1.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogTest2 = (double)m_nudExtAnalogSigMonSigThresholdMaxAnaTest2.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogTest3 = (double)m_nudExtAnalogSigMonSigThresholdMaxAnaTest3.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogTest4 = (double)m_nudExtAnalogSigMonSigThresholdMaxAnaTest4.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogMux = (double)m_nudExtAnalogSigMonSigThresholdMaxAnaMux.Value;
				m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogVSense = (double)m_nudExtAnalogSigMonSigThresholdMaxAnaVSense.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateExtAnaMonConfigData(RootObject jobject, int p1)
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
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.isConfigured == 0)
					{
						string msg2 = string.Format("Missing External Analog Signals Monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg2);
					}
					else
					{
						m_nudExtAnalogSigMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.reportMode;
						m_chbExtAnalogSigMonSigIPEnaAnaTest1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalInpEnables, 16) & 1) == 1);
						m_chbExtAnalogSigMonSigIPEnaAnaTest2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalInpEnables, 16) & 2) >> 1 == 1);
						m_chbExtAnalogSigMonSigIPEnaAnaTest3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalInpEnables, 16) & 4) >> 2 == 1);
						m_chbExtAnalogSigMonSigIPEnaAnaTest4.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalInpEnables, 16) & 8) >> 3 == 1);
						m_chbExtAnalogSigMonSigIPEnaAnaMux.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalInpEnables, 16) & 16) >> 4 == 1);
						m_chbExtAnalogSigMonSigIPEnaVSense.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalInpEnables, 16) & 32) >> 5 == 1);
						m_chbExtAnalogSigMonSigBufEnaAnaTest1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalBuffEnables, 16) & 1) == 1);
						m_chbExtAnalogSigMonSigBufEnaAnaTest2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalBuffEnables, 16) & 2) >> 1 == 1);
						m_chbExtAnalogSigMonSigBufEnaAnaTest3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalBuffEnables, 16) & 4) >> 2 == 1);
						m_chbExtAnalogSigMonSigBufEnaAnaTest4.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalBuffEnables, 16) & 8) >> 3 == 1);
						m_chbExtAnalogSigMonSigBufEnaAnaMux.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalBuffEnables, 16) & 16) >> 4 == 1);
						m_nudExtAnalogSigMonSigSettlingTimeAnaTest1.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalSettlingTime[0];
						m_nudExtAnalogSigMonSigSettlingTimeAnaTest2.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalSettlingTime[1];
						m_nudExtAnalogSigMonSigSettlingTimeAnaTest3.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalSettlingTime[2];
						m_nudExtAnalogSigMonSigSettlingTimeAnaTest4.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalSettlingTime[3];
						m_nudExtAnalogSigMonSigSettlingTimeAnaMux.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalSettlingTime[4];
						m_nudExtAnalogSigMonSigSettlingTimeAnaVSense.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalSettlingTime[5];
						m_nudExtAnalogSigMonSigThresholdMinAnaTest1.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[0];
						m_nudExtAnalogSigMonSigThresholdMinAnaTest2.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[1];
						m_nudExtAnalogSigMonSigThresholdMinAnaTest3.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[2];
						m_nudExtAnalogSigMonSigThresholdMinAnaTest4.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[3];
						m_nudExtAnalogSigMonSigThresholdMinAnaMux.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[4];
						m_nudExtAnalogSigMonSigThresholdMinAnaVSense.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[5];
						m_nudExtAnalogSigMonSigThresholdMaxAnaTest1.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[6];
						m_nudExtAnalogSigMonSigThresholdMaxAnaTest2.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[7];
						m_nudExtAnalogSigMonSigThresholdMaxAnaTest3.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[8];
						m_nudExtAnalogSigMonSigThresholdMaxAnaTest4.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[9];
						m_nudExtAnalogSigMonSigThresholdMaxAnaMux.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[10];
						m_nudExtAnalogSigMonSigThresholdMaxAnaVSense.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlExtAnaSignalsMonConf_t.signalThresh[11];
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.isConfigured == 0)
					{
						string msg3 = string.Format("Missing Tx Internal Analog Signals Monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg3);
					}
					else
					{
						m_nudTX1IntAnalogSigMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx0IntAnaSgnlMonCfg.profileIndx;
						m_nudTX1IntAnalogSigMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx0IntAnaSgnlMonCfg.reportMode;
						m_nudTX2IntAnalogSigMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx1IntAnaSgnlMonCfg.profileIndx;
						m_nudTX2IntAnalogSigMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx1IntAnaSgnlMonCfg.reportMode;
						m_nudTX3IntAnalogSigMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx2IntAnaSgnlMonCfg.profileIndx;
						m_nudTX3IntAnalogSigMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxIntAnaSignalsMonConf_t.tx2IntAnaSgnlMonCfg.reportMode;
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlRxIntAnaSignalsMonConf_t.isConfigured == 0)
					{
						string msg4 = string.Format("Missing Rx Internal Analog Signals Monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg4);
					}
					else
					{
						m_nudRXIntAnalogSigMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxIntAnaSignalsMonConf_t.profileIndx;
						m_nudRXIntAnalogSigMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxIntAnaSignalsMonConf_t.reportMode;
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlPmClkLoIntAnaSignalsMonConf_t.isConfigured == 0)
					{
						string msg5 = string.Format("Missing Internal signals for PM, CLK and LO monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg5);
					}
					else
					{
						m_nudPMCLKLOIntAnalogSigMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlPmClkLoIntAnaSignalsMonConf_t.profileIndx;
						m_nudPMCLKLOIntAnalogSigMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlPmClkLoIntAnaSignalsMonConf_t.reportMode;
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlGpadcIntAnaSignalsMonConf_t.isConfigured == 0)
					{
						string msg6 = string.Format("Missing Internal signals for GPADC monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg6);
					}
					else
					{
						m_nudGPADCIntAnalogSigMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlGpadcIntAnaSignalsMonConf_t.reportMode;
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlPllContrVoltMonConf_t.isConfigured == 0)
					{
						string msg7 = string.Format("Missing Internal signals for PLL control voltage monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg7);
					}
					else
					{
						m_nudPLLCtlVolMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlPllContrVoltMonConf_t.reportMode;
						m_chbPLLCtlVolMonAPLLVctl.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlPllContrVoltMonConf_t.signalEnables, 16) & 1) == 1);
						m_chbPLLCtlVolMonSynthVCO1VolControl.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlPllContrVoltMonConf_t.signalEnables, 16) & 2) >> 1 == 1);
						m_chbPLLCtlVolMonSynthVCO2VolControl.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlPllContrVoltMonConf_t.signalEnables, 16) & 4) >> 2 == 1);
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlDualClkCompMonConf_t.isConfigured == 0)
					{
						string msg8 = string.Format("Missing Internal signals for DCC based clock monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg8);
					}
					else
					{
						m_nudDCCMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlDualClkCompMonConf_t.reportMode;
						m_chbDCCMonClockPair0.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlDualClkCompMonConf_t.dccPairEnables, 16) & 1) == 1);
						m_chbDCCMonClockPair1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlDualClkCompMonConf_t.dccPairEnables, 16) & 2) >> 1 == 1);
						m_chbDCCMonClockPair2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlDualClkCompMonConf_t.dccPairEnables, 16) & 4) >> 2 == 1);
						m_chbDCCMonClockPair3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlDualClkCompMonConf_t.dccPairEnables, 16) & 8) >> 3 == 1);
						m_chbDCCMonClockPair4.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlDualClkCompMonConf_t.dccPairEnables, 16) & 16) >> 4 == 1);
						m_chbDCCMonClockPair5.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlDualClkCompMonConf_t.dccPairEnables, 16) & 32) >> 5 == 1);
					}
				}
				result = true;
			}
			catch
			{
				string msg9 = string.Format("DC BIST Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg9);
				result = false;
			}
			return result;
		}

		public bool UpdateExternalAnalogSignalsMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateExternalAnalogSignalsMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudExtAnalogSigMonReportingMode.Value = m_MonExternalAnalogSignalConfigParameters.ReportingMode;
				m_chbExtAnalogSigMonSigIPEnaAnaTest1.Checked = (m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogTest1 == '\u0001');
				m_chbExtAnalogSigMonSigIPEnaAnaTest2.Checked = (m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogTest2 == '\u0001');
				m_chbExtAnalogSigMonSigIPEnaAnaTest3.Checked = (m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogTest3 == '\u0001');
				m_chbExtAnalogSigMonSigIPEnaAnaTest4.Checked = (m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogTest4 == '\u0001');
				m_chbExtAnalogSigMonSigIPEnaAnaMux.Checked = (m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogMux == '\u0001');
				m_chbExtAnalogSigMonSigIPEnaVSense.Checked = (m_MonExternalAnalogSignalConfigParameters.SigIpEnaAnalogVSense == '\u0001');
				m_chbExtAnalogSigMonSigBufEnaAnaTest1.Checked = (m_MonExternalAnalogSignalConfigParameters.SigBufEnaAnalogTest1 == '\u0001');
				m_chbExtAnalogSigMonSigBufEnaAnaTest2.Checked = (m_MonExternalAnalogSignalConfigParameters.SigBufEnaAnalogTest2 == '\u0001');
				m_chbExtAnalogSigMonSigBufEnaAnaTest3.Checked = (m_MonExternalAnalogSignalConfigParameters.SigBufEnaAnalogTest3 == '\u0001');
				m_chbExtAnalogSigMonSigBufEnaAnaTest4.Checked = (m_MonExternalAnalogSignalConfigParameters.SigBufEnaAnalogTest4 == '\u0001');
				m_chbExtAnalogSigMonSigBufEnaAnaMux.Checked = (m_MonExternalAnalogSignalConfigParameters.SigBufEnaAnalogMux == '\u0001');
				m_nudExtAnalogSigMonSigSettlingTimeAnaTest1.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogTest1;
				m_nudExtAnalogSigMonSigSettlingTimeAnaTest2.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogTest2;
				m_nudExtAnalogSigMonSigSettlingTimeAnaTest3.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogTest3;
				m_nudExtAnalogSigMonSigSettlingTimeAnaTest4.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogTest4;
				m_nudExtAnalogSigMonSigSettlingTimeAnaMux.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogMux;
				m_nudExtAnalogSigMonSigSettlingTimeAnaVSense.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigSettlingTimeAnalogVSense;
				m_nudExtAnalogSigMonSigThresholdMinAnaTest1.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogTest1;
				m_nudExtAnalogSigMonSigThresholdMinAnaTest2.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogTest2;
				m_nudExtAnalogSigMonSigThresholdMinAnaTest3.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogTest3;
				m_nudExtAnalogSigMonSigThresholdMinAnaTest4.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogTest4;
				m_nudExtAnalogSigMonSigThresholdMinAnaMux.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogMux;
				m_nudExtAnalogSigMonSigThresholdMinAnaVSense.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMinThresholdAnalogVSense;
				m_nudExtAnalogSigMonSigThresholdMaxAnaTest1.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogTest1;
				m_nudExtAnalogSigMonSigThresholdMaxAnaTest2.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogTest2;
				m_nudExtAnalogSigMonSigThresholdMaxAnaTest3.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogTest3;
				m_nudExtAnalogSigMonSigThresholdMaxAnaTest4.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogTest4;
				m_nudExtAnalogSigMonSigThresholdMaxAnaMux.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogMux;
				m_nudExtAnalogSigMonSigThresholdMaxAnaVSense.Value = (decimal)m_MonExternalAnalogSignalConfigParameters.SigMaxThresholdAnalogVSense;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeExternalAnalogSignalMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, ushort ExtAnalogSigTest1Val, ushort ExtAnalogSigTest2Val, ushort ExtAnalogSigTest3Val, ushort ExtAnalogSigTest4Val, ushort ExtAnalogSigMuxVal, ushort ExtAnalogSigVSenseVal, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_us_us_us_us_us_us_us_us_u method = new del_u_us_us_us_us_us_us_us_us_u(CascadeExternalAnalogSignalMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					ExtAnalogSigTest1Val,
					ExtAnalogSigTest2Val,
					ExtAnalogSigTest3Val,
					ExtAnalogSigTest4Val,
					ExtAnalogSigMuxVal,
					ExtAnalogSigVSenseVal,
					TimeStamp
				});
			}
			else
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
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(Math.Round((double)ExtAnalogSigTest1Val / 1024.0 * 1800.0, 2));
						Convert.ToString(Math.Round((double)ExtAnalogSigTest2Val / 1024.0 * 1800.0, 2));
						Convert.ToString(Math.Round((double)ExtAnalogSigTest3Val / 1024.0 * 1800.0, 2));
						Convert.ToString(Math.Round((double)ExtAnalogSigTest4Val / 1024.0 * 1800.0, 2));
						Convert.ToString(Math.Round((double)ExtAnalogSigMuxVal / 1024.0 * 1800.0, 2));
						Convert.ToString(Math.Round((double)ExtAnalogSigVSenseVal / 1024.0 * 1800.0, 2));
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(Math.Round((double)ExtAnalogSigTest1Val / 1024.0 * 1800.0, 2));
					Convert.ToString(Math.Round((double)ExtAnalogSigTest2Val / 1024.0 * 1800.0, 2));
					Convert.ToString(Math.Round((double)ExtAnalogSigTest3Val / 1024.0 * 1800.0, 2));
					Convert.ToString(Math.Round((double)ExtAnalogSigTest4Val / 1024.0 * 1800.0, 2));
					Convert.ToString(Math.Round((double)ExtAnalogSigMuxVal / 1024.0 * 1800.0, 2));
					Convert.ToString(Math.Round((double)ExtAnalogSigVSenseVal / 1024.0 * 1800.0, 2));
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetTX1IntAnalogSigMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetTX1IntAnalogSigMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetTX1IntAnalogSigMonConfig()
		{
			iSetTX1IntAnalogSigMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetTX1IntAnalogSigMonConfigAsync()
		{
			new del_v_v(iSetTX1IntAnalogSigMonConfig).BeginInvoke(null, null);
		}

		private void m_btnTX1IntAnalogSigMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetTX1IntAnalogSigMonConfigAsync();
		}

		public bool UpdateTX1IntAnalogSigMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTX1IntAnalogSigMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonInternalTx1AnalogSignalConfigParameters.ProfileIndex = (char)m_nudTX1IntAnalogSigMonProfileIndex.Value;
				m_MonInternalTx1AnalogSignalConfigParameters.ReportingMode = (char)m_nudTX1IntAnalogSigMonReportingMode.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateTX1IntAnalogSigMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTX1IntAnalogSigMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudTX1IntAnalogSigMonProfileIndex.Value = m_MonInternalTx1AnalogSignalConfigParameters.ProfileIndex;
				m_nudTX1IntAnalogSigMonReportingMode.Value = m_MonInternalTx1AnalogSignalConfigParameters.ReportingMode;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeInternalTX1AnalogSigMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_u_c_u method = new del_u_u_c_u(CascadeInternalTX1AnalogSigMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					ProfileIndex,
					TimeStamp
				});
			}
			else
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				string empty4 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(ProfileIndex);
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(ProfileIndex);
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetTX2IntAnalogSigMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetTX2IntAnalogSigMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetTX2IntAnalogSigMonConfig()
		{
			iSetTX2IntAnalogSigMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetTX2IntAnalogSigMonConfigAsync()
		{
			new del_v_v(iSetTX2IntAnalogSigMonConfig).BeginInvoke(null, null);
		}

		private void m_btnTX2IntAnalogSigMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetTX2IntAnalogSigMonConfigAsync();
		}

		public bool UpdateTX2IntAnalogSigMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTX2IntAnalogSigMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonInternalTx2AnalogSignalConfigParameters.ProfileIndex = (char)m_nudTX2IntAnalogSigMonProfileIndex.Value;
				m_MonInternalTx2AnalogSignalConfigParameters.ReportingMode = (char)m_nudTX2IntAnalogSigMonReportingMode.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateTX2IntAnalogSigMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTX2IntAnalogSigMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudTX2IntAnalogSigMonProfileIndex.Value = m_MonInternalTx2AnalogSignalConfigParameters.ProfileIndex;
				m_nudTX2IntAnalogSigMonReportingMode.Value = m_MonInternalTx2AnalogSignalConfigParameters.ReportingMode;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeInternalTX2AnalogSigMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_u_c_u method = new del_u_u_c_u(CascadeInternalTX2AnalogSigMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					ProfileIndex,
					TimeStamp
				});
			}
			else
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				string empty4 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(ProfileIndex);
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(ProfileIndex);
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetTX3IntAnalogSigMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetTX3IntAnalogSigMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetTX3IntAnalogSigMonConfig()
		{
			iSetTX3IntAnalogSigMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetTX3IntAnalogSigMonConfigAsync()
		{
			new del_v_v(iSetTX3IntAnalogSigMonConfig).BeginInvoke(null, null);
		}

		private void m_btnTX3IntAnalogSigMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetTX3IntAnalogSigMonConfigAsync();
		}

		public bool UpdateTX3IntAnalogSigMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTX3IntAnalogSigMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonInternalTx3AnalogSignalConfigParameters.ProfileIndex = (char)m_nudTX3IntAnalogSigMonProfileIndex.Value;
				m_MonInternalTx3AnalogSignalConfigParameters.ReportingMode = (char)m_nudTX3IntAnalogSigMonReportingMode.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateTX3IntAnalogSigMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTX3IntAnalogSigMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudTX3IntAnalogSigMonProfileIndex.Value = m_MonInternalTx3AnalogSignalConfigParameters.ProfileIndex;
				m_nudTX3IntAnalogSigMonReportingMode.Value = m_MonInternalTx3AnalogSignalConfigParameters.ReportingMode;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeInternalTX3AnalogSigMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_u_c_u method = new del_u_u_c_u(CascadeInternalTX3AnalogSigMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					ProfileIndex,
					TimeStamp
				});
			}
			else
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				string empty4 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(ProfileIndex);
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(ProfileIndex);
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetRXIntAnalogSigMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetRXIntAnalogSigMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRXIntAnalogSigMonConfig()
		{
			iSetRXIntAnalogSigMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetRXIntAnalogSigMonConfigAsync()
		{
			new del_v_v(iSetRXIntAnalogSigMonConfig).BeginInvoke(null, null);
		}

		private void m_btnRXIntAnalogSigMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetRXIntAnalogSigMonConfigAsync();
		}

		public bool UpdateRXIntAnalogSigMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRXIntAnalogSigMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonInternalRxAnalogSignalConfigParameters.ProfileIndex = (char)m_nudRXIntAnalogSigMonProfileIndex.Value;
				m_MonInternalRxAnalogSignalConfigParameters.ReportingMode = (char)m_nudRXIntAnalogSigMonReportingMode.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRXIntAnalogSigMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRXIntAnalogSigMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudRXIntAnalogSigMonProfileIndex.Value = m_MonInternalRxAnalogSignalConfigParameters.ProfileIndex;
				m_nudRXIntAnalogSigMonReportingMode.Value = m_MonInternalRxAnalogSignalConfigParameters.ReportingMode;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeInternalRxAnalogSigMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_u_c_u method = new del_u_u_c_u(CascadeInternalRxAnalogSigMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					ProfileIndex,
					TimeStamp
				});
			}
			else
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				string empty4 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(ProfileIndex);
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(ProfileIndex);
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetPMCLKLOIntAnalogSigMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetPMCLKLOIntAnalogSigMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetPMCLKLOIntAnalogSigMonConfig()
		{
			iSetPMCLKLOIntAnalogSigMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetPMCLKLOIntAnalogSigMonConfigAsync()
		{
			new del_v_v(iSetPMCLKLOIntAnalogSigMonConfig).BeginInvoke(null, null);
		}

		private void m_btnPMCLKLOIntAnalogSigMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetPMCLKLOIntAnalogSigMonConfigAsync();
		}

		public bool UpdatePMCLKLOIntAnalogSigMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdatePMCLKLOIntAnalogSigMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonInternalPMCLKLOAnalogSignalConfigParameters.ProfileIndex = (byte)m_nudPMCLKLOIntAnalogSigMonProfileIndex.Value;
				m_MonInternalPMCLKLOAnalogSignalConfigParameters.ReportingMode = (byte)m_nudPMCLKLOIntAnalogSigMonReportingMode.Value;
				m_MonInternalPMCLKLOAnalogSignalConfigParameters.Sync20GSigSelect = (byte)m_cboPMCLKSync20GSigSelect.SelectedIndex;
				m_MonInternalPMCLKLOAnalogSignalConfigParameters.Sync20GMinThreshold = (sbyte)m_nudPMCLKSync20GMinThreshold.Value;
				m_MonInternalPMCLKLOAnalogSignalConfigParameters.Sync20GMaxThreshold = (sbyte)m_nudPMCLKSync20GMaxThreshold.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdatePMCLKLOIntAnalogSigMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdatePMCLKLOIntAnalogSigMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudPMCLKLOIntAnalogSigMonProfileIndex.Value = m_MonInternalPMCLKLOAnalogSignalConfigParameters.ProfileIndex;
				m_nudPMCLKLOIntAnalogSigMonReportingMode.Value = m_MonInternalPMCLKLOAnalogSignalConfigParameters.ReportingMode;
				m_cboPMCLKSync20GSigSelect.SelectedIndex = (int)m_MonInternalPMCLKLOAnalogSignalConfigParameters.Sync20GSigSelect;
				m_nudPMCLKSync20GMinThreshold.Value = m_MonInternalPMCLKLOAnalogSignalConfigParameters.Sync20GMinThreshold;
				m_nudPMCLKSync20GMaxThreshold.Value = m_MonInternalPMCLKLOAnalogSignalConfigParameters.Sync20GMaxThreshold;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeInternalPMCLKLOAnalogSigMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, sbyte Sync_20G_Power, ushort Reserved, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_u_c_sc_us_u method = new del_u_u_c_sc_us_u(CascadeInternalPMCLKLOAnalogSigMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					ProfileIndex,
					Sync_20G_Power,
					Reserved,
					TimeStamp
				});
			}
			else
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				string empty4 = string.Empty;
				string empty5 = string.Empty;
				string empty6 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(ProfileIndex);
						Convert.ToString(Math.Round((double)Sync_20G_Power / 2.0, 1));
						Convert.ToString(Reserved);
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(ProfileIndex);
					Convert.ToString(Math.Round((double)Sync_20G_Power / 2.0, 1));
					Convert.ToString(Reserved);
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetGPADCIntAnalogSigMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetGPADCIntAnalogSigMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetGPADCIntAnalogSigMonConfig()
		{
			iSetGPADCIntAnalogSigMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetGPADCIntAnalogSigMonConfigAsync()
		{
			new del_v_v(iSetGPADCIntAnalogSigMonConfig).BeginInvoke(null, null);
		}

		private void m_btnGPADCIntAnalogSigMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetGPADCIntAnalogSigMonConfigAsync();
		}

		public bool UpdateGPADCIntAnalogSigMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateGPADCIntAnalogSigMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonInternalGPADCAnalogSignalConfigParameters.ReportingMode = (char)m_nudGPADCIntAnalogSigMonReportingMode.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateGPADCIntAnalogSigMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateGPADCIntAnalogSigMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudGPADCIntAnalogSigMonReportingMode.Value = m_MonInternalGPADCAnalogSignalConfigParameters.ReportingMode;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeInternalGPADCAnalogSigMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, ushort p3, ushort p4, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_us_us_us_u method = new del_u_us_us_us_u(CascadeInternalGPADCAnalogSigMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					p3,
					p4,
					TimeStamp
				});
			}
			else
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				string empty4 = string.Empty;
				string empty5 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString((int)(p3 * 1800 / 1024));
						Convert.ToString((int)(p4 * 1800 / 1024));
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString((int)(p3 * 1800 / 1024));
					Convert.ToString((int)(p4 * 1800 / 1024));
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetPLLControlVolMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetPLLControlVolMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetPLLControlVolMonConfig()
		{
			iSetPLLControlVolMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetPLLControlVolMonConfigAsync()
		{
			new del_v_v(iSetPLLControlVolMonConfig).BeginInvoke(null, null);
		}

		private void m_btnPLLControlVolMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetPLLControlVolMonConfigAsync();
		}

		public bool UpdatePLLControlVolMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdatePLLControlVolMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonPLLControlVoltageConfigParameters.ReportingMode = (char)m_nudPLLCtlVolMonReportingMode.Value;
				m_MonPLLControlVoltageConfigParameters.APLLVctl = (m_chbPLLCtlVolMonAPLLVctl.Checked ? '\u0001' : '\0');
				m_MonPLLControlVoltageConfigParameters.SynthVCO1VoltageControl = (m_chbPLLCtlVolMonSynthVCO1VolControl.Checked ? '\u0001' : '\0');
				m_MonPLLControlVoltageConfigParameters.SynthVCO2VoltageControl = (m_chbPLLCtlVolMonSynthVCO2VolControl.Checked ? '\u0001' : '\0');
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdatePLLControlVolMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdatePLLControlVolMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudPLLCtlVolMonReportingMode.Value = m_MonPLLControlVoltageConfigParameters.ReportingMode;
				m_chbPLLCtlVolMonAPLLVctl.Checked = (m_MonPLLControlVoltageConfigParameters.APLLVctl == '\u0001');
				m_chbPLLCtlVolMonSynthVCO1VolControl.Checked = (m_MonPLLControlVoltageConfigParameters.SynthVCO1VoltageControl == '\u0001');
				m_chbPLLCtlVolMonSynthVCO2VolControl.Checked = (m_MonPLLControlVoltageConfigParameters.SynthVCO2VoltageControl == '\u0001');
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadePLLControlVoltageMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, ushort p3, ushort SynthVCO1VctlMaxFreq, ushort SynthVCO1VctlMinFreq, ushort SynthVCO1Slope, ushort SynthVCO2VctlMaxFreq, ushort SynthVCO2VctlMinFreq, ushort SynthVCO2Slope, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_u_u_us_us_us_us_us_us_us_u method = new del_u_u_u_us_us_us_us_us_us_us_u(CascadePLLControlVoltageMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					p3,
					SynthVCO1VctlMaxFreq,
					SynthVCO1VctlMinFreq,
					SynthVCO1Slope,
					SynthVCO2VctlMaxFreq,
					SynthVCO2VctlMinFreq,
					SynthVCO2Slope,
					TimeStamp
				});
			}
			else
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
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(p3);
						Convert.ToString(SynthVCO1VctlMaxFreq);
						Convert.ToString(SynthVCO1VctlMinFreq);
						Convert.ToString(SynthVCO1Slope);
						Convert.ToString(SynthVCO2VctlMaxFreq);
						Convert.ToString(SynthVCO2VctlMinFreq);
						Convert.ToString(SynthVCO2Slope);
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(p3);
					Convert.ToString(SynthVCO1VctlMaxFreq);
					Convert.ToString(SynthVCO1VctlMinFreq);
					Convert.ToString(SynthVCO1Slope);
					Convert.ToString(SynthVCO2VctlMaxFreq);
					Convert.ToString(SynthVCO2VctlMinFreq);
					Convert.ToString(SynthVCO2Slope);
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetDCCMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetDCCMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetDCCMonConfig()
		{
			iSetDCCMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetDCCMonConfigAsync()
		{
			new del_v_v(iSetDCCMonConfig).BeginInvoke(null, null);
		}

		private void m_btnDCCMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetDCCMonConfigAsync();
		}

		public bool UpdateDCCMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateDCCMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonDualClockCompConfigParameters.ReportingMode = (char)m_nudDCCMonReportingMode.Value;
				m_MonDualClockCompConfigParameters.ClockPair0 = (m_chbDCCMonClockPair0.Checked ? '\u0001' : '\0');
				m_MonDualClockCompConfigParameters.ClockPair1 = (m_chbDCCMonClockPair1.Checked ? '\u0001' : '\0');
				m_MonDualClockCompConfigParameters.ClockPair2 = (m_chbDCCMonClockPair2.Checked ? '\u0001' : '\0');
				m_MonDualClockCompConfigParameters.ClockPair3 = (m_chbDCCMonClockPair3.Checked ? '\u0001' : '\0');
				m_MonDualClockCompConfigParameters.ClockPair4 = (m_chbDCCMonClockPair4.Checked ? '\u0001' : '\0');
				m_MonDualClockCompConfigParameters.ClockPair5 = (m_chbDCCMonClockPair5.Checked ? '\u0001' : '\0');
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateDCCMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateDCCMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudDCCMonReportingMode.Value = m_MonDualClockCompConfigParameters.ReportingMode;
				m_chbDCCMonClockPair0.Checked = (m_MonDualClockCompConfigParameters.ClockPair0 == '\u0001');
				m_chbDCCMonClockPair1.Checked = (m_MonDualClockCompConfigParameters.ClockPair1 == '\u0001');
				m_chbDCCMonClockPair2.Checked = (m_MonDualClockCompConfigParameters.ClockPair2 == '\u0001');
				m_chbDCCMonClockPair3.Checked = (m_MonDualClockCompConfigParameters.ClockPair3 == '\u0001');
				m_chbDCCMonClockPair4.Checked = (m_MonDualClockCompConfigParameters.ClockPair4 == '\u0001');
				m_chbDCCMonClockPair5.Checked = (m_MonDualClockCompConfigParameters.ClockPair5 == '\u0001');
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeDualClockComparatorMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, ushort FreqMeasClock0, ushort FreqMeasClock1, ushort FreqMeasClock2, ushort FreqMeasClock3, ushort FreqMeasClock4, ushort FreqMeasClock5, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_u_u_us_us_us_us_us_us_u method = new del_u_u_u_us_us_us_us_us_us_u(CascadeDualClockComparatorMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					FreqMeasClock0,
					FreqMeasClock1,
					FreqMeasClock2,
					FreqMeasClock3,
					FreqMeasClock4,
					FreqMeasClock5,
					TimeStamp
				});
			}
			else
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
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(FreqMeasClock0);
						Convert.ToString(FreqMeasClock1);
						Convert.ToString(FreqMeasClock2);
						Convert.ToString(FreqMeasClock3);
						Convert.ToString(FreqMeasClock4);
						Convert.ToString(FreqMeasClock5);
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(FreqMeasClock0);
					Convert.ToString(FreqMeasClock1);
					Convert.ToString(FreqMeasClock2);
					Convert.ToString(FreqMeasClock3);
					Convert.ToString(FreqMeasClock4);
					Convert.ToString(FreqMeasClock5);
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		public bool SaveRxExternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveRxExternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonReportingMode", m_nudExtAnalogSigMonReportingMode.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaAnaTest1", (m_chbExtAnalogSigMonSigIPEnaAnaTest1.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaAnaTest2", (m_chbExtAnalogSigMonSigIPEnaAnaTest2.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaAnaTest3", (m_chbExtAnalogSigMonSigIPEnaAnaTest3.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaAnaTest4", (m_chbExtAnalogSigMonSigIPEnaAnaTest4.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaAnaMux", (m_chbExtAnalogSigMonSigIPEnaAnaMux.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaVSense", (m_chbExtAnalogSigMonSigIPEnaVSense.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigBufEnaAnaTest1", (m_chbExtAnalogSigMonSigBufEnaAnaTest1.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigBufEnaAnaTest2", (m_chbExtAnalogSigMonSigBufEnaAnaTest2.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigBufEnaAnaTest3", (m_chbExtAnalogSigMonSigBufEnaAnaTest3.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigBufEnaAnaTest4", (m_chbExtAnalogSigMonSigBufEnaAnaTest4.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigBufEnaAnaMux", (m_chbExtAnalogSigMonSigBufEnaAnaMux.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaTest1", m_nudExtAnalogSigMonSigSettlingTimeAnaTest1.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaTest2", m_nudExtAnalogSigMonSigSettlingTimeAnaTest2.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaTest3", m_nudExtAnalogSigMonSigSettlingTimeAnaTest3.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaTest4", m_nudExtAnalogSigMonSigSettlingTimeAnaTest4.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaMux", m_nudExtAnalogSigMonSigSettlingTimeAnaMux.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaVSense", m_nudExtAnalogSigMonSigSettlingTimeAnaVSense.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaTest1", m_nudExtAnalogSigMonSigThresholdMinAnaTest1.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaTest2", m_nudExtAnalogSigMonSigThresholdMinAnaTest2.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaTest3", m_nudExtAnalogSigMonSigThresholdMinAnaTest3.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaTest4", m_nudExtAnalogSigMonSigThresholdMinAnaTest4.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaMux", m_nudExtAnalogSigMonSigThresholdMinAnaMux.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaVSense", m_nudExtAnalogSigMonSigThresholdMinAnaVSense.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaTest1", m_nudExtAnalogSigMonSigThresholdMaxAnaTest1.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaTest2", m_nudExtAnalogSigMonSigThresholdMaxAnaTest2.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaTest3", m_nudExtAnalogSigMonSigThresholdMaxAnaTest3.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaTest4", m_nudExtAnalogSigMonSigThresholdMaxAnaTest4.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaMux", m_nudExtAnalogSigMonSigThresholdMaxAnaMux.Value.ToString());
				ConfigurationManager.SetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaVSense", m_nudExtAnalogSigMonSigThresholdMaxAnaVSense.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadRxExternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadRxExternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte extAnalogSigMonReportingMode = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonReportingMode"));
				byte extAnalogSigMonSigIPEnaAnaTest = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaAnaTest1"));
				byte extAnalogSigMonSigIPEnaAnaTest2 = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaAnaTest2"));
				byte extAnalogSigMonSigIPEnaAnaTest3 = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaAnaTest3"));
				byte extAnalogSigMonSigIPEnaAnaTest4 = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaAnaTest4"));
				byte extAnalogSigMonSigIPEnaAnaMux = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaAnaMux"));
				byte extAnalogSigMonSigIPEnaVSense = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigIPEnaVSense"));
				byte extAnalogSigMonSigBufEnaAnaTest = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigBufEnaAnaTest1"));
				byte extAnalogSigMonSigBufEnaAnaTest2 = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigBufEnaAnaTest1"));
				byte extAnalogSigMonSigBufEnaAnaTest3 = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigBufEnaAnaTest1"));
				byte extAnalogSigMonSigBufEnaAnaTest4 = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigBufEnaAnaTest1"));
				byte extAnalogSigMonSigBufEnaAnaMux = Convert.ToByte(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigBufEnaAnaMux"));
				double extAnalogSigMonSigSettlingTimeAnaTest = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaTest1"));
				double extAnalogSigMonSigSettlingTimeAnaTest2 = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaTest2"));
				double extAnalogSigMonSigSettlingTimeAnaTest3 = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaTest3"));
				double extAnalogSigMonSigSettlingTimeAnaTest4 = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaTest4"));
				double extAnalogSigMonSigSettlingTimeAnaMux = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaMux"));
				double extAnalogSigMonSigSettlingTimeAnaVSense = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigSettlingTimeAnaVSense"));
				double extAnalogSigMonSigThresholdMinAnaTest = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaTest1"));
				double extAnalogSigMonSigThresholdMinAnaTest2 = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaTest1"));
				double extAnalogSigMonSigThresholdMinAnaTest3 = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaTest1"));
				double extAnalogSigMonSigThresholdMinAnaTest4 = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaTest1"));
				double extAnalogSigMonSigThresholdMinAnaMux = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaMux"));
				double extAnalogSigMonSigThresholdMinAnaVSense = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMinAnaVSense"));
				double extAnalogSigMonSigThresholdMaxAnaTest = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaTest1"));
				double extAnalogSigMonSigThresholdMaxAnaTest2 = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaTest1"));
				double extAnalogSigMonSigThresholdMaxAnaTest3 = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaTest1"));
				double extAnalogSigMonSigThresholdMaxAnaTest4 = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaTest1"));
				double extAnalogSigMonSigThresholdMaxAnaMux = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaMux"));
				double extAnalogSigMonSigThresholdMaxAnaVSense = (double)Convert.ToSingle(ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal("extAnalogSigMonSigThresholdMaxAnaVSense"));
				m_GuiManager.ScriptOps.UpdateNRxExternalAnalogSignalMonConfigData(extAnalogSigMonReportingMode, extAnalogSigMonSigIPEnaAnaTest, extAnalogSigMonSigIPEnaAnaTest2, extAnalogSigMonSigIPEnaAnaTest3, extAnalogSigMonSigIPEnaAnaTest4, extAnalogSigMonSigIPEnaAnaMux, extAnalogSigMonSigIPEnaVSense, extAnalogSigMonSigBufEnaAnaTest, extAnalogSigMonSigBufEnaAnaTest2, extAnalogSigMonSigBufEnaAnaTest3, extAnalogSigMonSigBufEnaAnaTest4, extAnalogSigMonSigBufEnaAnaMux, extAnalogSigMonSigSettlingTimeAnaTest, extAnalogSigMonSigSettlingTimeAnaTest2, extAnalogSigMonSigSettlingTimeAnaTest3, extAnalogSigMonSigSettlingTimeAnaTest4, extAnalogSigMonSigSettlingTimeAnaMux, extAnalogSigMonSigSettlingTimeAnaVSense, extAnalogSigMonSigThresholdMinAnaTest, extAnalogSigMonSigThresholdMinAnaTest2, extAnalogSigMonSigThresholdMinAnaTest3, extAnalogSigMonSigThresholdMinAnaTest4, extAnalogSigMonSigThresholdMinAnaMux, extAnalogSigMonSigThresholdMinAnaVSense, extAnalogSigMonSigThresholdMaxAnaTest, extAnalogSigMonSigThresholdMaxAnaTest2, extAnalogSigMonSigThresholdMaxAnaTest3, extAnalogSigMonSigThresholdMaxAnaTest4, extAnalogSigMonSigThresholdMaxAnaMux, extAnalogSigMonSigThresholdMaxAnaVSense);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveTx0InternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveTx0InternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetTx0IntAnalogSigMonConfigKeyVal("tx0IntAnalogSigMonProfileIndex", m_nudTX1IntAnalogSigMonProfileIndex.Value.ToString());
				ConfigurationManager.SetTx0IntAnalogSigMonConfigKeyVal("tx0IntAnalogSigMonReportingMode", m_nudTX1IntAnalogSigMonReportingMode.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadTx0InternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadTx0InternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte txIntAnalogSigMonProfileIndex = Convert.ToByte(ConfigurationManager.GetTx0IntAnalogSigMonConfigKeyVal("tx0IntAnalogSigMonProfileIndex"));
				byte txIntAnalogSigMonReportingMode = Convert.ToByte(ConfigurationManager.GetTx0IntAnalogSigMonConfigKeyVal("tx0IntAnalogSigMonReportingMode"));
				m_GuiManager.ScriptOps.UpdateNTx0InternalAnalogSignalMonConfigData(txIntAnalogSigMonProfileIndex, txIntAnalogSigMonReportingMode);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveTx1InternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveTx1InternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetTx1IntAnalogSigMonConfigKeyVal("tx1IntAnalogSigMonProfileIndex", m_nudTX2IntAnalogSigMonProfileIndex.Value.ToString());
				ConfigurationManager.SetTx1IntAnalogSigMonConfigKeyVal("tx1IntAnalogSigMonReportingMode", m_nudTX2IntAnalogSigMonReportingMode.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadTx1InternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadTx1InternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte txIntAnalogSigMonProfileIndex = Convert.ToByte(ConfigurationManager.GetTx1IntAnalogSigMonConfigKeyVal("tx1IntAnalogSigMonProfileIndex"));
				byte txIntAnalogSigMonReportingMode = Convert.ToByte(ConfigurationManager.GetTx1IntAnalogSigMonConfigKeyVal("tx1IntAnalogSigMonReportingMode"));
				m_GuiManager.ScriptOps.UpdateNTx1InternalAnalogSignalMonConfigData(txIntAnalogSigMonProfileIndex, txIntAnalogSigMonReportingMode);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveTx2InternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveTx2InternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetTx2IntAnalogSigMonConfigKeyVal("tx2IntAnalogSigMonProfileIndex", m_nudTX3IntAnalogSigMonProfileIndex.Value.ToString());
				ConfigurationManager.SetTx2IntAnalogSigMonConfigKeyVal("tx2IntAnalogSigMonReportingMode", m_nudTX3IntAnalogSigMonReportingMode.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadTx2InternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadTx2InternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte txIntAnalogSigMonProfileIndex = Convert.ToByte(ConfigurationManager.GetTx2IntAnalogSigMonConfigKeyVal("tx2IntAnalogSigMonProfileIndex"));
				byte txIntAnalogSigMonReportingMode = Convert.ToByte(ConfigurationManager.GetTx2IntAnalogSigMonConfigKeyVal("tx2IntAnalogSigMonReportingMode"));
				m_GuiManager.ScriptOps.UpdateNTx2InternalAnalogSignalMonConfigData(txIntAnalogSigMonProfileIndex, txIntAnalogSigMonReportingMode);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveRxInternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveRxInternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetRxIntAnalogSigMonConfigKeyVal("rxIntAnalogSigMonProfileIndex", m_nudRXIntAnalogSigMonProfileIndex.Value.ToString());
				ConfigurationManager.SetRxIntAnalogSigMonConfigKeyVal("rxIntAnalogSigMonReportingMode", m_nudRXIntAnalogSigMonReportingMode.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadRxInternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadRxInternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte rxIntAnalogSigMonProfileIndex = Convert.ToByte(ConfigurationManager.GetRxIntAnalogSigMonConfigKeyVal("rxIntAnalogSigMonProfileIndex"));
				byte rxIntAnalogSigMonReportingMode = Convert.ToByte(ConfigurationManager.GetRxIntAnalogSigMonConfigKeyVal("rxIntAnalogSigMonReportingMode"));
				m_GuiManager.ScriptOps.UpdateNRxInternalAnalogSignalMonConfigData(rxIntAnalogSigMonProfileIndex, rxIntAnalogSigMonReportingMode);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SavePMCLKLOInternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SavePMCLKLOInternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetPMCLKLOIntAnalogSigMonConfigKeyVal("pmCLKLOIntAnalogSigMonProfileIndex", m_nudPMCLKLOIntAnalogSigMonProfileIndex.Value.ToString());
				ConfigurationManager.SetPMCLKLOIntAnalogSigMonConfigKeyVal("pmCLKLOIntAnalogSigMonReportingMode", m_nudPMCLKLOIntAnalogSigMonReportingMode.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadPMCLKLOInternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadPMCLKLOInternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte pmCLKLOIntAnalogSigMonProfileIndex = Convert.ToByte(ConfigurationManager.GetPMCLKLOIntAnalogSigMonConfigKeyVal("pmCLKLOIntAnalogSigMonProfileIndex"));
				byte pmCLKLOIntAnalogSigMonReportingMode = Convert.ToByte(ConfigurationManager.GetPMCLKLOIntAnalogSigMonConfigKeyVal("pmCLKLOIntAnalogSigMonReportingMode"));
				m_GuiManager.ScriptOps.UpdateNPMCLKLOInternalAnalogSignalMonConfigData(pmCLKLOIntAnalogSigMonProfileIndex, pmCLKLOIntAnalogSigMonReportingMode);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveGPADCInternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveGPADCInternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetGPADCIntAnalogSigMonConfigKeyVal("gpadcIntAnalogSigMonReportingMode", m_nudGPADCIntAnalogSigMonReportingMode.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadGPADCInternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadGPADCInternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte gpadcIntAnalogSigMonReportingMode = Convert.ToByte(ConfigurationManager.GetGPADCIntAnalogSigMonConfigKeyVal("gpadcIntAnalogSigMonReportingMode"));
				m_GuiManager.ScriptOps.UpdateNGPADCInternalAnalogSignalMonConfigData(gpadcIntAnalogSigMonReportingMode);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SavePLLControlVoltageInternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SavePLLControlVoltageInternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetPLLControlVoltageMonConfigKeyVal("pllCtlVolMonReportingMode", m_nudPLLCtlVolMonReportingMode.Value.ToString());
				ConfigurationManager.SetPLLControlVoltageMonConfigKeyVal("pllCtlVolMonAPLLVctl", (m_chbPLLCtlVolMonAPLLVctl.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetPLLControlVoltageMonConfigKeyVal("pllCtlVolMonSynthVCO1VolControl", (m_chbPLLCtlVolMonSynthVCO1VolControl.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetPLLControlVoltageMonConfigKeyVal("pllCtlVolMonSynthVCO2VolControl", (m_chbPLLCtlVolMonSynthVCO2VolControl.Checked ? 1 : 0).ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadPLLControlVoltageInternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadPLLControlVoltageInternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte pllCtlVolMonReportingMode = Convert.ToByte(ConfigurationManager.GetPLLControlVoltageMonConfigKeyVal("pllCtlVolMonReportingMode"));
				byte pllCtlVolMonAPLLVctl = Convert.ToByte(ConfigurationManager.GetPLLControlVoltageMonConfigKeyVal("pllCtlVolMonAPLLVctl"));
				byte pllCtlVolMonSynthVCO1VolControl = Convert.ToByte(ConfigurationManager.GetPLLControlVoltageMonConfigKeyVal("pllCtlVolMonSynthVCO1VolControl"));
				byte pllCtlVolMonSynthVCO2VolControl = Convert.ToByte(ConfigurationManager.GetPLLControlVoltageMonConfigKeyVal("pllCtlVolMonSynthVCO2VolControl"));
				m_GuiManager.ScriptOps.UpdateNPLLVoltageControlInternalAnalogSignalMonConfigData(pllCtlVolMonReportingMode, pllCtlVolMonAPLLVctl, pllCtlVolMonSynthVCO1VolControl, pllCtlVolMonSynthVCO2VolControl);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveDCCInternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveDCCInternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetDCCMonConfigKeyVal("dccMonReportingMode", m_nudDCCMonReportingMode.Value.ToString());
				ConfigurationManager.SetDCCMonConfigKeyVal("dccMonClockPair0", (m_chbDCCMonClockPair0.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetDCCMonConfigKeyVal("dccMonClockPair1", (m_chbDCCMonClockPair1.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetDCCMonConfigKeyVal("dccMonClockPair2", (m_chbDCCMonClockPair2.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetDCCMonConfigKeyVal("dccMonClockPair3", (m_chbDCCMonClockPair3.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetDCCMonConfigKeyVal("dccMonClockPair4", (m_chbDCCMonClockPair4.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetDCCMonConfigKeyVal("dccMonClockPair5", (m_chbDCCMonClockPair5.Checked ? 1 : 0).ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadDCCInternalAnalogSignalMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadDCCInternalAnalogSignalMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte dccMonReportingMode = Convert.ToByte(ConfigurationManager.GetDCCMonConfigKeyVal("dccMonReportingMode"));
				byte dccMonClockPair = Convert.ToByte(ConfigurationManager.GetDCCMonConfigKeyVal("dccMonClockPair0"));
				byte dccMonClockPair2 = Convert.ToByte(ConfigurationManager.GetDCCMonConfigKeyVal("dccMonClockPair1"));
				byte dccMonClockPair3 = Convert.ToByte(ConfigurationManager.GetDCCMonConfigKeyVal("dccMonClockPair2"));
				byte dccMonClockPair4 = Convert.ToByte(ConfigurationManager.GetDCCMonConfigKeyVal("dccMonClockPair3"));
				byte dccMonClockPair5 = Convert.ToByte(ConfigurationManager.GetDCCMonConfigKeyVal("dccMonClockPair4"));
				byte dccMonClockPair6 = Convert.ToByte(ConfigurationManager.GetDCCMonConfigKeyVal("dccMonClockPair5"));
				m_GuiManager.ScriptOps.UpdateNDCCInternalAnalogSignalMonConfigData(dccMonReportingMode, dccMonClockPair, dccMonClockPair2, dccMonClockPair3, dccMonClockPair4, dccMonClockPair5, dccMonClockPair6);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private void label4_Click(object sender, EventArgs p1)
		{
		}

		private void groupBox4_Enter(object sender, EventArgs p1)
		{
		}

		private void m000013(object sender, EventArgs p1)
		{
		}

		private void m_nudPMCLKSync20GMinThreshold_ValueChanged(object sender, EventArgs p1)
		{
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_btnExternalAnalogSignalsMonConfigSet = new System.Windows.Forms.Button();
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaMux = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest4 = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest3 = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaVSense = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigThresholdMinAnaMux = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest4 = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest3 = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigThresholdMinAnaVSense = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaMux = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest4 = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest3 = new System.Windows.Forms.NumericUpDown();
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest2 = new System.Windows.Forms.NumericUpDown();
            this.m_chbExtAnalogSigMonSigBufEnaAnaMux = new System.Windows.Forms.CheckBox();
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaVSense = new System.Windows.Forms.NumericUpDown();
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest3 = new System.Windows.Forms.CheckBox();
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest4 = new System.Windows.Forms.CheckBox();
            this.m_chbExtAnalogSigMonSigIPEnaVSense = new System.Windows.Forms.CheckBox();
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest2 = new System.Windows.Forms.CheckBox();
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest1 = new System.Windows.Forms.CheckBox();
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest4 = new System.Windows.Forms.CheckBox();
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest2 = new System.Windows.Forms.CheckBox();
            this.m_chbExtAnalogSigMonSigIPEnaAnaMux = new System.Windows.Forms.CheckBox();
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest3 = new System.Windows.Forms.CheckBox();
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest1 = new System.Windows.Forms.CheckBox();
            this.m_nudExtAnalogSigMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_nudTX2IntAnalogSigMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.m_nudTX3IntAnalogSigMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.m_nudTX1IntAnalogSigMonProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.m_nudTX1IntAnalogSigMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.m_nudTX3IntAnalogSigMonProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.m_nudTX2IntAnalogSigMonProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.m_btnTX2IntAnalogSigMonConfigSet = new System.Windows.Forms.Button();
            this.m_btnTX1IntAnalogSigMonConfigSet = new System.Windows.Forms.Button();
            this.m_btnTX3IntAnalogSigMonConfigSet = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_btnRXIntAnalogSigMonConfigSet = new System.Windows.Forms.Button();
            this.m_nudRXIntAnalogSigMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.m_nudRXIntAnalogSigMonProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_nudPMCLKSync20GMaxThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_nudPMCLKSync20GMinThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_cboPMCLKSync20GSigSelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnPMCLKLOIntAnalogSigMonConfigSet = new System.Windows.Forms.Button();
            this.m_nudPMCLKLOIntAnalogSigMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.m_nudPMCLKLOIntAnalogSigMonProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_btnGPADCIntAnalogSigMonConfigSet = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.m_nudGPADCIntAnalogSigMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.m_btnPLLControlVolMonConfigSet = new System.Windows.Forms.Button();
            this.m_chbPLLCtlVolMonAPLLVctl = new System.Windows.Forms.CheckBox();
            this.m_chbPLLCtlVolMonSynthVCO1VolControl = new System.Windows.Forms.CheckBox();
            this.m_chbPLLCtlVolMonSynthVCO2VolControl = new System.Windows.Forms.CheckBox();
            this.m_nudPLLCtlVolMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.m_btnDCCMonConfigSet = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.m_chbDCCMonClockPair2 = new System.Windows.Forms.CheckBox();
            this.m_chbDCCMonClockPair5 = new System.Windows.Forms.CheckBox();
            this.m_chbDCCMonClockPair1 = new System.Windows.Forms.CheckBox();
            this.m_chbDCCMonClockPair4 = new System.Windows.Forms.CheckBox();
            this.m_chbDCCMonClockPair3 = new System.Windows.Forms.CheckBox();
            this.m_chbDCCMonClockPair0 = new System.Windows.Forms.CheckBox();
            this.m_nudDCCMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaMux)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaVSense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaMux)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaVSense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaMux)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaVSense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonReportingMode)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX2IntAnalogSigMonReportingMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX3IntAnalogSigMonReportingMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX1IntAnalogSigMonProfileIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX1IntAnalogSigMonReportingMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX3IntAnalogSigMonProfileIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX2IntAnalogSigMonProfileIndex)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXIntAnalogSigMonReportingMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXIntAnalogSigMonProfileIndex)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPMCLKSync20GMaxThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPMCLKSync20GMinThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPMCLKLOIntAnalogSigMonReportingMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPMCLKLOIntAnalogSigMonProfileIndex)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGPADCIntAnalogSigMonReportingMode)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPLLCtlVolMonReportingMode)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDCCMonReportingMode)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_btnExternalAnalogSignalsMonConfigSet);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMaxAnaMux);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest1);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest4);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest3);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest2);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMaxAnaVSense);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMinAnaMux);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest1);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest4);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest3);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest2);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigThresholdMinAnaVSense);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigSettlingTimeAnaMux);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest1);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest4);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest3);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest2);
            this.groupBox1.Controls.Add(this.m_chbExtAnalogSigMonSigBufEnaAnaMux);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonSigSettlingTimeAnaVSense);
            this.groupBox1.Controls.Add(this.m_chbExtAnalogSigMonSigBufEnaAnaTest3);
            this.groupBox1.Controls.Add(this.m_chbExtAnalogSigMonSigBufEnaAnaTest4);
            this.groupBox1.Controls.Add(this.m_chbExtAnalogSigMonSigIPEnaVSense);
            this.groupBox1.Controls.Add(this.m_chbExtAnalogSigMonSigBufEnaAnaTest2);
            this.groupBox1.Controls.Add(this.m_chbExtAnalogSigMonSigBufEnaAnaTest1);
            this.groupBox1.Controls.Add(this.m_chbExtAnalogSigMonSigIPEnaAnaTest4);
            this.groupBox1.Controls.Add(this.m_chbExtAnalogSigMonSigIPEnaAnaTest2);
            this.groupBox1.Controls.Add(this.m_chbExtAnalogSigMonSigIPEnaAnaMux);
            this.groupBox1.Controls.Add(this.m_chbExtAnalogSigMonSigIPEnaAnaTest3);
            this.groupBox1.Controls.Add(this.m_chbExtAnalogSigMonSigIPEnaAnaTest1);
            this.groupBox1.Controls.Add(this.m_nudExtAnalogSigMonReportingMode);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(9, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "External Analog Signals Mon Config";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 198);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "For thresholds, 1LSB = 1.8V/256";
            // 
            // m_btnExternalAnalogSignalsMonConfigSet
            // 
            this.m_btnExternalAnalogSignalsMonConfigSet.Location = new System.Drawing.Point(372, 189);
            this.m_btnExternalAnalogSignalsMonConfigSet.Name = "m_btnExternalAnalogSignalsMonConfigSet";
            this.m_btnExternalAnalogSignalsMonConfigSet.Size = new System.Drawing.Size(75, 31);
            this.m_btnExternalAnalogSignalsMonConfigSet.TabIndex = 57;
            this.m_btnExternalAnalogSignalsMonConfigSet.Text = "Set";
            this.m_btnExternalAnalogSignalsMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_nudExtAnalogSigMonSigThresholdMaxAnaMux
            // 
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaMux.Location = new System.Drawing.Point(380, 163);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaMux.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaMux.Name = "m_nudExtAnalogSigMonSigThresholdMaxAnaMux";
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaMux.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaMux.TabIndex = 56;
            // 
            // m_nudExtAnalogSigMonSigThresholdMaxAnaTest1
            // 
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest1.Location = new System.Drawing.Point(128, 163);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest1.Name = "m_nudExtAnalogSigMonSigThresholdMaxAnaTest1";
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest1.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest1.TabIndex = 55;
            // 
            // m_nudExtAnalogSigMonSigThresholdMaxAnaTest4
            // 
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest4.Location = new System.Drawing.Point(317, 163);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest4.Name = "m_nudExtAnalogSigMonSigThresholdMaxAnaTest4";
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest4.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest4.TabIndex = 54;
            // 
            // m_nudExtAnalogSigMonSigThresholdMaxAnaTest3
            // 
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest3.Location = new System.Drawing.Point(254, 163);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest3.Name = "m_nudExtAnalogSigMonSigThresholdMaxAnaTest3";
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest3.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest3.TabIndex = 53;
            // 
            // m_nudExtAnalogSigMonSigThresholdMaxAnaTest2
            // 
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest2.Location = new System.Drawing.Point(187, 163);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest2.Name = "m_nudExtAnalogSigMonSigThresholdMaxAnaTest2";
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest2.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest2.TabIndex = 52;
            // 
            // m_nudExtAnalogSigMonSigThresholdMaxAnaVSense
            // 
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaVSense.Location = new System.Drawing.Point(435, 163);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaVSense.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaVSense.Name = "m_nudExtAnalogSigMonSigThresholdMaxAnaVSense";
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaVSense.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMaxAnaVSense.TabIndex = 51;
            // 
            // m_nudExtAnalogSigMonSigThresholdMinAnaMux
            // 
            this.m_nudExtAnalogSigMonSigThresholdMinAnaMux.Location = new System.Drawing.Point(380, 137);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaMux.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMinAnaMux.Name = "m_nudExtAnalogSigMonSigThresholdMinAnaMux";
            this.m_nudExtAnalogSigMonSigThresholdMinAnaMux.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaMux.TabIndex = 50;
            // 
            // m_nudExtAnalogSigMonSigThresholdMinAnaTest1
            // 
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest1.Location = new System.Drawing.Point(128, 137);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest1.Name = "m_nudExtAnalogSigMonSigThresholdMinAnaTest1";
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest1.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest1.TabIndex = 49;
            // 
            // m_nudExtAnalogSigMonSigThresholdMinAnaTest4
            // 
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest4.Location = new System.Drawing.Point(317, 137);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest4.Name = "m_nudExtAnalogSigMonSigThresholdMinAnaTest4";
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest4.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest4.TabIndex = 48;
            // 
            // m_nudExtAnalogSigMonSigThresholdMinAnaTest3
            // 
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest3.Location = new System.Drawing.Point(254, 137);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest3.Name = "m_nudExtAnalogSigMonSigThresholdMinAnaTest3";
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest3.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest3.TabIndex = 47;
            // 
            // m_nudExtAnalogSigMonSigThresholdMinAnaTest2
            // 
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest2.Location = new System.Drawing.Point(187, 137);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest2.Name = "m_nudExtAnalogSigMonSigThresholdMinAnaTest2";
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest2.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaTest2.TabIndex = 46;
            // 
            // m_nudExtAnalogSigMonSigThresholdMinAnaVSense
            // 
            this.m_nudExtAnalogSigMonSigThresholdMinAnaVSense.Location = new System.Drawing.Point(435, 137);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaVSense.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigThresholdMinAnaVSense.Name = "m_nudExtAnalogSigMonSigThresholdMinAnaVSense";
            this.m_nudExtAnalogSigMonSigThresholdMinAnaVSense.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigThresholdMinAnaVSense.TabIndex = 45;
            // 
            // m_nudExtAnalogSigMonSigSettlingTimeAnaMux
            // 
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaMux.DecimalPlaces = 1;
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaMux.Increment = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaMux.Location = new System.Drawing.Point(380, 111);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaMux.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaMux.Name = "m_nudExtAnalogSigMonSigSettlingTimeAnaMux";
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaMux.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaMux.TabIndex = 44;
            // 
            // m_nudExtAnalogSigMonSigSettlingTimeAnaTest1
            // 
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest1.DecimalPlaces = 1;
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest1.Increment = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest1.Location = new System.Drawing.Point(128, 111);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest1.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest1.Name = "m_nudExtAnalogSigMonSigSettlingTimeAnaTest1";
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest1.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest1.TabIndex = 43;
            // 
            // m_nudExtAnalogSigMonSigSettlingTimeAnaTest4
            // 
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest4.DecimalPlaces = 1;
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest4.Increment = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest4.Location = new System.Drawing.Point(317, 111);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest4.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest4.Name = "m_nudExtAnalogSigMonSigSettlingTimeAnaTest4";
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest4.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest4.TabIndex = 42;
            // 
            // m_nudExtAnalogSigMonSigSettlingTimeAnaTest3
            // 
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest3.DecimalPlaces = 1;
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest3.Increment = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest3.Location = new System.Drawing.Point(254, 111);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest3.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest3.Name = "m_nudExtAnalogSigMonSigSettlingTimeAnaTest3";
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest3.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest3.TabIndex = 41;
            // 
            // m_nudExtAnalogSigMonSigSettlingTimeAnaTest2
            // 
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest2.DecimalPlaces = 1;
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest2.Increment = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest2.Location = new System.Drawing.Point(187, 111);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest2.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest2.Name = "m_nudExtAnalogSigMonSigSettlingTimeAnaTest2";
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest2.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest2.TabIndex = 40;
            // 
            // m_chbExtAnalogSigMonSigBufEnaAnaMux
            // 
            this.m_chbExtAnalogSigMonSigBufEnaAnaMux.AutoSize = true;
            this.m_chbExtAnalogSigMonSigBufEnaAnaMux.Location = new System.Drawing.Point(380, 85);
            this.m_chbExtAnalogSigMonSigBufEnaAnaMux.Name = "m_chbExtAnalogSigMonSigBufEnaAnaMux";
            this.m_chbExtAnalogSigMonSigBufEnaAnaMux.Size = new System.Drawing.Size(15, 14);
            this.m_chbExtAnalogSigMonSigBufEnaAnaMux.TabIndex = 39;
            this.m_chbExtAnalogSigMonSigBufEnaAnaMux.UseVisualStyleBackColor = true;
            // 
            // m_nudExtAnalogSigMonSigSettlingTimeAnaVSense
            // 
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaVSense.DecimalPlaces = 1;
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaVSense.Increment = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaVSense.Location = new System.Drawing.Point(435, 111);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaVSense.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaVSense.Name = "m_nudExtAnalogSigMonSigSettlingTimeAnaVSense";
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaVSense.Size = new System.Drawing.Size(51, 20);
            this.m_nudExtAnalogSigMonSigSettlingTimeAnaVSense.TabIndex = 17;
            // 
            // m_chbExtAnalogSigMonSigBufEnaAnaTest3
            // 
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest3.AutoSize = true;
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest3.Location = new System.Drawing.Point(254, 83);
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest3.Name = "m_chbExtAnalogSigMonSigBufEnaAnaTest3";
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest3.Size = new System.Drawing.Size(15, 14);
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest3.TabIndex = 37;
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest3.UseVisualStyleBackColor = true;
            // 
            // m_chbExtAnalogSigMonSigBufEnaAnaTest4
            // 
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest4.AutoSize = true;
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest4.Location = new System.Drawing.Point(317, 85);
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest4.Name = "m_chbExtAnalogSigMonSigBufEnaAnaTest4";
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest4.Size = new System.Drawing.Size(15, 14);
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest4.TabIndex = 36;
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest4.UseVisualStyleBackColor = true;
            // 
            // m_chbExtAnalogSigMonSigIPEnaVSense
            // 
            this.m_chbExtAnalogSigMonSigIPEnaVSense.AutoSize = true;
            this.m_chbExtAnalogSigMonSigIPEnaVSense.Location = new System.Drawing.Point(435, 64);
            this.m_chbExtAnalogSigMonSigIPEnaVSense.Name = "m_chbExtAnalogSigMonSigIPEnaVSense";
            this.m_chbExtAnalogSigMonSigIPEnaVSense.Size = new System.Drawing.Size(15, 14);
            this.m_chbExtAnalogSigMonSigIPEnaVSense.TabIndex = 35;
            this.m_chbExtAnalogSigMonSigIPEnaVSense.UseVisualStyleBackColor = true;
            // 
            // m_chbExtAnalogSigMonSigBufEnaAnaTest2
            // 
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest2.AutoSize = true;
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest2.Location = new System.Drawing.Point(187, 83);
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest2.Name = "m_chbExtAnalogSigMonSigBufEnaAnaTest2";
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest2.Size = new System.Drawing.Size(15, 14);
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest2.TabIndex = 34;
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest2.UseVisualStyleBackColor = true;
            // 
            // m_chbExtAnalogSigMonSigBufEnaAnaTest1
            // 
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest1.AutoSize = true;
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest1.Location = new System.Drawing.Point(128, 84);
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest1.Name = "m_chbExtAnalogSigMonSigBufEnaAnaTest1";
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest1.Size = new System.Drawing.Size(15, 14);
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest1.TabIndex = 33;
            this.m_chbExtAnalogSigMonSigBufEnaAnaTest1.UseVisualStyleBackColor = true;
            // 
            // m_chbExtAnalogSigMonSigIPEnaAnaTest4
            // 
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest4.AutoSize = true;
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest4.Location = new System.Drawing.Point(317, 64);
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest4.Name = "m_chbExtAnalogSigMonSigIPEnaAnaTest4";
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest4.Size = new System.Drawing.Size(15, 14);
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest4.TabIndex = 32;
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest4.UseVisualStyleBackColor = true;
            // 
            // m_chbExtAnalogSigMonSigIPEnaAnaTest2
            // 
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest2.AutoSize = true;
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest2.Location = new System.Drawing.Point(187, 64);
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest2.Name = "m_chbExtAnalogSigMonSigIPEnaAnaTest2";
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest2.Size = new System.Drawing.Size(15, 14);
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest2.TabIndex = 31;
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest2.UseVisualStyleBackColor = true;
            // 
            // m_chbExtAnalogSigMonSigIPEnaAnaMux
            // 
            this.m_chbExtAnalogSigMonSigIPEnaAnaMux.AutoSize = true;
            this.m_chbExtAnalogSigMonSigIPEnaAnaMux.Location = new System.Drawing.Point(380, 63);
            this.m_chbExtAnalogSigMonSigIPEnaAnaMux.Name = "m_chbExtAnalogSigMonSigIPEnaAnaMux";
            this.m_chbExtAnalogSigMonSigIPEnaAnaMux.Size = new System.Drawing.Size(15, 14);
            this.m_chbExtAnalogSigMonSigIPEnaAnaMux.TabIndex = 30;
            this.m_chbExtAnalogSigMonSigIPEnaAnaMux.UseVisualStyleBackColor = true;
            // 
            // m_chbExtAnalogSigMonSigIPEnaAnaTest3
            // 
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest3.AutoSize = true;
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest3.Location = new System.Drawing.Point(254, 64);
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest3.Name = "m_chbExtAnalogSigMonSigIPEnaAnaTest3";
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest3.Size = new System.Drawing.Size(15, 14);
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest3.TabIndex = 29;
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest3.UseVisualStyleBackColor = true;
            // 
            // m_chbExtAnalogSigMonSigIPEnaAnaTest1
            // 
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest1.AutoSize = true;
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest1.Location = new System.Drawing.Point(128, 64);
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest1.Name = "m_chbExtAnalogSigMonSigIPEnaAnaTest1";
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest1.Size = new System.Drawing.Size(15, 14);
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest1.TabIndex = 28;
            this.m_chbExtAnalogSigMonSigIPEnaAnaTest1.UseVisualStyleBackColor = true;
            // 
            // m_nudExtAnalogSigMonReportingMode
            // 
            this.m_nudExtAnalogSigMonReportingMode.Location = new System.Drawing.Point(128, 16);
            this.m_nudExtAnalogSigMonReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudExtAnalogSigMonReportingMode.Name = "m_nudExtAnalogSigMonReportingMode";
            this.m_nudExtAnalogSigMonReportingMode.Size = new System.Drawing.Size(91, 20);
            this.m_nudExtAnalogSigMonReportingMode.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 169);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Sig Thresh (Max)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 142);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "Sig Thresh (Min)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 116);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 13);
            this.label19.TabIndex = 23;
            this.label19.Text = "Sig Settling Tim (µs)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 85);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 13);
            this.label20.TabIndex = 22;
            this.label20.Text = "Sig Buffer Enable";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(4, 65);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 13);
            this.label21.TabIndex = 21;
            this.label21.Text = "Sig Input Enable";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(311, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "AnaTest4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(431, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "VSense";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(372, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "AnaMux";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Reporting Mode";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(123, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "AnaTest1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(249, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "AnaTest3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(185, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "AnaTest2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_nudTX2IntAnalogSigMonReportingMode);
            this.groupBox2.Controls.Add(this.m_nudTX3IntAnalogSigMonReportingMode);
            this.groupBox2.Controls.Add(this.m_nudTX1IntAnalogSigMonProfileIndex);
            this.groupBox2.Controls.Add(this.m_nudTX1IntAnalogSigMonReportingMode);
            this.groupBox2.Controls.Add(this.m_nudTX3IntAnalogSigMonProfileIndex);
            this.groupBox2.Controls.Add(this.m_nudTX2IntAnalogSigMonProfileIndex);
            this.groupBox2.Controls.Add(this.m_btnTX2IntAnalogSigMonConfigSet);
            this.groupBox2.Controls.Add(this.m_btnTX1IntAnalogSigMonConfigSet);
            this.groupBox2.Controls.Add(this.m_btnTX3IntAnalogSigMonConfigSet);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(526, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 164);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TX Internal Analog Signals Mon Config ";
            // 
            // m_nudTX2IntAnalogSigMonReportingMode
            // 
            this.m_nudTX2IntAnalogSigMonReportingMode.Location = new System.Drawing.Point(182, 77);
            this.m_nudTX2IntAnalogSigMonReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudTX2IntAnalogSigMonReportingMode.Name = "m_nudTX2IntAnalogSigMonReportingMode";
            this.m_nudTX2IntAnalogSigMonReportingMode.Size = new System.Drawing.Size(65, 20);
            this.m_nudTX2IntAnalogSigMonReportingMode.TabIndex = 39;
            // 
            // m_nudTX3IntAnalogSigMonReportingMode
            // 
            this.m_nudTX3IntAnalogSigMonReportingMode.Location = new System.Drawing.Point(266, 78);
            this.m_nudTX3IntAnalogSigMonReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudTX3IntAnalogSigMonReportingMode.Name = "m_nudTX3IntAnalogSigMonReportingMode";
            this.m_nudTX3IntAnalogSigMonReportingMode.Size = new System.Drawing.Size(65, 20);
            this.m_nudTX3IntAnalogSigMonReportingMode.TabIndex = 38;
            // 
            // m_nudTX1IntAnalogSigMonProfileIndex
            // 
            this.m_nudTX1IntAnalogSigMonProfileIndex.Location = new System.Drawing.Point(98, 46);
            this.m_nudTX1IntAnalogSigMonProfileIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudTX1IntAnalogSigMonProfileIndex.Name = "m_nudTX1IntAnalogSigMonProfileIndex";
            this.m_nudTX1IntAnalogSigMonProfileIndex.Size = new System.Drawing.Size(65, 20);
            this.m_nudTX1IntAnalogSigMonProfileIndex.TabIndex = 37;
            // 
            // m_nudTX1IntAnalogSigMonReportingMode
            // 
            this.m_nudTX1IntAnalogSigMonReportingMode.Location = new System.Drawing.Point(98, 79);
            this.m_nudTX1IntAnalogSigMonReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudTX1IntAnalogSigMonReportingMode.Name = "m_nudTX1IntAnalogSigMonReportingMode";
            this.m_nudTX1IntAnalogSigMonReportingMode.Size = new System.Drawing.Size(65, 20);
            this.m_nudTX1IntAnalogSigMonReportingMode.TabIndex = 36;
            // 
            // m_nudTX3IntAnalogSigMonProfileIndex
            // 
            this.m_nudTX3IntAnalogSigMonProfileIndex.Location = new System.Drawing.Point(266, 43);
            this.m_nudTX3IntAnalogSigMonProfileIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudTX3IntAnalogSigMonProfileIndex.Name = "m_nudTX3IntAnalogSigMonProfileIndex";
            this.m_nudTX3IntAnalogSigMonProfileIndex.Size = new System.Drawing.Size(65, 20);
            this.m_nudTX3IntAnalogSigMonProfileIndex.TabIndex = 35;
            // 
            // m_nudTX2IntAnalogSigMonProfileIndex
            // 
            this.m_nudTX2IntAnalogSigMonProfileIndex.Location = new System.Drawing.Point(182, 45);
            this.m_nudTX2IntAnalogSigMonProfileIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudTX2IntAnalogSigMonProfileIndex.Name = "m_nudTX2IntAnalogSigMonProfileIndex";
            this.m_nudTX2IntAnalogSigMonProfileIndex.Size = new System.Drawing.Size(65, 20);
            this.m_nudTX2IntAnalogSigMonProfileIndex.TabIndex = 34;
            // 
            // m_btnTX2IntAnalogSigMonConfigSet
            // 
            this.m_btnTX2IntAnalogSigMonConfigSet.Location = new System.Drawing.Point(183, 119);
            this.m_btnTX2IntAnalogSigMonConfigSet.Name = "m_btnTX2IntAnalogSigMonConfigSet";
            this.m_btnTX2IntAnalogSigMonConfigSet.Size = new System.Drawing.Size(65, 23);
            this.m_btnTX2IntAnalogSigMonConfigSet.TabIndex = 33;
            this.m_btnTX2IntAnalogSigMonConfigSet.Text = "Set";
            this.m_btnTX2IntAnalogSigMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_btnTX1IntAnalogSigMonConfigSet
            // 
            this.m_btnTX1IntAnalogSigMonConfigSet.Location = new System.Drawing.Point(98, 119);
            this.m_btnTX1IntAnalogSigMonConfigSet.Name = "m_btnTX1IntAnalogSigMonConfigSet";
            this.m_btnTX1IntAnalogSigMonConfigSet.Size = new System.Drawing.Size(65, 23);
            this.m_btnTX1IntAnalogSigMonConfigSet.TabIndex = 32;
            this.m_btnTX1IntAnalogSigMonConfigSet.Text = "Set";
            this.m_btnTX1IntAnalogSigMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_btnTX3IntAnalogSigMonConfigSet
            // 
            this.m_btnTX3IntAnalogSigMonConfigSet.Location = new System.Drawing.Point(270, 121);
            this.m_btnTX3IntAnalogSigMonConfigSet.Name = "m_btnTX3IntAnalogSigMonConfigSet";
            this.m_btnTX3IntAnalogSigMonConfigSet.Size = new System.Drawing.Size(65, 23);
            this.m_btnTX3IntAnalogSigMonConfigSet.TabIndex = 31;
            this.m_btnTX3IntAnalogSigMonConfigSet.Text = "Set";
            this.m_btnTX3IntAnalogSigMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(263, 21);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(27, 13);
            this.label22.TabIndex = 30;
            this.label22.Text = "TX2";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(186, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(27, 13);
            this.label23.TabIndex = 29;
            this.label23.Text = "TX1";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(103, 21);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(27, 13);
            this.label24.TabIndex = 28;
            this.label24.Text = "TX0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Profile Index";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Reporting Mode";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_btnRXIntAnalogSigMonConfigSet);
            this.groupBox3.Controls.Add(this.m_nudRXIntAnalogSigMonReportingMode);
            this.groupBox3.Controls.Add(this.m_nudRXIntAnalogSigMonProfileIndex);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Location = new System.Drawing.Point(880, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 164);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RX Int Analog Sig Mon Config ";
            // 
            // m_btnRXIntAnalogSigMonConfigSet
            // 
            this.m_btnRXIntAnalogSigMonConfigSet.Location = new System.Drawing.Point(99, 119);
            this.m_btnRXIntAnalogSigMonConfigSet.Name = "m_btnRXIntAnalogSigMonConfigSet";
            this.m_btnRXIntAnalogSigMonConfigSet.Size = new System.Drawing.Size(75, 23);
            this.m_btnRXIntAnalogSigMonConfigSet.TabIndex = 21;
            this.m_btnRXIntAnalogSigMonConfigSet.Text = "Set";
            this.m_btnRXIntAnalogSigMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_nudRXIntAnalogSigMonReportingMode
            // 
            this.m_nudRXIntAnalogSigMonReportingMode.Location = new System.Drawing.Point(109, 72);
            this.m_nudRXIntAnalogSigMonReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudRXIntAnalogSigMonReportingMode.Name = "m_nudRXIntAnalogSigMonReportingMode";
            this.m_nudRXIntAnalogSigMonReportingMode.Size = new System.Drawing.Size(65, 20);
            this.m_nudRXIntAnalogSigMonReportingMode.TabIndex = 20;
            // 
            // m_nudRXIntAnalogSigMonProfileIndex
            // 
            this.m_nudRXIntAnalogSigMonProfileIndex.Location = new System.Drawing.Point(109, 41);
            this.m_nudRXIntAnalogSigMonProfileIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudRXIntAnalogSigMonProfileIndex.Name = "m_nudRXIntAnalogSigMonProfileIndex";
            this.m_nudRXIntAnalogSigMonProfileIndex.Size = new System.Drawing.Size(65, 20);
            this.m_nudRXIntAnalogSigMonProfileIndex.TabIndex = 19;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(83, 13);
            this.label25.TabIndex = 10;
            this.label25.Text = "Reporting Mode";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 41);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 13);
            this.label26.TabIndex = 9;
            this.label26.Text = "Profile Index";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_nudPMCLKSync20GMaxThreshold);
            this.groupBox4.Controls.Add(this.m_nudPMCLKSync20GMinThreshold);
            this.groupBox4.Controls.Add(this.m_cboPMCLKSync20GSigSelect);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.m_btnPMCLKLOIntAnalogSigMonConfigSet);
            this.groupBox4.Controls.Add(this.m_nudPMCLKLOIntAnalogSigMonReportingMode);
            this.groupBox4.Controls.Add(this.m_nudPMCLKLOIntAnalogSigMonProfileIndex);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Location = new System.Drawing.Point(9, 244);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(256, 198);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PMCLKLO Int Analog Sig Mon Config ";
            // 
            // m_nudPMCLKSync20GMaxThreshold
            // 
            this.m_nudPMCLKSync20GMaxThreshold.Location = new System.Drawing.Point(153, 136);
            this.m_nudPMCLKSync20GMaxThreshold.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.m_nudPMCLKSync20GMaxThreshold.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.m_nudPMCLKSync20GMaxThreshold.Name = "m_nudPMCLKSync20GMaxThreshold";
            this.m_nudPMCLKSync20GMaxThreshold.Size = new System.Drawing.Size(67, 20);
            this.m_nudPMCLKSync20GMaxThreshold.TabIndex = 27;
            // 
            // m_nudPMCLKSync20GMinThreshold
            // 
            this.m_nudPMCLKSync20GMinThreshold.Location = new System.Drawing.Point(153, 110);
            this.m_nudPMCLKSync20GMinThreshold.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.m_nudPMCLKSync20GMinThreshold.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.m_nudPMCLKSync20GMinThreshold.Name = "m_nudPMCLKSync20GMinThreshold";
            this.m_nudPMCLKSync20GMinThreshold.Size = new System.Drawing.Size(67, 20);
            this.m_nudPMCLKSync20GMinThreshold.TabIndex = 26;
            // 
            // m_cboPMCLKSync20GSigSelect
            // 
            this.m_cboPMCLKSync20GSigSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPMCLKSync20GSigSelect.FormattingEnabled = true;
            this.m_cboPMCLKSync20GSigSelect.Items.AddRange(new object[] {
            "20GHzSyncDis",
            "SyncIn",
            "SyncOut",
            "ClkOut"});
            this.m_cboPMCLKSync20GSigSelect.Location = new System.Drawing.Point(153, 82);
            this.m_cboPMCLKSync20GSigSelect.Name = "m_cboPMCLKSync20GSigSelect";
            this.m_cboPMCLKSync20GSigSelect.Size = new System.Drawing.Size(97, 21);
            this.m_cboPMCLKSync20GSigSelect.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Sync 20G Max Thresh (dBm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Sync 20G Min Thresh (dBm)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Sync 20G Sig Sel";
            // 
            // m_btnPMCLKLOIntAnalogSigMonConfigSet
            // 
            this.m_btnPMCLKLOIntAnalogSigMonConfigSet.Location = new System.Drawing.Point(150, 168);
            this.m_btnPMCLKLOIntAnalogSigMonConfigSet.Name = "m_btnPMCLKLOIntAnalogSigMonConfigSet";
            this.m_btnPMCLKLOIntAnalogSigMonConfigSet.Size = new System.Drawing.Size(65, 23);
            this.m_btnPMCLKLOIntAnalogSigMonConfigSet.TabIndex = 21;
            this.m_btnPMCLKLOIntAnalogSigMonConfigSet.Text = "Set";
            this.m_btnPMCLKLOIntAnalogSigMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_nudPMCLKLOIntAnalogSigMonReportingMode
            // 
            this.m_nudPMCLKLOIntAnalogSigMonReportingMode.Location = new System.Drawing.Point(153, 55);
            this.m_nudPMCLKLOIntAnalogSigMonReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudPMCLKLOIntAnalogSigMonReportingMode.Name = "m_nudPMCLKLOIntAnalogSigMonReportingMode";
            this.m_nudPMCLKLOIntAnalogSigMonReportingMode.Size = new System.Drawing.Size(65, 20);
            this.m_nudPMCLKLOIntAnalogSigMonReportingMode.TabIndex = 20;
            // 
            // m_nudPMCLKLOIntAnalogSigMonProfileIndex
            // 
            this.m_nudPMCLKLOIntAnalogSigMonProfileIndex.Location = new System.Drawing.Point(153, 29);
            this.m_nudPMCLKLOIntAnalogSigMonProfileIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudPMCLKLOIntAnalogSigMonProfileIndex.Name = "m_nudPMCLKLOIntAnalogSigMonProfileIndex";
            this.m_nudPMCLKLOIntAnalogSigMonProfileIndex.Size = new System.Drawing.Size(65, 20);
            this.m_nudPMCLKLOIntAnalogSigMonProfileIndex.TabIndex = 19;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(4, 60);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(83, 13);
            this.label27.TabIndex = 11;
            this.label27.Text = "Reporting Mode";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(4, 30);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 13);
            this.label28.TabIndex = 10;
            this.label28.Text = "Profile Index";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_btnGPADCIntAnalogSigMonConfigSet);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.m_nudGPADCIntAnalogSigMonReportingMode);
            this.groupBox5.Location = new System.Drawing.Point(271, 244);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 145);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "GPADC Int Analog Sig Mon Config ";
            // 
            // m_btnGPADCIntAnalogSigMonConfigSet
            // 
            this.m_btnGPADCIntAnalogSigMonConfigSet.Location = new System.Drawing.Point(104, 104);
            this.m_btnGPADCIntAnalogSigMonConfigSet.Name = "m_btnGPADCIntAnalogSigMonConfigSet";
            this.m_btnGPADCIntAnalogSigMonConfigSet.Size = new System.Drawing.Size(65, 23);
            this.m_btnGPADCIntAnalogSigMonConfigSet.TabIndex = 23;
            this.m_btnGPADCIntAnalogSigMonConfigSet.Text = "Set";
            this.m_btnGPADCIntAnalogSigMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(4, 39);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 13);
            this.label29.TabIndex = 22;
            this.label29.Text = "Reporting Mode";
            // 
            // m_nudGPADCIntAnalogSigMonReportingMode
            // 
            this.m_nudGPADCIntAnalogSigMonReportingMode.Location = new System.Drawing.Point(104, 38);
            this.m_nudGPADCIntAnalogSigMonReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudGPADCIntAnalogSigMonReportingMode.Name = "m_nudGPADCIntAnalogSigMonReportingMode";
            this.m_nudGPADCIntAnalogSigMonReportingMode.Size = new System.Drawing.Size(65, 20);
            this.m_nudGPADCIntAnalogSigMonReportingMode.TabIndex = 21;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.m_btnPLLControlVolMonConfigSet);
            this.groupBox6.Controls.Add(this.m_chbPLLCtlVolMonAPLLVctl);
            this.groupBox6.Controls.Add(this.m_chbPLLCtlVolMonSynthVCO1VolControl);
            this.groupBox6.Controls.Add(this.m_chbPLLCtlVolMonSynthVCO2VolControl);
            this.groupBox6.Controls.Add(this.m_nudPLLCtlVolMonReportingMode);
            this.groupBox6.Controls.Add(this.label30);
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Location = new System.Drawing.Point(496, 244);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(219, 145);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "PLL Control Voltage Mon Config";
            // 
            // m_btnPLLControlVolMonConfigSet
            // 
            this.m_btnPLLControlVolMonConfigSet.Location = new System.Drawing.Point(124, 104);
            this.m_btnPLLControlVolMonConfigSet.Name = "m_btnPLLControlVolMonConfigSet";
            this.m_btnPLLControlVolMonConfigSet.Size = new System.Drawing.Size(65, 23);
            this.m_btnPLLControlVolMonConfigSet.TabIndex = 26;
            this.m_btnPLLControlVolMonConfigSet.Text = "Set";
            this.m_btnPLLControlVolMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_chbPLLCtlVolMonAPLLVctl
            // 
            this.m_chbPLLCtlVolMonAPLLVctl.AutoSize = true;
            this.m_chbPLLCtlVolMonAPLLVctl.Location = new System.Drawing.Point(6, 71);
            this.m_chbPLLCtlVolMonAPLLVctl.Name = "m_chbPLLCtlVolMonAPLLVctl";
            this.m_chbPLLCtlVolMonAPLLVctl.Size = new System.Drawing.Size(70, 17);
            this.m_chbPLLCtlVolMonAPLLVctl.TabIndex = 25;
            this.m_chbPLLCtlVolMonAPLLVctl.Text = "APLLVctl";
            this.m_chbPLLCtlVolMonAPLLVctl.UseVisualStyleBackColor = true;
            // 
            // m_chbPLLCtlVolMonSynthVCO1VolControl
            // 
            this.m_chbPLLCtlVolMonSynthVCO1VolControl.AutoSize = true;
            this.m_chbPLLCtlVolMonSynthVCO1VolControl.Location = new System.Drawing.Point(100, 69);
            this.m_chbPLLCtlVolMonSynthVCO1VolControl.Name = "m_chbPLLCtlVolMonSynthVCO1VolControl";
            this.m_chbPLLCtlVolMonSynthVCO1VolControl.Size = new System.Drawing.Size(114, 17);
            this.m_chbPLLCtlVolMonSynthVCO1VolControl.TabIndex = 24;
            this.m_chbPLLCtlVolMonSynthVCO1VolControl.Text = "Synth VCO1Vol Ctl";
            this.m_chbPLLCtlVolMonSynthVCO1VolControl.UseVisualStyleBackColor = true;
            // 
            // m_chbPLLCtlVolMonSynthVCO2VolControl
            // 
            this.m_chbPLLCtlVolMonSynthVCO2VolControl.AutoSize = true;
            this.m_chbPLLCtlVolMonSynthVCO2VolControl.Location = new System.Drawing.Point(6, 91);
            this.m_chbPLLCtlVolMonSynthVCO2VolControl.Name = "m_chbPLLCtlVolMonSynthVCO2VolControl";
            this.m_chbPLLCtlVolMonSynthVCO2VolControl.Size = new System.Drawing.Size(117, 17);
            this.m_chbPLLCtlVolMonSynthVCO2VolControl.TabIndex = 23;
            this.m_chbPLLCtlVolMonSynthVCO2VolControl.Text = "Synth VCO2 Vol Ctl";
            this.m_chbPLLCtlVolMonSynthVCO2VolControl.UseVisualStyleBackColor = true;
            // 
            // m_nudPLLCtlVolMonReportingMode
            // 
            this.m_nudPLLCtlVolMonReportingMode.Location = new System.Drawing.Point(100, 27);
            this.m_nudPLLCtlVolMonReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudPLLCtlVolMonReportingMode.Name = "m_nudPLLCtlVolMonReportingMode";
            this.m_nudPLLCtlVolMonReportingMode.Size = new System.Drawing.Size(65, 20);
            this.m_nudPLLCtlVolMonReportingMode.TabIndex = 19;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(4, 49);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 13);
            this.label30.TabIndex = 10;
            this.label30.Text = "Signal Enables";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(4, 28);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(83, 13);
            this.label31.TabIndex = 9;
            this.label31.Text = "Reporting Mode";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.m_btnDCCMonConfigSet);
            this.groupBox7.Controls.Add(this.label32);
            this.groupBox7.Controls.Add(this.m_chbDCCMonClockPair2);
            this.groupBox7.Controls.Add(this.m_chbDCCMonClockPair5);
            this.groupBox7.Controls.Add(this.m_chbDCCMonClockPair1);
            this.groupBox7.Controls.Add(this.m_chbDCCMonClockPair4);
            this.groupBox7.Controls.Add(this.m_chbDCCMonClockPair3);
            this.groupBox7.Controls.Add(this.m_chbDCCMonClockPair0);
            this.groupBox7.Controls.Add(this.m_nudDCCMonReportingMode);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Location = new System.Drawing.Point(754, 244);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(274, 145);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "DCC Monitoring Config";
            // 
            // m_btnDCCMonConfigSet
            // 
            this.m_btnDCCMonConfigSet.Location = new System.Drawing.Point(178, 104);
            this.m_btnDCCMonConfigSet.Name = "m_btnDCCMonConfigSet";
            this.m_btnDCCMonConfigSet.Size = new System.Drawing.Size(75, 23);
            this.m_btnDCCMonConfigSet.TabIndex = 44;
            this.m_btnDCCMonConfigSet.Text = "Set";
            this.m_btnDCCMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(4, 24);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(83, 13);
            this.label32.TabIndex = 43;
            this.label32.Text = "Reporting Mode";
            // 
            // m_chbDCCMonClockPair2
            // 
            this.m_chbDCCMonClockPair2.AutoSize = true;
            this.m_chbDCCMonClockPair2.Location = new System.Drawing.Point(170, 60);
            this.m_chbDCCMonClockPair2.Name = "m_chbDCCMonClockPair2";
            this.m_chbDCCMonClockPair2.Size = new System.Drawing.Size(80, 17);
            this.m_chbDCCMonClockPair2.TabIndex = 41;
            this.m_chbDCCMonClockPair2.Text = "ClockPair 2";
            this.m_chbDCCMonClockPair2.UseVisualStyleBackColor = true;
            // 
            // m_chbDCCMonClockPair5
            // 
            this.m_chbDCCMonClockPair5.AutoSize = true;
            this.m_chbDCCMonClockPair5.Location = new System.Drawing.Point(170, 85);
            this.m_chbDCCMonClockPair5.Name = "m_chbDCCMonClockPair5";
            this.m_chbDCCMonClockPair5.Size = new System.Drawing.Size(80, 17);
            this.m_chbDCCMonClockPair5.TabIndex = 21;
            this.m_chbDCCMonClockPair5.Text = "ClockPair 5";
            this.m_chbDCCMonClockPair5.UseVisualStyleBackColor = true;
            // 
            // m_chbDCCMonClockPair1
            // 
            this.m_chbDCCMonClockPair1.AutoSize = true;
            this.m_chbDCCMonClockPair1.Location = new System.Drawing.Point(86, 62);
            this.m_chbDCCMonClockPair1.Name = "m_chbDCCMonClockPair1";
            this.m_chbDCCMonClockPair1.Size = new System.Drawing.Size(80, 17);
            this.m_chbDCCMonClockPair1.TabIndex = 42;
            this.m_chbDCCMonClockPair1.Text = "ClockPair 1";
            this.m_chbDCCMonClockPair1.UseVisualStyleBackColor = true;
            // 
            // m_chbDCCMonClockPair4
            // 
            this.m_chbDCCMonClockPair4.AutoSize = true;
            this.m_chbDCCMonClockPair4.Location = new System.Drawing.Point(87, 85);
            this.m_chbDCCMonClockPair4.Name = "m_chbDCCMonClockPair4";
            this.m_chbDCCMonClockPair4.Size = new System.Drawing.Size(80, 17);
            this.m_chbDCCMonClockPair4.TabIndex = 20;
            this.m_chbDCCMonClockPair4.Text = "ClockPair 4";
            this.m_chbDCCMonClockPair4.UseVisualStyleBackColor = true;
            // 
            // m_chbDCCMonClockPair3
            // 
            this.m_chbDCCMonClockPair3.AutoSize = true;
            this.m_chbDCCMonClockPair3.Location = new System.Drawing.Point(7, 85);
            this.m_chbDCCMonClockPair3.Name = "m_chbDCCMonClockPair3";
            this.m_chbDCCMonClockPair3.Size = new System.Drawing.Size(80, 17);
            this.m_chbDCCMonClockPair3.TabIndex = 40;
            this.m_chbDCCMonClockPair3.Text = "ClockPair 3";
            this.m_chbDCCMonClockPair3.UseVisualStyleBackColor = true;
            // 
            // m_chbDCCMonClockPair0
            // 
            this.m_chbDCCMonClockPair0.AutoSize = true;
            this.m_chbDCCMonClockPair0.Location = new System.Drawing.Point(7, 62);
            this.m_chbDCCMonClockPair0.Name = "m_chbDCCMonClockPair0";
            this.m_chbDCCMonClockPair0.Size = new System.Drawing.Size(80, 17);
            this.m_chbDCCMonClockPair0.TabIndex = 38;
            this.m_chbDCCMonClockPair0.Text = "ClockPair 0";
            this.m_chbDCCMonClockPair0.UseVisualStyleBackColor = true;
            // 
            // m_nudDCCMonReportingMode
            // 
            this.m_nudDCCMonReportingMode.Location = new System.Drawing.Point(136, 21);
            this.m_nudDCCMonReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudDCCMonReportingMode.Name = "m_nudDCCMonReportingMode";
            this.m_nudDCCMonReportingMode.Size = new System.Drawing.Size(65, 20);
            this.m_nudDCCMonReportingMode.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "DCC Pair Enables";
            // 
            // c0000b1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "c0000b1";
            this.Size = new System.Drawing.Size(1138, 492);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaMux)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaTest2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMaxAnaVSense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaMux)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaTest2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigThresholdMinAnaVSense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaMux)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaTest2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonSigSettlingTimeAnaVSense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudExtAnalogSigMonReportingMode)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX2IntAnalogSigMonReportingMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX3IntAnalogSigMonReportingMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX1IntAnalogSigMonProfileIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX1IntAnalogSigMonReportingMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX3IntAnalogSigMonProfileIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTX2IntAnalogSigMonProfileIndex)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXIntAnalogSigMonReportingMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXIntAnalogSigMonProfileIndex)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPMCLKSync20GMaxThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPMCLKSync20GMinThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPMCLKLOIntAnalogSigMonReportingMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPMCLKLOIntAnalogSigMonProfileIndex)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGPADCIntAnalogSigMonReportingMode)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPLLCtlVolMonReportingMode)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDCCMonReportingMode)).EndInit();
            this.ResumeLayout(false);

		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;
		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;
		private frmAR1Main m_MainForm;
		private MonExternalAnalogSignalConfigParameters m_MonExternalAnalogSignalConfigParameters;
		private MonInternalTx1AnalogSignalConfigParameters m_MonInternalTx1AnalogSignalConfigParameters;
		private MonInternalTx2AnalogSignalConfigParameters m_MonInternalTx2AnalogSignalConfigParameters;
		private MonInternalTx3AnalogSignalConfigParameters m_MonInternalTx3AnalogSignalConfigParameters;
		private MonInternalRxAnalogSignalConfigParameters m_MonInternalRxAnalogSignalConfigParameters;
		private MonInternalPMCLKLOAnalogSignalConfigParameters m_MonInternalPMCLKLOAnalogSignalConfigParameters;
		private MonInternalGPADCAnalogSignalConfigParameters m_MonInternalGPADCAnalogSignalConfigParameters;
		private MonPLLControlVoltageConfigParameters m_MonPLLControlVoltageConfigParameters;
		private MonDualClockCompConfigParameters m_MonDualClockCompConfigParameters;
		private IContainer components;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
		private GroupBox groupBox4;
		private GroupBox groupBox5;
		private GroupBox groupBox6;
		private GroupBox groupBox7;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label11;
		private Label label12;
		private Label label13;
		private Label label14;
		private Label label1;
		private Label label15;
		private Label label16;
		private Label label17;
		private Label label18;
		private Label label19;
		private Label label20;
		private Label label21;
		private NumericUpDown m_nudExtAnalogSigMonReportingMode;
		private NumericUpDown m_nudExtAnalogSigMonSigSettlingTimeAnaVSense;
		private NumericUpDown m_nudDCCMonReportingMode;
		private CheckBox m_chbExtAnalogSigMonSigIPEnaAnaTest4;
		private CheckBox m_chbExtAnalogSigMonSigIPEnaAnaTest2;
		private CheckBox m_chbExtAnalogSigMonSigIPEnaAnaMux;
		private CheckBox m_chbExtAnalogSigMonSigIPEnaAnaTest3;
		private CheckBox m_chbExtAnalogSigMonSigIPEnaAnaTest1;
		private CheckBox m_chbDCCMonClockPair4;
		private CheckBox m_chbDCCMonClockPair5;
		private CheckBox m_chbExtAnalogSigMonSigBufEnaAnaMux;
		private CheckBox m_chbExtAnalogSigMonSigBufEnaAnaTest3;
		private CheckBox m_chbExtAnalogSigMonSigBufEnaAnaTest4;
		private CheckBox m_chbExtAnalogSigMonSigIPEnaVSense;
		private CheckBox m_chbExtAnalogSigMonSigBufEnaAnaTest2;
		private CheckBox m_chbExtAnalogSigMonSigBufEnaAnaTest1;
		private CheckBox m_chbDCCMonClockPair2;
		private CheckBox m_chbDCCMonClockPair1;
		private CheckBox m_chbDCCMonClockPair3;
		private CheckBox m_chbDCCMonClockPair0;
		private NumericUpDown m_nudExtAnalogSigMonSigSettlingTimeAnaMux;
		private NumericUpDown m_nudExtAnalogSigMonSigSettlingTimeAnaTest1;
		private NumericUpDown m_nudExtAnalogSigMonSigSettlingTimeAnaTest4;
		private NumericUpDown m_nudExtAnalogSigMonSigSettlingTimeAnaTest3;
		private NumericUpDown m_nudExtAnalogSigMonSigSettlingTimeAnaTest2;
		private Button m_btnExternalAnalogSignalsMonConfigSet;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMaxAnaMux;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMaxAnaTest1;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMaxAnaTest4;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMaxAnaTest3;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMaxAnaTest2;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMaxAnaVSense;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMinAnaMux;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMinAnaTest1;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMinAnaTest4;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMinAnaTest3;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMinAnaTest2;
		private NumericUpDown m_nudExtAnalogSigMonSigThresholdMinAnaVSense;
		private Button m_btnTX3IntAnalogSigMonConfigSet;
		private Label label22;
		private Label label23;
		private Label label24;
		private NumericUpDown m_nudTX2IntAnalogSigMonReportingMode;
		private NumericUpDown m_nudTX3IntAnalogSigMonReportingMode;
		private NumericUpDown m_nudTX1IntAnalogSigMonProfileIndex;
		private NumericUpDown m_nudTX1IntAnalogSigMonReportingMode;
		private NumericUpDown m_nudTX3IntAnalogSigMonProfileIndex;
		private NumericUpDown m_nudTX2IntAnalogSigMonProfileIndex;
		private Button m_btnTX2IntAnalogSigMonConfigSet;
		private Button m_btnTX1IntAnalogSigMonConfigSet;
		private Label label25;
		private Label label26;
		private Button m_btnRXIntAnalogSigMonConfigSet;
		private NumericUpDown m_nudRXIntAnalogSigMonReportingMode;
		private NumericUpDown m_nudRXIntAnalogSigMonProfileIndex;
		private NumericUpDown m_nudPMCLKLOIntAnalogSigMonReportingMode;
		private NumericUpDown m_nudPMCLKLOIntAnalogSigMonProfileIndex;
		private Label label27;
		private Label label28;
		private Label label29;
		private NumericUpDown m_nudGPADCIntAnalogSigMonReportingMode;
		private Button m_btnPMCLKLOIntAnalogSigMonConfigSet;
		private Button m_btnGPADCIntAnalogSigMonConfigSet;
		private Label label30;
		private Label label31;
		private CheckBox m_chbPLLCtlVolMonSynthVCO1VolControl;
		private CheckBox m_chbPLLCtlVolMonSynthVCO2VolControl;
		private NumericUpDown m_nudPLLCtlVolMonReportingMode;
		private CheckBox m_chbPLLCtlVolMonAPLLVctl;
		private Button m_btnPLLControlVolMonConfigSet;
		private Label label32;
		private Button m_btnDCCMonConfigSet;
		private NumericUpDown m_nudPMCLKSync20GMaxThreshold;
		private NumericUpDown m_nudPMCLKSync20GMinThreshold;
		private ComboBox m_cboPMCLKSync20GSigSelect;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label5;
	}
}
