using System;

public struct Tx2BPMPhaseMonitoringConfiguration
{
	public byte ProfileIndex;

	public byte phaseShifterCfg;

	public byte phaseShifterVal1;

	public byte phaseShifterVal2;

	public byte ReportingMode;

	public byte RxChannel;

	public ushort TxBPMPhaseErrorThreshold;

	public ushort TxBPMAmplitudeErrorThreshold;

	public ushort TxPhaseShifter1Threshold;

	public ushort TxPhaseShifter2Threshold;

	public ushort Reserved;
}
