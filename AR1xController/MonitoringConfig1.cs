using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class MonitoringConfig1
	{
		public RlMonDigEnablesT rlMonDigEnables_t { get; set; }

		public RlDigMonPeriodicConfT rlDigMonPeriodicConf_t { get; set; }

		public RlMonAnaEnablesT rlMonAnaEnables_t { get; set; }

		public RlTempMonConfT rlTempMonConf_t { get; set; }

		public RlRxGainPhaseMonConfT rlRxGainPhaseMonConf_t { get; set; }

		public RlRxNoiseMonConfT rlRxNoiseMonConf_t { get; set; }

		public RlRxIfStageMonConfT rlRxIfStageMonConf_t { get; set; }

		public RlAllTxPowMonConfT rlAllTxPowMonConf_t { get; set; }

		public RlAllTxBallBreakMonCfgT rlAllTxBallBreakMonCfg_t { get; set; }

		public RlTxGainPhaseMismatchMonConfT rlTxGainPhaseMismatchMonConf_t { get; set; }

		public RlAllTxBpmMonConfT rlAllTxBpmMonConf_t { get; set; }

		public RlSynthFreqMonConfT rlSynthFreqMonConf_t { get; set; }

		public RlExtAnaSignalsMonConfT rlExtAnaSignalsMonConf_t { get; set; }

		public RlAllTxIntAnaSignalsMonConfT rlAllTxIntAnaSignalsMonConf_t { get; set; }

		public RlRxIntAnaSignalsMonConfT rlRxIntAnaSignalsMonConf_t { get; set; }

		public RlPmClkLoIntAnaSignalsMonConfT rlPmClkLoIntAnaSignalsMonConf_t { get; set; }

		public RlGpadcIntAnaSignalsMonConfT rlGpadcIntAnaSignalsMonConf_t { get; set; }

		public RlPllContrVoltMonConfT rlPllContrVoltMonConf_t { get; set; }

		public RlDualClkCompMonConfT rlDualClkCompMonConf_t { get; set; }

		public RlRxSatMonConfT rlRxSatMonConf_t { get; set; }

		public RlSigImgMonConfT rlSigImgMonConf_t { get; set; }

		public RlRxMixInPwrMonConfT rlRxMixInPwrMonConf_t { get; set; }

		public RlAnaFaultInjT rlAnaFaultInj_t { get; set; }
	}
}
