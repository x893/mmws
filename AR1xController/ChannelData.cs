using System;

namespace AR1xController
{
	public class ChannelData
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

		public int Freq
		{
			get
			{
				return this.m_Freq;
			}
			set
			{
				this.m_Freq = value;
			}
		}

		public int PrimIdx
		{
			get
			{
				return this.m_PrimIdx;
			}
			set
			{
				this.m_PrimIdx = value;
			}
		}

		public Band Band
		{
			get
			{
				return this.m_Band;
			}
			set
			{
				this.m_Band = value;
			}
		}

		public ChannelData(string name, int freq, int prim_idx, Band band)
		{
			this.m_Name = name;
			this.m_Freq = freq;
			this.m_PrimIdx = prim_idx;
			this.m_Band = band;
		}

		private string m_Name;

		private int m_Freq;

		private int m_PrimIdx;

		private Band m_Band;
	}
}
