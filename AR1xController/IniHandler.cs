using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AR1xController
{
	public class IniHandler
	{
		public string FilePath
		{
			get
			{
				return this.m_FilePath;
			}
			set
			{
				this.m_FilePath = value;
			}
		}

		public IniHandler(string ini_path)
		{
			this.m_FilePath = ini_path;
		}

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string file_path);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def_val, StringBuilder ret_val, int size, string file_path);

		public void WriteValue(string section, string key, string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				IniHandler.WritePrivateProfileString(section, key, value, this.m_FilePath);
			}
		}

		public string ReadValue(string section, string key, string def)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			IniHandler.GetPrivateProfileString(section, key, def, stringBuilder, 255, this.m_FilePath);
			return stringBuilder.ToString();
		}

		public string m_FilePath;
	}
}
