using System;

namespace AR1xController
{
	public class MonTx2BPMPhaseConfigParameters
	{
		public byte ProfileIndex;

		public float phaseShifterCfgIncVal;

		public byte phaseShifterMonEna;

		public byte phaseShifterCfgIncValEna;

		public float phaseShifter1;

		public float phaseShifter2;

		public byte ReportingMode;

		public byte Rx0Channel;

		public byte Rx1Channel;

		public byte Rx2Channel;

		public byte Rx3Channel;

		public double TxBPMPhaseErrorThreshold;

		public double TxBPMAmplitudeErrorThreshold;

		public double TxPhaseShifter1Threshold;

		public double TxPhaseShifter2Threshold;

		public ushort Reserved;
	}
}
