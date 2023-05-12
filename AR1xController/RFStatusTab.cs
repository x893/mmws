using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class RFStatusTab : UserControl
	{
		public RFStatusTab()
		{
			m_MainForm = m_GuiManager.MainTsForm;
			m_RFStatusConfigParams = m_GuiManager.TsParams.RFStatusConfigParams;
			m_RFCharReportConfigParams = m_GuiManager.TsParams.RFCharReportConfigParams;
			m_RFCalibEnaDisConfigParams = m_GuiManager.TsParams.RFCalibEnaDisConfigParams;
			m_RFCalibMonConfigParams = m_GuiManager.TsParams.RFCalibMonConfigParams;
			m_TemperatrueSensorTempDataConfigParams = m_GuiManager.TsParams.TemperatrueSensorTempDataConfigParams;
			f000210 = m_GuiManager.TsParams.p000004;
			m_MeasurePDPowerConfigParams = m_GuiManager.TsParams.MeasurePDPowerConfigParams;
			m_MonSynthFreqLinearityConfigParams = m_GuiManager.TsParams.MonSynthFreqLinearityConfigParams;
			InitializeComponent();
			f000217.Text = "0.0";
			f000216.Text = "0.0";
			f000215.Text = "0.0";
			m_nudGPADCNumOfSamples.Value = 4m;
			m_CbPDType.SelectedIndex = 0;
			SetTheDefaultValuesOfPDTrim1GHZ();
		}

		public void SetTheDefaultValuesOfPDTrim1GHZ()
		{
			m_CbPDInstance.SelectedIndex = 0;
			f000225.SelectedIndex = 0;
			f000224.SelectedIndex = 0;
			m_CbPDTrimMode.SelectedIndex = 0;
		}

		public bool UpdateRFStatusConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRFStatusConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_RFStatusConfigParams.f000001 = (uint)m_nudGPADConfigVal.Value;
				m_RFStatusConfigParams.f000002 = (byte)m_nudGPADCParamVal.Value;
				m_RFStatusConfigParams.f000003 = (byte)m_nudGPADCNumOfSamples.Value;
				m_RFStatusConfigParams.GPADCNumOfSkipClocksMant = (byte)m_nudSkipClockMant.Value;
				m_RFStatusConfigParams.GPADCNumOfSkipClocksExp = (byte)m_nudSkipClockExp.Value;
				if (m_RFStatusConfigParams.f000003 == 0)
				{
					MessageBox.Show("Incorrect number of samples!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRFStatusConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRFStatusConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudGPADConfigVal.Value = m_RFStatusConfigParams.f000001;
				m_nudGPADCParamVal.Value = m_RFStatusConfigParams.f000002;
				m_nudGPADCNumOfSamples.Value = m_RFStatusConfigParams.f000003;
				m_nudSkipClockMant.Value = m_RFStatusConfigParams.GPADCNumOfSkipClocksMant;
				m_nudSkipClockExp.Value = m_RFStatusConfigParams.GPADCNumOfSkipClocksExp;
				if (m_RFStatusConfigParams.f000003 == 0)
				{
					MessageBox.Show("Incorrect number of samples!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetRFStatusConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetRFStatusConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFStatusConfig()
		{
			iSetRFStatusConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iSetRFStatusConfigAsync()
		{
			new del_v_v(iSetRFStatusConfig).BeginInvoke(null, null);
		}

		private void m_btnRFStatusCfg_Click(object sender, EventArgs p1)
		{
			iSetRFStatusConfigAsync();
		}

		public void SetGPADCAvgDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetGPADCAvgDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				f000217.Text = p0;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				f00021a.Text = p0;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				f000220.Text = p0;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				f00021d.Text = p0;
			}
		}

		public void SetGPADCMinDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetGPADCMinDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				f000216.Text = p0;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				f000222.Text = p0;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				f00021f.Text = p0;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				f00021c.Text = p0;
			}
		}

		public void SetGPADCMaxDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetGPADCMaxDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				f000215.Text = p0;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				f000221.Text = p0;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				f00021e.Text = p0;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				f00021b.Text = p0;
			}
		}

		public void SetTimeTempSensinGUI(string Time)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetTimeTempSensinGUI);
				base.Invoke(method, new object[]
				{
					Time
				});
				return;
			}
			m_lblTime.Text = Time;
		}

		public void SetTimeTempSensinGUI2(string Time)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetTimeTempSensinGUI2);
				base.Invoke(method, new object[]
				{
					Time
				});
				return;
			}
			m_lblRadarDevice2Time.Text = Time;
		}

		public void SetTx0TempSensinGUI(string Tx0TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetTx0TempSensinGUI);
				base.Invoke(method, new object[]
				{
					Tx0TempSens
				});
				return;
			}
			m_lblTx0TSValue.Text = Tx0TempSens;
		}

		public void SetTx0TempSensinGUI2(string Tx0TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetTx0TempSensinGUI2);
				base.Invoke(method, new object[]
				{
					Tx0TempSens
				});
				return;
			}
			m_lblRadarDevice2Tx0TSValue.Text = Tx0TempSens;
		}

		public void SetTx1TempSensinGUI(string Tx1TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetTx1TempSensinGUI);
				base.Invoke(method, new object[]
				{
					Tx1TempSens
				});
				return;
			}
			m_lblTx1TSValue.Text = Tx1TempSens;
		}

		public void SetTx1TempSensinGUI2(string Tx1TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetTx1TempSensinGUI2);
				base.Invoke(method, new object[]
				{
					Tx1TempSens
				});
				return;
			}
			m_lblRadarDevice2Tx1TSValue.Text = Tx1TempSens;
		}

		public void SetTx2TempSensinGUI(string Tx2TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetTx2TempSensinGUI);
				base.Invoke(method, new object[]
				{
					Tx2TempSens
				});
				return;
			}
			m_lblTx2TSValue.Text = Tx2TempSens;
		}

		public void SetTx2TempSensinGUI2(string Tx2TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetTx2TempSensinGUI2);
				base.Invoke(method, new object[]
				{
					Tx2TempSens
				});
				return;
			}
			m_lblRadarDevice2Tx2TSValue.Text = Tx2TempSens;
		}

		public void SetRx0TempSensinGUI(string Rx0TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetRx0TempSensinGUI);
				base.Invoke(method, new object[]
				{
					Rx0TempSens
				});
				return;
			}
			m_lblRx0TSValue.Text = Rx0TempSens;
		}

		public void SetRx0TempSensinGUI2(string Rx0TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetRx0TempSensinGUI2);
				base.Invoke(method, new object[]
				{
					Rx0TempSens
				});
				return;
			}
			m_lblRadarDevice2Rx0TSValue.Text = Rx0TempSens;
		}

		public void SetRx1TempSensinGUI(string Rx1TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetRx1TempSensinGUI);
				base.Invoke(method, new object[]
				{
					Rx1TempSens
				});
				return;
			}
			m_lblRx1TSValue.Text = Rx1TempSens;
		}

		public void SetRx1TempSensinGUI2(string Rx1TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetRx1TempSensinGUI2);
				base.Invoke(method, new object[]
				{
					Rx1TempSens
				});
				return;
			}
			m_lblRadarDevice2Rx1TSValue.Text = Rx1TempSens;
		}

		public void SetRx2TempSensinGUI(string Rx2TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetRx2TempSensinGUI);
				base.Invoke(method, new object[]
				{
					Rx2TempSens
				});
				return;
			}
			m_lblRx2TSValue.Text = Rx2TempSens;
		}

		public void SetRx2TempSensinGUI2(string Rx2TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetRx2TempSensinGUI2);
				base.Invoke(method, new object[]
				{
					Rx2TempSens
				});
				return;
			}
			m_lblRadarDevice2Rx2TSValue.Text = Rx2TempSens;
		}

		public void SetRx3TempSensinGUI(string Rx3TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetRx3TempSensinGUI);
				base.Invoke(method, new object[]
				{
					Rx3TempSens
				});
				return;
			}
			m_lblRx3TSValue.Text = Rx3TempSens;
		}

		public void SetRx3TempSensinGUI2(string Rx3TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetRx3TempSensinGUI2);
				base.Invoke(method, new object[]
				{
					Rx3TempSens
				});
				return;
			}
			m_lblRadarDevice2Rx3TSValue.Text = Rx3TempSens;
		}

		public void m000062(string PMTempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m000062);
				base.Invoke(method, new object[]
				{
					PMTempSens
				});
				return;
			}
			f00017e.Text = PMTempSens;
		}

		public void m000063(string PMTempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m000063);
				base.Invoke(method, new object[]
				{
					PMTempSens
				});
				return;
			}
			f000184.Text = PMTempSens;
		}

		public void SetDigTempSensinGUI(string DigTempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetDigTempSensinGUI);
				base.Invoke(method, new object[]
				{
					DigTempSens
				});
				return;
			}
			m_lblDigTSValue.Text = DigTempSens;
		}

		public void SetDig2TempSensinGUI(string Dig2TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetDig2TempSensinGUI);
				base.Invoke(method, new object[]
				{
					Dig2TempSens
				});
				return;
			}
			f00018d.Text = Dig2TempSens;
		}

		public void SetDigTempSensinGUI2(string DigTempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetDigTempSensinGUI2);
				base.Invoke(method, new object[]
				{
					DigTempSens
				});
				return;
			}
			m_lblRadarDevice2DigTSValue.Text = DigTempSens;
		}

		public void SetDig2TempSensinGUI2(string Dig2TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetDig2TempSensinGUI2);
				base.Invoke(method, new object[]
				{
					Dig2TempSens
				});
				return;
			}
			f00018d.Text = Dig2TempSens;
		}

		public void UpdatetRFTempSensinCascadeModeToGUI(uint RadarDevId, string time, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string tmpDig0Sens, string Dig2TempSens)
		{
			if (base.InvokeRequired)
			{
				delegate0e5 method = new delegate0e5(UpdatetRFTempSensinCascadeModeToGUI);
				base.Invoke(method, new object[]
				{
					RadarDevId,
					time,
					p2,
					p3,
					p4,
					p5,
					p6,
					p7,
					p8,
					p9,
					tmpDig0Sens,
					Dig2TempSens
				});
				return;
			}
			if (RadarDevId == 0U)
			{
				m_lblTime.Text = time;
				m_lblRx0TSValue.Text = p2;
				m_lblRx1TSValue.Text = p3;
				m_lblRx2TSValue.Text = p4;
				m_lblRx3TSValue.Text = p5;
				m_lblTx0TSValue.Text = p6;
				m_lblTx1TSValue.Text = p7;
				m_lblTx2TSValue.Text = p8;
				f00017e.Text = p9;
				m_lblDigTSValue.Text = tmpDig0Sens;
				f00018d.Text = Dig2TempSens;
				return;
			}
			if (RadarDevId == 1U)
			{
				m_lblRadarDevice2Time.Text = time;
				m_lblRadarDevice2Rx0TSValue.Text = p2;
				m_lblRadarDevice2Rx1TSValue.Text = p3;
				m_lblRadarDevice2Rx2TSValue.Text = p4;
				m_lblRadarDevice2Rx3TSValue.Text = p5;
				m_lblRadarDevice2Tx0TSValue.Text = p6;
				m_lblRadarDevice2Tx1TSValue.Text = p7;
				m_lblRadarDevice2Tx2TSValue.Text = p8;
				f000184.Text = p9;
				m_lblRadarDevice2DigTSValue.Text = tmpDig0Sens;
				f00018c.Text = Dig2TempSens;
				return;
			}
			if (RadarDevId == 2U)
			{
				m_lblRadarDevice3Time.Text = time;
				m_lblRadarDevice3Rx0TSValue.Text = p2;
				m_lblRadarDevice3Rx1TSValue.Text = p3;
				m_lblRadarDevice3Rx2TSValue.Text = p4;
				m_lblRadarDevice3Rx3TSValue.Text = p5;
				m_lblRadarDevice3Tx0TSValue.Text = p6;
				m_lblRadarDevice3Tx1TSValue.Text = p7;
				m_lblRadarDevice3Tx2TSValue.Text = p8;
				f000180.Text = p9;
				m_lblRadarDevice3DigTSValue.Text = tmpDig0Sens;
				f00018b.Text = Dig2TempSens;
				return;
			}
			if (RadarDevId == 3U)
			{
				m_lblRadarDevice4Time.Text = time;
				m_lblRadarDevice4Rx0TSValue.Text = p2;
				m_lblRadarDevice4Rx1TSValue.Text = p3;
				m_lblRadarDevice4Rx2TSValue.Text = p4;
				m_lblRadarDevice4Rx3TSValue.Text = p5;
				m_lblRadarDevice4Tx0TSValue.Text = p6;
				m_lblRadarDevice4Tx1TSValue.Text = p7;
				m_lblRadarDevice4Tx2TSValue.Text = p8;
				f000182.Text = p9;
				m_lblRadarDevice4DigTSValue.Text = tmpDig0Sens;
				f00018a.Text = Dig2TempSens;
			}
		}

		public bool UpdateRFCharReportConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRFCharReportConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_RFCharReportConfigParams.AeReportPeriod = (ushort)m_nudAeReportPeriod.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRFCharReportConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRFCharReportConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudAeReportPeriod.Value = m_RFCharReportConfigParams.AeReportPeriod;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetRFCharReportConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetRFCharReportConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFCharReportConfig()
		{
			iSetRFCharReportConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iSetRFCharReportConfigAsync()
		{
			new del_v_v(iSetRFCharReportConfig).BeginInvoke(null, null);
		}

		private void m_btnRFCharReportCfg_Click(object sender, EventArgs p1)
		{
			iSetRFCharReportConfigAsync();
		}

		public bool UpdateRFCalibMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRFCalibMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				if (m_chbCalibrationIndex.Checked && m_chbMonitorinIndex.Checked)
				{
					MessageBox.Show("Both calibration and monitoring Index Enabled! select either one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					result = false;
				}
				else
				{
					if (!m_chbCalibrationIndex.Checked)
					{
						if (!m_chbMonitorinIndex.Checked)
						{
							MessageBox.Show("Both calibration and monitoring Index disabled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return false;
						}
						m_RFCalibMonConfigParams.CalibMonId = (uint)m_nudRFMonitoringId.Value;
					}
					else
					{
						m_chbMonitorinIndex.Enabled = false;
						m_RFCalibMonConfigParams.CalibMonId = (uint)m_nudRFCalibrationId.Value;
					}
					result = true;
				}
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRFCalibMonConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRFCalibMonConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				if (m_RFCalibMonConfigParams.CalibMonId < 256U)
				{
					if (m_RFCalibMonConfigParams.CalibMonId > 255U || m_RFCalibMonConfigParams.CalibMonId < 0U)
					{
						MessageBox.Show("Both calibration and monitoring index values are out of Range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return false;
					}
					m_nudRFMonitoringId.Value = m_RFCalibMonConfigParams.CalibMonId;
					m_chbMonitorinIndex.Checked = true;
				}
				else
				{
					m_nudRFCalibrationId.Value = m_RFCalibMonConfigParams.CalibMonId;
					m_chbCalibrationIndex.Checked = true;
				}
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public int UpdateAndSetRFCalibMonConfigDataFrmCmd(uint MonCalVal)
		{
			if (base.InvokeRequired)
			{
				del_i_u method = new del_i_u(UpdateAndSetRFCalibMonConfigDataFrmCmd);
				return (int)base.Invoke(method, new object[]
				{
					MonCalVal
				});
			}
			int num = -1;
			int result;
			try
			{
				if (MonCalVal < 256U)
				{
					if (MonCalVal > 255U || MonCalVal < 0U)
					{
						MessageBox.Show("Both calibration and monitoring index values are out of Range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return num;
					}
					m_chbMonitorinIndex.Checked = true;
					m_chbCalibrationIndex.Checked = false;
				}
				else
				{
					m_chbCalibrationIndex.Checked = true;
					m_chbMonitorinIndex.Checked = false;
				}
				result = 0;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = num;
			}
			return result;
		}

		private int iSetRFCalibMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetRFCalibMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFCalibMonConfig()
		{
			iSetRFCalibMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iSetRFCalibMonConfigAsync()
		{
			new del_v_v(iSetRFCalibMonConfig).BeginInvoke(null, null);
		}

		private void m_btnRFCalibMonCfg_Click(object sender, EventArgs p1)
		{
			iSetRFCalibMonConfigAsync();
		}

		public bool UpdateRFCalibEnaDisConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRFCalibEnaDisConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_RFCalibEnaDisConfigParams.f0004f5 = (f000218.Checked ? 1U : 0U);
				m_RFCalibEnaDisConfigParams.APLLCalDisable = (f000219.Checked ? 1U : 0U);
				m_RFCalibEnaDisConfigParams.Synth1CalDisable = (m_Synth1Cal.Checked ? 1U : 0U);
				m_RFCalibEnaDisConfigParams.Synth2CalDisable = (m_Synth2Cal.Checked ? 1U : 0U);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRFCalibEnaDisConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateRFCalibEnaDisConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				f000218.Checked = (m_RFCalibEnaDisConfigParams.f0004f5 == 1U);
				f000219.Checked = (m_RFCalibEnaDisConfigParams.APLLCalDisable == 1U);
				m_Synth1Cal.Checked = (m_RFCalibEnaDisConfigParams.Synth1CalDisable == 1U);
				m_Synth2Cal.Checked = (m_RFCalibEnaDisConfigParams.Synth2CalDisable == 1U);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetRFClibDisableConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetRFClibDisableConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFClibDisableConfig()
		{
			iSetRFClibDisableConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iSetRFClibDisableConfigAsync()
		{
			new del_v_v(iSetRFClibDisableConfig).BeginInvoke(null, null);
		}

		private void m_btnRFClibDisableCfg_Click(object sender, EventArgs p1)
		{
			iSetRFClibDisableConfigAsync();
		}

		public void SetStaticDataprocessTypeinGUI(string processType)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetStaticDataprocessTypeinGUI);
				base.Invoke(method, new object[]
				{
					processType
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_lblProcessId.Text = processType;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_lblRadarDevice2ProcessId.Text = processType;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				m_lblRadarDevice3ProcessId.Text = processType;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				m_lblRadarDevice4ProcessId.Text = processType;
			}
		}

		public void SetTStaticDataRefClkFreqinGUI(string RefClkFreq)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetTStaticDataRefClkFreqinGUI);
				base.Invoke(method, new object[]
				{
					RefClkFreq
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_lblRefClkFreq.Text = RefClkFreq;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_lblRadarDevice2RefClkFreq.Text = RefClkFreq;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				m_lblRadarDevice3RefClkFreq.Text = RefClkFreq;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				m_lblRadarDevice4RefClkFreq.Text = RefClkFreq;
			}
		}

		public void SetStaticDataapllCalStatusinGUI(string apllCalStatus)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetStaticDataapllCalStatusinGUI);
				base.Invoke(method, new object[]
				{
					apllCalStatus
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_lblApllcalStatus.Text = apllCalStatus;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_lblRadarDevice2ApllcalStatus.Text = apllCalStatus;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				m_lblRadarDevice3ApllcalStatus.Text = apllCalStatus;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				m_lblRadarDevice4ApllcalStatus.Text = apllCalStatus;
			}
		}

		public void SetStaticDataapllClkFreqinGUI(string apllClkFreq)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetStaticDataapllClkFreqinGUI);
				base.Invoke(method, new object[]
				{
					apllClkFreq
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_lblClosedLoopFreq.Text = apllClkFreq;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_lblRadarDevice2ClosedLoopFreq.Text = apllClkFreq;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				m_lblRadarDevice3ClosedLoopFreq.Text = apllClkFreq;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				m_lblRadarDevice4ClosedLoopFreq.Text = apllClkFreq;
			}
		}

		public void clrBootUpDataVersion()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrBootUpDataVersion);
				base.Invoke(method);
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_lblProcessId.Text = "0.0";
				m_lblRefClkFreq.Text = "0.0";
				m_lblApllcalStatus.Text = "FAILURE";
				m_lblClosedLoopFreq.Text = "0.0";
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_lblRadarDevice2ProcessId.Text = "0.0";
				m_lblRadarDevice2RefClkFreq.Text = "0.0";
				m_lblRadarDevice2ApllcalStatus.Text = "FAILURE";
				m_lblRadarDevice2ClosedLoopFreq.Text = "0.0";
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				m_lblRadarDevice3ProcessId.Text = "0.0";
				m_lblRadarDevice3RefClkFreq.Text = "0.0";
				m_lblRadarDevice3ApllcalStatus.Text = "FAILURE";
				m_lblRadarDevice3ClosedLoopFreq.Text = "0.0";
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				m_lblRadarDevice4ProcessId.Text = "0.0";
				m_lblRadarDevice4RefClkFreq.Text = "0.0";
				m_lblRadarDevice4ApllcalStatus.Text = "FAILURE";
				m_lblRadarDevice4ClosedLoopFreq.Text = "0.0";
			}
		}

		public void EnableDisbleBSSBootUpDataWithRespectiveRadarDevices(ushort numberOfRadarDevicesDetected)
		{
			if (numberOfRadarDevicesDetected == 1)
			{
				m_lblProcessId.Visible = true;
				m_lblRefClkFreq.Visible = true;
				m_lblApllcalStatus.Visible = true;
				m_lblClosedLoopFreq.Visible = true;
				m_lblRadarDevice2ProcessId.Visible = false;
				m_lblRadarDevice2RefClkFreq.Visible = false;
				m_lblRadarDevice2ApllcalStatus.Visible = false;
				m_lblRadarDevice2ClosedLoopFreq.Visible = false;
				m_lblRadarDevice3ProcessId.Visible = false;
				m_lblRadarDevice3RefClkFreq.Visible = false;
				m_lblRadarDevice3ApllcalStatus.Visible = false;
				m_lblRadarDevice3ClosedLoopFreq.Visible = false;
				m_lblRadarDevice4ProcessId.Visible = false;
				m_lblRadarDevice4RefClkFreq.Visible = false;
				m_lblRadarDevice4ApllcalStatus.Visible = false;
				m_lblRadarDevice4ClosedLoopFreq.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 2)
			{
				m_lblProcessId.Visible = true;
				m_lblRefClkFreq.Visible = true;
				m_lblApllcalStatus.Visible = true;
				m_lblClosedLoopFreq.Visible = true;
				m_lblRadarDevice2ProcessId.Visible = true;
				m_lblRadarDevice2RefClkFreq.Visible = true;
				m_lblRadarDevice2ApllcalStatus.Visible = true;
				m_lblRadarDevice2ClosedLoopFreq.Visible = true;
				m_lblRadarDevice3ProcessId.Visible = false;
				m_lblRadarDevice3RefClkFreq.Visible = false;
				m_lblRadarDevice3ApllcalStatus.Visible = false;
				m_lblRadarDevice3ClosedLoopFreq.Visible = false;
				m_lblRadarDevice4ProcessId.Visible = false;
				m_lblRadarDevice4RefClkFreq.Visible = false;
				m_lblRadarDevice4ApllcalStatus.Visible = false;
				m_lblRadarDevice4ClosedLoopFreq.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 4)
			{
				m_lblProcessId.Visible = true;
				m_lblRefClkFreq.Visible = true;
				m_lblApllcalStatus.Visible = true;
				m_lblClosedLoopFreq.Visible = true;
				m_lblRadarDevice2ProcessId.Visible = true;
				m_lblRadarDevice2RefClkFreq.Visible = true;
				m_lblRadarDevice2ApllcalStatus.Visible = true;
				m_lblRadarDevice2ClosedLoopFreq.Visible = true;
				m_lblRadarDevice3ProcessId.Visible = true;
				m_lblRadarDevice3RefClkFreq.Visible = true;
				m_lblRadarDevice3ApllcalStatus.Visible = true;
				m_lblRadarDevice3ClosedLoopFreq.Visible = true;
				m_lblRadarDevice4ProcessId.Visible = true;
				m_lblRadarDevice4RefClkFreq.Visible = true;
				m_lblRadarDevice4ApllcalStatus.Visible = true;
				m_lblRadarDevice4ClosedLoopFreq.Visible = true;
				return;
			}
			m_lblProcessId.Visible = false;
			m_lblRefClkFreq.Visible = false;
			m_lblApllcalStatus.Visible = false;
			m_lblClosedLoopFreq.Visible = false;
			m_lblRadarDevice2ProcessId.Visible = false;
			m_lblRadarDevice2RefClkFreq.Visible = false;
			m_lblRadarDevice2ApllcalStatus.Visible = false;
			m_lblRadarDevice2ClosedLoopFreq.Visible = false;
			m_lblRadarDevice3ProcessId.Visible = false;
			m_lblRadarDevice3RefClkFreq.Visible = false;
			m_lblRadarDevice3ApllcalStatus.Visible = false;
			m_lblRadarDevice3ClosedLoopFreq.Visible = false;
			m_lblRadarDevice4ProcessId.Visible = false;
			m_lblRadarDevice4RefClkFreq.Visible = false;
			m_lblRadarDevice4ApllcalStatus.Visible = false;
			m_lblRadarDevice4ClosedLoopFreq.Visible = false;
		}

		public void EnableDisbleGPADCDataWithRespectiveRadarDevices(ushort numberOfRadarDevicesDetected)
		{
			if (numberOfRadarDevicesDetected == 1)
			{
				f000217.Visible = true;
				f000216.Visible = true;
				f000215.Visible = true;
				f00021a.Visible = false;
				f000222.Visible = false;
				f000221.Visible = false;
				f000220.Visible = false;
				f00021f.Visible = false;
				f00021e.Visible = false;
				f00021d.Visible = false;
				f00021c.Visible = false;
				f00021b.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 2)
			{
				f000217.Visible = true;
				f000216.Visible = true;
				f000215.Visible = true;
				f00021a.Visible = true;
				f000222.Visible = true;
				f000221.Visible = true;
				f000220.Visible = false;
				f00021f.Visible = false;
				f00021e.Visible = false;
				f00021d.Visible = false;
				f00021c.Visible = false;
				f00021b.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 4)
			{
				f000217.Visible = true;
				f000216.Visible = true;
				f000215.Visible = true;
				f00021a.Visible = true;
				f000222.Visible = true;
				f000221.Visible = true;
				f000220.Visible = true;
				f00021f.Visible = true;
				f00021e.Visible = true;
				f00021d.Visible = true;
				f00021c.Visible = true;
				f00021b.Visible = true;
				return;
			}
			f000217.Visible = false;
			f000216.Visible = false;
			f000215.Visible = false;
			f00021a.Visible = false;
			f000222.Visible = false;
			f000221.Visible = false;
			f000220.Visible = false;
			f00021f.Visible = false;
			f00021e.Visible = false;
			f00021d.Visible = false;
			f00021c.Visible = false;
			f00021b.Visible = false;
		}

		public void m000064()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(m000064);
				base.Invoke(method);
				return;
			}
			m_nudGPADConfigVal.Value = 0m;
			m_nudGPADCParamVal.Value = 0m;
			m_nudGPADCNumOfSamples.Value = 4m;
			m_nudSkipClockMant.Value = 0m;
			m_nudSkipClockExp.Value = 0m;
		}

		public void m000065()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(m000065);
				base.Invoke(method);
				return;
			}
			f000217.Text = "0.0";
			f000216.Text = "0.0";
			f000215.Text = "0.0";
		}

		public void clrCharReportConfigData()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrCharReportConfigData);
				base.Invoke(method);
				return;
			}
			m_nudAeReportPeriod.Value = 0m;
		}

		public void EnableDisbleRFTempertureReportWithRespectiveRadarDevices(ushort numberOfRadarDevicesDetected)
		{
			if (numberOfRadarDevicesDetected == 1)
			{
				m_lblTime.Visible = true;
				m_lblRx0TSValue.Visible = true;
				m_lblRx1TSValue.Visible = true;
				m_lblRx2TSValue.Visible = true;
				m_lblRx3TSValue.Visible = true;
				m_lblTx0TSValue.Visible = true;
				m_lblTx1TSValue.Visible = true;
				m_lblTx2TSValue.Visible = true;
				f00017e.Visible = true;
				m_lblDigTSValue.Visible = true;
				f00018d.Visible = true;
				m_lblRadarDevice2Time.Visible = false;
				m_lblRadarDevice2Rx0TSValue.Visible = false;
				m_lblRadarDevice2Rx1TSValue.Visible = false;
				m_lblRadarDevice2Rx2TSValue.Visible = false;
				m_lblRadarDevice2Rx3TSValue.Visible = false;
				m_lblRadarDevice2Tx0TSValue.Visible = false;
				m_lblRadarDevice2Tx1TSValue.Visible = false;
				m_lblRadarDevice2Tx2TSValue.Visible = false;
				f000184.Visible = false;
				m_lblRadarDevice2DigTSValue.Visible = false;
				f00018c.Visible = false;
				m_lblRadarDevice3Time.Visible = false;
				m_lblRadarDevice3Rx0TSValue.Visible = false;
				m_lblRadarDevice3Rx1TSValue.Visible = false;
				m_lblRadarDevice3Rx2TSValue.Visible = false;
				m_lblRadarDevice3Rx3TSValue.Visible = false;
				m_lblRadarDevice3Tx0TSValue.Visible = false;
				m_lblRadarDevice3Tx1TSValue.Visible = false;
				m_lblRadarDevice3Tx2TSValue.Visible = false;
				f000180.Visible = false;
				m_lblRadarDevice3DigTSValue.Visible = false;
				f00018b.Visible = false;
				m_lblRadarDevice4Time.Visible = false;
				m_lblRadarDevice4Rx0TSValue.Visible = false;
				m_lblRadarDevice4Rx1TSValue.Visible = false;
				m_lblRadarDevice4Rx2TSValue.Visible = false;
				m_lblRadarDevice4Rx3TSValue.Visible = false;
				m_lblRadarDevice4Tx0TSValue.Visible = false;
				m_lblRadarDevice4Tx1TSValue.Visible = false;
				m_lblRadarDevice4Tx2TSValue.Visible = false;
				f000182.Visible = false;
				m_lblRadarDevice4DigTSValue.Visible = false;
				f00018a.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 2)
			{
				m_lblTime.Visible = true;
				m_lblRx0TSValue.Visible = true;
				m_lblRx1TSValue.Visible = true;
				m_lblRx2TSValue.Visible = true;
				m_lblRx3TSValue.Visible = true;
				m_lblTx0TSValue.Visible = true;
				m_lblTx1TSValue.Visible = true;
				m_lblTx2TSValue.Visible = true;
				f00017e.Visible = true;
				m_lblDigTSValue.Visible = true;
				f00018d.Visible = true;
				m_lblRadarDevice2Time.Visible = true;
				m_lblRadarDevice2Rx0TSValue.Visible = true;
				m_lblRadarDevice2Rx1TSValue.Visible = true;
				m_lblRadarDevice2Rx2TSValue.Visible = true;
				m_lblRadarDevice2Rx3TSValue.Visible = true;
				m_lblRadarDevice2Tx0TSValue.Visible = true;
				m_lblRadarDevice2Tx1TSValue.Visible = true;
				m_lblRadarDevice2Tx2TSValue.Visible = true;
				f000184.Visible = true;
				m_lblRadarDevice2DigTSValue.Visible = true;
				f00018c.Visible = true;
				m_lblRadarDevice3Time.Visible = false;
				m_lblRadarDevice3Rx0TSValue.Visible = false;
				m_lblRadarDevice3Rx1TSValue.Visible = false;
				m_lblRadarDevice3Rx2TSValue.Visible = false;
				m_lblRadarDevice3Rx3TSValue.Visible = false;
				m_lblRadarDevice3Tx0TSValue.Visible = false;
				m_lblRadarDevice3Tx1TSValue.Visible = false;
				m_lblRadarDevice3Tx2TSValue.Visible = false;
				f000180.Visible = false;
				m_lblRadarDevice3DigTSValue.Visible = false;
				f00018b.Visible = false;
				m_lblRadarDevice4Time.Visible = false;
				m_lblRadarDevice4Rx0TSValue.Visible = false;
				m_lblRadarDevice4Rx1TSValue.Visible = false;
				m_lblRadarDevice4Rx2TSValue.Visible = false;
				m_lblRadarDevice4Rx3TSValue.Visible = false;
				m_lblRadarDevice4Tx0TSValue.Visible = false;
				m_lblRadarDevice4Tx1TSValue.Visible = false;
				m_lblRadarDevice4Tx2TSValue.Visible = false;
				f000182.Visible = false;
				m_lblRadarDevice4DigTSValue.Visible = false;
				f00018a.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 4)
			{
				m_lblTime.Visible = true;
				m_lblRx0TSValue.Visible = true;
				m_lblRx1TSValue.Visible = true;
				m_lblRx2TSValue.Visible = true;
				m_lblRx3TSValue.Visible = true;
				m_lblTx0TSValue.Visible = true;
				m_lblTx1TSValue.Visible = true;
				m_lblTx2TSValue.Visible = true;
				f00017e.Visible = true;
				m_lblDigTSValue.Visible = true;
				f00018d.Visible = true;
				m_lblRadarDevice2Time.Visible = true;
				m_lblRadarDevice2Rx0TSValue.Visible = true;
				m_lblRadarDevice2Rx1TSValue.Visible = true;
				m_lblRadarDevice2Rx2TSValue.Visible = true;
				m_lblRadarDevice2Rx3TSValue.Visible = true;
				m_lblRadarDevice2Tx0TSValue.Visible = true;
				m_lblRadarDevice2Tx1TSValue.Visible = true;
				m_lblRadarDevice2Tx2TSValue.Visible = true;
				f000184.Visible = true;
				m_lblRadarDevice2DigTSValue.Visible = true;
				f00018c.Visible = true;
				m_lblRadarDevice3Time.Visible = true;
				m_lblRadarDevice3Rx0TSValue.Visible = true;
				m_lblRadarDevice3Rx1TSValue.Visible = true;
				m_lblRadarDevice3Rx2TSValue.Visible = true;
				m_lblRadarDevice3Rx3TSValue.Visible = true;
				m_lblRadarDevice3Tx0TSValue.Visible = true;
				m_lblRadarDevice3Tx1TSValue.Visible = true;
				m_lblRadarDevice3Tx2TSValue.Visible = true;
				f000180.Visible = true;
				m_lblRadarDevice3DigTSValue.Visible = true;
				f00018b.Visible = true;
				m_lblRadarDevice4Time.Visible = true;
				m_lblRadarDevice4Rx0TSValue.Visible = true;
				m_lblRadarDevice4Rx1TSValue.Visible = true;
				m_lblRadarDevice4Rx2TSValue.Visible = true;
				m_lblRadarDevice4Rx3TSValue.Visible = true;
				m_lblRadarDevice4Tx0TSValue.Visible = true;
				m_lblRadarDevice4Tx1TSValue.Visible = true;
				m_lblRadarDevice4Tx2TSValue.Visible = true;
				f000182.Visible = true;
				m_lblRadarDevice4DigTSValue.Visible = true;
				f00018a.Visible = true;
				return;
			}
			m_lblTime.Visible = false;
			m_lblRx0TSValue.Visible = false;
			m_lblRx1TSValue.Visible = false;
			m_lblRx2TSValue.Visible = false;
			m_lblRx3TSValue.Visible = false;
			m_lblTx0TSValue.Visible = false;
			m_lblTx1TSValue.Visible = false;
			m_lblTx2TSValue.Visible = false;
			f00017e.Visible = false;
			m_lblDigTSValue.Visible = false;
			f00018d.Visible = false;
			m_lblRadarDevice2Time.Visible = false;
			m_lblRadarDevice2Rx0TSValue.Visible = false;
			m_lblRadarDevice2Rx1TSValue.Visible = false;
			m_lblRadarDevice2Rx2TSValue.Visible = false;
			m_lblRadarDevice2Rx3TSValue.Visible = false;
			m_lblRadarDevice2Tx0TSValue.Visible = false;
			m_lblRadarDevice2Tx1TSValue.Visible = false;
			m_lblRadarDevice2Tx2TSValue.Visible = false;
			f000184.Visible = false;
			m_lblRadarDevice2DigTSValue.Visible = false;
			m_lblRadarDevice3Time.Visible = false;
			m_lblRadarDevice3Rx0TSValue.Visible = false;
			m_lblRadarDevice3Rx1TSValue.Visible = false;
			m_lblRadarDevice3Rx2TSValue.Visible = false;
			m_lblRadarDevice3Rx3TSValue.Visible = false;
			m_lblRadarDevice3Tx0TSValue.Visible = false;
			m_lblRadarDevice3Tx1TSValue.Visible = false;
			m_lblRadarDevice3Tx2TSValue.Visible = false;
			f000180.Visible = false;
			m_lblRadarDevice3DigTSValue.Visible = false;
			f00018b.Visible = false;
			m_lblRadarDevice4Time.Visible = false;
			m_lblRadarDevice4Rx0TSValue.Visible = false;
			m_lblRadarDevice4Rx1TSValue.Visible = false;
			m_lblRadarDevice4Rx2TSValue.Visible = false;
			m_lblRadarDevice4Rx3TSValue.Visible = false;
			m_lblRadarDevice4Tx0TSValue.Visible = false;
			m_lblRadarDevice4Tx1TSValue.Visible = false;
			m_lblRadarDevice4Tx2TSValue.Visible = false;
			f000182.Visible = false;
			m_lblRadarDevice4DigTSValue.Visible = false;
			f00018a.Visible = false;
		}

		public void clrCharReportData()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrCharReportData);
				base.Invoke(method);
				return;
			}
			m_lblTime.Text = "0";
			m_lblRx0TSValue.Text = "0.0";
			m_lblRx1TSValue.Text = "0.0";
			m_lblRx2TSValue.Text = "0.0";
			m_lblRx3TSValue.Text = "0.0";
			m_lblTx0TSValue.Text = "0.0";
			m_lblTx1TSValue.Text = "0.0";
			m_lblTx2TSValue.Text = "0.0";
			f00017e.Text = "0.0";
			m_lblDigTSValue.Text = "0.0";
			f00018d.Text = "0.0";
		}

		public void clrCalibDisConfigData()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrCalibDisConfigData);
				base.Invoke(method);
			}
		}

		public void clrCalibMonData()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrCalibMonData);
				base.Invoke(method);
				return;
			}
			m_chbCalibrationIndex.Checked = false;
			m_chbMonitorinIndex.Checked = false;
			m_nudRFCalibrationId.Value = 257m;
			m_nudRFMonitoringId.Value = 0m;
		}

		public bool UpdateTempertureSensorTempConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTempertureSensorTempConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_TemperatrueSensorTempDataConfigParams.TrimTemp1 = (short)m_nudTrimTemp1.Value;
				m_TemperatrueSensorTempDataConfigParams.TrimTemp2 = (short)m_nudTrimTemp2.Value;
				m_TemperatrueSensorTempDataConfigParams.TrimCodeRx1 = (ushort)m_nudTrimRx1.Value;
				m_TemperatrueSensorTempDataConfigParams.TrimCodeTx1 = (ushort)m_nudTrimTx1.Value;
				m_TemperatrueSensorTempDataConfigParams.TrimCodeDig1 = (ushort)m_nudTrimDig1.Value;
				m_TemperatrueSensorTempDataConfigParams.TrimCodePm1 = (ushort)m_nudTrimPm1.Value;
				m_TemperatrueSensorTempDataConfigParams.TrimCodeRx2 = (ushort)m_nudTrimRx2.Value;
				m_TemperatrueSensorTempDataConfigParams.TrimCodeTx2 = (ushort)m_nudTrimTx2.Value;
				m_TemperatrueSensorTempDataConfigParams.TrimCodeDig2 = (ushort)m_nudTrimDig2.Value;
				m_TemperatrueSensorTempDataConfigParams.TrimCodePm2 = (ushort)m_nudTrimPm2.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateTempertureSensorTempConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTempertureSensorTempConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudTrimTemp1.Value = m_TemperatrueSensorTempDataConfigParams.TrimTemp1;
				m_nudTrimTemp2.Value = m_TemperatrueSensorTempDataConfigParams.TrimTemp2;
				m_nudTrimRx1.Value = m_TemperatrueSensorTempDataConfigParams.TrimCodeRx1;
				m_nudTrimTx1.Value = m_TemperatrueSensorTempDataConfigParams.TrimCodeTx1;
				m_nudTrimDig1.Value = m_TemperatrueSensorTempDataConfigParams.TrimCodeDig1;
				m_nudTrimPm1.Value = m_TemperatrueSensorTempDataConfigParams.TrimCodePm1;
				m_nudTrimRx2.Value = m_TemperatrueSensorTempDataConfigParams.TrimCodeRx2;
				m_nudTrimTx2.Value = m_TemperatrueSensorTempDataConfigParams.TrimCodeTx2;
				m_nudTrimDig2.Value = m_TemperatrueSensorTempDataConfigParams.TrimCodeDig2;
				m_nudTrimPm2.Value = m_TemperatrueSensorTempDataConfigParams.TrimCodePm2;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetRFTemperatureSensorDataConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetTempertureSensorTempDataConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFTemperatureSensorDataConfig()
		{
			iSetRFTemperatureSensorDataConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iSetRFTemperatureSensorDataConfigAsync()
		{
			new del_v_v(iSetRFTemperatureSensorDataConfig).BeginInvoke(null, null);
		}

		private void m_btnRFCTempSensorCfg_Click(object sender, EventArgs p1)
		{
			iSetRFTemperatureSensorDataConfigAsync();
		}

		private void PDPowerCfg_SelectedIndexChanged(object sender, EventArgs p1)
		{
			string a = m_CbPDInstance.SelectedIndex.ToString();
			object[] items2;
			if (a == "0")
			{
				f000225.Items.Clear();
				ComboBox.ObjectCollection items = f000225.Items;
				items2 = comboBoxRangeA;
				items.AddRange(items2);
				f000225.SelectedIndex = 0;
				return;
			}
			if (!(a == "1"))
			{
				return;
			}
			f000225.Items.Clear();
			ComboBox.ObjectCollection items3 = f000225.Items;
			items2 = comboBoxRangeB;
			items3.AddRange(items2);
			f000225.SelectedIndex = 0;
		}

		private int m000066(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.m0000a7(is_starting_op, is_ending_op);
		}

		private void m000067()
		{
			m000066(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void m000068()
		{
			new del_v_v(m000067).BeginInvoke(null, null);
		}

		private void m_btnPDTrim1GHzSet_Click(object sender, EventArgs p1)
		{
			m000068();
		}

		public bool UpdatePDTrimGHZConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdatePDTrimGHZConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				f000210.PDInstance = (char)m_CbPDInstance.SelectedIndex;
				f000210.RFINPowerIndex = (char)f000225.SelectedIndex;
				f000210.RFINPowerOn = (char)f000224.SelectedIndex;
				f000210.Mode = (char)m_CbPDTrimMode.SelectedIndex;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool m000069()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(m000069);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_CbPDInstance.SelectedIndex = (int)f000210.PDInstance;
				f000225.SelectedIndex = (int)f000210.RFINPowerIndex;
				f000224.SelectedIndex = (int)f000210.RFINPowerOn;
				m_CbPDTrimMode.SelectedIndex = (int)f000210.Mode;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iMeasurePDPowerConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iMeasurePDPowerConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iMeasurePDPowerConfig()
		{
			iMeasurePDPowerConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iMeasurePDPowerConfigAsync()
		{
			new del_v_v(iMeasurePDPowerConfig).BeginInvoke(null, null);
		}

		private void m_btnMeasurePDPowerSet_Click(object sender, EventArgs p1)
		{
			iMeasurePDPowerConfigAsync();
		}

		public bool UpdateMeasurePDPowerConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateMeasurePDPowerConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MeasurePDPowerConfigParams.PDId = (char)m_nudPDIndex.Value;
				m_MeasurePDPowerConfigParams.PDLnaGainIndex = (char)m_nudPDLNAGainIndex.Value;
				m_MeasurePDPowerConfigParams.NumOfAccumulations = (char)m_nudNumOfAccumulations.Value;
				m_MeasurePDPowerConfigParams.NumOfSamples = (char)m_nudPDINumOfSamples.Value;
				m_MeasurePDPowerConfigParams.PDType = (byte)m_CbPDType.SelectedIndex;
				m_MeasurePDPowerConfigParams.pdSel = (byte)m_nudPDSelect.Value;
				m_MeasurePDPowerConfigParams.pdDacVal = (byte)m_nudPDDACVal.Value;
				m_MeasurePDPowerConfigParams.paramVal = (byte)m_nudPDParamVal.Value;
				m_MeasurePDPowerConfigParams.Reserved = 0U;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMeasurePDPowerConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateMeasurePDPowerConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudPDIndex.Value = m_MeasurePDPowerConfigParams.PDId;
				m_nudPDLNAGainIndex.Value = m_MeasurePDPowerConfigParams.PDLnaGainIndex;
				m_nudNumOfAccumulations.Value = m_MeasurePDPowerConfigParams.NumOfAccumulations;
				m_nudPDINumOfSamples.Value = m_MeasurePDPowerConfigParams.NumOfSamples;
				m_CbPDType.SelectedIndex = (int)m_MeasurePDPowerConfigParams.PDType;
				m_nudPDSelect.Value = m_MeasurePDPowerConfigParams.pdSel;
				m_nudPDDACVal.Value = m_MeasurePDPowerConfigParams.pdDacVal;
				m_nudPDParamVal.Value = m_MeasurePDPowerConfigParams.paramVal;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool MeasurePDPowerAsyncDataReport(uint RadarDeviceId, uint SumOn, uint SumOff, ushort DeltaSum, ushort p4, ushort PDPower, byte PDMeasureStatus)
		{
			if (base.InvokeRequired)
			{
				del_b_u_u_u_us_us_us_b method = new del_b_u_u_u_us_us_us_b(MeasurePDPowerAsyncDataReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					SumOn,
					SumOff,
					DeltaSum,
					p4,
					PDPower,
					PDMeasureStatus
				});
			}
			else if (RadarDeviceId == 1U)
			{
				if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0001')
				{
					double num = 0.01733;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0002')
				{
					double num = 0.010934;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0003')
				{
					double num = 0.006899;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0004')
				{
					double num = 0.004353;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0005')
				{
					double num = 0.002747;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0006')
				{
					double num = 0.001733;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\a')
				{
					double num = 0.001093;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\b')
				{
					double num = 0.00069;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\t')
				{
					double num = 0.000435;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				f000226.Text = Convert.ToString((int)(p4 / 32));
				if (PDPower > 32767)
				{
					short num2 = (short)((int)PDPower - 65536);
					m_lblPDPower.Text = Convert.ToString((double)num2 / 10.0);
				}
				else
				{
					m_lblPDPower.Text = Convert.ToString((double)PDPower / 10.0);
				}
				if (PDMeasureStatus == 1)
				{
					m_lblPDPowerStatus.Text = "PASS";
				}
				else
				{
					m_lblPDPowerStatus.Text = "FAIL";
				}
				m_lblRFSumOn.Text = Convert.ToString(SumOn);
				m_lblRFSumOff.Text = Convert.ToString(SumOff);
			}
			return true;
		}

		public bool CascadeMeasurePDPowerAsyncDataReport(uint RadarDeviceId, uint SumOn, uint SumOff, ushort DeltaSum, ushort p4, ushort PDPower, byte PDMeasureStatus)
		{
			if (base.InvokeRequired)
			{
				del_b_u_u_u_us_us_us_b method = new del_b_u_u_u_us_us_us_b(CascadeMeasurePDPowerAsyncDataReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					SumOn,
					SumOff,
					DeltaSum,
					p4,
					PDPower,
					PDMeasureStatus
				});
			}
			else if (RadarDeviceId == 0U)
			{
				if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0001')
				{
					double num = 0.01733;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0002')
				{
					double num = 0.010934;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0003')
				{
					double num = 0.006899;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0004')
				{
					double num = 0.004353;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0005')
				{
					double num = 0.002747;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\u0006')
				{
					double num = 0.001733;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\a')
				{
					double num = 0.001093;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\b')
				{
					double num = 0.00069;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				else if (m_MeasurePDPowerConfigParams.PDLnaGainIndex == '\t')
				{
					double num = 0.000435;
					m_lblDeltaSum.Text = Convert.ToString(Math.Round((double)DeltaSum * num, 2));
				}
				f000226.Text = Convert.ToString((int)(p4 / 32));
				if (PDPower > 32767)
				{
					short num2 = (short)((int)PDPower - 65536);
					m_lblPDPower.Text = Convert.ToString((double)num2 / 10.0);
				}
				else
				{
					m_lblPDPower.Text = Convert.ToString((double)PDPower / 10.0);
				}
				if (PDMeasureStatus == 1)
				{
					m_lblPDPowerStatus.Text = "PASS";
				}
				else
				{
					m_lblPDPowerStatus.Text = "FAIL";
				}
				m_lblRFSumOn.Text = Convert.ToString(SumOn);
				m_lblRFSumOff.Text = Convert.ToString(SumOff);
			}
			else if (RadarDeviceId == 1U)
			{
				m_lblRadarDevice2DeltaSum.Text = Convert.ToString(DeltaSum);
				f000227.Text = Convert.ToString((int)(p4 / 32));
				m_lblRadarDevice2PDPower.Text = Convert.ToString((double)PDPower / 10.0);
				if (PDMeasureStatus == 1)
				{
					m_lblRadarDevice2PDPowerStatus.Text = "PASS";
				}
				else
				{
					m_lblRadarDevice2PDPowerStatus.Text = "FAIL";
				}
			}
			else if (RadarDeviceId == 2U)
			{
				m_lblRadarDevice3DeltaSum.Text = Convert.ToString(DeltaSum);
				f000228.Text = Convert.ToString((int)(p4 / 32));
				m_lblRadarDevice3PDPower.Text = Convert.ToString((double)PDPower / 10.0);
				if (PDMeasureStatus == 1)
				{
					m_lblRadarDevice3PDPowerStatus.Text = "PASS";
				}
				else
				{
					m_lblRadarDevice3PDPowerStatus.Text = "FAIL";
				}
			}
			else if (RadarDeviceId == 3U)
			{
				m_lblRadarDevice4DeltaSum.Text = Convert.ToString(DeltaSum);
				f000229.Text = Convert.ToString((int)(p4 / 32));
				m_lblRadarDevice4PDPower.Text = Convert.ToString((double)PDPower / 10.0);
				if (PDMeasureStatus == 1)
				{
					m_lblRadarDevice4PDPowerStatus.Text = "PASS";
				}
				else
				{
					m_lblRadarDevice4PDPowerStatus.Text = "FAIL";
				}
			}
			return true;
		}

		public void EnableDisbleMeasurePDPowerStatusWithRespectiveRadarDevices(ushort numberOfRadarDevicesDetected)
		{
			if (numberOfRadarDevicesDetected == 1)
			{
				m_lblDeltaSum.Visible = true;
				f000226.Visible = true;
				m_lblPDPower.Visible = true;
				m_lblPDPowerStatus.Visible = true;
				m_lblRadarDevice2DeltaSum.Visible = false;
				f000227.Visible = false;
				m_lblRadarDevice2PDPower.Visible = false;
				m_lblRadarDevice2PDPowerStatus.Visible = false;
				m_lblRadarDevice3DeltaSum.Visible = false;
				f000228.Visible = false;
				m_lblRadarDevice3PDPower.Visible = false;
				m_lblRadarDevice3PDPowerStatus.Visible = false;
				m_lblRadarDevice4DeltaSum.Visible = false;
				f000229.Visible = false;
				m_lblRadarDevice4PDPower.Visible = false;
				m_lblRadarDevice4PDPowerStatus.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 2)
			{
				m_lblDeltaSum.Visible = true;
				f000226.Visible = true;
				m_lblPDPower.Visible = true;
				m_lblPDPowerStatus.Visible = true;
				m_lblRadarDevice2DeltaSum.Visible = true;
				f000227.Visible = true;
				m_lblRadarDevice2PDPower.Visible = true;
				m_lblRadarDevice2PDPowerStatus.Visible = true;
				m_lblRadarDevice3DeltaSum.Visible = false;
				f000228.Visible = false;
				m_lblRadarDevice3PDPower.Visible = false;
				m_lblRadarDevice3PDPowerStatus.Visible = false;
				m_lblRadarDevice4DeltaSum.Visible = false;
				f000229.Visible = false;
				m_lblRadarDevice4PDPower.Visible = false;
				m_lblRadarDevice4PDPowerStatus.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 4)
			{
				m_lblDeltaSum.Visible = true;
				f000226.Visible = true;
				m_lblPDPower.Visible = true;
				m_lblPDPowerStatus.Visible = true;
				m_lblRadarDevice2DeltaSum.Visible = true;
				f000227.Visible = true;
				m_lblRadarDevice2PDPower.Visible = true;
				m_lblRadarDevice2PDPowerStatus.Visible = true;
				m_lblRadarDevice3DeltaSum.Visible = true;
				f000228.Visible = true;
				m_lblRadarDevice3PDPower.Visible = true;
				m_lblRadarDevice3PDPowerStatus.Visible = true;
				m_lblRadarDevice4DeltaSum.Visible = true;
				f000229.Visible = true;
				m_lblRadarDevice4PDPower.Visible = true;
				m_lblRadarDevice4PDPowerStatus.Visible = true;
				return;
			}
			m_lblDeltaSum.Visible = false;
			f000226.Visible = false;
			m_lblPDPower.Visible = false;
			m_lblPDPowerStatus.Visible = false;
			m_lblRadarDevice2DeltaSum.Visible = false;
			f000227.Visible = false;
			m_lblRadarDevice2PDPower.Visible = false;
			m_lblRadarDevice2PDPowerStatus.Visible = false;
			m_lblRadarDevice3DeltaSum.Visible = false;
			f000228.Visible = false;
			m_lblRadarDevice3PDPower.Visible = false;
			m_lblRadarDevice3PDPowerStatus.Visible = false;
			m_lblRadarDevice4DeltaSum.Visible = false;
			f000229.Visible = false;
			m_lblRadarDevice4PDPower.Visible = false;
			m_lblRadarDevice4PDPowerStatus.Visible = false;
		}

		public void ResetMeasurePDPowerReportOfRadarDevice1Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(ResetMeasurePDPowerReportOfRadarDevice1Status);
				base.Invoke(method);
				return;
			}
			m_lblDeltaSum.Text = "0";
			f000226.Text = "0";
			m_lblPDPower.Text = "0";
			m_lblPDPowerStatus.Text = "FAIL";
		}

		public void ResetMeasurePDPowerReportOfRadarDevice2Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(ResetMeasurePDPowerReportOfRadarDevice2Status);
				base.Invoke(method);
				return;
			}
			m_lblRadarDevice2DeltaSum.Text = "0";
			f000227.Text = "0";
			m_lblRadarDevice2PDPower.Text = "0";
			m_lblRadarDevice2PDPowerStatus.Text = "FAIL";
		}

		public void ResetMeasurePDPowerReportOfRadarDevice3Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(ResetMeasurePDPowerReportOfRadarDevice3Status);
				base.Invoke(method);
				return;
			}
			m_lblRadarDevice3DeltaSum.Text = "0";
			f000228.Text = "0";
			m_lblRadarDevice3PDPower.Text = "0";
			m_lblRadarDevice3PDPowerStatus.Text = "FAIL";
		}

		public void ResetMeasurePDPowerReportOfRadarDevice4Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(ResetMeasurePDPowerReportOfRadarDevice4Status);
				base.Invoke(method);
				return;
			}
			m_lblRadarDevice4DeltaSum.Text = "0";
			f000229.Text = "0";
			m_lblRadarDevice4PDPower.Text = "0";
			m_lblRadarDevice4PDPowerStatus.Text = "FAIL";
		}

		private int iSynthFreqLinearityMonConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSynthFreqLinearityMonConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSynthFreqLinearityMonConfig()
		{
			iSynthFreqLinearityMonConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iSynthFreqLinearityMonConfigAsync()
		{
			new del_v_v(iSynthFreqLinearityMonConfig).BeginInvoke(null, null);
		}

		private void m_btnSynthFreqLinearityMonConfigSet_Click(object sender, EventArgs p1)
		{
			iSynthFreqLinearityMonConfigAsync();
		}

		public bool UpdateSynthFreqLinearityMonConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateSynthFreqLinearityMonConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_MonSynthFreqLinearityConfigParams.Profile0Index = (m_chkProfileIndex0.Checked ? '\u0001' : '\0');
				m_MonSynthFreqLinearityConfigParams.Profile1Index = (m_chkProfileIndex1.Checked ? '\u0001' : '\0');
				m_MonSynthFreqLinearityConfigParams.Profile2Index = (m_chkProfileIndex2.Checked ? '\u0001' : '\0');
				m_MonSynthFreqLinearityConfigParams.Profile3Index = (m_chkProfileIndex3.Checked ? '\u0001' : '\0');
				m_MonSynthFreqLinearityConfigParams.ReportingMode = (char)m_nudReportingMode.Value;
				m_MonSynthFreqLinearityConfigParams.FreqErrorThreshold = (ushort)m_nudFreqErrorThreshold.Value;
				m_MonSynthFreqLinearityConfigParams.Profile0MonStartTime = (double)m_nudMonStartTimeProfile0.Value;
				m_MonSynthFreqLinearityConfigParams.Profile1MonStartTime = (double)m_nudMonStartTimeProfile1.Value;
				m_MonSynthFreqLinearityConfigParams.Profile2MonStartTime = (double)m_nudMonStartTimeProfile2.Value;
				m_MonSynthFreqLinearityConfigParams.Profile3MonStartTime = (double)m_nudMonStartTimeProfile3.Value;
				m_MonSynthFreqLinearityConfigParams.DataPathParams1L1 = (char)m_nudDataPathP1L1.Value;
				m_MonSynthFreqLinearityConfigParams.DataPathParams1L2 = (char)m_nudDataPathP1L2.Value;
				m_MonSynthFreqLinearityConfigParams.DataPathParams1N = (char)m_nudDataPathP1N.Value;
				m_MonSynthFreqLinearityConfigParams.DataPathParams2S1 = (char)m_nudDataPathP2S1.Value;
				m_MonSynthFreqLinearityConfigParams.DataPathParams2S2 = (char)m_nudDataPathP2S2.Value;
				m_MonSynthFreqLinearityConfigParams.DataPathParams2S = (char)m_nudDataPathP2S.Value;
				m_MonSynthFreqLinearityConfigParams.Profile0LinearityRAMAddress = (char)m_nudLinearityRAMAddressProfile0.Value;
				m_MonSynthFreqLinearityConfigParams.Profile1LinearityRAMAddress = (char)m_nudLinearityRAMAddressProfile1.Value;
				m_MonSynthFreqLinearityConfigParams.Profile2LinearityRAMAddress = (char)m_nudLinearityRAMAddressProfile2.Value;
				m_MonSynthFreqLinearityConfigParams.Profile3LinearityRAMAddress = (char)m_nudLinearityRAMAddressProfile3.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateSynthFreqLinearityMonConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateSynthFreqLinearityMonConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_chkProfileIndex0.Checked = (m_MonSynthFreqLinearityConfigParams.Profile0Index == '\u0001');
				m_chkProfileIndex1.Checked = (m_MonSynthFreqLinearityConfigParams.Profile1Index == '\u0001');
				m_chkProfileIndex2.Checked = (m_MonSynthFreqLinearityConfigParams.Profile2Index == '\u0001');
				m_chkProfileIndex3.Checked = (m_MonSynthFreqLinearityConfigParams.Profile3Index == '\u0001');
				m_nudReportingMode.Value = m_MonSynthFreqLinearityConfigParams.ReportingMode;
				m_nudFreqErrorThreshold.Value = m_MonSynthFreqLinearityConfigParams.FreqErrorThreshold;
				m_nudMonStartTimeProfile0.Value = (decimal)m_MonSynthFreqLinearityConfigParams.Profile0MonStartTime;
				m_nudMonStartTimeProfile1.Value = (decimal)m_MonSynthFreqLinearityConfigParams.Profile1MonStartTime;
				m_nudMonStartTimeProfile2.Value = (decimal)m_MonSynthFreqLinearityConfigParams.Profile2MonStartTime;
				m_nudMonStartTimeProfile3.Value = (decimal)m_MonSynthFreqLinearityConfigParams.Profile3MonStartTime;
				m_nudDataPathP1L1.Value = m_MonSynthFreqLinearityConfigParams.DataPathParams1L1;
				m_nudDataPathP1L2.Value = m_MonSynthFreqLinearityConfigParams.DataPathParams1L2;
				m_nudDataPathP1N.Value = m_MonSynthFreqLinearityConfigParams.DataPathParams1N;
				m_nudDataPathP2S1.Value = m_MonSynthFreqLinearityConfigParams.DataPathParams2S1;
				m_nudDataPathP2S2.Value = m_MonSynthFreqLinearityConfigParams.DataPathParams2S2;
				m_nudDataPathP2S.Value = m_MonSynthFreqLinearityConfigParams.DataPathParams2S;
				m_nudLinearityRAMAddressProfile0.Value = m_MonSynthFreqLinearityConfigParams.Profile0LinearityRAMAddress;
				m_nudLinearityRAMAddressProfile1.Value = m_MonSynthFreqLinearityConfigParams.Profile1LinearityRAMAddress;
				m_nudLinearityRAMAddressProfile2.Value = m_MonSynthFreqLinearityConfigParams.Profile2LinearityRAMAddress;
				m_nudLinearityRAMAddressProfile3.Value = m_MonSynthFreqLinearityConfigParams.Profile3LinearityRAMAddress;
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
            this.components = new System.ComponentModel.Container();
            this.m_grpRFStatusCfg = new System.Windows.Forms.GroupBox();
            this.f00021b = new System.Windows.Forms.Label();
            this.f00021c = new System.Windows.Forms.Label();
            this.f00021d = new System.Windows.Forms.Label();
            this.f00021e = new System.Windows.Forms.Label();
            this.f00021f = new System.Windows.Forms.Label();
            this.f000220 = new System.Windows.Forms.Label();
            this.f000221 = new System.Windows.Forms.Label();
            this.f000222 = new System.Windows.Forms.Label();
            this.f00021a = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.m_nudSkipClockExp = new System.Windows.Forms.NumericUpDown();
            this.f000215 = new System.Windows.Forms.Label();
            this.f000216 = new System.Windows.Forms.Label();
            this.f000217 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnRFStatusCfg = new System.Windows.Forms.Button();
            this.m_nudSkipClockMant = new System.Windows.Forms.NumericUpDown();
            this.m_nudGPADCNumOfSamples = new System.Windows.Forms.NumericUpDown();
            this.m_nudGPADCParamVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudGPADConfigVal = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_grpRFCharReportCfg = new System.Windows.Forms.GroupBox();
            this.f00018a = new System.Windows.Forms.Label();
            this.f00018b = new System.Windows.Forms.Label();
            this.f00018c = new System.Windows.Forms.Label();
            this.f00018d = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4DigTSValue = new System.Windows.Forms.Label();
            this.f000182 = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4Tx2TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4Tx1TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4Tx0TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4Rx3TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4Rx2TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4Rx1TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4Rx0TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4Time = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3DigTSValue = new System.Windows.Forms.Label();
            this.f000180 = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3Tx2TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3Tx1TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3Tx0TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3Rx3TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3Rx2TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3Rx1TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3Rx0TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3Time = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2DigTSValue = new System.Windows.Forms.Label();
            this.f000184 = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2Tx2TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2Tx1TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2Tx0TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2Rx3TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2Rx2TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2Rx1TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2Rx0TSValue = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2Time = new System.Windows.Forms.Label();
            this.m_lblDigTSValue = new System.Windows.Forms.Label();
            this.f00017e = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.m_lblTx2TSValue = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.m_lblTx1TSValue = new System.Windows.Forms.Label();
            this.m_lblTx0TSValue = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.m_lblRx3TSValue = new System.Windows.Forms.Label();
            this.m_lblRx2TSValue = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.m_lblRx1TSValue = new System.Windows.Forms.Label();
            this.m_lblRx0TSValue = new System.Windows.Forms.Label();
            this.m_lblTime = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.m_btnRFCharReportCfg = new System.Windows.Forms.Button();
            this.m_nudAeReportPeriod = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.m_grpRFCalibMonCfg = new System.Windows.Forms.GroupBox();
            this.m_nudRFMonitoringId = new System.Windows.Forms.NumericUpDown();
            this.m_chbCalibrationIndex = new System.Windows.Forms.CheckBox();
            this.m_chbMonitorinIndex = new System.Windows.Forms.CheckBox();
            this.m_btnRFCalibMonCfg = new System.Windows.Forms.Button();
            this.m_nudRFCalibrationId = new System.Windows.Forms.NumericUpDown();
            this.m_grpRFCalibDisableCfg = new System.Windows.Forms.GroupBox();
            this.m_btnRFClibDisableCfg = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.m_Synth2Ca = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.f000218 = new System.Windows.Forms.CheckBox();
            this.m_Synth2Cal = new System.Windows.Forms.CheckBox();
            this.m_Synth1Cal = new System.Windows.Forms.CheckBox();
            this.f000219 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lblRadarDevice4ClosedLoopFreq = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4ApllcalStatus = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4RefClkFreq = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4ProcessId = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3ClosedLoopFreq = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3ApllcalStatus = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3RefClkFreq = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3ProcessId = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2ClosedLoopFreq = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2ApllcalStatus = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2RefClkFreq = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2ProcessId = new System.Windows.Forms.Label();
            this.m_lblClosedLoopFreq = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.m_lblApllcalStatus = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.m_lblRefClkFreq = new System.Windows.Forms.Label();
            this.m_lblProcessId = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_nudTrimDig2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTrimPm2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTrimTx2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTrimRx2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTrimDig1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTrimPm1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTrimTx1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTrimRx1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTrimTemp2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTrimTemp1 = new System.Windows.Forms.NumericUpDown();
            this.m_btnRFCTempSensorCfg = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.f000223 = new System.Windows.Forms.GroupBox();
            this.m_CbPDTrimMode = new System.Windows.Forms.ComboBox();
            this.f000224 = new System.Windows.Forms.ComboBox();
            this.f000225 = new System.Windows.Forms.ComboBox();
            this.m_CbPDInstance = new System.Windows.Forms.ComboBox();
            this.m_btnPDTrim1GHzSet = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.m_grpMeasurePDPower = new System.Windows.Forms.GroupBox();
            this.m_lblRFSumOff = new System.Windows.Forms.Label();
            this.m_lblRFSumOn = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.m_CbPDType = new System.Windows.Forms.ComboBox();
            this.m_nudPDParamVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudPDDACVal = new System.Windows.Forms.NumericUpDown();
            this.m_nudPDSelect = new System.Windows.Forms.NumericUpDown();
            this.label75 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.m_lblPDPowerStatus = new System.Windows.Forms.Label();
            this.m_lblPDPower = new System.Windows.Forms.Label();
            this.f000226 = new System.Windows.Forms.Label();
            this.m_lblDeltaSum = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2PDPowerStatus = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2PDPower = new System.Windows.Forms.Label();
            this.f000227 = new System.Windows.Forms.Label();
            this.m_lblRadarDevice2DeltaSum = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3PDPowerStatus = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3PDPower = new System.Windows.Forms.Label();
            this.f000228 = new System.Windows.Forms.Label();
            this.m_lblRadarDevice3DeltaSum = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4PDPowerStatus = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4PDPower = new System.Windows.Forms.Label();
            this.f000229 = new System.Windows.Forms.Label();
            this.m_lblRadarDevice4DeltaSum = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.m_nudPDINumOfSamples = new System.Windows.Forms.NumericUpDown();
            this.m_nudNumOfAccumulations = new System.Windows.Forms.NumericUpDown();
            this.m_nudPDLNAGainIndex = new System.Windows.Forms.NumericUpDown();
            this.m_nudPDIndex = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.m_btnMeasurePDPowerSet = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.m_nudLinearityRAMAddressProfile0 = new System.Windows.Forms.NumericUpDown();
            this.m_nudDataPathP2S1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudDataPathP2S2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudDataPathP2S = new System.Windows.Forms.NumericUpDown();
            this.m_nudDataPathP1L1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudDataPathP1L2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudDataPathP1N = new System.Windows.Forms.NumericUpDown();
            this.m_nudMonStartTimeProfile0 = new System.Windows.Forms.NumericUpDown();
            this.m_nudMonStartTimeProfile1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudMonStartTimeProfile2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudReportingMode = new System.Windows.Forms.NumericUpDown();
            this.m_nudFreqErrorThreshold = new System.Windows.Forms.NumericUpDown();
            this.m_btnSynthFreqLinearityMonConfigSet = new System.Windows.Forms.Button();
            this.m_nudMonStartTimeProfile3 = new System.Windows.Forms.NumericUpDown();
            this.m_nudLinearityRAMAddressProfile1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudLinearityRAMAddressProfile2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudLinearityRAMAddressProfile3 = new System.Windows.Forms.NumericUpDown();
            this.label63 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_chkProfileIndex3 = new System.Windows.Forms.CheckBox();
            this.m_chkProfileIndex2 = new System.Windows.Forms.CheckBox();
            this.m_chkProfileIndex1 = new System.Windows.Forms.CheckBox();
            this.m_chkProfileIndex0 = new System.Windows.Forms.CheckBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.m_grpRFStatusCfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSkipClockExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSkipClockMant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGPADCNumOfSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGPADCParamVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGPADConfigVal)).BeginInit();
            this.m_grpRFCharReportCfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudAeReportPeriod)).BeginInit();
            this.m_grpRFCalibMonCfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRFMonitoringId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRFCalibrationId)).BeginInit();
            this.m_grpRFCalibDisableCfg.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimDig2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimPm2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimTx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimRx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimDig1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimPm1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimTx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimRx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimTemp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimTemp1)).BeginInit();
            this.f000223.SuspendLayout();
            this.m_grpMeasurePDPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDParamVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDDACVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDINumOfSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudNumOfAccumulations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDLNAGainIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudLinearityRAMAddressProfile0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP2S1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP2S2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP2S)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP1L1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP1L2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP1N)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMonStartTimeProfile0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMonStartTimeProfile1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMonStartTimeProfile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudReportingMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqErrorThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMonStartTimeProfile3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudLinearityRAMAddressProfile1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudLinearityRAMAddressProfile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudLinearityRAMAddressProfile3)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpRFStatusCfg
            // 
            this.m_grpRFStatusCfg.Controls.Add(this.f00021b);
            this.m_grpRFStatusCfg.Controls.Add(this.f00021c);
            this.m_grpRFStatusCfg.Controls.Add(this.f00021d);
            this.m_grpRFStatusCfg.Controls.Add(this.f00021e);
            this.m_grpRFStatusCfg.Controls.Add(this.f00021f);
            this.m_grpRFStatusCfg.Controls.Add(this.f000220);
            this.m_grpRFStatusCfg.Controls.Add(this.f000221);
            this.m_grpRFStatusCfg.Controls.Add(this.f000222);
            this.m_grpRFStatusCfg.Controls.Add(this.f00021a);
            this.m_grpRFStatusCfg.Controls.Add(this.label15);
            this.m_grpRFStatusCfg.Controls.Add(this.m_nudSkipClockExp);
            this.m_grpRFStatusCfg.Controls.Add(this.f000215);
            this.m_grpRFStatusCfg.Controls.Add(this.f000216);
            this.m_grpRFStatusCfg.Controls.Add(this.f000217);
            this.m_grpRFStatusCfg.Controls.Add(this.label8);
            this.m_grpRFStatusCfg.Controls.Add(this.label7);
            this.m_grpRFStatusCfg.Controls.Add(this.label2);
            this.m_grpRFStatusCfg.Controls.Add(this.label1);
            this.m_grpRFStatusCfg.Controls.Add(this.m_btnRFStatusCfg);
            this.m_grpRFStatusCfg.Controls.Add(this.m_nudSkipClockMant);
            this.m_grpRFStatusCfg.Controls.Add(this.m_nudGPADCNumOfSamples);
            this.m_grpRFStatusCfg.Controls.Add(this.m_nudGPADCParamVal);
            this.m_grpRFStatusCfg.Controls.Add(this.m_nudGPADConfigVal);
            this.m_grpRFStatusCfg.Controls.Add(this.label6);
            this.m_grpRFStatusCfg.Controls.Add(this.label5);
            this.m_grpRFStatusCfg.Controls.Add(this.label4);
            this.m_grpRFStatusCfg.Controls.Add(this.label3);
            this.m_grpRFStatusCfg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_grpRFStatusCfg.Location = new System.Drawing.Point(2, 1);
            this.m_grpRFStatusCfg.Name = "m_grpRFStatusCfg";
            this.m_grpRFStatusCfg.Size = new System.Drawing.Size(450, 277);
            this.m_grpRFStatusCfg.TabIndex = 0;
            this.m_grpRFStatusCfg.TabStop = false;
            this.m_grpRFStatusCfg.Text = "GPADC Measurement Config";
            // 
            // f00021b
            // 
            this.f00021b.AutoSize = true;
            this.f00021b.Location = new System.Drawing.Point(368, 258);
            this.f00021b.Name = "f00021b";
            this.f00021b.Size = new System.Drawing.Size(24, 15);
            this.f00021b.TabIndex = 32;
            this.f00021b.Text = "0.0";
            // 
            // f00021c
            // 
            this.f00021c.AutoSize = true;
            this.f00021c.Location = new System.Drawing.Point(368, 239);
            this.f00021c.Name = "f00021c";
            this.f00021c.Size = new System.Drawing.Size(24, 15);
            this.f00021c.TabIndex = 31;
            this.f00021c.Text = "0.0";
            // 
            // f00021d
            // 
            this.f00021d.AutoSize = true;
            this.f00021d.Location = new System.Drawing.Point(368, 218);
            this.f00021d.Name = "f00021d";
            this.f00021d.Size = new System.Drawing.Size(24, 15);
            this.f00021d.TabIndex = 30;
            this.f00021d.Text = "0.0";
            // 
            // f00021e
            // 
            this.f00021e.AutoSize = true;
            this.f00021e.Location = new System.Drawing.Point(292, 258);
            this.f00021e.Name = "f00021e";
            this.f00021e.Size = new System.Drawing.Size(24, 15);
            this.f00021e.TabIndex = 29;
            this.f00021e.Text = "0.0";
            // 
            // f00021f
            // 
            this.f00021f.AutoSize = true;
            this.f00021f.Location = new System.Drawing.Point(292, 239);
            this.f00021f.Name = "f00021f";
            this.f00021f.Size = new System.Drawing.Size(24, 15);
            this.f00021f.TabIndex = 28;
            this.f00021f.Text = "0.0";
            // 
            // f000220
            // 
            this.f000220.AutoSize = true;
            this.f000220.Location = new System.Drawing.Point(292, 218);
            this.f000220.Name = "f000220";
            this.f000220.Size = new System.Drawing.Size(24, 15);
            this.f000220.TabIndex = 27;
            this.f000220.Text = "0.0";
            // 
            // f000221
            // 
            this.f000221.AutoSize = true;
            this.f000221.Location = new System.Drawing.Point(212, 258);
            this.f000221.Name = "f000221";
            this.f000221.Size = new System.Drawing.Size(24, 15);
            this.f000221.TabIndex = 26;
            this.f000221.Text = "0.0";
            // 
            // f000222
            // 
            this.f000222.AutoSize = true;
            this.f000222.Location = new System.Drawing.Point(212, 239);
            this.f000222.Name = "f000222";
            this.f000222.Size = new System.Drawing.Size(24, 15);
            this.f000222.TabIndex = 25;
            this.f000222.Text = "0.0";
            // 
            // f00021a
            // 
            this.f00021a.AutoSize = true;
            this.f00021a.Location = new System.Drawing.Point(212, 218);
            this.f00021a.Name = "f00021a";
            this.f00021a.Size = new System.Drawing.Size(24, 15);
            this.f00021a.TabIndex = 24;
            this.f00021a.Text = "0.0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 15);
            this.label15.TabIndex = 23;
            this.label15.Text = "Skip  Clocks (Exp)";
            // 
            // m_nudSkipClockExp
            // 
            this.m_nudSkipClockExp.Location = new System.Drawing.Point(129, 139);
            this.m_nudSkipClockExp.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.m_nudSkipClockExp.Name = "m_nudSkipClockExp";
            this.m_nudSkipClockExp.Size = new System.Drawing.Size(88, 21);
            this.m_nudSkipClockExp.TabIndex = 22;
            // 
            // f000215
            // 
            this.f000215.AutoSize = true;
            this.f000215.Location = new System.Drawing.Point(130, 259);
            this.f000215.Name = "f000215";
            this.f000215.Size = new System.Drawing.Size(24, 15);
            this.f000215.TabIndex = 21;
            this.f000215.Text = "0.0";
            // 
            // f000216
            // 
            this.f000216.AutoSize = true;
            this.f000216.Location = new System.Drawing.Point(130, 239);
            this.f000216.Name = "f000216";
            this.f000216.Size = new System.Drawing.Size(24, 15);
            this.f000216.TabIndex = 20;
            this.f000216.Text = "0.0";
            // 
            // f000217
            // 
            this.f000217.AutoSize = true;
            this.f000217.Location = new System.Drawing.Point(130, 220);
            this.f000217.Name = "f000217";
            this.f000217.Size = new System.Drawing.Size(24, 15);
            this.f000217.TabIndex = 19;
            this.f000217.Text = "0.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "GPADC_Max_Meas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "GPADC_Min_Meas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "GPADC_Avg_Meas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "GPADC Data ";
            // 
            // m_btnRFStatusCfg
            // 
            this.m_btnRFStatusCfg.Location = new System.Drawing.Point(134, 166);
            this.m_btnRFStatusCfg.Name = "m_btnRFStatusCfg";
            this.m_btnRFStatusCfg.Size = new System.Drawing.Size(83, 27);
            this.m_btnRFStatusCfg.TabIndex = 14;
            this.m_btnRFStatusCfg.Text = "Set";
            this.m_btnRFStatusCfg.UseVisualStyleBackColor = true;
            // 
            // m_nudSkipClockMant
            // 
            this.m_nudSkipClockMant.Location = new System.Drawing.Point(129, 111);
            this.m_nudSkipClockMant.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_nudSkipClockMant.Name = "m_nudSkipClockMant";
            this.m_nudSkipClockMant.Size = new System.Drawing.Size(89, 21);
            this.m_nudSkipClockMant.TabIndex = 12;
            // 
            // m_nudGPADCNumOfSamples
            // 
            this.m_nudGPADCNumOfSamples.Location = new System.Drawing.Point(129, 81);
            this.m_nudGPADCNumOfSamples.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudGPADCNumOfSamples.Name = "m_nudGPADCNumOfSamples";
            this.m_nudGPADCNumOfSamples.Size = new System.Drawing.Size(89, 21);
            this.m_nudGPADCNumOfSamples.TabIndex = 11;
            this.m_nudGPADCNumOfSamples.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // m_nudGPADCParamVal
            // 
            this.m_nudGPADCParamVal.Location = new System.Drawing.Point(129, 53);
            this.m_nudGPADCParamVal.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudGPADCParamVal.Name = "m_nudGPADCParamVal";
            this.m_nudGPADCParamVal.Size = new System.Drawing.Size(89, 21);
            this.m_nudGPADCParamVal.TabIndex = 10;
            // 
            // m_nudGPADConfigVal
            // 
            this.m_nudGPADConfigVal.Location = new System.Drawing.Point(129, 26);
            this.m_nudGPADConfigVal.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.m_nudGPADConfigVal.Name = "m_nudGPADConfigVal";
            this.m_nudGPADConfigVal.Size = new System.Drawing.Size(89, 21);
            this.m_nudGPADConfigVal.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Skip Clocks (Mant)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "No. of Samples";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Param Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Config Value";
            // 
            // m_grpRFCharReportCfg
            // 
            this.m_grpRFCharReportCfg.Controls.Add(this.f00018a);
            this.m_grpRFCharReportCfg.Controls.Add(this.f00018b);
            this.m_grpRFCharReportCfg.Controls.Add(this.f00018c);
            this.m_grpRFCharReportCfg.Controls.Add(this.f00018d);
            this.m_grpRFCharReportCfg.Controls.Add(this.label78);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice4DigTSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.f000182);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice4Tx2TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice4Tx1TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice4Tx0TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice4Rx3TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice4Rx2TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice4Rx1TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice4Rx0TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice4Time);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice3DigTSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.f000180);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice3Tx2TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice3Tx1TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice3Tx0TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice3Rx3TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice3Rx2TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice3Rx1TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice3Rx0TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice3Time);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice2DigTSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.f000184);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice2Tx2TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice2Tx1TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice2Tx0TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice2Rx3TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice2Rx2TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice2Rx1TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice2Rx0TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRadarDevice2Time);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblDigTSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.f00017e);
            this.m_grpRFCharReportCfg.Controls.Add(this.label36);
            this.m_grpRFCharReportCfg.Controls.Add(this.label37);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblTx2TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.label29);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblTx1TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblTx0TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.label32);
            this.m_grpRFCharReportCfg.Controls.Add(this.label33);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRx3TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRx2TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.label24);
            this.m_grpRFCharReportCfg.Controls.Add(this.label25);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRx1TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblRx0TSValue);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_lblTime);
            this.m_grpRFCharReportCfg.Controls.Add(this.label18);
            this.m_grpRFCharReportCfg.Controls.Add(this.label19);
            this.m_grpRFCharReportCfg.Controls.Add(this.label20);
            this.m_grpRFCharReportCfg.Controls.Add(this.label21);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_btnRFCharReportCfg);
            this.m_grpRFCharReportCfg.Controls.Add(this.m_nudAeReportPeriod);
            this.m_grpRFCharReportCfg.Controls.Add(this.label9);
            this.m_grpRFCharReportCfg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_grpRFCharReportCfg.Location = new System.Drawing.Point(459, 313);
            this.m_grpRFCharReportCfg.Name = "m_grpRFCharReportCfg";
            this.m_grpRFCharReportCfg.Size = new System.Drawing.Size(472, 291);
            this.m_grpRFCharReportCfg.TabIndex = 1;
            this.m_grpRFCharReportCfg.TabStop = false;
            this.m_grpRFCharReportCfg.Text = "RF Temperature Report";
            // 
            // f00018a
            // 
            this.f00018a.AutoSize = true;
            this.f00018a.Location = new System.Drawing.Point(414, 254);
            this.f00018a.Name = "f00018a";
            this.f00018a.Size = new System.Drawing.Size(24, 15);
            this.f00018a.TabIndex = 81;
            this.f00018a.Text = "0.0";
            // 
            // f00018b
            // 
            this.f00018b.AutoSize = true;
            this.f00018b.Location = new System.Drawing.Point(332, 254);
            this.f00018b.Name = "f00018b";
            this.f00018b.Size = new System.Drawing.Size(24, 15);
            this.f00018b.TabIndex = 80;
            this.f00018b.Text = "0.0";
            // 
            // f00018c
            // 
            this.f00018c.AutoSize = true;
            this.f00018c.Location = new System.Drawing.Point(254, 254);
            this.f00018c.Name = "f00018c";
            this.f00018c.Size = new System.Drawing.Size(24, 15);
            this.f00018c.TabIndex = 79;
            this.f00018c.Text = "0.0";
            // 
            // f00018d
            // 
            this.f00018d.AutoSize = true;
            this.f00018d.Location = new System.Drawing.Point(176, 254);
            this.f00018d.Name = "f00018d";
            this.f00018d.Size = new System.Drawing.Size(24, 15);
            this.f00018d.TabIndex = 78;
            this.f00018d.Text = "0.0";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(10, 254);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(139, 15);
            this.label78.TabIndex = 77;
            this.label78.Text = "TEMP_DIG2_SENS (°C)";
            // 
            // m_lblRadarDevice4DigTSValue
            // 
            this.m_lblRadarDevice4DigTSValue.AutoSize = true;
            this.m_lblRadarDevice4DigTSValue.Location = new System.Drawing.Point(414, 237);
            this.m_lblRadarDevice4DigTSValue.Name = "m_lblRadarDevice4DigTSValue";
            this.m_lblRadarDevice4DigTSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice4DigTSValue.TabIndex = 74;
            this.m_lblRadarDevice4DigTSValue.Text = "0.0";
            // 
            // f000182
            // 
            this.f000182.AutoSize = true;
            this.f000182.Location = new System.Drawing.Point(414, 219);
            this.f000182.Name = "f000182";
            this.f000182.Size = new System.Drawing.Size(24, 15);
            this.f000182.TabIndex = 73;
            this.f000182.Text = "0.0";
            // 
            // m_lblRadarDevice4Tx2TSValue
            // 
            this.m_lblRadarDevice4Tx2TSValue.AutoSize = true;
            this.m_lblRadarDevice4Tx2TSValue.Location = new System.Drawing.Point(414, 198);
            this.m_lblRadarDevice4Tx2TSValue.Name = "m_lblRadarDevice4Tx2TSValue";
            this.m_lblRadarDevice4Tx2TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice4Tx2TSValue.TabIndex = 72;
            this.m_lblRadarDevice4Tx2TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice4Tx1TSValue
            // 
            this.m_lblRadarDevice4Tx1TSValue.AutoSize = true;
            this.m_lblRadarDevice4Tx1TSValue.Location = new System.Drawing.Point(414, 180);
            this.m_lblRadarDevice4Tx1TSValue.Name = "m_lblRadarDevice4Tx1TSValue";
            this.m_lblRadarDevice4Tx1TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice4Tx1TSValue.TabIndex = 71;
            this.m_lblRadarDevice4Tx1TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice4Tx0TSValue
            // 
            this.m_lblRadarDevice4Tx0TSValue.AutoSize = true;
            this.m_lblRadarDevice4Tx0TSValue.Location = new System.Drawing.Point(414, 162);
            this.m_lblRadarDevice4Tx0TSValue.Name = "m_lblRadarDevice4Tx0TSValue";
            this.m_lblRadarDevice4Tx0TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice4Tx0TSValue.TabIndex = 70;
            this.m_lblRadarDevice4Tx0TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice4Rx3TSValue
            // 
            this.m_lblRadarDevice4Rx3TSValue.AutoSize = true;
            this.m_lblRadarDevice4Rx3TSValue.Location = new System.Drawing.Point(414, 141);
            this.m_lblRadarDevice4Rx3TSValue.Name = "m_lblRadarDevice4Rx3TSValue";
            this.m_lblRadarDevice4Rx3TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice4Rx3TSValue.TabIndex = 69;
            this.m_lblRadarDevice4Rx3TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice4Rx2TSValue
            // 
            this.m_lblRadarDevice4Rx2TSValue.AutoSize = true;
            this.m_lblRadarDevice4Rx2TSValue.Location = new System.Drawing.Point(414, 120);
            this.m_lblRadarDevice4Rx2TSValue.Name = "m_lblRadarDevice4Rx2TSValue";
            this.m_lblRadarDevice4Rx2TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice4Rx2TSValue.TabIndex = 68;
            this.m_lblRadarDevice4Rx2TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice4Rx1TSValue
            // 
            this.m_lblRadarDevice4Rx1TSValue.AutoSize = true;
            this.m_lblRadarDevice4Rx1TSValue.Location = new System.Drawing.Point(414, 105);
            this.m_lblRadarDevice4Rx1TSValue.Name = "m_lblRadarDevice4Rx1TSValue";
            this.m_lblRadarDevice4Rx1TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice4Rx1TSValue.TabIndex = 67;
            this.m_lblRadarDevice4Rx1TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice4Rx0TSValue
            // 
            this.m_lblRadarDevice4Rx0TSValue.AutoSize = true;
            this.m_lblRadarDevice4Rx0TSValue.Location = new System.Drawing.Point(414, 85);
            this.m_lblRadarDevice4Rx0TSValue.Name = "m_lblRadarDevice4Rx0TSValue";
            this.m_lblRadarDevice4Rx0TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice4Rx0TSValue.TabIndex = 66;
            this.m_lblRadarDevice4Rx0TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice4Time
            // 
            this.m_lblRadarDevice4Time.AutoSize = true;
            this.m_lblRadarDevice4Time.Location = new System.Drawing.Point(414, 70);
            this.m_lblRadarDevice4Time.Name = "m_lblRadarDevice4Time";
            this.m_lblRadarDevice4Time.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice4Time.TabIndex = 65;
            this.m_lblRadarDevice4Time.Text = "0";
            // 
            // m_lblRadarDevice3DigTSValue
            // 
            this.m_lblRadarDevice3DigTSValue.AutoSize = true;
            this.m_lblRadarDevice3DigTSValue.Location = new System.Drawing.Point(332, 236);
            this.m_lblRadarDevice3DigTSValue.Name = "m_lblRadarDevice3DigTSValue";
            this.m_lblRadarDevice3DigTSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice3DigTSValue.TabIndex = 64;
            this.m_lblRadarDevice3DigTSValue.Text = "0.0";
            // 
            // f000180
            // 
            this.f000180.AutoSize = true;
            this.f000180.Location = new System.Drawing.Point(332, 218);
            this.f000180.Name = "f000180";
            this.f000180.Size = new System.Drawing.Size(24, 15);
            this.f000180.TabIndex = 63;
            this.f000180.Text = "0.0";
            // 
            // m_lblRadarDevice3Tx2TSValue
            // 
            this.m_lblRadarDevice3Tx2TSValue.AutoSize = true;
            this.m_lblRadarDevice3Tx2TSValue.Location = new System.Drawing.Point(332, 197);
            this.m_lblRadarDevice3Tx2TSValue.Name = "m_lblRadarDevice3Tx2TSValue";
            this.m_lblRadarDevice3Tx2TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice3Tx2TSValue.TabIndex = 62;
            this.m_lblRadarDevice3Tx2TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice3Tx1TSValue
            // 
            this.m_lblRadarDevice3Tx1TSValue.AutoSize = true;
            this.m_lblRadarDevice3Tx1TSValue.Location = new System.Drawing.Point(332, 180);
            this.m_lblRadarDevice3Tx1TSValue.Name = "m_lblRadarDevice3Tx1TSValue";
            this.m_lblRadarDevice3Tx1TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice3Tx1TSValue.TabIndex = 61;
            this.m_lblRadarDevice3Tx1TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice3Tx0TSValue
            // 
            this.m_lblRadarDevice3Tx0TSValue.AutoSize = true;
            this.m_lblRadarDevice3Tx0TSValue.Location = new System.Drawing.Point(332, 161);
            this.m_lblRadarDevice3Tx0TSValue.Name = "m_lblRadarDevice3Tx0TSValue";
            this.m_lblRadarDevice3Tx0TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice3Tx0TSValue.TabIndex = 60;
            this.m_lblRadarDevice3Tx0TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice3Rx3TSValue
            // 
            this.m_lblRadarDevice3Rx3TSValue.AutoSize = true;
            this.m_lblRadarDevice3Rx3TSValue.Location = new System.Drawing.Point(332, 141);
            this.m_lblRadarDevice3Rx3TSValue.Name = "m_lblRadarDevice3Rx3TSValue";
            this.m_lblRadarDevice3Rx3TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice3Rx3TSValue.TabIndex = 59;
            this.m_lblRadarDevice3Rx3TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice3Rx2TSValue
            // 
            this.m_lblRadarDevice3Rx2TSValue.AutoSize = true;
            this.m_lblRadarDevice3Rx2TSValue.Location = new System.Drawing.Point(332, 119);
            this.m_lblRadarDevice3Rx2TSValue.Name = "m_lblRadarDevice3Rx2TSValue";
            this.m_lblRadarDevice3Rx2TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice3Rx2TSValue.TabIndex = 58;
            this.m_lblRadarDevice3Rx2TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice3Rx1TSValue
            // 
            this.m_lblRadarDevice3Rx1TSValue.AutoSize = true;
            this.m_lblRadarDevice3Rx1TSValue.Location = new System.Drawing.Point(332, 103);
            this.m_lblRadarDevice3Rx1TSValue.Name = "m_lblRadarDevice3Rx1TSValue";
            this.m_lblRadarDevice3Rx1TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice3Rx1TSValue.TabIndex = 57;
            this.m_lblRadarDevice3Rx1TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice3Rx0TSValue
            // 
            this.m_lblRadarDevice3Rx0TSValue.AutoSize = true;
            this.m_lblRadarDevice3Rx0TSValue.Location = new System.Drawing.Point(332, 84);
            this.m_lblRadarDevice3Rx0TSValue.Name = "m_lblRadarDevice3Rx0TSValue";
            this.m_lblRadarDevice3Rx0TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice3Rx0TSValue.TabIndex = 56;
            this.m_lblRadarDevice3Rx0TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice3Time
            // 
            this.m_lblRadarDevice3Time.AutoSize = true;
            this.m_lblRadarDevice3Time.Location = new System.Drawing.Point(332, 68);
            this.m_lblRadarDevice3Time.Name = "m_lblRadarDevice3Time";
            this.m_lblRadarDevice3Time.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice3Time.TabIndex = 55;
            this.m_lblRadarDevice3Time.Text = "0";
            // 
            // m_lblRadarDevice2DigTSValue
            // 
            this.m_lblRadarDevice2DigTSValue.AutoSize = true;
            this.m_lblRadarDevice2DigTSValue.Location = new System.Drawing.Point(254, 237);
            this.m_lblRadarDevice2DigTSValue.Name = "m_lblRadarDevice2DigTSValue";
            this.m_lblRadarDevice2DigTSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice2DigTSValue.TabIndex = 54;
            this.m_lblRadarDevice2DigTSValue.Text = "0.0";
            // 
            // f000184
            // 
            this.f000184.AutoSize = true;
            this.f000184.Location = new System.Drawing.Point(254, 219);
            this.f000184.Name = "f000184";
            this.f000184.Size = new System.Drawing.Size(24, 15);
            this.f000184.TabIndex = 53;
            this.f000184.Text = "0.0";
            // 
            // m_lblRadarDevice2Tx2TSValue
            // 
            this.m_lblRadarDevice2Tx2TSValue.AutoSize = true;
            this.m_lblRadarDevice2Tx2TSValue.Location = new System.Drawing.Point(254, 198);
            this.m_lblRadarDevice2Tx2TSValue.Name = "m_lblRadarDevice2Tx2TSValue";
            this.m_lblRadarDevice2Tx2TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice2Tx2TSValue.TabIndex = 52;
            this.m_lblRadarDevice2Tx2TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice2Tx1TSValue
            // 
            this.m_lblRadarDevice2Tx1TSValue.AutoSize = true;
            this.m_lblRadarDevice2Tx1TSValue.Location = new System.Drawing.Point(254, 180);
            this.m_lblRadarDevice2Tx1TSValue.Name = "m_lblRadarDevice2Tx1TSValue";
            this.m_lblRadarDevice2Tx1TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice2Tx1TSValue.TabIndex = 51;
            this.m_lblRadarDevice2Tx1TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice2Tx0TSValue
            // 
            this.m_lblRadarDevice2Tx0TSValue.AutoSize = true;
            this.m_lblRadarDevice2Tx0TSValue.Location = new System.Drawing.Point(254, 162);
            this.m_lblRadarDevice2Tx0TSValue.Name = "m_lblRadarDevice2Tx0TSValue";
            this.m_lblRadarDevice2Tx0TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice2Tx0TSValue.TabIndex = 50;
            this.m_lblRadarDevice2Tx0TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice2Rx3TSValue
            // 
            this.m_lblRadarDevice2Rx3TSValue.AutoSize = true;
            this.m_lblRadarDevice2Rx3TSValue.Location = new System.Drawing.Point(254, 141);
            this.m_lblRadarDevice2Rx3TSValue.Name = "m_lblRadarDevice2Rx3TSValue";
            this.m_lblRadarDevice2Rx3TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice2Rx3TSValue.TabIndex = 49;
            this.m_lblRadarDevice2Rx3TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice2Rx2TSValue
            // 
            this.m_lblRadarDevice2Rx2TSValue.AutoSize = true;
            this.m_lblRadarDevice2Rx2TSValue.Location = new System.Drawing.Point(254, 120);
            this.m_lblRadarDevice2Rx2TSValue.Name = "m_lblRadarDevice2Rx2TSValue";
            this.m_lblRadarDevice2Rx2TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice2Rx2TSValue.TabIndex = 48;
            this.m_lblRadarDevice2Rx2TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice2Rx1TSValue
            // 
            this.m_lblRadarDevice2Rx1TSValue.AutoSize = true;
            this.m_lblRadarDevice2Rx1TSValue.Location = new System.Drawing.Point(254, 105);
            this.m_lblRadarDevice2Rx1TSValue.Name = "m_lblRadarDevice2Rx1TSValue";
            this.m_lblRadarDevice2Rx1TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice2Rx1TSValue.TabIndex = 47;
            this.m_lblRadarDevice2Rx1TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice2Rx0TSValue
            // 
            this.m_lblRadarDevice2Rx0TSValue.AutoSize = true;
            this.m_lblRadarDevice2Rx0TSValue.Location = new System.Drawing.Point(254, 85);
            this.m_lblRadarDevice2Rx0TSValue.Name = "m_lblRadarDevice2Rx0TSValue";
            this.m_lblRadarDevice2Rx0TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice2Rx0TSValue.TabIndex = 46;
            this.m_lblRadarDevice2Rx0TSValue.Text = "0.0";
            // 
            // m_lblRadarDevice2Time
            // 
            this.m_lblRadarDevice2Time.AutoSize = true;
            this.m_lblRadarDevice2Time.Location = new System.Drawing.Point(254, 70);
            this.m_lblRadarDevice2Time.Name = "m_lblRadarDevice2Time";
            this.m_lblRadarDevice2Time.Size = new System.Drawing.Size(14, 15);
            this.m_lblRadarDevice2Time.TabIndex = 45;
            this.m_lblRadarDevice2Time.Text = "0";
            // 
            // m_lblDigTSValue
            // 
            this.m_lblDigTSValue.AutoSize = true;
            this.m_lblDigTSValue.Location = new System.Drawing.Point(176, 237);
            this.m_lblDigTSValue.Name = "m_lblDigTSValue";
            this.m_lblDigTSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblDigTSValue.TabIndex = 44;
            this.m_lblDigTSValue.Text = "0.0";
            // 
            // f00017e
            // 
            this.f00017e.AutoSize = true;
            this.f00017e.Location = new System.Drawing.Point(176, 219);
            this.f00017e.Name = "f00017e";
            this.f00017e.Size = new System.Drawing.Size(24, 15);
            this.f00017e.TabIndex = 43;
            this.f00017e.Text = "0.0";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(10, 237);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(139, 15);
            this.label36.TabIndex = 42;
            this.label36.Text = "TEMP_DIG1_SENS (°C)";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(10, 219);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(128, 15);
            this.label37.TabIndex = 41;
            this.label37.Text = "TEMP_PM_SENS (°C)";
            // 
            // m_lblTx2TSValue
            // 
            this.m_lblTx2TSValue.AutoSize = true;
            this.m_lblTx2TSValue.Location = new System.Drawing.Point(176, 200);
            this.m_lblTx2TSValue.Name = "m_lblTx2TSValue";
            this.m_lblTx2TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblTx2TSValue.TabIndex = 39;
            this.m_lblTx2TSValue.Text = "0.0";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(10, 200);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(132, 15);
            this.label29.TabIndex = 37;
            this.label29.Text = "TEMP_TX3_SENS (°C)";
            // 
            // m_lblTx1TSValue
            // 
            this.m_lblTx1TSValue.AutoSize = true;
            this.m_lblTx1TSValue.Location = new System.Drawing.Point(176, 180);
            this.m_lblTx1TSValue.Name = "m_lblTx1TSValue";
            this.m_lblTx1TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblTx1TSValue.TabIndex = 36;
            this.m_lblTx1TSValue.Text = "0.0";
            // 
            // m_lblTx0TSValue
            // 
            this.m_lblTx0TSValue.AutoSize = true;
            this.m_lblTx0TSValue.Location = new System.Drawing.Point(176, 162);
            this.m_lblTx0TSValue.Name = "m_lblTx0TSValue";
            this.m_lblTx0TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblTx0TSValue.TabIndex = 35;
            this.m_lblTx0TSValue.Text = "0.0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(10, 180);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(132, 15);
            this.label32.TabIndex = 34;
            this.label32.Text = "TEMP_TX2_SENS (°C)";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(10, 162);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(132, 15);
            this.label33.TabIndex = 33;
            this.label33.Text = "TEMP_TX1_SENS (°C)";
            // 
            // m_lblRx3TSValue
            // 
            this.m_lblRx3TSValue.AutoSize = true;
            this.m_lblRx3TSValue.Location = new System.Drawing.Point(176, 142);
            this.m_lblRx3TSValue.Name = "m_lblRx3TSValue";
            this.m_lblRx3TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRx3TSValue.TabIndex = 32;
            this.m_lblRx3TSValue.Text = "0.0";
            // 
            // m_lblRx2TSValue
            // 
            this.m_lblRx2TSValue.AutoSize = true;
            this.m_lblRx2TSValue.Location = new System.Drawing.Point(176, 124);
            this.m_lblRx2TSValue.Name = "m_lblRx2TSValue";
            this.m_lblRx2TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRx2TSValue.TabIndex = 31;
            this.m_lblRx2TSValue.Text = "0.0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 142);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(134, 15);
            this.label24.TabIndex = 30;
            this.label24.Text = "TEMP_RX4_SENS (°C)";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(10, 124);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(134, 15);
            this.label25.TabIndex = 29;
            this.label25.Text = "TEMP_RX3_SENS (°C)";
            // 
            // m_lblRx1TSValue
            // 
            this.m_lblRx1TSValue.AutoSize = true;
            this.m_lblRx1TSValue.Location = new System.Drawing.Point(176, 105);
            this.m_lblRx1TSValue.Name = "m_lblRx1TSValue";
            this.m_lblRx1TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRx1TSValue.TabIndex = 28;
            this.m_lblRx1TSValue.Text = "0.0";
            // 
            // m_lblRx0TSValue
            // 
            this.m_lblRx0TSValue.AutoSize = true;
            this.m_lblRx0TSValue.Location = new System.Drawing.Point(176, 85);
            this.m_lblRx0TSValue.Name = "m_lblRx0TSValue";
            this.m_lblRx0TSValue.Size = new System.Drawing.Size(24, 15);
            this.m_lblRx0TSValue.TabIndex = 27;
            this.m_lblRx0TSValue.Text = "0.0";
            // 
            // m_lblTime
            // 
            this.m_lblTime.AutoSize = true;
            this.m_lblTime.Location = new System.Drawing.Point(176, 68);
            this.m_lblTime.Name = "m_lblTime";
            this.m_lblTime.Size = new System.Drawing.Size(14, 15);
            this.m_lblTime.TabIndex = 26;
            this.m_lblTime.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(134, 15);
            this.label18.TabIndex = 25;
            this.label18.Text = "TEMP_RX2_SENS (°C)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 85);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(134, 15);
            this.label19.TabIndex = 24;
            this.label19.Text = "TEMP_RX1_SENS (°C)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 68);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 15);
            this.label20.TabIndex = 23;
            this.label20.Text = "Time (ms)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(10, 53);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 15);
            this.label21.TabIndex = 22;
            this.label21.Text = "CHAR Data ";
            // 
            // m_btnRFCharReportCfg
            // 
            this.m_btnRFCharReportCfg.Location = new System.Drawing.Point(230, 21);
            this.m_btnRFCharReportCfg.Name = "m_btnRFCharReportCfg";
            this.m_btnRFCharReportCfg.Size = new System.Drawing.Size(83, 27);
            this.m_btnRFCharReportCfg.TabIndex = 2;
            this.m_btnRFCharReportCfg.Text = "Set";
            this.m_btnRFCharReportCfg.UseVisualStyleBackColor = true;
            // 
            // m_nudAeReportPeriod
            // 
            this.m_nudAeReportPeriod.Location = new System.Drawing.Point(135, 24);
            this.m_nudAeReportPeriod.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudAeReportPeriod.Name = "m_nudAeReportPeriod";
            this.m_nudAeReportPeriod.Size = new System.Drawing.Size(72, 21);
            this.m_nudAeReportPeriod.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "ReportPeriod (sec)";
            // 
            // m_grpRFCalibMonCfg
            // 
            this.m_grpRFCalibMonCfg.Controls.Add(this.m_nudRFMonitoringId);
            this.m_grpRFCalibMonCfg.Controls.Add(this.m_chbCalibrationIndex);
            this.m_grpRFCalibMonCfg.Controls.Add(this.m_chbMonitorinIndex);
            this.m_grpRFCalibMonCfg.Controls.Add(this.m_btnRFCalibMonCfg);
            this.m_grpRFCalibMonCfg.Controls.Add(this.m_nudRFCalibrationId);
            this.m_grpRFCalibMonCfg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_grpRFCalibMonCfg.Location = new System.Drawing.Point(3, 418);
            this.m_grpRFCalibMonCfg.Name = "m_grpRFCalibMonCfg";
            this.m_grpRFCalibMonCfg.Size = new System.Drawing.Size(217, 128);
            this.m_grpRFCalibMonCfg.TabIndex = 2;
            this.m_grpRFCalibMonCfg.TabStop = false;
            this.m_grpRFCalibMonCfg.Text = "RFCalibMonConfig";
            // 
            // m_nudRFMonitoringId
            // 
            this.m_nudRFMonitoringId.Location = new System.Drawing.Point(145, 54);
            this.m_nudRFMonitoringId.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudRFMonitoringId.Name = "m_nudRFMonitoringId";
            this.m_nudRFMonitoringId.Size = new System.Drawing.Size(64, 21);
            this.m_nudRFMonitoringId.TabIndex = 5;
            // 
            // m_chbCalibrationIndex
            // 
            this.m_chbCalibrationIndex.AutoSize = true;
            this.m_chbCalibrationIndex.Location = new System.Drawing.Point(9, 23);
            this.m_chbCalibrationIndex.Name = "m_chbCalibrationIndex";
            this.m_chbCalibrationIndex.Size = new System.Drawing.Size(118, 19);
            this.m_chbCalibrationIndex.TabIndex = 4;
            this.m_chbCalibrationIndex.Text = "Calibration Index";
            this.m_chbCalibrationIndex.UseVisualStyleBackColor = true;
            // 
            // m_chbMonitorinIndex
            // 
            this.m_chbMonitorinIndex.AutoSize = true;
            this.m_chbMonitorinIndex.Location = new System.Drawing.Point(9, 56);
            this.m_chbMonitorinIndex.Name = "m_chbMonitorinIndex";
            this.m_chbMonitorinIndex.Size = new System.Drawing.Size(115, 19);
            this.m_chbMonitorinIndex.TabIndex = 3;
            this.m_chbMonitorinIndex.Text = "Monitoring Index";
            this.m_chbMonitorinIndex.UseVisualStyleBackColor = true;
            // 
            // m_btnRFCalibMonCfg
            // 
            this.m_btnRFCalibMonCfg.Location = new System.Drawing.Point(127, 84);
            this.m_btnRFCalibMonCfg.Name = "m_btnRFCalibMonCfg";
            this.m_btnRFCalibMonCfg.Size = new System.Drawing.Size(83, 27);
            this.m_btnRFCalibMonCfg.TabIndex = 2;
            this.m_btnRFCalibMonCfg.Text = "Set";
            this.m_btnRFCalibMonCfg.UseVisualStyleBackColor = true;
            // 
            // m_nudRFCalibrationId
            // 
            this.m_nudRFCalibrationId.Location = new System.Drawing.Point(145, 27);
            this.m_nudRFCalibrationId.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.m_nudRFCalibrationId.Minimum = new decimal(new int[] {
            257,
            0,
            0,
            0});
            this.m_nudRFCalibrationId.Name = "m_nudRFCalibrationId";
            this.m_nudRFCalibrationId.Size = new System.Drawing.Size(64, 21);
            this.m_nudRFCalibrationId.TabIndex = 1;
            this.m_nudRFCalibrationId.Value = new decimal(new int[] {
            257,
            0,
            0,
            0});
            // 
            // m_grpRFCalibDisableCfg
            // 
            this.m_grpRFCalibDisableCfg.Controls.Add(this.m_btnRFClibDisableCfg);
            this.m_grpRFCalibDisableCfg.Controls.Add(this.label51);
            this.m_grpRFCalibDisableCfg.Controls.Add(this.m_Synth2Ca);
            this.m_grpRFCalibDisableCfg.Controls.Add(this.label41);
            this.m_grpRFCalibDisableCfg.Controls.Add(this.label47);
            this.m_grpRFCalibDisableCfg.Controls.Add(this.f000218);
            this.m_grpRFCalibDisableCfg.Controls.Add(this.m_Synth2Cal);
            this.m_grpRFCalibDisableCfg.Controls.Add(this.m_Synth1Cal);
            this.m_grpRFCalibDisableCfg.Controls.Add(this.f000219);
            this.m_grpRFCalibDisableCfg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_grpRFCalibDisableCfg.Location = new System.Drawing.Point(235, 418);
            this.m_grpRFCalibDisableCfg.Name = "m_grpRFCalibDisableCfg";
            this.m_grpRFCalibDisableCfg.Size = new System.Drawing.Size(202, 128);
            this.m_grpRFCalibDisableCfg.TabIndex = 3;
            this.m_grpRFCalibDisableCfg.TabStop = false;
            this.m_grpRFCalibDisableCfg.Text = "Calibration Func Disable Config";
            // 
            // m_btnRFClibDisableCfg
            // 
            this.m_btnRFClibDisableCfg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnRFClibDisableCfg.Location = new System.Drawing.Point(140, 90);
            this.m_btnRFClibDisableCfg.Name = "m_btnRFClibDisableCfg";
            this.m_btnRFClibDisableCfg.Size = new System.Drawing.Size(52, 27);
            this.m_btnRFClibDisableCfg.TabIndex = 31;
            this.m_btnRFClibDisableCfg.Text = "Set";
            this.m_btnRFClibDisableCfg.UseVisualStyleBackColor = true;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(9, 25);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(82, 15);
            this.label51.TabIndex = 44;
            this.label51.Text = "GPADC Temp";
            // 
            // m_Synth2Ca
            // 
            this.m_Synth2Ca.AutoSize = true;
            this.m_Synth2Ca.Location = new System.Drawing.Point(10, 100);
            this.m_Synth2Ca.Name = "m_Synth2Ca";
            this.m_Synth2Ca.Size = new System.Drawing.Size(54, 15);
            this.m_Synth2Ca.TabIndex = 43;
            this.m_Synth2Ca.Text = "SYNTH2";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(9, 75);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(54, 15);
            this.label41.TabIndex = 41;
            this.label41.Text = "SYNTH1";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(10, 50);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(58, 15);
            this.label47.TabIndex = 39;
            this.label47.Text = "APLL Cal";
            // 
            // f000218
            // 
            this.f000218.AutoSize = true;
            this.f000218.Location = new System.Drawing.Point(105, 25);
            this.f000218.Name = "f000218";
            this.f000218.Size = new System.Drawing.Size(15, 14);
            this.f000218.TabIndex = 31;
            this.f000218.UseVisualStyleBackColor = true;
            // 
            // m_Synth2Cal
            // 
            this.m_Synth2Cal.AutoSize = true;
            this.m_Synth2Cal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_Synth2Cal.Location = new System.Drawing.Point(105, 100);
            this.m_Synth2Cal.Name = "m_Synth2Cal";
            this.m_Synth2Cal.Size = new System.Drawing.Size(29, 19);
            this.m_Synth2Cal.TabIndex = 20;
            this.m_Synth2Cal.Text = " ";
            this.m_Synth2Cal.UseVisualStyleBackColor = true;
            // 
            // m_Synth1Cal
            // 
            this.m_Synth1Cal.AutoSize = true;
            this.m_Synth1Cal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_Synth1Cal.Location = new System.Drawing.Point(105, 75);
            this.m_Synth1Cal.Name = "m_Synth1Cal";
            this.m_Synth1Cal.Size = new System.Drawing.Size(29, 19);
            this.m_Synth1Cal.TabIndex = 16;
            this.m_Synth1Cal.Text = " ";
            this.m_Synth1Cal.UseVisualStyleBackColor = true;
            // 
            // f000219
            // 
            this.f000219.AutoSize = true;
            this.f000219.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.f000219.Location = new System.Drawing.Point(105, 50);
            this.f000219.Name = "f000219";
            this.f000219.Size = new System.Drawing.Size(29, 19);
            this.f000219.TabIndex = 12;
            this.f000219.Text = " ";
            this.f000219.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_lblRadarDevice4ClosedLoopFreq);
            this.groupBox1.Controls.Add(this.m_lblRadarDevice4ApllcalStatus);
            this.groupBox1.Controls.Add(this.m_lblRadarDevice4RefClkFreq);
            this.groupBox1.Controls.Add(this.m_lblRadarDevice4ProcessId);
            this.groupBox1.Controls.Add(this.m_lblRadarDevice3ClosedLoopFreq);
            this.groupBox1.Controls.Add(this.m_lblRadarDevice3ApllcalStatus);
            this.groupBox1.Controls.Add(this.m_lblRadarDevice3RefClkFreq);
            this.groupBox1.Controls.Add(this.m_lblRadarDevice3ProcessId);
            this.groupBox1.Controls.Add(this.m_lblRadarDevice2ClosedLoopFreq);
            this.groupBox1.Controls.Add(this.m_lblRadarDevice2ApllcalStatus);
            this.groupBox1.Controls.Add(this.m_lblRadarDevice2RefClkFreq);
            this.groupBox1.Controls.Add(this.m_lblRadarDevice2ProcessId);
            this.groupBox1.Controls.Add(this.m_lblClosedLoopFreq);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Controls.Add(this.m_lblApllcalStatus);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.m_lblRefClkFreq);
            this.groupBox1.Controls.Add(this.m_lblProcessId);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 128);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BOOTUP DATA";
            // 
            // m_lblRadarDevice4ClosedLoopFreq
            // 
            this.m_lblRadarDevice4ClosedLoopFreq.AutoSize = true;
            this.m_lblRadarDevice4ClosedLoopFreq.Font = new System.Drawing.Font("Arial", 9F);
            this.m_lblRadarDevice4ClosedLoopFreq.Location = new System.Drawing.Point(367, 85);
            this.m_lblRadarDevice4ClosedLoopFreq.Name = "m_lblRadarDevice4ClosedLoopFreq";
            this.m_lblRadarDevice4ClosedLoopFreq.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice4ClosedLoopFreq.TabIndex = 52;
            this.m_lblRadarDevice4ClosedLoopFreq.Text = "0.0";
            // 
            // m_lblRadarDevice4ApllcalStatus
            // 
            this.m_lblRadarDevice4ApllcalStatus.AutoSize = true;
            this.m_lblRadarDevice4ApllcalStatus.Font = new System.Drawing.Font("Arial", 9F);
            this.m_lblRadarDevice4ApllcalStatus.Location = new System.Drawing.Point(367, 61);
            this.m_lblRadarDevice4ApllcalStatus.Name = "m_lblRadarDevice4ApllcalStatus";
            this.m_lblRadarDevice4ApllcalStatus.Size = new System.Drawing.Size(56, 15);
            this.m_lblRadarDevice4ApllcalStatus.TabIndex = 51;
            this.m_lblRadarDevice4ApllcalStatus.Text = "FAILURE";
            // 
            // m_lblRadarDevice4RefClkFreq
            // 
            this.m_lblRadarDevice4RefClkFreq.AutoSize = true;
            this.m_lblRadarDevice4RefClkFreq.Font = new System.Drawing.Font("Arial", 9F);
            this.m_lblRadarDevice4RefClkFreq.Location = new System.Drawing.Point(367, 38);
            this.m_lblRadarDevice4RefClkFreq.Name = "m_lblRadarDevice4RefClkFreq";
            this.m_lblRadarDevice4RefClkFreq.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice4RefClkFreq.TabIndex = 50;
            this.m_lblRadarDevice4RefClkFreq.Text = "0.0";
            // 
            // m_lblRadarDevice4ProcessId
            // 
            this.m_lblRadarDevice4ProcessId.AutoSize = true;
            this.m_lblRadarDevice4ProcessId.Font = new System.Drawing.Font("Arial", 9F);
            this.m_lblRadarDevice4ProcessId.Location = new System.Drawing.Point(367, 17);
            this.m_lblRadarDevice4ProcessId.Name = "m_lblRadarDevice4ProcessId";
            this.m_lblRadarDevice4ProcessId.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice4ProcessId.TabIndex = 49;
            this.m_lblRadarDevice4ProcessId.Text = "0.0";
            // 
            // m_lblRadarDevice3ClosedLoopFreq
            // 
            this.m_lblRadarDevice3ClosedLoopFreq.AutoSize = true;
            this.m_lblRadarDevice3ClosedLoopFreq.Font = new System.Drawing.Font("Arial", 9F);
            this.m_lblRadarDevice3ClosedLoopFreq.Location = new System.Drawing.Point(291, 83);
            this.m_lblRadarDevice3ClosedLoopFreq.Name = "m_lblRadarDevice3ClosedLoopFreq";
            this.m_lblRadarDevice3ClosedLoopFreq.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice3ClosedLoopFreq.TabIndex = 48;
            this.m_lblRadarDevice3ClosedLoopFreq.Text = "0.0";
            // 
            // m_lblRadarDevice3ApllcalStatus
            // 
            this.m_lblRadarDevice3ApllcalStatus.AutoSize = true;
            this.m_lblRadarDevice3ApllcalStatus.Font = new System.Drawing.Font("Arial", 9F);
            this.m_lblRadarDevice3ApllcalStatus.Location = new System.Drawing.Point(291, 62);
            this.m_lblRadarDevice3ApllcalStatus.Name = "m_lblRadarDevice3ApllcalStatus";
            this.m_lblRadarDevice3ApllcalStatus.Size = new System.Drawing.Size(56, 15);
            this.m_lblRadarDevice3ApllcalStatus.TabIndex = 47;
            this.m_lblRadarDevice3ApllcalStatus.Text = "FAILURE";
            // 
            // m_lblRadarDevice3RefClkFreq
            // 
            this.m_lblRadarDevice3RefClkFreq.AutoSize = true;
            this.m_lblRadarDevice3RefClkFreq.Font = new System.Drawing.Font("Arial", 9F);
            this.m_lblRadarDevice3RefClkFreq.Location = new System.Drawing.Point(291, 40);
            this.m_lblRadarDevice3RefClkFreq.Name = "m_lblRadarDevice3RefClkFreq";
            this.m_lblRadarDevice3RefClkFreq.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice3RefClkFreq.TabIndex = 46;
            this.m_lblRadarDevice3RefClkFreq.Text = "0.0";
            // 
            // m_lblRadarDevice3ProcessId
            // 
            this.m_lblRadarDevice3ProcessId.AutoSize = true;
            this.m_lblRadarDevice3ProcessId.Font = new System.Drawing.Font("Arial", 9F);
            this.m_lblRadarDevice3ProcessId.Location = new System.Drawing.Point(291, 21);
            this.m_lblRadarDevice3ProcessId.Name = "m_lblRadarDevice3ProcessId";
            this.m_lblRadarDevice3ProcessId.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice3ProcessId.TabIndex = 45;
            this.m_lblRadarDevice3ProcessId.Text = "0.0";
            // 
            // m_lblRadarDevice2ClosedLoopFreq
            // 
            this.m_lblRadarDevice2ClosedLoopFreq.AutoSize = true;
            this.m_lblRadarDevice2ClosedLoopFreq.Font = new System.Drawing.Font("Arial", 9F);
            this.m_lblRadarDevice2ClosedLoopFreq.Location = new System.Drawing.Point(211, 83);
            this.m_lblRadarDevice2ClosedLoopFreq.Name = "m_lblRadarDevice2ClosedLoopFreq";
            this.m_lblRadarDevice2ClosedLoopFreq.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice2ClosedLoopFreq.TabIndex = 44;
            this.m_lblRadarDevice2ClosedLoopFreq.Text = "0.0";
            // 
            // m_lblRadarDevice2ApllcalStatus
            // 
            this.m_lblRadarDevice2ApllcalStatus.AutoSize = true;
            this.m_lblRadarDevice2ApllcalStatus.Font = new System.Drawing.Font("Arial", 9F);
            this.m_lblRadarDevice2ApllcalStatus.Location = new System.Drawing.Point(211, 62);
            this.m_lblRadarDevice2ApllcalStatus.Name = "m_lblRadarDevice2ApllcalStatus";
            this.m_lblRadarDevice2ApllcalStatus.Size = new System.Drawing.Size(56, 15);
            this.m_lblRadarDevice2ApllcalStatus.TabIndex = 43;
            this.m_lblRadarDevice2ApllcalStatus.Text = "FAILURE";
            // 
            // m_lblRadarDevice2RefClkFreq
            // 
            this.m_lblRadarDevice2RefClkFreq.AutoSize = true;
            this.m_lblRadarDevice2RefClkFreq.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblRadarDevice2RefClkFreq.Location = new System.Drawing.Point(211, 40);
            this.m_lblRadarDevice2RefClkFreq.Name = "m_lblRadarDevice2RefClkFreq";
            this.m_lblRadarDevice2RefClkFreq.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice2RefClkFreq.TabIndex = 42;
            this.m_lblRadarDevice2RefClkFreq.Text = "0.0";
            // 
            // m_lblRadarDevice2ProcessId
            // 
            this.m_lblRadarDevice2ProcessId.AutoSize = true;
            this.m_lblRadarDevice2ProcessId.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblRadarDevice2ProcessId.Location = new System.Drawing.Point(211, 21);
            this.m_lblRadarDevice2ProcessId.Name = "m_lblRadarDevice2ProcessId";
            this.m_lblRadarDevice2ProcessId.Size = new System.Drawing.Size(24, 15);
            this.m_lblRadarDevice2ProcessId.TabIndex = 41;
            this.m_lblRadarDevice2ProcessId.Text = "0.0";
            // 
            // m_lblClosedLoopFreq
            // 
            this.m_lblClosedLoopFreq.AutoSize = true;
            this.m_lblClosedLoopFreq.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblClosedLoopFreq.Location = new System.Drawing.Point(131, 82);
            this.m_lblClosedLoopFreq.Name = "m_lblClosedLoopFreq";
            this.m_lblClosedLoopFreq.Size = new System.Drawing.Size(24, 15);
            this.m_lblClosedLoopFreq.TabIndex = 40;
            this.m_lblClosedLoopFreq.Text = "0.0";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(4, 83);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(115, 15);
            this.label45.TabIndex = 39;
            this.label45.Text = "APLL/24 Freq (MHz)";
            // 
            // m_lblApllcalStatus
            // 
            this.m_lblApllcalStatus.AutoSize = true;
            this.m_lblApllcalStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblApllcalStatus.Location = new System.Drawing.Point(131, 61);
            this.m_lblApllcalStatus.Name = "m_lblApllcalStatus";
            this.m_lblApllcalStatus.Size = new System.Drawing.Size(56, 15);
            this.m_lblApllcalStatus.TabIndex = 38;
            this.m_lblApllcalStatus.Text = "FAILURE";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(3, 62);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(97, 15);
            this.label40.TabIndex = 37;
            this.label40.Text = "APLLCAL Status";
            // 
            // m_lblRefClkFreq
            // 
            this.m_lblRefClkFreq.AutoSize = true;
            this.m_lblRefClkFreq.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblRefClkFreq.Location = new System.Drawing.Point(131, 40);
            this.m_lblRefClkFreq.Name = "m_lblRefClkFreq";
            this.m_lblRefClkFreq.Size = new System.Drawing.Size(24, 15);
            this.m_lblRefClkFreq.TabIndex = 36;
            this.m_lblRefClkFreq.Text = "0.0";
            // 
            // m_lblProcessId
            // 
            this.m_lblProcessId.AutoSize = true;
            this.m_lblProcessId.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblProcessId.Location = new System.Drawing.Point(131, 20);
            this.m_lblProcessId.Name = "m_lblProcessId";
            this.m_lblProcessId.Size = new System.Drawing.Size(24, 15);
            this.m_lblProcessId.TabIndex = 35;
            this.m_lblProcessId.Text = "0.0";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(3, 42);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(117, 15);
            this.label43.TabIndex = 34;
            this.label43.Text = "REFCLK Freq (MHz)";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(3, 21);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(81, 15);
            this.label44.TabIndex = 33;
            this.label44.Text = "PROCESS ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_nudTrimDig2);
            this.groupBox2.Controls.Add(this.m_nudTrimPm2);
            this.groupBox2.Controls.Add(this.m_nudTrimTx2);
            this.groupBox2.Controls.Add(this.m_nudTrimRx2);
            this.groupBox2.Controls.Add(this.m_nudTrimDig1);
            this.groupBox2.Controls.Add(this.m_nudTrimPm1);
            this.groupBox2.Controls.Add(this.m_nudTrimTx1);
            this.groupBox2.Controls.Add(this.m_nudTrimRx1);
            this.groupBox2.Controls.Add(this.m_nudTrimTemp2);
            this.groupBox2.Controls.Add(this.m_nudTrimTemp1);
            this.groupBox2.Controls.Add(this.m_btnRFCTempSensorCfg);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(458, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 304);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Temp Sensor Trim Values";
            // 
            // m_nudTrimDig2
            // 
            this.m_nudTrimDig2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_nudTrimDig2.Location = new System.Drawing.Point(136, 243);
            this.m_nudTrimDig2.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_nudTrimDig2.Name = "m_nudTrimDig2";
            this.m_nudTrimDig2.Size = new System.Drawing.Size(62, 21);
            this.m_nudTrimDig2.TabIndex = 40;
            // 
            // m_nudTrimPm2
            // 
            this.m_nudTrimPm2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_nudTrimPm2.Location = new System.Drawing.Point(136, 218);
            this.m_nudTrimPm2.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_nudTrimPm2.Name = "m_nudTrimPm2";
            this.m_nudTrimPm2.Size = new System.Drawing.Size(62, 21);
            this.m_nudTrimPm2.TabIndex = 39;
            // 
            // m_nudTrimTx2
            // 
            this.m_nudTrimTx2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_nudTrimTx2.Location = new System.Drawing.Point(137, 194);
            this.m_nudTrimTx2.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_nudTrimTx2.Name = "m_nudTrimTx2";
            this.m_nudTrimTx2.Size = new System.Drawing.Size(60, 21);
            this.m_nudTrimTx2.TabIndex = 38;
            // 
            // m_nudTrimRx2
            // 
            this.m_nudTrimRx2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_nudTrimRx2.Location = new System.Drawing.Point(137, 170);
            this.m_nudTrimRx2.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_nudTrimRx2.Name = "m_nudTrimRx2";
            this.m_nudTrimRx2.Size = new System.Drawing.Size(61, 21);
            this.m_nudTrimRx2.TabIndex = 37;
            // 
            // m_nudTrimDig1
            // 
            this.m_nudTrimDig1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_nudTrimDig1.Location = new System.Drawing.Point(137, 146);
            this.m_nudTrimDig1.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_nudTrimDig1.Name = "m_nudTrimDig1";
            this.m_nudTrimDig1.Size = new System.Drawing.Size(61, 21);
            this.m_nudTrimDig1.TabIndex = 36;
            // 
            // m_nudTrimPm1
            // 
            this.m_nudTrimPm1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_nudTrimPm1.Location = new System.Drawing.Point(137, 122);
            this.m_nudTrimPm1.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_nudTrimPm1.Name = "m_nudTrimPm1";
            this.m_nudTrimPm1.Size = new System.Drawing.Size(61, 21);
            this.m_nudTrimPm1.TabIndex = 35;
            // 
            // m_nudTrimTx1
            // 
            this.m_nudTrimTx1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_nudTrimTx1.Location = new System.Drawing.Point(137, 98);
            this.m_nudTrimTx1.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_nudTrimTx1.Name = "m_nudTrimTx1";
            this.m_nudTrimTx1.Size = new System.Drawing.Size(61, 21);
            this.m_nudTrimTx1.TabIndex = 34;
            // 
            // m_nudTrimRx1
            // 
            this.m_nudTrimRx1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_nudTrimRx1.Location = new System.Drawing.Point(137, 74);
            this.m_nudTrimRx1.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_nudTrimRx1.Name = "m_nudTrimRx1";
            this.m_nudTrimRx1.Size = new System.Drawing.Size(60, 21);
            this.m_nudTrimRx1.TabIndex = 33;
            // 
            // m_nudTrimTemp2
            // 
            this.m_nudTrimTemp2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_nudTrimTemp2.Location = new System.Drawing.Point(137, 50);
            this.m_nudTrimTemp2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudTrimTemp2.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.m_nudTrimTemp2.Name = "m_nudTrimTemp2";
            this.m_nudTrimTemp2.Size = new System.Drawing.Size(61, 21);
            this.m_nudTrimTemp2.TabIndex = 32;
            // 
            // m_nudTrimTemp1
            // 
            this.m_nudTrimTemp1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_nudTrimTemp1.Location = new System.Drawing.Point(137, 26);
            this.m_nudTrimTemp1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudTrimTemp1.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.m_nudTrimTemp1.Name = "m_nudTrimTemp1";
            this.m_nudTrimTemp1.Size = new System.Drawing.Size(61, 21);
            this.m_nudTrimTemp1.TabIndex = 31;
            // 
            // m_btnRFCTempSensorCfg
            // 
            this.m_btnRFCTempSensorCfg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnRFCTempSensorCfg.Location = new System.Drawing.Point(118, 271);
            this.m_btnRFCTempSensorCfg.Name = "m_btnRFCTempSensorCfg";
            this.m_btnRFCTempSensorCfg.Size = new System.Drawing.Size(83, 27);
            this.m_btnRFCTempSensorCfg.TabIndex = 30;
            this.m_btnRFCTempSensorCfg.Text = "Set";
            this.m_btnRFCTempSensorCfg.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(430, 121);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(0, 15);
            this.label42.TabIndex = 19;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(430, 27);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(0, 15);
            this.label35.TabIndex = 15;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(129, 75);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(0, 15);
            this.label30.TabIndex = 12;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(5, 245);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(122, 15);
            this.label26.TabIndex = 9;
            this.label26.Text = "TRIM CODE DIG (T2)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(5, 222);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(118, 15);
            this.label23.TabIndex = 8;
            this.label23.Text = "TRIM CODE PM (T2)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(4, 197);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(115, 15);
            this.label22.TabIndex = 7;
            this.label22.Text = "TRIM CODE TX (T2)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 172);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 15);
            this.label17.TabIndex = 6;
            this.label17.Text = "TRIM CODE RX (T2)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(5, 149);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(122, 15);
            this.label16.TabIndex = 5;
            this.label16.Text = "TRIM CODE DIG (T1)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(4, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "TRIM CODE PM (T1)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(5, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 15);
            this.label13.TabIndex = 3;
            this.label13.Text = "TRIM CODE TX (T1)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "TRIM CODE RX (T1)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "TRIM TEMP2 (°C)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "TRIM TEMP1 (°C)";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // f000223
            // 
            this.f000223.Controls.Add(this.m_CbPDTrimMode);
            this.f000223.Controls.Add(this.f000224);
            this.f000223.Controls.Add(this.f000225);
            this.f000223.Controls.Add(this.m_CbPDInstance);
            this.f000223.Controls.Add(this.m_btnPDTrim1GHzSet);
            this.f000223.Controls.Add(this.label31);
            this.f000223.Controls.Add(this.label34);
            this.f000223.Controls.Add(this.label28);
            this.f000223.Controls.Add(this.label27);
            this.f000223.Location = new System.Drawing.Point(689, 2);
            this.f000223.Name = "f000223";
            this.f000223.Size = new System.Drawing.Size(229, 207);
            this.f000223.TabIndex = 6;
            this.f000223.TabStop = false;
            this.f000223.Text = "PD Trim 1GHZ Config";
            // 
            // m_CbPDTrimMode
            // 
            this.m_CbPDTrimMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_CbPDTrimMode.FormattingEnabled = true;
            this.m_CbPDTrimMode.Items.AddRange(new object[] {
            "MeasureMode",
            "ProgramMode"});
            this.m_CbPDTrimMode.Location = new System.Drawing.Point(99, 120);
            this.m_CbPDTrimMode.Name = "m_CbPDTrimMode";
            this.m_CbPDTrimMode.Size = new System.Drawing.Size(93, 21);
            this.m_CbPDTrimMode.TabIndex = 11;
            // 
            // f000224
            // 
            this.f000224.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f000224.FormattingEnabled = true;
            this.f000224.Items.AddRange(new object[] {
            "OFF",
            "ON"});
            this.f000224.Location = new System.Drawing.Point(127, 89);
            this.f000224.Name = "f000224";
            this.f000224.Size = new System.Drawing.Size(63, 21);
            this.f000224.TabIndex = 10;
            // 
            // f000225
            // 
            this.f000225.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f000225.FormattingEnabled = true;
            this.f000225.Items.AddRange(new object[] {
            "-11",
            "-5",
            "1",
            "7"});
            this.f000225.Location = new System.Drawing.Point(128, 56);
            this.f000225.Name = "f000225";
            this.f000225.Size = new System.Drawing.Size(62, 21);
            this.f000225.TabIndex = 8;
            // 
            // m_CbPDInstance
            // 
            this.m_CbPDInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_CbPDInstance.FormattingEnabled = true;
            this.m_CbPDInstance.Items.AddRange(new object[] {
            "HPPD",
            "LPPD"});
            this.m_CbPDInstance.Location = new System.Drawing.Point(127, 19);
            this.m_CbPDInstance.Name = "m_CbPDInstance";
            this.m_CbPDInstance.Size = new System.Drawing.Size(63, 21);
            this.m_CbPDInstance.TabIndex = 7;
            // 
            // m_btnPDTrim1GHzSet
            // 
            this.m_btnPDTrim1GHzSet.Location = new System.Drawing.Point(110, 154);
            this.m_btnPDTrim1GHzSet.Name = "m_btnPDTrim1GHzSet";
            this.m_btnPDTrim1GHzSet.Size = new System.Drawing.Size(83, 27);
            this.m_btnPDTrim1GHzSet.TabIndex = 6;
            this.m_btnPDTrim1GHzSet.Text = "Set";
            this.m_btnPDTrim1GHzSet.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 123);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(34, 13);
            this.label31.TabIndex = 3;
            this.label31.Text = "Mode";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(10, 93);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(82, 13);
            this.label34.TabIndex = 2;
            this.label34.Text = "RFIN Power On";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 55);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(95, 13);
            this.label28.TabIndex = 1;
            this.label28.Text = "RFIN Power (dBm)";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 22);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(66, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "PD Instance";
            // 
            // m_grpMeasurePDPower
            // 
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblRFSumOff);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblRFSumOn);
            this.m_grpMeasurePDPower.Controls.Add(this.label77);
            this.m_grpMeasurePDPower.Controls.Add(this.label76);
            this.m_grpMeasurePDPower.Controls.Add(this.m_CbPDType);
            this.m_grpMeasurePDPower.Controls.Add(this.m_nudPDParamVal);
            this.m_grpMeasurePDPower.Controls.Add(this.m_nudPDDACVal);
            this.m_grpMeasurePDPower.Controls.Add(this.m_nudPDSelect);
            this.m_grpMeasurePDPower.Controls.Add(this.label75);
            this.m_grpMeasurePDPower.Controls.Add(this.label74);
            this.m_grpMeasurePDPower.Controls.Add(this.label62);
            this.m_grpMeasurePDPower.Controls.Add(this.label61);
            this.m_grpMeasurePDPower.Controls.Add(this.label72);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblPDPowerStatus);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblPDPower);
            this.m_grpMeasurePDPower.Controls.Add(this.f000226);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblDeltaSum);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblRadarDevice2PDPowerStatus);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblRadarDevice2PDPower);
            this.m_grpMeasurePDPower.Controls.Add(this.f000227);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblRadarDevice2DeltaSum);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblRadarDevice3PDPowerStatus);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblRadarDevice3PDPower);
            this.m_grpMeasurePDPower.Controls.Add(this.f000228);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblRadarDevice3DeltaSum);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblRadarDevice4PDPowerStatus);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblRadarDevice4PDPower);
            this.m_grpMeasurePDPower.Controls.Add(this.f000229);
            this.m_grpMeasurePDPower.Controls.Add(this.m_lblRadarDevice4DeltaSum);
            this.m_grpMeasurePDPower.Controls.Add(this.label52);
            this.m_grpMeasurePDPower.Controls.Add(this.label53);
            this.m_grpMeasurePDPower.Controls.Add(this.label54);
            this.m_grpMeasurePDPower.Controls.Add(this.label55);
            this.m_grpMeasurePDPower.Controls.Add(this.m_nudPDINumOfSamples);
            this.m_grpMeasurePDPower.Controls.Add(this.m_nudNumOfAccumulations);
            this.m_grpMeasurePDPower.Controls.Add(this.m_nudPDLNAGainIndex);
            this.m_grpMeasurePDPower.Controls.Add(this.m_nudPDIndex);
            this.m_grpMeasurePDPower.Controls.Add(this.label50);
            this.m_grpMeasurePDPower.Controls.Add(this.label49);
            this.m_grpMeasurePDPower.Controls.Add(this.label48);
            this.m_grpMeasurePDPower.Controls.Add(this.label46);
            this.m_grpMeasurePDPower.Controls.Add(this.m_btnMeasurePDPowerSet);
            this.m_grpMeasurePDPower.Location = new System.Drawing.Point(937, 2);
            this.m_grpMeasurePDPower.Name = "m_grpMeasurePDPower";
            this.m_grpMeasurePDPower.Size = new System.Drawing.Size(385, 273);
            this.m_grpMeasurePDPower.TabIndex = 7;
            this.m_grpMeasurePDPower.TabStop = false;
            this.m_grpMeasurePDPower.Text = "Measure PD Power Config";
            // 
            // m_lblRFSumOff
            // 
            this.m_lblRFSumOff.AutoSize = true;
            this.m_lblRFSumOff.Location = new System.Drawing.Point(127, 169);
            this.m_lblRFSumOff.Name = "m_lblRFSumOff";
            this.m_lblRFSumOff.Size = new System.Drawing.Size(13, 13);
            this.m_lblRFSumOff.TabIndex = 42;
            this.m_lblRFSumOff.Text = "0";
            // 
            // m_lblRFSumOn
            // 
            this.m_lblRFSumOn.AutoSize = true;
            this.m_lblRFSumOn.Location = new System.Drawing.Point(127, 150);
            this.m_lblRFSumOn.Name = "m_lblRFSumOn";
            this.m_lblRFSumOn.Size = new System.Drawing.Size(13, 13);
            this.m_lblRFSumOn.TabIndex = 41;
            this.m_lblRFSumOn.Text = "0";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(5, 169);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(62, 13);
            this.label77.TabIndex = 40;
            this.label77.Text = "Sum RF Off";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(5, 149);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(62, 13);
            this.label76.TabIndex = 39;
            this.label76.Text = "Sum RF On";
            // 
            // m_CbPDType
            // 
            this.m_CbPDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_CbPDType.FormattingEnabled = true;
            this.m_CbPDType.Items.AddRange(new object[] {
            "HPPD",
            "LPPD"});
            this.m_CbPDType.Location = new System.Drawing.Point(300, 16);
            this.m_CbPDType.Name = "m_CbPDType";
            this.m_CbPDType.Size = new System.Drawing.Size(72, 21);
            this.m_CbPDType.TabIndex = 38;
            // 
            // m_nudPDParamVal
            // 
            this.m_nudPDParamVal.Location = new System.Drawing.Point(300, 101);
            this.m_nudPDParamVal.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudPDParamVal.Name = "m_nudPDParamVal";
            this.m_nudPDParamVal.Size = new System.Drawing.Size(72, 20);
            this.m_nudPDParamVal.TabIndex = 37;
            // 
            // m_nudPDDACVal
            // 
            this.m_nudPDDACVal.Location = new System.Drawing.Point(300, 71);
            this.m_nudPDDACVal.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudPDDACVal.Name = "m_nudPDDACVal";
            this.m_nudPDDACVal.Size = new System.Drawing.Size(72, 20);
            this.m_nudPDDACVal.TabIndex = 36;
            // 
            // m_nudPDSelect
            // 
            this.m_nudPDSelect.Location = new System.Drawing.Point(300, 43);
            this.m_nudPDSelect.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudPDSelect.Name = "m_nudPDSelect";
            this.m_nudPDSelect.Size = new System.Drawing.Size(72, 20);
            this.m_nudPDSelect.TabIndex = 35;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(229, 105);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(55, 13);
            this.label75.TabIndex = 33;
            this.label75.Text = "Param Val";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(231, 74);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(65, 13);
            this.label74.TabIndex = 32;
            this.label74.Text = "PD DAC Val";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(229, 43);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(55, 13);
            this.label62.TabIndex = 31;
            this.label62.Text = "PD Select";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(229, 16);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(49, 13);
            this.label61.TabIndex = 30;
            this.label61.Text = "PD Type";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label72.Location = new System.Drawing.Point(6, 133);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(134, 13);
            this.label72.TabIndex = 29;
            this.label72.Text = "Measure PD Power Report";
            // 
            // m_lblPDPowerStatus
            // 
            this.m_lblPDPowerStatus.AutoSize = true;
            this.m_lblPDPowerStatus.Location = new System.Drawing.Point(127, 250);
            this.m_lblPDPowerStatus.Name = "m_lblPDPowerStatus";
            this.m_lblPDPowerStatus.Size = new System.Drawing.Size(29, 13);
            this.m_lblPDPowerStatus.TabIndex = 28;
            this.m_lblPDPowerStatus.Text = "FAIL";
            // 
            // m_lblPDPower
            // 
            this.m_lblPDPower.AutoSize = true;
            this.m_lblPDPower.Location = new System.Drawing.Point(127, 231);
            this.m_lblPDPower.Name = "m_lblPDPower";
            this.m_lblPDPower.Size = new System.Drawing.Size(13, 13);
            this.m_lblPDPower.TabIndex = 27;
            this.m_lblPDPower.Text = "0";
            // 
            // f000226
            // 
            this.f000226.AutoSize = true;
            this.f000226.Location = new System.Drawing.Point(127, 210);
            this.f000226.Name = "f000226";
            this.f000226.Size = new System.Drawing.Size(13, 13);
            this.f000226.TabIndex = 26;
            this.f000226.Text = "0";
            // 
            // m_lblDeltaSum
            // 
            this.m_lblDeltaSum.AutoSize = true;
            this.m_lblDeltaSum.Location = new System.Drawing.Point(127, 189);
            this.m_lblDeltaSum.Name = "m_lblDeltaSum";
            this.m_lblDeltaSum.Size = new System.Drawing.Size(13, 13);
            this.m_lblDeltaSum.TabIndex = 25;
            this.m_lblDeltaSum.Text = "0";
            // 
            // m_lblRadarDevice2PDPowerStatus
            // 
            this.m_lblRadarDevice2PDPowerStatus.AutoSize = true;
            this.m_lblRadarDevice2PDPowerStatus.Location = new System.Drawing.Point(189, 250);
            this.m_lblRadarDevice2PDPowerStatus.Name = "m_lblRadarDevice2PDPowerStatus";
            this.m_lblRadarDevice2PDPowerStatus.Size = new System.Drawing.Size(29, 13);
            this.m_lblRadarDevice2PDPowerStatus.TabIndex = 24;
            this.m_lblRadarDevice2PDPowerStatus.Text = "FAIL";
            // 
            // m_lblRadarDevice2PDPower
            // 
            this.m_lblRadarDevice2PDPower.AutoSize = true;
            this.m_lblRadarDevice2PDPower.Location = new System.Drawing.Point(189, 231);
            this.m_lblRadarDevice2PDPower.Name = "m_lblRadarDevice2PDPower";
            this.m_lblRadarDevice2PDPower.Size = new System.Drawing.Size(13, 13);
            this.m_lblRadarDevice2PDPower.TabIndex = 23;
            this.m_lblRadarDevice2PDPower.Text = "0";
            // 
            // f000227
            // 
            this.f000227.AutoSize = true;
            this.f000227.Location = new System.Drawing.Point(189, 210);
            this.f000227.Name = "f000227";
            this.f000227.Size = new System.Drawing.Size(13, 13);
            this.f000227.TabIndex = 22;
            this.f000227.Text = "0";
            // 
            // m_lblRadarDevice2DeltaSum
            // 
            this.m_lblRadarDevice2DeltaSum.AutoSize = true;
            this.m_lblRadarDevice2DeltaSum.Location = new System.Drawing.Point(189, 189);
            this.m_lblRadarDevice2DeltaSum.Name = "m_lblRadarDevice2DeltaSum";
            this.m_lblRadarDevice2DeltaSum.Size = new System.Drawing.Size(13, 13);
            this.m_lblRadarDevice2DeltaSum.TabIndex = 21;
            this.m_lblRadarDevice2DeltaSum.Text = "0";
            // 
            // m_lblRadarDevice3PDPowerStatus
            // 
            this.m_lblRadarDevice3PDPowerStatus.AutoSize = true;
            this.m_lblRadarDevice3PDPowerStatus.Location = new System.Drawing.Point(250, 250);
            this.m_lblRadarDevice3PDPowerStatus.Name = "m_lblRadarDevice3PDPowerStatus";
            this.m_lblRadarDevice3PDPowerStatus.Size = new System.Drawing.Size(29, 13);
            this.m_lblRadarDevice3PDPowerStatus.TabIndex = 20;
            this.m_lblRadarDevice3PDPowerStatus.Text = "FAIL";
            // 
            // m_lblRadarDevice3PDPower
            // 
            this.m_lblRadarDevice3PDPower.AutoSize = true;
            this.m_lblRadarDevice3PDPower.Location = new System.Drawing.Point(250, 231);
            this.m_lblRadarDevice3PDPower.Name = "m_lblRadarDevice3PDPower";
            this.m_lblRadarDevice3PDPower.Size = new System.Drawing.Size(13, 13);
            this.m_lblRadarDevice3PDPower.TabIndex = 19;
            this.m_lblRadarDevice3PDPower.Text = "0";
            // 
            // f000228
            // 
            this.f000228.AutoSize = true;
            this.f000228.Location = new System.Drawing.Point(250, 210);
            this.f000228.Name = "f000228";
            this.f000228.Size = new System.Drawing.Size(13, 13);
            this.f000228.TabIndex = 18;
            this.f000228.Text = "0";
            // 
            // m_lblRadarDevice3DeltaSum
            // 
            this.m_lblRadarDevice3DeltaSum.AutoSize = true;
            this.m_lblRadarDevice3DeltaSum.Location = new System.Drawing.Point(250, 189);
            this.m_lblRadarDevice3DeltaSum.Name = "m_lblRadarDevice3DeltaSum";
            this.m_lblRadarDevice3DeltaSum.Size = new System.Drawing.Size(13, 13);
            this.m_lblRadarDevice3DeltaSum.TabIndex = 17;
            this.m_lblRadarDevice3DeltaSum.Text = "0";
            // 
            // m_lblRadarDevice4PDPowerStatus
            // 
            this.m_lblRadarDevice4PDPowerStatus.AutoSize = true;
            this.m_lblRadarDevice4PDPowerStatus.Location = new System.Drawing.Point(321, 250);
            this.m_lblRadarDevice4PDPowerStatus.Name = "m_lblRadarDevice4PDPowerStatus";
            this.m_lblRadarDevice4PDPowerStatus.Size = new System.Drawing.Size(29, 13);
            this.m_lblRadarDevice4PDPowerStatus.TabIndex = 16;
            this.m_lblRadarDevice4PDPowerStatus.Text = "FAIL";
            // 
            // m_lblRadarDevice4PDPower
            // 
            this.m_lblRadarDevice4PDPower.AutoSize = true;
            this.m_lblRadarDevice4PDPower.Location = new System.Drawing.Point(321, 231);
            this.m_lblRadarDevice4PDPower.Name = "m_lblRadarDevice4PDPower";
            this.m_lblRadarDevice4PDPower.Size = new System.Drawing.Size(13, 13);
            this.m_lblRadarDevice4PDPower.TabIndex = 15;
            this.m_lblRadarDevice4PDPower.Text = "0";
            // 
            // f000229
            // 
            this.f000229.AutoSize = true;
            this.f000229.Location = new System.Drawing.Point(321, 210);
            this.f000229.Name = "f000229";
            this.f000229.Size = new System.Drawing.Size(13, 13);
            this.f000229.TabIndex = 14;
            this.f000229.Text = "0";
            // 
            // m_lblRadarDevice4DeltaSum
            // 
            this.m_lblRadarDevice4DeltaSum.AutoSize = true;
            this.m_lblRadarDevice4DeltaSum.Location = new System.Drawing.Point(321, 189);
            this.m_lblRadarDevice4DeltaSum.Name = "m_lblRadarDevice4DeltaSum";
            this.m_lblRadarDevice4DeltaSum.Size = new System.Drawing.Size(13, 13);
            this.m_lblRadarDevice4DeltaSum.TabIndex = 13;
            this.m_lblRadarDevice4DeltaSum.Text = "0";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(6, 250);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(99, 13);
            this.label52.TabIndex = 12;
            this.label52.Text = "PD Measure Status";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(6, 231);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(85, 13);
            this.label53.TabIndex = 11;
            this.label53.Text = "PD Power (dBm)";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(6, 210);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(80, 13);
            this.label54.TabIndex = 10;
            this.label54.Text = "VPD RMS (mV)";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(6, 189);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(56, 13);
            this.label55.TabIndex = 9;
            this.label55.Text = "Vpdo (mV)";
            // 
            // m_nudPDINumOfSamples
            // 
            this.m_nudPDINumOfSamples.Location = new System.Drawing.Point(117, 101);
            this.m_nudPDINumOfSamples.Name = "m_nudPDINumOfSamples";
            this.m_nudPDINumOfSamples.Size = new System.Drawing.Size(90, 20);
            this.m_nudPDINumOfSamples.TabIndex = 8;
            this.m_nudPDINumOfSamples.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // m_nudNumOfAccumulations
            // 
            this.m_nudNumOfAccumulations.Location = new System.Drawing.Point(117, 71);
            this.m_nudNumOfAccumulations.Name = "m_nudNumOfAccumulations";
            this.m_nudNumOfAccumulations.Size = new System.Drawing.Size(90, 20);
            this.m_nudNumOfAccumulations.TabIndex = 7;
            this.m_nudNumOfAccumulations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_nudPDLNAGainIndex
            // 
            this.m_nudPDLNAGainIndex.Location = new System.Drawing.Point(117, 42);
            this.m_nudPDLNAGainIndex.Name = "m_nudPDLNAGainIndex";
            this.m_nudPDLNAGainIndex.Size = new System.Drawing.Size(90, 20);
            this.m_nudPDLNAGainIndex.TabIndex = 6;
            this.m_nudPDLNAGainIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_nudPDIndex
            // 
            this.m_nudPDIndex.Location = new System.Drawing.Point(117, 13);
            this.m_nudPDIndex.Name = "m_nudPDIndex";
            this.m_nudPDIndex.Size = new System.Drawing.Size(90, 20);
            this.m_nudPDIndex.TabIndex = 5;
            this.m_nudPDIndex.Value = new decimal(new int[] {
            89,
            0,
            0,
            0});
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(6, 106);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(79, 13);
            this.label50.TabIndex = 4;
            this.label50.Text = "No. of Samples";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(6, 76);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(108, 13);
            this.label49.TabIndex = 3;
            this.label49.Text = "No. of Accumulations";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(6, 46);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(103, 13);
            this.label48.TabIndex = 2;
            this.label48.Text = "PD  LNA Gain Index";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(6, 16);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(51, 13);
            this.label46.TabIndex = 1;
            this.label46.Text = "PD Index";
            // 
            // m_btnMeasurePDPowerSet
            // 
            this.m_btnMeasurePDPowerSet.Location = new System.Drawing.Point(300, 124);
            this.m_btnMeasurePDPowerSet.Name = "m_btnMeasurePDPowerSet";
            this.m_btnMeasurePDPowerSet.Size = new System.Drawing.Size(72, 27);
            this.m_btnMeasurePDPowerSet.TabIndex = 0;
            this.m_btnMeasurePDPowerSet.Text = "Set";
            this.m_btnMeasurePDPowerSet.UseVisualStyleBackColor = true;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 22);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(65, 13);
            this.label38.TabIndex = 0;
            this.label38.Text = "Profile Index";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 44);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(83, 13);
            this.label39.TabIndex = 1;
            this.label39.Text = "Reporting Mode";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(6, 69);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(130, 13);
            this.label56.TabIndex = 2;
            this.label56.Text = "Freq Err threshold (10kHz)";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(6, 190);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(99, 13);
            this.label57.TabIndex = 3;
            this.label57.Text = "Mon Start Time (µs)";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(6, 108);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(96, 13);
            this.label58.TabIndex = 4;
            this.label58.Text = "DataPath Params1";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(6, 146);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(96, 13);
            this.label59.TabIndex = 5;
            this.label59.Text = "DataPath Params2";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(7, 218);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(113, 13);
            this.label60.TabIndex = 6;
            this.label60.Text = "Linearity RAM address";
            // 
            // m_nudLinearityRAMAddressProfile0
            // 
            this.m_nudLinearityRAMAddressProfile0.Location = new System.Drawing.Point(135, 214);
            this.m_nudLinearityRAMAddressProfile0.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_nudLinearityRAMAddressProfile0.Name = "m_nudLinearityRAMAddressProfile0";
            this.m_nudLinearityRAMAddressProfile0.Size = new System.Drawing.Size(49, 20);
            this.m_nudLinearityRAMAddressProfile0.TabIndex = 7;
            // 
            // m_nudDataPathP2S1
            // 
            this.m_nudDataPathP2S1.Location = new System.Drawing.Point(135, 146);
            this.m_nudDataPathP2S1.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.m_nudDataPathP2S1.Name = "m_nudDataPathP2S1";
            this.m_nudDataPathP2S1.Size = new System.Drawing.Size(49, 20);
            this.m_nudDataPathP2S1.TabIndex = 8;
            this.m_nudDataPathP2S1.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // m_nudDataPathP2S2
            // 
            this.m_nudDataPathP2S2.Location = new System.Drawing.Point(193, 145);
            this.m_nudDataPathP2S2.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.m_nudDataPathP2S2.Name = "m_nudDataPathP2S2";
            this.m_nudDataPathP2S2.Size = new System.Drawing.Size(49, 20);
            this.m_nudDataPathP2S2.TabIndex = 9;
            this.m_nudDataPathP2S2.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // m_nudDataPathP2S
            // 
            this.m_nudDataPathP2S.Location = new System.Drawing.Point(252, 144);
            this.m_nudDataPathP2S.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_nudDataPathP2S.Name = "m_nudDataPathP2S";
            this.m_nudDataPathP2S.Size = new System.Drawing.Size(49, 20);
            this.m_nudDataPathP2S.TabIndex = 10;
            this.m_nudDataPathP2S.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // m_nudDataPathP1L1
            // 
            this.m_nudDataPathP1L1.Location = new System.Drawing.Point(135, 104);
            this.m_nudDataPathP1L1.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.m_nudDataPathP1L1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudDataPathP1L1.Name = "m_nudDataPathP1L1";
            this.m_nudDataPathP1L1.Size = new System.Drawing.Size(49, 20);
            this.m_nudDataPathP1L1.TabIndex = 11;
            this.m_nudDataPathP1L1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // m_nudDataPathP1L2
            // 
            this.m_nudDataPathP1L2.Location = new System.Drawing.Point(193, 104);
            this.m_nudDataPathP1L2.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.m_nudDataPathP1L2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudDataPathP1L2.Name = "m_nudDataPathP1L2";
            this.m_nudDataPathP1L2.Size = new System.Drawing.Size(49, 20);
            this.m_nudDataPathP1L2.TabIndex = 12;
            this.m_nudDataPathP1L2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // m_nudDataPathP1N
            // 
            this.m_nudDataPathP1N.Location = new System.Drawing.Point(252, 104);
            this.m_nudDataPathP1N.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.m_nudDataPathP1N.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudDataPathP1N.Name = "m_nudDataPathP1N";
            this.m_nudDataPathP1N.Size = new System.Drawing.Size(49, 20);
            this.m_nudDataPathP1N.TabIndex = 13;
            this.m_nudDataPathP1N.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // m_nudMonStartTimeProfile0
            // 
            this.m_nudMonStartTimeProfile0.DecimalPlaces = 1;
            this.m_nudMonStartTimeProfile0.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.m_nudMonStartTimeProfile0.Location = new System.Drawing.Point(135, 189);
            this.m_nudMonStartTimeProfile0.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.m_nudMonStartTimeProfile0.Name = "m_nudMonStartTimeProfile0";
            this.m_nudMonStartTimeProfile0.Size = new System.Drawing.Size(49, 20);
            this.m_nudMonStartTimeProfile0.TabIndex = 14;
            this.m_nudMonStartTimeProfile0.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // m_nudMonStartTimeProfile1
            // 
            this.m_nudMonStartTimeProfile1.DecimalPlaces = 1;
            this.m_nudMonStartTimeProfile1.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.m_nudMonStartTimeProfile1.Location = new System.Drawing.Point(193, 188);
            this.m_nudMonStartTimeProfile1.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.m_nudMonStartTimeProfile1.Name = "m_nudMonStartTimeProfile1";
            this.m_nudMonStartTimeProfile1.Size = new System.Drawing.Size(49, 20);
            this.m_nudMonStartTimeProfile1.TabIndex = 15;
            // 
            // m_nudMonStartTimeProfile2
            // 
            this.m_nudMonStartTimeProfile2.DecimalPlaces = 1;
            this.m_nudMonStartTimeProfile2.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.m_nudMonStartTimeProfile2.Location = new System.Drawing.Point(252, 186);
            this.m_nudMonStartTimeProfile2.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.m_nudMonStartTimeProfile2.Name = "m_nudMonStartTimeProfile2";
            this.m_nudMonStartTimeProfile2.Size = new System.Drawing.Size(49, 20);
            this.m_nudMonStartTimeProfile2.TabIndex = 16;
            // 
            // m_nudReportingMode
            // 
            this.m_nudReportingMode.Location = new System.Drawing.Point(135, 40);
            this.m_nudReportingMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudReportingMode.Name = "m_nudReportingMode";
            this.m_nudReportingMode.Size = new System.Drawing.Size(49, 20);
            this.m_nudReportingMode.TabIndex = 18;
            // 
            // m_nudFreqErrorThreshold
            // 
            this.m_nudFreqErrorThreshold.Location = new System.Drawing.Point(135, 65);
            this.m_nudFreqErrorThreshold.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudFreqErrorThreshold.Name = "m_nudFreqErrorThreshold";
            this.m_nudFreqErrorThreshold.Size = new System.Drawing.Size(49, 20);
            this.m_nudFreqErrorThreshold.TabIndex = 19;
            this.m_nudFreqErrorThreshold.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // m_btnSynthFreqLinearityMonConfigSet
            // 
            this.m_btnSynthFreqLinearityMonConfigSet.Location = new System.Drawing.Point(288, 241);
            this.m_btnSynthFreqLinearityMonConfigSet.Name = "m_btnSynthFreqLinearityMonConfigSet";
            this.m_btnSynthFreqLinearityMonConfigSet.Size = new System.Drawing.Size(75, 23);
            this.m_btnSynthFreqLinearityMonConfigSet.TabIndex = 20;
            this.m_btnSynthFreqLinearityMonConfigSet.Text = "Set";
            this.m_btnSynthFreqLinearityMonConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_nudMonStartTimeProfile3
            // 
            this.m_nudMonStartTimeProfile3.DecimalPlaces = 1;
            this.m_nudMonStartTimeProfile3.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.m_nudMonStartTimeProfile3.Location = new System.Drawing.Point(313, 187);
            this.m_nudMonStartTimeProfile3.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.m_nudMonStartTimeProfile3.Name = "m_nudMonStartTimeProfile3";
            this.m_nudMonStartTimeProfile3.Size = new System.Drawing.Size(49, 20);
            this.m_nudMonStartTimeProfile3.TabIndex = 21;
            // 
            // m_nudLinearityRAMAddressProfile1
            // 
            this.m_nudLinearityRAMAddressProfile1.Location = new System.Drawing.Point(193, 214);
            this.m_nudLinearityRAMAddressProfile1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_nudLinearityRAMAddressProfile1.Name = "m_nudLinearityRAMAddressProfile1";
            this.m_nudLinearityRAMAddressProfile1.Size = new System.Drawing.Size(49, 20);
            this.m_nudLinearityRAMAddressProfile1.TabIndex = 22;
            // 
            // m_nudLinearityRAMAddressProfile2
            // 
            this.m_nudLinearityRAMAddressProfile2.Location = new System.Drawing.Point(252, 214);
            this.m_nudLinearityRAMAddressProfile2.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_nudLinearityRAMAddressProfile2.Name = "m_nudLinearityRAMAddressProfile2";
            this.m_nudLinearityRAMAddressProfile2.Size = new System.Drawing.Size(49, 20);
            this.m_nudLinearityRAMAddressProfile2.TabIndex = 23;
            // 
            // m_nudLinearityRAMAddressProfile3
            // 
            this.m_nudLinearityRAMAddressProfile3.Location = new System.Drawing.Point(313, 215);
            this.m_nudLinearityRAMAddressProfile3.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_nudLinearityRAMAddressProfile3.Name = "m_nudLinearityRAMAddressProfile3";
            this.m_nudLinearityRAMAddressProfile3.Size = new System.Drawing.Size(49, 20);
            this.m_nudLinearityRAMAddressProfile3.TabIndex = 24;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(315, 172);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(45, 13);
            this.label63.TabIndex = 27;
            this.label63.Text = "Profile 3";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_chkProfileIndex3);
            this.groupBox3.Controls.Add(this.m_chkProfileIndex2);
            this.groupBox3.Controls.Add(this.m_chkProfileIndex1);
            this.groupBox3.Controls.Add(this.m_chkProfileIndex0);
            this.groupBox3.Controls.Add(this.label70);
            this.groupBox3.Controls.Add(this.label71);
            this.groupBox3.Controls.Add(this.label73);
            this.groupBox3.Controls.Add(this.label67);
            this.groupBox3.Controls.Add(this.label68);
            this.groupBox3.Controls.Add(this.label69);
            this.groupBox3.Controls.Add(this.label64);
            this.groupBox3.Controls.Add(this.label65);
            this.groupBox3.Controls.Add(this.label66);
            this.groupBox3.Controls.Add(this.label63);
            this.groupBox3.Controls.Add(this.m_nudLinearityRAMAddressProfile3);
            this.groupBox3.Controls.Add(this.m_nudLinearityRAMAddressProfile2);
            this.groupBox3.Controls.Add(this.m_nudLinearityRAMAddressProfile1);
            this.groupBox3.Controls.Add(this.m_nudMonStartTimeProfile3);
            this.groupBox3.Controls.Add(this.m_btnSynthFreqLinearityMonConfigSet);
            this.groupBox3.Controls.Add(this.m_nudFreqErrorThreshold);
            this.groupBox3.Controls.Add(this.m_nudReportingMode);
            this.groupBox3.Controls.Add(this.m_nudMonStartTimeProfile2);
            this.groupBox3.Controls.Add(this.m_nudMonStartTimeProfile1);
            this.groupBox3.Controls.Add(this.m_nudMonStartTimeProfile0);
            this.groupBox3.Controls.Add(this.m_nudDataPathP1N);
            this.groupBox3.Controls.Add(this.m_nudDataPathP1L2);
            this.groupBox3.Controls.Add(this.m_nudDataPathP1L1);
            this.groupBox3.Controls.Add(this.m_nudDataPathP2S);
            this.groupBox3.Controls.Add(this.m_nudDataPathP2S2);
            this.groupBox3.Controls.Add(this.m_nudDataPathP2S1);
            this.groupBox3.Controls.Add(this.m_nudLinearityRAMAddressProfile0);
            this.groupBox3.Controls.Add(this.label60);
            this.groupBox3.Controls.Add(this.label59);
            this.groupBox3.Controls.Add(this.label58);
            this.groupBox3.Controls.Add(this.label57);
            this.groupBox3.Controls.Add(this.label56);
            this.groupBox3.Controls.Add(this.label39);
            this.groupBox3.Controls.Add(this.label38);
            this.groupBox3.Location = new System.Drawing.Point(943, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(379, 275);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Synth Freq Linearity Mon Config";
            // 
            // m_chkProfileIndex3
            // 
            this.m_chkProfileIndex3.AutoSize = true;
            this.m_chkProfileIndex3.Location = new System.Drawing.Point(317, 17);
            this.m_chkProfileIndex3.Name = "m_chkProfileIndex3";
            this.m_chkProfileIndex3.Size = new System.Drawing.Size(61, 17);
            this.m_chkProfileIndex3.TabIndex = 40;
            this.m_chkProfileIndex3.Text = "Profile3";
            this.m_chkProfileIndex3.UseVisualStyleBackColor = true;
            // 
            // m_chkProfileIndex2
            // 
            this.m_chkProfileIndex2.AutoSize = true;
            this.m_chkProfileIndex2.Location = new System.Drawing.Point(255, 17);
            this.m_chkProfileIndex2.Name = "m_chkProfileIndex2";
            this.m_chkProfileIndex2.Size = new System.Drawing.Size(61, 17);
            this.m_chkProfileIndex2.TabIndex = 39;
            this.m_chkProfileIndex2.Text = "Profile2";
            this.m_chkProfileIndex2.UseVisualStyleBackColor = true;
            // 
            // m_chkProfileIndex1
            // 
            this.m_chkProfileIndex1.AutoSize = true;
            this.m_chkProfileIndex1.Location = new System.Drawing.Point(196, 17);
            this.m_chkProfileIndex1.Name = "m_chkProfileIndex1";
            this.m_chkProfileIndex1.Size = new System.Drawing.Size(61, 17);
            this.m_chkProfileIndex1.TabIndex = 38;
            this.m_chkProfileIndex1.Text = "Profile1";
            this.m_chkProfileIndex1.UseVisualStyleBackColor = true;
            // 
            // m_chkProfileIndex0
            // 
            this.m_chkProfileIndex0.AutoSize = true;
            this.m_chkProfileIndex0.Location = new System.Drawing.Point(135, 17);
            this.m_chkProfileIndex0.Name = "m_chkProfileIndex0";
            this.m_chkProfileIndex0.Size = new System.Drawing.Size(61, 17);
            this.m_chkProfileIndex0.TabIndex = 37;
            this.m_chkProfileIndex0.Text = "Profile0";
            this.m_chkProfileIndex0.UseVisualStyleBackColor = true;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(252, 172);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(45, 13);
            this.label70.TabIndex = 36;
            this.label70.Text = "Profile 2";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(201, 172);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(45, 13);
            this.label71.TabIndex = 35;
            this.label71.Text = "Profile 1";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(137, 172);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(45, 13);
            this.label73.TabIndex = 34;
            this.label73.Text = "Profile 0";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(256, 131);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(14, 13);
            this.label67.TabIndex = 33;
            this.label67.Text = "S";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(201, 131);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(20, 13);
            this.label68.TabIndex = 32;
            this.label68.Text = "S2";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(136, 131);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(20, 13);
            this.label69.TabIndex = 31;
            this.label69.Text = "S1";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(265, 90);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(15, 13);
            this.label64.TabIndex = 30;
            this.label64.Text = "N";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(206, 90);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(19, 13);
            this.label65.TabIndex = 29;
            this.label65.Text = "L2";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(149, 90);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(19, 13);
            this.label66.TabIndex = 28;
            this.label66.Text = "L1";
            // 
            // RFStatusTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.m_grpMeasurePDPower);
            this.Controls.Add(this.f000223);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_grpRFCalibDisableCfg);
            this.Controls.Add(this.m_grpRFCalibMonCfg);
            this.Controls.Add(this.m_grpRFCharReportCfg);
            this.Controls.Add(this.m_grpRFStatusCfg);
            this.Name = "RFStatusTab";
            this.Size = new System.Drawing.Size(1341, 623);
            this.m_grpRFStatusCfg.ResumeLayout(false);
            this.m_grpRFStatusCfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSkipClockExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudSkipClockMant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGPADCNumOfSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGPADCParamVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGPADConfigVal)).EndInit();
            this.m_grpRFCharReportCfg.ResumeLayout(false);
            this.m_grpRFCharReportCfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudAeReportPeriod)).EndInit();
            this.m_grpRFCalibMonCfg.ResumeLayout(false);
            this.m_grpRFCalibMonCfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRFMonitoringId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRFCalibrationId)).EndInit();
            this.m_grpRFCalibDisableCfg.ResumeLayout(false);
            this.m_grpRFCalibDisableCfg.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimDig2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimPm2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimTx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimRx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimDig1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimPm1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimTx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimRx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimTemp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTrimTemp1)).EndInit();
            this.f000223.ResumeLayout(false);
            this.f000223.PerformLayout();
            this.m_grpMeasurePDPower.ResumeLayout(false);
            this.m_grpMeasurePDPower.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDParamVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDDACVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDINumOfSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudNumOfAccumulations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDLNAGainIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPDIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudLinearityRAMAddressProfile0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP2S1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP2S2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP2S)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP1L1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP1L2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathP1N)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMonStartTimeProfile0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMonStartTimeProfile1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMonStartTimeProfile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudReportingMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqErrorThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMonStartTimeProfile3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudLinearityRAMAddressProfile1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudLinearityRAMAddressProfile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudLinearityRAMAddressProfile3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;
		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;
		private frmAR1Main m_MainForm;
		public BpmChirpConfigParams m_BpmChirpConfigParams;
		public RFStatusConfigParams m_RFStatusConfigParams;
		public RFCharReportConfigParams m_RFCharReportConfigParams;
		public RFCalibMonConfigParams m_RFCalibMonConfigParams;
		public RFCalibEnaDisConfigParams m_RFCalibEnaDisConfigParams;
		public RfStaticCharDataConfigParams m_RfStaticCharDataConfigParams;
		public TemperatrueSensorTempDataConfigParams m_TemperatrueSensorTempDataConfigParams;
		public c000258 f000210;
		public MeasurePDPowerConfigParams m_MeasurePDPowerConfigParams;
		public MonSynthFreqLinearityConfigParams m_MonSynthFreqLinearityConfigParams;

		public string[] comboBoxRangeA = new string[]
		{
			"-11",
			"-5",
			"1",
			"7"
		};

		public string[] comboBoxRangeB = new string[]
		{
			"-21",
			"-14",
			"-7",
			"0"
		};

		private IContainer components;
		private GroupBox m_grpRFStatusCfg;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label6;
		private NumericUpDown m_nudSkipClockMant;
		private NumericUpDown m_nudGPADCNumOfSamples;
		private NumericUpDown m_nudGPADCParamVal;
		private NumericUpDown m_nudGPADConfigVal;
		private Button m_btnRFStatusCfg;
		private Label label8;
		private Label label7;
		private Label label2;
		private Label label1;
		private Label f000215;
		private Label f000216;
		private Label f000217;
		private GroupBox m_grpRFCharReportCfg;
		private Button m_btnRFCharReportCfg;
		private NumericUpDown m_nudAeReportPeriod;
		private Label label9;
		private GroupBox m_grpRFCalibMonCfg;
		private GroupBox m_grpRFCalibDisableCfg;
		private Button m_btnRFCalibMonCfg;
		private NumericUpDown m_nudRFCalibrationId;
		private Label m_lblRx3TSValue;
		private Label m_lblRx2TSValue;
		private Label label24;
		private Label label25;
		private Label m_lblRx1TSValue;
		private Label m_lblRx0TSValue;
		private Label m_lblTime;
		private Label label18;
		private Label label19;
		private Label label20;
		private Label label21;
		private Label m_lblTx2TSValue;
		private Label label29;
		private Label m_lblTx1TSValue;
		private Label m_lblTx0TSValue;
		private Label label32;
		private Label label33;
		private Label m_lblDigTSValue;
		private Label f00017e;
		private Label label36;
		private Label label37;
		private GroupBox groupBox1;
		private Label m_lblApllcalStatus;
		private Label label40;
		private Label m_lblRefClkFreq;
		private Label m_lblProcessId;
		private Label label43;
		private Label label44;
		private Label m_lblClosedLoopFreq;
		private Label label45;
		private Label label15;
		private NumericUpDown m_nudSkipClockExp;
		private NumericUpDown m_nudRFMonitoringId;
		private CheckBox m_chbCalibrationIndex;
		private CheckBox m_chbMonitorinIndex;
		private GroupBox groupBox2;
		private Label label26;
		private Label label23;
		private Label label22;
		private Label label17;
		private Label label16;
		private Label label14;
		private Label label13;
		private Label label12;
		private Label label11;
		private Label label10;
		private Label label42;
		private Label label35;
		private Label label30;
		private Button m_btnRFCTempSensorCfg;
		private NumericUpDown m_nudTrimDig2;
		private NumericUpDown m_nudTrimPm2;
		private NumericUpDown m_nudTrimTx2;
		private NumericUpDown m_nudTrimRx2;
		private NumericUpDown m_nudTrimDig1;
		private NumericUpDown m_nudTrimPm1;
		private NumericUpDown m_nudTrimTx1;
		private NumericUpDown m_nudTrimRx1;
		private NumericUpDown m_nudTrimTemp2;
		private NumericUpDown m_nudTrimTemp1;
		private CheckBox f000218;
		private CheckBox m_Synth2Cal;
		private CheckBox m_Synth1Cal;
		private CheckBox f000219;
		private Label m_Synth2Ca;
		private Label label41;
		private Label label47;
		private Label label51;
		private ImageList imageList1;
		private Button m_btnRFClibDisableCfg;
		private Label m_lblRadarDevice4ClosedLoopFreq;
		private Label m_lblRadarDevice4ApllcalStatus;
		private Label m_lblRadarDevice4RefClkFreq;
		private Label m_lblRadarDevice4ProcessId;
		private Label m_lblRadarDevice3ClosedLoopFreq;
		private Label m_lblRadarDevice3ApllcalStatus;
		private Label m_lblRadarDevice3RefClkFreq;
		private Label m_lblRadarDevice3ProcessId;
		private Label m_lblRadarDevice2ClosedLoopFreq;
		private Label m_lblRadarDevice2ApllcalStatus;
		private Label m_lblRadarDevice2RefClkFreq;
		private Label m_lblRadarDevice2ProcessId;
		private Label f00021a;
		private Label f00021b;
		private Label f00021c;
		private Label f00021d;
		private Label f00021e;
		private Label f00021f;
		private Label f000220;
		private Label f000221;
		private Label f000222;
		private Label m_lblRadarDevice4DigTSValue;
		private Label f000182;
		private Label m_lblRadarDevice4Tx2TSValue;
		private Label m_lblRadarDevice4Tx1TSValue;
		private Label m_lblRadarDevice4Tx0TSValue;
		private Label m_lblRadarDevice4Rx3TSValue;
    	private Label m_lblRadarDevice4Rx2TSValue;
		private Label m_lblRadarDevice4Rx1TSValue;
		private Label m_lblRadarDevice4Rx0TSValue;
		private Label m_lblRadarDevice4Time;
		private Label m_lblRadarDevice3DigTSValue;
		private Label f000180;
		private Label m_lblRadarDevice3Tx2TSValue;
		private Label m_lblRadarDevice3Tx1TSValue;
		private Label m_lblRadarDevice3Tx0TSValue;
		private Label m_lblRadarDevice3Rx3TSValue;
		private Label m_lblRadarDevice3Rx2TSValue;
		private Label m_lblRadarDevice3Rx1TSValue;
		private Label m_lblRadarDevice3Rx0TSValue;
		private Label m_lblRadarDevice3Time;
		private Label m_lblRadarDevice2DigTSValue;
		private Label f000184;
		private Label m_lblRadarDevice2Tx2TSValue;
		private Label m_lblRadarDevice2Tx1TSValue;
		private Label m_lblRadarDevice2Tx0TSValue;
		private Label m_lblRadarDevice2Rx3TSValue;
		private Label m_lblRadarDevice2Rx2TSValue;
		private Label m_lblRadarDevice2Rx1TSValue;
		private Label m_lblRadarDevice2Rx0TSValue;
		private Label m_lblRadarDevice2Time;
		private GroupBox f000223;
		private ComboBox m_CbPDTrimMode;
		private ComboBox f000224;
		private ComboBox f000225;
		private ComboBox m_CbPDInstance;
		private Button m_btnPDTrim1GHzSet;
		private Label label31;
		private Label label34;
		private Label label28;
		private Label label27;
		private GroupBox m_grpMeasurePDPower;
		private Button m_btnMeasurePDPowerSet;
		private Label m_lblPDPowerStatus;
		private Label m_lblPDPower;
		private Label f000226;
		private Label m_lblDeltaSum;
		private Label m_lblRadarDevice2PDPowerStatus;
		private Label m_lblRadarDevice2PDPower;
		private Label f000227;
		private Label m_lblRadarDevice2DeltaSum;
		private Label m_lblRadarDevice3PDPowerStatus;
		private Label m_lblRadarDevice3PDPower;
		private Label f000228;
		private Label m_lblRadarDevice3DeltaSum;
		private Label m_lblRadarDevice4PDPowerStatus;
		private Label m_lblRadarDevice4PDPower;
		private Label f000229;
		private Label m_lblRadarDevice4DeltaSum;
		private Label label52;
		private Label label53;
		private Label label54;
		private Label label55;
		private NumericUpDown m_nudPDINumOfSamples;
		private NumericUpDown m_nudNumOfAccumulations;
		private NumericUpDown m_nudPDLNAGainIndex;
		private NumericUpDown m_nudPDIndex;
		private Label label50;
		private Label label49;
		private Label label48;
		private Label label46;
		private Label label72;
		private Label label38;
		private Label label39;
		private Label label56;
		private Label label57;
		private Label label58;
		private Label label59;
		private Label label60;
		private NumericUpDown m_nudLinearityRAMAddressProfile0;
		private NumericUpDown m_nudDataPathP2S1;
		private NumericUpDown m_nudDataPathP2S2;
		private NumericUpDown m_nudDataPathP2S;
		private NumericUpDown m_nudDataPathP1L1;
		private NumericUpDown m_nudDataPathP1L2;
		private NumericUpDown m_nudDataPathP1N;
		private NumericUpDown m_nudMonStartTimeProfile0;
		private NumericUpDown m_nudMonStartTimeProfile1;
		private NumericUpDown m_nudMonStartTimeProfile2;
		private NumericUpDown m_nudReportingMode;
		private NumericUpDown m_nudFreqErrorThreshold;
		private Button m_btnSynthFreqLinearityMonConfigSet;
		private NumericUpDown m_nudMonStartTimeProfile3;
		private NumericUpDown m_nudLinearityRAMAddressProfile1;
		private NumericUpDown m_nudLinearityRAMAddressProfile2;
		private NumericUpDown m_nudLinearityRAMAddressProfile3;
		private Label label63;
		private GroupBox groupBox3;
		private Label label70;
		private Label label71;
		private Label label73;
		private Label label67;
		private Label label68;
		private Label label69;
		private Label label64;
		private Label label65;
		private Label label66;
		private CheckBox m_chkProfileIndex3;
		private CheckBox m_chkProfileIndex2;
		private CheckBox m_chkProfileIndex1;
		private CheckBox m_chkProfileIndex0;
		private Label label75;
		private Label label74;
		private Label label62;
		private Label label61;
		private NumericUpDown m_nudPDParamVal;
		private NumericUpDown m_nudPDDACVal;
		private NumericUpDown m_nudPDSelect;
		private ComboBox m_CbPDType;
		private Label m_lblRFSumOff;
		private Label m_lblRFSumOn;
		private Label label77;
		private Label label76;
		private Label f00018d;
		private Label label78;
		private Label f00018a;
		private Label f00018b;
		private Label f00018c;
	}
}
