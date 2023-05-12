using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlAllTxPowMonConfT
	{
		public Tx0PowrMonCfg tx0PowrMonCfg { get; set; }

		public Tx1PowrMonCfg tx1PowrMonCfg { get; set; }

		public Tx2PowrMonCfg tx2PowrMonCfg { get; set; }

		public int isConfigured { get; set; }
	}
}
