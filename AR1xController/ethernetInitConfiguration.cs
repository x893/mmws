using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ethernetInitConfiguration
{
	public byte f00001c;
	public byte f00001d;
	public byte f00001e;
	public byte f00001f;
	public byte f000020;
	public byte f000021;
	public byte au8SourceIpAddr0;
	public byte au8SourceIpAddr1;
	public byte au8SourceIpAddr2;
	public byte au8SourceIpAddr3;
	public byte au8DestiIpAddr0;
	public byte au8DestiIpAddr1;
	public byte au8DestiIpAddr2;
	public byte au8DestiIpAddr3;
	public int u32RecordPortNo;
	public int u32ConfigPortNo;
}
