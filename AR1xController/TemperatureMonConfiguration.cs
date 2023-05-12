using System;

public struct TemperatureMonConfiguration
{
	public byte ReportingMode;

	public byte Reserved;

	public short AnaTempThreshMin;

	public short AnaTempThreshMax;

	public short DigTempThreshMin;

	public short DigTempThreshMax;

	public short TempDiffThresh;

	public uint Reserved2;

	public uint Reserved3;
}
