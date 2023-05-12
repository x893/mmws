using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlRfProgFiltConfT2
	{
		public int profileId { get; set; }

		public int coeffStartIdx { get; set; }

		public int progFiltLen { get; set; }

		public double progFiltFreqShift_Fs { get; set; }
	}
}
