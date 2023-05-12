using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class CurrentVersion
	{
		public JsonCfgVersion jsonCfgVersion { get; set; }

		public DFPVersion DFPVersion { get; set; }

		public SDKVersion SDKVersion { get; set; }

		public MmwavelinkVersion mmwavelinkVersion { get; set; }

		public int isConfigured { get; set; }
	}
}
