using System;

public struct PLLControlVoltageAsyncReport
{
	public ushort StatusFlags;

	public ushort ErrorCode;

	public ushort f00000e;

	public ushort SynthVCO1VctlMaxFreq;

	public ushort SynthVCO1VctlMinFreq;

	public ushort SynthVCO1Slope;

	public ushort SynthVCO2VctlMaxFreq;

	public ushort SynthVCO2VctlMinFreq;

	public ushort SynthVCO2Slope;

	public ushort Reserved;

	public uint Reserved2;

	public uint TimeStamp;
}
