using System;
using System.IO;

namespace AR1xController
{
	public class DllOps
	{
		public void Init(GuiManager gui_manager, AR1xxxWrapper ts_wrapper)
		{
			this.m_GuiManager = gui_manager;
			this.m_TsWrapper = ts_wrapper;
			this.m_MainForm = gui_manager.MainTsForm;
			this.m_MainParams = gui_manager.TsParams.MainParams;
			this.m_TxParams = gui_manager.TsParams.TxParams;
			this.m_RxParams = gui_manager.TsParams.RxParams;
			this.m_ConnectParams = gui_manager.TsParams.ConnectParams;
			this.iBindGuiOps();
		}

		private void iBindGuiOps()
		{
			this.m_GuiManager.BindApi(TsApiOp.StartTx, new del_i_v(this.m_GuiManager.DllOps.iStartTx_Invoke));
			this.m_GuiManager.BindApi(TsApiOp.StopTx, new del_i_v(this.m_GuiManager.DllOps.iStopTx_Invoke));
			this.m_GuiManager.BindApi(TsApiOp.SetOutputPower, new del_i_v(this.m_GuiManager.DllOps.iSetOutputPower_Invoke));
			this.m_GuiManager.BindApi(TsApiOp.Connect, new del_i_objarr(this.m_GuiManager.DllOps.iConnect_Invoke));
			this.m_GuiManager.BindApi(TsApiOp.SetNvsPath, new del_i_v(this.m_GuiManager.DllOps.iSetNvsPath_Invoke));
			this.m_GuiManager.BindApi(TsApiOp.SetIniFilePath, new del_i_v(this.m_GuiManager.DllOps.iSetIniFilePath_Invoke));
			this.m_GuiManager.BindApi(TsApiOp.Disconnect, new del_i_v(this.m_GuiManager.DllOps.iDisconnect_Invoke));
			this.m_GuiManager.BindApi(TsApiOp.ChannelTune, new del_i_v(this.m_GuiManager.DllOps.iChannelTune_Invoke));
			this.m_GuiManager.BindApi(TsApiOp.StartRx, new del_i_v(this.m_GuiManager.DllOps.iStartRx_Invoke));
			this.m_GuiManager.BindApi(TsApiOp.StopRx, new del_i_v(this.m_GuiManager.DllOps.iStoptRx_Invoke));
		}

		private void iPreStartTx(bool is_starting_op, bool is_ending_op)
		{
			this.m_GuiManager.p000002.Execute(GuiOp.PreStartTx, null, false, is_starting_op, is_ending_op);
		}

		private void iPostStartTx(bool is_starting_op, bool is_ending_op)
		{
		}

		private int iStartTx(bool is_starting_op, bool is_ending_op)
		{
			int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.StartTx, null, is_starting_op, is_ending_op);
			if (num != 0)
			{
				this.m_GuiManager.ErrorApiFailure(TsApiOp.StartTx, num);
			}
			return num;
		}

		private int iStartTx_Invoke()
		{
			int result;
			try
			{
				uint delay = (uint)this.m_TxParams.Delay;
				uint value = (uint)this.m_TxParams.Rate.Value;
				uint size = (uint)this.m_TxParams.Size;
				if (this.m_TxParams.Mode != TxMode.Packet_Continuous)
				{
					int amount = this.m_TxParams.Amount;
				}
				uint sgi = (uint)this.m_TxParams.SGI;
				string srcMacAddr = this.m_TxParams.SrcMacAddr;
				string dstMacAddr = this.m_TxParams.DstMacAddr;
				result = this.m_TsWrapper.Calling_ATE_TxPacket(delay, value, (ushort)size, (ushort)this.m_TxParams.Amount, (ushort)this.m_TxParams.Seed, (sbyte)this.m_TxParams.Mode, 1, (sbyte)sgi, (sbyte)this.m_TxParams.Preamble, (sbyte)this.m_TxParams.Type, (sbyte)this.m_TxParams.Scramble, 1, 1, srcMacAddr, dstMacAddr);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private int iStopTx(bool is_starting_op, bool is_ending_op)
		{
			int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.StopTx, null, is_starting_op, is_ending_op);
			if (num != 0)
			{
				this.m_GuiManager.ErrorApiFailure(TsApiOp.StopTx, num);
			}
			return num;
		}

		private int iStopTx_Invoke()
		{
			int result;
			try
			{
				result = this.m_TsWrapper.m0000cc();
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private int iSetOutputPower(bool is_starting_op, bool is_ending_op)
		{
			int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.SetOutputPower, null, is_starting_op, is_ending_op);
			if (num != 0)
			{
				this.m_GuiManager.ErrorApiFailure(TsApiOp.SetOutputPower, num);
			}
			return num;
		}

		private int iSetOutputPower_Invoke()
		{
			int result;
			try
			{
				int desiredPwr = (int)(this.m_TxParams.Power * 1000.0);
				result = this.m_TsWrapper.Calling_ATE_TxGainAdjust(desiredPwr, (byte)this.m_TxParams.Soc);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private int iConnectSeq(uint con_type, uint dest, bool ext)
		{
			int result;
			try
			{
				this.m_MainForm.ConnectTab.ConnectBegin();
				int num = this.iConnect(con_type, dest);
				this.m_MainForm.GetBoardStatus();
				this.m_MainForm.ConnectTab.ConnectEnd(num, ext);
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private int iConnectSeqRadarDevice2(uint con_type, uint dest, bool ext)
		{
			int result;
			try
			{
				this.m_MainForm.ConnectTab.ConnectBegin();
				int num = this.iConnect(con_type, dest);
				this.m_MainForm.GetBoardStatus();
				this.m_MainForm.ConnectTab.ConnectEndRadarDevice2(num, ext);
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private int iConnectSeqRadarDevice3(uint con_type, uint dest, bool ext)
		{
			int result;
			try
			{
				this.m_MainForm.ConnectTab.ConnectBegin();
				int num = this.iConnect(con_type, dest);
				this.m_MainForm.GetBoardStatus();
				this.m_MainForm.ConnectTab.ConnectEndRadarDevice3(num, ext);
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private int iConnectSeqRadarDevice4(uint con_type, uint dest, bool ext)
		{
			int result;
			try
			{
				this.m_MainForm.ConnectTab.ConnectBegin();
				int num = this.iConnect(con_type, dest);
				this.m_MainForm.GetBoardStatus();
				this.m_MainForm.ConnectTab.ConnectEndRadarDevice4(num, ext);
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public void m000004()
		{
			try
			{
				this.m_MainForm.ConnectTab.EnableDSPConfSpecifications();
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
		}

		private int iSetNvsPath()
		{
			int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.SetNvsPath, null, false, false);
			if (num != 0)
			{
				string msg = string.Format("Setting NVS path failed: Calling_ATE_SetNVSPath returned {0}", num);
				this.m_GuiManager.Error(msg);
			}
			return num;
		}

		private int iSetNvsPath_Invoke()
		{
			int result;
			try
			{
				int num = -1;
				string nvsPath = this.m_ConnectParams.NvsPath;
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private int iSetFrefClk()
		{
			int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.SetFrefClk, null, false, false);
			if (num != 0)
			{
				string msg = string.Format("Setting Fref clock failed: Calling_SetFrefClk returned {0}", num);
				this.m_GuiManager.Error(msg);
			}
			return num;
		}

		private int iSetIniFilePath()
		{
			int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.SetIniFilePath, null, false, false);
			if (num != 0)
			{
				string msg = string.Format("Setting Ini file path failed: Calling_SetIniFilePath returned {0}", num);
				this.m_GuiManager.Error(msg);
			}
			return num;
		}

		private int iSetIniFilePath_Invoke()
		{
			int result;
			try
			{
				string iniPath = this.m_ConnectParams.IniPath;
				result = this.m_TsWrapper.Calling_SetIniFilePath(iniPath);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int iConnect(uint con_type, uint dest)
		{
			int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.Connect, new object[]
			{
				con_type,
				dest
			}, false, false);
			if (num == 0)
			{
				GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] = true;
			}
			else
			{
				string msg = string.Format("Connection failed: Calling_ConnectTarget returned {0}", num);
				this.m_GuiManager.Error(msg);
			}
			return num;
		}

		private int iConnect_Invoke(object[] args)
		{
			int result;
			try
			{
				uint con_type = (uint)args[0];
				uint dest = (uint)args[1];
				uint timeout = 1000U;
				uint com_port;
				uint baud_rate;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					com_port = (uint)this.m_ConnectParams.ComPort;
					baud_rate = (uint)this.m_ConnectParams.BaudRate;
				}
				else
				{
					com_port = (uint)GlobalRef.g_RS232ComPort[(int)GlobalRef.g_RadarDeviceIndex];
					baud_rate = (uint)GlobalRef.g_RS232BaudRate[(int)GlobalRef.g_RadarDeviceIndex];
				}
				int num = this.m_TsWrapper.Calling_ATE_ConnectTarget(com_port, baud_rate, timeout);
				if (num == Constants.UnsupportedDllMethod)
				{
					this.m_GuiManager.Log("Using Calling_ATE_ConnectTarget instead...");
					num = this.m_TsWrapper.Calling_ATE_ConnectTarget_Ex(con_type, com_port, baud_rate, timeout, dest);
				}
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int iDisconnect(bool ext)
		{
			int result;
			try
			{
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					string full_command = "ar1.Disconnect()";
					this.m_GuiManager.RecordLog(2, full_command);
				}
				else
				{
					string full_command2 = "ar1.Disconnect_mult()";
					this.m_GuiManager.RecordLog(2, full_command2);
				}
				this.m_MainForm.ConnectTab.DisconnectBegin();
				int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.Disconnect, null, false, false);
				if (num != 0)
				{
					string msg = string.Format("Failed to disconnect: Calling_ATE_DisconnectTarget returned {0}", num);
					this.m_GuiManager.Error(msg);
				}
				else
				{
					GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] = false;
				}
				this.m_MainForm.GetBoardStatus();
				this.m_MainForm.ConnectTab.DisconnectEnd(num, ext);
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int iDisconnectRadarDevice2(bool ext)
		{
			int result;
			try
			{
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					string full_command = "ar1.Disconnect()";
					this.m_GuiManager.RecordLog(2, full_command);
				}
				else
				{
					string full_command2 = "ar1.Disconnect_mult()";
					this.m_GuiManager.RecordLog(2, full_command2);
				}
				this.m_MainForm.ConnectTab.DisconnectBegin();
				int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.Disconnect, null, false, false);
				if (num != 0)
				{
					string msg = string.Format("Failed to disconnect: Calling_ATE_DisconnectTarget returned {0}", num);
					this.m_GuiManager.Error(msg);
				}
				else
				{
					GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] = false;
				}
				this.m_MainForm.GetBoardStatus();
				this.m_MainForm.ConnectTab.DisconnectEndRadarDevice2(num, ext);
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int iDisconnectRadarDevice3(bool ext)
		{
			int result;
			try
			{
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					string full_command = "ar1.Disconnect()";
					this.m_GuiManager.RecordLog(2, full_command);
				}
				else
				{
					string full_command2 = "ar1.Disconnect_mult()";
					this.m_GuiManager.RecordLog(2, full_command2);
				}
				this.m_MainForm.ConnectTab.DisconnectBegin();
				int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.Disconnect, null, false, false);
				if (num != 0)
				{
					string msg = string.Format("Failed to disconnect: Calling_ATE_DisconnectTarget returned {0}", num);
					this.m_GuiManager.Error(msg);
				}
				else
				{
					GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] = false;
				}
				this.m_MainForm.GetBoardStatus();
				this.m_MainForm.ConnectTab.DisconnectEndRadarDevice3(num, ext);
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int iDisconnectRadarDevice4(bool ext)
		{
			int result;
			try
			{
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					string full_command = "ar1.Disconnect()";
					this.m_GuiManager.RecordLog(2, full_command);
				}
				else
				{
					string full_command2 = "ar1.Disconnect_mult()";
					this.m_GuiManager.RecordLog(2, full_command2);
				}
				this.m_MainForm.ConnectTab.DisconnectBegin();
				int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.Disconnect, null, false, false);
				if (num != 0)
				{
					string msg = string.Format("Failed to disconnect: Calling_ATE_DisconnectTarget returned {0}", num);
					this.m_GuiManager.Error(msg);
				}
				else
				{
					GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] = false;
				}
				this.m_MainForm.GetBoardStatus();
				this.m_MainForm.ConnectTab.DisconnectEndRadarDevice4(num, ext);
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int itempDisconnect(bool ext)
		{
			int result;
			try
			{
				string full_command = "ar1.Disconnect()";
				this.m_GuiManager.RecordLog(2, full_command);
				this.m_MainForm.ConnectTab.DisconnectBegin();
				int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.Disconnect, null, false, false);
				if (num != 0)
				{
					string msg = string.Format("Failed to disconnect: Calling_ATE_DisconnectTarget returned {0}", num);
					this.m_GuiManager.Error(msg);
				}
				else
				{
					GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] = false;
				}
				this.m_MainForm.ConnectTab.tempDisconnectEnd(num, ext);
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int iReConnect(bool ext)
		{
			int result;
			try
			{
				result = this.m_GuiManager.DllOps.iConnect(1U, 0U);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private int iDisconnect_Invoke()
		{
			return this.m_TsWrapper.Calling_ATE_DisconnectTarget();
		}

		private int iReadIniFile(out string error_str, bool EnableGetFEMType)
		{
			int result;
			try
			{
				int num = -1;
				string iniPath = this.m_ConnectParams.IniPath;
				error_str = "";
				string full_command = string.Format("ar1.API_ReadIniFile(\"{0}\",{1})", iniPath, EnableGetFEMType.ToString().ToLower());
				this.m_GuiManager.RecordLog(101, full_command);
				this.m_MainForm.ConnectTab.GuiOpExtStart(this.m_GuiManager.p000002.ApiNameDict[TsApiOp.ReadIni]);
				if (string.IsNullOrEmpty(iniPath))
				{
					result = 0;
				}
				else
				{
					if (File.Exists(iniPath))
					{
						num = this.m_TsWrapper.m0000cb(iniPath, out error_str, EnableGetFEMType);
					}
					else
					{
						this.m_GuiManager.Error(string.Format("Could not find ini file '{0}'", iniPath));
					}
					this.m_MainForm.GuiOpExtEnd();
					result = num;
				}
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				error_str = "";
				result = -1;
			}
			return result;
		}

		private int iChannelTune_Invoke()
		{
			int result;
			try
			{
				byte band = (byte)this.m_MainParams.Channel.Band;
				byte channel = (byte)this.m_MainParams.Channel.PrimIdx;
				result = this.m_TsWrapper.Calling_ATE_Channel(band, channel);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private int iChannelTune(bool is_starting_op, bool is_ending_op)
		{
			int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.ChannelTune, null, is_starting_op, is_ending_op);
			if (num != 0)
			{
				this.m_GuiManager.ErrorApiFailure(TsApiOp.ChannelTune, num);
			}
			return num;
		}

		private int iStartRx_Invoke()
		{
			int result;
			try
			{
				result = this.m_TsWrapper.Start_RX_Simulation();
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private int iStartRx(bool is_starting_op, bool is_ending_op)
		{
			int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.StartRx, null, is_starting_op, is_ending_op);
			if (num != 0)
			{
				this.m_GuiManager.ErrorApiFailure(TsApiOp.StartRx, num);
			}
			return num;
		}

		private int iStoptRx_Invoke()
		{
			int result;
			try
			{
				result = this.m_TsWrapper.Stop_RX_Simulation();
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private int iStopRx(bool is_starting_op, bool is_ending_op)
		{
			int num = this.m_GuiManager.p000002.ExecuteApi(TsApiOp.StopRx, null, is_starting_op, is_ending_op);
			if (num != 0)
			{
				this.m_GuiManager.ErrorApiFailure(TsApiOp.StopRx, num);
			}
			return num;
		}

		public int Connect_Gui(uint con_type, uint dest)
		{
			this.m_MainForm.ConnectTab.UpdateData();
			return this.iConnectSeq(con_type, dest, false);
		}

		public int Disconnect_Gui()
		{
			return this.iDisconnect(false);
		}

		public int ConnectRadarDev2_Gui(uint con_type, uint dest)
		{
			this.m_MainForm.ConnectTab.UpdateDataRadarDevice2();
			return this.iConnectSeqRadarDevice2(con_type, dest, false);
		}

		public int ConnectRadarDev3_Gui(uint con_type, uint dest)
		{
			this.m_MainForm.ConnectTab.UpdateDataRadarDevice3();
			return this.iConnectSeqRadarDevice3(con_type, dest, false);
		}

		public int ConnectRadarDev4_Gui(uint con_type, uint dest)
		{
			this.m_MainForm.ConnectTab.UpdateDataRadarDevice4();
			return this.iConnectSeqRadarDevice4(con_type, dest, false);
		}

		public int DisconnectRadarDev2_Gui()
		{
			return this.iDisconnectRadarDevice2(false);
		}

		public int DisconnectRadarDev3_Gui()
		{
			return this.iDisconnectRadarDevice3(false);
		}

		public int DisconnectRadarDev4_Gui()
		{
			return this.iDisconnectRadarDevice4(false);
		}

		public int ReadIni_Gui()
		{
			this.m_MainForm.ConnectTab.UpdateData();
			string text;
			return this.iReadIniFile(out text, true);
		}

		public void ProfileProgramFileterSet()
		{
			this.m_MainForm.ChirpConfigTab.EnableProfileProgFiltFor16XXARDevice();
			this.m_MainForm.AdvanceFrameConfigTab.EnableAdvFrameControlProgFiltFor16XXARDevice();
			this.m_MainForm.DataConfigTab.m000072();
			this.m_MainForm.DataConfigTab.DisableEnableCQConfigAndCQ0_1_2_TransSize_BasedOn_RadarDevice();
			this.m_MainForm.StaticConfigTab.DisableTx3ChannelFor16XXARDevice();
			this.m_MainForm.ContStreamingTab.DisableContinuousStreamingPowerBackOffAndPhaseShiftRegisterFor16XXARDevice();
			this.m_MainForm.BpmConfigTab.DisableBPMTx3ValuesBothTxOnAndTxOffFor16XXARDevice();
			this.m_MainForm.BpmConfigTab.DisablePerChirpPhaseShifterFor16XXARDevice();
			this.m_MainForm.ExternalFilterProgramming.DisableFilterProgramFor16XXARDevice();
			this.m_MainForm.ClockOutConfig.DisableEnableBothPMICAndMCUClockoutConfig_BasedOn_RadarDevice();
		}

		public int DownloadFw_Gui()
		{
			int result = -1;
			this.m_MainForm.RampTimingCfgTab.EnableProgFiltFor16XXARDevice();
			new del_v_v(this.ProfileProgramFileterSet).BeginInvoke(null, null);
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_MainForm.ConnectTab.UpdateData();
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				this.m_MainForm.ConnectTab.UpdateDataRadarDevice2();
			}
			else if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				this.m_MainForm.ConnectTab.UpdateDataRadarDevice2();
			}
			else if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				this.m_MainForm.ConnectTab.UpdateDataRadarDevice2();
			}
			if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
			{
				string fwPath = this.m_MainForm.ConnectTab.GetFwPath();
				string full_command = string.Format("ar1.DownloadBSSFw(\"{0}\")", fwPath);
				this.m_GuiManager.RecordLog(103, full_command);
				result = this.m_MainForm.ConnectTab.DownloadFw(false, fwPath);
			}
			else if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				string fwPath2 = this.m_MainForm.ConnectTab.GetFwPath();
				string full_command2 = string.Format("ar1.DownloadBSSFw_mult({0},\"{1}\")", GlobalRef.g_RadarDeviceId, fwPath2);
				this.m_GuiManager.RecordLog(103, full_command2);
				result = this.m_MainForm.ConnectTab.DownloadFw(false, fwPath2);
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				string fwPath3 = this.m_MainForm.ConnectTab.GetFwPath();
				string full_command3 = string.Format("ar1.DownloadBSSFw_mult({0},\"{1}\")", GlobalRef.g_RadarDeviceId, fwPath3);
				this.m_GuiManager.RecordLog(103, full_command3);
				result = this.m_MainForm.ConnectTab.DownloadFw(false, fwPath3);
			}
			else if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				string fwPath4 = this.m_MainForm.ConnectTab.GetFwPath();
				string full_command4 = string.Format("ar1.DownloadBSSFw_mult({0},\"{1}\")", GlobalRef.g_RadarDeviceId, fwPath4);
				this.m_GuiManager.RecordLog(103, full_command4);
				result = this.m_MainForm.ConnectTab.DownloadFw(false, fwPath4);
			}
			else if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				string fwPath5 = this.m_MainForm.ConnectTab.GetFwPath();
				string full_command5 = string.Format("ar1.DownloadBSSFw_mult({0},\"{1}\")", GlobalRef.g_RadarDeviceId, fwPath5);
				this.m_GuiManager.RecordLog(103, full_command5);
				result = this.m_MainForm.ConnectTab.DownloadFw(false, fwPath5);
			}
			return result;
		}

		public int DownloadMssFw_Gui()
		{
			int result = -1;
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_MainForm.ConnectTab.UpdateData();
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				this.m_MainForm.ConnectTab.UpdateDataRadarDevice2();
			}
			else if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				this.m_MainForm.ConnectTab.UpdateDataRadarDevice2();
			}
			else if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				this.m_MainForm.ConnectTab.UpdateDataRadarDevice2();
			}
			if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
			{
				string mssfwPath = this.m_MainForm.ConnectTab.GetMSSFwPath();
				string full_command = string.Format("ar1.DownloadMSSFw(\"{0}\")", mssfwPath);
				this.m_GuiManager.RecordLog(103, full_command);
				result = this.m_MainForm.ConnectTab.DownloadFw(false, mssfwPath);
			}
			else if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				string mssfwPath2 = this.m_MainForm.ConnectTab.GetMSSFwPath();
				string full_command2 = string.Format("ar1.DownloadMSSFw_mult({0}, \"{1}\")", GlobalRef.g_RadarDeviceId, mssfwPath2);
				this.m_GuiManager.RecordLog(103, full_command2);
				result = this.m_MainForm.ConnectTab.DownloadFw(false, mssfwPath2);
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				string mssfwPath3 = this.m_MainForm.ConnectTab.GetMSSFwPath();
				string full_command3 = string.Format("ar1.DownloadMSSFw_mult({0}, \"{1}\")", GlobalRef.g_RadarDeviceId, mssfwPath3);
				this.m_GuiManager.RecordLog(103, full_command3);
				result = this.m_MainForm.ConnectTab.DownloadFw(false, mssfwPath3);
			}
			else if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				string mssfwPath4 = this.m_MainForm.ConnectTab.GetMSSFwPath();
				string full_command4 = string.Format("ar1.DownloadMSSFw_mult({0}, \"{1}\")", GlobalRef.g_RadarDeviceId, mssfwPath4);
				this.m_GuiManager.RecordLog(103, full_command4);
				result = this.m_MainForm.ConnectTab.DownloadFw(false, mssfwPath4);
			}
			else if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				string mssfwPath5 = this.m_MainForm.ConnectTab.GetMSSFwPath();
				string full_command5 = string.Format("ar1.DownloadMSSFw_mult({0}, \"{1}\")", GlobalRef.g_RadarDeviceId, mssfwPath5);
				this.m_GuiManager.RecordLog(103, full_command5);
				result = this.m_MainForm.ConnectTab.DownloadFw(false, mssfwPath5);
			}
			return result;
		}

		public int DownloadDSPFw_Gui()
		{
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_MainForm.ConnectTab.UpdateData();
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				this.m_MainForm.ConnectTab.UpdateDataRadarDevice2();
			}
			string dspFwPath = this.m_MainForm.ConnectTab.GetDspFwPath();
			string full_command = string.Format("ar1.DownloadDSPFw(\"{0}\")", dspFwPath);
			this.m_GuiManager.RecordLog(103, full_command);
			return this.m_MainForm.ConnectTab.DownloadDSPFw(false, dspFwPath);
		}

		public int SetUpContStreamMode()
		{
			int result = -1;
			this.m_MainForm.ContStreamingTab.UpdateMtLbContStrData();
			string contStreamDumpFilePath = this.m_MainForm.ContStreamingTab.GetContStreamDumpFilePath();
			this.m_MainForm.ContStreamingTab.GetContStreamNoOfSamples();
			string full_command = string.Format("ar1.SetUpContMode(\"{0}\")", contStreamDumpFilePath);
			this.m_GuiManager.RecordLog(103, full_command);
			return result;
		}

		public int ChannelTune_Gui(bool is_starting_op, bool is_ending_op)
		{
			int result;
			try
			{
				ChannelData channel = this.m_MainParams.Channel;
				int channel2ndIdx = this.m_MainParams.Channel2ndIdx;
				this.m_MainForm.UpdateData();
				int num = this.iChannelTune(is_starting_op, is_ending_op);
				if (num != 0)
				{
					this.m_MainParams.Channel = channel;
					this.m_MainParams.Channel2ndIdx = channel2ndIdx;
					this.m_MainForm.UpdateGui();
				}
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int StartRx_Gui(bool is_starting_op, bool is_ending_op)
		{
			return this.iStartRx(is_starting_op, is_ending_op);
		}

		public int StopRx_Gui(bool is_starting_op, bool is_ending_op)
		{
			return this.iStopRx(is_starting_op, is_ending_op);
		}

		public int StartTx_Ext(uint delay, uint rate, ushort size, ushort amount, int power, ushort seed, sbyte packetMode, sbyte dcfOnOff, sbyte p8, sbyte preamble, sbyte type, sbyte scrambler, sbyte enableCLPC, sbyte seqNumMode, string SrcMacAddr, string DstMacAddr)
		{
			int result;
			try
			{
				this.m_MainForm.UpdateData();
				this.m_TxParams.Delay = (int)delay;
				this.m_TxParams.Size = (int)size;
				if (packetMode == 0)
				{
					this.m_TxParams.Mode = TxMode.Packet_Single;
				}
				else if (packetMode == 1)
				{
					this.m_TxParams.Mode = TxMode.Packet_Series;
				}
				else
				{
					this.m_TxParams.Mode = TxMode.Packet_Continuous;
				}
				this.m_TxParams.SGI = (int)p8;
				this.m_TxParams.Amount = (int)amount;
				this.m_TxParams.SrcMacAddr = SrcMacAddr;
				this.m_TxParams.DstMacAddr = DstMacAddr;
				this.m_TxParams.Preamble = (Preamble)preamble;
				result = this.iStartTx(true, true);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int StopTx_Ext()
		{
			int result;
			try
			{
				result = this.iStopTx(true, true);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int SetOutputPower_Ext(int des_pwr, uint level_idx, uint freq_band, uint freq_prim_chan, int freq_2nd_chan, uint ant_select, uint non_srv, uint chan_limit, uint fem_limit, uint gain_calc_mode, uint analog_gain_idx, int post_dpd)
		{
			int result;
			try
			{
				this.m_MainForm.UpdateData();
				if (gain_calc_mode == 0U)
				{
					this.m_TxParams.Dbm = 1;
					this.m_TxParams.Soc = 1;
				}
				else if (gain_calc_mode == 1U)
				{
					this.m_TxParams.Dbm = 1;
					this.m_TxParams.Soc = 0;
				}
				else
				{
					this.m_TxParams.Dbm = 0;
					this.m_TxParams.Soc = 0;
				}
				this.m_TxParams.Power = (double)des_pwr / 1000.0;
				this.m_TxParams.AnalogSetting = (int)analog_gain_idx;
				this.m_TxParams.AntSelect = (int)ant_select;
				this.m_TxParams.ChanLimit = (int)chan_limit;
				this.m_TxParams.FemLimit = (int)fem_limit;
				this.m_TxParams.PostDpd = (double)post_dpd / 1000.0;
				result = this.iSetOutputPower(true, true);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int Connect_Ext(uint RadarDeviceId, uint con_type, uint com_port, uint baud_rate, uint timeout, uint board_type, uint dest)
		{
			int result = -1;
			if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
			{
				this.m_MainForm.ConnectTab.UpdateData();
				this.m_ConnectParams.ComPort = (int)com_port;
				this.m_ConnectParams.BaudRate = (int)baud_rate;
			}
			else if (RadarDeviceId == 1U)
			{
				this.m_MainForm.ConnectTab.UpdateData();
				GlobalRef.g_RS232ComPort[(int)GlobalRef.g_RadarDeviceIndex] = (int)com_port;
				GlobalRef.g_RS232BaudRate[(int)GlobalRef.g_RadarDeviceIndex] = (int)baud_rate;
			}
			else if (RadarDeviceId == 2U)
			{
				this.m_MainForm.ConnectTab.UpdateDataRadarDevice2();
				GlobalRef.g_RS232ComPort[(int)GlobalRef.g_RadarDeviceIndex] = (int)com_port;
				GlobalRef.g_RS232BaudRate[(int)GlobalRef.g_RadarDeviceIndex] = (int)baud_rate;
			}
			this.m_ConnectParams.Timeout = (int)timeout;
			this.m_ConnectParams.BoardType = (int)board_type;
			this.m_MainForm.ConnectTab.UpdateGui();
			if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
			{
				result = this.iConnectSeq(con_type, dest, true);
			}
			else if (RadarDeviceId == 1U)
			{
				result = this.iConnectSeq(con_type, dest, true);
			}
			else if (RadarDeviceId == 2U)
			{
				result = this.iConnectSeqRadarDevice2(con_type, dest, true);
			}
			return result;
		}

		public int Disconnect_Ext(uint RadarDeviceId)
		{
			int result;
			if (RadarDeviceId == 1U)
			{
				result = this.iDisconnect(true);
			}
			else
			{
				result = this.iDisconnectRadarDevice2(true);
			}
			return result;
		}

		public int ReadIni_Ext(string ini_path, out string error_str, bool EnableGetFEMType)
		{
			this.m_MainForm.ConnectTab.UpdateData();
			this.m_ConnectParams.IniPath = ini_path;
			this.m_MainForm.ConnectTab.UpdateGui();
			return this.iReadIniFile(out error_str, EnableGetFEMType);
		}

		public int DownloadFw_Ext(string path)
		{
			int result;
			try
			{
				this.m_MainForm.ConnectTab.UpdateData();
				this.m_ConnectParams.BSS_FwPath = path;
				this.m_MainForm.ConnectTab.UpdateGui();
				result = this.m_MainForm.ConnectTab.DownloadFw(true, path);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int ChannelTune_Ext(int band, int primary_chan_idx, int bandwidth)
		{
			int result;
			try
			{
				if (this.m_MainForm.BoardStatus == BoardStatus.DISCONNECTED)
				{
					this.m_GuiManager.Error("ChannelTune: Board is disconnected");
					result = -1;
				}
				else
				{
					this.m_MainForm.UpdateData();
					ChannelData channel = this.m_MainParams.Channel;
					int channel2ndIdx = this.m_MainParams.Channel2ndIdx;
					int indexByBandAndPrime = this.m_MainForm.ChannelTable.GetIndexByBandAndPrime((Band)band, primary_chan_idx);
					if (indexByBandAndPrime == -1)
					{
						this.m_GuiManager.Error(string.Format("ChannelTune: could not match channel to band {0} and primary channel index {1}", band, primary_chan_idx));
						result = -1;
					}
					else
					{
						this.m_MainParams.Channel = this.m_MainForm.ChannelTable[indexByBandAndPrime];
						if (bandwidth == 0 || bandwidth == 1)
						{
							this.m_MainParams.Channel2ndIdx = 0;
						}
						else if (bandwidth == 2)
						{
							this.m_MainParams.Channel2ndIdx = -1;
						}
						else
						{
							if (bandwidth != 3)
							{
								this.m_GuiManager.Error(string.Format("ChannelTune: invalid bandwidth {0}", bandwidth));
								return -1;
							}
							this.m_MainParams.Channel2ndIdx = 1;
						}
						this.m_MainForm.UpdateGui();
						int num = this.iChannelTune(true, true);
						if (num != 0)
						{
							this.m_MainParams.Channel = channel;
							this.m_MainParams.Channel2ndIdx = channel2ndIdx;
							this.m_MainForm.UpdateGui();
						}
						result = num;
					}
				}
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int StartRx_Ext(uint issue_ack)
		{
			int result;
			try
			{
				int num = -1;
				if (issue_ack < 2U)
				{
					this.m_RxParams.IssueAck = issue_ack;
				}
				result = num;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		public int StopRx_Ext()
		{
			int result;
			try
			{
				result = this.iStopRx(true, true);
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = -1;
			}
			return result;
		}

		private GuiManager m_GuiManager;

		private AR1xxxWrapper m_TsWrapper;

		private MainParams m_MainParams;

		private ConnectParams m_ConnectParams;

		private TxParams m_TxParams;

		private RxParams m_RxParams;

		private frmAR1Main m_MainForm;
	}
}
