using System;

public struct ProfParams
{
	public ushort pprofileId;

	public float startFreqConst;

	public float idleTimeConst;

	public float adcStartTimeConst;

	public float rampEndTime;

	public uint tx1OutPowerBackoffCode;

	public uint tx2OutPowerBackoffCode;

	public uint tx3OutPowerBackoffCode;

	public float tx1PhaseShifter;

	public float tx2PhaseShifter;

	public float tx3PhaseShifter;

	public float freqSlopeConst;

	public float txStartTime;

	public ushort pnumAdcSamples;

	public ushort digOutSampleRate;

	public ushort hpfCornerFreq1;

	public ushort hpfCornerFreq2;

	public ushort rxGain;

	public ushort rxGainTarget;

	public ushort VCOSelect;

	public ushort forceVCOSelect;

	public ushort retainTxCalibLUT;

	public ushort retainRxCalibLUT;

	public ushort ProfileControl;
}
