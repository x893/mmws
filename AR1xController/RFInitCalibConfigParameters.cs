using System;

namespace AR1xController
{
	public class RFInitCalibConfigParameters
	{
		public uint LODist;

		public uint RXADCDC;

		public uint HPFCutoff;

		public uint LPFCutoff;

		public uint PeakDetector;

		public uint TXPower;

		public uint RXGain;

		public uint TXPhase;

		public uint RXIQMM;

		public char Reserved0;

		public char Reserved1;

		public ushort Reserved2;

		public uint Reserved3;
	}
}
