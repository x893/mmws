using System;

public struct Tx2BPMPhaseAsyncFormat
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public byte ProfileIndex;

	public byte TxPhaseShifter2LSB;

	public ushort TxPhaseShifter1Val;

	public ushort TxBPMPhaseErrorVal;

	public byte TxBPMAmplitudeErrorVal;

	public byte TxPhaseShifter2MSB;

	public uint TimeStamp;
}
