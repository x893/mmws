using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class DataConfigTab : UserControl
	{
		public DataConfigTab()
		{
			InitializeComponent();
			PostInitialization();
			m_MainForm = m_GuiManager.MainTsForm;
			m_DataConfigParams = m_GuiManager.TsParams.DataConfigParams;
			m_TestPatternGenConfigParams = m_GuiManager.TsParams.TestPatternGenConfigParams;
			m_GroupCS2LaneConfig.Visible = true;
			m_chkTestPatternGenCtl.Minimum = 0m;
			m_chkTestPatternGenCtl.Maximum = 1m;
			m_nudDataPathCQ0TransSize.Value = 132m;
			m_nudDataPathCQ1TransSize.Value = 132m;
			m_nudDataPathCQ2TransSize.Value = 72m;
			m_cboDataPathCQConfig.SelectedIndex = 2;
		}

		public bool UpdateDataConfig(RootObject jobject, int p1)
		{
			bool result;
			try
			{
				if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.isConfigured == 0)
				{
					string msg = string.Format("Missing Device Data Path Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg);
				}
				else
				{
					int num = Convert.ToInt32(jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.p000016, 16);
					int num2 = Convert.ToInt32(jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.p000017, 16);
					int selectedIndex = 0;
					if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.p000018 == 1)
					{
						if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.dataRate_Mbps == 900)
							selectedIndex = 0;
						else if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.dataRate_Mbps == 600)
							selectedIndex = 1;
						else if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.dataRate_Mbps == 450)
							selectedIndex = 2;
						else if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.dataRate_Mbps == 400)
							selectedIndex = 3;
						else if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.dataRate_Mbps == 300)
							selectedIndex = 4;
						else if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.dataRate_Mbps == 225)
							selectedIndex = 5;
						else if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.dataRate_Mbps == 150)
							selectedIndex = 6;
					}
					else if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.p000018 == 0)
					{
						if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.dataRate_Mbps == 450)
						{
							selectedIndex = 0;
						}
						else if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.dataRate_Mbps == 300)
						{
							selectedIndex = 1;
						}
						else if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.dataRate_Mbps == 150)
						{
							selectedIndex = 2;
						}
					}
					if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.intfSel == 0)
					{
						m_cboDataPathCfgPath.SelectedIndex = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.intfSel;
						m_cboDataPathCQConfig.SelectedIndex = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cqConfig;
						m_nudDataPathCQ0TransSize.Value = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cq0TransSize;
						m_nudDataPathCQ1TransSize.Value = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cq1TransSize;
						m_nudDataPathCQ2TransSize.Value = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cq2TransSize;
						if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.isConfigured == 0)
						{
							string msg2 = string.Format("Missing Device Data path Clock Configuration for Device {0}. Skipping..", p1);
							GlobalRef.LuaWrapper.PrintWarning(msg2);
						}
						else
						{
							m_cboLvdsLaneClkCfg.SelectedIndex = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.p000018;
							m_cboLvdsDataRate.SelectedIndex = selectedIndex;
						}
						if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevCsi2Cfg_t.isConfigured == 0)
						{
							string msg3 = string.Format("Missing CSI2 Configuration for Device {0}. Skipping..", p1);
							GlobalRef.LuaWrapper.PrintWarning(msg3);
						}
						else
						{
							int num3 = Convert.ToInt32(jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevCsi2Cfg_t.lanePosPolSel, 16);
							m_nudCSI2Lane0Pos.Value = (num3 & 7);
							m_chkCSI2Lane0Pol.Checked = ((num3 & 8) == 1);
							m_nudCSI2Lane1Pos.Value = (num3 & 112) >> 4;
							m_chkCSI2Lane1Pol.Checked = ((num3 & 128) >> 4 == 1);
							m_nudCSI2Lane2Pos.Value = (num3 & 1792) >> 8;
							m_chkCSI2Lane2Pol.Checked = ((num3 & 2048) >> 8 == 1);
							m_nudCSI2Lane3Pos.Value = (num3 & 28672) >> 12;
							m_chkCSI2Lane3Pol.Checked = ((num3 & 32768) >> 12 == 1);
							m_nudCSI2ClockPos.Value = (num3 & 458752) >> 16;
							m_chkCSI2ClockPol.Checked = ((num3 & 524288) >> 16 == 1);
						}
						if ((num & 63) == 1)
						{
							if ((num & 64) == 0 && (num & 128) == 0)
							{
								m_cboDataCfgFmt0.SelectedIndex = 0;
								m_nudPkt0VChannelNo.Value = 0m;
							}
							else if ((num >> 6 & 1) == 1 && (num >> 7 & 1) == 0)
							{
								m_cboDataCfgFmt0.SelectedIndex = 0;
								m_nudPkt0VChannelNo.Value = 1m;
							}
							else if ((num >> 6 & 1) == 0 && (num >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt0.SelectedIndex = 0;
								m_nudPkt0VChannelNo.Value = 2m;
							}
							else if ((num >> 6 & 1) == 1 && (num >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt0.SelectedIndex = 0;
								m_nudPkt0VChannelNo.Value = 3m;
							}
						}
						else if ((num & 63) == 6)
						{
							if ((num & 64) == 0 && (num & 128) == 0)
							{
								m_cboDataCfgFmt0.SelectedIndex = 1;
								m_nudPkt0VChannelNo.Value = 0m;
							}
							else if ((num >> 6 & 1) == 1 && (num >> 7 & 1) == 0)
							{
								m_cboDataCfgFmt0.SelectedIndex = 1;
								m_nudPkt0VChannelNo.Value = 1m;
							}
							else if ((num >> 6 & 1) == 0 && (num >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt0.SelectedIndex = 1;
								m_nudPkt0VChannelNo.Value = 2m;
							}
							else if ((num >> 6 & 1) == 1 && (num >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt0.SelectedIndex = 1;
								m_nudPkt0VChannelNo.Value = 3m;
							}
						}
						else if ((num & 63) == 9)
						{
							if ((num & 64) == 0 && (num & 128) == 0)
							{
								m_cboDataCfgFmt0.SelectedIndex = 2;
								m_nudPkt0VChannelNo.Value = 0m;
							}
							else if ((num >> 6 & 1) == 1 && (num >> 7 & 1) == 0)
							{
								m_cboDataCfgFmt0.SelectedIndex = 2;
								m_nudPkt0VChannelNo.Value = 1m;
							}
							else if ((num >> 6 & 1) == 0 && (num >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt0.SelectedIndex = 2;
								m_nudPkt0VChannelNo.Value = 2m;
							}
							else if ((num >> 6 & 1) == 1 && (num >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt0.SelectedIndex = 2;
								m_nudPkt0VChannelNo.Value = 3m;
							}
						}
						else if ((num & 63) == 54)
						{
							if ((num & 64) == 0 && (num & 128) == 0)
							{
								m_cboDataCfgFmt0.SelectedIndex = 3;
								m_nudPkt0VChannelNo.Value = 0m;
							}
							else if ((num >> 6 & 1) == 1 && (num >> 7 & 1) == 0)
							{
								m_cboDataCfgFmt0.SelectedIndex = 3;
								m_nudPkt0VChannelNo.Value = 1m;
							}
							else if ((num >> 6 & 1) == 0 && (num >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt0.SelectedIndex = 3;
								m_nudPkt0VChannelNo.Value = 2m;
							}
							else if ((num >> 6 & 1) == 1 && (num >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt0.SelectedIndex = 3;
								m_nudPkt0VChannelNo.Value = 3m;
							}
						}
						if ((num2 & 63) == 0)
						{
							if ((num2 & 64) == 0 && (num2 & 128) == 0)
							{
								m_cboDataCfgFmt1.SelectedIndex = 0;
								m_nudPkt1VChannelNo.Value = 0m;
							}
							else if ((num2 >> 6 & 1) == 1 && (num2 >> 7 & 1) == 0)
							{
								m_cboDataCfgFmt1.SelectedIndex = 0;
								m_nudPkt1VChannelNo.Value = 1m;
							}
							else if ((num2 >> 6 & 1) == 0 && (num2 >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt1.SelectedIndex = 0;
								m_nudPkt1VChannelNo.Value = 2m;
							}
							else if ((num2 >> 6 & 1) == 1 && (num2 >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt1.SelectedIndex = 0;
								m_nudPkt1VChannelNo.Value = 3m;
							}
						}
						else if ((num2 & 63) == 14)
						{
							if ((num2 & 64) == 0 && (num2 & 128) == 0)
							{
								m_cboDataCfgFmt1.SelectedIndex = 1;
								m_nudPkt1VChannelNo.Value = 0m;
							}
							else if ((num2 >> 6 & 1) == 1 && (num2 >> 7 & 1) == 0)
							{
								m_cboDataCfgFmt1.SelectedIndex = 1;
								m_nudPkt1VChannelNo.Value = 1m;
							}
							else if ((num2 >> 6 & 1) == 0 && (num2 >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt1.SelectedIndex = 1;
								m_nudPkt1VChannelNo.Value = 2m;
							}
							else if ((num2 >> 6 & 1) == 1 && (num2 >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt1.SelectedIndex = 1;
								m_nudPkt1VChannelNo.Value = 3m;
							}
						}
						else if ((num2 & 63) == 11)
						{
							if ((num2 & 64) == 0 && (num2 & 128) == 0)
							{
								m_cboDataCfgFmt1.SelectedIndex = 2;
								m_nudPkt1VChannelNo.Value = 0m;
							}
							else if ((num2 >> 6 & 1) == 1 && (num2 >> 7 & 1) == 0)
							{
								m_cboDataCfgFmt1.SelectedIndex = 2;
								m_nudPkt1VChannelNo.Value = 1m;
							}
							else if ((num2 >> 6 & 1) == 0 && (num2 >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt1.SelectedIndex = 2;
								m_nudPkt1VChannelNo.Value = 2m;
							}
							else if ((num2 >> 6 & 1) == 1 && (num2 >> 7 & 1) == 1)
							{
								m_cboDataCfgFmt1.SelectedIndex = 2;
								m_nudPkt1VChannelNo.Value = 3m;
							}
						}
					}
					else if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.intfSel == 1)
					{
						m_cboDataPathCfgPath.SelectedIndex = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.intfSel;
						m_cboDataPathCQConfig.SelectedIndex = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cqConfig;
						m_nudDataPathCQ0TransSize.Value = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cq0TransSize;
						m_nudDataPathCQ1TransSize.Value = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cq1TransSize;
						m_nudDataPathCQ2TransSize.Value = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cq2TransSize;
						if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.isConfigured == 0)
						{
							string msg4 = string.Format("Missing Device Data Path Clock Configuration for Device {0}. Skipping..", p1);
							GlobalRef.LuaWrapper.PrintWarning(msg4);
						}
						else
						{
							m_cboLvdsLaneClkCfg.SelectedIndex = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathClkCfg_t.p000018;
							m_cboLvdsDataRate.SelectedIndex = selectedIndex;
						}
						if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevLvdsLaneCfg_t.isConfigured == 0)
						{
							string msg5 = string.Format("Missing LVDS lane Configuration for Device {0}. Skipping..", p1);
							GlobalRef.LuaWrapper.PrintWarning(msg5);
						}
						else
						{
							m_cboLaneEnFormat.SelectedIndex = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevLvdsLaneCfg_t.laneFmtMap;
						}
						if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevLaneEnable_t.isConfigured == 0)
						{
							string msg6 = string.Format("Missing Device Lane Enable Configuration for Device {0}. Skipping..", p1);
							GlobalRef.LuaWrapper.PrintWarning(msg6);
						}
						else
						{
							f000244.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevLaneEnable_t.laneEn, 16) & 1) == 1);
							f000243.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevLaneEnable_t.laneEn, 16) & 2) >> 1 == 1);
							f000242.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevLaneEnable_t.laneEn, 16) & 4) >> 2 == 1);
							f000241.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevLaneEnable_t.laneEn, 16) & 8) >> 3 == 1);
						}
						if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevLvdsLaneCfg_t.isConfigured == 0)
						{
							string msg7 = string.Format("Missing Device LVDS Lane Configuration for Device {0}. Skipping..", p1);
							GlobalRef.LuaWrapper.PrintWarning(msg7);
						}
						else
						{
							f000246.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevLvdsLaneCfg_t.laneParamCfg, 16) & 1) == 1);
							m_chbLvdsPacketEndPulse.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevLvdsLaneCfg_t.laneParamCfg, 16) & 2) >> 1 == 1);
							f000245.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevLvdsLaneCfg_t.laneParamCfg, 16) & 4) >> 2 == 1);
						}
						if ((num & 63) == 1)
						{
							m_cboDataCfgFmt0.SelectedIndex = 0;
						}
						else if ((num & 63) == 6)
						{
							m_cboDataCfgFmt0.SelectedIndex = 1;
						}
						else if ((num & 63) == 9)
						{
							m_cboDataCfgFmt0.SelectedIndex = 2;
						}
						else if ((num & 63) == 54)
						{
							m_cboDataCfgFmt0.SelectedIndex = 3;
						}
						if ((num2 & 63) == 0)
						{
							m_cboDataCfgFmt1.SelectedIndex = 0;
						}
						else if ((num2 & 63) == 14)
						{
							m_cboDataCfgFmt1.SelectedIndex = 1;
						}
						else if ((num2 & 63) == 11)
						{
							m_cboDataCfgFmt1.SelectedIndex = 2;
						}
					}
					else if (jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.intfSel == 2)
					{
						m_cboDataPathCfgPath.SelectedIndex = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.intfSel;
						m_cboDataPathCQConfig.SelectedIndex = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cqConfig;
						m_nudDataPathCQ0TransSize.Value = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cq0TransSize;
						m_nudDataPathCQ1TransSize.Value = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cq1TransSize;
						m_nudDataPathCQ2TransSize.Value = jobject.mmWaveDevices[p1].rawDataCaptureConfig.rlDevDataPathCfg_t.cq2TransSize;
						if (num == 1)
						{
							m_cboDataCfgFmt0.SelectedIndex = 0;
						}
						else
						{
							m_cboDataCfgFmt0.SelectedIndex = 0;
						}
						m_cboDataCfgFmt1.SelectedIndex = 0;
					}
				}
				if (jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.isConfigured == 0)
				{
					string msg8 = string.Format("Missing Test Pattern Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg8);
				}
				else
				{
					if (jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatGenCtrl == 1)
					{
						m_chkTestPatternGenCtl.Value = 1m;
					}
					else
					{
						m_chkTestPatternGenCtl.Value = 0m;
					}
					m_nudTestPatternGenTiming.Value = jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatGenTime;
					m_nudTestPatternPktSize.Value = jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatrnPktSize;
					m_nudNumTestPatternPkts.Value = jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.numTestPtrnPkts;
					m_nudTestPatternRx0ICFG.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx0Icfg, 16) & 255);
					m_nudTestPatternRx0ICFG0.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx0Icfg, 16) & 65280) >> 8;
					m_nudTestPatternRx1ICFG.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx1Icfg, 16) & 255);
					m_nudTestPatternRx1ICFG1.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx1Icfg, 16) & 65280) >> 8;
					m_nudTestPatternRx2ICFG.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx2Icfg, 16) & 255);
					m_nudTestPatternRx2ICFG2.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx2Icfg, 16) & 65280) >> 8;
					m_nudTestPatternRx3ICFG.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx3Icfg, 16) & 255);
					m_nudTestPatternRx3ICFG3.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx3Icfg, 16) & 65280) >> 8;
					m_nudTestPatternRx0QCFG.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx0Qcfg, 16) & 255);
					m_nudTestPatternRx0QCFG0.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx0Qcfg, 16) & 65280) >> 8;
					m_nudTestPatternRx1QCFG.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx1Qcfg, 16) & 255);
					m_nudTestPatternRx1QCFG1.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx1Qcfg, 16) & 65280) >> 8;
					m_nudTestPatternRx2QCFG.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx2Qcfg, 16) & 255);
					m_nudTestPatternRx2QCFG2.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx2Qcfg, 16) & 65280) >> 8;
					m_nudTestPatternRx3QCFG.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx3Qcfg, 16) & 255);
					m_nudTestPatternRx3QCFG3.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rltestPattern_t.testPatRx3Qcfg, 16) & 65280) >> 8;
				}
				result = true;
			}
			catch
			{
				string msg9 = string.Format("Data Config Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg9);
				result = false;
			}
			return result;
		}

		public bool UpdateDataConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateDataConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				if (m_cboDataPathCfgPath.SelectedIndex == 1)
				{
					m_nudPkt0VChannelNo.Enabled = false;
					m_nudPkt1VChannelNo.Enabled = false;
				}
				else
				{
					m_nudPkt0VChannelNo.Enabled = true;
					m_nudPkt1VChannelNo.Enabled = true;
				}
				if (m_cboDataPathCfgPath.SelectedIndex == 0)
				{
					m_DataConfigParams.DataPath = (char)m_cboDataPathCfgPath.SelectedIndex;
					m_DataConfigParams.f000326 = '\u0002';
					m_DataConfigParams.CQConfig = (char)m_cboDataPathCQConfig.SelectedIndex;
					m_DataConfigParams.CQ0TransSize = (char)m_nudDataPathCQ0TransSize.Value;
					m_DataConfigParams.CQ1TransSize = (char)m_nudDataPathCQ1TransSize.Value;
					m_DataConfigParams.CQ2TransSize = (char)m_nudDataPathCQ2TransSize.Value;
					if (m_cboDataCfgFmt0.SelectedIndex == 0)
					{
						if (m_nudPkt0VChannelNo.Value == 0m)
						{
							m_DataConfigParams.DataFmt0 = '\u0001';
						}
						else if (m_nudPkt0VChannelNo.Value == 1m)
						{
							m_DataConfigParams.DataFmt0 = 'A';
						}
						else if (m_nudPkt0VChannelNo.Value == 2m)
						{
							m_DataConfigParams.DataFmt0 = '\u0081';
						}
						else if (m_nudPkt0VChannelNo.Value == 3m)
						{
							m_DataConfigParams.DataFmt0 = 'Á';
						}
					}
					else if (m_cboDataCfgFmt0.SelectedIndex == 1)
					{
						if (m_nudPkt0VChannelNo.Value == 0m)
						{
							m_DataConfigParams.DataFmt0 = '\u0006';
						}
						else if (m_nudPkt0VChannelNo.Value == 1m)
						{
							m_DataConfigParams.DataFmt0 = 'F';
						}
						else if (m_nudPkt0VChannelNo.Value == 2m)
						{
							m_DataConfigParams.DataFmt0 = '\u0086';
						}
						else if (m_nudPkt0VChannelNo.Value == 3m)
						{
							m_DataConfigParams.DataFmt0 = 'Æ';
						}
					}
					else if (m_cboDataCfgFmt0.SelectedIndex == 2)
					{
						if (m_nudPkt0VChannelNo.Value == 0m)
						{
							m_DataConfigParams.DataFmt0 = '\t';
						}
						else if (m_nudPkt0VChannelNo.Value == 1m)
						{
							m_DataConfigParams.DataFmt0 = 'I';
						}
						else if (m_nudPkt0VChannelNo.Value == 2m)
						{
							m_DataConfigParams.DataFmt0 = '\u0089';
						}
						else if (m_nudPkt0VChannelNo.Value == 3m)
						{
							m_DataConfigParams.DataFmt0 = 'É';
						}
					}
					else if (m_cboDataCfgFmt0.SelectedIndex == 3)
					{
						if (m_nudPkt0VChannelNo.Value == 0m)
						{
							m_DataConfigParams.DataFmt0 = '6';
						}
						else if (m_nudPkt0VChannelNo.Value == 1m)
						{
							m_DataConfigParams.DataFmt0 = 'v';
						}
						else if (m_nudPkt0VChannelNo.Value == 2m)
						{
							m_DataConfigParams.DataFmt0 = '¶';
						}
						else if (m_nudPkt0VChannelNo.Value == 3m)
						{
							m_DataConfigParams.DataFmt0 = 'ö';
						}
					}
					if (m_cboDataCfgFmt1.SelectedIndex == 0)
					{
						if (m_nudPkt1VChannelNo.Value == 0m)
						{
							m_DataConfigParams.DataFmt1 = '\0';
						}
						else if (m_nudPkt1VChannelNo.Value == 1m)
						{
							m_DataConfigParams.DataFmt1 = '@';
						}
						else if (m_nudPkt1VChannelNo.Value == 2m)
						{
							m_DataConfigParams.DataFmt1 = '\u0080';
						}
						else if (m_nudPkt1VChannelNo.Value == 3m)
						{
							m_DataConfigParams.DataFmt1 = 'À';
						}
					}
					else if (m_cboDataCfgFmt1.SelectedIndex == 1)
					{
						if (m_nudPkt1VChannelNo.Value == 0m)
						{
							m_DataConfigParams.DataFmt1 = '\u000e';
						}
						else if (m_nudPkt1VChannelNo.Value == 1m)
						{
							m_DataConfigParams.DataFmt1 = 'N';
						}
						else if (m_nudPkt1VChannelNo.Value == 2m)
						{
							m_DataConfigParams.DataFmt1 = '\u008e';
						}
						else if (m_nudPkt1VChannelNo.Value == 3m)
						{
							m_DataConfigParams.DataFmt1 = 'Î';
						}
					}
					else if (m_cboDataCfgFmt1.SelectedIndex == 2)
					{
						if (m_nudPkt1VChannelNo.Value == 0m)
						{
							m_DataConfigParams.DataFmt1 = '\v';
						}
						else if (m_nudPkt1VChannelNo.Value == 1m)
						{
							m_DataConfigParams.DataFmt1 = 'K';
						}
						else if (m_nudPkt1VChannelNo.Value == 2m)
						{
							m_DataConfigParams.DataFmt1 = '\u008b';
						}
						else if (m_nudPkt1VChannelNo.Value == 3m)
						{
							m_DataConfigParams.DataFmt1 = 'Ë';
						}
					}
				}
				else if (m_cboDataPathCfgPath.SelectedIndex == 1)
				{
					m_DataConfigParams.DataPath = (char)m_cboDataPathCfgPath.SelectedIndex;
					m_DataConfigParams.f000326 = '\u0002';
					m_DataConfigParams.CQConfig = (char)m_cboDataPathCQConfig.SelectedIndex;
					m_DataConfigParams.CQ0TransSize = (char)m_nudDataPathCQ0TransSize.Value;
					m_DataConfigParams.CQ1TransSize = (char)m_nudDataPathCQ1TransSize.Value;
					m_DataConfigParams.CQ2TransSize = (char)m_nudDataPathCQ2TransSize.Value;
					if (m_cboDataCfgFmt0.SelectedIndex == 0)
					{
						m_DataConfigParams.DataFmt0 = '\u0001';
					}
					else if (m_cboDataCfgFmt0.SelectedIndex == 1)
					{
						m_DataConfigParams.DataFmt0 = '\u0006';
					}
					else if (m_cboDataCfgFmt0.SelectedIndex == 2)
					{
						m_DataConfigParams.DataFmt0 = '\t';
					}
					else if (m_cboDataCfgFmt0.SelectedIndex == 3)
					{
						m_DataConfigParams.DataFmt0 = '6';
					}
					if (m_cboDataCfgFmt1.SelectedIndex == 0)
					{
						m_DataConfigParams.DataFmt1 = '\0';
					}
					else if (m_cboDataCfgFmt1.SelectedIndex == 1)
					{
						m_DataConfigParams.DataFmt1 = '\u000e';
					}
					else if (m_cboDataCfgFmt1.SelectedIndex == 2)
					{
						m_DataConfigParams.DataFmt1 = '\v';
					}
				}
				else if (m_cboDataPathCfgPath.SelectedIndex == 2)
				{
					if (GlobalRef.g_AR16xxDevice || GlobalRef.g_AR14xxDevice || GlobalRef.g_AR1843Device || GlobalRef.g_AR6843Device)
					{
						MessageBox.Show(string.Format("ERROR: SPI interface data path not supported in 16xx, 18xx, 14xx and 68xx!", new object[0]));
						return false;
					}
					m_DataConfigParams.DataPath = (char)m_cboDataPathCfgPath.SelectedIndex;
					m_DataConfigParams.CQConfig = (char)m_cboDataPathCQConfig.SelectedIndex;
					m_DataConfigParams.CQ0TransSize = (char)m_nudDataPathCQ0TransSize.Value;
					m_DataConfigParams.CQ1TransSize = (char)m_nudDataPathCQ1TransSize.Value;
					m_DataConfigParams.CQ2TransSize = (char)m_nudDataPathCQ2TransSize.Value;
					if (m_cboDataCfgFmt0.SelectedIndex == 0)
					{
						m_DataConfigParams.DataFmt0 = '\u0001';
					}
					else
					{
						m_DataConfigParams.DataFmt0 = '\0';
					}
					m_DataConfigParams.DataFmt1 = '\0';
				}
				m_DataConfigParams.laneClk = (char)m_cboLvdsLaneClkCfg.SelectedIndex;
				m_DataConfigParams.DataRate = (char)m_cboLvdsDataRate.SelectedIndex;
				m_DataConfigParams.f000327 = (ushort)m_cboLaneEnFormat.SelectedIndex;
				m_DataConfigParams.lane1En = (ushort)(f000244.Checked ? 1 : 0);
				m_DataConfigParams.lane2En = (ushort)(f000243.Checked ? 1 : 0);
				m_DataConfigParams.lane3En = (ushort)(f000242.Checked ? 1 : 0);
				m_DataConfigParams.lane4En = (ushort)(f000241.Checked ? 1 : 0);
				m_DataConfigParams.msbFirst = (ushort)(f000246.Checked ? 1 : 0);
				m_DataConfigParams.endPulse = (ushort)(m_chbLvdsPacketEndPulse.Checked ? 1 : 0);
				m_DataConfigParams.crc = (ushort)(f000245.Checked ? 1 : 0);
				m_DataConfigParams.CSI2DataLane0Pos = (ushort)m_nudCSI2Lane0Pos.Value;
				m_DataConfigParams.CSI2DataLane0Pol = (ushort)(m_chkCSI2Lane0Pol.Checked ? 1 : 0);
				m_DataConfigParams.CSI2DataLane1Pos = (ushort)m_nudCSI2Lane1Pos.Value;
				m_DataConfigParams.CSI2DataLane1Pol = (ushort)(m_chkCSI2Lane1Pol.Checked ? 1 : 0);
				m_DataConfigParams.CSI2DataLane2Pos = (ushort)m_nudCSI2Lane2Pos.Value;
				m_DataConfigParams.CSI2DataLane2Pol = (ushort)(m_chkCSI2Lane2Pol.Checked ? 1 : 0);
				m_DataConfigParams.CSI2DataLane3Pos = (ushort)m_nudCSI2Lane3Pos.Value;
				m_DataConfigParams.CSI2DataLane3Pol =(ushort) (m_chkCSI2Lane3Pol.Checked ? 1 : 0);
				m_DataConfigParams.CSI2ClockPos = (ushort)m_nudCSI2ClockPos.Value;
				m_DataConfigParams.CSI2ClockPol = (ushort)(m_chkCSI2ClockPol.Checked ? 1 : 0);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateCSI2LaneConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateCSI2LaneConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_nudCSI2Lane0Pos.Value = m_DataConfigParams.CSI2DataLane0Pos;
				m_chkCSI2Lane0Pol.Checked = (m_DataConfigParams.CSI2DataLane0Pol == 1);
				m_nudCSI2Lane1Pos.Value = m_DataConfigParams.CSI2DataLane1Pos;
				m_chkCSI2Lane1Pol.Checked = (m_DataConfigParams.CSI2DataLane1Pol == 1);
				m_nudCSI2Lane2Pos.Value = m_DataConfigParams.CSI2DataLane2Pos;
				m_chkCSI2Lane2Pol.Checked = (m_DataConfigParams.CSI2DataLane2Pol == 1);
				m_nudCSI2Lane3Pos.Value = m_DataConfigParams.CSI2DataLane3Pos;
				m_chkCSI2Lane3Pol.Checked = (m_DataConfigParams.CSI2DataLane3Pol == 1);
				m_nudCSI2ClockPos.Value = m_DataConfigParams.CSI2ClockPos;
				m_chkCSI2ClockPol.Checked = (m_DataConfigParams.CSI2ClockPol == 1);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateDataConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateDataConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_cboLvdsLaneClkCfg.SelectedIndex = (int)m_DataConfigParams.laneClk;
				m_cboLvdsDataRate.SelectedIndex = (int)m_DataConfigParams.DataRate;
				m_cboLaneEnFormat.SelectedIndex = (int)m_DataConfigParams.f000327;
				f000244.Checked = (m_DataConfigParams.lane1En == 1);
				f000243.Checked = (m_DataConfigParams.lane2En == 1);
				f000242.Checked = (m_DataConfigParams.lane3En == 1);
				f000241.Checked = (m_DataConfigParams.lane4En == 1);
				f000246.Checked = (m_DataConfigParams.msbFirst == 1);
				m_chbLvdsPacketEndPulse.Checked = (m_DataConfigParams.endPulse == 1);
				f000245.Checked = (m_DataConfigParams.crc == 1);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateAndLoadDataConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateAndLoadDataConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_cboDataPathCfgPath.SelectedIndex = (int)m_DataConfigParams.DataPath;
				m_cboDataCfgFmt0.SelectedIndex = (int)m_DataConfigParams.DataFmt0;
				m_cboDataCfgFmt1.SelectedIndex = (int)m_DataConfigParams.DataFmt1;
				m_nudPkt0VChannelNo.Value = m_DataConfigParams.CS2Pkt0VirtualChannelNo;
				m_nudPkt1VChannelNo.Value = m_DataConfigParams.CS2Pkt1VirtualChannelNo;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateDataPathConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateDataPathConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				if (m_DataConfigParams.DataPath == '\0')
				{
					m_cboDataPathCfgPath.SelectedIndex = (int)m_DataConfigParams.DataPath;
					m_cboDataPathCQConfig.SelectedIndex = (int)m_DataConfigParams.CQConfig;
					m_nudDataPathCQ0TransSize.Value = m_DataConfigParams.CQ0TransSize;
					m_nudDataPathCQ1TransSize.Value = m_DataConfigParams.CQ1TransSize;
					m_nudDataPathCQ2TransSize.Value = m_DataConfigParams.CQ2TransSize;
					if ((m_DataConfigParams.DataFmt0 & '?') == '\u0001')
					{
						if ((m_DataConfigParams.DataFmt0 & '@') == '\0' && (m_DataConfigParams.DataFmt0 & '\u0080') == '\0')
						{
							m_cboDataCfgFmt0.SelectedIndex = 0;
							m_nudPkt0VChannelNo.Value = 0m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\0')
						{
							m_cboDataCfgFmt0.SelectedIndex = 0;
							m_nudPkt0VChannelNo.Value = 1m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\0' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt0.SelectedIndex = 0;
							m_nudPkt0VChannelNo.Value = 2m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt0.SelectedIndex = 0;
							m_nudPkt0VChannelNo.Value = 3m;
						}
					}
					else if ((m_DataConfigParams.DataFmt0 & '?') == '\u0006')
					{
						if ((m_DataConfigParams.DataFmt0 & '@') == '\0' && (m_DataConfigParams.DataFmt0 & '\u0080') == '\0')
						{
							m_cboDataCfgFmt0.SelectedIndex = 1;
							m_nudPkt0VChannelNo.Value = 0m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\0')
						{
							m_cboDataCfgFmt0.SelectedIndex = 1;
							m_nudPkt0VChannelNo.Value = 1m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\0' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt0.SelectedIndex = 1;
							m_nudPkt0VChannelNo.Value = 2m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt0.SelectedIndex = 1;
							m_nudPkt0VChannelNo.Value = 3m;
						}
					}
					else if ((m_DataConfigParams.DataFmt0 & '?') == '\t')
					{
						if ((m_DataConfigParams.DataFmt0 & '@') == '\0' && (m_DataConfigParams.DataFmt0 & '\u0080') == '\0')
						{
							m_cboDataCfgFmt0.SelectedIndex = 2;
							m_nudPkt0VChannelNo.Value = 0m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\0')
						{
							m_cboDataCfgFmt0.SelectedIndex = 2;
							m_nudPkt0VChannelNo.Value = 1m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\0' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt0.SelectedIndex = 2;
							m_nudPkt0VChannelNo.Value = 2m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt0.SelectedIndex = 2;
							m_nudPkt0VChannelNo.Value = 3m;
						}
					}
					else if ((m_DataConfigParams.DataFmt0 & '?') == '6')
					{
						if ((m_DataConfigParams.DataFmt0 & '@') == '\0' && (m_DataConfigParams.DataFmt0 & '\u0080') == '\0')
						{
							m_cboDataCfgFmt0.SelectedIndex = 3;
							m_nudPkt0VChannelNo.Value = 0m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\0')
						{
							m_cboDataCfgFmt0.SelectedIndex = 3;
							m_nudPkt0VChannelNo.Value = 1m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\0' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt0.SelectedIndex = 3;
							m_nudPkt0VChannelNo.Value = 2m;
						}
						else if ((m_DataConfigParams.DataFmt0 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt0 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt0.SelectedIndex = 3;
							m_nudPkt0VChannelNo.Value = 3m;
						}
					}
					if ((m_DataConfigParams.DataFmt1 & '?') == '\0')
					{
						if ((m_DataConfigParams.DataFmt1 & '@') == '\0' && (m_DataConfigParams.DataFmt1 & '\u0080') == '\0')
						{
							m_cboDataCfgFmt1.SelectedIndex = 0;
							m_nudPkt1VChannelNo.Value = 0m;
						}
						else if ((m_DataConfigParams.DataFmt1 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt1 >> 7 & '\u0001') == '\0')
						{
							m_cboDataCfgFmt1.SelectedIndex = 0;
							m_nudPkt1VChannelNo.Value = 1m;
						}
						else if ((m_DataConfigParams.DataFmt1 >> 6 & '\u0001') == '\0' && (m_DataConfigParams.DataFmt1 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt1.SelectedIndex = 0;
							m_nudPkt1VChannelNo.Value = 2m;
						}
						else if ((m_DataConfigParams.DataFmt1 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt1 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt1.SelectedIndex = 0;
							m_nudPkt1VChannelNo.Value = 3m;
						}
					}
					else if ((m_DataConfigParams.DataFmt1 & '?') == '\u000e')
					{
						if ((m_DataConfigParams.DataFmt1 & '@') == '\0' && (m_DataConfigParams.DataFmt1 & '\u0080') == '\0')
						{
							m_cboDataCfgFmt1.SelectedIndex = 1;
							m_nudPkt1VChannelNo.Value = 0m;
						}
						else if ((m_DataConfigParams.DataFmt1 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt1 >> 7 & '\u0001') == '\0')
						{
							m_cboDataCfgFmt1.SelectedIndex = 1;
							m_nudPkt1VChannelNo.Value = 1m;
						}
						else if ((m_DataConfigParams.DataFmt1 >> 6 & '\u0001') == '\0' && (m_DataConfigParams.DataFmt1 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt1.SelectedIndex = 1;
							m_nudPkt1VChannelNo.Value = 2m;
						}
						else if ((m_DataConfigParams.DataFmt1 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt1 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt1.SelectedIndex = 1;
							m_nudPkt1VChannelNo.Value = 3m;
						}
					}
					else if ((m_DataConfigParams.DataFmt1 & '?') == '\v')
					{
						if ((m_DataConfigParams.DataFmt1 & '@') == '\0' && (m_DataConfigParams.DataFmt1 & '\u0080') == '\0')
						{
							m_cboDataCfgFmt1.SelectedIndex = 2;
							m_nudPkt1VChannelNo.Value = 0m;
						}
						else if ((m_DataConfigParams.DataFmt1 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt1 >> 7 & '\u0001') == '\0')
						{
							m_cboDataCfgFmt1.SelectedIndex = 2;
							m_nudPkt1VChannelNo.Value = 1m;
						}
						else if ((m_DataConfigParams.DataFmt1 >> 6 & '\u0001') == '\0' && (m_DataConfigParams.DataFmt1 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt1.SelectedIndex = 2;
							m_nudPkt1VChannelNo.Value = 2m;
						}
						else if ((m_DataConfigParams.DataFmt1 >> 6 & '\u0001') == '\u0001' && (m_DataConfigParams.DataFmt1 >> 7 & '\u0001') == '\u0001')
						{
							m_cboDataCfgFmt1.SelectedIndex = 2;
							m_nudPkt1VChannelNo.Value = 3m;
						}
					}
				}
				else if (m_DataConfigParams.DataPath == '\u0001')
				{
					m_cboDataPathCfgPath.SelectedIndex = (int)m_DataConfigParams.DataPath;
					m_cboDataPathCQConfig.SelectedIndex = (int)m_DataConfigParams.CQConfig;
					m_nudDataPathCQ0TransSize.Value = m_DataConfigParams.CQ0TransSize;
					m_nudDataPathCQ1TransSize.Value = m_DataConfigParams.CQ1TransSize;
					m_nudDataPathCQ2TransSize.Value = m_DataConfigParams.CQ2TransSize;
					if ((m_DataConfigParams.DataFmt0 & '?') == '\u0001')
					{
						m_cboDataCfgFmt0.SelectedIndex = 0;
					}
					else if ((m_DataConfigParams.DataFmt0 & '?') == '\u0006')
					{
						m_cboDataCfgFmt0.SelectedIndex = 1;
					}
					else if ((m_DataConfigParams.DataFmt0 & '?') == '\t')
					{
						m_cboDataCfgFmt0.SelectedIndex = 2;
					}
					else if ((m_DataConfigParams.DataFmt0 & '?') == '6')
					{
						m_cboDataCfgFmt0.SelectedIndex = 3;
					}
					if ((m_DataConfigParams.DataFmt1 & '?') == '\0')
					{
						m_cboDataCfgFmt1.SelectedIndex = 0;
					}
					else if ((m_DataConfigParams.DataFmt1 & '?') == '\u000e')
					{
						m_cboDataCfgFmt1.SelectedIndex = 1;
					}
					else if ((m_DataConfigParams.DataFmt1 & '?') == '\v')
					{
						m_cboDataCfgFmt1.SelectedIndex = 2;
					}
				}
				else if (m_DataConfigParams.DataPath == '\u0002')
				{
					m_cboDataPathCfgPath.SelectedIndex = (int)m_DataConfigParams.DataPath;
					m_DataConfigParams.CQConfig = (char)m_cboDataPathCQConfig.SelectedIndex;
					m_DataConfigParams.CQ0TransSize = (char)m_nudDataPathCQ0TransSize.Value;
					m_DataConfigParams.CQ1TransSize = (char)m_nudDataPathCQ1TransSize.Value;
					m_DataConfigParams.CQ2TransSize = (char)m_nudDataPathCQ2TransSize.Value;
					if (m_DataConfigParams.DataFmt0 == '\u0001')
					{
						m_cboDataCfgFmt0.SelectedIndex = 0;
					}
					else
					{
						m_cboDataCfgFmt0.SelectedIndex = 0;
					}
					m_cboDataCfgFmt1.SelectedIndex = 0;
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

		public bool LoadDataConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadDataConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ushort intfSel = Convert.ToUInt16(ConfigurationManager.GetAppSetting("intfSel"));
				ushort p = Convert.ToUInt16(ConfigurationManager.GetAppSetting("transferFmtPkt0"));
				ushort p2 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("transferFmtPkt1"));
				ushort cqConfig = Convert.ToUInt16(ConfigurationManager.GetAppSetting("cqConfig"));
				ushort pkt0VirtualChannelNo = Convert.ToUInt16(ConfigurationManager.GetAppSetting("Pkt0VChannelNo"));
				ushort pkt1VirtualChannelNo = Convert.ToUInt16(ConfigurationManager.GetAppSetting("Pkt1VChannelNo"));
				ushort p3 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("laneFrmtCfg"));
				ushort lane = Convert.ToUInt16(ConfigurationManager.GetAppSetting("Lane1"));
				ushort lane2 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("Lane2"));
				ushort lane3 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("Lane3"));
				ushort lane4 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("Lane4"));
				ushort p4 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("msbFst"));
				ushort p5 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("pktEndPls"));
				ushort p6 = Convert.ToUInt16(ConfigurationManager.GetAppSetting("crcEn"));
				ushort laneClk = Convert.ToUInt16(ConfigurationManager.GetAppSetting("laneClk"));
				ushort dataRate = Convert.ToUInt16(ConfigurationManager.GetAppSetting("dataRate"));
				m_GuiManager.ScriptOps.UpdateDataPathConfigData((char)intfSel, (char)p, (char)p2, (char)cqConfig, (char)pkt0VirtualChannelNo, (char)pkt1VirtualChannelNo);
				m_GuiManager.ScriptOps.UpdateLvdsLaneConfData(p3, lane, lane2, lane3, lane4, p4, p5, p6);
				m_GuiManager.ScriptOps.UpdateLvdsClkConfData((char)laneClk, (char)dataRate);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveDataConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveDataConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetAppSetting("intfSel", m_cboDataPathCfgPath.SelectedIndex.ToString());
				ConfigurationManager.SetAppSetting("transferFmtPkt0", m_cboDataCfgFmt0.SelectedIndex.ToString());
				ConfigurationManager.SetAppSetting("transferFmtPkt1", m_cboDataCfgFmt1.SelectedIndex.ToString());
				ConfigurationManager.SetAppSetting("cqConfig", m_cboDataCfgFmt1.SelectedIndex.ToString());
				ConfigurationManager.SetAppSetting("Pkt0VChannelNo", m_nudPkt0VChannelNo.Value.ToString());
				ConfigurationManager.SetAppSetting("Pkt1VChannelNo", m_nudPkt1VChannelNo.Value.ToString());
				ConfigurationManager.SetAppSetting("laneFrmtCfg", m_cboLaneEnFormat.SelectedIndex.ToString());
				ConfigurationManager.SetAppSetting("Lane1", (f000244.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetAppSetting("Lane2", (f000243.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetAppSetting("Lane3", (f000242.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetAppSetting("Lane4", (f000241.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetAppSetting("msbFst", (f000246.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetAppSetting("pktEndPls", (m_chbLvdsPacketEndPulse.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetAppSetting("crcEn", (f000245.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetAppSetting("laneClk", m_cboLvdsLaneClkCfg.SelectedIndex.ToString());
				ConfigurationManager.SetAppSetting("dataRate", m_cboLvdsDataRate.SelectedIndex.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private void m_lblDataCfgTransConf0_Click(object sender, EventArgs p1)
		{
		}

		private int iSetDataPathConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetDataPathConfig_Gui(is_starting_op, is_ending_op);
		}

		public void SetLVDSDataPathConfigReadyState()
		{
			f00023d.ForeColor = Color.Blue;
		}

		public void ReSetDataPathConfigReadyState()
		{
			m_btnDataPathCfg.ForeColor = Color.Black;
		}

		private void iSetDataPathConfig()
		{
			iSetDataPathConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
			SetLVDSDataPathConfigReadyState();
			ReSetDataPathConfigReadyState();
		}

		public void iSetDataPathConfigAsync()
		{
			new del_v_v(iSetDataPathConfig).BeginInvoke(null, null);
		}

		private void m_btnDataPathCfg_Click(object sender, EventArgs p1)
		{
			iSetDataPathConfigAsync();
		}

		private int iSetLvdsClkConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetLvdsClkConfig_Gui(is_starting_op, is_ending_op);
		}

		public void SetLVDSLaneConfigReadyState()
		{
			f00023f.ForeColor = Color.Blue;
		}

		public void ReSetLVDSDataPathConfigReadyState()
		{
			f00023d.ForeColor = Color.Black;
		}

		private void iSetLvdsClkConfig()
		{
			iSetLvdsClkConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
			SetLVDSLaneConfigReadyState();
			ReSetLVDSDataPathConfigReadyState();
		}

		public void iSetLvdsClkConfigAsync()
		{
			new del_v_v(iSetLvdsClkConfig).BeginInvoke(null, null);
		}

		private void m_btnLvdsLaneClkCfg_Click(object sender, EventArgs p1)
		{
			iSetLvdsClkConfigAsync();
		}

		private int iSetLvdsLaneConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetLvdsLaneConfig_Gui(is_starting_op, is_ending_op);
		}

		public void ReSetLVDSLaneDataPathConfigReadyState()
		{
			f00023f.ForeColor = Color.Black;
		}

		private void iSetLvdsLaneConfig()
		{
			iSetLvdsLaneConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
			ReSetLVDSLaneDataPathConfigReadyState();
		}

		public void iSetLvdsLaneConfigAsync()
		{
			new del_v_v(iSetLvdsLaneConfig).BeginInvoke(null, null);
		}

		private void m_btnLvdsLaneCfg_Click(object sender, EventArgs p1)
		{
			iSetLvdsLaneConfigAsync();
		}

		private void m_lblLaneClkCfg_Click(object sender, EventArgs p1)
		{
		}

		private void m_cboLvdsLaneClkCfg_SelectedIndexChanged(object sender, EventArgs p1)
		{
			string a = m_cboLvdsLaneClkCfg.SelectedIndex.ToString();
			object[] items2;
			if (a == "0")
			{
				m_cboLvdsDataRate.Items.Clear();
				ComboBox.ObjectCollection items = m_cboLvdsDataRate.Items;
				items2 = comboBoxRangeB;
				items.AddRange(items2);
				m_cboLvdsDataRate.SelectedIndex = 0;
				return;
			}
			if (!(a == "1"))
			{
				return;
			}
			m_cboLvdsDataRate.Items.Clear();
			ComboBox.ObjectCollection items3 = m_cboLvdsDataRate.Items;
			items2 = comboBoxRangeA;
			items3.AddRange(items2);
			m_cboLvdsDataRate.SelectedIndex = 0;
		}

		public bool iDisableDataCfgTabBtns()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(iDisableDataCfgTabBtns);
				return (bool)base.Invoke(method);
			}
			m_btnDataPathCfg.Enabled = false;
			f00023f.Enabled = false;
			f00023d.Enabled = false;
			return true;
		}

		public bool iEnableDataCfgTabBtns()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(iEnableDataCfgTabBtns);
				return (bool)base.Invoke(method);
			}
			m_btnDataPathCfg.Enabled = true;
			f00023f.Enabled = true;
			f00023d.Enabled = true;
			return true;
		}

		private void m_lblDataPathCfgPath_Click(object sender, EventArgs p1)
		{
			if (m_cboDataPathCfgPath.SelectedIndex == 0)
			{
				m_nudPkt0VChannelNo.Enabled = true;
				m_nudPkt1VChannelNo.Enabled = true;
				m_cboDataCfgFmt0.Enabled = true;
				m_cboDataCfgFmt1.Enabled = true;
			}
			else if (m_cboDataPathCfgPath.SelectedIndex == 2)
			{
				m_nudPkt0VChannelNo.Enabled = false;
				m_nudPkt1VChannelNo.Enabled = false;
				m_cboDataCfgFmt0.Enabled = false;
				m_cboDataCfgFmt1.Enabled = false;
			}
			else
			{
				m_nudPkt0VChannelNo.Enabled = false;
				m_nudPkt1VChannelNo.Enabled = false;
				m_cboDataCfgFmt0.Enabled = true;
				m_cboDataCfgFmt1.Enabled = true;
			}
			if (m_cboDataPathCfgPath.SelectedIndex == 0)
			{
				m_GroupCS2LaneConfig.Enabled = true;
				f000240.Enabled = false;
			}
			else
			{
				m_GroupCS2LaneConfig.Enabled = false;
				f000240.Enabled = true;
			}
			if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
			{
				f000242.Enabled = true;
				f000241.Enabled = true;
				f000242.Checked = true;
				f000241.Checked = true;
				m_cboDataPathCfgPath.Enabled = true;
				return;
			}
			if (GlobalRef.g_AR16xxDevice)
			{
				f000242.Enabled = false;
				f000241.Enabled = false;
				f000242.Checked = false;
				f000241.Checked = false;
				m_cboDataPathCfgPath.Enabled = false;
			}
		}

		public bool MappedLVDSDataLane1EnableWithRx1()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(MappedLVDSDataLane1EnableWithRx1);
				return (bool)base.Invoke(method);
			}
			f000244.Checked = Convert.ToBoolean(1);
			return true;
		}

		public void MappedLVDSDataLane1DisableWithRx1()
		{
			f000244.Checked = false;
		}

		public void enableLVDSLane1()
		{
			EnableControl_Rec(true, f000244);
		}

		public void EnableControl_Rec(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(EnableControl_Rec);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is CheckBox)
			{
				f000244.Checked = true;
				return;
			}
			f000244.Checked = false;
		}

		public void disableLVDSLane1()
		{
			disableControl_Rec(true, f000244);
		}

		public void disableControl_Rec(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(disableControl_Rec);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is CheckBox)
			{
				f000244.Checked = false;
				return;
			}
			f000244.Checked = true;
		}

		public void enableLVDSLane2()
		{
			EnableControl_Rec2(true, f000243);
		}

		public void EnableControl_Rec2(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(EnableControl_Rec2);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is CheckBox)
			{
				f000243.Checked = true;
				return;
			}
			f000243.Checked = false;
		}

		public void disableLVDSLane2()
		{
			disableControl_Rec2(true, f000243);
		}

		public void disableControl_Rec2(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(disableControl_Rec2);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is CheckBox)
			{
				f000243.Checked = false;
				return;
			}
			f000243.Checked = true;
		}

		public void enableLVDSLane3()
		{
			EnableControl_Rec3(true, f000242);
		}

		public void EnableControl_Rec3(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(EnableControl_Rec3);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is CheckBox)
			{
				f000242.Checked = true;
				return;
			}
			f000242.Checked = false;
		}

		public void disableLVDSLane3()
		{
			disableControl_Rec3(true, f000242);
		}

		public void disableControl_Rec3(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(disableControl_Rec3);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is CheckBox)
			{
				f000242.Checked = false;
				return;
			}
			f000242.Checked = true;
		}

		public void enableLVDSLane4()
		{
			EnableControl_Rec4(true, f000241);
		}

		public void EnableControl_Rec4(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(EnableControl_Rec4);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is CheckBox)
			{
				f000241.Checked = true;
				return;
			}
			f000241.Checked = false;
		}

		public void disableLVDSLane4()
		{
			disableControl_Rec4(true, f000241);
		}

		public void disableControl_Rec4(bool bEnable, Control ctrl)
		{
			if (base.InvokeRequired)
			{
				del_b_ctrl method = new del_b_ctrl(disableControl_Rec4);
				base.Invoke(method, new object[]
				{
					bEnable,
					ctrl
				});
				return;
			}
			if (ctrl is CheckBox)
			{
				f000241.Checked = false;
				return;
			}
			f000241.Checked = true;
		}

		public void m000072()
		{
			if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
			{
				f000242.Enabled = true;
				f000241.Enabled = true;
				f000242.Checked = true;
				f000241.Checked = true;
				m_cboDataPathCfgPath.Enabled = true;
				return;
			}
			if (GlobalRef.g_AR16xxDevice)
			{
				f000242.Enabled = false;
				f000241.Enabled = false;
				f000242.Checked = false;
				f000241.Checked = false;
				m_cboDataPathCfgPath.Enabled = false;
			}
		}

		public void DisableEnableCQConfigAndCQ0_1_2_TransSize_BasedOn_RadarDevice()
		{
			if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
			{
				m_cboDataPathCQConfig.Enabled = true;
				m_nudDataPathCQ0TransSize.Enabled = true;
				m_nudDataPathCQ1TransSize.Enabled = true;
				m_nudDataPathCQ2TransSize.Enabled = true;
				m_lblDataPathCQConfig.Enabled = true;
				m_lblDataPathCQ0TransSize.Enabled = true;
				m_lblDataPathCQ1TransSize.Enabled = true;
				m_lblDataPathCQ2TransSize.Enabled = true;
				m_grpMSSTestPatternGenConfig.Enabled = true;
				return;
			}
			if (GlobalRef.g_AR16xxDevice || GlobalRef.g_AR1843Device || GlobalRef.g_AR6843Device)
			{
				m_cboDataPathCQConfig.Enabled = false;
				m_nudDataPathCQ0TransSize.Enabled = false;
				m_nudDataPathCQ1TransSize.Enabled = false;
				m_nudDataPathCQ2TransSize.Enabled = false;
				m_lblDataPathCQConfig.Enabled = false;
				m_lblDataPathCQ0TransSize.Enabled = false;
				m_lblDataPathCQ1TransSize.Enabled = false;
				m_lblDataPathCQ2TransSize.Enabled = false;
				m_grpMSSTestPatternGenConfig.Enabled = false;
			}
		}

		private int iSetTestPatternGeneratingConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetTestPatternGeneratingConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetTestPatternGeneratingConfig()
		{
			iSetTestPatternGeneratingConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetTestPatternGeneratingConfigAsync()
		{
			new del_v_v(iSetTestPatternGeneratingConfig).BeginInvoke(null, null);
		}

		private void m_btnTestPatternGeneratedCfg_Click(object sender, EventArgs p1)
		{
			iSetTestPatternGeneratingConfigAsync();
		}

		public bool UpdateTestPatternGeneratingConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTestPatternGeneratingConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_TestPatternGenConfigParams.TestPatternGenCtl = (byte)m_chkTestPatternGenCtl.Value;
				m_TestPatternGenConfigParams.TestPatternGenTiming = (byte)m_nudTestPatternGenTiming.Value;
				m_TestPatternGenConfigParams.TestPatternPktSize = (ushort)m_nudTestPatternPktSize.Value;
				m_TestPatternGenConfigParams.NumTestPatternPkts = (uint)m_nudNumTestPatternPkts.Value;
				m_TestPatternGenConfigParams.TestPatternRx0ICfg1 = (ushort)m_nudTestPatternRx0ICFG.Value;
				m_TestPatternGenConfigParams.TestPatternRx0ICfg2 = (ushort)m_nudTestPatternRx0ICFG0.Value;
				m_TestPatternGenConfigParams.TestPatternRx1ICfg1 = (ushort)m_nudTestPatternRx1ICFG.Value;
				m_TestPatternGenConfigParams.TestPatternRx1ICfg2 = (ushort)m_nudTestPatternRx1ICFG1.Value;
				m_TestPatternGenConfigParams.TestPatternRx2ICfg1 = (ushort)m_nudTestPatternRx2ICFG.Value;
				m_TestPatternGenConfigParams.TestPatternRx2ICfg2 = (ushort)m_nudTestPatternRx2ICFG2.Value;
				m_TestPatternGenConfigParams.TestPatternRx3ICfg1 = (ushort)m_nudTestPatternRx3ICFG.Value;
				m_TestPatternGenConfigParams.TestPatternRx3ICfg2 = (ushort)m_nudTestPatternRx3ICFG3.Value;
				m_TestPatternGenConfigParams.TestPatternRx0QCfg1 = (ushort)m_nudTestPatternRx0QCFG.Value;
				m_TestPatternGenConfigParams.TestPatternRx0QCfg2 = (ushort)m_nudTestPatternRx0QCFG0.Value;
				m_TestPatternGenConfigParams.TestPatternRx1QCfg1 = (ushort)m_nudTestPatternRx1QCFG.Value;
				m_TestPatternGenConfigParams.TestPatternRx1QCfg2 = (ushort)m_nudTestPatternRx1QCFG1.Value;
				m_TestPatternGenConfigParams.TestPatternRx2QCfg1 = (ushort)m_nudTestPatternRx2QCFG.Value;
				m_TestPatternGenConfigParams.TestPatternRx2QCfg2 = (ushort)m_nudTestPatternRx2QCFG2.Value;
				m_TestPatternGenConfigParams.TestPatternRx3QCfg1 = (ushort)m_nudTestPatternRx3QCFG.Value;
				m_TestPatternGenConfigParams.TestPatternRx3QCfg2 = (ushort)m_nudTestPatternRx3QCFG3.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateTestPatternGeneratingConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateTestPatternGeneratingConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_chkTestPatternGenCtl.Value = m_TestPatternGenConfigParams.TestPatternGenCtl;
				m_nudTestPatternGenTiming.Value = m_TestPatternGenConfigParams.TestPatternGenTiming;
				m_nudTestPatternPktSize.Value = m_TestPatternGenConfigParams.TestPatternPktSize;
				m_nudNumTestPatternPkts.Value = m_TestPatternGenConfigParams.NumTestPatternPkts;
				m_nudTestPatternRx0ICFG.Value = m_TestPatternGenConfigParams.TestPatternRx0ICfg1;
				m_nudTestPatternRx0ICFG0.Value = m_TestPatternGenConfigParams.TestPatternRx0ICfg2;
				m_nudTestPatternRx1ICFG.Value = m_TestPatternGenConfigParams.TestPatternRx1ICfg1;
				m_nudTestPatternRx1ICFG1.Value = m_TestPatternGenConfigParams.TestPatternRx1ICfg2;
				m_nudTestPatternRx2ICFG.Value = m_TestPatternGenConfigParams.TestPatternRx2ICfg1;
				m_nudTestPatternRx2ICFG2.Value = m_TestPatternGenConfigParams.TestPatternRx2ICfg2;
				m_nudTestPatternRx3ICFG.Value = m_TestPatternGenConfigParams.TestPatternRx3ICfg1;
				m_nudTestPatternRx3ICFG3.Value = m_TestPatternGenConfigParams.TestPatternRx3ICfg2;
				m_nudTestPatternRx0QCFG.Value = m_TestPatternGenConfigParams.TestPatternRx0QCfg1;
				m_nudTestPatternRx0QCFG0.Value = m_TestPatternGenConfigParams.TestPatternRx0QCfg2;
				m_nudTestPatternRx1QCFG.Value = m_TestPatternGenConfigParams.TestPatternRx1QCfg1;
				m_nudTestPatternRx1QCFG1.Value = m_TestPatternGenConfigParams.TestPatternRx1QCfg2;
				m_nudTestPatternRx2QCFG.Value = m_TestPatternGenConfigParams.TestPatternRx2QCfg1;
				m_nudTestPatternRx2QCFG2.Value = m_TestPatternGenConfigParams.TestPatternRx2QCfg2;
				m_nudTestPatternRx3QCFG.Value = m_TestPatternGenConfigParams.TestPatternRx3QCfg1;
				m_nudTestPatternRx3QCFG3.Value = m_TestPatternGenConfigParams.TestPatternRx3QCfg2;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveDataPathConfData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveDataPathConfData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetdataPathConfigKeyVal("dataPathCfgPath", m_cboDataPathCfgPath.SelectedIndex.ToString());
				ConfigurationManager.SetdataPathConfigKeyVal("dataCfgFmt0", m_cboDataCfgFmt0.SelectedIndex.ToString());
				ConfigurationManager.SetdataPathConfigKeyVal("dataCfgFmt1", m_cboDataCfgFmt1.SelectedIndex.ToString());
				ConfigurationManager.SetdataPathConfigKeyVal("pkt0VChannelNo", m_nudPkt0VChannelNo.Value.ToString());
				ConfigurationManager.SetdataPathConfigKeyVal("pkt1VChannelNo", m_nudPkt1VChannelNo.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadDataPathConfData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadDataPathConfData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte dataPathCfgPath = Convert.ToByte(ConfigurationManager.GetdataPathConfigKeyVal("dataPathCfgPath"));
				byte p = Convert.ToByte(ConfigurationManager.GetdataPathConfigKeyVal("dataCfgFmt0"));
				byte p2 = Convert.ToByte(ConfigurationManager.GetdataPathConfigKeyVal("dataCfgFmt1"));
				byte pkt0VChannelNo = Convert.ToByte(ConfigurationManager.GetdataPathConfigKeyVal("pkt0VChannelNo"));
				byte pkt1VChannelNo = Convert.ToByte(ConfigurationManager.GetdataPathConfigKeyVal("pkt1VChannelNo"));
				m_GuiManager.ScriptOps.LoadNDataPathConfData(dataPathCfgPath, p, p2, pkt0VChannelNo, pkt1VChannelNo);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveClockConfData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveClockConfData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetClockConfigKeyVal("laneClock", m_cboLvdsLaneClkCfg.SelectedIndex.ToString());
				ConfigurationManager.SetClockConfigKeyVal("dataRate", m_cboLvdsDataRate.SelectedIndex.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadClockConfData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadClockConfData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte laneClock = Convert.ToByte(ConfigurationManager.GetClockConfigKeyVal("laneClock"));
				byte dataRate = Convert.ToByte(ConfigurationManager.GetClockConfigKeyVal("dataRate"));
				m_GuiManager.ScriptOps.LoadNClockConfData(laneClock, dataRate);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveLVDSLaneConfData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveLVDSLaneConfData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetlvdsLaneConfigKeyVal("laneFormat", m_cboLaneEnFormat.SelectedIndex.ToString());
				ConfigurationManager.SetlvdsLaneConfigKeyVal("lane1En", (f000244.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetlvdsLaneConfigKeyVal("lane2En", (f000243.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetlvdsLaneConfigKeyVal("lane3En", (f000242.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetlvdsLaneConfigKeyVal("lane4En", (f000241.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetlvdsLaneConfigKeyVal("lvdsMsbFirst", (f000246.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetlvdsLaneConfigKeyVal("lvdsCrcEn", (f000245.Checked ? 1 : 0).ToString());
				ConfigurationManager.SetlvdsLaneConfigKeyVal("lvdsPacketEndPulse", (m_chbLvdsPacketEndPulse.Checked ? 1 : 0).ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadLVDSLaneConfData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadLVDSLaneConfData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ushort laneFormat = Convert.ToUInt16(ConfigurationManager.GetlvdsLaneConfigKeyVal("laneFormat"));
				ushort lane1En = Convert.ToUInt16(ConfigurationManager.GetlvdsLaneConfigKeyVal("lane1En"));
				ushort lane2En = Convert.ToUInt16(ConfigurationManager.GetlvdsLaneConfigKeyVal("lane2En"));
				ushort lane3En = Convert.ToUInt16(ConfigurationManager.GetlvdsLaneConfigKeyVal("lane3En"));
				ushort lane4En = Convert.ToUInt16(ConfigurationManager.GetlvdsLaneConfigKeyVal("lane4En"));
				ushort p = Convert.ToUInt16(ConfigurationManager.GetlvdsLaneConfigKeyVal("lvdsMsbFirst"));
				ushort p2 = Convert.ToUInt16(ConfigurationManager.GetlvdsLaneConfigKeyVal("lvdsCrcEn"));
				ushort lvdsPacketEndPulse = Convert.ToUInt16(ConfigurationManager.GetlvdsLaneConfigKeyVal("lvdsPacketEndPulse"));
				m_GuiManager.ScriptOps.LoadNLVDSLaneConfData(laneFormat, lane1En, lane2En, lane3En, lane4En, p, p2, lvdsPacketEndPulse);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveCSI2ConfData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveCSI2ConfData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.Setcsi2ConfigKeyVal("lane0Pos", m_nudCSI2Lane0Pos.Value.ToString());
				ConfigurationManager.Setcsi2ConfigKeyVal("lane0Pol", (m_chkCSI2Lane0Pol.Checked ? 1 : 0).ToString());
				ConfigurationManager.Setcsi2ConfigKeyVal("lane1Pos", m_nudCSI2Lane1Pos.Value.ToString());
				ConfigurationManager.Setcsi2ConfigKeyVal("lane1Pol", (m_chkCSI2Lane1Pol.Checked ? 1 : 0).ToString());
				ConfigurationManager.Setcsi2ConfigKeyVal("lane2Pos", m_nudCSI2Lane2Pos.Value.ToString());
				ConfigurationManager.Setcsi2ConfigKeyVal("lane2Pol", (m_chkCSI2Lane2Pol.Checked ? 1 : 0).ToString());
				ConfigurationManager.Setcsi2ConfigKeyVal("lane3Pos", m_nudCSI2Lane3Pos.Value.ToString());
				ConfigurationManager.Setcsi2ConfigKeyVal("lane3Pol", (m_chkCSI2Lane3Pol.Checked ? 1 : 0).ToString());
				ConfigurationManager.Setcsi2ConfigKeyVal("clockPos", m_nudCSI2ClockPos.Value.ToString());
				ConfigurationManager.Setcsi2ConfigKeyVal("clockPol", (m_chkCSI2ClockPol.Checked ? 1 : 0).ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadCSI2ConfData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadCSI2ConfData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ushort lane0Pos = Convert.ToUInt16(ConfigurationManager.Getcsi2ConfigKeyVal("lane0Pos"));
				ushort lane0Pol = Convert.ToUInt16(ConfigurationManager.Getcsi2ConfigKeyVal("lane0Pol"));
				ushort lane1Pos = Convert.ToUInt16(ConfigurationManager.Getcsi2ConfigKeyVal("lane1Pos"));
				ushort lane1Pol = Convert.ToUInt16(ConfigurationManager.Getcsi2ConfigKeyVal("lane1Pol"));
				ushort lane2Pos = Convert.ToUInt16(ConfigurationManager.Getcsi2ConfigKeyVal("lane2Pos"));
				ushort lane2Pol = Convert.ToUInt16(ConfigurationManager.Getcsi2ConfigKeyVal("lane2Pol"));
				ushort lane3Pos = Convert.ToUInt16(ConfigurationManager.Getcsi2ConfigKeyVal("lane3Pos"));
				ushort lane3Pol = Convert.ToUInt16(ConfigurationManager.Getcsi2ConfigKeyVal("lane4Pol"));
				ushort clockPos = Convert.ToUInt16(ConfigurationManager.Getcsi2ConfigKeyVal("clockPos"));
				ushort clockPol = Convert.ToUInt16(ConfigurationManager.Getcsi2ConfigKeyVal("clockPol"));
				m_GuiManager.ScriptOps.LoadNCSI2LaneConfData(lane0Pos, lane0Pol, lane1Pos, lane1Pol, lane2Pos, lane2Pol, lane3Pos, lane3Pol, clockPos, clockPol);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveTestPatternGenConfData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(SaveTestPatternGenConfData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternGenCtl", m_chkTestPatternGenCtl.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternGenTime", m_nudTestPatternGenTiming.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternPktSize", m_nudTestPatternPktSize.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("numTestPatternPkts", m_nudNumTestPatternPkts.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx0ICFGStartOffset", m_nudTestPatternRx0ICFG.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx0ICFGVal", m_nudTestPatternRx0ICFG0.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx0QCFGStartOffset", m_nudTestPatternRx0QCFG.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx0QCFGVal", m_nudTestPatternRx0QCFG0.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx1ICFGStartOffset", m_nudTestPatternRx1ICFG.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx1ICFGVal", m_nudTestPatternRx1ICFG1.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx1QCFGStartOffset", m_nudTestPatternRx1QCFG.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx1QCFGVal", m_nudTestPatternRx1QCFG1.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx2ICFGStartOffset", m_nudTestPatternRx2ICFG.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx2ICFGVal", m_nudTestPatternRx2ICFG2.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx2QCFGStartOffset", m_nudTestPatternRx2QCFG.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx2QCFGVal", m_nudTestPatternRx2QCFG2.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx3ICFGStartOffset", m_nudTestPatternRx3ICFG.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx3ICFGVal", m_nudTestPatternRx3ICFG3.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx3QCFGStartOffset", m_nudTestPatternRx3QCFG.Value.ToString());
				ConfigurationManager.SetTestPatternGenConfigKeyVal("testPatternRx3QCFGVal", m_nudTestPatternRx3QCFG3.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadTestPatternGenConfData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(LoadTestPatternGenConfData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				byte testPatternGenCtl = Convert.ToByte(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternGenCtl"));
				byte testPatternGenTime = Convert.ToByte(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternGenTime"));
				ushort testPatternPktSize = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternPktSize"));
				uint numTestPatternPkts = (uint)Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("numTestPatternPkts"));
				ushort testPatternRx0ICFGStartOffset = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx0ICFGStartOffset"));
				ushort testPatternRx0ICFGVal = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx0ICFGVal"));
				ushort testPatternRx0QCFGStartOffset = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx0QCFGStartOffset"));
				ushort testPatternRx0QCFGVal = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx0QCFGVal"));
				ushort testPatternRx1ICFGStartOffset = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx1ICFGStartOffset"));
				ushort testPatternRx1ICFGVal = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx1ICFGVal"));
				ushort testPatternRx1QCFGStartOffset = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx1QCFGStartOffset"));
				ushort testPatternRx1QCFGVal = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx1QCFGVal"));
				ushort testPatternRx2ICFGStartOffset = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx2ICFGStartOffset"));
				ushort testPatternRx2ICFGVal = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx2ICFGVal"));
				ushort testPatternRx2QCFGStartOffset = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx2QCFGStartOffset"));
				ushort testPatternRx2QCFGVal = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx2QCFGVal"));
				ushort testPatternRx3ICFGStartOffset = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx3ICFGStartOffset"));
				ushort testPatternRx3ICFGVal = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx3ICFGVal"));
				ushort testPatternRx3QCFGStartOffset = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx3QCFGStartOffset"));
				ushort testPatternRx3QCFGVal = Convert.ToUInt16(ConfigurationManager.GetTestPatternGenConfigKeyVal("testPatternRx3QCFGVal"));
				m_GuiManager.ScriptOps.LoadNTestPatternGenConfData(testPatternGenCtl, testPatternGenTime, testPatternPktSize, numTestPatternPkts, testPatternRx0ICFGStartOffset, testPatternRx0ICFGVal, testPatternRx0QCFGStartOffset, testPatternRx0QCFGVal, testPatternRx1ICFGStartOffset, testPatternRx1ICFGVal, testPatternRx1QCFGStartOffset, testPatternRx1QCFGVal, testPatternRx2ICFGStartOffset, testPatternRx2ICFGVal, testPatternRx2QCFGStartOffset, testPatternRx2QCFGVal, testPatternRx3ICFGStartOffset, testPatternRx3ICFGVal, testPatternRx3QCFGStartOffset, testPatternRx3QCFGVal);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public int getDataPathConfigFormat()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(getDataPathConfigFormat);
				return (int)base.Invoke(method);
			}
			return m_cboDataCfgFmt0.SelectedIndex;
		}

		public int getDataPathConfigFormat1()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(getDataPathConfigFormat1);
				return (int)base.Invoke(method);
			}
			return m_cboDataCfgFmt1.SelectedIndex;
		}

		public int getNumLVDSLanes()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(getNumLVDSLanes);
				return (int)base.Invoke(method);
			}
			int num = 0;
			if (f000244.Checked)
			{
				num++;
			}
			if (f000243.Checked)
			{
				num++;
			}
			if (f000242.Checked)
			{
				num++;
			}
			if (f000241.Checked)
			{
				num++;
			}
			return num;
		}

		public int getCQvalue()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(getCQvalue);
				return (int)base.Invoke(method);
			}
			return (int)m_nudDataPathCQ0TransSize.Value + (int)m_nudDataPathCQ1TransSize.Value + (int)m_nudDataPathCQ2TransSize.Value;
		}

		public int getCQNumBits()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(getCQNumBits);
				return (int)base.Invoke(method);
			}
			int result;
			try
			{
				int num = 0;
				if (m_cboDataPathCQConfig.SelectedIndex == 0)
				{
					num = 12;
				}
				else if (m_cboDataPathCQConfig.SelectedIndex == 1)
				{
					num = 14;
				}
				else if (m_cboDataPathCQConfig.SelectedIndex == 2)
				{
					num = 16;
				}
				result = num;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = 0;
			}
			return result;
		}

		public int setCSI2DataPath()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(setCSI2DataPath);
				return (int)base.Invoke(method);
			}
			int result;
			try
			{
				m_cboDataPathCfgPath.SelectedIndex = 0;
				result = 0;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = 0;
			}
			return result;
		}

		private void m_grpMSSTestPatternGenConfig_Enter(object sender, EventArgs p1)
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
            this.m_grpDataPathConf = new System.Windows.Forms.GroupBox();
            this.m_cboDataPathCQConfig = new System.Windows.Forms.ComboBox();
            this.m_nudDataPathCQ2TransSize = new System.Windows.Forms.NumericUpDown();
            this.m_nudDataPathCQ1TransSize = new System.Windows.Forms.NumericUpDown();
            this.m_nudDataPathCQ0TransSize = new System.Windows.Forms.NumericUpDown();
            this.m_lblDataPathCQ2TransSize = new System.Windows.Forms.Label();
            this.m_lblDataPathCQ1TransSize = new System.Windows.Forms.Label();
            this.m_lblDataPathCQ0TransSize = new System.Windows.Forms.Label();
            this.m_lblDataPathCQConfig = new System.Windows.Forms.Label();
            this.m_nudPkt1VChannelNo = new System.Windows.Forms.NumericUpDown();
            this.m_nudPkt0VChannelNo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnDataPathCfg = new System.Windows.Forms.Button();
            this.m_lblDataCfgTransConf0 = new System.Windows.Forms.Label();
            this.m_cboDataPathCfgPath = new System.Windows.Forms.ComboBox();
            this.m_lblDataCfgPath = new System.Windows.Forms.Label();
            this.m_lblDataCfgTransConf1 = new System.Windows.Forms.Label();
            this.m_cboDataCfgFmt0 = new System.Windows.Forms.ComboBox();
            this.m_cboDataCfgFmt1 = new System.Windows.Forms.ComboBox();
            this.f00023c = new System.Windows.Forms.GroupBox();
            this.f00023d = new System.Windows.Forms.Button();
            this.m_lblLvdsDataRate = new System.Windows.Forms.Label();
            this.m_cboLvdsLaneClkCfg = new System.Windows.Forms.ComboBox();
            this.f00023e = new System.Windows.Forms.Label();
            this.m_cboLvdsDataRate = new System.Windows.Forms.ComboBox();
            this.f00023f = new System.Windows.Forms.Button();
            this.m_GroupCS2LaneConfig = new System.Windows.Forms.GroupBox();
            this.m_chkCSI2ClockPol = new System.Windows.Forms.CheckBox();
            this.m_chkCSI2Lane3Pol = new System.Windows.Forms.CheckBox();
            this.m_chkCSI2Lane2Pol = new System.Windows.Forms.CheckBox();
            this.m_chkCSI2Lane1Pol = new System.Windows.Forms.CheckBox();
            this.m_chkCSI2Lane0Pol = new System.Windows.Forms.CheckBox();
            this.m_nudCSI2ClockPos = new System.Windows.Forms.NumericUpDown();
            this.m_nudCSI2Lane3Pos = new System.Windows.Forms.NumericUpDown();
            this.m_nudCSI2Lane2Pos = new System.Windows.Forms.NumericUpDown();
            this.m_nudCSI2Lane1Pos = new System.Windows.Forms.NumericUpDown();
            this.m_nudCSI2Lane0Pos = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.f000240 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.f000241 = new System.Windows.Forms.CheckBox();
            this.f000242 = new System.Windows.Forms.CheckBox();
            this.f000243 = new System.Windows.Forms.CheckBox();
            this.f000244 = new System.Windows.Forms.CheckBox();
            this.m_lblLvdsLane = new System.Windows.Forms.Label();
            this.m_cboLaneEnFormat = new System.Windows.Forms.ComboBox();
            this.f000245 = new System.Windows.Forms.CheckBox();
            this.m_chbLvdsPacketEndPulse = new System.Windows.Forms.CheckBox();
            this.f000246 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_grpMSSTestPatternGenConfig = new System.Windows.Forms.GroupBox();
            this.m_chkTestPatternGenCtl = new System.Windows.Forms.NumericUpDown();
            this.m_nudNumTestPatternPkts = new System.Windows.Forms.NumericUpDown();
            this.m_nudTestPatternPktSize = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.m_btnTestPatternGeneratedCfg = new System.Windows.Forms.Button();
            this.m_nudTestPatternRx3QCFG3 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTestPatternRx3QCFG = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.m_nudTestPatternRx3ICFG3 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTestPatternRx3ICFG = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.m_nudTestPatternRx2QCFG2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTestPatternRx2QCFG = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.m_nudTestPatternRx2ICFG2 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTestPatternRx2ICFG = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.m_nudTestPatternRx1QCFG1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTestPatternRx1QCFG = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.m_nudTestPatternRx1ICFG1 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTestPatternRx1ICFG = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.m_nudTestPatternRx0QCFG0 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTestPatternRx0QCFG = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.m_nudTestPatternRx0ICFG0 = new System.Windows.Forms.NumericUpDown();
            this.m_nudTestPatternRx0ICFG = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.m_nudTestPatternGenTiming = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_grpDataPathConf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathCQ2TransSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathCQ1TransSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathCQ0TransSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPkt1VChannelNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPkt0VChannelNo)).BeginInit();
            this.f00023c.SuspendLayout();
            this.m_GroupCS2LaneConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudCSI2ClockPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudCSI2Lane3Pos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudCSI2Lane2Pos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudCSI2Lane1Pos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudCSI2Lane0Pos)).BeginInit();
            this.f000240.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_grpMSSTestPatternGenConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_chkTestPatternGenCtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudNumTestPatternPkts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternPktSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx3QCFG3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx3QCFG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx3ICFG3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx3ICFG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx2QCFG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx2QCFG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx2ICFG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx2ICFG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx1QCFG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx1QCFG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx1ICFG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx1ICFG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx0QCFG0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx0QCFG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx0ICFG0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx0ICFG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternGenTiming)).BeginInit();
            this.SuspendLayout();
            // 
            // m_grpDataPathConf
            // 
            this.m_grpDataPathConf.Controls.Add(this.m_cboDataPathCQConfig);
            this.m_grpDataPathConf.Controls.Add(this.m_nudDataPathCQ2TransSize);
            this.m_grpDataPathConf.Controls.Add(this.m_nudDataPathCQ1TransSize);
            this.m_grpDataPathConf.Controls.Add(this.m_nudDataPathCQ0TransSize);
            this.m_grpDataPathConf.Controls.Add(this.m_lblDataPathCQ2TransSize);
            this.m_grpDataPathConf.Controls.Add(this.m_lblDataPathCQ1TransSize);
            this.m_grpDataPathConf.Controls.Add(this.m_lblDataPathCQ0TransSize);
            this.m_grpDataPathConf.Controls.Add(this.m_lblDataPathCQConfig);
            this.m_grpDataPathConf.Controls.Add(this.m_nudPkt1VChannelNo);
            this.m_grpDataPathConf.Controls.Add(this.m_nudPkt0VChannelNo);
            this.m_grpDataPathConf.Controls.Add(this.label2);
            this.m_grpDataPathConf.Controls.Add(this.m_btnDataPathCfg);
            this.m_grpDataPathConf.Controls.Add(this.m_lblDataCfgTransConf0);
            this.m_grpDataPathConf.Controls.Add(this.m_cboDataPathCfgPath);
            this.m_grpDataPathConf.Controls.Add(this.m_lblDataCfgPath);
            this.m_grpDataPathConf.Controls.Add(this.m_lblDataCfgTransConf1);
            this.m_grpDataPathConf.Controls.Add(this.m_cboDataCfgFmt0);
            this.m_grpDataPathConf.Controls.Add(this.m_cboDataCfgFmt1);
            this.m_grpDataPathConf.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_grpDataPathConf.Location = new System.Drawing.Point(19, 21);
            this.m_grpDataPathConf.Margin = new System.Windows.Forms.Padding(2);
            this.m_grpDataPathConf.Name = "m_grpDataPathConf";
            this.m_grpDataPathConf.Padding = new System.Windows.Forms.Padding(2);
            this.m_grpDataPathConf.Size = new System.Drawing.Size(565, 145);
            this.m_grpDataPathConf.TabIndex = 29;
            this.m_grpDataPathConf.TabStop = false;
            this.m_grpDataPathConf.Text = "Data Path Configuration";
            // 
            // m_cboDataPathCQConfig
            // 
            this.m_cboDataPathCQConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDataPathCQConfig.FormattingEnabled = true;
            this.m_cboDataPathCQConfig.Items.AddRange(new object[] {
            "12 Bit",
            "14 Bit",
            "16 Bit"});
            this.m_cboDataPathCQConfig.Location = new System.Drawing.Point(491, 20);
            this.m_cboDataPathCQConfig.Name = "m_cboDataPathCQConfig";
            this.m_cboDataPathCQConfig.Size = new System.Drawing.Size(64, 23);
            this.m_cboDataPathCQConfig.TabIndex = 37;
            // 
            // m_nudDataPathCQ2TransSize
            // 
            this.m_nudDataPathCQ2TransSize.Location = new System.Drawing.Point(492, 109);
            this.m_nudDataPathCQ2TransSize.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudDataPathCQ2TransSize.Name = "m_nudDataPathCQ2TransSize";
            this.m_nudDataPathCQ2TransSize.Size = new System.Drawing.Size(66, 21);
            this.m_nudDataPathCQ2TransSize.TabIndex = 36;
            this.m_nudDataPathCQ2TransSize.Value = new decimal(new int[] {
            72,
            0,
            0,
            0});
            // 
            // m_nudDataPathCQ1TransSize
            // 
            this.m_nudDataPathCQ1TransSize.Location = new System.Drawing.Point(492, 81);
            this.m_nudDataPathCQ1TransSize.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudDataPathCQ1TransSize.Name = "m_nudDataPathCQ1TransSize";
            this.m_nudDataPathCQ1TransSize.Size = new System.Drawing.Size(66, 21);
            this.m_nudDataPathCQ1TransSize.TabIndex = 35;
            this.m_nudDataPathCQ1TransSize.Value = new decimal(new int[] {
            132,
            0,
            0,
            0});
            // 
            // m_nudDataPathCQ0TransSize
            // 
            this.m_nudDataPathCQ0TransSize.Location = new System.Drawing.Point(492, 53);
            this.m_nudDataPathCQ0TransSize.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudDataPathCQ0TransSize.Name = "m_nudDataPathCQ0TransSize";
            this.m_nudDataPathCQ0TransSize.Size = new System.Drawing.Size(66, 21);
            this.m_nudDataPathCQ0TransSize.TabIndex = 34;
            this.m_nudDataPathCQ0TransSize.Value = new decimal(new int[] {
            132,
            0,
            0,
            0});
            // 
            // m_lblDataPathCQ2TransSize
            // 
            this.m_lblDataPathCQ2TransSize.AutoSize = true;
            this.m_lblDataPathCQ2TransSize.Location = new System.Drawing.Point(360, 113);
            this.m_lblDataPathCQ2TransSize.Name = "m_lblDataPathCQ2TransSize";
            this.m_lblDataPathCQ2TransSize.Size = new System.Drawing.Size(125, 15);
            this.m_lblDataPathCQ2TransSize.TabIndex = 32;
            this.m_lblDataPathCQ2TransSize.Text = "CQ2TransSize (16bit)";
            // 
            // m_lblDataPathCQ1TransSize
            // 
            this.m_lblDataPathCQ1TransSize.AutoSize = true;
            this.m_lblDataPathCQ1TransSize.Location = new System.Drawing.Point(360, 85);
            this.m_lblDataPathCQ1TransSize.Name = "m_lblDataPathCQ1TransSize";
            this.m_lblDataPathCQ1TransSize.Size = new System.Drawing.Size(125, 15);
            this.m_lblDataPathCQ1TransSize.TabIndex = 31;
            this.m_lblDataPathCQ1TransSize.Text = "CQ1TransSize (16bit)";
            // 
            // m_lblDataPathCQ0TransSize
            // 
            this.m_lblDataPathCQ0TransSize.AutoSize = true;
            this.m_lblDataPathCQ0TransSize.Location = new System.Drawing.Point(360, 58);
            this.m_lblDataPathCQ0TransSize.Name = "m_lblDataPathCQ0TransSize";
            this.m_lblDataPathCQ0TransSize.Size = new System.Drawing.Size(125, 15);
            this.m_lblDataPathCQ0TransSize.TabIndex = 30;
            this.m_lblDataPathCQ0TransSize.Text = "CQ0TransSize (16bit)";
            // 
            // m_lblDataPathCQConfig
            // 
            this.m_lblDataPathCQConfig.AutoSize = true;
            this.m_lblDataPathCQConfig.Location = new System.Drawing.Point(360, 29);
            this.m_lblDataPathCQConfig.Name = "m_lblDataPathCQConfig";
            this.m_lblDataPathCQConfig.Size = new System.Drawing.Size(47, 15);
            this.m_lblDataPathCQConfig.TabIndex = 29;
            this.m_lblDataPathCQConfig.Text = "CQ Cfg";
            // 
            // m_nudPkt1VChannelNo
            // 
            this.m_nudPkt1VChannelNo.Location = new System.Drawing.Point(238, 80);
            this.m_nudPkt1VChannelNo.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudPkt1VChannelNo.Name = "m_nudPkt1VChannelNo";
            this.m_nudPkt1VChannelNo.Size = new System.Drawing.Size(66, 21);
            this.m_nudPkt1VChannelNo.TabIndex = 28;
            // 
            // m_nudPkt0VChannelNo
            // 
            this.m_nudPkt0VChannelNo.Location = new System.Drawing.Point(238, 53);
            this.m_nudPkt0VChannelNo.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudPkt0VChannelNo.Name = "m_nudPkt0VChannelNo";
            this.m_nudPkt0VChannelNo.Size = new System.Drawing.Size(66, 21);
            this.m_nudPkt0VChannelNo.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Virtual Channel No";
            // 
            // m_btnDataPathCfg
            // 
            this.m_btnDataPathCfg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnDataPathCfg.ForeColor = System.Drawing.Color.Blue;
            this.m_btnDataPathCfg.Location = new System.Drawing.Point(223, 110);
            this.m_btnDataPathCfg.Margin = new System.Windows.Forms.Padding(2);
            this.m_btnDataPathCfg.Name = "m_btnDataPathCfg";
            this.m_btnDataPathCfg.Size = new System.Drawing.Size(83, 27);
            this.m_btnDataPathCfg.TabIndex = 4;
            this.m_btnDataPathCfg.Text = "Set";
            this.m_btnDataPathCfg.UseVisualStyleBackColor = true;
            // 
            // m_lblDataCfgTransConf0
            // 
            this.m_lblDataCfgTransConf0.AutoSize = true;
            this.m_lblDataCfgTransConf0.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblDataCfgTransConf0.Location = new System.Drawing.Point(4, 56);
            this.m_lblDataCfgTransConf0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_lblDataCfgTransConf0.Name = "m_lblDataCfgTransConf0";
            this.m_lblDataCfgTransConf0.Size = new System.Drawing.Size(54, 15);
            this.m_lblDataCfgTransConf0.TabIndex = 23;
            this.m_lblDataCfgTransConf0.Text = "Packet 0";
            // 
            // m_cboDataPathCfgPath
            // 
            this.m_cboDataPathCfgPath.DisplayMember = "Low";
            this.m_cboDataPathCfgPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDataPathCfgPath.FormattingEnabled = true;
            this.m_cboDataPathCfgPath.Items.AddRange(new object[] {
            "CSI2",
            "LVDS",
            "SPI"});
            this.m_cboDataPathCfgPath.Location = new System.Drawing.Point(109, 29);
            this.m_cboDataPathCfgPath.Margin = new System.Windows.Forms.Padding(2);
            this.m_cboDataPathCfgPath.Name = "m_cboDataPathCfgPath";
            this.m_cboDataPathCfgPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboDataPathCfgPath.Size = new System.Drawing.Size(105, 23);
            this.m_cboDataPathCfgPath.TabIndex = 1;
            // 
            // m_lblDataCfgPath
            // 
            this.m_lblDataCfgPath.AutoSize = true;
            this.m_lblDataCfgPath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblDataCfgPath.Location = new System.Drawing.Point(4, 29);
            this.m_lblDataCfgPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_lblDataCfgPath.Name = "m_lblDataCfgPath";
            this.m_lblDataCfgPath.Size = new System.Drawing.Size(61, 15);
            this.m_lblDataCfgPath.TabIndex = 21;
            this.m_lblDataCfgPath.Text = "Data Path";
            // 
            // m_lblDataCfgTransConf1
            // 
            this.m_lblDataCfgTransConf1.AutoSize = true;
            this.m_lblDataCfgTransConf1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblDataCfgTransConf1.Location = new System.Drawing.Point(4, 83);
            this.m_lblDataCfgTransConf1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_lblDataCfgTransConf1.Name = "m_lblDataCfgTransConf1";
            this.m_lblDataCfgTransConf1.Size = new System.Drawing.Size(54, 15);
            this.m_lblDataCfgTransConf1.TabIndex = 25;
            this.m_lblDataCfgTransConf1.Text = "Packet 1";
            // 
            // m_cboDataCfgFmt0
            // 
            this.m_cboDataCfgFmt0.DisplayMember = "Low";
            this.m_cboDataCfgFmt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDataCfgFmt0.FormattingEnabled = true;
            this.m_cboDataCfgFmt0.Items.AddRange(new object[] {
            "ADC_ONLY",
            "CP_ADC",
            "ADC_CP",
            "CP_ADC_CQ"});
            this.m_cboDataCfgFmt0.Location = new System.Drawing.Point(109, 56);
            this.m_cboDataCfgFmt0.Margin = new System.Windows.Forms.Padding(2);
            this.m_cboDataCfgFmt0.Name = "m_cboDataCfgFmt0";
            this.m_cboDataCfgFmt0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboDataCfgFmt0.Size = new System.Drawing.Size(105, 23);
            this.m_cboDataCfgFmt0.TabIndex = 2;
            // 
            // m_cboDataCfgFmt1
            // 
            this.m_cboDataCfgFmt1.DisplayMember = "Low";
            this.m_cboDataCfgFmt1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDataCfgFmt1.FormattingEnabled = true;
            this.m_cboDataCfgFmt1.Items.AddRange(new object[] {
            "Suppress Packet",
            "CP_CQ",
            "CQ_CP"});
            this.m_cboDataCfgFmt1.Location = new System.Drawing.Point(109, 83);
            this.m_cboDataCfgFmt1.Margin = new System.Windows.Forms.Padding(2);
            this.m_cboDataCfgFmt1.Name = "m_cboDataCfgFmt1";
            this.m_cboDataCfgFmt1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboDataCfgFmt1.Size = new System.Drawing.Size(105, 23);
            this.m_cboDataCfgFmt1.TabIndex = 3;
            // 
            // f00023c
            // 
            this.f00023c.Controls.Add(this.f00023d);
            this.f00023c.Controls.Add(this.m_lblLvdsDataRate);
            this.f00023c.Controls.Add(this.m_cboLvdsLaneClkCfg);
            this.f00023c.Controls.Add(this.f00023e);
            this.f00023c.Controls.Add(this.m_cboLvdsDataRate);
            this.f00023c.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f00023c.Location = new System.Drawing.Point(20, 172);
            this.f00023c.Margin = new System.Windows.Forms.Padding(2);
            this.f00023c.Name = "f00023c";
            this.f00023c.Padding = new System.Windows.Forms.Padding(2);
            this.f00023c.Size = new System.Drawing.Size(226, 140);
            this.f00023c.TabIndex = 31;
            this.f00023c.TabStop = false;
            this.f00023c.Text = "Clock Configuration";
            // 
            // f00023d
            // 
            this.f00023d.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f00023d.Location = new System.Drawing.Point(105, 109);
            this.f00023d.Margin = new System.Windows.Forms.Padding(2);
            this.f00023d.Name = "f00023d";
            this.f00023d.Size = new System.Drawing.Size(83, 27);
            this.f00023d.TabIndex = 7;
            this.f00023d.Text = "Set";
            this.f00023d.UseVisualStyleBackColor = true;
            // 
            // m_lblLvdsDataRate
            // 
            this.m_lblLvdsDataRate.AutoSize = true;
            this.m_lblLvdsDataRate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblLvdsDataRate.Location = new System.Drawing.Point(4, 77);
            this.m_lblLvdsDataRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_lblLvdsDataRate.Name = "m_lblLvdsDataRate";
            this.m_lblLvdsDataRate.Size = new System.Drawing.Size(62, 15);
            this.m_lblLvdsDataRate.TabIndex = 27;
            this.m_lblLvdsDataRate.Text = "Data Rate";
            // 
            // m_cboLvdsLaneClkCfg
            // 
            this.m_cboLvdsLaneClkCfg.DisplayMember = "Low";
            this.m_cboLvdsLaneClkCfg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboLvdsLaneClkCfg.FormattingEnabled = true;
            this.m_cboLvdsLaneClkCfg.Items.AddRange(new object[] {
            "SDR Clock",
            "DDR Clock"});
            this.m_cboLvdsLaneClkCfg.Location = new System.Drawing.Point(94, 42);
            this.m_cboLvdsLaneClkCfg.Margin = new System.Windows.Forms.Padding(2);
            this.m_cboLvdsLaneClkCfg.Name = "m_cboLvdsLaneClkCfg";
            this.m_cboLvdsLaneClkCfg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboLvdsLaneClkCfg.Size = new System.Drawing.Size(93, 23);
            this.m_cboLvdsLaneClkCfg.TabIndex = 5;
            // 
            // f00023e
            // 
            this.f00023e.AutoSize = true;
            this.f00023e.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f00023e.Location = new System.Drawing.Point(4, 42);
            this.f00023e.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.f00023e.Name = "f00023e";
            this.f00023e.Size = new System.Drawing.Size(69, 15);
            this.f00023e.TabIndex = 24;
            this.f00023e.Text = "Lane Clock";
            // 
            // m_cboLvdsDataRate
            // 
            this.m_cboLvdsDataRate.DisplayMember = "Low";
            this.m_cboLvdsDataRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboLvdsDataRate.FormattingEnabled = true;
            this.m_cboLvdsDataRate.Items.AddRange(new object[] {
            "900 Mbps",
            "600 Mbps",
            "450 Mbps",
            "400 Mbps",
            "300 Mbps",
            "225 Mbps",
            "150 Mbps"});
            this.m_cboLvdsDataRate.Location = new System.Drawing.Point(94, 77);
            this.m_cboLvdsDataRate.Margin = new System.Windows.Forms.Padding(2);
            this.m_cboLvdsDataRate.Name = "m_cboLvdsDataRate";
            this.m_cboLvdsDataRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboLvdsDataRate.Size = new System.Drawing.Size(93, 23);
            this.m_cboLvdsDataRate.TabIndex = 6;
            // 
            // f00023f
            // 
            this.f00023f.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f00023f.Location = new System.Drawing.Point(582, 512);
            this.f00023f.Margin = new System.Windows.Forms.Padding(2);
            this.f00023f.Name = "f00023f";
            this.f00023f.Size = new System.Drawing.Size(83, 27);
            this.f00023f.TabIndex = 16;
            this.f00023f.Text = "Set";
            this.f00023f.UseVisualStyleBackColor = true;
            // 
            // m_GroupCS2LaneConfig
            // 
            this.m_GroupCS2LaneConfig.Controls.Add(this.m_chkCSI2ClockPol);
            this.m_GroupCS2LaneConfig.Controls.Add(this.m_chkCSI2Lane3Pol);
            this.m_GroupCS2LaneConfig.Controls.Add(this.m_chkCSI2Lane2Pol);
            this.m_GroupCS2LaneConfig.Controls.Add(this.m_chkCSI2Lane1Pol);
            this.m_GroupCS2LaneConfig.Controls.Add(this.m_chkCSI2Lane0Pol);
            this.m_GroupCS2LaneConfig.Controls.Add(this.m_nudCSI2ClockPos);
            this.m_GroupCS2LaneConfig.Controls.Add(this.m_nudCSI2Lane3Pos);
            this.m_GroupCS2LaneConfig.Controls.Add(this.m_nudCSI2Lane2Pos);
            this.m_GroupCS2LaneConfig.Controls.Add(this.m_nudCSI2Lane1Pos);
            this.m_GroupCS2LaneConfig.Controls.Add(this.m_nudCSI2Lane0Pos);
            this.m_GroupCS2LaneConfig.Controls.Add(this.label12);
            this.m_GroupCS2LaneConfig.Controls.Add(this.label11);
            this.m_GroupCS2LaneConfig.Controls.Add(this.label10);
            this.m_GroupCS2LaneConfig.Controls.Add(this.label9);
            this.m_GroupCS2LaneConfig.Controls.Add(this.label8);
            this.m_GroupCS2LaneConfig.Controls.Add(this.label7);
            this.m_GroupCS2LaneConfig.Controls.Add(this.label6);
            this.m_GroupCS2LaneConfig.Controls.Add(this.label5);
            this.m_GroupCS2LaneConfig.Controls.Add(this.label4);
            this.m_GroupCS2LaneConfig.Controls.Add(this.label3);
            this.m_GroupCS2LaneConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_GroupCS2LaneConfig.Location = new System.Drawing.Point(253, 326);
            this.m_GroupCS2LaneConfig.Name = "m_GroupCS2LaneConfig";
            this.m_GroupCS2LaneConfig.Size = new System.Drawing.Size(434, 181);
            this.m_GroupCS2LaneConfig.TabIndex = 31;
            this.m_GroupCS2LaneConfig.TabStop = false;
            this.m_GroupCS2LaneConfig.Text = "CSI2 Lane Configuration";
            // 
            // m_chkCSI2ClockPol
            // 
            this.m_chkCSI2ClockPol.AutoSize = true;
            this.m_chkCSI2ClockPol.Location = new System.Drawing.Point(108, 151);
            this.m_chkCSI2ClockPol.Name = "m_chkCSI2ClockPol";
            this.m_chkCSI2ClockPol.Size = new System.Drawing.Size(95, 19);
            this.m_chkCSI2ClockPol.TabIndex = 19;
            this.m_chkCSI2ClockPol.Text = "+/- Pin Order";
            this.m_chkCSI2ClockPol.UseVisualStyleBackColor = true;
            // 
            // m_chkCSI2Lane3Pol
            // 
            this.m_chkCSI2Lane3Pol.AutoSize = true;
            this.m_chkCSI2Lane3Pol.Location = new System.Drawing.Point(305, 96);
            this.m_chkCSI2Lane3Pol.Name = "m_chkCSI2Lane3Pol";
            this.m_chkCSI2Lane3Pol.Size = new System.Drawing.Size(95, 19);
            this.m_chkCSI2Lane3Pol.TabIndex = 18;
            this.m_chkCSI2Lane3Pol.Text = "+/- Pin Order";
            this.m_chkCSI2Lane3Pol.UseVisualStyleBackColor = true;
            // 
            // m_chkCSI2Lane2Pol
            // 
            this.m_chkCSI2Lane2Pol.AutoSize = true;
            this.m_chkCSI2Lane2Pol.Location = new System.Drawing.Point(108, 96);
            this.m_chkCSI2Lane2Pol.Name = "m_chkCSI2Lane2Pol";
            this.m_chkCSI2Lane2Pol.Size = new System.Drawing.Size(95, 19);
            this.m_chkCSI2Lane2Pol.TabIndex = 17;
            this.m_chkCSI2Lane2Pol.Text = "+/- Pin Order";
            this.m_chkCSI2Lane2Pol.UseVisualStyleBackColor = true;
            // 
            // m_chkCSI2Lane1Pol
            // 
            this.m_chkCSI2Lane1Pol.AutoSize = true;
            this.m_chkCSI2Lane1Pol.Location = new System.Drawing.Point(305, 45);
            this.m_chkCSI2Lane1Pol.Name = "m_chkCSI2Lane1Pol";
            this.m_chkCSI2Lane1Pol.Size = new System.Drawing.Size(95, 19);
            this.m_chkCSI2Lane1Pol.TabIndex = 16;
            this.m_chkCSI2Lane1Pol.Text = "+/- Pin Order";
            this.m_chkCSI2Lane1Pol.UseVisualStyleBackColor = true;
            // 
            // m_chkCSI2Lane0Pol
            // 
            this.m_chkCSI2Lane0Pol.AutoSize = true;
            this.m_chkCSI2Lane0Pol.Location = new System.Drawing.Point(108, 46);
            this.m_chkCSI2Lane0Pol.Name = "m_chkCSI2Lane0Pol";
            this.m_chkCSI2Lane0Pol.Size = new System.Drawing.Size(95, 19);
            this.m_chkCSI2Lane0Pol.TabIndex = 15;
            this.m_chkCSI2Lane0Pol.Text = "+/- Pin Order";
            this.m_chkCSI2Lane0Pol.UseVisualStyleBackColor = true;
            // 
            // m_nudCSI2ClockPos
            // 
            this.m_nudCSI2ClockPos.Location = new System.Drawing.Point(16, 149);
            this.m_nudCSI2ClockPos.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_nudCSI2ClockPos.Name = "m_nudCSI2ClockPos";
            this.m_nudCSI2ClockPos.Size = new System.Drawing.Size(67, 21);
            this.m_nudCSI2ClockPos.TabIndex = 14;
            this.m_nudCSI2ClockPos.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // m_nudCSI2Lane3Pos
            // 
            this.m_nudCSI2Lane3Pos.Location = new System.Drawing.Point(209, 96);
            this.m_nudCSI2Lane3Pos.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudCSI2Lane3Pos.Name = "m_nudCSI2Lane3Pos";
            this.m_nudCSI2Lane3Pos.Size = new System.Drawing.Size(67, 21);
            this.m_nudCSI2Lane3Pos.TabIndex = 13;
            this.m_nudCSI2Lane3Pos.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // m_nudCSI2Lane2Pos
            // 
            this.m_nudCSI2Lane2Pos.Location = new System.Drawing.Point(16, 96);
            this.m_nudCSI2Lane2Pos.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudCSI2Lane2Pos.Name = "m_nudCSI2Lane2Pos";
            this.m_nudCSI2Lane2Pos.Size = new System.Drawing.Size(67, 21);
            this.m_nudCSI2Lane2Pos.TabIndex = 12;
            this.m_nudCSI2Lane2Pos.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // m_nudCSI2Lane1Pos
            // 
            this.m_nudCSI2Lane1Pos.Location = new System.Drawing.Point(209, 46);
            this.m_nudCSI2Lane1Pos.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudCSI2Lane1Pos.Name = "m_nudCSI2Lane1Pos";
            this.m_nudCSI2Lane1Pos.Size = new System.Drawing.Size(67, 21);
            this.m_nudCSI2Lane1Pos.TabIndex = 11;
            this.m_nudCSI2Lane1Pos.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // m_nudCSI2Lane0Pos
            // 
            this.m_nudCSI2Lane0Pos.Location = new System.Drawing.Point(16, 46);
            this.m_nudCSI2Lane0Pos.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudCSI2Lane0Pos.Name = "m_nudCSI2Lane0Pos";
            this.m_nudCSI2Lane0Pos.Size = new System.Drawing.Size(67, 21);
            this.m_nudCSI2Lane0Pos.TabIndex = 10;
            this.m_nudCSI2Lane0Pos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 15);
            this.label12.TabIndex = 9;
            this.label12.Text = "Clock Position";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(305, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "Lane3 Polarity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(209, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "Lane3 Position";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(106, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "Clock Polarity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(108, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Lane2 Polarity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Lane2 Position";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Lane1 Polarity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Lane1 Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Lane0 Polarity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lane0 Position";
            // 
            // f000240
            // 
            this.f000240.Controls.Add(this.label1);
            this.f000240.Controls.Add(this.f000241);
            this.f000240.Controls.Add(this.f000242);
            this.f000240.Controls.Add(this.f000243);
            this.f000240.Controls.Add(this.f000244);
            this.f000240.Controls.Add(this.m_lblLvdsLane);
            this.f000240.Controls.Add(this.m_cboLaneEnFormat);
            this.f000240.Controls.Add(this.f000245);
            this.f000240.Controls.Add(this.m_chbLvdsPacketEndPulse);
            this.f000240.Controls.Add(this.f000246);
            this.f000240.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f000240.Location = new System.Drawing.Point(19, 326);
            this.f000240.Margin = new System.Windows.Forms.Padding(2);
            this.f000240.Name = "f000240";
            this.f000240.Padding = new System.Windows.Forms.Padding(2);
            this.f000240.Size = new System.Drawing.Size(226, 181);
            this.f000240.TabIndex = 32;
            this.f000240.TabStop = false;
            this.f000240.Text = "LVDS Lane Configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 48;
            this.label1.Text = "Lane Format";
            // 
            // f000241
            // 
            this.f000241.AutoSize = true;
            this.f000241.Location = new System.Drawing.Point(165, 84);
            this.f000241.Name = "f000241";
            this.f000241.Size = new System.Drawing.Size(61, 19);
            this.f000241.TabIndex = 12;
            this.f000241.Text = "Lane4";
            this.f000241.UseVisualStyleBackColor = true;
            // 
            // f000242
            // 
            this.f000242.AutoSize = true;
            this.f000242.Location = new System.Drawing.Point(89, 84);
            this.f000242.Name = "f000242";
            this.f000242.Size = new System.Drawing.Size(61, 19);
            this.f000242.TabIndex = 11;
            this.f000242.Text = "Lane3";
            this.f000242.UseVisualStyleBackColor = true;
            // 
            // f000243
            // 
            this.f000243.AutoSize = true;
            this.f000243.Location = new System.Drawing.Point(165, 58);
            this.f000243.Name = "f000243";
            this.f000243.Size = new System.Drawing.Size(61, 19);
            this.f000243.TabIndex = 10;
            this.f000243.Text = "Lane2";
            this.f000243.UseVisualStyleBackColor = true;
            // 
            // f000244
            // 
            this.f000244.AutoSize = true;
            this.f000244.Location = new System.Drawing.Point(89, 59);
            this.f000244.Name = "f000244";
            this.f000244.Size = new System.Drawing.Size(61, 19);
            this.f000244.TabIndex = 9;
            this.f000244.Text = "Lane1";
            this.f000244.UseVisualStyleBackColor = true;
            // 
            // m_lblLvdsLane
            // 
            this.m_lblLvdsLane.AutoSize = true;
            this.m_lblLvdsLane.Location = new System.Drawing.Point(4, 71);
            this.m_lblLvdsLane.Name = "m_lblLvdsLane";
            this.m_lblLvdsLane.Size = new System.Drawing.Size(74, 15);
            this.m_lblLvdsLane.TabIndex = 43;
            this.m_lblLvdsLane.Text = "Lane Config";
            // 
            // m_cboLaneEnFormat
            // 
            this.m_cboLaneEnFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboLaneEnFormat.FormattingEnabled = true;
            this.m_cboLaneEnFormat.Items.AddRange(new object[] {
            "Format 0",
            "Format 1"});
            this.m_cboLaneEnFormat.Location = new System.Drawing.Point(94, 31);
            this.m_cboLaneEnFormat.Name = "m_cboLaneEnFormat";
            this.m_cboLaneEnFormat.Size = new System.Drawing.Size(93, 23);
            this.m_cboLaneEnFormat.TabIndex = 8;
            // 
            // f000245
            // 
            this.f000245.AutoSize = true;
            this.f000245.Location = new System.Drawing.Point(139, 107);
            this.f000245.Margin = new System.Windows.Forms.Padding(2);
            this.f000245.Name = "f000245";
            this.f000245.Size = new System.Drawing.Size(53, 19);
            this.f000245.TabIndex = 14;
            this.f000245.Text = "CRC";
            this.f000245.UseVisualStyleBackColor = true;
            // 
            // m_chbLvdsPacketEndPulse
            // 
            this.m_chbLvdsPacketEndPulse.AutoSize = true;
            this.m_chbLvdsPacketEndPulse.Location = new System.Drawing.Point(8, 130);
            this.m_chbLvdsPacketEndPulse.Margin = new System.Windows.Forms.Padding(2);
            this.m_chbLvdsPacketEndPulse.Name = "m_chbLvdsPacketEndPulse";
            this.m_chbLvdsPacketEndPulse.Size = new System.Drawing.Size(123, 19);
            this.m_chbLvdsPacketEndPulse.TabIndex = 15;
            this.m_chbLvdsPacketEndPulse.Text = "Packet End Pulse";
            this.m_chbLvdsPacketEndPulse.UseVisualStyleBackColor = true;
            // 
            // f000246
            // 
            this.f000246.AutoSize = true;
            this.f000246.Checked = true;
            this.f000246.CheckState = System.Windows.Forms.CheckState.Checked;
            this.f000246.Location = new System.Drawing.Point(8, 107);
            this.f000246.Margin = new System.Windows.Forms.Padding(2);
            this.f000246.Name = "f000246";
            this.f000246.Size = new System.Drawing.Size(78, 19);
            this.f000246.TabIndex = 13;
            this.f000246.Text = "MSB First";
            this.f000246.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f000240);
            this.groupBox1.Controls.Add(this.m_GroupCS2LaneConfig);
            this.groupBox1.Controls.Add(this.f00023f);
            this.groupBox1.Controls.Add(this.m_grpDataPathConf);
            this.groupBox1.Controls.Add(this.f00023c);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 567);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Configuration";
            // 
            // m_grpMSSTestPatternGenConfig
            // 
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_chkTestPatternGenCtl);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudNumTestPatternPkts);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternPktSize);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label26);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label25);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label24);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label23);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_btnTestPatternGeneratedCfg);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx3QCFG3);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx3QCFG);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label19);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx3ICFG3);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx3ICFG);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label20);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx2QCFG2);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx2QCFG);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label21);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx2ICFG2);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx2ICFG);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label22);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx1QCFG1);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx1QCFG);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label17);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx1ICFG1);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx1ICFG);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label18);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx0QCFG0);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx0QCFG);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label16);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx0ICFG0);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternRx0ICFG);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label15);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.m_nudTestPatternGenTiming);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label14);
            this.m_grpMSSTestPatternGenConfig.Controls.Add(this.label13);
            this.m_grpMSSTestPatternGenConfig.Location = new System.Drawing.Point(720, 3);
            this.m_grpMSSTestPatternGenConfig.Name = "m_grpMSSTestPatternGenConfig";
            this.m_grpMSSTestPatternGenConfig.Size = new System.Drawing.Size(316, 404);
            this.m_grpMSSTestPatternGenConfig.TabIndex = 34;
            this.m_grpMSSTestPatternGenConfig.TabStop = false;
            this.m_grpMSSTestPatternGenConfig.Text = "Test Pattern Generator Configuration";
            // 
            // m_chkTestPatternGenCtl
            // 
            this.m_chkTestPatternGenCtl.Location = new System.Drawing.Point(132, 16);
            this.m_chkTestPatternGenCtl.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_chkTestPatternGenCtl.Name = "m_chkTestPatternGenCtl";
            this.m_chkTestPatternGenCtl.Size = new System.Drawing.Size(67, 20);
            this.m_chkTestPatternGenCtl.TabIndex = 35;
            // 
            // m_nudNumTestPatternPkts
            // 
            this.m_nudNumTestPatternPkts.Location = new System.Drawing.Point(132, 90);
            this.m_nudNumTestPatternPkts.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.m_nudNumTestPatternPkts.Name = "m_nudNumTestPatternPkts";
            this.m_nudNumTestPatternPkts.Size = new System.Drawing.Size(67, 20);
            this.m_nudNumTestPatternPkts.TabIndex = 34;
            // 
            // m_nudTestPatternPktSize
            // 
            this.m_nudTestPatternPktSize.Location = new System.Drawing.Point(132, 64);
            this.m_nudTestPatternPktSize.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternPktSize.Name = "m_nudTestPatternPktSize";
            this.m_nudTestPatternPktSize.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternPktSize.TabIndex = 33;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(4, 95);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(111, 13);
            this.label26.TabIndex = 32;
            this.label26.Text = "Num TestPattern Pkts";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 69);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(104, 13);
            this.label25.TabIndex = 31;
            this.label25.Text = "TestPattern Pkt Size";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(212, 113);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(95, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "Value to be Added";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(130, 114);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 13);
            this.label23.TabIndex = 29;
            this.label23.Text = "Start Offset";
            // 
            // m_btnTestPatternGeneratedCfg
            // 
            this.m_btnTestPatternGeneratedCfg.Location = new System.Drawing.Point(210, 341);
            this.m_btnTestPatternGeneratedCfg.Name = "m_btnTestPatternGeneratedCfg";
            this.m_btnTestPatternGeneratedCfg.Size = new System.Drawing.Size(75, 29);
            this.m_btnTestPatternGeneratedCfg.TabIndex = 28;
            this.m_btnTestPatternGeneratedCfg.Text = "Set";
            this.m_btnTestPatternGeneratedCfg.UseVisualStyleBackColor = true;
            // 
            // m_nudTestPatternRx3QCFG3
            // 
            this.m_nudTestPatternRx3QCFG3.Location = new System.Drawing.Point(215, 315);
            this.m_nudTestPatternRx3QCFG3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx3QCFG3.Name = "m_nudTestPatternRx3QCFG3";
            this.m_nudTestPatternRx3QCFG3.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx3QCFG3.TabIndex = 27;
            // 
            // m_nudTestPatternRx3QCFG
            // 
            this.m_nudTestPatternRx3QCFG.Location = new System.Drawing.Point(132, 315);
            this.m_nudTestPatternRx3QCFG.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx3QCFG.Name = "m_nudTestPatternRx3QCFG";
            this.m_nudTestPatternRx3QCFG.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx3QCFG.TabIndex = 26;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 322);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 13);
            this.label19.TabIndex = 25;
            this.label19.Text = "TestPattern Rx3 QCFG";
            // 
            // m_nudTestPatternRx3ICFG3
            // 
            this.m_nudTestPatternRx3ICFG3.Location = new System.Drawing.Point(215, 289);
            this.m_nudTestPatternRx3ICFG3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx3ICFG3.Name = "m_nudTestPatternRx3ICFG3";
            this.m_nudTestPatternRx3ICFG3.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx3ICFG3.TabIndex = 24;
            // 
            // m_nudTestPatternRx3ICFG
            // 
            this.m_nudTestPatternRx3ICFG.Location = new System.Drawing.Point(132, 289);
            this.m_nudTestPatternRx3ICFG.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx3ICFG.Name = "m_nudTestPatternRx3ICFG";
            this.m_nudTestPatternRx3ICFG.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx3ICFG.TabIndex = 23;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 296);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 13);
            this.label20.TabIndex = 22;
            this.label20.Text = "TestPattern Rx3 ICFG";
            // 
            // m_nudTestPatternRx2QCFG2
            // 
            this.m_nudTestPatternRx2QCFG2.Location = new System.Drawing.Point(215, 263);
            this.m_nudTestPatternRx2QCFG2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx2QCFG2.Name = "m_nudTestPatternRx2QCFG2";
            this.m_nudTestPatternRx2QCFG2.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx2QCFG2.TabIndex = 21;
            // 
            // m_nudTestPatternRx2QCFG
            // 
            this.m_nudTestPatternRx2QCFG.Location = new System.Drawing.Point(132, 263);
            this.m_nudTestPatternRx2QCFG.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx2QCFG.Name = "m_nudTestPatternRx2QCFG";
            this.m_nudTestPatternRx2QCFG.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx2QCFG.TabIndex = 20;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(4, 270);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(116, 13);
            this.label21.TabIndex = 19;
            this.label21.Text = "TestPattern Rx2 QCFG";
            // 
            // m_nudTestPatternRx2ICFG2
            // 
            this.m_nudTestPatternRx2ICFG2.Location = new System.Drawing.Point(215, 237);
            this.m_nudTestPatternRx2ICFG2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx2ICFG2.Name = "m_nudTestPatternRx2ICFG2";
            this.m_nudTestPatternRx2ICFG2.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx2ICFG2.TabIndex = 18;
            // 
            // m_nudTestPatternRx2ICFG
            // 
            this.m_nudTestPatternRx2ICFG.Location = new System.Drawing.Point(132, 237);
            this.m_nudTestPatternRx2ICFG.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx2ICFG.Name = "m_nudTestPatternRx2ICFG";
            this.m_nudTestPatternRx2ICFG.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx2ICFG.TabIndex = 17;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 244);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(111, 13);
            this.label22.TabIndex = 16;
            this.label22.Text = "TestPattern Rx2 ICFG";
            // 
            // m_nudTestPatternRx1QCFG1
            // 
            this.m_nudTestPatternRx1QCFG1.Location = new System.Drawing.Point(215, 211);
            this.m_nudTestPatternRx1QCFG1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx1QCFG1.Name = "m_nudTestPatternRx1QCFG1";
            this.m_nudTestPatternRx1QCFG1.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx1QCFG1.TabIndex = 15;
            // 
            // m_nudTestPatternRx1QCFG
            // 
            this.m_nudTestPatternRx1QCFG.Location = new System.Drawing.Point(132, 211);
            this.m_nudTestPatternRx1QCFG.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx1QCFG.Name = "m_nudTestPatternRx1QCFG";
            this.m_nudTestPatternRx1QCFG.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx1QCFG.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 218);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(116, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "TestPattern Rx1 QCFG";
            // 
            // m_nudTestPatternRx1ICFG1
            // 
            this.m_nudTestPatternRx1ICFG1.Location = new System.Drawing.Point(215, 185);
            this.m_nudTestPatternRx1ICFG1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx1ICFG1.Name = "m_nudTestPatternRx1ICFG1";
            this.m_nudTestPatternRx1ICFG1.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx1ICFG1.TabIndex = 12;
            // 
            // m_nudTestPatternRx1ICFG
            // 
            this.m_nudTestPatternRx1ICFG.Location = new System.Drawing.Point(132, 185);
            this.m_nudTestPatternRx1ICFG.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx1ICFG.Name = "m_nudTestPatternRx1ICFG";
            this.m_nudTestPatternRx1ICFG.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx1ICFG.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 190);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(111, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "TestPattern Rx1 ICFG";
            // 
            // m_nudTestPatternRx0QCFG0
            // 
            this.m_nudTestPatternRx0QCFG0.Location = new System.Drawing.Point(215, 159);
            this.m_nudTestPatternRx0QCFG0.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx0QCFG0.Name = "m_nudTestPatternRx0QCFG0";
            this.m_nudTestPatternRx0QCFG0.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx0QCFG0.TabIndex = 9;
            // 
            // m_nudTestPatternRx0QCFG
            // 
            this.m_nudTestPatternRx0QCFG.Location = new System.Drawing.Point(132, 159);
            this.m_nudTestPatternRx0QCFG.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx0QCFG.Name = "m_nudTestPatternRx0QCFG";
            this.m_nudTestPatternRx0QCFG.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx0QCFG.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 164);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "TestPattern Rx0 QCFG";
            // 
            // m_nudTestPatternRx0ICFG0
            // 
            this.m_nudTestPatternRx0ICFG0.Location = new System.Drawing.Point(215, 133);
            this.m_nudTestPatternRx0ICFG0.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx0ICFG0.Name = "m_nudTestPatternRx0ICFG0";
            this.m_nudTestPatternRx0ICFG0.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx0ICFG0.TabIndex = 6;
            // 
            // m_nudTestPatternRx0ICFG
            // 
            this.m_nudTestPatternRx0ICFG.Location = new System.Drawing.Point(132, 133);
            this.m_nudTestPatternRx0ICFG.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.m_nudTestPatternRx0ICFG.Name = "m_nudTestPatternRx0ICFG";
            this.m_nudTestPatternRx0ICFG.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternRx0ICFG.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 138);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "TestPattern Rx0 ICFG";
            // 
            // m_nudTestPatternGenTiming
            // 
            this.m_nudTestPatternGenTiming.Location = new System.Drawing.Point(132, 38);
            this.m_nudTestPatternGenTiming.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_nudTestPatternGenTiming.Name = "m_nudTestPatternGenTiming";
            this.m_nudTestPatternGenTiming.Size = new System.Drawing.Size(67, 20);
            this.m_nudTestPatternGenTiming.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "TestPattern Gen Timing";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "TestPattern Gen Ctl";
            // 
            // DataConfigTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_grpMSSTestPatternGenConfig);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "DataConfigTab";
            this.Size = new System.Drawing.Size(1067, 584);
            this.m_grpDataPathConf.ResumeLayout(false);
            this.m_grpDataPathConf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathCQ2TransSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathCQ1TransSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudDataPathCQ0TransSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPkt1VChannelNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudPkt0VChannelNo)).EndInit();
            this.f00023c.ResumeLayout(false);
            this.f00023c.PerformLayout();
            this.m_GroupCS2LaneConfig.ResumeLayout(false);
            this.m_GroupCS2LaneConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudCSI2ClockPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudCSI2Lane3Pos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudCSI2Lane2Pos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudCSI2Lane1Pos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudCSI2Lane0Pos)).EndInit();
            this.f000240.ResumeLayout(false);
            this.f000240.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.m_grpMSSTestPatternGenConfig.ResumeLayout(false);
            this.m_grpMSSTestPatternGenConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_chkTestPatternGenCtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudNumTestPatternPkts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternPktSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx3QCFG3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx3QCFG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx3ICFG3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx3ICFG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx2QCFG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx2QCFG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx2ICFG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx2ICFG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx1QCFG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx1QCFG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx1ICFG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx1ICFG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx0QCFG0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx0QCFG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx0ICFG0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternRx0ICFG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTestPatternGenTiming)).EndInit();
            this.ResumeLayout(false);

		}

		private void PostInitialization()
		{
			m_cboLaneEnFormat.SelectedIndex = 0;
			f000244.Checked = true;
			f000243.Checked = true;
			f000242.Checked = true;
			f000241.Checked = true;
			m_cboLvdsLaneClkCfg.SelectedIndex = 1;
			m_cboLvdsDataRate.SelectedIndex = 1;
			m_cboDataCfgFmt1.SelectedIndex = 0;
			m_cboDataCfgFmt0.SelectedIndex = 0;
			m_cboDataPathCfgPath.SelectedIndex = 1;
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;
		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;
		private frmAR1Main m_MainForm;
		private DataConfigParams m_DataConfigParams;
		private TestPatternGenConfigParams m_TestPatternGenConfigParams;

		private string[] comboBoxRangeA = new string[]
		{
			"900 Mbps",
			"600 Mbps",
			"450 Mbps",
			"400 Mbps",
			"300 Mbps",
			"225 Mbps",
			"150 Mbps"
		};

		private string[] comboBoxRangeB = new string[]
		{
			"450 Mbps",
			"300 Mbps",
			"150 Mbps"
		};

		private IContainer components;
		private GroupBox m_grpDataPathConf;
		private Button m_btnDataPathCfg;
		private Label m_lblDataCfgTransConf0;
		private ComboBox m_cboDataPathCfgPath;
		private Label m_lblDataCfgPath;
		private Label m_lblDataCfgTransConf1;
		private ComboBox m_cboDataCfgFmt0;
		private ComboBox m_cboDataCfgFmt1;
		private Label label2;
		private NumericUpDown m_nudPkt1VChannelNo;
		private NumericUpDown m_nudPkt0VChannelNo;
		private GroupBox m_GroupCS2LaneConfig;
		private CheckBox m_chkCSI2ClockPol;
		private CheckBox m_chkCSI2Lane3Pol;
		private CheckBox m_chkCSI2Lane2Pol;
		private CheckBox m_chkCSI2Lane1Pol;
		private CheckBox m_chkCSI2Lane0Pol;
		private NumericUpDown m_nudCSI2ClockPos;
		private NumericUpDown m_nudCSI2Lane3Pos;
		private NumericUpDown m_nudCSI2Lane2Pos;
		private NumericUpDown m_nudCSI2Lane1Pos;
		private NumericUpDown m_nudCSI2Lane0Pos;
		private Label label12;
		private Label label11;
		private Label label10;
		private Label label9;
		private Label label8;
		private Label label7;
		private Label label6;
		private Label label5;
		private Label label4;
		private Label label3;
		private GroupBox f00023c;
		private Button f00023d;
		private Label m_lblLvdsDataRate;
		private ComboBox m_cboLvdsLaneClkCfg;
		private Label f00023e;
		private ComboBox m_cboLvdsDataRate;
		private Button f00023f;
		private GroupBox f000240;
		private Label label1;
		private CheckBox f000241;
		private CheckBox f000242;
		private CheckBox f000243;
		private CheckBox f000244;
		private Label m_lblLvdsLane;
		private ComboBox m_cboLaneEnFormat;
		private CheckBox f000245;
		private CheckBox m_chbLvdsPacketEndPulse;
		private CheckBox f000246;
		private GroupBox groupBox1;
		private GroupBox m_grpMSSTestPatternGenConfig;
		private Button m_btnTestPatternGeneratedCfg;
		private NumericUpDown m_nudTestPatternRx3QCFG3;
		private NumericUpDown m_nudTestPatternRx3QCFG;
		private Label label19;
		private NumericUpDown m_nudTestPatternRx3ICFG3;
		private NumericUpDown m_nudTestPatternRx3ICFG;
		private Label label20;
		private NumericUpDown m_nudTestPatternRx2QCFG2;
		private NumericUpDown m_nudTestPatternRx2QCFG;
		private Label label21;
		private NumericUpDown m_nudTestPatternRx2ICFG2;
		private NumericUpDown m_nudTestPatternRx2ICFG;
		private Label label22;
		private NumericUpDown m_nudTestPatternRx1QCFG1;
		private NumericUpDown m_nudTestPatternRx1QCFG;
		private Label label17;
		private NumericUpDown m_nudTestPatternRx1ICFG1;
		private NumericUpDown m_nudTestPatternRx1ICFG;
		private Label label18;
		private NumericUpDown m_nudTestPatternRx0QCFG0;
		private NumericUpDown m_nudTestPatternRx0QCFG;
		private Label label16;
		private NumericUpDown m_nudTestPatternRx0ICFG0;
		private NumericUpDown m_nudTestPatternRx0ICFG;
		private Label label15;
		private NumericUpDown m_nudTestPatternGenTiming;
		private Label label14;
		private Label label13;
		private Label label24;
		private Label label23;
		private NumericUpDown m_nudNumTestPatternPkts;
		private NumericUpDown m_nudTestPatternPktSize;
		private Label label26;
		private Label label25;
		private Label m_lblDataPathCQ0TransSize;
		private Label m_lblDataPathCQConfig;
		private Label m_lblDataPathCQ1TransSize;
		private Label m_lblDataPathCQ2TransSize;
		private NumericUpDown m_nudDataPathCQ2TransSize;
		private NumericUpDown m_nudDataPathCQ1TransSize;
		private NumericUpDown m_nudDataPathCQ0TransSize;
		private ComboBox m_cboDataPathCQConfig;
		private NumericUpDown m_chkTestPatternGenCtl;
	}
}
