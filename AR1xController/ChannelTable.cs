using System;
using System.Collections.Generic;

namespace AR1xController
{
	public class ChannelTable : List<ChannelData>
	{
		public void AddChannel(string chan_name, int freq, int prim_chan_idx, Band band)
		{
			base.Add(new ChannelData(chan_name, freq, prim_chan_idx, band));
		}

		public int GetIndexByName(string chan_name)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].Name == chan_name)
				{
					return i;
				}
			}
			return -1;
		}

		public int GetIndexByBandAndPrime(Band band, int primary_chan_idx)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base[i].Band == band && base[i].PrimIdx == primary_chan_idx)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
