using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class CapturedFiles
	{
		public int numFilesCollected { get; set; }

		public string fileBasePath { get; set; }

		public List<Files> files { get; set; }
	}
}
