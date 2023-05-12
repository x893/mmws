using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class RlTestSourceT
	{
		public List<RlTestSourceObjects> rlTestSourceObjects { get; set; }

		public List<RlTestSourceRxAntPos> rlTestSourceRxAntPos { get; set; }

		public List<RlTestSourceTxAntPos> rlTestSourceTxAntPos { get; set; }

		public int isConfigured { get; set; }
	}
}
