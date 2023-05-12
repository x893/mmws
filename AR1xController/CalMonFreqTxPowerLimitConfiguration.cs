using System;

public struct CalMonFreqTxPowerLimitConfiguration
{
	public ushort FreqLimitLowTx1;

	public ushort FreqLimitLowTx2;

	public ushort FreqLimitLowTx3;

	public ushort FreqLimitHighTx1;

	public ushort FreqLimitHighTx2;

	public ushort FreqLimitHighTx3;

	public byte Tx1PowerBackoff;

	public byte Tx2PowerBackoff;

	public byte Tx3PowerBackoff;

	public byte Reserved;

	public ushort Reserved2;

	public ushort Reserved3;

	public ushort Reserved4;

	public ushort Reserved5;
}
