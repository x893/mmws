using System;

namespace AR1xController
{
	public class MSSLatentFaultTestConfigParameters
	{
		public char f000322;

		public char DMAMOn;

		public char RTIMOn;

		public char ESMMOn;

		public char f000323;

		public char CRCMOn;

		public char VIMMon;

		public char MailBoxMon;

		public char LVDSPatternGenMon;

		public char CSI2PatternGenMon;

		public char GenNErrorMon;

		public char MibSPISingleBitErrorMon;

		public char MibSPIDoubleBitErrorMon;

		public char DMAParityError;

		public char TCMARamSingleBitErrorMon;

		public char TCMBRamSingleBitErrorMon;

		public char TCMARamDoubleBitErrorMon;

		public char TCMBRamDoubleBitErrorMon;

		public char TCMARamParityErrorMon;

		public char TCMBRamParityErrorMon;

		public char f000324;

		public char MSSMailBoxSingleBitErrorMon;

		public char MSSMailBoxDoubleBitErrorMon;

		public char BSSMailBoxSingleBitErrorMon;

		public char BSSMailBoxDoubleBitErrorMon;

		public char f000325;

		public char EDMAParityMon;

		public char CSI2ParityMon;

		public char DCCSelfTest;

		public char DCCFaultInsertion;

		public char PCRFaultGenTest;

		public char VIMRamParity;

		public char SCI;

		public char ReportingMode;

		public char TestMode;

		public ushort Reserved;
	}
}
