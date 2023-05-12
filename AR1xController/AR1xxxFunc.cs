using System;

namespace AR1xController
{
	public class AR1xxxFunc
	{
		public string Name
		{
			get
			{
				return this.m_Name;
			}
			set
			{
				this.m_Name = value;
			}
		}

		public string Format
		{
			get
			{
				return this.m_Format;
			}
			set
			{
				this.m_Format = value;
			}
		}

		public AR1xxxFunc(string name, string format)
		{
			this.m_Name = name;
			this.m_Format = format;
		}

		private string m_Name;

		private string m_Format;
	}
}
