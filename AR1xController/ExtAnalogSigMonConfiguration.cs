using System;

public struct ExtAnalogSigMonConfiguration
{
	public byte ReportingMode;

	public byte Reserved;

	public byte SignalInputEnables;

	public byte SignalBufferEnables;

	public ushort SignalSettlingTimeAnalogTest1AndTest2;

	public ushort SignalSettlingTimeAnalogTest3AndTest4;

	public ushort SignalSettlingTimeAnalogMuxAndVSense;

	public ushort SignalMinThresholdAnalogTest1AndTest2;

	public ushort SignalMinThresholdAnalogTest3AndTest4;

	public ushort SignalMinThresholdAnalogMuxAndVSense;

	public ushort SignalMaxThresholdAnalogTest1AndTest2;

	public ushort SignalMaxThresholdAnalogTest3AndTest4;

	public ushort SignalMaxThresholdAnalogMuxAndVSense;

	public ushort Reserved2;

	public uint Reserved3;

	public uint Reserved4;
}
