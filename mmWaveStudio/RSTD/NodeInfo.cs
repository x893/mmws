using System;
using System.Runtime.InteropServices;

namespace RSTD
{

	public struct NodeInfo
	{

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string path;


		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string value;
	}
}
