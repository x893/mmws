using System;

public struct TxGainPhaseMismatchAsyncReport
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public byte ProfileIndex;

	public byte Reserved;

	public ushort Reserved2;

	public uint RF1Tx1Tx2TxGainValue;

	public uint RF1Tx3RF2Tx1TxGainValue;

	public uint RF2Tx2RF2Tx3TxGainValue;

	public uint RF3Tx1RF3Tx2TxGainValue;

	public uint RF3Tx3GainRF1Tx1PhaseValue;

	public uint RF1Tx2Tx3TxPhaseValue;

	public uint RF2Tx1RF2Tx2TxPhaseValue;

	public uint RF2Tx3RF3Tx1TxPhaseValue;

	public uint RF3Tx2RF3Tx3TxPhaseValue;

	public uint Reserved3;

	public uint Reserved4;

	public uint TimeStamp;
}
