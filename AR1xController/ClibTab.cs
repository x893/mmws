using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AR1xController
{
	public class ClibTab : UserControl
	{
		public ClibTab()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_RadarDevice1DFEStaticReportDataConfigParams = this.m_GuiManager.TsParams.RadarDevice1DFEStaticReportDataConfigParams;
			this.m_RadarDevice2DFEStaticReportDataConfigParams = this.m_GuiManager.TsParams.RadarDevice2DFEStaticReportDataConfigParams;
			this.m_RadarDevice3DFEStaticReportDataConfigParams = this.m_GuiManager.TsParams.RadarDevice3DFEStaticReportDataConfigParams;
			this.m_RadarDevice4DFEStaticReportDataConfigParams = this.m_GuiManager.TsParams.RadarDevice4DFEStaticReportDataConfigParams;
			this.m_RfGPADCMeasureForExtInputConfigParams = this.m_GuiManager.TsParams.RfGPADCMeasureForExtInputConfigParams;
			this.m_lblIForceBuf.Visible = false;
			this.m_lblIForceBufMaxData.Visible = false;
			this.m_lblIForceBufMinData.Visible = false;
			this.m_lblIForceBufAvgData.Visible = false;
		}

		private int iSetRFCharReportConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iGetRFDynamicCharReportConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFCharReportConfig()
		{
			this.iSetRFCharReportConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void iSetRFCharReportConfigAsync()
		{
			new del_v_v(this.iSetRFCharReportConfig).BeginInvoke(null, null);
		}

		private void m_btnRFDynamicCfgGet_Click(object sender, EventArgs p1)
		{
			this.iSetRFCharReportConfigAsync();
		}

		public void SetTimeTempSensinGUI(uint devId, string Time)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(this.SetTimeTempSensinGUI);
				base.Invoke(method, new object[]
				{
					devId,
					Time
				});
				return;
			}
			if ((devId & 1U) == 1U)
			{
				this.m_lblTime.Text = Time;
				return;
			}
			if ((devId & 2U) == 2U)
			{
				this.m_lblRadarDevice2Time.Text = Time;
				return;
			}
			if ((devId & 4U) == 4U)
			{
				this.m_lblRadarDevice3Time.Text = Time;
				return;
			}
			if ((devId & 8U) == 8U)
			{
				this.m_lblRadarDevice4Time.Text = Time;
			}
		}

		public bool RFTemperatureReport(uint RadarDeviceId, string StatusFlags, string ErrorCode, string Rx1TempValue, string Rx2TempValue, string Rx3TempValue, string Rx4TempValue, string Tx1TempValue, string Tx2TempValue, string Tx3TempValue, string PMTempValue, string Dig1TempValue, string Dig2TempValue, string TimeStamp)
		{
			if (base.InvokeRequired)
			{
				delegate0111 method = new delegate0111(this.RFTemperatureReport);
				base.Invoke(method, new object[]
				{
					RadarDeviceId,
					StatusFlags,
					ErrorCode,
					Rx1TempValue,
					Rx2TempValue,
					Rx3TempValue,
					Rx4TempValue,
					Tx1TempValue,
					Tx2TempValue,
					Tx3TempValue,
					PMTempValue,
					Dig1TempValue,
					Dig2TempValue,
					TimeStamp
				});
			}
			else
			{
				string empty = string.Empty;
				string directoryName = Path.GetDirectoryName(Application.StartupPath);
				StreamWriter streamWriter = new StreamWriter(string.Concat(new string[]
				{
					directoryName + "\\PostProc\\MonitoringReport.txt"
				}), true);
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				string empty4 = string.Empty;
				string empty5 = string.Empty;
				string empty6 = string.Empty;
				string empty7 = string.Empty;
				string empty8 = string.Empty;
				string empty9 = string.Empty;
				string empty10 = string.Empty;
				string empty11 = string.Empty;
				string empty12 = string.Empty;
				string empty13 = string.Empty;
				string empty14 = string.Empty;
				if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
				{
					if (RadarDeviceId == 1U)
					{
						streamWriter.WriteLine(string.Concat(new string[]
						{
							" [",
							DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
							"] ",
							"RFTemperatureGetReport:",
							" ",
							TimeStamp,
							",",
							" ",
							Rx1TempValue,
							",",
							" ",
							Rx2TempValue,
							",",
							" ",
							Rx3TempValue,
							",",
							" ",
							Rx4TempValue,
							",",
							" ",
							Tx1TempValue,
							",",
							" ",
							Tx2TempValue,
							",",
							" ",
							Tx3TempValue,
							",",
							" ",
							PMTempValue,
							",",
							" ",
							Dig1TempValue,
							",",
							" ",
							Dig2TempValue
						}));
					}
				}
				else
				{
					streamWriter.WriteLine(string.Concat(new object[]
					{
						" [",
						DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
						"] ",
						"DeviceId",
						" [",
						RadarDeviceId,
						"]",
						"RFTemperatureGetReport:",
						" ",
						TimeStamp,
						",",
						" ",
						Rx1TempValue,
						",",
						" ",
						Rx2TempValue,
						",",
						" ",
						Rx3TempValue,
						",",
						" ",
						Rx4TempValue,
						",",
						" ",
						Tx1TempValue,
						",",
						" ",
						Tx2TempValue,
						",",
						" ",
						Tx3TempValue,
						",",
						" ",
						PMTempValue,
						",",
						" ",
						Dig1TempValue,
						",",
						" ",
						Dig2TempValue
					}));
				}
				streamWriter.Close();
				streamWriter.Dispose();
			}
			return true;
		}

		public void SetTx1TempSensinGUI(uint devId, string Tx1TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(this.SetTx1TempSensinGUI);
				base.Invoke(method, new object[]
				{
					devId,
					Tx1TempSens
				});
				return;
			}
			if ((devId & 1U) == 1U)
			{
				this.m_lblTx1TSValue.Text = Tx1TempSens;
				return;
			}
			if ((devId & 2U) == 2U)
			{
				this.m_lblRadarDevice2Tx1TSValue.Text = Tx1TempSens;
				return;
			}
			if ((devId & 4U) == 4U)
			{
				this.m_lblRadarDevice3Tx1TSValue.Text = Tx1TempSens;
				return;
			}
			if ((devId & 8U) == 8U)
			{
				this.m_lblRadarDevice4Tx1TSValue.Text = Tx1TempSens;
			}
		}

		public void SetTx2TempSensinGUI(uint devId, string Tx2TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(this.SetTx2TempSensinGUI);
				base.Invoke(method, new object[]
				{
					devId,
					Tx2TempSens
				});
				return;
			}
			if ((devId & 1U) == 1U)
			{
				this.m_lblTx2TSValue.Text = Tx2TempSens;
				return;
			}
			if ((devId & 2U) == 2U)
			{
				this.m_lblRadarDevice2Tx2TSValue.Text = Tx2TempSens;
				return;
			}
			if ((devId & 4U) == 4U)
			{
				this.m_lblRadarDevice3Tx2TSValue.Text = Tx2TempSens;
				return;
			}
			if ((devId & 8U) == 8U)
			{
				this.m_lblRadarDevice4Tx2TSValue.Text = Tx2TempSens;
			}
		}

		public void SetTx3TempSensinGUI(uint devId, string Tx3TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(this.SetTx3TempSensinGUI);
				base.Invoke(method, new object[]
				{
					devId,
					Tx3TempSens
				});
				return;
			}
			if ((devId & 1U) == 1U)
			{
				this.m_lblTx3TSValue.Text = Tx3TempSens;
				return;
			}
			if ((devId & 2U) == 2U)
			{
				this.m_lblRadarDevice2Tx3TSValue.Text = Tx3TempSens;
				return;
			}
			if ((devId & 4U) == 4U)
			{
				this.m_lblRadarDevice3Tx3TSValue.Text = Tx3TempSens;
				return;
			}
			if ((devId & 8U) == 8U)
			{
				this.m_lblRadarDevice4Tx3TSValue.Text = Tx3TempSens;
			}
		}

		public void SetRx1TempSensinGUI(uint devId, string Rx1TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(this.SetRx1TempSensinGUI);
				base.Invoke(method, new object[]
				{
					devId,
					Rx1TempSens
				});
				return;
			}
			if ((devId & 1U) == 1U)
			{
				this.m_lblRx1TSValue.Text = Rx1TempSens;
				return;
			}
			if ((devId & 2U) == 2U)
			{
				this.m_lblRadarDevice2Rx1TSValue.Text = Rx1TempSens;
				return;
			}
			if ((devId & 4U) == 4U)
			{
				this.m_lblRadarDevice3Rx1TSValue.Text = Rx1TempSens;
				return;
			}
			if ((devId & 8U) == 8U)
			{
				this.m_lblRadarDevice4Rx1TSValue.Text = Rx1TempSens;
			}
		}

		public void SetRx2TempSensinGUI(uint devId, string Rx2TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(this.SetRx2TempSensinGUI);
				base.Invoke(method, new object[]
				{
					devId,
					Rx2TempSens
				});
				return;
			}
			if ((devId & 1U) == 1U)
			{
				this.m_lblRx2TSValue.Text = Rx2TempSens;
				return;
			}
			if ((devId & 2U) == 2U)
			{
				this.m_lblRadarDevice2Rx2TSValue.Text = Rx2TempSens;
				return;
			}
			if ((devId & 4U) == 4U)
			{
				this.m_lblRadarDevice3Rx2TSValue.Text = Rx2TempSens;
				return;
			}
			if ((devId & 8U) == 8U)
			{
				this.m_lblRadarDevice4Rx2TSValue.Text = Rx2TempSens;
			}
		}

		public void SetRx3TempSensinGUI(uint devId, string Rx3TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(this.SetRx3TempSensinGUI);
				base.Invoke(method, new object[]
				{
					devId,
					Rx3TempSens
				});
				return;
			}
			if ((devId & 1U) == 1U)
			{
				this.m_lblRx3TSValue.Text = Rx3TempSens;
				return;
			}
			if ((devId & 2U) == 2U)
			{
				this.m_lblRadarDevice2Rx3TSValue.Text = Rx3TempSens;
				return;
			}
			if ((devId & 4U) == 4U)
			{
				this.m_lblRadarDevice3Rx3TSValue.Text = Rx3TempSens;
				return;
			}
			if ((devId & 8U) == 8U)
			{
				this.m_lblRadarDevice4Rx3TSValue.Text = Rx3TempSens;
			}
		}

		public void SetRx4TempSensinGUI(uint devId, string Rx4TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(this.SetRx4TempSensinGUI);
				base.Invoke(method, new object[]
				{
					devId,
					Rx4TempSens
				});
				return;
			}
			if ((devId & 1U) == 1U)
			{
				this.m_lblRx4TSValue.Text = Rx4TempSens;
				return;
			}
			if ((devId & 2U) == 2U)
			{
				this.m_lblRadarDevice2Rx4TSValue.Text = Rx4TempSens;
				return;
			}
			if ((devId & 4U) == 4U)
			{
				this.m_lblRadarDevice3Rx4TSValue.Text = Rx4TempSens;
				return;
			}
			if ((devId & 8U) == 8U)
			{
				this.m_lblRadarDevice4Rx4TSValue.Text = Rx4TempSens;
			}
		}

		public void m000014(uint devId, string PMTempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(this.m000014);
				base.Invoke(method, new object[]
				{
					devId,
					PMTempSens
				});
				return;
			}
			if ((devId & 1U) == 1U)
			{
				this.f00017e.Text = PMTempSens;
				return;
			}
			if ((devId & 2U) == 2U)
			{
				this.f000184.Text = PMTempSens;
				return;
			}
			if ((devId & 4U) == 4U)
			{
				this.f000180.Text = PMTempSens;
				return;
			}
			if ((devId & 8U) == 8U)
			{
				this.f000182.Text = PMTempSens;
			}
		}

		public void SetDigTempSensinGUI(uint devId, string DigTempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(this.SetDigTempSensinGUI);
				base.Invoke(method, new object[]
				{
					devId,
					DigTempSens
				});
				return;
			}
			if ((devId & 1U) == 1U)
			{
				this.f00017d.Text = DigTempSens;
				return;
			}
			if ((devId & 2U) == 2U)
			{
				this.f000183.Text = DigTempSens;
				return;
			}
			if ((devId & 4U) == 4U)
			{
				this.f00017f.Text = DigTempSens;
				return;
			}
			if ((devId & 8U) == 8U)
			{
				this.f000181.Text = DigTempSens;
			}
		}

		public void SetDig2TempSensinGUI(uint devId, string Dig2TempSens)
		{
			if (base.InvokeRequired)
			{
				del_v_i_s method = new del_v_i_s(this.SetDig2TempSensinGUI);
				base.Invoke(method, new object[]
				{
					devId,
					Dig2TempSens
				});
				return;
			}
			if ((devId & 1U) == 1U)
			{
				this.f00018d.Text = Dig2TempSens;
				return;
			}
			if ((devId & 2U) == 2U)
			{
				this.f00018c.Text = Dig2TempSens;
				return;
			}
			if ((devId & 4U) == 4U)
			{
				this.f00018b.Text = Dig2TempSens;
				return;
			}
			if ((devId & 8U) == 8U)
			{
				this.f00018a.Text = Dig2TempSens;
			}
		}

		public void SetAvgTempinGUI(int devId)
		{
			if (base.InvokeRequired)
			{
				del_v_i method = new del_v_i(this.SetAvgTempinGUI);
				base.Invoke(method, new object[]
				{
					devId
				});
				return;
			}
			if ((devId & 1) == 1)
			{
				decimal value = (Convert.ToDecimal(this.m_lblRx1TSValue.Text) + Convert.ToDecimal(this.m_lblRx2TSValue.Text) + Convert.ToDecimal(this.m_lblRx3TSValue.Text) + Convert.ToDecimal(this.m_lblRx4TSValue.Text) + Convert.ToDecimal(this.m_lblTx1TSValue.Text) + Convert.ToDecimal(this.m_lblTx2TSValue.Text) + Convert.ToDecimal(this.m_lblTx3TSValue.Text) + Convert.ToDecimal(this.f00017e.Text)) / 8m;
				this.m_lblAvgTempValue.Text = Convert.ToString(value);
				return;
			}
			if ((devId & 2) == 2)
			{
				decimal value2 = (Convert.ToDecimal(this.m_lblRadarDevice2Rx1TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice2Rx2TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice2Rx3TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice2Rx4TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice2Tx1TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice2Tx2TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice2Tx3TSValue.Text) + Convert.ToDecimal(this.f000184.Text)) / 8m;
				this.m_lblRadarDevice2AvgTempValue.Text = Convert.ToString(value2);
				return;
			}
			if ((devId & 4) == 4)
			{
				decimal value3 = (Convert.ToDecimal(this.m_lblRadarDevice3Rx1TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice3Rx2TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice3Rx3TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice3Rx4TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice3Tx1TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice3Tx2TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice3Tx3TSValue.Text) + Convert.ToDecimal(this.f000180.Text)) / 8m;
				this.m_lblRadarDevice3AvgTempValue.Text = Convert.ToString(value3);
				return;
			}
			if ((devId & 8) == 8)
			{
				decimal value4 = (Convert.ToDecimal(this.m_lblRadarDevice4Rx1TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice4Rx2TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice4Rx3TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice4Rx4TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice4Tx1TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice4Tx2TSValue.Text) + Convert.ToDecimal(this.m_lblRadarDevice4Tx3TSValue.Text) + Convert.ToDecimal(this.f000182.Text)) / 8m;
				this.m_lblRadarDevice4AvgTempValue.Text = Convert.ToString(value4);
			}
		}

		public void EnableDisbleRFTemperatureDataWithRespectiveRadarDevices(ushort numberOfRadarDevicesDetected)
		{
			if (numberOfRadarDevicesDetected == 1)
			{
				this.m_lblTime.Visible = true;
				this.m_lblRx1TSValue.Visible = true;
				this.m_lblRx2TSValue.Visible = true;
				this.m_lblRx3TSValue.Visible = true;
				this.m_lblRx4TSValue.Visible = true;
				this.m_lblTx1TSValue.Visible = true;
				this.m_lblTx2TSValue.Visible = true;
				this.m_lblTx3TSValue.Visible = true;
				this.f00017e.Visible = true;
				this.f00017d.Visible = true;
				this.f00018d.Visible = true;
				this.m_lblAvgTempValue.Visible = true;
				this.m_lblRadarDevice2Time.Visible = false;
				this.m_lblRadarDevice2Rx1TSValue.Visible = false;
				this.m_lblRadarDevice2Rx2TSValue.Visible = false;
				this.m_lblRadarDevice2Rx3TSValue.Visible = false;
				this.m_lblRadarDevice2Rx4TSValue.Visible = false;
				this.m_lblRadarDevice2Tx1TSValue.Visible = false;
				this.m_lblRadarDevice2Tx2TSValue.Visible = false;
				this.m_lblRadarDevice2Tx3TSValue.Visible = false;
				this.f000184.Visible = false;
				this.f000183.Visible = false;
				this.f00018c.Visible = false;
				this.m_lblRadarDevice2AvgTempValue.Visible = false;
				this.m_lblRadarDevice3Time.Visible = false;
				this.m_lblRadarDevice3Rx1TSValue.Visible = false;
				this.m_lblRadarDevice3Rx2TSValue.Visible = false;
				this.m_lblRadarDevice3Rx3TSValue.Visible = false;
				this.m_lblRadarDevice3Rx4TSValue.Visible = false;
				this.m_lblRadarDevice3Tx1TSValue.Visible = false;
				this.m_lblRadarDevice3Tx2TSValue.Visible = false;
				this.m_lblRadarDevice3Tx3TSValue.Visible = false;
				this.f000180.Visible = false;
				this.f00017f.Visible = false;
				this.f00018b.Visible = false;
				this.m_lblRadarDevice3AvgTempValue.Visible = false;
				this.m_lblRadarDevice4Time.Visible = false;
				this.m_lblRadarDevice4Rx1TSValue.Visible = false;
				this.m_lblRadarDevice4Rx2TSValue.Visible = false;
				this.m_lblRadarDevice4Rx3TSValue.Visible = false;
				this.m_lblRadarDevice4Rx4TSValue.Visible = false;
				this.m_lblRadarDevice4Tx1TSValue.Visible = false;
				this.m_lblRadarDevice4Tx2TSValue.Visible = false;
				this.m_lblRadarDevice4Tx3TSValue.Visible = false;
				this.f000182.Visible = false;
				this.f000181.Visible = false;
				this.f00018a.Visible = false;
				this.m_lblRadarDevice4AvgTempValue.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 2)
			{
				this.m_lblTime.Visible = true;
				this.m_lblRx1TSValue.Visible = true;
				this.m_lblRx2TSValue.Visible = true;
				this.m_lblRx3TSValue.Visible = true;
				this.m_lblRx4TSValue.Visible = true;
				this.m_lblTx1TSValue.Visible = true;
				this.m_lblTx2TSValue.Visible = true;
				this.m_lblTx3TSValue.Visible = true;
				this.f00017e.Visible = true;
				this.f00017d.Visible = true;
				this.f00018d.Visible = true;
				this.m_lblAvgTempValue.Visible = true;
				this.m_lblRadarDevice2Time.Visible = true;
				this.m_lblRadarDevice2Rx1TSValue.Visible = true;
				this.m_lblRadarDevice2Rx2TSValue.Visible = true;
				this.m_lblRadarDevice2Rx3TSValue.Visible = true;
				this.m_lblRadarDevice2Rx4TSValue.Visible = true;
				this.m_lblRadarDevice2Tx1TSValue.Visible = true;
				this.m_lblRadarDevice2Tx2TSValue.Visible = true;
				this.m_lblRadarDevice2Tx3TSValue.Visible = true;
				this.f000184.Visible = true;
				this.f000183.Visible = true;
				this.f00018c.Visible = true;
				this.m_lblRadarDevice2AvgTempValue.Visible = true;
				this.m_lblRadarDevice3Time.Visible = false;
				this.m_lblRadarDevice3Rx1TSValue.Visible = false;
				this.m_lblRadarDevice3Rx2TSValue.Visible = false;
				this.m_lblRadarDevice3Rx3TSValue.Visible = false;
				this.m_lblRadarDevice3Rx4TSValue.Visible = false;
				this.m_lblRadarDevice3Tx1TSValue.Visible = false;
				this.m_lblRadarDevice3Tx2TSValue.Visible = false;
				this.m_lblRadarDevice3Tx3TSValue.Visible = false;
				this.f000180.Visible = false;
				this.f00017f.Visible = false;
				this.f00018b.Visible = false;
				this.m_lblRadarDevice3AvgTempValue.Visible = false;
				this.m_lblRadarDevice4Time.Visible = false;
				this.m_lblRadarDevice4Rx1TSValue.Visible = false;
				this.m_lblRadarDevice4Rx2TSValue.Visible = false;
				this.m_lblRadarDevice4Rx3TSValue.Visible = false;
				this.m_lblRadarDevice4Rx4TSValue.Visible = false;
				this.m_lblRadarDevice4Tx1TSValue.Visible = false;
				this.m_lblRadarDevice4Tx2TSValue.Visible = false;
				this.m_lblRadarDevice4Tx3TSValue.Visible = false;
				this.f000182.Visible = false;
				this.f000181.Visible = false;
				this.f00018a.Visible = false;
				this.m_lblRadarDevice4AvgTempValue.Visible = false;
				return;
			}
			if (numberOfRadarDevicesDetected == 4)
			{
				this.m_lblTime.Visible = true;
				this.m_lblRx1TSValue.Visible = true;
				this.m_lblRx2TSValue.Visible = true;
				this.m_lblRx3TSValue.Visible = true;
				this.m_lblRx4TSValue.Visible = true;
				this.m_lblTx1TSValue.Visible = true;
				this.m_lblTx2TSValue.Visible = true;
				this.m_lblTx3TSValue.Visible = true;
				this.f00017e.Visible = true;
				this.f00017d.Visible = true;
				this.f00018d.Visible = true;
				this.m_lblAvgTempValue.Visible = true;
				this.m_lblRadarDevice2Time.Visible = true;
				this.m_lblRadarDevice2Rx1TSValue.Visible = true;
				this.m_lblRadarDevice2Rx2TSValue.Visible = true;
				this.m_lblRadarDevice2Rx3TSValue.Visible = true;
				this.m_lblRadarDevice2Rx4TSValue.Visible = true;
				this.m_lblRadarDevice2Tx1TSValue.Visible = true;
				this.m_lblRadarDevice2Tx2TSValue.Visible = true;
				this.m_lblRadarDevice2Tx3TSValue.Visible = true;
				this.f000184.Visible = true;
				this.f000183.Visible = true;
				this.f00018c.Visible = true;
				this.m_lblRadarDevice2AvgTempValue.Visible = true;
				this.m_lblRadarDevice3Time.Visible = true;
				this.m_lblRadarDevice3Rx1TSValue.Visible = true;
				this.m_lblRadarDevice3Rx2TSValue.Visible = true;
				this.m_lblRadarDevice3Rx3TSValue.Visible = true;
				this.m_lblRadarDevice3Rx4TSValue.Visible = true;
				this.m_lblRadarDevice3Tx1TSValue.Visible = true;
				this.m_lblRadarDevice3Tx2TSValue.Visible = true;
				this.m_lblRadarDevice3Tx3TSValue.Visible = true;
				this.f000180.Visible = true;
				this.f00017f.Visible = true;
				this.f00018b.Visible = true;
				this.m_lblRadarDevice3AvgTempValue.Visible = true;
				this.m_lblRadarDevice4Time.Visible = true;
				this.m_lblRadarDevice4Rx1TSValue.Visible = true;
				this.m_lblRadarDevice4Rx2TSValue.Visible = true;
				this.m_lblRadarDevice4Rx3TSValue.Visible = true;
				this.m_lblRadarDevice4Rx4TSValue.Visible = true;
				this.m_lblRadarDevice4Tx1TSValue.Visible = true;
				this.m_lblRadarDevice4Tx2TSValue.Visible = true;
				this.m_lblRadarDevice4Tx3TSValue.Visible = true;
				this.f000182.Visible = true;
				this.f000181.Visible = true;
				this.f00018a.Visible = true;
				this.m_lblRadarDevice4AvgTempValue.Visible = true;
				return;
			}
			this.m_lblTime.Visible = false;
			this.m_lblRx1TSValue.Visible = false;
			this.m_lblRx2TSValue.Visible = false;
			this.m_lblRx3TSValue.Visible = false;
			this.m_lblRx4TSValue.Visible = false;
			this.m_lblTx1TSValue.Visible = false;
			this.m_lblTx2TSValue.Visible = false;
			this.m_lblTx3TSValue.Visible = false;
			this.f00017e.Visible = false;
			this.f00017d.Visible = false;
			this.m_lblAvgTempValue.Visible = false;
			this.m_lblRadarDevice2Time.Visible = false;
			this.m_lblRadarDevice2Rx1TSValue.Visible = false;
			this.m_lblRadarDevice2Rx2TSValue.Visible = false;
			this.m_lblRadarDevice2Rx3TSValue.Visible = false;
			this.m_lblRadarDevice2Rx4TSValue.Visible = false;
			this.m_lblRadarDevice2Tx1TSValue.Visible = false;
			this.m_lblRadarDevice2Tx2TSValue.Visible = false;
			this.m_lblRadarDevice2Tx3TSValue.Visible = false;
			this.f000184.Visible = false;
			this.f000183.Visible = false;
			this.m_lblRadarDevice2AvgTempValue.Visible = false;
			this.m_lblRadarDevice3Time.Visible = false;
			this.m_lblRadarDevice3Rx1TSValue.Visible = false;
			this.m_lblRadarDevice3Rx2TSValue.Visible = false;
			this.m_lblRadarDevice3Rx3TSValue.Visible = false;
			this.m_lblRadarDevice3Rx4TSValue.Visible = false;
			this.m_lblRadarDevice3Tx1TSValue.Visible = false;
			this.m_lblRadarDevice3Tx2TSValue.Visible = false;
			this.m_lblRadarDevice3Tx3TSValue.Visible = false;
			this.f000180.Visible = false;
			this.f00017f.Visible = false;
			this.f00018b.Visible = false;
			this.m_lblRadarDevice3AvgTempValue.Visible = false;
			this.m_lblRadarDevice4Time.Visible = false;
			this.m_lblRadarDevice4Rx1TSValue.Visible = false;
			this.m_lblRadarDevice4Rx2TSValue.Visible = false;
			this.m_lblRadarDevice4Rx3TSValue.Visible = false;
			this.m_lblRadarDevice4Rx4TSValue.Visible = false;
			this.m_lblRadarDevice4Tx1TSValue.Visible = false;
			this.m_lblRadarDevice4Tx2TSValue.Visible = false;
			this.m_lblRadarDevice4Tx3TSValue.Visible = false;
			this.f000182.Visible = false;
			this.f000181.Visible = false;
			this.f00018a.Visible = false;
			this.m_lblRadarDevice4AvgTempValue.Visible = false;
		}

		private int iGetDFEStaticReportConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iGetDFEStaticReportDataConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iGetDFEStaticReportConfig()
		{
			this.iGetDFEStaticReportConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void iGetDFEStaticReportConfigAsync()
		{
			new del_v_v(this.iGetDFEStaticReportConfig).BeginInvoke(null, null);
		}

		private void m_btnDFEStaticReportGet_Click(object sender, EventArgs p1)
		{
			this.iGetDFEStaticReportConfigAsync();
		}

		public void DisplayProfile0RX1DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile0RX1DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile0IdcRX1.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile0QdcRX1.Text = Convert.ToString((int)p1);
			this.m_lblProfile0IpwrRX1.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile0QpwrRX1.Text = Convert.ToString(p3);
			this.m_lblProfile0IQcrosscorrRX1.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile0RX2DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile0RX2DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile0IdcRX2.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile0QdcRX2.Text = Convert.ToString((int)p1);
			this.m_lblProfile0IpwrRX2.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile0QpwrRX2.Text = Convert.ToString(p3);
			this.m_lblProfile0IQcrosscorrRX2.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile0RX3DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile0RX3DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile0IdcRX3.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile0QdcRX3.Text = Convert.ToString((int)p1);
			this.m_lblProfile0IpwrRX3.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile0QpwrRX3.Text = Convert.ToString(p3);
			this.m_lblProfile0IQcrosscorrRX3.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile0RX4DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile0RX4DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile0IdcRX4.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile0QdcRX4.Text = Convert.ToString((int)p1);
			this.m_lblProfile0IpwrRX4.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile0QpwrRX4.Text = Convert.ToString(p3);
			this.m_lblProfile0IQcrosscorrRX4.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile1RX1DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile1RX1DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile1IdcRX1.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile1QdcRX1.Text = Convert.ToString((int)p1);
			this.m_lblProfile1IpwrRX1.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile1QpwrRX1.Text = Convert.ToString(p3);
			this.m_lblProfile1IQcrosscorrRX1.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile1RX2DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile1RX2DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile1IdcRX2.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile1QdcRX2.Text = Convert.ToString((int)p1);
			this.m_lblProfile1IpwrRX2.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile1QpwrRX2.Text = Convert.ToString(p3);
			this.m_lblProfile1IQcrosscorrRX2.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile1RX3DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile1RX3DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile1IdcRX3.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile1QdcRX3.Text = Convert.ToString((int)p1);
			this.m_lblProfile1IpwrRX3.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile1QpwrRX3.Text = Convert.ToString(p3);
			this.m_lblProfile1IQcrosscorrRX3.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile1RX4DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile1RX4DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile1IdcRX4.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile1QdcRX4.Text = Convert.ToString((int)p1);
			this.m_lblProfile1IpwrRX4.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile1QpwrRX4.Text = Convert.ToString(p3);
			this.m_lblProfile1IQcrosscorrRX4.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile2RX1DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile2RX1DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile2IdcRX1.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile2QdcRX1.Text = Convert.ToString((int)p1);
			this.m_lblProfile2IpwrRX1.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile2QpwrRX1.Text = Convert.ToString(p3);
			this.m_lblProfile2IQcrosscorrRX1.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile2RX2DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile2RX2DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile2IdcRX2.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile2QdcRX2.Text = Convert.ToString((int)p1);
			this.m_lblProfile2IpwrRX2.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile2QpwrRX2.Text = Convert.ToString(p3);
			this.m_lblProfile2IQcrosscorrRX2.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile2RX3DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile2RX3DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile2IdcRX3.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile2QdcRX3.Text = Convert.ToString((int)p1);
			this.m_lblProfile2IpwrRX3.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile2QpwrRX3.Text = Convert.ToString(p3);
			this.m_lblProfile2IQcrosscorrRX3.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile2RX4DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile2RX4DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile2IdcRX4.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile2QdcRX4.Text = Convert.ToString((int)p1);
			this.m_lblProfile2IpwrRX4.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile2QpwrRX4.Text = Convert.ToString(p3);
			this.m_lblProfile2IQcrosscorrRX4.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile3RX1DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile3RX1DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile3IdcRX1.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile3QdcRX1.Text = Convert.ToString((int)p1);
			this.m_lblProfile3IpwrRX1.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile3QpwrRX1.Text = Convert.ToString(p3);
			this.m_lblProfile3IQcrosscorrRX1.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile3RX2DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile3RX2DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile3IdcRX2.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile3QdcRX2.Text = Convert.ToString((int)p1);
			this.m_lblProfile3IpwrRX2.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile3QpwrRX2.Text = Convert.ToString(p3);
			this.m_lblProfile3IQcrosscorrRX2.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile3RX3DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile3RX3DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile3IdcRX3.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile3QdcRX3.Text = Convert.ToString((int)p1);
			this.m_lblProfile3IpwrRX3.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile3QpwrRX3.Text = Convert.ToString(p3);
			this.m_lblProfile3IQcrosscorrRX3.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		public void DisplayProfile3RX4DataReportinGUI(int Profile0IdcRx1, uint p1, int Profile0IpwrRx1, int p3, uint Profile0IQcrosscorrRx1)
		{
			if (base.InvokeRequired)
			{
				delegate011c method = new delegate011c(this.DisplayProfile3RX4DataReportinGUI);
				base.Invoke(method, new object[]
				{
					Profile0IdcRx1,
					p1,
					Profile0IpwrRx1,
					p3,
					Profile0IQcrosscorrRx1
				});
				return;
			}
			this.m_lblProfile3IdcRX4.Text = Convert.ToString(Profile0IdcRx1);
			this.m_lblProfile3QdcRX4.Text = Convert.ToString((int)p1);
			this.m_lblProfile3IpwrRX4.Text = Convert.ToString(Profile0IpwrRx1);
			this.m_lblProfile3QpwrRX4.Text = Convert.ToString(p3);
			this.m_lblProfile3IQcrosscorrRX4.Text = Convert.ToString((int)Profile0IQcrosscorrRx1);
		}

		private void m_lblProfile0IdcRX2_Click(object sender, EventArgs p1)
		{
		}

		private int iSetGPADCExternalMeasurementConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetGPADCExternalMeasurementConfig_Gui(is_starting_op, is_ending_op);
		}

		private void m000015()
		{
			this.iSetGPADCExternalMeasurementConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void iSetGPADCExternalMeasurementConfigAsync()
		{
			new del_v_v(this.m000015).BeginInvoke(null, null);
		}

		private void m000016(object sender, EventArgs p1)
		{
			this.iSetGPADCExternalMeasurementConfigAsync();
		}

		public bool UpdateGPADCMeasurementForExtIPConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateGPADCMeasurementForExtIPConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest1SignalInputEna =(ushort) (this.m_chbANATest1.Checked ? 1 : 0);
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest2SignalInputEna = (ushort)(this.m_chbANATest2.Checked ? 1 : 0);
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest3SignalInputEna = (ushort)(this.m_chbANATest3.Checked ? 1 : 0);
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest4SignalInputEna = (ushort)(this.m_chbANATest4.Checked ? 1 : 0);
				this.m_RfGPADCMeasureForExtInputConfigParams.ANAMuxSignalInputEna = (ushort)(this.m_chbIForce.Checked ? 1 : 0);
				this.m_RfGPADCMeasureForExtInputConfigParams.VSenseSignalInputEna = (ushort)(this.m_chbVSense.Checked ? 1 : 0);
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest1SignalBufEna = (ushort)(this.m_chbSigBufEnaANATest1.Checked ? 1 : 0);
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest2SignalBufEna = (ushort)(this.m_chbSigBufEnaANATest2.Checked ? 1 : 0);
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest3SignalBufEna = (ushort)(this.m_chbSigBufEnaANATest3.Checked ? 1 : 0);
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest4SignalBufEna = (ushort)(this.m_chbSigBufEnaANATest4.Checked ? 1 : 0);
				this.m_RfGPADCMeasureForExtInputConfigParams.ANAMuxSignalBufEna = (ushort)(this.m_chbSigBufEnaANAMux.Checked ? 1 : 0);
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest1Cfg_NumSamples = (ushort)(ushort)this.m_nudANATest1Cfg.Value;
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest2Cfg_NumSamples = (ushort)(ushort)this.m_nudANATest2Cfg.Value;
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest3Cfg_NumSamples = (ushort)(ushort)this.m_nudANATest3Cfg.Value;
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest4Cfg_NumSamples = (ushort)(ushort)this.m_nudANATest4Cfg.Value;
				this.m_RfGPADCMeasureForExtInputConfigParams.ANAMuxCfg_NumSamples = (ushort)this.m_nudIForceCfg.Value;
				this.m_RfGPADCMeasureForExtInputConfigParams.VSenseCfg_NumSamples = (ushort)this.m_nudVSenseCfg.Value;
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest1Cfg_SettlingTime = (float)this.m_nudANATest1SettlingTimeCfg.Value;
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest2Cfg_SettlingTime = (float)this.m_nudANATest2SettlingTimeCfg.Value;
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest3Cfg_SettlingTime = (float)this.m_nudANATest3SettlingTimeCfg.Value;
				this.m_RfGPADCMeasureForExtInputConfigParams.ANATest4Cfg_SettlingTime = (float)this.m_nudANATest4SettlingTimeCfg.Value;
				this.m_RfGPADCMeasureForExtInputConfigParams.ANAMuxCfg_SettlingTime = (float)this.f000189.Value;
				this.m_RfGPADCMeasureForExtInputConfigParams.VSenseCfg_SettlingTime = (float)this.f000188.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateEventMonitorConfig(RootObject jobject, int p1)
		{
			bool result;
			try
			{
				if (jobject.mmWaveDevices[p1].rfConfig.p000014.isConfigured == 0)
				{
					string msg = string.Format("Missing GP ADC Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg);
				}
				else
				{
					this.m_chbANATest1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000014.enable, 16) & 1) == 1);
					this.m_chbANATest2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000014.enable, 16) & 2) >> 1 == 1);
					this.m_chbANATest3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000014.enable, 16) & 4) >> 2 == 1);
					this.m_chbANATest4.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000014.enable, 16) & 8) >> 3 == 1);
					this.m_chbIForce.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000014.enable, 16) & 16) >> 4 == 1);
					this.m_chbVSense.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000014.enable, 16) & 32) >> 5 == 1);
					this.m_chbSigBufEnaANATest1.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000014.bufferEnable, 16) & 1) == 1);
					this.m_chbSigBufEnaANATest2.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000014.bufferEnable, 16) & 2) >> 1 == 1);
					this.m_chbSigBufEnaANATest3.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000014.bufferEnable, 16) & 4) >> 2 == 1);
					this.m_chbSigBufEnaANATest4.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000014.bufferEnable, 16) & 8) >> 3 == 1);
					this.m_chbSigBufEnaANAMux.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.p000014.bufferEnable, 16) & 16) >> 4 == 1);
					this.m_nudANATest1Cfg.Value = jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[0].rlGpAdcSamples_t.sampleCnt;
					this.m_nudANATest2Cfg.Value = jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[1].rlGpAdcSamples_t.sampleCnt;
					this.m_nudANATest3Cfg.Value = jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[2].rlGpAdcSamples_t.sampleCnt;
					this.m_nudANATest4Cfg.Value = jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[3].rlGpAdcSamples_t.sampleCnt;
					this.m_nudIForceCfg.Value = jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[4].rlGpAdcSamples_t.sampleCnt;
					this.m_nudVSenseCfg.Value = jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[5].rlGpAdcSamples_t.sampleCnt;
					this.m_nudANATest1SettlingTimeCfg.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[0].rlGpAdcSamples_t.settlingTime_us;
					this.m_nudANATest2SettlingTimeCfg.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[1].rlGpAdcSamples_t.settlingTime_us;
					this.m_nudANATest3SettlingTimeCfg.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[2].rlGpAdcSamples_t.settlingTime_us;
					this.m_nudANATest4SettlingTimeCfg.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[3].rlGpAdcSamples_t.settlingTime_us;
					this.f000189.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[4].rlGpAdcSamples_t.settlingTime_us;
					this.f000188.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.p000014.numOfSamples[5].rlGpAdcSamples_t.settlingTime_us;
				}
				result = true;
			}
			catch
			{
				string msg2 = string.Format("Event Monitor Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg2);
				result = false;
			}
			return result;
		}

		public bool m000017()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.m000017);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_chbANATest1.Checked = (this.m_RfGPADCMeasureForExtInputConfigParams.ANATest1SignalInputEna == 1);
				this.m_chbANATest2.Checked = (this.m_RfGPADCMeasureForExtInputConfigParams.ANATest2SignalInputEna == 1);
				this.m_chbANATest3.Checked = (this.m_RfGPADCMeasureForExtInputConfigParams.ANATest3SignalInputEna == 1);
				this.m_chbANATest4.Checked = (this.m_RfGPADCMeasureForExtInputConfigParams.ANATest4SignalInputEna == 1);
				this.m_chbIForce.Checked = (this.m_RfGPADCMeasureForExtInputConfigParams.ANAMuxSignalInputEna == 1);
				this.m_chbVSense.Checked = (this.m_RfGPADCMeasureForExtInputConfigParams.VSenseSignalInputEna == 1);
				this.m_chbSigBufEnaANATest1.Checked = (this.m_RfGPADCMeasureForExtInputConfigParams.ANATest1SignalBufEna == 1);
				this.m_chbSigBufEnaANATest2.Checked = (this.m_RfGPADCMeasureForExtInputConfigParams.ANATest2SignalBufEna == 1);
				this.m_chbSigBufEnaANATest3.Checked = (this.m_RfGPADCMeasureForExtInputConfigParams.ANATest3SignalBufEna == 1);
				this.m_chbSigBufEnaANATest4.Checked = (this.m_RfGPADCMeasureForExtInputConfigParams.ANATest4SignalBufEna == 1);
				this.m_chbSigBufEnaANAMux.Checked = (this.m_RfGPADCMeasureForExtInputConfigParams.ANAMuxSignalBufEna == 1);
				this.m_nudANATest1Cfg.Value = this.m_RfGPADCMeasureForExtInputConfigParams.ANATest1Cfg_NumSamples;
				this.m_nudANATest2Cfg.Value = this.m_RfGPADCMeasureForExtInputConfigParams.ANATest2Cfg_NumSamples;
				this.m_nudANATest3Cfg.Value = this.m_RfGPADCMeasureForExtInputConfigParams.ANATest3Cfg_NumSamples;
				this.m_nudANATest4Cfg.Value = this.m_RfGPADCMeasureForExtInputConfigParams.ANATest4Cfg_NumSamples;
				this.m_nudIForceCfg.Value = this.m_RfGPADCMeasureForExtInputConfigParams.ANAMuxCfg_NumSamples;
				this.m_nudVSenseCfg.Value = this.m_RfGPADCMeasureForExtInputConfigParams.VSenseCfg_NumSamples;
				this.m_nudANATest1SettlingTimeCfg.Value = (decimal)this.m_RfGPADCMeasureForExtInputConfigParams.ANATest1Cfg_SettlingTime;
				this.m_nudANATest2SettlingTimeCfg.Value = (decimal)this.m_RfGPADCMeasureForExtInputConfigParams.ANATest2Cfg_SettlingTime;
				this.m_nudANATest3SettlingTimeCfg.Value = (decimal)this.m_RfGPADCMeasureForExtInputConfigParams.ANATest3Cfg_SettlingTime;
				this.m_nudANATest4SettlingTimeCfg.Value = (decimal)this.m_RfGPADCMeasureForExtInputConfigParams.ANATest4Cfg_SettlingTime;
				this.f000189.Value = (decimal)this.m_RfGPADCMeasureForExtInputConfigParams.ANAMuxCfg_SettlingTime;
				this.f000188.Value = (decimal)this.m_RfGPADCMeasureForExtInputConfigParams.VSenseCfg_SettlingTime;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public void SetGPADCANATest1AvgDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest1AvgDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.f000187.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCANATest1MaxDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest1MaxDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblANATest1MaxiData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCANATest1MinDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest1MinDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblANATest1MinData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCANATest2AvgDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest2AvgDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblANATest2MaxData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCANATest2MaxDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest2MaxDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblANATest2MaxiData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCANATest2MinDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest2MinDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblANATest2MinData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCANATest3AvgDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest3AvgDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblANATest3MaxData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCANATest3MaxDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest3MaxDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblANATest3MaxiData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCANATest3MinDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest3MinDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblANATest3MinData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCANATest4AvgDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest4AvgDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblANATest4MaxData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCANATest4MaxDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest4MaxDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblANATest4MaxiData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCANATest4MinDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCANATest4MinDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblANATest4MinData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCIForceAvgDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCIForceAvgDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblIForceAvgData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCIForceMaxDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCIForceMaxDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblIForceMaxData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCIForceMinDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCIForceMinDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblIForceMinData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCIForceBufAvgDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCIForceBufAvgDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblIForceBufAvgData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCIForceBufMaxDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCIForceBufMaxDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblIForceBufMaxData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCIForceBufMinDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCIForceBufMinDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblIForceBufMinData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCVForceAvgDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCVForceAvgDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblVForceAvgData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCVForceMaxDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCVForceMaxDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblVForceMaxData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		public void SetGPADCVForceMinDataResponseInGui(string p0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetGPADCVForceMinDataResponseInGui);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if ((GlobalRef.g_RadarDeviceId & 1U) == 1U)
			{
				this.m_lblVForceMinData.Text = p0;
				return;
			}
			uint num = GlobalRef.g_RadarDeviceId & 2U;
		}

		private void m_chbVSense_CheckedChanged(object sender, EventArgs p1)
		{
		}

		private void label11_Click(object sender, EventArgs p1)
		{
		}

		private void label30_Click(object sender, EventArgs p1)
		{
		}

		private void m000018(object sender, EventArgs p1)
		{
		}

		private void m_nudIForceCfg_ValueChanged(object sender, EventArgs p1)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.m_grpRFCharReportDynamicCfg = new GroupBox();
			this.f00018a = new Label();
			this.f00018b = new Label();
			this.f00018c = new Label();
			this.f00018d = new Label();
			this.label13 = new Label();
			this.f00017f = new Label();
			this.f000180 = new Label();
			this.m_lblRadarDevice3Tx3TSValue = new Label();
			this.m_lblRadarDevice3Tx2TSValue = new Label();
			this.m_lblRadarDevice3Tx1TSValue = new Label();
			this.m_lblRadarDevice3Rx4TSValue = new Label();
			this.m_lblRadarDevice3Rx3TSValue = new Label();
			this.m_lblRadarDevice3Rx2TSValue = new Label();
			this.m_lblRadarDevice3Rx1TSValue = new Label();
			this.m_lblRadarDevice3Time = new Label();
			this.f000181 = new Label();
			this.f000182 = new Label();
			this.m_lblRadarDevice4Tx3TSValue = new Label();
			this.m_lblRadarDevice4Tx2TSValue = new Label();
			this.m_lblRadarDevice4Tx1TSValue = new Label();
			this.m_lblRadarDevice4Rx4TSValue = new Label();
			this.m_lblRadarDevice4Rx3TSValue = new Label();
			this.m_lblRadarDevice4Rx2TSValue = new Label();
			this.m_lblRadarDevice4Rx1TSValue = new Label();
			this.m_lblRadarDevice4Time = new Label();
			this.f000183 = new Label();
			this.f000184 = new Label();
			this.m_lblRadarDevice2Tx3TSValue = new Label();
			this.m_lblRadarDevice2Tx2TSValue = new Label();
			this.m_lblRadarDevice2Tx1TSValue = new Label();
			this.m_lblRadarDevice2Rx4TSValue = new Label();
			this.m_lblRadarDevice2Rx3TSValue = new Label();
			this.m_lblRadarDevice2Rx2TSValue = new Label();
			this.m_lblRadarDevice2Rx1TSValue = new Label();
			this.m_lblRadarDevice2Time = new Label();
			this.m_btnRFDynamicCfgGet = new Button();
			this.label21 = new Label();
			this.label20 = new Label();
			this.m_lblTx2TSValue = new Label();
			this.m_lblRx4TSValue = new Label();
			this.m_lblTx3TSValue = new Label();
			this.m_lblTx1TSValue = new Label();
			this.f00017d = new Label();
			this.f00017e = new Label();
			this.m_lblRx3TSValue = new Label();
			this.m_lblRx2TSValue = new Label();
			this.m_lblRx1TSValue = new Label();
			this.m_lblTime = new Label();
			this.label9 = new Label();
			this.label10 = new Label();
			this.label7 = new Label();
			this.label8 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.m_grpDFEStaticReport = new GroupBox();
			this.m_lblProfile3IQcrosscorrRX4 = new Label();
			this.m_lblProfile3QpwrRX4 = new Label();
			this.m_lblProfile3IpwrRX4 = new Label();
			this.m_lblProfile3QdcRX4 = new Label();
			this.m_lblProfile3IdcRX4 = new Label();
			this.m_lblProfile3IQcrosscorrRX3 = new Label();
			this.m_lblProfile3QpwrRX3 = new Label();
			this.m_lblProfile3IpwrRX3 = new Label();
			this.m_lblProfile3QdcRX3 = new Label();
			this.m_lblProfile3IdcRX3 = new Label();
			this.m_lblProfile3IQcrosscorrRX2 = new Label();
			this.m_lblProfile3QpwrRX2 = new Label();
			this.m_lblProfile3IpwrRX2 = new Label();
			this.m_lblProfile3QdcRX2 = new Label();
			this.m_lblProfile3IdcRX2 = new Label();
			this.m_lblProfile3IQcrosscorrRX1 = new Label();
			this.m_lblProfile3QpwrRX1 = new Label();
			this.m_lblProfile3IpwrRX1 = new Label();
			this.m_lblProfile3QdcRX1 = new Label();
			this.m_lblProfile3IdcRX1 = new Label();
			this.m_lblProfile2IQcrosscorrRX4 = new Label();
			this.m_lblProfile2QpwrRX4 = new Label();
			this.m_lblProfile2IpwrRX4 = new Label();
			this.m_lblProfile2QdcRX4 = new Label();
			this.m_lblProfile2IdcRX4 = new Label();
			this.m_lblProfile2IQcrosscorrRX3 = new Label();
			this.m_lblProfile2QpwrRX3 = new Label();
			this.m_lblProfile2IpwrRX3 = new Label();
			this.m_lblProfile2QdcRX3 = new Label();
			this.m_lblProfile2IdcRX3 = new Label();
			this.m_lblProfile2IQcrosscorrRX2 = new Label();
			this.m_lblProfile2QpwrRX2 = new Label();
			this.m_lblProfile2IpwrRX2 = new Label();
			this.m_lblProfile2QdcRX2 = new Label();
			this.m_lblProfile2IdcRX2 = new Label();
			this.m_lblProfile2IQcrosscorrRX1 = new Label();
			this.m_lblProfile2QpwrRX1 = new Label();
			this.m_lblProfile2IpwrRX1 = new Label();
			this.m_lblProfile2QdcRX1 = new Label();
			this.m_lblProfile2IdcRX1 = new Label();
			this.m_lblProfile1IQcrosscorrRX4 = new Label();
			this.m_lblProfile1QpwrRX4 = new Label();
			this.m_lblProfile1IpwrRX4 = new Label();
			this.m_lblProfile1QdcRX4 = new Label();
			this.m_lblProfile1IdcRX4 = new Label();
			this.m_lblProfile1IQcrosscorrRX3 = new Label();
			this.m_lblProfile1QpwrRX3 = new Label();
			this.m_lblProfile1IpwrRX3 = new Label();
			this.m_lblProfile1QdcRX3 = new Label();
			this.m_lblProfile1IdcRX3 = new Label();
			this.m_lblProfile1IQcrosscorrRX2 = new Label();
			this.m_lblProfile1QpwrRX2 = new Label();
			this.m_lblProfile1IpwrRX2 = new Label();
			this.m_lblProfile1QdcRX2 = new Label();
			this.m_lblProfile1IdcRX2 = new Label();
			this.m_lblProfile1IQcrosscorrRX1 = new Label();
			this.m_lblProfile1QpwrRX1 = new Label();
			this.m_lblProfile1IpwrRX1 = new Label();
			this.m_lblProfile1QdcRX1 = new Label();
			this.m_lblProfile1IdcRX1 = new Label();
			this.m_lblProfile0IQcrosscorrRX4 = new Label();
			this.m_lblProfile0QpwrRX4 = new Label();
			this.m_lblProfile0IpwrRX4 = new Label();
			this.m_lblProfile0QdcRX4 = new Label();
			this.m_lblProfile0IdcRX4 = new Label();
			this.m_lblProfile0IQcrosscorrRX3 = new Label();
			this.m_lblProfile0QpwrRX3 = new Label();
			this.m_lblProfile0IpwrRX3 = new Label();
			this.m_lblProfile0QdcRX3 = new Label();
			this.m_lblProfile0IdcRX3 = new Label();
			this.m_lblProfile0IQcrosscorrRX2 = new Label();
			this.m_lblProfile0QpwrRX2 = new Label();
			this.m_lblProfile0IpwrRX2 = new Label();
			this.m_lblProfile0QdcRX2 = new Label();
			this.m_lblProfile0IdcRX2 = new Label();
			this.m_lblProfile0IQcrosscorrRX1 = new Label();
			this.m_lblProfile0QpwrRX1 = new Label();
			this.m_lblProfile0IpwrRX1 = new Label();
			this.m_lblProfile0QdcRX1 = new Label();
			this.m_lblProfile0IdcRX1 = new Label();
			this.m_btnDFEStaticReportGet = new Button();
			this.pictureBox3 = new PictureBox();
			this.pictureBox2 = new PictureBox();
			this.label92 = new Label();
			this.label91 = new Label();
			this.label86 = new Label();
			this.label87 = new Label();
			this.label88 = new Label();
			this.label89 = new Label();
			this.label90 = new Label();
			this.label84 = new Label();
			this.label85 = new Label();
			this.label82 = new Label();
			this.label83 = new Label();
			this.label80 = new Label();
			this.label81 = new Label();
			this.label78 = new Label();
			this.label79 = new Label();
			this.label77 = new Label();
			this.label76 = new Label();
			this.pictureBox1 = new PictureBox();
			this.label75 = new Label();
			this.label73 = new Label();
			this.label74 = new Label();
			this.label71 = new Label();
			this.m_lblProfile0RX1 = new Label();
			this.label70 = new Label();
			this.m_lblProfile0Idc = new Label();
			this.label67 = new Label();
			this.label68 = new Label();
			this.label66 = new Label();
			this.label65 = new Label();
			this.f000185 = new GroupBox();
			this.f000188 = new NumericUpDown();
			this.f000189 = new NumericUpDown();
			this.m_nudANATest4SettlingTimeCfg = new NumericUpDown();
			this.m_nudANATest3SettlingTimeCfg = new NumericUpDown();
			this.m_nudANATest2SettlingTimeCfg = new NumericUpDown();
			this.m_nudANATest1SettlingTimeCfg = new NumericUpDown();
			this.label35 = new Label();
			this.label34 = new Label();
			this.label33 = new Label();
			this.label32 = new Label();
			this.label31 = new Label();
			this.label30 = new Label();
			this.m_chbSigBufEnaANAMux = new CheckBox();
			this.m_chbSigBufEnaANATest4 = new CheckBox();
			this.m_chbSigBufEnaANATest3 = new CheckBox();
			this.m_chbSigBufEnaANATest2 = new CheckBox();
			this.m_chbSigBufEnaANATest1 = new CheckBox();
			this.label18 = new Label();
			this.f000186 = new Button();
			this.m_nudVSenseCfg = new NumericUpDown();
			this.m_nudIForceCfg = new NumericUpDown();
			this.m_nudANATest4Cfg = new NumericUpDown();
			this.m_nudANATest3Cfg = new NumericUpDown();
			this.m_nudANATest2Cfg = new NumericUpDown();
			this.m_nudANATest1Cfg = new NumericUpDown();
			this.m_chbVSense = new CheckBox();
			this.m_chbIForce = new CheckBox();
			this.m_chbANATest4 = new CheckBox();
			this.m_chbANATest3 = new CheckBox();
			this.m_chbANATest2 = new CheckBox();
			this.m_chbANATest1 = new CheckBox();
			this.label14 = new Label();
			this.label12 = new Label();
			this.label11 = new Label();
			this.label19 = new Label();
			this.label22 = new Label();
			this.label23 = new Label();
			this.label24 = new Label();
			this.label25 = new Label();
			this.label26 = new Label();
			this.label27 = new Label();
			this.m_lblANATest1MaxiData = new Label();
			this.m_lblANATest1MinData = new Label();
			this.f000187 = new Label();
			this.m_lblANATest2MaxData = new Label();
			this.m_lblANATest2MinData = new Label();
			this.m_lblANATest2MaxiData = new Label();
			this.m_lblANATest3MaxData = new Label();
			this.m_lblANATest3MinData = new Label();
			this.m_lblANATest3MaxiData = new Label();
			this.m_lblANATest4MaxData = new Label();
			this.m_lblANATest4MinData = new Label();
			this.m_lblANATest4MaxiData = new Label();
			this.label28 = new Label();
			this.label29 = new Label();
			this.m_lblIForceBuf = new Label();
			this.m_lblIForceMaxData = new Label();
			this.m_lblVForceMaxData = new Label();
			this.m_lblIForceBufMaxData = new Label();
			this.m_lblIForceMinData = new Label();
			this.m_lblVForceMinData = new Label();
			this.m_lblIForceBufMinData = new Label();
			this.m_lblIForceAvgData = new Label();
			this.m_lblVForceAvgData = new Label();
			this.m_lblIForceBufAvgData = new Label();
			this.label15 = new Label();
			this.m_lblAvgTempValue = new Label();
			this.m_lblRadarDevice2AvgTempValue = new Label();
			this.m_lblRadarDevice3AvgTempValue = new Label();
			this.m_lblRadarDevice4AvgTempValue = new Label();
			this.m_grpRFCharReportDynamicCfg.SuspendLayout();
			this.m_grpDFEStaticReport.SuspendLayout();
			((ISupportInitialize)this.pictureBox3).BeginInit();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.f000185.SuspendLayout();
			((ISupportInitialize)this.f000188).BeginInit();
			((ISupportInitialize)this.f000189).BeginInit();
			((ISupportInitialize)this.m_nudANATest4SettlingTimeCfg).BeginInit();
			((ISupportInitialize)this.m_nudANATest3SettlingTimeCfg).BeginInit();
			((ISupportInitialize)this.m_nudANATest2SettlingTimeCfg).BeginInit();
			((ISupportInitialize)this.m_nudANATest1SettlingTimeCfg).BeginInit();
			((ISupportInitialize)this.m_nudVSenseCfg).BeginInit();
			((ISupportInitialize)this.m_nudIForceCfg).BeginInit();
			((ISupportInitialize)this.m_nudANATest4Cfg).BeginInit();
			((ISupportInitialize)this.m_nudANATest3Cfg).BeginInit();
			((ISupportInitialize)this.m_nudANATest2Cfg).BeginInit();
			((ISupportInitialize)this.m_nudANATest1Cfg).BeginInit();
			base.SuspendLayout();
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice4AvgTempValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice3AvgTempValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice2AvgTempValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblAvgTempValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label15);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f00018a);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f00018b);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f00018c);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f00018d);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label13);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f00017f);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f000180);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice3Tx3TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice3Tx2TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice3Tx1TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice3Rx4TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice3Rx3TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice3Rx2TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice3Rx1TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice3Time);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f000181);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f000182);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice4Tx3TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice4Tx2TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice4Tx1TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice4Rx4TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice4Rx3TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice4Rx2TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice4Rx1TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice4Time);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f000183);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f000184);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice2Tx3TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice2Tx2TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice2Tx1TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice2Rx4TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice2Rx3TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice2Rx2TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice2Rx1TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRadarDevice2Time);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_btnRFDynamicCfgGet);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label21);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label20);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblTx2TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRx4TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblTx3TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblTx1TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f00017d);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.f00017e);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRx3TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRx2TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblRx1TSValue);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.m_lblTime);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label9);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label10);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label7);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label8);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label5);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label6);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label3);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label4);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label2);
			this.m_grpRFCharReportDynamicCfg.Controls.Add(this.label1);
			this.m_grpRFCharReportDynamicCfg.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_grpRFCharReportDynamicCfg.Location = new Point(20, 17);
			this.m_grpRFCharReportDynamicCfg.Margin = new Padding(4, 4, 4, 4);
			this.m_grpRFCharReportDynamicCfg.Name = "m_grpRFCharReportDynamicCfg";
			this.m_grpRFCharReportDynamicCfg.Padding = new Padding(4, 4, 4, 4);
			this.m_grpRFCharReportDynamicCfg.Size = new Size(493, 355);
			this.m_grpRFCharReportDynamicCfg.TabIndex = 4;
			this.m_grpRFCharReportDynamicCfg.TabStop = false;
			this.m_grpRFCharReportDynamicCfg.Text = "RF Temperature Data";
			this.f00018a.AutoSize = true;
			this.f00018a.Location = new Point(443, 306);
			this.f00018a.Margin = new Padding(4, 0, 4, 0);
			this.f00018a.Name = "m_lblRadarDevice4DIG2TSValue";
			this.f00018a.Size = new Size(28, 17);
			this.f00018a.TabIndex = 61;
			this.f00018a.Text = "0.0";
			this.f00018b.AutoSize = true;
			this.f00018b.Location = new Point(377, 306);
			this.f00018b.Margin = new Padding(4, 0, 4, 0);
			this.f00018b.Name = "m_lblRadarDevice3DIG2TSValue";
			this.f00018b.Size = new Size(28, 17);
			this.f00018b.TabIndex = 60;
			this.f00018b.Text = "0.0";
			this.f00018c.AutoSize = true;
			this.f00018c.Location = new Point(309, 306);
			this.f00018c.Margin = new Padding(4, 0, 4, 0);
			this.f00018c.Name = "m_lblRadarDevice2DIG2TSValue";
			this.f00018c.Size = new Size(28, 17);
			this.f00018c.TabIndex = 59;
			this.f00018c.Text = "0.0";
			this.f00018d.AutoSize = true;
			this.f00018d.Location = new Point(239, 306);
			this.f00018d.Margin = new Padding(4, 0, 4, 0);
			this.f00018d.Name = "m_lblDIG2TSValue";
			this.f00018d.Size = new Size(28, 17);
			this.f00018d.TabIndex = 57;
			this.f00018d.Text = "0.0";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(12, 306);
			this.label13.Margin = new Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new Size(168, 17);
			this.label13.TabIndex = 58;
			this.label13.Text = "TEMP_DIG2_SENS (°C)";
			this.f00017f.AutoSize = true;
			this.f00017f.Location = new Point(377, 286);
			this.f00017f.Margin = new Padding(4, 0, 4, 0);
			this.f00017f.Name = "m_lblRadarDevice3DIGTSValue";
			this.f00017f.Size = new Size(28, 17);
			this.f00017f.TabIndex = 52;
			this.f00017f.Text = "0.0";
			this.f000180.AutoSize = true;
			this.f000180.Location = new Point(377, 261);
			this.f000180.Margin = new Padding(4, 0, 4, 0);
			this.f000180.Name = "m_lblRadarDevice3PMTSValue";
			this.f000180.Size = new Size(28, 17);
			this.f000180.TabIndex = 51;
			this.f000180.Text = "0.0";
			this.m_lblRadarDevice3Tx3TSValue.AutoSize = true;
			this.m_lblRadarDevice3Tx3TSValue.Location = new Point(377, 236);
			this.m_lblRadarDevice3Tx3TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3Tx3TSValue.Name = "m_lblRadarDevice3Tx3TSValue";
			this.m_lblRadarDevice3Tx3TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice3Tx3TSValue.TabIndex = 50;
			this.m_lblRadarDevice3Tx3TSValue.Text = "0.0";
			this.m_lblRadarDevice3Tx2TSValue.AutoSize = true;
			this.m_lblRadarDevice3Tx2TSValue.Location = new Point(377, 212);
			this.m_lblRadarDevice3Tx2TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3Tx2TSValue.Name = "m_lblRadarDevice3Tx2TSValue";
			this.m_lblRadarDevice3Tx2TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice3Tx2TSValue.TabIndex = 49;
			this.m_lblRadarDevice3Tx2TSValue.Text = "0.0";
			this.m_lblRadarDevice3Tx1TSValue.AutoSize = true;
			this.m_lblRadarDevice3Tx1TSValue.Location = new Point(377, 187);
			this.m_lblRadarDevice3Tx1TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3Tx1TSValue.Name = "m_lblRadarDevice3Tx1TSValue";
			this.m_lblRadarDevice3Tx1TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice3Tx1TSValue.TabIndex = 48;
			this.m_lblRadarDevice3Tx1TSValue.Text = "0.0";
			this.m_lblRadarDevice3Rx4TSValue.AutoSize = true;
			this.m_lblRadarDevice3Rx4TSValue.Location = new Point(377, 162);
			this.m_lblRadarDevice3Rx4TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3Rx4TSValue.Name = "m_lblRadarDevice3Rx4TSValue";
			this.m_lblRadarDevice3Rx4TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice3Rx4TSValue.TabIndex = 47;
			this.m_lblRadarDevice3Rx4TSValue.Text = "0.0";
			this.m_lblRadarDevice3Rx3TSValue.AutoSize = true;
			this.m_lblRadarDevice3Rx3TSValue.Location = new Point(377, 138);
			this.m_lblRadarDevice3Rx3TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3Rx3TSValue.Name = "m_lblRadarDevice3Rx3TSValue";
			this.m_lblRadarDevice3Rx3TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice3Rx3TSValue.TabIndex = 46;
			this.m_lblRadarDevice3Rx3TSValue.Text = "0.0";
			this.m_lblRadarDevice3Rx2TSValue.AutoSize = true;
			this.m_lblRadarDevice3Rx2TSValue.Location = new Point(377, 113);
			this.m_lblRadarDevice3Rx2TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3Rx2TSValue.Name = "m_lblRadarDevice3Rx2TSValue";
			this.m_lblRadarDevice3Rx2TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice3Rx2TSValue.TabIndex = 45;
			this.m_lblRadarDevice3Rx2TSValue.Text = "0.0";
			this.m_lblRadarDevice3Rx1TSValue.AutoSize = true;
			this.m_lblRadarDevice3Rx1TSValue.Location = new Point(377, 89);
			this.m_lblRadarDevice3Rx1TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3Rx1TSValue.Name = "m_lblRadarDevice3Rx1TSValue";
			this.m_lblRadarDevice3Rx1TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice3Rx1TSValue.TabIndex = 44;
			this.m_lblRadarDevice3Rx1TSValue.Text = "0.0";
			this.m_lblRadarDevice3Time.AutoSize = true;
			this.m_lblRadarDevice3Time.Location = new Point(377, 64);
			this.m_lblRadarDevice3Time.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3Time.Name = "m_lblRadarDevice3Time";
			this.m_lblRadarDevice3Time.Size = new Size(16, 17);
			this.m_lblRadarDevice3Time.TabIndex = 43;
			this.m_lblRadarDevice3Time.Text = "0";
			this.f000181.AutoSize = true;
			this.f000181.Location = new Point(443, 286);
			this.f000181.Margin = new Padding(4, 0, 4, 0);
			this.f000181.Name = "m_lblRadarDevice4DIGTSValue";
			this.f000181.Size = new Size(28, 17);
			this.f000181.TabIndex = 42;
			this.f000181.Text = "0.0";
			this.f000182.AutoSize = true;
			this.f000182.Location = new Point(443, 261);
			this.f000182.Margin = new Padding(4, 0, 4, 0);
			this.f000182.Name = "m_lblRadarDevice4PMTSValue";
			this.f000182.Size = new Size(28, 17);
			this.f000182.TabIndex = 41;
			this.f000182.Text = "0.0";
			this.m_lblRadarDevice4Tx3TSValue.AutoSize = true;
			this.m_lblRadarDevice4Tx3TSValue.Location = new Point(443, 236);
			this.m_lblRadarDevice4Tx3TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4Tx3TSValue.Name = "m_lblRadarDevice4Tx3TSValue";
			this.m_lblRadarDevice4Tx3TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice4Tx3TSValue.TabIndex = 40;
			this.m_lblRadarDevice4Tx3TSValue.Text = "0.0";
			this.m_lblRadarDevice4Tx2TSValue.AutoSize = true;
			this.m_lblRadarDevice4Tx2TSValue.Location = new Point(443, 212);
			this.m_lblRadarDevice4Tx2TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4Tx2TSValue.Name = "m_lblRadarDevice4Tx2TSValue";
			this.m_lblRadarDevice4Tx2TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice4Tx2TSValue.TabIndex = 39;
			this.m_lblRadarDevice4Tx2TSValue.Text = "0.0";
			this.m_lblRadarDevice4Tx1TSValue.AutoSize = true;
			this.m_lblRadarDevice4Tx1TSValue.Location = new Point(443, 187);
			this.m_lblRadarDevice4Tx1TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4Tx1TSValue.Name = "m_lblRadarDevice4Tx1TSValue";
			this.m_lblRadarDevice4Tx1TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice4Tx1TSValue.TabIndex = 38;
			this.m_lblRadarDevice4Tx1TSValue.Text = "0.0";
			this.m_lblRadarDevice4Rx4TSValue.AutoSize = true;
			this.m_lblRadarDevice4Rx4TSValue.Location = new Point(443, 162);
			this.m_lblRadarDevice4Rx4TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4Rx4TSValue.Name = "m_lblRadarDevice4Rx4TSValue";
			this.m_lblRadarDevice4Rx4TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice4Rx4TSValue.TabIndex = 37;
			this.m_lblRadarDevice4Rx4TSValue.Text = "0.0";
			this.m_lblRadarDevice4Rx3TSValue.AutoSize = true;
			this.m_lblRadarDevice4Rx3TSValue.Location = new Point(443, 138);
			this.m_lblRadarDevice4Rx3TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4Rx3TSValue.Name = "m_lblRadarDevice4Rx3TSValue";
			this.m_lblRadarDevice4Rx3TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice4Rx3TSValue.TabIndex = 36;
			this.m_lblRadarDevice4Rx3TSValue.Text = "0.0";
			this.m_lblRadarDevice4Rx2TSValue.AutoSize = true;
			this.m_lblRadarDevice4Rx2TSValue.Location = new Point(443, 113);
			this.m_lblRadarDevice4Rx2TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4Rx2TSValue.Name = "m_lblRadarDevice4Rx2TSValue";
			this.m_lblRadarDevice4Rx2TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice4Rx2TSValue.TabIndex = 35;
			this.m_lblRadarDevice4Rx2TSValue.Text = "0.0";
			this.m_lblRadarDevice4Rx1TSValue.AutoSize = true;
			this.m_lblRadarDevice4Rx1TSValue.Location = new Point(443, 89);
			this.m_lblRadarDevice4Rx1TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4Rx1TSValue.Name = "m_lblRadarDevice4Rx1TSValue";
			this.m_lblRadarDevice4Rx1TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice4Rx1TSValue.TabIndex = 34;
			this.m_lblRadarDevice4Rx1TSValue.Text = "0.0";
			this.m_lblRadarDevice4Time.AutoSize = true;
			this.m_lblRadarDevice4Time.Location = new Point(443, 64);
			this.m_lblRadarDevice4Time.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4Time.Name = "m_lblRadarDevice4Time";
			this.m_lblRadarDevice4Time.Size = new Size(16, 17);
			this.m_lblRadarDevice4Time.TabIndex = 33;
			this.m_lblRadarDevice4Time.Text = "0";
			this.f000183.AutoSize = true;
			this.f000183.Location = new Point(309, 286);
			this.f000183.Margin = new Padding(4, 0, 4, 0);
			this.f000183.Name = "m_lblRadarDevice2DIGTSValue";
			this.f000183.Size = new Size(28, 17);
			this.f000183.TabIndex = 32;
			this.f000183.Text = "0.0";
			this.f000184.AutoSize = true;
			this.f000184.Location = new Point(309, 261);
			this.f000184.Margin = new Padding(4, 0, 4, 0);
			this.f000184.Name = "m_lblRadarDevice2PMTSValue";
			this.f000184.Size = new Size(28, 17);
			this.f000184.TabIndex = 31;
			this.f000184.Text = "0.0";
			this.m_lblRadarDevice2Tx3TSValue.AutoSize = true;
			this.m_lblRadarDevice2Tx3TSValue.Location = new Point(309, 236);
			this.m_lblRadarDevice2Tx3TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2Tx3TSValue.Name = "m_lblRadarDevice2Tx3TSValue";
			this.m_lblRadarDevice2Tx3TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice2Tx3TSValue.TabIndex = 30;
			this.m_lblRadarDevice2Tx3TSValue.Text = "0.0";
			this.m_lblRadarDevice2Tx2TSValue.AutoSize = true;
			this.m_lblRadarDevice2Tx2TSValue.Location = new Point(309, 212);
			this.m_lblRadarDevice2Tx2TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2Tx2TSValue.Name = "m_lblRadarDevice2Tx2TSValue";
			this.m_lblRadarDevice2Tx2TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice2Tx2TSValue.TabIndex = 29;
			this.m_lblRadarDevice2Tx2TSValue.Text = "0.0";
			this.m_lblRadarDevice2Tx1TSValue.AutoSize = true;
			this.m_lblRadarDevice2Tx1TSValue.Location = new Point(309, 187);
			this.m_lblRadarDevice2Tx1TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2Tx1TSValue.Name = "m_lblRadarDevice2Tx1TSValue";
			this.m_lblRadarDevice2Tx1TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice2Tx1TSValue.TabIndex = 28;
			this.m_lblRadarDevice2Tx1TSValue.Text = "0.0";
			this.m_lblRadarDevice2Rx4TSValue.AutoSize = true;
			this.m_lblRadarDevice2Rx4TSValue.Location = new Point(309, 162);
			this.m_lblRadarDevice2Rx4TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2Rx4TSValue.Name = "m_lblRadarDevice2Rx4TSValue";
			this.m_lblRadarDevice2Rx4TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice2Rx4TSValue.TabIndex = 27;
			this.m_lblRadarDevice2Rx4TSValue.Text = "0.0";
			this.m_lblRadarDevice2Rx3TSValue.AutoSize = true;
			this.m_lblRadarDevice2Rx3TSValue.Location = new Point(309, 138);
			this.m_lblRadarDevice2Rx3TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2Rx3TSValue.Name = "m_lblRadarDevice2Rx3TSValue";
			this.m_lblRadarDevice2Rx3TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice2Rx3TSValue.TabIndex = 26;
			this.m_lblRadarDevice2Rx3TSValue.Text = "0.0";
			this.m_lblRadarDevice2Rx2TSValue.AutoSize = true;
			this.m_lblRadarDevice2Rx2TSValue.Location = new Point(309, 113);
			this.m_lblRadarDevice2Rx2TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2Rx2TSValue.Name = "m_lblRadarDevice2Rx2TSValue";
			this.m_lblRadarDevice2Rx2TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice2Rx2TSValue.TabIndex = 25;
			this.m_lblRadarDevice2Rx2TSValue.Text = "0.0";
			this.m_lblRadarDevice2Rx1TSValue.AutoSize = true;
			this.m_lblRadarDevice2Rx1TSValue.Location = new Point(309, 89);
			this.m_lblRadarDevice2Rx1TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2Rx1TSValue.Name = "m_lblRadarDevice2Rx1TSValue";
			this.m_lblRadarDevice2Rx1TSValue.Size = new Size(28, 17);
			this.m_lblRadarDevice2Rx1TSValue.TabIndex = 24;
			this.m_lblRadarDevice2Rx1TSValue.Text = "0.0";
			this.m_lblRadarDevice2Time.AutoSize = true;
			this.m_lblRadarDevice2Time.Location = new Point(309, 64);
			this.m_lblRadarDevice2Time.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2Time.Name = "m_lblRadarDevice2Time";
			this.m_lblRadarDevice2Time.Size = new Size(16, 17);
			this.m_lblRadarDevice2Time.TabIndex = 23;
			this.m_lblRadarDevice2Time.Text = "0";
			this.m_btnRFDynamicCfgGet.Location = new Point(17, 23);
			this.m_btnRFDynamicCfgGet.Margin = new Padding(4, 4, 4, 4);
			this.m_btnRFDynamicCfgGet.Name = "m_btnRFDynamicCfgGet";
			this.m_btnRFDynamicCfgGet.Size = new Size(111, 33);
			this.m_btnRFDynamicCfgGet.TabIndex = 22;
			this.m_btnRFDynamicCfgGet.Text = "Get";
			this.m_btnRFDynamicCfgGet.UseVisualStyleBackColor = true;
			this.m_btnRFDynamicCfgGet.Click += this.m_btnRFDynamicCfgGet_Click;
			this.label21.AutoSize = true;
			this.label21.Location = new Point(12, 162);
			this.label21.Margin = new Padding(4, 0, 4, 0);
			this.label21.Name = "label21";
			this.label21.Size = new Size(158, 17);
			this.label21.TabIndex = 21;
			this.label21.Text = "TEMP_RX3_SENS (°C";
			this.label20.AutoSize = true;
			this.label20.Location = new Point(31, 121);
			this.label20.Margin = new Padding(4, 0, 4, 0);
			this.label20.Name = "label20";
			this.label20.Size = new Size(0, 17);
			this.label20.TabIndex = 20;
			this.m_lblTx2TSValue.AutoSize = true;
			this.m_lblTx2TSValue.Location = new Point(239, 212);
			this.m_lblTx2TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblTx2TSValue.Name = "m_lblTx2TSValue";
			this.m_lblTx2TSValue.Size = new Size(28, 17);
			this.m_lblTx2TSValue.TabIndex = 19;
			this.m_lblTx2TSValue.Text = "0.0";
			this.m_lblRx4TSValue.AutoSize = true;
			this.m_lblRx4TSValue.Location = new Point(239, 162);
			this.m_lblRx4TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRx4TSValue.Name = "m_lblRx4TSValue";
			this.m_lblRx4TSValue.Size = new Size(28, 17);
			this.m_lblRx4TSValue.TabIndex = 18;
			this.m_lblRx4TSValue.Text = "0.0";
			this.m_lblTx3TSValue.AutoSize = true;
			this.m_lblTx3TSValue.Location = new Point(239, 236);
			this.m_lblTx3TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblTx3TSValue.Name = "m_lblTx3TSValue";
			this.m_lblTx3TSValue.Size = new Size(28, 17);
			this.m_lblTx3TSValue.TabIndex = 17;
			this.m_lblTx3TSValue.Text = "0.0";
			this.m_lblTx1TSValue.AutoSize = true;
			this.m_lblTx1TSValue.Location = new Point(239, 187);
			this.m_lblTx1TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblTx1TSValue.Name = "m_lblTx1TSValue";
			this.m_lblTx1TSValue.Size = new Size(28, 17);
			this.m_lblTx1TSValue.TabIndex = 16;
			this.m_lblTx1TSValue.Text = "0.0";
			this.f00017d.AutoSize = true;
			this.f00017d.Location = new Point(239, 286);
			this.f00017d.Margin = new Padding(4, 0, 4, 0);
			this.f00017d.Name = "m_lblDIGTSValue";
			this.f00017d.Size = new Size(28, 17);
			this.f00017d.TabIndex = 15;
			this.f00017d.Text = "0.0";
			this.f00017e.AutoSize = true;
			this.f00017e.Location = new Point(239, 261);
			this.f00017e.Margin = new Padding(4, 0, 4, 0);
			this.f00017e.Name = "m_lblPMTSValue";
			this.f00017e.Size = new Size(28, 17);
			this.f00017e.TabIndex = 14;
			this.f00017e.Text = "0.0";
			this.m_lblRx3TSValue.AutoSize = true;
			this.m_lblRx3TSValue.Location = new Point(239, 138);
			this.m_lblRx3TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRx3TSValue.Name = "m_lblRx3TSValue";
			this.m_lblRx3TSValue.Size = new Size(28, 17);
			this.m_lblRx3TSValue.TabIndex = 13;
			this.m_lblRx3TSValue.Text = "0.0";
			this.m_lblRx2TSValue.AutoSize = true;
			this.m_lblRx2TSValue.Location = new Point(239, 113);
			this.m_lblRx2TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRx2TSValue.Name = "m_lblRx2TSValue";
			this.m_lblRx2TSValue.Size = new Size(28, 17);
			this.m_lblRx2TSValue.TabIndex = 12;
			this.m_lblRx2TSValue.Text = "0.0";
			this.m_lblRx1TSValue.AutoSize = true;
			this.m_lblRx1TSValue.Location = new Point(239, 89);
			this.m_lblRx1TSValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRx1TSValue.Name = "m_lblRx1TSValue";
			this.m_lblRx1TSValue.Size = new Size(28, 17);
			this.m_lblRx1TSValue.TabIndex = 11;
			this.m_lblRx1TSValue.Text = "0.0";
			this.m_lblTime.AutoSize = true;
			this.m_lblTime.Location = new Point(239, 64);
			this.m_lblTime.Margin = new Padding(4, 0, 4, 0);
			this.m_lblTime.Name = "m_lblTime";
			this.m_lblTime.Size = new Size(16, 17);
			this.m_lblTime.TabIndex = 10;
			this.m_lblTime.Text = "0";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(12, 212);
			this.label9.Margin = new Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new Size(161, 17);
			this.label9.TabIndex = 9;
			this.label9.Text = "TEMP_TX1_SENS (°C)";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(31, 121);
			this.label10.Margin = new Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new Size(0, 17);
			this.label10.TabIndex = 8;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(12, 236);
			this.label7.Margin = new Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(156, 17);
			this.label7.TabIndex = 7;
			this.label7.Text = "TEMP_TX2_SENS (°C";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(12, 187);
			this.label8.Margin = new Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(161, 17);
			this.label8.TabIndex = 6;
			this.label8.Text = "TEMP_TX0_SENS (°C)";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(12, 286);
			this.label5.Margin = new Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(168, 17);
			this.label5.TabIndex = 5;
			this.label5.Text = "TEMP_DIG1_SENS (°C)";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(12, 261);
			this.label6.Margin = new Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new Size(156, 17);
			this.label6.TabIndex = 4;
			this.label6.Text = "TEMP_PM_SENS (°C)";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(12, 138);
			this.label3.Margin = new Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(163, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "TEMP_RX2_SENS (°C)";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(12, 113);
			this.label4.Margin = new Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(163, 17);
			this.label4.TabIndex = 2;
			this.label4.Text = "TEMP_RX1_SENS (°C)";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(12, 89);
			this.label2.Margin = new Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(163, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "TEMP_RX0_SENS (°C)";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(12, 64);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(75, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Time (ms)";
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IQcrosscorrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3QpwrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IpwrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3QdcRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IdcRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IQcrosscorrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3QpwrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IpwrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3QdcRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IdcRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IQcrosscorrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3QpwrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IpwrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3QdcRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IdcRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IQcrosscorrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3QpwrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IpwrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3QdcRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile3IdcRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IQcrosscorrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2QpwrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IpwrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2QdcRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IdcRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IQcrosscorrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2QpwrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IpwrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2QdcRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IdcRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IQcrosscorrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2QpwrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IpwrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2QdcRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IdcRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IQcrosscorrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2QpwrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IpwrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2QdcRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile2IdcRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IQcrosscorrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1QpwrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IpwrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1QdcRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IdcRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IQcrosscorrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1QpwrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IpwrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1QdcRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IdcRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IQcrosscorrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1QpwrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IpwrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1QdcRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IdcRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IQcrosscorrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1QpwrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IpwrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1QdcRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile1IdcRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IQcrosscorrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0QpwrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IpwrRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0QdcRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IdcRX4);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IQcrosscorrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0QpwrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IpwrRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0QdcRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IdcRX3);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IQcrosscorrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0QpwrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IpwrRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0QdcRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IdcRX2);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IQcrosscorrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0QpwrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IpwrRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0QdcRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0IdcRX1);
			this.m_grpDFEStaticReport.Controls.Add(this.m_btnDFEStaticReportGet);
			this.m_grpDFEStaticReport.Controls.Add(this.pictureBox3);
			this.m_grpDFEStaticReport.Controls.Add(this.pictureBox2);
			this.m_grpDFEStaticReport.Controls.Add(this.label92);
			this.m_grpDFEStaticReport.Controls.Add(this.label91);
			this.m_grpDFEStaticReport.Controls.Add(this.label86);
			this.m_grpDFEStaticReport.Controls.Add(this.label87);
			this.m_grpDFEStaticReport.Controls.Add(this.label88);
			this.m_grpDFEStaticReport.Controls.Add(this.label89);
			this.m_grpDFEStaticReport.Controls.Add(this.label90);
			this.m_grpDFEStaticReport.Controls.Add(this.label84);
			this.m_grpDFEStaticReport.Controls.Add(this.label85);
			this.m_grpDFEStaticReport.Controls.Add(this.label82);
			this.m_grpDFEStaticReport.Controls.Add(this.label83);
			this.m_grpDFEStaticReport.Controls.Add(this.label80);
			this.m_grpDFEStaticReport.Controls.Add(this.label81);
			this.m_grpDFEStaticReport.Controls.Add(this.label78);
			this.m_grpDFEStaticReport.Controls.Add(this.label79);
			this.m_grpDFEStaticReport.Controls.Add(this.label77);
			this.m_grpDFEStaticReport.Controls.Add(this.label76);
			this.m_grpDFEStaticReport.Controls.Add(this.pictureBox1);
			this.m_grpDFEStaticReport.Controls.Add(this.label75);
			this.m_grpDFEStaticReport.Controls.Add(this.label73);
			this.m_grpDFEStaticReport.Controls.Add(this.label74);
			this.m_grpDFEStaticReport.Controls.Add(this.label71);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0RX1);
			this.m_grpDFEStaticReport.Controls.Add(this.label70);
			this.m_grpDFEStaticReport.Controls.Add(this.m_lblProfile0Idc);
			this.m_grpDFEStaticReport.Controls.Add(this.label67);
			this.m_grpDFEStaticReport.Controls.Add(this.label68);
			this.m_grpDFEStaticReport.Controls.Add(this.label66);
			this.m_grpDFEStaticReport.Controls.Add(this.label65);
			this.m_grpDFEStaticReport.Location = new Point(833, 17);
			this.m_grpDFEStaticReport.Margin = new Padding(4, 4, 4, 4);
			this.m_grpDFEStaticReport.Name = "m_grpDFEStaticReport";
			this.m_grpDFEStaticReport.Padding = new Padding(4, 4, 4, 4);
			this.m_grpDFEStaticReport.Size = new Size(936, 615);
			this.m_grpDFEStaticReport.TabIndex = 5;
			this.m_grpDFEStaticReport.TabStop = false;
			this.m_grpDFEStaticReport.Text = "DFE Statics Report";
			this.m_lblProfile3IQcrosscorrRX4.AutoSize = true;
			this.m_lblProfile3IQcrosscorrRX4.Location = new Point(647, 578);
			this.m_lblProfile3IQcrosscorrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IQcrosscorrRX4.Name = "m_lblProfile3IQcrosscorrRX4";
			this.m_lblProfile3IQcrosscorrRX4.Size = new Size(28, 17);
			this.m_lblProfile3IQcrosscorrRX4.TabIndex = 111;
			this.m_lblProfile3IQcrosscorrRX4.Text = "0.0";
			this.m_lblProfile3QpwrRX4.AutoSize = true;
			this.m_lblProfile3QpwrRX4.Location = new Point(647, 554);
			this.m_lblProfile3QpwrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3QpwrRX4.Name = "m_lblProfile3QpwrRX4";
			this.m_lblProfile3QpwrRX4.Size = new Size(28, 17);
			this.m_lblProfile3QpwrRX4.TabIndex = 110;
			this.m_lblProfile3QpwrRX4.Text = "0.0";
			this.m_lblProfile3IpwrRX4.AutoSize = true;
			this.m_lblProfile3IpwrRX4.Location = new Point(647, 529);
			this.m_lblProfile3IpwrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IpwrRX4.Name = "m_lblProfile3IpwrRX4";
			this.m_lblProfile3IpwrRX4.Size = new Size(28, 17);
			this.m_lblProfile3IpwrRX4.TabIndex = 109;
			this.m_lblProfile3IpwrRX4.Text = "0.0";
			this.m_lblProfile3QdcRX4.AutoSize = true;
			this.m_lblProfile3QdcRX4.Location = new Point(647, 505);
			this.m_lblProfile3QdcRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3QdcRX4.Name = "m_lblProfile3QdcRX4";
			this.m_lblProfile3QdcRX4.Size = new Size(28, 17);
			this.m_lblProfile3QdcRX4.TabIndex = 108;
			this.m_lblProfile3QdcRX4.Text = "0.0";
			this.m_lblProfile3IdcRX4.AutoSize = true;
			this.m_lblProfile3IdcRX4.Location = new Point(647, 480);
			this.m_lblProfile3IdcRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IdcRX4.Name = "m_lblProfile3IdcRX4";
			this.m_lblProfile3IdcRX4.Size = new Size(28, 17);
			this.m_lblProfile3IdcRX4.TabIndex = 107;
			this.m_lblProfile3IdcRX4.Text = "0.0";
			this.m_lblProfile3IQcrosscorrRX3.AutoSize = true;
			this.m_lblProfile3IQcrosscorrRX3.Location = new Point(535, 578);
			this.m_lblProfile3IQcrosscorrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IQcrosscorrRX3.Name = "m_lblProfile3IQcrosscorrRX3";
			this.m_lblProfile3IQcrosscorrRX3.Size = new Size(28, 17);
			this.m_lblProfile3IQcrosscorrRX3.TabIndex = 106;
			this.m_lblProfile3IQcrosscorrRX3.Text = "0.0";
			this.m_lblProfile3QpwrRX3.AutoSize = true;
			this.m_lblProfile3QpwrRX3.Location = new Point(535, 554);
			this.m_lblProfile3QpwrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3QpwrRX3.Name = "m_lblProfile3QpwrRX3";
			this.m_lblProfile3QpwrRX3.Size = new Size(28, 17);
			this.m_lblProfile3QpwrRX3.TabIndex = 105;
			this.m_lblProfile3QpwrRX3.Text = "0.0";
			this.m_lblProfile3IpwrRX3.AutoSize = true;
			this.m_lblProfile3IpwrRX3.Location = new Point(535, 529);
			this.m_lblProfile3IpwrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IpwrRX3.Name = "m_lblProfile3IpwrRX3";
			this.m_lblProfile3IpwrRX3.Size = new Size(28, 17);
			this.m_lblProfile3IpwrRX3.TabIndex = 104;
			this.m_lblProfile3IpwrRX3.Text = "0.0";
			this.m_lblProfile3QdcRX3.AutoSize = true;
			this.m_lblProfile3QdcRX3.Location = new Point(535, 505);
			this.m_lblProfile3QdcRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3QdcRX3.Name = "m_lblProfile3QdcRX3";
			this.m_lblProfile3QdcRX3.Size = new Size(28, 17);
			this.m_lblProfile3QdcRX3.TabIndex = 103;
			this.m_lblProfile3QdcRX3.Text = "0.0";
			this.m_lblProfile3IdcRX3.AutoSize = true;
			this.m_lblProfile3IdcRX3.Location = new Point(535, 480);
			this.m_lblProfile3IdcRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IdcRX3.Name = "m_lblProfile3IdcRX3";
			this.m_lblProfile3IdcRX3.Size = new Size(28, 17);
			this.m_lblProfile3IdcRX3.TabIndex = 102;
			this.m_lblProfile3IdcRX3.Text = "0.0";
			this.m_lblProfile3IQcrosscorrRX2.AutoSize = true;
			this.m_lblProfile3IQcrosscorrRX2.Location = new Point(393, 578);
			this.m_lblProfile3IQcrosscorrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IQcrosscorrRX2.Name = "m_lblProfile3IQcrosscorrRX2";
			this.m_lblProfile3IQcrosscorrRX2.Size = new Size(28, 17);
			this.m_lblProfile3IQcrosscorrRX2.TabIndex = 101;
			this.m_lblProfile3IQcrosscorrRX2.Text = "0.0";
			this.m_lblProfile3QpwrRX2.AutoSize = true;
			this.m_lblProfile3QpwrRX2.Location = new Point(393, 554);
			this.m_lblProfile3QpwrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3QpwrRX2.Name = "m_lblProfile3QpwrRX2";
			this.m_lblProfile3QpwrRX2.Size = new Size(28, 17);
			this.m_lblProfile3QpwrRX2.TabIndex = 100;
			this.m_lblProfile3QpwrRX2.Text = "0.0";
			this.m_lblProfile3IpwrRX2.AutoSize = true;
			this.m_lblProfile3IpwrRX2.Location = new Point(393, 529);
			this.m_lblProfile3IpwrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IpwrRX2.Name = "m_lblProfile3IpwrRX2";
			this.m_lblProfile3IpwrRX2.Size = new Size(28, 17);
			this.m_lblProfile3IpwrRX2.TabIndex = 99;
			this.m_lblProfile3IpwrRX2.Text = "0.0";
			this.m_lblProfile3QdcRX2.AutoSize = true;
			this.m_lblProfile3QdcRX2.Location = new Point(393, 505);
			this.m_lblProfile3QdcRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3QdcRX2.Name = "m_lblProfile3QdcRX2";
			this.m_lblProfile3QdcRX2.Size = new Size(28, 17);
			this.m_lblProfile3QdcRX2.TabIndex = 98;
			this.m_lblProfile3QdcRX2.Text = "0.0";
			this.m_lblProfile3IdcRX2.AutoSize = true;
			this.m_lblProfile3IdcRX2.Location = new Point(393, 480);
			this.m_lblProfile3IdcRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IdcRX2.Name = "m_lblProfile3IdcRX2";
			this.m_lblProfile3IdcRX2.Size = new Size(28, 17);
			this.m_lblProfile3IdcRX2.TabIndex = 97;
			this.m_lblProfile3IdcRX2.Text = "0.0";
			this.m_lblProfile3IQcrosscorrRX1.AutoSize = true;
			this.m_lblProfile3IQcrosscorrRX1.Location = new Point(251, 578);
			this.m_lblProfile3IQcrosscorrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IQcrosscorrRX1.Name = "m_lblProfile3IQcrosscorrRX1";
			this.m_lblProfile3IQcrosscorrRX1.Size = new Size(28, 17);
			this.m_lblProfile3IQcrosscorrRX1.TabIndex = 96;
			this.m_lblProfile3IQcrosscorrRX1.Text = "0.0";
			this.m_lblProfile3QpwrRX1.AutoSize = true;
			this.m_lblProfile3QpwrRX1.Location = new Point(251, 554);
			this.m_lblProfile3QpwrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3QpwrRX1.Name = "m_lblProfile3QpwrRX1";
			this.m_lblProfile3QpwrRX1.Size = new Size(28, 17);
			this.m_lblProfile3QpwrRX1.TabIndex = 95;
			this.m_lblProfile3QpwrRX1.Text = "0.0";
			this.m_lblProfile3IpwrRX1.AutoSize = true;
			this.m_lblProfile3IpwrRX1.Location = new Point(251, 529);
			this.m_lblProfile3IpwrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IpwrRX1.Name = "m_lblProfile3IpwrRX1";
			this.m_lblProfile3IpwrRX1.Size = new Size(28, 17);
			this.m_lblProfile3IpwrRX1.TabIndex = 94;
			this.m_lblProfile3IpwrRX1.Text = "0.0";
			this.m_lblProfile3QdcRX1.AutoSize = true;
			this.m_lblProfile3QdcRX1.Location = new Point(251, 505);
			this.m_lblProfile3QdcRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3QdcRX1.Name = "m_lblProfile3QdcRX1";
			this.m_lblProfile3QdcRX1.Size = new Size(28, 17);
			this.m_lblProfile3QdcRX1.TabIndex = 93;
			this.m_lblProfile3QdcRX1.Text = "0.0";
			this.m_lblProfile3IdcRX1.AutoSize = true;
			this.m_lblProfile3IdcRX1.Location = new Point(251, 480);
			this.m_lblProfile3IdcRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile3IdcRX1.Name = "m_lblProfile3IdcRX1";
			this.m_lblProfile3IdcRX1.Size = new Size(28, 17);
			this.m_lblProfile3IdcRX1.TabIndex = 92;
			this.m_lblProfile3IdcRX1.Text = "0.0";
			this.m_lblProfile2IQcrosscorrRX4.AutoSize = true;
			this.m_lblProfile2IQcrosscorrRX4.Location = new Point(647, 437);
			this.m_lblProfile2IQcrosscorrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IQcrosscorrRX4.Name = "m_lblProfile2IQcrosscorrRX4";
			this.m_lblProfile2IQcrosscorrRX4.Size = new Size(28, 17);
			this.m_lblProfile2IQcrosscorrRX4.TabIndex = 91;
			this.m_lblProfile2IQcrosscorrRX4.Text = "0.0";
			this.m_lblProfile2QpwrRX4.AutoSize = true;
			this.m_lblProfile2QpwrRX4.Location = new Point(647, 412);
			this.m_lblProfile2QpwrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2QpwrRX4.Name = "m_lblProfile2QpwrRX4";
			this.m_lblProfile2QpwrRX4.Size = new Size(28, 17);
			this.m_lblProfile2QpwrRX4.TabIndex = 90;
			this.m_lblProfile2QpwrRX4.Text = "0.0";
			this.m_lblProfile2IpwrRX4.AutoSize = true;
			this.m_lblProfile2IpwrRX4.Location = new Point(647, 388);
			this.m_lblProfile2IpwrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IpwrRX4.Name = "m_lblProfile2IpwrRX4";
			this.m_lblProfile2IpwrRX4.Size = new Size(28, 17);
			this.m_lblProfile2IpwrRX4.TabIndex = 89;
			this.m_lblProfile2IpwrRX4.Text = "0.0";
			this.m_lblProfile2QdcRX4.AutoSize = true;
			this.m_lblProfile2QdcRX4.Location = new Point(647, 363);
			this.m_lblProfile2QdcRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2QdcRX4.Name = "m_lblProfile2QdcRX4";
			this.m_lblProfile2QdcRX4.Size = new Size(28, 17);
			this.m_lblProfile2QdcRX4.TabIndex = 88;
			this.m_lblProfile2QdcRX4.Text = "0.0";
			this.m_lblProfile2IdcRX4.AutoSize = true;
			this.m_lblProfile2IdcRX4.Location = new Point(647, 338);
			this.m_lblProfile2IdcRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IdcRX4.Name = "m_lblProfile2IdcRX4";
			this.m_lblProfile2IdcRX4.Size = new Size(28, 17);
			this.m_lblProfile2IdcRX4.TabIndex = 87;
			this.m_lblProfile2IdcRX4.Text = "0.0";
			this.m_lblProfile2IQcrosscorrRX3.AutoSize = true;
			this.m_lblProfile2IQcrosscorrRX3.Location = new Point(535, 437);
			this.m_lblProfile2IQcrosscorrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IQcrosscorrRX3.Name = "m_lblProfile2IQcrosscorrRX3";
			this.m_lblProfile2IQcrosscorrRX3.Size = new Size(28, 17);
			this.m_lblProfile2IQcrosscorrRX3.TabIndex = 86;
			this.m_lblProfile2IQcrosscorrRX3.Text = "0.0";
			this.m_lblProfile2QpwrRX3.AutoSize = true;
			this.m_lblProfile2QpwrRX3.Location = new Point(535, 412);
			this.m_lblProfile2QpwrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2QpwrRX3.Name = "m_lblProfile2QpwrRX3";
			this.m_lblProfile2QpwrRX3.Size = new Size(28, 17);
			this.m_lblProfile2QpwrRX3.TabIndex = 85;
			this.m_lblProfile2QpwrRX3.Text = "0.0";
			this.m_lblProfile2IpwrRX3.AutoSize = true;
			this.m_lblProfile2IpwrRX3.Location = new Point(535, 388);
			this.m_lblProfile2IpwrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IpwrRX3.Name = "m_lblProfile2IpwrRX3";
			this.m_lblProfile2IpwrRX3.Size = new Size(28, 17);
			this.m_lblProfile2IpwrRX3.TabIndex = 84;
			this.m_lblProfile2IpwrRX3.Text = "0.0";
			this.m_lblProfile2QdcRX3.AutoSize = true;
			this.m_lblProfile2QdcRX3.Location = new Point(535, 363);
			this.m_lblProfile2QdcRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2QdcRX3.Name = "m_lblProfile2QdcRX3";
			this.m_lblProfile2QdcRX3.Size = new Size(28, 17);
			this.m_lblProfile2QdcRX3.TabIndex = 83;
			this.m_lblProfile2QdcRX3.Text = "0.0";
			this.m_lblProfile2IdcRX3.AutoSize = true;
			this.m_lblProfile2IdcRX3.Location = new Point(535, 338);
			this.m_lblProfile2IdcRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IdcRX3.Name = "m_lblProfile2IdcRX3";
			this.m_lblProfile2IdcRX3.Size = new Size(28, 17);
			this.m_lblProfile2IdcRX3.TabIndex = 82;
			this.m_lblProfile2IdcRX3.Text = "0.0";
			this.m_lblProfile2IQcrosscorrRX2.AutoSize = true;
			this.m_lblProfile2IQcrosscorrRX2.Location = new Point(393, 437);
			this.m_lblProfile2IQcrosscorrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IQcrosscorrRX2.Name = "m_lblProfile2IQcrosscorrRX2";
			this.m_lblProfile2IQcrosscorrRX2.Size = new Size(28, 17);
			this.m_lblProfile2IQcrosscorrRX2.TabIndex = 81;
			this.m_lblProfile2IQcrosscorrRX2.Text = "0.0";
			this.m_lblProfile2QpwrRX2.AutoSize = true;
			this.m_lblProfile2QpwrRX2.Location = new Point(393, 412);
			this.m_lblProfile2QpwrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2QpwrRX2.Name = "m_lblProfile2QpwrRX2";
			this.m_lblProfile2QpwrRX2.Size = new Size(28, 17);
			this.m_lblProfile2QpwrRX2.TabIndex = 80;
			this.m_lblProfile2QpwrRX2.Text = "0.0";
			this.m_lblProfile2IpwrRX2.AutoSize = true;
			this.m_lblProfile2IpwrRX2.Location = new Point(393, 388);
			this.m_lblProfile2IpwrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IpwrRX2.Name = "m_lblProfile2IpwrRX2";
			this.m_lblProfile2IpwrRX2.Size = new Size(28, 17);
			this.m_lblProfile2IpwrRX2.TabIndex = 79;
			this.m_lblProfile2IpwrRX2.Text = "0.0";
			this.m_lblProfile2QdcRX2.AutoSize = true;
			this.m_lblProfile2QdcRX2.Location = new Point(393, 363);
			this.m_lblProfile2QdcRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2QdcRX2.Name = "m_lblProfile2QdcRX2";
			this.m_lblProfile2QdcRX2.Size = new Size(28, 17);
			this.m_lblProfile2QdcRX2.TabIndex = 78;
			this.m_lblProfile2QdcRX2.Text = "0.0";
			this.m_lblProfile2IdcRX2.AutoSize = true;
			this.m_lblProfile2IdcRX2.Location = new Point(393, 338);
			this.m_lblProfile2IdcRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IdcRX2.Name = "m_lblProfile2IdcRX2";
			this.m_lblProfile2IdcRX2.Size = new Size(28, 17);
			this.m_lblProfile2IdcRX2.TabIndex = 77;
			this.m_lblProfile2IdcRX2.Text = "0.0";
			this.m_lblProfile2IQcrosscorrRX1.AutoSize = true;
			this.m_lblProfile2IQcrosscorrRX1.Location = new Point(251, 437);
			this.m_lblProfile2IQcrosscorrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IQcrosscorrRX1.Name = "m_lblProfile2IQcrosscorrRX1";
			this.m_lblProfile2IQcrosscorrRX1.Size = new Size(28, 17);
			this.m_lblProfile2IQcrosscorrRX1.TabIndex = 76;
			this.m_lblProfile2IQcrosscorrRX1.Text = "0.0";
			this.m_lblProfile2QpwrRX1.AutoSize = true;
			this.m_lblProfile2QpwrRX1.Location = new Point(251, 412);
			this.m_lblProfile2QpwrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2QpwrRX1.Name = "m_lblProfile2QpwrRX1";
			this.m_lblProfile2QpwrRX1.Size = new Size(28, 17);
			this.m_lblProfile2QpwrRX1.TabIndex = 75;
			this.m_lblProfile2QpwrRX1.Text = "0.0";
			this.m_lblProfile2IpwrRX1.AutoSize = true;
			this.m_lblProfile2IpwrRX1.Location = new Point(251, 388);
			this.m_lblProfile2IpwrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IpwrRX1.Name = "m_lblProfile2IpwrRX1";
			this.m_lblProfile2IpwrRX1.Size = new Size(28, 17);
			this.m_lblProfile2IpwrRX1.TabIndex = 74;
			this.m_lblProfile2IpwrRX1.Text = "0.0";
			this.m_lblProfile2QdcRX1.AutoSize = true;
			this.m_lblProfile2QdcRX1.Location = new Point(251, 363);
			this.m_lblProfile2QdcRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2QdcRX1.Name = "m_lblProfile2QdcRX1";
			this.m_lblProfile2QdcRX1.Size = new Size(28, 17);
			this.m_lblProfile2QdcRX1.TabIndex = 73;
			this.m_lblProfile2QdcRX1.Text = "0.0";
			this.m_lblProfile2IdcRX1.AutoSize = true;
			this.m_lblProfile2IdcRX1.Location = new Point(251, 338);
			this.m_lblProfile2IdcRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile2IdcRX1.Name = "m_lblProfile2IdcRX1";
			this.m_lblProfile2IdcRX1.Size = new Size(28, 17);
			this.m_lblProfile2IdcRX1.TabIndex = 72;
			this.m_lblProfile2IdcRX1.Text = "0.0";
			this.m_lblProfile1IQcrosscorrRX4.AutoSize = true;
			this.m_lblProfile1IQcrosscorrRX4.Location = new Point(647, 302);
			this.m_lblProfile1IQcrosscorrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IQcrosscorrRX4.Name = "m_lblProfile1IQcrosscorrRX4";
			this.m_lblProfile1IQcrosscorrRX4.Size = new Size(28, 17);
			this.m_lblProfile1IQcrosscorrRX4.TabIndex = 71;
			this.m_lblProfile1IQcrosscorrRX4.Text = "0.0";
			this.m_lblProfile1QpwrRX4.AutoSize = true;
			this.m_lblProfile1QpwrRX4.Location = new Point(647, 277);
			this.m_lblProfile1QpwrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1QpwrRX4.Name = "m_lblProfile1QpwrRX4";
			this.m_lblProfile1QpwrRX4.Size = new Size(28, 17);
			this.m_lblProfile1QpwrRX4.TabIndex = 70;
			this.m_lblProfile1QpwrRX4.Text = "0.0";
			this.m_lblProfile1IpwrRX4.AutoSize = true;
			this.m_lblProfile1IpwrRX4.Location = new Point(647, 252);
			this.m_lblProfile1IpwrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IpwrRX4.Name = "m_lblProfile1IpwrRX4";
			this.m_lblProfile1IpwrRX4.Size = new Size(28, 17);
			this.m_lblProfile1IpwrRX4.TabIndex = 69;
			this.m_lblProfile1IpwrRX4.Text = "0.0";
			this.m_lblProfile1QdcRX4.AutoSize = true;
			this.m_lblProfile1QdcRX4.Location = new Point(647, 228);
			this.m_lblProfile1QdcRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1QdcRX4.Name = "m_lblProfile1QdcRX4";
			this.m_lblProfile1QdcRX4.Size = new Size(28, 17);
			this.m_lblProfile1QdcRX4.TabIndex = 68;
			this.m_lblProfile1QdcRX4.Text = "0.0";
			this.m_lblProfile1IdcRX4.AutoSize = true;
			this.m_lblProfile1IdcRX4.Location = new Point(647, 203);
			this.m_lblProfile1IdcRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IdcRX4.Name = "m_lblProfile1IdcRX4";
			this.m_lblProfile1IdcRX4.Size = new Size(28, 17);
			this.m_lblProfile1IdcRX4.TabIndex = 67;
			this.m_lblProfile1IdcRX4.Text = "0.0";
			this.m_lblProfile1IQcrosscorrRX3.AutoSize = true;
			this.m_lblProfile1IQcrosscorrRX3.Location = new Point(535, 302);
			this.m_lblProfile1IQcrosscorrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IQcrosscorrRX3.Name = "m_lblProfile1IQcrosscorrRX3";
			this.m_lblProfile1IQcrosscorrRX3.Size = new Size(28, 17);
			this.m_lblProfile1IQcrosscorrRX3.TabIndex = 66;
			this.m_lblProfile1IQcrosscorrRX3.Text = "0.0";
			this.m_lblProfile1QpwrRX3.AutoSize = true;
			this.m_lblProfile1QpwrRX3.Location = new Point(535, 277);
			this.m_lblProfile1QpwrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1QpwrRX3.Name = "m_lblProfile1QpwrRX3";
			this.m_lblProfile1QpwrRX3.Size = new Size(28, 17);
			this.m_lblProfile1QpwrRX3.TabIndex = 65;
			this.m_lblProfile1QpwrRX3.Text = "0.0";
			this.m_lblProfile1IpwrRX3.AutoSize = true;
			this.m_lblProfile1IpwrRX3.Location = new Point(535, 252);
			this.m_lblProfile1IpwrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IpwrRX3.Name = "m_lblProfile1IpwrRX3";
			this.m_lblProfile1IpwrRX3.Size = new Size(28, 17);
			this.m_lblProfile1IpwrRX3.TabIndex = 64;
			this.m_lblProfile1IpwrRX3.Text = "0.0";
			this.m_lblProfile1QdcRX3.AutoSize = true;
			this.m_lblProfile1QdcRX3.Location = new Point(535, 228);
			this.m_lblProfile1QdcRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1QdcRX3.Name = "m_lblProfile1QdcRX3";
			this.m_lblProfile1QdcRX3.Size = new Size(28, 17);
			this.m_lblProfile1QdcRX3.TabIndex = 63;
			this.m_lblProfile1QdcRX3.Text = "0.0";
			this.m_lblProfile1IdcRX3.AutoSize = true;
			this.m_lblProfile1IdcRX3.Location = new Point(535, 203);
			this.m_lblProfile1IdcRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IdcRX3.Name = "m_lblProfile1IdcRX3";
			this.m_lblProfile1IdcRX3.Size = new Size(28, 17);
			this.m_lblProfile1IdcRX3.TabIndex = 62;
			this.m_lblProfile1IdcRX3.Text = "0.0";
			this.m_lblProfile1IQcrosscorrRX2.AutoSize = true;
			this.m_lblProfile1IQcrosscorrRX2.Location = new Point(393, 302);
			this.m_lblProfile1IQcrosscorrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IQcrosscorrRX2.Name = "m_lblProfile1IQcrosscorrRX2";
			this.m_lblProfile1IQcrosscorrRX2.Size = new Size(28, 17);
			this.m_lblProfile1IQcrosscorrRX2.TabIndex = 61;
			this.m_lblProfile1IQcrosscorrRX2.Text = "0.0";
			this.m_lblProfile1QpwrRX2.AutoSize = true;
			this.m_lblProfile1QpwrRX2.Location = new Point(393, 277);
			this.m_lblProfile1QpwrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1QpwrRX2.Name = "m_lblProfile1QpwrRX2";
			this.m_lblProfile1QpwrRX2.Size = new Size(28, 17);
			this.m_lblProfile1QpwrRX2.TabIndex = 60;
			this.m_lblProfile1QpwrRX2.Text = "0.0";
			this.m_lblProfile1IpwrRX2.AutoSize = true;
			this.m_lblProfile1IpwrRX2.Location = new Point(393, 252);
			this.m_lblProfile1IpwrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IpwrRX2.Name = "m_lblProfile1IpwrRX2";
			this.m_lblProfile1IpwrRX2.Size = new Size(28, 17);
			this.m_lblProfile1IpwrRX2.TabIndex = 59;
			this.m_lblProfile1IpwrRX2.Text = "0.0";
			this.m_lblProfile1QdcRX2.AutoSize = true;
			this.m_lblProfile1QdcRX2.Location = new Point(393, 228);
			this.m_lblProfile1QdcRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1QdcRX2.Name = "m_lblProfile1QdcRX2";
			this.m_lblProfile1QdcRX2.Size = new Size(28, 17);
			this.m_lblProfile1QdcRX2.TabIndex = 58;
			this.m_lblProfile1QdcRX2.Text = "0.0";
			this.m_lblProfile1IdcRX2.AutoSize = true;
			this.m_lblProfile1IdcRX2.Location = new Point(393, 203);
			this.m_lblProfile1IdcRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IdcRX2.Name = "m_lblProfile1IdcRX2";
			this.m_lblProfile1IdcRX2.Size = new Size(28, 17);
			this.m_lblProfile1IdcRX2.TabIndex = 57;
			this.m_lblProfile1IdcRX2.Text = "0.0";
			this.m_lblProfile1IQcrosscorrRX1.AutoSize = true;
			this.m_lblProfile1IQcrosscorrRX1.Location = new Point(251, 302);
			this.m_lblProfile1IQcrosscorrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IQcrosscorrRX1.Name = "m_lblProfile1IQcrosscorrRX1";
			this.m_lblProfile1IQcrosscorrRX1.Size = new Size(28, 17);
			this.m_lblProfile1IQcrosscorrRX1.TabIndex = 56;
			this.m_lblProfile1IQcrosscorrRX1.Text = "0.0";
			this.m_lblProfile1QpwrRX1.AutoSize = true;
			this.m_lblProfile1QpwrRX1.Location = new Point(251, 277);
			this.m_lblProfile1QpwrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1QpwrRX1.Name = "m_lblProfile1QpwrRX1";
			this.m_lblProfile1QpwrRX1.Size = new Size(28, 17);
			this.m_lblProfile1QpwrRX1.TabIndex = 55;
			this.m_lblProfile1QpwrRX1.Text = "0.0";
			this.m_lblProfile1IpwrRX1.AutoSize = true;
			this.m_lblProfile1IpwrRX1.Location = new Point(251, 252);
			this.m_lblProfile1IpwrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IpwrRX1.Name = "m_lblProfile1IpwrRX1";
			this.m_lblProfile1IpwrRX1.Size = new Size(28, 17);
			this.m_lblProfile1IpwrRX1.TabIndex = 54;
			this.m_lblProfile1IpwrRX1.Text = "0.0";
			this.m_lblProfile1QdcRX1.AutoSize = true;
			this.m_lblProfile1QdcRX1.Location = new Point(251, 228);
			this.m_lblProfile1QdcRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1QdcRX1.Name = "m_lblProfile1QdcRX1";
			this.m_lblProfile1QdcRX1.Size = new Size(28, 17);
			this.m_lblProfile1QdcRX1.TabIndex = 53;
			this.m_lblProfile1QdcRX1.Text = "0.0";
			this.m_lblProfile1IdcRX1.AutoSize = true;
			this.m_lblProfile1IdcRX1.Location = new Point(251, 203);
			this.m_lblProfile1IdcRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile1IdcRX1.Name = "m_lblProfile1IdcRX1";
			this.m_lblProfile1IdcRX1.Size = new Size(28, 17);
			this.m_lblProfile1IdcRX1.TabIndex = 52;
			this.m_lblProfile1IdcRX1.Text = "0.0";
			this.m_lblProfile0IQcrosscorrRX4.AutoSize = true;
			this.m_lblProfile0IQcrosscorrRX4.Location = new Point(647, 154);
			this.m_lblProfile0IQcrosscorrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IQcrosscorrRX4.Name = "m_lblProfile0IQcrosscorrRX4";
			this.m_lblProfile0IQcrosscorrRX4.Size = new Size(28, 17);
			this.m_lblProfile0IQcrosscorrRX4.TabIndex = 51;
			this.m_lblProfile0IQcrosscorrRX4.Text = "0.0";
			this.m_lblProfile0QpwrRX4.AutoSize = true;
			this.m_lblProfile0QpwrRX4.Location = new Point(647, 129);
			this.m_lblProfile0QpwrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0QpwrRX4.Name = "m_lblProfile0QpwrRX4";
			this.m_lblProfile0QpwrRX4.Size = new Size(28, 17);
			this.m_lblProfile0QpwrRX4.TabIndex = 50;
			this.m_lblProfile0QpwrRX4.Text = "0.0";
			this.m_lblProfile0IpwrRX4.AutoSize = true;
			this.m_lblProfile0IpwrRX4.Location = new Point(647, 105);
			this.m_lblProfile0IpwrRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IpwrRX4.Name = "m_lblProfile0IpwrRX4";
			this.m_lblProfile0IpwrRX4.Size = new Size(28, 17);
			this.m_lblProfile0IpwrRX4.TabIndex = 49;
			this.m_lblProfile0IpwrRX4.Text = "0.0";
			this.m_lblProfile0QdcRX4.AutoSize = true;
			this.m_lblProfile0QdcRX4.Location = new Point(647, 80);
			this.m_lblProfile0QdcRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0QdcRX4.Name = "m_lblProfile0QdcRX4";
			this.m_lblProfile0QdcRX4.Size = new Size(28, 17);
			this.m_lblProfile0QdcRX4.TabIndex = 48;
			this.m_lblProfile0QdcRX4.Text = "0.0";
			this.m_lblProfile0IdcRX4.AutoSize = true;
			this.m_lblProfile0IdcRX4.Location = new Point(647, 55);
			this.m_lblProfile0IdcRX4.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IdcRX4.Name = "m_lblProfile0IdcRX4";
			this.m_lblProfile0IdcRX4.Size = new Size(28, 17);
			this.m_lblProfile0IdcRX4.TabIndex = 47;
			this.m_lblProfile0IdcRX4.Text = "0.0";
			this.m_lblProfile0IQcrosscorrRX3.AutoSize = true;
			this.m_lblProfile0IQcrosscorrRX3.Location = new Point(535, 154);
			this.m_lblProfile0IQcrosscorrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IQcrosscorrRX3.Name = "m_lblProfile0IQcrosscorrRX3";
			this.m_lblProfile0IQcrosscorrRX3.Size = new Size(28, 17);
			this.m_lblProfile0IQcrosscorrRX3.TabIndex = 46;
			this.m_lblProfile0IQcrosscorrRX3.Text = "0.0";
			this.m_lblProfile0QpwrRX3.AutoSize = true;
			this.m_lblProfile0QpwrRX3.Location = new Point(535, 129);
			this.m_lblProfile0QpwrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0QpwrRX3.Name = "m_lblProfile0QpwrRX3";
			this.m_lblProfile0QpwrRX3.Size = new Size(28, 17);
			this.m_lblProfile0QpwrRX3.TabIndex = 45;
			this.m_lblProfile0QpwrRX3.Text = "0.0";
			this.m_lblProfile0IpwrRX3.AutoSize = true;
			this.m_lblProfile0IpwrRX3.Location = new Point(535, 105);
			this.m_lblProfile0IpwrRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IpwrRX3.Name = "m_lblProfile0IpwrRX3";
			this.m_lblProfile0IpwrRX3.Size = new Size(28, 17);
			this.m_lblProfile0IpwrRX3.TabIndex = 44;
			this.m_lblProfile0IpwrRX3.Text = "0.0";
			this.m_lblProfile0QdcRX3.AutoSize = true;
			this.m_lblProfile0QdcRX3.Location = new Point(535, 80);
			this.m_lblProfile0QdcRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0QdcRX3.Name = "m_lblProfile0QdcRX3";
			this.m_lblProfile0QdcRX3.Size = new Size(28, 17);
			this.m_lblProfile0QdcRX3.TabIndex = 43;
			this.m_lblProfile0QdcRX3.Text = "0.0";
			this.m_lblProfile0IdcRX3.AutoSize = true;
			this.m_lblProfile0IdcRX3.Location = new Point(535, 55);
			this.m_lblProfile0IdcRX3.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IdcRX3.Name = "m_lblProfile0IdcRX3";
			this.m_lblProfile0IdcRX3.Size = new Size(28, 17);
			this.m_lblProfile0IdcRX3.TabIndex = 42;
			this.m_lblProfile0IdcRX3.Text = "0.0";
			this.m_lblProfile0IQcrosscorrRX2.AutoSize = true;
			this.m_lblProfile0IQcrosscorrRX2.Location = new Point(393, 154);
			this.m_lblProfile0IQcrosscorrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IQcrosscorrRX2.Name = "m_lblProfile0IQcrosscorrRX2";
			this.m_lblProfile0IQcrosscorrRX2.Size = new Size(28, 17);
			this.m_lblProfile0IQcrosscorrRX2.TabIndex = 41;
			this.m_lblProfile0IQcrosscorrRX2.Text = "0.0";
			this.m_lblProfile0QpwrRX2.AutoSize = true;
			this.m_lblProfile0QpwrRX2.Location = new Point(393, 129);
			this.m_lblProfile0QpwrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0QpwrRX2.Name = "m_lblProfile0QpwrRX2";
			this.m_lblProfile0QpwrRX2.Size = new Size(28, 17);
			this.m_lblProfile0QpwrRX2.TabIndex = 40;
			this.m_lblProfile0QpwrRX2.Text = "0.0";
			this.m_lblProfile0IpwrRX2.AutoSize = true;
			this.m_lblProfile0IpwrRX2.Location = new Point(393, 105);
			this.m_lblProfile0IpwrRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IpwrRX2.Name = "m_lblProfile0IpwrRX2";
			this.m_lblProfile0IpwrRX2.Size = new Size(28, 17);
			this.m_lblProfile0IpwrRX2.TabIndex = 39;
			this.m_lblProfile0IpwrRX2.Text = "0.0";
			this.m_lblProfile0QdcRX2.AutoSize = true;
			this.m_lblProfile0QdcRX2.Location = new Point(393, 80);
			this.m_lblProfile0QdcRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0QdcRX2.Name = "m_lblProfile0QdcRX2";
			this.m_lblProfile0QdcRX2.Size = new Size(28, 17);
			this.m_lblProfile0QdcRX2.TabIndex = 38;
			this.m_lblProfile0QdcRX2.Text = "0.0";
			this.m_lblProfile0IdcRX2.AutoSize = true;
			this.m_lblProfile0IdcRX2.Location = new Point(393, 55);
			this.m_lblProfile0IdcRX2.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IdcRX2.Name = "m_lblProfile0IdcRX2";
			this.m_lblProfile0IdcRX2.Size = new Size(28, 17);
			this.m_lblProfile0IdcRX2.TabIndex = 37;
			this.m_lblProfile0IdcRX2.Text = "0.0";
			this.m_lblProfile0IdcRX2.Click += this.m_lblProfile0IdcRX2_Click;
			this.m_lblProfile0IQcrosscorrRX1.AutoSize = true;
			this.m_lblProfile0IQcrosscorrRX1.Location = new Point(251, 154);
			this.m_lblProfile0IQcrosscorrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IQcrosscorrRX1.Name = "m_lblProfile0IQcrosscorrRX1";
			this.m_lblProfile0IQcrosscorrRX1.Size = new Size(28, 17);
			this.m_lblProfile0IQcrosscorrRX1.TabIndex = 36;
			this.m_lblProfile0IQcrosscorrRX1.Text = "0.0";
			this.m_lblProfile0QpwrRX1.AutoSize = true;
			this.m_lblProfile0QpwrRX1.Location = new Point(251, 129);
			this.m_lblProfile0QpwrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0QpwrRX1.Name = "m_lblProfile0QpwrRX1";
			this.m_lblProfile0QpwrRX1.Size = new Size(28, 17);
			this.m_lblProfile0QpwrRX1.TabIndex = 35;
			this.m_lblProfile0QpwrRX1.Text = "0.0";
			this.m_lblProfile0IpwrRX1.AutoSize = true;
			this.m_lblProfile0IpwrRX1.Location = new Point(251, 105);
			this.m_lblProfile0IpwrRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IpwrRX1.Name = "m_lblProfile0IpwrRX1";
			this.m_lblProfile0IpwrRX1.Size = new Size(28, 17);
			this.m_lblProfile0IpwrRX1.TabIndex = 34;
			this.m_lblProfile0IpwrRX1.Text = "0.0";
			this.m_lblProfile0QdcRX1.AutoSize = true;
			this.m_lblProfile0QdcRX1.Location = new Point(251, 80);
			this.m_lblProfile0QdcRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0QdcRX1.Name = "m_lblProfile0QdcRX1";
			this.m_lblProfile0QdcRX1.Size = new Size(28, 17);
			this.m_lblProfile0QdcRX1.TabIndex = 33;
			this.m_lblProfile0QdcRX1.Text = "0.0";
			this.m_lblProfile0IdcRX1.AutoSize = true;
			this.m_lblProfile0IdcRX1.Location = new Point(251, 55);
			this.m_lblProfile0IdcRX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0IdcRX1.Name = "m_lblProfile0IdcRX1";
			this.m_lblProfile0IdcRX1.Size = new Size(28, 17);
			this.m_lblProfile0IdcRX1.TabIndex = 32;
			this.m_lblProfile0IdcRX1.Text = "0.0";
			this.m_btnDFEStaticReportGet.Location = new Point(825, 560);
			this.m_btnDFEStaticReportGet.Margin = new Padding(4, 4, 4, 4);
			this.m_btnDFEStaticReportGet.Name = "m_btnDFEStaticReportGet";
			this.m_btnDFEStaticReportGet.Size = new Size(100, 44);
			this.m_btnDFEStaticReportGet.TabIndex = 31;
			this.m_btnDFEStaticReportGet.Text = "Get";
			this.m_btnDFEStaticReportGet.UseVisualStyleBackColor = true;
			this.m_btnDFEStaticReportGet.Click += this.m_btnDFEStaticReportGet_Click;
			this.pictureBox3.BackColor = SystemColors.ControlDarkDark;
			this.pictureBox3.Location = new Point(96, 465);
			this.pictureBox3.Margin = new Padding(4, 4, 4, 4);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new Size(520, 2);
			this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
			this.pictureBox3.TabIndex = 30;
			this.pictureBox3.TabStop = false;
			this.pictureBox2.BackColor = SystemColors.ControlDarkDark;
			this.pictureBox2.Location = new Point(96, 327);
			this.pictureBox2.Margin = new Padding(4, 4, 4, 4);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(520, 2);
			this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 29;
			this.pictureBox2.TabStop = false;
			this.label92.AutoSize = true;
			this.label92.Location = new Point(8, 529);
			this.label92.Margin = new Padding(4, 0, 4, 0);
			this.label92.Name = "label92";
			this.label92.Size = new Size(74, 17);
			this.label92.TabIndex = 28;
			this.label92.Text = "PROFILE3";
			this.label91.AutoSize = true;
			this.label91.Location = new Point(8, 388);
			this.label91.Margin = new Padding(4, 0, 4, 0);
			this.label91.Name = "label91";
			this.label91.Size = new Size(74, 17);
			this.label91.TabIndex = 27;
			this.label91.Text = "PROFILE2";
			this.label86.AutoSize = true;
			this.label86.Location = new Point(93, 529);
			this.label86.Margin = new Padding(4, 0, 4, 0);
			this.label86.Name = "label86";
			this.label86.Size = new Size(33, 17);
			this.label86.TabIndex = 26;
			this.label86.Text = "Ipwr";
			this.label87.AutoSize = true;
			this.label87.Location = new Point(93, 505);
			this.label87.Margin = new Padding(4, 0, 4, 0);
			this.label87.Name = "label87";
			this.label87.Size = new Size(34, 17);
			this.label87.TabIndex = 25;
			this.label87.Text = "Qdc";
			this.label88.AutoSize = true;
			this.label88.Location = new Point(93, 554);
			this.label88.Margin = new Padding(4, 0, 4, 0);
			this.label88.Name = "label88";
			this.label88.Size = new Size(41, 17);
			this.label88.TabIndex = 24;
			this.label88.Text = "Qpwr";
			this.label89.AutoSize = true;
			this.label89.Location = new Point(93, 578);
			this.label89.Margin = new Padding(4, 0, 4, 0);
			this.label89.Name = "label89";
			this.label89.Size = new Size(81, 17);
			this.label89.TabIndex = 23;
			this.label89.Text = "IQcrosscorr";
			this.label90.AutoSize = true;
			this.label90.Location = new Point(93, 480);
			this.label90.Margin = new Padding(4, 0, 4, 0);
			this.label90.Name = "label90";
			this.label90.Size = new Size(26, 17);
			this.label90.TabIndex = 22;
			this.label90.Text = "Idc";
			this.label84.AutoSize = true;
			this.label84.Location = new Point(93, 388);
			this.label84.Margin = new Padding(4, 0, 4, 0);
			this.label84.Name = "label84";
			this.label84.Size = new Size(33, 17);
			this.label84.TabIndex = 21;
			this.label84.Text = "Ipwr";
			this.label85.AutoSize = true;
			this.label85.Location = new Point(93, 363);
			this.label85.Margin = new Padding(4, 0, 4, 0);
			this.label85.Name = "label85";
			this.label85.Size = new Size(34, 17);
			this.label85.TabIndex = 20;
			this.label85.Text = "Qdc";
			this.label82.AutoSize = true;
			this.label82.Location = new Point(93, 412);
			this.label82.Margin = new Padding(4, 0, 4, 0);
			this.label82.Name = "label82";
			this.label82.Size = new Size(41, 17);
			this.label82.TabIndex = 19;
			this.label82.Text = "Qpwr";
			this.label83.AutoSize = true;
			this.label83.Location = new Point(93, 437);
			this.label83.Margin = new Padding(4, 0, 4, 0);
			this.label83.Name = "label83";
			this.label83.Size = new Size(81, 17);
			this.label83.TabIndex = 18;
			this.label83.Text = "IQcrosscorr";
			this.label80.AutoSize = true;
			this.label80.Location = new Point(93, 338);
			this.label80.Margin = new Padding(4, 0, 4, 0);
			this.label80.Name = "label80";
			this.label80.Size = new Size(26, 17);
			this.label80.TabIndex = 17;
			this.label80.Text = "Idc";
			this.label81.AutoSize = true;
			this.label81.Location = new Point(93, 302);
			this.label81.Margin = new Padding(4, 0, 4, 0);
			this.label81.Name = "label81";
			this.label81.Size = new Size(81, 17);
			this.label81.TabIndex = 16;
			this.label81.Text = "IQcrosscorr";
			this.label78.AutoSize = true;
			this.label78.Location = new Point(93, 277);
			this.label78.Margin = new Padding(4, 0, 4, 0);
			this.label78.Name = "label78";
			this.label78.Size = new Size(41, 17);
			this.label78.TabIndex = 15;
			this.label78.Text = "Qpwr";
			this.label79.AutoSize = true;
			this.label79.Location = new Point(93, 252);
			this.label79.Margin = new Padding(4, 0, 4, 0);
			this.label79.Name = "label79";
			this.label79.Size = new Size(33, 17);
			this.label79.TabIndex = 14;
			this.label79.Text = "Ipwr";
			this.label77.AutoSize = true;
			this.label77.Location = new Point(93, 228);
			this.label77.Margin = new Padding(4, 0, 4, 0);
			this.label77.Name = "label77";
			this.label77.Size = new Size(34, 17);
			this.label77.TabIndex = 13;
			this.label77.Text = "Qdc";
			this.label76.AutoSize = true;
			this.label76.Location = new Point(93, 203);
			this.label76.Margin = new Padding(4, 0, 4, 0);
			this.label76.Name = "label76";
			this.label76.Size = new Size(26, 17);
			this.label76.TabIndex = 12;
			this.label76.Text = "Idc";
			this.pictureBox1.BackColor = SystemColors.ControlDarkDark;
			this.pictureBox1.Location = new Point(96, 188);
			this.pictureBox1.Margin = new Padding(4, 4, 4, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(520, 2);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			this.label75.AutoSize = true;
			this.label75.Location = new Point(8, 252);
			this.label75.Margin = new Padding(4, 0, 4, 0);
			this.label75.Name = "label75";
			this.label75.Size = new Size(74, 17);
			this.label75.TabIndex = 10;
			this.label75.Text = "PROFILE1";
			this.label73.AutoSize = true;
			this.label73.Location = new Point(7, 105);
			this.label73.Margin = new Padding(4, 0, 4, 0);
			this.label73.Name = "label73";
			this.label73.Size = new Size(74, 17);
			this.label73.TabIndex = 9;
			this.label73.Text = "PROFILE0";
			this.label74.AutoSize = true;
			this.label74.Location = new Point(93, 154);
			this.label74.Margin = new Padding(4, 0, 4, 0);
			this.label74.Name = "label74";
			this.label74.Size = new Size(154, 17);
			this.label74.TabIndex = 8;
			this.label74.Text = "IQcrosscorr (V^2/2^30)";
			this.label71.AutoSize = true;
			this.label71.Location = new Point(93, 129);
			this.label71.Margin = new Padding(4, 0, 4, 0);
			this.label71.Name = "label71";
			this.label71.Size = new Size(114, 17);
			this.label71.TabIndex = 7;
			this.label71.Text = "Qpwr (V^2/2^15)";
			this.m_lblProfile0RX1.AccessibleRole = AccessibleRole.Indicator;
			this.m_lblProfile0RX1.AutoSize = true;
			this.m_lblProfile0RX1.Location = new Point(93, 105);
			this.m_lblProfile0RX1.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0RX1.Name = "m_lblProfile0RX1";
			this.m_lblProfile0RX1.Size = new Size(106, 17);
			this.m_lblProfile0RX1.TabIndex = 6;
			this.m_lblProfile0RX1.Text = "Ipwr (V^2/2^15)";
			this.label70.AutoSize = true;
			this.label70.Location = new Point(93, 80);
			this.label70.Margin = new Padding(4, 0, 4, 0);
			this.label70.Name = "label70";
			this.label70.Size = new Size(92, 17);
			this.label70.TabIndex = 5;
			this.label70.Text = "Qdc (V/2^15)";
			this.m_lblProfile0Idc.AutoSize = true;
			this.m_lblProfile0Idc.Location = new Point(93, 55);
			this.m_lblProfile0Idc.Margin = new Padding(4, 0, 4, 0);
			this.m_lblProfile0Idc.Name = "m_lblProfile0Idc";
			this.m_lblProfile0Idc.Size = new Size(84, 17);
			this.m_lblProfile0Idc.TabIndex = 4;
			this.m_lblProfile0Idc.Text = "Idc (V/2^15)";
			this.label67.AutoSize = true;
			this.label67.Location = new Point(647, 22);
			this.label67.Margin = new Padding(4, 0, 4, 0);
			this.label67.Name = "label67";
			this.label67.Size = new Size(35, 17);
			this.label67.TabIndex = 3;
			this.label67.Text = "RX3";
			this.label68.AutoSize = true;
			this.label68.Location = new Point(535, 23);
			this.label68.Margin = new Padding(4, 0, 4, 0);
			this.label68.Name = "label68";
			this.label68.Size = new Size(35, 17);
			this.label68.TabIndex = 2;
			this.label68.Text = "RX2";
			this.label66.AutoSize = true;
			this.label66.Location = new Point(393, 23);
			this.label66.Margin = new Padding(4, 0, 4, 0);
			this.label66.Name = "label66";
			this.label66.Size = new Size(35, 17);
			this.label66.TabIndex = 1;
			this.label66.Text = "RX1";
			this.label65.AutoSize = true;
			this.label65.Location = new Point(251, 20);
			this.label65.Margin = new Padding(4, 0, 4, 0);
			this.label65.Name = "label65";
			this.label65.Size = new Size(35, 17);
			this.label65.TabIndex = 0;
			this.label65.Text = "RX0";
			this.f000185.Controls.Add(this.f000188);
			this.f000185.Controls.Add(this.f000189);
			this.f000185.Controls.Add(this.m_nudANATest4SettlingTimeCfg);
			this.f000185.Controls.Add(this.m_nudANATest3SettlingTimeCfg);
			this.f000185.Controls.Add(this.m_nudANATest2SettlingTimeCfg);
			this.f000185.Controls.Add(this.m_nudANATest1SettlingTimeCfg);
			this.f000185.Controls.Add(this.label35);
			this.f000185.Controls.Add(this.label34);
			this.f000185.Controls.Add(this.label33);
			this.f000185.Controls.Add(this.label32);
			this.f000185.Controls.Add(this.label31);
			this.f000185.Controls.Add(this.label30);
			this.f000185.Controls.Add(this.m_chbSigBufEnaANAMux);
			this.f000185.Controls.Add(this.m_chbSigBufEnaANATest4);
			this.f000185.Controls.Add(this.m_chbSigBufEnaANATest3);
			this.f000185.Controls.Add(this.m_chbSigBufEnaANATest2);
			this.f000185.Controls.Add(this.m_chbSigBufEnaANATest1);
			this.f000185.Controls.Add(this.label18);
			this.f000185.Controls.Add(this.f000186);
			this.f000185.Controls.Add(this.m_nudVSenseCfg);
			this.f000185.Controls.Add(this.m_nudIForceCfg);
			this.f000185.Controls.Add(this.m_nudANATest4Cfg);
			this.f000185.Controls.Add(this.m_nudANATest3Cfg);
			this.f000185.Controls.Add(this.m_nudANATest2Cfg);
			this.f000185.Controls.Add(this.m_nudANATest1Cfg);
			this.f000185.Controls.Add(this.m_chbVSense);
			this.f000185.Controls.Add(this.m_chbIForce);
			this.f000185.Controls.Add(this.m_chbANATest4);
			this.f000185.Controls.Add(this.m_chbANATest3);
			this.f000185.Controls.Add(this.m_chbANATest2);
			this.f000185.Controls.Add(this.m_chbANATest1);
			this.f000185.Controls.Add(this.label14);
			this.f000185.Controls.Add(this.label12);
			this.f000185.Controls.Add(this.label11);
			this.f000185.Location = new Point(20, 373);
			this.f000185.Margin = new Padding(4, 4, 4, 4);
			this.f000185.Name = "m_grpGPADCMeasurementCfg";
			this.f000185.Padding = new Padding(4, 4, 4, 4);
			this.f000185.Size = new Size(757, 220);
			this.f000185.TabIndex = 6;
			this.f000185.TabStop = false;
			this.f000185.Text = "GPADC Measurement Cfg";
			this.f000185.Enter += this.m000018;
			this.f000188.DecimalPlaces = 1;
			this.f000188.Increment = new decimal(new int[]
			{
				8,
				0,
				0,
				65536
			});
			this.f000188.Location = new Point(680, 143);
			this.f000188.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown = this.f000188;
			int[] array = new int[4];
			array[0] = 12;
			numericUpDown.Maximum = new decimal(array);
			this.f000188.Name = "m_nudVSENSESettlingTimeCfg";
			this.f000188.Size = new Size(68, 22);
			this.f000188.TabIndex = 40;
			this.f000189.DecimalPlaces = 1;
			this.f000189.Increment = new decimal(new int[]
			{
				8,
				0,
				0,
				65536
			});
			this.f000189.Location = new Point(589, 143);
			this.f000189.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown2 = this.f000189;
			int[] array2 = new int[4];
			array2[0] = 12;
			numericUpDown2.Maximum = new decimal(array2);
			this.f000189.Name = "m_nudANAMUXSettlingTimeCfg";
			this.f000189.Size = new Size(65, 22);
			this.f000189.TabIndex = 39;
			this.m_nudANATest4SettlingTimeCfg.DecimalPlaces = 1;
			this.m_nudANATest4SettlingTimeCfg.Increment = new decimal(new int[]
			{
				8,
				0,
				0,
				65536
			});
			this.m_nudANATest4SettlingTimeCfg.Location = new Point(480, 143);
			this.m_nudANATest4SettlingTimeCfg.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudANATest4SettlingTimeCfg = this.m_nudANATest4SettlingTimeCfg;
			int[] array3 = new int[4];
			array3[0] = 12;
			nudANATest4SettlingTimeCfg.Maximum = new decimal(array3);
			this.m_nudANATest4SettlingTimeCfg.Name = "m_nudANATest4SettlingTimeCfg";
			this.m_nudANATest4SettlingTimeCfg.Size = new Size(68, 22);
			this.m_nudANATest4SettlingTimeCfg.TabIndex = 38;
			this.m_nudANATest3SettlingTimeCfg.DecimalPlaces = 1;
			this.m_nudANATest3SettlingTimeCfg.Increment = new decimal(new int[]
			{
				8,
				0,
				0,
				65536
			});
			this.m_nudANATest3SettlingTimeCfg.Location = new Point(375, 143);
			this.m_nudANATest3SettlingTimeCfg.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudANATest3SettlingTimeCfg = this.m_nudANATest3SettlingTimeCfg;
			int[] array4 = new int[4];
			array4[0] = 12;
			nudANATest3SettlingTimeCfg.Maximum = new decimal(array4);
			this.m_nudANATest3SettlingTimeCfg.Name = "m_nudANATest3SettlingTimeCfg";
			this.m_nudANATest3SettlingTimeCfg.Size = new Size(68, 22);
			this.m_nudANATest3SettlingTimeCfg.TabIndex = 37;
			this.m_nudANATest2SettlingTimeCfg.DecimalPlaces = 1;
			this.m_nudANATest2SettlingTimeCfg.Increment = new decimal(new int[]
			{
				8,
				0,
				0,
				65536
			});
			this.m_nudANATest2SettlingTimeCfg.Location = new Point(267, 143);
			this.m_nudANATest2SettlingTimeCfg.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudANATest2SettlingTimeCfg = this.m_nudANATest2SettlingTimeCfg;
			int[] array5 = new int[4];
			array5[0] = 12;
			nudANATest2SettlingTimeCfg.Maximum = new decimal(array5);
			this.m_nudANATest2SettlingTimeCfg.Name = "m_nudANATest2SettlingTimeCfg";
			this.m_nudANATest2SettlingTimeCfg.Size = new Size(71, 22);
			this.m_nudANATest2SettlingTimeCfg.TabIndex = 36;
			this.m_nudANATest1SettlingTimeCfg.DecimalPlaces = 1;
			this.m_nudANATest1SettlingTimeCfg.Increment = new decimal(new int[]
			{
				8,
				0,
				0,
				65536
			});
			this.m_nudANATest1SettlingTimeCfg.Location = new Point(163, 143);
			this.m_nudANATest1SettlingTimeCfg.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudANATest1SettlingTimeCfg = this.m_nudANATest1SettlingTimeCfg;
			int[] array6 = new int[4];
			array6[0] = 12;
			nudANATest1SettlingTimeCfg.Maximum = new decimal(array6);
			this.m_nudANATest1SettlingTimeCfg.Name = "m_nudANATest1SettlingTimeCfg";
			this.m_nudANATest1SettlingTimeCfg.Size = new Size(68, 22);
			this.m_nudANATest1SettlingTimeCfg.TabIndex = 35;
			this.label35.AutoSize = true;
			this.label35.Location = new Point(680, 23);
			this.label35.Margin = new Padding(4, 0, 4, 0);
			this.label35.Name = "label35";
			this.label35.Size = new Size(63, 17);
			this.label35.TabIndex = 34;
			this.label35.Text = "VSENSE";
			this.label34.AutoSize = true;
			this.label34.Location = new Point(589, 23);
			this.label34.Margin = new Padding(4, 0, 4, 0);
			this.label34.Name = "label34";
			this.label34.Size = new Size(66, 17);
			this.label34.TabIndex = 33;
			this.label34.Text = "ANAMUX";
			this.label33.AutoSize = true;
			this.label33.Location = new Point(480, 23);
			this.label33.Margin = new Padding(4, 0, 4, 0);
			this.label33.Name = "label33";
			this.label33.Size = new Size(80, 17);
			this.label33.TabIndex = 32;
			this.label33.Text = "ANATEST4";
			this.label32.AutoSize = true;
			this.label32.Location = new Point(375, 23);
			this.label32.Margin = new Padding(4, 0, 4, 0);
			this.label32.Name = "label32";
			this.label32.Size = new Size(80, 17);
			this.label32.TabIndex = 31;
			this.label32.Text = "ANATEST3";
			this.label31.AutoSize = true;
			this.label31.Location = new Point(267, 23);
			this.label31.Margin = new Padding(4, 0, 4, 0);
			this.label31.Name = "label31";
			this.label31.Size = new Size(80, 17);
			this.label31.TabIndex = 30;
			this.label31.Text = "ANATEST2";
			this.label30.AutoSize = true;
			this.label30.Location = new Point(163, 23);
			this.label30.Margin = new Padding(4, 0, 4, 0);
			this.label30.Name = "label30";
			this.label30.Size = new Size(80, 17);
			this.label30.TabIndex = 29;
			this.label30.Text = "ANATEST1";
			this.label30.Click += this.label30_Click;
			this.m_chbSigBufEnaANAMux.AutoSize = true;
			this.m_chbSigBufEnaANAMux.Location = new Point(589, 82);
			this.m_chbSigBufEnaANAMux.Margin = new Padding(4, 4, 4, 4);
			this.m_chbSigBufEnaANAMux.Name = "m_chbSigBufEnaANAMux";
			this.m_chbSigBufEnaANAMux.Size = new Size(18, 17);
			this.m_chbSigBufEnaANAMux.TabIndex = 28;
			this.m_chbSigBufEnaANAMux.UseVisualStyleBackColor = true;
			this.m_chbSigBufEnaANATest4.AutoSize = true;
			this.m_chbSigBufEnaANATest4.Location = new Point(480, 82);
			this.m_chbSigBufEnaANATest4.Margin = new Padding(4, 4, 4, 4);
			this.m_chbSigBufEnaANATest4.Name = "m_chbSigBufEnaANATest4";
			this.m_chbSigBufEnaANATest4.Size = new Size(18, 17);
			this.m_chbSigBufEnaANATest4.TabIndex = 27;
			this.m_chbSigBufEnaANATest4.UseVisualStyleBackColor = true;
			this.m_chbSigBufEnaANATest3.AutoSize = true;
			this.m_chbSigBufEnaANATest3.Location = new Point(375, 84);
			this.m_chbSigBufEnaANATest3.Margin = new Padding(4, 4, 4, 4);
			this.m_chbSigBufEnaANATest3.Name = "m_chbSigBufEnaANATest3";
			this.m_chbSigBufEnaANATest3.Size = new Size(18, 17);
			this.m_chbSigBufEnaANATest3.TabIndex = 26;
			this.m_chbSigBufEnaANATest3.UseVisualStyleBackColor = true;
			this.m_chbSigBufEnaANATest2.AutoSize = true;
			this.m_chbSigBufEnaANATest2.Location = new Point(267, 84);
			this.m_chbSigBufEnaANATest2.Margin = new Padding(4, 4, 4, 4);
			this.m_chbSigBufEnaANATest2.Name = "m_chbSigBufEnaANATest2";
			this.m_chbSigBufEnaANATest2.Size = new Size(18, 17);
			this.m_chbSigBufEnaANATest2.TabIndex = 25;
			this.m_chbSigBufEnaANATest2.UseVisualStyleBackColor = true;
			this.m_chbSigBufEnaANATest1.AutoSize = true;
			this.m_chbSigBufEnaANATest1.Location = new Point(163, 82);
			this.m_chbSigBufEnaANATest1.Margin = new Padding(4, 4, 4, 4);
			this.m_chbSigBufEnaANATest1.Name = "m_chbSigBufEnaANATest1";
			this.m_chbSigBufEnaANATest1.Size = new Size(18, 17);
			this.m_chbSigBufEnaANATest1.TabIndex = 24;
			this.m_chbSigBufEnaANATest1.UseVisualStyleBackColor = true;
			this.label18.AutoSize = true;
			this.label18.Location = new Point(1, 82);
			this.label18.Margin = new Padding(4, 0, 4, 0);
			this.label18.Name = "label18";
			this.label18.Size = new Size(122, 17);
			this.label18.TabIndex = 23;
			this.label18.Text = " Signal Buffer Ena";
			this.f000186.Location = new Point(680, 176);
			this.f000186.Margin = new Padding(4, 4, 4, 4);
			this.f000186.Name = "m_btnGPADCExternalMeasurementCfgSet";
			this.f000186.Size = new Size(68, 33);
			this.f000186.TabIndex = 22;
			this.f000186.Text = "Set";
			this.f000186.UseVisualStyleBackColor = true;
			this.f000186.Click += this.m000016;
			this.m_nudVSenseCfg.Location = new Point(680, 110);
			this.m_nudVSenseCfg.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudVSenseCfg = this.m_nudVSenseCfg;
			int[] array7 = new int[4];
			array7[0] = 255;
			nudVSenseCfg.Maximum = new decimal(array7);
			this.m_nudVSenseCfg.Name = "m_nudVSenseCfg";
			this.m_nudVSenseCfg.Size = new Size(68, 22);
			this.m_nudVSenseCfg.TabIndex = 20;
			NumericUpDown nudVSenseCfg2 = this.m_nudVSenseCfg;
			int[] array8 = new int[4];
			array8[0] = 4;
			nudVSenseCfg2.Value = new decimal(array8);
			this.m_nudIForceCfg.Location = new Point(589, 110);
			this.m_nudIForceCfg.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudIForceCfg = this.m_nudIForceCfg;
			int[] array9 = new int[4];
			array9[0] = 255;
			nudIForceCfg.Maximum = new decimal(array9);
			this.m_nudIForceCfg.Name = "m_nudIForceCfg";
			this.m_nudIForceCfg.Size = new Size(68, 22);
			this.m_nudIForceCfg.TabIndex = 19;
			NumericUpDown nudIForceCfg2 = this.m_nudIForceCfg;
			int[] array10 = new int[4];
			array10[0] = 4;
			nudIForceCfg2.Value = new decimal(array10);
			this.m_nudIForceCfg.ValueChanged += this.m_nudIForceCfg_ValueChanged;
			this.m_nudANATest4Cfg.Location = new Point(480, 110);
			this.m_nudANATest4Cfg.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudANATest4Cfg = this.m_nudANATest4Cfg;
			int[] array11 = new int[4];
			array11[0] = 255;
			nudANATest4Cfg.Maximum = new decimal(array11);
			this.m_nudANATest4Cfg.Name = "m_nudANATest4Cfg";
			this.m_nudANATest4Cfg.Size = new Size(68, 22);
			this.m_nudANATest4Cfg.TabIndex = 18;
			NumericUpDown nudANATest4Cfg2 = this.m_nudANATest4Cfg;
			int[] array12 = new int[4];
			array12[0] = 4;
			nudANATest4Cfg2.Value = new decimal(array12);
			this.m_nudANATest3Cfg.Location = new Point(375, 110);
			this.m_nudANATest3Cfg.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudANATest3Cfg = this.m_nudANATest3Cfg;
			int[] array13 = new int[4];
			array13[0] = 255;
			nudANATest3Cfg.Maximum = new decimal(array13);
			this.m_nudANATest3Cfg.Name = "m_nudANATest3Cfg";
			this.m_nudANATest3Cfg.Size = new Size(68, 22);
			this.m_nudANATest3Cfg.TabIndex = 17;
			NumericUpDown nudANATest3Cfg2 = this.m_nudANATest3Cfg;
			int[] array14 = new int[4];
			array14[0] = 4;
			nudANATest3Cfg2.Value = new decimal(array14);
			this.m_nudANATest2Cfg.Location = new Point(267, 110);
			this.m_nudANATest2Cfg.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudANATest2Cfg = this.m_nudANATest2Cfg;
			int[] array15 = new int[4];
			array15[0] = 255;
			nudANATest2Cfg.Maximum = new decimal(array15);
			this.m_nudANATest2Cfg.Name = "m_nudANATest2Cfg";
			this.m_nudANATest2Cfg.Size = new Size(68, 22);
			this.m_nudANATest2Cfg.TabIndex = 16;
			NumericUpDown nudANATest2Cfg2 = this.m_nudANATest2Cfg;
			int[] array16 = new int[4];
			array16[0] = 4;
			nudANATest2Cfg2.Value = new decimal(array16);
			this.m_nudANATest1Cfg.Location = new Point(163, 110);
			this.m_nudANATest1Cfg.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudANATest1Cfg = this.m_nudANATest1Cfg;
			int[] array17 = new int[4];
			array17[0] = 255;
			nudANATest1Cfg.Maximum = new decimal(array17);
			this.m_nudANATest1Cfg.Name = "m_nudANATest1Cfg";
			this.m_nudANATest1Cfg.Size = new Size(68, 22);
			this.m_nudANATest1Cfg.TabIndex = 15;
			NumericUpDown nudANATest1Cfg2 = this.m_nudANATest1Cfg;
			int[] array18 = new int[4];
			array18[0] = 4;
			nudANATest1Cfg2.Value = new decimal(array18);
			this.m_chbVSense.AutoSize = true;
			this.m_chbVSense.Location = new Point(680, 55);
			this.m_chbVSense.Margin = new Padding(4, 4, 4, 4);
			this.m_chbVSense.Name = "m_chbVSense";
			this.m_chbVSense.Size = new Size(18, 17);
			this.m_chbVSense.TabIndex = 13;
			this.m_chbVSense.UseVisualStyleBackColor = true;
			this.m_chbVSense.CheckedChanged += this.m_chbVSense_CheckedChanged;
			this.m_chbIForce.AutoSize = true;
			this.m_chbIForce.Location = new Point(589, 54);
			this.m_chbIForce.Margin = new Padding(4, 4, 4, 4);
			this.m_chbIForce.Name = "m_chbIForce";
			this.m_chbIForce.Size = new Size(18, 17);
			this.m_chbIForce.TabIndex = 12;
			this.m_chbIForce.UseVisualStyleBackColor = true;
			this.m_chbANATest4.AutoSize = true;
			this.m_chbANATest4.Location = new Point(480, 54);
			this.m_chbANATest4.Margin = new Padding(4, 4, 4, 4);
			this.m_chbANATest4.Name = "m_chbANATest4";
			this.m_chbANATest4.Size = new Size(18, 17);
			this.m_chbANATest4.TabIndex = 11;
			this.m_chbANATest4.UseVisualStyleBackColor = true;
			this.m_chbANATest3.AutoSize = true;
			this.m_chbANATest3.Location = new Point(375, 54);
			this.m_chbANATest3.Margin = new Padding(4, 4, 4, 4);
			this.m_chbANATest3.Name = "m_chbANATest3";
			this.m_chbANATest3.Size = new Size(18, 17);
			this.m_chbANATest3.TabIndex = 10;
			this.m_chbANATest3.UseVisualStyleBackColor = true;
			this.m_chbANATest2.AutoSize = true;
			this.m_chbANATest2.Location = new Point(267, 54);
			this.m_chbANATest2.Margin = new Padding(4, 4, 4, 4);
			this.m_chbANATest2.Name = "m_chbANATest2";
			this.m_chbANATest2.Size = new Size(18, 17);
			this.m_chbANATest2.TabIndex = 9;
			this.m_chbANATest2.UseVisualStyleBackColor = true;
			this.m_chbANATest1.AutoSize = true;
			this.m_chbANATest1.Location = new Point(163, 54);
			this.m_chbANATest1.Margin = new Padding(4, 4, 4, 4);
			this.m_chbANATest1.Name = "m_chbANATest1";
			this.m_chbANATest1.Size = new Size(18, 17);
			this.m_chbANATest1.TabIndex = 8;
			this.m_chbANATest1.UseVisualStyleBackColor = true;
			this.label14.AutoSize = true;
			this.label14.Location = new Point(1, 144);
			this.label14.Margin = new Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new Size(119, 17);
			this.label14.TabIndex = 3;
			this.label14.Text = "Settling Time (µs)";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(1, 112);
			this.label12.Margin = new Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new Size(137, 17);
			this.label12.TabIndex = 1;
			this.label12.Text = "NumSamples Collect";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(1, 57);
			this.label11.Margin = new Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new Size(115, 17);
			this.label11.TabIndex = 0;
			this.label11.Text = " Signal Input Ena";
			this.label11.Click += this.label11_Click;
			this.label19.AutoSize = true;
			this.label19.Location = new Point(4, 651);
			this.label19.Margin = new Padding(4, 0, 4, 0);
			this.label19.Name = "label19";
			this.label19.Size = new Size(67, 17);
			this.label19.TabIndex = 7;
			this.label19.Text = "Max (mV)";
			this.label22.AutoSize = true;
			this.label22.Location = new Point(7, 687);
			this.label22.Margin = new Padding(4, 0, 4, 0);
			this.label22.Name = "label22";
			this.label22.Size = new Size(64, 17);
			this.label22.TabIndex = 8;
			this.label22.Text = "Min (mV)";
			this.label23.AutoSize = true;
			this.label23.Location = new Point(4, 729);
			this.label23.Margin = new Padding(4, 0, 4, 0);
			this.label23.Name = "label23";
			this.label23.Size = new Size(70, 17);
			this.label23.TabIndex = 9;
			this.label23.Text = "Avg  (mV)";
			this.label24.AutoSize = true;
			this.label24.Location = new Point(97, 617);
			this.label24.Margin = new Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new Size(80, 17);
			this.label24.TabIndex = 10;
			this.label24.Text = "ANATEST1";
			this.label25.AutoSize = true;
			this.label25.Location = new Point(204, 617);
			this.label25.Margin = new Padding(4, 0, 4, 0);
			this.label25.Name = "label25";
			this.label25.Size = new Size(80, 17);
			this.label25.TabIndex = 11;
			this.label25.Text = "ANATEST2";
			this.label26.AutoSize = true;
			this.label26.Location = new Point(313, 617);
			this.label26.Margin = new Padding(4, 0, 4, 0);
			this.label26.Name = "label26";
			this.label26.Size = new Size(80, 17);
			this.label26.TabIndex = 12;
			this.label26.Text = "ANATEST3";
			this.label27.AutoSize = true;
			this.label27.Location = new Point(425, 617);
			this.label27.Margin = new Padding(4, 0, 4, 0);
			this.label27.Name = "label27";
			this.label27.Size = new Size(80, 17);
			this.label27.TabIndex = 13;
			this.label27.Text = "ANATEST4";
			this.m_lblANATest1MaxiData.AutoSize = true;
			this.m_lblANATest1MaxiData.Location = new Point(96, 651);
			this.m_lblANATest1MaxiData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblANATest1MaxiData.Name = "m_lblANATest1MaxiData";
			this.m_lblANATest1MaxiData.Size = new Size(28, 17);
			this.m_lblANATest1MaxiData.TabIndex = 14;
			this.m_lblANATest1MaxiData.Text = "0.0";
			this.m_lblANATest1MinData.AutoSize = true;
			this.m_lblANATest1MinData.Location = new Point(96, 687);
			this.m_lblANATest1MinData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblANATest1MinData.Name = "m_lblANATest1MinData";
			this.m_lblANATest1MinData.Size = new Size(28, 17);
			this.m_lblANATest1MinData.TabIndex = 15;
			this.m_lblANATest1MinData.Text = "0.0";
			this.f000187.AutoSize = true;
			this.f000187.Location = new Point(96, 729);
			this.f000187.Margin = new Padding(4, 0, 4, 0);
			this.f000187.Name = "m_lblANATest1MAvgData";
			this.f000187.Size = new Size(28, 17);
			this.f000187.TabIndex = 16;
			this.f000187.Text = "0.0";
			this.m_lblANATest2MaxData.AutoSize = true;
			this.m_lblANATest2MaxData.Location = new Point(204, 729);
			this.m_lblANATest2MaxData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblANATest2MaxData.Name = "m_lblANATest2MaxData";
			this.m_lblANATest2MaxData.Size = new Size(28, 17);
			this.m_lblANATest2MaxData.TabIndex = 19;
			this.m_lblANATest2MaxData.Text = "0.0";
			this.m_lblANATest2MinData.AutoSize = true;
			this.m_lblANATest2MinData.Location = new Point(204, 687);
			this.m_lblANATest2MinData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblANATest2MinData.Name = "m_lblANATest2MinData";
			this.m_lblANATest2MinData.Size = new Size(28, 17);
			this.m_lblANATest2MinData.TabIndex = 18;
			this.m_lblANATest2MinData.Text = "0.0";
			this.m_lblANATest2MaxiData.AutoSize = true;
			this.m_lblANATest2MaxiData.Location = new Point(204, 651);
			this.m_lblANATest2MaxiData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblANATest2MaxiData.Name = "m_lblANATest2MaxiData";
			this.m_lblANATest2MaxiData.Size = new Size(28, 17);
			this.m_lblANATest2MaxiData.TabIndex = 17;
			this.m_lblANATest2MaxiData.Text = "0.0";
			this.m_lblANATest3MaxData.AutoSize = true;
			this.m_lblANATest3MaxData.Location = new Point(313, 729);
			this.m_lblANATest3MaxData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblANATest3MaxData.Name = "m_lblANATest3MaxData";
			this.m_lblANATest3MaxData.Size = new Size(28, 17);
			this.m_lblANATest3MaxData.TabIndex = 22;
			this.m_lblANATest3MaxData.Text = "0.0";
			this.m_lblANATest3MinData.AutoSize = true;
			this.m_lblANATest3MinData.Location = new Point(313, 687);
			this.m_lblANATest3MinData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblANATest3MinData.Name = "m_lblANATest3MinData";
			this.m_lblANATest3MinData.Size = new Size(28, 17);
			this.m_lblANATest3MinData.TabIndex = 21;
			this.m_lblANATest3MinData.Text = "0.0";
			this.m_lblANATest3MaxiData.AutoSize = true;
			this.m_lblANATest3MaxiData.Location = new Point(313, 651);
			this.m_lblANATest3MaxiData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblANATest3MaxiData.Name = "m_lblANATest3MaxiData";
			this.m_lblANATest3MaxiData.Size = new Size(28, 17);
			this.m_lblANATest3MaxiData.TabIndex = 20;
			this.m_lblANATest3MaxiData.Text = "0.0";
			this.m_lblANATest4MaxData.AutoSize = true;
			this.m_lblANATest4MaxData.Location = new Point(425, 729);
			this.m_lblANATest4MaxData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblANATest4MaxData.Name = "m_lblANATest4MaxData";
			this.m_lblANATest4MaxData.Size = new Size(28, 17);
			this.m_lblANATest4MaxData.TabIndex = 25;
			this.m_lblANATest4MaxData.Text = "0.0";
			this.m_lblANATest4MinData.AutoSize = true;
			this.m_lblANATest4MinData.Location = new Point(425, 687);
			this.m_lblANATest4MinData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblANATest4MinData.Name = "m_lblANATest4MinData";
			this.m_lblANATest4MinData.Size = new Size(28, 17);
			this.m_lblANATest4MinData.TabIndex = 24;
			this.m_lblANATest4MinData.Text = "0.0";
			this.m_lblANATest4MaxiData.AutoSize = true;
			this.m_lblANATest4MaxiData.Location = new Point(425, 651);
			this.m_lblANATest4MaxiData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblANATest4MaxiData.Name = "m_lblANATest4MaxiData";
			this.m_lblANATest4MaxiData.Size = new Size(28, 17);
			this.m_lblANATest4MaxiData.TabIndex = 23;
			this.m_lblANATest4MaxiData.Text = "0.0";
			this.label28.AutoSize = true;
			this.label28.Location = new Point(537, 615);
			this.label28.Margin = new Padding(4, 0, 4, 0);
			this.label28.Name = "label28";
			this.label28.Size = new Size(66, 17);
			this.label28.TabIndex = 26;
			this.label28.Text = "ANAMUX";
			this.label29.AutoSize = true;
			this.label29.Location = new Point(648, 615);
			this.label29.Margin = new Padding(4, 0, 4, 0);
			this.label29.Name = "label29";
			this.label29.Size = new Size(64, 17);
			this.label29.TabIndex = 27;
			this.label29.Text = "VFORCE";
			this.m_lblIForceBuf.AutoSize = true;
			this.m_lblIForceBuf.Location = new Point(717, 617);
			this.m_lblIForceBuf.Margin = new Padding(4, 0, 4, 0);
			this.m_lblIForceBuf.Name = "m_lblIForceBuf";
			this.m_lblIForceBuf.Size = new Size(85, 17);
			this.m_lblIForceBuf.TabIndex = 28;
			this.m_lblIForceBuf.Text = "IFORCEBUF";
			this.m_lblIForceMaxData.AutoSize = true;
			this.m_lblIForceMaxData.Location = new Point(537, 651);
			this.m_lblIForceMaxData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblIForceMaxData.Name = "m_lblIForceMaxData";
			this.m_lblIForceMaxData.Size = new Size(28, 17);
			this.m_lblIForceMaxData.TabIndex = 29;
			this.m_lblIForceMaxData.Text = "0.0";
			this.m_lblVForceMaxData.AutoSize = true;
			this.m_lblVForceMaxData.Location = new Point(648, 651);
			this.m_lblVForceMaxData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblVForceMaxData.Name = "m_lblVForceMaxData";
			this.m_lblVForceMaxData.Size = new Size(28, 17);
			this.m_lblVForceMaxData.TabIndex = 30;
			this.m_lblVForceMaxData.Text = "0.0";
			this.m_lblIForceBufMaxData.AutoSize = true;
			this.m_lblIForceBufMaxData.Location = new Point(720, 651);
			this.m_lblIForceBufMaxData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblIForceBufMaxData.Name = "m_lblIForceBufMaxData";
			this.m_lblIForceBufMaxData.Size = new Size(28, 17);
			this.m_lblIForceBufMaxData.TabIndex = 31;
			this.m_lblIForceBufMaxData.Text = "0.0";
			this.m_lblIForceMinData.AutoSize = true;
			this.m_lblIForceMinData.Location = new Point(537, 687);
			this.m_lblIForceMinData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblIForceMinData.Name = "m_lblIForceMinData";
			this.m_lblIForceMinData.Size = new Size(28, 17);
			this.m_lblIForceMinData.TabIndex = 32;
			this.m_lblIForceMinData.Text = "0.0";
			this.m_lblVForceMinData.AutoSize = true;
			this.m_lblVForceMinData.Location = new Point(648, 687);
			this.m_lblVForceMinData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblVForceMinData.Name = "m_lblVForceMinData";
			this.m_lblVForceMinData.Size = new Size(28, 17);
			this.m_lblVForceMinData.TabIndex = 33;
			this.m_lblVForceMinData.Text = "0.0";
			this.m_lblIForceBufMinData.AutoSize = true;
			this.m_lblIForceBufMinData.Location = new Point(720, 687);
			this.m_lblIForceBufMinData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblIForceBufMinData.Name = "m_lblIForceBufMinData";
			this.m_lblIForceBufMinData.Size = new Size(28, 17);
			this.m_lblIForceBufMinData.TabIndex = 34;
			this.m_lblIForceBufMinData.Text = "0.0";
			this.m_lblIForceAvgData.AutoSize = true;
			this.m_lblIForceAvgData.Location = new Point(537, 729);
			this.m_lblIForceAvgData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblIForceAvgData.Name = "m_lblIForceAvgData";
			this.m_lblIForceAvgData.Size = new Size(28, 17);
			this.m_lblIForceAvgData.TabIndex = 35;
			this.m_lblIForceAvgData.Text = "0.0";
			this.m_lblVForceAvgData.AutoSize = true;
			this.m_lblVForceAvgData.Location = new Point(648, 729);
			this.m_lblVForceAvgData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblVForceAvgData.Name = "m_lblVForceAvgData";
			this.m_lblVForceAvgData.Size = new Size(28, 17);
			this.m_lblVForceAvgData.TabIndex = 36;
			this.m_lblVForceAvgData.Text = "0.0";
			this.m_lblIForceBufAvgData.AutoSize = true;
			this.m_lblIForceBufAvgData.Location = new Point(720, 729);
			this.m_lblIForceBufAvgData.Margin = new Padding(4, 0, 4, 0);
			this.m_lblIForceBufAvgData.Name = "m_lblIForceBufAvgData";
			this.m_lblIForceBufAvgData.Size = new Size(28, 17);
			this.m_lblIForceBufAvgData.TabIndex = 37;
			this.m_lblIForceBufAvgData.Text = "0.0";
			this.label15.AutoSize = true;
			this.label15.Location = new Point(13, 329);
			this.label15.Margin = new Padding(4, 0, 4, 0);
			this.label15.Name = "label15";
			this.label15.Size = new Size(181, 17);
			this.label15.TabIndex = 62;
			this.label15.Text = "AVG_FIRST_8_TEMP (°C)";
			this.m_lblAvgTempValue.AutoSize = true;
			this.m_lblAvgTempValue.Location = new Point(239, 329);
			this.m_lblAvgTempValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblAvgTempValue.Name = "m_lblAvgTempValue";
			this.m_lblAvgTempValue.Size = new Size(28, 17);
			this.m_lblAvgTempValue.TabIndex = 63;
			this.m_lblAvgTempValue.Text = "0.0";
			this.m_lblRadarDevice2AvgTempValue.AutoSize = true;
			this.m_lblRadarDevice2AvgTempValue.Location = new Point(309, 329);
			this.m_lblRadarDevice2AvgTempValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice2AvgTempValue.Name = "m_lblRadarDevice2AvgTempValue";
			this.m_lblRadarDevice2AvgTempValue.Size = new Size(28, 17);
			this.m_lblRadarDevice2AvgTempValue.TabIndex = 64;
			this.m_lblRadarDevice2AvgTempValue.Text = "0.0";
			this.m_lblRadarDevice3AvgTempValue.AutoSize = true;
			this.m_lblRadarDevice3AvgTempValue.Location = new Point(377, 329);
			this.m_lblRadarDevice3AvgTempValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice3AvgTempValue.Name = "m_lblRadarDevice3AvgTempValue";
			this.m_lblRadarDevice3AvgTempValue.Size = new Size(28, 17);
			this.m_lblRadarDevice3AvgTempValue.TabIndex = 65;
			this.m_lblRadarDevice3AvgTempValue.Text = "0.0";
			this.m_lblRadarDevice4AvgTempValue.AutoSize = true;
			this.m_lblRadarDevice4AvgTempValue.Location = new Point(443, 329);
			this.m_lblRadarDevice4AvgTempValue.Margin = new Padding(4, 0, 4, 0);
			this.m_lblRadarDevice4AvgTempValue.Name = "m_lblRadarDevice4AvgTempValue";
			this.m_lblRadarDevice4AvgTempValue.Size = new Size(28, 17);
			this.m_lblRadarDevice4AvgTempValue.TabIndex = 66;
			this.m_lblRadarDevice4AvgTempValue.Text = "0.0";
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.m_lblIForceBufAvgData);
			base.Controls.Add(this.m_lblVForceAvgData);
			base.Controls.Add(this.m_lblIForceAvgData);
			base.Controls.Add(this.m_lblIForceBufMinData);
			base.Controls.Add(this.m_lblVForceMinData);
			base.Controls.Add(this.m_lblIForceMinData);
			base.Controls.Add(this.m_lblIForceBufMaxData);
			base.Controls.Add(this.m_lblVForceMaxData);
			base.Controls.Add(this.m_lblIForceMaxData);
			base.Controls.Add(this.m_lblIForceBuf);
			base.Controls.Add(this.label29);
			base.Controls.Add(this.label28);
			base.Controls.Add(this.m_lblANATest4MaxData);
			base.Controls.Add(this.m_lblANATest4MinData);
			base.Controls.Add(this.m_lblANATest4MaxiData);
			base.Controls.Add(this.m_lblANATest3MaxData);
			base.Controls.Add(this.m_lblANATest3MinData);
			base.Controls.Add(this.m_lblANATest3MaxiData);
			base.Controls.Add(this.m_lblANATest2MaxData);
			base.Controls.Add(this.m_lblANATest2MinData);
			base.Controls.Add(this.m_lblANATest2MaxiData);
			base.Controls.Add(this.f000187);
			base.Controls.Add(this.m_lblANATest1MinData);
			base.Controls.Add(this.m_lblANATest1MaxiData);
			base.Controls.Add(this.label27);
			base.Controls.Add(this.label26);
			base.Controls.Add(this.label25);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.label23);
			base.Controls.Add(this.label22);
			base.Controls.Add(this.label19);
			base.Controls.Add(this.f000185);
			base.Controls.Add(this.m_grpDFEStaticReport);
			base.Controls.Add(this.m_grpRFCharReportDynamicCfg);
			base.Margin = new Padding(4, 4, 4, 4);
			base.Name = "ClibTab";
			base.Size = new Size(1840, 764);
			this.m_grpRFCharReportDynamicCfg.ResumeLayout(false);
			this.m_grpRFCharReportDynamicCfg.PerformLayout();
			this.m_grpDFEStaticReport.ResumeLayout(false);
			this.m_grpDFEStaticReport.PerformLayout();
			((ISupportInitialize)this.pictureBox3).EndInit();
			((ISupportInitialize)this.pictureBox2).EndInit();
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.f000185.ResumeLayout(false);
			this.f000185.PerformLayout();
			((ISupportInitialize)this.f000188).EndInit();
			((ISupportInitialize)this.f000189).EndInit();
			((ISupportInitialize)this.m_nudANATest4SettlingTimeCfg).EndInit();
			((ISupportInitialize)this.m_nudANATest3SettlingTimeCfg).EndInit();
			((ISupportInitialize)this.m_nudANATest2SettlingTimeCfg).EndInit();
			((ISupportInitialize)this.m_nudANATest1SettlingTimeCfg).EndInit();
			((ISupportInitialize)this.m_nudVSenseCfg).EndInit();
			((ISupportInitialize)this.m_nudIForceCfg).EndInit();
			((ISupportInitialize)this.m_nudANATest4Cfg).EndInit();
			((ISupportInitialize)this.m_nudANATest3Cfg).EndInit();
			((ISupportInitialize)this.m_nudANATest2Cfg).EndInit();
			((ISupportInitialize)this.m_nudANATest1Cfg).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		public RadarDevice1DFEStaticReportDataConfigParams m_RadarDevice1DFEStaticReportDataConfigParams;

		public RadarDevice2DFEStaticReportDataConfigParams m_RadarDevice2DFEStaticReportDataConfigParams;

		public RadarDevice3DFEStaticReportDataConfigParams m_RadarDevice3DFEStaticReportDataConfigParams;

		public RadarDevice4DFEStaticReportDataConfigParams m_RadarDevice4DFEStaticReportDataConfigParams;

		public RfGPADCMeasureForExtInputConfigParams m_RfGPADCMeasureForExtInputConfigParams;

		private IContainer components;

		private GroupBox m_grpRFCharReportDynamicCfg;

		private Label label1;

		private Label label5;

		private Label label6;

		private Label label3;

		private Label label4;

		private Label label2;

		private Label label7;

		private Label label8;

		private Label label9;

		private Label label10;

		private Label m_lblTx2TSValue;

		private Label m_lblRx4TSValue;

		private Label m_lblTx3TSValue;

		private Label m_lblTx1TSValue;

		private Label f00017d;

		private Label f00017e;

		private Label m_lblRx3TSValue;

		private Label m_lblRx2TSValue;

		private Label m_lblRx1TSValue;

		private Label m_lblTime;

		private Label label21;

		private Label label20;

		private Button m_btnRFDynamicCfgGet;

		private Label f00017f;

		private Label f000180;

		private Label m_lblRadarDevice3Tx3TSValue;

		private Label m_lblRadarDevice3Tx2TSValue;

		private Label m_lblRadarDevice3Tx1TSValue;

		private Label m_lblRadarDevice3Rx4TSValue;

		private Label m_lblRadarDevice3Rx3TSValue;

		private Label m_lblRadarDevice3Rx2TSValue;

		private Label m_lblRadarDevice3Rx1TSValue;

		private Label m_lblRadarDevice3Time;

		private Label f000181;

		private Label f000182;

		private Label m_lblRadarDevice4Tx3TSValue;

		private Label m_lblRadarDevice4Tx2TSValue;

		private Label m_lblRadarDevice4Tx1TSValue;

		private Label m_lblRadarDevice4Rx4TSValue;

		private Label m_lblRadarDevice4Rx3TSValue;

		private Label m_lblRadarDevice4Rx2TSValue;

		private Label m_lblRadarDevice4Rx1TSValue;

		private Label m_lblRadarDevice4Time;

		private Label f000183;

		private Label f000184;

		private Label m_lblRadarDevice2Tx3TSValue;

		private Label m_lblRadarDevice2Tx2TSValue;

		private Label m_lblRadarDevice2Tx1TSValue;

		private Label m_lblRadarDevice2Rx4TSValue;

		private Label m_lblRadarDevice2Rx3TSValue;

		private Label m_lblRadarDevice2Rx2TSValue;

		private Label m_lblRadarDevice2Rx1TSValue;

		private Label m_lblRadarDevice2Time;

		private GroupBox m_grpDFEStaticReport;

		private Label m_lblProfile0Idc;

		private Label label67;

		private Label label68;

		private Label label66;

		private Label label65;

		private Label label75;

		private Label label73;

		private Label label74;

		private Label label71;

		private Label m_lblProfile0RX1;

		private Label label70;

		private PictureBox pictureBox1;

		private PictureBox pictureBox3;

		private PictureBox pictureBox2;

		private Label label92;

		private Label label91;

		private Label label86;

		private Label label87;

		private Label label88;

		private Label label89;

		private Label label90;

		private Label label84;

		private Label label85;

		private Label label82;

		private Label label83;

		private Label label80;

		private Label label81;

		private Label label78;

		private Label label79;

		private Label label77;

		private Label label76;

		private Button m_btnDFEStaticReportGet;

		private Label m_lblProfile3IQcrosscorrRX4;

		private Label m_lblProfile3QpwrRX4;

		private Label m_lblProfile3IpwrRX4;

		private Label m_lblProfile3QdcRX4;

		private Label m_lblProfile3IdcRX4;

		private Label m_lblProfile3IQcrosscorrRX3;

		private Label m_lblProfile3QpwrRX3;

		private Label m_lblProfile3IpwrRX3;

		private Label m_lblProfile3QdcRX3;

		private Label m_lblProfile3IdcRX3;

		private Label m_lblProfile3IQcrosscorrRX2;

		private Label m_lblProfile3QpwrRX2;

		private Label m_lblProfile3IpwrRX2;

		private Label m_lblProfile3QdcRX2;

		private Label m_lblProfile3IdcRX2;

		private Label m_lblProfile3IQcrosscorrRX1;

		private Label m_lblProfile3QpwrRX1;

		private Label m_lblProfile3IpwrRX1;

		private Label m_lblProfile3QdcRX1;

		private Label m_lblProfile3IdcRX1;

		private Label m_lblProfile2IQcrosscorrRX4;

		private Label m_lblProfile2QpwrRX4;

		private Label m_lblProfile2IpwrRX4;

		private Label m_lblProfile2QdcRX4;

		private Label m_lblProfile2IdcRX4;

		private Label m_lblProfile2IQcrosscorrRX3;

		private Label m_lblProfile2QpwrRX3;

		private Label m_lblProfile2IpwrRX3;

		private Label m_lblProfile2QdcRX3;

		private Label m_lblProfile2IdcRX3;

		private Label m_lblProfile2IQcrosscorrRX2;

		private Label m_lblProfile2QpwrRX2;

		private Label m_lblProfile2IpwrRX2;

		private Label m_lblProfile2QdcRX2;

		private Label m_lblProfile2IdcRX2;

		private Label m_lblProfile2IQcrosscorrRX1;

		private Label m_lblProfile2QpwrRX1;

		private Label m_lblProfile2IpwrRX1;

		private Label m_lblProfile2QdcRX1;

		private Label m_lblProfile2IdcRX1;

		private Label m_lblProfile1IQcrosscorrRX4;

		private Label m_lblProfile1QpwrRX4;

		private Label m_lblProfile1IpwrRX4;

		private Label m_lblProfile1QdcRX4;

		private Label m_lblProfile1IdcRX4;

		private Label m_lblProfile1IQcrosscorrRX3;

		private Label m_lblProfile1QpwrRX3;

		private Label m_lblProfile1IpwrRX3;

		private Label m_lblProfile1QdcRX3;

		private Label m_lblProfile1IdcRX3;

		private Label m_lblProfile1IQcrosscorrRX2;

		private Label m_lblProfile1QpwrRX2;

		private Label m_lblProfile1IpwrRX2;

		private Label m_lblProfile1QdcRX2;

		private Label m_lblProfile1IdcRX2;

		private Label m_lblProfile1IQcrosscorrRX1;

		private Label m_lblProfile1QpwrRX1;

		private Label m_lblProfile1IpwrRX1;

		private Label m_lblProfile1QdcRX1;

		private Label m_lblProfile1IdcRX1;

		private Label m_lblProfile0IQcrosscorrRX4;

		private Label m_lblProfile0QpwrRX4;

		private Label m_lblProfile0IpwrRX4;

		private Label m_lblProfile0QdcRX4;

		private Label m_lblProfile0IdcRX4;

		private Label m_lblProfile0IQcrosscorrRX3;

		private Label m_lblProfile0QpwrRX3;

		private Label m_lblProfile0IpwrRX3;

		private Label m_lblProfile0QdcRX3;

		private Label m_lblProfile0IdcRX3;

		private Label m_lblProfile0IQcrosscorrRX2;

		private Label m_lblProfile0QpwrRX2;

		private Label m_lblProfile0IpwrRX2;

		private Label m_lblProfile0QdcRX2;

		private Label m_lblProfile0IdcRX2;

		private Label m_lblProfile0IQcrosscorrRX1;

		private Label m_lblProfile0QpwrRX1;

		private Label m_lblProfile0IpwrRX1;

		private Label m_lblProfile0QdcRX1;

		private Label m_lblProfile0IdcRX1;

		private GroupBox f000185;

		private CheckBox m_chbVSense;

		private CheckBox m_chbIForce;

		private CheckBox m_chbANATest4;

		private CheckBox m_chbANATest3;

		private CheckBox m_chbANATest2;

		private CheckBox m_chbANATest1;

		private Label label14;

		private Label label12;

		private Label label11;

		private NumericUpDown m_nudVSenseCfg;

		private NumericUpDown m_nudIForceCfg;

		private NumericUpDown m_nudANATest4Cfg;

		private NumericUpDown m_nudANATest3Cfg;

		private NumericUpDown m_nudANATest2Cfg;

		private NumericUpDown m_nudANATest1Cfg;

		private Label label19;

		private Label label22;

		private Label label23;

		private Label label24;

		private Label label25;

		private Label label26;

		private Label label27;

		private Button f000186;

		private Label m_lblANATest1MaxiData;

		private Label m_lblANATest1MinData;

		private Label f000187;

		private Label m_lblANATest2MaxData;

		private Label m_lblANATest2MinData;

		private Label m_lblANATest2MaxiData;

		private Label m_lblANATest3MaxData;

		private Label m_lblANATest3MinData;

		private Label m_lblANATest3MaxiData;

		private Label m_lblANATest4MaxData;

		private Label m_lblANATest4MinData;

		private Label m_lblANATest4MaxiData;

		private Label label28;

		private Label label29;

		private Label m_lblIForceBuf;

		private Label m_lblIForceMaxData;

		private Label m_lblVForceMaxData;

		private Label m_lblIForceBufMaxData;

		private Label m_lblIForceMinData;

		private Label m_lblVForceMinData;

		private Label m_lblIForceBufMinData;

		private Label m_lblIForceAvgData;

		private Label m_lblVForceAvgData;

		private Label m_lblIForceBufAvgData;

		private CheckBox m_chbSigBufEnaANAMux;

		private CheckBox m_chbSigBufEnaANATest4;

		private CheckBox m_chbSigBufEnaANATest3;

		private CheckBox m_chbSigBufEnaANATest2;

		private CheckBox m_chbSigBufEnaANATest1;

		private Label label18;

		private Label label35;

		private Label label34;

		private Label label33;

		private Label label32;

		private Label label31;

		private Label label30;

		private NumericUpDown f000188;

		private NumericUpDown f000189;

		private NumericUpDown m_nudANATest4SettlingTimeCfg;

		private NumericUpDown m_nudANATest3SettlingTimeCfg;

		private NumericUpDown m_nudANATest2SettlingTimeCfg;

		private NumericUpDown m_nudANATest1SettlingTimeCfg;

		private Label f00018a;

		private Label f00018b;

		private Label f00018c;

		private Label f00018d;

		private Label label13;

		private Label m_lblRadarDevice4AvgTempValue;

		private Label m_lblRadarDevice3AvgTempValue;

		private Label m_lblRadarDevice2AvgTempValue;

		private Label m_lblAvgTempValue;

		private Label label15;
	}
}
