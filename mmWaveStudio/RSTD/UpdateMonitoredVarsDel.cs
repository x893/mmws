using System;
using System.Runtime.InteropServices;

namespace RSTD
{


	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UpdateMonitoredVarsDel(IntPtr nodes_info, uint count);
}
