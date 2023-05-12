using System.Collections.Generic;

namespace AR1xController
{
    public class RfConfig
	{
		public string waveformType { get; set; }
		public string MIMOScheme { get; set; }
		public string rlCalibrationDataFile { get; set; }
		public RlChanCfgT rlChanCfg_t { get; set; }
		public RlAdcOutCfgT rlAdcOutCfg_t { get; set; }
		public RlLowPowerModeCfgT rlLowPowerModeCfg_t { get; set; }
		public List<RlProfiles> rlProfiles { get; set; }
		public List<RlChirps> rlChirps { get; set; }
		public RlAdvChirpCfgT rlAdvChirpCfg_t { get; set; }
		public RlRfCalMonTimeUntConfT rlRfCalMonTimeUntConf_t { get; set; }
		public RlRfCalMonFreqLimitConfT rlRfCalMonFreqLimitConf_t { get; set; }
		public RlRfInitCalConfT rlRfInitCalConf_t { get; set; }
		public RlRunTimeCalibConfT rlRunTimeCalibConf_t { get; set; }
		public RlFrameCfgT rlFrameCfg_t { get; set; }
		public RlAdvFrameCfgT rlAdvFrameCfg_t { get; set; }
		public RlContModeCfgT rlContModeCfg_t { get; set; }
		public RlContModeEnT rlContModeEn_t { get; set; }
		public c0001d2 p000010 { get; set; }
		public RlBpmKCounterSelT rlBpmKCounterSel_t { get; set; }
		public c0001d5 p000011 { get; set; }
		public List<c0001d7> p000012 { get; set; }
		public c0001d8 p000013 { get; set; }
		public RlRfMiscConfT rlRfMiscConf_t { get; set; }
		public RlRfTxFreqPwrLimitMonConfT rlRfTxFreqPwrLimitMonConf_t { get; set; }
		public RlDynPwrSaveT rlDynPwrSave_t { get; set; }
		public c0001de p000014 { get; set; }
		public List<RlRfPhaseShiftCfgT> p000015 { get; set; }
		public RlInterChirpBlkCtrlCfgT rlInterChirpBlkCtrlCfg_t { get; set; }
		public RlRfProgFiltCoeffT rlRfProgFiltCoeff_t { get; set; }
		public List<RlRfProgFiltConfT> rlRfProgFiltConfs { get; set; }
		public RlInterRxGainPhConf rlInterRxGainPhConf_t { get; set; }
		public RlTestSourceT rlTestSource_t { get; set; }
		public RlTestSourceEnableT rlTestSourceEnable_t { get; set; }
		public RlRfLdoBypassCfgT rlRfLdoBypassCfg_t { get; set; }
		public RlRfPALoopbackCfgT rlRfPALoopbackCfg_t { get; set; }
		public RlRfPSLoopbackCfgT rlRfPSLoopbackCfg_t { get; set; }
		public RlRfIFLoopbackCfgT rlRfIFLoopbackCfg_t { get; set; }
		public List<RlLoopbackBursts> rlLoopbackBursts { get; set; }
		public RllatentFaultT rllatentFault_t { get; set; }
		public RlperiodicTestT rlperiodicTest_t { get; set; }
		public RltestPatternT rltestPattern_t { get; set; }
		public List<RlDynChirpCfgs> rlDynChirpCfgs { get; set; }
		public List<RlDynPerChirpPhShftCfgs> rlDynPerChirpPhShftCfgs { get; set; }

	}
}
