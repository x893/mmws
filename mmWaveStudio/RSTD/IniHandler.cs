using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RSTD
{

	public static class IniHandler
	{



		public static string FilePath
		{
			get
			{
				return IniHandler.m_FilePath;
			}
			set
			{
				IniHandler.m_FilePath = value;
			}
		}


		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string file_path);


		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def_val, StringBuilder ret_val, int size, string file_path);


		public static void WriteValue(string section, string key, string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				IniHandler.WritePrivateProfileString(section, key, value, IniHandler.m_FilePath);
			}
		}


		public static string ReadValue(string section, string key, string def)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			IniHandler.GetPrivateProfileString(section, key, def, stringBuilder, 255, IniHandler.m_FilePath);
			return stringBuilder.ToString();
		}


		public static string m_FilePath;
	}
}
