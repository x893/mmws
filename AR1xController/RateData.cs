using System;

namespace AR1xController
{
	public class RateData
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

		public RateGroup Group
		{
			get
			{
				return this.m_Group;
			}
			set
			{
				this.m_Group = value;
			}
		}

		public int ID
		{
			get
			{
				return this.m_Id;
			}
			set
			{
				this.m_Id = value;
			}
		}

		public RateData(string name, int value, RateGroup group, int p3)
		{
			this.m_Name = name;
			this.m_Value = value;
			this.m_Group = group;
			this.m_Id = p3;
		}

		private string m_Name;

		private RateGroup m_Group;

		private int m_Value;

		private int m_Id;
	}
}
