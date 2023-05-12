using System;

public struct TxGainPhaseMismatchMonitoringConfiguration
{
	public byte ProfileIndex;

	public byte RFFreqBitMask;

	public byte TxChannel;

	public byte RxChannel;

	public byte ReportingMode;

	public byte Reserved2;

	public short TxGainMismatchThreshold;

	public short TxPhaseMismatchThreshold;

	public short RF1TX1GainMismatchOffsetVal;

	public short RF1TX2GainMismatchOffsetVal;

	public short RF1TX3GainMismatchOffsetVal;

	public short RF2TX1GainMismatchOffsetVal;

	public short RF2TX2GainMismatchOffsetVal;

	public short RF2TX3GainMismatchOffsetVal;

	public short RF3TX1GainMismatchOffsetVal;

	public short RF3TX2GainMismatchOffsetVal;

	public short RF3TX3GainMismatchOffsetVal;

	public ushort RF1TX1PhaseMismatchOffsetVal;

	public ushort RF1TX2PhaseMismatchOffsetVal;

	public ushort RF1TX3PhaseMismatchOffsetVal;

	public ushort RF2TX1PhaseMismatchOffsetVal;

	public ushort RF2TX2PhaseMismatchOffsetVal;

	public ushort RF2TX3PhaseMismatchOffsetVal;

	public ushort RF3TX1PhaseMismatchOffsetVal;

	public ushort RF3TX2PhaseMismatchOffsetVal;

	public ushort RF3TX3PhaseMismatchOffsetVal;

	public ushort Reserved3;

	public uint Reserved4;
}
