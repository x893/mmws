using System;

public struct RxGainTempLutReportData
{
	public byte ProfileIndex;

	public byte Reserved;

	public sbyte Rx1GainCodeTempLessThanNeg30;

	public sbyte Rx1GainCodeTempNeg30ToNeg20;

	public sbyte Rx1GainCodeTempNeg20ToNeg10;

	public sbyte Rx1GainCodeTempNeg10To0;

	public byte Rx1GainCodeTemp0To10;

	public byte Rx1GainCodeTemp10To20;

	public byte Rx1GainCodeTemp20To30;

	public byte Rx1GainCodeTemp30To40;

	public byte Rx1GainCodeTemp40To50;

	public byte Rx1GainCodeTemp50To60;

	public byte Rx1GainCodeTemp60To70;

	public byte Rx1GainCodeTemp70To80;

	public byte Rx1GainCodeTemp80To90;

	public byte Rx1GainCodeTemp90To100;

	public byte Rx1GainCodeTemp100To110;

	public byte Rx1GainCodeTemp110To120;

	public byte Rx1GainCodeTemp120To130;

	public byte Rx1GainCodeTemp130To140;

	public byte Rx1GainCodeTempMoreThan140;

	public byte Reserved2;

	public byte Reserved3;

	public byte Reserved4;
}
