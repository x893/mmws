using System;

namespace AR1xController
{
	public class AnalogFaultInjectionConfigParameters
	{
		public byte Reserved;

		public byte RxGainDropRx1;

		public byte RxGainDropRx2;

		public byte RxGainDropRx3;

		public byte RxGainDropRx4;

		public byte RxPhaseInvRx1;

		public byte RxPhaseInvRx2;

		public byte RxPhaseInvRx3;

		public byte RxPhaseInvRx4;

		public byte RxHighNoiseRx1;

		public byte RxHighNoiseRx2;

		public byte RxHighNoiseRx3;

		public byte RxHighNoiseRx4;

		public byte RxIFStageRx1;

		public byte RxIFStageRx2;

		public byte RxIFStageRx3;

		public byte RxIFStageRx4;

		public byte RxLOAmpRx1Rx2;

		public byte RxLOAmpRx3Rx4;

		public byte TxLOAmpTx1Tx2;

		public byte TxLOAmpTx3;

		public byte TxGainDropTx1;

		public byte TxGainDropTx2;

		public byte TxGainDropTx3;

		public byte TxPhaseInvTxFault;

		public byte TxPhaseInvBPMTx1Fault;

		public byte TxPhaseInvBPMTx2Fault;

		public byte TxPhaseInvBPMTx3Fault;

		public byte SynthVCOOpenFault;

		public byte SynthFreqMonOffset;

		public byte f000319;

		public byte f00031a;

		public byte ExtAnalogSigMon;

		public byte f00031b;

		public byte Reserved2;

		public ushort Reserved3;

		public uint Reserved4;
	}
}
