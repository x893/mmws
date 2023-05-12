using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlExtAnaSignalsMonConfT
	{
		public int reportMode { get; set; }

		public string signalInpEnables { get; set; }

		public string signalBuffEnables { get; set; }

		public List<double> signalSettlingTime { get; set; }

		public List<double> signalThresh { get; set; }

		public int isConfigured { get; set; }
	}
}
