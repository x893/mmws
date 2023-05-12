using System;

namespace AR1xController
{
	public class AdvChirpConfigParams
	{
		public ushort chirpParamIdx;

		public ushort reserved0;

		public byte resetMode;

		public byte patternMode;

		public ushort resetPeriod;

		public uint reserved2;

		public ushort reserved3;

		public ushort paramUpdatePeriod;

		public double fixedDeltaInc;

		public uint f00032a;

		public uint f00032b;

		public uint f00032c;

		public uint f00032d;

		public uint f00032e;

		public uint f00032f;
	}
}
