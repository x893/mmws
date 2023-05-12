using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlRxGainPhaseMonConfT
	{
		public int profileIndx { get; set; }

		public string rfFreqBitMask { get; set; }

		public int txSel { get; set; }

		public double rxGainAbsThresh { get; set; }

		public double rxGainMismatchErrThresh { get; set; }

		public double rxGainFlatnessErrThresh { get; set; }

		public double rxGainPhaseMismatchErrThresh { get; set; }

		public List<List<double>> rxGainMismatchOffsetVal { get; set; }

		public List<List<double>> rxGainPhaseMismatchOffsetVal { get; set; }

		public int isConfigured { get; set; }
	}
}
