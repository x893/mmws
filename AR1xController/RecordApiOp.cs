using System;

namespace AR1xController
{
	public enum RecordApiOp
	{
		None,
		Connect,
		Disconnect,
		ChannelTune = 4,
		SetAntennaMode = 8,
		SetAntennaMode_24G,
		SetAntennaMode_5G,
		SetOutputPower = 14,
		StartTx = 17,
		StopTx = 13,
		StartRx = 26,
		StopRx = 25,
		GetRxStats = 27,
		f0002b5,
		ConnectAnalogPorts = 40,
		ReadIni = 101,
		UpdateIni,
		DownloadFw,
		PowerMode
	}
}
