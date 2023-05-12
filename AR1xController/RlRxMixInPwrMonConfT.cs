using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlRxMixInPwrMonConfT
	{
		public int profileIndx { get; set; }

		public int reportMode { get; set; }

		public string txEnable { get; set; }

		public string thresholds { get; set; }

		public int isConfigured { get; set; }
	}
}
