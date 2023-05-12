using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AR1xController
{
	public partial class ChirpManager : Form
	{
		public ChirpManager()
		{
			string directoryName = Path.GetDirectoryName(Application.StartupPath);
			string text = string.Concat(new string[]
			{
				directoryName + "\\Clients\\AR1xController\\ChirpConfigData.csv"
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
			this.loadChirpData(GlobalRef.jobject, p);
			this.m_cboADCDataFileChirpConfig.Text = text;
		}

		public AR1xxxExtOpps AR1xxxExtOpps
		{
			get
			{
				return this.m_AR1xxxExtOpps;
			}
			set
			{
				this.m_AR1xxxExtOpps = value;
			}
		}

		public ProfManager ProfManager
		{
			get
			{
				return this.m_ProfManager;
			}
			set
			{
				this.m_ProfManager = value;
			}
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

		public bool UpdateProfileConfigDataView0()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateProfileConfigDataView0);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				uint g_RadarDeviceId = GlobalRef.g_RadarDeviceId;
				int index = 0;
				for (int i = 0; i < 4; i++)
				{
					if (((ulong)g_RadarDeviceId & (ulong)(1L << (i & 31))) != 0UL)
					{
						int mmwaveDevIndex = this.m_GuiManager.ScriptOps.getMmwaveDevIndex(i);
						for (int j = 0; j < GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles.Count; j++)
						{
							if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[j].rlProfileCfg_t.profileId == 0)
							{
								index = j;
							}
						}
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.profileId != 0)
						{
							MessageBox.Show("Profile 0 is not configured yet!");
							return false;
						}
						this.m_nudProfileProfileId.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.profileId;
						this.m_nudStartFreqConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.startFreqConst_GHz;
						this.m_nudIdleTimeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.idleTimeConst_usec;
						this.m_nudAdcStartTimeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.adcStartTimeConst_usec;
						this.m_nudRampEndTime.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rampEndTime_usec;
						this.m_nudTx1OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 255);
						this.m_nudTx2OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 65280) >> 8;
						this.m_nudTx3OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 16711680) >> 16;
						this.m_nudTx1PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 255) >> 2) * 5;
						this.m_nudTx2PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 65280) >> 10) * 5;
						this.m_nudTx3PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 16711680) >> 18) * 5;
						this.m_nudFreqSlopeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.freqSlopeConst_MHz_usec;
						this.m_nudTxStartTime.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txStartTime_usec;
						this.m_nudNumAdcSamples.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.numAdcSamples;
						this.m_nudDigOutSampleRate.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.digOutSampleRate;
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.hpfCornerFreq1 == 0)
						{
							this.m_cboProfileHpf1.SelectedIndex = 0;
						}
						else
						{
							this.m_cboProfileHpf1.SelectedIndex = 1;
						}
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.hpfCornerFreq2 == 0)
						{
							this.m_cboProfileHpf2.SelectedIndex = 0;
						}
						else
						{
							this.m_cboProfileHpf2.SelectedIndex = 1;
						}
						this.m_nudProfileRxGain.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 63);
						if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 0)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 0;
						}
						else if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 1)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 1;
						}
						else if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 3)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 3;
						}
						this.m_cboChripMngrProfileVCOSelect.SelectedIndex = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfVcoSelect, 16) & 2) >> 1;
						this.m_chbChirpMngProfileForceVCOSelect.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfVcoSelect, 16) & 1) == 1);
						this.m_chbChirpMngrProfileRetainRxCalLUT.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfCalLutUpdate, 16) & 2) >> 1 == 1);
						this.m_chbChirpMngrProfileRetainTxCalLUT.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfCalLutUpdate, 16) & 1) == 1);
					}
				}
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				result = false;
			}
			return result;
		}

		public bool UpdateProfileConfigDataView1()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateProfileConfigDataView1);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				uint g_RadarDeviceId = GlobalRef.g_RadarDeviceId;
				int index = 0;
				for (int i = 0; i < 4; i++)
				{
					if (((ulong)g_RadarDeviceId & (ulong)(1L << (i & 31))) != 0UL)
					{
						int mmwaveDevIndex = this.m_GuiManager.ScriptOps.getMmwaveDevIndex(i);
						for (int j = 0; j < GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles.Count; j++)
						{
							if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[j].rlProfileCfg_t.profileId == 1)
							{
								index = j;
							}
						}
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.profileId != 1)
						{
							MessageBox.Show("Profile 1 is not configured yet!");
							return false;
						}
						this.m_nudProfileProfileId.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.profileId;
						this.m_nudStartFreqConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.startFreqConst_GHz;
						this.m_nudIdleTimeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.idleTimeConst_usec;
						this.m_nudAdcStartTimeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.adcStartTimeConst_usec;
						this.m_nudRampEndTime.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rampEndTime_usec;
						this.m_nudTx1OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 255);
						this.m_nudTx2OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 65280) >> 8;
						this.m_nudTx3OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 16711680) >> 16;
						this.m_nudTx1PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 255) >> 2) * 5;
						this.m_nudTx2PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 65280) >> 10) * 5;
						this.m_nudTx3PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 16711680) >> 18) * 5;
						this.m_nudFreqSlopeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.freqSlopeConst_MHz_usec;
						this.m_nudTxStartTime.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txStartTime_usec;
						this.m_nudNumAdcSamples.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.numAdcSamples;
						this.m_nudDigOutSampleRate.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.digOutSampleRate;
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.hpfCornerFreq1 == 0)
						{
							this.m_cboProfileHpf1.SelectedIndex = 0;
						}
						else
						{
							this.m_cboProfileHpf1.SelectedIndex = 1;
						}
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.hpfCornerFreq2 == 0)
						{
							this.m_cboProfileHpf2.SelectedIndex = 0;
						}
						else
						{
							this.m_cboProfileHpf2.SelectedIndex = 1;
						}
						this.m_nudProfileRxGain.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 63);
						if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 0)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 0;
						}
						else if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 1)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 1;
						}
						else if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 3)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 3;
						}
						this.m_cboChripMngrProfileVCOSelect.SelectedIndex = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfVcoSelect, 16) & 2) >> 1;
						this.m_chbChirpMngProfileForceVCOSelect.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfVcoSelect, 16) & 1) == 1);
						this.m_chbChirpMngrProfileRetainRxCalLUT.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfCalLutUpdate, 16) & 2) >> 1 == 1);
						this.m_chbChirpMngrProfileRetainTxCalLUT.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfCalLutUpdate, 16) & 1) == 1);
					}
				}
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				result = false;
			}
			return result;
		}

		public bool UpdateProfileConfigDataView2()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateProfileConfigDataView2);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				uint g_RadarDeviceId = GlobalRef.g_RadarDeviceId;
				int index = 0;
				for (int i = 0; i < 4; i++)
				{
					if (((ulong)g_RadarDeviceId & (ulong)(1L << (i & 31))) != 0UL)
					{
						int mmwaveDevIndex = this.m_GuiManager.ScriptOps.getMmwaveDevIndex(i);
						for (int j = 0; j < GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles.Count; j++)
						{
							if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[j].rlProfileCfg_t.profileId == 2)
							{
								index = j;
							}
						}
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.profileId != 2)
						{
							MessageBox.Show("Profile 2 is not configured yet!");
							return false;
						}
						this.m_nudProfileProfileId.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.profileId;
						this.m_nudStartFreqConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.startFreqConst_GHz;
						this.m_nudIdleTimeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.idleTimeConst_usec;
						this.m_nudAdcStartTimeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.adcStartTimeConst_usec;
						this.m_nudRampEndTime.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rampEndTime_usec;
						this.m_nudTx1OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 255);
						this.m_nudTx2OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 65280) >> 8;
						this.m_nudTx3OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 16711680) >> 16;
						this.m_nudTx1PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 255) >> 2) * 5;
						this.m_nudTx2PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 65280) >> 10) * 5;
						this.m_nudTx3PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 16711680) >> 18) * 5;
						this.m_nudFreqSlopeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.freqSlopeConst_MHz_usec;
						this.m_nudTxStartTime.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txStartTime_usec;
						this.m_nudNumAdcSamples.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.numAdcSamples;
						this.m_nudDigOutSampleRate.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.digOutSampleRate;
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.hpfCornerFreq1 == 0)
						{
							this.m_cboProfileHpf1.SelectedIndex = 0;
						}
						else
						{
							this.m_cboProfileHpf1.SelectedIndex = 1;
						}
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.hpfCornerFreq2 == 0)
						{
							this.m_cboProfileHpf2.SelectedIndex = 0;
						}
						else
						{
							this.m_cboProfileHpf2.SelectedIndex = 1;
						}
						this.m_nudProfileRxGain.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 63);
						if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 0)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 0;
						}
						else if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 1)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 1;
						}
						else if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 3)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 3;
						}
						this.m_cboChripMngrProfileVCOSelect.SelectedIndex = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfVcoSelect, 16) & 2) >> 1;
						this.m_chbChirpMngProfileForceVCOSelect.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfVcoSelect, 16) & 1) == 1);
						this.m_chbChirpMngrProfileRetainRxCalLUT.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfCalLutUpdate, 16) & 2) >> 1 == 1);
						this.m_chbChirpMngrProfileRetainTxCalLUT.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfCalLutUpdate, 16) & 1) == 1);
					}
				}
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				result = false;
			}
			return result;
		}

		public bool UpdateProfileConfigDataView3()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateProfileConfigDataView3);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				uint g_RadarDeviceId = GlobalRef.g_RadarDeviceId;
				int index = 0;
				for (int i = 0; i < 4; i++)
				{
					if (((ulong)g_RadarDeviceId & (ulong)(1L << (i & 31))) != 0UL)
					{
						int mmwaveDevIndex = this.m_GuiManager.ScriptOps.getMmwaveDevIndex(i);
						for (int j = 0; j < GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles.Count; j++)
						{
							if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[j].rlProfileCfg_t.profileId == 3)
							{
								index = j;
							}
						}
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.profileId != 3)
						{
							MessageBox.Show("Profile 3 is not configured yet!");
							return false;
						}
						this.m_nudProfileProfileId.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.profileId;
						this.m_nudStartFreqConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.startFreqConst_GHz;
						this.m_nudIdleTimeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.idleTimeConst_usec;
						this.m_nudAdcStartTimeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.adcStartTimeConst_usec;
						this.m_nudRampEndTime.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rampEndTime_usec;
						this.m_nudTx1OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 255);
						this.m_nudTx2OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 65280) >> 8;
						this.m_nudTx3OutPowerBackoffCode.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 16711680) >> 16;
						this.m_nudTx1PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 255) >> 2) * 5;
						this.m_nudTx2PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 65280) >> 10) * 5;
						this.m_nudTx3PhaseShifter.Value = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txPhaseShifter, 16) & 16711680) >> 18) * 5;
						this.m_nudFreqSlopeConst.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.freqSlopeConst_MHz_usec;
						this.m_nudTxStartTime.Value = (decimal)GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.txStartTime_usec;
						this.m_nudNumAdcSamples.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.numAdcSamples;
						this.m_nudDigOutSampleRate.Value = GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.digOutSampleRate;
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.hpfCornerFreq1 == 0)
						{
							this.m_cboProfileHpf1.SelectedIndex = 0;
						}
						else
						{
							this.m_cboProfileHpf1.SelectedIndex = 1;
						}
						if (GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.hpfCornerFreq2 == 0)
						{
							this.m_cboProfileHpf2.SelectedIndex = 0;
						}
						else
						{
							this.m_cboProfileHpf2.SelectedIndex = 1;
						}
						this.m_nudProfileRxGain.Value = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 63);
						if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 0)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 0;
						}
						else if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 1)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 1;
						}
						else if ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 3)
						{
							this.m_cboProfileRFGainTargetMnger.SelectedIndex = 3;
						}
						this.m_cboChripMngrProfileVCOSelect.SelectedIndex = (Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfVcoSelect, 16) & 2) >> 1;
						this.m_chbChirpMngProfileForceVCOSelect.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfVcoSelect, 16) & 1) == 1);
						this.m_chbChirpMngrProfileRetainRxCalLUT.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfCalLutUpdate, 16) & 2) >> 1 == 1);
						this.m_chbChirpMngrProfileRetainTxCalLUT.Checked = ((Convert.ToInt32(GlobalRef.jobject.mmWaveDevices[mmwaveDevIndex].rfConfig.rlProfiles[index].rlProfileCfg_t.pfCalLutUpdate, 16) & 1) == 1);
					}
				}
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				result = false;
			}
			return result;
		}

		private void m_btnBrowse_Click(object sender, EventArgs p1)
		{
			this.openFileDialog1.InitialDirectory = "D:";
			this.openFileDialog1.RestoreDirectory = true;
			string text = this.iHandleBrowseFiles("CSV", this.m_cboADCDataFileChirpConfig.Text);
			if (!string.IsNullOrEmpty(text))
			{
				this.iSetPathInCombo(text, this.m_cboADCDataFileChirpConfig);
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

		private void m_btnLoad_Click(object sender, EventArgs p1)
		{
			this.dataGridView1.Rows.Clear();
			this.dataGridView1.ColumnCount = 0;
			this.dataGridView1.DataSource = null;
			this.loadFileData(this.m_cboADCDataFileChirpConfig.Text);
		}

		private void m_btnSave_Click(object sender, EventArgs p1)
		{
			this.saveDataToFile(this.m_cboADCDataFileChirpConfig.Text);
			this.m_btnActivate.Enabled = true;
			this.m_btnSave.ForeColor = Color.FromArgb(34, 139, 34);
		}

		public void m_btnActivate_Click(object sender, EventArgs p1)
		{
			int i = 0;
			int rowCount = this.dataGridView1.RowCount;
			int num = 0;
			foreach (object obj in ((IEnumerable)this.dataGridView1.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (num >= rowCount - 1)
				{
					break;
				}
				while (i < rowCount - (rowCount - 1))
				{
					this.f000170[i].profId = Convert.ToUInt16(dataGridViewRow.Cells[0].Value);
					this.f000170[i].chipStartIndex = Convert.ToUInt16(dataGridViewRow.Cells[1].Value);
					this.f000170[i].chipEndIndex = Convert.ToUInt16(dataGridViewRow.Cells[2].Value);
					this.f000170[i].startFreqVar = Convert.ToSingle(dataGridViewRow.Cells[3].Value);
					this.f000170[i].freqSlopeVar = Convert.ToSingle(dataGridViewRow.Cells[4].Value);
					this.f000170[i].idleTimeVar = Convert.ToSingle(dataGridViewRow.Cells[5].Value);
					this.f000170[i].adcStartTimeVar = Convert.ToSingle(dataGridViewRow.Cells[6].Value);
					this.f000170[i].tx1Enable = Convert.ToUInt16(dataGridViewRow.Cells[7].Value);
					this.f000170[i].tx2Enable = Convert.ToUInt16(dataGridViewRow.Cells[8].Value);
					this.f000170[i].tx3Enable = Convert.ToUInt16(dataGridViewRow.Cells[9].Value);
					if (this.m_AR1xxxExtOpps.TriggerChirp((ushort)GlobalRef.g_RadarDeviceId, this.f000170[i].chipStartIndex, this.f000170[i].chipEndIndex, this.f000170[i].profId, this.f000170[i].startFreqVar, this.f000170[i].freqSlopeVar, this.f000170[i].idleTimeVar, this.f000170[i].adcStartTimeVar, this.f000170[i].tx1Enable, this.f000170[i].tx2Enable, this.f000170[i].tx3Enable) != 0)
					{
						string full_command = string.Format("chirp Config {0} failed, stoping.", new object[]
						{
							i
						});
						this.m_GuiManager.RecordLog(11, full_command);
						return;
					}
					i++;
					if (i == 512)
					{
						string full_command2 = string.Format("Maximum Chirp configuration is 512 but here exceeding configuration:{0}", new object[]
						{
							i
						});
						this.m_GuiManager.RecordLog(11, full_command2);
						return;
					}
				}
				i = 0;
				num++;
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs p1)
		{
			if (this.radioButton1.Checked)
			{
				this.UpdateProfileConfigDataView0();
			}
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs p1)
		{
			if (this.radioButton2.Checked)
			{
				this.UpdateProfileConfigDataView1();
			}
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs p1)
		{
			if (this.radioButton3.Checked)
			{
				this.UpdateProfileConfigDataView2();
			}
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs p1)
		{
			if (this.radioButton4.Checked)
			{
				this.UpdateProfileConfigDataView3();
			}
		}

		private void loadChirpData(RootObject jobject, int p1)
		{
			if (jobject.mmWaveDevices[p1].rfConfig.rlChirps.Count == 0)
			{
				MessageBox.Show("No Chirps have been configured!");
				return;
			}
			int count = GlobalRef.jobject.mmWaveDevices[p1].rfConfig.rlChirps.Count;
			string text = "";
			text = "Profile ID;Chirp Start Index;Chirp End Index;Start Freq Var (MHz);Frequency Slop Var (kHz/us);Idle Time Var (us);ADC Start Var (us);TX0 Enble;TX1 Enable;TX2 Enable";
			string[] array = new string[512];
			for (int i = 0; i < count; i++)
			{
				string text2 = jobject.mmWaveDevices[p1].rfConfig.rlChirps[i].rlChirpCfg_t.profileId + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[i].rlChirpCfg_t.chirpStartIdx + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[i].rlChirpCfg_t.chirpEndIdx + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[i].rlChirpCfg_t.startFreqVar_MHz + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[i].rlChirpCfg_t.freqSlopeVar_KHz_usec + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[i].rlChirpCfg_t.idleTimeVar_usec + ";";
				text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[i].rlChirpCfg_t.adcStartTimeVar_usec + ";";
				text2 = text2 + (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChirps[i].rlChirpCfg_t.txEnable, 16) & 1) + ";";
				text2 = text2 + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChirps[i].rlChirpCfg_t.txEnable, 16) & 2) >> 1) + ";";
				text2 += (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChirps[i].rlChirpCfg_t.txEnable, 16) & 4) >> 2;
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
				int num = array2.Count<string>();
				num--;
				for (int j = 0; j <= num; j++)
				{
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumn.Name = array2[j];
					dataGridViewTextBoxColumn.HeaderText = array2[j];
					dataGridViewTextBoxColumn.Width = 80;
					this.dataGridView1.Columns.Add(dataGridViewTextBoxColumn);
				}
				for (int k = 0; k < count; k++)
				{
					array2 = array[k].Split(new char[]
					{
						this.delimiter
					});
					DataGridViewRowCollection rows = this.dataGridView1.Rows;
					object[] values = array2;
					rows.Add(values);
					this.dataGridView1.Update();
					this.dataGridView1.Refresh();
					this.dataGridView1.Update();
					this.dataGridView1.Refresh();
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
							this.dataGridView1.Columns.Add(dataGridViewTextBoxColumn);
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
						DataGridViewRowCollection rows = this.dataGridView1.Rows;
						object[] values = array;
						rows.Add(values);
						this.dataGridView1.Update();
						this.dataGridView1.Refresh();
						this.dataGridView1.Update();
						this.dataGridView1.Refresh();
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
				int num = this.dataGridView1.ColumnCount - 1;
				if (num >= 0)
				{
					text = this.dataGridView1.Columns[0].HeaderText;
				}
				for (int i = 1; i <= num; i++)
				{
					text = text + this.delimiter.ToString() + this.dataGridView1.Columns[i].HeaderText;
				}
				streamWriter.WriteLine(text);
				foreach (object obj in ((IEnumerable)this.dataGridView1.Rows))
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

		private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs p1)
		{
			this.m_btnSave.ForeColor = Color.FromArgb(255, 0, 0);
		}

		private void ChirpMangrStartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudStartFreqConst.Value * 67108864.0 / 3.6) * 3.6 / 67108864.0;
			this.m_nudStartFreqConst.Value = (decimal)value;
		}

		private void ChirpMngrFreqSlopeConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudFreqSlopeConst.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudFreqSlopeConst.Value = (decimal)value;
		}

		private void ChirpMngrIdleTimeConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Floor((double)this.m_nudIdleTimeConst.Value * 100.0) / 100.0;
			this.m_nudIdleTimeConst.Value = (decimal)value;
		}

		private void ChirpMngrTxStartTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Floor((double)this.m_nudAdcStartTimeConst.Value * 100.0) / 100.0;
			this.m_nudAdcStartTimeConst.Value = (decimal)value;
		}

		private void ChirpMngrAdcStartTimeConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Floor((double)this.m_nudAdcStartTimeConst.Value * 100.0) / 100.0;
			this.m_nudAdcStartTimeConst.Value = (decimal)value;
		}

		private void ChirpMngrRampEndTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Floor((double)this.m_nudRampEndTime.Value * 100.0) / 100.0;
			this.m_nudRampEndTime.Value = (decimal)value;
		}

		private void ChirpMngrProfileRxGain_ValueChanged_1(object sender, EventArgs p1)
		{
		}

		private void ChirpMngrTx1PhaseShifter_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)(Math.Round((double)this.m_nudTx1PhaseShifter.Value * 256.0) / 360.0) * 360.0 / 256.0;
			this.m_nudTx1PhaseShifter.Value = (decimal)value;
		}

		private void ChirpMngrTx2PhaseShifter_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)(Math.Round((double)this.m_nudTx2PhaseShifter.Value * 256.0) / 360.0) * 360.0 / 256.0;
			this.m_nudTx2PhaseShifter.Value = (decimal)value;
		}

		private void ChirpMngrTx3PhaseShifter_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)(Math.Round((double)this.m_nudTx3PhaseShifter.Value * 256.0) / 360.0) * 360.0 / 256.0;
			this.m_nudTx3PhaseShifter.Value = (decimal)value;
		}

		private void ChirpManager_Load(object sender, EventArgs p1)
		{
		}

		private AR1xxxExtOpps m_AR1xxxExtOpps = GlobalRef.AR1xxxExtOpps;

		private ProfManager m_ProfManager = GlobalRef.ProfManager;

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private char delimiter;

		private ChirpParams[] f000170 = new ChirpParams[1024];
	}
}
