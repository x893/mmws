using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RegulatoryRestrictions
	{
		public int frequencyRangeBegin_GHz { get; set; }

		public int frequencyRangeEnd_GHz { get; set; }

		public int maxBandwidthAllowed_MHz { get; set; }

		public int maxTransmitPowerAllowed_dBm { get; set; }

		public int isConfigured { get; set; }
	}
}
