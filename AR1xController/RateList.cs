using System;
using System.Collections.Generic;

namespace AR1xController
{
	public class RateList : List<RateData>
	{
		public string[] Names
		{
			get
			{
				string[] array = new string[base.Count];
				for (int i = 0; i < base.Count; i++)
				{
					array[i] = base[i].Name;
				}
				return array;
			}
		}

		public void AddRate(string rate_name, int value, RateGroup group, int p3)
		{
			base.Add(new RateData(rate_name, value, group, p3));
		}

		public string GetNameByVal(int value)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].Value == value)
				{
					return base[i].Name;
				}
			}
			return null;
		}

		public string GetNameById(int p0)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].ID == p0)
				{
					return base[i].Name;
				}
			}
			return null;
		}

		public int GetValue(string name)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].Name == name)
				{
					return base[i].Value;
				}
			}
			return -1;
		}

		public int GetID(string name)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].Name == name)
				{
					return base[i].ID;
				}
			}
			return -1;
		}

		public RateGroup GetGroup(string name)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].Name == name)
				{
					return base[i].Group;
				}
			}
			return RateGroup.Undefined;
		}

		public RateData GetRate(string name)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].Name == name)
				{
					return base[i];
				}
			}
			return null;
		}

		public RateData GetRateById(int p0)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].ID == p0)
				{
					return base[i];
				}
			}
			return null;
		}

		public RateData GetRateByVal(int val)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].Value == val)
				{
					return base[i];
				}
			}
			return null;
		}
	}
}
