using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlRunTimeCalibConfT
	{
		public string oneTimeCalibEnMask { get; set; }

		public string periodicCalibEnMask { get; set; }

		public int calibPeriodicity { get; set; }

		public int reportEn { get; set; }

		public int txPowerCalMode { get; set; }

		public int isConfigured { get; set; }
	}
}
