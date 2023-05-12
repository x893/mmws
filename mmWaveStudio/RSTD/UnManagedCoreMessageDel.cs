using System;
using System.Runtime.InteropServices;

namespace RSTD
{


	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UnManagedCoreMessageDel(string msg);
}
