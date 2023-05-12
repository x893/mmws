using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct RFDCCardModeConfiguration
{
	public uint eLogMode;

	public uint eLvdsMode;

	public uint eDataXferMode;

	public uint eDataCaptureMode;

	public uint eDataFormatMode;

	public byte u8Timer;
}
