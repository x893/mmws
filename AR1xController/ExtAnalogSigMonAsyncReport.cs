using System;

public struct ExtAnalogSigMonAsyncReport
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public ushort ExtAnalogSigTest1Val;

	public ushort ExtAnalogSigTest2Val;

	public ushort ExtAnalogSigTest3Val;

	public ushort ExtAnalogSigTest4Val;

	public ushort ExtAnalogSigMuxVal;

	public ushort ExtAnalogSigVSenseVal;

	public uint Reserved;

	public uint TimeStamp;
}
