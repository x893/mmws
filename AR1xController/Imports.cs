using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace AR1xController
{
	public static class Imports
	{
		[DllImport("RF_API.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int DisconnectRFDCCard();

		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void* memcpy(void* dest, void* src, ulong count);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ethernetConnect(string pIpAddr, uint configPort, uint deviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ethernetDisconnect();

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int registerTDAStatusCallback(MulticastDelegate eventData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_setSystemType(int systemType);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int setWidthAndHeight(byte devSelection, uint width, uint height);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TDACreateApplication();

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int showCPUStats();

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int sendFramePeriodicitySync(uint periodicity);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int sendNumAllocatedFiles(uint numAllocatedFiles);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int enableDataPackaging(uint enablePackaging);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int setSessionDirectory(string sessionDirectory);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int startRecord();

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int stopRecord();

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpioGetValue(uint DeviceMap, uint gpioBase, uint gpioPin);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int gpioSetValue(uint DeviceMap, uint gpioBase, uint gpioPin, uint gpioVal);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int getWidthAndHeight(byte DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NumFramesToCapture(uint numFrames);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetInternalCfg(uint DeviceMap, uint memAddr, uint value);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_GetInternalCfg(uint DeviceMap, uint memAddr, IntPtr value);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_GetInternalRfCfg(uint DeviceMap, ushort profileId, uint memAddr, IntPtr value);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetInternalRfCfg(uint DeviceMap, ushort profileId, uint memAddr, uint value);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_WarmReset(int status);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_FullReset(int status);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SOPControl(int SOPmode);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int rlsGetNumofDevices(IntPtr RadarDevices);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_I2CWrite(uint DeviceMap, char slaveAddress, char regAddress, byte msbData, byte lsbData, int datasize);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_I2CRead(uint DeviceMap, char slaveAddress, char regAddress, IntPtr msbData, IntPtr lsbData, int datasize);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_OpenI2cIrqIf(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_CloseI2cIrqIf(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_OpenBoardControlIf();

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_CloseBoardControlIf();

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_OpenGenericGpioIf();

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_CloseGenericGpioIf();

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_OpenBoardControlIf(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_CloseBoardControlIf(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_OpenGenericGpioIf(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_CloseGenericGpioIf(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_FullReset(uint DeviceMap, int status);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SOPControl(uint DeviceMap, int SOPmode);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_PowerOn(uint DeviceId, char crcType, uint ackTimeout, char trasportType, uint portNum, MulticastDelegate callbk);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_GetGpadcData(uint DeviceId, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetGpAdcConfig(uint DeviceId, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetDynamicPowerSaveMode(uint DeviceId, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_DeviceAddDevices(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfSetTempSensTrimCfg(uint DeviceId, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_AdvanceFrameConfig(uint DeviceId, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetDynamicCharReportConfig(uint DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_GetTemperatureReport(uint DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_GetDfeRxStatistics(uint DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetCalibMonConfig(uint DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetCalibDisableConfig(uint DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfSetPdTrimConfig(uint DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfSetMeasTxPowerConfig(uint DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfSetMeasPdPowerConfig(uint DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfSynthLinMonConfig(byte DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetLoopBckBurstCfg(byte DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetSubFrameStart(byte DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetDynChirpCfg(byte DeviceMap, ushort segCnt, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_DevicePmicClkConfig(byte DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_DeviceMcuClkConfig(byte DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_DeviceSetTestPatternConfig(byte DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetInterChirpBlkCtrl(byte DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfCalibDataRestore(byte DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfCalibDataStore(byte DeviceMap, out CalibDataSaveReport OutData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfPhShiftCalibDataRestore(byte DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfPhShiftCalibDataStore(byte DeviceMap, out PhaseShifterClalibGetConfig OutData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetDynPerChirpPhShifterCfg(byte DeviceMap, ushort segCnt, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetDynChirpEn(byte DeviceMap, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_GetStaticCharData(uint deviceId, IntPtr inData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfEnable(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll")]
		public static extern int RadarLinkImpl_PowerOff();

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SwapResetAndPowerOn(uint DeviceId);

		[DllImport("RadarLinkDLL.dll")]
		public static extern int RadarLinkImpl_RemoveDevices(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfInit(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetMiscConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetCalMonFreqLimitConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetRfDevConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfTxFreqPwrLimitConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetCalMonTimeUnitConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_EnableDigMon(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfDigMonPeriodicConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_DeviceLatentFaultTests(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_DeviceEnablePeriodicTests(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_TxGainTempLutSet(byte DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int rlTxGainTempLutGet(byte DeviceMap, IntPtr data, out TxGainTempLutReportData OutData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int rlRxGainTempLutSet(byte DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int rlRxGainTempLutGet(byte DeviceMap, IntPtr data, out RxGainTempLutReportData OutData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfAnaMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfRxNoiseMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfTxBallbreakMonConfig(byte DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfRxGainPhMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfTxGainPhaseMismatchMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfAnaFaultInjConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfRxIfSatMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfPllContrlVoltMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfDualClkCompMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfRxSigImgMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfSynthFreqMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfRxMixerInPwrConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfExtAnaSignalsMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfTxPowrMonConfig(byte DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfTxIntAnaSignalsMonConfig(byte DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfRxIntAnaSignalsMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfPmClkLoIntAnaSignalsMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfGpadcIntAnaSignalsMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfTempMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfRxIfStageMonConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfInterRxGainPhaseConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfTxBpmMonConfig(byte DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RfInitCalibConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_RunTimeCalibConf(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SensorStart(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SensorStop(uint DeviceMap);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_ChannelConfig(byte DeviceMap, IntPtr Data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_ChirpConfig(uint DeviceMap, ushort chirpStartIdx, ushort chirpEndIdx, ushort profileId, uint startFreqVar, short freqSlopeVar, ushort idleTimeVar, ushort adcStartTimeVar, ushort txEnable);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_FrameConfig(uint DeviceMap, ushort chirpStartIdx, ushort chirpEndIdx, ushort frameCount, ushort loopCount, uint periodicity, uint triggerDelay, uint numAdcSamples, byte numDummyChirp, ushort TriggerSelect, ushort FrameControl);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_AdvChirpConfig(uint DeviceMap, ushort chirpParamIdx, byte resetMode, byte patternMode, ushort resetPeriod, ushort paramUpdatePeriod, int fixedDeltaInc);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_NfModeConfig(ushort nfMode);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_AdcOutConfig(byte DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_ProfileConfig(byte DeviceMap, IntPtr Data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_ContModeConfig(byte deviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_ContModeEnable(uint DeviceMap, ushort contModeEn);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_ContStreamingModeConfig(uint DeviceMap, ushort contStreamModeEn, ushort dataTransSize);

		[DllImport("RadarLinkDLL.dll")]
		public static extern byte RadarLinkImpl_IsConnected();

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_CustomCommand(uint DeviceMap, ushort protDir, ushort protMsgType, ushort protMsgId, ushort protNsbc, ushort protSbId, ushort protSbLen, IntPtr sbData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetProtocol(ushort protTest);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_LowPowerConfig(uint DeviceMap, ushort lpAdcMode);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_EnableRfLdoBypass(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_DeviceGetRfVersion(uint DeviceMap, out struct06b outData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_DeviceGetMssVersion(uint DeviceMap, out MSSFwVersion outData);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_FileDownload(uint DeviceMap, ushort remChunks, ushort chunkLen, IntPtr chunk);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_GetVersion(IntPtr masterVer);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_GetRadarLinkVersion(IntPtr masterVer);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetTestSource(uint DeviceMap, short obj1PosX, short obj1PosY, short obj1PosZ, short obj1VelX, short obj1VelY, short obj1VelZ, short obj1BMinX, short obj1BMinY, short obj1BMinZ, short obj1BMaxX, short obj1BMaxY, short obj1BMaxZ, short obj1Sig, short obj2PosX, short obj2PosY, short obj2PosZ, short obj2VelX, short obj2VelY, short obj2VelZ, short obj2BMinX, short obj2BMinY, short obj2BMinZ, short obj2BMaxX, short obj2BMaxY, short obj2BMaxZ, short obj2Sig, char obj1AntPosRx1X, char obj1AntPosRx1Z, char obj1AntPosRx2X, char obj1AntPosRx2Z, char obj1AntPosRx3X, char obj1AntPosRx3Z, char obj1AntPosRx4X, char obj1AntPosRx4Z, char obj1AntPosTx1X, char obj1AntPosTx1Z, char obj1AntPosTx2X, char obj1AntPosTx2Z, char obj1AntPosTx3X, char obj1AntPosTx3Z);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_DataFmtConfig(uint DeviceMap, ushort p1, ushort adcBits, ushort adcFmt, char iqSwapSel, char chInterleave);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_DataPathConfig(uint DeviceMap, byte intfSel, byte p2, byte p3, byte cqConfig, byte cq0TransSize, byte cq1TransSize, byte cq2TransSize, byte reserved);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_LaneConfig(uint DeviceMap, ushort laneEn);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_LvdsClkConfig(uint DeviceMap, char laneClk, char dataRate);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_DeviceReadMemBlock(byte DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_Csi2Config(uint DeviceMap, uint lanePosPolSel);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_LvdsLaneConfig(uint DeviceMap, ushort laneFmtMap, ushort laneParamCfg);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetHsiClock(uint DeviceMap, ushort hsiClk);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_EnableTestSource(uint DeviceMap, ushort enable, ushort mode);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_BpmCommonConfig(uint DeviceMap, ushort srcSel, ushort kCountSelStart, ushort kCountSelEnd, ushort kCnt, int kCounterStartOffset, int kCounterEndOffset);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_BpmChirpConfig(uint DeviceMap, ushort chirpStartIdx, ushort chirpEndIdx, ushort constBpmVal);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetPhaseShiftConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetAdvBpmPattern(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetPALoopbackConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetPSLoopbackConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetProgFiltConfig(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetProgFiltCoeffRam(uint DeviceMap, IntPtr data);

		[DllImport("RadarLinkDLL.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int RadarLinkImpl_SetIFLoopbackConfig(uint DeviceMap, IntPtr data);

		public static bool ImportFunctions(string dll_path)
		{
			if (string.IsNullOrEmpty(dll_path) || !File.Exists(dll_path))
			{
				GlobalRef.GuiManager.ErrorAbort(string.Format("Failed loading Trioscope dll from '{0}'. The file could not be found.", dll_path));
				return false;
			}
			Imports.iClearFuncDelegates();
			Imports.DllPath = dll_path;
			Imports.m_pDll = NativeImports.LoadLibrary(dll_path);
			if (Imports.m_pDll == IntPtr.Zero)
			{
				GlobalRef.GuiManager.ErrorAbort(string.Format("Failed loading Trioscope dll from '{0}'", dll_path));
				return false;
			}
			try
			{
				Delegate @delegate;
				if (Imports.iLoadFunc("Calling_CTrioScopeDll", typeof(Imports.del_Calling_CTrioScopeDll), out @delegate))
				{
					Imports.Calling_CTrioScopeDll = (Imports.del_Calling_CTrioScopeDll)@delegate;
				}
				if (Imports.iLoadFunc("Calling_DestructorCTrioScopeDll", typeof(Imports.del_Calling_DestructorCTrioScopeDll), out @delegate))
				{
					Imports.Calling_DestructorCTrioScopeDll = (Imports.del_Calling_DestructorCTrioScopeDll)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_ConnectTarget", typeof(Imports.del_Calling_ATE_ConnectTarget), out @delegate))
				{
					Imports.Calling_ATE_ConnectTarget = (Imports.del_Calling_ATE_ConnectTarget)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_DisconnectTarget", typeof(Imports.del_Calling_ATE_DisconnectTarget), out @delegate))
				{
					Imports.Calling_ATE_DisconnectTarget = (Imports.del_Calling_ATE_DisconnectTarget)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_DownloadFW", typeof(Imports.delegate027f), out @delegate))
				{
					Imports.f0002a8 = (Imports.delegate027f)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ReadAddr_Single", typeof(Imports.del_Calling_ReadAddr_Single), out @delegate))
				{
					Imports.Calling_ReadAddr_Single = (Imports.del_Calling_ReadAddr_Single)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ReadOcp_Single", typeof(Imports.del_Calling_ReadOcp_Single), out @delegate))
				{
					Imports.Calling_ReadOcp_Single = (Imports.del_Calling_ReadOcp_Single)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ReadAddr_Multi", typeof(Imports.del_Calling_ReadAddr_Multi), out @delegate))
				{
					Imports.Calling_ReadAddr_Multi = (Imports.del_Calling_ReadAddr_Multi)@delegate;
				}
				if (Imports.iLoadFunc("Calling_WriteAddr_Single", typeof(Imports.del_Calling_WriteAddr_Single), out @delegate))
				{
					Imports.Calling_WriteAddr_Single = (Imports.del_Calling_WriteAddr_Single)@delegate;
				}
				if (Imports.iLoadFunc("Calling_WriteOcp_Single", typeof(Imports.del_Calling_WriteOcp_Single), out @delegate))
				{
					Imports.Calling_WriteOcp_Single = (Imports.del_Calling_WriteOcp_Single)@delegate;
				}
				if (Imports.iLoadFunc("Calling_WriteAddr_Multi", typeof(Imports.del_Calling_WriteAddr_Multi), out @delegate))
				{
					Imports.Calling_WriteAddr_Multi = (Imports.del_Calling_WriteAddr_Multi)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_GetFwDownloadProgress", typeof(Imports.del_Calling_ATE_GetFwDownloadProgress), out @delegate))
				{
					Imports.Calling_ATE_GetFwDownloadProgress = (Imports.del_Calling_ATE_GetFwDownloadProgress)@delegate;
				}
				if (Imports.iLoadFunc("Calling_SetFwFilePath", typeof(Imports.del_Calling_SetFwFilePath), out @delegate))
				{
					Imports.Calling_SetFwFilePath = (Imports.del_Calling_SetFwFilePath)@delegate;
				}
				if (Imports.iLoadFunc("Calling_GetFwFilePath", typeof(Imports.del_Calling_GetFwFilePath), out @delegate))
				{
					Imports.Calling_GetFwFilePath = (Imports.del_Calling_GetFwFilePath)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_Read_INI_File", typeof(Imports.delegate0289), out @delegate))
				{
					Imports.f0002a9 = (Imports.delegate0289)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_SetNVSPath", typeof(Imports.delegate028a), out @delegate))
				{
					Imports.f0002aa = (Imports.delegate028a)@delegate;
				}
				if (Imports.iLoadFunc("Calling_SetFrefClk", typeof(Imports.del_Calling_SetFrefClk), out @delegate))
				{
					Imports.Calling_SetFrefClk = (Imports.del_Calling_SetFrefClk)@delegate;
				}
				if (Imports.iLoadFunc("Calling_SetIniFilePath", typeof(Imports.del_Calling_SetIniFilePath), out @delegate))
				{
					Imports.Calling_SetIniFilePath = (Imports.del_Calling_SetIniFilePath)@delegate;
				}
				if (Imports.iLoadFunc("Calling_TrioScopeTest", typeof(Imports.del_Calling_TrioScopeTest), out @delegate))
				{
					Imports.Calling_TrioScopeTest = (Imports.del_Calling_TrioScopeTest)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_GetSingleCalibStatus", typeof(Imports.del_Calling_ATE_GetSingleCalibStatus), out @delegate))
				{
					Imports.Calling_ATE_GetSingleCalibStatus = (Imports.del_Calling_ATE_GetSingleCalibStatus)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_Channel", typeof(Imports.del_Calling_ATE_Channel), out @delegate))
				{
					Imports.Calling_ATE_Channel = (Imports.del_Calling_ATE_Channel)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_GetCalibsStatus", typeof(Imports.del_Calling_ATE_GetCalibsStatus), out @delegate))
				{
					Imports.Calling_ATE_GetCalibsStatus = (Imports.del_Calling_ATE_GetCalibsStatus)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_TxPacket", typeof(Imports.del_Calling_ATE_TxPacket), out @delegate))
				{
					Imports.Calling_ATE_TxPacket = (Imports.del_Calling_ATE_TxPacket)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_TXStop", typeof(Imports.delegate0292), out @delegate))
				{
					Imports.f0002ab = (Imports.delegate0292)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_TxTone", typeof(Imports.del_Calling_ATE_TxTone), out @delegate))
				{
					Imports.Calling_ATE_TxTone = (Imports.del_Calling_ATE_TxTone)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_RxStatistics", typeof(Imports.del_Calling_ATE_RxStatistics), out @delegate))
				{
					Imports.Calling_ATE_RxStatistics = (Imports.del_Calling_ATE_RxStatistics)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_GetRadioError", typeof(Imports.del_Calling_ATE_GetRadioError), out @delegate))
				{
					Imports.Calling_ATE_GetRadioError = (Imports.del_Calling_ATE_GetRadioError)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_GetTemperature", typeof(Imports.del_Calling_ATE_GetTemperature), out @delegate))
				{
					Imports.Calling_ATE_GetTemperature = (Imports.del_Calling_ATE_GetTemperature)@delegate;
				}
				if (Imports.iLoadFunc("del_Calling_ATE_GetTxGainLutTemperature", typeof(Imports.del_Calling_ATE_GetTxGainLutTemperature), out @delegate))
				{
					Imports.Calling_ATE_GetTxGainLutTemperature = (Imports.del_Calling_ATE_GetTxGainLutTemperature)@delegate;
				}
				if (Imports.iLoadFunc("del_Calling_ATE_GetBSSRFFwVersion", typeof(Imports.delegate0278), out @delegate))
				{
					Imports.f0002ac = (Imports.delegate0278)@delegate;
				}
				if (Imports.iLoadFunc("del_Calling_ATE_GetMSSFwVersion", typeof(Imports.delegate0279), out @delegate))
				{
					Imports.f0002ad = (Imports.delegate0279)@delegate;
				}
				if (Imports.iLoadFunc("del_Calling_ATE_GetRxGainLutTemperature", typeof(Imports.del_Calling_ATE_GetRxGainLutTemperature), out @delegate))
				{
					Imports.Calling_ATE_GetRxGainLutTemperature = (Imports.del_Calling_ATE_GetRxGainLutTemperature)@delegate;
				}
				if (Imports.iLoadFunc("del_Calling_ATE_CalibDataStore", typeof(Imports.del_Calling_ATE_CalibDataStore), out @delegate))
				{
					Imports.Calling_ATE_CalibDataStore = (Imports.del_Calling_ATE_CalibDataStore)@delegate;
				}
				if (Imports.iLoadFunc("del_Calling_ATE_PhaseShiftCalibDataStore", typeof(Imports.del_Calling_ATE_PhaseShiftCalibDataStore), out @delegate))
				{
					Imports.Calling_ATE_PhaseShiftCalibDataStore = (Imports.del_Calling_ATE_PhaseShiftCalibDataStore)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_GetVbat", typeof(Imports.del_Calling_ATE_GetVbat), out @delegate))
				{
					Imports.Calling_ATE_GetVbat = (Imports.del_Calling_ATE_GetVbat)@delegate;
				}
				if (Imports.iLoadFunc("Calling_IsFirmwareRunning", typeof(Imports.del_Calling_IsFirmwareRunning), out @delegate))
				{
					Imports.Calling_IsFirmwareRunning = (Imports.del_Calling_IsFirmwareRunning)@delegate;
				}
				if (Imports.iLoadFunc("Calling_IsConnected", typeof(Imports.del_Calling_IsConnected), out @delegate))
				{
					Imports.Calling_IsConnected = (Imports.del_Calling_IsConnected)@delegate;
				}
				if (Imports.iLoadFunc("Calling_GetDllVersion", typeof(Imports.del_Calling_GetDllVersion), out @delegate))
				{
					Imports.Calling_GetDllVersion = (Imports.del_Calling_GetDllVersion)@delegate;
				}
				if (Imports.iLoadFunc("Calling_GetFW_Version", typeof(Imports.del_Calling_GetFW_Version), out @delegate))
				{
					Imports.Calling_GetFW_Version = (Imports.del_Calling_GetFW_Version)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_PowerMode", typeof(Imports.del_Calling_ATE_PowerMode), out @delegate))
				{
					Imports.Calling_ATE_PowerMode = (Imports.del_Calling_ATE_PowerMode)@delegate;
				}
				if (Imports.iLoadFunc("Calling_SetSwFlowControl", typeof(Imports.del_Calling_SetSwFlowControl), out @delegate))
				{
					Imports.Calling_SetSwFlowControl = (Imports.del_Calling_SetSwFlowControl)@delegate;
				}
				if (Imports.iLoadFunc("Calling_ATE_TxGainAdjust", typeof(Imports.del_Calling_ATE_TxGainAdjust), out @delegate))
				{
					Imports.Calling_ATE_TxGainAdjust = (Imports.del_Calling_ATE_TxGainAdjust)@delegate;
				}
				if (Imports.iLoadFunc("Calling_SetTimeOut", typeof(Imports.del_Calling_SetTimeOut), out @delegate))
				{
					Imports.Calling_SetTimeOut = (Imports.del_Calling_SetTimeOut)@delegate;
				}
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.ErrorAbort(string.Format("Failed to load Trioscope dll functions.\nerror message: {0}", ex.Message));
				return false;
			}
			return true;
		}

		private static void iClearFuncDelegates()
		{
			Imports.Calling_CTrioScopeDll = null;
			Imports.Calling_DestructorCTrioScopeDll = null;
			Imports.Calling_ATE_ConnectTarget = null;
			Imports.Calling_ATE_DisconnectTarget = null;
			Imports.f0002a8 = null;
			Imports.Calling_ReadAddr_Single = null;
			Imports.Calling_ReadOcp_Single = null;
			Imports.Calling_ReadAddr_Multi = null;
			Imports.Calling_WriteAddr_Single = null;
			Imports.Calling_WriteOcp_Single = null;
			Imports.Calling_WriteAddr_Multi = null;
			Imports.Calling_ATE_GetFwDownloadProgress = null;
			Imports.Calling_SetFwFilePath = null;
			Imports.Calling_GetFwFilePath = null;
			Imports.f0002a9 = null;
			Imports.Calling_TrioScopeTest = null;
			Imports.Calling_ATE_GetSingleCalibStatus = null;
			Imports.Calling_ATE_Channel = null;
			Imports.Calling_ATE_TxGainAdjust = null;
			Imports.Calling_TrioScopeTest = null;
			Imports.Calling_ATE_RxStatistics = null;
			Imports.Calling_ATE_GetRadioError = null;
			Imports.Calling_ATE_GetCalibsStatus = null;
			Imports.Calling_ATE_TxTone = null;
			Imports.Calling_ATE_GetTemperature = null;
			Imports.Calling_ATE_GetVbat = null;
			Imports.Calling_IsFirmwareRunning = null;
			Imports.Calling_IsConnected = null;
			Imports.Calling_GetDllVersion = null;
			Imports.Calling_GetFW_Version = null;
			Imports.Calling_ATE_PowerMode = null;
			Imports.Calling_SetSwFlowControl = null;
			Imports.Calling_SetTimeOut = null;
		}

		private static bool iLoadFunc(string func_name, Type del_type, out Delegate func_del)
		{
			func_del = null;
			IntPtr procAddress = NativeImports.GetProcAddress(Imports.m_pDll, func_name);
			if (procAddress == IntPtr.Zero)
			{
				return false;
			}
			func_del = Marshal.GetDelegateForFunctionPointer(procAddress, del_type);
			return true;
		}

		public static bool FreeLibrary()
		{
			bool flag = true;
			if (Imports.m_pDll != IntPtr.Zero)
			{
				try
				{
					flag = NativeImports.FreeLibrary(Imports.m_pDll);
					if (flag)
					{
						Imports.m_pDll = IntPtr.Zero;
						Imports.iClearFuncDelegates();
					}
					else
					{
						GlobalRef.GuiManager.ErrorAbort("Failed to free loaded Trioscope DLL.");
					}
				}
				catch (Exception ex)
				{
					GlobalRef.GuiManager.ErrorAbort(string.Format("Failed to free loaded Trioscope DLL with exception:\n{0}", ex.Message));
				}
			}
			return flag;
		}

		private static IntPtr m_pDll;

		public static string DllPath;

		public static Imports.del_Calling_CTrioScopeDll Calling_CTrioScopeDll;

		public static Imports.del_Calling_DestructorCTrioScopeDll Calling_DestructorCTrioScopeDll;

		public static Imports.del_Calling_ATE_ConnectTarget Calling_ATE_ConnectTarget;

		public static Imports.del_Calling_ATE_DisconnectTarget Calling_ATE_DisconnectTarget;

		public static Imports.delegate027f f0002a8;

		public static Imports.del_Calling_ReadAddr_Single Calling_ReadAddr_Single;

		public static Imports.del_Calling_ReadOcp_Single Calling_ReadOcp_Single;

		public static Imports.del_Calling_ReadAddr_Multi Calling_ReadAddr_Multi;

		public static Imports.del_Calling_WriteAddr_Single Calling_WriteAddr_Single;

		public static Imports.del_Calling_WriteOcp_Single Calling_WriteOcp_Single;

		public static Imports.del_Calling_WriteAddr_Multi Calling_WriteAddr_Multi;

		public static Imports.del_Calling_ATE_GetFwDownloadProgress Calling_ATE_GetFwDownloadProgress;

		public static Imports.del_Calling_SetFwFilePath Calling_SetFwFilePath;

		public static Imports.del_Calling_GetFwFilePath Calling_GetFwFilePath;

		public static Imports.delegate0289 f0002a9;

		public static Imports.delegate028a f0002aa;

		public static Imports.del_Calling_SetFrefClk Calling_SetFrefClk;

		public static Imports.del_Calling_SetIniFilePath Calling_SetIniFilePath;

		public static Imports.del_Calling_TrioScopeTest Calling_TrioScopeTest;

		public static Imports.del_Calling_ATE_GetSingleCalibStatus Calling_ATE_GetSingleCalibStatus;

		public static Imports.del_Calling_ATE_Channel Calling_ATE_Channel;

		public static Imports.del_Calling_ATE_GetCalibsStatus Calling_ATE_GetCalibsStatus;

		public static Imports.del_Calling_ATE_TxPacket Calling_ATE_TxPacket;

		public static Imports.delegate0292 f0002ab;

		public static Imports.del_Calling_ATE_TxTone Calling_ATE_TxTone;

		public static Imports.del_Calling_ATE_RxStatistics Calling_ATE_RxStatistics;

		public static Imports.del_Calling_ATE_GetRadioError Calling_ATE_GetRadioError;

		public static Imports.del_Calling_ATE_GetTemperature Calling_ATE_GetTemperature;

		public static Imports.del_Calling_ATE_GetTxGainLutTemperature Calling_ATE_GetTxGainLutTemperature;

		public static Imports.delegate0278 f0002ac;

		public static Imports.delegate0279 f0002ad;

		public static Imports.del_Calling_ATE_GetRxGainLutTemperature Calling_ATE_GetRxGainLutTemperature;

		public static Imports.del_Calling_ATE_CalibDataStore Calling_ATE_CalibDataStore;

		public static Imports.del_Calling_ATE_PhaseShiftCalibDataStore Calling_ATE_PhaseShiftCalibDataStore;

		public static Imports.del_Calling_ATE_GetVbat Calling_ATE_GetVbat;

		public static Imports.del_Calling_IsFirmwareRunning Calling_IsFirmwareRunning;

		public static Imports.del_Calling_IsConnected Calling_IsConnected;

		public static Imports.del_Calling_GetDllVersion Calling_GetDllVersion;

		public static Imports.del_Calling_GetFW_Version Calling_GetFW_Version;

		public static Imports.del_Calling_ATE_PowerMode Calling_ATE_PowerMode;

		public static Imports.del_Calling_SetSwFlowControl Calling_SetSwFlowControl;

		public static Imports.del_Calling_ATE_TxGainAdjust Calling_ATE_TxGainAdjust;

		public static Imports.del_Calling_SetTimeOut Calling_SetTimeOut;

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_CalibDataStore(out CalibDataSaveReport CalibDataSaveReportParam);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_PhaseShiftCalibDataStore(out PhaseShifterClalibGetConfig PhaseShifterClalibGetConfigParam);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_GetTxGainLutTemperature(out TxGainTempLutReportData TxGainTempLutReportDataParam);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_GetRxGainLutTemperature(out RxGainTempLutReportData RxGainTempLutReportDataParam);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int delegate0278(out struct06b p0);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int delegate0279(out MSSFwVersion MSSFwVersionParam);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr del_Calling_CTrioScopeDll();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void del_Calling_DestructorCTrioScopeDll();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_ConnectTarget(uint eConnType, uint com, uint baud_rate, uint time_out, uint h_wnd_dst);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ConnectDevice(uint eConnType, uint com, uint baud_rate, uint time_out, uint board_type, uint h_wnd_dst);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_DisconnectTarget();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int delegate027f(string file_path);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ReadAddr_Single(uint abs_addr, out uint value);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ReadOcp_Single(uint abs_addr, out uint value);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ReadAddr_Multi(uint abs_addr, uint[] values, uint num_of_dwords);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_WriteAddr_Single(uint abs_addr, uint value);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_WriteOcp_Single(uint abs_addr, uint value);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_WriteAddr_Multi(uint abs_addr, uint[] values, uint num_of_dwords, bool blBulk);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate double del_Calling_ATE_GetFwDownloadProgress();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_SetFwFilePath(string file_path);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_GetFwFilePath(StringBuilder file_path);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int delegate0289(string Ini_file_path, StringBuilder strError, bool enableGetFEMType);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate string delegate028a(string Nvs_file_path);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void del_Calling_SetFrefClk(uint manual_fref_clock, bool use_ini_file_fref_clock);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_SetIniFilePath(string Ini_file_path);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_TrioScopeTest(uint eTestCmd, IntPtr pTestCmdParams);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_GetSingleCalibStatus(byte calibration_type, out sbyte calibration_error);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_Channel(sbyte band, byte channel);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_GetCalibsStatus(short[] calibration_errors);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_TxPacket(uint delay, uint rate, ushort size, ushort amount, int power, ushort seed, sbyte packetMode, sbyte dcfOnOff, sbyte p8, sbyte preamble, sbyte type, sbyte scrambler, sbyte enableCLPC, sbyte seqNumMode, byte[] iSrcMacAddr, byte[] iDstMacAddr);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int delegate0292();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_TxTone(uint power, uint tone_type, uint ppa_step, uint ToneNumberSingleTones, uint ToneNumberTwoTones, uint UseDigitalDC, uint invert, uint ElevenNSpan, uint DigitalDC, uint AnalogDCFine, uint AnalogDCCoarse);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_Start_RX_Simulation();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int delegate0295(uint iparams);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_RxStatistics(out uint ReceivedValidPacketsNumber, out uint ReceivedFcsErrorPacketsNumber, out uint ReceivedPlcpErrorPacketsNumber, out uint SeqNumMissCount, out short AverageSnr, out short AverageRssi, out short AverageEvm, out uint oBasePacketId, out uint ioNumberOfPackets, out uint oNumberOfMissedPackets);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void del_Calling_ATE_GetRadioError(short radio_status, StringBuilder err_msg);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_GetTemperature(out sbyte p_temperature);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_GetVbat(out double p_Vbat);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_IsFirmwareRunning();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate bool del_Calling_IsConnected();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void del_Calling_GetDllVersion(string dll_name, StringBuilder p1);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_GetFW_Version(StringBuilder dll_name);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_PowerMode(byte power_mode);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void del_Calling_SetSwFlowControl(bool IsSwFlowControl);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_ATE_TxGainAdjust(int power, byte use_limit);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int del_Calling_SetTimeOut(uint timeout);
	}
}
