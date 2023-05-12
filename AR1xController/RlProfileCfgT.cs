using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlProfileCfgT
	{
		public int profileId { get; set; }
		public string pfVcoSelect { get; set; }
		public string pfCalLutUpdate { get; set; }
		public double startFreqConst_GHz { get; set; }
		public double idleTimeConst_usec { get; set; }
		public double adcStartTimeConst_usec { get; set; }
		public double rampEndTime_usec { get; set; }
		public string txOutPowerBackoffCode { get; set; }
		public string txPhaseShifter { get; set; }
		public double freqSlopeConst_MHz_usec { get; set; }
		public double txStartTime_usec { get; set; }
		public int numAdcSamples { get; set; }
		public int digOutSampleRate { get; set; }
		public int hpfCornerFreq1 { get; set; }
		public int hpfCornerFreq2 { get; set; }
		public string rxGain_dB { get; set; }
	}
}
