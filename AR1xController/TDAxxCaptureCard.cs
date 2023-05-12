using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public partial class TDAxxCaptureCard : Form
	{
		public TDAxxCaptureCard()
		{
			InitializeComponent();
			m_MainForm = m_GuiManager.MainTsForm;
			m_TDAEthernetInitConfigParams = m_GuiManager.TsParams.TDAEthernetInitConfigParams;
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

		public int iSetTDADeviceConnectConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetTDACaptureConnectConfig_Gui(is_starting_op, is_ending_op);
		}

		public void iSetTDADeviceConnectConfig()
		{
			iSetTDADeviceConnectConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetTDADeviceConnectConfigAsync()
		{
			new del_v_v(iSetTDADeviceConnectConfig).BeginInvoke(null, null);
		}

		private void m_btnRFDataCaptureSystemConfigSet_Click(object sender, EventArgs p1)
		{
			iSetTDADeviceConnectConfigAsync();
		}

		public bool UpdateInitializeEthernetConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateInitializeEthernetConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_TDAEthernetInitConfigParams.au8DestiIpAddr0 = Convert.ToByte(m_txtHostSystemIPAddress0.Text);
				m_TDAEthernetInitConfigParams.au8DestiIpAddr1 = Convert.ToByte(m_txtHostSystemIPAddress1.Text);
				m_TDAEthernetInitConfigParams.au8DestiIpAddr2 = Convert.ToByte(m_txtHostSystemIPAddress2.Text);
				m_TDAEthernetInitConfigParams.au8DestiIpAddr3 = Convert.ToByte(m_txtHostSystemIPAddress3.Text);
				m_TDAEthernetInitConfigParams.u32ConfigPortNo = Convert.ToUInt32(m_nudConfigPort.Value);
				m_TDAEthernetInitConfigParams.deviceMap = 0U;
				if (m_boxMasterEnable.Checked)
				{
					m_TDAEthernetInitConfigParams.deviceMap = (m_TDAEthernetInitConfigParams.deviceMap | 1U);
				}
				if (m_boxSlave1Enable.Checked)
				{
					m_TDAEthernetInitConfigParams.deviceMap = (m_TDAEthernetInitConfigParams.deviceMap | 2U);
				}
				if (m_boxSlave2Enable.Checked)
				{
					m_TDAEthernetInitConfigParams.deviceMap = (m_TDAEthernetInitConfigParams.deviceMap | 4U);
				}
				if (m_boxSlave3Enable.Checked)
				{
					m_TDAEthernetInitConfigParams.deviceMap = (m_TDAEthernetInitConfigParams.deviceMap | 8U);
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

		public bool UpdateTDACaptureCardDeviceConnectionConfigDataToGUI(bool status)
		{
			if (base.InvokeRequired)
			{
				del_b_b method = new del_b_b(UpdateTDACaptureCardDeviceConnectionConfigDataToGUI);
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
					m_btnRFDataCaptureSystemConfigSet.Text = "Disconnect";
				}
				else
				{
					m_btnRFDataCaptureSystemConfigSet.Text = "Connect and Configure";
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

		public bool UpdateInitializeEthernetConfigDataToGUI()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateInitializeEthernetConfigDataToGUI);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_txtHostSystemIPAddress0.Text = m_TDAEthernetInitConfigParams.au8DestiIpAddr0.ToString();
				m_txtHostSystemIPAddress1.Text = m_TDAEthernetInitConfigParams.au8DestiIpAddr1.ToString();
				m_txtHostSystemIPAddress2.Text = m_TDAEthernetInitConfigParams.au8DestiIpAddr2.ToString();
				m_txtHostSystemIPAddress3.Text = m_TDAEthernetInitConfigParams.au8DestiIpAddr3.ToString();
				m_nudConfigPort.Value = m_TDAEthernetInitConfigParams.u32ConfigPortNo;
				if ((m_TDAEthernetInitConfigParams.deviceMap & 1U) == 1U)
				{
					m_boxMasterEnable.Checked = true;
				}
				else
				{
					m_boxMasterEnable.Checked = false;
				}
				if ((m_TDAEthernetInitConfigParams.deviceMap & 2U) == 2U)
				{
					m_boxSlave1Enable.Checked = true;
				}
				else
				{
					m_boxSlave1Enable.Checked = false;
				}
				if ((m_TDAEthernetInitConfigParams.deviceMap & 4U) == 4U)
				{
					m_boxSlave2Enable.Checked = true;
				}
				else
				{
					m_boxSlave2Enable.Checked = false;
				}
				if ((m_TDAEthernetInitConfigParams.deviceMap & 8U) == 8U)
				{
					m_boxSlave3Enable.Checked = true;
				}
				else
				{
					m_boxSlave3Enable.Checked = false;
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

		public void m0000d4(string IPAddress)
		{
			if (base.InvokeRequired)
			{
				del_str method = new del_str(m0000d4);
				base.Invoke(method, new object[]
				{
					IPAddress
				});
				return;
			}
			string[] array = IPAddress.Split(new char[]
			{
				'.'
			});
			m_txtHostSystemIPAddress0.Text = array[0];
			m_txtHostSystemIPAddress1.Text = array[1];
			m_txtHostSystemIPAddress2.Text = array[2];
			m_txtHostSystemIPAddress3.Text = array[3];
		}

		public int GetTDADeviceMap(uint deviceMap)
		{
			if (base.InvokeRequired)
			{
				del_i_u method = new del_i_u(GetTDADeviceMap);
				return (int)base.Invoke(method, new object[]
				{
					deviceMap
				});
			}
			if ((deviceMap & 1U) == 1U)
			{
				m_boxMasterEnable.Checked = true;
			}
			else
			{
				m_boxMasterEnable.Checked = false;
			}
			if ((deviceMap & 2U) == 2U)
			{
				m_boxSlave1Enable.Checked = true;
			}
			else
			{
				m_boxSlave1Enable.Checked = false;
			}
			if ((deviceMap & 4U) == 4U)
			{
				m_boxSlave2Enable.Checked = true;
			}
			else
			{
				m_boxSlave2Enable.Checked = false;
			}
			if ((deviceMap & 8U) == 8U)
			{
				m_boxSlave3Enable.Checked = true;
			}
			else
			{
				m_boxSlave3Enable.Checked = false;
			}
			return 0;
		}

		public void SetTDAVersion(string Version)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new del_str(SetTDAVersion), Version);
				return;
			}
			label_version.Text = Version;
		}

		public void SetSopCmd()
		{
			m_GuiManager.ScriptOps.SetSopCmd(1, 4);
		}

		private void m_boxSlave1Enable_CheckedChanged(object sender, EventArgs p1)
		{
		}

		private AR1xxxExtOpps m_AR1xxxExtOpps = GlobalRef.AR1xxxExtOpps;
		private GuiManager m_GuiManager = GlobalRef.GuiManager;
		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;
		private frmAR1Main m_MainForm;
		public TDAEthernetInitConfigParams m_TDAEthernetInitConfigParams;
	}
}
