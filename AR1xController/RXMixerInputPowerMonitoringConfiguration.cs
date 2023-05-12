using System;

public struct RXMixerInputPowerMonitoringConfiguration
{
	public byte ProfileIndex;

	public byte ReportingMode;

	public byte TxEnable;

	public byte Reserved;

	public ushort Thresholds;

	public ushort Reserved2;

	public uint Reserved3;
}
