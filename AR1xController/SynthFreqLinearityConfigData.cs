using System;

public struct SynthFreqLinearityConfigData
{
	public byte ProfileIndex;

	public byte ReportingMode;

	public ushort FreqErrorThreshold;

	public uint MonStartTime;

	public uint DataPathParams1;

	public uint DataPathParams2;

	public uint LinearityRAMAddress;

	public uint Reserved;
}
