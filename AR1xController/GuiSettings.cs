using System;
using System.IO;
using System.Windows.Forms;

namespace AR1xController
{
	public class GuiSettings
	{
		public string DefaultFileName
		{
			get
			{
				return m_DefaultFileName;
			}
			set
			{
				m_DefaultFileName = value;
			}
		}

		public Main Main
		{
			get
			{
				return m_Main;
			}
			set
			{
				m_Main = value;
			}
		}

		public Connection Connection
		{
			get
			{
				return m_Connection;
			}
			set
			{
				m_Connection = value;
			}
		}

		public Tx Tx
		{
			get
			{
				return m_Tx;
			}
			set
			{
				m_Tx = value;
			}
		}

		public Rx Rx
		{
			get
			{
				return m_Rx;
			}
			set
			{
				m_Rx = value;
			}
		}

		public Bip TestSignal
		{
			get
			{
				return m_Bip;
			}
			set
			{
				m_Bip = value;
			}
		}

		public Calibrations Calibrations
		{
			get
			{
				return m_Calibrations;
			}
			set
			{
				m_Calibrations = value;
			}
		}

		private GuiSettings()
		{
			m_DefaultFileName = Path.Combine(Application.StartupPath, "ar1gui.ini");
			m_IniHandler = new IniHandler(m_DefaultFileName);
			SetDefaults();
		}

		public static GuiSettings Default
		{
			get
			{
				return GuiSettings.defaultInstance;
			}
			set
			{
				GuiSettings.defaultInstance = value;
			}
		}

		public void SetDefaults()
		{
			m_Main.RxLowPower = "0";
			m_Main.RxBoost = "0";
			m_Main.CalibUponTune = "0";
			m_Connection.ComPort = "";
			m_Connection.BaudRate = "921600";
			m_Connection.Timeout = "1000";
			m_Connection.PhyFwFile = "";
			m_Connection.PhyFwFile1 = "";
			m_Connection.PhyFwFile2 = "";
			m_Connection.PhyFwFile3 = "";
			m_Connection.PhyFwFile4 = "";
			m_Connection.MacFwFile = "";
			m_Connection.MacFwFile1 = "";
			m_Connection.MacFwFile2 = "";
			m_Connection.MacFwFile3 = "";
			m_Connection.MacFwFile4 = "";
			m_Connection.IniFile = "";
			m_Connection.IniFile1 = "";
			m_Connection.IniFile2 = "";
			m_Connection.IniFile3 = "";
			m_Connection.IniFile4 = "";
			m_Connection.DllFile = "";
			m_Connection.DllFile1 = "";
			m_Connection.DllFile2 = "";
			m_Connection.DllFile3 = "";
			m_Connection.DllFile4 = "";
			m_Connection.PollConnection = "1";
			m_Connection.PhyStandAlone = "0";
			m_Connection.BoardType = "1";
			m_Connection.UpdateIni = "0";
			m_Connection.FrefClk = "26   MHz";
			m_Tx.TxMode = "2";
			m_Tx.Rate = "7";
			m_Tx.Preamble = "7";
			m_Tx.Bw = "20";
			m_Tx.PacketType = "";
			m_Tx.PacketSize = "100";
			m_Tx.PacketAmount = "1";
			m_Tx.PacketDelay = "20";
			m_Tx.Sgi = "0";
			m_Tx.Stbc = "0";
			m_Tx.DualStream = "0";
			m_Tx.ConstantData = "124";
			m_Tx.DutyCycle = "";
			m_Tx.Scramble = "0";
			m_Tx.IncMode = "1";
			m_Tx.Seed = "135";
			m_Tx.Dbm = "1";
			m_Tx.TargetPower = "30";
			m_Tx.SocLimits = "0";
			m_Tx.FemLimits = "0";
			m_Tx.ChannelLimits = "0";
			m_Tx.AnalogSettings = "0";
			m_Tx.EnableDpd = "0";
			m_Tx.TargetCurve = "";
			m_Tx.PostDpd = "-0.25";
			m_Tx.EnableClpc = "0";
			m_Tx.ClpcTime = "0";
			m_Rx.IssueAck = "0";
			m_Rx.PhyModeCompVal = "10";
			m_Rx.PhyModeCompInc = "0";
			m_Bip.Sweeps = "0";
			m_Calibrations.PollCalibStatus = "1";
			m_Calibrations.PollInterval = "3";
		}

		public void Save()
		{
			Save(m_DefaultFileName);
		}

		public void Save(string filename)
		{
			try
			{
				m_IniHandler.FilePath = filename;
				GlobalRef.GuiManager.Log(string.Format("ar1.SaveSettings('{0}')", filename));
				frmAR1Main mainTsForm = GlobalRef.GuiManager.MainTsForm;
				mainTsForm.SaveSettings();
				mainTsForm.ConnectTab.SaveSettings();
				if (File.Exists(filename))
				{
					File.Delete(filename);
				}
				iWriteSettings();
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.Error(ex.Message, ex.StackTrace);
			}
		}

		public void Load()
		{
			Load(m_DefaultFileName);
		}

		public void Load(string filename)
		{
			try
			{
				m_IniHandler.FilePath = filename;
				GlobalRef.GuiManager.Log(string.Format("ar1.LoadSettings('{0}')", filename));
				frmAR1Main mainTsForm = GlobalRef.GuiManager.MainTsForm;
				iLoadSettings();
				mainTsForm.LoadSettings();
				mainTsForm.ConnectTab.LoadSettings();
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.Error(ex.Message, ex.StackTrace);
			}
		}

		private void iWriteSettings()
		{
			iWriteGeneral();
			iWriteMain();
			iWriteConnection();
			iWriteTx();
			iWriteRx();
			iWriteTestSignal();
			iWriteCalibrations();
		}

		private void iWriteGeneral()
		{
			string section = "General";
			m_IniHandler.WriteValue(section, "GuiVersion", "2.1.1.0".ToString());
		}

		private void iWriteMain()
		{
			string section = "Main";
			m_IniHandler.WriteValue(section, "RxLowPower", m_Main.RxLowPower.ToString());
			m_IniHandler.WriteValue(section, "RxBoost", m_Main.RxBoost.ToString());
			m_IniHandler.WriteValue(section, "CalibUponTune", m_Main.CalibUponTune.ToString());
		}

		private void iWriteConnection()
		{
			string section = "Connection";
			m_IniHandler.WriteValue(section, "ComPort", m_Connection.ComPort.ToString());
			m_IniHandler.WriteValue(section, "BaudRate", m_Connection.BaudRate.ToString());
			m_IniHandler.WriteValue(section, "Timeout", m_Connection.Timeout.ToString());
			m_IniHandler.WriteValue(section, "PhyFwFile", m_Connection.PhyFwFile.ToString());
			m_IniHandler.WriteValue(section, "PhyFwFile1", m_Connection.PhyFwFile1.ToString());
			m_IniHandler.WriteValue(section, "PhyFwFile2", m_Connection.PhyFwFile2.ToString());
			m_IniHandler.WriteValue(section, "PhyFwFile3", m_Connection.PhyFwFile3.ToString());
			m_IniHandler.WriteValue(section, "PhyFwFile4", m_Connection.PhyFwFile4.ToString());
			m_IniHandler.WriteValue(section, "MacFwFile", m_Connection.MacFwFile.ToString());
			m_IniHandler.WriteValue(section, "MacFwFile1", m_Connection.MacFwFile1.ToString());
			m_IniHandler.WriteValue(section, "MacFwFile2", m_Connection.MacFwFile2.ToString());
			m_IniHandler.WriteValue(section, "MacFwFile3", m_Connection.MacFwFile3.ToString());
			m_IniHandler.WriteValue(section, "MacFwFile4", m_Connection.MacFwFile4.ToString());
			m_IniHandler.WriteValue(section, "IniFile", m_Connection.IniFile.ToString());
			m_IniHandler.WriteValue(section, "IniFile1", m_Connection.IniFile1.ToString());
			m_IniHandler.WriteValue(section, "IniFile2", m_Connection.IniFile2.ToString());
			m_IniHandler.WriteValue(section, "IniFile3", m_Connection.IniFile3.ToString());
			m_IniHandler.WriteValue(section, "IniFile4", m_Connection.IniFile4.ToString());
			m_IniHandler.WriteValue(section, "DllFile", m_Connection.DllFile.ToString());
			m_IniHandler.WriteValue(section, "DllFile1", m_Connection.DllFile1.ToString());
			m_IniHandler.WriteValue(section, "DllFile2", m_Connection.DllFile2.ToString());
			m_IniHandler.WriteValue(section, "DllFile3", m_Connection.DllFile3.ToString());
			m_IniHandler.WriteValue(section, "DllFile4", m_Connection.DllFile4.ToString());
			m_IniHandler.WriteValue(section, "PollConnection", m_Connection.PollConnection.ToString());
			m_IniHandler.WriteValue(section, "PhyStandAlone", m_Connection.PhyStandAlone.ToString());
			m_IniHandler.WriteValue(section, "BoardType", m_Connection.BoardType.ToString());
			m_IniHandler.WriteValue(section, "UpdateIni", m_Connection.UpdateIni.ToString());
			m_IniHandler.WriteValue(section, "FrefClk", m_Connection.FrefClk.ToString());
			if (GlobalRef.f0002cf == "")
			{
				m_IniHandler.WriteValue(section, "TDA2xx_IPAddress", "0.0.0.0");
				return;
			}
			m_IniHandler.WriteValue(section, "TDA2xx_IPAddress", GlobalRef.f0002cf.ToString());
		}

		private void iWriteTx()
		{
			string section = "Tx";
			m_IniHandler.WriteValue(section, "TxMode", m_Tx.TxMode.ToString());
			m_IniHandler.WriteValue(section, "Rate", m_Tx.Rate.ToString());
			m_IniHandler.WriteValue(section, "Preamble", m_Tx.Preamble.ToString());
			m_IniHandler.WriteValue(section, "Bw", m_Tx.Bw.ToString());
			m_IniHandler.WriteValue(section, "PacketSize", m_Tx.PacketSize.ToString());
			m_IniHandler.WriteValue(section, "PacketAmount", m_Tx.PacketAmount.ToString());
			m_IniHandler.WriteValue(section, "PacketDelay", m_Tx.PacketDelay.ToString());
			m_IniHandler.WriteValue(section, "Sgi", m_Tx.Sgi.ToString());
			m_IniHandler.WriteValue(section, "Stbc", m_Tx.Stbc.ToString());
			m_IniHandler.WriteValue(section, "DualStream", m_Tx.DualStream.ToString());
			m_IniHandler.WriteValue(section, "ConstantData", m_Tx.ConstantData.ToString());
			m_IniHandler.WriteValue(section, "DutyCycle", m_Tx.DutyCycle.ToString());
			m_IniHandler.WriteValue(section, "Scramble", m_Tx.Scramble.ToString());
			m_IniHandler.WriteValue(section, "Increment", m_Tx.IncMode.ToString());
			m_IniHandler.WriteValue(section, "Seed", m_Tx.Seed.ToString());
			m_IniHandler.WriteValue(section, "Dbm", m_Tx.Dbm.ToString());
			m_IniHandler.WriteValue(section, "TargetPower", m_Tx.TargetPower.ToString());
			m_IniHandler.WriteValue(section, "SocLimits", m_Tx.SocLimits.ToString());
			m_IniHandler.WriteValue(section, "FemLimits", m_Tx.FemLimits.ToString());
			m_IniHandler.WriteValue(section, "ChannelLimits", m_Tx.ChannelLimits.ToString());
			m_IniHandler.WriteValue(section, "AnalogSettings", m_Tx.AnalogSettings.ToString());
			m_IniHandler.WriteValue(section, "EnableDpd", m_Tx.EnableDpd.ToString());
			m_IniHandler.WriteValue(section, "TargetCurve", m_Tx.TargetCurve.ToString());
			m_IniHandler.WriteValue(section, "PostDpd", m_Tx.PostDpd.ToString());
			m_IniHandler.WriteValue(section, "EnableClpc", m_Tx.EnableClpc.ToString());
			m_IniHandler.WriteValue(section, "ClpcTime", m_Tx.ClpcTime.ToString());
		}

		private void iWriteRx()
		{
			string section = "Rx";
			m_IniHandler.WriteValue(section, "IssueAck", m_Rx.IssueAck.ToString());
			m_IniHandler.WriteValue(section, "PhyModeCompVal", m_Rx.PhyModeCompVal.ToString());
			m_IniHandler.WriteValue(section, "PhyModeCompInc", m_Rx.PhyModeCompInc.ToString());
		}

		private void iWriteTestSignal()
		{
			string section = "TestSignal";
			m_IniHandler.WriteValue(section, "Sweeps", m_Bip.Sweeps.ToString());
		}

		private void iWriteCalibrations()
		{
			string section = "Calibrations";
			m_IniHandler.WriteValue(section, "PollCalibStatus", m_Calibrations.PollCalibStatus.ToString());
			m_IniHandler.WriteValue(section, "PollInterval", m_Calibrations.PollInterval.ToString());
		}

		private void iLoadSettings()
		{
			iLoadMain();
			iLoadConnection();
			iLoadTx();
			iLoadRx();
			iLoadBip();
			iLoadCalibrations();
		}

		private void iLoadMain()
		{
			string section = "Main";
			m_Main.RxLowPower = m_IniHandler.ReadValue(section, "RxLowPower", "0");
			m_Main.RxBoost = m_IniHandler.ReadValue(section, "RxBoost", "0");
			m_Main.CalibUponTune = m_IniHandler.ReadValue(section, "CalibUponTune", "0");
		}

		private void iLoadConnection()
		{
			string section = "Connection";
			m_Connection.ComPort = m_IniHandler.ReadValue(section, "ComPort", "");
			m_Connection.BaudRate = m_IniHandler.ReadValue(section, "BaudRate", "921600");
			m_Connection.Timeout = m_IniHandler.ReadValue(section, "Timeout", "1000");
			m_Connection.PhyFwFile = m_IniHandler.ReadValue(section, "PhyFwFile", "");
			m_Connection.PhyFwFile1 = m_IniHandler.ReadValue(section, "PhyFwFile1", "");
			m_Connection.PhyFwFile2 = m_IniHandler.ReadValue(section, "PhyFwFile2", "");
			m_Connection.PhyFwFile3 = m_IniHandler.ReadValue(section, "PhyFwFile3", "");
			m_Connection.PhyFwFile4 = m_IniHandler.ReadValue(section, "PhyFwFile4", "");
			m_Connection.MacFwFile = m_IniHandler.ReadValue(section, "MacFwFile", "");
			m_Connection.MacFwFile1 = m_IniHandler.ReadValue(section, "MacFwFile1", "");
			m_Connection.MacFwFile2 = m_IniHandler.ReadValue(section, "MacFwFile2", "");
			m_Connection.MacFwFile3 = m_IniHandler.ReadValue(section, "MacFwFile3", "");
			m_Connection.MacFwFile4 = m_IniHandler.ReadValue(section, "MacFwFile4", "");
			m_Connection.IniFile = m_IniHandler.ReadValue(section, "IniFile", "");
			m_Connection.IniFile1 = m_IniHandler.ReadValue(section, "IniFile1", "");
			m_Connection.IniFile2 = m_IniHandler.ReadValue(section, "IniFile2", "");
			m_Connection.IniFile3 = m_IniHandler.ReadValue(section, "IniFile3", "");
			m_Connection.IniFile4 = m_IniHandler.ReadValue(section, "IniFile4", "");
			m_Connection.DllFile = m_IniHandler.ReadValue(section, "DllFile", "");
			m_Connection.DllFile1 = m_IniHandler.ReadValue(section, "DllFile1", "");
			m_Connection.DllFile2 = m_IniHandler.ReadValue(section, "DllFile2", "");
			m_Connection.DllFile3 = m_IniHandler.ReadValue(section, "DllFile3", "");
			m_Connection.DllFile4 = m_IniHandler.ReadValue(section, "DllFile4", "");
			m_Connection.PollConnection = m_IniHandler.ReadValue(section, "PollConnection", "1");
			m_Connection.PhyStandAlone = m_IniHandler.ReadValue(section, "PhyStandAlone", "0");
			m_Connection.BoardType = m_IniHandler.ReadValue(section, "BoardType", "1");
			m_Connection.UpdateIni = m_IniHandler.ReadValue(section, "UpdateIni", "0");
			m_Connection.FrefClk = m_IniHandler.ReadValue(section, "FrefClk", "26   MHz");
			GlobalRef.f0002cf = m_IniHandler.ReadValue(section, "TDA2xx_IPAddress", "");
		}

		private void iLoadTx()
		{
			string section = "Tx";
			m_Tx.TxMode = m_IniHandler.ReadValue(section, "TxMode", "2");
			m_Tx.Rate = m_IniHandler.ReadValue(section, "Rate", "7");
			m_Tx.Preamble = m_IniHandler.ReadValue(section, "Preamble", "7");
			m_Tx.Bw = m_IniHandler.ReadValue(section, "Bw", "20");
			m_Tx.PacketSize = m_IniHandler.ReadValue(section, "PacketSize", "100");
			m_Tx.PacketAmount = m_IniHandler.ReadValue(section, "PacketAmount", "1");
			m_Tx.PacketDelay = m_IniHandler.ReadValue(section, "PacketDelay", "20");
			m_Tx.Sgi = m_IniHandler.ReadValue(section, "Sgi", "0");
			m_Tx.Stbc = m_IniHandler.ReadValue(section, "Stbc", "0");
			m_Tx.DualStream = m_IniHandler.ReadValue(section, "DualStream", "0");
			m_Tx.ConstantData = m_IniHandler.ReadValue(section, "ConstantData", "124");
			m_Tx.DutyCycle = m_IniHandler.ReadValue(section, "DutyCycle", "");
			m_Tx.Scramble = m_IniHandler.ReadValue(section, "Scramble", "0");
			m_Tx.IncMode = m_IniHandler.ReadValue(section, "Increment", "1");
			m_Tx.Seed = m_IniHandler.ReadValue(section, "Seed", "135");
			m_Tx.Dbm = m_IniHandler.ReadValue(section, "Dbm", "1");
			m_Tx.TargetPower = m_IniHandler.ReadValue(section, "TargetPower", "30");
			m_Tx.SocLimits = m_IniHandler.ReadValue(section, "SocLimits", "0");
			m_Tx.FemLimits = m_IniHandler.ReadValue(section, "FemLimits", "0");
			m_Tx.ChannelLimits = m_IniHandler.ReadValue(section, "ChannelLimits", "0");
			m_Tx.AnalogSettings = m_IniHandler.ReadValue(section, "AnalogSettings", "0");
			m_Tx.EnableDpd = m_IniHandler.ReadValue(section, "EnableDpd", "0");
			m_Tx.TargetCurve = m_IniHandler.ReadValue(section, "TargetCurve", "");
			m_Tx.PostDpd = m_IniHandler.ReadValue(section, "PostDpd", "-0.25");
			m_Tx.EnableClpc = m_IniHandler.ReadValue(section, "EnableClpc", "0");
			m_Tx.ClpcTime = m_IniHandler.ReadValue(section, "ClpcTime", "0");
		}

		private void iLoadRx()
		{
			string section = "Rx";
			m_Rx.IssueAck = m_IniHandler.ReadValue(section, "IssueAck", "0");
			m_Rx.PhyModeCompVal = m_IniHandler.ReadValue(section, "PhyModeCompVal", "10");
			m_Rx.PhyModeCompInc = m_IniHandler.ReadValue(section, "PhyModeCompInc", "0");
		}

		private void iLoadBip()
		{
			string section = "Bip";
			m_Bip.Sweeps = m_IniHandler.ReadValue(section, "Sweeps", "0");
		}

		private void iLoadCalibrations()
		{
			string section = "Calibrations";
			m_Calibrations.PollCalibStatus = m_IniHandler.ReadValue(section, "PollCalibStatus", "1");
			m_Calibrations.PollInterval = m_IniHandler.ReadValue(section, "PollInterval", "3");
		}

		private string m_DefaultFileName;
		private Main m_Main;
		private Connection m_Connection;
		private Tx m_Tx;
		private Rx m_Rx;
		private Bip m_Bip;
		private IniHandler m_IniHandler;
		private Calibrations m_Calibrations;
		private static GuiSettings defaultInstance = new GuiSettings();
	}
}
