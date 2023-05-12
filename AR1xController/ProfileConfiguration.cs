using System;

public struct ProfileConfiguration
{
	public ushort ProfileIndex;

	public byte VCOSelect;

	public byte CalibLUTUpdate;

	public uint FreqStartConst;

	public uint IdleTimeConst;

	public uint ADCStartTimeConst;

	public uint RampEndTimeConst;

	public uint TxOutputPowerBackoff;

	public uint TxPhaseShifter;

	public ushort FreqSlopeConst;

	public ushort TxStartTime;

	public ushort ADCSamples;

	public ushort DigOutputSampleRate;

	public byte HPF1CornerFreq;

	public byte HPF2CornerFreq;

	public ushort Reserved;

	public ushort RxGain;

	public ushort Reserved2;
}
