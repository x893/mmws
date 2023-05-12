using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AR1xController.GUI;
using AR1xController.Properties;

namespace AR1xController
{
    public class ChirpConfigTab : UserControl
    {
        public bool DownlaodFilesAbort
        {
            get
            {
                return this.m_bDownlaodFilesAbort;
            }
            set
            {
                this.m_bDownlaodFilesAbort = value;
            }
        }

        public ChirpConfigTab()
        {
            this.InitializeComponent();
            this.PostInitialization();
            this.m_MainForm = this.m_GuiManager.MainTsForm;
            this.m_ChirpConfigParams = this.m_GuiManager.TsParams.ChirpConfigParams;
            this.m_DynamicPowerSaveConfigParams = this.m_GuiManager.TsParams.DynamicPowerSaveConfigParams;
            this.m_InterRxGainPhaseFreqControlConfigParameters = this.m_GuiManager.TsParams.InterRxGainPhaseFreqControlConfigParameters;
            string directoryName = Path.GetDirectoryName(Application.StartupPath);
            string text = string.Concat(new string[]
            {
                directoryName + "\\PostProc\\adc_data.bin"
            });
            this.m_cboADC_DataFile.Text = text;
            this.m_chbTestSourceEnable.Visible = true;
            this.m_cboFrameTriggerSelect.SelectedIndex = 0;
            this.m_cboProfileRFGainTarget.SelectedIndex = 0;
            this.m_cboProfileVCOSelect.SelectedIndex = 0;
            this.m_bDownlaodFilesAbort = false;
            this.ComputeChirpBandwith();
        }

        public void ComputeChirpBandwith()
        {
            double value = (double)((ushort)Math.Round((double)this.m_nudFreqSlopeConst.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
            this.m_nudFreqSlopeConst.Value = (decimal)Math.Round(value, 3);
            this.m_lblBandwidth.Text = Math.Round(this.m_nudFreqSlopeConst.Value * this.m_nudRampEndTime.Value, 2).ToString();
        }

        public bool UpdateChirpConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateChirpConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_ChirpConfigParams.pprofileId = (ushort)this.m_nudProfileProfileId.Value;
                this.m_ChirpConfigParams.startFreqConst = (double)this.m_nudStartFreqConst.Value;
                this.m_ChirpConfigParams.idleTimeConst = (float)this.m_nudIdleTimeConst.Value;
                this.m_ChirpConfigParams.adcStartTimeConst = (float)this.m_nudAdcStartTimeConst.Value;
                this.m_ChirpConfigParams.rampEndTime = (float)this.m_nudRampEndTime.Value;
                this.m_ChirpConfigParams.tx1OutPowerBackoffCode = (uint)this.m_nudTx1OutPowerBackoffCode.Value;
                this.m_ChirpConfigParams.tx2OutPowerBackoffCode = (uint)this.m_nudTx2OutPowerBackoffCode.Value;
                this.m_ChirpConfigParams.tx3OutPowerBackoffCode = (uint)this.m_nudTx3OutPowerBackoffCode.Value;
                this.m_ChirpConfigParams.tx1PhaseShifter = (double)this.m_nudTx1PhaseShifter.Value;
                this.m_ChirpConfigParams.tx2PhaseShifter = (double)this.m_nudTx2PhaseShifter.Value;
                this.m_ChirpConfigParams.tx3PhaseShifter = (double)this.m_nudTx3PhaseShifter.Value;
                this.m_ChirpConfigParams.freqSlopeConst = (float)this.m_nudFreqSlopeConst.Value;
                this.m_ChirpConfigParams.txStartTime = (float)this.m_nudTxStartTime.Value;
                this.m_ChirpConfigParams.pnumAdcSamples = (ushort)this.m_nudNumAdcSamples.Value;
                this.m_ChirpConfigParams.digOutSampleRate = (ushort)this.m_nudDigOutSampleRate.Value;
                this.m_ChirpConfigParams.hpfCornerFreq1 = (char)this.m_cboProfileHpf1.SelectedIndex;
                this.m_ChirpConfigParams.hpfCornerFreq2 = (char)this.m_cboProfileHpf2.SelectedIndex;
                this.m_ChirpConfigParams.rxGain = (char)this.m_nudProfileRxGain.Value;
                this.m_ChirpConfigParams.VCOSelect = (byte)this.m_cboProfileVCOSelect.SelectedIndex;
                this.m_ChirpConfigParams.ForceVCOSelect = (byte)(this.m_chbProfileForceVCOSelect.Checked ? 1 : 0);
                this.m_ChirpConfigParams.RetainTxCalLUT = (byte)(this.m_chbProfileRetainTxCalLUT.Checked ? 1 : 0);
                this.m_ChirpConfigParams.RetainRxCalLUT = (byte)(this.m_chbProfileRetainRxCalLUT.Checked ? 1 : 0);
                if (this.m_cboProfileRFGainTarget.SelectedIndex == 0)
                {
                    this.m_ChirpConfigParams.RFGainTarget = '\0';
                }
                else if (this.m_cboProfileRFGainTarget.SelectedIndex == 1)
                {
                    this.m_ChirpConfigParams.RFGainTarget = '\u0001';
                }
                else if (this.m_cboProfileRFGainTarget.SelectedIndex == 2)
                {
                    this.m_ChirpConfigParams.RFGainTarget = '\u0003';
                }
                this.m_ChirpConfigParams.TX0CalibTx0 = (byte)(this.m_chbTX0CalibTx0.Checked ? 1 : 0);
                this.m_ChirpConfigParams.TX0CalibTx1 = (byte)(this.m_chbTX0CalibTx1.Checked ? 1 : 0);
                this.m_ChirpConfigParams.TX0CalibTx2 = (byte)(this.m_chbTX0CalibTx2.Checked ? 1 : 0);
                this.m_ChirpConfigParams.TX1CalibTx0 = (byte)(this.m_chbTX1CalibTx0.Checked ? 1 : 0);
                this.m_ChirpConfigParams.TX1CalibTx1 = (byte)(this.m_chbTX1CalibTx1.Checked ? 1 : 0);
                this.m_ChirpConfigParams.TX1CalibTx2 = (byte)(this.m_chbTX1CalibTx2.Checked ? 1 : 0);
                this.m_ChirpConfigParams.TX2CalibTx0 = (byte)(this.m_chbTX2CalibTx0.Checked ? 1 : 0);
                this.m_ChirpConfigParams.TX2CalibTx1 = (byte)(this.m_chbTX2CalibTx1.Checked ? 1 : 0);
                this.m_ChirpConfigParams.TX2CalibTx2 = (byte)(this.m_chbTX2CalibTx2.Checked ? 1 : 0);
                this.m_ChirpConfigParams.chirpStartIdx = (ushort)this.m_nudChirpStartIdx.Value;
                this.m_ChirpConfigParams.chirpEndIdx = (ushort)this.m_nudChirpEnd.Value;
                this.m_ChirpConfigParams.cprofileId = (ushort)this.m_nudChirpProfileId.Value;
                this.m_ChirpConfigParams.startFreqVar = (float)this.m_nudChirpStartFreq.Value;
                this.m_ChirpConfigParams.freqSlopeVar = (float)this.m_nudChirpFreqSlope.Value;
                this.m_ChirpConfigParams.idleTimeVar = (float)this.m_nudChirpIdleTime.Value;
                this.m_ChirpConfigParams.adcStartTimeVar = (float)this.m_nudChirpAdcStart.Value;
                this.m_ChirpConfigParams.tx1Enable = (ushort)(this.f00016c.Checked ? 1 : 0);
                this.m_ChirpConfigParams.tx2Enable = (ushort)(this.f00016b.Checked ? 1 : 0);
                this.m_ChirpConfigParams.tx3Enable = (ushort)(this.f00016a.Checked ? 1 : 0);
                this.m_ChirpConfigParams.fchirpStartIdx = (ushort)this.m_nudFrameStartChirp.Value;
                this.m_ChirpConfigParams.fchirpEndIdx = (ushort)this.m_nudFrameEndChirp.Value;
                this.m_ChirpConfigParams.frameCount = (ushort)this.m_nudFrameNumbers.Value;
                this.m_ChirpConfigParams.loopCount = (ushort)this.m_nudFrameLoops.Value;
                this.m_ChirpConfigParams.periodicity = (float)this.m_nudFramePeriodicity.Value;
                this.m_ChirpConfigParams.numDummyChirpsAtEnd = (byte)this.m_nudDummyChirpsEnd.Value;
                this.m_ChirpConfigParams.triggerDelay = (float)this.m_nudFrameTriggerDelay.Value;
                this.m_ChirpConfigParams.f000329 = this.m_btnFrameStart.Text;
                this.m_ChirpConfigParams.testSourceEnable = (ushort)(this.m_chbTestSourceEnable.Checked ? 1 : 0);
                if (this.m_cboFrameTriggerSelect.SelectedIndex == 1)
                {
                    this.m_ChirpConfigParams.TriggerSelect = 2;
                    GlobalRef.f0002d1 = true;
                }
                else
                {
                    this.m_ChirpConfigParams.TriggerSelect = 1;
                    GlobalRef.f0002d1 = false;
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

        public bool UpdateProfDataGui(RootObject jobject, int p1, int profInd)
        {
            this.m_nudProfileProfileId.Value = jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.profileId;
            this.m_nudStartFreqConst.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.startFreqConst_GHz;
            this.m_nudIdleTimeConst.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.idleTimeConst_usec;
            this.m_nudAdcStartTimeConst.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.adcStartTimeConst_usec;
            this.m_nudRampEndTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.rampEndTime_usec;
            this.m_nudTx1OutPowerBackoffCode.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 255);
            this.m_nudTx2OutPowerBackoffCode.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 65280) >> 8;
            this.m_nudTx3OutPowerBackoffCode.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 16711680) >> 16;
            this.m_nudTx1PhaseShifter.Value = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.txPhaseShifter, 16) & 255) >> 2) * 5;
            this.m_nudTx2PhaseShifter.Value = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.txPhaseShifter, 16) & 65280) >> 10) * 5;
            this.m_nudTx3PhaseShifter.Value = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.txPhaseShifter, 16) & 16711680) >> 18) * 5;
            this.m_nudFreqSlopeConst.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.freqSlopeConst_MHz_usec;
            this.m_nudTxStartTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.txStartTime_usec;
            this.m_nudNumAdcSamples.Value = jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.numAdcSamples;
            this.m_nudDigOutSampleRate.Value = jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.digOutSampleRate;
            if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.hpfCornerFreq1 == 0)
            {
                this.m_cboProfileHpf1.SelectedIndex = 0;
            }
            else
            {
                this.m_cboProfileHpf1.SelectedIndex = 1;
            }
            if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.hpfCornerFreq2 == 0)
            {
                this.m_cboProfileHpf2.SelectedIndex = 0;
            }
            else
            {
                this.m_cboProfileHpf2.SelectedIndex = 1;
            }
            this.m_nudProfileRxGain.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.rxGain_dB, 16) & 63);
            if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 0)
            {
                this.m_cboProfileRFGainTarget.SelectedIndex = 0;
            }
            else if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 1)
            {
                this.m_cboProfileRFGainTarget.SelectedIndex = 1;
            }
            else if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 3)
            {
                this.m_cboProfileRFGainTarget.SelectedIndex = 3;
            }
            this.m_cboProfileVCOSelect.SelectedIndex = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.pfVcoSelect, 16) & 2) >> 1;
            this.m_chbProfileForceVCOSelect.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.pfVcoSelect, 16) & 1) == 1);
            this.m_chbProfileRetainRxCalLUT.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.pfCalLutUpdate, 16) & 2) >> 1 == 1);
            this.m_chbProfileRetainTxCalLUT.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[profInd].rlProfileCfg_t.pfCalLutUpdate, 16) & 1) == 1);
            return true;
        }

        public bool UpdateChirpDataGui(RootObject jobject, int p1, int chirpInd)
        {
            this.m_nudChirpStartIdx.Value = jobject.mmWaveDevices[p1].rfConfig.rlChirps[chirpInd].rlChirpCfg_t.chirpStartIdx;
            this.m_nudChirpEnd.Value = jobject.mmWaveDevices[p1].rfConfig.rlChirps[chirpInd].rlChirpCfg_t.chirpEndIdx;
            this.m_nudChirpProfileId.Value = jobject.mmWaveDevices[p1].rfConfig.rlChirps[chirpInd].rlChirpCfg_t.profileId;
            this.m_nudChirpStartFreq.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlChirps[chirpInd].rlChirpCfg_t.startFreqVar_MHz;
            this.m_nudChirpFreqSlope.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlChirps[chirpInd].rlChirpCfg_t.freqSlopeVar_KHz_usec;
            this.m_nudChirpIdleTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlChirps[chirpInd].rlChirpCfg_t.idleTimeVar_usec;
            this.m_nudChirpAdcStart.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlChirps[chirpInd].rlChirpCfg_t.adcStartTimeVar_usec;
            this.f00016c.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChirps[chirpInd].rlChirpCfg_t.txEnable, 16) & 1) == 1);
            this.f00016b.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChirps[chirpInd].rlChirpCfg_t.txEnable, 16) & 2) >> 1 == 1);
            this.f00016a.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChirps[chirpInd].rlChirpCfg_t.txEnable, 16) & 4) >> 2 == 1);
            return true;
        }

        public bool UpdateChirpData(RootObject jobject, int p1)
        {
            bool result;
            try
            {
                string[] array = new string[]
                {
                    "mmWaveDevices[0]",
                    "mmWaveDevices[1]",
                    "mmWaveDevices[2]",
                    "mmWaveDevices[3]"
                };
                if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles.Count == 0)
                {
                    string msg = string.Format("Missing Profiles Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg);
                }
                else
                {
                    string path = Path.GetDirectoryName(Application.StartupPath) + "\\Clients\\AR1xController\\ProfConfigData.csv";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    StreamWriter streamWriter = new StreamWriter(path);
                    string value = "Profile ID,Start Freq(GHz),Frequency Slope(MHz/ us),Idle Time(us),TX Start Time(us),ADC Start Time(us),ADC Samples, Sample Rate(ksps),Ramp End Time(us),RX Gain(dB),RX Gain Target(dB),VCO Select, Force VCO Select, Retain Tx Cal LUT,Retain Rx  Cal LUT, HPF1 Corner Freq(kHz),HPF2 Corner Freq(k / M Hz),O / p Pwr Backoff Tx0(dB),O / p Pwr Backoff Tx1(dB),O / p Pwr Backoff Tx2(dB),Phase Shifter TX0(deg),Phase Shifter TX1(deg),Phase Shifter TX2(deg)";
                    streamWriter.WriteLine(value);
                    int count = GlobalRef.jobject.mmWaveDevices[p1].rfConfig.rlProfiles.Count;
                    int num = 0;
                    int num2 = 0;
                    double num3 = 0.0;
                    for (int i = 0; i < count; i++)
                    {
                        string text = jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.profileId + ",";
                        text = text + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.startFreqConst_GHz + ",";
                        text = text + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.freqSlopeConst_MHz_usec + ",";
                        text = text + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.idleTimeConst_usec + ",";
                        text = text + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txStartTime_usec + ",";
                        text = text + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.adcStartTimeConst_usec + ",";
                        text = text + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.numAdcSamples + ",";
                        text = text + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.digOutSampleRate + ",";
                        text = text + jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.rampEndTime_usec + ",";
                        text = text + (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.rxGain_dB, 16) & 63) + ",";
                        if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 0)
                        {
                            num = 30;
                        }
                        else if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 1)
                        {
                            num = 34;
                        }
                        else if ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.rxGain_dB, 16) & 192) >> 6 == 3)
                        {
                            num = 26;
                        }
                        text = text + num + ",";
                        text = text + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.pfVcoSelect, 16) & 2) >> 1) + ",";
                        text = text + (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.pfVcoSelect, 16) & 1) + ",";
                        text = text + (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.pfCalLutUpdate, 16) & 1) + ",";
                        text = text + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.pfCalLutUpdate, 16) & 2) >> 1) + ",";
                        if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq1 == 0)
                        {
                            num2 = 175;
                        }
                        else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq1 == 1)
                        {
                            num2 = 235;
                        }
                        else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq1 == 2)
                        {
                            num2 = 350;
                        }
                        else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq1 == 3)
                        {
                            num2 = 700;
                        }
                        text = text + num2 + ",";
                        if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq2 == 0)
                        {
                            num3 = 350.0;
                        }
                        else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq2 == 1)
                        {
                            num3 = 700.0;
                        }
                        else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq2 == 2)
                        {
                            num3 = 1.4;
                        }
                        else if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.hpfCornerFreq2 == 3)
                        {
                            num3 = 2.8;
                        }
                        text = text + num3 + ",";
                        text = text + (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 255) + ",";
                        text = text + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 65280) >> 8) + ",";
                        text = text + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txOutPowerBackoffCode, 16) & 16711680) >> 16) + ",";
                        text = text + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txPhaseShifter, 16) & 255) >> 2) * 5 + ",";
                        text = text + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txPhaseShifter, 16) & 65280) >> 10) * 5 + ",";
                        text += ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlProfiles[i].rlProfileCfg_t.txPhaseShifter, 16) & 16711680) >> 18) * 5;
                        streamWriter.WriteLine(text);
                    }
                    streamWriter.Close();
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlChirps.Count == 0)
                {
                    string msg2 = string.Format("Missing Chirps Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg2);
                }
                else
                {
                    int count2 = GlobalRef.jobject.mmWaveDevices[p1].rfConfig.rlChirps.Count;
                    string path2 = Path.GetDirectoryName(Application.StartupPath) + "\\Clients\\AR1xController\\ChirpConfigData.csv";
                    if (File.Exists(path2))
                    {
                        File.Delete(path2);
                    }
                    StreamWriter streamWriter2 = new StreamWriter(path2);
                    string value2 = "Profile ID,Chirp Start Index,Chirp End Index,Start Freq Var (MHz),Frequency Slop Var (kHz/us),Idle Time Var (us),ADC Start Var (us),TX0 Enble,TX1 Enable,TX2 Enable";
                    streamWriter2.WriteLine(value2);
                    for (int j = 0; j < count2; j++)
                    {
                        string text2 = jobject.mmWaveDevices[p1].rfConfig.rlChirps[j].rlChirpCfg_t.profileId + ",";
                        text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[j].rlChirpCfg_t.chirpStartIdx + ",";
                        text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[j].rlChirpCfg_t.chirpEndIdx + ",";
                        text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[j].rlChirpCfg_t.startFreqVar_MHz + ",";
                        text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[j].rlChirpCfg_t.freqSlopeVar_KHz_usec + ",";
                        text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[j].rlChirpCfg_t.idleTimeVar_usec + ",";
                        text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.rlChirps[j].rlChirpCfg_t.adcStartTimeVar_usec + ",";
                        text2 = text2 + (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChirps[j].rlChirpCfg_t.txEnable, 16) & 1) + ",";
                        text2 = text2 + ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChirps[j].rlChirpCfg_t.txEnable, 16) & 2) >> 1) + ",";
                        text2 += (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlChirps[j].rlChirpCfg_t.txEnable, 16) & 4) >> 2;
                        streamWriter2.WriteLine(text2);
                    }
                    streamWriter2.Close();
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlProfiles.Count == 0)
                {
                    string msg3 = string.Format("Missing Profiles Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg3);
                }
                else
                {
                    this.UpdateProfDataGui(jobject, p1, 0);
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlChirps.Count == 0)
                {
                    string msg4 = string.Format("Missing Chirps Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg4);
                }
                else
                {
                    this.UpdateChirpDataGui(jobject, p1, 0);
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlFrameCfg_t.isConfigured == 0)
                {
                    string msg5 = string.Format("Missing Frame Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg5);
                }
                else
                {
                    this.m_nudFrameStartChirp.Value = jobject.mmWaveDevices[p1].rfConfig.rlFrameCfg_t.chirpStartIdx;
                    this.m_nudFrameEndChirp.Value = jobject.mmWaveDevices[p1].rfConfig.rlFrameCfg_t.chirpEndIdx;
                    this.m_nudFrameNumbers.Value = jobject.mmWaveDevices[p1].rfConfig.rlFrameCfg_t.numFrames;
                    this.m_nudFrameLoops.Value = jobject.mmWaveDevices[p1].rfConfig.rlFrameCfg_t.numLoops;
                    this.m_nudFramePeriodicity.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlFrameCfg_t.framePeriodicity_msec;
                    this.m_nudDummyChirpsEnd.Value = jobject.mmWaveDevices[p1].rfConfig.rlFrameCfg_t.numDummyChirpsAtEnd;
                    this.m_nudFrameTriggerDelay.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlFrameCfg_t.frameTriggerDelay;
                    if (jobject.mmWaveDevices[p1].rfConfig.rlFrameCfg_t.triggerSelect == 2)
                    {
                        this.m_cboFrameTriggerSelect.SelectedIndex = 1;
                    }
                    else if (jobject.mmWaveDevices[p1].rfConfig.rlFrameCfg_t.triggerSelect == 1)
                    {
                        this.m_cboFrameTriggerSelect.SelectedIndex = 0;
                    }
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlDynPwrSave_t.isConfigured == 0)
                {
                    string msg6 = string.Format("Missing Dynamic Power Save Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg6);
                }
                else
                {
                    this.m_chbDynamicPowerSaveTx.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynPwrSave_t.p00000b, 16) & 1) == 1);
                    this.m_chbDynamicPowerSaveRx.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynPwrSave_t.p00000b, 16) & 2) >> 1 == 1);
                    this.m_chbDynamicPowerSaveLO.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynPwrSave_t.p00000b, 16) & 4) >> 2 == 1);
                }
                if (jobject.mmWaveDevices[p1].rfConfig.rlInterRxGainPhConf_t.isConfigured == 0)
                {
                    string msg7 = string.Format("Missing Inter Rx Gain Phase Configuration for Device {0}. Skipping..", p1);
                    GlobalRef.LuaWrapper.PrintWarning(msg7);
                }
                else
                {
                    this.m_nudInterRxGainPhaseProfileIndex.Value = jobject.mmWaveDevices[p1].rfConfig.rlInterRxGainPhConf_t.profileIndx;
                    this.m_nudInterRxGainPhaseDigitalRx1Gain.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterRxGainPhConf_t.digRxGain[0];
                    this.m_nudInterRxGainPhaseDigitalRx2Gain.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterRxGainPhConf_t.digRxGain[1];
                    this.m_nudInterRxGainPhaseDigitalRx3Gain.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterRxGainPhConf_t.digRxGain[2];
                    this.m_nudInterRxGainPhaseDigitalRx4Gain.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterRxGainPhConf_t.digRxGain[3];
                    this.m_nudInterRxGainPhaseDigitalRx1PhaseShift.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterRxGainPhConf_t.digRxPhShift[0];
                    this.m_nudInterRxGainPhaseDigitalRx2PhaseShift.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterRxGainPhConf_t.digRxPhShift[1];
                    this.m_nudInterRxGainPhaseDigitalRx3PhaseShift.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterRxGainPhConf_t.digRxPhShift[2];
                    this.m_nudInterRxGainPhaseDigitalRx4PhaseShift.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterRxGainPhConf_t.digRxPhShift[3];
                }
                result = true;
            }
            catch
            {
                string msg8 = string.Format("Chirp Config Tab Configuration for device {0} is incorrect.", p1);
                GlobalRef.LuaWrapper.PrintError(msg8);
                result = false;
            }
            return result;
        }

        public bool CheckValidValuesOfChirpTXchannels()
        {
            bool result;
            try
            {
                if (this.m_ChirpConfigParams.tx1Enable == 1 && this.m_ChirpConfigParams.tx2Enable == 1 && this.m_ChirpConfigParams.tx3Enable == 1)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool chirpTxChannelMsg()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.chirpTxChannelMsg);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                MessageBox.Show(this, " Not permitted an enabling of chirp three TX channels at time ");
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool DoParamCheck()
        {
            if (GlobalRef.g_ARDeviceOperateFreq60GHz)
            {
                return true;
            }
            if (!GlobalRef.g_AR2243Device)
            {
                if ((float)(this.m_ChirpConfigParams.pnumAdcSamples / (this.m_ChirpConfigParams.digOutSampleRate / 1000m)) + this.m_ChirpConfigParams.adcStartTimeConst >= this.m_ChirpConfigParams.rampEndTime)
                {
                    MessageBox.Show(string.Format("Error: Ramp duration is not enough to capture {0} samples at {1} ksps", new object[]
                    {
                        this.m_nudNumAdcSamples.Value,
                        this.m_nudDigOutSampleRate.Value
                    }));
                    return false;
                }
                float num = (float)(this.m_ChirpConfigParams.startFreqConst + (double)((float)((double)(this.m_ChirpConfigParams.freqSlopeConst * this.m_ChirpConfigParams.rampEndTime) / 1000.0)));
                double num2;
                double num3;
                if (this.m_ChirpConfigParams.startFreqConst < (double)num)
                {
                    num2 = this.m_ChirpConfigParams.startFreqConst;
                    num3 = (double)num;
                }
                else
                {
                    num2 = (double)num;
                    num3 = this.m_ChirpConfigParams.startFreqConst;
                }
                if (num3 > 81.01)
                {
                    if (this.m_ChirpConfigParams.freqSlopeConst < 0f)
                    {
                        MessageBox.Show(string.Format("Error: Start Freq of ramp {0} GHz is outside valid range", new object[]
                        {
                            (decimal)num3
                        }));
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Error: End Freq of ramp {0} GHz is outside valid range", new object[]
                        {
                            (decimal)num3
                        }));
                    }
                    return false;
                }
                if (num2 < 75.55)
                {
                    if (this.m_ChirpConfigParams.freqSlopeConst < 0f)
                    {
                        MessageBox.Show(string.Format("Error: End Freq of ramp {0} GHz is outside valid range", new object[]
                        {
                            (decimal)num2
                        }));
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Error: Start Freq of ramp {0} GHz is outside valid range", new object[]
                        {
                            (decimal)num2
                        }));
                    }
                    return false;
                }
            }
            return true;
        }

        public bool UpdateChirpConfigDataFrmCmd()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateChirpConfigDataFrmCmd);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudChirpStartIdx.Value = this.m_ChirpConfigParams.chirpStartIdx;
                this.m_nudChirpEnd.Value = this.m_ChirpConfigParams.chirpEndIdx;
                this.m_nudChirpProfileId.Value = this.m_ChirpConfigParams.cprofileId;
                this.m_nudChirpStartFreq.Value = (decimal)this.m_ChirpConfigParams.startFreqVar;
                this.m_nudChirpFreqSlope.Value = (decimal)this.m_ChirpConfigParams.freqSlopeVar;
                this.m_nudChirpIdleTime.Value = (decimal)this.m_ChirpConfigParams.idleTimeVar;
                this.m_nudChirpAdcStart.Value = (decimal)this.m_ChirpConfigParams.adcStartTimeVar;
                this.f00016c.Checked = (this.m_ChirpConfigParams.tx1Enable == 1);
                this.f00016b.Checked = (this.m_ChirpConfigParams.tx2Enable == 1);
                this.f00016a.Checked = (this.m_ChirpConfigParams.tx3Enable == 1);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateProfileConfigDataFrmCmd()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateProfileConfigDataFrmCmd);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudProfileProfileId.Value = this.m_ChirpConfigParams.pprofileId;
                this.m_nudStartFreqConst.Value = (decimal)this.m_ChirpConfigParams.startFreqConst;
                this.m_nudIdleTimeConst.Value = (decimal)this.m_ChirpConfigParams.idleTimeConst;
                this.m_nudAdcStartTimeConst.Value = (decimal)this.m_ChirpConfigParams.adcStartTimeConst;
                this.m_nudRampEndTime.Value = (decimal)this.m_ChirpConfigParams.rampEndTime;
                this.m_nudTx1OutPowerBackoffCode.Value = this.m_ChirpConfigParams.tx1OutPowerBackoffCode;
                this.m_nudTx2OutPowerBackoffCode.Value = this.m_ChirpConfigParams.tx2OutPowerBackoffCode;
                this.m_nudTx3OutPowerBackoffCode.Value = this.m_ChirpConfigParams.tx3OutPowerBackoffCode;
                this.m_nudTx1PhaseShifter.Value = (decimal)this.m_ChirpConfigParams.tx1PhaseShifter;
                this.m_nudTx2PhaseShifter.Value = (decimal)this.m_ChirpConfigParams.tx2PhaseShifter;
                this.m_nudTx3PhaseShifter.Value = (decimal)this.m_ChirpConfigParams.tx3PhaseShifter;
                this.m_nudFreqSlopeConst.Value = (decimal)this.m_ChirpConfigParams.freqSlopeConst;
                this.m_nudTxStartTime.Value = (decimal)this.m_ChirpConfigParams.txStartTime;
                this.m_nudNumAdcSamples.Value = this.m_ChirpConfigParams.pnumAdcSamples;
                this.m_nudDigOutSampleRate.Value = this.m_ChirpConfigParams.digOutSampleRate;
                this.m_cboProfileHpf1.SelectedIndex = (int)this.m_ChirpConfigParams.hpfCornerFreq1;
                this.m_cboProfileHpf2.SelectedIndex = (int)this.m_ChirpConfigParams.hpfCornerFreq2;
                this.m_nudProfileRxGain.Value = this.m_ChirpConfigParams.rxGain;
                if (this.m_ChirpConfigParams.RFGainTarget == '\0')
                {
                    this.m_cboProfileRFGainTarget.SelectedIndex = 0;
                }
                else if (this.m_ChirpConfigParams.RFGainTarget == '\u0001')
                {
                    this.m_cboProfileRFGainTarget.SelectedIndex = 1;
                }
                else if (this.m_ChirpConfigParams.RFGainTarget == '\u0003')
                {
                    this.m_cboProfileRFGainTarget.SelectedIndex = 2;
                }
                this.m_chbProfileForceVCOSelect.Checked = (this.m_ChirpConfigParams.ForceVCOSelect == 1);
                this.m_cboProfileVCOSelect.SelectedIndex = (int)this.m_ChirpConfigParams.VCOSelect;
                this.m_chbProfileRetainTxCalLUT.Checked = (this.m_ChirpConfigParams.RetainTxCalLUT == 1);
                this.m_chbProfileRetainRxCalLUT.Checked = (this.m_ChirpConfigParams.RetainRxCalLUT == 1);
                if (this.m_ChirpConfigParams.f000328 == 0)
                {
                    this.m_chbTX0CalibTx0.Checked = true;
                }
                else
                {
                    this.m_chbTX0CalibTx0.Checked = (this.m_ChirpConfigParams.TX0CalibTx0 == 1);
                }
                this.m_chbTX0CalibTx1.Checked = (this.m_ChirpConfigParams.TX0CalibTx1 == 1);
                this.m_chbTX0CalibTx2.Checked = (this.m_ChirpConfigParams.TX0CalibTx2 == 1);
                this.m_chbTX1CalibTx0.Checked = (this.m_ChirpConfigParams.TX1CalibTx0 == 1);
                if (this.m_ChirpConfigParams.f000328 == 0)
                {
                    this.m_chbTX1CalibTx1.Checked = true;
                }
                else
                {
                    this.m_chbTX1CalibTx1.Checked = (this.m_ChirpConfigParams.TX1CalibTx1 == 1);
                }
                this.m_chbTX1CalibTx2.Checked = (this.m_ChirpConfigParams.TX1CalibTx2 == 1);
                this.m_chbTX2CalibTx0.Checked = (this.m_ChirpConfigParams.TX2CalibTx0 == 1);
                this.m_chbTX2CalibTx1.Checked = (this.m_ChirpConfigParams.TX2CalibTx1 == 1);
                if (this.m_ChirpConfigParams.f000328 == 0)
                {
                    this.m_chbTX2CalibTx2.Checked = true;
                }
                else
                {
                    this.m_chbTX2CalibTx2.Checked = (this.m_ChirpConfigParams.TX2CalibTx2 == 1);
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

        public bool UpdateFrameConfigDataFrmCmd()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateFrameConfigDataFrmCmd);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudFrameStartChirp.Value = this.m_ChirpConfigParams.fchirpStartIdx;
                this.m_nudFrameEndChirp.Value = this.m_ChirpConfigParams.fchirpEndIdx;
                this.m_nudFrameNumbers.Value = this.m_ChirpConfigParams.frameCount;
                this.m_nudFrameLoops.Value = this.m_ChirpConfigParams.loopCount;
                this.m_nudFramePeriodicity.Value = (decimal)this.m_ChirpConfigParams.periodicity;
                this.m_nudFrameTriggerDelay.Value = (decimal)this.m_ChirpConfigParams.triggerDelay;
                this.m_ChirpConfigParams.testSourceEnable = (ushort)(this.m_chbTestSourceEnable.Checked ? 1 : 0);
                this.m_chbTestSourceEnable.Checked = (this.m_ChirpConfigParams.testSourceEnable == 1);
                this.m_nudDummyChirpsEnd.Value = this.m_ChirpConfigParams.numDummyChirpsAtEnd;
                if (this.m_ChirpConfigParams.TriggerSelect == 2)
                {
                    this.m_cboFrameTriggerSelect.SelectedIndex = 1;
                }
                else
                {
                    this.m_cboFrameTriggerSelect.SelectedIndex = 0;
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

        public bool LoadChirpConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadChirpConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("chirpStartIdx"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("chirpEndIdx"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("cprofileId"));
                Convert.ToUInt32(ConfigurationManager.GetAppSetting("startFreqVar"));
                Convert.ToSingle(ConfigurationManager.GetAppSetting("freqSlopeVar"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("idleTimeVar"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("adcStartTimeVar"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("tx1Enable"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("tx2Enable"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("tx3Enable"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("fchirpStartIdx"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("fchirpEndIdx"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("frameCount"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("loopCount"));
                Convert.ToSingle(ConfigurationManager.GetAppSetting("periodicity"));
                Convert.ToSingle(ConfigurationManager.GetAppSetting("triggerDelay"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("pprofileId"));
                Convert.ToSingle(ConfigurationManager.GetAppSetting("startFreqConst"));
                Convert.ToSingle(ConfigurationManager.GetAppSetting("idleTimeConst"));
                Convert.ToSingle(ConfigurationManager.GetAppSetting("adcStartTimeConst"));
                Convert.ToSingle(ConfigurationManager.GetAppSetting("rampEndTime"));
                Convert.ToUInt32(ConfigurationManager.GetAppSetting("tx1OutPowerBackoffCode"));
                Convert.ToUInt32(ConfigurationManager.GetAppSetting("tx2OutPowerBackoffCode"));
                Convert.ToUInt32(ConfigurationManager.GetAppSetting("tx3OutPowerBackoffCode"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("tx1PhaseShifter"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("tx2PhaseShifter"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("tx3PhaseShifter"));
                Convert.ToSingle(ConfigurationManager.GetAppSetting("freqSlopeConst"));
                Convert.ToSingle(ConfigurationManager.GetAppSetting("txStartTime"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("numAdcSamples"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("digOutSampleRate"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("hpfCornerFreq1"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("hpfCornerFreq2"));
                Convert.ToUInt16(ConfigurationManager.GetAppSetting("rxGain"));
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveChirpConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveChirpConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetAppSetting("chirpStartIdx", this.m_nudChirpStartIdx.Value.ToString());
                ConfigurationManager.SetAppSetting("chirpEndIdx", this.m_nudChirpEnd.Value.ToString());
                ConfigurationManager.SetAppSetting("cprofileId", this.m_nudChirpProfileId.Value.ToString());
                ConfigurationManager.SetAppSetting("startFreqVar", this.m_nudChirpStartFreq.Value.ToString());
                ConfigurationManager.SetAppSetting("freqSlopeVar", this.m_nudChirpFreqSlope.Value.ToString());
                ConfigurationManager.SetAppSetting("idleTimeVar", this.m_nudChirpIdleTime.Value.ToString());
                ConfigurationManager.SetAppSetting("adcStartTimeVar", this.m_nudChirpAdcStart.Value.ToString());
                ConfigurationManager.SetAppSetting("tx1Enable", (this.f00016c.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAppSetting("tx2Enable", (this.f00016b.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAppSetting("tx3Enable", (this.f00016a.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetAppSetting("fchirpStartIdx", this.m_nudFrameStartChirp.Value.ToString());
                ConfigurationManager.SetAppSetting("fchirpEndIdx", this.m_nudFrameEndChirp.Value.ToString());
                ConfigurationManager.SetAppSetting("frameCount", this.m_nudFrameNumbers.Value.ToString());
                ConfigurationManager.SetAppSetting("loopCount", this.m_nudFrameLoops.Value.ToString());
                ConfigurationManager.SetAppSetting("periodicity", this.m_nudFramePeriodicity.Value.ToString());
                ConfigurationManager.SetAppSetting("triggerDelay", this.m_nudFrameTriggerDelay.Value.ToString());
                ConfigurationManager.SetAppSetting("pprofileId", this.m_nudProfileProfileId.Value.ToString());
                ConfigurationManager.SetAppSetting("startFreqConst", this.m_nudStartFreqConst.Value.ToString());
                ConfigurationManager.SetAppSetting("idleTimeConst", this.m_nudIdleTimeConst.Value.ToString());
                ConfigurationManager.SetAppSetting("adcStartTimeConst", this.m_nudAdcStartTimeConst.Value.ToString());
                ConfigurationManager.SetAppSetting("rampEndTime", this.m_nudRampEndTime.Value.ToString());
                ConfigurationManager.SetAppSetting("tx1OutPowerBackoffCode", this.m_nudTx1OutPowerBackoffCode.Value.ToString());
                ConfigurationManager.SetAppSetting("tx2OutPowerBackoffCode", this.m_nudTx2OutPowerBackoffCode.Value.ToString());
                ConfigurationManager.SetAppSetting("tx3OutPowerBackoffCode", this.m_nudTx3OutPowerBackoffCode.Value.ToString());
                ConfigurationManager.SetAppSetting("tx1PhaseShifter", this.m_nudTx1PhaseShifter.Value.ToString());
                ConfigurationManager.SetAppSetting("tx2PhaseShifter", this.m_nudTx2PhaseShifter.Value.ToString());
                ConfigurationManager.SetAppSetting("tx3PhaseShifter", this.m_nudTx3PhaseShifter.Value.ToString());
                ConfigurationManager.SetAppSetting("freqSlopeConst", this.m_nudFreqSlopeConst.Value.ToString());
                ConfigurationManager.SetAppSetting("txStartTime", this.m_nudTxStartTime.Value.ToString());
                ConfigurationManager.SetAppSetting("numAdcSamples", this.m_nudNumAdcSamples.Value.ToString());
                ConfigurationManager.SetAppSetting("digOutSampleRate", this.m_nudDigOutSampleRate.Value.ToString());
                ConfigurationManager.SetAppSetting("hpfCornerFreq1", this.m_cboProfileHpf1.SelectedIndex.ToString());
                ConfigurationManager.SetAppSetting("hpfCornerFreq2", this.m_cboProfileHpf2.SelectedIndex.ToString());
                ConfigurationManager.SetAppSetting("rxGain", this.m_nudProfileRxGain.Value.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public void iSetTrigFrmBtnText(string text)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(this.iSetTrigFrmBtnText);
                base.Invoke(method, new object[]
                {
                    text
                });
                return;
            }
            this.m_btnFrameStart.Text = text;
        }

        private void m_lblChirpStartFreq_Click(object sender, EventArgs p1)
        {
        }

        private void m_nudProfileRxGain_ValueChanged(object sender, EventArgs p1)
        {
        }

        private int iSetChirpConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetChirpConfig_Gui(is_starting_op, is_ending_op);
        }

        public void SetFrameConfigReadyState()
        {
            this.m_btnFrameSet.ForeColor = Color.Blue;
        }

        public void ReSetchirpConfigReadyState()
        {
            this.m_btnChirpSet.ForeColor = Color.Black;
        }

        private void iSetChirpConfig()
        {
            this.iSetChirpConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
            this.m_MainForm.SetTSW1400ReadyState();
            this.SetFrameConfigReadyState();
            this.ReSetchirpConfigReadyState();
        }

        public void iSetChirpConfigAsync()
        {
            new del_v_v(this.iSetChirpConfig).BeginInvoke(null, null);
        }

        private void m_btnChirpSet_Click(object sender, EventArgs p1)
        {
            this.iSetChirpConfigAsync();
        }

        private int iSetFrameConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetFrameConfig_Gui(is_starting_op, is_ending_op);
        }

        public void ReSetFrameConfigReadyState()
        {
            this.m_btnFrameSet.ForeColor = Color.Black;
        }

        private void iSetFrameConfig()
        {
            this.iSetFrameConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
            this.m_MainForm.SetTSW1400ReadyState();
            this.ReSetFrameConfigReadyState();
        }

        public void iSetFrameConfigAsync()
        {
            new del_v_v(this.iSetFrameConfig).BeginInvoke(null, null);
        }

        private void m_btnFrameSet_Click(object sender, EventArgs p1)
        {
            this.iSetFrameConfigAsync();
        }

        private int iSetProfileConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetProfileConfig_Gui(is_starting_op, is_ending_op);
        }

        public void SetChirpConfigReadyState()
        {
            this.m_btnChirpSet.ForeColor = Color.Blue;
        }

        public void ReSetProfileConfigReadyState()
        {
            this.m_btnProfileSet.ForeColor = Color.Black;
        }

        private void iSetProfileConfig()
        {
            this.iSetProfileConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
            this.m_MainForm.SetTSW1400ReadyState();
            this.SetChirpConfigReadyState();
            this.ReSetProfileConfigReadyState();
        }

        public void iSetProfileConfigAsync()
        {
            new del_v_v(this.iSetProfileConfig).BeginInvoke(null, null);
        }

        private void m_btnProfileSet_Click(object sender, EventArgs p1)
        {
            this.iSetProfileConfigAsync();
        }

        public int getNumSamples()
        {
            if (base.InvokeRequired)
            {
                del_i_v method = new del_i_v(this.getNumSamples);
                return (int)base.Invoke(method);
            }
            return (int)this.m_nudNumAdcSamples.Value;
        }

        public long getNumChirps()
        {
            if (base.InvokeRequired)
            {
                del_ii_v method = new del_ii_v(this.getNumChirps);
                return (long)base.Invoke(method);
            }
            return (long)(((int)this.m_nudFrameEndChirp.Value - (int)this.m_nudFrameStartChirp.Value + 1) * (int)this.m_nudFrameLoops.Value);
        }

        private int iSetTrigFrame_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTrigFrame_Gui((ushort)GlobalRef.g_RadarDeviceId, is_starting_op, is_ending_op);
        }

        private void iSetTrigFrame()
        {
            this.iSetTrigFrame_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetTrigFrameAsync()
        {
            new del_v_v(this.iSetTrigFrame).BeginInvoke(null, null);
        }

        private void m_btnFrameStart_Click(object sender, EventArgs p1)
        {
            this.iSetTrigFrameAsync();
        }

        public string iGetFrameBtnText()
        {
            if (base.InvokeRequired)
            {
                del_s_v method = new del_s_v(this.iGetFrameBtnText);
                return (string)base.Invoke(method);
            }
            return this.m_btnFrameStart.Text;
        }

        public string iResetTriggerBtnText()
        {
            if (base.InvokeRequired)
            {
                del_s_v method = new del_s_v(this.iResetTriggerBtnText);
                return (string)base.Invoke(method);
            }
            string empty = string.Empty;
            this.m_btnFrameStart.Text = "Trigger Frame";
            return empty;
        }

        public void EnabletheTriggerSelect()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.EnabletheTriggerSelect);
                base.Invoke(method);
                return;
            }
            this.m_cboFrameTriggerSelect.Visible = true;
            this.m_lblTriggerSelect.Visible = true;
        }

        public void DisabletheTriggerSelect()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.DisabletheTriggerSelect);
                base.Invoke(method);
                return;
            }
            this.m_cboFrameTriggerSelect.Visible = true;
            this.m_lblTriggerSelect.Visible = true;
        }

        public void iSetFrameBtnText(string text)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(this.iSetFrameBtnText);
                base.Invoke(method, new object[]
                {
                    text
                });
                return;
            }
            this.m_btnFrameStart.Text = text;
        }

        private void m_btnMangChirps_Click(object sender, EventArgs p1)
        {
            this.m_ChirpManager = new ChirpManager();
            this.m_ChirpManager.Show();
        }

        private void m_btnMangProfiles_Click(object sender, EventArgs p1)
        {
            this.m_ProfManager = new ProfManager();
            this.m_ProfManager.Show();
            GlobalRef.ProfManager = this.m_ProfManager;
        }

        public bool iDisableChirpCfgTabBtns()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.iDisableChirpCfgTabBtns);
                return (bool)base.Invoke(method);
            }
            this.m_btnChirpSet.Enabled = false;
            this.m_btnFrameSet.Enabled = false;
            this.m_btnFrameStart.Enabled = false;
            this.m_btnMangChirps.Enabled = false;
            this.m_btnMangProfiles.Enabled = false;
            this.m_btnProfileSet.Enabled = false;
            this.m_btnRealTime.Enabled = false;
            return true;
        }

        public bool iEnableChirpCfgTabBtns()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.iEnableChirpCfgTabBtns);
                return (bool)base.Invoke(method);
            }
            this.m_btnChirpSet.Enabled = true;
            this.m_btnFrameSet.Enabled = true;
            this.m_btnFrameStart.Enabled = true;
            this.m_btnMangChirps.Enabled = true;
            this.m_btnMangProfiles.Enabled = true;
            this.m_btnProfileSet.Enabled = true;
            this.m_btnRealTime.Enabled = true;
            return true;
        }

        public void iStartTsw1400Invoke()
        {
            this.m_MainForm.startTsw1400Capture();
        }

        public void iStartTsw1400Async()
        {
            new del_v_v(this.iStartTsw1400Invoke).BeginInvoke(null, null);
        }

        public void m_btnTsw1400_Click(object sender, EventArgs p1)
        {
            GlobalRef.dobject.capturedFiles.files.Clear();
            GlobalRef.dobject.capturedFiles.numFilesCollected = GlobalRef.dobject.capturedFiles.files.Count;
            GlobalRef.dobject.capturedFiles.fileBasePath = "";
            GlobalRef.f0002c5 = 0;
            if (GlobalRef.f0002d0)
            {
                this.iDisableChirpCfgTabBtns();
                this.m_MainForm.SetOvBtEnblTimer(true);
                this.iStartRFDataCaptureCardAsync();
                this.iEnableChirpCfgTabBtns();
                this.m_MainForm.SetOvBtEnblTimer(false);
            }
            else if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
            {
                this.iDisableChirpCfgTabBtns();
                this.m_MainForm.SetOvBtEnblTimer(true);
                this.iStartTDACaptureCardAsync();
                this.iEnableChirpCfgTabBtns();
                this.m_MainForm.SetOvBtEnblTimer(false);
            }
            else
            {
                this.iDisableChirpCfgTabBtns();
                this.m_MainForm.SetOvBtEnblTimer(true);
                this.iStartTsw1400Async();
                this.iEnableChirpCfgTabBtns();
                this.m_MainForm.SetOvBtEnblTimer(false);
            }
            GlobalRef.f0002c5++;
            int count = GlobalRef.dobject.capturedFiles.files.Count;
            if (GlobalRef.f0002c5 > count)
            {
                Files item = new Files();
                GlobalRef.dobject.capturedFiles.files.Add(item);
                GlobalRef.dobject.capturedFiles.files[GlobalRef.f0002c5 - 1].rawFileName = "";
                GlobalRef.dobject.capturedFiles.files[GlobalRef.f0002c5 - 1].processedFileName = "";
                GlobalRef.dobject.capturedFiles.files[GlobalRef.f0002c5 - 1].processedFileSummary = new ProcessedFileSummary();
                this.GetCapturedFilesInfo();
                return;
            }
            this.MatlabPostProcPathSet(GlobalRef.dobject);
        }

        public void m00000c()
        {
            if (GlobalRef.f0002d0)
            {
                this.iDisableChirpCfgTabBtns();
                this.m_MainForm.SetOvBtEnblTimer(true);
                this.iStartRFDataCaptureCardAsync();
                this.iEnableChirpCfgTabBtns();
                this.m_MainForm.SetOvBtEnblTimer(false);
                return;
            }
            this.iDisableChirpCfgTabBtns();
            this.m_MainForm.SetOvBtEnblTimer(true);
            this.iStartTsw1400Async();
            this.iEnableChirpCfgTabBtns();
            this.m_MainForm.SetOvBtEnblTimer(false);
        }

        public void iStartTDACaptureCardAsync()
        {
            new del_v_v(this.iStartTDACaptureCardInvoke).BeginInvoke(null, null);
        }

        public void iStartTDACaptureCardInvoke()
        {
            this.m_MainForm.startTDACaptureCardCapture();
        }

        public void UpdateTDAAttributes()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.UpdateTDAAttributes);
                base.Invoke(method);
                return;
            }
            GlobalRef.g_numFilesAllocated = (uint)this.m_nudFileAllocation.Value;
            GlobalRef.g_enablePackaging = (this.m_ChkEnaDisablePackaging.Checked ? 1U : 0U);
            GlobalRef.g_numFramesToCapture = (uint)this.m_nudNumFramesToCapture.Value;
            string[] array = this.getCapturePath().Split(new char[]
            {
                '\\'
            });
            int num = array.Length;
            GlobalRef.g_TDACaptureDirectory = "/mnt/ssd/" + Path.GetFileNameWithoutExtension(array[num - 1]);
        }

        public int m00000d(uint numFilesAllocated, uint enablePackaging, string captureDirectory, uint numFramesToCapture)
        {
            if (base.InvokeRequired)
            {
                delegate0f1 method = new delegate0f1(this.m00000d);
                return (int)base.Invoke(method, new object[]
                {
                    numFilesAllocated,
                    enablePackaging,
                    captureDirectory,
                    numFramesToCapture
                });
            }
            this.m_nudFileAllocation.Value = numFilesAllocated;
            if (enablePackaging == 1U)
            {
                this.m_ChkEnaDisablePackaging.Checked = true;
            }
            else
            {
                this.m_ChkEnaDisablePackaging.Checked = false;
            }
            this.m_nudNumFramesToCapture.Value = numFramesToCapture;
            GlobalRef.g_TDACaptureDirectory = "/mnt/ssd/" + captureDirectory;
            string text = this.getCapturePath();
            string[] array = text.Split(new char[]
            {
                '\\'
            });
            int num = array.Length;
            array[num - 1] = captureDirectory + ".bin";
            text = string.Empty;
            for (int i = 0; i < num; i++)
            {
                if (i == num - 1)
                {
                    text += array[i];
                }
                else
                {
                    text = text + array[i] + "\\";
                }
            }
            this.m_cboADC_DataFile.Text = text;
            return 0;
        }

        public void iStartRFDataCaptureCardInvoke()
        {
            this.m_MainForm.startRFDataCaptureCardCapture();
        }

        public void iStartRFDataCaptureCardAsync()
        {
            new del_v_v(this.iStartRFDataCaptureCardInvoke).BeginInvoke(null, null);
        }

        public void debugStartRFDataCaptureCardInvoke()
        {
            this.m_MainForm.debugstartRFDataCaptureCardCapture();
        }

        public void debugStartRFDataCaptureCardAsync()
        {
            new del_v_v(this.debugStartRFDataCaptureCardInvoke).BeginInvoke(null, null);
        }

        public void iConvertRFRawDataToTSW1400DataFormat()
        {
            this.m_GuiManager.Log("Converting Raw ADCData format To TSW1400 ADC Data Format Started...");
            Connection connection = GuiSettings.Default.Connection;
            Path.GetDirectoryName(Application.ExecutablePath);
            if (!string.IsNullOrEmpty(this.m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath()))
            {
                this.m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath();
            }
            else
            {
                string msg = string.Format("Please select a file to save Data Capture Raw ADC data for Post Processing", new object[0]);
                this.m_GuiManager.Log(msg);
            }
            Path.GetDirectoryName(Application.StartupPath);
            string directoryName = Path.GetDirectoryName(Application.StartupPath);
            string.Concat(new string[]
            {
                directoryName + "\\PostProc\\adc_data_Raw_0.bin"
            });
            string directoryName2 = Path.GetDirectoryName(Application.StartupPath);
            string tswformatFile = string.Concat(new string[]
            {
                directoryName2 + "\\PostProc\\adc_data_TSW1400_0.bin"
            });
            this.iPutMtLbPostProcPath(tswformatFile, true);
        }

        public void iPutMtLbPostProcPath(string TSWFormatFile, bool status)
        {
            if (base.InvokeRequired)
            {
                del_v_s_b method = new del_v_s_b(this.iPutMtLbPostProcPath);
                base.Invoke(method, new object[]
                {
                    TSWFormatFile,
                    status
                });
                return;
            }
            this.m_cboADC_DataFile.Text = TSWFormatFile;
        }

        public string m00000e()
        {
            if (base.InvokeRequired)
            {
                del_s_v method = new del_s_v(this.m00000e);
                return (string)base.Invoke(method);
            }
            this.m_btnRealTime.Enabled = true;
            this.m_btnPostProc.Enabled = true;
            this.m_btnFrameStart.Enabled = true;
            this.f00016d.Enabled = true;
            return "TSW1400Enabled";
        }

        public string m00000f()
        {
            if (base.InvokeRequired)
            {
                del_s_v method = new del_s_v(this.m00000f);
                return (string)base.Invoke(method);
            }
            this.m_btnRealTime.Enabled = false;
            this.m_btnPostProc.Enabled = false;
            this.m_btnFrameStart.Enabled = false;
            this.f00016d.Enabled = false;
            return "TSW1400Disabled";
        }

        private void iStartPostProcInvoke()
        {
            this.m_MainForm.startMatlabPostProc();
        }

        private void iPostProcAsync()
        {
            new del_v_v(this.iStartPostProcInvoke).BeginInvoke(null, null);
        }

        private void m_btnPostProc_Click(object sender, EventArgs p1)
        {
            this.iDisableChirpCfgTabBtns();
            this.m_MainForm.SetOvBtEnblTimer(true);
            this.iPostProcAsync();
            this.iEnableChirpCfgTabBtns();
            this.m_MainForm.SetOvBtEnblTimer(false);
        }

        private void iStartRealTimeInvoke()
        {
            this.m_MainForm.startMatlabRealTimeProc();
        }

        private void iRealTimeAsync()
        {
            new del_v_v(this.iStartRealTimeInvoke).BeginInvoke(null, null);
        }

        private void m_btnRealTime_Click(object sender, EventArgs p1)
        {
            this.iDisableChirpCfgTabBtns();
            this.m_MainForm.SetOvBtEnblTimer(true);
            if (this.iGetRealTimeBtnText() == "Real Time")
            {
                this.iSetRealTimeBtnText("Stop");
                GlobalRef.g_RealTimeTrigVar = true;
            }
            else
            {
                this.iSetRealTimeBtnText("Real Time");
                GlobalRef.g_RealTimeTrigVar = false;
            }
            this.iRealTimeAsync();
            this.iEnableChirpCfgTabBtns();
            this.m_MainForm.SetOvBtEnblTimer(false);
        }

        private void iSetPathInCombo(string path, ComboBox combo)
        {
            if (base.InvokeRequired)
            {
                del_SetPathInCombo method = new del_SetPathInCombo(this.iSetPathInCombo);
                base.Invoke(method, new object[]
                {
                    path,
                    combo
                });
                return;
            }
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            if (!combo.Items.Contains(path))
            {
                if (combo.Items.Count >= Constants.MaxPaths)
                {
                    combo.Items.Remove(combo.Items[combo.Items.Count - 1]);
                }
                combo.Items.Insert(0, path);
            }
            else
            {
                combo.Items.Remove(path);
                combo.Items.Insert(0, path);
            }
            combo.SelectedIndex = combo.FindStringExact(path);
        }

        private string iHandleBrowseFiles(string file_type, string current_path)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (!(file_type == "FW") && !(file_type == "BIN"))
            {
                if (!(file_type == "INI"))
                {
                    if (file_type == "DLL")
                    {
                        openFileDialog.Title = "Browse for DLL file";
                        openFileDialog.Filter = "DLL File (*.dll)|*.dll";
                    }
                }
                else
                {
                    openFileDialog.Title = "Browse for INI file";
                    openFileDialog.Filter = "INI File (*.ini)|*.ini";
                }
            }
            else
            {
                openFileDialog.Title = "Browse for bin file";
                openFileDialog.Filter = "Binary Files (*.bin)|*.bin";
            }
            openFileDialog.RestoreDirectory = true;
            if (!string.IsNullOrEmpty(current_path) && File.Exists(current_path))
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(current_path);
            }
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        private void m_btnMtLbPPTarget_Click(object sender, EventArgs p1)
        {
            this.m_ofdlgFrMtLbPP.InitialDirectory = "C:";
            this.m_ofdlgFrMtLbPP.RestoreDirectory = true;
            string text = this.iHandleBrowseFiles("bin", this.m_cboADC_DataFile.Text);
            if (!string.IsNullOrEmpty(text))
            {
                this.iSetPathInCombo(text, this.m_cboADC_DataFile);
            }
        }

        public string iGetMtLbPostProcPath()
        {
            if (base.InvokeRequired)
            {
                del_s_v method = new del_s_v(this.iGetMtLbPostProcPath);
                return (string)base.Invoke(method);
            }
            return this.m_cboADC_DataFile.Text;
        }

        public string getCapturePath()
        {
            if (base.InvokeRequired)
            {
                del_s_v method = new del_s_v(this.getCapturePath);
                return (string)base.Invoke(method);
            }
            return this.m_cboADC_DataFile.Text;
        }

        public void iSetMtLbPostProcPath(string text)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(this.iSetMtLbPostProcPath);
                base.Invoke(method, new object[]
                {
                    text
                });
                return;
            }
            this.m_cboADC_DataFile.Text = text;
        }

        public void MatlabPostProcPathSet(SetupObject dobject)
        {
            if (GlobalRef.f0002c5 <= dobject.capturedFiles.files.Count)
            {
                this.iSetPathInCombo(dobject.capturedFiles.fileBasePath + "\\" + dobject.capturedFiles.files[GlobalRef.f0002c5 - 1].processedFileName, this.m_cboADC_DataFile);
            }
        }

        public bool GetCapturedFilesInfo()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.GetCapturedFilesInfo);
                return (bool)base.Invoke(method);
            }
            string[] array = this.m_cboADC_DataFile.Text.Split(new char[]
            {
                '\\'
            });
            int num = array.Length;
            string text = "";
            for (int i = 0; i < num - 1; i++)
            {
                if (i != num - 2)
                {
                    text = text + array[i] + "\\";
                }
                else if (i == num - 2)
                {
                    text += array[i];
                }
            }
            if (!GlobalRef.g_4ChipCascade && !GlobalRef.g_2ChipCascade)
            {
                GlobalRef.dobject.capturedFiles.fileBasePath = text;
                GlobalRef.dobject.capturedFiles.files[GlobalRef.f0002c5 - 1].processedFileName = array[num - 1];
                GlobalRef.dobject.capturedFiles.files[GlobalRef.f0002c5 - 1].rawFileName = Path.GetFileNameWithoutExtension(GlobalRef.dobject.capturedFiles.files[GlobalRef.f0002c5 - 1].processedFileName) + "_Raw_0.bin";
                GlobalRef.dobject.capturedFiles.numFilesCollected = GlobalRef.dobject.capturedFiles.files.Count;
            }
            else
            {
                GlobalRef.dobject.capturedFiles.fileBasePath = text + "\\" + Path.GetFileNameWithoutExtension(array[num - 1]);
            }
            return true;
        }

        public int GetNumOfFilesCaptured(string adc_file_path)
        {
            int num = 0;
            string text = ".bin";
            string text2 = adc_file_path.Remove(adc_file_path.IndexOf(text), text.Length);
            string path = text2 + "_0.bin";
            if (GlobalRef.g_RFDataCaptureMode)
            {
                int num2 = 0;
                string path2 = text2 + "_Raw_0.bin";
                string text3 = text2 + "_0.bin";
                if (File.Exists(path2))
                {
                    for (int i = 0; i <= 100; i++)
                    {
                        string text4 = string.Concat(new object[]
                        {
                            text2,
                            "_Raw_",
                            i,
                            ".bin"
                        });
                        if (!File.Exists(text4))
                        {
                            break;
                        }
                        string text5 = string.Concat(new object[]
                        {
                            text2,
                            "_",
                            i,
                            ".bin"
                        });
                        DateTime lastWriteTime = File.GetLastWriteTime(path2);
                        if (File.GetLastWriteTime(text4) < lastWriteTime)
                        {
                            break;
                        }
                        num2++;
                        if (File.Exists(text5))
                        {
                            File.Delete(text5);
                        }
                        File.Move(text4, text5);
                    }
                    if (num2 == 1)
                    {
                        if (File.Exists(adc_file_path))
                        {
                            File.Delete(adc_file_path);
                        }
                        if (File.Exists(text3))
                        {
                            File.Move(text3, adc_file_path);
                        }
                    }
                }
            }
            if (File.Exists(adc_file_path))
            {
                if (File.Exists(path))
                {
                    DateTime lastWriteTime = File.GetLastWriteTime(adc_file_path);
                    if (File.GetLastWriteTime(path) > lastWriteTime)
                    {
                        num++;
                        for (int j = 1; j <= 100; j++)
                        {
                            string path3 = string.Concat(new object[]
                            {
                                text2,
                                "_",
                                j,
                                ".bin"
                            });
                            if (!File.Exists(path3))
                            {
                                break;
                            }
                            lastWriteTime = File.GetLastWriteTime(path);
                            if (!(File.GetLastWriteTime(path3) >= lastWriteTime))
                            {
                                break;
                            }
                            num++;
                        }
                    }
                    else
                    {
                        num = 1;
                    }
                }
                else
                {
                    num = 1;
                }
            }
            else if (File.Exists(path))
            {
                num++;
                for (int k = 1; k <= 100; k++)
                {
                    string path4 = string.Concat(new object[]
                    {
                        text2,
                        "_",
                        k,
                        ".bin"
                    });
                    if (!File.Exists(path4))
                    {
                        break;
                    }
                    DateTime lastWriteTime = File.GetLastWriteTime(path);
                    if (!(File.GetLastWriteTime(path4) >= lastWriteTime))
                    {
                        break;
                    }
                    num++;
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public int GetNumOfRawFiles(string adc_file_path)
        {
            int num = 0;
            string text = ".bin";
            string text2 = adc_file_path.Remove(adc_file_path.IndexOf(text), text.Length);
            string path = text2 + "_Raw_0.bin";
            for (int i = 0; i <= 50; i++)
            {
                string path2 = string.Concat(new object[]
                {
                    text2,
                    "_Raw_",
                    i,
                    ".bin"
                });
                if (!File.Exists(path2))
                {
                    break;
                }
                DateTime lastWriteTime = File.GetLastWriteTime(path);
                if (!(File.GetLastWriteTime(path2) >= lastWriteTime))
                {
                    break;
                }
                num++;
            }
            return num;
        }

        public bool GetAdditionalCapturedFilesInfo()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.GetAdditionalCapturedFilesInfo);
                return (bool)base.Invoke(method);
            }
            string text = null;
            if (!string.IsNullOrEmpty(this.m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath()))
            {
                text = this.m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath();
            }
            int numOfRawFiles = this.m_GuiManager.MainTsForm.ChirpConfigTab.GetNumOfRawFiles(text);
            if (numOfRawFiles <= 1)
            {
                return false;
            }
            GlobalRef.dobject.capturedFiles.files[0].processedFileSummary.numZeroFillBytes = (int)GlobalRef.numZeroFillBytes[0];
            if (numOfRawFiles != 1)
            {
                string processedFileName = GlobalRef.dobject.capturedFiles.files[0].processedFileName;
                GlobalRef.dobject.capturedFiles.files[0].processedFileName = Path.GetFileNameWithoutExtension(processedFileName) + "_0.bin";
            }
            for (int i = 1; i < numOfRawFiles; i++)
            {
                Files item = new Files();
                GlobalRef.dobject.capturedFiles.files.Add(item);
                GlobalRef.dobject.capturedFiles.files[i].rawFileName = string.Concat(new object[]
                {
                    Path.GetFileNameWithoutExtension(text),
                    "_Raw_",
                    i,
                    ".bin"
                });
                GlobalRef.dobject.capturedFiles.files[i].processedFileName = string.Concat(new object[]
                {
                    Path.GetFileNameWithoutExtension(text),
                    "_",
                    i,
                    ".bin"
                });
                GlobalRef.dobject.capturedFiles.files[i].processedFileSummary = new ProcessedFileSummary();
                GlobalRef.dobject.capturedFiles.files[i].processedFileSummary.numZeroFillBytes = (int)GlobalRef.numZeroFillBytes[i];
            }
            GlobalRef.dobject.capturedFiles.numFilesCollected = GlobalRef.dobject.capturedFiles.files.Count;
            return true;
        }

        public void iSetRawDCCaptureMtLbPostProcPath(string text)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(this.iSetRawDCCaptureMtLbPostProcPath);
                base.Invoke(method, new object[]
                {
                    text
                });
                return;
            }
            this.m_cboADC_DataFile.Text = text;
        }

        public void iSetRealTimeBtnText(string text)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(this.iSetRealTimeBtnText);
                base.Invoke(method, new object[]
                {
                    text
                });
                return;
            }
            this.m_btnRealTime.Text = text;
        }

        public string iGetRealTimeBtnText()
        {
            if (base.InvokeRequired)
            {
                del_s_v method = new del_s_v(this.iGetRealTimeBtnText);
                return (string)base.Invoke(method);
            }
            return this.m_btnRealTime.Text;
        }

        public void SetTrigFrameCoutTimerPeriodicity(int period)
        {
            this.m_timerTrigFrameCout.Interval = period;
        }

        public void SetTDANumFramesTimerPeriodicity(int period)
        {
            this.m_timerTDANumFrames.Interval = period;
        }

        public void SetTrigFrameCoutTimer(bool enable)
        {
            if (base.InvokeRequired)
            {
                del_v_b method = new del_v_b(this.SetTrigFrameCoutTimer);
                base.Invoke(method, new object[]
                {
                    enable
                });
                return;
            }
            if (enable)
            {
                this.m_timerTrigFrameCout.Start();
                return;
            }
            this.m_timerTrigFrameCout.Stop();
        }

        public void SetTDANumFramesTimer(bool enable)
        {
            if (base.InvokeRequired)
            {
                del_v_b method = new del_v_b(this.SetTDANumFramesTimer);
                base.Invoke(method, new object[]
                {
                    enable
                });
                return;
            }
            if (enable)
            {
                this.m_timerTDANumFrames.Start();
                return;
            }
            this.m_timerTDANumFrames.Stop();
        }

        private void m_timerTrigFrameCout_Tick(object sender, EventArgs p1)
        {
            if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
            {
                GlobalRef.g_RadarDeviceId = 1U;
                this.m_GuiManager.ScriptOps.iSetStopFrame_InCascadeMode_Impl(1);
                return;
            }
            this.m_GuiManager.ScriptOps.iSetStopFrame_Impl(1);
        }

        private void m_timerTDANumFrames_Tick(object sender, EventArgs p1)
        {
            if ((GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade) && GlobalRef.f0002d2)
            {
                this.m_MainForm.ChirpConfigTab.SetTDANumFramesTimer(false);
                GlobalRef.f0002c8 = 0U;
                if (Imports.stopRecord() == 0)
                {
                    string msg = string.Format("Status: Passed for notifying TDA about Stop Frame", new object[0]);
                    GlobalRef.LuaWrapper.PrintWarning(msg);
                    GlobalRef.f0002d2 = false;
                    return;
                }
                string msg2 = string.Format("Status: Failed for notifying TDA about Stop Frame", new object[0]);
                GlobalRef.LuaWrapper.PrintError(msg2);
            }
        }

        public bool iHandleDownloadFilesProgress(bool ext)
        {
            return new WinSCPTransfer().ShowDialog() == DialogResult.OK;
        }

        private void m_chbTxCfg1_CheckedChanged(object sender, EventArgs p1)
        {
        }

        private void ChirpConfigTab_Load(object sender, EventArgs p1)
        {
        }

        private void m_nudStartFreqConst_ValueChanged(object sender, EventArgs p1)
        {
            if (GlobalRef.g_ARDeviceOperateFreq60GHz)
            {
                double value = (uint)Math.Round((double)this.m_nudStartFreqConst.Value * 67108864.0 / 2.7) * 2.7 / 67108864.0;
                this.m_nudStartFreqConst.Value = (decimal)value;
                return;
            }
            double value2 = (uint)Math.Round((double)this.m_nudStartFreqConst.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
            this.m_nudStartFreqConst.Value = (decimal)value2;
        }

        public int StartFreqMinAndMaxSet_Gui()
        {
            if (GlobalRef.g_ARDeviceOperateFreq60GHz)
            {
                this.m_nudStartFreqConst.Minimum = 45m;
                this.m_nudStartFreqConst.Maximum = 100m;
                this.m_nudStartFreqConst.Value = 60m;
                this.m_nudFreqSlopeConst.Minimum = -1000m;
                this.m_nudFreqSlopeConst.Maximum = 1000m;
                this.m_nudFreqSlopeConst.Value = 29.982m;
                this.m_cboProfileVCOSelect.SelectedIndex = 1;
            }
            else
            {
                this.m_nudStartFreqConst.Minimum = 0m;
                this.m_nudStartFreqConst.Maximum = 81m;
                this.m_nudStartFreqConst.Value = 77m;
                this.m_nudFreqSlopeConst.Minimum = -327m;
                this.m_nudFreqSlopeConst.Maximum = 327m;
                this.m_nudFreqSlopeConst.Value = 29.982m;
            }
            return 0;
        }

        private void m_nudFreqSlopeConst_ValueChanged(object sender, EventArgs p1)
        {
            if (GlobalRef.g_ARDeviceOperateFreq60GHz)
            {
                double value = (double)((short)Math.Round((double)this.m_nudFreqSlopeConst.Value * 27.61681646090535)) * 2430000.0 / 67108864.0;
                this.m_nudFreqSlopeConst.Value = (decimal)Math.Round(value, 3);
                double num = Math.Abs(Math.Round(value, 3));
                this.m_lblBandwidth.Text = Math.Round(num * (double)this.m_nudRampEndTime.Value, 2).ToString();
                return;
            }
            double value2 = (double)((short)Math.Round((double)this.m_nudFreqSlopeConst.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
            this.m_nudFreqSlopeConst.Value = (decimal)Math.Round(value2, 3);
            double num2 = Math.Abs(Math.Round(value2, 3));
            this.m_lblBandwidth.Text = Math.Round(num2 * (double)this.m_nudRampEndTime.Value, 2).ToString();
        }

        private void m_nudIdleTimeConst_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Floor((double)this.m_nudIdleTimeConst.Value * 100.0) / 100.0;
            this.m_nudIdleTimeConst.Value = (decimal)value;
        }

        private void m_nudTxStartTime_ValueChanged(object sender, EventArgs p1)
        {
            double value = (double)((int)Math.Floor((double)this.m_nudTxStartTime.Value * 100.0)) / 100.0;
            this.m_nudTxStartTime.Value = (decimal)value;
        }

        private void m_nudAdcStartTimeConst_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Floor((double)this.m_nudAdcStartTimeConst.Value * 100.0) / 100.0;
            this.m_nudAdcStartTimeConst.Value = (decimal)value;
        }

        private void m_nudRampEndTime_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)this.m_nudRampEndTime.Value * 100.0) / 100.0;
            this.m_nudRampEndTime.Value = (decimal)value;
            double num = (double)Math.Abs(this.m_nudFreqSlopeConst.Value);
            this.m_lblBandwidth.Text = Math.Round(num * (double)this.m_nudRampEndTime.Value, 2).ToString();
        }

        private void m_nudTx1PhaseShifter_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)(Math.Round((double)this.m_nudTx1PhaseShifter.Value * 256.0) / 360.0) * 360.0 / 256.0;
            this.m_nudTx1PhaseShifter.Value = (decimal)value;
        }

        private void m_nudTx2PhaseShifter_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)(Math.Round((double)this.m_nudTx2PhaseShifter.Value * 256.0) / 360.0) * 360.0 / 256.0;
            this.m_nudTx2PhaseShifter.Value = (decimal)value;
        }

        private void m_nudTx3PhaseShifter_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)(Math.Round((double)this.m_nudTx3PhaseShifter.Value * 256.0) / 360.0) * 360.0 / 256.0;
            this.m_nudTx3PhaseShifter.Value = (decimal)value;
        }

        private void m_nudChirpIdleTime_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)this.m_nudChirpIdleTime.Value * 100.0) / 100.0;
            this.m_nudChirpIdleTime.Value = (decimal)value;
        }

        private void m_nudChirpAdcStart_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)this.m_nudChirpAdcStart.Value * 100.0) / 100.0;
            this.m_nudChirpAdcStart.Value = (decimal)value;
        }

        private void m_nudFrameTriggerDelay_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)this.m_nudFrameTriggerDelay.Value * 200.0) / 200.0;
            this.m_nudFrameTriggerDelay.Value = (decimal)value;
        }

        private void m_nudFramePeriodicity_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)this.m_nudFramePeriodicity.Value * 2.0 * 100000.0) / 200000.0;
            this.m_nudFramePeriodicity.Value = (decimal)value;
            ushort chirpStartIdx = (ushort)this.m_nudFrameStartChirp.Value;
            ushort chirpEndIdx = (ushort)this.m_nudFrameEndChirp.Value;
            ushort noOfLoops = (ushort)this.m_nudFrameLoops.Value;
            float num = (float)this.m_nudFramePeriodicity.Value;
            float num2 = this.m_GuiManager.ScriptOps.CalculateFrameOnTimeForFrame(chirpStartIdx, chirpEndIdx, (uint)noOfLoops);
            float num3 = this.m_GuiManager.ScriptOps.CalculateRampOnTimeForFrame(chirpStartIdx, chirpEndIdx, (uint)noOfLoops);
            this.m_MainForm.ChirpConfigTab.UpdateFrameDutyCycle(Convert.ToString(Math.Round((double)(num2 / num * 100f), 1)));
            this.m_MainForm.ChirpConfigTab.UpdateFrameActiveRampDutyCycle(Convert.ToString(Math.Round((double)(num3 / num * 100f), 1)));
        }

        private void m_nudProfileProfileId_ValueChanged(object sender, EventArgs p1)
        {
            if (this.m_nudProfileProfileId.Value >= 4m)
            {
                this.m_nudProfileProfileId.Value = 3m;
            }
        }

        private void m_nudProfileRxGain_ValueChanged_1(object sender, EventArgs p1)
        {
            if (this.m_nudProfileRxGain.Value >= 48m)
            {
                this.m_nudProfileRxGain.Value = 48m;
            }
        }

        private void m_nudChirpStartFreq_ValueChanged(object sender, EventArgs p1)
        {
            double value = (uint)Math.Round((double)this.m_nudChirpStartFreq.Value * 67108864.0 / 3600.0) * 3600.0 / 67108864.0;
            this.m_nudChirpStartFreq.Value = (decimal)value;
        }

        private void m_nudChirpFreqSlope_ValueChanged(object sender, EventArgs p1)
        {
            double value = (double)((ushort)Math.Round((double)this.m_nudChirpFreqSlope.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
            this.m_nudChirpFreqSlope.Value = (decimal)value;
        }

        public void enableChirpTxChannel1()
        {
            this.EnableControl_Rec(true, this.f00016c);
        }

        public void EnableControl_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.EnableControl_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                if (this.m_ChirpConfigParams.TX1Channel == 1)
                {
                    this.f00016c.Checked = true;
                }
                this.f00016c.Enabled = true;
                return;
            }
            this.f00016c.Checked = false;
        }

        public void disableChirpTxChannel1()
        {
            this.disableControl_Rec(true, this.f00016c);
        }

        public void disableControl_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableControl_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00016c.Checked = false;
                this.f00016c.Enabled = false;
                return;
            }
            this.f00016c.Checked = true;
        }

        public void enableChirpTxChannel2()
        {
            this.EnableControl_Rec2(true, this.f00016b);
        }

        public void EnableControl_Rec2(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.EnableControl_Rec2);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                if (this.m_ChirpConfigParams.TX1Channel == 1)
                {
                    this.f00016b.Checked = false;
                }
                else if (this.m_ChirpConfigParams.TX2Channel == 1)
                {
                    this.f00016b.Checked = true;
                }
                this.f00016b.Enabled = true;
                return;
            }
            this.f00016b.Checked = false;
        }

        public void disableChirpTxChannel2()
        {
            this.disableControl_Rec2(true, this.f00016b);
        }

        public void disableControl_Rec2(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableControl_Rec2);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00016b.Checked = false;
                this.f00016b.Enabled = false;
                return;
            }
            this.f00016b.Checked = true;
        }

        public void enableChirpTxChannel3()
        {
            this.EnableControl_Rec3(true, this.f00016a);
        }

        public void EnableControl_Rec3(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.EnableControl_Rec3);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                if (this.m_ChirpConfigParams.TX1Channel == 1)
                {
                    this.f00016a.Checked = false;
                }
                else if (this.m_ChirpConfigParams.TX2Channel == 1)
                {
                    this.f00016a.Checked = false;
                }
                else if (this.m_ChirpConfigParams.TX3Channel == 1)
                {
                    this.f00016a.Checked = true;
                }
                this.f00016a.Enabled = true;
                return;
            }
            this.f00016a.Checked = false;
        }

        public void disableChirpTxChannel3()
        {
            this.disableControl_Rec3(true, this.f00016a);
        }

        public void disableControl_Rec3(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.disableControl_Rec3);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is CheckBox)
            {
                this.f00016a.Checked = false;
                this.f00016a.Enabled = false;
                return;
            }
            this.f00016a.Checked = true;
        }

        public void UpdateFrameDutyCycle(string FrameDutyCycle)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(this.UpdateFrameDutyCycle);
                base.Invoke(method, new object[]
                {
                    FrameDutyCycle
                });
                return;
            }
            this.m_lblFrameDutyCycle.Text = FrameDutyCycle + " %";
        }

        public void UpdateFrameActiveRampDutyCycle(string FrameActiveRampDutyCycle)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(this.UpdateFrameActiveRampDutyCycle);
                base.Invoke(method, new object[]
                {
                    FrameActiveRampDutyCycle
                });
                return;
            }
            this.m_lblFrameActiveRampDutyCycle.Text = FrameActiveRampDutyCycle + " %";
        }

        private void m_nudFrameStartChirpTxFreqSlope_ValueChanged(object sender, EventArgs p1)
        {
            ushort chirpStartIdx = (ushort)this.m_nudFrameStartChirp.Value;
            ushort chirpEndIdx = (ushort)this.m_nudFrameEndChirp.Value;
            ushort noOfLoops = (ushort)this.m_nudFrameLoops.Value;
            float num = (float)this.m_nudFramePeriodicity.Value;
            float num2 = this.m_GuiManager.ScriptOps.CalculateFrameOnTimeForFrame(chirpStartIdx, chirpEndIdx, (uint)noOfLoops);
            float num3 = this.m_GuiManager.ScriptOps.CalculateRampOnTimeForFrame(chirpStartIdx, chirpEndIdx, (uint)noOfLoops);
            this.m_MainForm.ChirpConfigTab.UpdateFrameDutyCycle(Convert.ToString(Math.Round((double)(num2 / num * 100f), 1)));
            this.m_MainForm.ChirpConfigTab.UpdateFrameActiveRampDutyCycle(Convert.ToString(Math.Round((double)(num3 / num * 100f), 1)));
        }

        private void m_nudFrameEndChirpTx_ValueChanged(object sender, EventArgs p1)
        {
            ushort chirpStartIdx = (ushort)this.m_nudFrameStartChirp.Value;
            ushort chirpEndIdx = (ushort)this.m_nudFrameEndChirp.Value;
            ushort noOfLoops = (ushort)this.m_nudFrameLoops.Value;
            float num = (float)this.m_nudFramePeriodicity.Value;
            float num2 = this.m_GuiManager.ScriptOps.CalculateFrameOnTimeForFrame(chirpStartIdx, chirpEndIdx, (uint)noOfLoops);
            float num3 = this.m_GuiManager.ScriptOps.CalculateRampOnTimeForFrame(chirpStartIdx, chirpEndIdx, (uint)noOfLoops);
            this.m_MainForm.ChirpConfigTab.UpdateFrameDutyCycle(Convert.ToString(Math.Round((double)(num2 / num * 100f), 1)));
            this.m_MainForm.ChirpConfigTab.UpdateFrameActiveRampDutyCycle(Convert.ToString(Math.Round((double)(num3 / num * 100f), 1)));
        }

        private void m_nudFrameNoOfChirpsLoops_ValueChanged(object sender, EventArgs p1)
        {
            ushort chirpStartIdx = (ushort)this.m_nudFrameStartChirp.Value;
            ushort chirpEndIdx = (ushort)this.m_nudFrameEndChirp.Value;
            ushort noOfLoops = (ushort)this.m_nudFrameLoops.Value;
            float num = (float)this.m_nudFramePeriodicity.Value;
            float num2 = this.m_GuiManager.ScriptOps.CalculateFrameOnTimeForFrame(chirpStartIdx, chirpEndIdx, (uint)noOfLoops);
            float num3 = this.m_GuiManager.ScriptOps.CalculateRampOnTimeForFrame(chirpStartIdx, chirpEndIdx, (uint)noOfLoops);
            this.m_MainForm.ChirpConfigTab.UpdateFrameDutyCycle(Convert.ToString(Math.Round((double)(num2 / num * 100f), 1)));
            this.m_MainForm.ChirpConfigTab.UpdateFrameActiveRampDutyCycle(Convert.ToString(Math.Round((double)(num3 / num * 100f), 1)));
        }

        private void m_nudNumOfProfileCSampleRate_ValueChanged(object sender, EventArgs p1)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs p1)
        {
        }

        public bool UpdateDynamicPowerSaveConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateDynamicPowerSaveConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_DynamicPowerSaveConfigParams.BloclCfgTX = (ushort)(this.m_chbDynamicPowerSaveTx.Checked ? 1 : 0);
                this.m_DynamicPowerSaveConfigParams.BloclCfgRX = (ushort)(this.m_chbDynamicPowerSaveRx.Checked ? 1 : 0);
                this.m_DynamicPowerSaveConfigParams.BloclCfgLODist = (ushort)(this.m_chbDynamicPowerSaveLO.Checked ? 1 : 0);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateDynamicPowerSaveConfigDataFrmCmd()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateDynamicPowerSaveConfigDataFrmCmd);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_chbDynamicPowerSaveTx.Checked = (this.m_DynamicPowerSaveConfigParams.BloclCfgTX == 1);
                this.m_chbDynamicPowerSaveRx.Checked = (this.m_DynamicPowerSaveConfigParams.BloclCfgRX == 1);
                this.m_chbDynamicPowerSaveLO.Checked = (this.m_DynamicPowerSaveConfigParams.BloclCfgLODist == 1);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private int iSetDynamicPowerSaveConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetDynamicPowerSaveConfig_Gui(is_starting_op, is_ending_op);
        }

        public void iSetDynamicPowerSaveConfig()
        {
            this.iSetDynamicPowerSaveConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        private void m_btnDynamicPowerSaveSet_Click(object sender, EventArgs p1)
        {
            new del_v_v(this.iSetDynamicPowerSaveConfig).BeginInvoke(null, null);
        }

        public void EnableProfileProgFiltFor16XXARDevice()
        {
            if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device || GlobalRef.g_AR6843Device || GlobalRef.g_AR1843Device)
            {
                this.f00016a.Enabled = true;
                this.m_nudTx3OutPowerBackoffCode.Enabled = true;
                this.m_nudTx3PhaseShifter.Enabled = true;
                return;
            }
            if (GlobalRef.g_AR16xxDevice)
            {
                this.f00016a.Enabled = false;
                this.m_nudTx3OutPowerBackoffCode.Enabled = false;
                this.m_nudTx3PhaseShifter.Enabled = false;
            }
        }

        public bool UdateTestSourceStatus()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UdateTestSourceStatus);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                if (GlobalRef.g_TestSource == 1U)
                {
                    this.m_chbTestSourceEnable.Checked = true;
                }
                else
                {
                    this.m_chbTestSourceEnable.Checked = false;
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

        private int iSetInterRxGainPhaseFreqControlConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetInterRxGainPhaseFreqControlConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetInterRxGainPhaseFreqControlConfig()
        {
            this.iSetInterRxGainPhaseFreqControlConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void iSetInterRxGainPhaseFreqControlConfigAsync()
        {
            new del_v_v(this.iSetInterRxGainPhaseFreqControlConfig).BeginInvoke(null, null);
        }

        private void m_btnInterRxGainPhaseFreqControlSet_Click(object sender, EventArgs p1)
        {
            this.iSetInterRxGainPhaseFreqControlConfigAsync();
        }

        public bool UpdateInterRxGainPhaseFreqControlConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateInterRxGainPhaseFreqControlConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_InterRxGainPhaseFreqControlConfigParameters.ProfileIndex = (char)this.m_nudInterRxGainPhaseProfileIndex.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx1DigitalGain = (double)this.m_nudInterRxGainPhaseDigitalRx1Gain.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx2DigitalGain = (double)this.m_nudInterRxGainPhaseDigitalRx2Gain.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx3DigitalGain = (double)this.m_nudInterRxGainPhaseDigitalRx3Gain.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx4DigitalGain = (double)this.m_nudInterRxGainPhaseDigitalRx4Gain.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx1DigitalPhaseShift = (double)this.m_nudInterRxGainPhaseDigitalRx1PhaseShift.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx2DigitalPhaseShift = (double)this.m_nudInterRxGainPhaseDigitalRx2PhaseShift.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx3DigitalPhaseShift = (double)this.m_nudInterRxGainPhaseDigitalRx3PhaseShift.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx4DigitalPhaseShift = (double)this.m_nudInterRxGainPhaseDigitalRx4PhaseShift.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx1DigitalFreqShift = (double)this.m_nudInterRxGainPhaseDigitalRx1FreqShift.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx2DigitalFreqShift = (double)this.m_nudInterRxGainPhaseDigitalRx2FreqShift.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx3DigitalFreqShift = (double)this.m_nudInterRxGainPhaseDigitalRx3FreqShift.Value;
                this.m_InterRxGainPhaseFreqControlConfigParameters.Rx4DigitalFreqShift = (double)this.m_nudInterRxGainPhaseDigitalRx4FreqShift.Value;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateInterRxGainPhaseFreqControlConfigDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateInterRxGainPhaseFreqControlConfigDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_nudInterRxGainPhaseProfileIndex.Value = this.m_InterRxGainPhaseFreqControlConfigParameters.ProfileIndex;
                this.m_nudInterRxGainPhaseDigitalRx1Gain.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx1DigitalGain;
                this.m_nudInterRxGainPhaseDigitalRx2Gain.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx2DigitalGain;
                this.m_nudInterRxGainPhaseDigitalRx3Gain.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx3DigitalGain;
                this.m_nudInterRxGainPhaseDigitalRx4Gain.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx4DigitalGain;
                this.m_nudInterRxGainPhaseDigitalRx1PhaseShift.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx1DigitalPhaseShift;
                this.m_nudInterRxGainPhaseDigitalRx2PhaseShift.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx2DigitalPhaseShift;
                this.m_nudInterRxGainPhaseDigitalRx3PhaseShift.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx3DigitalPhaseShift;
                this.m_nudInterRxGainPhaseDigitalRx4PhaseShift.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx4DigitalPhaseShift;
                this.m_nudInterRxGainPhaseDigitalRx1FreqShift.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx1DigitalFreqShift;
                this.m_nudInterRxGainPhaseDigitalRx2FreqShift.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx2DigitalFreqShift;
                this.m_nudInterRxGainPhaseDigitalRx3FreqShift.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx3DigitalFreqShift;
                this.m_nudInterRxGainPhaseDigitalRx4FreqShift.Value = (decimal)this.m_InterRxGainPhaseFreqControlConfigParameters.Rx4DigitalFreqShift;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private void m_nudRx1DigFreqShift_ValueChanged(object sender, EventArgs p1)
        {
            short num = (short)Math.Round((double)this.m_nudInterRxGainPhaseDigitalRx1FreqShift.Value / 4.0, 0);
            this.m_nudInterRxGainPhaseDigitalRx1FreqShift.Value = (int)(num * 4);
        }

        private void m_nudRx2DigFreqShift_ValueChanged(object sender, EventArgs p1)
        {
            short num = (short)Math.Round((double)this.m_nudInterRxGainPhaseDigitalRx2FreqShift.Value / 4.0, 0);
            this.m_nudInterRxGainPhaseDigitalRx2FreqShift.Value = (int)(num * 4);
        }

        private void m_nudRx3DigFreqShift_ValueChanged(object sender, EventArgs p1)
        {
            short num = (short)Math.Round((double)this.m_nudInterRxGainPhaseDigitalRx3FreqShift.Value / 4.0, 0);
            this.m_nudInterRxGainPhaseDigitalRx3FreqShift.Value = (int)(num * 4);
        }

        private void m_nudRx4DigFreqShift_ValueChanged(object sender, EventArgs p1)
        {
            short num = (short)Math.Round((double)this.m_nudInterRxGainPhaseDigitalRx4FreqShift.Value / 4.0, 0);
            this.m_nudInterRxGainPhaseDigitalRx4FreqShift.Value = (int)(num * 4);
        }

        public bool SaveProfileConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveProfileConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetProfileConfigKeyVal("pprofileId", this.m_nudProfileProfileId.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("startFreqConst", this.m_nudStartFreqConst.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("idleTimeConst", this.m_nudIdleTimeConst.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("adcStartTimeConst", this.m_nudAdcStartTimeConst.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("rampEndTime", this.m_nudRampEndTime.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("tx1OutPowerBackoffCode", this.m_nudTx1OutPowerBackoffCode.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("tx2OutPowerBackoffCode", this.m_nudTx2OutPowerBackoffCode.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("tx3OutPowerBackoffCode", this.m_nudTx3OutPowerBackoffCode.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("tx1PhaseShifter", this.m_nudTx1PhaseShifter.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("tx2PhaseShifter", this.m_nudTx2PhaseShifter.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("tx3PhaseShifter", this.m_nudTx3PhaseShifter.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("freqSlopeConst", this.m_nudFreqSlopeConst.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("txStartTime", this.m_nudTxStartTime.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("numAdcSamples", this.m_nudNumAdcSamples.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("digOutSampleRate", this.m_nudDigOutSampleRate.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("hpfCornerFreq1", this.m_cboProfileHpf1.SelectedIndex.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("hpfCornerFreq2", this.m_cboProfileHpf2.SelectedIndex.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("rxGain", this.m_nudProfileRxGain.Value.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("rfGainTarget", this.m_cboProfileRFGainTarget.SelectedIndex.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("vcoSelect", this.m_cboProfileVCOSelect.SelectedIndex.ToString());
                ConfigurationManager.SetProfileConfigKeyVal("forceVCOSelect", (this.m_chbProfileForceVCOSelect.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetProfileConfigKeyVal("retainTxCalLUT", (this.m_chbProfileRetainTxCalLUT.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetProfileConfigKeyVal("retainRxCalLUT", (this.m_chbProfileRetainRxCalLUT.Checked ? 1 : 0).ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadProfileConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadProfileConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ushort profileId = Convert.ToUInt16(ConfigurationManager.GetProfileConfigKeyVal("pprofileId"));
                float startFreqConst = Convert.ToSingle(ConfigurationManager.GetProfileConfigKeyVal("startFreqConst"));
                float idleTimeConst = Convert.ToSingle(ConfigurationManager.GetProfileConfigKeyVal("idleTimeConst"));
                float adcStartTimeConst = Convert.ToSingle(ConfigurationManager.GetProfileConfigKeyVal("adcStartTimeConst"));
                float rampEndTime = Convert.ToSingle(ConfigurationManager.GetProfileConfigKeyVal("rampEndTime"));
                uint tx1OutPowerBackoffCode = Convert.ToUInt32(ConfigurationManager.GetProfileConfigKeyVal("tx1OutPowerBackoffCode"));
                uint tx2OutPowerBackoffCode = Convert.ToUInt32(ConfigurationManager.GetProfileConfigKeyVal("tx2OutPowerBackoffCode"));
                uint tx3OutPowerBackoffCode = Convert.ToUInt32(ConfigurationManager.GetProfileConfigKeyVal("tx3OutPowerBackoffCode"));
                ushort tx1PhaseShifter = Convert.ToUInt16(ConfigurationManager.GetProfileConfigKeyVal("tx1PhaseShifter"));
                ushort tx2PhaseShifter = Convert.ToUInt16(ConfigurationManager.GetProfileConfigKeyVal("tx2PhaseShifter"));
                ushort tx3PhaseShifter = Convert.ToUInt16(ConfigurationManager.GetProfileConfigKeyVal("tx3PhaseShifter"));
                float freqSlopeConst = Convert.ToSingle(ConfigurationManager.GetProfileConfigKeyVal("freqSlopeConst"));
                float txStartTime = Convert.ToSingle(ConfigurationManager.GetProfileConfigKeyVal("txStartTime"));
                ushort numAdcSamples = Convert.ToUInt16(ConfigurationManager.GetProfileConfigKeyVal("numAdcSamples"));
                ushort digOutSampleRate = Convert.ToUInt16(ConfigurationManager.GetProfileConfigKeyVal("digOutSampleRate"));
                ushort hpfCornerFreq = Convert.ToUInt16(ConfigurationManager.GetProfileConfigKeyVal("hpfCornerFreq1"));
                ushort hpfCornerFreq2 = Convert.ToUInt16(ConfigurationManager.GetProfileConfigKeyVal("hpfCornerFreq2"));
                ushort rxGain = Convert.ToUInt16(ConfigurationManager.GetProfileConfigKeyVal("rxGain"));
                byte rfGainTarget = Convert.ToByte(ConfigurationManager.GetProfileConfigKeyVal("rfGainTarget"));
                byte vcoSelect = Convert.ToByte(ConfigurationManager.GetProfileConfigKeyVal("vcoSelect"));
                byte forceVCOSelect = Convert.ToByte(ConfigurationManager.GetProfileConfigKeyVal("forceVCOSelect"));
                byte retainTxCalLUT = Convert.ToByte(ConfigurationManager.GetProfileConfigKeyVal("retainTxCalLUT"));
                byte retainRxCalLUT = Convert.ToByte(ConfigurationManager.GetProfileConfigKeyVal("retainRxCalLUT"));
                this.m_GuiManager.ScriptOps.UpdateProfileConfData(profileId, startFreqConst, idleTimeConst, adcStartTimeConst, rampEndTime, tx1OutPowerBackoffCode, tx2OutPowerBackoffCode, tx3OutPowerBackoffCode, tx1PhaseShifter, tx2PhaseShifter, tx3PhaseShifter, freqSlopeConst, txStartTime, numAdcSamples, digOutSampleRate, (char)hpfCornerFreq, (char)hpfCornerFreq2, (char)rxGain, rfGainTarget, vcoSelect, forceVCOSelect, retainTxCalLUT, retainRxCalLUT);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveChirpConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveChirpConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetChirpConfigKeyVal("chirpStartIdx", this.m_nudChirpStartIdx.Value.ToString());
                ConfigurationManager.SetChirpConfigKeyVal("chirpEndIdx", this.m_nudChirpEnd.Value.ToString());
                ConfigurationManager.SetChirpConfigKeyVal("cprofileId", this.m_nudChirpProfileId.Value.ToString());
                ConfigurationManager.SetChirpConfigKeyVal("startFreqVar", this.m_nudChirpStartFreq.Value.ToString());
                ConfigurationManager.SetChirpConfigKeyVal("freqSlopeVar", this.m_nudChirpFreqSlope.Value.ToString());
                ConfigurationManager.SetChirpConfigKeyVal("idleTimeVar", this.m_nudChirpIdleTime.Value.ToString());
                ConfigurationManager.SetChirpConfigKeyVal("adcStartTimeVar", this.m_nudChirpAdcStart.Value.ToString());
                ConfigurationManager.SetChirpConfigKeyVal("tx1Enable", (this.f00016c.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetChirpConfigKeyVal("tx2Enable", (this.f00016b.Checked ? 1 : 0).ToString());
                ConfigurationManager.SetChirpConfigKeyVal("tx3Enable", (this.f00016a.Checked ? 1 : 0).ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadChirpConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadChirpConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ushort chirpStartIdx = Convert.ToUInt16(ConfigurationManager.GetChirpConfigKeyVal("chirpStartIdx"));
                ushort chirpEndIdx = Convert.ToUInt16(ConfigurationManager.GetChirpConfigKeyVal("chirpEndIdx"));
                ushort profileId = Convert.ToUInt16(ConfigurationManager.GetChirpConfigKeyVal("cprofileId"));
                uint num = Convert.ToUInt32(ConfigurationManager.GetChirpConfigKeyVal("startFreqVar"));
                float freqSlopeVar = Convert.ToSingle(ConfigurationManager.GetChirpConfigKeyVal("freqSlopeVar"));
                ushort num2 = Convert.ToUInt16(ConfigurationManager.GetChirpConfigKeyVal("idleTimeVar"));
                ushort num3 = Convert.ToUInt16(ConfigurationManager.GetChirpConfigKeyVal("adcStartTimeVar"));
                ushort tx1Enable = Convert.ToUInt16(ConfigurationManager.GetChirpConfigKeyVal("tx1Enable"));
                ushort tx2Enable = Convert.ToUInt16(ConfigurationManager.GetChirpConfigKeyVal("tx2Enable"));
                ushort tx3Enable = Convert.ToUInt16(ConfigurationManager.GetChirpConfigKeyVal("tx3Enable"));
                this.m_GuiManager.ScriptOps.UpdateChirpConfData(chirpStartIdx, chirpEndIdx, profileId, num, freqSlopeVar, (float)num2, (float)num3, tx1Enable, tx2Enable, tx3Enable);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool SaveFrameConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.SaveFrameConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ConfigurationManager.SetFrameConfigKeyVal("fchirpStartIdx", this.m_nudFrameStartChirp.Value.ToString());
                ConfigurationManager.SetFrameConfigKeyVal("fchirpEndIdx", this.m_nudFrameEndChirp.Value.ToString());
                ConfigurationManager.SetFrameConfigKeyVal("frameCount", this.m_nudFrameNumbers.Value.ToString());
                ConfigurationManager.SetFrameConfigKeyVal("loopCount", this.m_nudFrameLoops.Value.ToString());
                ConfigurationManager.SetFrameConfigKeyVal("periodicity", this.m_nudFramePeriodicity.Value.ToString());
                ConfigurationManager.SetFrameConfigKeyVal("triggerDelay", this.m_nudFrameTriggerDelay.Value.ToString());
                ConfigurationManager.SetFrameConfigKeyVal("triggerSelect", this.m_cboFrameTriggerSelect.SelectedIndex.ToString());
                ConfigurationManager.SetFrameConfigKeyVal("testSourceEn", (this.m_chbTestSourceEnable.Checked ? 1 : 0).ToString());
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool LoadFrameConfData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.LoadFrameConfData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                ushort chirpStartIdx = Convert.ToUInt16(ConfigurationManager.GetFrameConfigKeyVal("fchirpStartIdx"));
                ushort chirpEndIdx = Convert.ToUInt16(ConfigurationManager.GetFrameConfigKeyVal("fchirpEndIdx"));
                ushort frameCount = Convert.ToUInt16(ConfigurationManager.GetFrameConfigKeyVal("frameCount"));
                ushort loopCount = Convert.ToUInt16(ConfigurationManager.GetFrameConfigKeyVal("loopCount"));
                float periodicity = Convert.ToSingle(ConfigurationManager.GetFrameConfigKeyVal("periodicity"));
                float triggerDelay = Convert.ToSingle(ConfigurationManager.GetFrameConfigKeyVal("triggerDelay"));
                ushort triggerSelect = Convert.ToUInt16(ConfigurationManager.GetFrameConfigKeyVal("triggerSelect"));
                ushort testSourceEn = Convert.ToUInt16(ConfigurationManager.GetFrameConfigKeyVal("testSourceEn"));
                this.m_GuiManager.ScriptOps.UpdateFrameConfData(chirpStartIdx, chirpEndIdx, frameCount, loopCount, periodicity, triggerDelay, triggerSelect, testSourceEn);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private int iSetRFDeviceConnectConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetDataCaptureConnectConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetRFDeviceConnectConfig()
        {
            this.iSetRFDeviceConnectConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        private void iSetRFDeviceConnectConfigAsync()
        {
            new del_v_v(this.iSetRFDeviceConnectConfig).BeginInvoke(null, null);
        }

        private void m_btnRFDevConnectSet_Click(object sender, EventArgs p1)
        {
            this.iSetRFDeviceConnectConfigAsync();
        }

        public string iEnableRFADCDataCaptureCardSetUp()
        {
            if (base.InvokeRequired)
            {
                del_s_v method = new del_s_v(this.iEnableRFADCDataCaptureCardSetUp);
                return (string)base.Invoke(method);
            }
            this.f00016d.Text = "DCA1000 ARM";
            return "DCA1000Enabled";
        }

        public string iDisableRFADCDataCaptureCardSetUp()
        {
            if (base.InvokeRequired)
            {
                del_s_v method = new del_s_v(this.iDisableRFADCDataCaptureCardSetUp);
                return (string)base.Invoke(method);
            }
            this.f00016d.Text = "TSW1400 ARM";
            return "TSW1400Enabled";
        }

        public void DisablTxChannelsDuringTxCalibForCustomer()
        {
            this.m_grpTxCalibControlTxChannel.Visible = false;
        }

        private void m_grpTxCalibControlTxChannel_Enter(object sender, EventArgs p1)
        {
        }

        private void m_grpProfile_Enter(object sender, EventArgs p1)
        {
        }

        private void m_nudPhaseShifter0Const_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTx1PhaseShifter.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTx1PhaseShifter.Text = num.ToString();
        }

        private void m_nudPhaseShifter1Const_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTx2PhaseShifter.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTx2PhaseShifter.Text = num.ToString();
        }

        private void m_nudPhaseShifter2Const_ValueChanged(object sender, EventArgs p1)
        {
            double num = (double)((short)Math.Round((double)this.m_nudTx3PhaseShifter.Value * 64.0 / 360.0)) * 360.0 / 64.0;
            this.m_nudTx3PhaseShifter.Text = num.ToString();
        }

        public bool ChangeStatusFromStartCaptureToStopCapture(bool status)
        {
            if (base.InvokeRequired)
            {
                del_b_b method = new del_b_b(this.ChangeStatusFromStartCaptureToStopCapture);
                return (bool)base.Invoke(method, new object[]
                {
                    status
                });
            }
            bool result;
            try
            {
                if (status)
                {
                    this.f00016d.Text = "StopCapture";
                }
                else
                {
                    this.f00016d.Text = "CaptureCardARM";
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

        public bool DisableAndEnableTheStartCaptureButtonTillStopCaptureFinish(bool status)
        {
            if (base.InvokeRequired)
            {
                del_b_b method = new del_b_b(this.DisableAndEnableTheStartCaptureButtonTillStopCaptureFinish);
                return (bool)base.Invoke(method, new object[]
                {
                    status
                });
            }
            bool result;
            try
            {
                if (status)
                {
                    this.f00016d.Enabled = false;
                }
                else
                {
                    this.f00016d.Enabled = true;
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

        public bool DisableAndEnableFramingStatus(bool status)
        {
            if (base.InvokeRequired)
            {
                del_b_b method = new del_b_b(this.DisableAndEnableFramingStatus);
                return (bool)base.Invoke(method, new object[]
                {
                    status
                });
            }
            bool result;
            try
            {
                if (status)
                {
                    this.m_grpFramingStatus.Visible = false;
                }
                else
                {
                    this.m_grpFramingStatus.Visible = true;
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

        public bool DisableAndEnableTriggerAndPostProcButton(bool status)
        {
            if (base.InvokeRequired)
            {
                del_b_b method = new del_b_b(this.DisableAndEnableTriggerAndPostProcButton);
                return (bool)base.Invoke(method, new object[]
                {
                    status
                });
            }
            bool result;
            try
            {
                if (status)
                {
                    this.m_btnFrameStart.Enabled = false;
                    this.m_btnPostProc.Enabled = false;
                }
                else
                {
                    this.m_btnFrameStart.Enabled = true;
                    this.m_btnPostProc.Enabled = true;
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

        public bool DisableAndEnablePostProcButtonInInfiniteFrameMode(bool status)
        {
            if (base.InvokeRequired)
            {
                del_b_b method = new del_b_b(this.DisableAndEnablePostProcButtonInInfiniteFrameMode);
                return (bool)base.Invoke(method, new object[]
                {
                    status
                });
            }
            bool result;
            try
            {
                if (status)
                {
                    this.m_btnPostProc.Enabled = false;
                }
                else
                {
                    this.m_btnPostProc.Enabled = true;
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

        public void SetRFGainTarget()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(this.SetRFGainTarget);
                base.Invoke(method);
                return;
            }
            if (GlobalRef.g_AR2243Device)
            {
                this.m_cboProfileRFGainTarget.SelectedIndex = 1;
                return;
            }
            this.m_cboProfileRFGainTarget.SelectedIndex = 0;
        }

        private void m_nudChirpProfileId_ValueChanged(object sender, EventArgs p1)
        {
        }

        private void m_nudChirpStartIdx_ValueChanged(object sender, EventArgs p1)
        {
        }

        private void m_nudChirpEnd_ValueChanged(object sender, EventArgs p1)
        {
        }

        private void m_cboProfileHpf1_SelectedIndexChanged(object sender, EventArgs p1)
        {
        }

        private void m_nudTx1OutPowerBackoffCode_ValueChanged(object sender, EventArgs p1)
        {
        }

        private void m_nudNumAdcSamples_ValueChanged(object sender, EventArgs p1)
        {
        }

        private void m_lblProfileAdcSamples_Click(object sender, EventArgs p1)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs p1)
        {
        }

        private void m_lblProfileProfileId_Click(object sender, EventArgs p1)
        {
        }

        private void m_chbProfileForceVCOSelect_CheckedChanged(object sender, EventArgs p1)
        {
        }

        private void m_cboFrameTriggerSelect_SelectedIndexChanged(object sender, EventArgs p1)
        {
        }

        private void m_cboProfileVCOSelect_SelectedIndexChanged(object sender, EventArgs p1)
        {
        }

        private void m_chbTestSourceEnable_CheckedChanged(object sender, EventArgs p1)
        {
        }

        private void m_btnTransferFiles_Click(object sender, EventArgs p1)
        {
            this.TransferFilesUsingWinSCPAsync();
        }

        public void TransferFilesUsingWinSCPAsync()
        {
            new del_v_v(this.SetTransferFilesUsingWinSCP).BeginInvoke(null, null);
        }

        private void SetTransferFilesUsingWinSCP()
        {
            this.iSetTransferFilesUsingWinSCP_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        private int iSetTransferFilesUsingWinSCP_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetTransferFilesUsingWinSCP_Gui(is_starting_op, is_ending_op);
        }

        public void UpdateDeviceFramingStatus(uint deviceMap, uint startStopIndx)
        {
            if (base.InvokeRequired)
            {
                del_v_i_i method = new del_v_i_i(this.UpdateDeviceFramingStatus);
                base.Invoke(method, new object[]
                {
                    deviceMap,
                    startStopIndx
                });
                return;
            }
            if (startStopIndx == 1U)
            {
                switch (deviceMap)
                {
                    case 0U:
                        this.m_lblDev1FramingStatus.Text = "FRAMING";
                        this.m_lblDev1FramingStatus.ForeColor = Color.Green;
                        this.m_lblDev2FramingStatus.Text = "FRAMING";
                        this.m_lblDev2FramingStatus.ForeColor = Color.Green;
                        this.m_lblDev3FramingStatus.Text = "FRAMING";
                        this.m_lblDev3FramingStatus.ForeColor = Color.Green;
                        this.m_lblDev4FramingStatus.Text = "FRAMING";
                        this.m_lblDev4FramingStatus.ForeColor = Color.Green;
                        this.m_btnTransferFiles.Enabled = false;
                        break;
                    case 1U:
                        this.m_lblDev2FramingStatus.Text = "WAITING FOR TRIGGER";
                        this.m_lblDev2FramingStatus.ForeColor = Color.Blue;
                        break;
                    case 2U:
                        this.m_lblDev3FramingStatus.Text = "WAITING FOR TRIGGER";
                        this.m_lblDev3FramingStatus.ForeColor = Color.Blue;
                        break;
                    case 3U:
                        this.m_lblDev4FramingStatus.Text = "WAITING FOR TRIGGER";
                        this.m_lblDev4FramingStatus.ForeColor = Color.Blue;
                        break;
                }
            }
            else if (startStopIndx == 0U)
            {
                switch (deviceMap)
                {
                    case 0U:
                        this.m_lblDev1FramingStatus.Text = "NOT FRAMING";
                        this.m_lblDev1FramingStatus.ForeColor = Color.Red;
                        this.m_lblDev2FramingStatus.Text = "WAITING FOR TRIGGER";
                        this.m_lblDev2FramingStatus.ForeColor = Color.Blue;
                        this.m_lblDev3FramingStatus.Text = "WAITING FOR TRIGGER";
                        this.m_lblDev3FramingStatus.ForeColor = Color.Blue;
                        this.m_lblDev4FramingStatus.Text = "WAITING FOR TRIGGER";
                        this.m_lblDev4FramingStatus.ForeColor = Color.Blue;
                        this.m_btnTransferFiles.Enabled = true;
                        break;
                    case 1U:
                        this.m_lblDev2FramingStatus.Text = "NOT FRAMING";
                        this.m_lblDev2FramingStatus.ForeColor = Color.Red;
                        break;
                    case 2U:
                        this.m_lblDev3FramingStatus.Text = "NOT FRAMING";
                        this.m_lblDev3FramingStatus.ForeColor = Color.Red;
                        break;
                    case 3U:
                        this.m_lblDev4FramingStatus.Text = "NOT FRAMING";
                        this.m_lblDev4FramingStatus.ForeColor = Color.Red;
                        break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (!GlobalRef.g_FrameTriggered_Cascade[i])
                {
                    if (i == 0)
                    {
                        this.m_lblDev1FramingStatus.Text = "NOT FRAMING";
                        this.m_lblDev1FramingStatus.ForeColor = Color.Red;
                    }
                    else if (i == 1)
                    {
                        this.m_lblDev2FramingStatus.Text = "NOT FRAMING";
                        this.m_lblDev2FramingStatus.ForeColor = Color.Red;
                    }
                    else if (i == 2)
                    {
                        this.m_lblDev3FramingStatus.Text = "NOT FRAMING";
                        this.m_lblDev3FramingStatus.ForeColor = Color.Red;
                    }
                    else if (i == 3)
                    {
                        this.m_lblDev4FramingStatus.Text = "NOT FRAMING";
                        this.m_lblDev4FramingStatus.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void m_btnStopFrame_Click(object sender, EventArgs p1)
        {
            this.iSetStopFrameAsync();
        }

        public void iSetStopFrameAsync()
        {
            new del_v_v(this.iSetStopFrame).BeginInvoke(null, null);
        }

        private void iSetStopFrame()
        {
            this.iSetStopFrame_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        private int iSetStopFrame_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetStopFrame_Gui((ushort)GlobalRef.g_RadarDeviceId, is_starting_op, is_ending_op);
        }

        public string iEnableTDADataCaptureCardSetUp()
        {
            if (base.InvokeRequired)
            {
                del_s_v method = new del_s_v(this.iEnableTDADataCaptureCardSetUp);
                return (string)base.Invoke(method);
            }
            this.f00016d.Text = "TDAxx ARM";
            return "TDAEnabled";
        }

        private void m_nudFileAllocation_ValueChanged(object sender, EventArgs p1)
        {
        }

        private void m_btnBasicPostProc_CheckedChanged(object sender, EventArgs p1)
        {
            if (this.m_btnBasicPostProc.Checked)
            {
                GlobalRef.g_PostProcType = 0U;
            }
        }

        private void m000010(object sender, EventArgs p1)
        {
            if (this.f00016f.Checked)
            {
                GlobalRef.g_PostProcType = 1U;
            }
        }

        private void m000011(object sender, EventArgs p1)
        {
            if (this.f00016e.Checked)
            {
                GlobalRef.g_PostProcType = 2U;
            }
        }

        private void m_btnGetTDAWidthHeight_Click(object sender, EventArgs p1)
        {
            if (!GlobalRef.g_TDACaptureCardConnectStatus)
            {
                this.m_GuiManager.Error("Not connected to TDA!");
                return;
            }
            int radarDevIndx = this.m_MainForm.getRadarDevIndx(GlobalRef.g_RadarDeviceId);
            if (!GlobalRef.g_TDAsetWidthHeightDone[radarDevIndx])
            {
                this.m_GuiManager.Error("Width and height not set for the device!");
                return;
            }
            int widthAndHeight = Imports.getWidthAndHeight((byte)GlobalRef.g_RadarDeviceId);
            if (widthAndHeight == 0)
            {
                this.m_GuiManager.RecordLog(9, "Status : Passed");
                return;
            }
            string msg = string.Format("Status : Failed with error code {0}", widthAndHeight);
            this.m_GuiManager.Error(msg);
        }

        public void SetWidthAndHeight(uint width, uint height)
        {
            if (base.InvokeRequired)
            {
                del_v_i_i method = new del_v_i_i(this.SetWidthAndHeight);
                base.Invoke(method, new object[]
                {
                    width,
                    height
                });
                return;
            }
            if (width == 0U)
            {
                this.m_txtTDACaptureWidth.Text = "-";
            }
            else
            {
                this.m_txtTDACaptureWidth.Text = width.ToString();
            }
            if (height == 0U)
            {
                this.m_txtTDACaptureHeight.Text = "-";
                return;
            }
            this.m_txtTDACaptureHeight.Text = height.ToString();
        }

        public bool DisableAndEnableWidthHeightStatus(bool status)
        {
            if (base.InvokeRequired)
            {
                del_b_b method = new del_b_b(this.DisableAndEnableWidthHeightStatus);
                return (bool)base.Invoke(method, new object[]
                {
                    status
                });
            }
            bool result;
            try
            {
                if (status)
                {
                    this.m_grpTDAWidthHeight.Visible = false;
                }
                else
                {
                    this.m_grpTDAWidthHeight.Visible = true;
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

        public bool DisableAndEnableNumFilesCaptureStatus(bool status)
        {
            if (base.InvokeRequired)
            {
                del_b_b method = new del_b_b(this.DisableAndEnableNumFilesCaptureStatus);
                return (bool)base.Invoke(method, new object[]
                {
                    status
                });
            }
            bool result;
            try
            {
                if (status)
                {
                    this.m_grpEnableNumFilesCapture.Visible = false;
                }
                else
                {
                    this.m_grpEnableNumFilesCapture.Visible = true;
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

        private void m_btnTDAStopCapture_Click(object sender, EventArgs p1)
        {
            this.iStopRecordTDAAsync();
        }

        public void iStopRecordTDAAsync()
        {
            new del_v_v(this.iStopRecordTDA).BeginInvoke(null, null);
        }

        private void iStopRecordTDA()
        {
            this.StopRecordTDA();
            this.m_MainForm.GuiOpEnd(true);
        }

        public int StopRecordTDA()
        {
            int num = -1;
            if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
            {
                if (GlobalRef.f0002d2)
                {
                    this.m_MainForm.ChirpConfigTab.SetTDANumFramesTimer(false);
                    GlobalRef.f0002c8 = 0U;
                    num = Imports.stopRecord();
                    if (num == 0)
                    {
                        string msg = string.Format("Status: Passed for notifying TDA about Stop Frame", new object[0]);
                        GlobalRef.LuaWrapper.PrintWarning(msg);
                        GlobalRef.f0002d2 = false;
                    }
                    else
                    {
                        string msg2 = string.Format("Status: Failed for notifying TDA about Stop Frame", new object[0]);
                        GlobalRef.LuaWrapper.PrintError(msg2);
                    }
                    int num2 = 0;
                    while (GlobalRef.f0002c8 == 0U)
                    {
                        Thread.Sleep(300);
                        num2++;
                        if (num2 > 20)
                        {
                            string msg3 = string.Format("TDA Stop Record ACK not received!", new object[0]);
                            GlobalRef.LuaWrapper.PrintError(msg3);
                            break;
                        }
                    }
                }
                else
                {
                    string msg4 = string.Format("TDA ARM is already done!", new object[0]);
                    GlobalRef.LuaWrapper.PrintError(msg4);
                }
            }
            else
            {
                string msg5 = string.Format("Valid only for a cascade scenario!", new object[0]);
                GlobalRef.LuaWrapper.PrintError(msg5);
            }
            return num;
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
            this.components = new Container();
            this.m_chkboxMonRepGUI = new GroupBox();
            this.m_grpTDAWidthHeight = new GroupBox();
            this.m_txtTDACaptureHeight = new Label();
            this.label33 = new Label();
            this.m_txtTDACaptureWidth = new Label();
            this.m_btnGetTDAWidthHeight = new Button();
            this.label31 = new Label();
            this.m_grpFrame = new GroupBox();
            this.m_nudDummyChirpsEnd = new NumericUpDown();
            this.m_lblDummyChirps = new Label();
            this.m_lblFrameActiveRampDutyCycle = new Label();
            this.label23 = new Label();
            this.m_cboFrameTriggerSelect = new ComboBox();
            this.m_lblTriggerSelect = new Label();
            this.m_lblFrameDutyCycle = new Label();
            this.label5 = new Label();
            this.m_chbTestSourceEnable = new CheckBox();
            this.m_btnFrameSet = new Button();
            this.m_nudFrameTriggerDelay = new NumericUpDown();
            this.m_lblFrameTriggerDelay = new Label();
            this.m_nudFramePeriodicity = new NumericUpDown();
            this.m_lblFramePeriodicity = new Label();
            this.m_nudFrameLoops = new NumericUpDown();
            this.m_lblFrameLoops = new Label();
            this.m_nudFrameNumbers = new NumericUpDown();
            this.m_lblFrameNumbers = new Label();
            this.m_nudFrameEndChirp = new NumericUpDown();
            this.m_nudFrameStartChirp = new NumericUpDown();
            this.m_lblFrameEndChirp = new Label();
            this.m_lblFrameStartChirp = new Label();
            this.m_grpTxCalibControlTxChannel = new GroupBox();
            this.m_chbTX2CalibTx2 = new CheckBox();
            this.m_chbTX1CalibTx2 = new CheckBox();
            this.m_chbTX0CalibTx2 = new CheckBox();
            this.m_chbTX2CalibTx1 = new CheckBox();
            this.m_chbTX1CalibTx1 = new CheckBox();
            this.m_chbTX0CalibTx1 = new CheckBox();
            this.m_chbTX2CalibTx0 = new CheckBox();
            this.m_chbTX1CalibTx0 = new CheckBox();
            this.m_chbTX0CalibTx0 = new CheckBox();
            this.label22 = new Label();
            this.label21 = new Label();
            this.label20 = new Label();
            this.label19 = new Label();
            this.label18 = new Label();
            this.label17 = new Label();
            this.groupBox3 = new GroupBox();
            this.label13 = new Label();
            this.label12 = new Label();
            this.label11 = new Label();
            this.label10 = new Label();
            this.m_btnInterRxGainPhaseFreqControlSet = new Button();
            this.m_nudInterRxGainPhaseDigitalRx3FreqShift = new NumericUpDown();
            this.m_nudInterRxGainPhaseDigitalRx4FreqShift = new NumericUpDown();
            this.m_nudInterRxGainPhaseDigitalRx2FreqShift = new NumericUpDown();
            this.m_nudInterRxGainPhaseDigitalRx1FreqShift = new NumericUpDown();
            this.m_nudInterRxGainPhaseDigitalRx3PhaseShift = new NumericUpDown();
            this.m_nudInterRxGainPhaseDigitalRx4PhaseShift = new NumericUpDown();
            this.m_nudInterRxGainPhaseDigitalRx2PhaseShift = new NumericUpDown();
            this.m_nudInterRxGainPhaseDigitalRx1PhaseShift = new NumericUpDown();
            this.m_nudInterRxGainPhaseDigitalRx4Gain = new NumericUpDown();
            this.m_nudInterRxGainPhaseDigitalRx3Gain = new NumericUpDown();
            this.m_nudInterRxGainPhaseDigitalRx2Gain = new NumericUpDown();
            this.m_nudInterRxGainPhaseDigitalRx1Gain = new NumericUpDown();
            this.m_nudInterRxGainPhaseProfileIndex = new NumericUpDown();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label7 = new Label();
            this.label6 = new Label();
            this.m_grpDynamicPowerSave = new GroupBox();
            this.m_btnDynamicPowerSaveSet = new Button();
            this.m_chbDynamicPowerSaveLO = new CheckBox();
            this.m_chbDynamicPowerSaveRx = new CheckBox();
            this.m_chbDynamicPowerSaveTx = new CheckBox();
            this.groupBox2 = new GroupBox();
            this.m_grpPostProcOptions = new GroupBox();
            this.f00016e = new RadioButton();
            this.f00016f = new RadioButton();
            this.m_btnBasicPostProc = new RadioButton();
            this.m_btnStopFrame = new Button();
            this.m_grpFramingStatus = new GroupBox();
            this.m_lblDev4FramingStatus = new Label();
            this.m_lblDev3FramingStatus = new Label();
            this.m_lblDev2FramingStatus = new Label();
            this.m_lblDev1FramingStatus = new Label();
            this.label27 = new Label();
            this.label26 = new Label();
            this.label25 = new Label();
            this.label24 = new Label();
            this.m_btnTransferFiles = new Button();
            this.m_btnPostProc = new Button();
            this.m_cboADC_DataFile = new ComboBox();
            this.f00016d = new Button();
            this.m_btnRealTime = new Button();
            this.m_btnMtLbPPTarget = new Button();
            this.m_btnFrameStart = new Button();
            this.m_grpEnableNumFilesCapture = new GroupBox();
            this.m_ChkEnaDisablePackaging = new CheckBox();
            this.label28 = new Label();
            this.m_nudFileAllocation = new NumericUpDown();
            this.label29 = new Label();
            this.m_btnTDAStopCapture = new Button();
            this.m_nudNumFramesToCapture = new NumericUpDown();
            this.label32 = new Label();
            this.pictureBox1 = new PictureBox();
            this.m_grpProfile = new GroupBox();
            this.m_chbProfileRetainRxCalLUT = new CheckBox();
            this.m_chbProfileRetainTxCalLUT = new CheckBox();
            this.label16 = new Label();
            this.m_chbProfileForceVCOSelect = new CheckBox();
            this.m_cboProfileVCOSelect = new ComboBox();
            this.label15 = new Label();
            this.m_cboProfileRFGainTarget = new ComboBox();
            this.label14 = new Label();
            this.m_nudTx3PhaseShifter = new NumericUpDown();
            this.m_nudTx2PhaseShifter = new NumericUpDown();
            this.m_nudTx1PhaseShifter = new NumericUpDown();
            this.m_lblBandwidth = new Label();
            this.label4 = new Label();
            this.m_nudTx2OutPowerBackoffCode = new NumericUpDown();
            this.m_nudTx1OutPowerBackoffCode = new NumericUpDown();
            this.m_lblProfileTx2OpPwrBackoff = new Label();
            this.m_lblProfileTx1OpPwrBackoff = new Label();
            this.m_btnMangProfiles = new Button();
            this.label2 = new Label();
            this.label1 = new Label();
            this.m_nudProfileRxGain = new NumericUpDown();
            this.m_btnProfileSet = new Button();
            this.m_nudTxStartTime = new NumericUpDown();
            this.m_lblProfileTxStartTime = new Label();
            this.m_nudFreqSlopeConst = new NumericUpDown();
            this.m_lblProfileFreqSlope = new Label();
            this.m_lblProfilePhaseShifter = new Label();
            this.m_nudTx3OutPowerBackoffCode = new NumericUpDown();
            this.m_lblProfileTx3OpPwrBackoff = new Label();
            this.m_nudStartFreqConst = new NumericUpDown();
            this.m_lblProfileStartFreqConst = new Label();
            this.m_nudRampEndTime = new NumericUpDown();
            this.m_lblProfileRampEndTime = new Label();
            this.m_nudIdleTimeConst = new NumericUpDown();
            this.m_lblProfileIdleTime = new Label();
            this.m_nudAdcStartTimeConst = new NumericUpDown();
            this.m_lblProfileAdcStartTime = new Label();
            this.m_nudNumAdcSamples = new NumericUpDown();
            this.m_lblProfileAdcSamples = new Label();
            this.m_nudDigOutSampleRate = new NumericUpDown();
            this.m_lblProfileSampleRate = new Label();
            this.m_lblProfileRxGain = new Label();
            this.m_cboProfileHpf2 = new ComboBox();
            this.m_lblProfileHpf2 = new Label();
            this.m_cboProfileHpf1 = new ComboBox();
            this.m_lblProfileHpf1 = new Label();
            this.m_nudProfileProfileId = new NumericUpDown();
            this.m_lblProfileProfileId = new Label();
            this.m_grpChirp = new GroupBox();
            this.m_btnMangChirps = new Button();
            this.f00016a = new CheckBox();
            this.f00016b = new CheckBox();
            this.f00016c = new CheckBox();
            this.m_nudChirpAdcStart = new NumericUpDown();
            this.m_nudChirpIdleTime = new NumericUpDown();
            this.m_nudChirpStartFreq = new NumericUpDown();
            this.m_nudChirpFreqSlope = new NumericUpDown();
            this.m_nudChirpEnd = new NumericUpDown();
            this.m_nudChirpStartIdx = new NumericUpDown();
            this.m_nudChirpProfileId = new NumericUpDown();
            this.m_lblChirpTxEnable = new Label();
            this.m_lblChirpAdcStart = new Label();
            this.m_lblChirpIdleTime = new Label();
            this.m_lblChirpfreqSlope = new Label();
            this.m_lblChirpStartFreq = new Label();
            this.m_lblChirpEndIdx = new Label();
            this.m_btnChirpSet = new Button();
            this.m_lblChirpStartIdx = new Label();
            this.m_lblChirpProfileId = new Label();
            this.m_ofdlgFrMtLbPP = new SaveFileDialog();
            this.m_timerTrigFrameCout = new System.Windows.Forms.Timer(this.components);
            this.m_timerTDANumFrames = new System.Windows.Forms.Timer(this.components);
            this.m_chkboxMonRepGUI.SuspendLayout();
            this.m_grpTDAWidthHeight.SuspendLayout();
            this.m_grpFrame.SuspendLayout();
            ((ISupportInitialize)this.m_nudDummyChirpsEnd).BeginInit();
            ((ISupportInitialize)this.m_nudFrameTriggerDelay).BeginInit();
            ((ISupportInitialize)this.m_nudFramePeriodicity).BeginInit();
            ((ISupportInitialize)this.m_nudFrameLoops).BeginInit();
            ((ISupportInitialize)this.m_nudFrameNumbers).BeginInit();
            ((ISupportInitialize)this.m_nudFrameEndChirp).BeginInit();
            ((ISupportInitialize)this.m_nudFrameStartChirp).BeginInit();
            this.m_grpTxCalibControlTxChannel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx3FreqShift).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx4FreqShift).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx2FreqShift).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx1FreqShift).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx3PhaseShift).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx4PhaseShift).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx2PhaseShift).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx1PhaseShift).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx4Gain).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx3Gain).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx2Gain).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx1Gain).BeginInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseProfileIndex).BeginInit();
            this.m_grpDynamicPowerSave.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.m_grpPostProcOptions.SuspendLayout();
            this.m_grpFramingStatus.SuspendLayout();
            this.m_grpEnableNumFilesCapture.SuspendLayout();
            ((ISupportInitialize)this.m_nudFileAllocation).BeginInit();
            ((ISupportInitialize)this.m_nudNumFramesToCapture).BeginInit();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            this.m_grpProfile.SuspendLayout();
            ((ISupportInitialize)this.m_nudTx3PhaseShifter).BeginInit();
            ((ISupportInitialize)this.m_nudTx2PhaseShifter).BeginInit();
            ((ISupportInitialize)this.m_nudTx1PhaseShifter).BeginInit();
            ((ISupportInitialize)this.m_nudTx2OutPowerBackoffCode).BeginInit();
            ((ISupportInitialize)this.m_nudTx1OutPowerBackoffCode).BeginInit();
            ((ISupportInitialize)this.m_nudProfileRxGain).BeginInit();
            ((ISupportInitialize)this.m_nudTxStartTime).BeginInit();
            ((ISupportInitialize)this.m_nudFreqSlopeConst).BeginInit();
            ((ISupportInitialize)this.m_nudTx3OutPowerBackoffCode).BeginInit();
            ((ISupportInitialize)this.m_nudStartFreqConst).BeginInit();
            ((ISupportInitialize)this.m_nudRampEndTime).BeginInit();
            ((ISupportInitialize)this.m_nudIdleTimeConst).BeginInit();
            ((ISupportInitialize)this.m_nudAdcStartTimeConst).BeginInit();
            ((ISupportInitialize)this.m_nudNumAdcSamples).BeginInit();
            ((ISupportInitialize)this.m_nudDigOutSampleRate).BeginInit();
            ((ISupportInitialize)this.m_nudProfileProfileId).BeginInit();
            this.m_grpChirp.SuspendLayout();
            ((ISupportInitialize)this.m_nudChirpAdcStart).BeginInit();
            ((ISupportInitialize)this.m_nudChirpIdleTime).BeginInit();
            ((ISupportInitialize)this.m_nudChirpStartFreq).BeginInit();
            ((ISupportInitialize)this.m_nudChirpFreqSlope).BeginInit();
            ((ISupportInitialize)this.m_nudChirpEnd).BeginInit();
            ((ISupportInitialize)this.m_nudChirpStartIdx).BeginInit();
            ((ISupportInitialize)this.m_nudChirpProfileId).BeginInit();
            base.SuspendLayout();
            this.m_chkboxMonRepGUI.BackgroundImageLayout = ImageLayout.Center;
            this.m_chkboxMonRepGUI.Controls.Add(this.m_grpTDAWidthHeight);
            this.m_chkboxMonRepGUI.Controls.Add(this.m_grpFrame);
            this.m_chkboxMonRepGUI.Controls.Add(this.m_grpTxCalibControlTxChannel);
            this.m_chkboxMonRepGUI.Controls.Add(this.groupBox3);
            this.m_chkboxMonRepGUI.Controls.Add(this.m_grpDynamicPowerSave);
            this.m_chkboxMonRepGUI.Controls.Add(this.groupBox2);
            this.m_chkboxMonRepGUI.Controls.Add(this.pictureBox1);
            this.m_chkboxMonRepGUI.Controls.Add(this.m_grpProfile);
            this.m_chkboxMonRepGUI.Controls.Add(this.m_grpChirp);
            this.m_chkboxMonRepGUI.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_chkboxMonRepGUI.Location = new Point(4, 4);
            this.m_chkboxMonRepGUI.Margin = new Padding(4);
            this.m_chkboxMonRepGUI.Name = "m_chkboxMonRepGUI";
            this.m_chkboxMonRepGUI.Padding = new Padding(4);
            this.m_chkboxMonRepGUI.Size = new Size(1586, 749);
            this.m_chkboxMonRepGUI.TabIndex = 0;
            this.m_chkboxMonRepGUI.TabStop = false;
            this.m_chkboxMonRepGUI.Text = "Sensor Configuration";
            this.m_chkboxMonRepGUI.Enter += this.groupBox1_Enter;
            this.m_grpTDAWidthHeight.Controls.Add(this.m_txtTDACaptureHeight);
            this.m_grpTDAWidthHeight.Controls.Add(this.label33);
            this.m_grpTDAWidthHeight.Controls.Add(this.m_txtTDACaptureWidth);
            this.m_grpTDAWidthHeight.Controls.Add(this.m_btnGetTDAWidthHeight);
            this.m_grpTDAWidthHeight.Controls.Add(this.label31);
            this.m_grpTDAWidthHeight.Location = new Point(1107, 461);
            this.m_grpTDAWidthHeight.Name = "m_grpTDAWidthHeight";
            this.m_grpTDAWidthHeight.Size = new Size(471, 63);
            this.m_grpTDAWidthHeight.TabIndex = 61;
            this.m_grpTDAWidthHeight.TabStop = false;
            this.m_grpTDAWidthHeight.Text = "TDA Width/Height";
            this.m_grpTDAWidthHeight.Visible = false;
            this.m_txtTDACaptureHeight.AutoSize = true;
            this.m_txtTDACaptureHeight.ForeColor = Color.DodgerBlue;
            this.m_txtTDACaptureHeight.Location = new Point(222, 31);
            this.m_txtTDACaptureHeight.Margin = new Padding(4, 0, 4, 0);
            this.m_txtTDACaptureHeight.Name = "m_txtTDACaptureHeight";
            this.m_txtTDACaptureHeight.Size = new Size(13, 17);
            this.m_txtTDACaptureHeight.TabIndex = 65;
            this.m_txtTDACaptureHeight.Text = "-";
            this.label33.AutoSize = true;
            this.label33.Location = new Point(162, 31);
            this.label33.Margin = new Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new Size(49, 17);
            this.label33.TabIndex = 64;
            this.label33.Text = "Height";
            this.m_txtTDACaptureWidth.AutoSize = true;
            this.m_txtTDACaptureWidth.ForeColor = Color.DodgerBlue;
            this.m_txtTDACaptureWidth.Location = new Point(66, 31);
            this.m_txtTDACaptureWidth.Margin = new Padding(4, 0, 4, 0);
            this.m_txtTDACaptureWidth.Name = "m_txtTDACaptureWidth";
            this.m_txtTDACaptureWidth.Size = new Size(13, 17);
            this.m_txtTDACaptureWidth.TabIndex = 63;
            this.m_txtTDACaptureWidth.Text = "-";
            this.m_btnGetTDAWidthHeight.Location = new Point(320, 20);
            this.m_btnGetTDAWidthHeight.Margin = new Padding(4);
            this.m_btnGetTDAWidthHeight.Name = "m_btnGetTDAWidthHeight";
            this.m_btnGetTDAWidthHeight.Size = new Size(128, 31);
            this.m_btnGetTDAWidthHeight.TabIndex = 61;
            this.m_btnGetTDAWidthHeight.Text = "Get";
            this.m_btnGetTDAWidthHeight.UseVisualStyleBackColor = true;
            this.m_btnGetTDAWidthHeight.Click += this.m_btnGetTDAWidthHeight_Click;
            this.label31.AutoSize = true;
            this.label31.Location = new Point(11, 31);
            this.label31.Margin = new Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new Size(46, 17);
            this.label31.TabIndex = 62;
            this.label31.Text = "Width";
            this.m_grpFrame.Controls.Add(this.m_nudDummyChirpsEnd);
            this.m_grpFrame.Controls.Add(this.m_lblDummyChirps);
            this.m_grpFrame.Controls.Add(this.m_lblFrameActiveRampDutyCycle);
            this.m_grpFrame.Controls.Add(this.label23);
            this.m_grpFrame.Controls.Add(this.m_cboFrameTriggerSelect);
            this.m_grpFrame.Controls.Add(this.m_lblTriggerSelect);
            this.m_grpFrame.Controls.Add(this.m_lblFrameDutyCycle);
            this.m_grpFrame.Controls.Add(this.label5);
            this.m_grpFrame.Controls.Add(this.m_chbTestSourceEnable);
            this.m_grpFrame.Controls.Add(this.m_btnFrameSet);
            this.m_grpFrame.Controls.Add(this.m_nudFrameTriggerDelay);
            this.m_grpFrame.Controls.Add(this.m_lblFrameTriggerDelay);
            this.m_grpFrame.Controls.Add(this.m_nudFramePeriodicity);
            this.m_grpFrame.Controls.Add(this.m_lblFramePeriodicity);
            this.m_grpFrame.Controls.Add(this.m_nudFrameLoops);
            this.m_grpFrame.Controls.Add(this.m_lblFrameLoops);
            this.m_grpFrame.Controls.Add(this.m_nudFrameNumbers);
            this.m_grpFrame.Controls.Add(this.m_lblFrameNumbers);
            this.m_grpFrame.Controls.Add(this.m_nudFrameEndChirp);
            this.m_grpFrame.Controls.Add(this.m_nudFrameStartChirp);
            this.m_grpFrame.Controls.Add(this.m_lblFrameEndChirp);
            this.m_grpFrame.Controls.Add(this.m_lblFrameStartChirp);
            this.m_grpFrame.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_grpFrame.Location = new Point(584, 461);
            this.m_grpFrame.Margin = new Padding(4);
            this.m_grpFrame.Name = "m_grpFrame";
            this.m_grpFrame.Padding = new Padding(4);
            this.m_grpFrame.Size = new Size(512, 280);
            this.m_grpFrame.TabIndex = 10;
            this.m_grpFrame.TabStop = false;
            this.m_grpFrame.Text = "Frame";
            this.m_nudDummyChirpsEnd.Location = new Point(154, 150);
            this.m_nudDummyChirpsEnd.Margin = new Padding(4);
            NumericUpDown nudDummyChirpsEnd = this.m_nudDummyChirpsEnd;
            int[] array = new int[4];
            array[0] = 128;
            nudDummyChirpsEnd.Maximum = new decimal(array);
            this.m_nudDummyChirpsEnd.Name = "m_nudDummyChirpsEnd";
            this.m_nudDummyChirpsEnd.Size = new Size(89, 25);
            this.m_nudDummyChirpsEnd.TabIndex = 54;
            this.m_lblDummyChirps.AutoSize = true;
            this.m_lblDummyChirps.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblDummyChirps.Location = new Point(6, 152);
            this.m_lblDummyChirps.Margin = new Padding(4, 0, 4, 0);
            this.m_lblDummyChirps.Name = "m_lblDummyChirps";
            this.m_lblDummyChirps.Size = new Size(143, 17);
            this.m_lblDummyChirps.TabIndex = 53;
            this.m_lblDummyChirps.Text = "Dummy Chirps(End)";
            this.m_lblFrameActiveRampDutyCycle.AutoSize = true;
            this.m_lblFrameActiveRampDutyCycle.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.m_lblFrameActiveRampDutyCycle.Location = new Point(455, 155);
            this.m_lblFrameActiveRampDutyCycle.Margin = new Padding(4, 0, 4, 0);
            this.m_lblFrameActiveRampDutyCycle.Name = "m_lblFrameActiveRampDutyCycle";
            this.m_lblFrameActiveRampDutyCycle.Size = new Size(28, 18);
            this.m_lblFrameActiveRampDutyCycle.TabIndex = 52;
            this.m_lblFrameActiveRampDutyCycle.Text = "0.0";
            this.label23.AutoSize = true;
            this.label23.Location = new Point(257, 155);
            this.label23.Margin = new Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new Size(167, 17);
            this.label23.TabIndex = 51;
            this.label23.Text = "Active-Ramp Duty Cycle";
            this.m_cboFrameTriggerSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            this.m_cboFrameTriggerSelect.FormattingEnabled = true;
            this.m_cboFrameTriggerSelect.Items.AddRange(new object[]
            {
                "SoftwareTrigger",
                "HardwareTrigger"
            });
            this.m_cboFrameTriggerSelect.Location = new Point(150, 191);
            this.m_cboFrameTriggerSelect.Margin = new Padding(4);
            this.m_cboFrameTriggerSelect.Name = "m_cboFrameTriggerSelect";
            this.m_cboFrameTriggerSelect.Size = new Size(145, 25);
            this.m_cboFrameTriggerSelect.TabIndex = 50;
            this.m_lblTriggerSelect.AutoSize = true;
            this.m_lblTriggerSelect.Location = new Point(9, 196);
            this.m_lblTriggerSelect.Margin = new Padding(4, 0, 4, 0);
            this.m_lblTriggerSelect.Name = "m_lblTriggerSelect";
            this.m_lblTriggerSelect.Size = new Size(98, 17);
            this.m_lblTriggerSelect.TabIndex = 49;
            this.m_lblTriggerSelect.Text = "Trigger Select";
            this.m_lblFrameDutyCycle.AutoSize = true;
            this.m_lblFrameDutyCycle.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.m_lblFrameDutyCycle.Location = new Point(455, 188);
            this.m_lblFrameDutyCycle.Margin = new Padding(4, 0, 4, 0);
            this.m_lblFrameDutyCycle.Name = "m_lblFrameDutyCycle";
            this.m_lblFrameDutyCycle.Size = new Size(28, 18);
            this.m_lblFrameDutyCycle.TabIndex = 48;
            this.m_lblFrameDutyCycle.Text = "0.0";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(341, 188);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(79, 17);
            this.label5.TabIndex = 47;
            this.label5.Text = "Duty Cycle";
            this.m_chbTestSourceEnable.AutoSize = true;
            this.m_chbTestSourceEnable.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_chbTestSourceEnable.Location = new Point(15, 238);
            this.m_chbTestSourceEnable.Margin = new Padding(4);
            this.m_chbTestSourceEnable.Name = "m_chbTestSourceEnable";
            this.m_chbTestSourceEnable.Size = new Size(157, 21);
            this.m_chbTestSourceEnable.TabIndex = 46;
            this.m_chbTestSourceEnable.Text = "Test Source Enable";
            this.m_chbTestSourceEnable.UseVisualStyleBackColor = true;
            this.m_chbTestSourceEnable.CheckedChanged += this.m_chbTestSourceEnable_CheckedChanged;
            this.m_btnFrameSet.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_btnFrameSet.Location = new Point(366, 231);
            this.m_btnFrameSet.Margin = new Padding(4);
            this.m_btnFrameSet.Name = "m_btnFrameSet";
            this.m_btnFrameSet.Size = new Size(126, 39);
            this.m_btnFrameSet.TabIndex = 45;
            this.m_btnFrameSet.Text = "Set";
            this.m_btnFrameSet.UseVisualStyleBackColor = true;
            this.m_btnFrameSet.Click += this.m_btnFrameSet_Click;
            this.m_nudFrameTriggerDelay.DecimalPlaces = 2;
            this.m_nudFrameTriggerDelay.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudFrameTriggerDelay.Location = new Point(390, 112);
            this.m_nudFrameTriggerDelay.Margin = new Padding(4);
            this.m_nudFrameTriggerDelay.Name = "m_nudFrameTriggerDelay";
            this.m_nudFrameTriggerDelay.Size = new Size(108, 25);
            this.m_nudFrameTriggerDelay.TabIndex = 44;
            this.m_nudFrameTriggerDelay.ValueChanged += this.m_nudFrameTriggerDelay_ValueChanged;
            this.m_lblFrameTriggerDelay.AutoSize = true;
            this.m_lblFrameTriggerDelay.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblFrameTriggerDelay.Location = new Point(250, 112);
            this.m_lblFrameTriggerDelay.Margin = new Padding(4, 0, 4, 0);
            this.m_lblFrameTriggerDelay.Name = "m_lblFrameTriggerDelay";
            this.m_lblFrameTriggerDelay.Size = new Size(124, 17);
            this.m_lblFrameTriggerDelay.TabIndex = 27;
            this.m_lblFrameTriggerDelay.Text = "Trigger Delay (µs)";
            this.m_nudFramePeriodicity.DecimalPlaces = 6;
            this.m_nudFramePeriodicity.Increment = new decimal(new int[]
            {
                5,
                0,
                0,
                327680
            });
            this.m_nudFramePeriodicity.Location = new Point(390, 75);
            this.m_nudFramePeriodicity.Margin = new Padding(4);
            NumericUpDown nudFramePeriodicity = this.m_nudFramePeriodicity;
            int[] array2 = new int[4];
            array2[0] = 1342;
            nudFramePeriodicity.Maximum = new decimal(array2);
            this.m_nudFramePeriodicity.Name = "m_nudFramePeriodicity";
            this.m_nudFramePeriodicity.Size = new Size(108, 25);
            this.m_nudFramePeriodicity.TabIndex = 42;
            NumericUpDown nudFramePeriodicity2 = this.m_nudFramePeriodicity;
            int[] array3 = new int[4];
            array3[0] = 40;
            nudFramePeriodicity2.Value = new decimal(array3);
            this.m_nudFramePeriodicity.ValueChanged += this.m_nudFramePeriodicity_ValueChanged;
            this.m_lblFramePeriodicity.AutoSize = true;
            this.m_lblFramePeriodicity.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblFramePeriodicity.Location = new Point(250, 75);
            this.m_lblFramePeriodicity.Margin = new Padding(4, 0, 4, 0);
            this.m_lblFramePeriodicity.Name = "m_lblFramePeriodicity";
            this.m_lblFramePeriodicity.Size = new Size(110, 17);
            this.m_lblFramePeriodicity.TabIndex = 25;
            this.m_lblFramePeriodicity.Text = "Periodicity (ms)";
            this.m_nudFrameLoops.Location = new Point(390, 38);
            this.m_nudFrameLoops.Margin = new Padding(4);
            NumericUpDown nudFrameLoops = this.m_nudFrameLoops;
            int[] array4 = new int[4];
            array4[0] = 255;
            nudFrameLoops.Maximum = new decimal(array4);
            this.m_nudFrameLoops.Name = "m_nudFrameLoops";
            this.m_nudFrameLoops.Size = new Size(109, 25);
            this.m_nudFrameLoops.TabIndex = 40;
            NumericUpDown nudFrameLoops2 = this.m_nudFrameLoops;
            int[] array5 = new int[4];
            array5[0] = 128;
            nudFrameLoops2.Value = new decimal(array5);
            this.m_nudFrameLoops.ValueChanged += this.m_nudFrameNoOfChirpsLoops_ValueChanged;
            this.m_lblFrameLoops.AutoSize = true;
            this.m_lblFrameLoops.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblFrameLoops.Location = new Point(250, 38);
            this.m_lblFrameLoops.Margin = new Padding(4, 0, 4, 0);
            this.m_lblFrameLoops.Name = "m_lblFrameLoops";
            this.m_lblFrameLoops.Size = new Size(125, 17);
            this.m_lblFrameLoops.TabIndex = 23;
            this.m_lblFrameLoops.Text = "No of Chirp Loops";
            this.m_nudFrameNumbers.Location = new Point(154, 112);
            this.m_nudFrameNumbers.Margin = new Padding(4);
            NumericUpDown nudFrameNumbers = this.m_nudFrameNumbers;
            int[] array6 = new int[4];
            array6[0] = 65535;
            nudFrameNumbers.Maximum = new decimal(array6);
            this.m_nudFrameNumbers.Name = "m_nudFrameNumbers";
            this.m_nudFrameNumbers.Size = new Size(89, 25);
            this.m_nudFrameNumbers.TabIndex = 43;
            NumericUpDown nudFrameNumbers2 = this.m_nudFrameNumbers;
            int[] array7 = new int[4];
            array7[0] = 8;
            nudFrameNumbers2.Value = new decimal(array7);
            this.m_lblFrameNumbers.AutoSize = true;
            this.m_lblFrameNumbers.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblFrameNumbers.Location = new Point(8, 112);
            this.m_lblFrameNumbers.Margin = new Padding(4, 0, 4, 0);
            this.m_lblFrameNumbers.Name = "m_lblFrameNumbers";
            this.m_lblFrameNumbers.Size = new Size(97, 17);
            this.m_lblFrameNumbers.TabIndex = 21;
            this.m_lblFrameNumbers.Text = "No of Frames";
            this.m_nudFrameEndChirp.Location = new Point(154, 75);
            this.m_nudFrameEndChirp.Margin = new Padding(4);
            NumericUpDown nudFrameEndChirp = this.m_nudFrameEndChirp;
            int[] array8 = new int[4];
            array8[0] = 511;
            nudFrameEndChirp.Maximum = new decimal(array8);
            this.m_nudFrameEndChirp.Name = "m_nudFrameEndChirp";
            this.m_nudFrameEndChirp.Size = new Size(89, 25);
            this.m_nudFrameEndChirp.TabIndex = 41;
            this.m_nudFrameEndChirp.ValueChanged += this.m_nudFrameEndChirpTx_ValueChanged;
            this.m_nudFrameStartChirp.Location = new Point(154, 38);
            this.m_nudFrameStartChirp.Margin = new Padding(4);
            NumericUpDown nudFrameStartChirp = this.m_nudFrameStartChirp;
            int[] array9 = new int[4];
            array9[0] = 511;
            nudFrameStartChirp.Maximum = new decimal(array9);
            this.m_nudFrameStartChirp.Name = "m_nudFrameStartChirp";
            this.m_nudFrameStartChirp.Size = new Size(89, 25);
            this.m_nudFrameStartChirp.TabIndex = 39;
            this.m_nudFrameStartChirp.ValueChanged += this.m_nudFrameStartChirpTxFreqSlope_ValueChanged;
            this.m_lblFrameEndChirp.AutoSize = true;
            this.m_lblFrameEndChirp.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblFrameEndChirp.Location = new Point(8, 75);
            this.m_lblFrameEndChirp.Margin = new Padding(4, 0, 4, 0);
            this.m_lblFrameEndChirp.Name = "m_lblFrameEndChirp";
            this.m_lblFrameEndChirp.Size = new Size(95, 17);
            this.m_lblFrameEndChirp.TabIndex = 18;
            this.m_lblFrameEndChirp.Text = "End Chirp TX";
            this.m_lblFrameStartChirp.AutoSize = true;
            this.m_lblFrameStartChirp.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblFrameStartChirp.Location = new Point(8, 38);
            this.m_lblFrameStartChirp.Margin = new Padding(4, 0, 4, 0);
            this.m_lblFrameStartChirp.Name = "m_lblFrameStartChirp";
            this.m_lblFrameStartChirp.Size = new Size(100, 17);
            this.m_lblFrameStartChirp.TabIndex = 17;
            this.m_lblFrameStartChirp.Text = "Start Chirp TX";
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.m_chbTX2CalibTx2);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.m_chbTX1CalibTx2);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.m_chbTX0CalibTx2);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.m_chbTX2CalibTx1);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.m_chbTX1CalibTx1);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.m_chbTX0CalibTx1);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.m_chbTX2CalibTx0);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.m_chbTX1CalibTx0);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.m_chbTX0CalibTx0);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.label22);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.label21);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.label20);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.label19);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.label18);
            this.m_grpTxCalibControlTxChannel.Controls.Add(this.label17);
            this.m_grpTxCalibControlTxChannel.Location = new Point(1107, 536);
            this.m_grpTxCalibControlTxChannel.Margin = new Padding(4);
            this.m_grpTxCalibControlTxChannel.Name = "m_grpTxCalibControlTxChannel";
            this.m_grpTxCalibControlTxChannel.Padding = new Padding(4);
            this.m_grpTxCalibControlTxChannel.Size = new Size(252, 154);
            this.m_grpTxCalibControlTxChannel.TabIndex = 57;
            this.m_grpTxCalibControlTxChannel.TabStop = false;
            this.m_grpTxCalibControlTxChannel.Text = "TXs Enabled During TX Calib";
            this.m_grpTxCalibControlTxChannel.Enter += this.m_grpTxCalibControlTxChannel_Enter;
            this.m_chbTX2CalibTx2.AutoSize = true;
            this.m_chbTX2CalibTx2.Checked = true;
            this.m_chbTX2CalibTx2.CheckState = CheckState.Checked;
            this.m_chbTX2CalibTx2.Location = new Point(216, 113);
            this.m_chbTX2CalibTx2.Margin = new Padding(4);
            this.m_chbTX2CalibTx2.Name = "m_chbTX2CalibTx2";
            this.m_chbTX2CalibTx2.Size = new Size(18, 17);
            this.m_chbTX2CalibTx2.TabIndex = 14;
            this.m_chbTX2CalibTx2.UseVisualStyleBackColor = true;
            this.m_chbTX1CalibTx2.AutoSize = true;
            this.m_chbTX1CalibTx2.Location = new Point(216, 85);
            this.m_chbTX1CalibTx2.Margin = new Padding(4);
            this.m_chbTX1CalibTx2.Name = "m_chbTX1CalibTx2";
            this.m_chbTX1CalibTx2.Size = new Size(18, 17);
            this.m_chbTX1CalibTx2.TabIndex = 13;
            this.m_chbTX1CalibTx2.UseVisualStyleBackColor = true;
            this.m_chbTX0CalibTx2.AutoSize = true;
            this.m_chbTX0CalibTx2.Location = new Point(216, 56);
            this.m_chbTX0CalibTx2.Margin = new Padding(4);
            this.m_chbTX0CalibTx2.Name = "m_chbTX0CalibTx2";
            this.m_chbTX0CalibTx2.Size = new Size(18, 17);
            this.m_chbTX0CalibTx2.TabIndex = 12;
            this.m_chbTX0CalibTx2.UseVisualStyleBackColor = true;
            this.m_chbTX2CalibTx1.AutoSize = true;
            this.m_chbTX2CalibTx1.Location = new Point(154, 113);
            this.m_chbTX2CalibTx1.Margin = new Padding(4);
            this.m_chbTX2CalibTx1.Name = "m_chbTX2CalibTx1";
            this.m_chbTX2CalibTx1.Size = new Size(18, 17);
            this.m_chbTX2CalibTx1.TabIndex = 11;
            this.m_chbTX2CalibTx1.UseVisualStyleBackColor = true;
            this.m_chbTX1CalibTx1.AutoSize = true;
            this.m_chbTX1CalibTx1.Checked = true;
            this.m_chbTX1CalibTx1.CheckState = CheckState.Checked;
            this.m_chbTX1CalibTx1.Location = new Point(154, 85);
            this.m_chbTX1CalibTx1.Margin = new Padding(4);
            this.m_chbTX1CalibTx1.Name = "m_chbTX1CalibTx1";
            this.m_chbTX1CalibTx1.Size = new Size(18, 17);
            this.m_chbTX1CalibTx1.TabIndex = 10;
            this.m_chbTX1CalibTx1.UseVisualStyleBackColor = true;
            this.m_chbTX0CalibTx1.AutoSize = true;
            this.m_chbTX0CalibTx1.Location = new Point(154, 56);
            this.m_chbTX0CalibTx1.Margin = new Padding(4);
            this.m_chbTX0CalibTx1.Name = "m_chbTX0CalibTx1";
            this.m_chbTX0CalibTx1.Size = new Size(18, 17);
            this.m_chbTX0CalibTx1.TabIndex = 9;
            this.m_chbTX0CalibTx1.UseVisualStyleBackColor = true;
            this.m_chbTX2CalibTx0.AutoSize = true;
            this.m_chbTX2CalibTx0.Location = new Point(91, 113);
            this.m_chbTX2CalibTx0.Margin = new Padding(4);
            this.m_chbTX2CalibTx0.Name = "m_chbTX2CalibTx0";
            this.m_chbTX2CalibTx0.Size = new Size(18, 17);
            this.m_chbTX2CalibTx0.TabIndex = 8;
            this.m_chbTX2CalibTx0.UseVisualStyleBackColor = true;
            this.m_chbTX1CalibTx0.AutoSize = true;
            this.m_chbTX1CalibTx0.Location = new Point(91, 85);
            this.m_chbTX1CalibTx0.Margin = new Padding(4);
            this.m_chbTX1CalibTx0.Name = "m_chbTX1CalibTx0";
            this.m_chbTX1CalibTx0.Size = new Size(18, 17);
            this.m_chbTX1CalibTx0.TabIndex = 7;
            this.m_chbTX1CalibTx0.UseVisualStyleBackColor = true;
            this.m_chbTX0CalibTx0.AutoSize = true;
            this.m_chbTX0CalibTx0.Checked = true;
            this.m_chbTX0CalibTx0.CheckState = CheckState.Checked;
            this.m_chbTX0CalibTx0.Location = new Point(91, 56);
            this.m_chbTX0CalibTx0.Margin = new Padding(4);
            this.m_chbTX0CalibTx0.Name = "m_chbTX0CalibTx0";
            this.m_chbTX0CalibTx0.Size = new Size(18, 17);
            this.m_chbTX0CalibTx0.TabIndex = 6;
            this.m_chbTX0CalibTx0.UseVisualStyleBackColor = true;
            this.label22.AutoSize = true;
            this.label22.Location = new Point(10, 111);
            this.label22.Margin = new Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new Size(60, 17);
            this.label22.TabIndex = 5;
            this.label22.Text = "TX2 Cal";
            this.label21.AutoSize = true;
            this.label21.Location = new Point(10, 84);
            this.label21.Margin = new Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new Size(60, 17);
            this.label21.TabIndex = 4;
            this.label21.Text = "TX1 Cal";
            this.label20.AutoSize = true;
            this.label20.Location = new Point(10, 52);
            this.label20.Margin = new Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new Size(60, 17);
            this.label20.TabIndex = 3;
            this.label20.Text = "TX0 Cal";
            this.label19.AutoSize = true;
            this.label19.Location = new Point(207, 27);
            this.label19.Margin = new Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new Size(34, 17);
            this.label19.TabIndex = 2;
            this.label19.Text = "TX2";
            this.label18.AutoSize = true;
            this.label18.Location = new Point(145, 27);
            this.label18.Margin = new Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new Size(34, 17);
            this.label18.TabIndex = 1;
            this.label18.Text = "TX1";
            this.label17.AutoSize = true;
            this.label17.Location = new Point(83, 27);
            this.label17.Margin = new Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new Size(34, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "TX0";
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.m_btnInterRxGainPhaseFreqControlSet);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx3FreqShift);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx4FreqShift);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx2FreqShift);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx1FreqShift);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx3PhaseShift);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx4PhaseShift);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx2PhaseShift);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx1PhaseShift);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx4Gain);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx3Gain);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx2Gain);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseDigitalRx1Gain);
            this.groupBox3.Controls.Add(this.m_nudInterRxGainPhaseProfileIndex);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new Point(1112, 25);
            this.groupBox3.Margin = new Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new Padding(4);
            this.groupBox3.Size = new Size(466, 202);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Inter Rx Gain Phase Freq Control Config";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(393, 26);
            this.label13.Margin = new Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new Size(34, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = "Rx3";
            this.label12.AutoSize = true;
            this.label12.Location = new Point(312, 26);
            this.label12.Margin = new Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new Size(34, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Rx2";
            this.label11.AutoSize = true;
            this.label11.Location = new Point(229, 24);
            this.label11.Margin = new Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new Size(34, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "Rx1";
            this.label10.AutoSize = true;
            this.label10.Location = new Point(148, 26);
            this.label10.Margin = new Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new Size(34, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Rx0";
            this.m_btnInterRxGainPhaseFreqControlSet.Location = new Point(345, 156);
            this.m_btnInterRxGainPhaseFreqControlSet.Margin = new Padding(4);
            this.m_btnInterRxGainPhaseFreqControlSet.Name = "m_btnInterRxGainPhaseFreqControlSet";
            this.m_btnInterRxGainPhaseFreqControlSet.Size = new Size(94, 31);
            this.m_btnInterRxGainPhaseFreqControlSet.TabIndex = 17;
            this.m_btnInterRxGainPhaseFreqControlSet.Text = "Set";
            this.m_btnInterRxGainPhaseFreqControlSet.UseVisualStyleBackColor = true;
            this.m_btnInterRxGainPhaseFreqControlSet.Click += this.m_btnInterRxGainPhaseFreqControlSet_Click;
            NumericUpDown nudInterRxGainPhaseDigitalRx3FreqShift = this.m_nudInterRxGainPhaseDigitalRx3FreqShift;
            int[] array10 = new int[4];
            array10[0] = 4;
            nudInterRxGainPhaseDigitalRx3FreqShift.Increment = new decimal(array10);
            this.m_nudInterRxGainPhaseDigitalRx3FreqShift.Location = new Point(299, 123);
            this.m_nudInterRxGainPhaseDigitalRx3FreqShift.Margin = new Padding(4);
            NumericUpDown nudInterRxGainPhaseDigitalRx3FreqShift2 = this.m_nudInterRxGainPhaseDigitalRx3FreqShift;
            int[] array11 = new int[4];
            array11[0] = 131068;
            nudInterRxGainPhaseDigitalRx3FreqShift2.Maximum = new decimal(array11);
            this.m_nudInterRxGainPhaseDigitalRx3FreqShift.Minimum = new decimal(new int[]
            {
                131072,
                0,
                0,
                int.MinValue
            });
            this.m_nudInterRxGainPhaseDigitalRx3FreqShift.Name = "m_nudInterRxGainPhaseDigitalRx3FreqShift";
            this.m_nudInterRxGainPhaseDigitalRx3FreqShift.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx3FreqShift.TabIndex = 16;
            this.m_nudInterRxGainPhaseDigitalRx3FreqShift.Visible = false;
            this.m_nudInterRxGainPhaseDigitalRx3FreqShift.ValueChanged += this.m_nudRx3DigFreqShift_ValueChanged;
            NumericUpDown nudInterRxGainPhaseDigitalRx4FreqShift = this.m_nudInterRxGainPhaseDigitalRx4FreqShift;
            int[] array12 = new int[4];
            array12[0] = 4;
            nudInterRxGainPhaseDigitalRx4FreqShift.Increment = new decimal(array12);
            this.m_nudInterRxGainPhaseDigitalRx4FreqShift.Location = new Point(383, 123);
            this.m_nudInterRxGainPhaseDigitalRx4FreqShift.Margin = new Padding(4);
            NumericUpDown nudInterRxGainPhaseDigitalRx4FreqShift2 = this.m_nudInterRxGainPhaseDigitalRx4FreqShift;
            int[] array13 = new int[4];
            array13[0] = 131068;
            nudInterRxGainPhaseDigitalRx4FreqShift2.Maximum = new decimal(array13);
            this.m_nudInterRxGainPhaseDigitalRx4FreqShift.Minimum = new decimal(new int[]
            {
                131072,
                0,
                0,
                int.MinValue
            });
            this.m_nudInterRxGainPhaseDigitalRx4FreqShift.Name = "m_nudInterRxGainPhaseDigitalRx4FreqShift";
            this.m_nudInterRxGainPhaseDigitalRx4FreqShift.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx4FreqShift.TabIndex = 15;
            this.m_nudInterRxGainPhaseDigitalRx4FreqShift.Visible = false;
            this.m_nudInterRxGainPhaseDigitalRx4FreqShift.ValueChanged += this.m_nudRx4DigFreqShift_ValueChanged;
            NumericUpDown nudInterRxGainPhaseDigitalRx2FreqShift = this.m_nudInterRxGainPhaseDigitalRx2FreqShift;
            int[] array14 = new int[4];
            array14[0] = 4;
            nudInterRxGainPhaseDigitalRx2FreqShift.Increment = new decimal(array14);
            this.m_nudInterRxGainPhaseDigitalRx2FreqShift.Location = new Point(221, 123);
            this.m_nudInterRxGainPhaseDigitalRx2FreqShift.Margin = new Padding(4);
            NumericUpDown nudInterRxGainPhaseDigitalRx2FreqShift2 = this.m_nudInterRxGainPhaseDigitalRx2FreqShift;
            int[] array15 = new int[4];
            array15[0] = 131068;
            nudInterRxGainPhaseDigitalRx2FreqShift2.Maximum = new decimal(array15);
            this.m_nudInterRxGainPhaseDigitalRx2FreqShift.Minimum = new decimal(new int[]
            {
                131072,
                0,
                0,
                int.MinValue
            });
            this.m_nudInterRxGainPhaseDigitalRx2FreqShift.Name = "m_nudInterRxGainPhaseDigitalRx2FreqShift";
            this.m_nudInterRxGainPhaseDigitalRx2FreqShift.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx2FreqShift.TabIndex = 14;
            this.m_nudInterRxGainPhaseDigitalRx2FreqShift.Visible = false;
            this.m_nudInterRxGainPhaseDigitalRx2FreqShift.ValueChanged += this.m_nudRx2DigFreqShift_ValueChanged;
            NumericUpDown nudInterRxGainPhaseDigitalRx1FreqShift = this.m_nudInterRxGainPhaseDigitalRx1FreqShift;
            int[] array16 = new int[4];
            array16[0] = 4;
            nudInterRxGainPhaseDigitalRx1FreqShift.Increment = new decimal(array16);
            this.m_nudInterRxGainPhaseDigitalRx1FreqShift.Location = new Point(143, 123);
            this.m_nudInterRxGainPhaseDigitalRx1FreqShift.Margin = new Padding(4);
            NumericUpDown nudInterRxGainPhaseDigitalRx1FreqShift2 = this.m_nudInterRxGainPhaseDigitalRx1FreqShift;
            int[] array17 = new int[4];
            array17[0] = 131068;
            nudInterRxGainPhaseDigitalRx1FreqShift2.Maximum = new decimal(array17);
            this.m_nudInterRxGainPhaseDigitalRx1FreqShift.Minimum = new decimal(new int[]
            {
                131072,
                0,
                0,
                int.MinValue
            });
            this.m_nudInterRxGainPhaseDigitalRx1FreqShift.Name = "m_nudInterRxGainPhaseDigitalRx1FreqShift";
            this.m_nudInterRxGainPhaseDigitalRx1FreqShift.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx1FreqShift.TabIndex = 13;
            this.m_nudInterRxGainPhaseDigitalRx1FreqShift.Visible = false;
            this.m_nudInterRxGainPhaseDigitalRx1FreqShift.ValueChanged += this.m_nudRx1DigFreqShift_ValueChanged;
            this.m_nudInterRxGainPhaseDigitalRx3PhaseShift.DecimalPlaces = 2;
            this.m_nudInterRxGainPhaseDigitalRx3PhaseShift.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudInterRxGainPhaseDigitalRx3PhaseShift.Location = new Point(299, 86);
            this.m_nudInterRxGainPhaseDigitalRx3PhaseShift.Margin = new Padding(4);
            NumericUpDown nudInterRxGainPhaseDigitalRx3PhaseShift = this.m_nudInterRxGainPhaseDigitalRx3PhaseShift;
            int[] array18 = new int[4];
            array18[0] = 65535;
            nudInterRxGainPhaseDigitalRx3PhaseShift.Maximum = new decimal(array18);
            this.m_nudInterRxGainPhaseDigitalRx3PhaseShift.Name = "m_nudInterRxGainPhaseDigitalRx3PhaseShift";
            this.m_nudInterRxGainPhaseDigitalRx3PhaseShift.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx3PhaseShift.TabIndex = 12;
            this.m_nudInterRxGainPhaseDigitalRx4PhaseShift.DecimalPlaces = 2;
            this.m_nudInterRxGainPhaseDigitalRx4PhaseShift.ImeMode = ImeMode.NoControl;
            this.m_nudInterRxGainPhaseDigitalRx4PhaseShift.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudInterRxGainPhaseDigitalRx4PhaseShift.Location = new Point(383, 86);
            this.m_nudInterRxGainPhaseDigitalRx4PhaseShift.Margin = new Padding(4);
            NumericUpDown nudInterRxGainPhaseDigitalRx4PhaseShift = this.m_nudInterRxGainPhaseDigitalRx4PhaseShift;
            int[] array19 = new int[4];
            array19[0] = 65535;
            nudInterRxGainPhaseDigitalRx4PhaseShift.Maximum = new decimal(array19);
            this.m_nudInterRxGainPhaseDigitalRx4PhaseShift.Name = "m_nudInterRxGainPhaseDigitalRx4PhaseShift";
            this.m_nudInterRxGainPhaseDigitalRx4PhaseShift.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx4PhaseShift.TabIndex = 11;
            this.m_nudInterRxGainPhaseDigitalRx2PhaseShift.DecimalPlaces = 2;
            this.m_nudInterRxGainPhaseDigitalRx2PhaseShift.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudInterRxGainPhaseDigitalRx2PhaseShift.Location = new Point(221, 86);
            this.m_nudInterRxGainPhaseDigitalRx2PhaseShift.Margin = new Padding(4);
            NumericUpDown nudInterRxGainPhaseDigitalRx2PhaseShift = this.m_nudInterRxGainPhaseDigitalRx2PhaseShift;
            int[] array20 = new int[4];
            array20[0] = 65535;
            nudInterRxGainPhaseDigitalRx2PhaseShift.Maximum = new decimal(array20);
            this.m_nudInterRxGainPhaseDigitalRx2PhaseShift.Name = "m_nudInterRxGainPhaseDigitalRx2PhaseShift";
            this.m_nudInterRxGainPhaseDigitalRx2PhaseShift.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx2PhaseShift.TabIndex = 10;
            this.m_nudInterRxGainPhaseDigitalRx1PhaseShift.DecimalPlaces = 2;
            this.m_nudInterRxGainPhaseDigitalRx1PhaseShift.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudInterRxGainPhaseDigitalRx1PhaseShift.Location = new Point(143, 87);
            this.m_nudInterRxGainPhaseDigitalRx1PhaseShift.Margin = new Padding(4);
            NumericUpDown nudInterRxGainPhaseDigitalRx1PhaseShift = this.m_nudInterRxGainPhaseDigitalRx1PhaseShift;
            int[] array21 = new int[4];
            array21[0] = 65535;
            nudInterRxGainPhaseDigitalRx1PhaseShift.Maximum = new decimal(array21);
            this.m_nudInterRxGainPhaseDigitalRx1PhaseShift.Name = "m_nudInterRxGainPhaseDigitalRx1PhaseShift";
            this.m_nudInterRxGainPhaseDigitalRx1PhaseShift.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx1PhaseShift.TabIndex = 9;
            this.m_nudInterRxGainPhaseDigitalRx4Gain.DecimalPlaces = 1;
            this.m_nudInterRxGainPhaseDigitalRx4Gain.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudInterRxGainPhaseDigitalRx4Gain.Location = new Point(383, 48);
            this.m_nudInterRxGainPhaseDigitalRx4Gain.Margin = new Padding(4);
            this.m_nudInterRxGainPhaseDigitalRx4Gain.Minimum = new decimal(new int[]
            {
                100,
                0,
                0,
                int.MinValue
            });
            this.m_nudInterRxGainPhaseDigitalRx4Gain.Name = "m_nudInterRxGainPhaseDigitalRx4Gain";
            this.m_nudInterRxGainPhaseDigitalRx4Gain.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx4Gain.TabIndex = 8;
            this.m_nudInterRxGainPhaseDigitalRx3Gain.DecimalPlaces = 1;
            this.m_nudInterRxGainPhaseDigitalRx3Gain.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudInterRxGainPhaseDigitalRx3Gain.Location = new Point(299, 48);
            this.m_nudInterRxGainPhaseDigitalRx3Gain.Margin = new Padding(4);
            this.m_nudInterRxGainPhaseDigitalRx3Gain.Minimum = new decimal(new int[]
            {
                100,
                0,
                0,
                int.MinValue
            });
            this.m_nudInterRxGainPhaseDigitalRx3Gain.Name = "m_nudInterRxGainPhaseDigitalRx3Gain";
            this.m_nudInterRxGainPhaseDigitalRx3Gain.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx3Gain.TabIndex = 7;
            this.m_nudInterRxGainPhaseDigitalRx2Gain.DecimalPlaces = 1;
            this.m_nudInterRxGainPhaseDigitalRx2Gain.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudInterRxGainPhaseDigitalRx2Gain.Location = new Point(221, 48);
            this.m_nudInterRxGainPhaseDigitalRx2Gain.Margin = new Padding(4);
            this.m_nudInterRxGainPhaseDigitalRx2Gain.Minimum = new decimal(new int[]
            {
                100,
                0,
                0,
                int.MinValue
            });
            this.m_nudInterRxGainPhaseDigitalRx2Gain.Name = "m_nudInterRxGainPhaseDigitalRx2Gain";
            this.m_nudInterRxGainPhaseDigitalRx2Gain.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx2Gain.TabIndex = 6;
            this.m_nudInterRxGainPhaseDigitalRx1Gain.DecimalPlaces = 1;
            this.m_nudInterRxGainPhaseDigitalRx1Gain.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                65536
            });
            this.m_nudInterRxGainPhaseDigitalRx1Gain.Location = new Point(143, 48);
            this.m_nudInterRxGainPhaseDigitalRx1Gain.Margin = new Padding(4);
            this.m_nudInterRxGainPhaseDigitalRx1Gain.Minimum = new decimal(new int[]
            {
                100,
                0,
                0,
                int.MinValue
            });
            this.m_nudInterRxGainPhaseDigitalRx1Gain.Name = "m_nudInterRxGainPhaseDigitalRx1Gain";
            this.m_nudInterRxGainPhaseDigitalRx1Gain.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseDigitalRx1Gain.TabIndex = 5;
            this.m_nudInterRxGainPhaseProfileIndex.Location = new Point(143, 157);
            this.m_nudInterRxGainPhaseProfileIndex.Margin = new Padding(4);
            this.m_nudInterRxGainPhaseProfileIndex.Name = "m_nudInterRxGainPhaseProfileIndex";
            this.m_nudInterRxGainPhaseProfileIndex.Size = new Size(70, 25);
            this.m_nudInterRxGainPhaseProfileIndex.TabIndex = 4;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(9, 128);
            this.label8.Margin = new Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new Size(129, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Dig Freq Shift (Hz)";
            this.label8.Visible = false;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(9, 93);
            this.label9.Margin = new Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(126, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Dig Ph Shift (Deg)";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(9, 54);
            this.label7.Margin = new Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new Size(96, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Dig Gain (dB)";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(9, 159);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(83, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "ProfileIndex";
            this.m_grpDynamicPowerSave.Controls.Add(this.m_btnDynamicPowerSaveSet);
            this.m_grpDynamicPowerSave.Controls.Add(this.m_chbDynamicPowerSaveLO);
            this.m_grpDynamicPowerSave.Controls.Add(this.m_chbDynamicPowerSaveRx);
            this.m_grpDynamicPowerSave.Controls.Add(this.m_chbDynamicPowerSaveTx);
            this.m_grpDynamicPowerSave.Location = new Point(1377, 536);
            this.m_grpDynamicPowerSave.Margin = new Padding(4);
            this.m_grpDynamicPowerSave.Name = "m_grpDynamicPowerSave";
            this.m_grpDynamicPowerSave.Padding = new Padding(4);
            this.m_grpDynamicPowerSave.Size = new Size(201, 154);
            this.m_grpDynamicPowerSave.TabIndex = 53;
            this.m_grpDynamicPowerSave.TabStop = false;
            this.m_grpDynamicPowerSave.Text = "Enable Dynamic Power Save in Inter-chirp";
            this.m_btnDynamicPowerSaveSet.Location = new Point(59, 113);
            this.m_btnDynamicPowerSaveSet.Margin = new Padding(4);
            this.m_btnDynamicPowerSaveSet.Name = "m_btnDynamicPowerSaveSet";
            this.m_btnDynamicPowerSaveSet.Size = new Size(70, 29);
            this.m_btnDynamicPowerSaveSet.TabIndex = 3;
            this.m_btnDynamicPowerSaveSet.Text = "Set";
            this.m_btnDynamicPowerSaveSet.UseVisualStyleBackColor = true;
            this.m_btnDynamicPowerSaveSet.Click += this.m_btnDynamicPowerSaveSet_Click;
            this.m_chbDynamicPowerSaveLO.AutoSize = true;
            this.m_chbDynamicPowerSaveLO.Checked = true;
            this.m_chbDynamicPowerSaveLO.CheckState = CheckState.Checked;
            this.m_chbDynamicPowerSaveLO.Location = new Point(56, 78);
            this.m_chbDynamicPowerSaveLO.Margin = new Padding(4);
            this.m_chbDynamicPowerSaveLO.Name = "m_chbDynamicPowerSaveLO";
            this.m_chbDynamicPowerSaveLO.Size = new Size(80, 21);
            this.m_chbDynamicPowerSaveLO.TabIndex = 2;
            this.m_chbDynamicPowerSaveLO.Text = "LO Dist";
            this.m_chbDynamicPowerSaveLO.UseVisualStyleBackColor = true;
            this.m_chbDynamicPowerSaveRx.AutoSize = true;
            this.m_chbDynamicPowerSaveRx.Checked = true;
            this.m_chbDynamicPowerSaveRx.CheckState = CheckState.Checked;
            this.m_chbDynamicPowerSaveRx.Location = new Point(98, 47);
            this.m_chbDynamicPowerSaveRx.Margin = new Padding(4);
            this.m_chbDynamicPowerSaveRx.Name = "m_chbDynamicPowerSaveRx";
            this.m_chbDynamicPowerSaveRx.Size = new Size(50, 21);
            this.m_chbDynamicPowerSaveRx.TabIndex = 1;
            this.m_chbDynamicPowerSaveRx.Text = "RX";
            this.m_chbDynamicPowerSaveRx.UseVisualStyleBackColor = true;
            this.m_chbDynamicPowerSaveTx.AutoSize = true;
            this.m_chbDynamicPowerSaveTx.Checked = true;
            this.m_chbDynamicPowerSaveTx.CheckState = CheckState.Checked;
            this.m_chbDynamicPowerSaveTx.Location = new Point(40, 47);
            this.m_chbDynamicPowerSaveTx.Margin = new Padding(4);
            this.m_chbDynamicPowerSaveTx.Name = "m_chbDynamicPowerSaveTx";
            this.m_chbDynamicPowerSaveTx.Size = new Size(48, 21);
            this.m_chbDynamicPowerSaveTx.TabIndex = 0;
            this.m_chbDynamicPowerSaveTx.Text = "TX";
            this.m_chbDynamicPowerSaveTx.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.m_grpPostProcOptions);
            this.groupBox2.Controls.Add(this.m_btnStopFrame);
            this.groupBox2.Controls.Add(this.m_grpFramingStatus);
            this.groupBox2.Controls.Add(this.m_btnTransferFiles);
            this.groupBox2.Controls.Add(this.m_btnPostProc);
            this.groupBox2.Controls.Add(this.m_cboADC_DataFile);
            this.groupBox2.Controls.Add(this.f00016d);
            this.groupBox2.Controls.Add(this.m_btnRealTime);
            this.groupBox2.Controls.Add(this.m_btnMtLbPPTarget);
            this.groupBox2.Controls.Add(this.m_btnFrameStart);
            this.groupBox2.Controls.Add(this.m_grpEnableNumFilesCapture);
            this.groupBox2.Location = new Point(644, 234);
            this.groupBox2.Margin = new Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new Padding(4);
            this.groupBox2.Size = new Size(934, 220);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Capture and Post Processing";
            this.m_grpPostProcOptions.Controls.Add(this.f00016e);
            this.m_grpPostProcOptions.Controls.Add(this.f00016f);
            this.m_grpPostProcOptions.Controls.Add(this.m_btnBasicPostProc);
            this.m_grpPostProcOptions.Location = new Point(628, 14);
            this.m_grpPostProcOptions.Name = "m_grpPostProcOptions";
            this.m_grpPostProcOptions.Size = new Size(279, 53);
            this.m_grpPostProcOptions.TabIndex = 60;
            this.m_grpPostProcOptions.TabStop = false;
            this.m_grpPostProcOptions.Text = "PostProcessing Options";
            this.m_grpPostProcOptions.Visible = false;
            this.f00016e.AutoSize = true;
            this.f00016e.Location = new Point(190, 24);
            this.f00016e.Name = "m_btnTXBFPostProc";
            this.f00016e.Size = new Size(70, 21);
            this.f00016e.TabIndex = 2;
            this.f00016e.Text = "TX BF";
            this.f00016e.UseVisualStyleBackColor = true;
            this.f00016e.CheckedChanged += this.m000011;
            this.f00016f.AutoSize = true;
            this.f00016f.Location = new Point(105, 24);
            this.f00016f.Name = "m_btnMIMOPostProc";
            this.f00016f.Size = new Size(66, 21);
            this.f00016f.TabIndex = 1;
            this.f00016f.Text = "MIMO";
            this.f00016f.UseVisualStyleBackColor = true;
            this.f00016f.CheckedChanged += this.m000010;
            this.m_btnBasicPostProc.AutoSize = true;
            this.m_btnBasicPostProc.Checked = true;
            this.m_btnBasicPostProc.Location = new Point(21, 24);
            this.m_btnBasicPostProc.Name = "m_btnBasicPostProc";
            this.m_btnBasicPostProc.Size = new Size(66, 21);
            this.m_btnBasicPostProc.TabIndex = 0;
            this.m_btnBasicPostProc.TabStop = true;
            this.m_btnBasicPostProc.Text = "Basic";
            this.m_btnBasicPostProc.UseVisualStyleBackColor = true;
            this.m_btnBasicPostProc.CheckedChanged += this.m_btnBasicPostProc_CheckedChanged;
            this.m_btnStopFrame.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_btnStopFrame.Location = new Point(248, 26);
            this.m_btnStopFrame.Margin = new Padding(5);
            this.m_btnStopFrame.Name = "m_btnStopFrame";
            this.m_btnStopFrame.Size = new Size(101, 54);
            this.m_btnStopFrame.TabIndex = 54;
            this.m_btnStopFrame.Text = "Stop Frame";
            this.m_btnStopFrame.UseVisualStyleBackColor = true;
            this.m_btnStopFrame.Click += this.m_btnStopFrame_Click;
            this.m_grpFramingStatus.Controls.Add(this.m_lblDev4FramingStatus);
            this.m_grpFramingStatus.Controls.Add(this.m_lblDev3FramingStatus);
            this.m_grpFramingStatus.Controls.Add(this.m_lblDev2FramingStatus);
            this.m_grpFramingStatus.Controls.Add(this.m_lblDev1FramingStatus);
            this.m_grpFramingStatus.Controls.Add(this.label27);
            this.m_grpFramingStatus.Controls.Add(this.label26);
            this.m_grpFramingStatus.Controls.Add(this.label25);
            this.m_grpFramingStatus.Controls.Add(this.label24);
            this.m_grpFramingStatus.Location = new Point(12, 130);
            this.m_grpFramingStatus.Name = "m_grpFramingStatus";
            this.m_grpFramingStatus.Size = new Size(598, 80);
            this.m_grpFramingStatus.TabIndex = 53;
            this.m_grpFramingStatus.TabStop = false;
            this.m_grpFramingStatus.Text = "Framing Status";
            this.m_grpFramingStatus.Visible = false;
            this.m_lblDev4FramingStatus.AutoSize = true;
            this.m_lblDev4FramingStatus.ForeColor = Color.Red;
            this.m_lblDev4FramingStatus.Location = new Point(397, 51);
            this.m_lblDev4FramingStatus.Margin = new Padding(4, 0, 4, 0);
            this.m_lblDev4FramingStatus.Name = "m_lblDev4FramingStatus";
            this.m_lblDev4FramingStatus.Size = new Size(107, 17);
            this.m_lblDev4FramingStatus.TabIndex = 61;
            this.m_lblDev4FramingStatus.Text = "NOT FRAMING";
            this.m_lblDev3FramingStatus.AutoSize = true;
            this.m_lblDev3FramingStatus.ForeColor = Color.Red;
            this.m_lblDev3FramingStatus.Location = new Point(397, 25);
            this.m_lblDev3FramingStatus.Margin = new Padding(4, 0, 4, 0);
            this.m_lblDev3FramingStatus.Name = "m_lblDev3FramingStatus";
            this.m_lblDev3FramingStatus.Size = new Size(107, 17);
            this.m_lblDev3FramingStatus.TabIndex = 60;
            this.m_lblDev3FramingStatus.Text = "NOT FRAMING";
            this.m_lblDev2FramingStatus.AutoSize = true;
            this.m_lblDev2FramingStatus.ForeColor = Color.Red;
            this.m_lblDev2FramingStatus.Location = new Point(80, 52);
            this.m_lblDev2FramingStatus.Margin = new Padding(4, 0, 4, 0);
            this.m_lblDev2FramingStatus.Name = "m_lblDev2FramingStatus";
            this.m_lblDev2FramingStatus.Size = new Size(107, 17);
            this.m_lblDev2FramingStatus.TabIndex = 59;
            this.m_lblDev2FramingStatus.Text = "NOT FRAMING";
            this.m_lblDev1FramingStatus.AutoSize = true;
            this.m_lblDev1FramingStatus.ForeColor = Color.Red;
            this.m_lblDev1FramingStatus.Location = new Point(80, 25);
            this.m_lblDev1FramingStatus.Margin = new Padding(4, 0, 4, 0);
            this.m_lblDev1FramingStatus.Name = "m_lblDev1FramingStatus";
            this.m_lblDev1FramingStatus.Size = new Size(107, 17);
            this.m_lblDev1FramingStatus.TabIndex = 58;
            this.m_lblDev1FramingStatus.Text = "NOT FRAMING";
            this.label27.AutoSize = true;
            this.label27.Location = new Point(330, 51);
            this.label27.Margin = new Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new Size(65, 17);
            this.label27.TabIndex = 57;
            this.label27.Text = "Device 4";
            this.label26.AutoSize = true;
            this.label26.Location = new Point(330, 25);
            this.label26.Margin = new Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new Size(65, 17);
            this.label26.TabIndex = 56;
            this.label26.Text = "Device 3";
            this.label25.AutoSize = true;
            this.label25.Location = new Point(11, 52);
            this.label25.Margin = new Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new Size(65, 17);
            this.label25.TabIndex = 55;
            this.label25.Text = "Device 2";
            this.label24.AutoSize = true;
            this.label24.Location = new Point(11, 25);
            this.label24.Margin = new Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new Size(65, 17);
            this.label24.TabIndex = 54;
            this.label24.Text = "Device 1";
            this.m_btnTransferFiles.Enabled = false;
            this.m_btnTransferFiles.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_btnTransferFiles.Location = new Point(373, 26);
            this.m_btnTransferFiles.Margin = new Padding(5);
            this.m_btnTransferFiles.Name = "m_btnTransferFiles";
            this.m_btnTransferFiles.Size = new Size(98, 54);
            this.m_btnTransferFiles.TabIndex = 52;
            this.m_btnTransferFiles.Text = "Transfer Files";
            this.m_btnTransferFiles.UseVisualStyleBackColor = true;
            this.m_btnTransferFiles.Click += this.m_btnTransferFiles_Click;
            this.m_btnPostProc.Location = new Point(491, 26);
            this.m_btnPostProc.Margin = new Padding(4);
            this.m_btnPostProc.Name = "m_btnPostProc";
            this.m_btnPostProc.Size = new Size(101, 54);
            this.m_btnPostProc.TabIndex = 23;
            this.m_btnPostProc.Text = "PostProc";
            this.m_btnPostProc.UseVisualStyleBackColor = true;
            this.m_btnPostProc.Click += this.m_btnPostProc_Click;
            this.m_cboADC_DataFile.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.m_cboADC_DataFile.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.m_cboADC_DataFile.FormattingEnabled = true;
            this.m_cboADC_DataFile.Location = new Point(8, 92);
            this.m_cboADC_DataFile.Margin = new Padding(4);
            this.m_cboADC_DataFile.Name = "m_cboADC_DataFile";
            this.m_cboADC_DataFile.Size = new Size(525, 25);
            this.m_cboADC_DataFile.TabIndex = 51;
            this.m_cboADC_DataFile.Text = "C:\\RadarStudio\\PostProc\\adc_data.bin";
            this.f00016d.Location = new Point(17, 25);
            this.f00016d.Margin = new Padding(4);
            this.f00016d.Name = "m_btnTsw1400";
            this.f00016d.Size = new Size(91, 55);
            this.f00016d.TabIndex = 21;
            this.f00016d.Text = "DCA1000 ARM";
            this.f00016d.UseVisualStyleBackColor = true;
            this.f00016d.Click += this.m_btnTsw1400_Click;
            this.m_btnRealTime.Location = new Point(599, 26);
            this.m_btnRealTime.Margin = new Padding(4);
            this.m_btnRealTime.Name = "m_btnRealTime";
            this.m_btnRealTime.Size = new Size(13, 54);
            this.m_btnRealTime.TabIndex = 24;
            this.m_btnRealTime.Text = "Real Time";
            this.m_btnRealTime.UseVisualStyleBackColor = true;
            this.m_btnRealTime.Visible = false;
            this.m_btnRealTime.Click += this.m_btnRealTime_Click;
            this.m_btnMtLbPPTarget.Location = new Point(541, 89);
            this.m_btnMtLbPPTarget.Margin = new Padding(4);
            this.m_btnMtLbPPTarget.Name = "m_btnMtLbPPTarget";
            this.m_btnMtLbPPTarget.Size = new Size(71, 32);
            this.m_btnMtLbPPTarget.TabIndex = 26;
            this.m_btnMtLbPPTarget.Text = "Browse";
            this.m_btnMtLbPPTarget.UseVisualStyleBackColor = true;
            this.m_btnMtLbPPTarget.Click += this.m_btnMtLbPPTarget_Click;
            this.m_btnFrameStart.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_btnFrameStart.Location = new Point(131, 26);
            this.m_btnFrameStart.Margin = new Padding(5);
            this.m_btnFrameStart.Name = "m_btnFrameStart";
            this.m_btnFrameStart.Size = new Size(95, 54);
            this.m_btnFrameStart.TabIndex = 22;
            this.m_btnFrameStart.Text = "Trigger Frame";
            this.m_btnFrameStart.UseVisualStyleBackColor = true;
            this.m_btnFrameStart.Click += this.m_btnFrameStart_Click;
            this.m_grpEnableNumFilesCapture.Controls.Add(this.m_ChkEnaDisablePackaging);
            this.m_grpEnableNumFilesCapture.Controls.Add(this.label28);
            this.m_grpEnableNumFilesCapture.Controls.Add(this.m_nudFileAllocation);
            this.m_grpEnableNumFilesCapture.Controls.Add(this.label29);
            this.m_grpEnableNumFilesCapture.Controls.Add(this.m_btnTDAStopCapture);
            this.m_grpEnableNumFilesCapture.Controls.Add(this.m_nudNumFramesToCapture);
            this.m_grpEnableNumFilesCapture.Controls.Add(this.label32);
            this.m_grpEnableNumFilesCapture.Location = new Point(0, 76);
            this.m_grpEnableNumFilesCapture.Name = "m_grpEnableNumFilesCapture";
            this.m_grpEnableNumFilesCapture.Size = new Size(908, 144);
            this.m_grpEnableNumFilesCapture.TabIndex = 66;
            this.m_grpEnableNumFilesCapture.TabStop = false;
            this.m_grpEnableNumFilesCapture.Visible = false;
            this.m_ChkEnaDisablePackaging.AutoSize = true;
            this.m_ChkEnaDisablePackaging.Location = new Point(823, 57);
            this.m_ChkEnaDisablePackaging.Margin = new Padding(4);
            this.m_ChkEnaDisablePackaging.Name = "m_ChkEnaDisablePackaging";
            this.m_ChkEnaDisablePackaging.Size = new Size(18, 17);
            this.m_ChkEnaDisablePackaging.TabIndex = 72;
            this.m_ChkEnaDisablePackaging.UseVisualStyleBackColor = true;
            this.label28.AutoSize = true;
            this.label28.Location = new Point(625, 57);
            this.label28.Margin = new Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new Size(149, 17);
            this.label28.TabIndex = 71;
            this.label28.Text = "Enable 12-bit Packing";
            this.m_nudFileAllocation.Location = new Point(823, 26);
            this.m_nudFileAllocation.Margin = new Padding(4);
            NumericUpDown nudFileAllocation = this.m_nudFileAllocation;
            int[] array22 = new int[4];
            array22[0] = 1000;
            nudFileAllocation.Maximum = new decimal(array22);
            this.m_nudFileAllocation.Name = "m_nudFileAllocation";
            this.m_nudFileAllocation.Size = new Size(72, 25);
            this.m_nudFileAllocation.TabIndex = 70;
            this.label29.AutoSize = true;
            this.label29.Location = new Point(625, 30);
            this.label29.Name = "label29";
            this.label29.Size = new Size(137, 17);
            this.label29.TabIndex = 69;
            this.label29.Text = "Files to be allocated";
            this.m_btnTDAStopCapture.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_btnTDAStopCapture.Location = new Point(627, 109);
            this.m_btnTDAStopCapture.Margin = new Padding(4);
            this.m_btnTDAStopCapture.Name = "m_btnTDAStopCapture";
            this.m_btnTDAStopCapture.Size = new Size(147, 28);
            this.m_btnTDAStopCapture.TabIndex = 67;
            this.m_btnTDAStopCapture.Text = "Stop Capture";
            this.m_btnTDAStopCapture.UseVisualStyleBackColor = true;
            this.m_btnTDAStopCapture.Click += this.m_btnTDAStopCapture_Click;
            this.m_nudNumFramesToCapture.Location = new Point(823, 83);
            this.m_nudNumFramesToCapture.Margin = new Padding(4);
            NumericUpDown nudNumFramesToCapture = this.m_nudNumFramesToCapture;
            int[] array23 = new int[4];
            array23[0] = 1000;
            nudNumFramesToCapture.Maximum = new decimal(array23);
            this.m_nudNumFramesToCapture.Name = "m_nudNumFramesToCapture";
            this.m_nudNumFramesToCapture.Size = new Size(72, 25);
            this.m_nudNumFramesToCapture.TabIndex = 68;
            this.label32.AutoSize = true;
            this.label32.Location = new Point(625, 85);
            this.label32.Name = "label32";
            this.label32.Size = new Size(169, 17);
            this.label32.TabIndex = 67;
            this.label32.Text = "No of Frames to Capture";
            this.pictureBox1.Image = Resources.sensorconfig1;
            this.pictureBox1.Location = new Point(656, 26);
            this.pictureBox1.Margin = new Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(450, 201);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.m_grpProfile.Controls.Add(this.m_chbProfileRetainRxCalLUT);
            this.m_grpProfile.Controls.Add(this.m_chbProfileRetainTxCalLUT);
            this.m_grpProfile.Controls.Add(this.label16);
            this.m_grpProfile.Controls.Add(this.m_chbProfileForceVCOSelect);
            this.m_grpProfile.Controls.Add(this.m_cboProfileVCOSelect);
            this.m_grpProfile.Controls.Add(this.label15);
            this.m_grpProfile.Controls.Add(this.m_cboProfileRFGainTarget);
            this.m_grpProfile.Controls.Add(this.label14);
            this.m_grpProfile.Controls.Add(this.m_nudTx3PhaseShifter);
            this.m_grpProfile.Controls.Add(this.m_nudTx2PhaseShifter);
            this.m_grpProfile.Controls.Add(this.m_nudTx1PhaseShifter);
            this.m_grpProfile.Controls.Add(this.m_lblBandwidth);
            this.m_grpProfile.Controls.Add(this.label4);
            this.m_grpProfile.Controls.Add(this.m_nudTx2OutPowerBackoffCode);
            this.m_grpProfile.Controls.Add(this.m_nudTx1OutPowerBackoffCode);
            this.m_grpProfile.Controls.Add(this.m_lblProfileTx2OpPwrBackoff);
            this.m_grpProfile.Controls.Add(this.m_lblProfileTx1OpPwrBackoff);
            this.m_grpProfile.Controls.Add(this.m_btnMangProfiles);
            this.m_grpProfile.Controls.Add(this.label2);
            this.m_grpProfile.Controls.Add(this.label1);
            this.m_grpProfile.Controls.Add(this.m_nudProfileRxGain);
            this.m_grpProfile.Controls.Add(this.m_btnProfileSet);
            this.m_grpProfile.Controls.Add(this.m_nudTxStartTime);
            this.m_grpProfile.Controls.Add(this.m_lblProfileTxStartTime);
            this.m_grpProfile.Controls.Add(this.m_nudFreqSlopeConst);
            this.m_grpProfile.Controls.Add(this.m_lblProfileFreqSlope);
            this.m_grpProfile.Controls.Add(this.m_lblProfilePhaseShifter);
            this.m_grpProfile.Controls.Add(this.m_nudTx3OutPowerBackoffCode);
            this.m_grpProfile.Controls.Add(this.m_lblProfileTx3OpPwrBackoff);
            this.m_grpProfile.Controls.Add(this.m_nudStartFreqConst);
            this.m_grpProfile.Controls.Add(this.m_lblProfileStartFreqConst);
            this.m_grpProfile.Controls.Add(this.m_nudRampEndTime);
            this.m_grpProfile.Controls.Add(this.m_lblProfileRampEndTime);
            this.m_grpProfile.Controls.Add(this.m_nudIdleTimeConst);
            this.m_grpProfile.Controls.Add(this.m_lblProfileIdleTime);
            this.m_grpProfile.Controls.Add(this.m_nudAdcStartTimeConst);
            this.m_grpProfile.Controls.Add(this.m_lblProfileAdcStartTime);
            this.m_grpProfile.Controls.Add(this.m_nudNumAdcSamples);
            this.m_grpProfile.Controls.Add(this.m_lblProfileAdcSamples);
            this.m_grpProfile.Controls.Add(this.m_nudDigOutSampleRate);
            this.m_grpProfile.Controls.Add(this.m_lblProfileSampleRate);
            this.m_grpProfile.Controls.Add(this.m_lblProfileRxGain);
            this.m_grpProfile.Controls.Add(this.m_cboProfileHpf2);
            this.m_grpProfile.Controls.Add(this.m_lblProfileHpf2);
            this.m_grpProfile.Controls.Add(this.m_cboProfileHpf1);
            this.m_grpProfile.Controls.Add(this.m_lblProfileHpf1);
            this.m_grpProfile.Controls.Add(this.m_nudProfileProfileId);
            this.m_grpProfile.Controls.Add(this.m_lblProfileProfileId);
            this.m_grpProfile.FlatStyle = FlatStyle.Flat;
            this.m_grpProfile.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_grpProfile.Location = new Point(8, 16);
            this.m_grpProfile.Margin = new Padding(4);
            this.m_grpProfile.Name = "m_grpProfile";
            this.m_grpProfile.Padding = new Padding(4);
            this.m_grpProfile.Size = new Size(629, 438);
            this.m_grpProfile.TabIndex = 11;
            this.m_grpProfile.TabStop = false;
            this.m_grpProfile.Text = "Profile";
            this.m_grpProfile.Enter += this.m_grpProfile_Enter;
            this.m_chbProfileRetainRxCalLUT.AutoSize = true;
            this.m_chbProfileRetainRxCalLUT.Location = new Point(335, 411);
            this.m_chbProfileRetainRxCalLUT.Margin = new Padding(4);
            this.m_chbProfileRetainRxCalLUT.Name = "m_chbProfileRetainRxCalLUT";
            this.m_chbProfileRetainRxCalLUT.Size = new Size(139, 21);
            this.m_chbProfileRetainRxCalLUT.TabIndex = 66;
            this.m_chbProfileRetainRxCalLUT.Text = "RetainRxCalLUT";
            this.m_chbProfileRetainRxCalLUT.UseVisualStyleBackColor = true;
            this.m_chbProfileRetainTxCalLUT.AutoSize = true;
            this.m_chbProfileRetainTxCalLUT.Location = new Point(192, 411);
            this.m_chbProfileRetainTxCalLUT.Margin = new Padding(4);
            this.m_chbProfileRetainTxCalLUT.Name = "m_chbProfileRetainTxCalLUT";
            this.m_chbProfileRetainTxCalLUT.Size = new Size(137, 21);
            this.m_chbProfileRetainTxCalLUT.TabIndex = 65;
            this.m_chbProfileRetainTxCalLUT.Text = "RetainTxCalLUT";
            this.m_chbProfileRetainTxCalLUT.UseVisualStyleBackColor = true;
            this.label16.AutoSize = true;
            this.label16.Location = new Point(9, 411);
            this.label16.Margin = new Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new Size(122, 17);
            this.label16.TabIndex = 64;
            this.label16.Text = "Calib LUT Update";
            this.m_chbProfileForceVCOSelect.AutoSize = true;
            this.m_chbProfileForceVCOSelect.Location = new Point(335, 384);
            this.m_chbProfileForceVCOSelect.Margin = new Padding(4);
            this.m_chbProfileForceVCOSelect.Name = "m_chbProfileForceVCOSelect";
            this.m_chbProfileForceVCOSelect.Size = new Size(149, 21);
            this.m_chbProfileForceVCOSelect.TabIndex = 63;
            this.m_chbProfileForceVCOSelect.Text = "Force VCO Select";
            this.m_chbProfileForceVCOSelect.UseVisualStyleBackColor = true;
            this.m_cboProfileVCOSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            this.m_cboProfileVCOSelect.FormattingEnabled = true;
            this.m_cboProfileVCOSelect.Items.AddRange(new object[]
            {
                "VCO1",
                "VCO2"
            });
            this.m_cboProfileVCOSelect.Location = new Point(192, 378);
            this.m_cboProfileVCOSelect.Margin = new Padding(4);
            this.m_cboProfileVCOSelect.Name = "m_cboProfileVCOSelect";
            this.m_cboProfileVCOSelect.Size = new Size(115, 25);
            this.m_cboProfileVCOSelect.TabIndex = 62;
            this.label15.AutoSize = true;
            this.label15.Location = new Point(9, 380);
            this.label15.Margin = new Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new Size(85, 17);
            this.label15.TabIndex = 61;
            this.label15.Text = "VCO Select";
            this.m_cboProfileRFGainTarget.DropDownStyle = ComboBoxStyle.DropDownList;
            this.m_cboProfileRFGainTarget.FormattingEnabled = true;
            this.m_cboProfileRFGainTarget.Items.AddRange(new object[]
            {
                "30dB",
                "34dB",
                "26dB"
            });
            this.m_cboProfileRFGainTarget.Location = new Point(192, 344);
            this.m_cboProfileRFGainTarget.Margin = new Padding(4);
            this.m_cboProfileRFGainTarget.Name = "m_cboProfileRFGainTarget";
            this.m_cboProfileRFGainTarget.Size = new Size(115, 25);
            this.m_cboProfileRFGainTarget.TabIndex = 60;
            this.label14.AutoSize = true;
            this.label14.Location = new Point(8, 348);
            this.label14.Margin = new Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new Size(106, 17);
            this.label14.TabIndex = 59;
            this.label14.Text = "RF Gain Target";
            this.m_nudTx3PhaseShifter.DecimalPlaces = 3;
            this.m_nudTx3PhaseShifter.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTx3PhaseShifter.Location = new Point(504, 249);
            this.m_nudTx3PhaseShifter.Margin = new Padding(4);
            NumericUpDown nudTx3PhaseShifter = this.m_nudTx3PhaseShifter;
            int[] array24 = new int[4];
            array24[0] = 360;
            nudTx3PhaseShifter.Maximum = new decimal(array24);
            this.m_nudTx3PhaseShifter.Name = "m_nudTx3PhaseShifter";
            this.m_nudTx3PhaseShifter.Size = new Size(118, 25);
            this.m_nudTx3PhaseShifter.TabIndex = 58;
            this.m_nudTx3PhaseShifter.ValueChanged += this.m_nudPhaseShifter2Const_ValueChanged;
            this.m_nudTx2PhaseShifter.DecimalPlaces = 3;
            this.m_nudTx2PhaseShifter.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTx2PhaseShifter.Location = new Point(504, 218);
            this.m_nudTx2PhaseShifter.Margin = new Padding(4);
            NumericUpDown nudTx2PhaseShifter = this.m_nudTx2PhaseShifter;
            int[] array25 = new int[4];
            array25[0] = 360;
            nudTx2PhaseShifter.Maximum = new decimal(array25);
            this.m_nudTx2PhaseShifter.Name = "m_nudTx2PhaseShifter";
            this.m_nudTx2PhaseShifter.Size = new Size(116, 25);
            this.m_nudTx2PhaseShifter.TabIndex = 57;
            this.m_nudTx2PhaseShifter.ValueChanged += this.m_nudPhaseShifter1Const_ValueChanged;
            this.m_nudTx1PhaseShifter.DecimalPlaces = 3;
            this.m_nudTx1PhaseShifter.Increment = new decimal(new int[]
            {
                5625,
                0,
                0,
                196608
            });
            this.m_nudTx1PhaseShifter.Location = new Point(504, 185);
            this.m_nudTx1PhaseShifter.Margin = new Padding(4);
            NumericUpDown nudTx1PhaseShifter = this.m_nudTx1PhaseShifter;
            int[] array26 = new int[4];
            array26[0] = 360;
            nudTx1PhaseShifter.Maximum = new decimal(array26);
            this.m_nudTx1PhaseShifter.Name = "m_nudTx1PhaseShifter";
            this.m_nudTx1PhaseShifter.Size = new Size(115, 25);
            this.m_nudTx1PhaseShifter.TabIndex = 56;
            this.m_nudTx1PhaseShifter.ValueChanged += this.m_nudPhaseShifter0Const_ValueChanged;
            this.m_lblBandwidth.AutoSize = true;
            this.m_lblBandwidth.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.m_lblBandwidth.Location = new Point(534, 285);
            this.m_lblBandwidth.Margin = new Padding(4, 0, 4, 0);
            this.m_lblBandwidth.Name = "m_lblBandwidth";
            this.m_lblBandwidth.Size = new Size(40, 18);
            this.m_lblBandwidth.TabIndex = 55;
            this.m_lblBandwidth.Text = "1800";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(376, 282);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(115, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "Bandwidth(MHz)";
            this.m_nudTx2OutPowerBackoffCode.Location = new Point(504, 120);
            this.m_nudTx2OutPowerBackoffCode.Margin = new Padding(4);
            NumericUpDown nudTx2OutPowerBackoffCode = this.m_nudTx2OutPowerBackoffCode;
            int[] array27 = new int[4];
            array27[0] = 30;
            nudTx2OutPowerBackoffCode.Maximum = new decimal(array27);
            this.m_nudTx2OutPowerBackoffCode.Name = "m_nudTx2OutPowerBackoffCode";
            this.m_nudTx2OutPowerBackoffCode.Size = new Size(115, 25);
            this.m_nudTx2OutPowerBackoffCode.TabIndex = 8;
            this.m_nudTx1OutPowerBackoffCode.Location = new Point(504, 88);
            this.m_nudTx1OutPowerBackoffCode.Margin = new Padding(4);
            NumericUpDown nudTx1OutPowerBackoffCode = this.m_nudTx1OutPowerBackoffCode;
            int[] array28 = new int[4];
            array28[0] = 30;
            nudTx1OutPowerBackoffCode.Maximum = new decimal(array28);
            this.m_nudTx1OutPowerBackoffCode.Name = "m_nudTx1OutPowerBackoffCode";
            this.m_nudTx1OutPowerBackoffCode.Size = new Size(115, 25);
            this.m_nudTx1OutPowerBackoffCode.TabIndex = 6;
            this.m_lblProfileTx2OpPwrBackoff.AutoSize = true;
            this.m_lblProfileTx2OpPwrBackoff.Location = new Point(328, 120);
            this.m_lblProfileTx2OpPwrBackoff.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileTx2OpPwrBackoff.Name = "m_lblProfileTx2OpPwrBackoff";
            this.m_lblProfileTx2OpPwrBackoff.Size = new Size(177, 17);
            this.m_lblProfileTx2OpPwrBackoff.TabIndex = 53;
            this.m_lblProfileTx2OpPwrBackoff.Text = "O/p Pwr Backoff TX1 (dB)";
            this.m_lblProfileTx1OpPwrBackoff.AutoSize = true;
            this.m_lblProfileTx1OpPwrBackoff.Location = new Point(328, 88);
            this.m_lblProfileTx1OpPwrBackoff.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileTx1OpPwrBackoff.Name = "m_lblProfileTx1OpPwrBackoff";
            this.m_lblProfileTx1OpPwrBackoff.Size = new Size(177, 17);
            this.m_lblProfileTx1OpPwrBackoff.TabIndex = 52;
            this.m_lblProfileTx1OpPwrBackoff.Text = "O/p Pwr Backoff TX0 (dB)";
            this.m_btnMangProfiles.Location = new Point(488, 310);
            this.m_btnMangProfiles.Margin = new Padding(4);
            this.m_btnMangProfiles.Name = "m_btnMangProfiles";
            this.m_btnMangProfiles.Size = new Size(126, 39);
            this.m_btnMangProfiles.TabIndex = 20;
            this.m_btnMangProfiles.Text = "Manage Profile";
            this.m_btnMangProfiles.UseVisualStyleBackColor = true;
            this.m_btnMangProfiles.Click += this.m_btnMangProfiles_Click;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(328, 249);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(164, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Phase Shifter TX2 (deg)";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(328, 218);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(164, 17);
            this.label1.TabIndex = 49;
            this.label1.Text = "Phase Shifter TX1 (deg)";
            NumericUpDown nudProfileRxGain = this.m_nudProfileRxGain;
            int[] array29 = new int[4];
            array29[0] = 2;
            nudProfileRxGain.Increment = new decimal(array29);
            this.m_nudProfileRxGain.Location = new Point(192, 312);
            this.m_nudProfileRxGain.Margin = new Padding(4);
            NumericUpDown nudProfileRxGain2 = this.m_nudProfileRxGain;
            int[] array30 = new int[4];
            array30[0] = 52;
            nudProfileRxGain2.Maximum = new decimal(array30);
            NumericUpDown nudProfileRxGain3 = this.m_nudProfileRxGain;
            int[] array31 = new int[4];
            array31[0] = 24;
            nudProfileRxGain3.Minimum = new decimal(array31);
            this.m_nudProfileRxGain.Name = "m_nudProfileRxGain";
            this.m_nudProfileRxGain.Size = new Size(116, 25);
            this.m_nudProfileRxGain.TabIndex = 18;
            NumericUpDown nudProfileRxGain4 = this.m_nudProfileRxGain;
            int[] array32 = new int[4];
            array32[0] = 30;
            nudProfileRxGain4.Value = new decimal(array32);
            this.m_nudProfileRxGain.ValueChanged += this.m_nudProfileRxGain_ValueChanged_1;
            this.m_btnProfileSet.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_btnProfileSet.ForeColor = Color.Blue;
            this.m_btnProfileSet.Location = new Point(342, 310);
            this.m_btnProfileSet.Margin = new Padding(4);
            this.m_btnProfileSet.Name = "m_btnProfileSet";
            this.m_btnProfileSet.Size = new Size(126, 39);
            this.m_btnProfileSet.TabIndex = 19;
            this.m_btnProfileSet.Text = "Set";
            this.m_btnProfileSet.UseVisualStyleBackColor = true;
            this.m_btnProfileSet.Click += this.m_btnProfileSet_Click;
            this.m_nudTxStartTime.DecimalPlaces = 2;
            this.m_nudTxStartTime.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudTxStartTime.Location = new Point(192, 152);
            this.m_nudTxStartTime.Margin = new Padding(4);
            NumericUpDown nudTxStartTime = this.m_nudTxStartTime;
            int[] array33 = new int[4];
            array33[0] = 40;
            nudTxStartTime.Maximum = new decimal(array33);
            this.m_nudTxStartTime.Minimum = new decimal(new int[]
            {
                40,
                0,
                0,
                int.MinValue
            });
            this.m_nudTxStartTime.Name = "m_nudTxStartTime";
            this.m_nudTxStartTime.Size = new Size(116, 25);
            this.m_nudTxStartTime.TabIndex = 9;
            this.m_nudTxStartTime.ValueChanged += this.m_nudTxStartTime_ValueChanged;
            this.m_lblProfileTxStartTime.AutoSize = true;
            this.m_lblProfileTxStartTime.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileTxStartTime.Location = new Point(8, 152);
            this.m_lblProfileTxStartTime.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileTxStartTime.Name = "m_lblProfileTxStartTime";
            this.m_lblProfileTxStartTime.Size = new Size(127, 17);
            this.m_lblProfileTxStartTime.TabIndex = 44;
            this.m_lblProfileTxStartTime.Text = "TX Start Time (µs)";
            this.m_nudFreqSlopeConst.DecimalPlaces = 3;
            this.m_nudFreqSlopeConst.Increment = new decimal(new int[]
            {
                5,
                0,
                0,
                131072
            });
            this.m_nudFreqSlopeConst.Location = new Point(192, 88);
            this.m_nudFreqSlopeConst.Margin = new Padding(4);
            NumericUpDown nudFreqSlopeConst = this.m_nudFreqSlopeConst;
            int[] array34 = new int[4];
            array34[0] = 327;
            nudFreqSlopeConst.Maximum = new decimal(array34);
            this.m_nudFreqSlopeConst.Minimum = new decimal(new int[]
            {
                327,
                0,
                0,
                int.MinValue
            });
            this.m_nudFreqSlopeConst.Name = "m_nudFreqSlopeConst";
            this.m_nudFreqSlopeConst.Size = new Size(116, 25);
            this.m_nudFreqSlopeConst.TabIndex = 5;
            this.m_nudFreqSlopeConst.Value = new decimal(new int[]
            {
                29982,
                0,
                0,
                196608
            });
            this.m_nudFreqSlopeConst.ValueChanged += this.m_nudFreqSlopeConst_ValueChanged;
            this.m_lblProfileFreqSlope.AutoSize = true;
            this.m_lblProfileFreqSlope.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileFreqSlope.Location = new Point(9, 88);
            this.m_lblProfileFreqSlope.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileFreqSlope.Name = "m_lblProfileFreqSlope";
            this.m_lblProfileFreqSlope.Size = new Size(181, 17);
            this.m_lblProfileFreqSlope.TabIndex = 42;
            this.m_lblProfileFreqSlope.Text = "Frequency Slope (MHz/µs)";
            this.m_lblProfilePhaseShifter.AutoSize = true;
            this.m_lblProfilePhaseShifter.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfilePhaseShifter.Location = new Point(328, 186);
            this.m_lblProfilePhaseShifter.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfilePhaseShifter.Name = "m_lblProfilePhaseShifter";
            this.m_lblProfilePhaseShifter.Size = new Size(164, 17);
            this.m_lblProfilePhaseShifter.TabIndex = 40;
            this.m_lblProfilePhaseShifter.Text = "Phase Shifter TX0 (deg)";
            this.m_nudTx3OutPowerBackoffCode.Location = new Point(504, 152);
            this.m_nudTx3OutPowerBackoffCode.Margin = new Padding(4);
            NumericUpDown nudTx3OutPowerBackoffCode = this.m_nudTx3OutPowerBackoffCode;
            int[] array35 = new int[4];
            array35[0] = 30;
            nudTx3OutPowerBackoffCode.Maximum = new decimal(array35);
            this.m_nudTx3OutPowerBackoffCode.Name = "m_nudTx3OutPowerBackoffCode";
            this.m_nudTx3OutPowerBackoffCode.Size = new Size(115, 25);
            this.m_nudTx3OutPowerBackoffCode.TabIndex = 10;
            this.m_lblProfileTx3OpPwrBackoff.AutoSize = true;
            this.m_lblProfileTx3OpPwrBackoff.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileTx3OpPwrBackoff.Location = new Point(328, 152);
            this.m_lblProfileTx3OpPwrBackoff.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileTx3OpPwrBackoff.Name = "m_lblProfileTx3OpPwrBackoff";
            this.m_lblProfileTx3OpPwrBackoff.Size = new Size(177, 17);
            this.m_lblProfileTx3OpPwrBackoff.TabIndex = 38;
            this.m_lblProfileTx3OpPwrBackoff.Text = "O/p Pwr Backoff TX2 (dB)";
            this.m_nudStartFreqConst.DecimalPlaces = 6;
            this.m_nudStartFreqConst.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                393216
            });
            this.m_nudStartFreqConst.Location = new Point(192, 56);
            this.m_nudStartFreqConst.Margin = new Padding(4);
            NumericUpDown nudStartFreqConst = this.m_nudStartFreqConst;
            int[] array36 = new int[4];
            array36[0] = 81;
            nudStartFreqConst.Maximum = new decimal(array36);
            this.m_nudStartFreqConst.Name = "m_nudStartFreqConst";
            this.m_nudStartFreqConst.Size = new Size(116, 25);
            this.m_nudStartFreqConst.TabIndex = 3;
            this.m_nudStartFreqConst.Value = new decimal(new int[]
            {
                770,
                0,
                0,
                65536
            });
            this.m_nudStartFreqConst.ValueChanged += this.m_nudStartFreqConst_ValueChanged;
            this.m_lblProfileStartFreqConst.AutoSize = true;
            this.m_lblProfileStartFreqConst.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileStartFreqConst.Location = new Point(8, 56);
            this.m_lblProfileStartFreqConst.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileStartFreqConst.Name = "m_lblProfileStartFreqConst";
            this.m_lblProfileStartFreqConst.Size = new Size(116, 17);
            this.m_lblProfileStartFreqConst.TabIndex = 36;
            this.m_lblProfileStartFreqConst.Text = "Start Freq (GHz)";
            this.m_nudRampEndTime.DecimalPlaces = 2;
            this.m_nudRampEndTime.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudRampEndTime.Location = new Point(192, 281);
            this.m_nudRampEndTime.Margin = new Padding(4);
            NumericUpDown nudRampEndTime = this.m_nudRampEndTime;
            int[] array37 = new int[4];
            array37[0] = 5000;
            nudRampEndTime.Maximum = new decimal(array37);
            this.m_nudRampEndTime.Name = "m_nudRampEndTime";
            this.m_nudRampEndTime.Size = new Size(116, 25);
            this.m_nudRampEndTime.TabIndex = 17;
            NumericUpDown nudRampEndTime2 = this.m_nudRampEndTime;
            int[] array38 = new int[4];
            array38[0] = 60;
            nudRampEndTime2.Value = new decimal(array38);
            this.m_nudRampEndTime.ValueChanged += this.m_nudRampEndTime_ValueChanged;
            this.m_lblProfileRampEndTime.AutoSize = true;
            this.m_lblProfileRampEndTime.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileRampEndTime.Location = new Point(8, 281);
            this.m_lblProfileRampEndTime.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileRampEndTime.Name = "m_lblProfileRampEndTime";
            this.m_lblProfileRampEndTime.Size = new Size(144, 17);
            this.m_lblProfileRampEndTime.TabIndex = 34;
            this.m_lblProfileRampEndTime.Text = "Ramp End Time (µs)";
            this.m_nudIdleTimeConst.DecimalPlaces = 2;
            this.m_nudIdleTimeConst.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudIdleTimeConst.Location = new Point(192, 120);
            this.m_nudIdleTimeConst.Margin = new Padding(4);
            this.m_nudIdleTimeConst.Maximum = new decimal(new int[]
            {
                524287,
                0,
                0,
                131072
            });
            this.m_nudIdleTimeConst.Name = "m_nudIdleTimeConst";
            this.m_nudIdleTimeConst.Size = new Size(116, 25);
            this.m_nudIdleTimeConst.TabIndex = 7;
            NumericUpDown nudIdleTimeConst = this.m_nudIdleTimeConst;
            int[] array39 = new int[4];
            array39[0] = 100;
            nudIdleTimeConst.Value = new decimal(array39);
            this.m_nudIdleTimeConst.ValueChanged += this.m_nudIdleTimeConst_ValueChanged;
            this.m_lblProfileIdleTime.AutoSize = true;
            this.m_lblProfileIdleTime.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileIdleTime.Location = new Point(8, 120);
            this.m_lblProfileIdleTime.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileIdleTime.Name = "m_lblProfileIdleTime";
            this.m_lblProfileIdleTime.Size = new Size(96, 17);
            this.m_lblProfileIdleTime.TabIndex = 32;
            this.m_lblProfileIdleTime.Text = "Idle Time (µs)";
            this.m_nudAdcStartTimeConst.DecimalPlaces = 2;
            this.m_nudAdcStartTimeConst.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudAdcStartTimeConst.Location = new Point(192, 186);
            this.m_nudAdcStartTimeConst.Margin = new Padding(4);
            NumericUpDown nudAdcStartTimeConst = this.m_nudAdcStartTimeConst;
            int[] array40 = new int[4];
            array40[0] = 4095;
            nudAdcStartTimeConst.Maximum = new decimal(array40);
            this.m_nudAdcStartTimeConst.Name = "m_nudAdcStartTimeConst";
            this.m_nudAdcStartTimeConst.Size = new Size(116, 25);
            this.m_nudAdcStartTimeConst.TabIndex = 11;
            NumericUpDown nudAdcStartTimeConst2 = this.m_nudAdcStartTimeConst;
            int[] array41 = new int[4];
            array41[0] = 6;
            nudAdcStartTimeConst2.Value = new decimal(array41);
            this.m_nudAdcStartTimeConst.ValueChanged += this.m_nudAdcStartTimeConst_ValueChanged;
            this.m_lblProfileAdcStartTime.AutoSize = true;
            this.m_lblProfileAdcStartTime.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileAdcStartTime.Location = new Point(8, 186);
            this.m_lblProfileAdcStartTime.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileAdcStartTime.Name = "m_lblProfileAdcStartTime";
            this.m_lblProfileAdcStartTime.Size = new Size(140, 17);
            this.m_lblProfileAdcStartTime.TabIndex = 30;
            this.m_lblProfileAdcStartTime.Text = "ADC Start Time (µs)";
            this.m_nudNumAdcSamples.Location = new Point(192, 218);
            this.m_nudNumAdcSamples.Margin = new Padding(4);
            NumericUpDown nudNumAdcSamples = this.m_nudNumAdcSamples;
            int[] array42 = new int[4];
            array42[0] = 4096;
            nudNumAdcSamples.Maximum = new decimal(array42);
            NumericUpDown nudNumAdcSamples2 = this.m_nudNumAdcSamples;
            int[] array43 = new int[4];
            array43[0] = 64;
            nudNumAdcSamples2.Minimum = new decimal(array43);
            this.m_nudNumAdcSamples.Name = "m_nudNumAdcSamples";
            this.m_nudNumAdcSamples.Size = new Size(116, 25);
            this.m_nudNumAdcSamples.TabIndex = 13;
            NumericUpDown nudNumAdcSamples3 = this.m_nudNumAdcSamples;
            int[] array44 = new int[4];
            array44[0] = 256;
            nudNumAdcSamples3.Value = new decimal(array44);
            this.m_lblProfileAdcSamples.AutoSize = true;
            this.m_lblProfileAdcSamples.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileAdcSamples.Location = new Point(8, 218);
            this.m_lblProfileAdcSamples.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileAdcSamples.Name = "m_lblProfileAdcSamples";
            this.m_lblProfileAdcSamples.Size = new Size(101, 17);
            this.m_lblProfileAdcSamples.TabIndex = 28;
            this.m_lblProfileAdcSamples.Text = "ADC Samples";
            this.m_nudDigOutSampleRate.Location = new Point(192, 249);
            this.m_nudDigOutSampleRate.Margin = new Padding(4);
            NumericUpDown nudDigOutSampleRate = this.m_nudDigOutSampleRate;
            int[] array45 = new int[4];
            array45[0] = 60000;
            nudDigOutSampleRate.Maximum = new decimal(array45);
            NumericUpDown nudDigOutSampleRate2 = this.m_nudDigOutSampleRate;
            int[] array46 = new int[4];
            array46[0] = 200;
            nudDigOutSampleRate2.Minimum = new decimal(array46);
            this.m_nudDigOutSampleRate.Name = "m_nudDigOutSampleRate";
            this.m_nudDigOutSampleRate.Size = new Size(116, 25);
            this.m_nudDigOutSampleRate.TabIndex = 15;
            NumericUpDown nudDigOutSampleRate3 = this.m_nudDigOutSampleRate;
            int[] array47 = new int[4];
            array47[0] = 10000;
            nudDigOutSampleRate3.Value = new decimal(array47);
            this.m_nudDigOutSampleRate.ValueChanged += this.m_nudNumOfProfileCSampleRate_ValueChanged;
            this.m_lblProfileSampleRate.AutoSize = true;
            this.m_lblProfileSampleRate.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileSampleRate.Location = new Point(8, 249);
            this.m_lblProfileSampleRate.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileSampleRate.Name = "m_lblProfileSampleRate";
            this.m_lblProfileSampleRate.Size = new Size(138, 17);
            this.m_lblProfileSampleRate.TabIndex = 26;
            this.m_lblProfileSampleRate.Text = "Sample Rate (ksps)";
            this.m_lblProfileRxGain.AutoSize = true;
            this.m_lblProfileRxGain.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileRxGain.Location = new Point(8, 314);
            this.m_lblProfileRxGain.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileRxGain.Name = "m_lblProfileRxGain";
            this.m_lblProfileRxGain.Size = new Size(94, 17);
            this.m_lblProfileRxGain.TabIndex = 24;
            this.m_lblProfileRxGain.Text = "RX Gain (dB)";
            this.m_cboProfileHpf2.DisplayMember = "0";
            this.m_cboProfileHpf2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.m_cboProfileHpf2.FormattingEnabled = true;
            this.m_cboProfileHpf2.Items.AddRange(new object[]
            {
                "350K",
                "700K",
                "1.4M",
                "2.8M"
            });
            this.m_cboProfileHpf2.Location = new Point(504, 56);
            this.m_cboProfileHpf2.Margin = new Padding(4);
            this.m_cboProfileHpf2.Name = "m_cboProfileHpf2";
            this.m_cboProfileHpf2.RightToLeft = RightToLeft.No;
            this.m_cboProfileHpf2.Size = new Size(115, 25);
            this.m_cboProfileHpf2.TabIndex = 4;
            this.m_lblProfileHpf2.AutoSize = true;
            this.m_lblProfileHpf2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileHpf2.Location = new Point(328, 56);
            this.m_lblProfileHpf2.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileHpf2.Name = "m_lblProfileHpf2";
            this.m_lblProfileHpf2.Size = new Size(128, 17);
            this.m_lblProfileHpf2.TabIndex = 22;
            this.m_lblProfileHpf2.Text = "HPF2 Corner Freq";
            this.m_cboProfileHpf1.DisplayMember = "0";
            this.m_cboProfileHpf1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.m_cboProfileHpf1.FormattingEnabled = true;
            this.m_cboProfileHpf1.Items.AddRange(new object[]
            {
                "175K",
                "235K",
                "350K",
                "700K"
            });
            this.m_cboProfileHpf1.Location = new Point(504, 25);
            this.m_cboProfileHpf1.Margin = new Padding(4);
            this.m_cboProfileHpf1.Name = "m_cboProfileHpf1";
            this.m_cboProfileHpf1.RightToLeft = RightToLeft.No;
            this.m_cboProfileHpf1.Size = new Size(115, 25);
            this.m_cboProfileHpf1.TabIndex = 2;
            this.m_lblProfileHpf1.AutoSize = true;
            this.m_lblProfileHpf1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileHpf1.Location = new Point(328, 25);
            this.m_lblProfileHpf1.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileHpf1.Name = "m_lblProfileHpf1";
            this.m_lblProfileHpf1.Size = new Size(128, 17);
            this.m_lblProfileHpf1.TabIndex = 20;
            this.m_lblProfileHpf1.Text = "HPF1 Corner Freq";
            this.m_nudProfileProfileId.Location = new Point(192, 25);
            this.m_nudProfileProfileId.Margin = new Padding(4);
            NumericUpDown nudProfileProfileId = this.m_nudProfileProfileId;
            int[] array48 = new int[4];
            array48[0] = 15;
            nudProfileProfileId.Maximum = new decimal(array48);
            this.m_nudProfileProfileId.Name = "m_nudProfileProfileId";
            this.m_nudProfileProfileId.Size = new Size(116, 25);
            this.m_nudProfileProfileId.TabIndex = 1;
            this.m_nudProfileProfileId.ValueChanged += this.m_nudProfileProfileId_ValueChanged;
            this.m_lblProfileProfileId.AutoSize = true;
            this.m_lblProfileProfileId.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileProfileId.Location = new Point(8, 25);
            this.m_lblProfileProfileId.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileProfileId.Name = "m_lblProfileProfileId";
            this.m_lblProfileProfileId.Size = new Size(64, 17);
            this.m_lblProfileProfileId.TabIndex = 2;
            this.m_lblProfileProfileId.Text = "Profile Id";
            this.m_grpChirp.Controls.Add(this.m_btnMangChirps);
            this.m_grpChirp.Controls.Add(this.f00016a);
            this.m_grpChirp.Controls.Add(this.f00016b);
            this.m_grpChirp.Controls.Add(this.f00016c);
            this.m_grpChirp.Controls.Add(this.m_nudChirpAdcStart);
            this.m_grpChirp.Controls.Add(this.m_nudChirpIdleTime);
            this.m_grpChirp.Controls.Add(this.m_nudChirpStartFreq);
            this.m_grpChirp.Controls.Add(this.m_nudChirpFreqSlope);
            this.m_grpChirp.Controls.Add(this.m_nudChirpEnd);
            this.m_grpChirp.Controls.Add(this.m_nudChirpStartIdx);
            this.m_grpChirp.Controls.Add(this.m_nudChirpProfileId);
            this.m_grpChirp.Controls.Add(this.m_lblChirpTxEnable);
            this.m_grpChirp.Controls.Add(this.m_lblChirpAdcStart);
            this.m_grpChirp.Controls.Add(this.m_lblChirpIdleTime);
            this.m_grpChirp.Controls.Add(this.m_lblChirpfreqSlope);
            this.m_grpChirp.Controls.Add(this.m_lblChirpStartFreq);
            this.m_grpChirp.Controls.Add(this.m_lblChirpEndIdx);
            this.m_grpChirp.Controls.Add(this.m_btnChirpSet);
            this.m_grpChirp.Controls.Add(this.m_lblChirpStartIdx);
            this.m_grpChirp.Controls.Add(this.m_lblChirpProfileId);
            this.m_grpChirp.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_grpChirp.Location = new Point(8, 461);
            this.m_grpChirp.Margin = new Padding(4);
            this.m_grpChirp.Name = "m_grpChirp";
            this.m_grpChirp.Padding = new Padding(4);
            this.m_grpChirp.Size = new Size(572, 280);
            this.m_grpChirp.TabIndex = 6;
            this.m_grpChirp.TabStop = false;
            this.m_grpChirp.Text = "Chirp";
            this.m_btnMangChirps.Location = new Point(439, 231);
            this.m_btnMangChirps.Margin = new Padding(4);
            this.m_btnMangChirps.Name = "m_btnMangChirps";
            this.m_btnMangChirps.Size = new Size(126, 39);
            this.m_btnMangChirps.TabIndex = 38;
            this.m_btnMangChirps.Text = "Manage Chirps";
            this.m_btnMangChirps.UseVisualStyleBackColor = true;
            this.m_btnMangChirps.Click += this.m_btnMangChirps_Click;
            this.f00016a.AutoSize = true;
            this.f00016a.Location = new Point(446, 175);
            this.f00016a.Margin = new Padding(4);
            this.f00016a.Name = "m_chbTxCfg3";
            this.f00016a.Size = new Size(56, 21);
            this.f00016a.TabIndex = 36;
            this.f00016a.Text = "TX2";
            this.f00016a.UseVisualStyleBackColor = true;
            this.f00016b.AutoSize = true;
            this.f00016b.Checked = true;
            this.f00016b.CheckState = CheckState.Checked;
            this.f00016b.Location = new Point(368, 175);
            this.f00016b.Margin = new Padding(4);
            this.f00016b.Name = "m_chbTxCfg2";
            this.f00016b.Size = new Size(56, 21);
            this.f00016b.TabIndex = 35;
            this.f00016b.Text = "TX1";
            this.f00016b.UseVisualStyleBackColor = true;
            this.f00016c.AutoSize = true;
            this.f00016c.Checked = true;
            this.f00016c.CheckState = CheckState.Checked;
            this.f00016c.Location = new Point(298, 175);
            this.f00016c.Margin = new Padding(4);
            this.f00016c.Name = "m_chbTxCfg1";
            this.f00016c.Size = new Size(56, 21);
            this.f00016c.TabIndex = 34;
            this.f00016c.Text = "TX0";
            this.f00016c.UseVisualStyleBackColor = true;
            this.f00016c.CheckedChanged += this.m_chbTxCfg1_CheckedChanged;
            this.m_nudChirpAdcStart.DecimalPlaces = 2;
            this.m_nudChirpAdcStart.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudChirpAdcStart.Location = new Point(476, 112);
            this.m_nudChirpAdcStart.Margin = new Padding(4);
            NumericUpDown nudChirpAdcStart = this.m_nudChirpAdcStart;
            int[] array49 = new int[4];
            array49[0] = 40;
            nudChirpAdcStart.Maximum = new decimal(array49);
            this.m_nudChirpAdcStart.Name = "m_nudChirpAdcStart";
            this.m_nudChirpAdcStart.Size = new Size(89, 25);
            this.m_nudChirpAdcStart.TabIndex = 32;
            this.m_nudChirpAdcStart.ValueChanged += this.m_nudChirpAdcStart_ValueChanged;
            this.m_nudChirpIdleTime.DecimalPlaces = 2;
            this.m_nudChirpIdleTime.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                131072
            });
            this.m_nudChirpIdleTime.Location = new Point(476, 75);
            this.m_nudChirpIdleTime.Margin = new Padding(4);
            NumericUpDown nudChirpIdleTime = this.m_nudChirpIdleTime;
            int[] array50 = new int[4];
            array50[0] = 40;
            nudChirpIdleTime.Maximum = new decimal(array50);
            this.m_nudChirpIdleTime.Name = "m_nudChirpIdleTime";
            this.m_nudChirpIdleTime.Size = new Size(89, 25);
            this.m_nudChirpIdleTime.TabIndex = 30;
            this.m_nudChirpIdleTime.ValueChanged += this.m_nudChirpIdleTime_ValueChanged;
            this.m_nudChirpStartFreq.DecimalPlaces = 6;
            this.m_nudChirpStartFreq.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                393216
            });
            this.m_nudChirpStartFreq.Location = new Point(158, 150);
            this.m_nudChirpStartFreq.Margin = new Padding(4);
            NumericUpDown nudChirpStartFreq = this.m_nudChirpStartFreq;
            int[] array51 = new int[4];
            array51[0] = 453;
            nudChirpStartFreq.Maximum = new decimal(array51);
            this.m_nudChirpStartFreq.Name = "m_nudChirpStartFreq";
            this.m_nudChirpStartFreq.Size = new Size(101, 25);
            this.m_nudChirpStartFreq.TabIndex = 33;
            this.m_nudChirpStartFreq.ValueChanged += this.m_nudChirpStartFreq_ValueChanged;
            this.m_nudChirpFreqSlope.DecimalPlaces = 3;
            this.m_nudChirpFreqSlope.Increment = new decimal(new int[]
            {
                1,
                0,
                0,
                196608
            });
            this.m_nudChirpFreqSlope.Location = new Point(476, 38);
            this.m_nudChirpFreqSlope.Margin = new Padding(4);
            this.m_nudChirpFreqSlope.Maximum = new decimal(new int[]
            {
                3024,
                0,
                0,
                65536
            });
            this.m_nudChirpFreqSlope.Name = "m_nudChirpFreqSlope";
            this.m_nudChirpFreqSlope.Size = new Size(89, 25);
            this.m_nudChirpFreqSlope.TabIndex = 28;
            this.m_nudChirpFreqSlope.ValueChanged += this.m_nudChirpFreqSlope_ValueChanged;
            this.m_nudChirpEnd.Location = new Point(158, 112);
            this.m_nudChirpEnd.Margin = new Padding(4);
            NumericUpDown nudChirpEnd = this.m_nudChirpEnd;
            int[] array52 = new int[4];
            array52[0] = 511;
            nudChirpEnd.Maximum = new decimal(array52);
            this.m_nudChirpEnd.Name = "m_nudChirpEnd";
            this.m_nudChirpEnd.Size = new Size(101, 25);
            this.m_nudChirpEnd.TabIndex = 31;
            this.m_nudChirpStartIdx.Location = new Point(158, 75);
            this.m_nudChirpStartIdx.Margin = new Padding(4);
            NumericUpDown nudChirpStartIdx = this.m_nudChirpStartIdx;
            int[] array53 = new int[4];
            array53[0] = 511;
            nudChirpStartIdx.Maximum = new decimal(array53);
            this.m_nudChirpStartIdx.Name = "m_nudChirpStartIdx";
            this.m_nudChirpStartIdx.Size = new Size(101, 25);
            this.m_nudChirpStartIdx.TabIndex = 29;
            this.m_nudChirpProfileId.Location = new Point(158, 38);
            this.m_nudChirpProfileId.Margin = new Padding(4);
            NumericUpDown nudChirpProfileId = this.m_nudChirpProfileId;
            int[] array54 = new int[4];
            array54[0] = 3;
            nudChirpProfileId.Maximum = new decimal(array54);
            this.m_nudChirpProfileId.Name = "m_nudChirpProfileId";
            this.m_nudChirpProfileId.Size = new Size(101, 25);
            this.m_nudChirpProfileId.TabIndex = 27;
            this.m_lblChirpTxEnable.AutoSize = true;
            this.m_lblChirpTxEnable.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblChirpTxEnable.Location = new Point(266, 150);
            this.m_lblChirpTxEnable.Margin = new Padding(4, 0, 4, 0);
            this.m_lblChirpTxEnable.Name = "m_lblChirpTxEnable";
            this.m_lblChirpTxEnable.Size = new Size(186, 17);
            this.m_lblChirpTxEnable.TabIndex = 11;
            this.m_lblChirpTxEnable.Text = "TX Enable for current chirp ";
            this.m_lblChirpAdcStart.AutoSize = true;
            this.m_lblChirpAdcStart.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblChirpAdcStart.Location = new Point(266, 112);
            this.m_lblChirpAdcStart.Margin = new Padding(4, 0, 4, 0);
            this.m_lblChirpAdcStart.Name = "m_lblChirpAdcStart";
            this.m_lblChirpAdcStart.Size = new Size(129, 17);
            this.m_lblChirpAdcStart.TabIndex = 10;
            this.m_lblChirpAdcStart.Text = "ADC Start Var (µs)";
            this.m_lblChirpIdleTime.AutoSize = true;
            this.m_lblChirpIdleTime.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblChirpIdleTime.Location = new Point(266, 75);
            this.m_lblChirpIdleTime.Margin = new Padding(4, 0, 4, 0);
            this.m_lblChirpIdleTime.Name = "m_lblChirpIdleTime";
            this.m_lblChirpIdleTime.Size = new Size(121, 17);
            this.m_lblChirpIdleTime.TabIndex = 9;
            this.m_lblChirpIdleTime.Text = "Idle Time Var (µs)";
            this.m_lblChirpfreqSlope.AutoSize = true;
            this.m_lblChirpfreqSlope.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblChirpfreqSlope.Location = new Point(266, 38);
            this.m_lblChirpfreqSlope.Margin = new Padding(4, 0, 4, 0);
            this.m_lblChirpfreqSlope.Name = "m_lblChirpfreqSlope";
            this.m_lblChirpfreqSlope.Size = new Size(206, 17);
            this.m_lblChirpfreqSlope.TabIndex = 8;
            this.m_lblChirpfreqSlope.Text = "Frequency Slope Var (MHz/µs)";
            this.m_lblChirpStartFreq.AutoSize = true;
            this.m_lblChirpStartFreq.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblChirpStartFreq.Location = new Point(11, 150);
            this.m_lblChirpStartFreq.Margin = new Padding(4, 0, 4, 0);
            this.m_lblChirpStartFreq.Name = "m_lblChirpStartFreq";
            this.m_lblChirpStartFreq.Size = new Size(145, 17);
            this.m_lblChirpStartFreq.TabIndex = 7;
            this.m_lblChirpStartFreq.Text = "Start Freq Var (MHz) ";
            this.m_lblChirpStartFreq.Click += this.m_lblChirpStartFreq_Click;
            this.m_lblChirpEndIdx.AutoSize = true;
            this.m_lblChirpEndIdx.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblChirpEndIdx.Location = new Point(11, 112);
            this.m_lblChirpEndIdx.Margin = new Padding(4, 0, 4, 0);
            this.m_lblChirpEndIdx.Name = "m_lblChirpEndIdx";
            this.m_lblChirpEndIdx.Size = new Size(121, 17);
            this.m_lblChirpEndIdx.TabIndex = 5;
            this.m_lblChirpEndIdx.Text = "End Chirp for Cfg";
            this.m_btnChirpSet.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_btnChirpSet.Location = new Point(289, 231);
            this.m_btnChirpSet.Margin = new Padding(4);
            this.m_btnChirpSet.Name = "m_btnChirpSet";
            this.m_btnChirpSet.Size = new Size(126, 39);
            this.m_btnChirpSet.TabIndex = 37;
            this.m_btnChirpSet.Text = "Set";
            this.m_btnChirpSet.UseVisualStyleBackColor = true;
            this.m_btnChirpSet.Click += this.m_btnChirpSet_Click;
            this.m_lblChirpStartIdx.AutoSize = true;
            this.m_lblChirpStartIdx.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblChirpStartIdx.Location = new Point(11, 75);
            this.m_lblChirpStartIdx.Margin = new Padding(4, 0, 4, 0);
            this.m_lblChirpStartIdx.Name = "m_lblChirpStartIdx";
            this.m_lblChirpStartIdx.Size = new Size(126, 17);
            this.m_lblChirpStartIdx.TabIndex = 2;
            this.m_lblChirpStartIdx.Text = "Start Chirp for Cfg";
            this.m_lblChirpProfileId.AutoSize = true;
            this.m_lblChirpProfileId.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblChirpProfileId.Location = new Point(11, 38);
            this.m_lblChirpProfileId.Margin = new Padding(4, 0, 4, 0);
            this.m_lblChirpProfileId.Name = "m_lblChirpProfileId";
            this.m_lblChirpProfileId.Size = new Size(64, 17);
            this.m_lblChirpProfileId.TabIndex = 1;
            this.m_lblChirpProfileId.Text = "Profile Id";
            this.m_timerTrigFrameCout.Tick += this.m_timerTrigFrameCout_Tick;
            this.m_timerTDANumFrames.Tick += this.m_timerTDANumFrames_Tick;
            base.AutoScaleDimensions = new SizeF(120f, 120f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            base.Controls.Add(this.m_chkboxMonRepGUI);
            base.Margin = new Padding(4);
            base.Name = "ChirpConfigTab";
            base.Size = new Size(1594, 757);
            base.Load += this.ChirpConfigTab_Load;
            this.m_chkboxMonRepGUI.ResumeLayout(false);
            this.m_grpTDAWidthHeight.ResumeLayout(false);
            this.m_grpTDAWidthHeight.PerformLayout();
            this.m_grpFrame.ResumeLayout(false);
            this.m_grpFrame.PerformLayout();
            ((ISupportInitialize)this.m_nudDummyChirpsEnd).EndInit();
            ((ISupportInitialize)this.m_nudFrameTriggerDelay).EndInit();
            ((ISupportInitialize)this.m_nudFramePeriodicity).EndInit();
            ((ISupportInitialize)this.m_nudFrameLoops).EndInit();
            ((ISupportInitialize)this.m_nudFrameNumbers).EndInit();
            ((ISupportInitialize)this.m_nudFrameEndChirp).EndInit();
            ((ISupportInitialize)this.m_nudFrameStartChirp).EndInit();
            this.m_grpTxCalibControlTxChannel.ResumeLayout(false);
            this.m_grpTxCalibControlTxChannel.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx3FreqShift).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx4FreqShift).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx2FreqShift).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx1FreqShift).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx3PhaseShift).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx4PhaseShift).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx2PhaseShift).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx1PhaseShift).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx4Gain).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx3Gain).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx2Gain).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseDigitalRx1Gain).EndInit();
            ((ISupportInitialize)this.m_nudInterRxGainPhaseProfileIndex).EndInit();
            this.m_grpDynamicPowerSave.ResumeLayout(false);
            this.m_grpDynamicPowerSave.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.m_grpPostProcOptions.ResumeLayout(false);
            this.m_grpPostProcOptions.PerformLayout();
            this.m_grpFramingStatus.ResumeLayout(false);
            this.m_grpFramingStatus.PerformLayout();
            this.m_grpEnableNumFilesCapture.ResumeLayout(false);
            this.m_grpEnableNumFilesCapture.PerformLayout();
            ((ISupportInitialize)this.m_nudFileAllocation).EndInit();
            ((ISupportInitialize)this.m_nudNumFramesToCapture).EndInit();
            ((ISupportInitialize)this.pictureBox1).EndInit();
            this.m_grpProfile.ResumeLayout(false);
            this.m_grpProfile.PerformLayout();
            ((ISupportInitialize)this.m_nudTx3PhaseShifter).EndInit();
            ((ISupportInitialize)this.m_nudTx2PhaseShifter).EndInit();
            ((ISupportInitialize)this.m_nudTx1PhaseShifter).EndInit();
            ((ISupportInitialize)this.m_nudTx2OutPowerBackoffCode).EndInit();
            ((ISupportInitialize)this.m_nudTx1OutPowerBackoffCode).EndInit();
            ((ISupportInitialize)this.m_nudProfileRxGain).EndInit();
            ((ISupportInitialize)this.m_nudTxStartTime).EndInit();
            ((ISupportInitialize)this.m_nudFreqSlopeConst).EndInit();
            ((ISupportInitialize)this.m_nudTx3OutPowerBackoffCode).EndInit();
            ((ISupportInitialize)this.m_nudStartFreqConst).EndInit();
            ((ISupportInitialize)this.m_nudRampEndTime).EndInit();
            ((ISupportInitialize)this.m_nudIdleTimeConst).EndInit();
            ((ISupportInitialize)this.m_nudAdcStartTimeConst).EndInit();
            ((ISupportInitialize)this.m_nudNumAdcSamples).EndInit();
            ((ISupportInitialize)this.m_nudDigOutSampleRate).EndInit();
            ((ISupportInitialize)this.m_nudProfileProfileId).EndInit();
            this.m_grpChirp.ResumeLayout(false);
            this.m_grpChirp.PerformLayout();
            ((ISupportInitialize)this.m_nudChirpAdcStart).EndInit();
            ((ISupportInitialize)this.m_nudChirpIdleTime).EndInit();
            ((ISupportInitialize)this.m_nudChirpStartFreq).EndInit();
            ((ISupportInitialize)this.m_nudChirpFreqSlope).EndInit();
            ((ISupportInitialize)this.m_nudChirpEnd).EndInit();
            ((ISupportInitialize)this.m_nudChirpStartIdx).EndInit();
            ((ISupportInitialize)this.m_nudChirpProfileId).EndInit();
            base.ResumeLayout(false);
        }

        private void PostInitialization()
        {
            this.m_cboProfileHpf1.SelectedIndex = 0;
            this.m_cboProfileHpf2.SelectedIndex = 0;
        }

        private GuiManager m_GuiManager = GlobalRef.GuiManager;

        private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

        private frmAR1Main m_MainForm;

        public ChirpManager m_ChirpManager;

        public ProfManager m_ProfManager;

        public ChirpConfigParams m_ChirpConfigParams;

        public DynamicPowerSaveConfigParams m_DynamicPowerSaveConfigParams;

        public InterRxGainPhaseFreqControlConfigParameters m_InterRxGainPhaseFreqControlConfigParameters;

        public bool m_bDownlaodFilesAbort;

        private IContainer components;

        private GroupBox m_chkboxMonRepGUI;

        private GroupBox m_grpFrame;

        private Button m_btnFrameSet;

        private NumericUpDown m_nudFrameTriggerDelay;

        private Label m_lblFrameTriggerDelay;

        private NumericUpDown m_nudFramePeriodicity;

        private Label m_lblFramePeriodicity;

        private NumericUpDown m_nudFrameLoops;

        private Label m_lblFrameLoops;

        private NumericUpDown m_nudFrameNumbers;

        private Label m_lblFrameNumbers;

        private NumericUpDown m_nudFrameEndChirp;

        private NumericUpDown m_nudFrameStartChirp;

        private Label m_lblFrameEndChirp;

        private Label m_lblFrameStartChirp;

        private GroupBox m_grpChirp;

        private CheckBox f00016a;

        private CheckBox f00016b;

        private CheckBox f00016c;

        private NumericUpDown m_nudChirpAdcStart;

        private NumericUpDown m_nudChirpIdleTime;

        private NumericUpDown m_nudChirpStartFreq;

        private NumericUpDown m_nudChirpFreqSlope;

        private NumericUpDown m_nudChirpEnd;

        private NumericUpDown m_nudChirpStartIdx;

        private NumericUpDown m_nudChirpProfileId;

        private Label m_lblChirpTxEnable;

        private Label m_lblChirpAdcStart;

        private Label m_lblChirpIdleTime;

        private Label m_lblChirpfreqSlope;

        private Label m_lblChirpStartFreq;

        private Label m_lblChirpEndIdx;

        private Button m_btnChirpSet;

        private Label m_lblChirpStartIdx;

        private Label m_lblChirpProfileId;

        private Button m_btnFrameStart;

        private GroupBox m_grpProfile;

        private NumericUpDown m_nudProfileRxGain;

        private Button m_btnProfileSet;

        private NumericUpDown m_nudTxStartTime;

        private Label m_lblProfileTxStartTime;

        private NumericUpDown m_nudFreqSlopeConst;

        private Label m_lblProfileFreqSlope;

        private Label m_lblProfilePhaseShifter;

        private NumericUpDown m_nudTx3OutPowerBackoffCode;

        private Label m_lblProfileTx3OpPwrBackoff;

        private NumericUpDown m_nudStartFreqConst;

        private Label m_lblProfileStartFreqConst;

        private NumericUpDown m_nudRampEndTime;

        private Label m_lblProfileRampEndTime;

        private NumericUpDown m_nudIdleTimeConst;

        private Label m_lblProfileIdleTime;

        private NumericUpDown m_nudAdcStartTimeConst;

        private Label m_lblProfileAdcStartTime;

        private NumericUpDown m_nudNumAdcSamples;

        private Label m_lblProfileAdcSamples;

        private NumericUpDown m_nudDigOutSampleRate;

        private Label m_lblProfileSampleRate;

        private Label m_lblProfileRxGain;

        private ComboBox m_cboProfileHpf2;

        private Label m_lblProfileHpf2;

        private ComboBox m_cboProfileHpf1;

        private Label m_lblProfileHpf1;

        private NumericUpDown m_nudProfileProfileId;

        private Label m_lblProfileProfileId;

        private Label label2;

        private Label label1;

        private PictureBox pictureBox1;

        private Button m_btnMangChirps;

        private Button m_btnMangProfiles;

        private NumericUpDown m_nudTx2OutPowerBackoffCode;

        private NumericUpDown m_nudTx1OutPowerBackoffCode;

        private Label m_lblProfileTx2OpPwrBackoff;

        private Label m_lblProfileTx1OpPwrBackoff;

        private Button f00016d;

        private Button m_btnPostProc;

        private Button m_btnMtLbPPTarget;

        private SaveFileDialog m_ofdlgFrMtLbPP;

        private Button m_btnRealTime;

        private GroupBox groupBox2;

        private System.Windows.Forms.Timer m_timerTrigFrameCout;

        private CheckBox m_chbTestSourceEnable;

        private Label label4;

        private Label m_lblBandwidth;

        private ComboBox m_cboADC_DataFile;

        private Label m_lblFrameDutyCycle;

        private Label label5;

        private NumericUpDown m_nudTx1PhaseShifter;

        private NumericUpDown m_nudTx2PhaseShifter;

        private NumericUpDown m_nudTx3PhaseShifter;

        private Label m_lblTriggerSelect;

        private ComboBox m_cboFrameTriggerSelect;

        private GroupBox m_grpDynamicPowerSave;

        private Button m_btnDynamicPowerSaveSet;

        private CheckBox m_chbDynamicPowerSaveLO;

        private CheckBox m_chbDynamicPowerSaveRx;

        private CheckBox m_chbDynamicPowerSaveTx;

        private GroupBox groupBox3;

        private Button m_btnInterRxGainPhaseFreqControlSet;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx3FreqShift;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx4FreqShift;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx2FreqShift;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx1FreqShift;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx3PhaseShift;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx4PhaseShift;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx2PhaseShift;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx1PhaseShift;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx4Gain;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx3Gain;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx2Gain;

        private NumericUpDown m_nudInterRxGainPhaseDigitalRx1Gain;

        private NumericUpDown m_nudInterRxGainPhaseProfileIndex;

        private Label label8;

        private Label label9;

        private Label label7;

        private Label label6;

        private Label label13;

        private Label label12;

        private Label label11;

        private Label label10;

        private Label label14;

        private ComboBox m_cboProfileRFGainTarget;

        private CheckBox m_chbProfileForceVCOSelect;

        private ComboBox m_cboProfileVCOSelect;

        private Label label15;

        private CheckBox m_chbProfileRetainRxCalLUT;

        private CheckBox m_chbProfileRetainTxCalLUT;

        private Label label16;

        private GroupBox m_grpTxCalibControlTxChannel;

        private Label label22;

        private Label label21;

        private Label label20;

        private Label label19;

        private Label label18;

        private Label label17;

        private CheckBox m_chbTX2CalibTx2;

        private CheckBox m_chbTX1CalibTx2;

        private CheckBox m_chbTX0CalibTx2;

        private CheckBox m_chbTX2CalibTx1;

        private CheckBox m_chbTX1CalibTx1;

        private CheckBox m_chbTX0CalibTx1;

        private CheckBox m_chbTX2CalibTx0;

        private CheckBox m_chbTX1CalibTx0;

        private CheckBox m_chbTX0CalibTx0;

        private Label m_lblFrameActiveRampDutyCycle;

        private Label label23;

        private NumericUpDown m_nudDummyChirpsEnd;

        private Label m_lblDummyChirps;

        private Button m_btnTransferFiles;

        private GroupBox m_grpFramingStatus;

        private Label m_lblDev4FramingStatus;

        private Label m_lblDev3FramingStatus;

        private Label m_lblDev2FramingStatus;

        private Label m_lblDev1FramingStatus;

        private Label label27;

        private Label label26;

        private Label label25;

        private Label label24;

        private Button m_btnStopFrame;

        private GroupBox m_grpPostProcOptions;

        private RadioButton f00016e;

        private RadioButton f00016f;

        private RadioButton m_btnBasicPostProc;

        private GroupBox m_grpTDAWidthHeight;

        private Label m_txtTDACaptureHeight;

        private Label label33;

        private Label m_txtTDACaptureWidth;

        private Button m_btnGetTDAWidthHeight;

        private Label label31;

        private GroupBox m_grpEnableNumFilesCapture;

        private NumericUpDown m_nudNumFramesToCapture;

        private Label label32;

        private System.Windows.Forms.Timer m_timerTDANumFrames;

        private Button m_btnTDAStopCapture;

        private CheckBox m_ChkEnaDisablePackaging;

        private Label label28;

        private NumericUpDown m_nudFileAllocation;

        private Label label29;
    }
}
