using System;

public struct Tx3PowerMonAsyncData
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public byte ProfileIndex;

	public byte Reserved;

	public ushort Reserved2;

	public uint RF12TxPowerValue;

	public uint RF3TxPowerValue;

	public uint TimeStamp;
}
