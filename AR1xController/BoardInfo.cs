using System;

namespace AR1xController
{
	public class BoardInfo
	{
		public BoardInfo()
		{
			this.Reset();
		}

		public void Reset()
		{
			this.RDL = 0;
			this.PG = "0.0";
			this.Type = BoardType.HDK;
			this.Flavor = BoardFlavor.Unkown;
			this.Antenna = AntennaType.Unknown;
			this.Process = ProcessType.Unkown;
		}

		public int RDL;

		public string PG;

		public BoardType Type;

		public BoardFlavor Flavor;

		public AntennaType Antenna;

		public ProcessType Process;
	}
}
