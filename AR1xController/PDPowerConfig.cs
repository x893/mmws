using System;

public struct PDPowerConfig
{
	public uint SumRFOn;

	public uint SumRFOff;

	public ushort DeltaSum;

	public ushort f00000f;

	public ushort PDPower;

	public byte PDMeasureStatus;

	public byte reserved;
}
