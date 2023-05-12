using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class SetupObject
	{
		public string createdByVersion { get; set; }

		public DateTime createdOn { get; set; }

		public string configUsed { get; set; }

		public string captureHardware { get; set; }

		public DCA1000Config DCA1000Config { get; set; }

		public string mmWaveDevice { get; set; }

		public int operatingFreq { get; set; }

		public MmWaveDeviceConfig mmWaveDeviceConfig { get; set; }

		public CapturedFiles capturedFiles { get; set; }
	}
}
