using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlTxGainPhaseMismatchMonConfT
	{
		public int profileIndx { get; set; }

		public string rfFreqBitMask { get; set; }

		public string txEn { get; set; }

		public string rxEn { get; set; }

		public double txGainMismatchThresh { get; set; }

		public double txPhaseMismatchThresh { get; set; }

		public List<List<double>> txGainMismatchOffsetVal { get; set; }

		public List<List<double>> txPhaseMismatchOffsetVal { get; set; }

		public int isConfigured { get; set; }
	}
}
