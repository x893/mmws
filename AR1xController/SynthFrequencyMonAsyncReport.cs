using System;

public struct SynthFrequencyMonAsyncReport
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public byte ProfileIndex;

	public byte Reserved;

	public ushort Reserved2;

	public int MaxFreqErrorValue;

	public uint FreqFailureCount;

	public uint Reserved3;

	public uint Reserved4;

	public uint TimeStamp;
}
