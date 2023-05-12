using System;

namespace AR1xController
{
	public class MeasurePDPowerConfigParams
	{
		public char PDId;

		public char PDLnaGainIndex;

		public char NumOfAccumulations;

		public char NumOfSamples;

		public byte PDType;

		public byte pdSel;

		public byte pdDacVal;

		public byte paramVal;

		public uint Reserved;
	}
}
