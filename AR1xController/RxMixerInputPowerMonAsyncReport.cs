using System;

public struct RxMixerInputPowerMonAsyncReport
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public byte ProfileId;

	public byte Reserved2;

	public ushort Reserved3;

	public uint RxMixerInVolVal;

	public uint Reserved;

	public uint TimeStamp;
}
