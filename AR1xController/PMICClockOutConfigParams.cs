using System;

namespace AR1xController
{
	public class PMICClockOutConfigParams
	{
		public byte PMICClockControl;

		public byte PMICClockSrc;

		public byte SrcClockDiv;

		public byte ModeSelect;

		public uint FreqSlope;

		public byte MinNDivVal;

		public byte MaxNDivVal;

		public byte ClockDitherEna;

		public byte Reserved;
	}
}
