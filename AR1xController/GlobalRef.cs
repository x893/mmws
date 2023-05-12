using System;
using System.Diagnostics;
using System.Reflection;
using LuaRegister;

namespace AR1xController
{
	internal static class GlobalRef
	{
		public static c000169 DllController
		{
			get
			{
				return GlobalRef.m_DllController;
			}
			set
			{
				GlobalRef.m_DllController = value;
			}
		}

		public static AR1xxxWrapper TsWrapper
		{
			get
			{
				return GlobalRef.m_AR1Wrapper;
			}
			set
			{
				GlobalRef.m_AR1Wrapper = value;
			}
		}

		public static LuaWrapper LuaWrapper
		{
			get
			{
				return GlobalRef.m_LuaWrapper;
			}
			set
			{
				GlobalRef.m_LuaWrapper = value;
			}
		}

		public static GuiManager GuiManager
		{
			get
			{
				return GlobalRef.m_GuiManager;
			}
			set
			{
				GlobalRef.m_GuiManager = value;
			}
		}

		public static ProfManager ProfManager
		{
			get
			{
				return GlobalRef.m_ProfManager;
			}
			set
			{
				GlobalRef.m_ProfManager = value;
			}
		}

		public static PerChirpManager PerChirpManager
		{
			get
			{
				return GlobalRef.m_PerChirpManager;
			}
			set
			{
				GlobalRef.m_PerChirpManager = value;
			}
		}

		public static BPMChirpManager BPMChirpManager
		{
			get
			{
				return GlobalRef.m_BPMChirpManager;
			}
			set
			{
				GlobalRef.m_BPMChirpManager = value;
			}
		}

		public static RFDataCaptureCard RFDataCaptureCard
		{
			get
			{
				return GlobalRef.m_RFDataCaptureCard;
			}
			set
			{
				GlobalRef.m_RFDataCaptureCard = value;
			}
		}

		public static TDAxxCaptureCard TDAxxCaptureCard
		{
			get
			{
				return GlobalRef.m_TDAxxCaptureCard;
			}
			set
			{
				GlobalRef.m_TDAxxCaptureCard = value;
			}
		}

		public static AR1xxxExtOpps AR1xxxExtOpps
		{
			get
			{
				return GlobalRef.m_AR1xxxExtOpps;
			}
			set
			{
				GlobalRef.m_AR1xxxExtOpps = value;
			}
		}

		public static string GuiVersion
		{
			get
			{
				return GlobalRef.m_GuiVersion;
			}
			set
			{
				GlobalRef.m_GuiVersion = value;
			}
		}

		public static string AppTitle = "RadarAPI";

		public static double Dummy = 0.0;

		private static c000169 m_DllController;

		private static AR1xxxWrapper m_AR1Wrapper;

		private static LuaWrapper m_LuaWrapper;

		private static GuiManager m_GuiManager;

		private static ProfManager m_ProfManager;

		private static PerChirpManager m_PerChirpManager;

		private static BPMChirpManager m_BPMChirpManager;

		private static RFDataCaptureCard m_RFDataCaptureCard;

		private static TDAxxCaptureCard m_TDAxxCaptureCard;

		private static AR1xxxExtOpps m_AR1xxxExtOpps;

		public static string m_GuiVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

		public static volatile RootObject jobject;

		public static volatile SetupObject dobject;

		public static volatile int lua_method = 0;

		public static volatile int f0002c5 = 0;

		public static volatile bool jsonExecution = false;

		public static volatile int m_FwDownloadProgress = 1;

		public static volatile string g_winSCPfilename = "";

		public static volatile string g_winSCPprogress = "0";

		public static volatile string g_winSCPtransferSpeed = "0";

		public static volatile bool g_DisableReportLogging = false;

		public static volatile bool g_BSSFwDl = false;

		public static volatile bool g_MSSFwDl = false;

		public static volatile bool g_DSPFwDl = false;

		public static volatile bool[] g_SpiConnect = new bool[4];

		public static volatile bool[] g_RS232Connect = new bool[4];

		public static volatile bool[] g_NtvRS232Connect = new bool[4];

		public static volatile uint g_CasCadeDeviceSpiConnect = 0U;

		public static volatile uint g_SensorStartStopController = 0U;

		public static volatile int[] g_RS232BaudRate = new int[4];

		public static volatile int[] g_RS232ComPort = new int[4];

		public static volatile short[] CoeffRAM = new short[104];

		public static volatile bool DCEventReg = true;

		public static volatile uint[] CalibData_chunkID_0 = new uint[171];

		public static volatile uint[] CalibData_chunkID_1 = new uint[56];

		public static volatile uint[] CalibData_chunkID_2 = new uint[56];

		public static volatile ushort[] PhaseShitCalibData = new ushort[201];

		public static volatile uint[] Width_TDA = new uint[4];

		public static volatile uint[] Height_TDA = new uint[4];

		public static volatile uint framePeriodicity_TDA = 0U;

		public static volatile uint g_numFilesAllocated = 0U;

		public static volatile uint g_numFramesToCapture = 0U;

		public static volatile uint g_enablePackaging = 0U;

		public static volatile uint f0002c6 = 0U;

		public static volatile uint f0002c7 = 0U;

		public static volatile uint f0002c8 = 0U;

		public static volatile uint f0002c9 = 0U;

		public static volatile uint f0002ca = 0U;

		public static volatile uint f0002cb = 0U;

		public static volatile uint f0002cc = 0U;

		public static volatile uint f0002cd = 0U;

		public static volatile uint f0002ce = 0U;

		public static volatile uint g_PostProcType = 0U;

		public static volatile uint[] numZeroFillBytes = new uint[50];

		public static volatile string f0002cf = string.Empty;

		public static volatile string g_TDAVersion = "-";

		public static volatile uint g_TDADeviceMap = 0U;

		public static volatile string g_TDACaptureDirectory = string.Empty;

		public static volatile uint g_numCaptureDirectoryFiles = 0U;

		public static volatile uint g_numCaptureFilesTransferred = 0U;

		public static volatile bool g_RFDataCaptureMode = false;

		public static volatile bool g_TDADataCaptureMode = false;

		public static volatile bool g_DCA1000Control = false;

		public static volatile bool f0002d0 = false;

		public static volatile bool g_CapturePktSequenceEnaDisable = false;

		public static volatile bool g_CaptureStartStopStatus = false;

		public static volatile bool g_ContStreamCaptureStartStopStatus = false;

		public static volatile uint g_CaptureCardStopCtl = 0U;

		public static volatile bool g_OpnBrdCtrl = false;

		public static volatile bool g_OpnGpioCtrl = false;

		public static volatile bool g_FrameTriggered = false;

		public static volatile bool[] g_FrameTriggered_Cascade = new bool[4];

		public static volatile int g_FrameTriggeredDevMap = 0;

		public static volatile bool g_StopCmdInProgress = false;

		public static volatile bool f0002d1 = false;

		public static volatile bool g_RealTimeTrigVar = false;

		public static volatile bool g_BpmCmnConfig = false;

		public static volatile bool g_StudioInit = true;

		public static volatile bool g_StudioInit1 = true;

		public static volatile bool g_StudioInit2 = true;

		public static volatile bool g_2ChipCascade = false;

		public static volatile bool g_4ChipCascade = false;

		public static volatile bool f0002d2 = false;

		public static volatile bool[] g_TDAsetWidthHeightDone = new bool[4];

		public static volatile bool g_AR12xxDevice = false;

		public static volatile bool g_AR14xxDevice = false;

		public static volatile bool g_AR16xxDevice = false;

		public static volatile bool g_AR6843Device = false;

		public static volatile bool g_AR1843Device = false;

		public static volatile bool g_AR2243Device = false;

		public static volatile bool g_ARDeviceOperateFreq60GHz = false;

		public static volatile bool g_LegacyFrame = false;

		public static volatile bool g_AdvancedFrame = false;

		public static volatile bool g_AdvancedNumFrameHandle = false;

		public static volatile uint g_RadarDeviceId = 0U;

		public static volatile uint g_RadarDeviceIndex = 0U;

		public static volatile uint g_SOPMode4Set = 0U;

		public static volatile uint g_SOPMode7Set = 0U;

		public static volatile uint g_RS232DeviceController = 0U;

		public static volatile uint g_NumOfRadarDevicesDetected = 0U;

		public static volatile uint g_TestSource = 0U;

		public static volatile uint g_ProfileProgFilterEnaDisable = 0U;

		public static volatile uint g_BSSFwDownloadStatus = 0U;

		public static volatile uint g_MSSFwDownloadStatus = 0U;

		public static volatile uint g_TXPowerStatus = 0U;

		public static volatile uint g_PDPowerStatus = 0U;

		public static volatile uint g_RunTimeCalibStatus = 0U;

		public static volatile uint g_I2COpenCloseHandler = 0U;

		public static volatile uint g_RFInitStatus = 0U;

		public static volatile bool g_RadarDev_60HzEnaDis = false;

		public static volatile string f0002d3 = string.Empty;

		public static volatile bool g_CaptureCardConnectStatue = false;

		public static volatile bool g_TDACaptureCardConnectStatus = false;

		public static volatile bool g_2243MetaImageDwld = false;

		public static volatile bool g_2243SwapReset = true;

		public static volatile uint g_Tx1PowerMon = 0U;

		public static volatile uint g_Tx2PowerMon = 0U;

		public static volatile uint g_Tx3PowerMon = 0U;

		public static volatile uint g_Tx1BallBreakMon = 0U;

		public static volatile uint g_Tx2BallBreakMon = 0U;

		public static volatile uint g_Tx3BallBreakMon = 0U;

		public static volatile uint g_RxGainAndPhaseMon = 0U;

		public static volatile uint g_RxNoiseFigureMon = 0U;

		public static volatile uint g_RxIFStageMon = 0U;

		public static volatile uint g_RxMixPowerMon = 0U;

		public static volatile uint g_Tx1BPMPhaseMon = 0U;

		public static volatile uint g_Tx2BPMPhaseMon = 0U;

		public static volatile uint g_Tx3BPMPhaseMon = 0U;

		public static volatile uint g_TxGainPhaseMismatchMon = 0U;

		public static volatile uint g_SynthFreqErrMon = 0U;

		public static volatile uint g_PLLCtlVolSigMon = 0U;

		public static volatile uint g_DCCMon = 0U;

		public static volatile uint g_InternalTx1AnaSigMon = 0U;

		public static volatile uint g_InternalTx2AnaSigMon = 0U;

		public static volatile uint g_InternalTx3AnaSigMon = 0U;

		public static volatile uint g_InternalRxAnaSigMon = 0U;

		public static volatile uint g_InternalPmClkLoAnaSigMon = 0U;

		public static volatile uint f0002d4 = 0U;

		public static volatile uint g_TemperatureMon = 0U;

		public static volatile uint g_ExternalAnaSigMon = 0U;

		public static volatile uint g_MSSLatentFaultMon = 0U;

		public static volatile uint g_MSSPeriodicTestMon = 0U;

		public static volatile byte g_DigPeriodicStatus = 0;

		public static volatile byte g_DigLatentFaultStatus = 0;

		public static volatile Process g_processLua;

		public static bool CustomerVersion = true;
	}
}
