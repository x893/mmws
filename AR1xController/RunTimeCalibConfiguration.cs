using System;

public struct RunTimeCalibConfiguration
{
	public uint OneTimeCalibEnaMask;

	public uint PeriodicCalibEnaMask;

	public uint CalibPeriodicity;

	public byte ReportEnable;

	public byte Reserved1;

	public byte TxPowerCalMode;

	public byte Reserved2;

	public uint Reserved3;
}
