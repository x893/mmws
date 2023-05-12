using System;

namespace AR1xController
{
	public class RFPSLoopBackConfigParams
	{
		public ushort LoopBackFreq;

		public ushort Reserved;

		public char LoopBackEnable;

		public char LoopBackTXIdTx0;

		public char LoopBackTXIdTx1;

		public char PGAGainIndex;

		public char Reserved2;
	}
}
