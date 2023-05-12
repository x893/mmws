using System;

namespace AR1xController
{
	public class ChirpConfigParams
	{
		public ushort chirpStartIdx;

		public ushort chirpEndIdx;

		public ushort cprofileId;

		public float startFreqVar;

		public float freqSlopeVar;

		public float idleTimeVar;

		public float adcStartTimeVar;

		public ushort tx1Enable;

		public ushort tx2Enable;

		public ushort tx3Enable;

		public ushort pprofileId;

		public double startFreqConst;

		public float idleTimeConst;

		public float adcStartTimeConst;

		public float rampEndTime;

		public uint tx1OutPowerBackoffCode;

		public uint tx2OutPowerBackoffCode;

		public uint tx3OutPowerBackoffCode;

		public double tx1PhaseShifter;

		public double tx2PhaseShifter;

		public double tx3PhaseShifter;

		public float freqSlopeConst;

		public float txStartTime;

		public ushort pnumAdcSamples;

		public ushort digOutSampleRate;

		public char hpfCornerFreq1;

		public char hpfCornerFreq2;

		public char rxGain;

		public char RFGainTarget;

		public ushort ProfileControl;

		public byte VCOSelect;

		public byte ForceVCOSelect;

		public byte RetainTxCalLUT;

		public byte RetainRxCalLUT;

		public byte TX0CalibTx0;

		public byte TX0CalibTx1;

		public byte TX0CalibTx2;

		public byte TX1CalibTx0;

		public byte TX1CalibTx1;

		public byte TX1CalibTx2;

		public byte TX2CalibTx0;

		public byte TX2CalibTx1;

		public byte TX2CalibTx2;

		public byte f000328;

		public ushort fchirpStartIdx;

		public ushort fchirpEndIdx;

		public ushort frameCount;

		public ushort loopCount;

		public float periodicity;

		public float triggerDelay;

		public byte numDummyChirpsAtEnd;

		public string f000329;

		public ushort testSourceEnable;

		public string postProcPath;

		public ushort FrameControl;

		public int TX1Channel;

		public int TX2Channel;

		public int TX3Channel;

		public int DataFormat;

		public ushort TriggerSelect;
	}
}
