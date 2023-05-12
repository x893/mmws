using System.Collections.Generic;

namespace AR1xController
{
    public class FrameSeq
	{
		public int numOfSubFrames { get; set; }
		public int forceProfile { get; set; }
		public string loopBackCfg { get; set; }
		public int subFrameTrigger { get; set; }
		public List<SubFrameCfg> subFrameCfg { get; set; }
		public int numFrames { get; set; }
		public int triggerSelect { get; set; }
		public double frameTrigDelay_usec { get; set; }
	}
}
