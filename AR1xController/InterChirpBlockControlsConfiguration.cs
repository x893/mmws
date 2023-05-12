using System;

public struct InterChirpBlockControlsConfiguration
{
	public ushort Rx02RFTurnOffTime;

	public ushort Rx13RFTurnOffTime;

	public ushort Rx02BBTurnOffTime;

	public ushort Rx13BBTurnOffTime;

	public ushort Rx02RFPreEnableTime;

	public ushort Rx24RFPreEnableTime;

	public ushort Rx02BBPreEnableTime;

	public ushort Rx13BBPreEnableTime;

	public ushort Rx02RFTurnOnTime;

	public ushort Rx13RFTurnOnTime;

	public ushort Rx02BBTurnOnTime;

	public ushort Rx13BBTurnOnTime;

	public ushort RxLOChainTurnOffTime;

	public ushort TxLOChainTurnOffTime;

	public ushort RxLOChainTurnOnTime;

	public ushort TxLOChainTurnOnTime;

	public uint Reserved;

	public uint Reserved2;
}
