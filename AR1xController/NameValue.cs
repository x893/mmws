using System;

namespace AR1xController
{
	public class NameValue
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

		public int Value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = value;
			}
		}

		public NameValue(string name, int value)
		{
			this.m_Name = name;
			this.m_Value = value;
		}

		private string m_Name;

		private int m_Value;
	}
}
