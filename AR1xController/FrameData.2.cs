using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class FrameData
	{
		public int numSubFrames { get; set; }

		public List<SubframeDataCfg> subframeDataCfg { get; set; }
	}
}
