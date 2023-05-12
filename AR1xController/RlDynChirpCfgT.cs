using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlDynChirpCfgT
	{
		public int chirpRowSel { get; set; }

		public int chirpSegSel { get; set; }

		public int programMode { get; set; }

		public List<RlChirpRows> rlChirpRows { get; set; }

	}
}
