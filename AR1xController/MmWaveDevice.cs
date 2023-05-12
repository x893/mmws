using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class MmWaveDevice
	{
		public int mmWaveDeviceId { get; set; }

		public RfConfig rfConfig { get; set; }

		public RawDataCaptureConfig rawDataCaptureConfig { get; set; }

		public MonitoringConfig1 monitoringConfig { get; set; }
	}
}
