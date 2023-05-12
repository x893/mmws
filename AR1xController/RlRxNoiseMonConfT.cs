using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlRxNoiseMonConfT
	{
		public int profileIndx { get; set; }
		public string rfFreqBitMask { get; set; }
		public int reportMode { get; set; }
		public double noiseThresh { get; set; }
		public int isConfigured { get; set; }
	}
}
