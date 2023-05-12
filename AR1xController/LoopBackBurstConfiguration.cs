using System;

public struct LoopBackBurstConfiguration
{
	public byte LoopBackSelect;

	public byte BaseProfileIndex;

	public byte BurstIndex;

	public byte Reserved;

	public uint FreqConst;

	public ushort SlopeConst;

	public ushort Reserved2;

	public uint TxBackOff;

	public ushort RxGain;

	public byte TxEnable;

	public byte Reserved3;

	public ushort BPMConfig;

	public ushort DigitalCorrectionDisable;

	public byte IFLoopBackFreq;

	public byte IFLoopBackMagnitude;

	public byte f000027;

	public byte f000028;

	public uint PSLoopBackFreq;

	public uint Reserved4;

	public ushort PALoopBackFreq;

	public ushort Reserved5;

	public ushort Reserved6;

	public ushort Reserved7;
}
