using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AR1xController
{
	public class BpmConfigTab : UserControl
	{
		public BpmConfigTab()
		{
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_BpmChirpConfigParams = this.m_GuiManager.TsParams.BpmChirpConfigParams;
			this.m_PerChirpPhaseShifterConfigParams = this.m_GuiManager.TsParams.PerChirpPhaseShifterConfigParams;
			this.m_AdvanceBPMPatternConfigParams = this.m_GuiManager.TsParams.AdvanceBPMPatternConfigParams;
			this.InitializeComponent();
			if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device || GlobalRef.g_AR1843Device)
			{
				this.m_grpPerChirpPhaseShifterCfg.Visible = true;
			}
			else if (GlobalRef.g_AR16xxDevice)
			{
				this.m_grpPerChirpPhaseShifterCfg.Visible = false;
			}
			this.m_cboResetOption.SelectedIndex = 0;
			this.m_grpAdvanceBPMPatternCfg.Visible = false;
		}

		public void DisablePerChirpPhaseShifterFor16XXARDevice()
		{
			if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR14xxDevice || GlobalRef.g_AR1843Device || GlobalRef.g_AR6843Device || GlobalRef.g_AR2243Device)
			{
				this.m_grpPerChirpPhaseShifterCfg.Enabled = true;
				return;
			}
			if (GlobalRef.g_AR16xxDevice)
			{
				this.m_grpPerChirpPhaseShifterCfg.Enabled = false;
			}
		}

		public void DisablePerChirpPhaseShifterFor14XXARDevice()
		{
			if (GlobalRef.g_AR14xxDevice)
			{
				this.m_grpPerChirpPhaseShifterCfg.Enabled = true;
			}
		}

		public bool UpdateBpmChirpConfigGui(RootObject jobject, int p1, int chirpInd)
		{
			this.m_nudStrtIdx.Value = jobject.mmWaveDevices[p1].rfConfig.p000012[0].p000008.chirpStartIdx;
			this.m_nudEndIdx.Value = jobject.mmWaveDevices[p1].rfConfig.p000012[0].p000008.chirpEndIdx;
			int num = Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000012[0].p000008.constBpmVal, 16);
			this.m_nudTx0Off.Value = (num & 1);
			this.m_nudTx0On.Value = (num & 2) >> 1;
			this.m_nudTx1Off.Value = (num & 4) >> 2;
			this.m_nudTx1On.Value = (num & 8) >> 3;
			this.m_nudTx2Off.Value = (num & 16) >> 4;
			this.m_nudTx2On.Value = (num & 32) >> 5;
			return true;
		}

		public bool UpdatePerChirpPhaseShifterGui(RootObject jobject, int p1, int chirpInd)
		{
			this.m_nudChirpStartIndex.Value = jobject.mmWaveDevices[p1].rfConfig.p000015[chirpInd].rlRfPhaseShiftCfg_t.chirpStartIdx;
			this.m_nudChirpEndIndex.Value = jobject.mmWaveDevices[p1].rfConfig.p000015[chirpInd].rlRfPhaseShiftCfg_t.chirpEndIdx;
			this.m_nudTx0PhaseShifter.Value = jobject.mmWaveDevices[p1].rfConfig.p000015[chirpInd].rlRfPhaseShiftCfg_t.tx0PhaseShift;
			this.m_nudTx1PhaseShifter.Value = jobject.mmWaveDevices[p1].rfConfig.p000015[chirpInd].rlRfPhaseShiftCfg_t.tx1PhaseShift;
			this.m_nudTx2PhaseShifter.Value = jobject.mmWaveDevices[p1].rfConfig.p000015[chirpInd].rlRfPhaseShiftCfg_t.tx2PhaseShift;
			return true;
		}

		public bool UpdateBpmChirpConfig(RootObject jobject, int p1)
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
				if (jobject.mmWaveDevices[p1].rfConfig.p000012.Count == 0)
				{
					string msg = string.Format("Missing BPM Chirps Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg);
				}
				else
				{
					this.UpdateBpmChirpConfigGui(jobject, p1, 0);
					string path = Path.GetDirectoryName(Application.StartupPath) + "\\Clients\\AR1xController\\BPMData.csv";
					if (File.Exists(path))
					{
						File.Delete(path);
					}
					StreamWriter streamWriter = new StreamWriter(path);
					string value = "Tx0Off ,Tx0On ,Tx1Off ,Tx1On ,Tx2Off ,Tx2On";
					streamWriter.WriteLine(value);
					int count = GlobalRef.jobject.mmWaveDevices[p1].rfConfig.p000012.Count;
					for (int i = 0; i < count; i++)
					{
						int chirpStartIdx = jobject.mmWaveDevices[p1].rfConfig.p000012[i].p000008.chirpStartIdx;
						int chirpEndIdx = jobject.mmWaveDevices[p1].rfConfig.p000012[i].p000008.chirpEndIdx;
						for (int j = chirpStartIdx; j <= chirpEndIdx; j++)
						{
							int num = Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000012[i].p000008.constBpmVal, 16);
							string text = (num & 1).ToString() + ",";
							text = text + ((num & 2) >> 1).ToString() + ",";
							text = text + ((num & 4) >> 2).ToString() + ",";
							text = text + ((num & 8) >> 3).ToString() + ",";
							text = text + ((num & 16) >> 4).ToString() + ",";
							text += ((num & 32) >> 5).ToString();
							streamWriter.WriteLine(text);
						}
					}
					streamWriter.Close();
				}
				if (jobject.mmWaveDevices[p1].rfConfig.p000015.Count == 0)
				{
					string msg2 = string.Format("Missing Phase Shift Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg2);
				}
				else if (GlobalRef.g_AR12xxDevice)
				{
					this.UpdatePerChirpPhaseShifterGui(jobject, p1, 0);
					string path2 = Path.GetDirectoryName(Application.StartupPath) + "\\Clients\\AR1xController\\ChirpPhaseShifterConfigData.csv";
					if (File.Exists(path2))
					{
						File.Delete(path2);
					}
					StreamWriter streamWriter2 = new StreamWriter(path2);
					string value2 = "Tx0PhShift ,Tx1PhShift ,Tx2PhShift";
					streamWriter2.WriteLine(value2);
					int count2 = GlobalRef.jobject.mmWaveDevices[p1].rfConfig.p000015.Count;
					for (int k = 0; k < count2; k++)
					{
						int chirpStartIdx2 = jobject.mmWaveDevices[p1].rfConfig.p000015[k].rlRfPhaseShiftCfg_t.chirpStartIdx;
						int chirpEndIdx2 = jobject.mmWaveDevices[p1].rfConfig.p000015[k].rlRfPhaseShiftCfg_t.chirpEndIdx;
						for (int l = chirpStartIdx2; l <= chirpEndIdx2; l++)
						{
							string text2 = jobject.mmWaveDevices[p1].rfConfig.p000015[k].rlRfPhaseShiftCfg_t.tx0PhaseShift + ",";
							text2 = text2 + jobject.mmWaveDevices[p1].rfConfig.p000015[k].rlRfPhaseShiftCfg_t.tx1PhaseShift + ",";
							text2 += jobject.mmWaveDevices[p1].rfConfig.p000015[k].rlRfPhaseShiftCfg_t.tx2PhaseShift;
							streamWriter2.WriteLine(text2);
						}
					}
					streamWriter2.Close();
				}
				result = true;
			}
			catch
			{
				string msg3 = string.Format("BPM Config Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg3);
				result = false;
			}
			return result;
		}

		public bool UpdateBpmChirpConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateBpmChirpConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_BpmChirpConfigParams.chirpStartIdx = (ushort)this.m_nudStrtIdx.Value;
				this.m_BpmChirpConfigParams.chirpEndIdx = (ushort)this.m_nudEndIdx.Value;
				this.m_BpmChirpConfigParams.tx0Off = (ushort)this.m_nudTx0Off.Value;
				this.m_BpmChirpConfigParams.tx0On = (ushort)this.m_nudTx0On.Value;
				this.m_BpmChirpConfigParams.tx1Off = (ushort)this.m_nudTx1Off.Value;
				this.m_BpmChirpConfigParams.tx1On = (ushort)this.m_nudTx1On.Value;
				this.m_BpmChirpConfigParams.tx2Off = (ushort)this.m_nudTx2Off.Value;
				this.m_BpmChirpConfigParams.tx2On = (ushort)this.m_nudTx2On.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetBpmChirpConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetBpmChirpConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetBpmChirpConfig()
		{
			this.iSetBpmChirpConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetBpmChirpConfigAsync()
		{
			new del_v_v(this.iSetBpmChirpConfig).BeginInvoke(null, null);
		}

		private void m_btnBpmChirpCfg_Click(object sender, EventArgs p1)
		{
			this.iSetBpmChirpConfigAsync();
		}

		public bool UpdateBpmChirpConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateBpmChirpConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudStrtIdx.Value = this.m_BpmChirpConfigParams.chirpStartIdx;
				this.m_nudEndIdx.Value = this.m_BpmChirpConfigParams.chirpEndIdx;
				this.m_nudTx0Off.Value = this.m_BpmChirpConfigParams.tx0Off;
				this.m_nudTx0On.Value = this.m_BpmChirpConfigParams.tx0On;
				this.m_nudTx1Off.Value = this.m_BpmChirpConfigParams.tx1Off;
				this.m_nudTx1On.Value = this.m_BpmChirpConfigParams.tx1On;
				this.m_nudTx2Off.Value = this.m_BpmChirpConfigParams.tx2Off;
				this.m_nudTx2On.Value = this.m_BpmChirpConfigParams.tx2On;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private void BpmConfigTab_Load(object sender, EventArgs p1)
		{
		}

		public bool SaveBPMConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.SaveBPMConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetAppSetting("bpmStartIndex", this.m_nudStrtIdx.Value.ToString());
				ConfigurationManager.SetAppSetting("bpmEndIndex", this.m_nudEndIdx.Value.ToString());
				ConfigurationManager.SetAppSetting("bpmTx0ChOn", this.m_nudTx0Off.Value.ToString());
				ConfigurationManager.SetAppSetting("bpmTx0ChOff", this.m_nudTx0On.Value.ToString());
				ConfigurationManager.SetAppSetting("bpmTx1ChOn", this.m_nudTx1Off.Value.ToString());
				ConfigurationManager.SetAppSetting("bpmTx1ChOff", this.m_nudTx1On.Value.ToString());
				ConfigurationManager.SetAppSetting("bpmTx2ChOn", this.m_nudTx2Off.Value.ToString());
				ConfigurationManager.SetAppSetting("bpmTx2ChOff", this.m_nudTx2On.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadBPMConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.LoadBPMConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ushort bpmStartIndex = Convert.ToUInt16(ConfigurationManager.GetAppSetting("bpmStartIndex"));
				ushort bpmEndIndex = Convert.ToUInt16(ConfigurationManager.GetAppSetting("bpmEndIndex"));
				ushort p = Convert.ToUInt16(ConfigurationManager.GetAppSetting("bpmTx0ChOn"));
				ushort p2 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("bpmTx0ChOff"));
				ushort p3 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("bpmTx1ChOn"));
				ushort p4 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("bpmTx1ChOff"));
				ushort p5 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("bpmTx2ChOn"));
				ushort p6 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("bpmTx2ChOff"));
				this.m_GuiManager.ScriptOps.UpdateBPMConfigData(bpmStartIndex, bpmEndIndex, p, p2, p3, p4, p5, p6);
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public void enableBPMTx1Off()
		{
			this.EnableControl_Rec(true, this.m_nudTx0Off);
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
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx0Off.Enabled = true;
				return;
			}
			this.m_nudTx0Off.Enabled = false;
		}

		public void disableBPMTx1Off()
		{
			this.disableControl_Rec(true, this.m_nudTx0Off);
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
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx0Off.Enabled = false;
				return;
			}
			this.m_nudTx0Off.Enabled = true;
		}

		public void enableBPMTx1On()
		{
			this.EnableBPMTx1OnControl_Rec(true, this.m_nudTx0On);
		}

		public void EnableBPMTx1OnControl_Rec(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(this.EnableBPMTx1OnControl_Rec);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx0On.Enabled = true;
				return;
			}
			this.m_nudTx0On.Enabled = false;
		}

		public void disableBPMTx1On()
		{
			this.disableBPMTx1OnControl_Rec(true, this.m_nudTx0On);
		}

		public void disableBPMTx1OnControl_Rec(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(this.disableBPMTx1OnControl_Rec);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx0On.Enabled = false;
				return;
			}
			this.m_nudTx0On.Enabled = true;
		}

		public void enableBPMTx2Off()
		{
			this.EnableBPMTx2OffControl_Rec2(true, this.m_nudTx1Off);
		}

		public void EnableBPMTx2OffControl_Rec2(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(this.EnableBPMTx2OffControl_Rec2);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx1Off.Enabled = true;
				return;
			}
			this.m_nudTx1Off.Enabled = false;
		}

		public void disableBPMTx2Off()
		{
			this.disableBPMTx2OffControl_Rec2(true, this.m_nudTx1Off);
		}

		public void disableBPMTx2OffControl_Rec2(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(this.disableBPMTx2OffControl_Rec2);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx1Off.Enabled = false;
				return;
			}
			this.m_nudTx1Off.Enabled = true;
		}

		public void enableBPMTx2On()
		{
			this.EnableBPMTx2OnControl_Rec2(true, this.m_nudTx1On);
		}

		public void EnableBPMTx2OnControl_Rec2(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(this.EnableBPMTx2OnControl_Rec2);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx1On.Enabled = true;
				return;
			}
			this.m_nudTx1On.Enabled = false;
		}

		public void disableBPMTx2On()
		{
			this.disableBPMTx2OnControl_Rec2(true, this.m_nudTx1On);
		}

		public void disableBPMTx2OnControl_Rec2(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(this.disableBPMTx2OnControl_Rec2);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx1On.Enabled = false;
				return;
			}
			this.m_nudTx1On.Enabled = true;
		}

		public void enableBPMTx3Off()
		{
			this.EnableBPMTx3OffControl_Rec3(true, this.m_nudTx2Off);
		}

		public void EnableBPMTx3OffControl_Rec3(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(this.EnableBPMTx3OffControl_Rec3);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx2Off.Enabled = true;
				return;
			}
			this.m_nudTx2Off.Enabled = false;
		}

		public void disableBPMTx3Off()
		{
			this.disableBPMTx3OffControl_Rec3(true, this.m_nudTx2Off);
		}

		public void disableBPMTx3OffControl_Rec3(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(this.disableBPMTx3OffControl_Rec3);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx2Off.Enabled = false;
				return;
			}
			this.m_nudTx2Off.Enabled = true;
		}

		public void enableBPMTx3On()
		{
			this.EnableBPMTx3OnControl_Rec3(true, this.m_nudTx2On);
		}

		public void EnableBPMTx3OnControl_Rec3(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(this.EnableBPMTx3OnControl_Rec3);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx2On.Enabled = true;
				return;
			}
			this.m_nudTx2On.Enabled = false;
		}

		public void disableBPMTx3On()
		{
			this.disableBPMTx3OnControl_Rec3(true, this.m_nudTx2On);
		}

		public void disableBPMTx3OnControl_Rec3(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(this.disableBPMTx3OnControl_Rec3);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is NumericUpDown)
			{
				this.m_nudTx2On.Enabled = false;
				return;
			}
			this.m_nudTx2On.Enabled = true;
		}

		public void DisableBPMTx3ValuesBothTxOnAndTxOffFor16XXARDevice()
		{
			if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
			{
				this.m_nudTx2Off.Enabled = true;
				this.m_nudTx2On.Enabled = true;
				return;
			}
			if (GlobalRef.g_AR16xxDevice)
			{
				this.m_nudTx2Off.Enabled = false;
				this.m_nudTx2On.Enabled = false;
			}
		}

		private int iSetPerChirpPhaseShifterConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetPerChirpPhaseShifterConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetPerChirpPhaseShifterConfig()
		{
			this.iSetPerChirpPhaseShifterConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetPerChirpPhaseShifterConfigAsync()
		{
			new del_v_v(this.iSetPerChirpPhaseShifterConfig).BeginInvoke(null, null);
		}

		private void m_btnPerChirpPhaseShifterCfg_Click(object sender, EventArgs p1)
		{
			this.iSetPerChirpPhaseShifterConfigAsync();
		}

		public bool UpdatePerChirpPhaseShifterConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdatePerChirpPhaseShifterConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_PerChirpPhaseShifterConfigParams.chirpStartIdx = (ushort)this.m_nudChirpStartIndex.Value;
				this.m_PerChirpPhaseShifterConfigParams.chirpEndIdx = (ushort)this.m_nudChirpEndIndex.Value;
				this.m_PerChirpPhaseShifterConfigParams.Tx0PhaseShifter = (char)this.m_nudTx0PhaseShifter.Value;
				this.m_PerChirpPhaseShifterConfigParams.Tx1PhaseShifter = (char)this.m_nudTx1PhaseShifter.Value;
				this.m_PerChirpPhaseShifterConfigParams.Tx2PhaseShifter = (char)this.m_nudTx2PhaseShifter.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdatePerChirpPhaseShifterConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdatePerChirpPhaseShifterConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudChirpStartIndex.Value = this.m_PerChirpPhaseShifterConfigParams.chirpStartIdx;
				this.m_nudChirpEndIndex.Value = this.m_PerChirpPhaseShifterConfigParams.chirpEndIdx;
				this.m_nudTx0PhaseShifter.Value = this.m_PerChirpPhaseShifterConfigParams.Tx0PhaseShifter;
				this.m_nudTx1PhaseShifter.Value = this.m_PerChirpPhaseShifterConfigParams.Tx1PhaseShifter;
				this.m_nudTx2PhaseShifter.Value = this.m_PerChirpPhaseShifterConfigParams.Tx2PhaseShifter;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetAdvanceBPMPatternConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetAdvanceBPMPatternConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetAdvanceBPMPatternConfig()
		{
			this.iSetAdvanceBPMPatternConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void iSetAdvanceBPMPatternConfigAsync()
		{
			new del_v_v(this.iSetAdvanceBPMPatternConfig).BeginInvoke(null, null);
		}

		private void m_btnAdvanceBPMPatternCfg_Click(object sender, EventArgs p1)
		{
			this.iSetAdvanceBPMPatternConfigAsync();
		}

		public bool UpdateAdvanceBPMPatternConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateAdvanceBPMPatternConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_AdvanceBPMPatternConfigParams.BPMPatternIndex = (byte)this.m_nudBPMPatternIndex.Value;
				this.m_AdvanceBPMPatternConfigParams.ResetOption = (ushort)this.m_cboResetOption.SelectedIndex;
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern0, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern0);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern1, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern1);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern2, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern2);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern3, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern3);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern4, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern4);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern5, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern5);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern6, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern6);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern7, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern7);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern8, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern8);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern9, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern9);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern10, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern10);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern11, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern11);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern12, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern12);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern13, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern13);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern14, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern14);
				this.iConvertHexTextToUInt(this.m_txtTx0BPMPattern15, out this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern15);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern0, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern0);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern1, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern1);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern2, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern2);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern3, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern3);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern4, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern4);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern5, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern5);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern6, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern6);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern7, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern7);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern8, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern8);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern9, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern9);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern10, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern10);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern11, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern11);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern12, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern12);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern13, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern13);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern14, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern14);
				this.iConvertHexTextToUInt(this.m_txtTx1BPMPattern15, out this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern15);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern0, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern0);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern1, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern1);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern2, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern2);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern3, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern3);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern4, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern4);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern5, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern5);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern6, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern6);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern7, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern7);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern8, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern8);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern9, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern9);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern10, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern10);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern11, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern11);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern12, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern12);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern13, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern13);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern14, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern14);
				this.iConvertHexTextToUInt(this.m_txtTx2BPMPattern15, out this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern15);
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateAdvanceBPMPatternConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateAdvanceBPMPatternConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudBPMPatternIndex.Value = this.m_AdvanceBPMPatternConfigParams.BPMPatternIndex;
				this.m_cboResetOption.SelectedIndex = (int)this.m_AdvanceBPMPatternConfigParams.ResetOption;
				this.m_txtTx0BPMPattern0.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern0.ToString("x");
				this.m_txtTx0BPMPattern1.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern1.ToString("x");
				this.m_txtTx0BPMPattern2.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern2.ToString("x");
				this.m_txtTx0BPMPattern3.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern3.ToString("x");
				this.m_txtTx0BPMPattern4.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern4.ToString("x");
				this.m_txtTx0BPMPattern5.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern5.ToString("x");
				this.m_txtTx0BPMPattern6.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern6.ToString("x");
				this.m_txtTx0BPMPattern7.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern7.ToString("x");
				this.m_txtTx0BPMPattern8.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern8.ToString("x");
				this.m_txtTx0BPMPattern9.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern9.ToString("x");
				this.m_txtTx0BPMPattern10.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern10.ToString("x");
				this.m_txtTx0BPMPattern11.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern11.ToString("x");
				this.m_txtTx0BPMPattern12.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern12.ToString("x");
				this.m_txtTx0BPMPattern13.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern13.ToString("x");
				this.m_txtTx0BPMPattern14.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern14.ToString("x");
				this.m_txtTx0BPMPattern15.Text = this.m_AdvanceBPMPatternConfigParams.Tx0BPMpattern15.ToString("x");
				this.m_txtTx1BPMPattern0.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern0.ToString("x");
				this.m_txtTx1BPMPattern1.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern1.ToString("x");
				this.m_txtTx1BPMPattern2.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern2.ToString("x");
				this.m_txtTx1BPMPattern3.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern3.ToString("x");
				this.m_txtTx1BPMPattern4.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern4.ToString("x");
				this.m_txtTx1BPMPattern5.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern5.ToString("x");
				this.m_txtTx1BPMPattern6.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern6.ToString("x");
				this.m_txtTx1BPMPattern7.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern7.ToString("x");
				this.m_txtTx1BPMPattern8.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern8.ToString("x");
				this.m_txtTx1BPMPattern9.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern9.ToString("x");
				this.m_txtTx1BPMPattern10.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern10.ToString("x");
				this.m_txtTx1BPMPattern11.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern11.ToString("x");
				this.m_txtTx1BPMPattern12.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern12.ToString("x");
				this.m_txtTx1BPMPattern13.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern13.ToString("x");
				this.m_txtTx1BPMPattern14.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern14.ToString("x");
				this.m_txtTx1BPMPattern15.Text = this.m_AdvanceBPMPatternConfigParams.Tx1BPMpattern15.ToString("x");
				this.m_txtTx2BPMPattern0.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern0.ToString("x");
				this.m_txtTx2BPMPattern1.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern1.ToString("x");
				this.m_txtTx2BPMPattern2.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern2.ToString("x");
				this.m_txtTx2BPMPattern3.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern3.ToString("x");
				this.m_txtTx2BPMPattern4.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern4.ToString("x");
				this.m_txtTx2BPMPattern5.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern5.ToString("x");
				this.m_txtTx2BPMPattern6.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern6.ToString("x");
				this.m_txtTx2BPMPattern7.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern7.ToString("x");
				this.m_txtTx2BPMPattern8.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern8.ToString("x");
				this.m_txtTx2BPMPattern9.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern9.ToString("x");
				this.m_txtTx2BPMPattern10.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern10.ToString("x");
				this.m_txtTx2BPMPattern11.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern11.ToString("x");
				this.m_txtTx2BPMPattern12.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern12.ToString("x");
				this.m_txtTx2BPMPattern13.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern13.ToString("x");
				this.m_txtTx2BPMPattern14.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern14.ToString("x");
				this.m_txtTx2BPMPattern15.Text = this.m_AdvanceBPMPatternConfigParams.Tx2BPMpattern15.ToString("x");
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private bool iConvertHexTextToUInt(TextBox p0, out uint uint_val)
		{
			uint_val = 0U;
			if (string.IsNullOrEmpty(p0.Text))
			{
				return false;
			}
			string text = p0.Text.ToLower();
			if (text.Length > 1 && text.StartsWith("0x"))
			{
				text = text.Remove(0, 2);
			}
			return uint.TryParse(text, NumberStyles.HexNumber, null, out uint_val);
		}

		private void textBox17_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox41_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox2_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox3_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox4_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox7_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox14_TextChanged(object sender, EventArgs p1)
		{
		}

		private void m_txtTx0BPMPattern11_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox20_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox19_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox18_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox24_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox25_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox32_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox31_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox36_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox34_TextChanged(object sender, EventArgs p1)
		{
		}

		private void textBox46_TextChanged(object sender, EventArgs p1)
		{
		}

		private void m_txtTx0BPMPattern0_TextChanged(object sender, EventArgs p1)
		{
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs p1)
		{
		}

		private void m_btnMangPhaseShifter_Click(object sender, EventArgs p1)
		{
			this.m_PerChirpManager = new PerChirpManager();
			this.m_PerChirpManager.Show();
			GlobalRef.PerChirpManager = this.m_PerChirpManager;
		}

		private void m_btnMangBPMChirps_Click(object sender, EventArgs p1)
		{
			this.m_BPMChirpManager = new BPMChirpManager();
			this.m_BPMChirpManager.Show();
			GlobalRef.BPMChirpManager = this.m_BPMChirpManager;
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
			this.f00012e = new GroupBox();
			this.label6 = new Label();
			this.label5 = new Label();
			this.groupBox1 = new GroupBox();
			this.m_nudTx2On = new NumericUpDown();
			this.m_nudTx2Off = new NumericUpDown();
			this.m_nudTx1On = new NumericUpDown();
			this.m_nudTx1Off = new NumericUpDown();
			this.m_nudTx0On = new NumericUpDown();
			this.m_nudTx0Off = new NumericUpDown();
			this.TxOn = new Label();
			this.TxOff = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.Tx0 = new Label();
			this.m_nudEndIdx = new NumericUpDown();
			this.m_nudStrtIdx = new NumericUpDown();
			this.label2 = new Label();
			this.label1 = new Label();
			this.f00012f = new Button();
			this.openFileDialog2 = new OpenFileDialog();
			this.m_grpPerChirpPhaseShifterCfg = new GroupBox();
			this.m_btnMangPhaseShifter = new Button();
			this.label12 = new Label();
			this.m_btnPerChirpPhaseShifterCfg = new Button();
			this.m_nudTx2PhaseShifter = new NumericUpDown();
			this.m_nudTx1PhaseShifter = new NumericUpDown();
			this.m_nudTx0PhaseShifter = new NumericUpDown();
			this.m_nudChirpEndIndex = new NumericUpDown();
			this.m_nudChirpStartIndex = new NumericUpDown();
			this.label11 = new Label();
			this.label10 = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.label7 = new Label();
			this.openFileDialog3 = new OpenFileDialog();
			this.label13 = new Label();
			this.label14 = new Label();
			this.label15 = new Label();
			this.label16 = new Label();
			this.label17 = new Label();
			this.m_btnAdvanceBPMPatternCfg = new Button();
			this.m_nudBPMPatternIndex = new NumericUpDown();
			this.m_cboResetOption = new ComboBox();
			this.m_txtTx0BPMPattern0 = new TextBox();
			this.m_txtTx0BPMPattern1 = new TextBox();
			this.m_txtTx0BPMPattern2 = new TextBox();
			this.m_txtTx0BPMPattern3 = new TextBox();
			this.m_txtTx0BPMPattern4 = new TextBox();
			this.m_txtTx0BPMPattern5 = new TextBox();
			this.m_txtTx0BPMPattern6 = new TextBox();
			this.m_txtTx0BPMPattern7 = new TextBox();
			this.m_txtTx0BPMPattern8 = new TextBox();
			this.m_txtTx0BPMPattern9 = new TextBox();
			this.m_txtTx0BPMPattern10 = new TextBox();
			this.m_txtTx0BPMPattern11 = new TextBox();
			this.m_txtTx0BPMPattern12 = new TextBox();
			this.m_txtTx0BPMPattern13 = new TextBox();
			this.m_txtTx0BPMPattern14 = new TextBox();
			this.m_txtTx0BPMPattern15 = new TextBox();
			this.m_txtTx1BPMPattern0 = new TextBox();
			this.m_txtTx1BPMPattern1 = new TextBox();
			this.m_txtTx1BPMPattern2 = new TextBox();
			this.m_txtTx1BPMPattern3 = new TextBox();
			this.m_txtTx1BPMPattern4 = new TextBox();
			this.m_txtTx1BPMPattern5 = new TextBox();
			this.m_txtTx1BPMPattern6 = new TextBox();
			this.m_txtTx1BPMPattern7 = new TextBox();
			this.m_txtTx1BPMPattern8 = new TextBox();
			this.m_txtTx1BPMPattern9 = new TextBox();
			this.m_txtTx1BPMPattern10 = new TextBox();
			this.m_txtTx1BPMPattern11 = new TextBox();
			this.m_txtTx1BPMPattern12 = new TextBox();
			this.m_txtTx1BPMPattern13 = new TextBox();
			this.m_txtTx1BPMPattern14 = new TextBox();
			this.m_txtTx1BPMPattern15 = new TextBox();
			this.m_txtTx2BPMPattern0 = new TextBox();
			this.m_txtTx2BPMPattern1 = new TextBox();
			this.m_txtTx2BPMPattern2 = new TextBox();
			this.m_txtTx2BPMPattern3 = new TextBox();
			this.m_txtTx2BPMPattern4 = new TextBox();
			this.m_txtTx2BPMPattern5 = new TextBox();
			this.m_txtTx2BPMPattern6 = new TextBox();
			this.m_txtTx2BPMPattern7 = new TextBox();
			this.m_txtTx2BPMPattern12 = new TextBox();
			this.m_txtTx2BPMPattern13 = new TextBox();
			this.m_txtTx2BPMPattern14 = new TextBox();
			this.m_txtTx2BPMPattern15 = new TextBox();
			this.m_txtTx2BPMPattern8 = new TextBox();
			this.m_txtTx2BPMPattern9 = new TextBox();
			this.m_txtTx2BPMPattern10 = new TextBox();
			this.m_txtTx2BPMPattern11 = new TextBox();
			this.m_grpAdvanceBPMPatternCfg = new GroupBox();
			this.m_btnMangBPMChirps = new Button();
			this.f00012e.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.m_nudTx2On).BeginInit();
			((ISupportInitialize)this.m_nudTx2Off).BeginInit();
			((ISupportInitialize)this.m_nudTx1On).BeginInit();
			((ISupportInitialize)this.m_nudTx1Off).BeginInit();
			((ISupportInitialize)this.m_nudTx0On).BeginInit();
			((ISupportInitialize)this.m_nudTx0Off).BeginInit();
			((ISupportInitialize)this.m_nudEndIdx).BeginInit();
			((ISupportInitialize)this.m_nudStrtIdx).BeginInit();
			this.m_grpPerChirpPhaseShifterCfg.SuspendLayout();
			((ISupportInitialize)this.m_nudTx2PhaseShifter).BeginInit();
			((ISupportInitialize)this.m_nudTx1PhaseShifter).BeginInit();
			((ISupportInitialize)this.m_nudTx0PhaseShifter).BeginInit();
			((ISupportInitialize)this.m_nudChirpEndIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirpStartIndex).BeginInit();
			((ISupportInitialize)this.m_nudBPMPatternIndex).BeginInit();
			this.m_grpAdvanceBPMPatternCfg.SuspendLayout();
			base.SuspendLayout();
			this.f00012e.Controls.Add(this.m_btnMangBPMChirps);
			this.f00012e.Controls.Add(this.label6);
			this.f00012e.Controls.Add(this.label5);
			this.f00012e.Controls.Add(this.groupBox1);
			this.f00012e.Controls.Add(this.m_nudEndIdx);
			this.f00012e.Controls.Add(this.m_nudStrtIdx);
			this.f00012e.Controls.Add(this.label2);
			this.f00012e.Controls.Add(this.label1);
			this.f00012e.Controls.Add(this.f00012f);
			this.f00012e.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.f00012e.Location = new Point(11, 4);
			this.f00012e.Margin = new Padding(4);
			this.f00012e.Name = "m_grpBpmChirpCfg";
			this.f00012e.Padding = new Padding(4);
			this.f00012e.Size = new Size(462, 372);
			this.f00012e.TabIndex = 0;
			this.f00012e.TabStop = false;
			this.f00012e.Text = "BPM Chirp Config";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(360, 178);
			this.label6.Margin = new Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new Size(97, 17);
			this.label6.TabIndex = 44;
			this.label6.Text = "1: 180 degree";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(361, 143);
			this.label5.Margin = new Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(85, 17);
			this.label5.TabIndex = 43;
			this.label5.Text = "0: 0 degree ";
			this.groupBox1.Controls.Add(this.m_nudTx2On);
			this.groupBox1.Controls.Add(this.m_nudTx2Off);
			this.groupBox1.Controls.Add(this.m_nudTx1On);
			this.groupBox1.Controls.Add(this.m_nudTx1Off);
			this.groupBox1.Controls.Add(this.m_nudTx0On);
			this.groupBox1.Controls.Add(this.m_nudTx0Off);
			this.groupBox1.Controls.Add(this.TxOn);
			this.groupBox1.Controls.Add(this.TxOff);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.Tx0);
			this.groupBox1.Location = new Point(52, 127);
			this.groupBox1.Margin = new Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new Padding(4);
			this.groupBox1.Size = new Size(277, 178);
			this.groupBox1.TabIndex = 42;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tx BPM Config";
			this.m_nudTx2On.Location = new Point(201, 134);
			this.m_nudTx2On.Margin = new Padding(4);
			NumericUpDown nudTx2On = this.m_nudTx2On;
			int[] array = new int[4];
			array[0] = 1;
			nudTx2On.Maximum = new decimal(array);
			this.m_nudTx2On.Name = "m_nudTx2On";
			this.m_nudTx2On.Size = new Size(67, 25);
			this.m_nudTx2On.TabIndex = 8;
			this.m_nudTx2Off.Location = new Point(108, 134);
			this.m_nudTx2Off.Margin = new Padding(4);
			NumericUpDown nudTx2Off = this.m_nudTx2Off;
			int[] array2 = new int[4];
			array2[0] = 1;
			nudTx2Off.Maximum = new decimal(array2);
			this.m_nudTx2Off.Name = "m_nudTx2Off";
			this.m_nudTx2Off.Size = new Size(67, 25);
			this.m_nudTx2Off.TabIndex = 7;
			this.m_nudTx1On.Location = new Point(201, 95);
			this.m_nudTx1On.Margin = new Padding(4);
			NumericUpDown nudTx1On = this.m_nudTx1On;
			int[] array3 = new int[4];
			array3[0] = 1;
			nudTx1On.Maximum = new decimal(array3);
			this.m_nudTx1On.Name = "m_nudTx1On";
			this.m_nudTx1On.Size = new Size(67, 25);
			this.m_nudTx1On.TabIndex = 6;
			this.m_nudTx1Off.Location = new Point(108, 95);
			this.m_nudTx1Off.Margin = new Padding(4);
			NumericUpDown nudTx1Off = this.m_nudTx1Off;
			int[] array4 = new int[4];
			array4[0] = 1;
			nudTx1Off.Maximum = new decimal(array4);
			this.m_nudTx1Off.Name = "m_nudTx1Off";
			this.m_nudTx1Off.Size = new Size(67, 25);
			this.m_nudTx1Off.TabIndex = 5;
			this.m_nudTx0On.Location = new Point(201, 53);
			this.m_nudTx0On.Margin = new Padding(4);
			NumericUpDown nudTx0On = this.m_nudTx0On;
			int[] array5 = new int[4];
			array5[0] = 1;
			nudTx0On.Maximum = new decimal(array5);
			this.m_nudTx0On.Name = "m_nudTx0On";
			this.m_nudTx0On.Size = new Size(67, 25);
			this.m_nudTx0On.TabIndex = 4;
			this.m_nudTx0Off.Location = new Point(108, 55);
			this.m_nudTx0Off.Margin = new Padding(4);
			NumericUpDown nudTx0Off = this.m_nudTx0Off;
			int[] array6 = new int[4];
			array6[0] = 1;
			nudTx0Off.Maximum = new decimal(array6);
			this.m_nudTx0Off.Name = "m_nudTx0Off";
			this.m_nudTx0Off.Size = new Size(67, 25);
			this.m_nudTx0Off.TabIndex = 3;
			this.TxOn.AutoSize = true;
			this.TxOn.Location = new Point(208, 26);
			this.TxOn.Margin = new Padding(4, 0, 4, 0);
			this.TxOn.Name = "TxOn";
			this.TxOn.Size = new Size(50, 17);
			this.TxOn.TabIndex = 10;
			this.TxOn.Text = "TX On";
			this.TxOff.AutoSize = true;
			this.TxOff.Location = new Point(115, 26);
			this.TxOff.Margin = new Padding(4, 0, 4, 0);
			this.TxOff.Name = "TxOff";
			this.TxOff.Size = new Size(50, 17);
			this.TxOff.TabIndex = 9;
			this.TxOff.Text = "TX Off";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(4, 138);
			this.label4.Margin = new Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(92, 17);
			this.label4.TabIndex = 11;
			this.label4.Text = "TX2 BPM Val";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(4, 101);
			this.label3.Margin = new Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(92, 17);
			this.label3.TabIndex = 8;
			this.label3.Text = "TX1 BPM Val";
			this.Tx0.AutoSize = true;
			this.Tx0.Location = new Point(4, 60);
			this.Tx0.Margin = new Padding(4, 0, 4, 0);
			this.Tx0.Name = "Tx0";
			this.Tx0.Size = new Size(92, 17);
			this.Tx0.TabIndex = 5;
			this.Tx0.Text = "TX0 BPM Val";
			this.m_nudEndIdx.Location = new Point(192, 82);
			this.m_nudEndIdx.Margin = new Padding(4);
			NumericUpDown nudEndIdx = this.m_nudEndIdx;
			int[] array7 = new int[4];
			array7[0] = 511;
			nudEndIdx.Maximum = new decimal(array7);
			this.m_nudEndIdx.Name = "m_nudEndIdx";
			this.m_nudEndIdx.Size = new Size(129, 25);
			this.m_nudEndIdx.TabIndex = 2;
			this.m_nudStrtIdx.Location = new Point(192, 43);
			this.m_nudStrtIdx.Margin = new Padding(4);
			NumericUpDown nudStrtIdx = this.m_nudStrtIdx;
			int[] array8 = new int[4];
			array8[0] = 511;
			nudStrtIdx.Maximum = new decimal(array8);
			this.m_nudStrtIdx.Name = "m_nudStrtIdx";
			this.m_nudStrtIdx.Size = new Size(129, 25);
			this.m_nudStrtIdx.TabIndex = 1;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(48, 86);
			this.label2.Margin = new Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(72, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "End Index";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(48, 43);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(77, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Start Index";
			this.f00012f.Location = new Point(136, 316);
			this.f00012f.Margin = new Padding(4);
			this.f00012f.Name = "m_btnBpmChirpCfg";
			this.f00012f.Size = new Size(111, 39);
			this.f00012f.TabIndex = 9;
			this.f00012f.Text = "Set";
			this.f00012f.UseVisualStyleBackColor = true;
			this.f00012f.Click += this.m_btnBpmChirpCfg_Click;
			this.openFileDialog2.FileName = "openFileDialog2";
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.m_btnMangPhaseShifter);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.label12);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.m_btnPerChirpPhaseShifterCfg);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.m_nudTx2PhaseShifter);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.m_nudTx1PhaseShifter);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.m_nudTx0PhaseShifter);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.m_nudChirpEndIndex);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.m_nudChirpStartIndex);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.label11);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.label10);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.label9);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.label8);
			this.m_grpPerChirpPhaseShifterCfg.Controls.Add(this.label7);
			this.m_grpPerChirpPhaseShifterCfg.Location = new Point(486, 5);
			this.m_grpPerChirpPhaseShifterCfg.Margin = new Padding(4);
			this.m_grpPerChirpPhaseShifterCfg.Name = "m_grpPerChirpPhaseShifterCfg";
			this.m_grpPerChirpPhaseShifterCfg.Padding = new Padding(4);
			this.m_grpPerChirpPhaseShifterCfg.Size = new Size(505, 281);
			this.m_grpPerChirpPhaseShifterCfg.TabIndex = 17;
			this.m_grpPerChirpPhaseShifterCfg.TabStop = false;
			this.m_grpPerChirpPhaseShifterCfg.Text = "Chirp based Phase Shifter";
			this.m_btnMangPhaseShifter.Location = new Point(332, 227);
			this.m_btnMangPhaseShifter.Margin = new Padding(4);
			this.m_btnMangPhaseShifter.Name = "m_btnMangPhaseShifter";
			this.m_btnMangPhaseShifter.Size = new Size(158, 39);
			this.m_btnMangPhaseShifter.TabIndex = 21;
			this.m_btnMangPhaseShifter.Text = "Manage Phase Shifter";
			this.m_btnMangPhaseShifter.UseVisualStyleBackColor = true;
			this.m_btnMangPhaseShifter.Click += this.m_btnMangPhaseShifter_Click;
			this.label12.AutoSize = true;
			this.label12.Location = new Point(356, 103);
			this.label12.Margin = new Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new Size(143, 17);
			this.label12.TabIndex = 11;
			this.label12.Text = "1LSB = 5.625 degree";
			this.m_btnPerChirpPhaseShifterCfg.Location = new Point(210, 227);
			this.m_btnPerChirpPhaseShifterCfg.Margin = new Padding(4);
			this.m_btnPerChirpPhaseShifterCfg.Name = "m_btnPerChirpPhaseShifterCfg";
			this.m_btnPerChirpPhaseShifterCfg.Size = new Size(111, 39);
			this.m_btnPerChirpPhaseShifterCfg.TabIndex = 10;
			this.m_btnPerChirpPhaseShifterCfg.Text = "Set";
			this.m_btnPerChirpPhaseShifterCfg.UseVisualStyleBackColor = true;
			this.m_btnPerChirpPhaseShifterCfg.Click += this.m_btnPerChirpPhaseShifterCfg_Click;
			this.m_nudTx2PhaseShifter.Location = new Point(205, 177);
			this.m_nudTx2PhaseShifter.Margin = new Padding(4);
			NumericUpDown nudTx2PhaseShifter = this.m_nudTx2PhaseShifter;
			int[] array9 = new int[4];
			array9[0] = 63;
			nudTx2PhaseShifter.Maximum = new decimal(array9);
			this.m_nudTx2PhaseShifter.Name = "m_nudTx2PhaseShifter";
			this.m_nudTx2PhaseShifter.Size = new Size(129, 22);
			this.m_nudTx2PhaseShifter.TabIndex = 9;
			this.m_nudTx1PhaseShifter.Location = new Point(205, 140);
			this.m_nudTx1PhaseShifter.Margin = new Padding(4);
			NumericUpDown nudTx1PhaseShifter = this.m_nudTx1PhaseShifter;
			int[] array10 = new int[4];
			array10[0] = 63;
			nudTx1PhaseShifter.Maximum = new decimal(array10);
			this.m_nudTx1PhaseShifter.Name = "m_nudTx1PhaseShifter";
			this.m_nudTx1PhaseShifter.Size = new Size(129, 22);
			this.m_nudTx1PhaseShifter.TabIndex = 8;
			this.m_nudTx0PhaseShifter.Location = new Point(205, 103);
			this.m_nudTx0PhaseShifter.Margin = new Padding(4);
			NumericUpDown nudTx0PhaseShifter = this.m_nudTx0PhaseShifter;
			int[] array11 = new int[4];
			array11[0] = 63;
			nudTx0PhaseShifter.Maximum = new decimal(array11);
			this.m_nudTx0PhaseShifter.Name = "m_nudTx0PhaseShifter";
			this.m_nudTx0PhaseShifter.Size = new Size(129, 22);
			this.m_nudTx0PhaseShifter.TabIndex = 7;
			this.m_nudChirpEndIndex.Location = new Point(205, 66);
			this.m_nudChirpEndIndex.Margin = new Padding(4);
			NumericUpDown nudChirpEndIndex = this.m_nudChirpEndIndex;
			int[] array12 = new int[4];
			array12[0] = 511;
			nudChirpEndIndex.Maximum = new decimal(array12);
			this.m_nudChirpEndIndex.Name = "m_nudChirpEndIndex";
			this.m_nudChirpEndIndex.Size = new Size(129, 22);
			this.m_nudChirpEndIndex.TabIndex = 6;
			this.m_nudChirpStartIndex.Location = new Point(205, 30);
			this.m_nudChirpStartIndex.Margin = new Padding(4);
			NumericUpDown nudChirpStartIndex = this.m_nudChirpStartIndex;
			int[] array13 = new int[4];
			array13[0] = 511;
			nudChirpStartIndex.Maximum = new decimal(array13);
			this.m_nudChirpStartIndex.Name = "m_nudChirpStartIndex";
			this.m_nudChirpStartIndex.Size = new Size(129, 22);
			this.m_nudChirpStartIndex.TabIndex = 5;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(16, 183);
			this.label11.Margin = new Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new Size(123, 17);
			this.label11.TabIndex = 4;
			this.label11.Text = "TX2 Phase Shifter";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(16, 148);
			this.label10.Margin = new Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new Size(123, 17);
			this.label10.TabIndex = 3;
			this.label10.Text = "TX1 Phase Shifter";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(16, 110);
			this.label9.Margin = new Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new Size(123, 17);
			this.label9.TabIndex = 2;
			this.label9.Text = "TX0 Phase Shifter";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(16, 73);
			this.label8.Margin = new Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(107, 17);
			this.label8.TabIndex = 1;
			this.label8.Text = "Chirp End Index";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(16, 38);
			this.label7.Margin = new Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(112, 17);
			this.label7.TabIndex = 0;
			this.label7.Text = "Chirp Start Index";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(8, 21);
			this.label13.Margin = new Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new Size(91, 17);
			this.label13.TabIndex = 0;
			this.label13.Text = "Pattern Index";
			this.label14.AutoSize = true;
			this.label14.Location = new Point(272, 22);
			this.label14.Margin = new Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new Size(91, 17);
			this.label14.TabIndex = 1;
			this.label14.Text = "Reset Option";
			this.label15.AutoSize = true;
			this.label15.Location = new Point(33, 58);
			this.label15.Margin = new Padding(4, 0, 4, 0);
			this.label15.Name = "label15";
			this.label15.Size = new Size(146, 17);
			this.label15.TabIndex = 2;
			this.label15.Text = " Tx0 BPM Pattern (0x)";
			this.label16.AutoSize = true;
			this.label16.Location = new Point(211, 58);
			this.label16.Margin = new Padding(4, 0, 4, 0);
			this.label16.Name = "label16";
			this.label16.Size = new Size(142, 17);
			this.label16.TabIndex = 3;
			this.label16.Text = "Tx1 BPM Pattern (0x)";
			this.label17.AutoSize = true;
			this.label17.Location = new Point(384, 60);
			this.label17.Margin = new Padding(4, 0, 4, 0);
			this.label17.Name = "label17";
			this.label17.Size = new Size(142, 17);
			this.label17.TabIndex = 4;
			this.label17.Text = "Tx2 BPM Pattern (0x)";
			this.m_btnAdvanceBPMPatternCfg.Location = new Point(417, 612);
			this.m_btnAdvanceBPMPatternCfg.Margin = new Padding(4);
			this.m_btnAdvanceBPMPatternCfg.Name = "m_btnAdvanceBPMPatternCfg";
			this.m_btnAdvanceBPMPatternCfg.Size = new Size(100, 30);
			this.m_btnAdvanceBPMPatternCfg.TabIndex = 5;
			this.m_btnAdvanceBPMPatternCfg.Text = "Set";
			this.m_btnAdvanceBPMPatternCfg.UseVisualStyleBackColor = true;
			this.m_btnAdvanceBPMPatternCfg.Click += this.m_btnAdvanceBPMPatternCfg_Click;
			this.m_nudBPMPatternIndex.Location = new Point(119, 20);
			this.m_nudBPMPatternIndex.Margin = new Padding(4);
			NumericUpDown nudBPMPatternIndex = this.m_nudBPMPatternIndex;
			int[] array14 = new int[4];
			array14[0] = 3;
			nudBPMPatternIndex.Maximum = new decimal(array14);
			this.m_nudBPMPatternIndex.Name = "m_nudBPMPatternIndex";
			this.m_nudBPMPatternIndex.Size = new Size(127, 22);
			this.m_nudBPMPatternIndex.TabIndex = 6;
			this.m_cboResetOption.DropDownStyle = ComboBoxStyle.DropDownList;
			this.m_cboResetOption.FormattingEnabled = true;
			this.m_cboResetOption.Items.AddRange(new object[]
			{
				"FrameEnd",
				"SubFrameEnd",
				"BurstEnd"
			});
			this.m_cboResetOption.Location = new Point(372, 22);
			this.m_cboResetOption.Margin = new Padding(4);
			this.m_cboResetOption.Name = "m_cboResetOption";
			this.m_cboResetOption.Size = new Size(144, 24);
			this.m_cboResetOption.TabIndex = 7;
			this.m_cboResetOption.SelectedIndexChanged += this.comboBox1_SelectedIndexChanged;
			this.m_txtTx0BPMPattern0.Location = new Point(43, 86);
			this.m_txtTx0BPMPattern0.Margin = new Padding(4);
			this.m_txtTx0BPMPattern0.Name = "m_txtTx0BPMPattern0";
			this.m_txtTx0BPMPattern0.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern0.TabIndex = 8;
			this.m_txtTx0BPMPattern0.TextChanged += this.m_txtTx0BPMPattern0_TextChanged;
			this.m_txtTx0BPMPattern1.Location = new Point(43, 117);
			this.m_txtTx0BPMPattern1.Margin = new Padding(4);
			this.m_txtTx0BPMPattern1.Name = "m_txtTx0BPMPattern1";
			this.m_txtTx0BPMPattern1.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern1.TabIndex = 9;
			this.m_txtTx0BPMPattern1.TextChanged += this.textBox2_TextChanged;
			this.m_txtTx0BPMPattern2.Location = new Point(43, 155);
			this.m_txtTx0BPMPattern2.Margin = new Padding(4);
			this.m_txtTx0BPMPattern2.Name = "m_txtTx0BPMPattern2";
			this.m_txtTx0BPMPattern2.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern2.TabIndex = 10;
			this.m_txtTx0BPMPattern2.TextChanged += this.textBox3_TextChanged;
			this.m_txtTx0BPMPattern3.Location = new Point(43, 186);
			this.m_txtTx0BPMPattern3.Margin = new Padding(4);
			this.m_txtTx0BPMPattern3.Name = "m_txtTx0BPMPattern3";
			this.m_txtTx0BPMPattern3.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern3.TabIndex = 11;
			this.m_txtTx0BPMPattern3.TextChanged += this.textBox4_TextChanged;
			this.m_txtTx0BPMPattern4.Location = new Point(43, 215);
			this.m_txtTx0BPMPattern4.Margin = new Padding(4);
			this.m_txtTx0BPMPattern4.Name = "m_txtTx0BPMPattern4";
			this.m_txtTx0BPMPattern4.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern4.TabIndex = 12;
			this.m_txtTx0BPMPattern5.Location = new Point(43, 249);
			this.m_txtTx0BPMPattern5.Margin = new Padding(4);
			this.m_txtTx0BPMPattern5.Name = "m_txtTx0BPMPattern5";
			this.m_txtTx0BPMPattern5.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern5.TabIndex = 13;
			this.m_txtTx0BPMPattern5.TextChanged += this.textBox7_TextChanged;
			this.m_txtTx0BPMPattern6.Location = new Point(43, 284);
			this.m_txtTx0BPMPattern6.Margin = new Padding(4);
			this.m_txtTx0BPMPattern6.Name = "m_txtTx0BPMPattern6";
			this.m_txtTx0BPMPattern6.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern6.TabIndex = 14;
			this.m_txtTx0BPMPattern7.Location = new Point(43, 315);
			this.m_txtTx0BPMPattern7.Margin = new Padding(4);
			this.m_txtTx0BPMPattern7.Name = "m_txtTx0BPMPattern7";
			this.m_txtTx0BPMPattern7.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern7.TabIndex = 15;
			this.m_txtTx0BPMPattern8.Location = new Point(43, 343);
			this.m_txtTx0BPMPattern8.Margin = new Padding(4);
			this.m_txtTx0BPMPattern8.Name = "m_txtTx0BPMPattern8";
			this.m_txtTx0BPMPattern8.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern8.TabIndex = 16;
			this.m_txtTx0BPMPattern9.Location = new Point(43, 374);
			this.m_txtTx0BPMPattern9.Margin = new Padding(4);
			this.m_txtTx0BPMPattern9.Name = "m_txtTx0BPMPattern9";
			this.m_txtTx0BPMPattern9.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern9.TabIndex = 17;
			this.m_txtTx0BPMPattern10.Location = new Point(43, 407);
			this.m_txtTx0BPMPattern10.Margin = new Padding(4);
			this.m_txtTx0BPMPattern10.Name = "m_txtTx0BPMPattern10";
			this.m_txtTx0BPMPattern10.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern10.TabIndex = 18;
			this.m_txtTx0BPMPattern11.Location = new Point(43, 441);
			this.m_txtTx0BPMPattern11.Margin = new Padding(4);
			this.m_txtTx0BPMPattern11.Name = "m_txtTx0BPMPattern11";
			this.m_txtTx0BPMPattern11.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern11.TabIndex = 19;
			this.m_txtTx0BPMPattern11.TextChanged += this.m_txtTx0BPMPattern11_TextChanged;
			this.m_txtTx0BPMPattern12.Location = new Point(43, 469);
			this.m_txtTx0BPMPattern12.Margin = new Padding(4);
			this.m_txtTx0BPMPattern12.Name = "m_txtTx0BPMPattern12";
			this.m_txtTx0BPMPattern12.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern12.TabIndex = 20;
			this.m_txtTx0BPMPattern13.Location = new Point(43, 502);
			this.m_txtTx0BPMPattern13.Margin = new Padding(4);
			this.m_txtTx0BPMPattern13.Name = "m_txtTx0BPMPattern13";
			this.m_txtTx0BPMPattern13.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern13.TabIndex = 21;
			this.m_txtTx0BPMPattern14.Location = new Point(43, 538);
			this.m_txtTx0BPMPattern14.Margin = new Padding(4);
			this.m_txtTx0BPMPattern14.Name = "m_txtTx0BPMPattern14";
			this.m_txtTx0BPMPattern14.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern14.TabIndex = 22;
			this.m_txtTx0BPMPattern14.TextChanged += this.textBox14_TextChanged;
			this.m_txtTx0BPMPattern15.Location = new Point(43, 569);
			this.m_txtTx0BPMPattern15.Margin = new Padding(4);
			this.m_txtTx0BPMPattern15.Name = "m_txtTx0BPMPattern15";
			this.m_txtTx0BPMPattern15.Size = new Size(132, 22);
			this.m_txtTx0BPMPattern15.TabIndex = 23;
			this.m_txtTx1BPMPattern0.Location = new Point(217, 86);
			this.m_txtTx1BPMPattern0.Margin = new Padding(4);
			this.m_txtTx1BPMPattern0.Name = "m_txtTx1BPMPattern0";
			this.m_txtTx1BPMPattern0.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern0.TabIndex = 24;
			this.m_txtTx1BPMPattern0.TextChanged += this.textBox20_TextChanged;
			this.m_txtTx1BPMPattern1.Location = new Point(217, 119);
			this.m_txtTx1BPMPattern1.Margin = new Padding(4);
			this.m_txtTx1BPMPattern1.Name = "m_txtTx1BPMPattern1";
			this.m_txtTx1BPMPattern1.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern1.TabIndex = 25;
			this.m_txtTx1BPMPattern1.TextChanged += this.textBox19_TextChanged;
			this.m_txtTx1BPMPattern2.Location = new Point(217, 155);
			this.m_txtTx1BPMPattern2.Margin = new Padding(4);
			this.m_txtTx1BPMPattern2.Name = "m_txtTx1BPMPattern2";
			this.m_txtTx1BPMPattern2.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern2.TabIndex = 26;
			this.m_txtTx1BPMPattern2.TextChanged += this.textBox18_TextChanged;
			this.m_txtTx1BPMPattern3.Location = new Point(217, 186);
			this.m_txtTx1BPMPattern3.Margin = new Padding(4);
			this.m_txtTx1BPMPattern3.Name = "m_txtTx1BPMPattern3";
			this.m_txtTx1BPMPattern3.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern3.TabIndex = 27;
			this.m_txtTx1BPMPattern3.TextChanged += this.textBox17_TextChanged;
			this.m_txtTx1BPMPattern4.Location = new Point(220, 217);
			this.m_txtTx1BPMPattern4.Margin = new Padding(4);
			this.m_txtTx1BPMPattern4.Name = "m_txtTx1BPMPattern4";
			this.m_txtTx1BPMPattern4.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern4.TabIndex = 28;
			this.m_txtTx1BPMPattern4.TextChanged += this.textBox24_TextChanged;
			this.m_txtTx1BPMPattern5.Location = new Point(217, 250);
			this.m_txtTx1BPMPattern5.Margin = new Padding(4);
			this.m_txtTx1BPMPattern5.Name = "m_txtTx1BPMPattern5";
			this.m_txtTx1BPMPattern5.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern5.TabIndex = 29;
			this.m_txtTx1BPMPattern6.Location = new Point(217, 282);
			this.m_txtTx1BPMPattern6.Margin = new Padding(4);
			this.m_txtTx1BPMPattern6.Name = "m_txtTx1BPMPattern6";
			this.m_txtTx1BPMPattern6.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern6.TabIndex = 30;
			this.m_txtTx1BPMPattern7.Location = new Point(217, 313);
			this.m_txtTx1BPMPattern7.Margin = new Padding(4);
			this.m_txtTx1BPMPattern7.Name = "m_txtTx1BPMPattern7";
			this.m_txtTx1BPMPattern7.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern7.TabIndex = 31;
			this.m_txtTx1BPMPattern8.Location = new Point(217, 343);
			this.m_txtTx1BPMPattern8.Margin = new Padding(4);
			this.m_txtTx1BPMPattern8.Name = "m_txtTx1BPMPattern8";
			this.m_txtTx1BPMPattern8.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern8.TabIndex = 32;
			this.m_txtTx1BPMPattern9.Location = new Point(217, 375);
			this.m_txtTx1BPMPattern9.Margin = new Padding(4);
			this.m_txtTx1BPMPattern9.Name = "m_txtTx1BPMPattern9";
			this.m_txtTx1BPMPattern9.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern9.TabIndex = 33;
			this.m_txtTx1BPMPattern10.Location = new Point(217, 407);
			this.m_txtTx1BPMPattern10.Margin = new Padding(4);
			this.m_txtTx1BPMPattern10.Name = "m_txtTx1BPMPattern10";
			this.m_txtTx1BPMPattern10.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern10.TabIndex = 34;
			this.m_txtTx1BPMPattern11.Location = new Point(217, 438);
			this.m_txtTx1BPMPattern11.Margin = new Padding(4);
			this.m_txtTx1BPMPattern11.Name = "m_txtTx1BPMPattern11";
			this.m_txtTx1BPMPattern11.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern11.TabIndex = 35;
			this.m_txtTx1BPMPattern11.TextChanged += this.textBox25_TextChanged;
			this.m_txtTx1BPMPattern12.Location = new Point(217, 470);
			this.m_txtTx1BPMPattern12.Margin = new Padding(4);
			this.m_txtTx1BPMPattern12.Name = "m_txtTx1BPMPattern12";
			this.m_txtTx1BPMPattern12.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern12.TabIndex = 36;
			this.m_txtTx1BPMPattern12.TextChanged += this.textBox32_TextChanged;
			this.m_txtTx1BPMPattern13.Location = new Point(217, 502);
			this.m_txtTx1BPMPattern13.Margin = new Padding(4);
			this.m_txtTx1BPMPattern13.Name = "m_txtTx1BPMPattern13";
			this.m_txtTx1BPMPattern13.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern13.TabIndex = 37;
			this.m_txtTx1BPMPattern13.TextChanged += this.textBox31_TextChanged;
			this.m_txtTx1BPMPattern14.Location = new Point(217, 538);
			this.m_txtTx1BPMPattern14.Margin = new Padding(4);
			this.m_txtTx1BPMPattern14.Name = "m_txtTx1BPMPattern14";
			this.m_txtTx1BPMPattern14.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern14.TabIndex = 38;
			this.m_txtTx1BPMPattern15.Location = new Point(217, 569);
			this.m_txtTx1BPMPattern15.Margin = new Padding(4);
			this.m_txtTx1BPMPattern15.Name = "m_txtTx1BPMPattern15";
			this.m_txtTx1BPMPattern15.Size = new Size(132, 22);
			this.m_txtTx1BPMPattern15.TabIndex = 39;
			this.m_txtTx2BPMPattern0.Location = new Point(384, 86);
			this.m_txtTx2BPMPattern0.Margin = new Padding(4);
			this.m_txtTx2BPMPattern0.Name = "m_txtTx2BPMPattern0";
			this.m_txtTx2BPMPattern0.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern0.TabIndex = 40;
			this.m_txtTx2BPMPattern0.TextChanged += this.textBox36_TextChanged;
			this.m_txtTx2BPMPattern1.Location = new Point(384, 119);
			this.m_txtTx2BPMPattern1.Margin = new Padding(4);
			this.m_txtTx2BPMPattern1.Name = "m_txtTx2BPMPattern1";
			this.m_txtTx2BPMPattern1.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern1.TabIndex = 41;
			this.m_txtTx2BPMPattern2.Location = new Point(384, 155);
			this.m_txtTx2BPMPattern2.Margin = new Padding(4);
			this.m_txtTx2BPMPattern2.Name = "m_txtTx2BPMPattern2";
			this.m_txtTx2BPMPattern2.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern2.TabIndex = 42;
			this.m_txtTx2BPMPattern2.TextChanged += this.textBox34_TextChanged;
			this.m_txtTx2BPMPattern3.Location = new Point(384, 186);
			this.m_txtTx2BPMPattern3.Margin = new Padding(4);
			this.m_txtTx2BPMPattern3.Name = "m_txtTx2BPMPattern3";
			this.m_txtTx2BPMPattern3.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern3.TabIndex = 43;
			this.m_txtTx2BPMPattern4.Location = new Point(384, 215);
			this.m_txtTx2BPMPattern4.Margin = new Padding(4);
			this.m_txtTx2BPMPattern4.Name = "m_txtTx2BPMPattern4";
			this.m_txtTx2BPMPattern4.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern4.TabIndex = 44;
			this.m_txtTx2BPMPattern5.Location = new Point(384, 249);
			this.m_txtTx2BPMPattern5.Margin = new Padding(4);
			this.m_txtTx2BPMPattern5.Name = "m_txtTx2BPMPattern5";
			this.m_txtTx2BPMPattern5.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern5.TabIndex = 45;
			this.m_txtTx2BPMPattern6.Location = new Point(384, 284);
			this.m_txtTx2BPMPattern6.Margin = new Padding(4);
			this.m_txtTx2BPMPattern6.Name = "m_txtTx2BPMPattern6";
			this.m_txtTx2BPMPattern6.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern6.TabIndex = 46;
			this.m_txtTx2BPMPattern7.Location = new Point(384, 315);
			this.m_txtTx2BPMPattern7.Margin = new Padding(4);
			this.m_txtTx2BPMPattern7.Name = "m_txtTx2BPMPattern7";
			this.m_txtTx2BPMPattern7.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern7.TabIndex = 47;
			this.m_txtTx2BPMPattern12.Location = new Point(384, 474);
			this.m_txtTx2BPMPattern12.Margin = new Padding(4);
			this.m_txtTx2BPMPattern12.Name = "m_txtTx2BPMPattern12";
			this.m_txtTx2BPMPattern12.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern12.TabIndex = 48;
			this.m_txtTx2BPMPattern13.Location = new Point(384, 508);
			this.m_txtTx2BPMPattern13.Margin = new Padding(4);
			this.m_txtTx2BPMPattern13.Name = "m_txtTx2BPMPattern13";
			this.m_txtTx2BPMPattern13.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern13.TabIndex = 49;
			this.m_txtTx2BPMPattern14.Location = new Point(384, 539);
			this.m_txtTx2BPMPattern14.Margin = new Padding(4);
			this.m_txtTx2BPMPattern14.Name = "m_txtTx2BPMPattern14";
			this.m_txtTx2BPMPattern14.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern14.TabIndex = 50;
			this.m_txtTx2BPMPattern15.Location = new Point(384, 571);
			this.m_txtTx2BPMPattern15.Margin = new Padding(4);
			this.m_txtTx2BPMPattern15.Name = "m_txtTx2BPMPattern15";
			this.m_txtTx2BPMPattern15.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern15.TabIndex = 51;
			this.m_txtTx2BPMPattern15.TextChanged += this.textBox41_TextChanged;
			this.m_txtTx2BPMPattern8.Location = new Point(384, 345);
			this.m_txtTx2BPMPattern8.Margin = new Padding(4);
			this.m_txtTx2BPMPattern8.Name = "m_txtTx2BPMPattern8";
			this.m_txtTx2BPMPattern8.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern8.TabIndex = 52;
			this.m_txtTx2BPMPattern9.Location = new Point(384, 374);
			this.m_txtTx2BPMPattern9.Margin = new Padding(4);
			this.m_txtTx2BPMPattern9.Name = "m_txtTx2BPMPattern9";
			this.m_txtTx2BPMPattern9.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern9.TabIndex = 53;
			this.m_txtTx2BPMPattern10.Location = new Point(384, 410);
			this.m_txtTx2BPMPattern10.Margin = new Padding(4);
			this.m_txtTx2BPMPattern10.Name = "m_txtTx2BPMPattern10";
			this.m_txtTx2BPMPattern10.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern10.TabIndex = 54;
			this.m_txtTx2BPMPattern10.TextChanged += this.textBox46_TextChanged;
			this.m_txtTx2BPMPattern11.Location = new Point(384, 441);
			this.m_txtTx2BPMPattern11.Margin = new Padding(4);
			this.m_txtTx2BPMPattern11.Name = "m_txtTx2BPMPattern11";
			this.m_txtTx2BPMPattern11.Size = new Size(132, 22);
			this.m_txtTx2BPMPattern11.TabIndex = 55;
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern11);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern10);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern9);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern8);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern15);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern14);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern13);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern12);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern7);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern6);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern5);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern4);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern3);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern2);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern1);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx2BPMPattern0);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern15);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern14);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern13);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern12);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern11);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern10);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern9);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern8);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern7);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern6);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern5);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern4);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern3);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern2);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern1);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx1BPMPattern0);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern15);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern14);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern13);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern12);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern11);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern10);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern9);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern8);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern7);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern6);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern5);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern4);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern3);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern2);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern1);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_txtTx0BPMPattern0);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_cboResetOption);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_nudBPMPatternIndex);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.m_btnAdvanceBPMPatternCfg);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.label17);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.label16);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.label15);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.label14);
			this.m_grpAdvanceBPMPatternCfg.Controls.Add(this.label13);
			this.m_grpAdvanceBPMPatternCfg.Location = new Point(1003, 5);
			this.m_grpAdvanceBPMPatternCfg.Margin = new Padding(4);
			this.m_grpAdvanceBPMPatternCfg.Name = "m_grpAdvanceBPMPatternCfg";
			this.m_grpAdvanceBPMPatternCfg.Padding = new Padding(4);
			this.m_grpAdvanceBPMPatternCfg.Size = new Size(539, 649);
			this.m_grpAdvanceBPMPatternCfg.TabIndex = 24;
			this.m_grpAdvanceBPMPatternCfg.TabStop = false;
			this.m_grpAdvanceBPMPatternCfg.Text = "Advance BPM Pattern Config";
			this.m_btnMangBPMChirps.Location = new Point(255, 316);
			this.m_btnMangBPMChirps.Margin = new Padding(4);
			this.m_btnMangBPMChirps.Name = "m_btnMangBPMChirps";
			this.m_btnMangBPMChirps.Size = new Size(192, 39);
			this.m_btnMangBPMChirps.TabIndex = 45;
			this.m_btnMangBPMChirps.Text = "Manage BPM Chirps";
			this.m_btnMangBPMChirps.UseVisualStyleBackColor = true;
			this.m_btnMangBPMChirps.Click += this.m_btnMangBPMChirps_Click;
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.m_grpAdvanceBPMPatternCfg);
			base.Controls.Add(this.m_grpPerChirpPhaseShifterCfg);
			base.Controls.Add(this.f00012e);
			base.Margin = new Padding(4);
			base.Name = "BpmConfigTab";
			base.Size = new Size(1578, 668);
			base.Load += this.BpmConfigTab_Load;
			this.f00012e.ResumeLayout(false);
			this.f00012e.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.m_nudTx2On).EndInit();
			((ISupportInitialize)this.m_nudTx2Off).EndInit();
			((ISupportInitialize)this.m_nudTx1On).EndInit();
			((ISupportInitialize)this.m_nudTx1Off).EndInit();
			((ISupportInitialize)this.m_nudTx0On).EndInit();
			((ISupportInitialize)this.m_nudTx0Off).EndInit();
			((ISupportInitialize)this.m_nudEndIdx).EndInit();
			((ISupportInitialize)this.m_nudStrtIdx).EndInit();
			this.m_grpPerChirpPhaseShifterCfg.ResumeLayout(false);
			this.m_grpPerChirpPhaseShifterCfg.PerformLayout();
			((ISupportInitialize)this.m_nudTx2PhaseShifter).EndInit();
			((ISupportInitialize)this.m_nudTx1PhaseShifter).EndInit();
			((ISupportInitialize)this.m_nudTx0PhaseShifter).EndInit();
			((ISupportInitialize)this.m_nudChirpEndIndex).EndInit();
			((ISupportInitialize)this.m_nudChirpStartIndex).EndInit();
			((ISupportInitialize)this.m_nudBPMPatternIndex).EndInit();
			this.m_grpAdvanceBPMPatternCfg.ResumeLayout(false);
			this.m_grpAdvanceBPMPatternCfg.PerformLayout();
			base.ResumeLayout(false);
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		public BpmChirpConfigParams m_BpmChirpConfigParams;

		public PerChirpPhaseShifterConfigParams m_PerChirpPhaseShifterConfigParams;

		public PerChirpManager m_PerChirpManager;

		public BPMChirpManager m_BPMChirpManager;

		public AdvanceBPMPatternConfigParams m_AdvanceBPMPatternConfigParams;

		private IContainer components;

		private OpenFileDialog openFileDialog2;

		private GroupBox f00012e;

		private Button f00012f;

		private NumericUpDown m_nudEndIdx;

		private NumericUpDown m_nudStrtIdx;

		private Label label2;

		private Label label1;

		private GroupBox groupBox1;

		private Label label4;

		private Label label3;

		private Label Tx0;

		private NumericUpDown m_nudTx2On;

		private NumericUpDown m_nudTx2Off;

		private NumericUpDown m_nudTx1On;

		private NumericUpDown m_nudTx1Off;

		private NumericUpDown m_nudTx0On;

		private NumericUpDown m_nudTx0Off;

		private Label TxOn;

		private Label TxOff;

		private Label label6;

		private Label label5;

		private GroupBox m_grpPerChirpPhaseShifterCfg;

		private NumericUpDown m_nudTx2PhaseShifter;

		private NumericUpDown m_nudTx1PhaseShifter;

		private NumericUpDown m_nudTx0PhaseShifter;

		private NumericUpDown m_nudChirpEndIndex;

		private NumericUpDown m_nudChirpStartIndex;

		private Label label11;

		private Label label10;

		private Label label9;

		private Label label8;

		private Label label7;

		private Button m_btnPerChirpPhaseShifterCfg;

		private OpenFileDialog openFileDialog3;

		private Label label12;

		private Label label13;

		private Label label14;

		private Label label15;

		private Label label16;

		private Label label17;

		private Button m_btnAdvanceBPMPatternCfg;

		private NumericUpDown m_nudBPMPatternIndex;

		private ComboBox m_cboResetOption;

		private TextBox m_txtTx0BPMPattern0;

		private TextBox m_txtTx0BPMPattern1;

		private TextBox m_txtTx0BPMPattern2;

		private TextBox m_txtTx0BPMPattern3;

		private TextBox m_txtTx0BPMPattern4;

		private TextBox m_txtTx0BPMPattern5;

		private TextBox m_txtTx0BPMPattern6;

		private TextBox m_txtTx0BPMPattern7;

		private TextBox m_txtTx0BPMPattern8;

		private TextBox m_txtTx0BPMPattern9;

		private TextBox m_txtTx0BPMPattern10;

		private TextBox m_txtTx0BPMPattern11;

		private TextBox m_txtTx0BPMPattern12;

		private TextBox m_txtTx0BPMPattern13;

		private TextBox m_txtTx0BPMPattern14;

		private TextBox m_txtTx0BPMPattern15;

		private TextBox m_txtTx1BPMPattern0;

		private TextBox m_txtTx1BPMPattern1;

		private TextBox m_txtTx1BPMPattern2;

		private TextBox m_txtTx1BPMPattern3;

		private TextBox m_txtTx1BPMPattern4;

		private TextBox m_txtTx1BPMPattern5;

		private TextBox m_txtTx1BPMPattern6;

		private TextBox m_txtTx1BPMPattern7;

		private TextBox m_txtTx1BPMPattern8;

		private TextBox m_txtTx1BPMPattern9;

		private TextBox m_txtTx1BPMPattern10;

		private TextBox m_txtTx1BPMPattern11;

		private TextBox m_txtTx1BPMPattern12;

		private TextBox m_txtTx1BPMPattern13;

		private TextBox m_txtTx1BPMPattern14;

		private TextBox m_txtTx1BPMPattern15;

		private TextBox m_txtTx2BPMPattern0;

		private TextBox m_txtTx2BPMPattern1;

		private TextBox m_txtTx2BPMPattern2;

		private TextBox m_txtTx2BPMPattern3;

		private TextBox m_txtTx2BPMPattern4;

		private TextBox m_txtTx2BPMPattern5;

		private TextBox m_txtTx2BPMPattern6;

		private TextBox m_txtTx2BPMPattern7;

		private TextBox m_txtTx2BPMPattern12;

		private TextBox m_txtTx2BPMPattern13;

		private TextBox m_txtTx2BPMPattern14;

		private TextBox m_txtTx2BPMPattern15;

		private TextBox m_txtTx2BPMPattern8;

		private TextBox m_txtTx2BPMPattern9;

		private TextBox m_txtTx2BPMPattern10;

		private TextBox m_txtTx2BPMPattern11;

		private GroupBox m_grpAdvanceBPMPatternCfg;

		private Button m_btnMangPhaseShifter;

		private Button m_btnMangBPMChirps;
	}
}
