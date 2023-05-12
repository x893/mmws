using System;

public struct ProfileData
{
	public uint profileIntialized;

	public uint startFreqConst;

	public uint idleTimeConst;

	public uint adcStartTimeConst;

	public uint rampEndTime;

	public uint tx1OutPowerBackoffCode;

	public uint tx2OutPowerBackoffCode;

	public uint tx3OutPowerBackoffCode;

	public uint tx1PhaseShifter;

	public uint tx2PhaseShifter;

	public uint tx3PhaseShifter;

	public ushort freqSlopeConst;

	public short txStartTime;

	public ushort pnumAdcSamples;

	public ushort digOutSampleRate;

	public char hpfCornerFreq1;

	public char hpfCornerFreq2;

	public char rxGain;
}
