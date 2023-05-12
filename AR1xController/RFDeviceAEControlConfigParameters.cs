using System;

namespace AR1xController
{
	public class RFDeviceAEControlConfigParameters
	{
		public uint f0002fd;

		public uint RFMonAEDirection;

		public byte AEFrameStartControl;

		public byte AEFrameStopControl;

		public ushort Reserved;

		public byte BSSDigitalControl;

		public byte AsyncEventCRCConfig;

		public ushort Reserved2;

		public byte Reserved3;
	}
}
