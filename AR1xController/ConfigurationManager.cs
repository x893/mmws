using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace AR1xController
{
	public static class ConfigurationManager
	{
		private static Hashtable channelConfigManager()
		{
			ConfigurationManager.channelConfig_HT = new Hashtable();
			return ConfigurationManager.channelConfig_HT;
		}

		public static string GetChannelConfigKeyVal(string key)
		{
			return ConfigurationManager.GetChannelConfigKeyVal(key, null);
		}

		public static string GetChannelConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.channelConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.channelConfig_HT[key];
		}

		public static void SetChannelConfigKeyVal(string key, string value)
		{
			ConfigurationManager.channelConfig_HT[key] = value;
		}

		private static Hashtable adcConfigManager()
		{
			ConfigurationManager.adcConfig_HT = new Hashtable();
			return ConfigurationManager.adcConfig_HT;
		}

		public static string GetADCConfigKeyVal(string key)
		{
			return ConfigurationManager.GetADCConfigKeyVal(key, null);
		}

		public static string GetADCConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.adcConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.adcConfig_HT[key];
		}

		public static void SetADCConfigKeyVal(string key, string value)
		{
			ConfigurationManager.adcConfig_HT[key] = value;
		}

		private static Hashtable lpmodeConfigManager()
		{
			ConfigurationManager.lpConfig_HT = new Hashtable();
			return ConfigurationManager.lpConfig_HT;
		}

		public static string m000001(string key)
		{
			return ConfigurationManager.m000002(key, null);
		}

		public static string m000002(string key, string defaultValue)
		{
			if (!ConfigurationManager.lpConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.lpConfig_HT[key];
		}

		public static void m000003(string key, string value)
		{
			ConfigurationManager.lpConfig_HT[key] = value;
		}

		private static Hashtable freqLimitConfigManager()
		{
			ConfigurationManager.freqLimitConfig_HT = new Hashtable();
			return ConfigurationManager.freqLimitConfig_HT;
		}

		public static string GetfreqLimitConfigKeyVal(string key)
		{
			return ConfigurationManager.GetfreqLimitConfigKeyVal(key, null);
		}

		public static string GetfreqLimitConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.freqLimitConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.freqLimitConfig_HT[key];
		}

		public static void SetfreqLimitConfigKeyVal(string key, string value)
		{
			ConfigurationManager.freqLimitConfig_HT[key] = value;
		}

		private static Hashtable RfLdoByPassConfigManager()
		{
			ConfigurationManager.rfldobypassConfig_HT = new Hashtable();
			return ConfigurationManager.rfldobypassConfig_HT;
		}

		public static string GetRfLdoByPassConfigKeyVal(string key)
		{
			return ConfigurationManager.GetRfLdoByPassConfigKeyVal(key, null);
		}

		public static string GetRfLdoByPassConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.rfldobypassConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.rfldobypassConfig_HT[key];
		}

		public static void SetRfLdoByPassConfigKeyVal(string key, string value)
		{
			ConfigurationManager.rfldobypassConfig_HT[key] = value;
		}

		private static Hashtable radarMiscCtlConfigManager()
		{
			ConfigurationManager.radarmisccontrolConfig_HT = new Hashtable();
			return ConfigurationManager.radarmisccontrolConfig_HT;
		}

		public static string GetradarMiscCtlConfigKeyVal(string key)
		{
			return ConfigurationManager.GetradarMiscCtlConfigKeyVal(key, null);
		}

		public static string GetradarMiscCtlConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.radarmisccontrolConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.radarmisccontrolConfig_HT[key];
		}

		public static void SetradarMiscCtlConfigKeyVal(string key, string value)
		{
			ConfigurationManager.radarmisccontrolConfig_HT[key] = value;
		}

		private static Hashtable calMonFreqTxPowLimitConfigManager()
		{
			ConfigurationManager.calmonfreqtxpowlimitConfig_HT = new Hashtable();
			return ConfigurationManager.calmonfreqtxpowlimitConfig_HT;
		}

		public static string GetcalMonFreqTxPowLimitConfigKeyVal(string key)
		{
			return ConfigurationManager.GetcalMonFreqTxPowLimitConfigKeyVal(key, null);
		}

		public static string GetcalMonFreqTxPowLimitConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.calmonfreqtxpowlimitConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.calmonfreqtxpowlimitConfig_HT[key];
		}

		public static void SetcalMonFreqTxPowLimitConfigKeyVal(string key, string value)
		{
			ConfigurationManager.calmonfreqtxpowlimitConfig_HT[key] = value;
		}

		private static Hashtable dataPathConfigManager()
		{
			ConfigurationManager.dataPathConfig_HT = new Hashtable();
			return ConfigurationManager.dataPathConfig_HT;
		}

		public static string GetdataPathConfigKeyVal(string key)
		{
			return ConfigurationManager.GetdataPathConfigKeyVal(key, null);
		}

		public static string GetdataPathConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.dataPathConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.dataPathConfig_HT[key];
		}

		public static void SetdataPathConfigKeyVal(string key, string value)
		{
			ConfigurationManager.dataPathConfig_HT[key] = value;
		}

		private static Hashtable clockConfigManager()
		{
			ConfigurationManager.clockConfig_HT = new Hashtable();
			return ConfigurationManager.clockConfig_HT;
		}

		public static string GetClockConfigKeyVal(string key)
		{
			return ConfigurationManager.GetClockConfigKeyVal(key, null);
		}

		public static string GetClockConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.clockConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.clockConfig_HT[key];
		}

		public static void SetClockConfigKeyVal(string key, string value)
		{
			ConfigurationManager.clockConfig_HT[key] = value;
		}

		private static Hashtable lvdsLaneConfigManager()
		{
			ConfigurationManager.lvdsLaneConfig_HT = new Hashtable();
			return ConfigurationManager.lvdsLaneConfig_HT;
		}

		public static string GetlvdsLaneConfigKeyVal(string key)
		{
			return ConfigurationManager.GetlvdsLaneConfigKeyVal(key, null);
		}

		public static string GetlvdsLaneConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.lvdsLaneConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.lvdsLaneConfig_HT[key];
		}

		public static void SetlvdsLaneConfigKeyVal(string key, string value)
		{
			ConfigurationManager.lvdsLaneConfig_HT[key] = value;
		}

		private static Hashtable csi2ConfigManager()
		{
			ConfigurationManager.csi2Config_HT = new Hashtable();
			return ConfigurationManager.csi2Config_HT;
		}

		public static string Getcsi2ConfigKeyVal(string key)
		{
			return ConfigurationManager.Getcsi2ConfigKeyVal(key, null);
		}

		public static string Getcsi2ConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.csi2Config_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.csi2Config_HT[key];
		}

		public static void Setcsi2ConfigKeyVal(string key, string value)
		{
			ConfigurationManager.csi2Config_HT[key] = value;
		}

		private static Hashtable testPatternGenConfigManager()
		{
			ConfigurationManager.testPatternGenConfig_HT = new Hashtable();
			return ConfigurationManager.testPatternGenConfig_HT;
		}

		public static string GetTestPatternGenConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTestPatternGenConfigKeyVal(key, null);
		}

		public static string GetTestPatternGenConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.testPatternGenConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.testPatternGenConfig_HT[key];
		}

		public static void SetTestPatternGenConfigKeyVal(string key, string value)
		{
			ConfigurationManager.testPatternGenConfig_HT[key] = value;
		}

		private static Hashtable testSourceConfigManager()
		{
			ConfigurationManager.testSourceConfig_HT = new Hashtable();
			return ConfigurationManager.testSourceConfig_HT;
		}

		public static string GetTestSourceConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTestSourceConfigKeyVal(key, null);
		}

		public static string GetTestSourceConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.testSourceConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.testSourceConfig_HT[key];
		}

		public static void SetTestSourceConfigKeyVal(string key, string value)
		{
			ConfigurationManager.testSourceConfig_HT[key] = value;
		}

		private static Hashtable chirpConfigManager()
		{
			ConfigurationManager.chirpConfig_HT = new Hashtable();
			return ConfigurationManager.chirpConfig_HT;
		}

		public static string GetChirpConfigKeyVal(string key)
		{
			return ConfigurationManager.GetChirpConfigKeyVal(key, null);
		}

		public static string GetChirpConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.chirpConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.chirpConfig_HT[key];
		}

		public static void SetChirpConfigKeyVal(string key, string value)
		{
			ConfigurationManager.chirpConfig_HT[key] = value;
		}

		private static Hashtable profileConfigManager()
		{
			ConfigurationManager.profileConfig_HT = new Hashtable();
			return ConfigurationManager.profileConfig_HT;
		}

		public static string GetProfileConfigKeyVal(string key)
		{
			return ConfigurationManager.GetProfileConfigKeyVal(key, null);
		}

		public static string GetProfileConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.profileConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.profileConfig_HT[key];
		}

		public static void SetProfileConfigKeyVal(string key, string value)
		{
			ConfigurationManager.profileConfig_HT[key] = value;
		}

		private static Hashtable frameConfigManager()
		{
			ConfigurationManager.frameConfig_HT = new Hashtable();
			return ConfigurationManager.frameConfig_HT;
		}

		public static string GetFrameConfigKeyVal(string key)
		{
			return ConfigurationManager.GetFrameConfigKeyVal(key, null);
		}

		public static string GetFrameConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.frameConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.frameConfig_HT[key];
		}

		public static void SetFrameConfigKeyVal(string key, string value)
		{
			ConfigurationManager.frameConfig_HT[key] = value;
		}

		private static Hashtable advanceFrameConfigManager()
		{
			ConfigurationManager.advanceFrameConfig_HT = new Hashtable();
			return ConfigurationManager.advanceFrameConfig_HT;
		}

		public static string GetAdvanceFrameConfigKeyVal(string key)
		{
			return ConfigurationManager.GetAdvanceFrameConfigKeyVal(key, null);
		}

		public static string GetAdvanceFrameConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.advanceFrameConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.advanceFrameConfig_HT[key];
		}

		public static void SetAdvanceConfigKeyVal(string key, string value)
		{
			ConfigurationManager.advanceFrameConfig_HT[key] = value;
		}

		private static Hashtable loopBackBurstConfigManager()
		{
			ConfigurationManager.loopBackBurstConfig_HT = new Hashtable();
			return ConfigurationManager.loopBackBurstConfig_HT;
		}

		public static string GetLoopBackBurstConfigKeyVal(string key)
		{
			return ConfigurationManager.GetLoopBackBurstConfigKeyVal(key, null);
		}

		public static string GetLoopBackBurstConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.loopBackBurstConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.loopBackBurstConfig_HT[key];
		}

		public static void SetLoopBackBurstConfigKeyVal(string key, string value)
		{
			ConfigurationManager.loopBackBurstConfig_HT[key] = value;
		}

		private static Hashtable analogMonEnableConfigManager()
		{
			ConfigurationManager.analogMonEnableConfig_HT = new Hashtable();
			return ConfigurationManager.analogMonEnableConfig_HT;
		}

		public static string GetAnalogMonEnableConfigKeyVal(string key)
		{
			return ConfigurationManager.GetAnalogMonEnableConfigKeyVal(key, null);
		}

		public static string GetAnalogMonEnableConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.analogMonEnableConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.analogMonEnableConfig_HT[key];
		}

		public static void SetAnalogMonEnableConfigKeyVal(string key, string value)
		{
			ConfigurationManager.analogMonEnableConfig_HT[key] = value;
		}

		private static Hashtable tx0BallBreakConfigManager()
		{
			ConfigurationManager.tx0BallBreakConfig_HT = new Hashtable();
			return ConfigurationManager.tx0BallBreakConfig_HT;
		}

		public static string GetTx0BallBreakConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx0BallBreakConfigKeyVal(key, null);
		}

		public static string GetTx0BallBreakConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.tx0BallBreakConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.tx0BallBreakConfig_HT[key];
		}

		public static void SetTx0BallBreakConfigKeyVal(string key, string value)
		{
			ConfigurationManager.tx0BallBreakConfig_HT[key] = value;
		}

		private static Hashtable tx1BallBreakConfigManager()
		{
			ConfigurationManager.tx1BallBreakConfig_HT = new Hashtable();
			return ConfigurationManager.tx1BallBreakConfig_HT;
		}

		public static string GetTx1BallBreakConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx1BallBreakConfigKeyVal(key, null);
		}

		public static string GetTx1BallBreakConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.tx1BallBreakConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.tx1BallBreakConfig_HT[key];
		}

		public static void SetTx1BallBreakConfigKeyVal(string key, string value)
		{
			ConfigurationManager.tx1BallBreakConfig_HT[key] = value;
		}

		private static Hashtable tx2BallBreakConfigManager()
		{
			ConfigurationManager.tx2BallBreakConfig_HT = new Hashtable();
			return ConfigurationManager.tx2BallBreakConfig_HT;
		}

		public static string GetTx2BallBreakConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx0BallBreakConfigKeyVal(key, null);
		}

		public static string GetTx2BallBreakConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.tx2BallBreakConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.tx2BallBreakConfig_HT[key];
		}

		public static void SetTx2BallBreakConfigKeyVal(string key, string value)
		{
			ConfigurationManager.tx2BallBreakConfig_HT[key] = value;
		}

		private static Hashtable tx0PowerMonConfigManager()
		{
			ConfigurationManager.tx0PowerMonConfig_HT = new Hashtable();
			return ConfigurationManager.tx0PowerMonConfig_HT;
		}

		public static string GetTx0PowerMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx0PowerMonConfigKeyVal(key, null);
		}

		public static string GetTx0PowerMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.tx0PowerMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.tx0PowerMonConfig_HT[key];
		}

		public static void SetTx0PowerMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.tx0PowerMonConfig_HT[key] = value;
		}

		private static Hashtable tx1PowerMonConfigManager()
		{
			ConfigurationManager.tx1PowerMonConfig_HT = new Hashtable();
			return ConfigurationManager.tx1PowerMonConfig_HT;
		}

		public static string GetTx1PowerMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx1PowerMonConfigKeyVal(key, null);
		}

		public static string GetTx1PowerMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.tx1PowerMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.tx1PowerMonConfig_HT[key];
		}

		public static void SetTx1PowerMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.tx1PowerMonConfig_HT[key] = value;
		}

		private static Hashtable tx2PowerMonConfigManager()
		{
			ConfigurationManager.tx2PowerMonConfig_HT = new Hashtable();
			return ConfigurationManager.tx2PowerMonConfig_HT;
		}

		public static string GetTx2PowerMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx2PowerMonConfigKeyVal(key, null);
		}

		public static string GetTx2PowerMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.tx2PowerMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.tx2PowerMonConfig_HT[key];
		}

		public static void SetTx2PowerMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.tx2PowerMonConfig_HT[key] = value;
		}

		private static Hashtable tx0BPMMonConfigManager()
		{
			ConfigurationManager.f0000ed = new Hashtable();
			return ConfigurationManager.f0000ed;
		}

		public static string GetTx0BPMMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx0BPMMonConfigKeyVal(key, null);
		}

		public static string GetTx0BPMMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.f0000ed.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.f0000ed[key];
		}

		public static void SetTx0BPMMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.f0000ed[key] = value;
		}

		private static Hashtable tx1BPMMonConfigManager()
		{
			ConfigurationManager.f0000ee = new Hashtable();
			return ConfigurationManager.f0000ee;
		}

		public static string GetTx1BPMMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx1BPMMonConfigKeyVal(key, null);
		}

		public static string GetTx1BPMMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.f0000ee.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.f0000ee[key];
		}

		public static void SetTx1BPMMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.f0000ee[key] = value;
		}

		private static Hashtable tx2BPMMonConfigManager()
		{
			ConfigurationManager.f0000ef = new Hashtable();
			return ConfigurationManager.f0000ef;
		}

		public static string GetTx2BPMMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx2BPMMonConfigKeyVal(key, null);
		}

		public static string GetTx2BPMMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.f0000ef.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.f0000ef[key];
		}

		public static void SetTx2BPMMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.f0000ef[key] = value;
		}

		private static Hashtable txGainPhaseMismatchMonConfigManager()
		{
			ConfigurationManager.txGainPhaseMismatchMonConfig_HT = new Hashtable();
			return ConfigurationManager.txGainPhaseMismatchMonConfig_HT;
		}

		public static string GetTxGainPhaseMismatchMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal(key, null);
		}

		public static string GetTxGainPhaseMismatchMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.txGainPhaseMismatchMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.txGainPhaseMismatchMonConfig_HT[key];
		}

		public static void SetTxGainPhaseMismatchMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.txGainPhaseMismatchMonConfig_HT[key] = value;
		}

		private static Hashtable analogFaultInjectionConfigManager()
		{
			ConfigurationManager.analogFaultInjectionConfig_HT = new Hashtable();
			return ConfigurationManager.analogFaultInjectionConfig_HT;
		}

		public static string GetAnalogFaultInjectionConfigKeyVal(string key)
		{
			return ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal(key, null);
		}

		public static string GetAnalogFaultInjectionConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.analogFaultInjectionConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.analogFaultInjectionConfig_HT[key];
		}

		public static void SetAnalogFaultInjectionConfigKeyVal(string key, string value)
		{
			ConfigurationManager.analogFaultInjectionConfig_HT[key] = value;
		}

		private static Hashtable rxGainPhaseMonConfigManager()
		{
			ConfigurationManager.rxGainPhaseMonConfig_HT = new Hashtable();
			return ConfigurationManager.rxGainPhaseMonConfig_HT;
		}

		public static string GetRxGainPhaseMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetRxGainPhaseMonConfigKeyVal(key, null);
		}

		public static string GetRxGainPhaseMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.rxGainPhaseMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.rxGainPhaseMonConfig_HT[key];
		}

		public static void SetRxGainPhaseMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.rxGainPhaseMonConfig_HT[key] = value;
		}

		private static Hashtable rxNoiseFigureMonConfigManager()
		{
			ConfigurationManager.rxNoiseFigureMonConfig_HT = new Hashtable();
			return ConfigurationManager.rxNoiseFigureMonConfig_HT;
		}

		public static string GetRxNoiseFigureMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetRxNoiseFigureMonConfigKeyVal(key, null);
		}

		public static string GetRxNoiseFigureMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.rxNoiseFigureMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.rxNoiseFigureMonConfig_HT[key];
		}

		public static void SetRxNoiseFigureMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.rxNoiseFigureMonConfig_HT[key] = value;
		}

		private static Hashtable rxIFStageMonConfigManager()
		{
			ConfigurationManager.rxIFStageMonConfig_HT = new Hashtable();
			return ConfigurationManager.rxIFStageMonConfig_HT;
		}

		public static string GetRxIFStageMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetRxIFStageMonConfigKeyVal(key, null);
		}

		public static string GetRxIFStageMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.rxIFStageMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.rxIFStageMonConfig_HT[key];
		}

		public static void SetRxIFStageMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.rxIFStageMonConfig_HT[key] = value;
		}

		private static Hashtable rxSaturationDetectorMonConfigManager()
		{
			ConfigurationManager.rxSaturationDetectorMonConfig_HT = new Hashtable();
			return ConfigurationManager.rxSaturationDetectorMonConfig_HT;
		}

		public static string GetRxSaturationDetectorMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetRxSaturationDetectorMonConfigKeyVal(key, null);
		}

		public static string GetRxSaturationDetectorMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.rxSaturationDetectorMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.rxSaturationDetectorMonConfig_HT[key];
		}

		public static void SetRxSaturationDetectorMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.rxSaturationDetectorMonConfig_HT[key] = value;
		}

		private static Hashtable rxSignalAndImgeMonConfigManager()
		{
			ConfigurationManager.rxSignalImageMonConfig_HT = new Hashtable();
			return ConfigurationManager.rxSignalImageMonConfig_HT;
		}

		public static string GetRxSignalAndImgeMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetRxSignalAndImgeMonConfigKeyVal(key, null);
		}

		public static string GetRxSignalAndImgeMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.rxSignalImageMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.rxSignalImageMonConfig_HT[key];
		}

		public static void SetRxSignalAndImgeMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.rxSignalImageMonConfig_HT[key] = value;
		}

		private static Hashtable rxMixerInputPowerMonConfigManager()
		{
			ConfigurationManager.rxMixerInputPowerMonConfig_HT = new Hashtable();
			return ConfigurationManager.rxMixerInputPowerMonConfig_HT;
		}

		public static string GetRxMixerInputPowerMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetRxMixerInputPowerMonConfigKeyVal(key, null);
		}

		public static string GetRxMixerInputPowerMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.rxMixerInputPowerMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.rxMixerInputPowerMonConfig_HT[key];
		}

		public static void SetRxMixerInputPowerMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.rxMixerInputPowerMonConfig_HT[key] = value;
		}

		private static Hashtable rxTempMonConfigManager()
		{
			ConfigurationManager.rxTempMonConfig_HT = new Hashtable();
			return ConfigurationManager.rxTempMonConfig_HT;
		}

		public static string GetRxTempMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetRxTempMonConfigKeyVal(key, null);
		}

		public static string GetRxTempMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.rxTempMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.rxTempMonConfig_HT[key];
		}

		public static void SetRxTempMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.rxTempMonConfig_HT[key] = value;
		}

		private static Hashtable rxSynthFreqErrorMonConfigManager()
		{
			ConfigurationManager.rxSynthFreqErrorMonConfig_HT = new Hashtable();
			return ConfigurationManager.rxSynthFreqErrorMonConfig_HT;
		}

		public static string GetRxSynthFreqErrorMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetRxSynthFreqErrorMonConfigKeyVal(key, null);
		}

		public static string GetRxSynthFreqErrorMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.rxSynthFreqErrorMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.rxSynthFreqErrorMonConfig_HT[key];
		}

		public static void SetRxSynthFreqErrorMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.rxSynthFreqErrorMonConfig_HT[key] = value;
		}

		private static Hashtable rxExtAnalogSigMonConfigManager()
		{
			ConfigurationManager.rxExtAnalogSignalMonConfig_HT = new Hashtable();
			return ConfigurationManager.rxExtAnalogSignalMonConfig_HT;
		}

		public static string GetRxExtAnalogSigMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetRxExtAnalogSigMonConfigKeyVal(key, null);
		}

		public static string GetRxExtAnalogSigMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.rxExtAnalogSignalMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.rxExtAnalogSignalMonConfig_HT[key];
		}

		public static void SetRxExtAnalogSigMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.rxExtAnalogSignalMonConfig_HT[key] = value;
		}

		private static Hashtable tx0IntAnalogSigMonConfigManager()
		{
			ConfigurationManager.tx0IntAnalogSignalMonConfig_HT = new Hashtable();
			return ConfigurationManager.tx0IntAnalogSignalMonConfig_HT;
		}

		public static string GetTx0IntAnalogSigMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx0IntAnalogSigMonConfigKeyVal(key, null);
		}

		public static string GetTx0IntAnalogSigMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.tx0IntAnalogSignalMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.tx0IntAnalogSignalMonConfig_HT[key];
		}

		public static void SetTx0IntAnalogSigMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.tx0IntAnalogSignalMonConfig_HT[key] = value;
		}

		private static Hashtable tx1IntAnalogSigMonConfigManager()
		{
			ConfigurationManager.tx1IntAnalogSignalMonConfig_HT = new Hashtable();
			return ConfigurationManager.tx1IntAnalogSignalMonConfig_HT;
		}

		public static string GetTx1IntAnalogSigMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx1IntAnalogSigMonConfigKeyVal(key, null);
		}

		public static string GetTx1IntAnalogSigMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.tx1IntAnalogSignalMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.tx1IntAnalogSignalMonConfig_HT[key];
		}

		public static void SetTx1IntAnalogSigMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.tx1IntAnalogSignalMonConfig_HT[key] = value;
		}

		private static Hashtable tx2IntAnalogSigMonConfigManager()
		{
			ConfigurationManager.tx2IntAnalogSignalMonConfig_HT = new Hashtable();
			return ConfigurationManager.tx2IntAnalogSignalMonConfig_HT;
		}

		public static string GetTx2IntAnalogSigMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetTx2IntAnalogSigMonConfigKeyVal(key, null);
		}

		public static string GetTx2IntAnalogSigMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.tx2IntAnalogSignalMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.tx2IntAnalogSignalMonConfig_HT[key];
		}

		public static void SetTx2IntAnalogSigMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.tx2IntAnalogSignalMonConfig_HT[key] = value;
		}

		private static Hashtable rxIntAnalogSigMonConfigManager()
		{
			ConfigurationManager.rxIntAnalogSignalMonConfig_HT = new Hashtable();
			return ConfigurationManager.rxIntAnalogSignalMonConfig_HT;
		}

		public static string GetRxIntAnalogSigMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetRxIntAnalogSigMonConfigKeyVal(key, null);
		}

		public static string GetRxIntAnalogSigMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.rxIntAnalogSignalMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.rxIntAnalogSignalMonConfig_HT[key];
		}

		public static void SetRxIntAnalogSigMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.rxIntAnalogSignalMonConfig_HT[key] = value;
		}

		private static Hashtable PMCLKLOIntAnalogSigMonConfigManager()
		{
			ConfigurationManager.f0000f0 = new Hashtable();
			return ConfigurationManager.f0000f0;
		}

		public static string GetPMCLKLOIntAnalogSigMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetPMCLKLOIntAnalogSigMonConfigKeyVal(key, null);
		}

		public static string GetPMCLKLOIntAnalogSigMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.f0000f0.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.f0000f0[key];
		}

		public static void SetPMCLKLOIntAnalogSigMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.f0000f0[key] = value;
		}

		private static Hashtable GPADCIntAnalogSigMonConfigManager()
		{
			ConfigurationManager.GPADCIntAnalogSignalMonConfig_HT = new Hashtable();
			return ConfigurationManager.GPADCIntAnalogSignalMonConfig_HT;
		}

		public static string GetGPADCIntAnalogSigMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetGPADCIntAnalogSigMonConfigKeyVal(key, null);
		}

		public static string GetGPADCIntAnalogSigMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.GPADCIntAnalogSignalMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.GPADCIntAnalogSignalMonConfig_HT[key];
		}

		public static void SetGPADCIntAnalogSigMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.GPADCIntAnalogSignalMonConfig_HT[key] = value;
		}

		private static Hashtable pllControlVoltageMonConfigManager()
		{
			ConfigurationManager.pllControlVoltageMonConfig_HT = new Hashtable();
			return ConfigurationManager.pllControlVoltageMonConfig_HT;
		}

		public static string GetPLLControlVoltageMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetPLLControlVoltageMonConfigKeyVal(key, null);
		}

		public static string GetPLLControlVoltageMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.pllControlVoltageMonConfig_HT.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.pllControlVoltageMonConfig_HT[key];
		}

		public static void SetPLLControlVoltageMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.pllControlVoltageMonConfig_HT[key] = value;
		}

		private static Hashtable DCCMonConfigManager()
		{
			ConfigurationManager.f0000f1 = new Hashtable();
			return ConfigurationManager.f0000f1;
		}

		public static string GetDCCMonConfigKeyVal(string key)
		{
			return ConfigurationManager.GetDCCMonConfigKeyVal(key, null);
		}

		public static string GetDCCMonConfigKeyVal(string key, string defaultValue)
		{
			if (!ConfigurationManager.f0000f1.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.f0000f1[key];
		}

		public static void SetDCCMonConfigKeyVal(string key, string value)
		{
			ConfigurationManager.f0000f1[key] = value;
		}

		static ConfigurationManager()
		{
			ConfigurationManager.channelConfigManager();
			ConfigurationManager.adcConfigManager();
			ConfigurationManager.lpmodeConfigManager();
			ConfigurationManager.freqLimitConfigManager();
			ConfigurationManager.RfLdoByPassConfigManager();
			ConfigurationManager.radarMiscCtlConfigManager();
			ConfigurationManager.calMonFreqTxPowLimitConfigManager();
			ConfigurationManager.dataPathConfigManager();
			ConfigurationManager.clockConfigManager();
			ConfigurationManager.lvdsLaneConfigManager();
			ConfigurationManager.csi2ConfigManager();
			ConfigurationManager.testPatternGenConfigManager();
			ConfigurationManager.testSourceConfigManager();
			ConfigurationManager.chirpConfigManager();
			ConfigurationManager.profileConfigManager();
			ConfigurationManager.frameConfigManager();
			ConfigurationManager.advanceFrameConfigManager();
			ConfigurationManager.loopBackBurstConfigManager();
			ConfigurationManager.analogMonEnableConfigManager();
			ConfigurationManager.tx0BallBreakConfigManager();
			ConfigurationManager.tx1BallBreakConfigManager();
			ConfigurationManager.tx2BallBreakConfigManager();
			ConfigurationManager.tx0PowerMonConfigManager();
			ConfigurationManager.tx1PowerMonConfigManager();
			ConfigurationManager.tx2PowerMonConfigManager();
			ConfigurationManager.tx0BPMMonConfigManager();
			ConfigurationManager.tx1BPMMonConfigManager();
			ConfigurationManager.tx2BPMMonConfigManager();
			ConfigurationManager.txGainPhaseMismatchMonConfigManager();
			ConfigurationManager.analogFaultInjectionConfigManager();
			ConfigurationManager.rxGainPhaseMonConfigManager();
			ConfigurationManager.rxNoiseFigureMonConfigManager();
			ConfigurationManager.rxIFStageMonConfigManager();
			ConfigurationManager.rxSaturationDetectorMonConfigManager();
			ConfigurationManager.rxSignalAndImgeMonConfigManager();
			ConfigurationManager.rxMixerInputPowerMonConfigManager();
			ConfigurationManager.rxTempMonConfigManager();
			ConfigurationManager.rxSynthFreqErrorMonConfigManager();
			ConfigurationManager.rxExtAnalogSigMonConfigManager();
			ConfigurationManager.tx0IntAnalogSigMonConfigManager();
			ConfigurationManager.tx1IntAnalogSigMonConfigManager();
			ConfigurationManager.tx2IntAnalogSigMonConfigManager();
			ConfigurationManager.rxIntAnalogSigMonConfigManager();
			ConfigurationManager.PMCLKLOIntAnalogSigMonConfigManager();
			ConfigurationManager.GPADCIntAnalogSigMonConfigManager();
			ConfigurationManager.pllControlVoltageMonConfigManager();
			ConfigurationManager.DCCMonConfigManager();
		}

		public static string GetAppSetting(string key)
		{
			return ConfigurationManager.GetAppSetting(key, null);
		}

		public static string GetAppSetting(string key, string defaultValue)
		{
			if (!ConfigurationManager.appSettings.Contains(key))
			{
				return defaultValue;
			}
			return (string)ConfigurationManager.appSettings[key];
		}

		public static void SetAppSetting(string key, string value)
		{
			ConfigurationManager.appSettings[key] = value;
		}

		public static void Load(string FileName)
		{
			ConfigurationManager.appSettings.Clear();
			ConfigurationManager.channelConfig_HT.Clear();
			ConfigurationManager.adcConfig_HT.Clear();
			ConfigurationManager.lpConfig_HT.Clear();
			ConfigurationManager.freqLimitConfig_HT.Clear();
			ConfigurationManager.rfldobypassConfig_HT.Clear();
			ConfigurationManager.radarmisccontrolConfig_HT.Clear();
			ConfigurationManager.calmonfreqtxpowlimitConfig_HT.Clear();
			ConfigurationManager.dataPathConfig_HT.Clear();
			ConfigurationManager.clockConfig_HT.Clear();
			ConfigurationManager.lvdsLaneConfig_HT.Clear();
			ConfigurationManager.csi2Config_HT.Clear();
			ConfigurationManager.testPatternGenConfig_HT.Clear();
			ConfigurationManager.testSourceConfig_HT.Clear();
			ConfigurationManager.chirpConfig_HT.Clear();
			ConfigurationManager.profileConfig_HT.Clear();
			ConfigurationManager.frameConfig_HT.Clear();
			ConfigurationManager.advanceFrameConfig_HT.Clear();
			ConfigurationManager.loopBackBurstConfig_HT.Clear();
			ConfigurationManager.analogMonEnableConfig_HT.Clear();
			ConfigurationManager.tx0BallBreakConfig_HT.Clear();
			ConfigurationManager.tx1BallBreakConfig_HT.Clear();
			ConfigurationManager.tx2BallBreakConfig_HT.Clear();
			ConfigurationManager.tx0PowerMonConfig_HT.Clear();
			ConfigurationManager.tx1PowerMonConfig_HT.Clear();
			ConfigurationManager.tx2PowerMonConfig_HT.Clear();
			ConfigurationManager.f0000ed.Clear();
			ConfigurationManager.f0000ee.Clear();
			ConfigurationManager.f0000ef.Clear();
			ConfigurationManager.txGainPhaseMismatchMonConfig_HT.Clear();
			ConfigurationManager.analogFaultInjectionConfig_HT.Clear();
			ConfigurationManager.rxGainPhaseMonConfig_HT.Clear();
			ConfigurationManager.rxNoiseFigureMonConfig_HT.Clear();
			ConfigurationManager.rxIFStageMonConfig_HT.Clear();
			ConfigurationManager.rxSaturationDetectorMonConfig_HT.Clear();
			ConfigurationManager.rxSignalImageMonConfig_HT.Clear();
			ConfigurationManager.rxMixerInputPowerMonConfig_HT.Clear();
			ConfigurationManager.rxTempMonConfig_HT.Clear();
			ConfigurationManager.rxSynthFreqErrorMonConfig_HT.Clear();
			ConfigurationManager.rxExtAnalogSignalMonConfig_HT.Clear();
			ConfigurationManager.tx0IntAnalogSignalMonConfig_HT.Clear();
			ConfigurationManager.tx1IntAnalogSignalMonConfig_HT.Clear();
			ConfigurationManager.tx2IntAnalogSignalMonConfig_HT.Clear();
			ConfigurationManager.rxIntAnalogSignalMonConfig_HT.Clear();
			ConfigurationManager.f0000f0.Clear();
			ConfigurationManager.GPADCIntAnalogSignalMonConfig_HT.Clear();
			ConfigurationManager.pllControlVoltageMonConfig_HT.Clear();
			ConfigurationManager.f0000f1.Clear();
			using (XmlReader xmlReader = XmlReader.Create(FileName))
			{
				while (xmlReader.Read())
				{
					string name = xmlReader.Name;
					uint num = c00026d.ComputeStringHash(name);
					if (num <= 1675027703U)
					{
						if (num <= 545235244U)
						{
							if (num <= 265051898U)
							{
								if (num <= 79727581U)
								{
									if (num != 68230276U)
									{
										if (num == 79727581U)
										{
											if (name == "apiname_rxifstagemon_cfg")
											{
												while (xmlReader.Read())
												{
													if (xmlReader.Name == "apiname_rxifstagemon_cfg")
													{
														break;
													}
													if (xmlReader.Name == "param")
													{
														string attribute = xmlReader.GetAttribute("name");
														string attribute2 = xmlReader.GetAttribute("value");
														ConfigurationManager.rxIFStageMonConfig_HT.Add(attribute, attribute2);
													}
												}
											}
										}
									}
									else if (name == "apiname_rxsignalandimagemon_cfg")
									{
										while (xmlReader.Read())
										{
											if (xmlReader.Name == "apiname_rxsignalandimagemon_cfg")
											{
												break;
											}
											if (xmlReader.Name == "param")
											{
												string attribute3 = xmlReader.GetAttribute("name");
												string attribute4 = xmlReader.GetAttribute("value");
												ConfigurationManager.rxSignalImageMonConfig_HT.Add(attribute3, attribute4);
											}
										}
									}
								}
								else if (num != 116357985U)
								{
									if (num != 169406277U)
									{
										if (num == 265051898U)
										{
											if (name == "apiname_chirp_cfg")
											{
												while (xmlReader.Read())
												{
													if (xmlReader.Name == "apiname_chirp_cfg")
													{
														break;
													}
													if (xmlReader.Name == "param")
													{
														string attribute5 = xmlReader.GetAttribute("name");
														string attribute6 = xmlReader.GetAttribute("value");
														ConfigurationManager.chirpConfig_HT.Add(attribute5, attribute6);
													}
												}
											}
										}
									}
									else if (name == "apiname_testsource_cfg")
									{
										while (xmlReader.Read())
										{
											if (xmlReader.Name == "apiname_testsource_cfg")
											{
												break;
											}
											if (xmlReader.Name == "param")
											{
												string attribute7 = xmlReader.GetAttribute("name");
												string attribute8 = xmlReader.GetAttribute("value");
												ConfigurationManager.testSourceConfig_HT.Add(attribute7, attribute8);
											}
										}
									}
								}
								else if (name == "apiname_pllcontrolvoltagemon_cfg")
								{
									while (xmlReader.Read())
									{
										if (xmlReader.Name == "apiname_pllcontrolvoltagemon_cfg")
										{
											break;
										}
										if (xmlReader.Name == "param")
										{
											string attribute9 = xmlReader.GetAttribute("name");
											string attribute10 = xmlReader.GetAttribute("value");
											ConfigurationManager.pllControlVoltageMonConfig_HT.Add(attribute9, attribute10);
										}
									}
								}
							}
							else if (num <= 328546757U)
							{
								if (num != 283065656U)
								{
									if (num != 287505997U)
									{
										if (num == 328546757U)
										{
											if (name == "apiname_radarmisccontrol_cfg")
											{
												while (xmlReader.Read())
												{
													if (xmlReader.Name == "apiname_radarmisccontrol_cfg")
													{
														break;
													}
													if (xmlReader.Name == "param")
													{
														string attribute11 = xmlReader.GetAttribute("name");
														string attribute12 = xmlReader.GetAttribute("value");
														ConfigurationManager.radarmisccontrolConfig_HT.Add(attribute11, attribute12);
													}
												}
											}
										}
									}
									else if (name == "apiname_tx2bpmmon_cfg")
									{
										while (xmlReader.Read())
										{
											if (xmlReader.Name == "apiname_tx2bpmmon_cfg")
											{
												break;
											}
											if (xmlReader.Name == "param")
											{
												string attribute13 = xmlReader.GetAttribute("name");
												string attribute14 = xmlReader.GetAttribute("value");
												ConfigurationManager.f0000ef.Add(attribute13, attribute14);
											}
										}
									}
								}
								else if (name == "apiname_tx0ballbreak_cfg")
								{
									while (xmlReader.Read())
									{
										if (xmlReader.Name == "apiname_tx0ballbreak_cfg")
										{
											break;
										}
										if (xmlReader.Name == "param")
										{
											string attribute15 = xmlReader.GetAttribute("name");
											string attribute16 = xmlReader.GetAttribute("value");
											ConfigurationManager.tx0BallBreakConfig_HT.Add(attribute15, attribute16);
										}
									}
								}
							}
							else if (num != 359849571U)
							{
								if (num != 500166558U)
								{
									if (num == 545235244U)
									{
										if (name == "apiname_tx1bpmmon_cfg")
										{
											while (xmlReader.Read())
											{
												if (xmlReader.Name == "apiname_tx1bpmmon_cfg")
												{
													break;
												}
												if (xmlReader.Name == "param")
												{
													string attribute17 = xmlReader.GetAttribute("name");
													string attribute18 = xmlReader.GetAttribute("value");
													ConfigurationManager.f0000ee.Add(attribute17, attribute18);
												}
											}
										}
									}
								}
								else if (name == "apiname_rxtemperaturemon_cfg")
								{
									while (xmlReader.Read())
									{
										if (xmlReader.Name == "apiname_rxtemperaturemon_cfg")
										{
											break;
										}
										if (xmlReader.Name == "param")
										{
											string attribute19 = xmlReader.GetAttribute("name");
											string attribute20 = xmlReader.GetAttribute("value");
											ConfigurationManager.rxTempMonConfig_HT.Add(attribute19, attribute20);
										}
									}
								}
							}
							else if (name == "apiname_tx0bpmmon_cfg")
							{
								while (xmlReader.Read())
								{
									if (xmlReader.Name == "apiname_tx0bpmmon_cfg")
									{
										break;
									}
									if (xmlReader.Name == "param")
									{
										string attribute21 = xmlReader.GetAttribute("name");
										string attribute22 = xmlReader.GetAttribute("value");
										ConfigurationManager.f0000ed.Add(attribute21, attribute22);
									}
								}
							}
						}
						else if (num <= 1117803290U)
						{
							if (num <= 786669241U)
							{
								if (num != 755274731U)
								{
									if (num != 782607304U)
									{
										if (num == 786669241U)
										{
											if (name == "apiname_calmonfreqtxpowlimit_cfg")
											{
												while (xmlReader.Read())
												{
													if (xmlReader.Name == "apiname_calmonfreqtxpowlimit_cfg")
													{
														break;
													}
													if (xmlReader.Name == "param")
													{
														string attribute23 = xmlReader.GetAttribute("name");
														string attribute24 = xmlReader.GetAttribute("value");
														ConfigurationManager.calmonfreqtxpowlimitConfig_HT.Add(attribute23, attribute24);
													}
												}
											}
										}
									}
									else if (name == "apiname_rxsaturationdetectormon_cfg")
									{
										while (xmlReader.Read())
										{
											if (xmlReader.Name == "apiname_rxsaturationdetectormon_cfg")
											{
												break;
											}
											if (xmlReader.Name == "param")
											{
												string attribute25 = xmlReader.GetAttribute("name");
												string attribute26 = xmlReader.GetAttribute("value");
												ConfigurationManager.rxSaturationDetectorMonConfig_HT.Add(attribute25, attribute26);
											}
										}
									}
								}
								else if (name == "apiname_frame_cfg")
								{
									while (xmlReader.Read())
									{
										if (xmlReader.Name == "apiname_frame_cfg")
										{
											break;
										}
										if (xmlReader.Name == "param")
										{
											string attribute27 = xmlReader.GetAttribute("name");
											string attribute28 = xmlReader.GetAttribute("value");
											ConfigurationManager.frameConfig_HT.Add(attribute27, attribute28);
										}
									}
								}
							}
							else if (num != 1018856367U)
							{
								if (num != 1041548484U)
								{
									if (num == 1117803290U)
									{
										if (name == "apiname_rxgainphasemon_cfg")
										{
											while (xmlReader.Read())
											{
												if (xmlReader.Name == "apiname_rxgainphasemon_cfg")
												{
													break;
												}
												if (xmlReader.Name == "param")
												{
													string attribute29 = xmlReader.GetAttribute("name");
													string attribute30 = xmlReader.GetAttribute("value");
													ConfigurationManager.rxGainPhaseMonConfig_HT.Add(attribute29, attribute30);
												}
											}
										}
									}
								}
								else if (name == "apiname_gpadcintanalogsignalmon_cfg")
								{
									while (xmlReader.Read())
									{
										if (xmlReader.Name == "apiname_gpadcintanalogsignalmon_cfg")
										{
											break;
										}
										if (xmlReader.Name == "param")
										{
											string attribute31 = xmlReader.GetAttribute("name");
											string attribute32 = xmlReader.GetAttribute("value");
											ConfigurationManager.GPADCIntAnalogSignalMonConfig_HT.Add(attribute31, attribute32);
										}
									}
								}
							}
							else if (name == "apiname_tx0intanalogsignalmon_cfg")
							{
								while (xmlReader.Read())
								{
									if (xmlReader.Name == "apiname_tx0intanalogsignalmon_cfg")
									{
										break;
									}
									if (xmlReader.Name == "param")
									{
										string attribute33 = xmlReader.GetAttribute("name");
										string attribute34 = xmlReader.GetAttribute("value");
										ConfigurationManager.tx0IntAnalogSignalMonConfig_HT.Add(attribute33, attribute34);
									}
								}
							}
						}
						else if (num <= 1550112811U)
						{
							if (num != 1481304004U)
							{
								if (num != 1523788136U)
								{
									if (num == 1550112811U)
									{
										if (name == "apiname_profile_cfg")
										{
											while (xmlReader.Read())
											{
												if (xmlReader.Name == "apiname_profile_cfg")
												{
													break;
												}
												if (xmlReader.Name == "param")
												{
													string attribute35 = xmlReader.GetAttribute("name");
													string attribute36 = xmlReader.GetAttribute("value");
													ConfigurationManager.profileConfig_HT.Add(attribute35, attribute36);
												}
											}
										}
									}
								}
								else if (name == "apiname_rxmixerinputpowermon_cfg")
								{
									while (xmlReader.Read())
									{
										if (xmlReader.Name == "apiname_rxmixerinputpowermon_cfg")
										{
											break;
										}
										if (xmlReader.Name == "param")
										{
											string attribute37 = xmlReader.GetAttribute("name");
											string attribute38 = xmlReader.GetAttribute("value");
											ConfigurationManager.rxMixerInputPowerMonConfig_HT.Add(attribute37, attribute38);
										}
									}
								}
							}
							else if (name == "apiname_txgainphasemismatchmon_cfg")
							{
								while (xmlReader.Read())
								{
									if (xmlReader.Name == "apiname_txgainphasemismatchmon_cfg")
									{
										break;
									}
									if (xmlReader.Name == "param")
									{
										string attribute39 = xmlReader.GetAttribute("name");
										string attribute40 = xmlReader.GetAttribute("value");
										ConfigurationManager.txGainPhaseMismatchMonConfig_HT.Add(attribute39, attribute40);
									}
								}
							}
						}
						else if (num != 1624747129U)
						{
							if (num != 1646633332U)
							{
								if (num == 1675027703U)
								{
									if (name == "apiname_pmclklointanalogsignalmon_cfg")
									{
										while (xmlReader.Read())
										{
											if (xmlReader.Name == "apiname_pmclklointanalogsignalmon_cfg")
											{
												break;
											}
											if (xmlReader.Name == "param")
											{
												string attribute41 = xmlReader.GetAttribute("name");
												string attribute42 = xmlReader.GetAttribute("value");
												ConfigurationManager.f0000f0.Add(attribute41, attribute42);
											}
										}
									}
								}
							}
							else if (name == "apiname_adc_cfg")
							{
								while (xmlReader.Read())
								{
									if (xmlReader.Name == "apiname_adc_cfg")
									{
										break;
									}
									if (xmlReader.Name == "param")
									{
										string attribute43 = xmlReader.GetAttribute("name");
										string attribute44 = xmlReader.GetAttribute("value");
										ConfigurationManager.adcConfig_HT.Add(attribute43, attribute44);
									}
								}
							}
						}
						else if (name == "apiname_rxextanalogsignalmon_cfg")
						{
							while (xmlReader.Read())
							{
								if (xmlReader.Name == "apiname_rxextanalogsignalmon_cfg")
								{
									break;
								}
								if (xmlReader.Name == "param")
								{
									string attribute45 = xmlReader.GetAttribute("name");
									string attribute46 = xmlReader.GetAttribute("value");
									ConfigurationManager.rxExtAnalogSignalMonConfig_HT.Add(attribute45, attribute46);
								}
							}
						}
					}
					else if (num <= 2819952635U)
					{
						if (num <= 2285494187U)
						{
							if (num <= 1893932414U)
							{
								if (num != 1803856371U)
								{
									if (num != 1829365388U)
									{
										if (num == 1893932414U)
										{
											if (name == "apiname_rxnoisefiguremon_cfg")
											{
												while (xmlReader.Read())
												{
													if (xmlReader.Name == "apiname_rxnoisefiguremon_cfg")
													{
														break;
													}
													if (xmlReader.Name == "param")
													{
														string attribute47 = xmlReader.GetAttribute("name");
														string attribute48 = xmlReader.GetAttribute("value");
														ConfigurationManager.rxNoiseFigureMonConfig_HT.Add(attribute47, attribute48);
													}
												}
											}
										}
									}
									else if (name == "apiname_lp_cfg")
									{
										while (xmlReader.Read())
										{
											if (xmlReader.Name == "apiname_lp_cfg")
											{
												break;
											}
											if (xmlReader.Name == "param")
											{
												string attribute49 = xmlReader.GetAttribute("name");
												string attribute50 = xmlReader.GetAttribute("value");
												ConfigurationManager.lpConfig_HT.Add(attribute49, attribute50);
											}
										}
									}
								}
								else if (name == "apiname_datapath_cfg")
								{
									while (xmlReader.Read())
									{
										if (xmlReader.Name == "apiname_datapath_cfg")
										{
											break;
										}
										if (xmlReader.Name == "param")
										{
											string attribute51 = xmlReader.GetAttribute("name");
											string attribute52 = xmlReader.GetAttribute("value");
											ConfigurationManager.dataPathConfig_HT.Add(attribute51, attribute52);
										}
									}
								}
							}
							else if (num != 2019204335U)
							{
								if (num != 2253212313U)
								{
									if (num == 2285494187U)
									{
										if (name == "apiname_rxintanalogsignalmon_cfg")
										{
											while (xmlReader.Read())
											{
												if (xmlReader.Name == "apiname_rxintanalogsignalmon_cfg")
												{
													break;
												}
												if (xmlReader.Name == "param")
												{
													string attribute53 = xmlReader.GetAttribute("name");
													string attribute54 = xmlReader.GetAttribute("value");
													ConfigurationManager.rxIntAnalogSignalMonConfig_HT.Add(attribute53, attribute54);
												}
											}
										}
									}
								}
								else if (name == "apiname_tx2intanalogsignalmon_cfg")
								{
									while (xmlReader.Read())
									{
										if (xmlReader.Name == "apiname_tx2intanalogsignalmon_cfg")
										{
											break;
										}
										if (xmlReader.Name == "param")
										{
											string attribute55 = xmlReader.GetAttribute("name");
											string attribute56 = xmlReader.GetAttribute("value");
											ConfigurationManager.tx2IntAnalogSignalMonConfig_HT.Add(attribute55, attribute56);
										}
									}
								}
							}
							else if (name == "apiname_freqlimit_cfg")
							{
								while (xmlReader.Read())
								{
									if (xmlReader.Name == "apiname_freqlimit_cfg")
									{
										break;
									}
									if (xmlReader.Name == "param")
									{
										string attribute57 = xmlReader.GetAttribute("name");
										string attribute58 = xmlReader.GetAttribute("value");
										ConfigurationManager.freqLimitConfig_HT.Add(attribute57, attribute58);
									}
								}
							}
						}
						else if (num <= 2520107725U)
						{
							if (num != 2303883711U)
							{
								if (num != 2400828913U)
								{
									if (num == 2520107725U)
									{
										if (name == "apiname_tx2powermon_cfg")
										{
											while (xmlReader.Read())
											{
												if (xmlReader.Name == "apiname_tx2powermon_cfg")
												{
													break;
												}
												if (xmlReader.Name == "param")
												{
													string attribute59 = xmlReader.GetAttribute("name");
													string attribute60 = xmlReader.GetAttribute("value");
													ConfigurationManager.tx2PowerMonConfig_HT.Add(attribute59, attribute60);
												}
											}
										}
									}
								}
								else if (name == "apiname_lvdslane_cfg")
								{
									while (xmlReader.Read())
									{
										if (xmlReader.Name == "apiname_lvdslane_cfg")
										{
											break;
										}
										if (xmlReader.Name == "param")
										{
											string attribute61 = xmlReader.GetAttribute("name");
											string attribute62 = xmlReader.GetAttribute("value");
											ConfigurationManager.lvdsLaneConfig_HT.Add(attribute61, attribute62);
										}
									}
								}
							}
							else if (name == "apiname_loopbackburst_cfg")
							{
								while (xmlReader.Read())
								{
									if (xmlReader.Name == "apiname_loopbackburst_cfg")
									{
										break;
									}
									if (xmlReader.Name == "param")
									{
										string attribute63 = xmlReader.GetAttribute("name");
										string attribute64 = xmlReader.GetAttribute("value");
										ConfigurationManager.loopBackBurstConfig_HT.Add(attribute63, attribute64);
									}
								}
							}
						}
						else if (num != 2601264880U)
						{
							if (num != 2604756587U)
							{
								if (num == 2819952635U)
								{
									if (name == "apiname_tx0powermon_cfg")
									{
										while (xmlReader.Read())
										{
											if (xmlReader.Name == "apiname_tx0powermon_cfg")
											{
												break;
											}
											if (xmlReader.Name == "param")
											{
												string attribute65 = xmlReader.GetAttribute("name");
												string attribute66 = xmlReader.GetAttribute("value");
												ConfigurationManager.tx0PowerMonConfig_HT.Add(attribute65, attribute66);
											}
										}
									}
								}
							}
							else if (name == "apiname_advanceframe_cfg")
							{
								while (xmlReader.Read())
								{
									if (xmlReader.Name == "apiname_advanceframe_cfg")
									{
										break;
									}
									if (xmlReader.Name == "param")
									{
										string attribute67 = xmlReader.GetAttribute("name");
										string attribute68 = xmlReader.GetAttribute("value");
										ConfigurationManager.advanceFrameConfig_HT.Add(attribute67, attribute68);
									}
								}
							}
						}
						else if (name == "apiname_dccmon_cfg")
						{
							while (xmlReader.Read() && !(xmlReader.Name == "apiname_dccmon_cfg"))
							{
								if (xmlReader.Name == "param")
								{
									string attribute69 = xmlReader.GetAttribute("name");
									string attribute70 = xmlReader.GetAttribute("value");
									ConfigurationManager.f0000f1.Add(attribute69, attribute70);
								}
							}
						}
					}
					else if (num <= 3280253392U)
					{
						if (num <= 2967111240U)
						{
							if (num != 2829431299U)
							{
								if (num != 2892414325U)
								{
									if (num == 2967111240U)
									{
										if (name == "apiname_tx1intanalogsignalmon_cfg")
										{
											while (xmlReader.Read())
											{
												if (xmlReader.Name == "apiname_tx1intanalogsignalmon_cfg")
												{
													break;
												}
												if (xmlReader.Name == "param")
												{
													string attribute71 = xmlReader.GetAttribute("name");
													string attribute72 = xmlReader.GetAttribute("value");
													ConfigurationManager.tx1IntAnalogSignalMonConfig_HT.Add(attribute71, attribute72);
												}
											}
										}
									}
								}
								else if (name == "apiname_tx1ballbreak_cfg")
								{
									while (xmlReader.Read())
									{
										if (xmlReader.Name == "apiname_tx1ballbreak_cfg")
										{
											break;
										}
										if (xmlReader.Name == "param")
										{
											string attribute73 = xmlReader.GetAttribute("name");
											string attribute74 = xmlReader.GetAttribute("value");
											ConfigurationManager.tx1BallBreakConfig_HT.Add(attribute73, attribute74);
										}
									}
								}
							}
							else if (name == "apiname_rfldobypass_cfg")
							{
								while (xmlReader.Read())
								{
									if (xmlReader.Name == "apiname_rfldobypass_cfg")
									{
										break;
									}
									if (xmlReader.Name == "param")
									{
										string attribute75 = xmlReader.GetAttribute("name");
										string attribute76 = xmlReader.GetAttribute("value");
										ConfigurationManager.rfldobypassConfig_HT.Add(attribute75, attribute76);
									}
								}
							}
						}
						else if (num != 3150708220U)
						{
							if (num != 3219717980U)
							{
								if (num == 3280253392U)
								{
									if (name == "apiname_tx1powermon_cfg")
									{
										while (xmlReader.Read())
										{
											if (xmlReader.Name == "apiname_tx1powermon_cfg")
											{
												break;
											}
											if (xmlReader.Name == "param")
											{
												string attribute77 = xmlReader.GetAttribute("name");
												string attribute78 = xmlReader.GetAttribute("value");
												ConfigurationManager.tx1PowerMonConfig_HT.Add(attribute77, attribute78);
											}
										}
									}
								}
							}
							else if (name == "apiname_rxsynthfreqerrormon_cfg")
							{
								while (xmlReader.Read())
								{
									if (xmlReader.Name == "apiname_rxsynthfreqerrormon_cfg")
									{
										break;
									}
									if (xmlReader.Name == "param")
									{
										string attribute79 = xmlReader.GetAttribute("name");
										string attribute80 = xmlReader.GetAttribute("value");
										ConfigurationManager.rxSynthFreqErrorMonConfig_HT.Add(attribute79, attribute80);
									}
								}
							}
						}
						else if (name == "apiname_testpatterngen_cfg")
						{
							while (xmlReader.Read())
							{
								if (xmlReader.Name == "apiname_testpatterngen_cfg")
								{
									break;
								}
								if (xmlReader.Name == "param")
								{
									string attribute81 = xmlReader.GetAttribute("name");
									string attribute82 = xmlReader.GetAttribute("value");
									ConfigurationManager.testPatternGenConfig_HT.Add(attribute81, attribute82);
								}
							}
						}
					}
					else if (num <= 3492348625U)
					{
						if (num != 3382507437U)
						{
							if (num != 3464096043U)
							{
								if (num == 3492348625U)
								{
									if (name == "apiname_channel_cfg")
									{
										while (xmlReader.Read())
										{
											if (xmlReader.Name == "apiname_channel_cfg")
											{
												break;
											}
											if (xmlReader.Name == "param")
											{
												string attribute83 = xmlReader.GetAttribute("name");
												string attribute84 = xmlReader.GetAttribute("value");
												ConfigurationManager.channelConfig_HT.Add(attribute83, attribute84);
											}
										}
									}
								}
							}
							else if (name == "apiname_csi2lane_cfg")
							{
								while (xmlReader.Read())
								{
									if (xmlReader.Name == "apiname_csi2lane_cfg")
									{
										break;
									}
									if (xmlReader.Name == "param")
									{
										string attribute85 = xmlReader.GetAttribute("name");
										string attribute86 = xmlReader.GetAttribute("value");
										ConfigurationManager.csi2Config_HT.Add(attribute85, attribute86);
									}
								}
							}
						}
						else if (name == "apiname_analogfaultinjection_cfg")
						{
							while (xmlReader.Read())
							{
								if (xmlReader.Name == "apiname_analogfaultinjection_cfg")
								{
									break;
								}
								if (xmlReader.Name == "param")
								{
									string attribute87 = xmlReader.GetAttribute("name");
									string attribute88 = xmlReader.GetAttribute("value");
									ConfigurationManager.analogFaultInjectionConfig_HT.Add(attribute87, attribute88);
								}
							}
						}
					}
					else if (num != 3794617136U)
					{
						if (num != 3826942186U)
						{
							if (num == 4249483755U)
							{
								if (name == "apiname_analogmonenable_cfg")
								{
									while (xmlReader.Read())
									{
										if (xmlReader.Name == "apiname_analogmonenable_cfg")
										{
											break;
										}
										if (xmlReader.Name == "param")
										{
											string attribute89 = xmlReader.GetAttribute("name");
											string attribute90 = xmlReader.GetAttribute("value");
											ConfigurationManager.analogMonEnableConfig_HT.Add(attribute89, attribute90);
										}
									}
								}
							}
						}
						else if (name == "apiname_tx2ballbreak_cfg")
						{
							while (xmlReader.Read())
							{
								if (xmlReader.Name == "apiname_tx2ballbreak_cfg")
								{
									break;
								}
								if (xmlReader.Name == "param")
								{
									string attribute91 = xmlReader.GetAttribute("name");
									string attribute92 = xmlReader.GetAttribute("value");
									ConfigurationManager.tx2BallBreakConfig_HT.Add(attribute91, attribute92);
								}
							}
						}
					}
					else if (name == "apiname_clock_cfg")
					{
						while (xmlReader.Read())
						{
							if (xmlReader.Name == "apiname_clock_cfg")
							{
								break;
							}
							if (xmlReader.Name == "param")
							{
								string attribute93 = xmlReader.GetAttribute("name");
								string attribute94 = xmlReader.GetAttribute("value");
								ConfigurationManager.clockConfig_HT.Add(attribute93, attribute94);
							}
						}
					}
				}
			}
		}

		public static void Save(string FileName)
		{
			using (StreamWriter streamWriter = new StreamWriter(FileName))
			{
				streamWriter.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
				streamWriter.WriteLine("<configuration>");
				streamWriter.WriteLine("\t<apiname_channel_cfg>");
				foreach (object obj in ConfigurationManager.channelConfig_HT)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					string value = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry.Key,
						"\" value=\"",
						dictionaryEntry.Value,
						"\" />"
					});
					streamWriter.WriteLine(value);
				}
				streamWriter.WriteLine("\t</apiname_channel_cfg>");
				streamWriter.WriteLine("\t<apiname_adc_cfg>");
				foreach (object obj2 in ConfigurationManager.adcConfig_HT)
				{
					DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
					string value2 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry2.Key,
						"\" value=\"",
						dictionaryEntry2.Value,
						"\" />"
					});
					streamWriter.WriteLine(value2);
				}
				streamWriter.WriteLine("\t</apiname_adc_cfg>");
				streamWriter.WriteLine("\t<apiname_lp_cfg>");
				foreach (object obj3 in ConfigurationManager.lpConfig_HT)
				{
					DictionaryEntry dictionaryEntry3 = (DictionaryEntry)obj3;
					string value3 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry3.Key,
						"\" value=\"",
						dictionaryEntry3.Value,
						"\" />"
					});
					streamWriter.WriteLine(value3);
				}
				streamWriter.WriteLine("\t</apiname_lp_cfg>");
				streamWriter.WriteLine("\t<apiname_freqlimit_cfg>");
				foreach (object obj4 in ConfigurationManager.freqLimitConfig_HT)
				{
					DictionaryEntry dictionaryEntry4 = (DictionaryEntry)obj4;
					string value4 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry4.Key,
						"\" value=\"",
						dictionaryEntry4.Value,
						"\" />"
					});
					streamWriter.WriteLine(value4);
				}
				streamWriter.WriteLine("\t</apiname_freqlimit_cfg>");
				streamWriter.WriteLine("\t<apiname_rfldobypass_cfg>");
				foreach (object obj5 in ConfigurationManager.rfldobypassConfig_HT)
				{
					DictionaryEntry dictionaryEntry5 = (DictionaryEntry)obj5;
					string value5 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry5.Key,
						"\" value=\"",
						dictionaryEntry5.Value,
						"\" />"
					});
					streamWriter.WriteLine(value5);
				}
				streamWriter.WriteLine("\t</apiname_rfldobypass_cfg>");
				streamWriter.WriteLine("\t<apiname_radarmisccontrol_cfg>");
				foreach (object obj6 in ConfigurationManager.radarmisccontrolConfig_HT)
				{
					DictionaryEntry dictionaryEntry6 = (DictionaryEntry)obj6;
					string value6 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry6.Key,
						"\" value=\"",
						dictionaryEntry6.Value,
						"\" />"
					});
					streamWriter.WriteLine(value6);
				}
				streamWriter.WriteLine("\t</apiname_radarmisccontrol_cfg>");
				streamWriter.WriteLine("\t<apiname_calmonfreqtxpowlimit_cfg>");
				foreach (object obj7 in ConfigurationManager.calmonfreqtxpowlimitConfig_HT)
				{
					DictionaryEntry dictionaryEntry7 = (DictionaryEntry)obj7;
					string value7 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry7.Key,
						"\" value=\"",
						dictionaryEntry7.Value,
						"\" />"
					});
					streamWriter.WriteLine(value7);
				}
				streamWriter.WriteLine("\t</apiname_calmonfreqtxpowlimit_cfg>");
				streamWriter.WriteLine("\t<apiname_datapath_cfg>");
				foreach (object obj8 in ConfigurationManager.dataPathConfig_HT)
				{
					DictionaryEntry dictionaryEntry8 = (DictionaryEntry)obj8;
					string value8 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry8.Key,
						"\" value=\"",
						dictionaryEntry8.Value,
						"\" />"
					});
					streamWriter.WriteLine(value8);
				}
				streamWriter.WriteLine("\t</apiname_datapath_cfg>");
				streamWriter.WriteLine("\t<apiname_clock_cfg>");
				foreach (object obj9 in ConfigurationManager.clockConfig_HT)
				{
					DictionaryEntry dictionaryEntry9 = (DictionaryEntry)obj9;
					string value9 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry9.Key,
						"\" value=\"",
						dictionaryEntry9.Value,
						"\" />"
					});
					streamWriter.WriteLine(value9);
				}
				streamWriter.WriteLine("\t</apiname_clock_cfg>");
				streamWriter.WriteLine("\t<apiname_lvdslane_cfg>");
				foreach (object obj10 in ConfigurationManager.lvdsLaneConfig_HT)
				{
					DictionaryEntry dictionaryEntry10 = (DictionaryEntry)obj10;
					string value10 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry10.Key,
						"\" value=\"",
						dictionaryEntry10.Value,
						"\" />"
					});
					streamWriter.WriteLine(value10);
				}
				streamWriter.WriteLine("\t</apiname_lvdslane_cfg>");
				streamWriter.WriteLine("\t<apiname_csi2lane_cfg>");
				foreach (object obj11 in ConfigurationManager.csi2Config_HT)
				{
					DictionaryEntry dictionaryEntry11 = (DictionaryEntry)obj11;
					string value11 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry11.Key,
						"\" value=\"",
						dictionaryEntry11.Value,
						"\" />"
					});
					streamWriter.WriteLine(value11);
				}
				streamWriter.WriteLine("\t</apiname_csi2lane_cfg>");
				streamWriter.WriteLine("\t<apiname_testpatterngen_cfg>");
				foreach (object obj12 in ConfigurationManager.testPatternGenConfig_HT)
				{
					DictionaryEntry dictionaryEntry12 = (DictionaryEntry)obj12;
					string value12 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry12.Key,
						"\" value=\"",
						dictionaryEntry12.Value,
						"\" />"
					});
					streamWriter.WriteLine(value12);
				}
				streamWriter.WriteLine("\t</apiname_testpatterngen_cfg>");
				streamWriter.WriteLine("\t<apiname_testsource_cfg>");
				foreach (object obj13 in ConfigurationManager.testSourceConfig_HT)
				{
					DictionaryEntry dictionaryEntry13 = (DictionaryEntry)obj13;
					string value13 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry13.Key,
						"\" value=\"",
						dictionaryEntry13.Value,
						"\" />"
					});
					streamWriter.WriteLine(value13);
				}
				streamWriter.WriteLine("\t</apiname_testsource_cfg>");
				streamWriter.WriteLine("\t<apiname_profile_cfg>");
				foreach (object obj14 in ConfigurationManager.profileConfig_HT)
				{
					DictionaryEntry dictionaryEntry14 = (DictionaryEntry)obj14;
					string value14 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry14.Key,
						"\" value=\"",
						dictionaryEntry14.Value,
						"\" />"
					});
					streamWriter.WriteLine(value14);
				}
				streamWriter.WriteLine("\t</apiname_profile_cfg>");
				streamWriter.WriteLine("\t<apiname_chirp_cfg>");
				foreach (object obj15 in ConfigurationManager.chirpConfig_HT)
				{
					DictionaryEntry dictionaryEntry15 = (DictionaryEntry)obj15;
					string value15 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry15.Key,
						"\" value=\"",
						dictionaryEntry15.Value,
						"\" />"
					});
					streamWriter.WriteLine(value15);
				}
				streamWriter.WriteLine("\t</apiname_chirp_cfg>");
				streamWriter.WriteLine("\t<apiname_frame_cfg>");
				foreach (object obj16 in ConfigurationManager.frameConfig_HT)
				{
					DictionaryEntry dictionaryEntry16 = (DictionaryEntry)obj16;
					string value16 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry16.Key,
						"\" value=\"",
						dictionaryEntry16.Value,
						"\" />"
					});
					streamWriter.WriteLine(value16);
				}
				streamWriter.WriteLine("\t</apiname_frame_cfg>");
				streamWriter.WriteLine("\t<apiname_advanceframe_cfg>");
				foreach (object obj17 in ConfigurationManager.advanceFrameConfig_HT)
				{
					DictionaryEntry dictionaryEntry17 = (DictionaryEntry)obj17;
					string value17 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry17.Key,
						"\" value=\"",
						dictionaryEntry17.Value,
						"\" />"
					});
					streamWriter.WriteLine(value17);
				}
				streamWriter.WriteLine("\t</apiname_advanceframe_cfg>");
				streamWriter.WriteLine("\t<apiname_loopbackburst_cfg>");
				foreach (object obj18 in ConfigurationManager.loopBackBurstConfig_HT)
				{
					DictionaryEntry dictionaryEntry18 = (DictionaryEntry)obj18;
					string value18 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry18.Key,
						"\" value=\"",
						dictionaryEntry18.Value,
						"\" />"
					});
					streamWriter.WriteLine(value18);
				}
				streamWriter.WriteLine("\t</apiname_loopbackburst_cfg>");
				streamWriter.WriteLine("\t<apiname_analogmonenable_cfg>");
				foreach (object obj19 in ConfigurationManager.analogMonEnableConfig_HT)
				{
					DictionaryEntry dictionaryEntry19 = (DictionaryEntry)obj19;
					string value19 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry19.Key,
						"\" value=\"",
						dictionaryEntry19.Value,
						"\" />"
					});
					streamWriter.WriteLine(value19);
				}
				streamWriter.WriteLine("\t</apiname_analogmonenable_cfg>");
				streamWriter.WriteLine("\t<apiname_tx0ballbreak_cfg>");
				foreach (object obj20 in ConfigurationManager.tx0BallBreakConfig_HT)
				{
					DictionaryEntry dictionaryEntry20 = (DictionaryEntry)obj20;
					string value20 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry20.Key,
						"\" value=\"",
						dictionaryEntry20.Value,
						"\" />"
					});
					streamWriter.WriteLine(value20);
				}
				streamWriter.WriteLine("\t</apiname_tx0ballbreak_cfg>");
				streamWriter.WriteLine("\t<apiname_tx1ballbreak_cfg>");
				foreach (object obj21 in ConfigurationManager.tx1BallBreakConfig_HT)
				{
					DictionaryEntry dictionaryEntry21 = (DictionaryEntry)obj21;
					string value21 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry21.Key,
						"\" value=\"",
						dictionaryEntry21.Value,
						"\" />"
					});
					streamWriter.WriteLine(value21);
				}
				streamWriter.WriteLine("\t</apiname_tx1ballbreak_cfg>");
				streamWriter.WriteLine("\t<apiname_tx2ballbreak_cfg>");
				foreach (object obj22 in ConfigurationManager.tx2BallBreakConfig_HT)
				{
					DictionaryEntry dictionaryEntry22 = (DictionaryEntry)obj22;
					string value22 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry22.Key,
						"\" value=\"",
						dictionaryEntry22.Value,
						"\" />"
					});
					streamWriter.WriteLine(value22);
				}
				streamWriter.WriteLine("\t</apiname_tx2ballbreak_cfg>");
				streamWriter.WriteLine("\t<apiname_tx0powermon_cfg>");
				foreach (object obj23 in ConfigurationManager.tx0PowerMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry23 = (DictionaryEntry)obj23;
					string value23 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry23.Key,
						"\" value=\"",
						dictionaryEntry23.Value,
						"\" />"
					});
					streamWriter.WriteLine(value23);
				}
				streamWriter.WriteLine("\t</apiname_tx0powermon_cfg>");
				streamWriter.WriteLine("\t<apiname_tx1powermon_cfg>");
				foreach (object obj24 in ConfigurationManager.tx1PowerMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry24 = (DictionaryEntry)obj24;
					string value24 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry24.Key,
						"\" value=\"",
						dictionaryEntry24.Value,
						"\" />"
					});
					streamWriter.WriteLine(value24);
				}
				streamWriter.WriteLine("\t</apiname_tx1powermon_cfg>");
				streamWriter.WriteLine("\t<apiname_tx2powermon_cfg>");
				foreach (object obj25 in ConfigurationManager.tx2PowerMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry25 = (DictionaryEntry)obj25;
					string value25 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry25.Key,
						"\" value=\"",
						dictionaryEntry25.Value,
						"\" />"
					});
					streamWriter.WriteLine(value25);
				}
				streamWriter.WriteLine("\t</apiname_tx2powermon_cfg>");
				streamWriter.WriteLine("\t<apiname_tx0bpmmon_cfg>");
				foreach (object obj26 in ConfigurationManager.f0000ed)
				{
					DictionaryEntry dictionaryEntry26 = (DictionaryEntry)obj26;
					string value26 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry26.Key,
						"\" value=\"",
						dictionaryEntry26.Value,
						"\" />"
					});
					streamWriter.WriteLine(value26);
				}
				streamWriter.WriteLine("\t</apiname_tx0bpmmon_cfg>");
				streamWriter.WriteLine("\t<apiname_tx1bpmmon_cfg>");
				foreach (object obj27 in ConfigurationManager.f0000ee)
				{
					DictionaryEntry dictionaryEntry27 = (DictionaryEntry)obj27;
					string value27 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry27.Key,
						"\" value=\"",
						dictionaryEntry27.Value,
						"\" />"
					});
					streamWriter.WriteLine(value27);
				}
				streamWriter.WriteLine("\t</apiname_tx1bpmmon_cfg>");
				streamWriter.WriteLine("\t<apiname_tx2bpmmon_cfg>");
				foreach (object obj28 in ConfigurationManager.f0000ef)
				{
					DictionaryEntry dictionaryEntry28 = (DictionaryEntry)obj28;
					string value28 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry28.Key,
						"\" value=\"",
						dictionaryEntry28.Value,
						"\" />"
					});
					streamWriter.WriteLine(value28);
				}
				streamWriter.WriteLine("\t</apiname_tx2bpmmon_cfg>");
				streamWriter.WriteLine("\t<apiname_txgainphasemismatchmon_cfg>");
				foreach (object obj29 in ConfigurationManager.txGainPhaseMismatchMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry29 = (DictionaryEntry)obj29;
					string value29 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry29.Key,
						"\" value=\"",
						dictionaryEntry29.Value,
						"\" />"
					});
					streamWriter.WriteLine(value29);
				}
				streamWriter.WriteLine("\t</apiname_txgainphasemismatchmon_cfg>");
				streamWriter.WriteLine("\t<apiname_analogfaultinjection_cfg>");
				foreach (object obj30 in ConfigurationManager.analogFaultInjectionConfig_HT)
				{
					DictionaryEntry dictionaryEntry30 = (DictionaryEntry)obj30;
					string value30 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry30.Key,
						"\" value=\"",
						dictionaryEntry30.Value,
						"\" />"
					});
					streamWriter.WriteLine(value30);
				}
				streamWriter.WriteLine("\t</apiname_analogfaultinjection_cfg>");
				streamWriter.WriteLine("\t<apiname_rxgainphasemon_cfg>");
				foreach (object obj31 in ConfigurationManager.rxGainPhaseMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry31 = (DictionaryEntry)obj31;
					string value31 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry31.Key,
						"\" value=\"",
						dictionaryEntry31.Value,
						"\" />"
					});
					streamWriter.WriteLine(value31);
				}
				streamWriter.WriteLine("\t</apiname_rxgainphasemon_cfg>");
				streamWriter.WriteLine("\t<apiname_rxnoisefiguremon_cfg>");
				foreach (object obj32 in ConfigurationManager.rxNoiseFigureMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry32 = (DictionaryEntry)obj32;
					string value32 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry32.Key,
						"\" value=\"",
						dictionaryEntry32.Value,
						"\" />"
					});
					streamWriter.WriteLine(value32);
				}
				streamWriter.WriteLine("\t</apiname_rxnoisefiguremon_cfg>");
				streamWriter.WriteLine("\t<apiname_rxifstagemon_cfg>");
				foreach (object obj33 in ConfigurationManager.rxIFStageMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry33 = (DictionaryEntry)obj33;
					string value33 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry33.Key,
						"\" value=\"",
						dictionaryEntry33.Value,
						"\" />"
					});
					streamWriter.WriteLine(value33);
				}
				streamWriter.WriteLine("\t</apiname_rxifstagemon_cfg>");
				streamWriter.WriteLine("\t<apiname_rxsaturationdetectormon_cfg>");
				foreach (object obj34 in ConfigurationManager.rxSaturationDetectorMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry34 = (DictionaryEntry)obj34;
					string value34 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry34.Key,
						"\" value=\"",
						dictionaryEntry34.Value,
						"\" />"
					});
					streamWriter.WriteLine(value34);
				}
				streamWriter.WriteLine("\t</apiname_rxsaturationdetectormon_cfg>");
				streamWriter.WriteLine("\t<apiname_rxsignalandimagemon_cfg>");
				foreach (object obj35 in ConfigurationManager.rxSignalImageMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry35 = (DictionaryEntry)obj35;
					string value35 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry35.Key,
						"\" value=\"",
						dictionaryEntry35.Value,
						"\" />"
					});
					streamWriter.WriteLine(value35);
				}
				streamWriter.WriteLine("\t</apiname_rxsignalandimagemon_cfg>");
				streamWriter.WriteLine("\t<apiname_rxmixerinputpowermon_cfg>");
				foreach (object obj36 in ConfigurationManager.rxMixerInputPowerMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry36 = (DictionaryEntry)obj36;
					string value36 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry36.Key,
						"\" value=\"",
						dictionaryEntry36.Value,
						"\" />"
					});
					streamWriter.WriteLine(value36);
				}
				streamWriter.WriteLine("\t</apiname_rxmixerinputpowermon_cfg>");
				streamWriter.WriteLine("\t<apiname_rxtemperaturemon_cfg>");
				foreach (object obj37 in ConfigurationManager.rxTempMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry37 = (DictionaryEntry)obj37;
					string value37 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry37.Key,
						"\" value=\"",
						dictionaryEntry37.Value,
						"\" />"
					});
					streamWriter.WriteLine(value37);
				}
				streamWriter.WriteLine("\t</apiname_rxtemperaturemon_cfg>");
				streamWriter.WriteLine("\t<apiname_rxsynthfreqerrormon_cfg>");
				foreach (object obj38 in ConfigurationManager.rxSynthFreqErrorMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry38 = (DictionaryEntry)obj38;
					string value38 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry38.Key,
						"\" value=\"",
						dictionaryEntry38.Value,
						"\" />"
					});
					streamWriter.WriteLine(value38);
				}
				streamWriter.WriteLine("\t</apiname_rxsynthfreqerrormon_cfg>");
				streamWriter.WriteLine("\t<apiname_rxextanalogsignalmon_cfg>");
				foreach (object obj39 in ConfigurationManager.rxExtAnalogSignalMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry39 = (DictionaryEntry)obj39;
					string value39 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry39.Key,
						"\" value=\"",
						dictionaryEntry39.Value,
						"\" />"
					});
					streamWriter.WriteLine(value39);
				}
				streamWriter.WriteLine("\t</apiname_rxextanalogsignalmon_cfg>");
				streamWriter.WriteLine("\t<apiname_tx0intanalogsignalmon_cfg>");
				foreach (object obj40 in ConfigurationManager.tx0IntAnalogSignalMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry40 = (DictionaryEntry)obj40;
					string value40 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry40.Key,
						"\" value=\"",
						dictionaryEntry40.Value,
						"\" />"
					});
					streamWriter.WriteLine(value40);
				}
				streamWriter.WriteLine("\t</apiname_tx0intanalogsignalmon_cfg>");
				streamWriter.WriteLine("\t<apiname_tx1intanalogsignalmon_cfg>");
				foreach (object obj41 in ConfigurationManager.tx1IntAnalogSignalMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry41 = (DictionaryEntry)obj41;
					string value41 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry41.Key,
						"\" value=\"",
						dictionaryEntry41.Value,
						"\" />"
					});
					streamWriter.WriteLine(value41);
				}
				streamWriter.WriteLine("\t</apiname_tx1intanalogsignalmon_cfg>");
				streamWriter.WriteLine("\t<apiname_tx2intanalogsignalmon_cfg>");
				foreach (object obj42 in ConfigurationManager.tx2IntAnalogSignalMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry42 = (DictionaryEntry)obj42;
					string value42 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry42.Key,
						"\" value=\"",
						dictionaryEntry42.Value,
						"\" />"
					});
					streamWriter.WriteLine(value42);
				}
				streamWriter.WriteLine("\t</apiname_tx2intanalogsignalmon_cfg>");
				streamWriter.WriteLine("\t<apiname_rxintanalogsignalmon_cfg>");
				foreach (object obj43 in ConfigurationManager.rxIntAnalogSignalMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry43 = (DictionaryEntry)obj43;
					string value43 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry43.Key,
						"\" value=\"",
						dictionaryEntry43.Value,
						"\" />"
					});
					streamWriter.WriteLine(value43);
				}
				streamWriter.WriteLine("\t</apiname_rxintanalogsignalmon_cfg>");
				streamWriter.WriteLine("\t<apiname_pmclklointanalogsignalmon_cfg>");
				foreach (object obj44 in ConfigurationManager.f0000f0)
				{
					DictionaryEntry dictionaryEntry44 = (DictionaryEntry)obj44;
					string value44 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry44.Key,
						"\" value=\"",
						dictionaryEntry44.Value,
						"\" />"
					});
					streamWriter.WriteLine(value44);
				}
				streamWriter.WriteLine("\t</apiname_pmclklointanalogsignalmon_cfg>");
				streamWriter.WriteLine("\t<apiname_gpadcintanalogsignalmon_cfg>");
				foreach (object obj45 in ConfigurationManager.GPADCIntAnalogSignalMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry45 = (DictionaryEntry)obj45;
					string value45 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry45.Key,
						"\" value=\"",
						dictionaryEntry45.Value,
						"\" />"
					});
					streamWriter.WriteLine(value45);
				}
				streamWriter.WriteLine("\t</apiname_gpadcintanalogsignalmon_cfg>");
				streamWriter.WriteLine("\t<apiname_pllcontrolvoltagemon_cfg>");
				foreach (object obj46 in ConfigurationManager.pllControlVoltageMonConfig_HT)
				{
					DictionaryEntry dictionaryEntry46 = (DictionaryEntry)obj46;
					string value46 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry46.Key,
						"\" value=\"",
						dictionaryEntry46.Value,
						"\" />"
					});
					streamWriter.WriteLine(value46);
				}
				streamWriter.WriteLine("\t</apiname_pllcontrolvoltagemon_cfg>");
				streamWriter.WriteLine("\t<apiname_dccmon_cfg>");
				foreach (object obj47 in ConfigurationManager.f0000f1)
				{
					DictionaryEntry dictionaryEntry47 = (DictionaryEntry)obj47;
					string value47 = string.Concat(new object[]
					{
						"\t\t<param name=\"",
						dictionaryEntry47.Key,
						"\" value=\"",
						dictionaryEntry47.Value,
						"\" />"
					});
					streamWriter.WriteLine(value47);
				}
				streamWriter.WriteLine("\t</apiname_dccmon_cfg>");
				streamWriter.WriteLine("</configuration>");
			}
		}

		private const string APPSETTINGS_SECTION = "appSettings";

		private const string PARAM = "param";

		private const string NAME = "name";

		private const string VALUE = "value";

		private static Hashtable appSettings = new Hashtable();

		private const string CHANNEL_CONFIG_SECTION = "apiname_channel_cfg";

		private static Hashtable channelConfig_HT;

		private const string ADC_CONFIG_SECTION = "apiname_adc_cfg";

		private static Hashtable adcConfig_HT;

		private const string LPMODE_CONFIG_SECTION = "apiname_lp_cfg";

		private static Hashtable lpConfig_HT;

		private const string FREQLIMIT_CONFIG_SECTION = "apiname_freqlimit_cfg";

		private static Hashtable freqLimitConfig_HT;

		private const string RFLDOBYPASS_CONFIG_SECTION = "apiname_rfldobypass_cfg";

		private static Hashtable rfldobypassConfig_HT;

		private const string RADARMISCCONTROL_CONFIG_SECTION = "apiname_radarmisccontrol_cfg";

		private static Hashtable radarmisccontrolConfig_HT;

		private const string CALMONFREQTXPOWLIMIT_CONFIG_SECTION = "apiname_calmonfreqtxpowlimit_cfg";

		private static Hashtable calmonfreqtxpowlimitConfig_HT;

		private const string DATAPATH_CONFIG_SECTION = "apiname_datapath_cfg";

		private static Hashtable dataPathConfig_HT;

		private const string CLOCK_CONFIG_SECTION = "apiname_clock_cfg";

		private static Hashtable clockConfig_HT;

		private const string LVDSLANE_CONFIG_SECTION = "apiname_lvdslane_cfg";

		private static Hashtable lvdsLaneConfig_HT;

		private const string CSI2_CONFIG_SECTION = "apiname_csi2lane_cfg";

		private static Hashtable csi2Config_HT;

		private const string TESTPATTERNGEN_CONFIG_SECTION = "apiname_testpatterngen_cfg";

		private static Hashtable testPatternGenConfig_HT;

		private const string TESTSOURCE_CONFIG_SECTION = "apiname_testsource_cfg";

		private static Hashtable testSourceConfig_HT;

		private const string CHIRP_CONFIG_SECTION = "apiname_chirp_cfg";

		private static Hashtable chirpConfig_HT;

		private const string PROFILE_CONFIG_SECTION = "apiname_profile_cfg";

		private static Hashtable profileConfig_HT;

		private const string FRAME_CONFIG_SECTION = "apiname_frame_cfg";

		private static Hashtable frameConfig_HT;

		private const string ADVANCEFRAME_CONFIG_SECTION = "apiname_advanceframe_cfg";

		private static Hashtable advanceFrameConfig_HT;

		private const string LOOPBACKBURST_CONFIG_SECTION = "apiname_loopbackburst_cfg";

		private static Hashtable loopBackBurstConfig_HT;

		private const string ANALOGMONENABLE_CONFIG_SECTION = "apiname_analogmonenable_cfg";

		private static Hashtable analogMonEnableConfig_HT;

		private const string TX0BALLBREAK_CONFIG_SECTION = "apiname_tx0ballbreak_cfg";

		private static Hashtable tx0BallBreakConfig_HT;

		private const string TX1BALLBREAK_CONFIG_SECTION = "apiname_tx1ballbreak_cfg";

		private static Hashtable tx1BallBreakConfig_HT;

		private const string TX2BALLBREAK_CONFIG_SECTION = "apiname_tx2ballbreak_cfg";

		private static Hashtable tx2BallBreakConfig_HT;

		private const string TX0POWERMON_CONFIG_SECTION = "apiname_tx0powermon_cfg";

		private static Hashtable tx0PowerMonConfig_HT;

		private const string TX1POWERMON_CONFIG_SECTION = "apiname_tx1powermon_cfg";

		private static Hashtable tx1PowerMonConfig_HT;

		private const string TX2POWERMON_CONFIG_SECTION = "apiname_tx2powermon_cfg";

		private static Hashtable tx2PowerMonConfig_HT;

		private const string TX0BPMMON_CONFIG_SECTION = "apiname_tx0bpmmon_cfg";

		private static Hashtable f0000ed;

		private const string TX1BPMMON_CONFIG_SECTION = "apiname_tx1bpmmon_cfg";

		private static Hashtable f0000ee;

		private const string TX2BPMMON_CONFIG_SECTION = "apiname_tx2bpmmon_cfg";

		private static Hashtable f0000ef;

		private const string TXGAINPHASEMISMATCHMON_CONFIG_SECTION = "apiname_txgainphasemismatchmon_cfg";

		private static Hashtable txGainPhaseMismatchMonConfig_HT;

		private const string ANALOGFAULTINJECTION_CONFIG_SECTION = "apiname_analogfaultinjection_cfg";

		private static Hashtable analogFaultInjectionConfig_HT;

		private const string RXGAINPHASEMON_CONFIG_SECTION = "apiname_rxgainphasemon_cfg";

		private static Hashtable rxGainPhaseMonConfig_HT;

		private const string RXNOISEFIGUREMON_CONFIG_SECTION = "apiname_rxnoisefiguremon_cfg";

		private static Hashtable rxNoiseFigureMonConfig_HT;

		private const string RXIFSTAGEMON_CONFIG_SECTION = "apiname_rxifstagemon_cfg";

		private static Hashtable rxIFStageMonConfig_HT;

		private const string RXSATURATIONDETECTORMON_CONFIG_SECTION = "apiname_rxsaturationdetectormon_cfg";

		private static Hashtable rxSaturationDetectorMonConfig_HT;

		private const string RXSIGNALIMAGEMON_CONFIG_SECTION = "apiname_rxsignalandimagemon_cfg";

		private static Hashtable rxSignalImageMonConfig_HT;

		private const string RXMIXERINPUTPOWERMON_CONFIG_SECTION = "apiname_rxmixerinputpowermon_cfg";

		private static Hashtable rxMixerInputPowerMonConfig_HT;

		private const string RXTEMPERATUREMON_CONFIG_SECTION = "apiname_rxtemperaturemon_cfg";

		private static Hashtable rxTempMonConfig_HT;

		private const string RXSYNTHFREQERRORMON_CONFIG_SECTION = "apiname_rxsynthfreqerrormon_cfg";

		private static Hashtable rxSynthFreqErrorMonConfig_HT;

		private const string RXEXTANALOGSIGMON_CONFIG_SECTION = "apiname_rxextanalogsignalmon_cfg";

		private static Hashtable rxExtAnalogSignalMonConfig_HT;

		private const string TX0INTANALOGSIGMON_CONFIG_SECTION = "apiname_tx0intanalogsignalmon_cfg";

		private static Hashtable tx0IntAnalogSignalMonConfig_HT;

		private const string TX1INTANALOGSIGMON_CONFIG_SECTION = "apiname_tx1intanalogsignalmon_cfg";

		private static Hashtable tx1IntAnalogSignalMonConfig_HT;

		private const string TX2INTANALOGSIGMON_CONFIG_SECTION = "apiname_tx2intanalogsignalmon_cfg";

		private static Hashtable tx2IntAnalogSignalMonConfig_HT;

		private const string RXINTANALOGSIGMON_CONFIG_SECTION = "apiname_rxintanalogsignalmon_cfg";

		private static Hashtable rxIntAnalogSignalMonConfig_HT;

		private const string PMCLKLOINTANALOGSIGMON_CONFIG_SECTION = "apiname_pmclklointanalogsignalmon_cfg";

		private static Hashtable f0000f0;

		private const string GPADCINTANALOGSIGMON_CONFIG_SECTION = "apiname_gpadcintanalogsignalmon_cfg";

		private static Hashtable GPADCIntAnalogSignalMonConfig_HT;

		private const string PLLVOLTAGECONTROLMON_CONFIG_SECTION = "apiname_pllcontrolvoltagemon_cfg";

		private static Hashtable pllControlVoltageMonConfig_HT;

		private const string DCCMON_CONFIG_SECTION = "apiname_dccmon_cfg";

		private static Hashtable f0000f1;
	}
}
