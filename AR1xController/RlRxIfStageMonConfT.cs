using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlRxIfStageMonConfT
	{
		public int profileIndx { get; set; }
		public int reportMode { get; set; }
		public int hpfCutoffErrThresh { get; set; }
		public int lpfCutoffErrThresh { get; set; }
		public double ifaGainErrThresh { get; set; }
		public int isConfigured { get; set; }
	}
}
