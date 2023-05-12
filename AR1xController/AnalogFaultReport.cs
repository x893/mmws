using System;

public struct AnalogFaultReport
{
	public byte FaultType;

	public byte Reserved;

	public ushort Reserved2;

	public uint FaultSig;

	public uint Reserved3;
}
