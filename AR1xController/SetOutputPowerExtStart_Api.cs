using System;

namespace AR1xController
{
	public delegate void SetOutputPowerExtStart_Api(int des_pwr, uint level_idx, uint freq_band, uint freq_prim_chan, int freq_2nd_chan, uint ant_select, uint non_srv, uint chan_limit, uint fem_limit, uint gain_calc_mode, uint analog_gain_idx, int post_dpd);
}
