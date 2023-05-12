using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlFrameCfgT
	{
		public int chirpEndIdx { get; set; }

		public int chirpStartIdx { get; set; }

		public int numLoops { get; set; }

		public int numFrames { get; set; }

		public float framePeriodicity_msec { get; set; }

		public int triggerSelect { get; set; }

		public byte numDummyChirpsAtEnd { get; set; }

		public float frameTriggerDelay { get; set; }

		public int isConfigured { get; set; }
	}
}
