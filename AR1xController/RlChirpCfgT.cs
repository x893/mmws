using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlChirpCfgT
	{
		public int chirpStartIdx { get; set; }

		public int chirpEndIdx { get; set; }

		public int profileId { get; set; }

		public double startFreqVar_MHz { get; set; }

		public double freqSlopeVar_KHz_usec { get; set; }

		public double idleTimeVar_usec { get; set; }

		public double adcStartTimeVar_usec { get; set; }

		public string txEnable { get; set; }
	}
}
