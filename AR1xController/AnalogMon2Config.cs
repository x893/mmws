using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class AnalogMon2Config : UserControl
	{
		public AnalogMon2Config()
		{
			InitializeComponent();
			m_MainForm = m_GuiManager.MainTsForm;
			m_MonRXGainPhaseConfigParameters = m_GuiManager.TsParams.MonRXGainPhaseConfigParameters;
			m_MonRXNoiseFigureConfigParameters = m_GuiManager.TsParams.MonRXNoiseFigureConfigParameters;
			m_MonRXIFStageConfigParameters = m_GuiManager.TsParams.MonRXIFStageConfigParameters;
			m_MonRxSaturationDetectorConfigParameters = m_GuiManager.TsParams.MonRxSaturationDetectorConfigParameters;
			m_MonSignalAndImageConfigParameters = m_GuiManager.TsParams.MonSignalAndImageConfigParameters;
			m_MonSynthFrequencyConfigParameters = m_GuiManager.TsParams.MonSynthFrequencyConfigParameters;
			m_MonTemperatureConfigParameters = m_GuiManager.TsParams.MonTemperatureConfigParameters;
			m_MonRxMixerInputPowerConfigParameters = m_GuiManager.TsParams.MonRxMixerInputPowerConfigParameters;
			m_nudSynthFrequencyMonFreqErrorThreshold.Value = 4000m;
			m_nudSynthFrequencyMonStartTime.Value = 2m;
			m_cboRxGainPhaseMonTxSelect.SelectedIndex = 0;
			m_nudRxNoiseFigureReportingMode.Value = 0m;
			m_nudRxSatDetectorMonPriTimeSliceDuration.Value = 0.8m;
			m_nudRxSatDetectorMonSatMonNumSlice.Value = 63m;
			m_cboRxSatDetectorSatMonSelect.SelectedIndex = 1;
			m_nudRxSatDetectorMonSatMonRxChannelMask.Value = 0m;
			m_nudSigImgMonNumSlice.Value = 63m;
			m_nudSigImgMonPriTimeSliceNumSamples.Value = 8m;
		}

		private int iSetRXGainPhaseMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetRXGainPhaseMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRXGainPhaseMonConfig()
		{
			iSetRXGainPhaseMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetRXGainPhaseMonConfigAsync()
		{
			new del_v_v(iSetRXGainPhaseMonConfig).BeginInvoke(null, null);
		}

		private void m_btnRxGainPhaseMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetRXGainPhaseMonConfigAsync();
		}

		public bool UpdateRxGainPhaseMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRxGainPhaseMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonRXGainPhaseConfigParameters.ProfileIndex = (char)m_nudRXGainPhaseMonProfileIndex.Value;
				m_MonRXGainPhaseConfigParameters.RF1FreqBitMask = (m_chbRF1RXGainPhaseMonBitMask.Checked ? '\u0001' : '\0');
				m_MonRXGainPhaseConfigParameters.RF2FreqBitMask = (m_chbRF2RXGainPhaseMonBitMask.Checked ? '\u0001' : '\0');
				m_MonRXGainPhaseConfigParameters.RF3FreqBitMask = (m_chbRF3RXGainPhaseMonBitMask.Checked ? '\u0001' : '\0');
				m_MonRXGainPhaseConfigParameters.ReportingMode = (char)m_nudRXGainPhaseReprotingMode.Value;
				m_MonRXGainPhaseConfigParameters.TxSelect = (char)m_cboRxGainPhaseMonTxSelect.SelectedIndex;
				m_MonRXGainPhaseConfigParameters.RxGainAbsoluteErrorThreshold = (double)m_nudRXGainPhaseAbsErrThreshold.Value;
				m_MonRXGainPhaseConfigParameters.RxGainMismatchThreshold = (double)m_nudRXGainMismatchThresholds.Value;
				m_MonRXGainPhaseConfigParameters.RxGainFlatnessErrorThreshold = (double)m_nudRXGainFlatnessErrThreshold.Value;
				m_MonRXGainPhaseConfigParameters.RxPhaseMismatchThreshold = (ushort)m_nudRXPhaseMismatchThreshold.Value;
				m_MonRXGainPhaseConfigParameters.f000301 = (double)m_nudRF1RX1RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000302 = (double)m_nudRF1RX2RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000303 = (double)m_nudRF1RX3RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000304 = (double)m_nudRF1RX4RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000305 = (double)m_nudRF2RX1RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000306 = (double)m_nudRF2RX2RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000307 = (double)m_nudRF2RX3RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000308 = (double)m_nudRF2RX4RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000309 = (double)m_nudRF3RX1RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f00030a = (double)m_nudRF3RX2RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f00030b = (double)m_nudRF3RX3RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f00030c = (double)m_nudRF3RX4RXGainMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f00030d = (double)m_nudRF1RX1RXPhaseMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f00030e = (double)m_nudRF1RX2RXPhaseMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f00030f = (double)m_nudRF1RX3RXPhaseMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000310 = (double)m_nudRF1RX4RXPhaseMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000311 = (double)m_nudRF2RX1RXPhaseMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000312 = (double)m_nudRF2RX2RXPhaseMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000313 = (double)m_nudRF2RX3RXPhaseMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000314 = (double)m_nudRF2RX4RXPhaseMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000315 = (double)m_nudRF3RX1RXPhaseMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000316 = (double)m_nudRF3RX2RXPhaseMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000317 = (double)m_nudRF3RX3RXPhaseMismatchOffVal.Value;
				m_MonRXGainPhaseConfigParameters.f000318 = (double)m_nudRF3RX4RXPhaseMismatchOffVal.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateAnaRXMonConfigData(RootObject jobject, int p1)
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
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.isConfigured == 0)
					{
						string msg2 = string.Format("Missing RX gain and phase monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg2);
					}
					else
					{
						m_nudRXGainPhaseMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.profileIndx;
						m_chbRF1RXGainPhaseMonBitMask.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rfFreqBitMask, 16) & 1) == 1);
						m_chbRF2RXGainPhaseMonBitMask.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rfFreqBitMask, 16) & 2) >> 1 == 1);
						m_chbRF3RXGainPhaseMonBitMask.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rfFreqBitMask, 16) & 4) >> 2 == 1);
						m_cboRxGainPhaseMonTxSelect.SelectedIndex = jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.txSel;
						m_nudRXGainPhaseAbsErrThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainAbsThresh;
						m_nudRXGainMismatchThresholds.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchErrThresh;
						m_nudRXGainFlatnessErrThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainFlatnessErrThresh;
						m_nudRXPhaseMismatchThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchErrThresh;
						m_nudRF1RX1RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[0][0] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[0][1]);
						m_nudRF1RX2RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[0][2] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[0][3]);
						m_nudRF1RX3RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[0][4] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[0][5]);
						m_nudRF1RX4RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[0][6] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[0][7]);
						m_nudRF2RX1RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[1][0] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[1][1]);
						m_nudRF2RX2RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[1][2] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[1][3]);
						m_nudRF2RX3RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[1][4] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[1][5]);
						m_nudRF2RX4RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[1][6] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[1][7]);
						m_nudRF3RX1RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[2][0] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[2][1]);
						m_nudRF3RX2RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[2][2] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[2][3]);
						m_nudRF3RX3RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[2][4] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[2][5]);
						m_nudRF3RX4RXGainMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[2][6] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainMismatchOffsetVal[2][7]);
						m_nudRF1RX1RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[0][0] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[0][1]);
						m_nudRF1RX2RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[0][2] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[0][3]);
						m_nudRF1RX3RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[0][4] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[0][5]);
						m_nudRF1RX4RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[0][6] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[0][7]);
						m_nudRF2RX1RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[1][0] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[1][1]);
						m_nudRF2RX2RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[1][2] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[1][3]);
						m_nudRF2RX3RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[1][4] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[1][5]);
						m_nudRF2RX4RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[1][6] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[1][7]);
						m_nudRF3RX1RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[2][0] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[2][1]);
						m_nudRF3RX2RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[2][2] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[2][3]);
						m_nudRF3RX3RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[2][4] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[2][5]);
						m_nudRF3RX4RXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[2][6] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlRxGainPhaseMonConf_t.rxGainPhaseMismatchOffsetVal[2][7]);
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlRxNoiseMonConf_t.isConfigured == 0)
					{
						string msg3 = string.Format("Missing RX noise monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg3);
					}
					else
					{
						m_nudRXNoiseMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxNoiseMonConf_t.profileIndx;
						m_chbRF1RXNoiseMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlRxNoiseMonConf_t.rfFreqBitMask, 16) & 1) == 1);
						m_chbRF2RXNoiseMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlRxNoiseMonConf_t.rfFreqBitMask, 16) & 2) >> 1 == 1);
						m_chbRF3RXNoiseMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlRxNoiseMonConf_t.rfFreqBitMask, 16) & 4) >> 2 == 1);
						m_nudRxNoiseFigureReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxNoiseMonConf_t.reportMode;
						m_nudRXNoiseFigureThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlRxNoiseMonConf_t.noiseThresh;
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlRxIfStageMonConf_t.isConfigured == 0)
					{
						string msg4 = string.Format("Missing RX IF stage monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg4);
					}
					else
					{
						m_nudRXIFStageMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxIfStageMonConf_t.profileIndx;
						m_nudRxIFStageReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxIfStageMonConf_t.reportMode;
						m_nudRxIFStageHPFCuttoffFreqErrThreshold.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxIfStageMonConf_t.hpfCutoffErrThresh;
						m_nudRxIFStageLPFCuttoffFreqErrThreshold.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxIfStageMonConf_t.lpfCutoffErrThresh;
						m_nudRxIFStageIFAGainErrThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlRxIfStageMonConf_t.ifaGainErrThresh;
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlRxSatMonConf_t.isConfigured == 0)
					{
						string msg5 = string.Format("Missing RX saturation monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg5);
					}
					else
					{
						m_nudRxSatDetectorMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxSatMonConf_t.profileIndx;
						if (jobject.mmWaveDevices[p1].monitoringConfig.rlRxSatMonConf_t.satMonSel == 1)
						{
							m_cboRxSatDetectorSatMonSelect.SelectedIndex = 0;
						}
						else if (jobject.mmWaveDevices[p1].monitoringConfig.rlRxSatMonConf_t.satMonSel == 3)
						{
							m_cboRxSatDetectorSatMonSelect.SelectedIndex = 1;
						}
						m_nudRxSatDetectorMonPriTimeSliceDuration.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlRxSatMonConf_t.primarySliceDuration;
						m_nudRxSatDetectorMonSatMonNumSlice.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxSatMonConf_t.numSlices;
						m_nudRxSatDetectorMonSatMonRxChannelMask.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxSatMonConf_t.rxChannelMask;
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlSigImgMonConf_t.isConfigured == 0)
					{
						string msg6 = string.Format("Missing Signal and image band energy monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg6);
					}
					else
					{
						m_nudSigImgMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlSigImgMonConf_t.profileIndx;
						m_nudSigImgMonPriTimeSliceNumSamples.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlSigImgMonConf_t.timeSliceNumSamples;
						m_nudSigImgMonNumSlice.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlSigImgMonConf_t.numSlices;
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlRxMixInPwrMonConf_t.isConfigured == 0)
					{
						string msg7 = string.Format("Missing RX mixer input power monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg7);
					}
					else
					{
						m_nudRxMixerIpPowMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxMixInPwrMonConf_t.reportMode;
						m_nudRxMixerIpPowMonProfielIdnex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlRxMixInPwrMonConf_t.profileIndx;
						m_chbRxMixerIpPowMonTx1Ena.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlRxMixInPwrMonConf_t.txEnable, 16) & 1) == 1);
						m_chbRxMixerIpPowMonTx2Ena.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlRxMixInPwrMonConf_t.txEnable, 16) & 2) >> 1 == 1);
						m_chbRxMixerIpPowMonTx3Ena.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlRxMixInPwrMonConf_t.txEnable, 16) & 4) >> 2 == 1);
						m_nudRxMixerIpPowMonMinThresholds.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlRxMixInPwrMonConf_t.thresholds, 16) & 1);
						m_nudRxMixerIpPowMonMaxThresholds.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlRxMixInPwrMonConf_t.thresholds, 16) & 2) >> 1;
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlTempMonConf_t.isConfigured == 0)
					{
						string msg8 = string.Format("Missing Temperature sensor monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg8);
					}
					else
					{
						m_nudTempMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlTempMonConf_t.reportMode;
						m_nudTempMonAnaTempThreshMin.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlTempMonConf_t.anaTempThreshMin;
						m_nudTempMonAnaTempThreshMax.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlTempMonConf_t.anaTempThreshMax;
						m_nudTempMonDigTempThreshMin.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlTempMonConf_t.digTempThreshMin;
						m_nudTempMonDigTempThreshMax.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlTempMonConf_t.digTempThreshMax;
						m_nudTempMonTempDiffThresh.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlTempMonConf_t.tempDiffThresh;
					}
					if (jobject.mmWaveDevices[p1].monitoringConfig.rlSynthFreqMonConf_t.isConfigured == 0)
					{
						string msg9 = string.Format("Missing Synthesizer frequency monitoring Configuration for Device {0}. Skipping..", p1);
						GlobalRef.LuaWrapper.PrintWarning(msg9);
					}
					else
					{
						m_nudSynthFrequencyProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlSynthFreqMonConf_t.profileIndx;
						m_nudSynthFrequencyMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlSynthFreqMonConf_t.reportMode;
						m_nudSynthFrequencyMonFreqErrorThreshold.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlSynthFreqMonConf_t.freqErrThresh;
						m_nudSynthFrequencyMonStartTime.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlSynthFreqMonConf_t.monStartTime;
					}
				}
				result = true;
			}
			catch
			{
				string msg10 = string.Format("Rx Monitoring Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg10);
				result = false;
			}
			return result;
		}

		public bool UpdateRxGainPhaseMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRxGainPhaseMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudRXGainPhaseMonProfileIndex.Value = m_MonRXGainPhaseConfigParameters.ProfileIndex;
				m_chbRF1RXGainPhaseMonBitMask.Checked = (m_MonRXGainPhaseConfigParameters.RF1FreqBitMask == '\u0001');
				m_chbRF2RXGainPhaseMonBitMask.Checked = (m_MonRXGainPhaseConfigParameters.RF2FreqBitMask == '\u0001');
				m_chbRF3RXGainPhaseMonBitMask.Checked = (m_MonRXGainPhaseConfigParameters.RF3FreqBitMask == '\u0001');
				m_nudRXGainPhaseReprotingMode.Value = m_MonRXGainPhaseConfigParameters.ReportingMode;
				m_cboRxGainPhaseMonTxSelect.SelectedIndex = (int)m_MonRXGainPhaseConfigParameters.TxSelect;
				m_nudRXGainPhaseAbsErrThreshold.Value = (decimal)m_MonRXGainPhaseConfigParameters.RxGainAbsoluteErrorThreshold;
				m_nudRXGainMismatchThresholds.Value = (decimal)m_MonRXGainPhaseConfigParameters.RxGainMismatchThreshold;
				m_nudRXGainFlatnessErrThreshold.Value = (decimal)m_MonRXGainPhaseConfigParameters.RxGainFlatnessErrorThreshold;
				m_nudRXPhaseMismatchThreshold.Value = m_MonRXGainPhaseConfigParameters.RxPhaseMismatchThreshold;
				m_nudRF1RX1RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000301;
				m_nudRF1RX2RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000302;
				m_nudRF1RX3RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000303;
				m_nudRF1RX4RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000304;
				m_nudRF2RX1RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000305;
				m_nudRF2RX2RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000306;
				m_nudRF2RX3RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000307;
				m_nudRF2RX4RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000308;
				m_nudRF3RX1RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000309;
				m_nudRF3RX2RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f00030a;
				m_nudRF3RX3RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f00030b;
				m_nudRF3RX4RXGainMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f00030c;
				m_nudRF1RX1RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f00030d;
				m_nudRF1RX2RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f00030e;
				m_nudRF1RX3RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f00030f;
				m_nudRF1RX4RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000310;
				m_nudRF2RX1RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000311;
				m_nudRF2RX2RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000312;
				m_nudRF2RX3RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000313;
				m_nudRF2RX4RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000314;
				m_nudRF3RX1RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000315;
				m_nudRF3RX2RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000316;
				m_nudRF3RX3RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000317;
				m_nudRF3RX4RXPhaseMismatchOffVal.Value = (decimal)m_MonRXGainPhaseConfigParameters.f000318;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeRxGainPhaseMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, uint RF1Rx1Rx2GainValue, uint RF1Rx3Rx4GainValue, uint RF2Rx1Rx2GainValue, uint RF2Rx3Rx4GainValue, uint RF3Rx1Rx2GainValue, uint RF3Rx3Rx4GainValue, uint RF1Rx1Rx2PhaseValue, uint RF1Rx3Rx4PhaseValue, uint RF2Rx1Rx2PhaseValue, uint RF2Rx3Rx4PhaseValue, uint RF3Rx1Rx2PhaseValue, uint RF3Rx3Rx4PhaseValue, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				delegate010f method = new delegate010f(CascadeRxGainPhaseMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					ProfileIndex,
					RF1Rx1Rx2GainValue,
					RF1Rx3Rx4GainValue,
					RF2Rx1Rx2GainValue,
					RF2Rx3Rx4GainValue,
					RF3Rx1Rx2GainValue,
					RF3Rx3Rx4GainValue,
					RF1Rx1Rx2PhaseValue,
					RF1Rx3Rx4PhaseValue,
					RF2Rx1Rx2PhaseValue,
					RF2Rx3Rx4PhaseValue,
					RF3Rx1Rx2PhaseValue,
					RF3Rx3Rx4PhaseValue,
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
				string empty11 = string.Empty;
				string empty12 = string.Empty;
				string empty13 = string.Empty;
				string empty14 = string.Empty;
				string empty15 = string.Empty;
				string empty16 = string.Empty;
				string empty17 = string.Empty;
				string empty18 = string.Empty;
				string empty19 = string.Empty;
				string empty20 = string.Empty;
				string empty21 = string.Empty;
				string empty22 = string.Empty;
				string empty23 = string.Empty;
				string empty24 = string.Empty;
				string empty25 = string.Empty;
				string empty26 = string.Empty;
				string empty27 = string.Empty;
				string empty28 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(ProfileIndex);
						ushort num = (ushort)(RF1Rx1Rx2GainValue & 65535U);
						if (num > 32767)
						{
							Convert.ToString((double)((short)((int)num - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num / 10.0);
						}
						ushort num2 = (ushort)(RF1Rx1Rx2GainValue >> 16);
						if (num2 > 32767)
						{
							Convert.ToString((double)((short)((int)num2 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num2 / 10.0);
						}
						ushort num3 = (ushort)(RF1Rx3Rx4GainValue & 65535U);
						if (num3 > 32767)
						{
							Convert.ToString((double)((short)((int)num3 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num3 / 10.0);
						}
						ushort num4 = (ushort)(RF1Rx3Rx4GainValue >> 16);
						if (num4 > 32767)
						{
							Convert.ToString((double)((short)((int)num4 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num4 / 10.0);
						}
						ushort num5 = (ushort)(RF2Rx1Rx2GainValue & 65535U);
						if (num5 > 32767)
						{
							Convert.ToString((double)((short)((int)num5 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num5 / 10.0);
						}
						ushort num6 = (ushort)(RF2Rx1Rx2GainValue >> 16);
						if (num6 > 32767)
						{
							Convert.ToString((double)((short)((int)num6 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num6 / 10.0);
						}
						ushort num7 = (ushort)(RF2Rx3Rx4GainValue & 65535U);
						if (num7 > 32767)
						{
							Convert.ToString((double)((short)((int)num7 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num7 / 10.0);
						}
						ushort num8 = (ushort)(RF2Rx3Rx4GainValue >> 16);
						if (num8 > 32767)
						{
							Convert.ToString((double)((short)((int)num8 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num8 / 10.0);
						}
						ushort num9 = (ushort)(RF3Rx1Rx2GainValue & 65535U);
						if (num9 > 32767)
						{
							Convert.ToString((double)((short)((int)num9 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num9 / 10.0);
						}
						ushort num10 = (ushort)(RF3Rx1Rx2GainValue >> 16);
						if (num10 > 32767)
						{
							Convert.ToString((double)((short)((int)num10 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num10 / 10.0);
						}
						ushort num11 = (ushort)(RF3Rx3Rx4GainValue & 65535U);
						if (num11 > 32767)
						{
							Convert.ToString((double)((short)((int)num11 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num11 / 10.0);
						}
						ushort num12 = (ushort)(RF3Rx3Rx4GainValue >> 16);
						if (num12 > 32767)
						{
							Convert.ToString((double)((short)((int)num12 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num12 / 10.0);
						}
						ushort num13 = (ushort)(RF1Rx1Rx2PhaseValue & 65535U);
						if (num13 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num13 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num13 * 360) / 65536.0, 2));
						}
						ushort num14 = (ushort)(RF1Rx1Rx2PhaseValue >> 16);
						if (num14 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num14 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num14 * 360) / 65536.0, 2));
						}
						ushort num15 = (ushort)(RF1Rx3Rx4PhaseValue & 65535U);
						if (num15 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num15 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num15 * 360) / 65536.0, 2));
						}
						ushort num16 = (ushort)(RF1Rx3Rx4PhaseValue >> 16);
						if (num16 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num16 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num16 * 360) / 65536.0, 2));
						}
						ushort num17 = (ushort)(RF2Rx1Rx2PhaseValue & 65535U);
						if (num17 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num17 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num17 * 360) / 65536.0, 2));
						}
						ushort num18 = (ushort)(RF2Rx1Rx2PhaseValue >> 16);
						if (num18 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num18 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num18 * 360) / 65536.0, 2));
						}
						ushort num19 = (ushort)(RF2Rx3Rx4PhaseValue & 65535U);
						if (num19 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num19 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num19 * 360) / 65536.0, 2));
						}
						ushort num20 = (ushort)(RF2Rx3Rx4PhaseValue >> 16);
						if (num20 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num20 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num20 * 360) / 65536.0, 2));
						}
						ushort num21 = (ushort)(RF3Rx1Rx2PhaseValue & 65535U);
						if (num21 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num21 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num21 * 360) / 65536.0, 2));
						}
						ushort num22 = (ushort)(RF3Rx1Rx2PhaseValue >> 16);
						if (num22 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num22 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num22 * 360) / 65536.0, 2));
						}
						ushort num23 = (ushort)(RF3Rx3Rx4PhaseValue & 65535U);
						if (num23 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num23 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num23 * 360) / 65536.0, 2));
						}
						ushort num24 = (ushort)(RF3Rx3Rx4PhaseValue >> 16);
						if (num24 > 32767)
						{
							Convert.ToString(Math.Round((double)((ushort)((int)num24 - 65536) * 360) / 65536.0, 2));
						}
						else
						{
							Convert.ToString(Math.Round((double)(num24 * 360) / 65536.0, 2));
						}
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(ProfileIndex);
					ushort num25 = (ushort)(RF1Rx1Rx2GainValue & 65535U);
					if (num25 > 32767)
					{
						Convert.ToString((double)((short)((int)num25 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num25 / 10.0);
					}
					ushort num26 = (ushort)(RF1Rx1Rx2GainValue >> 16);
					if (num26 > 32767)
					{
						Convert.ToString((double)((short)((int)num26 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num26 / 10.0);
					}
					ushort num27 = (ushort)(RF1Rx3Rx4GainValue & 65535U);
					if (num27 > 32767)
					{
						Convert.ToString((double)((short)((int)num27 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num27 / 10.0);
					}
					ushort num28 = (ushort)(RF1Rx3Rx4GainValue >> 16);
					if (num28 > 32767)
					{
						Convert.ToString((double)((short)((int)num28 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num28 / 10.0);
					}
					ushort num29 = (ushort)(RF2Rx1Rx2GainValue & 65535U);
					if (num29 > 32767)
					{
						Convert.ToString((double)((short)((int)num29 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num29 / 10.0);
					}
					ushort num30 = (ushort)(RF2Rx1Rx2GainValue >> 16);
					if (num30 > 32767)
					{
						Convert.ToString((double)((short)((int)num30 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num30 / 10.0);
					}
					ushort num31 = (ushort)(RF2Rx3Rx4GainValue & 65535U);
					if (num31 > 32767)
					{
						Convert.ToString((double)((short)((int)num31 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num31 / 10.0);
					}
					ushort num32 = (ushort)(RF2Rx3Rx4GainValue >> 16);
					if (num32 > 32767)
					{
						Convert.ToString((double)((short)((int)num32 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num32 / 10.0);
					}
					ushort num33 = (ushort)(RF3Rx1Rx2GainValue & 65535U);
					if (num33 > 32767)
					{
						Convert.ToString((double)((short)((int)num33 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num33 / 10.0);
					}
					ushort num34 = (ushort)(RF3Rx1Rx2GainValue >> 16);
					if (num34 > 32767)
					{
						Convert.ToString((double)((short)((int)num34 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num34 / 10.0);
					}
					ushort num35 = (ushort)(RF3Rx3Rx4GainValue & 65535U);
					if (num35 > 32767)
					{
						Convert.ToString((double)((short)((int)num35 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num35 / 10.0);
					}
					ushort num36 = (ushort)(RF3Rx3Rx4GainValue >> 16);
					if (num36 > 32767)
					{
						Convert.ToString((double)((short)((int)num36 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num36 / 10.0);
					}
					ushort num37 = (ushort)(RF1Rx1Rx2PhaseValue & 65535U);
					if (num37 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num37 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num37 * 360) / 65536.0, 2));
					}
					ushort num38 = (ushort)(RF1Rx1Rx2PhaseValue >> 16);
					if (num38 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num38 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num38 * 360) / 65536.0, 2));
					}
					ushort num39 = (ushort)(RF1Rx3Rx4PhaseValue & 65535U);
					if (num39 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num39 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num39 * 360) / 65536.0, 2));
					}
					ushort num40 = (ushort)(RF1Rx3Rx4PhaseValue >> 16);
					if (num40 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num40 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num40 * 360) / 65536.0, 2));
					}
					ushort num41 = (ushort)(RF2Rx1Rx2PhaseValue & 65535U);
					if (num41 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num41 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num41 * 360) / 65536.0, 2));
					}
					ushort num42 = (ushort)(RF2Rx1Rx2PhaseValue >> 16);
					if (num42 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num42 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num42 * 360) / 65536.0, 2));
					}
					ushort num43 = (ushort)(RF2Rx3Rx4PhaseValue & 65535U);
					if (num43 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num43 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num43 * 360) / 65536.0, 2));
					}
					ushort num44 = (ushort)(RF2Rx3Rx4PhaseValue >> 16);
					if (num44 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num44 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num44 * 360) / 65536.0, 2));
					}
					ushort num45 = (ushort)(RF3Rx1Rx2PhaseValue & 65535U);
					if (num45 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num45 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num45 * 360) / 65536.0, 2));
					}
					ushort num46 = (ushort)(RF3Rx1Rx2PhaseValue >> 16);
					if (num46 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num46 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num46 * 360) / 65536.0, 2));
					}
					ushort num47 = (ushort)(RF3Rx3Rx4PhaseValue & 65535U);
					if (num47 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num47 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num47 * 360) / 65536.0, 2));
					}
					ushort num48 = (ushort)(RF3Rx3Rx4PhaseValue >> 16);
					if (num48 > 32767)
					{
						Convert.ToString(Math.Round((double)((ushort)((int)num48 - 65536) * 360) / 65536.0, 2));
					}
					else
					{
						Convert.ToString(Math.Round((double)(num48 * 360) / 65536.0, 2));
					}
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetRXNoiseFigureMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetRXNoiseFigureMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRXNoiseFigureMonConfig()
		{
			iSetRXNoiseFigureMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetRXNoiseFigureMonConfigAsync()
		{
			new del_v_v(iSetRXNoiseFigureMonConfig).BeginInvoke(null, null);
		}

		private void m_btnRXNoiseMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetRXNoiseFigureMonConfigAsync();
		}

		public bool UpdateRXNoiseFigureMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRXNoiseFigureMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonRXNoiseFigureConfigParameters.ProfileIndex = (char)m_nudRXNoiseMonProfileIndex.Value;
				m_MonRXNoiseFigureConfigParameters.RF1FreqBitMask = (m_chbRF1RXNoiseMon.Checked ? '\u0001' : '\0');
				m_MonRXNoiseFigureConfigParameters.RF2FreqBitMask = (m_chbRF2RXNoiseMon.Checked ? '\u0001' : '\0');
				m_MonRXNoiseFigureConfigParameters.RF3FreqBitMask = (m_chbRF3RXNoiseMon.Checked ? '\u0001' : '\0');
				m_MonRXNoiseFigureConfigParameters.ReportingMode = (char)m_nudRxNoiseFigureReportingMode.Value;
				m_MonRXNoiseFigureConfigParameters.RXNoiseFigureThreshold = (double)m_nudRXNoiseFigureThreshold.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRXNoiseFigureMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRXNoiseFigureMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudRXNoiseMonProfileIndex.Value = m_MonRXNoiseFigureConfigParameters.ProfileIndex;
				m_chbRF1RXNoiseMon.Checked = (m_MonRXNoiseFigureConfigParameters.RF1FreqBitMask == '\u0001');
				m_chbRF2RXNoiseMon.Checked = (m_MonRXNoiseFigureConfigParameters.RF2FreqBitMask == '\u0001');
				m_chbRF3RXNoiseMon.Checked = (m_MonRXNoiseFigureConfigParameters.RF3FreqBitMask == '\u0001');
				m_nudRxNoiseFigureReportingMode.Value = m_MonRXNoiseFigureConfigParameters.ReportingMode;
				m_nudRXNoiseFigureThreshold.Value = (decimal)m_MonRXNoiseFigureConfigParameters.RXNoiseFigureThreshold;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeRxNoiseFigureMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, uint RF1Rx1Rx2PowerValue, uint RF1Rx3Rx4PowerValue, uint RF2Rx1Rx2PowerValue, uint RF2Rx3Rx4PowerValue, uint RF3Rx1Rx2PowerValue, uint RF3Rx3Rx4PowerValue, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				delegate0102 method = new delegate0102(CascadeRxNoiseFigureMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					ProfileIndex,
					RF1Rx1Rx2PowerValue,
					RF1Rx3Rx4PowerValue,
					RF2Rx1Rx2PowerValue,
					RF2Rx3Rx4PowerValue,
					RF3Rx1Rx2PowerValue,
					RF3Rx3Rx4PowerValue,
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
				string empty11 = string.Empty;
				string empty12 = string.Empty;
				string empty13 = string.Empty;
				string empty14 = string.Empty;
				string empty15 = string.Empty;
				string empty16 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(ProfileIndex);
						ushort num = (ushort)(RF1Rx1Rx2PowerValue & 65535U);
						if (num > 32767)
						{
							Convert.ToString((double)((short)((int)num - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num / 10.0);
						}
						ushort num2 = (ushort)(RF1Rx1Rx2PowerValue >> 16);
						if (num2 > 32767)
						{
							Convert.ToString((double)((short)((int)num2 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num2 / 10.0);
						}
						ushort num3 = (ushort)(RF1Rx3Rx4PowerValue & 65535U);
						if (num3 > 32767)
						{
							Convert.ToString((double)((short)((int)num3 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num3 / 10.0);
						}
						ushort num4 = (ushort)(RF1Rx3Rx4PowerValue >> 16);
						if (num4 > 32767)
						{
							Convert.ToString((double)((short)((int)num4 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num4 / 10.0);
						}
						ushort num5 = (ushort)(RF2Rx1Rx2PowerValue & 65535U);
						if (num5 > 32767)
						{
							Convert.ToString((double)((short)((int)num5 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num5 / 10.0);
						}
						ushort num6 = (ushort)(RF2Rx1Rx2PowerValue >> 16);
						if (num6 > 32767)
						{
							Convert.ToString((double)((short)((int)num6 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num6 / 10.0);
						}
						ushort num7 = (ushort)(RF2Rx3Rx4PowerValue & 65535U);
						if (num7 > 32767)
						{
							Convert.ToString((double)((short)((int)num7 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num7 / 10.0);
						}
						ushort num8 = (ushort)(RF2Rx3Rx4PowerValue >> 16);
						if (num8 > 32767)
						{
							Convert.ToString((double)((short)((int)num8 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num8 / 10.0);
						}
						ushort num9 = (ushort)(RF3Rx1Rx2PowerValue & 65535U);
						if (num9 > 32767)
						{
							Convert.ToString((double)((short)((int)num9 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num9 / 10.0);
						}
						ushort num10 = (ushort)(RF3Rx1Rx2PowerValue >> 16);
						if (num10 > 32767)
						{
							Convert.ToString((double)((short)((int)num10 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num10 / 10.0);
						}
						ushort num11 = (ushort)(RF3Rx3Rx4PowerValue & 65535U);
						if (num11 > 32767)
						{
							Convert.ToString((double)((short)((int)num11 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num11 / 10.0);
						}
						ushort num12 = (ushort)(RF3Rx3Rx4PowerValue >> 16);
						if (num12 > 32767)
						{
							Convert.ToString((double)((short)((int)num12 - 65536)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num12 / 10.0);
						}
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(ProfileIndex);
					ushort num13 = (ushort)(RF1Rx1Rx2PowerValue & 65535U);
					if (num13 > 32767)
					{
						Convert.ToString((double)((short)((int)num13 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num13 / 10.0);
					}
					ushort num14 = (ushort)(RF1Rx1Rx2PowerValue >> 16);
					if (num14 > 32767)
					{
						Convert.ToString((double)((short)((int)num14 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num14 / 10.0);
					}
					ushort num15 = (ushort)(RF1Rx3Rx4PowerValue & 65535U);
					if (num15 > 32767)
					{
						Convert.ToString((double)((short)((int)num15 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num15 / 10.0);
					}
					ushort num16 = (ushort)(RF1Rx3Rx4PowerValue >> 16);
					if (num16 > 32767)
					{
						Convert.ToString((double)((short)((int)num16 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num16 / 10.0);
					}
					ushort num17 = (ushort)(RF2Rx1Rx2PowerValue & 65535U);
					if (num17 > 32767)
					{
						Convert.ToString((double)((short)((int)num17 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num17 / 10.0);
					}
					ushort num18 = (ushort)(RF2Rx1Rx2PowerValue >> 16);
					if (num18 > 32767)
					{
						Convert.ToString((double)((short)((int)num18 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num18 / 10.0);
					}
					ushort num19 = (ushort)(RF2Rx3Rx4PowerValue & 65535U);
					if (num19 > 32767)
					{
						Convert.ToString((double)((short)((int)num19 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num19 / 10.0);
					}
					ushort num20 = (ushort)(RF2Rx3Rx4PowerValue >> 16);
					if (num20 > 32767)
					{
						Convert.ToString((double)((short)((int)num20 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num20 / 10.0);
					}
					ushort num21 = (ushort)(RF3Rx1Rx2PowerValue & 65535U);
					if (num21 > 32767)
					{
						Convert.ToString((double)((short)((int)num21 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num21 / 10.0);
					}
					ushort num22 = (ushort)(RF3Rx1Rx2PowerValue >> 16);
					if (num22 > 32767)
					{
						Convert.ToString((double)((short)((int)num22 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num22 / 10.0);
					}
					ushort num23 = (ushort)(RF3Rx3Rx4PowerValue & 65535U);
					if (num23 > 32767)
					{
						Convert.ToString((double)((short)((int)num23 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num23 / 10.0);
					}
					ushort num24 = (ushort)(RF3Rx3Rx4PowerValue >> 16);
					if (num24 > 32767)
					{
						Convert.ToString((double)((short)((int)num24 - 65536)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num24 / 10.0);
					}
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetRXIFStageMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetRXIFStageMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRXIFStageMonConfig()
		{
			iSetRXIFStageMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetRXIFStageMonConfigAsync()
		{
			new del_v_v(iSetRXIFStageMonConfig).BeginInvoke(null, null);
		}

		private void m_btnRXIFStageMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetRXIFStageMonConfigAsync();
		}

		public bool UpdateRXIFStageMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRXIFStageMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonRXIFStageConfigParameters.ProfileIndex = (char)m_nudRXIFStageMonProfileIndex.Value;
				m_MonRXIFStageConfigParameters.ReportingMode = (char)m_nudRxIFStageReportingMode.Value;
				m_MonRXIFStageConfigParameters.HPFCutofFreqErrorThreshold = (ushort)m_nudRxIFStageHPFCuttoffFreqErrThreshold.Value;
				m_MonRXIFStageConfigParameters.LPFCutofFreqErrorThreshold = (ushort)m_nudRxIFStageLPFCuttoffFreqErrThreshold.Value;
				m_MonRXIFStageConfigParameters.IFAGainErrorThreshold = (double)m_nudRxIFStageIFAGainErrThreshold.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRXIFStageMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRXIFStageMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudRXIFStageMonProfileIndex.Value = m_MonRXIFStageConfigParameters.ProfileIndex;
				m_nudRxIFStageReportingMode.Value = m_MonRXIFStageConfigParameters.ReportingMode;
				m_nudRxIFStageHPFCuttoffFreqErrThreshold.Value = m_MonRXIFStageConfigParameters.HPFCutofFreqErrorThreshold;
				m_nudRxIFStageLPFCuttoffFreqErrThreshold.Value = m_MonRXIFStageConfigParameters.LPFCutofFreqErrorThreshold;
				m_nudRxIFStageIFAGainErrThreshold.Value = (decimal)m_MonRXIFStageConfigParameters.IFAGainErrorThreshold;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeRXIFStageMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, int Rx1Rx2Rx3Rx4IChannnelHPFCuttoffFreqErrorVal, int Rx1Rx2Rx3Rx4QChannnelHPFCuttoffFreqErrorVal, int Rx1Rx2Rx3Rx4IChannnelLPFCuttoffFreqErrorVal, int Rx1Rx2Rx3Rx4QChannnelLPFCuttoffFreqErrorVal, int Rx1Rx2Rx3Rx4IChannnelIFAGainErrorVal, int Rx1Rx2Rx3Rx4QChannnelIFAGainErrorVal, uint p10, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				delegate0101 method = new delegate0101(CascadeRXIFStageMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					ProfileIndex,
					Rx1Rx2Rx3Rx4IChannnelHPFCuttoffFreqErrorVal,
					Rx1Rx2Rx3Rx4QChannnelHPFCuttoffFreqErrorVal,
					Rx1Rx2Rx3Rx4IChannnelLPFCuttoffFreqErrorVal,
					Rx1Rx2Rx3Rx4QChannnelLPFCuttoffFreqErrorVal,
					Rx1Rx2Rx3Rx4IChannnelIFAGainErrorVal,
					Rx1Rx2Rx3Rx4QChannnelIFAGainErrorVal,
					p10,
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
				string empty11 = string.Empty;
				string empty12 = string.Empty;
				string empty13 = string.Empty;
				string empty14 = string.Empty;
				string empty15 = string.Empty;
				string empty16 = string.Empty;
				string empty17 = string.Empty;
				string empty18 = string.Empty;
				string empty19 = string.Empty;
				string empty20 = string.Empty;
				string empty21 = string.Empty;
				string empty22 = string.Empty;
				string empty23 = string.Empty;
				string empty24 = string.Empty;
				string empty25 = string.Empty;
				string empty26 = string.Empty;
				string empty27 = string.Empty;
				string empty28 = string.Empty;
				string empty29 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(ProfileIndex);
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelHPFCuttoffFreqErrorVal & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelHPFCuttoffFreqErrorVal >> 8 & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelHPFCuttoffFreqErrorVal >> 16 & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelHPFCuttoffFreqErrorVal >> 24 & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelHPFCuttoffFreqErrorVal & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelHPFCuttoffFreqErrorVal >> 8 & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelHPFCuttoffFreqErrorVal >> 16 & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelHPFCuttoffFreqErrorVal >> 24 & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelLPFCuttoffFreqErrorVal & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelLPFCuttoffFreqErrorVal >> 8 & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelLPFCuttoffFreqErrorVal >> 16 & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelLPFCuttoffFreqErrorVal >> 24 & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelLPFCuttoffFreqErrorVal & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelLPFCuttoffFreqErrorVal >> 8 & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelLPFCuttoffFreqErrorVal >> 16 & 255));
						Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelLPFCuttoffFreqErrorVal >> 24 & 255));
						ushort num = (ushort)(Rx1Rx2Rx3Rx4IChannnelIFAGainErrorVal & 255);
						if (num > 127)
						{
							Convert.ToString((double)((sbyte)(num - 255)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num / 10.0);
						}
						ushort num2 = (ushort)(Rx1Rx2Rx3Rx4IChannnelIFAGainErrorVal >> 8 & 255);
						if (num2 > 127)
						{
							Convert.ToString((double)((sbyte)(num2 - 255)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num2 / 10.0);
						}
						ushort num3 = (ushort)(Rx1Rx2Rx3Rx4IChannnelIFAGainErrorVal >> 16 & 255);
						if (num3 > 127)
						{
							Convert.ToString((double)((sbyte)(num3 - 255)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num3 / 10.0);
						}
						ushort num4 = (ushort)(Rx1Rx2Rx3Rx4IChannnelIFAGainErrorVal >> 24 & 255);
						if (num4 > 127)
						{
							Convert.ToString((double)((sbyte)(num4 - 255)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num4 / 10.0);
						}
						ushort num5 = (ushort)(Rx1Rx2Rx3Rx4QChannnelIFAGainErrorVal & 255);
						if (num5 > 127)
						{
							Convert.ToString((double)((sbyte)(num5 - 255)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num5 / 10.0);
						}
						ushort num6 = (ushort)(Rx1Rx2Rx3Rx4QChannnelIFAGainErrorVal >> 8 & 255);
						if (num6 > 127)
						{
							Convert.ToString((double)((sbyte)(num6 - 255)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num6 / 10.0);
						}
						ushort num7 = (ushort)(Rx1Rx2Rx3Rx4QChannnelIFAGainErrorVal >> 16 & 255);
						if (num7 > 127)
						{
							Convert.ToString((double)((sbyte)(num7 - 255)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num7 / 10.0);
						}
						ushort num8 = (ushort)(Rx1Rx2Rx3Rx4QChannnelIFAGainErrorVal >> 24 & 255);
						if (num8 > 127)
						{
							Convert.ToString((double)((sbyte)(num8 - 255)) / 10.0);
						}
						else
						{
							Convert.ToString((double)num8 / 10.0);
						}
						Convert.ToString(TimeStamp);
						ushort num9 = (ushort)(p10 & 255U);
						if (num9 > 127)
						{
							Convert.ToString((sbyte)(num9 - 255));
						}
						else
						{
							Convert.ToString(num9);
						}
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(ProfileIndex);
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelHPFCuttoffFreqErrorVal & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelHPFCuttoffFreqErrorVal >> 8 & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelHPFCuttoffFreqErrorVal >> 16 & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelHPFCuttoffFreqErrorVal >> 24 & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelHPFCuttoffFreqErrorVal & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelHPFCuttoffFreqErrorVal >> 8 & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelHPFCuttoffFreqErrorVal >> 16 & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelHPFCuttoffFreqErrorVal >> 24 & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelLPFCuttoffFreqErrorVal & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelLPFCuttoffFreqErrorVal >> 8 & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelLPFCuttoffFreqErrorVal >> 16 & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4IChannnelLPFCuttoffFreqErrorVal >> 24 & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelLPFCuttoffFreqErrorVal & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelLPFCuttoffFreqErrorVal >> 8 & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelLPFCuttoffFreqErrorVal >> 16 & 255));
					Convert.ToString((sbyte)(Rx1Rx2Rx3Rx4QChannnelLPFCuttoffFreqErrorVal >> 24 & 255));
					ushort num10 = (ushort)(Rx1Rx2Rx3Rx4IChannnelIFAGainErrorVal & 255);
					if (num10 > 127)
					{
						Convert.ToString((double)((sbyte)(num10 - 255)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num10 / 10.0);
					}
					ushort num11 = (ushort)(Rx1Rx2Rx3Rx4IChannnelIFAGainErrorVal >> 8 & 255);
					if (num11 > 127)
					{
						Convert.ToString((double)((sbyte)(num11 - 255)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num11 / 10.0);
					}
					ushort num12 = (ushort)(Rx1Rx2Rx3Rx4IChannnelIFAGainErrorVal >> 16 & 255);
					if (num12 > 127)
					{
						Convert.ToString((double)((sbyte)(num12 - 255)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num12 / 10.0);
					}
					ushort num13 = (ushort)(Rx1Rx2Rx3Rx4IChannnelIFAGainErrorVal >> 24 & 255);
					if (num13 > 127)
					{
						Convert.ToString((double)((sbyte)(num13 - 255)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num13 / 10.0);
					}
					ushort num14 = (ushort)(Rx1Rx2Rx3Rx4QChannnelIFAGainErrorVal & 255);
					if (num14 > 127)
					{
						Convert.ToString((double)((sbyte)(num14 - 255)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num14 / 10.0);
					}
					ushort num15 = (ushort)(Rx1Rx2Rx3Rx4QChannnelIFAGainErrorVal >> 8 & 255);
					if (num15 > 127)
					{
						Convert.ToString((double)((sbyte)(num15 - 255)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num15 / 10.0);
					}
					ushort num16 = (ushort)(Rx1Rx2Rx3Rx4QChannnelIFAGainErrorVal >> 16 & 255);
					if (num16 > 127)
					{
						Convert.ToString((double)((sbyte)(num16 - 255)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num16 / 10.0);
					}
					ushort num17 = (ushort)(Rx1Rx2Rx3Rx4QChannnelIFAGainErrorVal >> 24 & 255);
					if (num17 > 127)
					{
						Convert.ToString((double)((sbyte)(num17 - 255)) / 10.0);
					}
					else
					{
						Convert.ToString((double)num17 / 10.0);
					}
					Convert.ToString(TimeStamp);
					ushort num18 = (ushort)(p10 & 255U);
					if (num18 > 127)
					{
						Convert.ToString((sbyte)(num18 - 255));
					}
					else
					{
						Convert.ToString(num18);
					}
				}
			}
			return true;
		}

		private int iSetRXSaturationDetectorMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetRXSaturationDetectorMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRXSaturationDetectorMonConfig()
		{
			iSetRXSaturationDetectorMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetRXSaturationDetectorMonConfigAsync()
		{
			new del_v_v(iSetRXSaturationDetectorMonConfig).BeginInvoke(null, null);
		}

		private void m_btnRXSaturationDetectorMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetRXSaturationDetectorMonConfigAsync();
		}

		public bool UpdateRXSaturationDetectorMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRXSaturationDetectorMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonRxSaturationDetectorConfigParameters.ProfileIndex = (byte)m_nudRxSatDetectorMonProfileIndex.Value;
				if (m_cboRxSatDetectorSatMonSelect.SelectedIndex == 0)
				{
					m_MonRxSaturationDetectorConfigParameters.SatMonSelect = 1;
				}
				else if (m_cboRxSatDetectorSatMonSelect.SelectedIndex == 1)
				{
					m_MonRxSaturationDetectorConfigParameters.SatMonSelect = 3;
				}
				m_MonRxSaturationDetectorConfigParameters.SatMonPrimaryTimeSliceDuration = (double)m_nudRxSatDetectorMonPriTimeSliceDuration.Value;
				m_MonRxSaturationDetectorConfigParameters.SatMonNumSlices = (short)m_nudRxSatDetectorMonSatMonNumSlice.Value;
				m_MonRxSaturationDetectorConfigParameters.SatMonRxChannelMask = (byte)m_nudRxSatDetectorMonSatMonRxChannelMask.Value;
				m_MonRxSaturationDetectorConfigParameters.Reserved1 = (byte)m_nudRxSatDetectorMonSatReserved.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRXSaturationDetectorMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRXSaturationDetectorMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudRxSatDetectorMonProfileIndex.Value = m_MonRxSaturationDetectorConfigParameters.ProfileIndex;
				if (m_MonRxSaturationDetectorConfigParameters.SatMonSelect == 1)
				{
					m_cboRxSatDetectorSatMonSelect.SelectedIndex = 0;
				}
				else if (m_MonRxSaturationDetectorConfigParameters.SatMonSelect == 3)
				{
					m_cboRxSatDetectorSatMonSelect.SelectedIndex = 1;
				}
				m_nudRxSatDetectorMonPriTimeSliceDuration.Value = (decimal)m_MonRxSaturationDetectorConfigParameters.SatMonPrimaryTimeSliceDuration;
				m_nudRxSatDetectorMonSatMonNumSlice.Value = m_MonRxSaturationDetectorConfigParameters.SatMonNumSlices;
				m_nudRxSatDetectorMonSatMonRxChannelMask.Value = m_MonRxSaturationDetectorConfigParameters.SatMonRxChannelMask;
				m_nudRxSatDetectorMonSatReserved.Value = m_MonRxSaturationDetectorConfigParameters.Reserved1;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeRXSaturationDetectorMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_u_u_u method = new del_u_u_u_u(CascadeRXSaturationDetectorMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					TimeStamp
				});
			}
			else
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetSignalandImageMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetSignalandImageMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetSignalandImageMonConfig()
		{
			iSetSignalandImageMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetSignalandImageMonConfigAsync()
		{
			new del_v_v(iSetSignalandImageMonConfig).BeginInvoke(null, null);
		}

		private void m_btnSignalandImageMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetSignalandImageMonConfigAsync();
		}

		public bool UpdateSignalandImageMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateSignalandImageMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonSignalAndImageConfigParameters.ProfileIndex = (char)m_nudSigImgMonProfileIndex.Value;
				m_MonSignalAndImageConfigParameters.SigImGMonPriTimeSliceNumSamples = (short)m_nudSigImgMonPriTimeSliceNumSamples.Value;
				m_MonSignalAndImageConfigParameters.SigImGMonNumSlices = (char)m_nudSigImgMonNumSlice.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateSignalandImageMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateSignalandImageMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudSigImgMonProfileIndex.Value = m_MonSignalAndImageConfigParameters.ProfileIndex;
				m_nudSigImgMonPriTimeSliceNumSamples.Value = m_MonSignalAndImageConfigParameters.SigImGMonPriTimeSliceNumSamples;
				m_nudSigImgMonNumSlice.Value = m_MonSignalAndImageConfigParameters.SigImGMonNumSlices;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetTemperatureMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetTemperatureMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetTemperatureMonConfig()
		{
			iSetTemperatureMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetTemperatureMonConfigAsync()
		{
			new del_v_v(iSetTemperatureMonConfig).BeginInvoke(null, null);
		}

		private void m_btnTemperatureMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetTemperatureMonConfigAsync();
		}

		public bool UpdateTemperatureMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTemperatureMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonTemperatureConfigParameters.ReportingMode = (char)m_nudTempMonReportingMode.Value;
				m_MonTemperatureConfigParameters.AnaTempThreshMin = (short)m_nudTempMonAnaTempThreshMin.Value;
				m_MonTemperatureConfigParameters.AnaTempThreshMax = (short)m_nudTempMonAnaTempThreshMax.Value;
				m_MonTemperatureConfigParameters.DigTempThreshMin = (short)m_nudTempMonDigTempThreshMin.Value;
				m_MonTemperatureConfigParameters.DigTempThreshMax = (short)m_nudTempMonDigTempThreshMax.Value;
				m_MonTemperatureConfigParameters.TempDiffThresh = (short)m_nudTempMonTempDiffThresh.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateTemperatureMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTemperatureMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudTempMonReportingMode.Value = m_MonTemperatureConfigParameters.ReportingMode;
				m_nudTempMonAnaTempThreshMin.Value = m_MonTemperatureConfigParameters.AnaTempThreshMin;
				m_nudTempMonAnaTempThreshMax.Value = m_MonTemperatureConfigParameters.AnaTempThreshMax;
				m_nudTempMonDigTempThreshMin.Value = m_MonTemperatureConfigParameters.DigTempThreshMin;
				m_nudTempMonDigTempThreshMax.Value = m_MonTemperatureConfigParameters.DigTempThreshMax;
				m_nudTempMonTempDiffThresh.Value = m_MonTemperatureConfigParameters.TempDiffThresh;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeTemperatureMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, short Rx1TempValue, short Rx2TempValue, short Rx3TempValue, short Rx4TempValue, short Tx1TempValue, short Tx2TempValue, short Tx3TempValue, short PMTempValue, short Dig1TempValue, short Dig2TempValue, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				delegate0110 method = new delegate0110(CascadeTemperatureMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					Rx1TempValue,
					Rx2TempValue,
					Rx3TempValue,
					Rx4TempValue,
					Tx1TempValue,
					Tx2TempValue,
					Tx3TempValue,
					PMTempValue,
					Dig1TempValue,
					Dig2TempValue,
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
				string empty11 = string.Empty;
				string empty12 = string.Empty;
				string empty13 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString(Rx1TempValue);
						Convert.ToString(Rx2TempValue);
						Convert.ToString(Rx3TempValue);
						Convert.ToString(Rx4TempValue);
						Convert.ToString(Tx1TempValue);
						Convert.ToString(Tx2TempValue);
						Convert.ToString(Tx3TempValue);
						Convert.ToString(PMTempValue);
						Convert.ToString(Dig1TempValue);
						Convert.ToString(Dig2TempValue);
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(Rx1TempValue);
					Convert.ToString(Rx2TempValue);
					Convert.ToString(Rx3TempValue);
					Convert.ToString(Rx4TempValue);
					Convert.ToString(Tx1TempValue);
					Convert.ToString(Tx2TempValue);
					Convert.ToString(Tx3TempValue);
					Convert.ToString(PMTempValue);
					Convert.ToString(Dig1TempValue);
					Convert.ToString(Dig2TempValue);
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetSynthFrequencyMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetSynthFrequencyMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetSynthFrequencyMonConfig()
		{
			iSetSynthFrequencyMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetSynthFrequencyMonConfigAsync()
		{
			new del_v_v(iSetSynthFrequencyMonConfig).BeginInvoke(null, null);
		}

		private void m_btnSynthFrequencyMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetSynthFrequencyMonConfigAsync();
		}

		public bool UpdateSynthFrequencyMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateSynthFrequencyMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonSynthFrequencyConfigParameters.ProfileIndex = (char)m_nudSynthFrequencyProfileIndex.Value;
				m_MonSynthFrequencyConfigParameters.ReportingMode = (char)m_nudSynthFrequencyMonReportingMode.Value;
				m_MonSynthFrequencyConfigParameters.FreqErrorThreshold = (ushort)m_nudSynthFrequencyMonFreqErrorThreshold.Value;
				m_MonSynthFrequencyConfigParameters.MonStartTime = (double)m_nudSynthFrequencyMonStartTime.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateSynthFrequencyMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateSynthFrequencyMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudSynthFrequencyProfileIndex.Value = m_MonSynthFrequencyConfigParameters.ProfileIndex;
				m_nudSynthFrequencyMonReportingMode.Value = m_MonSynthFrequencyConfigParameters.ReportingMode;
				m_nudSynthFrequencyMonFreqErrorThreshold.Value = m_MonSynthFrequencyConfigParameters.FreqErrorThreshold;
				m_nudSynthFrequencyMonStartTime.Value = (decimal)m_MonSynthFrequencyConfigParameters.MonStartTime;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeSynthFrequencyMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, int MaxFreqErrorValue, uint FreqFailureCount, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_us_us_c_su_u_u method = new del_u_us_us_c_su_u_u(CascadeSynthFrequencyMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					ProfileIndex,
					MaxFreqErrorValue,
					FreqFailureCount,
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
						Convert.ToString(MaxFreqErrorValue);
						Convert.ToString(FreqFailureCount);
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString(ProfileIndex);
					Convert.ToString(MaxFreqErrorValue);
					Convert.ToString(FreqFailureCount);
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		private int iSetRxMixerInputPowerMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetRxMixerInputPowerMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRxMixerInputPowerMonConfig()
		{
			iSetRxMixerInputPowerMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetRxMixerInputPowerMonConfigAsync()
		{
			new del_v_v(iSetRxMixerInputPowerMonConfig).BeginInvoke(null, null);
		}

		private void m_btnRxMixerInoutPowerMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSetRxMixerInputPowerMonConfigAsync();
		}

		public bool UpdateRxMixerInputPowerMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRxMixerInputPowerMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonRxMixerInputPowerConfigParameters.ReportingMode = (char)m_nudRxMixerIpPowMonReportingMode.Value;
				m_MonRxMixerInputPowerConfigParameters.ProfileIndex = (char)m_nudRxMixerIpPowMonProfielIdnex.Value;
				m_MonRxMixerInputPowerConfigParameters.Tx1Enable = (m_chbRxMixerIpPowMonTx1Ena.Checked ? '\u0001' : '\0');
				m_MonRxMixerInputPowerConfigParameters.Tx2Enable = (m_chbRxMixerIpPowMonTx2Ena.Checked ? '\u0001' : '\0');
				m_MonRxMixerInputPowerConfigParameters.Tx3Enable = (m_chbRxMixerIpPowMonTx3Ena.Checked ? '\u0001' : '\0');
				m_MonRxMixerInputPowerConfigParameters.MinThresholds = (ushort)m_nudRxMixerIpPowMonMinThresholds.Value;
				m_MonRxMixerInputPowerConfigParameters.MaxThresholds = (ushort)m_nudRxMixerIpPowMonMaxThresholds.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRxMixerInputPowerMonConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRxMixerInputPowerMonConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudRxMixerIpPowMonReportingMode.Value = m_MonRxMixerInputPowerConfigParameters.ReportingMode;
				m_nudRxMixerIpPowMonProfielIdnex.Value = m_MonRxMixerInputPowerConfigParameters.ProfileIndex;
				m_chbRxMixerIpPowMonTx1Ena.Checked = (m_MonRxMixerInputPowerConfigParameters.Tx1Enable == '\u0001');
				m_chbRxMixerIpPowMonTx2Ena.Checked = (m_MonRxMixerInputPowerConfigParameters.Tx2Enable == '\u0001');
				m_chbRxMixerIpPowMonTx3Ena.Checked = (m_MonRxMixerInputPowerConfigParameters.Tx3Enable == '\u0001');
				m_nudRxMixerIpPowMonMinThresholds.Value = m_MonRxMixerInputPowerConfigParameters.MinThresholds;
				m_nudRxMixerIpPowMonMaxThresholds.Value = m_MonRxMixerInputPowerConfigParameters.MaxThresholds;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool CascadeRxMixerInputPowerMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileId, uint RxMixerInVolVal, uint TimeStamp)
		{
			if (base.InvokeRequired)
			{
				del_u_us_us_b_u_u method = new del_u_us_us_b_u_u(CascadeRxMixerInputPowerMonitoringReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					ProfileId,
					RxMixerInVolVal,
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
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						Convert.ToString(StatusFlags);
						Convert.ToString(ErrorCode);
						Convert.ToString((RxMixerInVolVal & 255U) * 1800U / 256U);
						Convert.ToString((RxMixerInVolVal >> 8 & 255U) * 1800U / 256U);
						Convert.ToString((RxMixerInVolVal >> 16 & 255U) * 1800U / 256U);
						Convert.ToString((RxMixerInVolVal >> 24 & 255U) * 1800U / 256U);
						Convert.ToString(ProfileId);
						Convert.ToString(TimeStamp);
					}
				}
				else
				{
					Convert.ToString(StatusFlags);
					Convert.ToString(ErrorCode);
					Convert.ToString((RxMixerInVolVal & 255U) * 1800U / 256U);
					Convert.ToString((RxMixerInVolVal >> 8 & 255U) * 1800U / 256U);
					Convert.ToString((RxMixerInVolVal >> 16 & 255U) * 1800U / 256U);
					Convert.ToString((RxMixerInVolVal >> 24 & 255U) * 1800U / 256U);
					Convert.ToString(ProfileId);
					Convert.ToString(TimeStamp);
				}
			}
			return true;
		}

		public bool SaveRxGainPhaseMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveRxGainPhaseMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rxGainPhaseMonProfileIndex", m_nudRXGainPhaseMonProfileIndex.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf1RXGainPhaseMonBitMask", (m_chbRF1RXGainPhaseMonBitMask.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf2RXGainPhaseMonBitMask", (m_chbRF2RXGainPhaseMonBitMask.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf3RXGainPhaseMonBitMask", (m_chbRF3RXGainPhaseMonBitMask.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rxGainPhaseReprotingMode", m_nudRXGainPhaseReprotingMode.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rxGainPhaseAbsErrThreshold", m_nudRXGainPhaseAbsErrThreshold.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rxGainMismatchThresholds", m_nudRXGainMismatchThresholds.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rxGainFlatnessErrThreshold", m_nudRXGainFlatnessErrThreshold.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rxPhaseMismatchThreshold", m_nudRXPhaseMismatchThreshold.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rxGainPhaseMonTxSelect", m_cboRxGainPhaseMonTxSelect.SelectedIndex.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf1RX0RXGainMismatchOffVal", m_nudRF1RX1RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf1RX1RXGainMismatchOffVal", m_nudRF1RX2RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf1RX2RXGainMismatchOffVal", m_nudRF1RX3RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf1RX3RXGainMismatchOffVal", m_nudRF1RX4RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf2RX0RXGainMismatchOffVal", m_nudRF2RX1RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf2RX1RXGainMismatchOffVal", m_nudRF2RX2RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf2RX2RXGainMismatchOffVal", m_nudRF2RX3RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf2RX3RXGainMismatchOffVal", m_nudRF2RX4RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf3RX0RXGainMismatchOffVal", m_nudRF3RX1RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf3RX1RXGainMismatchOffVal", m_nudRF3RX2RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf3RX2RXGainMismatchOffVal", m_nudRF3RX3RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf3RX3RXGainMismatchOffVal", m_nudRF3RX4RXGainMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf1RX0RXPhaseMismatchOffVal", m_nudRF1RX1RXPhaseMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf1RX1RXPhaseMismatchOffVal", m_nudRF1RX2RXPhaseMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf1RX2RXPhaseMismatchOffVal", m_nudRF1RX3RXPhaseMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf1RX3RXPhaseMismatchOffVal", m_nudRF1RX4RXPhaseMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf2RX0RXPhaseMismatchOffVal", m_nudRF2RX1RXPhaseMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf2RX1RXPhaseMismatchOffVal", m_nudRF2RX2RXPhaseMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf2RX2RXPhaseMismatchOffVal", m_nudRF2RX3RXPhaseMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf2RX3RXPhaseMismatchOffVal", m_nudRF2RX4RXPhaseMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf3RX0RXPhaseMismatchOffVal", m_nudRF3RX1RXPhaseMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf3RX1RXPhaseMismatchOffVal", m_nudRF3RX2RXPhaseMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf3RX2RXPhaseMismatchOffVal", m_nudRF3RX3RXPhaseMismatchOffVal.Value.ToString());
				ConfigurationManager.SetRxGainPhaseMonConfigKeyVal("rf3RX3RXPhaseMismatchOffVal", m_nudRF3RX4RXPhaseMismatchOffVal.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadRxGainPhaseMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadRxGainPhaseMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte rxGainPhaseMonProfileIndex = Convert.ToByte(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rxGainPhaseMonProfileIndex"));
				byte rf1RXGainPhaseMonBitMask = Convert.ToByte(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf1RXGainPhaseMonBitMask"));
				byte rf2RXGainPhaseMonBitMask = Convert.ToByte(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf2RXGainPhaseMonBitMask"));
				byte rf3RXGainPhaseMonBitMask = Convert.ToByte(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf3RXGainPhaseMonBitMask"));
				byte rxGainPhaseReprotingMode = Convert.ToByte(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rxGainPhaseReprotingMode"));
				double rxGainPhaseAbsErrThreshold = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rxGainPhaseAbsErrThreshold"));
				double rxGainMismatchThresholds = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rxGainMismatchThresholds"));
				double rxGainFlatnessErrThreshold = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rxGainFlatnessErrThreshold"));
				double rxPhaseMismatchThreshold = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rxPhaseMismatchThreshold"));
				byte rxGainPhaseMonTxSelect = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rxGainPhaseMonTxSelect"));
				double rf1RX0RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf1RX0RXGainMismatchOffVal"));
				double rf1RX1RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf1RX1RXGainMismatchOffVal"));
				double rf1RX2RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf1RX2RXGainMismatchOffVal"));
				double rf1RX3RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf1RX3RXGainMismatchOffVal"));
				double rf2RX0RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf2RX0RXGainMismatchOffVal"));
				double rf2RX1RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf2RX1RXGainMismatchOffVal"));
				double rf2RX2RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf2RX2RXGainMismatchOffVal"));
				double rf2RX3RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf2RX3RXGainMismatchOffVal"));
				double rf3RX0RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf3RX0RXGainMismatchOffVal"));
				double rf3RX1RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf3RX1RXGainMismatchOffVal"));
				double rf3RX2RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf3RX2RXGainMismatchOffVal"));
				double rf3RX3RXGainMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf3RX3RXGainMismatchOffVal"));
				double rf1RX0RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf1RX0RXPhaseMismatchOffVal"));
				double rf1RX1RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf1RX1RXPhaseMismatchOffVal"));
				double rf1RX2RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf1RX2RXPhaseMismatchOffVal"));
				double rf1RX3RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf1RX3RXPhaseMismatchOffVal"));
				double rf2RX0RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf2RX0RXPhaseMismatchOffVal"));
				double rf2RX1RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf2RX1RXPhaseMismatchOffVal"));
				double rf2RX2RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf2RX2RXPhaseMismatchOffVal"));
				double rf2RX3RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf2RX3RXPhaseMismatchOffVal"));
				double rf3RX0RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf3RX0RXPhaseMismatchOffVal"));
				double rf3RX1RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf3RX1RXPhaseMismatchOffVal"));
				double rf3RX2RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf3RX2RXPhaseMismatchOffVal"));
				double rf3RX3RXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetRxGainPhaseMonConfigKeyVal("rf3RX3RXPhaseMismatchOffVal"));
				m_GuiManager.ScriptOps.UpdateNRxGainPhaseMonConfigData(rxGainPhaseMonProfileIndex, rf1RXGainPhaseMonBitMask, rf2RXGainPhaseMonBitMask, rf3RXGainPhaseMonBitMask, rxGainPhaseReprotingMode, rxGainPhaseAbsErrThreshold, rxGainMismatchThresholds, rxGainFlatnessErrThreshold, rxPhaseMismatchThreshold, rxGainPhaseMonTxSelect, rf1RX0RXGainMismatchOffVal, rf1RX1RXGainMismatchOffVal, rf1RX2RXGainMismatchOffVal, rf1RX3RXGainMismatchOffVal, rf2RX0RXGainMismatchOffVal, rf2RX1RXGainMismatchOffVal, rf2RX2RXGainMismatchOffVal, rf2RX3RXGainMismatchOffVal, rf3RX0RXGainMismatchOffVal, rf3RX1RXGainMismatchOffVal, rf3RX2RXGainMismatchOffVal, rf3RX3RXGainMismatchOffVal, rf1RX0RXPhaseMismatchOffVal, rf1RX1RXPhaseMismatchOffVal, rf1RX2RXPhaseMismatchOffVal, rf1RX3RXPhaseMismatchOffVal, rf2RX0RXPhaseMismatchOffVal, rf2RX1RXPhaseMismatchOffVal, rf2RX2RXPhaseMismatchOffVal, rf2RX3RXPhaseMismatchOffVal, rf3RX0RXPhaseMismatchOffVal, rf3RX1RXPhaseMismatchOffVal, rf3RX2RXPhaseMismatchOffVal, rf3RX3RXPhaseMismatchOffVal);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveRxNoiseFigureMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveRxNoiseFigureMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetRxNoiseFigureMonConfigKeyVal("rxNoiseMonProfileIndex", m_nudRXNoiseMonProfileIndex.Value.ToString());
				ConfigurationManager.SetRxNoiseFigureMonConfigKeyVal("rf1RXNoiseMon", (m_chbRF1RXNoiseMon.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxNoiseFigureMonConfigKeyVal("rf2RXNoiseMon", (m_chbRF2RXNoiseMon.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxNoiseFigureMonConfigKeyVal("rf3RXNoiseMon", (m_chbRF3RXNoiseMon.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxNoiseFigureMonConfigKeyVal("rxNoiseFigureReportingMode", m_nudRxNoiseFigureReportingMode.Value.ToString());
				ConfigurationManager.SetRxNoiseFigureMonConfigKeyVal("rxNoiseFigureThreshold", m_nudRXNoiseFigureThreshold.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadRxNoiseFigureMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadRxNoiseFigureMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte rxNoiseMonProfileIndex = Convert.ToByte(ConfigurationManager.GetRxNoiseFigureMonConfigKeyVal("rxNoiseMonProfileIndex"));
				byte rf1RXNoiseMon = Convert.ToByte(ConfigurationManager.GetRxNoiseFigureMonConfigKeyVal("rf1RXNoiseMon"));
				byte rf2RXNoiseMon = Convert.ToByte(ConfigurationManager.GetRxNoiseFigureMonConfigKeyVal("rf2RXNoiseMon"));
				byte rf3RXNoiseMon = Convert.ToByte(ConfigurationManager.GetRxNoiseFigureMonConfigKeyVal("rf3RXNoiseMon"));
				byte rxNoiseFigureReportingMode = Convert.ToByte(ConfigurationManager.GetRxNoiseFigureMonConfigKeyVal("rxNoiseFigureReportingMode"));
				double rxNoiseFigureThreshold = (double)Convert.ToSingle(ConfigurationManager.GetRxNoiseFigureMonConfigKeyVal("rxNoiseFigureThreshold"));
				m_GuiManager.ScriptOps.UpdateNRxNoiseFigureMonConfigData(rxNoiseMonProfileIndex, rf1RXNoiseMon, rf2RXNoiseMon, rf3RXNoiseMon, rxNoiseFigureReportingMode, rxNoiseFigureThreshold);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveRxIFStageMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveRxIFStageMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetRxIFStageMonConfigKeyVal("rxIFStageMonProfileIndex", m_nudRXIFStageMonProfileIndex.Value.ToString());
				ConfigurationManager.SetRxIFStageMonConfigKeyVal("rxIFStageReportingMode", m_nudRxIFStageReportingMode.Value.ToString());
				ConfigurationManager.SetRxIFStageMonConfigKeyVal("rxIFStageHPFCuttoffFreqErrThreshold", m_nudRxIFStageHPFCuttoffFreqErrThreshold.Value.ToString());
				ConfigurationManager.SetRxIFStageMonConfigKeyVal("rxIFStageLPFCuttoffFreqErrThreshold", m_nudRxIFStageLPFCuttoffFreqErrThreshold.Value.ToString());
				ConfigurationManager.SetRxIFStageMonConfigKeyVal("rxIFStageIFAGainErrThreshold", m_nudRxIFStageIFAGainErrThreshold.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadRxIFStageMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadRxIFStageMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte rxIFStageMonProfileIndex = Convert.ToByte(ConfigurationManager.GetRxIFStageMonConfigKeyVal("rxIFStageMonProfileIndex"));
				byte rxIFStageReportingMode = Convert.ToByte(ConfigurationManager.GetRxIFStageMonConfigKeyVal("rxIFStageReportingMode"));
				ushort rxIFStageHPFCuttoffFreqErrThreshold = Convert.ToUInt16(ConfigurationManager.GetRxIFStageMonConfigKeyVal("rxIFStageHPFCuttoffFreqErrThreshold"));
				ushort rxIFStageLPFCuttoffFreqErrThreshold = Convert.ToUInt16(ConfigurationManager.GetRxIFStageMonConfigKeyVal("rxIFStageLPFCuttoffFreqErrThreshold"));
				double p = (double)Convert.ToSingle(ConfigurationManager.GetRxIFStageMonConfigKeyVal("rxIFStageIFAGainErrThreshold"));
				m_GuiManager.ScriptOps.UpdateNRxIFStageMonConfigData(rxIFStageMonProfileIndex, rxIFStageReportingMode, rxIFStageHPFCuttoffFreqErrThreshold, rxIFStageLPFCuttoffFreqErrThreshold, p);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveRxSaturationDetectorMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveRxSaturationDetectorMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetRxSaturationDetectorMonConfigKeyVal("rxSatDetectorMonProfileIndex", m_nudRxSatDetectorMonProfileIndex.Value.ToString());
				ConfigurationManager.SetRxSaturationDetectorMonConfigKeyVal("rxSatDetectorMonPriTimeSliceDuration", m_nudRxSatDetectorMonPriTimeSliceDuration.Value.ToString());
				ConfigurationManager.SetRxSaturationDetectorMonConfigKeyVal("rxSatDetectorMonSatMonNumSlice", m_nudRxSatDetectorMonSatMonNumSlice.Value.ToString());
				ConfigurationManager.SetRxSaturationDetectorMonConfigKeyVal("rxSatDetectorSatMonSelect", m_cboRxSatDetectorSatMonSelect.SelectedIndex.ToString());
				ConfigurationManager.SetRxSaturationDetectorMonConfigKeyVal("rxSatDetectorMonSatMonRxChannelMask", m_nudRxSatDetectorMonSatMonRxChannelMask.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadRxSaturationDetectorMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadRxSaturationDetectorMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte rxSatDetectorMonProfileIndex = Convert.ToByte(ConfigurationManager.GetRxSaturationDetectorMonConfigKeyVal("rxSatDetectorMonProfileIndex"));
				double rxSatDetectorMonPriTimeSliceDuration = (double)Convert.ToSingle(ConfigurationManager.GetRxSaturationDetectorMonConfigKeyVal("rxSatDetectorMonPriTimeSliceDuration"));
				ushort rxSatDetectorMonSatMonNumSlice = Convert.ToUInt16(ConfigurationManager.GetRxSaturationDetectorMonConfigKeyVal("rxSatDetectorMonSatMonNumSlice"));
				byte rxSatDetectorSatMonSelect = Convert.ToByte(ConfigurationManager.GetRxSaturationDetectorMonConfigKeyVal("rxSatDetectorSatMonSelect"));
				byte rxSatDetectorMonSatMonRxChannelMask = Convert.ToByte(ConfigurationManager.GetRxSaturationDetectorMonConfigKeyVal("rxSatDetectorMonSatMonRxChannelMask"));
				m_GuiManager.ScriptOps.UpdateNRxSaturationDetectorMonConfigData(rxSatDetectorMonProfileIndex, rxSatDetectorMonPriTimeSliceDuration, rxSatDetectorMonSatMonNumSlice, rxSatDetectorSatMonSelect, rxSatDetectorMonSatMonRxChannelMask);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveRxSignalAndImageMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveRxSignalAndImageMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetRxSignalAndImgeMonConfigKeyVal("sigImgMonProfileIndex", m_nudSigImgMonProfileIndex.Value.ToString());
				ConfigurationManager.SetRxSignalAndImgeMonConfigKeyVal("sigImgMonNumSlice", m_nudSigImgMonNumSlice.Value.ToString());
				ConfigurationManager.SetRxSignalAndImgeMonConfigKeyVal("sigImgMonPriTimeSliceNumSamples", m_nudSigImgMonPriTimeSliceNumSamples.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadRxSignalAndImageMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadRxSignalAndImageMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte sigImgMonProfileIndex = Convert.ToByte(ConfigurationManager.GetRxSignalAndImgeMonConfigKeyVal("sigImgMonProfileIndex"));
				byte sigImgMonNumSlice = Convert.ToByte(ConfigurationManager.GetRxSignalAndImgeMonConfigKeyVal("sigImgMonNumSlice"));
				ushort sigImgMonPriTimeSliceNumSamples = Convert.ToUInt16(ConfigurationManager.GetRxSignalAndImgeMonConfigKeyVal("sigImgMonPriTimeSliceNumSamples"));
				m_GuiManager.ScriptOps.UpdateNRxSignalAndImageMonConfigData(sigImgMonProfileIndex, sigImgMonNumSlice, sigImgMonPriTimeSliceNumSamples);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveRxMixerInputPowerMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveRxMixerInputPowerMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonReportingMode", m_nudRxMixerIpPowMonReportingMode.Value.ToString());
				ConfigurationManager.SetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonProfielIdnex", m_nudRxMixerIpPowMonProfielIdnex.Value.ToString());
				ConfigurationManager.SetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonTx0Ena", (m_chbRxMixerIpPowMonTx1Ena.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonTx1Ena", (m_chbRxMixerIpPowMonTx2Ena.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonTx2Ena", (m_chbRxMixerIpPowMonTx3Ena.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonMinThresholds", m_nudRxMixerIpPowMonMinThresholds.Value.ToString());
				ConfigurationManager.SetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonMaxThresholds", m_nudRxMixerIpPowMonMaxThresholds.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadRxMixerInputPowerMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadRxMixerInputPowerMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte rxMixerIpPowMonReportingMode = Convert.ToByte(ConfigurationManager.GetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonReportingMode"));
				byte rxMixerIpPowMonProfielIdnex = Convert.ToByte(ConfigurationManager.GetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonProfielIdnex"));
				byte rxMixerIpPowMonTx0Ena = Convert.ToByte(ConfigurationManager.GetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonTx0Ena"));
				byte rxMixerIpPowMonTx1Ena = Convert.ToByte(ConfigurationManager.GetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonTx1Ena"));
				byte rxMixerIpPowMonTx2Ena = Convert.ToByte(ConfigurationManager.GetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonTx2Ena"));
				ushort rxMixerIpPowMonMinThresholds = Convert.ToUInt16(ConfigurationManager.GetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonMinThresholds"));
				ushort rxMixerIpPowMonMaxThresholds = Convert.ToUInt16(ConfigurationManager.GetRxMixerInputPowerMonConfigKeyVal("rxMixerIpPowMonMaxThresholds"));
				m_GuiManager.ScriptOps.UpdateNRxMixerInputPowerMonConfigData(rxMixerIpPowMonReportingMode, rxMixerIpPowMonProfielIdnex, rxMixerIpPowMonTx0Ena, rxMixerIpPowMonTx1Ena, rxMixerIpPowMonTx2Ena, rxMixerIpPowMonMinThresholds, rxMixerIpPowMonMaxThresholds);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveRxTemperatureMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveRxTemperatureMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetRxTempMonConfigKeyVal("tempMonReportingMode", m_nudTempMonReportingMode.Value.ToString());
				ConfigurationManager.SetRxTempMonConfigKeyVal("tempMonAnaTempThreshMin", m_nudTempMonAnaTempThreshMin.Value.ToString());
				ConfigurationManager.SetRxTempMonConfigKeyVal("tempMonAnaTempThreshMax", m_nudTempMonAnaTempThreshMax.Value.ToString());
				ConfigurationManager.SetRxTempMonConfigKeyVal("tempMonDigTempThreshMin", m_nudTempMonDigTempThreshMin.Value.ToString());
				ConfigurationManager.SetRxTempMonConfigKeyVal("tempMonDigTempThreshMax", m_nudTempMonDigTempThreshMax.Value.ToString());
				ConfigurationManager.SetRxTempMonConfigKeyVal("tempMonTempDiffThresh", m_nudTempMonTempDiffThresh.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadRxTemperatureMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadRxTemperatureMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte tempMonReportingMode = Convert.ToByte(ConfigurationManager.GetRxTempMonConfigKeyVal("tempMonReportingMode"));
				short tempMonAnaTempThreshMin = Convert.ToInt16(ConfigurationManager.GetRxTempMonConfigKeyVal("tempMonAnaTempThreshMin"));
				short tempMonAnaTempThreshMax = Convert.ToInt16(ConfigurationManager.GetRxTempMonConfigKeyVal("tempMonAnaTempThreshMax"));
				short tempMonDigTempThreshMin = Convert.ToInt16(ConfigurationManager.GetRxTempMonConfigKeyVal("tempMonDigTempThreshMin"));
				short tempMonDigTempThreshMax = Convert.ToInt16(ConfigurationManager.GetRxTempMonConfigKeyVal("tempMonDigTempThreshMax"));
				short tempMonTempDiffThresh = Convert.ToInt16(ConfigurationManager.GetRxTempMonConfigKeyVal("tempMonTempDiffThresh"));
				m_GuiManager.ScriptOps.UpdateNRxTemperatureMonConfigData(tempMonReportingMode, tempMonAnaTempThreshMin, tempMonAnaTempThreshMax, tempMonDigTempThreshMin, tempMonDigTempThreshMax, tempMonTempDiffThresh);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveRxSynthFreqErrorMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveRxSynthFreqErrorMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetRxSynthFreqErrorMonConfigKeyVal("synthFrequencyProfileIndex", m_nudSynthFrequencyProfileIndex.Value.ToString());
				ConfigurationManager.SetRxSynthFreqErrorMonConfigKeyVal("synthFrequencyMonReportingMode", m_nudSynthFrequencyMonReportingMode.Value.ToString());
				ConfigurationManager.SetRxSynthFreqErrorMonConfigKeyVal("synthFrequencyMonFreqErrorThreshold", m_nudSynthFrequencyMonFreqErrorThreshold.Value.ToString());
				ConfigurationManager.SetRxSynthFreqErrorMonConfigKeyVal("synthFrequencyMonStartTime", m_nudSynthFrequencyMonStartTime.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadRxSynthFreqErrorMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadRxSynthFreqErrorMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte synthFrequencyProfileIndex = Convert.ToByte(ConfigurationManager.GetRxSynthFreqErrorMonConfigKeyVal("synthFrequencyProfileIndex"));
				byte synthFrequencyMonReportingMode = Convert.ToByte(ConfigurationManager.GetRxSynthFreqErrorMonConfigKeyVal("synthFrequencyMonReportingMode"));
				ushort synthFrequencyMonFreqErrorThreshold = Convert.ToUInt16(ConfigurationManager.GetRxSynthFreqErrorMonConfigKeyVal("synthFrequencyMonFreqErrorThreshold"));
				double synthFrequencyMonStartTime = (double)Convert.ToSingle(ConfigurationManager.GetRxSynthFreqErrorMonConfigKeyVal("synthFrequencyMonStartTime"));
				m_GuiManager.ScriptOps.UpdateNRxSynthFreqErrorMonConfigData(synthFrequencyProfileIndex, synthFrequencyMonReportingMode, synthFrequencyMonFreqErrorThreshold, synthFrequencyMonStartTime);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
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
            this.m_nudTempMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_nudTempMonAnaTempThreshMin = new System.Windows.Forms.NumericUpDown();
            this.m_btnTemperatureMonConfigSet = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.m_nudTempMonDigTempThreshMin = new System.Windows.Forms.NumericUpDown();
            this.m_nudTempMonAnaTempThreshMax = new System.Windows.Forms.NumericUpDown();
            this.m_nudTempMonTempDiffThresh = new System.Windows.Forms.NumericUpDown();
            this.m_nudTempMonDigTempThreshMax = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_btnSynthFrequencyMonConfigSet = new System.Windows.Forms.Button();
            this.m_nudSynthFrequencyProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.m_nudSynthFrequencyMonStartTime = new System.Windows.Forms.NumericUpDown();
            this.m_nudSynthFrequencyMonFreqErrorThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_nudSynthFrequencyMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.m_nudRxMixerIpPowMonMaxThresholds = new System.Windows.Forms.NumericUpDown();
            this.m_btnRxMixerInoutPowerMonConfigSet = new System.Windows.Forms.Button();
            this.m_chbRxMixerIpPowMonTx3Ena = new System.Windows.Forms.CheckBox();
            this.m_chbRxMixerIpPowMonTx2Ena = new System.Windows.Forms.CheckBox();
            this.m_chbRxMixerIpPowMonTx1Ena = new System.Windows.Forms.CheckBox();
            this.m_nudRxMixerIpPowMonMinThresholds = new System.Windows.Forms.NumericUpDown();
            this.m_nudRxMixerIpPowMonProfielIdnex = new System.Windows.Forms.NumericUpDown();
            this.m_nudRxMixerIpPowMonReportingMode = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_nudRXGainMismatchThresholds = new System.Windows.Forms.NumericUpDown();
            this.m_btnRxGainPhaseMonConfigSet = new System.Windows.Forms.Button();
            this.m_nudRF3RX4RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF3RX3RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF3RX2RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF3RX1RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF2RX4RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF2RX3RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF2RX2RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF2RX1RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF1RX4RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF1RX3RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF1RX2RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF1RX1RXPhaseMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF3RX4RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF3RX3RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF3RX2RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF3RX1RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF2RX4RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF2RX3RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF2RX2RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF2RX1RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF1RX4RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF1RX3RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF1RX2RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudRF1RX1RXGainMismatchOffVal = new System.Windows.Forms.NumericUpDown();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.m_chbRF2RXGainPhaseMonBitMask = new System.Windows.Forms.CheckBox();
            this.m_cboRxGainPhaseMonTxSelect = new System.Windows.Forms.ComboBox();
            this.m_nudRXPhaseMismatchThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_nudRXGainFlatnessErrThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_nudRXGainPhaseAbsErrThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_nudRXGainPhaseMonProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.m_nudRXGainPhaseReprotingMode = new System.Windows.Forms.NumericUpDown();
            this.m_chbRF1RXGainPhaseMonBitMask = new System.Windows.Forms.CheckBox();
            this.m_chbRF3RXGainPhaseMonBitMask = new System.Windows.Forms.CheckBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.m_nudRXGainMismatchThreshold = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_nudRxSatDetectorMonSatReserved = new System.Windows.Forms.NumericUpDown();
            this.label57 = new System.Windows.Forms.Label();
            this.m_cboRxSatDetectorSatMonSelect = new System.Windows.Forms.ComboBox();
            this.m_nudRxSatDetectorMonSatMonRxChannelMask = new System.Windows.Forms.NumericUpDown();
            this.m_nudRxSatDetectorMonSatMonNumSlice = new System.Windows.Forms.NumericUpDown();
            this.m_nudRxSatDetectorMonPriTimeSliceDuration = new System.Windows.Forms.NumericUpDown();
            this.m_nudRxSatDetectorMonProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.m_btnRXSaturationDetectorMonConfigSet = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_chbRF3RXNoiseMon = new System.Windows.Forms.CheckBox();
            this.m_chbRF1RXNoiseMon = new System.Windows.Forms.CheckBox();
            this.m_chbRF2RXNoiseMon = new System.Windows.Forms.CheckBox();
            this.m_nudRXNoiseFigureThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_nudRxNoiseFigureReportingMode = new System.Windows.Forms.NumericUpDown();
            this.m_nudRXNoiseMonProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.m_btnRXNoiseMonConfigSet = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_nudRxIFStageIFAGainErrThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_nudRxIFStageLPFCuttoffFreqErrThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_nudRxIFStageHPFCuttoffFreqErrThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_nudRxIFStageReportingMode = new System.Windows.Forms.NumericUpDown();
            this.m_nudRXIFStageMonProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.f0000ff = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.m_nudSigImgMonPriTimeSliceNumSamples = new System.Windows.Forms.NumericUpDown();
            this.m_nudSigImgMonNumSlice = new System.Windows.Forms.NumericUpDown();
            this.m_btnSignalandImageMonConfigSet = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.m_nudSigImgMonProfileIndex = new System.Windows.Forms.NumericUpDown();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonReportingMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonAnaTempThreshMin)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonDigTempThreshMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonAnaTempThreshMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonTempDiffThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonDigTempThreshMax)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSynthFrequencyProfileIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSynthFrequencyMonStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSynthFrequencyMonFreqErrorThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSynthFrequencyMonReportingMode)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxMixerIpPowMonMaxThresholds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxMixerIpPowMonMinThresholds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxMixerIpPowMonProfielIdnex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxMixerIpPowMonReportingMode)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXGainMismatchThresholds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX4RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX3RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX2RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX1RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX4RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX3RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX2RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX1RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX4RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX3RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX2RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX1RXPhaseMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX4RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX3RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX2RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX1RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX4RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX3RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX2RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX1RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX4RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX3RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX2RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX1RXGainMismatchOffVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXPhaseMismatchThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXGainFlatnessErrThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXGainPhaseAbsErrThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXGainPhaseMonProfileIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXGainPhaseReprotingMode)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxSatDetectorMonSatReserved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxSatDetectorMonSatMonRxChannelMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxSatDetectorMonSatMonNumSlice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxSatDetectorMonPriTimeSliceDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxSatDetectorMonProfileIndex)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXNoiseFigureThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxNoiseFigureReportingMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXNoiseMonProfileIndex)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxIFStageIFAGainErrThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxIFStageLPFCuttoffFreqErrThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxIFStageHPFCuttoffFreqErrThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxIFStageReportingMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXIFStageMonProfileIndex)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSigImgMonPriTimeSliceNumSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSigImgMonNumSlice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSigImgMonProfileIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // m_nudTempMonReportingMode
            // 
            this.m_nudTempMonReportingMode.Location = new System.Drawing.Point(164, 15);
            this.m_nudTempMonReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudTempMonReportingMode.Name = "m_nudTempMonReportingMode";
            this.m_nudTempMonReportingMode.Size = new System.Drawing.Size(67, 20);
            this.m_nudTempMonReportingMode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ana Temp Thresh Max (Deg)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dig Temp Thresh Min (Deg)";
            // 
            // m_nudTempMonAnaTempThreshMin
            // 
            this.m_nudTempMonAnaTempThreshMin.Location = new System.Drawing.Point(164, 42);
            this.m_nudTempMonAnaTempThreshMin.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.m_nudTempMonAnaTempThreshMin.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.m_nudTempMonAnaTempThreshMin.Name = "m_nudTempMonAnaTempThreshMin";
            this.m_nudTempMonAnaTempThreshMin.Size = new System.Drawing.Size(67, 20);
            this.m_nudTempMonAnaTempThreshMin.TabIndex = 7;
            // 
            // m_btnTemperatureMonConfigSet
            // 
            this.m_btnTemperatureMonConfigSet.Location = new System.Drawing.Point(156, 165);
            this.m_btnTemperatureMonConfigSet.Name = "m_btnTemperatureMonConfigSet";
            this.m_btnTemperatureMonConfigSet.Size = new System.Drawing.Size(75, 23);
            this.m_btnTemperatureMonConfigSet.TabIndex = 8;
            this.m_btnTemperatureMonConfigSet.Text = "Set";
            this.m_btnTemperatureMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.m_nudTempMonDigTempThreshMin);
            this.groupBox6.Controls.Add(this.m_nudTempMonAnaTempThreshMax);
            this.groupBox6.Controls.Add(this.m_nudTempMonTempDiffThresh);
            this.groupBox6.Controls.Add(this.m_nudTempMonDigTempThreshMax);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.m_nudTempMonAnaTempThreshMin);
            this.groupBox6.Controls.Add(this.m_btnTemperatureMonConfigSet);
            this.groupBox6.Controls.Add(this.m_nudTempMonReportingMode);
            this.groupBox6.Location = new System.Drawing.Point(689, 328);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(243, 195);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Temperature Mon Config ";
            // 
            // m_nudTempMonDigTempThreshMin
            // 
            this.m_nudTempMonDigTempThreshMin.Location = new System.Drawing.Point(164, 90);
            this.m_nudTempMonDigTempThreshMin.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.m_nudTempMonDigTempThreshMin.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.m_nudTempMonDigTempThreshMin.Name = "m_nudTempMonDigTempThreshMin";
            this.m_nudTempMonDigTempThreshMin.Size = new System.Drawing.Size(67, 20);
            this.m_nudTempMonDigTempThreshMin.TabIndex = 14;
            // 
            // m_nudTempMonAnaTempThreshMax
            // 
            this.m_nudTempMonAnaTempThreshMax.Location = new System.Drawing.Point(164, 67);
            this.m_nudTempMonAnaTempThreshMax.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.m_nudTempMonAnaTempThreshMax.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.m_nudTempMonAnaTempThreshMax.Name = "m_nudTempMonAnaTempThreshMax";
            this.m_nudTempMonAnaTempThreshMax.Size = new System.Drawing.Size(67, 20);
            this.m_nudTempMonAnaTempThreshMax.TabIndex = 13;
            // 
            // m_nudTempMonTempDiffThresh
            // 
            this.m_nudTempMonTempDiffThresh.Location = new System.Drawing.Point(164, 140);
            this.m_nudTempMonTempDiffThresh.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.m_nudTempMonTempDiffThresh.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.m_nudTempMonTempDiffThresh.Name = "m_nudTempMonTempDiffThresh";
            this.m_nudTempMonTempDiffThresh.Size = new System.Drawing.Size(67, 20);
            this.m_nudTempMonTempDiffThresh.TabIndex = 12;
            // 
            // m_nudTempMonDigTempThreshMax
            // 
            this.m_nudTempMonDigTempThreshMax.Location = new System.Drawing.Point(164, 115);
            this.m_nudTempMonDigTempThreshMax.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.m_nudTempMonDigTempThreshMax.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.m_nudTempMonDigTempThreshMax.Name = "m_nudTempMonDigTempThreshMax";
            this.m_nudTempMonDigTempThreshMax.Size = new System.Drawing.Size(67, 20);
            this.m_nudTempMonDigTempThreshMax.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(141, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Dig Temp Thresh Max (Deg)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Temp Diff Thresh (Deg)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Ana Temp Thresh Min (Deg)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Reporting Mode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_btnSynthFrequencyMonConfigSet);
            this.groupBox2.Controls.Add(this.m_nudSynthFrequencyProfileIndex);
            this.groupBox2.Controls.Add(this.m_nudSynthFrequencyMonStartTime);
            this.groupBox2.Controls.Add(this.m_nudSynthFrequencyMonFreqErrorThreshold);
            this.groupBox2.Controls.Add(this.m_nudSynthFrequencyMonReportingMode);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(945, 328);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 195);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Synth Frequency Err Mon Config";
            // 
            // m_btnSynthFrequencyMonConfigSet
            // 
            this.m_btnSynthFrequencyMonConfigSet.Location = new System.Drawing.Point(119, 160);
            this.m_btnSynthFrequencyMonConfigSet.Name = "m_btnSynthFrequencyMonConfigSet";
            this.m_btnSynthFrequencyMonConfigSet.Size = new System.Drawing.Size(75, 23);
            this.m_btnSynthFrequencyMonConfigSet.TabIndex = 15;
            this.m_btnSynthFrequencyMonConfigSet.Text = "Set";
            this.m_btnSynthFrequencyMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_nudSynthFrequencyProfileIndex
            // 
            this.m_nudSynthFrequencyProfileIndex.Location = new System.Drawing.Point(127, 15);
            this.m_nudSynthFrequencyProfileIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudSynthFrequencyProfileIndex.Name = "m_nudSynthFrequencyProfileIndex";
            this.m_nudSynthFrequencyProfileIndex.Size = new System.Drawing.Size(67, 20);
            this.m_nudSynthFrequencyProfileIndex.TabIndex = 7;
            // 
            // m_nudSynthFrequencyMonStartTime
            // 
            this.m_nudSynthFrequencyMonStartTime.DecimalPlaces = 1;
            this.m_nudSynthFrequencyMonStartTime.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.m_nudSynthFrequencyMonStartTime.Location = new System.Drawing.Point(127, 95);
            this.m_nudSynthFrequencyMonStartTime.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.m_nudSynthFrequencyMonStartTime.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147483648});
            this.m_nudSynthFrequencyMonStartTime.Name = "m_nudSynthFrequencyMonStartTime";
            this.m_nudSynthFrequencyMonStartTime.Size = new System.Drawing.Size(67, 20);
            this.m_nudSynthFrequencyMonStartTime.TabIndex = 6;
            this.m_nudSynthFrequencyMonStartTime.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            // 
            // m_nudSynthFrequencyMonFreqErrorThreshold
            // 
            this.m_nudSynthFrequencyMonFreqErrorThreshold.Location = new System.Drawing.Point(127, 69);
            this.m_nudSynthFrequencyMonFreqErrorThreshold.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudSynthFrequencyMonFreqErrorThreshold.Name = "m_nudSynthFrequencyMonFreqErrorThreshold";
            this.m_nudSynthFrequencyMonFreqErrorThreshold.Size = new System.Drawing.Size(67, 20);
            this.m_nudSynthFrequencyMonFreqErrorThreshold.TabIndex = 5;
            this.m_nudSynthFrequencyMonFreqErrorThreshold.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // m_nudSynthFrequencyMonReportingMode
            // 
            this.m_nudSynthFrequencyMonReportingMode.Location = new System.Drawing.Point(127, 41);
            this.m_nudSynthFrequencyMonReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudSynthFrequencyMonReportingMode.Name = "m_nudSynthFrequencyMonReportingMode";
            this.m_nudSynthFrequencyMonReportingMode.Size = new System.Drawing.Size(67, 20);
            this.m_nudSynthFrequencyMonReportingMode.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 19);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "Profile Index";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 97);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Mon Start Time (µs)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(120, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Freq Err Thresh (10kHz)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Reporting Mode";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label54);
            this.groupBox7.Controls.Add(this.label52);
            this.groupBox7.Controls.Add(this.m_nudRxMixerIpPowMonMaxThresholds);
            this.groupBox7.Controls.Add(this.m_btnRxMixerInoutPowerMonConfigSet);
            this.groupBox7.Controls.Add(this.m_chbRxMixerIpPowMonTx3Ena);
            this.groupBox7.Controls.Add(this.m_chbRxMixerIpPowMonTx2Ena);
            this.groupBox7.Controls.Add(this.m_chbRxMixerIpPowMonTx1Ena);
            this.groupBox7.Controls.Add(this.m_nudRxMixerIpPowMonMinThresholds);
            this.groupBox7.Controls.Add(this.m_nudRxMixerIpPowMonProfielIdnex);
            this.groupBox7.Controls.Add(this.m_nudRxMixerIpPowMonReportingMode);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Location = new System.Drawing.Point(445, 328);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(234, 195);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Rx Mixer Input Power Mon Config";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(182, 94);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(51, 13);
            this.label54.TabIndex = 13;
            this.label54.Text = "Max (mV)";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(108, 95);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(48, 13);
            this.label52.TabIndex = 12;
            this.label52.Text = "Min (mV)";
            // 
            // m_nudRxMixerIpPowMonMaxThresholds
            // 
            this.m_nudRxMixerIpPowMonMaxThresholds.Location = new System.Drawing.Point(174, 114);
            this.m_nudRxMixerIpPowMonMaxThresholds.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.m_nudRxMixerIpPowMonMaxThresholds.Name = "m_nudRxMixerIpPowMonMaxThresholds";
            this.m_nudRxMixerIpPowMonMaxThresholds.Size = new System.Drawing.Size(60, 20);
            this.m_nudRxMixerIpPowMonMaxThresholds.TabIndex = 11;
            // 
            // m_btnRxMixerInoutPowerMonConfigSet
            // 
            this.m_btnRxMixerInoutPowerMonConfigSet.Location = new System.Drawing.Point(117, 160);
            this.m_btnRxMixerInoutPowerMonConfigSet.Name = "m_btnRxMixerInoutPowerMonConfigSet";
            this.m_btnRxMixerInoutPowerMonConfigSet.Size = new System.Drawing.Size(75, 27);
            this.m_btnRxMixerInoutPowerMonConfigSet.TabIndex = 10;
            this.m_btnRxMixerInoutPowerMonConfigSet.Text = "Set";
            this.m_btnRxMixerInoutPowerMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_chbRxMixerIpPowMonTx3Ena
            // 
            this.m_chbRxMixerIpPowMonTx3Ena.AutoSize = true;
            this.m_chbRxMixerIpPowMonTx3Ena.Location = new System.Drawing.Point(190, 70);
            this.m_chbRxMixerIpPowMonTx3Ena.Name = "m_chbRxMixerIpPowMonTx3Ena";
            this.m_chbRxMixerIpPowMonTx3Ena.Size = new System.Drawing.Size(44, 17);
            this.m_chbRxMixerIpPowMonTx3Ena.TabIndex = 9;
            this.m_chbRxMixerIpPowMonTx3Ena.Text = "Tx2";
            this.m_chbRxMixerIpPowMonTx3Ena.UseVisualStyleBackColor = true;
            // 
            // m_chbRxMixerIpPowMonTx2Ena
            // 
            this.m_chbRxMixerIpPowMonTx2Ena.AutoSize = true;
            this.m_chbRxMixerIpPowMonTx2Ena.Location = new System.Drawing.Point(148, 70);
            this.m_chbRxMixerIpPowMonTx2Ena.Name = "m_chbRxMixerIpPowMonTx2Ena";
            this.m_chbRxMixerIpPowMonTx2Ena.Size = new System.Drawing.Size(44, 17);
            this.m_chbRxMixerIpPowMonTx2Ena.TabIndex = 8;
            this.m_chbRxMixerIpPowMonTx2Ena.Text = "Tx1";
            this.m_chbRxMixerIpPowMonTx2Ena.UseVisualStyleBackColor = true;
            // 
            // m_chbRxMixerIpPowMonTx1Ena
            // 
            this.m_chbRxMixerIpPowMonTx1Ena.AutoSize = true;
            this.m_chbRxMixerIpPowMonTx1Ena.Location = new System.Drawing.Point(108, 70);
            this.m_chbRxMixerIpPowMonTx1Ena.Name = "m_chbRxMixerIpPowMonTx1Ena";
            this.m_chbRxMixerIpPowMonTx1Ena.Size = new System.Drawing.Size(44, 17);
            this.m_chbRxMixerIpPowMonTx1Ena.TabIndex = 7;
            this.m_chbRxMixerIpPowMonTx1Ena.Text = "Tx0";
            this.m_chbRxMixerIpPowMonTx1Ena.UseVisualStyleBackColor = true;
            // 
            // m_nudRxMixerIpPowMonMinThresholds
            // 
            this.m_nudRxMixerIpPowMonMinThresholds.Location = new System.Drawing.Point(108, 114);
            this.m_nudRxMixerIpPowMonMinThresholds.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.m_nudRxMixerIpPowMonMinThresholds.Name = "m_nudRxMixerIpPowMonMinThresholds";
            this.m_nudRxMixerIpPowMonMinThresholds.Size = new System.Drawing.Size(60, 20);
            this.m_nudRxMixerIpPowMonMinThresholds.TabIndex = 6;
            // 
            // m_nudRxMixerIpPowMonProfielIdnex
            // 
            this.m_nudRxMixerIpPowMonProfielIdnex.Location = new System.Drawing.Point(108, 47);
            this.m_nudRxMixerIpPowMonProfielIdnex.Name = "m_nudRxMixerIpPowMonProfielIdnex";
            this.m_nudRxMixerIpPowMonProfielIdnex.Size = new System.Drawing.Size(90, 20);
            this.m_nudRxMixerIpPowMonProfielIdnex.TabIndex = 5;
            // 
            // m_nudRxMixerIpPowMonReportingMode
            // 
            this.m_nudRxMixerIpPowMonReportingMode.Location = new System.Drawing.Point(108, 22);
            this.m_nudRxMixerIpPowMonReportingMode.Name = "m_nudRxMixerIpPowMonReportingMode";
            this.m_nudRxMixerIpPowMonReportingMode.Size = new System.Drawing.Size(90, 20);
            this.m_nudRxMixerIpPowMonReportingMode.TabIndex = 4;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(4, 116);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 13);
            this.label24.TabIndex = 3;
            this.label24.Text = "Thresholds";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(4, 71);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Tx Enable";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "Profile Index";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(4, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Reporting Mode";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_nudRXGainMismatchThresholds);
            this.groupBox1.Controls.Add(this.m_btnRxGainPhaseMonConfigSet);
            this.groupBox1.Controls.Add(this.m_nudRF3RX4RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3RX3RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3RX2RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3RX1RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2RX4RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2RX3RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2RX2RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2RX1RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1RX4RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1RX3RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1RX2RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1RX1RXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3RX4RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3RX3RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3RX2RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3RX1RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2RX4RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2RX3RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2RX2RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2RX1RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1RX4RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1RX3RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1RX2RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1RX1RXGainMismatchOffVal);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.m_chbRF2RXGainPhaseMonBitMask);
            this.groupBox1.Controls.Add(this.m_cboRxGainPhaseMonTxSelect);
            this.groupBox1.Controls.Add(this.m_nudRXPhaseMismatchThreshold);
            this.groupBox1.Controls.Add(this.m_nudRXGainFlatnessErrThreshold);
            this.groupBox1.Controls.Add(this.m_nudRXGainPhaseAbsErrThreshold);
            this.groupBox1.Controls.Add(this.m_nudRXGainPhaseMonProfileIndex);
            this.groupBox1.Controls.Add(this.m_nudRXGainPhaseReprotingMode);
            this.groupBox1.Controls.Add(this.m_chbRF1RXGainPhaseMonBitMask);
            this.groupBox1.Controls.Add(this.m_chbRF3RXGainPhaseMonBitMask);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.m_nudRXGainMismatchThreshold);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(13, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 312);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monitoring Rx Gain Phase Config";
            // 
            // m_nudRXGainMismatchThresholds
            // 
            this.m_nudRXGainMismatchThresholds.DecimalPlaces = 1;
            this.m_nudRXGainMismatchThresholds.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRXGainMismatchThresholds.Location = new System.Drawing.Point(458, 23);
            this.m_nudRXGainMismatchThresholds.Name = "m_nudRXGainMismatchThresholds";
            this.m_nudRXGainMismatchThresholds.Size = new System.Drawing.Size(73, 20);
            this.m_nudRXGainMismatchThresholds.TabIndex = 83;
            // 
            // m_btnRxGainPhaseMonConfigSet
            // 
            this.m_btnRxGainPhaseMonConfigSet.Location = new System.Drawing.Point(394, 283);
            this.m_btnRxGainPhaseMonConfigSet.Name = "m_btnRxGainPhaseMonConfigSet";
            this.m_btnRxGainPhaseMonConfigSet.Size = new System.Drawing.Size(75, 23);
            this.m_btnRxGainPhaseMonConfigSet.TabIndex = 82;
            this.m_btnRxGainPhaseMonConfigSet.Text = "Set";
            this.m_btnRxGainPhaseMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_nudRF3RX4RXPhaseMismatchOffVal
            // 
            this.m_nudRF3RX4RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF3RX4RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF3RX4RXPhaseMismatchOffVal.Location = new System.Drawing.Point(470, 251);
            this.m_nudRF3RX4RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF3RX4RXPhaseMismatchOffVal.Name = "m_nudRF3RX4RXPhaseMismatchOffVal";
            this.m_nudRF3RX4RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF3RX4RXPhaseMismatchOffVal.TabIndex = 81;
            // 
            // m_nudRF3RX3RXPhaseMismatchOffVal
            // 
            this.m_nudRF3RX3RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF3RX3RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF3RX3RXPhaseMismatchOffVal.Location = new System.Drawing.Point(470, 224);
            this.m_nudRF3RX3RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF3RX3RXPhaseMismatchOffVal.Name = "m_nudRF3RX3RXPhaseMismatchOffVal";
            this.m_nudRF3RX3RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF3RX3RXPhaseMismatchOffVal.TabIndex = 80;
            // 
            // m_nudRF3RX2RXPhaseMismatchOffVal
            // 
            this.m_nudRF3RX2RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF3RX2RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF3RX2RXPhaseMismatchOffVal.Location = new System.Drawing.Point(470, 197);
            this.m_nudRF3RX2RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF3RX2RXPhaseMismatchOffVal.Name = "m_nudRF3RX2RXPhaseMismatchOffVal";
            this.m_nudRF3RX2RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF3RX2RXPhaseMismatchOffVal.TabIndex = 79;
            // 
            // m_nudRF3RX1RXPhaseMismatchOffVal
            // 
            this.m_nudRF3RX1RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF3RX1RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF3RX1RXPhaseMismatchOffVal.Location = new System.Drawing.Point(470, 170);
            this.m_nudRF3RX1RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF3RX1RXPhaseMismatchOffVal.Name = "m_nudRF3RX1RXPhaseMismatchOffVal";
            this.m_nudRF3RX1RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF3RX1RXPhaseMismatchOffVal.TabIndex = 78;
            // 
            // m_nudRF2RX4RXPhaseMismatchOffVal
            // 
            this.m_nudRF2RX4RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF2RX4RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF2RX4RXPhaseMismatchOffVal.Location = new System.Drawing.Point(401, 252);
            this.m_nudRF2RX4RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF2RX4RXPhaseMismatchOffVal.Name = "m_nudRF2RX4RXPhaseMismatchOffVal";
            this.m_nudRF2RX4RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF2RX4RXPhaseMismatchOffVal.TabIndex = 77;
            // 
            // m_nudRF2RX3RXPhaseMismatchOffVal
            // 
            this.m_nudRF2RX3RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF2RX3RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF2RX3RXPhaseMismatchOffVal.Location = new System.Drawing.Point(401, 225);
            this.m_nudRF2RX3RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF2RX3RXPhaseMismatchOffVal.Name = "m_nudRF2RX3RXPhaseMismatchOffVal";
            this.m_nudRF2RX3RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF2RX3RXPhaseMismatchOffVal.TabIndex = 76;
            // 
            // m_nudRF2RX2RXPhaseMismatchOffVal
            // 
            this.m_nudRF2RX2RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF2RX2RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF2RX2RXPhaseMismatchOffVal.Location = new System.Drawing.Point(401, 198);
            this.m_nudRF2RX2RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF2RX2RXPhaseMismatchOffVal.Name = "m_nudRF2RX2RXPhaseMismatchOffVal";
            this.m_nudRF2RX2RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF2RX2RXPhaseMismatchOffVal.TabIndex = 75;
            // 
            // m_nudRF2RX1RXPhaseMismatchOffVal
            // 
            this.m_nudRF2RX1RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF2RX1RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF2RX1RXPhaseMismatchOffVal.Location = new System.Drawing.Point(401, 171);
            this.m_nudRF2RX1RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF2RX1RXPhaseMismatchOffVal.Name = "m_nudRF2RX1RXPhaseMismatchOffVal";
            this.m_nudRF2RX1RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF2RX1RXPhaseMismatchOffVal.TabIndex = 74;
            // 
            // m_nudRF1RX4RXPhaseMismatchOffVal
            // 
            this.m_nudRF1RX4RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF1RX4RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF1RX4RXPhaseMismatchOffVal.Location = new System.Drawing.Point(330, 252);
            this.m_nudRF1RX4RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF1RX4RXPhaseMismatchOffVal.Name = "m_nudRF1RX4RXPhaseMismatchOffVal";
            this.m_nudRF1RX4RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF1RX4RXPhaseMismatchOffVal.TabIndex = 73;
            // 
            // m_nudRF1RX3RXPhaseMismatchOffVal
            // 
            this.m_nudRF1RX3RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF1RX3RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF1RX3RXPhaseMismatchOffVal.Location = new System.Drawing.Point(330, 225);
            this.m_nudRF1RX3RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF1RX3RXPhaseMismatchOffVal.Name = "m_nudRF1RX3RXPhaseMismatchOffVal";
            this.m_nudRF1RX3RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF1RX3RXPhaseMismatchOffVal.TabIndex = 72;
            // 
            // m_nudRF1RX2RXPhaseMismatchOffVal
            // 
            this.m_nudRF1RX2RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF1RX2RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF1RX2RXPhaseMismatchOffVal.Location = new System.Drawing.Point(330, 198);
            this.m_nudRF1RX2RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF1RX2RXPhaseMismatchOffVal.Name = "m_nudRF1RX2RXPhaseMismatchOffVal";
            this.m_nudRF1RX2RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF1RX2RXPhaseMismatchOffVal.TabIndex = 71;
            // 
            // m_nudRF1RX1RXPhaseMismatchOffVal
            // 
            this.m_nudRF1RX1RXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF1RX1RXPhaseMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRF1RX1RXPhaseMismatchOffVal.Location = new System.Drawing.Point(330, 171);
            this.m_nudRF1RX1RXPhaseMismatchOffVal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRF1RX1RXPhaseMismatchOffVal.Name = "m_nudRF1RX1RXPhaseMismatchOffVal";
            this.m_nudRF1RX1RXPhaseMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF1RX1RXPhaseMismatchOffVal.TabIndex = 70;
            // 
            // m_nudRF3RX4RXGainMismatchOffVal
            // 
            this.m_nudRF3RX4RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF3RX4RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF3RX4RXGainMismatchOffVal.Location = new System.Drawing.Point(196, 254);
            this.m_nudRF3RX4RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF3RX4RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF3RX4RXGainMismatchOffVal.Name = "m_nudRF3RX4RXGainMismatchOffVal";
            this.m_nudRF3RX4RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF3RX4RXGainMismatchOffVal.TabIndex = 69;
            // 
            // m_nudRF3RX3RXGainMismatchOffVal
            // 
            this.m_nudRF3RX3RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF3RX3RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF3RX3RXGainMismatchOffVal.Location = new System.Drawing.Point(196, 227);
            this.m_nudRF3RX3RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF3RX3RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF3RX3RXGainMismatchOffVal.Name = "m_nudRF3RX3RXGainMismatchOffVal";
            this.m_nudRF3RX3RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF3RX3RXGainMismatchOffVal.TabIndex = 68;
            // 
            // m_nudRF3RX2RXGainMismatchOffVal
            // 
            this.m_nudRF3RX2RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF3RX2RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF3RX2RXGainMismatchOffVal.Location = new System.Drawing.Point(196, 200);
            this.m_nudRF3RX2RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF3RX2RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF3RX2RXGainMismatchOffVal.Name = "m_nudRF3RX2RXGainMismatchOffVal";
            this.m_nudRF3RX2RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF3RX2RXGainMismatchOffVal.TabIndex = 67;
            // 
            // m_nudRF3RX1RXGainMismatchOffVal
            // 
            this.m_nudRF3RX1RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF3RX1RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF3RX1RXGainMismatchOffVal.Location = new System.Drawing.Point(196, 173);
            this.m_nudRF3RX1RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF3RX1RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF3RX1RXGainMismatchOffVal.Name = "m_nudRF3RX1RXGainMismatchOffVal";
            this.m_nudRF3RX1RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF3RX1RXGainMismatchOffVal.TabIndex = 66;
            // 
            // m_nudRF2RX4RXGainMismatchOffVal
            // 
            this.m_nudRF2RX4RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF2RX4RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF2RX4RXGainMismatchOffVal.Location = new System.Drawing.Point(123, 254);
            this.m_nudRF2RX4RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF2RX4RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF2RX4RXGainMismatchOffVal.Name = "m_nudRF2RX4RXGainMismatchOffVal";
            this.m_nudRF2RX4RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF2RX4RXGainMismatchOffVal.TabIndex = 65;
            // 
            // m_nudRF2RX3RXGainMismatchOffVal
            // 
            this.m_nudRF2RX3RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF2RX3RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF2RX3RXGainMismatchOffVal.Location = new System.Drawing.Point(123, 227);
            this.m_nudRF2RX3RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF2RX3RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF2RX3RXGainMismatchOffVal.Name = "m_nudRF2RX3RXGainMismatchOffVal";
            this.m_nudRF2RX3RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF2RX3RXGainMismatchOffVal.TabIndex = 64;
            // 
            // m_nudRF2RX2RXGainMismatchOffVal
            // 
            this.m_nudRF2RX2RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF2RX2RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF2RX2RXGainMismatchOffVal.Location = new System.Drawing.Point(123, 200);
            this.m_nudRF2RX2RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF2RX2RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF2RX2RXGainMismatchOffVal.Name = "m_nudRF2RX2RXGainMismatchOffVal";
            this.m_nudRF2RX2RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF2RX2RXGainMismatchOffVal.TabIndex = 63;
            // 
            // m_nudRF2RX1RXGainMismatchOffVal
            // 
            this.m_nudRF2RX1RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF2RX1RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF2RX1RXGainMismatchOffVal.Location = new System.Drawing.Point(123, 173);
            this.m_nudRF2RX1RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF2RX1RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF2RX1RXGainMismatchOffVal.Name = "m_nudRF2RX1RXGainMismatchOffVal";
            this.m_nudRF2RX1RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF2RX1RXGainMismatchOffVal.TabIndex = 62;
            // 
            // m_nudRF1RX4RXGainMismatchOffVal
            // 
            this.m_nudRF1RX4RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF1RX4RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF1RX4RXGainMismatchOffVal.Location = new System.Drawing.Point(47, 254);
            this.m_nudRF1RX4RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF1RX4RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF1RX4RXGainMismatchOffVal.Name = "m_nudRF1RX4RXGainMismatchOffVal";
            this.m_nudRF1RX4RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF1RX4RXGainMismatchOffVal.TabIndex = 61;
            // 
            // m_nudRF1RX3RXGainMismatchOffVal
            // 
            this.m_nudRF1RX3RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF1RX3RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF1RX3RXGainMismatchOffVal.Location = new System.Drawing.Point(47, 227);
            this.m_nudRF1RX3RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF1RX3RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF1RX3RXGainMismatchOffVal.Name = "m_nudRF1RX3RXGainMismatchOffVal";
            this.m_nudRF1RX3RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF1RX3RXGainMismatchOffVal.TabIndex = 60;
            // 
            // m_nudRF1RX2RXGainMismatchOffVal
            // 
            this.m_nudRF1RX2RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF1RX2RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF1RX2RXGainMismatchOffVal.Location = new System.Drawing.Point(47, 200);
            this.m_nudRF1RX2RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF1RX2RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF1RX2RXGainMismatchOffVal.Name = "m_nudRF1RX2RXGainMismatchOffVal";
            this.m_nudRF1RX2RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF1RX2RXGainMismatchOffVal.TabIndex = 59;
            // 
            // m_nudRF1RX1RXGainMismatchOffVal
            // 
            this.m_nudRF1RX1RXGainMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF1RX1RXGainMismatchOffVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRF1RX1RXGainMismatchOffVal.Location = new System.Drawing.Point(47, 173);
            this.m_nudRF1RX1RXGainMismatchOffVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRF1RX1RXGainMismatchOffVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRF1RX1RXGainMismatchOffVal.Name = "m_nudRF1RX1RXGainMismatchOffVal";
            this.m_nudRF1RX1RXGainMismatchOffVal.Size = new System.Drawing.Size(61, 20);
            this.m_nudRF1RX1RXGainMismatchOffVal.TabIndex = 58;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(342, 155);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(27, 13);
            this.label39.TabIndex = 57;
            this.label39.Text = "RF1";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(139, 153);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(27, 13);
            this.label40.TabIndex = 56;
            this.label40.Text = "RF2";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(479, 152);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(27, 13);
            this.label41.TabIndex = 55;
            this.label41.Text = "RF3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "RF3";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(58, 152);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(27, 13);
            this.label42.TabIndex = 54;
            this.label42.Text = "RF1";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(417, 155);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(27, 13);
            this.label43.TabIndex = 53;
            this.label43.Text = "RF2";
            // 
            // m_chbRF2RXGainPhaseMonBitMask
            // 
            this.m_chbRF2RXGainPhaseMonBitMask.AutoSize = true;
            this.m_chbRF2RXGainPhaseMonBitMask.Checked = true;
            this.m_chbRF2RXGainPhaseMonBitMask.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chbRF2RXGainPhaseMonBitMask.Location = new System.Drawing.Point(200, 46);
            this.m_chbRF2RXGainPhaseMonBitMask.Name = "m_chbRF2RXGainPhaseMonBitMask";
            this.m_chbRF2RXGainPhaseMonBitMask.Size = new System.Drawing.Size(46, 17);
            this.m_chbRF2RXGainPhaseMonBitMask.TabIndex = 52;
            this.m_chbRF2RXGainPhaseMonBitMask.Text = "RF2";
            this.m_chbRF2RXGainPhaseMonBitMask.UseVisualStyleBackColor = true;
            // 
            // m_cboRxGainPhaseMonTxSelect
            // 
            this.m_cboRxGainPhaseMonTxSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboRxGainPhaseMonTxSelect.FormattingEnabled = true;
            this.m_cboRxGainPhaseMonTxSelect.Items.AddRange(new object[] {
            "TX0",
            "TX1"});
            this.m_cboRxGainPhaseMonTxSelect.Location = new System.Drawing.Point(458, 106);
            this.m_cboRxGainPhaseMonTxSelect.Name = "m_cboRxGainPhaseMonTxSelect";
            this.m_cboRxGainPhaseMonTxSelect.Size = new System.Drawing.Size(73, 21);
            this.m_cboRxGainPhaseMonTxSelect.TabIndex = 51;
            // 
            // m_nudRXPhaseMismatchThreshold
            // 
            this.m_nudRXPhaseMismatchThreshold.DecimalPlaces = 2;
            this.m_nudRXPhaseMismatchThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudRXPhaseMismatchThreshold.Location = new System.Drawing.Point(458, 76);
            this.m_nudRXPhaseMismatchThreshold.Name = "m_nudRXPhaseMismatchThreshold";
            this.m_nudRXPhaseMismatchThreshold.Size = new System.Drawing.Size(73, 20);
            this.m_nudRXPhaseMismatchThreshold.TabIndex = 50;
            // 
            // m_nudRXGainFlatnessErrThreshold
            // 
            this.m_nudRXGainFlatnessErrThreshold.DecimalPlaces = 1;
            this.m_nudRXGainFlatnessErrThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRXGainFlatnessErrThreshold.Location = new System.Drawing.Point(458, 49);
            this.m_nudRXGainFlatnessErrThreshold.Name = "m_nudRXGainFlatnessErrThreshold";
            this.m_nudRXGainFlatnessErrThreshold.Size = new System.Drawing.Size(73, 20);
            this.m_nudRXGainFlatnessErrThreshold.TabIndex = 49;
            // 
            // m_nudRXGainPhaseAbsErrThreshold
            // 
            this.m_nudRXGainPhaseAbsErrThreshold.DecimalPlaces = 1;
            this.m_nudRXGainPhaseAbsErrThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRXGainPhaseAbsErrThreshold.Location = new System.Drawing.Point(150, 104);
            this.m_nudRXGainPhaseAbsErrThreshold.Name = "m_nudRXGainPhaseAbsErrThreshold";
            this.m_nudRXGainPhaseAbsErrThreshold.Size = new System.Drawing.Size(87, 20);
            this.m_nudRXGainPhaseAbsErrThreshold.TabIndex = 47;
            // 
            // m_nudRXGainPhaseMonProfileIndex
            // 
            this.m_nudRXGainPhaseMonProfileIndex.Location = new System.Drawing.Point(150, 21);
            this.m_nudRXGainPhaseMonProfileIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudRXGainPhaseMonProfileIndex.Name = "m_nudRXGainPhaseMonProfileIndex";
            this.m_nudRXGainPhaseMonProfileIndex.Size = new System.Drawing.Size(87, 20);
            this.m_nudRXGainPhaseMonProfileIndex.TabIndex = 46;
            // 
            // m_nudRXGainPhaseReprotingMode
            // 
            this.m_nudRXGainPhaseReprotingMode.Location = new System.Drawing.Point(150, 71);
            this.m_nudRXGainPhaseReprotingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudRXGainPhaseReprotingMode.Name = "m_nudRXGainPhaseReprotingMode";
            this.m_nudRXGainPhaseReprotingMode.Size = new System.Drawing.Size(87, 20);
            this.m_nudRXGainPhaseReprotingMode.TabIndex = 45;
            // 
            // m_chbRF1RXGainPhaseMonBitMask
            // 
            this.m_chbRF1RXGainPhaseMonBitMask.AutoSize = true;
            this.m_chbRF1RXGainPhaseMonBitMask.Checked = true;
            this.m_chbRF1RXGainPhaseMonBitMask.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chbRF1RXGainPhaseMonBitMask.Location = new System.Drawing.Point(150, 47);
            this.m_chbRF1RXGainPhaseMonBitMask.Name = "m_chbRF1RXGainPhaseMonBitMask";
            this.m_chbRF1RXGainPhaseMonBitMask.Size = new System.Drawing.Size(46, 17);
            this.m_chbRF1RXGainPhaseMonBitMask.TabIndex = 44;
            this.m_chbRF1RXGainPhaseMonBitMask.Text = "RF1";
            this.m_chbRF1RXGainPhaseMonBitMask.UseVisualStyleBackColor = true;
            // 
            // m_chbRF3RXGainPhaseMonBitMask
            // 
            this.m_chbRF3RXGainPhaseMonBitMask.AutoSize = true;
            this.m_chbRF3RXGainPhaseMonBitMask.Checked = true;
            this.m_chbRF3RXGainPhaseMonBitMask.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chbRF3RXGainPhaseMonBitMask.Location = new System.Drawing.Point(249, 47);
            this.m_chbRF3RXGainPhaseMonBitMask.Name = "m_chbRF3RXGainPhaseMonBitMask";
            this.m_chbRF3RXGainPhaseMonBitMask.Size = new System.Drawing.Size(46, 17);
            this.m_chbRF3RXGainPhaseMonBitMask.TabIndex = 43;
            this.m_chbRF3RXGainPhaseMonBitMask.Text = "RF3";
            this.m_chbRF3RXGainPhaseMonBitMask.UseVisualStyleBackColor = true;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(291, 256);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(28, 13);
            this.label37.TabIndex = 41;
            this.label37.Text = "RX3";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(291, 231);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(28, 13);
            this.label38.TabIndex = 40;
            this.label38.Text = "RX2";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(291, 202);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(28, 13);
            this.label31.TabIndex = 39;
            this.label31.Text = "RX1";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(291, 174);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(28, 13);
            this.label32.TabIndex = 38;
            this.label32.Text = "RX0";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(291, 136);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(179, 13);
            this.label33.TabIndex = 37;
            this.label33.Text = "Rx Phase Mismatch Offset Val (Deg)";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(291, 106);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(54, 13);
            this.label34.TabIndex = 36;
            this.label34.Text = "TX Select";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(291, 78);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(166, 13);
            this.label27.TabIndex = 35;
            this.label27.Text = "Rx Phase Mismatch Thresh (Deg)";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(291, 51);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(139, 13);
            this.label28.TabIndex = 34;
            this.label28.Text = "Rx Gain Flat Err Thresh (dB)";
            // 
            // m_nudRXGainMismatchThreshold
            // 
            this.m_nudRXGainMismatchThreshold.AutoSize = true;
            this.m_nudRXGainMismatchThreshold.Location = new System.Drawing.Point(291, 28);
            this.m_nudRXGainMismatchThreshold.Name = "m_nudRXGainMismatchThreshold";
            this.m_nudRXGainMismatchThreshold.Size = new System.Drawing.Size(151, 13);
            this.m_nudRXGainMismatchThreshold.TabIndex = 33;
            this.m_nudRXGainMismatchThreshold.Text = "Rx Gain Mismatch Thresh (dB)";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(12, 176);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(28, 13);
            this.label30.TabIndex = 32;
            this.label30.Text = "RX0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "RX3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "RX2";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 202);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(28, 13);
            this.label25.TabIndex = 29;
            this.label25.Text = "RX1";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 133);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(164, 13);
            this.label26.TabIndex = 28;
            this.label26.Text = "Rx Gain Mismatch Offset Val (dB)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Rx Gain Abs Err Thresh(dB)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Reporting Mode";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "RF Freq BitMask";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Profile Index";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_nudRxSatDetectorMonSatReserved);
            this.groupBox3.Controls.Add(this.label57);
            this.groupBox3.Controls.Add(this.m_cboRxSatDetectorSatMonSelect);
            this.groupBox3.Controls.Add(this.m_nudRxSatDetectorMonSatMonRxChannelMask);
            this.groupBox3.Controls.Add(this.m_nudRxSatDetectorMonSatMonNumSlice);
            this.groupBox3.Controls.Add(this.m_nudRxSatDetectorMonPriTimeSliceDuration);
            this.groupBox3.Controls.Add(this.m_nudRxSatDetectorMonProfileIndex);
            this.groupBox3.Controls.Add(this.m_btnRXSaturationDetectorMonConfigSet);
            this.groupBox3.Controls.Add(this.label47);
            this.groupBox3.Controls.Add(this.label48);
            this.groupBox3.Controls.Add(this.label49);
            this.groupBox3.Controls.Add(this.label50);
            this.groupBox3.Controls.Add(this.label51);
            this.groupBox3.Location = new System.Drawing.Point(13, 328);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(210, 202);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rx Saturation Detector Mon Config";
            // 
            // m_nudRxSatDetectorMonSatReserved
            // 
            this.m_nudRxSatDetectorMonSatReserved.Location = new System.Drawing.Point(135, 154);
            this.m_nudRxSatDetectorMonSatReserved.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudRxSatDetectorMonSatReserved.Name = "m_nudRxSatDetectorMonSatReserved";
            this.m_nudRxSatDetectorMonSatReserved.Size = new System.Drawing.Size(70, 20);
            this.m_nudRxSatDetectorMonSatReserved.TabIndex = 64;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(5, 159);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(53, 13);
            this.label57.TabIndex = 63;
            this.label57.Text = "Reserved";
            // 
            // m_cboRxSatDetectorSatMonSelect
            // 
            this.m_cboRxSatDetectorSatMonSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboRxSatDetectorSatMonSelect.FormattingEnabled = true;
            this.m_cboRxSatDetectorSatMonSelect.Items.AddRange(new object[] {
            "ADC",
            "ADC and IFA1"});
            this.m_cboRxSatDetectorSatMonSelect.Location = new System.Drawing.Point(114, 101);
            this.m_cboRxSatDetectorSatMonSelect.Name = "m_cboRxSatDetectorSatMonSelect";
            this.m_cboRxSatDetectorSatMonSelect.Size = new System.Drawing.Size(87, 21);
            this.m_cboRxSatDetectorSatMonSelect.TabIndex = 60;
            // 
            // m_nudRxSatDetectorMonSatMonRxChannelMask
            // 
            this.m_nudRxSatDetectorMonSatMonRxChannelMask.Location = new System.Drawing.Point(134, 129);
            this.m_nudRxSatDetectorMonSatMonRxChannelMask.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudRxSatDetectorMonSatMonRxChannelMask.Name = "m_nudRxSatDetectorMonSatMonRxChannelMask";
            this.m_nudRxSatDetectorMonSatMonRxChannelMask.Size = new System.Drawing.Size(70, 20);
            this.m_nudRxSatDetectorMonSatMonRxChannelMask.TabIndex = 59;
            this.m_nudRxSatDetectorMonSatMonRxChannelMask.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_nudRxSatDetectorMonSatMonNumSlice
            // 
            this.m_nudRxSatDetectorMonSatMonNumSlice.Location = new System.Drawing.Point(134, 73);
            this.m_nudRxSatDetectorMonSatMonNumSlice.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.m_nudRxSatDetectorMonSatMonNumSlice.Name = "m_nudRxSatDetectorMonSatMonNumSlice";
            this.m_nudRxSatDetectorMonSatMonNumSlice.Size = new System.Drawing.Size(70, 20);
            this.m_nudRxSatDetectorMonSatMonNumSlice.TabIndex = 58;
            this.m_nudRxSatDetectorMonSatMonNumSlice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_nudRxSatDetectorMonPriTimeSliceDuration
            // 
            this.m_nudRxSatDetectorMonPriTimeSliceDuration.DecimalPlaces = 2;
            this.m_nudRxSatDetectorMonPriTimeSliceDuration.Increment = new decimal(new int[] {
            16,
            0,
            0,
            131072});
            this.m_nudRxSatDetectorMonPriTimeSliceDuration.Location = new System.Drawing.Point(134, 46);
            this.m_nudRxSatDetectorMonPriTimeSliceDuration.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudRxSatDetectorMonPriTimeSliceDuration.Name = "m_nudRxSatDetectorMonPriTimeSliceDuration";
            this.m_nudRxSatDetectorMonPriTimeSliceDuration.Size = new System.Drawing.Size(70, 20);
            this.m_nudRxSatDetectorMonPriTimeSliceDuration.TabIndex = 57;
            // 
            // m_nudRxSatDetectorMonProfileIndex
            // 
            this.m_nudRxSatDetectorMonProfileIndex.Location = new System.Drawing.Point(134, 22);
            this.m_nudRxSatDetectorMonProfileIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudRxSatDetectorMonProfileIndex.Name = "m_nudRxSatDetectorMonProfileIndex";
            this.m_nudRxSatDetectorMonProfileIndex.Size = new System.Drawing.Size(70, 20);
            this.m_nudRxSatDetectorMonProfileIndex.TabIndex = 56;
            // 
            // m_btnRXSaturationDetectorMonConfigSet
            // 
            this.m_btnRXSaturationDetectorMonConfigSet.Location = new System.Drawing.Point(129, 177);
            this.m_btnRXSaturationDetectorMonConfigSet.Name = "m_btnRXSaturationDetectorMonConfigSet";
            this.m_btnRXSaturationDetectorMonConfigSet.Size = new System.Drawing.Size(75, 23);
            this.m_btnRXSaturationDetectorMonConfigSet.TabIndex = 53;
            this.m_btnRXSaturationDetectorMonConfigSet.Text = "Set";
            this.m_btnRXSaturationDetectorMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(4, 132);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(91, 13);
            this.label47.TabIndex = 48;
            this.label47.Text = "Rx Channel Mask";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(4, 46);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(127, 13);
            this.label48.TabIndex = 52;
            this.label48.Text = "Primary Tim Slice Dur (µs)";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(4, 106);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(80, 13);
            this.label49.TabIndex = 50;
            this.label49.Text = "Sat Mon Select";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(4, 21);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(65, 13);
            this.label50.TabIndex = 51;
            this.label50.Text = "Profile Index";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(4, 75);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(60, 13);
            this.label51.TabIndex = 49;
            this.label51.Text = "Num Slices";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_chbRF3RXNoiseMon);
            this.groupBox4.Controls.Add(this.m_chbRF1RXNoiseMon);
            this.groupBox4.Controls.Add(this.m_chbRF2RXNoiseMon);
            this.groupBox4.Controls.Add(this.m_nudRXNoiseFigureThreshold);
            this.groupBox4.Controls.Add(this.m_nudRxNoiseFigureReportingMode);
            this.groupBox4.Controls.Add(this.m_nudRXNoiseMonProfileIndex);
            this.groupBox4.Controls.Add(this.m_btnRXNoiseMonConfigSet);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(581, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 204);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Monitoring RX Noise Figure Config";
            // 
            // m_chbRF3RXNoiseMon
            // 
            this.m_chbRF3RXNoiseMon.AutoSize = true;
            this.m_chbRF3RXNoiseMon.Checked = true;
            this.m_chbRF3RXNoiseMon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chbRF3RXNoiseMon.Location = new System.Drawing.Point(239, 44);
            this.m_chbRF3RXNoiseMon.Name = "m_chbRF3RXNoiseMon";
            this.m_chbRF3RXNoiseMon.Size = new System.Drawing.Size(46, 17);
            this.m_chbRF3RXNoiseMon.TabIndex = 50;
            this.m_chbRF3RXNoiseMon.Text = "RF3";
            this.m_chbRF3RXNoiseMon.UseVisualStyleBackColor = true;
            // 
            // m_chbRF1RXNoiseMon
            // 
            this.m_chbRF1RXNoiseMon.AutoSize = true;
            this.m_chbRF1RXNoiseMon.Checked = true;
            this.m_chbRF1RXNoiseMon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chbRF1RXNoiseMon.Location = new System.Drawing.Point(135, 44);
            this.m_chbRF1RXNoiseMon.Name = "m_chbRF1RXNoiseMon";
            this.m_chbRF1RXNoiseMon.Size = new System.Drawing.Size(46, 17);
            this.m_chbRF1RXNoiseMon.TabIndex = 49;
            this.m_chbRF1RXNoiseMon.Text = "RF1";
            this.m_chbRF1RXNoiseMon.UseVisualStyleBackColor = true;
            // 
            // m_chbRF2RXNoiseMon
            // 
            this.m_chbRF2RXNoiseMon.AutoSize = true;
            this.m_chbRF2RXNoiseMon.Checked = true;
            this.m_chbRF2RXNoiseMon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chbRF2RXNoiseMon.Location = new System.Drawing.Point(187, 44);
            this.m_chbRF2RXNoiseMon.Name = "m_chbRF2RXNoiseMon";
            this.m_chbRF2RXNoiseMon.Size = new System.Drawing.Size(46, 17);
            this.m_chbRF2RXNoiseMon.TabIndex = 48;
            this.m_chbRF2RXNoiseMon.Text = "RF2";
            this.m_chbRF2RXNoiseMon.UseVisualStyleBackColor = true;
            // 
            // m_nudRXNoiseFigureThreshold
            // 
            this.m_nudRXNoiseFigureThreshold.DecimalPlaces = 1;
            this.m_nudRXNoiseFigureThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRXNoiseFigureThreshold.Location = new System.Drawing.Point(135, 94);
            this.m_nudRXNoiseFigureThreshold.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.m_nudRXNoiseFigureThreshold.Name = "m_nudRXNoiseFigureThreshold";
            this.m_nudRXNoiseFigureThreshold.Size = new System.Drawing.Size(87, 20);
            this.m_nudRXNoiseFigureThreshold.TabIndex = 47;
            // 
            // m_nudRxNoiseFigureReportingMode
            // 
            this.m_nudRxNoiseFigureReportingMode.Location = new System.Drawing.Point(135, 68);
            this.m_nudRxNoiseFigureReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudRxNoiseFigureReportingMode.Name = "m_nudRxNoiseFigureReportingMode";
            this.m_nudRxNoiseFigureReportingMode.Size = new System.Drawing.Size(87, 20);
            this.m_nudRxNoiseFigureReportingMode.TabIndex = 46;
            // 
            // m_nudRXNoiseMonProfileIndex
            // 
            this.m_nudRXNoiseMonProfileIndex.Location = new System.Drawing.Point(135, 19);
            this.m_nudRXNoiseMonProfileIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudRXNoiseMonProfileIndex.Name = "m_nudRXNoiseMonProfileIndex";
            this.m_nudRXNoiseMonProfileIndex.Size = new System.Drawing.Size(87, 20);
            this.m_nudRXNoiseMonProfileIndex.TabIndex = 45;
            // 
            // m_btnRXNoiseMonConfigSet
            // 
            this.m_btnRXNoiseMonConfigSet.Location = new System.Drawing.Point(147, 160);
            this.m_btnRXNoiseMonConfigSet.Name = "m_btnRXNoiseMonConfigSet";
            this.m_btnRXNoiseMonConfigSet.Size = new System.Drawing.Size(75, 23);
            this.m_btnRXNoiseMonConfigSet.TabIndex = 44;
            this.m_btnRXNoiseMonConfigSet.Text = "Set";
            this.m_btnRXNoiseMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(4, 47);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(86, 13);
            this.label35.TabIndex = 43;
            this.label35.Text = "RF Freq BitMask";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Rx Noise Fig Thresh (dB)";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(4, 19);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 13);
            this.label36.TabIndex = 42;
            this.label36.Text = "Profile Index";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Reporting Mode";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_nudRxIFStageIFAGainErrThreshold);
            this.groupBox5.Controls.Add(this.m_nudRxIFStageLPFCuttoffFreqErrThreshold);
            this.groupBox5.Controls.Add(this.m_nudRxIFStageHPFCuttoffFreqErrThreshold);
            this.groupBox5.Controls.Add(this.m_nudRxIFStageReportingMode);
            this.groupBox5.Controls.Add(this.m_nudRXIFStageMonProfileIndex);
            this.groupBox5.Controls.Add(this.f0000ff);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.label44);
            this.groupBox5.Controls.Add(this.label45);
            this.groupBox5.Controls.Add(this.label46);
            this.groupBox5.Location = new System.Drawing.Point(873, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(279, 204);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Monitoring RX IFStage Config";
            // 
            // m_nudRxIFStageIFAGainErrThreshold
            // 
            this.m_nudRxIFStageIFAGainErrThreshold.DecimalPlaces = 1;
            this.m_nudRxIFStageIFAGainErrThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudRxIFStageIFAGainErrThreshold.Location = new System.Drawing.Point(170, 132);
            this.m_nudRxIFStageIFAGainErrThreshold.Name = "m_nudRxIFStageIFAGainErrThreshold";
            this.m_nudRxIFStageIFAGainErrThreshold.Size = new System.Drawing.Size(87, 20);
            this.m_nudRxIFStageIFAGainErrThreshold.TabIndex = 54;
            // 
            // m_nudRxIFStageLPFCuttoffFreqErrThreshold
            // 
            this.m_nudRxIFStageLPFCuttoffFreqErrThreshold.Location = new System.Drawing.Point(170, 102);
            this.m_nudRxIFStageLPFCuttoffFreqErrThreshold.Name = "m_nudRxIFStageLPFCuttoffFreqErrThreshold";
            this.m_nudRxIFStageLPFCuttoffFreqErrThreshold.Size = new System.Drawing.Size(87, 20);
            this.m_nudRxIFStageLPFCuttoffFreqErrThreshold.TabIndex = 53;
            // 
            // m_nudRxIFStageHPFCuttoffFreqErrThreshold
            // 
            this.m_nudRxIFStageHPFCuttoffFreqErrThreshold.Location = new System.Drawing.Point(170, 71);
            this.m_nudRxIFStageHPFCuttoffFreqErrThreshold.Name = "m_nudRxIFStageHPFCuttoffFreqErrThreshold";
            this.m_nudRxIFStageHPFCuttoffFreqErrThreshold.Size = new System.Drawing.Size(87, 20);
            this.m_nudRxIFStageHPFCuttoffFreqErrThreshold.TabIndex = 51;
            // 
            // m_nudRxIFStageReportingMode
            // 
            this.m_nudRxIFStageReportingMode.Location = new System.Drawing.Point(170, 42);
            this.m_nudRxIFStageReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudRxIFStageReportingMode.Name = "m_nudRxIFStageReportingMode";
            this.m_nudRxIFStageReportingMode.Size = new System.Drawing.Size(87, 20);
            this.m_nudRxIFStageReportingMode.TabIndex = 50;
            // 
            // m_nudRXIFStageMonProfileIndex
            // 
            this.m_nudRXIFStageMonProfileIndex.Location = new System.Drawing.Point(170, 15);
            this.m_nudRXIFStageMonProfileIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudRXIFStageMonProfileIndex.Name = "m_nudRXIFStageMonProfileIndex";
            this.m_nudRXIFStageMonProfileIndex.Size = new System.Drawing.Size(87, 20);
            this.m_nudRXIFStageMonProfileIndex.TabIndex = 49;
            // 
            // f0000ff
            // 
            this.f0000ff.Location = new System.Drawing.Point(182, 160);
            this.f0000ff.Name = "f0000ff";
            this.f0000ff.Size = new System.Drawing.Size(75, 23);
            this.f0000ff.TabIndex = 48;
            this.f0000ff.Text = "Set";
            this.f0000ff.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "IFA Gain Err Thresh (dB)";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(4, 43);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 13);
            this.label29.TabIndex = 47;
            this.label29.Text = "Reporting Mode";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(4, 105);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(150, 13);
            this.label44.TabIndex = 45;
            this.label44.Text = "LPF Cutoff Freq Err Thresh (%)";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(4, 19);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(65, 13);
            this.label45.TabIndex = 46;
            this.label45.Text = "Profile Index";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(4, 73);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(152, 13);
            this.label46.TabIndex = 44;
            this.label46.Text = "HPF Cutoff Freq Err Thresh (%)";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.m_nudSigImgMonPriTimeSliceNumSamples);
            this.groupBox8.Controls.Add(this.m_nudSigImgMonNumSlice);
            this.groupBox8.Controls.Add(this.m_btnSignalandImageMonConfigSet);
            this.groupBox8.Controls.Add(this.label53);
            this.groupBox8.Controls.Add(this.m_nudSigImgMonProfileIndex);
            this.groupBox8.Controls.Add(this.label55);
            this.groupBox8.Controls.Add(this.label56);
            this.groupBox8.Location = new System.Drawing.Point(234, 328);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(201, 195);
            this.groupBox8.TabIndex = 19;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Rx Signal and Image Mon Config";
            // 
            // m_nudSigImgMonPriTimeSliceNumSamples
            // 
            this.m_nudSigImgMonPriTimeSliceNumSamples.Location = new System.Drawing.Point(120, 94);
            this.m_nudSigImgMonPriTimeSliceNumSamples.Name = "m_nudSigImgMonPriTimeSliceNumSamples";
            this.m_nudSigImgMonPriTimeSliceNumSamples.Size = new System.Drawing.Size(70, 20);
            this.m_nudSigImgMonPriTimeSliceNumSamples.TabIndex = 55;
            // 
            // m_nudSigImgMonNumSlice
            // 
            this.m_nudSigImgMonNumSlice.Location = new System.Drawing.Point(120, 49);
            this.m_nudSigImgMonNumSlice.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.m_nudSigImgMonNumSlice.Name = "m_nudSigImgMonNumSlice";
            this.m_nudSigImgMonNumSlice.Size = new System.Drawing.Size(70, 20);
            this.m_nudSigImgMonNumSlice.TabIndex = 54;
            // 
            // m_btnSignalandImageMonConfigSet
            // 
            this.m_btnSignalandImageMonConfigSet.Location = new System.Drawing.Point(115, 160);
            this.m_btnSignalandImageMonConfigSet.Name = "m_btnSignalandImageMonConfigSet";
            this.m_btnSignalandImageMonConfigSet.Size = new System.Drawing.Size(75, 23);
            this.m_btnSignalandImageMonConfigSet.TabIndex = 53;
            this.m_btnSignalandImageMonConfigSet.Text = "Set";
            this.m_btnSignalandImageMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(4, 51);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(60, 13);
            this.label53.TabIndex = 52;
            this.label53.Text = "Num Slices";
            // 
            // m_nudSigImgMonProfileIndex
            // 
            this.m_nudSigImgMonProfileIndex.Location = new System.Drawing.Point(120, 20);
            this.m_nudSigImgMonProfileIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudSigImgMonProfileIndex.Name = "m_nudSigImgMonProfileIndex";
            this.m_nudSigImgMonProfileIndex.Size = new System.Drawing.Size(70, 20);
            this.m_nudSigImgMonProfileIndex.TabIndex = 52;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(4, 20);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(65, 13);
            this.label55.TabIndex = 51;
            this.label55.Text = "Profile Index";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(4, 77);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(131, 13);
            this.label56.TabIndex = 49;
            this.label56.Text = "NumSamplesPerTimeSlice";
            // 
            // AnalogMon2Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Name = "AnalogMon2Config";
            this.Size = new System.Drawing.Size(1165, 581);
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonReportingMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonAnaTempThreshMin)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonDigTempThreshMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonAnaTempThreshMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonTempDiffThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTempMonDigTempThreshMax)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSynthFrequencyProfileIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSynthFrequencyMonStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSynthFrequencyMonFreqErrorThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSynthFrequencyMonReportingMode)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxMixerIpPowMonMaxThresholds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxMixerIpPowMonMinThresholds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxMixerIpPowMonProfielIdnex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxMixerIpPowMonReportingMode)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXGainMismatchThresholds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX4RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX3RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX2RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX1RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX4RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX3RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX2RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX1RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX4RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX3RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX2RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX1RXPhaseMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX4RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX3RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX2RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF3RX1RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX4RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX3RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX2RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF2RX1RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX4RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX3RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX2RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRF1RX1RXGainMismatchOffVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXPhaseMismatchThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXGainFlatnessErrThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXGainPhaseAbsErrThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXGainPhaseMonProfileIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXGainPhaseReprotingMode)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxSatDetectorMonSatReserved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxSatDetectorMonSatMonRxChannelMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxSatDetectorMonSatMonNumSlice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxSatDetectorMonPriTimeSliceDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxSatDetectorMonProfileIndex)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXNoiseFigureThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxNoiseFigureReportingMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXNoiseMonProfileIndex)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxIFStageIFAGainErrThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxIFStageLPFCuttoffFreqErrThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxIFStageHPFCuttoffFreqErrThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxIFStageReportingMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRXIFStageMonProfileIndex)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSigImgMonPriTimeSliceNumSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSigImgMonNumSlice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSigImgMonProfileIndex)).EndInit();
            this.ResumeLayout(false);

		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;
		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;
		private frmAR1Main m_MainForm;
		private MonRXGainPhaseConfigParameters m_MonRXGainPhaseConfigParameters;
		private MonRXNoiseFigureConfigParameters m_MonRXNoiseFigureConfigParameters;
		private MonRXIFStageConfigParameters m_MonRXIFStageConfigParameters;
		private MonRxSaturationDetectorConfigParameters m_MonRxSaturationDetectorConfigParameters;
		private MonSignalAndImageConfigParameters m_MonSignalAndImageConfigParameters;
		private MonTemperatureConfigParameters m_MonTemperatureConfigParameters;
		private MonSynthFrequencyConfigParameters m_MonSynthFrequencyConfigParameters;
		private MonRxMixerInputPowerConfigParameters m_MonRxMixerInputPowerConfigParameters;
		private IContainer components;
		private NumericUpDown m_nudTempMonReportingMode;
		private Label label1;
		private Label label3;
		private NumericUpDown m_nudTempMonAnaTempThreshMin;
		private Button m_btnTemperatureMonConfigSet;
		private GroupBox groupBox6;
		private Label label13;
		private Label label14;
		private NumericUpDown m_nudTempMonDigTempThreshMin;
		private NumericUpDown m_nudTempMonAnaTempThreshMax;
		private NumericUpDown m_nudTempMonTempDiffThresh;
		private NumericUpDown m_nudTempMonDigTempThreshMax;
		private Label label15;
		private Label label16;
		private GroupBox groupBox2;
		private NumericUpDown m_nudSynthFrequencyProfileIndex;
		private NumericUpDown m_nudSynthFrequencyMonStartTime;
		private NumericUpDown m_nudSynthFrequencyMonFreqErrorThreshold;
		private NumericUpDown m_nudSynthFrequencyMonReportingMode;
		private Label label20;
		private Label label19;
		private Label label18;
		private Label label17;
		private Button m_btnSynthFrequencyMonConfigSet;
		private GroupBox groupBox7;
		private NumericUpDown m_nudRxMixerIpPowMonProfielIdnex;
		private NumericUpDown m_nudRxMixerIpPowMonReportingMode;
		private Label label24;
		private Label label23;
		private Label label22;
		private Label label21;
		private CheckBox m_chbRxMixerIpPowMonTx3Ena;
		private CheckBox m_chbRxMixerIpPowMonTx2Ena;
		private CheckBox m_chbRxMixerIpPowMonTx1Ena;
		private NumericUpDown m_nudRxMixerIpPowMonMinThresholds;
		private Button m_btnRxMixerInoutPowerMonConfigSet;
		private GroupBox groupBox1;
		private GroupBox groupBox3;
		private GroupBox groupBox4;
		private GroupBox groupBox5;
		private GroupBox groupBox8;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label2;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label37;
		private Label label38;
		private Label label31;
		private Label label32;
		private Label label33;
		private Label label34;
		private Label label27;
		private Label label28;

		private Label m_nudRXGainMismatchThreshold;
		private Label label30;
		private Label label11;
		private Label label12;
		private Label label25;
		private Label label26;
		private Label label35;
		private Label label36;
		private CheckBox m_chbRF1RXGainPhaseMonBitMask;
		private CheckBox m_chbRF3RXGainPhaseMonBitMask;
		private NumericUpDown m_nudRXPhaseMismatchThreshold;
		private NumericUpDown m_nudRXGainFlatnessErrThreshold;
		private NumericUpDown m_nudRXGainPhaseAbsErrThreshold;
		private NumericUpDown m_nudRXGainPhaseMonProfileIndex;
		private NumericUpDown m_nudRXGainPhaseReprotingMode;
		private ComboBox m_cboRxGainPhaseMonTxSelect;
		private CheckBox m_chbRF2RXGainPhaseMonBitMask;
		private Label label39;
		private Label label40;
		private Label label41;
		private Label label42;
		private Label label43;
		private NumericUpDown m_nudRF1RX4RXGainMismatchOffVal;
		private NumericUpDown m_nudRF1RX3RXGainMismatchOffVal;
		private NumericUpDown m_nudRF1RX2RXGainMismatchOffVal;
		private NumericUpDown m_nudRF1RX1RXGainMismatchOffVal;
		private Button m_btnRxGainPhaseMonConfigSet;
		private NumericUpDown m_nudRF3RX4RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF3RX3RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF3RX2RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF3RX1RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF2RX4RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF2RX3RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF2RX2RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF2RX1RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF1RX4RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF1RX3RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF1RX2RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF1RX1RXPhaseMismatchOffVal;
		private NumericUpDown m_nudRF3RX4RXGainMismatchOffVal;
		private NumericUpDown m_nudRF3RX3RXGainMismatchOffVal;
		private NumericUpDown m_nudRF3RX2RXGainMismatchOffVal;
		private NumericUpDown m_nudRF3RX1RXGainMismatchOffVal;
		private NumericUpDown m_nudRF2RX4RXGainMismatchOffVal;
		private NumericUpDown m_nudRF2RX3RXGainMismatchOffVal;
		private NumericUpDown m_nudRF2RX2RXGainMismatchOffVal;
		private NumericUpDown m_nudRF2RX1RXGainMismatchOffVal;
		private NumericUpDown m_nudRXGainMismatchThresholds;
		private Label label29;
		private Label label44;
		private Label label45;
		private Label label46;
		private Label label47;
		private Label label48;
		private Label label49;
		private Label label50;
		private Label label51;
		private Label label53;
		private Label label55;
		private Label label56;
		private Button m_btnRXSaturationDetectorMonConfigSet;
		private Button m_btnRXNoiseMonConfigSet;
		private Button f0000ff;
		private Button m_btnSignalandImageMonConfigSet;
		private NumericUpDown m_nudRXNoiseFigureThreshold;
		private NumericUpDown m_nudRxNoiseFigureReportingMode;
		private NumericUpDown m_nudRXNoiseMonProfileIndex;
		private NumericUpDown m_nudRxIFStageIFAGainErrThreshold;
		private NumericUpDown m_nudRxIFStageLPFCuttoffFreqErrThreshold;
		private NumericUpDown m_nudRxIFStageHPFCuttoffFreqErrThreshold;
		private NumericUpDown m_nudRxIFStageReportingMode;
		private NumericUpDown m_nudRXIFStageMonProfileIndex;
		private NumericUpDown m_nudSigImgMonProfileIndex;
		private CheckBox m_chbRF3RXNoiseMon;
		private CheckBox m_chbRF1RXNoiseMon;
		private CheckBox m_chbRF2RXNoiseMon;
		private NumericUpDown m_nudSigImgMonPriTimeSliceNumSamples;
		private NumericUpDown m_nudSigImgMonNumSlice;
		private NumericUpDown m_nudRxSatDetectorMonSatMonRxChannelMask;
		private NumericUpDown m_nudRxSatDetectorMonSatMonNumSlice;
		private NumericUpDown m_nudRxSatDetectorMonPriTimeSliceDuration;
		private NumericUpDown m_nudRxSatDetectorMonProfileIndex;
		private ComboBox m_cboRxSatDetectorSatMonSelect;
		private Label label54;
		private Label label52;
		private NumericUpDown m_nudRxMixerIpPowMonMaxThresholds;
		private NumericUpDown m_nudRxSatDetectorMonSatReserved;
		private Label label57;
	}
}
