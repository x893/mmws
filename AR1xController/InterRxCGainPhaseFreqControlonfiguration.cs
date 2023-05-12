using System;

public struct InterRxCGainPhaseFreqControlonfiguration
{
	public byte ProfileIndex;

	public byte Reserved;

	public ushort Reserved2;

	public uint DigitalGain;

	public uint Rx1Rx2DigitalPhaseShift;

	public uint Rx3Rx4DigitalPhaseShift;

	public uint Rx1Rx2DigitalFreqShift;

	public uint Rx3Rx4DigitalFreqShift;
}
