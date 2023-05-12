using System;

namespace AR1xController
{
	public enum TsApiOp
	{
		None,
		Connect,
		Disconnect,
		ReadIni,
		SetNvsPath,
		SetFrefClk,
		SetIniFilePath,
		ChannelTune,
		PowerMode,
		SetAntennaMode_24G,
		SetAntennaMode_5G,
		StartTx,
		StopTx,
		SetOutputPower,
		StartRx,
		StopRx,
		GetRxStats,
		RunCalibration
	}
}
