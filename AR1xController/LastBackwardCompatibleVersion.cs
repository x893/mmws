using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class LastBackwardCompatibleVersion
	{
		public DFPVersion2 DFPVersion { get; set; }

		public SDKVersion2 SDKVersion { get; set; }

		public MmwavelinkVersion2 mmwavelinkVersion { get; set; }

		public int isConfigured { get; set; }
	}
}
