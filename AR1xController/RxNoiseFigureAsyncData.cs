using System;

public struct RxNoiseFigureAsyncData
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public byte ProfileIndex;

	public byte Reserved;

	public ushort Reserved2;

	public uint RF1Rx1Rx2PowerValue;

	public uint RF1Rx3Rx4PowerValue;

	public uint RF2Rx1Rx2PowerValue;

	public uint RF2Rx3Rx4PowerValue;

	public uint RF3Rx1Rx2PowerValue;

	public uint RF3Rx3Rx4PowerValue;

	public uint Reserved3;

	public uint Reserved4;

	public uint Reserved5;

	public uint TimeStamp;
}
