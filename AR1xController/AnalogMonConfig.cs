using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
    public class AnalogMonConfig : UserControl
    {
        public AnalogMonConfig()
        {
            this.InitializeComponent();
            this.m_MainForm = this.m_GuiManager.MainTsForm;
            this.m_MonRFEnablesConfigParameters = this.m_GuiManager.TsParams.MonRFEnablesConfigParameters;
            this.m_MonTX1PowerConfigParameters = this.m_GuiManager.TsParams.MonTX1PowerConfigParameters;
            this.m_MonTX2PowerConfigParameters = this.m_GuiManager.TsParams.MonTX2PowerConfigParameters;
            this.m_MonTX3PowerConfigParameters = this.m_GuiManager.TsParams.MonTX3PowerConfigParameters;
            this.m_MonTx1BallBreakConfigParameters = this.m_GuiManager.TsParams.MonTx1BallBreakConfigParameters;
            this.m_MonTx2BallBreakConfigParameters = this.m_GuiManager.TsParams.MonTx2BallBreakConfigParameters;
            this.m_MonTx3BallBreakConfigParameters = this.m_GuiManager.TsParams.MonTx3BallBreakConfigParameters;
            this.m_MonTx1BPMPhaseConfigParameters = this.m_GuiManager.TsParams.MonTx1BPMPhaseConfigParameters;
            this.m_MonTx2BPMPhaseConfigParameters = this.m_GuiManager.TsParams.MonTx2BPMPhaseConfigParameters;
            this.m_MonTx3BPMPhaseConfigParameters = this.m_GuiManager.TsParams.MonTx3BPMPhaseConfigParameters;
            this.m_MonTxGainPhaseMismatchConfigParameters = this.m_GuiManager.TsParams.MonTxGainPhaseMismatchConfigParameters;
            this.m_AnalogFaultInjectionConfigParameters = this.m_GuiManager.TsParams.AnalogFaultInjectionConfigParameters;
            this.m_MonSynthFrequencyConfigParameters = this.m_GuiManager.TsParams.MonSynthFrequencyConfigParameters;
            this.m_nudTX1PowerReportingMode.Value = 0m;
            this.m_nudTX2PowerReportingMode.Value = 0m;
            this.m_nudTX3PowerReportingMode.Value = 0m;
            this.m_nudTX1BallBreakMonReportingMode.Value = 0m;
            this.m_nudTX2BallBreakMonReportingMode.Value = 0m;
            this.m_nudTX3BallBreakMonReportingMode.Value = 0m;
        }

        private int iSetMonitoringRFEnablesConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetMonitoringRFEnablesConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetMonitoringRFEnablesConfig()
        {
            this.iSetMonitoringRFEnablesConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetMonitoringRFEnablesConfigAsync()
        {
            new del_v_v(this.iSetMonitoringRFEnablesConfig).BeginInvoke(null, null);
        }

        private void m_btnAnalogMonRFEnablesMonConfigSet_Click_1(object sender, EventArgs p1)
        {
            this.iSetMonitoringRFEnablesConfigAsync();
        }

        public bool UpdateMonitoringRFEnablesConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateMonitoringRFEnablesConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_MonRFEnablesConfigParameters.TemperatureMon = (this.m_chbTemperatureMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.RxGainPhase = (this.m_chbRXGainPhaseMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.RxNoise = (this.m_chbRXNoiseMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.RxIFStage = (this.f000115.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.Tx1Power = (this.m_chbTX1PowerMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.Tx2Power = (this.m_chbTX2PowerMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.Tx3Power = (this.m_chbTX3PowerMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.Tx1BallBreak = (this.m_chbTX1BallBreakMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.Tx2BallBreak = (this.m_chbTX2BallBreakMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.Tx3BallBreak = (this.m_chbTX3BallBreakMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.TxGainPhase = (this.m_chbTXGainPhaseMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.Tx1BPM = (this.f000114.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.Tx2BPM = (this.f000113.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.Tx3BPM = (this.f000112.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.SynthFrequency = (this.m_chbSynthFreqMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.ExternalAnalogSignals = (this.m_chbExternalAnalogSignalsMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.InternalTX1Signals = (this.m_chbInternalTX1SignalsMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.InternalTX2Signals = (this.m_chbInternalTX2SignalsMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.InternalTX3Signals = (this.m_chbInternalTX3SignalsMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.InternalRXSignal = (this.m_chbInternalRXSignalsMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.f0002fe = (this.f000111.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.f0002ff = (this.f000110.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.PLLControlVoltage = (this.m_chbPLLControlVolMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.DCCClockFreq = (this.m_chbDCCClockFreqMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.f000300 = (this.f00010f.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.RxSigImgBand = (this.m_chbRXSigImgBandMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.RxMixerInputPower = (this.m_chbRXMixerInputPowerMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.Reserved = (this.m_chbReservedMonEna.Checked ? '\u0001' : '\0');
                this.m_MonRFEnablesConfigParameters.ApllLdoShortCircuit = (byte)(this.f000127.Checked ? 1 : 0);
                this.m_MonRFEnablesConfigParameters.VCOLdoShortCircuit = (byte)(this.f000125.Checked ? 1 : 0);
                this.m_MonRFEnablesConfigParameters.PALdoShortCircuit = (byte)(this.f000126.Checked ? 1 : 0);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateAnaTXMonConfigData(RootObject jobject, int p1)
        {
            bool result;
            try
            {
                if (jobject.mmWaveDevices[p1].monitoringConfig == null)
                {
                    string msg = string.Format("Missing Monitoring Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg);
                }
                else
                {
                    if (jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.isConfigured == 0)
                    {
                        string msg2 = string.Format("Missing Analog monitoring Configuration for Device {0}. Skipping..", p1);
                        GlobalRef.LuaWrapper.PrintWarning(msg2);
                    }
                    else
                    {
                        this.m_chbTemperatureMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 1) == 1);
                        this.m_chbRXGainPhaseMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 2) >> 1 == 1);
                        this.m_chbRXNoiseMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 4) >> 2 == 1);
                        this.f000115.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 8) >> 3 == 1);
                        this.m_chbTX1PowerMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 16) >> 4 == 1);
                        this.m_chbTX2PowerMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 32) >> 5 == 1);
                        this.m_chbTX3PowerMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 64) >> 6 == 1);
                        this.m_chbTX1BallBreakMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 128) >> 7 == 1);
                        this.m_chbTX2BallBreakMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 256) >> 8 == 1);
                        this.m_chbTX3BallBreakMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 512) >> 9 == 1);
                        this.m_chbTXGainPhaseMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 1024) >> 10 == 1);
                        this.f000114.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 2048) >> 11 == 1);
                        this.f000113.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 4096) >> 12 == 1);
                        this.f000112.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 8192) >> 13 == 1);
                        this.m_chbSynthFreqMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 16384) >> 14 == 1);
                        this.m_chbExternalAnalogSignalsMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 32768) >> 15 == 1);
                        this.m_chbInternalTX1SignalsMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 65536) >> 16 == 1);
                        this.m_chbInternalTX2SignalsMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 131072) >> 17 == 1);
                        this.m_chbInternalTX3SignalsMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 262144) >> 18 == 1);
                        this.m_chbInternalRXSignalsMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 524288) >> 19 == 1);
                        this.f000111.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 1048576) >> 20 == 1);
                        this.f000110.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 2097152) >> 21 == 1);
                        this.m_chbPLLControlVolMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 4194304) >> 22 == 1);
                        this.m_chbDCCClockFreqMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 8388608) >> 23 == 1);
                        this.f00010f.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 16777216) >> 24 == 1);
                        this.m_chbRXSigImgBandMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 33554432) >> 25 == 1);
                        this.m_chbRXMixerInputPowerMonEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlMonAnaEnables_t.enMask, 16) & 67108864) >> 26 == 1);
                    }
                    if (jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.isConfigured == 0)
                    {
                        string msg3 = string.Format("Missing TX power monitoring Configuration for Device {0}. Skipping..", p1);
                        GlobalRef.LuaWrapper.PrintWarning(msg3);
                    }
                    else
                    {
                        this.m_nudTXPwrMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.profileIndx;
                        this.f000105.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.rfFreqBitMask, 16) & 1) == 1);
                        this.f000104.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.rfFreqBitMask, 16) & 2) >> 1 == 1);
                        this.f000103.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.rfFreqBitMask, 16) & 4) >> 2 == 1);
                        this.m_nudTX1PowerReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.reportMode;
                        this.m_nudTXPwAbsErrThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.txPowAbsErrThresh;
                        this.m_nudTXPwFlatnessThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx0PowrMonCfg.txPowFlatnessErrThresh;
                        this.m_nudTX2PwrMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.profileIndx;
                        this.f00010b.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.rfFreqBitMask, 16) & 1) == 1);
                        this.f00010a.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.rfFreqBitMask, 16) & 2) >> 1 == 1);
                        this.f000109.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.rfFreqBitMask, 16) & 4) >> 2 == 1);
                        this.m_nudTX2PowerReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.reportMode;
                        this.m_nudTX2PwAbsErrThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.txPowAbsErrThresh;
                        this.m_nudTX2PwFlatnessThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx1PowrMonCfg.txPowFlatnessErrThresh;
                        this.m_nudTX3PwrMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.profileIndx;
                        this.f000108.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.rfFreqBitMask, 16) & 1) == 1);
                        this.f000107.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.rfFreqBitMask, 16) & 2) >> 1 == 1);
                        this.f000106.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.rfFreqBitMask, 16) & 4) >> 2 == 1);
                        this.m_nudTX3PowerReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.reportMode;
                        this.m_nudTX3PwAbsErrThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.txPowAbsErrThresh;
                        this.m_nudTX3PwFlatnessThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxPowMonConf_t.tx2PowrMonCfg.txPowFlatnessErrThresh;
                    }
                    if (jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBallBreakMonCfg_t.isConfigured == 0)
                    {
                        string msg4 = string.Format("Missing TX ballbreak monitoring Configuration for Device {0}. Skipping..", p1);
                        GlobalRef.LuaWrapper.PrintWarning(msg4);
                    }
                    else
                    {
                        this.m_nudTX1BallBreakMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBallBreakMonCfg_t.p000019.reportMode;
                        this.m_nudTX1ReflCoeffMagThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBallBreakMonCfg_t.p000019.txReflCoeffMagThresh;
                        this.m_nudTX2BallBreakMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBallBreakMonCfg_t.p00001a.reportMode;
                        this.m_nudTX2ReflCoeffMagThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBallBreakMonCfg_t.p00001a.txReflCoeffMagThresh;
                        this.m_nudTX3BallBreakMonReportingMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBallBreakMonCfg_t.p00001b.reportMode;
                        this.m_nudTX3ReflCoeffMagThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBallBreakMonCfg_t.p00001b.txReflCoeffMagThresh;
                    }
                    if (jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.isConfigured == 0)
                    {
                        string msg5 = string.Format("Missing TX BPM monitoring Configuration for Device {0}. Skipping..", p1);
                        GlobalRef.LuaWrapper.PrintWarning(msg5);
                    }
                    else
                    {
                        this.m_nudTX1BPMPhaseMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.profileIndx;
                        this.m_nudTX1BPMPhaseMonReportMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.reportMode;
                        this.f00011a.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.rxEn, 16) & 1) == 1);
                        this.f000119.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.rxEn, 16) & 2) >> 1 == 1);
                        this.f000120.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.rxEn, 16) & 4) >> 2 == 1);
                        this.f00011c.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.rxEn, 16) & 8) >> 3 == 1);
                        this.m_nudTX1BPMPhaseMonErrorThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.txBpmPhaseErrThresh;
                        this.m_nudTX1BPMAmplitudeMonErrorThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001c.txBpmAmplErrThresh;
                        this.m_nudTX2BPMPhaseMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.profileIndx;
                        this.m_nudTX2BPMPhaseMonReportMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.reportMode;
                        this.f00011e.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.rxEn, 16) & 1) == 1);
                        this.f00011d.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.rxEn, 16) & 2) >> 1 == 1);
                        this.f00011f.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.rxEn, 16) & 4) >> 2 == 1);
                        this.f00011b.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.rxEn, 16) & 8) >> 3 == 1);
                        this.m_nudTX2BPMPhaseMonErrorThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.txBpmPhaseErrThresh;
                        this.m_nudTX2BPMAmplitudeMonErrorThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001d.txBpmAmplErrThresh;
                        this.m_nudTX3BPMPhaseMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.profileIndx;
                        this.m_nudTX3BPMPhaseMonReportMode.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.reportMode;
                        this.f000123.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.rxEn, 16) & 1) == 1);
                        this.f000122.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.rxEn, 16) & 2) >> 1 == 1);
                        this.f000124.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.rxEn, 16) & 4) >> 2 == 1);
                        this.f000121.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.rxEn, 16) & 8) >> 3 == 1);
                        this.m_nudTX3BPMPhaseMonErrorThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.txBpmPhaseErrThresh;
                        this.m_nudTX3BPMAmplitudeMonErrorThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlAllTxBpmMonConf_t.p00001e.txBpmAmplErrThresh;
                    }
                    if (jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.isConfigured == 0)
                    {
                        string msg6 = string.Format("Missing TX gain and phase mismatch monitoring Configuration for Device {0}. Skipping..", p1);
                        GlobalRef.LuaWrapper.PrintWarning(msg6);
                    }
                    else
                    {
                        this.m_nudTxGainPhaseMismacthMonProfileIndex.Value = jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.profileIndx;
                        this.m_chbRF1TXGainPhaseMismatchMonBitMask.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.rfFreqBitMask, 16) & 1) == 1);
                        this.m_chbRF2TXGainPhaseMismatchMonBitMask.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.rfFreqBitMask, 16) & 2) >> 1 == 1);
                        this.m_chbRF3TXGainPhaseMismatchMonBitMask.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.rfFreqBitMask, 16) & 4) >> 2 == 1);
                        this.m_chbTXGainPhaseMismatchMonTx1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txEn, 16) & 1) == 1);
                        this.m_chbTXGainPhaseMismatchMonTx2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txEn, 16) & 2) >> 1 == 1);
                        this.m_chbTXGainPhaseMismatchMonTx3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txEn, 16) & 4) >> 2 == 1);
                        this.m_chbTXGainPhaseMismatchMonRx0.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.rxEn, 16) & 1) == 1);
                        this.m_chbTXGainPhaseMismatchMonRx1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.rxEn, 16) & 2) >> 1 == 1);
                        this.m_chbTXGainPhaseMismatchMonRx2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.rxEn, 16) & 4) >> 2 == 1);
                        this.m_chbTXGainPhaseMismatchMonRx3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.rxEn, 16) & 8) >> 3 == 1);
                        this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchThresh;
                        this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.Value = (decimal)jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchThresh;
                        this.m_nudRF1TX1TXGainPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[0][0] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[0][1]);
                        this.m_nudRF1TX2TXGainPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[0][2] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[0][3]);
                        this.m_nudRF1TX3TXGainPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[0][4] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[0][5]);
                        this.m_nudRF2TX1TXGainPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[1][0] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[1][1]);
                        this.m_nudRF2TX2TXGainPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[1][2] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[1][3]);
                        this.m_nudRF2TX3TXGainPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[1][4] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[1][5]);
                        this.m_nudRF3TX1TXGainPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[2][0] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[2][1]);
                        this.m_nudRF3TX2TXGainPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[2][2] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[2][3]);
                        this.m_nudRF3TX3TXGainPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[2][4] * 0.1 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txGainMismatchOffsetVal[2][5]);
                        this.m_nudRF1TX1TXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[0][0] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[0][1]);
                        this.m_nudRF1TX2TXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[0][2] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[0][3]);
                        this.m_nudRF1TX3TXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[0][4] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[0][5]);
                        this.m_nudRF2TX1TXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[1][0] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[1][1]);
                        this.m_nudRF2TX2TXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[1][2] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[1][3]);
                        this.m_nudRF2TX3TXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[1][4] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[1][5]);
                        this.m_nudRF3TX1TXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[2][0] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[2][1]);
                        this.m_nudRF3TX2TXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[2][2] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[2][3]);
                        this.m_nudRF3TX3TXPhaseMismatchOffVal.Value = (decimal)(jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[2][4] * 0.01 + jobject.mmWaveDevices[p1].monitoringConfig.rlTxGainPhaseMismatchMonConf_t.txPhaseMismatchOffsetVal[2][5]);
                    }
                    if (jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.isConfigured == 0)
                    {
                        string msg7 = string.Format("Missing Analog fault injection Configuration for Device {0}. Skipping..", p1);
                        GlobalRef.LuaWrapper.PrintWarning(msg7);
                    }
                    else
                    {
                        this.m_chbRxGainDropRx1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxGainDrop, 16) & 1) == 1);
                        this.m_chbRxGainDropRx2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxGainDrop, 16) & 2) >> 1 == 1);
                        this.m_chbRxGainDropRx3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxGainDrop, 16) & 4) >> 2 == 1);
                        this.m_chbRxGainDropRx4.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxGainDrop, 16) & 8) >> 3 == 1);
                        this.m_chbRxPhaseInvRx1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxPhInv, 16) & 1) == 1);
                        this.m_chbRxPhaseInvRx2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxPhInv, 16) & 2) >> 1 == 1);
                        this.m_chbRxPhaseInvRx3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxPhInv, 16) & 4) >> 2 == 1);
                        this.m_chbRxPhaseInvRx4.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxPhInv, 16) & 8) >> 3 == 1);
                        this.m_chbRxHighNoiseRx1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxHighNoise, 16) & 1) == 1);
                        this.m_chbRxHighNoiseRx2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxHighNoise, 16) & 2) >> 1 == 1);
                        this.m_chbRxHighNoiseRx3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxHighNoise, 16) & 4) >> 2 == 1);
                        this.m_chbRxHighNoiseRx4.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxHighNoise, 16) & 8) >> 3 == 1);
                        this.m_chbRxIFStageRx1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxIfStagesFault, 16) & 1) == 1);
                        this.m_chbRxIFStageRx2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxIfStagesFault, 16) & 2) >> 1 == 1);
                        this.m_chbRxIFStageRx3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxIfStagesFault, 16) & 4) >> 2 == 1);
                        this.m_chbRxIFStageRx4.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxIfStagesFault, 16) & 8) >> 3 == 1);
                        this.m_chbRxLOAmpRx0Rx1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxLoAmpFault, 16) & 1) == 1);
                        this.m_chbRxLOAmpRx2Rx3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.rxLoAmpFault, 16) & 2) >> 1 == 1);
                        this.m_chbTxLOAmpTx0Tx1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.txLoAmpFault, 16) & 1) == 1);
                        this.m_chbTxLOAmpTx2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.txLoAmpFault, 16) & 2) >> 1 == 1);
                        this.m_chbTxGainDropTx1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.txGainDrop, 16) & 1) == 1);
                        this.m_chbTxGainDropTx2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.txGainDrop, 16) & 2) >> 1 == 1);
                        this.m_chbTxGainDropTx3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.txGainDrop, 16) & 4) >> 2 == 1);
                        this.m_chbTxGainInvTxFault.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.txPhInv, 16) & 1) == 1);
                        this.m_chbTxGainInvTx1BPMVal.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.txPhInv, 16) & 8) >> 3 == 1);
                        this.m_chbTxGainInvTx2BPMVal.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.txPhInv, 16) & 16) >> 4 == 1);
                        this.m_chbTxGainInvTx3BPMVal.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.txPhInv, 16) & 32) >> 5 == 1);
                        this.m_chbSynthVCOOpenLoop.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.synthFault, 16) & 1) == 1);
                        this.m_chbSynthFreqMonOffset.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.synthFault, 16) & 2) >> 1 == 1);
                        this.f000116.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.supplyLdoFault, 16) & 1) == 1);
                        this.f000117.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.miscFault, 16) & 1) == 1);
                        this.m_chbExtAnaSigMon.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.miscThreshFault, 16) & 1) == 1);
                        this.f000118.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].monitoringConfig.rlAnaFaultInj_t.miscThreshFault, 16) & 2) >> 1 == 1);
                    }
                }
                result = true;
            }
            catch
            {
                string msg8 = string.Format("Tx Monitoring Tab Configuration for device {0} is incorrect.", p1);
                GlobalRef.LuaWrapper.PrintError(msg8);
                result = false;
            }
            return result;
        }

        public bool UpdateMonitoringRFEnablesConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateMonitoringRFEnablesConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_chbTemperatureMonEna.Checked = (this.m_MonRFEnablesConfigParameters.TemperatureMon == '\u0001');
                this.m_chbRXGainPhaseMonEna.Checked = (this.m_MonRFEnablesConfigParameters.RxGainPhase == '\u0001');
                this.m_chbRXNoiseMonEna.Checked = (this.m_MonRFEnablesConfigParameters.RxNoise == '\u0001');
                this.f000115.Checked = (this.m_MonRFEnablesConfigParameters.RxIFStage == '\u0001');
                this.m_chbTX1PowerMonEna.Checked = (this.m_MonRFEnablesConfigParameters.Tx1Power == '\u0001');
                this.m_chbTX2PowerMonEna.Checked = (this.m_MonRFEnablesConfigParameters.Tx2Power == '\u0001');
                this.m_chbTX3PowerMonEna.Checked = (this.m_MonRFEnablesConfigParameters.Tx3Power == '\u0001');
                this.m_chbTX1BallBreakMonEna.Checked = (this.m_MonRFEnablesConfigParameters.Tx1BallBreak == '\u0001');
                this.m_chbTX2BallBreakMonEna.Checked = (this.m_MonRFEnablesConfigParameters.Tx2BallBreak == '\u0001');
                this.m_chbTX3BallBreakMonEna.Checked = (this.m_MonRFEnablesConfigParameters.Tx3BallBreak == '\u0001');
                this.m_chbTXGainPhaseMonEna.Checked = (this.m_MonRFEnablesConfigParameters.TxGainPhase == '\u0001');
                this.f000114.Checked = (this.m_MonRFEnablesConfigParameters.Tx1BPM == '\u0001');
                this.f000113.Checked = (this.m_MonRFEnablesConfigParameters.Tx2BPM == '\u0001');
                this.f000112.Checked = (this.m_MonRFEnablesConfigParameters.Tx3BPM == '\u0001');
                this.m_chbSynthFreqMonEna.Checked = (this.m_MonRFEnablesConfigParameters.SynthFrequency == '\u0001');
                this.m_chbExternalAnalogSignalsMonEna.Checked = (this.m_MonRFEnablesConfigParameters.ExternalAnalogSignals == '\u0001');
                this.m_chbInternalTX1SignalsMonEna.Checked = (this.m_MonRFEnablesConfigParameters.InternalTX1Signals == '\u0001');
                this.m_chbInternalTX2SignalsMonEna.Checked = (this.m_MonRFEnablesConfigParameters.InternalTX2Signals == '\u0001');
                this.m_chbInternalTX3SignalsMonEna.Checked = (this.m_MonRFEnablesConfigParameters.InternalTX3Signals == '\u0001');
                this.m_chbInternalRXSignalsMonEna.Checked = (this.m_MonRFEnablesConfigParameters.InternalRXSignal == '\u0001');
                this.f000111.Checked = (this.m_MonRFEnablesConfigParameters.f0002fe == '\u0001');
                this.f000110.Checked = (this.m_MonRFEnablesConfigParameters.f0002ff == '\u0001');
                this.m_chbPLLControlVolMonEna.Checked = (this.m_MonRFEnablesConfigParameters.PLLControlVoltage == '\u0001');
                this.m_chbDCCClockFreqMonEna.Checked = (this.m_MonRFEnablesConfigParameters.DCCClockFreq == '\u0001');
                this.f00010f.Checked = (this.m_MonRFEnablesConfigParameters.f000300 == '\u0001');
                this.m_chbRXSigImgBandMonEna.Checked = (this.m_MonRFEnablesConfigParameters.RxSigImgBand == '\u0001');
                this.m_chbRXMixerInputPowerMonEna.Checked = (this.m_MonRFEnablesConfigParameters.RxMixerInputPower == '\u0001');
                this.m_chbReservedMonEna.Checked = (this.m_MonRFEnablesConfigParameters.Reserved == '\u0001');
                this.f000127.Checked = (this.m_MonRFEnablesConfigParameters.ApllLdoShortCircuit == 1);
                this.f000125.Checked = (this.m_MonRFEnablesConfigParameters.VCOLdoShortCircuit == 1);
                this.f000126.Checked = (this.m_MonRFEnablesConfigParameters.PALdoShortCircuit == 1);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private int iSetTX1PowerMonConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTX1PowerMonConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetTX1PowerMonConfig()
        {
            this.iSetTX1PowerMonConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetTX1PowerMonConfigAsync()
        {
            new del_v_v(this.iSetTX1PowerMonConfig).BeginInvoke(null, null);
        }

        private void m_btnTX1PowerMonConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetTX1PowerMonConfigAsync();
        }

        public bool UpdateTX1PowerMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX1PowerMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_MonTX1PowerConfigParameters.ProfileIndex = (char)this.m_nudTXPwrMonProfileIndex.Value;
                this.m_MonTX1PowerConfigParameters.RF1FreqBitMask = (this.f000105.Checked ? '\u0001' : '\0');
                this.m_MonTX1PowerConfigParameters.RF2FreqBitMask = (this.f000104.Checked ? '\u0001' : '\0');
                this.m_MonTX1PowerConfigParameters.RF3FreqBitMask = (this.f000103.Checked ? '\u0001' : '\0');
                this.m_MonTX1PowerConfigParameters.ReportingMode = (char)this.m_nudTX1PowerReportingMode.Value;
                this.m_MonTX1PowerConfigParameters.TxPowerAbsoluteErrorThreshold = (double)this.m_nudTXPwAbsErrThreshold.Value;
                this.m_MonTX1PowerConfigParameters.TxPowerFlatnessErrorThreshold = (double)this.m_nudTXPwFlatnessThreshold.Value;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateTX1PowerMonConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX1PowerMonConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudTXPwrMonProfileIndex.Value = this.m_MonTX1PowerConfigParameters.ProfileIndex;
                this.f000105.Checked = (this.m_MonTX1PowerConfigParameters.RF1FreqBitMask == '\u0001');
                this.f000104.Checked = (this.m_MonTX1PowerConfigParameters.RF2FreqBitMask == '\u0001');
                this.f000103.Checked = (this.m_MonTX1PowerConfigParameters.RF3FreqBitMask == '\u0001');
                this.m_nudTX1PowerReportingMode.Value = this.m_MonTX1PowerConfigParameters.ReportingMode;
                this.m_nudTXPwAbsErrThreshold.Value = (decimal)this.m_MonTX1PowerConfigParameters.TxPowerAbsoluteErrorThreshold;
                this.m_nudTXPwFlatnessThreshold.Value = (decimal)this.m_MonTX1PowerConfigParameters.TxPowerFlatnessErrorThreshold;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool MonitoringReportHeader(uint RadarDeviceId, uint FTTICount, short AvgTemp)
        {
            if (base.InvokeRequired)
            {
                del_u_u_s method = new del_u_u_s(this.MonitoringReportHeader);
                base.Invoke(method, new object[]
                {
                    RadarDeviceId,
                    FTTICount,
                    AvgTemp
                });
            }
            else
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    if (RadarDeviceId == 1U)
                    {
                        Convert.ToString(FTTICount);
                        Convert.ToString(AvgTemp);
                    }
                }
                else
                {
                    Convert.ToString(FTTICount);
                    Convert.ToString(AvgTemp);
                }
            }
            return true;
        }

        public bool CascadeTx1PowerMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, uint RF12TxPowerValue, uint RF3TxPowerValue, uint TimeStamp)
        {
            if (base.InvokeRequired)
            {
                delegate0100 method = new delegate0100(this.CascadeTx1PowerMonitoringReport);
                base.Invoke(method, new object[]
                {
                    RadarDeviceId,
                    StatusFlags,
                    ErrorCode,
                    ProfileIndex,
                    RF12TxPowerValue,
                    RF3TxPowerValue,
                    TimeStamp
                });
            }
            else
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                string empty7 = string.Empty;
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    if (RadarDeviceId == 1U)
                    {
                        if ((StatusFlags & 1) == 1)
                        {
                            Convert.ToString(StatusFlags);
                        }
                        else
                        {
                            Convert.ToString(StatusFlags);
                        }
                        Convert.ToString(ErrorCode);
                        Convert.ToString(ProfileIndex);
                        ushort num = (ushort)(RF12TxPowerValue & 65535U);
                        if (num > 32767)
                        {
                            Convert.ToString((double)((short)((int)num - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num / 10.0);
                        }
                        ushort num2 = (ushort)(RF12TxPowerValue >> 16);
                        if (num2 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num2 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num2 / 10.0);
                        }
                        ushort num3 = (ushort)(RF3TxPowerValue & 65535U);
                        if (num3 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num3 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num3 / 10.0);
                        }
                        Convert.ToString(TimeStamp);
                    }
                }
                else
                {
                    if ((StatusFlags & 1) == 1)
                    {
                        Convert.ToString(StatusFlags);
                    }
                    else
                    {
                        Convert.ToString(StatusFlags);
                    }
                    Convert.ToString(ErrorCode);
                    Convert.ToString(ProfileIndex);
                    ushort num4 = (ushort)(RF12TxPowerValue & 65535U);
                    if (num4 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num4 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num4 / 10.0);
                    }
                    ushort num5 = (ushort)(RF12TxPowerValue >> 16);
                    if (num5 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num5 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num5 / 10.0);
                    }
                    ushort num6 = (ushort)(RF3TxPowerValue & 65535U);
                    if (num6 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num6 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num6 / 10.0);
                    }
                    Convert.ToString(TimeStamp);
                }
            }
            return true;
        }

        private int iSetTX2PowerMonConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTX2PowerMonConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetTX2PowerMonConfig()
        {
            this.iSetTX2PowerMonConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetTX2PowerMonConfigAsync()
        {
            new del_v_v(this.iSetTX2PowerMonConfig).BeginInvoke(null, null);
        }

        private void m_btnTX2PowerMonConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetTX2PowerMonConfigAsync();
        }

        public bool UpdateTX2PowerMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX2PowerMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_MonTX2PowerConfigParameters.ProfileIndex = (char)this.m_nudTX2PwrMonProfileIndex.Value;
                this.m_MonTX2PowerConfigParameters.RF1FreqBitMask = (this.f00010b.Checked ? '\u0001' : '\0');
                this.m_MonTX2PowerConfigParameters.RF2FreqBitMask = (this.f00010a.Checked ? '\u0001' : '\0');
                this.m_MonTX2PowerConfigParameters.RF3FreqBitMask = (this.f000109.Checked ? '\u0001' : '\0');
                this.m_MonTX2PowerConfigParameters.ReportingMode = (char)this.m_nudTX2PowerReportingMode.Value;
                this.m_MonTX2PowerConfigParameters.TxPowerAbsoluteErrorThreshold = (double)this.m_nudTX2PwAbsErrThreshold.Value;
                this.m_MonTX2PowerConfigParameters.TxPowerFlatnessErrorThreshold = (double)this.m_nudTX2PwFlatnessThreshold.Value;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateTX2PowerMonConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX2PowerMonConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudTX2PwrMonProfileIndex.Value = this.m_MonTX2PowerConfigParameters.ProfileIndex;
                this.f00010b.Checked = (this.m_MonTX2PowerConfigParameters.RF1FreqBitMask == '\u0001');
                this.f00010a.Checked = (this.m_MonTX2PowerConfigParameters.RF2FreqBitMask == '\u0001');
                this.f000109.Checked = (this.m_MonTX2PowerConfigParameters.RF3FreqBitMask == '\u0001');
                this.m_nudTX2PowerReportingMode.Value = this.m_MonTX2PowerConfigParameters.ReportingMode;
                this.m_nudTX2PwAbsErrThreshold.Value = (decimal)this.m_MonTX2PowerConfigParameters.TxPowerAbsoluteErrorThreshold;
                this.m_nudTX2PwFlatnessThreshold.Value = (decimal)this.m_MonTX2PowerConfigParameters.TxPowerFlatnessErrorThreshold;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool CascadeTx2PowerMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, uint RF12TxPowerValue, uint RF3TxPowerValue, uint TimeStamp)
        {
            if (base.InvokeRequired)
            {
                delegate0100 method = new delegate0100(this.CascadeTx2PowerMonitoringReport);
                base.Invoke(method, new object[]
                {
                    RadarDeviceId,
                    StatusFlags,
                    ErrorCode,
                    ProfileIndex,
                    RF12TxPowerValue,
                    RF3TxPowerValue,
                    TimeStamp
                });
            }
            else
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                string empty7 = string.Empty;
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    if (RadarDeviceId == 1U)
                    {
                        if ((StatusFlags & 1) == 1)
                        {
                            Convert.ToString(StatusFlags);
                        }
                        else
                        {
                            Convert.ToString(StatusFlags);
                        }
                        Convert.ToString(ErrorCode);
                        Convert.ToString(ProfileIndex);
                        ushort num = (ushort)(RF12TxPowerValue & 65535U);
                        if (num > 32767)
                        {
                            Convert.ToString((double)((short)((int)num - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num / 10.0);
                        }
                        ushort num2 = (ushort)(RF12TxPowerValue >> 16);
                        if (num2 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num2 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num2 / 10.0);
                        }
                        ushort num3 = (ushort)(RF3TxPowerValue & 65535U);
                        if (num3 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num3 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num3 / 10.0);
                        }
                        Convert.ToString(TimeStamp);
                    }
                }
                else
                {
                    if ((StatusFlags & 1) == 1)
                    {
                        Convert.ToString(StatusFlags);
                    }
                    else
                    {
                        Convert.ToString(StatusFlags);
                    }
                    Convert.ToString(ErrorCode);
                    Convert.ToString(ProfileIndex);
                    ushort num4 = (ushort)(RF12TxPowerValue & 65535U);
                    if (num4 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num4 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num4 / 10.0);
                    }
                    ushort num5 = (ushort)(RF12TxPowerValue >> 16);
                    if (num5 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num5 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num5 / 10.0);
                    }
                    ushort num6 = (ushort)(RF3TxPowerValue & 65535U);
                    if (num6 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num6 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num6 / 10.0);
                    }
                    Convert.ToString(TimeStamp);
                }
            }
            return true;
        }

        private int iSetTX3PowerMonConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTX3PowerMonConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetTX3PowerMonConfig()
        {
            this.iSetTX3PowerMonConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetTX3PowerMonConfigAsync()
        {
            new del_v_v(this.iSetTX3PowerMonConfig).BeginInvoke(null, null);
        }

        private void m_btnTX3PowerMonConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetTX3PowerMonConfigAsync();
        }

        public bool UpdateTX3PowerMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX3PowerMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_MonTX3PowerConfigParameters.ProfileIndex = (char)this.m_nudTX3PwrMonProfileIndex.Value;
                this.m_MonTX3PowerConfigParameters.RF1FreqBitMask = (this.f000108.Checked ? '\u0001' : '\0');
                this.m_MonTX3PowerConfigParameters.RF2FreqBitMask = (this.f000107.Checked ? '\u0001' : '\0');
                this.m_MonTX3PowerConfigParameters.RF3FreqBitMask = (this.f000106.Checked ? '\u0001' : '\0');
                this.m_MonTX3PowerConfigParameters.ReportingMode = (char)this.m_nudTX3PowerReportingMode.Value;
                this.m_MonTX3PowerConfigParameters.TxPowerAbsoluteErrorThreshold = (double)this.m_nudTX3PwAbsErrThreshold.Value;
                this.m_MonTX3PowerConfigParameters.TxPowerFlatnessErrorThreshold = (double)this.m_nudTX3PwFlatnessThreshold.Value;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateTX3PowerMonConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX3PowerMonConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudTX3PwrMonProfileIndex.Value = this.m_MonTX3PowerConfigParameters.ProfileIndex;
                this.f000108.Checked = (this.m_MonTX3PowerConfigParameters.RF1FreqBitMask == '\u0001');
                this.f000107.Checked = (this.m_MonTX3PowerConfigParameters.RF2FreqBitMask == '\u0001');
                this.f000106.Checked = (this.m_MonTX3PowerConfigParameters.RF3FreqBitMask == '\u0001');
                this.m_nudTX3PowerReportingMode.Value = this.m_MonTX3PowerConfigParameters.ReportingMode;
                this.m_nudTX3PwAbsErrThreshold.Value = (decimal)this.m_MonTX3PowerConfigParameters.TxPowerAbsoluteErrorThreshold;
                this.m_nudTX3PwFlatnessThreshold.Value = (decimal)this.m_MonTX3PowerConfigParameters.TxPowerFlatnessErrorThreshold;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool CascadeTx3PowerMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, uint RF12TxPowerValue, uint RF3TxPowerValue, uint TimeStamp)
        {
            if (base.InvokeRequired)
            {
                delegate0100 method = new delegate0100(this.CascadeTx3PowerMonitoringReport);
                base.Invoke(method, new object[]
                {
                    RadarDeviceId,
                    StatusFlags,
                    ErrorCode,
                    ProfileIndex,
                    RF12TxPowerValue,
                    RF3TxPowerValue,
                    TimeStamp
                });
            }
            else
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                string empty7 = string.Empty;
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    if (RadarDeviceId == 1U)
                    {
                        if ((StatusFlags & 1) == 1)
                        {
                            Convert.ToString(StatusFlags);
                        }
                        else
                        {
                            Convert.ToString(StatusFlags);
                        }
                        Convert.ToString(ErrorCode);
                        Convert.ToString(ProfileIndex);
                        ushort num = (ushort)(RF12TxPowerValue & 65535U);
                        if (num > 32767)
                        {
                            Convert.ToString((double)((short)((int)num - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num / 10.0);
                        }
                        ushort num2 = (ushort)(RF12TxPowerValue >> 16);
                        if (num2 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num2 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num2 / 10.0);
                        }
                        ushort num3 = (ushort)(RF3TxPowerValue & 65535U);
                        if (num3 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num3 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num3 / 10.0);
                        }
                        Convert.ToString(TimeStamp);
                    }
                }
                else
                {
                    if ((StatusFlags & 1) == 1)
                    {
                        Convert.ToString(StatusFlags);
                    }
                    else
                    {
                        Convert.ToString(StatusFlags);
                    }
                    Convert.ToString(ErrorCode);
                    Convert.ToString(ProfileIndex);
                    ushort num4 = (ushort)(RF12TxPowerValue & 65535U);
                    if (num4 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num4 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num4 / 10.0);
                    }
                    ushort num5 = (ushort)(RF12TxPowerValue >> 16);
                    if (num5 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num5 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num5 / 10.0);
                    }
                    ushort num6 = (ushort)(RF3TxPowerValue & 65535U);
                    if (num6 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num6 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num6 / 10.0);
                    }
                    Convert.ToString(TimeStamp);
                }
            }
            return true;
        }

        private int iSetTX1BallBreakMonConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTX1BallBreakMonConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetTX1BallBreakMonConfig()
        {
            this.iSetTX1BallBreakMonConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetTX1BallBreakMonConfigAsync()
        {
            new del_v_v(this.iSetTX1BallBreakMonConfig).BeginInvoke(null, null);
        }

        private void m_btnTX1BallBreakMonConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetTX1BallBreakMonConfigAsync();
        }

        public bool UpdateTX1BallBreakMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX1BallBreakMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_MonTx1BallBreakConfigParameters.ReportingMode = (char)this.m_nudTX1BallBreakMonReportingMode.Value;
                this.m_MonTx1BallBreakConfigParameters.TXReflectionCoeffMagnitudeThreshold = (double)this.m_nudTX1ReflCoeffMagThreshold.Value;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateTX1BallBreakMonConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX1BallBreakMonConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudTX1BallBreakMonReportingMode.Value = this.m_MonTx1BallBreakConfigParameters.ReportingMode;
                this.m_nudTX1ReflCoeffMagThreshold.Value = (decimal)this.m_MonTx1BallBreakConfigParameters.TXReflectionCoeffMagnitudeThreshold;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool CascadeTX1BallBreakMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, ushort TxReflCoeffMagValue, uint TimeStamp)
        {
            if (base.InvokeRequired)
            {
                delegate0114 method = new delegate0114(this.CascadeTX1BallBreakMonitoringReport);
                base.Invoke(method, new object[]
                {
                    RadarDeviceId,
                    StatusFlags,
                    ErrorCode,
                    TxReflCoeffMagValue,
                    TimeStamp
                });
            }
            else
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    if (RadarDeviceId == 1U)
                    {
                        Convert.ToString(StatusFlags);
                        Convert.ToString(ErrorCode);
                        if (TxReflCoeffMagValue > 32767)
                        {
                            Convert.ToString((double)((short)((int)TxReflCoeffMagValue - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)TxReflCoeffMagValue / 10.0);
                        }
                        Convert.ToString(TimeStamp);
                    }
                }
                else
                {
                    Convert.ToString(StatusFlags);
                    Convert.ToString(ErrorCode);
                    if (TxReflCoeffMagValue > 32767)
                    {
                        Convert.ToString((double)((short)((int)TxReflCoeffMagValue - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)TxReflCoeffMagValue / 10.0);
                    }
                    Convert.ToString(TimeStamp);
                }
            }
            return true;
        }

        private int iSetTX2BallBreakMonConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTX2BallBreakMonConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetTX2BallBreakMonConfig()
        {
            this.iSetTX2BallBreakMonConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetTX2BallBreakMonConfigAsync()
        {
            new del_v_v(this.iSetTX2BallBreakMonConfig).BeginInvoke(null, null);
        }

        private void m_btnTX2BallBreakMonConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetTX2BallBreakMonConfigAsync();
        }

        public bool UpdateTX2BallBreakMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX2BallBreakMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_MonTx2BallBreakConfigParameters.ReportingMode = (char)this.m_nudTX2BallBreakMonReportingMode.Value;
                this.m_MonTx2BallBreakConfigParameters.TXReflectionCoeffMagnitudeThreshold = (double)this.m_nudTX2ReflCoeffMagThreshold.Value;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateTX2BallBreakMonConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX2BallBreakMonConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudTX2BallBreakMonReportingMode.Value = this.m_MonTx2BallBreakConfigParameters.ReportingMode;
                this.m_nudTX2ReflCoeffMagThreshold.Value = (decimal)this.m_MonTx2BallBreakConfigParameters.TXReflectionCoeffMagnitudeThreshold;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool CascadeTX2BallBreakMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, ushort TxReflCoeffMagValue, uint TimeStamp)
        {
            if (base.InvokeRequired)
            {
                delegate0114 method = new delegate0114(this.CascadeTX2BallBreakMonitoringReport);
                base.Invoke(method, new object[]
                {
                    RadarDeviceId,
                    StatusFlags,
                    ErrorCode,
                    TxReflCoeffMagValue,
                    TimeStamp
                });
            }
            else
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    if (RadarDeviceId == 1U)
                    {
                        Convert.ToString(StatusFlags);
                        Convert.ToString(ErrorCode);
                        if (TxReflCoeffMagValue > 32767)
                        {
                            Convert.ToString((double)((short)((int)TxReflCoeffMagValue - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)TxReflCoeffMagValue / 10.0);
                        }
                        Convert.ToString(TimeStamp);
                    }
                }
                else
                {
                    Convert.ToString(StatusFlags);
                    Convert.ToString(ErrorCode);
                    if (TxReflCoeffMagValue > 32767)
                    {
                        Convert.ToString((double)((short)((int)TxReflCoeffMagValue - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)TxReflCoeffMagValue / 10.0);
                    }
                    Convert.ToString(TimeStamp);
                }
            }
            return true;
        }

        private int iSetTX3BallBreakMonConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTX3BallBreakMonConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetTX3BallBreakMonConfig()
        {
            this.iSetTX3BallBreakMonConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetTX3BallBreakMonConfigAsync()
        {
            new del_v_v(this.iSetTX3BallBreakMonConfig).BeginInvoke(null, null);
        }

        private void m_btnTX3BallBreakMonConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetTX3BallBreakMonConfigAsync();
        }

        public bool UpdateTX3BallBreakMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX3BallBreakMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_MonTx3BallBreakConfigParameters.ReportingMode = (char)this.m_nudTX3BallBreakMonReportingMode.Value;
                this.m_MonTx3BallBreakConfigParameters.TXReflectionCoeffMagnitudeThreshold = (double)this.m_nudTX3ReflCoeffMagThreshold.Value;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateTX3BallBreakMonConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX3BallBreakMonConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudTX3BallBreakMonReportingMode.Value = this.m_MonTx3BallBreakConfigParameters.ReportingMode;
                this.m_nudTX3ReflCoeffMagThreshold.Value = (decimal)this.m_MonTx3BallBreakConfigParameters.TXReflectionCoeffMagnitudeThreshold;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool CascadeTX3BallBreakMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, ushort TxReflCoeffMagValue, uint TimeStamp)
        {
            if (base.InvokeRequired)
            {
                delegate0114 method = new delegate0114(this.CascadeTX3BallBreakMonitoringReport);
                base.Invoke(method, new object[]
                {
                    RadarDeviceId,
                    StatusFlags,
                    ErrorCode,
                    TxReflCoeffMagValue,
                    TimeStamp
                });
            }
            else
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    if (RadarDeviceId == 1U)
                    {
                        Convert.ToString(StatusFlags);
                        Convert.ToString(ErrorCode);
                        if (TxReflCoeffMagValue > 32767)
                        {
                            Convert.ToString((double)((short)((int)TxReflCoeffMagValue - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)TxReflCoeffMagValue / 10.0);
                        }
                        Convert.ToString(TimeStamp);
                    }
                }
                else
                {
                    Convert.ToString(StatusFlags);
                    Convert.ToString(ErrorCode);
                    if (TxReflCoeffMagValue > 32767)
                    {
                        Convert.ToString((double)((short)((int)TxReflCoeffMagValue - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)TxReflCoeffMagValue / 10.0);
                    }
                    Convert.ToString(TimeStamp);
                }
            }
            return true;
        }

        private int iSetTX1BPMPhaseMonConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTX1BPMPhaseMonConfig_Gui(is_starting_op, is_ending_op);
        }

        private void m000005()
        {
            this.iSetTX1BPMPhaseMonConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetTX1BPMPhaseMonConfigAsync()
        {
            new del_v_v(this.m000005).BeginInvoke(null, null);
        }

        private void m_btnTX1BPMPhaseMonConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetTX1BPMPhaseMonConfigAsync();
        }

        public bool UpdateTX1BPMPhaseMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX1BPMPhaseMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_MonTx1BPMPhaseConfigParameters.ProfileIndex = (byte)this.m_nudTX1BPMPhaseMonProfileIndex.Value;
                this.m_MonTx1BPMPhaseConfigParameters.phaseShifterCfgIncVal = (float)this.m_nudTX1BPMPhaseMonPhaseShiftCfg.Value;
                this.m_MonTx1BPMPhaseConfigParameters.phaseShifterMonEna = (byte)(this.m_chbTX0BPMMonPhaseShiftMonEna.Checked ? 1 : 0);
                this.m_MonTx1BPMPhaseConfigParameters.phaseShifterCfgIncValEna = (byte)(this.m_chbTX0BPMMonPhaseShiftIncMonValEna.Checked ? 1 : 0);
                this.m_MonTx1BPMPhaseConfigParameters.phaseShifter1 = (float)this.m_nudTX1BPMPhaseMonPhaseShift1.Value;
                this.m_MonTx1BPMPhaseConfigParameters.phaseShifter2 = (float)this.m_nudTX1BPMPhaseMonPhaseShift2.Value;
                this.m_MonTx1BPMPhaseConfigParameters.ReportingMode = (byte)this.m_nudTX1BPMPhaseMonReportMode.Value;
                this.m_MonTx1BPMPhaseConfigParameters.Rx0Channel = (byte)(this.f00011a.Checked ? 1 : 0);
                this.m_MonTx1BPMPhaseConfigParameters.Rx1Channel = (byte)(this.f000119.Checked ? 1 : 0);
                this.m_MonTx1BPMPhaseConfigParameters.Rx2Channel = (byte)(this.f000120.Checked ? 1 : 0);
                this.m_MonTx1BPMPhaseConfigParameters.Rx3Channel = (byte)(this.f00011c.Checked ? 1 : 0);
                this.m_MonTx1BPMPhaseConfigParameters.TxBPMPhaseErrorThreshold = (double)this.m_nudTX1BPMPhaseMonErrorThreshold.Value;
                this.m_MonTx1BPMPhaseConfigParameters.TxBPMAmplitudeErrorThreshold = (double)this.m_nudTX1BPMAmplitudeMonErrorThreshold.Value;
                this.m_MonTx1BPMPhaseConfigParameters.TxPhaseShifter1Threshold = (double)this.f00012d.Value;
                this.m_MonTx1BPMPhaseConfigParameters.TxPhaseShifter2Threshold = (double)this.f00012c.Value;
                this.m_MonTx1BPMPhaseConfigParameters.Reserved = 0;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool m000006()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.m000006);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudTX1BPMPhaseMonProfileIndex.Value = this.m_MonTx1BPMPhaseConfigParameters.ProfileIndex;
                this.m_nudTX1BPMPhaseMonPhaseShiftCfg.Value = (decimal)this.m_MonTx1BPMPhaseConfigParameters.phaseShifterCfgIncVal;
                this.m_chbTX0BPMMonPhaseShiftMonEna.Checked = (this.m_MonTx1BPMPhaseConfigParameters.phaseShifterMonEna == 1);
                this.m_chbTX0BPMMonPhaseShiftIncMonValEna.Checked = (this.m_MonTx1BPMPhaseConfigParameters.phaseShifterCfgIncValEna == 1);
                this.m_nudTX1BPMPhaseMonPhaseShift1.Value = (decimal)this.m_MonTx1BPMPhaseConfigParameters.phaseShifter1;
                this.m_nudTX1BPMPhaseMonPhaseShift2.Value = (decimal)this.m_MonTx1BPMPhaseConfigParameters.phaseShifter2;
                this.m_nudTX1BPMPhaseMonReportMode.Value = this.m_MonTx1BPMPhaseConfigParameters.ReportingMode;
                this.f00011a.Checked = (this.m_MonTx1BPMPhaseConfigParameters.Rx0Channel == 1);
                this.f000119.Checked = (this.m_MonTx1BPMPhaseConfigParameters.Rx1Channel == 1);
                this.f000120.Checked = (this.m_MonTx1BPMPhaseConfigParameters.Rx2Channel == 1);
                this.f00011c.Checked = (this.m_MonTx1BPMPhaseConfigParameters.Rx3Channel == 1);
                this.m_nudTX1BPMPhaseMonErrorThreshold.Value = (decimal)this.m_MonTx1BPMPhaseConfigParameters.TxBPMPhaseErrorThreshold;
                this.m_nudTX1BPMAmplitudeMonErrorThreshold.Value = (decimal)this.m_MonTx1BPMPhaseConfigParameters.TxBPMAmplitudeErrorThreshold;
                this.f00012d.Value = (decimal)this.m_MonTx1BPMPhaseConfigParameters.TxPhaseShifter1Threshold;
                this.f00012c.Value = (decimal)this.m_MonTx1BPMPhaseConfigParameters.TxPhaseShifter2Threshold;
                this.m_MonTx1BPMPhaseConfigParameters.Reserved = 0;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool CascadeTx1BPMPhaseMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, byte TxPhaseShifter2LSB, ushort TxPhaseShifter1Val, ushort Tx1BPMPhaseErrorVal, byte Tx1BPMAmplitudeErrorVal, byte TxPhaseShifter2MSB, uint TimeStamp)
        {
            if (base.InvokeRequired)
            {
                del_u_us_us_c_c_us_us_c_c_u method = new del_u_us_us_c_c_us_us_c_c_u(this.CascadeTx1BPMPhaseMonitoringReport);
                base.Invoke(method, new object[]
                {
                    RadarDeviceId,
                    StatusFlags,
                    ErrorCode,
                    ProfileIndex,
                    TxPhaseShifter2LSB,
                    TxPhaseShifter1Val,
                    Tx1BPMPhaseErrorVal,
                    Tx1BPMAmplitudeErrorVal,
                    TxPhaseShifter2MSB,
                    TimeStamp
                });
            }
            else
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                string text = string.Empty;
                string text2 = string.Empty;
                string empty7 = string.Empty;
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    if (RadarDeviceId == 1U)
                    {
                        Convert.ToString(StatusFlags);
                        Convert.ToString(ErrorCode);
                        Convert.ToString(ProfileIndex);
                        text2 = Convert.ToString(Math.Round((double)(((int)TxPhaseShifter2MSB | (int)TxPhaseShifter2LSB << 8) * 360) / 65536.0, 2));
                        if (!text2.Contains("."))
                        {
                            text2 += ".00";
                        }
                        if (TxPhaseShifter1Val > 32767)
                        {
                            text = Convert.ToString(Math.Round((double)((ushort)((int)TxPhaseShifter1Val - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            text = Convert.ToString(Math.Round((double)(TxPhaseShifter1Val * 360) / 65536.0, 2));
                        }
                        if (!text.Contains("."))
                        {
                            text += ".00";
                        }
                        if (Tx1BPMPhaseErrorVal > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)Tx1BPMPhaseErrorVal - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(Tx1BPMPhaseErrorVal * 360) / 65536.0, 2));
                        }
                        if (Tx1BPMAmplitudeErrorVal > 127)
                        {
                            Convert.ToString((double)((sbyte)(Tx1BPMAmplitudeErrorVal - byte.MaxValue)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)Tx1BPMAmplitudeErrorVal / 10.0);
                        }
                        Convert.ToString(Math.Round((double)((int)TxPhaseShifter2MSB * 360) / 65536.0, 2));
                        Convert.ToString(TimeStamp);
                    }
                }
                else
                {
                    Convert.ToString(StatusFlags);
                    Convert.ToString(ErrorCode);
                    Convert.ToString(ProfileIndex);
                    text2 = Convert.ToString(Math.Round((double)(((int)TxPhaseShifter2MSB | (int)TxPhaseShifter2LSB << 8) * 360) / 65536.0, 2));
                    if (!text2.Contains("."))
                    {
                        text2 += ".00";
                    }
                    if (TxPhaseShifter1Val > 32767)
                    {
                        text = Convert.ToString(Math.Round((double)((ushort)((int)TxPhaseShifter1Val - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        text = Convert.ToString(Math.Round((double)(TxPhaseShifter1Val * 360) / 65536.0, 2));
                    }
                    if (!text.Contains("."))
                    {
                        text += ".00";
                    }
                    if (Tx1BPMPhaseErrorVal > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)Tx1BPMPhaseErrorVal - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(Tx1BPMPhaseErrorVal * 360) / 65536.0, 2));
                    }
                    if (Tx1BPMAmplitudeErrorVal > 127)
                    {
                        Convert.ToString((double)((sbyte)(Tx1BPMAmplitudeErrorVal - byte.MaxValue)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)Tx1BPMAmplitudeErrorVal / 10.0);
                    }
                    Convert.ToString(Math.Round((double)((int)TxPhaseShifter2MSB * 360) / 65536.0, 2));
                    Convert.ToString(TimeStamp);
                }
            }
            return true;
        }

        private int iSetTX2BPMPhaseMonConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTX2BPMPhaseMonConfig_Gui(is_starting_op, is_ending_op);
        }

        private void m000007()
        {
            this.iSetTX2BPMPhaseMonConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetTX2BPMPhaseMonConfigAsync()
        {
            new del_v_v(this.m000007).BeginInvoke(null, null);
        }

        private void m_btnTX2BPMPhaseMonConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetTX2BPMPhaseMonConfigAsync();
        }

        public bool UpdateTX2BPMPhaseMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX2BPMPhaseMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_MonTx2BPMPhaseConfigParameters.ProfileIndex = (byte)this.m_nudTX2BPMPhaseMonProfileIndex.Value;
                this.m_MonTx2BPMPhaseConfigParameters.phaseShifterCfgIncVal = (float)this.m_nudTX2BPMPhaseMonPhaseShiftCfg.Value;
                this.m_MonTx2BPMPhaseConfigParameters.phaseShifterMonEna = (byte)(this.m_chbTX1BPMMonPhaseShiftMonEna.Checked ? 1 : 0);
                this.m_MonTx2BPMPhaseConfigParameters.phaseShifterCfgIncValEna = (byte)(this.m_chbTX1BPMMonPhaseShiftIncMonValEna.Checked ? 1 : 0);
                this.m_MonTx2BPMPhaseConfigParameters.phaseShifter1 = (float)this.m_nudTX2BPMPhaseMonPhaseShift1.Value;
                this.m_MonTx2BPMPhaseConfigParameters.phaseShifter2 = (float)this.m_nudTX2BPMPhaseMonPhaseShift2.Value;
                this.m_MonTx2BPMPhaseConfigParameters.ReportingMode = (byte)this.m_nudTX2BPMPhaseMonReportMode.Value;
                this.m_MonTx2BPMPhaseConfigParameters.Rx0Channel = (byte)(this.f00011e.Checked ? 1 : 0);
                this.m_MonTx2BPMPhaseConfigParameters.Rx1Channel = (byte)(this.f00011d.Checked ? 1 : 0);
                this.m_MonTx2BPMPhaseConfigParameters.Rx2Channel = (byte)(this.f00011f.Checked ? 1 : 0);
                this.m_MonTx2BPMPhaseConfigParameters.Rx3Channel = (byte)(this.f00011b.Checked ? 1 : 0);
                this.m_MonTx2BPMPhaseConfigParameters.TxBPMPhaseErrorThreshold = (double)this.m_nudTX2BPMPhaseMonErrorThreshold.Value;
                this.m_MonTx2BPMPhaseConfigParameters.TxBPMAmplitudeErrorThreshold = (double)this.m_nudTX2BPMAmplitudeMonErrorThreshold.Value;
                this.m_MonTx2BPMPhaseConfigParameters.TxPhaseShifter1Threshold = (double)this.f00012b.Value;
                this.m_MonTx2BPMPhaseConfigParameters.TxPhaseShifter2Threshold = (double)this.f00012a.Value;
                this.m_MonTx2BPMPhaseConfigParameters.Reserved = 0;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool m000008()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.m000008);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudTX2BPMPhaseMonProfileIndex.Value = this.m_MonTx2BPMPhaseConfigParameters.ProfileIndex;
                this.m_nudTX2BPMPhaseMonPhaseShiftCfg.Value = (decimal)this.m_MonTx2BPMPhaseConfigParameters.phaseShifterCfgIncVal;
                this.m_chbTX1BPMMonPhaseShiftMonEna.Checked = (this.m_MonTx2BPMPhaseConfigParameters.phaseShifterMonEna == 1);
                this.m_chbTX1BPMMonPhaseShiftIncMonValEna.Checked = (this.m_MonTx2BPMPhaseConfigParameters.phaseShifterCfgIncValEna == 1);
                this.m_nudTX2BPMPhaseMonPhaseShift1.Value = (decimal)this.m_MonTx2BPMPhaseConfigParameters.phaseShifter1;
                this.m_nudTX2BPMPhaseMonPhaseShift2.Value = (decimal)this.m_MonTx2BPMPhaseConfigParameters.phaseShifter2;
                this.m_nudTX2BPMPhaseMonReportMode.Value = this.m_MonTx2BPMPhaseConfigParameters.ReportingMode;
                this.f00011e.Checked = (this.m_MonTx2BPMPhaseConfigParameters.Rx0Channel == 1);
                this.f00011d.Checked = (this.m_MonTx2BPMPhaseConfigParameters.Rx1Channel == 1);
                this.f00011f.Checked = (this.m_MonTx2BPMPhaseConfigParameters.Rx2Channel == 1);
                this.f00011b.Checked = (this.m_MonTx2BPMPhaseConfigParameters.Rx3Channel == 1);
                this.m_nudTX2BPMPhaseMonErrorThreshold.Value = (decimal)this.m_MonTx2BPMPhaseConfigParameters.TxBPMPhaseErrorThreshold;
                this.m_nudTX2BPMAmplitudeMonErrorThreshold.Value = (decimal)this.m_MonTx2BPMPhaseConfigParameters.TxBPMAmplitudeErrorThreshold;
                this.f00012b.Value = (decimal)this.m_MonTx2BPMPhaseConfigParameters.TxPhaseShifter1Threshold;
                this.f00012a.Value = (decimal)this.m_MonTx2BPMPhaseConfigParameters.TxPhaseShifter2Threshold;
                this.m_MonTx2BPMPhaseConfigParameters.Reserved = 0;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool CascadeTx2BPMPhaseMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, byte TxPhaseShifter2LSB, ushort TxPhaseShifter1Val, ushort Tx1BPMPhaseErrorVal, byte Tx1BPMAmplitudeErrorVal, byte TxPhaseShifter2MSB, uint TimeStamp)
        {
            if (base.InvokeRequired)
            {
                del_u_us_us_c_c_us_us_c_c_u method = new del_u_us_us_c_c_us_us_c_c_u(this.CascadeTx2BPMPhaseMonitoringReport);
                base.Invoke(method, new object[]
                {
                    RadarDeviceId,
                    StatusFlags,
                    ErrorCode,
                    ProfileIndex,
                    TxPhaseShifter2LSB,
                    TxPhaseShifter1Val,
                    Tx1BPMPhaseErrorVal,
                    Tx1BPMAmplitudeErrorVal,
                    TxPhaseShifter2MSB,
                    TimeStamp
                });
            }
            else
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                string text = string.Empty;
                string text2 = string.Empty;
                string empty7 = string.Empty;
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    if (RadarDeviceId == 1U)
                    {
                        Convert.ToString(StatusFlags);
                        Convert.ToString(ErrorCode);
                        Convert.ToString(ProfileIndex);
                        text2 = Convert.ToString(Math.Round((double)(((int)TxPhaseShifter2MSB | (int)TxPhaseShifter2LSB << 8) * 360) / 65536.0, 2));
                        if (!text2.Contains("."))
                        {
                            text2 += ".00";
                        }
                        if (TxPhaseShifter1Val > 32767)
                        {
                            text = Convert.ToString(Math.Round((double)((ushort)((int)TxPhaseShifter1Val - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            text = Convert.ToString(Math.Round((double)(TxPhaseShifter1Val * 360) / 65536.0, 2));
                        }
                        if (!text.Contains("."))
                        {
                            text += ".00";
                        }
                        if (Tx1BPMPhaseErrorVal > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)Tx1BPMPhaseErrorVal - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(Tx1BPMPhaseErrorVal * 360) / 65536.0, 2));
                        }
                        if (Tx1BPMAmplitudeErrorVal > 127)
                        {
                            Convert.ToString((double)((sbyte)(Tx1BPMAmplitudeErrorVal - byte.MaxValue)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)Tx1BPMAmplitudeErrorVal / 10.0);
                        }
                        Convert.ToString(Math.Round((double)((int)TxPhaseShifter2MSB * 360) / 65536.0, 2));
                        Convert.ToString(TimeStamp);
                    }
                }
                else
                {
                    Convert.ToString(StatusFlags);
                    Convert.ToString(ErrorCode);
                    Convert.ToString(ProfileIndex);
                    text2 = Convert.ToString(Math.Round((double)(((int)TxPhaseShifter2MSB | (int)TxPhaseShifter2LSB << 8) * 360) / 65536.0, 2));
                    if (!text2.Contains("."))
                    {
                        text2 += ".00";
                    }
                    if (TxPhaseShifter1Val > 32767)
                    {
                        text = Convert.ToString(Math.Round((double)((ushort)((int)TxPhaseShifter1Val - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        text = Convert.ToString(Math.Round((double)(TxPhaseShifter1Val * 360) / 65536.0, 2));
                    }
                    if (!text.Contains("."))
                    {
                        text += ".00";
                    }
                    if (Tx1BPMPhaseErrorVal > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)Tx1BPMPhaseErrorVal - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(Tx1BPMPhaseErrorVal * 360) / 65536.0, 2));
                    }
                    if (Tx1BPMAmplitudeErrorVal > 127)
                    {
                        Convert.ToString((double)((sbyte)(Tx1BPMAmplitudeErrorVal - byte.MaxValue)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)Tx1BPMAmplitudeErrorVal / 10.0);
                    }
                    Convert.ToString(Math.Round((double)((int)TxPhaseShifter2MSB * 360) / 65536.0, 2));
                    Convert.ToString(TimeStamp);
                }
            }
            return true;
        }

        private int iSetTX3BPMPhaseMonConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTX3BPMPhaseMonConfig_Gui(is_starting_op, is_ending_op);
        }

        private void m000009()
        {
            this.iSetTX3BPMPhaseMonConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetTX3BPMPhaseMonConfigAsync()
        {
            new del_v_v(this.m000009).BeginInvoke(null, null);
        }

        private void m_btnTX3BPMPhaseMonConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetTX3BPMPhaseMonConfigAsync();
        }

        public bool UpdateTX3BPMPhaseMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTX3BPMPhaseMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_MonTx3BPMPhaseConfigParameters.ProfileIndex = (byte)this.m_nudTX3BPMPhaseMonProfileIndex.Value;
                this.m_MonTx3BPMPhaseConfigParameters.phaseShifterCfgIncVal = (float)this.m_nudTX3BPMPhaseMonPhaseShiftCfg.Value;
                this.m_MonTx3BPMPhaseConfigParameters.phaseShifterMonEna = (byte)(this.m_chbTX2BPMMonPhaseShiftMonEna.Checked ? 1 : 0);
                this.m_MonTx3BPMPhaseConfigParameters.phaseShifterCfgIncValEna = (byte)(this.m_chbTX2BPMMonPhaseShiftIncMonValEna.Checked ? 1 : 0);
                this.m_MonTx3BPMPhaseConfigParameters.phaseShifter1 = (float)this.m_nudTX3BPMPhaseMonPhaseShift1.Value;
                this.m_MonTx3BPMPhaseConfigParameters.phaseShifter2 = (float)this.m_nudTX3BPMPhaseMonPhaseShift2.Value;
                this.m_MonTx3BPMPhaseConfigParameters.ReportingMode = (byte)this.m_nudTX3BPMPhaseMonReportMode.Value;
                this.m_MonTx3BPMPhaseConfigParameters.Rx0Channel = (byte)(this.f000123.Checked ? 1 : 0);
                this.m_MonTx3BPMPhaseConfigParameters.Rx1Channel = (byte)(this.f000122.Checked ? 1 : 0);
                this.m_MonTx3BPMPhaseConfigParameters.Rx2Channel = (byte)(this.f000124.Checked ? 1 : 0);
                this.m_MonTx3BPMPhaseConfigParameters.Rx3Channel = (byte)(this.f000121.Checked ? 1 : 0);
                this.m_MonTx3BPMPhaseConfigParameters.TxBPMPhaseErrorThreshold = (double)this.m_nudTX3BPMPhaseMonErrorThreshold.Value;
                this.m_MonTx3BPMPhaseConfigParameters.TxBPMAmplitudeErrorThreshold = (double)this.m_nudTX3BPMAmplitudeMonErrorThreshold.Value;
                this.m_MonTx3BPMPhaseConfigParameters.TxPhaseShifter1Threshold = (double)this.f000129.Value;
                this.m_MonTx3BPMPhaseConfigParameters.TxPhaseShifter2Threshold = (double)this.f000128.Value;
                this.m_MonTx2BPMPhaseConfigParameters.Reserved = 0;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool m00000a()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.m00000a);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudTX3BPMPhaseMonProfileIndex.Value = this.m_MonTx3BPMPhaseConfigParameters.ProfileIndex;
                this.m_nudTX3BPMPhaseMonPhaseShiftCfg.Value = (decimal)this.m_MonTx3BPMPhaseConfigParameters.phaseShifterCfgIncVal;
                this.m_chbTX2BPMMonPhaseShiftMonEna.Checked = (this.m_MonTx3BPMPhaseConfigParameters.phaseShifterMonEna == 1);
                this.m_chbTX2BPMMonPhaseShiftIncMonValEna.Checked = (this.m_MonTx3BPMPhaseConfigParameters.phaseShifterCfgIncValEna == 1);
                this.m_nudTX3BPMPhaseMonPhaseShift1.Value = (decimal)this.m_MonTx3BPMPhaseConfigParameters.phaseShifter1;
                this.m_nudTX3BPMPhaseMonPhaseShift2.Value = (decimal)this.m_MonTx3BPMPhaseConfigParameters.phaseShifter2;
                this.m_nudTX3BPMPhaseMonReportMode.Value = this.m_MonTx3BPMPhaseConfigParameters.ReportingMode;
                this.f000123.Checked = (this.m_MonTx3BPMPhaseConfigParameters.Rx0Channel == 1);
                this.f000122.Checked = (this.m_MonTx3BPMPhaseConfigParameters.Rx1Channel == 1);
                this.f000124.Checked = (this.m_MonTx3BPMPhaseConfigParameters.Rx2Channel == 1);
                this.f000121.Checked = (this.m_MonTx3BPMPhaseConfigParameters.Rx3Channel == 1);
                this.m_nudTX3BPMPhaseMonErrorThreshold.Value = (decimal)this.m_MonTx3BPMPhaseConfigParameters.TxBPMPhaseErrorThreshold;
                this.m_nudTX3BPMAmplitudeMonErrorThreshold.Value = (decimal)this.m_MonTx3BPMPhaseConfigParameters.TxBPMAmplitudeErrorThreshold;
                this.f000129.Value = (decimal)this.m_MonTx3BPMPhaseConfigParameters.TxPhaseShifter1Threshold;
                this.f000128.Value = (decimal)this.m_MonTx3BPMPhaseConfigParameters.TxPhaseShifter2Threshold;
                this.m_MonTx3BPMPhaseConfigParameters.Reserved = 0;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool CascadeTx3BPMPhaseMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, byte TxPhaseShifter2LSB, ushort TxPhaseShifter1Val, ushort Tx1BPMPhaseErrorVal, byte Tx1BPMAmplitudeErrorVal, byte TxPhaseShifter2MSB, uint TimeStamp)
        {
            if (base.InvokeRequired)
            {
                del_u_us_us_c_c_us_us_c_c_u method = new del_u_us_us_c_c_us_us_c_c_u(this.CascadeTx3BPMPhaseMonitoringReport);
                base.Invoke(method, new object[]
                {
                    RadarDeviceId,
                    StatusFlags,
                    ErrorCode,
                    ProfileIndex,
                    TxPhaseShifter2LSB,
                    TxPhaseShifter1Val,
                    Tx1BPMPhaseErrorVal,
                    Tx1BPMAmplitudeErrorVal,
                    TxPhaseShifter2MSB,
                    TimeStamp
                });
            }
            else
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                string text = string.Empty;
                string text2 = string.Empty;
                string empty7 = string.Empty;
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    if (RadarDeviceId == 1U)
                    {
                        Convert.ToString(StatusFlags);
                        Convert.ToString(ErrorCode);
                        Convert.ToString(ProfileIndex);
                        text2 = Convert.ToString(Math.Round((double)(((int)TxPhaseShifter2MSB | (int)TxPhaseShifter2LSB << 8) * 360) / 65536.0, 2));
                        if (!text2.Contains("."))
                        {
                            text2 += ".00";
                        }
                        if (TxPhaseShifter1Val > 32767)
                        {
                            text = Convert.ToString(Math.Round((double)((ushort)((int)TxPhaseShifter1Val - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            text = Convert.ToString(Math.Round((double)(TxPhaseShifter1Val * 360) / 65536.0, 2));
                        }
                        if (!text.Contains("."))
                        {
                            text += ".00";
                        }
                        if (Tx1BPMPhaseErrorVal > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)Tx1BPMPhaseErrorVal - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(Tx1BPMPhaseErrorVal * 360) / 65536.0, 2));
                        }
                        if (Tx1BPMAmplitudeErrorVal > 127)
                        {
                            Convert.ToString((double)((sbyte)(Tx1BPMAmplitudeErrorVal - byte.MaxValue)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)Tx1BPMAmplitudeErrorVal / 10.0);
                        }
                        Convert.ToString(Math.Round((double)((int)TxPhaseShifter2MSB * 360) / 65536.0, 2));
                        Convert.ToString(TimeStamp);
                    }
                }
                else
                {
                    Convert.ToString(StatusFlags);
                    Convert.ToString(ErrorCode);
                    Convert.ToString(ProfileIndex);
                    text2 = Convert.ToString(Math.Round((double)(((int)TxPhaseShifter2MSB | (int)TxPhaseShifter2LSB << 8) * 360) / 65536.0, 2));
                    if (!text2.Contains("."))
                    {
                        text2 += ".00";
                    }
                    if (TxPhaseShifter1Val > 32767)
                    {
                        text = Convert.ToString(Math.Round((double)((ushort)((int)TxPhaseShifter1Val - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        text = Convert.ToString(Math.Round((double)(TxPhaseShifter1Val * 360) / 65536.0, 2));
                    }
                    if (!text.Contains("."))
                    {
                        text += ".00";
                    }
                    if (Tx1BPMPhaseErrorVal > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)Tx1BPMPhaseErrorVal - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(Tx1BPMPhaseErrorVal * 360) / 65536.0, 2));
                    }
                    if (Tx1BPMAmplitudeErrorVal > 127)
                    {
                        Convert.ToString((double)((sbyte)(Tx1BPMAmplitudeErrorVal - byte.MaxValue)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)Tx1BPMAmplitudeErrorVal / 10.0);
                    }
                    Convert.ToString(Math.Round((double)((int)TxPhaseShifter2MSB * 360) / 65536.0, 2));
                    Convert.ToString(TimeStamp);
                }
            }
            return true;
        }

        private int iSetTXGainPhaseMismatchMonConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTXGainPhaseMismatchMonConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetTXGainPhaseMismatchMonConfig()
        {
            this.iSetTXGainPhaseMismatchMonConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetTXGainPhaseMismatchMonConfigAsync()
        {
            new del_v_v(this.iSetTXGainPhaseMismatchMonConfig).BeginInvoke(null, null);
        }

        private void m_btnTXGainPhaseMismatchMonConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetTXGainPhaseMismatchMonConfigAsync();
        }

        public bool UpdateTXGainPhaseMismatchMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTXGainPhaseMismatchMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_MonTxGainPhaseMismatchConfigParameters.ProfileIndex = (char)this.m_nudTxGainPhaseMismacthMonProfileIndex.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF1FreqBitMask = (this.m_chbRF1TXGainPhaseMismatchMonBitMask.Checked ? '\u0001' : '\0');
                this.m_MonTxGainPhaseMismatchConfigParameters.RF2FreqBitMask = (this.m_chbRF2TXGainPhaseMismatchMonBitMask.Checked ? '\u0001' : '\0');
                this.m_MonTxGainPhaseMismatchConfigParameters.RF3FreqBitMask = (this.m_chbRF3TXGainPhaseMismatchMonBitMask.Checked ? '\u0001' : '\0');
                this.m_MonTxGainPhaseMismatchConfigParameters.Tx1Channel = (this.m_chbTXGainPhaseMismatchMonTx1.Checked ? '\u0001' : '\0');
                this.m_MonTxGainPhaseMismatchConfigParameters.Tx2Channel = (this.m_chbTXGainPhaseMismatchMonTx2.Checked ? '\u0001' : '\0');
                this.m_MonTxGainPhaseMismatchConfigParameters.Tx3Channel = (this.m_chbTXGainPhaseMismatchMonTx3.Checked ? '\u0001' : '\0');
                this.m_MonTxGainPhaseMismatchConfigParameters.Rx0Channel = (this.m_chbTXGainPhaseMismatchMonRx0.Checked ? '\u0001' : '\0');
                this.m_MonTxGainPhaseMismatchConfigParameters.Rx1Channel = (this.m_chbTXGainPhaseMismatchMonRx1.Checked ? '\u0001' : '\0');
                this.m_MonTxGainPhaseMismatchConfigParameters.Rx2Channel = (this.m_chbTXGainPhaseMismatchMonRx2.Checked ? '\u0001' : '\0');
                this.m_MonTxGainPhaseMismatchConfigParameters.Rx3Channel = (this.m_chbTXGainPhaseMismatchMonRx3.Checked ? '\u0001' : '\0');
                this.m_MonTxGainPhaseMismatchConfigParameters.ReportingMode = (char)this.m_nudTxGainPhaseMismacthMonReportingMode.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.TxGainMismatchThreshold = (double)this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.TxPhaseMismatchThreshold = (double)this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx1GainMismatchOffsetVal = (double)this.m_nudRF1TX1TXGainPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx2GainMismatchOffsetVal = (double)this.m_nudRF1TX2TXGainPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx3GainMismatchOffsetVal = (double)this.m_nudRF1TX3TXGainPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx1GainMismatchOffsetVal = (double)this.m_nudRF2TX1TXGainPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx2GainMismatchOffsetVal = (double)this.m_nudRF2TX2TXGainPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx3GainMismatchOffsetVal = (double)this.m_nudRF2TX3TXGainPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx1GainMismatchOffsetVal = (double)this.m_nudRF3TX1TXGainPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx2GainMismatchOffsetVal = (double)this.m_nudRF3TX2TXGainPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx3GainMismatchOffsetVal = (double)this.m_nudRF3TX3TXGainPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx1PhaseMismatchOffsetVal = (double)this.m_nudRF1TX1TXPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx2PhaseMismatchOffsetVal = (double)this.m_nudRF1TX2TXPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx3PhaseMismatchOffsetVal = (double)this.m_nudRF1TX3TXPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx1PhaseMismatchOffsetVal = (double)this.m_nudRF2TX1TXPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx2PhaseMismatchOffsetVal = (double)this.m_nudRF2TX2TXPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx3PhaseMismatchOffsetVal = (double)this.m_nudRF2TX3TXPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx1PhaseMismatchOffsetVal = (double)this.m_nudRF3TX1TXPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx2PhaseMismatchOffsetVal = (double)this.m_nudRF3TX2TXPhaseMismatchOffVal.Value;
                this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx3PhaseMismatchOffsetVal = (double)this.m_nudRF3TX3TXPhaseMismatchOffVal.Value;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateTXGainPhaseMismatchMonConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateTXGainPhaseMismatchMonConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudTxGainPhaseMismacthMonProfileIndex.Value = this.m_MonTxGainPhaseMismatchConfigParameters.ProfileIndex;
                this.m_chbRF1TXGainPhaseMismatchMonBitMask.Checked = (this.m_MonTxGainPhaseMismatchConfigParameters.RF1FreqBitMask == '\u0001');
                this.m_chbRF2TXGainPhaseMismatchMonBitMask.Checked = (this.m_MonTxGainPhaseMismatchConfigParameters.RF2FreqBitMask == '\u0001');
                this.m_chbRF3TXGainPhaseMismatchMonBitMask.Checked = (this.m_MonTxGainPhaseMismatchConfigParameters.RF3FreqBitMask == '\u0001');
                this.m_chbTXGainPhaseMismatchMonTx1.Checked = (this.m_MonTxGainPhaseMismatchConfigParameters.Tx1Channel == '\u0001');
                this.m_chbTXGainPhaseMismatchMonTx2.Checked = (this.m_MonTxGainPhaseMismatchConfigParameters.Tx2Channel == '\u0001');
                this.m_chbTXGainPhaseMismatchMonTx3.Checked = (this.m_MonTxGainPhaseMismatchConfigParameters.Tx3Channel == '\u0001');
                this.m_chbTXGainPhaseMismatchMonRx0.Checked = (this.m_MonTxGainPhaseMismatchConfigParameters.Rx0Channel == '\u0001');
                this.m_chbTXGainPhaseMismatchMonRx1.Checked = (this.m_MonTxGainPhaseMismatchConfigParameters.Rx1Channel == '\u0001');
                this.m_chbTXGainPhaseMismatchMonRx2.Checked = (this.m_MonTxGainPhaseMismatchConfigParameters.Rx2Channel == '\u0001');
                this.m_chbTXGainPhaseMismatchMonRx3.Checked = (this.m_MonTxGainPhaseMismatchConfigParameters.Rx3Channel == '\u0001');
                this.m_nudTxGainPhaseMismacthMonReportingMode.Value = this.m_MonTxGainPhaseMismatchConfigParameters.ReportingMode;
                this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.TxGainMismatchThreshold;
                this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.TxPhaseMismatchThreshold;
                this.m_nudRF1TX1TXGainPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx1GainMismatchOffsetVal;
                this.m_nudRF1TX2TXGainPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx2GainMismatchOffsetVal;
                this.m_nudRF1TX3TXGainPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx3GainMismatchOffsetVal;
                this.m_nudRF2TX1TXGainPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx1GainMismatchOffsetVal;
                this.m_nudRF2TX2TXGainPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx2GainMismatchOffsetVal;
                this.m_nudRF2TX3TXGainPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx3GainMismatchOffsetVal;
                this.m_nudRF3TX1TXGainPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx1GainMismatchOffsetVal;
                this.m_nudRF3TX2TXGainPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx2GainMismatchOffsetVal;
                this.m_nudRF3TX3TXGainPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx3GainMismatchOffsetVal;
                this.m_nudRF1TX1TXPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx1PhaseMismatchOffsetVal;
                this.m_nudRF1TX2TXPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx2PhaseMismatchOffsetVal;
                this.m_nudRF1TX3TXPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF1Tx3PhaseMismatchOffsetVal;
                this.m_nudRF2TX1TXPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx1PhaseMismatchOffsetVal;
                this.m_nudRF2TX2TXPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx2PhaseMismatchOffsetVal;
                this.m_nudRF2TX3TXPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF2Tx3PhaseMismatchOffsetVal;
                this.m_nudRF3TX1TXPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx1PhaseMismatchOffsetVal;
                this.m_nudRF3TX2TXPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx2PhaseMismatchOffsetVal;
                this.m_nudRF3TX3TXPhaseMismatchOffVal.Value = (decimal)this.m_MonTxGainPhaseMismatchConfigParameters.RF3Tx3PhaseMismatchOffsetVal;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool CascadeTxGainPhaseMismatchMonitoringReport(uint RadarDeviceId, ushort StatusFlags, ushort ErrorCode, byte ProfileIndex, uint RF1Tx1Tx2GainValue, uint RF1Tx3RF2Tx1TxGainValue, uint RF2Tx2RF2Tx3TxGainValue, uint RF3Tx1RF3Tx2TxGainValue, uint RF3Tx3GainRF1Tx1PhaseValue, uint RF1Tx2Tx3TxPhaseValue, uint RF2Tx1RF2Tx2TxPhaseValue, uint RF2Tx3RF3Tx1TxPhaseValue, uint RF3Tx2RF3Tx3TxPhaseValue, uint TimeStamp)
        {
            if (base.InvokeRequired)
            {
                delegate0112 method = new delegate0112(this.CascadeTxGainPhaseMismatchMonitoringReport);
                base.Invoke(method, new object[]
                {
                    RadarDeviceId,
                    StatusFlags,
                    ErrorCode,
                    ProfileIndex,
                    RF1Tx1Tx2GainValue,
                    RF1Tx3RF2Tx1TxGainValue,
                    RF2Tx2RF2Tx3TxGainValue,
                    RF3Tx1RF3Tx2TxGainValue,
                    RF3Tx3GainRF1Tx1PhaseValue,
                    RF1Tx2Tx3TxPhaseValue,
                    RF2Tx1RF2Tx2TxPhaseValue,
                    RF2Tx3RF3Tx1TxPhaseValue,
                    RF3Tx2RF3Tx3TxPhaseValue,
                    TimeStamp
                });
            }
            else
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                string empty7 = string.Empty;
                string empty8 = string.Empty;
                string empty9 = string.Empty;
                string empty10 = string.Empty;
                string empty11 = string.Empty;
                string empty12 = string.Empty;
                string empty13 = string.Empty;
                string empty14 = string.Empty;
                string empty15 = string.Empty;
                string empty16 = string.Empty;
                string empty17 = string.Empty;
                string empty18 = string.Empty;
                string empty19 = string.Empty;
                string empty20 = string.Empty;
                string empty21 = string.Empty;
                string empty22 = string.Empty;
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    if (RadarDeviceId == 1U)
                    {
                        Convert.ToString(StatusFlags);
                        Convert.ToString(ErrorCode);
                        Convert.ToString(ProfileIndex);
                        ushort num = (ushort)(RF1Tx1Tx2GainValue & 65535U);
                        if (num > 32767)
                        {
                            Convert.ToString((double)((short)((int)num - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num / 10.0);
                        }
                        ushort num2 = (ushort)(RF1Tx1Tx2GainValue >> 16);
                        if (num2 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num2 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num2 / 10.0);
                        }
                        ushort num3 = (ushort)(RF1Tx3RF2Tx1TxGainValue & 65535U);
                        if (num3 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num3 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num3 / 10.0);
                        }
                        ushort num4 = (ushort)(RF1Tx3RF2Tx1TxGainValue >> 16);
                        if (num4 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num4 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num4 / 10.0);
                        }
                        ushort num5 = (ushort)(RF2Tx2RF2Tx3TxGainValue & 65535U);
                        if (num5 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num5 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num5 / 10.0);
                        }
                        ushort num6 = (ushort)(RF2Tx2RF2Tx3TxGainValue >> 16);
                        if (num6 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num6 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num6 / 10.0);
                        }
                        ushort num7 = (ushort)(RF3Tx1RF3Tx2TxGainValue & 65535U);
                        if (num7 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num7 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num7 / 10.0);
                        }
                        ushort num8 = (ushort)(RF3Tx1RF3Tx2TxGainValue >> 16);
                        if (num8 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num8 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num8 / 10.0);
                        }
                        ushort num9 = (ushort)(RF3Tx3GainRF1Tx1PhaseValue & 65535U);
                        if (num9 > 32767)
                        {
                            Convert.ToString((double)((short)((int)num9 - 65536)) / 10.0);
                        }
                        else
                        {
                            Convert.ToString((double)num9 / 10.0);
                        }
                        ushort num10 = (ushort)(RF3Tx3GainRF1Tx1PhaseValue >> 16);
                        if (num10 > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)num10 - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(num10 * 360) / 65536.0, 2));
                        }
                        ushort num11 = (ushort)(RF1Tx2Tx3TxPhaseValue & 65535U);
                        if (num11 > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)num11 - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(num11 * 360) / 65536.0, 2));
                        }
                        ushort num12 = (ushort)(RF1Tx2Tx3TxPhaseValue >> 16);
                        if (num12 > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)num12 - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(num12 * 360) / 65536.0, 2));
                        }
                        ushort num13 = (ushort)(RF2Tx1RF2Tx2TxPhaseValue & 65535U);
                        if (num13 > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)num13 - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(num13 * 360) / 65536.0, 2));
                        }
                        ushort num14 = (ushort)(RF2Tx1RF2Tx2TxPhaseValue >> 16);
                        if (num14 > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)num14 - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(num14 * 360) / 65536.0, 2));
                        }
                        ushort num15 = (ushort)(RF2Tx3RF3Tx1TxPhaseValue & 65535U);
                        if (num15 > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)num15 - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(num15 * 360) / 65536.0, 2));
                        }
                        ushort num16 = (ushort)(RF2Tx3RF3Tx1TxPhaseValue >> 16);
                        if (num16 > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)num16 - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(num16 * 360) / 65536.0, 2));
                        }
                        ushort num17 = (ushort)(RF3Tx2RF3Tx3TxPhaseValue & 65535U);
                        if (num17 > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)num17 - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(num17 * 360) / 65536.0, 2));
                        }
                        ushort num18 = (ushort)(RF3Tx2RF3Tx3TxPhaseValue >> 16);
                        if (num18 > 32767)
                        {
                            Convert.ToString(Math.Round((double)((ushort)((int)num18 - 65536) * 360) / 65536.0, 2));
                        }
                        else
                        {
                            Convert.ToString(Math.Round((double)(num18 * 360) / 65536.0, 2));
                        }
                        Convert.ToString(TimeStamp);
                    }
                }
                else
                {
                    Convert.ToString(StatusFlags);
                    Convert.ToString(ErrorCode);
                    Convert.ToString(ProfileIndex);
                    ushort num19 = (ushort)(RF1Tx1Tx2GainValue & 65535U);
                    if (num19 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num19 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num19 / 10.0);
                    }
                    ushort num20 = (ushort)(RF1Tx1Tx2GainValue >> 16);
                    if (num20 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num20 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num20 / 10.0);
                    }
                    ushort num21 = (ushort)(RF1Tx3RF2Tx1TxGainValue & 65535U);
                    if (num21 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num21 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num21 / 10.0);
                    }
                    ushort num22 = (ushort)(RF1Tx3RF2Tx1TxGainValue >> 16);
                    if (num22 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num22 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num22 / 10.0);
                    }
                    ushort num23 = (ushort)(RF2Tx2RF2Tx3TxGainValue & 65535U);
                    if (num23 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num23 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num23 / 10.0);
                    }
                    ushort num24 = (ushort)(RF2Tx2RF2Tx3TxGainValue >> 16);
                    if (num24 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num24 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num24 / 10.0);
                    }
                    ushort num25 = (ushort)(RF3Tx1RF3Tx2TxGainValue & 65535U);
                    if (num25 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num25 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num25 / 10.0);
                    }
                    ushort num26 = (ushort)(RF3Tx1RF3Tx2TxGainValue >> 16);
                    if (num26 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num26 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num26 / 10.0);
                    }
                    ushort num27 = (ushort)(RF3Tx3GainRF1Tx1PhaseValue & 65535U);
                    if (num27 > 32767)
                    {
                        Convert.ToString((double)((short)((int)num27 - 65536)) / 10.0);
                    }
                    else
                    {
                        Convert.ToString((double)num27 / 10.0);
                    }
                    ushort num28 = (ushort)(RF3Tx3GainRF1Tx1PhaseValue >> 16);
                    if (num28 > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)num28 - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(num28 * 360) / 65536.0, 2));
                    }
                    ushort num29 = (ushort)(RF1Tx2Tx3TxPhaseValue & 65535U);
                    if (num29 > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)num29 - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(num29 * 360) / 65536.0, 2));
                    }
                    ushort num30 = (ushort)(RF1Tx2Tx3TxPhaseValue >> 16);
                    if (num30 > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)num30 - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(num30 * 360) / 65536.0, 2));
                    }
                    ushort num31 = (ushort)(RF2Tx1RF2Tx2TxPhaseValue & 65535U);
                    if (num31 > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)num31 - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(num31 * 360) / 65536.0, 2));
                    }
                    ushort num32 = (ushort)(RF2Tx1RF2Tx2TxPhaseValue >> 16);
                    if (num32 > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)num32 - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(num32 * 360) / 65536.0, 2));
                    }
                    ushort num33 = (ushort)(RF2Tx3RF3Tx1TxPhaseValue & 65535U);
                    if (num33 > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)num33 - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(num33 * 360) / 65536.0, 2));
                    }
                    ushort num34 = (ushort)(RF2Tx3RF3Tx1TxPhaseValue >> 16);
                    if (num34 > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)num34 - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(num34 * 360) / 65536.0, 2));
                    }
                    ushort num35 = (ushort)(RF3Tx2RF3Tx3TxPhaseValue & 65535U);
                    if (num35 > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)num35 - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(num35 * 360) / 65536.0, 2));
                    }
                    ushort num36 = (ushort)(RF3Tx2RF3Tx3TxPhaseValue >> 16);
                    if (num36 > 32767)
                    {
                        Convert.ToString(Math.Round((double)((ushort)((int)num36 - 65536) * 360) / 65536.0, 2));
                    }
                    else
                    {
                        Convert.ToString(Math.Round((double)(num36 * 360) / 65536.0, 2));
                    }
                    Convert.ToString(TimeStamp);
                }
            }
            return true;
        }

        private int iSetAnalogFaultInjectionConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetAnalogFaultInjectionConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetAnalogFaultInjectionConfig()
        {
            this.iSetAnalogFaultInjectionConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetAnalogFaultInjectionConfigAsync()
        {
            new del_v_v(this.iSetAnalogFaultInjectionConfig).BeginInvoke(null, null);
        }

        private void m_btnAnalogFaultInjectionConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetAnalogFaultInjectionConfigAsync();
        }

        public bool UpdateAnalogFaultInjectionConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateAnalogFaultInjectionConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_AnalogFaultInjectionConfigParameters.RxGainDropRx1 = (byte)(this.m_chbRxGainDropRx1.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxGainDropRx2 = (byte)(this.m_chbRxGainDropRx2.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxGainDropRx3 = (byte)(this.m_chbRxGainDropRx3.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxGainDropRx4 = (byte)(this.m_chbRxGainDropRx4.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxPhaseInvRx1 = (byte)(this.m_chbRxPhaseInvRx1.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxPhaseInvRx2 = (byte)(this.m_chbRxPhaseInvRx2.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxPhaseInvRx3 = (byte)(this.m_chbRxPhaseInvRx3.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxPhaseInvRx4 = (byte)(this.m_chbRxPhaseInvRx4.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxHighNoiseRx1 = (byte)(this.m_chbRxHighNoiseRx1.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxHighNoiseRx2 = (byte)(this.m_chbRxHighNoiseRx2.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxHighNoiseRx3 = (byte)(this.m_chbRxHighNoiseRx3.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxHighNoiseRx4 = (byte)(this.m_chbRxHighNoiseRx4.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxIFStageRx1 = (byte)(this.m_chbRxIFStageRx1.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxIFStageRx2 = (byte)(this.m_chbRxIFStageRx2.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxIFStageRx3 = (byte)(this.m_chbRxIFStageRx3.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxIFStageRx4 = (byte)(this.m_chbRxIFStageRx4.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxLOAmpRx1Rx2 = (byte)(this.m_chbRxLOAmpRx0Rx1.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.RxLOAmpRx3Rx4 = (byte)(this.m_chbRxLOAmpRx2Rx3.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.TxLOAmpTx1Tx2 = (byte)(this.m_chbTxLOAmpTx0Tx1.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.TxLOAmpTx3 = (byte)(this.m_chbTxLOAmpTx2.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.TxGainDropTx1 = (byte)(this.m_chbTxGainDropTx1.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.TxGainDropTx2 = (byte)(this.m_chbTxGainDropTx2.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.TxGainDropTx3 = (byte)(this.m_chbTxGainDropTx3.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.TxPhaseInvTxFault = (byte)(this.m_chbTxGainInvTxFault.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.TxPhaseInvBPMTx1Fault = (byte)(this.m_chbTxGainInvTx1BPMVal.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.TxPhaseInvBPMTx2Fault = (byte)(this.m_chbTxGainInvTx2BPMVal.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.TxPhaseInvBPMTx3Fault = (byte)(this.m_chbTxGainInvTx3BPMVal.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.SynthVCOOpenFault = (byte)(this.m_chbSynthVCOOpenLoop.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.SynthFreqMonOffset = (byte)(this.m_chbSynthFreqMonOffset.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.f000319 = (byte)(this.f000116.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.f00031a = (byte)(this.f000117.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.f00031b = (byte)(this.f000118.Checked ? 1 : 0);
                this.m_AnalogFaultInjectionConfigParameters.Reserved2 = 0;
                this.m_AnalogFaultInjectionConfigParameters.Reserved3 = 0;
                this.m_AnalogFaultInjectionConfigParameters.Reserved4 = 0U;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateAnalogFaultInjectionConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateAnalogFaultInjectionConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_chbRxGainDropRx1.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxGainDropRx1 == 1);
                this.m_chbRxGainDropRx2.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxGainDropRx2 == 1);
                this.m_chbRxGainDropRx3.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxGainDropRx3 == 1);
                this.m_chbRxGainDropRx4.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxGainDropRx4 == 1);
                this.m_chbRxPhaseInvRx1.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxPhaseInvRx1 == 1);
                this.m_chbRxPhaseInvRx2.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxPhaseInvRx2 == 1);
                this.m_chbRxPhaseInvRx3.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxPhaseInvRx3 == 1);
                this.m_chbRxPhaseInvRx4.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxPhaseInvRx4 == 1);
                this.m_chbRxHighNoiseRx1.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxHighNoiseRx1 == 1);
                this.m_chbRxHighNoiseRx2.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxHighNoiseRx2 == 1);
                this.m_chbRxHighNoiseRx3.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxHighNoiseRx3 == 1);
                this.m_chbRxHighNoiseRx4.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxHighNoiseRx4 == 1);
                this.m_chbRxIFStageRx1.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxIFStageRx1 == 1);
                this.m_chbRxIFStageRx2.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxIFStageRx2 == 1);
                this.m_chbRxIFStageRx3.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxIFStageRx3 == 1);
                this.m_chbRxIFStageRx4.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxIFStageRx4 == 1);
                this.m_chbRxLOAmpRx0Rx1.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxLOAmpRx1Rx2 == 1);
                this.m_chbRxLOAmpRx2Rx3.Checked = (this.m_AnalogFaultInjectionConfigParameters.RxLOAmpRx3Rx4 == 1);
                this.m_chbTxLOAmpTx0Tx1.Checked = (this.m_AnalogFaultInjectionConfigParameters.TxLOAmpTx1Tx2 == 1);
                this.m_chbTxLOAmpTx2.Checked = (this.m_AnalogFaultInjectionConfigParameters.TxLOAmpTx3 == 1);
                this.m_chbTxGainDropTx1.Checked = (this.m_AnalogFaultInjectionConfigParameters.TxGainDropTx1 == 1);
                this.m_chbTxGainDropTx2.Checked = (this.m_AnalogFaultInjectionConfigParameters.TxGainDropTx2 == 1);
                this.m_chbTxGainDropTx3.Checked = (this.m_AnalogFaultInjectionConfigParameters.TxGainDropTx3 == 1);
                this.m_chbTxGainInvTxFault.Checked = (this.m_AnalogFaultInjectionConfigParameters.TxPhaseInvTxFault == 1);
                this.m_chbTxGainInvTx1BPMVal.Checked = (this.m_AnalogFaultInjectionConfigParameters.TxPhaseInvBPMTx1Fault == 1);
                this.m_chbTxGainInvTx2BPMVal.Checked = (this.m_AnalogFaultInjectionConfigParameters.TxPhaseInvBPMTx2Fault == 1);
                this.m_chbTxGainInvTx3BPMVal.Checked = (this.m_AnalogFaultInjectionConfigParameters.TxPhaseInvBPMTx3Fault == 1);
                this.m_chbSynthVCOOpenLoop.Checked = (this.m_AnalogFaultInjectionConfigParameters.SynthVCOOpenFault == 1);
                this.m_chbSynthFreqMonOffset.Checked = (this.m_AnalogFaultInjectionConfigParameters.SynthFreqMonOffset == 1);
                this.f000116.Checked = (this.m_AnalogFaultInjectionConfigParameters.f000319 == 1);
                this.f000117.Checked = (this.m_AnalogFaultInjectionConfigParameters.f00031a == 1);
                this.f000118.Checked = (this.m_AnalogFaultInjectionConfigParameters.f00031b == 1);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public void enableTx0BPMRx0Channel()
        {
            this.enableTx0BPMRx0Channel_Rec(true, this.f00011a);
        }

        public void enableTx0BPMRx0Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx0BPMRx0Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011a.Checked = true;
                return;
            }
            this.f00011a.Checked = false;
        }

        public void disableTx0BPMRx0Channel()
        {
            this.disableTx0BPMRx0Channel_Rec(true, this.f00011a);
        }

        public void disableTx0BPMRx0Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx0BPMRx0Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011a.Checked = false;
                return;
            }
            this.f00011a.Checked = true;
        }

        public void enableTx0BPMRx1Channel()
        {
            this.enableTx0BPMRx1Channel_Rec(true, this.f000119);
        }

        public void enableTx0BPMRx1Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx0BPMRx1Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000119.Checked = true;
                return;
            }
            this.f000119.Checked = false;
        }

        public void disableTx0BPMRx1Channel()
        {
            this.disableTx0BPMRx1Channel_Rec(true, this.f000119);
        }

        public void disableTx0BPMRx1Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx0BPMRx1Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000119.Checked = false;
                return;
            }
            this.f000119.Checked = true;
        }

        public void enableTx0BPMRx2Channel()
        {
            this.enableTx0BPMRx2Channel_Rec(true, this.f000120);
        }

        public void enableTx0BPMRx2Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx0BPMRx2Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000120.Checked = true;
                return;
            }
            this.f000120.Checked = false;
        }

        public void disableTx0BPMRx2Channel()
        {
            this.disableTx0BPMRx2Channel_Rec(true, this.f000120);
        }

        public void disableTx0BPMRx2Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx0BPMRx2Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000120.Checked = false;
                return;
            }
            this.f000120.Checked = true;
        }

        public void enableTx0BPMRx3Channel()
        {
            this.enableTx0BPMRx3Channel_Rec(true, this.f00011c);
        }

        public void enableTx0BPMRx3Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx0BPMRx3Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011c.Checked = true;
                return;
            }
            this.f00011c.Checked = false;
        }

        public void disableTx0BPMRx3Channel()
        {
            this.disableTx0BPMRx3Channel_Rec(true, this.f00011c);
        }

        public void disableTx0BPMRx3Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx0BPMRx3Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011c.Checked = false;
                return;
            }
            this.f00011c.Checked = true;
        }

        public void enableTx1BPMRx0Channel()
        {
            this.enableTx1BPMRx0Channel_Rec(true, this.f00011e);
        }

        public void enableTx1BPMRx0Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx1BPMRx0Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011e.Checked = true;
                return;
            }
            this.f00011e.Checked = false;
        }

        public void disableTx1BPMRx0Channel()
        {
            this.disableTx1BPMRx0Channel_Rec(true, this.f00011e);
        }

        public void disableTx1BPMRx0Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx1BPMRx0Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011e.Checked = false;
                return;
            }
            this.f00011e.Checked = true;
        }

        public void enableTx1BPMRx1Channel()
        {
            this.enableTx1BPMRx1Channel_Rec(true, this.f00011d);
        }

        public void enableTx1BPMRx1Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx1BPMRx1Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011d.Checked = true;
                return;
            }
            this.f00011d.Checked = false;
        }

        public void disableTx1BPMRx1Channel()
        {
            this.disableTx1BPMRx1Channel_Rec(true, this.f00011d);
        }

        public void disableTx1BPMRx1Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx1BPMRx1Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011d.Checked = false;
                return;
            }
            this.f00011d.Checked = true;
        }

        public void enableTx1BPMRx2Channel()
        {
            this.enableTx1BPMRx2Channel_Rec(true, this.f00011f);
        }

        public void enableTx1BPMRx2Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx1BPMRx2Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011f.Checked = true;
                return;
            }
            this.f00011f.Checked = false;
        }

        public void disableTx1BPMRx2Channel()
        {
            this.disableTx1BPMRx2Channel_Rec(true, this.f00011f);
        }

        public void disableTx1BPMRx2Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx1BPMRx2Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011f.Checked = false;
                return;
            }
            this.f00011f.Checked = true;
        }

        public void enableTx1BPMRx3Channel()
        {
            this.enableTx1BPMRx3Channel_Rec(true, this.f00011b);
        }

        public void enableTx1BPMRx3Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx1BPMRx3Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011b.Checked = true;
                return;
            }
            this.f00011b.Checked = false;
        }

        public void disableTx1BPMRx3Channel()
        {
            this.disableTx1BPMRx3Channel_Rec(true, this.f00011b);
        }

        public void disableTx1BPMRx3Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx1BPMRx3Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00011b.Checked = false;
                return;
            }
            this.f00011b.Checked = true;
        }

        public void enableTx2BPMRx0Channel()
        {
            this.enableTx2BPMRx0Channel_Rec(true, this.f000123);
        }

        public void enableTx2BPMRx0Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx2BPMRx0Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000123.Checked = true;
                return;
            }
            this.f000123.Checked = false;
        }

        public void disableTx2BPMRx0Channel()
        {
            this.disableTx2BPMRx0Channel_Rec(true, this.f000123);
        }

        public void disableTx2BPMRx0Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx2BPMRx0Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000123.Checked = false;
                return;
            }
            this.f000123.Checked = true;
        }

        public void enableTx2BPMRx1Channel()
        {
            this.enableTx2BPMRx1Channel_Rec(true, this.f000122);
        }

        public void enableTx2BPMRx1Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx2BPMRx1Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000122.Checked = true;
                return;
            }
            this.f000122.Checked = false;
        }

        public void disableTx2BPMRx1Channel()
        {
            this.disableTx2BPMRx1Channel_Rec(true, this.f000122);
        }

        public void disableTx2BPMRx1Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx2BPMRx1Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000122.Checked = false;
                return;
            }
            this.f000122.Checked = true;
        }

        public void enableTx2BPMRx2Channel()
        {
            this.enableTx2BPMRx2Channel_Rec(true, this.f000124);
        }

        public void enableTx2BPMRx2Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx2BPMRx2Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000124.Checked = true;
                return;
            }
            this.f000124.Checked = false;
        }

        public void disableTx2BPMRx2Channel()
        {
            this.disableTx2BPMRx2Channel_Rec(true, this.f000124);
        }

        public void disableTx2BPMRx2Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx2BPMRx2Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000124.Checked = false;
                return;
            }
            this.f000124.Checked = true;
        }

        public void enableTx2BPMRx3Channel()
        {
            this.enableTx2BPMRx3Channel_Rec(true, this.f000121);
        }

        public void enableTx2BPMRx3Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx2BPMRx3Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000121.Checked = true;
                return;
            }
            this.f000121.Checked = false;
        }

        public void disableTx2BPMRx3Channel()
        {
            this.disableTx2BPMRx3Channel_Rec(true, this.f000121);
        }

        public void disableTx2BPMRx3Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx2BPMRx3Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f000121.Checked = false;
                return;
            }
            this.f000121.Checked = true;
        }

        public void enableTx0GainPhaseChannel()
        {
            this.enableTx0GainPhaseChannel_Rec(true, this.m_chbTXGainPhaseMismatchMonTx1);
        }

        public void enableTx0GainPhaseChannel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx0GainPhaseChannel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonTx1.Checked = true;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonTx1.Checked = false;
        }

        public void disableTx0GainPhaseChannel()
        {
            this.disableTx0GainPhaseChannel_Rec(true, this.m_chbTXGainPhaseMismatchMonTx1);
        }

        public void disableTx0GainPhaseChannel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx0GainPhaseChannel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonTx1.Checked = false;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonTx1.Checked = true;
        }

        public void enableTx1GainPhaseChannel()
        {
            this.enableTx1GainPhaseChannel_Rec(true, this.m_chbTXGainPhaseMismatchMonTx2);
        }

        public void enableTx1GainPhaseChannel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx1GainPhaseChannel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonTx2.Checked = true;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonTx2.Checked = false;
        }

        public void disableTx1GainPhaseChannel()
        {
            this.disableTx1GainPhaseChannel_Rec(true, this.m_chbTXGainPhaseMismatchMonTx2);
        }

        public void disableTx1GainPhaseChannel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx1GainPhaseChannel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonTx2.Checked = false;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonTx2.Checked = true;
        }

        public void enableTx2GainPhaseChannel()
        {
            this.enableTx2GainPhaseChannel_Rec(true, this.m_chbTXGainPhaseMismatchMonTx3);
        }

        public void enableTx2GainPhaseChannel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTx2GainPhaseChannel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonTx3.Checked = true;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonTx3.Checked = false;
        }

        public void disableTx2GainPhaseChannel()
        {
            this.disableTx2GainPhaseChannel_Rec(true, this.m_chbTXGainPhaseMismatchMonTx3);
        }

        public void disableTx2GainPhaseChannel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTx2GainPhaseChannel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonTx3.Checked = false;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonTx3.Checked = true;
        }

        public void enableTxGainPhaseRx0Channel()
        {
            this.enableTxGainPhaseRx0Channel_Rec(true, this.m_chbTXGainPhaseMismatchMonRx0);
        }

        public void enableTxGainPhaseRx0Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTxGainPhaseRx0Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonRx0.Checked = true;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonRx0.Checked = false;
        }

        public void disableTxGainPhaseRx0Channel()
        {
            this.disableTxGainPhaseRx0Channel_Rec(true, this.m_chbTXGainPhaseMismatchMonRx0);
        }

        public void disableTxGainPhaseRx0Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTxGainPhaseRx0Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonRx0.Checked = false;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonRx0.Checked = true;
        }

        public void enableTxGainPhaseRx1Channel()
        {
            this.enableTxGainPhaseRx1Channel_Rec(true, this.m_chbTXGainPhaseMismatchMonRx1);
        }

        public void enableTxGainPhaseRx1Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTxGainPhaseRx1Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonRx1.Checked = true;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonRx1.Checked = false;
        }

        public void disableTxGainPhaseRx1Channel()
        {
            this.disableTxGainPhaseRx1Channel_Rec(true, this.m_chbTXGainPhaseMismatchMonRx1);
        }

        public void disableTxGainPhaseRx1Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTxGainPhaseRx1Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonRx1.Checked = false;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonRx1.Checked = true;
        }

        public void enableTxGainPhaseRx2Channel()
        {
            this.enableTxGainPhaseRx2Channel_Rec(true, this.m_chbTXGainPhaseMismatchMonRx2);
        }

        public void enableTxGainPhaseRx2Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTxGainPhaseRx2Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonRx2.Checked = true;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonRx2.Checked = false;
        }

        public void disableTxGainPhaseRx2Channel()
        {
            this.disableTxGainPhaseRx2Channel_Rec(true, this.m_chbTXGainPhaseMismatchMonRx2);
        }

        public void disableTxGainPhaseRx2Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTxGainPhaseRx2Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonRx2.Checked = false;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonRx2.Checked = true;
        }

        public void enableTxGainPhaseRx3Channel()
        {
            this.enableTxGainPhaseRx3Channel_Rec(true, this.m_chbTXGainPhaseMismatchMonRx3);
        }

        public void enableTxGainPhaseRx3Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.enableTxGainPhaseRx3Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonRx3.Checked = true;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonRx3.Checked = false;
        }

        public void disableTxGainPhaseRx3Channel()
        {
            this.disableTxGainPhaseRx3Channel_Rec(true, this.m_chbTXGainPhaseMismatchMonRx3);
        }

        public void disableTxGainPhaseRx3Channel_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableTxGainPhaseRx3Channel_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.m_chbTXGainPhaseMismatchMonRx3.Checked = false;
                return;
            }
            this.m_chbTXGainPhaseMismatchMonRx3.Checked = true;
        }

        public bool SaveAnalogMonEnableConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveAnalogMonEnableConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("temperatureMonEna", (this.m_chbTemperatureMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("rxGainPhaseMonEna", (this.m_chbRXGainPhaseMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("rxNoiseMonEna", (this.m_chbRXNoiseMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("rxIFStageMonEna", (this.f000115.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("tx0PowerMonEna", (this.m_chbTX1PowerMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("tx1PowerMonEna", (this.m_chbTX2PowerMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("tx2PowerMonEna", (this.m_chbTX3PowerMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("tx0BallBreakMonEna", (this.m_chbTX1BallBreakMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("tx1BallBreakMonEna", (this.m_chbTX2BallBreakMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("tx2BallBreakMonEna", (this.m_chbTX3BallBreakMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("txGainPhaseMonEna", (this.m_chbTXGainPhaseMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("tx0BPMMonEna", (this.f000114.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("tx1BPMMonEna", (this.f000113.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("tx2BPMMonEna", (this.f000112.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("synthFreqMonEna", (this.m_chbSynthFreqMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("externalAnalogSignalsMonEna", (this.m_chbExternalAnalogSignalsMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("internalTX0SignalsMonEna", (this.m_chbInternalTX1SignalsMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("internalTX1SignalsMonEna", (this.m_chbInternalTX2SignalsMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("internalTX2SignalsMonEna", (this.m_chbInternalTX3SignalsMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("internalRXSignalsMonEna", (this.m_chbInternalRXSignalsMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("internalPMCLKLOSignalsMonEna", (this.f000111.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("internalGPADCSignalsMonEna", (this.f000110.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("pllControlVolMonEna", (this.m_chbPLLControlVolMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("dccClockFreqMonEna", (this.m_chbDCCClockFreqMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("rxIFASaturationMonEna", (this.f00010f.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("rxSigImgBandMonEna", (this.m_chbRXSigImgBandMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("rxMixerInputPowerMonEna", (this.m_chbRXMixerInputPowerMonEna.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogMonEnableConfigKeyVal("reservedMonEna", (this.m_chbReservedMonEna.Checked ? 1 : 0).ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadAnalogMonEnableConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadAnalogMonEnableConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte temperatureMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("temperatureMonEna"));
                byte rxGainPhaseMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("rxGainPhaseMonEna"));
                byte rxNoiseMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("rxNoiseMonEna"));
                byte rxIFStageMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("rxIFStageMonEna"));
                byte tx0PowerMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("tx0PowerMonEna"));
                byte tx1PowerMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("tx1PowerMonEna"));
                byte tx2PowerMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("tx2PowerMonEna"));
                byte tx0BallBreakMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("tx0BallBreakMonEna"));
                byte tx1BallBreakMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("tx1BallBreakMonEna"));
                byte tx2BallBreakMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("tx2BallBreakMonEna"));
                byte txGainPhaseMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("txGainPhaseMonEna"));
                byte tx0BPMMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("tx0BPMMonEna"));
                byte tx1BPMMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("tx1BPMMonEna"));
                byte tx2BPMMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("tx2BPMMonEna"));
                byte synthFreqMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("synthFreqMonEna"));
                byte externalAnalogSignalsMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("externalAnalogSignalsMonEna"));
                byte internalTX0SignalsMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("internalTX0SignalsMonEna"));
                byte internalTX1SignalsMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("internalTX1SignalsMonEna"));
                byte internalTX2SignalsMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("internalTX2SignalsMonEna"));
                byte internalRXSignalsMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("internalRXSignalsMonEna"));
                byte p = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("internalPMCLKLOSignalsMonEna"));
                byte internalGPADCSignalsMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("internalGPADCSignalsMonEna"));
                byte pllControlVolMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("pllControlVolMonEna"));
                byte dccClockFreqMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("dccClockFreqMonEna"));
                byte rxIFASaturationMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("rxIFASaturationMonEna"));
                byte rxSigImgBandMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("rxSigImgBandMonEna"));
                byte rxMixerInputPowerMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("rxMixerInputPowerMonEna"));
                byte reservedMonEna = Convert.ToByte(ConfigurationManager.GetAnalogMonEnableConfigKeyVal("reservedMonEna"));
                this.m_GuiManager.ScriptOps.UpdateAnalogMonEnableConfigData(temperatureMonEna, rxGainPhaseMonEna, rxNoiseMonEna, rxIFStageMonEna, tx0PowerMonEna, tx1PowerMonEna, tx2PowerMonEna, tx0BallBreakMonEna, tx1BallBreakMonEna, tx2BallBreakMonEna, txGainPhaseMonEna, tx0BPMMonEna, tx1BPMMonEna, tx2BPMMonEna, synthFreqMonEna, externalAnalogSignalsMonEna, internalTX0SignalsMonEna, internalTX1SignalsMonEna, internalTX2SignalsMonEna, internalRXSignalsMonEna, p, internalGPADCSignalsMonEna, pllControlVolMonEna, dccClockFreqMonEna, rxIFASaturationMonEna, rxSigImgBandMonEna, rxMixerInputPowerMonEna, reservedMonEna);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveTx0BallBreakConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveTx0BallBreakConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetTx0BallBreakConfigKeyVal("tx0BallBreakMonReportingMode", this.m_nudTX1BallBreakMonReportingMode.Value.ToString());
                ConfigurationManager.SetTx0BallBreakConfigKeyVal("tx0ReflCoeffMagThreshold", this.m_nudTX1ReflCoeffMagThreshold.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadTx0BallBreakConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadTx0BallBreakConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte tx0BallBreakMonReportingMode = Convert.ToByte(ConfigurationManager.GetTx0BallBreakConfigKeyVal("tx0BallBreakMonReportingMode"));
                double tx0ReflCoeffMagThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx0BallBreakConfigKeyVal("tx0ReflCoeffMagThreshold"));
                this.m_GuiManager.ScriptOps.UpdateTx0BallBreakConfigData(tx0BallBreakMonReportingMode, tx0ReflCoeffMagThreshold);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveTx1BallBreakConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveTx1BallBreakConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetTx1BallBreakConfigKeyVal("tx1BallBreakMonReportingMode", this.m_nudTX2BallBreakMonReportingMode.Value.ToString());
                ConfigurationManager.SetTx1BallBreakConfigKeyVal("tx1ReflCoeffMagThreshold", this.m_nudTX2ReflCoeffMagThreshold.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadTx1BallBreakConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadTx1BallBreakConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte tx1BallBreakMonReportingMode = Convert.ToByte(ConfigurationManager.GetTx1BallBreakConfigKeyVal("tx1BallBreakMonReportingMode"));
                double tx1ReflCoeffMagThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx1BallBreakConfigKeyVal("tx1ReflCoeffMagThreshold"));
                this.m_GuiManager.ScriptOps.UpdateTx1BallBreakConfigData(tx1BallBreakMonReportingMode, tx1ReflCoeffMagThreshold);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveTx2BallBreakConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveTx2BallBreakConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetTx2BallBreakConfigKeyVal("tx2BallBreakMonReportingMode", this.m_nudTX3BallBreakMonReportingMode.Value.ToString());
                ConfigurationManager.SetTx2BallBreakConfigKeyVal("tx2ReflCoeffMagThreshold", this.m_nudTX3ReflCoeffMagThreshold.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadTx2BallBreakConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadTx2BallBreakConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte tx2BallBreakMonReportingMode = Convert.ToByte(ConfigurationManager.GetTx2BallBreakConfigKeyVal("tx2BallBreakMonReportingMode"));
                double tx2ReflCoeffMagThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx2BallBreakConfigKeyVal("tx2ReflCoeffMagThreshold"));
                this.m_GuiManager.ScriptOps.UpdateTx2BallBreakConfigData(tx2BallBreakMonReportingMode, tx2ReflCoeffMagThreshold);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveTx0PowerMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveTx0PowerMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetTx0PowerMonConfigKeyVal("tx0PwrMonProfileIndex", this.m_nudTXPwrMonProfileIndex.Value.ToString());
                ConfigurationManager.SetTx0PowerMonConfigKeyVal("tx0PowerRF1", (this.f000105.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx0PowerMonConfigKeyVal("tx0PowerRF2", (this.f000104.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx0PowerMonConfigKeyVal("tx0PowerRF3", (this.f000103.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx0PowerMonConfigKeyVal("tx0PowerReportingMode", this.m_nudTX1PowerReportingMode.Value.ToString());
                ConfigurationManager.SetTx0PowerMonConfigKeyVal("tx0PwAbsErrThreshold", this.m_nudTXPwAbsErrThreshold.Value.ToString());
                ConfigurationManager.SetTx0PowerMonConfigKeyVal("tx0PwFlatnessThreshold", this.m_nudTXPwFlatnessThreshold.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadTx0PowerMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadTx0PowerMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte tx0PwrMonProfileIndex = Convert.ToByte(ConfigurationManager.GetTx0PowerMonConfigKeyVal("tx0PwrMonProfileIndex"));
                byte tx0PowerRF = Convert.ToByte(ConfigurationManager.GetTx0PowerMonConfigKeyVal("tx0PowerRF1"));
                byte tx0PowerRF2 = Convert.ToByte(ConfigurationManager.GetTx0PowerMonConfigKeyVal("tx0PowerRF2"));
                byte tx0PowerRF3 = Convert.ToByte(ConfigurationManager.GetTx0PowerMonConfigKeyVal("tx0PowerRF3"));
                byte tx0PowerReportingMode = Convert.ToByte(ConfigurationManager.GetTx0PowerMonConfigKeyVal("tx0PowerReportingMode"));
                double tx0PwAbsErrThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx0PowerMonConfigKeyVal("tx0PwAbsErrThreshold"));
                double tx0PwFlatnessThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx0PowerMonConfigKeyVal("tx0PwFlatnessThreshold"));
                this.m_GuiManager.ScriptOps.UpdateTx0PowerMonConfigData(tx0PwrMonProfileIndex, tx0PowerRF, tx0PowerRF2, tx0PowerRF3, tx0PowerReportingMode, tx0PwAbsErrThreshold, tx0PwFlatnessThreshold);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveTx1PowerMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveTx1PowerMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetTx1PowerMonConfigKeyVal("tx1PwrMonProfileIndex", this.m_nudTX2PwrMonProfileIndex.Value.ToString());
                ConfigurationManager.SetTx1PowerMonConfigKeyVal("tx1PowerRF1", (this.f00010b.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx1PowerMonConfigKeyVal("tx1PowerRF2", (this.f00010a.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx1PowerMonConfigKeyVal("tx1PowerRF3", (this.f000109.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx1PowerMonConfigKeyVal("tx1PowerReportingMode", this.m_nudTX2PowerReportingMode.Value.ToString());
                ConfigurationManager.SetTx1PowerMonConfigKeyVal("tx1PwAbsErrThreshold", this.m_nudTX2PwAbsErrThreshold.Value.ToString());
                ConfigurationManager.SetTx1PowerMonConfigKeyVal("tx1PwFlatnessThreshold", this.m_nudTX2PwFlatnessThreshold.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadTx1PowerMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadTx1PowerMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte tx1PwrMonProfileIndex = Convert.ToByte(ConfigurationManager.GetTx1PowerMonConfigKeyVal("tx1PwrMonProfileIndex"));
                byte tx1PowerRF = Convert.ToByte(ConfigurationManager.GetTx1PowerMonConfigKeyVal("tx1PowerRF1"));
                byte tx1PowerRF2 = Convert.ToByte(ConfigurationManager.GetTx1PowerMonConfigKeyVal("tx1PowerRF2"));
                byte tx1PowerRF3 = Convert.ToByte(ConfigurationManager.GetTx1PowerMonConfigKeyVal("tx1PowerRF3"));
                byte tx1PowerReportingMode = Convert.ToByte(ConfigurationManager.GetTx1PowerMonConfigKeyVal("tx1PowerReportingMode"));
                double tx1PwAbsErrThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx1PowerMonConfigKeyVal("tx1PwAbsErrThreshold"));
                double tx1PwFlatnessThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx1PowerMonConfigKeyVal("tx1PwFlatnessThreshold"));
                this.m_GuiManager.ScriptOps.UpdateTx1PowerMonConfigData(tx1PwrMonProfileIndex, tx1PowerRF, tx1PowerRF2, tx1PowerRF3, tx1PowerReportingMode, tx1PwAbsErrThreshold, tx1PwFlatnessThreshold);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveTx2PowerMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveTx2PowerMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetTx2PowerMonConfigKeyVal("tx2PwrMonProfileIndex", this.m_nudTX3PwrMonProfileIndex.Value.ToString());
                ConfigurationManager.SetTx2PowerMonConfigKeyVal("tx2PowerRF1", (this.f000108.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx2PowerMonConfigKeyVal("tx2PowerRF2", (this.f000107.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx2PowerMonConfigKeyVal("tx2PowerRF3", (this.f000106.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx2PowerMonConfigKeyVal("tx2PowerReportingMode", this.m_nudTX3PowerReportingMode.Value.ToString());
                ConfigurationManager.SetTx2PowerMonConfigKeyVal("tx2PwAbsErrThreshold", this.m_nudTX3PwAbsErrThreshold.Value.ToString());
                ConfigurationManager.SetTx2PowerMonConfigKeyVal("tx2PwFlatnessThreshold", this.m_nudTX3PwFlatnessThreshold.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadTx2PowerMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadTx2PowerMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte tx2PwrMonProfileIndex = Convert.ToByte(ConfigurationManager.GetTx2PowerMonConfigKeyVal("tx2PwrMonProfileIndex"));
                byte tx2PowerRF = Convert.ToByte(ConfigurationManager.GetTx2PowerMonConfigKeyVal("tx2PowerRF1"));
                byte tx2PowerRF2 = Convert.ToByte(ConfigurationManager.GetTx2PowerMonConfigKeyVal("tx2PowerRF2"));
                byte tx2PowerRF3 = Convert.ToByte(ConfigurationManager.GetTx2PowerMonConfigKeyVal("tx2PowerRF3"));
                byte tx2PowerReportingMode = Convert.ToByte(ConfigurationManager.GetTx2PowerMonConfigKeyVal("tx2PowerReportingMode"));
                double tx2PwAbsErrThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx2PowerMonConfigKeyVal("tx2PwAbsErrThreshold"));
                double tx2PwFlatnessThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx2PowerMonConfigKeyVal("tx2PwFlatnessThreshold"));
                this.m_GuiManager.ScriptOps.UpdateTx2PowerMonConfigData(tx2PwrMonProfileIndex, tx2PowerRF, tx2PowerRF2, tx2PowerRF3, tx2PowerReportingMode, tx2PwAbsErrThreshold, tx2PwFlatnessThreshold);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveTx0BPMMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveTx0BPMMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetTx0BPMMonConfigKeyVal("tx0BPMPhaseMonProfileIndex", this.m_nudTX1BPMPhaseMonProfileIndex.Value.ToString());
                ConfigurationManager.SetTx0BPMMonConfigKeyVal("tx0BPMPhaseMonReportMode", this.m_nudTX1BPMPhaseMonReportMode.Value.ToString());
                ConfigurationManager.SetTx0BPMMonConfigKeyVal("tx0BPMMonRx0", (this.f00011a.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx0BPMMonConfigKeyVal("tx0BPMMonRx1", (this.f000119.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx0BPMMonConfigKeyVal("tx0BPMMonRx2", (this.f000120.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx0BPMMonConfigKeyVal("tx0BPMMonRx3", (this.f00011c.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx0BPMMonConfigKeyVal("tx0BPMPhaseMonErrorThreshold", this.m_nudTX1BPMPhaseMonErrorThreshold.Value.ToString());
                ConfigurationManager.SetTx0BPMMonConfigKeyVal("tx0BPMAmplitudeMonErrorThreshold", this.m_nudTX1BPMAmplitudeMonErrorThreshold.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadTx0BPMMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadTx0BPMMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte tx0BPMPhaseMonProfileIndex = Convert.ToByte(ConfigurationManager.GetTx0BPMMonConfigKeyVal("tx0BPMPhaseMonProfileIndex"));
                byte tx0BPMPhaseMonReportMode = Convert.ToByte(ConfigurationManager.GetTx0BPMMonConfigKeyVal("tx0BPMPhaseMonReportMode"));
                byte tx0BPMMonRx = Convert.ToByte(ConfigurationManager.GetTx0BPMMonConfigKeyVal("tx0BPMMonRx0"));
                byte tx0BPMMonRx2 = Convert.ToByte(ConfigurationManager.GetTx0BPMMonConfigKeyVal("tx0BPMMonRx1"));
                byte tx0BPMMonRx3 = Convert.ToByte(ConfigurationManager.GetTx0BPMMonConfigKeyVal("tx0BPMMonRx2"));
                byte tx0BPMMonRx4 = Convert.ToByte(ConfigurationManager.GetTx0BPMMonConfigKeyVal("tx0BPMMonRx3"));
                double tx0BPMPhaseMonErrorThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx0BPMMonConfigKeyVal("tx0BPMPhaseMonErrorThreshold"));
                double tx0BPMAmplitudeMonErrorThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx0BPMMonConfigKeyVal("tx0BPMAmplitudeMonErrorThreshold"));
                this.m_GuiManager.ScriptOps.UpdateTx0BPMMonConfigData(tx0BPMPhaseMonProfileIndex, tx0BPMPhaseMonReportMode, tx0BPMMonRx, tx0BPMMonRx2, tx0BPMMonRx3, tx0BPMMonRx4, tx0BPMPhaseMonErrorThreshold, tx0BPMAmplitudeMonErrorThreshold);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveTx1BPMMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveTx1BPMMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetTx1BPMMonConfigKeyVal("tx1BPMPhaseMonProfileIndex", this.m_nudTX2BPMPhaseMonProfileIndex.Value.ToString());
                ConfigurationManager.SetTx1BPMMonConfigKeyVal("tx1BPMPhaseMonReportMode", this.m_nudTX2BPMPhaseMonReportMode.Value.ToString());
                ConfigurationManager.SetTx1BPMMonConfigKeyVal("tx1BPMMonRx0", (this.f00011e.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx1BPMMonConfigKeyVal("tx1BPMMonRx1", (this.f00011d.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx1BPMMonConfigKeyVal("tx1BPMMonRx2", (this.f00011f.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx1BPMMonConfigKeyVal("tx1BPMMonRx3", (this.f00011b.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx1BPMMonConfigKeyVal("tx1BPMPhaseMonErrorThreshold", this.m_nudTX2BPMPhaseMonErrorThreshold.Value.ToString());
                ConfigurationManager.SetTx1BPMMonConfigKeyVal("tx1BPMAmplitudeMonErrorThreshold", this.m_nudTX2BPMAmplitudeMonErrorThreshold.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadTx1BPMMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadTx1BPMMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte tx0BPMPhaseMonProfileIndex = Convert.ToByte(ConfigurationManager.GetTx1BPMMonConfigKeyVal("tx1BPMPhaseMonProfileIndex"));
                byte tx0BPMPhaseMonReportMode = Convert.ToByte(ConfigurationManager.GetTx1BPMMonConfigKeyVal("tx1BPMPhaseMonReportMode"));
                byte tx0BPMMonRx = Convert.ToByte(ConfigurationManager.GetTx1BPMMonConfigKeyVal("tx1BPMMonRx0"));
                byte tx0BPMMonRx2 = Convert.ToByte(ConfigurationManager.GetTx1BPMMonConfigKeyVal("tx1BPMMonRx1"));
                byte tx0BPMMonRx3 = Convert.ToByte(ConfigurationManager.GetTx1BPMMonConfigKeyVal("tx1BPMMonRx2"));
                byte tx0BPMMonRx4 = Convert.ToByte(ConfigurationManager.GetTx1BPMMonConfigKeyVal("tx1BPMMonRx3"));
                double tx0BPMPhaseMonErrorThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx1BPMMonConfigKeyVal("tx1BPMPhaseMonErrorThreshold"));
                double tx0BPMAmplitudeMonErrorThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx1BPMMonConfigKeyVal("tx1BPMAmplitudeMonErrorThreshold"));
                this.m_GuiManager.ScriptOps.UpdateTx1BPMMonConfigData(tx0BPMPhaseMonProfileIndex, tx0BPMPhaseMonReportMode, tx0BPMMonRx, tx0BPMMonRx2, tx0BPMMonRx3, tx0BPMMonRx4, tx0BPMPhaseMonErrorThreshold, tx0BPMAmplitudeMonErrorThreshold);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveTx2BPMMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveTx2BPMMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetTx2BPMMonConfigKeyVal("tx2BPMPhaseMonProfileIndex", this.m_nudTX3BPMPhaseMonProfileIndex.Value.ToString());
                ConfigurationManager.SetTx2BPMMonConfigKeyVal("tx2BPMPhaseMonReportMode", this.m_nudTX3BPMPhaseMonReportMode.Value.ToString());
                ConfigurationManager.SetTx2BPMMonConfigKeyVal("tx2BPMMonRx0", (this.f000123.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx2BPMMonConfigKeyVal("tx2BPMMonRx1", (this.f000122.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx2BPMMonConfigKeyVal("tx2BPMMonRx2", (this.f000124.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx2BPMMonConfigKeyVal("tx2BPMMonRx3", (this.f000121.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTx2BPMMonConfigKeyVal("tx2BPMPhaseMonErrorThreshold", this.m_nudTX3BPMPhaseMonErrorThreshold.Value.ToString());
                ConfigurationManager.SetTx2BPMMonConfigKeyVal("tx2BPMAmplitudeMonErrorThreshold", this.m_nudTX3BPMAmplitudeMonErrorThreshold.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadTx2BPMMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadTx2BPMMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte tx0BPMPhaseMonProfileIndex = Convert.ToByte(ConfigurationManager.GetTx2BPMMonConfigKeyVal("tx2BPMPhaseMonProfileIndex"));
                byte tx0BPMPhaseMonReportMode = Convert.ToByte(ConfigurationManager.GetTx2BPMMonConfigKeyVal("tx2BPMPhaseMonReportMode"));
                byte tx0BPMMonRx = Convert.ToByte(ConfigurationManager.GetTx2BPMMonConfigKeyVal("tx2BPMMonRx0"));
                byte tx0BPMMonRx2 = Convert.ToByte(ConfigurationManager.GetTx2BPMMonConfigKeyVal("tx2BPMMonRx1"));
                byte tx0BPMMonRx3 = Convert.ToByte(ConfigurationManager.GetTx2BPMMonConfigKeyVal("tx2BPMMonRx2"));
                byte tx0BPMMonRx4 = Convert.ToByte(ConfigurationManager.GetTx2BPMMonConfigKeyVal("tx2BPMMonRx3"));
                double tx0BPMPhaseMonErrorThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx2BPMMonConfigKeyVal("tx2BPMPhaseMonErrorThreshold"));
                double tx0BPMAmplitudeMonErrorThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTx2BPMMonConfigKeyVal("tx2BPMAmplitudeMonErrorThreshold"));
                this.m_GuiManager.ScriptOps.UpdateTx2BPMMonConfigData(tx0BPMPhaseMonProfileIndex, tx0BPMPhaseMonReportMode, tx0BPMMonRx, tx0BPMMonRx2, tx0BPMMonRx3, tx0BPMMonRx4, tx0BPMPhaseMonErrorThreshold, tx0BPMAmplitudeMonErrorThreshold);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveTxGainPhaseMismatchMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveTxGainPhaseMismatchMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismacthMonProfileIndex", this.m_nudTxGainPhaseMismacthMonProfileIndex.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismacthMonReportingMode", this.m_nudTxGainPhaseMismacthMonReportingMode.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf1TXGainPhaseMismatchMonBitMask", (this.m_chbRF1TXGainPhaseMismatchMonBitMask.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf2TXGainPhaseMismatchMonBitMask", (this.m_chbRF2TXGainPhaseMismatchMonBitMask.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf3TXGainPhaseMismatchMonBitMask", (this.m_chbRF3TXGainPhaseMismatchMonBitMask.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("tx0GainPhaseMismatchMon", (this.m_chbTXGainPhaseMismatchMonTx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("tx1GainPhaseMismatchMon", (this.m_chbTXGainPhaseMismatchMonTx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("tx2GainPhaseMismatchMon", (this.m_chbTXGainPhaseMismatchMonTx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismatchMonRx0", (this.m_chbTXGainPhaseMismatchMonRx0.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismatchMonRx1", (this.m_chbTXGainPhaseMismatchMonRx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismatchMonRx2", (this.m_chbTXGainPhaseMismatchMonRx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismatchMonRx3", (this.m_chbTXGainPhaseMismatchMonRx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismacthMonTxGainMismatchThreshold", this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismacthMonTxPhaseMismatchThreshold", this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf1TX0TXGainPhaseMismatchOffVal", this.m_nudRF1TX1TXGainPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf2TX0TXGainPhaseMismatchOffVal", this.m_nudRF2TX1TXGainPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf3TX0TXGainPhaseMismatchOffVal", this.m_nudRF3TX1TXGainPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf1TX1TXGainPhaseMismatchOffVal", this.m_nudRF1TX2TXGainPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf2TX1TXGainPhaseMismatchOffVal", this.m_nudRF2TX2TXGainPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf3TX1TXGainPhaseMismatchOffVal", this.m_nudRF3TX2TXGainPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf1TX2TXGainPhaseMismatchOffVal", this.m_nudRF1TX3TXGainPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf2TX2TXGainPhaseMismatchOffVal", this.m_nudRF2TX3TXGainPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf3TX2TXGainPhaseMismatchOffVal", this.m_nudRF3TX3TXGainPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf1TX0TXPhaseMismatchOffVal", this.m_nudRF1TX1TXPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf2TX0TXPhaseMismatchOffVal", this.m_nudRF2TX1TXPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf3TX0TXPhaseMismatchOffVal", this.m_nudRF3TX1TXPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf1TX1TXPhaseMismatchOffVal", this.m_nudRF1TX2TXPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf2TX1TXPhaseMismatchOffVal", this.m_nudRF2TX2TXPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf3TX1TXPhaseMismatchOffVal", this.m_nudRF3TX2TXPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf1TX2TXPhaseMismatchOffVal", this.m_nudRF1TX3TXPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf2TX2TXPhaseMismatchOffVal", this.m_nudRF2TX3TXPhaseMismatchOffVal.Value.ToString());
                ConfigurationManager.SetTxGainPhaseMismatchMonConfigKeyVal("rf3TX2TXPhaseMismatchOffVal", this.m_nudRF3TX3TXPhaseMismatchOffVal.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadTxGainPhaseMismatchMonConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadTxGainPhaseMismatchMonConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte txGainPhaseMismacthMonProfileIndex = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismacthMonProfileIndex"));
                byte txGainPhaseMismacthMonReportingMode = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismacthMonReportingMode"));
                byte rf1TXGainPhaseMismatchMonBitMask = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf1TXGainPhaseMismatchMonBitMask"));
                byte rf2TXGainPhaseMismatchMonBitMask = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf2TXGainPhaseMismatchMonBitMask"));
                byte rf3TXGainPhaseMismatchMonBitMask = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf3TXGainPhaseMismatchMonBitMask"));
                byte tx0GainPhaseMismatchMon = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("tx0GainPhaseMismatchMon"));
                byte tx1GainPhaseMismatchMon = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("tx1GainPhaseMismatchMon"));
                byte tx2GainPhaseMismatchMon = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("tx2GainPhaseMismatchMon"));
                byte txGainPhaseMismatchMonRx = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismatchMonRx0"));
                byte txGainPhaseMismatchMonRx2 = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismatchMonRx1"));
                byte txGainPhaseMismatchMonRx3 = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismatchMonRx2"));
                byte txGainPhaseMismatchMonRx4 = Convert.ToByte(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismatchMonRx3"));
                double txGainPhaseMismacthMonTxGainMismatchThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismacthMonTxGainMismatchThreshold"));
                double txGainPhaseMismacthMonTxPhaseMismatchThreshold = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("txGainPhaseMismacthMonTxPhaseMismatchThreshold"));
                double rf1TX0TXGainPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf1TX0TXGainPhaseMismatchOffVal"));
                double rf2TX0TXGainPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf2TX0TXGainPhaseMismatchOffVal"));
                double rf3TX0TXGainPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf3TX0TXGainPhaseMismatchOffVal"));
                double rf1TX1TXGainPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf1TX1TXGainPhaseMismatchOffVal"));
                double rf2TX1TXGainPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf2TX1TXGainPhaseMismatchOffVal"));
                double rf3TX1TXGainPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf3TX1TXGainPhaseMismatchOffVal"));
                double rf1TX2TXGainPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf1TX2TXGainPhaseMismatchOffVal"));
                double rf2TX2TXGainPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf2TX2TXGainPhaseMismatchOffVal"));
                double rf3TX2TXGainPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf3TX2TXGainPhaseMismatchOffVal"));
                double rf1TX0TXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf1TX0TXPhaseMismatchOffVal"));
                double rf2TX0TXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf2TX0TXPhaseMismatchOffVal"));
                double rf3TX0TXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf3TX0TXPhaseMismatchOffVal"));
                double rf1TX1TXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf1TX1TXPhaseMismatchOffVal"));
                double rf2TX1TXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf2TX1TXPhaseMismatchOffVal"));
                double rf3TX1TXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf3TX1TXPhaseMismatchOffVal"));
                double rf1TX2TXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf1TX2TXPhaseMismatchOffVal"));
                double rf2TX2TXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf2TX2TXPhaseMismatchOffVal"));
                double rf3TX2TXPhaseMismatchOffVal = (double)Convert.ToSingle(ConfigurationManager.GetTxGainPhaseMismatchMonConfigKeyVal("rf3TX2TXPhaseMismatchOffVal"));
                this.m_GuiManager.ScriptOps.UpdateTxGainPhaseMismtchMonConfigData(txGainPhaseMismacthMonProfileIndex, txGainPhaseMismacthMonReportingMode, rf1TXGainPhaseMismatchMonBitMask, rf2TXGainPhaseMismatchMonBitMask, rf3TXGainPhaseMismatchMonBitMask, tx0GainPhaseMismatchMon, tx1GainPhaseMismatchMon, tx2GainPhaseMismatchMon, txGainPhaseMismatchMonRx, txGainPhaseMismatchMonRx2, txGainPhaseMismatchMonRx3, txGainPhaseMismatchMonRx4, txGainPhaseMismacthMonTxGainMismatchThreshold, txGainPhaseMismacthMonTxPhaseMismatchThreshold, rf1TX0TXGainPhaseMismatchOffVal, rf2TX0TXGainPhaseMismatchOffVal, rf3TX0TXGainPhaseMismatchOffVal, rf1TX1TXGainPhaseMismatchOffVal, rf2TX1TXGainPhaseMismatchOffVal, rf3TX1TXGainPhaseMismatchOffVal, rf1TX2TXGainPhaseMismatchOffVal, rf2TX2TXGainPhaseMismatchOffVal, rf3TX2TXGainPhaseMismatchOffVal, rf1TX0TXPhaseMismatchOffVal, rf2TX0TXPhaseMismatchOffVal, rf3TX0TXPhaseMismatchOffVal, rf1TX1TXPhaseMismatchOffVal, rf2TX1TXPhaseMismatchOffVal, rf3TX1TXPhaseMismatchOffVal, rf1TX2TXPhaseMismatchOffVal, rf2TX2TXPhaseMismatchOffVal, rf3TX2TXPhaseMismatchOffVal);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveAnalogFaultInjectionConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveAnalogFaultInjectionConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxGainDropRx0", (this.m_chbRxGainDropRx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxGainDropRx1", (this.m_chbRxGainDropRx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxGainDropRx2", (this.m_chbRxGainDropRx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxGainDropRx3", (this.m_chbRxGainDropRx4.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxPhaseInvRx0", (this.m_chbRxPhaseInvRx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxPhaseInvRx1", (this.m_chbRxPhaseInvRx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxPhaseInvRx2", (this.m_chbRxPhaseInvRx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxPhaseInvRx3", (this.m_chbRxPhaseInvRx4.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxHighNoiseRx0", (this.m_chbRxHighNoiseRx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxHighNoiseRx1", (this.m_chbRxHighNoiseRx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxHighNoiseRx2", (this.m_chbRxHighNoiseRx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxHighNoiseRx3", (this.m_chbRxHighNoiseRx4.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxIFStageRx0", (this.m_chbRxIFStageRx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxIFStageRx1", (this.m_chbRxIFStageRx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxIFStageRx2", (this.m_chbRxIFStageRx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxIFStageRx3", (this.m_chbRxIFStageRx4.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxLOAmpRx0Rx1", (this.m_chbRxLOAmpRx0Rx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("rxLOAmpRx2Rx3", (this.m_chbRxLOAmpRx2Rx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("txLOAmpTx0Tx1", (this.m_chbTxLOAmpTx0Tx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("txLOAmpTx2", (this.m_chbTxLOAmpTx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("txGainDropTx0", (this.m_chbTxGainDropTx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("txGainDropTx1", (this.m_chbTxGainDropTx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("txGainDropTx2", (this.m_chbTxGainDropTx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("txGainInvTx0BPMVal", (this.m_chbTxGainInvTx1BPMVal.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("txGainInvTx1BPMVal", (this.m_chbTxGainInvTx2BPMVal.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("txGainInvTx2BPMVal", (this.m_chbTxGainInvTx3BPMVal.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("txGainInvTxFault", (this.m_chbTxGainInvTxFault.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("synthVCOOpenLoop", (this.m_chbSynthVCOOpenLoop.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("synthFreqMonOffset", (this.m_chbSynthFreqMonOffset.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("ldoRxLODistFault", (this.f000116.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("gpadcClkFreqFault", (this.f000117.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("gpadcIntSigMon", (this.f000118.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAnalogFaultInjectionConfigKeyVal("extAnaSigMon", (this.m_chbExtAnaSigMon.Checked ? 1 : 0).ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadAnalogFaultInjectionConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadAnalogFaultInjectionConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte rxGainDropRx = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxGainDropRx0"));
                byte rxGainDropRx2 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxGainDropRx1"));
                byte rxGainDropRx3 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxGainDropRx2"));
                byte rxGainDropRx4 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxGainDropRx3"));
                byte rxPhaseInvRx = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxPhaseInvRx0"));
                byte rxPhaseInvRx2 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxPhaseInvRx1"));
                byte rxPhaseInvRx3 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxPhaseInvRx2"));
                byte rxPhaseInvRx4 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxPhaseInvRx3"));
                byte rxHighNoiseRx = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxHighNoiseRx0"));
                byte rxHighNoiseRx2 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxHighNoiseRx1"));
                byte rxHighNoiseRx3 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxHighNoiseRx2"));
                byte rxHighNoiseRx4 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxHighNoiseRx3"));
                byte rxIFStageRx = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxIFStageRx0"));
                byte rxIFStageRx2 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxIFStageRx1"));
                byte rxIFStageRx3 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxIFStageRx2"));
                byte rxIFStageRx4 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxIFStageRx3"));
                byte rxLOAmpRx0Rx = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxLOAmpRx0Rx1"));
                byte rxLOAmpRx2Rx = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("rxLOAmpRx2Rx3"));
                byte txLOAmpTx0Tx = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("txLOAmpTx0Tx1"));
                byte txLOAmpTx = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("txLOAmpTx2"));
                byte txGainDropTx = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("txGainDropTx0"));
                byte txGainDropTx2 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("txGainDropTx1"));
                byte txGainDropTx3 = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("txGainDropTx2"));
                byte txGainInvTx0BPMVal = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("txGainInvTx0BPMVal"));
                byte txGainInvTx1BPMVal = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("txGainInvTx1BPMVal"));
                byte txGainInvTx2BPMVal = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("txGainInvTx2BPMVal"));
                byte txGainInvTxFault = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("txGainInvTxFault"));
                byte synthVCOOpenLoop = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("synthVCOOpenLoop"));
                byte synthFreqMonOffset = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("synthFreqMonOffset"));
                byte ldoRxLODistFault = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("ldoRxLODistFault"));
                byte gpadcClkFreqFault = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("gpadcClkFreqFault"));
                byte gpadcIntSigMon = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("gpadcIntSigMon"));
                byte extAnaSigMon = Convert.ToByte(ConfigurationManager.GetAnalogFaultInjectionConfigKeyVal("extAnaSigMon"));
                this.m_GuiManager.ScriptOps.UpdateNAnalogFaultInjectionConfigData(rxGainDropRx, rxGainDropRx2, rxGainDropRx3, rxGainDropRx4, rxPhaseInvRx, rxPhaseInvRx2, rxPhaseInvRx3, rxPhaseInvRx4, rxHighNoiseRx, rxHighNoiseRx2, rxHighNoiseRx3, rxHighNoiseRx4, rxIFStageRx, rxIFStageRx2, rxIFStageRx3, rxIFStageRx4, rxLOAmpRx0Rx, rxLOAmpRx2Rx, txLOAmpTx0Tx, txLOAmpTx, txGainDropTx, txGainDropTx2, txGainDropTx3, txGainInvTx0BPMVal, txGainInvTx1BPMVal, txGainInvTx2BPMVal, txGainInvTxFault, synthVCOOpenLoop, synthFreqMonOffset, ldoRxLODistFault, gpadcClkFreqFault, gpadcIntSigMon, extAnaSigMon);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private void m_nudPhaseShifter1Const_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTX1BPMPhaseMonPhaseShift1.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTX1BPMPhaseMonPhaseShift1.Text = num.ToString();
        }

        private void m_nudTx0BPMPhaseShifter2Const_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTX1BPMPhaseMonPhaseShift2.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTX1BPMPhaseMonPhaseShift2.Text = num.ToString();
        }

        private void m_nudTx0BPMPhaseShifterIncConst_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTX1BPMPhaseMonPhaseShiftCfg.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTX1BPMPhaseMonPhaseShiftCfg.Text = num.ToString();
        }

        private void m_nudTx1BPMPhaseShifterIncConst_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTX2BPMPhaseMonPhaseShiftCfg.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTX2BPMPhaseMonPhaseShiftCfg.Text = num.ToString();
        }

        private void m_nudTx2BPMPhaseShifterIncConst_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTX3BPMPhaseMonPhaseShiftCfg.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTX3BPMPhaseMonPhaseShiftCfg.Text = num.ToString();
        }

        private void m_nudTx0BPMPhaseShifter1Const_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTX2BPMPhaseMonPhaseShift1.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTX2BPMPhaseMonPhaseShift1.Text = num.ToString();
        }

        private void m_nudTx1BPMPhaseShifter2Const_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTX2BPMPhaseMonPhaseShift2.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTX2BPMPhaseMonPhaseShift2.Text = num.ToString();
        }

        private void m_nudTx2BPMPhaseShifter1Const_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTX3BPMPhaseMonPhaseShift1.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTX3BPMPhaseMonPhaseShift1.Text = num.ToString();
        }

        private void m_nudTx2BPMPhaseShifter2Const_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTX3BPMPhaseMonPhaseShift2.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTX3BPMPhaseMonPhaseShift2.Text = num.ToString();
        }

        private void m_nudTX1BPMTxPhaseShiftThreshold1_ValueChanged(object sender, EventArgs p1)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.m_grpMonitoringTX1PowerConfig = new GroupBox();
            this.m_nudTX3PowerReportingMode = new NumericUpDown();
            this.m_nudTX2PowerReportingMode = new NumericUpDown();
            this.m_nudTX1PowerReportingMode = new NumericUpDown();
            this.m_nudTX3PwFlatnessThreshold = new NumericUpDown();
            this.m_nudTX2PwFlatnessThreshold = new NumericUpDown();
            this.m_nudTX3PwAbsErrThreshold = new NumericUpDown();
            this.m_nudTX2PwAbsErrThreshold = new NumericUpDown();
            this.f000106 = new CheckBox();
            this.f000107 = new CheckBox();
            this.f000108 = new CheckBox();
            this.f000109 = new CheckBox();
            this.f00010a = new CheckBox();
            this.f00010b = new CheckBox();
            this.m_btnTX3PowerMonConfigSet = new Button();
            this.m_btnTX2PowerMonConfigSet = new Button();
            this.m_btnTX1PowerMonConfigSet = new Button();
            this.m_nudTXPwFlatnessThreshold = new NumericUpDown();
            this.m_nudTXPwAbsErrThreshold = new NumericUpDown();
            this.f000103 = new CheckBox();
            this.f000104 = new CheckBox();
            this.f000105 = new CheckBox();
            this.label33 = new Label();
            this.label32 = new Label();
            this.label31 = new Label();
            this.m_nudTX3PwrMonProfileIndex = new NumericUpDown();
            this.m_nudTX2PwrMonProfileIndex = new NumericUpDown();
            this.m_nudTXPwrMonProfileIndex = new NumericUpDown();
            this.label30 = new Label();
            this.label29 = new Label();
            this.label28 = new Label();
            this.label27 = new Label();
            this.label26 = new Label();
            this.m_grpTXBallBreakMonitoringConfig = new GroupBox();
            this.m_nudTX3BallBreakMonReportingMode = new NumericUpDown();
            this.m_nudTX2BallBreakMonReportingMode = new NumericUpDown();
            this.m_nudTX1BallBreakMonReportingMode = new NumericUpDown();
            this.m_btnTX3BallBreakMonConfigSet = new Button();
            this.m_btnTX2BallBreakMonConfigSet = new Button();
            this.m_btnTX1BallBreakMonConfigSet = new Button();
            this.m_nudTX3ReflCoeffMagThreshold = new NumericUpDown();
            this.m_nudTX2ReflCoeffMagThreshold = new NumericUpDown();
            this.m_nudTX1ReflCoeffMagThreshold = new NumericUpDown();
            this.label63 = new Label();
            this.label64 = new Label();
            this.label36 = new Label();
            this.label35 = new Label();
            this.label34 = new Label();
            this.label57 = new Label();
            this.label56 = new Label();
            this.label55 = new Label();
            this.label54 = new Label();
            this.label53 = new Label();
            this.label72 = new Label();
            this.label77 = new Label();
            this.label78 = new Label();
            this.label79 = new Label();
            this.m_grpMonitoringTxBPMPhaseConfig = new GroupBox();
            this.m_chbTX2BPMMonPhaseShiftIncMonValEna = new CheckBox();
            this.m_chbTX2BPMMonPhaseShiftMonEna = new CheckBox();
            this.m_chbTX1BPMMonPhaseShiftIncMonValEna = new CheckBox();
            this.m_chbTX1BPMMonPhaseShiftMonEna = new CheckBox();
            this.m_chbTX0BPMMonPhaseShiftIncMonValEna = new CheckBox();
            this.m_chbTX0BPMMonPhaseShiftMonEna = new CheckBox();
            this.f000128 = new NumericUpDown();
            this.f000129 = new NumericUpDown();
            this.m_nudTX3BPMPhaseMonPhaseShift2 = new NumericUpDown();
            this.m_nudTX3BPMPhaseMonPhaseShift1 = new NumericUpDown();
            this.m_nudTX3BPMPhaseMonPhaseShiftCfg = new NumericUpDown();
            this.f00012a = new NumericUpDown();
            this.f00012b = new NumericUpDown();
            this.m_nudTX2BPMPhaseMonPhaseShift2 = new NumericUpDown();
            this.m_nudTX2BPMPhaseMonPhaseShift1 = new NumericUpDown();
            this.m_nudTX2BPMPhaseMonPhaseShiftCfg = new NumericUpDown();
            this.label75 = new Label();
            this.f00012c = new NumericUpDown();
            this.f00012d = new NumericUpDown();
            this.label74 = new Label();
            this.label73 = new Label();
            this.label71 = new Label();
            this.m_nudTX1BPMPhaseMonPhaseShift2 = new NumericUpDown();
            this.m_nudTX1BPMPhaseMonPhaseShift1 = new NumericUpDown();
            this.m_nudTX1BPMPhaseMonPhaseShiftCfg = new NumericUpDown();
            this.label70 = new Label();
            this.label69 = new Label();
            this.label68 = new Label();
            this.f000121 = new CheckBox();
            this.f000122 = new CheckBox();
            this.f000123 = new CheckBox();
            this.f000124 = new CheckBox();
            this.f00011b = new CheckBox();
            this.f00011c = new CheckBox();
            this.f00011d = new CheckBox();
            this.f00011e = new CheckBox();
            this.f00011f = new CheckBox();
            this.f000120 = new CheckBox();
            this.f000119 = new CheckBox();
            this.f00011a = new CheckBox();
            this.label51 = new Label();
            this.f00010c = new Button();
            this.f00010d = new Button();
            this.f00010e = new Button();
            this.label81 = new Label();
            this.label80 = new Label();
            this.m_nudTX3BPMAmplitudeMonErrorThreshold = new NumericUpDown();
            this.m_nudTX3BPMPhaseMonErrorThreshold = new NumericUpDown();
            this.m_nudTX3BPMPhaseMonReportMode = new NumericUpDown();
            this.m_nudTX3BPMPhaseMonProfileIndex = new NumericUpDown();
            this.m_nudTX2BPMAmplitudeMonErrorThreshold = new NumericUpDown();
            this.m_nudTX2BPMPhaseMonErrorThreshold = new NumericUpDown();
            this.m_nudTX2BPMPhaseMonReportMode = new NumericUpDown();
            this.m_nudTX2BPMPhaseMonProfileIndex = new NumericUpDown();
            this.m_nudTX1BPMAmplitudeMonErrorThreshold = new NumericUpDown();
            this.m_nudTX1BPMPhaseMonErrorThreshold = new NumericUpDown();
            this.m_nudTX1BPMPhaseMonReportMode = new NumericUpDown();
            this.m_nudTX1BPMPhaseMonProfileIndex = new NumericUpDown();
            this.groupBox1 = new GroupBox();
            this.m_chbTXGainPhaseMismatchMonRx3 = new CheckBox();
            this.m_chbTXGainPhaseMismatchMonRx2 = new CheckBox();
            this.m_chbTXGainPhaseMismatchMonRx1 = new CheckBox();
            this.m_chbTXGainPhaseMismatchMonRx0 = new CheckBox();
            this.label50 = new Label();
            this.m_btnTXGainPhaseMismatchMonConfigSet = new Button();
            this.label102 = new Label();
            this.label101 = new Label();
            this.label100 = new Label();
            this.label99 = new Label();
            this.label98 = new Label();
            this.label97 = new Label();
            this.label96 = new Label();
            this.label95 = new Label();
            this.label94 = new Label();
            this.label93 = new Label();
            this.label92 = new Label();
            this.label91 = new Label();
            this.m_nudRF1TX3TXPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF1TX2TXPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF1TX1TXPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF3TX3TXPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF3TX2TXPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF3TX1TXPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF2TX3TXPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF2TX2TXPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF2TX1TXPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF3TX3TXGainPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF3TX2TXGainPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF3TX1TXGainPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF2TX3TXGainPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF2TX2TXGainPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF2TX1TXGainPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF1TX3TXGainPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudRF1TX2TXGainPhaseMismatchOffVal = new NumericUpDown();
            this.label90 = new Label();
            this.m_nudRF1TX1TXGainPhaseMismatchOffVal = new NumericUpDown();
            this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold = new NumericUpDown();
            this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold = new NumericUpDown();
            this.m_nudTxGainPhaseMismacthMonReportingMode = new NumericUpDown();
            this.m_chbTXGainPhaseMismatchMonTx3 = new CheckBox();
            this.m_chbTXGainPhaseMismatchMonTx2 = new CheckBox();
            this.m_chbTXGainPhaseMismatchMonTx1 = new CheckBox();
            this.m_chbRF3TXGainPhaseMismatchMonBitMask = new CheckBox();
            this.m_chbRF2TXGainPhaseMismatchMonBitMask = new CheckBox();
            this.m_chbRF1TXGainPhaseMismatchMonBitMask = new CheckBox();
            this.m_nudTxGainPhaseMismacthMonProfileIndex = new NumericUpDown();
            this.label86 = new Label();
            this.label87 = new Label();
            this.label88 = new Label();
            this.label89 = new Label();
            this.label85 = new Label();
            this.label84 = new Label();
            this.label83 = new Label();
            this.label82 = new Label();
            this.m_grpAnalogMonitoringRFEnablesConfig = new GroupBox();
            this.f000125 = new CheckBox();
            this.f000126 = new CheckBox();
            this.f000127 = new CheckBox();
            this.label65 = new Label();
            this.label62 = new Label();
            this.label61 = new Label();
            this.m_chbReservedMonEna = new CheckBox();
            this.label37 = new Label();
            this.m_chbRXMixerInputPowerMonEna = new CheckBox();
            this.label118 = new Label();
            this.label131 = new Label();
            this.m_chbRXSigImgBandMonEna = new CheckBox();
            this.m_btnAnalogMonRFEnablesMonConfigSet = new Button();
            this.f00010f = new CheckBox();
            this.label25 = new Label();
            this.label19 = new Label();
            this.label20 = new Label();
            this.label21 = new Label();
            this.label22 = new Label();
            this.label23 = new Label();
            this.label24 = new Label();
            this.label13 = new Label();
            this.label14 = new Label();
            this.label15 = new Label();
            this.label16 = new Label();
            this.label17 = new Label();
            this.label18 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();
            this.label11 = new Label();
            this.label12 = new Label();
            this.label6 = new Label();
            this.label5 = new Label();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.f000110 = new CheckBox();
            this.f000111 = new CheckBox();
            this.m_chbInternalRXSignalsMonEna = new CheckBox();
            this.m_chbInternalTX3SignalsMonEna = new CheckBox();
            this.m_chbInternalTX2SignalsMonEna = new CheckBox();
            this.m_chbPLLControlVolMonEna = new CheckBox();
            this.m_chbDCCClockFreqMonEna = new CheckBox();
            this.m_chbTemperatureMonEna = new CheckBox();
            this.m_chbInternalTX1SignalsMonEna = new CheckBox();
            this.m_chbExternalAnalogSignalsMonEna = new CheckBox();
            this.m_chbSynthFreqMonEna = new CheckBox();
            this.f000112 = new CheckBox();
            this.f000113 = new CheckBox();
            this.f000114 = new CheckBox();
            this.m_chbTXGainPhaseMonEna = new CheckBox();
            this.m_chbTX3BallBreakMonEna = new CheckBox();
            this.m_chbTX2BallBreakMonEna = new CheckBox();
            this.m_chbTX1BallBreakMonEna = new CheckBox();
            this.m_chbTX3PowerMonEna = new CheckBox();
            this.m_chbTX2PowerMonEna = new CheckBox();
            this.m_chbTX1PowerMonEna = new CheckBox();
            this.f000115 = new CheckBox();
            this.m_chbRXNoiseMonEna = new CheckBox();
            this.m_chbRXGainPhaseMonEna = new CheckBox();
            this.groupBox2 = new GroupBox();
            this.m_chbSynthFreqMonOffset = new CheckBox();
            this.m_btnAnalogFaultInjectionConfigSet = new Button();
            this.m_chbSynthVCOOpenLoop = new CheckBox();
            this.f000116 = new CheckBox();
            this.f000117 = new CheckBox();
            this.f000118 = new CheckBox();
            this.m_chbExtAnaSigMon = new CheckBox();
            this.m_chbTxGainInvTx2BPMVal = new CheckBox();
            this.m_chbTxGainInvTx3BPMVal = new CheckBox();
            this.m_chbTxGainInvTx1BPMVal = new CheckBox();
            this.m_chbTxGainInvTxFault = new CheckBox();
            this.m_chbTxGainDropTx3 = new CheckBox();
            this.m_chbTxGainDropTx2 = new CheckBox();
            this.m_chbTxGainDropTx1 = new CheckBox();
            this.m_chbTxLOAmpTx2 = new CheckBox();
            this.m_chbTxLOAmpTx0Tx1 = new CheckBox();
            this.m_chbRxLOAmpRx2Rx3 = new CheckBox();
            this.m_chbRxLOAmpRx0Rx1 = new CheckBox();
            this.m_chbRxIFStageRx4 = new CheckBox();
            this.m_chbRxIFStageRx3 = new CheckBox();
            this.m_chbRxIFStageRx2 = new CheckBox();
            this.m_chbRxIFStageRx1 = new CheckBox();
            this.m_chbRxHighNoiseRx4 = new CheckBox();
            this.m_chbRxHighNoiseRx3 = new CheckBox();
            this.m_chbRxHighNoiseRx2 = new CheckBox();
            this.m_chbRxHighNoiseRx1 = new CheckBox();
            this.m_chbRxPhaseInvRx4 = new CheckBox();
            this.m_chbRxPhaseInvRx3 = new CheckBox();
            this.m_chbRxPhaseInvRx2 = new CheckBox();
            this.m_chbRxPhaseInvRx1 = new CheckBox();
            this.m_chbRxGainDropRx4 = new CheckBox();
            this.m_chbRxGainDropRx3 = new CheckBox();
            this.m_chbRxGainDropRx2 = new CheckBox();
            this.m_chbRxGainDropRx1 = new CheckBox();
            this.label59 = new Label();
            this.label60 = new Label();
            this.label52 = new Label();
            this.label58 = new Label();
            this.label48 = new Label();
            this.label49 = new Label();
            this.label46 = new Label();
            this.label47 = new Label();
            this.label44 = new Label();
            this.label45 = new Label();
            this.label42 = new Label();
            this.label43 = new Label();
            this.label40 = new Label();
            this.label41 = new Label();
            this.label39 = new Label();
            this.label38 = new Label();
            this.m_grpMonitoringTX1PowerConfig.SuspendLayout();
            ((ISupportInitialize)this.m_nudTX3PowerReportingMode).BeginInit();
            ((ISupportInitialize)this.m_nudTX2PowerReportingMode).BeginInit();
            ((ISupportInitialize)this.m_nudTX1PowerReportingMode).BeginInit();
            ((ISupportInitialize)this.m_nudTX3PwFlatnessThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX2PwFlatnessThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX3PwAbsErrThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX2PwAbsErrThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTXPwFlatnessThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTXPwAbsErrThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX3PwrMonProfileIndex).BeginInit();
            ((ISupportInitialize)this.m_nudTX2PwrMonProfileIndex).BeginInit();
            ((ISupportInitialize)this.m_nudTXPwrMonProfileIndex).BeginInit();
            this.m_grpTXBallBreakMonitoringConfig.SuspendLayout();
            ((ISupportInitialize)this.m_nudTX3BallBreakMonReportingMode).BeginInit();
            ((ISupportInitialize)this.m_nudTX2BallBreakMonReportingMode).BeginInit();
            ((ISupportInitialize)this.m_nudTX1BallBreakMonReportingMode).BeginInit();
            ((ISupportInitialize)this.m_nudTX3ReflCoeffMagThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX2ReflCoeffMagThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX1ReflCoeffMagThreshold).BeginInit();
            this.m_grpMonitoringTxBPMPhaseConfig.SuspendLayout();
            ((ISupportInitialize)this.f000128).BeginInit();
            ((ISupportInitialize)this.f000129).BeginInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonPhaseShift2).BeginInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonPhaseShift1).BeginInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonPhaseShiftCfg).BeginInit();
            ((ISupportInitialize)this.f00012a).BeginInit();
            ((ISupportInitialize)this.f00012b).BeginInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonPhaseShift2).BeginInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonPhaseShift1).BeginInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonPhaseShiftCfg).BeginInit();
            ((ISupportInitialize)this.f00012c).BeginInit();
            ((ISupportInitialize)this.f00012d).BeginInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonPhaseShift2).BeginInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonPhaseShift1).BeginInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonPhaseShiftCfg).BeginInit();
            ((ISupportInitialize)this.m_nudTX3BPMAmplitudeMonErrorThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonErrorThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonReportMode).BeginInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonProfileIndex).BeginInit();
            ((ISupportInitialize)this.m_nudTX2BPMAmplitudeMonErrorThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonErrorThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonReportMode).BeginInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonProfileIndex).BeginInit();
            ((ISupportInitialize)this.m_nudTX1BPMAmplitudeMonErrorThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonErrorThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonReportMode).BeginInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonProfileIndex).BeginInit();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize)this.m_nudRF1TX3TXPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF1TX2TXPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF1TX1TXPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF3TX3TXPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF3TX2TXPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF3TX1TXPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF2TX3TXPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF2TX2TXPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF2TX1TXPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF3TX3TXGainPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF3TX2TXGainPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF3TX1TXGainPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF2TX3TXGainPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF2TX2TXGainPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF2TX1TXGainPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF1TX3TXGainPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF1TX2TXGainPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudRF1TX1TXGainPhaseMismatchOffVal).BeginInit();
            ((ISupportInitialize)this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold).BeginInit();
            ((ISupportInitialize)this.m_nudTxGainPhaseMismacthMonReportingMode).BeginInit();
            ((ISupportInitialize)this.m_nudTxGainPhaseMismacthMonProfileIndex).BeginInit();
            this.m_grpAnalogMonitoringRFEnablesConfig.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTX3PowerReportingMode);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTX2PowerReportingMode);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTX1PowerReportingMode);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTX3PwFlatnessThreshold);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTX2PwFlatnessThreshold);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTX3PwAbsErrThreshold);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTX2PwAbsErrThreshold);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.f000106);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.f000107);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.f000108);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.f000109);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.f00010a);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.f00010b);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_btnTX3PowerMonConfigSet);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_btnTX2PowerMonConfigSet);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_btnTX1PowerMonConfigSet);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTXPwFlatnessThreshold);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTXPwAbsErrThreshold);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.f000103);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.f000104);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.f000105);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.label33);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.label32);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.label31);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTX3PwrMonProfileIndex);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTX2PwrMonProfileIndex);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.m_nudTXPwrMonProfileIndex);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.label30);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.label29);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.label28);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.label27);
            this.m_grpMonitoringTX1PowerConfig.Controls.Add(this.label26);
            this.m_grpMonitoringTX1PowerConfig.Location = new Point(460, 33);
            this.m_grpMonitoringTX1PowerConfig.Margin = new Padding(4);
            this.m_grpMonitoringTX1PowerConfig.Name = "m_grpMonitoringTX1PowerConfig";
            this.m_grpMonitoringTX1PowerConfig.Padding = new Padding(4);
            this.m_grpMonitoringTX1PowerConfig.Size = new Size(743, 234);
            this.m_grpMonitoringTX1PowerConfig.TabIndex = 1;
            this.m_grpMonitoringTX1PowerConfig.TabStop = false;
            this.m_grpMonitoringTX1PowerConfig.Text = "Monitoring TX Power Config";
            this.m_nudTX3PowerReportingMode.Location = new Point(565, 100);
            this.m_nudTX3PowerReportingMode.Margin = new Padding(4);
            int[] array = new int[4];
            array[0] = 2;
            this.m_nudTX3PowerReportingMode.Maximum = new decimal(array);
            this.m_nudTX3PowerReportingMode.Name = "m_nudTX3PowerReportingMode";
            this.m_nudTX3PowerReportingMode.Size = new Size(92, 22);
            this.m_nudTX3PowerReportingMode.TabIndex = 34;
            this.m_nudTX2PowerReportingMode.Location = new Point(389, 100);
            this.m_nudTX2PowerReportingMode.Margin = new Padding(4);
            int[] array2 = new int[4];
            array2[0] = 2;
            this.m_nudTX2PowerReportingMode.Maximum = new decimal(array2);
            this.m_nudTX2PowerReportingMode.Name = "m_nudTX2PowerReportingMode";
            this.m_nudTX2PowerReportingMode.Size = new Size(91, 22);
            this.m_nudTX2PowerReportingMode.TabIndex = 33;
            this.m_nudTX1PowerReportingMode.Location = new Point(203, 100);
            this.m_nudTX1PowerReportingMode.Margin = new Padding(4);
            int[] array3 = new int[4];
            array3[0] = 2;
            this.m_nudTX1PowerReportingMode.Maximum = new decimal(array3);
            this.m_nudTX1PowerReportingMode.Name = "m_nudTX1PowerReportingMode";
            this.m_nudTX1PowerReportingMode.Size = new Size(92, 22);
            this.m_nudTX1PowerReportingMode.TabIndex = 32;
            this.m_nudTX3PwFlatnessThreshold.DecimalPlaces = 1;
            this.m_nudTX3PwFlatnessThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudTX3PwFlatnessThreshold.Location = new Point(565, 164);
            this.m_nudTX3PwFlatnessThreshold.Margin = new Padding(4);
            int[] array4 = new int[4];
            array4[0] = 60;
            this.m_nudTX3PwFlatnessThreshold.Maximum = new decimal(array4);
            this.m_nudTX3PwFlatnessThreshold.Name = "m_nudTX3PwFlatnessThreshold";
            this.m_nudTX3PwFlatnessThreshold.Size = new Size(92, 22);
            this.m_nudTX3PwFlatnessThreshold.TabIndex = 31;
            this.m_nudTX2PwFlatnessThreshold.DecimalPlaces = 1;
            this.m_nudTX2PwFlatnessThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudTX2PwFlatnessThreshold.Location = new Point(388, 164);
            this.m_nudTX2PwFlatnessThreshold.Margin = new Padding(4);
            int[] array5 = new int[4];
            array5[0] = 60;
            this.m_nudTX2PwFlatnessThreshold.Maximum = new decimal(array5);
            this.m_nudTX2PwFlatnessThreshold.Name = "m_nudTX2PwFlatnessThreshold";
            this.m_nudTX2PwFlatnessThreshold.Size = new Size(92, 22);
            this.m_nudTX2PwFlatnessThreshold.TabIndex = 30;
            this.m_nudTX3PwAbsErrThreshold.DecimalPlaces = 1;
            this.m_nudTX3PwAbsErrThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudTX3PwAbsErrThreshold.Location = new Point(565, 133);
            this.m_nudTX3PwAbsErrThreshold.Margin = new Padding(4);
            int[] array6 = new int[4];
            array6[0] = 60;
            this.m_nudTX3PwAbsErrThreshold.Maximum = new decimal(array6);
            this.m_nudTX3PwAbsErrThreshold.Name = "m_nudTX3PwAbsErrThreshold";
            this.m_nudTX3PwAbsErrThreshold.Size = new Size(92, 22);
            this.m_nudTX3PwAbsErrThreshold.TabIndex = 29;
            int[] array7 = new int[4];
            array7[0] = 1;
            this.m_nudTX3PwAbsErrThreshold.Value = new decimal(array7);
            this.m_nudTX2PwAbsErrThreshold.DecimalPlaces = 1;
            this.m_nudTX2PwAbsErrThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudTX2PwAbsErrThreshold.Location = new Point(388, 133);
            this.m_nudTX2PwAbsErrThreshold.Margin = new Padding(4);
            int[] array8 = new int[4];
            array8[0] = 60;
            this.m_nudTX2PwAbsErrThreshold.Maximum = new decimal(array8);
            this.m_nudTX2PwAbsErrThreshold.Name = "m_nudTX2PwAbsErrThreshold";
            this.m_nudTX2PwAbsErrThreshold.Size = new Size(92, 22);
            this.m_nudTX2PwAbsErrThreshold.TabIndex = 28;
            int[] array9 = new int[4];
            array9[0] = 1;
            this.m_nudTX2PwAbsErrThreshold.Value = new decimal(array9);
            this.f000106.AutoSize = true;
            this.f000106.Checked = true;
            this.f000106.CheckState = CheckState.Checked;
            this.f000106.Location = new Point(673, 71);
            this.f000106.Margin = new Padding(4);
            this.f000106.Name = "m_chbTX3PowerRF3";
            this.f000106.Size = new Size(56, 21);
            this.f000106.TabIndex = 25;
            this.f000106.Text = "RF3";
            this.f000106.UseVisualStyleBackColor = true;
            this.f000107.AutoSize = true;
            this.f000107.Checked = true;
            this.f000107.CheckState = CheckState.Checked;
            this.f000107.Location = new Point(619, 71);
            this.f000107.Margin = new Padding(4);
            this.f000107.Name = "m_chbTX3PowerRF2";
            this.f000107.Size = new Size(56, 21);
            this.f000107.TabIndex = 24;
            this.f000107.Text = "RF2";
            this.f000107.UseVisualStyleBackColor = true;
            this.f000108.AutoSize = true;
            this.f000108.Checked = true;
            this.f000108.CheckState = CheckState.Checked;
            this.f000108.Location = new Point(565, 71);
            this.f000108.Margin = new Padding(4);
            this.f000108.Name = "m_chbTX3PowerRF1";
            this.f000108.Size = new Size(56, 21);
            this.f000108.TabIndex = 23;
            this.f000108.Text = "RF1";
            this.f000108.UseVisualStyleBackColor = true;
            this.f000109.AutoSize = true;
            this.f000109.Checked = true;
            this.f000109.CheckState = CheckState.Checked;
            this.f000109.Location = new Point(495, 71);
            this.f000109.Margin = new Padding(4);
            this.f000109.Name = "m_chbTX2PowerRF3";
            this.f000109.Size = new Size(56, 21);
            this.f000109.TabIndex = 22;
            this.f000109.Text = "RF3";
            this.f000109.UseVisualStyleBackColor = true;
            this.f00010a.AutoSize = true;
            this.f00010a.Checked = true;
            this.f00010a.CheckState = CheckState.Checked;
            this.f00010a.Location = new Point(441, 71);
            this.f00010a.Margin = new Padding(4);
            this.f00010a.Name = "m_chbTX2PowerRF2";
            this.f00010a.Size = new Size(56, 21);
            this.f00010a.TabIndex = 21;
            this.f00010a.Text = "RF2";
            this.f00010a.UseVisualStyleBackColor = true;
            this.f00010b.AutoSize = true;
            this.f00010b.Checked = true;
            this.f00010b.CheckState = CheckState.Checked;
            this.f00010b.Location = new Point(388, 71);
            this.f00010b.Margin = new Padding(4);
            this.f00010b.Name = "m_chbTX2PowerRF1";
            this.f00010b.Size = new Size(56, 21);
            this.f00010b.TabIndex = 20;
            this.f00010b.Text = "RF1";
            this.f00010b.UseVisualStyleBackColor = true;
            this.m_btnTX3PowerMonConfigSet.Location = new Point(591, 196);
            this.m_btnTX3PowerMonConfigSet.Margin = new Padding(4);
            this.m_btnTX3PowerMonConfigSet.Name = "m_btnTX3PowerMonConfigSet";
            this.m_btnTX3PowerMonConfigSet.Size = new Size(67, 33);
            this.m_btnTX3PowerMonConfigSet.TabIndex = 19;
            this.m_btnTX3PowerMonConfigSet.Text = "Set";
            this.m_btnTX3PowerMonConfigSet.UseVisualStyleBackColor = true;
            this.m_btnTX3PowerMonConfigSet.Click += this.m_btnTX3PowerMonConfigSet_Click;
            this.m_btnTX2PowerMonConfigSet.Location = new Point(413, 196);
            this.m_btnTX2PowerMonConfigSet.Margin = new Padding(4);
            this.m_btnTX2PowerMonConfigSet.Name = "m_btnTX2PowerMonConfigSet";
            this.m_btnTX2PowerMonConfigSet.Size = new Size(67, 33);
            this.m_btnTX2PowerMonConfigSet.TabIndex = 18;
            this.m_btnTX2PowerMonConfigSet.Text = "Set";
            this.m_btnTX2PowerMonConfigSet.UseVisualStyleBackColor = true;
            this.m_btnTX2PowerMonConfigSet.Click += this.m_btnTX2PowerMonConfigSet_Click;
            this.m_btnTX1PowerMonConfigSet.Location = new Point(228, 196);
            this.m_btnTX1PowerMonConfigSet.Margin = new Padding(4);
            this.m_btnTX1PowerMonConfigSet.Name = "m_btnTX1PowerMonConfigSet";
            this.m_btnTX1PowerMonConfigSet.Size = new Size(67, 33);
            this.m_btnTX1PowerMonConfigSet.TabIndex = 17;
            this.m_btnTX1PowerMonConfigSet.Text = "Set";
            this.m_btnTX1PowerMonConfigSet.UseVisualStyleBackColor = true;
            this.m_btnTX1PowerMonConfigSet.Click += this.m_btnTX1PowerMonConfigSet_Click;
            this.m_nudTXPwFlatnessThreshold.DecimalPlaces = 1;
            this.m_nudTXPwFlatnessThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudTXPwFlatnessThreshold.Location = new Point(203, 162);
            this.m_nudTXPwFlatnessThreshold.Margin = new Padding(4);
            int[] array10 = new int[4];
            array10[0] = 60;
            this.m_nudTXPwFlatnessThreshold.Maximum = new decimal(array10);
            this.m_nudTXPwFlatnessThreshold.Name = "m_nudTXPwFlatnessThreshold";
            this.m_nudTXPwFlatnessThreshold.Size = new Size(92, 22);
            this.m_nudTXPwFlatnessThreshold.TabIndex = 16;
            this.m_nudTXPwAbsErrThreshold.DecimalPlaces = 1;
            this.m_nudTXPwAbsErrThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudTXPwAbsErrThreshold.Location = new Point(203, 130);
            this.m_nudTXPwAbsErrThreshold.Margin = new Padding(4);
            int[] array11 = new int[4];
            array11[0] = 60;
            this.m_nudTXPwAbsErrThreshold.Maximum = new decimal(array11);
            this.m_nudTXPwAbsErrThreshold.Name = "m_nudTXPwAbsErrThreshold";
            this.m_nudTXPwAbsErrThreshold.Size = new Size(92, 22);
            this.m_nudTXPwAbsErrThreshold.TabIndex = 15;
            int[] array12 = new int[4];
            array12[0] = 1;
            this.m_nudTXPwAbsErrThreshold.Value = new decimal(array12);
            this.f000103.AutoSize = true;
            this.f000103.Checked = true;
            this.f000103.CheckState = CheckState.Checked;
            this.f000103.Location = new Point(313, 71);
            this.f000103.Margin = new Padding(4);
            this.f000103.Name = "m_chbTXPowerRF3";
            this.f000103.Size = new Size(56, 21);
            this.f000103.TabIndex = 13;
            this.f000103.Text = "RF3";
            this.f000103.UseVisualStyleBackColor = true;
            this.f000104.AutoSize = true;
            this.f000104.Checked = true;
            this.f000104.CheckState = CheckState.Checked;
            this.f000104.Location = new Point(257, 71);
            this.f000104.Margin = new Padding(4);
            this.f000104.Name = "m_chbTXPowerRF2";
            this.f000104.Size = new Size(56, 21);
            this.f000104.TabIndex = 12;
            this.f000104.Text = "RF2";
            this.f000104.UseVisualStyleBackColor = true;
            this.f000105.AutoSize = true;
            this.f000105.Checked = true;
            this.f000105.CheckState = CheckState.Checked;
            this.f000105.Location = new Point(203, 71);
            this.f000105.Margin = new Padding(4);
            this.f000105.Name = "m_chbTXPowerRF1";
            this.f000105.Size = new Size(56, 21);
            this.f000105.TabIndex = 11;
            this.f000105.Text = "RF1";
            this.f000105.UseVisualStyleBackColor = true;
            this.label33.AutoSize = true;
            this.label33.Location = new Point(561, 17);
            this.label33.Margin = new Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new Size(77, 17);
            this.label33.TabIndex = 10;
            this.label33.Text = "TX2 Power";
            this.label32.AutoSize = true;
            this.label32.Location = new Point(385, 16);
            this.label32.Margin = new Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new Size(77, 17);
            this.label32.TabIndex = 9;
            this.label32.Text = "TX1 Power";
            this.label31.AutoSize = true;
            this.label31.Location = new Point(204, 16);
            this.label31.Margin = new Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new Size(77, 17);
            this.label31.TabIndex = 8;
            this.label31.Text = "TX0 Power";
            this.m_nudTX3PwrMonProfileIndex.Location = new Point(565, 37);
            this.m_nudTX3PwrMonProfileIndex.Margin = new Padding(4);
            int[] array13 = new int[4];
            array13[0] = 3;
            this.m_nudTX3PwrMonProfileIndex.Maximum = new decimal(array13);
            this.m_nudTX3PwrMonProfileIndex.Name = "m_nudTX3PwrMonProfileIndex";
            this.m_nudTX3PwrMonProfileIndex.Size = new Size(92, 22);
            this.m_nudTX3PwrMonProfileIndex.TabIndex = 7;
            this.m_nudTX2PwrMonProfileIndex.Location = new Point(388, 37);
            this.m_nudTX2PwrMonProfileIndex.Margin = new Padding(4);
            int[] array14 = new int[4];
            array14[0] = 3;
            this.m_nudTX2PwrMonProfileIndex.Maximum = new decimal(array14);
            this.m_nudTX2PwrMonProfileIndex.Name = "m_nudTX2PwrMonProfileIndex";
            this.m_nudTX2PwrMonProfileIndex.Size = new Size(92, 22);
            this.m_nudTX2PwrMonProfileIndex.TabIndex = 6;
            this.m_nudTXPwrMonProfileIndex.Location = new Point(203, 37);
            this.m_nudTXPwrMonProfileIndex.Margin = new Padding(4);
            int[] array15 = new int[4];
            array15[0] = 3;
            this.m_nudTXPwrMonProfileIndex.Maximum = new decimal(array15);
            this.m_nudTXPwrMonProfileIndex.Name = "m_nudTXPwrMonProfileIndex";
            this.m_nudTXPwrMonProfileIndex.Size = new Size(92, 22);
            this.m_nudTXPwrMonProfileIndex.TabIndex = 5;
            this.label30.AutoSize = true;
            this.label30.Location = new Point(7, 164);
            this.label30.Margin = new Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new Size(183, 17);
            this.label30.TabIndex = 4;
            this.label30.Text = "Tx Pow Flat Err Thresh (dB)";
            this.label29.AutoSize = true;
            this.label29.Location = new Point(7, 133);
            this.label29.Margin = new Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new Size(184, 17);
            this.label29.TabIndex = 3;
            this.label29.Text = "Tx Pow Abs Err Thresh (dB)";
            this.label28.AutoSize = true;
            this.label28.Location = new Point(7, 102);
            this.label28.Margin = new Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new Size(109, 17);
            this.label28.TabIndex = 2;
            this.label28.Text = "Reporting Mode";
            this.label27.AutoSize = true;
            this.label27.Location = new Point(7, 71);
            this.label27.Margin = new Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new Size(112, 17);
            this.label27.TabIndex = 1;
            this.label27.Text = "RF Freq BitMask";
            this.label26.AutoSize = true;
            this.label26.Location = new Point(7, 41);
            this.label26.Margin = new Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new Size(85, 17);
            this.label26.TabIndex = 0;
            this.label26.Text = "Profile Index";
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.m_nudTX3BallBreakMonReportingMode);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.m_nudTX2BallBreakMonReportingMode);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.m_nudTX1BallBreakMonReportingMode);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.m_btnTX3BallBreakMonConfigSet);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.m_btnTX2BallBreakMonConfigSet);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.m_btnTX1BallBreakMonConfigSet);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.m_nudTX3ReflCoeffMagThreshold);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.m_nudTX2ReflCoeffMagThreshold);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.m_nudTX1ReflCoeffMagThreshold);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.label63);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.label64);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.label36);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.label35);
            this.m_grpTXBallBreakMonitoringConfig.Controls.Add(this.label34);
            this.m_grpTXBallBreakMonitoringConfig.Location = new Point(460, 274);
            this.m_grpTXBallBreakMonitoringConfig.Margin = new Padding(4);
            this.m_grpTXBallBreakMonitoringConfig.Name = "m_grpTXBallBreakMonitoringConfig";
            this.m_grpTXBallBreakMonitoringConfig.Padding = new Padding(4);
            this.m_grpTXBallBreakMonitoringConfig.Size = new Size(575, 144);
            this.m_grpTXBallBreakMonitoringConfig.TabIndex = 2;
            this.m_grpTXBallBreakMonitoringConfig.TabStop = false;
            this.m_grpTXBallBreakMonitoringConfig.Text = "TX Ball Break Monitoring";
            this.m_nudTX3BallBreakMonReportingMode.Location = new Point(464, 36);
            this.m_nudTX3BallBreakMonReportingMode.Margin = new Padding(4);
            int[] array16 = new int[4];
            array16[0] = 2;
            this.m_nudTX3BallBreakMonReportingMode.Maximum = new decimal(array16);
            this.m_nudTX3BallBreakMonReportingMode.Name = "m_nudTX3BallBreakMonReportingMode";
            this.m_nudTX3BallBreakMonReportingMode.Size = new Size(92, 22);
            this.m_nudTX3BallBreakMonReportingMode.TabIndex = 39;
            this.m_nudTX2BallBreakMonReportingMode.Location = new Point(341, 36);
            this.m_nudTX2BallBreakMonReportingMode.Margin = new Padding(4);
            int[] array17 = new int[4];
            array17[0] = 2;
            this.m_nudTX2BallBreakMonReportingMode.Maximum = new decimal(array17);
            this.m_nudTX2BallBreakMonReportingMode.Name = "m_nudTX2BallBreakMonReportingMode";
            this.m_nudTX2BallBreakMonReportingMode.Size = new Size(92, 22);
            this.m_nudTX2BallBreakMonReportingMode.TabIndex = 38;
            this.m_nudTX1BallBreakMonReportingMode.Location = new Point(220, 37);
            this.m_nudTX1BallBreakMonReportingMode.Margin = new Padding(4);
            int[] array18 = new int[4];
            array18[0] = 2;
            this.m_nudTX1BallBreakMonReportingMode.Maximum = new decimal(array18);
            this.m_nudTX1BallBreakMonReportingMode.Name = "m_nudTX1BallBreakMonReportingMode";
            this.m_nudTX1BallBreakMonReportingMode.Size = new Size(92, 22);
            this.m_nudTX1BallBreakMonReportingMode.TabIndex = 37;
            this.m_btnTX3BallBreakMonConfigSet.Location = new Point(464, 101);
            this.m_btnTX3BallBreakMonConfigSet.Margin = new Padding(4);
            this.m_btnTX3BallBreakMonConfigSet.Name = "m_btnTX3BallBreakMonConfigSet";
            this.m_btnTX3BallBreakMonConfigSet.Size = new Size(93, 33);
            this.m_btnTX3BallBreakMonConfigSet.TabIndex = 36;
            this.m_btnTX3BallBreakMonConfigSet.Text = "Set";
            this.m_btnTX3BallBreakMonConfigSet.UseVisualStyleBackColor = true;
            this.m_btnTX3BallBreakMonConfigSet.Click += this.m_btnTX3BallBreakMonConfigSet_Click;
            this.m_btnTX2BallBreakMonConfigSet.Location = new Point(341, 101);
            this.m_btnTX2BallBreakMonConfigSet.Margin = new Padding(4);
            this.m_btnTX2BallBreakMonConfigSet.Name = "m_btnTX2BallBreakMonConfigSet";
            this.m_btnTX2BallBreakMonConfigSet.Size = new Size(93, 33);
            this.m_btnTX2BallBreakMonConfigSet.TabIndex = 35;
            this.m_btnTX2BallBreakMonConfigSet.Text = "Set";
            this.m_btnTX2BallBreakMonConfigSet.UseVisualStyleBackColor = true;
            this.m_btnTX2BallBreakMonConfigSet.Click += this.m_btnTX2BallBreakMonConfigSet_Click;
            this.m_btnTX1BallBreakMonConfigSet.Location = new Point(220, 101);
            this.m_btnTX1BallBreakMonConfigSet.Margin = new Padding(4);
            this.m_btnTX1BallBreakMonConfigSet.Name = "m_btnTX1BallBreakMonConfigSet";
            this.m_btnTX1BallBreakMonConfigSet.Size = new Size(93, 33);
            this.m_btnTX1BallBreakMonConfigSet.TabIndex = 34;
            this.m_btnTX1BallBreakMonConfigSet.Text = "Set";
            this.m_btnTX1BallBreakMonConfigSet.UseVisualStyleBackColor = true;
            this.m_btnTX1BallBreakMonConfigSet.Click += this.m_btnTX1BallBreakMonConfigSet_Click;
            this.m_nudTX3ReflCoeffMagThreshold.DecimalPlaces = 1;
            this.m_nudTX3ReflCoeffMagThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudTX3ReflCoeffMagThreshold.Location = new Point(464, 69);
            this.m_nudTX3ReflCoeffMagThreshold.Margin = new Padding(4);
            int[] array19 = new int[4];
            array19[0] = 32767;
            this.m_nudTX3ReflCoeffMagThreshold.Maximum = new decimal(array19);
            this.m_nudTX3ReflCoeffMagThreshold.Minimum = new decimal(new int[]
            {
                32768,
                0,
                0,
                int.MinValue
            });
            this.m_nudTX3ReflCoeffMagThreshold.Name = "m_nudTX3ReflCoeffMagThreshold";
            this.m_nudTX3ReflCoeffMagThreshold.Size = new Size(92, 22);
            this.m_nudTX3ReflCoeffMagThreshold.TabIndex = 33;
            this.m_nudTX3ReflCoeffMagThreshold.Value = new decimal(new int[]
            {
                9,
                0,
                0,
                int.MinValue
            });
            this.m_nudTX2ReflCoeffMagThreshold.DecimalPlaces = 1;
            this.m_nudTX2ReflCoeffMagThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudTX2ReflCoeffMagThreshold.Location = new Point(341, 69);
            this.m_nudTX2ReflCoeffMagThreshold.Margin = new Padding(4);
            int[] array20 = new int[4];
            array20[0] = 32767;
            this.m_nudTX2ReflCoeffMagThreshold.Maximum = new decimal(array20);
            this.m_nudTX2ReflCoeffMagThreshold.Minimum = new decimal(new int[]
            {
                32768,
                0,
                0,
                int.MinValue
            });
            this.m_nudTX2ReflCoeffMagThreshold.Name = "m_nudTX2ReflCoeffMagThreshold";
            this.m_nudTX2ReflCoeffMagThreshold.Size = new Size(92, 22);
            this.m_nudTX2ReflCoeffMagThreshold.TabIndex = 32;
            this.m_nudTX2ReflCoeffMagThreshold.Value = new decimal(new int[]
            {
                9,
                0,
                0,
                int.MinValue
            });
            this.m_nudTX1ReflCoeffMagThreshold.DecimalPlaces = 1;
            this.m_nudTX1ReflCoeffMagThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudTX1ReflCoeffMagThreshold.Location = new Point(220, 70);
            this.m_nudTX1ReflCoeffMagThreshold.Margin = new Padding(4);
            int[] array21 = new int[4];
            array21[0] = 32767;
            this.m_nudTX1ReflCoeffMagThreshold.Maximum = new decimal(array21);
            this.m_nudTX1ReflCoeffMagThreshold.Minimum = new decimal(new int[]
            {
                32768,
                0,
                0,
                int.MinValue
            });
            this.m_nudTX1ReflCoeffMagThreshold.Name = "m_nudTX1ReflCoeffMagThreshold";
            this.m_nudTX1ReflCoeffMagThreshold.Size = new Size(92, 22);
            this.m_nudTX1ReflCoeffMagThreshold.TabIndex = 31;
            this.m_nudTX1ReflCoeffMagThreshold.Value = new decimal(new int[]
            {
                9,
                0,
                0,
                int.MinValue
            });
            this.label63.AutoSize = true;
            this.label63.Location = new Point(484, 16);
            this.label63.Margin = new Padding(4, 0, 4, 0);
            this.label63.Name = "label63";
            this.label63.Size = new Size(34, 17);
            this.label63.TabIndex = 27;
            this.label63.Text = "TX2";
            this.label64.AutoSize = true;
            this.label64.Location = new Point(363, 16);
            this.label64.Margin = new Padding(4, 0, 4, 0);
            this.label64.Name = "label64";
            this.label64.Size = new Size(34, 17);
            this.label64.TabIndex = 26;
            this.label64.Text = "TX1";
            this.label36.AutoSize = true;
            this.label36.Location = new Point(8, 73);
            this.label36.Margin = new Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new Size(200, 17);
            this.label36.TabIndex = 2;
            this.label36.Text = "Tx Refl Coeff Mag Thresh (dB)";
            this.label35.AutoSize = true;
            this.label35.Location = new Point(8, 41);
            this.label35.Margin = new Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new Size(109, 17);
            this.label35.TabIndex = 1;
            this.label35.Text = "Reporting Mode";
            this.label34.AutoSize = true;
            this.label34.Location = new Point(244, 17);
            this.label34.Margin = new Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new Size(34, 17);
            this.label34.TabIndex = 0;
            this.label34.Text = "TX0";
            this.label57.AutoSize = true;
            this.label57.Location = new Point(4, 36);
            this.label57.Margin = new Padding(4, 0, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new Size(85, 17);
            this.label57.TabIndex = 10;
            this.label57.Text = "Profile Index";
            this.label56.AutoSize = true;
            this.label56.Location = new Point(4, 151);
            this.label56.Margin = new Padding(4, 0, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new Size(109, 17);
            this.label56.TabIndex = 11;
            this.label56.Text = "Reporting Mode";
            this.label55.AutoSize = true;
            this.label55.Location = new Point(4, 180);
            this.label55.Margin = new Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new Size(189, 17);
            this.label55.TabIndex = 12;
            this.label55.Text = "Tx BPM Ph Err Thresh (Deg)";
            this.label54.AutoSize = true;
            this.label54.Location = new Point(4, 209);
            this.label54.Margin = new Padding(4, 0, 4, 0);
            this.label54.Name = "label54";
            this.label54.Size = new Size(191, 17);
            this.label54.TabIndex = 13;
            this.label54.Text = "Tx BPM Amp Err Thresh (dB)";
            this.label53.AutoSize = true;
            this.label53.Location = new Point(223, 14);
            this.label53.Margin = new Padding(4, 0, 4, 0);
            this.label53.Name = "label53";
            this.label53.Size = new Size(34, 17);
            this.label53.TabIndex = 14;
            this.label53.Text = "TX0";
            this.label72.AutoSize = true;
            this.label72.BackColor = SystemColors.Control;
            this.label72.ForeColor = SystemColors.HotTrack;
            this.label72.Location = new Point(467, 10);
            this.label72.Margin = new Padding(4, 0, 4, 0);
            this.label72.Name = "label72";
            this.label72.Size = new Size(109, 17);
            this.label72.TabIndex = 7;
            this.label72.Text = "Reporting Mode";
            this.label77.AutoSize = true;
            this.label77.BackColor = SystemColors.Control;
            this.label77.ForeColor = SystemColors.HotTrack;
            this.label77.Location = new Point(591, 10);
            this.label77.Margin = new Padding(4, 0, 4, 0);
            this.label77.Name = "label77";
            this.label77.Size = new Size(161, 17);
            this.label77.TabIndex = 8;
            this.label77.Text = "VerboseThresholdDis: 0";
            this.label78.AutoSize = true;
            this.label78.BackColor = SystemColors.Control;
            this.label78.ForeColor = SystemColors.HotTrack;
            this.label78.Location = new Point(763, 10);
            this.label78.Margin = new Padding(4, 0, 4, 0);
            this.label78.Name = "label78";
            this.label78.Size = new Size(97, 17);
            this.label78.TabIndex = 9;
            this.label78.Text = "Quiet Mode: 1";
            this.label79.AutoSize = true;
            this.label79.BackColor = SystemColors.Control;
            this.label79.ForeColor = SystemColors.HotTrack;
            this.label79.Location = new Point(869, 10);
            this.label79.Margin = new Padding(4, 0, 4, 0);
            this.label79.Name = "label79";
            this.label79.Size = new Size(158, 17);
            this.label79.TabIndex = 10;
            this.label79.Text = "VerboseThresholdEn: 2";
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_chbTX2BPMMonPhaseShiftIncMonValEna);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_chbTX2BPMMonPhaseShiftMonEna);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_chbTX1BPMMonPhaseShiftIncMonValEna);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_chbTX1BPMMonPhaseShiftMonEna);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_chbTX0BPMMonPhaseShiftIncMonValEna);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_chbTX0BPMMonPhaseShiftMonEna);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f000128);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f000129);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX3BPMPhaseMonPhaseShift2);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX3BPMPhaseMonPhaseShift1);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX3BPMPhaseMonPhaseShiftCfg);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00012a);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00012b);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX2BPMPhaseMonPhaseShift2);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX2BPMPhaseMonPhaseShift1);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX2BPMPhaseMonPhaseShiftCfg);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label75);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00012c);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00012d);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label74);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label73);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label71);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX1BPMPhaseMonPhaseShift2);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX1BPMPhaseMonPhaseShift1);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX1BPMPhaseMonPhaseShiftCfg);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label70);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label69);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label68);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f000121);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f000122);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f000123);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f000124);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00011b);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00011c);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00011d);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00011e);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00011f);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f000120);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f000119);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00011a);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label51);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00010c);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00010d);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.f00010e);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label81);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label80);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX3BPMAmplitudeMonErrorThreshold);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX3BPMPhaseMonErrorThreshold);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX3BPMPhaseMonReportMode);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX3BPMPhaseMonProfileIndex);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX2BPMAmplitudeMonErrorThreshold);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX2BPMPhaseMonErrorThreshold);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX2BPMPhaseMonReportMode);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX2BPMPhaseMonProfileIndex);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX1BPMAmplitudeMonErrorThreshold);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX1BPMPhaseMonErrorThreshold);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX1BPMPhaseMonReportMode);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.m_nudTX1BPMPhaseMonProfileIndex);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label53);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label57);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label54);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label56);
            this.m_grpMonitoringTxBPMPhaseConfig.Controls.Add(this.label55);
            this.m_grpMonitoringTxBPMPhaseConfig.Location = new Point(13, 421);
            this.m_grpMonitoringTxBPMPhaseConfig.Margin = new Padding(4);
            this.m_grpMonitoringTxBPMPhaseConfig.Name = "m_grpMonitoringTxBPMPhaseConfig";
            this.m_grpMonitoringTxBPMPhaseConfig.Padding = new Padding(4);
            this.m_grpMonitoringTxBPMPhaseConfig.Size = new Size(1145, 294);
            this.m_grpMonitoringTxBPMPhaseConfig.TabIndex = 11;
            this.m_grpMonitoringTxBPMPhaseConfig.TabStop = false;
            this.m_grpMonitoringTxBPMPhaseConfig.Text = "Monitoring TX BPM Phase Config";
            this.m_chbTX2BPMMonPhaseShiftIncMonValEna.AutoSize = true;
            this.m_chbTX2BPMMonPhaseShiftIncMonValEna.Location = new Point(949, 110);
            this.m_chbTX2BPMMonPhaseShiftIncMonValEna.Margin = new Padding(4);
            this.m_chbTX2BPMMonPhaseShiftIncMonValEna.Name = "m_chbTX2BPMMonPhaseShiftIncMonValEna";
            this.m_chbTX2BPMMonPhaseShiftIncMonValEna.Size = new Size(158, 21);
            this.m_chbTX2BPMMonPhaseShiftIncMonValEna.TabIndex = 74;
            this.m_chbTX2BPMMonPhaseShiftIncMonValEna.Text = "Ph Shift  Inc Val Ena";
            this.m_chbTX2BPMMonPhaseShiftIncMonValEna.UseVisualStyleBackColor = true;
            this.m_chbTX2BPMMonPhaseShiftMonEna.AutoSize = true;
            this.m_chbTX2BPMMonPhaseShiftMonEna.Location = new Point(949, 84);
            this.m_chbTX2BPMMonPhaseShiftMonEna.Margin = new Padding(4);
            this.m_chbTX2BPMMonPhaseShiftMonEna.Name = "m_chbTX2BPMMonPhaseShiftMonEna";
            this.m_chbTX2BPMMonPhaseShiftMonEna.Size = new Size(139, 21);
            this.m_chbTX2BPMMonPhaseShiftMonEna.TabIndex = 73;
            this.m_chbTX2BPMMonPhaseShiftMonEna.Text = "Ph Shift Mon Ena";
            this.m_chbTX2BPMMonPhaseShiftMonEna.UseVisualStyleBackColor = true;
            this.m_chbTX1BPMMonPhaseShiftIncMonValEna.AutoSize = true;
            this.m_chbTX1BPMMonPhaseShiftIncMonValEna.Location = new Point(608, 114);
            this.m_chbTX1BPMMonPhaseShiftIncMonValEna.Margin = new Padding(4);
            this.m_chbTX1BPMMonPhaseShiftIncMonValEna.Name = "m_chbTX1BPMMonPhaseShiftIncMonValEna";
            this.m_chbTX1BPMMonPhaseShiftIncMonValEna.Size = new Size(158, 21);
            this.m_chbTX1BPMMonPhaseShiftIncMonValEna.TabIndex = 72;
            this.m_chbTX1BPMMonPhaseShiftIncMonValEna.Text = "Ph Shift  Inc Val Ena";
            this.m_chbTX1BPMMonPhaseShiftIncMonValEna.UseVisualStyleBackColor = true;
            this.m_chbTX1BPMMonPhaseShiftMonEna.AutoSize = true;
            this.m_chbTX1BPMMonPhaseShiftMonEna.Location = new Point(608, 89);
            this.m_chbTX1BPMMonPhaseShiftMonEna.Margin = new Padding(4);
            this.m_chbTX1BPMMonPhaseShiftMonEna.Name = "m_chbTX1BPMMonPhaseShiftMonEna";
            this.m_chbTX1BPMMonPhaseShiftMonEna.Size = new Size(139, 21);
            this.m_chbTX1BPMMonPhaseShiftMonEna.TabIndex = 71;
            this.m_chbTX1BPMMonPhaseShiftMonEna.Text = "Ph Shift Mon Ena";
            this.m_chbTX1BPMMonPhaseShiftMonEna.UseVisualStyleBackColor = true;
            this.m_chbTX0BPMMonPhaseShiftIncMonValEna.AutoSize = true;
            this.m_chbTX0BPMMonPhaseShiftIncMonValEna.Location = new Point(304, 113);
            this.m_chbTX0BPMMonPhaseShiftIncMonValEna.Margin = new Padding(4);
            this.m_chbTX0BPMMonPhaseShiftIncMonValEna.Name = "m_chbTX0BPMMonPhaseShiftIncMonValEna";
            this.m_chbTX0BPMMonPhaseShiftIncMonValEna.Size = new Size(158, 21);
            this.m_chbTX0BPMMonPhaseShiftIncMonValEna.TabIndex = 70;
            this.m_chbTX0BPMMonPhaseShiftIncMonValEna.Text = "Ph Shift  Inc Val Ena";
            this.m_chbTX0BPMMonPhaseShiftIncMonValEna.UseVisualStyleBackColor = true;
            this.m_chbTX0BPMMonPhaseShiftMonEna.AutoSize = true;
            this.m_chbTX0BPMMonPhaseShiftMonEna.Location = new Point(304, 85);
            this.m_chbTX0BPMMonPhaseShiftMonEna.Margin = new Padding(4);
            this.m_chbTX0BPMMonPhaseShiftMonEna.Name = "m_chbTX0BPMMonPhaseShiftMonEna";
            this.m_chbTX0BPMMonPhaseShiftMonEna.Size = new Size(139, 21);
            this.m_chbTX0BPMMonPhaseShiftMonEna.TabIndex = 69;
            this.m_chbTX0BPMMonPhaseShiftMonEna.Text = "Ph Shift Mon Ena";
            this.m_chbTX0BPMMonPhaseShiftMonEna.UseVisualStyleBackColor = true;
            this.f000128.DecimalPlaces = 3;
            this.f000128.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.f000128.Location = new Point(847, 265);
            this.f000128.Margin = new Padding(4);
            int[] array22 = new int[4];
            array22[0] = 360;
            this.f000128.Maximum = new decimal(array22);
            this.f000128.Name = "m_nudTX3BPMTxPhaseShiftThreshold2";
            this.f000128.Size = new Size(81, 22);
            this.f000128.TabIndex = 68;
            this.f000129.DecimalPlaces = 3;
            this.f000129.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.f000129.Location = new Point(847, 236);
            this.f000129.Margin = new Padding(4);
            int[] array23 = new int[4];
            array23[0] = 360;
            this.f000129.Maximum = new decimal(array23);
            this.f000129.Name = "m_nudTX3BPMTxPhaseShiftThreshold1";
            this.f000129.Size = new Size(81, 22);
            this.f000129.TabIndex = 67;
            this.m_nudTX3BPMPhaseMonPhaseShift2.DecimalPlaces = 3;
            this.m_nudTX3BPMPhaseMonPhaseShift2.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTX3BPMPhaseMonPhaseShift2.Location = new Point(847, 119);
            this.m_nudTX3BPMPhaseMonPhaseShift2.Margin = new Padding(4);
            int[] array24 = new int[4];
            array24[0] = 360;
            this.m_nudTX3BPMPhaseMonPhaseShift2.Maximum = new decimal(array24);
            this.m_nudTX3BPMPhaseMonPhaseShift2.Name = "m_nudTX3BPMPhaseMonPhaseShift2";
            this.m_nudTX3BPMPhaseMonPhaseShift2.Size = new Size(81, 22);
            this.m_nudTX3BPMPhaseMonPhaseShift2.TabIndex = 66;
            this.m_nudTX3BPMPhaseMonPhaseShift2.ValueChanged += this.m_nudTx2BPMPhaseShifter2Const_ValueChanged;
            this.m_nudTX3BPMPhaseMonPhaseShift1.DecimalPlaces = 3;
            this.m_nudTX3BPMPhaseMonPhaseShift1.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTX3BPMPhaseMonPhaseShift1.Location = new Point(847, 91);
            this.m_nudTX3BPMPhaseMonPhaseShift1.Margin = new Padding(4);
            int[] array25 = new int[4];
            array25[0] = 360;
            this.m_nudTX3BPMPhaseMonPhaseShift1.Maximum = new decimal(array25);
            this.m_nudTX3BPMPhaseMonPhaseShift1.Name = "m_nudTX3BPMPhaseMonPhaseShift1";
            this.m_nudTX3BPMPhaseMonPhaseShift1.Size = new Size(81, 22);
            this.m_nudTX3BPMPhaseMonPhaseShift1.TabIndex = 65;
            this.m_nudTX3BPMPhaseMonPhaseShift1.ValueChanged += this.m_nudTx2BPMPhaseShifter1Const_ValueChanged;
            this.m_nudTX3BPMPhaseMonPhaseShiftCfg.DecimalPlaces = 3;
            this.m_nudTX3BPMPhaseMonPhaseShiftCfg.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTX3BPMPhaseMonPhaseShiftCfg.Location = new Point(847, 63);
            this.m_nudTX3BPMPhaseMonPhaseShiftCfg.Margin = new Padding(4);
            int[] array26 = new int[4];
            array26[0] = 360;
            this.m_nudTX3BPMPhaseMonPhaseShiftCfg.Maximum = new decimal(array26);
            this.m_nudTX3BPMPhaseMonPhaseShiftCfg.Name = "m_nudTX3BPMPhaseMonPhaseShiftCfg";
            this.m_nudTX3BPMPhaseMonPhaseShiftCfg.Size = new Size(81, 22);
            this.m_nudTX3BPMPhaseMonPhaseShiftCfg.TabIndex = 64;
            this.m_nudTX3BPMPhaseMonPhaseShiftCfg.ValueChanged += this.m_nudTx2BPMPhaseShifterIncConst_ValueChanged;
            this.f00012a.DecimalPlaces = 3;
            this.f00012a.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.f00012a.Location = new Point(500, 265);
            this.f00012a.Margin = new Padding(4);
            int[] array27 = new int[4];
            array27[0] = 360;
            this.f00012a.Maximum = new decimal(array27);
            this.f00012a.Name = "m_nudTX2BPMTxPhaseShiftThreshold2";
            this.f00012a.Size = new Size(81, 22);
            this.f00012a.TabIndex = 63;
            this.f00012b.DecimalPlaces = 3;
            this.f00012b.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.f00012b.Location = new Point(500, 236);
            this.f00012b.Margin = new Padding(4);
            int[] array28 = new int[4];
            array28[0] = 360;
            this.f00012b.Maximum = new decimal(array28);
            this.f00012b.Name = "m_nudTX2BPMTxPhaseShiftThreshold1";
            this.f00012b.Size = new Size(81, 22);
            this.f00012b.TabIndex = 62;
            this.m_nudTX2BPMPhaseMonPhaseShift2.DecimalPlaces = 3;
            this.m_nudTX2BPMPhaseMonPhaseShift2.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTX2BPMPhaseMonPhaseShift2.Location = new Point(500, 119);
            this.m_nudTX2BPMPhaseMonPhaseShift2.Margin = new Padding(4);
            int[] array29 = new int[4];
            array29[0] = 360;
            this.m_nudTX2BPMPhaseMonPhaseShift2.Maximum = new decimal(array29);
            this.m_nudTX2BPMPhaseMonPhaseShift2.Name = "m_nudTX2BPMPhaseMonPhaseShift2";
            this.m_nudTX2BPMPhaseMonPhaseShift2.Size = new Size(81, 22);
            this.m_nudTX2BPMPhaseMonPhaseShift2.TabIndex = 61;
            this.m_nudTX2BPMPhaseMonPhaseShift2.ValueChanged += this.m_nudTx1BPMPhaseShifter2Const_ValueChanged;
            this.m_nudTX2BPMPhaseMonPhaseShift1.DecimalPlaces = 3;
            this.m_nudTX2BPMPhaseMonPhaseShift1.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTX2BPMPhaseMonPhaseShift1.Location = new Point(500, 91);
            this.m_nudTX2BPMPhaseMonPhaseShift1.Margin = new Padding(4);
            int[] array30 = new int[4];
            array30[0] = 360;
            this.m_nudTX2BPMPhaseMonPhaseShift1.Maximum = new decimal(array30);
            this.m_nudTX2BPMPhaseMonPhaseShift1.Name = "m_nudTX2BPMPhaseMonPhaseShift1";
            this.m_nudTX2BPMPhaseMonPhaseShift1.Size = new Size(81, 22);
            this.m_nudTX2BPMPhaseMonPhaseShift1.TabIndex = 60;
            this.m_nudTX2BPMPhaseMonPhaseShift1.ValueChanged += this.m_nudTx0BPMPhaseShifter1Const_ValueChanged;
            this.m_nudTX2BPMPhaseMonPhaseShiftCfg.DecimalPlaces = 3;
            this.m_nudTX2BPMPhaseMonPhaseShiftCfg.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTX2BPMPhaseMonPhaseShiftCfg.Location = new Point(500, 63);
            this.m_nudTX2BPMPhaseMonPhaseShiftCfg.Margin = new Padding(4);
            int[] array31 = new int[4];
            array31[0] = 360;
            this.m_nudTX2BPMPhaseMonPhaseShiftCfg.Maximum = new decimal(array31);
            this.m_nudTX2BPMPhaseMonPhaseShiftCfg.Name = "m_nudTX2BPMPhaseMonPhaseShiftCfg";
            this.m_nudTX2BPMPhaseMonPhaseShiftCfg.Size = new Size(81, 22);
            this.m_nudTX2BPMPhaseMonPhaseShiftCfg.TabIndex = 59;
            this.m_nudTX2BPMPhaseMonPhaseShiftCfg.ValueChanged += this.m_nudTx1BPMPhaseShifterIncConst_ValueChanged;
            this.label75.AutoSize = true;
            this.label75.Location = new Point(972, 12);
            this.label75.Margin = new Padding(4, 0, 4, 0);
            this.label75.Name = "label75";
            this.label75.Size = new Size(53, 17);
            this.label75.TabIndex = 57;
            this.label75.Text = "Rx Ena";
            this.f00012c.DecimalPlaces = 3;
            this.f00012c.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.f00012c.Location = new Point(204, 263);
            this.f00012c.Margin = new Padding(4);
            int[] array32 = new int[4];
            array32[0] = 360;
            this.f00012c.Maximum = new decimal(array32);
            this.f00012c.Name = "m_nudTX1BPMTxPhaseShiftThreshold2";
            this.f00012c.Size = new Size(81, 22);
            this.f00012c.TabIndex = 56;
            this.f00012d.DecimalPlaces = 3;
            this.f00012d.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.f00012d.Location = new Point(204, 235);
            this.f00012d.Margin = new Padding(4);
            int[] array33 = new int[4];
            array33[0] = 360;
            this.f00012d.Maximum = new decimal(array33);
            this.f00012d.Name = "m_nudTX1BPMTxPhaseShiftThreshold1";
            this.f00012d.Size = new Size(81, 22);
            this.f00012d.TabIndex = 55;
            this.f00012d.ValueChanged += this.m_nudTX1BPMTxPhaseShiftThreshold1_ValueChanged;
            this.label74.AutoSize = true;
            this.label74.Location = new Point(4, 268);
            this.label74.Margin = new Padding(4, 0, 4, 0);
            this.label74.Name = "label74";
            this.label74.Size = new Size(191, 17);
            this.label74.TabIndex = 54;
            this.label74.Text = "Tx Ph Shfit Thresh Min (Deg)";
            this.label73.AutoSize = true;
            this.label73.Location = new Point(4, 238);
            this.label73.Margin = new Padding(4, 0, 4, 0);
            this.label73.Name = "label73";
            this.label73.Size = new Size(194, 17);
            this.label73.TabIndex = 53;
            this.label73.Text = "Tx Ph Shfit Thresh Max (Deg)";
            this.label71.AutoSize = true;
            this.label71.Location = new Point(601, 17);
            this.label71.Margin = new Padding(4, 0, 4, 0);
            this.label71.Name = "label71";
            this.label71.Size = new Size(53, 17);
            this.label71.TabIndex = 52;
            this.label71.Text = "Rx Ena";
            this.m_nudTX1BPMPhaseMonPhaseShift2.DecimalPlaces = 3;
            this.m_nudTX1BPMPhaseMonPhaseShift2.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTX1BPMPhaseMonPhaseShift2.Location = new Point(204, 118);
            this.m_nudTX1BPMPhaseMonPhaseShift2.Margin = new Padding(4);
            int[] array34 = new int[4];
            array34[0] = 360;
            this.m_nudTX1BPMPhaseMonPhaseShift2.Maximum = new decimal(array34);
            this.m_nudTX1BPMPhaseMonPhaseShift2.Name = "m_nudTX1BPMPhaseMonPhaseShift2";
            this.m_nudTX1BPMPhaseMonPhaseShift2.Size = new Size(81, 22);
            this.m_nudTX1BPMPhaseMonPhaseShift2.TabIndex = 51;
            this.m_nudTX1BPMPhaseMonPhaseShift2.ValueChanged += this.m_nudTx0BPMPhaseShifter2Const_ValueChanged;
            this.m_nudTX1BPMPhaseMonPhaseShift1.DecimalPlaces = 3;
            this.m_nudTX1BPMPhaseMonPhaseShift1.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTX1BPMPhaseMonPhaseShift1.Location = new Point(204, 90);
            this.m_nudTX1BPMPhaseMonPhaseShift1.Margin = new Padding(4);
            int[] array35 = new int[4];
            array35[0] = 360;
            this.m_nudTX1BPMPhaseMonPhaseShift1.Maximum = new decimal(array35);
            this.m_nudTX1BPMPhaseMonPhaseShift1.Name = "m_nudTX1BPMPhaseMonPhaseShift1";
            this.m_nudTX1BPMPhaseMonPhaseShift1.Size = new Size(81, 22);
            this.m_nudTX1BPMPhaseMonPhaseShift1.TabIndex = 50;
            this.m_nudTX1BPMPhaseMonPhaseShift1.ValueChanged += this.m_nudPhaseShifter1Const_ValueChanged;
            this.m_nudTX1BPMPhaseMonPhaseShiftCfg.DecimalPlaces = 3;
            this.m_nudTX1BPMPhaseMonPhaseShiftCfg.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTX1BPMPhaseMonPhaseShiftCfg.Location = new Point(204, 62);
            this.m_nudTX1BPMPhaseMonPhaseShiftCfg.Margin = new Padding(4);
            int[] array36 = new int[4];
            array36[0] = 360;
            this.m_nudTX1BPMPhaseMonPhaseShiftCfg.Maximum = new decimal(array36);
            this.m_nudTX1BPMPhaseMonPhaseShiftCfg.Name = "m_nudTX1BPMPhaseMonPhaseShiftCfg";
            this.m_nudTX1BPMPhaseMonPhaseShiftCfg.Size = new Size(81, 22);
            this.m_nudTX1BPMPhaseMonPhaseShiftCfg.TabIndex = 49;
            this.m_nudTX1BPMPhaseMonPhaseShiftCfg.ValueChanged += this.m_nudTx0BPMPhaseShifterIncConst_ValueChanged;
            this.label70.AutoSize = true;
            this.label70.Location = new Point(4, 123);
            this.label70.Margin = new Padding(4, 0, 4, 0);
            this.label70.Name = "label70";
            this.label70.Size = new Size(105, 17);
            this.label70.TabIndex = 48;
            this.label70.Text = "Ph Shift2 (Deg)";
            this.label69.AutoSize = true;
            this.label69.Location = new Point(4, 97);
            this.label69.Margin = new Padding(4, 0, 4, 0);
            this.label69.Name = "label69";
            this.label69.Size = new Size(105, 17);
            this.label69.TabIndex = 47;
            this.label69.Text = "Ph Shift1 (Deg)";
            this.label68.AutoSize = true;
            this.label68.Location = new Point(4, 66);
            this.label68.Margin = new Padding(4, 0, 4, 0);
            this.label68.Name = "label68";
            this.label68.Size = new Size(168, 17);
            this.label68.TabIndex = 46;
            this.label68.Text = "Ph Shift Cfg Inc Val (Deg)";
            this.f000121.AutoSize = true;
            this.f000121.Location = new Point(1016, 58);
            this.f000121.Margin = new Padding(4);
            this.f000121.Name = "m_chbTX2BPMMonRx3";
            this.f000121.Size = new Size(54, 21);
            this.f000121.TabIndex = 43;
            this.f000121.Text = "Rx3";
            this.f000121.UseVisualStyleBackColor = true;
            this.f000122.AutoSize = true;
            this.f000122.Location = new Point(1016, 33);
            this.f000122.Margin = new Padding(4);
            this.f000122.Name = "m_chbTX2BPMMonRx1";
            this.f000122.Size = new Size(54, 21);
            this.f000122.TabIndex = 42;
            this.f000122.Text = "Rx1";
            this.f000122.UseVisualStyleBackColor = true;
            this.f000123.AutoSize = true;
            this.f000123.Location = new Point(949, 33);
            this.f000123.Margin = new Padding(4);
            this.f000123.Name = "m_chbTX2BPMMonRx0";
            this.f000123.Size = new Size(54, 21);
            this.f000123.TabIndex = 41;
            this.f000123.Text = "Rx0";
            this.f000123.UseVisualStyleBackColor = true;
            this.f000124.AutoSize = true;
            this.f000124.Location = new Point(949, 58);
            this.f000124.Margin = new Padding(4);
            this.f000124.Name = "m_chbTX2BPMMonRx2";
            this.f000124.Size = new Size(54, 21);
            this.f000124.TabIndex = 40;
            this.f000124.Text = "Rx2";
            this.f000124.UseVisualStyleBackColor = true;
            this.f00011b.AutoSize = true;
            this.f00011b.Location = new Point(672, 63);
            this.f00011b.Margin = new Padding(4);
            this.f00011b.Name = "m_chbTX1BPMMonRx3";
            this.f00011b.Size = new Size(54, 21);
            this.f00011b.TabIndex = 39;
            this.f00011b.Text = "Rx3";
            this.f00011b.UseVisualStyleBackColor = true;
            this.f00011c.AutoSize = true;
            this.f00011c.Location = new Point(360, 57);
            this.f00011c.Margin = new Padding(4);
            this.f00011c.Name = "m_chbTX0BPMMonRx3";
            this.f00011c.Size = new Size(54, 21);
            this.f00011c.TabIndex = 38;
            this.f00011c.Text = "Rx3";
            this.f00011c.UseVisualStyleBackColor = true;
            this.f00011d.AutoSize = true;
            this.f00011d.Location = new Point(672, 37);
            this.f00011d.Margin = new Padding(4);
            this.f00011d.Name = "m_chbTX1BPMMonRx1";
            this.f00011d.Size = new Size(54, 21);
            this.f00011d.TabIndex = 37;
            this.f00011d.Text = "Rx1";
            this.f00011d.UseVisualStyleBackColor = true;
            this.f00011e.AutoSize = true;
            this.f00011e.Location = new Point(608, 37);
            this.f00011e.Margin = new Padding(4);
            this.f00011e.Name = "m_chbTX1BPMMonRx0";
            this.f00011e.Size = new Size(54, 21);
            this.f00011e.TabIndex = 36;
            this.f00011e.Text = "Rx0";
            this.f00011e.UseVisualStyleBackColor = true;
            this.f00011f.AutoSize = true;
            this.f00011f.Location = new Point(608, 63);
            this.f00011f.Margin = new Padding(4);
            this.f00011f.Name = "m_chbTX1BPMMonRx2";
            this.f00011f.Size = new Size(54, 21);
            this.f00011f.TabIndex = 35;
            this.f00011f.Text = "Rx2";
            this.f00011f.UseVisualStyleBackColor = true;
            this.f000120.AutoSize = true;
            this.f000120.Location = new Point(304, 57);
            this.f000120.Margin = new Padding(4);
            this.f000120.Name = "m_chbTX0BPMMonRx2";
            this.f000120.Size = new Size(54, 21);
            this.f000120.TabIndex = 34;
            this.f000120.Text = "Rx2";
            this.f000120.UseVisualStyleBackColor = true;
            this.f000119.AutoSize = true;
            this.f000119.Location = new Point(360, 33);
            this.f000119.Margin = new Padding(4);
            this.f000119.Name = "m_chbTX0BPMMonRx1";
            this.f000119.Size = new Size(54, 21);
            this.f000119.TabIndex = 33;
            this.f000119.Text = "Rx1";
            this.f000119.UseVisualStyleBackColor = true;
            this.f00011a.AutoSize = true;
            this.f00011a.Location = new Point(304, 33);
            this.f00011a.Margin = new Padding(4);
            this.f00011a.Name = "m_chbTX0BPMMonRx0";
            this.f00011a.Size = new Size(54, 21);
            this.f00011a.TabIndex = 32;
            this.f00011a.Text = "Rx0";
            this.f00011a.UseVisualStyleBackColor = true;
            this.label51.AutoSize = true;
            this.label51.Location = new Point(308, 15);
            this.label51.Margin = new Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new Size(53, 17);
            this.label51.TabIndex = 31;
            this.label51.Text = "Rx Ena";
            this.f00010c.Location = new Point(312, 252);
            this.f00010c.Margin = new Padding(4);
            this.f00010c.Name = "m_btnTX1BPMPhaseMonConfigSet";
            this.f00010c.Size = new Size(73, 28);
            this.f00010c.TabIndex = 30;
            this.f00010c.Text = "Set";
            this.f00010c.UseVisualStyleBackColor = true;
            this.f00010c.Click += this.m_btnTX1BPMPhaseMonConfigSet_Click;
            this.f00010d.Location = new Point(625, 257);
            this.f00010d.Margin = new Padding(4);
            this.f00010d.Name = "m_btnTX2BPMPhaseMonConfigSet";
            this.f00010d.Size = new Size(73, 28);
            this.f00010d.TabIndex = 29;
            this.f00010d.Text = "Set";
            this.f00010d.UseVisualStyleBackColor = true;
            this.f00010d.Click += this.m_btnTX2BPMPhaseMonConfigSet_Click;
            this.f00010e.Location = new Point(987, 257);
            this.f00010e.Margin = new Padding(4);
            this.f00010e.Name = "m_btnTX3BPMPhaseMonConfigSet";
            this.f00010e.Size = new Size(73, 28);
            this.f00010e.TabIndex = 28;
            this.f00010e.Text = "Set";
            this.f00010e.UseVisualStyleBackColor = true;
            this.f00010e.Click += this.m_btnTX3BPMPhaseMonConfigSet_Click;
            this.label81.AutoSize = true;
            this.label81.Location = new Point(857, 16);
            this.label81.Margin = new Padding(4, 0, 4, 0);
            this.label81.Name = "label81";
            this.label81.Size = new Size(34, 17);
            this.label81.TabIndex = 27;
            this.label81.Text = "TX2";
            this.label80.AutoSize = true;
            this.label80.Location = new Point(508, 16);
            this.label80.Margin = new Padding(4, 0, 4, 0);
            this.label80.Name = "label80";
            this.label80.Size = new Size(34, 17);
            this.label80.TabIndex = 26;
            this.label80.Text = "TX1";
            this.m_nudTX3BPMAmplitudeMonErrorThreshold.DecimalPlaces = 2;
            this.m_nudTX3BPMAmplitudeMonErrorThreshold.Location = new Point(847, 208);
            this.m_nudTX3BPMAmplitudeMonErrorThreshold.Margin = new Padding(4);
            int[] array37 = new int[4];
            array37[0] = 12;
            this.m_nudTX3BPMAmplitudeMonErrorThreshold.Maximum = new decimal(array37);
            this.m_nudTX3BPMAmplitudeMonErrorThreshold.Name = "m_nudTX3BPMAmplitudeMonErrorThreshold";
            this.m_nudTX3BPMAmplitudeMonErrorThreshold.Size = new Size(81, 22);
            this.m_nudTX3BPMAmplitudeMonErrorThreshold.TabIndex = 25;
            this.m_nudTX3BPMPhaseMonErrorThreshold.DecimalPlaces = 2;
            this.m_nudTX3BPMPhaseMonErrorThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudTX3BPMPhaseMonErrorThreshold.Location = new Point(847, 177);
            this.m_nudTX3BPMPhaseMonErrorThreshold.Margin = new Padding(4);
            int[] array38 = new int[4];
            array38[0] = 360;
            this.m_nudTX3BPMPhaseMonErrorThreshold.Maximum = new decimal(array38);
            this.m_nudTX3BPMPhaseMonErrorThreshold.Name = "m_nudTX3BPMPhaseMonErrorThreshold";
            this.m_nudTX3BPMPhaseMonErrorThreshold.Size = new Size(81, 22);
            this.m_nudTX3BPMPhaseMonErrorThreshold.TabIndex = 24;
            this.m_nudTX3BPMPhaseMonReportMode.Location = new Point(847, 148);
            this.m_nudTX3BPMPhaseMonReportMode.Margin = new Padding(4);
            int[] array39 = new int[4];
            array39[0] = 2;
            this.m_nudTX3BPMPhaseMonReportMode.Maximum = new decimal(array39);
            this.m_nudTX3BPMPhaseMonReportMode.Name = "m_nudTX3BPMPhaseMonReportMode";
            this.m_nudTX3BPMPhaseMonReportMode.Size = new Size(81, 22);
            this.m_nudTX3BPMPhaseMonReportMode.TabIndex = 23;
            this.m_nudTX3BPMPhaseMonProfileIndex.Location = new Point(847, 37);
            this.m_nudTX3BPMPhaseMonProfileIndex.Margin = new Padding(4);
            int[] array40 = new int[4];
            array40[0] = 3;
            this.m_nudTX3BPMPhaseMonProfileIndex.Maximum = new decimal(array40);
            this.m_nudTX3BPMPhaseMonProfileIndex.Name = "m_nudTX3BPMPhaseMonProfileIndex";
            this.m_nudTX3BPMPhaseMonProfileIndex.Size = new Size(81, 22);
            this.m_nudTX3BPMPhaseMonProfileIndex.TabIndex = 22;
            this.m_nudTX2BPMAmplitudeMonErrorThreshold.DecimalPlaces = 2;
            this.m_nudTX2BPMAmplitudeMonErrorThreshold.Location = new Point(500, 208);
            this.m_nudTX2BPMAmplitudeMonErrorThreshold.Margin = new Padding(4);
            int[] array41 = new int[4];
            array41[0] = 12;
            this.m_nudTX2BPMAmplitudeMonErrorThreshold.Maximum = new decimal(array41);
            this.m_nudTX2BPMAmplitudeMonErrorThreshold.Name = "m_nudTX2BPMAmplitudeMonErrorThreshold";
            this.m_nudTX2BPMAmplitudeMonErrorThreshold.Size = new Size(81, 22);
            this.m_nudTX2BPMAmplitudeMonErrorThreshold.TabIndex = 21;
            this.m_nudTX2BPMPhaseMonErrorThreshold.DecimalPlaces = 2;
            this.m_nudTX2BPMPhaseMonErrorThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudTX2BPMPhaseMonErrorThreshold.Location = new Point(500, 177);
            this.m_nudTX2BPMPhaseMonErrorThreshold.Margin = new Padding(4);
            int[] array42 = new int[4];
            array42[0] = 360;
            this.m_nudTX2BPMPhaseMonErrorThreshold.Maximum = new decimal(array42);
            this.m_nudTX2BPMPhaseMonErrorThreshold.Name = "m_nudTX2BPMPhaseMonErrorThreshold";
            this.m_nudTX2BPMPhaseMonErrorThreshold.Size = new Size(81, 22);
            this.m_nudTX2BPMPhaseMonErrorThreshold.TabIndex = 20;
            this.m_nudTX2BPMPhaseMonReportMode.Location = new Point(500, 148);
            this.m_nudTX2BPMPhaseMonReportMode.Margin = new Padding(4);
            int[] array43 = new int[4];
            array43[0] = 2;
            this.m_nudTX2BPMPhaseMonReportMode.Maximum = new decimal(array43);
            this.m_nudTX2BPMPhaseMonReportMode.Name = "m_nudTX2BPMPhaseMonReportMode";
            this.m_nudTX2BPMPhaseMonReportMode.Size = new Size(81, 22);
            this.m_nudTX2BPMPhaseMonReportMode.TabIndex = 19;
            this.m_nudTX2BPMPhaseMonProfileIndex.Location = new Point(500, 34);
            this.m_nudTX2BPMPhaseMonProfileIndex.Margin = new Padding(4);
            int[] array44 = new int[4];
            array44[0] = 3;
            this.m_nudTX2BPMPhaseMonProfileIndex.Maximum = new decimal(array44);
            this.m_nudTX2BPMPhaseMonProfileIndex.Name = "m_nudTX2BPMPhaseMonProfileIndex";
            this.m_nudTX2BPMPhaseMonProfileIndex.Size = new Size(81, 22);
            this.m_nudTX2BPMPhaseMonProfileIndex.TabIndex = 18;
            this.m_nudTX1BPMAmplitudeMonErrorThreshold.DecimalPlaces = 2;
            this.m_nudTX1BPMAmplitudeMonErrorThreshold.Location = new Point(204, 207);
            this.m_nudTX1BPMAmplitudeMonErrorThreshold.Margin = new Padding(4);
            int[] array45 = new int[4];
            array45[0] = 12;
            this.m_nudTX1BPMAmplitudeMonErrorThreshold.Maximum = new decimal(array45);
            this.m_nudTX1BPMAmplitudeMonErrorThreshold.Name = "m_nudTX1BPMAmplitudeMonErrorThreshold";
            this.m_nudTX1BPMAmplitudeMonErrorThreshold.Size = new Size(81, 22);
            this.m_nudTX1BPMAmplitudeMonErrorThreshold.TabIndex = 17;
            this.m_nudTX1BPMPhaseMonErrorThreshold.DecimalPlaces = 2;
            this.m_nudTX1BPMPhaseMonErrorThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudTX1BPMPhaseMonErrorThreshold.Location = new Point(204, 176);
            this.m_nudTX1BPMPhaseMonErrorThreshold.Margin = new Padding(4);
            int[] array46 = new int[4];
            array46[0] = 360;
            this.m_nudTX1BPMPhaseMonErrorThreshold.Maximum = new decimal(array46);
            this.m_nudTX1BPMPhaseMonErrorThreshold.Name = "m_nudTX1BPMPhaseMonErrorThreshold";
            this.m_nudTX1BPMPhaseMonErrorThreshold.Size = new Size(81, 22);
            this.m_nudTX1BPMPhaseMonErrorThreshold.TabIndex = 16;
            this.m_nudTX1BPMPhaseMonReportMode.Location = new Point(204, 146);
            this.m_nudTX1BPMPhaseMonReportMode.Margin = new Padding(4);
            int[] array47 = new int[4];
            array47[0] = 2;
            this.m_nudTX1BPMPhaseMonReportMode.Maximum = new decimal(array47);
            this.m_nudTX1BPMPhaseMonReportMode.Name = "m_nudTX1BPMPhaseMonReportMode";
            this.m_nudTX1BPMPhaseMonReportMode.Size = new Size(81, 22);
            this.m_nudTX1BPMPhaseMonReportMode.TabIndex = 15;
            this.m_nudTX1BPMPhaseMonProfileIndex.Location = new Point(204, 32);
            this.m_nudTX1BPMPhaseMonProfileIndex.Margin = new Padding(4);
            int[] array48 = new int[4];
            array48[0] = 3;
            this.m_nudTX1BPMPhaseMonProfileIndex.Maximum = new decimal(array48);
            this.m_nudTX1BPMPhaseMonProfileIndex.Name = "m_nudTX1BPMPhaseMonProfileIndex";
            this.m_nudTX1BPMPhaseMonProfileIndex.Size = new Size(81, 22);
            this.m_nudTX1BPMPhaseMonProfileIndex.TabIndex = 14;
            this.groupBox1.Controls.Add(this.m_chbTXGainPhaseMismatchMonRx3);
            this.groupBox1.Controls.Add(this.m_chbTXGainPhaseMismatchMonRx2);
            this.groupBox1.Controls.Add(this.m_chbTXGainPhaseMismatchMonRx1);
            this.groupBox1.Controls.Add(this.m_chbTXGainPhaseMismatchMonRx0);
            this.groupBox1.Controls.Add(this.label50);
            this.groupBox1.Controls.Add(this.m_btnTXGainPhaseMismatchMonConfigSet);
            this.groupBox1.Controls.Add(this.label102);
            this.groupBox1.Controls.Add(this.label101);
            this.groupBox1.Controls.Add(this.label100);
            this.groupBox1.Controls.Add(this.label99);
            this.groupBox1.Controls.Add(this.label98);
            this.groupBox1.Controls.Add(this.label97);
            this.groupBox1.Controls.Add(this.label96);
            this.groupBox1.Controls.Add(this.label95);
            this.groupBox1.Controls.Add(this.label94);
            this.groupBox1.Controls.Add(this.label93);
            this.groupBox1.Controls.Add(this.label92);
            this.groupBox1.Controls.Add(this.label91);
            this.groupBox1.Controls.Add(this.m_nudRF1TX3TXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1TX2TXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1TX1TXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3TX3TXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3TX2TXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3TX1TXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2TX3TXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2TX2TXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2TX1TXPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3TX3TXGainPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3TX2TXGainPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF3TX1TXGainPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2TX3TXGainPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2TX2TXGainPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF2TX1TXGainPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1TX3TXGainPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudRF1TX2TXGainPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.label90);
            this.groupBox1.Controls.Add(this.m_nudRF1TX1TXGainPhaseMismatchOffVal);
            this.groupBox1.Controls.Add(this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold);
            this.groupBox1.Controls.Add(this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold);
            this.groupBox1.Controls.Add(this.m_nudTxGainPhaseMismacthMonReportingMode);
            this.groupBox1.Controls.Add(this.m_chbTXGainPhaseMismatchMonTx3);
            this.groupBox1.Controls.Add(this.m_chbTXGainPhaseMismatchMonTx2);
            this.groupBox1.Controls.Add(this.m_chbTXGainPhaseMismatchMonTx1);
            this.groupBox1.Controls.Add(this.m_chbRF3TXGainPhaseMismatchMonBitMask);
            this.groupBox1.Controls.Add(this.m_chbRF2TXGainPhaseMismatchMonBitMask);
            this.groupBox1.Controls.Add(this.m_chbRF1TXGainPhaseMismatchMonBitMask);
            this.groupBox1.Controls.Add(this.m_nudTxGainPhaseMismacthMonProfileIndex);
            this.groupBox1.Controls.Add(this.label86);
            this.groupBox1.Controls.Add(this.label87);
            this.groupBox1.Controls.Add(this.label88);
            this.groupBox1.Controls.Add(this.label89);
            this.groupBox1.Controls.Add(this.label85);
            this.groupBox1.Controls.Add(this.label84);
            this.groupBox1.Controls.Add(this.label83);
            this.groupBox1.Controls.Add(this.label82);
            this.groupBox1.Location = new Point(1167, 410);
            this.groupBox1.Margin = new Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new Padding(4);
            this.groupBox1.Size = new Size(630, 295);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monitoring TX Gain Phase Mismatch Config";
            this.m_chbTXGainPhaseMismatchMonRx3.AutoSize = true;
            this.m_chbTXGainPhaseMismatchMonRx3.Location = new Point(316, 103);
            this.m_chbTXGainPhaseMismatchMonRx3.Margin = new Padding(4);
            this.m_chbTXGainPhaseMismatchMonRx3.Name = "m_chbTXGainPhaseMismatchMonRx3";
            this.m_chbTXGainPhaseMismatchMonRx3.Size = new Size(54, 21);
            this.m_chbTXGainPhaseMismatchMonRx3.TabIndex = 55;
            this.m_chbTXGainPhaseMismatchMonRx3.Text = "Rx3";
            this.m_chbTXGainPhaseMismatchMonRx3.UseVisualStyleBackColor = true;
            this.m_chbTXGainPhaseMismatchMonRx2.AutoSize = true;
            this.m_chbTXGainPhaseMismatchMonRx2.Location = new Point(257, 103);
            this.m_chbTXGainPhaseMismatchMonRx2.Margin = new Padding(4);
            this.m_chbTXGainPhaseMismatchMonRx2.Name = "m_chbTXGainPhaseMismatchMonRx2";
            this.m_chbTXGainPhaseMismatchMonRx2.Size = new Size(54, 21);
            this.m_chbTXGainPhaseMismatchMonRx2.TabIndex = 54;
            this.m_chbTXGainPhaseMismatchMonRx2.Text = "Rx2";
            this.m_chbTXGainPhaseMismatchMonRx2.UseVisualStyleBackColor = true;
            this.m_chbTXGainPhaseMismatchMonRx1.AutoSize = true;
            this.m_chbTXGainPhaseMismatchMonRx1.Location = new Point(199, 103);
            this.m_chbTXGainPhaseMismatchMonRx1.Margin = new Padding(4);
            this.m_chbTXGainPhaseMismatchMonRx1.Name = "m_chbTXGainPhaseMismatchMonRx1";
            this.m_chbTXGainPhaseMismatchMonRx1.Size = new Size(54, 21);
            this.m_chbTXGainPhaseMismatchMonRx1.TabIndex = 53;
            this.m_chbTXGainPhaseMismatchMonRx1.Text = "Rx1";
            this.m_chbTXGainPhaseMismatchMonRx1.UseVisualStyleBackColor = true;
            this.m_chbTXGainPhaseMismatchMonRx0.AutoSize = true;
            this.m_chbTXGainPhaseMismatchMonRx0.Location = new Point(144, 103);
            this.m_chbTXGainPhaseMismatchMonRx0.Margin = new Padding(4);
            this.m_chbTXGainPhaseMismatchMonRx0.Name = "m_chbTXGainPhaseMismatchMonRx0";
            this.m_chbTXGainPhaseMismatchMonRx0.Size = new Size(54, 21);
            this.m_chbTXGainPhaseMismatchMonRx0.TabIndex = 52;
            this.m_chbTXGainPhaseMismatchMonRx0.Text = "Rx0";
            this.m_chbTXGainPhaseMismatchMonRx0.UseVisualStyleBackColor = true;
            this.label50.AutoSize = true;
            this.label50.Location = new Point(4, 102);
            this.label50.Margin = new Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new Size(53, 17);
            this.label50.TabIndex = 51;
            this.label50.Text = "Rx Ena";
            this.m_btnTXGainPhaseMismatchMonConfigSet.Location = new Point(545, 265);
            this.m_btnTXGainPhaseMismatchMonConfigSet.Margin = new Padding(4);
            this.m_btnTXGainPhaseMismatchMonConfigSet.Name = "m_btnTXGainPhaseMismatchMonConfigSet";
            this.m_btnTXGainPhaseMismatchMonConfigSet.Size = new Size(57, 28);
            this.m_btnTXGainPhaseMismatchMonConfigSet.TabIndex = 50;
            this.m_btnTXGainPhaseMismatchMonConfigSet.Text = "Set";
            this.m_btnTXGainPhaseMismatchMonConfigSet.UseVisualStyleBackColor = true;
            this.m_btnTXGainPhaseMismatchMonConfigSet.Click += this.m_btnTXGainPhaseMismatchMonConfigSet_Click;
            this.label102.AutoSize = true;
            this.label102.Location = new Point(536, 149);
            this.label102.Margin = new Padding(4, 0, 4, 0);
            this.label102.Name = "label102";
            this.label102.Size = new Size(34, 17);
            this.label102.TabIndex = 49;
            this.label102.Text = "RF3";
            this.label101.AutoSize = true;
            this.label101.Location = new Point(447, 150);
            this.label101.Margin = new Padding(4, 0, 4, 0);
            this.label101.Name = "label101";
            this.label101.Size = new Size(34, 17);
            this.label101.TabIndex = 48;
            this.label101.Text = "RF2";
            this.label100.AutoSize = true;
            this.label100.Location = new Point(365, 150);
            this.label100.Margin = new Padding(4, 0, 4, 0);
            this.label100.Name = "label100";
            this.label100.Size = new Size(34, 17);
            this.label100.TabIndex = 47;
            this.label100.Text = "RF1";
            this.label99.AutoSize = true;
            this.label99.Location = new Point(320, 239);
            this.label99.Margin = new Padding(4, 0, 4, 0);
            this.label99.Name = "label99";
            this.label99.Size = new Size(34, 17);
            this.label99.TabIndex = 46;
            this.label99.Text = "TX2";
            this.label98.AutoSize = true;
            this.label98.Location = new Point(320, 213);
            this.label98.Margin = new Padding(4, 0, 4, 0);
            this.label98.Name = "label98";
            this.label98.Size = new Size(34, 17);
            this.label98.TabIndex = 45;
            this.label98.Text = "TX1";
            this.label97.AutoSize = true;
            this.label97.Location = new Point(320, 183);
            this.label97.Margin = new Padding(4, 0, 4, 0);
            this.label97.Name = "label97";
            this.label97.Size = new Size(34, 17);
            this.label97.TabIndex = 44;
            this.label97.Text = "TX0";
            this.label96.AutoSize = true;
            this.label96.Location = new Point(223, 151);
            this.label96.Margin = new Padding(4, 0, 4, 0);
            this.label96.Name = "label96";
            this.label96.Size = new Size(34, 17);
            this.label96.TabIndex = 43;
            this.label96.Text = "RF3";
            this.label95.AutoSize = true;
            this.label95.Location = new Point(125, 149);
            this.label95.Margin = new Padding(4, 0, 4, 0);
            this.label95.Name = "label95";
            this.label95.Size = new Size(34, 17);
            this.label95.TabIndex = 42;
            this.label95.Text = "RF2";
            this.label94.AutoSize = true;
            this.label94.Location = new Point(51, 151);
            this.label94.Margin = new Padding(4, 0, 4, 0);
            this.label94.Name = "label94";
            this.label94.Size = new Size(34, 17);
            this.label94.TabIndex = 41;
            this.label94.Text = "RF1";
            this.label93.AutoSize = true;
            this.label93.Location = new Point(4, 239);
            this.label93.Margin = new Padding(4, 0, 4, 0);
            this.label93.Name = "label93";
            this.label93.Size = new Size(34, 17);
            this.label93.TabIndex = 40;
            this.label93.Text = "TX2";
            this.label92.AutoSize = true;
            this.label92.Location = new Point(4, 209);
            this.label92.Margin = new Padding(4, 0, 4, 0);
            this.label92.Name = "label92";
            this.label92.Size = new Size(34, 17);
            this.label92.TabIndex = 39;
            this.label92.Text = "TX1";
            this.label91.AutoSize = true;
            this.label91.Location = new Point(4, 176);
            this.label91.Margin = new Padding(4, 0, 4, 0);
            this.label91.Name = "label91";
            this.label91.Size = new Size(34, 17);
            this.label91.TabIndex = 38;
            this.label91.Text = "TX0";
            this.m_nudRF1TX3TXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF1TX3TXPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudRF1TX3TXPhaseMismatchOffVal.Location = new Point(363, 236);
            this.m_nudRF1TX3TXPhaseMismatchOffVal.Margin = new Padding(4);

            int[] array49 = new int[4];
            array49[0] = 360;
            this.m_nudRF1TX3TXPhaseMismatchOffVal.Maximum = new decimal(array49);
            this.m_nudRF1TX3TXPhaseMismatchOffVal.Name = "m_nudRF1TX3TXPhaseMismatchOffVal";
            this.m_nudRF1TX3TXPhaseMismatchOffVal.Size = new Size(73, 22);
            this.m_nudRF1TX3TXPhaseMismatchOffVal.TabIndex = 37;
            this.m_nudRF1TX2TXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF1TX2TXPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudRF1TX2TXPhaseMismatchOffVal.Location = new Point(363, 204);
            this.m_nudRF1TX2TXPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array50 = new int[4];
            array50[0] = 360;
            this.m_nudRF1TX2TXPhaseMismatchOffVal.Maximum = new decimal(array50);
            this.m_nudRF1TX2TXPhaseMismatchOffVal.Name = "m_nudRF1TX2TXPhaseMismatchOffVal";
            this.m_nudRF1TX2TXPhaseMismatchOffVal.Size = new Size(72, 22);
            this.m_nudRF1TX2TXPhaseMismatchOffVal.TabIndex = 36;
            this.m_nudRF1TX1TXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF1TX1TXPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudRF1TX1TXPhaseMismatchOffVal.Location = new Point(363, 172);
            this.m_nudRF1TX1TXPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array51 = new int[4];
            array51[0] = 360;
            this.m_nudRF1TX1TXPhaseMismatchOffVal.Maximum = new decimal(array51);
            this.m_nudRF1TX1TXPhaseMismatchOffVal.Name = "m_nudRF1TX1TXPhaseMismatchOffVal";
            this.m_nudRF1TX1TXPhaseMismatchOffVal.Size = new Size(69, 22);
            this.m_nudRF1TX1TXPhaseMismatchOffVal.TabIndex = 35;
            this.m_nudRF3TX3TXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF3TX3TXPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudRF3TX3TXPhaseMismatchOffVal.Location = new Point(529, 236);
            this.m_nudRF3TX3TXPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array52 = new int[4];
            array52[0] = 360;
            this.m_nudRF3TX3TXPhaseMismatchOffVal.Maximum = new decimal(array52);
            this.m_nudRF3TX3TXPhaseMismatchOffVal.Name = "m_nudRF3TX3TXPhaseMismatchOffVal";
            this.m_nudRF3TX3TXPhaseMismatchOffVal.Size = new Size(73, 22);
            this.m_nudRF3TX3TXPhaseMismatchOffVal.TabIndex = 34;
            this.m_nudRF3TX2TXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF3TX2TXPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudRF3TX2TXPhaseMismatchOffVal.Location = new Point(529, 204);
            this.m_nudRF3TX2TXPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array53 = new int[4];
            array53[0] = 360;
            this.m_nudRF3TX2TXPhaseMismatchOffVal.Maximum = new decimal(array53);
            this.m_nudRF3TX2TXPhaseMismatchOffVal.Name = "m_nudRF3TX2TXPhaseMismatchOffVal";
            this.m_nudRF3TX2TXPhaseMismatchOffVal.Size = new Size(72, 22);
            this.m_nudRF3TX2TXPhaseMismatchOffVal.TabIndex = 33;
            this.m_nudRF3TX1TXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF3TX1TXPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudRF3TX1TXPhaseMismatchOffVal.Location = new Point(529, 172);
            this.m_nudRF3TX1TXPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array54 = new int[4];
            array54[0] = 360;
            this.m_nudRF3TX1TXPhaseMismatchOffVal.Maximum = new decimal(array54);
            this.m_nudRF3TX1TXPhaseMismatchOffVal.Name = "m_nudRF3TX1TXPhaseMismatchOffVal";
            this.m_nudRF3TX1TXPhaseMismatchOffVal.Size = new Size(69, 22);
            this.m_nudRF3TX1TXPhaseMismatchOffVal.TabIndex = 32;
            this.m_nudRF2TX3TXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF2TX3TXPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudRF2TX3TXPhaseMismatchOffVal.Location = new Point(445, 236);
            this.m_nudRF2TX3TXPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array55 = new int[4];
            array55[0] = 360;
            this.m_nudRF2TX3TXPhaseMismatchOffVal.Maximum = new decimal(array55);
            this.m_nudRF2TX3TXPhaseMismatchOffVal.Name = "m_nudRF2TX3TXPhaseMismatchOffVal";
            this.m_nudRF2TX3TXPhaseMismatchOffVal.Size = new Size(73, 22);
            this.m_nudRF2TX3TXPhaseMismatchOffVal.TabIndex = 31;
            this.m_nudRF2TX2TXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF2TX2TXPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudRF2TX2TXPhaseMismatchOffVal.Location = new Point(445, 204);
            this.m_nudRF2TX2TXPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array56 = new int[4];
            array56[0] = 360;
            this.m_nudRF2TX2TXPhaseMismatchOffVal.Maximum = new decimal(array56);
            this.m_nudRF2TX2TXPhaseMismatchOffVal.Name = "m_nudRF2TX2TXPhaseMismatchOffVal";
            this.m_nudRF2TX2TXPhaseMismatchOffVal.Size = new Size(72, 22);
            this.m_nudRF2TX2TXPhaseMismatchOffVal.TabIndex = 30;
            this.m_nudRF2TX1TXPhaseMismatchOffVal.DecimalPlaces = 2;
            this.m_nudRF2TX1TXPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudRF2TX1TXPhaseMismatchOffVal.Location = new Point(445, 172);
            this.m_nudRF2TX1TXPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array57 = new int[4];
            array57[0] = 360;
            this.m_nudRF2TX1TXPhaseMismatchOffVal.Maximum = new decimal(array57);
            this.m_nudRF2TX1TXPhaseMismatchOffVal.Name = "m_nudRF2TX1TXPhaseMismatchOffVal";
            this.m_nudRF2TX1TXPhaseMismatchOffVal.Size = new Size(69, 22);
            this.m_nudRF2TX1TXPhaseMismatchOffVal.TabIndex = 29;
            this.m_nudRF3TX3TXGainPhaseMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF3TX3TXGainPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudRF3TX3TXGainPhaseMismatchOffVal.Location = new Point(207, 234);
            this.m_nudRF3TX3TXGainPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array58 = new int[4];
            array58[0] = 10;
            this.m_nudRF3TX3TXGainPhaseMismatchOffVal.Maximum = new decimal(array58);
            this.m_nudRF3TX3TXGainPhaseMismatchOffVal.Minimum = new decimal(new int[]
            {
                10,
                0,
                0,
                int.MinValue
            });
            this.m_nudRF3TX3TXGainPhaseMismatchOffVal.Name = "m_nudRF3TX3TXGainPhaseMismatchOffVal";
            this.m_nudRF3TX3TXGainPhaseMismatchOffVal.Size = new Size(73, 22);
            this.m_nudRF3TX3TXGainPhaseMismatchOffVal.TabIndex = 28;
            this.m_nudRF3TX2TXGainPhaseMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF3TX2TXGainPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudRF3TX2TXGainPhaseMismatchOffVal.Location = new Point(207, 202);
            this.m_nudRF3TX2TXGainPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array59 = new int[4];
            array59[0] = 10;
            this.m_nudRF3TX2TXGainPhaseMismatchOffVal.Maximum = new decimal(array59);
            this.m_nudRF3TX2TXGainPhaseMismatchOffVal.Minimum = new decimal(new int[]
            {
                10,
                0,
                0,
                int.MinValue
            });
            this.m_nudRF3TX2TXGainPhaseMismatchOffVal.Name = "m_nudRF3TX2TXGainPhaseMismatchOffVal";
            this.m_nudRF3TX2TXGainPhaseMismatchOffVal.Size = new Size(72, 22);
            this.m_nudRF3TX2TXGainPhaseMismatchOffVal.TabIndex = 27;
            this.m_nudRF3TX1TXGainPhaseMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF3TX1TXGainPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudRF3TX1TXGainPhaseMismatchOffVal.Location = new Point(207, 170);
            this.m_nudRF3TX1TXGainPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array60 = new int[4];
            array60[0] = 10;
            this.m_nudRF3TX1TXGainPhaseMismatchOffVal.Maximum = new decimal(array60);
            this.m_nudRF3TX1TXGainPhaseMismatchOffVal.Minimum = new decimal(new int[]
            {
                10,
                0,
                0,
                int.MinValue
            });
            this.m_nudRF3TX1TXGainPhaseMismatchOffVal.Name = "m_nudRF3TX1TXGainPhaseMismatchOffVal";
            this.m_nudRF3TX1TXGainPhaseMismatchOffVal.Size = new Size(69, 22);
            this.m_nudRF3TX1TXGainPhaseMismatchOffVal.TabIndex = 26;
            this.m_nudRF2TX3TXGainPhaseMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF2TX3TXGainPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudRF2TX3TXGainPhaseMismatchOffVal.Location = new Point(124, 234);
            this.m_nudRF2TX3TXGainPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array61 = new int[4];
            array61[0] = 10;
            this.m_nudRF2TX3TXGainPhaseMismatchOffVal.Maximum = new decimal(array61);
            this.m_nudRF2TX3TXGainPhaseMismatchOffVal.Minimum = new decimal(new int[]
            {
                10,
                0,
                0,
                int.MinValue
            });
            this.m_nudRF2TX3TXGainPhaseMismatchOffVal.Name = "m_nudRF2TX3TXGainPhaseMismatchOffVal";
            this.m_nudRF2TX3TXGainPhaseMismatchOffVal.Size = new Size(73, 22);
            this.m_nudRF2TX3TXGainPhaseMismatchOffVal.TabIndex = 25;
            this.m_nudRF2TX2TXGainPhaseMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF2TX2TXGainPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudRF2TX2TXGainPhaseMismatchOffVal.Location = new Point(124, 202);
            this.m_nudRF2TX2TXGainPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array62 = new int[4];
            array62[0] = 10;
            this.m_nudRF2TX2TXGainPhaseMismatchOffVal.Maximum = new decimal(array62);
            this.m_nudRF2TX2TXGainPhaseMismatchOffVal.Minimum = new decimal(new int[]
            {
                10,
                0,
                0,
                int.MinValue
            });
            this.m_nudRF2TX2TXGainPhaseMismatchOffVal.Name = "m_nudRF2TX2TXGainPhaseMismatchOffVal";
            this.m_nudRF2TX2TXGainPhaseMismatchOffVal.Size = new Size(72, 22);
            this.m_nudRF2TX2TXGainPhaseMismatchOffVal.TabIndex = 24;
            this.m_nudRF2TX1TXGainPhaseMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF2TX1TXGainPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudRF2TX1TXGainPhaseMismatchOffVal.Location = new Point(124, 170);
            this.m_nudRF2TX1TXGainPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array63 = new int[4];
            array63[0] = 10;
            this.m_nudRF2TX1TXGainPhaseMismatchOffVal.Maximum = new decimal(array63);
            this.m_nudRF2TX1TXGainPhaseMismatchOffVal.Minimum = new decimal(new int[]
            {
                10,
                0,
                0,
                int.MinValue
            });
            this.m_nudRF2TX1TXGainPhaseMismatchOffVal.Name = "m_nudRF2TX1TXGainPhaseMismatchOffVal";
            this.m_nudRF2TX1TXGainPhaseMismatchOffVal.Size = new Size(69, 22);
            this.m_nudRF2TX1TXGainPhaseMismatchOffVal.TabIndex = 23;
            this.m_nudRF1TX3TXGainPhaseMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF1TX3TXGainPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudRF1TX3TXGainPhaseMismatchOffVal.Location = new Point(43, 234);
            this.m_nudRF1TX3TXGainPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array64 = new int[4];
            array64[0] = 10;
            this.m_nudRF1TX3TXGainPhaseMismatchOffVal.Maximum = new decimal(array64);
            this.m_nudRF1TX3TXGainPhaseMismatchOffVal.Minimum = new decimal(new int[]
            {
                10,
                0,
                0,
                int.MinValue
            });
            this.m_nudRF1TX3TXGainPhaseMismatchOffVal.Name = "m_nudRF1TX3TXGainPhaseMismatchOffVal";
            this.m_nudRF1TX3TXGainPhaseMismatchOffVal.Size = new Size(73, 22);
            this.m_nudRF1TX3TXGainPhaseMismatchOffVal.TabIndex = 22;
            this.m_nudRF1TX2TXGainPhaseMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF1TX2TXGainPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudRF1TX2TXGainPhaseMismatchOffVal.Location = new Point(43, 202);
            this.m_nudRF1TX2TXGainPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array65 = new int[4];
            array65[0] = 10;
            this.m_nudRF1TX2TXGainPhaseMismatchOffVal.Maximum = new decimal(array65);
            this.m_nudRF1TX2TXGainPhaseMismatchOffVal.Minimum = new decimal(new int[]
            {
                10,
                0,
                0,
                int.MinValue
            });
            this.m_nudRF1TX2TXGainPhaseMismatchOffVal.Name = "m_nudRF1TX2TXGainPhaseMismatchOffVal";
            this.m_nudRF1TX2TXGainPhaseMismatchOffVal.Size = new Size(72, 22);
            this.m_nudRF1TX2TXGainPhaseMismatchOffVal.TabIndex = 21;
            this.label90.AutoSize = true;
            this.label90.Location = new Point(4, 133);
            this.label90.Margin = new Padding(4, 0, 4, 0);
            this.label90.Name = "label90";
            this.label90.Size = new Size(215, 17);
            this.label90.TabIndex = 20;
            this.label90.Text = "Tx Gain Mismatch Offset val (dB)";
            this.m_nudRF1TX1TXGainPhaseMismatchOffVal.DecimalPlaces = 1;
            this.m_nudRF1TX1TXGainPhaseMismatchOffVal.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudRF1TX1TXGainPhaseMismatchOffVal.Location = new Point(43, 170);
            this.m_nudRF1TX1TXGainPhaseMismatchOffVal.Margin = new Padding(4);
            int[] array66 = new int[4];
            array66[0] = 10;
            this.m_nudRF1TX1TXGainPhaseMismatchOffVal.Maximum = new decimal(array66);
            this.m_nudRF1TX1TXGainPhaseMismatchOffVal.Minimum = new decimal(new int[]
            {
                10,
                0,
                0,
                int.MinValue
            });
            this.m_nudRF1TX1TXGainPhaseMismatchOffVal.Name = "m_nudRF1TX1TXGainPhaseMismatchOffVal";
            this.m_nudRF1TX1TXGainPhaseMismatchOffVal.Size = new Size(69, 22);
            this.m_nudRF1TX1TXGainPhaseMismatchOffVal.TabIndex = 18;
            this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.DecimalPlaces = 2;
            this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.Location = new Point(533, 79);
            this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.Margin = new Padding(4);
            int[] array67 = new int[4];
            array67[0] = 360;
            this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.Maximum = new decimal(array67);
            this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.Name = "m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold";
            this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.Size = new Size(91, 22);
            this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold.TabIndex = 17;
            this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.DecimalPlaces = 1;
            this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.Location = new Point(533, 49);
            this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.Margin = new Padding(4);
            int[] array68 = new int[4];
            array68[0] = 10;
            this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.Maximum = new decimal(array68);
            this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.Name = "m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold";
            this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.Size = new Size(91, 22);
            this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold.TabIndex = 16;
            this.m_nudTxGainPhaseMismacthMonReportingMode.Location = new Point(533, 18);
            this.m_nudTxGainPhaseMismacthMonReportingMode.Margin = new Padding(4);
            int[] array69 = new int[4];
            array69[0] = 2;
            this.m_nudTxGainPhaseMismacthMonReportingMode.Maximum = new decimal(array69);
            this.m_nudTxGainPhaseMismacthMonReportingMode.Name = "m_nudTxGainPhaseMismacthMonReportingMode";
            this.m_nudTxGainPhaseMismacthMonReportingMode.Size = new Size(91, 22);
            this.m_nudTxGainPhaseMismacthMonReportingMode.TabIndex = 15;
            this.m_chbTXGainPhaseMismatchMonTx3.AutoSize = true;
            this.m_chbTXGainPhaseMismatchMonTx3.Location = new Point(257, 78);
            this.m_chbTXGainPhaseMismatchMonTx3.Margin = new Padding(4);
            this.m_chbTXGainPhaseMismatchMonTx3.Name = "m_chbTXGainPhaseMismatchMonTx3";
            this.m_chbTXGainPhaseMismatchMonTx3.Size = new Size(53, 21);
            this.m_chbTXGainPhaseMismatchMonTx3.TabIndex = 14;
            this.m_chbTXGainPhaseMismatchMonTx3.Text = "Tx2";
            this.m_chbTXGainPhaseMismatchMonTx3.UseVisualStyleBackColor = true;
            this.m_chbTXGainPhaseMismatchMonTx2.AutoSize = true;
            this.m_chbTXGainPhaseMismatchMonTx2.Location = new Point(199, 76);
            this.m_chbTXGainPhaseMismatchMonTx2.Margin = new Padding(4);
            this.m_chbTXGainPhaseMismatchMonTx2.Name = "m_chbTXGainPhaseMismatchMonTx2";
            this.m_chbTXGainPhaseMismatchMonTx2.Size = new Size(53, 21);
            this.m_chbTXGainPhaseMismatchMonTx2.TabIndex = 13;
            this.m_chbTXGainPhaseMismatchMonTx2.Text = "Tx1";
            this.m_chbTXGainPhaseMismatchMonTx2.UseVisualStyleBackColor = true;
            this.m_chbTXGainPhaseMismatchMonTx1.AutoSize = true;
            this.m_chbTXGainPhaseMismatchMonTx1.Location = new Point(144, 76);
            this.m_chbTXGainPhaseMismatchMonTx1.Margin = new Padding(4);
            this.m_chbTXGainPhaseMismatchMonTx1.Name = "m_chbTXGainPhaseMismatchMonTx1";
            this.m_chbTXGainPhaseMismatchMonTx1.Size = new Size(53, 21);
            this.m_chbTXGainPhaseMismatchMonTx1.TabIndex = 12;
            this.m_chbTXGainPhaseMismatchMonTx1.Text = "Tx0";
            this.m_chbTXGainPhaseMismatchMonTx1.UseVisualStyleBackColor = true;
            this.m_chbRF3TXGainPhaseMismatchMonBitMask.AutoSize = true;
            this.m_chbRF3TXGainPhaseMismatchMonBitMask.Checked = true;
            this.m_chbRF3TXGainPhaseMismatchMonBitMask.CheckState = CheckState.Checked;
            this.m_chbRF3TXGainPhaseMismatchMonBitMask.Location = new Point(257, 53);
            this.m_chbRF3TXGainPhaseMismatchMonBitMask.Margin = new Padding(4);
            this.m_chbRF3TXGainPhaseMismatchMonBitMask.Name = "m_chbRF3TXGainPhaseMismatchMonBitMask";
            this.m_chbRF3TXGainPhaseMismatchMonBitMask.Size = new Size(56, 21);
            this.m_chbRF3TXGainPhaseMismatchMonBitMask.TabIndex = 11;
            this.m_chbRF3TXGainPhaseMismatchMonBitMask.Text = "RF3";
            this.m_chbRF3TXGainPhaseMismatchMonBitMask.UseVisualStyleBackColor = true;
            this.m_chbRF2TXGainPhaseMismatchMonBitMask.AutoSize = true;
            this.m_chbRF2TXGainPhaseMismatchMonBitMask.Checked = true;
            this.m_chbRF2TXGainPhaseMismatchMonBitMask.CheckState = CheckState.Checked;
            this.m_chbRF2TXGainPhaseMismatchMonBitMask.Location = new Point(199, 53);
            this.m_chbRF2TXGainPhaseMismatchMonBitMask.Margin = new Padding(4);
            this.m_chbRF2TXGainPhaseMismatchMonBitMask.Name = "m_chbRF2TXGainPhaseMismatchMonBitMask";
            this.m_chbRF2TXGainPhaseMismatchMonBitMask.Size = new Size(56, 21);
            this.m_chbRF2TXGainPhaseMismatchMonBitMask.TabIndex = 10;
            this.m_chbRF2TXGainPhaseMismatchMonBitMask.Text = "RF2";
            this.m_chbRF2TXGainPhaseMismatchMonBitMask.UseVisualStyleBackColor = true;
            this.m_chbRF1TXGainPhaseMismatchMonBitMask.AutoSize = true;
            this.m_chbRF1TXGainPhaseMismatchMonBitMask.Checked = true;
            this.m_chbRF1TXGainPhaseMismatchMonBitMask.CheckState = CheckState.Checked;
            this.m_chbRF1TXGainPhaseMismatchMonBitMask.Location = new Point(144, 52);
            this.m_chbRF1TXGainPhaseMismatchMonBitMask.Margin = new Padding(4);
            this.m_chbRF1TXGainPhaseMismatchMonBitMask.Name = "m_chbRF1TXGainPhaseMismatchMonBitMask";
            this.m_chbRF1TXGainPhaseMismatchMonBitMask.Size = new Size(56, 21);
            this.m_chbRF1TXGainPhaseMismatchMonBitMask.TabIndex = 9;
            this.m_chbRF1TXGainPhaseMismatchMonBitMask.Text = "RF1";
            this.m_chbRF1TXGainPhaseMismatchMonBitMask.UseVisualStyleBackColor = true;
            this.m_nudTxGainPhaseMismacthMonProfileIndex.Location = new Point(144, 21);
            this.m_nudTxGainPhaseMismacthMonProfileIndex.Margin = new Padding(4);
            int[] array70 = new int[4];
            array70[0] = 3;
            this.m_nudTxGainPhaseMismacthMonProfileIndex.Maximum = new decimal(array70);
            this.m_nudTxGainPhaseMismacthMonProfileIndex.Name = "m_nudTxGainPhaseMismacthMonProfileIndex";
            this.m_nudTxGainPhaseMismacthMonProfileIndex.Size = new Size(105, 22);
            this.m_nudTxGainPhaseMismacthMonProfileIndex.TabIndex = 8;
            this.label86.AutoSize = true;
            this.label86.Location = new Point(320, 133);
            this.label86.Margin = new Padding(4, 0, 4, 0);
            this.label86.Name = "label86";
            this.label86.Size = new Size(211, 17);
            this.label86.TabIndex = 7;
            this.label86.Text = "Tx Ph Mismatch Offset val (Deg)";
            this.label87.AutoSize = true;
            this.label87.Location = new Point(17, 191);
            this.label87.Margin = new Padding(4, 0, 4, 0);
            this.label87.Name = "label87";
            this.label87.Size = new Size(0, 17);
            this.label87.TabIndex = 6;
            this.label88.AutoSize = true;
            this.label88.Location = new Point(317, 78);
            this.label88.Margin = new Padding(4, 0, 4, 0);
            this.label88.Name = "label88";
            this.label88.Size = new Size(215, 17);
            this.label88.TabIndex = 5;
            this.label88.Text = "Tx Phase Mismatch Thresh(Deg)";
            this.label89.AutoSize = true;
            this.label89.Location = new Point(316, 50);
            this.label89.Margin = new Padding(4, 0, 4, 0);
            this.label89.Name = "label89";
            this.label89.Size = new Size(196, 17);
            this.label89.TabIndex = 4;
            this.label89.Text = "Tx Gain Mismatch Thresh(dB)";
            this.label85.AutoSize = true;
            this.label85.Location = new Point(317, 21);
            this.label85.Margin = new Padding(4, 0, 4, 0);
            this.label85.Name = "label85";
            this.label85.Size = new Size(109, 17);
            this.label85.TabIndex = 3;
            this.label85.Text = "Reporting Mode";
            this.label84.AutoSize = true;
            this.label84.Location = new Point(4, 74);
            this.label84.Margin = new Padding(4, 0, 4, 0);
            this.label84.Name = "label84";
            this.label84.Size = new Size(52, 17);
            this.label84.TabIndex = 2;
            this.label84.Text = "Tx Ena";
            this.label83.AutoSize = true;
            this.label83.Location = new Point(4, 48);
            this.label83.Margin = new Padding(4, 0, 4, 0);
            this.label83.Name = "label83";
            this.label83.Size = new Size(112, 17);
            this.label83.TabIndex = 1;
            this.label83.Text = "RF Freq BitMask";
            this.label82.AutoSize = true;
            this.label82.Location = new Point(4, 25);
            this.label82.Margin = new Padding(4, 0, 4, 0);
            this.label82.Name = "label82";
            this.label82.Size = new Size(85, 17);
            this.label82.TabIndex = 0;
            this.label82.Text = "Profile Index";
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.f000125);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.f000126);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.f000127);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label65);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label62);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label61);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbReservedMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label37);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbRXMixerInputPowerMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label118);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label131);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbRXSigImgBandMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_btnAnalogMonRFEnablesMonConfigSet);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.f00010f);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label25);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label19);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label20);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label21);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label22);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label23);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label24);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label13);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label14);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label15);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label16);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label17);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label18);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label7);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label8);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label9);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label10);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label11);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label12);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label6);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label5);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label4);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label3);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label2);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.label1);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.f000110);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.f000111);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbInternalRXSignalsMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbInternalTX3SignalsMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbInternalTX2SignalsMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbPLLControlVolMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbDCCClockFreqMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbTemperatureMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbInternalTX1SignalsMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbExternalAnalogSignalsMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbSynthFreqMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.f000112);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.f000113);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.f000114);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbTXGainPhaseMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbTX3BallBreakMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbTX2BallBreakMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbTX1BallBreakMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbTX3PowerMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbTX2PowerMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbTX1PowerMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.f000115);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbRXNoiseMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Controls.Add(this.m_chbRXGainPhaseMonEna);
            this.m_grpAnalogMonitoringRFEnablesConfig.Location = new Point(13, 4);
            this.m_grpAnalogMonitoringRFEnablesConfig.Margin = new Padding(4);
            this.m_grpAnalogMonitoringRFEnablesConfig.Name = "m_grpAnalogMonitoringRFEnablesConfig";
            this.m_grpAnalogMonitoringRFEnablesConfig.Padding = new Padding(4);
            this.m_grpAnalogMonitoringRFEnablesConfig.Size = new Size(419, 418);
            this.m_grpAnalogMonitoringRFEnablesConfig.TabIndex = 13;
            this.m_grpAnalogMonitoringRFEnablesConfig.TabStop = false;
            this.m_grpAnalogMonitoringRFEnablesConfig.Text = "RF Analog Monitoring Enables Config";
            this.f000125.AutoSize = true;
            this.f000125.Location = new Point(379, 364);
            this.f000125.Margin = new Padding(4);
            this.f000125.Name = "m_chbVCOLDOCircuitEna";
            this.f000125.Size = new Size(18, 17);
            this.f000125.TabIndex = 62;
            this.f000125.UseVisualStyleBackColor = true;
            this.f000126.AutoSize = true;
            this.f000126.Location = new Point(139, 391);
            this.f000126.Margin = new Padding(4);
            this.f000126.Name = "m_chbPALDOCircuitEna";
            this.f000126.Size = new Size(18, 17);
            this.f000126.TabIndex = 61;
            this.f000126.UseVisualStyleBackColor = true;
            this.f000127.AutoSize = true;
            this.f000127.Location = new Point(139, 368);
            this.f000127.Margin = new Padding(4);
            this.f000127.Name = "m_chbAPLLLDOCircuitEna";
            this.f000127.Size = new Size(18, 17);
            this.f000127.TabIndex = 60;
            this.f000127.UseVisualStyleBackColor = true;
            this.label65.AutoSize = true;
            this.label65.Location = new Point(13, 394);
            this.label65.Margin = new Padding(4, 0, 4, 0);
            this.label65.Name = "label65";
            this.label65.Size = new Size(102, 17);
            this.label65.TabIndex = 59;
            this.label65.Text = "PA LDO SC En";
            this.label62.AutoSize = true;
            this.label62.Location = new Point(187, 366);
            this.label62.Margin = new Padding(4, 0, 4, 0);
            this.label62.Name = "label62";
            this.label62.Size = new Size(113, 17);
            this.label62.TabIndex = 58;
            this.label62.Text = "VCO LDO SC En";
            this.label61.AutoSize = true;
            this.label61.Location = new Point(13, 369);
            this.label61.Margin = new Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new Size(118, 17);
            this.label61.TabIndex = 57;
            this.label61.Text = "APLL LDO SC En";
            this.m_chbReservedMonEna.AutoSize = true;
            this.m_chbReservedMonEna.Location = new Point(379, 338);
            this.m_chbReservedMonEna.Margin = new Padding(4);
            this.m_chbReservedMonEna.Name = "m_chbReservedMonEna";
            this.m_chbReservedMonEna.Size = new Size(18, 17);
            this.m_chbReservedMonEna.TabIndex = 56;
            this.m_chbReservedMonEna.UseVisualStyleBackColor = true;
            this.label37.AutoSize = true;
            this.label37.Location = new Point(187, 340);
            this.label37.Margin = new Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new Size(69, 17);
            this.label37.TabIndex = 55;
            this.label37.Text = "Reserved";
            this.m_chbRXMixerInputPowerMonEna.AutoSize = true;
            this.m_chbRXMixerInputPowerMonEna.Location = new Point(380, 315);
            this.m_chbRXMixerInputPowerMonEna.Margin = new Padding(4);
            this.m_chbRXMixerInputPowerMonEna.Name = "m_chbRXMixerInputPowerMonEna";
            this.m_chbRXMixerInputPowerMonEna.Size = new Size(18, 17);
            this.m_chbRXMixerInputPowerMonEna.TabIndex = 54;
            this.m_chbRXMixerInputPowerMonEna.UseVisualStyleBackColor = true;
            this.label118.AutoSize = true;
            this.label118.Location = new Point(185, 318);
            this.label118.Margin = new Padding(4, 0, 4, 0);
            this.label118.Name = "label118";
            this.label118.Size = new Size(127, 17);
            this.label118.TabIndex = 53;
            this.label118.Text = "RxMixerInputPower";
            this.label131.AutoSize = true;
            this.label131.Location = new Point(185, 294);
            this.label131.Margin = new Padding(4, 0, 4, 0);
            this.label131.Name = "label131";
            this.label131.Size = new Size(114, 17);
            this.label131.TabIndex = 52;
            this.label131.Text = "RX Sig Img Band";
            this.m_chbRXSigImgBandMonEna.AutoSize = true;
            this.m_chbRXSigImgBandMonEna.Location = new Point(380, 295);
            this.m_chbRXSigImgBandMonEna.Margin = new Padding(4);
            this.m_chbRXSigImgBandMonEna.Name = "m_chbRXSigImgBandMonEna";
            this.m_chbRXSigImgBandMonEna.Size = new Size(18, 17);
            this.m_chbRXSigImgBandMonEna.TabIndex = 51;
            this.m_chbRXSigImgBandMonEna.UseVisualStyleBackColor = true;
            this.m_btnAnalogMonRFEnablesMonConfigSet.Location = new Point(307, 382);
            this.m_btnAnalogMonRFEnablesMonConfigSet.Margin = new Padding(4);
            this.m_btnAnalogMonRFEnablesMonConfigSet.Name = "m_btnAnalogMonRFEnablesMonConfigSet";
            this.m_btnAnalogMonRFEnablesMonConfigSet.Size = new Size(93, 33);
            this.m_btnAnalogMonRFEnablesMonConfigSet.TabIndex = 50;
            this.m_btnAnalogMonRFEnablesMonConfigSet.Text = "Set";
            this.m_btnAnalogMonRFEnablesMonConfigSet.UseVisualStyleBackColor = true;
            this.m_btnAnalogMonRFEnablesMonConfigSet.Click += this.m_btnAnalogMonRFEnablesMonConfigSet_Click_1;
            this.f00010f.AutoSize = true;
            this.f00010f.Location = new Point(380, 271);
            this.f00010f.Margin = new Padding(4);
            this.f00010f.Name = "m_chbRXIFASaturationMonEna";
            this.f00010f.Size = new Size(18, 17);
            this.f00010f.TabIndex = 49;
            this.f00010f.UseVisualStyleBackColor = true;
            this.label25.AutoSize = true;
            this.label25.Location = new Point(185, 271);
            this.label25.Margin = new Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new Size(120, 17);
            this.label25.TabIndex = 48;
            this.label25.Text = "RX IFA Saturation";
            this.label19.AutoSize = true;
            this.label19.Location = new Point(185, 246);
            this.label19.Margin = new Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new Size(107, 17);
            this.label19.TabIndex = 47;
            this.label19.Text = "DCC Clock Freq";
            this.label20.AutoSize = true;
            this.label20.Location = new Point(185, 222);
            this.label20.Margin = new Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new Size(106, 17);
            this.label20.TabIndex = 46;
            this.label20.Text = "PLL Control Vol";
            this.label21.AutoSize = true;
            this.label21.Location = new Point(185, 197);
            this.label21.Margin = new Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new Size(157, 17);
            this.label21.TabIndex = 45;
            this.label21.Text = "Internal GPADC Signals";
            this.label22.AutoSize = true;
            this.label22.Location = new Point(185, 172);
            this.label22.Margin = new Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new Size(174, 17);
            this.label22.TabIndex = 44;
            this.label22.Text = "Internal PMCLKLO Signals";
            this.label23.AutoSize = true;
            this.label23.Location = new Point(185, 148);
            this.label23.Margin = new Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new Size(128, 17);
            this.label23.TabIndex = 43;
            this.label23.Text = "Internal RX Signals";
            this.label24.AutoSize = true;
            this.label24.Location = new Point(185, 123);
            this.label24.Margin = new Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new Size(135, 17);
            this.label24.TabIndex = 42;
            this.label24.Text = "Internal TX2 Signals";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(185, 98);
            this.label13.Margin = new Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new Size(135, 17);
            this.label13.TabIndex = 41;
            this.label13.Text = "Internal TX1 Signals";
            this.label14.AutoSize = true;
            this.label14.Location = new Point(185, 74);
            this.label14.Margin = new Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new Size(135, 17);
            this.label14.TabIndex = 40;
            this.label14.Text = "Internal TX0 Signals";
            this.label15.AutoSize = true;
            this.label15.Location = new Point(185, 49);
            this.label15.Margin = new Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new Size(157, 17);
            this.label15.TabIndex = 39;
            this.label15.Text = "External Analog Signals";
            this.label16.AutoSize = true;
            this.label16.Location = new Point(185, 25);
            this.label16.Margin = new Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new Size(77, 17);
            this.label16.TabIndex = 38;
            this.label16.Text = "Synth Freq";
            this.label17.AutoSize = true;
            this.label17.Location = new Point(13, 345);
            this.label17.Margin = new Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new Size(67, 17);
            this.label17.TabIndex = 37;
            this.label17.Text = "TX2 BPM";
            this.label18.AutoSize = true;
            this.label18.Location = new Point(13, 320);
            this.label18.Margin = new Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new Size(67, 17);
            this.label18.TabIndex = 36;
            this.label18.Text = "TX1 BPM";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(13, 295);
            this.label7.Margin = new Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new Size(67, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "TX0 BPM";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(13, 271);
            this.label8.Margin = new Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new Size(104, 17);
            this.label8.TabIndex = 34;
            this.label8.Text = "TX Gain Phase";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(13, 246);
            this.label9.Margin = new Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(98, 17);
            this.label9.TabIndex = 33;
            this.label9.Text = "TX2 BallBreak";
            this.label10.AutoSize = true;
            this.label10.Location = new Point(13, 222);
            this.label10.Margin = new Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new Size(98, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "TX1 BallBreak";
            this.label11.AutoSize = true;
            this.label11.Location = new Point(13, 197);
            this.label11.Margin = new Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new Size(98, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "TX0 BallBreak";
            this.label12.AutoSize = true;
            this.label12.Location = new Point(13, 172);
            this.label12.Margin = new Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new Size(77, 17);
            this.label12.TabIndex = 30;
            this.label12.Text = "TX2 Power";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(13, 148);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(77, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "TX1 Power";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(13, 123);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(77, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "TX0 Power";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(13, 98);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(79, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "RX IFStage";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(13, 74);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(67, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "RX Noise";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(13, 49);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(105, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "RX Gain Phase";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 25);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(90, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Temperature";
            this.f000110.AutoSize = true;
            this.f000110.Location = new Point(380, 197);
            this.f000110.Margin = new Padding(4);
            this.f000110.Name = "m_chbInternalGPADCSignalsMonEna";
            this.f000110.Size = new Size(18, 17);
            this.f000110.TabIndex = 23;
            this.f000110.UseVisualStyleBackColor = true;
            this.f000111.AutoSize = true;
            this.f000111.Location = new Point(380, 172);
            this.f000111.Margin = new Padding(4);
            this.f000111.Name = "m_chbInternalPMCLKLOSignalsMonEna";
            this.f000111.Size = new Size(18, 17);
            this.f000111.TabIndex = 22;
            this.f000111.UseVisualStyleBackColor = true;
            this.m_chbInternalRXSignalsMonEna.AutoSize = true;
            this.m_chbInternalRXSignalsMonEna.Location = new Point(380, 148);
            this.m_chbInternalRXSignalsMonEna.Margin = new Padding(4);
            this.m_chbInternalRXSignalsMonEna.Name = "m_chbInternalRXSignalsMonEna";
            this.m_chbInternalRXSignalsMonEna.Size = new Size(18, 17);
            this.m_chbInternalRXSignalsMonEna.TabIndex = 21;
            this.m_chbInternalRXSignalsMonEna.UseVisualStyleBackColor = true;
            this.m_chbInternalTX3SignalsMonEna.AutoSize = true;
            this.m_chbInternalTX3SignalsMonEna.Location = new Point(380, 123);
            this.m_chbInternalTX3SignalsMonEna.Margin = new Padding(4);
            this.m_chbInternalTX3SignalsMonEna.Name = "m_chbInternalTX3SignalsMonEna";
            this.m_chbInternalTX3SignalsMonEna.Size = new Size(18, 17);
            this.m_chbInternalTX3SignalsMonEna.TabIndex = 20;
            this.m_chbInternalTX3SignalsMonEna.UseVisualStyleBackColor = true;
            this.m_chbInternalTX2SignalsMonEna.AutoSize = true;
            this.m_chbInternalTX2SignalsMonEna.Location = new Point(380, 98);
            this.m_chbInternalTX2SignalsMonEna.Margin = new Padding(4);
            this.m_chbInternalTX2SignalsMonEna.Name = "m_chbInternalTX2SignalsMonEna";
            this.m_chbInternalTX2SignalsMonEna.Size = new Size(18, 17);
            this.m_chbInternalTX2SignalsMonEna.TabIndex = 19;
            this.m_chbInternalTX2SignalsMonEna.UseVisualStyleBackColor = true;
            this.m_chbPLLControlVolMonEna.AutoSize = true;
            this.m_chbPLLControlVolMonEna.Location = new Point(380, 220);
            this.m_chbPLLControlVolMonEna.Margin = new Padding(4);
            this.m_chbPLLControlVolMonEna.Name = "m_chbPLLControlVolMonEna";
            this.m_chbPLLControlVolMonEna.Size = new Size(18, 17);
            this.m_chbPLLControlVolMonEna.TabIndex = 18;
            this.m_chbPLLControlVolMonEna.UseVisualStyleBackColor = true;
            this.m_chbDCCClockFreqMonEna.AutoSize = true;
            this.m_chbDCCClockFreqMonEna.Location = new Point(380, 246);
            this.m_chbDCCClockFreqMonEna.Margin = new Padding(4);
            this.m_chbDCCClockFreqMonEna.Name = "m_chbDCCClockFreqMonEna";
            this.m_chbDCCClockFreqMonEna.Size = new Size(18, 17);
            this.m_chbDCCClockFreqMonEna.TabIndex = 17;
            this.m_chbDCCClockFreqMonEna.UseVisualStyleBackColor = true;
            this.m_chbTemperatureMonEna.AutoSize = true;
            this.m_chbTemperatureMonEna.Location = new Point(139, 25);
            this.m_chbTemperatureMonEna.Margin = new Padding(4);
            this.m_chbTemperatureMonEna.Name = "m_chbTemperatureMonEna";
            this.m_chbTemperatureMonEna.Size = new Size(18, 17);
            this.m_chbTemperatureMonEna.TabIndex = 16;
            this.m_chbTemperatureMonEna.UseVisualStyleBackColor = true;
            this.m_chbInternalTX1SignalsMonEna.AutoSize = true;
            this.m_chbInternalTX1SignalsMonEna.Location = new Point(380, 74);
            this.m_chbInternalTX1SignalsMonEna.Margin = new Padding(4);
            this.m_chbInternalTX1SignalsMonEna.Name = "m_chbInternalTX1SignalsMonEna";
            this.m_chbInternalTX1SignalsMonEna.Size = new Size(18, 17);
            this.m_chbInternalTX1SignalsMonEna.TabIndex = 15;
            this.m_chbInternalTX1SignalsMonEna.UseVisualStyleBackColor = true;
            this.m_chbExternalAnalogSignalsMonEna.AutoSize = true;
            this.m_chbExternalAnalogSignalsMonEna.Location = new Point(380, 49);
            this.m_chbExternalAnalogSignalsMonEna.Margin = new Padding(4);
            this.m_chbExternalAnalogSignalsMonEna.Name = "m_chbExternalAnalogSignalsMonEna";
            this.m_chbExternalAnalogSignalsMonEna.Size = new Size(18, 17);
            this.m_chbExternalAnalogSignalsMonEna.TabIndex = 14;
            this.m_chbExternalAnalogSignalsMonEna.UseVisualStyleBackColor = true;
            this.m_chbSynthFreqMonEna.AutoSize = true;
            this.m_chbSynthFreqMonEna.Location = new Point(380, 25);
            this.m_chbSynthFreqMonEna.Margin = new Padding(4);
            this.m_chbSynthFreqMonEna.Name = "m_chbSynthFreqMonEna";
            this.m_chbSynthFreqMonEna.Size = new Size(18, 17);
            this.m_chbSynthFreqMonEna.TabIndex = 13;
            this.m_chbSynthFreqMonEna.UseVisualStyleBackColor = true;
            this.f000112.AutoSize = true;
            this.f000112.Location = new Point(139, 345);
            this.f000112.Margin = new Padding(4);
            this.f000112.Name = "m_chbTX3BPMMonEna";
            this.f000112.Size = new Size(18, 17);
            this.f000112.TabIndex = 12;
            this.f000112.UseVisualStyleBackColor = true;
            this.f000113.AutoSize = true;
            this.f000113.Location = new Point(139, 320);
            this.f000113.Margin = new Padding(4);
            this.f000113.Name = "m_chbTX2BPMMonEna";
            this.f000113.Size = new Size(18, 17);
            this.f000113.TabIndex = 11;
            this.f000113.UseVisualStyleBackColor = true;
            this.f000114.AutoSize = true;
            this.f000114.Location = new Point(139, 295);
            this.f000114.Margin = new Padding(4);
            this.f000114.Name = "m_chbTX1BPMMonEna";
            this.f000114.Size = new Size(18, 17);
            this.f000114.TabIndex = 10;
            this.f000114.UseVisualStyleBackColor = true;
            this.m_chbTXGainPhaseMonEna.AutoSize = true;
            this.m_chbTXGainPhaseMonEna.Location = new Point(139, 271);
            this.m_chbTXGainPhaseMonEna.Margin = new Padding(4);
            this.m_chbTXGainPhaseMonEna.Name = "m_chbTXGainPhaseMonEna";
            this.m_chbTXGainPhaseMonEna.Size = new Size(18, 17);
            this.m_chbTXGainPhaseMonEna.TabIndex = 9;
            this.m_chbTXGainPhaseMonEna.UseVisualStyleBackColor = true;
            this.m_chbTX3BallBreakMonEna.AutoSize = true;
            this.m_chbTX3BallBreakMonEna.Location = new Point(139, 246);
            this.m_chbTX3BallBreakMonEna.Margin = new Padding(4);
            this.m_chbTX3BallBreakMonEna.Name = "m_chbTX3BallBreakMonEna";
            this.m_chbTX3BallBreakMonEna.Size = new Size(18, 17);
            this.m_chbTX3BallBreakMonEna.TabIndex = 8;
            this.m_chbTX3BallBreakMonEna.UseVisualStyleBackColor = true;
            this.m_chbTX2BallBreakMonEna.AutoSize = true;
            this.m_chbTX2BallBreakMonEna.Location = new Point(139, 222);
            this.m_chbTX2BallBreakMonEna.Margin = new Padding(4);
            this.m_chbTX2BallBreakMonEna.Name = "m_chbTX2BallBreakMonEna";
            this.m_chbTX2BallBreakMonEna.Size = new Size(18, 17);
            this.m_chbTX2BallBreakMonEna.TabIndex = 7;
            this.m_chbTX2BallBreakMonEna.UseVisualStyleBackColor = true;
            this.m_chbTX1BallBreakMonEna.AutoSize = true;
            this.m_chbTX1BallBreakMonEna.Location = new Point(139, 197);
            this.m_chbTX1BallBreakMonEna.Margin = new Padding(4);
            this.m_chbTX1BallBreakMonEna.Name = "m_chbTX1BallBreakMonEna";
            this.m_chbTX1BallBreakMonEna.Size = new Size(18, 17);
            this.m_chbTX1BallBreakMonEna.TabIndex = 6;
            this.m_chbTX1BallBreakMonEna.UseVisualStyleBackColor = true;
            this.m_chbTX3PowerMonEna.AutoSize = true;
            this.m_chbTX3PowerMonEna.Location = new Point(139, 172);
            this.m_chbTX3PowerMonEna.Margin = new Padding(4);
            this.m_chbTX3PowerMonEna.Name = "m_chbTX3PowerMonEna";
            this.m_chbTX3PowerMonEna.Size = new Size(18, 17);
            this.m_chbTX3PowerMonEna.TabIndex = 5;
            this.m_chbTX3PowerMonEna.UseVisualStyleBackColor = true;
            this.m_chbTX2PowerMonEna.AutoSize = true;
            this.m_chbTX2PowerMonEna.Location = new Point(139, 148);
            this.m_chbTX2PowerMonEna.Margin = new Padding(4);
            this.m_chbTX2PowerMonEna.Name = "m_chbTX2PowerMonEna";
            this.m_chbTX2PowerMonEna.Size = new Size(18, 17);
            this.m_chbTX2PowerMonEna.TabIndex = 4;
            this.m_chbTX2PowerMonEna.UseVisualStyleBackColor = true;
            this.m_chbTX1PowerMonEna.AutoSize = true;
            this.m_chbTX1PowerMonEna.Location = new Point(139, 123);
            this.m_chbTX1PowerMonEna.Margin = new Padding(4);
            this.m_chbTX1PowerMonEna.Name = "m_chbTX1PowerMonEna";
            this.m_chbTX1PowerMonEna.Size = new Size(18, 17);
            this.m_chbTX1PowerMonEna.TabIndex = 3;
            this.m_chbTX1PowerMonEna.UseVisualStyleBackColor = true;
            this.f000115.AutoSize = true;
            this.f000115.Location = new Point(139, 98);
            this.f000115.Margin = new Padding(4);
            this.f000115.Name = "m_chbRXIFStageMonEna";
            this.f000115.Size = new Size(18, 17);
            this.f000115.TabIndex = 2;
            this.f000115.UseVisualStyleBackColor = true;
            this.m_chbRXNoiseMonEna.AutoSize = true;
            this.m_chbRXNoiseMonEna.Location = new Point(139, 74);
            this.m_chbRXNoiseMonEna.Margin = new Padding(4);
            this.m_chbRXNoiseMonEna.Name = "m_chbRXNoiseMonEna";
            this.m_chbRXNoiseMonEna.Size = new Size(18, 17);
            this.m_chbRXNoiseMonEna.TabIndex = 1;
            this.m_chbRXNoiseMonEna.UseVisualStyleBackColor = true;
            this.m_chbRXGainPhaseMonEna.AutoSize = true;
            this.m_chbRXGainPhaseMonEna.Location = new Point(139, 49);
            this.m_chbRXGainPhaseMonEna.Margin = new Padding(4);
            this.m_chbRXGainPhaseMonEna.Name = "m_chbRXGainPhaseMonEna";
            this.m_chbRXGainPhaseMonEna.Size = new Size(18, 17);
            this.m_chbRXGainPhaseMonEna.TabIndex = 0;
            this.m_chbRXGainPhaseMonEna.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.m_chbSynthFreqMonOffset);
            this.groupBox2.Controls.Add(this.m_btnAnalogFaultInjectionConfigSet);
            this.groupBox2.Controls.Add(this.m_chbSynthVCOOpenLoop);
            this.groupBox2.Controls.Add(this.f000116);
            this.groupBox2.Controls.Add(this.f000117);
            this.groupBox2.Controls.Add(this.f000118);
            this.groupBox2.Controls.Add(this.m_chbExtAnaSigMon);
            this.groupBox2.Controls.Add(this.m_chbTxGainInvTx2BPMVal);
            this.groupBox2.Controls.Add(this.m_chbTxGainInvTx3BPMVal);
            this.groupBox2.Controls.Add(this.m_chbTxGainInvTx1BPMVal);
            this.groupBox2.Controls.Add(this.m_chbTxGainInvTxFault);
            this.groupBox2.Controls.Add(this.m_chbTxGainDropTx3);
            this.groupBox2.Controls.Add(this.m_chbTxGainDropTx2);
            this.groupBox2.Controls.Add(this.m_chbTxGainDropTx1);
            this.groupBox2.Controls.Add(this.m_chbTxLOAmpTx2);
            this.groupBox2.Controls.Add(this.m_chbTxLOAmpTx0Tx1);
            this.groupBox2.Controls.Add(this.m_chbRxLOAmpRx2Rx3);
            this.groupBox2.Controls.Add(this.m_chbRxLOAmpRx0Rx1);
            this.groupBox2.Controls.Add(this.m_chbRxIFStageRx4);
            this.groupBox2.Controls.Add(this.m_chbRxIFStageRx3);
            this.groupBox2.Controls.Add(this.m_chbRxIFStageRx2);
            this.groupBox2.Controls.Add(this.m_chbRxIFStageRx1);
            this.groupBox2.Controls.Add(this.m_chbRxHighNoiseRx4);
            this.groupBox2.Controls.Add(this.m_chbRxHighNoiseRx3);
            this.groupBox2.Controls.Add(this.m_chbRxHighNoiseRx2);
            this.groupBox2.Controls.Add(this.m_chbRxHighNoiseRx1);
            this.groupBox2.Controls.Add(this.m_chbRxPhaseInvRx4);
            this.groupBox2.Controls.Add(this.m_chbRxPhaseInvRx3);
            this.groupBox2.Controls.Add(this.m_chbRxPhaseInvRx2);
            this.groupBox2.Controls.Add(this.m_chbRxPhaseInvRx1);
            this.groupBox2.Controls.Add(this.m_chbRxGainDropRx4);
            this.groupBox2.Controls.Add(this.m_chbRxGainDropRx3);
            this.groupBox2.Controls.Add(this.m_chbRxGainDropRx2);
            this.groupBox2.Controls.Add(this.m_chbRxGainDropRx1);
            this.groupBox2.Controls.Add(this.label59);
            this.groupBox2.Controls.Add(this.label60);
            this.groupBox2.Controls.Add(this.label52);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.label48);
            this.groupBox2.Controls.Add(this.label49);
            this.groupBox2.Controls.Add(this.label46);
            this.groupBox2.Controls.Add(this.label47);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.label40);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Location = new Point(1228, 17);
            this.groupBox2.Margin = new Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new Padding(4);
            this.groupBox2.Size = new Size(555, 385);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Analog Fault Injection Config";
            this.m_chbSynthFreqMonOffset.AutoSize = true;
            this.m_chbSynthFreqMonOffset.Location = new Point(251, 267);
            this.m_chbSynthFreqMonOffset.Margin = new Padding(4);
            this.m_chbSynthFreqMonOffset.Name = "m_chbSynthFreqMonOffset";
            this.m_chbSynthFreqMonOffset.Size = new Size(130, 21);
            this.m_chbSynthFreqMonOffset.TabIndex = 59;
            this.m_chbSynthFreqMonOffset.Text = "Synth Freq Mon";
            this.m_chbSynthFreqMonOffset.UseVisualStyleBackColor = true;
            this.m_btnAnalogFaultInjectionConfigSet.Location = new Point(435, 331);
            this.m_btnAnalogFaultInjectionConfigSet.Margin = new Padding(4);
            this.m_btnAnalogFaultInjectionConfigSet.Name = "m_btnAnalogFaultInjectionConfigSet";
            this.m_btnAnalogFaultInjectionConfigSet.Size = new Size(100, 37);
            this.m_btnAnalogFaultInjectionConfigSet.TabIndex = 58;
            this.m_btnAnalogFaultInjectionConfigSet.Text = "Set";
            this.m_btnAnalogFaultInjectionConfigSet.UseVisualStyleBackColor = true;
            this.m_btnAnalogFaultInjectionConfigSet.Click += this.m_btnAnalogFaultInjectionConfigSet_Click;
            this.m_chbSynthVCOOpenLoop.AutoSize = true;
            this.m_chbSynthVCOOpenLoop.Location = new Point(128, 263);
            this.m_chbSynthVCOOpenLoop.Margin = new Padding(4);
            this.m_chbSynthVCOOpenLoop.Name = "m_chbSynthVCOOpenLoop";
            this.m_chbSynthVCOOpenLoop.Size = new Size(95, 21);
            this.m_chbSynthVCOOpenLoop.TabIndex = 57;
            this.m_chbSynthVCOOpenLoop.Text = "SynthVCO";
            this.m_chbSynthVCOOpenLoop.UseVisualStyleBackColor = true;
            this.f000116.AutoSize = true;
            this.f000116.Location = new Point(128, 288);
            this.f000116.Margin = new Padding(4);
            this.f000116.Name = "m_chbLDORxLODistFault";
            this.f000116.Size = new Size(118, 21);
            this.f000116.TabIndex = 56;
            this.f000116.Text = "LDORxLODist";
            this.f000116.UseVisualStyleBackColor = true;
            this.f000117.AutoSize = true;
            this.f000117.Location = new Point(128, 318);
            this.f000117.Margin = new Padding(4);
            this.f000117.Name = "m_chbGPADCClkFreqFault";
            this.f000117.Size = new Size(126, 21);
            this.f000117.TabIndex = 54;
            this.f000117.Text = "GPADCClkFreq";
            this.f000117.UseVisualStyleBackColor = true;
            this.f000118.AutoSize = true;
            this.f000118.Location = new Point(128, 347);
            this.f000118.Margin = new Padding(4);
            this.f000118.Name = "m_chbGPADCIntSigMon";
            this.f000118.Size = new Size(140, 21);
            this.f000118.TabIndex = 51;
            this.f000118.Text = "GPADCIntSigMon";
            this.f000118.UseVisualStyleBackColor = true;
            this.m_chbExtAnaSigMon.AutoSize = true;
            this.m_chbExtAnaSigMon.Location = new Point(284, 350);
            this.m_chbExtAnaSigMon.Margin = new Padding(4);
            this.m_chbExtAnaSigMon.Name = "m_chbExtAnaSigMon";
            this.m_chbExtAnaSigMon.Size = new Size(121, 21);
            this.m_chbExtAnaSigMon.TabIndex = 50;
            this.m_chbExtAnaSigMon.Text = "ExtAnaSigMon";
            this.m_chbExtAnaSigMon.UseVisualStyleBackColor = true;
            this.m_chbExtAnaSigMon.Visible = false;
            this.m_chbTxGainInvTx2BPMVal.AutoSize = true;
            this.m_chbTxGainInvTx2BPMVal.Location = new Point(251, 238);
            this.m_chbTxGainInvTx2BPMVal.Margin = new Padding(4);
            this.m_chbTxGainInvTx2BPMVal.Name = "m_chbTxGainInvTx2BPMVal";
            this.m_chbTxGainInvTx2BPMVal.Size = new Size(86, 21);
            this.m_chbTxGainInvTx2BPMVal.TabIndex = 49;
            this.m_chbTxGainInvTx2BPMVal.Text = "Tx1 BPM";
            this.m_chbTxGainInvTx2BPMVal.UseVisualStyleBackColor = true;
            this.m_chbTxGainInvTx3BPMVal.AutoSize = true;
            this.m_chbTxGainInvTx3BPMVal.Location = new Point(375, 238);
            this.m_chbTxGainInvTx3BPMVal.Margin = new Padding(4);
            this.m_chbTxGainInvTx3BPMVal.Name = "m_chbTxGainInvTx3BPMVal";
            this.m_chbTxGainInvTx3BPMVal.Size = new Size(86, 21);
            this.m_chbTxGainInvTx3BPMVal.TabIndex = 48;
            this.m_chbTxGainInvTx3BPMVal.Text = "Tx2 BPM";
            this.m_chbTxGainInvTx3BPMVal.UseVisualStyleBackColor = true;
            this.m_chbTxGainInvTx1BPMVal.AutoSize = true;
            this.m_chbTxGainInvTx1BPMVal.Location = new Point(128, 238);
            this.m_chbTxGainInvTx1BPMVal.Margin = new Padding(4);
            this.m_chbTxGainInvTx1BPMVal.Name = "m_chbTxGainInvTx1BPMVal";
            this.m_chbTxGainInvTx1BPMVal.Size = new Size(86, 21);
            this.m_chbTxGainInvTx1BPMVal.TabIndex = 47;
            this.m_chbTxGainInvTx1BPMVal.Text = "Tx0 BPM";
            this.m_chbTxGainInvTx1BPMVal.UseVisualStyleBackColor = true;
            this.m_chbTxGainInvTxFault.AutoSize = true;
            this.m_chbTxGainInvTxFault.Location = new Point(479, 238);
            this.m_chbTxGainInvTxFault.Margin = new Padding(4);
            this.m_chbTxGainInvTxFault.Name = "m_chbTxGainInvTxFault";
            this.m_chbTxGainInvTxFault.Size = new Size(80, 21);
            this.m_chbTxGainInvTxFault.TabIndex = 46;
            this.m_chbTxGainInvTxFault.Text = "Tx Fault";
            this.m_chbTxGainInvTxFault.UseVisualStyleBackColor = true;
            this.m_chbTxGainDropTx3.AutoSize = true;
            this.m_chbTxGainDropTx3.Location = new Point(375, 210);
            this.m_chbTxGainDropTx3.Margin = new Padding(4);
            this.m_chbTxGainDropTx3.Name = "m_chbTxGainDropTx3";
            this.m_chbTxGainDropTx3.Size = new Size(53, 21);
            this.m_chbTxGainDropTx3.TabIndex = 44;
            this.m_chbTxGainDropTx3.Text = "Tx2";
            this.m_chbTxGainDropTx3.UseVisualStyleBackColor = true;
            this.m_chbTxGainDropTx2.AutoSize = true;
            this.m_chbTxGainDropTx2.Location = new Point(251, 210);
            this.m_chbTxGainDropTx2.Margin = new Padding(4);
            this.m_chbTxGainDropTx2.Name = "m_chbTxGainDropTx2";
            this.m_chbTxGainDropTx2.Size = new Size(53, 21);
            this.m_chbTxGainDropTx2.TabIndex = 43;
            this.m_chbTxGainDropTx2.Text = "Tx1";
            this.m_chbTxGainDropTx2.UseVisualStyleBackColor = true;
            this.m_chbTxGainDropTx1.AutoSize = true;
            this.m_chbTxGainDropTx1.Location = new Point(128, 210);
            this.m_chbTxGainDropTx1.Margin = new Padding(4);
            this.m_chbTxGainDropTx1.Name = "m_chbTxGainDropTx1";
            this.m_chbTxGainDropTx1.Size = new Size(53, 21);
            this.m_chbTxGainDropTx1.TabIndex = 42;
            this.m_chbTxGainDropTx1.Text = "Tx0";
            this.m_chbTxGainDropTx1.UseVisualStyleBackColor = true;
            this.m_chbTxLOAmpTx2.AutoSize = true;
            this.m_chbTxLOAmpTx2.Location = new Point(251, 181);
            this.m_chbTxLOAmpTx2.Margin = new Padding(4);
            this.m_chbTxLOAmpTx2.Name = "m_chbTxLOAmpTx2";
            this.m_chbTxLOAmpTx2.Size = new Size(53, 21);
            this.m_chbTxLOAmpTx2.TabIndex = 39;
            this.m_chbTxLOAmpTx2.Text = "Tx2";
            this.m_chbTxLOAmpTx2.UseVisualStyleBackColor = true;
            this.m_chbTxLOAmpTx0Tx1.AutoSize = true;
            this.m_chbTxLOAmpTx0Tx1.Location = new Point(128, 181);
            this.m_chbTxLOAmpTx0Tx1.Margin = new Padding(4);
            this.m_chbTxLOAmpTx0Tx1.Name = "m_chbTxLOAmpTx0Tx1";
            this.m_chbTxLOAmpTx0Tx1.Size = new Size(101, 21);
            this.m_chbTxLOAmpTx0Tx1.TabIndex = 38;
            this.m_chbTxLOAmpTx0Tx1.Text = "Tx0AndTx1";
            this.m_chbTxLOAmpTx0Tx1.UseVisualStyleBackColor = true;
            this.m_chbRxLOAmpRx2Rx3.AutoSize = true;
            this.m_chbRxLOAmpRx2Rx3.Location = new Point(251, 153);
            this.m_chbRxLOAmpRx2Rx3.Margin = new Padding(4);
            this.m_chbRxLOAmpRx2Rx3.Name = "m_chbRxLOAmpRx2Rx3";
            this.m_chbRxLOAmpRx2Rx3.Size = new Size(110, 21);
            this.m_chbRxLOAmpRx2Rx3.TabIndex = 36;
            this.m_chbRxLOAmpRx2Rx3.Text = "Rx2 and Rx3";
            this.m_chbRxLOAmpRx2Rx3.UseVisualStyleBackColor = true;
            this.m_chbRxLOAmpRx0Rx1.AutoSize = true;
            this.m_chbRxLOAmpRx0Rx1.Location = new Point(128, 153);
            this.m_chbRxLOAmpRx0Rx1.Margin = new Padding(4);
            this.m_chbRxLOAmpRx0Rx1.Name = "m_chbRxLOAmpRx0Rx1";
            this.m_chbRxLOAmpRx0Rx1.Size = new Size(102, 21);
            this.m_chbRxLOAmpRx0Rx1.TabIndex = 34;
            this.m_chbRxLOAmpRx0Rx1.Text = "Rx0andRx1";
            this.m_chbRxLOAmpRx0Rx1.UseVisualStyleBackColor = true;
            this.m_chbRxIFStageRx4.AutoSize = true;
            this.m_chbRxIFStageRx4.Location = new Point(479, 128);
            this.m_chbRxIFStageRx4.Margin = new Padding(4);
            this.m_chbRxIFStageRx4.Name = "m_chbRxIFStageRx4";
            this.m_chbRxIFStageRx4.Size = new Size(18, 17);
            this.m_chbRxIFStageRx4.TabIndex = 33;
            this.m_chbRxIFStageRx4.UseVisualStyleBackColor = true;
            this.m_chbRxIFStageRx3.AutoSize = true;
            this.m_chbRxIFStageRx3.Location = new Point(375, 128);
            this.m_chbRxIFStageRx3.Margin = new Padding(4);
            this.m_chbRxIFStageRx3.Name = "m_chbRxIFStageRx3";
            this.m_chbRxIFStageRx3.Size = new Size(18, 17);
            this.m_chbRxIFStageRx3.TabIndex = 32;
            this.m_chbRxIFStageRx3.UseVisualStyleBackColor = true;
            this.m_chbRxIFStageRx2.AutoSize = true;
            this.m_chbRxIFStageRx2.Location = new Point(251, 128);
            this.m_chbRxIFStageRx2.Margin = new Padding(4);
            this.m_chbRxIFStageRx2.Name = "m_chbRxIFStageRx2";
            this.m_chbRxIFStageRx2.Size = new Size(18, 17);
            this.m_chbRxIFStageRx2.TabIndex = 31;
            this.m_chbRxIFStageRx2.UseVisualStyleBackColor = true;
            this.m_chbRxIFStageRx1.AutoSize = true;
            this.m_chbRxIFStageRx1.Location = new Point(128, 128);
            this.m_chbRxIFStageRx1.Margin = new Padding(4);
            this.m_chbRxIFStageRx1.Name = "m_chbRxIFStageRx1";
            this.m_chbRxIFStageRx1.Size = new Size(18, 17);
            this.m_chbRxIFStageRx1.TabIndex = 30;
            this.m_chbRxIFStageRx1.UseVisualStyleBackColor = true;
            this.m_chbRxHighNoiseRx4.AutoSize = true;
            this.m_chbRxHighNoiseRx4.Location = new Point(479, 102);
            this.m_chbRxHighNoiseRx4.Margin = new Padding(4);
            this.m_chbRxHighNoiseRx4.Name = "m_chbRxHighNoiseRx4";
            this.m_chbRxHighNoiseRx4.Size = new Size(18, 17);
            this.m_chbRxHighNoiseRx4.TabIndex = 29;
            this.m_chbRxHighNoiseRx4.UseVisualStyleBackColor = true;
            this.m_chbRxHighNoiseRx3.AutoSize = true;
            this.m_chbRxHighNoiseRx3.Location = new Point(375, 102);
            this.m_chbRxHighNoiseRx3.Margin = new Padding(4);
            this.m_chbRxHighNoiseRx3.Name = "m_chbRxHighNoiseRx3";
            this.m_chbRxHighNoiseRx3.Size = new Size(18, 17);
            this.m_chbRxHighNoiseRx3.TabIndex = 28;
            this.m_chbRxHighNoiseRx3.UseVisualStyleBackColor = true;
            this.m_chbRxHighNoiseRx2.AutoSize = true;
            this.m_chbRxHighNoiseRx2.Location = new Point(251, 102);
            this.m_chbRxHighNoiseRx2.Margin = new Padding(4);
            this.m_chbRxHighNoiseRx2.Name = "m_chbRxHighNoiseRx2";
            this.m_chbRxHighNoiseRx2.Size = new Size(18, 17);
            this.m_chbRxHighNoiseRx2.TabIndex = 27;
            this.m_chbRxHighNoiseRx2.UseVisualStyleBackColor = true;
            this.m_chbRxHighNoiseRx1.AutoSize = true;
            this.m_chbRxHighNoiseRx1.Location = new Point(128, 102);
            this.m_chbRxHighNoiseRx1.Margin = new Padding(4);
            this.m_chbRxHighNoiseRx1.Name = "m_chbRxHighNoiseRx1";
            this.m_chbRxHighNoiseRx1.Size = new Size(18, 17);
            this.m_chbRxHighNoiseRx1.TabIndex = 26;
            this.m_chbRxHighNoiseRx1.UseVisualStyleBackColor = true;
            this.m_chbRxPhaseInvRx4.AutoSize = true;
            this.m_chbRxPhaseInvRx4.Location = new Point(479, 76);
            this.m_chbRxPhaseInvRx4.Margin = new Padding(4);
            this.m_chbRxPhaseInvRx4.Name = "m_chbRxPhaseInvRx4";
            this.m_chbRxPhaseInvRx4.Size = new Size(18, 17);
            this.m_chbRxPhaseInvRx4.TabIndex = 25;
            this.m_chbRxPhaseInvRx4.UseVisualStyleBackColor = true;
            this.m_chbRxPhaseInvRx3.AutoSize = true;
            this.m_chbRxPhaseInvRx3.Location = new Point(375, 76);
            this.m_chbRxPhaseInvRx3.Margin = new Padding(4);
            this.m_chbRxPhaseInvRx3.Name = "m_chbRxPhaseInvRx3";
            this.m_chbRxPhaseInvRx3.Size = new Size(18, 17);
            this.m_chbRxPhaseInvRx3.TabIndex = 24;
            this.m_chbRxPhaseInvRx3.UseVisualStyleBackColor = true;
            this.m_chbRxPhaseInvRx2.AutoSize = true;
            this.m_chbRxPhaseInvRx2.Location = new Point(251, 76);
            this.m_chbRxPhaseInvRx2.Margin = new Padding(4);
            this.m_chbRxPhaseInvRx2.Name = "m_chbRxPhaseInvRx2";
            this.m_chbRxPhaseInvRx2.Size = new Size(18, 17);
            this.m_chbRxPhaseInvRx2.TabIndex = 23;
            this.m_chbRxPhaseInvRx2.UseVisualStyleBackColor = true;
            this.m_chbRxPhaseInvRx1.AutoSize = true;
            this.m_chbRxPhaseInvRx1.Location = new Point(128, 76);
            this.m_chbRxPhaseInvRx1.Margin = new Padding(4);
            this.m_chbRxPhaseInvRx1.Name = "m_chbRxPhaseInvRx1";
            this.m_chbRxPhaseInvRx1.Size = new Size(18, 17);
            this.m_chbRxPhaseInvRx1.TabIndex = 22;
            this.m_chbRxPhaseInvRx1.UseVisualStyleBackColor = true;
            this.m_chbRxGainDropRx4.AutoSize = true;
            this.m_chbRxGainDropRx4.Location = new Point(479, 47);
            this.m_chbRxGainDropRx4.Margin = new Padding(4);
            this.m_chbRxGainDropRx4.Name = "m_chbRxGainDropRx4";
            this.m_chbRxGainDropRx4.Size = new Size(18, 17);
            this.m_chbRxGainDropRx4.TabIndex = 21;
            this.m_chbRxGainDropRx4.UseVisualStyleBackColor = true;
            this.m_chbRxGainDropRx3.AutoSize = true;
            this.m_chbRxGainDropRx3.Location = new Point(375, 47);
            this.m_chbRxGainDropRx3.Margin = new Padding(4);
            this.m_chbRxGainDropRx3.Name = "m_chbRxGainDropRx3";
            this.m_chbRxGainDropRx3.Size = new Size(18, 17);
            this.m_chbRxGainDropRx3.TabIndex = 20;
            this.m_chbRxGainDropRx3.UseVisualStyleBackColor = true;
            this.m_chbRxGainDropRx2.AutoSize = true;
            this.m_chbRxGainDropRx2.Location = new Point(251, 47);
            this.m_chbRxGainDropRx2.Margin = new Padding(4);
            this.m_chbRxGainDropRx2.Name = "m_chbRxGainDropRx2";
            this.m_chbRxGainDropRx2.Size = new Size(18, 17);
            this.m_chbRxGainDropRx2.TabIndex = 19;
            this.m_chbRxGainDropRx2.UseVisualStyleBackColor = true;
            this.m_chbRxGainDropRx1.AutoSize = true;
            this.m_chbRxGainDropRx1.Location = new Point(128, 47);
            this.m_chbRxGainDropRx1.Margin = new Padding(4);
            this.m_chbRxGainDropRx1.Name = "m_chbRxGainDropRx1";
            this.m_chbRxGainDropRx1.Size = new Size(18, 17);
            this.m_chbRxGainDropRx1.TabIndex = 18;
            this.m_chbRxGainDropRx1.UseVisualStyleBackColor = true;
            this.label59.AutoSize = true;
            this.label59.Location = new Point(475, 23);
            this.label59.Margin = new Padding(4, 0, 4, 0);
            this.label59.Name = "label59";
            this.label59.Size = new Size(32, 17);
            this.label59.TabIndex = 17;
            this.label59.Text = "Rx3";
            this.label60.AutoSize = true;
            this.label60.Location = new Point(371, 23);
            this.label60.Margin = new Padding(4, 0, 4, 0);
            this.label60.Name = "label60";
            this.label60.Size = new Size(32, 17);
            this.label60.TabIndex = 16;
            this.label60.Text = "Rx2";
            this.label52.AutoSize = true;
            this.label52.Location = new Point(245, 23);
            this.label52.Margin = new Padding(4, 0, 4, 0);
            this.label52.Name = "label52";
            this.label52.Size = new Size(32, 17);
            this.label52.TabIndex = 15;
            this.label52.Text = "Rx1";
            this.label58.AutoSize = true;
            this.label58.Location = new Point(127, 23);
            this.label58.Margin = new Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new Size(32, 17);
            this.label58.TabIndex = 14;
            this.label58.Text = "Rx0";
            this.label48.AutoSize = true;
            this.label48.Location = new Point(5, 351);
            this.label48.Margin = new Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new Size(104, 17);
            this.label48.TabIndex = 11;
            this.label48.Text = "Misc Threshold";
            this.label49.AutoSize = true;
            this.label49.Location = new Point(5, 318);
            this.label49.Margin = new Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new Size(71, 17);
            this.label49.TabIndex = 10;
            this.label49.Text = "Misc Fault";
            this.label46.AutoSize = true;
            this.label46.Location = new Point(5, 287);
            this.label46.Margin = new Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new Size(119, 17);
            this.label46.TabIndex = 9;
            this.label46.Text = "Supply LDO Fault";
            this.label47.AutoSize = true;
            this.label47.Location = new Point(5, 263);
            this.label47.Margin = new Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new Size(79, 17);
            this.label47.TabIndex = 8;
            this.label47.Text = "Synth Fault";
            this.label44.AutoSize = true;
            this.label44.Location = new Point(5, 180);
            this.label44.Margin = new Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new Size(78, 17);
            this.label44.TabIndex = 7;
            this.label44.Text = "Tx LO Amp";
            this.label45.AutoSize = true;
            this.label45.Location = new Point(5, 155);
            this.label45.Margin = new Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new Size(79, 17);
            this.label45.TabIndex = 6;
            this.label45.Text = "Rx LO Amp";
            this.label42.AutoSize = true;
            this.label42.Location = new Point(5, 239);
            this.label42.Margin = new Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new Size(89, 17);
            this.label42.TabIndex = 5;
            this.label42.Text = "Tx Phase Inv";
            this.label43.AutoSize = true;
            this.label43.Location = new Point(5, 210);
            this.label43.Margin = new Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new Size(92, 17);
            this.label43.TabIndex = 4;
            this.label43.Text = "Tx Gain Drop";
            this.label40.AutoSize = true;
            this.label40.Location = new Point(5, 126);
            this.label40.Margin = new Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new Size(80, 17);
            this.label40.TabIndex = 3;
            this.label40.Text = "Rx IF Stage";
            this.label41.AutoSize = true;
            this.label41.Location = new Point(5, 101);
            this.label41.Margin = new Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new Size(97, 17);
            this.label41.TabIndex = 2;
            this.label41.Text = "Rx High Noise";
            this.label39.AutoSize = true;
            this.label39.Location = new Point(5, 76);
            this.label39.Margin = new Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new Size(90, 17);
            this.label39.TabIndex = 1;
            this.label39.Text = "Rx Phase Inv";
            this.label38.AutoSize = true;
            this.label38.Location = new Point(5, 47);
            this.label38.Margin = new Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new Size(93, 17);
            this.label38.TabIndex = 0;
            this.label38.Text = "Rx Gain Drop";
            base.AutoScaleDimensions = new SizeF(8f, 16f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.m_grpAnalogMonitoringRFEnablesConfig);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.m_grpMonitoringTxBPMPhaseConfig);
            base.Controls.Add(this.label79);
            base.Controls.Add(this.label78);
            base.Controls.Add(this.label77);
            base.Controls.Add(this.label72);
            base.Controls.Add(this.m_grpTXBallBreakMonitoringConfig);
            base.Controls.Add(this.m_grpMonitoringTX1PowerConfig);
            base.Margin = new Padding(4);
            base.Name = "AnalogMonConfig";
            base.Size = new Size(1801, 721);
            this.m_grpMonitoringTX1PowerConfig.ResumeLayout(false);
            this.m_grpMonitoringTX1PowerConfig.PerformLayout();
            ((ISupportInitialize)this.m_nudTX3PowerReportingMode).EndInit();
            ((ISupportInitialize)this.m_nudTX2PowerReportingMode).EndInit();
            ((ISupportInitialize)this.m_nudTX1PowerReportingMode).EndInit();
            ((ISupportInitialize)this.m_nudTX3PwFlatnessThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX2PwFlatnessThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX3PwAbsErrThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX2PwAbsErrThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTXPwFlatnessThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTXPwAbsErrThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX3PwrMonProfileIndex).EndInit();
            ((ISupportInitialize)this.m_nudTX2PwrMonProfileIndex).EndInit();
            ((ISupportInitialize)this.m_nudTXPwrMonProfileIndex).EndInit();
            this.m_grpTXBallBreakMonitoringConfig.ResumeLayout(false);
            this.m_grpTXBallBreakMonitoringConfig.PerformLayout();
            ((ISupportInitialize)this.m_nudTX3BallBreakMonReportingMode).EndInit();
            ((ISupportInitialize)this.m_nudTX2BallBreakMonReportingMode).EndInit();
            ((ISupportInitialize)this.m_nudTX1BallBreakMonReportingMode).EndInit();
            ((ISupportInitialize)this.m_nudTX3ReflCoeffMagThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX2ReflCoeffMagThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX1ReflCoeffMagThreshold).EndInit();
            this.m_grpMonitoringTxBPMPhaseConfig.ResumeLayout(false);
            this.m_grpMonitoringTxBPMPhaseConfig.PerformLayout();
            ((ISupportInitialize)this.f000128).EndInit();
            ((ISupportInitialize)this.f000129).EndInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonPhaseShift2).EndInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonPhaseShift1).EndInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonPhaseShiftCfg).EndInit();
            ((ISupportInitialize)this.f00012a).EndInit();
            ((ISupportInitialize)this.f00012b).EndInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonPhaseShift2).EndInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonPhaseShift1).EndInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonPhaseShiftCfg).EndInit();
            ((ISupportInitialize)this.f00012c).EndInit();
            ((ISupportInitialize)this.f00012d).EndInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonPhaseShift2).EndInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonPhaseShift1).EndInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonPhaseShiftCfg).EndInit();
            ((ISupportInitialize)this.m_nudTX3BPMAmplitudeMonErrorThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonErrorThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonReportMode).EndInit();
            ((ISupportInitialize)this.m_nudTX3BPMPhaseMonProfileIndex).EndInit();
            ((ISupportInitialize)this.m_nudTX2BPMAmplitudeMonErrorThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonErrorThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonReportMode).EndInit();
            ((ISupportInitialize)this.m_nudTX2BPMPhaseMonProfileIndex).EndInit();
            ((ISupportInitialize)this.m_nudTX1BPMAmplitudeMonErrorThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonErrorThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonReportMode).EndInit();
            ((ISupportInitialize)this.m_nudTX1BPMPhaseMonProfileIndex).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize)this.m_nudRF1TX3TXPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF1TX2TXPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF1TX1TXPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF3TX3TXPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF3TX2TXPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF3TX1TXPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF2TX3TXPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF2TX2TXPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF2TX1TXPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF3TX3TXGainPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF3TX2TXGainPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF3TX1TXGainPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF2TX3TXGainPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF2TX2TXGainPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF2TX1TXGainPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF1TX3TXGainPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF1TX2TXGainPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudRF1TX1TXGainPhaseMismatchOffVal).EndInit();
            ((ISupportInitialize)this.m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold).EndInit();
            ((ISupportInitialize)this.m_nudTxGainPhaseMismacthMonReportingMode).EndInit();
            ((ISupportInitialize)this.m_nudTxGainPhaseMismacthMonProfileIndex).EndInit();
            this.m_grpAnalogMonitoringRFEnablesConfig.ResumeLayout(false);
            this.m_grpAnalogMonitoringRFEnablesConfig.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private GuiManager m_GuiManager = GlobalRef.GuiManager;

        private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

        private frmAR1Main m_MainForm;

        private MonRFEnablesConfigParameters m_MonRFEnablesConfigParameters;

        private MonTX1PowerConfigParameters m_MonTX1PowerConfigParameters;

        private MonTX2PowerConfigParameters m_MonTX2PowerConfigParameters;

        private MonTX3PowerConfigParameters m_MonTX3PowerConfigParameters;

        private MonTx1BallBreakConfigParameters m_MonTx1BallBreakConfigParameters;

        private MonTx2BallBreakConfigParameters m_MonTx2BallBreakConfigParameters;

        private MonTx3BallBreakConfigParameters m_MonTx3BallBreakConfigParameters;

        private MonTx1BPMPhaseConfigParameters m_MonTx1BPMPhaseConfigParameters;

        private MonTx2BPMPhaseConfigParameters m_MonTx2BPMPhaseConfigParameters;

        private MonTx3BPMPhaseConfigParameters m_MonTx3BPMPhaseConfigParameters;

        private MonTxGainPhaseMismatchConfigParameters m_MonTxGainPhaseMismatchConfigParameters;

        private AnalogFaultInjectionConfigParameters m_AnalogFaultInjectionConfigParameters;

        private MonSynthFrequencyConfigParameters m_MonSynthFrequencyConfigParameters;

        private IContainer components;

        private GroupBox m_grpMonitoringTX1PowerConfig;

        private Label label30;

        private Label label29;

        private Label label28;

        private Label label27;

        private Label label26;

        private GroupBox m_grpTXBallBreakMonitoringConfig;

        private Label label32;

        private Label label31;

        private NumericUpDown m_nudTX3PwrMonProfileIndex;

        private NumericUpDown m_nudTX2PwrMonProfileIndex;

        private NumericUpDown m_nudTXPwrMonProfileIndex;

        private Label label33;

        private NumericUpDown m_nudTXPwFlatnessThreshold;

        private NumericUpDown m_nudTXPwAbsErrThreshold;

        private CheckBox f000103;

        private CheckBox f000104;

        private CheckBox f000105;

        private Button m_btnTX1PowerMonConfigSet;

        private Label label63;

        private Label label64;

        private Label label36;

        private Label label35;

        private Label label34;

        private CheckBox f000106;

        private CheckBox f000107;

        private CheckBox f000108;

        private CheckBox f000109;

        private CheckBox f00010a;

        private CheckBox f00010b;

        private Button m_btnTX3PowerMonConfigSet;

        private Button m_btnTX2PowerMonConfigSet;

        private NumericUpDown m_nudTX3PwFlatnessThreshold;

        private NumericUpDown m_nudTX2PwFlatnessThreshold;

        private NumericUpDown m_nudTX3PwAbsErrThreshold;

        private NumericUpDown m_nudTX2PwAbsErrThreshold;

        private Label label57;

        private Label label56;

        private Label label55;

        private Label label54;

        private Label label53;

        private Button m_btnTX3BallBreakMonConfigSet;

        private Button m_btnTX2BallBreakMonConfigSet;

        private Button m_btnTX1BallBreakMonConfigSet;

        private NumericUpDown m_nudTX3ReflCoeffMagThreshold;

        private NumericUpDown m_nudTX2ReflCoeffMagThreshold;

        private NumericUpDown m_nudTX1ReflCoeffMagThreshold;

        private Label label72;

        private Label label77;

        private Label label78;

        private Label label79;

        private NumericUpDown m_nudTX3PowerReportingMode;

        private NumericUpDown m_nudTX2PowerReportingMode;

        private NumericUpDown m_nudTX1PowerReportingMode;

        private NumericUpDown m_nudTX3BallBreakMonReportingMode;

        private NumericUpDown m_nudTX2BallBreakMonReportingMode;

        private NumericUpDown m_nudTX1BallBreakMonReportingMode;

        private GroupBox m_grpMonitoringTxBPMPhaseConfig;

        private NumericUpDown m_nudTX1BPMPhaseMonProfileIndex;

        private Button f00010c;

        private Button f00010d;

        private Button f00010e;

        private Label label81;

        private Label label80;

        private NumericUpDown m_nudTX3BPMAmplitudeMonErrorThreshold;

        private NumericUpDown m_nudTX3BPMPhaseMonErrorThreshold;

        private NumericUpDown m_nudTX3BPMPhaseMonReportMode;

        private NumericUpDown m_nudTX3BPMPhaseMonProfileIndex;

        private NumericUpDown m_nudTX2BPMAmplitudeMonErrorThreshold;

        private NumericUpDown m_nudTX2BPMPhaseMonErrorThreshold;

        private NumericUpDown m_nudTX2BPMPhaseMonReportMode;

        private NumericUpDown m_nudTX2BPMPhaseMonProfileIndex;

        private NumericUpDown m_nudTX1BPMAmplitudeMonErrorThreshold;

        private NumericUpDown m_nudTX1BPMPhaseMonErrorThreshold;

        private NumericUpDown m_nudTX1BPMPhaseMonReportMode;

        private GroupBox groupBox1;

        private Label label90;

        private NumericUpDown m_nudRF1TX1TXGainPhaseMismatchOffVal;

        private NumericUpDown m_nudTxGainPhaseMismacthMonTxPhaseMismatchThreshold;

        private NumericUpDown m_nudTxGainPhaseMismacthMonTxGainMismatchThreshold;

        private NumericUpDown m_nudTxGainPhaseMismacthMonReportingMode;

        private CheckBox m_chbTXGainPhaseMismatchMonTx3;

        private CheckBox m_chbTXGainPhaseMismatchMonTx2;

        private CheckBox m_chbTXGainPhaseMismatchMonTx1;

        private CheckBox m_chbRF3TXGainPhaseMismatchMonBitMask;

        private CheckBox m_chbRF2TXGainPhaseMismatchMonBitMask;

        private CheckBox m_chbRF1TXGainPhaseMismatchMonBitMask;

        private NumericUpDown m_nudTxGainPhaseMismacthMonProfileIndex;

        private Label label86;

        private Label label87;

        private Label label88;

        private Label label89;

        private Label label85;

        private Label label84;

        private Label label83;

        private Label label82;

        private Label label102;

        private Label label101;

        private Label label100;

        private Label label99;

        private Label label98;

        private Label label97;

        private Label label96;

        private Label label95;

        private Label label94;

        private Label label93;

        private Label label92;

        private Label label91;

        private NumericUpDown m_nudRF1TX3TXPhaseMismatchOffVal;

        private NumericUpDown m_nudRF1TX2TXPhaseMismatchOffVal;

        private NumericUpDown m_nudRF1TX1TXPhaseMismatchOffVal;

        private NumericUpDown m_nudRF3TX3TXPhaseMismatchOffVal;

        private NumericUpDown m_nudRF3TX2TXPhaseMismatchOffVal;

        private NumericUpDown m_nudRF3TX1TXPhaseMismatchOffVal;

        private NumericUpDown m_nudRF2TX3TXPhaseMismatchOffVal;

        private NumericUpDown m_nudRF2TX2TXPhaseMismatchOffVal;

        private NumericUpDown m_nudRF2TX1TXPhaseMismatchOffVal;

        private NumericUpDown m_nudRF3TX3TXGainPhaseMismatchOffVal;

        private NumericUpDown m_nudRF3TX2TXGainPhaseMismatchOffVal;

        private NumericUpDown m_nudRF3TX1TXGainPhaseMismatchOffVal;

        private NumericUpDown m_nudRF2TX3TXGainPhaseMismatchOffVal;

        private NumericUpDown m_nudRF2TX2TXGainPhaseMismatchOffVal;

        private NumericUpDown m_nudRF2TX1TXGainPhaseMismatchOffVal;

        private NumericUpDown m_nudRF1TX3TXGainPhaseMismatchOffVal;

        private NumericUpDown m_nudRF1TX2TXGainPhaseMismatchOffVal;

        private Button m_btnTXGainPhaseMismatchMonConfigSet;

        private GroupBox m_grpAnalogMonitoringRFEnablesConfig;

        private CheckBox m_chbRXMixerInputPowerMonEna;

        private Label label118;

        private Label label131;

        private CheckBox m_chbRXSigImgBandMonEna;

        private Button m_btnAnalogMonRFEnablesMonConfigSet;

        private CheckBox f00010f;

        private Label label25;

        private Label label19;

        private Label label20;

        private Label label21;

        private Label label22;

        private Label label23;

        private Label label24;

        private Label label13;

        private Label label14;

        private Label label15;

        private Label label16;

        private Label label17;

        private Label label18;

        private Label label7;

        private Label label8;

        private Label label9;

        private Label label10;

        private Label label11;

        private Label label12;

        private Label label6;

        private Label label5;

        private Label label4;

        private Label label3;

        private Label label2;

        private Label label1;

        private CheckBox f000110;

        private CheckBox f000111;

        private CheckBox m_chbInternalRXSignalsMonEna;

        private CheckBox m_chbInternalTX3SignalsMonEna;

        private CheckBox m_chbInternalTX2SignalsMonEna;

        private CheckBox m_chbPLLControlVolMonEna;

        private CheckBox m_chbDCCClockFreqMonEna;

        private CheckBox m_chbTemperatureMonEna;

        private CheckBox m_chbInternalTX1SignalsMonEna;

        private CheckBox m_chbExternalAnalogSignalsMonEna;

        private CheckBox m_chbSynthFreqMonEna;

        private CheckBox f000112;

        private CheckBox f000113;

        private CheckBox f000114;

        private CheckBox m_chbTXGainPhaseMonEna;

        private CheckBox m_chbTX3BallBreakMonEna;

        private CheckBox m_chbTX2BallBreakMonEna;

        private CheckBox m_chbTX1BallBreakMonEna;

        private CheckBox m_chbTX3PowerMonEna;

        private CheckBox m_chbTX2PowerMonEna;

        private CheckBox m_chbTX1PowerMonEna;

        private CheckBox f000115;

        private CheckBox m_chbRXNoiseMonEna;

        private CheckBox m_chbRXGainPhaseMonEna;

        private CheckBox m_chbReservedMonEna;

        private Label label37;

        private GroupBox groupBox2;

        private CheckBox m_chbSynthVCOOpenLoop;

        private CheckBox f000116;

        private CheckBox f000117;

        private CheckBox f000118;

        private CheckBox m_chbExtAnaSigMon;

        private CheckBox m_chbTxGainInvTx2BPMVal;

        private CheckBox m_chbTxGainInvTx3BPMVal;

        private CheckBox m_chbTxGainInvTx1BPMVal;

        private CheckBox m_chbTxGainInvTxFault;

        private CheckBox m_chbTxGainDropTx3;

        private CheckBox m_chbTxGainDropTx2;

        private CheckBox m_chbTxGainDropTx1;

        private CheckBox m_chbTxLOAmpTx2;

        private CheckBox m_chbTxLOAmpTx0Tx1;

        private CheckBox m_chbRxLOAmpRx2Rx3;

        private CheckBox m_chbRxLOAmpRx0Rx1;

        private CheckBox m_chbRxIFStageRx4;

        private CheckBox m_chbRxIFStageRx3;

        private CheckBox m_chbRxIFStageRx2;

        private CheckBox m_chbRxIFStageRx1;

        private CheckBox m_chbRxHighNoiseRx4;

        private CheckBox m_chbRxHighNoiseRx3;

        private CheckBox m_chbRxHighNoiseRx2;

        private CheckBox m_chbRxHighNoiseRx1;

        private CheckBox m_chbRxPhaseInvRx4;

        private CheckBox m_chbRxPhaseInvRx3;

        private CheckBox m_chbRxPhaseInvRx2;

        private CheckBox m_chbRxPhaseInvRx1;

        private CheckBox m_chbRxGainDropRx4;

        private CheckBox m_chbRxGainDropRx3;

        private CheckBox m_chbRxGainDropRx2;

        private CheckBox m_chbRxGainDropRx1;

        private Label label59;

        private Label label60;

        private Label label52;

        private Label label58;

        private Label label48;

        private Label label49;

        private Label label46;

        private Label label47;

        private Label label44;

        private Label label45;

        private Label label42;

        private Label label43;

        private Label label40;

        private Label label41;

        private Label label39;

        private Label label38;

        private Button m_btnAnalogFaultInjectionConfigSet;

        private CheckBox m_chbSynthFreqMonOffset;

        private CheckBox m_chbTXGainPhaseMismatchMonRx0;

        private Label label50;

        private CheckBox m_chbTXGainPhaseMismatchMonRx1;

        private CheckBox m_chbTXGainPhaseMismatchMonRx3;

        private CheckBox m_chbTXGainPhaseMismatchMonRx2;

        private Label label51;

        private CheckBox f000119;

        private CheckBox f00011a;

        private CheckBox f00011b;

        private CheckBox f00011c;

        private CheckBox f00011d;

        private CheckBox f00011e;

        private CheckBox f00011f;

        private CheckBox f000120;

        private CheckBox f000121;

        private CheckBox f000122;

        private CheckBox f000123;

        private CheckBox f000124;

        private CheckBox f000125;

        private CheckBox f000126;

        private CheckBox f000127;

        private Label label65;

        private Label label62;

        private Label label61;

        private NumericUpDown f000128;

        private NumericUpDown f000129;

        private NumericUpDown m_nudTX3BPMPhaseMonPhaseShift2;

        private NumericUpDown m_nudTX3BPMPhaseMonPhaseShift1;

        private NumericUpDown m_nudTX3BPMPhaseMonPhaseShiftCfg;

        private NumericUpDown f00012a;

        private NumericUpDown f00012b;

        private NumericUpDown m_nudTX2BPMPhaseMonPhaseShift2;

        private NumericUpDown m_nudTX2BPMPhaseMonPhaseShift1;

        private NumericUpDown m_nudTX2BPMPhaseMonPhaseShiftCfg;

        private Label label75;

        private NumericUpDown f00012c;

        private NumericUpDown f00012d;

        private Label label74;

        private Label label73;

        private Label label71;

        private NumericUpDown m_nudTX1BPMPhaseMonPhaseShift2;

        private NumericUpDown m_nudTX1BPMPhaseMonPhaseShift1;

        private NumericUpDown m_nudTX1BPMPhaseMonPhaseShiftCfg;

        private Label label70;

        private Label label69;

        private Label label68;

        private CheckBox m_chbTX2BPMMonPhaseShiftIncMonValEna;

        private CheckBox m_chbTX2BPMMonPhaseShiftMonEna;

        private CheckBox m_chbTX1BPMMonPhaseShiftIncMonValEna;

        private CheckBox m_chbTX1BPMMonPhaseShiftMonEna;

        private CheckBox m_chbTX0BPMMonPhaseShiftIncMonValEna;

        private CheckBox m_chbTX0BPMMonPhaseShiftMonEna;
    }
}
