using System;

public struct IntTx3AnalogSigMonAsyncReport
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public byte ProfileIndex;

	public byte Reserved;

	public ushort Reserved2;

	public uint TimeStamp;
}
