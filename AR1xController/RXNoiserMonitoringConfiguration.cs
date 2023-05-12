using System;

public struct RXNoiserMonitoringConfiguration
{
	public byte ProfileIndex;

	public byte RFFreqBitMask;

	public ushort Reserved;

	public byte ReportingMode;

	public byte Reserved2;

	public ushort RXNoiseFigureThreshold;

	public uint Reserved3;
}
