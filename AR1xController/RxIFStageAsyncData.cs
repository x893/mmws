using System;

public struct RxIFStageAsyncData
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public byte ProfileIndex;

	public byte Reserved;

	public short Reserved2;

	public int Rx1Rx2Rx3Rx4IChannnelHPFCuttoffFreqErrorVal;

	public int Rx1Rx2Rx3Rx4QChannnelHPFCuttoffFreqErrorVal;

	public int Rx1Rx2Rx3Rx4IChannnelLPFCuttoffFreqErrorVal;

	public int Rx1Rx2Rx3Rx4QChannnelLPFCuttoffFreqErrorVal;

	public int Rx1Rx2Rx3Rx4IChannnelIFAGainErrorVal;

	public int Rx1Rx2Rx3Rx4QChannnelIFAGainErrorVal;

	public uint Reserved3;

	public uint Reserved4;

	public uint TimeStamp;
}
