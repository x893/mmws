using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class DCA1000Config
	{
		public string dataLoggingMode { get; set; }

		public string dataTransferMode { get; set; }

		public string dataCaptureMode { get; set; }

		public int packetSequenceEnable { get; set; }

		public int packetDelay_us { get; set; }
	}
}
