using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class DetectionChain
	{
		public string name { get; set; }
		public int detectionLoss { get; set; }
		public int systemLoss { get; set; }
		public int implementationMargin { get; set; }
		public int detectionSNR { get; set; }
		public int theoreticalRxAntennaGain { get; set; }
		public int theoreticalTxAntennaGain { get; set; }
	}
}
