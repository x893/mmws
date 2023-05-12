using System;

public struct DCCMonAsyncReport
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public ushort FreqMeasClock0;

	public ushort FreqMeasClock1;

	public ushort FreqMeasClock2;

	public ushort FreqMeasClock3;

	public ushort FreqMeasClock4;

	public ushort FreqMeasClock5;

	public uint Reserved;

	public uint Reserved2;

	public uint TimeStamp;
}
