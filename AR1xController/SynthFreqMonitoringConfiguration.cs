using System;

public struct SynthFreqMonitoringConfiguration
{
	public byte ProfileIndex;

	public byte ReportingMode;

	public ushort FreqErrorThreshold;

	public sbyte MonStartTime;

	public byte Reserved2;

	public ushort Reserved3;

	public uint Reserved4;
}
