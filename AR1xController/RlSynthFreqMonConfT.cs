using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlSynthFreqMonConfT
	{
		public int profileIndx { get; set; }

		public int reportMode { get; set; }

		public int freqErrThresh { get; set; }

		public double monStartTime { get; set; }

		public int isConfigured { get; set; }
	}
}
