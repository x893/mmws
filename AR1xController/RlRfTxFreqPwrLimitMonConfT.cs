using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlRfTxFreqPwrLimitMonConfT
	{
		public double freqLimitLowTx0 { get; set; }

		public double freqLimitLowTx1 { get; set; }

		public double freqLimitLowTx2 { get; set; }

		public double freqLimitHighTx0 { get; set; }

		public double freqLimitHighTx1 { get; set; }

		public double freqLimitHighTx2 { get; set; }

		public int tx0PwrBackOff { get; set; }

		public int tx1PwrBackOff { get; set; }

		public int tx2PwrBackOff { get; set; }

		public int isConfigured { get; set; }
	}
}
