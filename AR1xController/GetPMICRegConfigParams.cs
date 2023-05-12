using System;

namespace AR1xController
{
	public class GetPMICRegConfigParams
	{
		public byte SlaveAddress;

		public byte RegAddress;

		public byte RegMsbData;

		public byte RegLsbData;

		public int DataSize;
	}
}
