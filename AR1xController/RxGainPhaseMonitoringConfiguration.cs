using System;

public struct RxGainPhaseMonitoringConfiguration
{
	public byte ProfileIndex;

	public byte RFFreqBitMask;

	public byte ReportingMode;

	public byte TxSelect;

	public ushort RxGainAbsoluteErrorThreshold;

	public ushort RxGainMismatchThreshold;

	public ushort RxGainFlatnessErrorThreshold;

	public ushort RxPhaseMismatchThreshold;

	public int f000010;

	public int f000011;

	public int f000012;

	public int f000013;

	public int f000014;

	public int f000015;

	public uint f000016;

	public uint f000017;

	public uint f000018;

	public uint f000019;

	public uint f00001a;

	public uint f00001b;

	public uint Reserved;

	public uint Reserved2;
}
