using System;
using System.Runtime.InteropServices;

namespace RSTD
{


	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UnManagedConsolePrintDel(uint print_level, uint text_color, string text);
}
