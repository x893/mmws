using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace AR1xController
{
	public class PMICTab : UserControl
	{
		public PMICTab()
		{
			InitializeComponent();
			m_MainForm = m_GuiManager.MainTsForm;
			f0001fc = m_GuiManager.TsParams.PMICVoltageConfigParams;
			m_SetPMICRegConfigParams = m_GuiManager.TsParams.SetPMICRegConfigParams;
			m_GetPMICRegConfigParams = m_GuiManager.TsParams.GetPMICRegConfigParams;
		}

		public bool UpdatePMICGetConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdatePMICGetConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				f0001fc.f0004ed = (m_RadioBtnBuckVol0Value.Checked ? 1 : 0);
				f0001fc.f0004ee = (m_RadioBtnBuckVol1Value.Checked ? 1 : 0);
				f0001fc.f0004ef = (m_RadioBtnBuckVol2Value.Checked ? 1 : 0);
				f0001fc.f0004f0 = (m_RadioBtnBuckVol3Value.Checked ? 1 : 0);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetPMICVolConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iGetPMICBuckVoltageConfig_Gui(is_starting_op, is_ending_op);
		}

		private void m000044()
		{
			iSetPMICVolConfig_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetPMICVolConfigAsync()
		{
			new del_v_v(m000044).BeginInvoke(null, null);
		}

		private void m000045(object sender, EventArgs p1)
		{
			iSetPMICVolConfigAsync();
		}

		public void m000046(string BuckV0)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new del_v_s(m000046), BuckV0);
				return;
			}
			m_lblBuckVol0Value.Text = Convert.ToString(GetPMICBuckVoltageValueFromCode(Convert.ToByte(BuckV0)));
		}

		public void m000047(string BuckV1)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new del_v_s(m000047), BuckV1);
				return;
			}
			m_lblBuckVol1Value.Text = Convert.ToString(GetPMICBuckVoltageValueFromCode(Convert.ToByte(BuckV1)));
		}

		public void m000048(string BuckV2)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new del_v_s(m000048), BuckV2);
				return;
			}
			m_lblBuckVol2Value.Text = Convert.ToString(GetPMICBuckVoltageValueFromCode(Convert.ToByte(BuckV2)));
		}

		public void m000049(string BuckV3)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new del_v_s(m000049), BuckV3);
				return;
			}
			m_lblBuckVol3Value.Text = Convert.ToString(GetPMICBuckVoltageValueFromCode(Convert.ToByte(BuckV3)));
		}

		public string GetPMICBuckVoltageValueFromDict(int readBuckEnabled, string BuckV2)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("0", "0.5");
			dictionary.Add("1", "0.51");
			dictionary.Add("2", "0.52");
			dictionary.Add("3", "0.53");
			dictionary.Add("4", "0.54");
			dictionary.Add("5", "0.55");
			dictionary.Add("6", "0.56");
			dictionary.Add("7", "0.57");
			dictionary.Add("8", "0.58");
			dictionary.Add("9", "0.59");
			dictionary.Add("A", "0.6");
			dictionary.Add("B", "0.61");
			dictionary.Add("C", "0.62");
			dictionary.Add("D", "0.63");
			dictionary.Add("E", "0.64");
			dictionary.Add("F", "0.65");
			dictionary.Add("10", "0.66");
			dictionary.Add("11", "0.67");
			dictionary.Add("12", "0.68");
			dictionary.Add("13", "0.69");
			dictionary.Add("14", "0.7");
			dictionary.Add("15", "0.71");
			dictionary.Add("16", "0.72");
			dictionary.Add("17", "0.73");
			dictionary.Add("18", "0.735");
			dictionary.Add("19", "0.74");
			dictionary.Add("1A", "0.745");
			dictionary.Add("1B", "0.75");
			dictionary.Add("1C", "0.755");
			dictionary.Add("1D", "0.76");
			dictionary.Add("1E", "0.765");
			dictionary.Add("1F", "0.77");
			dictionary.Add("20", "0.775");
			dictionary.Add("21", "0.78");
			dictionary.Add("22", "0.785");
			dictionary.Add("23", "0.79");
			dictionary.Add("24", "0.795");
			dictionary.Add("25", "0.8");
			dictionary.Add("26", "0.805");
			dictionary.Add("27", "0.81");
			dictionary.Add("28", "0.815");
			dictionary.Add("29", "0.82");
			dictionary.Add("2A", "0.825");
			dictionary.Add("2B", "0.83");
			dictionary.Add("2C", "0.835");
			dictionary.Add("2D", "0.84");
			dictionary.Add("2E", "0.845");
			dictionary.Add("2F", "0.85");
			dictionary.Add("30", "0.855");
			dictionary.Add("31", "0.86");
			dictionary.Add("32", "0.865");
			dictionary.Add("33", "0.87");
			dictionary.Add("34", "0.875");
			dictionary.Add("35", "0.88");
			dictionary.Add("36", "0.885");
			dictionary.Add("37", "0.89");
			dictionary.Add("38", "0.895");
			dictionary.Add("39", "0.9");
			dictionary.Add("3A", "0.905");
			dictionary.Add("3B", "0.91");
			dictionary.Add("3C", "0.915");
			dictionary.Add("3D", "0.92");
			dictionary.Add("3E", "0.925");
			dictionary.Add("3F", "0.93");
			dictionary.Add("40", "0.935");
			dictionary.Add("41", "0.94");
			dictionary.Add("42", "0.945");
			dictionary.Add("43", "0.95");
			dictionary.Add("44", "0.955");
			dictionary.Add("45", "0.96");
			dictionary.Add("46", "0.965");
			dictionary.Add("47", "0.97");
			dictionary.Add("48", "0.975");
			dictionary.Add("49", "0.98");
			dictionary.Add("4A", "0.985");
			dictionary.Add("4B", "0.99");
			dictionary.Add("4C", "0.995");
			dictionary.Add("4D", "1");
			dictionary.Add("4E", "1.005");
			dictionary.Add("4F", "1.01");
			dictionary.Add("50", "1.015");
			dictionary.Add("51", "1.02");
			dictionary.Add("52", "1.025");
			dictionary.Add("53", "1.03");
			dictionary.Add("54", "1.035");
			dictionary.Add("55", "1.04");
			dictionary.Add("56", "1.045");
			dictionary.Add("57", "1.05");
			dictionary.Add("58", "1.055");
			dictionary.Add("59", "1.06");
			dictionary.Add("5A", "1.065");
			dictionary.Add("5B", "1.07");
			dictionary.Add("5C", "1.075");
			dictionary.Add("5D", "1.08");
			dictionary.Add("5E", "1.085");
			dictionary.Add("5F", "1.09");
			dictionary.Add("60", "1.095");
			dictionary.Add("61", "1.1");
			dictionary.Add("62", "1.105");
			dictionary.Add("63", "1.11");
			dictionary.Add("64", "1.115");
			dictionary.Add("65", "1.12");
			dictionary.Add("66", "1.125");
			dictionary.Add("67", "1.13");
			dictionary.Add("68", "1.135");
			dictionary.Add("69", "1.14");
			dictionary.Add("6A", "1.145");
			dictionary.Add("6B", "1.15");
			dictionary.Add("6C", "1.155");
			dictionary.Add("6D", "1.16");
			dictionary.Add("6E", "1.165");
			dictionary.Add("6F", "1.17");
			dictionary.Add("70", "1.175");
			dictionary.Add("71", "1.18");
			dictionary.Add("72", "1.185");
			dictionary.Add("73", "1.19");
			dictionary.Add("74", "1.195");
			dictionary.Add("75", "1.2");
			dictionary.Add("76", "1.205");
			dictionary.Add("77", "1.21");
			dictionary.Add("78", "1.215");
			dictionary.Add("79", "1.22");
			dictionary.Add("7A", "1.225");
			dictionary.Add("7B", "1.23");
			dictionary.Add("7C", "1.235");
			dictionary.Add("7D", "1.24");
			dictionary.Add("7E", "1.245");
			dictionary.Add("7F", "1.25");
			dictionary.Add("80", "1.255");
			dictionary.Add("81", "1.26");
			dictionary.Add("82", "1.265");
			dictionary.Add("83", "1.27");
			dictionary.Add("84", "1.275");
			dictionary.Add("85", "1.28");
			dictionary.Add("86", "1.285");
			dictionary.Add("87", "1.29");
			dictionary.Add("88", "1.295");
			dictionary.Add("89", "1.3");
			dictionary.Add("8A", "1.305");
			dictionary.Add("8B", "1.31");
			dictionary.Add("8C", "1.315");
			dictionary.Add("8D", "1.32");
			dictionary.Add("8E", "1.325");
			dictionary.Add("8F", "1.33");
			dictionary.Add("90", "1.335");
			dictionary.Add("91", "1.34");
			dictionary.Add("92", "1.345");
			dictionary.Add("93", "1.35");
			dictionary.Add("94", "1.355");
			dictionary.Add("95", "1.36");
			dictionary.Add("96", "1.365");
			dictionary.Add("97", "1.37");
			dictionary.Add("98", "1.375");
			dictionary.Add("99", "1.38");
			dictionary.Add("9A", "1.385");
			dictionary.Add("9B", "1.39");
			dictionary.Add("9C", "1.395");
			dictionary.Add("9D", "1.4");
			dictionary.Add("9E", "1.42");
			dictionary.Add("9F", "1.44");
			dictionary.Add("A0", "1.46");
			dictionary.Add("A1", "1.48");
			dictionary.Add("A2", "1.5");
			dictionary.Add("A3", "1.52");
			dictionary.Add("A4", "1.54");
			dictionary.Add("A5", "1.56");
			dictionary.Add("A6", "1.58");
			dictionary.Add("A7", "1.6");
			dictionary.Add("A8", "1.62");
			dictionary.Add("A9", "1.64");
			dictionary.Add("AA", "1.66");
			dictionary.Add("AB", "1.68");
			dictionary.Add("AC", "1.7");
			dictionary.Add("AD", "1.72");
			dictionary.Add("AE", "1.74");
			dictionary.Add("AF", "1.76");
			dictionary.Add("B0", "1.78");
			dictionary.Add("B1", "1.8");
			dictionary.Add("B2", "1.82");
			dictionary.Add("B3", "1.84");
			dictionary.Add("B4", "1.86");
			dictionary.Add("B5", "1.88");
			dictionary.Add("B6", "1.9");
			dictionary.Add("B7", "1.92");
			dictionary.Add("B8", "1.94");
			dictionary.Add("B9", "1.96");
			dictionary.Add("BA", "1.98");
			dictionary.Add("BB", "2");
			dictionary.Add("BC", "2.02");
			dictionary.Add("BD", "2.04");
			dictionary.Add("BE", "2.06");
			dictionary.Add("BF", "2.08");
			dictionary.Add("C0", "2.1");
			dictionary.Add("C1", "2.12");
			dictionary.Add("C2", "2.14");
			dictionary.Add("C3", "2.16");
			dictionary.Add("C4", "2.18");
			dictionary.Add("C5", "2.2");
			dictionary.Add("C6", "2.22");
			dictionary.Add("C7", "2.24");
			dictionary.Add("C8", "2.26");
			dictionary.Add("C9", "2.28");
			dictionary.Add("CA", "2.3");
			dictionary.Add("CB", "2.32");
			dictionary.Add("CC", "2.34");
			dictionary.Add("CD", "2.36");
			dictionary.Add("CE", "2.38");
			dictionary.Add("CF", "2.4");
			dictionary.Add("D0", "2.42");
			dictionary.Add("D1", "2.44");
			dictionary.Add("D2", "2.46");
			dictionary.Add("D3", "2.48");
			dictionary.Add("D4", "2.5");
			dictionary.Add("D5", "2.52");
			dictionary.Add("D6", "2.54");
			dictionary.Add("D7", "2.56");
			dictionary.Add("D8", "2.58");
			dictionary.Add("D9", "2.6");
			dictionary.Add("DA", "2.62");
			dictionary.Add("DB", "2.64");
			dictionary.Add("DC", "2.66");
			dictionary.Add("DD", "2.68");
			dictionary.Add("DE", "2.7");
			dictionary.Add("DF", "2.72");
			dictionary.Add("E0", "2.74");
			dictionary.Add("E1", "2.76");
			dictionary.Add("E2", "2.78");
			dictionary.Add("E3", "2.8");
			dictionary.Add("E4", "2.82");
			dictionary.Add("E5", "2.84");
			dictionary.Add("E6", "2.86");
			dictionary.Add("E7", "2.88");
			dictionary.Add("E8", "2.9");
			dictionary.Add("E9", "2.92");
			dictionary.Add("EA", "2.94");
			dictionary.Add("EB", "2.96");
			dictionary.Add("EC", "2.98");
			dictionary.Add("ED", "3");
			dictionary.Add("EE", "3.02");
			dictionary.Add("EF", "3.04");
			dictionary.Add("F0", "3.06");
			dictionary.Add("F1", "3.08");
			dictionary.Add("F2", "3.1");
			dictionary.Add("F3", "3.12");
			dictionary.Add("F4", "3.14");
			dictionary.Add("F5", "3.16");
			dictionary.Add("F6", "3.18");
			dictionary.Add("F7", "3.2");
			dictionary.Add("F8", "3.22");
			dictionary.Add("F9", "3.24");
			dictionary.Add("FA", "3.26");
			dictionary.Add("FB", "3.28");
			dictionary.Add("FC", "3.3");
			dictionary.Add("FD", "3.32");
			dictionary.Add("FE", "3.34");
			dictionary.Add("FF", "3.36");
			string result = string.Empty;
			if (readBuckEnabled == 0)
			{
				string key = int.Parse(BuckV2).ToString("X");
				dictionary.TryGetValue(key, out result);
			}
			if (readBuckEnabled == 1)
			{
				foreach (KeyValuePair<string, string> keyValuePair in dictionary)
				{
					if (keyValuePair.Value == BuckV2)
					{
						result = keyValuePair.Key;
						return result;
					}
				}
			}
			if (readBuckEnabled == 2)
			{
				foreach (KeyValuePair<string, string> keyValuePair2 in dictionary)
				{
					if (Convert.ToSingle(keyValuePair2.Value) >= Convert.ToSingle(BuckV2))
					{
						result = keyValuePair2.Value;
						break;
					}
				}
				return result;
			}
			return result;
		}

		public byte SetPMICBuckVoltageCodeFromValue(string BuckVoltage)
		{
			byte result = 0;
			double num = 0.5;
			double num2 = 0.73;
			double num3 = 1.4;
			if (Convert.ToDouble(BuckVoltage) >= 0.5 && Convert.ToDouble(BuckVoltage) <= 0.73)
			{
				result = (byte)((Convert.ToDouble(BuckVoltage) - num) * 100.0);
			}
			if (Convert.ToDouble(BuckVoltage) > 0.73 && Convert.ToDouble(BuckVoltage) < 0.735)
			{
				if ((double)Convert.ToSingle(BuckVoltage) <= 0.7325)
				{
					result = 23;
				}
				else
				{
					result = 24;
				}
			}
			if (Convert.ToDouble(BuckVoltage) >= 0.735 && Convert.ToDouble(BuckVoltage) <= 1.4)
			{
				result = (byte)((Convert.ToDouble(BuckVoltage) - num2) * 200.0 + 23.0);
			}
			if (Convert.ToDouble(BuckVoltage) > 1.4 && Convert.ToDouble(BuckVoltage) < 1.42)
			{
				if (Convert.ToDouble(BuckVoltage) <= 1.41)
				{
					result = 157;
				}
				else
				{
					result = 158;
				}
			}
			if (Convert.ToDouble(BuckVoltage) >= 1.42 && Convert.ToDouble(BuckVoltage) <= 3.36)
			{
				result = (byte)((Convert.ToDouble(BuckVoltage) - num3) * 50.0 + 157.0);
			}
			return result;
		}

		public double GetPMICBuckVoltageValueFromCode(byte voltageCode)
		{
			double result;
			if (voltageCode <= 23)
			{
				result = (double)voltageCode * 0.01 + 0.5;
			}
			else if (voltageCode <= 157)
			{
				result = (double)(voltageCode - 23) * 0.005 + 0.73;
			}
			else
			{
				result = (double)(voltageCode - 157) * 0.02 + 1.4;
			}
			return result;
		}

		public bool UpdatePMICVoltageConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdatePMICVoltageConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				string empty = string.Empty;
				f0001fc.f0004f1 = (m_RadioBtnSetBuckVol0Value.Checked ? 1 : 0);
				if (f0001fc.f0004f1 == 1)
				{
					f0001fc.Buck0SlaveAddress = 0;
					f0001fc.Buck0RegAddress = 0;
					if ((double)Convert.ToSingle(m_Buck0Vol.Text) < 0.5 || (double)Convert.ToSingle(m_Buck0Vol.Text) > 3.36)
					{
						MessageBox.Show("PMIC Buck Channel voltage range must lies between 0.5V to 3.36V !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return false;
					}
					f0001fc.Buck0MsbData = SetPMICBuckVoltageCodeFromValue(m_Buck0Vol.Text);
					f0001fc.Buck0LsbData = 0;
					f0001fc.Buck0DataSize = 0;
				}
				f0001fc.f0004f2 = (m_RadioBtnSetBuckVol1Value.Checked ? 1 : 0);
				if (f0001fc.f0004f2 == 1)
				{
					f0001fc.Buck1SlaveAddress = 0;
					f0001fc.Buck1RegAddress = 0;
					if ((double)Convert.ToSingle(m_Buck1Vol.Text) < 0.5 || (double)Convert.ToSingle(m_Buck1Vol.Text) > 3.36)
					{
						MessageBox.Show("PMIC Buck Channel voltage range must lies between 0.5V to 3.36V !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return false;
					}
					f0001fc.Buck1MsbData = SetPMICBuckVoltageCodeFromValue(m_Buck1Vol.Text);
					f0001fc.Buck1LsbData = 0;
					f0001fc.Buck1DataSize = 0;
				}
				f0001fc.f0004f3 = (m_RadioBtnSetBuckVol2Value.Checked ? 1 : 0);
				if (f0001fc.f0004f3 == 1)
				{
					f0001fc.Buck2SlaveAddress = 0;
					f0001fc.Buck2RegAddress = 0;
					if ((double)Convert.ToSingle(m_Buck2Vol.Text) < 0.5 || (double)Convert.ToSingle(m_Buck2Vol.Text) > 3.36)
					{
						MessageBox.Show("PMIC Buck Channel voltage range must lies between 0.5V to 3.36V !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return false;
					}
					f0001fc.Buck2MsbData = SetPMICBuckVoltageCodeFromValue(m_Buck2Vol.Text);
					f0001fc.Buck2LsbData = 0;
					f0001fc.Buck2DataSize = 0;
				}
				f0001fc.f0004f4 = (m_RadioBtnSetBuckVol3Value.Checked ? 1 : 0);
				if (f0001fc.f0004f4 == 1)
				{
					f0001fc.Buck3SlaveAddress = 0;
					f0001fc.Buck3RegAddress = 0;
					if ((double)Convert.ToSingle(m_Buck3Vol.Text) < 0.5 || (double)Convert.ToSingle(m_Buck3Vol.Text) > 3.36)
					{
						MessageBox.Show("PMIC Buck Channel voltage range must lies between 0.5V to 3.36V !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return false;
					}
					f0001fc.Buck3MsbData = SetPMICBuckVoltageCodeFromValue(m_Buck3Vol.Text);
					f0001fc.Buck3LsbData = 0;
					f0001fc.Buck3DataSize = 0;
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

		private int iSetPMICVolConfigSet_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetPMICBuckVoltageConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetPMICVolConfigSet()
		{
			iSetPMICVolConfigSet_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetPMICVolConfigSetAsync()
		{
			new del_v_v(iSetPMICVolConfigSet).BeginInvoke(null, null);
		}

		private void m00004a(object sender, EventArgs p1)
		{
			iSetPMICVolConfigSetAsync();
		}

		public void clrPMIConfigurationAfterReset()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(clrPMIConfigurationAfterReset);
				base.Invoke(method);
				return;
			}
			m_RadioBtnSetBuckVol0Value.Checked = false;
			m_RadioBtnSetBuckVol1Value.Checked = false;
			m_RadioBtnSetBuckVol2Value.Checked = false;
			m_RadioBtnSetBuckVol3Value.Checked = false;
			m_RadioBtnBuckVol0Value.Checked = false;
			m_RadioBtnBuckVol1Value.Checked = false;
			m_RadioBtnBuckVol2Value.Checked = false;
			m_RadioBtnBuckVol3Value.Checked = false;
			m_Buck0Vol.Text = "3.3";
			m_Buck1Vol.Text = "1.2";
			m_Buck2Vol.Text = "1.8";
			m_Buck3Vol.Text = "2.3";
		}

		public void m00004b(int p0)
		{
			if (base.InvokeRequired)
			{
				del_v_i method = new del_v_i(m00004b);
				base.Invoke(method, new object[]
				{
					p0
				});
				return;
			}
			if (p0 == 1)
			{
				f000203.Checked = true;
				return;
			}
			if (p0 == 2)
			{
				f000204.Checked = true;
				return;
			}
			f000203.Checked = false;
			f000204.Checked = false;
		}

		public void m00004c(string Buck0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m00004c);
				base.Invoke(method, new object[]
				{
					Buck0
				});
				return;
			}
			m_lblBuckVol0Value.Text = Buck0;
			m_RadioBtnBuckVol0Value.Checked = true;
		}

		public void m00004d(string Buck1)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m00004d);
				base.Invoke(method, new object[]
				{
					Buck1
				});
				return;
			}
			m_lblBuckVol1Value.Text = Buck1;
			m_RadioBtnBuckVol1Value.Checked = true;
		}

		public void m00004e(string Buck2)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m00004e);
				base.Invoke(method, new object[]
				{
					Buck2
				});
				return;
			}
			m_lblBuckVol2Value.Text = Buck2;
			m_RadioBtnBuckVol2Value.Checked = true;
		}

		public void m00004f(string Buck3)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m00004f);
				base.Invoke(method, new object[]
				{
					Buck3
				});
				return;
			}
			m_lblBuckVol3Value.Text = Buck3;
			m_RadioBtnBuckVol3Value.Checked = true;
		}

		public void m000050(string Buck0)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m000050);
				base.Invoke(method, new object[]
				{
					Buck0
				});
				return;
			}
			m_Buck0Vol.Text = Buck0;
			m_RadioBtnSetBuckVol0Value.Checked = true;
		}

		public void m000051(string Buck1)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m000051);
				base.Invoke(method, new object[]
				{
					Buck1
				});
				return;
			}
			m_Buck1Vol.Text = Buck1;
			m_RadioBtnSetBuckVol1Value.Checked = true;
		}

		public void m000052(string Buck2)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m000052);
				base.Invoke(method, new object[]
				{
					Buck2
				});
				return;
			}
			m_Buck2Vol.Text = Buck2;
			m_RadioBtnSetBuckVol2Value.Checked = true;
		}

		public void m000053(string Buck3)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m000053);
				base.Invoke(method, new object[]
				{
					Buck3
				});
				return;
			}
			m_Buck3Vol.Text = Buck3;
			m_RadioBtnSetBuckVol3Value.Checked = true;
		}

		private int iSetPMICConfigSet_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetPMICRegConfig_Gui(is_starting_op, is_ending_op);
		}

		private void m000054()
		{
			iSetPMICConfigSet_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetPMICConfigSetAsync()
		{
			new del_v_v(m000054).BeginInvoke(null, null);
		}

		private void m000055(object sender, EventArgs p1)
		{
			iSetPMICConfigSetAsync();
		}

		public bool UpdateSetPMICRegConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateSetPMICRegConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				uint num;
				if (!iConvertHexTextToUInt(m_txtGetI2CAddress, out num))
				{
					m_GuiManager.ErrorAbort("WriteRegister: Invalid address");
				}
				m_SetPMICRegConfigParams.SlaveAddress = (byte)num;
				uint num2;
				if (!iConvertHexTextToUInt(m_txtGetRegAddress, out num2))
				{
					m_GuiManager.ErrorAbort("WriteRegister: Invalid address");
				}
				m_SetPMICRegConfigParams.RegAddress = (byte)num2;
				uint num3;
				if (!iConvertHexTextToUInt(m_txtGetRegMSBData, out num3))
				{
					m_GuiManager.ErrorAbort("WriteRegister: Invalid address");
				}
				m_SetPMICRegConfigParams.RegMsbData = (byte)num3;
				uint num4;
				if (!iConvertHexTextToUInt(m_txtGetRegLSBData, out num4))
				{
					m_GuiManager.ErrorAbort("WriteRegister: Invalid address");
				}
				m_SetPMICRegConfigParams.RegLsbData = (byte)num4;
				m_SetPMICRegConfigParams.DataSize = (int)m_nudGetRegDataSize.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdatePMICRegConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdatePMICRegConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_txtGetI2CAddress.Text = Convert.ToString(m_SetPMICRegConfigParams.SlaveAddress, 16);
				m_txtGetRegAddress.Text = Convert.ToString(m_SetPMICRegConfigParams.RegAddress, 16);
				m_txtGetRegMSBData.Text = Convert.ToString(m_SetPMICRegConfigParams.RegMsbData, 16);
				m_txtGetRegLSBData.Text = Convert.ToString(m_SetPMICRegConfigParams.RegLsbData, 16);
				m_nudGetRegDataSize.Value = m_SetPMICRegConfigParams.DataSize;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetPMICConfigGet_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iGetPMICRegConfig_Gui(is_starting_op, is_ending_op);
		}

		private void m000056()
		{
			iSetPMICConfigGet_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetPMICConfigGetAsync()
		{
			new del_v_v(m000056).BeginInvoke(null, null);
		}

		private void m000057(object sender, EventArgs p1)
		{
			iSetPMICConfigGetAsync();
		}

		public bool UpdateGetPMICRegConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdateGetPMICRegConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				uint num;
				if (!iConvertHexTextToUInt(m_txtGetI2CAddress, out num))
				{
					m_GuiManager.ErrorAbort("WriteRegister: Invalid address");
				}
				m_GetPMICRegConfigParams.SlaveAddress = (byte)num;
				uint num2;
				if (!iConvertHexTextToUInt(m_txtGetRegAddress, out num2))
				{
					m_GuiManager.ErrorAbort("WriteRegister: Invalid address");
				}
				m_GetPMICRegConfigParams.RegAddress = (byte)num2;
				uint num3;
				if (!iConvertHexTextToUInt(m_txtGetRegMSBData, out num3))
				{
					m_GuiManager.ErrorAbort("WriteRegister: Invalid address");
				}
				m_GetPMICRegConfigParams.RegMsbData = (byte)num3;
				uint num4;
				if (!iConvertHexTextToUInt(m_txtGetRegLSBData, out num4))
				{
					m_GuiManager.ErrorAbort("WriteRegister: Invalid address");
				}
				m_GetPMICRegConfigParams.RegLsbData = (byte)num4;
				m_GetPMICRegConfigParams.DataSize = (int)m_nudGetRegDataSize.Value;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdatePMICRegReadConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdatePMICRegReadConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				m_txtGetI2CAddress.Text = Convert.ToString(m_GetPMICRegConfigParams.SlaveAddress, 16);
				m_txtGetRegAddress.Text = Convert.ToString(m_GetPMICRegConfigParams.RegAddress, 16);
				m_txtGetRegMSBData.Text = Convert.ToString(m_GetPMICRegConfigParams.RegMsbData, 16);
				m_txtGetRegLSBData.Text = Convert.ToString(m_GetPMICRegConfigParams.RegLsbData, 16);
				m_nudGetRegDataSize.Value = m_GetPMICRegConfigParams.DataSize;
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public void m000058(string MSBData)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m000058);
				base.Invoke(method, new object[]
				{
					MSBData
				});
				return;
			}
			m_txtGetRegMSBData.Text = MSBData;
		}

		public void m000059(string LSBData)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(m000059);
				base.Invoke(method, new object[]
				{
					LSBData
				});
				return;
			}
			m_txtGetRegLSBData.Text = LSBData;
		}

		private void groupBox2_Enter(object sender, EventArgs p1)
		{
		}

		private int iSetPMICDeviceSelectConfigSet_internal(bool is_starting_op, bool is_ending_op)
		{
			return m_GuiManager.ScriptOps.iSetMultiplePMICDevicesConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetPMICDeviceSelectConfigSet()
		{
			iSetPMICDeviceSelectConfigSet_internal(true, false);
			m_MainForm.GuiOpEnd(true);
		}

		public void iSetPMICDeviceSelectConfigSetAsync()
		{
			new del_v_v(iSetPMICDeviceSelectConfigSet).BeginInvoke(null, null);
		}

		private void m00005a(object sender, EventArgs p1)
		{
			iSetPMICDeviceSelectConfigSetAsync();
		}

		public bool UpdatePMICSelectConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(UpdatePMICSelectConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				f0001fc.PMIC1 = (f000203.Checked ? 1 : 0);
				f0001fc.PMIC2 = (f000204.Checked ? 1 : 0);
				result = true;
			}
			catch (Exception ex)
			{
				m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_RadioBtnBuckVol3Value = new System.Windows.Forms.RadioButton();
            this.m_RadioBtnBuckVol2Value = new System.Windows.Forms.RadioButton();
            this.m_RadioBtnBuckVol1Value = new System.Windows.Forms.RadioButton();
            this.m_RadioBtnBuckVol0Value = new System.Windows.Forms.RadioButton();
            this.m_lblBuckVol3Value = new System.Windows.Forms.Label();
            this.m_lblBuckVol2Value = new System.Windows.Forms.Label();
            this.m_lblBuckVol1Value = new System.Windows.Forms.Label();
            this.m_lblBuckVol0Value = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.f0001fd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_RadioBtnSetBuckVol0Value = new System.Windows.Forms.RadioButton();
            this.m_Buck3Vol = new System.Windows.Forms.TextBox();
            this.m_Buck2Vol = new System.Windows.Forms.TextBox();
            this.m_Buck1Vol = new System.Windows.Forms.TextBox();
            this.m_Buck0Vol = new System.Windows.Forms.TextBox();
            this.m_RadioBtnSetBuckVol3Value = new System.Windows.Forms.RadioButton();
            this.m_RadioBtnSetBuckVol2Value = new System.Windows.Forms.RadioButton();
            this.m_RadioBtnSetBuckVol1Value = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.f0001fe = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.f0001ff = new System.Windows.Forms.Button();
            this.f000200 = new System.Windows.Forms.Button();
            this.m_txtGetRegLSBData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_nudGetRegDataSize = new System.Windows.Forms.NumericUpDown();
            this.m_txtGetRegMSBData = new System.Windows.Forms.TextBox();
            this.m_txtGetRegAddress = new System.Windows.Forms.TextBox();
            this.m_txtGetI2CAddress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.f000201 = new System.Windows.Forms.GroupBox();
            this.f000202 = new System.Windows.Forms.Button();
            this.f000203 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.f000204 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGetRegDataSize)).BeginInit();
            this.f000201.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_RadioBtnBuckVol3Value);
            this.groupBox1.Controls.Add(this.m_RadioBtnBuckVol2Value);
            this.groupBox1.Controls.Add(this.m_RadioBtnBuckVol1Value);
            this.groupBox1.Controls.Add(this.m_RadioBtnBuckVol0Value);
            this.groupBox1.Controls.Add(this.m_lblBuckVol3Value);
            this.groupBox1.Controls.Add(this.m_lblBuckVol2Value);
            this.groupBox1.Controls.Add(this.m_lblBuckVol1Value);
            this.groupBox1.Controls.Add(this.m_lblBuckVol0Value);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.f0001fd);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(409, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PMICGet";
            // 
            // m_RadioBtnBuckVol3Value
            // 
            this.m_RadioBtnBuckVol3Value.AutoSize = true;
            this.m_RadioBtnBuckVol3Value.Location = new System.Drawing.Point(15, 155);
            this.m_RadioBtnBuckVol3Value.Name = "m_RadioBtnBuckVol3Value";
            this.m_RadioBtnBuckVol3Value.Size = new System.Drawing.Size(59, 19);
            this.m_RadioBtnBuckVol3Value.TabIndex = 11;
            this.m_RadioBtnBuckVol3Value.TabStop = true;
            this.m_RadioBtnBuckVol3Value.Text = "Buck3";
            this.m_RadioBtnBuckVol3Value.UseVisualStyleBackColor = true;
            // 
            // m_RadioBtnBuckVol2Value
            // 
            this.m_RadioBtnBuckVol2Value.AutoSize = true;
            this.m_RadioBtnBuckVol2Value.Location = new System.Drawing.Point(15, 121);
            this.m_RadioBtnBuckVol2Value.Name = "m_RadioBtnBuckVol2Value";
            this.m_RadioBtnBuckVol2Value.Size = new System.Drawing.Size(59, 19);
            this.m_RadioBtnBuckVol2Value.TabIndex = 7;
            this.m_RadioBtnBuckVol2Value.TabStop = true;
            this.m_RadioBtnBuckVol2Value.Text = "Buck2";
            this.m_RadioBtnBuckVol2Value.UseVisualStyleBackColor = true;
            // 
            // m_RadioBtnBuckVol1Value
            // 
            this.m_RadioBtnBuckVol1Value.AutoSize = true;
            this.m_RadioBtnBuckVol1Value.Location = new System.Drawing.Point(15, 87);
            this.m_RadioBtnBuckVol1Value.Name = "m_RadioBtnBuckVol1Value";
            this.m_RadioBtnBuckVol1Value.Size = new System.Drawing.Size(59, 19);
            this.m_RadioBtnBuckVol1Value.TabIndex = 10;
            this.m_RadioBtnBuckVol1Value.TabStop = true;
            this.m_RadioBtnBuckVol1Value.Text = "Buck1";
            this.m_RadioBtnBuckVol1Value.UseVisualStyleBackColor = true;
            // 
            // m_RadioBtnBuckVol0Value
            // 
            this.m_RadioBtnBuckVol0Value.AutoSize = true;
            this.m_RadioBtnBuckVol0Value.Location = new System.Drawing.Point(15, 56);
            this.m_RadioBtnBuckVol0Value.Name = "m_RadioBtnBuckVol0Value";
            this.m_RadioBtnBuckVol0Value.Size = new System.Drawing.Size(59, 19);
            this.m_RadioBtnBuckVol0Value.TabIndex = 9;
            this.m_RadioBtnBuckVol0Value.TabStop = true;
            this.m_RadioBtnBuckVol0Value.Text = "Buck0";
            this.m_RadioBtnBuckVol0Value.UseVisualStyleBackColor = true;
            // 
            // m_lblBuckVol3Value
            // 
            this.m_lblBuckVol3Value.AutoSize = true;
            this.m_lblBuckVol3Value.Location = new System.Drawing.Point(162, 157);
            this.m_lblBuckVol3Value.Name = "m_lblBuckVol3Value";
            this.m_lblBuckVol3Value.Size = new System.Drawing.Size(24, 15);
            this.m_lblBuckVol3Value.TabIndex = 8;
            this.m_lblBuckVol3Value.Text = "0.0";
            // 
            // m_lblBuckVol2Value
            // 
            this.m_lblBuckVol2Value.AutoSize = true;
            this.m_lblBuckVol2Value.Location = new System.Drawing.Point(162, 123);
            this.m_lblBuckVol2Value.Name = "m_lblBuckVol2Value";
            this.m_lblBuckVol2Value.Size = new System.Drawing.Size(24, 15);
            this.m_lblBuckVol2Value.TabIndex = 6;
            this.m_lblBuckVol2Value.Text = "0.0";
            // 
            // m_lblBuckVol1Value
            // 
            this.m_lblBuckVol1Value.AutoSize = true;
            this.m_lblBuckVol1Value.Location = new System.Drawing.Point(162, 90);
            this.m_lblBuckVol1Value.Name = "m_lblBuckVol1Value";
            this.m_lblBuckVol1Value.Size = new System.Drawing.Size(24, 15);
            this.m_lblBuckVol1Value.TabIndex = 4;
            this.m_lblBuckVol1Value.Text = "0.0";
            // 
            // m_lblBuckVol0Value
            // 
            this.m_lblBuckVol0Value.AutoSize = true;
            this.m_lblBuckVol0Value.Location = new System.Drawing.Point(162, 59);
            this.m_lblBuckVol0Value.Name = "m_lblBuckVol0Value";
            this.m_lblBuckVol0Value.Size = new System.Drawing.Size(24, 15);
            this.m_lblBuckVol0Value.TabIndex = 2;
            this.m_lblBuckVol0Value.Text = "0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Voltage (V)";
            // 
            // f0001fd
            // 
            this.f0001fd.Location = new System.Drawing.Point(117, 194);
            this.f0001fd.Name = "f0001fd";
            this.f0001fd.Size = new System.Drawing.Size(83, 27);
            this.f0001fd.TabIndex = 0;
            this.f0001fd.Text = "Get";
            this.f0001fd.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_RadioBtnSetBuckVol0Value);
            this.groupBox2.Controls.Add(this.m_Buck3Vol);
            this.groupBox2.Controls.Add(this.m_Buck2Vol);
            this.groupBox2.Controls.Add(this.m_Buck1Vol);
            this.groupBox2.Controls.Add(this.m_Buck0Vol);
            this.groupBox2.Controls.Add(this.m_RadioBtnSetBuckVol3Value);
            this.groupBox2.Controls.Add(this.m_RadioBtnSetBuckVol2Value);
            this.groupBox2.Controls.Add(this.m_RadioBtnSetBuckVol1Value);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.f0001fe);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(22, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 223);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PMICSet";
            // 
            // m_RadioBtnSetBuckVol0Value
            // 
            this.m_RadioBtnSetBuckVol0Value.AutoSize = true;
            this.m_RadioBtnSetBuckVol0Value.Location = new System.Drawing.Point(36, 59);
            this.m_RadioBtnSetBuckVol0Value.Name = "m_RadioBtnSetBuckVol0Value";
            this.m_RadioBtnSetBuckVol0Value.Size = new System.Drawing.Size(59, 19);
            this.m_RadioBtnSetBuckVol0Value.TabIndex = 17;
            this.m_RadioBtnSetBuckVol0Value.TabStop = true;
            this.m_RadioBtnSetBuckVol0Value.Text = "Buck0";
            this.m_RadioBtnSetBuckVol0Value.UseVisualStyleBackColor = true;
            // 
            // m_Buck3Vol
            // 
            this.m_Buck3Vol.Location = new System.Drawing.Point(155, 146);
            this.m_Buck3Vol.Name = "m_Buck3Vol";
            this.m_Buck3Vol.Size = new System.Drawing.Size(64, 21);
            this.m_Buck3Vol.TabIndex = 16;
            this.m_Buck3Vol.Text = "2.3";
            // 
            // m_Buck2Vol
            // 
            this.m_Buck2Vol.Location = new System.Drawing.Point(155, 117);
            this.m_Buck2Vol.Name = "m_Buck2Vol";
            this.m_Buck2Vol.Size = new System.Drawing.Size(64, 21);
            this.m_Buck2Vol.TabIndex = 15;
            this.m_Buck2Vol.Text = "1.8";
            // 
            // m_Buck1Vol
            // 
            this.m_Buck1Vol.Location = new System.Drawing.Point(155, 84);
            this.m_Buck1Vol.Name = "m_Buck1Vol";
            this.m_Buck1Vol.Size = new System.Drawing.Size(64, 21);
            this.m_Buck1Vol.TabIndex = 14;
            this.m_Buck1Vol.Text = "1.2";
            // 
            // m_Buck0Vol
            // 
            this.m_Buck0Vol.Location = new System.Drawing.Point(155, 56);
            this.m_Buck0Vol.Name = "m_Buck0Vol";
            this.m_Buck0Vol.Size = new System.Drawing.Size(64, 21);
            this.m_Buck0Vol.TabIndex = 13;
            this.m_Buck0Vol.Text = "3.3";
            // 
            // m_RadioBtnSetBuckVol3Value
            // 
            this.m_RadioBtnSetBuckVol3Value.AutoSize = true;
            this.m_RadioBtnSetBuckVol3Value.Location = new System.Drawing.Point(36, 146);
            this.m_RadioBtnSetBuckVol3Value.Name = "m_RadioBtnSetBuckVol3Value";
            this.m_RadioBtnSetBuckVol3Value.Size = new System.Drawing.Size(59, 19);
            this.m_RadioBtnSetBuckVol3Value.TabIndex = 12;
            this.m_RadioBtnSetBuckVol3Value.TabStop = true;
            this.m_RadioBtnSetBuckVol3Value.Text = "Buck3";
            this.m_RadioBtnSetBuckVol3Value.UseVisualStyleBackColor = true;
            // 
            // m_RadioBtnSetBuckVol2Value
            // 
            this.m_RadioBtnSetBuckVol2Value.AutoSize = true;
            this.m_RadioBtnSetBuckVol2Value.Location = new System.Drawing.Point(36, 117);
            this.m_RadioBtnSetBuckVol2Value.Name = "m_RadioBtnSetBuckVol2Value";
            this.m_RadioBtnSetBuckVol2Value.Size = new System.Drawing.Size(59, 19);
            this.m_RadioBtnSetBuckVol2Value.TabIndex = 11;
            this.m_RadioBtnSetBuckVol2Value.TabStop = true;
            this.m_RadioBtnSetBuckVol2Value.Text = "Buck2";
            this.m_RadioBtnSetBuckVol2Value.UseVisualStyleBackColor = true;
            // 
            // m_RadioBtnSetBuckVol1Value
            // 
            this.m_RadioBtnSetBuckVol1Value.AutoSize = true;
            this.m_RadioBtnSetBuckVol1Value.Location = new System.Drawing.Point(36, 84);
            this.m_RadioBtnSetBuckVol1Value.Name = "m_RadioBtnSetBuckVol1Value";
            this.m_RadioBtnSetBuckVol1Value.Size = new System.Drawing.Size(59, 19);
            this.m_RadioBtnSetBuckVol1Value.TabIndex = 10;
            this.m_RadioBtnSetBuckVol1Value.TabStop = true;
            this.m_RadioBtnSetBuckVol1Value.Text = "Buck1";
            this.m_RadioBtnSetBuckVol1Value.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(137, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Voltage (V) ";
            // 
            // f0001fe
            // 
            this.f0001fe.Location = new System.Drawing.Point(155, 184);
            this.f0001fe.Name = "f0001fe";
            this.f0001fe.Size = new System.Drawing.Size(83, 27);
            this.f0001fe.TabIndex = 0;
            this.f0001fe.Text = "Set";
            this.f0001fe.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(23, 32);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(282, 77);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "The user can give the following PMIC values:\r\nThe range from 0.5 to 0.73V in step" +
    "s of 10mV\r\nThe range from 0.735 to 1.4V in steps of 5mV\r\nThe range from 1.42 to " +
    "3.36 V in steps of 20mV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "PMIC OTP default voltage values";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Buck0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Buck1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(403, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Buck2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(403, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Buck3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(491, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "3.3 V";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(491, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "1.2 V";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(491, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "1.8 V";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(491, 125);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "2.3 V";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.f0001ff);
            this.groupBox3.Controls.Add(this.f000200);
            this.groupBox3.Controls.Add(this.m_txtGetRegLSBData);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.m_nudGetRegDataSize);
            this.groupBox3.Controls.Add(this.m_txtGetRegMSBData);
            this.groupBox3.Controls.Add(this.m_txtGetRegAddress);
            this.groupBox3.Controls.Add(this.m_txtGetI2CAddress);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Location = new System.Drawing.Point(741, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 282);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PMIC Configuration";
            // 
            // f0001ff
            // 
            this.f0001ff.Location = new System.Drawing.Point(197, 192);
            this.f0001ff.Name = "f0001ff";
            this.f0001ff.Size = new System.Drawing.Size(75, 32);
            this.f0001ff.TabIndex = 43;
            this.f0001ff.Text = "Read";
            this.f0001ff.UseVisualStyleBackColor = true;
            // 
            // f000200
            // 
            this.f000200.Location = new System.Drawing.Point(76, 192);
            this.f000200.Name = "f000200";
            this.f000200.Size = new System.Drawing.Size(75, 32);
            this.f000200.TabIndex = 42;
            this.f000200.Text = "Write";
            this.f000200.UseVisualStyleBackColor = true;
            // 
            // m_txtGetRegLSBData
            // 
            this.m_txtGetRegLSBData.Location = new System.Drawing.Point(138, 110);
            this.m_txtGetRegLSBData.Name = "m_txtGetRegLSBData";
            this.m_txtGetRegLSBData.Size = new System.Drawing.Size(100, 20);
            this.m_txtGetRegLSBData.TabIndex = 41;
            this.m_txtGetRegLSBData.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = " Reg LSB Data (Hex)";
            // 
            // m_nudGetRegDataSize
            // 
            this.m_nudGetRegDataSize.Location = new System.Drawing.Point(139, 139);
            this.m_nudGetRegDataSize.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_nudGetRegDataSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_nudGetRegDataSize.Name = "m_nudGetRegDataSize";
            this.m_nudGetRegDataSize.Size = new System.Drawing.Size(102, 20);
            this.m_nudGetRegDataSize.TabIndex = 39;
            this.m_nudGetRegDataSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_txtGetRegMSBData
            // 
            this.m_txtGetRegMSBData.Location = new System.Drawing.Point(138, 85);
            this.m_txtGetRegMSBData.Name = "m_txtGetRegMSBData";
            this.m_txtGetRegMSBData.Size = new System.Drawing.Size(100, 20);
            this.m_txtGetRegMSBData.TabIndex = 38;
            this.m_txtGetRegMSBData.Text = "0";
            // 
            // m_txtGetRegAddress
            // 
            this.m_txtGetRegAddress.Location = new System.Drawing.Point(138, 54);
            this.m_txtGetRegAddress.Name = "m_txtGetRegAddress";
            this.m_txtGetRegAddress.Size = new System.Drawing.Size(100, 20);
            this.m_txtGetRegAddress.TabIndex = 37;
            // 
            // m_txtGetI2CAddress
            // 
            this.m_txtGetI2CAddress.Location = new System.Drawing.Point(138, 22);
            this.m_txtGetI2CAddress.Name = "m_txtGetI2CAddress";
            this.m_txtGetI2CAddress.Size = new System.Drawing.Size(100, 20);
            this.m_txtGetI2CAddress.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Data Size";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = " Reg MSB Data (Hex)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 13);
            this.label18.TabIndex = 34;
            this.label18.Text = "Reg Address (Hex)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(19, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "I2C Address (Hex)";
            // 
            // f000201
            // 
            this.f000201.Controls.Add(this.f000202);
            this.f000201.Controls.Add(this.f000203);
            this.f000201.Controls.Add(this.label7);
            this.f000201.Controls.Add(this.f000204);
            this.f000201.Controls.Add(this.label5);
            this.f000201.Location = new System.Drawing.Point(22, 125);
            this.f000201.Name = "f000201";
            this.f000201.Size = new System.Drawing.Size(265, 101);
            this.f000201.TabIndex = 22;
            this.f000201.TabStop = false;
            this.f000201.Text = "Select PMIC Devices";
            // 
            // f000202
            // 
            this.f000202.Location = new System.Drawing.Point(137, 68);
            this.f000202.Name = "f000202";
            this.f000202.Size = new System.Drawing.Size(83, 27);
            this.f000202.TabIndex = 21;
            this.f000202.Text = "Set";
            this.f000202.UseVisualStyleBackColor = true;
            // 
            // f000203
            // 
            this.f000203.AutoSize = true;
            this.f000203.Location = new System.Drawing.Point(17, 23);
            this.f000203.Name = "f000203";
            this.f000203.Size = new System.Drawing.Size(60, 17);
            this.f000203.TabIndex = 17;
            this.f000203.TabStop = true;
            this.f000203.Text = "PMIC 1";
            this.f000203.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(109, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Powers Device 2 and 3";
            // 
            // f000204
            // 
            this.f000204.AutoSize = true;
            this.f000204.Location = new System.Drawing.Point(17, 47);
            this.f000204.Name = "f000204";
            this.f000204.Size = new System.Drawing.Size(60, 17);
            this.f000204.TabIndex = 18;
            this.f000204.TabStop = true;
            this.f000204.Text = "PMIC 2";
            this.f000204.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Powers Device 1 and 4";
            // 
            // PMICTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.f000201);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PMICTab";
            this.Size = new System.Drawing.Size(1142, 465);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudGetRegDataSize)).EndInit();
            this.f000201.ResumeLayout(false);
            this.f000201.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		public PMICVoltageConfigParams f0001fc;

		public SetPMICRegConfigParams m_SetPMICRegConfigParams;

		public GetPMICRegConfigParams m_GetPMICRegConfigParams;

		private IContainer components;

		private GroupBox groupBox1;

		private Label m_lblBuckVol3Value;

		private Label m_lblBuckVol2Value;

		private Label m_lblBuckVol1Value;

		private Label m_lblBuckVol0Value;

		private Label label1;

		private Button f0001fd;

		private GroupBox groupBox2;

		private Label label9;

		private Button f0001fe;

		private TextBox textBox1;

		private RadioButton m_RadioBtnBuckVol2Value;

		private RadioButton m_RadioBtnBuckVol3Value;

		private RadioButton m_RadioBtnBuckVol1Value;

		private RadioButton m_RadioBtnBuckVol0Value;

		private RadioButton m_RadioBtnSetBuckVol3Value;

		private RadioButton m_RadioBtnSetBuckVol2Value;

		private RadioButton m_RadioBtnSetBuckVol1Value;

		private Label label2;

		private Label label4;

		private Label label6;

		private Label label8;

		private Label label13;

		private Label label14;

		private Label label15;

		private Label label16;

		private Label label17;

		private TextBox m_Buck3Vol;

		private TextBox m_Buck2Vol;

		private TextBox m_Buck1Vol;

		private TextBox m_Buck0Vol;

		private GroupBox groupBox3;

		private TextBox m_txtGetRegLSBData;

		private Label label3;

		private NumericUpDown m_nudGetRegDataSize;

		private TextBox m_txtGetRegMSBData;

		private TextBox m_txtGetRegAddress;

		private TextBox m_txtGetI2CAddress;

		private Label label11;

		private Label label12;

		private Label label18;

		private Label label19;

		private Button f0001ff;

		private Button f000200;

		private GroupBox f000201;

		private Button f000202;

		private RadioButton f000203;

		private Label label7;

		private RadioButton f000204;

		private Label label5;

		private RadioButton m_RadioBtnSetBuckVol0Value;
	}
}
