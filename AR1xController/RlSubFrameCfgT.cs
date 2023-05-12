using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlSubFrameCfgT
	{
		public int forceProfileIdx { get; set; }

		public int chirpStartIdx { get; set; }

		public int numOfChirps { get; set; }

		public int numLoops { get; set; }

		public double burstPeriodicity_msec { get; set; }

		public int chirpStartIdxOffset { get; set; }

		public int numOfBurst { get; set; }

		public int numOfBurstLoops { get; set; }

		public double subFramePeriodicity_msec { get; set; }
	}
}
