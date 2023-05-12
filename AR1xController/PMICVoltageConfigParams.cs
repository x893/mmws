using System;

namespace AR1xController
{
	public class PMICVoltageConfigParams
	{
		public ushort Buck0SlaveAddress;
		public ushort Buck0RegAddress;
		public byte Buck0MsbData;
		public byte Buck0LsbData;
		public int Buck0DataSize;
		public ushort Buck1SlaveAddress;
		public ushort Buck1RegAddress;
		public byte Buck1MsbData;
		public byte Buck1LsbData;
		public int Buck1DataSize;
		public ushort Buck2SlaveAddress;
		public ushort Buck2RegAddress;
		public byte Buck2MsbData;
		public byte Buck2LsbData;
		public int Buck2DataSize;
		public ushort Buck3SlaveAddress;
		public ushort Buck3RegAddress;
		public byte Buck3MsbData;
		public byte Buck3LsbData;
		public int Buck3DataSize;
		public int f0004ed;
		public int f0004ee;
		public int f0004ef;
		public int f0004f0;
		public int f0004f1;
		public int f0004f2;
		public int f0004f3;
		public int f0004f4;
		public int PMIC1;
		public int PMIC2;
	}
}
