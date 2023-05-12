using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace RSTD
{
	public class CoreImports
	{
		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void RtttCore_Init(CoreImports.RtttExecutionContext_T rttt_execution_context, CoreImports.ClientCmdParams_T pCmdLine, UnManagedConsolePrintDel pPrintFunc, UnManagedCoreMessageDel pCoreMsg, StringBuilder pXmlTree, UnManagedCoreMessageBoxDel pCoreMsgBox, UpdateMonitoredVarsDel pUpdateMonitorsDisplay);

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void RtttCore_Close();

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool bConfigSettings();

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool bRtttCore_Build(StringBuilder pXmlTree, StringBuilder pClocksList);

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint RtttCore_UnBuild();

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void RtttCore_Go();

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void RtttCore_Stop();

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void RtttCore_Abort();

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool bHasStopped();

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Transmit(string pTreeMemMap);

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Receive(StringBuilder pTreeMemMap);

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool RtttCore_ReceiveVar(string path, out IntPtr value);

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ReceiveVarStr(string path, StringBuilder ActualSize);

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void LoadVar(string pVarFullPath, string pFileName);

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void MonitorSetVars(string pSettingsFile);

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void MonitorStart(string pOutFileName);

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void MonitorStop();

		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void MonitorFlush();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I4)]
		public static extern int RunFunction(string pFuncCall, StringBuilder pReturnStr);


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetWorkingDirectories(string input, string output, string config);


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr GetOutputDirectoryPath();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint GetPrintLevel();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GetBitPattern(double value, string q_notation, out double q_value, out long bit_pattern);


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GetFixedValue(long bit_pattern, string q_notation, out double value, out double q_value);


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void GetQNotationBits(string q_notation, ref int qi, ref int qf);


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool bAL_Build(StringBuilder pXmlTree);


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void AL_Init();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Clients_Init();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void AL_Reset();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Clients_Reset();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint AL_UnBuild();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool bExposeLoadedXml(StringBuilder pXmlTree);


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DisposeLoadedXml();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void TabStart(string TabName);


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void TabEnd();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void FolderStart(string FolderName);


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void FolderEnd();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void RegisterStart(string pDescription, IntPtr pAddress, string register_address, int register_type, int n_bits, uint default_val, string description, int export_mode);


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void RegisterEnd();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void AddHwRegisterField(string field_name, string description, string register_name, string register_address, int register_type, int start_bit, int n_bits, string type, string q_notation, long default_val, int export_mode);


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool AL_GetStatus();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint GetALTabs();


		[DllImport("rttt_core.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint GetClientTabs();


		[DllImport("kernel32.dll")]
		public static extern int IsDebuggerPresent();


		[DllImport("user32.dll", EntryPoint = "SendMessageW", SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, IntPtr lParam);


		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);


		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);


		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowPlacement(IntPtr hWnd, ref CoreImports.WindowPlacement lpwndpl);


		[DllImport("user32.dll")]
		public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);


		[DllImport("user32")]
		public static extern bool IsIconic(IntPtr hwnd);


		public const uint SW_HIDE = 0U;


		public const uint SW_NORMAL = 1U;


		public const int SW_SHOWNORMAL = 1;


		public const int SW_SHOWMINIMIZED = 2;


		public const int SW_SHOWMAXIMIZED = 3;


		public const uint SW_MAXIMIZE = 3U;


		public const uint SW_SHOWNOACTIVATE = 4U;


		public const uint SW_SHOW = 5U;


		public const uint SW_MINIMIZE = 6U;


		public const uint SW_SHOWMINNOACTIVE = 7U;


		public const uint SW_SHOWNA = 8U;


		public const uint SW_RESTORE = 9U;


		public const int WM_COPYDATA = 74;


		public const int WM_USER = 1024;


		public const int WM_VSCROLL = 277;


		public const int SB_BOTTOM = 7;


		public enum RtttExecutionContext_T
		{
	
			RTTT_CONTEXT__MASTER_SLAVE,
	
			RTTT_CONTEXT__MASTER,
	
			RTTT_CONTEXT__SLAVE_FULL_CMD,
	
			RTTT_CONTEXT__SLAVE_PARTIAL_CMD
		}


		public struct ClientCmdParams_T
		{
	
			[MarshalAs(UnmanagedType.U4)]
			public uint DataVersion;

	
			[MarshalAs(UnmanagedType.U4)]
			public uint DataLength;

	
			public IntPtr Data;
		}


		public struct WindowPlacement
		{
	
			public int length;
			public int flags;
			public int showCmd;
			public Point ptMinPosition;
			public Point ptMaxPosition;
			public Rectangle rcNormalPosition;
		}


		public struct CopyDataStruct
		{
			public int ID;
			public int Length;
			public string Data;
		}
	}
}
