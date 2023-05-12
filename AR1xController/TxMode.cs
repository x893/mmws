using System;

namespace AR1xController
{
	public enum TxMode
	{
		Unknown = -1,
		Packet_Single,
		Packet_Series,
		Packet_Infinite,
		Packet_Continuous,
		Packet_FccCont,
		Tone_Silence,
		Tone_Carrier,
		Tone_Single,
		Tone_Two
	}
}
