using System;

public struct ContStreamConfiguration
{
	public uint FreqStartConst;

	public uint TxOutputPowerBackoff;

	public uint TxPhaseShifter;

	public ushort DigOutputSampleRate;

	public byte HPF1CornerFreq;

	public byte HPF2CornerFreq;

	public byte RxGain;

	public byte VCOSelect;

	public byte TxEnable;

	public byte MisControls;
}
