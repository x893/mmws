using System;

public struct ChirpParams
{
	public ushort profId;

	public ushort chipStartIndex;

	public ushort chipEndIndex;

	public float startFreqVar;

	public float freqSlopeVar;

	public float idleTimeVar;

	public float adcStartTimeVar;

	public ushort tx1Enable;

	public ushort tx2Enable;

	public ushort tx3Enable;
}
