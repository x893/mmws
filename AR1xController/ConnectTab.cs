using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using AR1xController.Properties;

namespace AR1xController
{
	public class ConnectTab : UserControl
	{
		public Button ConnectButton
		{
			get
			{
				return m_btnConnect;
			}
		}

		public Button ConnectButtonRadarDevice2
		{
			get
			{
				return m_btnRadarDev2Connect;
			}
		}

		public Button ConnectButtonRadarDevice3
		{
			get
			{
				return m_btnRadarDev3Connect;
			}
		}

		public Button ConnectButtonRadarDevice4
		{
			get
			{
				return m_btnRadarDev4Connect;
			}
		}

		public Button SPIConnectButton
		{
			get
			{
				return m_btnSPIConct;
			}
		}

		public Label ConnectivityStatus
		{
			get
			{
				return m_lblConnectivityStatus;
			}
		}

		public Label RadarDevice2ConnectivityStatus
		{
			get
			{
				return m_lblConnectivityRadarDev2Status;
			}
		}

		public Label RadarDevice3ConnectivityStatus
		{
			get
			{
				return m_lblConnectivityRadarDev3Status;
			}
		}

		public Label RadarDevice4ConnectivityStatus
		{
			get
			{
				return m_lblConnectivityRadarDev4Status;
			}
		}

		public bool DownlaodFwAbort
		{
			get
			{
				return m_bDownlaodFwAbort;
			}
			set
			{
				m_bDownlaodFwAbort = value;
			}
		}

		public ConnectTab()
		{
			InitializeComponent();

			m_btnRefreshPorts.BackgroundImage = Properties.Resources.Refresh;
			m_btnRadarDev4RefreshPorts.BackgroundImage = Resources.Refresh;
			m_btnRadarDev3RefreshPorts.BackgroundImage = Resources.Refresh;
			m_btnRadarDev2RefreshPorts.BackgroundImage = Resources.Refresh;
			m_btnRefreshNoOfDevices.BackgroundImage = Resources.Refresh;

			m_chkAck.Visible = false;
			f000192.Visible = false;
			m_cboCRC.Visible = false;
			m_BSSCheck.Visible = false;
			m_MSSCheck.Visible = false;
			m_CfgFileCheck.Visible = false;
			m_cboSopMod.SelectedIndex = 0;
			m_cboCRC.SelectedIndex = 0;
			m_MainForm = m_GuiManager.MainTsForm;
			m_ConnectParams = m_GuiManager.TsParams.ConnectParams;
			m_SPIConnectParams = m_GuiManager.TsParams.SPIConnectParams;
			m_RadarDeviceModeConfigParams = m_GuiManager.TsParams.RadarDeviceModeConfigParams;
			m_bDownlaodFwAbort = false;
			m_btnFullRst.Visible = false;
			iInitControls();
			BindGuiOps();
			DisableControls();
			UpdateDllVersion();
			UpdateNumberOfRadarDevicesDetected();
			m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected = Convert.ToUInt16(m_lblNumOfRadarDevsDetected.Text);
		}

		public bool DeviceConnected()
		{
			return Convert.ToInt32(m_lblNumOfRadarDevsDetected.Text) != 0;
		}

		public int NoDeviceConnected()
		{
			int num = Convert.ToInt32(m_lblNumOfRadarDevsDetected.Text);
			if (num == 1)
			{
				return 1;
			}
			return num;
		}

		public bool UpdateSPIData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateSPIData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_SPIConnectParams.ackTimeout = (m_chkAck.Checked ? 1000 : 0);
				m_SPIConnectParams.crcType = 3;
				if (f000192.Checked)
				{
					m_SPIConnectParams.crcType = m_cboCRC.SelectedIndex;
				}
				m_SPIConnectParams.trasportType = '\0';
				m_SPIConnectParams.portNum = 0U;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateSPIDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateSPIDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_chkAck.Checked = (m_SPIConnectParams.ackTimeout == 1000);
				if (m_SPIConnectParams.crcType == 0)
				{
					f000192.Checked = (m_SPIConnectParams.crcType == 0);
					m_cboCRC.SelectedIndex = 0;
				}
				else
				{
					f000192.Checked = (m_SPIConnectParams.crcType != 3);
				}
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool ChangeControlsFrSop(int SOP_Val)
		{
			if (base.InvokeRequired)
			{
				del_b_i method = new del_b_i(ChangeControlsFrSop);
				return (bool)base.Invoke(method, new object[]
				{
					SOP_Val
				});
			}
			bool result;
			try
			{
				switch (SOP_Val)
				{
					case 2:
						m_btnFlash.Enabled = false;
						m_CfgFileCheck.Enabled = false;
						m_BSSCheck.Enabled = false;
						m_MSSCheck.Enabled = false;
						m_DSPCheck.Enabled = false;
						m_btnCfg_FileLoad.Enabled = false;
						m_btnMSS_FwLoad.Enabled = true;
						m_btnBSS_FwLoad.Enabled = true;
						m_btnDSP_FwLoad.Enabled = true;
						return true;
					case 4:
						m_btnFlash.Enabled = false;
						m_CfgFileCheck.Enabled = false;
						m_BSSCheck.Enabled = false;
						m_MSSCheck.Enabled = false;
						m_DSPCheck.Enabled = false;
						m_btnCfg_FileLoad.Enabled = false;
						m_btnMSS_FwLoad.Enabled = true;
						m_btnBSS_FwLoad.Enabled = true;
						m_btnDSP_FwLoad.Enabled = true;
						return true;
					case 5:
						m_btnFlash.Enabled = true;
						m_CfgFileCheck.Enabled = true;
						m_BSSCheck.Enabled = true;
						m_MSSCheck.Enabled = true;
						m_DSPCheck.Enabled = true;
						m_btnCfg_FileLoad.Enabled = false;
						m_btnMSS_FwLoad.Enabled = false;
						m_btnBSS_FwLoad.Enabled = false;
						m_btnDSP_FwLoad.Enabled = false;
						return true;
				}
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool FindTheNumberOfRadarDevicesViaSop(int NumberOfDevices)
		{
			if (base.InvokeRequired)
			{
				del_b_i method = new del_b_i(FindTheNumberOfRadarDevicesViaSop);
				return (bool)base.Invoke(method, new object[]
				{
					NumberOfDevices
				});
			}
			bool result;
			try
			{
				m_lblNumOfRadarDevsDetected.Text = Convert.ToString(NumberOfDevices);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateGuiFrRs232()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateGuiFrRs232);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_chkAck.Checked = false;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateGuiFrSopCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateGuiFrSopCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_cboSopMod.SelectedIndex = m_ConnectParams.SopMod;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private bool setDeviceType(string devType)
		{
			if (base.InvokeRequired)
			{
				del_b_s method = new del_b_s(setDeviceType);
				return (bool)base.Invoke(method, new object[]
				{
					devType
				});
			}
			bool result;
			try
			{
				if (devType == "awr1642")
				{
					f00019c.Checked = true;
				}
				else if (devType == "awr1243")
				{
					f00019a.Checked = true;
				}
				else if (devType == "iwr1443")
				{
					f00019b.Checked = true;
				}
				else if (devType == "awr1843")
				{
					m_RadioBtnxWR1843.Checked = true;
				}
				else if (devType == "iwr6843")
				{
					m_RadioBtnxWR6843.Checked = true;
				}
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		private bool setDeviceFreq(int operatingFreq)
		{
			if (base.InvokeRequired)
			{
				del_b_i method = new del_b_i(setDeviceFreq);
				return (bool)base.Invoke(method, new object[]
				{
					operatingFreq
				});
			}
			bool result;
			try
			{
				m_RadioBtn60GHzRadarDev.Checked = (operatingFreq == 60);
				m_RadioBtn77GHzRadarDev.Checked = (operatingFreq == 77);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		private bool setCOMport(string COMport)
		{
			if (base.InvokeRequired)
			{
				del_b_s method = new del_b_s(setCOMport);
				return (bool)base.Invoke(method, new object[]
				{
					COMport
				});
			}
			bool result;
			try
			{
				m_cboComPort.SelectedItem = COMport;
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		private bool setBaudRate(string baudRate)
		{
			if (base.InvokeRequired)
			{
				del_b_s method = new del_b_s(setBaudRate);
				return (bool)base.Invoke(method, new object[]
				{
					baudRate
				});
			}
			bool result;
			try
			{
				m_cboBaudRate.SelectedItem = baudRate;
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		private bool clearRadarSSFilePath()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(clearRadarSSFilePath);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_cboBSS_FwFile.Items.Clear();
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		private bool clearMasterSSFilePath()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(clearMasterSSFilePath);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_cboMSS_FwFile.Items.Clear();
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool UpdateConnectConfig(SetupObject dobject)
		{
			bool result;
			try
			{
				setDeviceType(dobject.mmWaveDevice);
				setDeviceFreq(dobject.operatingFreq);
				setCOMport(dobject.mmWaveDeviceConfig.p00001f);
				setBaudRate(dobject.mmWaveDeviceConfig.RS232BaudRate);
				clearRadarSSFilePath();
				iSetPathInCombo(dobject.mmWaveDeviceConfig.radarSSFirmware, m_cboBSS_FwFile);
				clearMasterSSFilePath();
				iSetPathInCombo(dobject.mmWaveDeviceConfig.masterSSFirmware, m_cboMSS_FwFile);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public void ConnectUpdate()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(ConnectUpdate);
				base.Invoke(method);
				return;
			}
			if (f00019c.Checked)
			{
				GlobalRef.dobject.mmWaveDevice = "awr1642";
			}
			else if (f00019a.Checked)
			{
				GlobalRef.dobject.mmWaveDevice = "awr1243";
			}
			else if (f00019b.Checked)
			{
				GlobalRef.dobject.mmWaveDevice = "iwr1443";
			}
			else if (m_RadioBtnxWR1843.Checked)
			{
				GlobalRef.dobject.mmWaveDevice = "awr1843";
			}
			else if (m_RadioBtnxWR6843.Checked)
			{
				GlobalRef.dobject.mmWaveDevice = "iwr6843";
			}
			if (m_RadioBtn60GHzRadarDev.Checked)
			{
				GlobalRef.dobject.operatingFreq = 60;
			}
			else if (m_RadioBtn77GHzRadarDev.Checked)
			{
				GlobalRef.dobject.operatingFreq = 77;
			}
			if (!GlobalRef.g_2ChipCascade && !GlobalRef.g_4ChipCascade)
			{
				GlobalRef.dobject.mmWaveDeviceConfig.p00001f = m_cboComPort.SelectedItem.ToString();
				GlobalRef.dobject.mmWaveDeviceConfig.RS232BaudRate = m_cboBaudRate.SelectedItem.ToString();
				GlobalRef.dobject.mmWaveDeviceConfig.masterSSFirmware = m_cboMSS_FwFile.Text;
			}
			GlobalRef.dobject.mmWaveDeviceConfig.radarSSFirmware = m_cboBSS_FwFile.Text;
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
				m_ConnectParams.BSS_FwPath = m_cboBSS_FwFile.Text;
				m_ConnectParams.MSS_FwPath = m_cboMSS_FwFile.Text;
				m_ConnectParams.DSP_FwPath = m_cboDSP_FwFile.Text;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					m_ConnectParams.ComPort = iGetIndexFromPortName();
					m_ConnectParams.BaudRate = m_GuiManager.GetValueFromCombo(m_cboBaudRate);
				}
				else
				{
					GlobalRef.g_RS232ComPort[(int)GlobalRef.g_RadarDeviceIndex] = iGetIndexFromPortName();
					GlobalRef.g_RS232BaudRate[(int)GlobalRef.g_RadarDeviceIndex] = m_GuiManager.GetValueFromCombo(m_cboBaudRate);
				}
				switch (m_cboSopMod.SelectedIndex)
				{
					case 0:
						m_ConnectParams.SopMod = 2;
						GlobalRef.g_SOPMode4Set = 0U;
						GlobalRef.g_SOPMode7Set = 0U;
						break;
					case 1:
						m_ConnectParams.SopMod = 4;
						GlobalRef.g_SOPMode4Set = 1U;
						GlobalRef.g_SOPMode7Set = 0U;
						break;
					case 2:
						m_ConnectParams.SopMod = 5;
						GlobalRef.g_SOPMode4Set = 0U;
						GlobalRef.g_SOPMode7Set = 0U;
						break;
					case 3:
						m_ConnectParams.SopMod = 6;
						break;
					default:
						m_ConnectParams.SopMod = 4;
						break;
				}
				if (m_ConnectParams.ComPort == -1)
				{
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateDataRadarDevice2()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateDataRadarDevice2);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_ConnectParams.BSS_FwPath = m_cboBSS_FwFile.Text;
				m_ConnectParams.MSS_FwPath = m_cboMSS_FwFile.Text;
				m_ConnectParams.DSP_FwPath = m_cboDSP_FwFile.Text;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					m_ConnectParams.BaudRate = m_GuiManager.GetValueFromCombo(m_cboRadarDevice2BaudRate);
					m_ConnectParams.ComPort = iGetIndexFromPortNameForRadarDevice2();
				}
				else
				{
					GlobalRef.g_RS232ComPort[(int)GlobalRef.g_RadarDeviceIndex] = iGetIndexFromPortNameForRadarDevice2();
					GlobalRef.g_RS232BaudRate[(int)GlobalRef.g_RadarDeviceIndex] = m_GuiManager.GetValueFromCombo(m_cboRadarDevice2BaudRate);
				}
				switch (m_cboSopMod.SelectedIndex)
				{
					case 0:
						m_ConnectParams.SopMod = 2;
						break;
					case 1:
						m_ConnectParams.SopMod = 4;
						break;
					case 2:
						m_ConnectParams.SopMod = 5;
						break;
					case 3:
						m_ConnectParams.SopMod = 6;
						break;
					default:
						m_ConnectParams.SopMod = 4;
						break;
				}
				if (m_ConnectParams.ComPort == -1)
				{
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateDataRadarDevice3()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateDataRadarDevice3);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_ConnectParams.BSS_FwPath = m_cboBSS_FwFile.Text;
				m_ConnectParams.MSS_FwPath = m_cboMSS_FwFile.Text;
				m_ConnectParams.DSP_FwPath = m_cboDSP_FwFile.Text;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					m_ConnectParams.BaudRate = m_GuiManager.GetValueFromCombo(m_cboRadarDevice3BaudRate);
					m_ConnectParams.ComPort = iGetIndexFromPortNameForRadarDevice3();
				}
				else
				{
					GlobalRef.g_RS232ComPort[(int)GlobalRef.g_RadarDeviceIndex] = iGetIndexFromPortNameForRadarDevice3();
					GlobalRef.g_RS232BaudRate[(int)GlobalRef.g_RadarDeviceIndex] = m_GuiManager.GetValueFromCombo(m_cboRadarDevice3BaudRate);
				}
				switch (m_cboSopMod.SelectedIndex)
				{
					case 0:
						m_ConnectParams.SopMod = 2;
						break;
					case 1:
						m_ConnectParams.SopMod = 4;
						break;
					case 2:
						m_ConnectParams.SopMod = 5;
						break;
					case 3:
						m_ConnectParams.SopMod = 6;
						break;
					default:
						m_ConnectParams.SopMod = 4;
						break;
				}
				if (m_ConnectParams.ComPort == -1)
				{
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateDataRadarDevice4()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateDataRadarDevice4);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_ConnectParams.BSS_FwPath = m_cboBSS_FwFile.Text;
				m_ConnectParams.MSS_FwPath = m_cboMSS_FwFile.Text;
				m_ConnectParams.DSP_FwPath = m_cboDSP_FwFile.Text;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					m_ConnectParams.BaudRate = m_GuiManager.GetValueFromCombo(m_cboRadarDevice4BaudRate);
					m_ConnectParams.ComPort = iGetIndexFromPortNameForRadarDevice4();
				}
				else
				{
					GlobalRef.g_RS232ComPort[(int)GlobalRef.g_RadarDeviceIndex] = iGetIndexFromPortNameForRadarDevice4();
					GlobalRef.g_RS232BaudRate[(int)GlobalRef.g_RadarDeviceIndex] = m_GuiManager.GetValueFromCombo(m_cboRadarDevice4BaudRate);
				}
				switch (m_cboSopMod.SelectedIndex)
				{
					case 0:
						m_ConnectParams.SopMod = 2;
						break;
					case 1:
						m_ConnectParams.SopMod = 4;
						break;
					case 2:
						m_ConnectParams.SopMod = 5;
						break;
					case 3:
						m_ConnectParams.SopMod = 6;
						break;
					default:
						m_ConnectParams.SopMod = 4;
						break;
				}
				if (m_ConnectParams.ComPort == -1)
				{
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRS232StatusDataOfRadarDevice2()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateDataRadarDevice2);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_btnRadarDev2Connect.Text = "Disconnected";
				f000199.Text = "Connected";
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool m000019()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(m000019);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_ConnectParams.BSS_FwPath = m_cboBSS_FwFile.Text;
				m_ConnectParams.MSS_FwPath = m_cboMSS_FwFile.Text;
				m_ConnectParams.DSP_FwPath = m_cboDSP_FwFile.Text;
				m_ConnectParams.ComPort = iGetIndexFromPortName();
				m_ConnectParams.BaudRate = m_GuiManager.GetValueFromCombo(m_cboBaudRate);
				switch (m_cboSopMod.SelectedIndex)
				{
					case 0:
						m_ConnectParams.SopMod = 2;
						break;
					case 1:
						m_ConnectParams.SopMod = 4;
						break;
					case 2:
						m_ConnectParams.SopMod = 5;
						break;
					case 3:
						m_ConnectParams.SopMod = 6;
						break;
					default:
						m_ConnectParams.SopMod = 4;
						break;
				}
				if (m_ConnectParams.ComPort == -1)
				{
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
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
				bool flag = true;
				iSetPathInCombo(m_ConnectParams.BSS_FwPath, m_cboBSS_FwFile);
				iSetPathInCombo(m_ConnectParams.MSS_FwPath, m_cboMSS_FwFile);
				iSetPathInCombo(m_ConnectParams.DSP_FwPath, m_cboDSP_FwFile);
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					m_cboComPort.SelectedItem = "COM" + m_ConnectParams.ComPort;
					flag &= m_GuiManager.SetValueInCombo(m_cboBaudRate, m_ConnectParams.BaudRate);
				}
				else
				{
					m_cboComPort.SelectedItem = "COM" + GlobalRef.g_RS232ComPort[(int)GlobalRef.g_RadarDeviceIndex];
					flag &= m_GuiManager.SetValueInCombo(m_cboBaudRate, GlobalRef.g_RS232BaudRate[(int)GlobalRef.g_RadarDeviceIndex]);
				}
				result = flag;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SetDefSopModIdx()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SetDefSopModIdx);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_cboSopMod.SelectedIndex = 1;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool ReSetRadarDevice2RS232Status()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(ReSetRadarDevice2RS232Status);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_btnRadarDev2Connect.Text = "Disconnected";
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool ReSetRadarDevice3RS232Status()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(ReSetRadarDevice3RS232Status);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_btnRadarDev3Connect.Text = "Disconnected";
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool ReSetRadarDevice4RS232Status()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(ReSetRadarDevice4RS232Status);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_btnRadarDev4Connect.Text = "Disconnected";
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
		}

		public void SaveSettings()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(SaveSettings);
				base.Invoke(method);
				return;
			}
			Connection connection = GuiSettings.Default.Connection;
			int num = iGetIndexFromPortName();
			if (num != -1)
			{
				connection.ComPort = num.ToString();
			}
			else
			{
				connection.ComPort = "";
			}
			connection.BaudRate = m_GuiManager.GetValueFromCombo(m_cboBaudRate).ToString();
			List<string> list = iGetPaths(m_cboBSS_FwFile);
			List<string> list2 = iGetPaths(m_cboMSS_FwFile);
			List<string> list3 = iGetPaths(m_cboDSP_FwFile);
			connection.PhyFwFile = ((list.Count > 0) ? list[0].ToString() : "");
			connection.PhyFwFile1 = ((list.Count > 1) ? list[1].ToString() : "");
			connection.PhyFwFile2 = ((list.Count > 2) ? list[2].ToString() : "");
			connection.PhyFwFile3 = ((list.Count > 3) ? list[3].ToString() : "");
			connection.PhyFwFile4 = ((list.Count > 4) ? list[4].ToString() : "");
			connection.MacFwFile = ((list2.Count > 0) ? list2[0].ToString() : "");
			connection.MacFwFile1 = ((list2.Count > 1) ? list2[1].ToString() : "");
			connection.MacFwFile2 = ((list2.Count > 2) ? list2[2].ToString() : "");
			connection.MacFwFile3 = ((list2.Count > 3) ? list2[3].ToString() : "");
			connection.MacFwFile4 = ((list2.Count > 4) ? list2[4].ToString() : "");
			connection.DSPFwFile = ((list3.Count > 0) ? list3[0].ToString() : "");
			connection.DSPFwFile1 = ((list3.Count > 1) ? list3[1].ToString() : "");
			connection.DSPFwFile2 = ((list3.Count > 2) ? list3[2].ToString() : "");
			connection.DSPFwFile3 = ((list3.Count > 3) ? list3[3].ToString() : "");
			connection.DSPFwFile4 = ((list3.Count > 4) ? list3[4].ToString() : "");
			connection.PollConnection = (m_chkPollConnection.Checked ? "1" : "0");
			GuiSettings.Default.Connection = connection;
		}

		private List<string> iGetPaths(ComboBox combo)
		{
			List<string> list = new List<string>();
			foreach (object obj in combo.Items)
			{
				string text = (string)obj;
				if (text != combo.Text)
				{
					list.Add(text);
				}
			}
			if (!string.IsNullOrEmpty(combo.Text))
			{
				list.Insert(0, combo.Text);
			}
			return list;
		}

		public void LoadSettings()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(LoadSettings);
				base.Invoke(method);
				return;
			}
			Connection connection = GuiSettings.Default.Connection;
			if (connection.ComPort != "" && m_cboComPort.Items.Count > 0)
			{
				if (m_cboComPort.Items.Contains("COM" + connection.ComPort))
				{
					m_cboComPort.SelectedItem = "COM" + connection.ComPort;
					m_cboRadarDevice2ComPort.SelectedItem = "COM" + connection.ComPort;
				}
				else
				{
					m_cboComPort.SelectedItem = m_cboComPort.Items[0];
					m_cboRadarDevice2ComPort.SelectedItem = m_cboComPort.Items[0];
				}
			}
			m_GuiManager.SetValueInCombo(m_cboBaudRate, int.Parse(connection.BaudRate));
			m_GuiManager.SetValueInCombo(m_cboRadarDevice2BaudRate, int.Parse(connection.BaudRate));
			m_cboBSS_FwFile.Items.Clear();
			iSetPathInCombo(connection.PhyFwFile4, m_cboBSS_FwFile);
			iSetPathInCombo(connection.PhyFwFile3, m_cboBSS_FwFile);
			iSetPathInCombo(connection.PhyFwFile2, m_cboBSS_FwFile);
			iSetPathInCombo(connection.PhyFwFile1, m_cboBSS_FwFile);
			iSetPathInCombo(connection.PhyFwFile, m_cboBSS_FwFile);
			m_cboMSS_FwFile.Items.Clear();
			iSetPathInCombo(connection.MacFwFile4, m_cboMSS_FwFile);
			iSetPathInCombo(connection.MacFwFile3, m_cboMSS_FwFile);
			iSetPathInCombo(connection.MacFwFile2, m_cboMSS_FwFile);
			iSetPathInCombo(connection.MacFwFile1, m_cboMSS_FwFile);
			iSetPathInCombo(connection.MacFwFile, m_cboMSS_FwFile);
			m_cboDSP_FwFile.Items.Clear();
			iSetPathInCombo(connection.DSPFwFile4, m_cboDSP_FwFile);
			iSetPathInCombo(connection.DSPFwFile3, m_cboDSP_FwFile);
			iSetPathInCombo(connection.DSPFwFile2, m_cboDSP_FwFile);
			iSetPathInCombo(connection.DSPFwFile1, m_cboDSP_FwFile);
			iSetPathInCombo(connection.DSPFwFile, m_cboDSP_FwFile);
			m_chkPollConnection.Checked = (connection.PollConnection == "1");
			m_cboMSS_FwFile.Enabled = true;
		}

		public void PostLoadSettings()
		{
			SetDllInCombo(Imports.DllPath);
		}

		public void UpdateLuaKeys()
		{
			iUpdateLuaKey(TsLuaKey.ConnectComPort);
			iUpdateLuaKey(TsLuaKey.ConnectBaudRate);
			iUpdateLuaKey(TsLuaKey.ConnectFwFile);
			iUpdateLuaKey(TsLuaKey.ConnectIniFile);
			iUpdateLuaKey(TsLuaKey.ConnectPoll);
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
			string text = "";
			LuaType type = LuaType.Number;
			if (!m_GuiManager.MainTsForm.SettingsLoaded)
			{
				return;
			}
			try
			{
				switch (key)
				{
					case TsLuaKey.ConnectComPort:
						text = iGetIndexFromPortName().ToString();
						break;
					case TsLuaKey.ConnectBaudRate:
						text = m_GuiManager.GetValueFromCombo(m_cboBaudRate).ToString();
						break;
					case TsLuaKey.ConnectTimeout:
					case TsLuaKey.ConnectFrefClk:
						break;
					case TsLuaKey.ConnectFwFile:
						text = m_cboBSS_FwFile.Text;
						text = text.Replace("\\", "\\\\");
						type = LuaType.f0002bd;
						break;
					case TsLuaKey.ConnectIniFile:
						text = text.Replace("\\", "\\\\");
						type = LuaType.f0002bd;
						break;
					default:
						m_GuiManager.Error(string.Format("Internal error: key {0} is not a valid Connect Tab key.", key.ToString()));
						return;
					case TsLuaKey.ConnectPoll:
						text = (m_chkPollConnection.Checked ? "1" : "0");
						break;
				}
				m_GuiManager.p000002.SetTableVal(key, text.ToString(), type);
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
		}

		private void iSetTsApiMode(bool ts_api_mode)
		{
			m_GuiManager.TsApiMode = ts_api_mode;
			m_GuiManager.p000002.SetTsApiFlag(ts_api_mode);
		}

		public void iSetPhyStandAlone(bool phy_sa)
		{
			m_GuiManager.PhyStandAlone = phy_sa;
			m_GuiManager.p000002.SetPhyStandAlone(phy_sa);
			m_GuiManager.TsApiMode = !phy_sa;
			m_GuiManager.p000002.SetTsApiFlag(!phy_sa);
		}

		public void SetTsApiModeExt(bool enable)
		{
			if (base.InvokeRequired)
			{
				del_v_b method = new del_v_b(SetTsApiModeExt);
				base.Invoke(method, new object[]
				{
					enable
				});
				return;
			}
			iSetTsApiMode(enable);
		}

		public void SetPhyStandAloneExt(bool is_phy_sa)
		{
			if (base.InvokeRequired)
			{
				del_v_b method = new del_v_b(SetPhyStandAloneExt);
				base.Invoke(method, new object[]
				{
					is_phy_sa
				});
				return;
			}
			iSetPhyStandAlone(is_phy_sa);
		}

		public void DisableControls()
		{
		}

		private void iInitControls()
		{
			iFillComPortCombo();
			iInitBaudRateList();
			iInitFrefClkList();
			iFillRadarDev2ComPortCombo();
			iFillRadarDev3ComPortCombo();
			iFillRadarDev4ComPortCombo();
			ComboBox.ObjectCollection items = m_cboBaudRate.Items;
			object[] names = m_BaudRateList.Names;
			items.AddRange(names);
			m_cboBaudRate.Tag = m_BaudRateList;
			m_cboBaudRate.SelectedItem = m_BaudRateList.GetName(115200);
			ComboBox.ObjectCollection items2 = m_cboRadarDevice2BaudRate.Items;
			names = m_BaudRateList.Names;
			items2.AddRange(names);
			m_cboRadarDevice2BaudRate.Tag = m_BaudRateList;
			m_cboRadarDevice2BaudRate.SelectedItem = m_BaudRateList.GetName(115200);
			ComboBox.ObjectCollection items3 = m_cboRadarDevice3BaudRate.Items;
			names = m_BaudRateList.Names;
			items3.AddRange(names);
			m_cboRadarDevice3BaudRate.Tag = m_BaudRateList;
			m_cboRadarDevice3BaudRate.SelectedItem = m_BaudRateList.GetName(115200);
			ComboBox.ObjectCollection items4 = m_cboRadarDevice4BaudRate.Items;
			names = m_BaudRateList.Names;
			items4.AddRange(names);
			m_cboRadarDevice4BaudRate.Tag = m_BaudRateList;
			m_cboRadarDevice4BaudRate.SelectedItem = m_BaudRateList.GetName(115200);
			m_lblDllVersion.Text = "";
			m_lblMacFwVersion.Text = "";
			m_lblMSSPatchFwVersion.Text = "";
			m_lblPHYFwVersion.Text = "";
			m_lblBSSPatchFwVersion.Text = "";
			m_lblDevStatus.Text = "";
			m_lblDev2Status.Text = "";
			m_lblRadarDev2MacFwVersion.Text = "";
			m_lblRadarDev2PHYFwVersion.Text = "";
			m_lblDev3Status.Text = "";
			m_lblRadarDev3MacFwVersion.Text = "";
			m_lblRadarDev3PHYFwVersion.Text = "";
			m_lblDev4Status.Text = "";
			m_lblRadarDev4MacFwVersion.Text = "";
			m_lblRadarDev4PHYFwVersion.Text = "";
			m_lblDSPFwVersion.Text = "";
			m_lblDieIDInfo.Text = "";
			m_lblGuiVersion.Text = "2.1.1.0";
			if (!GlobalRef.CustomerVersion)
			{
				m_lblDllVersion.Text = "Dbg" + "2.1.1.0";
			}
			else
			{
				m_lblDllVersion.Text = "2.1.1.0";
			}
			UpdateRLVersion();
		}

		private void iInitBaudRateList()
		{
			m_BaudRateList = new NameValueList();
			m_BaudRateList.AddNameValue("115200", 115200);
			m_BaudRateList.AddNameValue("921600", 921600);
		}

		private void iInitFrefClkList()
		{
			m_FrefClkList = new NameValueList();
			m_FrefClkList.AddNameValue("19.2 MHz", 0);
			m_FrefClkList.AddNameValue("26   MHz", 1);
			m_FrefClkList.AddNameValue("38.4 MHz", 2);
			m_FrefClkList.AddNameValue("52   MHz", 3);
			m_FrefClkList.AddNameValue("38.4 MHz XTAL", 4);
			m_FrefClkList.AddNameValue("26   MHz XTAL", 5);
		}

		private void iFillComPortCombo()
		{
			string text = "";
			if (m_cboComPort.Items.Count > 0)
			{
				if (m_cboComPort.SelectedItem != null)
				{
					text = m_cboComPort.SelectedItem.ToString();
				}
				m_cboComPort.Items.Clear();
			}
			List<string> list = new List<string>();
			list.AddRange(SerialPort.GetPortNames());
			list.Sort(new Comparison<string>(iComparePortsByLength));
			ComboBox.ObjectCollection items = m_cboComPort.Items;
			object[] items2 = list.ToArray();
			items.AddRange(items2);
			if (m_cboComPort.Items.Count > 0)
			{
				if (text != "" && m_cboComPort.Items.Contains(text))
				{
					m_cboComPort.SelectedItem = text;
					return;
				}
				m_cboComPort.SelectedItem = m_cboComPort.Items[0];
			}
		}

		private void iFillRadarDev2ComPortCombo()
		{
			string text = "";
			if (m_cboRadarDevice2ComPort.Items.Count > 0)
			{
				if (m_cboRadarDevice2ComPort.SelectedItem != null)
				{
					text = m_cboRadarDevice2ComPort.SelectedItem.ToString();
				}
				m_cboRadarDevice2ComPort.Items.Clear();
			}
			List<string> list = new List<string>();
			list.AddRange(SerialPort.GetPortNames());
			list.Sort(new Comparison<string>(iComparePortsByLength));
			ComboBox.ObjectCollection items = m_cboRadarDevice2ComPort.Items;
			object[] items2 = list.ToArray();
			items.AddRange(items2);
			if (m_cboRadarDevice2ComPort.Items.Count > 0)
			{
				if (text != "" && m_cboRadarDevice2ComPort.Items.Contains(text))
				{
					m_cboRadarDevice2ComPort.SelectedItem = text;
					return;
				}
				m_cboRadarDevice2ComPort.SelectedItem = m_cboComPort.Items[0];
			}
		}

		private void iFillRadarDev3ComPortCombo()
		{
			string text = "";
			if (m_cboRadarDevice3ComPort.Items.Count > 0)
			{
				if (m_cboRadarDevice3ComPort.SelectedItem != null)
				{
					text = m_cboRadarDevice3ComPort.SelectedItem.ToString();
				}
				m_cboRadarDevice3ComPort.Items.Clear();
			}
			List<string> list = new List<string>();
			list.AddRange(SerialPort.GetPortNames());
			list.Sort(new Comparison<string>(iComparePortsByLength));
			ComboBox.ObjectCollection items = m_cboRadarDevice3ComPort.Items;
			object[] items2 = list.ToArray();
			items.AddRange(items2);
			if (m_cboRadarDevice3ComPort.Items.Count > 0)
			{
				if (text != "" && m_cboRadarDevice3ComPort.Items.Contains(text))
				{
					m_cboRadarDevice3ComPort.SelectedItem = text;
					return;
				}
				m_cboRadarDevice3ComPort.SelectedItem = m_cboComPort.Items[0];
			}
		}

		private void iFillRadarDev4ComPortCombo()
		{
			string text = "";
			if (m_cboRadarDevice4ComPort.Items.Count > 0)
			{
				if (m_cboRadarDevice4ComPort.SelectedItem != null)
				{
					text = m_cboRadarDevice4ComPort.SelectedItem.ToString();
				}
				m_cboRadarDevice4ComPort.Items.Clear();
			}
			List<string> list = new List<string>();
			list.AddRange(SerialPort.GetPortNames());
			list.Sort(new Comparison<string>(iComparePortsByLength));
			ComboBox.ObjectCollection items = m_cboRadarDevice4ComPort.Items;
			object[] items2 = list.ToArray();
			items.AddRange(items2);
			if (m_cboRadarDevice4ComPort.Items.Count > 0)
			{
				if (text != "" && m_cboRadarDevice4ComPort.Items.Contains(text))
				{
					m_cboRadarDevice4ComPort.SelectedItem = text;
					return;
				}
				m_cboRadarDevice4ComPort.SelectedItem = m_cboComPort.Items[0];
			}
		}

		public void UpdateDllVersion()
		{
			string text;
			m_AR1Wrapper.Calling_GetDllVersion(Imports.DllPath, out text);
			m_GuiManager.p000003 = text;
			iSetDllVersionInGui(text);
		}

		public void UpdateNumberOfRadarDevicesDetected()
		{
			uint num;
			if (GlobalRef.g_4ChipCascade)
			{
				num = 4U;
				EnableDisbleRadarDeviceStatus(2);
				FindTheNumberOfRadarDevicesViaSop((int)num);
			}
			else if (GlobalRef.g_2ChipCascade)
			{
				num = 2U;
				EnableDisbleRadarDeviceStatus(1);
				FindTheNumberOfRadarDevicesViaSop((int)num);
			}
			else
			{
				byte[] array = new byte[4];
				Imports.rlsGetNumofDevices(GCHandle.Alloc(array, GCHandleType.Pinned).AddrOfPinnedObject());
				num = (uint)((int)array[3] << 24 | (int)array[2] << 16 | (int)array[1] << 8 | (int)array[0]);
				EnableDisbleRadarDeviceStatus(3);
				if (num > 1U)
				{
					MessageBox.Show(" More than one device detected!\n Please connect only single device", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				FindTheNumberOfRadarDevicesViaSop((int)num);
				num = 1U;
			}
			m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected = (ushort)num;
			GlobalRef.g_NumOfRadarDevicesDetected = (uint)m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected;
			EnableDisbleRS232OperationsWithRespectiveRadarDevices();
			EnableDisbleRadarDeviceStatusWithRespectiveRadarDevices();
			if (m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected == 1)
			{
				m_btnSPIConct.Visible = true;
				m_btnAddDevice2SPIConct.Visible = false;
				m_btnAddDevice3SPIConct.Visible = false;
				m_btnAddDevice4SPIConct.Visible = false;
			}
			else if (m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected == 2)
			{
				m_btnSPIConct.Visible = true;
				m_btnAddDevice2SPIConct.Visible = true;
				m_btnAddDevice3SPIConct.Visible = false;
				m_btnAddDevice4SPIConct.Visible = false;
			}
			else if (m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected == 4)
			{
				m_btnSPIConct.Visible = true;
				m_btnAddDevice2SPIConct.Visible = true;
				m_btnAddDevice3SPIConct.Visible = true;
				m_btnAddDevice4SPIConct.Visible = true;
			}
			else
			{
				m_btnAddDevice2SPIConct.Visible = false;
				m_btnAddDevice3SPIConct.Visible = false;
				m_btnAddDevice4SPIConct.Visible = false;
			}
			EnableAndDisableRFPowerUpBasedOnRadarDevicesDetected();
		}

		public void BootUpRadarDeviceData()
		{
			m_GuiManager.ScriptOps.EnableAndDisableBSSCharData(m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected);
		}

		public int ConfigureTemperatureSensorData()
		{
			int result = 0;
			m_GuiManager.ScriptOps.TemperatureSensorConfigure();
			return result;
		}

		public void EnableAndDisableRFPowerUpBasedOnRadarDevicesDetected()
		{
			if (m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected == 1)
			{
				m_btnEnblRf.Visible = true;
				m_btnEnblRfDevice2.Visible = false;
				m_btnEnblRfDevice3.Visible = false;
				m_btnEnblRfDevice4.Visible = false;
				return;
			}
			if (m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected == 2)
			{
				m_btnEnblRf.Visible = true;
				m_btnEnblRfDevice2.Visible = true;
				m_btnEnblRfDevice3.Visible = false;
				m_btnEnblRfDevice4.Visible = false;
				return;
			}
			if (m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected == 4)
			{
				m_btnEnblRf.Visible = true;
				m_btnEnblRfDevice2.Visible = true;
				m_btnEnblRfDevice3.Visible = true;
				m_btnEnblRfDevice4.Visible = true;
				return;
			}
			m_btnEnblRfDevice2.Visible = false;
			m_btnEnblRfDevice3.Visible = false;
			m_btnEnblRfDevice4.Visible = false;
		}

		private void iSetDllVersionInGui(string dll_version)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(iSetDllVersionInGui);
				base.Invoke(method, new object[]
				{
					dll_version
				});
				return;
			}
			m_lblDllVersion.Text = dll_version;
		}

		private bool iDllSupportsIniBeforeConnect()
		{
			try
			{
				if (m_GuiManager.p000003.StartsWith("8.1.0"))
				{
					string[] array = m_GuiManager.p000003.Split(new char[]
					{
						'.'
					});
					if (array.Length > 3 && int.Parse(array[3]) < 84)
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
			return true;
		}

		public void UpdateFwVersion(BoardStatus board_status, bool ext)
		{
			string text;
			m_AR1Wrapper.Calling_GetFW_Version(out text);
		}

		public int BSSPatchSpecialSignatureIdentifier(uint patchSplSign1, uint patchSplSign2)
		{
			uint num = 0U;
			uint num2 = 0U;
			m_AR1Wrapper.Calling_ReadAddr_Single(patchSplSign1, out num);
			m_AR1Wrapper.Calling_ReadAddr_Single(patchSplSign2, out num2);
			if (num == 3503231207U && num2 == 3490754029U)
			{
				return 0;
			}
			return -1;
		}

		public int MSSPatchSpecialSignatureIdentifier(uint patchSplSign1, uint patchSplSign2)
		{
			uint num = 0U;
			uint num2 = 0U;
			m_AR1Wrapper.Calling_ReadAddr_Single(patchSplSign1, out num);
			m_AR1Wrapper.Calling_ReadAddr_Single(patchSplSign2, out num2);
			if (num == 3503231207U && num2 == 3490754029U)
			{
				return 0;
			}
			return -1;
		}

		public int SetBSSVersions()
		{
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				string bssFwVersion = GetBssFwVersion();
				m_AR1Wrapper.GetBSSFwVersion();
				SetBSSVersionsInGui(bssFwVersion);
				if (BSSPatchSpecialSignatureIdentifier(1074266112U, 1074266116U) == 0)
				{
					string bssPatchFwVersion = GetBssPatchFwVersion();
					m_AR1Wrapper.GetBSSPatchFwVersion();
					SetBSSPatchVersionsInGui(bssPatchFwVersion);
				}
				else
				{
					SetNotAvailBSSPatchVersionsInGui("NA");
				}
			}
			ConnectTab.m_BSSDwnld = false;
			GlobalRef.g_BSSFwDl = false;
			return 1;
		}

		public int SetDSPVersions()
		{
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				string dspFwVersion = GetDspFwVersion();
				m_AR1Wrapper.GetDSPFwVersion();
				SetDSPVersionsInGui(dspFwVersion);
			}
			return 1;
		}

		public int SetMSSVersions()
		{
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				string mssFwVersion = GetMssFwVersion();
				m_AR1Wrapper.GetMSSFwVersion();
				SetMssFwVersionInGui(mssFwVersion);
				if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
				{
					if (MSSPatchSpecialSignatureIdentifier(2097152U, 2097156U) == 0)
					{
						string mssPatchFwVersion = GetMssPatchFwVersion();
						m_AR1Wrapper.GetMSSPatchFwVersion();
						if (GlobalRef.g_AR2243Device)
						{
							SetNotAvailMSSPatchVersionsInGui("NA");
						}
						else
						{
							SetMssPatchFwVersionInGui(mssPatchFwVersion);
						}
					}
					else
					{
						SetNotAvailMSSPatchVersionsInGui("NA");
					}
				}
				else
				{
					SetNotAvailMSSPatchVersionsInGui("NA");
				}
			}
			ConnectTab.m_MSSDwnld = false;
			GlobalRef.g_MSSFwDl = false;
			return 1;
		}

		public void SetFdspVersionToGui(string fdsp_version)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetFdspVersionToGui);
				base.Invoke(method, new object[]
				{
					fdsp_version
				});
				return;
			}
			m_lblPHYFwVersion.Text = string.Format("{0} (FDSP: {1})", m_lblPHYFwVersion.Text, fdsp_version.Trim(new char[1]));
		}

		public void UpdateRLVersion()
		{
			string rldll_version;
			m_GuiManager.ScriptOps.getRadarLinkVersion(out rldll_version);
			iSetRLDllVersionInGui(rldll_version);
		}

		private void iSetRLDllVersionInGui(string RLdll_version)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(iSetRLDllVersionInGui);
				base.Invoke(method, new object[]
				{
					RLdll_version
				});
				return;
			}
			m_lblRadarLinkVersion.Text = GetExactBSSAndMSSFirmwareVersion(RLdll_version);
		}

		public void UpdateMatlabPostProcVersion()
		{
			string matlabPostProcVersion = m_GuiManager.ScriptOps.getMatlabPostProcVersion();
			iSetMatlabPostProcVersionInGui(matlabPostProcVersion);
		}

		public void GetMatlabPreconfigurePlots()
		{
		}

		private void iSetMatlabPostProcVersionInGui(string MatlabPostProcdll_version)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(iSetMatlabPostProcVersionInGui);
				base.Invoke(method, new object[]
				{
					MatlabPostProcdll_version
				});
				return;
			}
			m_lblMatlabPostProcVersion.Text = GetExactMatlabPostProcVersion(MatlabPostProcdll_version);
		}

		public string GetExactMatlabPostProcVersion(string FWVersion)
		{
			string empty = string.Empty;
			string[] array = FWVersion.Split(new char[]
			{
				'('
			})[0].Split(new char[]
			{
				'.'
			});
			return Convert.ToString(Convert.ToInt32(array[0])) + "." + Convert.ToString(Convert.ToInt32(array[1]));
		}

		public void SetSOPModeinGui()
		{
			int num = 0;
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(SetSOPModeinGui);
				base.Invoke(method);
				return;
			}
			uint num2;
			m_AR1Wrapper.Calling_ReadAddr_Single(4294959720U, out num2);
			uint num3;
			m_AR1Wrapper.Calling_ReadAddr_Single(4294959636U, out num3);
			uint num4;
			m_AR1Wrapper.Calling_ReadAddr_Single(4294959632U, out num4);
			uint num5;
			m_AR1Wrapper.Calling_ReadAddr_Single(4294959636U, out num5);
			num5 &= 1U;
			string str;
			if (num5 == 0U)
			{
				str = "QM";
			}
			else
			{
				str = "ASIL-B";
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_lblDieIDInfo.Text = GetDieId(GlobalRef.g_RadarDeviceId);
				m_lblDieIDInfo.ForeColor = Color.Green;
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_lblRadarDev2DieIDInfo.Text = GetDieId(GlobalRef.g_RadarDeviceId);
				m_lblRadarDev2DieIDInfo.ForeColor = Color.Green;
			}
			else if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				m_lblRadarDev3DieIDInfo.Text = GetDieId(GlobalRef.g_RadarDeviceId);
				m_lblRadarDev3DieIDInfo.ForeColor = Color.Green;
			}
			else if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				m_lblRadarDev4DieIDInfo.Text = GetDieId(GlobalRef.g_RadarDeviceId);
				m_lblRadarDev4DieIDInfo.ForeColor = Color.Green;
			}
			findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
			uint num6 = num3 & 66846720U;
			string str2;
			if (num6 >> 18 == 0U)
			{
				switch ((num4 & 2U) | (num4 & 1U))
				{
					case 0U:
						str2 = "XWR1243" + "/" + str;
						GlobalRef.g_AR12xxDevice = true;
						num = m_GuiManager.ScriptOps.SelectChipVersion("AR1243");
						f00019a.Checked = true;
						m_RadioBtn77GHzRadarDev.Checked = true;
						if (!GlobalRef.jsonExecution)
						{
							m_MainForm.Import_Export.iSetPathInSetupAndmmWave("12xx");
						}
						if (num == 0)
						{
							string full_command = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
							{
							"XWR1243"
							});
							m_GuiManager.RecordLog(13, full_command);
							string full_command2 = string.Format("Status: Passed", new object[0]);
							m_GuiManager.RecordLog(8, full_command2);
						}
						else
						{
							string full_command3 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
							{
							"XWR1243"
							});
							m_GuiManager.RecordLog(13, full_command3);
							string full_command4 = string.Format("Status: Failed", new object[0]);
							m_GuiManager.RecordLog(8, full_command4);
						}
						break;
					case 1U:
						str2 = "XWR1443" + "/" + str;
						GlobalRef.g_AR12xxDevice = true;
						GlobalRef.g_AR14xxDevice = true;
						m_GuiManager.ScriptOps.SelectChipVersion("AR1243");
						f00019b.Checked = true;
						m_RadioBtn77GHzRadarDev.Checked = true;
						if (!GlobalRef.jsonExecution)
						{
							m_MainForm.Import_Export.iSetPathInSetupAndmmWave("14xx");
						}
						if (num == 0)
						{
							string full_command5 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
							{
							"XWR1443"
							});
							m_GuiManager.RecordLog(13, full_command5);
							string full_command6 = string.Format("Status: Passed", new object[0]);
							m_GuiManager.RecordLog(8, full_command6);
						}
						else
						{
							string full_command7 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
							{
							"XWR1443"
							});
							m_GuiManager.RecordLog(13, full_command7);
							string full_command8 = string.Format("Status: Failed", new object[0]);
							m_GuiManager.RecordLog(8, full_command8);
						}
						break;
					case 2U:
						str2 = "XWR1642" + "/" + str;
						GlobalRef.g_AR16xxDevice = true;
						m_GuiManager.ScriptOps.SelectChipVersion("AR1642");
						f00019c.Checked = true;
						m_RadioBtn77GHzRadarDev.Checked = true;
						if (!GlobalRef.jsonExecution)
						{
							m_MainForm.Import_Export.iSetPathInSetupAndmmWave("16xx");
						}
						if (num == 0)
						{
							string full_command9 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
							{
							"XWR1642"
							});
							m_GuiManager.RecordLog(13, full_command9);
							string full_command10 = string.Format("Status: Passed", new object[0]);
							m_GuiManager.RecordLog(8, full_command10);
						}
						else
						{
							string full_command11 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
							{
							"XWR1642"
							});
							m_GuiManager.RecordLog(13, full_command11);
							string full_command12 = string.Format("Status: Failed", new object[0]);
							m_GuiManager.RecordLog(8, full_command12);
						}
						break;
					default:
						str2 = "UnDetDe" + "/" + str;
						break;
				}
			}
			else
			{
				uint num7 = num3 & 66846720U;
				num7 >>= 18;
				if (num7 <= 103U)
				{
					if (num7 <= 33U)
					{
						switch (num7)
						{
							case 1U:
							case 4U:
								goto IL_8D4;
							case 2U:
							case 3U:
								goto IL_B42;
							case 5U:
								goto IL_6AC;
							default:
								if (num7 - 32U > 1U)
								{
									goto IL_B42;
								}
								break;
						}
					}
					else
					{
						if (num7 == 64U)
						{
							goto IL_7C0;
						}
						if (num7 - 96U > 2U && num7 - 102U > 1U)
						{
							goto IL_B42;
						}
						goto IL_8D4;
					}
				}
				else if (num7 <= 160U)
				{
					if (num7 - 112U <= 1U)
					{
						goto IL_6AC;
					}
					if (num7 != 128U)
					{
						if (num7 != 160U)
						{
							goto IL_B42;
						}
						goto IL_7C0;
					}
				}
				else
				{
					if (num7 - 192U <= 1U)
					{
						goto IL_8D4;
					}
					if (num7 == 208U)
					{
						goto IL_6AC;
					}
					if (num7 - 224U > 4U)
					{
						goto IL_B42;
					}
					str2 = "IWR6843" + "/" + str;
					GlobalRef.g_AR16xxDevice = true;
					GlobalRef.g_AR6843Device = true;
					m_GuiManager.ScriptOps.SelectChipVersion("IWR6843");
					m_RadioBtnxWR6843.Checked = true;
					m_RadioBtn60GHzRadarDev.Checked = true;
					if (!GlobalRef.jsonExecution)
					{
						m_MainForm.Import_Export.iSetPathInSetupAndmmWave("68xx");
					}
					if (num == 0)
					{
						string full_command13 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
						{
							"IWR6843"
						});
						m_GuiManager.RecordLog(13, full_command13);
						string full_command14 = string.Format("Status: Passed", new object[0]);
						m_GuiManager.RecordLog(8, full_command14);
						goto IL_B55;
					}
					string full_command15 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
					{
						"IWR6843"
					});
					m_GuiManager.RecordLog(13, full_command15);
					string full_command16 = string.Format("Status: Failed", new object[0]);
					m_GuiManager.RecordLog(8, full_command16);
					goto IL_B55;
				}
				str2 = "XWR1243" + "/" + str;
				GlobalRef.g_AR12xxDevice = true;
				num = m_GuiManager.ScriptOps.SelectChipVersion("AR1243");
				f00019a.Checked = true;
				m_RadioBtn77GHzRadarDev.Checked = true;
				if (!GlobalRef.jsonExecution)
				{
					m_MainForm.Import_Export.iSetPathInSetupAndmmWave("12xx");
				}
				if (num == 0)
				{
					string full_command17 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
					{
						"XWR1243"
					});
					m_GuiManager.RecordLog(13, full_command17);
					string full_command18 = string.Format("Status: Passed", new object[0]);
					m_GuiManager.RecordLog(8, full_command18);
					goto IL_B55;
				}
				string full_command19 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
				{
					"XWR1243"
				});
				m_GuiManager.RecordLog(13, full_command19);
				string full_command20 = string.Format("Status: Failed", new object[0]);
				m_GuiManager.RecordLog(8, full_command20);
				goto IL_B55;
			IL_6AC:
				str2 = "XWR1843" + "/" + str;
				GlobalRef.g_AR16xxDevice = true;
				GlobalRef.g_AR1843Device = true;
				num = m_GuiManager.ScriptOps.SelectChipVersion("AR1642");
				m_RadioBtnxWR1843.Checked = true;
				m_RadioBtn77GHzRadarDev.Checked = true;
				if (!GlobalRef.jsonExecution)
				{
					m_MainForm.Import_Export.iSetPathInSetupAndmmWave("18xx");
				}
				if (num == 0)
				{
					string full_command21 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
					{
						"XWR1843"
					});
					m_GuiManager.RecordLog(13, full_command21);
					string full_command22 = string.Format("Status: Passed", new object[0]);
					m_GuiManager.RecordLog(8, full_command22);
					goto IL_B55;
				}
				string full_command23 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
				{
					"XWR1843"
				});
				m_GuiManager.RecordLog(13, full_command23);
				string full_command24 = string.Format("Status: Failed", new object[0]);
				m_GuiManager.RecordLog(8, full_command24);
				goto IL_B55;
			IL_7C0:
				str2 = "XWR1443" + "/" + str;
				GlobalRef.g_AR12xxDevice = true;
				GlobalRef.g_AR14xxDevice = true;
				num = m_GuiManager.ScriptOps.SelectChipVersion("AR1243");
				f00019b.Checked = true;
				m_RadioBtn77GHzRadarDev.Checked = true;
				if (!GlobalRef.jsonExecution)
				{
					m_MainForm.Import_Export.iSetPathInSetupAndmmWave("14xx");
				}
				if (num == 0)
				{
					string full_command25 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
					{
						"XWR1443"
					});
					m_GuiManager.RecordLog(13, full_command25);
					string full_command26 = string.Format("Status: Passed", new object[0]);
					m_GuiManager.RecordLog(8, full_command26);
					goto IL_B55;
				}
				string full_command27 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
				{
					"XWR1443"
				});
				m_GuiManager.RecordLog(13, full_command27);
				string full_command28 = string.Format("Status: Failed", new object[0]);
				m_GuiManager.RecordLog(8, full_command28);
				goto IL_B55;
			IL_8D4:
				str2 = "XWR1642" + "/" + str;
				GlobalRef.g_AR16xxDevice = true;
				num = m_GuiManager.ScriptOps.SelectChipVersion("AR1642");
				f00019c.Checked = true;
				m_RadioBtn77GHzRadarDev.Checked = true;
				if (!GlobalRef.jsonExecution)
				{
					m_MainForm.Import_Export.iSetPathInSetupAndmmWave("16xx");
				}
				if (num == 0)
				{
					string full_command29 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
					{
						"XWR1642"
					});
					m_GuiManager.RecordLog(13, full_command29);
					string full_command30 = string.Format("Status: Passed", new object[0]);
					m_GuiManager.RecordLog(8, full_command30);
					goto IL_B55;
				}
				string full_command31 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
				{
					"XWR1642"
				});
				m_GuiManager.RecordLog(13, full_command31);
				string full_command32 = string.Format("Status: Failed", new object[0]);
				m_GuiManager.RecordLog(8, full_command32);
				goto IL_B55;
			IL_B42:
				str2 = "UnDetDe" + "/" + str;
			}
		IL_B55:
			switch (num2)
			{
				case 1U:
					GlobalRef.g_SOPMode7Set = 0U;
					GlobalRef.g_SOPMode4Set = 1U;
					if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
					{
						string str3 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDevStatus.Text = str2 + "/SOP:4" + str3;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
					{
						string str4 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev2Status.Text = str2 + "/SOP:4" + str4;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
					{
						string str5 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev3Status.Text = str2 + "/SOP:4" + str5;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
					{
						string str6 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev4Status.Text = str2 + "/SOP:4" + str6;
						goto IL_1060;
					}
					goto IL_1060;
				case 3U:
					GlobalRef.g_SOPMode7Set = 0U;
					GlobalRef.g_SOPMode4Set = 0U;
					if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
					{
						string str7 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDevStatus.Text = str2 + "/SOP:2" + str7;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
					{
						string str8 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev2Status.Text = str2 + "/SOP:2" + str8;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
					{
						string str9 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev3Status.Text = str2 + "/SOP:2" + str9;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
					{
						string str10 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev4Status.Text = str2 + "/SOP:2" + str10;
						goto IL_1060;
					}
					goto IL_1060;
				case 5U:
					GlobalRef.g_SOPMode7Set = 0U;
					GlobalRef.g_SOPMode4Set = 0U;
					if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
					{
						string str11 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDevStatus.Text = str2 + "/SOP:5" + str11;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
					{
						string str12 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev2Status.Text = str2 + "/SOP:5" + str12;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
					{
						string str13 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev3Status.Text = str2 + "/SOP:5" + str13;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
					{
						string str14 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev4Status.Text = str2 + "/SOP:5" + str14;
						goto IL_1060;
					}
					goto IL_1060;
				case 6U:
					GlobalRef.g_SOPMode7Set = 0U;
					GlobalRef.g_SOPMode4Set = 0U;
					if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
					{
						string str15 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDevStatus.Text = str2 + "/SOP:6" + str15;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
					{
						string str16 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev2Status.Text = str2 + "/SOP:6" + str16;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
					{
						string str17 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev3Status.Text = str2 + "/SOP:6" + str17;
						goto IL_1060;
					}
					if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
					{
						string str18 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
						m_lblDev4Status.Text = str2 + "/SOP:6" + str18;
						goto IL_1060;
					}
					goto IL_1060;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				string str19 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
				m_lblDevStatus.Text = str2 + "/SOP:Inv" + str19;
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				string str20 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
				m_lblDev2Status.Text = str2 + "/SOP:Inv" + str20;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				string str21 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
				m_lblDev3Status.Text = str2 + "/SOP:Inv" + str21;
			}
			else if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				string str22 = findRadarDeviceESVersion(GlobalRef.g_RadarDeviceId);
				m_lblDev4Status.Text = str2 + "/SOP:Inv" + str22;
			}
		IL_1060:
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				string msg = string.Format("Device Status : {0}", new object[]
				{
					m_lblDevStatus.Text
				});
				GlobalRef.LuaWrapper.PrintWarning(msg);
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				string msg2 = string.Format("Slave1 Device Status : {0}", new object[]
				{
					m_lblDev2Status.Text
				});
				GlobalRef.LuaWrapper.PrintWarning(msg2);
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				string msg3 = string.Format("Slave2 Device Status : {0}", new object[]
				{
					m_lblDev3Status.Text
				});
				GlobalRef.LuaWrapper.PrintWarning(msg3);
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				string msg4 = string.Format("Slave3 Device Status : {0}", new object[]
				{
					m_lblDev4Status.Text
				});
				GlobalRef.LuaWrapper.PrintWarning(msg4);
			}
		}

		public void m00001a()
		{
			int num = 0;
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(m00001a);
				base.Invoke(method);
				return;
			}
			int num2 = 0;
			int num3 = (int)GlobalRef.g_RadarDeviceId;
			do
			{
				if ((num3 & 1 << num2) != 0)
				{
					string value;
					m_MainForm.RegOpeTab.iReadRegisterDataViaSpi(1U << num2, 4294959720U, 0U, 31U, out value);
					string value2;
					m_MainForm.RegOpeTab.iReadRegisterDataViaSpi(1U << num2, 4294959636U, 0U, 31U, out value2);
					string value3;
					m_MainForm.RegOpeTab.iReadRegisterDataViaSpi(1U << num2, 4294959632U, 0U, 31U, out value3);
					string value4;
					m_MainForm.RegOpeTab.iReadRegisterDataViaSpi(1U << num2, 4294959636U, 0U, 31U, out value4);
					string str;
					if ((Convert.ToUInt32(value4, 16) & 1U) == 0U)
					{
						str = "QM";
					}
					else
					{
						str = "ASIL-B";
					}
					if ((1 << num2 & 1) == 1)
					{
						m_lblDieIDInfo.Text = GetDieId(1U << num2);
						m_lblDieIDInfo.ForeColor = Color.Green;
					}
					else if ((1 << num2 & 2) == 2)
					{
						m_lblRadarDev2DieIDInfo.Text = GetDieId(1U << num2);
						m_lblRadarDev2DieIDInfo.ForeColor = Color.Green;
					}
					else if ((1 << num2 & 4) == 4)
					{
						m_lblRadarDev3DieIDInfo.Text = GetDieId(1U << num2);
						m_lblRadarDev3DieIDInfo.ForeColor = Color.Green;
					}
					else if ((1 << num2 & 8) == 8)
					{
						m_lblRadarDev4DieIDInfo.Text = GetDieId(1U << num2);
						m_lblRadarDev4DieIDInfo.ForeColor = Color.Green;
					}
					findRadarDeviceESVersion(1U << num2);
					uint num4 = Convert.ToUInt32(value2, 16);
					uint num5 = num4 & 66846720U;
					num5 >>= 18;
					uint num6 = Convert.ToUInt32(value3, 16);
					string str2;
					if (num5 == 0U)
					{
						switch ((num6 & 2U) | (num6 & 1U))
						{
							case 0U:
								str2 = "XWR1243" + "/" + str;
								GlobalRef.g_AR12xxDevice = true;
								num = m_GuiManager.ScriptOps.SelectChipVersion("AR1243");
								f00019a.Checked = true;
								m_RadioBtn77GHzRadarDev.Checked = true;
								if (!GlobalRef.jsonExecution)
								{
									m_MainForm.Import_Export.iSetPathInSetupAndmmWave("12xx");
								}
								if (num == 0)
								{
									string full_command = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
									{
									"XWR1243"
									});
									m_GuiManager.RecordLog(13, full_command);
									string full_command2 = string.Format("Status: Passed", new object[0]);
									m_GuiManager.RecordLog(8, full_command2);
								}
								else
								{
									string full_command3 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
									{
									"XWR1243"
									});
									m_GuiManager.RecordLog(13, full_command3);
									string full_command4 = string.Format("Status: Failed", new object[0]);
									m_GuiManager.RecordLog(8, full_command4);
								}
								break;
							case 1U:
								str2 = "XWR1443" + "/" + str;
								GlobalRef.g_AR12xxDevice = true;
								GlobalRef.g_AR14xxDevice = true;
								m_GuiManager.ScriptOps.SelectChipVersion("AR1243");
								f00019b.Checked = true;
								m_RadioBtn77GHzRadarDev.Checked = true;
								if (!GlobalRef.jsonExecution)
								{
									m_MainForm.Import_Export.iSetPathInSetupAndmmWave("14xx");
								}
								if (num == 0)
								{
									string full_command5 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
									{
									"XWR1443"
									});
									m_GuiManager.RecordLog(13, full_command5);
									string full_command6 = string.Format("Status: Passed", new object[0]);
									m_GuiManager.RecordLog(8, full_command6);
								}
								else
								{
									string full_command7 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
									{
									"XWR1443"
									});
									m_GuiManager.RecordLog(13, full_command7);
									string full_command8 = string.Format("Status: Failed", new object[0]);
									m_GuiManager.RecordLog(8, full_command8);
								}
								break;
							case 2U:
								str2 = "XWR1642" + "/" + str;
								GlobalRef.g_AR16xxDevice = true;
								m_GuiManager.ScriptOps.SelectChipVersion("AR1642");
								f00019c.Checked = true;
								m_RadioBtn77GHzRadarDev.Checked = true;
								if (!GlobalRef.jsonExecution)
								{
									m_MainForm.Import_Export.iSetPathInSetupAndmmWave("16xx");
								}
								m_MainForm.RampTimingCfgTab.EnableProgFiltFor16XXARDevice();
								m_GuiManager.DllOps.ProfileProgramFileterSet();
								if (num == 0)
								{
									string full_command9 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
									{
									"XWR1642"
									});
									m_GuiManager.RecordLog(13, full_command9);
									string full_command10 = string.Format("Status: Passed", new object[0]);
									m_GuiManager.RecordLog(8, full_command10);
								}
								else
								{
									string full_command11 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
									{
									"XWR1642"
									});
									m_GuiManager.RecordLog(13, full_command11);
									string full_command12 = string.Format("Status: Failed", new object[0]);
									m_GuiManager.RecordLog(8, full_command12);
								}
								break;
							default:
								str2 = "UnDetDe" + "/" + str;
								break;
						}
					}
					else
					{
						uint num7 = num4 & 66846720U;
						num7 >>= 18;
						if (num7 <= 103U)
						{
							if (num7 <= 33U)
							{
								switch (num7)
								{
									case 1U:
									case 4U:
										goto IL_986;
									case 2U:
									case 3U:
										goto IL_C14;
									case 5U:
										goto IL_73E;
									default:
										if (num7 - 32U > 1U)
										{
											goto IL_C14;
										}
										break;
								}
							}
							else
							{
								if (num7 == 64U)
								{
									goto IL_872;
								}
								if (num7 - 96U > 2U && num7 - 102U > 1U)
								{
									goto IL_C14;
								}
								goto IL_986;
							}
						}
						else if (num7 <= 160U)
						{
							if (num7 - 112U <= 1U)
							{
								goto IL_73E;
							}
							if (num7 != 128U)
							{
								if (num7 != 160U)
								{
									goto IL_C14;
								}
								goto IL_872;
							}
						}
						else
						{
							if (num7 - 192U <= 1U)
							{
								goto IL_986;
							}
							if (num7 == 208U)
							{
								goto IL_73E;
							}
							if (num7 - 224U > 4U)
							{
								goto IL_C14;
							}
							str2 = "IWR6843" + "/" + str;
							GlobalRef.g_AR16xxDevice = true;
							GlobalRef.g_AR6843Device = true;
							m_GuiManager.ScriptOps.SelectChipVersion("IWR6843");
							m_RadioBtnxWR6843.Checked = true;
							m_RadioBtn60GHzRadarDev.Checked = true;
							if (!GlobalRef.jsonExecution)
							{
								m_MainForm.Import_Export.iSetPathInSetupAndmmWave("68xx");
							}
							if (num == 0)
							{
								string full_command13 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
								{
									"IWR6843"
								});
								m_GuiManager.RecordLog(13, full_command13);
								string full_command14 = string.Format("Status: Passed", new object[0]);
								m_GuiManager.RecordLog(8, full_command14);
								goto IL_C27;
							}
							string full_command15 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
							{
								"IWR6843"
							});
							m_GuiManager.RecordLog(13, full_command15);
							string full_command16 = string.Format("Status: Failed", new object[0]);
							m_GuiManager.RecordLog(8, full_command16);
							goto IL_C27;
						}
						str2 = "XWR1243" + "/" + str;
						GlobalRef.g_AR12xxDevice = true;
						num = m_GuiManager.ScriptOps.SelectChipVersion("AR1243");
						f00019a.Checked = true;
						m_RadioBtn77GHzRadarDev.Checked = true;
						if (!GlobalRef.jsonExecution)
						{
							m_MainForm.Import_Export.iSetPathInSetupAndmmWave("12xx");
						}
						if (num == 0)
						{
							string full_command17 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
							{
								"XWR1243"
							});
							m_GuiManager.RecordLog(13, full_command17);
							string full_command18 = string.Format("Status: Passed", new object[0]);
							m_GuiManager.RecordLog(8, full_command18);
							goto IL_C27;
						}
						string full_command19 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
						{
							"XWR1243"
						});
						m_GuiManager.RecordLog(13, full_command19);
						string full_command20 = string.Format("Status: Failed", new object[0]);
						m_GuiManager.RecordLog(8, full_command20);
						goto IL_C27;
					IL_73E:
						str2 = "XWR1843" + "/" + str;
						GlobalRef.g_AR16xxDevice = true;
						GlobalRef.g_AR1843Device = true;
						num = m_GuiManager.ScriptOps.SelectChipVersion("AR1642");
						m_RadioBtnxWR1843.Checked = true;
						m_RadioBtn77GHzRadarDev.Checked = true;
						m_MainForm.RampTimingCfgTab.EnableProgFiltFor16XXARDevice();
						m_GuiManager.DllOps.ProfileProgramFileterSet();
						if (!GlobalRef.jsonExecution)
						{
							m_MainForm.Import_Export.iSetPathInSetupAndmmWave("18xx");
						}
						if (num == 0)
						{
							string full_command21 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
							{
								"XWR1843"
							});
							m_GuiManager.RecordLog(13, full_command21);
							string full_command22 = string.Format("Status: Passed", new object[0]);
							m_GuiManager.RecordLog(8, full_command22);
							goto IL_C27;
						}
						string full_command23 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
						{
							"XWR1843"
						});
						m_GuiManager.RecordLog(13, full_command23);
						string full_command24 = string.Format("Status: Failed", new object[0]);
						m_GuiManager.RecordLog(8, full_command24);
						goto IL_C27;
					IL_872:
						str2 = "XWR1443" + "/" + str;
						GlobalRef.g_AR12xxDevice = true;
						GlobalRef.g_AR14xxDevice = true;
						num = m_GuiManager.ScriptOps.SelectChipVersion("AR1243");
						f00019b.Checked = true;
						m_RadioBtn77GHzRadarDev.Checked = true;
						if (!GlobalRef.jsonExecution)
						{
							m_MainForm.Import_Export.iSetPathInSetupAndmmWave("14xx");
						}
						if (num == 0)
						{
							string full_command25 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
							{
								"XWR1443"
							});
							m_GuiManager.RecordLog(13, full_command25);
							string full_command26 = string.Format("Status: Passed", new object[0]);
							m_GuiManager.RecordLog(8, full_command26);
							goto IL_C27;
						}
						string full_command27 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
						{
							"XWR1443"
						});
						m_GuiManager.RecordLog(13, full_command27);
						string full_command28 = string.Format("Status: Failed", new object[0]);
						m_GuiManager.RecordLog(8, full_command28);
						goto IL_C27;
					IL_986:
						str2 = "XWR1642" + "/" + str;
						GlobalRef.g_AR16xxDevice = true;
						num = m_GuiManager.ScriptOps.SelectChipVersion("AR1642");
						f00019c.Checked = true;
						m_RadioBtn77GHzRadarDev.Checked = true;
						m_MainForm.RampTimingCfgTab.EnableProgFiltFor16XXARDevice();
						m_GuiManager.DllOps.ProfileProgramFileterSet();
						if (!GlobalRef.jsonExecution)
						{
							m_MainForm.Import_Export.iSetPathInSetupAndmmWave("16xx");
						}
						if (num == 0)
						{
							string full_command29 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
							{
								"XWR1642"
							});
							m_GuiManager.RecordLog(13, full_command29);
							string full_command30 = string.Format("Status: Passed", new object[0]);
							m_GuiManager.RecordLog(8, full_command30);
							goto IL_C27;
						}
						string full_command31 = string.Format("ar1.SelectChipVersion(\"{0}\")", new object[]
						{
							"XWR1642"
						});
						m_GuiManager.RecordLog(13, full_command31);
						string full_command32 = string.Format("Status: Failed", new object[0]);
						m_GuiManager.RecordLog(8, full_command32);
						goto IL_C27;
					IL_C14:
						str2 = "UnDetDe" + "/" + str;
					}
				IL_C27:
					switch (Convert.ToUInt32(value, 16))
					{
						case 1U:
							GlobalRef.g_SOPMode7Set = 0U;
							GlobalRef.g_SOPMode4Set = 1U;
							if ((1 << num2 & 1) == 1)
							{
								string str3 = findRadarDeviceESVersion(1U << num2);
								m_lblDevStatus.Text = str2 + "/SOP:4" + str3;
							}
							else if ((1 << num2 & 2) == 2)
							{
								string str4 = findRadarDeviceESVersion(1U << num2);
								m_lblDev2Status.Text = str2 + "/SOP:4" + str4;
							}
							else if ((1 << num2 & 4) == 4)
							{
								string str5 = findRadarDeviceESVersion(1U << num2);
								m_lblDev3Status.Text = str2 + "/SOP:4" + str5;
							}
							else if ((1 << num2 & 8) == 8)
							{
								string str6 = findRadarDeviceESVersion(1U << num2);
								m_lblDev4Status.Text = str2 + "/SOP:4" + str6;
							}
							break;
						case 2U:
						case 4U:
							goto IL_1057;
						case 3U:
							GlobalRef.g_SOPMode7Set = 0U;
							GlobalRef.g_SOPMode4Set = 0U;
							if ((1 << num2 & 1) == 1)
							{
								string str7 = findRadarDeviceESVersion(1U << num2);
								m_lblDevStatus.Text = str2 + "/SOP:2" + str7;
							}
							else if ((1 << num2 & 2) == 2)
							{
								string str8 = findRadarDeviceESVersion(1U << num2);
								m_lblDev2Status.Text = str2 + "/SOP:2" + str8;
							}
							else if ((1 << num2 & 4) == 4)
							{
								string str9 = findRadarDeviceESVersion(1U << num2);
								m_lblDev3Status.Text = str2 + "/SOP:2" + str9;
							}
							else if ((1 << num2 & 8) == 8)
							{
								string str10 = findRadarDeviceESVersion(1U << num2);
								m_lblDev4Status.Text = str2 + "/SOP:2" + str10;
							}
							break;
						case 5U:
							GlobalRef.g_SOPMode7Set = 0U;
							GlobalRef.g_SOPMode4Set = 0U;
							if ((1 << num2 & 1) == 1)
							{
								string str11 = findRadarDeviceESVersion(1U << num2);
								m_lblDevStatus.Text = str2 + "/SOP:5" + str11;
							}
							else if ((1 << num2 & 2) == 2)
							{
								string str12 = findRadarDeviceESVersion(1U << num2);
								m_lblDev2Status.Text = str2 + "/SOP:5" + str12;
							}
							else if ((1 << num2 & 4) == 4)
							{
								string str13 = findRadarDeviceESVersion(1U << num2);
								m_lblDev3Status.Text = str2 + "/SOP:5" + str13;
							}
							else if ((1 << num2 & 8) == 8)
							{
								string str14 = findRadarDeviceESVersion(1U << num2);
								m_lblDev4Status.Text = str2 + "/SOP:5" + str14;
							}
							break;
						case 6U:
							GlobalRef.g_SOPMode7Set = 0U;
							GlobalRef.g_SOPMode4Set = 0U;
							if ((1 << num2 & 1) == 1)
							{
								string str15 = findRadarDeviceESVersion(1U << num2);
								m_lblDevStatus.Text = str2 + "/SOP:6" + str15;
							}
							else if ((1 << num2 & 2) == 2)
							{
								string str16 = findRadarDeviceESVersion(1U << num2);
								m_lblDev2Status.Text = str2 + "/SOP:6" + str16;
							}
							else if ((1 << num2 & 4) == 4)
							{
								string str17 = findRadarDeviceESVersion(1U << num2);
								m_lblDev3Status.Text = str2 + "/SOP:6" + str17;
							}
							else if ((1 << num2 & 8) == 8)
							{
								string str18 = findRadarDeviceESVersion(1U << num2);
								m_lblDev4Status.Text = str2 + "/SOP:6" + str18;
							}
							break;
						default:
							goto IL_1057;
					}
				IL_1142:
					if ((1 << num2 & 1) == 1)
					{
						string msg = string.Format("Device Status : {0}", new object[]
						{
							m_lblDevStatus.Text
						});
						GlobalRef.LuaWrapper.PrintWarning(msg);
					}
					else if ((1 << num2 & 2) == 2)
					{
						string msg2 = string.Format("Slave1 Device Status : {0}", new object[]
						{
							m_lblDev2Status.Text
						});
						GlobalRef.LuaWrapper.PrintWarning(msg2);
					}
					else if ((1 << num2 & 4) == 4)
					{
						string msg3 = string.Format("Slave2 Device Status : {0}", new object[]
						{
							m_lblDev3Status.Text
						});
						GlobalRef.LuaWrapper.PrintWarning(msg3);
					}
					else if ((1 << num2 & 8) == 8)
					{
						string msg4 = string.Format("Slave3 Device Status : {0}", new object[]
						{
							m_lblDev4Status.Text
						});
						GlobalRef.LuaWrapper.PrintWarning(msg4);
					}
					num3 &= ~(1 << num2);
					goto IL_124A;
				IL_1057:
					if ((1 << num2 & 1) == 1)
					{
						string str19 = findRadarDeviceESVersion(1U << num2);
						m_lblDevStatus.Text = str2 + "/SOP:Inv" + str19;
						goto IL_1142;
					}
					if ((1 << num2 & 2) == 2)
					{
						string str20 = findRadarDeviceESVersion(1U << num2);
						m_lblDev2Status.Text = str2 + "/SOP:Inv" + str20;
						goto IL_1142;
					}
					if ((1 << num2 & 4) == 4)
					{
						string str21 = findRadarDeviceESVersion(1U << num2);
						m_lblDev3Status.Text = str2 + "/SOP:Inv" + str21;
						goto IL_1142;
					}
					if ((1 << num2 & 8) == 8)
					{
						string str22 = findRadarDeviceESVersion(1U << num2);
						m_lblDev4Status.Text = str2 + "/SOP:Inv" + str22;
						goto IL_1142;
					}
					goto IL_1142;
				}
			IL_124A:
				num2++;
			}
			while (num3 != 0);
		}

		public string m00001b(uint CorePMOS, uint CoreNMOS)
		{
			string result = string.Empty;
			if (CorePMOS == 0U && CoreNMOS == 0U)
			{
				result = "NB";
			}
			else if ((CorePMOS == 2U && CoreNMOS == 2U) || (CorePMOS == 1U && CoreNMOS == 1U))
			{
				result = "WL";
			}
			else if ((CorePMOS == 5U && CoreNMOS == 5U) || (CorePMOS == 6U && CoreNMOS == 6U))
			{
				result = "SL";
			}
			return result;
		}

		public string findRadarDeviceESVersion(uint deviceMap)
		{
			string str = string.Empty;
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				uint num;
				m_AR1Wrapper.Calling_ReadAddr_Single(4294959640U, out num);
				uint num2;
				num = (num2 = (num & 15U));
				str = num2.ToString();
			}
			else
			{
				string value;
				m_MainForm.RegOpeTab.iReadRegisterDataViaSpi(deviceMap, 4294959640U, 0U, 31U, out value);
				str = (Convert.ToUInt32(value, 16) & 15U).ToString();
			}
			return "/" + "ES:" + str;
		}

		public string GetDieId(uint deviceMap)
		{
			string empty = string.Empty;
			uint num3;
			uint die_ID2;
			uint die_ID;
			uint num2;
			uint num = num2 = (die_ID = (die_ID2 = (num3 = 0U)));
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				m_AR1Wrapper.Calling_ReadAddr_Single(4294959616U, out num2);
				m_AR1Wrapper.Calling_ReadAddr_Single(4294959620U, out num);
				m_AR1Wrapper.Calling_ReadAddr_Single(4294959624U, out die_ID);
				m_AR1Wrapper.Calling_ReadAddr_Single(4294959628U, out die_ID2);
				m_AR1Wrapper.Calling_ReadAddr_Single(4294439096U, out num3);
			}
			else
			{
				string value;
				m_MainForm.RegOpeTab.iReadRegisterDataViaSpi(deviceMap, 4294959616U, 0U, 31U, out value);
				num2 = Convert.ToUInt32(value, 16);
				string value2;
				m_MainForm.RegOpeTab.iReadRegisterDataViaSpi(deviceMap, 4294959620U, 0U, 31U, out value2);
				num = Convert.ToUInt32(value2, 16);
				string value3;
				m_MainForm.RegOpeTab.iReadRegisterDataViaSpi(deviceMap, 4294959624U, 0U, 31U, out value3);
				die_ID = Convert.ToUInt32(value3, 16);
				string value4;
				m_MainForm.RegOpeTab.iReadRegisterDataViaSpi(deviceMap, 4294959628U, 0U, 31U, out value4);
				die_ID2 = Convert.ToUInt32(value4, 16);
			}
			uint value5 = ReverseBitFromData(die_ID) & 16777215U;
			uint value6 = ReverseBitFromData(die_ID2) >> 24 & 63U;
			uint value7 = ReverseBitFromData(die_ID2) & 4095U;
			uint value8 = ReverseBitFromData(die_ID2) >> 12 & 4095U;
			return string.Concat(new string[]
			{
				"Lot:",
				Convert.ToString(value5),
				"/Wafer:",
				Convert.ToString(value6),
				"/DevX:",
				Convert.ToString(value7),
				"/DevY:",
				Convert.ToString(value8)
			});
		}

		public uint ReverseBitFromData(uint Die_ID)
		{
			uint num = 0U;
			int num2 = 31;
			for (int i = 0; i < 32; i++)
			{
				if ((Die_ID >> i & 1U) == 1U)
				{
					num |= 1U << num2;
					num2--;
				}
				else
				{
					num |= 0U << num2;
					num2--;
				}
			}
			return num;
		}

		public static string ReverseString_Rec(string str)
		{
			if (str.Length <= 1)
			{
				return str;
			}
			return ConnectTab.ReverseString_Rec(str.Substring(1)) + str[0].ToString();
		}

		public void EnableDSPConfSpecifications()
		{
			f000194.Visible = true;
			m_cboDSP_FwFile.Visible = true;
			m_DSPCheck.Visible = true;
			m_btnDSP_FwLoad.Visible = true;
			f000193.Visible = true;
			m_lblDSPFwVersion.Visible = false;
			f000195.Visible = false;
			f000194.Enabled = true;
			m_cboDSP_FwFile.Enabled = true;
			m_DSPCheck.Enabled = true;
			m_btnDSP_FwLoad.Enabled = true;
			f000193.Enabled = true;
			m_lblDSPFwVersion.Enabled = false;
			f000195.Enabled = false;
		}

		public string GetBssPatchFwVersion()
		{
			uint value;
			m_AR1Wrapper.Calling_ReadAddr_Single(1074266136U, out value);
			uint value2;
			m_AR1Wrapper.Calling_ReadAddr_Single(1074266140U, out value2);
			byte[] bytes = BitConverter.GetBytes(value);
			byte[] bytes2 = BitConverter.GetBytes(value2);
			return string.Format("{0:d2}.{1:d2}.{2:d2}.{3:d2} ({4:d2}/{5:d2}/{6:d2})", new object[]
			{
				int.Parse(bytes[0].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[1].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[2].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[3].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[2].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[1].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[0].ToString("X"), NumberStyles.HexNumber)
			});
		}

		public string GetBssFwVersion()
		{
			uint value;
			m_AR1Wrapper.Calling_ReadAddr_Single(1073741896U, out value);
			uint value2;
			m_AR1Wrapper.Calling_ReadAddr_Single(1073741900U, out value2);
			byte[] bytes = BitConverter.GetBytes(value);
			byte[] bytes2 = BitConverter.GetBytes(value2);
			return string.Format("{0:d2}.{1:d2}.{2:d2}.{3:d2} ({4:d2}/{5:d2}/{6:d2})", new object[]
			{
				int.Parse(bytes[0].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[1].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[2].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[3].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[2].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[1].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[0].ToString("X"), NumberStyles.HexNumber)
			});
		}

		public string GetDspFwVersion()
		{
			uint value;
			m_AR1Wrapper.Calling_ReadAddr_Single(1073741896U, out value);
			uint value2;
			m_AR1Wrapper.Calling_ReadAddr_Single(1073741900U, out value2);
			byte[] bytes = BitConverter.GetBytes(value);
			byte[] bytes2 = BitConverter.GetBytes(value2);
			return string.Format("{0:d2}.{1:d2}.{2:d2}.{3:d2} ({4:d2}/{5:d2}/{6:d2})", new object[]
			{
				int.Parse(bytes[0].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[1].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[2].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[3].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[2].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[1].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[0].ToString("X"), NumberStyles.HexNumber)
			});
		}

		public string GetMssFwVersion()
		{
			uint value;
			m_AR1Wrapper.Calling_ReadAddr_Single(72U, out value);
			uint value2;
			m_AR1Wrapper.Calling_ReadAddr_Single(76U, out value2);
			byte[] bytes = BitConverter.GetBytes(value);
			byte[] bytes2 = BitConverter.GetBytes(value2);
			return string.Format("{0:d2}.{1:d2}.{2:d2}.{3:d2} ({4:d2}/{5:d2}/{6:d2})", new object[]
			{
				int.Parse(bytes[0].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[1].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[2].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[3].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[2].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[1].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[0].ToString("X"), NumberStyles.HexNumber)
			});
		}

		public string GetMssPatchFwVersion()
		{
			uint value;
			m_AR1Wrapper.Calling_ReadAddr_Single(2097176U, out value);
			uint value2;
			m_AR1Wrapper.Calling_ReadAddr_Single(2097180U, out value2);
			byte[] bytes = BitConverter.GetBytes(value);
			byte[] bytes2 = BitConverter.GetBytes(value2);
			return string.Format("{0:d2}.{1:d2}.{2:d2}.{3:d2} ({4:d2}/{5:d2}/{6:d2})", new object[]
			{
				int.Parse(bytes[0].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[1].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[2].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes[3].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[2].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[1].ToString("X"), NumberStyles.HexNumber),
				int.Parse(bytes2[0].ToString("X"), NumberStyles.HexNumber)
			});
		}

		private string iFillStr(uint start_address, int length)
		{
			string result = "";
			try
			{
				uint num = 0U;
				string text = "";
				for (int i = 0; i < length / 4; i++)
				{
					uint address = (uint)((ulong)start_address + (ulong)((long)(i * 4)));
					GlobalRef.TsWrapper.ReadRegister(2, address, 0, 31, out num);
					text = num.ToString("X").Replace("0x", "").PadLeft(8, '0') + text;
				}
				result = iConvertNum2Str(text);
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
			}
			return result;
		}

		private string iConvertNum2Str(string num)
		{
			string text = "";
			for (int i = num.Length - 1; i >= 0; i -= 2)
			{
				string value = num[i - 1].ToString() + num[i].ToString();
				text += ((char)Convert.ToUInt32(value, 16)).ToString();
			}
			return text;
		}

		public void SetMssFwVersionInGui(string fw_version)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetMssFwVersionInGui);
				base.Invoke(method, new object[]
				{
					fw_version
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				if (string.IsNullOrEmpty(m_lblMacFwVersion.Text))
				{
					m_lblMacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command = string.Format("ar1.GetMSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command);
					string full_command2 = string.Format("MSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command2);
					return;
				}
				if (m_lblMacFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblMacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command3 = string.Format("ar1.GetMSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command3);
					string full_command4 = string.Format("MSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command4);
					return;
				}
				m_lblMacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command5 = string.Format("ar1.GetMSSFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command5);
				string full_command6 = string.Format("MSSFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command6);
				m_GuiManager.Warning("Mismatched MSS firmware version!");
				return;
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				if (string.IsNullOrEmpty(m_lblRadarDev2MacFwVersion.Text))
				{
					m_lblRadarDev2MacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command7 = string.Format("ar1.GetMSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command7);
					string full_command8 = string.Format("MSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command8);
					return;
				}
				if (m_lblRadarDev2MacFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblRadarDev2MacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command9 = string.Format("ar1.GetMSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command9);
					string full_command10 = string.Format("MSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command10);
					return;
				}
				m_lblRadarDev2MacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command11 = string.Format("ar1.GetMSSFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command11);
				string full_command12 = string.Format("MSSFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command12);
				m_GuiManager.Warning("Mismatched MSS firmware version!");
				return;
			}
			else
			{
				if ((GlobalRef.g_RadarDeviceId & 4U) != 4U)
				{
					if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
					{
						if (string.IsNullOrEmpty(m_lblRadarDev4MacFwVersion.Text))
						{
							m_lblRadarDev4MacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
							string full_command13 = string.Format("ar1.GetMSSFwVersion()", new object[0]);
							m_GuiManager.RecordLog(13, full_command13);
							string full_command14 = string.Format("MSSFwVersion:({0})", new object[]
							{
								fw_version
							});
							m_GuiManager.RecordLog(13, full_command14);
							return;
						}
						if (m_lblRadarDev4MacFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
						{
							m_lblRadarDev4MacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
							string full_command15 = string.Format("ar1.GetMSSFwVersion()", new object[0]);
							m_GuiManager.RecordLog(13, full_command15);
							string full_command16 = string.Format("MSSFwVersion:({0})", new object[]
							{
								fw_version
							});
							m_GuiManager.RecordLog(13, full_command16);
							return;
						}
						m_lblRadarDev4MacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
						string full_command17 = string.Format("ar1.GetMSSFwVersion()", new object[0]);
						m_GuiManager.RecordLog(13, full_command17);
						string full_command18 = string.Format("MSSFwVersion:({0})", new object[]
						{
							fw_version
						});
						m_GuiManager.RecordLog(13, full_command18);
						m_GuiManager.Warning("Mismatched MSS firmware version!");
					}
					return;
				}
				if (string.IsNullOrEmpty(m_lblRadarDev3MacFwVersion.Text))
				{
					m_lblRadarDev3MacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command19 = string.Format("ar1.GetMSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command19);
					string full_command20 = string.Format("MSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command20);
					return;
				}
				if (m_lblRadarDev3MacFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblRadarDev3MacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command21 = string.Format("ar1.GetMSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command21);
					string full_command22 = string.Format("MSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command22);
					return;
				}
				m_lblRadarDev3MacFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command23 = string.Format("ar1.GetMSSFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command23);
				string full_command24 = string.Format("MSSFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command24);
				m_GuiManager.Warning("Mismatched MSS firmware version!");
				return;
			}
		}

		public void SetMssPatchFwVersionInGui(string fw_version)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetMssPatchFwVersionInGui);
				base.Invoke(method, new object[]
				{
					fw_version
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				if (string.IsNullOrEmpty(m_lblMSSPatchFwVersion.Text))
				{
					m_lblMSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command);
					string full_command2 = string.Format("MSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command2);
					return;
				}
				if (m_lblMSSPatchFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblMSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command3 = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command3);
					string full_command4 = string.Format("MSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command4);
					return;
				}
				m_lblMSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command5 = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command5);
				string full_command6 = string.Format("MSSPatchFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command6);
				m_GuiManager.Warning("Mismatched MSS Patch firmware version!");
				return;
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				if (string.IsNullOrEmpty(m_lblRadarDev2MSSPatchFwVersion.Text))
				{
					m_lblRadarDev2MSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command7 = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command7);
					string full_command8 = string.Format("MSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command8);
					return;
				}
				if (m_lblRadarDev2MSSPatchFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblRadarDev2MSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command9 = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command9);
					string full_command10 = string.Format("MSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command10);
					return;
				}
				m_lblRadarDev2MSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command11 = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command11);
				string full_command12 = string.Format("MSSPatchFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command12);
				m_GuiManager.Warning("Mismatched MSS firmware version!");
				return;
			}
			else
			{
				if ((GlobalRef.g_RadarDeviceId & 4U) != 4U)
				{
					if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
					{
						if (string.IsNullOrEmpty(m_lblRadarDev4MSSPatchFwVersion.Text))
						{
							m_lblRadarDev4MSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
							string full_command13 = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
							m_GuiManager.RecordLog(13, full_command13);
							string full_command14 = string.Format("MSSPatchFwVersion:({0})", new object[]
							{
								fw_version
							});
							m_GuiManager.RecordLog(13, full_command14);
							return;
						}
						if (m_lblRadarDev4MSSPatchFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
						{
							m_lblRadarDev4MSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
							string full_command15 = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
							m_GuiManager.RecordLog(13, full_command15);
							string full_command16 = string.Format("MSSPatchFwVersion:({0})", new object[]
							{
								fw_version
							});
							m_GuiManager.RecordLog(13, full_command16);
							return;
						}
						m_lblRadarDev4MSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
						string full_command17 = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
						m_GuiManager.RecordLog(13, full_command17);
						string full_command18 = string.Format("MSSPatchFwVersion:({0})", new object[]
						{
							fw_version
						});
						m_GuiManager.RecordLog(13, full_command18);
						m_GuiManager.Warning("Mismatched MSS firmware version!");
					}
					return;
				}
				if (string.IsNullOrEmpty(m_lblRadarDev3MSSPatchFwVersion.Text))
				{
					m_lblRadarDev3MSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command19 = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command19);
					string full_command20 = string.Format("MSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command20);
					return;
				}
				if (m_lblRadarDev3MSSPatchFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblRadarDev3MSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command21 = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command21);
					string full_command22 = string.Format("MSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command22);
					return;
				}
				m_lblRadarDev3MSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command23 = string.Format("ar1.GetMSSPatchFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command23);
				string full_command24 = string.Format("MSSPatchFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command24);
				m_GuiManager.Warning("Mismatched MSS firmware version!");
				return;
			}
		}

		public void SetBSSVersionsInGui(string fw_version)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetBSSVersionsInGui);
				base.Invoke(method, new object[]
				{
					fw_version
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				if (string.IsNullOrEmpty(m_lblPHYFwVersion.Text))
				{
					m_lblPHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command = string.Format("ar1.GetBSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command);
					string full_command2 = string.Format("BSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command2);
					return;
				}
				if (m_lblPHYFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblPHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command3 = string.Format("ar1.GetBSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command3);
					string full_command4 = string.Format("BSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command4);
					return;
				}
				m_lblPHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command5 = string.Format("ar1.GetBSSFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command5);
				string full_command6 = string.Format("BSSFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command6);
				m_GuiManager.Warning("BSS firmware version Mismatch!");
				return;
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				if (string.IsNullOrEmpty(m_lblRadarDev2PHYFwVersion.Text))
				{
					m_lblRadarDev2PHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command7 = string.Format("ar1.GetBSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command7);
					string full_command8 = string.Format("BSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command8);
					return;
				}
				if (m_lblRadarDev2PHYFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblRadarDev2PHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command9 = string.Format("ar1.GetBSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command9);
					string full_command10 = string.Format("BSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command10);
					return;
				}
				m_lblRadarDev2PHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command11 = string.Format("ar1.GetBSSFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command11);
				string full_command12 = string.Format("BSSFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command12);
				m_GuiManager.Warning("BSS firmware version Mismatch!");
				return;
			}
			else
			{
				if ((GlobalRef.g_RadarDeviceId & 4U) != 4U)
				{
					if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
					{
						if (string.IsNullOrEmpty(m_lblRadarDev4PHYFwVersion.Text))
						{
							m_lblRadarDev4PHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
							string full_command13 = string.Format("ar1.GetBSSFwVersion()", new object[0]);
							m_GuiManager.RecordLog(13, full_command13);
							string full_command14 = string.Format("BSSFwVersion:({0})", new object[]
							{
								fw_version
							});
							m_GuiManager.RecordLog(13, full_command14);
							return;
						}
						if (m_lblRadarDev4PHYFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
						{
							m_lblRadarDev4PHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
							string full_command15 = string.Format("ar1.GetBSSFwVersion()", new object[0]);
							m_GuiManager.RecordLog(13, full_command15);
							string full_command16 = string.Format("BSSFwVersion:({0})", new object[]
							{
								fw_version
							});
							m_GuiManager.RecordLog(13, full_command16);
							return;
						}
						m_lblRadarDev4PHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
						string full_command17 = string.Format("ar1.GetBSSFwVersion()", new object[0]);
						m_GuiManager.RecordLog(13, full_command17);
						string full_command18 = string.Format("BSSFwVersion:({0})", new object[]
						{
							fw_version
						});
						m_GuiManager.RecordLog(13, full_command18);
						m_GuiManager.Warning("BSS firmware version Mismatch!");
					}
					return;
				}
				if (string.IsNullOrEmpty(m_lblRadarDev3PHYFwVersion.Text))
				{
					m_lblRadarDev3PHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command19 = string.Format("ar1.GetBSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command19);
					string full_command20 = string.Format("BSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command20);
					return;
				}
				if (m_lblRadarDev3PHYFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblRadarDev3PHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command21 = string.Format("ar1.GetBSSFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command21);
					string full_command22 = string.Format("BSSFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command22);
					return;
				}
				m_lblRadarDev3PHYFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command23 = string.Format("ar1.GetBSSFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command23);
				string full_command24 = string.Format("BSSFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command24);
				m_GuiManager.Warning("BSS firmware version Mismatch!");
				return;
			}
		}

		public void SetBSSPatchVersionsInGui(string fw_version)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetBSSPatchVersionsInGui);
				base.Invoke(method, new object[]
				{
					fw_version
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				if (string.IsNullOrEmpty(m_lblBSSPatchFwVersion.Text))
				{
					m_lblBSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command);
					string full_command2 = string.Format("BSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command2);
					return;
				}
				if (m_lblBSSPatchFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblBSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command3 = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command3);
					string full_command4 = string.Format("BSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command4);
					return;
				}
				m_lblBSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command5 = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command5);
				string full_command6 = string.Format("BSSPatchFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command6);
				m_GuiManager.Warning("BSS patch firmware version Mismatch!");
				return;
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				if (string.IsNullOrEmpty(m_lblRadarDev2BSSPatchFwVersion.Text))
				{
					m_lblRadarDev2BSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command7 = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command7);
					string full_command8 = string.Format("BSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command8);
					return;
				}
				if (m_lblRadarDev2BSSPatchFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblRadarDev2BSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command9 = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command9);
					string full_command10 = string.Format("BSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command10);
					return;
				}
				m_lblRadarDev2BSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command11 = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command11);
				string full_command12 = string.Format("BSSPatchFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command12);
				m_GuiManager.Warning("BSS firmware version Mismatch!");
				return;
			}
			else
			{
				if ((GlobalRef.g_RadarDeviceId & 4U) != 4U)
				{
					if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
					{
						if (string.IsNullOrEmpty(m_lblRadarDev4BSSPatchFwVersion.Text))
						{
							m_lblRadarDev4BSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
							string full_command13 = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
							m_GuiManager.RecordLog(13, full_command13);
							string full_command14 = string.Format("BSSPatchFwVersion:({0})", new object[]
							{
								fw_version
							});
							m_GuiManager.RecordLog(13, full_command14);
							return;
						}
						if (m_lblRadarDev4BSSPatchFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
						{
							m_lblRadarDev4BSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
							string full_command15 = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
							m_GuiManager.RecordLog(13, full_command15);
							string full_command16 = string.Format("BSSPatchFwVersion:({0})", new object[]
							{
								fw_version
							});
							m_GuiManager.RecordLog(13, full_command16);
							return;
						}
						m_lblRadarDev4BSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
						string full_command17 = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
						m_GuiManager.RecordLog(13, full_command17);
						string full_command18 = string.Format("BSSPatchFwVersion:({0})", new object[]
						{
							fw_version
						});
						m_GuiManager.RecordLog(13, full_command18);
						m_GuiManager.Warning("BSS firmware version Mismatch!");
					}
					return;
				}
				if (string.IsNullOrEmpty(m_lblRadarDev3BSSPatchFwVersion.Text))
				{
					m_lblRadarDev3BSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command19 = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command19);
					string full_command20 = string.Format("BSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command20);
					return;
				}
				if (m_lblRadarDev3BSSPatchFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(fw_version))
				{
					m_lblRadarDev3BSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
					string full_command21 = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
					m_GuiManager.RecordLog(13, full_command21);
					string full_command22 = string.Format("BSSPatchFwVersion:({0})", new object[]
					{
						fw_version
					});
					m_GuiManager.RecordLog(13, full_command22);
					return;
				}
				m_lblRadarDev3BSSPatchFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(fw_version);
				string full_command23 = string.Format("ar1.GetBSSPatchFwVersion()", new object[0]);
				m_GuiManager.RecordLog(13, full_command23);
				string full_command24 = string.Format("BSSPatchFwVersion:({0})", new object[]
				{
					fw_version
				});
				m_GuiManager.RecordLog(13, full_command24);
				m_GuiManager.Warning("BSS firmware version Mismatch!");
				return;
			}
		}

		public void SetNotAvailBSSPatchVersionsInGui(string fw_version)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetNotAvailBSSPatchVersionsInGui);
				base.Invoke(method, new object[]
				{
					fw_version
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_lblBSSPatchFwVersion.Text = "NA";
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_lblRadarDev2BSSPatchFwVersion.Text = "NA";
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				m_lblRadarDev3BSSPatchFwVersion.Text = "NA";
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				m_lblRadarDev4BSSPatchFwVersion.Text = "NA";
			}
		}

		public void SetNotAvailMSSPatchVersionsInGui(string fw_version)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetNotAvailMSSPatchVersionsInGui);
				base.Invoke(method, new object[]
				{
					fw_version
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_lblMSSPatchFwVersion.Text = "NA";
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_lblRadarDev2MSSPatchFwVersion.Text = "NA";
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				m_lblRadarDev3MSSPatchFwVersion.Text = "NA";
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				m_lblRadarDev4MSSPatchFwVersion.Text = "NA";
			}
		}

		public string GetExactBSSAndMSSFirmwareVersion(string FWVersion)
		{
			string empty = string.Empty;
			string[] array = FWVersion.Split(new char[]
			{
				'('
			});
			string[] array2 = array[0].Split(new char[]
			{
				'.'
			});
			return string.Concat(new string[]
			{
				Convert.ToString(Convert.ToInt32(array2[0])),
				".",
				Convert.ToString(Convert.ToInt32(array2[1])),
				".",
				Convert.ToString(Convert.ToInt32(array2[2])),
				".",
				Convert.ToString(Convert.ToInt32(array2[3]))
			}) + " (" + array[1];
		}

		public void SetDSPVersionsInGui(string dspfw_version)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(SetDSPVersionsInGui);
				base.Invoke(method, new object[]
				{
					dspfw_version
				});
				return;
			}
			if (string.IsNullOrEmpty(m_lblDSPFwVersion.Text))
			{
				m_lblDSPFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(dspfw_version);
				return;
			}
			if (m_lblDSPFwVersion.Text == GetExactBSSAndMSSFirmwareVersion(dspfw_version))
			{
				m_lblDSPFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(dspfw_version);
				return;
			}
			m_lblDSPFwVersion.Text = GetExactBSSAndMSSFirmwareVersion(dspfw_version);
			m_GuiManager.Warning("DSS firmware version Mismatch!");
		}

		public void CloseIt()
		{
			Thread.Sleep(3500);
			SendKeys.SendWait(" ");
		}

		private int iComparePortsByLength(string p0, string p1)
		{
			if (p0 == null)
			{
				if (p1 == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (p1 == null)
				{
					return 1;
				}
				int num = p0.Length.CompareTo(p1.Length);
				if (num != 0)
				{
					return num;
				}
				return p0.CompareTo(p1);
			}
		}

		public void iConnectDisconnect()
		{
			iDisableConnectTabBtn();
			m_MainForm.SetOvBtEnblTimer(true);
			if (m_btnConnect.Text == "Connect (2)")
			{
				m_GuiManager.DllOps.Connect_Gui(1U, 0U);
			}
			else
			{
				m_GuiManager.DllOps.Disconnect_Gui();
			}
			GuiSettings.Default.Save();
			iEnableConnectTabBtn();
			SetBSSFrwLoadReadyState();
			ReSetRS232ReadyState();
			m_MainForm.SetOvBtEnblTimer(false);
		}

		public void iConnectDisconnectRadarDevice2()
		{
			iDisableConnectTabBtn();
			m_MainForm.SetOvBtEnblTimer(true);
			if (m_btnRadarDev2Connect.Text == "Connect")
			{
				m_GuiManager.DllOps.ConnectRadarDev2_Gui(1U, 0U);
			}
			else
			{
				m_GuiManager.DllOps.DisconnectRadarDev2_Gui();
			}
			GuiSettings.Default.Save();
			iEnableConnectTabBtn();
			SetBSSFrwLoadReadyState();
			ReSetRS232ReadyState();
			m_MainForm.SetOvBtEnblTimer(false);
		}

		public void iConnectDisconnectRadarDevice3()
		{
			iDisableConnectTabBtn();
			m_MainForm.SetOvBtEnblTimer(true);
			if (m_btnRadarDev3Connect.Text == "Connect")
			{
				m_GuiManager.DllOps.ConnectRadarDev3_Gui(1U, 0U);
			}
			else
			{
				m_GuiManager.DllOps.DisconnectRadarDev3_Gui();
			}
			GuiSettings.Default.Save();
			iEnableConnectTabBtn();
			SetBSSFrwLoadReadyState();
			ReSetRS232ReadyState();
			m_MainForm.SetOvBtEnblTimer(false);
		}

		public void iConnectDisconnectRadarDevice4()
		{
			iDisableConnectTabBtn();
			m_MainForm.SetOvBtEnblTimer(true);
			if (m_btnRadarDev4Connect.Text == "Connect")
			{
				m_GuiManager.DllOps.ConnectRadarDev4_Gui(1U, 0U);
			}
			else
			{
				m_GuiManager.DllOps.DisconnectRadarDev4_Gui();
			}
			GuiSettings.Default.Save();
			iEnableConnectTabBtn();
			SetBSSFrwLoadReadyState();
			ReSetRS232ReadyState();
			m_MainForm.SetOvBtEnblTimer(false);
		}

		public void ReSetRS232ReadyState()
		{
			m_btnConnect.ForeColor = Color.Black;
			m_btnConnect.BackColor = SystemColors.Control;
		}

		public void SetBSSFrwLoadReadyState()
		{
			m_btnBSS_FwLoad.BackColor = Color.FromArgb(55, 136, 255);
			m_btnBSS_FwLoad.ForeColor = Color.Black;
		}

		public void SetConnectRadar1ReadyState()
		{
			m_btnConnect.ForeColor = Color.Blue;
		}

		public void SetSOPReadyState()
		{
			m_btnSetSop.ForeColor = Color.Black;
		}

		public void ShowMessage(string msg, string txt)
		{
			MessageBox.Show(msg, txt, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public void iSetSPIConnectBtnText(uint p0, string text)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(iSetSPIConnectBtnText);
				base.Invoke(method, new object[]
				{
					p0,
					text
				});
				return;
			}
			if (p0 == 1U)
			{
				m_btnSPIConct.Text = text;
				return;
			}
			if (p0 == 2U)
			{
				m_btnAddDevice2SPIConct.Text = text;
				return;
			}
			if (p0 == 4U)
			{
				m_btnAddDevice3SPIConct.Text = text;
				return;
			}
			if (p0 == 8U)
			{
				m_btnAddDevice4SPIConct.Text = text;
			}
		}

		public void iSetSPIConnectBtnTextColor(Color colour)
		{
			if (base.InvokeRequired)
			{
				del_v_c method = new del_v_c(iSetSPIConnectBtnTextColor);
				base.Invoke(method, new object[]
				{
					colour
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_btnSPIConct.ForeColor = colour;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_btnAddDevice2SPIConct.ForeColor = colour;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				m_btnAddDevice3SPIConct.ForeColor = colour;
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				m_btnAddDevice4SPIConct.ForeColor = colour;
			}
		}

		public void iSetRs232ConnectBtnText(string text)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(iSetRs232ConnectBtnText);
				base.Invoke(method, new object[]
				{
					text
				});
			}
		}

		public void iSetSPIRfEnblBtnText(uint p0, string text)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(iSetSPIRfEnblBtnText);
				base.Invoke(method, new object[]
				{
					p0,
					text
				});
				return;
			}
			if (p0 == 1U)
			{
				m_btnEnblRf.Text = text;
				return;
			}
			if (p0 == 2U)
			{
				m_btnEnblRfDevice2.Text = text;
				return;
			}
			if (p0 == 4U)
			{
				m_btnEnblRfDevice3.Text = text;
				return;
			}
			if (p0 == 8U)
			{
				m_btnEnblRfDevice4.Text = text;
			}
		}

		public string iGetSPIRfEnblBtnText()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(iGetSPIRfEnblBtnText);
				return (string)base.Invoke(method);
			}
			return m_btnEnblRf.Text;
		}

		public void setMssFwVersion(uint deviceMap, string mssVer)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(setMssFwVersion);
				base.Invoke(method, new object[]
				{
					deviceMap,
					mssVer
				});
				return;
			}
			if ((deviceMap & 1U) == 1U)
			{
				m_lblMacFwVersion.Text = mssVer;
				return;
			}
			if ((deviceMap & 2U) == 2U)
			{
				m_lblRadarDev2MacFwVersion.Text = mssVer;
				return;
			}
			if ((deviceMap & 4U) == 4U)
			{
				m_lblRadarDev3MacFwVersion.Text = mssVer;
				return;
			}
			if ((deviceMap & 8U) == 8U)
			{
				m_lblRadarDev4MacFwVersion.Text = mssVer;
			}
		}

		public void setBssFwVersion(uint deviceMap, string bssVer)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(setBssFwVersion);
				base.Invoke(method, new object[]
				{
					deviceMap,
					bssVer
				});
				return;
			}
			if ((deviceMap & 1U) == 1U)
			{
				m_lblPHYFwVersion.Text = bssVer;
				return;
			}
			if ((deviceMap & 2U) == 2U)
			{
				m_lblRadarDev2PHYFwVersion.Text = bssVer;
				return;
			}
			if ((deviceMap & 4U) == 4U)
			{
				m_lblRadarDev3PHYFwVersion.Text = bssVer;
				return;
			}
			if ((deviceMap & 8U) == 8U)
			{
				m_lblRadarDev4PHYFwVersion.Text = bssVer;
			}
		}

		public void clrMssFwVersion()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrMssFwVersion);
				base.Invoke(method);
				return;
			}
			m_lblMacFwVersion.Text = "";
			m_lblMSSPatchFwVersion.Text = "";
		}

		public void clrRadarDevice1Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrRadarDevice1Status);
				base.Invoke(method);
				return;
			}
			m_lblDevStatus.Text = "";
			m_lblDieIDInfo.Text = "";
		}

		public void clrAllStatusofConnectTab()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrAllStatusofConnectTab);
				base.Invoke(method);
				return;
			}
			m_btnConnect.BackColor = SystemColors.Control;
			m_btnBSS_FwLoad.BackColor = SystemColors.Control;
			m_btnMSS_FwLoad.BackColor = SystemColors.Control;
			m_btnSPIConct.BackColor = SystemColors.Control;
			m_btnEnblRf.BackColor = SystemColors.Control;
		}

		public void clrRadarDevice2Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrRadarDevice2Status);
				base.Invoke(method);
				return;
			}
			m_lblDev2Status.Text = "";
			m_lblRadarDev2DieIDInfo.Text = "";
		}

		public void clrRadarDevice3Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrRadarDevice3Status);
				base.Invoke(method);
				return;
			}
			m_lblDev3Status.Text = "";
			m_lblRadarDev3DieIDInfo.Text = "";
		}

		public void clrRadarDevice4Status()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrRadarDevice4Status);
				base.Invoke(method);
				return;
			}
			m_lblDev4Status.Text = "";
			m_lblRadarDev4DieIDInfo.Text = "";
		}

		public void m00001c()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(m00001c);
				base.Invoke(method);
				return;
			}
			m_lblPHYFwVersion.Text = "";
			m_lblBSSPatchFwVersion.Text = "";
		}

		public void clrMssDev2FwVersion()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrMssDev2FwVersion);
				base.Invoke(method);
				return;
			}
			m_lblRadarDev2MacFwVersion.Text = "";
			m_lblRadarDev2MSSPatchFwVersion.Text = "";
		}

		public void clrMssDev3FwVersion()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrMssDev3FwVersion);
				base.Invoke(method);
				return;
			}
			m_lblRadarDev3MacFwVersion.Text = "";
			m_lblRadarDev3MSSPatchFwVersion.Text = "";
		}

		public void clrMssDev4FwVersion()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrMssDev4FwVersion);
				base.Invoke(method);
				return;
			}
			m_lblRadarDev4MacFwVersion.Text = "";
			m_lblRadarDev4MSSPatchFwVersion.Text = "";
		}

		public void m00001d()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(m00001d);
				base.Invoke(method);
				return;
			}
			m_lblRadarDev2PHYFwVersion.Text = "";
			m_lblRadarDev2BSSPatchFwVersion.Text = "";
		}

		public void m00001e()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(m00001e);
				base.Invoke(method);
				return;
			}
			m_lblRadarDev3PHYFwVersion.Text = "";
			m_lblRadarDev3BSSPatchFwVersion.Text = "";
		}

		public void m00001f()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(m00001f);
				base.Invoke(method);
				return;
			}
			m_lblRadarDev4PHYFwVersion.Text = "";
			m_lblRadarDev4BSSPatchFwVersion.Text = "";
		}

		private int iGetIndexFromPortName()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(iGetIndexFromPortName);
				return (int)base.Invoke(method);
			}
			int result = -1;
			if (m_cboComPort.SelectedItem == null)
			{
				return result;
			}
			string text = m_cboComPort.SelectedItem.ToString();
			if (text != null && text.StartsWith("COM") && !int.TryParse(text.Replace("COM", ""), out result))
			{
				m_GuiManager.Error("Could not detect com index from selected COM port");
			}
			return result;
		}

		private int iGetIndexFromPortNameForRadarDevice2()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(iGetIndexFromPortNameForRadarDevice2);
				return (int)base.Invoke(method);
			}
			int result = -1;
			if (m_cboRadarDevice2ComPort.SelectedItem == null)
			{
				return result;
			}
			string text = m_cboRadarDevice2ComPort.SelectedItem.ToString();
			if (text != null && text.StartsWith("COM") && !int.TryParse(text.Replace("COM", ""), out result))
			{
				m_GuiManager.Error("Could not detect com index from selected COM port");
			}
			return result;
		}

		private int iGetIndexFromPortNameForRadarDevice3()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(iGetIndexFromPortNameForRadarDevice3);
				return (int)base.Invoke(method);
			}
			int result = -1;
			if (m_cboRadarDevice3ComPort.SelectedItem == null)
			{
				return result;
			}
			string text = m_cboRadarDevice3ComPort.SelectedItem.ToString();
			if (text != null && text.StartsWith("COM") && !int.TryParse(text.Replace("COM", ""), out result))
			{
				m_GuiManager.Error("Could not detect com index from selected COM port");
			}
			return result;
		}

		private int iGetIndexFromPortNameForRadarDevice4()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(iGetIndexFromPortNameForRadarDevice4);
				return (int)base.Invoke(method);
			}
			int result = -1;
			if (m_cboRadarDevice4ComPort.SelectedItem == null)
			{
				return result;
			}
			string text = m_cboRadarDevice4ComPort.SelectedItem.ToString();
			if (text != null && text.StartsWith("COM") && !int.TryParse(text.Replace("COM", ""), out result))
			{
				m_GuiManager.Error("Could not detect com index from selected COM port");
			}
			return result;
		}

		private bool iHandleDownloadFwProgress(bool ext)
		{
			if (base.InvokeRequired)
			{
				del_b_b method = new del_b_b(iHandleDownloadFwProgress);
				return (bool)base.Invoke(method, new object[]
				{
					ext
				});
			}
			return new frmProgressBar().ShowDialog() == DialogResult.OK;
		}

		private void iRunPostDownloadFwEvents()
		{
			SetBSSVersions();
		}

		private void iRunPostDownloadDSPFwEvents()
		{
			SetDSPVersions();
		}

		private void iRunMssPostDownloadFwEvents()
		{
			SetMSSVersions();
		}

		private void iRunPostDownloadFwEventsAsync()
		{
			iRunPostDownloadFwEvents();
		}

		private void iRunPostDownloadDSPFwEventsAsync()
		{
			new del_v_v(iRunPostDownloadDSPFwEvents).BeginInvoke(null, null);
		}

		private void iRunMssPostDownloadFwEventsAsync()
		{
			iRunMssPostDownloadFwEvents();
		}

		private void iPostConnect()
		{
			if (m_GuiManager.PhyStandAlone)
			{
				m_MainForm.SetCalibUponTune(true);
			}
			m_MainForm.UpdateDieID();
		}

		public void UpdateConnectionTabEnabledStatus()
		{
			m_btnBSS_FwLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_btnMSS_FwLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_btnCfg_FileLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_cboComPort.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_cboBaudRate.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnRefreshPorts.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnSPIConct.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnConnect.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				m_btnConnect.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
				m_btnSPIConct.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
				m_cboComPort.Enabled = false;
				m_cboBaudRate.Enabled = false;
				m_btnRefreshPorts.Enabled = false;
			}
			if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
			{
				m_btnBSS_FwLoad.Enabled = true;
				m_btnMSS_FwLoad.Enabled = true;
				m_btnCfg_FileLoad.Enabled = true;
			}
			DisableControls();
		}

		public void UpdateConnectionTabEnabledStatusRadarDevice2()
		{
			m_btnBSS_FwLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_btnMSS_FwLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_btnCfg_FileLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_cboComPort.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_cboBaudRate.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnRefreshPorts.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnSPIConct.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnConnect.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				m_btnConnect.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
				m_btnSPIConct.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
				m_cboComPort.Enabled = false;
				m_cboBaudRate.Enabled = false;
				m_btnRefreshPorts.Enabled = false;
			}
			if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
			{
				m_btnBSS_FwLoad.Enabled = true;
				m_btnMSS_FwLoad.Enabled = true;
				m_btnCfg_FileLoad.Enabled = true;
			}
			DisableControls();
		}

		public void UpdateConnectionTabEnabledStatusRadarDevice3()
		{
			m_btnBSS_FwLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_btnMSS_FwLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_btnCfg_FileLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_cboComPort.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_cboBaudRate.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnRefreshPorts.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnSPIConct.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnConnect.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				m_btnConnect.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
				m_btnSPIConct.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
				m_cboComPort.Enabled = false;
				m_cboBaudRate.Enabled = false;
				m_btnRefreshPorts.Enabled = false;
			}
			if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
			{
				m_btnBSS_FwLoad.Enabled = true;
				m_btnMSS_FwLoad.Enabled = true;
				m_btnCfg_FileLoad.Enabled = true;
			}
			DisableControls();
		}

		public void UpdateConnectionTabEnabledStatusRadarDevice4()
		{
			m_btnBSS_FwLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_btnMSS_FwLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_btnCfg_FileLoad.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
			m_cboComPort.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_cboBaudRate.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnRefreshPorts.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnSPIConct.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			m_btnConnect.Enabled = (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED);
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				m_btnConnect.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
				m_btnSPIConct.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
				m_cboComPort.Enabled = false;
				m_cboBaudRate.Enabled = false;
				m_btnRefreshPorts.Enabled = false;
			}
			if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
			{
				m_btnBSS_FwLoad.Enabled = true;
				m_btnMSS_FwLoad.Enabled = true;
				m_btnCfg_FileLoad.Enabled = true;
			}
			DisableControls();
		}

		public void UpdateConnectionTabEnabledSts()
		{
			m_btnBSS_FwLoad.Enabled = false;
			m_btnMSS_FwLoad.Enabled = false;
			m_btnCfg_FileLoad.Enabled = false;
			m_cboComPort.Enabled = true;
			m_cboBaudRate.Enabled = true;
			m_btnRefreshPorts.Enabled = true;
			m_btnSPIConct.Enabled = true;
			m_btnConnect.Enabled = true;
			if (GlobalRef.g_RS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				m_cboComPort.Enabled = true;
				m_cboBaudRate.Enabled = true;
				m_btnRefreshPorts.Enabled = true;
				m_btnSPIConct.Enabled = false;
				m_btnConnect.Enabled = true;
			}
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				m_btnConnect.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
				m_btnSPIConct.Enabled = (m_MainForm.BoardStatus > BoardStatus.DISCONNECTED);
				m_cboComPort.Enabled = false;
				m_cboBaudRate.Enabled = false;
				m_btnRefreshPorts.Enabled = false;
				m_btnSPIConct.Enabled = true;
				m_btnConnect.Enabled = true;
				m_btnBSS_FwLoad.Enabled = true;
				m_btnMSS_FwLoad.Enabled = true;
				m_btnCfg_FileLoad.Enabled = true;
			}
			if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
			{
				m_btnBSS_FwLoad.Enabled = true;
				m_btnMSS_FwLoad.Enabled = true;
				m_btnCfg_FileLoad.Enabled = true;
				m_btnSPIConct.Enabled = true;
				m_btnConnect.Enabled = true;
			}
		}

		private uint ReverseBytes(uint value)
		{
			return (value & 255U) << 24 | (value & 65280U) << 8 | (value & 16711680U) >> 8 | (value & 4278190080U) >> 24;
		}

		public string GetFwPath()
		{
			return m_ConnectParams.BSS_FwPath;
		}

		public string GetMSSFwPath()
		{
			return m_ConnectParams.MSS_FwPath;
		}

		public string GetDspFwPath()
		{
			return m_ConnectParams.DSP_FwPath;
		}

		public int DownloadFw(bool ext, string fw_path)
		{
			int result = -1;
			m_bFwDownloadInProgress = true;
			if (!string.IsNullOrEmpty(fw_path))
			{
				if (File.Exists(fw_path))
				{
					if (!ext)
					{
						new del_i_s(DownloadFw_Invoke).BeginInvoke(fw_path, null, null);
						if (iHandleDownloadFwProgress(ext))
						{
							result = 0;
							if (GlobalRef.g_BSSFwDownloadStatus == 1U)
							{
								iRunPostDownloadFwEventsAsync();
							}
							if (GlobalRef.g_MSSFwDownloadStatus == 1U)
							{
								iRunMssPostDownloadFwEventsAsync();
							}
						}
					}
					else
					{
						new del_b_b(iHandleDownloadFwProgress).BeginInvoke(ext, null, null);
						result = DownloadFw_Invoke(fw_path);
					}
				}
				else
				{
					m_GuiManager.Error(string.Format("Could not find file '{0}'", fw_path));
				}
			}
			m_bFwDownloadInProgress = false;
			return result;
		}

		public int CustomDownloadFw(bool ext, string fw_path)
		{
			int result = -1;
			m_bFwDownloadInProgress = true;
			if (!string.IsNullOrEmpty(fw_path))
			{
				if (File.Exists(fw_path))
				{
					if (!ext)
					{
						new del_i_s(CustomDownloadFw_Invoke).BeginInvoke(fw_path, null, null);
						if (iHandleDownloadFwProgress(ext))
						{
							result = 0;
							if (ConnectTab.m_BSSDwnld || GlobalRef.g_BSSFwDl)
							{
								iRunPostDownloadFwEventsAsync();
							}
							else if (ConnectTab.m_MSSDwnld || GlobalRef.g_MSSFwDl)
							{
								iRunMssPostDownloadFwEventsAsync();
							}
						}
					}
					else
					{
						new del_b_b(iHandleDownloadFwProgress).BeginInvoke(ext, null, null);
						result = DownloadFw_Invoke(fw_path);
					}
				}
				else
				{
					m_GuiManager.Error(string.Format("Could not find file '{0}'", fw_path));
				}
			}
			m_bFwDownloadInProgress = false;
			return result;
		}

		public int DownloadDSPFw(bool ext, string fw_path)
		{
			int result = -1;
			m_bFwDownloadInProgress = true;
			if (!string.IsNullOrEmpty(fw_path))
			{
				if (File.Exists(fw_path))
				{
					if (!ext)
					{
						new del_i_s(DownloadDSPFw_Invoke).BeginInvoke(fw_path, null, null);
						if (iHandleDownloadFwProgress(ext))
						{
							result = 0;
							iRunPostDownloadDSPFwEventsAsync();
						}
					}
					else
					{
						new del_b_b(iHandleDownloadFwProgress).BeginInvoke(ext, null, null);
						result = DownloadDSPFw_Invoke(fw_path);
					}
				}
				else
				{
					m_GuiManager.Error(string.Format("Could not find file '{0}'", fw_path));
				}
			}
			m_bFwDownloadInProgress = false;
			return result;
		}

		public int m000020(string fw_path)
		{
			GlobalRef.g_BSSFwDownloadStatus = 0U;
			GlobalRef.g_MSSFwDownloadStatus = 0U;
			m_ConnectParams.BSS_FwPath = fw_path;
			iSetPathInCombo(m_ConnectParams.BSS_FwPath, m_cboBSS_FwFile);
			return DownloadFw(false, fw_path);
		}

		public int CustomDownloadBssFw(string fw_path)
		{
			m_ConnectParams.BSS_FwPath = fw_path;
			iSetPathInCombo(m_ConnectParams.BSS_FwPath, m_cboBSS_FwFile);
			return CustomDownloadFw(false, fw_path);
		}

		public int DownloadMssFw(string fw_path)
		{
			GlobalRef.g_BSSFwDownloadStatus = 0U;
			GlobalRef.g_MSSFwDownloadStatus = 0U;
			m_ConnectParams.MSS_FwPath = fw_path;
			iSetPathInCombo(m_ConnectParams.MSS_FwPath, m_cboMSS_FwFile);
			return DownloadFw(false, fw_path);
		}

		public int m000021(string fw_path)
		{
			m_ConnectParams.DSP_FwPath = fw_path;
			iSetPathInCombo(m_ConnectParams.DSP_FwPath, m_cboDSP_FwFile);
			return DownloadDSPFw(false, fw_path);
		}

		public int CustomDownloadMssFw(string fw_path)
		{
			m_ConnectParams.MSS_FwPath = fw_path;
			iSetPathInCombo(m_ConnectParams.MSS_FwPath, m_cboMSS_FwFile);
			return CustomDownloadFw(false, fw_path);
		}

		public void UpdateSpiDownloadInfo(string metaImagePath)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(UpdateSpiDownloadInfo);
				base.Invoke(method, new object[]
				{
					metaImagePath
				});
				return;
			}
			m_cboBSS_FwFile.Text = metaImagePath;
		}

		public int DownloadFw_Invoke(string fw_path)
		{
			int num = -1;
			m_bDownlaodFwAbort = false;
			if (GlobalRef.g_2ChipCascade || GlobalRef.g_4ChipCascade)
			{
				UpdateSpiDownloadInfo(fw_path);
			}
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				num = m_AR1Wrapper.m0000c7(fw_path);
			}
			else if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
			{
				num = m_AR1Wrapper.DownloadFileOvSPI(fw_path);
			}
			if (num != 0)
			{
				m_GuiManager.Error(string.Format("Download FW failed with error {0}", num));
				m_bDownlaodFwAbort = true;
			}
			return num;
		}

		public int CustomDownloadFw_Invoke(string fw_path)
		{
			int num = -1;
			m_bDownlaodFwAbort = false;
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				num = m_AR1Wrapper.m0000c8(fw_path);
			}
			else if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
			{
				num = m_AR1Wrapper.DownloadFileOvSPI(fw_path);
			}
			if (num != 0)
			{
				m_GuiManager.Error(string.Format("Download FW failed with error {0}", num));
				m_bDownlaodFwAbort = true;
			}
			return num;
		}

		public int DownloadDSPFw_Invoke(string fw_path)
		{
			int num = -1;
			m_bDownlaodFwAbort = false;
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				num = m_AR1Wrapper.m0000c9(fw_path);
			}
			else if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
			{
				num = m_AR1Wrapper.m0000ca(fw_path);
			}
			if (num != 0)
			{
				m_GuiManager.Error(string.Format("Download FW failed with error {0}", num));
				m_bDownlaodFwAbort = true;
			}
			return num;
		}

		public string GetPhyFwPath()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(GetPhyFwPath);
				return (string)base.Invoke(method);
			}
			return m_cboBSS_FwFile.Text;
		}

		public string GetMssFwPath()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(GetMssFwPath);
				return (string)base.Invoke(method);
			}
			return m_cboMSS_FwFile.Text;
		}

		public string GetMacFwPath()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(GetMacFwPath);
				return (string)base.Invoke(method);
			}
			if (m_cboMSS_FwFile.Text == "")
			{
				return m_cboBSS_FwFile.Text;
			}
			return m_cboMSS_FwFile.Text;
		}

		public string GetDSPFwPath()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(GetDSPFwPath);
				return (string)base.Invoke(method);
			}
			m_cboDSP_FwFile.Text = "";
			return m_cboDSP_FwFile.Text;
		}

		public string GetCfgFwPath()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(GetCfgFwPath);
				return (string)base.Invoke(method);
			}
			return m_cboCfg_File.Text;
		}

		public string GetNvsPath()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(GetNvsPath);
				return (string)base.Invoke(method);
			}
			return "Path";
		}

		private string iHandleBrowseFiles(string file_type, string current_path)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (!(file_type == "FW") && !(file_type == "NVS"))
			{
				if (!(file_type == "INI"))
				{
					if (file_type == "DLL")
					{
						openFileDialog.Title = "Browse for DLL file";
						openFileDialog.Filter = "DLL File (*.dll)|*.dll";
					}
				}
				else
				{
					openFileDialog.Title = "Browse for INI file";
					openFileDialog.Filter = "INI File (*.ini)|*.ini";
				}
			}
			else
			{
				openFileDialog.Title = "Browse for firmware file";
				openFileDialog.Filter = "Binary Files (*.bin)|*.bin";
			}
			openFileDialog.RestoreDirectory = true;
			if (!string.IsNullOrEmpty(current_path) && File.Exists(current_path))
			{
				openFileDialog.InitialDirectory = Path.GetDirectoryName(current_path);
			}
			openFileDialog.ShowDialog();
			return openFileDialog.FileName;
		}

		private void iSetPathInCombo(string path, ComboBox combo)
		{
			if (base.InvokeRequired)
			{
				del_SetPathInCombo method = new del_SetPathInCombo(iSetPathInCombo);
				base.Invoke(method, new object[]
				{
					path,
					combo
				});
				return;
			}
			if (string.IsNullOrEmpty(path))
			{
				return;
			}
			if (!combo.Items.Contains(path))
			{
				if (combo.Items.Count >= Constants.MaxPaths)
				{
					combo.Items.Remove(combo.Items[combo.Items.Count - 1]);
				}
				combo.Items.Insert(0, path);
			}
			else
			{
				combo.Items.Remove(path);
				combo.Items.Insert(0, path);
			}
			combo.SelectedIndex = combo.FindStringExact(path);
		}

		public void SetDllInCombo(string dll_path)
		{
		}

		public void BindGuiOps()
		{
		}

		public void ConnectBegin()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(ConnectBegin);
				base.Invoke(method);
				return;
			}
			m_bIsConnectInProgress = true;
			iAllowConnectBtnEvent(false);
		}

		public void ConnectEnd(int res, bool ext)
		{
			if (res != 0)
			{
				iSetConnectBtnText("Connect (2)");
			}
			else
			{
				m_MainForm.HandleBoardStatusChange(ext);
				iPostConnect();
			}
			iAllowConnectBtnEvent(true);
			m_bIsConnectInProgress = false;
		}

		public void ConnectEndRadarDevice2(int res, bool ext)
		{
			if (res != 0)
			{
				iSetConnectBtnTextRadarDevice2("Connect");
			}
			else
			{
				m_MainForm.HandleBoardStatusChangeRadarDevice2(ext);
				iPostConnect();
			}
			iAllowConnectBtnEvent(true);
			m_bIsConnectInProgress = false;
		}

		public void ConnectEndRadarDevice3(int res, bool ext)
		{
			if (res != 0)
			{
				iSetConnectBtnTextRadarDevice3("Connect");
			}
			else
			{
				m_MainForm.HandleBoardStatusChangeRadarDevice3(ext);
				iPostConnect();
			}
			iAllowConnectBtnEvent(true);
			m_bIsConnectInProgress = false;
		}

		public void ConnectEndRadarDevice4(int res, bool ext)
		{
			if (res != 0)
			{
				iSetConnectBtnTextRadarDevice4("Connect");
			}
			else
			{
				m_MainForm.HandleBoardStatusChangeRadarDevice4(ext);
				iPostConnect();
			}
			iAllowConnectBtnEvent(true);
			m_bIsConnectInProgress = false;
		}

		public void iSetConnectBtnText(string text)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(iSetConnectBtnText);
				base.Invoke(method, new object[]
				{
					text
				});
				return;
			}
			m_btnConnect.Text = text;
		}

		public void iSetConnectBtnTextRadarDevice2(string text)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(iSetConnectBtnTextRadarDevice2);
				base.Invoke(method, new object[]
				{
					text
				});
				return;
			}
			m_btnRadarDev2Connect.Text = text;
		}

		public void iSetConnectBtnTextRadarDevice3(string text)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(iSetConnectBtnTextRadarDevice3);
				base.Invoke(method, new object[]
				{
					text
				});
				return;
			}
			m_btnRadarDev3Connect.Text = text;
		}

		public void iSetConnectBtnTextRadarDevice4(string text)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(iSetConnectBtnTextRadarDevice4);
				base.Invoke(method, new object[]
				{
					text
				});
				return;
			}
			m_btnRadarDev4Connect.Text = text;
		}

		public string iGetConnectBtnText()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(iGetConnectBtnText);
				return (string)base.Invoke(method);
			}
			return m_btnConnect.Text;
		}

		private void iAllowConnectBtnEvent(bool enable)
		{
			if (base.InvokeRequired)
			{
				del_v_b method = new del_v_b(iAllowConnectBtnEvent);
				base.Invoke(method, new object[]
				{
					enable
				});
				return;
			}
			if (enable)
			{
				m_btnConnect.Click += m_btnConnect_Click;
				return;
			}
			m_btnConnect.Click -= m_btnConnect_Click;
		}

		public bool iDisableConnectTabBtn()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(iDisableConnectTabBtn);
				return (bool)base.Invoke(method);
			}
			m_btnConnect.Enabled = false;
			m_btnSPIConct.Enabled = false;
			m_btnEnblRf.Enabled = false;
			m_btnSetSop.Enabled = false;
			m_btnFullRst.Enabled = false;
			return true;
		}

		public bool iEnableConnectTabBtn()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(iEnableConnectTabBtn);
				return (bool)base.Invoke(method);
			}
			m_btnConnect.Enabled = true;
			m_btnSPIConct.Enabled = true;
			m_btnEnblRf.Enabled = true;
			m_btnSetSop.Enabled = true;
			m_btnFullRst.Enabled = true;
			return true;
		}

		public void SetOvUvTimer(bool enable)
		{
			if (base.InvokeRequired)
			{
				del_v_b method = new del_v_b(SetOvUvTimer);
				base.Invoke(method, new object[]
				{
					enable
				});
				return;
			}
			if (enable)
			{
				m_timerCheckOvUv.Start();
				return;
			}
			m_timerCheckOvUv.Stop();
		}

		public void GetBoardInfo()
		{
			m_GuiManager.Log("Getting board info...");
			iGetPG_Version();
		}

		private void iGetPG_Version()
		{
			uint num;
			GlobalRef.TsWrapper.ReadRegister(4, 9740U, 4, 6, out num);
			uint num2;
			GlobalRef.TsWrapper.ReadRegister(4, 9740U, 2, 3, out num2);
			m_GuiManager.PG2 = (num >= 2U);
			m_GuiManager.BoardInfo.PG = string.Format("{0}.{1}", num, num2);
		}

		public string GetFdspVersion()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(GetFdspVersion);
				return (string)base.Invoke(method);
			}
			m_GuiManager.Log("Reading FDSP version...");
			uint start_address = 2157060116U;
			int length = 8;
			string result = iFillStr(start_address, length);
			if (!m000022(ref result))
			{
				result = "ERR";
			}
			return result;
		}

		private bool m000022(ref string version)
		{
			uint num = 0U;
			uint num2 = 0U;
			string[] array = version.Split(new char[]
			{
				'.'
			});
			if (array.Length != 2)
			{
				return false;
			}
			if (!uint.TryParse(array[0], NumberStyles.HexNumber, null, out num))
			{
				return false;
			}
			if (!uint.TryParse(array[1], NumberStyles.HexNumber, null, out num2))
			{
				return false;
			}
			version = num.ToString() + "." + num2.ToString();
			return true;
		}

		public bool UpdateTsIni(string ini_path)
		{
			GlobalRef.GuiManager.Log(string.Format("Updating '{0}'...", ini_path));
			AR1IniHandler ar1IniHandler = new AR1IniHandler(ini_path);
			bool flag = ar1IniHandler.ReadIniFile();
			if (flag)
			{
				flag = ar1IniHandler.WriteIniFile();
			}
			return flag;
		}

		public void ResetBoardInfo()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(ResetBoardInfo);
				base.Invoke(method);
				return;
			}
			m_GuiManager.BoardInfo.Reset();
		}

		public void DisconnectBegin()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(DisconnectBegin);
				base.Invoke(method);
				return;
			}
			m_bIsConnectInProgress = true;
			iAllowConnectBtnEvent(false);
			SetOvUvTimer(false);
		}

		public void DisconnectEnd(int res, bool ext)
		{
			if (base.InvokeRequired)
			{
				del_v_i_b method = new del_v_i_b(DisconnectEnd);
				base.Invoke(method, new object[]
				{
					res,
					ext
				});
				return;
			}
			if (res != 0)
			{
				m_btnConnect.Text = "Disconnect (2)";
			}
			else
			{
				m_MainForm.HandleBoardStatusChange(ext);
			}
			iAllowConnectBtnEvent(true);
			m_bIsConnectInProgress = false;
			if (iGetSPIRfEnblBtnText() == "RF Powered-up" && !GlobalRef.g_SpiConnect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				iSetSPIRfEnblBtnText(1U, "RF Power-up");
			}
		}

		public void DisconnectEndRadarDevice2(int res, bool ext)
		{
			if (base.InvokeRequired)
			{
				del_v_i_b method = new del_v_i_b(DisconnectEndRadarDevice2);
				base.Invoke(method, new object[]
				{
					res,
					ext
				});
				return;
			}
			if (res != 0)
			{
				m_btnRadarDev2Connect.Text = "Disconnect";
			}
			else
			{
				m_MainForm.HandleBoardStatusChangeRadarDevice2(ext);
			}
			iAllowConnectBtnEvent(true);
			m_bIsConnectInProgress = false;
			if (iGetSPIRfEnblBtnText() == "RF Powered-up" && !GlobalRef.g_SpiConnect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				iSetSPIRfEnblBtnText(2U, "RF Power-up");
			}
		}

		public void DisconnectEndRadarDevice3(int res, bool ext)
		{
			if (base.InvokeRequired)
			{
				del_v_i_b method = new del_v_i_b(DisconnectEndRadarDevice3);
				base.Invoke(method, new object[]
				{
					res,
					ext
				});
				return;
			}
			if (res != 0)
			{
				m_btnRadarDev3Connect.Text = "Disconnect";
			}
			else
			{
				m_MainForm.HandleBoardStatusChangeRadarDevice3(ext);
			}
			iAllowConnectBtnEvent(true);
			m_bIsConnectInProgress = false;
			if (iGetSPIRfEnblBtnText() == "RF Powered-up" && !GlobalRef.g_SpiConnect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				iSetSPIRfEnblBtnText(4U, "RF Power-up");
			}
		}

		public void DisconnectEndRadarDevice4(int res, bool ext)
		{
			if (base.InvokeRequired)
			{
				del_v_i_b method = new del_v_i_b(DisconnectEndRadarDevice4);
				base.Invoke(method, new object[]
				{
					res,
					ext
				});
				return;
			}
			if (res != 0)
			{
				m_btnRadarDev4Connect.Text = "Disconnect";
			}
			else
			{
				m_MainForm.HandleBoardStatusChangeRadarDevice4(ext);
			}
			iAllowConnectBtnEvent(true);
			m_bIsConnectInProgress = false;
			if (iGetSPIRfEnblBtnText() == "RF Powered-up" && !GlobalRef.g_SpiConnect[(int)GlobalRef.g_RadarDeviceIndex])
			{
				iSetSPIRfEnblBtnText(8U, "RF Power-up");
			}
		}

		public void tempDisconnectEnd(int res, bool ext)
		{
			if (base.InvokeRequired)
			{
				del_v_i_b method = new del_v_i_b(tempDisconnectEnd);
				base.Invoke(method, new object[]
				{
					res,
					ext
				});
				return;
			}
			iAllowConnectBtnEvent(true);
			m_bIsConnectInProgress = false;
		}

		private void m_btnConnect_Click(object sender, EventArgs p1)
		{
			new del_v_v(iConnectDisconnect).BeginInvoke(null, null);
		}

		public void m_btnRS232()
		{
			new del_v_v(iConnectDisconnect).BeginInvoke(null, null);
		}

		private void m_btnRadarDev2Connect_Click(object sender, EventArgs p1)
		{
			new del_v_v(iConnectDisconnectRadarDevice2).BeginInvoke(null, null);
		}

		private void m_btnRadarDev3Connect_Click(object sender, EventArgs p1)
		{
			new del_v_v(iConnectDisconnectRadarDevice3).BeginInvoke(null, null);
		}

		private void m_btnRadarDev4Connect_Click(object sender, EventArgs p1)
		{
			new del_v_v(iConnectDisconnectRadarDevice4).BeginInvoke(null, null);
		}

		private void m_btnRefreshPorts_Click(object sender, EventArgs p1)
		{
			iFillComPortCombo();
		}

		private void m_btnFwLoad_Click(object sender, EventArgs p1)
		{
			GlobalRef.g_BSSFwDownloadStatus = 0U;
			GlobalRef.g_MSSFwDownloadStatus = 0U;
			iDownloadFwAsync();
			ConnectTab.m_BSSDwnld = true;
		}

		public void m000023()
		{
			GlobalRef.g_BSSFwDownloadStatus = 0U;
			GlobalRef.g_MSSFwDownloadStatus = 0U;
			iDownloadFwAsync();
			ConnectTab.m_BSSDwnld = true;
		}

		private void m_btnMSSFwLoad_Click(object sender, EventArgs p1)
		{
			GlobalRef.g_MSSFwDownloadStatus = 0U;
			GlobalRef.g_BSSFwDownloadStatus = 0U;
			iDownloadMSSFwAsync();
			ConnectTab.m_BSSDwnld = false;
			ConnectTab.m_MSSDwnld = true;
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_btnSPIConct.Enabled = false;
				m_btnEnblRf.Enabled = false;
				return;
			}
			m_btnSPIConct.Enabled = true;
			m_btnEnblRf.Enabled = true;
		}

		public void m000024()
		{
			GlobalRef.g_MSSFwDownloadStatus = 0U;
			GlobalRef.g_BSSFwDownloadStatus = 0U;
			iDownloadMSSFwAsync();
			ConnectTab.m_BSSDwnld = false;
			ConnectTab.m_MSSDwnld = true;
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_btnSPIConct.Enabled = false;
				m_btnEnblRf.Enabled = false;
				return;
			}
			m_btnSPIConct.Enabled = true;
			m_btnEnblRf.Enabled = true;
		}

		private void m_btnDSP_FwLoad_Click(object sender, EventArgs p1)
		{
			string text = m_lblDevStatus.Text;
			if (text == "")
			{
				MessageBox.Show("The device is not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (text.Substring(0, 6) == "AR16xx")
			{
				EnableDSPConfSpecifications();
				iDownloadDSPFwAsync();
				return;
			}
			DisableDSPGuiSpecs();
			MessageBox.Show("Invalid Device type. This DSP firmware supports only the AR16XX device !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		public void DisableDSPGuiSpecs()
		{
			f000194.Enabled = false;
			m_cboDSP_FwFile.Enabled = false;
			m_DSPCheck.Enabled = false;
			m_btnDSP_FwLoad.Enabled = false;
			f000193.Enabled = false;
		}

		private void iDownloadDSPFwAsync()
		{
			new del_v_v(iDownloadDSPFw).BeginInvoke(null, null);
		}

		private void iDownloadFwAsync()
		{
			new del_v_v(iDownloadFw).BeginInvoke(null, null);
		}

		private void iDownloadMSSFwAsync()
		{
			new del_v_v(iDownloadMssFw).BeginInvoke(null, null);
		}

		public void SetMSSFrwLoadReadyState()
		{
			m_btnMSS_FwLoad.BackColor = Color.FromArgb(55, 136, 255);
			m_btnMSS_FwLoad.ForeColor = Color.Black;
		}

		private void iDownloadFw()
		{
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] && m_ConnectParams.SopMod == 4)
			{
				m_GuiManager.Log("Download over RS232 is not supported in Functional Mode!");
			}
			else
			{
				m_GuiManager.DllOps.DownloadFw_Gui();
			}
			SetMSSFrwLoadReadyState();
			ReSetBSSFrwReadyState();
		}

		public void ReSetBSSFrwReadyState()
		{
			m_btnBSS_FwLoad.ForeColor = Color.Black;
			m_btnBSS_FwLoad.BackColor = SystemColors.Control;
		}

		private void iDownloadMssFw()
		{
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] && m_ConnectParams.SopMod == 4)
			{
				m_GuiManager.Log("Download over RS232 is not supported in Functional Mode!");
			}
			else
			{
				m_GuiManager.DllOps.DownloadMssFw_Gui();
			}
			SetSPIConnectReadyState();
			ReSetMSSFrwReadyState();
		}

		private void iDownloadDSPFw()
		{
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] && m_ConnectParams.SopMod == 4)
			{
				m_GuiManager.Log("Download over RS232 is not supported in Functional Mode!");
				return;
			}
			m_GuiManager.DllOps.DownloadDSPFw_Gui();
		}

		public void ReSetMSSFrwReadyState()
		{
			m_btnMSS_FwLoad.ForeColor = Color.Black;
			m_btnMSS_FwLoad.BackColor = SystemColors.Control;
		}

		public void SetConfiReadyState()
		{
			m_btnCfg_FileLoad.ForeColor = Color.Blue;
		}

		public void SetSPIConnectReadyState()
		{
			m_btnSPIConct.BackColor = Color.FromArgb(55, 136, 255);
			m_btnSPIConct.ForeColor = Color.Black;
		}

		private void m_timerCheckOvUv_Tick(object sender, EventArgs p1)
		{
			bool flag = true;
			if (!m_GuiManager.OvUvCheckEnabled || flag || !m_GuiManager.PG2 || m_GuiManager.IsElpOn)
			{
				return;
			}
			if (m_bIsConnectInProgress || m_bFwDownloadInProgress)
			{
				return;
			}
			if (m_MainForm.BoardStatus == BoardStatus.DISCONNECTED)
			{
				return;
			}
			iCheckOvUvAsync();
		}

		private void iCheckOvUvAsync()
		{
			new del_v_v(iCheckOvUv).BeginInvoke(null, null);
		}

		private void iCheckOvUv()
		{
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			SetOvUvTimer(false);
			try
			{
				GlobalRef.TsWrapper.ReadRegister(4, 8530U, 5, 7, out num);
				GlobalRef.TsWrapper.ReadRegister(4, 8772U, 7, 7, out num2);
				GlobalRef.TsWrapper.ReadRegister(2, 8475692U, 16, 31, out num3);
				if (num3 == 1539U)
				{
					if (num != 0U)
					{
						string msg = "Over voltage was detected on this device, please pass it to further PM debug";
						iHandleOvUv(msg);
					}
					else if (num2 != 0U)
					{
						string msg = "Under voltage was detected on this device, please pass it to further PM debug";
						iHandleOvUv(msg);
					}
				}
			}
			catch (Exception ex)
			{
				m_GuiManager.Error("OV & UV check threw an exception:\n" + ex.Message, ex.StackTrace);
			}
			finally
			{
				SetOvUvTimer(true);
			}
		}

		private void iHandleOvUv(string msg)
		{
			m_MainForm.SuspendAllActions();
			iPopOvUvMessage(msg);
		}

		private void iPopOvUvMessage(string msg)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(iPopOvUvMessage);
				base.Invoke(method, new object[]
				{
					msg
				});
				return;
			}
			GlobalRef.LuaWrapper.PrintError("[WLAN 18xx FW]: " + msg);
			MessageBox.Show(msg, GlobalRef.AppTitle);
		}

		private void m000025(object sender, EventArgs p1)
		{
			string text = iHandleBrowseFiles("FW", m_cboBSS_FwFile.Text);
			if (!string.IsNullOrEmpty(text))
			{
				iSetPathInCombo(text, m_cboBSS_FwFile);
			}
		}

		private void m000026(object sender, EventArgs p1)
		{
			string text = iHandleBrowseFiles("FW", m_cboMSS_FwFile.Text);
			if (!string.IsNullOrEmpty(text))
			{
				iSetPathInCombo(text, m_cboMSS_FwFile);
			}
		}

		private void m_btnCfg_File_Click(object sender, EventArgs p1)
		{
			string text = iHandleBrowseFiles("FW", m_cboCfg_File.Text);
			if (!string.IsNullOrEmpty(text))
			{
				iSetPathInCombo(text, m_cboCfg_File);
			}
		}

		private void m000027(object sender, EventArgs p1)
		{
			string text = iHandleBrowseFiles("FW", m_cboDSP_FwFile.Text);
			if (!string.IsNullOrEmpty(text))
			{
				iSetPathInCombo(text, m_cboDSP_FwFile);
			}
		}

		private void iRunPhySAControlScriptAsync()
		{
			new del_v_v(iRunPhySAControlScript).BeginInvoke(null, null);
		}

		private void iRunPhySAControlScript()
		{
			m_GuiManager.p000002.Execute(GuiOp.PhySAControl, null, false);
		}

		private void m_BSSReset_Click(object sender, EventArgs p1)
		{
		}

		private void label1_Click(object sender, EventArgs p1)
		{
		}

		private void label2_Click(object sender, EventArgs p1)
		{
		}

		private void m_cboBSS_FwFile_SelectedIndexChanged(object sender, EventArgs p1)
		{
		}

		private void m_cboFrefClock_SelectedIndexChanged(object sender, EventArgs p1)
		{
		}

		private void m_chkBssRom_CheckedChanged(object sender, EventArgs p1)
		{
		}

		private void m_chkUpdateIni_CheckedChanged(object sender, EventArgs p1)
		{
		}

		private int iSPIConnectDisconnect_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSPIConnectDisconnect_Gui(is_starting_op, is_ending_op);
		}

		public void iSPIConnectDisconnect()
		{
			iSPIConnectDisconnect_internal(true, false);
			m_MainForm.GuiOpEnd(true);
			SetRFPowerOffReadyState();
			ReSetSPIConnectReadyState();
		}

		public void ReSetSPIConnectReadyState()
		{
			m_btnSPIConct.ForeColor = Color.Black;
			m_btnSPIConct.BackColor = SystemColors.Control;
		}

		public void SetRFPowerOffReadyState()
		{
			m_btnEnblRf.BackColor = Color.FromArgb(55, 136, 255);
			m_btnEnblRf.ForeColor = Color.Black;
		}

		private void m_btnSPIConct_Click(object sender, EventArgs p1)
		{
			new del_v_v(iSPIConnectDisconnect).BeginInvoke(null, null);
		}

		public void m_btnSPIConnect()
		{
			new del_v_v(iSPIConnectDisconnect).BeginInvoke(null, null);
		}

		private int iRs232ConnectDisconnect_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iRs232ConnectDisconnect_Gui(is_starting_op, is_ending_op);
		}

		public void iRs232ConnectDisconnect()
		{
			iRs232ConnectDisconnect_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void m_btnRS232Conct_Click(object sender, EventArgs p1)
		{
			new del_v_v(iRs232ConnectDisconnect).BeginInvoke(null, null);
		}

		private bool iSPIEnableRf_Internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSPIEnableRf_Gui(is_starting_op, is_ending_op) == 0;
		}

		public void iSPIEnableRf()
		{
			iSPIEnableRf_Internal(true, false);
			m_MainForm.GuiOpEnd(true);
			ReSetRFPowerOffReadyState();
		}

		public void ReSetRFPowerOffReadyState()
		{
			m_btnEnblRf.ForeColor = Color.Black;
			m_btnEnblRf.BackColor = SystemColors.Control;
		}

		public void iSetEnblRfAsync()
		{
			new del_v_v(iSPIEnableRf).BeginInvoke(null, null);
		}

		private void m_btnEnblRf_Click(object sender, EventArgs p1)
		{
			iSetEnblRfAsync();
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
				m_MainForm.SetControlsWait(false);
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
				m_MainForm.SetControlsWait(true);
			}
		}

		public void iWarmResetInvoke()
		{
			m_GuiManager.ScriptOps.iWarmReset_Impl();
			m_MainForm.GuiOpEnd(true);
		}

		private void m_btnWarmRst_Click(object sender, EventArgs p1)
		{
			new del_v_v(iWarmResetInvoke).BeginInvoke(null, null);
		}

		public void iFullResetInvoke()
		{
			m_GuiManager.ScriptOps.iFullReset_Impl();
			m_MainForm.GuiOpEnd(true);
		}

		private void m_btnFullRst_Click(object sender, EventArgs p1)
		{
			new del_v_v(iFullResetInvoke).BeginInvoke(null, null);
			m_lblDevStatus.Text = "";
		}

		public void iSopChangeInvoke()
		{
			m_GuiManager.ScriptOps.iChangeSop_Impl();
			m_MainForm.GuiOpEnd(true);
			SetRS232ConnectReadyState();
			ReSetSOPReadyState();
			m_GuiManager.ScriptOps.IntializeTheChirpDefaultData();
			m_GuiManager.ScriptOps.IntializeTheProfileDefaultData();
			GlobalRef.g_TestSource = 0U;
		}

		public void ReSetSOPReadyState()
		{
			m_btnSetSop.ForeColor = Color.Black;
			m_btnSetSop.BackColor = SystemColors.Control;
		}

		private void m_btnSetSop_Click(object sender, EventArgs p1)
		{
			new del_v_v(iSopChangeInvoke).BeginInvoke(null, null);
		}

		public void SetRS232ConnectReadyState()
		{
			m_btnConnect.BackColor = Color.FromArgb(55, 136, 255);
			m_btnConnect.ForeColor = Color.Black;
		}

		public void iSetNErrorInvoke()
		{
			m_GuiManager.ScriptOps.iChangeSop_Impl();
			m_MainForm.GuiOpEnd(true);
		}

		private void m_btnNErrorIn_Click(object sender, EventArgs p1)
		{
			new del_v_v(iSetNErrorInvoke).BeginInvoke(null, null);
		}

		public void SpiSetMSSVersion()
		{
			byte[] array = new byte[4];
			byte[] array2 = new byte[4];
			for (int i = 0; i < 4; i++)
			{
				array[i] = (byte)(i + 1);
			}
			for (int j = 0; j < 4; j++)
			{
				array2[j] = (byte)(j + 1);
			}
			IntPtr value = GCHandle.Alloc(array, GCHandleType.Pinned).AddrOfPinnedObject();
			IntPtr value2 = GCHandle.Alloc(array2, GCHandleType.Pinned).AddrOfPinnedObject();
			uint memAddr = 72U;
			uint memAddr2 = 76U;
			int num = 0;
			int num2 = (int)GlobalRef.g_RadarDeviceId;
			do
			{
				if ((num2 & 1 << num) != 0)
				{
					Imports.RadarLinkImpl_GetInternalCfg(1U << num, memAddr, value);
					Thread.Sleep(200);
					if (Imports.RadarLinkImpl_GetInternalCfg(1U << num, memAddr2, value2) == 0)
					{
						Array.Reverse(array, 0, 4);
						BitConverter.ToString(array).Replace("-", string.Empty);
						Array.Reverse(array2, 0, 4);
						BitConverter.ToString(array2).Replace("-", string.Empty);
						string mssVer = string.Format("{3:d1}.{2:d1}.{1:d1}.{0:d1} ({6:d2}/{5:d2}/{4:d2})", new object[]
						{
							int.Parse(array[0].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array[1].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array[2].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array[3].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array2[3].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array2[2].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array2[1].ToString("X"), NumberStyles.HexNumber)
						});
						setMssFwVersion(1U << num, mssVer);
					}
					num2 &= ~(1 << num);
				}
				num++;
			}
			while (num2 != 0);
		}

		public void SpiSetBSSVersion()
		{
			byte[] array = new byte[4];
			byte[] array2 = new byte[4];
			for (int i = 0; i < 4; i++)
			{
				array[i] = (byte)(i + 1);
			}
			for (int j = 0; j < 4; j++)
			{
				array2[j] = (byte)(j + 1);
			}
			IntPtr value = GCHandle.Alloc(array, GCHandleType.Pinned).AddrOfPinnedObject();
			IntPtr value2 = GCHandle.Alloc(array2, GCHandleType.Pinned).AddrOfPinnedObject();
			uint memAddr = 1073741896U;
			uint memAddr2 = 1073741900U;
			int num = 0;
			int num2 = (int)GlobalRef.g_RadarDeviceId;
			do
			{
				if ((num2 & 1 << num) != 0)
				{
					Imports.RadarLinkImpl_GetInternalCfg(1U << num, memAddr, value);
					Thread.Sleep(200);
					if (Imports.RadarLinkImpl_GetInternalCfg(1U << num, memAddr2, value2) == 0)
					{
						Array.Reverse(array, 0, 4);
						BitConverter.ToString(array).Replace("-", string.Empty);
						Array.Reverse(array2, 0, 4);
						BitConverter.ToString(array2).Replace("-", string.Empty);
						string bssVer = string.Format("{3:d1}.{2:d1}.{1:d1}.{0:d1} ({6:d2}/{5:d2}/{4:d2})", new object[]
						{
							int.Parse(array[0].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array[1].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array[2].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array[3].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array2[3].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array2[2].ToString("X"), NumberStyles.HexNumber),
							int.Parse(array2[1].ToString("X"), NumberStyles.HexNumber)
						});
						setBssFwVersion(1U << num, bssVer);
					}
					num2 &= ~(1 << num);
				}
				num++;
			}
			while (num2 != 0);
		}

		public uint iGetVal(string candidate)
		{
			int[] array = candidate.Split(new char[]
			{
				'-'
			}).Select(new Func<string, int>(ConnectTab.c00026e.f00019e.m000032)).ToArray<int>();
			uint value;
			iConvertHexTextToUInt(new TextBox
			{
				Text = array.ToString()
			}, out value);
			return ReverseBytes(value);
		}

		public static string Reverse(string p0)
		{
			char[] array = p0.ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		private bool iConvertTextToUInt(string textVal, out uint uint_val)
		{
			uint_val = 0U;
			return uint.TryParse(textVal.ToLower(), NumberStyles.HexNumber, null, out uint_val);
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

		private uint iGetBitsRange(uint val, uint start_bit, uint end_bit)
		{
			ulong num = (1UL << (int)(end_bit - start_bit + 1U)) - 1UL;
			return (uint)((ulong)(val >> (int)start_bit) & num);
		}

		private bool iBitValidation(uint start_bit, uint end_bit)
		{
			uint num = 31U;
			if (0U > start_bit || num < end_bit)
			{
				GlobalRef.GuiManager.Error("wrong start bit");
				return false;
			}
			if (start_bit > end_bit || end_bit > num)
			{
				GlobalRef.GuiManager.Error("wrong end bit");
				return false;
			}
			return true;
		}

		private void m_btnAbort_Click(object sender, EventArgs p1)
		{
			m_GuiManager.p000002.AbortGuiOpThread();
		}

		public void iSetFwVerInvoke()
		{
			if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex] && GlobalRef.g_SOPMode4Set == 0U && GlobalRef.g_SOPMode7Set == 0U)
			{
				SetMSSVersions();
				SetBSSVersions();
				return;
			}
			if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
			{
				SpiSetMSSVersion();
				m_GuiManager.ScriptOps.SpiSetMSSPatchVersion();
				SpiSetBSSVersion();
				m_GuiManager.ScriptOps.SpiSetBSSPatchVersion();
			}
		}

		public void setMssPatchFwVersion(uint deviceMap, string mssPatchVer)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(setMssPatchFwVersion);
				base.Invoke(method, new object[]
				{
					deviceMap,
					mssPatchVer
				});
				return;
			}
			if ((deviceMap & 1U) == 1U)
			{
				m_lblMSSPatchFwVersion.Text = mssPatchVer;
				return;
			}
			if ((deviceMap & 2U) == 2U)
			{
				m_lblRadarDev2MSSPatchFwVersion.Text = mssPatchVer;
				return;
			}
			if ((deviceMap & 4U) == 4U)
			{
				m_lblRadarDev3MSSPatchFwVersion.Text = mssPatchVer;
				return;
			}
			if ((deviceMap & 8U) == 8U)
			{
				m_lblRadarDev4MSSPatchFwVersion.Text = mssPatchVer;
			}
		}

		public void setBssPatchFwVersion(uint deviceMap, string bssPatchVer)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(setBssPatchFwVersion);
				base.Invoke(method, new object[]
				{
					deviceMap,
					bssPatchVer
				});
				return;
			}
			if ((deviceMap & 1U) == 1U)
			{
				m_lblBSSPatchFwVersion.Text = bssPatchVer;
				return;
			}
			if ((deviceMap & 2U) == 2U)
			{
				m_lblRadarDev2BSSPatchFwVersion.Text = bssPatchVer;
				return;
			}
			if ((deviceMap & 4U) == 4U)
			{
				m_lblRadarDev3BSSPatchFwVersion.Text = bssPatchVer;
				return;
			}
			if ((deviceMap & 8U) == 8U)
			{
				m_lblRadarDev4BSSPatchFwVersion.Text = bssPatchVer;
			}
		}

		private void m_btnFlash_Click(object sender, EventArgs p1)
		{
			new del_v_v(iFlashProgram).BeginInvoke(null, null);
		}

		public void UpdateFlashInfo(uint com_port, string metaImagePath, bool eraseOnly)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s_b method = new del_v_i_s_b(UpdateFlashInfo);
				base.Invoke(method, new object[]
				{
					com_port,
					metaImagePath,
					eraseOnly
				});
				return;
			}
			m_cboBSS_FwFile.Text = metaImagePath;
			m_ConnectParams.ComPort = (int)com_port;
			m_BSSCheck.Checked = !eraseOnly;
		}

		public void iFlashProgram()
		{
			m_GuiManager.Log("Flash Program Started...");
			Connection connection = GuiSettings.Default.Connection;
			string directoryName = Path.GetDirectoryName(Application.StartupPath);
			string text = string.Concat(new string[]
			{
				directoryName + "\\FlashProgrammer\\XWR1xxx_Package.txt"
			});
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			File.Create(text).Dispose();
			using (TextWriter textWriter = new StreamWriter(text))
			{
				textWriter.WriteLine("FORMAT,SFLASH");
				if (m_BSSCheck.Checked)
				{
					textWriter.WriteLine(GetPhyFwPath() + ",BSS_BUILD,SFLASH\n");
				}
				if (m_MSSCheck.Checked)
				{
					textWriter.WriteLine(GetMacFwPath() + ",MSS_BUILD,SFLASH\n");
				}
				if (m_CfgFileCheck.Checked)
				{
					textWriter.WriteLine(GetCfgFwPath() + ",CONFIG_INFO,SFLASH\n");
				}
				if (m_DSPCheck.Checked)
				{
					textWriter.WriteLine(GetDSPFwPath() + ",DSP_BUILD,SFLASH\n");
				}
				textWriter.Close();
			}
			string text2;
			if (m_BSSCheck.Checked)
			{
				text2 = "false";
			}
			else
			{
				text2 = "true";
			}
			if (m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected <= 1)
			{
				string full_command = string.Format("ar1.FlashProgram({0}, {1}, \"{2}\")", new object[]
				{
					m_ConnectParams.ComPort,
					text2,
					GetPhyFwPath()
				});
				m_GuiManager.RecordLog(15, full_command);
			}
			else
			{
				string full_command2 = string.Format("ar1.FlashProgram_mult({0}, {1}, {2}, \"{3}\")", new object[]
				{
					GlobalRef.g_RadarDeviceId,
					m_ConnectParams.ComPort,
					text2,
					GetPhyFwPath()
				});
				m_GuiManager.RecordLog(15, full_command2);
			}
			Process process = new Process();
			process.StartInfo.FileName = directoryName + "\\FlashProgrammer\\mmwaveprog_cmdline.exe";
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.RedirectStandardOutput = false;
			int num;
			if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
			{
				num = m_ConnectParams.ComPort;
			}
			else
			{
				num = GlobalRef.g_RS232ComPort[(int)GlobalRef.g_RadarDeviceIndex];
			}
			SerialPort.GetPortNames();
			process.StartInfo.Arguments = string.Concat(new object[]
			{
				" -p ",
				num,
				" -b \"",
				text,
				"\""
			});
			process.EnableRaisingEvents = true;
			process.StartInfo.WorkingDirectory = "D:\\";
			process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
			process.Start();
			int num2 = 0;
			while (num2 < 10 && !process.HasExited)
			{
				process.Refresh();
				Console.WriteLine("Physical Memory Usage: " + process.WorkingSet.ToString());
				Thread.Sleep(5000);
				num2++;
			}
			process.WaitForExit();
			process.Close();
			m_GuiManager.Log("Flash Program completed!");
		}

		private void m_lblGuiVersion_Click(object sender, EventArgs p1)
		{
		}

		private void m_btnCfg_FileLoad_Click(object sender, EventArgs p1)
		{
		}

		private void m_cboCRC_SelectedIndexChanged(object sender, EventArgs p1)
		{
		}

		private void m_btnSetSop4_Click(object sender, EventArgs p1)
		{
			if (m_cboSopMod.SelectedIndex == 1)
			{
				m_btnFullRst.Visible = true;
			}
			else
			{
				m_btnFullRst.Visible = false;
			}
			if (m_cboSopMod.SelectedIndex == 2)
			{
				m_btnFlash.Visible = false;
				m_btnFlash.Enabled = true;
				return;
			}
			m_btnFlash.Enabled = false;
		}

		private void m_btnRS232ConnectStatus_TextChanged(object sender, EventArgs p1)
		{
			if (m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected == 1)
			{
				if (m_btnConnect.Text == "Disconnect (2)")
				{
					f000196.Text = "Connected";
					f000196.ForeColor = Color.Green;
					return;
				}
				f000196.Text = "Disconnected";
				f000196.ForeColor = Color.Red;
				return;
			}
			else if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				if (m_btnConnect.Text == "Disconnect (2)")
				{
					f000196.Text = "Connected";
					f000196.ForeColor = Color.Green;
					return;
				}
				f000196.Text = "Disconnected";
				f000196.ForeColor = Color.Red;
				return;
			}
			else if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				if (m_btnConnect.Text == "Disconnect (2)")
				{
					f000199.Text = "Connected";
					f000199.ForeColor = Color.Green;
					return;
				}
				f000199.Text = "Disconnected";
				f000199.ForeColor = Color.Red;
				return;
			}
			else
			{
				if ((GlobalRef.g_RadarDeviceId & 4U) != 4U)
				{
					if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
					{
						if (m_btnConnect.Text == "Disconnect (2)")
						{
							f000197.Text = "Connected";
							f000197.ForeColor = Color.Green;
							return;
						}
						f000197.Text = "Disconnected";
						f000197.ForeColor = Color.Red;
					}
					return;
				}
				if (m_btnConnect.Text == "Disconnect (2)")
				{
					f000198.Text = "Connected";
					f000198.ForeColor = Color.Green;
					return;
				}
				f000198.Text = "Disconnected";
				f000198.ForeColor = Color.Red;
				return;
			}
		}

		private void m_btnSPIConnectStatus_TextChanged(object sender, EventArgs p1)
		{
			if (m_btnSPIConct.Text == "SPI Disconnect (5)")
			{
				m_lblSPIConnectivityStatus.Text = "Connected";
				m_lblSPIConnectivityStatus.ForeColor = Color.Green;
				return;
			}
			m_lblSPIConnectivityStatus.Text = "Disconnected";
			m_lblSPIConnectivityStatus.ForeColor = Color.Red;
		}

		private void m_btnRadarDev2RefreshPorts_Click(object sender, EventArgs p1)
		{
			iFillRadarDev2ComPortCombo();
		}

		private void m_btnRefreshNoOfDevices_Click(object sender, EventArgs p1)
		{
			UpdateNumberOfRadarDevicesDetected();
		}

		public void EnableDisableConnectComponentsForCascade(bool status)
		{
			if (base.InvokeRequired)
			{
				del_v_b method = new del_v_b(EnableDisableConnectComponentsForCascade);
				base.Invoke(method, new object[]
				{
					status
				});
				return;
			}
			m_grpSettings.Enabled = status;
		}

		public void EnableDisbleRS232OperationsWithRespectiveRadarDevices()
		{
			m_grpSettings.Visible = true;
			m_grpRadarDev2RS232OpSettings.Visible = false;
			m_grpRadarDev3RS232OpSettings.Visible = false;
			m_grpRadarDev4RS232OpSettings.Visible = false;
			m_grpRadarMultiDevicesRS232OpSetting.Visible = false;
			m_MainForm.RadarDeviceSelection((uint)m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected);
		}

		public void EnableDisbleRadarDeviceStatusWithRespectiveRadarDevices()
		{
			if (m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected == 1)
			{
				m_grpRadarDev2StatusSettings.Visible = false;
				m_grpRadarDev3StatusSettings.Visible = false;
				m_grpRadarDev4StatusSettings.Visible = false;
				m_lblConnectivityRadarDev2Status.Visible = false;
				f000199.Visible = false;
				m_lblRadarDev2SPIConnectivityStatus.Visible = false;
				m_lblDev2Status.Visible = false;
				m_lblRadarDev2PHYFwVersion.Visible = false;
				m_lblRadarDev2MacFwVersion.Visible = false;
				m_lblConnectivityRadarDev3Status.Visible = false;
				f000198.Visible = false;
				m_lblRadarDev3SPIConnectivityStatus.Visible = false;
				m_lblDev3Status.Visible = false;
				m_lblRadarDev3PHYFwVersion.Visible = false;
				m_lblRadarDev3MacFwVersion.Visible = false;
				m_lblConnectivityRadarDev4Status.Visible = false;
				f000197.Visible = false;
				m_lblRadarDev4SPIConnectivityStatus.Visible = false;
				m_lblDev4Status.Visible = false;
				m_lblRadarDev4PHYFwVersion.Visible = false;
				m_lblRadarDev4MacFwVersion.Visible = false;
				return;
			}
			if (m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected == 2)
			{
				m_grpRadarDev2StatusSettings.Visible = true;
				m_grpRadarDev3StatusSettings.Visible = false;
				m_grpRadarDev4StatusSettings.Visible = false;
				m_lblConnectivityRadarDev2Status.Visible = true;
				f000199.Visible = true;
				m_lblRadarDev2SPIConnectivityStatus.Visible = true;
				m_lblDev2Status.Visible = true;
				m_lblRadarDev2PHYFwVersion.Visible = true;
				m_lblRadarDev2MacFwVersion.Visible = true;
				m_lblConnectivityRadarDev3Status.Visible = false;
				f000198.Visible = false;
				m_lblRadarDev3SPIConnectivityStatus.Visible = false;
				m_lblDev3Status.Visible = false;
				m_lblRadarDev3PHYFwVersion.Visible = false;
				m_lblRadarDev3MacFwVersion.Visible = false;
				m_lblConnectivityRadarDev4Status.Visible = false;
				f000197.Visible = false;
				m_lblRadarDev4SPIConnectivityStatus.Visible = false;
				m_lblDev4Status.Visible = false;
				m_lblRadarDev4PHYFwVersion.Visible = false;
				m_lblRadarDev4MacFwVersion.Visible = false;
				return;
			}
			if (m_RadarDeviceModeConfigParams.NumberOfRadarDevicesDetected == 4)
			{
				m_grpRadarDev2StatusSettings.Visible = true;
				m_grpRadarDev3StatusSettings.Visible = true;
				m_grpRadarDev4StatusSettings.Visible = true;
				m_lblConnectivityRadarDev2Status.Visible = true;
				f000199.Visible = true;
				m_lblRadarDev2SPIConnectivityStatus.Visible = true;
				m_lblDev2Status.Visible = true;
				m_lblRadarDev2PHYFwVersion.Visible = true;
				m_lblRadarDev2MacFwVersion.Visible = true;
				m_lblConnectivityRadarDev3Status.Visible = true;
				f000198.Visible = true;
				m_lblRadarDev3SPIConnectivityStatus.Visible = true;
				m_lblDev3Status.Visible = true;
				m_lblRadarDev3PHYFwVersion.Visible = true;
				m_lblRadarDev3MacFwVersion.Visible = true;
				m_lblConnectivityRadarDev4Status.Visible = true;
				f000197.Visible = true;
				m_lblRadarDev4SPIConnectivityStatus.Visible = true;
				m_lblDev4Status.Visible = true;
				m_lblRadarDev4PHYFwVersion.Visible = true;
				m_lblRadarDev4MacFwVersion.Visible = true;
				return;
			}
			m_grpRadarDev2StatusSettings.Visible = false;
			m_grpRadarDev3StatusSettings.Visible = false;
			m_grpRadarDev4StatusSettings.Visible = false;
			m_lblConnectivityRadarDev2Status.Visible = false;
			f000199.Visible = false;
			m_lblRadarDev2SPIConnectivityStatus.Visible = false;
			m_lblDev2Status.Visible = false;
			m_lblRadarDev2PHYFwVersion.Visible = false;
			m_lblRadarDev2MacFwVersion.Visible = false;
			m_lblConnectivityRadarDev3Status.Visible = false;
			f000198.Visible = false;
			m_lblRadarDev3SPIConnectivityStatus.Visible = false;
			m_lblDev3Status.Visible = false;
			m_lblRadarDev3PHYFwVersion.Visible = false;
			m_lblRadarDev3MacFwVersion.Visible = false;
			m_lblConnectivityRadarDev4Status.Visible = false;
			f000197.Visible = false;
			m_lblRadarDev4SPIConnectivityStatus.Visible = false;
			m_lblDev4Status.Visible = false;
			m_lblRadarDev4PHYFwVersion.Visible = false;
			m_lblRadarDev4MacFwVersion.Visible = false;
		}

		public void EnableDisbleRadarDeviceStatus(int rDeviceID)
		{
			if (rDeviceID == 1)
			{
				if (GlobalRef.g_StudioInit)
				{
					m_grpRadarDev2StatusSettings.Visible = false;
					GlobalRef.g_StudioInit = false;
				}
				else
				{
					m_grpRadarDev2StatusSettings.Visible = true;
					m_btnAddDevice2SPIConct.Visible = true;
					m_btnEnblRfDevice2.Visible = true;
				}
				m_grpRadarDev3StatusSettings.Visible = false;
				m_grpRadarDev4StatusSettings.Visible = false;
				m_lblConnectivityRadarDev2Status.Visible = true;
				f000199.Visible = true;
				m_lblRadarDev2SPIConnectivityStatus.Visible = true;
				m_lblDev2Status.Visible = true;
				m_lblRadarDev2PHYFwVersion.Visible = true;
				m_lblRadarDev2MacFwVersion.Visible = true;
				m_lblConnectivityRadarDev3Status.Visible = false;
				f000198.Visible = false;
				m_lblRadarDev3SPIConnectivityStatus.Visible = false;
				m_lblDev3Status.Visible = false;
				m_lblRadarDev3PHYFwVersion.Visible = false;
				m_lblRadarDev3MacFwVersion.Visible = false;
				m_lblConnectivityRadarDev4Status.Visible = false;
				f000197.Visible = false;
				m_lblRadarDev4SPIConnectivityStatus.Visible = false;
				m_lblDev4Status.Visible = false;
				m_lblRadarDev4PHYFwVersion.Visible = false;
				m_lblRadarDev4MacFwVersion.Visible = false;
				m_btnAddDevice3SPIConct.Visible = false;
				m_btnEnblRfDevice3.Visible = false;
				m_btnAddDevice4SPIConct.Visible = false;
				m_btnEnblRfDevice4.Visible = false;
				return;
			}
			if (rDeviceID == 2)
			{
				m_grpRadarDev2StatusSettings.Visible = true;
				m_grpRadarDev3StatusSettings.Visible = true;
				m_grpRadarDev4StatusSettings.Visible = true;
				m_lblConnectivityRadarDev2Status.Visible = true;
				f000199.Visible = true;
				m_lblRadarDev2SPIConnectivityStatus.Visible = true;
				m_lblDev2Status.Visible = true;
				m_lblRadarDev2PHYFwVersion.Visible = true;
				m_lblRadarDev2MacFwVersion.Visible = true;
				m_lblConnectivityRadarDev3Status.Visible = true;
				f000198.Visible = true;
				m_lblRadarDev3SPIConnectivityStatus.Visible = true;
				m_lblDev3Status.Visible = true;
				m_lblRadarDev3PHYFwVersion.Visible = true;
				m_lblRadarDev3MacFwVersion.Visible = true;
				m_lblConnectivityRadarDev4Status.Visible = true;
				f000197.Visible = true;
				m_lblRadarDev4SPIConnectivityStatus.Visible = true;
				m_lblDev4Status.Visible = true;
				m_lblRadarDev4PHYFwVersion.Visible = true;
				m_lblRadarDev4MacFwVersion.Visible = true;
				m_btnAddDevice2SPIConct.Visible = true;
				m_btnEnblRfDevice2.Visible = true;
				m_btnAddDevice3SPIConct.Visible = true;
				m_btnEnblRfDevice3.Visible = true;
				m_btnAddDevice4SPIConct.Visible = true;
				m_btnEnblRfDevice4.Visible = true;
				return;
			}
			m_grpRadarDev2StatusSettings.Visible = false;
			m_grpRadarDev3StatusSettings.Visible = false;
			m_grpRadarDev4StatusSettings.Visible = false;
			m_lblConnectivityRadarDev2Status.Visible = false;
			f000199.Visible = false;
			m_lblRadarDev2SPIConnectivityStatus.Visible = false;
			m_lblDev2Status.Visible = false;
			m_lblRadarDev2PHYFwVersion.Visible = false;
			m_lblRadarDev2MacFwVersion.Visible = false;
			m_lblConnectivityRadarDev3Status.Visible = false;
			f000198.Visible = false;
			m_lblRadarDev3SPIConnectivityStatus.Visible = false;
			m_lblDev3Status.Visible = false;
			m_lblRadarDev3PHYFwVersion.Visible = false;
			m_lblRadarDev3MacFwVersion.Visible = false;
			m_lblConnectivityRadarDev4Status.Visible = false;
			f000197.Visible = false;
			m_lblRadarDev4SPIConnectivityStatus.Visible = false;
			m_lblDev4Status.Visible = false;
			m_lblRadarDev4PHYFwVersion.Visible = false;
			m_lblRadarDev4MacFwVersion.Visible = false;
		}

		private int iRadarDevice2SPIConnectDisconnect_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iRadarDevice2SPIConnectDisconnect_Gui(is_starting_op, is_ending_op);
		}

		public void iRadarDevice2SPIConnectDisconnect()
		{
			iRadarDevice2SPIConnectDisconnect_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void m_btnAddDevice2SPIConct_Click(object sender, EventArgs p1)
		{
			new del_v_v(iRadarDevice2SPIConnectDisconnect).BeginInvoke(null, null);
		}

		private int iRadarDevice3SPIConnectDisconnect_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iRadarDevice3SPIConnectDisconnect_Gui(is_starting_op, is_ending_op);
		}

		public void iRadarDevice3SPIConnectDisconnect()
		{
			iRadarDevice3SPIConnectDisconnect_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void m_btnAddDevice3SPIConct_Click(object sender, EventArgs p1)
		{
			new del_v_v(iRadarDevice3SPIConnectDisconnect).BeginInvoke(null, null);
		}

		private int iRadarDevice4SPIConnectDisconnect_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iRadarDevice4SPIConnectDisconnect_Gui(is_starting_op, is_ending_op);
		}

		public void iRadarDevice4SPIConnectDisconnect()
		{
			iRadarDevice4SPIConnectDisconnect_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void m_btnAddDevice4SPIConct_Click(object sender, EventArgs p1)
		{
			new del_v_v(iRadarDevice4SPIConnectDisconnect).BeginInvoke(null, null);
		}

		public void UpdateCRCandAck()
		{
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_chkAck.Enabled = true;
				f000192.Enabled = true;
				m_cboCRC.Enabled = true;
				return;
			}
			m_chkAck.Enabled = false;
			f000192.Enabled = false;
			m_cboCRC.Enabled = false;
		}

		public void EnableDisableRadarDeviceSystem()
		{
			if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
			{
				m_chkAck.Enabled = true;
				f000192.Enabled = true;
				m_cboCRC.Enabled = true;
				return;
			}
			m_chkAck.Enabled = false;
			f000192.Enabled = false;
			m_cboCRC.Enabled = false;
		}

		public void UpdateSPIConnectDevice()
		{
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_btnSPIConct.Enabled = true;
			}
			else
			{
				m_btnSPIConct.Enabled = false;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_btnAddDevice2SPIConct.Enabled = true;
			}
			else
			{
				m_btnAddDevice2SPIConct.Enabled = false;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				m_btnAddDevice3SPIConct.Enabled = true;
			}
			else
			{
				m_btnAddDevice3SPIConct.Enabled = false;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				m_btnAddDevice4SPIConct.Enabled = true;
				return;
			}
			m_btnAddDevice4SPIConct.Enabled = false;
		}

		public void UpdateRFPowerUpDevice()
		{
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				m_btnEnblRf.Enabled = true;
			}
			else
			{
				m_btnEnblRf.Enabled = false;
			}
			if ((GlobalRef.g_RadarDeviceId & 2U) == 2U)
			{
				m_btnEnblRfDevice2.Enabled = true;
			}
			else
			{
				m_btnEnblRfDevice2.Enabled = false;
			}
			if ((GlobalRef.g_RadarDeviceId & 4U) == 4U)
			{
				m_btnEnblRfDevice3.Enabled = true;
			}
			else
			{
				m_btnEnblRfDevice3.Enabled = false;
			}
			if ((GlobalRef.g_RadarDeviceId & 8U) == 8U)
			{
				m_btnEnblRfDevice4.Enabled = true;
				return;
			}
			m_btnEnblRfDevice4.Enabled = false;
		}

		private void m_btnDevice2RS232ConnectStatus_TextChanged(object sender, EventArgs p1)
		{
			if (m_btnRadarDev2Connect.Text == "Disconnect")
			{
				f000199.Text = "Connected";
				f000199.ForeColor = Color.Green;
				return;
			}
			f000199.Text = "Disconnected";
			f000199.ForeColor = Color.Red;
		}

		private void m_btnDevice3RS232ConnectStatus_TextChanged(object sender, EventArgs p1)
		{
		}

		private void m_btnDevice4RS232ConnectStatus_TextChanged(object sender, EventArgs p1)
		{
		}

		private void m_btnRadarSDevice2SPIConnectStatus_TextChanged(object sender, EventArgs p1)
		{
			if (m_btnAddDevice2SPIConct.Text == "SPI Disconnect (2)")
			{
				m_lblRadarDev2SPIConnectivityStatus.Text = "Connected";
				m_lblRadarDev2SPIConnectivityStatus.ForeColor = Color.Green;
				return;
			}
			m_lblRadarDev2SPIConnectivityStatus.Text = "Disconnected";
			m_lblRadarDev2SPIConnectivityStatus.ForeColor = Color.Red;
		}

		private void m_btnRadarSDevice3SPIConnectStatus_TextChanged(object sender, EventArgs p1)
		{
			if (m_btnAddDevice3SPIConct.Text == "SPI Disconnect (3)")
			{
				m_lblRadarDev3SPIConnectivityStatus.Text = "Connected";
				m_lblRadarDev3SPIConnectivityStatus.ForeColor = Color.Green;
				return;
			}
			m_lblRadarDev3SPIConnectivityStatus.Text = "Disconnected";
			m_lblRadarDev3SPIConnectivityStatus.ForeColor = Color.Red;
		}

		private void m_btnRadarSDevice4SPIConnectStatus_TextChanged(object sender, EventArgs p1)
		{
			if (m_btnAddDevice4SPIConct.Text == "SPI Disconnect (4)")
			{
				m_lblRadarDev4SPIConnectivityStatus.Text = "Connected";
				m_lblRadarDev4SPIConnectivityStatus.ForeColor = Color.Green;
				return;
			}
			m_lblRadarDev4SPIConnectivityStatus.Text = "Disconnected";
			m_lblRadarDev4SPIConnectivityStatus.ForeColor = Color.Red;
		}

		private bool iSPIEnableRfDevice2_Internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSPIEnableRfDevice2_Gui(is_starting_op, is_ending_op) == 0;
		}

		private void iSPIEnableRfDevice2()
		{
			iSPIEnableRfDevice2_Internal(true, false);
			m_MainForm.GuiOpEnd(true);
			ReSetRFPowerOffDevice2ReadyState();
		}

		public void ReSetRFPowerOffDevice2ReadyState()
		{
		}

		private void iSetEnblRfDevice2Async()
		{
			new del_v_v(iSPIEnableRfDevice2).BeginInvoke(null, null);
		}

		private void m_btnEnblRfDevice2_Click(object sender, EventArgs p1)
		{
			iSetEnblRfDevice2Async();
		}

		private bool iSPIEnableRfDevice3_Internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSPIEnableRfDevice3_Gui(is_starting_op, is_ending_op) == 0;
		}

		private void iSPIEnableRfDevice3()
		{
			iSPIEnableRfDevice3_Internal(true, false);
			m_MainForm.GuiOpEnd(true);
			ReSetRFPowerOffDevice3ReadyState();
		}

		public void ReSetRFPowerOffDevice3ReadyState()
		{
		}

		private void iSetEnblRfDevice3Async()
		{
			new del_v_v(iSPIEnableRfDevice3).BeginInvoke(null, null);
		}

		private void m_btnEnblRfDevice3_Click(object sender, EventArgs p1)
		{
			iSetEnblRfDevice3Async();
		}

		private bool iSPIEnableRfDevice4_Internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSPIEnableRfDevice4_Gui(is_starting_op, is_ending_op) == 0;
		}

		private void iSPIEnableRfDevice4()
		{
			iSPIEnableRfDevice4_Internal(true, false);
			m_MainForm.GuiOpEnd(true);
			ReSetRFPowerOffDevice4ReadyState();
		}

		public void ReSetRFPowerOffDevice4ReadyState()
		{
		}

		private void iSetEnblRfDevice4Async()
		{
			new del_v_v(iSPIEnableRfDevice4).BeginInvoke(null, null);
		}

		private void m_btnEnblRfDevice4_Click(object sender, EventArgs p1)
		{
			iSetEnblRfDevice4Async();
		}

		private bool iTempSensorGet_Internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iTemperatureSensorData_Gui(is_starting_op, is_ending_op) == 0;
		}

		private void iTempSensorGet()
		{
			iTempSensorGet_Internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		private void iTempSensorGetAsync()
		{
			new del_v_v(iTempSensorGet).BeginInvoke(null, null);
		}

		private void m_btnTempSensorGet_Click(object sender, EventArgs p1)
		{
			iTempSensorGetAsync();
		}

		public void DispalyTopNearRx1TempSensValueinGUI(string TopNearRx1TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(DispalyTopNearRx1TempSensValueinGUI);
				base.Invoke(method, new object[]
				{
					TopNearRx1TempSens
				});
				return;
			}
			m_lblTopNearRX1.Text = TopNearRx1TempSens;
		}

		public void DispalyBottomNearTx2TempSensValueinGUI(string BottomNearTx2)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(DispalyBottomNearTx2TempSensValueinGUI);
				base.Invoke(method, new object[]
				{
					BottomNearTx2
				});
				return;
			}
			m_lblBottomNearTX2.Text = BottomNearTx2;
		}

		public void DispalyBottomNearRx1TempSensValueinGUI(string BottomNearRx1)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(DispalyBottomNearRx1TempSensValueinGUI);
				base.Invoke(method, new object[]
				{
					BottomNearRx1
				});
				return;
			}
			m_lblBottomNearRX1.Text = BottomNearRx1;
		}

		public void DispalyTopNearTx3TempSensValueinGUI(string TopNearTx3)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(DispalyTopNearTx3TempSensValueinGUI);
				base.Invoke(method, new object[]
				{
					TopNearTx3
				});
				return;
			}
			m_lblTopNearTX3.Text = TopNearTx3;
		}

		private void m_btnRadarDev3RefreshPorts_Click(object sender, EventArgs p1)
		{
			iFillRadarDev3ComPortCombo();
		}

		private void m_btnRadarDev4RefreshPorts_Click(object sender, EventArgs p1)
		{
			iFillRadarDev4ComPortCombo();
		}

		private void ConnectTab_Load(object sender, EventArgs p1)
		{
		}

		public string iEnableCaptureCardResetSetUp()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(iEnableCaptureCardResetSetUp);
				return (string)base.Invoke(method);
			}
			m_btnFlash.Visible = false;
			m_grpSOPControl.Text = "SOP Control";
			m_lblSOPMode.Text = "SOP Mode";
			m_lblSOPNote.Visible = false;
			m_cboSopMod.Visible = true;
			return "DCA1000Enabled";
		}

		public string iDisableCaptureCardResetSetUp()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(iDisableCaptureCardResetSetUp);
				return (string)base.Invoke(method);
			}
			m_btnFlash.Visible = false;
			m_grpSOPControl.Text = "Reset Control";
			m_lblSOPMode.Text = "Reset";
			m_lblSOPNote.Visible = true;
			m_cboSopMod.Visible = false;
			return "DCA1000Enabled";
		}

		private void SixtyGHzRadarDevice_CheckedChanged(object sender, EventArgs p1)
		{
			if (m_RadioBtn60GHzRadarDev.Checked)
			{
				GlobalRef.g_ARDeviceOperateFreq60GHz = true;
				m_GuiManager.ScriptOps.iConfigProfileStartFreMinAndMax_Gui();
			}
		}

		private void SeventyGHzRadarDevice_CheckedChanged(object sender, EventArgs p1)
		{
			if (m_RadioBtn77GHzRadarDev.Checked)
			{
				GlobalRef.g_ARDeviceOperateFreq60GHz = false;
				m_GuiManager.ScriptOps.iConfigProfileStartFreMinAndMax_Gui();
			}
		}

		private void m000028(object sender, EventArgs p1)
		{
			selectAR6843DeviceVariant();
		}

		private void m000029(object sender, EventArgs p1)
		{
			selectAR1843DeviceVariant();
		}

		private void m00002a(object sender, EventArgs p1)
		{
			m00002e();
		}

		private void m00002b(object sender, EventArgs p1)
		{
			m00002f();
		}

		private void m00002c(object sender, EventArgs p1)
		{
			m000030();
		}

		public int SelectDeviceVariantForFwDownload(string DeviceName)
		{
			int result = 0;
			if (DeviceName == "XWR1243")
			{
				f00019a.Checked = true;
				return result;
			}
			if (DeviceName == "XWR1443")
			{
				f00019b.Checked = true;
				return result;
			}
			if (DeviceName == "XWR1642")
			{
				f00019c.Checked = true;
				return result;
			}
			if (DeviceName == "XWR1843")
			{
				m_RadioBtnxWR1843.Checked = true;
				return result;
			}
			if (DeviceName == "IWR6843")
			{
				m_RadioBtnxWR6843.Checked = true;
			}
			return result;
		}

		public int GetDeviceVariant(out string DeviceName)
		{
			int result = 0;
			if (f00019a.Checked)
			{
				DeviceName = "XWR1243";
				return result;
			}
			if (f00019b.Checked)
			{
				DeviceName = "XWR1443";
				return result;
			}
			if (f00019c.Checked)
			{
				DeviceName = "XWR1642";
				return result;
			}
			if (m_RadioBtnxWR1843.Checked)
			{
				DeviceName = "XWR1843";
				return result;
			}
			if (m_RadioBtnxWR6843.Checked)
			{
				DeviceName = "IWR6843";
				return result;
			}
			DeviceName = "UNKNOWN";
			return result;
		}

		public int ConfigureDeviceOperateFreqinGHz_Gui()
		{
			if (GlobalRef.g_ARDeviceOperateFreq60GHz)
			{
				m_RadioBtn60GHzRadarDev.Checked = true;
				m_RadioBtn77GHzRadarDev.Checked = false;
			}
			else
			{
				m_RadioBtn77GHzRadarDev.Checked = true;
				m_RadioBtn60GHzRadarDev.Checked = false;
			}
			return 0;
		}

		public int m00002d()
		{
			if (f00019d.Checked)
			{
				if (GlobalRef.g_ARDeviceOperateFreq60GHz)
				{
					string msg = string.Format("Invalid combination configuration..!!!!", new object[0]);
					GlobalRef.LuaWrapper.PrintError(msg);
				}
				else
				{
					m_GuiManager.ScriptOps.SelectChipVersion("XWR2243");
					string full_command = string.Format("ar1.deviceVariantSelection(\"{0}\")", new object[]
					{
						"XWR2243"
					});
					m_GuiManager.RecordLog(13, full_command);
					string full_command2 = string.Format("Status: Passed", new object[0]);
					m_GuiManager.RecordLog(8, full_command2);
					GlobalRef.g_AR12xxDevice = false;
					GlobalRef.g_AR14xxDevice = false;
					GlobalRef.g_AR16xxDevice = false;
					GlobalRef.g_AR1843Device = false;
					GlobalRef.g_AR2243Device = true;
				}
				GlobalRef.g_AR6843Device = false;
			}
			else
			{
				GlobalRef.g_AR6843Device = false;
			}
			return 0;
		}

		public int m00002e()
		{
			if (f00019a.Checked)
			{
				if (GlobalRef.g_ARDeviceOperateFreq60GHz)
				{
					string msg = string.Format("Invalid combination configuration..!!!!", new object[0]);
					GlobalRef.LuaWrapper.PrintError(msg);
				}
				else
				{
					m_GuiManager.ScriptOps.SelectChipVersion("AR1243");
					string full_command = string.Format("ar1.deviceVariantSelection(\"{0}\")", new object[]
					{
						"XWR1243"
					});
					m_GuiManager.RecordLog(13, full_command);
					string full_command2 = string.Format("Status: Passed", new object[0]);
					m_GuiManager.RecordLog(8, full_command2);
					GlobalRef.g_AR12xxDevice = true;
					GlobalRef.g_AR14xxDevice = false;
					GlobalRef.g_AR16xxDevice = false;
					GlobalRef.g_AR1843Device = false;
					GlobalRef.g_AR2243Device = false;
				}
				GlobalRef.g_AR6843Device = false;
			}
			else
			{
				GlobalRef.g_AR6843Device = false;
			}
			return 0;
		}

		public int m00002f()
		{
			if (f00019b.Checked)
			{
				if (GlobalRef.g_ARDeviceOperateFreq60GHz)
				{
					string msg = string.Format("Invalid combination configuration..!!!!", new object[0]);
					GlobalRef.LuaWrapper.PrintError(msg);
				}
				else
				{
					m_GuiManager.ScriptOps.SelectChipVersion("AR1243");
					string full_command = string.Format("ar1.deviceVariantSelection(\"{0}\")", new object[]
					{
						"XWR1443"
					});
					m_GuiManager.RecordLog(13, full_command);
					string full_command2 = string.Format("Status: Passed", new object[0]);
					m_GuiManager.RecordLog(8, full_command2);
					GlobalRef.g_AR12xxDevice = false;
					GlobalRef.g_AR14xxDevice = true;
					GlobalRef.g_AR16xxDevice = false;
					GlobalRef.g_AR1843Device = false;
					GlobalRef.g_AR2243Device = false;
				}
				GlobalRef.g_AR6843Device = false;
			}
			else
			{
				GlobalRef.g_AR6843Device = false;
			}
			return 0;
		}

		public int m000030()
		{
			if (f00019c.Checked)
			{
				if (GlobalRef.g_ARDeviceOperateFreq60GHz)
				{
					m_GuiManager.ScriptOps.SelectChipVersion("IWR6843");
					string full_command = string.Format("ar1.deviceVariantSelection(\"{0}\")", new object[]
					{
						"IWR6843"
					});
					m_GuiManager.RecordLog(13, full_command);
				}
				else
				{
					m_GuiManager.ScriptOps.SelectChipVersion("AR1642");
					string full_command2 = string.Format("ar1.deviceVariantSelection(\"{0}\")", new object[]
					{
						"XWR1642"
					});
					m_GuiManager.RecordLog(13, full_command2);
				}
				string full_command3 = string.Format("Status: Passed", new object[0]);
				m_GuiManager.RecordLog(8, full_command3);
				GlobalRef.g_AR12xxDevice = false;
				GlobalRef.g_AR14xxDevice = false;
				GlobalRef.g_AR16xxDevice = true;
				GlobalRef.g_AR1843Device = false;
				GlobalRef.g_AR2243Device = false;
				GlobalRef.g_AR6843Device = false;
			}
			else
			{
				GlobalRef.g_AR6843Device = false;
			}
			return 0;
		}

		public int selectAR1843DeviceVariant()
		{
			if (m_RadioBtnxWR1843.Checked)
			{
				if (GlobalRef.g_ARDeviceOperateFreq60GHz)
				{
					string msg = string.Format("Invalid combination configuration..!!!!", new object[0]);
					GlobalRef.LuaWrapper.PrintError(msg);
				}
				else
				{
					m_GuiManager.ScriptOps.SelectChipVersion("AR1642");
					string full_command = string.Format("ar1.deviceVariantSelection(\"{0}\")", new object[]
					{
						"XWR1843"
					});
					m_GuiManager.RecordLog(13, full_command);
					string full_command2 = string.Format("Status: Passed", new object[0]);
					m_GuiManager.RecordLog(8, full_command2);
					GlobalRef.g_AR12xxDevice = false;
					GlobalRef.g_AR14xxDevice = false;
					GlobalRef.g_AR16xxDevice = true;
					GlobalRef.g_AR1843Device = true;
					GlobalRef.g_AR2243Device = false;
				}
				GlobalRef.g_AR6843Device = false;
			}
			else
			{
				GlobalRef.g_AR6843Device = false;
			}
			return 0;
		}

		public int selectAR6843DeviceVariant()
		{
			if (m_RadioBtnxWR6843.Checked)
			{
				if (GlobalRef.g_ARDeviceOperateFreq60GHz && (!GlobalRef.g_AR12xxDevice || !GlobalRef.g_AR14xxDevice))
				{
					m_GuiManager.ScriptOps.SelectChipVersion("IWR6843");
					string full_command = string.Format("ar1.deviceVariantSelection(\"{0}\")", new object[]
					{
						"IWR6843"
					});
					m_GuiManager.RecordLog(13, full_command);
					string full_command2 = string.Format("Status: Passed", new object[0]);
					m_GuiManager.RecordLog(8, full_command2);
					GlobalRef.g_AR12xxDevice = false;
					GlobalRef.g_AR14xxDevice = false;
					GlobalRef.g_AR16xxDevice = true;
					GlobalRef.g_AR1843Device = false;
					GlobalRef.g_AR2243Device = false;
				}
				else
				{
					string.Format("Invalid combination configuration..!!!!", new object[0]);
				}
				GlobalRef.g_AR6843Device = true;
			}
			else
			{
				GlobalRef.g_AR6843Device = false;
			}
			return 0;
		}

		private void m_cboCfg_File_SelectedIndexChanged(object sender, EventArgs p1)
		{
		}

		private void m_lblCfgFile_Click(object sender, EventArgs p1)
		{
		}

		private void m000031(object sender, EventArgs p1)
		{
		}

		private void m_grpRadarMultiDevicesRS232OpSetting_Enter(object sender, EventArgs p1)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_chkPollConnection = new System.Windows.Forms.CheckBox();
			this.m_lblDllVersion = new System.Windows.Forms.Label();
			this.m_lblConnectivityStatus = new System.Windows.Forms.Label();
			this.m_lblMacFwVersion = new System.Windows.Forms.Label();
			this.m_lblMacVersion = new System.Windows.Forms.Label();
			this.m_btnConnect = new System.Windows.Forms.Button();
			this.m_lblStatus = new System.Windows.Forms.Label();
			this.m_grpFirmWare = new System.Windows.Forms.GroupBox();
			this.m_btnDSP_FwLoad = new System.Windows.Forms.Button();
			this.m_DSPCheck = new System.Windows.Forms.CheckBox();
			this.f000193 = new System.Windows.Forms.Button();
			this.m_cboDSP_FwFile = new System.Windows.Forms.ComboBox();
			this.f000194 = new System.Windows.Forms.Label();
			this.m_MSSCheck = new System.Windows.Forms.CheckBox();
			this.m_BSSCheck = new System.Windows.Forms.CheckBox();
			this.m_CfgFileCheck = new System.Windows.Forms.CheckBox();
			this.m_btnCfg_FileLoad = new System.Windows.Forms.Button();
			this.m_cboCfg_File = new System.Windows.Forms.ComboBox();
			this.m_btnCfg_File = new System.Windows.Forms.Button();
			this.m_lblCfgFile = new System.Windows.Forms.Label();
			this.m_btnMSS_FwLoad = new System.Windows.Forms.Button();
			this.m_cboMSS_FwFile = new System.Windows.Forms.ComboBox();
			this.f000190 = new System.Windows.Forms.Button();
			this.f000191 = new System.Windows.Forms.Label();
			this.m_cboBSS_FwFile = new System.Windows.Forms.ComboBox();
			this.m_btnBSS_FwLoad = new System.Windows.Forms.Button();
			this.f00018e = new System.Windows.Forms.Button();
			this.f00018f = new System.Windows.Forms.Label();
			this.m_grpSettings = new System.Windows.Forms.GroupBox();
			this.m_btnRefreshPorts = new System.Windows.Forms.Button();
			this.m_cboBaudRate = new System.Windows.Forms.ComboBox();
			this.m_cboComPort = new System.Windows.Forms.ComboBox();
			this.m_lblBaudRate = new System.Windows.Forms.Label();
			this.m_lblComPort = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_lblPHYFwVersion = new System.Windows.Forms.Label();
			this.m_lblPhyVersion = new System.Windows.Forms.Label();
			this.m_timerCheckOvUv = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_btnEnblRfDevice4 = new System.Windows.Forms.Button();
			this.m_btnEnblRfDevice3 = new System.Windows.Forms.Button();
			this.m_btnEnblRfDevice2 = new System.Windows.Forms.Button();
			this.m_btnAddDevice4SPIConct = new System.Windows.Forms.Button();
			this.m_btnAddDevice3SPIConct = new System.Windows.Forms.Button();
			this.m_btnAddDevice2SPIConct = new System.Windows.Forms.Button();
			this.m_cboCRC = new System.Windows.Forms.ComboBox();
			this.f000192 = new System.Windows.Forms.CheckBox();
			this.m_btnEnblRf = new System.Windows.Forms.Button();
			this.m_chkAck = new System.Windows.Forms.CheckBox();
			this.m_btnSPIConct = new System.Windows.Forms.Button();
			this.m_grpBoardCtrl = new System.Windows.Forms.GroupBox();
			this.m_lblSOPNote = new System.Windows.Forms.Label();
			this.m_btnFlash = new System.Windows.Forms.Button();
			this.m_grpSOPControl = new System.Windows.Forms.GroupBox();
			this.m_cboSopMod = new System.Windows.Forms.ComboBox();
			this.m_lblSOPMode = new System.Windows.Forms.Label();
			this.m_btnSetSop = new System.Windows.Forms.Button();
			this.m_btnFullRst = new System.Windows.Forms.Button();
			this.m_btnWarmRst = new System.Windows.Forms.Button();
			this.m_lblDevStatus = new System.Windows.Forms.Label();
			this.m_lblDevSts = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_lblRadarLinkVersion = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_lblMatlabPostProcVersion = new System.Windows.Forms.Label();
			this.f000195 = new System.Windows.Forms.Label();
			this.m_lblDSPFwVersion = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.f000196 = new System.Windows.Forms.Label();
			this.m_lblSPIConnectivityStatus = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.m_lblNumOfRadarDevsDetected = new System.Windows.Forms.Label();
			this.m_grpRadarMultiDevicesRS232OpSetting = new System.Windows.Forms.GroupBox();
			this.m_grpRadarDev4RS232OpSettings = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.m_btnRadarDev4Connect = new System.Windows.Forms.Button();
			this.m_btnRadarDev4RefreshPorts = new System.Windows.Forms.Button();
			this.m_cboRadarDevice4BaudRate = new System.Windows.Forms.ComboBox();
			this.m_cboRadarDevice4ComPort = new System.Windows.Forms.ComboBox();
			this.m_grpRadarDev3RS232OpSettings = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.m_btnRadarDev3Connect = new System.Windows.Forms.Button();
			this.m_btnRadarDev3RefreshPorts = new System.Windows.Forms.Button();
			this.m_cboRadarDevice3BaudRate = new System.Windows.Forms.ComboBox();
			this.m_cboRadarDevice3ComPort = new System.Windows.Forms.ComboBox();
			this.m_grpRadarDev2RS232OpSettings = new System.Windows.Forms.GroupBox();
			this.m_btnRadarDev2RefreshPorts = new System.Windows.Forms.Button();
			this.m_cboRadarDevice2BaudRate = new System.Windows.Forms.ComboBox();
			this.m_cboRadarDevice2ComPort = new System.Windows.Forms.ComboBox();
			this.m_btnRadarDev2Connect = new System.Windows.Forms.Button();
			this.m_lblRadarDevBaudRate = new System.Windows.Forms.Label();
			this.m_lblRadarDev2ComPort = new System.Windows.Forms.Label();
			this.m_btnRefreshNoOfDevices = new System.Windows.Forms.Button();
			this.m_lblRadarDev4MacFwVersion = new System.Windows.Forms.Label();
			this.m_lblRadarDev4PHYFwVersion = new System.Windows.Forms.Label();
			this.m_lblDev4Status = new System.Windows.Forms.Label();
			this.m_lblRadarDev4SPIConnectivityStatus = new System.Windows.Forms.Label();
			this.f000197 = new System.Windows.Forms.Label();
			this.m_lblConnectivityRadarDev4Status = new System.Windows.Forms.Label();
			this.m_lblRadarDev3MacFwVersion = new System.Windows.Forms.Label();
			this.m_lblRadarDev3PHYFwVersion = new System.Windows.Forms.Label();
			this.m_lblDev3Status = new System.Windows.Forms.Label();
			this.m_lblRadarDev3SPIConnectivityStatus = new System.Windows.Forms.Label();
			this.f000198 = new System.Windows.Forms.Label();
			this.m_lblConnectivityRadarDev3Status = new System.Windows.Forms.Label();
			this.m_lblRadarDev2MacFwVersion = new System.Windows.Forms.Label();
			this.m_lblRadarDev2PHYFwVersion = new System.Windows.Forms.Label();
			this.m_lblDev2Status = new System.Windows.Forms.Label();
			this.m_lblRadarDev2SPIConnectivityStatus = new System.Windows.Forms.Label();
			this.f000199 = new System.Windows.Forms.Label();
			this.m_lblConnectivityRadarDev2Status = new System.Windows.Forms.Label();
			this.m_grpRadarDev2StatusSettings = new System.Windows.Forms.GroupBox();
			this.m_lblRadarDev2DieIDInfo = new System.Windows.Forms.Label();
			this.m_lblRadarDev2BSSPatchFwVersion = new System.Windows.Forms.Label();
			this.m_lblRadarDev2MSSPatchFwVersion = new System.Windows.Forms.Label();
			this.m_grpRadarDev3StatusSettings = new System.Windows.Forms.GroupBox();
			this.m_lblRadarDev3DieIDInfo = new System.Windows.Forms.Label();
			this.m_lblRadarDev3BSSPatchFwVersion = new System.Windows.Forms.Label();
			this.m_lblRadarDev3MSSPatchFwVersion = new System.Windows.Forms.Label();
			this.m_grpRadarDev4StatusSettings = new System.Windows.Forms.GroupBox();
			this.m_lblRadarDev4DieIDInfo = new System.Windows.Forms.Label();
			this.m_lblRadarDev4BSSPatchFwVersion = new System.Windows.Forms.Label();
			this.m_lblRadarDev4MSSPatchFwVersion = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.m_lblTopNearTX3 = new System.Windows.Forms.Label();
			this.m_lblBottomNearRX1 = new System.Windows.Forms.Label();
			this.m_lblBottomNearTX2 = new System.Windows.Forms.Label();
			this.m_lblNearRx = new System.Windows.Forms.Label();
			this.m_btnTempSensorGet = new System.Windows.Forms.Button();
			this.m_grpTemperatureSensor = new System.Windows.Forms.GroupBox();
			this.m_lblTopNearRX1 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.m_lblDieIDInfo = new System.Windows.Forms.Label();
			this.m_lblBSSPatchFwVersion = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.m_lblMSSPatchFwVersion = new System.Windows.Forms.Label();
			this.m_lblGuiVersion = new System.Windows.Forms.Label();
			this.f00019a = new System.Windows.Forms.RadioButton();
			this.f00019b = new System.Windows.Forms.RadioButton();
			this.f00019c = new System.Windows.Forms.RadioButton();
			this.m_grpDeviceVariantTypes = new System.Windows.Forms.GroupBox();
			this.f00019d = new System.Windows.Forms.RadioButton();
			this.m_RadioBtnxWR1843 = new System.Windows.Forms.RadioButton();
			this.m_RadioBtnxWR6843 = new System.Windows.Forms.RadioButton();
			this.m_RadioBtn77GHzRadarDev = new System.Windows.Forms.RadioButton();
			this.m_RadioBtn60GHzRadarDev = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_lblI2CAddress = new System.Windows.Forms.Label();
			this.m_nudI2CAddress = new System.Windows.Forms.NumericUpDown();
			this.m_grpFirmWare.SuspendLayout();
			this.m_grpSettings.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.m_grpBoardCtrl.SuspendLayout();
			this.m_grpSOPControl.SuspendLayout();
			this.m_grpRadarMultiDevicesRS232OpSetting.SuspendLayout();
			this.m_grpRadarDev4RS232OpSettings.SuspendLayout();
			this.m_grpRadarDev3RS232OpSettings.SuspendLayout();
			this.m_grpRadarDev2RS232OpSettings.SuspendLayout();
			this.m_grpRadarDev2StatusSettings.SuspendLayout();
			this.m_grpRadarDev3StatusSettings.SuspendLayout();
			this.m_grpRadarDev4StatusSettings.SuspendLayout();
			this.m_grpTemperatureSensor.SuspendLayout();
			this.m_grpDeviceVariantTypes.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_nudI2CAddress)).BeginInit();
			this.SuspendLayout();
			// 
			// m_chkPollConnection
			// 
			this.m_chkPollConnection.AutoSize = true;
			this.m_chkPollConnection.Checked = true;
			this.m_chkPollConnection.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_chkPollConnection.Enabled = false;
			this.m_chkPollConnection.Location = new System.Drawing.Point(1263, 463);
			this.m_chkPollConnection.Name = "m_chkPollConnection";
			this.m_chkPollConnection.Size = new System.Drawing.Size(113, 19);
			this.m_chkPollConnection.TabIndex = 25;
			this.m_chkPollConnection.Text = "Poll Connection";
			this.m_chkPollConnection.UseVisualStyleBackColor = true;
			this.m_chkPollConnection.Visible = false;
			// 
			// m_lblDllVersion
			// 
			this.m_lblDllVersion.AutoSize = true;
			this.m_lblDllVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblDllVersion.Location = new System.Drawing.Point(763, 214);
			this.m_lblDllVersion.Name = "m_lblDllVersion";
			this.m_lblDllVersion.Size = new System.Drawing.Size(54, 13);
			this.m_lblDllVersion.TabIndex = 29;
			this.m_lblDllVersion.Text = "0.0.0.00";
			this.m_lblDllVersion.Visible = false;
			// 
			// m_lblConnectivityStatus
			// 
			this.m_lblConnectivityStatus.AutoSize = true;
			this.m_lblConnectivityStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblConnectivityStatus.ForeColor = System.Drawing.Color.Red;
			this.m_lblConnectivityStatus.Location = new System.Drawing.Point(672, 33);
			this.m_lblConnectivityStatus.Name = "m_lblConnectivityStatus";
			this.m_lblConnectivityStatus.Size = new System.Drawing.Size(85, 15);
			this.m_lblConnectivityStatus.TabIndex = 27;
			this.m_lblConnectivityStatus.Text = "Disconnected";
			// 
			// m_lblMacFwVersion
			// 
			this.m_lblMacFwVersion.AutoSize = true;
			this.m_lblMacFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblMacFwVersion.Location = new System.Drawing.Point(672, 173);
			this.m_lblMacFwVersion.Name = "m_lblMacFwVersion";
			this.m_lblMacFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblMacFwVersion.TabIndex = 26;
			this.m_lblMacFwVersion.Text = "0.0.0.0.0.0.0";
			// 
			// m_lblMacVersion
			// 
			this.m_lblMacVersion.AutoSize = true;
			this.m_lblMacVersion.Location = new System.Drawing.Point(535, 173);
			this.m_lblMacVersion.Name = "m_lblMacVersion";
			this.m_lblMacVersion.Size = new System.Drawing.Size(129, 15);
			this.m_lblMacVersion.TabIndex = 25;
			this.m_lblMacVersion.Text = "MSS firmware version:";
			// 
			// m_btnConnect
			// 
			this.m_btnConnect.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_btnConnect.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btnConnect.Location = new System.Drawing.Point(82, 88);
			this.m_btnConnect.Name = "m_btnConnect";
			this.m_btnConnect.Size = new System.Drawing.Size(108, 27);
			this.m_btnConnect.TabIndex = 8;
			this.m_btnConnect.Text = "Connect (2)";
			this.m_btnConnect.UseVisualStyleBackColor = true;
			// 
			// m_lblStatus
			// 
			this.m_lblStatus.AutoSize = true;
			this.m_lblStatus.Location = new System.Drawing.Point(523, 33);
			this.m_lblStatus.Name = "m_lblStatus";
			this.m_lblStatus.Size = new System.Drawing.Size(142, 15);
			this.m_lblStatus.TabIndex = 23;
			this.m_lblStatus.Text = "FTDI Connectivity Status:";
			// 
			// m_grpFirmWare
			// 
			this.m_grpFirmWare.Controls.Add(this.m_btnDSP_FwLoad);
			this.m_grpFirmWare.Controls.Add(this.m_DSPCheck);
			this.m_grpFirmWare.Controls.Add(this.f000193);
			this.m_grpFirmWare.Controls.Add(this.m_cboDSP_FwFile);
			this.m_grpFirmWare.Controls.Add(this.f000194);
			this.m_grpFirmWare.Controls.Add(this.m_MSSCheck);
			this.m_grpFirmWare.Controls.Add(this.m_BSSCheck);
			this.m_grpFirmWare.Controls.Add(this.m_CfgFileCheck);
			this.m_grpFirmWare.Controls.Add(this.m_btnCfg_FileLoad);
			this.m_grpFirmWare.Controls.Add(this.m_cboCfg_File);
			this.m_grpFirmWare.Controls.Add(this.m_btnCfg_File);
			this.m_grpFirmWare.Controls.Add(this.m_lblCfgFile);
			this.m_grpFirmWare.Controls.Add(this.m_btnMSS_FwLoad);
			this.m_grpFirmWare.Controls.Add(this.m_cboMSS_FwFile);
			this.m_grpFirmWare.Controls.Add(this.f000190);
			this.m_grpFirmWare.Controls.Add(this.f000191);
			this.m_grpFirmWare.Controls.Add(this.m_cboBSS_FwFile);
			this.m_grpFirmWare.Controls.Add(this.m_btnBSS_FwLoad);
			this.m_grpFirmWare.Controls.Add(this.f00018e);
			this.m_grpFirmWare.Controls.Add(this.f00018f);
			this.m_grpFirmWare.Location = new System.Drawing.Point(15, 325);
			this.m_grpFirmWare.Name = "m_grpFirmWare";
			this.m_grpFirmWare.Size = new System.Drawing.Size(731, 162);
			this.m_grpFirmWare.TabIndex = 22;
			this.m_grpFirmWare.TabStop = false;
			this.m_grpFirmWare.Text = "Files";
			// 
			// m_btnDSP_FwLoad
			// 
			this.m_btnDSP_FwLoad.Enabled = false;
			this.m_btnDSP_FwLoad.Location = new System.Drawing.Point(622, 134);
			this.m_btnDSP_FwLoad.Name = "m_btnDSP_FwLoad";
			this.m_btnDSP_FwLoad.Size = new System.Drawing.Size(61, 23);
			this.m_btnDSP_FwLoad.TabIndex = 62;
			this.m_btnDSP_FwLoad.Text = "Load";
			this.m_btnDSP_FwLoad.UseVisualStyleBackColor = true;
			this.m_btnDSP_FwLoad.Visible = false;
			// 
			// m_DSPCheck
			// 
			this.m_DSPCheck.AutoSize = true;
			this.m_DSPCheck.Location = new System.Drawing.Point(702, 138);
			this.m_DSPCheck.Name = "m_DSPCheck";
			this.m_DSPCheck.Size = new System.Drawing.Size(15, 14);
			this.m_DSPCheck.TabIndex = 61;
			this.m_DSPCheck.UseVisualStyleBackColor = true;
			this.m_DSPCheck.Visible = false;
			// 
			// f000193
			// 
			this.f000193.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.f000193.Location = new System.Drawing.Point(581, 134);
			this.f000193.Name = "f000193";
			this.f000193.Size = new System.Drawing.Size(33, 23);
			this.f000193.TabIndex = 60;
			this.f000193.Text = "...";
			this.f000193.UseVisualStyleBackColor = true;
			this.f000193.Visible = false;
			// 
			// m_cboDSP_FwFile
			// 
			this.m_cboDSP_FwFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cboDSP_FwFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cboDSP_FwFile.FormattingEnabled = true;
			this.m_cboDSP_FwFile.Location = new System.Drawing.Point(80, 134);
			this.m_cboDSP_FwFile.Name = "m_cboDSP_FwFile";
			this.m_cboDSP_FwFile.Size = new System.Drawing.Size(495, 23);
			this.m_cboDSP_FwFile.TabIndex = 59;
			this.m_cboDSP_FwFile.Visible = false;
			// 
			// f000194
			// 
			this.f000194.AutoSize = true;
			this.f000194.Location = new System.Drawing.Point(10, 139);
			this.f000194.Name = "f000194";
			this.f000194.Size = new System.Drawing.Size(56, 15);
			this.f000194.TabIndex = 58;
			this.f000194.Text = "DSP FW:";
			this.f000194.Visible = false;
			// 
			// m_MSSCheck
			// 
			this.m_MSSCheck.AutoSize = true;
			this.m_MSSCheck.Location = new System.Drawing.Point(702, 69);
			this.m_MSSCheck.Name = "m_MSSCheck";
			this.m_MSSCheck.Size = new System.Drawing.Size(15, 14);
			this.m_MSSCheck.TabIndex = 16;
			this.m_MSSCheck.UseVisualStyleBackColor = true;
			// 
			// m_BSSCheck
			// 
			this.m_BSSCheck.AutoSize = true;
			this.m_BSSCheck.Location = new System.Drawing.Point(702, 38);
			this.m_BSSCheck.Name = "m_BSSCheck";
			this.m_BSSCheck.Size = new System.Drawing.Size(15, 14);
			this.m_BSSCheck.TabIndex = 12;
			this.m_BSSCheck.UseVisualStyleBackColor = true;
			// 
			// m_CfgFileCheck
			// 
			this.m_CfgFileCheck.AutoSize = true;
			this.m_CfgFileCheck.Location = new System.Drawing.Point(702, 104);
			this.m_CfgFileCheck.Name = "m_CfgFileCheck";
			this.m_CfgFileCheck.Size = new System.Drawing.Size(15, 14);
			this.m_CfgFileCheck.TabIndex = 20;
			this.m_CfgFileCheck.UseVisualStyleBackColor = true;
			// 
			// m_btnCfg_FileLoad
			// 
			this.m_btnCfg_FileLoad.Enabled = false;
			this.m_btnCfg_FileLoad.Location = new System.Drawing.Point(623, 100);
			this.m_btnCfg_FileLoad.Name = "m_btnCfg_FileLoad";
			this.m_btnCfg_FileLoad.Size = new System.Drawing.Size(61, 23);
			this.m_btnCfg_FileLoad.TabIndex = 19;
			this.m_btnCfg_FileLoad.Text = "Load";
			this.m_btnCfg_FileLoad.UseVisualStyleBackColor = true;
			// 
			// m_cboCfg_File
			// 
			this.m_cboCfg_File.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cboCfg_File.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cboCfg_File.FormattingEnabled = true;
			this.m_cboCfg_File.Location = new System.Drawing.Point(81, 100);
			this.m_cboCfg_File.Name = "m_cboCfg_File";
			this.m_cboCfg_File.Size = new System.Drawing.Size(494, 23);
			this.m_cboCfg_File.TabIndex = 17;
			// 
			// m_btnCfg_File
			// 
			this.m_btnCfg_File.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_btnCfg_File.Location = new System.Drawing.Point(582, 100);
			this.m_btnCfg_File.Name = "m_btnCfg_File";
			this.m_btnCfg_File.Size = new System.Drawing.Size(33, 23);
			this.m_btnCfg_File.TabIndex = 18;
			this.m_btnCfg_File.Text = "...";
			this.m_btnCfg_File.UseVisualStyleBackColor = true;
			// 
			// m_lblCfgFile
			// 
			this.m_lblCfgFile.AutoSize = true;
			this.m_lblCfgFile.Location = new System.Drawing.Point(8, 102);
			this.m_lblCfgFile.Name = "m_lblCfgFile";
			this.m_lblCfgFile.Size = new System.Drawing.Size(69, 15);
			this.m_lblCfgFile.TabIndex = 57;
			this.m_lblCfgFile.Text = "Config File:";
			// 
			// m_btnMSS_FwLoad
			// 
			this.m_btnMSS_FwLoad.Enabled = false;
			this.m_btnMSS_FwLoad.Location = new System.Drawing.Point(623, 66);
			this.m_btnMSS_FwLoad.Name = "m_btnMSS_FwLoad";
			this.m_btnMSS_FwLoad.Size = new System.Drawing.Size(61, 23);
			this.m_btnMSS_FwLoad.TabIndex = 15;
			this.m_btnMSS_FwLoad.Text = "Load (4)";
			this.m_btnMSS_FwLoad.UseVisualStyleBackColor = true;
			// 
			// m_cboMSS_FwFile
			// 
			this.m_cboMSS_FwFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cboMSS_FwFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cboMSS_FwFile.FormattingEnabled = true;
			this.m_cboMSS_FwFile.Location = new System.Drawing.Point(80, 67);
			this.m_cboMSS_FwFile.Name = "m_cboMSS_FwFile";
			this.m_cboMSS_FwFile.Size = new System.Drawing.Size(496, 23);
			this.m_cboMSS_FwFile.TabIndex = 13;
			// 
			// f000190
			// 
			this.f000190.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.f000190.Location = new System.Drawing.Point(582, 66);
			this.f000190.Name = "f000190";
			this.f000190.Size = new System.Drawing.Size(33, 23);
			this.f000190.TabIndex = 14;
			this.f000190.Text = "...";
			this.f000190.UseVisualStyleBackColor = true;
			// 
			// f000191
			// 
			this.f000191.AutoSize = true;
			this.f000191.Location = new System.Drawing.Point(7, 69);
			this.f000191.Name = "f000191";
			this.f000191.Size = new System.Drawing.Size(56, 15);
			this.f000191.TabIndex = 44;
			this.f000191.Text = "MSS FW:";
			// 
			// m_cboBSS_FwFile
			// 
			this.m_cboBSS_FwFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cboBSS_FwFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cboBSS_FwFile.FormattingEnabled = true;
			this.m_cboBSS_FwFile.Location = new System.Drawing.Point(79, 35);
			this.m_cboBSS_FwFile.Name = "m_cboBSS_FwFile";
			this.m_cboBSS_FwFile.Size = new System.Drawing.Size(497, 23);
			this.m_cboBSS_FwFile.TabIndex = 9;
			// 
			// m_btnBSS_FwLoad
			// 
			this.m_btnBSS_FwLoad.Enabled = false;
			this.m_btnBSS_FwLoad.Location = new System.Drawing.Point(623, 35);
			this.m_btnBSS_FwLoad.Name = "m_btnBSS_FwLoad";
			this.m_btnBSS_FwLoad.Size = new System.Drawing.Size(61, 23);
			this.m_btnBSS_FwLoad.TabIndex = 11;
			this.m_btnBSS_FwLoad.Text = "Load (3)";
			this.m_btnBSS_FwLoad.UseVisualStyleBackColor = true;
			// 
			// f00018e
			// 
			this.f00018e.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.f00018e.Location = new System.Drawing.Point(582, 35);
			this.f00018e.Name = "f00018e";
			this.f00018e.Size = new System.Drawing.Size(33, 23);
			this.f00018e.TabIndex = 10;
			this.f00018e.Text = "...";
			this.f00018e.UseVisualStyleBackColor = true;
			// 
			// f00018f
			// 
			this.f00018f.AutoSize = true;
			this.f00018f.Location = new System.Drawing.Point(7, 39);
			this.f00018f.Name = "f00018f";
			this.f00018f.Size = new System.Drawing.Size(55, 15);
			this.f00018f.TabIndex = 1;
			this.f00018f.Text = "BSS FW:";
			// 
			// m_grpSettings
			// 
			this.m_grpSettings.Controls.Add(this.m_btnRefreshPorts);
			this.m_grpSettings.Controls.Add(this.m_cboBaudRate);
			this.m_grpSettings.Controls.Add(this.m_cboComPort);
			this.m_grpSettings.Controls.Add(this.m_lblBaudRate);
			this.m_grpSettings.Controls.Add(this.m_lblComPort);
			this.m_grpSettings.Controls.Add(this.m_btnConnect);
			this.m_grpSettings.Location = new System.Drawing.Point(257, 14);
			this.m_grpSettings.Name = "m_grpSettings";
			this.m_grpSettings.Size = new System.Drawing.Size(226, 125);
			this.m_grpSettings.TabIndex = 21;
			this.m_grpSettings.TabStop = false;
			this.m_grpSettings.Text = "RS232 Operations";
			// 
			// m_btnRefreshPorts
			// 
			this.m_btnRefreshPorts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.m_btnRefreshPorts.Location = new System.Drawing.Point(194, 22);
			this.m_btnRefreshPorts.Name = "m_btnRefreshPorts";
			this.m_btnRefreshPorts.Size = new System.Drawing.Size(24, 24);
			this.m_btnRefreshPorts.TabIndex = 6;
			this.m_btnRefreshPorts.UseVisualStyleBackColor = true;
			// 
			// m_cboBaudRate
			// 
			this.m_cboBaudRate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cboBaudRate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboBaudRate.FormattingEnabled = true;
			this.m_cboBaudRate.Location = new System.Drawing.Point(82, 55);
			this.m_cboBaudRate.Name = "m_cboBaudRate";
			this.m_cboBaudRate.Size = new System.Drawing.Size(107, 23);
			this.m_cboBaudRate.TabIndex = 7;
			// 
			// m_cboComPort
			// 
			this.m_cboComPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cboComPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cboComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboComPort.FormattingEnabled = true;
			this.m_cboComPort.Location = new System.Drawing.Point(82, 22);
			this.m_cboComPort.Name = "m_cboComPort";
			this.m_cboComPort.Size = new System.Drawing.Size(107, 23);
			this.m_cboComPort.TabIndex = 5;
			// 
			// m_lblBaudRate
			// 
			this.m_lblBaudRate.AutoSize = true;
			this.m_lblBaudRate.Location = new System.Drawing.Point(7, 60);
			this.m_lblBaudRate.Name = "m_lblBaudRate";
			this.m_lblBaudRate.Size = new System.Drawing.Size(65, 15);
			this.m_lblBaudRate.TabIndex = 2;
			this.m_lblBaudRate.Text = "Baud Rate";
			// 
			// m_lblComPort
			// 
			this.m_lblComPort.AutoSize = true;
			this.m_lblComPort.Location = new System.Drawing.Point(7, 27);
			this.m_lblComPort.Name = "m_lblComPort";
			this.m_lblComPort.Size = new System.Drawing.Size(59, 15);
			this.m_lblComPort.TabIndex = 0;
			this.m_lblComPort.Text = "COM Port";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(589, 213);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 15);
			this.label4.TabIndex = 31;
			this.label4.Text = "GUI Version:";
			// 
			// m_lblPHYFwVersion
			// 
			this.m_lblPHYFwVersion.AutoSize = true;
			this.m_lblPHYFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblPHYFwVersion.Location = new System.Drawing.Point(672, 133);
			this.m_lblPHYFwVersion.Name = "m_lblPHYFwVersion";
			this.m_lblPHYFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblPHYFwVersion.TabIndex = 42;
			this.m_lblPHYFwVersion.Text = "0.0.0.0.0.0.0";
			// 
			// m_lblPhyVersion
			// 
			this.m_lblPhyVersion.AutoSize = true;
			this.m_lblPhyVersion.Location = new System.Drawing.Point(535, 133);
			this.m_lblPhyVersion.Name = "m_lblPhyVersion";
			this.m_lblPhyVersion.Size = new System.Drawing.Size(128, 15);
			this.m_lblPhyVersion.TabIndex = 41;
			this.m_lblPhyVersion.Text = "BSS firmware version:";
			// 
			// m_timerCheckOvUv
			// 
			this.m_timerCheckOvUv.Interval = 15000;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_btnEnblRfDevice4);
			this.groupBox1.Controls.Add(this.m_btnEnblRfDevice3);
			this.groupBox1.Controls.Add(this.m_btnEnblRfDevice2);
			this.groupBox1.Controls.Add(this.m_btnAddDevice4SPIConct);
			this.groupBox1.Controls.Add(this.m_btnAddDevice3SPIConct);
			this.groupBox1.Controls.Add(this.m_btnAddDevice2SPIConct);
			this.groupBox1.Controls.Add(this.m_cboCRC);
			this.groupBox1.Controls.Add(this.f000192);
			this.groupBox1.Controls.Add(this.m_btnEnblRf);
			this.groupBox1.Controls.Add(this.m_chkAck);
			this.groupBox1.Controls.Add(this.m_btnSPIConct);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(775, 325);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(619, 129);
			this.groupBox1.TabIndex = 45;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SPI Operations";
			// 
			// m_btnEnblRfDevice4
			// 
			this.m_btnEnblRfDevice4.Location = new System.Drawing.Point(458, 86);
			this.m_btnEnblRfDevice4.Name = "m_btnEnblRfDevice4";
			this.m_btnEnblRfDevice4.Size = new System.Drawing.Size(124, 28);
			this.m_btnEnblRfDevice4.TabIndex = 73;
			this.m_btnEnblRfDevice4.Text = "RF Power-up (4)";
			this.m_btnEnblRfDevice4.UseVisualStyleBackColor = true;
			// 
			// m_btnEnblRfDevice3
			// 
			this.m_btnEnblRfDevice3.Location = new System.Drawing.Point(306, 89);
			this.m_btnEnblRfDevice3.Name = "m_btnEnblRfDevice3";
			this.m_btnEnblRfDevice3.Size = new System.Drawing.Size(125, 28);
			this.m_btnEnblRfDevice3.TabIndex = 72;
			this.m_btnEnblRfDevice3.Text = "RF Power-up (3)";
			this.m_btnEnblRfDevice3.UseVisualStyleBackColor = true;
			// 
			// m_btnEnblRfDevice2
			// 
			this.m_btnEnblRfDevice2.Location = new System.Drawing.Point(153, 88);
			this.m_btnEnblRfDevice2.Name = "m_btnEnblRfDevice2";
			this.m_btnEnblRfDevice2.Size = new System.Drawing.Size(133, 28);
			this.m_btnEnblRfDevice2.TabIndex = 71;
			this.m_btnEnblRfDevice2.Text = "RF Power-up (2)";
			this.m_btnEnblRfDevice2.UseVisualStyleBackColor = true;
			// 
			// m_btnAddDevice4SPIConct
			// 
			this.m_btnAddDevice4SPIConct.Location = new System.Drawing.Point(458, 52);
			this.m_btnAddDevice4SPIConct.Name = "m_btnAddDevice4SPIConct";
			this.m_btnAddDevice4SPIConct.Size = new System.Drawing.Size(124, 28);
			this.m_btnAddDevice4SPIConct.TabIndex = 70;
			this.m_btnAddDevice4SPIConct.Text = "SPI Connect (4)";
			this.m_btnAddDevice4SPIConct.UseVisualStyleBackColor = true;
			// 
			// m_btnAddDevice3SPIConct
			// 
			this.m_btnAddDevice3SPIConct.Location = new System.Drawing.Point(305, 52);
			this.m_btnAddDevice3SPIConct.Name = "m_btnAddDevice3SPIConct";
			this.m_btnAddDevice3SPIConct.Size = new System.Drawing.Size(126, 28);
			this.m_btnAddDevice3SPIConct.TabIndex = 69;
			this.m_btnAddDevice3SPIConct.Text = "SPI Connect (3)";
			this.m_btnAddDevice3SPIConct.UseVisualStyleBackColor = true;
			// 
			// m_btnAddDevice2SPIConct
			// 
			this.m_btnAddDevice2SPIConct.Location = new System.Drawing.Point(153, 52);
			this.m_btnAddDevice2SPIConct.Name = "m_btnAddDevice2SPIConct";
			this.m_btnAddDevice2SPIConct.Size = new System.Drawing.Size(133, 28);
			this.m_btnAddDevice2SPIConct.TabIndex = 68;
			this.m_btnAddDevice2SPIConct.Text = "SPI Connect (2)";
			this.m_btnAddDevice2SPIConct.UseVisualStyleBackColor = true;
			// 
			// m_cboCRC
			// 
			this.m_cboCRC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cboCRC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cboCRC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCRC.DropDownWidth = 50;
			this.m_cboCRC.FormattingEnabled = true;
			this.m_cboCRC.Items.AddRange(new object[] {
			"16-bit"});
			this.m_cboCRC.Location = new System.Drawing.Point(116, 20);
			this.m_cboCRC.Name = "m_cboCRC";
			this.m_cboCRC.Size = new System.Drawing.Size(55, 23);
			this.m_cboCRC.TabIndex = 25;
			// 
			// f000192
			// 
			this.f000192.AutoSize = true;
			this.f000192.Checked = true;
			this.f000192.CheckState = System.Windows.Forms.CheckState.Checked;
			this.f000192.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.f000192.Location = new System.Drawing.Point(64, 23);
			this.f000192.Name = "f000192";
			this.f000192.Size = new System.Drawing.Size(53, 19);
			this.f000192.TabIndex = 22;
			this.f000192.Text = "CRC";
			this.f000192.UseVisualStyleBackColor = true;
			// 
			// m_btnEnblRf
			// 
			this.m_btnEnblRf.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_btnEnblRf.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btnEnblRf.Location = new System.Drawing.Point(9, 88);
			this.m_btnEnblRf.Name = "m_btnEnblRf";
			this.m_btnEnblRf.Size = new System.Drawing.Size(123, 28);
			this.m_btnEnblRf.TabIndex = 24;
			this.m_btnEnblRf.Text = "RF Power-up (6)";
			this.m_btnEnblRf.UseVisualStyleBackColor = true;
			// 
			// m_chkAck
			// 
			this.m_chkAck.AutoSize = true;
			this.m_chkAck.Checked = true;
			this.m_chkAck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_chkAck.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_chkAck.Location = new System.Drawing.Point(8, 23);
			this.m_chkAck.Name = "m_chkAck";
			this.m_chkAck.Size = new System.Drawing.Size(50, 19);
			this.m_chkAck.TabIndex = 21;
			this.m_chkAck.Text = "ACK";
			this.m_chkAck.UseVisualStyleBackColor = true;
			// 
			// m_btnSPIConct
			// 
			this.m_btnSPIConct.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_btnSPIConct.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btnSPIConct.Location = new System.Drawing.Point(8, 52);
			this.m_btnSPIConct.Name = "m_btnSPIConct";
			this.m_btnSPIConct.Size = new System.Drawing.Size(124, 28);
			this.m_btnSPIConct.TabIndex = 23;
			this.m_btnSPIConct.Text = "SPI Connect (5)";
			this.m_btnSPIConct.UseVisualStyleBackColor = true;
			// 
			// m_grpBoardCtrl
			// 
			this.m_grpBoardCtrl.Controls.Add(this.m_lblSOPNote);
			this.m_grpBoardCtrl.Controls.Add(this.m_btnFlash);
			this.m_grpBoardCtrl.Controls.Add(this.m_grpSOPControl);
			this.m_grpBoardCtrl.Controls.Add(this.m_btnFullRst);
			this.m_grpBoardCtrl.Controls.Add(this.m_btnWarmRst);
			this.m_grpBoardCtrl.Controls.Add(this.m_grpSettings);
			this.m_grpBoardCtrl.Location = new System.Drawing.Point(15, 16);
			this.m_grpBoardCtrl.Name = "m_grpBoardCtrl";
			this.m_grpBoardCtrl.Size = new System.Drawing.Size(497, 192);
			this.m_grpBoardCtrl.TabIndex = 48;
			this.m_grpBoardCtrl.TabStop = false;
			this.m_grpBoardCtrl.Text = "Board Control";
			// 
			// m_lblSOPNote
			// 
			this.m_lblSOPNote.AutoSize = true;
			this.m_lblSOPNote.ForeColor = System.Drawing.Color.Blue;
			this.m_lblSOPNote.Location = new System.Drawing.Point(5, 108);
			this.m_lblSOPNote.Name = "m_lblSOPNote";
			this.m_lblSOPNote.Size = new System.Drawing.Size(226, 15);
			this.m_lblSOPNote.TabIndex = 22;
			this.m_lblSOPNote.Text = "SOP Mode controlled via jumper on EVM";
			// 
			// m_btnFlash
			// 
			this.m_btnFlash.Location = new System.Drawing.Point(8, 128);
			this.m_btnFlash.Name = "m_btnFlash";
			this.m_btnFlash.Size = new System.Drawing.Size(112, 27);
			this.m_btnFlash.TabIndex = 3;
			this.m_btnFlash.Text = "Flash Program";
			this.m_btnFlash.UseVisualStyleBackColor = true;
			this.m_btnFlash.Visible = false;
			// 
			// m_grpSOPControl
			// 
			this.m_grpSOPControl.Controls.Add(this.m_cboSopMod);
			this.m_grpSOPControl.Controls.Add(this.m_lblSOPMode);
			this.m_grpSOPControl.Controls.Add(this.m_btnSetSop);
			this.m_grpSOPControl.Location = new System.Drawing.Point(7, 23);
			this.m_grpSOPControl.Name = "m_grpSOPControl";
			this.m_grpSOPControl.Size = new System.Drawing.Size(234, 80);
			this.m_grpSOPControl.TabIndex = 3;
			this.m_grpSOPControl.TabStop = false;
			this.m_grpSOPControl.Text = "Reset Control";
			// 
			// m_cboSopMod
			// 
			this.m_cboSopMod.FormattingEnabled = true;
			this.m_cboSopMod.Items.AddRange(new object[] {
			"Mode 2 (Development)",
			"Mode 4 (Functional - SPI)",
			"Mode 5 (Flash Program)",
			"Mode 6"});
			this.m_cboSopMod.Location = new System.Drawing.Point(82, 20);
			this.m_cboSopMod.Name = "m_cboSopMod";
			this.m_cboSopMod.Size = new System.Drawing.Size(140, 23);
			this.m_cboSopMod.TabIndex = 1;
			this.m_cboSopMod.Visible = false;
			// 
			// m_lblSOPMode
			// 
			this.m_lblSOPMode.AutoSize = true;
			this.m_lblSOPMode.Location = new System.Drawing.Point(13, 24);
			this.m_lblSOPMode.Name = "m_lblSOPMode";
			this.m_lblSOPMode.Size = new System.Drawing.Size(40, 15);
			this.m_lblSOPMode.TabIndex = 1;
			this.m_lblSOPMode.Text = "Reset";
			// 
			// m_btnSetSop
			// 
			this.m_btnSetSop.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.m_btnSetSop.ForeColor = System.Drawing.Color.Black;
			this.m_btnSetSop.Location = new System.Drawing.Point(150, 49);
			this.m_btnSetSop.Name = "m_btnSetSop";
			this.m_btnSetSop.Size = new System.Drawing.Size(72, 27);
			this.m_btnSetSop.TabIndex = 2;
			this.m_btnSetSop.Text = "Set (1)";
			this.m_btnSetSop.UseVisualStyleBackColor = false;
			// 
			// m_btnFullRst
			// 
			this.m_btnFullRst.Location = new System.Drawing.Point(8, 157);
			this.m_btnFullRst.Name = "m_btnFullRst";
			this.m_btnFullRst.Size = new System.Drawing.Size(112, 27);
			this.m_btnFullRst.TabIndex = 4;
			this.m_btnFullRst.Text = "Reset";
			this.m_btnFullRst.UseVisualStyleBackColor = true;
			// 
			// m_btnWarmRst
			// 
			this.m_btnWarmRst.Location = new System.Drawing.Point(130, 158);
			this.m_btnWarmRst.Name = "m_btnWarmRst";
			this.m_btnWarmRst.Size = new System.Drawing.Size(89, 21);
			this.m_btnWarmRst.TabIndex = 0;
			this.m_btnWarmRst.Text = "Warm Reset";
			this.m_btnWarmRst.UseVisualStyleBackColor = true;
			this.m_btnWarmRst.Visible = false;
			// 
			// m_lblDevStatus
			// 
			this.m_lblDevStatus.AutoSize = true;
			this.m_lblDevStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblDevStatus.ForeColor = System.Drawing.Color.Green;
			this.m_lblDevStatus.Location = new System.Drawing.Point(672, 93);
			this.m_lblDevStatus.Name = "m_lblDevStatus";
			this.m_lblDevStatus.Size = new System.Drawing.Size(51, 15);
			this.m_lblDevStatus.TabIndex = 43;
			this.m_lblDevStatus.Text = "AR12xx";
			// 
			// m_lblDevSts
			// 
			this.m_lblDevSts.AutoSize = true;
			this.m_lblDevSts.Location = new System.Drawing.Point(578, 93);
			this.m_lblDevSts.Name = "m_lblDevSts";
			this.m_lblDevSts.Size = new System.Drawing.Size(85, 15);
			this.m_lblDevSts.TabIndex = 49;
			this.m_lblDevSts.Text = "Device Status:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(550, 233);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 15);
			this.label1.TabIndex = 50;
			this.label1.Text = "Radar Link Version:";
			// 
			// m_lblRadarLinkVersion
			// 
			this.m_lblRadarLinkVersion.AutoSize = true;
			this.m_lblRadarLinkVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarLinkVersion.Location = new System.Drawing.Point(672, 233);
			this.m_lblRadarLinkVersion.Name = "m_lblRadarLinkVersion";
			this.m_lblRadarLinkVersion.Size = new System.Drawing.Size(72, 15);
			this.m_lblRadarLinkVersion.TabIndex = 51;
			this.m_lblRadarLinkVersion.Text = "00.00.00.00";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(557, 253);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 15);
			this.label3.TabIndex = 52;
			this.label3.Text = "Post Proc Version:";
			// 
			// m_lblMatlabPostProcVersion
			// 
			this.m_lblMatlabPostProcVersion.AutoSize = true;
			this.m_lblMatlabPostProcVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblMatlabPostProcVersion.Location = new System.Drawing.Point(672, 253);
			this.m_lblMatlabPostProcVersion.Name = "m_lblMatlabPostProcVersion";
			this.m_lblMatlabPostProcVersion.Size = new System.Drawing.Size(72, 15);
			this.m_lblMatlabPostProcVersion.TabIndex = 53;
			this.m_lblMatlabPostProcVersion.Text = "00.00.00.00";
			// 
			// f000195
			// 
			this.f000195.AutoSize = true;
			this.f000195.Location = new System.Drawing.Point(535, 273);
			this.f000195.Name = "f000195";
			this.f000195.Size = new System.Drawing.Size(130, 15);
			this.f000195.TabIndex = 54;
			this.f000195.Text = "DSP firmware Version:";
			this.f000195.Visible = false;
			// 
			// m_lblDSPFwVersion
			// 
			this.m_lblDSPFwVersion.AutoSize = true;
			this.m_lblDSPFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblDSPFwVersion.Location = new System.Drawing.Point(672, 273);
			this.m_lblDSPFwVersion.Name = "m_lblDSPFwVersion";
			this.m_lblDSPFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblDSPFwVersion.TabIndex = 55;
			this.m_lblDSPFwVersion.Text = "0.0.0.0.0.0.0";
			this.m_lblDSPFwVersion.Visible = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(511, 53);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(154, 15);
			this.label5.TabIndex = 56;
			this.label5.Text = "RS232 Connectivity Status:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(529, 73);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(135, 15);
			this.label6.TabIndex = 57;
			this.label6.Text = "SPI Connectivity Status:";
			// 
			// f000196
			// 
			this.f000196.AutoSize = true;
			this.f000196.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
			this.f000196.ForeColor = System.Drawing.Color.Red;
			this.f000196.Location = new System.Drawing.Point(672, 53);
			this.f000196.Name = "f000196";
			this.f000196.Size = new System.Drawing.Size(85, 15);
			this.f000196.TabIndex = 58;
			this.f000196.Text = "Disconnected";
			// 
			// m_lblSPIConnectivityStatus
			// 
			this.m_lblSPIConnectivityStatus.AutoSize = true;
			this.m_lblSPIConnectivityStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSPIConnectivityStatus.ForeColor = System.Drawing.Color.Red;
			this.m_lblSPIConnectivityStatus.Location = new System.Drawing.Point(672, 73);
			this.m_lblSPIConnectivityStatus.Name = "m_lblSPIConnectivityStatus";
			this.m_lblSPIConnectivityStatus.Size = new System.Drawing.Size(85, 15);
			this.m_lblSPIConnectivityStatus.TabIndex = 59;
			this.m_lblSPIConnectivityStatus.Text = "Disconnected";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(527, 11);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(138, 15);
			this.label7.TabIndex = 60;
			this.label7.Text = "No.of Devices Detected:";
			// 
			// m_lblNumOfRadarDevsDetected
			// 
			this.m_lblNumOfRadarDevsDetected.AutoSize = true;
			this.m_lblNumOfRadarDevsDetected.Location = new System.Drawing.Point(675, 11);
			this.m_lblNumOfRadarDevsDetected.Name = "m_lblNumOfRadarDevsDetected";
			this.m_lblNumOfRadarDevsDetected.Size = new System.Drawing.Size(14, 15);
			this.m_lblNumOfRadarDevsDetected.TabIndex = 61;
			this.m_lblNumOfRadarDevsDetected.Text = "0";
			// 
			// m_grpRadarMultiDevicesRS232OpSetting
			// 
			this.m_grpRadarMultiDevicesRS232OpSetting.Controls.Add(this.m_grpRadarDev4RS232OpSettings);
			this.m_grpRadarMultiDevicesRS232OpSetting.Controls.Add(this.m_grpRadarDev3RS232OpSettings);
			this.m_grpRadarMultiDevicesRS232OpSetting.Controls.Add(this.m_grpRadarDev2RS232OpSettings);
			this.m_grpRadarMultiDevicesRS232OpSetting.Location = new System.Drawing.Point(1242, 229);
			this.m_grpRadarMultiDevicesRS232OpSetting.Name = "m_grpRadarMultiDevicesRS232OpSetting";
			this.m_grpRadarMultiDevicesRS232OpSetting.Size = new System.Drawing.Size(216, 98);
			this.m_grpRadarMultiDevicesRS232OpSetting.TabIndex = 62;
			this.m_grpRadarMultiDevicesRS232OpSetting.TabStop = false;
			this.m_grpRadarMultiDevicesRS232OpSetting.Text = "RS232 Operations";
			this.m_grpRadarMultiDevicesRS232OpSetting.Visible = false;
			// 
			// m_grpRadarDev4RS232OpSettings
			// 
			this.m_grpRadarDev4RS232OpSettings.Controls.Add(this.label15);
			this.m_grpRadarDev4RS232OpSettings.Controls.Add(this.label14);
			this.m_grpRadarDev4RS232OpSettings.Controls.Add(this.m_btnRadarDev4Connect);
			this.m_grpRadarDev4RS232OpSettings.Controls.Add(this.m_btnRadarDev4RefreshPorts);
			this.m_grpRadarDev4RS232OpSettings.Controls.Add(this.m_cboRadarDevice4BaudRate);
			this.m_grpRadarDev4RS232OpSettings.Controls.Add(this.m_cboRadarDevice4ComPort);
			this.m_grpRadarDev4RS232OpSettings.Location = new System.Drawing.Point(420, 19);
			this.m_grpRadarDev4RS232OpSettings.Name = "m_grpRadarDev4RS232OpSettings";
			this.m_grpRadarDev4RS232OpSettings.Size = new System.Drawing.Size(200, 125);
			this.m_grpRadarDev4RS232OpSettings.TabIndex = 2;
			this.m_grpRadarDev4RS232OpSettings.TabStop = false;
			this.m_grpRadarDev4RS232OpSettings.Text = "Radar Device4";
			this.m_grpRadarDev4RS232OpSettings.Visible = false;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(2, 65);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(65, 15);
			this.label15.TabIndex = 5;
			this.label15.Text = "Baud Rate";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(1, 29);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(59, 15);
			this.label14.TabIndex = 4;
			this.label14.Text = "COM Port";
			// 
			// m_btnRadarDev4Connect
			// 
			this.m_btnRadarDev4Connect.Location = new System.Drawing.Point(73, 93);
			this.m_btnRadarDev4Connect.Name = "m_btnRadarDev4Connect";
			this.m_btnRadarDev4Connect.Size = new System.Drawing.Size(96, 27);
			this.m_btnRadarDev4Connect.TabIndex = 3;
			this.m_btnRadarDev4Connect.Text = "Connect";
			this.m_btnRadarDev4Connect.UseVisualStyleBackColor = true;
			// 
			// m_btnRadarDev4RefreshPorts
			// 
			this.m_btnRadarDev4RefreshPorts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.m_btnRadarDev4RefreshPorts.Location = new System.Drawing.Point(169, 26);
			this.m_btnRadarDev4RefreshPorts.Name = "m_btnRadarDev4RefreshPorts";
			this.m_btnRadarDev4RefreshPorts.Size = new System.Drawing.Size(24, 24);
			this.m_btnRadarDev4RefreshPorts.TabIndex = 2;
			this.m_btnRadarDev4RefreshPorts.UseVisualStyleBackColor = true;
			// 
			// m_cboRadarDevice4BaudRate
			// 
			this.m_cboRadarDevice4BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboRadarDevice4BaudRate.FormattingEnabled = true;
			this.m_cboRadarDevice4BaudRate.Location = new System.Drawing.Point(74, 61);
			this.m_cboRadarDevice4BaudRate.Name = "m_cboRadarDevice4BaudRate";
			this.m_cboRadarDevice4BaudRate.Size = new System.Drawing.Size(93, 23);
			this.m_cboRadarDevice4BaudRate.TabIndex = 1;
			// 
			// m_cboRadarDevice4ComPort
			// 
			this.m_cboRadarDevice4ComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboRadarDevice4ComPort.FormattingEnabled = true;
			this.m_cboRadarDevice4ComPort.Location = new System.Drawing.Point(73, 29);
			this.m_cboRadarDevice4ComPort.Name = "m_cboRadarDevice4ComPort";
			this.m_cboRadarDevice4ComPort.Size = new System.Drawing.Size(93, 23);
			this.m_cboRadarDevice4ComPort.TabIndex = 0;
			// 
			// m_grpRadarDev3RS232OpSettings
			// 
			this.m_grpRadarDev3RS232OpSettings.Controls.Add(this.label13);
			this.m_grpRadarDev3RS232OpSettings.Controls.Add(this.label12);
			this.m_grpRadarDev3RS232OpSettings.Controls.Add(this.m_btnRadarDev3Connect);
			this.m_grpRadarDev3RS232OpSettings.Controls.Add(this.m_btnRadarDev3RefreshPorts);
			this.m_grpRadarDev3RS232OpSettings.Controls.Add(this.m_cboRadarDevice3BaudRate);
			this.m_grpRadarDev3RS232OpSettings.Controls.Add(this.m_cboRadarDevice3ComPort);
			this.m_grpRadarDev3RS232OpSettings.Location = new System.Drawing.Point(219, 20);
			this.m_grpRadarDev3RS232OpSettings.Name = "m_grpRadarDev3RS232OpSettings";
			this.m_grpRadarDev3RS232OpSettings.Size = new System.Drawing.Size(200, 124);
			this.m_grpRadarDev3RS232OpSettings.TabIndex = 1;
			this.m_grpRadarDev3RS232OpSettings.TabStop = false;
			this.m_grpRadarDev3RS232OpSettings.Text = "Radar Device3";
			this.m_grpRadarDev3RS232OpSettings.Visible = false;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(2, 61);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(65, 15);
			this.label13.TabIndex = 5;
			this.label13.Text = "Baud Rate";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(0, 28);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(59, 15);
			this.label12.TabIndex = 4;
			this.label12.Text = "COM Port";
			// 
			// m_btnRadarDev3Connect
			// 
			this.m_btnRadarDev3Connect.Location = new System.Drawing.Point(67, 89);
			this.m_btnRadarDev3Connect.Name = "m_btnRadarDev3Connect";
			this.m_btnRadarDev3Connect.Size = new System.Drawing.Size(96, 27);
			this.m_btnRadarDev3Connect.TabIndex = 3;
			this.m_btnRadarDev3Connect.Text = "Connect";
			this.m_btnRadarDev3Connect.UseVisualStyleBackColor = true;
			// 
			// m_btnRadarDev3RefreshPorts
			// 
			this.m_btnRadarDev3RefreshPorts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.m_btnRadarDev3RefreshPorts.Location = new System.Drawing.Point(171, 25);
			this.m_btnRadarDev3RefreshPorts.Name = "m_btnRadarDev3RefreshPorts";
			this.m_btnRadarDev3RefreshPorts.Size = new System.Drawing.Size(24, 24);
			this.m_btnRadarDev3RefreshPorts.TabIndex = 2;
			this.m_btnRadarDev3RefreshPorts.UseVisualStyleBackColor = true;
			// 
			// m_cboRadarDevice3BaudRate
			// 
			this.m_cboRadarDevice3BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboRadarDevice3BaudRate.FormattingEnabled = true;
			this.m_cboRadarDevice3BaudRate.Location = new System.Drawing.Point(71, 57);
			this.m_cboRadarDevice3BaudRate.Name = "m_cboRadarDevice3BaudRate";
			this.m_cboRadarDevice3BaudRate.Size = new System.Drawing.Size(93, 23);
			this.m_cboRadarDevice3BaudRate.TabIndex = 1;
			// 
			// m_cboRadarDevice3ComPort
			// 
			this.m_cboRadarDevice3ComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboRadarDevice3ComPort.FormattingEnabled = true;
			this.m_cboRadarDevice3ComPort.Location = new System.Drawing.Point(71, 28);
			this.m_cboRadarDevice3ComPort.Name = "m_cboRadarDevice3ComPort";
			this.m_cboRadarDevice3ComPort.Size = new System.Drawing.Size(93, 23);
			this.m_cboRadarDevice3ComPort.TabIndex = 0;
			// 
			// m_grpRadarDev2RS232OpSettings
			// 
			this.m_grpRadarDev2RS232OpSettings.Controls.Add(this.m_btnRadarDev2RefreshPorts);
			this.m_grpRadarDev2RS232OpSettings.Controls.Add(this.m_cboRadarDevice2BaudRate);
			this.m_grpRadarDev2RS232OpSettings.Controls.Add(this.m_cboRadarDevice2ComPort);
			this.m_grpRadarDev2RS232OpSettings.Controls.Add(this.m_btnRadarDev2Connect);
			this.m_grpRadarDev2RS232OpSettings.Controls.Add(this.m_lblRadarDevBaudRate);
			this.m_grpRadarDev2RS232OpSettings.Controls.Add(this.m_lblRadarDev2ComPort);
			this.m_grpRadarDev2RS232OpSettings.Location = new System.Drawing.Point(0, 8);
			this.m_grpRadarDev2RS232OpSettings.Name = "m_grpRadarDev2RS232OpSettings";
			this.m_grpRadarDev2RS232OpSettings.Size = new System.Drawing.Size(213, 82);
			this.m_grpRadarDev2RS232OpSettings.TabIndex = 0;
			this.m_grpRadarDev2RS232OpSettings.TabStop = false;
			this.m_grpRadarDev2RS232OpSettings.Text = "Radar Device2";
			// 
			// m_btnRadarDev2RefreshPorts
			// 
			this.m_btnRadarDev2RefreshPorts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.m_btnRadarDev2RefreshPorts.Location = new System.Drawing.Point(177, 14);
			this.m_btnRadarDev2RefreshPorts.Name = "m_btnRadarDev2RefreshPorts";
			this.m_btnRadarDev2RefreshPorts.Size = new System.Drawing.Size(24, 24);
			this.m_btnRadarDev2RefreshPorts.TabIndex = 5;
			this.m_btnRadarDev2RefreshPorts.UseVisualStyleBackColor = true;
			// 
			// m_cboRadarDevice2BaudRate
			// 
			this.m_cboRadarDevice2BaudRate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cboRadarDevice2BaudRate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cboRadarDevice2BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboRadarDevice2BaudRate.FormattingEnabled = true;
			this.m_cboRadarDevice2BaudRate.Location = new System.Drawing.Point(77, 30);
			this.m_cboRadarDevice2BaudRate.Name = "m_cboRadarDevice2BaudRate";
			this.m_cboRadarDevice2BaudRate.Size = new System.Drawing.Size(93, 23);
			this.m_cboRadarDevice2BaudRate.TabIndex = 4;
			// 
			// m_cboRadarDevice2ComPort
			// 
			this.m_cboRadarDevice2ComPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cboRadarDevice2ComPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cboRadarDevice2ComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboRadarDevice2ComPort.FormattingEnabled = true;
			this.m_cboRadarDevice2ComPort.Location = new System.Drawing.Point(77, 14);
			this.m_cboRadarDevice2ComPort.Name = "m_cboRadarDevice2ComPort";
			this.m_cboRadarDevice2ComPort.Size = new System.Drawing.Size(93, 23);
			this.m_cboRadarDevice2ComPort.TabIndex = 3;
			// 
			// m_btnRadarDev2Connect
			// 
			this.m_btnRadarDev2Connect.Location = new System.Drawing.Point(77, 44);
			this.m_btnRadarDev2Connect.Name = "m_btnRadarDev2Connect";
			this.m_btnRadarDev2Connect.Size = new System.Drawing.Size(96, 27);
			this.m_btnRadarDev2Connect.TabIndex = 2;
			this.m_btnRadarDev2Connect.Text = "Connect";
			this.m_btnRadarDev2Connect.UseVisualStyleBackColor = true;
			// 
			// m_lblRadarDevBaudRate
			// 
			this.m_lblRadarDevBaudRate.AutoSize = true;
			this.m_lblRadarDevBaudRate.Location = new System.Drawing.Point(7, 31);
			this.m_lblRadarDevBaudRate.Name = "m_lblRadarDevBaudRate";
			this.m_lblRadarDevBaudRate.Size = new System.Drawing.Size(65, 15);
			this.m_lblRadarDevBaudRate.TabIndex = 1;
			this.m_lblRadarDevBaudRate.Text = "Baud Rate";
			// 
			// m_lblRadarDev2ComPort
			// 
			this.m_lblRadarDev2ComPort.AutoSize = true;
			this.m_lblRadarDev2ComPort.Location = new System.Drawing.Point(10, 14);
			this.m_lblRadarDev2ComPort.Name = "m_lblRadarDev2ComPort";
			this.m_lblRadarDev2ComPort.Size = new System.Drawing.Size(59, 15);
			this.m_lblRadarDev2ComPort.TabIndex = 0;
			this.m_lblRadarDev2ComPort.Text = "COM Port";
			// 
			// m_btnRefreshNoOfDevices
			// 
			this.m_btnRefreshNoOfDevices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.m_btnRefreshNoOfDevices.Location = new System.Drawing.Point(724, 9);
			this.m_btnRefreshNoOfDevices.Name = "m_btnRefreshNoOfDevices";
			this.m_btnRefreshNoOfDevices.Size = new System.Drawing.Size(27, 22);
			this.m_btnRefreshNoOfDevices.TabIndex = 63;
			this.m_btnRefreshNoOfDevices.UseVisualStyleBackColor = true;
			// 
			// m_lblRadarDev4MacFwVersion
			// 
			this.m_lblRadarDev4MacFwVersion.AutoSize = true;
			this.m_lblRadarDev4MacFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev4MacFwVersion.Location = new System.Drawing.Point(3, 158);
			this.m_lblRadarDev4MacFwVersion.Name = "m_lblRadarDev4MacFwVersion";
			this.m_lblRadarDev4MacFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblRadarDev4MacFwVersion.TabIndex = 99;
			this.m_lblRadarDev4MacFwVersion.Text = "0.0.0.0.0.0.0";
			// 
			// m_lblRadarDev4PHYFwVersion
			// 
			this.m_lblRadarDev4PHYFwVersion.AutoSize = true;
			this.m_lblRadarDev4PHYFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev4PHYFwVersion.Location = new System.Drawing.Point(3, 118);
			this.m_lblRadarDev4PHYFwVersion.Name = "m_lblRadarDev4PHYFwVersion";
			this.m_lblRadarDev4PHYFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblRadarDev4PHYFwVersion.TabIndex = 98;
			this.m_lblRadarDev4PHYFwVersion.Text = "0.0.0.0.0.0.0";
			// 
			// m_lblDev4Status
			// 
			this.m_lblDev4Status.AutoSize = true;
			this.m_lblDev4Status.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblDev4Status.ForeColor = System.Drawing.Color.Green;
			this.m_lblDev4Status.Location = new System.Drawing.Point(3, 78);
			this.m_lblDev4Status.Name = "m_lblDev4Status";
			this.m_lblDev4Status.Size = new System.Drawing.Size(51, 15);
			this.m_lblDev4Status.TabIndex = 97;
			this.m_lblDev4Status.Text = "AR12xx";
			// 
			// m_lblRadarDev4SPIConnectivityStatus
			// 
			this.m_lblRadarDev4SPIConnectivityStatus.AutoSize = true;
			this.m_lblRadarDev4SPIConnectivityStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev4SPIConnectivityStatus.ForeColor = System.Drawing.Color.Red;
			this.m_lblRadarDev4SPIConnectivityStatus.Location = new System.Drawing.Point(3, 58);
			this.m_lblRadarDev4SPIConnectivityStatus.Name = "m_lblRadarDev4SPIConnectivityStatus";
			this.m_lblRadarDev4SPIConnectivityStatus.Size = new System.Drawing.Size(85, 15);
			this.m_lblRadarDev4SPIConnectivityStatus.TabIndex = 93;
			this.m_lblRadarDev4SPIConnectivityStatus.Text = "Disconnected";
			// 
			// f000197
			// 
			this.f000197.AutoSize = true;
			this.f000197.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.f000197.ForeColor = System.Drawing.Color.Red;
			this.f000197.Location = new System.Drawing.Point(3, 38);
			this.f000197.Name = "f000197";
			this.f000197.Size = new System.Drawing.Size(85, 15);
			this.f000197.TabIndex = 91;
			this.f000197.Text = "Disconnected";
			// 
			// m_lblConnectivityRadarDev4Status
			// 
			this.m_lblConnectivityRadarDev4Status.AutoSize = true;
			this.m_lblConnectivityRadarDev4Status.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblConnectivityRadarDev4Status.ForeColor = System.Drawing.Color.Red;
			this.m_lblConnectivityRadarDev4Status.Location = new System.Drawing.Point(3, 18);
			this.m_lblConnectivityRadarDev4Status.Name = "m_lblConnectivityRadarDev4Status";
			this.m_lblConnectivityRadarDev4Status.Size = new System.Drawing.Size(85, 15);
			this.m_lblConnectivityRadarDev4Status.TabIndex = 90;
			this.m_lblConnectivityRadarDev4Status.Text = "Disconnected";
			// 
			// m_lblRadarDev3MacFwVersion
			// 
			this.m_lblRadarDev3MacFwVersion.AutoSize = true;
			this.m_lblRadarDev3MacFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev3MacFwVersion.Location = new System.Drawing.Point(3, 158);
			this.m_lblRadarDev3MacFwVersion.Name = "m_lblRadarDev3MacFwVersion";
			this.m_lblRadarDev3MacFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblRadarDev3MacFwVersion.TabIndex = 89;
			this.m_lblRadarDev3MacFwVersion.Text = "0.0.0.0.0.0.0";
			// 
			// m_lblRadarDev3PHYFwVersion
			// 
			this.m_lblRadarDev3PHYFwVersion.AutoSize = true;
			this.m_lblRadarDev3PHYFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev3PHYFwVersion.Location = new System.Drawing.Point(3, 118);
			this.m_lblRadarDev3PHYFwVersion.Name = "m_lblRadarDev3PHYFwVersion";
			this.m_lblRadarDev3PHYFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblRadarDev3PHYFwVersion.TabIndex = 88;
			this.m_lblRadarDev3PHYFwVersion.Text = "0.0.0.0.0.0.0";
			// 
			// m_lblDev3Status
			// 
			this.m_lblDev3Status.AutoSize = true;
			this.m_lblDev3Status.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblDev3Status.ForeColor = System.Drawing.Color.Green;
			this.m_lblDev3Status.Location = new System.Drawing.Point(3, 78);
			this.m_lblDev3Status.Name = "m_lblDev3Status";
			this.m_lblDev3Status.Size = new System.Drawing.Size(51, 15);
			this.m_lblDev3Status.TabIndex = 87;
			this.m_lblDev3Status.Text = "AR12xx";
			// 
			// m_lblRadarDev3SPIConnectivityStatus
			// 
			this.m_lblRadarDev3SPIConnectivityStatus.AutoSize = true;
			this.m_lblRadarDev3SPIConnectivityStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev3SPIConnectivityStatus.ForeColor = System.Drawing.Color.Red;
			this.m_lblRadarDev3SPIConnectivityStatus.Location = new System.Drawing.Point(3, 58);
			this.m_lblRadarDev3SPIConnectivityStatus.Name = "m_lblRadarDev3SPIConnectivityStatus";
			this.m_lblRadarDev3SPIConnectivityStatus.Size = new System.Drawing.Size(85, 15);
			this.m_lblRadarDev3SPIConnectivityStatus.TabIndex = 83;
			this.m_lblRadarDev3SPIConnectivityStatus.Text = "Disconnected";
			// 
			// f000198
			// 
			this.f000198.AutoSize = true;
			this.f000198.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.f000198.ForeColor = System.Drawing.Color.Red;
			this.f000198.Location = new System.Drawing.Point(3, 38);
			this.f000198.Name = "f000198";
			this.f000198.Size = new System.Drawing.Size(85, 15);
			this.f000198.TabIndex = 81;
			this.f000198.Text = "Disconnected";
			// 
			// m_lblConnectivityRadarDev3Status
			// 
			this.m_lblConnectivityRadarDev3Status.AutoSize = true;
			this.m_lblConnectivityRadarDev3Status.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblConnectivityRadarDev3Status.ForeColor = System.Drawing.Color.Red;
			this.m_lblConnectivityRadarDev3Status.Location = new System.Drawing.Point(3, 18);
			this.m_lblConnectivityRadarDev3Status.Name = "m_lblConnectivityRadarDev3Status";
			this.m_lblConnectivityRadarDev3Status.Size = new System.Drawing.Size(85, 15);
			this.m_lblConnectivityRadarDev3Status.TabIndex = 80;
			this.m_lblConnectivityRadarDev3Status.Text = "Disconnected";
			// 
			// m_lblRadarDev2MacFwVersion
			// 
			this.m_lblRadarDev2MacFwVersion.AutoSize = true;
			this.m_lblRadarDev2MacFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev2MacFwVersion.Location = new System.Drawing.Point(3, 158);
			this.m_lblRadarDev2MacFwVersion.Name = "m_lblRadarDev2MacFwVersion";
			this.m_lblRadarDev2MacFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblRadarDev2MacFwVersion.TabIndex = 79;
			this.m_lblRadarDev2MacFwVersion.Text = "0.0.0.0.0.0.0";
			// 
			// m_lblRadarDev2PHYFwVersion
			// 
			this.m_lblRadarDev2PHYFwVersion.AutoSize = true;
			this.m_lblRadarDev2PHYFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev2PHYFwVersion.Location = new System.Drawing.Point(3, 118);
			this.m_lblRadarDev2PHYFwVersion.Name = "m_lblRadarDev2PHYFwVersion";
			this.m_lblRadarDev2PHYFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblRadarDev2PHYFwVersion.TabIndex = 78;
			this.m_lblRadarDev2PHYFwVersion.Text = "0.0.0.0.0.0.0";
			// 
			// m_lblDev2Status
			// 
			this.m_lblDev2Status.AutoSize = true;
			this.m_lblDev2Status.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblDev2Status.ForeColor = System.Drawing.Color.Green;
			this.m_lblDev2Status.Location = new System.Drawing.Point(3, 78);
			this.m_lblDev2Status.Name = "m_lblDev2Status";
			this.m_lblDev2Status.Size = new System.Drawing.Size(51, 15);
			this.m_lblDev2Status.TabIndex = 77;
			this.m_lblDev2Status.Text = "AR12xx";
			// 
			// m_lblRadarDev2SPIConnectivityStatus
			// 
			this.m_lblRadarDev2SPIConnectivityStatus.AutoSize = true;
			this.m_lblRadarDev2SPIConnectivityStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev2SPIConnectivityStatus.ForeColor = System.Drawing.Color.Red;
			this.m_lblRadarDev2SPIConnectivityStatus.Location = new System.Drawing.Point(3, 58);
			this.m_lblRadarDev2SPIConnectivityStatus.Name = "m_lblRadarDev2SPIConnectivityStatus";
			this.m_lblRadarDev2SPIConnectivityStatus.Size = new System.Drawing.Size(85, 15);
			this.m_lblRadarDev2SPIConnectivityStatus.TabIndex = 73;
			this.m_lblRadarDev2SPIConnectivityStatus.Text = "Disconnected";
			// 
			// f000199
			// 
			this.f000199.AutoSize = true;
			this.f000199.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.f000199.ForeColor = System.Drawing.Color.Red;
			this.f000199.Location = new System.Drawing.Point(3, 38);
			this.f000199.Name = "f000199";
			this.f000199.Size = new System.Drawing.Size(85, 15);
			this.f000199.TabIndex = 70;
			this.f000199.Text = "Disconnected";
			// 
			// m_lblConnectivityRadarDev2Status
			// 
			this.m_lblConnectivityRadarDev2Status.AutoSize = true;
			this.m_lblConnectivityRadarDev2Status.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblConnectivityRadarDev2Status.ForeColor = System.Drawing.Color.Red;
			this.m_lblConnectivityRadarDev2Status.Location = new System.Drawing.Point(3, 18);
			this.m_lblConnectivityRadarDev2Status.Name = "m_lblConnectivityRadarDev2Status";
			this.m_lblConnectivityRadarDev2Status.Size = new System.Drawing.Size(85, 15);
			this.m_lblConnectivityRadarDev2Status.TabIndex = 67;
			this.m_lblConnectivityRadarDev2Status.Text = "Disconnected";
			// 
			// m_grpRadarDev2StatusSettings
			// 
			this.m_grpRadarDev2StatusSettings.Controls.Add(this.m_lblRadarDev2DieIDInfo);
			this.m_grpRadarDev2StatusSettings.Controls.Add(this.m_lblRadarDev2BSSPatchFwVersion);
			this.m_grpRadarDev2StatusSettings.Controls.Add(this.m_lblRadarDev2MSSPatchFwVersion);
			this.m_grpRadarDev2StatusSettings.Controls.Add(this.m_lblConnectivityRadarDev2Status);
			this.m_grpRadarDev2StatusSettings.Controls.Add(this.f000199);
			this.m_grpRadarDev2StatusSettings.Controls.Add(this.m_lblRadarDev2SPIConnectivityStatus);
			this.m_grpRadarDev2StatusSettings.Controls.Add(this.m_lblDev2Status);
			this.m_grpRadarDev2StatusSettings.Controls.Add(this.m_lblRadarDev2PHYFwVersion);
			this.m_grpRadarDev2StatusSettings.Controls.Add(this.m_lblRadarDev2MacFwVersion);
			this.m_grpRadarDev2StatusSettings.Location = new System.Drawing.Point(893, 17);
			this.m_grpRadarDev2StatusSettings.Name = "m_grpRadarDev2StatusSettings";
			this.m_grpRadarDev2StatusSettings.Size = new System.Drawing.Size(225, 202);
			this.m_grpRadarDev2StatusSettings.TabIndex = 68;
			this.m_grpRadarDev2StatusSettings.TabStop = false;
			this.m_grpRadarDev2StatusSettings.Text = "Radar Device2";
			// 
			// m_lblRadarDev2DieIDInfo
			// 
			this.m_lblRadarDev2DieIDInfo.AutoSize = true;
			this.m_lblRadarDev2DieIDInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev2DieIDInfo.Location = new System.Drawing.Point(3, 98);
			this.m_lblRadarDev2DieIDInfo.Name = "m_lblRadarDev2DieIDInfo";
			this.m_lblRadarDev2DieIDInfo.Size = new System.Drawing.Size(24, 15);
			this.m_lblRadarDev2DieIDInfo.TabIndex = 82;
			this.m_lblRadarDev2DieIDInfo.Text = "0.0";
			// 
			// m_lblRadarDev2BSSPatchFwVersion
			// 
			this.m_lblRadarDev2BSSPatchFwVersion.AutoSize = true;
			this.m_lblRadarDev2BSSPatchFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev2BSSPatchFwVersion.Location = new System.Drawing.Point(3, 138);
			this.m_lblRadarDev2BSSPatchFwVersion.Name = "m_lblRadarDev2BSSPatchFwVersion";
			this.m_lblRadarDev2BSSPatchFwVersion.Size = new System.Drawing.Size(44, 15);
			this.m_lblRadarDev2BSSPatchFwVersion.TabIndex = 81;
			this.m_lblRadarDev2BSSPatchFwVersion.Text = "0.0.0.0";
			// 
			// m_lblRadarDev2MSSPatchFwVersion
			// 
			this.m_lblRadarDev2MSSPatchFwVersion.AutoSize = true;
			this.m_lblRadarDev2MSSPatchFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev2MSSPatchFwVersion.Location = new System.Drawing.Point(3, 178);
			this.m_lblRadarDev2MSSPatchFwVersion.Name = "m_lblRadarDev2MSSPatchFwVersion";
			this.m_lblRadarDev2MSSPatchFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblRadarDev2MSSPatchFwVersion.TabIndex = 80;
			this.m_lblRadarDev2MSSPatchFwVersion.Text = "0.0.0.0.0.0.0";
			// 
			// m_grpRadarDev3StatusSettings
			// 
			this.m_grpRadarDev3StatusSettings.Controls.Add(this.m_lblRadarDev3DieIDInfo);
			this.m_grpRadarDev3StatusSettings.Controls.Add(this.m_lblRadarDev3BSSPatchFwVersion);
			this.m_grpRadarDev3StatusSettings.Controls.Add(this.m_lblRadarDev3MSSPatchFwVersion);
			this.m_grpRadarDev3StatusSettings.Controls.Add(this.m_lblConnectivityRadarDev3Status);
			this.m_grpRadarDev3StatusSettings.Controls.Add(this.f000198);
			this.m_grpRadarDev3StatusSettings.Controls.Add(this.m_lblRadarDev3SPIConnectivityStatus);
			this.m_grpRadarDev3StatusSettings.Controls.Add(this.m_lblDev3Status);
			this.m_grpRadarDev3StatusSettings.Controls.Add(this.m_lblRadarDev3PHYFwVersion);
			this.m_grpRadarDev3StatusSettings.Controls.Add(this.m_lblRadarDev3MacFwVersion);
			this.m_grpRadarDev3StatusSettings.Location = new System.Drawing.Point(1127, 18);
			this.m_grpRadarDev3StatusSettings.Name = "m_grpRadarDev3StatusSettings";
			this.m_grpRadarDev3StatusSettings.Size = new System.Drawing.Size(218, 201);
			this.m_grpRadarDev3StatusSettings.TabIndex = 69;
			this.m_grpRadarDev3StatusSettings.TabStop = false;
			this.m_grpRadarDev3StatusSettings.Text = "Radar Device3";
			// 
			// m_lblRadarDev3DieIDInfo
			// 
			this.m_lblRadarDev3DieIDInfo.AutoSize = true;
			this.m_lblRadarDev3DieIDInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev3DieIDInfo.Location = new System.Drawing.Point(3, 98);
			this.m_lblRadarDev3DieIDInfo.Name = "m_lblRadarDev3DieIDInfo";
			this.m_lblRadarDev3DieIDInfo.Size = new System.Drawing.Size(24, 15);
			this.m_lblRadarDev3DieIDInfo.TabIndex = 92;
			this.m_lblRadarDev3DieIDInfo.Text = "0.0";
			// 
			// m_lblRadarDev3BSSPatchFwVersion
			// 
			this.m_lblRadarDev3BSSPatchFwVersion.AutoSize = true;
			this.m_lblRadarDev3BSSPatchFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev3BSSPatchFwVersion.Location = new System.Drawing.Point(3, 138);
			this.m_lblRadarDev3BSSPatchFwVersion.Name = "m_lblRadarDev3BSSPatchFwVersion";
			this.m_lblRadarDev3BSSPatchFwVersion.Size = new System.Drawing.Size(44, 15);
			this.m_lblRadarDev3BSSPatchFwVersion.TabIndex = 91;
			this.m_lblRadarDev3BSSPatchFwVersion.Text = "0.0.0.0";
			// 
			// m_lblRadarDev3MSSPatchFwVersion
			// 
			this.m_lblRadarDev3MSSPatchFwVersion.AutoSize = true;
			this.m_lblRadarDev3MSSPatchFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev3MSSPatchFwVersion.Location = new System.Drawing.Point(3, 178);
			this.m_lblRadarDev3MSSPatchFwVersion.Name = "m_lblRadarDev3MSSPatchFwVersion";
			this.m_lblRadarDev3MSSPatchFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblRadarDev3MSSPatchFwVersion.TabIndex = 90;
			this.m_lblRadarDev3MSSPatchFwVersion.Text = "0.0.0.0.0.0.0";
			// 
			// m_grpRadarDev4StatusSettings
			// 
			this.m_grpRadarDev4StatusSettings.Controls.Add(this.m_lblRadarDev4DieIDInfo);
			this.m_grpRadarDev4StatusSettings.Controls.Add(this.m_lblRadarDev4BSSPatchFwVersion);
			this.m_grpRadarDev4StatusSettings.Controls.Add(this.m_lblRadarDev4MSSPatchFwVersion);
			this.m_grpRadarDev4StatusSettings.Controls.Add(this.m_lblRadarDev4MacFwVersion);
			this.m_grpRadarDev4StatusSettings.Controls.Add(this.m_lblConnectivityRadarDev4Status);
			this.m_grpRadarDev4StatusSettings.Controls.Add(this.m_lblRadarDev4PHYFwVersion);
			this.m_grpRadarDev4StatusSettings.Controls.Add(this.f000197);
			this.m_grpRadarDev4StatusSettings.Controls.Add(this.m_lblDev4Status);
			this.m_grpRadarDev4StatusSettings.Controls.Add(this.m_lblRadarDev4SPIConnectivityStatus);
			this.m_grpRadarDev4StatusSettings.Location = new System.Drawing.Point(1353, 18);
			this.m_grpRadarDev4StatusSettings.Name = "m_grpRadarDev4StatusSettings";
			this.m_grpRadarDev4StatusSettings.Size = new System.Drawing.Size(237, 201);
			this.m_grpRadarDev4StatusSettings.TabIndex = 70;
			this.m_grpRadarDev4StatusSettings.TabStop = false;
			this.m_grpRadarDev4StatusSettings.Text = "Radar Device4";
			// 
			// m_lblRadarDev4DieIDInfo
			// 
			this.m_lblRadarDev4DieIDInfo.AutoSize = true;
			this.m_lblRadarDev4DieIDInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev4DieIDInfo.Location = new System.Drawing.Point(3, 98);
			this.m_lblRadarDev4DieIDInfo.Name = "m_lblRadarDev4DieIDInfo";
			this.m_lblRadarDev4DieIDInfo.Size = new System.Drawing.Size(24, 15);
			this.m_lblRadarDev4DieIDInfo.TabIndex = 100;
			this.m_lblRadarDev4DieIDInfo.Text = "0.0";
			// 
			// m_lblRadarDev4BSSPatchFwVersion
			// 
			this.m_lblRadarDev4BSSPatchFwVersion.AutoSize = true;
			this.m_lblRadarDev4BSSPatchFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev4BSSPatchFwVersion.Location = new System.Drawing.Point(3, 138);
			this.m_lblRadarDev4BSSPatchFwVersion.Name = "m_lblRadarDev4BSSPatchFwVersion";
			this.m_lblRadarDev4BSSPatchFwVersion.Size = new System.Drawing.Size(44, 15);
			this.m_lblRadarDev4BSSPatchFwVersion.TabIndex = 93;
			this.m_lblRadarDev4BSSPatchFwVersion.Text = "0.0.0.0";
			// 
			// m_lblRadarDev4MSSPatchFwVersion
			// 
			this.m_lblRadarDev4MSSPatchFwVersion.AutoSize = true;
			this.m_lblRadarDev4MSSPatchFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblRadarDev4MSSPatchFwVersion.Location = new System.Drawing.Point(3, 178);
			this.m_lblRadarDev4MSSPatchFwVersion.Name = "m_lblRadarDev4MSSPatchFwVersion";
			this.m_lblRadarDev4MSSPatchFwVersion.Size = new System.Drawing.Size(74, 15);
			this.m_lblRadarDev4MSSPatchFwVersion.TabIndex = 93;
			this.m_lblRadarDev4MSSPatchFwVersion.Text = "0.0.0.0.0.0.0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(5, 19);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(58, 14);
			this.label8.TabIndex = 71;
			this.label8.Text = "Near MMIC";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(6, 38);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(92, 14);
			this.label9.TabIndex = 72;
			this.label9.Text = "Away From MMIC";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(145, 20);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(60, 14);
			this.label10.TabIndex = 73;
			this.label10.Text = "BottomRX1";
			this.label10.Visible = false;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(145, 41);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(43, 14);
			this.label11.TabIndex = 74;
			this.label11.Text = "TopTX3";
			this.label11.Visible = false;
			// 
			// m_lblTopNearTX3
			// 
			this.m_lblTopNearTX3.AutoSize = true;
			this.m_lblTopNearTX3.Location = new System.Drawing.Point(203, 41);
			this.m_lblTopNearTX3.Name = "m_lblTopNearTX3";
			this.m_lblTopNearTX3.Size = new System.Drawing.Size(24, 15);
			this.m_lblTopNearTX3.TabIndex = 78;
			this.m_lblTopNearTX3.Text = "0.0";
			this.m_lblTopNearTX3.Visible = false;
			// 
			// m_lblBottomNearRX1
			// 
			this.m_lblBottomNearRX1.AutoSize = true;
			this.m_lblBottomNearRX1.Location = new System.Drawing.Point(203, 19);
			this.m_lblBottomNearRX1.Name = "m_lblBottomNearRX1";
			this.m_lblBottomNearRX1.Size = new System.Drawing.Size(24, 15);
			this.m_lblBottomNearRX1.TabIndex = 77;
			this.m_lblBottomNearRX1.Text = "0.0";
			this.m_lblBottomNearRX1.Visible = false;
			// 
			// m_lblBottomNearTX2
			// 
			this.m_lblBottomNearTX2.AutoSize = true;
			this.m_lblBottomNearTX2.Location = new System.Drawing.Point(110, 40);
			this.m_lblBottomNearTX2.Name = "m_lblBottomNearTX2";
			this.m_lblBottomNearTX2.Size = new System.Drawing.Size(24, 15);
			this.m_lblBottomNearTX2.TabIndex = 76;
			this.m_lblBottomNearTX2.Text = "0.0";
			// 
			// m_lblNearRx
			// 
			this.m_lblNearRx.AutoSize = true;
			this.m_lblNearRx.Location = new System.Drawing.Point(559, 265);
			this.m_lblNearRx.Name = "m_lblNearRx";
			this.m_lblNearRx.Size = new System.Drawing.Size(0, 15);
			this.m_lblNearRx.TabIndex = 75;
			// 
			// m_btnTempSensorGet
			// 
			this.m_btnTempSensorGet.Location = new System.Drawing.Point(893, 296);
			this.m_btnTempSensorGet.Name = "m_btnTempSensorGet";
			this.m_btnTempSensorGet.Size = new System.Drawing.Size(59, 23);
			this.m_btnTempSensorGet.TabIndex = 79;
			this.m_btnTempSensorGet.Text = "Get";
			this.m_btnTempSensorGet.UseVisualStyleBackColor = true;
			this.m_btnTempSensorGet.Visible = false;
			// 
			// m_grpTemperatureSensor
			// 
			this.m_grpTemperatureSensor.Controls.Add(this.m_lblTopNearRX1);
			this.m_grpTemperatureSensor.Controls.Add(this.m_lblTopNearTX3);
			this.m_grpTemperatureSensor.Controls.Add(this.label8);
			this.m_grpTemperatureSensor.Controls.Add(this.m_lblBottomNearRX1);
			this.m_grpTemperatureSensor.Controls.Add(this.label9);
			this.m_grpTemperatureSensor.Controls.Add(this.m_lblBottomNearTX2);
			this.m_grpTemperatureSensor.Controls.Add(this.label10);
			this.m_grpTemperatureSensor.Controls.Add(this.label11);
			this.m_grpTemperatureSensor.Location = new System.Drawing.Point(893, 226);
			this.m_grpTemperatureSensor.Name = "m_grpTemperatureSensor";
			this.m_grpTemperatureSensor.Size = new System.Drawing.Size(241, 69);
			this.m_grpTemperatureSensor.TabIndex = 80;
			this.m_grpTemperatureSensor.TabStop = false;
			this.m_grpTemperatureSensor.Text = "On Board Temperature Sensor";
			this.m_grpTemperatureSensor.Visible = false;
			// 
			// m_lblTopNearRX1
			// 
			this.m_lblTopNearRX1.AutoSize = true;
			this.m_lblTopNearRX1.Location = new System.Drawing.Point(110, 19);
			this.m_lblTopNearRX1.Name = "m_lblTopNearRX1";
			this.m_lblTopNearRX1.Size = new System.Drawing.Size(24, 15);
			this.m_lblTopNearRX1.TabIndex = 80;
			this.m_lblTopNearRX1.Text = "0.0";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(619, 113);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(42, 15);
			this.label16.TabIndex = 81;
			this.label16.Text = "Die Id:";
			// 
			// m_lblDieIDInfo
			// 
			this.m_lblDieIDInfo.AutoSize = true;
			this.m_lblDieIDInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblDieIDInfo.Location = new System.Drawing.Point(672, 113);
			this.m_lblDieIDInfo.Name = "m_lblDieIDInfo";
			this.m_lblDieIDInfo.Size = new System.Drawing.Size(24, 15);
			this.m_lblDieIDInfo.TabIndex = 82;
			this.m_lblDieIDInfo.Text = "0.0";
			// 
			// m_lblBSSPatchFwVersion
			// 
			this.m_lblBSSPatchFwVersion.AutoSize = true;
			this.m_lblBSSPatchFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblBSSPatchFwVersion.Location = new System.Drawing.Point(672, 153);
			this.m_lblBSSPatchFwVersion.Name = "m_lblBSSPatchFwVersion";
			this.m_lblBSSPatchFwVersion.Size = new System.Drawing.Size(44, 15);
			this.m_lblBSSPatchFwVersion.TabIndex = 83;
			this.m_lblBSSPatchFwVersion.Text = "0.0.0.0";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(525, 153);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(138, 15);
			this.label18.TabIndex = 84;
			this.label18.Text = "BSS Patch firmware ver:";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(525, 193);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(139, 15);
			this.label19.TabIndex = 85;
			this.label19.Text = "MSS Patch firmware ver:";
			// 
			// m_lblMSSPatchFwVersion
			// 
			this.m_lblMSSPatchFwVersion.AutoSize = true;
			this.m_lblMSSPatchFwVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblMSSPatchFwVersion.Location = new System.Drawing.Point(672, 193);
			this.m_lblMSSPatchFwVersion.Name = "m_lblMSSPatchFwVersion";
			this.m_lblMSSPatchFwVersion.Size = new System.Drawing.Size(44, 15);
			this.m_lblMSSPatchFwVersion.TabIndex = 86;
			this.m_lblMSSPatchFwVersion.Text = "0.0.0.0";
			// 
			// m_lblGuiVersion
			// 
			this.m_lblGuiVersion.AutoSize = true;
			this.m_lblGuiVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblGuiVersion.Location = new System.Drawing.Point(672, 213);
			this.m_lblGuiVersion.Name = "m_lblGuiVersion";
			this.m_lblGuiVersion.Size = new System.Drawing.Size(44, 15);
			this.m_lblGuiVersion.TabIndex = 32;
			this.m_lblGuiVersion.Text = "1.0.9.0";
			// 
			// f00019a
			// 
			this.f00019a.AutoSize = true;
			this.f00019a.Location = new System.Drawing.Point(19, 14);
			this.f00019a.Name = "f00019a";
			this.f00019a.Size = new System.Drawing.Size(76, 19);
			this.f00019a.TabIndex = 87;
			this.f00019a.TabStop = true;
			this.f00019a.Text = "XWR12xx";
			this.f00019a.UseVisualStyleBackColor = true;
			// 
			// f00019b
			// 
			this.f00019b.AutoSize = true;
			this.f00019b.Location = new System.Drawing.Point(19, 34);
			this.f00019b.Name = "f00019b";
			this.f00019b.Size = new System.Drawing.Size(76, 19);
			this.f00019b.TabIndex = 88;
			this.f00019b.TabStop = true;
			this.f00019b.Text = "XWR14xx";
			this.f00019b.UseVisualStyleBackColor = true;
			// 
			// f00019c
			// 
			this.f00019c.AutoSize = true;
			this.f00019c.Location = new System.Drawing.Point(19, 57);
			this.f00019c.Name = "f00019c";
			this.f00019c.Size = new System.Drawing.Size(76, 19);
			this.f00019c.TabIndex = 89;
			this.f00019c.TabStop = true;
			this.f00019c.Text = "XWR16xx";
			this.f00019c.UseVisualStyleBackColor = true;
			// 
			// m_grpDeviceVariantTypes
			// 
			this.m_grpDeviceVariantTypes.Controls.Add(this.f00019d);
			this.m_grpDeviceVariantTypes.Controls.Add(this.m_RadioBtnxWR1843);
			this.m_grpDeviceVariantTypes.Controls.Add(this.m_RadioBtnxWR6843);
			this.m_grpDeviceVariantTypes.Controls.Add(this.f00019a);
			this.m_grpDeviceVariantTypes.Controls.Add(this.f00019c);
			this.m_grpDeviceVariantTypes.Controls.Add(this.f00019b);
			this.m_grpDeviceVariantTypes.Location = new System.Drawing.Point(293, 208);
			this.m_grpDeviceVariantTypes.Name = "m_grpDeviceVariantTypes";
			this.m_grpDeviceVariantTypes.Size = new System.Drawing.Size(214, 100);
			this.m_grpDeviceVariantTypes.TabIndex = 90;
			this.m_grpDeviceVariantTypes.TabStop = false;
			this.m_grpDeviceVariantTypes.Text = "Device Variant";
			// 
			// f00019d
			// 
			this.f00019d.AutoSize = true;
			this.f00019d.Location = new System.Drawing.Point(109, 57);
			this.f00019d.Name = "f00019d";
			this.f00019d.Size = new System.Drawing.Size(76, 19);
			this.f00019d.TabIndex = 93;
			this.f00019d.TabStop = true;
			this.f00019d.Text = "XWR22xx";
			this.f00019d.UseVisualStyleBackColor = true;
			this.f00019d.Visible = false;
			// 
			// m_RadioBtnxWR1843
			// 
			this.m_RadioBtnxWR1843.AutoSize = true;
			this.m_RadioBtnxWR1843.Location = new System.Drawing.Point(109, 34);
			this.m_RadioBtnxWR1843.Name = "m_RadioBtnxWR1843";
			this.m_RadioBtnxWR1843.Size = new System.Drawing.Size(78, 19);
			this.m_RadioBtnxWR1843.TabIndex = 92;
			this.m_RadioBtnxWR1843.TabStop = true;
			this.m_RadioBtnxWR1843.Text = "xWR1843";
			this.m_RadioBtnxWR1843.UseVisualStyleBackColor = true;
			// 
			// m_RadioBtnxWR6843
			// 
			this.m_RadioBtnxWR6843.AutoSize = true;
			this.m_RadioBtnxWR6843.Location = new System.Drawing.Point(109, 14);
			this.m_RadioBtnxWR6843.Name = "m_RadioBtnxWR6843";
			this.m_RadioBtnxWR6843.Size = new System.Drawing.Size(78, 19);
			this.m_RadioBtnxWR6843.TabIndex = 91;
			this.m_RadioBtnxWR6843.TabStop = true;
			this.m_RadioBtnxWR6843.Text = "xWR6843";
			this.m_RadioBtnxWR6843.UseVisualStyleBackColor = true;
			// 
			// m_RadioBtn77GHzRadarDev
			// 
			this.m_RadioBtn77GHzRadarDev.AutoSize = true;
			this.m_RadioBtn77GHzRadarDev.Location = new System.Drawing.Point(23, 39);
			this.m_RadioBtn77GHzRadarDev.Name = "m_RadioBtn77GHzRadarDev";
			this.m_RadioBtn77GHzRadarDev.Size = new System.Drawing.Size(65, 19);
			this.m_RadioBtn77GHzRadarDev.TabIndex = 91;
			this.m_RadioBtn77GHzRadarDev.Text = "77 GHz";
			this.m_RadioBtn77GHzRadarDev.UseVisualStyleBackColor = true;
			// 
			// m_RadioBtn60GHzRadarDev
			// 
			this.m_RadioBtn60GHzRadarDev.AutoSize = true;
			this.m_RadioBtn60GHzRadarDev.Location = new System.Drawing.Point(22, 18);
			this.m_RadioBtn60GHzRadarDev.Name = "m_RadioBtn60GHzRadarDev";
			this.m_RadioBtn60GHzRadarDev.Size = new System.Drawing.Size(65, 19);
			this.m_RadioBtn60GHzRadarDev.TabIndex = 90;
			this.m_RadioBtn60GHzRadarDev.Text = "60 GHz";
			this.m_RadioBtn60GHzRadarDev.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.m_RadioBtn60GHzRadarDev);
			this.groupBox2.Controls.Add(this.m_RadioBtn77GHzRadarDev);
			this.groupBox2.Location = new System.Drawing.Point(123, 208);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(164, 72);
			this.groupBox2.TabIndex = 92;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Operating Frequency";
			// 
			// m_lblI2CAddress
			// 
			this.m_lblI2CAddress.AutoSize = true;
			this.m_lblI2CAddress.Location = new System.Drawing.Point(781, 470);
			this.m_lblI2CAddress.Name = "m_lblI2CAddress";
			this.m_lblI2CAddress.Size = new System.Drawing.Size(106, 15);
			this.m_lblI2CAddress.TabIndex = 93;
			this.m_lblI2CAddress.Text = "I2C Address (Hex)";
			this.m_lblI2CAddress.Visible = false;
			// 
			// m_nudI2CAddress
			// 
			this.m_nudI2CAddress.Hexadecimal = true;
			this.m_nudI2CAddress.Location = new System.Drawing.Point(916, 466);
			this.m_nudI2CAddress.Maximum = new decimal(new int[] {
			47,
			0,
			0,
			0});
			this.m_nudI2CAddress.Minimum = new decimal(new int[] {
			40,
			0,
			0,
			0});
			this.m_nudI2CAddress.Name = "m_nudI2CAddress";
			this.m_nudI2CAddress.Size = new System.Drawing.Size(66, 21);
			this.m_nudI2CAddress.TabIndex = 94;
			this.m_nudI2CAddress.Value = new decimal(new int[] {
			40,
			0,
			0,
			0});
			this.m_nudI2CAddress.Visible = false;
			// 
			// ConnectTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_nudI2CAddress);
			this.Controls.Add(this.m_lblPhyVersion);
			this.Controls.Add(this.m_btnTempSensorGet);
			this.Controls.Add(this.m_lblI2CAddress);
			this.Controls.Add(this.m_lblStatus);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.m_lblMacVersion);
			this.Controls.Add(this.m_grpDeviceVariantTypes);
			this.Controls.Add(this.m_lblMSSPatchFwVersion);
			this.Controls.Add(this.m_grpTemperatureSensor);
			this.Controls.Add(this.m_lblMacFwVersion);
			this.Controls.Add(this.m_lblNearRx);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.m_grpRadarDev4StatusSettings);
			this.Controls.Add(this.m_lblConnectivityStatus);
			this.Controls.Add(this.m_grpRadarDev3StatusSettings);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.m_grpRadarDev2StatusSettings);
			this.Controls.Add(this.m_lblDllVersion);
			this.Controls.Add(this.m_btnRefreshNoOfDevices);
			this.Controls.Add(this.m_lblBSSPatchFwVersion);
			this.Controls.Add(this.m_grpRadarMultiDevicesRS232OpSetting);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_lblNumOfRadarDevsDetected);
			this.Controls.Add(this.m_lblDieIDInfo);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.m_lblGuiVersion);
			this.Controls.Add(this.m_grpBoardCtrl);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.m_lblPHYFwVersion);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_lblDevStatus);
			this.Controls.Add(this.m_chkPollConnection);
			this.Controls.Add(this.m_lblDevSts);
			this.Controls.Add(this.m_grpFirmWare);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.f000196);
			this.Controls.Add(this.m_lblRadarLinkVersion);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_lblSPIConnectivityStatus);
			this.Controls.Add(this.m_lblMatlabPostProcVersion);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.f000195);
			this.Controls.Add(this.m_lblDSPFwVersion);
			this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "ConnectTab";
			this.Size = new System.Drawing.Size(1608, 525);
			this.m_grpFirmWare.ResumeLayout(false);
			this.m_grpFirmWare.PerformLayout();
			this.m_grpSettings.ResumeLayout(false);
			this.m_grpSettings.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.m_grpBoardCtrl.ResumeLayout(false);
			this.m_grpBoardCtrl.PerformLayout();
			this.m_grpSOPControl.ResumeLayout(false);
			this.m_grpSOPControl.PerformLayout();
			this.m_grpRadarMultiDevicesRS232OpSetting.ResumeLayout(false);
			this.m_grpRadarDev4RS232OpSettings.ResumeLayout(false);
			this.m_grpRadarDev4RS232OpSettings.PerformLayout();
			this.m_grpRadarDev3RS232OpSettings.ResumeLayout(false);
			this.m_grpRadarDev3RS232OpSettings.PerformLayout();
			this.m_grpRadarDev2RS232OpSettings.ResumeLayout(false);
			this.m_grpRadarDev2RS232OpSettings.PerformLayout();
			this.m_grpRadarDev2StatusSettings.ResumeLayout(false);
			this.m_grpRadarDev2StatusSettings.PerformLayout();
			this.m_grpRadarDev3StatusSettings.ResumeLayout(false);
			this.m_grpRadarDev3StatusSettings.PerformLayout();
			this.m_grpRadarDev4StatusSettings.ResumeLayout(false);
			this.m_grpRadarDev4StatusSettings.PerformLayout();
			this.m_grpTemperatureSensor.ResumeLayout(false);
			this.m_grpTemperatureSensor.PerformLayout();
			this.m_grpDeviceVariantTypes.ResumeLayout(false);
			this.m_grpDeviceVariantTypes.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_nudI2CAddress)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_AR1Wrapper = GlobalRef.TsWrapper;

		private NameValueList m_BaudRateList;

		private NameValueList m_FrefClkList;

		private frmAR1Main m_MainForm;

		public bool m_bIsConnectInProgress;

		public bool m_bFwDownloadInProgress;

		private bool m_bDownlaodFwAbort;

		private ConnectParams m_ConnectParams;

		public RadarDeviceModeConfigParams m_RadarDeviceModeConfigParams;

		private SPIConnectParams m_SPIConnectParams;

		public static bool m_BSSDwnld;

		public static bool m_MSSDwnld;

		private IContainer components;

		private CheckBox m_chkPollConnection;

		private Label m_lblDllVersion;

		private Label m_lblConnectivityStatus;

		private Label m_lblMacFwVersion;

		private Label m_lblMacVersion;

		private Button m_btnConnect;

		private Label m_lblStatus;

		private GroupBox m_grpFirmWare;

		private Button m_btnBSS_FwLoad;

		private Button f00018e;

		private Label f00018f;

		private GroupBox m_grpSettings;

		private Button m_btnRefreshPorts;

		private ComboBox m_cboBaudRate;

		private ComboBox m_cboComPort;

		private Label m_lblBaudRate;

		private Label m_lblComPort;

		private Label label4;

		private ComboBox m_cboBSS_FwFile;

		private Label m_lblPHYFwVersion;

		private Label m_lblPhyVersion;

		private System.Windows.Forms.Timer m_timerCheckOvUv;

		private ComboBox m_cboMSS_FwFile;

		private Button m_btnMSS_FwLoad;

		private Button f000190;

		private Label f000191;

		private GroupBox groupBox1;

		private CheckBox m_chkAck;

		private Button m_btnEnblRf;

		private Button m_btnSPIConct;

		private GroupBox m_grpBoardCtrl;

		private GroupBox m_grpSOPControl;

		private Label m_lblSOPMode;

		private Button m_btnSetSop;

		private Button m_btnFullRst;

		private Button m_btnWarmRst;

		private ComboBox m_cboSopMod;

		private CheckBox m_MSSCheck;

		private CheckBox m_BSSCheck;

		private CheckBox m_CfgFileCheck;

		private Button m_btnCfg_FileLoad;

		private ComboBox m_cboCfg_File;

		private Button m_btnCfg_File;

		private Label m_lblCfgFile;

		private Button m_btnFlash;

		private Label m_lblDevStatus;

		private Label m_lblDevSts;

		private CheckBox f000192;

		private ComboBox m_cboCRC;

		private Label label1;

		private Label m_lblRadarLinkVersion;

		private Label label3;

		private Label m_lblMatlabPostProcVersion;

		private CheckBox m_DSPCheck;

		private Button f000193;

		private ComboBox m_cboDSP_FwFile;

		private Label f000194;

		private Button m_btnDSP_FwLoad;

		private Label f000195;

		private Label m_lblDSPFwVersion;

		private Label label5;

		private Label label6;

		private Label f000196;

		private Label m_lblSPIConnectivityStatus;

		private Label label7;

		private Label m_lblNumOfRadarDevsDetected;

		private GroupBox m_grpRadarMultiDevicesRS232OpSetting;

		private GroupBox m_grpRadarDev4RS232OpSettings;

		private GroupBox m_grpRadarDev3RS232OpSettings;

		private GroupBox m_grpRadarDev2RS232OpSettings;

		private Button m_btnRadarDev2RefreshPorts;

		private ComboBox m_cboRadarDevice2BaudRate;

		private ComboBox m_cboRadarDevice2ComPort;

		private Button m_btnRadarDev2Connect;

		private Label m_lblRadarDevBaudRate;

		private Label m_lblRadarDev2ComPort;

		private Button m_btnRefreshNoOfDevices;

		private Label m_lblRadarDev4MacFwVersion;

		private Label m_lblRadarDev4PHYFwVersion;

		private Label m_lblDev4Status;

		private Label m_lblRadarDev4SPIConnectivityStatus;

		private Label f000197;

		private Label m_lblConnectivityRadarDev4Status;

		private Label m_lblRadarDev3MacFwVersion;

		private Label m_lblRadarDev3PHYFwVersion;

		private Label m_lblDev3Status;

		private Label m_lblRadarDev3SPIConnectivityStatus;

		private Label f000198;

		private Label m_lblConnectivityRadarDev3Status;

		private Label m_lblRadarDev2MacFwVersion;

		private Label m_lblRadarDev2PHYFwVersion;

		private Label m_lblDev2Status;

		private Label m_lblRadarDev2SPIConnectivityStatus;

		private Label f000199;

		private Label m_lblConnectivityRadarDev2Status;

		private Button m_btnAddDevice4SPIConct;

		private Button m_btnAddDevice3SPIConct;

		private Button m_btnAddDevice2SPIConct;

		private Button m_btnEnblRfDevice4;

		private Button m_btnEnblRfDevice3;

		private Button m_btnEnblRfDevice2;

		private GroupBox m_grpRadarDev2StatusSettings;

		private GroupBox m_grpRadarDev3StatusSettings;

		private GroupBox m_grpRadarDev4StatusSettings;

		private Label label8;

		private Label label9;

		private Label label10;

		private Label label11;

		private Label m_lblTopNearTX3;

		private Label m_lblBottomNearRX1;

		private Label m_lblBottomNearTX2;

		private Label m_lblNearRx;

		private Button m_btnTempSensorGet;

		private GroupBox m_grpTemperatureSensor;

		private Label m_lblTopNearRX1;

		private Button m_btnRadarDev4Connect;

		private Button m_btnRadarDev4RefreshPorts;

		private ComboBox m_cboRadarDevice4BaudRate;

		private ComboBox m_cboRadarDevice4ComPort;

		private Button m_btnRadarDev3Connect;

		private Button m_btnRadarDev3RefreshPorts;

		private ComboBox m_cboRadarDevice3BaudRate;

		private ComboBox m_cboRadarDevice3ComPort;

		private Label label15;

		private Label label14;

		private Label label13;

		private Label label12;

		private Label label16;

		private Label m_lblDieIDInfo;

		private Label m_lblBSSPatchFwVersion;

		private Label label18;

		private Label label19;

		private Label m_lblMSSPatchFwVersion;

		private Label m_lblGuiVersion;

		private Label m_lblSOPNote;

		private RadioButton f00019a;

		private RadioButton f00019b;

		private RadioButton f00019c;

		private GroupBox m_grpDeviceVariantTypes;

		private RadioButton m_RadioBtn77GHzRadarDev;

		private RadioButton m_RadioBtn60GHzRadarDev;

		private GroupBox groupBox2;

		private Label m_lblRadarDev2DieIDInfo;

		private Label m_lblRadarDev2BSSPatchFwVersion;

		private Label m_lblRadarDev2MSSPatchFwVersion;

		private Label m_lblRadarDev3DieIDInfo;

		private Label m_lblRadarDev3BSSPatchFwVersion;

		private Label m_lblRadarDev3MSSPatchFwVersion;

		private Label m_lblRadarDev4DieIDInfo;

		private Label m_lblRadarDev4BSSPatchFwVersion;

		private Label m_lblRadarDev4MSSPatchFwVersion;

		private RadioButton m_RadioBtnxWR6843;

		private RadioButton m_RadioBtnxWR1843;

		private RadioButton f00019d;

		private Label m_lblI2CAddress;

		private NumericUpDown m_nudI2CAddress;

		[CompilerGenerated]
		[Serializable]
		private sealed class c00026e
		{
			internal int m000032(string p0)
			{
				return Convert.ToInt32(p0);
			}

			public static readonly ConnectTab.c00026e f00019e = new ConnectTab.c00026e();

			public static Func<string, int> f00019f;
		}
	}
}

