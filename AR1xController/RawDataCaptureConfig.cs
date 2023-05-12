using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RawDataCaptureConfig
	{
		public RlDevDataFmtCfgT rlDevDataFmtCfg_t { get; set; }
		public RlDevDataPathCfgT rlDevDataPathCfg_t { get; set; }
		public RlDevLaneEnableT rlDevLaneEnable_t { get; set; }
		public RlDevDataPathClkCfgT rlDevDataPathClkCfg_t { get; set; }
		public RlDevLvdsLaneCfgT rlDevLvdsLaneCfg_t { get; set; }
		public RlDevCsi2CfgT rlDevCsi2Cfg_t { get; set; }
		public RlDevMiscCfgT rlDevMiscCfg_t { get; set; }
	}
}
