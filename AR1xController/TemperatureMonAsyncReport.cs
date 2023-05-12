using System;

public struct TemperatureMonAsyncReport
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public short Rx1TempValue;

	public short Rx2TempValue;

	public short Rx3TempValue;

	public short Rx4TempValue;

	public short Tx1TempValue;

	public short Tx2TempValue;

	public short Tx3TempValue;

	public short PMTempValue;

	public short Dig1TempValue;

	public short Dig2TempValue;

	public uint Reserved;

	public uint TimeStamp;
}
