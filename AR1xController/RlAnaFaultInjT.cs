using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlAnaFaultInjT
	{
		public string rxGainDrop { get; set; }
		public string rxPhInv { get; set; }
		public string rxHighNoise { get; set; }
		public string rxIfStagesFault { get; set; }
		public string rxLoAmpFault { get; set; }
		public string txLoAmpFault { get; set; }
		public string txGainDrop { get; set; }
		public string txPhInv { get; set; }
		public string synthFault { get; set; }
		public string supplyLdoFault { get; set; }
		public string miscFault { get; set; }
		public string miscThreshFault { get; set; }
		public int isConfigured { get; set; }
	}
}
