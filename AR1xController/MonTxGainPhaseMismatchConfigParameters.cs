using System;

namespace AR1xController
{
	public class MonTxGainPhaseMismatchConfigParameters
	{
		public char ProfileIndex;

		public char RF1FreqBitMask;

		public char RF2FreqBitMask;

		public char RF3FreqBitMask;

		public char Tx1Channel;

		public char Tx2Channel;

		public char Tx3Channel;

		public char Rx0Channel;

		public char Rx1Channel;

		public char Rx2Channel;

		public char Rx3Channel;

		public char ReportingMode;

		public char Reserved2;

		public double TxGainMismatchThreshold;

		public double TxPhaseMismatchThreshold;

		public double RF1Tx1GainMismatchOffsetVal;

		public double RF1Tx2GainMismatchOffsetVal;

		public double RF1Tx3GainMismatchOffsetVal;

		public double RF2Tx1GainMismatchOffsetVal;

		public double RF2Tx2GainMismatchOffsetVal;

		public double RF2Tx3GainMismatchOffsetVal;

		public double RF3Tx1GainMismatchOffsetVal;

		public double RF3Tx2GainMismatchOffsetVal;

		public double RF3Tx3GainMismatchOffsetVal;

		public double RF1Tx1PhaseMismatchOffsetVal;

		public double RF1Tx2PhaseMismatchOffsetVal;

		public double RF1Tx3PhaseMismatchOffsetVal;

		public double RF2Tx1PhaseMismatchOffsetVal;

		public double RF2Tx2PhaseMismatchOffsetVal;

		public double RF2Tx3PhaseMismatchOffsetVal;

		public double RF3Tx1PhaseMismatchOffsetVal;

		public double RF3Tx2PhaseMismatchOffsetVal;

		public double RF3Tx3PhaseMismatchOffsetVal;

		public ushort Reserved3;

		public uint Reserved4;
	}
}
