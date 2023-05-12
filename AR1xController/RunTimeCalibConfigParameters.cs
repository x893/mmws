using System;

namespace AR1xController
{
	public class RunTimeCalibConfigParameters
	{
		public uint OneTimeLODist;

		public uint OneTimeTXPower;

		public uint OneTimeRXGain;

		public uint OneTimePDCal;

		public uint PeriodiCalibLODist;

		public uint PeriodiCalibTXPower;

		public uint PeriodiCalibRXGain;

		public uint PeriodiCalibPDCal;

		public uint CalibPeriodicity;

		public char EnableCalReport;

		public char TxPowerCalMode;

		public char Reserved0;

		public char Reserved1;

		public ushort Reserved2;

		public uint Reserved3;
	}
}
