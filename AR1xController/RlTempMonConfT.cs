using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlTempMonConfT
	{
		public int reportMode { get; set; }

		public int anaTempThreshMin { get; set; }

		public int anaTempThreshMax { get; set; }

		public int digTempThreshMin { get; set; }

		public int digTempThreshMax { get; set; }

		public int tempDiffThresh { get; set; }

		public int isConfigured { get; set; }
	}
}
