using System;
using System.Diagnostics;

namespace RSTD
{

	public class Utils
	{

		[Conditional("DEBUG")]
		public static void Unreferenced(params object[] o)
		{
		}
	}
}
