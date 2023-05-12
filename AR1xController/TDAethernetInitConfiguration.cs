using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TDAethernetInitConfiguration
{
	public byte au8DestiIpAddr0;

	public byte au8DestiIpAddr1;

	public byte au8DestiIpAddr2;

	public byte au8DestiIpAddr3;

	public int u32ConfigPortNo;

	public uint deviceMap;
}
