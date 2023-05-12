using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class LoopBack : UserControl
	{
		public LoopBack()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_RFPALoopBackConfigParams = this.m_GuiManager.TsParams.RFPALoopBackConfigParams;
			this.m_RFPSLoopBackConfigParams = this.m_GuiManager.TsParams.RFPSLoopBackConfigParams;
			this.m_RFIFLoopBackConfigParams = this.m_GuiManager.TsParams.RFIFLoopBackConfigParams;
			this.m_nudRFPALoopBackFreq.Value = 2m;
			this.m_nudRFIFLoopBackFreq.SelectedIndex = 5;
			this.m_cboRFLoopBackGainIndex.SelectedIndex = 12;
		}

		private int iSetRFPALoopBackConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetRFPALoopBackConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFPALoopBackConfig()
		{
			this.iSetRFPALoopBackConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetRFPALoopBackAsync()
		{
			new del_v_v(this.iSetRFPALoopBackConfig).BeginInvoke(null, null);
		}

		private void m000074(object sender, EventArgs p1)
		{
			this.iSetRFPALoopBackAsync();
		}

		public bool UpdateRFPALoopBackConfigDataFromGUI()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRFPALoopBackConfigDataFromGUI);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RFPALoopBackConfigParams.LoopBackFreq = (ushort)this.m_nudRFPALoopBackFreq.Value;
				this.m_RFPALoopBackConfigParams.LoopBackEnable = (this.f00025c.Checked ? '\u0001' : '\0');
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateLoopBackConfig(RootObject jobject, int p1)
		{
			bool result;
			try
			{
				if (jobject.mmWaveDevices[p1].rfConfig.rlRfPALoopbackCfg_t.isConfigured == 0)
				{
					string msg = string.Format("Missing PA Loopback Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg);
				}
				else
				{
					this.m_nudRFPALoopBackFreq.Value = jobject.mmWaveDevices[p1].rfConfig.rlRfPALoopbackCfg_t.paLoopbackFreq_MHz;
					this.f00025c.Checked = (jobject.mmWaveDevices[p1].rfConfig.rlRfPALoopbackCfg_t.p00000c == 1);
				}
				if (jobject.mmWaveDevices[p1].rfConfig.rlRfPSLoopbackCfg_t.isConfigured == 0)
				{
					string msg2 = string.Format("Missing PS Loopback Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg2);
				}
				else
				{
					this.m_nudRFPSLoopBackFreq.Value = jobject.mmWaveDevices[p1].rfConfig.rlRfPSLoopbackCfg_t.psLoopbackFreq_KHz;
					this.f00025e.Checked = (jobject.mmWaveDevices[p1].rfConfig.rlRfPSLoopbackCfg_t.p00000d == 1);
					this.f000263.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlRfPSLoopbackCfg_t.psLoopbackTxId, 16) & 1) == 1);
					this.f000262.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlRfPSLoopbackCfg_t.psLoopbackTxId, 16) & 2) >> 1 == 1);
					this.m_cboRFLoopBackGainIndex.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlRfPSLoopbackCfg_t.pgaGainIndex;
				}
				if (jobject.mmWaveDevices[p1].rfConfig.rlRfIFLoopbackCfg_t.isConfigured == 0)
				{
					string msg3 = string.Format("Missing IF Loopback Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg3);
				}
				else
				{
					this.m_nudRFIFLoopBackFreq.SelectedIndex = jobject.mmWaveDevices[p1].rfConfig.rlRfIFLoopbackCfg_t.ifLoopbackFreq;
					this.f000260.Checked = (jobject.mmWaveDevices[p1].rfConfig.rlRfIFLoopbackCfg_t.ifLoopbackEn == 1);
				}
				result = true;
			}
			catch
			{
				string msg4 = string.Format("LoopBack Config Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg4);
				result = false;
			}
			return result;
		}

		public bool UpdateRFPALoopBackConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRFPALoopBackConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudRFPALoopBackFreq.Value = this.m_RFPALoopBackConfigParams.LoopBackFreq;
				this.f00025c.Checked = (this.m_RFPALoopBackConfigParams.LoopBackEnable == '\u0001');
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetRFPSLoopBackConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetRFPSLoopBackConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFPSLoopBackConfig()
		{
			this.iSetRFPSLoopBackConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetRFPSLoopBackAsync()
		{
			new del_v_v(this.iSetRFPSLoopBackConfig).BeginInvoke(null, null);
		}

		private void m000075(object sender, EventArgs p1)
		{
			this.iSetRFPSLoopBackAsync();
		}

		public bool UpdateRFPSLoopBackConfigDataFromGUI()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRFPSLoopBackConfigDataFromGUI);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RFPSLoopBackConfigParams.LoopBackFreq = (ushort)this.m_nudRFPSLoopBackFreq.Value;
				this.m_RFPSLoopBackConfigParams.LoopBackEnable = (this.f00025e.Checked ? '\u0001' : '\0');
				this.m_RFPSLoopBackConfigParams.LoopBackTXIdTx0 = (this.f000263.Checked ? '\u0001' : '\0');
				this.m_RFPSLoopBackConfigParams.LoopBackTXIdTx1 = (this.f000262.Checked ? '\u0001' : '\0');
				this.m_RFPSLoopBackConfigParams.PGAGainIndex = (char)this.m_cboRFLoopBackGainIndex.SelectedIndex;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRFPSLoopBackConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRFPSLoopBackConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudRFPSLoopBackFreq.Value = this.m_RFPSLoopBackConfigParams.LoopBackFreq;
				this.f00025e.Checked = (this.m_RFPSLoopBackConfigParams.LoopBackEnable == '\u0001');
				this.f000263.Checked = (this.m_RFPSLoopBackConfigParams.LoopBackTXIdTx0 == '\u0001');
				this.f000262.Checked = (this.m_RFPSLoopBackConfigParams.LoopBackTXIdTx1 == '\u0001');
				this.m_cboRFLoopBackGainIndex.SelectedIndex = (int)this.m_RFPSLoopBackConfigParams.PGAGainIndex;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetRFIFLoopBackConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetRFIFLoopBackConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRFIFLoopBackConfig()
		{
			this.iSetRFIFLoopBackConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetRFIFLoopBackAsync()
		{
			new del_v_v(this.iSetRFIFLoopBackConfig).BeginInvoke(null, null);
		}

		private void m000076(object sender, EventArgs p1)
		{
			this.iSetRFIFLoopBackAsync();
		}

		public bool UpdateRFIFLoopBackConfigDataFromGUI()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRFIFLoopBackConfigDataFromGUI);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RFIFLoopBackConfigParams.LoopBackFreq = (ushort)this.m_nudRFIFLoopBackFreq.SelectedIndex;
				this.m_RFIFLoopBackConfigParams.LoopBackEnable = (this.f000260.Checked ? '\u0001' : '\0');
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRFIFLoopBackConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRFIFLoopBackConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudRFIFLoopBackFreq.SelectedIndex = (int)this.m_RFIFLoopBackConfigParams.LoopBackFreq;
				this.f000260.Checked = (this.m_RFIFLoopBackConfigParams.LoopBackEnable == '\u0001');
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private void m000077(object sender, EventArgs p1)
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
			this.f000259 = new GroupBox();
			this.m_nudRFPALoopBackFreq = new NumericUpDown();
			this.f00025c = new CheckBox();
			this.f00025d = new Button();
			this.label2 = new Label();
			this.label1 = new Label();
			this.f00025a = new GroupBox();
			this.f000262 = new CheckBox();
			this.f000263 = new CheckBox();
			this.m_cboRFLoopBackGainIndex = new ComboBox();
			this.f00025e = new CheckBox();
			this.m_nudRFPSLoopBackFreq = new NumericUpDown();
			this.f00025f = new Button();
			this.label6 = new Label();
			this.label5 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.f00025b = new GroupBox();
			this.m_nudRFIFLoopBackFreq = new ComboBox();
			this.f000260 = new CheckBox();
			this.f000261 = new Button();
			this.label7 = new Label();
			this.label8 = new Label();
			this.f000259.SuspendLayout();
			((ISupportInitialize)this.m_nudRFPALoopBackFreq).BeginInit();
			this.f00025a.SuspendLayout();
			((ISupportInitialize)this.m_nudRFPSLoopBackFreq).BeginInit();
			this.f00025b.SuspendLayout();
			base.SuspendLayout();
			this.f000259.Controls.Add(this.m_nudRFPALoopBackFreq);
			this.f000259.Controls.Add(this.f00025c);
			this.f000259.Controls.Add(this.f00025d);
			this.f000259.Controls.Add(this.label2);
			this.f000259.Controls.Add(this.label1);
			this.f000259.Location = new Point(43, 55);
			this.f000259.Margin = new Padding(4);
			this.f000259.Name = "m_grpRFPALoopBackCfg";
			this.f000259.Padding = new Padding(4);
			this.f000259.Size = new Size(344, 175);
			this.f000259.TabIndex = 0;
			this.f000259.TabStop = false;
			this.f000259.Text = "PA LoopBack Configuration";
			this.m_nudRFPALoopBackFreq.Location = new Point(209, 32);
			this.m_nudRFPALoopBackFreq.Margin = new Padding(4);
			this.m_nudRFPALoopBackFreq.Name = "m_nudRFPALoopBackFreq";
			this.m_nudRFPALoopBackFreq.Size = new Size(123, 22);
			this.m_nudRFPALoopBackFreq.TabIndex = 4;
			NumericUpDown nudRFPALoopBackFreq = this.m_nudRFPALoopBackFreq;
			int[] array = new int[4];
			array[0] = 2;
			nudRFPALoopBackFreq.Value = new decimal(array);
			this.f00025c.AutoSize = true;
			this.f00025c.Location = new Point(209, 69);
			this.f00025c.Margin = new Padding(4);
			this.f00025c.Name = "m_ChkRFPALoopBackEnable";
			this.f00025c.Size = new Size(18, 17);
			this.f00025c.TabIndex = 3;
			this.f00025c.UseVisualStyleBackColor = true;
			this.f00025d.Location = new Point(209, 111);
			this.f00025d.Margin = new Padding(4);
			this.f00025d.Name = "m_btnRFPALoopBackSet";
			this.f00025d.Size = new Size(100, 43);
			this.f00025d.TabIndex = 2;
			this.f00025d.Text = "Set";
			this.f00025d.UseVisualStyleBackColor = true;
			this.f00025d.Click += this.m000074;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(32, 69);
			this.label2.Margin = new Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(119, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "LoopBack Enable";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(28, 32);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(146, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "LoopBack Freq (MHz)";
			this.f00025a.Controls.Add(this.f000262);
			this.f00025a.Controls.Add(this.f000263);
			this.f00025a.Controls.Add(this.m_cboRFLoopBackGainIndex);
			this.f00025a.Controls.Add(this.f00025e);
			this.f00025a.Controls.Add(this.m_nudRFPSLoopBackFreq);
			this.f00025a.Controls.Add(this.f00025f);
			this.f00025a.Controls.Add(this.label6);
			this.f00025a.Controls.Add(this.label5);
			this.f00025a.Controls.Add(this.label4);
			this.f00025a.Controls.Add(this.label3);
			this.f00025a.Location = new Point(400, 55);
			this.f00025a.Margin = new Padding(4);
			this.f00025a.Name = "m_grpRFPSLoopBackCfg";
			this.f00025a.Padding = new Padding(4);
			this.f00025a.Size = new Size(615, 175);
			this.f00025a.TabIndex = 1;
			this.f00025a.TabStop = false;
			this.f00025a.Text = "PS LoopBack Configuration";
			this.f000262.AutoSize = true;
			this.f000262.Location = new Point(552, 30);
			this.f000262.Margin = new Padding(4);
			this.f000262.Name = "m_ChkRFPSLoopBackTXIdTx1";
			this.f000262.Size = new Size(56, 21);
			this.f000262.TabIndex = 10;
			this.f000262.Text = "TX1";
			this.f000262.UseVisualStyleBackColor = true;
			this.f000263.AutoSize = true;
			this.f000263.Location = new Point(473, 30);
			this.f000263.Margin = new Padding(4);
			this.f000263.Name = "m_ChkRFPSLoopBackTXIdTx0";
			this.f000263.Size = new Size(56, 21);
			this.f000263.TabIndex = 9;
			this.f000263.Text = "TX0";
			this.f000263.UseVisualStyleBackColor = true;
			this.m_cboRFLoopBackGainIndex.DropDownStyle = ComboBoxStyle.DropDownList;
			this.m_cboRFLoopBackGainIndex.FormattingEnabled = true;
			this.m_cboRFLoopBackGainIndex.Items.AddRange(new object[]
			{
				"OFF",
				"-22 dB",
				"-16 dB",
				"-15 dB",
				"-14 dB",
				"-13 dB",
				"-12 dB",
				"-11 dB",
				"-10 dB",
				"-9 dB",
				"-8 dB",
				"-7 dB",
				"-6 dB",
				"-5 dB",
				"-4 dB",
				"-3 dB",
				"-2 dB",
				"-1 dB",
				"0 dB",
				"1 dB",
				"2 dB",
				"3 dB",
				"4 dB",
				"5 dB",
				"6 dB",
				"7 dB",
				"8 dB",
				"9 dB"
			});
			this.m_cboRFLoopBackGainIndex.Location = new Point(473, 66);
			this.m_cboRFLoopBackGainIndex.Margin = new Padding(4);
			this.m_cboRFLoopBackGainIndex.Name = "m_cboRFLoopBackGainIndex";
			this.m_cboRFLoopBackGainIndex.Size = new Size(131, 24);
			this.m_cboRFLoopBackGainIndex.TabIndex = 8;
			this.f00025e.AutoSize = true;
			this.f00025e.Location = new Point(180, 66);
			this.f00025e.Margin = new Padding(4);
			this.f00025e.Name = "m_ChkRFPSLoopBackEnable";
			this.f00025e.Size = new Size(18, 17);
			this.f00025e.TabIndex = 6;
			this.f00025e.UseVisualStyleBackColor = true;
			this.m_nudRFPSLoopBackFreq.Location = new Point(180, 30);
			this.m_nudRFPSLoopBackFreq.Margin = new Padding(4);
			NumericUpDown nudRFPSLoopBackFreq = this.m_nudRFPSLoopBackFreq;
			int[] array2 = new int[4];
			array2[0] = 32768;
			nudRFPSLoopBackFreq.Maximum = new decimal(array2);
			this.m_nudRFPSLoopBackFreq.Name = "m_nudRFPSLoopBackFreq";
			this.m_nudRFPSLoopBackFreq.Size = new Size(132, 22);
			this.m_nudRFPSLoopBackFreq.TabIndex = 5;
			this.f00025f.Location = new Point(180, 111);
			this.f00025f.Margin = new Padding(4);
			this.f00025f.Name = "m_btnRFPSLoopBackSet";
			this.f00025f.Size = new Size(100, 43);
			this.f00025f.TabIndex = 4;
			this.f00025f.Text = "Set";
			this.f00025f.UseVisualStyleBackColor = true;
			this.f00025f.Click += this.m000075;
			this.label6.AutoSize = true;
			this.label6.Location = new Point(329, 66);
			this.label6.Margin = new Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new Size(108, 17);
			this.label6.TabIndex = 3;
			this.label6.Text = "PGA Gain Index";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(329, 30);
			this.label5.Margin = new Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(106, 17);
			this.label5.TabIndex = 2;
			this.label5.Text = "LoopBack TXID";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(12, 66);
			this.label4.Margin = new Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(119, 17);
			this.label4.TabIndex = 1;
			this.label4.Text = "LoopBack Enable";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(12, 30);
			this.label3.Margin = new Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(144, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "LoopBack Freq (KHz)";
			this.f00025b.Controls.Add(this.m_nudRFIFLoopBackFreq);
			this.f00025b.Controls.Add(this.f000260);
			this.f00025b.Controls.Add(this.f000261);
			this.f00025b.Controls.Add(this.label7);
			this.f00025b.Controls.Add(this.label8);
			this.f00025b.Location = new Point(1028, 55);
			this.f00025b.Margin = new Padding(4);
			this.f00025b.Name = "m_grpRFIFLoopBackCfg";
			this.f00025b.Padding = new Padding(4);
			this.f00025b.Size = new Size(395, 175);
			this.f00025b.TabIndex = 2;
			this.f00025b.TabStop = false;
			this.f00025b.Text = "IF LoopBack Configuration";
			this.f00025b.Enter += this.m000077;
			this.m_nudRFIFLoopBackFreq.DropDownStyle = ComboBoxStyle.DropDownList;
			this.m_nudRFIFLoopBackFreq.FormattingEnabled = true;
			this.m_nudRFIFLoopBackFreq.Items.AddRange(new object[]
			{
				"180 KHz",
				"240 KHz",
				"360 KHz",
				"720 KHz",
				"1 MHz",
				"2 MHz",
				"2.5 MHz",
				"3 MHz",
				"4.02 MHz",
				"5 MHz",
				"6 MHz",
				"8.03 MHz",
				"9 MHz",
				"10 MHz"
			});
			this.m_nudRFIFLoopBackFreq.Location = new Point(217, 30);
			this.m_nudRFIFLoopBackFreq.Margin = new Padding(4);
			this.m_nudRFIFLoopBackFreq.Name = "m_nudRFIFLoopBackFreq";
			this.m_nudRFIFLoopBackFreq.Size = new Size(160, 24);
			this.m_nudRFIFLoopBackFreq.TabIndex = 6;
			this.f000260.AutoSize = true;
			this.f000260.Location = new Point(217, 73);
			this.f000260.Margin = new Padding(4);
			this.f000260.Name = "m_ChkRFIFLoopBackEnable";
			this.f000260.Size = new Size(18, 17);
			this.f000260.TabIndex = 5;
			this.f000260.UseVisualStyleBackColor = true;
			this.f000261.Location = new Point(217, 111);
			this.f000261.Margin = new Padding(4);
			this.f000261.Name = "m_btnRFIFLoopBackSet";
			this.f000261.Size = new Size(100, 43);
			this.f000261.TabIndex = 4;
			this.f000261.Text = "Set";
			this.f000261.UseVisualStyleBackColor = true;
			this.f000261.Click += this.m000076;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(35, 73);
			this.label7.Margin = new Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(119, 17);
			this.label7.TabIndex = 3;
			this.label7.Text = "LoopBack Enable";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(35, 36);
			this.label8.Margin = new Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(146, 17);
			this.label8.TabIndex = 2;
			this.label8.Text = "LoopBack Freq (MHz)";
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.f00025b);
			base.Controls.Add(this.f00025a);
			base.Controls.Add(this.f000259);
			base.Margin = new Padding(4);
			base.Name = "LoopBack";
			base.Size = new Size(1453, 583);
			this.f000259.ResumeLayout(false);
			this.f000259.PerformLayout();
			((ISupportInitialize)this.m_nudRFPALoopBackFreq).EndInit();
			this.f00025a.ResumeLayout(false);
			this.f00025a.PerformLayout();
			((ISupportInitialize)this.m_nudRFPSLoopBackFreq).EndInit();
			this.f00025b.ResumeLayout(false);
			this.f00025b.PerformLayout();
			base.ResumeLayout(false);
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		private RFPALoopBackConfigParams m_RFPALoopBackConfigParams;

		private RFPSLoopBackConfigParams m_RFPSLoopBackConfigParams;

		private RFIFLoopBackConfigParams m_RFIFLoopBackConfigParams;

		private IContainer components;

		private GroupBox f000259;

		private GroupBox f00025a;

		private GroupBox f00025b;

		private CheckBox f00025c;

		private Button f00025d;

		private Label label2;

		private Label label1;

		private NumericUpDown m_nudRFPALoopBackFreq;

		private CheckBox f00025e;

		private NumericUpDown m_nudRFPSLoopBackFreq;

		private Button f00025f;

		private Label label6;

		private Label label5;

		private Label label4;

		private Label label3;

		private CheckBox f000260;

		private Button f000261;

		private Label label7;

		private Label label8;

		private ComboBox m_cboRFLoopBackGainIndex;

		private ComboBox m_nudRFIFLoopBackFreq;

		private CheckBox f000262;

		private CheckBox f000263;
	}
}
