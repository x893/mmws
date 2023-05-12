using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using LuaInterface;
using LuaRegister;
using MathWorks.MATLAB.NET.Arrays;

namespace AR1xController
{
	public class AR1xxxWrapper
	{
		public frmAR1Main MainTsfrm
		{
			get
			{
				return m_MainAR1frm;
			}
			set
			{
				m_MainAR1frm = value;
			}
		}

		public GuiManager GuiManager
		{
			get
			{
				return m_GuiManager;
			}
			set
			{
				m_GuiManager = value;
			}
		}

		public AR1xxxWrapper(LuaWrapper lua_wrapper)
		{
			m_LuaWrapper = lua_wrapper;
			m_GuiManager = new GuiManager();
			GlobalRef.GuiManager = m_GuiManager;
			m_SPWrapper = new SerialPortWrapper();
			m_MainAR1frm = m_GuiManager.MainTsForm;
		}

		public void UnLoad()
		{
			CloseGui();
			m_SPWrapper.Close();
		}

		public uint Init(string com_port, uint baudrate)
		{
			return m_SPWrapper.Init(com_port, (int)baudrate);
		}

		[AttrLuaFunc("PowerOn", "PowerOn", new string[]
		{
			"bCrcPresent",
			"bAckRequested",
			"trasportType, spi:0, RS232:1",
			"portNum",
			"out powerUpTime",
			"out powerUpStatus",
			"out bootTestStatus"
		})]
		public int PowerOn(ushort crcType, ushort ackTimeout, char trasportType, uint portNum, out uint powerUpTime, out string powerUpStatus, out string bootTestStatus)
		{
			ushort radarDeviceId = 1;
			powerUpTime = 0U;
			powerUpStatus = string.Empty;
			bootTestStatus = string.Empty;
			return m_GuiManager.ScriptOps.PowOnCmd(radarDeviceId, crcType, ackTimeout, trasportType, portNum, out powerUpTime, out powerUpStatus, out bootTestStatus);
		}

		[AttrLuaFunc("PowerOn_mult", "PowerOn_mult", new string[]
		{
			"Radar Device Id",
			"bCrcPresent",
			"bAckRequested",
			"trasportType, spi:0, RS232:1",
			"portNum",
			"out powerUpTime",
			"out powerUpStatus",
			"out bootTestStatus"
		})]
		public int PowerOn(ushort RadarDeviceId, ushort crcType, ushort ackTimeout, char trasportType, uint portNum, out uint powerUpTime, out string powerUpStatus, out string bootTestStatus)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			powerUpTime = 0U;
			powerUpStatus = string.Empty;
			bootTestStatus = string.Empty;
			return m_GuiManager.ScriptOps.PowOnCmd(RadarDeviceId, crcType, ackTimeout, trasportType, portNum, out powerUpTime, out powerUpStatus, out bootTestStatus);
		}

		[AttrLuaFunc("AddDevice", "AddDevice API used to connect slave devices through SPI", new string[]
		{
			"Radar Device Id"
		})]
		public int AddDevice(ushort RadarDeviceId)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.AddDevicePowOnCmd(RadarDeviceId);
		}

		[AttrLuaFunc("RemoveDevice", "Disconnect the SPI from slave Devices", new string[]
		{
			"Radar Device Id"
		})]
		public int RemoveDevice(ushort RadarDeviceId)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.AddDevicePowOnCmd(RadarDeviceId);
		}

		[AttrLuaFunc("DownloadBssFwOvSPI", "DownloadBssFwOvSPI", new string[]
		{
			"FwPath"
		})]
		public int DownloadBssFwOvSPI(string FwPath)
		{
			if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U && !GlobalRef.g_RS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				return m_GuiManager.ScriptOps.iDownldBssFwCmdLine_Impl(1, FwPath);
			}
			m_GuiManager.Log("Only SPI should be connected");
			return -1;
		}

		[AttrLuaFunc("DownloadBssFwOvSPI_mult", "Download Bss Firmware Over SPI on cascade device", new string[]
		{
			"Radar Device Id",
			"BSS Firmware Path"
		})]
		public int DownloadBssFwOvSPI(ushort RadarDeviceId, string FwPath)
		{
			if (((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U) && !GlobalRef.g_RS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				return m_GuiManager.ScriptOps.iDownldBssFwCmdLine_Impl(RadarDeviceId, FwPath);
			}
			m_GuiManager.Log("Only SPI should be connected");
			return -1;
		}

		[AttrLuaFunc("DownloadMssFwOvSPI", "DownloadMssFwOvSPI", new string[]
		{
			"FwPath"
		})]
		public int DownloadMssFwOvSPI(string FwPath)
		{
			if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U && !GlobalRef.g_RS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				return m_GuiManager.ScriptOps.iDownldMssFwCmdLine_Impl(1, FwPath);
			}
			m_GuiManager.Log("Only SPI should be connected");
			return -1;
		}

		[AttrLuaFunc("DownloadMssFwOvSPI_mult", "DownloadMssFwOvSPI", new string[]
		{
			"Radar Device Id",
			"FwPath"
		})]
		public int DownloadMssFwOvSPI_mult(ushort RadarDeviceId, string FwPath)
		{
			if (((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U) && !GlobalRef.g_RS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				return m_GuiManager.ScriptOps.iDownldMssFwCmdLine_Impl(RadarDeviceId, FwPath);
			}
			m_GuiManager.Log("Only SPI should be connected");
			return -1;
		}

		[AttrLuaFunc("DebugSignal", "DebugSignal", new string[]
		{
			"DebugSignal to set"
		})]
		public int SetDbgSignal(ushort DbgMode)
		{
			return m_GuiManager.MainTsForm.RegOpeTab.GetDbgSigDataFrmCmd(DbgMode);
		}

		[AttrLuaFunc("SOPControl", "SOPControl", new string[]
		{
			"SOP Mode to set"
		})]
		public int SetSop(ushort sopMod)
		{
			ushort radarDeviceId = 1;
			return m_GuiManager.ScriptOps.SetSopCmd(radarDeviceId, sopMod);
		}

		[AttrLuaFunc("SOPControl_mult", "SOPControl_mult", new string[]
		{
			"Radar Device Id",
			"SOP Mode to set"
		})]
		public int SetSop(ushort RadarDeviceId, ushort sopMod)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.SetSopCmd(RadarDeviceId, sopMod);
		}

		[AttrLuaFunc("FullReset", "FullReset")]
		public int FullReset()
		{
			return m_GuiManager.ScriptOps.iFullReset_Impl();
		}

		[AttrLuaFunc("selectRadarMode", "Select the Radar Mode", new string[]
		{
			"mode ; 0: Single Chip, 1 : Cascade Chip"
		})]
		public int selectRadarMode(uint mode)
		{
			return m_MainAR1frm.selectRadarModeLua(mode);
		}

		[AttrLuaFunc("selectCascadeMode", "Select the Cascade Mode", new string[]
		{
			"mode ; 0: Two Chip Cascade, 1 : Four Chip Cascade"
		})]
		public int selectCascadeMode(uint mode)
		{
			if (mode == 0U)
			{
				m_LuaWrapper.PrintError("Two chip Cascade mode is not supported!");
				return -1;
			}
			return m_MainAR1frm.selectCascadeModeLua(mode);
		}

		[AttrLuaFunc("ConnectTDA", "Setup and Connect to TDA", new string[]
		{
			"IP Address of TDA",
			"Configuration port no",
			"Device Map indicating the devices to be enabled by TDA"
		})]
		public int m0000a2(string ipAddr, int portno, uint deviceMap)
		{
			if (!GlobalRef.g_TDACaptureCardConnectStatus)
			{
				return m_GuiManager.ScriptOps.m0000a2(ipAddr, portno, deviceMap);
			}
			m_GuiManager.RecordLog(9, "Connection to the TDA is already established!");
			return 0;
		}

		[AttrLuaFunc("DisconnectTDA", "Disconnect with TDA Capture card")]
		public int DisconnectTDA()
		{
			return m_GuiManager.ScriptOps.DisconnectTDA();
		}

		[AttrLuaFunc("RfEnable", "RfEnable", new string[]
		{
			"out powerUpStatus",
			"out powerUpTime"
		})]
		public int RfEnable(out string powerUpStatus, out uint powerUpTime)
		{
			powerUpStatus = string.Empty;
			powerUpTime = 0U;
			return m_GuiManager.ScriptOps.m00008b(1, out powerUpStatus, out powerUpTime);
		}

		[AttrLuaFunc("RfEnable_mult", "RfEnable_mult", new string[]
		{
			"Radar Device Id",
			"out powerUpStatus",
			"out powerUpTime"
		})]
		public int RfEnable(ushort RadarDeviceId, out string powerUpStatus, out uint powerUpTime)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			powerUpStatus = string.Empty;
			powerUpTime = 0U;
			return m_GuiManager.ScriptOps.m00008b(RadarDeviceId, out powerUpStatus, out powerUpTime);
		}

		[AttrLuaFunc("GetStaticCharData", "GetStaticCharData", new string[]
		{
			"out processType",
			" out refClkFreq",
			" out apllCalStatus",
			"out apllClkFreqMHz"
		})]
		public int GetStaticCharData(out string processType, out ushort refClkFreq, out string apllCalStatus, out float apllClkFreqMHz)
		{
			processType = string.Empty;
			refClkFreq = 0;
			apllCalStatus = string.Empty;
			apllClkFreqMHz = 0f;
			return m_GuiManager.ScriptOps.GetStaticCharBootUpData(out processType, out refClkFreq, out apllCalStatus, out apllClkFreqMHz);
		}

		[AttrLuaFunc("RfInit_mult", "RfInit API defines the intialization of RF anlog and digital base band sections", new string[]
		{
			"Radar Device Id",
			"out the Status of each calibration (0-Fail, 1- Pass)",
			"out Particular calibration data has been updated in hardware (0-No Update, 1-Updated)",
			" out Measured Temperature at the time of calibration",
			" out Time Stamp at the time of performing calibration updates"
		})]
		public int RfInit(ushort RadarDeviceId, out string CalibStatus, out string CalibUpdate, out short Temperature, out uint TimeStamp)
		{
			CalibStatus = string.Empty;
			CalibUpdate = string.Empty;
			Temperature = 0;
			TimeStamp = 0U;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.iSetRfInit_LUA(RadarDeviceId, out CalibStatus, out CalibUpdate, out Temperature, out TimeStamp);
		}

		[AttrLuaFunc("RfInit", "RfInit API defines the intialization of RF anlog and digital base band sections", new string[]
		{
			"out the Status of each calibration (0-Fail, 1- Pass)",
			"out Particular calibration data has been updated in hardware (0-No Update, 1-Updated)",
			" out Measured Temperature at the time of calibration",
			" out Time Stamp at the time of performing calibration updates"
		})]
		public int RfInit(out string CalibStatus, out string CalibUpdate, out short Temperature, out uint TimeStamp)
		{
			CalibStatus = string.Empty;
			CalibUpdate = string.Empty;
			Temperature = 0;
			TimeStamp = 0U;
			return m_GuiManager.ScriptOps.iSetRfInit_LUA(1, out CalibStatus, out CalibUpdate, out Temperature, out TimeStamp);
		}

		[AttrLuaFunc("StartFrame_mult", "StartFrame", new string[]
		{
			"Radar Device Id"
		})]
		public int TriggerFrameCmd(ushort RadarDeviceId)
		{
			if (!GlobalRef.g_2ChipCascade && !GlobalRef.g_4ChipCascade)
			{
				m_GuiManager.LuaError("Cascade API issued for single chip device");
				return -1;
			}
			int radarDevIndx = m_MainAR1frm.getRadarDevIndx((uint)RadarDeviceId);
			if (!GlobalRef.g_FrameTriggered_Cascade[radarDevIndx])
			{
				m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
				return m_GuiManager.ScriptOps.iSetTrigFrame_InCascadeMode_Gui(RadarDeviceId, true, false);
			}
			m_GuiManager.RecordLog(9, "Frame already triggered for the cascade device");
			return -1;
		}

		[AttrLuaFunc("StartFrame", "StartFrame")]
		public int TriggerFrameCmd()
		{
			if (!GlobalRef.g_FrameTriggered)
			{
				return m_GuiManager.ScriptOps.iSetTrigFrame_Gui(1, true, false);
			}
			m_GuiManager.RecordLog(9, "Frame already triggered");
			return -1;
		}

		[AttrLuaFunc("StopFrame_mult", "StopFrame", new string[]
		{
			"Radar Device Id"
		})]
		public int StopFrameCmd(ushort RadarDeviceId)
		{
			if (!GlobalRef.g_2ChipCascade && !GlobalRef.g_4ChipCascade)
			{
				m_GuiManager.LuaError("Cascade API issued for single chip device");
				return -1;
			}
			int radarDevIndx = m_MainAR1frm.getRadarDevIndx((uint)RadarDeviceId);
			if (GlobalRef.g_FrameTriggered_Cascade[radarDevIndx])
			{
				m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
				return m_GuiManager.ScriptOps.iSetStopFrame_InCascadeMode_Gui(RadarDeviceId, true, false);
			}
			m_GuiManager.LuaError("Frame already stopped for the cascade device");
			return -1;
		}

		[AttrLuaFunc("StopFrame", "StopFrame")]
		public int StopFrameCmd()
		{
			if (GlobalRef.g_FrameTriggered)
			{
				return m_GuiManager.ScriptOps.iSetStopFrame_Gui(1, true, false);
			}
			m_GuiManager.RecordLog(9, "Frame already stopped");
			return -1;
		}

		[AttrLuaFunc("TDACaptureCard_StartRecord_mult", "TDACaptureCard_StartRecord API used to start/open the VIP ports in the TDA Capture Card", new string[]
		{
			"Radar Device Id",
			"Number of files to be allocated",
			"Enable Data Packing. 0 - 16bit, 1 - 12bit",
			"Name of the Capture Directory (eg. adc_data)",
			"Number of frames to be captured by TDA in a session. 0 - disable this condition (default case). Any positive value - Number of frames to be captured"
		})]
		public int TDACaptureCard_StartRecord(ushort RadarDeviceId, uint numFilesAllocated, uint enableDataPacking, string captureDirectory, uint numFramesToCapture)
		{
			GlobalRef.g_RadarDeviceId = (uint)RadarDeviceId;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			m_MainAR1frm.ChirpConfigTab.m00000d(numFilesAllocated, enableDataPacking, captureDirectory, numFramesToCapture);
			return m_MainAR1frm.iSetTDACaptureCard_ImplThread();
		}

		[AttrLuaFunc("TDACaptureCard_StopRecord_mult", "TDACaptureCard_StopRecord API used to stop/close the VIP ports in the TDA Capture Card", new string[]
		{
			"Radar Device Id"
		})]
		public int TDACaptureCard_StopRecord(ushort RadarDeviceId)
		{
			GlobalRef.g_RadarDeviceId = (uint)RadarDeviceId;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_MainAR1frm.ChirpConfigTab.StopRecordTDA();
		}

		[AttrLuaFunc("IsConnected", "IsConnected")]
		public int IsConnected()
		{
			return (int)Imports.RadarLinkImpl_IsConnected();
		}

		[AttrLuaFunc("PowerOff", "PowerOff")]
		public int PowerOff()
		{
			if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U)
			{
				return m_GuiManager.ScriptOps.iSPIConnectDisconnect_Gui(true, false);
			}
			GlobalRef.LuaWrapper.PrintWarning("Already SPI disconnected (POWER OFF) from Radar device...!!!");
			return 0;
		}

		[AttrLuaFunc("PowerOff_mult", "PowerOff")]
		public int PowerOffDevice()
		{
			if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U)
			{
				m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
				return m_GuiManager.ScriptOps.iSPIConnectDisconnect_Gui(true, false);
			}
			GlobalRef.LuaWrapper.PrintWarning("Already SPI disconnected (POWER OFF) from Master device...!!!");
			return 0;
		}

		[AttrLuaFunc("ChanNAdcConfig_mult", " Static device config API which defines configure both the Transmiter and Reciever channels of Radar device and also ADC data format output", new string[]
		{
			"Radar Device Id",
			"Tx0 channel",
			"Tx1 channel",
			"Tx2 channel",
			"Rx0 channel",
			"Rx1 channnel",
			"Rx2 channel",
			"Rx3 channel[b15:0] + (CascadePinOutCfg[b31:16] b16:ClkOutMasterDis, b17:SynOutMasterDis, b18:ClkOutSlaveEna, b19:SynOutSlaveEna, b20:IntLOMasterEna, b21:OSCClkOutMasterDis)",
			"Number of ADC bits",
			"ADC output format[b15:0] + FullScaleReductionFactor[b31:16]",
			"ADC Mode",
			"CascadeMode(Single Chip: 0x0000, MultiChip Master:0x0001, MultiChip Slave:0x0002)"
		})]
		public int ChanNAdcConfig(ushort RadarDeviceId, ushort p1, ushort p2, ushort p3, ushort p4, ushort p5, ushort p6, uint p7, int BitsVal, uint FmtVal, uint IQSwap, ushort CasCadeMode)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetChanNAdcConfData(RadarDeviceId, p1, p2, p3, p4, p5, p6, p7, BitsVal, FmtVal, IQSwap, CasCadeMode);
		}

		[AttrLuaFunc("ChanNAdcConfig", " Static device config API which defines configure both the Transmiter and Reciever channels of Radar device and also ADC data format output", new string[]
		{
			"Tx0 channel",
			"Tx1 channel",
			"Tx2 channel",
			"Rx0 channel",
			"Rx1 channnel",
			"Rx2 channel",
			"Rx3 channel[b15:0] + (CascadePinOutCfg[b31:16] b16:ClkOutMasterDis, b17:SynOutMasterDis, b18:ClkOutSlaveEna, b19:SynOutSlaveEna, b20:IntLOMasterEna, b21:OSCClkOutMasterDis)",
			"Number of ADC bits",
			"ADC output format[b15:0] + FullScaleReductionFactor[b31:16]",
			"ADC Mode[b15:0] + CascadeMode[b31:16](Single Chip: 0x0000, MultiChip Master:0x0001, MultiChip Slave:0x0002)"
		})]
		public int ChanNAdcConfig(ushort p0, ushort p1, ushort p2, ushort p3, ushort p4, ushort p5, uint p6, int BitsVal, uint FmtVal, uint IQSwap)
		{
			return m_GuiManager.ScriptOps.UpdateNSetChanNAdcConfData(1, p0, p1, p2, p3, p4, p5, p6, BitsVal, FmtVal, IQSwap, (ushort)(IQSwap >> 16));
		}

		[AttrLuaFunc("SetMiscConfig", " PerChirpPhaseShifterEnaConfig API which defines controls miscellaneous global RF controls", new string[]
		{
			"Per chirp phase shifter enable or disable"
		})]
		public int PerChirpPhaseShifterEnaConfig(uint PerChirpPhaseShifterEnable)
		{
			return m_GuiManager.ScriptOps.UpdateNSetPerChirpPhaseShifterEnableConfData(1, PerChirpPhaseShifterEnable);
		}

		[AttrLuaFunc("SetMiscConfig_mult", " PerChirpPhaseShifterEnaConfig API which defines controls miscellaneous global RF controls", new string[]
		{
			"Radar device id",
			"Per chirp phase shifter enable or disable"
		})]
		public int PerChirpPhaseShifterEnaConfig(ushort RadarDeviceId, uint PerChirpPhaseShifterEnable)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetPerChirpPhaseShifterEnableConfData(RadarDeviceId, PerChirpPhaseShifterEnable);
		}

		[AttrLuaFunc("SetCalMonFreqLimitConfig", " SetCalMonFreqLimitConfig API which defines Radar RF calibration and monitoring frequency limit", new string[]
		{
			"Frequency limit low",
			"Frequency limit high"
		})]
		public int SetCalMonFreqLimitConfig(double FreqLimitLow, double FreqLimitHigh)
		{
			return m_GuiManager.ScriptOps.UpdateNSetFreqLimitConfData(1, FreqLimitLow, FreqLimitHigh);
		}

		[AttrLuaFunc("SetCalMonFreqLimitConfig_mult", " SetCalMonFreqLimitConfig_mult API which defines Radar RF calibration and monitoring frequency limit", new string[]
		{
			"Radar Device Id",
			"Frequency limit low",
			"Frequency limit high"
		})]
		public int SetCalMonFreqLimitConfig(ushort RadarDeviceId, double FreqLimitLow, double FreqLimitHigh)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetFreqLimitConfData(RadarDeviceId, FreqLimitLow, FreqLimitHigh);
		}

		[AttrLuaFunc("SetRFDeviceConfig", " SetRFDeviceConfig API which configures the direction of async event from BSS", new string[]
		{
			"RFAEDirection",
			"AEControl",
			"Reserved",
			"BSSDigitalControl",
			"AsyncEventCRCConfig",
			"Reserved2",
			"Reserved3"
		})]
		public int SetRFDeviceConfig(uint RFAEDirection, byte AEControl, ushort Reserved, byte BSSDigitalControl, byte AsyncEventCRCConfig, byte Reserved2, ushort Reserved3)
		{
			return m_GuiManager.ScriptOps.UpdateNRFDeviceAEControlConfData(1, RFAEDirection, AEControl, Reserved, BSSDigitalControl, AsyncEventCRCConfig, Reserved2, Reserved3);
		}

		[AttrLuaFunc("SetRFDeviceConfig_mult", " SetRFDeviceConfig API which configures the direction of async event from BSS", new string[]
		{
			"Radar device",
			"RFAEDirection",
			"AEControl",
			"Reserved",
			"BSSDigitalControl",
			"AsyncEventCRCConfig",
			"Reserved2",
			"Reserved3"
		})]
		public int SetRFDeviceConfig(ushort RadarDeviceId, uint RFAEDirection, byte AEControl, ushort Reserved, byte BSSDigitalControl, byte AsyncEventCRCConfig, byte Reserved2, ushort Reserved3)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNRFDeviceAEControlConfData(RadarDeviceId, RFAEDirection, AEControl, Reserved, BSSDigitalControl, AsyncEventCRCConfig, Reserved2, Reserved3);
		}

		[AttrLuaFunc("RfSetCalMonFreqTxPowLimitConfig", " RfSetCalMonFreqTxPowLimitConfig API which sets the limits for RF frequency transmission for each TX and also Tx power limits", new string[]
		{
			"Tx0 Frequency limit low in MHz",
			"Tx1 Frequency limit low MHz",
			"Tx2 Frequency limit low MHz",
			"Tx0 Frequency limit high in MHz",
			"Tx1 Frequency limit high in MHz",
			"Tx2 Frequency limit high in MHz",
			"Tx0 output power backoff in dB",
			"Tx1 output power backoff in dB",
			"Tx2 output power backoff in dB"
		})]
		public int RfSetCalMonFreqTxPowLimitConfig(double FreqLimitLowTx0, double FreqLimitLowTx1, double FreqLimitLowTx2, double FreqLimitHighTx0, double FreqLimitHighTx1, double FreqLimitHighTx2, double Tx0PowerBackoff, double Tx1PowerBackoff, double Tx2PowerBackoff)
		{
			return m_GuiManager.ScriptOps.UpdateNSetCalMonFreqTxPowLimitConfData(1, FreqLimitLowTx0, FreqLimitLowTx1, FreqLimitLowTx2, FreqLimitHighTx0, FreqLimitHighTx1, FreqLimitHighTx2, Tx0PowerBackoff, Tx1PowerBackoff, Tx2PowerBackoff);
		}

		[AttrLuaFunc("RfSetCalMonFreqTxPowLimitConfig_mult", " RfSetCalMonFreqTxPowLimitConfig API which sets the limits for RF frequency transmission for each TX and also Tx power limits", new string[]
		{
			"Radar Device Id",
			"Tx0 Frequency limit low in MHz",
			"Tx1 Frequency limit low MHz",
			"Tx2 Frequency limit low MHz",
			"Tx0 Frequency limit high in MHz",
			"Tx1 Frequency limit high in MHz",
			"Tx2 Frequency limit high in MHz",
			"Tx0 output power backoff in dB",
			"Tx1 output power backoff in dB",
			"Tx2 output power backoff in dB"
		})]
		public int RfSetCalMonFreqTxPowLimitConfig(ushort RadarDeviceId, double FreqLimitLowTx0, double FreqLimitLowTx1, double FreqLimitLowTx2, double FreqLimitHighTx0, double FreqLimitHighTx1, double FreqLimitHighTx2, double Tx0PowerBackoff, double Tx1PowerBackoff, double Tx2PowerBackoff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetCalMonFreqTxPowLimitConfData(RadarDeviceId, FreqLimitLowTx0, FreqLimitLowTx1, FreqLimitLowTx2, FreqLimitHighTx0, FreqLimitHighTx1, FreqLimitHighTx2, Tx0PowerBackoff, Tx1PowerBackoff, Tx2PowerBackoff);
		}

		[AttrLuaFunc("SetRfRxSigImgMonConfig", " SetRfRxSigImgMonConfig API which defines containing information related to signal and image band energy", new string[]
		{
			"Profile Index for which this monitoring config applies",
			"Number of slices to monitor",
			"Number of samples constituting each time slice"
		})]
		public int SetRfRxSigImgMonConfig(char ProfileIndex, short SigImGMonPriTimeSliceNumSamples, char SigImGMonNumSlices)
		{
			return m_GuiManager.ScriptOps.UpdateNSetRxSignalAndImgageBandEnergyMonConfData(1, ProfileIndex, SigImGMonPriTimeSliceNumSamples, SigImGMonNumSlices);
		}

		[AttrLuaFunc("SetRfRxSigImgMonConfig_mult", " SetRfRxSigImgMonConfig API which defines containing information related to signal and image band energy", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring config applies",
			"Number of slices to monitor",
			"Number of samples constituting each time slice"
		})]
		public int SetRfRxSigImgMonConfig(ushort RadarDeviceId, char ProfileIndex, short SigImGMonPriTimeSliceNumSamples, char SigImGMonNumSlices)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetRxSignalAndImgageBandEnergyMonConfData(RadarDeviceId, ProfileIndex, SigImGMonPriTimeSliceNumSamples, SigImGMonNumSlices);
		}

		[AttrLuaFunc("SetRfRxIfSatMonConfig", " SetRfRxIfSatMonConfig API which defines containing information related to RX saturation detector monitoring ", new string[]
		{
			"Profile Index for which this monitoring config applies",
			"Saturation monitoring select, 1: ADC Mon, 3: ADC and IFA1 mon",
			"Reserved1",
			"Reserved2",
			"saturation monitoring primary time slice duration in us (1 LSB = 0.16 us)",
			"Number of (primary + secondary)time slices to monitor",
			"saturation monitoring Rx channel mask if saturation mon mode is set",
			"Reserved3",
			"Reserved4",
			"Reserved5",
			"Reserved6",
			"Reserved7"
		})]
		public int SetRfRxIfSatMonConfig(byte ProfileIndex, byte SatMonSelect, byte Reserved1, byte Reserved2, double SatMonPrimaryTimeSliceDuration, short SatMonNumSlices, byte SatMonRxChannelMask, byte Reserved3, byte Reserved4, byte Reserved5, uint Reserved6, uint Reserved7)
		{
			return m_GuiManager.ScriptOps.UpdateNSetRxIfSatMonConfData(1, ProfileIndex, SatMonSelect, Reserved1, Reserved2, SatMonPrimaryTimeSliceDuration, SatMonNumSlices, SatMonRxChannelMask, Reserved3, Reserved4, Reserved5, Reserved6, Reserved7);
		}

		[AttrLuaFunc("SetRfRxIfSatMonConfig_mult", " SetRfRxIfSatMonConfig API which defines containing information related to RX saturation detector monitoring ", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"Saturation monitoring select, 1: ADC Mon, 2: IFA1 mon, 3: ADC and IFA1 mon",
			"Reserved1",
			"Reserved2",
			"saturation monitoring primary time slice duration in us (1 LSB = 0.16 us)",
			"Number of (primary + secondary)time slices to monitor",
			"saturation monitoring Rx channel mask if saturation mon mode is set",
			"Reserved3",
			"Reserved4",
			"Reserved5",
			"Reserved6",
			"Reserved7"
		})]
		public int SetRfRxIfSatMonConfig(ushort RadarDeviceId, byte ProfileIndex, byte SatMonSelect, byte Reserved1, byte Reserved2, double SatMonPrimaryTimeSliceDuration, short SatMonNumSlices, byte SatMonRxChannelMask, byte Reserved3, byte Reserved4, byte Reserved5, uint Reserved6, uint Reserved7)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetRxIfSatMonConfData(RadarDeviceId, ProfileIndex, SatMonSelect, Reserved1, Reserved2, SatMonPrimaryTimeSliceDuration, SatMonNumSlices, SatMonRxChannelMask, Reserved3, Reserved4, Reserved5, Reserved6, Reserved7);
		}

		[AttrLuaFunc("TxGainTempLutSet", " TxGainTempLutSet API used to overwrite the TX gain temperature LUT used in firmware", new string[]
		{
			"Profile Index for which this monitoring config applies",
			"Tx1GainCodeTempLessThanNeg30",
			"Tx1GainCodeTempNeg30ToNeg20",
			"Tx1GainCodeTempNeg20ToNeg10",
			"Tx1GainCodeTempNeg10To0",
			"Tx1GainCodeTemp0To10",
			"Tx1GainCodeTemp10To20",
			"Tx1GainCodeTemp20To30",
			"Tx1GainCodeTemp30To40",
			"Tx1GainCodeTemp40To50",
			"Tx1GainCodeTemp50To60",
			"Tx1GainCodeTemp60To70",
			"Tx1GainCodeTemp70To80",
			"Tx1GainCodeTemp80To90",
			"Tx1GainCodeTemp90To100",
			"Tx1GainCodeTemp100To110",
			"Tx1GainCodeTemp110To120",
			"Tx1GainCodeTemp120To130",
			"Tx1GainCodeTemp130To140",
			"Tx1GainCodeTempMoreThan140",
			"Tx2GainCodeTempLessThanNeg30",
			"Tx2GainCodeTempNeg30ToNeg20",
			"Tx2GainCodeTempNeg20ToNeg10",
			"Tx2GainCodeTempNeg10To0",
			"Tx2GainCodeTemp0To10",
			"Tx2GainCodeTemp10To20",
			"Tx2GainCodeTemp20To30",
			"Tx2GainCodeTemp30To40",
			"Tx2GainCodeTemp40To50",
			"Tx2GainCodeTemp50To60",
			"Tx2GainCodeTemp60To70",
			"Tx2GainCodeTemp70To80",
			"Tx2GainCodeTemp80To90",
			"Tx2GainCodeTemp90To100",
			"Tx2GainCodeTemp100To110",
			"Tx2GainCodeTemp110To120",
			"Tx2GainCodeTemp120To130",
			"Tx2GainCodeTemp130To140",
			"Tx2GainCodeTempMoreThan140",
			"Tx3GainCodeTempLessThanNeg30",
			"Tx3GainCodeTempNeg30ToNeg20",
			"Tx3GainCodeTempNeg20ToNeg10",
			"Tx3GainCodeTempNeg10To0",
			"Tx3GainCodeTemp0To10",
			"Tx3GainCodeTemp10To20",
			"Tx3GainCodeTemp20To30",
			"Tx3GainCodeTemp30To40",
			"Tx3GainCodeTemp40To50",
			"Tx3GainCodeTemp50To60",
			"Tx3GainCodeTemp60To70",
			"Tx3GainCodeTemp70To80",
			"Tx3GainCodeTemp80To90",
			"Tx3GainCodeTemp90To100",
			"Tx3GainCodeTemp100To110",
			"Tx3GainCodeTemp110To120",
			"Tx3GainCodeTemp120To130",
			"Tx3GainCodeTemp130To140",
			"Tx3GainCodeTempMoreThan140"
		})]
		public int TxGainTempLutSet(char ProfileIndex, char Tx1GainCodeTempLessThanNeg30, char Tx1GainCodeTempNeg30ToNeg20, char Tx1GainCodeTempNeg20ToNeg10, char Tx1GainCodeTempNeg10To0, char Tx1GainCodeTemp0To10, char Tx1GainCodeTemp10To20, char Tx1GainCodeTemp20To30, char Tx1GainCodeTemp30To40, char Tx1GainCodeTemp40To50, char Tx1GainCodeTemp50To60, char Tx1GainCodeTemp60To70, char Tx1GainCodeTemp70To80, char Tx1GainCodeTemp80To90, char Tx1GainCodeTemp90To100, char Tx1GainCodeTemp100To110, char Tx1GainCodeTemp110To120, char Tx1GainCodeTemp120To130, char Tx1GainCodeTemp130To140, char Tx1GainCodeTempMoreThan140, char Tx2GainCodeTempLessThanNeg30, char Tx2GainCodeTempNeg30ToNeg20, char Tx2GainCodeTempNeg20ToNeg10, char Tx2GainCodeTempNeg10To0, char Tx2GainCodeTemp0To10, char Tx2GainCodeTemp10To20, char Tx2GainCodeTemp20To30, char Tx2GainCodeTemp30To40, char Tx2GainCodeTemp40To50, char Tx2GainCodeTemp50To60, char Tx2GainCodeTemp60To70, char Tx2GainCodeTemp70To80, char Tx2GainCodeTemp80To90, char Tx2GainCodeTemp90To100, char Tx2GainCodeTemp100To110, char Tx2GainCodeTemp110To120, char Tx2GainCodeTemp120To130, char Tx2GainCodeTemp130To140, char Tx2GainCodeTempMoreThan140, char Tx3GainCodeTempLessThanNeg30, char Tx3GainCodeTempNeg30ToNeg20, char Tx3GainCodeTempNeg20ToNeg10, char Tx3GainCodeTempNeg10To0, char Tx3GainCodeTemp0To10, char Tx3GainCodeTemp10To20, char Tx3GainCodeTemp20To30, char Tx3GainCodeTemp30To40, char Tx3GainCodeTemp40To50, char Tx3GainCodeTemp50To60, char Tx3GainCodeTemp60To70, char Tx3GainCodeTemp70To80, char Tx3GainCodeTemp80To90, char Tx3GainCodeTemp90To100, char Tx3GainCodeTemp100To110, char Tx3GainCodeTemp110To120, char Tx3GainCodeTemp120To130, char Tx3GainCodeTemp130To140, char Tx3GainCodeTempMoreThan140)
		{
			return m_GuiManager.ScriptOps.UpdateNTxGainTempLUTSetConfData(1, ProfileIndex, Tx1GainCodeTempLessThanNeg30, Tx1GainCodeTempNeg30ToNeg20, Tx1GainCodeTempNeg20ToNeg10, Tx1GainCodeTempNeg10To0, Tx1GainCodeTemp0To10, Tx1GainCodeTemp10To20, Tx1GainCodeTemp20To30, Tx1GainCodeTemp30To40, Tx1GainCodeTemp40To50, Tx1GainCodeTemp50To60, Tx1GainCodeTemp60To70, Tx1GainCodeTemp70To80, Tx1GainCodeTemp80To90, Tx1GainCodeTemp90To100, Tx1GainCodeTemp100To110, Tx1GainCodeTemp110To120, Tx1GainCodeTemp120To130, Tx1GainCodeTemp130To140, Tx1GainCodeTempMoreThan140, Tx2GainCodeTempLessThanNeg30, Tx2GainCodeTempNeg30ToNeg20, Tx2GainCodeTempNeg20ToNeg10, Tx2GainCodeTempNeg10To0, Tx2GainCodeTemp0To10, Tx2GainCodeTemp10To20, Tx2GainCodeTemp20To30, Tx2GainCodeTemp30To40, Tx2GainCodeTemp40To50, Tx2GainCodeTemp50To60, Tx2GainCodeTemp60To70, Tx2GainCodeTemp70To80, Tx2GainCodeTemp80To90, Tx2GainCodeTemp90To100, Tx2GainCodeTemp100To110, Tx2GainCodeTemp110To120, Tx2GainCodeTemp120To130, Tx2GainCodeTemp130To140, Tx2GainCodeTempMoreThan140, Tx3GainCodeTempLessThanNeg30, Tx3GainCodeTempNeg30ToNeg20, Tx3GainCodeTempNeg20ToNeg10, Tx3GainCodeTempNeg10To0, Tx3GainCodeTemp0To10, Tx3GainCodeTemp10To20, Tx3GainCodeTemp20To30, Tx3GainCodeTemp30To40, Tx3GainCodeTemp40To50, Tx3GainCodeTemp50To60, Tx3GainCodeTemp60To70, Tx3GainCodeTemp70To80, Tx3GainCodeTemp80To90, Tx3GainCodeTemp90To100, Tx3GainCodeTemp100To110, Tx3GainCodeTemp110To120, Tx3GainCodeTemp120To130, Tx3GainCodeTemp130To140, Tx3GainCodeTempMoreThan140);
		}

		[AttrLuaFunc("TxGainTempLutSet_mult", " TxGainTempLutSet API used to overwrite the TX gain temperature LUT used in firmware", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring config applies",
			"Tx1GainCodeTempLessThanNeg30",
			"Tx1GainCodeTempNeg30ToNeg20",
			"Tx1GainCodeTempNeg20ToNeg10",
			"Tx1GainCodeTempNeg10To0",
			"Tx1GainCodeTemp0To10",
			"Tx1GainCodeTemp10To20",
			"Tx1GainCodeTemp20To30",
			"Tx1GainCodeTemp30To40",
			"Tx1GainCodeTemp40To50",
			"Tx1GainCodeTemp50To60",
			"Tx1GainCodeTemp60To70",
			"Tx1GainCodeTemp70To80",
			"Tx1GainCodeTemp80To90",
			"Tx1GainCodeTemp90To100",
			"Tx1GainCodeTemp100To110",
			"Tx1GainCodeTemp110To120",
			"Tx1GainCodeTemp120To130",
			"Tx1GainCodeTemp130To140",
			"Tx1GainCodeTempMoreThan140",
			"Tx2GainCodeTempLessThanNeg30",
			"Tx2GainCodeTempNeg30ToNeg20",
			"Tx2GainCodeTempNeg20ToNeg10",
			"Tx2GainCodeTempNeg10To0",
			"Tx2GainCodeTemp0To10",
			"Tx2GainCodeTemp10To20",
			"Tx2GainCodeTemp20To30",
			"Tx2GainCodeTemp30To40",
			"Tx2GainCodeTemp40To50",
			"Tx2GainCodeTemp50To60",
			"Tx2GainCodeTemp60To70",
			"Tx2GainCodeTemp70To80",
			"Tx2GainCodeTemp80To90",
			"Tx2GainCodeTemp90To100",
			"Tx2GainCodeTemp100To110",
			"Tx2GainCodeTemp110To120",
			"Tx2GainCodeTemp120To130",
			"Tx2GainCodeTemp130To140",
			"Tx2GainCodeTempMoreThan140",
			"Tx3GainCodeTempLessThanNeg30",
			"Tx3GainCodeTempNeg30ToNeg20",
			"Tx3GainCodeTempNeg20ToNeg10",
			"Tx3GainCodeTempNeg10To0",
			"Tx3GainCodeTemp0To10",
			"Tx3GainCodeTemp10To20",
			"Tx3GainCodeTemp20To30",
			"Tx3GainCodeTemp30To40",
			"Tx3GainCodeTemp40To50",
			"Tx3GainCodeTemp50To60",
			"Tx3GainCodeTemp60To70",
			"Tx3GainCodeTemp70To80",
			"Tx3GainCodeTemp80To90",
			"Tx3GainCodeTemp90To100",
			"Tx3GainCodeTemp100To110",
			"Tx3GainCodeTemp110To120",
			"Tx3GainCodeTemp120To130",
			"Tx3GainCodeTemp130To140",
			"Tx3GainCodeTempMoreThan140"
		})]
		public int TxGainTempLutSet(ushort RadarDeviceId, char ProfileIndex, char Tx1GainCodeTempLessThanNeg30, char Tx1GainCodeTempNeg30ToNeg20, char Tx1GainCodeTempNeg20ToNeg10, char Tx1GainCodeTempNeg10To0, char Tx1GainCodeTemp0To10, char Tx1GainCodeTemp10To20, char Tx1GainCodeTemp20To30, char Tx1GainCodeTemp30To40, char Tx1GainCodeTemp40To50, char Tx1GainCodeTemp50To60, char Tx1GainCodeTemp60To70, char Tx1GainCodeTemp70To80, char Tx1GainCodeTemp80To90, char Tx1GainCodeTemp90To100, char Tx1GainCodeTemp100To110, char Tx1GainCodeTemp110To120, char Tx1GainCodeTemp120To130, char Tx1GainCodeTemp130To140, char Tx1GainCodeTempMoreThan140, char Tx2GainCodeTempLessThanNeg30, char Tx2GainCodeTempNeg30ToNeg20, char Tx2GainCodeTempNeg20ToNeg10, char Tx2GainCodeTempNeg10To0, char Tx2GainCodeTemp0To10, char Tx2GainCodeTemp10To20, char Tx2GainCodeTemp20To30, char Tx2GainCodeTemp30To40, char Tx2GainCodeTemp40To50, char Tx2GainCodeTemp50To60, char Tx2GainCodeTemp60To70, char Tx2GainCodeTemp70To80, char Tx2GainCodeTemp80To90, char Tx2GainCodeTemp90To100, char Tx2GainCodeTemp100To110, char Tx2GainCodeTemp110To120, char Tx2GainCodeTemp120To130, char Tx2GainCodeTemp130To140, char Tx2GainCodeTempMoreThan140, char Tx3GainCodeTempLessThanNeg30, char Tx3GainCodeTempNeg30ToNeg20, char Tx3GainCodeTempNeg20ToNeg10, char Tx3GainCodeTempNeg10To0, char Tx3GainCodeTemp0To10, char Tx3GainCodeTemp10To20, char Tx3GainCodeTemp20To30, char Tx3GainCodeTemp30To40, char Tx3GainCodeTemp40To50, char Tx3GainCodeTemp50To60, char Tx3GainCodeTemp60To70, char Tx3GainCodeTemp70To80, char Tx3GainCodeTemp80To90, char Tx3GainCodeTemp90To100, char Tx3GainCodeTemp100To110, char Tx3GainCodeTemp110To120, char Tx3GainCodeTemp120To130, char Tx3GainCodeTemp130To140, char Tx3GainCodeTempMoreThan140)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNTxGainTempLUTSetConfData(RadarDeviceId, ProfileIndex, Tx1GainCodeTempLessThanNeg30, Tx1GainCodeTempNeg30ToNeg20, Tx1GainCodeTempNeg20ToNeg10, Tx1GainCodeTempNeg10To0, Tx1GainCodeTemp0To10, Tx1GainCodeTemp10To20, Tx1GainCodeTemp20To30, Tx1GainCodeTemp30To40, Tx1GainCodeTemp40To50, Tx1GainCodeTemp50To60, Tx1GainCodeTemp60To70, Tx1GainCodeTemp70To80, Tx1GainCodeTemp80To90, Tx1GainCodeTemp90To100, Tx1GainCodeTemp100To110, Tx1GainCodeTemp110To120, Tx1GainCodeTemp120To130, Tx1GainCodeTemp130To140, Tx1GainCodeTempMoreThan140, Tx2GainCodeTempLessThanNeg30, Tx2GainCodeTempNeg30ToNeg20, Tx2GainCodeTempNeg20ToNeg10, Tx2GainCodeTempNeg10To0, Tx2GainCodeTemp0To10, Tx2GainCodeTemp10To20, Tx2GainCodeTemp20To30, Tx2GainCodeTemp30To40, Tx2GainCodeTemp40To50, Tx2GainCodeTemp50To60, Tx2GainCodeTemp60To70, Tx2GainCodeTemp70To80, Tx2GainCodeTemp80To90, Tx2GainCodeTemp90To100, Tx2GainCodeTemp100To110, Tx2GainCodeTemp110To120, Tx2GainCodeTemp120To130, Tx2GainCodeTemp130To140, Tx2GainCodeTempMoreThan140, Tx3GainCodeTempLessThanNeg30, Tx3GainCodeTempNeg30ToNeg20, Tx3GainCodeTempNeg20ToNeg10, Tx3GainCodeTempNeg10To0, Tx3GainCodeTemp0To10, Tx3GainCodeTemp10To20, Tx3GainCodeTemp20To30, Tx3GainCodeTemp30To40, Tx3GainCodeTemp40To50, Tx3GainCodeTemp50To60, Tx3GainCodeTemp60To70, Tx3GainCodeTemp70To80, Tx3GainCodeTemp80To90, Tx3GainCodeTemp90To100, Tx3GainCodeTemp100To110, Tx3GainCodeTemp110To120, Tx3GainCodeTemp120To130, Tx3GainCodeTemp130To140, Tx3GainCodeTempMoreThan140);
		}

		[AttrLuaFunc("TxGainTempLutGet", " TxGainTempLutGet API used to read the TX gain temperature LUT used by the firmware", new string[]
		{
			"Profile Index for which this monitoring config applies",
			"out profileIndex",
			"out Tx1GainCodeTempLessThanNeg30",
			"out Tx1GainCodeTempNeg30ToNeg20",
			"out Tx1GainCodeTempNeg20ToNeg10",
			"out Tx1GainCodeTempNeg10To0",
			"out Tx1GainCodeTemp0To10",
			"out Tx1GainCodeTemp10To20",
			"out Tx1GainCodeTemp20To30",
			"out Tx1GainCodeTemp30To40",
			"out Tx1GainCodeTemp40To50",
			"out Tx1GainCodeTemp50To60",
			"out Tx1GainCodeTemp60To70",
			"out Tx1GainCodeTemp70To80",
			"out Tx1GainCodeTemp80To90",
			"out Tx1GainCodeTemp90To100",
			"out Tx1GainCodeTemp100To110",
			"out Tx1GainCodeTemp110To120",
			"out Tx1GainCodeTemp120To130",
			"out Tx1GainCodeTemp130To140",
			"out Tx1GainCodeTempMoreThan140",
			"out Tx2GainCodeTempLessThanNeg30",
			"out Tx2GainCodeTempNeg30ToNeg20",
			"out Tx2GainCodeTempNeg20ToNeg10",
			"out Tx2GainCodeTempNeg10To0",
			"out Tx2GainCodeTemp0To10",
			"out Tx2GainCodeTemp10To20",
			"out Tx2GainCodeTemp20To30",
			"out Tx2GainCodeTemp30To40",
			"out Tx2GainCodeTemp40To50",
			"out Tx2GainCodeTemp50To60",
			"out Tx2GainCodeTemp60To70",
			"out Tx2GainCodeTemp70To80",
			"out Tx2GainCodeTemp80To90",
			"out Tx2GainCodeTemp90To100",
			"out Tx2GainCodeTemp100To110",
			"out Tx2GainCodeTemp110To120",
			"out Tx2GainCodeTemp120To130",
			"out Tx2GainCodeTemp130To140",
			"out Tx2GainCodeTempMoreThan140",
			"out Tx3GainCodeTempLessThanNeg30",
			"out Tx3GainCodeTempNeg30ToNeg20",
			"out Tx3GainCodeTempNeg20ToNeg10",
			"out Tx3GainCodeTempNeg10To0",
			"out Tx3GainCodeTemp0To10",
			"out Tx3GainCodeTemp10To20",
			"out Tx3GainCodeTemp20To30",
			"out Tx3GainCodeTemp30To40",
			"out Tx3GainCodeTemp40To50",
			"out Tx3GainCodeTemp50To60",
			"out Tx3GainCodeTemp60To70",
			"out Tx3GainCodeTemp70To80",
			"out Tx3GainCodeTemp80To90",
			"out Tx3GainCodeTemp90To100",
			"out Tx3GainCodeTemp100To110",
			"out Tx3GainCodeTemp110To120",
			"out Tx3GainCodeTemp120To130",
			"out Tx3GainCodeTemp130To140",
			"out Tx3GainCodeTempMoreThan140"
		})]
		public int TxGainTempLutGet(char ProfileIndex, out string profileIndex, out string Tx1GainCodeTempLessThanNeg30, out string Tx1GainCodeTempNeg30ToNeg20, out string Tx1GainCodeTempNeg20ToNeg10, out string Tx1GainCodeTempNeg10To0, out string Tx1GainCodeTemp0To10, out string Tx1GainCodeTemp10To20, out string Tx1GainCodeTemp20To30, out string Tx1GainCodeTemp30To40, out string Tx1GainCodeTemp40To50, out string Tx1GainCodeTemp50To60, out string Tx1GainCodeTemp60To70, out string Tx1GainCodeTemp70To80, out string Tx1GainCodeTemp80To90, out string Tx1GainCodeTemp90To100, out string Tx1GainCodeTemp100To110, out string Tx1GainCodeTemp110To120, out string Tx1GainCodeTemp120To130, out string Tx1GainCodeTemp130To140, out string Tx1GainCodeTempMoreThan140, out string Tx2GainCodeTempLessThanNeg30, out string Tx2GainCodeTempNeg30ToNeg20, out string Tx2GainCodeTempNeg20ToNeg10, out string Tx2GainCodeTempNeg10To0, out string Tx2GainCodeTemp0To10, out string Tx2GainCodeTemp10To20, out string Tx2GainCodeTemp20To30, out string Tx2GainCodeTemp30To40, out string Tx2GainCodeTemp40To50, out string Tx2GainCodeTemp50To60, out string Tx2GainCodeTemp60To70, out string Tx2GainCodeTemp70To80, out string Tx2GainCodeTemp80To90, out string Tx2GainCodeTemp90To100, out string Tx2GainCodeTemp100To110, out string Tx2GainCodeTemp110To120, out string Tx2GainCodeTemp120To130, out string Tx2GainCodeTemp130To140, out string Tx2GainCodeTempMoreThan140, out string Tx3GainCodeTempLessThanNeg30, out string Tx3GainCodeTempNeg30ToNeg20, out string Tx3GainCodeTempNeg20ToNeg10, out string Tx3GainCodeTempNeg10To0, out string Tx3GainCodeTemp0To10, out string Tx3GainCodeTemp10To20, out string Tx3GainCodeTemp20To30, out string Tx3GainCodeTemp30To40, out string Tx3GainCodeTemp40To50, out string Tx3GainCodeTemp50To60, out string Tx3GainCodeTemp60To70, out string Tx3GainCodeTemp70To80, out string Tx3GainCodeTemp80To90, out string Tx3GainCodeTemp90To100, out string Tx3GainCodeTemp100To110, out string Tx3GainCodeTemp110To120, out string Tx3GainCodeTemp120To130, out string Tx3GainCodeTemp130To140, out string Tx3GainCodeTempMoreThan140)
		{
			profileIndex = string.Empty;
			Tx1GainCodeTempLessThanNeg30 = string.Empty;
			Tx1GainCodeTempNeg30ToNeg20 = string.Empty;
			Tx1GainCodeTempNeg20ToNeg10 = string.Empty;
			Tx1GainCodeTempNeg10To0 = string.Empty;
			Tx1GainCodeTemp0To10 = string.Empty;
			Tx1GainCodeTemp10To20 = string.Empty;
			Tx1GainCodeTemp20To30 = string.Empty;
			Tx1GainCodeTemp30To40 = string.Empty;
			Tx1GainCodeTemp40To50 = string.Empty;
			Tx1GainCodeTemp50To60 = string.Empty;
			Tx1GainCodeTemp60To70 = string.Empty;
			Tx1GainCodeTemp70To80 = string.Empty;
			Tx1GainCodeTemp80To90 = string.Empty;
			Tx1GainCodeTemp90To100 = string.Empty;
			Tx1GainCodeTemp100To110 = string.Empty;
			Tx1GainCodeTemp110To120 = string.Empty;
			Tx1GainCodeTemp120To130 = string.Empty;
			Tx1GainCodeTemp130To140 = string.Empty;
			Tx1GainCodeTempMoreThan140 = string.Empty;
			Tx2GainCodeTempLessThanNeg30 = string.Empty;
			Tx2GainCodeTempNeg30ToNeg20 = string.Empty;
			Tx2GainCodeTempNeg20ToNeg10 = string.Empty;
			Tx2GainCodeTempNeg10To0 = string.Empty;
			Tx2GainCodeTemp0To10 = string.Empty;
			Tx2GainCodeTemp10To20 = string.Empty;
			Tx2GainCodeTemp20To30 = string.Empty;
			Tx2GainCodeTemp30To40 = string.Empty;
			Tx2GainCodeTemp40To50 = string.Empty;
			Tx2GainCodeTemp50To60 = string.Empty;
			Tx2GainCodeTemp60To70 = string.Empty;
			Tx2GainCodeTemp70To80 = string.Empty;
			Tx2GainCodeTemp80To90 = string.Empty;
			Tx2GainCodeTemp90To100 = string.Empty;
			Tx2GainCodeTemp100To110 = string.Empty;
			Tx2GainCodeTemp110To120 = string.Empty;
			Tx2GainCodeTemp120To130 = string.Empty;
			Tx2GainCodeTemp130To140 = string.Empty;
			Tx2GainCodeTempMoreThan140 = string.Empty;
			Tx3GainCodeTempLessThanNeg30 = string.Empty;
			Tx3GainCodeTempNeg30ToNeg20 = string.Empty;
			Tx3GainCodeTempNeg20ToNeg10 = string.Empty;
			Tx3GainCodeTempNeg10To0 = string.Empty;
			Tx3GainCodeTemp0To10 = string.Empty;
			Tx3GainCodeTemp10To20 = string.Empty;
			Tx3GainCodeTemp20To30 = string.Empty;
			Tx3GainCodeTemp30To40 = string.Empty;
			Tx3GainCodeTemp40To50 = string.Empty;
			Tx3GainCodeTemp50To60 = string.Empty;
			Tx3GainCodeTemp60To70 = string.Empty;
			Tx3GainCodeTemp70To80 = string.Empty;
			Tx3GainCodeTemp80To90 = string.Empty;
			Tx3GainCodeTemp90To100 = string.Empty;
			Tx3GainCodeTemp100To110 = string.Empty;
			Tx3GainCodeTemp110To120 = string.Empty;
			Tx3GainCodeTemp120To130 = string.Empty;
			Tx3GainCodeTemp130To140 = string.Empty;
			Tx3GainCodeTempMoreThan140 = string.Empty;
			m_GuiManager.ScriptOps.UpdateNTxGainTempLUTGetConfData(1, ProfileIndex);
			return m_GuiManager.ScriptOps.UpdateNTxGainTempLUTGetConfData_cmd(out profileIndex, out Tx1GainCodeTempLessThanNeg30, out Tx1GainCodeTempNeg30ToNeg20, out Tx1GainCodeTempNeg20ToNeg10, out Tx1GainCodeTempNeg10To0, out Tx1GainCodeTemp0To10, out Tx1GainCodeTemp10To20, out Tx1GainCodeTemp20To30, out Tx1GainCodeTemp30To40, out Tx1GainCodeTemp40To50, out Tx1GainCodeTemp50To60, out Tx1GainCodeTemp60To70, out Tx1GainCodeTemp70To80, out Tx1GainCodeTemp80To90, out Tx1GainCodeTemp90To100, out Tx1GainCodeTemp100To110, out Tx1GainCodeTemp110To120, out Tx1GainCodeTemp120To130, out Tx1GainCodeTemp130To140, out Tx1GainCodeTempMoreThan140, out Tx2GainCodeTempLessThanNeg30, out Tx2GainCodeTempNeg30ToNeg20, out Tx2GainCodeTempNeg20ToNeg10, out Tx2GainCodeTempNeg10To0, out Tx2GainCodeTemp0To10, out Tx2GainCodeTemp10To20, out Tx2GainCodeTemp20To30, out Tx2GainCodeTemp30To40, out Tx2GainCodeTemp40To50, out Tx2GainCodeTemp50To60, out Tx2GainCodeTemp60To70, out Tx2GainCodeTemp70To80, out Tx2GainCodeTemp80To90, out Tx2GainCodeTemp90To100, out Tx2GainCodeTemp100To110, out Tx2GainCodeTemp110To120, out Tx2GainCodeTemp120To130, out Tx2GainCodeTemp130To140, out Tx2GainCodeTempMoreThan140, out Tx3GainCodeTempLessThanNeg30, out Tx3GainCodeTempNeg30ToNeg20, out Tx3GainCodeTempNeg20ToNeg10, out Tx3GainCodeTempNeg10To0, out Tx3GainCodeTemp0To10, out Tx3GainCodeTemp10To20, out Tx3GainCodeTemp20To30, out Tx3GainCodeTemp30To40, out Tx3GainCodeTemp40To50, out Tx3GainCodeTemp50To60, out Tx3GainCodeTemp60To70, out Tx3GainCodeTemp70To80, out Tx3GainCodeTemp80To90, out Tx3GainCodeTemp90To100, out Tx3GainCodeTemp100To110, out Tx3GainCodeTemp110To120, out Tx3GainCodeTemp120To130, out Tx3GainCodeTemp130To140, out Tx3GainCodeTempMoreThan140);
		}

		[AttrLuaFunc("TxGainTempLutGet_mult", " TxGainTempLutGet API used to read the TX gain temperature LUT used by the firmware", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring config applies",
			"out profileIndex",
			"out Tx1GainCodeTempLessThanNeg30",
			"out Tx1GainCodeTempNeg30ToNeg20",
			"out Tx1GainCodeTempNeg20ToNeg10",
			"out Tx1GainCodeTempNeg10To0",
			"out Tx1GainCodeTemp0To10",
			"out Tx1GainCodeTemp10To20",
			"out Tx1GainCodeTemp20To30",
			"out Tx1GainCodeTemp30To40",
			"out Tx1GainCodeTemp40To50",
			"out Tx1GainCodeTemp50To60",
			"out Tx1GainCodeTemp60To70",
			"out Tx1GainCodeTemp70To80",
			"out Tx1GainCodeTemp80To90",
			"out Tx1GainCodeTemp90To100",
			"out Tx1GainCodeTemp100To110",
			"out Tx1GainCodeTemp110To120",
			"out Tx1GainCodeTemp120To130",
			"out Tx1GainCodeTemp130To140",
			"out Tx1GainCodeTempMoreThan140",
			"out Tx2GainCodeTempLessThanNeg30",
			"out Tx2GainCodeTempNeg30ToNeg20",
			"out Tx2GainCodeTempNeg20ToNeg10",
			"out Tx2GainCodeTempNeg10To0",
			"out Tx2GainCodeTemp0To10",
			"out Tx2GainCodeTemp10To20",
			"out Tx2GainCodeTemp20To30",
			"out Tx2GainCodeTemp30To40",
			"out Tx2GainCodeTemp40To50",
			"out Tx2GainCodeTemp50To60",
			"out Tx2GainCodeTemp60To70",
			"out Tx2GainCodeTemp70To80",
			"out Tx2GainCodeTemp80To90",
			"out Tx2GainCodeTemp90To100",
			"out Tx2GainCodeTemp100To110",
			"out Tx2GainCodeTemp110To120",
			"out Tx2GainCodeTemp120To130",
			"out Tx2GainCodeTemp130To140",
			"out Tx2GainCodeTempMoreThan140",
			"out Tx3GainCodeTempLessThanNeg30",
			"out Tx3GainCodeTempNeg30ToNeg20",
			"out Tx3GainCodeTempNeg20ToNeg10",
			"out Tx3GainCodeTempNeg10To0",
			"out Tx3GainCodeTemp0To10",
			"out Tx3GainCodeTemp10To20",
			"out Tx3GainCodeTemp20To30",
			"out Tx3GainCodeTemp30To40",
			"out Tx3GainCodeTemp40To50",
			"out Tx3GainCodeTemp50To60",
			"out Tx3GainCodeTemp60To70",
			"out Tx3GainCodeTemp70To80",
			"out Tx3GainCodeTemp80To90",
			"out Tx3GainCodeTemp90To100",
			"out Tx3GainCodeTemp100To110",
			"out Tx3GainCodeTemp110To120",
			"out Tx3GainCodeTemp120To130",
			"out Tx3GainCodeTemp130To140",
			"out Tx3GainCodeTempMoreThan140"
		})]
		public int TxGainTempLutGet(ushort RadarDeviceId, char ProfileIndex, out string profileIndex, out string Tx1GainCodeTempLessThanNeg30, out string Tx1GainCodeTempNeg30ToNeg20, out string Tx1GainCodeTempNeg20ToNeg10, out string Tx1GainCodeTempNeg10To0, out string Tx1GainCodeTemp0To10, out string Tx1GainCodeTemp10To20, out string Tx1GainCodeTemp20To30, out string Tx1GainCodeTemp30To40, out string Tx1GainCodeTemp40To50, out string Tx1GainCodeTemp50To60, out string Tx1GainCodeTemp60To70, out string Tx1GainCodeTemp70To80, out string Tx1GainCodeTemp80To90, out string Tx1GainCodeTemp90To100, out string Tx1GainCodeTemp100To110, out string Tx1GainCodeTemp110To120, out string Tx1GainCodeTemp120To130, out string Tx1GainCodeTemp130To140, out string Tx1GainCodeTempMoreThan140, out string Tx2GainCodeTempLessThanNeg30, out string Tx2GainCodeTempNeg30ToNeg20, out string Tx2GainCodeTempNeg20ToNeg10, out string Tx2GainCodeTempNeg10To0, out string Tx2GainCodeTemp0To10, out string Tx2GainCodeTemp10To20, out string Tx2GainCodeTemp20To30, out string Tx2GainCodeTemp30To40, out string Tx2GainCodeTemp40To50, out string Tx2GainCodeTemp50To60, out string Tx2GainCodeTemp60To70, out string Tx2GainCodeTemp70To80, out string Tx2GainCodeTemp80To90, out string Tx2GainCodeTemp90To100, out string Tx2GainCodeTemp100To110, out string Tx2GainCodeTemp110To120, out string Tx2GainCodeTemp120To130, out string Tx2GainCodeTemp130To140, out string Tx2GainCodeTempMoreThan140, out string Tx3GainCodeTempLessThanNeg30, out string Tx3GainCodeTempNeg30ToNeg20, out string Tx3GainCodeTempNeg20ToNeg10, out string Tx3GainCodeTempNeg10To0, out string Tx3GainCodeTemp0To10, out string Tx3GainCodeTemp10To20, out string Tx3GainCodeTemp20To30, out string Tx3GainCodeTemp30To40, out string Tx3GainCodeTemp40To50, out string Tx3GainCodeTemp50To60, out string Tx3GainCodeTemp60To70, out string Tx3GainCodeTemp70To80, out string Tx3GainCodeTemp80To90, out string Tx3GainCodeTemp90To100, out string Tx3GainCodeTemp100To110, out string Tx3GainCodeTemp110To120, out string Tx3GainCodeTemp120To130, out string Tx3GainCodeTemp130To140, out string Tx3GainCodeTempMoreThan140)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			profileIndex = string.Empty;
			Tx1GainCodeTempLessThanNeg30 = string.Empty;
			Tx1GainCodeTempNeg30ToNeg20 = string.Empty;
			Tx1GainCodeTempNeg20ToNeg10 = string.Empty;
			Tx1GainCodeTempNeg10To0 = string.Empty;
			Tx1GainCodeTemp0To10 = string.Empty;
			Tx1GainCodeTemp10To20 = string.Empty;
			Tx1GainCodeTemp20To30 = string.Empty;
			Tx1GainCodeTemp30To40 = string.Empty;
			Tx1GainCodeTemp40To50 = string.Empty;
			Tx1GainCodeTemp50To60 = string.Empty;
			Tx1GainCodeTemp60To70 = string.Empty;
			Tx1GainCodeTemp70To80 = string.Empty;
			Tx1GainCodeTemp80To90 = string.Empty;
			Tx1GainCodeTemp90To100 = string.Empty;
			Tx1GainCodeTemp100To110 = string.Empty;
			Tx1GainCodeTemp110To120 = string.Empty;
			Tx1GainCodeTemp120To130 = string.Empty;
			Tx1GainCodeTemp130To140 = string.Empty;
			Tx1GainCodeTempMoreThan140 = string.Empty;
			Tx2GainCodeTempLessThanNeg30 = string.Empty;
			Tx2GainCodeTempNeg30ToNeg20 = string.Empty;
			Tx2GainCodeTempNeg20ToNeg10 = string.Empty;
			Tx2GainCodeTempNeg10To0 = string.Empty;
			Tx2GainCodeTemp0To10 = string.Empty;
			Tx2GainCodeTemp10To20 = string.Empty;
			Tx2GainCodeTemp20To30 = string.Empty;
			Tx2GainCodeTemp30To40 = string.Empty;
			Tx2GainCodeTemp40To50 = string.Empty;
			Tx2GainCodeTemp50To60 = string.Empty;
			Tx2GainCodeTemp60To70 = string.Empty;
			Tx2GainCodeTemp70To80 = string.Empty;
			Tx2GainCodeTemp80To90 = string.Empty;
			Tx2GainCodeTemp90To100 = string.Empty;
			Tx2GainCodeTemp100To110 = string.Empty;
			Tx2GainCodeTemp110To120 = string.Empty;
			Tx2GainCodeTemp120To130 = string.Empty;
			Tx2GainCodeTemp130To140 = string.Empty;
			Tx2GainCodeTempMoreThan140 = string.Empty;
			Tx3GainCodeTempLessThanNeg30 = string.Empty;
			Tx3GainCodeTempNeg30ToNeg20 = string.Empty;
			Tx3GainCodeTempNeg20ToNeg10 = string.Empty;
			Tx3GainCodeTempNeg10To0 = string.Empty;
			Tx3GainCodeTemp0To10 = string.Empty;
			Tx3GainCodeTemp10To20 = string.Empty;
			Tx3GainCodeTemp20To30 = string.Empty;
			Tx3GainCodeTemp30To40 = string.Empty;
			Tx3GainCodeTemp40To50 = string.Empty;
			Tx3GainCodeTemp50To60 = string.Empty;
			Tx3GainCodeTemp60To70 = string.Empty;
			Tx3GainCodeTemp70To80 = string.Empty;
			Tx3GainCodeTemp80To90 = string.Empty;
			Tx3GainCodeTemp90To100 = string.Empty;
			Tx3GainCodeTemp100To110 = string.Empty;
			Tx3GainCodeTemp110To120 = string.Empty;
			Tx3GainCodeTemp120To130 = string.Empty;
			Tx3GainCodeTemp130To140 = string.Empty;
			Tx3GainCodeTempMoreThan140 = string.Empty;
			m_GuiManager.ScriptOps.UpdateNTxGainTempLUTGetConfData(RadarDeviceId, ProfileIndex);
			return m_GuiManager.ScriptOps.UpdateNTxGainTempLUTGetConfData_cmd(out profileIndex, out Tx1GainCodeTempLessThanNeg30, out Tx1GainCodeTempNeg30ToNeg20, out Tx1GainCodeTempNeg20ToNeg10, out Tx1GainCodeTempNeg10To0, out Tx1GainCodeTemp0To10, out Tx1GainCodeTemp10To20, out Tx1GainCodeTemp20To30, out Tx1GainCodeTemp30To40, out Tx1GainCodeTemp40To50, out Tx1GainCodeTemp50To60, out Tx1GainCodeTemp60To70, out Tx1GainCodeTemp70To80, out Tx1GainCodeTemp80To90, out Tx1GainCodeTemp90To100, out Tx1GainCodeTemp100To110, out Tx1GainCodeTemp110To120, out Tx1GainCodeTemp120To130, out Tx1GainCodeTemp130To140, out Tx1GainCodeTempMoreThan140, out Tx2GainCodeTempLessThanNeg30, out Tx2GainCodeTempNeg30ToNeg20, out Tx2GainCodeTempNeg20ToNeg10, out Tx2GainCodeTempNeg10To0, out Tx2GainCodeTemp0To10, out Tx2GainCodeTemp10To20, out Tx2GainCodeTemp20To30, out Tx2GainCodeTemp30To40, out Tx2GainCodeTemp40To50, out Tx2GainCodeTemp50To60, out Tx2GainCodeTemp60To70, out Tx2GainCodeTemp70To80, out Tx2GainCodeTemp80To90, out Tx2GainCodeTemp90To100, out Tx2GainCodeTemp100To110, out Tx2GainCodeTemp110To120, out Tx2GainCodeTemp120To130, out Tx2GainCodeTemp130To140, out Tx2GainCodeTempMoreThan140, out Tx3GainCodeTempLessThanNeg30, out Tx3GainCodeTempNeg30ToNeg20, out Tx3GainCodeTempNeg20ToNeg10, out Tx3GainCodeTempNeg10To0, out Tx3GainCodeTemp0To10, out Tx3GainCodeTemp10To20, out Tx3GainCodeTemp20To30, out Tx3GainCodeTemp30To40, out Tx3GainCodeTemp40To50, out Tx3GainCodeTemp50To60, out Tx3GainCodeTemp60To70, out Tx3GainCodeTemp70To80, out Tx3GainCodeTemp80To90, out Tx3GainCodeTemp90To100, out Tx3GainCodeTemp100To110, out Tx3GainCodeTemp110To120, out Tx3GainCodeTemp120To130, out Tx3GainCodeTemp130To140, out Tx3GainCodeTempMoreThan140);
		}

		[AttrLuaFunc("RxGainTempLutSet", " RxGainTempLutSet API used to overwrite the RX gain temperature LUT used in firmware", new string[]
		{
			"Profile Index for which this monitoring config applies",
			"Rx1GainCodeTempLessThanNeg30",
			"Rx1GainCodeTempNeg30ToNeg20",
			"Rx1GainCodeTempNeg20ToNeg10",
			"Rx1GainCodeTempNeg10To0",
			"Rx1GainCodeTemp0To10",
			"Rx1GainCodeTemp10To20",
			"Rx1GainCodeTemp20To30",
			"Rx1GainCodeTemp30To40",
			"Rx1GainCodeTemp40To50",
			"Rx1GainCodeTemp50To60",
			"Rx1GainCodeTemp60To70",
			"Rx1GainCodeTemp70To80",
			"Rx1GainCodeTemp80To90",
			"Rx1GainCodeTemp90To100",
			"Rx1GainCodeTemp100To110",
			"Rx1GainCodeTemp110To120",
			"Rx1GainCodeTemp120To130",
			"Rx1GainCodeTemp130To140",
			"Rx1GainCodeTempMoreThan140"
		})]
		public int RxGainTempLutSet(char ProfileIndex, char Rx1GainCodeTempLessThanNeg30, char Rx1GainCodeTempNeg30ToNeg20, char Rx1GainCodeTempNeg20ToNeg10, char Rx1GainCodeTempNeg10To0, char Rx1GainCodeTemp0To10, char Rx1GainCodeTemp10To20, char Rx1GainCodeTemp20To30, char Rx1GainCodeTemp30To40, char Rx1GainCodeTemp40To50, char Rx1GainCodeTemp50To60, char Rx1GainCodeTemp60To70, char Rx1GainCodeTemp70To80, char Rx1GainCodeTemp80To90, char Rx1GainCodeTemp90To100, char Rx1GainCodeTemp100To110, char Rx1GainCodeTemp110To120, char Rx1GainCodeTemp120To130, char Rx1GainCodeTemp130To140, char Rx1GainCodeTempMoreThan140)
		{
			return m_GuiManager.ScriptOps.UpdateNRxGainTempLUTSetConfData(1, ProfileIndex, Rx1GainCodeTempLessThanNeg30, Rx1GainCodeTempNeg30ToNeg20, Rx1GainCodeTempNeg20ToNeg10, Rx1GainCodeTempNeg10To0, Rx1GainCodeTemp0To10, Rx1GainCodeTemp10To20, Rx1GainCodeTemp20To30, Rx1GainCodeTemp30To40, Rx1GainCodeTemp40To50, Rx1GainCodeTemp50To60, Rx1GainCodeTemp60To70, Rx1GainCodeTemp70To80, Rx1GainCodeTemp80To90, Rx1GainCodeTemp90To100, Rx1GainCodeTemp100To110, Rx1GainCodeTemp110To120, Rx1GainCodeTemp120To130, Rx1GainCodeTemp130To140, Rx1GainCodeTempMoreThan140);
		}

		[AttrLuaFunc("RxGainTempLutSet_mult", " RxGainTempLutSet API used to overwrite the RX gain temperature LUT used in firmware", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring config applies",
			"Rx1GainCodeTempLessThanNeg30",
			"Rx1GainCodeTempNeg30ToNeg20",
			"Rx1GainCodeTempNeg20ToNeg10",
			"Rx1GainCodeTempNeg10To0",
			"Rx1GainCodeTemp0To10",
			"Rx1GainCodeTemp10To20",
			"Rx1GainCodeTemp20To30",
			"Rx1GainCodeTemp30To40",
			"Rx1GainCodeTemp40To50",
			"Rx1GainCodeTemp50To60",
			"Rx1GainCodeTemp60To70",
			"Rx1GainCodeTemp70To80",
			"Rx1GainCodeTemp80To90",
			"Rx1GainCodeTemp90To100",
			"Rx1GainCodeTemp100To110",
			"Rx1GainCodeTemp110To120",
			"Rx1GainCodeTemp120To130",
			"Rx1GainCodeTemp130To140",
			"Rx1GainCodeTempMoreThan140"
		})]
		public int RxGainTempLutSet(ushort RadarDeviceId, char ProfileIndex, char Rx1GainCodeTempLessThanNeg30, char Rx1GainCodeTempNeg30ToNeg20, char Rx1GainCodeTempNeg20ToNeg10, char Rx1GainCodeTempNeg10To0, char Rx1GainCodeTemp0To10, char Rx1GainCodeTemp10To20, char Rx1GainCodeTemp20To30, char Rx1GainCodeTemp30To40, char Rx1GainCodeTemp40To50, char Rx1GainCodeTemp50To60, char Rx1GainCodeTemp60To70, char Rx1GainCodeTemp70To80, char Rx1GainCodeTemp80To90, char Rx1GainCodeTemp90To100, char Rx1GainCodeTemp100To110, char Rx1GainCodeTemp110To120, char Rx1GainCodeTemp120To130, char Rx1GainCodeTemp130To140, char Rx1GainCodeTempMoreThan140)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNRxGainTempLUTSetConfData(RadarDeviceId, ProfileIndex, Rx1GainCodeTempLessThanNeg30, Rx1GainCodeTempNeg30ToNeg20, Rx1GainCodeTempNeg20ToNeg10, Rx1GainCodeTempNeg10To0, Rx1GainCodeTemp0To10, Rx1GainCodeTemp10To20, Rx1GainCodeTemp20To30, Rx1GainCodeTemp30To40, Rx1GainCodeTemp40To50, Rx1GainCodeTemp50To60, Rx1GainCodeTemp60To70, Rx1GainCodeTemp70To80, Rx1GainCodeTemp80To90, Rx1GainCodeTemp90To100, Rx1GainCodeTemp100To110, Rx1GainCodeTemp110To120, Rx1GainCodeTemp120To130, Rx1GainCodeTemp130To140, Rx1GainCodeTempMoreThan140);
		}

		[AttrLuaFunc("RxGainTempLutGet", " RxGainTempLutGet API used to read the RX gain temperature LUT used by the firmware", new string[]
		{
			"Profile Index for which this monitoring config applies",
			"out profileIndex",
			"out Rx1GainCodeTempLessThanNeg30",
			"out Rx1GainCodeTempNeg30ToNeg20",
			"out Rx1GainCodeTempNeg20ToNeg10",
			"out Rx1GainCodeTempNeg10To0",
			"out Rx1GainCodeTemp0To10",
			"out Rx1GainCodeTemp10To20",
			"out Rx1GainCodeTemp20To30",
			"out Rx1GainCodeTemp30To40",
			"out Rx1GainCodeTemp40To50",
			"out Rx1GainCodeTemp50To60",
			"out Rx1GainCodeTemp60To70",
			"out Rx1GainCodeTemp70To80",
			"out Rx1GainCodeTemp80To90",
			"out Rx1GainCodeTemp90To100",
			"out Rx1GainCodeTemp100To110",
			"out Rx1GainCodeTemp110To120",
			"out Rx1GainCodeTemp120To130",
			"out Rx1GainCodeTemp130To140",
			"out Rx1GainCodeTempMoreThan140"
		})]
		public int RxGainTempLutGet(char ProfileIndex, out string profileIndex, out string Rx1GainCodeTempLessThanNeg30, out string Rx1GainCodeTempNeg30ToNeg20, out string Rx1GainCodeTempNeg20ToNeg10, out string Rx1GainCodeTempNeg10To0, out string Rx1GainCodeTemp0To10, out string Rx1GainCodeTemp10To20, out string Rx1GainCodeTemp20To30, out string Rx1GainCodeTemp30To40, out string Rx1GainCodeTemp40To50, out string Rx1GainCodeTemp50To60, out string Rx1GainCodeTemp60To70, out string Rx1GainCodeTemp70To80, out string Rx1GainCodeTemp80To90, out string Rx1GainCodeTemp90To100, out string Rx1GainCodeTemp100To110, out string Rx1GainCodeTemp110To120, out string Rx1GainCodeTemp120To130, out string Rx1GainCodeTemp130To140, out string Rx1GainCodeTempMoreThan140)
		{
			profileIndex = string.Empty;
			Rx1GainCodeTempLessThanNeg30 = string.Empty;
			Rx1GainCodeTempNeg30ToNeg20 = string.Empty;
			Rx1GainCodeTempNeg20ToNeg10 = string.Empty;
			Rx1GainCodeTempNeg10To0 = string.Empty;
			Rx1GainCodeTemp0To10 = string.Empty;
			Rx1GainCodeTemp10To20 = string.Empty;
			Rx1GainCodeTemp20To30 = string.Empty;
			Rx1GainCodeTemp30To40 = string.Empty;
			Rx1GainCodeTemp40To50 = string.Empty;
			Rx1GainCodeTemp50To60 = string.Empty;
			Rx1GainCodeTemp60To70 = string.Empty;
			Rx1GainCodeTemp70To80 = string.Empty;
			Rx1GainCodeTemp80To90 = string.Empty;
			Rx1GainCodeTemp90To100 = string.Empty;
			Rx1GainCodeTemp100To110 = string.Empty;
			Rx1GainCodeTemp110To120 = string.Empty;
			Rx1GainCodeTemp120To130 = string.Empty;
			Rx1GainCodeTemp130To140 = string.Empty;
			Rx1GainCodeTempMoreThan140 = string.Empty;
			m_GuiManager.ScriptOps.UpdateNRxGainTempLUTGetConfData(1, ProfileIndex);
			return m_GuiManager.ScriptOps.UpdateNRxGainTempLUTGetConfData_cmd(out profileIndex, out Rx1GainCodeTempLessThanNeg30, out Rx1GainCodeTempNeg30ToNeg20, out Rx1GainCodeTempNeg20ToNeg10, out Rx1GainCodeTempNeg10To0, out Rx1GainCodeTemp0To10, out Rx1GainCodeTemp10To20, out Rx1GainCodeTemp20To30, out Rx1GainCodeTemp30To40, out Rx1GainCodeTemp40To50, out Rx1GainCodeTemp50To60, out Rx1GainCodeTemp60To70, out Rx1GainCodeTemp70To80, out Rx1GainCodeTemp80To90, out Rx1GainCodeTemp90To100, out Rx1GainCodeTemp100To110, out Rx1GainCodeTemp110To120, out Rx1GainCodeTemp120To130, out Rx1GainCodeTemp130To140, out Rx1GainCodeTempMoreThan140);
		}

		[AttrLuaFunc("RxGainTempLutGet_mult", " RxGainTempLutGet API used to read the RX gain temperature LUT used by the firmware", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring config applies",
			"out profileIndex",
			"out Rx1GainCodeTempLessThanNeg30",
			"out Rx1GainCodeTempNeg30ToNeg20",
			"out Rx1GainCodeTempNeg20ToNeg10",
			"out Rx1GainCodeTempNeg10To0",
			"out Rx1GainCodeTemp0To10",
			"out Rx1GainCodeTemp10To20",
			"out Rx1GainCodeTemp20To30",
			"out Rx1GainCodeTemp30To40",
			"out Rx1GainCodeTemp40To50",
			"out Rx1GainCodeTemp50To60",
			"out Rx1GainCodeTemp60To70",
			"out Rx1GainCodeTemp70To80",
			"out Rx1GainCodeTemp80To90",
			"out Rx1GainCodeTemp90To100",
			"out Rx1GainCodeTemp100To110",
			"out Rx1GainCodeTemp110To120",
			"out Rx1GainCodeTemp120To130",
			"out Rx1GainCodeTemp130To140",
			"out Rx1GainCodeTempMoreThan140"
		})]
		public int RxGainTempLutGet(ushort RadarDeviceId, char ProfileIndex, out string profileIndex, out string Rx1GainCodeTempLessThanNeg30, out string Rx1GainCodeTempNeg30ToNeg20, out string Rx1GainCodeTempNeg20ToNeg10, out string Rx1GainCodeTempNeg10To0, out string Rx1GainCodeTemp0To10, out string Rx1GainCodeTemp10To20, out string Rx1GainCodeTemp20To30, out string Rx1GainCodeTemp30To40, out string Rx1GainCodeTemp40To50, out string Rx1GainCodeTemp50To60, out string Rx1GainCodeTemp60To70, out string Rx1GainCodeTemp70To80, out string Rx1GainCodeTemp80To90, out string Rx1GainCodeTemp90To100, out string Rx1GainCodeTemp100To110, out string Rx1GainCodeTemp110To120, out string Rx1GainCodeTemp120To130, out string Rx1GainCodeTemp130To140, out string Rx1GainCodeTempMoreThan140)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			profileIndex = string.Empty;
			Rx1GainCodeTempLessThanNeg30 = string.Empty;
			Rx1GainCodeTempNeg30ToNeg20 = string.Empty;
			Rx1GainCodeTempNeg20ToNeg10 = string.Empty;
			Rx1GainCodeTempNeg10To0 = string.Empty;
			Rx1GainCodeTemp0To10 = string.Empty;
			Rx1GainCodeTemp10To20 = string.Empty;
			Rx1GainCodeTemp20To30 = string.Empty;
			Rx1GainCodeTemp30To40 = string.Empty;
			Rx1GainCodeTemp40To50 = string.Empty;
			Rx1GainCodeTemp50To60 = string.Empty;
			Rx1GainCodeTemp60To70 = string.Empty;
			Rx1GainCodeTemp70To80 = string.Empty;
			Rx1GainCodeTemp80To90 = string.Empty;
			Rx1GainCodeTemp90To100 = string.Empty;
			Rx1GainCodeTemp100To110 = string.Empty;
			Rx1GainCodeTemp110To120 = string.Empty;
			Rx1GainCodeTemp120To130 = string.Empty;
			Rx1GainCodeTemp130To140 = string.Empty;
			Rx1GainCodeTempMoreThan140 = string.Empty;
			m_GuiManager.ScriptOps.UpdateNRxGainTempLUTGetConfData(RadarDeviceId, ProfileIndex);
			return m_GuiManager.ScriptOps.UpdateNRxGainTempLUTGetConfData_cmd(out profileIndex, out Rx1GainCodeTempLessThanNeg30, out Rx1GainCodeTempNeg30ToNeg20, out Rx1GainCodeTempNeg20ToNeg10, out Rx1GainCodeTempNeg10To0, out Rx1GainCodeTemp0To10, out Rx1GainCodeTemp10To20, out Rx1GainCodeTemp20To30, out Rx1GainCodeTemp30To40, out Rx1GainCodeTemp40To50, out Rx1GainCodeTemp50To60, out Rx1GainCodeTemp60To70, out Rx1GainCodeTemp70To80, out Rx1GainCodeTemp80To90, out Rx1GainCodeTemp90To100, out Rx1GainCodeTemp100To110, out Rx1GainCodeTemp110To120, out Rx1GainCodeTemp120To130, out Rx1GainCodeTemp130To140, out Rx1GainCodeTempMoreThan140);
		}

		[AttrLuaFunc("SetRfAnaMonConfig", " SetRfAnaMonConfig API which defines consolidated configuration of all analog monitoring", new string[]
		{
			"Analog monitoring enables",
			"Reserved, APLL LDO Short Circuit[b0], VCO LDO Short Circuit[b1], PA LDO Short circuit[b2]"
		})]
		public int SetRfAnaMonConfig(uint AnaMonEnables, uint Reserved)
		{
			return m_GuiManager.ScriptOps.UpdateNSetAnalogMonitoringEnablesConfData(1, AnaMonEnables, Reserved);
		}

		[AttrLuaFunc("SetRfAnaMonConfig_mult", " SetRfAnaMonConfig API which defines consolidated configuration of all analog monitoring", new string[]
		{
			"Radar Device Id",
			"Analog monitoring enables",
			"Reserved, APLL LDO Short Circuit[b0], VCO LDO Short Circuit[b1], PA LDO Short circuit[b2]"
		})]
		public int SetRfAnaMonConfig(ushort RadarDeviceId, uint AnaMonEnables, uint Reserved)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetAnalogMonitoringEnablesConfData(RadarDeviceId, AnaMonEnables, Reserved);
		}

		[AttrLuaFunc("SetRfTxGainPhaseMismatchMonConfig", " SetRfTxGainPhaseMismatchMonConfig API which defines as containing information related to Tx gain and phase mismatch monitoring", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"TX0 channel enables",
			"TX1 channel enables",
			"TX2 channel enables",
			"RX0 channel enables",
			"RX1 channel enables",
			"RX2 channel enables",
			"RX3 channel",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check ",
			"Reserved2",
			"Tx gain mismatch threshold in dB (1 LSB = 0.1dB )",
			"Tx Phase mismatch threshold in deg(1 LSB = 360/2^16 )",
			"RF1 TX0 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF1 TX1 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF1 TX2 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF2 TX0 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF2 TX1 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF2 TX2 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF3 TX0 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF3 TX1 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF3 TX2 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF1 TX0 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF1 TX1 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF1 TX2 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF2 TX0 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF2 TX1 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF2 TX2 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF3 TX0 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF3 TX1 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF3 TX2 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"Reserved3",
			"Reserved4",
			"out StatusFlag",
			"out Errorcode",
			"out Profileindex",
			"out RF1Tx0GainReportValue",
			"out RF1Tx1GainReportValue",
			"out RF1Tx2GainReportValue",
			"out RF2Tx0GainReportValue",
			"out RF2Tx1GainReportValue",
			"out RF2Tx2GainReportValue",
			"out RF3Tx0GainReportValue",
			"out RF3Tx1GainReportValue",
			"out RF3Tx2GainReportValue",
			"out RF1Tx0PhaseReportValue",
			"out RF1Tx1PhaseReportValue",
			"out RF1Tx2PhaseReportValue",
			"out RF2Tx0PhaseReportValue",
			"out RF2Tx1PhaseReportValue",
			"out RF2Tx2PhaseReportValue",
			"out RF3Tx0PhaseReportValue",
			"out RF3Tx1PhaseReportValue",
			"out RF3Tx2PhaseReportValue",
			"out Timestamp"
		})]
		public int SetRfTxGainPhaseMismatchMonConfig(char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char Tx0Channel, char Tx1Channel, char Tx2Channel, char Rx0Channel, char Rx1Channel, char Rx2Channel, char Rx3Channel, char ReportingMode, char Reserved2, double TxGainMismatchThreshold, double TxPhaseMismatchThreshold, double RF1Tx0GainMismatchOffsetVal, double RF1Tx1GainMismatchOffsetVal, double RF1Tx2GainMismatchOffsetVal, double RF2Tx0GainMismatchOffsetVal, double RF2Tx1GainMismatchOffsetVal, double RF2Tx2GainMismatchOffsetVal, double RF3Tx0GainMismatchOffsetVal, double RF3Tx1GainMismatchOffsetVal, double RF3Tx2GainMismatchOffsetVal, double RF1Tx0PhaseMismatchOffsetVal, double RF1Tx1PhaseMismatchOffsetVal, double RF1Tx2PhaseMismatchOffsetVal, double RF2Tx0PhaseMismatchOffsetVal, double RF2Tx1PhaseMismatchOffsetVal, double RF2Tx2PhaseMismatchOffsetVal, double RF3Tx0PhaseMismatchOffsetVal, double RF3Tx1PhaseMismatchOffsetVal, double RF3Tx2PhaseMismatchOffsetVal, ushort Reserved3, uint Reserved4, out string StatusFlag, out string Errorcode, out string Profileindex, out string RF1Tx0GainReportValue, out string RF1Tx1GainReportValue, out string RF1Tx2GainReportValue, out string RF2Tx0GainReportValue, out string RF2Tx1GainReportValue, out string RF2Tx2GainReportValue, out string RF3Tx0GainReportValue, out string RF3Tx1GainReportValue, out string RF3Tx2GainReportValue, out string RF1Tx0PhaseReportValue, out string RF1Tx1PhaseReportValue, out string RF1Tx2PhaseReportValue, out string RF2Tx0PhaseReportValue, out string RF2Tx1PhaseReportValue, out string RF2Tx2PhaseReportValue, out string RF3Tx0PhaseReportValue, out string RF3Tx1PhaseReportValue, out string RF3Tx2PhaseReportValue, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			RF1Tx0GainReportValue = string.Empty;
			RF1Tx1GainReportValue = string.Empty;
			RF1Tx2GainReportValue = string.Empty;
			RF2Tx0GainReportValue = string.Empty;
			RF2Tx1GainReportValue = string.Empty;
			RF2Tx2GainReportValue = string.Empty;
			RF3Tx0GainReportValue = string.Empty;
			RF3Tx1GainReportValue = string.Empty;
			RF3Tx2GainReportValue = string.Empty;
			RF1Tx0PhaseReportValue = string.Empty;
			RF1Tx1PhaseReportValue = string.Empty;
			RF1Tx2PhaseReportValue = string.Empty;
			RF2Tx0PhaseReportValue = string.Empty;
			RF2Tx1PhaseReportValue = string.Empty;
			RF2Tx2PhaseReportValue = string.Empty;
			RF3Tx0PhaseReportValue = string.Empty;
			RF3Tx1PhaseReportValue = string.Empty;
			RF3Tx2PhaseReportValue = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTxGainPhaseMismatchMonitoringConfData(1, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, Tx0Channel, Tx1Channel, Tx2Channel, Rx0Channel, Rx1Channel, Rx2Channel, Rx3Channel, ReportingMode, Reserved2, TxGainMismatchThreshold, TxPhaseMismatchThreshold, RF1Tx0GainMismatchOffsetVal, RF1Tx1GainMismatchOffsetVal, RF1Tx2GainMismatchOffsetVal, RF2Tx0GainMismatchOffsetVal, RF2Tx1GainMismatchOffsetVal, RF2Tx2GainMismatchOffsetVal, RF3Tx0GainMismatchOffsetVal, RF3Tx1GainMismatchOffsetVal, RF3Tx2GainMismatchOffsetVal, RF1Tx0PhaseMismatchOffsetVal, RF1Tx1PhaseMismatchOffsetVal, RF1Tx2PhaseMismatchOffsetVal, RF2Tx0PhaseMismatchOffsetVal, RF2Tx1PhaseMismatchOffsetVal, RF2Tx2PhaseMismatchOffsetVal, RF3Tx0PhaseMismatchOffsetVal, RF3Tx1PhaseMismatchOffsetVal, RF3Tx2PhaseMismatchOffsetVal, Reserved3, Reserved4);
			return m_GuiManager.ScriptOps.UpdateNTxGainPhaseMismatchMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out RF1Tx0GainReportValue, out RF1Tx1GainReportValue, out RF1Tx2GainReportValue, out RF2Tx0GainReportValue, out RF2Tx1GainReportValue, out RF2Tx2GainReportValue, out RF3Tx0GainReportValue, out RF3Tx1GainReportValue, out RF3Tx2GainReportValue, out RF1Tx0PhaseReportValue, out RF1Tx1PhaseReportValue, out RF1Tx2PhaseReportValue, out RF2Tx0PhaseReportValue, out RF2Tx1PhaseReportValue, out RF2Tx2PhaseReportValue, out RF3Tx0PhaseReportValue, out RF3Tx1PhaseReportValue, out RF3Tx2PhaseReportValue, out Timestamp);
		}

		[AttrLuaFunc("SetRfTxGainPhaseMismatchMonConfig_mult", " SetRfTxGainPhaseMismatchMonConfig API which defines as containing information related to Tx gain and phase mismatch monitoring", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"TX0 channel enables",
			"TX1 channel enables",
			"TX2 channel enables",
			"RX0 channel enables",
			"RX1 channel enables",
			"RX2 channel enables",
			"RX3 channel",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check ",
			"Reserved2",
			"Tx gain mismatch threshold in dB (1 LSB = 0.1dB )",
			"Tx Phase mismatch threshold in deg (1 LSB = 360/2^16 )",
			"RF1 TX0 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF1 TX1 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF1 TX2 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF2 TX0 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF2 TX1 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF2 TX2 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF3 TX0 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF3 TX1 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF3 TX2 gain mismatch offset value in dB (1 LSB = 0.1dB )",
			"RF1 TX0 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF1 TX1 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF1 TX2 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF2 TX0 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF2 TX1 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF2 TX2 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF3 TX0 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF3 TX1 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"RF3 TX2 Phase mismatch offset value(1 LSB = 360/2^16 )",
			"Reserved3",
			"Reserved4",
			"out StatusFlag",
			"out Errorcode",
			"out Profileindex",
			"out RF1Tx0GainReportValue",
			"out RF1Tx1GainReportValue",
			"out RF1Tx2GainReportValue",
			"out RF2Tx0GainReportValue",
			"out RF2Tx1GainReportValue",
			"out RF2Tx2GainReportValue",
			"out RF3Tx0GainReportValue",
			"out RF3Tx1GainReportValue",
			"out RF3Tx2GainReportValue",
			"out RF1Tx0PhaseReportValue",
			"out RF1Tx1PhaseReportValue",
			"out RF1Tx2PhaseReportValue",
			"out RF2Tx0PhaseReportValue",
			"out RF2Tx1PhaseReportValue",
			"out RF2Tx2PhaseReportValue",
			"out RF3Tx0PhaseReportValue",
			"out RF3Tx1PhaseReportValue",
			"out RF3Tx2PhaseReportValue",
			"out Timestamp"
		})]
		public int SetRfTxGainPhaseMismatchMonConfig(ushort RadarDeviceId, char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char Tx0Channel, char Tx1Channel, char Tx2Channel, char Rx0Channel, char Rx1Channel, char Rx2Channel, char Rx3Channel, char ReportingMode, char Reserved2, double TxGainMismatchThreshold, double TxPhaseMismatchThreshold, double RF1Tx0GainMismatchOffsetVal, double RF1Tx1GainMismatchOffsetVal, double RF1Tx2GainMismatchOffsetVal, double RF2Tx0GainMismatchOffsetVal, double RF2Tx1GainMismatchOffsetVal, double RF2Tx2GainMismatchOffsetVal, double RF3Tx0GainMismatchOffsetVal, double RF3Tx1GainMismatchOffsetVal, double RF3Tx2GainMismatchOffsetVal, double RF1Tx0PhaseMismatchOffsetVal, double RF1Tx1PhaseMismatchOffsetVal, double RF1Tx2PhaseMismatchOffsetVal, double RF2Tx0PhaseMismatchOffsetVal, double RF2Tx1PhaseMismatchOffsetVal, double RF2Tx2PhaseMismatchOffsetVal, double RF3Tx0PhaseMismatchOffsetVal, double RF3Tx1PhaseMismatchOffsetVal, double RF3Tx2PhaseMismatchOffsetVal, ushort Reserved3, uint Reserved4, out string StatusFlag, out string Errorcode, out string Profileindex, out string RF1Tx0GainReportValue, out string RF1Tx1GainReportValue, out string RF1Tx2GainReportValue, out string RF2Tx0GainReportValue, out string RF2Tx1GainReportValue, out string RF2Tx2GainReportValue, out string RF3Tx0GainReportValue, out string RF3Tx1GainReportValue, out string RF3Tx2GainReportValue, out string RF1Tx0PhaseReportValue, out string RF1Tx1PhaseReportValue, out string RF1Tx2PhaseReportValue, out string RF2Tx0PhaseReportValue, out string RF2Tx1PhaseReportValue, out string RF2Tx2PhaseReportValue, out string RF3Tx0PhaseReportValue, out string RF3Tx1PhaseReportValue, out string RF3Tx2PhaseReportValue, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			RF1Tx0GainReportValue = string.Empty;
			RF1Tx1GainReportValue = string.Empty;
			RF1Tx2GainReportValue = string.Empty;
			RF2Tx0GainReportValue = string.Empty;
			RF2Tx1GainReportValue = string.Empty;
			RF2Tx2GainReportValue = string.Empty;
			RF3Tx0GainReportValue = string.Empty;
			RF3Tx1GainReportValue = string.Empty;
			RF3Tx2GainReportValue = string.Empty;
			RF1Tx0PhaseReportValue = string.Empty;
			RF1Tx1PhaseReportValue = string.Empty;
			RF1Tx2PhaseReportValue = string.Empty;
			RF2Tx0PhaseReportValue = string.Empty;
			RF2Tx1PhaseReportValue = string.Empty;
			RF2Tx2PhaseReportValue = string.Empty;
			RF3Tx0PhaseReportValue = string.Empty;
			RF3Tx1PhaseReportValue = string.Empty;
			RF3Tx2PhaseReportValue = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTxGainPhaseMismatchMonitoringConfData(RadarDeviceId, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, Tx0Channel, Tx1Channel, Tx2Channel, Rx0Channel, Rx1Channel, Rx2Channel, Rx3Channel, ReportingMode, Reserved2, TxGainMismatchThreshold, TxPhaseMismatchThreshold, RF1Tx0GainMismatchOffsetVal, RF1Tx1GainMismatchOffsetVal, RF1Tx2GainMismatchOffsetVal, RF2Tx0GainMismatchOffsetVal, RF2Tx1GainMismatchOffsetVal, RF2Tx2GainMismatchOffsetVal, RF3Tx0GainMismatchOffsetVal, RF3Tx1GainMismatchOffsetVal, RF3Tx2GainMismatchOffsetVal, RF1Tx0PhaseMismatchOffsetVal, RF1Tx1PhaseMismatchOffsetVal, RF1Tx2PhaseMismatchOffsetVal, RF2Tx0PhaseMismatchOffsetVal, RF2Tx1PhaseMismatchOffsetVal, RF2Tx2PhaseMismatchOffsetVal, RF3Tx0PhaseMismatchOffsetVal, RF3Tx1PhaseMismatchOffsetVal, RF3Tx2PhaseMismatchOffsetVal, Reserved3, Reserved4);
			return m_GuiManager.ScriptOps.UpdateNTxGainPhaseMismatchMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out RF1Tx0GainReportValue, out RF1Tx1GainReportValue, out RF1Tx2GainReportValue, out RF2Tx0GainReportValue, out RF2Tx1GainReportValue, out RF2Tx2GainReportValue, out RF3Tx0GainReportValue, out RF3Tx1GainReportValue, out RF3Tx2GainReportValue, out RF1Tx0PhaseReportValue, out RF1Tx1PhaseReportValue, out RF1Tx2PhaseReportValue, out RF2Tx0PhaseReportValue, out RF2Tx1PhaseReportValue, out RF2Tx2PhaseReportValue, out RF3Tx0PhaseReportValue, out RF3Tx1PhaseReportValue, out RF3Tx2PhaseReportValue, out Timestamp);
		}

		[AttrLuaFunc("SetRfGpadcIntAnaSignalsMonConfig", "SetRfGpadcIntAnaSignalsMonConfig API which defines that configure the information related to GPADC internal annalog signal monitoring and report the soft results from monitor", new string[]
		{
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"out StatusFlag",
			"out  Errorcode",
			"out GPADCRef1Val",
			"out GPADCRef2Val",
			"out Timestamp"
		})]
		public int SetRfGpadcIntAnaSignalsMonConfig(char ReportingMode, out string StatusFlag, out string Errorcode, out string p3, out string p4, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			p3 = string.Empty;
			p4 = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalGPADCAnalogSignalMonitoringConfData(1, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalGPADCAnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out p3, out p4, out Timestamp);
		}

		[AttrLuaFunc("SetRfGpadcIntAnaSignalsMonConfig_mult", "SetRfGpadcIntAnaSignalsMonConfig API which defines that configure the information related to GPADC internal annalog signal monitoring and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"out StatusFlag",
			"out  Errorcode",
			"out GPADCRef1Val",
			"out GPADCRef2Val",
			"out Timestamp"
		})]
		public int SetRfGpadcIntAnaSignalsMonConfig(ushort RadarDeviceId, char ReportingMode, out string StatusFlag, out string Errorcode, out string p4, out string p5, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			p4 = string.Empty;
			p5 = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalGPADCAnalogSignalMonitoringConfData(RadarDeviceId, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalGPADCAnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out p4, out p5, out Timestamp);
		}

		[AttrLuaFunc("SetRfPmClkLoIntAnaSignalsMonConfig", "SetRfPmClkLoIntAnaSignalsMonConfig API which defines that configure the information related to Power management, clock generation and LO distribution circuits internal annalog signal monitoring and report the soft results from monitor", new string[]
		{
			"Profile Index used for monitoring the enabled signals [b7:0] + Sync_20G_SIG_SEL[b15:8] + SYNC_20G_MIN_THRESH[b23:16]",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check + SYNC_20G_MAX_THRESH[b15:8]",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out  Sync 20G power",
			"out  Reserved",
			"out Timestamp"
		})]
		public int SetRfPmClkLoIntAnaSignalsMonConfig(int ProfileIndex, uint ReportingMode, out string StatusFlag, out string Errorcode, out string profileIndex, out string Sync20GPower, out string Reserved, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			Timestamp = string.Empty;
			Sync20GPower = string.Empty;
			Reserved = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalPMCLKLOAnalogSignalMonitoringConfData(1, ProfileIndex, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalPMCLKLOAnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Sync20GPower, out Reserved, out Timestamp);
		}

		[AttrLuaFunc("SetRfPmClkLoIntAnaSignalsMonConfig_mult", "SetRfPmClkLoIntAnaSignalsMonConfig API which defines that configure the information related to Power management, clock generation and LO distribution circuits internal annalog signal monitoring and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index used for monitoring the enabled signals[b7:0] + Sync_20G_SIG_SEL[b15:8] + SYNC_20G_MIN_THRESH[b23:16]",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check+ SYNC_20G_MAX_THRESH[b15:8]",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out  Sync 20G power",
			"out  Reserved",
			"out Timestamp"
		})]
		public int SetRfPmClkLoIntAnaSignalsMonConfig(ushort RadarDeviceId, int ProfileIndex, uint ReportingMode, out string StatusFlag, out string Errorcode, out string profileIndex, out string Sync20GPower, out string Reserved, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			Timestamp = string.Empty;
			Sync20GPower = string.Empty;
			Reserved = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalPMCLKLOAnalogSignalMonitoringConfData(RadarDeviceId, ProfileIndex, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalPMCLKLOAnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Sync20GPower, out Reserved, out Timestamp);
		}

		[AttrLuaFunc("SetRfRxIntAnaSignalsMonConfig", "SetRfRxIntAnaSignalsMonConfig API which defines that configure the information related to RX internal analog signals monitoring and report the soft results from monitor", new string[]
		{
			"Profile Index used for monitoring the enabled signals",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Timestamp"
		})]
		public int SetRfRxIntAnaSignalsMonConfig(char ProfileIndex, char ReportingMode, out string StatusFlag, out string Errorcode, out string profileIndex, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalRXAnalogSignalMonitoringConfData(1, ProfileIndex, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalRXAnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Timestamp);
		}

		[AttrLuaFunc("SetRfRxIntAnaSignalsMonConfig_mult", "SetRfRxIntAnaSignalsMonConfig API which defines that configure the information related to RX internal analog signals monitoring and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index used for monitoring the enabled signals",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Timestamp"
		})]
		public int SetRfRxIntAnaSignalsMonConfig(ushort RadarDeviceId, char ProfileIndex, char ReportingMode, out string StatusFlag, out string Errorcode, out string profileIndex, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalRXAnalogSignalMonitoringConfData(RadarDeviceId, ProfileIndex, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalRXAnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx0IntAnaSignalsMonConfig", "SetRfTx0IntAnaSignalsMonConfig API which defines that configure the information related to TX0 internal analog signals monitoring and report the soft results from monitor", new string[]
		{
			"Profile Index for which this monitoring the enabled signals",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Timestamp"
		})]
		public int SetRfTx0IntAnaSignalsMonConfig(char ProfileIndex, char ReportingMode, out string StatusFlag, out string Errorcode, out string profileIndex, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalTX1AnalogSignalMonitoringConfData(1, ProfileIndex, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalTX1AnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx0IntAnaSignalsMonConfig_mult", "SetRfTx0IntAnaSignalsMonConfig API which defines that configure the information related to TX0 internal analog signals monitoring and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring the enabled signals",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Timestamp"
		})]
		public int SetRfTx0IntAnaSignalsMonConfig(ushort RadarDeviceId, char ProfileIndex, char ReportingMode, out string StatusFlag, out string Errorcode, out string profileIndex, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalTX1AnalogSignalMonitoringConfData(RadarDeviceId, ProfileIndex, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalTX1AnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx1IntAnaSignalsMonConfig", "SetRfTx1IntAnaSignalsMonConfig API which defines that configure the information related to TX1 internal analog signals monitoring and report the soft results from monitor", new string[]
		{
			"Profile Index for which this monitoring the enabled signals",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Timestamp"
		})]
		public int SetRfTx1IntAnaSignalsMonConfig(char ProfileIndex, char ReportingMode, out string StatusFlag, out string Errorcode, out string profileIndex, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalTX2AnalogSignalMonitoringConfData(1, ProfileIndex, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalTX2AnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx1IntAnaSignalsMonConfig_mult", "SetRfTx1IntAnaSignalsMonConfig API which defines that configure the information related to TX1 internal analog signals monitoring and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring the enabled signals",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Timestamp"
		})]
		public int SetRfTx1IntAnaSignalsMonConfig(ushort RadarDeviceId, char ProfileIndex, char ReportingMode, out string StatusFlag, out string Errorcode, out string profileIndex, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalTX2AnalogSignalMonitoringConfData(RadarDeviceId, ProfileIndex, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalTX2AnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx2IntAnaSignalsMonConfig", "SetRfTx2IntAnaSignalsMonConfig API which defines that configure the information related to TX2 internal analog signals monitoring and report the soft results from monitor", new string[]
		{
			"Profile Index for which this monitoring the enabled signals",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Timestamp"
		})]
		public int SetRfTx2IntAnaSignalsMonConfig(char ProfileIndex, char ReportingMode, out string StatusFlag, out string Errorcode, out string profileIndex, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalTX3AnalogSignalMonitoringConfData(1, ProfileIndex, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalTX3AnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx2IntAnaSignalsMonConfig_mult", "SetRfTx2IntAnaSignalsMonConfig API which defines that configure the information related to TX2 internal analog signals monitoring and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring the enabled signals",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Timestamp"
		})]
		public int SetRfTx2IntAnaSignalsMonConfig(ushort RadarDeviceId, char ProfileIndex, char ReportingMode, out string StatusFlag, out string Errorcode, out string profileIndex, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetInternalTX3AnalogSignalMonitoringConfData(RadarDeviceId, ProfileIndex, ReportingMode);
			return m_GuiManager.ScriptOps.UpdateNInternalTX3AnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Timestamp);
		}

		[AttrLuaFunc("SetRfTempMonConfig", "SetRfTempMonConfig API which defines that configure the information related to temperature monitoring and report the soft results from monitor", new string[]
		{
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Analog temperature minimum in deg(1LSB = 1 Deg Cel)",
			"Analog temperature threshold maximum in deg(1LSB = 1 Deg Cel)",
			"Digital temperature threshold minimum in deg(1LSB = 1 Deg Cel)",
			"Digital temperature threshold maximum in deg(1LSB = 1 Deg Cel)",
			"Temperature difference threshold in deg(1LSB = 1 Deg Cel)",
			"out StatusFlag",
			"out Errorcode",
			"out Rx1TempVal",
			"out  Rx2TempVal",
			"out  Rx3TempVal",
			"out Rx4TempVal",
			"out Tx1TempVal",
			"out Tx2TempVal",
			"out Tx3TempVal",
			"out PMTempVal",
			"out Dig1TempVal",
			"out Dig2TempVal",
			"out Timestamp"
		})]
		public int SetRfTempMonConfig(char ReportingMode, short AnaTempThreshMin, short AnaTempThreshMax, short DigTempThreshMin, short DigTempThreshMax, short TempDiffThresh, out string StatusFlag, out string Errorcode, out string Rx1TempVal, out string Rx2TempVal, out string Rx3TempVal, out string Rx4TempVal, out string Tx1TempVal, out string Tx2TempVal, out string Tx3TempVal, out string PMTempVal, out string Dig1TempVal, out string Dig2TempVal, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Rx1TempVal = string.Empty;
			Rx2TempVal = string.Empty;
			Rx3TempVal = string.Empty;
			Rx4TempVal = string.Empty;
			Tx1TempVal = string.Empty;
			Tx2TempVal = string.Empty;
			Tx3TempVal = string.Empty;
			PMTempVal = string.Empty;
			Dig1TempVal = string.Empty;
			Dig2TempVal = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTemperatureMonitoringConfData(1, ReportingMode, AnaTempThreshMin, AnaTempThreshMax, DigTempThreshMin, DigTempThreshMax, TempDiffThresh);
			return m_GuiManager.ScriptOps.UpdateNTemperatureMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Rx1TempVal, out Rx2TempVal, out Rx3TempVal, out Rx4TempVal, out Tx1TempVal, out Tx2TempVal, out Tx3TempVal, out PMTempVal, out Dig1TempVal, out Dig2TempVal, out Timestamp);
		}

		[AttrLuaFunc("SetRfTempMonConfig_mult", "SetRfTempMonConfig API which defines that configure the information related to temperature monitoring and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Analog temperature minimum in deg(1LSB = 1 Deg Cel)",
			"Analog temperature threshold maximum in deg(1LSB = 1 Deg Cel)",
			"Digital temperature threshold minimum in deg(1LSB = 1 Deg Cel)",
			"Digital temperature threshold maximum in deg(1LSB = 1 Deg Cel)",
			"Temperature difference threshold in deg(1LSB = 1 Deg Cel)",
			"out StatusFlag",
			"out Errorcode",
			"out Rx1TempVal",
			"out  Rx2TempVal",
			"out  Rx3TempVal",
			"out Rx4TempVal",
			"out Tx1TempVal",
			"out Tx2TempVal",
			"out Tx3TempVal",
			"out PMTempVal",
			"out Dig1TempVal",
			"out Dig2TempVal",
			"out Timestamp"
		})]
		public int SetRfTempMonConfig(ushort RadarDeviceId, char ReportingMode, short AnaTempThreshMin, short AnaTempThreshMax, short DigTempThreshMin, short DigTempThreshMax, short TempDiffThresh, out string StatusFlag, out string Errorcode, out string Rx1TempVal, out string Rx2TempVal, out string Rx3TempVal, out string Rx4TempVal, out string Tx1TempVal, out string Tx2TempVal, out string Tx3TempVal, out string PMTempVal, out string Dig1TempVal, out string Dig2TempVal, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Rx1TempVal = string.Empty;
			Rx2TempVal = string.Empty;
			Rx3TempVal = string.Empty;
			Rx4TempVal = string.Empty;
			Tx1TempVal = string.Empty;
			Tx2TempVal = string.Empty;
			Tx3TempVal = string.Empty;
			PMTempVal = string.Empty;
			Dig1TempVal = string.Empty;
			Dig2TempVal = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTemperatureMonitoringConfData(RadarDeviceId, ReportingMode, AnaTempThreshMin, AnaTempThreshMax, DigTempThreshMin, DigTempThreshMax, TempDiffThresh);
			return m_GuiManager.ScriptOps.UpdateNTemperatureMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Rx1TempVal, out Rx2TempVal, out Rx3TempVal, out Rx4TempVal, out Tx1TempVal, out Tx2TempVal, out Tx3TempVal, out PMTempVal, out Dig1TempVal, out Dig2TempVal, out Timestamp);
		}

		[AttrLuaFunc("SetRfExtAnaSignalsMonConfig", "SetRfExtAnaSignalsMonConfig API which defines that configure the information related to external DC signals monitoring and report the soft results from monitor", new string[]
		{
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Signal input enables Analog test1",
			"Signal input enables Analog test2",
			"Signal input enables Analog test3",
			"Signal input enables Analog test4",
			"Signal input enables Analog Mux",
			"Signal input enables Analog Vsense",
			"Signal buffer enables Analog test1",
			"Signal buffer enables Analog test2",
			"Signal buffer enables Analog test3",
			"Signal buffer enables Analog test4",
			"Signal buffer enables Analog Mux",
			"Signal settling time Analog test1 in us (1 LSB = 0.8 us)",
			"Signal settling time Analog test2 in us (1 LSB = 0.8 us)",
			"Signal settling time Analog test3 in us (1 LSB = 0.8 us)",
			"Signal settling time Analog test4 in us (1 LSB = 0.8 us)",
			"Signal settling time Analog Mux in us (1 LSB = 0.8 us)",
			"Signal settling time Analog Vsense in us (1 LSB = 0.8 us)",
			"Signal minimum threshold Analog test1 in Vol (1 LSB = 1.8V/256)",
			"Signal minimum threshold Analog test2 in Vol (1 LSB = 1.8V/256)",
			"Signal minimum threshold Analog test3 in Vol (1 LSB = 1.8V/256)",
			"Signal minimum threshold Analog test4 in Vol (1 LSB = 1.8V/256)",
			"Signal minimum threshold Analog Mux in Vol (1 LSB = 1.8V/256)",
			"Signal minimum threshold Analog Vsense in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog test1 in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog test2 in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog test3 in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog test4 in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog Mux in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog Vsense in Vol (1 LSB = 1.8V/256)",
			"out StatusFlag",
			"out  Errorcode",
			"out ExtAnalogSigtest1Val",
			"out ExtAnalogSigtest2Val",
			"out ExtAnalogSigtest3Val",
			"out ExtAnalogSigtest4Val",
			"out ExtAnalogSigmuxVal",
			"out ExtAnalogSigvsenseVal",
			"out Timestamp"
		})]
		public int SetRfExtAnaSignalsMonConfig(char ReportingMode, char SigIpEnaAnalogTest1, char SigIpEnaAnalogTest2, char SigIpEnaAnalogTest3, char SigIpEnaAnalogTest4, char SigIpEnaAnalogMux, char SigIpEnaAnalogVSense, char SigBufEnaAnalogTest1, char SigBufEnaAnalogTest2, char SigBufEnaAnalogTest3, char SigBufEnaAnalogTest4, char SigBufEnaAnalogMux, double SigSettlingTimeAnalogTest1, double SigSettlingTimeAnalogTest2, double SigSettlingTimeAnalogTest3, double SigSettlingTimeAnalogTest4, double SigSettlingTimeAnalogMux, double SigSettlingTimeAnalogVSense, double SigMinThresholdAnalogTest1, double SigMinThresholdAnalogTest2, double SigMinThresholdAnalogTest3, double SigMinThresholdAnalogTest4, double SigMinThresholdAnalogMux, double SigMinThresholdAnalogVSense, double SigMaxThresholdAnalogTest1, double SigMaxThresholdAnalogTest2, double SigMaxThresholdAnalogTest3, double SigMaxThresholdAnalogTest4, double SigMaxThresholdAnalogMux, double SigMaxThresholdAnalogVSense, out string StatusFlag, out string Errorcode, out string ExtAnalogSigtest1Val, out string ExtAnalogSigtest2Val, out string ExtAnalogSigtest3Val, out string ExtAnalogSigtest4Val, out string ExtAnalogSigmuxVal, out string ExtAnalogSigvsenseVal, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			ExtAnalogSigtest1Val = string.Empty;
			ExtAnalogSigtest2Val = string.Empty;
			ExtAnalogSigtest3Val = string.Empty;
			ExtAnalogSigtest4Val = string.Empty;
			ExtAnalogSigmuxVal = string.Empty;
			ExtAnalogSigvsenseVal = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetExternalAnalogSignalMonitoringConfData(1, ReportingMode, SigIpEnaAnalogTest1, SigIpEnaAnalogTest2, SigIpEnaAnalogTest3, SigIpEnaAnalogTest4, SigIpEnaAnalogMux, SigIpEnaAnalogVSense, SigBufEnaAnalogTest1, SigBufEnaAnalogTest2, SigBufEnaAnalogTest3, SigBufEnaAnalogTest4, SigBufEnaAnalogMux, SigSettlingTimeAnalogTest1, SigSettlingTimeAnalogTest2, SigSettlingTimeAnalogTest3, SigSettlingTimeAnalogTest4, SigSettlingTimeAnalogMux, SigSettlingTimeAnalogVSense, SigMinThresholdAnalogTest1, SigMinThresholdAnalogTest2, SigMinThresholdAnalogTest3, SigMinThresholdAnalogTest4, SigMinThresholdAnalogMux, SigMinThresholdAnalogVSense, SigMaxThresholdAnalogTest1, SigMaxThresholdAnalogTest2, SigMaxThresholdAnalogTest3, SigMaxThresholdAnalogTest4, SigMaxThresholdAnalogMux, SigMaxThresholdAnalogVSense);
			return m_GuiManager.ScriptOps.UpdateNExternalAnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out ExtAnalogSigtest1Val, out ExtAnalogSigtest2Val, out ExtAnalogSigtest3Val, out ExtAnalogSigtest4Val, out ExtAnalogSigmuxVal, out ExtAnalogSigvsenseVal, out Timestamp);
		}

		[AttrLuaFunc("SetRfExtAnaSignalsMonConfig_mult", "SetRfExtAnaSignalsMonConfig API which defines that configure the information related to external DC signals monitoring and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Signal input enables Analog test1",
			"Signal input enables Analog test2",
			"Signal input enables Analog test3",
			"Signal input enables Analog test4",
			"Signal input enables Analog Mux",
			"Signal input enables Analog Vsense",
			"Signal buffer enables Analog test1",
			"Signal buffer enables Analog test2",
			"Signal buffer enables Analog test3",
			"Signal buffer enables Analog test4",
			"Signal buffer enables Analog Mux",
			"Signal settling time Analog test1 in us (1 LSB = 0.8 us)",
			"Signal settling time Analog test2 in us (1 LSB = 0.8 us)",
			"Signal settling time Analog test3 in us (1 LSB = 0.8 us)",
			"Signal settling time Analog test4 in us (1 LSB = 0.8 us)",
			"Signal settling time Analog Mux in us (1 LSB = 0.8 us)",
			"Signal settling time Analog Vsense in us (1 LSB = 0.8 us)",
			"Signal minimum threshold Analog test1 in Vol (1 LSB = 1.8V/256)",
			"Signal minimum threshold Analog test2 in Vol (1 LSB = 1.8V/256)",
			"Signal minimum threshold Analog test3 in Vol (1 LSB = 1.8V/256)",
			"Signal minimum threshold Analog test4 in Vol (1 LSB = 1.8V/256)",
			"Signal minimum threshold Analog Mux in Vol (1 LSB = 1.8V/256)",
			"Signal minimum threshold Analog Vsense in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog test1 in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog test2 in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog test3 in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog test4 in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog Mux in Vol (1 LSB = 1.8V/256)",
			"Signal maximum threshold Analog Vsense in Vol (1 LSB = 1.8V/256)",
			"out StatusFlag",
			"out  Errorcode",
			"out ExtAnalogSigtest1Val",
			"out ExtAnalogSigtest2Val",
			"out ExtAnalogSigtest3Val",
			"out ExtAnalogSigtest4Val",
			"out ExtAnalogSigmuxVal",
			"out ExtAnalogSigvsenseVal",
			"out Timestamp"
		})]
		public int SetRfExtAnaSignalsMonConfig(ushort RadarDeviceId, char ReportingMode, char SigIpEnaAnalogTest1, char SigIpEnaAnalogTest2, char SigIpEnaAnalogTest3, char SigIpEnaAnalogTest4, char SigIpEnaAnalogMux, char SigIpEnaAnalogVSense, char SigBufEnaAnalogTest1, char SigBufEnaAnalogTest2, char SigBufEnaAnalogTest3, char SigBufEnaAnalogTest4, char SigBufEnaAnalogMux, double SigSettlingTimeAnalogTest1, double SigSettlingTimeAnalogTest2, double SigSettlingTimeAnalogTest3, double SigSettlingTimeAnalogTest4, double SigSettlingTimeAnalogMux, double SigSettlingTimeAnalogVSense, double SigMinThresholdAnalogTest1, double SigMinThresholdAnalogTest2, double SigMinThresholdAnalogTest3, double SigMinThresholdAnalogTest4, double SigMinThresholdAnalogMux, double SigMinThresholdAnalogVSense, double SigMaxThresholdAnalogTest1, double SigMaxThresholdAnalogTest2, double SigMaxThresholdAnalogTest3, double SigMaxThresholdAnalogTest4, double SigMaxThresholdAnalogMux, double SigMaxThresholdAnalogVSense, out string StatusFlag, out string Errorcode, out string ExtAnalogSigtest1Val, out string ExtAnalogSigtest2Val, out string ExtAnalogSigtest3Val, out string ExtAnalogSigtest4Val, out string ExtAnalogSigmuxVal, out string ExtAnalogSigvsenseVal, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			ExtAnalogSigtest1Val = string.Empty;
			ExtAnalogSigtest2Val = string.Empty;
			ExtAnalogSigtest3Val = string.Empty;
			ExtAnalogSigtest4Val = string.Empty;
			ExtAnalogSigmuxVal = string.Empty;
			ExtAnalogSigvsenseVal = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetExternalAnalogSignalMonitoringConfData(RadarDeviceId, ReportingMode, SigIpEnaAnalogTest1, SigIpEnaAnalogTest2, SigIpEnaAnalogTest3, SigIpEnaAnalogTest4, SigIpEnaAnalogMux, SigIpEnaAnalogVSense, SigBufEnaAnalogTest1, SigBufEnaAnalogTest2, SigBufEnaAnalogTest3, SigBufEnaAnalogTest4, SigBufEnaAnalogMux, SigSettlingTimeAnalogTest1, SigSettlingTimeAnalogTest2, SigSettlingTimeAnalogTest3, SigSettlingTimeAnalogTest4, SigSettlingTimeAnalogMux, SigSettlingTimeAnalogVSense, SigMinThresholdAnalogTest1, SigMinThresholdAnalogTest2, SigMinThresholdAnalogTest3, SigMinThresholdAnalogTest4, SigMinThresholdAnalogMux, SigMinThresholdAnalogVSense, SigMaxThresholdAnalogTest1, SigMaxThresholdAnalogTest2, SigMaxThresholdAnalogTest3, SigMaxThresholdAnalogTest4, SigMaxThresholdAnalogMux, SigMaxThresholdAnalogVSense);
			return m_GuiManager.ScriptOps.UpdateNExternalAnalogSignalMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out ExtAnalogSigtest1Val, out ExtAnalogSigtest2Val, out ExtAnalogSigtest3Val, out ExtAnalogSigtest4Val, out ExtAnalogSigmuxVal, out ExtAnalogSigvsenseVal, out Timestamp);
		}

		[AttrLuaFunc("SetRfDualClkCompMonConfig", "SetRfDualClkCompMonConfig API which defines that configure the information related to DCC based clock  frequency monitoring and report the soft results from monitor", new string[]
		{
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"DCC Clock Pair0 enable or disable",
			"DCC Clock Pair1 enable or disable",
			"DCC Clock Pair2 enable or disable",
			"DCC Clock Pair3 enable or disable",
			"DCC Clock Pair4 enable or disable",
			"DCC Clock Pair5 enable or disable",
			"out StatusFlag",
			"out  Errorcode",
			"out FreqMeasclock0",
			"out FreqMeasclock1",
			"out FreqMeasclock2",
			"out FreqMeasclock3",
			"out FreqMeasclock4",
			"out FreqMeasclock5",
			"out Timestamp"
		})]
		public int SetRfDualClkCompMonConfig(char ReportingMode, char ClockPair0, char ClockPair1, char ClockPair2, char ClockPair3, char ClockPair4, char ClockPair5, out string StatusFlag, out string Errorcode, out string FreqMeasclock0, out string FreqMeasclock1, out string FreqMeasclock2, out string FreqMeasclock3, out string FreqMeasclock4, out string FreqMeasclock5, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			FreqMeasclock0 = string.Empty;
			FreqMeasclock1 = string.Empty;
			FreqMeasclock2 = string.Empty;
			FreqMeasclock3 = string.Empty;
			FreqMeasclock4 = string.Empty;
			FreqMeasclock5 = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetDCCMonitoringConfData(1, ReportingMode, ClockPair0, ClockPair1, ClockPair2, ClockPair3, ClockPair4, ClockPair5);
			return m_GuiManager.ScriptOps.UpdateNDCCMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out FreqMeasclock0, out FreqMeasclock1, out FreqMeasclock2, out FreqMeasclock3, out FreqMeasclock4, out FreqMeasclock5, out Timestamp);
		}

		[AttrLuaFunc("SetRfDualClkCompMonConfig_mult", " SetRfDualClkCompMonConfig API which defines that configure the information related to DCC based clock  frequency monitoring and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"DCC Clock Pair0 enable or disable",
			"DCC Clock Pair1 enable or disable",
			"DCC Clock Pair2 enable or disable",
			"DCC Clock Pair3 enable or disable",
			"DCC Clock Pair4 enable or disable",
			"DCC Clock Pair5 enable or disable",
			"out StatusFlag",
			"out  Errorcode",
			"out FreqMeasclock0",
			"out FreqMeasclock1",
			"out FreqMeasclock2",
			"out FreqMeasclock3",
			"out FreqMeasclock4",
			"out FreqMeasclock5",
			"out Timestamp"
		})]
		public int SetRfDualClkCompMonConfig(ushort RadarDeviceId, char ReportingMode, char ClockPair0, char ClockPair1, char ClockPair2, char ClockPair3, char ClockPair4, char ClockPair5, out string StatusFlag, out string Errorcode, out string FreqMeasclock0, out string FreqMeasclock1, out string FreqMeasclock2, out string FreqMeasclock3, out string FreqMeasclock4, out string FreqMeasclock5, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			FreqMeasclock0 = string.Empty;
			FreqMeasclock1 = string.Empty;
			FreqMeasclock2 = string.Empty;
			FreqMeasclock3 = string.Empty;
			FreqMeasclock4 = string.Empty;
			FreqMeasclock5 = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetDCCMonitoringConfData(RadarDeviceId, ReportingMode, ClockPair0, ClockPair1, ClockPair2, ClockPair3, ClockPair4, ClockPair5);
			return m_GuiManager.ScriptOps.UpdateNDCCMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out FreqMeasclock0, out FreqMeasclock1, out FreqMeasclock2, out FreqMeasclock3, out FreqMeasclock4, out FreqMeasclock5, out Timestamp);
		}

		[AttrLuaFunc("SetRfPllContrlVoltMonConfig", " SetRfPllContrlVoltMonConfig API which defines that configure the information related to APLL and synthesizer voltage control signals monitoring and report the soft results from monitor", new string[]
		{
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"APPL voltage control signal enable or disable",
			"Synth VCO1 voltage control signal enable or disable",
			"Synth VCO2 voltage control signal enable or disable",
			"out StatusFlag",
			"out  Errorcode",
			"out APLLvolCtl",
			"out SynthVCO1volCtlMaxFreq",
			"out SynthVCO1volCtlMinFreq",
			"out SynthVCO1slope",
			"out SynthVCO2volCtlMaxFreq",
			"out SynthVCO2volCtlMinFreq",
			"out SynthVCO2slope",
			"out Timestamp"
		})]
		public int SetRfPllContrlVoltMonConfig(char ReportingMode, char APLLVctl, char SynthVCO1VoltageControl, char SynthVCO2VoltageControl, out string StatusFlag, out string Errorcode, out string APLLvolCtl, out string p7, out string p8, out string SynthVCO1slope, out string p10, out string p11, out string SynthVCO2slope, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			APLLvolCtl = string.Empty;
			p7 = string.Empty;
			p8 = string.Empty;
			SynthVCO1slope = string.Empty;
			p10 = string.Empty;
			p11 = string.Empty;
			SynthVCO2slope = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetPLLControlVolSignalsMonitoringConfData(1, ReportingMode, APLLVctl, SynthVCO1VoltageControl, SynthVCO2VoltageControl);
			return m_GuiManager.ScriptOps.UpdateNPLLControlVolSignalsMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out APLLvolCtl, out p7, out p8, out SynthVCO1slope, out p10, out p11, out SynthVCO2slope, out Timestamp);
		}

		[AttrLuaFunc("SetRfPllContrlVoltMonConfig_mult", " SetRfPllContrlVoltMonConfig API which defines that configure the information related to APLL and synthesizer voltage control signals monitoring and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"APPL voltage control signal enable or disable",
			"Synth VCO1 voltage control signal enable or disable",
			"Synth VCO2 voltage control signal enable or disable",
			"out StatusFlag",
			"out  Errorcode",
			"out APLLvolCtl",
			"out SynthVCO1volCtlMaxFreq",
			"out SynthVCO1volCtlMinFreq",
			"out SynthVCO1slope",
			"out SynthVCO2volCtlMaxFreq",
			"out SynthVCO2volCtlMinFreq",
			"out SynthVCO2slope",
			"out Timestamp"
		})]
		public int SetRfPllContrlVoltMonConfig(ushort RadarDeviceId, char ReportingMode, char APLLVctl, char SynthVCO1VoltageControl, char SynthVCO2VoltageControl, out string StatusFlag, out string Errorcode, out string APLLvolCtl, out string p8, out string p9, out string SynthVCO1slope, out string p11, out string p12, out string SynthVCO2slope, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			APLLvolCtl = string.Empty;
			p8 = string.Empty;
			p9 = string.Empty;
			SynthVCO1slope = string.Empty;
			p11 = string.Empty;
			p12 = string.Empty;
			SynthVCO2slope = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetPLLControlVolSignalsMonitoringConfData(RadarDeviceId, ReportingMode, APLLVctl, SynthVCO1VoltageControl, SynthVCO2VoltageControl);
			return m_GuiManager.ScriptOps.UpdateNPLLControlVolSignalsMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out APLLvolCtl, out p8, out p9, out SynthVCO1slope, out p11, out p12, out SynthVCO2slope, out Timestamp);
		}

		[AttrLuaFunc("SetRfSynthFreqMonConfig", " SetRfSynthFreqMonConfig API which defines that configure the information related to synthesizer frequency monitoring during chirping and report the soft results from monitor", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Frequency Error Threshold value compared measured chirp during chirp in kHz (1 LSB = 10 kHz)",
			"This determines when the monitoring starts in each chirp relative to start  of the ramp in us (1 LSB = 1 us)",
			"out StatusFlag",
			"out  Errorcode",
			"out Profileindex",
			"out MaxFreqErrorVal",
			"out FrequencyFailureCount",
			"out Timestamp"
		})]
		public int SetRfSynthFreqMonConfig(char ProfileIndex, char ReportingMode, ushort FreqErrorThreshold, double MonStartTime, out string StatusFlag, out string Errorcode, out string Profileindex, out string MaxFreqErrorVal, out string FrequencyFailureCount, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			MaxFreqErrorVal = string.Empty;
			FrequencyFailureCount = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetSynthFrequencyErrorMonitoringConfData(1, ProfileIndex, ReportingMode, FreqErrorThreshold, MonStartTime);
			return m_GuiManager.ScriptOps.UpdateNSynthFrequencyErrorMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out MaxFreqErrorVal, out FrequencyFailureCount, out Timestamp);
		}

		[AttrLuaFunc("SetRfSynthFreqMonConfig_mult", " SetRfSynthFreqMonConfig API which defines that configure the information related to synthesizer frequency monitoring during chirping and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Frequency Error Threshold value compared measured chirp during chirp in kHz (1 LSB = 10 kHz)",
			"This determines when the monitoring starts in each chirp relative to start  of the ramp in us (1 LSB = 0.2 us)",
			"out StatusFlag",
			"out  Errorcode",
			"out Profileindex",
			"out MaxFreqErrorVal",
			"out FrequencyFailureCount",
			"out Timestamp"
		})]
		public int SetRfSynthFreqMonConfig(ushort RadarDeviceId, char ProfileIndex, char ReportingMode, ushort FreqErrorThreshold, double MonStartTime, out string StatusFlag, out string Errorcode, out string Profileindex, out string MaxFreqErrorVal, out string FrequencyFailureCount, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			MaxFreqErrorVal = string.Empty;
			FrequencyFailureCount = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetSynthFrequencyErrorMonitoringConfData(RadarDeviceId, ProfileIndex, ReportingMode, FreqErrorThreshold, MonStartTime);
			return m_GuiManager.ScriptOps.UpdateNSynthFrequencyErrorMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out MaxFreqErrorVal, out FrequencyFailureCount, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx0PowMonConfig", " SetRfTx0PowMonConfig API which defines that configure the monitors of TX0 transmitter output power and report the soft results from monitor", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx Power Absolute Error Threshold in dB(1LSB = 0.1dB)",
			"Tx Power Flatness Error Threshold in dB(1LSB = 0.1dB)",
			"out StatusFlags",
			"out  ErrorCode",
			"out ProfileIndex",
			"out RF1TxPowerValue",
			"out RF2TxPowerValue",
			"out RF3TxPowerValue",
			"out TimeStamp"
		})]
		public int SetRfTx0PowMonConfig(char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char ReportingMode, double TxPowerAbsoluteErrorThreshold, double TxPowerFlatnessErrorThreshold, out string StatusFlags, out string ErrorCode, out string profileIndex, out string RF1TxPowerValue, out string RF2TxPowerValue, out string RF3TxPowerValue, out string TimeStamp)
		{
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			profileIndex = string.Empty;
			RF1TxPowerValue = string.Empty;
			RF2TxPowerValue = string.Empty;
			RF3TxPowerValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx1PowerMonitoringConfData(1, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, ReportingMode, TxPowerAbsoluteErrorThreshold, TxPowerFlatnessErrorThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx1PowerMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out profileIndex, out RF1TxPowerValue, out RF2TxPowerValue, out RF3TxPowerValue, out TimeStamp);
		}

		[AttrLuaFunc("SetRfTx0PowMonConfig_mult", " SetRfTx0PowMonConfig API which defines that configure the monitors of TX0 transmitter output power and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx Power Absolute Error Threshold in dB(1LSB = 0.1dB)",
			"Tx Power Flatness Error Threshold in dB(1LSB = 0.1dB)",
			"out StatusFlags",
			"out  ErrorCode",
			"out ProfileIndex",
			"out RF1TxPowerValue",
			"out RF2TxPowerValue",
			"out RF3TxPowerValue",
			"out TimeStamp"
		})]
		public int SetRfTx0PowMonConfig(ushort RadarDeviceId, char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char ReportingMode, double TxPowerAbsoluteErrorThreshold, double TxPowerFlatnessErrorThreshold, out string StatusFlags, out string ErrorCode, out string profileIndex, out string RF1TxPowerValue, out string RF2TxPowerValue, out string RF3TxPowerValue, out string TimeStamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			profileIndex = string.Empty;
			RF1TxPowerValue = string.Empty;
			RF2TxPowerValue = string.Empty;
			RF3TxPowerValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx1PowerMonitoringConfData(RadarDeviceId, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, ReportingMode, TxPowerAbsoluteErrorThreshold, TxPowerFlatnessErrorThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx1PowerMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out profileIndex, out RF1TxPowerValue, out RF2TxPowerValue, out RF3TxPowerValue, out TimeStamp);
		}

		[AttrLuaFunc("SetRfTx1PowMonConfig", " SetRfTx1PowMonConfig API which defines that configure the monitors of TX1 transmitter output power and report the soft results from monitor", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx Power Absolute Error Threshold in dB(1LSB = 0.1dB)",
			"Tx Power Flatness Error Threshold in dB(1LSB = 0.1dB)",
			"out StatusFlags",
			"out  ErrorCode",
			"out ProfileIndex",
			"out RF1TxPowerValue",
			"out RF2TxPowerValue",
			"out RF3TxPowerValue",
			"out TimeStamp"
		})]
		public int SetRfTx1PowMonConfig(char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char ReportingMode, double TxPowerAbsoluteErrorThreshold, double TxPowerFlatnessErrorThreshold, out string StatusFlags, out string ErrorCode, out string profileIndex, out string RF1TxPowerValue, out string RF2TxPowerValue, out string RF3TxPowerValue, out string TimeStamp)
		{
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			profileIndex = string.Empty;
			RF1TxPowerValue = string.Empty;
			RF2TxPowerValue = string.Empty;
			RF3TxPowerValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx2PowerMonitoringConfData(1, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, ReportingMode, TxPowerAbsoluteErrorThreshold, TxPowerFlatnessErrorThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx2PowerMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out profileIndex, out RF1TxPowerValue, out RF2TxPowerValue, out RF3TxPowerValue, out TimeStamp);
		}

		[AttrLuaFunc("SetRfTx1PowMonConfig_mult", " SetRfTx1PowMonConfig API which defines that configure the monitors of TX1 transmitter output power and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx Power Absolute Error Threshold in dB(1LSB = 0.1dB)",
			"Tx Power Flatness Error Threshold in dB(1LSB = 0.1dB)",
			"out StatusFlags",
			"out  ErrorCode",
			"out ProfileIndex",
			"out RF1TxPowerValue",
			"out RF2TxPowerValue",
			"out RF3TxPowerValue",
			"out TimeStamp"
		})]
		public int SetRfTx1PowMonConfig(ushort RadarDeviceId, char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char ReportingMode, double TxPowerAbsoluteErrorThreshold, double TxPowerFlatnessErrorThreshold, out string StatusFlags, out string ErrorCode, out string profileIndex, out string RF1TxPowerValue, out string RF2TxPowerValue, out string RF3TxPowerValue, out string TimeStamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			profileIndex = string.Empty;
			RF1TxPowerValue = string.Empty;
			RF2TxPowerValue = string.Empty;
			RF3TxPowerValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx2PowerMonitoringConfData(RadarDeviceId, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, ReportingMode, TxPowerAbsoluteErrorThreshold, TxPowerFlatnessErrorThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx2PowerMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out profileIndex, out RF1TxPowerValue, out RF2TxPowerValue, out RF3TxPowerValue, out TimeStamp);
		}

		[AttrLuaFunc("SetRfTx2PowMonConfig", " SetRfTx2PowMonConfig API which defines that configure the monitors of TX2 transmitter output power and report the soft results from monitor", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx Power Absolute Error Threshold in dB(1LSB = 0.1dB)",
			"Tx Power Flatness Error Threshold in dB(1LSB = 0.1dB)",
			"out StatusFlags",
			"out  ErrorCode",
			"out ProfileIndex",
			"out RF1TxPowerValue",
			"out RF2TxPowerValue",
			"out RF3TxPowerValue",
			"out TimeStamp"
		})]
		public int SetRfTx2PowMonConfig(char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char ReportingMode, double TxPowerAbsoluteErrorThreshold, double TxPowerFlatnessErrorThreshold, out string StatusFlags, out string ErrorCode, out string profileIndex, out string RF1TxPowerValue, out string RF2TxPowerValue, out string RF3TxPowerValue, out string TimeStamp)
		{
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			profileIndex = string.Empty;
			RF1TxPowerValue = string.Empty;
			RF2TxPowerValue = string.Empty;
			RF3TxPowerValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx3PowerMonitoringConfData(1, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, ReportingMode, TxPowerAbsoluteErrorThreshold, TxPowerFlatnessErrorThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx3PowerMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out profileIndex, out RF1TxPowerValue, out RF2TxPowerValue, out RF3TxPowerValue, out TimeStamp);
		}

		[AttrLuaFunc("SetRfTx2PowMonConfig_mult", " SetRfTx2PowMonConfig API which defines that configure the monitors of TX2 transmitter output power and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx Power Absolute Error Threshold in dB(1LSB = 0.1dB)",
			"Tx Power Flatness Error Threshold in dB(1LSB = 0.1dB)",
			"out StatusFlags",
			"out  ErrorCode",
			"out ProfileIndex",
			"out RF1TxPowerValue",
			"out RF2TxPowerValue",
			"out RF3TxPowerValue",
			"out TimeStamp"
		})]
		public int SetRfTx2PowMonConfig(ushort RadarDeviceId, char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char ReportingMode, double TxPowerAbsoluteErrorThreshold, double TxPowerFlatnessErrorThreshold, out string StatusFlags, out string ErrorCode, out string profileIndex, out string RF1TxPowerValue, out string RF2TxPowerValue, out string RF3TxPowerValue, out string TimeStamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			profileIndex = string.Empty;
			RF1TxPowerValue = string.Empty;
			RF2TxPowerValue = string.Empty;
			RF3TxPowerValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx3PowerMonitoringConfData(RadarDeviceId, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, ReportingMode, TxPowerAbsoluteErrorThreshold, TxPowerFlatnessErrorThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx3PowerMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out profileIndex, out RF1TxPowerValue, out RF2TxPowerValue, out RF3TxPowerValue, out TimeStamp);
		}

		[AttrLuaFunc("DeviceLatentFaultConfig", " DeviceLatentFaultConfig API which used to trigger the periodic tests in MSS", new string[]
		{
			"Test enables 1",
			"Test enables 2",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode)",
			"Test mode, Production mode:0, Characterization mode:1",
			"Reserved parameter",
			"out TestStatusFlag1",
			"out TestStatusFlag2",
			"Reserved1"
		})]
		public int DeviceLatentFaultConfig(uint TestEna1, uint TestEna2, char ReportingMode, char TestMode, ushort Reserved, out string TestStatusFlag1, out string TestStatusFlag2, out string Reserved1)
		{
			TestStatusFlag1 = string.Empty;
			TestStatusFlag2 = string.Empty;
			Reserved1 = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetMSSLatentFaultTestMonitoringConfData(1, TestEna1, TestEna2, ReportingMode, TestMode, Reserved);
			return m_GuiManager.ScriptOps.UpdateNMSSLatentFaultMonitoringConfigurationData_cmd(out TestStatusFlag1, out TestStatusFlag2, out Reserved1);
		}

		[AttrLuaFunc("DeviceLatentFaultConfig_mult", " DeviceLatentFaultConfig API which used to trigger the periodic tests in MSS", new string[]
		{
			"Radar Device Id",
			"Test enables 1",
			"Test enables 2",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode)",
			"Test mode, Production mode:0, Characterization mode:1",
			"Reserved parameter",
			"out TestStatusFlag1",
			"out TestStatusFlag2",
			"Reserved1"
		})]
		public int DeviceLatentFaultConfig(ushort RadarDeviceId, uint TestEna1, uint TestEna2, char ReportingMode, char TestMode, ushort Reserved, out string TestStatusFlag1, out string TestStatusFlag2, out string Reserved1)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			TestStatusFlag1 = string.Empty;
			TestStatusFlag2 = string.Empty;
			Reserved1 = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetMSSLatentFaultTestMonitoringConfData(RadarDeviceId, TestEna1, TestEna2, ReportingMode, TestMode, Reserved);
			return m_GuiManager.ScriptOps.UpdateNMSSLatentFaultMonitoringConfigurationData_cmd(out TestStatusFlag1, out TestStatusFlag2, out Reserved1);
		}

		[AttrLuaFunc("DevicePeriodicTestsConfig", " DevicePeriodicTestsConfig API which used to trigger the periodic tests in MSS", new string[]
		{
			"periodicity at which tests need to be run in ms",
			"Test enables 0:Periodicity config reg read enable , 1:ESM monitoring enable",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode)",
			"Reserved parameter",
			"out TestStatusFlag"
		})]
		public int DevicePeriodicTestsConfig(uint Periodicity, uint TestEna, char ReportingMode, ushort Reserved, out string TestStatusFlag)
		{
			TestStatusFlag = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetMSSPeriodicTestMonitoringConfData(1, Periodicity, TestEna, ReportingMode, Reserved);
			return m_GuiManager.ScriptOps.UpdateNMSSPeriodicMonitoringConfigurationData_cmd(out TestStatusFlag);
		}

		[AttrLuaFunc("DevicePeriodicTestsConfig_mult", " DevicePeriodicTestsConfig API which used to trigger the periodic tests in MSS", new string[]
		{
			"periodicity at which tests need to be run in ms",
			"Radar Device Id",
			"Test enables 0:Periodicity config reg read enable , 1:ESM monitoring enable",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode)",
			"Reserved parameter",
			"out TestStatusFlag"
		})]
		public int DevicePeriodicTestsConfig(ushort RadarDeviceId, uint Periodicity, uint TestEna, char ReportingMode, ushort Reserved, out string TestStatusFlag)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			TestStatusFlag = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetMSSPeriodicTestMonitoringConfData(RadarDeviceId, Periodicity, TestEna, ReportingMode, Reserved);
			return m_GuiManager.ScriptOps.UpdateNMSSPeriodicMonitoringConfigurationData_cmd(out TestStatusFlag);
		}

		[AttrLuaFunc("SetRfRxNoiseMonConfig", " SetRfRxNoiseMonConfig API which defines that configure the manitor of reciever noise and report the soft results from monitor", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"RX Noise Figure Threshold in dB (1 LSB = 0.1dB )",
			"out StatusFlag",
			"out Errorcode",
			"out Profileindex",
			"out RF1Rx1powervalue",
			"out RF1Rx2powervalue",
			"out RF1Rx3powervalue",
			"out RF1Rx4powervalue",
			"out RF2Rx1powervalue",
			"out RF2Rx2powervalue",
			"out RF2Rx3powervalue",
			"out RF2Rx4powervalue",
			"out RF3Rx1powervalue",
			"out RF3Rx2powervalue",
			"out RF3Rx3powervalue",
			"out RF3Rx4powervalue",
			"out Timestamp"
		})]
		public int SetRfRxNoiseMonConfig(char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char ReportingMode, double RXNoiseFigureThreshold, out string StatusFlag, out string Errorcode, out string Profileindex, out string p9, out string p10, out string p11, out string p12, out string p13, out string p14, out string p15, out string p16, out string p17, out string p18, out string p19, out string p20, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			p9 = string.Empty;
			p10 = string.Empty;
			p11 = string.Empty;
			p12 = string.Empty;
			p13 = string.Empty;
			p14 = string.Empty;
			p15 = string.Empty;
			p16 = string.Empty;
			p17 = string.Empty;
			p18 = string.Empty;
			p19 = string.Empty;
			p20 = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRxNoisefigureMonitoringConfData(1, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, ReportingMode, RXNoiseFigureThreshold);
			return m_GuiManager.ScriptOps.UpdateNRxNoisefigureMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out p9, out p10, out p11, out p12, out p13, out p14, out p15, out p16, out p17, out p18, out p19, out p20, out Timestamp);
		}

		[AttrLuaFunc("SetRfRxNoiseMonConfig_mult", " SetRfRxNoiseMonConfig API which defines that configure the manitor of reciever noise and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"RX Noise Figure Threshold in dB (1 LSB = 0.1dB )",
			"out StatusFlag",
			"out Errorcode",
			"out Profileindex",
			"out RF1Rx1powervalue",
			"out RF1Rx2powervalue",
			"out RF1Rx3powervalue",
			"out RF1Rx4powervalue",
			"out RF2Rx1powervalue",
			"out RF2Rx2powervalue",
			"out RF2Rx3powervalue",
			"out RF2Rx4powervalue",
			"out RF3Rx1powervalue",
			"out RF3Rx2powervalue",
			"out RF3Rx3powervalue",
			"out RF3Rx4powervalue",
			"out Timestamp"
		})]
		public int SetRfRxNoiseMonConfig(ushort RadarDeviceId, char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char ReportingMode, double RXNoiseFigureThreshold, out string StatusFlag, out string Errorcode, out string Profileindex, out string p10, out string p11, out string p12, out string p13, out string p14, out string p15, out string p16, out string p17, out string p18, out string p19, out string p20, out string p21, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			p10 = string.Empty;
			p11 = string.Empty;
			p12 = string.Empty;
			p13 = string.Empty;
			p14 = string.Empty;
			p15 = string.Empty;
			p16 = string.Empty;
			p17 = string.Empty;
			p18 = string.Empty;
			p19 = string.Empty;
			p20 = string.Empty;
			p21 = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRxNoisefigureMonitoringConfData(RadarDeviceId, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, ReportingMode, RXNoiseFigureThreshold);
			return m_GuiManager.ScriptOps.UpdateNRxNoisefigureMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out p10, out p11, out p12, out p13, out p14, out p15, out p16, out p17, out p18, out p19, out p20, out p21, out Timestamp);
		}

		[AttrLuaFunc("SetRfInterRxGainPhFreqConfig", "SetRfInterRxGainPhFreqConfig API which used to induce diffwrent gain or phase or frequency offsets on the different RXs, for inter-RX mismatch compensation ", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"Rx0 digital gain",
			"Rx1 digital gain",
			"Rx2 digital gain",
			"Rx3 digital gain",
			"Rx0 digital phase shift",
			"Rx1 digital phase shift",
			" Rx2 digital phase shift",
			" Rx3 digital phase shift",
			"Rx0 digital Frequency shift in Hz",
			"Rx1 digital Frequency shift in Hz",
			" Rx2 digital Frequency shift in Hz",
			" Rx3 digital Frequency shift in Hz"
		})]
		public int SetRfInterRxGainPhFreqConfig(char ProfileIndex, double Rx0DigitalGain, double Rx1DigitalGain, double Rx2DigitalGain, double Rx3DigitalGain, double Rx0DigitalPhaseShift, double Rx1DigitalPhaseShift, double Rx2DigitalPhaseShift, double Rx3DigitalPhaseShift, double Rx0DigitalFreqShift, double Rx1DigitalFreqShift, double Rx2DigitalFreqShift, double Rx3DigitalFreqShift)
		{
			return m_GuiManager.ScriptOps.UpdateNSetInterRxGainPhaseFreqControlConfData(1, ProfileIndex, Rx0DigitalGain, Rx1DigitalGain, Rx2DigitalGain, Rx3DigitalGain, Rx0DigitalPhaseShift, Rx1DigitalPhaseShift, Rx2DigitalPhaseShift, Rx3DigitalPhaseShift, Rx0DigitalFreqShift, Rx1DigitalFreqShift, Rx2DigitalFreqShift, Rx3DigitalFreqShift);
		}

		[AttrLuaFunc("SetRfMixerInpPowMonConfig", "SetRfMixerInpPowMonConfig API which defines that configure related information to Rx mixer input power monitoring", new string[]
		{
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Profile Index for which this monitoring cofig applies",
			"Tx1 Enable",
			"Tx2 Enable",
			"Tx3Enable",
			"MinThresholds(b0:15), MaxThresholds(b16:31) in mV (1 LSB = 1800mV/256)",
			"out StatusFlag",
			"out Errorcode",
			"out ProfileId",
			"out Rx1MixerInputVolVal",
			"out Rx2MixerInputVolVal",
			"out Rx3MixerInputVolVal",
			"out Rx4MixerInputVolVal",
			"out TimeStamp"
		})]
		public int SetRfMixerInpPowMonConfig(char ReportingMode, char ProfileIndex, char Tx1Enable, char Tx2Enable, char Tx3Enable, uint Thresholds, out string StatusFlag, out string Errorcode, out string ProfileId, out string Rx1MixerInputVolVal, out string Rx2MixerInputVolVal, out string Rx3MixerInputVolVal, out string Rx4MixerInputVolVal, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Rx1MixerInputVolVal = string.Empty;
			Rx2MixerInputVolVal = string.Empty;
			Rx3MixerInputVolVal = string.Empty;
			Rx4MixerInputVolVal = string.Empty;
			Timestamp = string.Empty;
			ProfileId = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRxMixerInputPowerMonitroingConfData(1, ReportingMode, ProfileIndex, Tx1Enable, Tx2Enable, Tx3Enable, Thresholds);
			return m_GuiManager.ScriptOps.UpdateNRxMixerInputPowerMonitroingConfigurationData_cmd(out StatusFlag, out Errorcode, out ProfileId, out Rx1MixerInputVolVal, out Rx2MixerInputVolVal, out Rx3MixerInputVolVal, out Rx4MixerInputVolVal, out Timestamp);
		}

		[AttrLuaFunc("SetRfMixerInpPowMonConfig_mult", "SetRfMixerInpPowMonConfig API which defines that configure related information to Rx mixer input power monitoring", new string[]
		{
			"Radar Device Id",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Profile Index for which this monitoring cofig applies",
			"Tx1 Enable",
			"Tx2 Enable",
			"Tx3Enable",
			"MinThresholds(b0:15), MaxThresholds(b16:31) in mV (1 LSB = 1800mV/256)",
			"out StatusFlag",
			"out Errorcode",
			"out ProfileId",
			"out Rx1MixerInputVolVal",
			"out Rx2MixerInputVolVal",
			"out Rx3MixerInputVolVal",
			"out Rx4MixerInputVolVal",
			"out TimeStamp"
		})]
		public int SetRfMixerInpPowMonConfig(ushort RadarDeviceId, char ReportingMode, char ProfileIndex, char Tx1Enable, char Tx2Enable, char Tx3Enable, uint Thresholds, out string StatusFlag, out string Errorcode, out string ProfileId, out string Rx1MixerInputVolVal, out string Rx2MixerInputVolVal, out string Rx3MixerInputVolVal, out string Rx4MixerInputVolVal, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Rx1MixerInputVolVal = string.Empty;
			Rx2MixerInputVolVal = string.Empty;
			Rx3MixerInputVolVal = string.Empty;
			Rx4MixerInputVolVal = string.Empty;
			Timestamp = string.Empty;
			ProfileId = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRxMixerInputPowerMonitroingConfData(RadarDeviceId, ReportingMode, ProfileIndex, Tx1Enable, Tx2Enable, Tx3Enable, Thresholds);
			return m_GuiManager.ScriptOps.UpdateNRxMixerInputPowerMonitroingConfigurationData_cmd(out StatusFlag, out Errorcode, out ProfileId, out Rx1MixerInputVolVal, out Rx2MixerInputVolVal, out Rx3MixerInputVolVal, out Rx4MixerInputVolVal, out Timestamp);
		}

		[AttrLuaFunc("SetRfRxIfStageMonConfig", "SetRfRxIfStageMonConfig API which defines that configure the manitor of reciever IF filter attenuation and report the soft results from monitor", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Absolute values of HPF IF Cutoff frequency error in % (1 LSB = 1% )",
			"Absolute values of IF LPF Cutoff frequency error in % (1 LSB = 1% )",
			" Absolute deviation values of Rx IFA gain error in dB (1 LSB = 0.1dB )",
			"out StatusFlag",
			"out Errorcode",
			"out Profileindex",
			"out Rx1IChHPFCutoffFreqErrVal",
			"out Rx2IChHPFCutoffFreqErrVal",
			"out Rx3IChHPFCutoffFreqErrVal",
			"out Rx4IChHPFCutoffFreqErrVal",
			"out Rx1QChHPFCutoffFreqErrVal",
			"out Rx2QChHPFCutoffFreqErrVal",
			"out Rx3QChHPFCutoffFreqErrVal",
			"out Rx4QChHPFCutoffFreqErrVal",
			"out Rx1IChLPFCutoffFreqErrVal",
			"out Rx2IChLPFCutoffFreqErrVal",
			"out Rx3IChLPFCutoffFreqErrVal",
			"out Rx4IChLPFCutoffFreqErrVal",
			"out Rx1QChLPFCutoffFreqErrVal",
			"out Rx2QChLPFCutoffFreqErrVal",
			"out Rx3QChLPFCutoffFreqErrVal",
			"out Rx4QChLPFCutoffFreqErrVal",
			"out Rx1IChRxIFAGainErrVal",
			"out Rx2IChRxIFAGainErrVal",
			"out Rx3IChRxIFAGainErrVal",
			"out Rx4IChRxIFAGainErrVal",
			"out Rx1QChRxIFAGainErrVal",
			"out Rx2QChRxIFAGainErrVal",
			"out Rx3QChRxIFAGainErrVal",
			"out Rx4QChRxIFAGainErrVal",
			"Out ProgIFAGain",
			"out Timestamp"
		})]
		public int SetRfRxIfStageMonConfig(char ProfileIndex, char ReportingMode, ushort HPFCutofFreqErrorThreshold, ushort LPFCutofFreqErrorThreshold, double IFAGainErrorThreshold, out string StatusFlag, out string Errorcode, out string Profileindex, out string Rx1IChHPFCutoffFreqErrVal, out string Rx2IChHPFCutoffFreqErrVal, out string Rx3IChHPFCutoffFreqErrVal, out string Rx4IChHPFCutoffFreqErrVal, out string Rx1QChHPFCutoffFreqErrVal, out string Rx2QChHPFCutoffFreqErrVal, out string Rx3QChHPFCutoffFreqErrVal, out string Rx4QChHPFCutoffFreqErrVal, out string Rx1IChLPFCutoffFreqErrVal, out string Rx2IChLPFCutoffFreqErrVal, out string Rx3IChLPFCutoffFreqErrVal, out string Rx4IChLPFCutoffFreqErrVal, out string Rx1QChLPFCutoffFreqErrVal, out string Rx2QChLPFCutoffFreqErrVal, out string Rx3QChLPFCutoffFreqErrVal, out string Rx4QChLPFCutoffFreqErrVal, out string Rx1IChRxIFAGainErrVal, out string Rx2IChRxIFAGainErrVal, out string Rx3IChRxIFAGainErrVal, out string Rx4IChRxIFAGainErrVal, out string Rx1QChRxIFAGainErrVal, out string Rx2QChRxIFAGainErrVal, out string Rx3QChRxIFAGainErrVal, out string Rx4QChRxIFAGainErrVal, out string ProgIFAGain, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			Rx1IChHPFCutoffFreqErrVal = string.Empty;
			Rx2IChHPFCutoffFreqErrVal = string.Empty;
			Rx3IChHPFCutoffFreqErrVal = string.Empty;
			Rx4IChHPFCutoffFreqErrVal = string.Empty;
			Rx1QChHPFCutoffFreqErrVal = string.Empty;
			Rx2QChHPFCutoffFreqErrVal = string.Empty;
			Rx3QChHPFCutoffFreqErrVal = string.Empty;
			Rx4QChHPFCutoffFreqErrVal = string.Empty;
			Rx1IChLPFCutoffFreqErrVal = string.Empty;
			Rx2IChLPFCutoffFreqErrVal = string.Empty;
			Rx3IChLPFCutoffFreqErrVal = string.Empty;
			Rx4IChLPFCutoffFreqErrVal = string.Empty;
			Rx1QChLPFCutoffFreqErrVal = string.Empty;
			Rx2QChLPFCutoffFreqErrVal = string.Empty;
			Rx3QChLPFCutoffFreqErrVal = string.Empty;
			Rx4QChLPFCutoffFreqErrVal = string.Empty;
			Rx1IChRxIFAGainErrVal = string.Empty;
			Rx2IChRxIFAGainErrVal = string.Empty;
			Rx3IChRxIFAGainErrVal = string.Empty;
			Rx4IChRxIFAGainErrVal = string.Empty;
			Rx1QChRxIFAGainErrVal = string.Empty;
			Rx2QChRxIFAGainErrVal = string.Empty;
			Rx3QChRxIFAGainErrVal = string.Empty;
			Rx4QChRxIFAGainErrVal = string.Empty;
			ProgIFAGain = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRxIFStageMonitoringConfData(1, ProfileIndex, ReportingMode, HPFCutofFreqErrorThreshold, LPFCutofFreqErrorThreshold, IFAGainErrorThreshold);
			return m_GuiManager.ScriptOps.UpdateNRxIFStageMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out Rx1IChHPFCutoffFreqErrVal, out Rx2IChHPFCutoffFreqErrVal, out Rx3IChHPFCutoffFreqErrVal, out Rx4IChHPFCutoffFreqErrVal, out Rx1QChHPFCutoffFreqErrVal, out Rx2QChHPFCutoffFreqErrVal, out Rx3QChHPFCutoffFreqErrVal, out Rx4QChHPFCutoffFreqErrVal, out Rx1IChLPFCutoffFreqErrVal, out Rx2IChLPFCutoffFreqErrVal, out Rx3IChLPFCutoffFreqErrVal, out Rx4IChLPFCutoffFreqErrVal, out Rx1QChLPFCutoffFreqErrVal, out Rx2QChLPFCutoffFreqErrVal, out Rx3QChLPFCutoffFreqErrVal, out Rx4QChLPFCutoffFreqErrVal, out Rx1IChRxIFAGainErrVal, out Rx2IChRxIFAGainErrVal, out Rx3IChRxIFAGainErrVal, out Rx4IChRxIFAGainErrVal, out Rx1QChRxIFAGainErrVal, out Rx2QChRxIFAGainErrVal, out Rx3QChRxIFAGainErrVal, out Rx4QChRxIFAGainErrVal, out ProgIFAGain, out Timestamp);
		}

		[AttrLuaFunc("SetRfRxIfStageMonConfig_mult", "SetRfRxIfStageMonConfig API which defines that configure the manitor of reciever IF filter attenuation and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Absolute values of HPF IF Cutoff frequency error in % (1 LSB = 1% )",
			"Absolute values of IF LPF Cutoff frequency error in % (1 LSB = 1% )",
			" Absolute deviation values of Rx IFA gain error in dB (1 LSB = 0.1dB )",
			"out StatusFlag",
			"out Errorcode",
			"out Profileindex",
			"out Rx1IChHPFCutoffFreqErrVal",
			"out Rx2IChHPFCutoffFreqErrVal",
			"out Rx3IChHPFCutoffFreqErrVal",
			"out Rx4IChHPFCutoffFreqErrVal",
			"out Rx1QChHPFCutoffFreqErrVal",
			"out Rx2QChHPFCutoffFreqErrVal",
			"out Rx3QChHPFCutoffFreqErrVal",
			"out Rx4QChHPFCutoffFreqErrVal",
			"out Rx1IChLPFCutoffFreqErrVal",
			"out Rx2IChLPFCutoffFreqErrVal",
			"out Rx3IChLPFCutoffFreqErrVal",
			"out Rx4IChLPFCutoffFreqErrVal",
			"out Rx1QChLPFCutoffFreqErrVal",
			"out Rx2QChLPFCutoffFreqErrVal",
			"out Rx3QChLPFCutoffFreqErrVal",
			"out Rx4QChLPFCutoffFreqErrVal",
			"out Rx1IChRxIFAGainErrVal",
			"out Rx2IChRxIFAGainErrVal",
			"out Rx3IChRxIFAGainErrVal",
			"out Rx4IChRxIFAGainErrVal",
			"out Rx1QChRxIFAGainErrVal",
			"out Rx2QChRxIFAGainErrVal",
			"out Rx3QChRxIFAGainErrVal",
			"out Rx4QChRxIFAGainErrVal",
			"out ProgIFAGain",
			"out Timestamp"
		})]
		public int SetRfRxIfStageMonConfig(ushort RadarDeviceId, char ProfileIndex, char ReportingMode, ushort HPFCutofFreqErrorThreshold, ushort LPFCutofFreqErrorThreshold, double IFAGainErrorThreshold, out string StatusFlag, out string Errorcode, out string Profileindex, out string Rx1IChHPFCutoffFreqErrVal, out string Rx2IChHPFCutoffFreqErrVal, out string Rx3IChHPFCutoffFreqErrVal, out string Rx4IChHPFCutoffFreqErrVal, out string Rx1QChHPFCutoffFreqErrVal, out string Rx2QChHPFCutoffFreqErrVal, out string Rx3QChHPFCutoffFreqErrVal, out string Rx4QChHPFCutoffFreqErrVal, out string Rx1IChLPFCutoffFreqErrVal, out string Rx2IChLPFCutoffFreqErrVal, out string Rx3IChLPFCutoffFreqErrVal, out string Rx4IChLPFCutoffFreqErrVal, out string Rx1QChLPFCutoffFreqErrVal, out string Rx2QChLPFCutoffFreqErrVal, out string Rx3QChLPFCutoffFreqErrVal, out string Rx4QChLPFCutoffFreqErrVal, out string Rx1IChRxIFAGainErrVal, out string Rx2IChRxIFAGainErrVal, out string Rx3IChRxIFAGainErrVal, out string Rx4IChRxIFAGainErrVal, out string Rx1QChRxIFAGainErrVal, out string Rx2QChRxIFAGainErrVal, out string Rx3QChRxIFAGainErrVal, out string Rx4QChRxIFAGainErrVal, out string ProgIFAGain, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			Rx1IChHPFCutoffFreqErrVal = string.Empty;
			Rx2IChHPFCutoffFreqErrVal = string.Empty;
			Rx3IChHPFCutoffFreqErrVal = string.Empty;
			Rx4IChHPFCutoffFreqErrVal = string.Empty;
			Rx1QChHPFCutoffFreqErrVal = string.Empty;
			Rx2QChHPFCutoffFreqErrVal = string.Empty;
			Rx3QChHPFCutoffFreqErrVal = string.Empty;
			Rx4QChHPFCutoffFreqErrVal = string.Empty;
			Rx1IChLPFCutoffFreqErrVal = string.Empty;
			Rx2IChLPFCutoffFreqErrVal = string.Empty;
			Rx3IChLPFCutoffFreqErrVal = string.Empty;
			Rx4IChLPFCutoffFreqErrVal = string.Empty;
			Rx1QChLPFCutoffFreqErrVal = string.Empty;
			Rx2QChLPFCutoffFreqErrVal = string.Empty;
			Rx3QChLPFCutoffFreqErrVal = string.Empty;
			Rx4QChLPFCutoffFreqErrVal = string.Empty;
			Rx1IChRxIFAGainErrVal = string.Empty;
			Rx2IChRxIFAGainErrVal = string.Empty;
			Rx3IChRxIFAGainErrVal = string.Empty;
			Rx4IChRxIFAGainErrVal = string.Empty;
			Rx1QChRxIFAGainErrVal = string.Empty;
			Rx2QChRxIFAGainErrVal = string.Empty;
			Rx3QChRxIFAGainErrVal = string.Empty;
			Rx4QChRxIFAGainErrVal = string.Empty;
			Timestamp = string.Empty;
			ProgIFAGain = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRxIFStageMonitoringConfData(RadarDeviceId, ProfileIndex, ReportingMode, HPFCutofFreqErrorThreshold, LPFCutofFreqErrorThreshold, IFAGainErrorThreshold);
			return m_GuiManager.ScriptOps.UpdateNRxIFStageMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out Rx1IChHPFCutoffFreqErrVal, out Rx2IChHPFCutoffFreqErrVal, out Rx3IChHPFCutoffFreqErrVal, out Rx4IChHPFCutoffFreqErrVal, out Rx1QChHPFCutoffFreqErrVal, out Rx2QChHPFCutoffFreqErrVal, out Rx3QChHPFCutoffFreqErrVal, out Rx4QChHPFCutoffFreqErrVal, out Rx1IChLPFCutoffFreqErrVal, out Rx2IChLPFCutoffFreqErrVal, out Rx3IChLPFCutoffFreqErrVal, out Rx4IChLPFCutoffFreqErrVal, out Rx1QChLPFCutoffFreqErrVal, out Rx2QChLPFCutoffFreqErrVal, out Rx3QChLPFCutoffFreqErrVal, out Rx4QChLPFCutoffFreqErrVal, out Rx1IChRxIFAGainErrVal, out Rx2IChRxIFAGainErrVal, out Rx3IChRxIFAGainErrVal, out Rx4IChRxIFAGainErrVal, out Rx1QChRxIFAGainErrVal, out Rx2QChRxIFAGainErrVal, out Rx3QChRxIFAGainErrVal, out Rx4QChRxIFAGainErrVal, out ProgIFAGain, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx0BallbreakMonConfig", " SetRfTx0BallbreakMonConfig API which defines that configure the monitors of TX0 transmitter balls and impedance matching and report the soft results from monitor", new string[]
		{
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx reflection coefficient magnitude for each channel in dB (1 LSB = 0.1dB )",
			"out StatusFlags",
			"out  ErrorCode",
			"out TxReflCoeffMagValue",
			"out TimeStamp"
		})]
		public int SetRfTx0BallbreakMonConfig(char ReportingMode, double TXReflectionCoeffMagnitudeThreshold, out string StatusFlags, out string ErrorCode, out string TxReflCoeffMagValue, out string TimeStamp)
		{
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			TxReflCoeffMagValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx1BallBreakMonitoringConfData(1, ReportingMode, TXReflectionCoeffMagnitudeThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx1BallBreakMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out TxReflCoeffMagValue, out TimeStamp);
		}

		[AttrLuaFunc("SetRfTx0BallbreakMonConfig_mult", " SetRfTx0BallbreakMonConfig API which defines that configure the monitors of TX0 transmitter balls and impedance matching and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx reflection coefficient magnitude for each channel in dB (1 LSB = 0.1dB )",
			"out StatusFlags",
			"out  ErrorCode",
			"out TxReflCoeffMagValue",
			"out TimeStamp"
		})]
		public int SetRfTx0BallbreakMonConfig(ushort RadarDeviceId, char ReportingMode, double TXReflectionCoeffMagnitudeThreshold, out string StatusFlags, out string ErrorCode, out string TxReflCoeffMagValue, out string TimeStamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			TxReflCoeffMagValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx1BallBreakMonitoringConfData(RadarDeviceId, ReportingMode, TXReflectionCoeffMagnitudeThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx1BallBreakMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out TxReflCoeffMagValue, out TimeStamp);
		}

		[AttrLuaFunc("SetRfTx1BallbreakMonConfig", " SetRfTx1BallbreakMonConfig API which defines that configure the monitors of TX1 transmitter balls and impedance matching and report the soft results from monitor", new string[]
		{
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx reflection coefficient magnitude for each channel in dB (1 LSB = 0.1dB )",
			"out StatusFlags",
			"out  ErrorCode",
			"out TxReflCoeffMagValue",
			"out TimeStamp"
		})]
		public int SetRfTx1BallbreakMonConfig(char ReportingMode, double TXReflectionCoeffMagnitudeThreshold, out string StatusFlags, out string ErrorCode, out string TxReflCoeffMagValue, out string TimeStamp)
		{
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			TxReflCoeffMagValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx2BallBreakMonitoringConfData(1, ReportingMode, TXReflectionCoeffMagnitudeThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx2BallBreakMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out TxReflCoeffMagValue, out TimeStamp);
		}

		[AttrLuaFunc("SetRfTx1BallbreakMonConfig_mult", " SetRfTx1BallbreakMonConfig API which defines that configure the monitors of TX1 transmitter balls and impedance matching and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx reflection coefficient magnitude for each channel in dB (1 LSB = 0.1dB )",
			"out StatusFlags",
			"out  ErrorCode",
			"out TxReflCoeffMagValue",
			"out TimeStamp"
		})]
		public int SetRfTx1BallbreakMonConfig(ushort RadarDeviceId, char ReportingMode, double TXReflectionCoeffMagnitudeThreshold, out string StatusFlags, out string ErrorCode, out string TxReflCoeffMagValue, out string TimeStamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			TxReflCoeffMagValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx2BallBreakMonitoringConfData(RadarDeviceId, ReportingMode, TXReflectionCoeffMagnitudeThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx2BallBreakMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out TxReflCoeffMagValue, out TimeStamp);
		}

		[AttrLuaFunc("SetRfTx2BallbreakMonConfig", " SetRfTx2BallbreakMonConfig API which defines that configure the monitors of TX2 transmitter balls and impedance matching and report the soft results from monitor", new string[]
		{
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx reflection coefficient magnitude for each channel in dB (1 LSB = 0.1dB )",
			"out StatusFlags",
			"out  ErrorCode",
			"out TxReflCoeffMagValue",
			"out TimeStamp"
		})]
		public int SetRfTx2BallbreakMonConfig(char ReportingMode, double TXReflectionCoeffMagnitudeThreshold, out string StatusFlags, out string ErrorCode, out string TxReflCoeffMagValue, out string TimeStamp)
		{
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			TxReflCoeffMagValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx3BallBreakMonitoringConfData(1, ReportingMode, TXReflectionCoeffMagnitudeThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx3BallBreakMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out TxReflCoeffMagValue, out TimeStamp);
		}

		[AttrLuaFunc("SetRfTx2BallbreakMonConfig_mult", " SetRfTx2BallbreakMonConfig API which defines that configure the monitors of TX2 transmitter balls and impedance matching and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx reflection coefficient magnitude for each channel in dB (1 LSB = 0.1dB )",
			"out StatusFlags",
			"out  ErrorCode",
			"out TxReflCoeffMagValue",
			"out TimeStamp"
		})]
		public int SetRfTx2BallbreakMonConfig(ushort RadarDeviceId, char ReportingMode, double TXReflectionCoeffMagnitudeThreshold, out string StatusFlags, out string ErrorCode, out string TxReflCoeffMagValue, out string TimeStamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlags = string.Empty;
			ErrorCode = string.Empty;
			TxReflCoeffMagValue = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx3BallBreakMonitoringConfData(RadarDeviceId, ReportingMode, TXReflectionCoeffMagnitudeThreshold);
			return m_GuiManager.ScriptOps.UpdateNTx3BallBreakMonitoringConfigurationData_cmd(out StatusFlags, out ErrorCode, out TxReflCoeffMagValue, out TimeStamp);
		}

		[AttrLuaFunc("SetRfTx0BpmMonConfig", " SetRfTx0BpmMonConfig API which defines that configure the monitors of TX0 transmitter binary phase modulation and report the soft results from monitor for various Tx channels", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"Phase Shift Increment Val Ena[b0], Phase Shift Mon Ena[b1]",
			"phase Shifter Cfg, Phase shift increment value(1 LSB = 360/2^6)",
			"phase shifter1 to be monitored(1 LSB = 5.625 degrees)",
			"phase shifter2 to be monitored(1 LSB = 5.625 degrees)",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Rx Channel enable Rx0[b0], Rx1[b1], Rx2[b2], Rx3[b3]",
			"The deviation of Tx output phase diffrence(1 LSB = 360/2^16 )",
			"The deviation of Tx output amplitude diffrence in dB (1 LSB = 0.1dB )",
			"Tx Phase shifter1 threshold(1 LSB = 360/2^16)",
			"Tx Phase shifter2 threshold(1 LSB = 360/2^16)",
			"Reserved",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Tx1BPMPhaseErrorValue",
			"out Tx1BPMAmplitudeErrorValue",
			"out TxPhaseShifter1 Val, (1 LSB = 360/2^16)",
			"out TxPhaseShifter2 Val(1 LSB = 360/2^16)",
			" out Timestamp"
		})]
		public int SetRfTx0BpmMonConfig(byte ProfileIndex, byte phaseShifterMonEna, float phaseShifterIncCfg, float phaseShifterVal1, float phaseShifterVal2, byte ReportingMode, byte RxChannel, float TxBPMPhaseErrorThreshold, float TxBPMAmplitudeErrorThreshold, float TxPhaseShifter1Threshold, float TxPhaseShifter2Threshold, ushort Reserved, out string StatusFlag, out string Errorcode, out string profileIndex, out string Tx1BPMPhaseErrorValue, out string Tx1BPMAmplitudeErrorValue, out string TxPhaseShifter1Val, out string TxPhaseShifter2Val, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			TxPhaseShifter2Val = string.Empty;
			TxPhaseShifter1Val = string.Empty;
			Tx1BPMPhaseErrorValue = string.Empty;
			Tx1BPMAmplitudeErrorValue = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx1BPMPhaseMonitoringConfData(1, ProfileIndex, phaseShifterMonEna, phaseShifterIncCfg, phaseShifterVal1, phaseShifterVal2, ReportingMode, RxChannel, TxBPMPhaseErrorThreshold, TxBPMAmplitudeErrorThreshold, TxPhaseShifter1Threshold, TxPhaseShifter2Threshold, Reserved);
			return m_GuiManager.ScriptOps.UpdateNTx1BPMPhaseMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Tx1BPMPhaseErrorValue, out Tx1BPMAmplitudeErrorValue, out TxPhaseShifter1Val, out TxPhaseShifter2Val, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx0BpmMonConfig_mult", " SetRfTx0BpmMonConfig API which defines that configure the monitors of TX0 transmitter binary phase modulation and report the soft results from monitor for various Tx channels", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"Phase Shift Increment Val Ena[b0], Phase Shift Mon Ena[b1]",
			"phase Shifter Cfg, Phase shift increment value (1 LSB = 360/2^6)",
			"phase shifter1 to be monitored(1 LSB = 5.625 degrees)",
			"phase shifter2 to be monitored(1 LSB = 5.625 degrees)",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Rx Channel enable Rx0[b0], Rx1[b1], Rx2[b2], Rx3[b3]",
			"The deviation of Tx output phase diffrence(1 LSB = 360/2^16 )",
			"The deviation of Tx output amplitude diffrence in dB (1 LSB = 0.1dB )",
			"Tx Phase shifter1 threshold(1 LSB = 360/2^16)",
			"Tx Phase shifter2 threshold(1 LSB = 360/2^16)",
			"Reserved",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Tx1BPMPhaseErrorValue",
			"out Tx1BPMAmplitudeErrorValue",
			"out TxPhaseShifter1 Val, (1 LSB = 360/2^16)",
			"out TxPhaseShifter2 Val(1 LSB = 360/2^16)",
			" out Timestamp"
		})]
		public int SetRfTx0BpmMonConfig(ushort RadarDeviceId, byte ProfileIndex, byte phaseShifterMonEna, float phaseShifterIncCfg, float phaseShifterVal1, float phaseShifterVal2, byte ReportingMode, byte RxChannel, float TxBPMPhaseErrorThreshold, float TxBPMAmplitudeErrorThreshold, float TxPhaseShifter1Threshold, float TxPhaseShifter2Threshold, ushort Reserved, out string StatusFlag, out string Errorcode, out string profileIndex, out string Tx1BPMPhaseErrorValue, out string Tx1BPMAmplitudeErrorValue, out string TxPhaseShifter1Val, out string TxPhaseShifter2Val, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			TxPhaseShifter2Val = string.Empty;
			TxPhaseShifter1Val = string.Empty;
			Tx1BPMPhaseErrorValue = string.Empty;
			Tx1BPMAmplitudeErrorValue = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx1BPMPhaseMonitoringConfData(RadarDeviceId, ProfileIndex, phaseShifterMonEna, phaseShifterIncCfg, phaseShifterVal1, phaseShifterVal2, ReportingMode, RxChannel, TxBPMPhaseErrorThreshold, TxBPMAmplitudeErrorThreshold, TxPhaseShifter1Threshold, TxPhaseShifter2Threshold, Reserved);
			return m_GuiManager.ScriptOps.UpdateNTx1BPMPhaseMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Tx1BPMPhaseErrorValue, out Tx1BPMAmplitudeErrorValue, out TxPhaseShifter1Val, out TxPhaseShifter2Val, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx1BpmMonConfig", " SetRfTx1BpmMonConfig API which defines that configure the monitors of TX1 transmitter binary phase modulation and report the soft results from monitor for various Tx channels", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"Phase Shift Increment Val Ena[b0], Phase Shift Mon Ena[b1]",
			"phase Shifter Cfg, Phase shift increment value (1 LSB = 360/2^6)",
			"phase shifter1 to be monitored(1 LSB = 5.625 degrees)",
			"phase shifter2 to be monitored(1 LSB = 5.625 degrees)",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Rx Channel enable Rx0[b0], Rx1[b1], Rx2[b2], Rx3[b3]",
			"The deviation of Tx output phase diffrence(1 LSB = 360/2^16 )",
			"The deviation of Tx output amplitude diffrence in dB (1 LSB = 0.1dB )",
			"Tx Phase shifter1 threshold(1 LSB = 360/2^16)",
			"Tx Phase shifter2 threshold(1 LSB = 360/2^16)",
			"Reserved",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Tx1BPMPhaseErrorValue",
			"out Tx1BPMAmplitudeErrorValue",
			"out TxPhaseShifter1 Val, (1 LSB = 360/2^16)",
			"out TxPhaseShifter2 Val(1 LSB = 360/2^16)",
			" out Timestamp"
		})]
		public int SetRfTx1BpmMonConfig(byte ProfileIndex, byte phaseShifterMonEna, float phaseShifterIncCfg, float phaseShifterVal1, float phaseShifterVal2, byte ReportingMode, byte RxChannel, float TxBPMPhaseErrorThreshold, float TxBPMAmplitudeErrorThreshold, float TxPhaseShifter1Threshold, float TxPhaseShifter2Threshold, ushort Reserved, out string StatusFlag, out string Errorcode, out string profileIndex, out string Tx1BPMPhaseErrorValue, out string Tx1BPMAmplitudeErrorValue, out string TxPhaseShifter1Val, out string TxPhaseShifter2Val, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			TxPhaseShifter2Val = string.Empty;
			TxPhaseShifter1Val = string.Empty;
			Tx1BPMPhaseErrorValue = string.Empty;
			Tx1BPMAmplitudeErrorValue = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx2BPMPhaseMonitoringConfData(1, ProfileIndex, phaseShifterMonEna, phaseShifterIncCfg, phaseShifterVal1, phaseShifterVal2, ReportingMode, RxChannel, TxBPMPhaseErrorThreshold, TxBPMAmplitudeErrorThreshold, TxPhaseShifter1Threshold, TxPhaseShifter2Threshold, Reserved);
			return m_GuiManager.ScriptOps.UpdateNTx2BPMPhaseMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Tx1BPMPhaseErrorValue, out Tx1BPMAmplitudeErrorValue, out TxPhaseShifter1Val, out TxPhaseShifter2Val, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx1BpmMonConfig_mult", " SetRfTx1BpmMonConfig API which defines that configure the monitors of TX1 transmitter binary phase modulation and report the soft results from monitor for various Tx channels", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"Phase Shift Increment Val Ena[b0], Phase Shift Mon Ena[b1]",
			"phase Shifter Cfg, Phase shift increment value (1 LSB = 360/2^6)",
			"phase shifter1 to be monitored(1 LSB = 5.625 degrees)",
			"phase shifter2 to be monitored(1 LSB = 5.625 degrees)",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Rx Channel enable Rx0[b0], Rx1[b1], Rx2[b2], Rx3[b3]",
			"The deviation of Tx output phase diffrence(1 LSB = 360/2^16 )",
			"The deviation of Tx output amplitude diffrence in dB (1 LSB = 0.1dB )",
			"Tx Phase shifter1 threshold(1 LSB = 360/2^16)",
			"Tx Phase shifter2 threshold(1 LSB = 360/2^16)",
			"Reserved",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Tx1BPMPhaseErrorValue",
			"out Tx1BPMAmplitudeErrorValue",
			"out TxPhaseShifter1 Val, (1 LSB = 360/2^16)",
			"out TxPhaseShifter2 Val(1 LSB = 360/2^16)",
			" out Timestamp"
		})]
		public int SetRfTx1BpmMonConfig(ushort RadarDeviceId, byte ProfileIndex, byte phaseShifterMonEna, float phaseShifterIncCfg, float phaseShifterVal1, float phaseShifterVal2, byte ReportingMode, byte RxChannel, float TxBPMPhaseErrorThreshold, float TxBPMAmplitudeErrorThreshold, float TxPhaseShifter1Threshold, float TxPhaseShifter2Threshold, ushort Reserved, out string StatusFlag, out string Errorcode, out string profileIndex, out string Tx1BPMPhaseErrorValue, out string Tx1BPMAmplitudeErrorValue, out string TxPhaseShifter1Val, out string TxPhaseShifter2Val, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			TxPhaseShifter2Val = string.Empty;
			TxPhaseShifter1Val = string.Empty;
			Tx1BPMPhaseErrorValue = string.Empty;
			Tx1BPMAmplitudeErrorValue = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx2BPMPhaseMonitoringConfData(RadarDeviceId, ProfileIndex, phaseShifterMonEna, phaseShifterIncCfg, phaseShifterVal1, phaseShifterVal2, ReportingMode, RxChannel, TxBPMPhaseErrorThreshold, TxBPMAmplitudeErrorThreshold, TxPhaseShifter1Threshold, TxPhaseShifter2Threshold, Reserved);
			return m_GuiManager.ScriptOps.UpdateNTx2BPMPhaseMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Tx1BPMPhaseErrorValue, out Tx1BPMAmplitudeErrorValue, out TxPhaseShifter1Val, out TxPhaseShifter2Val, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx2BpmMonConfig", " SetRfTx2BpmMonConfig API which defines that configure the monitors of TX2 transmitter binary phase modulation and report the soft results from monitor for various Tx channels", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"Phase Shift Increment Val Ena[b0], Phase Shift Mon Ena[b1]",
			"phase Shifter Cfg, Phase shift increment value (1 LSB = 360/2^6)",
			"phase shifter1 to be monitored(1 LSB = 5.625 degrees)",
			"phase shifter2 to be monitored(1 LSB = 5.625 degrees)",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Rx Channel enable Rx0[b0], Rx1[b1], Rx2[b2], Rx3[b3]",
			"The deviation of Tx output phase diffrence(1 LSB = 360/2^16 )",
			"The deviation of Tx output amplitude diffrence in dB (1 LSB = 0.1dB )",
			"Tx Phase shifter1 threshold(1 LSB = 360/2^16)",
			"Tx Phase shifter2 threshold(1 LSB = 360/2^16)",
			"Reserved",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Tx1BPMPhaseErrorValue",
			"out Tx1BPMAmplitudeErrorValue",
			"out TxPhaseShifter1 Val, (1 LSB = 360/2^16)",
			"out TxPhaseShifter2 Val(1 LSB = 360/2^16)",
			" out Timestamp"
		})]
		public int SetRfTx2BpmMonConfig(byte ProfileIndex, byte phaseShifterMonEna, float phaseShifterIncCfg, float phaseShifterVal1, float phaseShifterVal2, byte ReportingMode, byte RxChannel, float TxBPMPhaseErrorThreshold, float TxBPMAmplitudeErrorThreshold, float TxPhaseShifter1Threshold, float TxPhaseShifter2Threshold, ushort Reserved, out string StatusFlag, out string Errorcode, out string profileIndex, out string Tx1BPMPhaseErrorValue, out string Tx1BPMAmplitudeErrorValue, out string TxPhaseShifter1Val, out string TxPhaseShifter2Val, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			TxPhaseShifter2Val = string.Empty;
			TxPhaseShifter1Val = string.Empty;
			Tx1BPMPhaseErrorValue = string.Empty;
			Tx1BPMAmplitudeErrorValue = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx3BPMPhaseMonitoringConfData(1, ProfileIndex, phaseShifterMonEna, phaseShifterIncCfg, phaseShifterVal1, phaseShifterVal2, ReportingMode, RxChannel, TxBPMPhaseErrorThreshold, TxBPMAmplitudeErrorThreshold, TxPhaseShifter1Threshold, TxPhaseShifter2Threshold, Reserved);
			return m_GuiManager.ScriptOps.UpdateNTx3BPMPhaseMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Tx1BPMPhaseErrorValue, out Tx1BPMAmplitudeErrorValue, out TxPhaseShifter1Val, out TxPhaseShifter2Val, out Timestamp);
		}

		[AttrLuaFunc("SetRfTx2BpmMonConfig_mult", " SetRfTx2BpmMonConfig API which defines that configure the monitors of TX2 transmitter binary phase modulation and report the soft results from monitor for various Tx channels", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"Phase Shift Increment Val Ena[b0], Phase Shift Mon Ena[b1]",
			"phase Shifter Cfg, Phase shift increment value (1 LSB = 360/2^6)",
			"phase shifter1 to be monitored(1 LSB = 5.625 degrees)",
			"phase shifter2 to be monitored(1 LSB = 5.625 degrees)",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Rx Channel enable Rx0[b0], Rx1[b1], Rx2[b2], Rx3[b3]",
			"The deviation of Tx output phase diffrence(1 LSB = 360/2^16 )",
			"The deviation of Tx output amplitude diffrence in dB (1 LSB = 0.1dB )",
			"Tx Phase shifter1 threshold(1 LSB = 360/2^16)",
			"Tx Phase shifter2 threshold(1 LSB = 360/2^16)",
			"Reserved",
			"out StatusFlag",
			"out  Errorcode",
			"out profileIndex",
			"out Tx1BPMPhaseErrorValue",
			"out Tx1BPMAmplitudeErrorValue",
			"out TxPhaseShifter1 Val, (1 LSB = 360/2^16)",
			"out TxPhaseShifter2 Val(1 LSB = 360/2^16)",
			" out Timestamp"
		})]
		public int SetRfTx2BpmMonConfig(ushort RadarDeviceId, byte ProfileIndex, byte phaseShifterMonEna, float phaseShifterIncCfg, float phaseShifterVal1, float phaseShifterVal2, byte ReportingMode, byte RxChannel, float TxBPMPhaseErrorThreshold, float TxBPMAmplitudeErrorThreshold, float TxPhaseShifter1Threshold, float TxPhaseShifter2Threshold, ushort Reserved, out string StatusFlag, out string Errorcode, out string profileIndex, out string Tx1BPMPhaseErrorValue, out string Tx1BPMAmplitudeErrorValue, out string TxPhaseShifter1Val, out string TxPhaseShifter2Val, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			profileIndex = string.Empty;
			TxPhaseShifter2Val = string.Empty;
			TxPhaseShifter1Val = string.Empty;
			Tx1BPMPhaseErrorValue = string.Empty;
			Tx1BPMAmplitudeErrorValue = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetTx3BPMPhaseMonitoringConfData(RadarDeviceId, ProfileIndex, phaseShifterMonEna, phaseShifterIncCfg, phaseShifterVal1, phaseShifterVal2, ReportingMode, RxChannel, TxBPMPhaseErrorThreshold, TxBPMAmplitudeErrorThreshold, TxPhaseShifter1Threshold, TxPhaseShifter2Threshold, Reserved);
			return m_GuiManager.ScriptOps.UpdateNTx3BPMPhaseMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out profileIndex, out Tx1BPMPhaseErrorValue, out Tx1BPMAmplitudeErrorValue, out TxPhaseShifter1Val, out TxPhaseShifter2Val, out Timestamp);
		}

		[AttrLuaFunc("SetRfDigMonPeriodicConfig", " SetRfDigMonPeriodicConfig API which defines that configure the of all periodic digital monitoring within Radar sub system", new string[]
		{
			"0: VerboseModeEveryMonPeiod, 1: Report is send only upon a failure (Quiet mode)",
			"Reserved",
			"Periodic digital mon, b:0 Periodic config Reg, b1:ESM mon, b2:DFE test, b3: Frame timing mon, Reserved[b31:4]",
			"Reserved2",
			"out DigMonPeriodicStatus",
			"out  TimeStamp"
		})]
		public int SetRfDigMonPeriodicConfig(char ReportingMode, uint Reserved, uint PeriodiDigitalMonEn, uint Reserved2, out string DigMonPeriodicStatus, out string TimeStamp)
		{
			DigMonPeriodicStatus = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetDigitalPeriodicMonitoringConfData(1, ReportingMode, Reserved, PeriodiDigitalMonEn, Reserved2);
			return m_GuiManager.ScriptOps.UpdateNSetDigitalPeriodicMonitoringConfigurationData_cmd(out DigMonPeriodicStatus, out TimeStamp);
		}

		[AttrLuaFunc("SetRfDigMonPeriodicConfig_mult", " SetRfDigMonPeriodicConfig API which defines that configure the of all periodic digital monitoring within Radar sub system", new string[]
		{
			"Radar Device Id",
			"0: VerboseModeEveryMonPeiod, 1: Report is send only upon a failure (Quiet mode)",
			"Reserved",
			"Periodic digital mon, b:0 Periodic config Reg, b1:ESM mon, b2:DFE test, b3: Frame timing mon, Reserved[b31:4]",
			"Reserved2",
			"out DigMonPeriodicStatus",
			"out  TimeStamp"
		})]
		public int SetRfDigMonPeriodicConfig(ushort RadarDeviceId, char ReportingMode, uint Reserved, uint PeriodiDigitalMonEn, uint Reserved2, out string DigMonPeriodicStatus, out string TimeStamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			DigMonPeriodicStatus = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetDigitalPeriodicMonitoringConfData(RadarDeviceId, ReportingMode, Reserved, PeriodiDigitalMonEn, Reserved2);
			return m_GuiManager.ScriptOps.UpdateNSetDigitalPeriodicMonitoringConfigurationData_cmd(out DigMonPeriodicStatus, out TimeStamp);
		}

		[AttrLuaFunc("SetRfDigLatentFaultMonEnableConfig", " SetRfDigLatentFaultMonEnableConfig API which defines configure the of all digital monitoring", new string[]
		{
			"Digital monitoring enable,b1:CR4andVIMLockStep, b3:VIM, b6:CRC, b7:RampGenMemECC, b8:DFE Parity, b9:DFE Mem ECC, b10:RampGenLockStep, b11:FRC lockstep, b16:ESM, b17:DFE STC, b19:ATCM BTCM ECC, b20:ATCM,BTCM parity, b24:FFT, b25:RTI, b26:PCR",
			"Test mode, 0:production mode, 1: characterization mode",
			"Reserved1",
			"Reserved2",
			"out Test status flag"
		})]
		public int SetRfDigLatentFaultMonEnableConfig(uint DigitalMonEnables, char TestMode, uint Reserved1, uint Reserved2, out string TestStatusFlag)
		{
			TestStatusFlag = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetDigitalLatentFaultMonitoringConfData(1, DigitalMonEnables, TestMode, Reserved1, Reserved2);
			return m_GuiManager.ScriptOps.UpdateNSetDigitalLatentFaultMonitoringConfigurationData_cmd(out TestStatusFlag);
		}

		[AttrLuaFunc("SetRfDigLatentFaultMonEnableConfig_mult", " SetRfDigLatentFaultMonEnableConfig API which defines configure the of all digital monitoring", new string[]
		{
			"Radar device Id",
			"Digital monitoring enable,b1:CR4andVIMLockStep, b3:VIM, b6:CRC, b7:RampGenMemECC, b8:DFE Parity, b9:DFE Mem ECC, b10:RampGenLockStep, b11:FRC lockstep, b16:ESM, b17:DFE STC, b19:ATCM BTCM ECC, b20:ATCM,BTCM parity, b24:FFT, b25:RTI, b26:PCR",
			"Test mode, 0:production mode, 1: characterization mode",
			"Reserved1",
			"Reserved2",
			"out Test status flag"
		})]
		public int SetRfDigLatentFaultMonEnableConfig(ushort RadarDeviceId, uint DigitalMonEnables, char TestMode, uint Reserved1, uint Reserved2, out string TestStatusFlag)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			TestStatusFlag = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetDigitalLatentFaultMonitoringConfData(RadarDeviceId, DigitalMonEnables, TestMode, Reserved1, Reserved2);
			return m_GuiManager.ScriptOps.UpdateNSetDigitalLatentFaultMonitoringConfigurationData_cmd(out TestStatusFlag);
		}

		[AttrLuaFunc("SetRfRxGainPhMonConfig", " SetRfRxGainPhMonConfig API which defines that configure the monitors of reciever gain and phase, and report the soft results from monitor", new string[]
		{
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx Select for Rx gain measurement",
			"Rx Gain Absolute Error Threshold in dB (1 LSB = 0.1dB )",
			"Rx Gain Mismatch Threshold in dB (1 LSB = 0.1dB )",
			"Rx Gain Flatness Error Threshold in dB (1 LSB = 0.1dB )",
			"Rx Phase Mismatch Threshold(1 LSB = 360/2^16 )",
			"RF1 RX0 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF1 RX1 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF1 RX2 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF1 RX3 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF2 RX0 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF2 RX1 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF2 RX2 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF2 RX3 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF3 RX0 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF3 RX1 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF3 RX2 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF3 RX3 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF1 RX0 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF1 RX1 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF1 RX2 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF1 RX3 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF2 RX0 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF2 RX1 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF2 RX2 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF2 RX3 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF3 RX0 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF3 RX1 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF3 RX2 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF3 RX3 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"out StatusFlag",
			"out Errorcode",
			"out Profileindex",
			"out RF1Rx0gainvalue",
			"out RF1Rx1gainvalue",
			"out RF1Rx2gainvalue",
			"out RF1Rx3gainvalue",
			"out RF2Rx0gainvalue",
			"out RF2Rx1gainvalue",
			"out RF2Rx2gainvalue",
			"out RF2Rx3gainvalue",
			"out RF3Rx0gainvalue",
			"out RF3Rx1gainvalue",
			"out RF3Rx2gainvalue",
			"out RF3Rx3gainvalue",
			"out RF1Rx0phasevalue",
			"out RF1Rx1phasevalue",
			"out RF1Rx2phasevalue",
			"out RF1Rx3phasevalue",
			"out RF2Rx0phasevalue",
			"out RF2Rx1phasevalue",
			"out RF2Rx2phasevalue",
			"out RF2Rx3phasevalue",
			"out RF3Rx0phasevalue",
			"out RF3Rx1phasevalue",
			"out RF3Rx2phasevalue",
			"out RF3Rx3phasevalue",
			"out Timestamp"
		})]
		public int SetRfRxGainPhMonConfig(char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char ReportingMode, char TxSelect, double RxGainAbsoluteErrorThreshold, double RxGainMismatchThreshold, double RxGainFlatnessErrorThreshold, ushort RxPhaseMismatchThreshold, double p10, double p11, double p12, double p13, double p14, double p15, double p16, double p17, double p18, double p19, double p20, double p21, double p22, double p23, double p24, double p25, double p26, double p27, double p28, double p29, double p30, double p31, double p32, double p33, out string StatusFlag, out string Errorcode, out string Profileindex, out string RF1Rx0gainvalue, out string RF1Rx1gainvalue, out string RF1Rx2gainvalue, out string RF1Rx3gainvalue, out string RF2Rx0gainvalue, out string RF2Rx1gainvalue, out string RF2Rx2gainvalue, out string RF2Rx3gainvalue, out string RF3Rx0gainvalue, out string RF3Rx1gainvalue, out string RF3Rx2gainvalue, out string RF3Rx3gainvalue, out string p49, out string p50, out string p51, out string p52, out string p53, out string p54, out string p55, out string p56, out string p57, out string p58, out string p59, out string p60, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			RF1Rx0gainvalue = string.Empty;
			RF1Rx1gainvalue = string.Empty;
			RF1Rx2gainvalue = string.Empty;
			RF1Rx3gainvalue = string.Empty;
			RF2Rx0gainvalue = string.Empty;
			RF2Rx1gainvalue = string.Empty;
			RF2Rx2gainvalue = string.Empty;
			RF2Rx3gainvalue = string.Empty;
			RF3Rx0gainvalue = string.Empty;
			RF3Rx1gainvalue = string.Empty;
			RF3Rx2gainvalue = string.Empty;
			RF3Rx3gainvalue = string.Empty;
			p49 = string.Empty;
			p50 = string.Empty;
			p51 = string.Empty;
			p52 = string.Empty;
			p53 = string.Empty;
			p54 = string.Empty;
			p55 = string.Empty;
			p56 = string.Empty;
			p57 = string.Empty;
			p58 = string.Empty;
			p59 = string.Empty;
			p60 = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRxGainandPhaseMonitoringConfData(1, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, ReportingMode, TxSelect, RxGainAbsoluteErrorThreshold, RxGainMismatchThreshold, RxGainFlatnessErrorThreshold, RxPhaseMismatchThreshold, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33);
			return m_GuiManager.ScriptOps.UpdateNRxGainandPhaseMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out RF1Rx0gainvalue, out RF1Rx1gainvalue, out RF1Rx2gainvalue, out RF1Rx3gainvalue, out RF2Rx0gainvalue, out RF2Rx1gainvalue, out RF2Rx2gainvalue, out RF2Rx3gainvalue, out RF3Rx0gainvalue, out RF3Rx1gainvalue, out RF3Rx2gainvalue, out RF3Rx3gainvalue, out p49, out p50, out p51, out p52, out p53, out p54, out p55, out p56, out p57, out p58, out p59, out p60, out Timestamp);
		}

		[AttrLuaFunc("SetRfRxGainPhMonConfig_mult", " SetRfRxGainPhMonConfig API which defines that configure the monitors of reciever gain and phase, and report the soft results from monitor", new string[]
		{
			"Radar Device Id",
			"Profile Index for which this monitoring cofig applies",
			"RF1:Lowest RF frequency in profile sweep bandwidth",
			"RF2:Centre RF frequency in profile sweep bandwidth",
			"RF3:Highest RF frequency in profile sweep bandwidth",
			"0: Every monitroing period without threshold check (verbose mode), 1: Report is send only upon a failure (Quiet mode), 2: Every monitroing period with threshold check",
			"Tx Select",
			"Rx Gain Absolute Error Threshold in dB (1 LSB = 0.1dB )",
			"Rx Gain Mismatch Threshold in dB (1 LSB = 0.1dB )",
			"Rx Gain Flatness Error Threshold in dB (1 LSB = 0.1dB )",
			"Rx Phase Mismatch Threshold(1 LSB = 360/2^16 )",
			"RF1 RX0 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF1 RX1 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF1 RX2 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF1 RX3 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF2 RX0 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF2 RX1 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF2 RX2 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF2 RX3 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF3 RX0 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF3 RX1 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF3 RX2 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF3 RX3 RX Gain Mismatch Offset Val in dB (1 LSB = 0.1dB )",
			"RF1 RX0 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF1 RX1 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF1 RX2 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF1 RX3 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF2 RX0 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF2 RX1 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF2 RX2 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF2 RX3 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF3 RX0 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF3 RX1 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF3 RX2 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"RF3 RX3 RX Phase Mismatch Offset Val(1 LSB = 360/2^16 )",
			"out StatusFlag",
			"out Errorcode",
			"out Profileindex",
			"out RF1Rx0gainvalue",
			"out RF1Rx1gainvalue",
			"out RF1Rx2gainvalue",
			"out RF1Rx3gainvalue",
			"out RF2Rx0gainvalue",
			"out RF2Rx1gainvalue",
			"out RF2Rx2gainvalue",
			"out RF2Rx3gainvalue",
			"out RF3Rx0gainvalue",
			"out RF3Rx1gainvalue",
			"out RF3Rx2gainvalue",
			"out RF3Rx3gainvalue",
			"out RF1Rx0phasevalue",
			"out RF1Rx1phasevalue",
			"out RF1Rx2phasevalue",
			"out RF1Rx3phasevalue",
			"out RF2Rx0phasevalue",
			"out RF2Rx1phasevalue",
			"out RF2Rx2phasevalue",
			"out RF2Rx3phasevalue",
			"out RF3Rx0phasevalue",
			"out RF3Rx1phasevalue",
			"out RF3Rx2phasevalue",
			"out RF3Rx3phasevalue",
			"out Timestamp"
		})]
		public int SetRfRxGainPhMonConfig(ushort RadarDeviceId, char ProfileIndex, char RF1FreqBitMask, char RF2FreqBitMask, char RF3FreqBitMask, char ReportingMode, char TxSelect, double RxGainAbsoluteErrorThreshold, double RxGainMismatchThreshold, double RxGainFlatnessErrorThreshold, ushort RxPhaseMismatchThreshold, double p11, double p12, double p13, double p14, double p15, double p16, double p17, double p18, double p19, double p20, double p21, double p22, double p23, double p24, double p25, double p26, double p27, double p28, double p29, double p30, double p31, double p32, double p33, double p34, out string StatusFlag, out string Errorcode, out string Profileindex, out string RF1Rx0gainvalue, out string RF1Rx1gainvalue, out string RF1Rx2gainvalue, out string RF1Rx3gainvalue, out string RF2Rx0gainvalue, out string RF2Rx1gainvalue, out string RF2Rx2gainvalue, out string RF2Rx3gainvalue, out string RF3Rx0gainvalue, out string RF3Rx1gainvalue, out string RF3Rx2gainvalue, out string RF3Rx3gainvalue, out string p50, out string p51, out string p52, out string p53, out string p54, out string p55, out string p56, out string p57, out string p58, out string p59, out string p60, out string p61, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			RF1Rx0gainvalue = string.Empty;
			RF1Rx1gainvalue = string.Empty;
			RF1Rx2gainvalue = string.Empty;
			RF1Rx3gainvalue = string.Empty;
			RF2Rx0gainvalue = string.Empty;
			RF2Rx1gainvalue = string.Empty;
			RF2Rx2gainvalue = string.Empty;
			RF2Rx3gainvalue = string.Empty;
			RF3Rx0gainvalue = string.Empty;
			RF3Rx1gainvalue = string.Empty;
			RF3Rx2gainvalue = string.Empty;
			RF3Rx3gainvalue = string.Empty;
			p50 = string.Empty;
			p51 = string.Empty;
			p52 = string.Empty;
			p53 = string.Empty;
			p54 = string.Empty;
			p55 = string.Empty;
			p56 = string.Empty;
			p57 = string.Empty;
			p58 = string.Empty;
			p59 = string.Empty;
			p60 = string.Empty;
			p61 = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRxGainandPhaseMonitoringConfData(RadarDeviceId, ProfileIndex, RF1FreqBitMask, RF2FreqBitMask, RF3FreqBitMask, ReportingMode, TxSelect, RxGainAbsoluteErrorThreshold, RxGainMismatchThreshold, RxGainFlatnessErrorThreshold, RxPhaseMismatchThreshold, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34);
			return m_GuiManager.ScriptOps.UpdateNRxGainandPhaseMonitoringConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out RF1Rx0gainvalue, out RF1Rx1gainvalue, out RF1Rx2gainvalue, out RF1Rx3gainvalue, out RF2Rx0gainvalue, out RF2Rx1gainvalue, out RF2Rx2gainvalue, out RF2Rx3gainvalue, out RF3Rx0gainvalue, out RF3Rx1gainvalue, out RF3Rx2gainvalue, out RF3Rx3gainvalue, out p50, out p51, out p52, out p53, out p54, out p55, out p56, out p57, out p58, out p59, out p60, out p61, out Timestamp);
		}

		[AttrLuaFunc("SetCalMonTimeUnitConfig", " SetCalMonTimeUnitConfig API which defines calibration and monitoring time unit configuration", new string[]
		{
			"Calib Mon Time Unit",
			"Numof Cascade Devices",
			"Device Id"
		})]
		public int SetCalMonTimeUnitConfig(ushort CalibMonTimeUnit, char NumCascadeDevices, char DeviceId)
		{
			return m_GuiManager.ScriptOps.UpdateNSetTimeUnitConfData(1, CalibMonTimeUnit, NumCascadeDevices, DeviceId);
		}

		[AttrLuaFunc("SetCalMonTimeUnitConfig_mult", " SetCalMonTimeUnitConfig API which defines calibration and monitoring time unit configuration", new string[]
		{
			"Radar Device Id",
			"Calib Mon Time Unit",
			"Numof Cascade Devices",
			"Device Id"
		})]
		public int SetCalMonTimeUnitConfig(ushort RadarDeviceId, ushort CalibMonTimeUnit, char NumCascadeDevices, char DeviceId)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetTimeUnitConfData(RadarDeviceId, CalibMonTimeUnit, NumCascadeDevices, DeviceId);
		}

		[AttrLuaFunc("RfInitCalibConfig", " RfInitCalibConfig API which defines calibration and monitoring RF initialization configuration", new string[]
		{
			"LODist",
			"RX ADC DC",
			"HPF Cutoff",
			"LPF Cutoff",
			"PeakDetector",
			"TX Power",
			" RX Gain",
			"RX IQMM[b15:0]+TXPhase[b31:16]"
		})]
		public int RfInitCalibConfig(uint LODist, uint RXADCDC, uint HPFCutoff, uint LPFCutoff, uint PeakDetector, uint TXPower, uint RXGain, uint RXIQMM)
		{
			return m_GuiManager.ScriptOps.UpdateNSetRFInitCalibConfData(1, LODist, RXADCDC, HPFCutoff, LPFCutoff, PeakDetector, TXPower, RXGain, RXIQMM);
		}

		[AttrLuaFunc("RfInitCalibConfig_mult", " RfInitCalibConfig API which defines calibration and monitoring RF initialization configuration", new string[]
		{
			"Radar Device Id",
			"LODist",
			"RX ADC DC",
			"HPF Cutoff",
			"LPF Cutoff",
			"PeakDetector",
			"TX Power",
			" RX Gain",
			"RX IQMM[b15:0]+TXPhase[b31:16]"
		})]
		public int RfInitCalibConfig(ushort RadarDeviceId, uint LODist, uint RXADCDC, uint HPFCutoff, uint LPFCutoff, uint PeakDetector, uint TXPower, uint RXGain, uint RXIQMM)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetRFInitCalibConfData(RadarDeviceId, LODist, RXADCDC, HPFCutoff, LPFCutoff, PeakDetector, TXPower, RXGain, RXIQMM);
		}

		[AttrLuaFunc("RunTimeCalibConfTrig", " RunTimeCalibConfTrig API which defines calibration and monitoring RF Run Time configuration", new string[]
		{
			"One Time Calib LODist",
			"One Time Calib TX Power",
			" One Time Calib RX Gain",
			"One time PD calibration",
			"Periodic Calib LODist",
			"Periodic Calib TX Power",
			" Periodic Calib RX Gain",
			"Periodic Calib PD calibration",
			"Calib Periodicity",
			"Enable or disable the cal report",
			"Tx Power Cal Mode",
			"out ErrorFlag",
			"out UpdateStatus",
			"out Temperature",
			"out TimeStamp"
		})]
		public int RunTimeCalibConfTrig(uint OneTimeCalibLODist, uint OneTimeCalibTXPower, uint OneTimeCalibRXGain, uint OneTimeCalibPDCal, uint PeriodicCalibLODist, uint PeriodicCalibTXPower, uint PeriodicCalibRXGain, uint PeriodicCalibPDCal, uint CalibPeriodicity, char CalReport, char TxPowerCalMode, out string ErrorFlag, out string UpdateStatus, out string Temperature, out string TimeStamp)
		{
			ErrorFlag = string.Empty;
			UpdateStatus = string.Empty;
			Temperature = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRunTimeCalibrationConfigData(1, OneTimeCalibLODist, OneTimeCalibTXPower, OneTimeCalibRXGain, OneTimeCalibPDCal, PeriodicCalibLODist, PeriodicCalibTXPower, PeriodicCalibRXGain, PeriodicCalibPDCal, CalibPeriodicity, CalReport, TxPowerCalMode);
			return m_GuiManager.ScriptOps.UpdateNMeasureTheRunTimeConfigurationData_cmd(out ErrorFlag, out UpdateStatus, out Temperature, out TimeStamp);
		}

		[AttrLuaFunc("RunTimeCalibConfTrig_mult", " RunTimeCalibConfTrig API which defines calibration and monitoring RF Run Time configuration", new string[]
		{
			"Radar Device Id",
			"One Time Calib LODist",
			"One Time Calib TX Power",
			" One Time Calib RX Gain",
			"One time PD calibration",
			"Periodic Calib LODist",
			"Periodic Calib TX Power",
			" Periodic Calib RX Gain",
			"Periodic Calib PD calibration",
			"Calib Periodicity",
			"Enable or disable the cal report",
			"Tx Power Cal Mode",
			"out ErrorFlag",
			"out UpdateStatus",
			"out Temperature",
			"out TimeStamp"
		})]
		public int RunTimeCalibConfTrig(ushort RadarDeviceId, uint OneTimeCalibLODist, uint OneTimeCalibTXPower, uint OneTimeCalibRXGain, uint OneTimeCalibPDCal, uint PeriodicCalibLODist, uint PeriodicCalibTXPower, uint PeriodicCalibRXGain, uint PeriodicCalibPDCal, uint CalibPeriodicity, char CalReport, char TxPowerCalMode, out string ErrorFlag, out string UpdateStatus, out string Temperature, out string TimeStamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			ErrorFlag = string.Empty;
			UpdateStatus = string.Empty;
			Temperature = string.Empty;
			TimeStamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRunTimeCalibrationConfigData(RadarDeviceId, OneTimeCalibLODist, OneTimeCalibTXPower, OneTimeCalibRXGain, OneTimeCalibPDCal, PeriodicCalibLODist, PeriodicCalibTXPower, PeriodicCalibRXGain, PeriodicCalibPDCal, CalibPeriodicity, CalReport, TxPowerCalMode);
			return m_GuiManager.ScriptOps.UpdateNMeasureTheRunTimeConfigurationData_cmd(out ErrorFlag, out UpdateStatus, out Temperature, out TimeStamp);
		}

		[AttrLuaFunc("LPModConfig_mult", "LP Mod Config API which defines both Configure the ADC Mode and analog filter channel format", new string[]
		{
			"Radar Device Id",
			"Analog filter Chananel",
			"ADC Mode"
		})]
		public int LowPowNNoisFifConfig(ushort RadarDeviceId, int AnaChan, int LpAdcMod)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetLowPowNNoisFifConfigData(RadarDeviceId, AnaChan, LpAdcMod);
		}

		[AttrLuaFunc("LPModConfig", "LP Mod Config API which defines both Configure the ADC Mode and analog filter channel format", new string[]
		{
			"Analog filter Chananel",
			"ADC Mode"
		})]
		public int LowPowNNoisFifConfig(int AnaChan, int LpAdcMod)
		{
			return m_GuiManager.ScriptOps.UpdateNSetLowPowNNoisFifConfigData(1, AnaChan, LpAdcMod);
		}

		[AttrLuaFunc("RfLdoBypassConfig_mult", "RFLDOBypassConfig_mult API which defines enable or disable the RF LDO Bypass", new string[]
		{
			"Radar Device Id",
			"(RFLDOBypassEnable:b0  + PALDODisable:b1  + Reserved[b15:2]) + SupplyMonIRDrop[b23:16] + IO Supply[b31:24]"
		})]
		public int EnableRfLdoBypassConfig(ushort RadarDeviceId, uint RFLDOBypassEnableAndMonIRDrop)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetRFLDOBypassEnableorDisableConfigData(RadarDeviceId, RFLDOBypassEnableAndMonIRDrop);
		}

		[AttrLuaFunc("RfLdoBypassConfig", "RFLDOBypassConfig API which defines enable or disable the RF LDO Bypass", new string[]
		{
			"(RFLDOBypassEnable:b0  + PALDODisable:b1  + Reserved[b15:2]) + SupplyMonIRDrop[b23:16] + IO Supply[b31:24]"
		})]
		public int EnableRfLdoBypassConfig(uint RFLDOBypassEnableAndMonIRDrop)
		{
			return m_GuiManager.ScriptOps.UpdateNSetRFLDOBypassEnableorDisableConfigData(1, RFLDOBypassEnableAndMonIRDrop);
		}

		[AttrLuaFunc("ChirpConfig_mult", "Chirp configuration API which defines which profile is to be used for each chirp in a frame", new string[]
		{
			"Radar Device Id",
			"First Chirp Start Index number",
			"Last chirp Index number",
			"Chirp Configured profileId",
			"Chirp start frequency var in MHz",
			"frequency Slope Var in MHz/µs",
			"Idle Time Var in µs",
			"ADC Start Time Var in µs",
			"tx0 channel",
			"tx1 channel",
			"tx2 channel"
		})]
		public int ChirpConfig(ushort RadarDeviceId, ushort chirpStartIdx, ushort chirpEndIdx, ushort profileId, float startFreqVar, float freqSlopeVar, float idleTimeVar, float adcStartTimeVar, ushort tx0Enable, ushort tx1Enable, ushort tx2Enable)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetChirpConfData(RadarDeviceId, chirpStartIdx, chirpEndIdx, profileId, startFreqVar, freqSlopeVar, idleTimeVar, adcStartTimeVar, tx0Enable, tx1Enable, tx2Enable);
		}

		[AttrLuaFunc("ChirpConfig", "Chirp configuration API which defines which profile is to be used for each chirp in a frame", new string[]
		{
			"First Chirp Start Index number",
			"Last chirp Index number",
			"Chirp Configured profileId",
			"Chirp start frequency var in MHz",
			"frequency Slope Var in MHz/µs",
			"Idle Time Var in µs",
			"ADC Start Time Var in µs",
			"tx0 channel",
			"tx1 channel",
			"tx2 channel"
		})]
		public int ChirpConfig(ushort chirpStartIdx, ushort chirpEndIdx, ushort profileId, float startFreqVar, float freqSlopeVar, float idleTimeVar, float adcStartTimeVar, ushort tx0Enable, ushort tx1Enable, ushort tx2Enable)
		{
			return m_GuiManager.ScriptOps.UpdateNSetChirpConfData(1, chirpStartIdx, chirpEndIdx, profileId, startFreqVar, freqSlopeVar, idleTimeVar, adcStartTimeVar, tx0Enable, tx1Enable, tx2Enable);
		}

		[AttrLuaFunc("TransferFilesUsingWinSCP_mult", "API to transfer all the captured files present in the /mnt/ssd folder of the capture card using WinSCP", new string[]
		{
			"Radar device Id"
		})]
		public int TransferFilesUsingWinSCP(ushort RadarDeviceId)
		{
			GlobalRef.g_RadarDeviceId = (uint)RadarDeviceId;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.TransferFilesUsingWinSCP();
		}

		[AttrLuaFunc("SetDynamicPowerSaveMode", "SetDynamicPowerSaveMode configuration API which defines enable Dynamic Power Save Mode", new string[]
		{
			"BlockCfgTX",
			"BlockCfgRX",
			"BlockCfgLODist"
		})]
		public int SetDynamicPowerSave(ushort BlockCfgTX, ushort BlockCfgRX, ushort BlockCfgLODist)
		{
			return m_GuiManager.ScriptOps.UpdateNSetdynamicPowerSaveModeConfData(1U, BlockCfgTX, BlockCfgRX, BlockCfgLODist);
		}

		[AttrLuaFunc("SetDynamicPowerSaveMode_mult", "SetDynamicPowerSaveMode configuration API which defines enable Dynamic Power Save Mode", new string[]
		{
			"RadarDeviceId",
			"BlockCfgTX",
			"BlockCfgRX",
			"BlockCfgLODist"
		})]
		public int SetDynamicPowerSave(uint RadarDeviceId, ushort BlockCfgTX, ushort BlockCfgRX, ushort BlockCfgLODist)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetdynamicPowerSaveModeConfData(RadarDeviceId, BlockCfgTX, BlockCfgRX, BlockCfgLODist);
		}

		[AttrLuaFunc("FrameConfig_mult", "Frame Configuration API defines Frame formation which has sequence of chirps to be transmitted subsequently", new string[]
		{
			"Radar Device Id",
			"First Chirp Start Index number",
			"Last chirp Index number",
			"Number of frames to transmit",
			"Number of times to repeat from start chirp to last chirp in each frame",
			"Each frame repetition period in ms",
			" Optional time delay from sync in trigger to the occurrence of frame chirps in µs",
			"No. of chirps in a frame to skip (at the end of the frame) for HSI streaming",
			"TriggerSelect"
		})]
		public int FrameConfig(ushort RadarDeviceId, ushort chirpStartIdx, ushort chirpEndIdx, ushort frameCount, ushort loopCount, float periodicity, float triggerDelay, byte numDummyChirp, ushort TriggerSelect)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetFrameConfData(RadarDeviceId, chirpStartIdx, chirpEndIdx, frameCount, loopCount, periodicity, triggerDelay, numDummyChirp, TriggerSelect);
		}

		[AttrLuaFunc("FrameConfig", "Frame Configuration API defines Frame formation which has sequence of chirps to be transmitted subsequently", new string[]
		{
			"First Chirp Start Index number",
			"Last chirp Index number",
			"Number of frames to transmit",
			"Number of times to repeat from start chirp to last chirp in each frame",
			"Each frame repetition period in ms",
			" Optional time delay from sync in trigger to the occurrence of frame chirps in µs",
			"No. of chirps in a frame to skip (at the end of the frame) for HSI streaming",
			"TriggerSelect"
		})]
		public int FrameConfig(ushort chirpStartIdx, ushort chirpEndIdx, ushort frameCount, ushort loopCount, float periodicity, float triggerDelay, byte numDummyChirp, ushort TriggerSelect)
		{
			return m_GuiManager.ScriptOps.UpdateNSetFrameConfData(1, chirpStartIdx, chirpEndIdx, frameCount, loopCount, periodicity, triggerDelay, numDummyChirp, TriggerSelect);
		}

		[AttrLuaFunc("BpmConfig_mult", "Bpm Configuration API Defines static configurations related to BPM(Binary Phase Modulation) feature in each of the TXs Channels.", new string[]
		{
			"RadarDeviceId",
			"Start Index of the chirp for configuring the constant BPM",
			"End Index of the chirp for configuring the constant BPM",
			"Value of Binary phase shift value for Tx0 Channel when during idle time",
			"Value of Binary phase shift value for Tx0 Channel during chirp",
			"Value of Binary phase shift value for Tx1 Channel when during idle time",
			"Value of Binary phase shift value for Tx1 Channel during chirp",
			"Value of Binary phase shift value for Tx2 Channel when during idle time",
			"Value of Binary phase shift value for Tx2 Channel during chirp"
		})]
		public int BPMChirpConfig(ushort RadarDeviceId, ushort bpmChirpStartIndex, ushort bpmChirpEndIndex, ushort tx0Off, ushort tx0On, ushort tx1Off, ushort tx1On, ushort tx2Off, ushort tx2On)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetBPMChirpConfigData(RadarDeviceId, bpmChirpStartIndex, bpmChirpEndIndex, tx0Off, tx0On, tx1Off, tx1On, tx2Off, tx2On);
		}

		[AttrLuaFunc("BpmConfig", "Bpm Configuration API Defines static configurations related to BPM(Binary Phase Modulation) feature in each of the TXs Channels.", new string[]
		{
			"Start Index of the chirp for configuring the constant BPM",
			"End Index of the chirp for configuring the constant BPM",
			"Value of Binary phase shift value for Tx0 Channel when during idle time",
			"Value of Binary phase shift value for Tx0 Channel during chirp",
			"Value of Binary phase shift value for Tx1 Channel when during idle time",
			"Value of Binary phase shift value for Tx1 Channel during chirp",
			"Value of Binary phase shift value for Tx2 Channel when during idle time",
			"Value of Binary phase shift value for Tx2 Channel during chirp"
		})]
		public int BPMChirpConfig(ushort bpmChirpStartIndex, ushort bpmChirpEndIndex, ushort tx0Off, ushort tx0On, ushort tx1Off, ushort tx1On, ushort tx2Off, ushort tx2On)
		{
			return m_GuiManager.ScriptOps.UpdateNSetBPMChirpConfigData(1, bpmChirpStartIndex, bpmChirpEndIndex, tx0Off, tx0On, tx1Off, tx1On, tx2Off, tx2On);
		}

		[AttrLuaFunc("SetAdvBpmPatternConfig", "SetAdvBpmPatternConfig API Defines advance BPM pattern configuration for each of the TXs Channels.", new string[]
		{
			"BPMPatternIndex",
			"Reserved",
			"ResetOption",
			"Reserved1",
			"Reserved2",
			"Tx0BPMpattern0",
			"Tx0BPMpattern1",
			"Tx0BPMpattern2",
			"Tx0BPMpattern3",
			"Tx0BPMpattern4",
			"Tx0BPMpattern5",
			"Tx0BPMpattern6",
			"Tx0BPMpattern7",
			"Tx0BPMpattern8",
			"Tx0BPMpattern9",
			"Tx0BPMpattern10",
			"Tx0BPMpattern11",
			"Tx0BPMpattern12",
			"Tx0BPMpattern13",
			"Tx0BPMpattern14",
			"Tx0BPMpattern15",
			"Tx1BPMpattern0",
			"Tx1BPMpattern1",
			"Tx1BPMpattern2",
			"Tx1BPMpattern3",
			"Tx1BPMpattern4",
			"Tx1BPMpattern5",
			"Tx1BPMpattern6",
			"Tx1BPMpattern7",
			"Tx1BPMpattern8",
			"Tx1BPMpattern9",
			"Tx1BPMpattern10",
			"Tx1BPMpattern11",
			"Tx1BPMpattern12",
			"Tx1BPMpattern13",
			"Tx1BPMpattern14",
			"Tx1BPMpattern15",
			"Tx2BPMpattern0",
			"Tx2BPMpattern1",
			"Tx2BPMpattern2",
			"Tx2BPMpattern3",
			"Tx2BPMpattern4",
			"Tx2BPMpattern5",
			"Tx2BPMpattern6",
			"Tx2BPMpattern7",
			"Tx2BPMpattern8",
			"Tx2BPMpattern9",
			"Tx2BPMpattern10",
			"Tx2BPMpattern11",
			"Tx2BPMpattern12",
			"Tx2BPMpattern13",
			"Tx2BPMpattern14",
			"Tx2BPMpattern15"
		})]
		public int SetAdvBpmPatternConfig(byte BPMPatternIndex, byte Reserved, ushort ResetOption, ushort Reserved1, ushort Reserved2, string Tx0BPMpattern0, uint Tx0BPMpattern1, uint Tx0BPMpattern2, uint Tx0BPMpattern3, uint Tx0BPMpattern4, uint Tx0BPMpattern5, uint Tx0BPMpattern6, uint Tx0BPMpattern7, uint Tx0BPMpattern8, uint Tx0BPMpattern9, uint Tx0BPMpattern10, uint Tx0BPMpattern11, uint Tx0BPMpattern12, uint Tx0BPMpattern13, uint Tx0BPMpattern14, uint Tx0BPMpattern15, uint Tx1BPMpattern0, uint Tx1BPMpattern1, uint Tx1BPMpattern2, uint Tx1BPMpattern3, uint Tx1BPMpattern4, uint Tx1BPMpattern5, uint Tx1BPMpattern6, uint Tx1BPMpattern7, uint Tx1BPMpattern8, uint Tx1BPMpattern9, uint Tx1BPMpattern10, uint Tx1BPMpattern11, uint Tx1BPMpattern12, uint Tx1BPMpattern13, uint Tx1BPMpattern14, uint Tx1BPMpattern15, uint Tx2BPMpattern0, uint Tx2BPMpattern1, uint Tx2BPMpattern2, uint Tx2BPMpattern3, uint Tx2BPMpattern4, uint Tx2BPMpattern5, uint Tx2BPMpattern6, uint Tx2BPMpattern7, uint Tx2BPMpattern8, uint Tx2BPMpattern9, uint Tx2BPMpattern10, uint Tx2BPMpattern11, uint Tx2BPMpattern12, uint Tx2BPMpattern13, uint Tx2BPMpattern14, uint Tx2BPMpattern15)
		{
			return m_GuiManager.ScriptOps.UpdateNSetAdvanceBPMPatternConfigData(1, BPMPatternIndex, Reserved, ResetOption, Reserved1, Reserved2, Tx0BPMpattern0, Tx0BPMpattern1, Tx0BPMpattern2, Tx0BPMpattern3, Tx0BPMpattern4, Tx0BPMpattern5, Tx0BPMpattern6, Tx0BPMpattern7, Tx0BPMpattern8, Tx0BPMpattern9, Tx0BPMpattern10, Tx0BPMpattern11, Tx0BPMpattern12, Tx0BPMpattern13, Tx0BPMpattern14, Tx0BPMpattern15, Tx1BPMpattern0, Tx1BPMpattern1, Tx1BPMpattern2, Tx1BPMpattern3, Tx1BPMpattern4, Tx1BPMpattern5, Tx1BPMpattern6, Tx1BPMpattern7, Tx1BPMpattern8, Tx1BPMpattern9, Tx1BPMpattern10, Tx1BPMpattern11, Tx1BPMpattern12, Tx1BPMpattern13, Tx1BPMpattern14, Tx1BPMpattern15, Tx2BPMpattern0, Tx2BPMpattern1, Tx2BPMpattern2, Tx2BPMpattern3, Tx2BPMpattern4, Tx2BPMpattern5, Tx2BPMpattern6, Tx2BPMpattern7, Tx2BPMpattern8, Tx2BPMpattern9, Tx2BPMpattern10, Tx2BPMpattern11, Tx2BPMpattern12, Tx2BPMpattern13, Tx2BPMpattern14, Tx2BPMpattern15);
		}

		[AttrLuaFunc("SetPerChirpPhaseShifterConfig", "SetPerChirpPhaseShifterConfig API Defines static phase configurations per chirp in each of the TXs Channels.", new string[]
		{
			"Start Index of the chirp for configuring the phase shifter",
			"End Index of the chirp for configuring phase shifter",
			"TX0 phase shifter value",
			"TX1 phase shifter value",
			"TX2 phase shifter value"
		})]
		public int SetPerChirpPhaseShifterConfig(ushort ChirpStartIndex, ushort ChirpEndIndex, ushort Tx0PhaseShifter, ushort Tx1PhaseShifter, ushort Tx2PhaseShifter)
		{
			return m_GuiManager.ScriptOps.UpdateNSetChirpBasedPhaseShifterConfigData(1, ChirpStartIndex, ChirpEndIndex, Tx0PhaseShifter, Tx1PhaseShifter, Tx2PhaseShifter);
		}

		[AttrLuaFunc("SetPerChirpPhaseShifterConfig_mult", "SetPerChirpPhaseShifterConfig API Defines static phase configurations per chirp in each of the TXs Channels.", new string[]
		{
			"Radar Device Id",
			"Start Index of the chirp for configuring the phase shifter",
			"End Index of the chirp for configuring phase shifter",
			"TX0 phase shifter value",
			"TX1 phase shifter value",
			"TX2 phase shifter value"
		})]
		public int SetPerChirpPhaseShifterConfig(ushort RadarDeviceId, ushort ChirpStartIndex, ushort ChirpEndIndex, ushort Tx0PhaseShifter, ushort Tx1PhaseShifter, ushort Tx2PhaseShifter)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetChirpBasedPhaseShifterConfigData(RadarDeviceId, ChirpStartIndex, ChirpEndIndex, Tx0PhaseShifter, Tx1PhaseShifter, Tx2PhaseShifter);
		}

		[AttrLuaFunc("SetRFPALoopbackConfig", "SetRFPALoopbackConfig API Defines Enables/Disables PA loopback for all enabled profiles and it used to debug both Tx and Rx chains are working correctly.", new string[]
		{
			"PA loop back frequency",
			"PA loop back enabled/disabled"
		})]
		public int SetRFPALoopbackConfig(ushort PALoopBackFreq, ushort PALoopBackEnabled)
		{
			return m_GuiManager.ScriptOps.UpdateNSetPALoopBackConfigData(1, PALoopBackFreq, PALoopBackEnabled);
		}

		[AttrLuaFunc("SetRFPALoopbackConfig_mult", "SetRFPALoopbackConfig API Defines Enables/Disables PA loopback for all enabled profiles and it used to debug both Tx and Rx chains are working correctly", new string[]
		{
			"Radar Device Id",
			"PA loop back frequency",
			"PA loop back enabled/disabled"
		})]
		public int SetRFPALoopbackConfig(ushort RadarDeviceId, ushort PALoopBackFreq, ushort PALoopBackEnabled)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetPALoopBackConfigData(RadarDeviceId, PALoopBackFreq, PALoopBackEnabled);
		}

		[AttrLuaFunc("SetRFPSLoopbackConfig", "SetRFPSLoopbackConfig API Defines Enables/Disables PS(Phase shifter) loopback for all enabled profiles and it used to debug both Tx and Rx chains.", new string[]
		{
			"PS loop back frequency in KHz",
			"PS loop back enabled/disabled",
			"PS loop back TXId0",
			"PS loop back TXId1",
			"PGA GAIN Index"
		})]
		public int SetRFPSLoopbackConfig(ushort PSLoopBackFreq, ushort PSLoopBackEnabled, ushort PSLoopBackTXId0, ushort PSLoopBackTXId1, ushort PGAGainIndex)
		{
			return m_GuiManager.ScriptOps.UpdateNSetPSLoopBackConfigData(1, PSLoopBackFreq, PSLoopBackEnabled, PSLoopBackTXId0, PSLoopBackTXId1, PGAGainIndex);
		}

		[AttrLuaFunc("SetRFPSLoopbackConfig_mult", "SetRFPSLoopbackConfig API Defines Enables/Disables PS(Phase shifter) loopback for all enabled profiles and it used to debug both Tx and Rx chains", new string[]
		{
			"Radar Device Id",
			"PS loop back frequency in KHz",
			"PS loop back enabled/disabled",
			"PS loop back TXId0",
			"PS loop back TXId1",
			"PGA Gain Index"
		})]
		public int SetRFPSLoopbackConfig(ushort RadarDeviceId, ushort PSLoopBackFreq, ushort PSLoopBackEnabled, ushort PSLoopBackTXId0, ushort PSLoopBackTXId1, ushort PGAGainIndex)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetPSLoopBackConfigData(RadarDeviceId, PSLoopBackFreq, PSLoopBackEnabled, PSLoopBackTXId0, PSLoopBackTXId1, PGAGainIndex);
		}

		[AttrLuaFunc("SetRFIFLoopbackConfig", "SetRFIFLoopbackConfig API Defines Enables/Disables IF loopback for all enabled profiles and it used to debug Rx IF chains", new string[]
		{
			"IF loop back frequency",
			"IF loop back enabled/disabled"
		})]
		public int SetRFIFLoopbackConfig(ushort IFLoopBackFreq, ushort IFLoopBackEnabled)
		{
			return m_GuiManager.ScriptOps.UpdateNSetIFLoopBackConfigData(1, IFLoopBackFreq, IFLoopBackEnabled);
		}

		[AttrLuaFunc("SetRFIFLoopbackConfig_mult", "SetRFIFLoopbackConfig API Defines Enables/Disables IF loopback for all enabled profiles and it used to debug Rx IF chains", new string[]
		{
			"Radar Device Id",
			"IF loop back frequency",
			"IF loop back enabled/disabled"
		})]
		public int SetRFIFLoopbackConfig(ushort RadarDeviceId, ushort IFLoopBackFreq, ushort IFLoopBackEnabled)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetIFLoopBackConfigData(RadarDeviceId, IFLoopBackFreq, IFLoopBackEnabled);
		}

		[AttrLuaFunc("SetProgFiltCoeffRamApply", "SetProgFiltCoeffRam API Defines externally program the filter coeff RAM")]
		public int SetProgFiltCoeffRam()
		{
			return m_GuiManager.ScriptOps.UpdateNSetProgramFilterCoeffRAMConfigData(1);
		}

		[AttrLuaFunc("SetProgFiltCoeffRamApply_mult", "SetProgFiltCoeffRam API Defines externally program the filter coeff RAM", new string[]
		{
			"Radar Device Id"
		})]
		public int SetProgFiltCoeffRam(ushort RadarDeviceId)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetProgramFilterCoeffRAMConfigData(RadarDeviceId);
		}

		[AttrLuaFunc("SetProgFiltCoeffRamClear_mult", "SetProgFiltCoeffRamClear API Defines externally program the filter coeff RAM values cleared ", new string[]
		{
			"Radar Device Id"
		})]
		public int SetProgFiltCoeffRamClear(ushort RadarDeviceId)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetProgramFilterCoeffRAMConfigDataClear(RadarDeviceId);
		}

		[AttrLuaFunc("SetProgFiltCoeffRamClear", "SetProgFiltCoeffRamClear API Defines externally program the filter coeff RAM values cleared ")]
		public int SetProgFiltCoeffRamClear()
		{
			return m_GuiManager.ScriptOps.UpdateNSetProgramFilterCoeffRAMConfigDataClear(1);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam1to10", "SetProgFiltCoeffRam1to10 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000ad(short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			return m_GuiManager.ScriptOps.m00008c(1, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam1to10_mult", "SetProgFiltCoeffRam1to10 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"Radar Device Id",
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000ae(ushort RadarDeviceId, short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m00008c(RadarDeviceId, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam11to20", "SetProgFiltCoeffRam11to20 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000af(short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			return m_GuiManager.ScriptOps.m00008d(1, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam11to20_mult", "SetProgFiltCoeffRam11to20 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"Radar Device Id",
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000b0(ushort RadarDeviceId, short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m00008d(RadarDeviceId, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam21to30", "SetProgFiltCoeffRam21to30 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000b1(short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			return m_GuiManager.ScriptOps.m00008e(1, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam21to30_mult", "SetProgFiltCoeffRam21to30 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"Radar Device Id",
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000b2(ushort RadarDeviceId, short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m00008e(RadarDeviceId, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam31to40", "SetProgFiltCoeffRam31to40 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000b3(short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			return m_GuiManager.ScriptOps.m00008f(1, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam31to40_mult", "SetProgFiltCoeffRam31to40 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"Radar Device Id",
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000b4(ushort RadarDeviceId, short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m00008f(RadarDeviceId, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam41to50", "SetProgFiltCoeffRam41to50 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000b5(short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			return m_GuiManager.ScriptOps.m000090(1, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam41to50_mult", "SetProgFiltCoeffRam41to50 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"Radar Device Id",
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000b6(ushort RadarDeviceId, short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m000090(RadarDeviceId, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam51to60", "SetProgFiltCoeffRam51to60 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000b7(short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			return m_GuiManager.ScriptOps.m000091(1, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam51to60_mult", "SetProgFiltCoeffRam51to60 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"Radar Device Id",
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000b8(ushort RadarDeviceId, short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m000091(RadarDeviceId, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam61to70", "SetProgFiltCoeffRam61to70 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000b9(short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			return m_GuiManager.ScriptOps.m000092(1, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam61to70_mult", "SetProgFiltCoeffRam61to70 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"Radar Device Id",
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000ba(ushort RadarDeviceId, short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m000092(RadarDeviceId, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam71to80", "SetProgFiltCoeffRam71to80 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000bb(short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			return m_GuiManager.ScriptOps.m000093(1, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam71to80_mult", "SetProgFiltCoeffRam71to80 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"Radar Device Id",
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000bc(ushort RadarDeviceId, short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m000093(RadarDeviceId, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam81to90", "SetProgFiltCoeffRam81to90 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000bd(short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			return m_GuiManager.ScriptOps.m000094(1, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam81to90_mult", "SetProgFiltCoeffRam81to90 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"Radar Device Id",
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000be(ushort RadarDeviceId, short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m000094(RadarDeviceId, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam91to100", "SetProgFiltCoeffRam91to100 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000bf(short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			return m_GuiManager.ScriptOps.m000095(1, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam91to100_mult", "SetProgFiltCoeffRam91to100 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"Radar Device Id",
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff",
			"FifthCoeff",
			"SixthCoeff",
			"SeventhCoeff",
			"EigthCoeff",
			"NineCoeff",
			"TenCoeff"
		})]
		public int m0000c0(ushort RadarDeviceId, short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff, short FifthCoeff, short SixthCoeff, short SeventhCoeff, short EigthCoeff, short NinethCoeff, short TenthCoeff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m000095(RadarDeviceId, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff, FifthCoeff, SixthCoeff, SeventhCoeff, EigthCoeff, NinethCoeff, TenthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam101to104", "SetProgFiltCoeffRam101to104 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff"
		})]
		public int m0000c1(short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff)
		{
			return m_GuiManager.ScriptOps.m000096(1, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff);
		}

		[AttrLuaFunc("SetProgFiltCoeffRam101to104_mult", "SetProgFiltCoeffRam101to104 API Defines externally program the filter coeff RAM from 1 to 10", new string[]
		{
			"Radar Device Id",
			"FirstCoeff",
			"SecondCoeff",
			"ThirdCoeff",
			"FourthCoeff"
		})]
		public int m0000c2(ushort RadarDeviceId, short FirstCoeff, short SecondCoeff, short ThirdCoeff, short FourthCoeff)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m000096(RadarDeviceId, FirstCoeff, SecondCoeff, ThirdCoeff, FourthCoeff);
		}

		[AttrLuaFunc("SetProgFiltConfig", "SetProgFiltConfig API Defines externally program the filter", new string[]
		{
			"ProfileIndex",
			"PFCoeffStartIndex",
			"ProgFilterLen",
			"Freq shift factor in Fs"
		})]
		public int SetProgFilterConfig(char ProfileIndex, char PFCoeffStartIndex, char ProgFilterLen, double FreqShiftFactor)
		{
			return m_GuiManager.ScriptOps.UpdateNSetProgramFilterConfigData(1, ProfileIndex, PFCoeffStartIndex, ProgFilterLen, FreqShiftFactor);
		}

		[AttrLuaFunc("SetProgFiltConfig_mult", "SetProgFiltConfig API Defines externally program the filter", new string[]
		{
			"RadarDeviceId",
			"ProfileIndex",
			"PFCoeffStartIndex",
			"ProgFilterLen",
			"Freq shift factor in Fs"
		})]
		public int SetProgFilterConfig(ushort RadarDeviceId, char ProfileIndex, char PFCoeffStartIndex, char ProgFilterLen, double FreqShiftFactor)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetProgramFilterConfigData(RadarDeviceId, ProfileIndex, PFCoeffStartIndex, ProgFilterLen, FreqShiftFactor);
		}

		[AttrLuaFunc("SetExternalGpAdcConfig", "SetExternalGpAdcConfig API Defines Enables the GPADC reads for external inputs", new string[]
		{
			"signal input enables",
			"signal buffer enables",
			"ANATest1Cfg for Number of samples to collect[b7:0] + settling time in µs[b15:8]",
			"ANATest2Cfg for Number of samples to collect[b7:0]+ settling time in µs[b15:8]",
			"ANATest3Cfg for Number of samples to collect[b7:0]+ settling time in µs[b15:8]",
			"ANATest4Cfg for Number of samples to collect[b7:0]+ settling time in µs[b15:8]",
			"ANAMuxCfg for Number of samples to collect[b7:0]+ settling time in µs[b15:8]",
			"VSenseCfg for Number of samples to collect[b7:0]+ settling time in µs[b15:8]",
			"Reserved1",
			"Reserved2",
			"Reserved3",
			"Reserved4"
		})]
		public int SetExternalGpAdcConfig(ushort SigInputEna, ushort SigBufEna, ushort ANATest1Cfg, ushort ANATest2Cfg, ushort ANATest3Cfg, ushort ANATest4Cfg, ushort ANAMuxCfg, ushort VSenseCfg, ushort Reserved1, uint Reserved2, uint Reserved3, uint Reserved4)
		{
			return m_GuiManager.ScriptOps.UpdateNSetGPADCExternalInputsConfigData(1, SigInputEna, SigBufEna, ANATest1Cfg, ANATest2Cfg, ANATest3Cfg, ANATest4Cfg, ANAMuxCfg, VSenseCfg, Reserved1, Reserved2, Reserved3, Reserved4);
		}

		[AttrLuaFunc("SetExternalGpAdcConfig_mult", "SetExternalGpAdcConfig API Defines Enables the GPADC reads for external inputs", new string[]
		{
			"Radar Device Id",
			"signal input enables",
			"signal buffer enables",
			"ANATest1Cfg for Number of samples to collect[b7:0] + settling time in µs[b15:8]",
			"ANATest2Cfg for Number of samples to collect[b7:0]+ settling time in µs[b15:8]",
			"ANATest3Cfg for Number of samples to collect[b7:0]+ settling time in µs[b15:8]",
			"ANATest4Cfg for Number of samples to collect[b7:0]+ settling time in µs[b15:8]",
			"ANAMuxCfg for Number of samples to collect[b7:0]+ settling time in µs[b15:8]",
			"VSenseCfg for Number of samples to collect[b7:0]+ settling time in µs[b15:8]",
			"Reserved1",
			"Reserved2",
			"Reserved3",
			"Reserved4"
		})]
		public int SetExternalGpAdcConfig(ushort RadarDeviceId, ushort SigInputEna, ushort SigBufEna, ushort ANATest1Cfg, ushort ANATest2Cfg, ushort ANATest3Cfg, ushort ANATest4Cfg, ushort ANAMuxCfg, ushort VSenseCfg, ushort Reserved1, uint Reserved2, uint Reserved3, uint Reserved4)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetGPADCExternalInputsConfigData(RadarDeviceId, SigInputEna, SigBufEna, ANATest1Cfg, ANATest2Cfg, ANATest3Cfg, ANATest4Cfg, ANAMuxCfg, VSenseCfg, Reserved1, Reserved2, Reserved3, Reserved4);
		}

		[AttrLuaFunc("SetTemperatureReportConfig_mult", "SetTemperatureReportConfig API Defines the provides the device temperature sensor information", new string[]
		{
			"RadarDeviceId",
			"Reporting Period in seconds"
		})]
		public int SetTemperatureReportConfig(ushort RadarDeviceId, ushort AeReportPeriod)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetDynamicCharReportConfigData(RadarDeviceId, AeReportPeriod);
		}

		[AttrLuaFunc("SetTemperatureReportConfig", "SetTemperatureReportConfig API Defines the provides the device temperature sensor information", new string[]
		{
			"Reporting Period in seconds"
		})]
		public int SetTemperatureReportConfig(ushort AeReportPeriod)
		{
			return m_GuiManager.ScriptOps.UpdateNSetDynamicCharReportConfigData(1, AeReportPeriod);
		}

		[AttrLuaFunc("RFTemperatureGet_mult", "RF Temperature Get API Defines to provide the device temperture sensor information dynamically ", new string[]
		{
			"Radar Device Id",
			"BSS local time from device power up in ms ",
			"Rx0 temperture sensor in degree C",
			"Rx1 temperture sensor in degree C",
			"Rx2 temperture sensor in degree C",
			"Rx3 temperture sensor in degree C",
			"Tx0 temperture sensor in degree C",
			"Tx1 temperture sensor in degree C",
			"Tx2 temperture sensor in degree C",
			"PM temperture sensor in degree C",
			"Digital1 temperture sensor in degree C",
			"Digital2 temperture sensor in degree C (Applicable only in AR16xx device)"
		})]
		public int RFTemperatureGet(ushort RadarDeviceId, out uint time, out short p2, out short p3, out short p4, out short p5, out short p6, out short p7, out short p8, out short p9, out short tmpDig1Sens, out short tmpDig2Sens)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			time = 0U;
			p2 = 0;
			p3 = 0;
			p4 = 0;
			p5 = 0;
			p6 = 0;
			p7 = 0;
			p8 = 0;
			p9 = 0;
			tmpDig1Sens = 0;
			tmpDig2Sens = 0;
			return m_GuiManager.ScriptOps.iGetRFDynamicetConfig_Cmd(RadarDeviceId, out time, out p2, out p3, out p4, out p5, out p6, out p7, out p8, out p9, out tmpDig1Sens, out tmpDig2Sens);
		}

		[AttrLuaFunc("RFTemperatureGet", "RF Temperature Get API Defines to provide the device temperture sensor information dynamically ", new string[]
		{
			"BSS local time from device power up in ms ",
			"Rx0 temperture sensor in degree C",
			"Rx1 temperture sensor in degree C",
			"Rx2 temperture sensor in degree C",
			"Rx3 temperture sensor in degree C",
			"Tx0 temperture sensor in degree C",
			"Tx1 temperture sensor in degree C",
			"Tx2 temperture sensor in degree C",
			"PM temperture sensor in degree C",
			"Digital1 temperture sensor in degree C",
			"Digital2 temperture sensor in degree C (Applicable only in AR16xx device)"
		})]
		public int RFTemperatureGet(out uint time, out short p1, out short p2, out short p3, out short p4, out short p5, out short p6, out short p7, out short p8, out short tmpDig1Sens, out short tmpDig2Sens)
		{
			time = 0U;
			p1 = 0;
			p2 = 0;
			p3 = 0;
			p4 = 0;
			p5 = 0;
			p6 = 0;
			p7 = 0;
			p8 = 0;
			tmpDig1Sens = 0;
			tmpDig2Sens = 0;
			return m_GuiManager.ScriptOps.iGetRFDynamicetConfig_Cmd(1, out time, out p1, out p2, out p3, out p4, out p5, out p6, out p7, out p8, out tmpDig1Sens, out tmpDig2Sens);
		}

		[AttrLuaFunc("SetCalibDisableConfig_mult", "SetCalibDisableConfig API used to enable or disable the GPADC Temp, APLL, Synth1 and Synth2 calibration during boot time and run time of BSS for testing purpose", new string[]
		{
			"Radar Device Id",
			"Enable or disable GPADC temp read",
			"Enable or disable APLL Calibration",
			"Synth1 calibration is enabled or disabled ",
			"Synth2 calibration is enabled or disabled"
		})]
		public int SetCalibDisableConfig(ushort RadarDeviceId, uint p1, uint APLLCal, uint Synth1Cal, uint Synth2Cal)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetCalibEnaDisableConfigData(RadarDeviceId, p1, APLLCal, Synth1Cal, Synth2Cal);
		}

		[AttrLuaFunc("SetCalibDisableConfig", "SetCalibDisableConfig API used to enable or disable the GPADC Temp, APLL, Synth1 and Synth2 calibration during boot time and run time of BSS for testing purpose", new string[]
		{
			"Enable or disable GPADC temp read",
			"Enable or disable APLL Calibration",
			"Synth1 calibration is enabled or disabled ",
			"Synth2 calibration is enabled or disabled"
		})]
		public int SetCalibDisableConfig(uint p0, uint APLLCal, uint Synth1Cal, uint Synth2Cal)
		{
			return m_GuiManager.ScriptOps.UpdateNSetCalibEnaDisableConfigData(1, p0, APLLCal, Synth1Cal, Synth2Cal);
		}

		[AttrLuaFunc("SetInterChirpBlockControlsConfig", "SetInterChirpBlockControlsConfig API used to trigger the chirp config from software to hardware", new string[]
		{
			"Rx02RFTurnOffTime",
			"Rx13RFTurnOffTime",
			"Rx02BBTurnOffTime",
			"Rx13BBTurnOffTime",
			"Rx02RFPreEnableTime",
			"Rx24RFPreEnableTime",
			"Rx02BBPreEnableTime",
			"Rx13BBPreEnableTime",
			"Rx02RFTurnOnTime",
			"Rx13RFTurnOnTime",
			"Rx02BBTurnOnTime",
			"Rx13BBTurnOnTime",
			"RxLOChainTurnOffTime",
			"TxLOChainTurnOffTime",
			"RxLOChainTurnOnTime",
			"TxLOChainTurnOnTime",
			"Reserved",
			"Reserved2"
		})]
		public int SetInterChirpBlockControlsConfig(double Rx02RFTurnOffTime, double Rx13RFTurnOffTime, double Rx02BBTurnOffTime, double Rx13BBTurnOffTime, double Rx02RFPreEnableTime, double Rx24RFPreEnableTime, double Rx02BBPreEnableTime, double Rx13BBPreEnableTime, double Rx02RFTurnOnTime, double Rx13RFTurnOnTime, double Rx02BBTurnOnTime, double Rx13BBTurnOnTime, double RxLOChainTurnOffTime, double TxLOChainTurnOffTime, double RxLOChainTurnOnTime, double TxLOChainTurnOnTime, uint Reserved, uint Reserved2)
		{
			return m_GuiManager.ScriptOps.UpdateNSetInterChirpBlockControlsConfigData(1, Rx02RFTurnOffTime, Rx13RFTurnOffTime, Rx02BBTurnOffTime, Rx13BBTurnOffTime, Rx02RFPreEnableTime, Rx24RFPreEnableTime, Rx02BBPreEnableTime, Rx13BBPreEnableTime, Rx02RFTurnOnTime, Rx13RFTurnOnTime, Rx02BBTurnOnTime, Rx13BBTurnOnTime, RxLOChainTurnOffTime, TxLOChainTurnOffTime, RxLOChainTurnOnTime, TxLOChainTurnOnTime, Reserved, Reserved2);
		}

		[AttrLuaFunc("SetInterChirpBlockControlsConfig_mult", "SetInterChirpBlockControlsConfig API used to trigger the chirp config from software to hardware", new string[]
		{
			"Radar device id",
			"Rx02RFTurnOffTime",
			"Rx13RFTurnOffTime",
			"Rx02BBTurnOffTime",
			"Rx13BBTurnOffTime",
			"Rx02RFPreEnableTime",
			"Rx24RFPreEnableTime",
			"Rx02BBPreEnableTime",
			"Rx13BBPreEnableTime",
			"Rx02RFTurnOnTime",
			"Rx13RFTurnOnTime",
			"Rx02BBTurnOnTime",
			"Rx13BBTurnOnTime",
			"RxLOChainTurnOffTime",
			"TxLOChainTurnOffTime",
			"RxLOChainTurnOnTime",
			"TxLOChainTurnOnTime",
			"Reserved",
			"Reserved2"
		})]
		public int SetInterChirpBlockControlsConfig(ushort RadarDeviceId, double Rx02RFTurnOffTime, double Rx13RFTurnOffTime, double Rx02BBTurnOffTime, double Rx13BBTurnOffTime, double Rx02RFPreEnableTime, double Rx24RFPreEnableTime, double Rx02BBPreEnableTime, double Rx13BBPreEnableTime, double Rx02RFTurnOnTime, double Rx13RFTurnOnTime, double Rx02BBTurnOnTime, double Rx13BBTurnOnTime, double RxLOChainTurnOffTime, double TxLOChainTurnOffTime, double RxLOChainTurnOnTime, double TxLOChainTurnOnTime, uint Reserved, uint Reserved2)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetInterChirpBlockControlsConfigData(RadarDeviceId, Rx02RFTurnOffTime, Rx13RFTurnOffTime, Rx02BBTurnOffTime, Rx13BBTurnOffTime, Rx02RFPreEnableTime, Rx24RFPreEnableTime, Rx02BBPreEnableTime, Rx13BBPreEnableTime, Rx02RFTurnOnTime, Rx13RFTurnOnTime, Rx02BBTurnOnTime, Rx13BBTurnOnTime, RxLOChainTurnOffTime, TxLOChainTurnOffTime, RxLOChainTurnOnTime, TxLOChainTurnOnTime, Reserved, Reserved2);
		}

		[AttrLuaFunc("SetCalibDataSaveConfig", "SetCalibDataSaveConfig API used to read the calibration data from device", new string[]
		{
			"Index of requested chunk",
			"Reserved",
			"Calibration store data file path"
		})]
		public int SetCalibDataSaveConfig(ushort ChunkID, ushort Reserved, string CalibStoreFilePath)
		{
			return m_GuiManager.ScriptOps.UpdateNSetCalibDataSaveConfigData(1, ChunkID, Reserved, CalibStoreFilePath);
		}

		[AttrLuaFunc("SetCalibDataSaveConfig_mult", "SetCalibDataSaveConfig API used to read the calibration data from device", new string[]
		{
			"Radar device id",
			"Index of requested chunk",
			"Reserved",
			"Calibration store data file path"
		})]
		public int SetCalibDataSaveConfig(ushort RadarDeviceId, ushort ChunkID, ushort Reserved, string CalibStoreFilePath)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetCalibDataSaveConfigData(RadarDeviceId, ChunkID, Reserved, CalibStoreFilePath);
		}

		[AttrLuaFunc("SetCalibDataRestoreConfig", "SetCalibDataRestoreConfig API used to restore the calibration data from device", new string[]
		{
			"Index of requested chunk",
			"Num chunks",
			"Calibration restore data file path"
		})]
		public int SetCalibDataRestoreConfig(ushort ChunkID, ushort NumChunks, string CalibRestoreFilePath)
		{
			return m_GuiManager.ScriptOps.UpdateNSetCalibDataRestoreConfigData(1, ChunkID, NumChunks, CalibRestoreFilePath);
		}

		[AttrLuaFunc("SetCalibDataRestoreConfig_mult", "SetCalibDataRestoreConfig API used to restore the calibration data from device", new string[]
		{
			"Radar device id",
			"Index of requested chunk",
			"Num chunks",
			"Calibration restore data file path"
		})]
		public int SetCalibDataRestoreConfig(ushort RadarDeviceId, ushort ChunkID, ushort NumChunks, string CalibRestoreFilePath)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetCalibDataRestoreConfigData(RadarDeviceId, ChunkID, NumChunks, CalibRestoreFilePath);
		}

		[AttrLuaFunc("rlRfPhShifterCalibDataStore", "rlRfPhShifterCalibDataStore API used to read the phase shifter calibration data from device", new string[]
		{
			"Reserved0",
			"Reserved1",
			"Reserved2",
			"phase shifter calibration store data file path"
		})]
		public int RfPhShifterCalibDataStore(ushort Reserved0, ushort Reserved1, ushort Reserved2, string PhaseShiterCalibStoreFilePath)
		{
			return m_GuiManager.ScriptOps.UpdateNSetPhaseShifterCalibDataSaveConfigData(1, Reserved0, Reserved1, Reserved2, PhaseShiterCalibStoreFilePath);
		}

		[AttrLuaFunc("rlRfPhShifterCalibDataStore_mult", "rlRfPhShifterCalibDataStore API used to read the phase shifter calibration data from device", new string[]
		{
			"Radar device id",
			"Reserved0",
			"Reserved1",
			"Reserved2",
			"phase shifter calibration store data file path"
		})]
		public int RfPhShifterCalibDataStore(ushort RadarDeviceId, ushort Reserved0, ushort Reserved1, ushort Reserved2, string PhaseShiterCalibStoreFilePath)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetPhaseShifterCalibDataSaveConfigData(RadarDeviceId, Reserved0, Reserved1, Reserved2, PhaseShiterCalibStoreFilePath);
		}

		[AttrLuaFunc("rlRfPhShifterCalibDataRestore", "rlRfPhShifterCalibDataRestore API used to restore the phase shifter calibration data for Tx channles", new string[]
		{
			"Reserved0",
			"Reserved1",
			"Reserved2",
			"phase shifter calibration restore data file path"
		})]
		public int rlRfPhShifterCalibDataRestore(ushort Reserved0, ushort Reserved1, ushort Reserved2, string PhaseShiterCalibRestoreFilePath)
		{
			return m_GuiManager.ScriptOps.UpdateNSetPhaseShifterCalibDataRestoreConfigData(1, Reserved0, Reserved1, Reserved2, PhaseShiterCalibRestoreFilePath);
		}

		[AttrLuaFunc("rlRfPhShifterCalibDataRestore_mult", "rlRfPhShifterCalibDataRestore API used to restore the phase shifter calibration data for Tx channles", new string[]
		{
			"Radar device id",
			"Reserved0",
			"Reserved1",
			"Reserved2",
			"phase shifter calibration restore data file path"
		})]
		public int rlRfPhShifterCalibDataRestore(ushort RadarDeviceId, ushort Reserved0, ushort Reserved1, ushort Reserved2, string PhaseShiterCalibRestoreFilePath)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetPhaseShifterCalibDataRestoreConfigData(RadarDeviceId, Reserved0, Reserved1, Reserved2, PhaseShiterCalibRestoreFilePath);
		}

		[AttrLuaFunc("SetMCUClockOutConfig", "SetMCUClockOutConfig API used to configure to set up the desired frequency pf MCU clock that is output from device", new string[]
		{
			"Enable or disable MCU clock control",
			"Specifies the the source of MCU clock",
			"specifies the Division factor to be applied to source clock",
			"Reserved"
		})]
		public int SetMCUClockOutConfig(byte MCUClockControl, byte MCUClockSrc, byte SrcClockDiv, byte Reserved)
		{
			return m_GuiManager.ScriptOps.UpdateNSetMCUClockOutConfigData(1, MCUClockControl, MCUClockSrc, SrcClockDiv, Reserved);
		}

		[AttrLuaFunc("SetMCUClockOutConfig_mult", "SetMCUClockOutConfig API used to  configure to set up the desired frequency pf MCU clock that is output from device", new string[]
		{
			"Radar device id",
			"Enable or disable MCU clock control",
			"Specifies the the source of MCU clock",
			"specifies the Division factor to be applied to source clock",
			"Reserved"
		})]
		public int SetMCUClockOutConfig(ushort RadarDeviceId, byte MCUClockControl, byte MCUClockSrc, byte SrcClockDiv, byte Reserved)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetMCUClockOutConfigData(RadarDeviceId, MCUClockControl, MCUClockSrc, SrcClockDiv, Reserved);
		}

		[AttrLuaFunc("SetPMICClockOutConfig", "SetPMICClockOutConfig API used to to configure to set up the desired frequency pf PMIC clock that is output from device", new string[]
		{
			"Enable or disable PMIC clock control",
			"Specifies the the source of PMIC clock",
			"specifies the Division factor to be applied to source clock",
			"Specifies the the mode select of PMIC clock",
			"Frequency slope in MHz ",
			"Minimum division val",
			"Maximum division val",
			"Control the enable or disable the clock dithering",
			"Reserved"
		})]
		public int SetPMICClockOutConfig(byte PMICClockControl, byte PMICClockSrc, byte SrcClockDiv, byte ModeSelect, uint FreqSlope, byte MinNDivVal, byte MaxNDivVal, byte ClockDitherEna, byte Reserved)
		{
			return m_GuiManager.ScriptOps.UpdateNSetPMICClockOutConfigData(1, PMICClockControl, PMICClockSrc, SrcClockDiv, ModeSelect, FreqSlope, MinNDivVal, MaxNDivVal, ClockDitherEna, Reserved);
		}

		[AttrLuaFunc("SetPMICClockOutConfig_mult", "SetPMICClockOutConfig API used to to configure to set up the desired frequency pf PMIC clock that is output from device", new string[]
		{
			"Radar device id",
			"Enable or disablePMIC clock control",
			"Specifies the the source of PMIC clock",
			"specifies the Division factor to be applied to source clock",
			"Specifies the the mode select of PMIC clock",
			"Frequency slope in MHz ",
			"Minimum division val",
			"Maximum division val",
			"Control the enable or disable the clock dithering",
			"Reserved"
		})]
		public int SetPMICClockOutConfig(ushort RadarDeviceId, byte PMICClockControl, byte PMICClockSrc, byte SrcClockDiv, byte ModeSelect, uint FreqSlope, byte MinNDivVal, byte MaxNDivVal, byte ClockDitherEna, byte Reserved)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetPMICClockOutConfigData(RadarDeviceId, PMICClockControl, PMICClockSrc, SrcClockDiv, ModeSelect, FreqSlope, MinNDivVal, MaxNDivVal, ClockDitherEna, Reserved);
		}

		[AttrLuaFunc("DynChirpCfgSet", "DynChirpCfgSet API used to dynamically change chirp configuration while frame are on going", new string[]
		{
			"Chirp Row Select. \n 0 : enables all 3 chirp rows (R1, R2, R3) to be reconfigured. \n 1 : enables only R1 to be reconfigured. \n 2 : enables only R2 to be reconfigured. \n 3 : enables only R3 to be reconfigured",
			"Chirp Segment Select. \n If Row Select : 0, then upto 32 segments (each of 16 chirps) can be configured. \n If Row Select : non zero, then upto 11 segments (each of 48 chirps) can be configured with segment 11 containing 32 chirps.",
			"Program Mode. \n 0 : Program the new configuration when Dyn Chirp Enable API is issued. \n 1 : Program the new configuration immediately.",
			"Chirp1R1Conf. 3:0 - Profile Index. 13:8 - Freq Slope Var. 18:16 - TX Enable. 29:24 - BPM Constant bits",
			"Chirp1R2Conf. 22:0 - Freq Start Var",
			"Chirp1R3Conf. 11:0 - Idle time Var. 27:16 - ADC Start time Var",
			"Chirp2R1Conf. See Chirp1R1 Description",
			"Chirp2R2Conf. See Chirp1R2 Description",
			"Chirp2R3Conf. See Chirp1R3 Description",
			"Chirp3R1Conf. See Chirp1R1 Description",
			"Chirp3R2Conf. See Chirp1R2 Description",
			"Chirp3R3Conf. See Chirp1R3 Description",
			"Chirp4R1Conf. See Chirp1R1 Description",
			"Chirp4R2Conf. See Chirp1R2 Description",
			"Chirp4R3Conf. See Chirp1R3 Description",
			"Chirp5R1Conf. See Chirp1R1 Description",
			"Chirp5R2Conf. See Chirp1R2 Description",
			"Chirp5R3Conf. See Chirp1R3 Description",
			"Chirp6R1Conf. See Chirp1R1 Description",
			"Chirp6R2Conf. See Chirp1R2 Description",
			"Chirp6R3Conf. See Chirp1R3 Description",
			"Chirp7R1Conf. See Chirp1R1 Description",
			"Chirp7R2Conf. See Chirp1R2 Description",
			"Chirp7R3Conf. See Chirp1R3 Description",
			"Chirp8R1Conf. See Chirp1R1 Description",
			"Chirp8R2Conf. See Chirp1R2 Description",
			"Chirp8R3Conf. See Chirp1R3 Description",
			"Chirp9R1Conf. See Chirp1R1 Description",
			"Chirp9R2Conf. See Chirp1R2 Description",
			"Chirp9R3Conf. See Chirp1R3 Description",
			"Chirp10R1Conf. See Chirp1R1 Description",
			"Chirp10R2Conf. See Chirp1R2 Description",
			"Chirp10R3Conf. See Chirp1R3 Description",
			"Chirp11R1Conf. See Chirp1R1 Description",
			"Chirp11R2Conf. See Chirp1R2 Description",
			"Chirp11R3Conf. See Chirp1R3 Description",
			"Chirp12R1Conf. See Chirp1R1 Description",
			"Chirp12R2Conf. See Chirp1R2 Description",
			"Chirp12R3Conf. See Chirp1R3 Description",
			"Chirp13R1Conf. See Chirp1R1 Description",
			"Chirp13R2Conf. See Chirp1R2 Description",
			"Chirp13R3Conf. See Chirp1R3 Description",
			"Chirp14R1Conf. See Chirp1R1 Description",
			"Chirp14R2Conf. See Chirp1R2 Description",
			"Chirp14R3Conf. See Chirp1R3 Description",
			"Chirp14R1Conf. See Chirp1R1 Description",
			"Chirp15R2Conf. See Chirp1R2 Description",
			"Chirp15R3Conf. See Chirp1R3 Description",
			"Chirp16R1Conf. See Chirp1R1 Description",
			"Chirp16R2Conf. See Chirp1R2 Description",
			"Chirp16R3Conf. See Chirp1R3 Description"
		})]
		public int DynChirpCfgSet(byte ChirpRowSelect, byte ChirpSegmentSelect, ushort ProgramMode, uint Chirp1R1Conf, uint Chirp1R2Conf, uint Chirp1R3Conf, uint Chirp2R1Conf, uint Chirp2R2Conf, uint Chirp2R3Conf, uint Chirp3R1Conf, uint Chirp3R2Conf, uint Chirp3R3Conf, uint Chirp4R1Conf, uint Chirp4R2Conf, uint Chirp4R3Conf, uint Chirp5R1Conf, uint Chirp5R2Conf, uint Chirp5R3Conf, uint Chirp6R1Conf, uint Chirp6R2Conf, uint Chirp6R3Conf, uint Chirp7R1Conf, uint Chirp7R2Conf, uint Chirp7R3Conf, uint Chirp8R1Conf, uint Chirp8R2Conf, uint Chirp8R3Conf, uint Chirp9R1Conf, uint Chirp9R2Conf, uint Chirp9R3Conf, uint Chirp10R1Conf, uint Chirp10R2Conf, uint Chirp10R3Conf, uint Chirp11R1Conf, uint Chirp11R2Conf, uint Chirp11R3Conf, uint Chirp12R1Conf, uint Chirp12R2Conf, uint Chirp12R3Conf, uint Chirp13R1Conf, uint Chirp13R2Conf, uint Chirp13R3Conf, uint Chirp14R1Conf, uint Chirp14R2Conf, uint Chirp14R3Conf, uint Chirp15R1Conf, uint Chirp15R2Conf, uint Chirp15R3Conf, uint Chirp16R1Conf, uint Chirp16R2Conf, uint Chirp16R3Conf)
		{
			GlobalRef.lua_method = 1;
			int result = m_GuiManager.ScriptOps.UpdateNSetDynamicChirpConfigData(1, ChirpRowSelect, ChirpSegmentSelect, ProgramMode, Chirp1R1Conf, Chirp1R2Conf, Chirp1R3Conf, Chirp2R1Conf, Chirp2R2Conf, Chirp2R3Conf, Chirp3R1Conf, Chirp3R2Conf, Chirp3R3Conf, Chirp4R1Conf, Chirp4R2Conf, Chirp4R3Conf, Chirp5R1Conf, Chirp5R2Conf, Chirp5R3Conf, Chirp6R1Conf, Chirp6R2Conf, Chirp6R3Conf, Chirp7R1Conf, Chirp7R2Conf, Chirp7R3Conf, Chirp8R1Conf, Chirp8R2Conf, Chirp8R3Conf, Chirp9R1Conf, Chirp9R2Conf, Chirp9R3Conf, Chirp10R1Conf, Chirp10R2Conf, Chirp10R3Conf, Chirp11R1Conf, Chirp11R2Conf, Chirp11R3Conf, Chirp12R1Conf, Chirp12R2Conf, Chirp12R3Conf, Chirp13R1Conf, Chirp13R2Conf, Chirp13R3Conf, Chirp14R1Conf, Chirp14R2Conf, Chirp14R3Conf, Chirp15R1Conf, Chirp15R2Conf, Chirp15R3Conf, Chirp16R1Conf, Chirp16R2Conf, Chirp16R3Conf);
			GlobalRef.lua_method = 0;
			return result;
		}

		[AttrLuaFunc("DynChirpCfgSet_mult", "DynChirpCfgSet API used to dynamically change chirp configuration while frame are on going", new string[]
		{
			"Radar Device Id",
			"Chirp Row Select. \n 0 : enables all 3 chirp rows (R1, R2, R3) to be reconfigured. \n 1 : enables only R1 to be reconfigured. \n 2 : enables only R2 to be reconfigured. \n 3 : enables only R3 to be reconfigured",
			"Chirp Segment Select. \n If Row Select : 0, then upto 32 segments (each of 16 chirps) can be configured. \n If Row Select : non zero, then upto 11 segments (each of 48 chirps) can be configured with segment 11 containing 32 chirps.",
			"Program Mode. \n 0 : Program the new configuration when Dyn Chirp Enable API is issued. \n 1 : Program the new configuration immediately.",
			"Chirp1R1Conf. 3:0 - Profile Index. 13:8 - Freq Slope Var. 18:16 - TX Enable. 29:24 - BPM Constant bits",
			"Chirp1R2Conf. 22:0 - Freq Start Var",
			"Chirp1R3Conf. 11:0 - Idle time Var. 27:16 - ADC Start time Var",
			"Chirp2R1Conf. See Chirp1R1 Description",
			"Chirp2R2Conf. See Chirp1R2 Description",
			"Chirp2R3Conf. See Chirp1R3 Description",
			"Chirp3R1Conf. See Chirp1R1 Description",
			"Chirp3R2Conf. See Chirp1R2 Description",
			"Chirp3R3Conf. See Chirp1R3 Description",
			"Chirp4R1Conf. See Chirp1R1 Description",
			"Chirp4R2Conf. See Chirp1R2 Description",
			"Chirp4R3Conf. See Chirp1R3 Description",
			"Chirp5R1Conf. See Chirp1R1 Description",
			"Chirp5R2Conf. See Chirp1R2 Description",
			"Chirp5R3Conf. See Chirp1R3 Description",
			"Chirp6R1Conf. See Chirp1R1 Description",
			"Chirp6R2Conf. See Chirp1R2 Description",
			"Chirp6R3Conf. See Chirp1R3 Description",
			"Chirp7R1Conf. See Chirp1R1 Description",
			"Chirp7R2Conf. See Chirp1R2 Description",
			"Chirp7R3Conf. See Chirp1R3 Description",
			"Chirp8R1Conf. See Chirp1R1 Description",
			"Chirp8R2Conf. See Chirp1R2 Description",
			"Chirp8R3Conf. See Chirp1R3 Description",
			"Chirp9R1Conf. See Chirp1R1 Description",
			"Chirp9R2Conf. See Chirp1R2 Description",
			"Chirp9R3Conf. See Chirp1R3 Description",
			"Chirp10R1Conf. See Chirp1R1 Description",
			"Chirp10R2Conf. See Chirp1R2 Description",
			"Chirp10R3Conf. See Chirp1R3 Description",
			"Chirp11R1Conf. See Chirp1R1 Description",
			"Chirp11R2Conf. See Chirp1R2 Description",
			"Chirp11R3Conf. See Chirp1R3 Description",
			"Chirp12R1Conf. See Chirp1R1 Description",
			"Chirp12R2Conf. See Chirp1R2 Description",
			"Chirp12R3Conf. See Chirp1R3 Description",
			"Chirp13R1Conf. See Chirp1R1 Description",
			"Chirp13R2Conf. See Chirp1R2 Description",
			"Chirp13R3Conf. See Chirp1R3 Description",
			"Chirp14R1Conf. See Chirp1R1 Description",
			"Chirp14R2Conf. See Chirp1R2 Description",
			"Chirp14R3Conf. See Chirp1R3 Description",
			"Chirp14R1Conf. See Chirp1R1 Description",
			"Chirp15R2Conf. See Chirp1R2 Description",
			"Chirp15R3Conf. See Chirp1R3 Description",
			"Chirp16R1Conf. See Chirp1R1 Description",
			"Chirp16R2Conf. See Chirp1R2 Description",
			"Chirp16R3Conf. See Chirp1R3 Description"
		})]
		public int DynChirpCfgSet(ushort RadarDeviceId, byte ChirpRowSelect, byte ChirpSegmentSelect, ushort ProgramMode, uint Chirp1R1Conf, uint Chirp1R2Conf, uint Chirp1R3Conf, uint Chirp2R1Conf, uint Chirp2R2Conf, uint Chirp2R3Conf, uint Chirp3R1Conf, uint Chirp3R2Conf, uint Chirp3R3Conf, uint Chirp4R1Conf, uint Chirp4R2Conf, uint Chirp4R3Conf, uint Chirp5R1Conf, uint Chirp5R2Conf, uint Chirp5R3Conf, uint Chirp6R1Conf, uint Chirp6R2Conf, uint Chirp6R3Conf, uint Chirp7R1Conf, uint Chirp7R2Conf, uint Chirp7R3Conf, uint Chirp8R1Conf, uint Chirp8R2Conf, uint Chirp8R3Conf, uint Chirp9R1Conf, uint Chirp9R2Conf, uint Chirp9R3Conf, uint Chirp10R1Conf, uint Chirp10R2Conf, uint Chirp10R3Conf, uint Chirp11R1Conf, uint Chirp11R2Conf, uint Chirp11R3Conf, uint Chirp12R1Conf, uint Chirp12R2Conf, uint Chirp12R3Conf, uint Chirp13R1Conf, uint Chirp13R2Conf, uint Chirp13R3Conf, uint Chirp14R1Conf, uint Chirp14R2Conf, uint Chirp14R3Conf, uint Chirp15R1Conf, uint Chirp15R2Conf, uint Chirp15R3Conf, uint Chirp16R1Conf, uint Chirp16R2Conf, uint Chirp16R3Conf)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			GlobalRef.lua_method = 1;
			int result = m_GuiManager.ScriptOps.UpdateNSetDynamicChirpConfigData(RadarDeviceId, ChirpRowSelect, ChirpSegmentSelect, ProgramMode, Chirp1R1Conf, Chirp1R2Conf, Chirp1R3Conf, Chirp2R1Conf, Chirp2R2Conf, Chirp2R3Conf, Chirp3R1Conf, Chirp3R2Conf, Chirp3R3Conf, Chirp4R1Conf, Chirp4R2Conf, Chirp4R3Conf, Chirp5R1Conf, Chirp5R2Conf, Chirp5R3Conf, Chirp6R1Conf, Chirp6R2Conf, Chirp6R3Conf, Chirp7R1Conf, Chirp7R2Conf, Chirp7R3Conf, Chirp8R1Conf, Chirp8R2Conf, Chirp8R3Conf, Chirp9R1Conf, Chirp9R2Conf, Chirp9R3Conf, Chirp10R1Conf, Chirp10R2Conf, Chirp10R3Conf, Chirp11R1Conf, Chirp11R2Conf, Chirp11R3Conf, Chirp12R1Conf, Chirp12R2Conf, Chirp12R3Conf, Chirp13R1Conf, Chirp13R2Conf, Chirp13R3Conf, Chirp14R1Conf, Chirp14R2Conf, Chirp14R3Conf, Chirp15R1Conf, Chirp15R2Conf, Chirp15R3Conf, Chirp16R1Conf, Chirp16R2Conf, Chirp16R3Conf);
			GlobalRef.lua_method = 0;
			return result;
		}

		[AttrLuaFunc("DynamicChirpEnableCfgSet", "DynamicChirpEnableCfgSet API used to trigger the copy of chirp configuration from software to hardware . the copy take place at the end of going frame", new string[]
		{
			"Reserved"
		})]
		public int DynamicChirpEnableCfgSet(uint Reserved)
		{
			return m_GuiManager.ScriptOps.UpdateNSetDynamicChirpEnableConfigData(1, Reserved);
		}

		[AttrLuaFunc("DynamicChirpEnableCfgSet_mult", "DynamicChirpEnableCfgSet API used to trigger the copy of chirp configuration from software to hardware .The copy take place at the end of going frame", new string[]
		{
			"Radar Device Id",
			"Reserved"
		})]
		public int DynamicChirpEnableCfgSet(ushort RadarDeviceId, uint Reserved)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetDynamicChirpEnableConfigData(RadarDeviceId, Reserved);
		}

		[AttrLuaFunc("DynPerChirpPhShifterCfgSet", "DynPerChirpPhShifterCfgSet API used to dynamically change the per-chirp phase shift configuration while frame are on going", new string[]
		{
			"Reserved",
			"Chirp Segment Select",
			"Chirp1Tx0PhaseShifter",
			"Chirp1Tx1PhaseShifter",
			"Chirp1Tx2PhaseShifter",
			"Chirp2Tx0PhaseShifter",
			"Chirp2Tx1PhaseShifter",
			"Chirp2Tx2PhaseShifter",
			"Chirp3Tx0PhaseShifter",
			"Chirp3Tx1PhaseShifter",
			"Chirp3Tx2PhaseShifter",
			"Chirp4Tx0PhaseShifter",
			"Chirp4Tx1PhaseShifter",
			"Chirp4Tx2PhaseShifter",
			"Chirp5Tx0PhaseShifter",
			"Chirp5Tx1PhaseShifter",
			"Chirp5Tx2PhaseShifter",
			"Chirp6Tx0PhaseShifter",
			"Chirp6Tx1PhaseShifter",
			"Chirp6Tx2PhaseShifter",
			"Chirp7Tx0PhaseShifter",
			"Chirp7Tx1PhaseShifter",
			"Chirp7Tx2PhaseShifter",
			"Chirp8Tx0PhaseShifter",
			"Chirp8Tx1PhaseShifter",
			"Chirp8Tx2PhaseShifter",
			"Chirp9Tx0PhaseShifter",
			"Chirp9Tx1PhaseShifter",
			"Chirp9Tx2PhaseShifter",
			"Chirp10Tx0PhaseShifter",
			"Chirp10Tx1PhaseShifter",
			"Chirp10Tx2PhaseShifter",
			"Chirp1Tx0PhaseShifter",
			"Chirp11Tx1PhaseShifter",
			"Chirp11Tx2PhaseShifter",
			"Chirp12Tx0PhaseShifter",
			"Chirp12Tx1PhaseShifter",
			"Chirp12Tx2PhaseShifter",
			"Chirp13Tx0PhaseShifter",
			"Chirp13Tx1PhaseShifter",
			"Chirp13Tx2PhaseShifter",
			"Chirp14Tx0PhaseShifter",
			"Chirp14Tx1PhaseShifter",
			"Chirp14Tx2PhaseShifter",
			"Chirp15Tx0PhaseShifter",
			"Chirp15Tx1PhaseShifter",
			"Chirp15Tx2PhaseShifter",
			"Chirp16Tx0PhaseShifter",
			"Chirp16Tx1PhaseShifter",
			"Chirp16Tx2PhaseShifter",
			"Reserved2"
		})]
		public int DynPerChirpPhShifterCfgSet(byte Reserved, byte ChirpSegmentSelect, byte Chirp1Tx0PhaseShifter, byte Chirp1Tx1PhaseShifter, byte Chirp1Tx2PhaseShifter, byte Chirp2Tx0PhaseShifter, byte Chirp2Tx1PhaseShifter, byte Chirp2Tx2PhaseShifter, byte Chirp3Tx0PhaseShifter, byte Chirp3Tx1PhaseShifter, byte Chirp3Tx2PhaseShifter, byte Chirp4Tx0PhaseShifter, byte Chirp4Tx1PhaseShifter, byte Chirp4Tx2PhaseShifter, byte Chirp5Tx0PhaseShifter, byte Chirp5Tx1PhaseShifter, byte Chirp5Tx2PhaseShifter, byte Chirp6Tx0PhaseShifter, byte Chirp6Tx1PhaseShifter, byte Chirp6Tx2PhaseShifter, byte Chirp7Tx0PhaseShifter, byte Chirp7Tx1PhaseShifter, byte Chirp7Tx2PhaseShifter, byte Chirp8Tx0PhaseShifter, byte Chirp8Tx1PhaseShifter, byte Chirp8Tx2PhaseShifter, byte Chirp9Tx0PhaseShifter, byte Chirp9Tx1PhaseShifter, byte Chirp9Tx2PhaseShifter, byte Chirp10Tx0PhaseShifter, byte Chirp10Tx1PhaseShifter, byte Chirp10Tx2PhaseShifter, byte Chirp11Tx0PhaseShifter, byte Chirp11Tx1PhaseShifter, byte Chirp11Tx2PhaseShifter, byte Chirp12Tx0PhaseShifter, byte Chirp12Tx1PhaseShifter, byte Chirp12Tx2PhaseShifter, byte Chirp13Tx0PhaseShifter, byte Chirp13Tx1PhaseShifter, byte Chirp13Tx2PhaseShifter, byte Chirp14Tx0PhaseShifter, byte Chirp14Tx1PhaseShifter, byte Chirp14Tx2PhaseShifter, byte Chirp15Tx0PhaseShifter, byte Chirp15Tx1PhaseShifter, byte Chirp15Tx2PhaseShifter, byte Chirp16Tx0PhaseShifter, byte Chirp16Tx1PhaseShifter, byte Chirp16Tx2PhaseShifter, ushort Reserved2)
		{
			return m_GuiManager.ScriptOps.UpdateNSetDynamicPerChirpConfigData(1, Reserved, ChirpSegmentSelect, Chirp1Tx0PhaseShifter, Chirp1Tx1PhaseShifter, Chirp1Tx2PhaseShifter, Chirp2Tx0PhaseShifter, Chirp2Tx1PhaseShifter, Chirp2Tx2PhaseShifter, Chirp3Tx0PhaseShifter, Chirp3Tx1PhaseShifter, Chirp3Tx2PhaseShifter, Chirp4Tx0PhaseShifter, Chirp4Tx1PhaseShifter, Chirp4Tx2PhaseShifter, Chirp5Tx0PhaseShifter, Chirp5Tx1PhaseShifter, Chirp5Tx2PhaseShifter, Chirp6Tx0PhaseShifter, Chirp6Tx1PhaseShifter, Chirp6Tx2PhaseShifter, Chirp7Tx0PhaseShifter, Chirp7Tx1PhaseShifter, Chirp7Tx2PhaseShifter, Chirp8Tx0PhaseShifter, Chirp8Tx1PhaseShifter, Chirp8Tx2PhaseShifter, Chirp9Tx0PhaseShifter, Chirp9Tx1PhaseShifter, Chirp9Tx2PhaseShifter, Chirp10Tx0PhaseShifter, Chirp10Tx1PhaseShifter, Chirp10Tx2PhaseShifter, Chirp11Tx0PhaseShifter, Chirp11Tx1PhaseShifter, Chirp11Tx2PhaseShifter, Chirp12Tx0PhaseShifter, Chirp12Tx1PhaseShifter, Chirp12Tx2PhaseShifter, Chirp13Tx0PhaseShifter, Chirp13Tx1PhaseShifter, Chirp13Tx2PhaseShifter, Chirp14Tx0PhaseShifter, Chirp14Tx1PhaseShifter, Chirp14Tx2PhaseShifter, Chirp15Tx0PhaseShifter, Chirp15Tx1PhaseShifter, Chirp15Tx2PhaseShifter, Chirp16Tx0PhaseShifter, Chirp16Tx1PhaseShifter, Chirp16Tx2PhaseShifter, Reserved2);
		}

		[AttrLuaFunc("DynPerChirpPhShifterCfgSet_mult", "DynPerChirpPhShifterCfgSet API used to dynamically change the per-chirp phase shift configuration while frame are on going", new string[]
		{
			"Radar Device Id",
			"Reserved",
			"Chirp Segment Select",
			"Chirp1Tx0PhaseShifter",
			"Chirp1Tx1PhaseShifter",
			"Chirp1Tx2PhaseShifter",
			"Chirp2Tx0PhaseShifter",
			"Chirp2Tx1PhaseShifter",
			"Chirp2Tx2PhaseShifter",
			"Chirp3Tx0PhaseShifter",
			"Chirp3Tx1PhaseShifter",
			"Chirp3Tx2PhaseShifter",
			"Chirp4Tx0PhaseShifter",
			"Chirp4Tx1PhaseShifter",
			"Chirp4Tx2PhaseShifter",
			"Chirp5Tx0PhaseShifter",
			"Chirp5Tx1PhaseShifter",
			"Chirp5Tx2PhaseShifter",
			"Chirp6Tx0PhaseShifter",
			"Chirp6Tx1PhaseShifter",
			"Chirp6Tx2PhaseShifter",
			"Chirp7Tx0PhaseShifter",
			"Chirp7Tx1PhaseShifter",
			"Chirp7Tx2PhaseShifter",
			"Chirp8Tx0PhaseShifter",
			"Chirp8Tx1PhaseShifter",
			"Chirp8Tx2PhaseShifter",
			"Chirp9Tx0PhaseShifter",
			"Chirp9Tx1PhaseShifter",
			"Chirp9Tx2PhaseShifter",
			"Chirp10Tx0PhaseShifter",
			"Chirp10Tx1PhaseShifter",
			"Chirp10Tx2PhaseShifter",
			"Chirp1Tx0PhaseShifter",
			"Chirp11Tx1PhaseShifter",
			"Chirp11Tx2PhaseShifter",
			"Chirp12Tx0PhaseShifter",
			"Chirp12Tx1PhaseShifter",
			"Chirp12Tx2PhaseShifter",
			"Chirp13Tx0PhaseShifter",
			"Chirp13Tx1PhaseShifter",
			"Chirp13Tx2PhaseShifter",
			"Chirp14Tx0PhaseShifter",
			"Chirp14Tx1PhaseShifter",
			"Chirp14Tx2PhaseShifter",
			"Chirp15Tx0PhaseShifter",
			"Chirp15Tx1PhaseShifter",
			"Chirp15Tx2PhaseShifter",
			"Chirp16Tx0PhaseShifter",
			"Chirp16Tx1PhaseShifter",
			"Chirp16Tx2PhaseShifter",
			"Reserved2"
		})]
		public int DynPerChirpPhShifterCfgSet(ushort RadarDeviceId, byte Reserved, byte ChirpSegmentSelect, byte Chirp1Tx0PhaseShifter, byte Chirp1Tx1PhaseShifter, byte Chirp1Tx2PhaseShifter, byte Chirp2Tx0PhaseShifter, byte Chirp2Tx1PhaseShifter, byte Chirp2Tx2PhaseShifter, byte Chirp3Tx0PhaseShifter, byte Chirp3Tx1PhaseShifter, byte Chirp3Tx2PhaseShifter, byte Chirp4Tx0PhaseShifter, byte Chirp4Tx1PhaseShifter, byte Chirp4Tx2PhaseShifter, byte Chirp5Tx0PhaseShifter, byte Chirp5Tx1PhaseShifter, byte Chirp5Tx2PhaseShifter, byte Chirp6Tx0PhaseShifter, byte Chirp6Tx1PhaseShifter, byte Chirp6Tx2PhaseShifter, byte Chirp7Tx0PhaseShifter, byte Chirp7Tx1PhaseShifter, byte Chirp7Tx2PhaseShifter, byte Chirp8Tx0PhaseShifter, byte Chirp8Tx1PhaseShifter, byte Chirp8Tx2PhaseShifter, byte Chirp9Tx0PhaseShifter, byte Chirp9Tx1PhaseShifter, byte Chirp9Tx2PhaseShifter, byte Chirp10Tx0PhaseShifter, byte Chirp10Tx1PhaseShifter, byte Chirp10Tx2PhaseShifter, byte Chirp11Tx0PhaseShifter, byte Chirp11Tx1PhaseShifter, byte Chirp11Tx2PhaseShifter, byte Chirp12Tx0PhaseShifter, byte Chirp12Tx1PhaseShifter, byte Chirp12Tx2PhaseShifter, byte Chirp13Tx0PhaseShifter, byte Chirp13Tx1PhaseShifter, byte Chirp13Tx2PhaseShifter, byte Chirp14Tx0PhaseShifter, byte Chirp14Tx1PhaseShifter, byte Chirp14Tx2PhaseShifter, byte Chirp15Tx0PhaseShifter, byte Chirp15Tx1PhaseShifter, byte Chirp15Tx2PhaseShifter, byte Chirp16Tx0PhaseShifter, byte Chirp16Tx1PhaseShifter, byte Chirp16Tx2PhaseShifter, ushort Reserved2)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetDynamicPerChirpConfigData(RadarDeviceId, Reserved, ChirpSegmentSelect, Chirp1Tx0PhaseShifter, Chirp1Tx1PhaseShifter, Chirp1Tx2PhaseShifter, Chirp2Tx0PhaseShifter, Chirp2Tx1PhaseShifter, Chirp2Tx2PhaseShifter, Chirp3Tx0PhaseShifter, Chirp3Tx1PhaseShifter, Chirp3Tx2PhaseShifter, Chirp4Tx0PhaseShifter, Chirp4Tx1PhaseShifter, Chirp4Tx2PhaseShifter, Chirp5Tx0PhaseShifter, Chirp5Tx1PhaseShifter, Chirp5Tx2PhaseShifter, Chirp6Tx0PhaseShifter, Chirp6Tx1PhaseShifter, Chirp6Tx2PhaseShifter, Chirp7Tx0PhaseShifter, Chirp7Tx1PhaseShifter, Chirp7Tx2PhaseShifter, Chirp8Tx0PhaseShifter, Chirp8Tx1PhaseShifter, Chirp8Tx2PhaseShifter, Chirp9Tx0PhaseShifter, Chirp9Tx1PhaseShifter, Chirp9Tx2PhaseShifter, Chirp10Tx0PhaseShifter, Chirp10Tx1PhaseShifter, Chirp10Tx2PhaseShifter, Chirp11Tx0PhaseShifter, Chirp11Tx1PhaseShifter, Chirp11Tx2PhaseShifter, Chirp12Tx0PhaseShifter, Chirp12Tx1PhaseShifter, Chirp12Tx2PhaseShifter, Chirp13Tx0PhaseShifter, Chirp13Tx1PhaseShifter, Chirp13Tx2PhaseShifter, Chirp14Tx0PhaseShifter, Chirp14Tx1PhaseShifter, Chirp14Tx2PhaseShifter, Chirp15Tx0PhaseShifter, Chirp15Tx1PhaseShifter, Chirp15Tx2PhaseShifter, Chirp16Tx0PhaseShifter, Chirp16Tx1PhaseShifter, Chirp16Tx2PhaseShifter, Reserved2);
		}

		[AttrLuaFunc("SetTestPatternConfig", "SetTestPatternConfig API used configurations to set up the test pattern to be generated and transferred over the selected high speed interface(LVDS/CSI2)", new string[]
		{
			"TestPattern Generatimg Ctl enable or disable",
			"TestPattern Generating Timing",
			"Testpattern packet size",
			"Num test pattern pkts",
			"TestPatternRx0ICfg1",
			"TestPatternRx0ICfg2",
			"TestPatternRx0QCfg1",
			"TestPatternRx0QCfg2",
			"TestPatternRx01ICfg1",
			"TestPatternRx1ICfg2",
			"TestPatternRx1QCfg1",
			"TestPatternRx1QCfg2",
			"TestPatternRx2ICfg1",
			"TestPatternRx2ICfg2",
			"TestPatternRx2QCfg1",
			"TestPatternRx2QCfg2",
			"TestPatternRx3ICfg1",
			"TestPatternRx3ICfg2",
			"TestPatternRx3QCfg1",
			"TestPatternRx3QCfg2",
			"Reserved"
		})]
		public int SetTestPatternConfig(byte TestPatternGenCtl, byte TestPatternGenTiming, ushort TestPatternPktSize, uint NumTestPatternPkts, ushort TestPatternRx0ICfg1, ushort TestPatternRx0ICfg2, ushort TestPatternRx0QCfg1, ushort TestPatternRx0QCfg2, ushort TestPatternRx1ICfg1, ushort TestPatternRx1ICfg2, ushort TestPatternRx1QCfg1, ushort TestPatternRx1QCfg2, ushort TestPatternRx2ICfg1, ushort TestPatternRx2ICfg2, ushort TestPatternRx2QCfg1, ushort TestPatternRx2QCfg2, ushort TestPatternRx3ICfg1, ushort TestPatternRx3ICfg2, ushort TestPatternRx3QCfg1, ushort TestPatternRx3QCfg2, uint Reserved)
		{
			return m_GuiManager.ScriptOps.UpdateNSetTestPatternGenerationConfigData(1, TestPatternGenCtl, TestPatternGenTiming, TestPatternPktSize, NumTestPatternPkts, TestPatternRx0ICfg1, TestPatternRx0ICfg2, TestPatternRx0QCfg1, TestPatternRx0QCfg2, TestPatternRx1ICfg1, TestPatternRx1ICfg2, TestPatternRx1QCfg1, TestPatternRx1QCfg2, TestPatternRx2ICfg1, TestPatternRx2ICfg2, TestPatternRx2QCfg1, TestPatternRx2QCfg2, TestPatternRx3ICfg1, TestPatternRx3ICfg2, TestPatternRx3QCfg1, TestPatternRx3QCfg2, Reserved);
		}

		[AttrLuaFunc("SetTestPatternConfig_mult", "SetTestPatternConfig API used configurations to set up the test pattern to be generated and transferred over the selected high speed interface(LVDS/CSI2)", new string[]
		{
			"Radar Device Id",
			"TestPatternGenCtl",
			"TestPatternGenTiming",
			"Testpattern packet size",
			"Num test pattern pkts",
			"TestPatternRx0ICfg1",
			"TestPatternRx0ICfg2",
			"TestPatternRx0QCfg1",
			"TestPatternRx0QCfg2",
			"TestPatternRx01ICfg1",
			"TestPatternRx1ICfg2",
			"TestPatternRx1QCfg1",
			"TestPatternRx1QCfg2",
			"TestPatternRx2ICfg1",
			"TestPatternRx2ICfg2",
			"TestPatternRx2QCfg1",
			"TestPatternRx2QCfg2",
			"TestPatternRx3ICfg1",
			"TestPatternRx3ICfg2",
			"TestPatternRx3QCfg1",
			"TestPatternRx3QCfg2",
			"Reserved"
		})]
		public int SetTestPatternConfig(ushort RadarDeviceId, byte TestPatternGenCtl, byte TestPatternGenTiming, ushort TestPatternPktSize, uint NumTestPatternPkts, ushort TestPatternRx0ICfg1, ushort TestPatternRx0ICfg2, ushort TestPatternRx0QCfg1, ushort TestPatternRx0QCfg2, ushort TestPatternRx1ICfg1, ushort TestPatternRx1ICfg2, ushort TestPatternRx1QCfg1, ushort TestPatternRx1QCfg2, ushort TestPatternRx2ICfg1, ushort TestPatternRx2ICfg2, ushort TestPatternRx2QCfg1, ushort TestPatternRx2QCfg2, ushort TestPatternRx3ICfg1, ushort TestPatternRx3ICfg2, ushort TestPatternRx3QCfg1, ushort TestPatternRx3QCfg2, uint Reserved)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetTestPatternGenerationConfigData(RadarDeviceId, TestPatternGenCtl, TestPatternGenTiming, TestPatternPktSize, NumTestPatternPkts, TestPatternRx0ICfg1, TestPatternRx0ICfg2, TestPatternRx0QCfg1, TestPatternRx0QCfg2, TestPatternRx1ICfg1, TestPatternRx1ICfg2, TestPatternRx1QCfg1, TestPatternRx1QCfg2, TestPatternRx2ICfg1, TestPatternRx2ICfg2, TestPatternRx2QCfg1, TestPatternRx2QCfg2, TestPatternRx3ICfg1, TestPatternRx3ICfg2, TestPatternRx3QCfg1, TestPatternRx3QCfg2, Reserved);
		}

		[AttrLuaFunc("SetAnalogFaultInjectionConfig", "SetAnalogFaultInjectionConfig API used to inject the faults in the analog circuits to test the corresponding monitors", new string[]
		{
			"Reserved",
			"Rx gain drop",
			"Rx phase invert",
			"Rx high noise",
			"Rx if stages fault",
			"Rx LO amp fault",
			"Tx Lo Amp fault",
			"Tx Gain drop",
			"Tx phase invert",
			"Synth fault",
			"Supply LDO fault",
			"Miscellaneous fault",
			"Miscellaneous threshold fault",
			"Reserved2",
			"Reserved3",
			"Reserved4"
		})]
		public int SetAnalogFaultInjectionConfig(byte Reserved, byte RxGainDrop, byte RxPhaseInv, byte RxHighNoise, byte RxIFStageFault, byte RxLOAmpFault, byte TxLOAmpFault, byte TxGainDrop, byte TxPhaseInv, byte SynthFault, byte SupplyLDOFault, byte MiscFault, byte MiscThresholdFault, byte Reserved2, ushort Reserved3, uint Reserved4)
		{
			return m_GuiManager.ScriptOps.UpdateNSetAnalogFaultInjectionConfigData(1, Reserved, RxGainDrop, RxPhaseInv, RxHighNoise, RxIFStageFault, RxLOAmpFault, TxLOAmpFault, TxGainDrop, TxPhaseInv, SynthFault, SupplyLDOFault, MiscFault, MiscThresholdFault, Reserved2, Reserved3, Reserved4);
		}

		[AttrLuaFunc("SetAnalogFaultInjectionConfig_mult", "SetAnalogFaultInjectionConfig API used to inject the faults in the analog circuits to test the corresponding monitors", new string[]
		{
			"Radar Device Id",
			"Reserved",
			"Rx gain drop",
			"Rx phase invert",
			"Rx high noise",
			"Rx if stages fault",
			"Rx LO amp fault",
			"Tx Lo Amp fault",
			"Tx Gain drop",
			"Tx phase invert",
			"Synth fault",
			"Supply LDO fault",
			"Miscellaneous fault",
			"Miscellaneous threshold fault",
			"Reserved2",
			"Reserved3",
			"Reserved4"
		})]
		public int SetAnalogFaultInjectionConfig(ushort RadarDeviceId, byte Reserved, byte RxGainDrop, byte RxPhaseInv, byte RxHighNoise, byte RxIFStageFault, byte RxLOAmpFault, byte TxLOAmpFault, byte TxGainDrop, byte TxPhaseInv, byte SynthFault, byte SupplyLDOFault, byte MiscFault, byte MiscThresholdFault, byte Reserved2, ushort Reserved3, uint Reserved4)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetAnalogFaultInjectionConfigData(RadarDeviceId, Reserved, RxGainDrop, RxPhaseInv, RxHighNoise, RxIFStageFault, RxLOAmpFault, TxLOAmpFault, TxGainDrop, TxPhaseInv, SynthFault, SupplyLDOFault, MiscFault, MiscThresholdFault, Reserved2, Reserved3, Reserved4);
		}

		[AttrLuaFunc("RfSetPdTrimConfig", "RfSetPdTrimConfig API used to trim peak detectors", new string[]
		{
			"PD Instance , 0-HPPD , 1-LPPD",
			"Input power for trimming both LPPD and HPPD",
			"RF input power on or off ",
			"Mode is eithe Measuremode(0) or program mode(1)"
		})]
		public int RfSetPdTrim1GHZConfig(char PDInstance, char RFInPowerIndex, char RFInPowerOn, char Mode)
		{
			return m_GuiManager.ScriptOps.UpdateNSetPDTrim1GHZConfigData(1, PDInstance, RFInPowerIndex, RFInPowerOn, Mode);
		}

		[AttrLuaFunc("RfSetPdTrimConfig_mult", "RfSetPdTrimConfig API used to trim peak detectors", new string[]
		{
			"Radar Device Id",
			"PD Instance , 0-HPPD , 1-LPPD",
			"Input power for trimming both LPPD and HPPD",
			"RF input power on or off ",
			"Mode is eithe Measuremode(0) or program mode(1)"
		})]
		public int RfSetPdTrim1GHZConfig(ushort RadarDeviceId, char PDInstance, char RFInPowerIndex, char RFInPowerOn, char Mode)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetPDTrim1GHZConfigData(RadarDeviceId, PDInstance, RFInPowerIndex, RFInPowerOn, Mode);
		}

		[AttrLuaFunc("SetRfSynthLinMonConfig", "SetRfSynthLinMonConfig API used to containing information related to synthesizer frequency error and linearity monitoring during chirping", new string[]
		{
			"Profile indicates for which this monitoring needs to be enabled",
			"0: Monitoring period without threshold check, 1: Report sends only upon a failure, 2: Monitoring period with threshold check",
			"Measured Frequency error threshold compare against threshold",
			"Monitoring start time of profile0",
			"Monitoring start time of profile1",
			"Monitoring start time of profile2",
			"Monitoring start time of profile3",
			"Data path params1 L1",
			"Data path params1 L2",
			"Data path params1 N",
			"Data path params2 S1",
			"Data path params2 S2",
			"Data path params2 S",
			"Linnearity RAM Address of profile0",
			"Linnearity RAM Address of profile1",
			"Linnearity RAM Address of profile2",
			"Linnearity RAM Address of profile3",
			"out StatusFlag",
			"out  Errorcode",
			"out Profileindex",
			"out MaxFreqErrorVal",
			"out FrequencyFailureCount",
			"out Timestamp"
		})]
		public int SetRfSynthLinMonConfig(char ProfileIndex, char ReportingMode, ushort FreqErrorThreshold, double Profile0MonStartTime, double Profile1MonStartTime, double Profile2MonStartTime, double Profile3MonStartTime, char DataPathParams1L1, char DataPathParams1L2, char DataPathParams1N, char DataPathParams2S1, char DataPathParams2S2, char DataPathParams2S, char Profile0LinearityRAMAddress, char Profile1LinearityRAMAddress, char Profile2LinearityRAMAddress, char Profile3LinearityRAMAddress, out string StatusFlag, out string Errorcode, out string Profileindex, out string MaxFreqErrorVal, out string FrequencyFailureCount, out string Timestamp)
		{
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			MaxFreqErrorVal = string.Empty;
			FrequencyFailureCount = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRfSynthFreqLinearityMonConfigData(1, ProfileIndex, ReportingMode, FreqErrorThreshold, Profile0MonStartTime, Profile1MonStartTime, Profile2MonStartTime, Profile3MonStartTime, DataPathParams1L1, DataPathParams1L2, DataPathParams1N, DataPathParams2S1, DataPathParams2S2, DataPathParams2S, Profile0LinearityRAMAddress, Profile1LinearityRAMAddress, Profile2LinearityRAMAddress, Profile3LinearityRAMAddress);
			return m_GuiManager.ScriptOps.UpdateNRfSynthFreqLinearityMonConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out MaxFreqErrorVal, out FrequencyFailureCount, out Timestamp);
		}

		[AttrLuaFunc("SetRfSynthLinMonConfig_mult", "SetRfSynthLinMonConfig API used to containing information related to synthesizer frequency error and linearity monitoring during chirping", new string[]
		{
			"Radar Device Id",
			"Profile indicates for which this monitoring needs to be enabled",
			"0: Monitoring period without threshold check, 1: Report sends only upon a failure, 2: Monitoring period with threshold check",
			"Measured Frequency error threshold compare against threshold",
			"Monitoring start time of profile0",
			"Monitoring start time of profile1",
			"Monitoring start time of profile2",
			"Monitoring start time of profile3",
			"Data path params1 L1",
			"Data path params1 L2",
			"Data path params1 N",
			"Data path params2 S1",
			"Data path params2 S2",
			"Data path params2 S",
			"Linnearity RAM Address of profile0",
			"Linnearity RAM Address of profile1",
			"Linnearity RAM Address of profile2",
			"Linnearity RAM Address of profile3",
			"out StatusFlag",
			"out  Errorcode",
			"out Profileindex",
			"out MaxFreqErrorVal",
			"out FrequencyFailureCount",
			"out Timestamp"
		})]
		public int SetRfSynthLinMonConfig(ushort RadarDeviceId, char ProfileIndex, char ReportingMode, ushort FreqErrorThreshold, double Profile0MonStartTime, double Profile1MonStartTime, double Profile2MonStartTime, double Profile3MonStartTime, char DataPathParams1L1, char DataPathParams1L2, char DataPathParams1N, char DataPathParams2S1, char DataPathParams2S2, char DataPathParams2S, char Profile0LinearityRAMAddress, char Profile1LinearityRAMAddress, char Profile2LinearityRAMAddress, char Profile3LinearityRAMAddress, out string StatusFlag, out string Errorcode, out string Profileindex, out string MaxFreqErrorVal, out string FrequencyFailureCount, out string Timestamp)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			StatusFlag = string.Empty;
			Errorcode = string.Empty;
			Profileindex = string.Empty;
			MaxFreqErrorVal = string.Empty;
			FrequencyFailureCount = string.Empty;
			Timestamp = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetRfSynthFreqLinearityMonConfigData(1, ProfileIndex, ReportingMode, FreqErrorThreshold, Profile0MonStartTime, Profile1MonStartTime, Profile2MonStartTime, Profile3MonStartTime, DataPathParams1L1, DataPathParams1L2, DataPathParams1N, DataPathParams2S1, DataPathParams2S2, DataPathParams2S, Profile0LinearityRAMAddress, Profile1LinearityRAMAddress, Profile2LinearityRAMAddress, Profile3LinearityRAMAddress);
			return m_GuiManager.ScriptOps.UpdateNRfSynthFreqLinearityMonConfigurationData_cmd(out StatusFlag, out Errorcode, out Profileindex, out MaxFreqErrorVal, out FrequencyFailureCount, out Timestamp);
		}

		[AttrLuaFunc("SetMeasPdPowerConfig", "SetMeasPdPowerConfig API used to measure the peak detectors power", new string[]
		{
			"unique Peak detector id",
			"PD LNA Gain Index",
			"Number of accumulations",
			"Number of samples to be used for each GPADC measurement",
			"PD Type",
			"pdSel",
			"pdDacVal",
			"paramVal",
			"Reserved",
			"out SumRFOn",
			"out SumRFOff",
			"out DeltaSum",
			"out  VPDRMS",
			"out PDPower",
			"out  PDMeasureStatus"
		})]
		public int SetMeasPdPowerConfig(char PDId, char p1, char NumAccumulations, char NumSamples, byte PDType, byte pdSel, byte pdDacVal, byte paramVal, uint Reserved, out string SumRFOn, out string SumRFOff, out string DeltaSum, out string p12, out string PDPower, out string PDMeasureStatus)
		{
			DeltaSum = string.Empty;
			p12 = string.Empty;
			PDPower = string.Empty;
			PDMeasureStatus = string.Empty;
			SumRFOn = string.Empty;
			SumRFOff = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetPDPowerConfigData(1, PDId, p1, NumAccumulations, NumSamples, PDType, pdSel, pdDacVal, paramVal, Reserved);
			return m_GuiManager.ScriptOps.UpdateNMeasureThePDPowerConfigData_cmd(out SumRFOn, out SumRFOff, out DeltaSum, out p12, out PDPower, out PDMeasureStatus);
		}

		[AttrLuaFunc("SetMeasPdPowerConfig_mult", "SetMeasPdPowerConfig API used to measure the peak detectors power", new string[]
		{
			"Radar Device Id",
			"unique Peak detector id",
			"PD LNA Gain Index",
			"Number of accumulations ",
			"Number of samples to be used for each GPADC measurement",
			"PD Type",
			"pdSel",
			"pdDacVal",
			"paramVal",
			"Reserved",
			"out SumRFOn",
			"out SumRFOff",
			"out DeltaSum",
			"out  VPDRMS",
			"out PDPower",
			"out  PDMeasureStatus"
		})]
		public int SetMeasPdPowerConfig(ushort RadarDeviceId, char PDId, char p2, char NumAccumulations, char NumSamples, byte PDType, byte pdSel, byte pdDacVal, byte paramVal, uint Reserved, out string SumRFOn, out string SumRFOff, out string DeltaSum, out string p13, out string PDPower, out string PDMeasureStatus)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			DeltaSum = string.Empty;
			p13 = string.Empty;
			PDPower = string.Empty;
			PDMeasureStatus = string.Empty;
			SumRFOn = string.Empty;
			SumRFOff = string.Empty;
			m_GuiManager.ScriptOps.UpdateNSetPDPowerConfigData(1, PDId, p2, NumAccumulations, NumSamples, PDType, pdSel, pdDacVal, paramVal, Reserved);
			return m_GuiManager.ScriptOps.UpdateNMeasureThePDPowerConfigData_cmd(out SumRFOn, out SumRFOff, out DeltaSum, out p13, out PDPower, out PDMeasureStatus);
		}

		[AttrLuaFunc("SetTempSensTrimConfig_mult", "SetTempSensTrimConfig API Defines the provides the temperature trim data to BSS", new string[]
		{
			"Radar Device Id",
			"Trim Temperature 1",
			"Trim Temperature 2",
			"Measured GPADC code for RX temperature sensor at temperture T1",
			"Measured GPADC code for TX temperature sensor at temperture T1",
			"Measured GPADC code for PM temperature sensor at temperture T1",
			"Measured GPADC code for DIG temperature sensor at temperture T1",
			"Measured GPADC code for RX temperature sensor at temperture T2",
			"Measured GPADC code for TX temperature sensor at temperture T2",
			"Measured GPADC code for PM temperature sensor at temperture T2",
			"Measured GPADC code for DIG temperature sensor at temperture T2"
		})]
		public int SetTempSensTrimConfig(ushort RadarDeviceId, short TrimTemp1, short TrimTemp2, ushort TrimCodeRx1, ushort TrimCodeTx1, ushort TrimCodePm1, ushort TrimCodeDig1, ushort TrimCodeRx2, ushort TrimCodeTx2, ushort TrimCodePm2, ushort TrimCodeDig2)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNTempertureSensorTempConfigData(RadarDeviceId, TrimTemp1, TrimTemp2, TrimCodeRx1, TrimCodeTx1, TrimCodePm1, TrimCodeDig1, TrimCodeRx2, TrimCodeTx2, TrimCodePm2, TrimCodeDig2);
		}

		[AttrLuaFunc("SetTempSensTrimConfig", "SetTempSensTrimConfig API Defines the provides the temperature trim data to BSS", new string[]
		{
			"Trim Temperature 1",
			"Trim Temperature 2",
			"Measured GPADC code for RX temperature sensor at temperture T1",
			"Measured GPADC code for TX temperature sensor at temperture T1",
			"Measured GPADC code for PM temperature sensor at temperture T1",
			"Measured GPADC code for DIG temperature sensor at temperture T1",
			"Measured GPADC code for RX temperature sensor at temperture T2",
			"Measured GPADC code for TX temperature sensor at temperture T2",
			"Measured GPADC code for PM temperature sensor at temperture T2",
			"Measured GPADC code for DIG temperature sensor at temperture T2"
		})]
		public int SetTempSensTrimConfig(short TrimTemp1, short TrimTemp2, ushort TrimCodeRx1, ushort TrimCodeTx1, ushort TrimCodePm1, ushort TrimCodeDig1, ushort TrimCodeRx2, ushort TrimCodeTx2, ushort TrimCodePm2, ushort TrimCodeDig2)
		{
			return m_GuiManager.ScriptOps.UpdateNTempertureSensorTempConfigData(1, TrimTemp1, TrimTemp2, TrimCodeRx1, TrimCodeTx1, TrimCodePm1, TrimCodeDig1, TrimCodeRx2, TrimCodeTx2, TrimCodePm2, TrimCodeDig2);
		}

		[AttrLuaFunc("AdvanceFrameConfig_mult", "AdvanceFrameConfig API Defines advanced frame configuration", new string[]
		{
			"Radar Device Id",
			"Number Of SubFrames enabled in this frame(b0:15) + SW Sub-Frame triggermode(b0:31",
			"Profile is used when that chirp is transmitted(b0:7) + LoopBackCfg(LoopBackCfg(b7)+SubFrameID (b8:9)))(b7:15)",
			"SF1 Force Profile Idx",
			"SF1 Start index of the first chirp in this sub frame",
			"SF1 Number Of unique Chirps per burst",
			"SF1 Number Of times to loop through the unique chirps in each burst, without gaps, using HW",
			"SF1 Minimum time needed for triggering next burst",
			"SF1 Chirps Start Idex Offset",
			"SF1 Number Of Bursts constituting this sub frame",
			"SF1 Number Of Burst Loops",
			"SF1 SubFrame Periodicity",
			"SF2 Force Profile Idx",
			"SF2 Chirp StartIdx",
			"SF2 Num Of Chirps",
			"SF2 Number of times to loop over the set of above defined bursts for this subframe",
			"SF2BurstPeriodicity",
			"SF2 Chirp Start Idx Offset",
			"SF2 Num Of Burst",
			"SF2 Num Of BurstLoops",
			"SF2 SubFrame Periodicity",
			"SF3 Force Profile Idx",
			"SF3 Chirp StartIdx",
			"SF3 Num Of Chirps",
			"SF3 Num Of Loops",
			"SF3 Burst Periodicity",
			"SF3 Chirp Start Idx Offset",
			"SF3 Num Of Burst",
			"SF3 Num Of BurstLoops",
			"SF3 SubFrame Periodicity",
			"SF4 Force Profile Idx",
			"SF4 Chirp StartIdx",
			"SF4 Num Of Chirps",
			"SF4 Num Of Loops",
			"SF4 Burst Periodicity",
			"SF4 Chirp Start Idx Offset",
			"SF 4Num Of Burst",
			"SF4 Num Of BurstLoops",
			"SF4 SubFrame Periodicity",
			"Number Of Frames to transmit",
			"Trigger Select such as software and hardware trigger ",
			"Optional time delay from the SYNC-IN trigger to the occurance of frame chirps",
			"Num Of Clone SubFrames",
			"SF1 Total Chirps",
			"SF1 Num Of AdcSamples",
			"SF1 Num Of Chirps In DataPacket",
			"SF2 Total Chirps",
			"SF2 Num Of AdcSamples",
			"SF2 Num Of Chirps In DataPacket",
			"SF3 Total Chirps",
			"SF3 Num Of AdcSamples",
			"SF3Num Of Chirps In DataPacket",
			"SF4 Total Chirps",
			"SF4 Num Of AdcSamples",
			"SF4 Num Of Chirps In DataPacket"
		})]
		public int AdvanceFrameConfig(ushort RadarDeviceId, uint NumOfSubFrames, ushort ForceProfile, ushort SF1ForceProfileIdx, ushort SF1ChirpStartIdx, ushort SF1NumOfChirps, ushort SF1NumOfLoops, uint SF1BurstPeriodicity, ushort SF1ChirpStartIdxOffset, ushort SF1NumOfBurst, ushort SF1NumOfBurstLoops, uint SF1SubFramePeriodicity, ushort SF2ForceProfileIdx, ushort SF2ChirpStartIdx, ushort SF2NumOfChirps, ushort SF2NumOfLoops, uint SF2BurstPeriodicity, ushort SF2ChirpStartIdxOffset, ushort SF2NumOfBurst, ushort SF2NumOfBurstLoops, uint SF2SubFramePeriodicity, ushort SF3ForceProfileIdx, ushort SF3ChirpStartIdx, ushort SF3NumOfChirps, ushort SF3NumOfLoops, uint SF3BurstPeriodicity, ushort SF3ChirpStartIdxOffset, ushort SF3NumOfBurst, ushort SF3NumOfBurstLoops, uint SF3SubFramePeriodicity, ushort SF4ForceProfileIdx, ushort SF4ChirpStartIdx, ushort SF4NumOfChirps, ushort SF4NumOfLoops, uint SF4BurstPeriodicity, ushort SF4ChirpStartIdxOffset, ushort SF4NumOfBurst, ushort SF4NumOfBurstLoops, uint SF4SubFramePeriodicity, ushort NumOfFrames, ushort TriggerSelect, uint FrameTrigDelay, byte NumOfCloneSubFrames, uint SF1TotalChirps, ushort SF1NumOfAdcSamples, byte SF1NumOfChirpsInDataPacket, uint SF2TotalChirps, ushort SF2NumOfAdcSamples, byte SF2NumOfChirpsInDataPacket, uint SF3TotalChirps, ushort SF3NumOfAdcSamples, byte SF3NumOfChirpsInDataPacket, uint SF4TotalChirps, ushort SF4NumOfAdcSamples, byte SF4NumOfChirpsInDataPacket)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNAdvanceFrameConfigConfigData(RadarDeviceId, NumOfSubFrames, ForceProfile, SF1ForceProfileIdx, SF1ChirpStartIdx, SF1NumOfChirps, SF1NumOfLoops, SF1BurstPeriodicity, SF1ChirpStartIdxOffset, SF1NumOfBurst, SF1NumOfBurstLoops, SF1SubFramePeriodicity, SF2ForceProfileIdx, SF2ChirpStartIdx, SF2NumOfChirps, SF2NumOfLoops, SF2BurstPeriodicity, SF2ChirpStartIdxOffset, SF2NumOfBurst, SF2NumOfBurstLoops, SF2SubFramePeriodicity, SF3ForceProfileIdx, SF3ChirpStartIdx, SF3NumOfChirps, SF3NumOfLoops, SF3BurstPeriodicity, SF3ChirpStartIdxOffset, SF3NumOfBurst, SF3NumOfBurstLoops, SF3SubFramePeriodicity, SF4ForceProfileIdx, SF4ChirpStartIdx, SF4NumOfChirps, SF4NumOfLoops, SF4BurstPeriodicity, SF4ChirpStartIdxOffset, SF4NumOfBurst, SF4NumOfBurstLoops, SF4SubFramePeriodicity, NumOfFrames, TriggerSelect, FrameTrigDelay, NumOfCloneSubFrames, SF1TotalChirps, SF1NumOfAdcSamples, SF1NumOfChirpsInDataPacket, SF2TotalChirps, SF2NumOfAdcSamples, SF2NumOfChirpsInDataPacket, SF3TotalChirps, SF3NumOfAdcSamples, SF3NumOfChirpsInDataPacket, SF4TotalChirps, SF4NumOfAdcSamples, SF4NumOfChirpsInDataPacket);
		}

		[AttrLuaFunc("AdvanceFrameConfig", "AdvanceFrameConfig API Defines advanced frame configuration", new string[]
		{
			"Number Of SubFrames enabled in this frame(b0:15) + SW Sub-Frame triggermode(b0:31)",
			"Profile is used when that chirp is transmitted(b0:7) + LoopBackCfg(LoopBackCfg(b7)+SubFrameID (b8:9)))(b7:15)",
			"SF1 Force Profile Idx",
			"SF1 Start index of the first chirp in this sub frame",
			"SF1 Number Of unique Chirps per burst",
			"SF1 Number Of times to loop through the unique chirps in each burst, without gaps, using HW",
			"SF1 Minimum time needed for triggering next burst",
			"SF1 Chirps Start Idex Offset",
			"SF1 Number Of Bursts constituting this sub frame",
			"SF1 Number Of Burst Loops",
			"SF1 SubFrame Periodicity",
			"SF2 Force Profile Idx",
			"SF2 Chirp Start Idx",
			"SF2 Num Of Chirps",
			"SF2 Number of times to loop over the set of above defined bursts for this subframe",
			"SF2 Burst Periodicity",
			"SF2 Chirp Start Idx Offset",
			"SF2 Num Of Burst",
			"SF2 Num Of BurstLoops",
			"SF2 SubFrame Periodicity",
			"SF3 Force Profile Idx",
			"SF3 Chirp Start Idx",
			"SF3 Num Of Chirps",
			"SF3 Num Of Loops",
			"SF3 Burst Periodicity",
			"SF3 Chirp Start Idx Offset",
			"SF3 Num Of Burst",
			"SF3 Num Of BurstLoops",
			"SF3 SubFrame Periodicity",
			"SF4 Force Profile Idx",
			"SF4 Chirp Start Idx",
			"SF4 Num Of Chirps",
			"SF4 Num Of Loops",
			"SF4 Burst Periodicity",
			"SF4 Chirp Start Idx Offset",
			"SF4 Num Of Burst",
			"SF4 Num Of BurstLoops",
			"SF4 SubFrame Periodicity",
			"Number Of Frames to transmit",
			"Trigger Select such as software and hardware trigger ",
			"Optional time delay from the SYNC-IN trigger to the occurance of frame chirps",
			"Num Of Clone SubFrames",
			"SF1 Total Chirps",
			"SF1 Num Of AdcSamples",
			"SF1 Num Of Chirps In DataPacket",
			"SF2 Total Chirps",
			"SF2 Num Of AdcSamples",
			"SF2 Num Of Chirps In DataPacket",
			"SF3 Total Chirps",
			"SF3 Num Of AdcSamples",
			"SF3 Num Of Chirps In DataPacket",
			"SF4 Total Chirps",
			"SF4 Num Of AdcSamples",
			"SF4 Num Of Chirps In DataPacket"
		})]
		public int AdvanceFrameConfig(uint NumOfSubFrames, ushort ForceProfile, ushort SF1ForceProfileIdx, ushort SF1ChirpStartIdx, ushort SF1NumOfChirps, ushort SF1NumOfLoops, uint SF1BurstPeriodicity, ushort SF1ChirpStartIdxOffset, ushort SF1NumOfBurst, ushort SF1NumOfBurstLoops, uint SF1SubFramePeriodicity, ushort SF2ForceProfileIdx, ushort SF2ChirpStartIdx, ushort SF2NumOfChirps, ushort SF2NumOfLoops, uint SF2BurstPeriodicity, ushort SF2ChirpStartIdxOffset, ushort SF2NumOfBurst, ushort SF2NumOfBurstLoops, uint SF2SubFramePeriodicity, ushort SF3ForceProfileIdx, ushort SF3ChirpStartIdx, ushort SF3NumOfChirps, ushort SF3NumOfLoops, uint SF3BurstPeriodicity, ushort SF3ChirpStartIdxOffset, ushort SF3NumOfBurst, ushort SF3NumOfBurstLoops, uint SF3SubFramePeriodicity, ushort SF4ForceProfileIdx, ushort SF4ChirpStartIdx, ushort SF4NumOfChirps, ushort SF4NumOfLoops, uint SF4BurstPeriodicity, ushort SF4ChirpStartIdxOffset, ushort SF4NumOfBurst, ushort SF4NumOfBurstLoops, uint SF4SubFramePeriodicity, ushort NumOfFrames, ushort TriggerSelect, uint FrameTrigDelay, byte NumOfCloneSubFrames, uint SF1TotalChirps, ushort SF1NumOfAdcSamples, byte SF1NumOfChirpsInDataPacket, uint SF2TotalChirps, ushort SF2NumOfAdcSamples, byte SF2NumOfChirpsInDataPacket, uint SF3TotalChirps, ushort SF3NumOfAdcSamples, byte SF3NumOfChirpsInDataPacket, uint SF4TotalChirps, ushort SF4NumOfAdcSamples, byte SF4NumOfChirpsInDataPacket)
		{
			return m_GuiManager.ScriptOps.UpdateNAdvanceFrameConfigConfigData(1, NumOfSubFrames, ForceProfile, SF1ForceProfileIdx, SF1ChirpStartIdx, SF1NumOfChirps, SF1NumOfLoops, SF1BurstPeriodicity, SF1ChirpStartIdxOffset, SF1NumOfBurst, SF1NumOfBurstLoops, SF1SubFramePeriodicity, SF2ForceProfileIdx, SF2ChirpStartIdx, SF2NumOfChirps, SF2NumOfLoops, SF2BurstPeriodicity, SF2ChirpStartIdxOffset, SF2NumOfBurst, SF2NumOfBurstLoops, SF2SubFramePeriodicity, SF3ForceProfileIdx, SF3ChirpStartIdx, SF3NumOfChirps, SF3NumOfLoops, SF3BurstPeriodicity, SF3ChirpStartIdxOffset, SF3NumOfBurst, SF3NumOfBurstLoops, SF3SubFramePeriodicity, SF4ForceProfileIdx, SF4ChirpStartIdx, SF4NumOfChirps, SF4NumOfLoops, SF4BurstPeriodicity, SF4ChirpStartIdxOffset, SF4NumOfBurst, SF4NumOfBurstLoops, SF4SubFramePeriodicity, NumOfFrames, TriggerSelect, FrameTrigDelay, NumOfCloneSubFrames, SF1TotalChirps, SF1NumOfAdcSamples, SF1NumOfChirpsInDataPacket, SF2TotalChirps, SF2NumOfAdcSamples, SF2NumOfChirpsInDataPacket, SF3TotalChirps, SF3NumOfAdcSamples, SF3NumOfChirpsInDataPacket, SF4TotalChirps, SF4NumOfAdcSamples, SF4NumOfChirpsInDataPacket);
		}

		[AttrLuaFunc("LbBurstCfgSet", "LbBurstCfgSet API used for introduce loop back chirps within the on-going frame", new string[]
		{
			"Loop back select",
			"Base profile index",
			"Burst Index",
			"Reserved",
			"Frequency constant in GHz",
			"Slope constant in MHz/µs",
			"Reserved2",
			"Tx back off",
			"Rx gain",
			"Tx enable",
			"Reserved3",
			"BPM constant values",
			"Digital Correction enable or Disable",
			"IF Loop Back Frequency",
			"IF LoopBack Magnitude in 10mV",
			"PS1 PGA Gain Index",
			"PS2 PGA Gain Index",
			"PS LoopBack Freq in kHz (1LSB = 1kHz)",
			"Reserved4",
			"PA LoopBack Frequency in MHz(100MHz/PALoopBackFreq), 100MHz divider which sets the loopback frequency",
			"Reserved5",
			"Reserved6",
			"Reserved7"
		})]
		public int LbBurstCfgSet(byte LoopBackSelect, byte BaseProfileIndex, byte BurstIndex, byte Reserved, double FreqConst, float SlopeConst, ushort Reserved2, uint TxBackOff, ushort RxGain, byte TxEnable, byte Reserved3, ushort BPMConfig, ushort DigitalCorrectionDisable, byte IFLoopBackFreq, byte IFLoopBackMagnitude, byte p15, byte p16, uint PSLoopBackFreq, uint Reserved4, ushort PALoopBackFreq, ushort Reserved5, ushort Reserved6, ushort Reserved7)
		{
			return m_GuiManager.ScriptOps.UpdateNLoopBackBurstConfigData(1U, LoopBackSelect, BaseProfileIndex, BurstIndex, Reserved, FreqConst, SlopeConst, Reserved2, TxBackOff, RxGain, TxEnable, Reserved3, BPMConfig, DigitalCorrectionDisable, IFLoopBackFreq, IFLoopBackMagnitude, p15, p16, PSLoopBackFreq, Reserved4, PALoopBackFreq, Reserved5, Reserved6, Reserved7);
		}

		[AttrLuaFunc("LbBurstCfgSet_mult", "LbBurstCfgSet API used for introduce loop back chirps within the on-going frame", new string[]
		{
			"RadarDeviceId",
			"Loop back select",
			"Base profile index",
			"Burst Index",
			"Reserved",
			"Frequency constant in GHz",
			"Slope constant in MHz/µs",
			"Reserved2",
			"Tx back off",
			"Rx gain",
			"Tx enable",
			"Reserved3",
			"BPM constant values",
			"Digital Correction enable or Disable",
			"IF Loop Back Frequency",
			"IF LoopBack Magnitude in 10mV",
			"PS1 PGA Gain Index",
			"PS2 PGA Gain Index",
			"PS LoopBack Freq in kHz (1LSB = 1kHz)",
			"Reserved4",
			"PA LoopBack Frequency in MHz(100MHz/PALoopBackFreq), 100MHz divider which sets the loopback frequency",
			"Reserved5",
			"Reserved6",
			"Reserved7"
		})]
		public int LbBurstCfgSet(uint RadarDeviceId, byte LoopBackSelect, byte BaseProfileIndex, byte BurstIndex, byte Reserved, double FreqConst, float SlopeConst, ushort Reserved2, uint TxBackOff, ushort RxGain, byte TxEnable, byte Reserved3, ushort BPMConfig, ushort DigitalCorrectionDisable, byte IFLoopBackFreq, byte IFLoopBackMagnitude, byte p16, byte p17, uint PSLoopBackFreq, uint Reserved4, ushort PALoopBackFreq, ushort Reserved5, ushort Reserved6, ushort Reserved7)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNLoopBackBurstConfigData(RadarDeviceId, LoopBackSelect, BaseProfileIndex, BurstIndex, Reserved, FreqConst, SlopeConst, Reserved2, TxBackOff, RxGain, TxEnable, Reserved3, BPMConfig, DigitalCorrectionDisable, IFLoopBackFreq, IFLoopBackMagnitude, p16, p17, PSLoopBackFreq, Reserved4, PALoopBackFreq, Reserved5, Reserved6, Reserved7);
		}

		[AttrLuaFunc("SubFrameStartCfgSet", "SubFrameStartCfgSet API used for starts or stops transmission of sub frames ", new string[]
		{
			"Trigger a Sub-Frame in software triggered mode",
			"Reserved",
			"Reserved2"
		})]
		public int SubFrameStartCfgSet(ushort StartStopCommand, ushort Reserved, ushort Reserved2)
		{
			return m_GuiManager.ScriptOps.UpdateNSWSubFrameStartStopConfigData(1U, StartStopCommand, Reserved, Reserved2);
		}

		[AttrLuaFunc("SubFrameStartCfgSet_mult", "SubFrameStartCfgSet API used for starts or stops transmission of sub frames ", new string[]
		{
			"RadarDeviceId",
			"Trigger a Sub-Frame in software triggered mode",
			"Reserved",
			"Reserved2"
		})]
		public int SubFrameStartCfgSet(uint RadarDeviceId, ushort StartStopCommand, ushort Reserved, ushort Reserved2)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSWSubFrameStartStopConfigData(RadarDeviceId, StartStopCommand, Reserved, Reserved2);
		}

		[AttrLuaFunc("SelectCaptureDevice", "Select capture device type either TSW1400 or DCA1000 or TDA2XX", new string[]
		{
			"TSW1400 or DCA1000 or TDA2XX"
		})]
		public int SelectCaptureDevice(string DeviceType)
		{
			return m_GuiManager.MainTsForm.SelectCaptureDevice(DeviceType);
		}

		[AttrLuaFunc("DisableMonitoringLogging", "Disable/Enable the logging of Monitoring Reports in the Output Console", new string[]
		{
			"1- Disable, 0-Enable (By default)"
		})]
		public int DisableMonitoringLogging(uint mode)
		{
			return m_GuiManager.MainTsForm.CalibConfig.DisableMonitoringLogging(mode);
		}

		[AttrLuaFunc("CaptureCardConfig_EthInit", "CaptureCardConfig_EthInit API used to ethernet initialization", new string[]
		{
			"System Source IP(PC) address",
			"FPGA Destination IP address",
			"FPGA MAC address",
			"Configuration Port No",
			"Record Port No"
		})]
		public int CaptureCardConfig_EthInit(string SystemSourceIPAddress, string p1, string p2, uint ConfigPort, uint RecordPort)
		{
			return m_GuiManager.ScriptOps.UpdateNSetRFEthernetInitializationConfigurationData(1U, p2, SystemSourceIPAddress, p1, ConfigPort, RecordPort);
		}

		[AttrLuaFunc("CaptureCardConfig_Mode", "ConfigureRFDCCardMode API used to configured the ethernet mode", new string[]
		{
			"eLogMode, Raw mode : 1, Multimode:2",
			"eLvdsMode or Radar DeviceType: AR12xx or AR14:1, AR16xx or AR18xx or AR68xx:2:",
			"eDataXferMode, LVDS: 1, DMM:2",
			"eDataCaptureMode, EthernetMode:2, SDCard:1",
			"eDataFormatMode, 12-bit:1, 14-bit:2, 16-bit:3",
			"u8Timer"
		})]
		public int CaptureCardConfig_Mode(uint eLogMode, uint eLvdsMode, uint eDataXferMode, uint eDataCaptureMode, uint eDataFormatMode, byte u8Timer)
		{
			return m_GuiManager.ScriptOps.UpdateNSetRFEthernetModeConfigurationData(1U, eLogMode, eLvdsMode, eDataXferMode, eDataCaptureMode, eDataFormatMode, u8Timer);
		}

		[AttrLuaFunc("CaptureCardConfig_StartRecord", "CaptureCardConfig_StartRecord API used to start record the ADC data from RF capture card", new string[]
		{
			"ADC file name",
			"Packet sequence number enable(1) or disable(0)"
		})]
		public int CaptureCardConfig_StartRecord(string ADCFileName, byte PktSeqEnaDisable)
		{
			return m_GuiManager.ScriptOps.UpdateNSetStartRecordADCData(1U, ADCFileName, PktSeqEnaDisable);
		}

		[AttrLuaFunc("CaptureCardConfig_StopRecord", "CaptureCardConfig_StopRecord API Used to stop record the ADC data from RF capture card")]
		public int CaptureCardConfig_StopRecord()
		{
			return m_GuiManager.ScriptOps.UpdateNSetStopRecordData(1U);
		}

		[AttrLuaFunc("CaptureCardConfig_ResetFPGA", "CaptureCardConfig_ResetFPGA API API Used to reset the RF Data capture card FPGA device")]
		public int CaptureCardConfig_ResetFPGA()
		{
			return m_GuiManager.ScriptOps.UpdateNResetRFDataCaptureCardFPGAConfigData(1U);
		}

		[AttrLuaFunc("ConfigureRFDCCard_EEPROM", "ConfigureRFDCCard_EEPROM API used toconfigure the RF data capture card of EEPROM", new string[]
		{
			"System Source IP(PC) address",
			"FPGA Destination IP address",
			"FPGA MAC address",
			"Configuration Port No",
			"Record Port No"
		})]
		public int m0000c3(string SystemSourceIPAddress, string p1, string p2, uint ConfigPort, uint RecordPort)
		{
			return m_GuiManager.ScriptOps.m000097(1U, p2, SystemSourceIPAddress, p1, ConfigPort, RecordPort);
		}

		[AttrLuaFunc("CaptureCardConfig_PacketDelay", "CaptureCardConfig_PacketDelay API used to configure record data packet delay and number of bytes in a data packet sent from FPGA", new string[]
		{
			"PacketDelay(ValidRange:5 to 255 usec)"
		})]
		public int CaptureCardConfig_PacketDelay(ushort packetDelay)
		{
			return m_GuiManager.ScriptOps.UpdateNDataPacketDelayConfigData(1U, packetDelay);
		}

		[AttrLuaFunc("CaptureCard_DisConnect", "CaptureCard_DisConnect API used to disconnect the socket ")]
		public int CaptureCard_DisConnect()
		{
			return m_GuiManager.ScriptOps.UpdateNCaptureCardDisconnect(1U);
		}

		[AttrLuaFunc("GetCaptureCardFPGAVersion", "Get RF Data Capture Card FPGA Version", new string[]
		{
			"FPGA Version"
		})]
		public int GetCaptureCardFPGAVersion(out string FPGA_Version)
		{
			return m_GuiManager.ScriptOps.m000089(out FPGA_Version);
		}

		[AttrLuaFunc("GetCaptureCardDllVersion", "Get RF Data Capture Card dll Version", new string[]
		{
			"dll Version"
		})]
		public int GetCaptureCardDllVersion(out string dll_Version)
		{
			return m_GuiManager.ScriptOps.m000088(out dll_Version);
		}

		[AttrLuaFunc("CaptureCardConfig_EthInit_WithoutSPI", "CaptureCardConfig_EthInit_WithoutSPI API used to ethernet initialization", new string[]
		{
			"System Source IP(PC) address",
			"FPGA Destination IP address",
			"FPGA MAC address",
			"Configuration Port No",
			"Record Port No"
		})]
		public int CaptureCardConfig_EthInit_WithoutSPI(string SystemSourceIPAddress, string p1, string p2, uint ConfigPort, uint RecordPort)
		{
			return m_GuiManager.ScriptOps.UpdateNSetRFEthernetInitializationConfigurationData_WithoutSPI(1U, p2, SystemSourceIPAddress, p1, ConfigPort, RecordPort);
		}

		[AttrLuaFunc("CaptureCardConfig_Mode_WithoutSPI", "ConfigureRFDCCardMode_WithoutSPI API used to configured the ethernet mode", new string[]
		{
			"eLogMode, Raw mode : 1, Multimode:2",
			"eLvdsMode or Radar DeviceType: AR12xx or AR14:1, AR16xx or AR18xx or AR68xx :2:",
			"eDataXferMode, LVDS: 1, DMM:2",
			"eDataCaptureMode, EthernetMode:2, SDCard:1",
			"eDataFormatMode, 12-bit:1, 14-bit:2, 16-bit:3",
			"Reserved"
		})]
		public int CaptureCardConfig_Mode_WithoutSPI(uint eLogMode, uint eLvdsMode, uint eDataXferMode, uint eDataCaptureMode, uint eDataFormatMode, byte Reserved)
		{
			return m_GuiManager.ScriptOps.UpdateNSetRFEthernetModeConfigurationData_WithoutSPI(1U, eLogMode, eLvdsMode, eDataXferMode, eDataCaptureMode, eDataFormatMode, Reserved);
		}

		[AttrLuaFunc("CaptureCardConfig_StartRecord_WithoutSPI", "CaptureCardConfig_StartRecord_WithoutSPI API used to start record the ADC data from RF capture card", new string[]
		{
			"ADC file name",
			"Packet sequence number enable(1) or disable(0)"
		})]
		public int CaptureCardConfig_StartRecord_WithoutSPI(string ADCFileName, byte PktSeqEnaDisable)
		{
			return m_GuiManager.ScriptOps.UpdateNSetStartRecordADCData_WithoutSPI(1U, ADCFileName, PktSeqEnaDisable);
		}

		[AttrLuaFunc("CaptureCardConfig_StopRecord_WithoutSPI", "CaptureCardConfig_StopRecord_WithoutSPI API Used to stop record the ADC data from RF capture card")]
		public int CaptureCardConfig_StopRecord_WithoutSPI()
		{
			return m_GuiManager.ScriptOps.UpdateNSetStopRecordData_WithoutSPI(1U);
		}

		[AttrLuaFunc("CaptureCardConfig_ResetFPGA_WithoutSPI", "CaptureCardConfig_ResetFPGA_WithoutSPI API API Used to reset the RF Data capture card FPGA device")]
		public int CaptureCardConfig_ResetFPGA_WithoutSPI()
		{
			return m_GuiManager.ScriptOps.UpdateNResetRFDataCaptureCardFPGAConfigData_WithoutSPI(1U);
		}

		[AttrLuaFunc("ConfigureRFDCCard_EEPROM_WithoutSPI", "ConfigureRFDCCard_EEPROM_WithoutSPI API used toconfigure the RF data capture card of EEPROM", new string[]
		{
			"System Source IP(PC) address",
			"FPGA Destination IP address",
			"FPGA MAC address",
			"Configuration Port No",
			"Record Port No"
		})]
		public int m0000c4(string SystemSourceIPAddress, string p1, string p2, uint ConfigPort, uint RecordPort)
		{
			return m_GuiManager.ScriptOps.m000098(1U, p2, SystemSourceIPAddress, p1, ConfigPort, RecordPort);
		}

		[AttrLuaFunc("CaptureCardConfig_PacketDelay_WithoutSPI", "CaptureCardConfig_PacketDelay_WithoutSPI API used to configure record data packet delay and number of bytes in a data packet sent from FPGA", new string[]
		{
			"PacketDelay(ValidRange:5 to 255 usec)"
		})]
		public int CaptureCardConfig_PacketDelay_WithoutSPI(ushort packetDelay)
		{
			return m_GuiManager.ScriptOps.UpdateNDataPacketDelayConfigData_WithoutSPI(1U, packetDelay);
		}

		[AttrLuaFunc("CaptureCard_DisConnect_WithoutSPI", "CaptureCard_DisConnect_WithoutSPI API used to disconnect the socket ")]
		public int CaptureCard_DisConnect_WithoutSPI()
		{
			return m_GuiManager.ScriptOps.UpdateNCaptureCardDisconnect_WithoutSPI(1U);
		}

		[AttrLuaFunc("GetCaptureCardFPGAVersion_WithoutSPI", "Get RF Data Capture Card FPGA Version", new string[]
		{
			"FPGA Version"
		})]
		public int GetCaptureCardFPGAVersion_WithoutSPI(out string FPGA_Version)
		{
			return m_GuiManager.ScriptOps.m000089(out FPGA_Version);
		}

		[AttrLuaFunc("GetCaptureCardDllVersion_WithoutSPI", "Get RF Data Capture Card dll Version", new string[]
		{
			"dll Version"
		})]
		public int GetCaptureCardDllVersion_WithoutSPI(out string dll_Version)
		{
			return m_GuiManager.ScriptOps.m000088(out dll_Version);
		}

		[AttrLuaFunc("SetCalibMonConfig_mult", "SetCalibMonConfig API Used to trigger individual calibration and monitoring APIs for BSS for testing purposes", new string[]
		{
			"RadarDeviceId",
			"Calibration and Monitoring Id"
		})]
		public int SetCalibMonConfig(uint RadarDeviceId, uint CalibMonId)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetCalibMonConfigData(RadarDeviceId, CalibMonId);
		}

		[AttrLuaFunc("SetCalibMonConfig", "SetCalibMonConfig API Used to trigger individual calibration and monitoring APIs for BSS for testing purposes", new string[]
		{
			"Calibration and Monitoring Id"
		})]
		public int SetCalibMonConfig(uint CalibMonId)
		{
			return m_GuiManager.ScriptOps.UpdateNSetCalibMonConfigData(1U, CalibMonId);
		}

		[AttrLuaFunc("gpadcMeasurement_mult", "gpadcMeasurement API Defines to read the GPADC data for specified sensor in RF device", new string[]
		{
			"RadarDeviceId",
			"GPADC Configuration Value",
			"GPADC Parameter Value",
			"Number Of GPADC Samples to collect",
			"Number of GPADC clocks to skip before sample collection",
			"Number of GPADC clocks to skip before sample collection",
			"out GPADCMax",
			"out GPADCMin",
			"out GPADCAvg"
		})]
		public int gpadcMeasurement(uint RadarDeviceId, uint p1, byte p2, byte p3, byte RFGPADCNumOfSkipSamplesMant, byte RFGPADCNumOfSkipSamplesExp, out double ADCMaxValue, out double ADCMinValue, out double ADCAvgValue)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			ADCMaxValue = 0.0;
			ADCMinValue = 0.0;
			ADCAvgValue = 0.0;
			m_GuiManager.ScriptOps.UpdateNSetRFStatusConfigData_Cmd(RadarDeviceId, p1, p2, p3, RFGPADCNumOfSkipSamplesMant, RFGPADCNumOfSkipSamplesExp);
			return m_GuiManager.ScriptOps.iSetRFStatusConfig_Cmd(out ADCMaxValue, out ADCMinValue, out ADCAvgValue);
		}

		[AttrLuaFunc("gpadcMeasurement", "gpadcMeasurement API Defines to read the GPADC data for specified sensor in RF device", new string[]
		{
			"GPADC Configuration Value",
			"GPADC Parameter Value",
			"Number Of GPADC Samples to collect",
			"Number of GPADC clocks to skip before sample collection",
			"Number of GPADC clocks to skip before sample collection",
			"out GPADCMax",
			"out GPADCMin",
			"out GPADCAvg"
		})]
		public int gpadcMeasurement(uint p0, byte p1, byte p2, byte RFGPADCNumOfSkipSamplesMant, byte RFGPADCNumOfSkipSamplesExp, out double ADCMaxValue, out double ADCMinValue, out double ADCAvgValue)
		{
			ADCMaxValue = 0.0;
			ADCMinValue = 0.0;
			ADCAvgValue = 0.0;
			m_GuiManager.ScriptOps.UpdateNSetRFStatusConfigData_Cmd(1U, p0, p1, p2, RFGPADCNumOfSkipSamplesMant, RFGPADCNumOfSkipSamplesExp);
			return m_GuiManager.ScriptOps.iSetRFStatusConfig_Cmd(out ADCMaxValue, out ADCMinValue, out ADCAvgValue);
		}

		[AttrLuaFunc("GetTemperatureSensorData", "GetTemperatureSensorDataRead", new string[]
		{
			"out TopnearRX1",
			"out BottomnearTX2"
		})]
		public int TemperatureSensorDataRead(out double TopnearRX1, out double BottomnearTX2)
		{
			TopnearRX1 = 0.0;
			BottomnearTX2 = 0.0;
			return m_GuiManager.ScriptOps.iReadTemperatureSensorDataFromLua_Impl(out TopnearRX1, out BottomnearTX2);
		}

		[AttrLuaFunc("DFEStaticReportGet", "DFEStaticReportGet", new string[]
		{
			"out Profile0RX0Idc",
			"out Profile0RX0Qdc",
			"out Profile0RX0Ipwr",
			"out Profile0RX0Qpwr",
			"out Profile0RX0IQcrosscorr",
			"out Profile0RX1Idc",
			"out Profile0RX1Qdc",
			"out Profile0RX1Ipwr",
			"out Profile0RX1Qpwr",
			"out Profile0RX1IQcrosscorr",
			"out Profile0RX2Idc",
			"out Profile0RX2Qdc",
			"out Profile0RX2Ipwr",
			"out Profile0RX2Qpwr",
			"out Profile0RX2IQcrosscorr",
			"out Profile0RX3Idc",
			"out Profile0RX3Qdc",
			"out Profile0RX3Ipwr",
			"out Profile0RX3Qpwr",
			"out Profile0RX3IQcrosscorr",
			"out Profile1RX0Idc",
			"out Profile1RX0Qdc",
			"out Profile1RX0Ipwr",
			"out Profile1RX0Qpwr",
			"out Profile1RX0IQcrosscorr",
			"out Profile1RX1Idc",
			"out Profile1RX1Qdc",
			"out Profile1RX1Ipwr",
			"out Profile1RX1Qpwr",
			"out Profile1RX1IQcrosscorr",
			"out Profile1RX2Idc",
			"out Profile1RX2Qdc",
			"out Profile1RX2Ipwr",
			"out Profile1RX2Qpwr",
			"out Profile1RX2IQcrosscorr",
			"out Profile1RX3Idc",
			"out Profile1RX3Qdc",
			"out Profile1RX3Ipwr",
			"out Profile1RX3Qpwr",
			"out Profile1RX3IQcrosscorr",
			"out Profile2RX0Idc",
			"out Profile2RX0Qdc",
			"out Profile2RX0Ipwr",
			"out Profile2RX0Qpwr",
			"out Profile2RX0IQcrosscorr",
			"out Profile2RX1Idc",
			"out Profile2RX1Qdc",
			"out Profile2RX1Ipwr",
			"out Profile2RX1Qpwr",
			"out Profile2RX1IQcrosscorr",
			"out Profile2RX2Idc",
			"out Profile2RX2Qdc",
			"out Profile2RX2Ipwr",
			"out Profile2RX2Qpwr",
			"out Profile2RX2IQcrosscorr",
			"out Profile2RX3Idc",
			"out Profile2RX3Qdc",
			"out Profile2RX3Ipwr",
			"out Profile2RX3Qpwr",
			"out Profile2RX3IQcrosscorr",
			"out Profile3RX0Idc",
			"out Profile3RX0Qdc",
			"out Profile3RX0Ipwr",
			"out Profile3RX0Qpwr",
			"out Profile3RX0IQcrosscorr",
			"out Profile3RX1Idc",
			"out Profile3RX1Qdc",
			"out Profile3RX1Ipwr",
			"out Profile3RX1Qpwr",
			"out Profile3RX1IQcrosscorr",
			"out Profile3RX2Idc",
			"out Profile3RX2Qdc",
			"out Profile3RX2Ipwr",
			"out Profile3RX2Qpwr",
			"out Profile3RX2IQcrosscorr",
			"out Profile3RX3Idc",
			"out Profile3RX3Qdc",
			"out Profile3RX3Ipwr",
			"out Profile3RX3Qpwr",
			"out Profile3RX3IQcrosscorr"
		})]
		public int DFEStaticReportGet1(out short Profile0RX0Idc, out short Profile0RX0Qdc, out ushort Profile0RX0Ipwr, out ushort Profile0RX0Qpwr, out int Profile0RX0IQcrosscorr, out short Profile0RX1Idc, out short Profile0RX1Qdc, out ushort Profile0RX1Ipwr, out ushort Profile0RX1Qpwr, out int Profile0RX1IQcrosscorr, out short Profile0RX2Idc, out short Profile0RX2Qdc, out ushort Profile0RX2Ipwr, out ushort Profile0RX2Qpwr, out int Profile0RX2IQcrosscorr, out short Profile0RX3Idc, out short Profile0RX3Qdc, out ushort Profile0RX3Ipwr, out ushort Profile0RX3Qpwr, out int Profile0RX3IQcrosscorr, out short Profile1RX0Idc, out short Profile1RX0Qdc, out ushort Profile1RX0Ipwr, out ushort Profile1RX0Qpwr, out int Profile1RX0IQcrosscorr, out short Profile1RX1Idc, out short Profile1RX1Qdc, out ushort Profile1RX1Ipwr, out ushort Profile1RX1Qpwr, out int Profile1RX1IQcrosscorr, out short Profile1RX2Idc, out short Profile1RX2Qdc, out ushort Profile1RX2Ipwr, out ushort Profile1RX2Qpwr, out int Profile1RX2IQcrosscorr, out short Profile1RX3Idc, out short Profile1RX3Qdc, out ushort Profile1RX3Ipwr, out ushort Profile1RX3Qpwr, out int Profile1RX3IQcrosscorr, out short Profile2RX0Idc, out short Profile2RX0Qdc, out ushort Profile2RX0Ipwr, out ushort Profile2RX0Qpwr, out int Profile2RX0IQcrosscorr, out short Profile2RX1Idc, out short Profile2RX1Qdc, out ushort Profile2RX1Ipwr, out ushort Profile2RX1Qpwr, out int Profile2RX1IQcrosscorr, out short Profile2RX2Idc, out short Profile2RX2Qdc, out ushort Profile2RX2Ipwr, out ushort Profile2RX2Qpwr, out int Profile2RX2IQcrosscorr, out short Profile2RX3Idc, out short Profile2RX3Qdc, out ushort Profile2RX3Ipwr, out ushort Profile2RX3Qpwr, out int Profile2RX3IQcrosscorr, out short Profile3RX0Idc, out short Profile3RX0Qdc, out ushort Profile3RX0Ipwr, out ushort Profile3RX0Qpwr, out int Profile3RX0IQcrosscorr, out short Profile3RX1Idc, out short Profile3RX1Qdc, out ushort Profile3RX1Ipwr, out ushort Profile3RX1Qpwr, out int Profile3RX1IQcrosscorr, out short Profile3RX2Idc, out short Profile3RX2Qdc, out ushort Profile3RX2Ipwr, out ushort Profile3RX2Qpwr, out int Profile3RX2IQcrosscorr, out short Profile3RX3Idc, out short Profile3RX3Qdc, out ushort Profile3RX3Ipwr, out ushort Profile3RX3Qpwr, out int Profile3RX3IQcrosscorr)
		{
			Profile0RX0Idc = 0;
			Profile0RX0Qdc = 0;
			Profile0RX0Ipwr = 0;
			Profile0RX0Qpwr = 0;
			Profile0RX0IQcrosscorr = 0;
			Profile0RX1Idc = 0;
			Profile0RX1Qdc = 0;
			Profile0RX1Ipwr = 0;
			Profile0RX1Qpwr = 0;
			Profile0RX1IQcrosscorr = 0;
			Profile0RX2Idc = 0;
			Profile0RX2Qdc = 0;
			Profile0RX2Ipwr = 0;
			Profile0RX2Qpwr = 0;
			Profile0RX2IQcrosscorr = 0;
			Profile0RX3Idc = 0;
			Profile0RX3Qdc = 0;
			Profile0RX3Ipwr = 0;
			Profile0RX3Qpwr = 0;
			Profile0RX3IQcrosscorr = 0;
			Profile1RX0Idc = 0;
			Profile1RX0Qdc = 0;
			Profile1RX0Ipwr = 0;
			Profile1RX0Qpwr = 0;
			Profile1RX0IQcrosscorr = 0;
			Profile1RX1Idc = 0;
			Profile1RX1Qdc = 0;
			Profile1RX1Ipwr = 0;
			Profile1RX1Qpwr = 0;
			Profile1RX1IQcrosscorr = 0;
			Profile1RX2Idc = 0;
			Profile1RX2Qdc = 0;
			Profile1RX2Ipwr = 0;
			Profile1RX2Qpwr = 0;
			Profile1RX2IQcrosscorr = 0;
			Profile1RX3Idc = 0;
			Profile1RX3Qdc = 0;
			Profile1RX3Ipwr = 0;
			Profile1RX3Qpwr = 0;
			Profile1RX3IQcrosscorr = 0;
			Profile2RX0Idc = 0;
			Profile2RX0Qdc = 0;
			Profile2RX0Ipwr = 0;
			Profile2RX0Qpwr = 0;
			Profile2RX0IQcrosscorr = 0;
			Profile2RX1Idc = 0;
			Profile2RX1Qdc = 0;
			Profile2RX1Ipwr = 0;
			Profile2RX1Qpwr = 0;
			Profile2RX1IQcrosscorr = 0;
			Profile2RX2Idc = 0;
			Profile2RX2Qdc = 0;
			Profile2RX2Ipwr = 0;
			Profile2RX2Qpwr = 0;
			Profile2RX2IQcrosscorr = 0;
			Profile2RX3Idc = 0;
			Profile2RX3Qdc = 0;
			Profile2RX3Ipwr = 0;
			Profile2RX3Qpwr = 0;
			Profile2RX3IQcrosscorr = 0;
			Profile3RX0Idc = 0;
			Profile3RX0Qdc = 0;
			Profile3RX0Ipwr = 0;
			Profile3RX0Qpwr = 0;
			Profile3RX0IQcrosscorr = 0;
			Profile3RX1Idc = 0;
			Profile3RX1Qdc = 0;
			Profile3RX1Ipwr = 0;
			Profile3RX1Qpwr = 0;
			Profile3RX1IQcrosscorr = 0;
			Profile3RX2Idc = 0;
			Profile3RX2Qdc = 0;
			Profile3RX2Ipwr = 0;
			Profile3RX2Qpwr = 0;
			Profile3RX2IQcrosscorr = 0;
			Profile3RX3Idc = 0;
			Profile3RX3Qdc = 0;
			Profile3RX3Ipwr = 0;
			Profile3RX3Qpwr = 0;
			Profile3RX3IQcrosscorr = 0;
			return m_GuiManager.ScriptOps.iGetDFEStaticReportDataConfigToLauCmd_Impl(1U, out Profile0RX0Idc, out Profile0RX0Qdc, out Profile0RX0Ipwr, out Profile0RX0Qpwr, out Profile0RX0IQcrosscorr, out Profile0RX1Idc, out Profile0RX1Qdc, out Profile0RX1Ipwr, out Profile0RX1Qpwr, out Profile0RX1IQcrosscorr, out Profile0RX2Idc, out Profile0RX2Qdc, out Profile0RX2Ipwr, out Profile0RX2Qpwr, out Profile0RX2IQcrosscorr, out Profile0RX3Idc, out Profile0RX3Qdc, out Profile0RX3Ipwr, out Profile0RX3Qpwr, out Profile0RX3IQcrosscorr, out Profile1RX0Idc, out Profile1RX0Qdc, out Profile1RX0Ipwr, out Profile1RX0Qpwr, out Profile1RX0IQcrosscorr, out Profile1RX1Idc, out Profile1RX1Qdc, out Profile1RX1Ipwr, out Profile1RX1Qpwr, out Profile1RX1IQcrosscorr, out Profile1RX2Idc, out Profile1RX2Qdc, out Profile1RX2Ipwr, out Profile1RX2Qpwr, out Profile1RX2IQcrosscorr, out Profile1RX3Idc, out Profile1RX3Qdc, out Profile1RX3Ipwr, out Profile1RX3Qpwr, out Profile1RX3IQcrosscorr, out Profile2RX0Idc, out Profile2RX0Qdc, out Profile2RX0Ipwr, out Profile2RX0Qpwr, out Profile2RX0IQcrosscorr, out Profile2RX1Idc, out Profile2RX1Qdc, out Profile2RX1Ipwr, out Profile2RX1Qpwr, out Profile2RX1IQcrosscorr, out Profile2RX2Idc, out Profile2RX2Qdc, out Profile2RX2Ipwr, out Profile2RX2Qpwr, out Profile2RX2IQcrosscorr, out Profile2RX3Idc, out Profile2RX3Qdc, out Profile2RX3Ipwr, out Profile2RX3Qpwr, out Profile2RX3IQcrosscorr, out Profile3RX0Idc, out Profile3RX0Qdc, out Profile3RX0Ipwr, out Profile3RX0Qpwr, out Profile3RX0IQcrosscorr, out Profile3RX1Idc, out Profile3RX1Qdc, out Profile3RX1Ipwr, out Profile3RX1Qpwr, out Profile3RX1IQcrosscorr, out Profile3RX2Idc, out Profile3RX2Qdc, out Profile3RX2Ipwr, out Profile3RX2Qpwr, out Profile3RX2IQcrosscorr, out Profile3RX3Idc, out Profile3RX3Qdc, out Profile3RX3Ipwr, out Profile3RX3Qpwr, out Profile3RX3IQcrosscorr);
		}

		[AttrLuaFunc("DFEStaticReportGet_mult", "DFEStaticReportGet_mult", new string[]
		{
			"RadarDeviceId",
			"out Profile0RX0Idc",
			"out Profile0RX0Qdc",
			"out Profile0RX0Ipwr",
			"out Profile0RX0Qpwr",
			"out Profile0RX0IQcrosscorr",
			"out Profile0RX1Idc",
			"out Profile0RX1Qdc",
			"out Profile0RX1Ipwr",
			"out Profile0RX1Qpwr",
			"out Profile0RX1IQcrosscorr",
			"out Profile0RX2Idc",
			"out Profile0RX2Qdc",
			"out Profile0RX2Ipwr",
			"out Profile0RX2Qpwr",
			"out Profile0RX2IQcrosscorr",
			"out Profile0RX3Idc",
			"out Profile0RX3Qdc",
			"out Profile0RX3Ipwr",
			"out Profile0RX3Qpwr",
			"out Profile0RX3IQcrosscorr",
			"out Profile1RX0Idc",
			"out Profile1RX0Qdc",
			"out Profile1RX0Ipwr",
			"out Profile1RX0Qpwr",
			"out Profile1RX0IQcrosscorr",
			"out Profile1RX1Idc",
			"out Profile1RX1Qdc",
			"out Profile1RX1Ipwr",
			"out Profile1RX1Qpwr",
			"out Profile1RX1IQcrosscorr",
			"out Profile1RX2Idc",
			"out Profile1RX2Qdc",
			"out Profile1RX2Ipwr",
			"out Profile1RX2Qpwr",
			"out Profile1RX2IQcrosscorr",
			"out Profile1RX3Idc",
			"out Profile1RX3Qdc",
			"out Profile1RX3Ipwr",
			"out Profile1RX3Qpwr",
			"out Profile1RX3IQcrosscorr",
			"out Profile2RX0Idc",
			"out Profile2RX0Qdc",
			"out Profile2RX0Ipwr",
			"out Profile2RX0Qpwr",
			"out Profile2RX0IQcrosscorr",
			"out Profile2RX1Idc",
			"out Profile2RX1Qdc",
			"out Profile2RX1Ipwr",
			"out Profile2RX1Qpwr",
			"out Profile2RX1IQcrosscorr",
			"out Profile2RX2Idc",
			"out Profile2RX2Qdc",
			"out Profile2RX2Ipwr",
			"out Profile2RX2Qpwr",
			"out Profile2RX2IQcrosscorr",
			"out Profile2RX3Idc",
			"out Profile2RX3Qdc",
			"out Profile2RX3Ipwr",
			"out Profile2RX3Qpwr",
			"out Profile2RX3IQcrosscorr",
			"out Profile3RX0Idc",
			"out Profile3RX0Qdc",
			"out Profile3RX0Ipwr",
			"out Profile3RX0Qpwr",
			"out Profile3RX0IQcrosscorr",
			"out Profile3RX1Idc",
			"out Profile3RX1Qdc",
			"out Profile3RX1Ipwr",
			"out Profile3RX1Qpwr",
			"out Profile3RX1IQcrosscorr",
			"out Profile3RX2Idc",
			"out Profile3RX2Qdc",
			"out Profile3RX2Ipwr",
			"out Profile3RX2Qpwr",
			"out Profile3RX2IQcrosscorr",
			"out Profile3RX3Idc",
			"out Profile3RX3Qdc",
			"out Profile3RX3Ipwr",
			"out Profile3RX3Qpwr",
			"out Profile3RX3IQcrosscorr"
		})]
		public int DFEStaticReportGet1(uint RadarDeviceId, out short Profile0RX0Idc, out short Profile0RX0Qdc, out ushort Profile0RX0Ipwr, out ushort Profile0RX0Qpwr, out int Profile0RX0IQcrosscorr, out short Profile0RX1Idc, out short Profile0RX1Qdc, out ushort Profile0RX1Ipwr, out ushort Profile0RX1Qpwr, out int Profile0RX1IQcrosscorr, out short Profile0RX2Idc, out short Profile0RX2Qdc, out ushort Profile0RX2Ipwr, out ushort Profile0RX2Qpwr, out int Profile0RX2IQcrosscorr, out short Profile0RX3Idc, out short Profile0RX3Qdc, out ushort Profile0RX3Ipwr, out ushort Profile0RX3Qpwr, out int Profile0RX3IQcrosscorr, out short Profile1RX0Idc, out short Profile1RX0Qdc, out ushort Profile1RX0Ipwr, out ushort Profile1RX0Qpwr, out int Profile1RX0IQcrosscorr, out short Profile1RX1Idc, out short Profile1RX1Qdc, out ushort Profile1RX1Ipwr, out ushort Profile1RX1Qpwr, out int Profile1RX1IQcrosscorr, out short Profile1RX2Idc, out short Profile1RX2Qdc, out ushort Profile1RX2Ipwr, out ushort Profile1RX2Qpwr, out int Profile1RX2IQcrosscorr, out short Profile1RX3Idc, out short Profile1RX3Qdc, out ushort Profile1RX3Ipwr, out ushort Profile1RX3Qpwr, out int Profile1RX3IQcrosscorr, out short Profile2RX0Idc, out short Profile2RX0Qdc, out ushort Profile2RX0Ipwr, out ushort Profile2RX0Qpwr, out int Profile2RX0IQcrosscorr, out short Profile2RX1Idc, out short Profile2RX1Qdc, out ushort Profile2RX1Ipwr, out ushort Profile2RX1Qpwr, out int Profile2RX1IQcrosscorr, out short Profile2RX2Idc, out short Profile2RX2Qdc, out ushort Profile2RX2Ipwr, out ushort Profile2RX2Qpwr, out int Profile2RX2IQcrosscorr, out short Profile2RX3Idc, out short Profile2RX3Qdc, out ushort Profile2RX3Ipwr, out ushort Profile2RX3Qpwr, out int Profile2RX3IQcrosscorr, out short Profile3RX0Idc, out short Profile3RX0Qdc, out ushort Profile3RX0Ipwr, out ushort Profile3RX0Qpwr, out int Profile3RX0IQcrosscorr, out short Profile3RX1Idc, out short Profile3RX1Qdc, out ushort Profile3RX1Ipwr, out ushort Profile3RX1Qpwr, out int Profile3RX1IQcrosscorr, out short Profile3RX2Idc, out short Profile3RX2Qdc, out ushort Profile3RX2Ipwr, out ushort Profile3RX2Qpwr, out int Profile3RX2IQcrosscorr, out short Profile3RX3Idc, out short Profile3RX3Qdc, out ushort Profile3RX3Ipwr, out ushort Profile3RX3Qpwr, out int Profile3RX3IQcrosscorr)
		{
			Profile0RX0Idc = 0;
			Profile0RX0Qdc = 0;
			Profile0RX0Ipwr = 0;
			Profile0RX0Qpwr = 0;
			Profile0RX0IQcrosscorr = 0;
			Profile0RX1Idc = 0;
			Profile0RX1Qdc = 0;
			Profile0RX1Ipwr = 0;
			Profile0RX1Qpwr = 0;
			Profile0RX1IQcrosscorr = 0;
			Profile0RX2Idc = 0;
			Profile0RX2Qdc = 0;
			Profile0RX2Ipwr = 0;
			Profile0RX2Qpwr = 0;
			Profile0RX2IQcrosscorr = 0;
			Profile0RX3Idc = 0;
			Profile0RX3Qdc = 0;
			Profile0RX3Ipwr = 0;
			Profile0RX3Qpwr = 0;
			Profile0RX3IQcrosscorr = 0;
			Profile1RX0Idc = 0;
			Profile1RX0Qdc = 0;
			Profile1RX0Ipwr = 0;
			Profile1RX0Qpwr = 0;
			Profile1RX0IQcrosscorr = 0;
			Profile1RX1Idc = 0;
			Profile1RX1Qdc = 0;
			Profile1RX1Ipwr = 0;
			Profile1RX1Qpwr = 0;
			Profile1RX1IQcrosscorr = 0;
			Profile1RX2Idc = 0;
			Profile1RX2Qdc = 0;
			Profile1RX2Ipwr = 0;
			Profile1RX2Qpwr = 0;
			Profile1RX2IQcrosscorr = 0;
			Profile1RX3Idc = 0;
			Profile1RX3Qdc = 0;
			Profile1RX3Ipwr = 0;
			Profile1RX3Qpwr = 0;
			Profile1RX3IQcrosscorr = 0;
			Profile2RX0Idc = 0;
			Profile2RX0Qdc = 0;
			Profile2RX0Ipwr = 0;
			Profile2RX0Qpwr = 0;
			Profile2RX0IQcrosscorr = 0;
			Profile2RX1Idc = 0;
			Profile2RX1Qdc = 0;
			Profile2RX1Ipwr = 0;
			Profile2RX1Qpwr = 0;
			Profile2RX1IQcrosscorr = 0;
			Profile2RX2Idc = 0;
			Profile2RX2Qdc = 0;
			Profile2RX2Ipwr = 0;
			Profile2RX2Qpwr = 0;
			Profile2RX2IQcrosscorr = 0;
			Profile2RX3Idc = 0;
			Profile2RX3Qdc = 0;
			Profile2RX3Ipwr = 0;
			Profile2RX3Qpwr = 0;
			Profile2RX3IQcrosscorr = 0;
			Profile3RX0Idc = 0;
			Profile3RX0Qdc = 0;
			Profile3RX0Ipwr = 0;
			Profile3RX0Qpwr = 0;
			Profile3RX0IQcrosscorr = 0;
			Profile3RX1Idc = 0;
			Profile3RX1Qdc = 0;
			Profile3RX1Ipwr = 0;
			Profile3RX1Qpwr = 0;
			Profile3RX1IQcrosscorr = 0;
			Profile3RX2Idc = 0;
			Profile3RX2Qdc = 0;
			Profile3RX2Ipwr = 0;
			Profile3RX2Qpwr = 0;
			Profile3RX2IQcrosscorr = 0;
			Profile3RX3Idc = 0;
			Profile3RX3Qdc = 0;
			Profile3RX3Ipwr = 0;
			Profile3RX3Qpwr = 0;
			Profile3RX3IQcrosscorr = 0;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.iGetDFEStaticReportDataConfigToLauCmd_Impl(RadarDeviceId, out Profile0RX0Idc, out Profile0RX0Qdc, out Profile0RX0Ipwr, out Profile0RX0Qpwr, out Profile0RX0IQcrosscorr, out Profile0RX1Idc, out Profile0RX1Qdc, out Profile0RX1Ipwr, out Profile0RX1Qpwr, out Profile0RX1IQcrosscorr, out Profile0RX2Idc, out Profile0RX2Qdc, out Profile0RX2Ipwr, out Profile0RX2Qpwr, out Profile0RX2IQcrosscorr, out Profile0RX3Idc, out Profile0RX3Qdc, out Profile0RX3Ipwr, out Profile0RX3Qpwr, out Profile0RX3IQcrosscorr, out Profile1RX0Idc, out Profile1RX0Qdc, out Profile1RX0Ipwr, out Profile1RX0Qpwr, out Profile1RX0IQcrosscorr, out Profile1RX1Idc, out Profile1RX1Qdc, out Profile1RX1Ipwr, out Profile1RX1Qpwr, out Profile1RX1IQcrosscorr, out Profile1RX2Idc, out Profile1RX2Qdc, out Profile1RX2Ipwr, out Profile1RX2Qpwr, out Profile1RX2IQcrosscorr, out Profile1RX3Idc, out Profile1RX3Qdc, out Profile1RX3Ipwr, out Profile1RX3Qpwr, out Profile1RX3IQcrosscorr, out Profile2RX0Idc, out Profile2RX0Qdc, out Profile2RX0Ipwr, out Profile2RX0Qpwr, out Profile2RX0IQcrosscorr, out Profile2RX1Idc, out Profile2RX1Qdc, out Profile2RX1Ipwr, out Profile2RX1Qpwr, out Profile2RX1IQcrosscorr, out Profile2RX2Idc, out Profile2RX2Qdc, out Profile2RX2Ipwr, out Profile2RX2Qpwr, out Profile2RX2IQcrosscorr, out Profile2RX3Idc, out Profile2RX3Qdc, out Profile2RX3Ipwr, out Profile2RX3Qpwr, out Profile2RX3IQcrosscorr, out Profile3RX0Idc, out Profile3RX0Qdc, out Profile3RX0Ipwr, out Profile3RX0Qpwr, out Profile3RX0IQcrosscorr, out Profile3RX1Idc, out Profile3RX1Qdc, out Profile3RX1Ipwr, out Profile3RX1Qpwr, out Profile3RX1IQcrosscorr, out Profile3RX2Idc, out Profile3RX2Qdc, out Profile3RX2Ipwr, out Profile3RX2Qpwr, out Profile3RX2IQcrosscorr, out Profile3RX3Idc, out Profile3RX3Qdc, out Profile3RX3Ipwr, out Profile3RX3Qpwr, out Profile3RX3IQcrosscorr);
		}

		[AttrLuaFunc("SelectPMICDevice", "Chooses the PMIC devices", new string[]
		{
			"PMIC1 - 1, PMIC2 - 2"
		})]
		public int SelectPMICDevice(int p0)
		{
			return m_GuiManager.ScriptOps.SelectPMICDevice_cmd(1U, p0);
		}

		[AttrLuaFunc("SetPMICBuck0_mult", "Set the PMIC Buck0 voltage", new string[]
		{
			"RadarDeviceId",
			"iBuck0Voltage in Volts"
		})]
		public int SetPMICBuck0(uint RadarDeviceId, double iBuck0Voltage)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m00009a(iBuck0Voltage);
		}

		[AttrLuaFunc("SetPMICBuck0", "Set the PMIC Buck0 voltage", new string[]
		{
			"iBuck0Voltage in Volts"
		})]
		public int SetPMICBuck0(double iBuck0Voltage)
		{
			return m_GuiManager.ScriptOps.m00009a(iBuck0Voltage);
		}

		[AttrLuaFunc("SetPMICBuck1_mult", "Set the PMIC Buck1 voltage", new string[]
		{
			"RadarDeviceId",
			"iBuck1Voltage in Volts"
		})]
		public int SetPMICBuck1(uint RadarDeviceId, double iBuck1Voltage)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m00009b(iBuck1Voltage);
		}

		[AttrLuaFunc("SetPMICBuck1", "Set the PMIC Buck1 voltage", new string[]
		{
			"iBuck1Voltage in Volts"
		})]
		public int SetPMICBuck1(double iBuck1Voltage)
		{
			return m_GuiManager.ScriptOps.m00009b(iBuck1Voltage);
		}

		[AttrLuaFunc("SetPMICBuck2_mult", "Set the PMIC Buck2 voltage", new string[]
		{
			"RadarDeviceId",
			"iBuck2Voltage in Volts"
		})]
		public int SetPMICBuck2(uint RadarDeviceId, double iBuck2Voltage)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m00009c(iBuck2Voltage);
		}

		[AttrLuaFunc("SetPMICBuck2", "Set the PMIC Buck2 voltage", new string[]
		{
			"iBuck2Voltage in Volts"
		})]
		public int SetPMICBuck2(double iBuck2Voltage)
		{
			return m_GuiManager.ScriptOps.m00009c(iBuck2Voltage);
		}

		[AttrLuaFunc("SetPMICBuck3_mult", "Set the PMIC Buck3 voltage", new string[]
		{
			"RadarDeviceId",
			"iBuck3Voltage in Volts"
		})]
		public int SetPMICBuck3(uint RadarDeviceId, double iBuck3Voltage)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m00009d(iBuck3Voltage);
		}

		[AttrLuaFunc("SetPMICBuck3", "Set the PMIC Buck3 voltage", new string[]
		{
			"iBuck3Voltage in Volts"
		})]
		public int SetPMICBuck3(float iBuck3Voltage)
		{
			return m_GuiManager.ScriptOps.m00009d((double)iBuck3Voltage);
		}

		[AttrLuaFunc("GetPMICBuck0_mult", "Get the PMIC Buck0 voltage", new string[]
		{
			"RadarDeviceId",
			"out oVoltage in Volts"
		})]
		public int GetPMICBuck0(uint RadarDeviceId, out string oVoltage)
		{
			oVoltage = string.Empty;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m00009e(out oVoltage);
		}

		[AttrLuaFunc("GetPMICBuck0", "Get the PMIC Buck0 voltage", new string[]
		{
			"out oVoltage in Volts"
		})]
		public int GetPMICBuck0(out string oVoltage)
		{
			oVoltage = string.Empty;
			return m_GuiManager.ScriptOps.m00009e(out oVoltage);
		}

		[AttrLuaFunc("GetPMICBuck1_mult", "Get the PMIC Buck1 voltage", new string[]
		{
			"RadarDeviceId",
			"out oVoltage in Volts"
		})]
		public int GetPMICBuck1(uint RadarDeviceId, out string oVoltage)
		{
			oVoltage = string.Empty;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m00009f(out oVoltage);
		}

		[AttrLuaFunc("GetPMICBuck1", "Get the PMIC Buck1 voltage", new string[]
		{
			"out oVoltage in Volts"
		})]
		public int GetPMICBuck1(out string oVoltage)
		{
			oVoltage = string.Empty;
			return m_GuiManager.ScriptOps.m00009f(out oVoltage);
		}

		[AttrLuaFunc("GetPMICBuck2_mult", "Get the PMIC Buck2 voltage", new string[]
		{
			"RadarDeviceId",
			"out oVoltage in Volts"
		})]
		public int GetPMICBuck2(uint RadarDeviceId, out string oVoltage)
		{
			oVoltage = string.Empty;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m0000a0(out oVoltage);
		}

		[AttrLuaFunc("GetPMICBuck2", "Get the PMIC Buck2 voltage", new string[]
		{
			"out oVoltage in Volts"
		})]
		public int GetPMICBuck2(out string oVoltage)
		{
			oVoltage = string.Empty;
			return m_GuiManager.ScriptOps.m0000a0(out oVoltage);
		}

		[AttrLuaFunc("GetPMICBuck3_mult", "Get the PMIC Buck3 voltage", new string[]
		{
			"RadarDeviceId",
			"out oVoltage in Volts"
		})]
		public int GetPMICBuck3(uint RadarDeviceId, out string oVoltage)
		{
			oVoltage = string.Empty;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.m0000a1(out oVoltage);
		}

		[AttrLuaFunc("GetPMICBuck3", "Get the PMIC Buck3 voltage", new string[]
		{
			"out oVoltage in Volts"
		})]
		public int GetPMICBuck3(out string oVoltage)
		{
			oVoltage = string.Empty;
			return m_GuiManager.ScriptOps.m0000a1(out oVoltage);
		}

		[AttrLuaFunc("SetPMICRegConfig", "SetPMICRegConfig API is used for configure the PMIC register ", new string[]
		{
			"SlaveAddress in hex",
			"RegAddress in hex",
			"RegMsbData in hex",
			"RegLsbData in hex",
			"DataSize"
		})]
		public int SetPMICRegConfig(byte SlaveAddress, byte RegAddress, byte RegMsbData, byte RegLsbData, uint DataSize)
		{
			return m_GuiManager.ScriptOps.UpdateNPMICRegisterConfigData(1U, SlaveAddress, RegAddress, RegMsbData, RegLsbData, DataSize);
		}

		[AttrLuaFunc("SetPMICRegConfig_mult", "SetPMICRegConfig API is used for configure the PMIC register ", new string[]
		{
			"RadarDeviceId",
			"SlaveAddress in hex",
			"RegAddress in hex",
			"RegMsbData in hex",
			"RegLsbData in hex",
			"DataSize"
		})]
		public int SetPMICRegConfig(uint RadarDeviceId, byte SlaveAddress, byte RegAddress, byte RegMsbData, byte RegLsbData, uint DataSize)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNPMICRegisterConfigData(RadarDeviceId, SlaveAddress, RegAddress, RegMsbData, RegLsbData, DataSize);
		}

		[AttrLuaFunc("GetPMICRegConfig", "GetPMICRegConfig API is used for configure the PMIC register ", new string[]
		{
			"SlaveAddress in hex",
			"RegAddress in hex",
			"DataSize",
			"out RegMsbData in Hex format",
			"out RegLsbData in Hex format"
		})]
		public int GetPMICRegConfig(byte SlaveAddress, byte RegAddress, uint DataSize, out string RegMsbData, out string RegLsbData)
		{
			RegMsbData = string.Empty;
			RegLsbData = string.Empty;
			return m_GuiManager.ScriptOps.UpdateNPMICRegisterReadConfigData(1U, SlaveAddress, RegAddress, DataSize, out RegMsbData, out RegLsbData);
		}

		[AttrLuaFunc("GetPMICRegConfig_mult", "GetPMICRegConfig API is used for configure the PMIC register ", new string[]
		{
			"RadarDeviceId",
			"SlaveAddress in hex",
			"RegAddress in hex",
			"DataSize",
			"out RegMsbData in Hex format",
			"out RegLsbData in Hex format"
		})]
		public int GetPMICRegConfig(uint RadarDeviceId, byte SlaveAddress, byte RegAddress, uint DataSize, out string RegMsbData, out string RegLsbData)
		{
			RegMsbData = string.Empty;
			RegLsbData = string.Empty;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNPMICRegisterReadConfigData(RadarDeviceId, SlaveAddress, RegAddress, DataSize, out RegMsbData, out RegLsbData);
		}

		[AttrLuaFunc("gpioGetValue", "gpioGetValue API is used to get the GPIO value for the given configuration", new string[]
		{
			"RadarDeviceId",
			"gpio Pad",
			"gpio Pin",
			"out gpio Value"
		})]
		public int gpioGetValue(uint RadarDeviceId, uint gpioBase, uint gpioPin, out uint gpioVal)
		{
			gpioVal = 0U;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateGPIOReadConfigData(RadarDeviceId, gpioBase, gpioPin, out gpioVal);
		}

		[AttrLuaFunc("gpioSetValue", "gpioSetValue API is used to set the GPIO value for the given configuration", new string[]
		{
			"RadarDeviceId",
			"gpio Pad",
			"gpio Pin",
			"gpio Value"
		})]
		public int gpioSetValue(uint RadarDeviceId, uint gpioBase, uint gpioPin, uint gpioVal)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateGPIOWriteConfigData(RadarDeviceId, gpioBase, gpioPin, gpioVal);
		}

		[AttrLuaFunc("StartTsw1400Arm", "StartTsw1400Arm", new string[]
		{
			"filename for ADC Dump"
		})]
		public int StartTsw1400Arm(string filename)
		{
			return m_GuiManager.ScriptOps.StartTsw1400Arm(filename);
		}

		[AttrLuaFunc("StartMatlabPostProc", "StartMatlabPostProc", new string[]
		{
			"filename for ADC Dump"
		})]
		public int StartMatlabPostProc(string filename)
		{
			return m_GuiManager.ScriptOps.StartPostProc(filename);
		}

		[AttrLuaFunc("GetNumOfRawFiles", "GetNumOfRawFiles", new string[]
		{
			"ADC output file path"
		})]
		public int GetNumOfRawFiles(string adc_file_path)
		{
			return m_MainAR1frm.ChirpConfigTab.GetNumOfRawFiles(adc_file_path);
		}

		[AttrLuaFunc("ReturnStrongestDetectedObject", "ReturnStrongestDetectedObject", new string[]
		{
			"filename for ADC data",
			"out ObjectRangeAndSpeed"
		})]
		public int ReturnStrongestDetectedObject(string filename, out MWArray ObjectRangeAndSpeed)
		{
			ObjectRangeAndSpeed = null;
			return m_GuiManager.ScriptOps.returnStrongestDetectedObject(filename, out ObjectRangeAndSpeed);
		}

		[AttrLuaFunc("ReturnListOfDetectedObjects", "ReturnListOfDetectedObjects", new string[]
		{
			"filename for ADC data",
			"out ObjectsRangeAndSpeed"
		})]
		public int ReturnListOfDetectedObjects(string filename, out MWArray ObjectsRangeAndSpeed)
		{
			ObjectsRangeAndSpeed = null;
			return m_GuiManager.ScriptOps.returnListOfDetectedObjects(filename, out ObjectsRangeAndSpeed);
		}

		[AttrLuaFunc("SetupTSW1400", "SetupTSW1400")]
		public int SetupTSW1400()
		{
			return m_GuiManager.ScriptOps.StartHSDCPro();
		}

		[AttrLuaFunc("StartRlTimePostProc", "StartRlTimePostProc", new string[]
		{
			"filename for ADC Dump"
		})]
		public int StartRlTimePostProc(string filename)
		{
			if (m_GuiManager.MainTsForm.ChirpConfigTab.iGetRealTimeBtnText() == "Real Time")
			{
				m_GuiManager.MainTsForm.ChirpConfigTab.iSetRealTimeBtnText("Stop");
				GlobalRef.g_RealTimeTrigVar = true;
				return m_GuiManager.ScriptOps.StartRlTimePostProc(filename);
			}
			m_GuiManager.Log("Real Time already started");
			return -1;
		}

		[AttrLuaFunc("StopRlTimePostProc", "StopRlTimePostProc", new string[]
		{
			"filename for ADC Dump"
		})]
		public int StopRlTimePostProc(string filename)
		{
			if (m_GuiManager.MainTsForm.ChirpConfigTab.iGetRealTimeBtnText() == "Stop")
			{
				m_GuiManager.MainTsForm.ChirpConfigTab.iSetRealTimeBtnText("Real Time");
				GlobalRef.g_RealTimeTrigVar = false;
				return m_GuiManager.ScriptOps.StartRlTimePostProc(filename);
			}
			m_GuiManager.Log("Real Time laready stopped");
			return -1;
		}

		[AttrLuaFunc("setUpContMode", "SetUpContMode", new string[]
		{
			"filename for cont ADC Dump",
			" No of Samples"
		})]
		public int setUpContMode(string filename, int NoOfSamples)
		{
			return m_GuiManager.ScriptOps.iStartMtlbFrContProcessing(filename, NoOfSamples);
		}

		[AttrLuaFunc("GetPostProcVersion", "Get Matlab PostProcVersion")]
		public string GetPostProcVersion()
		{
			return GetExactMatlabPostProcVersion(m_GuiManager.ScriptOps.getMatlabPostProcVersion());
		}

		public string GetExactMatlabPostProcVersion(string FWVersion)
		{
			string empty = string.Empty;
			string[] array = FWVersion.Split(new char[]
			{
				'('
			})[0].Split(new char[]
			{
				'.'
			});
			return Convert.ToString(Convert.ToInt32(array[0])) + "." + Convert.ToString(Convert.ToInt32(array[1]));
		}

		[AttrLuaFunc("SavePostProcPicture", "Save  PostProcPicture", new string[]
		{
			"ADC File name"
		})]
		public int SavePostProcPicture(string ADCFilename)
		{
			return m_GuiManager.ScriptOps.SavePostProcPicture(ADCFilename);
		}

		[AttrLuaFunc("SelectChipVersion", "Select the specific chip version for matlab configuration such as Profile, chirp and Frame etc", new string[]
		{
			"Chip Name such as XWR1243, XWR1443, XWR1642, AR1243, AR1443, AR1642, XWR1843 and IWR6843"
		})]
		public int GetSelectChipVersion(string chipName)
		{
			return m_GuiManager.ScriptOps.SelectChipVersion(chipName);
		}

		[AttrLuaFunc("frequencyBandSelection", "frequencyBandSelection defined as the select a device operating band frequency in GHz", new string[]
		{
			"Device operataing band frequency in GHz, 60G : 60GHz device, 77G : 77GHz device"
		})]
		public int FrequencyBandSelection(string deviceBandFreq)
		{
			if (deviceBandFreq == "60G")
			{
				GlobalRef.g_ARDeviceOperateFreq60GHz = true;
				m_GuiManager.MainTsForm.ConnectTab.ConfigureDeviceOperateFreqinGHz_Gui();
				return m_GuiManager.ScriptOps.iConfigProfileStartFreMinAndMax_Gui();
			}
			GlobalRef.g_ARDeviceOperateFreq60GHz = false;
			m_MainAR1frm.ConnectTab.ConfigureDeviceOperateFreqinGHz_Gui();
			return m_GuiManager.ScriptOps.iConfigProfileStartFreMinAndMax_Gui();
		}

		[AttrLuaFunc("MeasureDC", "Returns the DC in Volts for the specified Rxchain with complex, real or imaginary channel", new string[]
		{
			"ADC filename",
			"Rx-chain which is enabled",
			"0-complex samples, 1-in-phase samples, 2-quadrature-phase channel samples",
			"out DC VoltageI ",
			"out DCVoltageQ"
		})]
		public int MesureTheDCVoltage(string ADCfilename, uint Rxchain, uint I_or_Q, out double DCVoltageI, out double DCVoltageQ)
		{
			DCVoltageI = 0.0;
			DCVoltageQ = 0.0;
			return m_GuiManager.ScriptOps.MeasureOfDCVoltage(ADCfilename, Rxchain, I_or_Q, out DCVoltageI, out DCVoltageQ);
		}

		[AttrLuaFunc("ParseToStandardFormat", "ParseToStandardFormat API Converts a given file  from NonInterleaved to Interleaved. the number of samples per chirp is given by profileconfig API", new string[]
		{
			"Input ADC filename (say 'adc_data.bin')containing data",
			"Output filename.(say 'adc_data.csv')",
			"Type of output such as 0-Adc data, 1-FFT output(1 chirp, cmplx adc input), 2-FFT output(1 chirp, real adc input), 3-FFT output(1 chirp, imag adc input), 4-Non-coh-sum of FFT output in dDBFs(cmplx adc input), 5-Non-coh-sum of FFT output in dDBFs(real adc input), 6-Non-coh-sum of FFT output in dDBFs(imag adc input)"
		})]
		public int ConvertFromNonInterleavedToInterleaved(string input_file_name, string output_file_name, uint TypeofOutput)
		{
			return m_GuiManager.ScriptOps.ConvertFromNonnterleavedTointerleave(input_file_name, output_file_name, TypeofOutput);
		}

		[AttrLuaFunc("CreateHistogram", "CreateHistogram API populates the outputfilename with the histogram of the'fft output' for the file specified by ADC filename", new string[]
		{
			"CSV file containing the histogram and the histogram edges as well",
			"ADC file containing data (bin file)",
			"Min-limit of the histogram",
			"Max-limit of the histogram",
			"Number of uniform bins of the histogram",
			"type of data , 0-ADC data , 1- FFT non coherent sum(in dBfs)",
			"Index of the Rx Chain",
			"I_or_Q , 0-Complex samples , 1- In-Phase samples, 2- Quadrature-phase channel samples"
		})]
		public int CreateHistogram(string output_file_name, string input_file_name, uint MinLimit, uint MaxLimit, uint NumBins, uint TypeOfData, uint RxChain, uint I_OR_Q)
		{
			return m_GuiManager.ScriptOps.CreateHistogramFFTOutput(output_file_name, input_file_name, MinLimit, MaxLimit, NumBins, TypeOfData, RxChain, I_OR_Q);
		}

		[AttrLuaFunc("MeasureFundPower", " Returns the power in dBFS, the frequency in Hz, and the phase in radians of the largest peak located in the fourier specturm", new string[]
		{
			"ADC filename",
			"Integration bandwidth in Hz",
			"Rx-chain which is enabled",
			" 0-complex samples, 1-in-phase samples, 2-quadrature-phase channel samples",
			"out Power_dBFs ",
			"out freq_Hz ",
			"out phase_rad "
		})]
		public int MeasureTheFundPower(string ADCfilename, double p1, uint Rxchain, uint I_or_Q, out double Power_dBFs, out double freq_Hz, out double phase_rad)
		{
			Power_dBFs = 0.0;
			freq_Hz = 0.0;
			phase_rad = 0.0;
			return m_GuiManager.ScriptOps.MeasureTheFundPower(ADCfilename, p1, Rxchain, I_or_Q, out Power_dBFs, out freq_Hz, out phase_rad);
		}

		[AttrLuaFunc("MeasureSecondHarmonicCharacsteristics", "Returns the power(in dBFS), the frequency(in Hz), and the phase(in radians) of the second harmonic peak located in the fourier specturm. the third harmonic is sought at fund_freq_hz x2. Once the harmonic is found , its energy is computed by integrating_bw_hz around the peak", new string[]
		{
			"ADC file",
			"fundamental frequency in Hz",
			"Integration bandwidth in Hz",
			"Rx-chain which is enabled",
			" 0-complex samples, 1-in-phase samples, 2-quadrature-phase channel samples",
			"out Power_dBFs ",
			"out freq_Hz ",
			"out phase_rad "
		})]
		public int MeasureTheSecondHarmonicCharacsteristics(string ADCfilename, double fund_freq_hz, double p2, uint Rxchain, uint I_or_Q, out double Power_dBFs, out double freq_Hz, out double phase_rad)
		{
			Power_dBFs = 0.0;
			freq_Hz = 0.0;
			phase_rad = 0.0;
			return m_GuiManager.ScriptOps.MeasureTheSecondHarmonicCharacsteristics(ADCfilename, fund_freq_hz, p2, Rxchain, I_or_Q, out Power_dBFs, out freq_Hz, out phase_rad);
		}

		[AttrLuaFunc("MeasureThirdHarmonicCharacsteristics", "Returns the power(in dBFS), the frequency(in Hz), and the phase(in radians) of the third harmonic peak located in the fourier specturm. the third harmonic is sought at fund_freq_hz x3. Once the harmonic is found , its energy is computed by integrating_bw_hz around the peak", new string[]
		{
			"ADC filename",
			"fundamental frequency in Hz",
			"Integration bandwidth in Hz",
			"Rx-chain which is enabled",
			" 0-complex samples, 1-in-phase samples, 2-quadrature-phase channel samples",
			"out Power_dBFs ",
			"out freq_Hz ",
			"out phase_rad "
		})]
		public int MeasureTheThirdHarmonicCharacsteristics(string ADCfilename, double fund_freq_hz, double p2, uint Rxchain, uint I_or_Q, out double Power_dBFs, out double freq_Hz, out double phase_rad)
		{
			Power_dBFs = 0.0;
			freq_Hz = 0.0;
			phase_rad = 0.0;
			return m_GuiManager.ScriptOps.MeasureTheThirdHarmonicCharacsteristics(ADCfilename, fund_freq_hz, p2, Rxchain, I_or_Q, out Power_dBFs, out freq_Hz, out phase_rad);
		}

		[AttrLuaFunc("MeasurePowerSpectralDensity", "The returns the power spectral density(in dBFS/Hz) from Freq_Start_in_hz to (freq_Start_in_hz + Bandwidth_in_hz).", new string[]
		{
			"ADC filename",
			"start frequency in Hz",
			"stop frequency in Hz",
			"Rx-chain which is enabled",
			" 0-complex samples, 1-in-phase samples, 2-quadrature-phase channel samples",
			"out Power_dBFs_per_Hz "
		})]
		public int MeasureThePowerSpectralDensity(string ADCfilename, double freq_Start_in_hz, double Bandwidth_in_hz, uint Rxchain, uint I_or_Q, out double Power_dBFs_per_Hz)
		{
			Power_dBFs_per_Hz = 0.0;
			return m_GuiManager.ScriptOps.MeasureThePowerSpectralDensity(ADCfilename, freq_Start_in_hz, Bandwidth_in_hz, Rxchain, I_or_Q, out Power_dBFs_per_Hz);
		}

		[AttrLuaFunc("MeasurePeakInBandwidth", "The returns the power in dBFS/Hz), the Frequency(in Hz) and the phase (in Radians of the largest peak located between two frequency- freq_start_in_hz and (freq_Start_in_hz + Bandwidth in hz)", new string[]
		{
			"ADC filename",
			"start frequency in Hz",
			"the bandwidth around the peak to integrate",
			"stop frequency in Hz",
			"Rx-chain which is enabled",
			" 0-complex samples, 1-in-phase samples, 2-quadrature-phase channel samples",
			"out Power_dBFs ",
			"out freq_Hz ",
			"out phase_rad "
		})]
		public int MeasureThePeakInBandwidth(string ADCfilename, double freq_Start_in_hz, double p2, double Bandwidth_in_hz, uint Rxchain, uint I_or_Q, out double Power_dBFs, out double freq_Hz, out double phase_rad)
		{
			Power_dBFs = 0.0;
			freq_Hz = 0.0;
			phase_rad = 0.0;
			return m_GuiManager.ScriptOps.MeasureThePeakInBandwidth(ADCfilename, freq_Start_in_hz, Bandwidth_in_hz, p2, Rxchain, I_or_Q, out Power_dBFs, out freq_Hz, out phase_rad);
		}

		[AttrLuaFunc("BasicConfigurationForAnalysisTool", "This functions allows the configuration of a set of parameters for the analysis tool and should be called only after the device has been placed in 'continous streaming'mode. This function also programs the HSDCPro to collect the necessary number of samples based on the NumberOfSamplesPerFFT and NumNonCohAverages", new string[]
		{
			"Number Of Samples Per FFT",
			"If the FFT Size is larger than Number of SamplesPerFFT we do an oversampled FFT",
			"Number of Non-Coherent Averages tobe performed per FFT",
			"Index of the 'window type' to be selected for windowing per FFT. The options are 0: No-window, 1: Hann(using the hanning function) 2: Blackmann-Harris, 4: Flat-Top",
			" Set the 1 remove the DC  from this measuremnet prior to FFT. set to 0 otherwise  ",
			"Should be HSPDCPro do triggered capture?(set to 1 otherwise set to 0) "
		})]
		public int BasicConfigurationForAnalysisTool(uint NumberOfSamplesPerFFT, uint FFTSize, uint NumNonCohAverages, uint WindowSelect, uint RemoveDc, uint EnableTriggeredCapture)
		{
			return m_GuiManager.ScriptOps.BasicConfigurationForAnalysisTool(NumberOfSamplesPerFFT, FFTSize, NumNonCohAverages, WindowSelect, RemoveDc, EnableTriggeredCapture);
		}

		[AttrLuaFunc("MeasureTheTxPowerConfig", "MeasureTheTxPower API used to measure the TX output power using the onchip peak detectors", new string[]
		{
			"Number Of accumulations",
			"Number Of Samples to be used for each GPADC measurement",
			"out Tx0utputPower",
			"out Tx0ReflectedPower",
			"out Tx0IncidentVoltage",
			"out Tx0ReflectedVoltage",
			"out Tx1TxOutputPower",
			"out Tx1ReflectedPower",
			"out Tx1IncidentVoltage",
			"out Tx1ReflectedVoltage",
			"out Tx2TxOutputPower",
			"out Tx2ReflectedPower",
			"out Tx2IncidentVoltage",
			"out Tx2ReflectedVoltage"
		})]
		public int MeasureTheTxPower(char NumberOfAccumulations, char NumberOfSamples, out string Tx0OutputPower, out string Tx0ReflectedPower, out string Tx0IncidentVoltage, out string Tx0ReflectedVoltage, out string Tx1TxOutputPower, out string Tx1ReflectedPower, out string Tx1IncidentVoltage, out string Tx1ReflectedVoltage, out string Tx2TxOutputPower, out string Tx2ReflectedPower, out string Tx2IncidentVoltage, out string Tx2ReflectedVoltage)
		{
			Tx0OutputPower = string.Empty;
			Tx0ReflectedPower = string.Empty;
			Tx0IncidentVoltage = string.Empty;
			Tx0ReflectedVoltage = string.Empty;
			Tx1TxOutputPower = string.Empty;
			Tx1ReflectedPower = string.Empty;
			Tx1IncidentVoltage = string.Empty;
			Tx1ReflectedVoltage = string.Empty;
			Tx2TxOutputPower = string.Empty;
			Tx2ReflectedPower = string.Empty;
			Tx2IncidentVoltage = string.Empty;
			Tx2ReflectedVoltage = string.Empty;
			m_GuiManager.ScriptOps.UpdateNMeasureTehTxPowerConfigData(1, NumberOfAccumulations, NumberOfSamples);
			return m_GuiManager.ScriptOps.UpdateNMeasureTehTxPowerConfigData_cmd(out Tx0OutputPower, out Tx0ReflectedPower, out Tx0IncidentVoltage, out Tx0ReflectedVoltage, out Tx1TxOutputPower, out Tx1ReflectedPower, out Tx1IncidentVoltage, out Tx1ReflectedVoltage, out Tx2TxOutputPower, out Tx2ReflectedPower, out Tx2IncidentVoltage, out Tx2ReflectedVoltage);
		}

		[AttrLuaFunc("MeasureTheTxPowerConfig_mult", "MeasureTheTxPower API used to measure the TX output power using the onchip peak detectors", new string[]
		{
			"Radar Device Id",
			"Number Of accumulations",
			"Number Of Samples to be used for each GPADC measurement",
			"out Tx0OutputPower",
			"out Tx0ReflectedPower",
			"out Tx0IncidentVoltage",
			"out Tx0ReflectedVoltage",
			"out Tx1TxOutputPower",
			"out Tx1ReflectedPower",
			"out Tx1IncidentVoltage",
			"out Tx1ReflectedVoltage",
			"out Tx2TxOutputPower",
			"out Tx2ReflectedPower",
			"out Tx2IncidentVoltage",
			"out Tx2ReflectedVoltage"
		})]
		public int MeasureTheTxPower(ushort RadarDeviceId, char NumberOfAccumulations, char NumberOfSamples, out string Tx0OutputPower, out string Tx0ReflectedPower, out string Tx0IncidentVoltage, out string Tx0ReflectedVoltage, out string Tx1TxOutputPower, out string Tx1ReflectedPower, out string Tx1IncidentVoltage, out string Tx1ReflectedVoltage, out string Tx2TxOutputPower, out string Tx2ReflectedPower, out string Tx2IncidentVoltage, out string Tx2ReflectedVoltage)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			Tx0OutputPower = string.Empty;
			Tx0ReflectedPower = string.Empty;
			Tx0IncidentVoltage = string.Empty;
			Tx0ReflectedVoltage = string.Empty;
			Tx1TxOutputPower = string.Empty;
			Tx1ReflectedPower = string.Empty;
			Tx1IncidentVoltage = string.Empty;
			Tx1ReflectedVoltage = string.Empty;
			Tx2TxOutputPower = string.Empty;
			Tx2ReflectedPower = string.Empty;
			Tx2IncidentVoltage = string.Empty;
			Tx2ReflectedVoltage = string.Empty;
			m_GuiManager.ScriptOps.UpdateNMeasureTehTxPowerConfigData(RadarDeviceId, NumberOfAccumulations, NumberOfSamples);
			return m_GuiManager.ScriptOps.UpdateNMeasureTehTxPowerConfigData_cmd(out Tx0OutputPower, out Tx0ReflectedPower, out Tx0IncidentVoltage, out Tx0ReflectedVoltage, out Tx1TxOutputPower, out Tx1ReflectedPower, out Tx1IncidentVoltage, out Tx1ReflectedVoltage, out Tx2TxOutputPower, out Tx2ReflectedPower, out Tx2IncidentVoltage, out Tx2ReflectedVoltage);
		}

		[AttrLuaFunc("ConfigureDetection", "Configure Detection", new string[]
		{
			"cfar_method",
			"use_log_cfar",
			"cfar_guard_window_size",
			"cfar_window_size",
			" cfar_threshold_dB",
			"detect_only_local_maxima_in_range",
			"detect_only_local_maxima_in_doppler",
			"do_cfar_in_range",
			"do_cfar_in_doppler"
		})]
		public int ConfigureDetection(double cfar_method, double use_log_cfar, double cfar_guard_window_size, double cfar_window_size, double cfar_threshold_dB, double detect_only_local_maxima_in_range, double detect_only_local_maxima_in_doppler, double do_cfar_in_range, double do_cfar_in_doppler)
		{
			return m_GuiManager.ScriptOps.ConfigureDetection(cfar_method, use_log_cfar, cfar_guard_window_size, cfar_window_size, cfar_threshold_dB, detect_only_local_maxima_in_range, detect_only_local_maxima_in_doppler, do_cfar_in_range, do_cfar_in_doppler);
		}

		[AttrLuaFunc("SelectBurst", "Selection of Burst", new string[]
		{
			"frameslider_val",
			"subframeslider_val",
			"burstslider_val",
			"burstloopslider_val",
			" chirpTypeslider_val",
			"chirpSlider_val"
		})]
		public int SelectBurst(double frameslider_val, double subframeslider_val, double burstslider_val, double burstloopslider_val, double chirpTypeslider_val, double chirpSlider_val)
		{
			return m_GuiManager.ScriptOps.selectBurst(frameslider_val, subframeslider_val, burstslider_val, burstloopslider_val, chirpTypeslider_val, chirpSlider_val);
		}

		[AttrLuaFunc("SaveCQData", "API used to Save CQ Data in a file", new string[]
		{
			"File name",
			"Cq data type, 1:DFE WB energy monitor, 2: Signal and image band monitor, 3:ADC IF saturation indicator"
		})]
		public int SaveCQData(string FileName, uint CQDataType)
		{
			return m_GuiManager.ScriptOps.saveCQDataInFile(FileName, CQDataType);
		}

		[AttrLuaFunc("AdditionalConfigurationForAnalysisTool", "Additional Configuration For Analysis Tool", new string[]
		{
			"SamplesStartindex",
			"NumberOfSamplesPerFFT",
			"ChirpsStartIndex",
			"NumOfChiprsPerFrame",
			" FrameStartIndex",
			"NumFrames"
		})]
		public int AdditionalConfigurationForAnalysisTool(uint SamplesStartindex, uint NumberOfSamplesPerFFT, uint ChirpsStartIndex, uint NumOfChiprsPerFrame, uint FrameStartIndex, uint NumFrames)
		{
			return m_GuiManager.ScriptOps.AdditionalConfigurationForAnalysisTool(SamplesStartindex, NumberOfSamplesPerFFT, ChirpsStartIndex, NumOfChiprsPerFrame, FrameStartIndex, NumFrames);
		}

		[AttrLuaFunc("PostProcPreConfigure_Plots", "change the diffrent plots present in the postproc output, 1: 2D FFT amplitude profile , 2: Range-Angle plot(per frame), 3:Detection and angles estimation results , 4: chirp config profile, 5: 1D FFT amplitude profile, 6: Time domain plot, 7: CQ-metrics - DFE wide-band energy monitor, 8:CQ metrics-ADC /IF saturation indicator, 9: CQ-metrics -DFE energy monitor, 10: chirp number per frame, 11:Profile index and channnel number per frame, 12:phase stability across chirps, 13:Amplitude stability across chirps, 14:Zero-vector-bins vs. High-velocity-bin", new string[]
		{
			"which plot",
			"which channel",
			"top_right_plot",
			"top_right_channel",
			"bottom_left_plot",
			"bottom_left_channel",
			"bottom_right_plot",
			"bottom_right_channel"
		})]
		public int PostProcPreConfigure_Plots(uint top_left_plot, uint top_left_channel, uint top_right_plot, uint top_right_channel, uint bottom_left_plot, uint bottom_left_channel, uint bottom_right_plot, uint bottom_right_channel)
		{
			return m_GuiManager.ScriptOps.MatlabPreConfigure_Plots(top_left_plot, top_left_channel, top_right_plot, top_right_channel, bottom_left_plot, bottom_left_channel, bottom_right_plot, bottom_right_channel);
		}

		[AttrLuaFunc("EnableTestSource_mult", "EnableTestSource", new string[]
		{
			"Radar Device Id",
			"mode"
		})]
		public int EnableTestSource(ushort RadarDeviceId, ushort mode)
		{
			if (GlobalRef.g_TestSource == 0U)
			{
				GlobalRef.g_TestSource = 1U;
				m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
				return m_GuiManager.ScriptOps.TestSrcEnblCmd(RadarDeviceId, mode);
			}
			GlobalRef.LuaWrapper.PrintWarning("Test Source Already Enabled...!!!");
			return -1;
		}

		[AttrLuaFunc("EnableTestSource", "EnableTestSource", new string[]
		{
			"mode"
		})]
		public int EnableTestSource(ushort mode)
		{
			if (GlobalRef.g_TestSource == 0U)
			{
				GlobalRef.g_TestSource = 1U;
				return m_GuiManager.ScriptOps.TestSrcEnblCmd(1, mode);
			}
			GlobalRef.LuaWrapper.PrintWarning("Test Source Already Enabled...!!!");
			return -1;
		}

		[AttrLuaFunc("DisableTestSource_mult", "DisableTestSource", new string[]
		{
			"Radar Device Id",
			"mode"
		})]
		public int DisableTestSource(ushort RadarDeviceId, ushort mode)
		{
			if (GlobalRef.g_TestSource == 1U)
			{
				GlobalRef.g_TestSource = 0U;
				m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
				return m_GuiManager.ScriptOps.TestSrcEnblCmd(RadarDeviceId, mode);
			}
			GlobalRef.LuaWrapper.PrintWarning("Test Source Already Disabled...!!!");
			return -1;
		}

		[AttrLuaFunc("DisableTestSource", "DisableTestSource", new string[]
		{
			"mode"
		})]
		public int DisableTestSource(ushort mode)
		{
			if (GlobalRef.g_TestSource == 1U)
			{
				GlobalRef.g_TestSource = 0U;
				return m_GuiManager.ScriptOps.TestSrcEnblCmd(1, mode);
			}
			GlobalRef.LuaWrapper.PrintWarning("Test Source Already Disabled...!!!");
			return -1;
		}

		[AttrLuaFunc("SetTestSource_mult", "Set Test Source API Defines test source emulates recieved reflections from pair of objects at different positions with different velocities and their signal level strengths", new string[]
		{
			"Radar Device Id",
			"Object1 Position in X-axis in metre",
			"Object1 Position in Y-axis in metre",
			"Object1 Position Z-axis in metre",
			"Object1 Velocity X-axis in m/s",
			"Object1 Velocity in Y-axis in m/s",
			"Object1 Velocity in Z-axis in m/s",
			"Object1 Boundary Min X-axis in metre",
			"Object1 Boundary Min Y-axis in metre",
			"Object1 Boundary Min Z-axis in metre",
			"Object1 Boundary Max X-axis in metre",
			"Object1 Boundary Max Y-axis in metre",
			"Object1 Boundary Max Z-axis in metre",
			"Object1 Signal level strengths in dBFS",
			"Object2 Position X-axis in metre",
			"Object2 Position Y-axis in metre",
			"Object2 Position Z-axis in metre",
			"Object2 Velocity X-axis in m/s",
			"Object2 Velocity Y-axis in m/s",
			"Object2 Velocity in Z-axis in m/s",
			"Object2 Bounadary Min X-axis in metre",
			"Object2 Boundary Min Y-axis in metre",
			"Object2 Boundary Min Z-axis in metre",
			"Object2 Boundary Max X-axis in cm",
			"Object2 Boundary Max Y-axis in cm",
			"Object2 Boundary Max Z axis in cm",
			"Object2 Signal level strengths in dBFS",
			"Object1 Position in Rx1 Antenna in X-axis in lambda ",
			"Object1 position in Rx1 Antenna in Z-axis in lambda",
			"Object1 position in Rx2 Antenna in X-axis in lambda",
			"Object1 position in Rx2 Antenna in Z-axis in lambda",
			"Object1 position in Rx3 Antenna in X-axis in lambda",
			"Object1 position in Rx3 Antenna in Z-axis in lambda",
			"Object1 position in Rx4 Antenna in X-axis in lambda",
			"Object1 position in Rx4 Antenna in Z-axis in lambda",
			"Object1 Position in Tx1 Antenna in X-axis in lambda",
			"Object1 Position in Tx1 Antenna in Z-axis in lambda",
			"Object1 Position in Tx2 Antenna in X-axis in lambda",
			"Object1 Position in Tx2 Antenna in Z-axis in lambda",
			"Object1 Position in Tx3 Antenna in X-axis in lambda",
			"Object1 Position in Tx3 Antenna in Z-axis in lambda"
		})]
		public int RadarLinkImpl_SetTestSource(ushort RadarDeviceId, float obj1PosX, float obj1PosY, float obj1PosZ, float obj1VelX, float obj1VelY, float obj1VelZ, float obj1BMinX, float obj1BMinY, float obj1BMinZ, float obj1BMaxX, float obj1BMaxY, float obj1BMaxZ, float obj1Sig, float obj2PosX, float obj2PosY, float obj2PosZ, float obj2VelX, float obj2VelY, float obj2VelZ, float obj2BMinX, float obj2BMinY, float obj2BMinZ, float obj2BMaxX, float obj2BMaxY, float obj2BMaxZ, float obj2Sig, float obj1AntPosRx1X, float obj1AntPosRx1Z, float obj1AntPosRx2X, float obj1AntPosRx2Z, float obj1AntPosRx3X, float obj1AntPosRx3Z, float obj1AntPosRx4X, float obj1AntPosRx4Z, float obj1AntPosTx1X, float obj1AntPosTx1Z, float obj1AntPosTx2X, float obj1AntPosTx2Z, float obj1AntPosTx3X, float obj1AntPosTx3Z)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetTestSrcData(RadarDeviceId, obj1PosX, obj1PosY, obj1PosZ, obj1VelX, obj1VelY, obj1VelZ, obj1BMinX, obj1BMinY, obj1BMinZ, obj1BMaxX, obj1BMaxY, obj1BMaxZ, obj1Sig, obj2PosX, obj2PosY, obj2PosZ, obj2VelX, obj2VelY, obj2VelZ, obj2BMinX, obj2BMinY, obj2BMinZ, obj2BMaxX, obj2BMaxY, obj2BMaxZ, obj2Sig, obj1AntPosRx1X, obj1AntPosRx1Z, obj1AntPosRx2X, obj1AntPosRx2Z, obj1AntPosRx3X, obj1AntPosRx3Z, obj1AntPosRx4X, obj1AntPosRx4Z, obj1AntPosTx1X, obj1AntPosTx1Z, obj1AntPosTx2X, obj1AntPosTx2Z, obj1AntPosTx3X, obj1AntPosTx3Z);
		}

		[AttrLuaFunc("SetTestSource", "Set Test Source API Defines test source emulates recieved reflections from pair of objects at different positions with different velocities and their signal level strengths", new string[]
		{
			"Object1 Position in X-axis in metre",
			"Object1 Position in Y-axis in metre",
			"Object1 Position Z-axis in metre",
			"Object1 Velocity X-axis in m/s",
			"Object1 Velocity in Y-axis in m/s",
			"Object1 Velocity in Z-axis in m/s",
			"Object1 Boundary Min X-axis in metre",
			"Object1 Boundary Min Y-axis in metre",
			"Object1 Boundary Min Z-axis in metre",
			"Object1 Boundary Max X-axis in metre",
			"Object1 Boundary Max Y-axis in metre",
			"Object1 Boundary Max Z-axis in metre",
			"Object1 Signal level strengths in dBFS",
			"Object2 Position X-axis in metre",
			"Object2 Position Y-axis in metre",
			"Object2 Position Z-axis in metre",
			"Object2 Velocity X-axis in m/s",
			"Object2 Velocity Y-axis in m/s",
			"Object2 Velocity in Z-axis in m/s",
			"Object2 Bounadary Min X-axis in metre",
			"Object2 Boundary Min Y-axis in metre",
			"Object2 Boundary Min Z-axis in metre",
			"Object2 Boundary Max X-axis in cm",
			"Object2 Boundary Max Y-axis in cm",
			"Object2 Boundary Max Z axis in cm",
			"Object2 Signal level strengths in dBFS",
			"Object1 Position in Rx1 Antenna in X-axis in lambda ",
			"Object1 position in Rx1 Antenna in Z-axis in lambda",
			"Object1 position in Rx2 Antenna in X-axis in lambda",
			"Object1 position in Rx2 Antenna in Z-axis in lambda",
			"Object1 position in Rx3 Antenna in X-axis in lambda",
			"Object1 position in Rx3 Antenna in Z-axis in lambda",
			"Object1 position in Rx4 Antenna in X-axis in lambda",
			"Object1 position in Rx4 Antenna in Z-axis in lambda",
			"Object1 Position in Tx1 Antenna in X-axis in lambda",
			"Object1 Position in Tx1 Antenna in Z-axis in lambda",
			"Object1 Position in Tx2 Antenna in X-axis in lambda",
			"Object1 Position in Tx2 Antenna in Z-axis in lambda",
			"Object1 Position in Tx3 Antenna in X-axis in lambda",
			"Object1 Position in Tx3 Antenna in Z-axis in lambda"
		})]
		public int RadarLinkImpl_SetTestSource(float obj1PosX, float obj1PosY, float obj1PosZ, float obj1VelX, float obj1VelY, float obj1VelZ, float obj1BMinX, float obj1BMinY, float obj1BMinZ, float obj1BMaxX, float obj1BMaxY, float obj1BMaxZ, float obj1Sig, float obj2PosX, float obj2PosY, float obj2PosZ, float obj2VelX, float obj2VelY, float obj2VelZ, float obj2BMinX, float obj2BMinY, float obj2BMinZ, float obj2BMaxX, float obj2BMaxY, float obj2BMaxZ, float obj2Sig, float obj1AntPosRx1X, float obj1AntPosRx1Z, float obj1AntPosRx2X, float obj1AntPosRx2Z, float obj1AntPosRx3X, float obj1AntPosRx3Z, float obj1AntPosRx4X, float obj1AntPosRx4Z, float obj1AntPosTx1X, float obj1AntPosTx1Z, float obj1AntPosTx2X, float obj1AntPosTx2Z, float obj1AntPosTx3X, float obj1AntPosTx3Z)
		{
			return m_GuiManager.ScriptOps.UpdateNSetTestSrcData(1, obj1PosX, obj1PosY, obj1PosZ, obj1VelX, obj1VelY, obj1VelZ, obj1BMinX, obj1BMinY, obj1BMinZ, obj1BMaxX, obj1BMaxY, obj1BMaxZ, obj1Sig, obj2PosX, obj2PosY, obj2PosZ, obj2VelX, obj2VelY, obj2VelZ, obj2BMinX, obj2BMinY, obj2BMinZ, obj2BMaxX, obj2BMaxY, obj2BMaxZ, obj2Sig, obj1AntPosRx1X, obj1AntPosRx1Z, obj1AntPosRx2X, obj1AntPosRx2Z, obj1AntPosRx3X, obj1AntPosRx3Z, obj1AntPosRx4X, obj1AntPosRx4Z, obj1AntPosTx1X, obj1AntPosTx1Z, obj1AntPosTx2X, obj1AntPosTx2Z, obj1AntPosTx3X, obj1AntPosTx3Z);
		}

		[AttrLuaFunc("ProfileConfig_mult", "Profile configuration API which defines chirp profile parameters", new string[]
		{
			"Radar Device Id",
			"Chirp Profile Id [0 to 3]",
			"Chirp Start Frequency in GHz",
			"Chirp Idle Time in µs",
			"Chirp ADC Start Time in µs",
			"Chirp Ramp End Time in µs",
			"TX0 channel Power Backoff in dB",
			"TX1 channel Power Backoff in dB",
			"TX2 channel Power Backoff in dB",
			"TX0 channel Phase Shifter Value in deg",
			"TX1 channel Phase Shifter in deg",
			"TX2 channel Phase Shifter in deg",
			"Chirp Frequency Slope in MHz/µs",
			"TX Start Time in µs",
			"RX Number of Adc Samples",
			"RX Sampling Rate in ksps",
			"RX HPF1 corner frequency,[b15:0 (0x00-175 kHz, 0x01-235 kHz, 0x02-350 kHz, 0x03-700 kHz)] + TxChnCalibSet[b31:16]",
			"RX HPF2 corner frequency,[b15:0 (0x00-350 kHz, 0x01-700 kHz, 0x02-1.4 MHz, 0x03-2.8 MHz)] + ForceVCOSelet[b16] and VCOSelect[b17] , RetainTxCalUpdate[b24] , RetainRxCalLut[b25]",
			"RX Gain in dB(b0:5), RF Gain Target(b6:7)values 30dB:00, 34dB:01, Reserve:10, 26dB:11"
		})]
		public int ProfileConfig(ushort RadarDeviceId, ushort profileId, float startFreqConst, float idleTimeConst, float adcStartTimeConst, float rampEndTime, uint tx0OutPowerBackoffCode, uint tx1OutPowerBackoffCode, uint tx2OutPowerBackoffCode, float tx0PhaseShifter, float tx1PhaseShifter, float tx2PhaseShifter, float freqSlopeConst, float txStartTime, ushort numAdcSamples, ushort digOutSampleRate, uint hpfCornerFreq1, uint hpfCornerFreq2, char rxGain)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetProfileConfData(RadarDeviceId, profileId, startFreqConst, idleTimeConst, adcStartTimeConst, rampEndTime, tx0OutPowerBackoffCode, tx1OutPowerBackoffCode, tx2OutPowerBackoffCode, tx0PhaseShifter, tx1PhaseShifter, tx2PhaseShifter, freqSlopeConst, txStartTime, numAdcSamples, digOutSampleRate, hpfCornerFreq1, hpfCornerFreq2, rxGain);
		}

		[AttrLuaFunc("ProfileConfig", "Profile configuration API which defines chirp profile parameters", new string[]
		{
			"Chirp Profile Id [0 to 3]",
			"Chirp Start Frequency in GHz",
			"Chirp Idle Time in µs",
			"Chirp ADC Start Time in µs",
			"Chirp Ramp End Time in µs",
			"TX0 channel Power Backoff in dB",
			"TX1 channel Power Backoff in dB",
			"TX2 channel Power Backoff in dB",
			"TX0 channel Phase Shifter Value in deg",
			"TX1 channel Phase Shifter in deg",
			"TX2 channel Phase Shifter in deg",
			"Chirp Frequency Slope in MHz/µs",
			"TX Start Time in µs",
			"RX Number of Adc Samples",
			"RX Sampling Rate in ksps",
			"RX HPF1 corner frequency,[b15:0 (0x00-175 kHz, 0x01-235 kHz, 0x02-350 kHz, 0x03-700 kHz)] + TxChnCalibSet[b31:16]",
			"RX HPF2 corner frequency,[b15:0 (0x00-350 kHz, 0x01-700 kHz, 0x02-1.4 MHz, 0x03-2.8 MHz)] + ForceVCOSelet[b16] and VCOSelect[b17] , RetainTxCalUpdate[b24] , RetainRxCalLut[b25]",
			"RX Gain in dB(b0:5), RF Gain Target(b6:7)values 30dB:00, 34dB:01, Reserve:10, 26dB:11"
		})]
		public int ProfileConfig(ushort profileId, float startFreqConst, float idleTimeConst, float adcStartTimeConst, float rampEndTime, uint tx0OutPowerBackoffCode, uint tx1OutPowerBackoffCode, uint tx2OutPowerBackoffCode, float tx0PhaseShifter, float tx1PhaseShifter, float tx2PhaseShifter, float freqSlopeConst, float txStartTime, ushort numAdcSamples, ushort digOutSampleRate, uint hpfCornerFreq1, uint hpfCornerFreq2, char rxGain)
		{
			return m_GuiManager.ScriptOps.UpdateNSetProfileConfData(1, profileId, startFreqConst, idleTimeConst, adcStartTimeConst, rampEndTime, tx0OutPowerBackoffCode, tx1OutPowerBackoffCode, tx2OutPowerBackoffCode, tx0PhaseShifter, tx1PhaseShifter, tx2PhaseShifter, freqSlopeConst, txStartTime, numAdcSamples, digOutSampleRate, hpfCornerFreq1, hpfCornerFreq2, rxGain);
		}

		[AttrLuaFunc("AdvancedFrameConfig", "AdvancedFrameConfig", new string[]
		{
			"ForceProfileIdx",
			"ChirpStartIdx",
			"NumOfChirps",
			"NumOfLoops",
			"BurstPeriodicity",
			"ChirpStartIdxOffset",
			"NumOfBrust",
			"NumOfBrustLoops",
			"SubFramePeriodicity",
			"NumOfSubFrames",
			"ForceProfile",
			"NumOfFrames",
			"TriggerSelect",
			"FrameTrigDelay"
		})]
		public int AdvancedFrameConfig(ushort ForceProfileIdx, ushort ChirpStartIdx, ushort NumOfChirps, ushort NumOfLoops, uint BurstPeriodicity, ushort ChirpStartIdxOffset, ushort NumOfBrust, ushort NumOfBrustLoops, uint SubFramePeriodicity, byte NumOfSubFrames, byte ForceProfile, ushort NumOfFrames, ushort TriggerSelect, uint FrameTrigDelay)
		{
			return m_GuiManager.ScriptOps.UpdateNSetAdvancedFrameConfData(ForceProfileIdx, ChirpStartIdx, NumOfChirps, NumOfLoops, BurstPeriodicity, ChirpStartIdxOffset, NumOfBrust, NumOfBrustLoops, SubFramePeriodicity, NumOfSubFrames, ForceProfile, NumOfFrames, TriggerSelect, FrameTrigDelay);
		}

		[AttrLuaFunc("BasicConfigurationForAnalysis", "This functions allows the configuration of a set of parameters for the analysis tool and should be called only after the device has been placed in 'continous streaming'mode. This function also programs the HSDCPro to collect the necessary number of samples based on the NumberOfSamplesPerFFT and NumNonCohAverages", new string[]
		{
			"Number Of Samples Per FFT",
			"FFT Size",
			"Number of Non-Coherent Averages per FFT",
			"0-No window, 1- Hann, 2-Blackmann-Harris, 4-Flat-Top",
			" 1 to remove DC, 0 otherwise  ",
			" 1 to HSPDCPro do triggered capture, 0 otherwise",
			"0-No compensation, 1-Gain compensation, 2-Enegry compensation"
		})]
		public int BasicConfigurationForAnalysis(uint NumberOfSamples, uint FFTSize, uint NUumberOfAverages, ushort WindowSelection, char RemoveDC, char EnableTriggerCapture, char WindowCompensation)
		{
			return m_GuiManager.ScriptOps.UpdateNSetBasicConfigurationForAnalysisConfData(NumberOfSamples, FFTSize, NUumberOfAverages, WindowSelection, RemoveDC, EnableTriggerCapture, WindowCompensation);
		}

		[AttrLuaFunc("MeasureGain", "MeasureGain API defines measure the gain", new string[]
		{
			" ADC Data file path",
			"RxChain",
			"ToneFreq in Hz",
			"RXInputPower in dBm"
		})]
		public int MeasureGain(string ADCFileName, uint RxChain, float ToneFreq, float RXInputPower)
		{
			return m_GuiManager.ScriptOps.UpdateNSetMeasureTheGainConfData(ADCFileName, RxChain, ToneFreq, RXInputPower);
		}

		[AttrLuaFunc("MeasureNF", "MeasureGain API defines measure the Noise figure", new string[]
		{
			" ADC Data file path",
			"RxChain",
			"ToneFreq in Hz"
		})]
		public int MeasureNF(string ADCFileName, uint RxChain, float ToneFreq)
		{
			return m_GuiManager.ScriptOps.UpdateNSetMeasureTheNFConfigData(ADCFileName, RxChain, ToneFreq);
		}

		[AttrLuaFunc("CaptureCardConfig_StartRecord_ContinuousStreamData", "CaptureCardConfig_StartRecord_ContinuousStreamData API defines Capture the ADC Data from continuous streaming from DCA1000 device", new string[]
		{
			"ADCFileName",
			"Packet sequence number enable(1) or disable(0)"
		})]
		public int CaptureCardConfig_StartRecord_ContinuousStreamData(string ADCFileName, byte PktSeqEnaDisable)
		{
			return m_GuiManager.ScriptOps.UpdateNSetRawADCStartCaptureFromContStreamingConfData(ADCFileName, PktSeqEnaDisable);
		}

		[AttrLuaFunc("CaptureCardConfig_StopRecord_ContinuousStreamData", "CaptureCardConfig_StopRecord_ContinuousStreamData API used to stop captue Data from DCA1000 device")]
		public int CaptureCardConfig_StopRecord_ContinuousStreamData()
		{
			return m_GuiManager.ScriptOps.UpdateNSetRawADCStopCaptureFromContStreamingConfDataViaLua();
		}

		[AttrLuaFunc("CaptureContStreamADCData", "CaptureContStreamADCData API defines Capture the ADC Data from continuous streaming", new string[]
		{
			"ADCFileName",
			"ADCNumberOfSamples"
		})]
		public int SetupForTriggeredCaptureinContinuousStreaming(string ADCFileName, uint ADCNumberOfSamples)
		{
			return m_GuiManager.ScriptOps.UpdateNSetADCCaptureFromContStreamingConfData(ADCFileName, ADCNumberOfSamples);
		}

		[AttrLuaFunc("ProcessContStreamADCData", "ProcessContStreamADCData API defines Processing and displaying ADC Data of Continuous streaming", new string[]
		{
			"ADCFileName"
		})]
		public int ProcessADCData(string ADCFileName)
		{
			return m_GuiManager.ScriptOps.UpdateNSetADCDataProcessingAndDisplayFromContStreamingConfData(ADCFileName);
		}

		[AttrLuaFunc("ContStrConfig", "Continuous Streming Configuration API defines Configuration of the data path to transfer the captured ADC samples continuously without missing any sample to external Device(host)", new string[]
		{
			"Start Frequency for each profile of chirp in GHz",
			"ADC sampling rate for each profile in ksps",
			"Rx gain for each profile in dB",
			"HPF1 corner frequency for each profile in KHz",
			"HPF2 corner frequency for each profile in KHz",
			"How much the trasmit power should be reduced from Max in Tx0 Channel",
			"How much the trasmit power should be reduced from Max in Tx1 Channel",
			"How much the trasmit power should be reduced from Max in Tx2 Channel",
			"The additional phase shift to be introduced on Tx0 Channel",
			"The additional phase shift to be introduced on Tx1 Channel",
			"The additional phase shift to be introduced on Tx2 Channel(b0:15) + ForceSelect(b16) + VCOSelecct(b17)) (b16: 31) "
		})]
		public int ContStrModConfig(double startFreqConst, ushort digOutSampleRate, char rxGain, char hpfCornerFreq1, char hpfCornerFreq2, uint tx0OutPowerBackoffCode, uint tx1OutPowerBackoffCode, uint tx2OutPowerBackoffCode, ushort tx0PhaseShifter, ushort tx1PhaseShifter, uint tx2PhaseShifter)
		{
			return m_GuiManager.ScriptOps.UpdateNSetContStrConfData(1, startFreqConst, digOutSampleRate, rxGain, hpfCornerFreq1, hpfCornerFreq2, tx0OutPowerBackoffCode, tx1OutPowerBackoffCode, tx2OutPowerBackoffCode, tx0PhaseShifter, tx1PhaseShifter, tx2PhaseShifter);
		}

		[AttrLuaFunc("ContStrConfig_mult", "Continuous Streming Configuration API defines Configuration of the data path to transfer the captured ADC samples continuously without missing any sample to external Device(host)", new string[]
		{
			"Radar Device Id",
			"Start Frequency for each profile of chirp in GHz",
			"ADC sampling rate for each profile in ksps",
			"Rx gain for each profile in dB",
			"HPF1 corner frequency for each profile in KHz",
			"HPF2 corner frequency for each profile in KHz",
			"How much the trasmit power should be reduced from Max in Tx0 Channel",
			"How much the trasmit power should be reduced from Max in Tx1 Channel",
			"How much the trasmit power should be reduced from Max in Tx2 Channel",
			"The additional phase shift to be introduced on Tx0 Channel",
			"The additional phase shift to be introduced on Tx1 Channel",
			"The additional phase shift to be introduced on Tx2 Channel(b0:15) + ForceSelect(b16) + VCOSelecct(b17))"
		})]
		public int ContStrModConfig(ushort RadarDeviceId, double startFreqConst, ushort digOutSampleRate, char rxGain, char hpfCornerFreq1, char hpfCornerFreq2, uint tx0OutPowerBackoffCode, uint tx1OutPowerBackoffCode, uint tx2OutPowerBackoffCode, ushort tx0PhaseShifter, ushort tx1PhaseShifter, uint tx2PhaseShifter)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetContStrConfData(RadarDeviceId, startFreqConst, digOutSampleRate, rxGain, hpfCornerFreq1, hpfCornerFreq2, tx0OutPowerBackoffCode, tx1OutPowerBackoffCode, tx2OutPowerBackoffCode, tx0PhaseShifter, tx1PhaseShifter, tx2PhaseShifter);
		}

		[AttrLuaFunc("ContStrModEnable_mult", "Continuous Streming Mode Enable API defines Configuration  needed to enable the continuous streaming mode from the device", new string[]
		{
			"Radar Device Id"
		})]
		public int EnableContStrMod(ushort RadarDeviceId)
		{
			if (m_GuiManager.MainTsForm.ContStreamingTab.iGetContStrBtnText() == "Enable (2)")
			{
				m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
				return m_GuiManager.ScriptOps.iEnblContStrConfig_Gui(true, false, RadarDeviceId);
			}
			m_GuiManager.RecordLog(9, "Cont Str Already Enabled");
			return -1;
		}

		[AttrLuaFunc("ContStrModEnable", "Continuous Streming Mode Enable API defines Configuration  needed to enable the continuous streaming mode from the device")]
		public int EnableContStrMod()
		{
			if (m_GuiManager.MainTsForm.ContStreamingTab.iGetContStrBtnText() == "Enable (2)")
			{
				return m_GuiManager.ScriptOps.iEnblContStrConfig_Gui(true, false, 1);
			}
			m_GuiManager.RecordLog(9, "Cont Str Already Enabled");
			return -1;
		}

		[AttrLuaFunc("ContStrModDisable_mult", "Continuous Streming Mode disable API defines Configuration  needed to disable the continuous streaming mode from the device", new string[]
		{
			"Radar Device Id"
		})]
		public int DisableContStrMod(ushort RadarDeviceId)
		{
			if (m_GuiManager.MainTsForm.ContStreamingTab.iGetContStrBtnText() == "Disable (2)")
			{
				m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
				return m_GuiManager.ScriptOps.iEnblContStrConfig_Gui(true, false, RadarDeviceId);
			}
			m_GuiManager.RecordLog(9, "Cont Str Already Disabled");
			return -1;
		}

		[AttrLuaFunc("ContStrModDisable", "Continuous Streming Mode disable API defines Configuration  needed to disable the continuous streaming mode from the device")]
		public int DisableContStrMod()
		{
			if (m_GuiManager.MainTsForm.ContStreamingTab.iGetContStrBtnText() == "Disable (2)")
			{
				return m_GuiManager.ScriptOps.iEnblContStrConfig_Gui(true, false, 1);
			}
			m_GuiManager.RecordLog(9, "Cont Str Already Disabled");
			return -1;
		}

		[AttrLuaFunc("GetRadarLinkVersion", "GetRadarLinkVersion", new string[]
		{
			"RadarLink DLL Version"
		})]
		public int RadarLinkImpl_GetVersion(out string RLDll_Version)
		{
			int radarLinkVersion = m_GuiManager.ScriptOps.getRadarLinkVersion(out RLDll_Version);
			RLDll_Version = GetExactBSSAndMSSFirmwareVersion(RLDll_Version);
			return radarLinkVersion;
		}

		public string GetExactBSSAndMSSFirmwareVersion(string FWVersion)
		{
			string empty = string.Empty;
			string[] array = FWVersion.Split(new char[]
			{
				'('
			});
			string[] array2 = array[0].Split(new char[]
			{
				'.'
			});
			return string.Concat(new string[]
			{
				Convert.ToString(Convert.ToInt32(array2[0])),
				".",
				Convert.ToString(Convert.ToInt32(array2[1])),
				".",
				Convert.ToString(Convert.ToInt32(array2[2])),
				".",
				Convert.ToString(Convert.ToInt32(array2[3]))
			}) + " (" + array[1];
		}

		[AttrLuaFunc("GetNumberOfRadarDevicesDetected", "GetNumberOfRadarDevicesDetected API defines the number of Radar devices detected", new string[]
		{
			"RadarDevicesDetected"
		})]
		public int GetNumberOfRadarDevicesDetected(out uint RadarDevicesDetected)
		{
			return m_GuiManager.ScriptOps.GetRadarDevicesDetected(out RadarDevicesDetected);
		}

		[AttrLuaFunc("CustomCommand_mult", "Custom Command API Defines the used to creation of the customized command.", new string[]
		{
			"Radar Device Id",
			"msgDirection, Invalid:0, Host To BSS: 1, BSS To Host: 2, Host To DSS: 3, DSS To Host:4,  Host To MSS: 5, MSS To Host:6, BSS To MSS:7, MSS To BSS:8, BSS To DSS:9, DSS To BSS:10, MSS To DSS :11, DSS TO MSS:12",
			"msgType, Command: 0, Response:1, NACK:2, ASYNC:3",
			"Message ID",
			"Number of Sub Block",
			"Sub Block unique ID",
			"Length of the Sub Block in bytes",
			"Data corresponding to the Sub Block in bytes"
		})]
		public int RadarLinkImpl_SendCmdMsg(ushort RadarDeviceId, ushort msgDir, ushort msgType, ushort msgID, ushort p4, ushort sbID, ushort sbLen, string sbData)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.CmdLineCustomCommand_Impl(RadarDeviceId, msgDir, msgType, msgID, p4, sbID, sbLen, sbData);
		}

		[AttrLuaFunc("CustomCommand", "Custom Command API Defines the used to creation of the customized command.", new string[]
		{
			"msgDirection, Invalid:0, Host To BSS: 1, BSS To Host: 2, Host To DSS: 3, DSS To Host:4,  Host To MSS: 5, MSS To Host:6, BSS To MSS:7, MSS To BSS:8, BSS To DSS:9, DSS To BSS:10, MSS To DSS :11, DSS TO MSS:12",
			"msgType, Command: 0, Response:1, NACK:2, ASYNC:3",
			"Message ID",
			"Number of Sub Block",
			"Sub Block unique ID",
			"Length of the Sub Block in bytes",
			"Data corresponding to the Sub Block in bytes"
		})]
		public int RadarLinkImpl_SendCmdMsg(ushort msgDir, ushort msgType, ushort msgID, ushort p3, ushort sbID, ushort sbLen, string sbData)
		{
			return m_GuiManager.ScriptOps.CmdLineCustomCommand_Impl(1, msgDir, msgType, msgID, p3, sbID, sbLen, sbData);
		}

		[AttrLuaFunc("DataPathConfig_mult", "DataPathConfig API Defines the used to configure the device data path", new string[]
		{
			"Radar Device Id",
			"Data path interface select(0:7)+ CQ config(b8:15)",
			"Data output format(b0:7)+CQ0TransSize(b8:15)+CQ1TransSize(b16:23)+CQ2TransSize(b24:31)",
			"Supress packet 1 transmission"
		})]
		public int DataPathConfig(ushort RadarDeviceId, uint intfSel, uint p2, uint p3)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetDataPathConfigData(RadarDeviceId, intfSel, p2, p3);
		}

		[AttrLuaFunc("DataPathConfig", "DataPathConfig API Defines the used to configure the device data path", new string[]
		{
			"Data path interface select(0:7)+ CQ config(b8:15)",
			"Data output format(b0:7)+ CQ0TransSize(b8:15)+ CQ1TransSize(b16:23)+ CQ2TransSize(b24:31)",
			"Supress packet 1 transmission"
		})]
		public int DataPathConfig(uint intfSel, uint p1, uint p2)
		{
			return m_GuiManager.ScriptOps.UpdateNSetDataPathConfigData(1, intfSel, p1, p2);
		}

		[AttrLuaFunc("LVDSLaneConfig_mult", "LVDSLaneConfig API Defines the device data format configuration", new string[]
		{
			"Radar Device Id",
			"Radar ADC output bit format configuration",
			"Rx1 Channel enable",
			"Rx2 Channel enable",
			"Rx3 Channel enable",
			"Rx4 Channel enable",
			"Data recieve format type",
			"Packet End Pulse",
			"CRC Enable"
		})]
		public int LaneConfig(ushort RadarDeviceId, ushort p1, ushort lane1En, ushort lane2En, ushort lane3En, ushort lane4En, ushort p6, ushort p7, ushort p8)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetLvdsLaneConfData(RadarDeviceId, p1, lane1En, lane2En, lane3En, lane4En, p6, p7, p8);
		}

		[AttrLuaFunc("LVDSLaneConfig", "LVDSLaneConfig API Defines the device data format configuration", new string[]
		{
			"Radar ADC output bit format configuration",
			"Rx1 Channel enable",
			"Rx2 Channel enable",
			"Rx3 Channel enable",
			"Rx4 Channel enable",
			"Data recieve format type",
			"Packet End Pulse",
			"CRC Enable"
		})]
		public int LaneConfig(ushort p0, ushort lane1En, ushort lane2En, ushort lane3En, ushort lane4En, ushort p5, ushort p6, ushort p7)
		{
			return m_GuiManager.ScriptOps.UpdateNSetLvdsLaneConfData(1, p0, lane1En, lane2En, lane3En, lane4En, p5, p6, p7);
		}

		[AttrLuaFunc("CSI2LaneConfig_mult", "CSI2LaneConfig", new string[]
		{
			"Radar Device Id",
			"CSI2DataLane0Pos",
			"CSI2DataLane0Pol",
			"CSI2DataLane1Pos",
			"CSI2DataLane1Pol",
			"CSI2DataLane2Pos",
			"CSI2DataLane2Pol",
			"CSI2DataLane3Pos",
			"CSI2DataLane3Pol",
			"CSI2ClockPos",
			"CSI2ClockPol"
		})]
		public int CSI2LaneConfig(ushort RadarDeviceId, ushort CSI2DataLane0Pos, ushort CSI2DataLane0Pol, ushort CSI2DataLane1Pos, ushort CSI2DataLane1Pol, ushort CSI2DataLane2Pos, ushort CSI2DataLane2Pol, ushort CSI2DataLane3Pos, ushort CSI2DataLane3Pol, ushort CSI2ClockPos, ushort CSI2ClockPol)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetCSI2LaneConfData(RadarDeviceId, CSI2DataLane0Pos, CSI2DataLane0Pol, CSI2DataLane1Pos, CSI2DataLane1Pol, CSI2DataLane2Pos, CSI2DataLane2Pol, CSI2DataLane3Pos, CSI2DataLane3Pol, CSI2ClockPos, CSI2ClockPol);
		}

		[AttrLuaFunc("CSI2LaneConfig", "CSI2LaneConfig", new string[]
		{
			"CSI2DataLane0Pos",
			"CSI2DataLane0Pol",
			"CSI2DataLane1Pos",
			"CSI2DataLane1Pol",
			"CSI2DataLane2Pos",
			"CSI2DataLane2Pol",
			"CSI2DataLane3Pos",
			"CSI2DataLane3Pol",
			"CSI2ClockPos",
			"CSI2ClockPol"
		})]
		public int CSI2LaneConfig(ushort CSI2DataLane0Pos, ushort CSI2DataLane0Pol, ushort CSI2DataLane1Pos, ushort CSI2DataLane1Pol, ushort CSI2DataLane2Pos, ushort CSI2DataLane2Pol, ushort CSI2DataLane3Pos, ushort CSI2DataLane3Pol, ushort CSI2ClockPos, ushort CSI2ClockPol)
		{
			return m_GuiManager.ScriptOps.UpdateNSetCSI2LaneConfData(1, CSI2DataLane0Pos, CSI2DataLane0Pol, CSI2DataLane1Pos, CSI2DataLane1Pol, CSI2DataLane2Pos, CSI2DataLane2Pol, CSI2DataLane3Pos, CSI2DataLane3Pol, CSI2ClockPos, CSI2ClockPol);
		}

		[AttrLuaFunc("LvdsClkConfig_mult", "LvdsClkConfig API Defines the used to HSI Clock configuration", new string[]
		{
			"Radar Device Id",
			"Lane Clock selection",
			"Data rate selection"
		})]
		public int m0000c5(ushort RadarDeviceId, char laneClk, char dataRate)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.ScriptOps.UpdateNSetLvdsClkConfData(RadarDeviceId, laneClk, dataRate);
		}

		[AttrLuaFunc("LvdsClkConfig", "LvdsClkConfig API Defines the used to HSI Clock configuration", new string[]
		{
			"Lane Clock selection",
			"Data rate selection"
		})]
		public int m0000c6(char laneClk, char dataRate)
		{
			return m_GuiManager.ScriptOps.UpdateNSetLvdsClkConfData(1, laneClk, dataRate);
		}

		[AttrLuaFunc("DeviceReadMemBlockConfig", "DeviceReadMemBlockConfig API Defines the used to read contiguous memory locations", new string[]
		{
			"Start address of block",
			"Length of the block to be read",
			"Reserved"
		})]
		public int DeviceReadMemBlockConfig(uint BlockStartAddress, uint DataLength, uint Reserved)
		{
			return m_GuiManager.ScriptOps.UpdateNSetMSSDataBlockReadConfData(1, BlockStartAddress, DataLength, Reserved);
		}

		[AttrLuaFunc("SetInternalCfg_mult", "Set Internal Cfg of register through SPI", new string[]
		{
			"Radar Device Id",
			"Reg Address",
			"Reg values"
		})]
		public int SetInternalCfg(ushort RadarDeviceId, uint RegAddress, uint Regvalues)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_MainAR1frm.m_RegOpeTab.iWriteRegisterViaSpiChannel(RadarDeviceId, RegAddress, Regvalues);
		}

		[AttrLuaFunc("SetInternalCfg", "Set Internal Cfg of register through SPI", new string[]
		{
			"Reg Address",
			"Reg values"
		})]
		public int SetInternalCfg(uint RegAddress, uint Regvalues)
		{
			return m_MainAR1frm.m_RegOpeTab.iWriteRegisterViaSpiChannel(1, RegAddress, Regvalues);
		}

		[AttrLuaFunc("GetInternalCfg_mult", "Get Internal Cfg of register through SPI", new string[]
		{
			"Radar Device Id",
			"Reg Address",
			"StartBit",
			"StopBit",
			"out Register Value"
		})]
		public int GetInternalCfg(ushort RadarDeviceId, uint address, uint StartBit, uint StopBit, out string RegVal)
		{
			RegVal = string.Empty;
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_MainAR1frm.m_RegOpeTab.iReadRegisterDataViaSpi((uint)RadarDeviceId, address, StartBit, StopBit, out RegVal);
		}

		[AttrLuaFunc("GetInternalCfg", "Get Internal Cfg of register through SPI", new string[]
		{
			"Reg Address",
			"StartBit",
			"StopBit",
			"out Register Value"
		})]
		public int GetInternalCfg(uint address, uint StartBit, uint StopBit, out string RegVal)
		{
			RegVal = string.Empty;
			return m_MainAR1frm.m_RegOpeTab.iReadRegisterDataViaSpi(1U, address, StartBit, StopBit, out RegVal);
		}

		public int Calling_ATE_ConnectTarget(uint com_port, uint baud_rate, uint timeout)
		{
			int result = 0;
			if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
			{
				string full_command = string.Format("ar1.Connect({0},{1},{2})", com_port, baud_rate, timeout);
				m_GuiManager.RecordLog(0, full_command);
			}
			else
			{
				string full_command2 = string.Format("ar1.Connect_mult({0},{1},{2},{3})", new object[]
				{
					GlobalRef.g_RadarDeviceId,
					com_port,
					baud_rate,
					timeout
				});
				m_GuiManager.RecordLog(0, full_command2);
			}
			try
			{
				result = (int)Init(string.Format("COM{0}", com_port), baud_rate);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_ConnectTarget: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public int Calling_ATE_ConnectTarget_Ex(uint con_type, uint com_port, uint baud_rate, uint timeout, uint dest)
		{
			int result = -1;
			string full_command = string.Format("ar1.Calling_ATE_ConnectTarget_Ex({0},{1},{2},{3},{4})", new object[]
			{
				con_type,
				com_port,
				baud_rate,
				timeout,
				dest
			});
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				result = Imports.Calling_ATE_ConnectTarget(con_type, com_port, baud_rate, timeout, dest);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_ConnectTarget_Ex: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public int Calling_SetIniFilePath(string ini_path)
		{
			int result = -1;
			string full_command = string.Format("ar1.Calling_SetIniFilePath({0})", ini_path);
			m_GuiManager.RecordLog(0, full_command);
			if (Imports.Calling_SetFrefClk == null)
			{
				GlobalRef.GuiManager.Warning("Calling_SetIniFilePath is not supported in this Trioscope DLL verison");
				return Constants.UnsupportedDllMethod;
			}
			try
			{
				Imports.Calling_SetIniFilePath(ini_path);
				result = 0;
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_SetIniFilePath: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		[AttrLuaFunc("Calling_ATE_DisconnectTarget", "Disconnect from the board")]
		public int Calling_ATE_DisconnectTarget()
		{
			int result = -1;
			string full_command = "ar1.Calling_ATE_DisconnectTarget()";
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				result = (int)m_SPWrapper.Close();
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_DisconnectTarget " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public ushort ComputeChecksum(byte[] bytes)
		{
			ushort num = initialValue;
			for (int i = 0; i < bytes.Length; i++)
			{
				num = (ushort)((int)num << 8 ^ (int)table[num >> 8 ^ (int)(byte.MaxValue & bytes[i])]);
			}
			return num;
		}

		public void crc(AR1xxxWrapper.InitialCrcValue initValue)
		{
			initialValue = (ushort)initValue;
			for (int i = 0; i < table.Length; i++)
			{
				ushort num = 0;
				ushort num2 = (ushort)(i << 8);
				for (int j = 0; j < 8; j++)
				{
					if (((num ^ num2) & 32768) != 0)
					{
						num = (ushort)((int)num << 1 ^ 4129);
					}
					else
					{
						num = (ushort)(num << 1);
					}
					num2 = (ushort)(num2 << 1);
				}
				table[i] = num;
			}
		}

		public int ComputeChecksumBytes(LuaTable inp_values, out ushort value)
		{
			int count = inp_values.Values.Count;
			byte[] array = new byte[count];
			crc(AR1xxxWrapper.InitialCrcValue.NonZero1);
			for (int i = 0; i < count; i++)
			{
				array[i] = (byte)((double)inp_values[i + 1]);
			}
			ushort num = ComputeChecksum(array);
			value = num;
			return 1;
		}

		public int GetBytes(int value, out LuaTable bytes_val)
		{
			List<object> list = new List<object>();
			byte[] bytes = BitConverter.GetBytes(value);
			for (int i = 0; i < bytes.Length; i++)
			{
				list.Add(bytes[i]);
			}
			bytes_val = m_LuaWrapper.CreateLuaTable(list);
			return 1;
		}

		public byte[] HexToBytes(string input)
		{
			byte[] array = new byte[input.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToByte(input.Substring(2 * i, 2), 16);
			}
			return array;
		}

		public void ConvertIntToHexFile(string source_file_path, string target_file_path)
		{
			if (string.IsNullOrEmpty(source_file_path) || !File.Exists(source_file_path))
			{
				MessageBox.Show("Wrong input for source file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			string[] array = File.ReadAllLines(source_file_path);
			string[] array2 = new string[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				int num;
				int.TryParse(array[i], out num);
				array2[i] = num.ToString("x");
				array2[i] = array2[i].PadLeft(8, '0');
			}
			File.WriteAllLines(target_file_path, array2);
		}

		public int Calling_ReadOcp_Single(uint abs_addr, out uint value)
		{
			int result = -1;
			value = 0U;
			string full_command = string.Format("ar1.Calling_ReadOcp_Single(0x{0})", abs_addr.ToString("X"));
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				result = Imports.Calling_ReadOcp_Single(abs_addr, out value);
				m_GuiManager.RecordLog(0, string.Format("Register: {0}; Value: 0x{1}", abs_addr.ToString("X"), value.ToString("X")));
			}
			catch (Exception ex)
			{
				m_GuiManager.ErrorAbort(string.Format("Calling_ReadOcp_Single exception: {0}. Check connection to device.", ex.Message));
			}
			return result;
		}

		public int Calling_ReadAddr_Single(uint abs_addr, out uint value)
		{
			int result = -1;
			value = 0U;
			try
			{
				result = (int)m_SPWrapper.Read(abs_addr, out value);
			}
			catch (Exception ex)
			{
				m_GuiManager.ErrorAbort(string.Format("Calling_ReadAddr_Single exception: {0}. Check connection to device.", ex.Message));
			}
			return result;
		}

		public int Calling_ReadAddr_Multi(uint abs_addr, uint num_of_dwords, out LuaTable reg_values)
		{
			int num = -1;
			uint[] array = new uint[num_of_dwords];
			List<object> list = new List<object>();
			string full_command = string.Format("ar1.Calling_ReadAddr_Multi(0x{0},values[],{1})", abs_addr.ToString("X"), num_of_dwords);
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				num = Imports.Calling_ReadAddr_Multi(abs_addr, array, num_of_dwords);
			}
			catch (Exception ex)
			{
				m_GuiManager.ErrorAbort(string.Format("Calling_ReadAddr_Multi exception: {0}. Check connection to device.", ex.Message));
			}
			if (num == 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					list.Add(array[i]);
				}
				reg_values = m_LuaWrapper.CreateLuaTable(list);
			}
			else
			{
				reg_values = null;
			}
			return num;
		}

		public int Calling_WriteOcp_Single(uint abs_addr, uint value)
		{
			int result = -1;
			string full_command = string.Format("ar1.Calling_WriteOcp_Single(0x{0},0x{1})", abs_addr.ToString("X"), value.ToString("X"));
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				result = Imports.Calling_WriteOcp_Single(abs_addr, value);
			}
			catch (Exception ex)
			{
				m_GuiManager.ErrorAbort(string.Format("Calling_WriteOcp_Single exception: {0}. Check connection to device.", ex.Message));
			}
			return result;
		}

		public int Calling_WriteAddr_Single(uint abs_addr, uint value)
		{
			int result = -1;
			try
			{
				result = (int)m_SPWrapper.Write(abs_addr, value);
			}
			catch (Exception ex)
			{
				m_GuiManager.ErrorAbort(string.Format("Calling_WriteAddr_Single exception: {0}. Check connection to device.", ex.Message));
			}
			return result;
		}

		public int Calling_WriteAddr_Multi(uint abs_addr, LuaTable reg_values, uint num_of_dwords, bool blBulk)
		{
			int result = -1;
			int count = reg_values.Values.Count;
			uint[] array = new uint[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = (uint)((double)reg_values[i + 1]);
			}
			string full_command = string.Format("ar1.Calling_WriteAddr_Multi(0x{0},values[],{1},{2})", abs_addr.ToString("X"), num_of_dwords, blBulk.ToString().ToLower());
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				result = Imports.Calling_WriteAddr_Multi(abs_addr, array, num_of_dwords, blBulk);
			}
			catch (Exception ex)
			{
				m_GuiManager.ErrorAbort(string.Format("Calling_WriteAddr_Multi exception: {0}. Check connection to device.", ex.Message));
			}
			return result;
		}

		public int m0000c7(string file_path)
		{
			int result = -1;
			uint num = 0U;
			uint num2 = 10U;
			try
			{
				if (ConnectTab.m_BSSDwnld || GlobalRef.g_BSSFwDl)
				{
					result = Calling_WriteAddr_Single(4294959368U, 2913796269U);
					result = Calling_WriteAddr_Single(4294959368U, 2902458541U);
					result = Calling_WriteAddr_Single(4294959368U, 2902458368U);
					result = Calling_WriteAddr_Single(4294959576U, 2902458624U);
					result = Calling_ReadAddr_Single(4294959580U, out num);
					while ((num & 2902524160U) == 0U && num2 > 0U)
					{
						Thread.Sleep(100);
						result = Calling_ReadAddr_Single(4294959580U, out num);
						num2 -= 1U;
					}
					result = Calling_WriteAddr_Single(4294959576U, 0U);
					byte[] value = File.ReadAllBytes(file_path);
					uint num3 = BitConverter.ToUInt32(value, 0);
					uint num4 = BitConverter.ToUInt32(value, 24);
					if (num3 == 1129467986U)
					{
						if (num4 == 0U)
						{
							if (GlobalRef.g_AR12xxDevice)
							{
								result = Calling_ReadAddr_Single(4294959520U, out num);
								result = Calling_WriteAddr_Single(4294959520U, num & 4294967288U);
								result = Calling_WriteAddr_Single(4294959584U, 7U);
								result = Calling_WriteAddr_Single(4294959424U, 173U);
								result = Calling_WriteAddr_Single(4294959576U, 2902523904U);
								result = Calling_ReadAddr_Single(4294959580U, out num);
								num2 = 10U;
								while ((num & 2902523904U) == 0U && num2 > 0U)
								{
									Thread.Sleep(100);
									result = Calling_ReadAddr_Single(4294959580U, out num);
									num2 -= 1U;
								}
								result = Calling_WriteAddr_Single(4294959576U, 0U);
							}
							else if (GlobalRef.g_AR16xxDevice)
							{
								result = Calling_WriteAddr_Single(4294959372U, 0U);
								result = Calling_WriteAddr_Single(4294960056U, 103U);
								result = Calling_ReadAddr_Single(4294960076U, out num);
								result = Calling_WriteAddr_Single(4294960076U, (num & 65535U) | 269484032U);
								result = Calling_WriteAddr_Single(4294959424U, 173U);
								result = Calling_WriteAddr_Single(4294959576U, 2902458368U);
								result = Calling_WriteAddr_Single(4294960040U, 192U);
								result = Calling_ReadAddr_Single(4294960044U, out num);
								num2 = 10U;
								while ((num & 192U) != 192U && num2 > 0U)
								{
									Thread.Sleep(100);
									result = Calling_ReadAddr_Single(4294960044U, out num);
									num2 -= 1U;
								}
								result = Calling_WriteAddr_Single(4294959576U, 0U);
							}
							else if (GlobalRef.g_AR2243Device)
							{
								result = Calling_ReadAddr_Single(4294959520U, out num);
								result = Calling_WriteAddr_Single(4294959520U, num & 4294967280U);
								result = Calling_WriteAddr_Single(4294959584U, 15U);
								result = Calling_WriteAddr_Single(4294959424U, 173U);
								result = Calling_WriteAddr_Single(4294959480U, 1073741824U);
								result = Calling_WriteAddr_Single(4294959576U, 2902523904U);
								result = Calling_ReadAddr_Single(4294959580U, out num);
								num2 = 10U;
								while ((num & 2902523904U) == 0U && num2 > 0U)
								{
									Thread.Sleep(100);
									result = Calling_ReadAddr_Single(4294959580U, out num);
									num2 -= 1U;
								}
								result = Calling_WriteAddr_Single(4294959576U, 0U);
							}
							string full_command = string.Format("Downloading BSS ROM RPRC Binary..", new object[0]);
							m_GuiManager.RecordLog(0, full_command);
						}
						else
						{
							if (GlobalRef.g_AR12xxDevice)
							{
								result = Calling_ReadAddr_Single(4294959520U, out num);
								string empty = string.Empty;
								if (m_MainAR1frm.ConnectTab.findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId) == "/ES:3")
								{
									result = Calling_WriteAddr_Single(4294959520U, num & 4294967292U);
									result = Calling_WriteAddr_Single(4294959584U, 3U);
								}
								else
								{
									result = Calling_WriteAddr_Single(4294959520U, num & 4294967288U);
									result = Calling_WriteAddr_Single(4294959584U, 7U);
								}
								result = Calling_WriteAddr_Single(4294959424U, 44288U);
								result = Calling_WriteAddr_Single(4294959576U, 2902523904U);
								result = Calling_ReadAddr_Single(4294959580U, out num);
								num2 = 10U;
								while ((num & 2902523904U) == 0U && num2 > 0U)
								{
									Thread.Sleep(100);
									result = Calling_ReadAddr_Single(4294959580U, out num);
									num2 -= 1U;
								}
								result = Calling_WriteAddr_Single(4294959576U, 0U);
							}
							else if (GlobalRef.g_AR16xxDevice)
							{
								result = Calling_WriteAddr_Single(4294960056U, 103U);
								result = Calling_ReadAddr_Single(4294960076U, out num);
								result = Calling_WriteAddr_Single(4294960076U, (num & 65535U) | 269484032U);
								result = Calling_WriteAddr_Single(4294959424U, 44288U);
								result = Calling_WriteAddr_Single(4294959576U, 2902458368U);
								result = Calling_WriteAddr_Single(4294960040U, 192U);
								result = Calling_ReadAddr_Single(4294960044U, out num);
								num2 = 10U;
								while ((num & 192U) != 192U && num2 > 0U)
								{
									Thread.Sleep(100);
									result = Calling_ReadAddr_Single(4294960044U, out num);
									num2 -= 1U;
								}
								result = Calling_WriteAddr_Single(4294959576U, 0U);
							}
							string full_command2 = string.Format("Downloading BSS Patch RPRC Binary..", new object[0]);
							m_GuiManager.RecordLog(0, full_command2);
						}
						result = m_SPWrapper.DownloadToDevice(file_path);
						GlobalRef.g_BSSFwDownloadStatus = 1U;
					}
					else
					{
						if (GlobalRef.g_AR16xxDevice)
						{
							result = Calling_WriteAddr_Single(4294959372U, 0U);
							if (num3 == 3042575265U)
							{
								result = Calling_WriteAddr_Single(4294960056U, 118U);
							}
							else
							{
								result = Calling_WriteAddr_Single(4294960056U, 103U);
							}
						}
						else
						{
							result = Calling_WriteAddr_Single(4294959576U, 2902523904U);
							result = Calling_ReadAddr_Single(4294959580U, out num);
							num2 = 10U;
							while ((num & 2902523904U) == 0U && num2 > 0U)
							{
								Thread.Sleep(100);
								result = Calling_ReadAddr_Single(4294959580U, out num);
								num2 -= 1U;
							}
							result = Calling_WriteAddr_Single(4294959576U, 0U);
						}
						if (num3 == 3042575313U || num3 == 3042575265U)
						{
							string full_command3 = string.Format("Downloading BSS ROM Legacy Binary..", new object[0]);
							m_GuiManager.RecordLog(0, full_command3);
							result = m_SPWrapper.OldVersionDownloadToDevice(file_path);
							GlobalRef.g_BSSFwDownloadStatus = 1U;
						}
						else if (num3 == 3042551583U)
						{
							string full_command4 = string.Format("Downloading BSS Patch Legacy Binary..", new object[0]);
							m_GuiManager.RecordLog(0, full_command4);
							result = m_SPWrapper.OldVersionDownloadToDevice(file_path);
							GlobalRef.g_BSSFwDownloadStatus = 1U;
						}
					}
				}
				else if (ConnectTab.m_MSSDwnld || GlobalRef.g_MSSFwDl)
				{
					uint num3 = BitConverter.ToUInt32(File.ReadAllBytes(file_path), 0);
					result = Calling_WriteAddr_Single(4294959724U, 1U);
					result = Calling_WriteAddr_Single(4294967132U, 2902458371U);
					result = Calling_ReadAddr_Single(4294967148U, out num);
					num2 = 10U;
					while ((num & 3U) != 3U && num2 > 0U)
					{
						Thread.Sleep(100);
						result = Calling_ReadAddr_Single(4294967148U, out num);
					}
					result = Calling_WriteAddr_Single(4294967132U, 0U);
					result = Calling_WriteAddr_Single(4294967072U, 44288U);
					if (num3 == 1129467986U)
					{
						string full_command5 = string.Format("Downloading MSS RPRC Binary..", new object[0]);
						m_GuiManager.RecordLog(0, full_command5);
						result = m_SPWrapper.DownloadToDevice(file_path);
						GlobalRef.g_MSSFwDownloadStatus = 1U;
					}
					else if (num3 == 895091665U)
					{
						string full_command6 = string.Format("Downloading MSS Legacy Binary..", new object[0]);
						m_GuiManager.RecordLog(0, full_command6);
						result = m_SPWrapper.OldVersionDownloadToDevice(file_path);
						GlobalRef.g_MSSFwDownloadStatus = 1U;
					}
					result = Calling_WriteAddr_Single(4294959724U, 0U);
				}
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				if (ex is OutOfMemoryException)
				{
					int num5 = 0;
					int num6 = 10;
					for (;;)
					{
						num5++;
						if (num6 > 10)
						{
							break;
						}
						GlobalRef.GuiManager.Error("OutOfMemory-Exception caught, Trying to fix. Counter: " + num5.ToString());
						Thread.Sleep(TimeSpan.FromSeconds((double)(num5 * 10)));
						GC.Collect();
						GC.WaitForPendingFinalizers();
						GC.Collect();
						GC.WaitForPendingFinalizers();
						if (num5 >= num6)
						{
							goto Block_31;
						}
					}
					throw;
					Block_31:;
				}
				else
				{
					GlobalRef.GuiManager.Error("Calling_ATE_DownloadFW: " + ex.Message, ex.StackTrace);
					SystemInfo();
					string full_command7 = string.Format("An OUT OF MEMORY error happens becuase the process is unable to find a large enough section of contiguous pages in its virtual address space to do the requested mapping", new object[0]);
					m_GuiManager.RecordLog(0, full_command7);
					string full_command8 = string.Format("Terminating application unexpectedly.....!!!!!", new object[0]);
					m_GuiManager.RecordLog(0, full_command8);
					Environment.FailFast(string.Format("Out of Memory: {0}", ex.Message));
				}
			}
			return result;
		}

		public void SystemInfo()
		{
			long num = 0L;
			long num2 = 0L;
			long num3 = 0L;
			Process process = null;
			try
			{
				process = Process.Start("Radar Studio.exe");
				do
				{
					if (!process.HasExited)
					{
						process.Refresh();
						Console.WriteLine();
						Console.WriteLine("{0} -", process.ToString());
						Console.WriteLine("-------------------------------------");
						Console.WriteLine("  physical memory usage(RAM): {0}", process.WorkingSet64);
						Console.WriteLine("  base priority: {0}", process.BasePriority);
						Console.WriteLine("  priority class: {0}", process.PriorityClass);
						Console.WriteLine("  user processor time: {0}", process.UserProcessorTime);
						Console.WriteLine("  privileged processor time: {0}", process.PrivilegedProcessorTime);
						Console.WriteLine("  total processor time: {0}", process.TotalProcessorTime);
						Console.WriteLine("  PagedSystemMemorySize64: {0}", process.PagedSystemMemorySize64);
						Console.WriteLine("  PagedMemorySize64: {0}", process.PagedMemorySize64);
						num = process.PeakPagedMemorySize64;
						num3 = process.PeakVirtualMemorySize64;
						num2 = process.PeakWorkingSet64;
						if (process.Responding)
						{
							Console.WriteLine("Status = Running");
						}
						else
						{
							Console.WriteLine("Status = Not Responding");
						}
					}
				}
				while (!process.WaitForExit(1000));
				Console.WriteLine();
				Console.WriteLine("Process exit code: {0}", process.ExitCode);
				Console.WriteLine("Peak physical memory usage of the process: {0}", num2);
				Console.WriteLine("Peak paged memory usage of the process: {0}", num);
				Console.WriteLine("Peak virtual memory usage of the process: {0}", num3);
			}
			finally
			{
				if (process != null)
				{
					process.Close();
				}
			}
		}

		public int m0000c8(string file_path)
		{
			int result = -1;
			try
			{
				if (ConnectTab.m_BSSDwnld || GlobalRef.g_BSSFwDl)
				{
					byte[] value = File.ReadAllBytes(file_path);
					uint num = BitConverter.ToUInt32(value, 0);
					uint num2 = BitConverter.ToUInt32(value, 24);
					if (num == 1129467986U)
					{
						if (num2 == 0U)
						{
							string full_command = string.Format("Downloading BSS ROM RPRC Binary..", new object[0]);
							m_GuiManager.RecordLog(0, full_command);
						}
						else
						{
							string full_command2 = string.Format("Downloading BSS Patch RPRC Binary..", new object[0]);
							m_GuiManager.RecordLog(0, full_command2);
						}
						result = m_SPWrapper.DownloadToDevice(file_path);
					}
					else if (num == 3042575313U || num == 3042575265U)
					{
						string full_command3 = string.Format("Downloading BSS ROM Legacy Binary..", new object[0]);
						m_GuiManager.RecordLog(0, full_command3);
						result = m_SPWrapper.OldVersionDownloadToDevice(file_path);
					}
					else if (num == 3042551583U)
					{
						string full_command4 = string.Format("Downloading BSS Patch Legacy Binary..", new object[0]);
						m_GuiManager.RecordLog(0, full_command4);
						result = m_SPWrapper.OldVersionDownloadToDevice(file_path);
					}
				}
				else if (ConnectTab.m_MSSDwnld || GlobalRef.g_MSSFwDl)
				{
					uint num = BitConverter.ToUInt32(File.ReadAllBytes(file_path), 0);
					if (num == 1129467986U)
					{
						string full_command5 = string.Format("Downloading MSS RPRC Binary..", new object[0]);
						m_GuiManager.RecordLog(0, full_command5);
						result = m_SPWrapper.DownloadToDevice(file_path);
					}
					else if (num == 895091665U)
					{
						string full_command6 = string.Format("Downloading MSS Legacy Binary..", new object[0]);
						m_GuiManager.RecordLog(0, full_command6);
						result = m_SPWrapper.OldVersionDownloadToDevice(file_path);
					}
				}
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_DownloadFW: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public int m0000c9(string file_path)
		{
			int result = -1;
			try
			{
				if (BitConverter.ToUInt32(File.ReadAllBytes(file_path), 0) == 1129467986U)
				{
					string full_command = string.Format("Downloading DSP RPRC Binary..", new object[0]);
					m_GuiManager.RecordLog(0, full_command);
					result = m_SPWrapper.DownloadDSPFwToDevice(file_path);
				}
				uint num;
				result = Calling_ReadAddr_Single(4294959848U, out num);
				result = Calling_WriteAddr_Single(4294959848U, num | 2902458368U);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_DownloadFW: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public int DownloadFileOvSPI(string file_path)
		{
			int result = -1;
			if (ConnectTab.m_BSSDwnld || GlobalRef.g_BSSFwDl)
			{
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					string full_command = string.Format("ar1.DownloadBssFwOvSPI({0})", file_path);
					m_GuiManager.RecordLog(0, full_command);
				}
				else
				{
					string full_command2 = string.Format("ar1.DownloadBssFwOvSPI_mult({0}, {1})", GlobalRef.g_RadarDeviceId, file_path);
					m_GuiManager.RecordLog(0, full_command2);
				}
			}
			else if (ConnectTab.m_MSSDwnld || GlobalRef.g_MSSFwDl)
			{
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					string full_command3 = string.Format("ar1.DownloadMssFwOvSPI({0})", file_path);
					m_GuiManager.RecordLog(0, full_command3);
				}
				else
				{
					string full_command4 = string.Format("ar1.DownloadMssFwOvSPI_mult({0}, {1})", GlobalRef.g_RadarDeviceId, file_path);
					m_GuiManager.RecordLog(0, full_command4);
				}
			}
			try
			{
				int fileType;
				if (GlobalRef.g_2243MetaImageDwld)
				{
					fileType = 4;
				}
				else if (ConnectTab.m_BSSDwnld || GlobalRef.g_BSSFwDl)
				{
					fileType = 0;
				}
				else if (ConnectTab.m_MSSDwnld || GlobalRef.g_MSSFwDl)
				{
					fileType = 3;
				}
				else
				{
					fileType = -1;
				}
				result = m_SPWrapper.DownloadToDeviceOvSPI(fileType, file_path);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("DownloadFileOvSPI: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public int m0000ca(string file_path)
		{
			int num = -1;
			string full_command = string.Format("ar1.DownloadDSPFWFileOvSPI({0})", file_path);
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				int num2;
				if (ConnectTab.m_BSSDwnld || GlobalRef.g_BSSFwDl)
				{
					num2 = 0;
				}
				else if (ConnectTab.m_MSSDwnld || GlobalRef.g_MSSFwDl)
				{
					num2 = 3;
				}
				else
				{
					num2 = -1;
				}
				num = m_SPWrapper.DownloadToDeviceOvSPI(num2, file_path);
				if (num == 0 && num2 == 0)
				{
					m_MainAR1frm.ConnectTab.SpiSetBSSVersion();
				}
				else if (num == 0 && num2 == 3)
				{
					m_MainAR1frm.ConnectTab.SpiSetMSSVersion();
				}
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("DownloadFileOvSPI: " + ex.Message, ex.StackTrace);
			}
			return num;
		}

		public double Calling_ATE_GetFwDownloadProgress()
		{
			double result = 0.0;
			try
			{
				result = (double)GlobalRef.m_FwDownloadProgress;
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_GetFwDownloadProgress: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		[AttrLuaFunc("Calling_SetFwFilePath", "Set the FW file path", "BSS fw file path", "MSS fw file path")]
		public int Calling_SetFwFilePath(string bss_file_path, string mss_file_path)
		{
			int result = -1;
			m_GuiManager.RecordLog(0, string.Format("ar1.Calling_SetFwFilePath({0}, {1})", bss_file_path, mss_file_path));
			try
			{
				string file_path;
				if (m_GuiManager.PhyStandAlone)
				{
					file_path = bss_file_path;
				}
				else if (mss_file_path == "")
				{
					file_path = bss_file_path;
				}
				else
				{
					file_path = mss_file_path;
				}
				result = Imports.Calling_SetFwFilePath(file_path);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_SetFwFilePath: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		[AttrLuaFunc("Calling_GetFwFilePath", "Get the FW file path", "out FW file path")]
		public int Calling_GetFwFilePath(out string file_path)
		{
			string full_command = string.Format("ar1.Calling_GetFwFilePath({0})", new StringBuilder
			{
				Capacity = 256
			});
			m_GuiManager.RecordLog(0, full_command);
			file_path = m_MainAR1frm.ConnectTab.GetPhyFwPath();
			return 1;
		}

		public int m0000cb(string Ini_file_path, out string strError, bool enableGetFEMType)
		{
			int result = -1;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Capacity = 256;
			strError = "";
			m_GuiManager.RecordLog(0, "Empty function");
			m_GuiManager.RecordLog(0, string.Format("ar1.Calling_ATE_Read_INI_File(\"{0}\", {1})", Ini_file_path, enableGetFEMType.ToString().ToLower()));
			if (Imports.f0002a9 == null)
			{
				GlobalRef.GuiManager.Warning("Calling_ATE_Read_INI_File is not supported in this Trioscope DLL verison");
				return Constants.UnsupportedDllMethod;
			}
			try
			{
				result = Imports.f0002a9(Ini_file_path, stringBuilder, enableGetFEMType);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_Read_INI_File: " + ex.Message, ex.StackTrace);
			}
			strError = stringBuilder.ToString();
			return result;
		}

		public int Calling_ATE_GetSingleCalibStatus(byte calibration_type, out sbyte calibration_error)
		{
			m_GuiManager.RecordLog(0, string.Format("ar1.Calling_ATE_GetSingleCalibStatus({0})", calibration_type));
			return Imports.Calling_ATE_GetSingleCalibStatus(calibration_type, out calibration_error);
		}

		public int Calling_ATE_GetCalibsStatusCa(out short[] calibration_errors)
		{
			calibration_errors = new short[30];
			return Imports.Calling_ATE_GetCalibsStatus(calibration_errors);
		}

		public int Calling_ATE_GetCalibsStatus(out LuaTable calibration_errors)
		{
			short[] array = new short[30];
			List<object> list = new List<object>();
			m_GuiManager.RecordLog(0, "ar1.Calling_ATE_GetCalibsStatus(calib_errs[])");
			int num = Imports.Calling_ATE_GetCalibsStatus(array);
			if (num == 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					list.Add(array[i]);
				}
				calibration_errors = m_LuaWrapper.CreateLuaTable(list);
			}
			else
			{
				calibration_errors = null;
			}
			return num;
		}

		public int Calling_ATE_TxPacket(uint delay, uint rate, ushort size, ushort amount, ushort seed, sbyte packetMode, sbyte dcfOnOff, sbyte p7, sbyte preamble, sbyte type, sbyte scrambler, sbyte enableCLPC, sbyte seqNumMode, string SrcMacAddr, string DstMacAddr)
		{
			int result = -1;
			m_GuiManager.RecordLog(0, string.Format("ar1.Calling_ATE_TxPacket({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, \"{13}\", \"{14}\")",
                delay,
                rate,
                size,
                amount,
                seed,
                packetMode,
                dcfOnOff,
                p7,
                preamble,
                type,
                scrambler,
                enableCLPC,
                seqNumMode,
                SrcMacAddr,
                DstMacAddr
            ));
			byte[] iSrcMacAddr;
			if (!iConvertMacAddressToByteArray(SrcMacAddr, out iSrcMacAddr))
			{
				return result;
			}
			byte[] iDstMacAddr;
			if (!iConvertMacAddressToByteArray(DstMacAddr, out iDstMacAddr))
			{
				return result;
			}
			try
			{
				result = Imports.Calling_ATE_TxPacket(delay, rate, size, amount, 0, seed, packetMode, dcfOnOff, p7, preamble, type, scrambler, enableCLPC, seqNumMode, iSrcMacAddr, iDstMacAddr);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_TxPacket: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		private bool iConvertMacAddressToByteArray(string mac_address, out byte[] byte_arr)
		{
			string[] array = mac_address.Split(new char[]
			{
				':'
			}, StringSplitOptions.RemoveEmptyEntries);
			byte_arr = new byte[array.Length];
			if (byte_arr.Length < 6)
			{
				m_GuiManager.LuaError(string.Format("Invalid mac address format: {0}. should be 6 bytes in format 'xx:xx:xx:xx:xx:xx'", mac_address));
				return false;
			}
			try
			{
				for (int i = 0; i < array.Length; i++)
				{
					byte_arr[i] = Convert.ToByte(array[i], 16);
				}
			}
			catch
			{
				m_GuiManager.LuaError(string.Format("Invalid mac address format: {0}. should be 6 bytes in format 'xx:xx:xx:xx:xx:xx'", mac_address));
				return false;
			}
			return true;
		}

		public int m0000cc()
		{
			int result = -1;
			m_GuiManager.RecordLog(0, string.Format("ar1.Calling_ATE_TXStop()", new object[0]));
			try
			{
				result = Imports.f0002ab();
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_TXStop: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public int Calling_ATE_TxTone(uint power, uint tone_type, uint ppa_step, uint ToneNumberSingleTones, uint ToneNumberTwoTones, uint UseDigitalDC, uint invert, uint ElevenNSpan, uint DigitalDC, uint AnalogDCFine, uint AnalogDCCoarse)
		{
			m_GuiManager.RecordLog(0, string.Format("ar1.Calling_ATE_TxTone({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10})",
                power,
                tone_type,
                ppa_step,
                ToneNumberSingleTones,
                ToneNumberTwoTones,
                UseDigitalDC,
                invert,
                ElevenNSpan,
                DigitalDC,
                AnalogDCFine,
                AnalogDCCoarse
            ));
			return Imports.Calling_ATE_TxTone(power, tone_type, ppa_step, ToneNumberSingleTones, ToneNumberTwoTones, UseDigitalDC, invert, ElevenNSpan, DigitalDC, AnalogDCFine, AnalogDCCoarse);
		}

		public int Calling_ATE_PowerMode(byte power_mode)
		{
			int num = -1;
			m_GuiManager.RecordLog(0, string.Format("Calling_TrioScopeTest(0x22, {0})", power_mode));
			AR1xxxWrapper.TTestCmdDebug ttestCmdDebug = default(AR1xxxWrapper.TTestCmdDebug);
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				ttestCmdDebug.iPowerMode = power_mode;
				intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(ttestCmdDebug));
				Marshal.StructureToPtr(ttestCmdDebug, intPtr, false);
				num = Imports.Calling_TrioScopeTest(34U, intPtr);
				if (num != 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Capacity = 256;
					Imports.Calling_ATE_GetRadioError((short)num, stringBuilder);
					stringBuilder.ToString();
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
					return num;
				}
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_PowerMode: " + ex.Message, ex.StackTrace);
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			return num;
		}

		public int Calling_ATE_Channel(byte band, byte channel)
		{
			int result = -1;
			m_GuiManager.RecordLog(0, string.Format("ar1.Calling_ATE_Channel({0}, {1})", band, channel));
			try
			{
				result = Imports.Calling_ATE_Channel((sbyte)band, channel);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_Channel: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public int Calling_ATE_TxGainAdjust(int desiredPwr, byte useIniLimitPower)
		{
			int result = -1;
			m_GuiManager.RecordLog(0, string.Format("ar1.Calling_ATE_TxGainAdjust({0}, {1})", desiredPwr, useIniLimitPower));
			try
			{
				result = Imports.Calling_ATE_TxGainAdjust(desiredPwr, useIniLimitPower);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("ar1.Calling_ATE_TxGainAdjust: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public int Start_RX_Simulation()
		{
			int result = -1;
			m_GuiManager.RecordLog(0, "ar1.Start_RX_Simulation()");
			try
			{
				result = Imports.Calling_TrioScopeTest(19U, IntPtr.Zero);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Start_RX_Simulation: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public int Calling_ATE_RxStatistics(out uint ReceivedPlcpErrorPacketsNumber, out uint ReceivedValidPacketsNumber, out uint ReceivedFcsErrorPacketsNumber, out uint AvarageDataCtrlRssi, out uint total, out double Per)
		{
			int num = -1;
			Per = -1.0;
			total = 0U;
			AvarageDataCtrlRssi = 0U;
			ReceivedPlcpErrorPacketsNumber = 0U;
			ReceivedFcsErrorPacketsNumber = 0U;
			ReceivedValidPacketsNumber = 0U;
			try
			{
				short num2;
				short num3;
				short num4;
				uint num5;
				uint num6;
				uint num7;
				num = Imports.Calling_ATE_RxStatistics(out ReceivedValidPacketsNumber, out ReceivedFcsErrorPacketsNumber, out ReceivedPlcpErrorPacketsNumber, out AvarageDataCtrlRssi, out num2, out num3, out num4, out num5, out num6, out num7);
				if (num != 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Capacity = 256;
					Imports.Calling_ATE_GetRadioError((short)num, stringBuilder);
					string msg = string.Format("[{0}].Calling_ATE_Get_Rx_Statistics: {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), stringBuilder);
					GlobalRef.GuiManager.Error(msg);
				}
				/*
				string.Format("ReceivedValidPacketsNumber = {0} ReceivedFcsErrorPacketsNumber = {1} ReceivedPlcpErrorPacketsNumber = {2}", ReceivedValidPacketsNumber, ReceivedFcsErrorPacketsNumber, ReceivedPlcpErrorPacketsNumber);
				string.Format("AvarageDataCtrlRssi = {0} AvarageMgMntRssi = {1} StartTimeStamp = {2} GetTimeStamp = {3} ", new object[]
				{
					AvarageDataCtrlRssi,
					num5,
					num6,
					num7
				});
				*/
				total = ReceivedValidPacketsNumber + ReceivedPlcpErrorPacketsNumber + ReceivedFcsErrorPacketsNumber;
				Per = m0000cd(total, ReceivedValidPacketsNumber, ReceivedPlcpErrorPacketsNumber);
				total -= ReceivedPlcpErrorPacketsNumber;
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_ATE_Get_Rx_Statistics: " + ex.Message, ex.StackTrace);
			}
			return num;
		}

		private double m0000cd(uint total_packets, uint received_valid_packets_number, uint received_plcp_error_packets_number)
		{
			if (total_packets == 0U)
			{
				return 0.0;
			}
			double num = (total_packets - received_valid_packets_number - received_plcp_error_packets_number) * 100.0 / (total_packets - received_plcp_error_packets_number);
			if (0.0 > num || 100.0 < num)
			{
				return -1.0;
			}
			return num;
		}

		public int Stop_RX_Simulation()
		{
			int result = -1;
			m_GuiManager.RecordLog(0, "ar1.Stop_RX_Simulation()");
			try
			{
				result = Imports.Calling_TrioScopeTest(18U, IntPtr.Zero);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Stop_RX_Simulation: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public bool RX_ResetStatistics()
		{
			m_GuiManager.RecordLog(0, "called ar1.RX_ResetStatistics()");
			try
			{
				int num = Imports.Calling_TrioScopeTest(20U, IntPtr.Zero);
				m_GuiManager.RecordLog(0, "exit ar1.RX_ResetStatistics()");
				if (num != 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Capacity = 256;
					Imports.Calling_ATE_GetRadioError((short)num, stringBuilder);
					GlobalRef.GuiManager.Error("RX_ResetStatistics: " + stringBuilder);
				}
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("RX_ResetStatistics: " + ex.Message, ex.StackTrace);
			}
			return true;
		}

		public int Calling_ATE_GetTemperature(out sbyte p_temperature)
		{
			m_GuiManager.RecordLog(0, "ar1.Calling_ATE_GetTemperature()");
			return Imports.Calling_ATE_GetTemperature(out p_temperature);
		}

		public int Calling_ATE_GetVbat(out double p_Vbat)
		{
			string full_command = "ar1.Calling_ATE_GetVbat()";
			m_GuiManager.RecordLog(0, full_command);
			return Imports.Calling_ATE_GetVbat(out p_Vbat);
		}

		[AttrLuaFunc("Calling_IsFirmwareRunning", "return if FW is running or not")]
		public int Calling_IsFirmwareRunning()
		{
			int result = -1;
			string full_command = "ar1.Calling_IsFirmwareRunning()";
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				result = m_MainAR1frm.ConnectTab.SetBSSVersions();
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
					throw ex;

				GlobalRef.GuiManager.Error("Calling_IsFirmwareRunning: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		[AttrLuaFunc("Calling_IsConnected", "return if Connected to the board or not")]
		public bool Calling_IsConnected()
		{
			bool flag = false;
			string full_command = "ar1.Calling_IsConnected()";
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				flag = m_SPWrapper.IsConnected();
				if (flag)
				{
					m_MainAR1frm.ConnectTab.SetSOPModeinGui();
				}
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_IsConnected: " + ex.Message, ex.StackTrace);
			}
			return flag;
		}

		public void Calling_GetDllVersion(string dll_name, out string p1)
		{
			new StringBuilder().Capacity = 256;
			p1 = "0.0.0.1";
		}

		[AttrLuaFunc("Calling_GetFW_Version", "Get the version of the FW loaded", "out FW version")]
		public int Calling_GetFW_Version(out string p0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Capacity = 256;
			m_GuiManager.RecordLog(0, "ar1.Calling_GetFW_Version()");
			m_MainAR1frm.ConnectTab.SetBSSVersions();
			int result = 0;
			p0 = stringBuilder.ToString();
			return result;
		}

		public void Calling_SetSwFlowControl(bool IsSwFlowControl)
		{
			m_GuiManager.RecordLog(0, string.Format("ar1.Calling_SetSwFlowControl({0})", IsSwFlowControl.ToString().ToLower()));
			Imports.Calling_SetSwFlowControl(IsSwFlowControl);
		}

		public int Calling_SetTimeOut(uint timeout)
		{
			int result = -1;
			m_GuiManager.RecordLog(0, string.Format("ar1.Calling_SetTimeOut({0})", timeout));
			if (Imports.Calling_SetTimeOut == null)
			{
				GlobalRef.GuiManager.Warning("Calling_SetTimeOut is not supported in this Trioscope DLL verison");
				return Constants.UnsupportedDllMethod;
			}
			try
			{
				result = Imports.Calling_SetTimeOut(timeout);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					throw ex;
				}
				GlobalRef.GuiManager.Error("Calling_SetTimeOut: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		[AttrLuaFunc("GuiVersion", "Displays the AutoRadar AR1xxx GUI version")]
		public string GuiVersion()
		{
			string full_command = "ar1.GuiVersion()";
			m_GuiManager.RecordLog(0, full_command);
			return "2.1.1.0";
		}

		public void SaveSettings(string file_name)
		{
			string full_command = string.Format("ar1.SaveSettings('{0}')", file_name);
			m_GuiManager.RecordLog(0, full_command);
			GuiSettings.Default.Save(file_name);
		}

		public void LoadSettings(string file_name)
		{
			m_GuiManager.RecordLog(0, string.Format("ar1.LoadSettings('{0}')", file_name));
			GuiSettings.Default.Load(file_name);
		}

		public int API_ChannelTune(byte band, byte channel, byte bandwidth)
		{
			return m_GuiManager.DllOps.ChannelTune_Ext((int)band, (int)channel, (int)bandwidth);
		}

		public int API_ReadIniFile(string path, out string error_str, bool EnableGetFEMType)
		{
			return m_GuiManager.DllOps.ReadIni_Ext(path, out error_str, EnableGetFEMType);
		}

		[AttrLuaFunc("SetUpContMode", "Capture and Display the Cont Stream ADC data", new string[]
		{
			"Dump fileName",
			"Number of Samples"
		})]
		public int SetUpContMode()
		{
			return m_GuiManager.DllOps.SetUpContStreamMode();
		}

		[AttrLuaFunc("GetBSSFwVersionAPI", "Get the version of both BSS FW and patch over SPI", new string[]
		{
			"out BSS firmware version",
			"out BSS Patch firmware version"
		})]
		public int m0000ce(out string BSSFwVersion, out string BSSPatchFwVersion)
		{
			return m_GuiManager.ScriptOps.SpiSetBSSPatchVersionOverSPI(out BSSFwVersion, out BSSPatchFwVersion);
		}

		[AttrLuaFunc("GetMSSFwVersionAPI", "Get the version of both MSS FW and patch over SPI", new string[]
		{
			"out MSS firmware version",
			"out MSS Patch firmware version"
		})]
		public int m0000cf(out string MSSFwVersion, out string MSSPatchFwVersion)
		{
			return m_GuiManager.ScriptOps.SpiSetMSSPatchVersionOverSPI(out MSSFwVersion, out MSSPatchFwVersion);
		}

		[AttrLuaFunc("GetBSSFwVersion", "Get the version of the FW loaded (and update it in the gui)")]
		public string GetBSSFwVersion()
		{
			string bssFwVersion = GetBssFwVersion();
			string empty = string.Empty;
			string.IsNullOrEmpty(bssFwVersion);
			return bssFwVersion;
		}

		[AttrLuaFunc("GetBSSPatchFwVersion", "Get the version of the BSS Patch FW loaded (and update it in the gui)")]
		public string GetBSSPatchFwVersion()
		{
			string bssPatchFwVersion = GetBssPatchFwVersion();
			string empty = string.Empty;
			string.IsNullOrEmpty(bssPatchFwVersion);
			return bssPatchFwVersion;
		}

		[AttrLuaFunc("GetDSPFwVersion", "Get the version of the FW loaded (and update it in the gui)")]
		public string GetDSPFwVersion()
		{
			string dspFwVersion = GetDspFwVersion();
			string text = string.Empty;
			if (string.IsNullOrEmpty(dspFwVersion))
			{
				return dspFwVersion;
			}
			foreach (char c in dspFwVersion)
			{
				if (c == '(')
				{
					break;
				}
				text += c.ToString();
			}
			return text;
		}

		[AttrLuaFunc("GetDieId", "Get the DieId which consist of Lot , waper, DevX and DevY information")]
		public string GetDIEIdInfo()
		{
			return m_MainAR1frm.ConnectTab.GetDieId(GlobalRef.g_RadarDeviceId);
		}

		public string GetBssFwVersion()
		{
			return m_MainAR1frm.ConnectTab.GetBssFwVersion();
		}

		public string GetBssPatchFwVersion()
		{
			if (m_MainAR1frm.ConnectTab.BSSPatchSpecialSignatureIdentifier(1074266112U, 1074266116U) == 0)
			{
				return m_MainAR1frm.ConnectTab.GetBssPatchFwVersion();
			}
			return "NA";
		}

		public string GetDspFwVersion()
		{
			return m_MainAR1frm.ConnectTab.GetDspFwVersion();
		}

		[AttrLuaFunc("GetMSSFwVersion", "Get the version of the FW loaded (and update it in the gui)")]
		public string GetMSSFwVersion()
		{
			string mssFwVersion = GetMssFwVersion();
			string empty = string.Empty;
			string.IsNullOrEmpty(mssFwVersion);
			return mssFwVersion;
		}

		[AttrLuaFunc("GetMSSPatchFwVersion", "Get the version of the MSS patch FW loaded (and update it in the gui)")]
		public string GetMSSPatchFwVersion()
		{
			string mssPatchFwVersion = GetMssPatchFwVersion();
			string empty = string.Empty;
			string.IsNullOrEmpty(mssPatchFwVersion);
			return mssPatchFwVersion;
		}

		public string GetMssFwVersion()
		{
			return m_MainAR1frm.ConnectTab.GetMssFwVersion();
		}

		public string GetMssPatchFwVersion()
		{
			if (!GlobalRef.g_AR12xxDevice && !GlobalRef.g_AR2243Device)
			{
				return "NA";
			}
			if (m_MainAR1frm.ConnectTab.MSSPatchSpecialSignatureIdentifier(2097152U, 2097156U) == 0)
			{
				return m_MainAR1frm.ConnectTab.GetMssPatchFwVersion();
			}
			return "NA";
		}

		public string GetFdspVersion()
		{
			return m_MainAR1frm.ConnectTab.GetFdspVersion();
		}

		[AttrLuaFunc("ShowGui", "Display the AutoRadar AR1xxx FW User interface")]
		public void ShowGui()
		{
			if (m_LuaWrapper.GuiMain.InvokeRequired)
			{
				del_v_v method = new del_v_v(ShowGui);
				m_LuaWrapper.GuiMain.Invoke(method);
				return;
			}
			if (m_MainAR1frm == null)
			{
				m_MainAR1frm = new frmAR1Main(m_GuiManager);
			}
			m_LuaWrapper.ShowGuiFunc(m_MainAR1frm);
			m_MainAR1frm.Focus();
		}

		[AttrLuaFunc("HideGui", "Hide the AutoRadar AR1xxx FW User interface")]
		public void HideGui()
		{
			if (!IsGuiShown())
			{
				return;
			}
			if (m_LuaWrapper.GuiMain.InvokeRequired)
			{
				del_v_v method = new del_v_v(HideGui);
				m_LuaWrapper.GuiMain.Invoke(method);
				return;
			}
			m_MainAR1frm.Hide();
		}

		public void CloseGui()
		{
			if (m_LuaWrapper.GuiMain.InvokeRequired)
			{
				del_v_v method = new del_v_v(CloseGui);
				m_LuaWrapper.GuiMain.Invoke(method);
				return;
			}
			if (m_MainAR1frm == null || !m_MainAR1frm.IsHandleCreated)
			{
				return;
			}
			m_MainAR1frm.Close();
			m_MainAR1frm = null;
		}

		[AttrLuaFunc("Error", "Display an error message", new string[]
		{
			"the message"
		})]
		public void Error(string msg)
		{
			GuiManager.Error(msg);
		}

		[AttrLuaFunc("Warning", "Display a warning message", new string[]
		{
			"the message"
		})]
		public void Warning(string msg)
		{
			GuiManager.Warning(msg);
		}

		[AttrLuaFunc("Connect", "Connect to the board", new string[]
		{
			"com port number",
			"baud rate",
			"timeout (ms)"
		})]
		public int Connect(uint com_port, uint baud_rate, uint timeout)
		{
			return m_GuiManager.DllOps.Connect_Ext(1U, 1U, com_port, baud_rate, timeout, 2U, 0U);
		}

		public void demo()
		{
			if (GlobalRef.g_AR16xxDevice)
			{
				m_MainAR1frm.ConnectTab.EnableDSPConfSpecifications();
			}
		}

		[AttrLuaFunc("Connect_mult", "Connect to the board", new string[]
		{
			"RadarDeviceId",
			"com port number",
			"baud rate",
			"timeout (ms)"
		})]
		public int Connect(uint RadarDeviceId, uint com_port, uint baud_rate, uint timeout)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.DllOps.Connect_Ext(RadarDeviceId, 1U, com_port, baud_rate, timeout, 2U, 0U);
		}

		public int ConnectEx(uint RadarDeviceId, uint con_type, uint com_port, uint baud_rate, uint timeout, uint dest)
		{
			return m_GuiManager.DllOps.Connect_Ext(RadarDeviceId, con_type, com_port, baud_rate, timeout, 2U, dest);
		}

		public int API_Connect(uint RadarDeviceId, uint con_type, uint com_port, uint baud_rate, uint timeout, uint board_type, uint dest)
		{
			return m_GuiManager.DllOps.Connect_Ext(RadarDeviceId, con_type, com_port, baud_rate, timeout, board_type, dest);
		}

		[AttrLuaFunc("Disconnect", "Disconnect from the board")]
		public int Disconnect()
		{
			return m_GuiManager.DllOps.Disconnect_Ext(1U);
		}

		[AttrLuaFunc("Disconnect_mult", "RadarDeviceId", new string[]
		{
			"Disconnect from the board"
		})]
		public int Disconnect(uint RadarDeviceId)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_GuiManager.DllOps.Disconnect_Ext(RadarDeviceId);
		}

		[AttrLuaFunc("deviceVariantSelection", "Select diffrent Device Variant for Download firmware", new string[]
		{
			"XWR1243, XWR1443, XWR1642, IWR6843, XWR1843"
		})]
		public int deviceVariantSelection(string DeviceName)
		{
			return m_MainAR1frm.ConnectTab.SelectDeviceVariantForFwDownload(DeviceName);
		}

		[AttrLuaFunc("GetdeviceVariant", "Get Device Variant", new string[]
		{
			"XWR1243, XWR1443, XWR1642, IWR6843, XWR1843"
		})]
		public int deviceVariantSelection(out string DeviceName)
		{
			return m_MainAR1frm.ConnectTab.GetDeviceVariant(out DeviceName);
		}

		[AttrLuaFunc("DownloadBSSFw", "Download firmware", new string[]
		{
			"path to fw file"
		})]
		public int DownloadBSSFw(string path)
		{
			GlobalRef.g_RadarDeviceId = 1U;
			GlobalRef.g_BSSFwDl = true;
			string full_command = string.Format("ar1.DownloadBSSFw(\"{0}\")", path);
			m_GuiManager.RecordLog(103, full_command);
			int result = m_MainAR1frm.ConnectTab.m000020(path);
			m_MainAR1frm.ConnectTab.SetMSSFrwLoadReadyState();
			m_MainAR1frm.ConnectTab.ReSetBSSFrwReadyState();
			return result;
		}

		[AttrLuaFunc("DownloadBSSFw_mult", "Download firmware", new string[]
		{
			"RadarDeviceId",
			"path to fw file"
		})]
		public int DownloadBSSFw(uint RadarDeviceId, string path)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			GlobalRef.g_RadarDeviceId = RadarDeviceId;
			GlobalRef.g_BSSFwDl = true;
			string full_command = string.Format("ar1.DownloadBSSFw_mult({0},\"{1}\")", RadarDeviceId, path);
			m_GuiManager.RecordLog(103, full_command);
			return m_MainAR1frm.ConnectTab.m000020(path);
		}

		[AttrLuaFunc("CustomDownloadBSSFw", "Custom Download firmware", new string[]
		{
			"path to fw file"
		})]
		public int CustomDownloadBSSFw(string path)
		{
			GlobalRef.g_BSSFwDl = true;
			string full_command = string.Format("ar1.CustomDownloadBSSFw(\"{0}\")", path);
			m_GuiManager.RecordLog(103, full_command);
			return m_MainAR1frm.ConnectTab.CustomDownloadBssFw(path);
		}

		[AttrLuaFunc("DownloadDSPFw", "Download DSP firmware", new string[]
		{
			"path to fw file"
		})]
		public int DownloadDSPFw(string path)
		{
			GlobalRef.g_RadarDeviceId = 1U;
			GlobalRef.g_DSPFwDl = true;
			string full_command = string.Format("ar1.DownloadDSPFw(\"{0}\")", path);
			m_GuiManager.RecordLog(103, full_command);
			return m_MainAR1frm.ConnectTab.m000021(path);
		}

		[AttrLuaFunc("DownloadDSPFw_mult", "Download DSP firmware", new string[]
		{
			"RadarDeviceId",
			"path to fw file"
		})]
		public int DownloadDSPFw(uint RadarDeviceId, string path)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			GlobalRef.g_RadarDeviceId = RadarDeviceId;
			GlobalRef.g_DSPFwDl = true;
			string full_command = string.Format("ar1.DownloadDSPFw_mult({0}, \"{1}\")", RadarDeviceId, path);
			m_GuiManager.RecordLog(103, full_command);
			return m_MainAR1frm.ConnectTab.m000021(path);
		}

		[AttrLuaFunc("DownloadMSSFw", "Download MSS firmware", new string[]
		{
			"path to fw file"
		})]
		public int DownloadMSSFw(string path)
		{
			GlobalRef.g_RadarDeviceId = 1U;
			GlobalRef.g_MSSFwDl = true;
			string full_command = string.Format("ar1.DownloadMSSFw(\"{0}\")", path);
			m_GuiManager.RecordLog(103, full_command);
			return m_MainAR1frm.ConnectTab.DownloadMssFw(path);
		}

		[AttrLuaFunc("DownloadMSSFw_mult", "Download MSS firmware", new string[]
		{
			"RadarDeviceId",
			"path to fw file"
		})]
		public int DownloadMSSFw(uint RadarDeviceId, string path)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			GlobalRef.g_RadarDeviceId = RadarDeviceId;
			GlobalRef.g_MSSFwDl = true;
			string full_command = string.Format("ar1.DownloadMSSFw_mult({0},\"{1}\")", RadarDeviceId, path);
			m_GuiManager.RecordLog(103, full_command);
			return m_MainAR1frm.ConnectTab.DownloadMssFw(path);
		}

		[AttrLuaFunc("CustomDownloadMSSFw", "Custom Download MSS firmware", new string[]
		{
			"path to fw file"
		})]
		public int CustomDownloadMSSFw(string path)
		{
			GlobalRef.g_MSSFwDl = true;
			string full_command = string.Format("ar1.CustomDownloadMSSFw(\"{0}\")", path);
			m_GuiManager.RecordLog(103, full_command);
			return m_MainAR1frm.ConnectTab.CustomDownloadMssFw(path);
		}

		[AttrLuaFunc("GetBSSFwPath", "Get the path of the BSS firmware")]
		public string GetBSSFwPath()
		{
			string text = m_MainAR1frm.ConnectTab.GetPhyFwPath();
			if (string.IsNullOrEmpty(text))
			{
				text = "\"\"";
			}
			return text;
		}

		[AttrLuaFunc("GetMSSFwPath", "Get the path of the MSS firmware")]
		public string GetMSSFwPath()
		{
			string text = m_MainAR1frm.ConnectTab.GetMssFwPath();
			if (string.IsNullOrEmpty(text))
			{
				text = "\"\"";
			}
			return text;
		}

		public string GetFwPath()
		{
			string result = m_MainAR1frm.ConnectTab.GetPhyFwPath();
			if (IsGuiShown())
			{
				if (m_GuiManager.PhyStandAlone)
				{
					result = m_MainAR1frm.ConnectTab.GetPhyFwPath();
				}
				else
				{
					result = m_MainAR1frm.ConnectTab.GetMacFwPath();
				}
			}
			else
			{
				try
				{
					Calling_GetFwFilePath(out result);
				}
				catch
				{
					result = "";
				}
			}
			return result;
		}

		[AttrLuaFunc("ReadRegister", "Read a register by address", new string[]
		{
			"register address",
			"start bit",
			"end bit",
			"out value"
		})]
		public int ReadRegister(uint address, int start_bit, int end_bit, out uint value)
		{
			value = 0U;
			int num = ReadRegister(2, address, start_bit, end_bit, out value);
			string text = "0x" + address.ToString("x");
			string full_command = string.Format("ar1.ReadRegister({0}, {1}, {2})", new object[]
			{
				text,
				(ushort)start_bit,
				end_bit
			});
			m_GuiManager.RecordLog(0, full_command);
			if (num == 0 && IsGuiShown())
			{
				m_MainAR1frm.RegOpeTab.ReadWriteExt(2, address, start_bit, end_bit, value);
			}
			return num;
		}

		[AttrLuaFunc("GetInternalRfCfg_mult", "GetInternalRfCfg", new string[]
		{
			"Radar Device Id",
			"ProfileIDValue",
			"register address",
			"start bit",
			"end bit",
			"out Register Value"
		})]
		public int GetInternalRfCfg(ushort RadarDeviceId, ushort ProfileIDValue, uint address, ushort start_bit, ushort end_bit, out string RegVal)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			RegVal = string.Empty;
			return m_MainAR1frm.RegOpeTab.iReadBssRegister_ViaCmdLine(RadarDeviceId, ProfileIDValue, address, start_bit, end_bit, out RegVal);
		}

		[AttrLuaFunc("GetInternalRfCfg", "GetInternalRfCfg", new string[]
		{
			"ProfileIDValue",
			"register address",
			"start bit",
			"end bit",
			"out Register Value"
		})]
		public int GetInternalRfCfg(ushort ProfileIDValue, uint address, ushort start_bit, ushort end_bit, out string RegVal)
		{
			RegVal = string.Empty;
			return m_MainAR1frm.RegOpeTab.iReadBssRegister_ViaCmdLine(1, ProfileIDValue, address, start_bit, end_bit, out RegVal);
		}

		[AttrLuaFunc("SetInternalRfCfg_mult", "SetInternalRfCfg", new string[]
		{
			"Radar Device ID",
			"ProfileID",
			"register address",
			"value to write",
			"start bit",
			"end bit"
		})]
		public int SetInternalRfCfg(ushort RadarDeviceId, ushort profId, uint address, uint value, ushort start_bit, ushort end_bit)
		{
			m_MainAR1frm.setRadarDevMapGui(GlobalRef.g_RadarDeviceId);
			return m_MainAR1frm.RegOpeTab.iWriteBssRegister_CmdLine(RadarDeviceId, profId, address, value, start_bit, end_bit);
		}

		[AttrLuaFunc("SetInternalRfCfg", "SetInternalRfCfg", new string[]
		{
			"ProfileID",
			"register address",
			"value to write",
			"start bit",
			"end bit"
		})]
		public int SetInternalRfCfg(ushort profId, uint address, uint value, ushort start_bit, ushort end_bit)
		{
			return m_MainAR1frm.RegOpeTab.iWriteBssRegister_CmdLine(1, profId, address, value, start_bit, end_bit);
		}

		public int ReadRegister(int type, uint address, int start_bit, int end_bit, out uint value)
		{
			int result = 0;
			value = 0U;
			string full_command = iGetRecordLogMsg(type, address, start_bit, end_bit);
			GuiManager.RecordLog(0, full_command, false);
			try
			{
				if (m_GuiManager.IsElpOn)
				{
					m_GuiManager.Error("Access to all registers is disabled when in ELP mode");
					return -1;
				}
				if (m_GuiManager.IsPowerDownOn && type == 1)
				{
					m_GuiManager.Error("Access to PHY registers is disabled when in Power Down mode");
					return -1;
				}
				uint addr = iGetAbsAddress(address, (RegType)type);
				value = m_SPWrapper.Read(addr, (uint)start_bit, (uint)end_bit);
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.Error("ReadRegister: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		[AttrLuaFunc("WriteRegister", "Write to a register by address and mask", new string[]
		{
			"register address",
			"start bit",
			"end bit",
			"value"
		})]
		public int WriteRegister(uint address, int start_bit, int end_bit, uint value)
		{
			int num = WriteRegister(2, address, start_bit, end_bit, value);
			if (num == 0 && IsGuiShown())
			{
				m_MainAR1frm.RegOpeTab.ReadWriteExt(2, address, start_bit, end_bit, value);
			}
			return num;
		}

		public int WriteRegister(int type, uint address, int start_bit, int end_bit, uint value)
		{
			int num = -1;
			string full_command = iGetRecordLogMsg(type, address, start_bit, end_bit, value);
			GuiManager.RecordLog(0, full_command, false);
			try
			{
				int num2 = end_bit - start_bit + 1;
				uint abs_addr = iGetAbsAddress(address, (RegType)type);
				if (type == 4)
				{
					uint num3 = (1U << num2) - 1U << start_bit;
					uint num4;
					num = Calling_ReadOcp_Single(abs_addr, out num4);
					if (num == 0)
					{
						num4 = ((num4 & ~num3) | value << start_bit);
						num = Calling_WriteOcp_Single(abs_addr, num4);
					}
				}
				else if (type == 7)
				{
					uint num4;
					num = Calling_ReadAddr_Single(abs_addr, out num4);
					if (num == 0)
					{
						uint num5 = num4 >> end_bit;
						uint num6 = num4 >> start_bit;
						uint num7 = num4 - (num6 << start_bit);
						num4 = (num5 << end_bit) + (value << start_bit) + num7;
						num4 = (uint)(18446744073709486080UL + (ulong)num4);
						num = Calling_WriteAddr_Single(abs_addr, num4);
					}
				}
				else
				{
					if (type == 6)
					{
						abs_addr = (address & Constants.NWP_SHIFT) + Constants.NWP_SRAM_OFFSET;
					}
					if (type == 5)
					{
						abs_addr = (address & Constants.NWP_SHIFT) + Constants.NWP_OFFSET;
					}
					if (num2 == 32)
					{
						num = Calling_WriteAddr_Single(abs_addr, value);
					}
					else
					{
						uint num3 = (1U << num2) - 1U << start_bit;
						uint num4;
						num = Calling_ReadAddr_Single(abs_addr, out num4);
						if (num == 0)
						{
							num4 = ((num4 & ~num3) | value << start_bit);
							num = Calling_WriteAddr_Single(abs_addr, num4);
						}
					}
				}
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.Error("WriteRegister: " + ex.Message, ex.StackTrace);
			}
			return num;
		}

		public int ReadByName(string path, out uint value)
		{
			value = 0U;
			bool flag;
			int type;
			uint address;
			int start_bit;
			int end_bit;
			if (!m_LuaWrapper.GetRegisterInfo(path, out flag, out type, out address, out start_bit, out end_bit))
			{
				m_GuiManager.LuaError(string.Format("Failed to get register info for path '{0}'", path));
				return -1;
			}
			return ReadRegister(type, address, start_bit, end_bit, out value);
		}

		public int ReadRegisterByName(string path, int start_bit, int end_bit, out uint value)
		{
			value = 0U;
			bool flag;
			int type;
			uint address;
			int num;
			int num2;
			if (!m_LuaWrapper.GetRegisterInfo(path, out flag, out type, out address, out num, out num2))
			{
				m_GuiManager.LuaError(string.Format("Failed to get register info for path '{0}'", path));
				return -1;
			}
			return ReadRegister(type, address, start_bit, end_bit, out value);
		}

		public int WriteByName(string path, uint value)
		{
			bool flag;
			int num;
			uint address;
			int start_bit;
			int end_bit;
			if (!m_LuaWrapper.GetRegisterInfo(path, out flag, out num, out address, out start_bit, out end_bit))
			{
				m_GuiManager.LuaError(string.Format("Failed to get register info for path '{0}'", path));
				return -1;
			}
			return WriteRegister(2, address, start_bit, end_bit, value);
		}

		public int WriteRegisterByName(string path, int start_bit, int end_bit, long value)
		{
			bool flag;
			int type;
			uint address;
			int num;
			int num2;
			if (!m_LuaWrapper.GetRegisterInfo(path, out flag, out type, out address, out num, out num2))
			{
				m_GuiManager.LuaError(string.Format("Failed to get register info for path '{0}'", path));
				return -1;
			}
			if (value < 0L)
			{
				value += 1L << (end_bit - start_bit + 1 & 31);
			}
			return WriteRegister(type, address, start_bit, end_bit, (uint)value);
		}

		[AttrLuaFunc("ReadBlock", "Read a block of registers", new string[]
		{
			"absolute address",
			"number of registers to read",
			"file name path",
			"append"
		})]
		public int ReadBlock(uint abs_addr, uint num_of_dwords, string filename, bool append)
		{
			int num = -1;
			string text = "";
			string[] array = null;
			string full_command = string.Format("ar1.ReadBlock(0x{0},{1},\"{2}\",{3})", new object[]
			{
				abs_addr.ToString("x"),
				num_of_dwords,
				filename,
				append.ToString().ToLower()
			});
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				num = m_SPWrapper.ReadBlock(abs_addr, num_of_dwords, out text);
				array = text.Split(new char[]
				{
					'\r'
				});
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.ErrorAbort(string.Format("Calling_ReadAddr_Multi exception: {0}. Check connection to device.", ex.Message));
			}
			if (num == 0)
			{
				TextWriter textWriter = null;
				try
				{
					textWriter = new StreamWriter(filename, append);
					for (int i = 0; i < array.Length - 1; i++)
					{
						textWriter.WriteLine(array[i].PadLeft(8, '0'));
					}
					if (textWriter != null)
					{
						textWriter.Close();
					}
					full_command = string.Format("ar1.ReadBlock of {0} words completed", array.Length - 1);
					m_GuiManager.RecordLog(0, full_command);
				}
				catch (Exception ex2)
				{
					num = -1;
					if (textWriter != null)
					{
						textWriter.Close();
					}
					GlobalRef.GuiManager.ErrorAbort(string.Format("ReadBlock exception: {0}.", ex2.Message));
				}
			}
			return num;
		}

		public int ReadBlockSeq(uint abs_addr, uint num_of_dwords, string seqAddress)
		{
			string text = "";
			try
			{
				m_SPWrapper.ReadBlock(abs_addr, num_of_dwords, out text);
				if (Array.IndexOf<string>(text.Split(new char[]
				{
					'\r'
				}), seqAddress) > -1)
				{
					return 1;
				}
				return 0;
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.ErrorAbort(string.Format("Calling_ReadAddr_Multi exception: {0}. Check connection to device.", ex.Message));
			}
			return 0;
		}

		public int ReadBlockOld(uint abs_addr, uint num_of_dwords, string filename, bool append)
		{
			int num = -1;
			string text = "";
			string full_command = string.Format("ar1.ReadBlock(0x{0},{1},\"{2}\",{3})", new object[]
			{
				abs_addr.ToString("x"),
				num_of_dwords,
				filename,
				append.ToString().ToLower()
			});
			m_GuiManager.RecordLog(0, full_command, false);
			try
			{
				num = m_SPWrapper.ReadBlock(abs_addr, num_of_dwords, out text);
				text.Split(new char[]
				{
					'\r'
				});
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.ErrorAbort(string.Format("Calling_ReadAddr_Multi exception: {0}. Check connection to device.", ex.Message));
			}
			if (num == 0)
			{
				TextWriter textWriter = null;
				try
				{
					textWriter = new StreamWriter(filename, append);
					textWriter.Write(text);
					if (textWriter != null)
					{
						textWriter.Close();
					}
				}
				catch (Exception ex2)
				{
					num = -1;
					if (textWriter != null)
					{
						textWriter.Close();
					}
					GlobalRef.GuiManager.ErrorAbort(string.Format("ReadBlockOld exception: {0}.", ex2.Message));
				}
			}
			return num;
		}

		[AttrLuaFunc("WriteBlock", "Write a block of registers", new string[]
		{
			"absolute address",
			"number of registers to write",
			"file name path"
		})]
		public int WriteBlock(uint abs_addr, uint num_of_dwords, string filename)
		{
			int result = 0;
			string[] array = new string[0];
			string full_command = string.Format("ar1.WriteBlock(0x{0},{1},\"{2}\")", abs_addr.ToString("x"), num_of_dwords, filename);
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				if (!File.Exists(filename))
				{
					return result;
				}
				array = File.ReadAllLines(filename);
				int num = array.Length;
				if ((ulong)num_of_dwords > (ulong)((long)num))
				{
					string full_command2 = string.Format("WARNING !!! Please provide the NUM_OF_DWORDS should be less than or equal to FILE SIZE", new object[0]);
					m_GuiManager.RecordLog(0, full_command2);
					string full_command3 = string.Format("NUM_OF_DWORDS:({0})", num_of_dwords);
					m_GuiManager.RecordLog(0, full_command3);
					string full_command4 = string.Format("FILE SIZE:({0})", num);
					m_GuiManager.RecordLog(0, full_command4);
					return -1;
				}
				for (uint num2 = 0U; num2 < num_of_dwords; num2 += 1U)
				{
					uint values = Convert.ToUInt32(array[(int)num2], 16);
					m_SPWrapper.DSSWriteBlockForHexFormatIntData(abs_addr + num2 * 4U, values, 1U);
					Thread.Sleep(1);
				}
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.ErrorAbort(string.Format("WriteBlock exception: {0}.", ex.Message));
				result = -1;
				return result;
			}
			return result;
		}

		public int WriteBlockXForHexFormat(uint abs_addr, uint num_of_dwords, string filename)
		{
			int result = 0;
			string[] array = new string[0];
			string full_command = string.Format("ar1.WriteBlockXForHexFormat(0x{0},{1},\"{2}\")", abs_addr.ToString("x"), num_of_dwords, filename);
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				if (!File.Exists(filename))
				{
					return result;
				}
				array = File.ReadAllLines(filename);
				for (uint num = 0U; num < num_of_dwords; num += 1U)
				{
					uint values = Convert.ToUInt32(array[(int)num].Remove(0, 5), 16);
					m_SPWrapper.DSSWriteBlockForHexFormatIntData(abs_addr + num * 4U, values, 1U);
					Thread.Sleep(1);
				}
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.ErrorAbort(string.Format("WriteBlock exception: {0}.", ex.Message));
				result = -1;
				return result;
			}
			return result;
		}

		public int WriteBlockDV(uint abs_addr, uint num_of_dwords, string filename)
		{
			int result = 0;
			string[] array = new string[0];
			string full_command = string.Format("ar1.WriteBlockDV(0x{0},{1},\"{2}\")", abs_addr.ToString("x"), num_of_dwords, filename);
			m_GuiManager.RecordLog(0, full_command);
			try
			{
				if (!File.Exists(filename))
				{
					return result;
				}
				array = File.ReadAllLines(filename);
				for (uint num = 0U; num < num_of_dwords; num += 1U)
				{
					uint values = Convert.ToUInt32(array[(int)num].Split(new char[]
					{
						'\t'
					})[1], 16);
					m_SPWrapper.DSSWriteBlockForHexFormatIntData(abs_addr + num * 4U, values, 1U);
					Thread.Sleep(1);
				}
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.ErrorAbort(string.Format("WriteBlock exception: {0}.", ex.Message));
				result = -1;
				return result;
			}
			return result;
		}

		[AttrLuaFunc("CaptureImport", "Imports Capture Setup JSON Configuration file", new string[]
		{
			"capturePath : absolute path of the input setup configuration file"
		})]
		public int CaptureImport(string capturePath)
		{
			return m_MainAR1frm.Import_Export.CaptureImport(capturePath);
		}

		[AttrLuaFunc("ConfigureSetup", "Configures the Capture Card and Setup fields")]
		public int ConfigureSetup()
		{
			GlobalRef.lua_method = 1;
			return m_GuiManager.ScriptOps.m0000a4();
		}

		[AttrLuaFunc("JsonImport", "Imports mmWave JSON Configuration file", new string[]
		{
			"jsonFilePath : absolute path of the input mmWave configuration file"
		})]
		public int JsonImport(string jsonFilePath)
		{
			return m_MainAR1frm.Import_Export.jsonImport(jsonFilePath);
		}

		[AttrLuaFunc("JsonLoad", "Populate Device configuration from JSON file to various tabs for device specified in argument", new string[]
		{
			"devId : the device ID for which the configration will be loaded"
		})]
		public int JsonLoad(int devId)
		{
			if (m_MainAR1frm.Import_Export.SetDeviceId(devId) == 0)
			{
				return m_GuiManager.ScriptOps.m0000a5(GlobalRef.jobject);
			}
			return -1;
		}

		[AttrLuaFunc("JsonExecute", "Configures a device with the Loaded configuration from JSON file ", new string[]
		{
			"devId : ID for the device to be configured"
		})]
		public int JsonExecute(int devId)
		{
			if (m_MainAR1frm.Import_Export.SetDeviceId(devId) == 0)
			{
				return m_GuiManager.ScriptOps.m0000a6(GlobalRef.jobject);
			}
			return -1;
		}

		[AttrLuaFunc("JsonExport", "Exports the configuration present in input mmWave configuration file and configuration corresponding to commands executed", new string[]
		{
			"jsonFilePath_Capture : absolute path of the output setup configuration file",
			"jsonFilePath_mmwave : absolute path of the output mmWave configuration file"
		})]
		public int JsonExport(string jsonFilePath_Capture, string jsonFilePath_mmwave)
		{
			GlobalRef.lua_method = 1;
			return m_MainAR1frm.Import_Export.jsonExport(jsonFilePath_Capture, jsonFilePath_mmwave);
		}

		private string StringToHex(string hexstring)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char value in hexstring)
			{
				stringBuilder.Append(Convert.ToInt32(value).ToString("x") + " ");
			}
			return stringBuilder.ToString();
		}

		public int ChannelTune(int band, int primary_chan_idx, int secondary_chan_idx, out int calib_res)
		{
			calib_res = -1;
			return m_GuiManager.ScriptOps.ChannelTune_Ext(band, primary_chan_idx, secondary_chan_idx, out calib_res);
		}

		public int CalibExecute()
		{
			return m_GuiManager.ScriptOps.Calibrate_Ext();
		}

		public int RunCalibration(string calib_name)
		{
			return m_GuiManager.ScriptOps.RunCalib_Ext(calib_name);
		}

		public int GoToElp()
		{
			return m_GuiManager.ScriptOps.GoToElp_Ext();
		}

		public int RxLowPowerMode(int rx_mode, out int calib_res)
		{
			calib_res = -1;
			return m_GuiManager.ScriptOps.RxLowPower_Ext(rx_mode, out calib_res);
		}

		public int RxBoost(int boost_mode, out int calib_res)
		{
			calib_res = -1;
			return m_GuiManager.ScriptOps.RxBoost_Ext(boost_mode, out calib_res);
		}

		public int TxStop()
		{
			return m_GuiManager.ScriptOps.StopTx_Ext();
		}

		public int SetOutputPower(int dbm, double target_power, int soc, int analog_setting, int ant_select, int channel_limits_disable, int fem_limits_disable, double post_dpd)
		{
			return m_GuiManager.ScriptOps.SetOutputPower_Ext(dbm, target_power, soc, analog_setting, ant_select, channel_limits_disable, fem_limits_disable, post_dpd);
		}

		public int StartTx(int packet_mode, int p1, int preamble, double delay, int amount, int size, int rate, int const_data, int p8, int stbc)
		{
			return m0000d0(packet_mode, p1, preamble, delay, amount, size, rate, const_data, p8, stbc, 0, 1, 7);
		}

		public int m0000d0(int packet_mode, int p1, int preamble, double delay, int amount, int size, int rate, int const_data, int p8, int stbc, int scramble, int inc_mode, int seed)
		{
			return m_GuiManager.ScriptOps.StartTxPacket_Ext(packet_mode, p1, preamble, delay, amount, size, rate, const_data, p8, stbc, scramble, inc_mode, seed);
		}

		public int TransmitSilence()
		{
			return m_GuiManager.ScriptOps.TransmitSilence_Ext();
		}

		public int TransmitCarrierFeedThrough()
		{
			return m_GuiManager.ScriptOps.TransmitCarrier_Ext();
		}

		public int TransmitSingleTone(int tone_idx)
		{
			return m_GuiManager.ScriptOps.TransmitSingleTone_Ex(tone_idx);
		}

		public void m0000d1(int enable)
		{
			m_GuiManager.ScriptOps.EnableDpd_Ext(enable);
		}

		public int RXStatsMode(int ack_en, int inc_mode, int rx_data)
		{
			return m_GuiManager.ScriptOps.StartRxStats_Ext(ack_en, inc_mode, rx_data);
		}

		public int rstRXStats()
		{
			return m_GuiManager.ScriptOps.RstRxStats_Ext();
		}

		public int stopRXStats()
		{
			return m_GuiManager.ScriptOps.StopRxStats_Ext();
		}

		public int getRXStats(int num_expected_packets)
		{
			int result = -1;
			object[] res_arr = m_GuiManager.p000002.Execute(GuiOp.GetRxStats, new object[]
			{
				num_expected_packets
			}, false);
			m_GuiManager.p000002.GetSingleIntRes(GuiOp.StopRxStats, res_arr, out result);
			return result;
		}

		public void SetKeyChangesLog(bool on_off)
		{
			m_GuiManager.LogLuaKeyChanges = on_off;
		}

		public bool m0000d2(string dll_path)
		{
			string full_command = string.Format("ar1.LoadTsDll(\"{0}\")", dll_path);
			m_GuiManager.RecordLog(0, full_command);
			if (string.IsNullOrEmpty(dll_path))
			{
				m_GuiManager.Warning("LoadTsDll: dll path provided is empty.");
				return false;
			}
			bool flag = Imports.ImportFunctions(dll_path);
			if (flag && GlobalRef.TsWrapper.IsGuiShown())
			{
				m_GuiManager.MainTsForm.ConnectTab.UpdateDllVersion();
				m_GuiManager.MainTsForm.ConnectTab.SetDllInCombo(dll_path);
			}
			return flag;
		}

		public bool LoadRadarDll(string dll_path)
		{
			string full_command = string.Format("ar1.LoadTsDll(\"{0}\")", dll_path);
			m_GuiManager.RecordLog(0, full_command);
			if (string.IsNullOrEmpty(dll_path))
			{
				m_GuiManager.Warning("LoadTsDll: dll path provided is empty.");
				return false;
			}
			bool flag = Imports.ImportFunctions(dll_path);
			if (flag && GlobalRef.TsWrapper.IsGuiShown())
			{
				m_GuiManager.MainTsForm.ConnectTab.UpdateDllVersion();
				m_GuiManager.MainTsForm.ConnectTab.SetDllInCombo(dll_path);
			}
			return flag;
		}

		public string SetNvsFile(string nvs_path)
		{
			string full_command = string.Format("ar1.SetNvsFile(\"{0}\")", nvs_path);
			m_GuiManager.RecordLog(0, full_command);
			if (string.IsNullOrEmpty(nvs_path))
			{
				m_GuiManager.Warning("SetNvsFile: dll path provided is empty.");
				return "";
			}
			return Imports.f0002aa(nvs_path);
		}

		[AttrLuaFunc("UnLoadTsDll", "Unload the Trioscope DLL from memory")]
		public bool m0000d3()
		{
			string full_command = "ar1.UnLoadTsDll()";
			m_GuiManager.RecordLog(0, full_command);
			return true;
		}

		public void SetTsApiMode(bool enable)
		{
			m_GuiManager.MainTsForm.ConnectTab.SetTsApiModeExt(enable);
		}

		public void SetPhySA(bool enable)
		{
			m_GuiManager.MainTsForm.ConnectTab.SetPhyStandAloneExt(enable);
		}

		public bool UpdateIni(string ini_path)
		{
			string full_command = string.Format("ar1.UpdateIni(\"{0}\")", ini_path);
			m_GuiManager.RecordLog(102, full_command);
			return m_GuiManager.MainTsForm.ConnectTab.UpdateTsIni(ini_path);
		}

		public void UpdateLuaFromGui()
		{
			if (!IsGuiShown())
			{
				m_GuiManager.Warning("UpdateLuaFromGui: Ignored. No GUI is displayed");
				return;
			}
			m_GuiManager.MainTsForm.UpdateLuaKeys();
		}

		public LuaTable GetIniParams(string ini_path)
		{
			AR1IniHandler ar1IniHandler = new AR1IniHandler(ini_path);
			LuaTable result = null;
			if (ar1IniHandler.ReadIniFile())
			{
				result = ar1IniHandler.CreateLuaIniTable();
			}
			return result;
		}

		public LuaTable GetBoardInfo()
		{
			m_GuiManager.MainTsForm.ConnectTab.GetBoardInfo();
			return GuiManager.GetBoardInfoAsLuaTable();
		}

		public bool IsDelivery()
		{
			return true;
		}

		public void DisableOvUvCheck()
		{
			m_GuiManager.MainTsForm.ConnectTab.SetOvUvTimer(false);
			m_GuiManager.OvUvCheckEnabled = false;
		}

		public void EnableOvUvCheck()
		{
			m_GuiManager.OvUvCheckEnabled = true;
			m_GuiManager.MainTsForm.ConnectTab.SetOvUvTimer(true);
		}

		public void DisableLDOCheck()
		{
			m_GuiManager.EnableLDOCheck = false;
		}

		public void EnableLDOCheck()
		{
			m_GuiManager.EnableLDOCheck = true;
		}

		private bool iGetRegTypeFromString(string type, out RegType reg_type)
		{
			type = type.ToLower();
			if (type == "top")
			{
				reg_type = RegType.REG_TYPE_WLAN_TOP;
			}
			else if (type == "phy")
			{
				reg_type = RegType.REG_TYPE_WLAN_PHY;
			}
			else
			{
				if (!(type == "mac"))
				{
					m_GuiManager.Error(string.Format("ReadRegister: Invalid type '{0}'", type));
					reg_type = RegType.REG_TYPE_UNKNOWN;
					return false;
				}
				reg_type = RegType.REG_TYPE_WLAN_MAC;
			}
			return true;
		}

		private uint iGetAbsAddress(uint rel_address, RegType reg_type)
		{
			return rel_address;
		}

		private void iGetRegValue(XmlNode reg_node, out uint reg_val, out uint mask)
		{
			int num = int.Parse(reg_node.Attributes["n_bits"].Value);
			reg_val = 0U;
			mask = 0U;
			if (reg_node.FirstChild.Name == "#text")
			{
				reg_val = uint.Parse(reg_node.FirstChild.Value);
				mask = (1U << num) - 1U;
				return;
			}
			foreach (object obj in reg_node.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				int num2 = int.Parse(xmlNode.ChildNodes[1].Attributes["start_bit"].Value);
				int num3 = int.Parse(xmlNode.ChildNodes[1].Attributes["n_bits"].Value);
				int num4 = int.Parse(xmlNode.FirstChild.Value);
				if (num4 < 0)
				{
					num4 += (int)Math.Pow(2.0, (double)num3);
				}
				uint num5 = (uint)num4;
				reg_val |= num5 << num2;
				mask |= (1U << num3) - 1U << num2;
			}
		}

		private void iUpdateFieldsValue(XmlNode reg_node, uint reg_val)
		{
			int.Parse(reg_node.Attributes["n_bits"].Value);
			long num = 1L;
			foreach (object obj in reg_node.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				int num2 = int.Parse(xmlNode.ChildNodes[1].Attributes["start_bit"].Value);
				int num3 = int.Parse(xmlNode.ChildNodes[1].Attributes["n_bits"].Value);
				uint num4 = (uint)((num << num3) - 1L);
				xmlNode.FirstChild.Value = (reg_val >> num2 & num4).ToString();
			}
		}

		private string iGetRecordLogMsg(int type, uint address, int start_bit, int end_bit)
		{
			string arg;
			if (type == 4)
			{
				arg = "rtb";
			}
			else if (type == 1)
			{
				arg = "rpb";
			}
			else if (type == 2)
			{
				arg = "rmb";
			}
			else if (type == 5)
			{
				arg = "rab";
			}
			else if (type == 6)
			{
				arg = "rnmb";
			}
			else
			{
				arg = "UnknowType";
			}
			string arg2 = string.Format("\"{0}:{1}\"", end_bit, start_bit);
			string arg3 = "0x" + address.ToString("x");
			return string.Format("{0}({1},{2})", arg, arg3, arg2);
		}

		private string iGetRecordLogMsg(int type, uint address, int start_bit, int end_bit, uint value)
		{
			string text;
			if (type == 4)
			{
				text = "wtb";
			}
			else if (type == 1)
			{
				text = "wpb";
			}
			else if (type == 2)
			{
				text = "wmb";
			}
			else if (type == 5)
			{
				text = "wab";
			}
			else if (type == 6)
			{
				text = "wnmb";
			}
			else
			{
				text = "UnknowType";
			}
			string text2 = string.Format("\"{0}:{1}\"", end_bit, start_bit);
			string text3 = "0x" + address.ToString("x");
			return string.Format("{0}({1},{2},0x{3})", new object[]
			{
				text,
				text3,
				text2,
				value.ToString("x")
			});
		}

		public bool IsGuiShown()
		{
			return m_MainAR1frm != null && m_MainAR1frm.IsHandleCreated && m_MainAR1frm.Visible;
		}

		public void Transmit(XmlNode xml_tree)
		{
			if (!NoLog_Calling_IsConnected())
			{
				m_GuiManager.ErrorAbort("Transmit of register(s) failed: Target is disconnected");
				return;
			}
			try
			{
				foreach (object obj in ((XmlElement)xml_tree).GetElementsByTagName("Register"))
				{
					XmlNode xmlNode = (XmlNode)obj;
					string value = xmlNode.Attributes["name"].Value;
					int num = int.Parse(xmlNode.Attributes["reg_type"].Value);
					if (xmlNode.ParentNode.Attributes["name"].Value.ToLower().Contains("_actl"))
					{
						num = 7;
					}
					int num2 = int.Parse(xmlNode.Attributes["n_bits"].Value);
					uint num3 = uint.Parse(xmlNode.Attributes["address"].Value, NumberStyles.HexNumber);
					uint abs_addr = iGetAbsAddress(num3, (RegType)num);
					uint num4;
					uint num5;
					iGetRegValue(xmlNode, out num4, out num5);
					if ((ulong)num5 == (ulong)((long)((1 << num2) - 1)))
					{
						if (num == 4 || num == 7)
						{
							WriteRegister(num, num3, 0, 31, num4);
						}
						else
						{
							Calling_WriteAddr_Single(abs_addr, num4);
						}
					}
					else if (num == 4 || num == 7)
					{
						iWriteTopFields(xmlNode, num3, num);
					}
					else
					{
						uint num6;
						Calling_ReadAddr_Single(abs_addr, out num6);
						num4 = ((num6 & ~num5) | num4);
						Calling_WriteAddr_Single(abs_addr, num4);
					}
				}
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.ErrorAbort(ex.Message);
			}
		}

		private void iWriteTopFields(XmlNode reg_node, uint reg_address, int reg_type)
		{
			foreach (object obj in reg_node.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				int num = int.Parse(xmlNode.ChildNodes[1].Attributes["start_bit"].Value);
				int num2 = int.Parse(xmlNode.ChildNodes[1].Attributes["n_bits"].Value);
				uint value = uint.Parse(xmlNode.FirstChild.Value);
				int end_bit = num + num2 - 1;
				WriteRegister(reg_type, reg_address, num, end_bit, value);
			}
		}

		public void Receive(ref XmlNode xml_tree)
		{
			if (!NoLog_Calling_IsConnected())
			{
				m_GuiManager.ErrorAbort("Receive of register(s) failed: Target is disconnected");
				return;
			}
			try
			{
				foreach (object obj in ((XmlElement)xml_tree).GetElementsByTagName("Register"))
				{
					XmlNode xmlNode = (XmlNode)obj;
					string value = xmlNode.Attributes["name"].Value;
					int num = int.Parse(xmlNode.Attributes["reg_type"].Value);
					if (xmlNode.ParentNode.Attributes["name"].Value.ToLower().Contains("_actl"))
					{
						num = 7;
					}
					int.Parse(xmlNode.Attributes["n_bits"].Value);
					uint num2 = uint.Parse(xmlNode.Attributes["address"].Value, NumberStyles.HexNumber);
					uint abs_addr = iGetAbsAddress(num2, (RegType)num);
					uint reg_val;
					if (num == 4 || num == 7)
					{
						ReadRegister(num, num2, 0, 31, out reg_val);
					}
					else
					{
						Calling_ReadAddr_Single(abs_addr, out reg_val);
					}
					if (xmlNode.FirstChild.Name == "#text")
					{
						xmlNode.FirstChild.Value = reg_val.ToString();
					}
					else
					{
						iUpdateFieldsValue(xmlNode, reg_val);
					}
				}
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.ErrorAbort(ex.Message);
			}
		}

		public bool NoLog_Calling_IsConnected()
		{
			bool result = false;
			try
			{
				result = m_SPWrapper.IsConnected();
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.Error("Calling_IsConnected: " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		public int NoLog_Calling_ATE_DisconnectTarget()
		{
			int result = -1;
			try
			{
				result = Imports.Calling_ATE_DisconnectTarget();
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.Error("Calling_ATE_DisconnectTarget " + ex.Message, ex.StackTrace);
			}
			return result;
		}

		private const ushort poly = 4129;

		private ushort[] table = new ushort[256];

		private ushort initialValue = ushort.MaxValue;

		private const int PHY_ADDRESS_BASE = 0;

		private const int TOP_ADDRESS_BASE = 0;

		public const int NUMBER_OF_CALIBRATIONS_E = 30;

		private LuaWrapper m_LuaWrapper;

		private frmAR1Main m_MainAR1frm;

		private GuiManager m_GuiManager;

		private SerialPortWrapper m_SPWrapper;

		public enum InitialCrcValue
		{
			Zeros,
			NonZero1 = 65535,
			NonZero2 = 7439
		}

		public struct TTestCmdDebug
		{
			public byte iPowerMode;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			public byte[] padding;
		}
	}
}
