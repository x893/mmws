using System;

public struct RxGainPhaseAsyncData
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public byte ProfileIndex;

	public byte Reserved;

	public ushort Reserved2;

	public uint RF1Rx1Rx2RxGainValue;

	public uint RF1Rx3Rx4RxGainValue;

	public uint RF2Rx1Rx2RxGainValue;

	public uint RF2Rx3Rx4RxGainValue;

	public uint RF3Rx1Rx2RxGainValue;

	public uint RF3Rx3Rx4RxGainValue;

	public uint RF1Rx1Rx2RxPhaseValue;

	public uint RF1Rx3Rx4RxPhaseValue;

	public uint RF2Rx1Rx2RxPhaseValue;

	public uint RF2Rx3Rx4RxPhaseValue;

	public uint RF3Rx1Rx2RxPhaseValue;

	public uint RF3Rx3Rx4RxPhaseValue;

	public uint Reserved3;

	public uint Reserved4;

	public uint TimeStamp;
}
