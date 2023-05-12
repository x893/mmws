using System;
using System.Collections.Generic;
using System.Threading;
using LuaInterface;
using LuaRegister;

namespace AR1xController
{
	public class AR1xxxgui
	{
		public Dictionary<GuiOp, AR1xxxFunc> LuaFormatDict
		{
			get
			{
				return this.m_LuaFormatDict;
			}
			set
			{
				this.m_LuaFormatDict = value;
			}
		}

		public Dictionary<string, object> AR1xxxguiTable
		{
			get
			{
				return this.f0002f0;
			}
			set
			{
				this.f0002f0 = value;
			}
		}

		public Dictionary<TsApiOp, string> ApiNameDict
		{
			get
			{
				return this.m_ApiNameDict;
			}
			set
			{
				this.m_ApiNameDict = value;
			}
		}

		public Dictionary<TsLuaKey, string> AR1xxxguiDict
		{
			get
			{
				return this.m_AR1xxxguiDict;
			}
			set
			{
				this.m_AR1xxxguiDict = value;
			}
		}

		public AR1xxxgui(GuiManager gui_manager)
		{
			this.m_GuiManager = gui_manager;
			this.m_LuaFormatDict = new Dictionary<GuiOp, AR1xxxFunc>();
			this.m_ApiNameDict = new Dictionary<TsApiOp, string>();
			this.m_AR1xxxguiDict = new Dictionary<TsLuaKey, string>();
			this.iFillLuaFormatDict();
			this.iFillApiNameDict();
			this.iFillAR1GuiDict();
		}

		public void AbortGuiOpThread()
		{
			if (this.m_GuiOpThread == null || (this.m_GuiOpThread.ThreadState & ThreadState.Stopped) == ThreadState.Stopped)
			{
				return;
			}
			if ((this.m_GuiOpThread.ThreadState & ThreadState.Suspended) == ThreadState.Suspended)
			{
				this.m_GuiOpThread.Resume();
			}
			this.m_GuiOpThread.Abort();
			this.m_GuiOpThread = null;
			this.m_GuiManager.MainTsForm.ConnectTab.GuiOpEnd(true);
		}

		private void iFillLuaFormatDict()
		{
			this.m_LuaFormatDict.Add(GuiOp.Calibrate, new AR1xxxFunc("ar1.CalibExecute", "return ar1gui.CalibExecute()"));
			this.m_LuaFormatDict.Add(GuiOp.ChannelTune, new AR1xxxFunc("ar1.ChannelTune", "return ar1gui.ChannelTune({0},{1})"));
			this.m_LuaFormatDict.Add(GuiOp.GoToElp, new AR1xxxFunc("ar1.GoToElp", "return ar1gui.GoToElp()"));
			this.m_LuaFormatDict.Add(GuiOp.RxLowPower, new AR1xxxFunc("ar1.RxLowPowerMode", "return ar1gui.RxLowPowerMode({0})"));
			this.m_LuaFormatDict.Add(GuiOp.RxBoost, new AR1xxxFunc("ar1.RxBoost", "return ar1gui.RxBoost({0})"));
			this.m_LuaFormatDict.Add(GuiOp.SetAntennaMode, new AR1xxxFunc("ar1.SetAntennaMode", "return ar1gui.SetAntennaMode({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11})"));
			this.m_LuaFormatDict.Add(GuiOp.f0002ae, new AR1xxxFunc("ar1.EnableDirectWriteMRC11b", "ar1gui.EnableDirectWriteMRC11b()"));
			this.m_LuaFormatDict.Add(GuiOp.f0002af, new AR1xxxFunc("ar1.DisableDirectWriteMRC11b", "ar1gui.DisableDirectWriteMRC11b()"));
			this.m_LuaFormatDict.Add(GuiOp.TxStop, new AR1xxxFunc("ar1.TxStop", "return ar1gui.TxStop({0},{1},{2},{3},{4},{5}, {6})"));
			this.m_LuaFormatDict.Add(GuiOp.SetOutputPower, new AR1xxxFunc("ar1.SetOutputPower", "return ar1gui.SetOutputPower({0},{1},{2},{3},{4},{5},{6},{7})"));
			this.m_LuaFormatDict.Add(GuiOp.PreStartTx, new AR1xxxFunc("ar1.PreStartTx", "ar1gui.PreStartTx()"));
			this.m_LuaFormatDict.Add(GuiOp.PostStartTx, new AR1xxxFunc("ar1.PostStartTx", "ar1gui.PostStartTx()"));
			this.m_LuaFormatDict.Add(GuiOp.StartTx, new AR1xxxFunc("ar1.StartTxEx", "return ar1gui.StartTxEx({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})"));
			this.m_LuaFormatDict.Add(GuiOp.TransmitSilence, new AR1xxxFunc("ar1.TransmitSilence", "return ar1gui.TransmitSilence()"));
			this.m_LuaFormatDict.Add(GuiOp.TransmitCarrier, new AR1xxxFunc("ar1.TransmitCarrierFeedThrough", "return ar1gui.TransmitCarrierFeedThrough()"));
			this.m_LuaFormatDict.Add(GuiOp.TransmitTwoTone, new AR1xxxFunc("ar1.TransmitTwoTone", "return ar1gui.TransmitTwoTone({0}, {1})"));
			this.m_LuaFormatDict.Add(GuiOp.TransmitSingleTone, new AR1xxxFunc("ar1.StartCW", "return ar1gui.StartCW({0}, {1})"));
			this.m_LuaFormatDict.Add(GuiOp.StopTxCW, new AR1xxxFunc("ar1.StopCW", "return ar1gui.StopCW()"));
			this.m_LuaFormatDict.Add(GuiOp.EnableDpd, new AR1xxxFunc("ar1.EnDpd", "ar1gui.EnDpd({0})"));
			this.m_LuaFormatDict.Add(GuiOp.Bip, new AR1xxxFunc("ar1.TestSignal", "ar1gui.TestSignal({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23})"));
			this.m_LuaFormatDict.Add(GuiOp.StopRxStats, new AR1xxxFunc("ar1.stopRXStats", "return ar1gui.stopRXStats()"));
			this.m_LuaFormatDict.Add(GuiOp.StartRxStats, new AR1xxxFunc("ar1.RXStatsMode", "return ar1gui.RXStatsMode({0},{1},{2})"));
			this.m_LuaFormatDict.Add(GuiOp.GetRxStats, new AR1xxxFunc("ar1.getRXStats", "return ar1gui.getRXStats({0})"));
			this.m_LuaFormatDict.Add(GuiOp.f0002b0, new AR1xxxFunc("ar1.rstRXStats", "return ar1gui.rstRXStats()"));
			this.m_LuaFormatDict.Add(GuiOp.PostConnect, new AR1xxxFunc("ar1.PostConnect", "ar1gui.PostConnect()"));
			this.m_LuaFormatDict.Add(GuiOp.PostDownloadFw, new AR1xxxFunc("ar1.PostDownloadFw", "ar1gui.PostDownloadFw()"));
			this.m_LuaFormatDict.Add(GuiOp.PhySAControl, new AR1xxxFunc("ar1.PhySAControl", "ar1gui.PhySAControl()"));
			this.m_LuaFormatDict.Add(GuiOp.DcOffsetOverride, new AR1xxxFunc("ar1.dcOffsetOverride", "ar1gui.dcOffsetOverride({0},{1},{2},{3})"));
			this.m_LuaFormatDict.Add(GuiOp.AnalogDcOverride, new AR1xxxFunc("ar1.analogDCOverride", "ar1gui.analogDCOverride({0},{1},{2})"));
			this.m_LuaFormatDict.Add(GuiOp.f0002b1, new AR1xxxFunc("ar1.txiqOverride", "ar1gui.txiqOverride({0},{1},{2},{3})"));
			this.m_LuaFormatDict.Add(GuiOp.IPaMixerVgaOverride, new AR1xxxFunc("ar1.txIPaMixerVgaOverride", "ar1gui.txIPaMixerVgaOverride({0})"));
			this.m_LuaFormatDict.Add(GuiOp.f0002b2, new AR1xxxFunc("ar1.rxRF_DACOverride", "ar1gui.rxRF_DACOverride({0},{1},{2})"));
			this.m_LuaFormatDict.Add(GuiOp.f0002b3, new AR1xxxFunc("ar1.rxBB_DACOverride", "ar1gui.rxBB_DACOverride({0},{1},{2})"));
			this.m_LuaFormatDict.Add(GuiOp.RFIF1VgaOverride, new AR1xxxFunc("ar1.RXIF1VgaOverride", "ar1gui.RXIF1VgaOverride({0},{1},{2},{3})"));
			this.m_LuaFormatDict.Add(GuiOp.ReadersDc, new AR1xxxFunc("ar1.readresDC", "return ar1gui.readresDC({0})"));
			this.m_LuaFormatDict.Add(GuiOp.ConnectAnalogPorts, new AR1xxxFunc("ar1.SetChannelConfig", "return ar1gui.ConnectAnalogPorts({0},{1},{2},{3})"));
			this.m_LuaFormatDict.Add(GuiOp.SetChannelConfig, new AR1xxxFunc("ar1.SetChannelConfig", "return ar1gui.SetChannelConfig({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14})"));
			this.m_LuaFormatDict.Add(GuiOp.SetNfModConfig, new AR1xxxFunc("ar1.SetNfModConfig", "return ar1gui.SetNfModConfig({0},{1},{2},{3},{4},{5},{6},{7},{8})"));
			this.m_LuaFormatDict.Add(GuiOp.SetAdcConfig, new AR1xxxFunc("ar1.SetAdcConfig", "return ar1gui.SetAdcConfig({0},{1},{2},{3},{4},{5},{6},{7},{8},{9})"));
			this.m_LuaFormatDict.Add(GuiOp.SetLpAdcConfig, new AR1xxxFunc("ar1.SetLpAdcConfig", "return ar1gui.SetLpAdcConfig({0},{1},{2},{3},{4},{5},{6},{7},{8},{9})"));
			this.m_LuaFormatDict.Add(GuiOp.SetDynPowConf, new AR1xxxFunc("ar1.SetDynPowConf", "return ar1gui.SetDynPowConf({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})"));
			this.m_LuaFormatDict.Add(GuiOp.GetChannelConfig, new AR1xxxFunc("ar1.GetChannelConfig", "return ar1gui.GetChannelConfig()"));
			this.m_LuaFormatDict.Add(GuiOp.GetDynPowConf, new AR1xxxFunc("ar1.GetDynPowConf", "return ar1gui.GetDynPowConf()"));
			this.m_LuaFormatDict.Add(GuiOp.GetNfModConfig, new AR1xxxFunc("ar1.GetNfModConfig", "return ar1gui.GetNfModConfig()"));
			this.m_LuaFormatDict.Add(GuiOp.GetLpAdcConfig, new AR1xxxFunc("ar1.GetLpAdcConfig", "return ar1gui.GetLpAdcConfig()"));
			this.m_LuaFormatDict.Add(GuiOp.GetAdcConfig, new AR1xxxFunc("ar1.GetAdcConfig", "return ar1gui.GetAdcConfig()"));
		}

		private void iFillApiNameDict()
		{
			this.m_ApiNameDict.Add(TsApiOp.Connect, "ar1.Calling_ATE_ConnectTarget");
			this.m_ApiNameDict.Add(TsApiOp.Disconnect, "ar1.Calling_ATE_DisconnectTarget");
			this.m_ApiNameDict.Add(TsApiOp.ReadIni, "ar1.Calling_ATE_Read_INI_File");
			this.m_ApiNameDict.Add(TsApiOp.SetIniFilePath, "ar1.Calling_SetIniFilePath");
		}

		private void iFillAR1GuiDict()
		{
			this.m_AR1xxxguiDict.Add(TsLuaKey.ConnectComPort, "connect.ComPort");
			this.m_AR1xxxguiDict.Add(TsLuaKey.ConnectBaudRate, "connect.BaudRate");
			this.m_AR1xxxguiDict.Add(TsLuaKey.ConnectTimeout, "connect.Timeout");
			this.m_AR1xxxguiDict.Add(TsLuaKey.ConnectFwFile, "connect.FwFile");
			this.m_AR1xxxguiDict.Add(TsLuaKey.ConnectIniFile, "connect.IniFile");
			this.m_AR1xxxguiDict.Add(TsLuaKey.ConnectSetINvsFile, "connect.NVSFile");
			this.m_AR1xxxguiDict.Add(TsLuaKey.ConnectDllFile, "connect.DllFile");
			this.m_AR1xxxguiDict.Add(TsLuaKey.ConnectPoll, "connect.Poll");
		}

		public int ExecuteApi(TsApiOp op_id, object[] args)
		{
			return this.ExecuteApi(op_id, args, true, true);
		}

		public int ExecuteApi(TsApiOp op_id, object[] args, bool is_starting_op, bool is_ending_op)
		{
			int result = -1;
			this.m_IsEndingOp = is_ending_op;
			if (this.m_GuiOpThread != null && (this.m_GuiOpThread.ThreadState & ThreadState.Stopped) != ThreadState.Stopped && !this.m_GuiManager.IsExternalThread())
			{
				return result;
			}
			try
			{
				if (GlobalRef.TsWrapper.IsGuiShown())
				{
					GlobalRef.GuiManager.MainTsForm.ConnectTab.GuiOpStart(this.m_ApiNameDict[op_id], is_starting_op);
				}
				ApiRunner apiRunner = new ApiRunner(op_id, args, is_ending_op);
				this.m_GuiOpThread = new Thread(new ThreadStart(apiRunner.Execute));
				this.m_GuiOpThread.IsBackground = true;
				this.m_GuiOpThread.Name = "TS_API";
				this.m_GuiOpThread.Start();
				this.m_GuiOpThread.Join();
				result = apiRunner.Res;
				if (apiRunner.Aborted)
				{
					this.iHandleAbort(op_id);
				}
			}
			catch (ThreadAbortException)
			{
				this.iHandleAbort(op_id);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
			return result;
		}

		private void iHandleAbort(TsApiOp op_id)
		{
			GlobalRef.GuiManager.ErrorAbort(string.Format("Instruction '{0}' was aborted.", this.m_ApiNameDict[op_id]));
			if (GlobalRef.TsWrapper.IsGuiShown())
			{
				GlobalRef.GuiManager.MainTsForm.GuiOpExtEnd();
			}
		}

		public object[] Execute(GuiOp op_id, object[] args, bool async)
		{
			return this.Execute(op_id, args, async, true, true);
		}

		public object[] Execute(GuiOp op_id, object[] args, bool async, bool is_starting_op, bool is_ending_op)
		{
			object[] result = null;
			this.m_IsEndingOp = is_ending_op;
			if (this.m_GuiOpThread != null && (this.m_GuiOpThread.ThreadState & ThreadState.Stopped) != ThreadState.Stopped && (async || !this.m_GuiManager.IsExternalThread()))
			{
				return null;
			}
			try
			{
				string format = this.m_LuaFormatDict[op_id].Format;
				string text;
				if (args != null)
				{
					text = string.Format(format, args);
				}
				else
				{
					text = format;
				}
				GlobalRef.GuiManager.RecordLog((int)op_id, text.Replace("ar1gui", "ar1"));
				if (!async && this.m_GuiManager.IsExternalThread())
				{
					if (GlobalRef.TsWrapper.IsGuiShown())
					{
						GlobalRef.GuiManager.MainTsForm.ConnectTab.GuiOpExtStart(this.m_LuaFormatDict[op_id].Name);
					}
					result = GlobalRef.LuaWrapper.DoString(text);
					if (GlobalRef.TsWrapper.IsGuiShown())
					{
						GlobalRef.GuiManager.MainTsForm.GuiOpExtEnd();
					}
				}
				else
				{
					if (GlobalRef.TsWrapper.IsGuiShown())
					{
						GlobalRef.GuiManager.MainTsForm.ConnectTab.GuiOpStart(this.m_LuaFormatDict[op_id].Name, is_starting_op);
					}
					result = GlobalRef.LuaWrapper.DoString(text, (int)op_id, new dPostLuaOpDel(this.PostLuaFunc), out this.m_GuiOpThread, async);
				}
			}
			catch (ThreadAbortException)
			{
				GlobalRef.GuiManager.Error(string.Format("Instruction '{0}' was aborted.", this.m_LuaFormatDict[op_id].Name));
				if (GlobalRef.TsWrapper.IsGuiShown())
				{
					GlobalRef.GuiManager.MainTsForm.GuiOpExtEnd();
				}
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
			return result;
		}

		public void PostLuaFunc(int op_id, object[] res)
		{
			Delegate guiEndFunc = this.m_GuiManager.GetGuiEndFunc((GuiOp)op_id);
			if (guiEndFunc != null)
			{
				guiEndFunc.DynamicInvoke(new object[]
				{
					res
				});
			}
			if (GlobalRef.TsWrapper.IsGuiShown())
			{
				GlobalRef.GuiManager.MainTsForm.ConnectTab.GuiOpEnd(this.m_IsEndingOp);
			}
		}

		public bool GetSingleIntRes(GuiOp op_id, object[] res_arr, out int res)
		{
			res = -1;
			try
			{
				res = (int)((double)res_arr[0]);
			}
			catch
			{
				this.m_GuiManager.ErrorAbort(string.Format("Failed to get results from {0}", this.m_LuaFormatDict[op_id].Name));
				return false;
			}
			return true;
		}

		public bool GetTwoIntRes(GuiOp op_id, object[] res_arr, out int res1, out int res2)
		{
			res1 = -1;
			res2 = -1;
			try
			{
				res1 = (int)((double)res_arr[0]);
				res2 = (int)((double)res_arr[1]);
			}
			catch
			{
				this.m_GuiManager.ErrorAbort(string.Format("Failed to get results from {0}", this.m_LuaFormatDict[op_id].Name));
				return false;
			}
			return true;
		}

		public bool GetThreeIntRes(GuiOp op_id, object[] res_arr, out int res1, out int res2, out int res3)
		{
			res1 = -1;
			res2 = -1;
			res3 = -1;
			try
			{
				res1 = (int)((double)res_arr[0]);
				res2 = (int)((double)res_arr[1]);
				res3 = (int)((double)res_arr[2]);
			}
			catch
			{
				this.m_GuiManager.ErrorAbort(string.Format("Failed to get results from {0}", this.m_LuaFormatDict[op_id].Name));
				return false;
			}
			return true;
		}

		public void SetCalibUponTuneStatus(bool status)
		{
			try
			{
				string lua_str = string.Format("ar1gui.CalibUponTune = {0}", status.ToString().ToLower());
				this.m_GuiManager.DoLuaString(0, lua_str);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
		}

		public void SetNumOfAnt(int num_of_ant_val)
		{
			try
			{
				string lua_str = string.Format("ar1gui.numOfAnt = {0}", num_of_ant_val.ToString().ToLower());
				this.m_GuiManager.DoLuaString(0, lua_str);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
		}

		public void SetPhyStandAlone(bool val)
		{
			try
			{
				string lua_str = string.Format("ar1gui.PhyStandAlone = {0}", val.ToString().ToLower());
				this.m_GuiManager.DoLuaString(0, lua_str);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
		}

		public void SetTsApiFlag(bool val)
		{
			try
			{
				string lua_str = string.Format("ar1gui.UseTsApi = {0}", val.ToString().ToLower());
				this.m_GuiManager.DoLuaString(0, lua_str);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
		}

		public object[] GetRxStatsValues()
		{
			object[] result;
			try
			{
				string lua_str = string.Format("return rxstats.num_good_packets, rxstats.num_bad_packets, rxstats.num_RX_BD_error, rxstats.num_rx_ls_rejet, rxstats.num_rx_stomp, rxstats.num_plcp_header_error, rxstats.num_cca_time_out, rxstats.per", new object[0]);
				result = this.m_GuiManager.DoLuaString(0, lua_str, false);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = null;
			}
			return result;
		}

		public object[] GetRxStats_UnSafe(int num_expected_packets)
		{
			object[] result;
			try
			{
				string full_command = string.Format("ar1.getRXStats({0})", num_expected_packets);
				this.m_GuiManager.RecordLog(27, full_command);
				string lua_str = string.Format("return ar1gui.getRXStats({0})", num_expected_packets);
				result = this.m_GuiManager.DoLuaString(0, lua_str);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = null;
			}
			return result;
		}

		public void EnablePhyStandAlone()
		{
			try
			{
				string lua_str = "return wmb(0x8092c000,'31:00',0x80000000)";
				if ((int)((double)this.m_GuiManager.DoLuaString(0, lua_str, false)[0]) != 0)
				{
					this.m_GuiManager.ErrorAbort("Failed to set enable register for phy stand alone mode");
				}
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
		}

		public bool Getar1guiTable()
		{
			bool result;
			try
			{
				this.f0002f0 = new Dictionary<string, object>();
				string lua_str = "return ar1gui";
				LuaTable luaTable = (LuaTable)this.m_GuiManager.DoLuaString(0, lua_str, false)[0];
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool GetTableBoolVal(string key, ref bool value)
		{
			bool result;
			try
			{
				if (this.f0002f0.ContainsKey(key))
				{
					value = (bool)this.f0002f0[key];
					result = true;
				}
				else
				{
					this.m_GuiManager.Error(string.Format("Could not find key '{0}' in ar1gui table", key));
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

		public void SetTableVal(TsLuaKey key, string value)
		{
			this.SetTableVal(key, value, LuaType.Number);
		}

		public void SetTableVal(TsLuaKey key, string value, LuaType type)
		{
			try
			{
				if (type == LuaType.f0002bd)
				{
					value = string.Format("\"{0}\"", value);
				}
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
		}

		private GuiManager m_GuiManager;

		private Dictionary<GuiOp, AR1xxxFunc> m_LuaFormatDict;

		private Dictionary<TsApiOp, string> m_ApiNameDict;

		private Thread m_GuiOpThread;

		private bool m_IsEndingOp;

		private Dictionary<string, object> f0002f0;

		private Dictionary<TsLuaKey, string> m_AR1xxxguiDict;
	}
}
