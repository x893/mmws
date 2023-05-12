using System;

public struct IntGPADCAnalogSigMonAsyncReport
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public ushort f00000c;

	public ushort f00000d;

	public uint Reserved;

	public uint TimeStamp;
}
