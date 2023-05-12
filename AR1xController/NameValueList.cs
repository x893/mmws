using System;
using System.Collections.Generic;

namespace AR1xController
{
	public class NameValueList : List<NameValue>
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

		public int[] Values
		{
			get
			{
				int[] array = new int[base.Count];
				for (int i = 0; i < base.Count; i++)
				{
					array[i] = base[i].Value;
				}
				return array;
			}
		}

		public void AddNameValue(string name, int value)
		{
			base.Add(new NameValue(name, value));
		}

		public string GetName(int value)
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
	}
}
