using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
    public class AdvanceFrameConfigTab : UserControl
    {
        public AdvanceFrameConfigTab()
        {
            InitializeComponent();
            m_MainForm = m_GuiManager.MainTsForm;
            m_AdvancedFrameConfigParams = m_GuiManager.TsParams.AdvancedFrameConfigParams;
            m_AdvChirpConfigParams = m_GuiManager.TsParams.AdvChirpConfigParams;
            m_LoopBackBurstConfigParams = m_GuiManager.TsParams.LoopBackBurstConfigParams;
            m_SWSubFrameStartStopConfigParams = m_GuiManager.TsParams.SWSubFrameStartStopConfigParams;
            EnabledDefaultSubFrame0();
            SetResetForceProfilStatus();
            EnableDisableSubFramesBasedOnRadarDeviceType();
            m_nudLoopBackCfgSubFrameID.Value = 3m;
            f0000f2.SelectedIndex = 23;
            f0000fd.SelectedIndex = 23;
            m_CbLoopBackSelect.SelectedIndex = 0;
            m_CbRFGainTarget.SelectedIndex = 0;
            f0000f3.SelectedIndex = 0;
            m_grpAdvChirp.Visible = false;
        }

        public void EnableDisableSubFramesBasedOnRadarDeviceType()
        {
            if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR14xxDevice || GlobalRef.g_AR2243Device)
            {
                m_nudNoOfAdcSamples.Enabled = false;
                m_nudNoOfAdcSamples2.Enabled = false;
                m_nudNoOfAdcSamples3.Enabled = false;
                m_nudNoOfAdcSamples4.Enabled = false;
                return;
            }
            if (GlobalRef.g_AR16xxDevice || GlobalRef.g_AR6843Device || GlobalRef.g_AR1843Device)
            {
                m_nudNoOfAdcSamples.Enabled = true;
                m_nudNoOfAdcSamples2.Enabled = true;
                m_nudNoOfAdcSamples3.Enabled = true;
                m_nudNoOfAdcSamples4.Enabled = true;
            }
        }

        public bool UpdateLoopbackBurstGui(RootObject jobject, int p1, int burstInd)
        {
            m_CbLoopBackSelect.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.loopbackSel;
            m_nudLPBBaseProfileIndex.Value = jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.baseProfileIndx;
            m_nudLPBBusrtIndex.Value = jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.burstIndx;
            m_nudLPBFreqConst.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.freqConst_GHz;
            m_nudLPBSlopeConst.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.slopeConst_MHz_us;
            m_nudLPBTx1BackOff.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.txBackoff, 16) & 255);
            m_nudLPBTx2BackOff.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.txBackoff, 16) & 65280) >> 8;
            m_nudLPBTx3BackOff.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.txBackoff, 16) & 16776960) >> 16;
            m_nudLPBRxGain.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.rxGain_dB, 16) & 63);
            if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.rxGain_dB, 16) & 192) >> 6 == 0)
            {
                m_CbRFGainTarget.SelectedIndex = 0;
            }
            else if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.rxGain_dB, 16) & 192) >> 6 == 1)
            {
                m_CbRFGainTarget.SelectedIndex = 1;
            }
            else if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.rxGain_dB, 16) & 192) >> 6 == 3)
            {
                m_CbRFGainTarget.SelectedIndex = 2;
            }
            m_chLPBTx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.txEn, 16) & 1) == 1);
            m_chLPBTx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.txEn, 16) & 2) >> 1 == 1);
            m_chLPBTx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.txEn, 16) & 4) >> 2 == 1);
            f0000f9.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.bpmConfig, 16) & 1) == 1);
            f0000f8.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.bpmConfig, 16) & 2) >> 1 == 1);
            f0000f7.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.bpmConfig, 16) & 4) >> 2 == 1);
            f0000f6.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.bpmConfig, 16) & 8) >> 3 == 1);
            f0000f5.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.bpmConfig, 16) & 16) >> 4 == 1);
            f0000f4.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.bpmConfig, 16) & 32) >> 5 == 1);
            m_chLPBDigitalCorrDisable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.digCorrDis, 16) & 1) == 1);
            m_chLPBDigCorrRxGainPhase.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.digCorrDis, 16) & 2) >> 1 == 1);
            f0000f3.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.ifLbFreq;
            f0000fc.Value = jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.ifLbMag_10mv;
            f0000f2.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.ps1PgaIndx;
            f0000fd.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.ps2PgaIndx;
            f0000fe.Value = jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.p00000f;
            f0000fa.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.p00000e, 16) & 65535);
            f0000fb.Value = ((long)Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts[burstInd].rlLoopbackBurst_t.p00000e, 16) & 4294901760L) >> 16;
            return true;
        }

        public bool UpdateAdvFrameConfig(RootObject jobject, int p1)
        {
            bool result;
            try
            {
                if (jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.isConfigured == 0)
                {
                    string msg = string.Format("Missing Advanced Frame Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg);
                }
                else
                {
                    m_nudNumOfSubFrames.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.numOfSubFrames;
                    m_ChkBxForceProfile.Checked = (jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.forceProfile == 1);
                    m_nudNumOfFrames.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.numFrames;
                    if (jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.triggerSelect == 1)
                    {
                        m_chbSelectSoftwareTrigger.Checked = true;
                    }
                    else if (jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.triggerSelect == 2)
                    {
                        m_chbSelectHardwareTrigger.Checked = true;
                    }
                    m_nudFrameTriggerDelay.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.frameTrigDelay_usec;
                    m_ChkBxLoopBackCfg.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.loopBackCfg, 16) & 1) == 1);
                    m_nudLoopBackCfgSubFrameID.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.loopBackCfg, 16) & 6) >> 1;
                    m_ChkSWSubFrameTriggerCfg.Checked = (jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameTrigger == 1);
                    m_nudForceProfileIdx.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[0].rlSubFrameCfg_t.forceProfileIdx;
                    m_nudChirpStartIdx.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[0].rlSubFrameCfg_t.chirpStartIdx;
                    m_nudNumOfChirps.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[0].rlSubFrameCfg_t.numOfChirps;
                    m_nudNumOfLoops.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[0].rlSubFrameCfg_t.numLoops;
                    m_nudBrustPeriodicity.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[0].rlSubFrameCfg_t.burstPeriodicity_msec;
                    m_nudChirpStartIdxOffset.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[0].rlSubFrameCfg_t.chirpStartIdxOffset;
                    m_nudNumOfBrust.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[0].rlSubFrameCfg_t.numOfBurst;
                    m_nudNumOfBrustLoops.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[0].rlSubFrameCfg_t.numOfBurstLoops;
                    m_nudSubFramePeriod.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[0].rlSubFrameCfg_t.subFramePeriodicity_msec;
                    m_nudNoOfAdcSamples.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameData.subframeDataCfg[0].rlSubFrameDataCfg_t.numChirpsInDataPacket;
                    m_nudForceProfileIdx2.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[1].rlSubFrameCfg_t.forceProfileIdx;
                    m_nudChirpStartIdx2.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[1].rlSubFrameCfg_t.chirpStartIdx;
                    m_nudNumOfChirps2.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[1].rlSubFrameCfg_t.numOfChirps;
                    m_nudNumOfLoops2.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[1].rlSubFrameCfg_t.numLoops;
                    m_nudBrustPeriodicity2.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[1].rlSubFrameCfg_t.burstPeriodicity_msec;
                    m_nudChirpStartIdxOffset2.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[1].rlSubFrameCfg_t.chirpStartIdxOffset;
                    m_nudNumOfBrust2.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[1].rlSubFrameCfg_t.numOfBurst;
                    m_nudNumOfBrustLoops2.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[1].rlSubFrameCfg_t.numOfBurstLoops;
                    m_nudSubFramePeriod2.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[1].rlSubFrameCfg_t.subFramePeriodicity_msec;
                    m_nudNoOfAdcSamples2.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameData.subframeDataCfg[1].rlSubFrameDataCfg_t.numChirpsInDataPacket;
                    m_nudForceProfileIdx3.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[2].rlSubFrameCfg_t.forceProfileIdx;
                    m_nudChirpStartIdx3.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[2].rlSubFrameCfg_t.chirpStartIdx;
                    m_nudNumOfChirps3.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[2].rlSubFrameCfg_t.numOfChirps;
                    m_nudNumOfLoops3.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[2].rlSubFrameCfg_t.numLoops;
                    m_nudBrustPeriodicity3.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[2].rlSubFrameCfg_t.burstPeriodicity_msec;
                    m_nudChirpStartIdxOffset3.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[2].rlSubFrameCfg_t.chirpStartIdxOffset;
                    m_nudNumOfBrust3.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[2].rlSubFrameCfg_t.numOfBurst;
                    m_nudNumOfBrustLoops3.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[2].rlSubFrameCfg_t.numOfBurstLoops;
                    m_nudSubFramePeriod3.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[2].rlSubFrameCfg_t.subFramePeriodicity_msec;
                    m_nudNoOfAdcSamples3.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameData.subframeDataCfg[2].rlSubFrameDataCfg_t.numChirpsInDataPacket;
                    m_nudForceProfileIdx4.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[3].rlSubFrameCfg_t.forceProfileIdx;
                    m_nudChirpStartIdx4.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[3].rlSubFrameCfg_t.chirpStartIdx;
                    m_nudNumOfChirps4.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[3].rlSubFrameCfg_t.numOfChirps;
                    m_nudNumOfLoops4.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[3].rlSubFrameCfg_t.numLoops;
                    m_nudBrustPeriodicity4.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[3].rlSubFrameCfg_t.burstPeriodicity_msec;
                    m_nudChirpStartIdxOffset4.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[3].rlSubFrameCfg_t.chirpStartIdxOffset;
                    m_nudNumOfBrust4.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[3].rlSubFrameCfg_t.numOfBurst;
                    m_nudNumOfBrustLoops4.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[3].rlSubFrameCfg_t.numOfBurstLoops;
                    m_nudSubFramePeriod4.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameSeq.subFrameCfg[3].rlSubFrameCfg_t.subFramePeriodicity_msec;
                    m_nudNoOfAdcSamples4.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvFrameCfg_t.frameData.subframeDataCfg[3].rlSubFrameDataCfg_t.numChirpsInDataPacket;
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlLoopbackBursts.Count == 0)
                {
                    string msg2 = string.Format("Missing Loopback Burst Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg2);
                }
                else
                {
                    UpdateLoopbackBurstGui(jobject, p1, 0);
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlAdvChirpCfg_t.isConfigured == 0)
                {
                    string msg3 = string.Format("Missing Advanced Chirp Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg3);
                }
                else
                {
                    m_nudChirpParamIdx.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvChirpCfg_t.chirpParamIdx;
                    m_nudResetMode.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvChirpCfg_t.resetMode;
                    m_nudPatternMode.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvChirpCfg_t.patternMode;
                    m_nudResetPeriod.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvChirpCfg_t.resetPeriod;
                    m_nudParamPeriod.Value = jobject.mmWaveDevices[p1].rfConfig.rlAdvChirpCfg_t.paramUpdatePeriod;
                    m_nudFixedDeltaInc.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlAdvChirpCfg_t.fixedDeltaInc;
                }
                result = true;
            }
            catch
            {
                string msg4 = string.Format("Advanced Frame Config Tab Configuration= for device {0} is incorrect.", p1);
                GlobalRef.LuaWrapper.PrintError(msg4);
                result = false;
            }
            return result;
        }

        public bool UpdateAdvncedFrameConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(UpdateAdvncedFrameConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                m_AdvancedFrameConfigParams.NumOfSubFrames = (byte)m_nudNumOfSubFrames.Value;
                m_AdvancedFrameConfigParams.ForceProfile = (byte)(m_ChkBxForceProfile.Checked ? 1 : 0);
                m_AdvancedFrameConfigParams.NumOfFrames = (ushort)m_nudNumOfFrames.Value;
                if (m_chbSelectSoftwareTrigger.Checked)
                {
                    m_AdvancedFrameConfigParams.TriggerSelect = 1;
                }
                else if (m_chbSelectHardwareTrigger.Checked)
                {
                    m_AdvancedFrameConfigParams.TriggerSelect = 2;
                }
                else
                {
                    m_AdvancedFrameConfigParams.TriggerSelect = 1;
                }
                m_AdvancedFrameConfigParams.FrameTrigDelay = (float)m_nudFrameTriggerDelay.Value;
                m_AdvancedFrameConfigParams.LoopBackCfg = (byte)(m_ChkBxLoopBackCfg.Checked ? 1 : 0);
                m_AdvancedFrameConfigParams.SubFrameId = (byte)m_nudLoopBackCfgSubFrameID.Value;
                m_AdvancedFrameConfigParams.SWSubFrameTriggerMode = (byte)(m_ChkSWSubFrameTriggerCfg.Checked ? 1 : 0);
                m_AdvancedFrameConfigParams.ForceProfileIdx = (ushort)m_nudForceProfileIdx.Value;
                m_AdvancedFrameConfigParams.ChirpStartIdx = (ushort)m_nudChirpStartIdx.Value;
                m_AdvancedFrameConfigParams.NumOfChirps = (ushort)m_nudNumOfChirps.Value;
                m_AdvancedFrameConfigParams.NumOfLoops = (ushort)m_nudNumOfLoops.Value;
                m_AdvancedFrameConfigParams.BurstPeriodicity = (float)m_nudBrustPeriodicity.Value;
                m_AdvancedFrameConfigParams.ChirpStartIdxOffset = (ushort)m_nudChirpStartIdxOffset.Value;
                m_AdvancedFrameConfigParams.NumOfBrust = (ushort)m_nudNumOfBrust.Value;
                m_AdvancedFrameConfigParams.NumOfBrustLoops = (ushort)m_nudNumOfBrustLoops.Value;
                m_AdvancedFrameConfigParams.SubFramePeriodicity = (float)m_nudSubFramePeriod.Value;
                m_AdvancedFrameConfigParams.NumOfAdcSamples = (ushort)m_nudNoOfAdcSamples.Value;
                m_AdvancedFrameConfigParams.ForceProfileIdx2 = (ushort)m_nudForceProfileIdx2.Value;
                m_AdvancedFrameConfigParams.ChirpStartIdx2 = (ushort)m_nudChirpStartIdx2.Value;
                m_AdvancedFrameConfigParams.NumOfChirps2 = (ushort)m_nudNumOfChirps2.Value;
                m_AdvancedFrameConfigParams.NumOfLoops2 = (ushort)m_nudNumOfLoops2.Value;
                m_AdvancedFrameConfigParams.BurstPeriodicity2 = (float)m_nudBrustPeriodicity2.Value;
                m_AdvancedFrameConfigParams.ChirpStartIdxOffset2 = (ushort)m_nudChirpStartIdxOffset2.Value;
                m_AdvancedFrameConfigParams.NumOfBrust2 = (ushort)m_nudNumOfBrust2.Value;
                m_AdvancedFrameConfigParams.NumOfBrustLoops2 = (ushort)m_nudNumOfBrustLoops2.Value;
                m_AdvancedFrameConfigParams.SubFramePeriodicity2 = (float)m_nudSubFramePeriod2.Value;
                m_AdvancedFrameConfigParams.NumOfAdcSamples2 = (ushort)m_nudNoOfAdcSamples2.Value;
                m_AdvancedFrameConfigParams.ForceProfileIdx3 = (ushort)m_nudForceProfileIdx3.Value;
                m_AdvancedFrameConfigParams.ChirpStartIdx3 = (ushort)m_nudChirpStartIdx3.Value;
                m_AdvancedFrameConfigParams.NumOfChirps3 = (ushort)m_nudNumOfChirps3.Value;
                m_AdvancedFrameConfigParams.NumOfLoops3 = (ushort)m_nudNumOfLoops3.Value;
                m_AdvancedFrameConfigParams.BurstPeriodicity3 = (float)m_nudBrustPeriodicity3.Value;
                m_AdvancedFrameConfigParams.ChirpStartIdxOffset3 = (ushort)m_nudChirpStartIdxOffset3.Value;
                m_AdvancedFrameConfigParams.NumOfBrust3 = (ushort)m_nudNumOfBrust3.Value;
                m_AdvancedFrameConfigParams.NumOfBrustLoops3 = (ushort)m_nudNumOfBrustLoops3.Value;
                m_AdvancedFrameConfigParams.SubFramePeriodicity3 = (float)m_nudSubFramePeriod3.Value;
                m_AdvancedFrameConfigParams.NumOfAdcSamples3 = (ushort)m_nudNoOfAdcSamples3.Value;
                m_AdvancedFrameConfigParams.ForceProfileIdx4 = (ushort)m_nudForceProfileIdx4.Value;
                m_AdvancedFrameConfigParams.ChirpStartIdx4 = (ushort)m_nudChirpStartIdx4.Value;
                m_AdvancedFrameConfigParams.NumOfChirps4 = (ushort)m_nudNumOfChirps4.Value;
                m_AdvancedFrameConfigParams.NumOfLoops4 = (ushort)m_nudNumOfLoops4.Value;
                m_AdvancedFrameConfigParams.BurstPeriodicity4 = (float)m_nudBrustPeriodicity4.Value;
                m_AdvancedFrameConfigParams.ChirpStartIdxOffset4 = (ushort)m_nudChirpStartIdxOffset4.Value;
                m_AdvancedFrameConfigParams.NumOfBrust4 = (ushort)m_nudNumOfBrust4.Value;
                m_AdvancedFrameConfigParams.NumOfBrustLoops4 = (ushort)m_nudNumOfBrustLoops4.Value;
                m_AdvancedFrameConfigParams.SubFramePeriodicity4 = (float)m_nudSubFramePeriod4.Value;
                m_AdvancedFrameConfigParams.NumOfAdcSamples4 = (ushort)m_nudNoOfAdcSamples4.Value;
                m_AdvancedFrameConfigParams.testSourceEnable = (ushort)(m_chbAdvancedFrameTestSourceEnable.Checked ? 1 : 0);
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateAdvncedFrameConfigDataFrmCmd()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(UpdateAdvncedFrameConfigDataFrmCmd);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                m_nudNumOfSubFrames.Value = m_AdvancedFrameConfigParams.NumOfSubFrames;
                m_ChkBxForceProfile.Checked = (m_AdvancedFrameConfigParams.ForceProfile == 1);
                m_nudNumOfFrames.Value = m_AdvancedFrameConfigParams.NumOfFrames;
                if (m_AdvancedFrameConfigParams.TriggerSelect == 1)
                {
                    m_chbSelectSoftwareTrigger.Checked = true;
                }
                else if (m_AdvancedFrameConfigParams.TriggerSelect == 2)
                {
                    m_chbSelectHardwareTrigger.Checked = true;
                }
                m_nudFrameTriggerDelay.Value = (decimal)m_AdvancedFrameConfigParams.FrameTrigDelay;
                m_ChkBxLoopBackCfg.Checked = (m_AdvancedFrameConfigParams.LoopBackCfg == 1);
                m_nudLoopBackCfgSubFrameID.Value = m_AdvancedFrameConfigParams.SubFrameId;
                m_ChkSWSubFrameTriggerCfg.Checked = (m_AdvancedFrameConfigParams.SWSubFrameTriggerMode == 1);
                m_nudForceProfileIdx.Value = m_AdvancedFrameConfigParams.ForceProfileIdx;
                m_nudChirpStartIdx.Value = m_AdvancedFrameConfigParams.ChirpStartIdx;
                m_nudNumOfChirps.Value = m_AdvancedFrameConfigParams.NumOfChirps;
                m_nudNumOfLoops.Value = m_AdvancedFrameConfigParams.NumOfLoops;
                m_nudBrustPeriodicity.Value = (decimal)m_AdvancedFrameConfigParams.BurstPeriodicity;
                m_nudChirpStartIdxOffset.Value = m_AdvancedFrameConfigParams.ChirpStartIdxOffset;
                m_nudNumOfBrust.Value = m_AdvancedFrameConfigParams.NumOfBrust;
                m_nudNumOfBrustLoops.Value = m_AdvancedFrameConfigParams.NumOfBrustLoops;
                m_nudSubFramePeriod.Value = (decimal)m_AdvancedFrameConfigParams.SubFramePeriodicity;
                m_nudNoOfAdcSamples.Value = 1m;
                m_nudForceProfileIdx2.Value = m_AdvancedFrameConfigParams.ForceProfileIdx2;
                m_nudChirpStartIdx2.Value = m_AdvancedFrameConfigParams.ChirpStartIdx2;
                m_nudNumOfChirps2.Value = m_AdvancedFrameConfigParams.NumOfChirps2;
                m_nudNumOfLoops2.Value = m_AdvancedFrameConfigParams.NumOfLoops2;
                m_nudBrustPeriodicity2.Value = (decimal)m_AdvancedFrameConfigParams.BurstPeriodicity2;
                m_nudChirpStartIdxOffset2.Value = m_AdvancedFrameConfigParams.ChirpStartIdxOffset2;
                m_nudNumOfBrust2.Value = m_AdvancedFrameConfigParams.NumOfBrust2;
                m_nudNumOfBrustLoops2.Value = m_AdvancedFrameConfigParams.NumOfBrustLoops2;
                m_nudSubFramePeriod2.Value = (decimal)m_AdvancedFrameConfigParams.SubFramePeriodicity2;
                m_nudNoOfAdcSamples2.Value = 1m;
                m_nudForceProfileIdx3.Value = m_AdvancedFrameConfigParams.ForceProfileIdx3;
                m_nudChirpStartIdx3.Value = m_AdvancedFrameConfigParams.ChirpStartIdx3;
                m_nudNumOfChirps3.Value = m_AdvancedFrameConfigParams.NumOfChirps3;
                m_nudNumOfLoops3.Value = m_AdvancedFrameConfigParams.NumOfLoops3;
                m_nudBrustPeriodicity3.Value = (decimal)m_AdvancedFrameConfigParams.BurstPeriodicity3;
                m_nudChirpStartIdxOffset3.Value = m_AdvancedFrameConfigParams.ChirpStartIdxOffset3;
                m_nudNumOfBrust3.Value = m_AdvancedFrameConfigParams.NumOfBrust3;
                m_nudNumOfBrustLoops3.Value = m_AdvancedFrameConfigParams.NumOfBrustLoops3;
                m_nudSubFramePeriod3.Value = (decimal)m_AdvancedFrameConfigParams.SubFramePeriodicity3;
                m_nudNoOfAdcSamples3.Value = 1m;
                m_nudForceProfileIdx4.Value = m_AdvancedFrameConfigParams.ForceProfileIdx4;
                m_nudChirpStartIdx4.Value = m_AdvancedFrameConfigParams.ChirpStartIdx4;
                m_nudNumOfChirps4.Value = m_AdvancedFrameConfigParams.NumOfChirps4;
                m_nudNumOfLoops4.Value = m_AdvancedFrameConfigParams.NumOfLoops4;
                m_nudBrustPeriodicity4.Value = (decimal)m_AdvancedFrameConfigParams.BurstPeriodicity4;
                m_nudChirpStartIdxOffset4.Value = m_AdvancedFrameConfigParams.ChirpStartIdxOffset4;
                m_nudNumOfBrust4.Value = m_AdvancedFrameConfigParams.NumOfBrust4;
                m_nudNumOfBrustLoops4.Value = m_AdvancedFrameConfigParams.NumOfBrustLoops4;
                m_nudSubFramePeriod4.Value = (decimal)m_AdvancedFrameConfigParams.SubFramePeriodicity4;
                m_nudNoOfAdcSamples4.Value = 1m;
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private int iSetAdvncedFrameConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return m_GuiManager.ScriptOps.iAdvncedFrameConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetAdvncedFrameConfig()
        {
            iSetAdvncedFrameConfig_internal(true, false);
            m_MainForm.GuiOpEnd(true);
        }

        public void iSetAdvncedFrameConfigAsync()
        {
            new del_v_v(iSetAdvncedFrameConfig).BeginInvoke(null, null);
        }

        private void m_btnAdvFrameConfig_Click(object sender, EventArgs p1)
        {
            iSetAdvncedFrameConfigAsync();
        }

        private void m_nudNumOfSubFrames_ValueChanged(object sender, EventArgs p1)
        {
            int value = (int)m_nudNumOfSubFrames.Value;
            m_nudNumOfSubFrames.Value = value;
            if (m_nudNumOfSubFrames.Value == 1m)
            {
                if (!m_ChkBxForceProfile.Checked)
                {
                    m_nudForceProfileIdx.Enabled = false;
                }
                else
                {
                    m_nudForceProfileIdx.Enabled = true;
                }
                m_nudChirpStartIdx.Enabled = true;
                m_nudNumOfChirps.Enabled = true;
                m_nudNumOfLoops.Enabled = true;
                m_nudBrustPeriodicity.Enabled = true;
                m_nudChirpStartIdxOffset.Enabled = true;
                m_nudNumOfBrust.Enabled = true;
                m_nudNumOfBrustLoops.Enabled = true;
                m_nudSubFramePeriod.Enabled = true;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples.Enabled = true;
                }
                m_nudForceProfileIdx2.Enabled = false;
                m_nudChirpStartIdx2.Enabled = false;
                m_nudNumOfChirps2.Enabled = false;
                m_nudNumOfLoops2.Enabled = false;
                m_nudBrustPeriodicity2.Enabled = false;
                m_nudChirpStartIdxOffset2.Enabled = false;
                m_nudNumOfBrust2.Enabled = false;
                m_nudNumOfBrustLoops2.Enabled = false;
                m_nudSubFramePeriod2.Enabled = false;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples2.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples2.Enabled = false;
                }
                m_nudForceProfileIdx3.Enabled = false;
                m_nudChirpStartIdx3.Enabled = false;
                m_nudNumOfChirps3.Enabled = false;
                m_nudNumOfLoops3.Enabled = false;
                m_nudBrustPeriodicity3.Enabled = false;
                m_nudChirpStartIdxOffset3.Enabled = false;
                m_nudNumOfBrust3.Enabled = false;
                m_nudNumOfBrustLoops3.Enabled = false;
                m_nudSubFramePeriod3.Enabled = false;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples3.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples3.Enabled = false;
                }
                m_nudForceProfileIdx4.Enabled = false;
                m_nudChirpStartIdx4.Enabled = false;
                m_nudNumOfChirps4.Enabled = false;
                m_nudNumOfLoops4.Enabled = false;
                m_nudBrustPeriodicity4.Enabled = false;
                m_nudChirpStartIdxOffset4.Enabled = false;
                m_nudNumOfBrust4.Enabled = false;
                m_nudNumOfBrustLoops4.Enabled = false;
                m_nudSubFramePeriod4.Enabled = false;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples4.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples4.Enabled = false;
                }
            }
            if (m_nudNumOfSubFrames.Value == 2m)
            {
                if (!m_ChkBxForceProfile.Checked)
                {
                    m_nudForceProfileIdx.Enabled = false;
                }
                else
                {
                    m_nudForceProfileIdx.Enabled = true;
                }
                m_nudChirpStartIdx.Enabled = true;
                m_nudNumOfChirps.Enabled = true;
                m_nudNumOfLoops.Enabled = true;
                m_nudBrustPeriodicity.Enabled = true;
                m_nudChirpStartIdxOffset.Enabled = true;
                m_nudNumOfBrust.Enabled = true;
                m_nudNumOfBrustLoops.Enabled = true;
                m_nudSubFramePeriod.Enabled = true;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples.Enabled = true;
                }
                if (!m_ChkBxForceProfile.Checked)
                {
                    m_nudForceProfileIdx2.Enabled = false;
                }
                else
                {
                    m_nudForceProfileIdx2.Enabled = true;
                }
                m_nudChirpStartIdx2.Enabled = true;
                m_nudNumOfChirps2.Enabled = true;
                m_nudNumOfLoops2.Enabled = true;
                m_nudBrustPeriodicity2.Enabled = true;
                m_nudChirpStartIdxOffset2.Enabled = true;
                m_nudNumOfBrust2.Enabled = true;
                m_nudNumOfBrustLoops2.Enabled = true;
                m_nudSubFramePeriod2.Enabled = true;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples2.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples2.Enabled = true;
                }
                m_nudForceProfileIdx3.Enabled = false;
                m_nudChirpStartIdx3.Enabled = false;
                m_nudNumOfChirps3.Enabled = false;
                m_nudNumOfLoops3.Enabled = false;
                m_nudBrustPeriodicity3.Enabled = false;
                m_nudChirpStartIdxOffset3.Enabled = false;
                m_nudNumOfBrust3.Enabled = false;
                m_nudNumOfBrustLoops3.Enabled = false;
                m_nudSubFramePeriod3.Enabled = false;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples3.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples3.Enabled = false;
                }
                m_nudForceProfileIdx4.Enabled = false;
                m_nudChirpStartIdx4.Enabled = false;
                m_nudNumOfChirps4.Enabled = false;
                m_nudNumOfLoops4.Enabled = false;
                m_nudBrustPeriodicity4.Enabled = false;
                m_nudChirpStartIdxOffset4.Enabled = false;
                m_nudNumOfBrust4.Enabled = false;
                m_nudNumOfBrustLoops4.Enabled = false;
                m_nudSubFramePeriod4.Enabled = false;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples4.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples4.Enabled = false;
                }
            }
            if (m_nudNumOfSubFrames.Value == 3m)
            {
                if (!m_ChkBxForceProfile.Checked)
                {
                    m_nudForceProfileIdx.Enabled = false;
                }
                else
                {
                    m_nudForceProfileIdx.Enabled = true;
                }
                m_nudChirpStartIdx.Enabled = true;
                m_nudNumOfChirps.Enabled = true;
                m_nudNumOfLoops.Enabled = true;
                m_nudBrustPeriodicity.Enabled = true;
                m_nudChirpStartIdxOffset.Enabled = true;
                m_nudNumOfBrust.Enabled = true;
                m_nudNumOfBrustLoops.Enabled = true;
                m_nudSubFramePeriod.Enabled = true;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples.Enabled = true;
                }
                if (!m_ChkBxForceProfile.Checked)
                {
                    m_nudForceProfileIdx2.Enabled = false;
                }
                else
                {
                    m_nudForceProfileIdx2.Enabled = true;
                }
                m_nudChirpStartIdx2.Enabled = true;
                m_nudNumOfChirps2.Enabled = true;
                m_nudNumOfLoops2.Enabled = true;
                m_nudBrustPeriodicity2.Enabled = true;
                m_nudChirpStartIdxOffset2.Enabled = true;
                m_nudNumOfBrust2.Enabled = true;
                m_nudNumOfBrustLoops2.Enabled = true;
                m_nudSubFramePeriod2.Enabled = true;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples2.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples2.Enabled = true;
                }
                if (!m_ChkBxForceProfile.Checked)
                {
                    m_nudForceProfileIdx3.Enabled = false;
                }
                else
                {
                    m_nudForceProfileIdx3.Enabled = true;
                }
                m_nudChirpStartIdx3.Enabled = true;
                m_nudNumOfChirps3.Enabled = true;
                m_nudNumOfLoops3.Enabled = true;
                m_nudBrustPeriodicity3.Enabled = true;
                m_nudChirpStartIdxOffset3.Enabled = true;
                m_nudNumOfBrust3.Enabled = true;
                m_nudNumOfBrustLoops3.Enabled = true;
                m_nudSubFramePeriod3.Enabled = true;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples3.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples3.Enabled = true;
                }
                m_nudForceProfileIdx4.Enabled = false;
                m_nudChirpStartIdx4.Enabled = false;
                m_nudNumOfChirps4.Enabled = false;
                m_nudNumOfLoops4.Enabled = false;
                m_nudBrustPeriodicity4.Enabled = false;
                m_nudChirpStartIdxOffset4.Enabled = false;
                m_nudNumOfBrust4.Enabled = false;
                m_nudNumOfBrustLoops4.Enabled = false;
                m_nudSubFramePeriod4.Enabled = false;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples4.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples4.Enabled = false;
                }
            }
            if (m_nudNumOfSubFrames.Value == 4m)
            {
                if (!m_ChkBxForceProfile.Checked)
                {
                    m_nudForceProfileIdx.Enabled = false;
                }
                else
                {
                    m_nudForceProfileIdx.Enabled = true;
                }
                m_nudChirpStartIdx.Enabled = true;
                m_nudNumOfChirps.Enabled = true;
                m_nudNumOfLoops.Enabled = true;
                m_nudBrustPeriodicity.Enabled = true;
                m_nudChirpStartIdxOffset.Enabled = true;
                m_nudNumOfBrust.Enabled = true;
                m_nudNumOfBrustLoops.Enabled = true;
                m_nudSubFramePeriod.Enabled = true;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples.Enabled = true;
                }
                if (!m_ChkBxForceProfile.Checked)
                {
                    m_nudForceProfileIdx2.Enabled = false;
                }
                else
                {
                    m_nudForceProfileIdx2.Enabled = true;
                }
                m_nudChirpStartIdx2.Enabled = true;
                m_nudNumOfChirps2.Enabled = true;
                m_nudNumOfLoops2.Enabled = true;
                m_nudBrustPeriodicity2.Enabled = true;
                m_nudChirpStartIdxOffset2.Enabled = true;
                m_nudNumOfBrust2.Enabled = true;
                m_nudNumOfBrustLoops2.Enabled = true;
                m_nudSubFramePeriod2.Enabled = true;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples2.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples2.Enabled = true;
                }
                if (!m_ChkBxForceProfile.Checked)
                {
                    m_nudForceProfileIdx3.Enabled = false;
                }
                else
                {
                    m_nudForceProfileIdx3.Enabled = true;
                }
                m_nudChirpStartIdx3.Enabled = true;
                m_nudNumOfChirps3.Enabled = true;
                m_nudNumOfLoops3.Enabled = true;
                m_nudBrustPeriodicity3.Enabled = true;
                m_nudChirpStartIdxOffset3.Enabled = true;
                m_nudNumOfBrust3.Enabled = true;
                m_nudNumOfBrustLoops3.Enabled = true;
                m_nudSubFramePeriod3.Enabled = true;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples3.Enabled = false;
                }
                else if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples3.Enabled = true;
                }
                if (!m_ChkBxForceProfile.Checked)
                {
                    m_nudForceProfileIdx4.Enabled = false;
                }
                else
                {
                    m_nudForceProfileIdx4.Enabled = true;
                }
                m_nudChirpStartIdx4.Enabled = true;
                m_nudNumOfChirps4.Enabled = true;
                m_nudNumOfLoops4.Enabled = true;
                m_nudBrustPeriodicity4.Enabled = true;
                m_nudChirpStartIdxOffset4.Enabled = true;
                m_nudNumOfBrust4.Enabled = true;
                m_nudNumOfBrustLoops4.Enabled = true;
                m_nudSubFramePeriod4.Enabled = true;
                if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
                {
                    m_nudNoOfAdcSamples4.Enabled = false;
                    return;
                }
                if (GlobalRef.g_AR16xxDevice)
                {
                    m_nudNoOfAdcSamples4.Enabled = true;
                }
            }
        }

        public void EnabledDefaultSubFrame0()
        {
            m_nudForceProfileIdx.Enabled = true;
            m_nudChirpStartIdx.Enabled = true;
            m_nudNumOfChirps.Enabled = true;
            m_nudNumOfLoops.Enabled = true;
            m_nudBrustPeriodicity.Enabled = true;
            m_nudChirpStartIdxOffset.Enabled = true;
            m_nudNumOfBrust.Enabled = true;
            m_nudNumOfBrustLoops.Enabled = true;
            m_nudSubFramePeriod.Enabled = true;
            if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
            {
                m_nudNoOfAdcSamples.Enabled = false;
            }
            else if (GlobalRef.g_AR16xxDevice)
            {
                m_nudNoOfAdcSamples.Enabled = true;
            }
            m_nudForceProfileIdx2.Enabled = false;
            m_nudChirpStartIdx2.Enabled = false;
            m_nudNumOfChirps2.Enabled = false;
            m_nudNumOfLoops2.Enabled = false;
            m_nudBrustPeriodicity2.Enabled = false;
            m_nudChirpStartIdxOffset2.Enabled = false;
            m_nudNumOfBrust2.Enabled = false;
            m_nudNumOfBrustLoops2.Enabled = false;
            m_nudSubFramePeriod2.Enabled = false;
            if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
            {
                m_nudNoOfAdcSamples2.Enabled = false;
            }
            else if (GlobalRef.g_AR16xxDevice)
            {
                m_nudNoOfAdcSamples2.Enabled = false;
            }
            m_nudForceProfileIdx3.Enabled = false;
            m_nudChirpStartIdx3.Enabled = false;
            m_nudNumOfChirps3.Enabled = false;
            m_nudNumOfLoops3.Enabled = false;
            m_nudBrustPeriodicity3.Enabled = false;
            m_nudChirpStartIdxOffset3.Enabled = false;
            m_nudNumOfBrust3.Enabled = false;
            m_nudNumOfBrustLoops3.Enabled = false;
            m_nudSubFramePeriod3.Enabled = false;
            if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
            {
                m_nudNoOfAdcSamples3.Enabled = false;
            }
            else if (GlobalRef.g_AR16xxDevice)
            {
                m_nudNoOfAdcSamples3.Enabled = false;
            }
            m_nudForceProfileIdx4.Enabled = false;
            m_nudChirpStartIdx4.Enabled = false;
            m_nudNumOfChirps4.Enabled = false;
            m_nudNumOfLoops4.Enabled = false;
            m_nudBrustPeriodicity4.Enabled = false;
            m_nudChirpStartIdxOffset4.Enabled = false;
            m_nudNumOfBrust4.Enabled = false;
            m_nudNumOfBrustLoops4.Enabled = false;
            m_nudSubFramePeriod4.Enabled = false;
            if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
            {
                m_nudNoOfAdcSamples4.Enabled = false;
                return;
            }
            if (GlobalRef.g_AR16xxDevice)
            {
                m_nudNoOfAdcSamples4.Enabled = false;
            }
        }

        public void clrSubFrameConfigurationAfterReset()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(clrSubFrameConfigurationAfterReset);
                base.Invoke(method);
                return;
            }
            m_nudNumOfSubFrames.Value = 1m;
            m_nudNumOfFrames.Value = 0m;
            m_chbSelectSoftwareTrigger.Checked = true;
            m_nudFrameTriggerDelay.Value = 0m;
            m_nudForceProfileIdx.Value = 0m;
            m_nudChirpStartIdx.Value = 0m;
            m_nudNumOfChirps.Value = 1m;
            m_nudNumOfLoops.Value = 1m;
            m_nudBrustPeriodicity.Value = 0m;
            m_nudChirpStartIdxOffset.Value = 0m;
            m_nudNumOfBrust.Value = 1m;
            m_nudNumOfBrustLoops.Value = 1m;
            m_nudSubFramePeriod.Value = 0m;
            m_nudNoOfAdcSamples.Value = 0m;
            m_nudForceProfileIdx2.Value = 0m;
            m_nudChirpStartIdx2.Value = 0m;
            m_nudNumOfChirps2.Value = 1m;
            m_nudNumOfLoops2.Value = 1m;
            m_nudBrustPeriodicity2.Value = 0m;
            m_nudChirpStartIdxOffset2.Value = 0m;
            m_nudNumOfBrust2.Value = 1m;
            m_nudNumOfBrustLoops2.Value = 1m;
            m_nudSubFramePeriod2.Value = 0m;
            m_nudNoOfAdcSamples2.Value = 0m;
            m_nudForceProfileIdx3.Value = 0m;
            m_nudChirpStartIdx3.Value = 0m;
            m_nudNumOfChirps3.Value = 1m;
            m_nudNumOfLoops3.Value = 1m;
            m_nudBrustPeriodicity3.Value = 0m;
            m_nudChirpStartIdxOffset3.Value = 0m;
            m_nudNumOfBrust3.Value = 1m;
            m_nudNumOfBrustLoops3.Value = 1m;
            m_nudSubFramePeriod3.Value = 0m;
            m_nudNoOfAdcSamples3.Value = 0m;
            m_nudForceProfileIdx4.Value = 0m;
            m_nudChirpStartIdx4.Value = 0m;
            m_nudNumOfChirps4.Value = 1m;
            m_nudNumOfLoops4.Value = 1m;
            m_nudBrustPeriodicity4.Value = 0m;
            m_nudChirpStartIdxOffset4.Value = 0m;
            m_nudNumOfBrust4.Value = 1m;
            m_nudNumOfBrustLoops4.Value = 1m;
            m_nudSubFramePeriod4.Value = 0m;
            m_nudNoOfAdcSamples4.Value = 0m;
        }

        private void m_ChkBxForceProfile_StatesChanged(object sender, EventArgs p1)
        {
            SetResetForceProfilStatus();
        }

        public void SetResetForceProfilStatus()
        {
            if (!m_ChkBxForceProfile.Checked)
            {
                if (m_nudNumOfSubFrames.Value == 1m)
                {
                    m_nudForceProfileIdx.Enabled = false;
                }
                if (m_nudNumOfSubFrames.Value == 2m)
                {
                    m_nudForceProfileIdx.Enabled = false;
                    m_nudForceProfileIdx2.Enabled = false;
                }
                if (m_nudNumOfSubFrames.Value == 3m)
                {
                    m_nudForceProfileIdx.Enabled = false;
                    m_nudForceProfileIdx2.Enabled = false;
                    m_nudForceProfileIdx3.Enabled = false;
                }
                if (m_nudNumOfSubFrames.Value == 4m)
                {
                    m_nudForceProfileIdx.Enabled = false;
                    m_nudForceProfileIdx2.Enabled = false;
                    m_nudForceProfileIdx3.Enabled = false;
                    m_nudForceProfileIdx4.Enabled = false;
                    return;
                }
            }
            else
            {
                if (m_nudNumOfSubFrames.Value == 1m)
                {
                    m_nudForceProfileIdx.Enabled = true;
                }
                if (m_nudNumOfSubFrames.Value == 2m)
                {
                    m_nudForceProfileIdx.Enabled = true;
                    m_nudForceProfileIdx2.Enabled = true;
                }
                if (m_nudNumOfSubFrames.Value == 3m)
                {
                    m_nudForceProfileIdx.Enabled = true;
                    m_nudForceProfileIdx2.Enabled = true;
                    m_nudForceProfileIdx3.Enabled = true;
                }
                if (m_nudNumOfSubFrames.Value == 4m)
                {
                    m_nudForceProfileIdx.Enabled = true;
                    m_nudForceProfileIdx2.Enabled = true;
                    m_nudForceProfileIdx3.Enabled = true;
                    m_nudForceProfileIdx4.Enabled = true;
                }
            }
        }

        private void m_nudAdvancedFrameTriggerDelay_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)m_nudFrameTriggerDelay.Value * 200.0) / 200.0;
            m_nudFrameTriggerDelay.Value = (decimal)value;
        }

        private void m_nudSubFrameBurst1Periodicity_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)m_nudBrustPeriodicity.Value * 2.0 * 100000.0) / 200000.0;
            m_nudBrustPeriodicity.Value = (decimal)value;
            UpdateSubFrame1DutyCycle();
        }

        private void m_nudSubFrame1Periodicity_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)m_nudSubFramePeriod.Value * 2.0 * 100000.0) / 200000.0;
            m_nudSubFramePeriod.Value = (decimal)value;
        }

        private void m_nudSubFrameBurst2Periodicity_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)m_nudBrustPeriodicity2.Value * 2.0 * 100000.0) / 200000.0;
            m_nudBrustPeriodicity2.Value = (decimal)value;
            UpdateSubFrame2DutyCycle();
        }

        private void m_nudSubFrame2Periodicity_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)m_nudSubFramePeriod2.Value * 2.0 * 100000.0) / 200000.0;
            m_nudSubFramePeriod2.Value = (decimal)value;
        }

        private void m_nudSubFrameBurst3Periodicity_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)m_nudBrustPeriodicity3.Value * 2.0 * 100000.0) / 200000.0;
            m_nudBrustPeriodicity3.Value = (decimal)value;
            UpdateSubFrame3DutyCycle();
        }

        private void m_nudSubFrame3Periodicity_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)m_nudSubFramePeriod3.Value * 2.0 * 100000.0) / 200000.0;
            m_nudSubFramePeriod3.Value = (decimal)value;
        }

        private void m_nudSubFrameBurst4Periodicity_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)m_nudBrustPeriodicity4.Value * 2.0 * 100000.0) / 200000.0;
            m_nudBrustPeriodicity4.Value = (decimal)value;
            UpdateSubFrame4DutyCycle();
        }

        private void m_nudSubFrame4Periodicity_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)m_nudSubFramePeriod4.Value * 2.0 * 100000.0) / 200000.0;
            m_nudSubFramePeriod4.Value = (decimal)value;
        }

        public void EnableAdvFrameControlProgFiltFor16XXARDevice()
        {
        }

        private int iSetLoopBackBurstConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return m_GuiManager.ScriptOps.iLoopBuckBurstConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetLoopBackBurstConfig()
        {
            iSetLoopBackBurstConfig_internal(true, false);
            m_MainForm.GuiOpEnd(true);
        }

        public void iSetLoopBackBurstConfigAsync()
        {
            new del_v_v(iSetLoopBackBurstConfig).BeginInvoke(null, null);
        }

        private void m_btnLoopBackBurstConfig_Click(object sender, EventArgs p1)
        {
            iSetLoopBackBurstConfigAsync();
        }

        public bool UpdateLoopBackBurstConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(UpdateLoopBackBurstConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                m_LoopBackBurstConfigParams.LoopBackSelect = (byte)m_CbLoopBackSelect.SelectedIndex;
                m_LoopBackBurstConfigParams.BaseProfileIndex = (byte)m_nudLPBBaseProfileIndex.Value;
                m_LoopBackBurstConfigParams.BurstIndex = (byte)m_nudLPBBusrtIndex.Value;
                m_LoopBackBurstConfigParams.FreqConst = (double)m_nudLPBFreqConst.Value;
                m_LoopBackBurstConfigParams.SlopeConst = (float)m_nudLPBSlopeConst.Value;
                m_LoopBackBurstConfigParams.Tx1BackOff = (byte)m_nudLPBTx1BackOff.Value;
                m_LoopBackBurstConfigParams.Tx2BackOff = (byte)m_nudLPBTx2BackOff.Value;
                m_LoopBackBurstConfigParams.Tx3BackOff = (byte)m_nudLPBTx3BackOff.Value;
                m_LoopBackBurstConfigParams.RxGain = (byte)m_nudLPBRxGain.Value;
                if (m_CbRFGainTarget.SelectedIndex == 0)
                {
                    m_LoopBackBurstConfigParams.RFGainTarget = 0;
                }
                else if (m_CbRFGainTarget.SelectedIndex == 1)
                {
                    m_LoopBackBurstConfigParams.RFGainTarget = 1;
                }
                else if (m_CbRFGainTarget.SelectedIndex == 2)
                {
                    m_LoopBackBurstConfigParams.RFGainTarget = 3;
                }
                m_LoopBackBurstConfigParams.Tx1Enable = (byte)(m_chLPBTx1Enable.Checked ? 1 : 0);
                m_LoopBackBurstConfigParams.Tx2Enable = (byte)(m_chLPBTx2Enable.Checked ? 1 : 0);
                m_LoopBackBurstConfigParams.Tx3Enable = (byte)(m_chLPBTx3Enable.Checked ? 1 : 0);
                m_LoopBackBurstConfigParams.BPMTx0Off = (byte)(f0000f9.Checked ? 1 : 0);
                m_LoopBackBurstConfigParams.BPMTx0On = (byte)(f0000f8.Checked ? 1 : 0);
                m_LoopBackBurstConfigParams.BPMTx1Off = (byte)(f0000f7.Checked ? 1 : 0);
                m_LoopBackBurstConfigParams.BPMTx1On = (byte)(f0000f6.Checked ? 1 : 0);
                m_LoopBackBurstConfigParams.BPMTx2Off = (byte)(f0000f5.Checked ? 1 : 0);
                m_LoopBackBurstConfigParams.BPMTx2On = (byte)(f0000f4.Checked ? 1 : 0);
                m_LoopBackBurstConfigParams.IQMM = (byte)(m_chLPBDigitalCorrDisable.Checked ? 1 : 0);
                m_LoopBackBurstConfigParams.RxGainPhase = (byte)(m_chLPBDigCorrRxGainPhase.Checked ? 1 : 0);
                m_LoopBackBurstConfigParams.IFLoopBackFreq = (byte)f0000f3.SelectedIndex;
                m_LoopBackBurstConfigParams.IFLoopBackMagnitude = (byte)f0000fc.Value;
                m_LoopBackBurstConfigParams.f000027 = (byte)f0000f2.SelectedIndex;
                m_LoopBackBurstConfigParams.f000028 = (byte)f0000fd.SelectedIndex;
                m_LoopBackBurstConfigParams.PALoopBackFreq = (ushort)f0000fe.Value;
                m_LoopBackBurstConfigParams.Tx1PSLoopBackFreq = (ushort)f0000fa.Value;
                m_LoopBackBurstConfigParams.Tx2PSLoopBackFreq = (ushort)f0000fb.Value;
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateLoopBackBurstConfigDataFrmCmd()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(UpdateLoopBackBurstConfigDataFrmCmd);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                m_CbLoopBackSelect.SelectedIndex = (int)m_LoopBackBurstConfigParams.LoopBackSelect;
                m_nudLPBBaseProfileIndex.Value = m_LoopBackBurstConfigParams.BaseProfileIndex;
                m_nudLPBBusrtIndex.Value = m_LoopBackBurstConfigParams.BurstIndex;
                m_nudLPBFreqConst.Value = (decimal)m_LoopBackBurstConfigParams.FreqConst;
                m_nudLPBSlopeConst.Value = (decimal)m_LoopBackBurstConfigParams.SlopeConst;
                m_nudLPBTx1BackOff.Value = m_LoopBackBurstConfigParams.Tx1BackOff;
                m_nudLPBTx2BackOff.Value = m_LoopBackBurstConfigParams.Tx2BackOff;
                m_nudLPBTx3BackOff.Value = m_LoopBackBurstConfigParams.Tx3BackOff;
                m_nudLPBRxGain.Value = m_LoopBackBurstConfigParams.RxGain;
                if (m_LoopBackBurstConfigParams.RFGainTarget == 0)
                {
                    m_CbRFGainTarget.SelectedIndex = 0;
                }
                else if (m_LoopBackBurstConfigParams.RFGainTarget == 1)
                {
                    m_CbRFGainTarget.SelectedIndex = 1;
                }
                else if (m_LoopBackBurstConfigParams.RFGainTarget == 3)
                {
                    m_CbRFGainTarget.SelectedIndex = 2;
                }
                m_chLPBTx1Enable.Checked = (m_LoopBackBurstConfigParams.Tx1Enable == 1);
                m_chLPBTx2Enable.Checked = (m_LoopBackBurstConfigParams.Tx2Enable == 1);
                m_chLPBTx3Enable.Checked = (m_LoopBackBurstConfigParams.Tx3Enable == 1);
                f0000f9.Checked = (m_LoopBackBurstConfigParams.BPMTx0Off == 1);
                f0000f8.Checked = (m_LoopBackBurstConfigParams.BPMTx0On == 1);
                f0000f7.Checked = (m_LoopBackBurstConfigParams.BPMTx1Off == 1);
                f0000f6.Checked = (m_LoopBackBurstConfigParams.BPMTx1On == 1);
                f0000f5.Checked = (m_LoopBackBurstConfigParams.BPMTx2Off == 1);
                f0000f4.Checked = (m_LoopBackBurstConfigParams.BPMTx2On == 1);
                m_chLPBDigitalCorrDisable.Checked = (m_LoopBackBurstConfigParams.IQMM == 1);
                m_chLPBDigCorrRxGainPhase.Checked = (m_LoopBackBurstConfigParams.RxGainPhase == 1);
                f0000f3.SelectedIndex = (int)m_LoopBackBurstConfigParams.IFLoopBackFreq;
                f0000fc.Value = m_LoopBackBurstConfigParams.IFLoopBackMagnitude;
                f0000f2.SelectedIndex = (int)m_LoopBackBurstConfigParams.f000027;
                f0000fd.SelectedIndex = (int)m_LoopBackBurstConfigParams.f000028;
                f0000fe.Value = m_LoopBackBurstConfigParams.PALoopBackFreq;
                f0000fa.Value = m_LoopBackBurstConfigParams.Tx1PSLoopBackFreq;
                f0000fb.Value = m_LoopBackBurstConfigParams.Tx2PSLoopBackFreq;
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private void m_nudLoopBackBurstSlope_ValueChanged(object sender, EventArgs p1)
        {
            if (GlobalRef.g_ARDeviceOperateFreq60GHz)
            {
                double value = (double)((short)Math.Round((double)m_nudLPBSlopeConst.Value * 27.61681646090535)) * 2430000.0 / 67108864.0;
                m_nudLPBSlopeConst.Value = (decimal)Math.Round(value, 3);
                return;
            }
            double value2 = (double)((ushort)Math.Round((double)m_nudLPBSlopeConst.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
            m_nudLPBSlopeConst.Value = (decimal)Math.Round(value2, 3);
        }

        private void m_nudLoopBackBurstStartFreqConst_ValueChanged(object sender, EventArgs p1)
        {
            if (GlobalRef.g_ARDeviceOperateFreq60GHz)
            {
                double value = (uint)Math.Round((double)m_nudLPBFreqConst.Value * 67108864.0 / 2.7) * 2.7 / 67108864.0;
                m_nudLPBFreqConst.Value = (decimal)value;
                return;
            }
            double value2 = (uint)Math.Round((double)m_nudLPBFreqConst.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
            m_nudLPBFreqConst.Value = (decimal)value2;
        }

        public int StartFreqMinAndMaxSetInLoopBackBurst_Gui()
        {
            if (GlobalRef.g_ARDeviceOperateFreq60GHz)
            {
                m_nudLPBFreqConst.Minimum = 45m;
                m_nudLPBFreqConst.Maximum = 100m;
                m_nudLPBFreqConst.Value = 60m;
            }
            else
            {
                m_nudLPBFreqConst.Minimum = 0m;
                m_nudLPBFreqConst.Maximum = 81m;
                m_nudLPBFreqConst.Value = 77m;
            }
            return 0;
        }

        public void UpdateSubFrame1DutyCycle(string FrameDutyCycle)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(UpdateSubFrame1DutyCycle);
                base.Invoke(method, new object[]
                {
                    FrameDutyCycle
                });
                return;
            }
            m_lblSubFrame1DutyCycle.Text = FrameDutyCycle + " %";
        }

        public void UpdateSubFrame1ActiveRampDutyCycle(string FrameDutyCycle)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(UpdateSubFrame1ActiveRampDutyCycle);
                base.Invoke(method, new object[]
                {
                    FrameDutyCycle
                });
                return;
            }
            m_lblSubFrame1ActiveRampDutyCycle.Text = FrameDutyCycle + " %";
        }

        public void UpdateSubFrame2DutyCycle(string FrameDutyCycle)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(UpdateSubFrame2DutyCycle);
                base.Invoke(method, new object[]
                {
                    FrameDutyCycle
                });
                return;
            }
            m_lblSubFrame2DutyCycle.Text = FrameDutyCycle + " %";
        }

        public void UpdateSubFrame2ActiveRampDutyCycle(string FrameDutyCycle)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(UpdateSubFrame2ActiveRampDutyCycle);
                base.Invoke(method, new object[]
                {
                    FrameDutyCycle
                });
                return;
            }
            m_lblSubFrame2ActiveRampDutyCycle.Text = FrameDutyCycle + " %";
        }

        public void UpdateSubFrame3DutyCycle(string FrameDutyCycle)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(UpdateSubFrame3DutyCycle);
                base.Invoke(method, new object[]
                {
                    FrameDutyCycle
                });
                return;
            }
            m_lblSubFrame3DutyCycle.Text = FrameDutyCycle + " %";
        }

        public void UpdateSubFrame3ActiveRampDutyCycle(string FrameDutyCycle)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(UpdateSubFrame3ActiveRampDutyCycle);
                base.Invoke(method, new object[]
                {
                    FrameDutyCycle
                });
                return;
            }
            m_lblSubFrame3ActiveRampDutyCycle.Text = FrameDutyCycle + " %";
        }

        public void UpdateSubFrame4DutyCycle(string FrameDutyCycle)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(UpdateSubFrame4DutyCycle);
                base.Invoke(method, new object[]
                {
                    FrameDutyCycle
                });
                return;
            }
            m_lblSubFrame4DutyCycle.Text = FrameDutyCycle + " %";
        }

        public void UpdateSubFrame4ActiveRampDutyCycle(string FrameDutyCycle)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(UpdateSubFrame4ActiveRampDutyCycle);
                base.Invoke(method, new object[]
                {
                    FrameDutyCycle
                });
                return;
            }
            m_lblSubFrame4ActiveRampDutyCycle.Text = FrameDutyCycle + " %";
        }

        public bool SaveAdvanceFrameConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(SaveAdvanceFrameConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetAdvanceConfigKeyVal("numOfSubFrames", m_nudNumOfSubFrames.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("forceProfileEna", (m_ChkBxForceProfile.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("numOfFrames", m_nudNumOfFrames.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("softwareTrigger", (m_chbSelectSoftwareTrigger.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("hardwareTrigger", (m_chbSelectHardwareTrigger.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("frameTriggerDelay", m_nudFrameTriggerDelay.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("loopBackCfg", (m_ChkBxLoopBackCfg.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("loopBackCfgSubFrameID", m_nudLoopBackCfgSubFrameID.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("testSourceEn", (m_chbAdvancedFrameTestSourceEnable.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb1forceProfileIdx", m_nudForceProfileIdx.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb1chirpStartIdx", m_nudChirpStartIdx.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb1numOfChirps", m_nudNumOfChirps.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb1numOfLoops", m_nudNumOfLoops.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb1brustPeriodicity", m_nudBrustPeriodicity.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb1chirpStartIdxOffset", m_nudChirpStartIdxOffset.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb1numOfBrust", m_nudNumOfBrust.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb1numOfBrustLoops", m_nudNumOfBrustLoops.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb1subFramePeriod", m_nudSubFramePeriod.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb1noOfAdcSamples", m_nudNoOfAdcSamples.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb2forceProfileIdx", m_nudForceProfileIdx2.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb2chirpStartIdx", m_nudChirpStartIdx2.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb2numOfChirps", m_nudNumOfChirps2.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb2numOfLoops", m_nudNumOfLoops2.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb2brustPeriodicity", m_nudBrustPeriodicity2.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb2chirpStartIdxOffset", m_nudChirpStartIdxOffset2.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb2numOfBrust", m_nudNumOfBrust2.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb2numOfBrustLoops", m_nudNumOfBrustLoops2.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb2subFramePeriod", m_nudSubFramePeriod2.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb2noOfAdcSamples", m_nudNoOfAdcSamples2.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb3forceProfileIdx", m_nudForceProfileIdx3.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb3chirpStartIdx", m_nudChirpStartIdx3.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb3numOfChirps", m_nudNumOfChirps3.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb3numOfLoops", m_nudNumOfLoops3.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb3brustPeriodicity", m_nudBrustPeriodicity3.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb3chirpStartIdxOffset", m_nudChirpStartIdxOffset3.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb3numOfBrust", m_nudNumOfBrust3.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb3numOfBrustLoops", m_nudNumOfBrustLoops3.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb3subFramePeriod", m_nudSubFramePeriod3.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb3noOfAdcSamples", m_nudNoOfAdcSamples3.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb4forceProfileIdx", m_nudForceProfileIdx4.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb4chirpStartIdx", m_nudChirpStartIdx4.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb4numOfChirps", m_nudNumOfChirps4.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb4numOfLoops", m_nudNumOfLoops4.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb4brustPeriodicity", m_nudBrustPeriodicity4.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb4chirpStartIdxOffset", m_nudChirpStartIdxOffset4.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb4numOfBrust", m_nudNumOfBrust4.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb4numOfBrustLoops", m_nudNumOfBrustLoops4.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb4subFramePeriod", m_nudSubFramePeriod4.Value.ToString());
                ConfigurationManager.SetAdvanceConfigKeyVal("sb4noOfAdcSamples", m_nudNoOfAdcSamples4.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadAdvanceFrameConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(LoadAdvanceFrameConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte numOfSubFrames = Convert.ToByte(ConfigurationManager.GetAdvanceFrameConfigKeyVal("numOfSubFrames"));
                byte forceProfileEna = Convert.ToByte(ConfigurationManager.GetAdvanceFrameConfigKeyVal("forceProfileEna"));
                ushort numOfFrames = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("numOfFrames"));
                ushort softwareTrigger = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("softwareTrigger"));
                ushort hardwareTrigger = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("hardwareTrigger"));
                float frameTriggerDelay = Convert.ToSingle(ConfigurationManager.GetAdvanceFrameConfigKeyVal("frameTriggerDelay"));
                byte loopBackCfgSubFrameID = Convert.ToByte(ConfigurationManager.GetAdvanceFrameConfigKeyVal("loopBackCfgSubFrameID"));
                byte loopBackCfg = Convert.ToByte(ConfigurationManager.GetAdvanceFrameConfigKeyVal("loopBackCfg"));
                ushort testSourceEn = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("testSourceEn"));
                ushort p = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb1forceProfileIdx"));
                ushort p2 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb1chirpStartIdx"));
                ushort sb1numOfChirps = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb1numOfChirps"));
                ushort sb1numOfLoops = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb1numOfLoops"));
                float p3 = Convert.ToSingle(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb1brustPeriodicity"));
                ushort p4 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb1chirpStartIdxOffset"));
                ushort sb1numOfBrust = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb1numOfBrust"));
                ushort p5 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb1numOfBrustLoops"));
                float p6 = Convert.ToSingle(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb1subFramePeriod"));
                ushort p7 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb1noOfAdcSamples"));
                ushort p8 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3forceProfileIdx"));
                ushort p9 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3chirpStartIdx"));
                ushort sb2numOfChirps = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3numOfChirps"));
                ushort sb2numOfLoops = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3numOfLoops"));
                float p10 = Convert.ToSingle(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb2brustPeriodicity"));
                ushort p11 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb2chirpStartIdxOffset"));
                ushort sb2numOfBrust = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb2numOfBrust"));
                ushort p12 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb2numOfBrustLoops"));
                float p13 = Convert.ToSingle(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb2subFramePeriod"));
                ushort p14 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb2noOfAdcSamples"));
                ushort p15 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3forceProfileIdx"));
                ushort p16 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3chirpStartIdx"));
                ushort sb3numOfChirps = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3numOfChirps"));
                ushort sb3numOfLoops = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3numOfLoops"));
                float p17 = Convert.ToSingle(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3brustPeriodicity"));
                ushort p18 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3chirpStartIdxOffset"));
                ushort sb3numOfBrust = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3numOfBrust"));
                ushort p19 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3numOfBrustLoops"));
                float p20 = Convert.ToSingle(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3subFramePeriod"));
                ushort p21 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb3noOfAdcSamples"));
                ushort p22 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb4forceProfileIdx"));
                ushort p23 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb4chirpStartIdx"));
                ushort sb4numOfChirps = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb4numOfChirps"));
                ushort sb4numOfLoops = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb4numOfLoops"));
                float p24 = Convert.ToSingle(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb4brustPeriodicity"));
                ushort p25 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb4chirpStartIdxOffset"));
                ushort sb4numOfBrust = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb4numOfBrust"));
                ushort p26 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb4numOfBrustLoops"));
                float p27 = Convert.ToSingle(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb4subFramePeriod"));
                ushort p28 = Convert.ToUInt16(ConfigurationManager.GetAdvanceFrameConfigKeyVal("sb4noOfAdcSamples"));
                m_GuiManager.ScriptOps.UpdateAdvanceFrameConfigData(numOfSubFrames, forceProfileEna, numOfFrames, softwareTrigger, hardwareTrigger, frameTriggerDelay, loopBackCfgSubFrameID, loopBackCfg, testSourceEn, p, p2, sb1numOfChirps, sb1numOfLoops, p3, p4, sb1numOfBrust, p5, p6, p7, p8, p9, sb2numOfChirps, sb2numOfLoops, p10, p11, sb2numOfBrust, p12, p13, p14, p15, p16, sb3numOfChirps, sb3numOfLoops, p17, p18, sb3numOfBrust, p19, p20, p21, p22, p23, sb4numOfChirps, sb4numOfLoops, p24, p25, sb4numOfBrust, p26, p27, p28);
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveLoopBackBurstConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(SaveLoopBackBurstConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("loopBackSelect", m_CbLoopBackSelect.SelectedIndex.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("baseProfileIndex", m_nudLPBBaseProfileIndex.Value.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("busrtIndex", m_nudLPBBusrtIndex.Value.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("freqConst", m_nudLPBFreqConst.Value.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("slopeConst", m_nudLPBSlopeConst.Value.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("tx0BackOff", m_nudLPBTx1BackOff.Value.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("tx1BackOff", m_nudLPBTx2BackOff.Value.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("tx2BackOff", m_nudLPBTx3BackOff.Value.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("tx0En", (m_chLPBTx1Enable.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("tx1En", (m_chLPBTx2Enable.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("tx2En", (m_chLPBTx3Enable.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("rfGainTarget", m_CbRFGainTarget.SelectedIndex.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("rxGain", m_nudLPBRxGain.Value.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("bpmTx0Off", (f0000f9.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("bpmTx0On", (f0000f8.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("bpmTx1Off", (f0000f7.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("bpmTx1On", (f0000f6.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("bpmTx2Off", (f0000f5.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("bpmTx2On", (f0000f4.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("digitalCorrDisable", (m_chLPBDigitalCorrDisable.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("digCorrRxGainPhase", (m_chLPBDigCorrRxGainPhase.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("ifLoopBackFreq", f0000f3.SelectedIndex.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("iflLoopBackMag", f0000fc.Value.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("ps1PGAGainIndex", f0000f2.SelectedIndex.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("ps2PGAGainIndex", f0000fd.SelectedIndex.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("paLoopBackFreq", f0000fe.Value.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("psTx0LoopBackFreq", f0000fa.Value.ToString());
                ConfigurationManager.SetLoopBackBurstConfigKeyVal("psTx1LoopBackFreq", f0000fb.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadLoopBackBurstConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(LoadLoopBackBurstConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                byte loopBackSelect = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("loopBackSelect"));
                byte baseProfileIndex = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("baseProfileIndex"));
                byte busrtIndex = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("busrtIndex"));
                double freqConst = (double)Convert.ToSingle(ConfigurationManager.GetLoopBackBurstConfigKeyVal("freqConst"));
                float slopeConst = Convert.ToSingle(ConfigurationManager.GetLoopBackBurstConfigKeyVal("slopeConst"));
                byte tx0BackOff = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("tx0BackOff"));
                byte tx1BackOff = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("tx1BackOff"));
                byte tx2BackOff = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("tx2BackOff"));
                byte p = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("tx0En"));
                byte p2 = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("tx1En"));
                byte p3 = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("tx2En"));
                byte rfGainTarget = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("rfGainTarget"));
                byte rxGain = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("rxGain"));
                byte p4 = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("bpmTx0Off"));
                byte p5 = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("bpmTx0On"));
                byte p6 = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("bpmTx1Off"));
                byte p7 = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("bpmTx1On"));
                byte p8 = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("bpmTx2Off"));
                byte p9 = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("bpmTx2On"));
                byte digitalCorrDisable = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("digitalCorrDisable"));
                byte digCorrRxGainPhase = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("digCorrRxGainPhase"));
                byte ifLoopBackFreq = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("ifLoopBackFreq"));
                byte iflLoopBackMag = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("iflLoopBackMag"));
                byte ps1PGAGainIndex = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("ps1PGAGainIndex"));
                byte ps2PGAGainIndex = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("ps2PGAGainIndex"));
                byte paLoopBackFreq = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("paLoopBackFreq"));
                byte psTx0LoopBackFreq = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("psTx0LoopBackFreq"));
                byte psTx1LoopBackFreq = Convert.ToByte(ConfigurationManager.GetLoopBackBurstConfigKeyVal("psTx1LoopBackFreq"));
                m_GuiManager.ScriptOps.UpdateLoopBackBurstConfigData(loopBackSelect, baseProfileIndex, busrtIndex, freqConst, slopeConst, tx0BackOff, tx1BackOff, tx2BackOff, p, p2, p3, rfGainTarget, rxGain, p4, p5, p6, p7, p8, p9, digitalCorrDisable, digCorrRxGainPhase, ifLoopBackFreq, iflLoopBackMag, ps1PGAGainIndex, ps2PGAGainIndex, paLoopBackFreq, psTx0LoopBackFreq, psTx1LoopBackFreq);
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private int iSetSoftwareSubFrameStartConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return m_GuiManager.ScriptOps.iSoftwareSubFrameStartConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetSoftwareSubFrameStartConfig()
        {
            iSetSoftwareSubFrameStartConfig_internal(true, false);
            m_MainForm.GuiOpEnd(true);
        }

        public void iSetSoftwareSubFrameStartConfigAsync()
        {
            new del_v_v(iSetSoftwareSubFrameStartConfig).BeginInvoke(null, null);
        }

        private void m_btnSoftwareSubFrameStartConfig_Click(object sender, EventArgs p1)
        {
            iSetSoftwareSubFrameStartConfigAsync();
        }

        public bool UpdateSWSubFrameStartConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(UpdateSWSubFrameStartConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                m_SWSubFrameStartStopConfigParams.StartCommand = (ushort)(m_ChSubFrameStartConfig.Checked ? 1 : 0);
                m_SWSubFrameStartStopConfigParams.Reserved = 0;
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateSWSubFrameStartConfigDataFrmCmd()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(UpdateSWSubFrameStartConfigDataFrmCmd);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                m_ChSubFrameStartConfig.Checked = (m_SWSubFrameStartStopConfigParams.StartCommand == 1);
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public void SetRFGainTarget()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(SetRFGainTarget);
                base.Invoke(method);
                return;
            }
            if (GlobalRef.g_AR2243Device)
            {
                m_CbRFGainTarget.SelectedIndex = 1;
                return;
            }
            m_CbRFGainTarget.SelectedIndex = 0;
        }

        public int getNumChirps()
        {
            if (base.InvokeRequired)
            {
                del_i_v method = new del_i_v(getNumChirps);
                return (int)base.Invoke(method);
            }
            int numSubFrames = getNumSubFrames();
            int result = 0;
            if (numSubFrames == 1)
            {
                int num = (int)m_nudNumOfChirps.Value;
                int num2 = (int)m_nudNumOfLoops.Value;
                int num3 = (int)m_nudNumOfBrust.Value;
                int num4 = (int)m_nudNumOfBrustLoops.Value;
                result = num * num2 * num3 * num4;
            }
            else if (numSubFrames == 2)
            {
                int num5 = (int)m_nudNumOfChirps.Value;
                int num6 = (int)m_nudNumOfLoops.Value;
                int num7 = (int)m_nudNumOfBrust.Value;
                int num8 = (int)m_nudNumOfBrustLoops.Value;
                int num9 = (int)m_nudNumOfChirps2.Value;
                int num10 = (int)m_nudNumOfLoops2.Value;
                int num11 = (int)m_nudNumOfBrust2.Value;
                int num12 = (int)m_nudNumOfBrustLoops2.Value;
                result = num5 * num6 * num7 * num8 + num9 * num10 * num11 * num12;
            }
            else if (numSubFrames == 3)
            {
                int num13 = (int)m_nudNumOfChirps.Value;
                int num14 = (int)m_nudNumOfLoops.Value;
                int num15 = (int)m_nudNumOfBrust.Value;
                int num16 = (int)m_nudNumOfBrustLoops.Value;
                int num17 = (int)m_nudNumOfChirps2.Value;
                int num18 = (int)m_nudNumOfLoops2.Value;
                int num19 = (int)m_nudNumOfBrust2.Value;
                int num20 = (int)m_nudNumOfBrustLoops2.Value;
                int num21 = (int)m_nudNumOfChirps3.Value;
                int num22 = (int)m_nudNumOfLoops3.Value;
                int num23 = (int)m_nudNumOfBrust3.Value;
                int num24 = (int)m_nudNumOfBrustLoops3.Value;
                result = num13 * num14 * num15 * num16 + num17 * num18 * num19 * num20 + num21 * num22 * num23 * num24;
            }
            else if (numSubFrames == 4)
            {
                int num25 = (int)m_nudNumOfChirps.Value;
                int num26 = (int)m_nudNumOfLoops.Value;
                int num27 = (int)m_nudNumOfBrust.Value;
                int num28 = (int)m_nudNumOfBrustLoops.Value;
                int num29 = (int)m_nudNumOfChirps2.Value;
                int num30 = (int)m_nudNumOfLoops2.Value;
                int num31 = (int)m_nudNumOfBrust2.Value;
                int num32 = (int)m_nudNumOfBrustLoops2.Value;
                int num33 = (int)m_nudNumOfChirps3.Value;
                int num34 = (int)m_nudNumOfLoops3.Value;
                int num35 = (int)m_nudNumOfBrust3.Value;
                int num36 = (int)m_nudNumOfBrustLoops3.Value;
                int num37 = (int)m_nudNumOfChirps4.Value;
                int num38 = (int)m_nudNumOfLoops4.Value;
                int num39 = (int)m_nudNumOfBrust4.Value;
                int num40 = (int)m_nudNumOfBrustLoops4.Value;
                result = num25 * num26 * num27 * num28 + num29 * num30 * num31 * num32 + num33 * num34 * num35 * num36 + num37 * num38 * num39 * num40;
            }
            return result;
        }

        public int getNumSubFrames()
        {
            if (base.InvokeRequired)
            {
                del_i_v method = new del_i_v(getNumSubFrames);
                return (int)base.Invoke(method);
            }
            return (int)m_nudNumOfSubFrames.Value;
        }

        public void UpdateSubFrame1DutyCycle()
        {
            ushort chirpStartIdx = (ushort)m_nudChirpStartIdx.Value;
            ushort chirpEndIdx = (ushort)((ushort)m_nudChirpStartIdx.Value + (ushort)m_nudNumOfChirps.Value - 1);
            uint noOfLoops = (uint)m_nudNumOfLoops.Value;
            float num = m_GuiManager.ScriptOps.CalculateFrameOnTimeForFrame(chirpStartIdx, chirpEndIdx, noOfLoops);
            float num2 = m_GuiManager.ScriptOps.CalculateRampOnTimeForFrame(chirpStartIdx, chirpEndIdx, noOfLoops);
            m_MainForm.AdvanceFrameConfigTab.UpdateSubFrame1DutyCycle(Convert.ToString(Math.Round((double)(num / (float)m_nudBrustPeriodicity.Value * 100f), 1)));
            m_MainForm.AdvanceFrameConfigTab.UpdateSubFrame1ActiveRampDutyCycle(Convert.ToString(Math.Round((double)(num2 / (float)m_nudBrustPeriodicity.Value * 100f), 1)));
        }

        private void m_nudChirpStartIdx_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame1DutyCycle();
        }

        private void m_nudNumOfChirps_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame1DutyCycle();
        }

        private void m_nudNumOfLoops_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame1DutyCycle();
        }

        public void UpdateSubFrame2DutyCycle()
        {
            ushort chirpStartIdx = (ushort)m_nudChirpStartIdx2.Value;
            ushort chirpEndIdx = (ushort)((ushort)m_nudChirpStartIdx2.Value + (ushort)m_nudNumOfChirps2.Value - 1);
            uint noOfLoops = (uint)m_nudNumOfLoops2.Value;
            float num = m_GuiManager.ScriptOps.CalculateFrameOnTimeForFrame(chirpStartIdx, chirpEndIdx, noOfLoops);
            float num2 = m_GuiManager.ScriptOps.CalculateRampOnTimeForFrame(chirpStartIdx, chirpEndIdx, noOfLoops);
            m_MainForm.AdvanceFrameConfigTab.UpdateSubFrame2DutyCycle(Convert.ToString(Math.Round((double)(num / (float)m_nudBrustPeriodicity2.Value * 100f), 1)));
            m_MainForm.AdvanceFrameConfigTab.UpdateSubFrame2ActiveRampDutyCycle(Convert.ToString(Math.Round((double)(num2 / (float)m_nudBrustPeriodicity2.Value * 100f), 1)));
        }

        private void m_nudChirpStartIdx2_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame2DutyCycle();
        }

        private void m_nudNumOfChirps2_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame2DutyCycle();
        }

        private void m_nudNumOfLoops2_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame2DutyCycle();
        }

        public void UpdateSubFrame3DutyCycle()
        {
            ushort chirpStartIdx = (ushort)m_nudChirpStartIdx3.Value;
            ushort chirpEndIdx = (ushort)(m_nudChirpStartIdx3.Value + m_nudNumOfChirps3.Value - 1);
            uint noOfLoops = (uint)m_nudNumOfLoops3.Value;
            float num = m_GuiManager.ScriptOps.CalculateFrameOnTimeForFrame(chirpStartIdx, chirpEndIdx, noOfLoops);
            float num2 = m_GuiManager.ScriptOps.CalculateRampOnTimeForFrame(chirpStartIdx, chirpEndIdx, noOfLoops);
            m_MainForm.AdvanceFrameConfigTab.UpdateSubFrame3DutyCycle(Convert.ToString(Math.Round((double)(num / (float)m_nudBrustPeriodicity3.Value * 100f), 1)));
            m_MainForm.AdvanceFrameConfigTab.UpdateSubFrame3ActiveRampDutyCycle(Convert.ToString(Math.Round((double)(num2 / (float)m_nudBrustPeriodicity3.Value * 100f), 1)));
        }

        private void m_nudChirpStartIdx3_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame3DutyCycle();
        }

        private void m_nudNumOfChirps3_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame3DutyCycle();
        }

        private void m_nudNumOfLoops3_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame3DutyCycle();
        }

        public void UpdateSubFrame4DutyCycle()
        {
            ushort chirpStartIdx = (ushort)m_nudChirpStartIdx4.Value;
            ushort chirpEndIdx = (ushort)(m_nudChirpStartIdx4.Value + m_nudNumOfChirps4.Value - 1);
            uint noOfLoops = (uint)m_nudNumOfLoops4.Value;
            float num = m_GuiManager.ScriptOps.CalculateFrameOnTimeForFrame(chirpStartIdx, chirpEndIdx, noOfLoops);
            float num2 = m_GuiManager.ScriptOps.CalculateRampOnTimeForFrame(chirpStartIdx, chirpEndIdx, noOfLoops);
            m_MainForm.AdvanceFrameConfigTab.UpdateSubFrame4DutyCycle(Convert.ToString(Math.Round((double)(num / (float)m_nudBrustPeriodicity4.Value * 100f), 1)));
            m_MainForm.AdvanceFrameConfigTab.UpdateSubFrame4ActiveRampDutyCycle(Convert.ToString(Math.Round((double)(num2 / (float)m_nudBrustPeriodicity4.Value * 100f), 1)));
        }

        private void m_nudChirpStartIdx4_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame4DutyCycle();
        }

        private void m_nudNumOfChirps4_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame4DutyCycle();
        }

        private void m_nudNumOfLoops4_ValueChanged(object sender, EventArgs p1)
        {
            UpdateSubFrame4DutyCycle();
        }

        private void m_btnAdvChirpConfig_Click(object sender, EventArgs p1)
        {
            iSetAdvChirpConfigAsync();
        }

        public void iSetAdvChirpConfigAsync()
        {
            new del_v_v(iSetAdvChirpConfig).BeginInvoke(null, null);
        }

        private void iSetAdvChirpConfig()
        {
            iSetAdvChirpConfig_internal(true, false);
            m_MainForm.GuiOpEnd(true);
        }

        private int iSetAdvChirpConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return m_GuiManager.ScriptOps.iSetAdvChirpConfig_Gui(is_starting_op, is_ending_op);
        }

        public bool UpdateAdvChirpConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(UpdateAdvChirpConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                m_AdvChirpConfigParams.chirpParamIdx = (ushort)m_nudChirpParamIdx.Value;
                m_AdvChirpConfigParams.resetMode = (byte)m_nudResetMode.Value;
                m_AdvChirpConfigParams.patternMode = (byte)m_nudPatternMode.Value;
                m_AdvChirpConfigParams.resetPeriod = (ushort)m_nudResetPeriod.Value;
                m_AdvChirpConfigParams.paramUpdatePeriod = (ushort)m_nudParamPeriod.Value;
                m_AdvChirpConfigParams.fixedDeltaInc = (double)m_nudFixedDeltaInc.Value;
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateAdvChirpConfigDataFrmCmd()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(UpdateAdvChirpConfigDataFrmCmd);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                m_nudChirpParamIdx.Value = m_AdvChirpConfigParams.chirpParamIdx;
                m_nudResetMode.Value = m_AdvChirpConfigParams.resetMode;
                m_nudPatternMode.Value = m_AdvChirpConfigParams.patternMode;
                m_nudResetPeriod.Value = m_AdvChirpConfigParams.resetPeriod;
                m_nudParamPeriod.Value = m_AdvChirpConfigParams.paramUpdatePeriod;
                m_nudFixedDeltaInc.Value = (decimal)m_AdvChirpConfigParams.fixedDeltaInc;
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupBox2 = new GroupBox();
            m_lblSubFrame4ActiveRampDutyCycle = new Label();
            m_lblSubFrame3ActiveRampDutyCycle = new Label();
            m_lblSubFrame2ActiveRampDutyCycle = new Label();
            m_lblSubFrame1ActiveRampDutyCycle = new Label();
            label45 = new Label();
            m_lblSubFrame4DutyCycle = new Label();
            m_lblSubFrame3DutyCycle = new Label();
            m_lblSubFrame2DutyCycle = new Label();
            m_lblSubFrame1DutyCycle = new Label();
            label44 = new Label();
            m_ChkSWSubFrameTriggerCfg = new CheckBox();
            label43 = new Label();
            m_nudLoopBackCfgSubFrameID = new NumericUpDown();
            label41 = new Label();
            m_ChkBxLoopBackCfg = new CheckBox();
            m_chbSelectHardwareTrigger = new RadioButton();
            m_chbSelectSoftwareTrigger = new RadioButton();
            m_chbAdvancedFrameTestSourceEnable = new CheckBox();
            m_ChkBxForceProfile = new CheckBox();
            groupBox3 = new GroupBox();
            m_nudNoOfAdcSamples4 = new NumericUpDown();
            m_nudNoOfAdcSamples3 = new NumericUpDown();
            m_nudNoOfAdcSamples2 = new NumericUpDown();
            m_nudNoOfAdcSamples = new NumericUpDown();
            label5 = new Label();
            m_nudSubFramePeriod4 = new NumericUpDown();
            m_nudNumOfBrustLoops4 = new NumericUpDown();
            m_nudNumOfBrust4 = new NumericUpDown();
            m_nudChirpStartIdxOffset4 = new NumericUpDown();
            m_nudBrustPeriodicity4 = new NumericUpDown();
            m_nudNumOfLoops4 = new NumericUpDown();
            m_nudNumOfChirps4 = new NumericUpDown();
            m_nudChirpStartIdx4 = new NumericUpDown();
            m_nudForceProfileIdx4 = new NumericUpDown();
            m_nudSubFramePeriod3 = new NumericUpDown();
            m_nudNumOfBrustLoops3 = new NumericUpDown();
            m_nudNumOfBrust3 = new NumericUpDown();
            m_nudChirpStartIdxOffset3 = new NumericUpDown();
            m_nudBrustPeriodicity3 = new NumericUpDown();
            m_nudNumOfLoops3 = new NumericUpDown();
            m_nudNumOfChirps3 = new NumericUpDown();
            m_nudChirpStartIdx3 = new NumericUpDown();
            m_nudForceProfileIdx3 = new NumericUpDown();
            m_nudSubFramePeriod2 = new NumericUpDown();
            m_nudNumOfBrustLoops2 = new NumericUpDown();
            m_nudNumOfBrust2 = new NumericUpDown();
            m_nudChirpStartIdxOffset2 = new NumericUpDown();
            m_nudBrustPeriodicity2 = new NumericUpDown();
            m_nudNumOfLoops2 = new NumericUpDown();
            m_nudNumOfChirps2 = new NumericUpDown();
            m_nudChirpStartIdx2 = new NumericUpDown();
            m_nudForceProfileIdx2 = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            m_nudSubFramePeriod = new NumericUpDown();
            m_nudSubFramePeriodicity = new Label();
            m_nudNumOfBrustLoops = new NumericUpDown();
            m_nudNumOfBrust = new NumericUpDown();
            m_nudChirpStartIdxOffset = new NumericUpDown();
            m_nudBrustPeriodicity = new NumericUpDown();
            m_nudNumOfLoops = new NumericUpDown();
            m_nudNumOfChirps = new NumericUpDown();
            m_nudChirpStartIdx = new NumericUpDown();
            m_nudForceProfileIdx = new NumericUpDown();
            label9 = new Label();
            label10 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            m_nudFrameTriggerDelay = new NumericUpDown();
            m_nudNumOfFrames = new NumericUpDown();
            m_nudNumOfSubFrames = new NumericUpDown();
            m_btnAdvFrameConfig = new Button();
            label11 = new Label();
            label12 = new Label();
            label14 = new Label();
            label16 = new Label();
            groupBox1 = new GroupBox();
            m_CbRFGainTarget = new ComboBox();
            f0000fe = new NumericUpDown();
            m_btnLoopBackBurstConfig = new Button();
            label40 = new Label();
            label39 = new Label();
            label38 = new Label();
            label37 = new Label();
            label36 = new Label();
            label35 = new Label();
            label34 = new Label();
            label33 = new Label();
            label32 = new Label();
            f0000fd = new ComboBox();
            label31 = new Label();
            f0000f2 = new ComboBox();
            f0000f3 = new ComboBox();
            m_chLPBDigCorrRxGainPhase = new CheckBox();
            m_chLPBDigitalCorrDisable = new CheckBox();
            f0000f4 = new CheckBox();
            f0000f5 = new CheckBox();
            f0000f6 = new CheckBox();
            f0000f7 = new CheckBox();
            f0000f8 = new CheckBox();
            f0000f9 = new CheckBox();
            m_chLPBTx3Enable = new CheckBox();
            m_chLPBTx2Enable = new CheckBox();
            m_chLPBTx1Enable = new CheckBox();
            f0000fa = new NumericUpDown();
            f0000fb = new NumericUpDown();
            f0000fc = new NumericUpDown();
            m_nudLPBRxGain = new NumericUpDown();
            m_nudLPBTx3BackOff = new NumericUpDown();
            m_nudLPBTx2BackOff = new NumericUpDown();
            m_nudLPBTx1BackOff = new NumericUpDown();
            m_nudLPBSlopeConst = new NumericUpDown();
            m_nudLPBFreqConst = new NumericUpDown();
            m_nudLPBBusrtIndex = new NumericUpDown();
            m_nudLPBBaseProfileIndex = new NumericUpDown();
            m_CbLoopBackSelect = new ComboBox();
            label30 = new Label();
            label29 = new Label();
            label28 = new Label();
            label27 = new Label();
            label26 = new Label();
            label25 = new Label();
            label24 = new Label();
            label23 = new Label();
            label15 = new Label();
            label13 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            groupBox4 = new GroupBox();
            m_ChSubFrameStartConfig = new CheckBox();
            m_btnSoftwareSubFrameStartConfig = new Button();
            label42 = new Label();
            m_grpAdvChirp = new GroupBox();
            m_btnAdvChirpConfig = new Button();
            m_nudFixedDeltaInc = new NumericUpDown();
            label51 = new Label();
            m_nudParamPeriod = new NumericUpDown();
            label50 = new Label();
            m_nudResetPeriod = new NumericUpDown();
            label49 = new Label();
            m_nudPatternMode = new NumericUpDown();
            label48 = new Label();
            m_nudResetMode = new NumericUpDown();
            label47 = new Label();
            m_nudChirpParamIdx = new NumericUpDown();
            label46 = new Label();
            groupBox2.SuspendLayout();
            ((ISupportInitialize)m_nudLoopBackCfgSubFrameID).BeginInit();
            groupBox3.SuspendLayout();
            ((ISupportInitialize)m_nudNoOfAdcSamples4).BeginInit();
            ((ISupportInitialize)m_nudNoOfAdcSamples3).BeginInit();
            ((ISupportInitialize)m_nudNoOfAdcSamples2).BeginInit();
            ((ISupportInitialize)m_nudNoOfAdcSamples).BeginInit();
            ((ISupportInitialize)m_nudSubFramePeriod4).BeginInit();
            ((ISupportInitialize)m_nudNumOfBrustLoops4).BeginInit();
            ((ISupportInitialize)m_nudNumOfBrust4).BeginInit();
            ((ISupportInitialize)m_nudChirpStartIdxOffset4).BeginInit();
            ((ISupportInitialize)m_nudBrustPeriodicity4).BeginInit();
            ((ISupportInitialize)m_nudNumOfLoops4).BeginInit();
            ((ISupportInitialize)m_nudNumOfChirps4).BeginInit();
            ((ISupportInitialize)m_nudChirpStartIdx4).BeginInit();
            ((ISupportInitialize)m_nudForceProfileIdx4).BeginInit();
            ((ISupportInitialize)m_nudSubFramePeriod3).BeginInit();
            ((ISupportInitialize)m_nudNumOfBrustLoops3).BeginInit();
            ((ISupportInitialize)m_nudNumOfBrust3).BeginInit();
            ((ISupportInitialize)m_nudChirpStartIdxOffset3).BeginInit();
            ((ISupportInitialize)m_nudBrustPeriodicity3).BeginInit();
            ((ISupportInitialize)m_nudNumOfLoops3).BeginInit();
            ((ISupportInitialize)m_nudNumOfChirps3).BeginInit();
            ((ISupportInitialize)m_nudChirpStartIdx3).BeginInit();
            ((ISupportInitialize)m_nudForceProfileIdx3).BeginInit();
            ((ISupportInitialize)m_nudSubFramePeriod2).BeginInit();
            ((ISupportInitialize)m_nudNumOfBrustLoops2).BeginInit();
            ((ISupportInitialize)m_nudNumOfBrust2).BeginInit();
            ((ISupportInitialize)m_nudChirpStartIdxOffset2).BeginInit();
            ((ISupportInitialize)m_nudBrustPeriodicity2).BeginInit();
            ((ISupportInitialize)m_nudNumOfLoops2).BeginInit();
            ((ISupportInitialize)m_nudNumOfChirps2).BeginInit();
            ((ISupportInitialize)m_nudChirpStartIdx2).BeginInit();
            ((ISupportInitialize)m_nudForceProfileIdx2).BeginInit();
            ((ISupportInitialize)m_nudSubFramePeriod).BeginInit();
            ((ISupportInitialize)m_nudNumOfBrustLoops).BeginInit();
            ((ISupportInitialize)m_nudNumOfBrust).BeginInit();
            ((ISupportInitialize)m_nudChirpStartIdxOffset).BeginInit();
            ((ISupportInitialize)m_nudBrustPeriodicity).BeginInit();
            ((ISupportInitialize)m_nudNumOfLoops).BeginInit();
            ((ISupportInitialize)m_nudNumOfChirps).BeginInit();
            ((ISupportInitialize)m_nudChirpStartIdx).BeginInit();
            ((ISupportInitialize)m_nudForceProfileIdx).BeginInit();
            ((ISupportInitialize)m_nudFrameTriggerDelay).BeginInit();
            ((ISupportInitialize)m_nudNumOfFrames).BeginInit();
            ((ISupportInitialize)m_nudNumOfSubFrames).BeginInit();
            groupBox1.SuspendLayout();
            ((ISupportInitialize)f0000fe).BeginInit();
            ((ISupportInitialize)f0000fa).BeginInit();
            ((ISupportInitialize)f0000fb).BeginInit();
            ((ISupportInitialize)f0000fc).BeginInit();
            ((ISupportInitialize)m_nudLPBRxGain).BeginInit();
            ((ISupportInitialize)m_nudLPBTx3BackOff).BeginInit();
            ((ISupportInitialize)m_nudLPBTx2BackOff).BeginInit();
            ((ISupportInitialize)m_nudLPBTx1BackOff).BeginInit();
            ((ISupportInitialize)m_nudLPBSlopeConst).BeginInit();
            ((ISupportInitialize)m_nudLPBFreqConst).BeginInit();
            ((ISupportInitialize)m_nudLPBBusrtIndex).BeginInit();
            ((ISupportInitialize)m_nudLPBBaseProfileIndex).BeginInit();
            groupBox4.SuspendLayout();
            m_grpAdvChirp.SuspendLayout();
            ((ISupportInitialize)m_nudFixedDeltaInc).BeginInit();
            ((ISupportInitialize)m_nudParamPeriod).BeginInit();
            ((ISupportInitialize)m_nudResetPeriod).BeginInit();
            ((ISupportInitialize)m_nudPatternMode).BeginInit();
            ((ISupportInitialize)m_nudResetMode).BeginInit();
            ((ISupportInitialize)m_nudChirpParamIdx).BeginInit();
            base.SuspendLayout();
            groupBox2.Controls.Add(m_lblSubFrame4ActiveRampDutyCycle);
            groupBox2.Controls.Add(m_lblSubFrame3ActiveRampDutyCycle);
            groupBox2.Controls.Add(m_lblSubFrame2ActiveRampDutyCycle);
            groupBox2.Controls.Add(m_lblSubFrame1ActiveRampDutyCycle);
            groupBox2.Controls.Add(label45);
            groupBox2.Controls.Add(m_lblSubFrame4DutyCycle);
            groupBox2.Controls.Add(m_lblSubFrame3DutyCycle);
            groupBox2.Controls.Add(m_lblSubFrame2DutyCycle);
            groupBox2.Controls.Add(m_lblSubFrame1DutyCycle);
            groupBox2.Controls.Add(label44);
            groupBox2.Controls.Add(m_ChkSWSubFrameTriggerCfg);
            groupBox2.Controls.Add(label43);
            groupBox2.Controls.Add(m_nudLoopBackCfgSubFrameID);
            groupBox2.Controls.Add(label41);
            groupBox2.Controls.Add(m_ChkBxLoopBackCfg);
            groupBox2.Controls.Add(m_chbSelectHardwareTrigger);
            groupBox2.Controls.Add(m_chbSelectSoftwareTrigger);
            groupBox2.Controls.Add(m_chbAdvancedFrameTestSourceEnable);
            groupBox2.Controls.Add(m_ChkBxForceProfile);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(m_nudFrameTriggerDelay);
            groupBox2.Controls.Add(m_nudNumOfFrames);
            groupBox2.Controls.Add(m_nudNumOfSubFrames);
            groupBox2.Controls.Add(m_btnAdvFrameConfig);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label16);
            groupBox2.Location = new Point(19, 16);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(800, 672);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Frame Configuration";
            m_lblSubFrame4ActiveRampDutyCycle.AutoSize = true;
            m_lblSubFrame4ActiveRampDutyCycle.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            m_lblSubFrame4ActiveRampDutyCycle.Location = new Point(686, 600);
            m_lblSubFrame4ActiveRampDutyCycle.Margin = new Padding(4, 0, 4, 0);
            m_lblSubFrame4ActiveRampDutyCycle.Name = "m_lblSubFrame4ActiveRampDutyCycle";
            m_lblSubFrame4ActiveRampDutyCycle.Size = new Size(28, 18);
            m_lblSubFrame4ActiveRampDutyCycle.TabIndex = 58;
            m_lblSubFrame4ActiveRampDutyCycle.Text = "0.0";
            m_lblSubFrame3ActiveRampDutyCycle.AutoSize = true;
            m_lblSubFrame3ActiveRampDutyCycle.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            m_lblSubFrame3ActiveRampDutyCycle.Location = new Point(528, 601);
            m_lblSubFrame3ActiveRampDutyCycle.Margin = new Padding(4, 0, 4, 0);
            m_lblSubFrame3ActiveRampDutyCycle.Name = "m_lblSubFrame3ActiveRampDutyCycle";
            m_lblSubFrame3ActiveRampDutyCycle.Size = new Size(28, 18);
            m_lblSubFrame3ActiveRampDutyCycle.TabIndex = 57;
            m_lblSubFrame3ActiveRampDutyCycle.Text = "0.0";
            m_lblSubFrame2ActiveRampDutyCycle.AutoSize = true;
            m_lblSubFrame2ActiveRampDutyCycle.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            m_lblSubFrame2ActiveRampDutyCycle.Location = new Point(382, 601);
            m_lblSubFrame2ActiveRampDutyCycle.Margin = new Padding(4, 0, 4, 0);
            m_lblSubFrame2ActiveRampDutyCycle.Name = "m_lblSubFrame2ActiveRampDutyCycle";
            m_lblSubFrame2ActiveRampDutyCycle.Size = new Size(28, 18);
            m_lblSubFrame2ActiveRampDutyCycle.TabIndex = 56;
            m_lblSubFrame2ActiveRampDutyCycle.Text = "0.0";
            m_lblSubFrame1ActiveRampDutyCycle.AutoSize = true;
            m_lblSubFrame1ActiveRampDutyCycle.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            m_lblSubFrame1ActiveRampDutyCycle.Location = new Point(218, 601);
            m_lblSubFrame1ActiveRampDutyCycle.Margin = new Padding(4, 0, 4, 0);
            m_lblSubFrame1ActiveRampDutyCycle.Name = "m_lblSubFrame1ActiveRampDutyCycle";
            m_lblSubFrame1ActiveRampDutyCycle.Size = new Size(28, 18);
            m_lblSubFrame1ActiveRampDutyCycle.TabIndex = 55;
            m_lblSubFrame1ActiveRampDutyCycle.Text = "0.0";
            label45.AutoSize = true;
            label45.Location = new Point(8, 601);
            label45.Margin = new Padding(4, 0, 4, 0);
            label45.Name = "label45";
            label45.Size = new Size(159, 17);
            label45.TabIndex = 54;
            label45.Text = "Active-Ramp Duty Cycle";
            m_lblSubFrame4DutyCycle.AutoSize = true;
            m_lblSubFrame4DutyCycle.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            m_lblSubFrame4DutyCycle.Location = new Point(686, 572);
            m_lblSubFrame4DutyCycle.Margin = new Padding(4, 0, 4, 0);
            m_lblSubFrame4DutyCycle.Name = "m_lblSubFrame4DutyCycle";
            m_lblSubFrame4DutyCycle.Size = new Size(28, 18);
            m_lblSubFrame4DutyCycle.TabIndex = 53;
            m_lblSubFrame4DutyCycle.Text = "0.0";
            m_lblSubFrame3DutyCycle.AutoSize = true;
            m_lblSubFrame3DutyCycle.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            m_lblSubFrame3DutyCycle.Location = new Point(528, 572);
            m_lblSubFrame3DutyCycle.Margin = new Padding(4, 0, 4, 0);
            m_lblSubFrame3DutyCycle.Name = "m_lblSubFrame3DutyCycle";
            m_lblSubFrame3DutyCycle.Size = new Size(28, 18);
            m_lblSubFrame3DutyCycle.TabIndex = 52;
            m_lblSubFrame3DutyCycle.Text = "0.0";
            m_lblSubFrame2DutyCycle.AutoSize = true;
            m_lblSubFrame2DutyCycle.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            m_lblSubFrame2DutyCycle.Location = new Point(382, 573);
            m_lblSubFrame2DutyCycle.Margin = new Padding(4, 0, 4, 0);
            m_lblSubFrame2DutyCycle.Name = "m_lblSubFrame2DutyCycle";
            m_lblSubFrame2DutyCycle.Size = new Size(28, 18);
            m_lblSubFrame2DutyCycle.TabIndex = 51;
            m_lblSubFrame2DutyCycle.Text = "0.0";
            m_lblSubFrame1DutyCycle.AutoSize = true;
            m_lblSubFrame1DutyCycle.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            m_lblSubFrame1DutyCycle.Location = new Point(218, 573);
            m_lblSubFrame1DutyCycle.Margin = new Padding(4, 0, 4, 0);
            m_lblSubFrame1DutyCycle.Name = "m_lblSubFrame1DutyCycle";
            m_lblSubFrame1DutyCycle.Size = new Size(28, 18);
            m_lblSubFrame1DutyCycle.TabIndex = 50;
            m_lblSubFrame1DutyCycle.Text = "0.0";
            label44.AutoSize = true;
            label44.Location = new Point(91, 573);
            label44.Margin = new Padding(4, 0, 4, 0);
            label44.Name = "label44";
            label44.Size = new Size(75, 17);
            label44.TabIndex = 49;
            label44.Text = "Duty Cycle";
            m_ChkSWSubFrameTriggerCfg.AutoSize = true;
            m_ChkSWSubFrameTriggerCfg.Location = new Point(707, 95);
            m_ChkSWSubFrameTriggerCfg.Margin = new Padding(4);
            m_ChkSWSubFrameTriggerCfg.Name = "m_ChkSWSubFrameTriggerCfg";
            m_ChkSWSubFrameTriggerCfg.Size = new Size(18, 17);
            m_ChkSWSubFrameTriggerCfg.TabIndex = 26;
            m_ChkSWSubFrameTriggerCfg.UseVisualStyleBackColor = true;
            label43.AutoSize = true;
            label43.Location = new Point(535, 95);
            label43.Margin = new Padding(4, 0, 4, 0);
            label43.Name = "label43";
            label43.Size = new Size(128, 17);
            label43.TabIndex = 25;
            label43.Text = "Sub-Frame Trigger";
            m_nudLoopBackCfgSubFrameID.Location = new Point(185, 157);
            m_nudLoopBackCfgSubFrameID.Margin = new Padding(4);
            NumericUpDown nudLoopBackCfgSubFrameID = m_nudLoopBackCfgSubFrameID;
            int[] array = new int[4];
            array[0] = 3;
            nudLoopBackCfgSubFrameID.Maximum = new decimal(array);
            m_nudLoopBackCfgSubFrameID.Name = "m_nudLoopBackCfgSubFrameID";
            m_nudLoopBackCfgSubFrameID.Size = new Size(104, 22);
            m_nudLoopBackCfgSubFrameID.TabIndex = 24;
            label41.AutoSize = true;
            label41.Location = new Point(27, 161);
            label41.Margin = new Padding(4, 0, 4, 0);
            label41.Name = "label41";
            label41.Size = new Size(148, 17);
            label41.TabIndex = 23;
            label41.Text = "Loop Bk Sub Frame Id";
            m_ChkBxLoopBackCfg.AutoSize = true;
            m_ChkBxLoopBackCfg.Location = new Point(300, 160);
            m_ChkBxLoopBackCfg.Margin = new Padding(4);
            m_ChkBxLoopBackCfg.Name = "m_ChkBxLoopBackCfg";
            m_ChkBxLoopBackCfg.Size = new Size(110, 21);
            m_ChkBxLoopBackCfg.TabIndex = 22;
            m_ChkBxLoopBackCfg.Text = "LoopBackEn";
            m_ChkBxLoopBackCfg.UseVisualStyleBackColor = true;
            m_chbSelectHardwareTrigger.AutoSize = true;
            m_chbSelectHardwareTrigger.Location = new Point(325, 91);
            m_chbSelectHardwareTrigger.Margin = new Padding(4);
            m_chbSelectHardwareTrigger.Name = "m_chbSelectHardwareTrigger";
            m_chbSelectHardwareTrigger.Size = new Size(136, 21);
            m_chbSelectHardwareTrigger.TabIndex = 21;
            m_chbSelectHardwareTrigger.Text = "HardwareTrigger";
            m_chbSelectHardwareTrigger.UseVisualStyleBackColor = true;
            m_chbSelectSoftwareTrigger.AutoSize = true;
            m_chbSelectSoftwareTrigger.Checked = true;
            m_chbSelectSoftwareTrigger.Location = new Point(184, 91);
            m_chbSelectSoftwareTrigger.Margin = new Padding(4);
            m_chbSelectSoftwareTrigger.Name = "m_chbSelectSoftwareTrigger";
            m_chbSelectSoftwareTrigger.Size = new Size(134, 21);
            m_chbSelectSoftwareTrigger.TabIndex = 20;
            m_chbSelectSoftwareTrigger.TabStop = true;
            m_chbSelectSoftwareTrigger.Text = "Software Trigger";
            m_chbSelectSoftwareTrigger.UseVisualStyleBackColor = true;
            m_chbAdvancedFrameTestSourceEnable.AutoSize = true;
            m_chbAdvancedFrameTestSourceEnable.Location = new Point(16, 637);
            m_chbAdvancedFrameTestSourceEnable.Margin = new Padding(4);
            m_chbAdvancedFrameTestSourceEnable.Name = "m_chbAdvancedFrameTestSourceEnable";
            m_chbAdvancedFrameTestSourceEnable.Size = new Size(155, 21);
            m_chbAdvancedFrameTestSourceEnable.TabIndex = 19;
            m_chbAdvancedFrameTestSourceEnable.Text = "Test Source Enable";
            m_chbAdvancedFrameTestSourceEnable.UseVisualStyleBackColor = true;
            m_ChkBxForceProfile.AutoSize = true;
            m_ChkBxForceProfile.Location = new Point(318, 123);
            m_ChkBxForceProfile.Margin = new Padding(4);
            m_ChkBxForceProfile.Name = "m_ChkBxForceProfile";
            m_ChkBxForceProfile.Size = new Size(106, 21);
            m_ChkBxForceProfile.TabIndex = 16;
            m_ChkBxForceProfile.Text = "ForceProfile";
            m_ChkBxForceProfile.UseVisualStyleBackColor = true;
            m_ChkBxForceProfile.CheckedChanged += m_ChkBxForceProfile_StatesChanged;
            groupBox3.Controls.Add(m_nudNoOfAdcSamples4);
            groupBox3.Controls.Add(m_nudNoOfAdcSamples3);
            groupBox3.Controls.Add(m_nudNoOfAdcSamples2);
            groupBox3.Controls.Add(m_nudNoOfAdcSamples);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(m_nudSubFramePeriod4);
            groupBox3.Controls.Add(m_nudNumOfBrustLoops4);
            groupBox3.Controls.Add(m_nudNumOfBrust4);
            groupBox3.Controls.Add(m_nudChirpStartIdxOffset4);
            groupBox3.Controls.Add(m_nudBrustPeriodicity4);
            groupBox3.Controls.Add(m_nudNumOfLoops4);
            groupBox3.Controls.Add(m_nudNumOfChirps4);
            groupBox3.Controls.Add(m_nudChirpStartIdx4);
            groupBox3.Controls.Add(m_nudForceProfileIdx4);
            groupBox3.Controls.Add(m_nudSubFramePeriod3);
            groupBox3.Controls.Add(m_nudNumOfBrustLoops3);
            groupBox3.Controls.Add(m_nudNumOfBrust3);
            groupBox3.Controls.Add(m_nudChirpStartIdxOffset3);
            groupBox3.Controls.Add(m_nudBrustPeriodicity3);
            groupBox3.Controls.Add(m_nudNumOfLoops3);
            groupBox3.Controls.Add(m_nudNumOfChirps3);
            groupBox3.Controls.Add(m_nudChirpStartIdx3);
            groupBox3.Controls.Add(m_nudForceProfileIdx3);
            groupBox3.Controls.Add(m_nudSubFramePeriod2);
            groupBox3.Controls.Add(m_nudNumOfBrustLoops2);
            groupBox3.Controls.Add(m_nudNumOfBrust2);
            groupBox3.Controls.Add(m_nudChirpStartIdxOffset2);
            groupBox3.Controls.Add(m_nudBrustPeriodicity2);
            groupBox3.Controls.Add(m_nudNumOfLoops2);
            groupBox3.Controls.Add(m_nudNumOfChirps2);
            groupBox3.Controls.Add(m_nudChirpStartIdx2);
            groupBox3.Controls.Add(m_nudForceProfileIdx2);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(m_nudSubFramePeriod);
            groupBox3.Controls.Add(m_nudSubFramePeriodicity);
            groupBox3.Controls.Add(m_nudNumOfBrustLoops);
            groupBox3.Controls.Add(m_nudNumOfBrust);
            groupBox3.Controls.Add(m_nudChirpStartIdxOffset);
            groupBox3.Controls.Add(m_nudBrustPeriodicity);
            groupBox3.Controls.Add(m_nudNumOfLoops);
            groupBox3.Controls.Add(m_nudNumOfChirps);
            groupBox3.Controls.Add(m_nudChirpStartIdx);
            groupBox3.Controls.Add(m_nudForceProfileIdx);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(label19);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(label22);
            groupBox3.Location = new Point(16, 191);
            groupBox3.Margin = new Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4);
            groupBox3.Size = new Size(753, 370);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Sub Frame Configuration";
            m_nudNoOfAdcSamples4.Location = new Point(633, 338);
            m_nudNoOfAdcSamples4.Margin = new Padding(4);
            NumericUpDown nudNoOfAdcSamples = m_nudNoOfAdcSamples4;
            int[] array2 = new int[4];
            array2[0] = 8;
            nudNoOfAdcSamples.Maximum = new decimal(array2);
            NumericUpDown nudNoOfAdcSamples2 = m_nudNoOfAdcSamples4;
            int[] array3 = new int[4];
            array3[0] = 1;
            nudNoOfAdcSamples2.Minimum = new decimal(array3);
            m_nudNoOfAdcSamples4.Name = "m_nudNoOfAdcSamples4";
            m_nudNoOfAdcSamples4.Size = new Size(111, 22);
            m_nudNoOfAdcSamples4.TabIndex = 54;
            NumericUpDown nudNoOfAdcSamples3 = m_nudNoOfAdcSamples4;
            int[] array4 = new int[4];
            array4[0] = 1;
            nudNoOfAdcSamples3.Value = new decimal(array4);
            m_nudNoOfAdcSamples3.Location = new Point(476, 338);
            m_nudNoOfAdcSamples3.Margin = new Padding(4);
            NumericUpDown nudNoOfAdcSamples4 = m_nudNoOfAdcSamples3;
            int[] array5 = new int[4];
            array5[0] = 8;
            nudNoOfAdcSamples4.Maximum = new decimal(array5);
            NumericUpDown nudNoOfAdcSamples5 = m_nudNoOfAdcSamples3;
            int[] array6 = new int[4];
            array6[0] = 1;
            nudNoOfAdcSamples5.Minimum = new decimal(array6);
            m_nudNoOfAdcSamples3.Name = "m_nudNoOfAdcSamples3";
            m_nudNoOfAdcSamples3.Size = new Size(111, 22);
            m_nudNoOfAdcSamples3.TabIndex = 53;
            NumericUpDown nudNoOfAdcSamples6 = m_nudNoOfAdcSamples3;
            int[] array7 = new int[4];
            array7[0] = 1;
            nudNoOfAdcSamples6.Value = new decimal(array7);
            m_nudNoOfAdcSamples2.Location = new Point(324, 338);
            m_nudNoOfAdcSamples2.Margin = new Padding(4);
            NumericUpDown nudNoOfAdcSamples7 = m_nudNoOfAdcSamples2;
            int[] array8 = new int[4];
            array8[0] = 8;
            nudNoOfAdcSamples7.Maximum = new decimal(array8);
            NumericUpDown nudNoOfAdcSamples8 = m_nudNoOfAdcSamples2;
            int[] array9 = new int[4];
            array9[0] = 1;
            nudNoOfAdcSamples8.Minimum = new decimal(array9);
            m_nudNoOfAdcSamples2.Name = "m_nudNoOfAdcSamples2";
            m_nudNoOfAdcSamples2.Size = new Size(111, 22);
            m_nudNoOfAdcSamples2.TabIndex = 52;
            NumericUpDown nudNoOfAdcSamples9 = m_nudNoOfAdcSamples2;
            int[] array10 = new int[4];
            array10[0] = 1;
            nudNoOfAdcSamples9.Value = new decimal(array10);
            m_nudNoOfAdcSamples.Location = new Point(165, 338);
            m_nudNoOfAdcSamples.Margin = new Padding(4);
            NumericUpDown nudNoOfAdcSamples10 = m_nudNoOfAdcSamples;
            int[] array11 = new int[4];
            array11[0] = 8;
            nudNoOfAdcSamples10.Maximum = new decimal(array11);
            NumericUpDown nudNoOfAdcSamples11 = m_nudNoOfAdcSamples;
            int[] array12 = new int[4];
            array12[0] = 1;
            nudNoOfAdcSamples11.Minimum = new decimal(array12);
            m_nudNoOfAdcSamples.Name = "m_nudNoOfAdcSamples";
            m_nudNoOfAdcSamples.Size = new Size(108, 22);
            m_nudNoOfAdcSamples.TabIndex = 51;
            NumericUpDown nudNoOfAdcSamples12 = m_nudNoOfAdcSamples;
            int[] array13 = new int[4];
            array13[0] = 1;
            nudNoOfAdcSamples12.Value = new decimal(array13);
            label5.AutoSize = true;
            label5.Location = new Point(16, 338);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(120, 17);
            label5.TabIndex = 50;
            label5.Text = "ChirpsPerDataPkt";
            m_nudSubFramePeriod4.DecimalPlaces = 6;
            m_nudSubFramePeriod4.Increment = new decimal(new int[]
            {
                5,
                0,
                0,
                327680
            });
            m_nudSubFramePeriod4.Location = new Point(633, 308);
            m_nudSubFramePeriod4.Margin = new Padding(4);
            NumericUpDown nudSubFramePeriod = m_nudSubFramePeriod4;
            int[] array14 = new int[4];
            array14[0] = 1342;
            nudSubFramePeriod.Maximum = new decimal(array14);
            m_nudSubFramePeriod4.Name = "m_nudSubFramePeriod4";
            m_nudSubFramePeriod4.Size = new Size(111, 22);
            m_nudSubFramePeriod4.TabIndex = 49;
            NumericUpDown nudSubFramePeriod2 = m_nudSubFramePeriod4;
            int[] array15 = new int[4];
            array15[0] = 40;
            nudSubFramePeriod2.Value = new decimal(array15);
            m_nudSubFramePeriod4.ValueChanged += m_nudSubFrame4Periodicity_ValueChanged;
            m_nudNumOfBrustLoops4.Location = new Point(636, 277);
            m_nudNumOfBrustLoops4.Margin = new Padding(4);
            NumericUpDown nudNumOfBrustLoops = m_nudNumOfBrustLoops4;
            int[] array16 = new int[4];
            array16[0] = 64;
            nudNumOfBrustLoops.Maximum = new decimal(array16);
            NumericUpDown nudNumOfBrustLoops2 = m_nudNumOfBrustLoops4;
            int[] array17 = new int[4];
            array17[0] = 1;
            nudNumOfBrustLoops2.Minimum = new decimal(array17);
            m_nudNumOfBrustLoops4.Name = "m_nudNumOfBrustLoops4";
            m_nudNumOfBrustLoops4.Size = new Size(108, 22);
            m_nudNumOfBrustLoops4.TabIndex = 48;
            NumericUpDown nudNumOfBrustLoops3 = m_nudNumOfBrustLoops4;
            int[] array18 = new int[4];
            array18[0] = 1;
            nudNumOfBrustLoops3.Value = new decimal(array18);
            m_nudNumOfBrust4.Location = new Point(636, 246);
            m_nudNumOfBrust4.Margin = new Padding(4);
            NumericUpDown nudNumOfBrust = m_nudNumOfBrust4;
            int[] array19 = new int[4];
            array19[0] = 512;
            nudNumOfBrust.Maximum = new decimal(array19);
            NumericUpDown nudNumOfBrust2 = m_nudNumOfBrust4;
            int[] array20 = new int[4];
            array20[0] = 1;
            nudNumOfBrust2.Minimum = new decimal(array20);
            m_nudNumOfBrust4.Name = "m_nudNumOfBrust4";
            m_nudNumOfBrust4.Size = new Size(108, 22);
            m_nudNumOfBrust4.TabIndex = 47;
            NumericUpDown nudNumOfBrust3 = m_nudNumOfBrust4;
            int[] array21 = new int[4];
            array21[0] = 1;
            nudNumOfBrust3.Value = new decimal(array21);
            m_nudChirpStartIdxOffset4.Location = new Point(636, 215);
            m_nudChirpStartIdxOffset4.Margin = new Padding(4);
            NumericUpDown nudChirpStartIdxOffset = m_nudChirpStartIdxOffset4;
            int[] array22 = new int[4];
            array22[0] = 511;
            nudChirpStartIdxOffset.Maximum = new decimal(array22);
            m_nudChirpStartIdxOffset4.Name = "m_nudChirpStartIdxOffset4";
            m_nudChirpStartIdxOffset4.Size = new Size(108, 22);
            m_nudChirpStartIdxOffset4.TabIndex = 46;
            m_nudBrustPeriodicity4.DecimalPlaces = 6;
            m_nudBrustPeriodicity4.Increment = new decimal(new int[]
            {
                5,
                0,
                0,
                327680
            });
            m_nudBrustPeriodicity4.Location = new Point(636, 185);
            m_nudBrustPeriodicity4.Margin = new Padding(4);
            NumericUpDown nudBrustPeriodicity = m_nudBrustPeriodicity4;
            int[] array23 = new int[4];
            array23[0] = 1342;
            nudBrustPeriodicity.Maximum = new decimal(array23);
            m_nudBrustPeriodicity4.Name = "m_nudBrustPeriodicity4";
            m_nudBrustPeriodicity4.Size = new Size(108, 22);
            m_nudBrustPeriodicity4.TabIndex = 45;
            NumericUpDown nudBrustPeriodicity2 = m_nudBrustPeriodicity4;
            int[] array24 = new int[4];
            array24[0] = 40;
            nudBrustPeriodicity2.Value = new decimal(array24);
            m_nudBrustPeriodicity4.ValueChanged += m_nudSubFrameBurst4Periodicity_ValueChanged;
            m_nudNumOfLoops4.Location = new Point(636, 154);
            m_nudNumOfLoops4.Margin = new Padding(4);
            NumericUpDown nudNumOfLoops = m_nudNumOfLoops4;
            int[] array25 = new int[4];
            array25[0] = 255;
            nudNumOfLoops.Maximum = new decimal(array25);
            NumericUpDown nudNumOfLoops2 = m_nudNumOfLoops4;
            int[] array26 = new int[4];
            array26[0] = 1;
            nudNumOfLoops2.Minimum = new decimal(array26);
            m_nudNumOfLoops4.Name = "m_nudNumOfLoops4";
            m_nudNumOfLoops4.Size = new Size(108, 22);
            m_nudNumOfLoops4.TabIndex = 44;
            NumericUpDown nudNumOfLoops3 = m_nudNumOfLoops4;
            int[] array27 = new int[4];
            array27[0] = 128;
            nudNumOfLoops3.Value = new decimal(array27);
            m_nudNumOfLoops4.ValueChanged += m_nudNumOfLoops4_ValueChanged;
            m_nudNumOfChirps4.Location = new Point(636, 123);
            m_nudNumOfChirps4.Margin = new Padding(4);
            NumericUpDown nudNumOfChirps = m_nudNumOfChirps4;
            int[] array28 = new int[4];
            array28[0] = 512;
            nudNumOfChirps.Maximum = new decimal(array28);
            NumericUpDown nudNumOfChirps2 = m_nudNumOfChirps4;
            int[] array29 = new int[4];
            array29[0] = 1;
            nudNumOfChirps2.Minimum = new decimal(array29);
            m_nudNumOfChirps4.Name = "m_nudNumOfChirps4";
            m_nudNumOfChirps4.Size = new Size(108, 22);
            m_nudNumOfChirps4.TabIndex = 43;
            NumericUpDown nudNumOfChirps3 = m_nudNumOfChirps4;
            int[] array30 = new int[4];
            array30[0] = 1;
            nudNumOfChirps3.Value = new decimal(array30);
            m_nudNumOfChirps4.ValueChanged += m_nudNumOfChirps4_ValueChanged;
            m_nudChirpStartIdx4.Location = new Point(636, 92);
            m_nudChirpStartIdx4.Margin = new Padding(4);
            NumericUpDown nudChirpStartIdx = m_nudChirpStartIdx4;
            int[] array31 = new int[4];
            array31[0] = 511;
            nudChirpStartIdx.Maximum = new decimal(array31);
            m_nudChirpStartIdx4.Name = "m_nudChirpStartIdx4";
            m_nudChirpStartIdx4.Size = new Size(108, 22);
            m_nudChirpStartIdx4.TabIndex = 42;
            m_nudChirpStartIdx4.ValueChanged += m_nudChirpStartIdx4_ValueChanged;
            m_nudForceProfileIdx4.Location = new Point(636, 62);
            m_nudForceProfileIdx4.Margin = new Padding(4);
            NumericUpDown nudForceProfileIdx = m_nudForceProfileIdx4;
            int[] array32 = new int[4];
            array32[0] = 3;
            nudForceProfileIdx.Maximum = new decimal(array32);
            m_nudForceProfileIdx4.Name = "m_nudForceProfileIdx4";
            m_nudForceProfileIdx4.Size = new Size(108, 22);
            m_nudForceProfileIdx4.TabIndex = 41;
            m_nudSubFramePeriod3.DecimalPlaces = 6;
            m_nudSubFramePeriod3.Increment = new decimal(new int[]
            {
                5,
                0,
                0,
                327680
            });
            m_nudSubFramePeriod3.Location = new Point(476, 308);
            m_nudSubFramePeriod3.Margin = new Padding(4);
            NumericUpDown nudSubFramePeriod3 = m_nudSubFramePeriod3;
            int[] array33 = new int[4];
            array33[0] = 1342;
            nudSubFramePeriod3.Maximum = new decimal(array33);
            m_nudSubFramePeriod3.Name = "m_nudSubFramePeriod3";
            m_nudSubFramePeriod3.Size = new Size(111, 22);
            m_nudSubFramePeriod3.TabIndex = 40;
            NumericUpDown nudSubFramePeriod4 = m_nudSubFramePeriod3;
            int[] array34 = new int[4];
            array34[0] = 40;
            nudSubFramePeriod4.Value = new decimal(array34);
            m_nudSubFramePeriod3.ValueChanged += m_nudSubFrame3Periodicity_ValueChanged;
            m_nudNumOfBrustLoops3.Location = new Point(479, 277);
            m_nudNumOfBrustLoops3.Margin = new Padding(4);
            NumericUpDown nudNumOfBrustLoops4 = m_nudNumOfBrustLoops3;
            int[] array35 = new int[4];
            array35[0] = 64;
            nudNumOfBrustLoops4.Maximum = new decimal(array35);
            NumericUpDown nudNumOfBrustLoops5 = m_nudNumOfBrustLoops3;
            int[] array36 = new int[4];
            array36[0] = 1;
            nudNumOfBrustLoops5.Minimum = new decimal(array36);
            m_nudNumOfBrustLoops3.Name = "m_nudNumOfBrustLoops3";
            m_nudNumOfBrustLoops3.Size = new Size(108, 22);
            m_nudNumOfBrustLoops3.TabIndex = 39;
            NumericUpDown nudNumOfBrustLoops6 = m_nudNumOfBrustLoops3;
            int[] array37 = new int[4];
            array37[0] = 1;
            nudNumOfBrustLoops6.Value = new decimal(array37);
            m_nudNumOfBrust3.Location = new Point(479, 246);
            m_nudNumOfBrust3.Margin = new Padding(4);
            NumericUpDown nudNumOfBrust4 = m_nudNumOfBrust3;
            int[] array38 = new int[4];
            array38[0] = 512;
            nudNumOfBrust4.Maximum = new decimal(array38);
            NumericUpDown nudNumOfBrust5 = m_nudNumOfBrust3;
            int[] array39 = new int[4];
            array39[0] = 1;
            nudNumOfBrust5.Minimum = new decimal(array39);
            m_nudNumOfBrust3.Name = "m_nudNumOfBrust3";
            m_nudNumOfBrust3.Size = new Size(108, 22);
            m_nudNumOfBrust3.TabIndex = 38;
            NumericUpDown nudNumOfBrust6 = m_nudNumOfBrust3;
            int[] array40 = new int[4];
            array40[0] = 1;
            nudNumOfBrust6.Value = new decimal(array40);
            m_nudChirpStartIdxOffset3.Location = new Point(479, 215);
            m_nudChirpStartIdxOffset3.Margin = new Padding(4);
            NumericUpDown nudChirpStartIdxOffset2 = m_nudChirpStartIdxOffset3;
            int[] array41 = new int[4];
            array41[0] = 511;
            nudChirpStartIdxOffset2.Maximum = new decimal(array41);
            m_nudChirpStartIdxOffset3.Name = "m_nudChirpStartIdxOffset3";
            m_nudChirpStartIdxOffset3.Size = new Size(108, 22);
            m_nudChirpStartIdxOffset3.TabIndex = 37;
            m_nudBrustPeriodicity3.DecimalPlaces = 6;
            m_nudBrustPeriodicity3.Increment = new decimal(new int[]
            {
                5,
                0,
                0,
                327680
            });
            m_nudBrustPeriodicity3.Location = new Point(479, 185);
            m_nudBrustPeriodicity3.Margin = new Padding(4);
            NumericUpDown nudBrustPeriodicity3 = m_nudBrustPeriodicity3;
            int[] array42 = new int[4];
            array42[0] = 1342;
            nudBrustPeriodicity3.Maximum = new decimal(array42);
            m_nudBrustPeriodicity3.Name = "m_nudBrustPeriodicity3";
            m_nudBrustPeriodicity3.Size = new Size(108, 22);
            m_nudBrustPeriodicity3.TabIndex = 36;
            NumericUpDown nudBrustPeriodicity4 = m_nudBrustPeriodicity3;
            int[] array43 = new int[4];
            array43[0] = 40;
            nudBrustPeriodicity4.Value = new decimal(array43);
            m_nudBrustPeriodicity3.ValueChanged += m_nudSubFrameBurst3Periodicity_ValueChanged;
            m_nudNumOfLoops3.Location = new Point(479, 154);
            m_nudNumOfLoops3.Margin = new Padding(4);
            NumericUpDown nudNumOfLoops4 = m_nudNumOfLoops3;
            int[] array44 = new int[4];
            array44[0] = 255;
            nudNumOfLoops4.Maximum = new decimal(array44);
            NumericUpDown nudNumOfLoops5 = m_nudNumOfLoops3;
            int[] array45 = new int[4];
            array45[0] = 1;
            nudNumOfLoops5.Minimum = new decimal(array45);
            m_nudNumOfLoops3.Name = "m_nudNumOfLoops3";
            m_nudNumOfLoops3.Size = new Size(108, 22);
            m_nudNumOfLoops3.TabIndex = 35;
            NumericUpDown nudNumOfLoops6 = m_nudNumOfLoops3;
            int[] array46 = new int[4];
            array46[0] = 128;
            nudNumOfLoops6.Value = new decimal(array46);
            m_nudNumOfLoops3.ValueChanged += m_nudNumOfLoops3_ValueChanged;
            m_nudNumOfChirps3.Location = new Point(479, 123);
            m_nudNumOfChirps3.Margin = new Padding(4);
            NumericUpDown nudNumOfChirps4 = m_nudNumOfChirps3;
            int[] array47 = new int[4];
            array47[0] = 512;
            nudNumOfChirps4.Maximum = new decimal(array47);
            NumericUpDown nudNumOfChirps5 = m_nudNumOfChirps3;
            int[] array48 = new int[4];
            array48[0] = 1;
            nudNumOfChirps5.Minimum = new decimal(array48);
            m_nudNumOfChirps3.Name = "m_nudNumOfChirps3";
            m_nudNumOfChirps3.Size = new Size(108, 22);
            m_nudNumOfChirps3.TabIndex = 34;
            NumericUpDown nudNumOfChirps6 = m_nudNumOfChirps3;
            int[] array49 = new int[4];
            array49[0] = 1;
            nudNumOfChirps6.Value = new decimal(array49);
            m_nudNumOfChirps3.ValueChanged += m_nudNumOfChirps3_ValueChanged;
            m_nudChirpStartIdx3.Location = new Point(479, 92);
            m_nudChirpStartIdx3.Margin = new Padding(4);
            NumericUpDown nudChirpStartIdx2 = m_nudChirpStartIdx3;
            int[] array50 = new int[4];
            array50[0] = 511;
            nudChirpStartIdx2.Maximum = new decimal(array50);
            m_nudChirpStartIdx3.Name = "m_nudChirpStartIdx3";
            m_nudChirpStartIdx3.Size = new Size(108, 22);
            m_nudChirpStartIdx3.TabIndex = 33;
            m_nudChirpStartIdx3.ValueChanged += m_nudChirpStartIdx3_ValueChanged;
            m_nudForceProfileIdx3.Location = new Point(479, 62);
            m_nudForceProfileIdx3.Margin = new Padding(4);
            NumericUpDown nudForceProfileIdx2 = m_nudForceProfileIdx3;
            int[] array51 = new int[4];
            array51[0] = 3;
            nudForceProfileIdx2.Maximum = new decimal(array51);
            m_nudForceProfileIdx3.Name = "m_nudForceProfileIdx3";
            m_nudForceProfileIdx3.Size = new Size(108, 22);
            m_nudForceProfileIdx3.TabIndex = 32;
            m_nudSubFramePeriod2.DecimalPlaces = 6;
            m_nudSubFramePeriod2.Increment = new decimal(new int[]
            {
                5,
                0,
                0,
                327680
            });
            m_nudSubFramePeriod2.Location = new Point(324, 308);
            m_nudSubFramePeriod2.Margin = new Padding(4);
            NumericUpDown nudSubFramePeriod5 = m_nudSubFramePeriod2;
            int[] array52 = new int[4];
            array52[0] = 1342;
            nudSubFramePeriod5.Maximum = new decimal(array52);
            m_nudSubFramePeriod2.Name = "m_nudSubFramePeriod2";
            m_nudSubFramePeriod2.Size = new Size(111, 22);
            m_nudSubFramePeriod2.TabIndex = 31;
            NumericUpDown nudSubFramePeriod6 = m_nudSubFramePeriod2;
            int[] array53 = new int[4];
            array53[0] = 40;
            nudSubFramePeriod6.Value = new decimal(array53);
            m_nudSubFramePeriod2.ValueChanged += m_nudSubFrame2Periodicity_ValueChanged;
            m_nudNumOfBrustLoops2.Location = new Point(327, 277);
            m_nudNumOfBrustLoops2.Margin = new Padding(4);
            NumericUpDown nudNumOfBrustLoops7 = m_nudNumOfBrustLoops2;
            int[] array54 = new int[4];
            array54[0] = 64;
            nudNumOfBrustLoops7.Maximum = new decimal(array54);
            NumericUpDown nudNumOfBrustLoops8 = m_nudNumOfBrustLoops2;
            int[] array55 = new int[4];
            array55[0] = 1;
            nudNumOfBrustLoops8.Minimum = new decimal(array55);
            m_nudNumOfBrustLoops2.Name = "m_nudNumOfBrustLoops2";
            m_nudNumOfBrustLoops2.Size = new Size(108, 22);
            m_nudNumOfBrustLoops2.TabIndex = 30;
            NumericUpDown nudNumOfBrustLoops9 = m_nudNumOfBrustLoops2;
            int[] array56 = new int[4];
            array56[0] = 1;
            nudNumOfBrustLoops9.Value = new decimal(array56);
            m_nudNumOfBrust2.Location = new Point(327, 246);
            m_nudNumOfBrust2.Margin = new Padding(4);
            NumericUpDown nudNumOfBrust7 = m_nudNumOfBrust2;
            int[] array57 = new int[4];
            array57[0] = 512;
            nudNumOfBrust7.Maximum = new decimal(array57);
            NumericUpDown nudNumOfBrust8 = m_nudNumOfBrust2;
            int[] array58 = new int[4];
            array58[0] = 1;
            nudNumOfBrust8.Minimum = new decimal(array58);
            m_nudNumOfBrust2.Name = "m_nudNumOfBrust2";
            m_nudNumOfBrust2.Size = new Size(108, 22);
            m_nudNumOfBrust2.TabIndex = 29;
            NumericUpDown nudNumOfBrust9 = m_nudNumOfBrust2;
            int[] array59 = new int[4];
            array59[0] = 1;
            nudNumOfBrust9.Value = new decimal(array59);
            m_nudChirpStartIdxOffset2.Location = new Point(327, 215);
            m_nudChirpStartIdxOffset2.Margin = new Padding(4);
            NumericUpDown nudChirpStartIdxOffset3 = m_nudChirpStartIdxOffset2;
            int[] array60 = new int[4];
            array60[0] = 511;
            nudChirpStartIdxOffset3.Maximum = new decimal(array60);
            m_nudChirpStartIdxOffset2.Name = "m_nudChirpStartIdxOffset2";
            m_nudChirpStartIdxOffset2.Size = new Size(108, 22);
            m_nudChirpStartIdxOffset2.TabIndex = 28;
            m_nudBrustPeriodicity2.DecimalPlaces = 6;
            m_nudBrustPeriodicity2.Increment = new decimal(new int[]
            {
                5,
                0,
                0,
                327680
            });
            m_nudBrustPeriodicity2.Location = new Point(327, 185);
            m_nudBrustPeriodicity2.Margin = new Padding(4);
            NumericUpDown nudBrustPeriodicity5 = m_nudBrustPeriodicity2;
            int[] array61 = new int[4];
            array61[0] = 1342;
            nudBrustPeriodicity5.Maximum = new decimal(array61);
            m_nudBrustPeriodicity2.Name = "m_nudBrustPeriodicity2";
            m_nudBrustPeriodicity2.Size = new Size(108, 22);
            m_nudBrustPeriodicity2.TabIndex = 27;
            NumericUpDown nudBrustPeriodicity6 = m_nudBrustPeriodicity2;
            int[] array62 = new int[4];
            array62[0] = 40;
            nudBrustPeriodicity6.Value = new decimal(array62);
            m_nudBrustPeriodicity2.ValueChanged += m_nudSubFrameBurst2Periodicity_ValueChanged;
            m_nudNumOfLoops2.Location = new Point(327, 154);
            m_nudNumOfLoops2.Margin = new Padding(4);
            NumericUpDown nudNumOfLoops7 = m_nudNumOfLoops2;
            int[] array63 = new int[4];
            array63[0] = 255;
            nudNumOfLoops7.Maximum = new decimal(array63);
            NumericUpDown nudNumOfLoops8 = m_nudNumOfLoops2;
            int[] array64 = new int[4];
            array64[0] = 1;
            nudNumOfLoops8.Minimum = new decimal(array64);
            m_nudNumOfLoops2.Name = "m_nudNumOfLoops2";
            m_nudNumOfLoops2.Size = new Size(108, 22);
            m_nudNumOfLoops2.TabIndex = 26;
            NumericUpDown nudNumOfLoops9 = m_nudNumOfLoops2;
            int[] array65 = new int[4];
            array65[0] = 128;
            nudNumOfLoops9.Value = new decimal(array65);
            m_nudNumOfLoops2.ValueChanged += m_nudNumOfLoops2_ValueChanged;
            m_nudNumOfChirps2.Location = new Point(327, 123);
            m_nudNumOfChirps2.Margin = new Padding(4);
            NumericUpDown nudNumOfChirps7 = m_nudNumOfChirps2;
            int[] array66 = new int[4];
            array66[0] = 512;
            nudNumOfChirps7.Maximum = new decimal(array66);
            NumericUpDown nudNumOfChirps8 = m_nudNumOfChirps2;
            int[] array67 = new int[4];
            array67[0] = 1;
            nudNumOfChirps8.Minimum = new decimal(array67);
            m_nudNumOfChirps2.Name = "m_nudNumOfChirps2";
            m_nudNumOfChirps2.Size = new Size(108, 22);
            m_nudNumOfChirps2.TabIndex = 25;
            NumericUpDown nudNumOfChirps9 = m_nudNumOfChirps2;
            int[] array68 = new int[4];
            array68[0] = 1;
            nudNumOfChirps9.Value = new decimal(array68);
            m_nudNumOfChirps2.ValueChanged += m_nudNumOfChirps2_ValueChanged;
            m_nudChirpStartIdx2.Location = new Point(327, 92);
            m_nudChirpStartIdx2.Margin = new Padding(4);
            NumericUpDown nudChirpStartIdx3 = m_nudChirpStartIdx2;
            int[] array69 = new int[4];
            array69[0] = 511;
            nudChirpStartIdx3.Maximum = new decimal(array69);
            m_nudChirpStartIdx2.Name = "m_nudChirpStartIdx2";
            m_nudChirpStartIdx2.Size = new Size(108, 22);
            m_nudChirpStartIdx2.TabIndex = 24;
            m_nudChirpStartIdx2.ValueChanged += m_nudChirpStartIdx2_ValueChanged;
            m_nudForceProfileIdx2.Location = new Point(327, 62);
            m_nudForceProfileIdx2.Margin = new Padding(4);
            NumericUpDown nudForceProfileIdx3 = m_nudForceProfileIdx2;
            int[] array70 = new int[4];
            array70[0] = 3;
            nudForceProfileIdx3.Maximum = new decimal(array70);
            m_nudForceProfileIdx2.Name = "m_nudForceProfileIdx2";
            m_nudForceProfileIdx2.Size = new Size(108, 22);
            m_nudForceProfileIdx2.TabIndex = 23;
            label4.AutoSize = true;
            label4.Location = new Point(632, 25);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(81, 17);
            label4.TabIndex = 22;
            label4.Text = "SubFrame4";
            label3.AutoSize = true;
            label3.Location = new Point(475, 25);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(81, 17);
            label3.TabIndex = 21;
            label3.Text = "SubFrame3";
            label2.AutoSize = true;
            label2.Location = new Point(327, 25);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(81, 17);
            label2.TabIndex = 20;
            label2.Text = "SubFrame2";
            label1.AutoSize = true;
            label1.Location = new Point(168, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(81, 17);
            label1.TabIndex = 19;
            label1.Text = "SubFrame1";
            m_nudSubFramePeriod.DecimalPlaces = 6;
            m_nudSubFramePeriod.Increment = new decimal(new int[]
            {
                5,
                0,
                0,
                327680
            });
            m_nudSubFramePeriod.Location = new Point(165, 308);
            m_nudSubFramePeriod.Margin = new Padding(4);
            NumericUpDown nudSubFramePeriod7 = m_nudSubFramePeriod;
            int[] array71 = new int[4];
            array71[0] = 1342;
            nudSubFramePeriod7.Maximum = new decimal(array71);
            m_nudSubFramePeriod.Name = "m_nudSubFramePeriod";
            m_nudSubFramePeriod.Size = new Size(111, 22);
            m_nudSubFramePeriod.TabIndex = 18;
            NumericUpDown nudSubFramePeriod8 = m_nudSubFramePeriod;
            int[] array72 = new int[4];
            array72[0] = 40;
            nudSubFramePeriod8.Value = new decimal(array72);
            m_nudSubFramePeriod.ValueChanged += m_nudSubFrame1Periodicity_ValueChanged;
            m_nudSubFramePeriodicity.AutoSize = true;
            m_nudSubFramePeriodicity.Location = new Point(16, 308);
            m_nudSubFramePeriodicity.Margin = new Padding(4, 0, 4, 0);
            m_nudSubFramePeriodicity.Name = "m_nudSubFramePeriodicity";
            m_nudSubFramePeriodicity.Size = new Size(146, 17);
            m_nudSubFramePeriodicity.TabIndex = 17;
            m_nudSubFramePeriodicity.Text = "SubFramePeriod (ms)";
            m_nudNumOfBrustLoops.Location = new Point(168, 277);
            m_nudNumOfBrustLoops.Margin = new Padding(4);
            NumericUpDown nudNumOfBrustLoops10 = m_nudNumOfBrustLoops;
            int[] array73 = new int[4];
            array73[0] = 64;
            nudNumOfBrustLoops10.Maximum = new decimal(array73);
            NumericUpDown nudNumOfBrustLoops11 = m_nudNumOfBrustLoops;
            int[] array74 = new int[4];
            array74[0] = 1;
            nudNumOfBrustLoops11.Minimum = new decimal(array74);
            m_nudNumOfBrustLoops.Name = "m_nudNumOfBrustLoops";
            m_nudNumOfBrustLoops.Size = new Size(108, 22);
            m_nudNumOfBrustLoops.TabIndex = 16;
            NumericUpDown nudNumOfBrustLoops12 = m_nudNumOfBrustLoops;
            int[] array75 = new int[4];
            array75[0] = 1;
            nudNumOfBrustLoops12.Value = new decimal(array75);
            m_nudNumOfBrust.Location = new Point(168, 246);
            m_nudNumOfBrust.Margin = new Padding(4);
            NumericUpDown nudNumOfBrust10 = m_nudNumOfBrust;
            int[] array76 = new int[4];
            array76[0] = 512;
            nudNumOfBrust10.Maximum = new decimal(array76);
            NumericUpDown nudNumOfBrust11 = m_nudNumOfBrust;
            int[] array77 = new int[4];
            array77[0] = 1;
            nudNumOfBrust11.Minimum = new decimal(array77);
            m_nudNumOfBrust.Name = "m_nudNumOfBrust";
            m_nudNumOfBrust.Size = new Size(108, 22);
            m_nudNumOfBrust.TabIndex = 15;
            NumericUpDown nudNumOfBrust12 = m_nudNumOfBrust;
            int[] array78 = new int[4];
            array78[0] = 1;
            nudNumOfBrust12.Value = new decimal(array78);
            m_nudChirpStartIdxOffset.Location = new Point(168, 215);
            m_nudChirpStartIdxOffset.Margin = new Padding(4);
            NumericUpDown nudChirpStartIdxOffset4 = m_nudChirpStartIdxOffset;
            int[] array79 = new int[4];
            array79[0] = 511;
            nudChirpStartIdxOffset4.Maximum = new decimal(array79);
            m_nudChirpStartIdxOffset.Name = "m_nudChirpStartIdxOffset";
            m_nudChirpStartIdxOffset.Size = new Size(108, 22);
            m_nudChirpStartIdxOffset.TabIndex = 14;
            m_nudBrustPeriodicity.DecimalPlaces = 6;
            m_nudBrustPeriodicity.Increment = new decimal(new int[]
            {
                5,
                0,
                0,
                327680
            });
            m_nudBrustPeriodicity.Location = new Point(168, 185);
            m_nudBrustPeriodicity.Margin = new Padding(4);
            NumericUpDown nudBrustPeriodicity7 = m_nudBrustPeriodicity;
            int[] array80 = new int[4];
            array80[0] = 1342;
            nudBrustPeriodicity7.Maximum = new decimal(array80);
            m_nudBrustPeriodicity.Name = "m_nudBrustPeriodicity";
            m_nudBrustPeriodicity.Size = new Size(108, 22);
            m_nudBrustPeriodicity.TabIndex = 13;
            NumericUpDown nudBrustPeriodicity8 = m_nudBrustPeriodicity;
            int[] array81 = new int[4];
            array81[0] = 40;
            nudBrustPeriodicity8.Value = new decimal(array81);
            m_nudBrustPeriodicity.ValueChanged += m_nudSubFrameBurst1Periodicity_ValueChanged;
            m_nudNumOfLoops.Location = new Point(168, 154);
            m_nudNumOfLoops.Margin = new Padding(4);
            NumericUpDown nudNumOfLoops10 = m_nudNumOfLoops;
            int[] array82 = new int[4];
            array82[0] = 255;
            nudNumOfLoops10.Maximum = new decimal(array82);
            NumericUpDown nudNumOfLoops11 = m_nudNumOfLoops;
            int[] array83 = new int[4];
            array83[0] = 1;
            nudNumOfLoops11.Minimum = new decimal(array83);
            m_nudNumOfLoops.Name = "m_nudNumOfLoops";
            m_nudNumOfLoops.Size = new Size(108, 22);
            m_nudNumOfLoops.TabIndex = 12;
            NumericUpDown nudNumOfLoops12 = m_nudNumOfLoops;
            int[] array84 = new int[4];
            array84[0] = 128;
            nudNumOfLoops12.Value = new decimal(array84);
            m_nudNumOfLoops.ValueChanged += m_nudNumOfLoops_ValueChanged;
            m_nudNumOfChirps.Location = new Point(168, 123);
            m_nudNumOfChirps.Margin = new Padding(4);
            NumericUpDown nudNumOfChirps10 = m_nudNumOfChirps;
            int[] array85 = new int[4];
            array85[0] = 512;
            nudNumOfChirps10.Maximum = new decimal(array85);
            NumericUpDown nudNumOfChirps11 = m_nudNumOfChirps;
            int[] array86 = new int[4];
            array86[0] = 1;
            nudNumOfChirps11.Minimum = new decimal(array86);
            m_nudNumOfChirps.Name = "m_nudNumOfChirps";
            m_nudNumOfChirps.Size = new Size(108, 22);
            m_nudNumOfChirps.TabIndex = 11;
            NumericUpDown nudNumOfChirps12 = m_nudNumOfChirps;
            int[] array87 = new int[4];
            array87[0] = 1;
            nudNumOfChirps12.Value = new decimal(array87);
            m_nudNumOfChirps.ValueChanged += m_nudNumOfChirps_ValueChanged;
            m_nudChirpStartIdx.Location = new Point(168, 92);
            m_nudChirpStartIdx.Margin = new Padding(4);
            NumericUpDown nudChirpStartIdx4 = m_nudChirpStartIdx;
            int[] array88 = new int[4];
            array88[0] = 511;
            nudChirpStartIdx4.Maximum = new decimal(array88);
            m_nudChirpStartIdx.Name = "m_nudChirpStartIdx";
            m_nudChirpStartIdx.Size = new Size(108, 22);
            m_nudChirpStartIdx.TabIndex = 10;
            m_nudChirpStartIdx.ValueChanged += m_nudChirpStartIdx_ValueChanged;
            m_nudForceProfileIdx.Location = new Point(168, 62);
            m_nudForceProfileIdx.Margin = new Padding(4);
            NumericUpDown nudForceProfileIdx4 = m_nudForceProfileIdx;
            int[] array89 = new int[4];
            array89[0] = 3;
            nudForceProfileIdx4.Maximum = new decimal(array89);
            m_nudForceProfileIdx.Name = "m_nudForceProfileIdx";
            m_nudForceProfileIdx.Size = new Size(108, 22);
            m_nudForceProfileIdx.TabIndex = 9;
            label9.AutoSize = true;
            label9.Location = new Point(16, 246);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(70, 17);
            label9.TabIndex = 7;
            label9.Text = "NumBurst";
            label10.AutoSize = true;
            label10.Location = new Point(16, 277);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(109, 17);
            label10.TabIndex = 6;
            label10.Text = "NumBurstLoops";
            label17.AutoSize = true;
            label17.Location = new Point(16, 185);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(114, 17);
            label17.TabIndex = 5;
            label17.Text = "BurstPeriod (ms)";
            label18.AutoSize = true;
            label18.Location = new Point(16, 215);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(126, 17);
            label18.TabIndex = 4;
            label18.Text = "ChirpStartIdxOffset";
            label19.AutoSize = true;
            label19.Location = new Point(16, 123);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(77, 17);
            label19.TabIndex = 3;
            label19.Text = "NumChirps";
            label20.AutoSize = true;
            label20.Location = new Point(16, 154);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(76, 17);
            label20.TabIndex = 2;
            label20.Text = "NumLoops";
            label21.AutoSize = true;
            label21.Location = new Point(16, 91);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(88, 17);
            label21.TabIndex = 1;
            label21.Text = "ChirpStartIdx";
            label22.AutoSize = true;
            label22.Location = new Point(16, 62);
            label22.Margin = new Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new Size(101, 17);
            label22.TabIndex = 0;
            label22.Text = "ForceProfileIdx";
            m_nudFrameTriggerDelay.DecimalPlaces = 2;
            m_nudFrameTriggerDelay.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            m_nudFrameTriggerDelay.Location = new Point(184, 123);
            m_nudFrameTriggerDelay.Margin = new Padding(4);
            NumericUpDown nudFrameTriggerDelay = m_nudFrameTriggerDelay;
            int[] array90 = new int[4];
            array90[0] = 20000;
            nudFrameTriggerDelay.Maximum = new decimal(array90);
            m_nudFrameTriggerDelay.Name = "m_nudFrameTriggerDelay";
            m_nudFrameTriggerDelay.Size = new Size(108, 22);
            m_nudFrameTriggerDelay.TabIndex = 14;
            m_nudFrameTriggerDelay.ValueChanged += m_nudAdvancedFrameTriggerDelay_ValueChanged;
            m_nudNumOfFrames.Location = new Point(184, 20);
            m_nudNumOfFrames.Margin = new Padding(4);
            NumericUpDown nudNumOfFrames = m_nudNumOfFrames;
            int[] array91 = new int[4];
            array91[0] = 65535;
            nudNumOfFrames.Maximum = new decimal(array91);
            m_nudNumOfFrames.Name = "m_nudNumOfFrames";
            m_nudNumOfFrames.Size = new Size(108, 22);
            m_nudNumOfFrames.TabIndex = 12;
            m_nudNumOfSubFrames.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            m_nudNumOfSubFrames.Location = new Point(184, 55);
            m_nudNumOfSubFrames.Margin = new Padding(4);
            NumericUpDown nudNumOfSubFrames = m_nudNumOfSubFrames;
            int[] array92 = new int[4];
            array92[0] = 4;
            nudNumOfSubFrames.Maximum = new decimal(array92);
            NumericUpDown nudNumOfSubFrames2 = m_nudNumOfSubFrames;
            int[] array93 = new int[4];
            array93[0] = 1;
            nudNumOfSubFrames2.Minimum = new decimal(array93);
            m_nudNumOfSubFrames.Name = "m_nudNumOfSubFrames";
            m_nudNumOfSubFrames.Size = new Size(108, 25);
            m_nudNumOfSubFrames.TabIndex = 9;
            NumericUpDown nudNumOfSubFrames3 = m_nudNumOfSubFrames;
            int[] array94 = new int[4];
            array94[0] = 1;
            nudNumOfSubFrames3.Value = new decimal(array94);
            m_nudNumOfSubFrames.ValueChanged += m_nudNumOfSubFrames_ValueChanged;
            m_btnAdvFrameConfig.Location = new Point(669, 635);
            m_btnAdvFrameConfig.Margin = new Padding(4);
            m_btnAdvFrameConfig.Name = "m_btnAdvFrameConfig";
            m_btnAdvFrameConfig.Size = new Size(111, 33);
            m_btnAdvFrameConfig.TabIndex = 8;
            m_btnAdvFrameConfig.Text = "Set";
            m_btnAdvFrameConfig.UseVisualStyleBackColor = true;
            m_btnAdvFrameConfig.Click += m_btnAdvFrameConfig_Click;
            label11.AutoSize = true;
            label11.Location = new Point(23, 89);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(93, 17);
            label11.TabIndex = 5;
            label11.Text = "TriggerSelect";
            label12.AutoSize = true;
            label12.Location = new Point(23, 123);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(119, 17);
            label12.TabIndex = 4;
            label12.Text = "TriggerDelay (µs)";
            label14.AutoSize = true;
            label14.Location = new Point(23, 20);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(84, 17);
            label14.TabIndex = 2;
            label14.Text = "NumFrames";
            label16.AutoSize = true;
            label16.Location = new Point(23, 55);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(109, 17);
            label16.TabIndex = 0;
            label16.Text = "NumSubFrames";
            groupBox1.Controls.Add(m_CbRFGainTarget);
            groupBox1.Controls.Add(f0000fe);
            groupBox1.Controls.Add(m_btnLoopBackBurstConfig);
            groupBox1.Controls.Add(label40);
            groupBox1.Controls.Add(label39);
            groupBox1.Controls.Add(label38);
            groupBox1.Controls.Add(label37);
            groupBox1.Controls.Add(label36);
            groupBox1.Controls.Add(label35);
            groupBox1.Controls.Add(label34);
            groupBox1.Controls.Add(label33);
            groupBox1.Controls.Add(label32);
            groupBox1.Controls.Add(f0000fd);
            groupBox1.Controls.Add(label31);
            groupBox1.Controls.Add(f0000f2);
            groupBox1.Controls.Add(f0000f3);
            groupBox1.Controls.Add(m_chLPBDigCorrRxGainPhase);
            groupBox1.Controls.Add(m_chLPBDigitalCorrDisable);
            groupBox1.Controls.Add(f0000f4);
            groupBox1.Controls.Add(f0000f5);
            groupBox1.Controls.Add(f0000f6);
            groupBox1.Controls.Add(f0000f7);
            groupBox1.Controls.Add(f0000f8);
            groupBox1.Controls.Add(f0000f9);
            groupBox1.Controls.Add(m_chLPBTx3Enable);
            groupBox1.Controls.Add(m_chLPBTx2Enable);
            groupBox1.Controls.Add(m_chLPBTx1Enable);
            groupBox1.Controls.Add(f0000fa);
            groupBox1.Controls.Add(f0000fb);
            groupBox1.Controls.Add(f0000fc);
            groupBox1.Controls.Add(m_nudLPBRxGain);
            groupBox1.Controls.Add(m_nudLPBTx3BackOff);
            groupBox1.Controls.Add(m_nudLPBTx2BackOff);
            groupBox1.Controls.Add(m_nudLPBTx1BackOff);
            groupBox1.Controls.Add(m_nudLPBSlopeConst);
            groupBox1.Controls.Add(m_nudLPBFreqConst);
            groupBox1.Controls.Add(m_nudLPBBusrtIndex);
            groupBox1.Controls.Add(m_nudLPBBaseProfileIndex);
            groupBox1.Controls.Add(m_CbLoopBackSelect);
            groupBox1.Controls.Add(label30);
            groupBox1.Controls.Add(label29);
            groupBox1.Controls.Add(label28);
            groupBox1.Controls.Add(label27);
            groupBox1.Controls.Add(label26);
            groupBox1.Controls.Add(label25);
            groupBox1.Controls.Add(label24);
            groupBox1.Controls.Add(label23);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(841, 16);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(497, 654);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "LoopBack Burst Configuration";
            m_CbRFGainTarget.DropDownStyle = ComboBoxStyle.DropDownList;
            m_CbRFGainTarget.FormattingEnabled = true;
            m_CbRFGainTarget.Items.AddRange(new object[]
            {
                "30 dB",
                "34 dB",
                "26 dB"
            });
            m_CbRFGainTarget.Location = new Point(337, 282);
            m_CbRFGainTarget.Margin = new Padding(4);
            m_CbRFGainTarget.Name = "m_CbRFGainTarget";
            m_CbRFGainTarget.Size = new Size(88, 24);
            m_CbRFGainTarget.TabIndex = 53;
            f0000fe.Location = new Point(187, 530);
            f0000fe.Margin = new Padding(4);
            NumericUpDown numericUpDown = f0000fe;
            int[] array95 = new int[4];
            array95[0] = 65535;
            numericUpDown.Maximum = new decimal(array95);
            f0000fe.Name = "m_nudLPBPALoopBackFreq";
            f0000fe.Size = new Size(95, 22);
            f0000fe.TabIndex = 52;
            NumericUpDown numericUpDown2 = f0000fe;
            int[] array96 = new int[4];
            array96[0] = 2;
            numericUpDown2.Value = new decimal(array96);
            m_btnLoopBackBurstConfig.Location = new Point(383, 614);
            m_btnLoopBackBurstConfig.Margin = new Padding(4);
            m_btnLoopBackBurstConfig.Name = "m_btnLoopBackBurstConfig";
            m_btnLoopBackBurstConfig.Size = new Size(100, 28);
            m_btnLoopBackBurstConfig.TabIndex = 51;
            m_btnLoopBackBurstConfig.Text = "Set";
            m_btnLoopBackBurstConfig.UseVisualStyleBackColor = true;
            m_btnLoopBackBurstConfig.Click += m_btnLoopBackBurstConfig_Click;
            label40.AutoSize = true;
            label40.Location = new Point(329, 561);
            label40.Margin = new Padding(4, 0, 4, 0);
            label40.Name = "label40";
            label40.Size = new Size(31, 17);
            label40.TabIndex = 50;
            label40.Text = "Tx1";
            label39.AutoSize = true;
            label39.Location = new Point(211, 561);
            label39.Margin = new Padding(4, 0, 4, 0);
            label39.Name = "label39";
            label39.Size = new Size(31, 17);
            label39.TabIndex = 49;
            label39.Text = "Tx0";
            label38.AutoSize = true;
            label38.Location = new Point(331, 262);
            label38.Margin = new Padding(4, 0, 4, 0);
            label38.Name = "label38";
            label38.Size = new Size(106, 17);
            label38.TabIndex = 48;
            label38.Text = "RF Gain Target";
            label37.AutoSize = true;
            label37.Location = new Point(187, 262);
            label37.Margin = new Padding(4, 0, 4, 0);
            label37.Name = "label37";
            label37.Size = new Size(58, 17);
            label37.TabIndex = 47;
            label37.Text = "Rx Gain";
            label36.AutoSize = true;
            label36.Location = new Point(384, 176);
            label36.Margin = new Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new Size(31, 17);
            label36.TabIndex = 46;
            label36.Text = "Tx2";
            label35.AutoSize = true;
            label35.Location = new Point(292, 176);
            label35.Margin = new Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new Size(31, 17);
            label35.TabIndex = 45;
            label35.Text = "Tx1";
            label34.AutoSize = true;
            label34.Location = new Point(209, 176);
            label34.Margin = new Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new Size(31, 17);
            label34.TabIndex = 44;
            label34.Text = "Tx0";
            label33.AutoSize = true;
            label33.Location = new Point(5, 533);
            label33.Margin = new Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new Size(168, 17);
            label33.TabIndex = 42;
            label33.Text = "PA LoopBack Freq (MHz)";
            label32.AutoSize = true;
            label32.Location = new Point(5, 583);
            label32.Margin = new Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new Size(164, 17);
            label32.TabIndex = 41;
            label32.Text = "PS LoopBack Freq (kHz)";
            f0000fd.DropDownStyle = ComboBoxStyle.DropDownList;
            f0000fd.FormattingEnabled = true;
            f0000fd.Items.AddRange(new object[]
            {
                "OFF",
                "-22 dB",
                "-16 dB",
                "-15 dB",
                "-14 dB",
                "-13 dB",
                "-12 dB",
                "-11 dB",
                "-10 dB",
                "-9 dB",
                "-8 dB",
                "-7 dB",
                "-6 dB",
                "-5 dB",
                "-4 dB",
                "-3 dB",
                "-2 dB",
                "-1 dB",
                "0 dB",
                "1 dB",
                "2 dB",
                "3 dB",
                "4 dB",
                "5 dB",
                "6 dB",
                "7 dB",
                "8 dB",
                "9 dB"
            });
            f0000fd.Location = new Point(187, 498);
            f0000fd.Margin = new Padding(4);
            f0000fd.Name = "m_CbLPBPS2PGAGainIndex";
            f0000fd.Size = new Size(93, 24);
            f0000fd.TabIndex = 40;
            label31.AutoSize = true;
            label31.Location = new Point(5, 503);
            label31.Margin = new Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new Size(138, 17);
            label31.TabIndex = 39;
            label31.Text = "PS2 PGA Gain Index";
            f0000f2.DropDownStyle = ComboBoxStyle.DropDownList;
            f0000f2.FormattingEnabled = true;
            f0000f2.Items.AddRange(new object[]
            {
                "OFF",
                "-22 dB",
                "-16 dB",
                "-15 dB",
                "-14 dB",
                "-13 dB",
                "-12 dB",
                "-11 dB",
                "-10 dB",
                "-9 dB",
                "-8 dB",
                "-7 dB",
                "-6 dB",
                "-5 dB",
                "-4 dB",
                "-3 dB",
                "-2 dB",
                "-1 dB",
                "0 dB",
                "1 dB",
                "2 dB",
                "3 dB",
                "4 dB",
                "5 dB",
                "6 dB",
                "7 dB",
                "8 dB",
                "9 dB"
            });
            f0000f2.Location = new Point(187, 466);
            f0000f2.Margin = new Padding(4);
            f0000f2.Name = "m_CbLPBPS1PGAGainIndex";
            f0000f2.Size = new Size(93, 24);
            f0000f2.TabIndex = 38;
            f0000f3.DropDownStyle = ComboBoxStyle.DropDownList;
            f0000f3.FormattingEnabled = true;
            f0000f3.Items.AddRange(new object[]
            {
                "180 kHz",
                "240 kHz",
                "360 kHz",
                "720 kHz",
                "1 MHz",
                "2 MHz",
                "2.5 MHz",
                "3 MHz",
                "4.02 MHz",
                "5 MHz",
                "6 MHz",
                "8.03 MHz",
                "9 MHz",
                "10 MHz",
                ""
            });
            f0000f3.Location = new Point(187, 400);
            f0000f3.Margin = new Padding(4);
            f0000f3.Name = "m_CbLPBIFlLoopBackFreq";
            f0000f3.Size = new Size(93, 24);
            f0000f3.TabIndex = 37;
            m_chLPBDigCorrRxGainPhase.AutoSize = true;
            m_chLPBDigCorrRxGainPhase.Location = new Point(287, 370);
            m_chLPBDigCorrRxGainPhase.Margin = new Padding(4);
            m_chLPBDigCorrRxGainPhase.Name = "m_chLPBDigCorrRxGainPhase";
            m_chLPBDigCorrRxGainPhase.Size = new Size(149, 21);
            m_chLPBDigCorrRxGainPhase.TabIndex = 36;
            m_chLPBDigCorrRxGainPhase.Text = "RxGain And Phase";
            m_chLPBDigCorrRxGainPhase.UseVisualStyleBackColor = true;
            m_chLPBDigitalCorrDisable.AutoSize = true;
            m_chLPBDigitalCorrDisable.Location = new Point(187, 369);
            m_chLPBDigitalCorrDisable.Margin = new Padding(4);
            m_chLPBDigitalCorrDisable.Name = "m_chLPBDigitalCorrDisable";
            m_chLPBDigitalCorrDisable.Size = new Size(66, 21);
            m_chLPBDigitalCorrDisable.TabIndex = 35;
            m_chLPBDigitalCorrDisable.Text = "IQMM";
            m_chLPBDigitalCorrDisable.UseVisualStyleBackColor = true;
            f0000f4.AutoSize = true;
            f0000f4.Location = new Point(388, 342);
            f0000f4.Margin = new Padding(4);
            f0000f4.Name = "m_chLPBBPMTx2On";
            f0000f4.Size = new Size(76, 21);
            f0000f4.TabIndex = 34;
            f0000f4.Text = "Tx2 On";
            f0000f4.UseVisualStyleBackColor = true;
            f0000f5.AutoSize = true;
            f0000f5.Location = new Point(285, 341);
            f0000f5.Margin = new Padding(4);
            f0000f5.Name = "m_chLPBBPMTx2Off";
            f0000f5.Size = new Size(76, 21);
            f0000f5.TabIndex = 33;
            f0000f5.Text = "Tx2 Off";
            f0000f5.UseVisualStyleBackColor = true;
            f0000f6.AutoSize = true;
            f0000f6.Location = new Point(187, 341);
            f0000f6.Margin = new Padding(4);
            f0000f6.Name = "m_chLPBBPMTx1On";
            f0000f6.Size = new Size(76, 21);
            f0000f6.TabIndex = 32;
            f0000f6.Text = "Tx1 On";
            f0000f6.UseVisualStyleBackColor = true;
            f0000f7.AutoSize = true;
            f0000f7.Location = new Point(388, 315);
            f0000f7.Margin = new Padding(4);
            f0000f7.Name = "m_chLPBBPMTx1Off";
            f0000f7.Size = new Size(76, 21);
            f0000f7.TabIndex = 31;
            f0000f7.Text = "Tx1 Off";
            f0000f7.UseVisualStyleBackColor = true;
            f0000f8.AutoSize = true;
            f0000f8.Location = new Point(285, 314);
            f0000f8.Margin = new Padding(4);
            f0000f8.Name = "m_chLPBBPMTx0On";
            f0000f8.Size = new Size(76, 21);
            f0000f8.TabIndex = 30;
            f0000f8.Text = "Tx0 On";
            f0000f8.UseVisualStyleBackColor = true;
            f0000f9.AutoSize = true;
            f0000f9.Location = new Point(187, 314);
            f0000f9.Margin = new Padding(4);
            f0000f9.Name = "m_chLPBBPMTx0Off";
            f0000f9.Size = new Size(76, 21);
            f0000f9.TabIndex = 29;
            f0000f9.Text = "Tx0 Off";
            f0000f9.UseVisualStyleBackColor = true;
            m_chLPBTx3Enable.AutoSize = true;
            m_chLPBTx3Enable.Location = new Point(388, 238);
            m_chLPBTx3Enable.Margin = new Padding(4);
            m_chLPBTx3Enable.Name = "m_chLPBTx3Enable";
            m_chLPBTx3Enable.Size = new Size(18, 17);
            m_chLPBTx3Enable.TabIndex = 28;
            m_chLPBTx3Enable.UseVisualStyleBackColor = true;
            m_chLPBTx2Enable.AutoSize = true;
            m_chLPBTx2Enable.Location = new Point(291, 238);
            m_chLPBTx2Enable.Margin = new Padding(4);
            m_chLPBTx2Enable.Name = "m_chLPBTx2Enable";
            m_chLPBTx2Enable.Size = new Size(18, 17);
            m_chLPBTx2Enable.TabIndex = 27;
            m_chLPBTx2Enable.UseVisualStyleBackColor = true;
            m_chLPBTx1Enable.AutoSize = true;
            m_chLPBTx1Enable.Location = new Point(187, 238);
            m_chLPBTx1Enable.Margin = new Padding(4);
            m_chLPBTx1Enable.Name = "m_chLPBTx1Enable";
            m_chLPBTx1Enable.Size = new Size(18, 17);
            m_chLPBTx1Enable.TabIndex = 26;
            m_chLPBTx1Enable.UseVisualStyleBackColor = true;
            f0000fa.Location = new Point(187, 580);
            f0000fa.Margin = new Padding(4);
            NumericUpDown numericUpDown3 = f0000fa;
            int[] array97 = new int[4];
            array97[0] = 65535;
            numericUpDown3.Maximum = new decimal(array97);
            f0000fa.Name = "m_nudLPBPSTx0LoopBackFreq";
            f0000fa.Size = new Size(95, 22);
            f0000fa.TabIndex = 25;
            f0000fb.Location = new Point(324, 580);
            f0000fb.Margin = new Padding(4);
            NumericUpDown numericUpDown4 = f0000fb;
            int[] array98 = new int[4];
            array98[0] = 65535;
            numericUpDown4.Maximum = new decimal(array98);
            f0000fb.Name = "m_nudLPBPSTx1LoopBackFreq";
            f0000fb.Size = new Size(84, 22);
            f0000fb.TabIndex = 24;
            f0000fc.Location = new Point(187, 433);
            f0000fc.Margin = new Padding(4);
            NumericUpDown numericUpDown5 = f0000fc;
            int[] array99 = new int[4];
            array99[0] = 63;
            numericUpDown5.Maximum = new decimal(array99);
            NumericUpDown numericUpDown6 = f0000fc;
            int[] array100 = new int[4];
            array100[0] = 1;
            numericUpDown6.Minimum = new decimal(array100);
            f0000fc.Name = "m_nudLPBIFlLoopBackMag";
            f0000fc.Size = new Size(95, 22);
            f0000fc.TabIndex = 23;
            NumericUpDown numericUpDown7 = f0000fc;
            int[] array101 = new int[4];
            array101[0] = 2;
            numericUpDown7.Value = new decimal(array101);
            m_nudLPBRxGain.Location = new Point(187, 283);
            m_nudLPBRxGain.Margin = new Padding(4);
            NumericUpDown nudLPBRxGain = m_nudLPBRxGain;
            int[] array102 = new int[4];
            array102[0] = 52;
            nudLPBRxGain.Maximum = new decimal(array102);
            NumericUpDown nudLPBRxGain2 = m_nudLPBRxGain;
            int[] array103 = new int[4];
            array103[0] = 24;
            nudLPBRxGain2.Minimum = new decimal(array103);
            m_nudLPBRxGain.Name = "m_nudLPBRxGain";
            m_nudLPBRxGain.Size = new Size(85, 22);
            m_nudLPBRxGain.TabIndex = 21;
            NumericUpDown nudLPBRxGain3 = m_nudLPBRxGain;
            int[] array104 = new int[4];
            array104[0] = 30;
            nudLPBRxGain3.Value = new decimal(array104);
            m_nudLPBTx3BackOff.Location = new Point(383, 199);
            m_nudLPBTx3BackOff.Margin = new Padding(4);
            NumericUpDown nudLPBTx3BackOff = m_nudLPBTx3BackOff;
            int[] array105 = new int[4];
            array105[0] = 30;
            nudLPBTx3BackOff.Maximum = new decimal(array105);
            m_nudLPBTx3BackOff.Name = "m_nudLPBTx3BackOff";
            m_nudLPBTx3BackOff.Size = new Size(85, 22);
            m_nudLPBTx3BackOff.TabIndex = 20;
            m_nudLPBTx2BackOff.Location = new Point(288, 199);
            m_nudLPBTx2BackOff.Margin = new Padding(4);
            NumericUpDown nudLPBTx2BackOff = m_nudLPBTx2BackOff;
            int[] array106 = new int[4];
            array106[0] = 30;
            nudLPBTx2BackOff.Maximum = new decimal(array106);
            m_nudLPBTx2BackOff.Name = "m_nudLPBTx2BackOff";
            m_nudLPBTx2BackOff.Size = new Size(85, 22);
            m_nudLPBTx2BackOff.TabIndex = 19;
            m_nudLPBTx1BackOff.Location = new Point(187, 199);
            m_nudLPBTx1BackOff.Margin = new Padding(4);
            NumericUpDown nudLPBTx1BackOff = m_nudLPBTx1BackOff;
            int[] array107 = new int[4];
            array107[0] = 30;
            nudLPBTx1BackOff.Maximum = new decimal(array107);
            m_nudLPBTx1BackOff.Name = "m_nudLPBTx1BackOff";
            m_nudLPBTx1BackOff.Size = new Size(85, 22);
            m_nudLPBTx1BackOff.TabIndex = 18;
            m_nudLPBSlopeConst.DecimalPlaces = 3;
            m_nudLPBSlopeConst.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                196608
            });
            m_nudLPBSlopeConst.Location = new Point(187, 146);
            m_nudLPBSlopeConst.Margin = new Padding(4);
            NumericUpDown nudLPBSlopeConst = m_nudLPBSlopeConst;
            int[] array108 = new int[4];
            array108[0] = 327;
            nudLPBSlopeConst.Maximum = new decimal(array108);
            m_nudLPBSlopeConst.Minimum = new decimal(new int[]
            {
                327,
                0,
                0,
                int.MinValue
            });
            m_nudLPBSlopeConst.Name = "m_nudLPBSlopeConst";
            m_nudLPBSlopeConst.Size = new Size(112, 22);
            m_nudLPBSlopeConst.TabIndex = 17;
            m_nudLPBSlopeConst.ValueChanged += m_nudLoopBackBurstSlope_ValueChanged;
            m_nudLPBFreqConst.DecimalPlaces = 6;
            m_nudLPBFreqConst.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                393216
            });
            m_nudLPBFreqConst.Location = new Point(187, 114);
            m_nudLPBFreqConst.Margin = new Padding(4);
            NumericUpDown nudLPBFreqConst = m_nudLPBFreqConst;
            int[] array109 = new int[4];
            array109[0] = 81;
            nudLPBFreqConst.Maximum = new decimal(array109);
            m_nudLPBFreqConst.Name = "m_nudLPBFreqConst";
            m_nudLPBFreqConst.Size = new Size(112, 22);
            m_nudLPBFreqConst.TabIndex = 16;
            NumericUpDown nudLPBFreqConst2 = m_nudLPBFreqConst;
            int[] array110 = new int[4];
            array110[0] = 77;
            nudLPBFreqConst2.Value = new decimal(array110);
            m_nudLPBFreqConst.ValueChanged += m_nudLoopBackBurstStartFreqConst_ValueChanged;
            m_nudLPBBusrtIndex.Location = new Point(187, 84);
            m_nudLPBBusrtIndex.Margin = new Padding(4);
            NumericUpDown nudLPBBusrtIndex = m_nudLPBBusrtIndex;
            int[] array111 = new int[4];
            array111[0] = 15;
            nudLPBBusrtIndex.Maximum = new decimal(array111);
            m_nudLPBBusrtIndex.Name = "m_nudLPBBusrtIndex";
            m_nudLPBBusrtIndex.Size = new Size(112, 22);
            m_nudLPBBusrtIndex.TabIndex = 15;
            m_nudLPBBaseProfileIndex.Location = new Point(187, 53);
            m_nudLPBBaseProfileIndex.Margin = new Padding(4);
            NumericUpDown nudLPBBaseProfileIndex = m_nudLPBBaseProfileIndex;
            int[] array112 = new int[4];
            array112[0] = 3;
            nudLPBBaseProfileIndex.Maximum = new decimal(array112);
            m_nudLPBBaseProfileIndex.Name = "m_nudLPBBaseProfileIndex";
            m_nudLPBBaseProfileIndex.Size = new Size(112, 22);
            m_nudLPBBaseProfileIndex.TabIndex = 14;
            m_CbLoopBackSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            m_CbLoopBackSelect.FormattingEnabled = true;
            m_CbLoopBackSelect.Items.AddRange(new object[]
            {
                "No LoopBack",
                "IF LoopBack",
                "PS LoopBack",
                "PA LoopBack"
            });
            m_CbLoopBackSelect.Location = new Point(187, 20);
            m_CbLoopBackSelect.Margin = new Padding(4);
            m_CbLoopBackSelect.Name = "m_CbLoopBackSelect";
            m_CbLoopBackSelect.Size = new Size(113, 24);
            m_CbLoopBackSelect.TabIndex = 13;
            label30.AutoSize = true;
            label30.Location = new Point(5, 471);
            label30.Margin = new Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new Size(138, 17);
            label30.TabIndex = 12;
            label30.Text = "PS1 PGA Gain Index";
            label29.AutoSize = true;
            label29.Location = new Point(5, 438);
            label29.Margin = new Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new Size(167, 17);
            label29.TabIndex = 11;
            label29.Text = "IF LoopBack Mag (10mV)";
            label28.AutoSize = true;
            label28.Location = new Point(5, 400);
            label28.Margin = new Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new Size(119, 17);
            label28.TabIndex = 10;
            label28.Text = "IF LoopBack Freq";
            label27.AutoSize = true;
            label27.Location = new Point(5, 369);
            label27.Margin = new Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new Size(111, 17);
            label27.TabIndex = 9;
            label27.Text = "Dig Corr Disable";
            label26.AutoSize = true;
            label26.Location = new Point(5, 231);
            label26.Margin = new Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new Size(71, 17);
            label26.TabIndex = 8;
            label26.Text = "Tx Enable";
            label25.AutoSize = true;
            label25.Location = new Point(5, 314);
            label25.Margin = new Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new Size(79, 17);
            label25.TabIndex = 7;
            label25.Text = "BPM config";
            label24.AutoSize = true;
            label24.Location = new Point(5, 287);
            label24.Margin = new Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new Size(89, 17);
            label24.TabIndex = 6;
            label24.Text = "Rx Gain (dB)";
            label23.AutoSize = true;
            label23.Location = new Point(5, 202);
            label23.Margin = new Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new Size(108, 17);
            label23.TabIndex = 5;
            label23.Text = "Tx BackOff (dB)";
            label15.AutoSize = true;
            label15.Location = new Point(5, 153);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(176, 17);
            label15.TabIndex = 4;
            label15.Text = "Frequency Slope (MHz/µs)";
            label13.AutoSize = true;
            label13.Location = new Point(5, 118);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(113, 17);
            label13.TabIndex = 3;
            label13.Text = "Start Freq (GHz)";
            label8.AutoSize = true;
            label8.Location = new Point(5, 89);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(78, 17);
            label8.TabIndex = 2;
            label8.Text = "Burst Index";
            label7.AutoSize = true;
            label7.Location = new Point(5, 59);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(121, 17);
            label7.TabIndex = 1;
            label7.Text = "Base Profile Index";
            label6.AutoSize = true;
            label6.Location = new Point(5, 26);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(95, 17);
            label6.TabIndex = 0;
            label6.Text = "LoopBack Sel";
            groupBox4.Controls.Add(m_ChSubFrameStartConfig);
            groupBox4.Controls.Add(m_btnSoftwareSubFrameStartConfig);
            groupBox4.Controls.Add(label42);
            groupBox4.Location = new Point(1364, 16);
            groupBox4.Margin = new Padding(4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4);
            groupBox4.Size = new Size(247, 171);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "SubFrame Start Configuration";
            m_ChSubFrameStartConfig.AutoSize = true;
            m_ChSubFrameStartConfig.Checked = true;
            m_ChSubFrameStartConfig.CheckState = CheckState.Checked;
            m_ChSubFrameStartConfig.Location = new Point(180, 39);
            m_ChSubFrameStartConfig.Margin = new Padding(4);
            m_ChSubFrameStartConfig.Name = "m_ChSubFrameStartConfig";
            m_ChSubFrameStartConfig.Size = new Size(18, 17);
            m_ChSubFrameStartConfig.TabIndex = 2;
            m_ChSubFrameStartConfig.UseVisualStyleBackColor = true;
            m_btnSoftwareSubFrameStartConfig.Location = new Point(112, 110);
            m_btnSoftwareSubFrameStartConfig.Margin = new Padding(4);
            m_btnSoftwareSubFrameStartConfig.Name = "m_btnSoftwareSubFrameStartConfig";
            m_btnSoftwareSubFrameStartConfig.Size = new Size(100, 38);
            m_btnSoftwareSubFrameStartConfig.TabIndex = 1;
            m_btnSoftwareSubFrameStartConfig.Text = "Set";
            m_btnSoftwareSubFrameStartConfig.UseVisualStyleBackColor = true;
            m_btnSoftwareSubFrameStartConfig.Click += m_btnSoftwareSubFrameStartConfig_Click;
            label42.AutoSize = true;
            label42.Location = new Point(12, 39);
            label42.Margin = new Padding(4, 0, 4, 0);
            label42.Name = "label42";
            label42.Size = new Size(102, 17);
            label42.TabIndex = 0;
            label42.Text = "SubFrame Ena";
            m_grpAdvChirp.Controls.Add(m_btnAdvChirpConfig);
            m_grpAdvChirp.Controls.Add(m_nudFixedDeltaInc);
            m_grpAdvChirp.Controls.Add(label51);
            m_grpAdvChirp.Controls.Add(m_nudParamPeriod);
            m_grpAdvChirp.Controls.Add(label50);
            m_grpAdvChirp.Controls.Add(m_nudResetPeriod);
            m_grpAdvChirp.Controls.Add(label49);
            m_grpAdvChirp.Controls.Add(m_nudPatternMode);
            m_grpAdvChirp.Controls.Add(label48);
            m_grpAdvChirp.Controls.Add(m_nudResetMode);
            m_grpAdvChirp.Controls.Add(label47);
            m_grpAdvChirp.Controls.Add(m_nudChirpParamIdx);
            m_grpAdvChirp.Controls.Add(label46);
            m_grpAdvChirp.Location = new Point(1364, 208);
            m_grpAdvChirp.Margin = new Padding(4);
            m_grpAdvChirp.Name = "m_grpAdvChirp";
            m_grpAdvChirp.Padding = new Padding(4);
            m_grpAdvChirp.Size = new Size(247, 274);
            m_grpAdvChirp.TabIndex = 4;
            m_grpAdvChirp.TabStop = false;
            m_grpAdvChirp.Text = "Advance Chirp Configuration";
            m_btnAdvChirpConfig.Location = new Point(81, 222);
            m_btnAdvChirpConfig.Margin = new Padding(4);
            m_btnAdvChirpConfig.Name = "m_btnAdvChirpConfig";
            m_btnAdvChirpConfig.Size = new Size(100, 38);
            m_btnAdvChirpConfig.TabIndex = 3;
            m_btnAdvChirpConfig.Text = "Set";
            m_btnAdvChirpConfig.UseVisualStyleBackColor = true;
            m_btnAdvChirpConfig.Click += m_btnAdvChirpConfig_Click;
            m_nudFixedDeltaInc.DecimalPlaces = 7;
            m_nudFixedDeltaInc.Increment = new decimal(new int[]
            {
                53644,
                0,
                0,
                589824
            });
            m_nudFixedDeltaInc.Location = new Point(145, 188);
            m_nudFixedDeltaInc.Margin = new Padding(4);
            NumericUpDown nudFixedDeltaInc = m_nudFixedDeltaInc;
            int[] array113 = new int[4];
            array113[0] = 5000;
            nudFixedDeltaInc.Maximum = new decimal(array113);
            m_nudFixedDeltaInc.Minimum = new decimal(new int[]
            {
                5000,
                0,
                0,
                int.MinValue
            });
            m_nudFixedDeltaInc.Name = "m_nudFixedDeltaInc";
            m_nudFixedDeltaInc.Size = new Size(85, 22);
            m_nudFixedDeltaInc.TabIndex = 64;
            label51.AutoSize = true;
            label51.Location = new Point(8, 188);
            label51.Margin = new Padding(4, 0, 4, 0);
            label51.Name = "label51";
            label51.Size = new Size(138, 17);
            label51.TabIndex = 63;
            label51.Text = "Fixed Delta Inc(MHz)";
            m_nudParamPeriod.Location = new Point(145, 157);
            m_nudParamPeriod.Margin = new Padding(4);
            NumericUpDown nudParamPeriod = m_nudParamPeriod;
            int[] array114 = new int[4];
            array114[0] = 8192;
            nudParamPeriod.Maximum = new decimal(array114);
            m_nudParamPeriod.Name = "m_nudParamPeriod";
            m_nudParamPeriod.Size = new Size(85, 22);
            m_nudParamPeriod.TabIndex = 62;
            label50.AutoSize = true;
            label50.Location = new Point(13, 157);
            label50.Margin = new Padding(4, 0, 4, 0);
            label50.Name = "label50";
            label50.Size = new Size(118, 17);
            label50.TabIndex = 61;
            label50.Text = "Param Period (N)";
            m_nudResetPeriod.Location = new Point(145, 125);
            m_nudResetPeriod.Margin = new Padding(4);
            NumericUpDown nudResetPeriod = m_nudResetPeriod;
            int[] array115 = new int[4];
            array115[0] = 65535;
            nudResetPeriod.Maximum = new decimal(array115);
            m_nudResetPeriod.Name = "m_nudResetPeriod";
            m_nudResetPeriod.Size = new Size(85, 22);
            m_nudResetPeriod.TabIndex = 60;
            label49.AutoSize = true;
            label49.Location = new Point(13, 127);
            label49.Margin = new Padding(4, 0, 4, 0);
            label49.Name = "label49";
            label49.Size = new Size(115, 17);
            label49.TabIndex = 59;
            label49.Text = "Reset Period (M)";
            m_nudPatternMode.Location = new Point(145, 96);
            m_nudPatternMode.Margin = new Padding(4);
            NumericUpDown nudPatternMode = m_nudPatternMode;
            int[] array116 = new int[4];
            array116[0] = 255;
            nudPatternMode.Maximum = new decimal(array116);
            m_nudPatternMode.Name = "m_nudPatternMode";
            m_nudPatternMode.Size = new Size(85, 22);
            m_nudPatternMode.TabIndex = 58;
            label48.AutoSize = true;
            label48.Location = new Point(13, 97);
            label48.Margin = new Padding(4, 0, 4, 0);
            label48.Name = "label48";
            label48.Size = new Size(93, 17);
            label48.TabIndex = 57;
            label48.Text = "Pattern Mode";
            m_nudResetMode.Location = new Point(145, 66);
            m_nudResetMode.Margin = new Padding(4);
            NumericUpDown nudResetMode = m_nudResetMode;
            int[] array117 = new int[4];
            array117[0] = 255;
            nudResetMode.Maximum = new decimal(array117);
            m_nudResetMode.Name = "m_nudResetMode";
            m_nudResetMode.Size = new Size(85, 22);
            m_nudResetMode.TabIndex = 56;
            label47.AutoSize = true;
            label47.Location = new Point(13, 68);
            label47.Margin = new Padding(4, 0, 4, 0);
            label47.Name = "label47";
            label47.Size = new Size(84, 17);
            label47.TabIndex = 55;
            label47.Text = "Reset Mode";
            m_nudChirpParamIdx.Location = new Point(145, 36);
            m_nudChirpParamIdx.Margin = new Padding(4);
            NumericUpDown nudChirpParamIdx = m_nudChirpParamIdx;
            int[] array118 = new int[4];
            array118[0] = 65535;
            nudChirpParamIdx.Maximum = new decimal(array118);
            m_nudChirpParamIdx.Name = "m_nudChirpParamIdx";
            m_nudChirpParamIdx.Size = new Size(85, 22);
            m_nudChirpParamIdx.TabIndex = 54;
            label46.AutoSize = true;
            label46.Location = new Point(12, 39);
            label46.Margin = new Padding(4, 0, 4, 0);
            label46.Name = "label46";
            label46.Size = new Size(107, 17);
            label46.TabIndex = 0;
            label46.Text = "Chirp Param Idx";
            base.AutoScaleDimensions = new SizeF(8f, 16f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(m_grpAdvChirp);
            base.Controls.Add(groupBox4);
            base.Controls.Add(groupBox1);
            base.Controls.Add(groupBox2);
            base.Margin = new Padding(4);
            base.Name = "AdvanceFrameConfigTab";
            base.Size = new Size(1669, 692);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((ISupportInitialize)m_nudLoopBackCfgSubFrameID).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((ISupportInitialize)m_nudNoOfAdcSamples4).EndInit();
            ((ISupportInitialize)m_nudNoOfAdcSamples3).EndInit();
            ((ISupportInitialize)m_nudNoOfAdcSamples2).EndInit();
            ((ISupportInitialize)m_nudNoOfAdcSamples).EndInit();
            ((ISupportInitialize)m_nudSubFramePeriod4).EndInit();
            ((ISupportInitialize)m_nudNumOfBrustLoops4).EndInit();
            ((ISupportInitialize)m_nudNumOfBrust4).EndInit();
            ((ISupportInitialize)m_nudChirpStartIdxOffset4).EndInit();
            ((ISupportInitialize)m_nudBrustPeriodicity4).EndInit();
            ((ISupportInitialize)m_nudNumOfLoops4).EndInit();
            ((ISupportInitialize)m_nudNumOfChirps4).EndInit();
            ((ISupportInitialize)m_nudChirpStartIdx4).EndInit();
            ((ISupportInitialize)m_nudForceProfileIdx4).EndInit();
            ((ISupportInitialize)m_nudSubFramePeriod3).EndInit();
            ((ISupportInitialize)m_nudNumOfBrustLoops3).EndInit();
            ((ISupportInitialize)m_nudNumOfBrust3).EndInit();
            ((ISupportInitialize)m_nudChirpStartIdxOffset3).EndInit();
            ((ISupportInitialize)m_nudBrustPeriodicity3).EndInit();
            ((ISupportInitialize)m_nudNumOfLoops3).EndInit();
            ((ISupportInitialize)m_nudNumOfChirps3).EndInit();
            ((ISupportInitialize)m_nudChirpStartIdx3).EndInit();
            ((ISupportInitialize)m_nudForceProfileIdx3).EndInit();
            ((ISupportInitialize)m_nudSubFramePeriod2).EndInit();
            ((ISupportInitialize)m_nudNumOfBrustLoops2).EndInit();
            ((ISupportInitialize)m_nudNumOfBrust2).EndInit();
            ((ISupportInitialize)m_nudChirpStartIdxOffset2).EndInit();
            ((ISupportInitialize)m_nudBrustPeriodicity2).EndInit();
            ((ISupportInitialize)m_nudNumOfLoops2).EndInit();
            ((ISupportInitialize)m_nudNumOfChirps2).EndInit();
            ((ISupportInitialize)m_nudChirpStartIdx2).EndInit();
            ((ISupportInitialize)m_nudForceProfileIdx2).EndInit();
            ((ISupportInitialize)m_nudSubFramePeriod).EndInit();
            ((ISupportInitialize)m_nudNumOfBrustLoops).EndInit();
            ((ISupportInitialize)m_nudNumOfBrust).EndInit();
            ((ISupportInitialize)m_nudChirpStartIdxOffset).EndInit();
            ((ISupportInitialize)m_nudBrustPeriodicity).EndInit();
            ((ISupportInitialize)m_nudNumOfLoops).EndInit();
            ((ISupportInitialize)m_nudNumOfChirps).EndInit();
            ((ISupportInitialize)m_nudChirpStartIdx).EndInit();
            ((ISupportInitialize)m_nudForceProfileIdx).EndInit();
            ((ISupportInitialize)m_nudFrameTriggerDelay).EndInit();
            ((ISupportInitialize)m_nudNumOfFrames).EndInit();
            ((ISupportInitialize)m_nudNumOfSubFrames).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((ISupportInitialize)f0000fe).EndInit();
            ((ISupportInitialize)f0000fa).EndInit();
            ((ISupportInitialize)f0000fb).EndInit();
            ((ISupportInitialize)f0000fc).EndInit();
            ((ISupportInitialize)m_nudLPBRxGain).EndInit();
            ((ISupportInitialize)m_nudLPBTx3BackOff).EndInit();
            ((ISupportInitialize)m_nudLPBTx2BackOff).EndInit();
            ((ISupportInitialize)m_nudLPBTx1BackOff).EndInit();
            ((ISupportInitialize)m_nudLPBSlopeConst).EndInit();
            ((ISupportInitialize)m_nudLPBFreqConst).EndInit();
            ((ISupportInitialize)m_nudLPBBusrtIndex).EndInit();
            ((ISupportInitialize)m_nudLPBBaseProfileIndex).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            m_grpAdvChirp.ResumeLayout(false);
            m_grpAdvChirp.PerformLayout();
            ((ISupportInitialize)m_nudFixedDeltaInc).EndInit();
            ((ISupportInitialize)m_nudParamPeriod).EndInit();
            ((ISupportInitialize)m_nudResetPeriod).EndInit();
            ((ISupportInitialize)m_nudPatternMode).EndInit();
            ((ISupportInitialize)m_nudResetMode).EndInit();
            ((ISupportInitialize)m_nudChirpParamIdx).EndInit();
            base.ResumeLayout(false);
        }

        private GuiManager m_GuiManager = GlobalRef.GuiManager;
        private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;
        private frmAR1Main m_MainForm;
        public AdvancedFrameConfigParams m_AdvancedFrameConfigParams;
        public AdvChirpConfigParams m_AdvChirpConfigParams;
        public LoopBackBurstConfigParams m_LoopBackBurstConfigParams;
        public SWSubFrameStartStopConfigParams m_SWSubFrameStartStopConfigParams;
        private IContainer components;
        private GroupBox groupBox2;
        private NumericUpDown m_nudFrameTriggerDelay;
        private NumericUpDown m_nudNumOfFrames;
        private NumericUpDown m_nudNumOfSubFrames;
        private Button m_btnAdvFrameConfig;
        private Label label11;
        private Label label12;
        private Label label14;
        private Label label16;
        private GroupBox groupBox3;
        private NumericUpDown m_nudNumOfBrustLoops;
        private NumericUpDown m_nudNumOfBrust;
        private NumericUpDown m_nudChirpStartIdxOffset;
        private NumericUpDown m_nudBrustPeriodicity;
        private NumericUpDown m_nudNumOfLoops;
        private NumericUpDown m_nudNumOfChirps;
        private NumericUpDown m_nudChirpStartIdx;
        private NumericUpDown m_nudForceProfileIdx;
        private Label label9;
        private Label label10;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label m_nudSubFramePeriodicity;
        private NumericUpDown m_nudSubFramePeriod;
        private NumericUpDown m_nudSubFramePeriod4;
        private NumericUpDown m_nudNumOfBrustLoops4;
        private NumericUpDown m_nudNumOfBrust4;
        private NumericUpDown m_nudChirpStartIdxOffset4;
        private NumericUpDown m_nudBrustPeriodicity4;
        private NumericUpDown m_nudNumOfLoops4;
        private NumericUpDown m_nudNumOfChirps4;
        private NumericUpDown m_nudChirpStartIdx4;
        private NumericUpDown m_nudForceProfileIdx4;
        private NumericUpDown m_nudSubFramePeriod3;
        private NumericUpDown m_nudNumOfBrustLoops3;
        private NumericUpDown m_nudNumOfBrust3;
        private NumericUpDown m_nudChirpStartIdxOffset3;
        private NumericUpDown m_nudBrustPeriodicity3;
        private NumericUpDown m_nudNumOfLoops3;
        private NumericUpDown m_nudNumOfChirps3;
        private NumericUpDown m_nudChirpStartIdx3;
        private NumericUpDown m_nudForceProfileIdx3;
        private NumericUpDown m_nudSubFramePeriod2;
        private NumericUpDown m_nudNumOfBrustLoops2;
        private NumericUpDown m_nudNumOfBrust2;
        private NumericUpDown m_nudChirpStartIdxOffset2;
        private NumericUpDown m_nudBrustPeriodicity2;
        private NumericUpDown m_nudNumOfLoops2;
        private NumericUpDown m_nudNumOfChirps2;
        private NumericUpDown m_nudChirpStartIdx2;
        private NumericUpDown m_nudForceProfileIdx2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox m_ChkBxForceProfile;
        private NumericUpDown m_nudNoOfAdcSamples4;
        private NumericUpDown m_nudNoOfAdcSamples3;
        private NumericUpDown m_nudNoOfAdcSamples2;
        private NumericUpDown m_nudNoOfAdcSamples;
        private Label label5;
        private CheckBox m_chbAdvancedFrameTestSourceEnable;
        private RadioButton m_chbSelectHardwareTrigger;
        private RadioButton m_chbSelectSoftwareTrigger;
        private GroupBox groupBox1;
        private ComboBox m_CbLoopBackSelect;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label27;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label15;
        private Label label13;
        private Label label8;
        private Label label7;
        private Label label6;
        private NumericUpDown m_nudLPBBusrtIndex;
        private NumericUpDown m_nudLPBBaseProfileIndex;
        private Label label31;
        private ComboBox f0000f2;
        private ComboBox f0000f3;
        private CheckBox m_chLPBDigCorrRxGainPhase;
        private CheckBox m_chLPBDigitalCorrDisable;
        private CheckBox f0000f4;
        private CheckBox f0000f5;
        private CheckBox f0000f6;
        private CheckBox f0000f7;
        private CheckBox f0000f8;
        private CheckBox f0000f9;
        private CheckBox m_chLPBTx3Enable;
        private CheckBox m_chLPBTx2Enable;
        private CheckBox m_chLPBTx1Enable;
        private NumericUpDown f0000fa;
        private NumericUpDown f0000fb;
        private NumericUpDown f0000fc;
        private NumericUpDown m_nudLPBRxGain;
        private NumericUpDown m_nudLPBTx3BackOff;
        private NumericUpDown m_nudLPBTx2BackOff;
        private NumericUpDown m_nudLPBTx1BackOff;
        private NumericUpDown m_nudLPBSlopeConst;
        private NumericUpDown m_nudLPBFreqConst;
        private Label label33;
        private Label label32;
        private ComboBox f0000fd;
        private Label label36;
        private Label label35;
        private Label label34;
        private Label label38;
        private Label label37;
        private Label label40;
        private Label label39;
        private Button m_btnLoopBackBurstConfig;
        private NumericUpDown f0000fe;
        private ComboBox m_CbRFGainTarget;
        private CheckBox m_ChkBxLoopBackCfg;
        private NumericUpDown m_nudLoopBackCfgSubFrameID;
        private Label label41;
        private GroupBox groupBox4;
        private CheckBox m_ChSubFrameStartConfig;
        private Button m_btnSoftwareSubFrameStartConfig;
        private Label label42;
        private CheckBox m_ChkSWSubFrameTriggerCfg;
        private Label label43;
        private Label m_lblSubFrame4DutyCycle;
        private Label m_lblSubFrame3DutyCycle;
        private Label m_lblSubFrame2DutyCycle;
        private Label m_lblSubFrame1DutyCycle;
        private Label label44;
        private Label m_lblSubFrame4ActiveRampDutyCycle;
        private Label m_lblSubFrame3ActiveRampDutyCycle;
        private Label m_lblSubFrame2ActiveRampDutyCycle;
        private Label m_lblSubFrame1ActiveRampDutyCycle;
        private Label label45;
        private GroupBox m_grpAdvChirp;
        private NumericUpDown m_nudFixedDeltaInc;
        private Label label51;
        private NumericUpDown m_nudParamPeriod;
        private Label label50;
        private NumericUpDown m_nudResetPeriod;
        private Label label49;
        private NumericUpDown m_nudPatternMode;
        private Label label48;
        private NumericUpDown m_nudResetMode;
        private Label label47;
        private NumericUpDown m_nudChirpParamIdx;
        private Label label46;
        private Button m_btnAdvChirpConfig;
    }
}
