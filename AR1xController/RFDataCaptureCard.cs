using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace AR1xController
{
	public partial class RFDataCaptureCard : Form
	{
		public RFDataCaptureCard()
		{
			this.InitializeComponent();
			this.InitRFEthernetModeConfig();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_EthernetInitConfigParams = this.m_GuiManager.TsParams.EthernetInitConfigParams;
			this.m_EthernetModeConfigParams = this.m_GuiManager.TsParams.EthernetModeConfigParams;
			this.m_RecordDataPacketDelayConfigParams = this.m_GuiManager.TsParams.RecordDataPacketDelayConfigParams;
		}

		public GuiManager GuiManager
		{
			get
			{
				return this.m_GuiManager;
			}
			set
			{
				this.m_GuiManager = value;
			}
		}

		private void InitRFEthernetModeConfig()
		{
			this.m_cboEthernetDataLogMode.SelectedIndex = 0;
			this.m_cboEthernetTransferMode.SelectedIndex = 0;
			this.m_cboEthernetDataCaptureMode.SelectedIndex = 0;
			this.m_cboEtherneDataForamtMode.SelectedIndex = 0;
			this.m_cboEthernetDeviceLVDSSelectMode.SelectedIndex = 0;
		}

		public int iSetRFDeviceConnectConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			this.UpdateInitializeEthernetConfigData();
			this.UpdateEthernetModeConfigData();
			this.UpdateEPacketDelayConfigData();
			return this.m_GuiManager.ScriptOps.iSetDataCaptureConnectConfig_Gui(is_starting_op, is_ending_op);
		}

		public void iSetRFDeviceConnectConfig()
		{
			this.iSetRFDeviceConnectConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetRFDeviceConnectConfigAsync()
		{
			new del_v_v(this.iSetRFDeviceConnectConfig).BeginInvoke(null, null);
		}

		private void m_btnRFDataCaptureSystemConfigSet_Click(object sender, EventArgs p1)
		{
			this.iSetRFDeviceConnectConfigAsync();
		}

		public bool UpdateInitializeEthernetConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateInitializeEthernetConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				uint value = 0U;
				uint value2 = 0U;
				uint value3 = 0U;
				uint value4 = 0U;
				uint value5 = 0U;
				uint value6 = 0U;
				if (!this.iConvertHexTextToUInt(this.m_txtMacAddress0, out value))
				{
					result = false;
				}
				else if (!this.iConvertHexTextToUInt(this.m_txtMacAddress1, out value2))
				{
					result = false;
				}
				else if (!this.iConvertHexTextToUInt(this.m_txtMacAddress2, out value3))
				{
					result = false;
				}
				else if (!this.iConvertHexTextToUInt(this.m_txtMacAddress3, out value4))
				{
					result = false;
				}
				else if (!this.iConvertHexTextToUInt(this.m_txtMacAddress4, out value5))
				{
					result = false;
				}
				else if (!this.iConvertHexTextToUInt(this.m_txtMacAddress5, out value6))
				{
					result = false;
				}
				else
				{
					this.m_EthernetInitConfigParams.f00001c = Convert.ToByte(value);
					this.m_EthernetInitConfigParams.f00001d = Convert.ToByte(value2);
					this.m_EthernetInitConfigParams.f00001e = Convert.ToByte(value3);
					this.m_EthernetInitConfigParams.f00001f = Convert.ToByte(value4);
					this.m_EthernetInitConfigParams.f000020 = Convert.ToByte(value5);
					this.m_EthernetInitConfigParams.f000021 = Convert.ToByte(value6);
					this.m_EthernetInitConfigParams.au8SourceIpAddr0 = Convert.ToByte(this.m_txtHostSystemIPAddress0.Text);
					this.m_EthernetInitConfigParams.au8SourceIpAddr1 = Convert.ToByte(this.m_txtHostSystemIPAddress1.Text);
					this.m_EthernetInitConfigParams.au8SourceIpAddr2 = Convert.ToByte(this.m_txtHostSystemIPAddress2.Text);
					this.m_EthernetInitConfigParams.au8SourceIpAddr3 = Convert.ToByte(this.m_txtHostSystemIPAddress3.Text);
					this.m_EthernetInitConfigParams.au8DestiIpAddr0 = Convert.ToByte(this.m_txtIPAddress0.Text);
					this.m_EthernetInitConfigParams.au8DestiIpAddr1 = Convert.ToByte(this.m_txtIPAddress1.Text);
					this.m_EthernetInitConfigParams.au8DestiIpAddr2 = Convert.ToByte(this.m_txtIPAddress2.Text);
					this.m_EthernetInitConfigParams.au8DestiIpAddr3 = Convert.ToByte(this.m_txtIPAddress3.Text);
					this.m_EthernetInitConfigParams.u32RecordPortNo = Convert.ToUInt32(this.m_nudRecordPlayBackPort.Value);
					this.m_EthernetInitConfigParams.u32ConfigPortNo = Convert.ToUInt32(this.m_nudConfigPort.Value);
					result = true;
				}
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateInitializeEthernetConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateInitializeEthernetConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f00001c);
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f00001d);
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f00001e);
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f00001f);
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f000020);
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f000021);
				this.m_txtIPAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.au8SourceIpAddr0);
				this.m_txtIPAddress1.Text = Convert.ToString(this.m_EthernetInitConfigParams.au8SourceIpAddr1);
				this.m_txtIPAddress2.Text = Convert.ToString(this.m_EthernetInitConfigParams.au8SourceIpAddr2);
				this.m_txtIPAddress3.Text = Convert.ToString(this.m_EthernetInitConfigParams.au8SourceIpAddr3);
				this.m_nudRecordPlayBackPort.Value = this.m_EthernetInitConfigParams.u32RecordPortNo;
				this.m_nudConfigPort.Value = this.m_EthernetInitConfigParams.u32ConfigPortNo;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int m00006a(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetResetFPGADeviceConfig_Gui(is_starting_op, is_ending_op);
		}

		private void m00006b()
		{
			this.m00006a(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void m00006c()
		{
			new del_v_v(this.m00006b).BeginInvoke(null, null);
		}

		private void m00006d(object sender, EventArgs p1)
		{
			this.m00006c();
		}

		private void m_btnEtherNetModeConfigSet_Click(object sender, EventArgs p1)
		{
		}

		public bool UpdateEthernetConfig(SetupObject dobject)
		{
			bool result;
			try
			{
				if (dobject.DCA1000Config.dataLoggingMode == "raw")
				{
					this.m_cboEthernetDataLogMode.SelectedIndex = 0;
				}
				else
				{
					this.m_cboEthernetDataLogMode.SelectedIndex = 1;
				}
				if (dobject.DCA1000Config.dataTransferMode == "LVDSCapture")
				{
					this.m_cboEthernetTransferMode.SelectedIndex = 0;
				}
				else
				{
					this.m_cboEthernetTransferMode.SelectedIndex = 1;
				}
				if (dobject.DCA1000Config.dataCaptureMode == "ethernetStream")
				{
					this.m_cboEthernetDataCaptureMode.SelectedIndex = 0;
				}
				else
				{
					this.m_cboEthernetDataCaptureMode.SelectedIndex = 1;
				}
				this.m_ChkPacketSequenceEnaDisable.Checked = (dobject.DCA1000Config.packetSequenceEnable == 1);
				this.m_nudPacketDelayConfig.Value = dobject.DCA1000Config.packetDelay_us;
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public void GetEthernetConfig(SetupObject dobject)
		{
			try
			{
				if (this.m_cboEthernetDataLogMode.SelectedIndex == 0)
				{
					GlobalRef.dobject.DCA1000Config.dataLoggingMode = "raw";
				}
				else if (this.m_cboEthernetDataLogMode.SelectedIndex == 1)
				{
					GlobalRef.dobject.DCA1000Config.dataLoggingMode = "multi";
				}
				if (this.m_cboEthernetTransferMode.SelectedIndex == 0)
				{
					GlobalRef.dobject.DCA1000Config.dataTransferMode = "LVDSCapture";
				}
				else if (this.m_cboEthernetTransferMode.SelectedIndex == 1)
				{
					GlobalRef.dobject.DCA1000Config.dataTransferMode = "DMMCapture";
				}
				if (this.m_cboEthernetDataCaptureMode.SelectedIndex == 0)
				{
					GlobalRef.dobject.DCA1000Config.dataCaptureMode = "ethernetStream";
				}
				else if (this.m_cboEthernetDataCaptureMode.SelectedIndex == 1)
				{
					GlobalRef.dobject.DCA1000Config.dataCaptureMode = "SDCard";
				}
				GlobalRef.dobject.DCA1000Config.packetSequenceEnable = (int)(this.m_ChkPacketSequenceEnaDisable.Checked ? 1 : 0);
				GlobalRef.dobject.DCA1000Config.packetDelay_us = (int)this.m_nudPacketDelayConfig.Value;
			}
			catch
			{
			}
		}

		public bool UpdateEthernetModeConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateEthernetModeConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				if (this.m_cboEthernetDataLogMode.SelectedIndex == 0)
				{
					this.m_EthernetModeConfigParams.eLogMode = Convert.ToUInt32(1);
					GlobalRef.dobject.DCA1000Config.dataLoggingMode = "raw";
				}
				else if (this.m_cboEthernetDataLogMode.SelectedIndex == 1)
				{
					this.m_EthernetModeConfigParams.eLogMode = 2U;
					GlobalRef.dobject.DCA1000Config.dataLoggingMode = "multi";
				}
				if (this.m_cboEthernetDeviceLVDSSelectMode.SelectedIndex == 0)
				{
					this.m_EthernetModeConfigParams.eLvdsMode = Convert.ToUInt32(1);
				}
				else if (this.m_cboEthernetDeviceLVDSSelectMode.SelectedIndex == 1)
				{
					this.m_EthernetModeConfigParams.eLvdsMode = Convert.ToUInt32(2);
				}
				if (this.m_cboEthernetTransferMode.SelectedIndex == 0)
				{
					this.m_EthernetModeConfigParams.eDataXferMode = Convert.ToUInt32(1);
					GlobalRef.dobject.DCA1000Config.dataTransferMode = "LVDSCapture";
				}
				else if (this.m_cboEthernetTransferMode.SelectedIndex == 1)
				{
					this.m_EthernetModeConfigParams.eDataXferMode = Convert.ToUInt32(2);
					GlobalRef.dobject.DCA1000Config.dataTransferMode = "DMMCapture";
				}
				if (this.m_cboEthernetDataCaptureMode.SelectedIndex == 0)
				{
					this.m_EthernetModeConfigParams.eDataCaptureMode = Convert.ToUInt32(2);
					GlobalRef.dobject.DCA1000Config.dataCaptureMode = "ethernetStream";
				}
				else if (this.m_cboEthernetDataCaptureMode.SelectedIndex == 1)
				{
					this.m_EthernetModeConfigParams.eDataCaptureMode = Convert.ToUInt32(1);
					GlobalRef.dobject.DCA1000Config.dataCaptureMode = "SDCard";
				}
				if (this.m_cboEtherneDataForamtMode.SelectedIndex == 0)
				{
					this.m_EthernetModeConfigParams.eDataFormatMode = Convert.ToUInt32(1);
				}
				else if (this.m_cboEtherneDataForamtMode.SelectedIndex == 1)
				{
					this.m_EthernetModeConfigParams.eDataFormatMode = Convert.ToUInt32(2);
				}
				else if (this.m_cboEtherneDataForamtMode.SelectedIndex == 2)
				{
					this.m_EthernetModeConfigParams.eDataFormatMode = Convert.ToUInt32(3);
				}
				this.m_EthernetModeConfigParams.u8Timer = 30;
				this.m_EthernetModeConfigParams.PktSequenceEnaDisable = (byte)(this.m_ChkPacketSequenceEnaDisable.Checked ? 1 : 0);
				GlobalRef.dobject.DCA1000Config.packetSequenceEnable = (int)(this.m_ChkPacketSequenceEnaDisable.Checked ? 1 : 0);
				if (this.m_EthernetModeConfigParams.PktSequenceEnaDisable == 1)
				{
					GlobalRef.g_CapturePktSequenceEnaDisable = true;
				}
				else
				{
					GlobalRef.g_CapturePktSequenceEnaDisable = false;
				}
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateEthernetModeConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateEthernetModeConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f00001c);
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f00001d);
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f00001e);
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f00001f);
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f000020);
				this.m_txtMacAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.f000021);
				this.m_txtIPAddress0.Text = Convert.ToString(this.m_EthernetInitConfigParams.au8SourceIpAddr0);
				this.m_txtIPAddress1.Text = Convert.ToString(this.m_EthernetInitConfigParams.au8SourceIpAddr1);
				this.m_txtIPAddress2.Text = Convert.ToString(this.m_EthernetInitConfigParams.au8SourceIpAddr2);
				this.m_txtIPAddress3.Text = Convert.ToString(this.m_EthernetInitConfigParams.au8SourceIpAddr3);
				this.m_nudRecordPlayBackPort.Value = this.m_EthernetInitConfigParams.u32RecordPortNo;
				this.m_nudConfigPort.Value = this.m_EthernetInitConfigParams.u32ConfigPortNo;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
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

		public int GetRFDCCardDllVersion(string RFDCCardDllVersion)
		{
			this.f00022e.Text = RFDCCardDllVersion;
			return 0;
		}

		public void UpdateRFDCCardDllVersion()
		{
			string rfdccardDllVersion;
			this.m_GuiManager.ScriptOps.m000088(out rfdccardDllVersion);
			this.GetRFDCCardDllVersion(rfdccardDllVersion);
		}

		public void m00006e(string p0)
		{
			if (this.f00022d.InvokeRequired)
			{
				del_str method = new del_str(this.m00006e);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			this.f00022d.Text = Convert.ToString(p0);
		}

		private int iSetPacketDelayConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			this.UpdateEPacketDelayConfigData();
			return this.m_GuiManager.ScriptOps.iSetPacketDelayConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetPacketDelayConfig()
		{
			this.iSetPacketDelayConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void iSetPacketDelayConfigAsync()
		{
			new del_v_v(this.iSetPacketDelayConfig).BeginInvoke(null, null);
		}

		private void m_btnPacketDelayConfigSet_Click(object sender, EventArgs p1)
		{
			this.iSetPacketDelayConfigAsync();
		}

		public bool UpdateEPacketDelayConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateEPacketDelayConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RecordDataPacketDelayConfigParams.packetDelay = Convert.ToUInt16(this.m_nudPacketDelayConfig.Value);
				GlobalRef.dobject.DCA1000Config.packetDelay_us = (int)this.m_nudPacketDelayConfig.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdatePacketDelayConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdatePacketDelayConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudPacketDelayConfig.Value = this.m_RecordDataPacketDelayConfigParams.packetDelay;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateCaptureCardDeviceConnectionConfigDataToGUI(bool status)
		{
			if (base.InvokeRequired)
			{
				del_b_b method = new del_b_b(this.UpdateCaptureCardDeviceConnectionConfigDataToGUI);
				return (bool)base.Invoke(method, new object[]
				{
					status
				});
			}
			bool result;
			try
			{
				if (status)
				{
					this.m_btnRFDataCaptureSystemConfigSet.Text = "Disconnect";
					this.f00022c.Enabled = true;
				}
				else
				{
					this.m_btnRFDataCaptureSystemConfigSet.Text = "Connect, Reset and Configure";
					this.f00022c.Enabled = false;
				}
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateCaptureCardDeviceConnectionConfigToGUI(bool status)
		{
			if (base.InvokeRequired)
			{
				del_b_b method = new del_b_b(this.UpdateCaptureCardDeviceConnectionConfigToGUI);
				return (bool)base.Invoke(method, new object[]
				{
					status
				});
			}
			bool result;
			try
			{
				if (status)
				{
					this.m_btnRFDataCaptureSystemConfigSet.Text = "Connect, Reset and Configure";
					this.f00022c.Enabled = false;
					this.f00022d.Text = "0.0.0.0";
				}
				else
				{
					this.m_btnRFDataCaptureSystemConfigSet.Text = "Disconnect";
					this.f00022c.Enabled = true;
				}
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdatAndResetFPGAVersionInGUI(bool status)
		{
			if (status)
			{
				this.f00022d.Text = "0.0.0.0";
			}
			return true;
		}

		private AR1xxxExtOpps m_AR1xxxExtOpps = GlobalRef.AR1xxxExtOpps;

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		public EthernetInitConfigParams m_EthernetInitConfigParams;

		public EthernetModeConfigParams m_EthernetModeConfigParams;

		public RecordDataPacketDelayConfigParams m_RecordDataPacketDelayConfigParams;
	}
}
