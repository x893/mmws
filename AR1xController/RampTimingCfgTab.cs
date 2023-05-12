using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AR1xController.Properties;

namespace AR1xController
{
	public class RampTimingCfgTab : UserControl
	{
		public RampTimingCfgTab()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_RampTimingConfigParams = this.m_GuiManager.TsParams.RampTimingConfigParams;
			this.EnableProgFiltFor16XXARDevice();
			this.m_comDFEMode.SelectedIndex = 1;
			this.m_ChkBxForProgFiltEnable.Visible = false;
			this.m_cboRampTimeHpf1.SelectedIndex = 0;
			this.m_cboRampTimeHpf2.SelectedIndex = 0;
		}

		public void EnableProgFiltFor16XXARDevice()
		{
			if (GlobalRef.g_AR12xxDevice)
			{
				this.m_ChkBxForProgFiltEnable.Enabled = false;
				return;
			}
			if (GlobalRef.g_AR16xxDevice)
			{
				this.m_ChkBxForProgFiltEnable.Enabled = true;
			}
		}

		public bool UpdateRampTimigConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRampTimigConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RampTimingConfigParams.ADCFullRateEnable = (this.m_ChkBxForADCFullRateEnable.Checked ? 1U : 0U);
				this.m_RampTimingConfigParams.ADCHalfRateEnable = (this.m_ChkBxForADCHalfRateEnable.Checked ? 1U : 0U);
				this.m_RampTimingConfigParams.ProgFiltEnable = (this.m_ChkBxForProgFiltEnable.Checked ? 1U : 0U);
				this.m_RampTimingConfigParams.DFEMode = (uint)this.m_comDFEMode.SelectedIndex;
				this.m_RampTimingConfigParams.Slope = (float)this.m_nudSlope.Value;
				this.m_RampTimingConfigParams.ADCSamples = (uint)this.m_nudNumADCSamples.Value;
				this.m_RampTimingConfigParams.SampleRate = (uint)this.m_nudNumSampleRate.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRampTimigConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRampTimigConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_ChkBxForADCFullRateEnable.Checked = (this.m_RampTimingConfigParams.ADCFullRateEnable == 1U);
				this.m_ChkBxForADCHalfRateEnable.Checked = (this.m_RampTimingConfigParams.ADCHalfRateEnable == 1U);
				this.m_ChkBxForProgFiltEnable.Checked = (this.m_RampTimingConfigParams.ProgFiltEnable == 1U);
				this.m_comDFEMode.SelectedIndex = (int)this.m_RampTimingConfigParams.DFEMode;
				this.m_nudSlope.Value = (decimal)this.m_RampTimingConfigParams.Slope;
				this.m_nudNumADCSamples.Value = this.m_RampTimingConfigParams.ADCSamples;
				this.m_nudNumSampleRate.Value = this.m_RampTimingConfigParams.SampleRate;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public void SetRampIdleTimeInGUI(string IdleTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetRampIdleTimeInGUI);
				base.Invoke(method, new object[]
				{
					IdleTime
				});
				return;
			}
			this.m_txtIdleTime.Text = IdleTime;
		}

		public void SetTxStartTimeTimeInGUI(string TxStartTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetTxStartTimeTimeInGUI);
				base.Invoke(method, new object[]
				{
					TxStartTime
				});
			}
		}

		public void m000073(string ADCStartTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.m000073);
				base.Invoke(method, new object[]
				{
					ADCStartTime
				});
				return;
			}
			this.f000257.Text = ADCStartTime;
		}

		public void SetRampEndTimeInGUI(string RampEndTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetRampEndTimeInGUI);
				base.Invoke(method, new object[]
				{
					RampEndTime
				});
				return;
			}
			this.m_txtRampEndTime.Text = RampEndTime;
		}

		public void SetValidSweepBWInGUI(string ValidSweepBW)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetValidSweepBWInGUI);
				base.Invoke(method, new object[]
				{
					ValidSweepBW
				});
				return;
			}
			this.m_txtValidSweepBW.Text = ValidSweepBW;
		}

		public void SetTotalSweepBWInGUI(string TotalSweepBW)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetTotalSweepBWInGUI);
				base.Invoke(method, new object[]
				{
					TotalSweepBW
				});
				return;
			}
			this.m_txtTotalSweepBW.Text = TotalSweepBW;
		}

		public void SetNintyPerCentSettlingIdleTimeInGUI(string IdleTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyPerCentSettlingIdleTimeInGUI);
				base.Invoke(method, new object[]
				{
					IdleTime
				});
				return;
			}
			this.m_txtNintySettlingIdleTime.Text = IdleTime;
		}

		public void SetNintyPerCentSettlingADCStartTimeInGUI(string ADCStartTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyPerCentSettlingADCStartTimeInGUI);
				base.Invoke(method, new object[]
				{
					ADCStartTime
				});
				return;
			}
			this.m_txtNintySettlingADCStartTime.Text = ADCStartTime;
		}

		public void SetNintyPerCentSettlingRampEndTimeInGUI(string RampEndTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyPerCentSettlingRampEndTimeInGUI);
				base.Invoke(method, new object[]
				{
					RampEndTime
				});
				return;
			}
			this.m_txtNintySettlingRampEndTime.Text = RampEndTime;
		}

		public void SetNintyPerCentSettlingValidSweepBWInGUI(string ValidSweepBW)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyPerCentSettlingValidSweepBWInGUI);
				base.Invoke(method, new object[]
				{
					ValidSweepBW
				});
				return;
			}
			this.m_txtNintySettlingValidSweepBW.Text = ValidSweepBW;
		}

		public void SetNintyPerCentSettlingTotalSweepBWInGUI(string TotalSweepBW)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyPerCentSettlingTotalSweepBWInGUI);
				base.Invoke(method, new object[]
				{
					TotalSweepBW
				});
				return;
			}
			this.m_txtNintySettlingTotalSweepBW.Text = TotalSweepBW;
		}

		public void SetNintyNinePerCentSettlingIdleTimeInGUI(string IdleTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyNinePerCentSettlingIdleTimeInGUI);
				base.Invoke(method, new object[]
				{
					IdleTime
				});
				return;
			}
			this.m_txtNintyNineIdleTime.Text = IdleTime;
		}

		public void SetNintyNinePerCentSettlingADCStartTimeInGUI(string ADCStartTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyNinePerCentSettlingADCStartTimeInGUI);
				base.Invoke(method, new object[]
				{
					ADCStartTime
				});
				return;
			}
			this.f000258.Text = ADCStartTime;
		}

		public void SetNintyNinePerCentSettlingRampEndTimeInGUI(string RampEndTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyNinePerCentSettlingRampEndTimeInGUI);
				base.Invoke(method, new object[]
				{
					RampEndTime
				});
				return;
			}
			this.m_txtNintyNineRampEndTime.Text = RampEndTime;
		}

		public void SetNintyNinePerCentSettlingValidSweepBWInGUI(string ValidSweepBW)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyNinePerCentSettlingValidSweepBWInGUI);
				base.Invoke(method, new object[]
				{
					ValidSweepBW
				});
				return;
			}
			this.m_txtNintyNineSettlingValidSweepBW.Text = ValidSweepBW;
		}

		public void SetNintyNinePerCentSettlingTotalSweepBWInGUI(string TotalSweepBW)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyNinePerCentSettlingTotalSweepBWInGUI);
				base.Invoke(method, new object[]
				{
					TotalSweepBW
				});
				return;
			}
			this.m_txtNintyNineSettlingTotalSweepBW.Text = TotalSweepBW;
		}

		public void SetUserProgrammingIdleTimeInGUI(string IdleTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetUserProgrammingIdleTimeInGUI);
				base.Invoke(method, new object[]
				{
					IdleTime
				});
				return;
			}
			this.m_txtUserProgIdleTime.Text = IdleTime;
		}

		public void SetUserProgrammingADCStartTimeInGUI(string ADCStartTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetUserProgrammingADCStartTimeInGUI);
				base.Invoke(method, new object[]
				{
					ADCStartTime
				});
				return;
			}
			this.m_txtUsrProgADCStartTime.Text = ADCStartTime;
		}

		public void SetUserProgrammingRampEndTimeInGUI(string RampEndTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetUserProgrammingRampEndTimeInGUI);
				base.Invoke(method, new object[]
				{
					RampEndTime
				});
				return;
			}
			this.m_txtUsrProgRampEndTime.Text = RampEndTime;
		}

		public void SetUserProgrammingValidSweepBWInGUI(string ValidSweepBW)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetUserProgrammingValidSweepBWInGUI);
				base.Invoke(method, new object[]
				{
					ValidSweepBW
				});
				return;
			}
			this.m_txtUsrProgValidSweepBW.Text = ValidSweepBW;
		}

		public void SetUserProgrammingTotalSweepBWInGUI(string TotalSweepBW)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetUserProgrammingTotalSweepBWInGUI);
				base.Invoke(method, new object[]
				{
					TotalSweepBW
				});
				return;
			}
			this.m_txtUsrProgTotalSweepBW.Text = TotalSweepBW;
		}

		public void SetUserProgrammingInterChirpTimeInGUI(string UserInterChirpTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetUserProgrammingInterChirpTimeInGUI);
				base.Invoke(method, new object[]
				{
					UserInterChirpTime
				});
				return;
			}
			this.m_txtUserProgSettlingInterChirpTime.Text = UserInterChirpTime;
		}

		public void SetNintyPercnetSettlingInterChirpTimeInGUI(string InterChirpTime90)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyPercnetSettlingInterChirpTimeInGUI);
				base.Invoke(method, new object[]
				{
					InterChirpTime90
				});
				return;
			}
			this.m_txtNintySettlingInterChirpTime.Text = InterChirpTime90;
		}

		public void SetNintyFivePercnetSettlingInterChirpTimeInGUI(string InterChirpTime95)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyFivePercnetSettlingInterChirpTimeInGUI);
				base.Invoke(method, new object[]
				{
					InterChirpTime95
				});
				return;
			}
			this.m_txtNintyFiveSettlingInterChirpTime.Text = InterChirpTime95;
		}

		public void SetNintyNinePercnetSettlingInterChirpTimeInGUI(string InterChirpTime99)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetNintyNinePercnetSettlingInterChirpTimeInGUI);
				base.Invoke(method, new object[]
				{
					InterChirpTime99
				});
				return;
			}
			this.m_txtNintyNineSettlingInterChirpTime.Text = InterChirpTime99;
		}

		private void m_nudRampFreqSlopeConst_ValueChanged(object sender, EventArgs p1)
		{
			if (GlobalRef.g_ARDeviceOperateFreq60GHz)
			{
				double value = (double)((short)Math.Round((double)this.m_nudSlope.Value * 27.61681646090535)) * 2430000.0 / 67108864.0;
				this.m_nudSlope.Value = (decimal)Math.Round(value, 3);
				this.iLocalRampTimingConfig_Impl();
				return;
			}
			double value2 = (double)((short)Math.Round((double)this.m_nudSlope.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudSlope.Value = (decimal)Math.Round(value2, 3);
			this.iLocalRampTimingConfig_Impl();
		}

		private int iLocalRampTimingConfig_Impl()
		{
			this.m_RampTimingConfigParams.ADCFullRateEnable = (this.m_ChkBxForADCFullRateEnable.Checked ? 1U : 0U);
			this.m_RampTimingConfigParams.ADCHalfRateEnable = (this.m_ChkBxForADCHalfRateEnable.Checked ? 1U : 0U);
			this.m_RampTimingConfigParams.ProgFiltEnable = (this.m_ChkBxForProgFiltEnable.Checked ? 1U : 0U);
			this.m_RampTimingConfigParams.DFEMode = (uint)this.m_comDFEMode.SelectedIndex;
			this.m_RampTimingConfigParams.Slope = (float)this.m_nudSlope.Value;
			this.m_RampTimingConfigParams.ADCSamples = (uint)this.m_nudNumADCSamples.Value;
			this.m_RampTimingConfigParams.SampleRate = (uint)this.m_nudNumSampleRate.Value;
			this.m_RampTimingConfigParams.HPF1 = (char)this.m_cboRampTimeHpf1.SelectedIndex;
			this.m_RampTimingConfigParams.HPF2 = (char)this.m_cboRampTimeHpf2.SelectedIndex;
			int result = 0;
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = Math.Round((double)(Math.Abs(this.m_RampTimingConfigParams.Slope) * this.m_RampTimingConfigParams.ADCSamples / this.m_RampTimingConfigParams.SampleRate * 1000f), 2);
			double num7;
			if (this.m_RampTimingConfigParams.Slope < 50f)
			{
				num7 = 1.0;
			}
			else
			{
				num7 = 2.5;
			}
			uint num8;
			if (1U == this.m_RampTimingConfigParams.DFEMode)
			{
				num8 = 3U;
			}
			else
			{
				num8 = 2U;
			}
			num8 -= this.m_RampTimingConfigParams.ProgFiltEnable;
			uint num9 = this.m_RampTimingConfigParams.SampleRate * (uint)Math.Pow(2.0, num8);
			uint num10 = (uint)Math.Pow(2.0, this.m_RampTimingConfigParams.ADCHalfRateEnable);
			double num11 = 1800U / (18U * num10);
			double num12 = 1000.0 / num9;
			double num13 = Math.Log(num11 * num12, 2.0);
			uint dfenumOptDecimStages = (uint)Math.Ceiling((num13 < 0.0) ? (num13 * 0.0) : num13);
			this.m_nudNumSampleRate.ForeColor = Color.Black;
			if (this.m_RampTimingConfigParams.ADCFullRateEnable == 1U)
			{
				if (this.m_RampTimingConfigParams.DFEMode == 0U || this.m_RampTimingConfigParams.DFEMode == 3U)
				{
					if (this.m_RampTimingConfigParams.SampleRate > 50000U)
					{
						this.m_nudNumSampleRate.Value = 50000m;
						this.m_RampTimingConfigParams.SampleRate = 50000U;
						this.m_nudNumSampleRate.ForeColor = Color.Red;
					}
				}
				else if (this.m_RampTimingConfigParams.DFEMode == 1U)
				{
					if (this.m_RampTimingConfigParams.SampleRate > 25000U)
					{
						this.m_nudNumSampleRate.Value = 25000m;
						this.m_RampTimingConfigParams.SampleRate = 25000U;
						this.m_nudNumSampleRate.ForeColor = Color.Red;
					}
				}
				else if (this.m_RampTimingConfigParams.DFEMode == 2U && this.m_RampTimingConfigParams.SampleRate > 50000U)
				{
					this.m_nudNumSampleRate.Value = 50000m;
					this.m_RampTimingConfigParams.SampleRate = 50000U;
					this.m_nudNumSampleRate.ForeColor = Color.Red;
				}
			}
			if (this.m_RampTimingConfigParams.ADCHalfRateEnable == 1U)
			{
				if (this.m_RampTimingConfigParams.DFEMode == 0U || this.m_RampTimingConfigParams.DFEMode == 3U)
				{
					if (this.m_RampTimingConfigParams.SampleRate > 18750U)
					{
						this.m_nudNumSampleRate.Value = 18750m;
						this.m_RampTimingConfigParams.SampleRate = 18750U;
						this.m_nudNumSampleRate.ForeColor = Color.Red;
					}
				}
				else if (this.m_RampTimingConfigParams.DFEMode == 1U)
				{
					if (this.m_RampTimingConfigParams.SampleRate > 9375U)
					{
						this.m_nudNumSampleRate.Value = 9375m;
						this.m_RampTimingConfigParams.SampleRate = 9375U;
						this.m_nudNumSampleRate.ForeColor = Color.Red;
					}
				}
				else if (this.m_RampTimingConfigParams.DFEMode == 2U && this.m_RampTimingConfigParams.SampleRate > 18750U)
				{
					this.m_nudNumSampleRate.Value = 18750m;
					this.m_RampTimingConfigParams.SampleRate = 18750U;
					this.m_nudNumSampleRate.ForeColor = Color.Red;
				}
			}
			if (this.m_RampTimingConfigParams.HPF1 == '\0' && this.m_RampTimingConfigParams.HPF2 == '\0')
			{
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			else if (this.m_RampTimingConfigParams.HPF1 == '\0' && this.m_RampTimingConfigParams.HPF2 == '\u0001')
			{
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			else if (this.m_RampTimingConfigParams.HPF1 == '\u0001' && this.m_RampTimingConfigParams.HPF2 == '\0')
			{
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			else if (this.m_RampTimingConfigParams.HPF1 == '\u0001' && this.m_RampTimingConfigParams.HPF2 == '\u0001')
			{
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num = this.m_GuiManager.ScriptOps.m000078(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			double num14;
			if (num <= 5.0)
			{
				num14 = num;
			}
			else
			{
				num14 = 5.0;
			}
			if (this.m_RampTimingConfigParams.HPF1 == '\0' && this.m_RampTimingConfigParams.HPF2 == '\0')
			{
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			else if (this.m_RampTimingConfigParams.HPF1 == '\0' && this.m_RampTimingConfigParams.HPF2 == '\u0001')
			{
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			else if (this.m_RampTimingConfigParams.HPF1 == '\u0001' && this.m_RampTimingConfigParams.HPF2 == '\0')
			{
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			else if (this.m_RampTimingConfigParams.HPF1 == '\u0001' && this.m_RampTimingConfigParams.HPF2 == '\u0001')
			{
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num2 = this.m_GuiManager.ScriptOps.m000079(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			this.m_RampTimingConfigParams.DFEPipe = num;
			double num15 = Math.Round(num2 - num, 2);
			this.m_RampTimingConfigParams.DFELat = num2 - num;
			if (this.m_RampTimingConfigParams.HPF1 == '\0' && this.m_RampTimingConfigParams.HPF2 == '\0')
			{
				num3 = this.m_GuiManager.ScriptOps.m00007a(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num4 = this.m_GuiManager.ScriptOps.m00007b(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num5 = this.m_GuiManager.ScriptOps.m00007c(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			else if (this.m_RampTimingConfigParams.HPF1 == '\0' && this.m_RampTimingConfigParams.HPF2 == '\u0001')
			{
				num3 = this.m_GuiManager.ScriptOps.m00007d(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num4 = this.m_GuiManager.ScriptOps.m00007e(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num5 = this.m_GuiManager.ScriptOps.m00007f(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			else if (this.m_RampTimingConfigParams.HPF1 == '\u0001' && this.m_RampTimingConfigParams.HPF2 == '\0')
			{
				num3 = this.m_GuiManager.ScriptOps.m000080(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num4 = this.m_GuiManager.ScriptOps.m000081(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num5 = this.m_GuiManager.ScriptOps.m000082(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			else if (this.m_RampTimingConfigParams.HPF1 == '\u0001' && this.m_RampTimingConfigParams.HPF2 == '\u0001')
			{
				num3 = this.m_GuiManager.ScriptOps.m000083(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num4 = this.m_GuiManager.ScriptOps.m000084(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
				num5 = this.m_GuiManager.ScriptOps.m000085(this.m_RampTimingConfigParams.DFEMode, this.m_RampTimingConfigParams.ADCFullRateEnable, dfenumOptDecimStages, this.m_RampTimingConfigParams.SampleRate, this.m_RampTimingConfigParams.ProgFiltEnable);
			}
			this.m_RampTimingConfigParams.TxStartTime = num7;
			double num16 = Math.Round(num7 + num3 - num15, 2);
			double num17 = Math.Round(num7 + num4 - num15, 2);
			double num18 = Math.Round(num7 + num5 - num15, 2);
			double num19 = this.m_RampTimingConfigParams.ADCSamples / this.m_RampTimingConfigParams.SampleRate * 1000.0;
			double num20 = num16 + num19 + num2 - num14;
			double num21 = num17 + num19 + num2 - num14;
			double num22 = num18 + num19 + num2 - num14;
			num20 = Math.Round(num20, 2);
			num21 = Math.Round(num21, 2);
			num22 = Math.Round(num22, 2);
			double num23 = Math.Round((double)Math.Abs(this.m_RampTimingConfigParams.Slope) * num20, 2);
			double num24 = Math.Round((double)Math.Abs(this.m_RampTimingConfigParams.Slope) * num21, 2);
			double num25 = Math.Round((double)Math.Abs(this.m_RampTimingConfigParams.Slope) * num22, 2);
			double num26;
			if (num23 < 1000.0)
			{
				num26 = 2.0;
			}
			else if (num23 < 2000.0)
			{
				num26 = 3.5;
			}
			else if (num23 < 3000.0)
			{
				num26 = 5.0;
			}
			else
			{
				num26 = 7.0;
			}
			double num27;
			if (num24 < 1000.0)
			{
				num27 = 2.0;
			}
			else if (num24 < 2000.0)
			{
				num27 = 3.5;
			}
			else if (num24 < 3000.0)
			{
				num27 = 5.0;
			}
			else
			{
				num27 = 7.0;
			}
			double num28;
			if (num25 < 1000.0)
			{
				num28 = 2.0;
			}
			else if (num25 < 2000.0)
			{
				num28 = 3.5;
			}
			else if (num25 < 3000.0)
			{
				num28 = 5.0;
			}
			else
			{
				num28 = 7.0;
			}
			double num29;
			if (num26 > num14)
			{
				num29 = num26;
				num29 = Math.Round(num29, 2);
			}
			else
			{
				num29 = num14;
				num29 = Math.Round(num29, 2);
			}
			double num30;
			if (num27 > num14)
			{
				num30 = num27;
				num30 = Math.Round(num30, 2);
			}
			else
			{
				num30 = num14;
				num30 = Math.Round(num30, 2);
			}
			double num31;
			if (num28 > num14)
			{
				num31 = num28;
				num31 = Math.Round(num31, 2);
			}
			else
			{
				num31 = num14;
				num31 = Math.Round(num31, 2);
			}
			this.m_RampTimingConfigParams.Tsynth_rampdown = num27;
			this.m_RampTimingConfigParams.TpipeCapped = num14;
			double value = num15 + num31 + num18;
			double value2 = num15 + num30 + num17;
			double value3 = num15 + num29 + num16;
			this.SetUserProgrammingInterChirpTimeInGUI(Convert.ToString(value2));
			this.SetNintyPercnetSettlingInterChirpTimeInGUI(Convert.ToString(value));
			this.SetNintyFivePercnetSettlingInterChirpTimeInGUI(Convert.ToString(value2));
			this.SetNintyNinePercnetSettlingInterChirpTimeInGUI(Convert.ToString(value3));
			this.SetNintyNinePerCentSettlingIdleTimeInGUI(Convert.ToString(num29));
			this.SetNintyNinePerCentSettlingADCStartTimeInGUI(Convert.ToString(num16));
			this.SetNintyNinePerCentSettlingRampEndTimeInGUI(Convert.ToString(num20));
			this.SetNintyNinePerCentSettlingValidSweepBWInGUI(Convert.ToString(num6));
			this.SetNintyNinePerCentSettlingTotalSweepBWInGUI(Convert.ToString(num23));
			if (num23 > 4000.0)
			{
				this.m_txtNintyNineSettlingTotalSweepBW.BackColor = Color.Pink;
				this.m_txtNintyNineSettlingTotalSweepBW.Text = Convert.ToString(num23);
			}
			else
			{
				this.m_txtNintyNineSettlingTotalSweepBW.Text = Convert.ToString(num23);
				this.m_txtNintyNineSettlingTotalSweepBW.BackColor = Color.LightGray;
			}
			this.SetRampIdleTimeInGUI(Convert.ToString(num30));
			this.m000073(Convert.ToString(num17));
			this.SetRampEndTimeInGUI(Convert.ToString(num21));
			this.SetValidSweepBWInGUI(Convert.ToString(num6));
			this.SetTotalSweepBWInGUI(Convert.ToString(num24));
			if (num24 > 4000.0)
			{
				this.m_txtTotalSweepBW.BackColor = Color.Pink;
				this.m_txtTotalSweepBW.Text = Convert.ToString(num24);
			}
			else
			{
				this.m_txtTotalSweepBW.Text = Convert.ToString(num24);
				this.m_txtTotalSweepBW.BackColor = Color.LightGray;
			}
			this.SetNintyPerCentSettlingIdleTimeInGUI(Convert.ToString(num31));
			this.SetNintyPerCentSettlingADCStartTimeInGUI(Convert.ToString(num18));
			this.SetNintyPerCentSettlingRampEndTimeInGUI(Convert.ToString(num22));
			this.SetNintyPerCentSettlingValidSweepBWInGUI(Convert.ToString(num6));
			this.SetNintyPerCentSettlingTotalSweepBWInGUI(Convert.ToString(num25));
			if (num25 > 4000.0)
			{
				this.m_txtNintySettlingTotalSweepBW.BackColor = Color.Pink;
				this.m_txtNintySettlingTotalSweepBW.Text = Convert.ToString(num25);
			}
			else
			{
				this.m_txtNintySettlingTotalSweepBW.Text = Convert.ToString(num25);
				this.m_txtNintySettlingTotalSweepBW.BackColor = Color.LightGray;
			}
			this.m_RampTimingConfigParams.ADCStartTime95 = num17;
			this.m_RampTimingConfigParams.IdleTime95 = num30;
			this.m_RampTimingConfigParams.RampEndTime95 = num21;
			this.SetUserProgrammingIdleTimeInGUI(Convert.ToString(num30));
			this.SetUserProgrammingADCStartTimeInGUI(Convert.ToString(num17));
			this.SetUserProgrammingRampEndTimeInGUI(Convert.ToString(num21));
			this.SetUserProgrammingValidSweepBWInGUI(Convert.ToString(num6));
			this.SetUserProgrammingTotalSweepBWInGUI(Convert.ToString(num24));
			if (num24 > 4000.0)
			{
				this.m_txtUsrProgTotalSweepBW.BackColor = Color.Pink;
				this.m_txtUsrProgTotalSweepBW.Text = Convert.ToString(num24);
			}
			else
			{
				this.m_txtUsrProgTotalSweepBW.Text = Convert.ToString(num24);
				this.m_txtUsrProgTotalSweepBW.BackColor = Color.LightGray;
			}
			if (num6 > 4000.0)
			{
				this.m_txtUsrProgValidSweepBW.BackColor = Color.Pink;
				this.m_txtUsrProgValidSweepBW.Text = Convert.ToString(num6);
				this.m_txtNintySettlingValidSweepBW.BackColor = Color.Pink;
				this.m_txtNintySettlingValidSweepBW.Text = Convert.ToString(num6);
				this.m_txtValidSweepBW.BackColor = Color.Pink;
				this.m_txtValidSweepBW.Text = Convert.ToString(num6);
				this.m_txtNintyNineSettlingValidSweepBW.BackColor = Color.Pink;
				this.m_txtNintyNineSettlingValidSweepBW.Text = Convert.ToString(num6);
				return result;
			}
			this.m_txtUsrProgValidSweepBW.Text = Convert.ToString(num6);
			this.m_txtUsrProgValidSweepBW.BackColor = Color.LightGray;
			this.m_txtNintySettlingValidSweepBW.Text = Convert.ToString(num6);
			this.m_txtNintySettlingValidSweepBW.BackColor = Color.LightGray;
			this.m_txtValidSweepBW.Text = Convert.ToString(num6);
			this.m_txtValidSweepBW.BackColor = Color.LightGray;
			this.m_txtNintyNineSettlingValidSweepBW.Text = Convert.ToString(num6);
			this.m_txtNintyNineSettlingValidSweepBW.BackColor = Color.LightGray;
			return result;
		}

		private void m_nudRampADCSamples_ValueChanged(object sender, EventArgs p1)
		{
			this.iLocalRampTimingConfig_Impl();
		}

		private void m_nudRampSampleRate_ValueChanged(object sender, EventArgs p1)
		{
			this.iLocalRampTimingConfig_Impl();
		}

		private void m_nudRampDFEMode_ValueChanged(object sender, EventArgs p1)
		{
			this.iLocalRampTimingConfig_Impl();
		}

		private void m_nudRampProgFiltEnable_ValueChanged(object sender, EventArgs p1)
		{
			this.iLocalRampTimingConfig_Impl();
		}

		private void m_nudRampADCFullRateMode_ValueChanged(object sender, EventArgs p1)
		{
			this.iLocalRampTimingConfig_Impl();
		}

		private void m_nudRampADCHalfRateMode_ValueChanged(object sender, EventArgs p1)
		{
			this.iLocalRampTimingConfig_Impl();
		}

		public void SetMaximumSampleRateInGUI(string MaxSampleRate)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetMaximumSampleRateInGUI);
				base.Invoke(method, new object[]
				{
					MaxSampleRate
				});
			}
		}

		private void m_nudADCStartTime_ValueChanged(object sender, EventArgs p1)
		{
			double num = this.m_RampTimingConfigParams.SampleRate;
			double num2 = this.m_RampTimingConfigParams.ADCSamples / (num / 1000.0);
			double num3 = Convert.ToDouble(this.m_txtUsrProgADCStartTime.Value);
			this.m_txtUsrProgRampEndTime.Value = Convert.ToDecimal(Math.Round(num3 + num2 + this.m_RampTimingConfigParams.DFELat, 2));
			double num4 = Math.Round((double)Math.Abs(this.m_RampTimingConfigParams.Slope) * Convert.ToDouble(this.m_txtUsrProgRampEndTime.Value), 2);
			double num5 = Convert.ToDouble(this.m_txtUserProgIdleTime.Text);
			double value = this.m_RampTimingConfigParams.DFELat + num3 + num5;
			this.m_txtUserProgSettlingInterChirpTime.Text = Convert.ToString(value);
			if (num4 > 4000.0)
			{
				this.m_txtUsrProgTotalSweepBW.Text = Convert.ToString(num4);
				this.m_txtUsrProgTotalSweepBW.BackColor = Color.Pink;
				return;
			}
			this.m_txtUsrProgTotalSweepBW.Text = Convert.ToString(num4);
			this.m_txtUsrProgTotalSweepBW.BackColor = Color.LightGray;
		}

		private void m_nudRampEndTime_ValueChanged(object sender, EventArgs p1)
		{
			double num = this.m_RampTimingConfigParams.SampleRate;
			double num2 = this.m_RampTimingConfigParams.ADCSamples / (num / 1000.0);
			double num3 = 5000.0;
			string empty = string.Empty;
			double num4 = Convert.ToDouble(this.m_txtUsrProgADCStartTime.Value);
			double num5 = num4 + num2;
			this.m_txtUsrProgRampEndTime.ForeColor = Color.Black;
			if (Convert.ToDouble(this.m_txtUsrProgRampEndTime.Value) < num5 || Convert.ToDouble(this.m_txtUsrProgRampEndTime.Value) > num3)
			{
				string.Format("RampEndTime minimum is {0} ms\n", new object[]
				{
					num5
				});
				string.Format("RampEndTime maximum is {0} ms \n", new object[]
				{
					num3
				});
				this.m_txtUsrProgRampEndTime.Value = Convert.ToDecimal(num5);
				this.m_txtUsrProgRampEndTime.ForeColor = Color.Red;
			}
			double num6 = Convert.ToDouble(this.m_txtUsrProgRampEndTime.Value);
			double num7 = num4 + num2 + this.m_RampTimingConfigParams.DFELat;
			if (num6 < num7)
			{
				this.m_txtUserProgIdleTime.Text = Convert.ToString(Math.Round(this.m_RampTimingConfigParams.IdleTime95 + num7 - num6, 2));
			}
			else if (this.m_RampTimingConfigParams.TpipeCapped > this.m_RampTimingConfigParams.Tsynth_rampdown)
			{
				double tsynth_rampdown = this.m_RampTimingConfigParams.Tsynth_rampdown;
				double num8 = this.m_RampTimingConfigParams.TpipeCapped - (num6 - num7);
				if (num8 < tsynth_rampdown)
				{
					num8 = tsynth_rampdown;
				}
				this.m_txtUserProgIdleTime.Text = Convert.ToString(Math.Round(num8, 2));
			}
			else
			{
				this.m_txtUserProgIdleTime.Text = Convert.ToString(Math.Round(this.m_RampTimingConfigParams.IdleTime95, 2));
			}
			double num9 = Math.Round((double)Math.Abs(this.m_RampTimingConfigParams.Slope) * Convert.ToDouble(this.m_txtUsrProgRampEndTime.Value), 2);
			double num10 = Convert.ToDouble(this.m_txtUserProgIdleTime.Text);
			double value = this.m_RampTimingConfigParams.DFELat + num4 + num10;
			this.m_txtUserProgSettlingInterChirpTime.Text = Convert.ToString(value);
			if (num9 > 4000.0)
			{
				this.m_txtUsrProgTotalSweepBW.BackColor = Color.Pink;
				this.m_txtUsrProgTotalSweepBW.Text = Convert.ToString(num9);
				return;
			}
			this.m_txtUsrProgTotalSweepBW.Text = Convert.ToString(num9);
			this.m_txtUsrProgTotalSweepBW.BackColor = Color.LightGray;
		}

		private void m_CombBoxHPF1CornerFreq_SelectiveChanged(object sender, EventArgs p1)
		{
			this.iLocalRampTimingConfig_Impl();
		}

		private void m_CombBoxHPF2CornerFreq_SelectiveChanged(object sender, EventArgs p1)
		{
			this.iLocalRampTimingConfig_Impl();
		}

		public void DisplayErrorRampleRateInCurrentDFEModeInGUI(string IdleTime)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.DisplayErrorRampleRateInCurrentDFEModeInGUI);
				base.Invoke(method, new object[]
				{
					IdleTime
				});
				return;
			}
			this.m_txtNintySettlingIdleTime.Text = "Error";
			this.m_txtNintySettlingADCStartTime.Text = "Error";
			this.m_txtNintySettlingRampEndTime.Text = "Error";
			this.m_txtNintySettlingValidSweepBW.Text = "Error";
			this.m_txtNintySettlingTotalSweepBW.Text = "Error";
			this.m_txtIdleTime.Text = "Error";
			this.f000257.Text = "Error";
			this.m_txtRampEndTime.Text = "Error";
			this.m_txtValidSweepBW.Text = "Error";
			this.m_txtTotalSweepBW.Text = "Error";
			this.m_txtNintyNineIdleTime.Text = "Error";
			this.f000258.Text = "Error";
			this.m_txtNintyNineRampEndTime.Text = "Error";
			this.m_txtNintyNineSettlingValidSweepBW.Text = "Error";
			this.m_txtNintyNineSettlingTotalSweepBW.Text = "Error";
			this.m_txtUserProgIdleTime.Text = "Error";
			this.m_txtUsrProgRampEndTime.Value = 0m;
			this.m_txtUsrProgADCStartTime.Value = 0m;
			this.m_txtUsrProgValidSweepBW.Text = "Error";
			this.m_txtUsrProgTotalSweepBW.Text = "Error";
		}

		private void groupBox1_Enter(object sender, EventArgs p1)
		{
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RampTimingCfgTab));
			this.m_grpRampTimingCfg = new GroupBox();
			this.pictureBox1 = new PictureBox();
			this.textBox1 = new TextBox();
			this.groupBox2 = new GroupBox();
			this.m_txtUserProgSettlingInterChirpTime = new TextBox();
			this.m_txtNintyNineSettlingInterChirpTime = new TextBox();
			this.m_txtNintyFiveSettlingInterChirpTime = new TextBox();
			this.m_txtNintySettlingInterChirpTime = new TextBox();
			this.label11 = new Label();
			this.m_txtUsrProgADCStartTime = new NumericUpDown();
			this.m_txtUsrProgRampEndTime = new NumericUpDown();
			this.m_txtNintySettlingTotalSweepBW = new TextBox();
			this.m_txtNintySettlingValidSweepBW = new TextBox();
			this.m_txtNintySettlingRampEndTime = new TextBox();
			this.m_txtNintySettlingADCStartTime = new TextBox();
			this.m_txtNintySettlingIdleTime = new TextBox();
			this.label16 = new Label();
			this.m_txtUsrProgTotalSweepBW = new TextBox();
			this.m_txtUsrProgValidSweepBW = new TextBox();
			this.m_txtNintyNineSettlingTotalSweepBW = new TextBox();
			this.m_txtNintyNineSettlingValidSweepBW = new TextBox();
			this.m_txtValidSweepBW = new TextBox();
			this.m_txtTotalSweepBW = new TextBox();
			this.label9 = new Label();
			this.label10 = new Label();
			this.m_txtUserProgIdleTime = new TextBox();
			this.m_txtNintyNineRampEndTime = new TextBox();
			this.f000258 = new TextBox();
			this.m_txtNintyNineIdleTime = new TextBox();
			this.label13 = new Label();
			this.label12 = new Label();
			this.label6 = new Label();
			this.m_txtRampEndTime = new TextBox();
			this.f000257 = new TextBox();
			this.m_txtIdleTime = new TextBox();
			this.label8 = new Label();
			this.label7 = new Label();
			this.label5 = new Label();
			this.groupBox1 = new GroupBox();
			this.label15 = new Label();
			this.label14 = new Label();
			this.m_cboRampTimeHpf2 = new ComboBox();
			this.m_cboRampTimeHpf1 = new ComboBox();
			this.m_ChkBxForADCHalfRateEnable = new RadioButton();
			this.m_ChkBxForADCFullRateEnable = new RadioButton();
			this.m_nudNumSampleRate = new NumericUpDown();
			this.m_nudNumADCSamples = new NumericUpDown();
			this.m_nudSlope = new NumericUpDown();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.m_comDFEMode = new ComboBox();
			this.m_ChkBxForProgFiltEnable = new CheckBox();
			this.m_grpRampTimingCfg.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.m_txtUsrProgADCStartTime).BeginInit();
			((ISupportInitialize)this.m_txtUsrProgRampEndTime).BeginInit();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.m_nudNumSampleRate).BeginInit();
			((ISupportInitialize)this.m_nudNumADCSamples).BeginInit();
			((ISupportInitialize)this.m_nudSlope).BeginInit();
			base.SuspendLayout();
			this.m_grpRampTimingCfg.Controls.Add(this.pictureBox1);
			this.m_grpRampTimingCfg.Controls.Add(this.textBox1);
			this.m_grpRampTimingCfg.Controls.Add(this.groupBox2);
			this.m_grpRampTimingCfg.Controls.Add(this.groupBox1);
			this.m_grpRampTimingCfg.Location = new Point(16, 4);
			this.m_grpRampTimingCfg.Margin = new Padding(4, 4, 4, 4);
			this.m_grpRampTimingCfg.Name = "m_grpRampTimingCfg";
			this.m_grpRampTimingCfg.Padding = new Padding(4, 4, 4, 4);
			this.m_grpRampTimingCfg.Size = new Size(1213, 764);
			this.m_grpRampTimingCfg.TabIndex = 0;
			this.m_grpRampTimingCfg.TabStop = false;
			this.m_grpRampTimingCfg.Text = "Ramp Timing Calculator";
			this.pictureBox1.Image = Resources.RampGenTiming;
			this.pictureBox1.Location = new Point(259, 353);
			this.pictureBox1.Margin = new Padding(4, 4, 4, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(765, 347);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			this.textBox1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.textBox1.Location = new Point(23, 20);
			this.textBox1.Margin = new Padding(4, 4, 4, 4);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new Size(1176, 62);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = componentResourceManager.GetString("textBox1.Text");
			this.groupBox2.Controls.Add(this.m_txtUserProgSettlingInterChirpTime);
			this.groupBox2.Controls.Add(this.m_txtNintyNineSettlingInterChirpTime);
			this.groupBox2.Controls.Add(this.m_txtNintyFiveSettlingInterChirpTime);
			this.groupBox2.Controls.Add(this.m_txtNintySettlingInterChirpTime);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.m_txtUsrProgADCStartTime);
			this.groupBox2.Controls.Add(this.m_txtUsrProgRampEndTime);
			this.groupBox2.Controls.Add(this.m_txtNintySettlingTotalSweepBW);
			this.groupBox2.Controls.Add(this.m_txtNintySettlingValidSweepBW);
			this.groupBox2.Controls.Add(this.m_txtNintySettlingRampEndTime);
			this.groupBox2.Controls.Add(this.m_txtNintySettlingADCStartTime);
			this.groupBox2.Controls.Add(this.m_txtNintySettlingIdleTime);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.m_txtUsrProgTotalSweepBW);
			this.groupBox2.Controls.Add(this.m_txtUsrProgValidSweepBW);
			this.groupBox2.Controls.Add(this.m_txtNintyNineSettlingTotalSweepBW);
			this.groupBox2.Controls.Add(this.m_txtNintyNineSettlingValidSweepBW);
			this.groupBox2.Controls.Add(this.m_txtValidSweepBW);
			this.groupBox2.Controls.Add(this.m_txtTotalSweepBW);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.m_txtUserProgIdleTime);
			this.groupBox2.Controls.Add(this.m_txtNintyNineRampEndTime);
			this.groupBox2.Controls.Add(this.f000258);
			this.groupBox2.Controls.Add(this.m_txtNintyNineIdleTime);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.m_txtRampEndTime);
			this.groupBox2.Controls.Add(this.f000257);
			this.groupBox2.Controls.Add(this.m_txtIdleTime);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox2.Location = new Point(617, 82);
			this.groupBox2.Margin = new Padding(4, 4, 4, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new Padding(4, 4, 4, 4);
			this.groupBox2.Size = new Size(583, 262);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Recommended Configuration";
			this.m_txtUserProgSettlingInterChirpTime.Location = new Point(484, 228);
			this.m_txtUserProgSettlingInterChirpTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtUserProgSettlingInterChirpTime.Name = "m_txtUserProgSettlingInterChirpTime";
			this.m_txtUserProgSettlingInterChirpTime.ReadOnly = true;
			this.m_txtUserProgSettlingInterChirpTime.Size = new Size(84, 25);
			this.m_txtUserProgSettlingInterChirpTime.TabIndex = 37;
			this.m_txtNintyNineSettlingInterChirpTime.Location = new Point(384, 228);
			this.m_txtNintyNineSettlingInterChirpTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintyNineSettlingInterChirpTime.Name = "m_txtNintyNineSettlingInterChirpTime";
			this.m_txtNintyNineSettlingInterChirpTime.ReadOnly = true;
			this.m_txtNintyNineSettlingInterChirpTime.Size = new Size(84, 25);
			this.m_txtNintyNineSettlingInterChirpTime.TabIndex = 36;
			this.m_txtNintyFiveSettlingInterChirpTime.Location = new Point(284, 228);
			this.m_txtNintyFiveSettlingInterChirpTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintyFiveSettlingInterChirpTime.Name = "m_txtNintyFiveSettlingInterChirpTime";
			this.m_txtNintyFiveSettlingInterChirpTime.ReadOnly = true;
			this.m_txtNintyFiveSettlingInterChirpTime.Size = new Size(84, 25);
			this.m_txtNintyFiveSettlingInterChirpTime.TabIndex = 35;
			this.m_txtNintySettlingInterChirpTime.Location = new Point(183, 228);
			this.m_txtNintySettlingInterChirpTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintySettlingInterChirpTime.Name = "m_txtNintySettlingInterChirpTime";
			this.m_txtNintySettlingInterChirpTime.ReadOnly = true;
			this.m_txtNintySettlingInterChirpTime.Size = new Size(84, 25);
			this.m_txtNintySettlingInterChirpTime.TabIndex = 34;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(11, 229);
			this.label11.Margin = new Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new Size(141, 17);
			this.label11.TabIndex = 33;
			this.label11.Text = "Inter Chirp Time (µs)";
			this.m_txtUsrProgADCStartTime.DecimalPlaces = 2;
			this.m_txtUsrProgADCStartTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_txtUsrProgADCStartTime.Location = new Point(487, 80);
			this.m_txtUsrProgADCStartTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtUsrProgADCStartTime.Maximum = new decimal(new int[]
			{
				4095,
				0,
				0,
				131072
			});
			this.m_txtUsrProgADCStartTime.Name = "m_txtUsrProgADCStartTime";
			this.m_txtUsrProgADCStartTime.Size = new Size(84, 25);
			this.m_txtUsrProgADCStartTime.TabIndex = 32;
			this.m_txtUsrProgADCStartTime.ValueChanged += this.m_nudADCStartTime_ValueChanged;
			this.m_txtUsrProgRampEndTime.DecimalPlaces = 2;
			this.m_txtUsrProgRampEndTime.ForeColor = Color.Red;
			this.m_txtUsrProgRampEndTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_txtUsrProgRampEndTime.Location = new Point(487, 117);
			this.m_txtUsrProgRampEndTime.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown txtUsrProgRampEndTime = this.m_txtUsrProgRampEndTime;
			int[] array = new int[4];
			array[0] = 5000;
			txtUsrProgRampEndTime.Maximum = new decimal(array);
			this.m_txtUsrProgRampEndTime.Name = "m_txtUsrProgRampEndTime";
			this.m_txtUsrProgRampEndTime.Size = new Size(84, 25);
			this.m_txtUsrProgRampEndTime.TabIndex = 31;
			this.m_txtUsrProgRampEndTime.ValueChanged += this.m_nudRampEndTime_ValueChanged;
			this.m_txtNintySettlingTotalSweepBW.Location = new Point(183, 191);
			this.m_txtNintySettlingTotalSweepBW.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintySettlingTotalSweepBW.Name = "m_txtNintySettlingTotalSweepBW";
			this.m_txtNintySettlingTotalSweepBW.ReadOnly = true;
			this.m_txtNintySettlingTotalSweepBW.Size = new Size(84, 25);
			this.m_txtNintySettlingTotalSweepBW.TabIndex = 30;
			this.m_txtNintySettlingValidSweepBW.Location = new Point(183, 154);
			this.m_txtNintySettlingValidSweepBW.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintySettlingValidSweepBW.Name = "m_txtNintySettlingValidSweepBW";
			this.m_txtNintySettlingValidSweepBW.ReadOnly = true;
			this.m_txtNintySettlingValidSweepBW.Size = new Size(84, 25);
			this.m_txtNintySettlingValidSweepBW.TabIndex = 29;
			this.m_txtNintySettlingRampEndTime.Location = new Point(183, 117);
			this.m_txtNintySettlingRampEndTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintySettlingRampEndTime.Name = "m_txtNintySettlingRampEndTime";
			this.m_txtNintySettlingRampEndTime.ReadOnly = true;
			this.m_txtNintySettlingRampEndTime.Size = new Size(84, 25);
			this.m_txtNintySettlingRampEndTime.TabIndex = 28;
			this.m_txtNintySettlingADCStartTime.Location = new Point(183, 80);
			this.m_txtNintySettlingADCStartTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintySettlingADCStartTime.Name = "m_txtNintySettlingADCStartTime";
			this.m_txtNintySettlingADCStartTime.ReadOnly = true;
			this.m_txtNintySettlingADCStartTime.Size = new Size(84, 25);
			this.m_txtNintySettlingADCStartTime.TabIndex = 27;
			this.m_txtNintySettlingIdleTime.Location = new Point(183, 43);
			this.m_txtNintySettlingIdleTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintySettlingIdleTime.Name = "m_txtNintySettlingIdleTime";
			this.m_txtNintySettlingIdleTime.ReadOnly = true;
			this.m_txtNintySettlingIdleTime.Size = new Size(84, 25);
			this.m_txtNintySettlingIdleTime.TabIndex = 26;
			this.label16.AutoSize = true;
			this.label16.Location = new Point(179, 22);
			this.label16.Margin = new Padding(4, 0, 4, 0);
			this.label16.Name = "label16";
			this.label16.Size = new Size(89, 17);
			this.label16.TabIndex = 25;
			this.label16.Text = "90% Settling";
			this.m_txtUsrProgTotalSweepBW.ForeColor = SystemColors.WindowText;
			this.m_txtUsrProgTotalSweepBW.Location = new Point(484, 191);
			this.m_txtUsrProgTotalSweepBW.Margin = new Padding(4, 4, 4, 4);
			this.m_txtUsrProgTotalSweepBW.Name = "m_txtUsrProgTotalSweepBW";
			this.m_txtUsrProgTotalSweepBW.ReadOnly = true;
			this.m_txtUsrProgTotalSweepBW.Size = new Size(84, 25);
			this.m_txtUsrProgTotalSweepBW.TabIndex = 24;
			this.m_txtUsrProgValidSweepBW.Location = new Point(484, 154);
			this.m_txtUsrProgValidSweepBW.Margin = new Padding(4, 4, 4, 4);
			this.m_txtUsrProgValidSweepBW.Name = "m_txtUsrProgValidSweepBW";
			this.m_txtUsrProgValidSweepBW.ReadOnly = true;
			this.m_txtUsrProgValidSweepBW.Size = new Size(84, 25);
			this.m_txtUsrProgValidSweepBW.TabIndex = 23;
			this.m_txtNintyNineSettlingTotalSweepBW.Location = new Point(384, 191);
			this.m_txtNintyNineSettlingTotalSweepBW.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintyNineSettlingTotalSweepBW.Name = "m_txtNintyNineSettlingTotalSweepBW";
			this.m_txtNintyNineSettlingTotalSweepBW.ReadOnly = true;
			this.m_txtNintyNineSettlingTotalSweepBW.Size = new Size(84, 25);
			this.m_txtNintyNineSettlingTotalSweepBW.TabIndex = 22;
			this.m_txtNintyNineSettlingValidSweepBW.Location = new Point(384, 154);
			this.m_txtNintyNineSettlingValidSweepBW.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintyNineSettlingValidSweepBW.Name = "m_txtNintyNineSettlingValidSweepBW";
			this.m_txtNintyNineSettlingValidSweepBW.ReadOnly = true;
			this.m_txtNintyNineSettlingValidSweepBW.Size = new Size(84, 25);
			this.m_txtNintyNineSettlingValidSweepBW.TabIndex = 21;
			this.m_txtValidSweepBW.Location = new Point(284, 154);
			this.m_txtValidSweepBW.Margin = new Padding(4, 4, 4, 4);
			this.m_txtValidSweepBW.Name = "m_txtValidSweepBW";
			this.m_txtValidSweepBW.ReadOnly = true;
			this.m_txtValidSweepBW.Size = new Size(84, 25);
			this.m_txtValidSweepBW.TabIndex = 14;
			this.m_txtTotalSweepBW.Location = new Point(284, 191);
			this.m_txtTotalSweepBW.Margin = new Padding(4, 4, 4, 4);
			this.m_txtTotalSweepBW.Name = "m_txtTotalSweepBW";
			this.m_txtTotalSweepBW.ReadOnly = true;
			this.m_txtTotalSweepBW.Size = new Size(84, 25);
			this.m_txtTotalSweepBW.TabIndex = 15;
			this.label9.AutoSize = true;
			this.label9.Location = new Point(11, 159);
			this.label9.Margin = new Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new Size(159, 17);
			this.label9.TabIndex = 12;
			this.label9.Text = "Valid Sweep BW (MHz)";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(11, 194);
			this.label10.Margin = new Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new Size(159, 17);
			this.label10.TabIndex = 13;
			this.label10.Text = "Total Sweep BW (MHz)";
			this.m_txtUserProgIdleTime.Location = new Point(484, 43);
			this.m_txtUserProgIdleTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtUserProgIdleTime.Name = "m_txtUserProgIdleTime";
			this.m_txtUserProgIdleTime.ReadOnly = true;
			this.m_txtUserProgIdleTime.Size = new Size(84, 25);
			this.m_txtUserProgIdleTime.TabIndex = 18;
			this.m_txtNintyNineRampEndTime.Location = new Point(384, 117);
			this.m_txtNintyNineRampEndTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintyNineRampEndTime.Name = "m_txtNintyNineRampEndTime";
			this.m_txtNintyNineRampEndTime.ReadOnly = true;
			this.m_txtNintyNineRampEndTime.Size = new Size(84, 25);
			this.m_txtNintyNineRampEndTime.TabIndex = 17;
			this.f000258.Location = new Point(384, 80);
			this.f000258.Margin = new Padding(4, 4, 4, 4);
			this.f000258.Name = "m_txtNintyNineIADCStartTime";
			this.f000258.ReadOnly = true;
			this.f000258.Size = new Size(84, 25);
			this.f000258.TabIndex = 16;
			this.m_txtNintyNineIdleTime.Location = new Point(384, 43);
			this.m_txtNintyNineIdleTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtNintyNineIdleTime.Name = "m_txtNintyNineIdleTime";
			this.m_txtNintyNineIdleTime.ReadOnly = true;
			this.m_txtNintyNineIdleTime.Size = new Size(84, 25);
			this.m_txtNintyNineIdleTime.TabIndex = 15;
			this.label13.AutoSize = true;
			this.label13.Location = new Point(483, 22);
			this.label13.Margin = new Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new Size(74, 17);
			this.label13.TabIndex = 14;
			this.label13.Text = "User Prog";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(380, 22);
			this.label12.Margin = new Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new Size(89, 17);
			this.label12.TabIndex = 13;
			this.label12.Text = "99% Settling";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(277, 22);
			this.label6.Margin = new Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new Size(89, 17);
			this.label6.TabIndex = 12;
			this.label6.Text = "95% Settling";
			this.m_txtRampEndTime.Location = new Point(284, 117);
			this.m_txtRampEndTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtRampEndTime.Name = "m_txtRampEndTime";
			this.m_txtRampEndTime.ReadOnly = true;
			this.m_txtRampEndTime.Size = new Size(84, 25);
			this.m_txtRampEndTime.TabIndex = 11;
			this.f000257.Location = new Point(284, 80);
			this.f000257.Margin = new Padding(4, 4, 4, 4);
			this.f000257.Name = "m_txtIADCStartTime";
			this.f000257.ReadOnly = true;
			this.f000257.Size = new Size(84, 25);
			this.f000257.TabIndex = 10;
			this.m_txtIdleTime.Location = new Point(284, 43);
			this.m_txtIdleTime.Margin = new Padding(4, 4, 4, 4);
			this.m_txtIdleTime.Multiline = true;
			this.m_txtIdleTime.Name = "m_txtIdleTime";
			this.m_txtIdleTime.ReadOnly = true;
			this.m_txtIdleTime.Size = new Size(84, 25);
			this.m_txtIdleTime.TabIndex = 8;
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label8.Location = new Point(11, 117);
			this.label8.Margin = new Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(144, 17);
			this.label8.TabIndex = 3;
			this.label8.Text = "Ramp End Time (µs)";
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(11, 80);
			this.label7.Margin = new Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(140, 17);
			this.label7.TabIndex = 2;
			this.label7.Text = "ADC Start Time (µs)";
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(11, 43);
			this.label5.Margin = new Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(100, 17);
			this.label5.TabIndex = 0;
			this.label5.Text = "Idle Time  (µs)";
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.m_cboRampTimeHpf2);
			this.groupBox1.Controls.Add(this.m_cboRampTimeHpf1);
			this.groupBox1.Controls.Add(this.m_ChkBxForADCHalfRateEnable);
			this.groupBox1.Controls.Add(this.m_ChkBxForADCFullRateEnable);
			this.groupBox1.Controls.Add(this.m_nudNumSampleRate);
			this.groupBox1.Controls.Add(this.m_nudNumADCSamples);
			this.groupBox1.Controls.Add(this.m_nudSlope);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.m_comDFEMode);
			this.groupBox1.Controls.Add(this.m_ChkBxForProgFiltEnable);
			this.groupBox1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(23, 82);
			this.groupBox1.Margin = new Padding(4, 4, 4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new Padding(4, 4, 4, 4);
			this.groupBox1.Size = new Size(587, 239);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ramp Timing Inputs";
			this.groupBox1.Enter += this.groupBox1_Enter;
			this.label15.AutoSize = true;
			this.label15.Location = new Point(313, 121);
			this.label15.Margin = new Padding(4, 0, 4, 0);
			this.label15.Name = "label15";
			this.label15.Size = new Size(128, 17);
			this.label15.TabIndex = 7;
			this.label15.Text = "HPF2 Corner Freq";
			this.label14.AutoSize = true;
			this.label14.Location = new Point(313, 80);
			this.label14.Margin = new Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new Size(128, 17);
			this.label14.TabIndex = 6;
			this.label14.Text = "HPF1 Corner Freq";
			this.m_cboRampTimeHpf2.DropDownStyle = ComboBoxStyle.DropDownList;
			this.m_cboRampTimeHpf2.FormattingEnabled = true;
			this.m_cboRampTimeHpf2.Items.AddRange(new object[]
			{
				"350K",
				"700K"
			});
			this.m_cboRampTimeHpf2.Location = new Point(464, 114);
			this.m_cboRampTimeHpf2.Margin = new Padding(4, 4, 4, 4);
			this.m_cboRampTimeHpf2.Name = "m_cboRampTimeHpf2";
			this.m_cboRampTimeHpf2.Size = new Size(111, 25);
			this.m_cboRampTimeHpf2.TabIndex = 5;
			this.m_cboRampTimeHpf2.SelectedIndexChanged += this.m_CombBoxHPF2CornerFreq_SelectiveChanged;
			this.m_cboRampTimeHpf1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.m_cboRampTimeHpf1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_cboRampTimeHpf1.FormattingEnabled = true;
			this.m_cboRampTimeHpf1.Items.AddRange(new object[]
			{
				"175K",
				"235K"
			});
			this.m_cboRampTimeHpf1.Location = new Point(464, 73);
			this.m_cboRampTimeHpf1.Margin = new Padding(4, 4, 4, 4);
			this.m_cboRampTimeHpf1.Name = "m_cboRampTimeHpf1";
			this.m_cboRampTimeHpf1.Size = new Size(111, 25);
			this.m_cboRampTimeHpf1.TabIndex = 4;
			this.m_cboRampTimeHpf1.SelectedIndexChanged += this.m_CombBoxHPF1CornerFreq_SelectiveChanged;
			this.m_ChkBxForADCHalfRateEnable.AutoSize = true;
			this.m_ChkBxForADCHalfRateEnable.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_ChkBxForADCHalfRateEnable.Location = new Point(196, 37);
			this.m_ChkBxForADCHalfRateEnable.Margin = new Padding(4, 4, 4, 4);
			this.m_ChkBxForADCHalfRateEnable.Name = "m_ChkBxForADCHalfRateEnable";
			this.m_ChkBxForADCHalfRateEnable.Size = new Size(163, 21);
			this.m_ChkBxForADCHalfRateEnable.TabIndex = 15;
			this.m_ChkBxForADCHalfRateEnable.TabStop = true;
			this.m_ChkBxForADCHalfRateEnable.Text = "ADC Half Rate Mode";
			this.m_ChkBxForADCHalfRateEnable.UseVisualStyleBackColor = true;
			this.m_ChkBxForADCHalfRateEnable.CheckedChanged += this.m_nudRampADCHalfRateMode_ValueChanged;
			this.m_ChkBxForADCFullRateEnable.AutoSize = true;
			this.m_ChkBxForADCFullRateEnable.Checked = true;
			this.m_ChkBxForADCFullRateEnable.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_ChkBxForADCFullRateEnable.Location = new Point(16, 37);
			this.m_ChkBxForADCFullRateEnable.Margin = new Padding(4, 4, 4, 4);
			this.m_ChkBxForADCFullRateEnable.Name = "m_ChkBxForADCFullRateEnable";
			this.m_ChkBxForADCFullRateEnable.Size = new Size(161, 21);
			this.m_ChkBxForADCFullRateEnable.TabIndex = 14;
			this.m_ChkBxForADCFullRateEnable.TabStop = true;
			this.m_ChkBxForADCFullRateEnable.Text = "ADC Full Rate Mode";
			this.m_ChkBxForADCFullRateEnable.UseVisualStyleBackColor = true;
			this.m_ChkBxForADCFullRateEnable.CheckedChanged += this.m_nudRampADCFullRateMode_ValueChanged;
			this.m_nudNumSampleRate.Location = new Point(177, 202);
			this.m_nudNumSampleRate.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudNumSampleRate = this.m_nudNumSampleRate;
			int[] array2 = new int[4];
			array2[0] = 50000;
			nudNumSampleRate.Maximum = new decimal(array2);
			NumericUpDown nudNumSampleRate2 = this.m_nudNumSampleRate;
			int[] array3 = new int[4];
			array3[0] = 2000;
			nudNumSampleRate2.Minimum = new decimal(array3);
			this.m_nudNumSampleRate.Name = "m_nudNumSampleRate";
			this.m_nudNumSampleRate.Size = new Size(112, 25);
			this.m_nudNumSampleRate.TabIndex = 12;
			NumericUpDown nudNumSampleRate3 = this.m_nudNumSampleRate;
			int[] array4 = new int[4];
			array4[0] = 5000;
			nudNumSampleRate3.Value = new decimal(array4);
			this.m_nudNumSampleRate.ValueChanged += this.m_nudRampSampleRate_ValueChanged;
			this.m_nudNumADCSamples.Location = new Point(177, 161);
			this.m_nudNumADCSamples.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudNumADCSamples = this.m_nudNumADCSamples;
			int[] array5 = new int[4];
			array5[0] = 16384;
			nudNumADCSamples.Maximum = new decimal(array5);
			NumericUpDown nudNumADCSamples2 = this.m_nudNumADCSamples;
			int[] array6 = new int[4];
			array6[0] = 2;
			nudNumADCSamples2.Minimum = new decimal(array6);
			this.m_nudNumADCSamples.Name = "m_nudNumADCSamples";
			this.m_nudNumADCSamples.Size = new Size(112, 25);
			this.m_nudNumADCSamples.TabIndex = 11;
			NumericUpDown nudNumADCSamples3 = this.m_nudNumADCSamples;
			int[] array7 = new int[4];
			array7[0] = 256;
			nudNumADCSamples3.Value = new decimal(array7);
			this.m_nudNumADCSamples.ValueChanged += this.m_nudRampADCSamples_ValueChanged;
			this.m_nudSlope.DecimalPlaces = 3;
			this.m_nudSlope.Increment = new decimal(new int[]
			{
				5,
				0,
				0,
				131072
			});
			this.m_nudSlope.Location = new Point(177, 119);
			this.m_nudSlope.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudSlope = this.m_nudSlope;
			int[] array8 = new int[4];
			array8[0] = 300;
			nudSlope.Maximum = new decimal(array8);
			this.m_nudSlope.Minimum = new decimal(new int[]
			{
				300,
				0,
				0,
				int.MinValue
			});
			this.m_nudSlope.Name = "m_nudSlope";
			this.m_nudSlope.Size = new Size(112, 25);
			this.m_nudSlope.TabIndex = 10;
			this.m_nudSlope.Value = new decimal(new int[]
			{
				50018,
				0,
				0,
				196608
			});
			this.m_nudSlope.ValueChanged += this.m_nudRampFreqSlopeConst_ValueChanged;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(17, 207);
			this.label4.Margin = new Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(138, 17);
			this.label4.TabIndex = 9;
			this.label4.Text = "Sample Rate (ksps)";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(16, 170);
			this.label3.Margin = new Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(101, 17);
			this.label3.TabIndex = 8;
			this.label3.Text = "ADC Samples";
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(16, 126);
			this.label2.Margin = new Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(108, 17);
			this.label2.TabIndex = 7;
			this.label2.Text = "Slope (MHz/µs)";
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(16, 82);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(77, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "DFE Mode";
			this.m_comDFEMode.DropDownStyle = ComboBoxStyle.DropDownList;
			this.m_comDFEMode.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_comDFEMode.FormattingEnabled = true;
			this.m_comDFEMode.Items.AddRange(new object[]
			{
				"Real",
				"Complex1x",
				"Complex2x",
				"PseudoReal"
			});
			this.m_comDFEMode.Location = new Point(177, 76);
			this.m_comDFEMode.Margin = new Padding(4, 4, 4, 4);
			this.m_comDFEMode.Name = "m_comDFEMode";
			this.m_comDFEMode.Size = new Size(111, 25);
			this.m_comDFEMode.TabIndex = 5;
			this.m_comDFEMode.SelectedIndexChanged += this.m_nudRampDFEMode_ValueChanged;
			this.m_ChkBxForProgFiltEnable.AutoSize = true;
			this.m_ChkBxForProgFiltEnable.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_ChkBxForProgFiltEnable.Location = new Point(16, 58);
			this.m_ChkBxForProgFiltEnable.Margin = new Padding(4, 4, 4, 4);
			this.m_ChkBxForProgFiltEnable.Name = "m_ChkBxForProgFiltEnable";
			this.m_ChkBxForProgFiltEnable.Size = new Size(310, 21);
			this.m_ChkBxForProgFiltEnable.TabIndex = 4;
			this.m_ChkBxForProgFiltEnable.Text = "Programmable Filter Enable (AR16xx Only)";
			this.m_ChkBxForProgFiltEnable.UseVisualStyleBackColor = true;
			this.m_ChkBxForProgFiltEnable.CheckedChanged += this.m_nudRampProgFiltEnable_ValueChanged;
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.m_grpRampTimingCfg);
			base.Margin = new Padding(4, 4, 4, 4);
			base.Name = "RampTimingCfgTab";
			base.Size = new Size(1240, 786);
			this.m_grpRampTimingCfg.ResumeLayout(false);
			this.m_grpRampTimingCfg.PerformLayout();
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((ISupportInitialize)this.m_txtUsrProgADCStartTime).EndInit();
			((ISupportInitialize)this.m_txtUsrProgRampEndTime).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.m_nudNumSampleRate).EndInit();
			((ISupportInitialize)this.m_nudNumADCSamples).EndInit();
			((ISupportInitialize)this.m_nudSlope).EndInit();
			base.ResumeLayout(false);
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		public RampTimingConfigParams m_RampTimingConfigParams;

		private IContainer components;

		private GroupBox m_grpRampTimingCfg;

		private GroupBox groupBox2;

		private GroupBox groupBox1;

		private CheckBox m_ChkBxForProgFiltEnable;

		private ComboBox m_comDFEMode;

		private NumericUpDown m_nudNumSampleRate;

		private NumericUpDown m_nudNumADCSamples;

		private NumericUpDown m_nudSlope;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label label1;

		private Label label8;

		private Label label7;

		private Label label5;

		private TextBox m_txtRampEndTime;

		private TextBox f000257;

		private TextBox m_txtIdleTime;

		private RadioButton m_ChkBxForADCFullRateEnable;

		private RadioButton m_ChkBxForADCHalfRateEnable;

		private Label label10;

		private Label label9;

		private TextBox m_txtTotalSweepBW;

		private TextBox m_txtValidSweepBW;

		private TextBox textBox1;

		private TextBox m_txtUserProgIdleTime;

		private TextBox m_txtNintyNineRampEndTime;

		private TextBox f000258;

		private TextBox m_txtNintyNineIdleTime;

		private Label label13;

		private Label label12;

		private Label label6;

		private Label label15;

		private Label label14;

		private ComboBox m_cboRampTimeHpf2;

		private ComboBox m_cboRampTimeHpf1;

		private TextBox m_txtUsrProgTotalSweepBW;

		private TextBox m_txtUsrProgValidSweepBW;

		private TextBox m_txtNintyNineSettlingTotalSweepBW;

		private TextBox m_txtNintyNineSettlingValidSweepBW;

		private TextBox m_txtNintySettlingTotalSweepBW;

		private TextBox m_txtNintySettlingValidSweepBW;

		private TextBox m_txtNintySettlingRampEndTime;

		private TextBox m_txtNintySettlingADCStartTime;

		private TextBox m_txtNintySettlingIdleTime;

		private Label label16;

		private NumericUpDown m_txtUsrProgADCStartTime;

		private NumericUpDown m_txtUsrProgRampEndTime;

		private PictureBox pictureBox1;

		private TextBox m_txtUserProgSettlingInterChirpTime;

		private TextBox m_txtNintyNineSettlingInterChirpTime;

		private TextBox m_txtNintyFiveSettlingInterChirpTime;

		private TextBox m_txtNintySettlingInterChirpTime;

		private Label label11;
	}
}
