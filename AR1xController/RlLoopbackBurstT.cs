using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlLoopbackBurstT
	{
		public int loopbackSel { get; set; }
		public int baseProfileIndx { get; set; }
		public int burstIndx { get; set; }
		public double freqConst_GHz { get; set; }
		public double slopeConst_MHz_us { get; set; }
		public string txBackoff { get; set; }
		public string rxGain_dB { get; set; }
		public string txEn { get; set; }
		public string bpmConfig { get; set; }
		public string digCorrDis { get; set; }
		public int ifLbFreq { get; set; }
		public int ifLbMag_10mv { get; set; }
		public int ps1PgaIndx { get; set; }
		public int ps2PgaIndx { get; set; }
		public string p00000e { get; set; }
		public int p00000f { get; set; }
	}
}
