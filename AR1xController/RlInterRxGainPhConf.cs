using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlInterRxGainPhConf
	{
		public int profileIndx { get; set; }

		public List<double> digRxGain { get; set; }

		public List<double> digRxPhShift { get; set; }

		public int isConfigured { get; set; }
	}
}
