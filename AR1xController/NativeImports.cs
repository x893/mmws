using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AR1xController
{
	public class NativeImports
	{
		[DllImport("user32.dll")]
		public static extern IntPtr GetFocus();

		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string dllToLoad);

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

		[DllImport("kernel32.dll")]
		public static extern bool FreeLibrary(IntPtr hModule);

		[DllImport("ole32.dll")]
		public static extern void CoFreeUnusedLibraries();

		[DllImport("Shlwapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern uint AssocQueryString(AssocF flags, AssocStr str, string pszAssoc, string pszExtra, [Out] StringBuilder pszOut, [In] [Out] ref uint pcchOut);
	}
}
