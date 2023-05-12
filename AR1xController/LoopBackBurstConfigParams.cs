using System;

namespace AR1xController
{
	public class LoopBackBurstConfigParams
	{
		public byte LoopBackSelect;

		public byte BaseProfileIndex;

		public byte BurstIndex;

		public byte Reserved;

		public double FreqConst;

		public float SlopeConst;

		public ushort Reserved2;

		public byte Tx1BackOff;

		public byte Tx2BackOff;

		public byte Tx3BackOff;

		public byte RxGain;

		public byte RFGainTarget;

		public byte Tx1Enable;

		public byte Tx2Enable;

		public byte Tx3Enable;

		public byte BPMTx0Off;

		public byte BPMTx0On;

		public byte BPMTx1Off;

		public byte BPMTx1On;

		public byte BPMTx2Off;

		public byte BPMTx2On;

		public byte IQMM;

		public byte RxGainPhase;

		public byte IFLoopBackFreq;

		public byte IFLoopBackMagnitude;

		public byte f000027;

		public byte f000028;

		public ushort Tx1PSLoopBackFreq;

		public ushort Tx2PSLoopBackFreq;

		public ushort PALoopBackFreq;
	}
}
