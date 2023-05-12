using System;

public struct IntPMCLKLOAnalogSigMonAsyncReport
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public byte ProfileIndex;

	public sbyte Sync20GPower;

	public ushort Reserved2;

	public uint TimeStamp;
}
