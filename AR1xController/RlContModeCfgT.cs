using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlContModeCfgT
	{
		public double startFreqConst_GHz { get; set; }
		public string txOutPowerBackoffCode { get; set; }
		public string txPhaseShifter { get; set; }
		public double digOutSampleRate { get; set; }
		public int hpfCornerFreq1 { get; set; }
		public int hpfCornerFreq2 { get; set; }
		public string rxGain_dB { get; set; }
		public string vcoSelect { get; set; }
		public int isConfigured { get; set; }
	}
}
