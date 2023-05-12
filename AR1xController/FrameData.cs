using System;

public struct FrameData
{
	public ushort fchirpStartIdx;

	public ushort fchirpEndIdx;

	public ushort frameCount;

	public ushort loopCount;

	public uint periodicity;

	public uint triggerDelay;

	public uint fnumAdcSamples;
}
