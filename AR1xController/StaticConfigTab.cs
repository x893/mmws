using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
    public class StaticConfigTab : UserControl
    {
        public StaticConfigTab()
        {
            this.InitializeComponent();

            this.PostInitialization();
            this.m_RadarDeviceMode.SelectedIndex = 0;
            this.m_MainForm = this.m_GuiManager.MainTsForm;
            this.m_StaticParams = this.m_GuiManager.TsParams.StaticParams;
            this.m_RFMiscConfigParams = this.m_GuiManager.TsParams.RFMiscConfigParams;
            this.m_LpModConfParams = this.m_GuiManager.TsParams.LpModConfParams;
            this.m_RFLDOBypassEnableAndDisableConfigParameters = this.m_GuiManager.TsParams.RFLDOBypassEnableAndDisableConfigParameters;
            this.m_RFCalibFrequencyLimitConfigParameters = this.m_GuiManager.TsParams.RFCalibFrequencyLimitConfigParameters;
            this.m_CalMonFrequencyTxPowerLimitConfigParameters = this.m_GuiManager.TsParams.CalMonFrequencyTxPowerLimitConfigParameters;
            this.m_RFDeviceAEControlConfigParameters = this.m_GuiManager.TsParams.RFDeviceAEControlConfigParameters;
            this.UpdateBasicConfData();
            this.UpdateLpModConfData();
            this.m_comSupplyMonIRDrop.SelectedIndex = 0;
            this.m_comSupplyMonIOSupply.SelectedIndex = 0;
            this.f00023a.SelectedIndex = 1;
            this.f000239.SelectedIndex = 1;
            this.f000238.SelectedIndex = 0;
            this.m_grpFreqLimitsConfig.Visible = true;
        }

        public bool UpdateStaticConfig(RootObject jobject, int p1)
        {
            bool result;
            try
            {
                if (jobject.mmWaveDevices[p1].rfConfig.rlChanCfg_t.isConfigured == 0)
                {
                    string msg = string.Format("Missing Channel Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg);
                }
                else
                {
                    int num = Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChanCfg_t.p000007, 16);
                    int num2 = Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChanCfg_t.p000006, 16);

                    this.cbEnableTx1.Checked = ((num & 1) == 1);
                    this.cbEnableTx2.Checked = ((num & 2) >> 1 == 1);
                    this.cbEnableTx3.Checked = ((num & 4) >> 2 == 1);

                    this.cbEnableRx1.Checked = ((num2 & 1) == 1);
                    this.cbEnableRx2.Checked = ((num2 & 2) >> 1 == 1);
                    this.cbEnableRx3.Checked = ((num2 & 4) >> 2 == 1);
                    this.cbEnableRx4.Checked = ((num2 & 8) >> 3 == 1);
                    this.m_RadarDeviceMode.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlChanCfg_t.cascading;
                    this.m_chkClkOutMasterDis.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChanCfg_t.cascadingPinoutCfg, 16) & 1) == 1);
                    this.m_chkSynOutMasterDis.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChanCfg_t.cascadingPinoutCfg, 16) & 2) >> 1 == 1);
                    this.m_chkClkOutSlaveEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChanCfg_t.cascadingPinoutCfg, 16) & 4) >> 2 == 1);
                    this.m_chkSynOutSlaveEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChanCfg_t.cascadingPinoutCfg, 16) & 8) >> 3 == 1);
                    this.m_chkIntLOMasterEna.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChanCfg_t.cascadingPinoutCfg, 16) & 16) >> 4 == 1);
                    this.m_chkOSCClkOutMasterDis.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChanCfg_t.cascadingPinoutCfg, 16) & 32) >> 5 == 1);
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlAdcOutCfg_t.isConfigured == 0)
                {
                    string msg2 = string.Format("Missing ADC Output Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg2);
                }
                else
                {
                    this.m_comBits.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlAdcOutCfg_t.fmt.b2AdcBits;
                    this.m_comFmts.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlAdcOutCfg_t.fmt.b2AdcOutFmt;
                    this.m_nudFullScaleReductionFactor.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdcOutCfg_t.fmt.b8FullScaleReducFctr;
                }
                if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataFmtCfg_t.isConfigured == 0)
                {
                    string msg3 = string.Format("Missing Device Data Format Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg3);
                }
                else
                {
                    this.m_comIQSwap.SelectedIndex = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataFmtCfg_t.iqSwapSel;
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlLowPowerModeCfg_t.isConfigured == 0)
                {
                    string msg4 = string.Format("Missing Low Power Mode Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg4);
                }
                else
                {
                    this.m_comLpAdcMod.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlLowPowerModeCfg_t.lpAdcMode;
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlRfLdoBypassCfg_t.isConfigured == 0)
                {
                    string msg5 = string.Format("Missing LDO Bypass Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg5);
                }
                else
                {
                    this.f000237.Checked = ((jobject.mmWaveDevices[p1].rfConfig.rlRfLdoBypassCfg_t.ldoBypassEnable & 1) == 1);
                    this.f00023b.Checked = ((jobject.mmWaveDevices[p1].rfConfig.rlRfLdoBypassCfg_t.ldoBypassEnable & 2) >> 1 == 0);
                    this.m_comSupplyMonIRDrop.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlRfLdoBypassCfg_t.supplyMonIrDrop;
                    if (jobject.mmWaveDevices[p1].rfConfig.rlRfLdoBypassCfg_t.ioSupplyIndicator == 0)
                    {
                        this.m_comSupplyMonIOSupply.SelectedIndex = 0;
                    }
                    else if (jobject.mmWaveDevices[p1].rfConfig.rlRfLdoBypassCfg_t.ioSupplyIndicator == 1)
                    {
                        this.m_comSupplyMonIOSupply.SelectedIndex = 1;
                    }
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlRfMiscConf_t.isConfigured == 0)
                {
                    string msg6 = string.Format("Missing Per Chip Phase shifter Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg6);
                }
                else if (GlobalRef.g_AR12xxDevice)
                {
                    this.m_chkPerChirpPhaseShifterEnable.Checked = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlRfMiscConf_t.miscCtl, 16) == 1);
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlRfCalMonFreqLimitConf_t.isConfigured == 0)
                {
                    string msg7 = string.Format("Missing Calib Monitoring Frequency Limits Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg7);
                }
                else
                {
                    this.m_nudFreqLimitLow.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlRfCalMonFreqLimitConf_t.freqLimitLow_GHz;
                    this.m_nudFreqLimitHigh.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlRfCalMonFreqLimitConf_t.freqLimitHigh_GHz;
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlRfTxFreqPwrLimitMonConf_t.isConfigured == 0)
                {
                    string msg8 = string.Format("Missing TX Frequency and Power Limit Monitoring Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg8);
                }
                else
                {
                    this.m_nudFreqLimitLowTx1.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitLowTx0;
                    this.m_nudFreqLimitLowTx2.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitLowTx1;
                    this.m_nudFreqLimitLowTx3.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitLowTx2;
                    this.m_nudFreqLimitHighTx1.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitHighTx0;
                    this.m_nudFreqLimitHighTx2.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitHighTx1;
                    this.m_nudFreqLimitHighTx3.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlRfTxFreqPwrLimitMonConf_t.freqLimitHighTx2;
                    this.m_nudPowerBackOffTx1.Value = jobject.mmWaveDevices[p1].rfConfig.rlRfTxFreqPwrLimitMonConf_t.tx0PwrBackOff;
                    this.m_nudPowerBackOffTx2.Value = jobject.mmWaveDevices[p1].rfConfig.rlRfTxFreqPwrLimitMonConf_t.tx1PwrBackOff;
                    this.m_nudPowerBackOffTx3.Value = jobject.mmWaveDevices[p1].rfConfig.rlRfTxFreqPwrLimitMonConf_t.tx2PwrBackOff;
                }
                if (jobject.mmWaveDevices[p1].rfConfig.p000013.isConfigured == 0)
                {
                    string msg9 = string.Format("Missing RF Device Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg9);
                }
                else
                {
                    this.f00023a.SelectedIndex = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000013.aeDirection, 16) & 3);
                    this.f000239.SelectedIndex = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000013.aeDirection, 16) & 12) >> 2;
                    this.m_chkFrameStartAECtlEnaDisble.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000013.aeControl, 16) & 1) == 1);
                    this.m_chkFrameStopAECtlEnaDisble.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000013.aeControl, 16) & 2) >> 1 == 1);
                    this.m_RFDeviceAEControlConfigParameters.Reserved = 0;
                    this.m_chkBSSDigWatchDogTimerCtlEnaDisble.Checked = (jobject.mmWaveDevices[p1].rfConfig.p000013.p000009 == 1);
                    this.f000238.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.p000013.p00000a;
                }
                result = true;
            }
            catch
            {
                string msg10 = string.Format("Static Config Tab Configuration for device {0} is incorrect.", p1);
                GlobalRef.LuaWrapper.PrintError(msg10);
                result = false;
            }
            return result;
        }

        public int getNumBits()
        {
            if (base.InvokeRequired)
            {
                del_i_v method = new del_i_v(this.getNumBits);
                return (int)base.Invoke(method);
            }
            int result;
            try
            {
                int num = 0;
                if (this.m_comBits.SelectedIndex == 0)
                {
                    num = 12;
                }
                else if (this.m_comBits.SelectedIndex == 1)
                {
                    num = 14;
                }
                else if (this.m_comBits.SelectedIndex == 2)
                {
                    num = 16;
                }
                result = num;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = 0;
            }
            return result;
        }

        public int getFormat()
        {
            if (base.InvokeRequired)
            {
                del_i_v method = new del_i_v(this.getFormat);
                return (int)base.Invoke(method);
            }
            int result;
            try
            {
                int num = 0;
                if (this.m_comFmts.SelectedIndex == 0 || this.m_comFmts.SelectedIndex == 3)
                {
                    num = 1;
                }
                else if (this.m_comFmts.SelectedIndex == 1 || this.m_comFmts.SelectedIndex == 2)
                {
                    num = 2;
                }
                result = num;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = 0;
            }
            return result;
        }

        public int getRxChains()
        {
            if (base.InvokeRequired)
            {
                del_i_v method = new del_i_v(this.getRxChains);
                return (int)base.Invoke(method);
            }
            int result;
            try
            {
                int num = 0;
                if (this.cbEnableRx1.Checked)
                {
                    num++;
                }
                if (this.cbEnableRx2.Checked)
                {
                    num++;
                }
                if (this.cbEnableRx3.Checked)
                {
                    num++;
                }
                if (this.cbEnableRx4.Checked)
                {
                    num++;
                }
                result = num;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = 0;
            }
            return result;
        }

        public bool UpdateBasicConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(UpdateBasicConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                m_StaticParams.EnableTx1 = (cbEnableTx1.Checked ? 1 : 0);
                m_StaticParams.EnableTx2 = (cbEnableTx2.Checked ? 1 : 0);
                m_StaticParams.EnableTx3 = (cbEnableTx3.Checked ? 1 : 0);

                m_StaticParams.EnableRx1 = (cbEnableRx1.Checked ? 1 : 0);
                m_StaticParams.EnableRx2 = (cbEnableRx2.Checked ? 1 : 0);
                m_StaticParams.EnableRx3 = (cbEnableRx3.Checked ? 1 : 0);
                m_StaticParams.EnableRx4 = (cbEnableRx4.Checked ? 1 : 0);

                m_StaticParams.BitsVal = m_comBits.SelectedIndex;
                m_StaticParams.FmtVal = m_comFmts.SelectedIndex;
                m_StaticParams.FullScaleReductionFactor = (byte)m_nudFullScaleReductionFactor.Value;
                m_StaticParams.IQSwap = (char)m_comIQSwap.SelectedIndex;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_StaticParams.ChanIntrlev = '\0';
                }
                else
                {
                    m_StaticParams.ChanIntrlev = '\u0001';
                }
                m_StaticParams.CascadeMode = (ushort)m_RadarDeviceMode.SelectedIndex;
                m_StaticParams.ClkOutMasterDis = (byte)(m_chkClkOutMasterDis.Checked ? 1 : 0);
                m_StaticParams.SynOutMasterDis = (byte)(m_chkSynOutMasterDis.Checked ? 1 : 0);
                m_StaticParams.ClkOutSlaveEna = (byte)(m_chkClkOutSlaveEna.Checked ? 1 : 0);
                m_StaticParams.SynOutSlaveEna = (byte)(m_chkSynOutSlaveEna.Checked ? 1 : 0);
                m_StaticParams.IntLOMasterEna = (byte)(m_chkIntLOMasterEna.Checked ? 1 : 0);
                m_StaticParams.OSCClkOutMasterDis = (byte)(m_chkOSCClkOutMasterDis.Checked ? 1 : 0);
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateLpModConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateLpModConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_LpModConfParams.LpAdcMod = this.m_comLpAdcMod.SelectedIndex;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateChanAdcDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateChanAdcDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.cbEnableTx1.Checked = (this.m_StaticParams.EnableTx1 == 1);
                this.cbEnableTx2.Checked = (this.m_StaticParams.EnableTx2 == 1);
                this.cbEnableTx3.Checked = (this.m_StaticParams.EnableTx3 == 1);
                this.cbEnableRx1.Checked = (this.m_StaticParams.EnableRx1 == 1);
                this.cbEnableRx2.Checked = (this.m_StaticParams.EnableRx2 == 1);
                this.cbEnableRx3.Checked = (this.m_StaticParams.EnableRx3 == 1);
                this.cbEnableRx4.Checked = (this.m_StaticParams.EnableRx4 == 1);
                this.m_comBits.SelectedIndex = this.m_StaticParams.BitsVal;
                this.m_comFmts.SelectedIndex = this.m_StaticParams.FmtVal;
                this.m_nudFullScaleReductionFactor.Value = this.m_StaticParams.FullScaleReductionFactor;
                this.m_comIQSwap.SelectedIndex = (int)this.m_StaticParams.IQSwap;
                this.m_RadarDeviceMode.SelectedIndex = (int)this.m_StaticParams.CascadeMode;
                this.m_chkClkOutMasterDis.Checked = (this.m_StaticParams.ClkOutMasterDis == 1);
                this.m_chkSynOutMasterDis.Checked = (this.m_StaticParams.SynOutMasterDis == 1);
                this.m_chkClkOutSlaveEna.Checked = (this.m_StaticParams.ClkOutSlaveEna == 1);
                this.m_chkSynOutSlaveEna.Checked = (this.m_StaticParams.SynOutSlaveEna == 1);
                this.m_chkIntLOMasterEna.Checked = (this.m_StaticParams.IntLOMasterEna == 1);
                this.m_chkOSCClkOutMasterDis.Checked = (this.m_StaticParams.OSCClkOutMasterDis == 1);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateLpNNoiseDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateLpNNoiseDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_comLpAdcMod.SelectedIndex = this.m_LpModConfParams.LpAdcMod;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadBasicConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadBasicConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("Tx1En"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("Tx2En"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("Tx3En"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("Rx1En"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("Rx2En"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("Rx3En"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("Rx4En"));
                Convert.ToInt32(ConfigurationManager.GetAppSetting("BitsVal"));
                Convert.ToInt32(ConfigurationManager.GetAppSetting("FmtVal"));
                Convert.ToInt32(ConfigurationManager.GetAppSetting("IQSwap"));
                int anaChan = Convert.ToInt32(ConfigurationManager.GetAppSetting("AnaChan"));
                int lpAdcMod = Convert.ToInt32(ConfigurationManager.GetAppSetting("LpAdcMod"));
                int nfMod = Convert.ToInt32(ConfigurationManager.GetAppSetting("NfMod"));
                this.m_GuiManager.ScriptOps.UpdateLowPowNNoisFifConfigData(anaChan, lpAdcMod, nfMod);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveBasicConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveBasicConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetAppSetting("Tx1En", (this.cbEnableTx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAppSetting("Tx2En", (this.cbEnableTx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAppSetting("Tx3En", (this.cbEnableTx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAppSetting("Rx1En", (this.cbEnableRx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAppSetting("Rx2En", (this.cbEnableRx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAppSetting("Rx3En", (this.cbEnableRx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAppSetting("Rx4En", (this.cbEnableRx4.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAppSetting("BitsVal", this.m_comBits.SelectedIndex.ToString());
                ConfigurationManager.SetAppSetting("FmtVal", this.m_comFmts.SelectedIndex.ToString());
                ConfigurationManager.SetAppSetting("IQSwap", this.m_comIQSwap.SelectedIndex.ToString());
                ConfigurationManager.SetAppSetting("LpAdcMod", this.m_comLpAdcMod.SelectedIndex.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadChannelConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadChannelConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ushort txIdx = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("tx0En"));
                ushort tx = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("tx1En"));
                ushort tx2 = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("tx2En"));
                ushort rxIdx = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("rx0En"));
                ushort rx = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("rx1En"));
                ushort rx2 = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("rx2En"));
                ushort rx3 = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("rx3En"));
                ushort cascadeMode = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("cascadeMode"));
                this.m_GuiManager.ScriptOps.UpdateChanNAdcConfData(txIdx, tx, tx2, rxIdx, rx, rx2, rx3, cascadeMode, 0, 0, 0);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveChannelBasicConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveChannelBasicConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetChannelConfigKeyVal("tx0En", (this.cbEnableTx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetChannelConfigKeyVal("tx1En", (this.cbEnableTx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetChannelConfigKeyVal("tx2En", (this.cbEnableTx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetChannelConfigKeyVal("rx0En", (this.cbEnableRx1.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetChannelConfigKeyVal("rx1En", (this.cbEnableRx2.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetChannelConfigKeyVal("rx2En", (this.cbEnableRx3.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetChannelConfigKeyVal("rx3En", (this.cbEnableRx4.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetChannelConfigKeyVal("cascadeMode", this.m_RadarDeviceMode.SelectedIndex.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadADCConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadADCConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ushort txIdx = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("tx0En"));
                ushort tx = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("tx1En"));
                ushort tx2 = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("tx2En"));
                ushort rxIdx = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("rx0En"));
                ushort rx = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("rx1En"));
                ushort rx2 = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("rx2En"));
                ushort rx3 = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("rx3En"));
                ushort cascadeMode = Convert.ToUInt16(ConfigurationManager.GetChannelConfigKeyVal("cascadeMode"));
                int bitsVal = Convert.ToInt32(ConfigurationManager.GetADCConfigKeyVal("bitsVal"));
                int fmtVal = Convert.ToInt32(ConfigurationManager.GetADCConfigKeyVal("formatVal"));
                int iqswap = Convert.ToInt32(ConfigurationManager.GetADCConfigKeyVal("IQSwap"));
                this.m_GuiManager.ScriptOps.UpdateChanNAdcConfData(txIdx, tx, tx2, rxIdx, rx, rx2, rx3, cascadeMode, bitsVal, fmtVal, iqswap);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveADCBasicConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveADCBasicConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetADCConfigKeyVal("bitsVal", this.m_comBits.SelectedIndex.ToString());
                ConfigurationManager.SetADCConfigKeyVal("formatVal", this.m_comFmts.SelectedIndex.ToString());
                ConfigurationManager.SetADCConfigKeyVal("IQSwap", this.m_comIQSwap.SelectedIndex.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadLPModeConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadLPModeConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                int lpAdcMod = Convert.ToInt32(ConfigurationManager.m000001("lpAdcMode"));
                this.m_GuiManager.ScriptOps.LoadNLPModeConfData(lpAdcMod);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveLPModeBasicConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveLPModeBasicConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.m000003("lpAdcMode", this.m_comLpAdcMod.SelectedIndex.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadFreqLimitConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadFreqLimitConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                double freqLimitLow = Convert.ToDouble(ConfigurationManager.GetfreqLimitConfigKeyVal("freqLimitLow"));
                double freqLimitHigh = Convert.ToDouble(ConfigurationManager.GetfreqLimitConfigKeyVal("freqLimitHigh"));
                this.m_GuiManager.ScriptOps.LoadNFreqLimitConfData(freqLimitLow, freqLimitHigh);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveFreqLimitConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveFreqLimitConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetfreqLimitConfigKeyVal("freqLimitLow", this.m_nudFreqLimitLow.Value.ToString());
                ConfigurationManager.SetfreqLimitConfigKeyVal("freqLimitHigh", this.m_nudFreqLimitHigh.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveRfLDOBypassConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveRfLDOBypassConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetRfLdoByPassConfigKeyVal("RFLdoByPass", (this.f000237.Checked ? 1 : 0).ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadRFLdoBypassConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadRFLdoBypassConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ushort rfldoBypass = Convert.ToUInt16(ConfigurationManager.GetRfLdoByPassConfigKeyVal("RFLdoByPass"));
                this.m_GuiManager.ScriptOps.LoadNRfLDOBypassConfData(rfldoBypass);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveRadarMiscControlConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveRadarMiscControlConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetradarMiscCtlConfigKeyVal("PerChirpPhaseShiftEna", (this.m_chkPerChirpPhaseShifterEnable.Checked ? 1 : 0).ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadRadarMiscControlConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadRadarMiscControlConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                uint perChirpPhaseShiftEna = (uint)Convert.ToUInt16(ConfigurationManager.GetradarMiscCtlConfigKeyVal("PerChirpPhaseShiftEna"));
                this.m_GuiManager.ScriptOps.LoadNRadarMiscControlConfData(perChirpPhaseShiftEna);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveCalMonFreqTxPowerLimitConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveCalMonFreqTxPowerLimitConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetcalMonFreqTxPowLimitConfigKeyVal("freqLimitLowTx0", this.m_nudFreqLimitLowTx1.Value.ToString());
                ConfigurationManager.SetcalMonFreqTxPowLimitConfigKeyVal("freqLimitLowTx1", this.m_nudFreqLimitLowTx2.Value.ToString());
                ConfigurationManager.SetcalMonFreqTxPowLimitConfigKeyVal("freqLimitLowTx2", this.m_nudFreqLimitLowTx3.Value.ToString());
                ConfigurationManager.SetcalMonFreqTxPowLimitConfigKeyVal("freqLimitHighTx0", this.m_nudFreqLimitHighTx1.Value.ToString());
                ConfigurationManager.SetcalMonFreqTxPowLimitConfigKeyVal("freqLimitHighTx1", this.m_nudFreqLimitHighTx2.Value.ToString());
                ConfigurationManager.SetcalMonFreqTxPowLimitConfigKeyVal("freqLimitHighTx2", this.m_nudFreqLimitHighTx3.Value.ToString());
                ConfigurationManager.SetcalMonFreqTxPowLimitConfigKeyVal("tx0PowerBackoff", this.m_nudPowerBackOffTx1.Value.ToString());
                ConfigurationManager.SetcalMonFreqTxPowLimitConfigKeyVal("tx1PowerBackoff", this.m_nudPowerBackOffTx2.Value.ToString());
                ConfigurationManager.SetcalMonFreqTxPowLimitConfigKeyVal("tx2PowerBackoff", this.m_nudPowerBackOffTx3.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadCalMonFreqTxPowerLimitConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadCalMonFreqTxPowerLimitConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                double freqLimitLowTx = Convert.ToDouble(ConfigurationManager.GetcalMonFreqTxPowLimitConfigKeyVal("freqLimitLowTx0"));
                double freqLimitLowTx2 = Convert.ToDouble(ConfigurationManager.GetcalMonFreqTxPowLimitConfigKeyVal("freqLimitLowTx1"));
                double freqLimitLowTx3 = Convert.ToDouble(ConfigurationManager.GetcalMonFreqTxPowLimitConfigKeyVal("freqLimitLowTx2"));
                double freqLimitHighTx = Convert.ToDouble(ConfigurationManager.GetcalMonFreqTxPowLimitConfigKeyVal("freqLimitHighTx0"));
                double freqLimitHighTx2 = Convert.ToDouble(ConfigurationManager.GetcalMonFreqTxPowLimitConfigKeyVal("freqLimitHighTx1"));
                double freqLimitHighTx3 = Convert.ToDouble(ConfigurationManager.GetcalMonFreqTxPowLimitConfigKeyVal("freqLimitHighTx2"));
                double tx0PowerBackoff = Convert.ToDouble(ConfigurationManager.GetcalMonFreqTxPowLimitConfigKeyVal("tx0PowerBackoff"));
                double tx1PowerBackoff = Convert.ToDouble(ConfigurationManager.GetcalMonFreqTxPowLimitConfigKeyVal("tx1PowerBackoff"));
                double tx2PowerBackoff = Convert.ToDouble(ConfigurationManager.GetcalMonFreqTxPowLimitConfigKeyVal("tx2PowerBackoff"));
                this.m_GuiManager.ScriptOps.LoadNCalMonFreqTxPowLimitConfData(freqLimitLowTx, freqLimitLowTx2, freqLimitLowTx3, freqLimitHighTx, freqLimitHighTx2, freqLimitHighTx3, tx0PowerBackoff, tx1PowerBackoff, tx2PowerBackoff);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private int iSetBasicConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetBasicConfig_Gui(is_starting_op, is_ending_op);
        }

        public void SetAdvanceConfigReadyState()
        {
            this.m_btnLpModSet.ForeColor = Color.Blue;
        }

        public void ReSetBasicConfigReadyState()
        {
            this.m_btnBasicConfSet.ForeColor = Color.Black;
        }

        private void iSetBasicConfig()
        {
            this.iSetBasicConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
            this.SetAdvanceConfigReadyState();
            this.ReSetBasicConfigReadyState();
        }

        public void SetRFIniialization()
        {
            this.m_btnRfInit.Text = "RF Init ";
        }

        public void iSetBasicConfigAsync()
        {
            new del_v_v(this.iSetBasicConfig).BeginInvoke(null, null);
        }

        private void btnBasicConfSet_Click(object sender, EventArgs p1)
        {
            this.iSetBasicConfigAsync();
            this.SetRFIniialization();
        }

        public bool iDisableStaticConfTabBtn()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.iDisableStaticConfTabBtn);
                return (bool)base.Invoke(method);
            }
            this.m_btnBasicConfSet.Enabled = false;
            this.m_btnLpModSet.Enabled = false;
            this.m_btnRfInit.Enabled = false;
            return true;
        }

        public bool iEnableStaticConfTabBtn()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.iEnableStaticConfTabBtn);
                return (bool)base.Invoke(method);
            }
            this.m_btnBasicConfSet.Enabled = true;
            this.m_btnLpModSet.Enabled = true;
            this.m_btnRfInit.Enabled = true;
            return true;
        }

        private void label4_Click(object sender, EventArgs p1)
        {
        }

        private int iSetLpModConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetLpModConfig_Gui(is_starting_op, is_ending_op);
        }

        public void SetRFInitReadyState()
        {
            this.m_btnRfInit.ForeColor = Color.Blue;
        }

        public void ReSetAdvanceConfigReadyState()
        {
            this.m_btnLpModSet.ForeColor = Color.Black;
        }

        private void iSetLpModConfig()
        {
            this.iSetLpModConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
            this.SetRFInitReadyState();
            this.ReSetAdvanceConfigReadyState();
        }

        public void iSetLpModConfigAsync()
        {
            new del_v_v(this.iSetLpModConfig).BeginInvoke(null, null);
        }

        private void btnLpModSet_Click(object sender, EventArgs p1)
        {
            this.iSetLpModConfigAsync();
            this.SetRFIniialization();
        }

        private void m_comBits_SelectedIndexChanged(object sender, EventArgs p1)
        {
        }

        private void m_comFmts_SelectedIndexChanged(object sender, EventArgs p1)
        {
        }

        public void SetRFIniializationtIsDone()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.SetRFIniializationtIsDone);
                base.Invoke(method);
                return;
            }
            this.m_btnRfInit.Text = "RF Init Done";
        }

        public void ReSetRFInitConfigReadyState()
        {
            this.m_btnRfInit.ForeColor = Color.Black;
        }

        private void iSetRfInit()
        {
            this.m_GuiManager.ScriptOps.iSetRfInit_Gui((ushort)GlobalRef.g_RadarDeviceId, true, false);
            this.m_MainForm.GuiOpEnd(true);
            this.ReSetRFInitConfigReadyState();
        }

        public void iSetRfInitAsync()
        {
            new del_v_v(this.iSetRfInit).BeginInvoke(null, null);
        }

        private void m_btnRfInit_Click(object sender, EventArgs p1)
        {
            this.iSetRfInitAsync();
            this.SetRFIniializationtIsDone();
        }

        public void clrRFInitDoneStatus()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.clrRFInitDoneStatus);
                base.Invoke(method);
                return;
            }
            this.m_btnRfInit.Text = "RF Init";
        }

        public void DisabletheCascadeMode()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.DisabletheCascadeMode);
                base.Invoke(method);
                return;
            }
            this.m_RadarDeviceMode.Visible = true;
            this.m_lblCascadeMode.Visible = true;
        }

        public void EnabletheCascadeMode()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.EnabletheCascadeMode);
                base.Invoke(method);
                return;
            }
            this.m_RadarDeviceMode.Visible = true;
            this.m_lblCascadeMode.Visible = true;
        }

        private void checkRx1_ChangeTx1_CheckedChanged(object sender, EventArgs p1)
        {
            if (this.cbEnableRx1.Checked)
            {
                this.DataConfigHandler.MappedLVDSDataLane1EnableWithRx1();
                return;
            }
            this.DataConfigHandler.MappedLVDSDataLane1DisableWithRx1();
        }

        private void m_ComboCasCadeModeSelect_SelectiveIndexChanged(object sender, EventArgs p1)
        {
        }

        public void DisableTx3ChannelFor16XXARDevice()
        {
            if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR14xxDevice || GlobalRef.g_AR6843Device || GlobalRef.g_AR1843Device || GlobalRef.g_AR2243Device)
            {
                this.cbEnableTx3.Enabled = true;
                this.m_grpRadarMiscCtl.Enabled = true;
                return;
            }
            if (GlobalRef.g_AR16xxDevice)
            {
                this.cbEnableTx3.Enabled = false;
                this.m_grpRadarMiscCtl.Enabled = false;
            }
        }

        public void DisablePerChirpPhaseShifterEnableFor14XXARDevice()
        {
            if (GlobalRef.g_AR14xxDevice)
            {
                this.m_grpRadarMiscCtl.Visible = false;
                return;
            }
            if (GlobalRef.g_AR6843Device || GlobalRef.g_AR1843Device || GlobalRef.g_AR2243Device)
            {
                this.m_grpRadarMiscCtl.Visible = true;
            }
        }

        private int m00006f(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetRFLDOBypassEnableAndDisableConfig_Gui(is_starting_op, is_ending_op);
        }

        private void m000070()
        {
            this.m00006f(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetLDOBypassAsync()
        {
            new del_v_v(this.m000070).BeginInvoke(null, null);
        }

        public void m000071(object sender, EventArgs p1)
        {
            this.iSetLDOBypassAsync();
        }

        public bool UpdateRFLDOBypassConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateRFLDOBypassConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_RFLDOBypassEnableAndDisableConfigParameters.LDOBypassEnable = (ushort)(this.f000237.Checked ? 1 : 0);
                this.m_RFLDOBypassEnableAndDisableConfigParameters.f0002fc = (byte)(this.f00023b.Checked ? 1 : 0);
                this.m_RFLDOBypassEnableAndDisableConfigParameters.SupplyMonIRDrop = (ushort)this.m_comSupplyMonIRDrop.SelectedIndex;
                if (this.m_comSupplyMonIOSupply.SelectedIndex == 0)
                {
                    this.m_RFLDOBypassEnableAndDisableConfigParameters.IOSupply = 0;
                }
                else if (this.m_comSupplyMonIOSupply.SelectedIndex == 1)
                {
                    this.m_RFLDOBypassEnableAndDisableConfigParameters.IOSupply = 1;
                }
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateRFLDOBypassConfDataFromCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateRFLDOBypassConfDataFromCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.f000237.Checked = (this.m_RFLDOBypassEnableAndDisableConfigParameters.LDOBypassEnable == 1);
                this.f00023b.Checked = (this.m_RFLDOBypassEnableAndDisableConfigParameters.f0002fc == 1);
                this.m_comSupplyMonIRDrop.SelectedIndex = (int)this.m_RFLDOBypassEnableAndDisableConfigParameters.SupplyMonIRDrop;
                if (this.m_RFLDOBypassEnableAndDisableConfigParameters.IOSupply == 0)
                {
                    this.m_comSupplyMonIOSupply.SelectedIndex = 0;
                }
                else if (this.m_RFLDOBypassEnableAndDisableConfigParameters.IOSupply == 1)
                {
                    this.m_comSupplyMonIOSupply.SelectedIndex = 1;
                }
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private int iSetPerChirpPhaseShifterEnableConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetPerChirpPhaseShifterEnableConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetPerChirpPhaseShifterEnableConfig()
        {
            this.iSetPerChirpPhaseShifterEnableConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetPerChirpPhaseShifterEnableConfigAsync()
        {
            new del_v_v(this.iSetPerChirpPhaseShifterEnableConfig).BeginInvoke(null, null);
        }

        private void m_btnRFMiscControlSet_Click(object sender, EventArgs p1)
        {
            this.iSetPerChirpPhaseShifterEnableConfigAsync();
        }

        public bool UpdatePerChirpPhaseShifterEnableConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdatePerChirpPhaseShifterEnableConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_RFMiscConfigParams.PerChirpPhaseShifterEnable = (this.m_chkPerChirpPhaseShifterEnable.Checked ? 1U : 0U);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdatePerChirpPhaseShifterEnableDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdatePerChirpPhaseShifterEnableDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_chkPerChirpPhaseShifterEnable.Checked = (this.m_RFMiscConfigParams.PerChirpPhaseShifterEnable == 1U);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private int iSetFreqLimitConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetFreqLimitConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetFreqLimitConfig()
        {
            this.iSetFreqLimitConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetFreqLimitConfigAsync()
        {
            new del_v_v(this.iSetFreqLimitConfig).BeginInvoke(null, null);
        }

        public void m_btnFreqLimitConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetFreqLimitConfigAsync();
        }

        public bool UpdateFreqLimitConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateFreqLimitConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_RFCalibFrequencyLimitConfigParameters.FreqLimitLow = (double)this.m_nudFreqLimitLow.Value;
                this.m_RFCalibFrequencyLimitConfigParameters.FreqLimitHigh = (double)this.m_nudFreqLimitHigh.Value;
                if (this.m_RFCalibFrequencyLimitConfigParameters.FreqLimitLow >= this.m_RFCalibFrequencyLimitConfigParameters.FreqLimitHigh)
                {
                    MessageBox.Show(" Frequency Limit High value should be always greater than Frequency Limit Low value !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateFreqLimitConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateFreqLimitConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudFreqLimitLow.Value = (decimal)this.m_RFCalibFrequencyLimitConfigParameters.FreqLimitLow;
                this.m_nudFreqLimitHigh.Value = (decimal)this.m_RFCalibFrequencyLimitConfigParameters.FreqLimitHigh;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public int SetStartAndEndFreqMinAndMaxLimitInFreqLimitConfig_Gui()
        {
            if (GlobalRef.g_ARDeviceOperateFreq60GHz)
            {
                this.m_nudFreqLimitLow.Minimum = 45m;
                this.m_nudFreqLimitLow.Maximum = 100m;
                this.m_nudFreqLimitLow.Value = 60m;
                this.m_nudFreqLimitHigh.Minimum = 45m;
                this.m_nudFreqLimitHigh.Maximum = 100m;
                this.m_nudFreqLimitHigh.Value = 64m;
            }
            else
            {
                this.m_nudFreqLimitLow.Minimum = 0m;
                this.m_nudFreqLimitLow.Maximum = 81m;
                this.m_nudFreqLimitLow.Value = 77m;
                this.m_nudFreqLimitHigh.Minimum = 0m;
                this.m_nudFreqLimitHigh.Maximum = 81m;
                this.m_nudFreqLimitHigh.Value = 81m;
            }
            return 0;
        }

        private int iSetCalMonFreqTxPowerLimitConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetCalMonFreqTxPowerLimitConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetCalMonFreqTxPowerLimitConfig()
        {
            this.iSetCalMonFreqTxPowerLimitConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetCalMonFreqTxPowerLimitConfigAsync()
        {
            new del_v_v(this.iSetCalMonFreqTxPowerLimitConfig).BeginInvoke(null, null);
        }

        private void m_btnCalMonFreqTxPowerLimitConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetCalMonFreqTxPowerLimitConfigAsync();
        }

        public bool UpdateCalMonFreqTxPowerLimitConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateCalMonFreqTxPowerLimitConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitLowTx1 = (double)this.m_nudFreqLimitLowTx1.Value;
                this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitLowTx2 = (double)this.m_nudFreqLimitLowTx2.Value;
                this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitLowTx3 = (double)this.m_nudFreqLimitLowTx3.Value;
                this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitHighTx1 = (double)this.m_nudFreqLimitHighTx1.Value;
                this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitHighTx2 = (double)this.m_nudFreqLimitHighTx2.Value;
                this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitHighTx3 = (double)this.m_nudFreqLimitHighTx3.Value;
                this.m_CalMonFrequencyTxPowerLimitConfigParameters.Tx1PowerBackoff = (double)this.m_nudPowerBackOffTx1.Value;
                this.m_CalMonFrequencyTxPowerLimitConfigParameters.Tx2PowerBackoff = (double)this.m_nudPowerBackOffTx2.Value;
                this.m_CalMonFrequencyTxPowerLimitConfigParameters.Tx3PowerBackoff = (double)this.m_nudPowerBackOffTx3.Value;
                if (this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitLowTx1 >= this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitHighTx1)
                {
                    MessageBox.Show(" Tx0 Frequency Limit High value should be always greater than Frequency Limit Low value !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    result = false;
                }
                else if (this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitLowTx2 >= this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitHighTx2)
                {
                    MessageBox.Show(" Tx1 Frequency Limit High value should be always greater than Frequency Limit Low value !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    result = false;
                }
                else if (this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitLowTx3 >= this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitHighTx3)
                {
                    MessageBox.Show(" Tx2 Frequency Limit High value should be always greater than Frequency Limit Low value !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateCalMonFreqTxPowerLimitConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateCalMonFreqTxPowerLimitConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudFreqLimitLowTx1.Value = (decimal)this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitLowTx1;
                this.m_nudFreqLimitLowTx2.Value = (decimal)this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitLowTx2;
                this.m_nudFreqLimitLowTx3.Value = (decimal)this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitLowTx3;
                this.m_nudFreqLimitHighTx1.Value = (decimal)this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitHighTx1;
                this.m_nudFreqLimitHighTx2.Value = (decimal)this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitHighTx2;
                this.m_nudFreqLimitHighTx3.Value = (decimal)this.m_CalMonFrequencyTxPowerLimitConfigParameters.FreqLimitHighTx3;
                this.m_nudPowerBackOffTx1.Value = (decimal)this.m_CalMonFrequencyTxPowerLimitConfigParameters.Tx1PowerBackoff;
                this.m_nudPowerBackOffTx2.Value = (decimal)this.m_CalMonFrequencyTxPowerLimitConfigParameters.Tx2PowerBackoff;
                this.m_nudPowerBackOffTx3.Value = (decimal)this.m_CalMonFrequencyTxPowerLimitConfigParameters.Tx3PowerBackoff;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public int SetStartAndEndFreqMinAndMaxLimitInCalMonFreqTxPowerLimitConfig_Gui()
        {
            if (GlobalRef.g_ARDeviceOperateFreq60GHz)
            {
                this.m_nudFreqLimitLowTx1.Minimum = 57m;
                this.m_nudFreqLimitLowTx1.Maximum = 64m;
                this.m_nudFreqLimitLowTx1.Value = 60m;
                this.m_nudFreqLimitHighTx1.Minimum = 57m;
                this.m_nudFreqLimitHighTx1.Maximum = 64m;
                this.m_nudFreqLimitHighTx1.Value = 64m;
                this.m_nudFreqLimitLowTx2.Minimum = 57m;
                this.m_nudFreqLimitLowTx2.Maximum = 64m;
                this.m_nudFreqLimitLowTx2.Value = 60m;
                this.m_nudFreqLimitHighTx2.Minimum = 57m;
                this.m_nudFreqLimitHighTx2.Maximum = 64m;
                this.m_nudFreqLimitHighTx2.Value = 64m;
                this.m_nudFreqLimitLowTx3.Minimum = 57m;
                this.m_nudFreqLimitLowTx3.Maximum = 64m;
                this.m_nudFreqLimitLowTx3.Value = 60m;
                this.m_nudFreqLimitHighTx3.Minimum = 57m;
                this.m_nudFreqLimitHighTx3.Maximum = 64m;
                this.m_nudFreqLimitHighTx3.Value = 64m;
            }
            else
            {
                this.m_nudFreqLimitLowTx1.Minimum = 0m;
                this.m_nudFreqLimitLowTx1.Maximum = 81m;
                this.m_nudFreqLimitLowTx1.Value = 77m;
                this.m_nudFreqLimitHighTx1.Minimum = 0m;
                this.m_nudFreqLimitHighTx1.Maximum = 81m;
                this.m_nudFreqLimitHighTx1.Value = 81m;
                this.m_nudFreqLimitLowTx2.Minimum = 0m;
                this.m_nudFreqLimitLowTx2.Maximum = 81m;
                this.m_nudFreqLimitLowTx2.Value = 77m;
                this.m_nudFreqLimitHighTx2.Minimum = 0m;
                this.m_nudFreqLimitHighTx2.Maximum = 81m;
                this.m_nudFreqLimitHighTx2.Value = 81m;
                this.m_nudFreqLimitLowTx3.Minimum = 0m;
                this.m_nudFreqLimitLowTx3.Maximum = 81m;
                this.m_nudFreqLimitLowTx3.Value = 77m;
                this.m_nudFreqLimitHighTx3.Minimum = 0m;
                this.m_nudFreqLimitHighTx3.Maximum = 81m;
                this.m_nudFreqLimitHighTx3.Value = 81m;
            }
            return 0;
        }

        private int iSetRFDeviceAEControlConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetRFDeviceAEControlConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetRFDeviceAEControlConfig()
        {
            this.iSetRFDeviceAEControlConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetRFDeviceAEControlConfigAsync()
        {
            new del_v_v(this.iSetRFDeviceAEControlConfig).BeginInvoke(null, null);
        }

        public void m_btnRFDeviceAEDirectionControlConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetRFDeviceAEControlConfigAsync();
        }

        public bool UpdateRFDeviceAEControlConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateRFDeviceAEControlConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                if (this.f00023a.SelectedIndex == 0)
                {
                    this.m_RFDeviceAEControlConfigParameters.f0002fd = 0U;
                }
                else if (this.f00023a.SelectedIndex == 1)
                {
                    this.m_RFDeviceAEControlConfigParameters.f0002fd = 1U;
                }
                else if (this.f00023a.SelectedIndex == 2)
                {
                    this.m_RFDeviceAEControlConfigParameters.f0002fd = 2U;
                }
                if (this.f000239.SelectedIndex == 0)
                {
                    this.m_RFDeviceAEControlConfigParameters.RFMonAEDirection = 0U;
                }
                else if (this.f000239.SelectedIndex == 1)
                {
                    this.m_RFDeviceAEControlConfigParameters.RFMonAEDirection = 1U;
                }
                else if (this.f000239.SelectedIndex == 2)
                {
                    this.m_RFDeviceAEControlConfigParameters.RFMonAEDirection = 2U;
                }
                this.m_RFDeviceAEControlConfigParameters.AEFrameStartControl = (byte)(this.m_chkFrameStartAECtlEnaDisble.Checked ? 1 : 0);
                this.m_RFDeviceAEControlConfigParameters.AEFrameStopControl = (byte)(this.m_chkFrameStopAECtlEnaDisble.Checked ? 1 : 0);
                this.m_RFDeviceAEControlConfigParameters.Reserved = 0;
                this.m_RFDeviceAEControlConfigParameters.BSSDigitalControl = (byte)(this.m_chkBSSDigWatchDogTimerCtlEnaDisble.Checked ? 1 : 0);
                if (this.f000238.SelectedIndex == 0)
                {
                    this.m_RFDeviceAEControlConfigParameters.AsyncEventCRCConfig = 0;
                }
                else if (this.f000238.SelectedIndex == 1)
                {
                    this.m_RFDeviceAEControlConfigParameters.AsyncEventCRCConfig = 1;
                }
                else if (this.f000238.SelectedIndex == 2)
                {
                    this.m_RFDeviceAEControlConfigParameters.AsyncEventCRCConfig = 2;
                }
                this.m_RFDeviceAEControlConfigParameters.Reserved2 = 0;
                this.m_RFDeviceAEControlConfigParameters.Reserved3 = 0;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateRFDeviceAEControlConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateRFDeviceAEControlConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.f00023a.SelectedIndex = (int)this.m_RFDeviceAEControlConfigParameters.f0002fd;
                this.f000239.SelectedIndex = (int)this.m_RFDeviceAEControlConfigParameters.RFMonAEDirection;
                this.m_chkFrameStartAECtlEnaDisble.Checked = (this.m_RFDeviceAEControlConfigParameters.AEFrameStartControl == 1);
                this.m_chkFrameStopAECtlEnaDisble.Checked = (this.m_RFDeviceAEControlConfigParameters.AEFrameStopControl == 1);
                this.m_RFDeviceAEControlConfigParameters.Reserved = 0;
                this.m_chkBSSDigWatchDogTimerCtlEnaDisble.Checked = (this.m_RFDeviceAEControlConfigParameters.BSSDigitalControl == 1);
                this.f000238.SelectedIndex = (int)this.m_RFDeviceAEControlConfigParameters.AsyncEventCRCConfig;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public void SelectMasterCascading()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.SelectMasterCascading);
                base.Invoke(method);
                return;
            }
            this.m_RadarDeviceMode.SelectedIndex = 1;
        }

        public void SelectSlaveCascading()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.SelectSlaveCascading);
                base.Invoke(method);
                return;
            }
            this.m_RadarDeviceMode.SelectedIndex = 2;
        }

        private void groupBox6_Enter(object sender, EventArgs p1)
        {
        }

        private void m_grpBasicConf_Enter(object sender, EventArgs p1)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs p1)
        {
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs p1)
        {
        }

        private void m_chkSynOutSlaveEna_CheckedChanged(object sender, EventArgs p1)
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
            this.m_grpBasicConf = new System.Windows.Forms.GroupBox();
            this.m_btnBasicConfSet = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_nudFullScaleReductionFactor = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_comIQSwap = new System.Windows.Forms.ComboBox();
            this.m_comFmts = new System.Windows.Forms.ComboBox();
            this.m_comBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_grpFreq = new System.Windows.Forms.GroupBox();
            this.m_chkOSCClkOutMasterDis = new System.Windows.Forms.CheckBox();
            this.m_chkIntLOMasterEna = new System.Windows.Forms.CheckBox();
            this.m_chkSynOutSlaveEna = new System.Windows.Forms.CheckBox();
            this.m_chkClkOutSlaveEna = new System.Windows.Forms.CheckBox();
            this.m_chkSynOutMasterDis = new System.Windows.Forms.CheckBox();
            this.m_chkClkOutMasterDis = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.m_lblCascadeMode = new System.Windows.Forms.Label();
            this.m_RadarDeviceMode = new System.Windows.Forms.ComboBox();
            this.cbEnableRx4 = new System.Windows.Forms.CheckBox();
            this.cbEnableRx3 = new System.Windows.Forms.CheckBox();
            this.cbEnableRx2 = new System.Windows.Forms.CheckBox();
            this.cbEnableRx1 = new System.Windows.Forms.CheckBox();
            this.cbEnableTx3 = new System.Windows.Forms.CheckBox();
            this.cbEnableTx2 = new System.Windows.Forms.CheckBox();
            this.cbEnableTx1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.f00023b = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.m_comSupplyMonIOSupply = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.m_comSupplyMonIRDrop = new System.Windows.Forms.ComboBox();
            this.f000236 = new System.Windows.Forms.Button();
            this.f000237 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_btnLpModSet = new System.Windows.Forms.Button();
            this.m_comLpAdcMod = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.m_grpRFDeviceConfig = new System.Windows.Forms.GroupBox();
            this.f000238 = new System.Windows.Forms.ComboBox();
            this.m_chkBSSDigWatchDogTimerCtlEnaDisble = new System.Windows.Forms.CheckBox();
            this.m_chkFrameStopAECtlEnaDisble = new System.Windows.Forms.CheckBox();
            this.m_chkFrameStartAECtlEnaDisble = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.f000239 = new System.Windows.Forms.ComboBox();
            this.f00023a = new System.Windows.Forms.ComboBox();
            this.m_btnRFDeviceAEDirectionControlConfigSet = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_nudPowerBackOffTx3 = new System.Windows.Forms.NumericUpDown();
            this.m_nudPowerBackOffTx2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudPowerBackOffTx1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudFreqLimitHighTx3 = new System.Windows.Forms.NumericUpDown();
            this.m_nudFreqLimitHighTx2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudFreqLimitHighTx1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudFreqLimitLowTx3 = new System.Windows.Forms.NumericUpDown();
            this.m_nudFreqLimitLowTx2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudFreqLimitLowTx1 = new System.Windows.Forms.NumericUpDown();
            this.m_btnCalMonFreqTxPowerLimitConfigSet = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_grpFreqLimitsConfig = new System.Windows.Forms.GroupBox();
            this.m_nudFreqLimitHigh = new System.Windows.Forms.NumericUpDown();
            this.m_nudFreqLimitLow = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_btnFreqLimitConfigSet = new System.Windows.Forms.Button();
            this.m_grpRadarMiscCtl = new System.Windows.Forms.GroupBox();
            this.m_btnRFMiscControlSet = new System.Windows.Forms.Button();
            this.m_chkPerChirpPhaseShifterEnable = new System.Windows.Forms.CheckBox();
            this.m_btnRfInit = new System.Windows.Forms.Button();
            this.m_grpBasicConf.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFullScaleReductionFactor)).BeginInit();
            this.m_grpFreq.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.m_grpRFDeviceConfig.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPowerBackOffTx3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPowerBackOffTx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPowerBackOffTx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitHighTx3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitHighTx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitHighTx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitLowTx3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitLowTx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitLowTx1)).BeginInit();
            this.m_grpFreqLimitsConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitLow)).BeginInit();
            this.m_grpRadarMiscCtl.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpBasicConf
            // 
            this.m_grpBasicConf.Controls.Add(this.m_btnBasicConfSet);
            this.m_grpBasicConf.Controls.Add(this.groupBox2);
            this.m_grpBasicConf.Controls.Add(this.m_grpFreq);
            this.m_grpBasicConf.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_grpBasicConf.Location = new System.Drawing.Point(10, 40);
            this.m_grpBasicConf.Name = "m_grpBasicConf";
            this.m_grpBasicConf.Size = new System.Drawing.Size(343, 419);
            this.m_grpBasicConf.TabIndex = 0;
            this.m_grpBasicConf.TabStop = false;
            this.m_grpBasicConf.Text = "Basic Configuration";
            // 
            // m_btnBasicConfSet
            // 
            this.m_btnBasicConfSet.ForeColor = System.Drawing.Color.Blue;
            this.m_btnBasicConfSet.Location = new System.Drawing.Point(181, 386);
            this.m_btnBasicConfSet.Name = "m_btnBasicConfSet";
            this.m_btnBasicConfSet.Size = new System.Drawing.Size(80, 28);
            this.m_btnBasicConfSet.TabIndex = 11;
            this.m_btnBasicConfSet.Text = "Set";
            this.m_btnBasicConfSet.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_nudFullScaleReductionFactor);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.m_comIQSwap);
            this.groupBox2.Controls.Add(this.m_comFmts);
            this.groupBox2.Controls.Add(this.m_comBits);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(7, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 151);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADC Config";
            // 
            // m_nudFullScaleReductionFactor
            // 
            this.m_nudFullScaleReductionFactor.Location = new System.Drawing.Point(135, 51);
            this.m_nudFullScaleReductionFactor.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.m_nudFullScaleReductionFactor.Name = "m_nudFullScaleReductionFactor";
            this.m_nudFullScaleReductionFactor.Size = new System.Drawing.Size(120, 21);
            this.m_nudFullScaleReductionFactor.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 30);
            this.label18.TabIndex = 13;
            this.label18.Text = "Full Scale \r\nReduction Factor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "IQ Swap";
            // 
            // m_comIQSwap
            // 
            this.m_comIQSwap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comIQSwap.FormattingEnabled = true;
            this.m_comIQSwap.Items.AddRange(new object[] {
            "I First",
            "Q First"});
            this.m_comIQSwap.Location = new System.Drawing.Point(133, 111);
            this.m_comIQSwap.Name = "m_comIQSwap";
            this.m_comIQSwap.Size = new System.Drawing.Size(121, 23);
            this.m_comIQSwap.TabIndex = 10;
            // 
            // m_comFmts
            // 
            this.m_comFmts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comFmts.FormattingEnabled = true;
            this.m_comFmts.Items.AddRange(new object[] {
            "Real",
            "Complex1x",
            "Complex2x",
            "PseudoReal"});
            this.m_comFmts.Location = new System.Drawing.Point(133, 80);
            this.m_comFmts.Name = "m_comFmts";
            this.m_comFmts.Size = new System.Drawing.Size(121, 23);
            this.m_comFmts.TabIndex = 9;
            // 
            // m_comBits
            // 
            this.m_comBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comBits.FormattingEnabled = true;
            this.m_comBits.Items.AddRange(new object[] {
            "12",
            "14",
            "16"});
            this.m_comBits.Location = new System.Drawing.Point(133, 21);
            this.m_comBits.Name = "m_comBits";
            this.m_comBits.Size = new System.Drawing.Size(121, 23);
            this.m_comBits.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Format";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bits";
            // 
            // m_grpFreq
            // 
            this.m_grpFreq.Controls.Add(this.m_chkOSCClkOutMasterDis);
            this.m_grpFreq.Controls.Add(this.m_chkIntLOMasterEna);
            this.m_grpFreq.Controls.Add(this.m_chkSynOutSlaveEna);
            this.m_grpFreq.Controls.Add(this.m_chkClkOutSlaveEna);
            this.m_grpFreq.Controls.Add(this.m_chkSynOutMasterDis);
            this.m_grpFreq.Controls.Add(this.m_chkClkOutMasterDis);
            this.m_grpFreq.Controls.Add(this.label26);
            this.m_grpFreq.Controls.Add(this.m_lblCascadeMode);
            this.m_grpFreq.Controls.Add(this.m_RadarDeviceMode);
            this.m_grpFreq.Controls.Add(this.cbEnableRx4);
            this.m_grpFreq.Controls.Add(this.cbEnableRx3);
            this.m_grpFreq.Controls.Add(this.cbEnableRx2);
            this.m_grpFreq.Controls.Add(this.cbEnableRx1);
            this.m_grpFreq.Controls.Add(this.cbEnableTx3);
            this.m_grpFreq.Controls.Add(this.cbEnableTx2);
            this.m_grpFreq.Controls.Add(this.cbEnableTx1);
            this.m_grpFreq.Controls.Add(this.label1);
            this.m_grpFreq.Controls.Add(this.label2);
            this.m_grpFreq.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_grpFreq.Location = new System.Drawing.Point(6, 19);
            this.m_grpFreq.Name = "m_grpFreq";
            this.m_grpFreq.Size = new System.Drawing.Size(331, 204);
            this.m_grpFreq.TabIndex = 2;
            this.m_grpFreq.TabStop = false;
            this.m_grpFreq.Text = "Channel Config";
            // 
            // m_chkOSCClkOutMasterDis
            // 
            this.m_chkOSCClkOutMasterDis.AutoSize = true;
            this.m_chkOSCClkOutMasterDis.Location = new System.Drawing.Point(177, 178);
            this.m_chkOSCClkOutMasterDis.Name = "m_chkOSCClkOutMasterDis";
            this.m_chkOSCClkOutMasterDis.Size = new System.Drawing.Size(151, 19);
            this.m_chkOSCClkOutMasterDis.TabIndex = 16;
            this.m_chkOSCClkOutMasterDis.Text = "OSCClkOut Master Dis";
            this.m_chkOSCClkOutMasterDis.UseVisualStyleBackColor = true;
            // 
            // m_chkIntLOMasterEna
            // 
            this.m_chkIntLOMasterEna.AutoSize = true;
            this.m_chkIntLOMasterEna.Location = new System.Drawing.Point(16, 178);
            this.m_chkIntLOMasterEna.Name = "m_chkIntLOMasterEna";
            this.m_chkIntLOMasterEna.Size = new System.Drawing.Size(126, 19);
            this.m_chkIntLOMasterEna.TabIndex = 15;
            this.m_chkIntLOMasterEna.Text = "INTLO Master Ena";
            this.m_chkIntLOMasterEna.UseVisualStyleBackColor = true;
            // 
            // m_chkSynOutSlaveEna
            // 
            this.m_chkSynOutSlaveEna.AutoSize = true;
            this.m_chkSynOutSlaveEna.Location = new System.Drawing.Point(177, 158);
            this.m_chkSynOutSlaveEna.Name = "m_chkSynOutSlaveEna";
            this.m_chkSynOutSlaveEna.Size = new System.Drawing.Size(129, 19);
            this.m_chkSynOutSlaveEna.TabIndex = 14;
            this.m_chkSynOutSlaveEna.Text = "SyncOut Slave Ena";
            this.m_chkSynOutSlaveEna.UseVisualStyleBackColor = true;
            // 
            // m_chkClkOutSlaveEna
            // 
            this.m_chkClkOutSlaveEna.AutoSize = true;
            this.m_chkClkOutSlaveEna.Location = new System.Drawing.Point(16, 158);
            this.m_chkClkOutSlaveEna.Name = "m_chkClkOutSlaveEna";
            this.m_chkClkOutSlaveEna.Size = new System.Drawing.Size(121, 19);
            this.m_chkClkOutSlaveEna.TabIndex = 13;
            this.m_chkClkOutSlaveEna.Text = "ClkOut Slave Ena";
            this.m_chkClkOutSlaveEna.UseVisualStyleBackColor = true;
            // 
            // m_chkSynOutMasterDis
            // 
            this.m_chkSynOutMasterDis.AutoSize = true;
            this.m_chkSynOutMasterDis.Location = new System.Drawing.Point(177, 138);
            this.m_chkSynOutMasterDis.Name = "m_chkSynOutMasterDis";
            this.m_chkSynOutMasterDis.Size = new System.Drawing.Size(133, 19);
            this.m_chkSynOutMasterDis.TabIndex = 12;
            this.m_chkSynOutMasterDis.Text = "SyncOut Master Dis";
            this.m_chkSynOutMasterDis.UseVisualStyleBackColor = true;
            // 
            // m_chkClkOutMasterDis
            // 
            this.m_chkClkOutMasterDis.AutoSize = true;
            this.m_chkClkOutMasterDis.Location = new System.Drawing.Point(16, 138);
            this.m_chkClkOutMasterDis.Name = "m_chkClkOutMasterDis";
            this.m_chkClkOutMasterDis.Size = new System.Drawing.Size(125, 19);
            this.m_chkClkOutMasterDis.TabIndex = 11;
            this.m_chkClkOutMasterDis.Text = "ClkOut Master Dis";
            this.m_chkClkOutMasterDis.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(13, 117);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(132, 15);
            this.label26.TabIndex = 10;
            this.label26.Text = "CasCading PinOut Cfg";
            // 
            // m_lblCascadeMode
            // 
            this.m_lblCascadeMode.AutoSize = true;
            this.m_lblCascadeMode.Location = new System.Drawing.Point(13, 90);
            this.m_lblCascadeMode.Name = "m_lblCascadeMode";
            this.m_lblCascadeMode.Size = new System.Drawing.Size(100, 15);
            this.m_lblCascadeMode.TabIndex = 9;
            this.m_lblCascadeMode.Text = "Cascading Mode";
            // 
            // m_RadarDeviceMode
            // 
            this.m_RadarDeviceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_RadarDeviceMode.FormattingEnabled = true;
            this.m_RadarDeviceMode.Items.AddRange(new object[] {
            "Single Chip",
            "Master",
            "Slave"});
            this.m_RadarDeviceMode.Location = new System.Drawing.Point(119, 86);
            this.m_RadarDeviceMode.Name = "m_RadarDeviceMode";
            this.m_RadarDeviceMode.Size = new System.Drawing.Size(95, 23);
            this.m_RadarDeviceMode.TabIndex = 8;
            // 
            // cbEnableRx4
            // 
            this.cbEnableRx4.AutoSize = true;
            this.cbEnableRx4.Location = new System.Drawing.Point(268, 53);
            this.cbEnableRx4.Name = "cbEnableRx4";
            this.cbEnableRx4.Size = new System.Drawing.Size(47, 19);
            this.cbEnableRx4.TabIndex = 7;
            this.cbEnableRx4.Text = "Rx3";
            this.cbEnableRx4.UseVisualStyleBackColor = true;
            // 
            // cbEnableRx3
            // 
            this.cbEnableRx3.AutoSize = true;
            this.cbEnableRx3.Location = new System.Drawing.Point(215, 53);
            this.cbEnableRx3.Name = "cbEnableRx3";
            this.cbEnableRx3.Size = new System.Drawing.Size(47, 19);
            this.cbEnableRx3.TabIndex = 6;
            this.cbEnableRx3.Text = "Rx2";
            this.cbEnableRx3.UseVisualStyleBackColor = true;
            // 
            // cbEnableRx2
            // 
            this.cbEnableRx2.AutoSize = true;
            this.cbEnableRx2.Location = new System.Drawing.Point(155, 53);
            this.cbEnableRx2.Name = "cbEnableRx2";
            this.cbEnableRx2.Size = new System.Drawing.Size(47, 19);
            this.cbEnableRx2.TabIndex = 5;
            this.cbEnableRx2.Text = "Rx1";
            this.cbEnableRx2.UseVisualStyleBackColor = true;
            // 
            // cbEnableRx1
            // 
            this.cbEnableRx1.AutoSize = true;
            this.cbEnableRx1.Location = new System.Drawing.Point(104, 53);
            this.cbEnableRx1.Name = "cbEnableRx1";
            this.cbEnableRx1.Size = new System.Drawing.Size(47, 19);
            this.cbEnableRx1.TabIndex = 4;
            this.cbEnableRx1.Text = "Rx0";
            this.cbEnableRx1.UseVisualStyleBackColor = true;
            // 
            // cbEnableTx3
            // 
            this.cbEnableTx3.AutoSize = true;
            this.cbEnableTx3.Location = new System.Drawing.Point(215, 18);
            this.cbEnableTx3.Name = "cbEnableTx3";
            this.cbEnableTx3.Size = new System.Drawing.Size(45, 19);
            this.cbEnableTx3.TabIndex = 3;
            this.cbEnableTx3.Text = "Tx2";
            this.cbEnableTx3.UseVisualStyleBackColor = true;
            // 
            // cbEnableTx2
            // 
            this.cbEnableTx2.AutoSize = true;
            this.cbEnableTx2.Location = new System.Drawing.Point(155, 18);
            this.cbEnableTx2.Name = "cbEnableTx2";
            this.cbEnableTx2.Size = new System.Drawing.Size(45, 19);
            this.cbEnableTx2.TabIndex = 2;
            this.cbEnableTx2.Text = "Tx1";
            this.cbEnableTx2.UseVisualStyleBackColor = true;
            // 
            // cbEnableTx1
            // 
            this.cbEnableTx1.AutoSize = true;
            this.cbEnableTx1.Location = new System.Drawing.Point(104, 18);
            this.cbEnableTx1.Name = "cbEnableTx1";
            this.cbEnableTx1.Size = new System.Drawing.Size(45, 19);
            this.cbEnableTx1.TabIndex = 1;
            this.cbEnableTx1.Text = "Tx0";
            this.cbEnableTx1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tx Channel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rx Channel";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(368, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 237);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Advanced Configuration";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.f00023b);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.m_comSupplyMonIOSupply);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.m_comSupplyMonIRDrop);
            this.groupBox7.Controls.Add(this.f000236);
            this.groupBox7.Controls.Add(this.f000237);
            this.groupBox7.Location = new System.Drawing.Point(7, 20);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(260, 122);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "RF LDO Bypass";
            // 
            // f00023b
            // 
            this.f00023b.AutoSize = true;
            this.f00023b.Location = new System.Drawing.Point(146, 41);
            this.f00023b.Name = "f00023b";
            this.f00023b.Size = new System.Drawing.Size(15, 14);
            this.f00023b.TabIndex = 22;
            this.f00023b.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 41);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(111, 15);
            this.label25.TabIndex = 21;
            this.label25.Text = "PA LDO I/P Disable";
            // 
            // m_comSupplyMonIOSupply
            // 
            this.m_comSupplyMonIOSupply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comSupplyMonIOSupply.FormattingEnabled = true;
            this.m_comSupplyMonIOSupply.Items.AddRange(new object[] {
            "3.3",
            "1.8"});
            this.m_comSupplyMonIOSupply.Location = new System.Drawing.Point(104, 89);
            this.m_comSupplyMonIOSupply.Name = "m_comSupplyMonIOSupply";
            this.m_comSupplyMonIOSupply.Size = new System.Drawing.Size(59, 23);
            this.m_comSupplyMonIOSupply.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 15);
            this.label17.TabIndex = 19;
            this.label17.Text = "IO Supply";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 15);
            this.label16.TabIndex = 16;
            this.label16.Text = "Supply IR Drop";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 15);
            this.label15.TabIndex = 15;
            this.label15.Text = "RF LDO Bypass Enable";
            // 
            // m_comSupplyMonIRDrop
            // 
            this.m_comSupplyMonIRDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comSupplyMonIRDrop.FormattingEnabled = true;
            this.m_comSupplyMonIRDrop.Items.AddRange(new object[] {
            "0%",
            "3%",
            "6%",
            "9%"});
            this.m_comSupplyMonIRDrop.Location = new System.Drawing.Point(104, 61);
            this.m_comSupplyMonIRDrop.Name = "m_comSupplyMonIRDrop";
            this.m_comSupplyMonIRDrop.Size = new System.Drawing.Size(59, 23);
            this.m_comSupplyMonIRDrop.TabIndex = 2;
            // 
            // f000236
            // 
            this.f000236.Location = new System.Drawing.Point(176, 88);
            this.f000236.Name = "f000236";
            this.f000236.Size = new System.Drawing.Size(75, 26);
            this.f000236.TabIndex = 1;
            this.f000236.Text = "Set";
            this.f000236.UseVisualStyleBackColor = true;
            // 
            // f000237
            // 
            this.f000237.AutoSize = true;
            this.f000237.Location = new System.Drawing.Point(146, 18);
            this.f000237.Name = "f000237";
            this.f000237.Size = new System.Drawing.Size(15, 14);
            this.f000237.TabIndex = 0;
            this.f000237.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(7, 271);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(308, 17);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Noise Figure Vs Linearity";
            this.groupBox5.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.m_btnLpModSet);
            this.groupBox4.Controls.Add(this.m_comLpAdcMod);
            this.groupBox4.Location = new System.Drawing.Point(7, 144);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 79);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "LP Mode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "LP ADC Mode";
            // 
            // m_btnLpModSet
            // 
            this.m_btnLpModSet.Location = new System.Drawing.Point(163, 45);
            this.m_btnLpModSet.Name = "m_btnLpModSet";
            this.m_btnLpModSet.Size = new System.Drawing.Size(75, 28);
            this.m_btnLpModSet.TabIndex = 14;
            this.m_btnLpModSet.Text = "Set";
            this.m_btnLpModSet.UseVisualStyleBackColor = true;
            // 
            // m_comLpAdcMod
            // 
            this.m_comLpAdcMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comLpAdcMod.FormattingEnabled = true;
            this.m_comLpAdcMod.Items.AddRange(new object[] {
            "Regular ADC",
            "Low Power ADC"});
            this.m_comLpAdcMod.Location = new System.Drawing.Point(118, 17);
            this.m_comLpAdcMod.Name = "m_comLpAdcMod";
            this.m_comLpAdcMod.Size = new System.Drawing.Size(121, 23);
            this.m_comLpAdcMod.TabIndex = 13;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.m_grpRFDeviceConfig);
            this.groupBox6.Controls.Add(this.groupBox1);
            this.groupBox6.Controls.Add(this.m_grpFreqLimitsConfig);
            this.groupBox6.Controls.Add(this.m_grpRadarMiscCtl);
            this.groupBox6.Controls.Add(this.m_btnRfInit);
            this.groupBox6.Controls.Add(this.m_grpBasicConf);
            this.groupBox6.Controls.Add(this.groupBox3);
            this.groupBox6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(4, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1319, 530);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Static Configuration";
            // 
            // m_grpRFDeviceConfig
            // 
            this.m_grpRFDeviceConfig.Controls.Add(this.f000238);
            this.m_grpRFDeviceConfig.Controls.Add(this.m_chkBSSDigWatchDogTimerCtlEnaDisble);
            this.m_grpRFDeviceConfig.Controls.Add(this.m_chkFrameStopAECtlEnaDisble);
            this.m_grpRFDeviceConfig.Controls.Add(this.m_chkFrameStartAECtlEnaDisble);
            this.m_grpRFDeviceConfig.Controls.Add(this.label24);
            this.m_grpRFDeviceConfig.Controls.Add(this.label23);
            this.m_grpRFDeviceConfig.Controls.Add(this.f000239);
            this.m_grpRFDeviceConfig.Controls.Add(this.f00023a);
            this.m_grpRFDeviceConfig.Controls.Add(this.m_btnRFDeviceAEDirectionControlConfigSet);
            this.m_grpRFDeviceConfig.Controls.Add(this.label22);
            this.m_grpRFDeviceConfig.Controls.Add(this.label21);
            this.m_grpRFDeviceConfig.Controls.Add(this.label20);
            this.m_grpRFDeviceConfig.Controls.Add(this.label19);
            this.m_grpRFDeviceConfig.Location = new System.Drawing.Point(1004, 39);
            this.m_grpRFDeviceConfig.Name = "m_grpRFDeviceConfig";
            this.m_grpRFDeviceConfig.Size = new System.Drawing.Size(294, 175);
            this.m_grpRFDeviceConfig.TabIndex = 22;
            this.m_grpRFDeviceConfig.TabStop = false;
            this.m_grpRFDeviceConfig.Text = "RF Device Configuration";
            // 
            // f000238
            // 
            this.f000238.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f000238.FormattingEnabled = true;
            this.f000238.Items.AddRange(new object[] {
            "CRC-16",
            "CRC-32",
            "CRC-64"});
            this.f000238.Location = new System.Drawing.Point(102, 120);
            this.f000238.Name = "f000238";
            this.f000238.Size = new System.Drawing.Size(84, 23);
            this.f000238.TabIndex = 12;
            // 
            // m_chkBSSDigWatchDogTimerCtlEnaDisble
            // 
            this.m_chkBSSDigWatchDogTimerCtlEnaDisble.AutoSize = true;
            this.m_chkBSSDigWatchDogTimerCtlEnaDisble.Location = new System.Drawing.Point(102, 96);
            this.m_chkBSSDigWatchDogTimerCtlEnaDisble.Name = "m_chkBSSDigWatchDogTimerCtlEnaDisble";
            this.m_chkBSSDigWatchDogTimerCtlEnaDisble.Size = new System.Drawing.Size(116, 19);
            this.m_chkBSSDigWatchDogTimerCtlEnaDisble.TabIndex = 11;
            this.m_chkBSSDigWatchDogTimerCtlEnaDisble.Text = "Watchdog Timer";
            this.m_chkBSSDigWatchDogTimerCtlEnaDisble.UseVisualStyleBackColor = true;
            // 
            // m_chkFrameStopAECtlEnaDisble
            // 
            this.m_chkFrameStopAECtlEnaDisble.AutoSize = true;
            this.m_chkFrameStopAECtlEnaDisble.Location = new System.Drawing.Point(206, 71);
            this.m_chkFrameStopAECtlEnaDisble.Name = "m_chkFrameStopAECtlEnaDisble";
            this.m_chkFrameStopAECtlEnaDisble.Size = new System.Drawing.Size(90, 19);
            this.m_chkFrameStopAECtlEnaDisble.TabIndex = 10;
            this.m_chkFrameStopAECtlEnaDisble.Text = "Frame Stop";
            this.m_chkFrameStopAECtlEnaDisble.UseVisualStyleBackColor = true;
            // 
            // m_chkFrameStartAECtlEnaDisble
            // 
            this.m_chkFrameStartAECtlEnaDisble.AutoSize = true;
            this.m_chkFrameStartAECtlEnaDisble.Location = new System.Drawing.Point(102, 71);
            this.m_chkFrameStartAECtlEnaDisble.Name = "m_chkFrameStartAECtlEnaDisble";
            this.m_chkFrameStartAECtlEnaDisble.Size = new System.Drawing.Size(90, 19);
            this.m_chkFrameStartAECtlEnaDisble.TabIndex = 9;
            this.m_chkFrameStartAECtlEnaDisble.Text = "Frame Start";
            this.m_chkFrameStartAECtlEnaDisble.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(204, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(66, 15);
            this.label24.TabIndex = 8;
            this.label24.Text = "Mon AE Dir";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(99, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(97, 15);
            this.label23.TabIndex = 7;
            this.label23.Text = "CPU\\ESM AE Dir";
            // 
            // f000239
            // 
            this.f000239.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f000239.FormattingEnabled = true;
            this.f000239.Items.AddRange(new object[] {
            "BSS TO MSS",
            "BSS TO HOST",
            "BSS TO DSS"});
            this.f000239.Location = new System.Drawing.Point(201, 39);
            this.f000239.Name = "f000239";
            this.f000239.Size = new System.Drawing.Size(90, 23);
            this.f000239.TabIndex = 6;
            // 
            // f00023a
            // 
            this.f00023a.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f00023a.FormattingEnabled = true;
            this.f00023a.Items.AddRange(new object[] {
            "BSS TO MSS",
            "BSS TO HOST",
            "BSS TO DSS"});
            this.f00023a.Location = new System.Drawing.Point(102, 39);
            this.f00023a.Name = "f00023a";
            this.f00023a.Size = new System.Drawing.Size(90, 23);
            this.f00023a.TabIndex = 5;
            // 
            // m_btnRFDeviceAEDirectionControlConfigSet
            // 
            this.m_btnRFDeviceAEDirectionControlConfigSet.Location = new System.Drawing.Point(201, 142);
            this.m_btnRFDeviceAEDirectionControlConfigSet.Name = "m_btnRFDeviceAEDirectionControlConfigSet";
            this.m_btnRFDeviceAEDirectionControlConfigSet.Size = new System.Drawing.Size(75, 26);
            this.m_btnRFDeviceAEDirectionControlConfigSet.TabIndex = 4;
            this.m_btnRFDeviceAEDirectionControlConfigSet.Text = "Set";
            this.m_btnRFDeviceAEDirectionControlConfigSet.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 127);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 15);
            this.label22.TabIndex = 3;
            this.label22.Text = "AE CRC Cfg";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(5, 96);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 15);
            this.label21.TabIndex = 2;
            this.label21.Text = "BSS Dig Control";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(5, 73);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(87, 15);
            this.label20.TabIndex = 1;
            this.label20.Text = "AE Dis Control";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 15);
            this.label19.TabIndex = 0;
            this.label19.Text = "RF AE Direction";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_nudPowerBackOffTx3);
            this.groupBox1.Controls.Add(this.m_nudPowerBackOffTx2);
            this.groupBox1.Controls.Add(this.m_nudPowerBackOffTx1);
            this.groupBox1.Controls.Add(this.m_nudFreqLimitHighTx3);
            this.groupBox1.Controls.Add(this.m_nudFreqLimitHighTx2);
            this.groupBox1.Controls.Add(this.m_nudFreqLimitHighTx1);
            this.groupBox1.Controls.Add(this.m_nudFreqLimitLowTx3);
            this.groupBox1.Controls.Add(this.m_nudFreqLimitLowTx2);
            this.groupBox1.Controls.Add(this.m_nudFreqLimitLowTx1);
            this.groupBox1.Controls.Add(this.m_btnCalMonFreqTxPowerLimitConfigSet);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(697, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 168);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cal Mon Frequency TX Power Limits Config";
            // 
            // m_nudPowerBackOffTx3
            // 
            this.m_nudPowerBackOffTx3.Location = new System.Drawing.Point(226, 100);
            this.m_nudPowerBackOffTx3.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.m_nudPowerBackOffTx3.Name = "m_nudPowerBackOffTx3";
            this.m_nudPowerBackOffTx3.Size = new System.Drawing.Size(56, 21);
            this.m_nudPowerBackOffTx3.TabIndex = 15;
            // 
            // m_nudPowerBackOffTx2
            // 
            this.m_nudPowerBackOffTx2.Location = new System.Drawing.Point(167, 100);
            this.m_nudPowerBackOffTx2.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.m_nudPowerBackOffTx2.Name = "m_nudPowerBackOffTx2";
            this.m_nudPowerBackOffTx2.Size = new System.Drawing.Size(53, 21);
            this.m_nudPowerBackOffTx2.TabIndex = 14;
            // 
            // m_nudPowerBackOffTx1
            // 
            this.m_nudPowerBackOffTx1.Location = new System.Drawing.Point(104, 100);
            this.m_nudPowerBackOffTx1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.m_nudPowerBackOffTx1.Name = "m_nudPowerBackOffTx1";
            this.m_nudPowerBackOffTx1.Size = new System.Drawing.Size(56, 21);
            this.m_nudPowerBackOffTx1.TabIndex = 13;
            // 
            // m_nudFreqLimitHighTx3
            // 
            this.m_nudFreqLimitHighTx3.DecimalPlaces = 2;
            this.m_nudFreqLimitHighTx3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudFreqLimitHighTx3.Location = new System.Drawing.Point(226, 71);
            this.m_nudFreqLimitHighTx3.Maximum = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            this.m_nudFreqLimitHighTx3.Minimum = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            this.m_nudFreqLimitHighTx3.Name = "m_nudFreqLimitHighTx3";
            this.m_nudFreqLimitHighTx3.Size = new System.Drawing.Size(56, 21);
            this.m_nudFreqLimitHighTx3.TabIndex = 12;
            this.m_nudFreqLimitHighTx3.Value = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            // 
            // m_nudFreqLimitHighTx2
            // 
            this.m_nudFreqLimitHighTx2.DecimalPlaces = 2;
            this.m_nudFreqLimitHighTx2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudFreqLimitHighTx2.Location = new System.Drawing.Point(167, 71);
            this.m_nudFreqLimitHighTx2.Maximum = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            this.m_nudFreqLimitHighTx2.Minimum = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            this.m_nudFreqLimitHighTx2.Name = "m_nudFreqLimitHighTx2";
            this.m_nudFreqLimitHighTx2.Size = new System.Drawing.Size(53, 21);
            this.m_nudFreqLimitHighTx2.TabIndex = 11;
            this.m_nudFreqLimitHighTx2.Value = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            // 
            // m_nudFreqLimitHighTx1
            // 
            this.m_nudFreqLimitHighTx1.DecimalPlaces = 2;
            this.m_nudFreqLimitHighTx1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudFreqLimitHighTx1.Location = new System.Drawing.Point(104, 71);
            this.m_nudFreqLimitHighTx1.Maximum = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            this.m_nudFreqLimitHighTx1.Minimum = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            this.m_nudFreqLimitHighTx1.Name = "m_nudFreqLimitHighTx1";
            this.m_nudFreqLimitHighTx1.Size = new System.Drawing.Size(56, 21);
            this.m_nudFreqLimitHighTx1.TabIndex = 10;
            this.m_nudFreqLimitHighTx1.Value = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            // 
            // m_nudFreqLimitLowTx3
            // 
            this.m_nudFreqLimitLowTx3.DecimalPlaces = 2;
            this.m_nudFreqLimitLowTx3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudFreqLimitLowTx3.Location = new System.Drawing.Point(226, 42);
            this.m_nudFreqLimitLowTx3.Maximum = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            this.m_nudFreqLimitLowTx3.Minimum = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            this.m_nudFreqLimitLowTx3.Name = "m_nudFreqLimitLowTx3";
            this.m_nudFreqLimitLowTx3.Size = new System.Drawing.Size(56, 21);
            this.m_nudFreqLimitLowTx3.TabIndex = 9;
            this.m_nudFreqLimitLowTx3.Value = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            // 
            // m_nudFreqLimitLowTx2
            // 
            this.m_nudFreqLimitLowTx2.DecimalPlaces = 2;
            this.m_nudFreqLimitLowTx2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudFreqLimitLowTx2.Location = new System.Drawing.Point(167, 42);
            this.m_nudFreqLimitLowTx2.Maximum = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            this.m_nudFreqLimitLowTx2.Minimum = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            this.m_nudFreqLimitLowTx2.Name = "m_nudFreqLimitLowTx2";
            this.m_nudFreqLimitLowTx2.Size = new System.Drawing.Size(53, 21);
            this.m_nudFreqLimitLowTx2.TabIndex = 8;
            this.m_nudFreqLimitLowTx2.Value = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            // 
            // m_nudFreqLimitLowTx1
            // 
            this.m_nudFreqLimitLowTx1.DecimalPlaces = 2;
            this.m_nudFreqLimitLowTx1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_nudFreqLimitLowTx1.Location = new System.Drawing.Point(104, 42);
            this.m_nudFreqLimitLowTx1.Maximum = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            this.m_nudFreqLimitLowTx1.Minimum = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            this.m_nudFreqLimitLowTx1.Name = "m_nudFreqLimitLowTx1";
            this.m_nudFreqLimitLowTx1.Size = new System.Drawing.Size(56, 21);
            this.m_nudFreqLimitLowTx1.TabIndex = 7;
            this.m_nudFreqLimitLowTx1.Value = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            // 
            // m_btnCalMonFreqTxPowerLimitConfigSet
            // 
            this.m_btnCalMonFreqTxPowerLimitConfigSet.Location = new System.Drawing.Point(208, 129);
            this.m_btnCalMonFreqTxPowerLimitConfigSet.Name = "m_btnCalMonFreqTxPowerLimitConfigSet";
            this.m_btnCalMonFreqTxPowerLimitConfigSet.Size = new System.Drawing.Size(75, 26);
            this.m_btnCalMonFreqTxPowerLimitConfigSet.TabIndex = 6;
            this.m_btnCalMonFreqTxPowerLimitConfigSet.Text = "Set";
            this.m_btnCalMonFreqTxPowerLimitConfigSet.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(233, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 15);
            this.label14.TabIndex = 5;
            this.label14.Text = "Tx2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(179, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "Tx1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(119, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Tx0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Power Backoff";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Freq Limit High";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Freq Limit Low ";
            // 
            // m_grpFreqLimitsConfig
            // 
            this.m_grpFreqLimitsConfig.Controls.Add(this.m_nudFreqLimitHigh);
            this.m_grpFreqLimitsConfig.Controls.Add(this.m_nudFreqLimitLow);
            this.m_grpFreqLimitsConfig.Controls.Add(this.label7);
            this.m_grpFreqLimitsConfig.Controls.Add(this.label5);
            this.m_grpFreqLimitsConfig.Controls.Add(this.m_btnFreqLimitConfigSet);
            this.m_grpFreqLimitsConfig.Location = new System.Drawing.Point(697, 39);
            this.m_grpFreqLimitsConfig.Name = "m_grpFreqLimitsConfig";
            this.m_grpFreqLimitsConfig.Size = new System.Drawing.Size(281, 155);
            this.m_grpFreqLimitsConfig.TabIndex = 19;
            this.m_grpFreqLimitsConfig.TabStop = false;
            this.m_grpFreqLimitsConfig.Text = "Frequency Limits Configuration";
            // 
            // m_nudFreqLimitHigh
            // 
            this.m_nudFreqLimitHigh.DecimalPlaces = 1;
            this.m_nudFreqLimitHigh.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudFreqLimitHigh.Location = new System.Drawing.Point(172, 70);
            this.m_nudFreqLimitHigh.Maximum = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            this.m_nudFreqLimitHigh.Minimum = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            this.m_nudFreqLimitHigh.Name = "m_nudFreqLimitHigh";
            this.m_nudFreqLimitHigh.Size = new System.Drawing.Size(61, 21);
            this.m_nudFreqLimitHigh.TabIndex = 4;
            this.m_nudFreqLimitHigh.Value = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            // 
            // m_nudFreqLimitLow
            // 
            this.m_nudFreqLimitLow.DecimalPlaces = 1;
            this.m_nudFreqLimitLow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nudFreqLimitLow.Location = new System.Drawing.Point(172, 30);
            this.m_nudFreqLimitLow.Maximum = new decimal(new int[] {
            810,
            0,
            0,
            65536});
            this.m_nudFreqLimitLow.Minimum = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            this.m_nudFreqLimitLow.Name = "m_nudFreqLimitLow";
            this.m_nudFreqLimitLow.Size = new System.Drawing.Size(61, 21);
            this.m_nudFreqLimitLow.TabIndex = 3;
            this.m_nudFreqLimitLow.Value = new decimal(new int[] {
            760,
            0,
            0,
            65536});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Frequency Limit High (GHz)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Frequency Limit Low (GHz)";
            // 
            // m_btnFreqLimitConfigSet
            // 
            this.m_btnFreqLimitConfigSet.Location = new System.Drawing.Point(154, 113);
            this.m_btnFreqLimitConfigSet.Name = "m_btnFreqLimitConfigSet";
            this.m_btnFreqLimitConfigSet.Size = new System.Drawing.Size(80, 28);
            this.m_btnFreqLimitConfigSet.TabIndex = 0;
            this.m_btnFreqLimitConfigSet.Text = "Set";
            this.m_btnFreqLimitConfigSet.UseVisualStyleBackColor = true;
            // 
            // m_grpRadarMiscCtl
            // 
            this.m_grpRadarMiscCtl.Controls.Add(this.m_btnRFMiscControlSet);
            this.m_grpRadarMiscCtl.Controls.Add(this.m_chkPerChirpPhaseShifterEnable);
            this.m_grpRadarMiscCtl.Location = new System.Drawing.Point(370, 288);
            this.m_grpRadarMiscCtl.Name = "m_grpRadarMiscCtl";
            this.m_grpRadarMiscCtl.Size = new System.Drawing.Size(184, 113);
            this.m_grpRadarMiscCtl.TabIndex = 18;
            this.m_grpRadarMiscCtl.TabStop = false;
            this.m_grpRadarMiscCtl.Text = "Radar Miscellaneous Control";
            // 
            // m_btnRFMiscControlSet
            // 
            this.m_btnRFMiscControlSet.Location = new System.Drawing.Point(6, 70);
            this.m_btnRFMiscControlSet.Name = "m_btnRFMiscControlSet";
            this.m_btnRFMiscControlSet.Size = new System.Drawing.Size(75, 30);
            this.m_btnRFMiscControlSet.TabIndex = 18;
            this.m_btnRFMiscControlSet.Text = "Set";
            this.m_btnRFMiscControlSet.UseVisualStyleBackColor = true;
            // 
            // m_chkPerChirpPhaseShifterEnable
            // 
            this.m_chkPerChirpPhaseShifterEnable.AutoSize = true;
            this.m_chkPerChirpPhaseShifterEnable.Location = new System.Drawing.Point(6, 34);
            this.m_chkPerChirpPhaseShifterEnable.Name = "m_chkPerChirpPhaseShifterEnable";
            this.m_chkPerChirpPhaseShifterEnable.Size = new System.Drawing.Size(173, 19);
            this.m_chkPerChirpPhaseShifterEnable.TabIndex = 17;
            this.m_chkPerChirpPhaseShifterEnable.Text = "Per Chirp Phase Shifter En";
            this.m_chkPerChirpPhaseShifterEnable.UseVisualStyleBackColor = true;
            // 
            // m_btnRfInit
            // 
            this.m_btnRfInit.Location = new System.Drawing.Point(564, 308);
            this.m_btnRfInit.Name = "m_btnRfInit";
            this.m_btnRfInit.Size = new System.Drawing.Size(119, 44);
            this.m_btnRfInit.TabIndex = 16;
            this.m_btnRfInit.Text = "RF Init";
            this.m_btnRfInit.UseVisualStyleBackColor = true;
            // 
            // StaticConfigTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox6);
            this.Name = "StaticConfigTab";
            this.Size = new System.Drawing.Size(1326, 537);
            this.m_grpBasicConf.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFullScaleReductionFactor)).EndInit();
            this.m_grpFreq.ResumeLayout(false);
            this.m_grpFreq.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.m_grpRFDeviceConfig.ResumeLayout(false);
            this.m_grpRFDeviceConfig.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPowerBackOffTx3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPowerBackOffTx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPowerBackOffTx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitHighTx3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitHighTx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitHighTx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitLowTx3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitLowTx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitLowTx1)).EndInit();
            this.m_grpFreqLimitsConfig.ResumeLayout(false);
            this.m_grpFreqLimitsConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFreqLimitLow)).EndInit();
            this.m_grpRadarMiscCtl.ResumeLayout(false);
            this.m_grpRadarMiscCtl.PerformLayout();
            this.ResumeLayout(false);

        }

        private void PostInitialization()
        {
            this.cbEnableTx1.Checked = true;
            this.cbEnableTx2.Checked = true;
            this.cbEnableRx1.Checked = true;
            this.cbEnableRx2.Checked = true;
            this.cbEnableRx3.Checked = true;
            this.cbEnableRx4.Checked = true;
            this.m_comLpAdcMod.SelectedIndex = 0;
            this.m_comBits.SelectedIndex = 2;
            this.m_comFmts.SelectedIndex = 1;
            this.m_comIQSwap.SelectedIndex = 0;
        }

        private GuiManager m_GuiManager = GlobalRef.GuiManager;
        private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;
        private frmAR1Main m_MainForm;
        private StaticParams m_StaticParams;
        private LpModConfParams m_LpModConfParams;
        private RFMiscConfigParams m_RFMiscConfigParams;
        private RFLDOBypassEnableAndDisableConfigParameters m_RFLDOBypassEnableAndDisableConfigParameters;
        private RFCalibFrequencyLimitConfigParameters m_RFCalibFrequencyLimitConfigParameters;
        private CalMonFrequencyTxPowerLimitConfigParameters m_CalMonFrequencyTxPowerLimitConfigParameters;
        private RFDeviceAEControlConfigParameters m_RFDeviceAEControlConfigParameters;
        private DataConfigTab DataConfigHandler = new DataConfigTab();
        private IContainer components;
        private GroupBox m_grpBasicConf;
        private Label label2;
        private Label label1;
        private GroupBox m_grpFreq;
        private Button m_btnBasicConfSet;
        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private ComboBox m_comFmts;
        private ComboBox m_comBits;
        private GroupBox groupBox3;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private Button m_btnLpModSet;
        private Label label6;
        private ComboBox m_comLpAdcMod;
        private Label label8;
        private ComboBox m_comIQSwap;
        private GroupBox groupBox6;
        private Button m_btnRfInit;
        private CheckBox cbEnableTx3;
        private CheckBox cbEnableTx2;
        private CheckBox cbEnableTx1;
        private CheckBox cbEnableRx4;
        private CheckBox cbEnableRx3;
        private CheckBox cbEnableRx2;
        private CheckBox cbEnableRx1;
        private Label m_lblCascadeMode;
        private ComboBox m_RadarDeviceMode;
        private GroupBox groupBox7;
        private Button f000236;
        private CheckBox f000237;
        private GroupBox m_grpRadarMiscCtl;
        private Button m_btnRFMiscControlSet;
        private CheckBox m_chkPerChirpPhaseShifterEnable;
        private GroupBox m_grpFreqLimitsConfig;
        private Label label7;
        private Label label5;
        private Button m_btnFreqLimitConfigSet;
        private NumericUpDown m_nudFreqLimitHigh;
        private NumericUpDown m_nudFreqLimitLow;
        private GroupBox groupBox1;
        private NumericUpDown m_nudPowerBackOffTx3;
        private NumericUpDown m_nudPowerBackOffTx2;
        private NumericUpDown m_nudPowerBackOffTx1;
        private NumericUpDown m_nudFreqLimitHighTx3;
        private NumericUpDown m_nudFreqLimitHighTx2;
        private NumericUpDown m_nudFreqLimitHighTx1;
        private NumericUpDown m_nudFreqLimitLowTx3;
        private NumericUpDown m_nudFreqLimitLowTx2;
        private NumericUpDown m_nudFreqLimitLowTx1;
        private Button m_btnCalMonFreqTxPowerLimitConfigSet;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label16;
        private Label label15;
        private ComboBox m_comSupplyMonIRDrop;
        private GroupBox m_grpRFDeviceConfig;
        private ComboBox f000238;
        private CheckBox m_chkBSSDigWatchDogTimerCtlEnaDisble;
        private CheckBox m_chkFrameStopAECtlEnaDisble;
        private CheckBox m_chkFrameStartAECtlEnaDisble;
        private Label label24;
        private Label label23;
        private ComboBox f000239;
        private ComboBox f00023a;
        private Button m_btnRFDeviceAEDirectionControlConfigSet;
        private Label label22;
        private Label label21;
        private Label label20;
        private Label label19;
        private ComboBox m_comSupplyMonIOSupply;
        private Label label17;
        private NumericUpDown m_nudFullScaleReductionFactor;
        private Label label18;
        private CheckBox f00023b;
        private Label label25;
        private CheckBox m_chkOSCClkOutMasterDis;
        private CheckBox m_chkIntLOMasterEna;
        private CheckBox m_chkSynOutSlaveEna;
        private CheckBox m_chkClkOutSlaveEna;
        private CheckBox m_chkSynOutMasterDis;
        private CheckBox m_chkClkOutMasterDis;
        private Label label26;
    }
}
