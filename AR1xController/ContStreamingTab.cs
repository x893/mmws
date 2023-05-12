using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AR1xController
{
	public class ContStreamingTab : UserControl
	{
		public ContStreamingTab()
		{
			InitializeComponent();
			PostInit();
			m_MainForm = m_GuiManager.MainTsForm;
			m_ContStreamParams = m_GuiManager.TsParams.ContStreamParams;
			m_BasicConfigurationForAnalysisParams = m_GuiManager.TsParams.BasicConfigurationForAnalysisParams;
			m_MeasureTxPowerParams = m_GuiManager.TsParams.MeasureTxPowerParams;
			f0001a1.Text = string.Concat(Path.GetDirectoryName(Application.StartupPath), "\\PostProc\\adc_data.bin");
			IntializeDefaultValuesOfBasicConfigurationForAnalysis();
			m_nudRxIPPower.Value = -35m;
			m_nudIFToneFreq.Value = 1m;
			m_nudDigOutSampleRate.Value = 9000m;
			m_cboRFGainTarget.SelectedIndex = 0;
			m_cboVCOSelect.SelectedIndex = 0;
		}

		public void IntializeDefaultValuesOfBasicConfigurationForAnalysis()
		{
			m_nudNumOfSamples.Value = 16384m;
			m_nudFFTSize.Value = 16384m;
			m_nudNumOfAverages.Value = 1m;
			m_cboWindowSelection.SelectedIndex = 0;
			m_ChkEnaTriggerCaptureYes.Checked = false;
			m_cboWindowCompensation.SelectedIndex = 1;
		}

		public bool UpdateContStreamConfig(RootObject jobject, int p1)
		{
			bool result;
			try
			{
				if (jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.isConfigured == 0)
				{
					string msg = string.Format("Missing Continous Mode Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg);
				}
				else
				{
					m_nudStartFreqConst.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.startFreqConst_GHz;
					m_nudDigOutSampleRate.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.digOutSampleRate;
					m_nudProfileRxGain.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.rxGain_dB, 16) & 63);
					m_cboProfileHpf1.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.hpfCornerFreq1;
					m_cboProfileHpf2.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.hpfCornerFreq2;
					m_nudTx1OutPowerBackoffCode.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.txOutPowerBackoffCode, 16) & 255);
					m_nudTx2OutPowerBackoffCode.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.txOutPowerBackoffCode, 16) & 65280) >> 8;
					m_nudTx3OutPowerBackoffCode.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.txOutPowerBackoffCode, 16) & 16711680) >> 16;
					m_nudTx1PhaseShifter.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.txPhaseShifter, 16) & 255);
					m_nudTx2PhaseShifter.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.txPhaseShifter, 16) & 65280) >> 8;
					m_nudTx3PhaseShifter.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.txPhaseShifter, 16) & 16711680) >> 16;
					if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.rxGain_dB, 16) & 192) >> 6 == 0)
					{
						m_cboRFGainTarget.SelectedIndex = 0;
					}
					else if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.rxGain_dB, 16) & 192) >> 6 == 1)
					{
						m_cboRFGainTarget.SelectedIndex = 1;
					}
					else if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.rxGain_dB, 16) & 192) >> 6 == 3)
					{
						m_cboRFGainTarget.SelectedIndex = 2;
					}
					if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.vcoSelect, 16) & 2) >> 1 == 0)
					{
						m_cboVCOSelect.SelectedIndex = 0;
					}
					else if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.vcoSelect, 16) & 2) >> 1 == 1)
					{
						m_cboVCOSelect.SelectedIndex = 1;
					}
					m_ChkForceVCOSelect.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlContModeCfg_t.vcoSelect, 16) & 1) == 1);
				}
				result = true;
			}
			catch
			{
				string msg2 = string.Format("Cont Streaming Config Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg2);
				result = false;
			}
			return result;
		}

		public bool UpdateContStrData()
		{
			if (base.InvokeRequired)
				return (bool)base.Invoke(new del_b_v(UpdateContStrData));

			bool result;
			try
			{
				m_ContStreamParams.startFreqConst = (double)m_nudStartFreqConst.Value;
				m_ContStreamParams.tx1OutPowerBackoffCode = (uint)m_nudTx1OutPowerBackoffCode.Value;
				m_ContStreamParams.tx2OutPowerBackoffCode = (uint)m_nudTx2OutPowerBackoffCode.Value;
				m_ContStreamParams.tx3OutPowerBackoffCode = (uint)m_nudTx3OutPowerBackoffCode.Value;
				m_ContStreamParams.tx1PhaseShifter = (double)m_nudTx1PhaseShifter.Value;
				m_ContStreamParams.tx2PhaseShifter = (double)m_nudTx2PhaseShifter.Value;
				m_ContStreamParams.tx3PhaseShifter = (uint)m_nudTx3PhaseShifter.Value;
				m_ContStreamParams.digOutSampleRate = (ushort)m_nudDigOutSampleRate.Value;
				m_ContStreamParams.hpfCornerFreq1 = (char)m_cboProfileHpf1.SelectedIndex;
				m_ContStreamParams.hpfCornerFreq2 = (char)m_cboProfileHpf2.SelectedIndex;
				m_ContStreamParams.rxGain = (char)m_nudProfileRxGain.Value;

				if (m_cboRFGainTarget.SelectedIndex == 0)
					m_ContStreamParams.RFGainTarget = 0;
				else if (m_cboRFGainTarget.SelectedIndex == 1)
					m_ContStreamParams.RFGainTarget = 1;
				else if (m_cboRFGainTarget.SelectedIndex == 2)
					m_ContStreamParams.RFGainTarget = 3;
				if (m_cboVCOSelect.SelectedIndex == 0)
					m_ContStreamParams.VCOSelect = 0;
				else if (m_cboVCOSelect.SelectedIndex == 1)
					m_ContStreamParams.VCOSelect = 1;

				m_ContStreamParams.ForceVCOSelect = (byte)(m_ChkForceVCOSelect.Checked ? 1 : 0);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMtLbContStrData()
		{
			if (base.InvokeRequired)
				return (bool)base.Invoke(new del_b_v(UpdateMtLbContStrData));

			bool result;
			try
			{
				m_ContStreamParams.mtlbAdcPath = f0001a1.Text;
				m_BasicConfigurationForAnalysisParams.NumberOfSamples = (uint)m_nudNumOfSamples.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public string iGetMtLbPostProcPathForDataCapture()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(iGetMtLbPostProcPathForDataCapture);
				return (string)base.Invoke(method);
			}
			return f0001a1.Text;
		}

		public bool ChangeStatusFromStartCaptureToStopCaptureInContStream(bool status)
		{
			if (base.InvokeRequired)
				return (bool)base.Invoke(new del_b_b(ChangeStatusFromStartCaptureToStopCaptureInContStream), status);

			bool result;
			try
			{
				if (status)
					m_btnContinuousADCCapture.Text = "StopCapture";
				else
					m_btnContinuousADCCapture.Text = "Capture";
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public string GetContStreamDumpFilePath()
		{
			return m_ContStreamParams.mtlbAdcPath;
		}

		public int GetContStreamNoOfSamples()
		{
			return m_ContStreamParams.noOfAdcSamples;
		}

		public bool UpdateContStrConfigData()
		{
			if (base.InvokeRequired)
				return (bool)base.Invoke(new del_b_v(UpdateContStrConfigData));

			bool result;
			try
			{
				m_nudStartFreqConst.Value = (decimal)m_ContStreamParams.startFreqConst;
				m_nudDigOutSampleRate.Value = m_ContStreamParams.digOutSampleRate;
				m_nudProfileRxGain.Value = m_ContStreamParams.rxGain;
				m_cboProfileHpf1.SelectedIndex = (int)m_ContStreamParams.hpfCornerFreq1;
				m_cboProfileHpf2.SelectedIndex = (int)m_ContStreamParams.hpfCornerFreq2;
				m_nudTx1OutPowerBackoffCode.Value = m_ContStreamParams.tx1OutPowerBackoffCode;
				m_nudTx2OutPowerBackoffCode.Value = m_ContStreamParams.tx2OutPowerBackoffCode;
				m_nudTx3OutPowerBackoffCode.Value = m_ContStreamParams.tx3OutPowerBackoffCode;
				m_nudTx1PhaseShifter.Value = (decimal)m_ContStreamParams.tx1PhaseShifter;
				m_nudTx2PhaseShifter.Value = (decimal)m_ContStreamParams.tx2PhaseShifter;
				m_nudTx3PhaseShifter.Value = (decimal)m_ContStreamParams.tx3PhaseShifter;

				if (m_ContStreamParams.RFGainTarget == 0)
					m_cboRFGainTarget.SelectedIndex = 0;
				else if (m_ContStreamParams.RFGainTarget == 1)
					m_cboRFGainTarget.SelectedIndex = 1;
				else if (m_ContStreamParams.RFGainTarget == 3)
					m_cboRFGainTarget.SelectedIndex = 2;

				if (m_ContStreamParams.VCOSelect == 0)
					m_cboVCOSelect.SelectedIndex = 0;
				else if (m_ContStreamParams.VCOSelect == 1)
					m_cboVCOSelect.SelectedIndex = 1;

				m_ChkForceVCOSelect.Checked = (m_ContStreamParams.ForceVCOSelect == 1);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetContStrConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetContStrConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetContStrConfig()
		{
			iSetContStrConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetContStrAsync()
		{
			new del_v_v(iSetContStrConfig).BeginInvoke(null, null);
		}

		private void m_btnProfileSet_Click(object sender, EventArgs p1)
		{
			iSetContStrAsync();
		}

		private int iEnblContStrConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iEnblContStrConfig_Gui(is_starting_op, is_ending_op, (ushort)GlobalRef.g_RadarDeviceId);
		}

		private void iEnblContStrConfig()
		{
			iEnblContStrConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iEnblContStrAsync()
		{
			new del_v_v(iEnblContStrConfig).BeginInvoke(null, null);
		}

		private void m_btnContStrEn_Click(object sender, EventArgs p1)
		{
			iEnblContStrAsync();
		}

		public void iSetContStrBtnText(string text)
		{
			if (base.InvokeRequired)
			{
                base.Invoke(new del_v_s(iSetContStrBtnText), text);
				return;
			}
			f0001a0.Text = text;
		}

		public string iGetContStrBtnText()
		{
			if (base.InvokeRequired)
				return (string)base.Invoke(new del_s_v(iGetContStrBtnText));
			UpdateContStrData();
			return f0001a0.Text;
		}

		private int iStartContStrConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iStartContStrConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iStartContStrConfig()
		{
			iStartContStrConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iStartContStrAsync()
		{
			new del_v_v(iStartContStrConfig).BeginInvoke(null, null);
		}

		private void m_btnContStrStrt_Click(object sender, EventArgs p1)
		{
			iStartContStrAsync();
		}

		private void iSetPathInCombo(string path, ComboBox combo)
		{
			if (base.InvokeRequired)
			{
                base.Invoke(new del_SetPathInCombo(iSetPathInCombo), path, combo);
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

		private string iHandleBrowseFiles(string file_type, string current_path)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (!(file_type == "FW") && !(file_type == "BIN"))
			{
				if (!(file_type == "INI"))
				{
					if (file_type == "DLL")
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

		private void m_btnAdcDataTar_Click(object sender, EventArgs p1)
		{
			m_fdlgContStrData.InitialDirectory = "C:";
			m_fdlgContStrData.RestoreDirectory = true;
			string text = iHandleBrowseFiles("bin", f0001a1.Text);
			if (!string.IsNullOrEmpty(text))
			{
				iSetPathInCombo(text, f0001a1);
			}
		}

		public string iGetAdcDataTarText()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(iGetAdcDataTarText);
				return (string)base.Invoke(method);
			}
			UpdateContStrData();
			return f0001a1.Text;
		}

		public bool SaveContStreamingData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveContStreamingData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetAppSetting("contStreamStartFreq", m_nudStartFreqConst.Value.ToString());
				ConfigurationManager.SetAppSetting("contStreamSampleRate", m_nudDigOutSampleRate.Value.ToString());
				ConfigurationManager.SetAppSetting("contStreamRxGain", m_nudProfileRxGain.Value.ToString());
				ConfigurationManager.SetAppSetting("contStreamHPF1CornFreq", m_cboProfileHpf1.SelectedIndex.ToString());
				ConfigurationManager.SetAppSetting("contStreamHPF2CornFreq", m_cboProfileHpf2.SelectedIndex.ToString());
				ConfigurationManager.SetAppSetting("contStreamPwrBackTx1", m_nudTx1OutPowerBackoffCode.Value.ToString());
				ConfigurationManager.SetAppSetting("contStreamPwrBackTx2", m_nudTx2OutPowerBackoffCode.Value.ToString());
				ConfigurationManager.SetAppSetting("contStreamPwrBackTx3", m_nudTx3OutPowerBackoffCode.Value.ToString());
				ConfigurationManager.SetAppSetting("contStreamPhaseShift1", m_nudTx1PhaseShifter.Value.ToString());
				ConfigurationManager.SetAppSetting("contStreamPhaseShift2", m_nudTx2PhaseShifter.Value.ToString());
				ConfigurationManager.SetAppSetting("contStreamPhaseShift3", m_nudTx3PhaseShifter.Value.ToString());
				ConfigurationManager.SetAppSetting("contStreamDumpFile", f0001a1.Text.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadContStreamingData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadContStreamingData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				float startFreq = Convert.ToSingle(ConfigurationManager.GetAppSetting("contStreamStartFreq"));
				ushort sampleRate = Convert.ToUInt16(ConfigurationManager.GetAppSetting("contStreamSampleRate"));
				ushort rxGain = Convert.ToUInt16(ConfigurationManager.GetAppSetting("contStreamRxGain"));
				ushort hpf1CornFreq = Convert.ToUInt16(ConfigurationManager.GetAppSetting("contStreamHPF1CornFreq"));
				ushort hpf2CornFreq = Convert.ToUInt16(ConfigurationManager.GetAppSetting("contStreamHPF2CornFreq"));
				ushort p = Convert.ToUInt16(ConfigurationManager.GetAppSetting("contStreamPwrBackTx1"));
				ushort p2 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("contStreamPwrBackTx2"));
				ushort p3 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("contStreamPwrBackTx3"));
				ushort phaseShift = Convert.ToUInt16(ConfigurationManager.GetAppSetting("contStreamPhaseShift1"));
				ushort phaseShift2 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("contStreamPhaseShift2"));
				ushort phaseShift3 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("contStreamPhaseShift3"));
				string dumpFile = Convert.ToString(ConfigurationManager.GetAppSetting("contStreamDumpFile"));
				ushort noOfSamples = Convert.ToUInt16(ConfigurationManager.GetAppSetting("contStreamNoOfSamples"));
				m_GuiManager.ScriptOps.UpdateContStreamConfigData(startFreq, sampleRate, rxGain, hpf1CornFreq, hpf2CornFreq, p, p2, p3, phaseShift, phaseShift2, phaseShift3, dumpFile, noOfSamples);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private void m_nudContStreamStartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			if (GlobalRef.g_ARDeviceOperateFreq60GHz)
			{
				double value = (uint)Math.Round((double)m_nudStartFreqConst.Value * 67108864.0 / 2.7) * 2.7 / 67108864.0;
				m_nudStartFreqConst.Value = (decimal)value;
				return;
			}
			double value2 = (uint)Math.Round((double)m_nudStartFreqConst.Value * 67108864.0 / 3.6) * 3.6 / 67108864.0;
			m_nudStartFreqConst.Value = (decimal)value2;
		}

		public int StartFreqMinAndMaxSetInContStream_Gui()
		{
			if (GlobalRef.g_ARDeviceOperateFreq60GHz)
			{
				m_nudStartFreqConst.Minimum = 45m;
				m_nudStartFreqConst.Maximum = 100m;
				m_nudStartFreqConst.Value = 60m;
			}
			else
			{
				m_nudStartFreqConst.Minimum = 0m;
				m_nudStartFreqConst.Maximum = 81m;
				m_nudStartFreqConst.Value = 77m;
			}
			return 0;
		}

		private void m_nudContStreamTx1PhaseShifter_ValueChanged(object sender, EventArgs p1)
		{
			double num = (double)((short)Math.Round((double)m_nudTx1PhaseShifter.Value * 256.0 / 360.0)) * 360.0 / 256.0;
			m_nudTx1PhaseShifter.Text = num.ToString();
		}

		private void m_nudContStreamTx2PhaseShifter_ValueChanged(object sender, EventArgs p1)
		{
			double num = (double)((short)Math.Round((double)m_nudTx2PhaseShifter.Value * 256.0 / 360.0)) * 360.0 / 256.0;
			m_nudTx2PhaseShifter.Text = num.ToString();
		}

		private void m_nudContStreamTx3PhaseShifter_ValueChanged(object sender, EventArgs p1)
		{
			double num = (double)((short)Math.Round((double)m_nudTx3PhaseShifter.Value * 256.0 / 360.0)) * 360.0 / 256.0;
			m_nudTx3PhaseShifter.Text = num.ToString();
		}

		public void DisableTheStreamEnable()
		{
			EnableControl_Rec(true, f0001a0);
		}

		public void EnableControl_Rec(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(EnableControl_Rec);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is Button)
			{
				f0001a0.Enabled = false;
				return;
			}
			f0001a0.Enabled = true;
		}

		public void EnableTheStreamEnable()
		{
			EnableStreamControl_Rec(true, f0001a0);
		}

		public void EnableStreamControl_Rec(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(EnableStreamControl_Rec);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is Button)
			{
				f0001a0.Enabled = true;
				return;
			}
			f0001a0.Enabled = false;
		}

		private void m_nudNumOfContStreamSampleRate_ValueChanged(object sender, EventArgs p1)
		{
		}

		public void DisableContinuousStreamingPowerBackOffAndPhaseShiftRegisterFor16XXARDevice()
		{
			if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device || GlobalRef.g_AR6843Device || GlobalRef.g_AR1843Device)
			{
				m_nudTx3OutPowerBackoffCode.Enabled = true;
				m_nudTx3PhaseShifter.Enabled = true;
				return;
			}
			if (GlobalRef.g_AR16xxDevice)
			{
				m_nudTx3OutPowerBackoffCode.Enabled = false;
				m_nudTx3PhaseShifter.Enabled = false;
			}
		}

		private int iSetiSetBasicConfigForAnalysisAsyncConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetBasicConfigurationForAnalysisConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetiSetBasicConfigForAnalysisAsyncConfig()
		{
			iSetiSetBasicConfigForAnalysisAsyncConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iSetBasicConfigForAnalysisAsync()
		{
			new del_v_v(iSetiSetBasicConfigForAnalysisAsyncConfig).BeginInvoke(null, null);
		}

		private void m_btnBasicConfigForAnalysisSet_Click(object sender, EventArgs p1)
		{
			iSetBasicConfigForAnalysisAsync();
		}

		public bool UpdateBasicConfigForAnalysisData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateBasicConfigForAnalysisData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_BasicConfigurationForAnalysisParams.NumberOfSamples = (uint)m_nudNumOfSamples.Value;
				m_BasicConfigurationForAnalysisParams.FFTSize = (uint)m_nudFFTSize.Value;
				m_BasicConfigurationForAnalysisParams.NumberOFAverages = (uint)m_nudNumOfAverages.Value;
				m_BasicConfigurationForAnalysisParams.WindowSelection = (ushort)m_cboWindowSelection.SelectedIndex;
				m_BasicConfigurationForAnalysisParams.RemoveDCEnable = (m_ChkRemoveDCYes.Checked ? '\u0001' : '\0');
				m_BasicConfigurationForAnalysisParams.EnableTirggerCapture = (m_ChkEnaTriggerCaptureYes.Checked ? '\u0001' : '\0');
				m_BasicConfigurationForAnalysisParams.WindowCopensation = (char)m_cboWindowCompensation.SelectedIndex;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateBasicConfigForAnalysiConfigDataFromLuaCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateBasicConfigForAnalysiConfigDataFromLuaCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudNumOfSamples.Value = m_BasicConfigurationForAnalysisParams.NumberOfSamples;
				m_nudFFTSize.Value = m_BasicConfigurationForAnalysisParams.FFTSize;
				m_nudNumOfAverages.Value = m_BasicConfigurationForAnalysisParams.NumberOFAverages;
				m_cboWindowSelection.SelectedIndex = (int)m_BasicConfigurationForAnalysisParams.WindowSelection;
				m_ChkRemoveDCYes.Checked = (m_BasicConfigurationForAnalysisParams.RemoveDCEnable == '\u0001');
				m_ChkEnaTriggerCaptureYes.Checked = (m_BasicConfigurationForAnalysisParams.EnableTirggerCapture == '\u0001');
				m_cboWindowCompensation.SelectedIndex = (int)m_BasicConfigurationForAnalysisParams.WindowCopensation;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iStartContStrADCCaptureConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iStartContStrADCCaptureConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iStartContStrADCCaptureConfig()
		{
			iStartContStrADCCaptureConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iStartContStrADCCaptureAsync()
		{
			new del_v_v(iStartContStrADCCaptureConfig).BeginInvoke(null, null);
		}

		private void m_btnContinuousADCCapture_Click(object sender, EventArgs p1)
		{
			iStartContStrADCCaptureAsync();
		}

		public bool UpdateContStreamADCCaptureConfigDataFromLuaCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateContStreamADCCaptureConfigDataFromLuaCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				f0001a1.Text = m_ContStreamParams.mtlbAdcPath;
				m_nudNumOfSamples.Value = m_BasicConfigurationForAnalysisParams.NumberOfSamples;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iStartContStrProcessAndDisplayADCDataConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iStartContStrADCProcessAndDisplayConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iStartContStrProcessAndDisplayADCDataConfig()
		{
			iStartContStrProcessAndDisplayADCDataConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iStartContStrProcessAndDisplayADCDataAsync()
		{
			new del_v_v(iStartContStrProcessAndDisplayADCDataConfig).BeginInvoke(null, null);
		}

		private void m_btnBasicConfigForAnalysisAndDisplay_Click(object sender, EventArgs p1)
		{
			if (GlobalRef.f0002d0)
			{
				iStartCaptureCardContStrProcessAndDisplayADCDataAsync();
				return;
			}
			iStartContStrProcessAndDisplayADCDataAsync();
		}

		private int iStartCaptureCardContStrProcessAndDisplayADCDataConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iStartCaptureCardContStrADCProcessAndDisplayConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iStartCaptureCardContStrProcessAndDisplayADCDataConfig()
		{
			iStartCaptureCardContStrProcessAndDisplayADCDataConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iStartCaptureCardContStrProcessAndDisplayADCDataAsync()
		{
			new del_v_v(iStartCaptureCardContStrProcessAndDisplayADCDataConfig).BeginInvoke(null, null);
		}

		private int iStartMeasureGainAndNFConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iStartMeasureGainAndNFConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iStartMeasureGainAndNFConfig()
		{
			iStartMeasureGainAndNFConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iStartMeasureGainAndNFDataAsync()
		{
			new del_v_v(iStartMeasureGainAndNFConfig).BeginInvoke(null, null);
		}

		private void m_btnMeasure_Gain_NF_Click(object sender, EventArgs p1)
		{
			iStartMeasureGainAndNFDataAsync();
		}

		private int iStartMeasureGainConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iStartMeasureGainConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iStartMeasureGainConfig()
		{
			iStartMeasureGainConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iStartMeasureGainDataAsync()
		{
			new del_v_v(iStartMeasureGainConfig).BeginInvoke(null, null);
		}

		private void m_btnMeasure_Gain_Click(object sender, EventArgs p1)
		{
			iStartMeasureGainDataAsync();
		}

		private int iStartMeasureNFConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iStartMeasureNFConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iStartMeasureNFConfig()
		{
			iStartMeasureNFConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iStartMeasureNFDataAsync()
		{
			new del_v_v(iStartMeasureNFConfig).BeginInvoke(null, null);
		}

		private void m_btnMeasureNF_Click(object sender, EventArgs p1)
		{
			iStartMeasureNFDataAsync();
		}

		public bool UpdateMeasureGainData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateMeasureGainData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_ContStreamParams.GainNFRxChain = (uint)m_nudRxChain.Value;
				m_ContStreamParams.GainNFInputPower = (float)m_nudRxIPPower.Value;
				m_ContStreamParams.GainNFToneFreq = (float)m_nudIFToneFreq.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMeasureGainConfigDataFromLuaCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateMeasureGainConfigDataFromLuaCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				f0001a1.Text = m_ContStreamParams.mtlbAdcPath;
				m_nudRxChain.Value = m_ContStreamParams.GainNFRxChain;
				m_nudRxIPPower.Value = (decimal)m_ContStreamParams.GainNFInputPower;
				m_nudIFToneFreq.Value = (decimal)m_ContStreamParams.GainNFToneFreq;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMeasureNFData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateMeasureNFData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_ContStreamParams.GainNFRxChain = (uint)m_nudRxChain.Value;
				m_ContStreamParams.GainNFToneFreq = (float)m_nudIFToneFreq.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMeasureNFConfigDataFromLuaCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateMeasureNFConfigDataFromLuaCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				f0001a1.Text = m_ContStreamParams.mtlbAdcPath;
				m_nudRxChain.Value = m_ContStreamParams.GainNFRxChain;
				m_nudIFToneFreq.Value = (decimal)m_ContStreamParams.GainNFToneFreq;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetMeasureTxPowerConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetMeasureTxPowerConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetMeasureTxPowerConfig()
		{
			iSetMeasureTxPowerConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iSetMeasureTxPowerAsync()
		{
			new del_v_v(iSetMeasureTxPowerConfig).BeginInvoke(null, null);
		}

		private void m_btnMeasureTxPowerSet_Click(object sender, EventArgs p1)
		{
			iSetMeasureTxPowerAsync();
		}

		public bool UpdateMeasureTheTxPowerData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateMeasureTheTxPowerData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MeasureTxPowerParams.NumberOfAccumulations = (char)m_nudTxPowerNoOfAccumulations.Value;
				m_MeasureTxPowerParams.NumberOfSamples = (char)m_nudTxPowerNoOfSamples.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMeasureTheTxPowerConfigDataFromLuaCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateMeasureTheTxPowerConfigDataFromLuaCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudTxPowerNoOfAccumulations.Value = m_MeasureTxPowerParams.NumberOfAccumulations;
				m_nudTxPowerNoOfSamples.Value = m_MeasureTxPowerParams.NumberOfSamples;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool MeasureTxPowerReport(uint RadarDeviceId, int TxOutputPower, int ReflectedPower, int IncidentVoltage, int ReflectedVoltage, int Tx2TxOutputPower, int Tx2ReflectedPower, int Tx2IncidentVoltage, int Tx2ReflectedVoltage, int Tx3TxOutputPower, int Tx3ReflectedPower, int Tx3IncidentVoltage, int Tx3ReflectedVoltage)
		{
			if (base.InvokeRequired)
			{
				delegate0ff method = new delegate0ff(MeasureTxPowerReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					TxOutputPower,
					ReflectedPower,
					IncidentVoltage,
					ReflectedVoltage,
					Tx2TxOutputPower,
					Tx2ReflectedPower,
					Tx2IncidentVoltage,
					Tx2ReflectedVoltage,
					Tx3TxOutputPower,
					Tx3ReflectedPower,
					Tx3IncidentVoltage,
					Tx3ReflectedVoltage
				});
			}
			else if (RadarDeviceId == 1U)
			{
				if (TxOutputPower > 32767)
				{
					TxOutputPower -= 65536;
					m_lblTxOutPutPower.Text = Convert.ToString((double)TxOutputPower / 10.0);
				}
				else
				{
					m_lblTxOutPutPower.Text = Convert.ToString((double)TxOutputPower / 10.0);
				}
				if (ReflectedPower > 32767)
				{
					ReflectedPower -= 65536;
					m_lblReflectedPower.Text = Convert.ToString((double)ReflectedPower / 10.0);
				}
				else
				{
					m_lblReflectedPower.Text = Convert.ToString((double)ReflectedPower / 10.0);
				}
				m_lblIncidentVoltage.Text = Convert.ToString(IncidentVoltage / 32);
				m_lblReflectedVoltage.Text = Convert.ToString(ReflectedVoltage / 32);
				if (Tx2TxOutputPower > 32767)
				{
					Tx2TxOutputPower -= 65536;
					m_lblTx2TxOutPutPower.Text = Convert.ToString((double)Tx2TxOutputPower / 10.0);
				}
				else
				{
					m_lblTx2TxOutPutPower.Text = Convert.ToString((double)Tx2TxOutputPower / 10.0);
				}
				if (Tx2ReflectedPower > 32767)
				{
					Tx2ReflectedPower -= 65536;
					m_lblTx2ReflectedPower.Text = Convert.ToString((double)Tx2ReflectedPower / 10.0);
				}
				else
				{
					m_lblTx2ReflectedPower.Text = Convert.ToString((double)Tx2ReflectedPower / 10.0);
				}
				m_lblTx2IncidentVoltage.Text = Convert.ToString(Tx2IncidentVoltage / 32);
				m_lblTx2ReflectedVoltage.Text = Convert.ToString(Tx2ReflectedVoltage / 32);
				if (Tx3TxOutputPower > 32767)
				{
					Tx3TxOutputPower -= 65536;
					m_lblTx3TxOutPutPower.Text = Convert.ToString((double)Tx3TxOutputPower / 10.0);
				}
				else
				{
					m_lblTx3TxOutPutPower.Text = Convert.ToString((double)Tx3TxOutputPower / 10.0);
				}
				if (Tx3ReflectedPower > 32767)
				{
					Tx3ReflectedPower -= 65536;
					m_lblTx3ReflectedPower.Text = Convert.ToString((double)Tx3ReflectedPower / 10.0);
				}
				else
				{
					m_lblTx3ReflectedPower.Text = Convert.ToString((double)Tx3ReflectedPower / 10.0);
				}
				m_lblTx3IncidentVoltage.Text = Convert.ToString(Tx3IncidentVoltage / 32);
				m_lblTx3ReflectedVoltage.Text = Convert.ToString(Tx3ReflectedVoltage / 32);
			}
			return true;
		}

		public bool CascadeMeasureTxPowerReport(uint RadarDeviceId, int TxOutputPower, int ReflectedPower, int IncidentVoltage, int ReflectedVoltage, int Tx2TxOutputPower, int Tx2ReflectedPower, int Tx2IncidentVoltage, int Tx2ReflectedVoltage, int Tx3TxOutputPower, int Tx3ReflectedPower, int Tx3IncidentVoltage, int Tx3ReflectedVoltage)
		{
			if (base.InvokeRequired)
			{
				delegate0ff method = new delegate0ff(CascadeMeasureTxPowerReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					TxOutputPower,
					ReflectedPower,
					IncidentVoltage,
					ReflectedVoltage,
					Tx2TxOutputPower,
					Tx2ReflectedPower,
					Tx2IncidentVoltage,
					Tx2ReflectedVoltage,
					Tx3TxOutputPower,
					Tx3ReflectedPower,
					Tx3IncidentVoltage,
					Tx3ReflectedVoltage
				});
			}
			else if (RadarDeviceId == 0U)
			{
				if (TxOutputPower > 32767)
				{
					TxOutputPower -= 65536;
					m_lblTxOutPutPower.Text = Convert.ToString((double)TxOutputPower / 10.0);
				}
				else
				{
					m_lblTxOutPutPower.Text = Convert.ToString((double)TxOutputPower / 10.0);
				}
				if (ReflectedPower > 32767)
				{
					ReflectedPower -= 65536;
					m_lblReflectedPower.Text = Convert.ToString((double)ReflectedPower / 10.0);
				}
				else
				{
					m_lblReflectedPower.Text = Convert.ToString((double)ReflectedPower / 10.0);
				}
				m_lblIncidentVoltage.Text = Convert.ToString(IncidentVoltage / 32);
				m_lblReflectedVoltage.Text = Convert.ToString(ReflectedVoltage / 32);
				if (Tx2TxOutputPower > 32767)
				{
					Tx2TxOutputPower -= 65536;
					m_lblTx2TxOutPutPower.Text = Convert.ToString((double)Tx2TxOutputPower / 10.0);
				}
				else
				{
					m_lblTx2TxOutPutPower.Text = Convert.ToString((double)Tx2TxOutputPower / 10.0);
				}
				if (Tx2ReflectedPower > 32767)
				{
					Tx2ReflectedPower -= 65536;
					m_lblTx2ReflectedPower.Text = Convert.ToString((double)Tx2ReflectedPower / 10.0);
				}
				else
				{
					m_lblTx2ReflectedPower.Text = Convert.ToString((double)Tx2ReflectedPower / 10.0);
				}
				m_lblTx2IncidentVoltage.Text = Convert.ToString(Tx2IncidentVoltage / 32);
				m_lblTx2ReflectedVoltage.Text = Convert.ToString(Tx2ReflectedVoltage / 32);
				if (Tx3TxOutputPower > 32767)
				{
					Tx3TxOutputPower -= 65536;
					m_lblTx3TxOutPutPower.Text = Convert.ToString((double)Tx3TxOutputPower / 10.0);
				}
				else
				{
					m_lblTx3TxOutPutPower.Text = Convert.ToString((double)Tx3TxOutputPower / 10.0);
				}
				if (Tx3ReflectedPower > 32767)
				{
					Tx3ReflectedPower -= 65536;
					m_lblTx3ReflectedPower.Text = Convert.ToString((double)Tx3ReflectedPower / 10.0);
				}
				else
				{
					m_lblTx3ReflectedPower.Text = Convert.ToString((double)Tx3ReflectedPower / 10.0);
				}
				m_lblTx3IncidentVoltage.Text = Convert.ToString(Tx3IncidentVoltage / 32);
				m_lblTx3ReflectedVoltage.Text = Convert.ToString(Tx3ReflectedVoltage / 32);
			}
			else if (RadarDeviceId == 1U)
			{
				m_lblRadarDevice2TxOutPutPower.Text = Convert.ToString((double)TxOutputPower / 10.0);
				m_lblRadarDevice2ReflectedPower.Text = Convert.ToString((double)ReflectedPower / 10.0);
				m_lblRadarDevice2IncidentVoltage.Text = Convert.ToString(IncidentVoltage / 32);
				m_lblRadarDevice2ReflectedVoltage.Text = Convert.ToString(ReflectedVoltage / 32);
			}
			else if (RadarDeviceId == 2U)
			{
				m_lblRadarDevice3TxOutPutPower.Text = Convert.ToString((double)TxOutputPower / 10.0);
				m_lblRadarDevice3ReflectedPower.Text = Convert.ToString((double)ReflectedPower / 10.0);
				m_lblRadarDevice3IncidentVoltage.Text = Convert.ToString(IncidentVoltage / 32);
				m_lblRadarDevice3ReflectedVoltage.Text = Convert.ToString(ReflectedVoltage / 32);
			}
			else if (RadarDeviceId == 3U)
			{
				m_lblRadarDevice4TxOutPutPower.Text = Convert.ToString((double)TxOutputPower / 10.0);
				m_lblRadarDevice4ReflectedPower.Text = Convert.ToString((double)ReflectedPower / 10.0);
				m_lblRadarDevice4IncidentVoltage.Text = Convert.ToString(IncidentVoltage / 32);
				m_lblRadarDevice4ReflectedVoltage.Text = Convert.ToString(ReflectedVoltage / 32);
			}
			return true;
		}

		public void EnableDisbleMeasureTxPowerStatusWithRespectiveRadarDevices(ushort numberOfRadarDevicesDetected)
		{
			if (numberOfRadarDevicesDetected == 1)
			{
				m_lblTxOutPutPower.Visible = true;
				m_lblReflectedPower.Visible = true;
				m_lblIncidentVoltage.Visible = true;
				m_lblReflectedVoltage.Visible = true;
				m_lblRadarDevice2TxOutPutPower.Visible = false;
				m_lblRadarDevice2ReflectedPower.Visible = false;
				m_lblRadarDevice2IncidentVoltage.Visible = false;
				m_lblRadarDevice2ReflectedVoltage.Visible = false;
				m_lblRadarDevice3TxOutPutPower.Visible = false;
				m_lblRadarDevice3ReflectedPower.Visible = false;
				m_lblRadarDevice3IncidentVoltage.Visible = false;
				m_lblRadarDevice3ReflectedVoltage.Visible = false;
				m_lblRadarDevice4TxOutPutPower.Visible = false;
				m_lblRadarDevice4ReflectedPower.Visible = false;
				m_lblRadarDevice4IncidentVoltage.Visible = false;
				m_lblRadarDevice4ReflectedVoltage.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 2)
			{
				m_lblTxOutPutPower.Visible = true;
				m_lblReflectedPower.Visible = true;
				m_lblIncidentVoltage.Visible = true;
				m_lblReflectedVoltage.Visible = true;
				m_lblRadarDevice2TxOutPutPower.Visible = true;
				m_lblRadarDevice2ReflectedPower.Visible = true;
				m_lblRadarDevice2IncidentVoltage.Visible = true;
				m_lblRadarDevice2ReflectedVoltage.Visible = true;
				m_lblRadarDevice3TxOutPutPower.Visible = false;
				m_lblRadarDevice3ReflectedPower.Visible = false;
				m_lblRadarDevice3IncidentVoltage.Visible = false;
				m_lblRadarDevice3ReflectedVoltage.Visible = false;
				m_lblRadarDevice4TxOutPutPower.Visible = false;
				m_lblRadarDevice4ReflectedPower.Visible = false;
				m_lblRadarDevice4IncidentVoltage.Visible = false;
				m_lblRadarDevice4ReflectedVoltage.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 4)
			{
				m_lblTxOutPutPower.Visible = true;
				m_lblReflectedPower.Visible = true;
				m_lblIncidentVoltage.Visible = true;
				m_lblReflectedVoltage.Visible = true;
				m_lblRadarDevice2TxOutPutPower.Visible = true;
				m_lblRadarDevice2ReflectedPower.Visible = true;
				m_lblRadarDevice2IncidentVoltage.Visible = true;
				m_lblRadarDevice2ReflectedVoltage.Visible = true;
				m_lblRadarDevice3TxOutPutPower.Visible = true;
				m_lblRadarDevice3ReflectedPower.Visible = true;
				m_lblRadarDevice3IncidentVoltage.Visible = true;
				m_lblRadarDevice3ReflectedVoltage.Visible = true;
				m_lblRadarDevice4TxOutPutPower.Visible = true;
				m_lblRadarDevice4ReflectedPower.Visible = true;
				m_lblRadarDevice4IncidentVoltage.Visible = true;
				m_lblRadarDevice4ReflectedVoltage.Visible = true;
				return;
			}
			m_lblTxOutPutPower.Visible = false;
			m_lblReflectedPower.Visible = false;
			m_lblIncidentVoltage.Visible = false;
			m_lblReflectedVoltage.Visible = false;
			m_lblRadarDevice2TxOutPutPower.Visible = false;
			m_lblRadarDevice2ReflectedPower.Visible = false;
			m_lblRadarDevice2IncidentVoltage.Visible = false;
			m_lblRadarDevice2ReflectedVoltage.Visible = false;
			m_lblRadarDevice3TxOutPutPower.Visible = false;
			m_lblRadarDevice3ReflectedPower.Visible = false;
			m_lblRadarDevice3IncidentVoltage.Visible = false;
			m_lblRadarDevice3ReflectedVoltage.Visible = false;
			m_lblRadarDevice4TxOutPutPower.Visible = false;
			m_lblRadarDevice4ReflectedPower.Visible = false;
			m_lblRadarDevice4IncidentVoltage.Visible = false;
			m_lblRadarDevice4ReflectedVoltage.Visible = false;
		}

		public void ResetMeasureTxPowerReportOfRadarDevice1Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(ResetMeasureTxPowerReportOfRadarDevice1Status);
				base.Invoke(method);
				return;
			}
			m_lblTxOutPutPower.Text = "0";
			m_lblReflectedPower.Text = "0";
			m_lblIncidentVoltage.Text = "0";
			m_lblReflectedVoltage.Text = "0";
		}

		public void ResetMeasureTxPowerReportOfRadarDevice2Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(ResetMeasureTxPowerReportOfRadarDevice2Status);
				base.Invoke(method);
				return;
			}
			m_lblRadarDevice2TxOutPutPower.Text = "0";
			m_lblRadarDevice2ReflectedPower.Text = "0";
			m_lblRadarDevice2IncidentVoltage.Text = "0";
			m_lblRadarDevice2ReflectedVoltage.Text = "0";
		}

		public void ResetMeasureTxPowerReportOfRadarDevice3Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(ResetMeasureTxPowerReportOfRadarDevice3Status);
				base.Invoke(method);
				return;
			}
			m_lblRadarDevice3TxOutPutPower.Text = "0";
			m_lblRadarDevice3ReflectedPower.Text = "0";
			m_lblRadarDevice3IncidentVoltage.Text = "0";
			m_lblRadarDevice3ReflectedVoltage.Text = "0";
		}

		public void ResetMeasureTxPowerReportOfRadarDevice4Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(ResetMeasureTxPowerReportOfRadarDevice4Status);
				base.Invoke(method);
				return;
			}
			m_lblRadarDevice4TxOutPutPower.Text = "0";
			m_lblRadarDevice4ReflectedPower.Text = "0";
			m_lblRadarDevice4IncidentVoltage.Text = "0";
			m_lblRadarDevice4ReflectedVoltage.Text = "0";
		}

		public void SetRFGainTarget()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(SetRFGainTarget);
				base.Invoke(method);
				return;
			}
			if (GlobalRef.g_AR2243Device)
			{
				m_cboRFGainTarget.SelectedIndex = 1;
				return;
			}
			m_cboRFGainTarget.SelectedIndex = 0;
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
            this.m_grpProfile = new System.Windows.Forms.GroupBox();
            this.m_ChkForceVCOSelect = new System.Windows.Forms.CheckBox();
            this.m_cboVCOSelect = new System.Windows.Forms.ComboBox();
            this.m_cboRFGainTarget = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.m_nudTx2OutPowerBackoffCode = new System.Windows.Forms.NumericUpDown();
            this.m_nudTx1OutPowerBackoffCode = new System.Windows.Forms.NumericUpDown();
            this.m_lblProfileTx2OpPwrBackoff = new System.Windows.Forms.Label();
            this.m_lblProfileTx1OpPwrBackoff = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_nudTx3PhaseShifter = new System.Windows.Forms.NumericUpDown();
            this.m_nudTx2PhaseShifter = new System.Windows.Forms.NumericUpDown();
            this.m_nudProfileRxGain = new System.Windows.Forms.NumericUpDown();
            this.m_btnProfileSet = new System.Windows.Forms.Button();
            this.m_nudTx1PhaseShifter = new System.Windows.Forms.NumericUpDown();
            this.m_lblProfilePhaseShifter = new System.Windows.Forms.Label();
            this.m_nudTx3OutPowerBackoffCode = new System.Windows.Forms.NumericUpDown();
            this.m_lblProfileTx3OpPwrBackoff = new System.Windows.Forms.Label();
            this.m_nudStartFreqConst = new System.Windows.Forms.NumericUpDown();
            this.m_lblProfileStartFreqConst = new System.Windows.Forms.Label();
            this.m_nudDigOutSampleRate = new System.Windows.Forms.NumericUpDown();
            this.m_lblProfileSampleRate = new System.Windows.Forms.Label();
            this.m_lblProfileRxGain = new System.Windows.Forms.Label();
            this.m_cboProfileHpf2 = new System.Windows.Forms.ComboBox();
            this.m_lblProfileHpf2 = new System.Windows.Forms.Label();
            this.m_cboProfileHpf1 = new System.Windows.Forms.ComboBox();
            this.m_lblProfileHpf1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_grpMeasureTxPower = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.m_lblTx3ReflectedVoltage = new System.Windows.Forms.Label();
            this.m_lblTx3IncidentVoltage = new System.Windows.Forms.Label();
            this.m_lblTx3ReflectedPower = new System.Windows.Forms.Label();
            this.m_lblTx3TxOutPutPower = new System.Windows.Forms.Label();
            this.m_lblTx2ReflectedVoltage = new System.Windows.Forms.Label();
            this.m_lblTx2IncidentVoltage = new System.Windows.Forms.Label();
            this.m_lblTx2ReflectedPower = new System.Windows.Forms.Label();
            this.m_lblTx2TxOutPutPower = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4TxOutPutPower = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4ReflectedVoltage = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4IncidentVoltage = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4ReflectedPower = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3TxOutPutPower = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3ReflectedVoltage = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3IncidentVoltage = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3ReflectedPower = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2TxOutPutPower = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2ReflectedVoltage = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2IncidentVoltage = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2ReflectedPower = new System.Windows.Forms.Label();
            this.m_lblTxOutPutPower = new System.Windows.Forms.Label();
            this.m_lblReflectedVoltage = new System.Windows.Forms.Label();
            this.m_lblIncidentVoltage = new System.Windows.Forms.Label();
            this.m_lblReflectedPower = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_btnMeasureTxPowerSet = new System.Windows.Forms.Button();
            this.m_nudTxPowerNoOfSamples = new System.Windows.Forms.NumericUpDown();
            this.m_nudTxPowerNoOfAccumulations = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_grpMeasureGainAndNF = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_nudIFToneFreq = new System.Windows.Forms.NumericUpDown();
            this.m_nudRxIPPower = new System.Windows.Forms.NumericUpDown();
            this.m_nudRxChain = new System.Windows.Forms.NumericUpDown();
            this.ddd = new System.Windows.Forms.Label();
            this.m_btnMeasureNF = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_btnMeasure_Gain = new System.Windows.Forms.Button();
            this.m_grpBasicCfgAnalysis = new System.Windows.Forms.GroupBox();
            this.m_ChkEnaTriggerCaptureYes = new System.Windows.Forms.CheckBox();
            this.m_ChkRemoveDCYes = new System.Windows.Forms.CheckBox();
            this.m_btnBasicConfigForAnalysisSet = new System.Windows.Forms.Button();
            this.m_nudFFTSize = new System.Windows.Forms.NumericUpDown();
            this.m_cboWindowSelection = new System.Windows.Forms.ComboBox();
            this.m_cboWindowCompensation = new System.Windows.Forms.ComboBox();
            this.m_nudNumOfAverages = new System.Windows.Forms.NumericUpDown();
            this.m_nudNumOfSamples = new System.Windows.Forms.NumericUpDown();
            this.m_lblWindowCompensation = new System.Windows.Forms.Label();
            this.m_lblRemoveDC = new System.Windows.Forms.Label();
            this.m_lblEnableTriggerdCapture = new System.Windows.Forms.Label();
            this.m_lblWindowSelection = new System.Windows.Forms.Label();
            this.m_lblNumberOfAverages = new System.Windows.Forms.Label();
            this.m_lblFFTSize = new System.Windows.Forms.Label();
            this.m_lblNumberOfSamples = new System.Windows.Forms.Label();
            this.m_grpCaptureAndPostProcess = new System.Windows.Forms.GroupBox();
            this.m_btnBasicConfigForAnalysisAndDisplay = new System.Windows.Forms.Button();
            this.m_btnContinuousADCCapture = new System.Windows.Forms.Button();
            this.f0001a1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_btnAdcDataTar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.f0001a0 = new System.Windows.Forms.Button();
            this.m_fdlgContStrData = new System.Windows.Forms.SaveFileDialog();
            this.m_grpProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx2OutPowerBackoffCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx1OutPowerBackoffCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx3PhaseShifter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx2PhaseShifter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudProfileRxGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx1PhaseShifter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx3OutPowerBackoffCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudStartFreqConst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDigOutSampleRate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.m_grpMeasureTxPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTxPowerNoOfSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTxPowerNoOfAccumulations)).BeginInit();
            this.m_grpMeasureGainAndNF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudIFToneFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxIPPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxChain)).BeginInit();
            this.m_grpBasicCfgAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFFTSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudNumOfAverages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudNumOfSamples)).BeginInit();
            this.m_grpCaptureAndPostProcess.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpProfile
            // 
            this.m_grpProfile.Controls.Add(this.m_ChkForceVCOSelect);
            this.m_grpProfile.Controls.Add(this.m_cboVCOSelect);
            this.m_grpProfile.Controls.Add(this.m_cboRFGainTarget);
            this.m_grpProfile.Controls.Add(this.label16);
            this.m_grpProfile.Controls.Add(this.label15);
            this.m_grpProfile.Controls.Add(this.m_nudTx2OutPowerBackoffCode);
            this.m_grpProfile.Controls.Add(this.m_nudTx1OutPowerBackoffCode);
            this.m_grpProfile.Controls.Add(this.m_lblProfileTx2OpPwrBackoff);
            this.m_grpProfile.Controls.Add(this.m_lblProfileTx1OpPwrBackoff);
            this.m_grpProfile.Controls.Add(this.label2);
            this.m_grpProfile.Controls.Add(this.label1);
            this.m_grpProfile.Controls.Add(this.m_nudTx3PhaseShifter);
            this.m_grpProfile.Controls.Add(this.m_nudTx2PhaseShifter);
            this.m_grpProfile.Controls.Add(this.m_nudProfileRxGain);
            this.m_grpProfile.Controls.Add(this.m_btnProfileSet);
            this.m_grpProfile.Controls.Add(this.m_nudTx1PhaseShifter);
            this.m_grpProfile.Controls.Add(this.m_lblProfilePhaseShifter);
            this.m_grpProfile.Controls.Add(this.m_nudTx3OutPowerBackoffCode);
            this.m_grpProfile.Controls.Add(this.m_lblProfileTx3OpPwrBackoff);
            this.m_grpProfile.Controls.Add(this.m_nudStartFreqConst);
            this.m_grpProfile.Controls.Add(this.m_lblProfileStartFreqConst);
            this.m_grpProfile.Controls.Add(this.m_nudDigOutSampleRate);
            this.m_grpProfile.Controls.Add(this.m_lblProfileSampleRate);
            this.m_grpProfile.Controls.Add(this.m_lblProfileRxGain);
            this.m_grpProfile.Controls.Add(this.m_cboProfileHpf2);
            this.m_grpProfile.Controls.Add(this.m_lblProfileHpf2);
            this.m_grpProfile.Controls.Add(this.m_cboProfileHpf1);
            this.m_grpProfile.Controls.Add(this.m_lblProfileHpf1);
            this.m_grpProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_grpProfile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_grpProfile.Location = new System.Drawing.Point(19, 19);
            this.m_grpProfile.Name = "m_grpProfile";
            this.m_grpProfile.Size = new System.Drawing.Size(530, 278);
            this.m_grpProfile.TabIndex = 12;
            this.m_grpProfile.TabStop = false;
            this.m_grpProfile.Text = "StreamConfig";
            // 
            // m_ChkForceVCOSelect
            // 
            this.m_ChkForceVCOSelect.AutoSize = true;
            this.m_ChkForceVCOSelect.Location = new System.Drawing.Point(153, 242);
            this.m_ChkForceVCOSelect.Name = "m_ChkForceVCOSelect";
            this.m_ChkForceVCOSelect.Size = new System.Drawing.Size(122, 19);
            this.m_ChkForceVCOSelect.TabIndex = 58;
            this.m_ChkForceVCOSelect.Text = "Force VCO Select";
            this.m_ChkForceVCOSelect.UseVisualStyleBackColor = true;
            // 
            // m_cboVCOSelect
            // 
            this.m_cboVCOSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboVCOSelect.FormattingEnabled = true;
            this.m_cboVCOSelect.Items.AddRange(new object[] {
            "VCO1",
            "VCO2"});
            this.m_cboVCOSelect.Location = new System.Drawing.Point(153, 210);
            this.m_cboVCOSelect.Name = "m_cboVCOSelect";
            this.m_cboVCOSelect.Size = new System.Drawing.Size(86, 23);
            this.m_cboVCOSelect.TabIndex = 57;
            // 
            // m_cboRFGainTarget
            // 
            this.m_cboRFGainTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboRFGainTarget.FormattingEnabled = true;
            this.m_cboRFGainTarget.Items.AddRange(new object[] {
            "30dB",
            "34dB",
            "26dB"});
            this.m_cboRFGainTarget.Location = new System.Drawing.Point(153, 115);
            this.m_cboRFGainTarget.Name = "m_cboRFGainTarget";
            this.m_cboRFGainTarget.Size = new System.Drawing.Size(86, 23);
            this.m_cboRFGainTarget.TabIndex = 56;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 212);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 15);
            this.label16.TabIndex = 55;
            this.label16.Text = "VCO Select";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 118);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 15);
            this.label15.TabIndex = 54;
            this.label15.Text = "RF Gain Target";
            // 
            // m_nudTx2OutPowerBackoffCode
            // 
            this.m_nudTx2OutPowerBackoffCode.Location = new System.Drawing.Point(404, 51);
            this.m_nudTx2OutPowerBackoffCode.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.m_nudTx2OutPowerBackoffCode.Name = "m_nudTx2OutPowerBackoffCode";
            this.m_nudTx2OutPowerBackoffCode.Size = new System.Drawing.Size(81, 21);
            this.m_nudTx2OutPowerBackoffCode.TabIndex = 4;
            // 
            // m_nudTx1OutPowerBackoffCode
            // 
            this.m_nudTx1OutPowerBackoffCode.Location = new System.Drawing.Point(404, 17);
            this.m_nudTx1OutPowerBackoffCode.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.m_nudTx1OutPowerBackoffCode.Name = "m_nudTx1OutPowerBackoffCode";
            this.m_nudTx1OutPowerBackoffCode.Size = new System.Drawing.Size(81, 21);
            this.m_nudTx1OutPowerBackoffCode.TabIndex = 2;
            // 
            // m_lblProfileTx2OpPwrBackoff
            // 
            this.m_lblProfileTx2OpPwrBackoff.AutoSize = true;
            this.m_lblProfileTx2OpPwrBackoff.Location = new System.Drawing.Point(256, 56);
            this.m_lblProfileTx2OpPwrBackoff.Name = "m_lblProfileTx2OpPwrBackoff";
            this.m_lblProfileTx2OpPwrBackoff.Size = new System.Drawing.Size(143, 15);
            this.m_lblProfileTx2OpPwrBackoff.TabIndex = 53;
            this.m_lblProfileTx2OpPwrBackoff.Text = "O/p Pwr Backoff TX1 (dB)";
            // 
            // m_lblProfileTx1OpPwrBackoff
            // 
            this.m_lblProfileTx1OpPwrBackoff.AutoSize = true;
            this.m_lblProfileTx1OpPwrBackoff.Location = new System.Drawing.Point(256, 22);
            this.m_lblProfileTx1OpPwrBackoff.Name = "m_lblProfileTx1OpPwrBackoff";
            this.m_lblProfileTx1OpPwrBackoff.Size = new System.Drawing.Size(143, 15);
            this.m_lblProfileTx1OpPwrBackoff.TabIndex = 52;
            this.m_lblProfileTx1OpPwrBackoff.Text = "O/p Pwr Backoff TX0 (dB)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 15);
            this.label2.TabIndex = 50;
            this.label2.Text = "Phase Shifter TX2 (deg)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 49;
            this.label1.Text = "Phase Shifter TX1 (deg)";
            // 
            // m_nudTx3PhaseShifter
            // 
            this.m_nudTx3PhaseShifter.DecimalPlaces = 1;
            this.m_nudTx3PhaseShifter.Location = new System.Drawing.Point(404, 192);
            this.m_nudTx3PhaseShifter.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudTx3PhaseShifter.Name = "m_nudTx3PhaseShifter";
            this.m_nudTx3PhaseShifter.Size = new System.Drawing.Size(81, 21);
            this.m_nudTx3PhaseShifter.TabIndex = 11;
            // 
            // m_nudTx2PhaseShifter
            // 
            this.m_nudTx2PhaseShifter.DecimalPlaces = 1;
            this.m_nudTx2PhaseShifter.Location = new System.Drawing.Point(404, 156);
            this.m_nudTx2PhaseShifter.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudTx2PhaseShifter.Name = "m_nudTx2PhaseShifter";
            this.m_nudTx2PhaseShifter.Size = new System.Drawing.Size(81, 21);
            this.m_nudTx2PhaseShifter.TabIndex = 10;
            // 
            // m_nudProfileRxGain
            // 
            this.m_nudProfileRxGain.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudProfileRxGain.Location = new System.Drawing.Point(153, 87);
            this.m_nudProfileRxGain.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudProfileRxGain.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.m_nudProfileRxGain.Name = "m_nudProfileRxGain";
            this.m_nudProfileRxGain.Size = new System.Drawing.Size(86, 21);
            this.m_nudProfileRxGain.TabIndex = 5;
            this.m_nudProfileRxGain.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // m_btnProfileSet
            // 
            this.m_btnProfileSet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnProfileSet.Location = new System.Drawing.Point(404, 236);
            this.m_btnProfileSet.Name = "m_btnProfileSet";
            this.m_btnProfileSet.Size = new System.Drawing.Size(83, 27);
            this.m_btnProfileSet.TabIndex = 12;
            this.m_btnProfileSet.Text = "Set (1)";
            this.m_btnProfileSet.UseVisualStyleBackColor = true;
            // 
            // m_nudTx1PhaseShifter
            // 
            this.m_nudTx1PhaseShifter.DecimalPlaces = 1;
            this.m_nudTx1PhaseShifter.Location = new System.Drawing.Point(404, 119);
            this.m_nudTx1PhaseShifter.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudTx1PhaseShifter.Name = "m_nudTx1PhaseShifter";
            this.m_nudTx1PhaseShifter.Size = new System.Drawing.Size(81, 21);
            this.m_nudTx1PhaseShifter.TabIndex = 8;
            // 
            // m_lblProfilePhaseShifter
            // 
            this.m_lblProfilePhaseShifter.AutoSize = true;
            this.m_lblProfilePhaseShifter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblProfilePhaseShifter.Location = new System.Drawing.Point(256, 123);
            this.m_lblProfilePhaseShifter.Name = "m_lblProfilePhaseShifter";
            this.m_lblProfilePhaseShifter.Size = new System.Drawing.Size(137, 15);
            this.m_lblProfilePhaseShifter.TabIndex = 40;
            this.m_lblProfilePhaseShifter.Text = "Phase Shifter TX0 (deg)";
            // 
            // m_nudTx3OutPowerBackoffCode
            // 
            this.m_nudTx3OutPowerBackoffCode.Location = new System.Drawing.Point(404, 85);
            this.m_nudTx3OutPowerBackoffCode.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.m_nudTx3OutPowerBackoffCode.Name = "m_nudTx3OutPowerBackoffCode";
            this.m_nudTx3OutPowerBackoffCode.Size = new System.Drawing.Size(81, 21);
            this.m_nudTx3OutPowerBackoffCode.TabIndex = 6;
            // 
            // m_lblProfileTx3OpPwrBackoff
            // 
            this.m_lblProfileTx3OpPwrBackoff.AutoSize = true;
            this.m_lblProfileTx3OpPwrBackoff.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblProfileTx3OpPwrBackoff.Location = new System.Drawing.Point(256, 87);
            this.m_lblProfileTx3OpPwrBackoff.Name = "m_lblProfileTx3OpPwrBackoff";
            this.m_lblProfileTx3OpPwrBackoff.Size = new System.Drawing.Size(143, 15);
            this.m_lblProfileTx3OpPwrBackoff.TabIndex = 38;
            this.m_lblProfileTx3OpPwrBackoff.Text = "O/p Pwr Backoff TX2 (dB)";
            // 
            // m_nudStartFreqConst
            // 
            this.m_nudStartFreqConst.DecimalPlaces = 6;
            this.m_nudStartFreqConst.Increment = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.m_nudStartFreqConst.Location = new System.Drawing.Point(153, 20);
            this.m_nudStartFreqConst.Maximum = new decimal(new int[] {
            81,
            0,
            0,
            0});
            this.m_nudStartFreqConst.Name = "m_nudStartFreqConst";
            this.m_nudStartFreqConst.Size = new System.Drawing.Size(86, 21);
            this.m_nudStartFreqConst.TabIndex = 1;
            this.m_nudStartFreqConst.Value = new decimal(new int[] {
            770,
            0,
            0,
            65536});
            // 
            // m_lblProfileStartFreqConst
            // 
            this.m_lblProfileStartFreqConst.AutoSize = true;
            this.m_lblProfileStartFreqConst.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblProfileStartFreqConst.Location = new System.Drawing.Point(6, 26);
            this.m_lblProfileStartFreqConst.Name = "m_lblProfileStartFreqConst";
            this.m_lblProfileStartFreqConst.Size = new System.Drawing.Size(94, 15);
            this.m_lblProfileStartFreqConst.TabIndex = 36;
            this.m_lblProfileStartFreqConst.Text = "Start Freq (GHz)";
            // 
            // m_nudDigOutSampleRate
            // 
            this.m_nudDigOutSampleRate.Location = new System.Drawing.Point(153, 55);
            this.m_nudDigOutSampleRate.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.m_nudDigOutSampleRate.Name = "m_nudDigOutSampleRate";
            this.m_nudDigOutSampleRate.Size = new System.Drawing.Size(86, 21);
            this.m_nudDigOutSampleRate.TabIndex = 3;
            this.m_nudDigOutSampleRate.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // m_lblProfileSampleRate
            // 
            this.m_lblProfileSampleRate.AutoSize = true;
            this.m_lblProfileSampleRate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblProfileSampleRate.Location = new System.Drawing.Point(6, 57);
            this.m_lblProfileSampleRate.Name = "m_lblProfileSampleRate";
            this.m_lblProfileSampleRate.Size = new System.Drawing.Size(117, 15);
            this.m_lblProfileSampleRate.TabIndex = 26;
            this.m_lblProfileSampleRate.Text = "Sample Rate (ksps)";
            // 
            // m_lblProfileRxGain
            // 
            this.m_lblProfileRxGain.AutoSize = true;
            this.m_lblProfileRxGain.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblProfileRxGain.Location = new System.Drawing.Point(6, 90);
            this.m_lblProfileRxGain.Name = "m_lblProfileRxGain";
            this.m_lblProfileRxGain.Size = new System.Drawing.Size(78, 15);
            this.m_lblProfileRxGain.TabIndex = 24;
            this.m_lblProfileRxGain.Text = "RX Gain (dB)";
            // 
            // m_cboProfileHpf2
            // 
            this.m_cboProfileHpf2.DisplayMember = "0";
            this.m_cboProfileHpf2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboProfileHpf2.FormattingEnabled = true;
            this.m_cboProfileHpf2.Items.AddRange(new object[] {
            "350K",
            "700K",
            "1.4M",
            "2.8M"});
            this.m_cboProfileHpf2.Location = new System.Drawing.Point(153, 180);
            this.m_cboProfileHpf2.Name = "m_cboProfileHpf2";
            this.m_cboProfileHpf2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboProfileHpf2.Size = new System.Drawing.Size(86, 23);
            this.m_cboProfileHpf2.TabIndex = 9;
            // 
            // m_lblProfileHpf2
            // 
            this.m_lblProfileHpf2.AutoSize = true;
            this.m_lblProfileHpf2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblProfileHpf2.Location = new System.Drawing.Point(6, 183);
            this.m_lblProfileHpf2.Name = "m_lblProfileHpf2";
            this.m_lblProfileHpf2.Size = new System.Drawing.Size(107, 15);
            this.m_lblProfileHpf2.TabIndex = 22;
            this.m_lblProfileHpf2.Text = "HPF2 Corner Freq";
            // 
            // m_cboProfileHpf1
            // 
            this.m_cboProfileHpf1.DisplayMember = "0";
            this.m_cboProfileHpf1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboProfileHpf1.FormattingEnabled = true;
            this.m_cboProfileHpf1.Items.AddRange(new object[] {
            "175K",
            "235K",
            "350K",
            "700K"});
            this.m_cboProfileHpf1.Location = new System.Drawing.Point(153, 144);
            this.m_cboProfileHpf1.Name = "m_cboProfileHpf1";
            this.m_cboProfileHpf1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboProfileHpf1.Size = new System.Drawing.Size(86, 23);
            this.m_cboProfileHpf1.TabIndex = 7;
            // 
            // m_lblProfileHpf1
            // 
            this.m_lblProfileHpf1.AutoSize = true;
            this.m_lblProfileHpf1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblProfileHpf1.Location = new System.Drawing.Point(6, 147);
            this.m_lblProfileHpf1.Name = "m_lblProfileHpf1";
            this.m_lblProfileHpf1.Size = new System.Drawing.Size(107, 15);
            this.m_lblProfileHpf1.TabIndex = 20;
            this.m_lblProfileHpf1.Text = "HPF1 Corner Freq";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_grpMeasureTxPower);
            this.groupBox1.Controls.Add(this.m_grpMeasureGainAndNF);
            this.groupBox1.Controls.Add(this.m_grpBasicCfgAnalysis);
            this.groupBox1.Controls.Add(this.m_grpCaptureAndPostProcess);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.m_grpProfile);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1371, 553);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ContStreaming";
            // 
            // m_grpMeasureTxPower
            // 
            this.m_grpMeasureTxPower.Controls.Add(this.label25);
            this.m_grpMeasureTxPower.Controls.Add(this.label24);
            this.m_grpMeasureTxPower.Controls.Add(this.label23);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblTx3ReflectedVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblTx3IncidentVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblTx3ReflectedPower);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblTx3TxOutPutPower);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblTx2ReflectedVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblTx2IncidentVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblTx2ReflectedPower);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblTx2TxOutPutPower);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice4TxOutPutPower);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice4ReflectedVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice4IncidentVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice4ReflectedPower);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice3TxOutPutPower);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice3ReflectedVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice3IncidentVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice3ReflectedPower);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice2TxOutPutPower);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice2ReflectedVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice2IncidentVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblRadarDevice2ReflectedPower);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblTxOutPutPower);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblReflectedVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblIncidentVoltage);
            this.m_grpMeasureTxPower.Controls.Add(this.m_lblReflectedPower);
            this.m_grpMeasureTxPower.Controls.Add(this.label14);
            this.m_grpMeasureTxPower.Controls.Add(this.label13);
            this.m_grpMeasureTxPower.Controls.Add(this.label12);
            this.m_grpMeasureTxPower.Controls.Add(this.label11);
            this.m_grpMeasureTxPower.Controls.Add(this.label10);
            this.m_grpMeasureTxPower.Controls.Add(this.m_btnMeasureTxPowerSet);
            this.m_grpMeasureTxPower.Controls.Add(this.m_nudTxPowerNoOfSamples);
            this.m_grpMeasureTxPower.Controls.Add(this.m_nudTxPowerNoOfAccumulations);
            this.m_grpMeasureTxPower.Controls.Add(this.label7);
            this.m_grpMeasureTxPower.Controls.Add(this.label6);
            this.m_grpMeasureTxPower.Location = new System.Drawing.Point(946, 21);
            this.m_grpMeasureTxPower.Name = "m_grpMeasureTxPower";
            this.m_grpMeasureTxPower.Size = new System.Drawing.Size(406, 290);
            this.m_grpMeasureTxPower.TabIndex = 57;
            this.m_grpMeasureTxPower.TabStop = false;
            this.m_grpMeasureTxPower.Text = "Measure Tx Power Config ";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(229, 160);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(26, 15);
            this.label25.TabIndex = 36;
            this.label25.Text = "Tx2";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(186, 160);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 15);
            this.label24.TabIndex = 35;
            this.label24.Text = "Tx1";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(145, 160);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(26, 15);
            this.label23.TabIndex = 34;
            this.label23.Text = "Tx0";
            // 
            // m_lblTx3ReflectedVoltage
            // 
            this.m_lblTx3ReflectedVoltage.AutoSize = true;
            this.m_lblTx3ReflectedVoltage.Location = new System.Drawing.Point(229, 270);
            this.m_lblTx3ReflectedVoltage.Name = "m_lblTx3ReflectedVoltage";
            this.m_lblTx3ReflectedVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblTx3ReflectedVoltage.TabIndex = 33;
            this.m_lblTx3ReflectedVoltage.Text = "0";
            // 
            // m_lblTx3IncidentVoltage
            // 
            this.m_lblTx3IncidentVoltage.AutoSize = true;
            this.m_lblTx3IncidentVoltage.Location = new System.Drawing.Point(229, 240);
            this.m_lblTx3IncidentVoltage.Name = "m_lblTx3IncidentVoltage";
            this.m_lblTx3IncidentVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblTx3IncidentVoltage.TabIndex = 32;
            this.m_lblTx3IncidentVoltage.Text = "0";
            // 
            // m_lblTx3ReflectedPower
            // 
            this.m_lblTx3ReflectedPower.AutoSize = true;
            this.m_lblTx3ReflectedPower.Location = new System.Drawing.Point(229, 210);
            this.m_lblTx3ReflectedPower.Name = "m_lblTx3ReflectedPower";
            this.m_lblTx3ReflectedPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblTx3ReflectedPower.TabIndex = 31;
            this.m_lblTx3ReflectedPower.Text = "0";
            // 
            // m_lblTx3TxOutPutPower
            // 
            this.m_lblTx3TxOutPutPower.AutoSize = true;
            this.m_lblTx3TxOutPutPower.Location = new System.Drawing.Point(229, 180);
            this.m_lblTx3TxOutPutPower.Name = "m_lblTx3TxOutPutPower";
            this.m_lblTx3TxOutPutPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblTx3TxOutPutPower.TabIndex = 30;
            this.m_lblTx3TxOutPutPower.Text = "0";
            // 
            // m_lblTx2ReflectedVoltage
            // 
            this.m_lblTx2ReflectedVoltage.AutoSize = true;
            this.m_lblTx2ReflectedVoltage.Location = new System.Drawing.Point(186, 270);
            this.m_lblTx2ReflectedVoltage.Name = "m_lblTx2ReflectedVoltage";
            this.m_lblTx2ReflectedVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblTx2ReflectedVoltage.TabIndex = 29;
            this.m_lblTx2ReflectedVoltage.Text = "0";
            // 
            // m_lblTx2IncidentVoltage
            // 
            this.m_lblTx2IncidentVoltage.AutoSize = true;
            this.m_lblTx2IncidentVoltage.Location = new System.Drawing.Point(186, 240);
            this.m_lblTx2IncidentVoltage.Name = "m_lblTx2IncidentVoltage";
            this.m_lblTx2IncidentVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblTx2IncidentVoltage.TabIndex = 28;
            this.m_lblTx2IncidentVoltage.Text = "0";
            // 
            // m_lblTx2ReflectedPower
            // 
            this.m_lblTx2ReflectedPower.AutoSize = true;
            this.m_lblTx2ReflectedPower.Location = new System.Drawing.Point(186, 210);
            this.m_lblTx2ReflectedPower.Name = "m_lblTx2ReflectedPower";
            this.m_lblTx2ReflectedPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblTx2ReflectedPower.TabIndex = 27;
            this.m_lblTx2ReflectedPower.Text = "0";
            // 
            // m_lblTx2TxOutPutPower
            // 
            this.m_lblTx2TxOutPutPower.AutoSize = true;
            this.m_lblTx2TxOutPutPower.Location = new System.Drawing.Point(186, 180);
            this.m_lblTx2TxOutPutPower.Name = "m_lblTx2TxOutPutPower";
            this.m_lblTx2TxOutPutPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblTx2TxOutPutPower.TabIndex = 26;
            this.m_lblTx2TxOutPutPower.Text = "0";
            // 
            // m_lblRadarDevice4TxOutPutPower
            // 
            this.m_lblRadarDevice4TxOutPutPower.AutoSize = true;
            this.m_lblRadarDevice4TxOutPutPower.Location = new System.Drawing.Point(380, 180);
            this.m_lblRadarDevice4TxOutPutPower.Name = "m_lblRadarDevice4TxOutPutPower";
            this.m_lblRadarDevice4TxOutPutPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice4TxOutPutPower.TabIndex = 25;
            this.m_lblRadarDevice4TxOutPutPower.Text = "0";
            // 
            // m_lblRadarDevice4ReflectedVoltage
            // 
            this.m_lblRadarDevice4ReflectedVoltage.AutoSize = true;
            this.m_lblRadarDevice4ReflectedVoltage.Location = new System.Drawing.Point(380, 270);
            this.m_lblRadarDevice4ReflectedVoltage.Name = "m_lblRadarDevice4ReflectedVoltage";
            this.m_lblRadarDevice4ReflectedVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice4ReflectedVoltage.TabIndex = 24;
            this.m_lblRadarDevice4ReflectedVoltage.Text = "0";
            // 
            // m_lblRadarDevice4IncidentVoltage
            // 
            this.m_lblRadarDevice4IncidentVoltage.AutoSize = true;
            this.m_lblRadarDevice4IncidentVoltage.Location = new System.Drawing.Point(380, 240);
            this.m_lblRadarDevice4IncidentVoltage.Name = "m_lblRadarDevice4IncidentVoltage";
            this.m_lblRadarDevice4IncidentVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice4IncidentVoltage.TabIndex = 23;
            this.m_lblRadarDevice4IncidentVoltage.Text = "0";
            // 
            // m_lblRadarDevice4ReflectedPower
            // 
            this.m_lblRadarDevice4ReflectedPower.AutoSize = true;
            this.m_lblRadarDevice4ReflectedPower.Location = new System.Drawing.Point(380, 210);
            this.m_lblRadarDevice4ReflectedPower.Name = "m_lblRadarDevice4ReflectedPower";
            this.m_lblRadarDevice4ReflectedPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice4ReflectedPower.TabIndex = 22;
            this.m_lblRadarDevice4ReflectedPower.Text = "0";
            // 
            // m_lblRadarDevice3TxOutPutPower
            // 
            this.m_lblRadarDevice3TxOutPutPower.AutoSize = true;
            this.m_lblRadarDevice3TxOutPutPower.Location = new System.Drawing.Point(357, 180);
            this.m_lblRadarDevice3TxOutPutPower.Name = "m_lblRadarDevice3TxOutPutPower";
            this.m_lblRadarDevice3TxOutPutPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice3TxOutPutPower.TabIndex = 21;
            this.m_lblRadarDevice3TxOutPutPower.Text = "0";
            // 
            // m_lblRadarDevice3ReflectedVoltage
            // 
            this.m_lblRadarDevice3ReflectedVoltage.AutoSize = true;
            this.m_lblRadarDevice3ReflectedVoltage.Location = new System.Drawing.Point(357, 270);
            this.m_lblRadarDevice3ReflectedVoltage.Name = "m_lblRadarDevice3ReflectedVoltage";
            this.m_lblRadarDevice3ReflectedVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice3ReflectedVoltage.TabIndex = 20;
            this.m_lblRadarDevice3ReflectedVoltage.Text = "0";
            // 
            // m_lblRadarDevice3IncidentVoltage
            // 
            this.m_lblRadarDevice3IncidentVoltage.AutoSize = true;
            this.m_lblRadarDevice3IncidentVoltage.Location = new System.Drawing.Point(357, 240);
            this.m_lblRadarDevice3IncidentVoltage.Name = "m_lblRadarDevice3IncidentVoltage";
            this.m_lblRadarDevice3IncidentVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice3IncidentVoltage.TabIndex = 19;
            this.m_lblRadarDevice3IncidentVoltage.Text = "0";
            // 
            // m_lblRadarDevice3ReflectedPower
            // 
            this.m_lblRadarDevice3ReflectedPower.AutoSize = true;
            this.m_lblRadarDevice3ReflectedPower.Location = new System.Drawing.Point(357, 210);
            this.m_lblRadarDevice3ReflectedPower.Name = "m_lblRadarDevice3ReflectedPower";
            this.m_lblRadarDevice3ReflectedPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice3ReflectedPower.TabIndex = 18;
            this.m_lblRadarDevice3ReflectedPower.Text = "0";
            // 
            // m_lblRadarDevice2TxOutPutPower
            // 
            this.m_lblRadarDevice2TxOutPutPower.AutoSize = true;
            this.m_lblRadarDevice2TxOutPutPower.Location = new System.Drawing.Point(332, 180);
            this.m_lblRadarDevice2TxOutPutPower.Name = "m_lblRadarDevice2TxOutPutPower";
            this.m_lblRadarDevice2TxOutPutPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice2TxOutPutPower.TabIndex = 17;
            this.m_lblRadarDevice2TxOutPutPower.Text = "0";
            // 
            // m_lblRadarDevice2ReflectedVoltage
            // 
            this.m_lblRadarDevice2ReflectedVoltage.AutoSize = true;
            this.m_lblRadarDevice2ReflectedVoltage.Location = new System.Drawing.Point(332, 270);
            this.m_lblRadarDevice2ReflectedVoltage.Name = "m_lblRadarDevice2ReflectedVoltage";
            this.m_lblRadarDevice2ReflectedVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice2ReflectedVoltage.TabIndex = 16;
            this.m_lblRadarDevice2ReflectedVoltage.Text = "0";
            // 
            // m_lblRadarDevice2IncidentVoltage
            // 
            this.m_lblRadarDevice2IncidentVoltage.AutoSize = true;
            this.m_lblRadarDevice2IncidentVoltage.Location = new System.Drawing.Point(332, 240);
            this.m_lblRadarDevice2IncidentVoltage.Name = "m_lblRadarDevice2IncidentVoltage";
            this.m_lblRadarDevice2IncidentVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice2IncidentVoltage.TabIndex = 15;
            this.m_lblRadarDevice2IncidentVoltage.Text = "0";
            // 
            // m_lblRadarDevice2ReflectedPower
            // 
            this.m_lblRadarDevice2ReflectedPower.AutoSize = true;
            this.m_lblRadarDevice2ReflectedPower.Location = new System.Drawing.Point(332, 210);
            this.m_lblRadarDevice2ReflectedPower.Name = "m_lblRadarDevice2ReflectedPower";
            this.m_lblRadarDevice2ReflectedPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice2ReflectedPower.TabIndex = 14;
            this.m_lblRadarDevice2ReflectedPower.Text = "0";
            // 
            // m_lblTxOutPutPower
            // 
            this.m_lblTxOutPutPower.AutoSize = true;
            this.m_lblTxOutPutPower.Location = new System.Drawing.Point(145, 180);
            this.m_lblTxOutPutPower.Name = "m_lblTxOutPutPower";
            this.m_lblTxOutPutPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblTxOutPutPower.TabIndex = 13;
            this.m_lblTxOutPutPower.Text = "0";
            // 
            // m_lblReflectedVoltage
            // 
            this.m_lblReflectedVoltage.AutoSize = true;
            this.m_lblReflectedVoltage.Location = new System.Drawing.Point(145, 270);
            this.m_lblReflectedVoltage.Name = "m_lblReflectedVoltage";
            this.m_lblReflectedVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblReflectedVoltage.TabIndex = 12;
            this.m_lblReflectedVoltage.Text = "0";
            // 
            // m_lblIncidentVoltage
            // 
            this.m_lblIncidentVoltage.AutoSize = true;
            this.m_lblIncidentVoltage.Location = new System.Drawing.Point(145, 240);
            this.m_lblIncidentVoltage.Name = "m_lblIncidentVoltage";
            this.m_lblIncidentVoltage.Size = new System.Drawing.Size(14, 15);
            this.m_lblIncidentVoltage.TabIndex = 11;
            this.m_lblIncidentVoltage.Text = "0";
            // 
            // m_lblReflectedPower
            // 
            this.m_lblReflectedPower.AutoSize = true;
            this.m_lblReflectedPower.Location = new System.Drawing.Point(145, 210);
            this.m_lblReflectedPower.Name = "m_lblReflectedPower";
            this.m_lblReflectedPower.Size = new System.Drawing.Size(14, 15);
            this.m_lblReflectedPower.TabIndex = 10;
            this.m_lblReflectedPower.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 180);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 15);
            this.label14.TabIndex = 9;
            this.label14.Text = "Tx Output Power (dBm)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 270);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 15);
            this.label13.TabIndex = 8;
            this.label13.Text = "Reflected Voltage (mV)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 15);
            this.label12.TabIndex = 7;
            this.label12.Text = "Incident Voltage (mV)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 210);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "Reflection Coeff.  (dB)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(6, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "Measure Tx Power Report";
            // 
            // m_btnMeasureTxPowerSet
            // 
            this.m_btnMeasureTxPowerSet.Location = new System.Drawing.Point(148, 98);
            this.m_btnMeasureTxPowerSet.Name = "m_btnMeasureTxPowerSet";
            this.m_btnMeasureTxPowerSet.Size = new System.Drawing.Size(83, 27);
            this.m_btnMeasureTxPowerSet.TabIndex = 4;
            this.m_btnMeasureTxPowerSet.Text = "Set";
            this.m_btnMeasureTxPowerSet.UseVisualStyleBackColor = true;
            // 
            // m_nudTxPowerNoOfSamples
            // 
            this.m_nudTxPowerNoOfSamples.Location = new System.Drawing.Point(144, 62);
            this.m_nudTxPowerNoOfSamples.Name = "m_nudTxPowerNoOfSamples";
            this.m_nudTxPowerNoOfSamples.Size = new System.Drawing.Size(86, 21);
            this.m_nudTxPowerNoOfSamples.TabIndex = 3;
            this.m_nudTxPowerNoOfSamples.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // m_nudTxPowerNoOfAccumulations
            // 
            this.m_nudTxPowerNoOfAccumulations.Location = new System.Drawing.Point(144, 26);
            this.m_nudTxPowerNoOfAccumulations.Name = "m_nudTxPowerNoOfAccumulations";
            this.m_nudTxPowerNoOfAccumulations.Size = new System.Drawing.Size(86, 21);
            this.m_nudTxPowerNoOfAccumulations.TabIndex = 2;
            this.m_nudTxPowerNoOfAccumulations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "No. of Samples";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "No. of Accumulations";
            // 
            // m_grpMeasureGainAndNF
            // 
            this.m_grpMeasureGainAndNF.Controls.Add(this.label5);
            this.m_grpMeasureGainAndNF.Controls.Add(this.label4);
            this.m_grpMeasureGainAndNF.Controls.Add(this.m_nudIFToneFreq);
            this.m_grpMeasureGainAndNF.Controls.Add(this.m_nudRxIPPower);
            this.m_grpMeasureGainAndNF.Controls.Add(this.m_nudRxChain);
            this.m_grpMeasureGainAndNF.Controls.Add(this.ddd);
            this.m_grpMeasureGainAndNF.Controls.Add(this.m_btnMeasureNF);
            this.m_grpMeasureGainAndNF.Controls.Add(this.label9);
            this.m_grpMeasureGainAndNF.Controls.Add(this.label8);
            this.m_grpMeasureGainAndNF.Controls.Add(this.m_btnMeasure_Gain);
            this.m_grpMeasureGainAndNF.Location = new System.Drawing.Point(696, 317);
            this.m_grpMeasureGainAndNF.Name = "m_grpMeasureGainAndNF";
            this.m_grpMeasureGainAndNF.Size = new System.Drawing.Size(281, 194);
            this.m_grpMeasureGainAndNF.TabIndex = 56;
            this.m_grpMeasureGainAndNF.TabStop = false;
            this.m_grpMeasureGainAndNF.Text = "Measure Gain and NF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Step2: With Sig gen OFF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Step1: With Sig gen ON";
            // 
            // m_nudIFToneFreq
            // 
            this.m_nudIFToneFreq.DecimalPlaces = 1;
            this.m_nudIFToneFreq.Location = new System.Drawing.Point(165, 90);
            this.m_nudIFToneFreq.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_nudIFToneFreq.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            -2147483648});
            this.m_nudIFToneFreq.Name = "m_nudIFToneFreq";
            this.m_nudIFToneFreq.Size = new System.Drawing.Size(75, 21);
            this.m_nudIFToneFreq.TabIndex = 6;
            // 
            // m_nudRxIPPower
            // 
            this.m_nudRxIPPower.DecimalPlaces = 1;
            this.m_nudRxIPPower.Location = new System.Drawing.Point(165, 60);
            this.m_nudRxIPPower.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.m_nudRxIPPower.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            -2147483648});
            this.m_nudRxIPPower.Name = "m_nudRxIPPower";
            this.m_nudRxIPPower.Size = new System.Drawing.Size(75, 21);
            this.m_nudRxIPPower.TabIndex = 5;
            this.m_nudRxIPPower.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // m_nudRxChain
            // 
            this.m_nudRxChain.Location = new System.Drawing.Point(165, 30);
            this.m_nudRxChain.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_nudRxChain.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_nudRxChain.Name = "m_nudRxChain";
            this.m_nudRxChain.Size = new System.Drawing.Size(75, 21);
            this.m_nudRxChain.TabIndex = 4;
            this.m_nudRxChain.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ddd
            // 
            this.ddd.AutoSize = true;
            this.ddd.Location = new System.Drawing.Point(2, 94);
            this.ddd.Name = "ddd";
            this.ddd.Size = new System.Drawing.Size(112, 15);
            this.ddd.TabIndex = 3;
            this.ddd.Text = "Meas IF Freq (MHz)";
            // 
            // m_btnMeasureNF
            // 
            this.m_btnMeasureNF.Location = new System.Drawing.Point(165, 150);
            this.m_btnMeasureNF.Name = "m_btnMeasureNF";
            this.m_btnMeasureNF.Size = new System.Drawing.Size(103, 23);
            this.m_btnMeasureNF.TabIndex = 0;
            this.m_btnMeasureNF.Text = "Measure NF";
            this.m_btnMeasureNF.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Rx i/p pow @ AR ball (dBm)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Rx Chain under Test";
            // 
            // m_btnMeasure_Gain
            // 
            this.m_btnMeasure_Gain.Location = new System.Drawing.Point(165, 120);
            this.m_btnMeasure_Gain.Name = "m_btnMeasure_Gain";
            this.m_btnMeasure_Gain.Size = new System.Drawing.Size(103, 23);
            this.m_btnMeasure_Gain.TabIndex = 0;
            this.m_btnMeasure_Gain.Text = "Measure Gain";
            this.m_btnMeasure_Gain.UseVisualStyleBackColor = true;
            // 
            // m_grpBasicCfgAnalysis
            // 
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_ChkEnaTriggerCaptureYes);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_ChkRemoveDCYes);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_btnBasicConfigForAnalysisSet);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_nudFFTSize);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_cboWindowSelection);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_cboWindowCompensation);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_nudNumOfAverages);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_nudNumOfSamples);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_lblWindowCompensation);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_lblRemoveDC);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_lblEnableTriggerdCapture);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_lblWindowSelection);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_lblNumberOfAverages);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_lblFFTSize);
            this.m_grpBasicCfgAnalysis.Controls.Add(this.m_lblNumberOfSamples);
            this.m_grpBasicCfgAnalysis.Location = new System.Drawing.Point(579, 19);
            this.m_grpBasicCfgAnalysis.Name = "m_grpBasicCfgAnalysis";
            this.m_grpBasicCfgAnalysis.Size = new System.Drawing.Size(361, 283);
            this.m_grpBasicCfgAnalysis.TabIndex = 53;
            this.m_grpBasicCfgAnalysis.TabStop = false;
            this.m_grpBasicCfgAnalysis.Text = "Basic Configuration For Analysis";
            // 
            // m_ChkEnaTriggerCaptureYes
            // 
            this.m_ChkEnaTriggerCaptureYes.AutoSize = true;
            this.m_ChkEnaTriggerCaptureYes.Location = new System.Drawing.Point(196, 180);
            this.m_ChkEnaTriggerCaptureYes.Name = "m_ChkEnaTriggerCaptureYes";
            this.m_ChkEnaTriggerCaptureYes.Size = new System.Drawing.Size(15, 14);
            this.m_ChkEnaTriggerCaptureYes.TabIndex = 20;
            this.m_ChkEnaTriggerCaptureYes.UseVisualStyleBackColor = true;
            // 
            // m_ChkRemoveDCYes
            // 
            this.m_ChkRemoveDCYes.AutoSize = true;
            this.m_ChkRemoveDCYes.Location = new System.Drawing.Point(196, 150);
            this.m_ChkRemoveDCYes.Name = "m_ChkRemoveDCYes";
            this.m_ChkRemoveDCYes.Size = new System.Drawing.Size(15, 14);
            this.m_ChkRemoveDCYes.TabIndex = 18;
            this.m_ChkRemoveDCYes.UseVisualStyleBackColor = true;
            // 
            // m_btnBasicConfigForAnalysisSet
            // 
            this.m_btnBasicConfigForAnalysisSet.Location = new System.Drawing.Point(261, 249);
            this.m_btnBasicConfigForAnalysisSet.Name = "m_btnBasicConfigForAnalysisSet";
            this.m_btnBasicConfigForAnalysisSet.Size = new System.Drawing.Size(83, 27);
            this.m_btnBasicConfigForAnalysisSet.TabIndex = 17;
            this.m_btnBasicConfigForAnalysisSet.Text = "Set (3)";
            this.m_btnBasicConfigForAnalysisSet.UseVisualStyleBackColor = true;
            // 
            // m_nudFFTSize
            // 
            this.m_nudFFTSize.Location = new System.Drawing.Point(196, 60);
            this.m_nudFFTSize.Maximum = new decimal(new int[] {
            -2000001,
            0,
            0,
            0});
            this.m_nudFFTSize.Name = "m_nudFFTSize";
            this.m_nudFFTSize.Size = new System.Drawing.Size(148, 21);
            this.m_nudFFTSize.TabIndex = 16;
            // 
            // m_cboWindowSelection
            // 
            this.m_cboWindowSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboWindowSelection.FormattingEnabled = true;
            this.m_cboWindowSelection.Items.AddRange(new object[] {
            "No Window",
            "Hann",
            "Blackman-Harris",
            "Flat-Top"});
            this.m_cboWindowSelection.Location = new System.Drawing.Point(196, 120);
            this.m_cboWindowSelection.Name = "m_cboWindowSelection";
            this.m_cboWindowSelection.Size = new System.Drawing.Size(148, 23);
            this.m_cboWindowSelection.TabIndex = 15;
            // 
            // m_cboWindowCompensation
            // 
            this.m_cboWindowCompensation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboWindowCompensation.FormattingEnabled = true;
            this.m_cboWindowCompensation.Items.AddRange(new object[] {
            "No Equalization",
            "Gain Compensation",
            "Energy Compensation"});
            this.m_cboWindowCompensation.Location = new System.Drawing.Point(196, 210);
            this.m_cboWindowCompensation.Name = "m_cboWindowCompensation";
            this.m_cboWindowCompensation.Size = new System.Drawing.Size(148, 23);
            this.m_cboWindowCompensation.TabIndex = 12;
            // 
            // m_nudNumOfAverages
            // 
            this.m_nudNumOfAverages.Location = new System.Drawing.Point(196, 90);
            this.m_nudNumOfAverages.Maximum = new decimal(new int[] {
            6536,
            0,
            0,
            0});
            this.m_nudNumOfAverages.Name = "m_nudNumOfAverages";
            this.m_nudNumOfAverages.Size = new System.Drawing.Size(148, 21);
            this.m_nudNumOfAverages.TabIndex = 8;
            // 
            // m_nudNumOfSamples
            // 
            this.m_nudNumOfSamples.Location = new System.Drawing.Point(196, 30);
            this.m_nudNumOfSamples.Maximum = new decimal(new int[] {
            -2000001,
            0,
            0,
            0});
            this.m_nudNumOfSamples.Name = "m_nudNumOfSamples";
            this.m_nudNumOfSamples.Size = new System.Drawing.Size(148, 21);
            this.m_nudNumOfSamples.TabIndex = 7;
            // 
            // m_lblWindowCompensation
            // 
            this.m_lblWindowCompensation.AutoSize = true;
            this.m_lblWindowCompensation.Location = new System.Drawing.Point(15, 210);
            this.m_lblWindowCompensation.Name = "m_lblWindowCompensation";
            this.m_lblWindowCompensation.Size = new System.Drawing.Size(136, 15);
            this.m_lblWindowCompensation.TabIndex = 6;
            this.m_lblWindowCompensation.Text = "Window Compensation";
            // 
            // m_lblRemoveDC
            // 
            this.m_lblRemoveDC.AutoSize = true;
            this.m_lblRemoveDC.Location = new System.Drawing.Point(15, 150);
            this.m_lblRemoveDC.Name = "m_lblRemoveDC";
            this.m_lblRemoveDC.Size = new System.Drawing.Size(74, 15);
            this.m_lblRemoveDC.TabIndex = 5;
            this.m_lblRemoveDC.Text = "Remove DC";
            // 
            // m_lblEnableTriggerdCapture
            // 
            this.m_lblEnableTriggerdCapture.AutoSize = true;
            this.m_lblEnableTriggerdCapture.Location = new System.Drawing.Point(15, 180);
            this.m_lblEnableTriggerdCapture.Name = "m_lblEnableTriggerdCapture";
            this.m_lblEnableTriggerdCapture.Size = new System.Drawing.Size(149, 15);
            this.m_lblEnableTriggerdCapture.TabIndex = 4;
            this.m_lblEnableTriggerdCapture.Text = "Enable Triggered Capture";
            // 
            // m_lblWindowSelection
            // 
            this.m_lblWindowSelection.AutoSize = true;
            this.m_lblWindowSelection.Location = new System.Drawing.Point(15, 120);
            this.m_lblWindowSelection.Name = "m_lblWindowSelection";
            this.m_lblWindowSelection.Size = new System.Drawing.Size(105, 15);
            this.m_lblWindowSelection.TabIndex = 3;
            this.m_lblWindowSelection.Text = "Window Selection";
            // 
            // m_lblNumberOfAverages
            // 
            this.m_lblNumberOfAverages.AutoSize = true;
            this.m_lblNumberOfAverages.Location = new System.Drawing.Point(15, 90);
            this.m_lblNumberOfAverages.Name = "m_lblNumberOfAverages";
            this.m_lblNumberOfAverages.Size = new System.Drawing.Size(120, 15);
            this.m_lblNumberOfAverages.TabIndex = 2;
            this.m_lblNumberOfAverages.Text = "Number Of Averages";
            // 
            // m_lblFFTSize
            // 
            this.m_lblFFTSize.AutoSize = true;
            this.m_lblFFTSize.Location = new System.Drawing.Point(15, 60);
            this.m_lblFFTSize.Name = "m_lblFFTSize";
            this.m_lblFFTSize.Size = new System.Drawing.Size(54, 15);
            this.m_lblFFTSize.TabIndex = 1;
            this.m_lblFFTSize.Text = "FFT Size";
            // 
            // m_lblNumberOfSamples
            // 
            this.m_lblNumberOfSamples.AutoSize = true;
            this.m_lblNumberOfSamples.Location = new System.Drawing.Point(15, 30);
            this.m_lblNumberOfSamples.Name = "m_lblNumberOfSamples";
            this.m_lblNumberOfSamples.Size = new System.Drawing.Size(120, 15);
            this.m_lblNumberOfSamples.TabIndex = 0;
            this.m_lblNumberOfSamples.Text = "Number Of Samples";
            // 
            // m_grpCaptureAndPostProcess
            // 
            this.m_grpCaptureAndPostProcess.Controls.Add(this.m_btnBasicConfigForAnalysisAndDisplay);
            this.m_grpCaptureAndPostProcess.Controls.Add(this.m_btnContinuousADCCapture);
            this.m_grpCaptureAndPostProcess.Controls.Add(this.f0001a1);
            this.m_grpCaptureAndPostProcess.Controls.Add(this.label3);
            this.m_grpCaptureAndPostProcess.Controls.Add(this.m_btnAdcDataTar);
            this.m_grpCaptureAndPostProcess.Location = new System.Drawing.Point(200, 317);
            this.m_grpCaptureAndPostProcess.Name = "m_grpCaptureAndPostProcess";
            this.m_grpCaptureAndPostProcess.Size = new System.Drawing.Size(481, 165);
            this.m_grpCaptureAndPostProcess.TabIndex = 52;
            this.m_grpCaptureAndPostProcess.TabStop = false;
            this.m_grpCaptureAndPostProcess.Text = "Capture and Post Process";
            // 
            // m_btnBasicConfigForAnalysisAndDisplay
            // 
            this.m_btnBasicConfigForAnalysisAndDisplay.Location = new System.Drawing.Point(363, 79);
            this.m_btnBasicConfigForAnalysisAndDisplay.Name = "m_btnBasicConfigForAnalysisAndDisplay";
            this.m_btnBasicConfigForAnalysisAndDisplay.Size = new System.Drawing.Size(100, 33);
            this.m_btnBasicConfigForAnalysisAndDisplay.TabIndex = 54;
            this.m_btnBasicConfigForAnalysisAndDisplay.Text = "Display (5)";
            this.m_btnBasicConfigForAnalysisAndDisplay.UseVisualStyleBackColor = true;
            // 
            // m_btnContinuousADCCapture
            // 
            this.m_btnContinuousADCCapture.Location = new System.Drawing.Point(70, 79);
            this.m_btnContinuousADCCapture.Name = "m_btnContinuousADCCapture";
            this.m_btnContinuousADCCapture.Size = new System.Drawing.Size(106, 33);
            this.m_btnContinuousADCCapture.TabIndex = 53;
            this.m_btnContinuousADCCapture.Text = "Capture (4)";
            this.m_btnContinuousADCCapture.UseVisualStyleBackColor = true;
            // 
            // f0001a1
            // 
            this.f0001a1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.f0001a1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.f0001a1.FormattingEnabled = true;
            this.f0001a1.Location = new System.Drawing.Point(70, 33);
            this.f0001a1.Name = "f0001a1";
            this.f0001a1.Size = new System.Drawing.Size(305, 23);
            this.f0001a1.TabIndex = 52;
            this.f0001a1.Text = "C:\\RadarStudio\\PostProc\\adc_data.bin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 51;
            this.label3.Text = "Dump File:";
            // 
            // m_btnAdcDataTar
            // 
            this.m_btnAdcDataTar.Location = new System.Drawing.Point(381, 29);
            this.m_btnAdcDataTar.Name = "m_btnAdcDataTar";
            this.m_btnAdcDataTar.Size = new System.Drawing.Size(83, 27);
            this.m_btnAdcDataTar.TabIndex = 15;
            this.m_btnAdcDataTar.Text = "Browse";
            this.m_btnAdcDataTar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.f0001a0);
            this.groupBox2.Location = new System.Drawing.Point(19, 317);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 113);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "StreamEnable";
            // 
            // f0001a0
            // 
            this.f0001a0.Location = new System.Drawing.Point(48, 54);
            this.f0001a0.Name = "f0001a0";
            this.f0001a0.Size = new System.Drawing.Size(83, 27);
            this.f0001a0.TabIndex = 13;
            this.f0001a0.Text = "Enable (2)";
            this.f0001a0.UseVisualStyleBackColor = true;
            // 
            // ContStreamingTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Name = "ContStreamingTab";
            this.Size = new System.Drawing.Size(1392, 559);
            this.m_grpProfile.ResumeLayout(false);
            this.m_grpProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx2OutPowerBackoffCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx1OutPowerBackoffCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx3PhaseShifter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx2PhaseShifter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudProfileRxGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx1PhaseShifter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTx3OutPowerBackoffCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudStartFreqConst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDigOutSampleRate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.m_grpMeasureTxPower.ResumeLayout(false);
            this.m_grpMeasureTxPower.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTxPowerNoOfSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTxPowerNoOfAccumulations)).EndInit();
            this.m_grpMeasureGainAndNF.ResumeLayout(false);
            this.m_grpMeasureGainAndNF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudIFToneFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxIPPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRxChain)).EndInit();
            this.m_grpBasicCfgAnalysis.ResumeLayout(false);
            this.m_grpBasicCfgAnalysis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFFTSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudNumOfAverages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudNumOfSamples)).EndInit();
            this.m_grpCaptureAndPostProcess.ResumeLayout(false);
            this.m_grpCaptureAndPostProcess.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		private void PostInit()
		{
			m_cboProfileHpf1.SelectedIndex = 0;
			m_cboProfileHpf2.SelectedIndex = 0;
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		private ContStreamParams m_ContStreamParams;

		private BasicConfigurationForAnalysisParams m_BasicConfigurationForAnalysisParams;

		public MeasureTxPowerParams m_MeasureTxPowerParams;

		public StaticParams m_StaticParams;

		private IContainer components;

		private GroupBox m_grpProfile;

		private NumericUpDown m_nudTx2OutPowerBackoffCode;

		private NumericUpDown m_nudTx1OutPowerBackoffCode;

		private Label m_lblProfileTx2OpPwrBackoff;

		private Label m_lblProfileTx1OpPwrBackoff;

		private Label label2;

		private Label label1;

		private NumericUpDown m_nudTx3PhaseShifter;

		private NumericUpDown m_nudTx2PhaseShifter;

		private Button m_btnProfileSet;

		private NumericUpDown m_nudTx1PhaseShifter;

		private Label m_lblProfilePhaseShifter;

		private NumericUpDown m_nudTx3OutPowerBackoffCode;

		private Label m_lblProfileTx3OpPwrBackoff;

		private NumericUpDown m_nudStartFreqConst;

		private Label m_lblProfileStartFreqConst;

		private NumericUpDown m_nudDigOutSampleRate;

		private Label m_lblProfileSampleRate;

		private ComboBox m_cboProfileHpf2;

		private Label m_lblProfileHpf2;

		private ComboBox m_cboProfileHpf1;

		private Label m_lblProfileHpf1;

		private NumericUpDown m_nudProfileRxGain;

		private Label m_lblProfileRxGain;

		private GroupBox groupBox1;

		private GroupBox groupBox2;

		private Button f0001a0;

		private Button m_btnAdcDataTar;

		private Label label3;

		private SaveFileDialog m_fdlgContStrData;

		private GroupBox m_grpCaptureAndPostProcess;

		private ComboBox f0001a1;

		private GroupBox m_grpBasicCfgAnalysis;

		private Label m_lblWindowCompensation;

		private Label m_lblRemoveDC;

		private Label m_lblEnableTriggerdCapture;

		private Label m_lblWindowSelection;

		private Label m_lblNumberOfAverages;

		private Label m_lblFFTSize;

		private Label m_lblNumberOfSamples;

		private ComboBox m_cboWindowCompensation;

		private NumericUpDown m_nudNumOfAverages;

		private NumericUpDown m_nudNumOfSamples;

		private ComboBox m_cboWindowSelection;

		private NumericUpDown m_nudFFTSize;

		private Button m_btnBasicConfigForAnalysisSet;

		private CheckBox m_ChkEnaTriggerCaptureYes;

		private CheckBox m_ChkRemoveDCYes;

		private Button m_btnBasicConfigForAnalysisAndDisplay;

		private Button m_btnContinuousADCCapture;
		private GroupBox m_grpMeasureGainAndNF;
		private NumericUpDown m_nudIFToneFreq;
		private NumericUpDown m_nudRxIPPower;
		private NumericUpDown m_nudRxChain;
		private Label ddd;
		private Label label9;
		private Label label8;
		private Button m_btnMeasure_Gain;
		private Button m_btnMeasureNF;
		private Label label5;
		private Label label4;
		private GroupBox m_grpMeasureTxPower;
		private Label label14;
		private Label label13;

		private Label label12;
		private Label label11;
		private Label label10;
		private Button m_btnMeasureTxPowerSet;
		private NumericUpDown m_nudTxPowerNoOfSamples;
		private NumericUpDown m_nudTxPowerNoOfAccumulations;
		private Label label7;
		private Label label6;
		private Label m_lblRadarDevice4TxOutPutPower;
		private Label m_lblRadarDevice4ReflectedVoltage;
		private Label m_lblRadarDevice4IncidentVoltage;
		private Label m_lblRadarDevice4ReflectedPower;
		private Label m_lblRadarDevice3TxOutPutPower;
		private Label m_lblRadarDevice3ReflectedVoltage;
		private Label m_lblRadarDevice3IncidentVoltage;
		private Label m_lblRadarDevice3ReflectedPower;
		private Label m_lblRadarDevice2TxOutPutPower;
		private Label m_lblRadarDevice2ReflectedVoltage;
		private Label m_lblRadarDevice2IncidentVoltage;
		private Label m_lblRadarDevice2ReflectedPower;
		private Label m_lblTxOutPutPower;
		private Label m_lblReflectedVoltage;
		private Label m_lblIncidentVoltage;
		private Label m_lblReflectedPower;
		private Label label25;
		private Label label24;
		private Label label23;
		private Label m_lblTx3ReflectedVoltage;
		private Label m_lblTx3IncidentVoltage;
		private Label m_lblTx3ReflectedPower;
		private Label m_lblTx3TxOutPutPower;

		private Label m_lblTx2ReflectedVoltage;

		private Label m_lblTx2IncidentVoltage;

		private Label m_lblTx2ReflectedPower;

		private Label m_lblTx2TxOutPutPower;

		private Label label16;

		private Label label15;

		private CheckBox m_ChkForceVCOSelect;

		private ComboBox m_cboVCOSelect;

		private ComboBox m_cboRFGainTarget;
	}
}
