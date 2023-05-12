using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlDynPerChirpPhShftCfgT
	{
		public int chirpSegSel { get; set; }

		public int programMode { get; set; }

		public List<RlChirpPhShiftPerTxs> rlChirpPhShiftPerTxs { get; set; }
	}
}
