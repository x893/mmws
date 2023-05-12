using System;
using System.Net.Sockets;
using RstdNet;

namespace RSTD
{
	public class CSocketPacket
	{
		public Socket thisSocket;
		public byte[] dataBuffer = new byte[RstdNetConsts.BUFFER_SIZE];
	}
}
