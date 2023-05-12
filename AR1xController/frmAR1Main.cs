using AR1xController.GUI;
using MathWorks.MATLAB.NET.Arrays;
using MatlabPostProcGui;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace AR1xController
{
    public partial class frmAR1Main : DockContent
    {
        public bool FPGA { get; set; }

        public ConnectTab ConnectTab
        {
            get
            {
                return m_ConnectTab;
            }
            set
            {
                m_ConnectTab = value;
            }
        }

        public RFDataCaptureCard RFDataCaptureCard
        {
            get
            {
                return m_RFDataCaptureCard;
            }
            set
            {
                m_RFDataCaptureCard = value;
            }
        }

        public TDAxxCaptureCard TDAxxCaptureCard
        {
            get
            {
                return m_TDAxxCaptureCard;
            }
            set
            {
                m_TDAxxCaptureCard = value;
            }
        }

        public StaticConfigTab StaticConfigTab
        {
            get
            {
                return m_StaticConfigTab;
            }
            set
            {
                m_StaticConfigTab = value;
            }
        }

        public DataConfigTab DataConfigTab
        {
            get
            {
                return m_DataConfigTab;
            }
            set
            {
                m_DataConfigTab = value;
            }
        }

        public ChirpConfigTab ChirpConfigTab
        {
            get
            {
                return m_ChirpConfigTab;
            }
            set
            {
                m_ChirpConfigTab = value;
            }
        }

        public InterChirpBlockControls InterChirpBlockControls
        {
            get
            {
                return m_InterChirpBlockControls;
            }
            set
            {
                m_InterChirpBlockControls = value;
            }
        }

        public TestSourceTab TestSourceTab
        {
            get
            {
                return m_TestSourceTab;
            }
            set
            {
                m_TestSourceTab = value;
            }
        }

        public ContStreamingTab ContStreamingTab
        {
            get
            {
                return m_ContStreamingTab;
            }
            set
            {
                m_ContStreamingTab = value;
            }
        }

        public RegOpeTab RegOpeTab
        {
            get
            {
                return m_RegOpeTab;
            }
            set
            {
                m_RegOpeTab = value;
            }
        }

        public BpmConfigTab BpmConfigTab
        {
            get
            {
                return m_BpmConfigTab;
            }
            set
            {
                m_BpmConfigTab = value;
            }
        }

        public RFStatusTab RFStatusTab
        {
            get
            {
                return m_RFStatusTab;
            }
            set
            {
                m_RFStatusTab = value;
            }
        }

        public PMICTab PMICTab
        {
            get
            {
                return m_PMICTab;
            }
            set
            {
                m_PMICTab = value;
            }
        }

        public AdvanceFrameConfigTab AdvanceFrameConfigTab
        {
            get
            {
                return m_AdvanceFrameConfigTab;
            }
            set
            {
                m_AdvanceFrameConfigTab = value;
            }
        }

        public RampTimingCfgTab RampTimingCfgTab
        {
            get
            {
                return m_RampTimingCfgTab;
            }
            set
            {
                m_RampTimingCfgTab = value;
            }
        }

        public Import_Export Import_Export
        {
            get
            {
                return m_Import_Export;
            }
            set
            {
                m_Import_Export = value;
            }
        }

        public ClibTab ClibTab
        {
            get
            {
                return m_ClibTab;
            }
            set
            {
                m_ClibTab = value;
            }
        }

        public LoopBack LoopBack
        {
            get
            {
                return m_LoopBack;
            }
            set
            {
                m_LoopBack = value;
            }
        }

        public ExternalFilterProgramming ExternalFilterProgramming
        {
            get
            {
                return m_ExternalFilterProgramming;
            }
            set
            {
                m_ExternalFilterProgramming = value;
            }
        }

        public CalibConfig CalibConfig
        {
            get
            {
                return m_CalibConfig;
            }
            set
            {
                m_CalibConfig = value;
            }
        }

        public MonitoringConfig MonitoringConfig
        {
            get
            {
                return m_MonitoringConfig;
            }
            set
            {
                m_MonitoringConfig = value;
            }
        }

        public AnalogMonConfig AnalogMonConfig
        {
            get
            {
                return m_AnalogMonConfig;
            }
            set
            {
                m_AnalogMonConfig = value;
            }
        }

        public AnalogMon2Config AnalogMon2Config
        {
            get
            {
                return m_AnalogMon2Config;
            }
            set
            {
                m_AnalogMon2Config = value;
            }
        }

        public ClockOutConfig ClockOutConfig
        {
            get
            {
                return m_ClockOutConfig;
            }
            set
            {
                m_ClockOutConfig = value;
            }
        }

        public TxRxGainTempLUTCfg TxRxGainTempLUTCfg
        {
            get
            {
                return m_TxRxGainTempLUTCfg;
            }
            set
            {
                m_TxRxGainTempLUTCfg = value;
            }
        }

        public WinSCPTransfer WinSCPTransfer
        {
            get
            {
                return m_winSCPTransfer;
            }
            set
            {
                m_winSCPTransfer = value;
            }
        }

        public c0000b1 p000001
        {
            get
            {
                return f0001a7;
            }
            set
            {
                f0001a7 = value;
            }
        }

        public MSSMonitoring MSSMonitoring
        {
            get
            {
                return m_MSSMonitoring;
            }
            set
            {
                m_MSSMonitoring = value;
            }
        }

        public DynamicChirpConfig DynamicChirpConfig
        {
            get
            {
                return m_DynamicChirpConfig;
            }
            set
            {
                m_DynamicChirpConfig = value;
            }
        }

        public CalibDataReStore CalibDataReStore
        {
            get
            {
                return m_CalibDataReStore;
            }
            set
            {
                m_CalibDataReStore = value;
            }
        }

        public ProtocolTab ProtocolTab
        {
            get
            {
                return m_ProtocolTab;
            }
            set
            {
                m_ProtocolTab = value;
            }
        }

        public System.Windows.Forms.Timer CheckConnectionTimer
        {
            get
            {
                return m_timerCheckConnection;
            }
        }

        public MatlabPostProcGUIClass MatlabPostProcGUIClass
        {
            get
            {
                return MatlabPostProcGuiInstance;
            }
            set
            {
                MatlabPostProcGuiInstance = value;
            }
        }

        public GuiManager GuiManager
        {
            get
            {
                return m_GuiManager;
            }
            set
            {
                m_GuiManager = value;
            }
        }

        public BoardStatus BoardStatus
        {
            get
            {
                return m_BoardStatus;
            }
            set
            {
                m_BoardStatus = value;
            }
        }

        public TabControl TabCtrl
        {
            get
            {
                return m_Tbc;
            }
        }

        public bool MainDisabled
        {
            get
            {
                return m_MainDisabled;
            }
            set
            {
                m_MainDisabled = value;
            }
        }

        public bool LoadingForm
        {
            get
            {
                return m_bLoadingForm;
            }
            set
            {
                m_bLoadingForm = value;
            }
        }

        public bool SettingsLoaded
        {
            get
            {
                return m_bSettingsLoaded;
            }
            set
            {
                m_bSettingsLoaded = value;
            }
        }

        public ChannelTable ChannelTable
        {
            get
            {
                return m_ChannelTable;
            }
        }

        public AntennaMode LastAntennaMode
        {
            get
            {
                return m_AntennaMode;
            }
            set
            {
                m_AntennaMode = value;
            }
        }

        public string SettingsOutputPath
        {
            get
            {
                return m_SettingsOutputPath;
            }
            set
            {
                m_SettingsOutputPath = value;
            }
        }

        public string SettingsTempReadOutputPath
        {
            get
            {
                return m_SettingsTempReadOutputPath;
            }
            set
            {
                m_SettingsTempReadOutputPath = value;
            }
        }

        public frmAR1Main(GuiManager gui_manager)
        {
            m_bLoadingForm = true;
            m_bSettingsLoaded = false;

            InitializeComponent();
            base.HideOnClose = true;
            m_GuiManager = gui_manager;
            m_GuiManager.MainTsForm = this;
            m_MainParams = gui_manager.TsParams.MainParams;
            m_ChirpConfigParams = m_GuiManager.TsParams.ChirpConfigParams;
            m_AdvancedFrameConfigParams = m_GuiManager.TsParams.AdvancedFrameConfigParams;
            m_RadarDeviceModeConfigParams = m_GuiManager.TsParams.RadarDeviceModeConfigParams;
            m_AntennaMode = new AntennaMode();
            iGetTsTableAndFlags();
            m_RadarMode.SelectedIndex = 0;
            m_chbTDABoard.Enabled = false;
            Imports.RadarLinkImpl_setSystemType(1);
            if (m_chkRadarDevice1.Checked)
            {
                GlobalRef.g_RadarDeviceId |= 1U;
            }
            else
            {
                GlobalRef.g_RadarDeviceId &= 4294967294U;
            }
            if (m_chkRadarDevice2.Checked)
            {
                GlobalRef.g_RadarDeviceId |= 2U;
            }
            else
            {
                GlobalRef.g_RadarDeviceId &= 4294967293U;
            }
            if (m_chkRadarDevice3.Checked)
            {
                GlobalRef.g_RadarDeviceId |= 4U;
            }
            else
            {
                GlobalRef.g_RadarDeviceId &= 4294967291U;
            }
            if (m_chkRadarDevice4.Checked)
            {
                GlobalRef.g_RadarDeviceId |= 8U;
            }
            else
            {
                GlobalRef.g_RadarDeviceId &= 4294967287U;
            }
            iInitControls();
            m_SettingsTempReadOutputPath = iGetSettingsTempReadOutputPath();
            if (IsSoftwareInstalled("MATLAB Runtime 8.5.1 (32"))
            {
                GlobalRef.LuaWrapper.PrintLuaWarning("Matlab Runtime Engine is installed");
            }
            else
            {
                GlobalRef.LuaWrapper.PrintError("Matlab Runtime Engine is not installed");
            }
            string directoryName = Path.GetDirectoryName(Application.StartupPath);
            string postProcesspath = string.Concat(new string[]
            {
                directoryName + "\\PostProc\\"
            });
            string full_command;
            if (!InitMatlabPostProcEngine(postProcesspath))
            {
                full_command = string.Format("Matlab Engine couldn't be Started..", new object[0]);
            }
            else
            {
                full_command = string.Format("Matlab Engine Started!", new object[0]);
            }
            m_GuiManager.RecordLog(99, full_command);
            GuiSettings.Default.DefaultFileName = Path.Combine(GlobalRef.LuaWrapper.SettingsOutputPath, "ar1gui.ini");
            m_BoardStatus = BoardStatus.DISCONNECTED;
            iInitTabs();
            m_DeviceMode.SelectedIndex = 0;
            iDisabletRadioButtonsTabStop_Rec(this);
            GuiSettings.Default.Load();
            m_bSettingsLoaded = true;
            RunPostLoadSettings();
            m_GuiManager.DllOps.Init(m_GuiManager, m_TsWrapper);
            m_GuiManager.ScriptOps.Init(m_GuiManager, m_TsWrapper);
            m_GuiManager.AR1xxxExtOpps.Init(m_GuiManager, m_TsWrapper);
            m_RegOpeTab.Init(m_GuiManager, m_TsWrapper);
            m_ConnectTab.UpdateMatlabPostProcVersion();
            m_ConnectTab.GetMatlabPreconfigurePlots();
            iSetConnectionTimer(true);
            MatlabPostProcGuiInstance.select_capture_device("DCA1000");
            GlobalRef.f0002d0 = true;
            GlobalRef.g_RFDataCaptureMode = true;
            SetGuiForCustomer();
        }

        public bool IsSoftwareInstalled(string softwareName)
        {
            c00026f c00026f = new c00026f();
            c00026f.softwareName = softwareName;
            c00026f.key = (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall") ?? Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall"));
            if (c00026f.key == null)
            {
                return false;
            }
            return c00026f.key.GetSubKeyNames().Select(new Func<string, RegistryKey>(c00026f.m000039)).Select(new Func<RegistryKey, string>(c000270.f00019e.m00003b)).Any(new Func<string, bool>(c00026f.m00003a));
        }

        public bool InitMatlabPostProcEngine(string PostProcesspath)
        {
            bool result;
            try
            {
                string full_command = string.Format("Starting Matlab Engine..", new object[0]);
                m_GuiManager.RecordLog(99, full_command);
                MatlabPostProcGuiInstance = new MatlabPostProcGUIClass();
                if (!string.IsNullOrEmpty(PostProcesspath))
                {
                    MatlabPostProcGuiInstance.Initialize_PostProcEngine(PostProcesspath);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                m_GuiManager.Error("Error occured in Matlab Initialization");
                result = false;
            }
            return result;
        }

        public bool UpdateData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(UpdateData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public string iGetSettingsOutputPath()
        {
            string text = string.Empty;
            string directoryName = Path.GetDirectoryName(Application.StartupPath);
            text = string.Concat(new string[]
            {
                directoryName + "\\PostProc\\adc_data.bin"
            });
            try
            {
                if (!Directory.Exists(text))
                {
                    File.Create(text);
                }
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(string.Format("Failed to create adc_data.bin file in PostProc path: \"{0}\".\nGot error: {1} ", text, ex.Message));
            }
            return text;
        }

        public string iGetSettingsTempReadOutputPath()
        {
            string text = string.Empty;
            string directoryName = Path.GetDirectoryName(Application.StartupPath);
            text = string.Concat(new string[]
            {
                directoryName + "\\PostProc\\Temp_data.txt"
            });
            try
            {
                if (!Directory.Exists(text))
                {
                    File.Create(text);
                }
                else
                {
                    File.Delete(text);
                    File.Create(text);
                }
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(string.Format("Failed to create Temp_data.txt file in PostProc path: \"{0}\".\nGot error: {1} ", text, ex.Message));
            }
            return text;
        }

        public bool UpdateGui()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(UpdateGui);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                result = true;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public void SetGuiForCustomer()
        {
            m_Tbc.TabPages.Remove(m_tabProtocolHolder);
            m_Tbc.TabPages.Remove(m_tabRFStatusConfigHolder);
            m_Tbc.TabPages.Remove(f0001a9);
            m_Tbc.TabPages.Remove(m_tabClibConfigHolder);
            m_ConnectTab.SetGuiForCustomer();
            m_GuiManager.MainTsForm.ChirpConfigTab.DisablTxChannelsDuringTxCalibForCustomer();
        }

        public void SaveSettings()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(SaveSettings);
                base.Invoke(method);
                return;
            }
            Main main = GuiSettings.Default.Main;
            GuiSettings.Default.Main = main;
        }

        public void LoadSettings()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(LoadSettings);
                base.Invoke(method);
                return;
            }
            Main main = GuiSettings.Default.Main;
        }

        public void RunPostLoadSettings()
        {
            iPostLoadSettings();
            ConnectTab.PostLoadSettings();
            UpdateLuaKeys();
        }

        private void iPostLoadSettings()
        {
        }

        public void UpdateLuaKeys()
        {
            iUpdateLuaKeys();
            m_ConnectTab.UpdateLuaKeys();
        }

        private void iUpdateLuaKeys()
        {
            iUpdateLuaKey(TsLuaKey.ChannelName);
            iUpdateLuaKey(TsLuaKey.ChannelFreq);
            iUpdateLuaKey(TsLuaKey.ChannelIdx);
            iUpdateLuaKey(TsLuaKey.ChannelBand);
            iUpdateLuaKey(TsLuaKey.PowerMode);
            iUpdateLuaKey(TsLuaKey.GatingMode);
        }

        private void iUpdateLuaKey(TsLuaKey key)
        {
            if (base.InvokeRequired)
            {
                del_UpdateLuaKey method = new del_UpdateLuaKey(iUpdateLuaKey);
                base.Invoke(method, new object[]
                {
                    key
                });
                return;
            }
            LuaType type = LuaType.Number;
            if (!m_GuiManager.MainTsForm.SettingsLoaded)
            {
                return;
            }
            try
            {
                string text;
                switch (key)
                {
                    case TsLuaKey.ChannelName:
                    case TsLuaKey.ChannelFreq:
                    case TsLuaKey.ChannelIdx:
                    case TsLuaKey.ChannelBand:
                        return;
                    case TsLuaKey.PowerMode:
                        text = "0";
                        break;
                    case TsLuaKey.GatingMode:
                        text = "1";
                        break;
                    default:
                        m_GuiManager.Error("Internal error: key {0} is not a valid General key.", key.ToString());
                        return;
                }
                m_GuiManager.p000002.SetTableVal(key, text.ToString(), type);
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        private void iUpdateLuaChannelKeys(int channel_idx)
        {
            if (channel_idx != -1)
            {
                m_GuiManager.p000002.SetTableVal(TsLuaKey.ChannelName, m_ChannelTable[channel_idx].Name, LuaType.f0002bd);
                m_GuiManager.p000002.SetTableVal(TsLuaKey.ChannelFreq, m_ChannelTable[channel_idx].Freq.ToString());
                m_GuiManager.p000002.SetTableVal(TsLuaKey.ChannelIdx, m_ChannelTable[channel_idx].PrimIdx.ToString());
                m_GuiManager.p000002.SetTableVal(TsLuaKey.ChannelBand, ((int)m_ChannelTable[channel_idx].Band).ToString());
            }
        }

        private void iGetTsTableAndFlags()
        {
            m_GuiManager.p000002.Getar1guiTable();
        }

        private void iInitTabs()
        {
            m_RFDataCaptureCard = new RFDataCaptureCard();
            m_TDAxxCaptureCard = new TDAxxCaptureCard();
            m_ConnectTab = new ConnectTab();
            m_StaticConfigTab = new StaticConfigTab();
            m_DataConfigTab = new DataConfigTab();
            m_ChirpConfigTab = new ChirpConfigTab();
            m_TestSourceTab = new TestSourceTab();
            m_RegOpeTab = new RegOpeTab();
            m_ProtocolTab = new ProtocolTab();
            m_ContStreamingTab = new ContStreamingTab();
            m_BpmConfigTab = new BpmConfigTab();
            m_RFStatusTab = new RFStatusTab();
            m_PMICTab = new PMICTab();
            m_ClibTab = new ClibTab();
            m_AdvanceFrameConfigTab = new AdvanceFrameConfigTab();
            m_RampTimingCfgTab = new RampTimingCfgTab();
            m_LoopBack = new LoopBack();
            m_ExternalFilterProgramming = new ExternalFilterProgramming();
            m_CalibConfig = new CalibConfig();
            m_MonitoringConfig = new MonitoringConfig();
            m_AnalogMonConfig = new AnalogMonConfig();
            m_AnalogMon2Config = new AnalogMon2Config();
            m_TxRxGainTempLUTCfg = new TxRxGainTempLUTCfg();
            m_winSCPTransfer = new WinSCPTransfer();
            f0001a7 = new c0000b1();
            m_MSSMonitoring = new MSSMonitoring();
            m_DynamicChirpConfig = new DynamicChirpConfig();
            m_ClockOutConfig = new ClockOutConfig();
            m_CalibDataReStore = new CalibDataReStore();
            m_InterChirpBlockControls = new InterChirpBlockControls();
            m_Import_Export = new Import_Export();
            m_tabConnectionHolder.Controls.Add(m_ConnectTab);
            m_tabStaticConfigHolder.Controls.Add(m_StaticConfigTab);
            m_tabDataConfigHolder.Controls.Add(m_DataConfigTab);
            m_tabChirpConfigHolder.Controls.Add(m_ChirpConfigTab);
            m_tabTestSourceHolder.Controls.Add(m_TestSourceTab);
            m_tabRegOpeHolder.Controls.Add(m_RegOpeTab);
            m_tabProtocolHolder.Controls.Add(m_ProtocolTab);
            m_tabContStreamHolder.Controls.Add(m_ContStreamingTab);
            m_tabBpmConfigHolder.Controls.Add(m_BpmConfigTab);
            m_tabRFStatusConfigHolder.Controls.Add(m_RFStatusTab);
            f0001a9.Controls.Add(m_PMICTab);

            m_tabClibConfigHolder.Controls.Add(m_ClibTab);
            m_tabAdvanceFrameConfigHolder.Controls.Add(m_AdvanceFrameConfigTab);
            m_tabRampTimingsConfigHolder.Controls.Add(m_RampTimingCfgTab);
            m_tabLoopBackConfigHolder.Controls.Add(m_LoopBack);
            m_tabExternalFilterProgConfigHolder.Controls.Add(m_ExternalFilterProgramming);
            m_tabRFMonCalibrationConfigHolder.Controls.Add(m_CalibConfig);
            m_tabRFMonitoringConfigHolder.Controls.Add(m_MonitoringConfig);
            m_tabAnalogMonitoringConfigHolder.Controls.Add(m_AnalogMonConfig);
            m_tabAnalogMonitoring2ConfigHolder.Controls.Add(m_AnalogMon2Config);
            m_tabTxRxGainTempLutConfigHolder.Controls.Add(m_TxRxGainTempLUTCfg);
            f0001aa.Controls.Add(f0001a7);

            m_tabMSSModuleMonitoringConfigHolder.Controls.Add(m_MSSMonitoring);
            m_tabDynamicChirpConfigHolder.Controls.Add(m_DynamicChirpConfig);
            m_tabClockOutConfigHolder.Controls.Add(m_ClockOutConfig);
            m_tabCalibDataRestoreConfigHolder.Controls.Add(m_CalibDataReStore);
            m_tabInterChirpBlockControlsConfigHolder.Controls.Add(m_InterChirpBlockControls);
            m_tabImportExportTabConfigHolder.Controls.Add(m_Import_Export);
            m_ConnectTab.Dock = DockStyle.Fill;
        }

        private void iInitControls()
        {
            iInitRegTypeList();
            iSetAllBits();
            iInitPowerModeList();
            iInitChannelTable();
            iInitChannelDud();
            iInitAntModeList();
        }

        private void iSetAllBits()
        {
        }

        private void iInitRegTypeList()
        {
            m_RegTypeList = new NameValueList();
            m_RegTypeList.AddNameValue("TOP", 4);
            m_RegTypeList.AddNameValue("PHY", 1);
            m_RegTypeList.AddNameValue("MAC", 2);
            m_RegTypeList.AddNameValue("NWP", 5);
            m_RegTypeList.AddNameValue("NWP_SRAM", 6);
            m_RegTypeList.AddNameValue("ACTL", 7);
        }

        private void iInitPowerModeList()
        {
            m_PowerModeList = new NameValueList();
            m_PowerModeList.AddNameValue("Listen", 1);
            m_PowerModeList.AddNameValue("Power Down", 3);
            m_PowerModeList.AddNameValue("ELP", 5);
        }

        private void iInitAntModeList()
        {
            m_AntModeList = new NameValueList();
            m_AntModeList.AddNameValue("MIMO", 0);
            m_AntModeList.AddNameValue("SISO", 1);
            m_AntModeList.AddNameValue("SISO w/MRC", 2);
            m_AntModeList.AddNameValue("HP SISO", 3);
            m_AntModeList.AddNameValue("HP SISO w/MRC", 4);
        }

        private void iInitChannelDud()
        {
            foreach (ChannelData channelData in m_ChannelTable)
            {
            }
        }

        private void iInitChannelTable()
        {
            m_ChannelTable = new ChannelTable();
            m_ChannelTable.AddChannel("1", 2412, 1, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("2", 2417, 2, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("3", 2422, 3, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("4", 2427, 4, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("5", 2432, 5, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("6", 2437, 6, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("7", 2442, 7, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("8", 2447, 8, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("9", 2452, 9, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("10", 2457, 10, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("11", 2462, 11, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("12", 2467, 12, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("13", 2472, 13, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("14", 2484, 14, Band.BAND_2_4GHZ);
            m_ChannelTable.AddChannel("J1", 4920, 16, Band.BAND_4_9GHZ);
            m_ChannelTable.AddChannel("J2", 4940, 12, Band.BAND_4_9GHZ);
            m_ChannelTable.AddChannel("J3", 4960, 8, Band.BAND_4_9GHZ);
            m_ChannelTable.AddChannel("J4", 4980, 4, Band.BAND_4_9GHZ);
            m_ChannelTable.AddChannel("J8", 5040, 8, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("J12", 5060, 12, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("J16", 5080, 16, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("J34", 5170, 34, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("36 ", 5180, 36, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("J38", 5190, 38, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("40", 5200, 40, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("J42", 5210, 42, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("44", 5220, 44, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("J46", 5230, 46, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("48", 5240, 48, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("52", 5260, 52, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("56", 5280, 56, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("60", 5300, 60, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("64", 5320, 64, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("100", 5500, 100, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("104", 5520, 104, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("108", 5540, 108, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("112", 5560, 112, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("116", 5580, 116, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("120", 5600, 120, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("124", 5620, 124, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("128", 5640, 128, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("132", 5660, 132, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("136", 5680, 136, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("140", 5700, 140, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("149", 5745, 149, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("153", 5765, 153, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("157", 5785, 157, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("161", 5805, 161, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("165", 5825, 165, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("171", 5855, 171, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("172", 5860, 172, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("173", 5865, 173, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("174", 5870, 174, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("175", 5875, 175, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("176", 5880, 176, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("177", 5885, 177, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("178", 5890, 178, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("179", 5895, 179, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("180", 5900, 180, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("181", 5905, 181, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("182", 5910, 182, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("183", 5915, 183, Band.BAND_5GHZ);
            m_ChannelTable.AddChannel("184", 5920, 184, Band.BAND_5GHZ);
            m_ChannelTable.Reverse();
        }

        public void GetBoardStatus()
        {
            m_BoardStatus = (m_TsWrapper.Calling_IsConnected())
                ? BoardStatus.CONNECTED
                : BoardStatus.DISCONNECTED;
        }

        public void HandleBoardStatusChange(bool ext)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new del_v_b(HandleBoardStatusChange), ext);
                return;
            }
            ResetStatuses();
            BoardStatus boardStatus = m_BoardStatus;
            if (boardStatus != BoardStatus.DISCONNECTED)
            {
                if (boardStatus == BoardStatus.CONNECTED)
                {
                    if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
                    {
                        ChangeLabelsAccordingConnectStatus(Color.Yellow, Color.Blue, "Connected without FW", "Disconnect (2)");
                        m_RegOpeTab.m000060();
                        m_ConnectTab.UpdateConnectionTabEnabledStatus();
                    }
                    else if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
                    {
                        m_ConnectTab.UpdateConnectionTabEnabledStatus();
                    }
                }
            }
            else
            {
                ChangeLabelsAccordingConnectStatus(Color.Red, Color.Red, "Not Connected", "Connect (2)");
                m_ConnectTab.ResetBoardInfo();
                m_ConnectTab.UpdateConnectionTabEnabledStatus();
                if (GlobalRef.g_CasCadeDeviceSpiConnect == 0U)
                {
                    m_RegOpeTab.m000061();
                }
            }
            iDisableControls();
        }

        public void HandleBoardStatusChangeRadarDevice2(bool ext)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new del_v_b(HandleBoardStatusChangeRadarDevice2), ext);
                return;
            }
            ResetStatuses();
            BoardStatus boardStatus = m_BoardStatus;
            if (boardStatus != BoardStatus.DISCONNECTED)
            {
                if (boardStatus == BoardStatus.CONNECTED)
                {
                    if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
                    {
                        ChangeLabelsAccordingConnectStatusRadarDevice2(Color.Yellow, Color.Blue, "Connected without FW", "Disconnect");
                        m_RegOpeTab.m000060();
                        m_ConnectTab.UpdateConnectionTabEnabledStatus();
                    }
                    else if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
                    {
                        m_ConnectTab.UpdateConnectionTabEnabledStatus();
                    }
                }
            }
            else
            {
                ChangeLabelsAccordingConnectStatusRadarDevice2(Color.Red, Color.Red, "Not Connected", "Connect");
                m_ConnectTab.ResetBoardInfo();
                m_ConnectTab.UpdateConnectionTabEnabledStatus();
                if (GlobalRef.g_CasCadeDeviceSpiConnect == 0U)
                {
                    m_RegOpeTab.m000061();
                }
            }
            iDisableControls();
        }

        public void HandleBoardStatusChangeRadarDevice3(bool ext)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new del_v_b(HandleBoardStatusChangeRadarDevice3), ext);
                return;
            }
            ResetStatuses();
            BoardStatus boardStatus = m_BoardStatus;
            if (boardStatus != BoardStatus.DISCONNECTED)
            {
                if (boardStatus == BoardStatus.CONNECTED)
                {
                    if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
                    {
                        ChangeLabelsAccordingConnectStatusRadarDevice3(Color.Yellow, Color.Blue, "Connected without FW", "Disconnect");
                        m_RegOpeTab.m000060();
                        m_ConnectTab.UpdateConnectionTabEnabledStatus();
                    }
                    else if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
                    {
                        m_ConnectTab.UpdateConnectionTabEnabledStatus();
                    }
                }
            }
            else
            {
                ChangeLabelsAccordingConnectStatusRadarDevice3(Color.Red, Color.Red, "Not Connected", "Connect");
                m_ConnectTab.ResetBoardInfo();
                m_ConnectTab.UpdateConnectionTabEnabledStatus();
                if (GlobalRef.g_CasCadeDeviceSpiConnect == 0U)
                {
                    m_RegOpeTab.m000061();
                }
            }
            iDisableControls();
        }

        public void HandleBoardStatusChangeRadarDevice4(bool ext)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new del_v_b(HandleBoardStatusChangeRadarDevice4), ext);
                return;
            }
            ResetStatuses();
            BoardStatus boardStatus = m_BoardStatus;
            if (boardStatus != BoardStatus.DISCONNECTED)
            {
                if (boardStatus == BoardStatus.CONNECTED)
                {
                    if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
                    {
                        ChangeLabelsAccordingConnectStatusRadarDevice4(Color.Yellow, Color.Blue, "Connected without FW", "Disconnect");
                        m_RegOpeTab.m000060();
                        m_ConnectTab.UpdateConnectionTabEnabledStatus();
                    }
                    else if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
                    {
                        m_ConnectTab.UpdateConnectionTabEnabledStatus();
                    }
                }
            }
            else
            {
                ChangeLabelsAccordingConnectStatusRadarDevice4(Color.Red, Color.Red, "Not Connected", "Connect");
                m_ConnectTab.ResetBoardInfo();
                m_ConnectTab.UpdateConnectionTabEnabledStatus();
                if (GlobalRef.g_CasCadeDeviceSpiConnect == 0U)
                {
                    m_RegOpeTab.m000061();
                }
            }
            iDisableControls();
        }

        public void HandleMainStatusChange(bool ext)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new del_v_b(HandleMainStatusChange), ext);
                return;
            }
            m_ConnectTab.UpdateConnectionTabEnabledSts();
        }

        public void ChangeLabelsAccordingConnectStatus(Color label_clr, Color p1, string lbl_con_text, string btn_status_text)
        {
            m_lblConnection.BackColor = label_clr;
            m_lblConnection.Text = lbl_con_text;
            m_ConnectTab.ConnectButton.ForeColor = p1;
            m_ConnectTab.ConnectButton.Text = btn_status_text;
            m_ConnectTab.UpdateConnectionTabEnabledStatus();
        }

        public void ChangeLabelsAccordingConnectStatusRadarDevice2(Color label_clr, Color p1, string lbl_con_text, string btn_status_text)
        {
            m_lblConnection.BackColor = label_clr;
            m_lblConnection.Text = lbl_con_text;
            m_ConnectTab.ConnectButtonRadarDevice2.ForeColor = p1;
            m_ConnectTab.ConnectButtonRadarDevice2.Text = btn_status_text;
            m_ConnectTab.UpdateConnectionTabEnabledStatusRadarDevice2();
        }

        public void ChangeLabelsAccordingConnectStatusRadarDevice3(Color label_clr, Color p1, string lbl_con_text, string btn_status_text)
        {
            m_lblConnection.BackColor = label_clr;
            m_lblConnection.Text = lbl_con_text;
            m_ConnectTab.ConnectButtonRadarDevice3.ForeColor = p1;
            m_ConnectTab.ConnectButtonRadarDevice3.Text = btn_status_text;
            m_ConnectTab.UpdateConnectionTabEnabledStatusRadarDevice3();
        }

        public void ChangeLabelsAccordingConnectStatusRadarDevice4(Color label_clr, Color p1, string lbl_con_text, string btn_status_text)
        {
            m_lblConnection.BackColor = label_clr;
            m_lblConnection.Text = lbl_con_text;
            m_ConnectTab.ConnectButtonRadarDevice4.ForeColor = p1;
            m_ConnectTab.ConnectButtonRadarDevice4.Text = btn_status_text;
            m_ConnectTab.UpdateConnectionTabEnabledStatusRadarDevice4();
        }

        private void iUpdateGuiAfterFwDownload()
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new del_v_v(iUpdateGuiAfterFwDownload));
                return;
            }
            if (BoardStatus == BoardStatus.CONNECTED)
            {
                iSetPowerModesEnabledStatus();
            }
        }

        public void DisableMain()
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new del_v_v(DisableMain));
                return;
            }
            foreach (object obj in m_Panel.Controls)
            {
                Control control = (Control)obj;
                if (control is GroupBox)
                {
                    control.Enabled = false;
                }
            }
            m_MainDisabled = true;
        }

        public void EnableMain()
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new del_v_v(EnableMain));
                return;
            }
            foreach (object obj in m_Panel.Controls)
            {
                Control control = (Control)obj;
                if (control is GroupBox)
                {
                    control.Enabled = true;
                }
            }
            m_MainDisabled = false;
        }

        private void iDisableControls()
        {
            m_ConnectTab.DisableControls();
        }

        private void iEnableControls(bool bConnect)
        {
            foreach (object obj in m_Panel.Controls)
            {
                Control control = (Control)obj;
                if (!(control is TabControl))
                {
                    EnableControl_Rec(bConnect, control);
                }
            }
            foreach (object obj2 in m_Tbc.TabPages)
            {
                TabPage tabPage = (TabPage)obj2;
                if (tabPage != m_tabConnectionHolder)
                {
                    EnableControl_Rec(bConnect, tabPage);
                }
            }
            if (bConnect)
            {
                UpdateGeneralEnabledStatus();
                return;
            }
            m_ConnectTab.UpdateConnectionTabEnabledStatus();
        }

        public void EnableControl_Rec(bool bEnable, Control ctrl)
        {
            if (ctrl is GroupBox || ctrl is Panel || ctrl is TabPage || ctrl.Parent is TabPage)
            {
                if (ctrl is GroupBox)
                    ctrl.Enabled = true;
                else
                    ctrl.Enabled = bEnable;
                foreach (Control ctrl2 in ctrl.Controls)
                    EnableControl_Rec(bEnable, ctrl2);
                return;
            }
            ctrl.Enabled = bEnable;
        }

        private void iDisabletRadioButtonsTabStop_Rec(Control ctrl)
        {
            if (ctrl.HasChildren)
            {
                foreach (Control ctrl2 in ctrl.Controls)
                    iDisabletRadioButtonsTabStop_Rec(ctrl2);
                return;
            }
            if (ctrl is RadioButton)
            {
                ctrl.TabStop = false;
            }
        }

        private bool iConvertHexTextToUInt(TextBox p0, out uint uint_val)
        {
            uint_val = 0U;
            if (string.IsNullOrEmpty(p0.Text))
            {
                return false;
            }
            string text = p0.Text.ToLower();
            if (text.Length > 1 && text.StartsWith("0x"))
            {
                text = text.Remove(0, 2);
            }
            return uint.TryParse(text, NumberStyles.HexNumber, null, out uint_val);
        }

        public void UpdateCalibrationStatus(int calib_res, bool set_time)
        {
            if (base.InvokeRequired)
            {
                del_v_i_b method = new del_v_i_b(UpdateCalibrationStatus);
                base.Invoke(method, new object[]
                {
                    calib_res,
                    set_time
                });
                return;
            }
            if (calib_res == 0)
            {
                return;
            }
        }

        private bool ibCheckChannelMatchesRate(int channel_idx)
        {
            if (base.InvokeRequired)
            {
                del_b_i method = new del_b_i(ibCheckChannelMatchesRate);
                return (bool)base.Invoke(method, new object[]
                {
                    channel_idx
                });
            }
            ChannelData channelData = m_ChannelTable[channel_idx];
            if (channelData.Band != Band.BAND_2_4GHZ)
            {
                m_GuiManager.Error(string.Format("Can't set to an U-NII band channel ({0}) when in 11b rate ({1})", channelData.Name, channelData.Name));
                return false;
            }
            return true;
        }

        public void UpdateDieID()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(UpdateDieID);
                base.Invoke(method);
            }
        }

        private void iSetGatingModeAsync()
        {
            new del_b_v(iSetGatingMode).BeginInvoke(null, null);
        }

        private bool iSetGatingMode()
        {
            int num;
            if (iIsGatingModeChecked())
            {
                num = 7;
            }
            else
            {
                num = 8;
            }
            int num2 = m_GuiManager.p000002.ExecuteApi(TsApiOp.PowerMode, new object[]
            {
                num
            });
            if (num2 != 0)
            {
                m_GuiManager.ErrorApiFailure(TsApiOp.PowerMode, num2);
                if (num == 7)
                {
                    iSetGatingCheckedStatus(false);
                }
                else
                {
                    iSetGatingCheckedStatus(true);
                }
            }
            return num2 == 0;
        }

        private bool iIsGatingModeChecked()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(iIsGatingModeChecked);
                return (bool)base.Invoke(method);
            }
            return true;
        }

        private void iSetGatingCheckedStatus(bool status)
        {
            if (base.InvokeRequired)
            {
                del_v_b method = new del_v_b(iSetGatingCheckedStatus);
                base.Invoke(method, new object[]
                {
                    status
                });
            }
        }

        public void UpdateGeneralEnabledStatus()
        {
        }

        public void GuiOpExtStart(string op_name)
        {
            if (base.InvokeRequired)
            {
                del_v_s method = new del_v_s(GuiOpExtStart);
                base.Invoke(method, new object[]
                {
                    op_name
                });
            }
        }

        public void GuiOpExtEnd()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(GuiOpExtEnd);
                base.Invoke(method);
            }
        }

        public void SetCurrentOp(string op_name)
        {
            try
            {
                if (base.InvokeRequired)
                {
                    del_v_s method = new del_v_s(SetCurrentOp);
                    base.Invoke(method, new object[]
                    {
                        op_name
                    });
                }
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        public void GuiOpStart(string op_name, bool disable_gui)
        {
            if (base.InvokeRequired)
            {
                del_v_s_b method = new del_v_s_b(GuiOpStart);
                base.Invoke(method, new object[]
                {
                    op_name,
                    disable_gui
                });
                return;
            }
            if (disable_gui)
            {
                SetControlsWait(false);
            }
        }

        public void GuiOpEnd(bool enable_gui)
        {
            if (base.InvokeRequired)
            {
                del_v_b method = new del_v_b(GuiOpEnd);
                base.Invoke(method, new object[]
                {
                    enable_gui
                });
                return;
            }
            if (enable_gui)
            {
                SetControlsWait(true);
            }
        }

        public void EnableDisableBtnDisplayTDAStats(bool status)
        {
            if (base.InvokeRequired)
            {
                del_v_b method = new del_v_b(EnableDisableBtnDisplayTDAStats);
                base.Invoke(method, new object[]
                {
                    status
                });
                return;
            }
            if (status)
            {
                m_btnDisplayTDAStats.Enabled = true;
                return;
            }
            m_btnDisplayTDAStats.Enabled = false;
        }

        public void RadarDeviceSelection(uint RadarDeviceId)
        {
            if (RadarDeviceId == 2U || RadarDeviceId == 3U || RadarDeviceId == 4U)
            {
                m_grpRadarDeviceMode.Visible = true;
                m_grpRadarDeviceMode.Enabled = true;
                m_grpRadarDeviceSelection.Visible = true;
                m_grpRadarDeviceSelection.Enabled = true;
                m_btnDisplayTDAStats.Visible = true;
                m_btnDisplayTDAStats.Enabled = false;
                if (RadarDeviceId == 2U)
                {
                    m_chkRadarDevice1.Enabled = true;
                    m_chkRadarDevice2.Enabled = true;
                    return;
                }
            }
            else
            {
                m_grpRadarDeviceSelection.Visible = false;
                m_grpRadarDeviceSelection.Enabled = false;
                m_grpRadarDeviceMode.Visible = false;
                m_grpRadarDeviceMode.Enabled = false;
                m_btnDisplayTDAStats.Visible = false;
                m_btnDisplayTDAStats.Enabled = false;
            }
        }

        public void SetTSW1400ReadyState()
        {
            m_btnStupHsdcPro.ForeColor = Color.Blue;
        }

        public void SetControlsWait(bool enable)
        {
            if (base.InvokeRequired)
            {
                del_v_b method = new del_v_b(SetControlsWait);
                base.Invoke(method);
                return;
            }
            if (enable)
            {
                foreach (object obj in m_Panel.Controls)
                {
                    Control control = (Control)obj;
                    if (m_MainDisabled)
                    {
                        if (!(control is GroupBox))
                        {
                            control.Enabled = true;
                        }
                    }
                    else
                    {
                        control.Enabled = true;
                    }
                }
                Cursor = Cursors.Default;
                return;
            }
            Cursor = Cursors.WaitCursor;
            foreach (object obj2 in m_Panel.Controls)
            {
                ((Control)obj2).Enabled = false;
            }
        }

        public void GoToElpEnd(int res)
        {
            if (base.InvokeRequired)
            {
                del_v_i method = new del_v_i(GoToElpEnd);
                base.Invoke(method, new object[]
                {
                    res
                });
                return;
            }
        }

        public void ResetStatuses()
        {
        }

        public void SuspendAllActions()
        {
        }

        public void SuspendAllActions_forShutdown()
        {
        }

        public void EnableChannelTune(bool enabled_status)
        {
            if (base.InvokeRequired)
            {
                del_v_b method = new del_v_b(EnableChannelTune);
                base.Invoke(method, new object[]
                {
                    enabled_status
                });
            }
        }

        private void iSetPowerModesEnabledStatus()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(iSetPowerModesEnabledStatus);
                base.Invoke(method);
                return;
            }
            bool phyStandAlone = GuiManager.PhyStandAlone;
        }

        public void SetCalibUponTune(bool val)
        {
            if (base.InvokeRequired)
            {
                del_v_b method = new del_v_b(SetCalibUponTune);
                base.Invoke(method, new object[]
                {
                    val
                });
            }
        }

        private void m_btnRead_Click(object sender, EventArgs p1)
        {
        }

        private void m_btnWrite_Click(object sender, EventArgs p1)
        {
        }

        private void m_btnAllBits_Click(object sender, EventArgs p1)
        {
            iSetAllBits();
        }

        private void frmAR1Main_FormClosing(object sender, FormClosingEventArgs p1)
        {
            m_ClosingForm = true;
            SuspendAllActions_forShutdown();
            if (m_BoardStatus != BoardStatus.DISCONNECTED)
            {
                m_TsWrapper.Calling_ATE_DisconnectTarget();
            }
            GuiSettings.Default.Save();
        }

        private void m_btnAbort_Click(object sender, EventArgs p1)
        {
            m_GuiManager.p000002.AbortGuiOpThread();
        }

        private void m_Tbc_SelectedIndexChanged(object sender, EventArgs p1)
        {
        }

        private void m_chkCalibUponTune_CheckedChanged(object sender, EventArgs p1)
        {
        }

        private void frmAR1Main_Load(object sender, EventArgs p1)
        {
            m_bLoadingForm = false;
        }

        private void frmAR1Main_DockStateChanged(object sender, EventArgs p1)
        {
            if (base.DockState == DockState.Hidden && !m_bLoadingForm && !m_ClosingForm)
            {
                GuiSettings.Default.Save();
            }
        }

        private void m_txtAddr_KeyDown(object sender, KeyEventArgs p1)
        {
            Keys keyCode = p1.KeyCode;
        }

        private void m_cboRegisterType_SelectedIndexChanged(object sender, EventArgs p1)
        {
        }

        private void m_btnEnterExitMode_Click(object sender, EventArgs p1)
        {
        }

        private void m_chkGating_Click(object sender, EventArgs p1)
        {
            iSetGatingModeAsync();
        }

        private void LoadConfig_Click(object sender, EventArgs p1)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load Configuration";
            openFileDialog.Filter = "XML Files|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ConfigurationManager.Load(openFileDialog.FileName);
                m_StaticConfigTab.LoadChannelConfData();
                m_StaticConfigTab.LoadADCConfData();
                m_StaticConfigTab.LoadLPModeConfData();
                m_StaticConfigTab.LoadFreqLimitConfData();
                m_StaticConfigTab.LoadRFLdoBypassConfData();
                m_StaticConfigTab.LoadRadarMiscControlConfData();
                m_StaticConfigTab.LoadCalMonFreqTxPowerLimitConfData();
                m_DataConfigTab.LoadDataPathConfData();
                m_DataConfigTab.LoadClockConfData();
                m_DataConfigTab.LoadCSI2ConfData();
                m_DataConfigTab.LoadLVDSLaneConfData();
                m_DataConfigTab.LoadTestPatternGenConfData();
                m_TestSourceTab.LoadTestSourceData();
                m_ChirpConfigTab.LoadProfileConfData();
                m_ChirpConfigTab.LoadChirpConfigData();
                m_ChirpConfigTab.LoadFrameConfData();
                m_AdvanceFrameConfigTab.LoadAdvanceFrameConfigData();
                m_AdvanceFrameConfigTab.LoadLoopBackBurstConfigData();
                m_AnalogMonConfig.LoadAnalogMonEnableConfigData();
                m_AnalogMonConfig.LoadTx0BallBreakConfigData();
                m_AnalogMonConfig.LoadTx1BallBreakConfigData();
                m_AnalogMonConfig.LoadTx2BallBreakConfigData();
                m_AnalogMonConfig.LoadTx0PowerMonConfigData();
                m_AnalogMonConfig.LoadTx1PowerMonConfigData();
                m_AnalogMonConfig.LoadTx2PowerMonConfigData();
                m_AnalogMonConfig.LoadTx0BPMMonConfigData();
                m_AnalogMonConfig.LoadTx1BPMMonConfigData();
                m_AnalogMonConfig.LoadTx2BPMMonConfigData();
                m_AnalogMonConfig.LoadTxGainPhaseMismatchMonConfigData();
                m_AnalogMonConfig.LoadAnalogFaultInjectionConfigData();
                m_AnalogMon2Config.LoadRxGainPhaseMonConfigData();
                m_AnalogMon2Config.LoadRxNoiseFigureMonConfigData();
                m_AnalogMon2Config.LoadRxIFStageMonConfigData();
                m_AnalogMon2Config.LoadRxSaturationDetectorMonConfigData();
                m_AnalogMon2Config.LoadRxSignalAndImageMonConfigData();
                m_AnalogMon2Config.LoadRxMixerInputPowerMonConfigData();
                m_AnalogMon2Config.LoadRxTemperatureMonConfigData();
                m_AnalogMon2Config.LoadRxSynthFreqErrorMonConfigData();
                f0001a7.LoadRxExternalAnalogSignalMonConfigData();
                f0001a7.LoadTx0InternalAnalogSignalMonConfigData();
                f0001a7.LoadTx1InternalAnalogSignalMonConfigData();
                f0001a7.LoadTx2InternalAnalogSignalMonConfigData();
                f0001a7.LoadRxInternalAnalogSignalMonConfigData();
                f0001a7.LoadPMCLKLOInternalAnalogSignalMonConfigData();
                f0001a7.LoadGPADCInternalAnalogSignalMonConfigData();
                f0001a7.LoadPLLControlVoltageInternalAnalogSignalMonConfigData();
                f0001a7.LoadDCCInternalAnalogSignalMonConfigData();
            }
        }

        public void iSaveConfigurations()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Configuration";
            saveFileDialog.Filter = "XML Files|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_StaticConfigTab.SaveChannelBasicConfData();
                m_StaticConfigTab.SaveADCBasicConfData();
                m_StaticConfigTab.SaveLPModeBasicConfData();
                m_StaticConfigTab.SaveFreqLimitConfData();
                m_StaticConfigTab.SaveRfLDOBypassConfData();
                m_StaticConfigTab.SaveRadarMiscControlConfData();
                m_StaticConfigTab.SaveCalMonFreqTxPowerLimitConfData();
                m_DataConfigTab.SaveDataPathConfData();
                m_DataConfigTab.SaveClockConfData();
                m_DataConfigTab.SaveCSI2ConfData();
                m_DataConfigTab.SaveLVDSLaneConfData();
                m_DataConfigTab.SaveTestPatternGenConfData();
                m_TestSourceTab.SaveTestSourceData();
                m_ChirpConfigTab.SaveProfileConfData();
                m_ChirpConfigTab.SaveChirpConfData();
                m_ChirpConfigTab.SaveFrameConfData();
                m_AdvanceFrameConfigTab.SaveAdvanceFrameConfigData();
                m_AdvanceFrameConfigTab.SaveLoopBackBurstConfigData();
                m_AnalogMonConfig.SaveAnalogMonEnableConfigData();
                m_AnalogMonConfig.SaveTx0BallBreakConfigData();
                m_AnalogMonConfig.SaveTx1BallBreakConfigData();
                m_AnalogMonConfig.SaveTx2BallBreakConfigData();
                m_AnalogMonConfig.SaveTx0PowerMonConfigData();
                m_AnalogMonConfig.SaveTx1PowerMonConfigData();
                m_AnalogMonConfig.SaveTx2PowerMonConfigData();
                m_AnalogMonConfig.SaveTx0BPMMonConfigData();
                m_AnalogMonConfig.SaveTx1BPMMonConfigData();
                m_AnalogMonConfig.SaveTx2BPMMonConfigData();
                m_AnalogMonConfig.SaveTxGainPhaseMismatchMonConfigData();
                m_AnalogMonConfig.SaveAnalogFaultInjectionConfigData();
                m_AnalogMon2Config.SaveRxGainPhaseMonConfigData();
                m_AnalogMon2Config.SaveRxNoiseFigureMonConfigData();
                m_AnalogMon2Config.SaveRxIFStageMonConfigData();
                m_AnalogMon2Config.SaveRxSaturationDetectorMonConfigData();
                m_AnalogMon2Config.SaveRxSignalAndImageMonConfigData();
                m_AnalogMon2Config.SaveRxMixerInputPowerMonConfigData();
                m_AnalogMon2Config.SaveRxTemperatureMonConfigData();
                m_AnalogMon2Config.SaveRxSynthFreqErrorMonConfigData();
                f0001a7.SaveRxExternalAnalogSignalMonConfigData();
                f0001a7.SaveTx0InternalAnalogSignalMonConfigData();
                f0001a7.SaveTx1InternalAnalogSignalMonConfigData();
                f0001a7.SaveTx2InternalAnalogSignalMonConfigData();
                f0001a7.SaveRxInternalAnalogSignalMonConfigData();
                f0001a7.SavePMCLKLOInternalAnalogSignalMonConfigData();
                f0001a7.SaveGPADCInternalAnalogSignalMonConfigData();
                f0001a7.SavePLLControlVoltageInternalAnalogSignalMonConfigData();
                f0001a7.SaveDCCInternalAnalogSignalMonConfigData();
                ConfigurationManager.Save(saveFileDialog.FileName);
            }
        }

        private void SaveConfig_Click(object sender, EventArgs p1)
        {
            iSaveConfigurations();
        }

        public void iStartMtlabPostProc()
        {
            int num = 0;
            try
            {
                string text = null;
                Path.GetDirectoryName(Application.ExecutablePath);
                if (!string.IsNullOrEmpty(m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath()))
                {
                    text = m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath();
                    long num2 = 0L;
                    string empty = string.Empty;
                    long num4;
                    if (GlobalRef.g_4ChipCascade || GlobalRef.g_2ChipCascade)
                    {
                        string[] array = text.Split(new char[]
                        {
                            '\\'
                        });
                        int num3 = array.Length;
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(array[num3 - 1]);
                        string str = string.Empty;
                        for (int i = 0; i < num3 - 1; i++)
                        {
                            str = str + array[i] + "\\";
                        }
                        text = string.Concat(new string[]
                        {
                            str + fileNameWithoutExtension + ".bin"
                        });
                        FileInfo[] files = new DirectoryInfo(string.Concat(new string[]
                        {
                            str + fileNameWithoutExtension
                        })).GetFiles("master*_data.bin");
                        num4 = (long)files.Length;
                        double num5 = 0.0;
                        double num6;
                        if (!GlobalRef.g_AdvancedFrame)
                        {
                            num6 = m_GuiManager.ScriptOps.getFrameSize();
                        }
                        else
                        {
                            num6 = m_GuiManager.ScriptOps.getAdvFrameSize();
                        }
                        int num7 = 0;
                        while ((long)num7 < num4)
                        {
                            double num8 = (double)new FileInfo(files[num7].FullName).Length;
                            num5 += num8 / num6;
                            num7++;
                        }
                        num2 = (long)num5;
                    }
                    else
                    {
                        num4 = (long)m_GuiManager.MainTsForm.ChirpConfigTab.GetNumOfFilesCaptured(text);
                    }
                    if (!GlobalRef.g_AdvancedFrame)
                    {
                        if (m_ChirpConfigParams.frameCount == 0)
                        {
                            if (!GlobalRef.g_4ChipCascade && !GlobalRef.g_2ChipCascade)
                            {
                                num2 = (long)getTotalFrames(text);
                            }
                        }
                        else
                        {
                            num2 = (long)((ulong)m_ChirpConfigParams.frameCount);
                        }
                    }
                    else if (m_AdvancedFrameConfigParams.NumOfFrames == 0)
                    {
                        if (!GlobalRef.g_4ChipCascade && !GlobalRef.g_2ChipCascade)
                        {
                            num2 = (long)getTotalFrames(text);
                        }
                    }
                    else
                    {
                        num2 = (long)((ulong)m_AdvancedFrameConfigParams.NumOfFrames);
                    }
                    string full_command = string.Format("ar1.StartMatlabPostProc(\"{0}\")", text);
                    m_GuiManager.RecordLog(0, full_command);
                    full_command = string.Format("No of files Captured: {0}, Total no of frames for each device : {1}", num4, num2);
                    m_GuiManager.RecordLog(0, full_command);
                    if (num4 != 0L)
                    {
                        if (GlobalRef.g_4ChipCascade || GlobalRef.g_2ChipCascade)
                        {
                            MatlabPostProcGuiInstance.update_num_adc_files_and_frames((double)num4, (double)num2, GlobalRef.g_TDADeviceMap);
                        }
                        else
                        {
                            MatlabPostProcGuiInstance.update_num_adc_files_and_frames((double)num4, (double)num2, 1.0);
                        }
                        MatlabPostProcGuiInstance.process_adc_data(text, (double)num);
                    }
                    else
                    {
                        GlobalRef.LuaWrapper.PrintError("Error : The number of files captured is zero!");
                    }
                }
                else
                {
                    MatlabPostProcGuiInstance.process_adc_data(text, (double)num);
                }
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        public double getTotalFrames(string PostProcesspath)
        {
            double num = 0.0;
            double num2;
            if (!GlobalRef.g_AdvancedFrame)
            {
                num2 = m_GuiManager.ScriptOps.getFrameSize();
            }
            else
            {
                num2 = m_GuiManager.ScriptOps.getAdvFrameSize();
            }
            int numOfFilesCaptured = m_GuiManager.MainTsForm.ChirpConfigTab.GetNumOfFilesCaptured(PostProcesspath);
            string text = ".bin";
            string text2 = PostProcesspath.Remove(PostProcesspath.IndexOf(text), text.Length);
            for (int i = 0; i < numOfFilesCaptured; i++)
            {
                string fileName;
                if (numOfFilesCaptured == 1)
                {
                    fileName = PostProcesspath;
                }
                else
                {
                    fileName = string.Concat(new object[]
                    {
                        text2,
                        "_",
                        i,
                        ".bin"
                    });
                }
                double num3 = (double)new FileInfo(fileName).Length;
                num += num3 / num2;
            }
            return num;
        }

        public void iStarReturnStrongestDetectedObject()
        {
            try
            {
                Path.GetDirectoryName(Application.ExecutablePath);
                if (!string.IsNullOrEmpty(m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath()))
                {
                    string text = m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath();
                    string full_command = string.Format("ar1.ReturnStrongestDetectedObject(\"{0}\")", text);
                    m_GuiManager.RecordLog(0, full_command);
                    double[] array = (double[])((MWNumericArray)MatlabPostProcGuiInstance.return_strongest_detected_object(text)).ToVector(MWArrayComponent.Real);
                    Convert.ToInt32(array[0]);
                    Convert.ToInt32(array[1]);
                }
                else
                {
                    string msg = string.Format("Please select a file to save ADC data for returns Strongest Detected Object", new object[0]);
                    m_GuiManager.Log(msg);
                }
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        public void iStartMtlabRealTimeProc()
        {
            try
            {
                Path.GetDirectoryName(Application.ExecutablePath);
                if (!string.IsNullOrEmpty(m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath()))
                {
                    m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath();
                    while (GlobalRef.g_RealTimeTrigVar)
                    {
                        if (!g_tsw1400busy && !g_frmStrtStop)
                        {
                            StartTSW1400IfRlTime();
                            StartTriggerFrmRlTime();
                        }
                    }
                }
                else
                {
                    string msg = string.Format("Please select a file to save ADC data for Post Processing", new object[0]);
                    m_GuiManager.Log(msg);
                }
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        private void m_Panel_Paint(object sender, PaintEventArgs p1)
        {
        }

        public void StartTSW1400IfRlTime()
        {
            g_tsw1400busy = true;
            Path.GetDirectoryName(Application.ExecutablePath);
            if (!string.IsNullOrEmpty(m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath()))
            {
                string value = m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath();
                MatlabPostProcGuiInstance.setup_for_triggered_capture_max_30_frames(value);
                MatlabPostProcGuiInstance.process_adc_data(value);
                string msg = string.Format("process_adc_data()", new object[0]);
                m_GuiManager.Log(msg);
                g_tsw1400busy = false;
                return;
            }
            string msg2 = string.Format("Please select a file to save ADC data for Post Processing", new object[0]);
            m_GuiManager.Log(msg2);
        }

        public void StartTriggerFrmRlTime()
        {
            g_frmStrtStop = true;
            Thread.Sleep(1000);
            iSetTrigFrame_ImplThread();
            Thread.Sleep(1000);
            if (iSetTrigFrame_ImplThread() == 0)
            {
                g_frmStrtStop = false;
            }
        }

        public static bool KeepTrying(int timeout, Func<bool> operation)
        {
            bool flag = false;
            int i = 0;
            while (i < timeout)
            {
                Thread.Sleep(1000);
                i += 1000;
                flag = operation();
                if (flag)
                {
                    break;
                }
            }
            return flag;
        }

        public bool spare_read()
        {
            uint num;
            m_TsWrapper.Calling_ReadAddr_Single(4294959848U, out num);
            return num == 0U;
        }

        public int iSetTrigFrame_ImplThread()
        {
            int num = -1;
            if (!GlobalRef.g_FrameTriggered)
            {
                if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] && !GlobalRef.g_SpiConnect[(int)GlobalRef.g_RadarDeviceIndex])
                {
                    num = m_TsWrapper.Calling_WriteAddr_Single(4294959848U, 1U);
                    if (m_GuiManager.DllOps.itempDisconnect(false) == 0)
                    {
                        string full_command = string.Format("Debug Port Disconnected", new object[0]);
                        m_GuiManager.RecordLog(0, full_command);
                        if (!GlobalRef.g_RS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
                        {
                            m_GuiManager.ScriptOps.iRs232ConnectDisconnect_impl();
                        }
                    }
                }
                num = Imports.RadarLinkImpl_SensorStart(GlobalRef.g_RadarDeviceId);
                string full_command2 = string.Format("ar1.StartFrame({0})", new object[]
                {
                    GlobalRef.g_RadarDeviceId
                });
                m_GuiManager.RecordLog(13, full_command2);
                if ((num == 0 && ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)) || GlobalRef.g_RS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
                {
                    m_GuiManager.MainTsForm.ChirpConfigTab.iSetFrameBtnText("Stop Frame");
                    string full_command3 = string.Format("Status: Passed", new object[0]);
                    m_GuiManager.RecordLog(13, full_command3);
                    GlobalRef.g_FrameTriggered = true;
                    MatlabPostProcGuiInstance.MatlabPostProcImpl_SensorStart();
                }
                else
                {
                    string msg = string.Format("Status: Failed, Error Type: {0}", new object[]
                    {
                        m_GuiManager.ScriptOps.GetErrorType(num)
                    });
                    GlobalRef.LuaWrapper.PrintError(msg);
                }
            }
            else if (GlobalRef.g_FrameTriggered && m_ChirpConfigParams.frameCount == 0)
            {
                num = Imports.RadarLinkImpl_SensorStop(GlobalRef.g_RadarDeviceId);
                string full_command4 = string.Format("ar1.StopFrame({0})", new object[]
                {
                    GlobalRef.g_RadarDeviceId
                });
                m_GuiManager.RecordLog(13, full_command4);
                if ((num == 0 && ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)) || GlobalRef.g_RS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
                {
                    string full_command5 = string.Format("Status: Passed", new object[0]);
                    m_GuiManager.RecordLog(13, full_command5);
                    m_GuiManager.MainTsForm.ChirpConfigTab.iSetFrameBtnText("Trigger Frame");
                    GlobalRef.g_FrameTriggered = false;
                    MatlabPostProcGuiInstance.MatlabPostProcImpl_SensorStop();
                }
                else
                {
                    string msg2 = string.Format("Status: Failed, Error Type: {0}", new object[]
                    {
                        m_GuiManager.ScriptOps.GetErrorType(num)
                    });
                    GlobalRef.LuaWrapper.PrintError(msg2);
                }
            }
            if (GlobalRef.g_RS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
            {
                if (m_GuiManager.ScriptOps.iRs232ConnectDisconnect_impl() == 0 && !GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
                {
                    m_GuiManager.DllOps.iConnect(1U, 0U);
                    string full_command6 = string.Format("Debug Port Reconnected!", new object[0]);
                    m_GuiManager.RecordLog(9, full_command6);
                    KeepTrying(2000, new Func<bool>(spare_read));
                }
            }
            else if (GlobalRef.g_CasCadeDeviceSpiConnect == 0U)
            {
                string full_command7 = string.Format("Error Occurred in Port open close", new object[0]);
                m_GuiManager.RecordLog(9, full_command7);
            }
            return num;
        }

        public int iSetTDACaptureCard_ImplThread()
        {
            int num = -1;
            int num2 = -1;
            if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] && GlobalRef.g_CasCadeDeviceSpiConnect == 0U)
            {
                num = m_TsWrapper.Calling_WriteAddr_Single(4294959848U, 1U);
                if (m_GuiManager.DllOps.itempDisconnect(false) == 0)
                {
                    string full_command = string.Format("Debug Port Disconnected", new object[0]);
                    m_GuiManager.RecordLog(0, full_command);
                    if (!GlobalRef.g_RS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
                    {
                        m_GuiManager.ScriptOps.iRs232ConnectDisconnect_impl();
                    }
                }
            }
            m_GuiManager.MainTsForm.ChirpConfigTab.UpdateTDAAttributes();
            string[] array = GlobalRef.g_TDACaptureDirectory.Split(new char[]
            {
                '/'
            });
            int num3 = array.Length;
            string full_command2 = string.Format("ar1.TDACaptureCard_StartRecord_mult({0}, {1}, {2}, {3}, {4})", new object[]
            {
                GlobalRef.g_RadarDeviceId,
                GlobalRef.g_numFilesAllocated,
                GlobalRef.g_enablePackaging,
                array[num3 - 1],
                GlobalRef.g_numFramesToCapture
            });
            m_GuiManager.RecordLog(2, full_command2);
            if (!GlobalRef.f0002d2)
            {
                if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        uint num4 = GlobalRef.Width_TDA[i];
                        uint num5 = GlobalRef.Height_TDA[i];
                        string message = string.Format("Device {0} - Configuring TDA with Width : {1} and Height : {2}", i, num4, num5);
                        GlobalRef.LuaWrapper.PrintLuaWarning(message);
                        num = Imports.setWidthAndHeight((byte)(1 << i), num4, num5);
                        if (num == 0)
                        {
                            string full_command3 = string.Format("Device {0} - setWidthAndHeight Status: Passed", i);
                            m_GuiManager.RecordLog(8, full_command3);
                            GlobalRef.g_TDAsetWidthHeightDone[i] = true;
                        }
                        else
                        {
                            string msg = string.Format("Device {0} - setWidthAndHeight Status: Failed", i);
                            GlobalRef.LuaWrapper.PrintError(msg);
                        }
                    }
                }
                GlobalRef.f0002c9 = 0U;
                if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
                {
                    string message2 = string.Format("Sending Frame Periodicity of {0} to TDA..", GlobalRef.framePeriodicity_TDA);
                    GlobalRef.LuaWrapper.PrintLuaWarning(message2);
                    num = Imports.sendFramePeriodicitySync(GlobalRef.framePeriodicity_TDA);
                    if (num == 0)
                    {
                        string full_command4 = string.Format("Status: Passed. Frame Periodicity sent to TDA", new object[0]);
                        m_GuiManager.RecordLog(8, full_command4);
                    }
                    else
                    {
                        string full_command5 = string.Format("Status: Failed. Frame Periodicity not sent to TDA", new object[0]);
                        m_GuiManager.RecordLog(8, full_command5);
                    }
                    ushort num6 = 0;
                    while (GlobalRef.f0002c9 == 0U)
                    {
                        Thread.Sleep(100);
                        num6 += 1;
                        if (num6 > 30)
                        {
                            string msg2 = string.Format("Frame Periodicity Response from Capture Card timed out!!", new object[0]);
                            GlobalRef.LuaWrapper.PrintError(msg2);
                            return -1;
                        }
                    }
                }
                GlobalRef.f0002ca = 0U;
                if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
                {
                    string message3 = string.Format("Sending Capture Directory with name {0} to TDA..", GlobalRef.g_TDACaptureDirectory);
                    GlobalRef.LuaWrapper.PrintLuaWarning(message3);
                    num = Imports.setSessionDirectory(GlobalRef.g_TDACaptureDirectory);
                    if (num == 0)
                    {
                        string full_command6 = string.Format("Status: Passed. Capture Directory sent to TDA", new object[0]);
                        m_GuiManager.RecordLog(8, full_command6);
                    }
                    else
                    {
                        string full_command7 = string.Format("Status: Failed. Capture Directory not sent to TDA", new object[0]);
                        m_GuiManager.RecordLog(8, full_command7);
                    }
                    ushort num7 = 0;
                    while (GlobalRef.f0002ca == 0U)
                    {
                        Thread.Sleep(100);
                        num7 += 1;
                        if (num7 > 30)
                        {
                            string msg3 = string.Format("Capture Directory Response from Capture Card timed out!!", new object[0]);
                            GlobalRef.LuaWrapper.PrintError(msg3);
                            return -1;
                        }
                    }
                }
                GlobalRef.f0002cb = 0U;
                if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
                {
                    string message4 = string.Format("Sending File Allocation of {0} files to TDA..", GlobalRef.g_numFilesAllocated);
                    GlobalRef.LuaWrapper.PrintLuaWarning(message4);
                    num = Imports.sendNumAllocatedFiles(GlobalRef.g_numFilesAllocated);
                    if (num == 0)
                    {
                        string full_command8 = string.Format("Status: Passed. File Allocation sent to TDA", new object[0]);
                        m_GuiManager.RecordLog(8, full_command8);
                    }
                    else
                    {
                        string full_command9 = string.Format("Status: Failed. File Allocation not sent to TDA", new object[0]);
                        m_GuiManager.RecordLog(8, full_command9);
                    }
                    ushort num8 = 0;
                    while (GlobalRef.f0002cb == 0U)
                    {
                        Thread.Sleep(100);
                        num8 += 1;
                        if (num8 > 30)
                        {
                            string msg4 = string.Format("File Allocation Response from Capture Card timed out!!", new object[0]);
                            GlobalRef.LuaWrapper.PrintError(msg4);
                            return -1;
                        }
                    }
                }
                GlobalRef.f0002cc = 0U;
                if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
                {
                    string message5 = string.Format("Sending Enable Data Packaging (0 - 16-bit; 1 - 12-bit) with value of {0} to TDA..", GlobalRef.g_enablePackaging);
                    GlobalRef.LuaWrapper.PrintLuaWarning(message5);
                    num = Imports.enableDataPackaging(GlobalRef.g_enablePackaging);
                    if (num == 0)
                    {
                        string full_command10 = string.Format("Status: Passed. Enable Data Packaging sent to TDA", new object[0]);
                        m_GuiManager.RecordLog(8, full_command10);
                    }
                    else
                    {
                        string full_command11 = string.Format("Status: Failed. Enable Data Packaging not sent to TDA", new object[0]);
                        m_GuiManager.RecordLog(8, full_command11);
                    }
                    ushort num9 = 0;
                    while (GlobalRef.f0002cc == 0U)
                    {
                        Thread.Sleep(100);
                        num9 += 1;
                        if (num9 > 30)
                        {
                            string msg5 = string.Format("Enable Data Packaging Response from Capture Card timed out!!", new object[0]);
                            GlobalRef.LuaWrapper.PrintError(msg5);
                            return -1;
                        }
                    }
                }
                GlobalRef.f0002cd = 0U;
                if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
                {
                    string message6 = string.Format("Sending Number of frames to capture with value of {0} to TDA..", GlobalRef.g_numFramesToCapture);
                    GlobalRef.LuaWrapper.PrintLuaWarning(message6);
                    num = Imports.NumFramesToCapture(GlobalRef.g_numFramesToCapture);
                    if (num == 0)
                    {
                        string full_command12 = string.Format("Status: Passed. Number of frames to capture sent to TDA", new object[0]);
                        m_GuiManager.RecordLog(8, full_command12);
                    }
                    else
                    {
                        string full_command13 = string.Format("Status: Failed. Number of frames to capture not sent to TDA", new object[0]);
                        m_GuiManager.RecordLog(8, full_command13);
                    }
                    ushort num10 = 0;
                    while (GlobalRef.f0002cd == 0U)
                    {
                        Thread.Sleep(100);
                        num10 += 1;
                        if (num10 > 30)
                        {
                            string msg6 = string.Format("Number of frames to be captured response from Capture Card timed out!!", new object[0]);
                            GlobalRef.LuaWrapper.PrintError(msg6);
                            return -1;
                        }
                    }
                }
                GlobalRef.f0002c6 = 0U;
                if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
                {
                    num = Imports.TDACreateApplication();
                    if (num == 0)
                    {
                        string full_command14 = string.Format("Status: Passed for notifying TDA about Creating Application", new object[0]);
                        m_GuiManager.RecordLog(13, full_command14);
                    }
                    else
                    {
                        string msg7 = string.Format("Status: Failed for notifying TDA about Creating Application", new object[0]);
                        GlobalRef.LuaWrapper.PrintError(msg7);
                    }
                    ushort num11 = 0;
                    while (GlobalRef.f0002c6 == 0U)
                    {
                        Thread.Sleep(100);
                        num11 += 1;
                        if (num11 > 90)
                        {
                            string msg8 = string.Format("Create Application Response from Capture Card timed out!!", new object[0]);
                            GlobalRef.LuaWrapper.PrintError(msg8);
                            return -1;
                        }
                    }
                }
                GlobalRef.f0002c7 = 0U;
                if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
                {
                    num2 = Imports.startRecord();
                    if (num2 == 0)
                    {
                        string full_command15 = string.Format("Status: Passed for notifying TDA about Start Frame", new object[0]);
                        m_GuiManager.RecordLog(13, full_command15);
                    }
                    else
                    {
                        string msg9 = string.Format("Status: Failed for notifying TDA about Start Frame", new object[0]);
                        GlobalRef.LuaWrapper.PrintError(msg9);
                    }
                    EnableDisableBtnDisplayTDAStats(true);
                    ushort num12 = 0;
                    while (GlobalRef.f0002c7 == 0U)
                    {
                        Thread.Sleep(100);
                        num12 += 1;
                        if (num12 > 30)
                        {
                            string msg10 = string.Format("Start Record Response from Capture Card timed out!!", new object[0]);
                            GlobalRef.LuaWrapper.PrintError(msg10);
                            return -1;
                        }
                    }
                }
                if (num == 0 && num2 == 0)
                {
                    GlobalRef.f0002d2 = true;
                    if (GlobalRef.g_numFramesToCapture != 0U)
                    {
                        ChirpConfigTab.SetTDANumFramesTimerPeriodicity((int)((double)(GlobalRef.g_numFramesToCapture * m_ChirpConfigParams.periodicity) * 1.25));
                        ChirpConfigTab.SetTDANumFramesTimer(true);
                    }
                }
            }
            else
            {
                string msg11 = string.Format("Status: Failed. TDA ARM already done!", new object[0]);
                GlobalRef.LuaWrapper.PrintError(msg11);
            }
            return num + num2;
        }

        public int iSetRFCaptureCard_ImplThread()
        {
            int result = -1;
            if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] && GlobalRef.g_CasCadeDeviceSpiConnect == 0U)
            {
                result = m_TsWrapper.Calling_WriteAddr_Single(4294959848U, 1U);
                if (m_GuiManager.DllOps.itempDisconnect(false) == 0)
                {
                    string full_command = string.Format("Debug Port Disconnected", new object[0]);
                    m_GuiManager.RecordLog(0, full_command);
                    if (!GlobalRef.g_RS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
                    {
                        m_GuiManager.ScriptOps.iRs232ConnectDisconnect_impl();
                    }
                }
            }
            string text = Path.GetDirectoryName(Application.StartupPath) + "\\PostProc";
            string text2 = "cf.json";
            string path = text + "\\cf.json";
            string text3 = "DCA1000EVM_CLI_Record.exe";
            string capturePath = m_ChirpConfigTab.getCapturePath();
            if (string.IsNullOrEmpty(capturePath))
            {
                string msg = string.Format("Please select a file to save Data Capture Raw ADC data for Post Processing", new object[0]);
                m_GuiManager.Log(msg);
                return 0;
            }
            int num = GlobalRef.g_CapturePktSequenceEnaDisable ? 1 : 0;
            if (GlobalRef.g_RadarDeviceId == 1U)
            {
                string full_command2 = string.Format("ar1.CaptureCardConfig_StartRecord(\"{0}\", {1})", new object[]
                {
                    capturePath,
                    num
                });
                m_GuiManager.RecordLog(2, full_command2);
            }
            m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableTheStartCaptureButtonTillStopCaptureFinish(true);
            string[] array = capturePath.Split(new char[]
            {
                '\\'
            });
            int num2 = array.Length;
            string text4 = "";
            for (int i = 0; i < num2 - 1; i++)
            {
                if (i != num2 - 2)
                {
                    text4 = text4 + array[i] + "\\";
                }
                else if (i == num2 - 2)
                {
                    text4 += array[i];
                }
            }
            string arg = text4;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(array[num2 - 1]);
            object obj = JsonConvert.DeserializeObject(File.ReadAllText(path));
            if (c000271.f0001ae == null)
            {
                c000271.f0001ae = CallSite<Func<CallSite, object, string, string, object>>.Create(Binder.SetIndex(CSharpBinderFlags.None, typeof(frmAR1Main), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
                }));
            }
            Func<CallSite, object, string, string, object> target = c000271.f0001ae.Target;
            CallSite f0001ae = c000271.f0001ae;
            if (c000271.f0001ad == null)
            {
                c000271.f0001ad = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(frmAR1Main), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
                }));
            }
            Func<CallSite, object, string, object> target2 = c000271.f0001ad.Target;
            CallSite f0001ad = c000271.f0001ad;
            if (c000271.f0001ac == null)
            {
                c000271.f0001ac = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(frmAR1Main), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
                }));
            }
            target(f0001ae, target2(f0001ad, c000271.f0001ac.Target(c000271.f0001ac, obj, "DCA1000Config"), "captureConfig"), "fileBasePath", arg);
            if (c000271.f0001b1 == null)
            {
                c000271.f0001b1 = CallSite<Func<CallSite, object, string, string, object>>.Create(Binder.SetIndex(CSharpBinderFlags.None, typeof(frmAR1Main), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
                }));
            }
            Func<CallSite, object, string, string, object> target3 = c000271.f0001b1.Target;
            CallSite f0001b = c000271.f0001b1;
            if (c000271.f0001b0 == null)
            {
                c000271.f0001b0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(frmAR1Main), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
                }));
            }
            Func<CallSite, object, string, object> target4 = c000271.f0001b0.Target;
            CallSite f0001b2 = c000271.f0001b0;
            if (c000271.f0001af == null)
            {
                c000271.f0001af = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(frmAR1Main), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
                }));
            }
            target3(f0001b, target4(f0001b2, c000271.f0001af.Target(c000271.f0001af, obj, "DCA1000Config"), "captureConfig"), "filePrefix", fileNameWithoutExtension);
            if (c000271.f0001b4 == null)
            {
                c000271.f0001b4 = CallSite<Func<CallSite, object, string, int, object>>.Create(Binder.SetIndex(CSharpBinderFlags.None, typeof(frmAR1Main), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
                }));
            }
            Func<CallSite, object, string, int, object> target5 = c000271.f0001b4.Target;
            CallSite f0001b3 = c000271.f0001b4;
            if (c000271.f0001b3 == null)
            {
                c000271.f0001b3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(frmAR1Main), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
                }));
            }
            Func<CallSite, object, string, object> target6 = c000271.f0001b3.Target;
            CallSite f0001b4 = c000271.f0001b3;
            if (c000271.f0001b2 == null)
            {
                c000271.f0001b2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(frmAR1Main), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
                }));
            }
            target5(f0001b3, target6(f0001b4, c000271.f0001b2.Target(c000271.f0001b2, obj, "DCA1000Config"), "captureConfig"), "sequenceNumberEnable", num);
            if (c000271.f0001b6 == null)
            {
                c000271.f0001b6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(frmAR1Main)));
            }
            Func<CallSite, object, string> target7 = c000271.f0001b6.Target;
            CallSite f0001b5 = c000271.f0001b6;
            if (c000271.f0001b5 == null)
            {
                c000271.f0001b5 = CallSite<Func<CallSite, Type, object, Formatting, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "SerializeObject", null, typeof(frmAR1Main), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
                }));
            }
            string contents = target7(f0001b5, c000271.f0001b5.Target(c000271.f0001b5, typeof(JsonConvert), obj, Formatting.Indented));
            File.WriteAllText(path, contents);
            string text5 = "start_record";
            string arguments = string.Concat(new string[]
            {
                "/C ",
                text3,
                " ",
                text5,
                " ",
                text2
            });
            GlobalRef.g_processLua = Process.Start(new ProcessStartInfo
            {
                FileName = "CMD.EXE",
                WorkingDirectory = text,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = true
            });
            string full_command3 = string.Format("Sending {0} command to DCA1000", text5);
            m_GuiManager.RecordLog(0, full_command3);
            string text6 = "";
            if (GlobalRef.g_processLua != null && !GlobalRef.g_processLua.HasExited)
            {
                GlobalRef.g_processLua.WaitForExit();
                text6 = GlobalRef.g_processLua.StandardOutput.ReadToEnd();
                m_GuiManager.RecordLog(0, text6);
            }
            if (text6 == "\r\nStart Record command : Success\r\n\r\nRecord is completed\r\n\r\nRecord stop is done successfully\r\n")
            {
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableTheStartCaptureButtonTillStopCaptureFinish(false);
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableTriggerAndPostProcButton(false);
            }
            else
            {
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableTheStartCaptureButtonTillStopCaptureFinish(false);
            }
            CopyMatlabLogFileForDCA1000(capturePath);
            Thread.Sleep(100);
            return result;
        }

        public int CopyMatlabLogFileForDCA1000(string logFileName)
        {
            string empty = string.Empty;
            string directoryName = Path.GetDirectoryName(Application.StartupPath);
            string text = string.Concat(new string[]
            {
                directoryName + "\\PostProc\\LogFile.txt"
            });
            string text2 = ".bin";
            string destFileName = logFileName.Remove(logFileName.IndexOf(text2), text2.Length) + "_LogFile.txt";
            if (File.Exists(text))
            {
                File.Copy(text, destFileName, true);
            }
            return 0;
        }

        public void m000037()
        {
            string text = string.Empty;
            try
            {
                Path.GetDirectoryName(Application.ExecutablePath);
                if (!string.IsNullOrEmpty(m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath()))
                {
                    string text2 = m_GuiManager.MainTsForm.ChirpConfigTab.iGetMtLbPostProcPath();
                    string full_command = string.Format("ar1.StartTsw1400Arm(\"{0}\")", text2);
                    m_GuiManager.RecordLog(0, full_command);
                    int num = Convert.ToInt32(((double[])((MWNumericArray)MatlabPostProcGuiInstance.setup_for_triggered_capture_max_30_frames(text2)).ToVector(MWArrayComponent.Real))[0]);
                    text = InterpretConfigInvalidData(num);
                    if (text.Replace('\t'.ToString(), "").Replace("\"", "") == "No Error")
                    {
                        string.Format("MatlabProc Status: {0}", new object[]
                        {
                            text
                        });
                    }
                    else
                    {
                        string full_command2 = string.Format("MatlabProc Status: Error Number: {0}", new object[]
                        {
                            num
                        });
                        m_GuiManager.RecordLog(8, full_command2);
                        string full_command3 = string.Format("MatlabProc Status: Error Type: {0}", new object[]
                        {
                            text
                        });
                        m_GuiManager.RecordLog(8, full_command3);
                    }
                    string full_command4 = string.Format("TSW1400 capture complete", new object[0]);
                    m_GuiManager.RecordLog(0, full_command4);
                }
                else
                {
                    string msg = string.Format("Please select a file to save ADC data for Post Processing", new object[0]);
                    m_GuiManager.Log(msg);
                }
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        public string InterpretConfigInvalidData(int ConfigInvalid)
        {
            string text = string.Empty;
            char c = '\t';
            char c2 = ',';
            string path = string.Empty;
            string directoryName = Path.GetDirectoryName(Application.StartupPath);
            path = string.Concat(new string[]
            {
                directoryName + "\\PostProc\\InvalidConfigErr.csv"
            });
            try
            {
                if (File.Exists(path))
                {
                    StreamReader streamReader = new StreamReader(path);
                    if (streamReader.Peek() != -1)
                    {
                        streamReader.ReadLine();
                    }
                    else
                    {
                        MessageBox.Show("File is Empty!!");
                    }
                    while (streamReader.Peek() != -1)
                    {
                        string[] array = streamReader.ReadLine().Split(new char[]
                        {
                            c2
                        });
                        if (!Convert.ToBoolean(ConfigInvalid))
                        {
                            if (Convert.ToBoolean(Convert.ToInt32(array[0]) == 0))
                            {
                                text += array[1];
                            }
                            return text;
                        }
                        if (Convert.ToBoolean(ConfigInvalid & 1) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 1))
                        {
                            text += array[1];
                        }
                        else if (Convert.ToBoolean(ConfigInvalid & 2) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 2))
                        {
                            text += array[1];
                        }
                        else if (Convert.ToBoolean(ConfigInvalid & 4) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 4))
                        {
                            text += array[1];
                        }
                        else if (Convert.ToBoolean(ConfigInvalid & 8) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 8))
                        {
                            text += array[1];
                        }
                        else if (Convert.ToBoolean(ConfigInvalid & 16) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 16))
                        {
                            text += array[1];
                        }
                        else if (Convert.ToBoolean(ConfigInvalid & 32) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 32))
                        {
                            text += array[1];
                        }
                        else if (Convert.ToBoolean(ConfigInvalid & 64) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 64))
                        {
                            text += array[1];
                        }
                        else if (Convert.ToBoolean(ConfigInvalid & 128) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 128))
                        {
                            text += array[1];
                        }
                        else if (Convert.ToBoolean(ConfigInvalid & 256) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 256))
                        {
                            text += array[1];
                        }
                        else if (Convert.ToBoolean(ConfigInvalid & 512) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 512))
                        {
                            text += array[1];
                        }
                        else if (Convert.ToBoolean(ConfigInvalid & 1024) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 1024))
                        {
                            text += array[1];
                        }
                        else if (Convert.ToBoolean(ConfigInvalid & 2048) && Convert.ToBoolean(Convert.ToInt32(array[0]) == 2048))
                        {
                            text += array[1];
                        }
                    }
                    streamReader.Close();
                }
                else
                {
                    string full_command = string.Format("PostProc folder doesn't have InvalidConfigErr.csv. Please place it back", new object[0]);
                    m_GuiManager.RecordLog(0, full_command);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return text.Replace(c.ToString(), "  # ");
        }

        public void startTsw1400Capture()
        {
            new del_v_v(m000037).BeginInvoke(null, null);
        }

        public void debugstartRFDataCaptureCardCapture()
        {
            iSetRFCaptureCard_ImplThread();
        }

        public void startTDACaptureCardCapture()
        {
            new del_i_v(iSetTDACaptureCard_ImplThread).BeginInvoke(null, null);
        }

        public void startRFDataCaptureCardCapture()
        {
            new del_i_v(iSetRFCaptureCard_ImplThread).BeginInvoke(null, null);
        }

        public void startMatlabPostProc()
        {
            new del_v_v(iStartMtlabPostProc).BeginInvoke(null, null);
        }

        public void ReturnStrongestDetectedObject()
        {
            new del_v_v(iStarReturnStrongestDetectedObject).BeginInvoke(null, null);
        }

        public void startMatlabRealTimeProc()
        {
            new del_v_v(iStartMtlabRealTimeProc).BeginInvoke(null, null);
        }

        private void m_timerChkOvfBtnEnabl_Tick(object sender, EventArgs p1)
        {
            m_GuiManager.ScriptOps.iEnableTabButtons();
        }

        public void SetOvBtEnblTimer(bool enable)
        {
            if (base.InvokeRequired)
            {
                del_v_b method = new del_v_b(SetOvBtEnblTimer);
                base.Invoke(method, new object[]
                {
                    enable
                });
                return;
            }
            if (enable)
            {
                m_timerChkOvfBtnEnabl.Start();
                return;
            }
            m_timerChkOvfBtnEnabl.Stop();
        }

        public void iSetConnectionTimer(bool enable)
        {
            if (base.InvokeRequired)
            {
                del_v_b method = new del_v_b(iSetConnectionTimer);
                base.Invoke(method, new object[]
                {
                    enable
                });
                return;
            }
            if (enable)
            {
                m_timerCheckConnection.Start();
                return;
            }
            m_timerCheckConnection.Stop();
        }

        private void m_timerCheckConnection_Tick(object sender, EventArgs p1)
        {
            if (m_GuiManager.MainTsForm.ConnectTab.m_bIsConnectInProgress)
            {
                return;
            }
            if (m_GuiManager.MainTsForm.ConnectTab.m_bFwDownloadInProgress)
            {
                return;
            }
            if (GuiSettings.Default.Connection.PollConnection == "1")
            {
                if (SerialPort.GetPortNames().Length == 0)
                {
                    m_GuiManager.MainTsForm.BoardStatus = BoardStatus.DISCONNECTED;
                    m_ConnectTab.ConnectivityStatus.Text = "Disconnected";
                    m_ConnectTab.ConnectivityStatus.ForeColor = Color.Red;
                    m_ConnectTab.RadarDevice2ConnectivityStatus.Text = "Disconnected";
                    m_ConnectTab.RadarDevice2ConnectivityStatus.ForeColor = Color.Red;
                    m_ConnectTab.RadarDevice3ConnectivityStatus.Text = "Disconnected";
                    m_ConnectTab.RadarDevice3ConnectivityStatus.ForeColor = Color.Red;
                    m_ConnectTab.RadarDevice4ConnectivityStatus.Text = "Disconnected";
                    m_ConnectTab.RadarDevice4ConnectivityStatus.ForeColor = Color.Red;
                    iSetConnectionTimer(true);
                    return;
                }
                m_ConnectTab.ConnectivityStatus.Text = "Connected";
                m_ConnectTab.ConnectivityStatus.ForeColor = Color.Green;
                m_ConnectTab.RadarDevice2ConnectivityStatus.Text = "Connected";
                m_ConnectTab.RadarDevice2ConnectivityStatus.ForeColor = Color.Green;
                m_ConnectTab.RadarDevice3ConnectivityStatus.Text = "Connected";
                m_ConnectTab.RadarDevice3ConnectivityStatus.ForeColor = Color.Green;
                m_ConnectTab.RadarDevice4ConnectivityStatus.Text = "Connected";
                m_ConnectTab.RadarDevice4ConnectivityStatus.ForeColor = Color.Green;
                iSetConnectionTimer(true);
            }
        }

        private void iStartHsdcStUpInvoke()
        {
            m_GuiManager.MainTsForm.ChirpConfigTab.m00000f();
            string full_command = string.Format("ar1.SetupTSW1400()", new object[0]);
            m_GuiManager.RecordLog(0, full_command);
            MatlabPostProcGuiInstance.setup_HSDCPro(1.0, 1.0, 0.0, 0.0, 0.0, 30000.0, 4096.0);
            string full_command2 = string.Format("TSW1400 set-up complete.", new object[0]);
            m_GuiManager.RecordLog(0, full_command2);
            m_GuiManager.MainTsForm.ChirpConfigTab.m00000e();
            SetTSW1400FunctionalState();
        }

        public void SetTSW1400FunctionalState()
        {
            m_btnStupHsdcPro.ForeColor = Color.Black;
        }

        public void iStartStUpHsdcProAsync()
        {
            iStartHsdcStUpInvoke();
        }

        public void UpdateCaptureCard(SetupObject dobject)
        {
            if (dobject.captureHardware == "DCA1000")
            {
                m_chbRFDataCaptureCard.Checked = true;
                return;
            }
            if (dobject.captureHardware == "TSW1400")
            {
                m_chbTSW1400Ena.Checked = true;
                return;
            }
            if (dobject.captureHardware == "TDA2XX")
            {
                m_chbTDABoard.Checked = true;
            }
        }

        public void getCaptureCard(SetupObject dobject)
        {
            if (m_chbRFDataCaptureCard.Checked)
            {
                dobject.captureHardware = "DCA1000";
                return;
            }
            if (m_chbTSW1400Ena.Checked)
            {
                dobject.captureHardware = "TSW1400";
                return;
            }
            if (m_chbTDABoard.Checked)
            {
                dobject.captureHardware = "TDA2XX";
            }
        }

        public void updateTDAStatus()
        {
            m_btnStupHsdcPro.Text = "SetUp TDAxx Capture Card";
            m_GuiManager.MainTsForm.ChirpConfigTab.iEnableTDADataCaptureCardSetUp();
            m_GuiManager.MainTsForm.ConnectTab.iEnableCaptureCardResetSetUp();
            GlobalRef.g_RFDataCaptureMode = false;
            GlobalRef.g_TDADataCaptureMode = true;
            GlobalRef.f0002d0 = false;
            m_TDAxxCaptureCard = new TDAxxCaptureCard();
        }

        public void m_btnStupHsdcPro_Click(object sender, EventArgs p1)
        {
            if (m_chbRFDataCaptureCard.Checked)
            {
                GlobalRef.g_RFDataCaptureMode = true;
                m_btnStupHsdcPro.Text = "SetUp DCA1000";
                m_GuiManager.MainTsForm.ChirpConfigTab.iEnableRFADCDataCaptureCardSetUp();
                m_GuiManager.MainTsForm.ConnectTab.iDisableCaptureCardResetSetUp();
                GlobalRef.g_RFDataCaptureMode = true;
                GlobalRef.f0002d0 = true;
                GlobalRef.g_TDADataCaptureMode = false;
            }
            else if (m_chbTDABoard.Checked)
            {
                m_btnStupHsdcPro.Text = "SetUp TDAxx Capture Card";
                m_GuiManager.MainTsForm.ChirpConfigTab.iEnableTDADataCaptureCardSetUp();
                m_GuiManager.MainTsForm.ConnectTab.iEnableCaptureCardResetSetUp();
                GlobalRef.g_RFDataCaptureMode = false;
                GlobalRef.g_TDADataCaptureMode = true;
                GlobalRef.f0002d0 = false;
            }
            else
            {
                GlobalRef.g_RFDataCaptureMode = false;
                m_btnStupHsdcPro.Text = "SetUp TSW1400";
                m_chbTSW1400Ena.Checked = true;
                m_GuiManager.MainTsForm.ConnectTab.iEnableCaptureCardResetSetUp();
                GlobalRef.g_RFDataCaptureMode = false;
                GlobalRef.f0002d0 = false;
                GlobalRef.g_TDADataCaptureMode = false;
            }
            if (GlobalRef.g_RFDataCaptureMode)
            {
                if (GlobalRef.RFDataCaptureCard == null || GlobalRef.RFDataCaptureCard.Text == "")
                {
                    m_RFDataCaptureCard = new RFDataCaptureCard();
                    m_RFDataCaptureCard.Show();
                    GlobalRef.RFDataCaptureCard = m_RFDataCaptureCard;
                    m_RFDataCaptureCard.UpdateRFDCCardDllVersion();
                    SelectCaptureDevice("DCA1000");
                    if (GlobalRef.f0002d3 != "")
                    {
                        GlobalRef.RFDataCaptureCard.m00006e(GlobalRef.f0002d3.ToString());
                        m_RFDataCaptureCard.UpdateCaptureCardDeviceConnectionConfigToGUI(false);
                        return;
                    }
                    m_RFDataCaptureCard.UpdateCaptureCardDeviceConnectionConfigToGUI(true);
                    return;
                }
                else if (CheckOpened(GlobalRef.RFDataCaptureCard.Text))
                {
                    if (GlobalRef.f0002d3 != "")
                    {
                        GlobalRef.RFDataCaptureCard.m00006e(GlobalRef.f0002d3.ToString());
                        return;
                    }
                }
                else if (GlobalRef.f0002d3 != "")
                {
                    GlobalRef.RFDataCaptureCard.m00006e(GlobalRef.f0002d3.ToString());
                    GlobalRef.RFDataCaptureCard.Show();
                    return;
                }
            }
            else if (GlobalRef.g_TDADataCaptureMode)
            {
                if (GlobalRef.TDAxxCaptureCard == null || GlobalRef.TDAxxCaptureCard.Text == "")
                {
                    m_TDAxxCaptureCard = new TDAxxCaptureCard();
                    m_TDAxxCaptureCard.Show();
                    GlobalRef.TDAxxCaptureCard = m_TDAxxCaptureCard;
                    SelectCaptureDevice("TDA2XX");
                    if (GlobalRef.g_TDACaptureCardConnectStatus)
                    {
                        if (GlobalRef.f0002cf != string.Empty)
                        {
                            GlobalRef.TDAxxCaptureCard.m0000d4(GlobalRef.f0002cf);
                        }
                        m_TDAxxCaptureCard.GetTDADeviceMap(GlobalRef.g_TDADeviceMap);
                        m_TDAxxCaptureCard.SetTDAVersion(GlobalRef.g_TDAVersion);
                        m_TDAxxCaptureCard.UpdateTDACaptureCardDeviceConnectionConfigDataToGUI(true);
                        return;
                    }
                    if (GlobalRef.f0002cf != string.Empty)
                    {
                        GlobalRef.TDAxxCaptureCard.m0000d4(GlobalRef.f0002cf);
                    }
                    m_TDAxxCaptureCard.UpdateTDACaptureCardDeviceConnectionConfigDataToGUI(false);
                    return;
                }
                else if (CheckOpened(GlobalRef.TDAxxCaptureCard.Text))
                {
                    if (GlobalRef.g_TDACaptureCardConnectStatus)
                    {
                        if (GlobalRef.f0002cf != string.Empty)
                        {
                            GlobalRef.TDAxxCaptureCard.m0000d4(GlobalRef.f0002cf);
                        }
                        GlobalRef.TDAxxCaptureCard.GetTDADeviceMap(GlobalRef.g_TDADeviceMap);
                        GlobalRef.TDAxxCaptureCard.SetTDAVersion(GlobalRef.g_TDAVersion);
                        return;
                    }
                }
                else if (GlobalRef.g_TDACaptureCardConnectStatus)
                {
                    if (GlobalRef.f0002cf != string.Empty)
                    {
                        GlobalRef.TDAxxCaptureCard.m0000d4(GlobalRef.f0002cf);
                    }
                    GlobalRef.TDAxxCaptureCard.GetTDADeviceMap(GlobalRef.g_TDADeviceMap);
                    GlobalRef.TDAxxCaptureCard.SetTDAVersion(GlobalRef.g_TDAVersion);
                    GlobalRef.TDAxxCaptureCard.Show();
                    return;
                }
            }
            else
            {
                SelectCaptureDevice("TSW1400");
                iStartStUpHsdcProAsync();
            }
        }

        private bool CheckOpened(string name)
        {
            foreach(Form f in Application.OpenForms)
                if (f.Text == name)
                    return true;
            return false;
        }

        public void m000038()
        {
            if (m_chbRFDataCaptureCard.Checked)
            {
                GlobalRef.g_RFDataCaptureMode = true;
                m_btnStupHsdcPro.Text = "SetUp DCA1000";
                m_GuiManager.MainTsForm.ChirpConfigTab.iEnableRFADCDataCaptureCardSetUp();
                m_GuiManager.MainTsForm.ConnectTab.iDisableCaptureCardResetSetUp();
                GlobalRef.g_RFDataCaptureMode = true;
                GlobalRef.f0002d0 = true;
                GlobalRef.g_TDADataCaptureMode = false;
            }
            else if (m_chbTDABoard.Checked)
            {
                m_btnStupHsdcPro.Text = "SetUp TDAxx Capture Card";
                m_GuiManager.MainTsForm.ChirpConfigTab.iEnableTDADataCaptureCardSetUp();
                m_GuiManager.MainTsForm.ConnectTab.iEnableCaptureCardResetSetUp();
                GlobalRef.g_RFDataCaptureMode = false;
                GlobalRef.g_TDADataCaptureMode = true;
                GlobalRef.f0002d0 = false;
            }
            else
            {
                GlobalRef.g_RFDataCaptureMode = false;
                m_btnStupHsdcPro.Text = "SetUp TSW1400";
                m_chbTSW1400Ena.Checked = true;
                m_GuiManager.MainTsForm.ConnectTab.iEnableCaptureCardResetSetUp();
                GlobalRef.g_RFDataCaptureMode = false;
                GlobalRef.f0002d0 = false;
                GlobalRef.g_TDADataCaptureMode = false;
            }
            if (GlobalRef.g_RFDataCaptureMode)
            {
                if (GlobalRef.RFDataCaptureCard == null || GlobalRef.RFDataCaptureCard.Text == "")
                {
                    m_RFDataCaptureCard = new RFDataCaptureCard();
                    m_RFDataCaptureCard.Show();
                    RFDataCaptureCard.UpdateEthernetConfig(GlobalRef.dobject);
                    GlobalRef.RFDataCaptureCard = m_RFDataCaptureCard;
                    m_RFDataCaptureCard.UpdateRFDCCardDllVersion();
                    SelectCaptureDevice("DCA1000");
                    return;
                }
                if (CheckOpened(GlobalRef.RFDataCaptureCard.Text))
                {
                    if (GlobalRef.f0002d3 != "")
                    {
                        GlobalRef.RFDataCaptureCard.m00006e(GlobalRef.f0002d3.ToString());
                        return;
                    }
                }
                else if (GlobalRef.f0002d3 != "")
                {
                    GlobalRef.RFDataCaptureCard.m00006e(GlobalRef.f0002d3.ToString());
                    GlobalRef.RFDataCaptureCard.Show();
                    return;
                }
            }
            else if (GlobalRef.g_TDADataCaptureMode)
            {
                if (GlobalRef.TDAxxCaptureCard == null || GlobalRef.TDAxxCaptureCard.Text == "")
                {
                    m_TDAxxCaptureCard = new TDAxxCaptureCard();
                    m_TDAxxCaptureCard.Show();
                    GlobalRef.TDAxxCaptureCard = m_TDAxxCaptureCard;
                    SelectCaptureDevice("TDA2XX");
                    return;
                }
                if (CheckOpened(GlobalRef.TDAxxCaptureCard.Text))
                {
                    if (GlobalRef.f0002cf != string.Empty)
                    {
                        GlobalRef.TDAxxCaptureCard.m0000d4(GlobalRef.f0002cf);
                    }
                    GlobalRef.TDAxxCaptureCard.GetTDADeviceMap(GlobalRef.g_TDADeviceMap);
                    GlobalRef.TDAxxCaptureCard.SetTDAVersion(GlobalRef.g_TDAVersion);
                    return;
                }
                if (GlobalRef.f0002cf != string.Empty)
                {
                    GlobalRef.TDAxxCaptureCard.m0000d4(GlobalRef.f0002cf);
                    GlobalRef.TDAxxCaptureCard.GetTDADeviceMap(GlobalRef.g_TDADeviceMap);
                    GlobalRef.TDAxxCaptureCard.SetTDAVersion(GlobalRef.g_TDAVersion);
                    GlobalRef.TDAxxCaptureCard.Show();
                    return;
                }
            }
            else
            {
                SelectCaptureDevice("TSW1400");
                iStartStUpHsdcProAsync();
            }
        }

        private void m_tabStaticConfigHolder_Click(object sender, EventArgs p1)
        {
        }

        public int SelectCaptureDevice(string CaptureDeviceType)
        {
            int result;
            try
            {
                string full_command = string.Format("ar1.SelectCaptureDevice(\"{0}\")", CaptureDeviceType);
                m_GuiManager.RecordLog(0, full_command);
                string full_command2 = string.Format("Status: Passed", new object[0]);
                m_GuiManager.RecordLog(0, full_command2);
                if (CaptureDeviceType == "DCA1000")
                {
                    m_chbRFDataCaptureCard.Checked = true;
                }
                else if (CaptureDeviceType == "TSW1400")
                {
                    m_chbTSW1400Ena.Checked = true;
                }
                else if (CaptureDeviceType == "TDA2XX")
                {
                    m_chbTDABoard.Checked = true;
                }
                MatlabPostProcGuiInstance.select_capture_device(CaptureDeviceType);
                result = 0;
            }
            catch (Exception ex)
            {
                m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = -1;
            }
            return result;
        }

        public void iSetDevice1Checked()
        {
            if (base.InvokeRequired)
            {
                del_v_v method = new del_v_v(iSetDevice1Checked);
                base.Invoke(method);
                return;
            }
            m_chkRadarDevice1.Checked = true;
            m_chkRadarDevice2.Checked = false;
            m_chkRadarDevice3.Checked = false;
            m_chkRadarDevice4.Checked = false;
        }

        public ushort getRadarDevMapGui()
        {
            return (ushort)((m_chkRadarDevice1.Checked ? 1 : 0) | (m_chkRadarDevice2.Checked ? 1 : 0) << 1 | (m_chkRadarDevice3.Checked ? 1 : 0) << 2 | (m_chkRadarDevice4.Checked ? 1 : 0) << 3);
        }

        public int setRadarDevMapGui(uint devMap)
        {
            if (base.InvokeRequired)
            {
                del_i_u method = new del_i_u(setRadarDevMapGui);
                return (int)base.Invoke(method, new object[]
                {
                    devMap
                });
            }
            m_chkRadarDevice1.Checked = ((devMap & 1U) == 1U);
            m_chkRadarDevice2.Checked = ((devMap & 2U) == 2U);
            m_chkRadarDevice3.Checked = ((devMap & 4U) == 4U);
            m_chkRadarDevice4.Checked = ((devMap & 8U) == 8U);
            return 0;
        }

        public int getRadarDevIndx(uint deviceMap)
        {
            int num = 0;
            uint num2 = deviceMap;
            while (num2 != 0U && (num2 & 1U) != 1U)
            {
                num++;
                num2 >>= 1;
            }
            return num;
        }

        private void m_nudRadarDevice1Id_Changed(object sender, EventArgs p1)
        {
            if (m_chkRadarDevice1.Checked)
            {
                GlobalRef.g_RadarDeviceId |= 1U;
                GlobalRef.g_RadarDeviceIndex = 0U;
                m_StaticConfigTab.SelectMasterCascading();
            }
            else
            {
                GlobalRef.g_RadarDeviceId &= 4294967294U;
            }
            m_GuiManager.MainTsForm.ConnectTab.UpdateSPIConnectDevice();
            m_GuiManager.MainTsForm.ConnectTab.UpdateRFPowerUpDevice();
            m_GuiManager.MainTsForm.ConnectTab.UpdateCRCandAck();
        }

        private void m_nudRadarDevice2Id_Changed(object sender, EventArgs p1)
        {
            if (m_chkRadarDevice2.Checked)
            {
                GlobalRef.g_RadarDeviceId |= 2U;
                GlobalRef.g_RadarDeviceIndex = 1U;
                m_StaticConfigTab.SelectSlaveCascading();
            }
            else
            {
                GlobalRef.g_RadarDeviceId &= 4294967293U;
            }
            m_GuiManager.MainTsForm.ConnectTab.UpdateSPIConnectDevice();
            m_GuiManager.MainTsForm.ConnectTab.UpdateRFPowerUpDevice();
            m_GuiManager.MainTsForm.ConnectTab.UpdateCRCandAck();
        }

        private void m_nudRadarDevice3Id_Changed(object sender, EventArgs p1)
        {
            if (m_chkRadarDevice3.Checked)
            {
                GlobalRef.g_RadarDeviceId |= 4U;
                GlobalRef.g_RadarDeviceIndex = 2U;
                m_StaticConfigTab.SelectSlaveCascading();
            }
            else
            {
                GlobalRef.g_RadarDeviceId &= 4294967291U;
            }
            m_GuiManager.MainTsForm.ConnectTab.UpdateSPIConnectDevice();
            m_GuiManager.MainTsForm.ConnectTab.UpdateRFPowerUpDevice();
            m_GuiManager.MainTsForm.ConnectTab.UpdateCRCandAck();
        }

        private void m_nudRadarDevice4Id_Changed(object sender, EventArgs p1)
        {
            if (m_chkRadarDevice4.Checked)
            {
                GlobalRef.g_RadarDeviceId |= 8U;
                GlobalRef.g_RadarDeviceIndex = 3U;
                m_StaticConfigTab.SelectSlaveCascading();
            }
            else
            {
                GlobalRef.g_RadarDeviceId &= 4294967287U;
            }
            m_GuiManager.MainTsForm.ConnectTab.UpdateSPIConnectDevice();
            m_GuiManager.MainTsForm.ConnectTab.UpdateRFPowerUpDevice();
            m_GuiManager.MainTsForm.ConnectTab.UpdateCRCandAck();
        }

        private void m_nudRadarDeviceSystem_ValueChanged(object sender, EventArgs p1)
        {
            if (m_DeviceMode.SelectedIndex == 0)
            {
                selectCascadeMode(0);
                return;
            }
            if (m_DeviceMode.SelectedIndex == 1)
            {
                selectCascadeMode(1);
                return;
            }
            selectCascadeMode(2);
        }

        public int selectCascadeMode(int mode)
        {
            string full_command = string.Format("ar1.selectCascadeMode({0})", mode);
            m_GuiManager.RecordLog(0, full_command);
            if (mode == 0)
            {
                if (GlobalRef.g_StudioInit1)
                {
                    GlobalRef.g_StudioInit1 = false;
                    m_GuiManager.MainTsForm.ConnectTab.EnableDisbleRadarDeviceStatus(1);
                }
                else
                {
                    GlobalRef.g_2ChipCascade = true;
                    GlobalRef.g_4ChipCascade = false;
                    m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableFramingStatus(true);
                    m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableWidthHeightStatus(true);
                    m_GuiManager.MainTsForm.RegOpeTab.DisableAndEnableGPIOStatus(true);
                    m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableNumFilesCaptureStatus(true);
                    m_GuiManager.MainTsForm.DataConfigTab.setCSI2DataPath();
                    Imports.RadarLinkImpl_setSystemType(2);
                    m_chkRadarDevice1.Visible = true;
                    m_chkRadarDevice2.Visible = true;
                    m_chkRadarDevice3.Visible = false;
                    m_chkRadarDevice4.Visible = false;
                    m_GuiManager.ScriptOps.UpdateDevicesDetected(2);
                    m_ConnectTab.UpdateNumberOfRadarDevicesDetected();
                }
            }
            else if (mode == 1)
            {
                GlobalRef.g_4ChipCascade = true;
                GlobalRef.g_2ChipCascade = false;
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableFramingStatus(false);
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableWidthHeightStatus(false);
                m_GuiManager.MainTsForm.RegOpeTab.DisableAndEnableGPIOStatus(false);
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableNumFilesCaptureStatus(false);
                m_GuiManager.MainTsForm.DataConfigTab.setCSI2DataPath();
                Imports.RadarLinkImpl_setSystemType(3);
                m_grpRadarDeviceSelection.Visible = true;
                m_chkRadarDevice1.Visible = true;
                m_chkRadarDevice2.Visible = true;
                m_chkRadarDevice3.Visible = true;
                m_chkRadarDevice4.Visible = true;
                m_GuiManager.ScriptOps.UpdateDevicesDetected(4);
                m_ConnectTab.UpdateNumberOfRadarDevicesDetected();
            }
            else
            {
                GlobalRef.g_2ChipCascade = false;
                GlobalRef.g_4ChipCascade = false;
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableFramingStatus(true);
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableWidthHeightStatus(true);
                m_GuiManager.MainTsForm.RegOpeTab.DisableAndEnableGPIOStatus(true);
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableNumFilesCaptureStatus(true);
                m_grpRadarDeviceSelection.Visible = false;
                m_chkRadarDevice1.Visible = false;
                m_chkRadarDevice2.Visible = false;
                m_chkRadarDevice3.Visible = false;
                m_chkRadarDevice4.Visible = false;
            }
            full_command = string.Format("Status: Passed", new object[0]);
            m_GuiManager.RecordLog(0, full_command);
            return 0;
        }

        public int selectCascadeModeLua(uint mode)
        {
            if (base.InvokeRequired)
            {
                del_i_u method = new del_i_u(selectCascadeModeLua);
                return (int)base.Invoke(method, new object[]
                {
                    mode
                });
            }
            if (mode != 0U)
            {
                if (mode != 1U)
                {
                    string msg = string.Format("Invalid argument!", new object[0]);
                    GlobalRef.LuaWrapper.PrintError(msg);
                    return -1;
                }
                m_DeviceMode.SelectedIndex = 1;
            }
            else
            {
                m_DeviceMode.SelectedIndex = 0;
            }
            return 0;
        }

        private void m_CheckBoxRFDataCaptureCard_ValueChanged(object sender, EventArgs p1)
        {
        }

        private void m_CheckBoxTSW1400SetUpConfig_ValueChanged(object sender, EventArgs p1)
        {
        }

        private void JsonConfigMainButton_Click(object sender, EventArgs p1)
        {
            m_Tbc.SelectedTab = m_tabImportExportTabConfigHolder;
        }

        private void m_chbTDABoard_CheckedChanged(object sender, EventArgs p1)
        {
        }

        private void m_RadarMode_SelectedIndexChanged(object sender, EventArgs p1)
        {
            if (m_RadarMode.SelectedIndex == 0)
            {
                selectRadarMode(0);
                return;
            }
            if (m_RadarMode.SelectedIndex == 1)
            {
                selectRadarMode(1);
            }
        }

        public int selectRadarModeLua(uint mode)
        {
            if (base.InvokeRequired)
            {
                del_i_u method = new del_i_u(selectRadarModeLua);
                return (int)base.Invoke(method, new object[]
                {
                    mode
                });
            }
            if (mode != 0U)
            {
                if (mode != 1U)
                {
                    string msg = string.Format("Invalid argument!", new object[0]);
                    GlobalRef.LuaWrapper.PrintError(msg);
                    return -1;
                }
                m_RadarMode.SelectedIndex = 1;
            }
            else
            {
                m_RadarMode.SelectedIndex = 0;
            }
            return 0;
        }

        public int selectRadarMode(int mode)
        {
            string full_command = string.Format("ar1.selectRadarMode({0})", mode);
            m_GuiManager.RecordLog(0, full_command);
            if (mode == 0)
            {
                m_chbRFDataCaptureCard.Enabled = true;
                m_chbTSW1400Ena.Enabled = true;
                m_chbRFDataCaptureCard.Checked = true;
                m_chbTDABoard.Enabled = false;
                RadarDeviceSelection(1U);
                GlobalRef.g_2ChipCascade = false;
                GlobalRef.g_4ChipCascade = false;
                Imports.RadarLinkImpl_setSystemType(1);
                if (GlobalRef.g_StudioInit2)
                {
                    GlobalRef.g_StudioInit2 = false;
                }
                else
                {
                    m_ConnectTab.EnableDisableConnectComponentsForCascade(true);
                    m_ConnectTab.UpdateNumberOfRadarDevicesDetected();
                    m_ConnectTab.EnableDisbleRadarDeviceStatusWithRespectiveRadarDevices();
                    m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableFramingStatus(true);
                    m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableWidthHeightStatus(true);
                    m_GuiManager.MainTsForm.RegOpeTab.DisableAndEnableGPIOStatus(true);
                    m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableNumFilesCaptureStatus(true);
                }
            }
            else if (mode == 1)
            {
                m_chbRFDataCaptureCard.Enabled = false;
                m_chbTSW1400Ena.Enabled = false;
                m_chbTDABoard.Checked = true;
                m_chbTDABoard.Enabled = false;
                RadarDeviceSelection(4U);
                GlobalRef.g_2ChipCascade = false;
                GlobalRef.g_4ChipCascade = true;
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableFramingStatus(false);
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableWidthHeightStatus(false);
                m_GuiManager.MainTsForm.RegOpeTab.DisableAndEnableGPIOStatus(false);
                m_GuiManager.MainTsForm.ChirpConfigTab.DisableAndEnableNumFilesCaptureStatus(false);
                m_DeviceMode.SelectedIndex = 1;
                m_ConnectTab.EnableDisableConnectComponentsForCascade(false);
                m_ConnectTab.EnableDisbleRadarDeviceStatus(2);
                m_ConnectTab.SetDefSopModIdx();
            }
            full_command = string.Format("Status: Passed", new object[0]);
            m_GuiManager.RecordLog(0, full_command);
            return 0;
        }

        private void m_btnDisplayTDAStats_Click(object sender, EventArgs p1)
        {
            if (Imports.showCPUStats() == 0)
            {
                string msg = string.Format("Status: Passed for Logging TDA Stats", new object[0]);
                GlobalRef.LuaWrapper.PrintWarning(msg);
                return;
            }
            string msg2 = string.Format("Status: Failed for Logging TDA Stats!", new object[0]);
            GlobalRef.LuaWrapper.PrintError(msg2);
        }

        private void m_chbRFDataCaptureCard_CheckedChanged(object sender, EventArgs p1)
        {
            if (m_chbRFDataCaptureCard.Checked)
            {
                m_btnStupHsdcPro.Text = "SetUp DCA1000";
                m_GuiManager.MainTsForm.ChirpConfigTab.iEnableRFADCDataCaptureCardSetUp();
                m_GuiManager.MainTsForm.ConnectTab.iDisableCaptureCardResetSetUp();
                GlobalRef.g_RFDataCaptureMode = true;
                GlobalRef.f0002d0 = true;
                GlobalRef.g_TDADataCaptureMode = false;
                string full_command = string.Format("ar1.SelectCaptureDevice(\"DCA1000\")", new object[0]);
                m_GuiManager.RecordLog(0, full_command);
                string full_command2 = string.Format("Status: Passed", new object[0]);
                m_GuiManager.RecordLog(0, full_command2);
                return;
            }
            if (m_chbTDABoard.Checked)
            {
                m_btnStupHsdcPro.Text = "SetUp TDAxx Capture Card";
                m_GuiManager.MainTsForm.ChirpConfigTab.iEnableTDADataCaptureCardSetUp();
                m_GuiManager.MainTsForm.ConnectTab.iEnableCaptureCardResetSetUp();
                GlobalRef.g_RFDataCaptureMode = false;
                GlobalRef.g_TDADataCaptureMode = true;
                return;
            }
            m_btnStupHsdcPro.Text = "SetUp TSW1400";
            m_GuiManager.MainTsForm.ConnectTab.iEnableCaptureCardResetSetUp();
            m_chbTSW1400Ena.Checked = true;
            GlobalRef.g_RFDataCaptureMode = false;
            GlobalRef.f0002d0 = false;
            GlobalRef.g_TDADataCaptureMode = false;
        }

        private void m_chbTSW1400Ena_CheckedChanged(object sender, EventArgs p1)
        {
            if (m_chbTSW1400Ena.Checked)
            {
                m_btnStupHsdcPro.Text = "SetUp TSW1400";
                m_GuiManager.MainTsForm.ChirpConfigTab.iDisableRFADCDataCaptureCardSetUp();
                m_GuiManager.MainTsForm.ConnectTab.iEnableCaptureCardResetSetUp();
                GlobalRef.g_RFDataCaptureMode = false;
                GlobalRef.g_TDADataCaptureMode = false;
                string full_command = string.Format("ar1.SelectCaptureDevice(\"TSW1400\")", new object[0]);
                m_GuiManager.RecordLog(0, full_command);
                string full_command2 = string.Format("Status: Passed", new object[0]);
                m_GuiManager.RecordLog(0, full_command2);
            }
        }

        private void m_chbTDABoard_CheckedChanged_1(object sender, EventArgs p1)
        {
            if (m_chbTDABoard.Checked)
            {
                m_btnStupHsdcPro.Text = "SetUp TDAxx Capture Card";
                m_GuiManager.MainTsForm.ChirpConfigTab.iEnableTDADataCaptureCardSetUp();
                m_GuiManager.MainTsForm.ConnectTab.iEnableCaptureCardResetSetUp();
                GlobalRef.g_RFDataCaptureMode = false;
                GlobalRef.g_TDADataCaptureMode = true;
            }
        }

        public RFDataCaptureCard m_RFDataCaptureCard;
        public TDAxxCaptureCard m_TDAxxCaptureCard;
        public ConnectTab m_ConnectTab;
        private StaticConfigTab m_StaticConfigTab;
        private DataConfigTab m_DataConfigTab;
        private ChirpConfigTab m_ChirpConfigTab;
        private TestSourceTab m_TestSourceTab;
        private ProtocolTab m_ProtocolTab;
        private ContStreamingTab m_ContStreamingTab;
        public RegOpeTab m_RegOpeTab;
        public BpmConfigTab m_BpmConfigTab;
        public RFStatusTab m_RFStatusTab;
        public PMICTab m_PMICTab;
        public ClibTab m_ClibTab;
        public AdvanceFrameConfigTab m_AdvanceFrameConfigTab;
        public RadarDeviceModeConfigParams m_RadarDeviceModeConfigParams;
        public RampTimingCfgTab m_RampTimingCfgTab;
        public LoopBack m_LoopBack;
        public ExternalFilterProgramming m_ExternalFilterProgramming;
        public CalibConfig m_CalibConfig;
        public MonitoringConfig m_MonitoringConfig;
        public AnalogMonConfig m_AnalogMonConfig;
        public AnalogMon2Config m_AnalogMon2Config;
        public TxRxGainTempLUTCfg m_TxRxGainTempLUTCfg;
        public WinSCPTransfer m_winSCPTransfer;
        public c0000b1 f0001a7;
        public MSSMonitoring m_MSSMonitoring;
        public DynamicChirpConfig m_DynamicChirpConfig;
        public ClockOutConfig m_ClockOutConfig;
        public CalibDataReStore m_CalibDataReStore;
        public InterChirpBlockControls m_InterChirpBlockControls;
        public Import_Export m_Import_Export;
        private GuiManager m_GuiManager;
        private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;
        private NameValueList m_RegTypeList;
        private NameValueList m_PowerModeList;
        private BoardStatus m_BoardStatus;
        private ChannelTable m_ChannelTable;
        private bool m_ClosingForm;
        private bool m_MainDisabled;
        private bool m_bLoadingForm;
        private bool m_bSettingsLoaded;
        private AntennaMode m_AntennaMode;
        private MainParams m_MainParams;
        private NameValueList m_AntModeList;
        private volatile bool g_tsw1400busy;
        private volatile bool g_frmStrtStop;
        private string m_SettingsOutputPath;
        private string m_SettingsTempReadOutputPath;
        public ChirpConfigParams m_ChirpConfigParams;
        public AdvChirpConfigParams m_AdvChirpConfigParams;
        public AdvancedFrameConfigParams m_AdvancedFrameConfigParams;
        private MatlabPostProcGUIClass MatlabPostProcGuiInstance;

        [CompilerGenerated]
        private sealed class c00026f
        {
            internal RegistryKey m000039(string keyName)
            {
                return key.OpenSubKey(keyName);
            }

            internal bool m00003a(string displayName)
            {
                return displayName != null && displayName.Contains(softwareName);
            }

            public RegistryKey key;

            public string softwareName;
        }

        [CompilerGenerated]
        [Serializable]
        private sealed class c000270
        {
            internal string m00003b(RegistryKey subkey)
            {
                return subkey.GetValue("DisplayName") as string;
            }

            public static readonly c000270 f00019e = new c000270();

            public static Func<RegistryKey, string> f0001ab;
        }

        [CompilerGenerated]
        private static class c000271
        {
            public static CallSite<Func<CallSite, object, string, object>> f0001ac;
            public static CallSite<Func<CallSite, object, string, object>> f0001ad;
            public static CallSite<Func<CallSite, object, string, string, object>> f0001ae;
            public static CallSite<Func<CallSite, object, string, object>> f0001af;
            public static CallSite<Func<CallSite, object, string, object>> f0001b0;
            public static CallSite<Func<CallSite, object, string, string, object>> f0001b1;
            public static CallSite<Func<CallSite, object, string, object>> f0001b2;
            public static CallSite<Func<CallSite, object, string, object>> f0001b3;
            public static CallSite<Func<CallSite, object, string, int, object>> f0001b4;
            public static CallSite<Func<CallSite, Type, object, Formatting, object>> f0001b5;
            public static CallSite<Func<CallSite, object, string>> f0001b6;
        }
    }
}
