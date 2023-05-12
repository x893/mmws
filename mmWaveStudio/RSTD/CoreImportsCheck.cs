using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace RSTD
{
	public static class CoreImportsCheck
	{

		[DllImport("kernel32.dll")]
		private static extern int LoadLibrary(string librayName);

		[DllImport("kernel32.dll")]
		private static extern int GetProcAddress(int hwnd, string procedureName);

		public static ArrayList CheckImportedProcs()
		{
			int hwnd = CoreImportsCheck.LoadLibrary("rttt_core.dll");
			string[] array = new string[]
			{
				"RtttCore_Init",
				"RtttCore_Close",
				"bConfigSettings",
				"bRtttCore_Build",
				"RtttCore_UnBuild",
				"RtttCore_Go",
				"RtttCore_Stop",
				"bHasStopped",
				"Transmit",
				"Receive",
				"RtttCore_ReceiveVar",
				"ReceiveVarStr",
				"LoadVar",
				"MonitorSetVars",
				"MonitorStart",
				"MonitorStop",
				"MonitorFlush",
				"RunFunction",
				"SetWorkingDirectories",
				"GetOutputDirectoryPath",
				"GetPrintLevel",
				"GetBitPattern",
				"GetFixedValue",
				"GetQNotationBits",
				"bAL_Build",
				"AL_Init",
				"AL_UnBuild",
				"Clients_Init",
				"AL_Reset",
				"Clients_Reset",
				"AL_GetStatus"
			};
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < array.Length; i++)
			{
				if (CoreImportsCheck.GetProcAddress(hwnd, array[i]) == 0)
				{
					arrayList.Add(array[i]);
				}
			}
			return arrayList;
		}
	}
}
