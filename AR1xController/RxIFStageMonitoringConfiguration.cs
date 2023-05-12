using System;

public struct RxIFStageMonitoringConfiguration
{
	public byte ProfileIndex;

	public byte ReportingMode;

	public ushort Reserved;

	public ushort Reserved2;

	public ushort HPFCuttoffFreqErrorThreshold;

	public ushort LPFCuttoffFreqErrorThreshold;

	public ushort IFAGainErrorThreshold;

	public uint Reserved3;
}
