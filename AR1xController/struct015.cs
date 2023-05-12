using System;

public struct struct015
{
	public byte FaultType;

	public byte Reserved;

	public ushort LineNum;

	public uint FaultLR;

	public uint FaultPrevLR;

	public uint FaultSPSR;

	public uint FaultSP;

	public uint FaultCauseAddress;

	public ushort FaultErrorStatus;

	public byte FaultErrorSource;

	public byte FaultAXIErrorType;

	public byte FaultAccessType;

	public byte FaultRecoveryType;

	public ushort Reserved2;
}
