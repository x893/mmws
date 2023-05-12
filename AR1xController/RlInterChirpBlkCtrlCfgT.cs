using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlInterChirpBlkCtrlCfgT
	{
		public double rx02RfTurnOffTime_us { get; set; }
		public double rx13RfTurnOffTime_us { get; set; }
		public double rx02BbTurnOffTime_us { get; set; }
		public double rx12BbTurnOffTime_us { get; set; }
		public double rx02RfPreEnTime_us { get; set; }
		public double rx13RfPreEnTime_us { get; set; }
		public double rx02BbPreEnTime_us { get; set; }
		public double rx13BbPreEnTime_us { get; set; }
		public double rx02RfTurnOnTime_us { get; set; }
		public double rx13RfTurnOnTime_us { get; set; }
		public double rx02BbTurnOnTime_us { get; set; }
		public double rx13BbTurnOnTime_us { get; set; }
		public double rxLoChainTurnOffTime_us { get; set; }
		public double txLoChainTurnOffTime_us { get; set; }
		public double rxLoChainTurnOnTime_us { get; set; }
		public double txLoChainTurnOnTime_us { get; set; }
		public int isConfigured { get; set; }
	}
}
