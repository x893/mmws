using System;
using System.Runtime.InteropServices;

namespace RSTD
{


	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate uint UnManagedCoreMessageBoxDel(uint msg_type, string msg);
}
