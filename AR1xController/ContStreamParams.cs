using System;

namespace AR1xController
{
	public class ContStreamParams
	{
		public double startFreqConst;

		public uint tx1OutPowerBackoffCode;

		public uint tx2OutPowerBackoffCode;

		public uint tx3OutPowerBackoffCode;

		public double tx1PhaseShifter;

		public double tx2PhaseShifter;

		public double tx3PhaseShifter;

		public ushort digOutSampleRate;

		public char hpfCornerFreq1;

		public char hpfCornerFreq2;

		public char rxGain;

		public byte ProgramFilterEnable;

		public string mtlbAdcPath;

		public int noOfAdcSamples;

		public int DataFormat;

		public int ContStremForceContStreamMode;

		public uint GainNFRxChain;

		public float GainNFInputPower;

		public float GainNFToneFreq;

		public ushort RFGainTarget;

		public byte ForceVCOSelect;

		public byte VCOSelect;
	}
}
