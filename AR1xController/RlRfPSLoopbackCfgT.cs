using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlRfPSLoopbackCfgT
	{
		public int psLoopbackFreq_KHz { get; set; }
		public int p00000d { get; set; }
		public string psLoopbackTxId { get; set; }
		public int pgaGainIndex { get; set; }
		public int isConfigured { get; set; }
	}
}
