using System;

namespace AR1xController
{
	public class AR1xxxExtOpps
	{
		public frmAR1Main MainTsfrm
		{
			get
			{
				return this.m_MainAR1frm;
			}
			set
			{
				this.m_MainAR1frm = value;
			}
		}

		public GuiManager GuiManager
		{
			get
			{
				return AR1xxxExtOpps.m_GuiManager;
			}
			set
			{
				AR1xxxExtOpps.m_GuiManager = value;
			}
		}

		public void Init(GuiManager gui_manager, AR1xxxWrapper ts_wrapper)
		{
			AR1xxxExtOpps.m_GuiManager = gui_manager;
			this.m_TsWrapper = ts_wrapper;
			this.m_MainAR1frm = gui_manager.MainTsForm;
		}

		public int TriggerChirp(ushort RadarDeviceId, ushort chirpStartIdx, ushort chirpEndIdx, ushort profileId, float startFreqVar, float freqSlopeVar, float idleTimeVar, float adcStartTimeVar, ushort tx1Enable, ushort tx2Enable, ushort tx3Enable)
		{
			return AR1xxxExtOpps.m_GuiManager.ScriptOps.UpdateNSetChirpConfData(RadarDeviceId, chirpStartIdx, chirpEndIdx, profileId, startFreqVar, freqSlopeVar, idleTimeVar, adcStartTimeVar, tx1Enable, tx2Enable, tx3Enable);
		}

		public int SetProfile(ushort RadarDeviceId, ushort profileId, float startFreqConst, float idleTimeConst, float adcStartTimeConst, float rampEndTime, uint tx1OutPowerBackoffCode, uint tx2OutPowerBackoffCode, uint tx3OutPowerBackoffCode, float tx1PhaseShifter, float tx2PhaseShifter, float tx3PhaseShifter, float freqSlopeConst, float txStartTime, ushort numAdcSamples, ushort digOutSampleRate, uint hpfCornerFreq1, uint hpfCornerFreq2, char rxGain, ushort ProfileControl)
		{
			return AR1xxxExtOpps.m_GuiManager.ScriptOps.UpdateNSetProfileConfData(RadarDeviceId, profileId, startFreqConst, idleTimeConst, adcStartTimeConst, rampEndTime, tx1OutPowerBackoffCode, tx2OutPowerBackoffCode, tx3OutPowerBackoffCode, tx1PhaseShifter, tx2PhaseShifter, tx3PhaseShifter, freqSlopeConst, txStartTime, numAdcSamples, digOutSampleRate, hpfCornerFreq1, hpfCornerFreq2, rxGain);
		}

		private frmAR1Main m_MainAR1frm;

		private static GuiManager m_GuiManager;

		private AR1xxxWrapper m_TsWrapper;
	}
}
