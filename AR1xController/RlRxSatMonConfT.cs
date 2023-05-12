using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlRxSatMonConfT
	{
		public int profileIndx { get; set; }

		public int satMonSel { get; set; }

		public double primarySliceDuration { get; set; }

		public int numSlices { get; set; }

		public int rxChannelMask { get; set; }

		public int isConfigured { get; set; }
	}
}
