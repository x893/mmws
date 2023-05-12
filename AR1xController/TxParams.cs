using System;

namespace AR1xController
{
	public class TxParams
	{
		public TxMode Mode;

		public RateData Rate;

		public Preamble Preamble;

		public int SGI;

		public int Scramble;

		public int Stbc;

		public int Increment;

		public int DualStream;

		public int Type;

		public int Seed;

		public int Size;

		public int Amount;

		public int Delay;

		public int ConstData;

		public int DutyCycle;

		public string SrcMacAddr;

		public string DstMacAddr;

		public int Dbm;

		public int Soc;

		public double Power;

		public int AnalogSetting;

		public int AntSelect;

		public int ChanLimit;

		public int FemLimit;

		public int EnableDpd;

		public int TargetCurve;

		public double PostDpd;

		public int EnableClpc;

		public int ClpcTime;

		public int FCarrier;

		public int SCarrier;
	}
}
