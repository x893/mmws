using System;

public struct AnalogFaultInjectionConfiguration
{
	public byte Reserved;

	public byte RxGainDrop;

	public byte RxPhaseInv;

	public byte RxHighNoise;

	public byte RxIFStageFault;

	public byte RxLOAmpFault;

	public byte TxLOAmpFault;

	public byte TxGainDrop;

	public byte TxPhaseInv;

	public byte SynthFault;

	public byte SupplyLDOFault;

	public byte MiscFault;

	public byte MiscThresholdFault;

	public byte Reserved2;

	public ushort Reserved3;

	public uint Reserved4;
}
