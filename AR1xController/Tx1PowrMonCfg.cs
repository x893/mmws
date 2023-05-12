using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class Tx1PowrMonCfg
	{
		public int profileIndx { get; set; }

		public string rfFreqBitMask { get; set; }

		public int reportMode { get; set; }

		public double txPowAbsErrThresh { get; set; }

		public double txPowFlatnessErrThresh { get; set; }
	}
}
