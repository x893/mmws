using System;

public struct RxSaturationDetectorMonitoringConfiguration
{
	public byte ProfileIndex;

	public byte SatMonSelect;

	public byte SatMonMode;

	public byte SatMonMode2;

	public short SatMonPrimaryTimeSliceDuration;

	public short SatMonNumSlices;

	public byte SatMonRxChannelMask;

	public byte Reserved;

	public byte Reserved2;

	public byte Reserved3;

	public int Reserved4;

	public int Reserved5;
}
