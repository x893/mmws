using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlAdvChirpCfgT
	{
		public ushort chirpParamIdx { get; set; }

		public byte resetMode { get; set; }

		public byte patternMode { get; set; }

		public ushort resetPeriod { get; set; }

		public ushort paramUpdatePeriod { get; set; }

		public double fixedDeltaInc { get; set; }

		public int isConfigured { get; set; }
	}
}
