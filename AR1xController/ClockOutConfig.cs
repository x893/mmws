using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class ClockOutConfig : UserControl
	{
		public ClockOutConfig()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_PMICClockOutConfigParams = this.m_GuiManager.TsParams.PMICClockOutConfigParams;
			this.m_MCUClockOutConfigParams = this.m_GuiManager.TsParams.MCUClockOutConfigParams;
			this.m_cboModeSelect.SelectedIndex = 0;
			this.m_cboMCUClockSelect.SelectedIndex = 0;
			this.f000174.SelectedIndex = 0;
		}

		private int iSetPMICClockOutConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iPMICClockOutConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetPMICClockOutConfig()
		{
			this.iSetPMICClockOutConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetPMICClockOutConfigAsync()
		{
			new del_v_v(this.iSetPMICClockOutConfig).BeginInvoke(null, null);
		}

		private void m000012(object sender, EventArgs p1)
		{
			this.iSetPMICClockOutConfigAsync();
		}

		public bool UpdatePMICClockOutConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdatePMICClockOutConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_PMICClockOutConfigParams.PMICClockControl = (byte)(this.f000173.Checked ? 1 : 0);
				if (this.f000174.SelectedIndex == 0)
				{
					this.m_PMICClockOutConfigParams.PMICClockSrc = 0;
				}
				else if (this.f000174.SelectedIndex == 1)
				{
					this.m_PMICClockOutConfigParams.PMICClockSrc = 2;
				}
				this.m_PMICClockOutConfigParams.SrcClockDiv = (byte)this.m_nudSrcClockDiv.Value;
				this.m_PMICClockOutConfigParams.ModeSelect = (byte)this.m_cboModeSelect.SelectedIndex;
				this.m_PMICClockOutConfigParams.FreqSlope = (uint)this.m_nudFreqSlope.Value;
				this.m_PMICClockOutConfigParams.MinNDivVal = (byte)this.m_nudMinNDivVal.Value;
				this.m_PMICClockOutConfigParams.MaxNDivVal = (byte)this.m_nudMaxNDivVal.Value;
				this.m_PMICClockOutConfigParams.ClockDitherEna = (byte)(this.m_chkClockDitherEn.Checked ? 1 : 0);
				this.m_PMICClockOutConfigParams.Reserved = 0;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdatePMICClockOutConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdatePMICClockOutConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.f000173.Checked = (this.m_PMICClockOutConfigParams.PMICClockControl == 1);
				if (this.m_PMICClockOutConfigParams.PMICClockSrc == 0)
				{
					this.f000174.SelectedIndex = 0;
				}
				else if (this.m_PMICClockOutConfigParams.PMICClockSrc == 2)
				{
					this.f000174.SelectedIndex = 1;
				}
				this.m_nudSrcClockDiv.Value = this.m_PMICClockOutConfigParams.SrcClockDiv;
				this.m_cboModeSelect.SelectedIndex = (int)this.m_PMICClockOutConfigParams.ModeSelect;
				this.m_nudFreqSlope.Value = this.m_PMICClockOutConfigParams.FreqSlope;
				this.m_nudMinNDivVal.Value = this.m_PMICClockOutConfigParams.MinNDivVal;
				this.m_nudMaxNDivVal.Value = this.m_PMICClockOutConfigParams.MaxNDivVal;
				this.m_chkClockDitherEn.Checked = (this.m_PMICClockOutConfigParams.ClockDitherEna == 1);
				this.m_PMICClockOutConfigParams.Reserved = 0;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetMCUClockOutConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iMCUClockOutConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetMCUClockOutConfig()
		{
			this.iSetMCUClockOutConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetMCUClockOutConfigAsync()
		{
			new del_v_v(this.iSetMCUClockOutConfig).BeginInvoke(null, null);
		}

		private void m_btnMCUClockOutCfg_Click(object sender, EventArgs p1)
		{
			this.iSetMCUClockOutConfigAsync();
		}

		public bool UpdateMCUClockOutConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateMCUClockOutConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_MCUClockOutConfigParams.MCUClockControl = (byte)(this.m_chkMCUClockCtl.Checked ? 1 : 0);
				if (this.m_cboMCUClockSelect.SelectedIndex == 0)
				{
					this.m_MCUClockOutConfigParams.MCUClockSrc = 0;
				}
				else if (this.m_cboMCUClockSelect.SelectedIndex == 1)
				{
					this.m_MCUClockOutConfigParams.MCUClockSrc = 2;
				}
				this.m_MCUClockOutConfigParams.SrcClockDiv = (byte)this.m_nudMCUSrcClockDiv.Value;
				this.m_MCUClockOutConfigParams.Reserved = 0;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateMCUClockOutConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateMCUClockOutConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_chkMCUClockCtl.Checked = (this.m_MCUClockOutConfigParams.MCUClockControl == 1);
				if (this.m_MCUClockOutConfigParams.MCUClockSrc == 0)
				{
					this.m_cboMCUClockSelect.SelectedIndex = 0;
				}
				else if (this.m_MCUClockOutConfigParams.MCUClockSrc == 2)
				{
					this.m_cboMCUClockSelect.SelectedIndex = 1;
				}
				this.m_nudMCUSrcClockDiv.Value = this.m_MCUClockOutConfigParams.SrcClockDiv;
				this.m_MCUClockOutConfigParams.Reserved = 0;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public void DisableEnableBothPMICAndMCUClockoutConfig_BasedOn_RadarDevice()
		{
			if (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR2243Device)
			{
				this.f000171.Enabled = true;
				this.m_grpMCUClockOutConfig.Enabled = true;
				return;
			}
			if (GlobalRef.g_AR16xxDevice || GlobalRef.g_AR1843Device || GlobalRef.g_AR6843Device)
			{
				this.f000171.Enabled = false;
				this.m_grpMCUClockOutConfig.Enabled = false;
			}
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
			this.f000171 = new GroupBox();
			this.f000174 = new ComboBox();
			this.f000172 = new Button();
			this.m_nudMaxNDivVal = new NumericUpDown();
			this.m_chkClockDitherEn = new CheckBox();
			this.m_cboModeSelect = new ComboBox();
			this.m_nudMinNDivVal = new NumericUpDown();
			this.m_nudFreqSlope = new NumericUpDown();
			this.m_nudSrcClockDiv = new NumericUpDown();
			this.f000173 = new CheckBox();
			this.label8 = new Label();
			this.label9 = new Label();
			this.label10 = new Label();
			this.label5 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.m_grpMCUClockOutConfig = new GroupBox();
			this.m_cboMCUClockSelect = new ComboBox();
			this.m_chkMCUClockCtl = new CheckBox();
			this.m_btnMCUClockOutCfg = new Button();
			this.m_nudMCUSrcClockDiv = new NumericUpDown();
			this.label18 = new Label();
			this.label19 = new Label();
			this.label20 = new Label();
			this.f000171.SuspendLayout();
			((ISupportInitialize)this.m_nudMaxNDivVal).BeginInit();
			((ISupportInitialize)this.m_nudMinNDivVal).BeginInit();
			((ISupportInitialize)this.m_nudFreqSlope).BeginInit();
			((ISupportInitialize)this.m_nudSrcClockDiv).BeginInit();
			this.m_grpMCUClockOutConfig.SuspendLayout();
			((ISupportInitialize)this.m_nudMCUSrcClockDiv).BeginInit();
			base.SuspendLayout();
			this.f000171.Controls.Add(this.f000174);
			this.f000171.Controls.Add(this.f000172);
			this.f000171.Controls.Add(this.m_nudMaxNDivVal);
			this.f000171.Controls.Add(this.m_chkClockDitherEn);
			this.f000171.Controls.Add(this.m_cboModeSelect);
			this.f000171.Controls.Add(this.m_nudMinNDivVal);
			this.f000171.Controls.Add(this.m_nudFreqSlope);
			this.f000171.Controls.Add(this.m_nudSrcClockDiv);
			this.f000171.Controls.Add(this.f000173);
			this.f000171.Controls.Add(this.label8);
			this.f000171.Controls.Add(this.label9);
			this.f000171.Controls.Add(this.label10);
			this.f000171.Controls.Add(this.label5);
			this.f000171.Controls.Add(this.label4);
			this.f000171.Controls.Add(this.label3);
			this.f000171.Controls.Add(this.label2);
			this.f000171.Controls.Add(this.label1);
			this.f000171.Location = new Point(13, 16);
			this.f000171.Name = "m_grpPMICClockOutConfig";
			this.f000171.Size = new Size(249, 329);
			this.f000171.TabIndex = 0;
			this.f000171.TabStop = false;
			this.f000171.Text = "PMIC Clock Out Configuration";
			this.f000174.DropDownStyle = ComboBoxStyle.DropDownList;
			this.f000174.FormattingEnabled = true;
			this.f000174.Items.AddRange(new object[]
			{
				"XTAL",
				"PLL-600"
			});
			this.f000174.Location = new Point(116, 50);
			this.f000174.Name = "m_cboPMICClockSelect";
			this.f000174.Size = new Size(66, 21);
			this.f000174.TabIndex = 19;
			this.f000172.Location = new Point(116, 263);
			this.f000172.Name = "m_btnPMICClockOutCfg";
			this.f000172.Size = new Size(66, 31);
			this.f000172.TabIndex = 18;
			this.f000172.Text = "Set";
			this.f000172.UseVisualStyleBackColor = true;
			this.f000172.Click += this.m000012;
			this.m_nudMaxNDivVal.Location = new Point(116, 204);
			NumericUpDown nudMaxNDivVal = this.m_nudMaxNDivVal;
			int[] array = new int[4];
			array[0] = 255;
			nudMaxNDivVal.Maximum = new decimal(array);
			this.m_nudMaxNDivVal.Name = "m_nudMaxNDivVal";
			this.m_nudMaxNDivVal.Size = new Size(66, 20);
			this.m_nudMaxNDivVal.TabIndex = 17;
			this.m_chkClockDitherEn.AutoSize = true;
			this.m_chkClockDitherEn.Location = new Point(116, 238);
			this.m_chkClockDitherEn.Name = "m_chkClockDitherEn";
			this.m_chkClockDitherEn.Size = new Size(15, 14);
			this.m_chkClockDitherEn.TabIndex = 16;
			this.m_chkClockDitherEn.UseVisualStyleBackColor = true;
			this.m_cboModeSelect.DropDownStyle = ComboBoxStyle.DropDownList;
			this.m_cboModeSelect.FormattingEnabled = true;
			this.m_cboModeSelect.Items.AddRange(new object[]
			{
				"Cont Mode",
				"Chirpmode"
			});
			this.m_cboModeSelect.Location = new Point(116, 111);
			this.m_cboModeSelect.Name = "m_cboModeSelect";
			this.m_cboModeSelect.Size = new Size(66, 21);
			this.m_cboModeSelect.TabIndex = 15;
			this.m_nudMinNDivVal.Location = new Point(116, 174);
			NumericUpDown nudMinNDivVal = this.m_nudMinNDivVal;
			int[] array2 = new int[4];
			array2[0] = 255;
			nudMinNDivVal.Maximum = new decimal(array2);
			this.m_nudMinNDivVal.Name = "m_nudMinNDivVal";
			this.m_nudMinNDivVal.Size = new Size(66, 20);
			this.m_nudMinNDivVal.TabIndex = 14;
			this.m_nudFreqSlope.Location = new Point(116, 144);
			NumericUpDown nudFreqSlope = this.m_nudFreqSlope;
			int[] array3 = new int[4];
			array3[0] = -1;
			nudFreqSlope.Maximum = new decimal(array3);
			this.m_nudFreqSlope.Name = "m_nudFreqSlope";
			this.m_nudFreqSlope.Size = new Size(66, 20);
			this.m_nudFreqSlope.TabIndex = 13;
			this.m_nudSrcClockDiv.Location = new Point(116, 81);
			NumericUpDown nudSrcClockDiv = this.m_nudSrcClockDiv;
			int[] array4 = new int[4];
			array4[0] = 255;
			nudSrcClockDiv.Maximum = new decimal(array4);
			this.m_nudSrcClockDiv.Name = "m_nudSrcClockDiv";
			this.m_nudSrcClockDiv.Size = new Size(66, 20);
			this.m_nudSrcClockDiv.TabIndex = 12;
			this.f000173.AutoSize = true;
			this.f000173.Location = new Point(116, 25);
			this.f000173.Name = "m_chkPMICClockCtl";
			this.f000173.Size = new Size(15, 14);
			this.f000173.TabIndex = 10;
			this.f000173.UseVisualStyleBackColor = true;
			this.label8.AutoSize = true;
			this.label8.Location = new Point(15, 238);
			this.label8.Name = "label8";
			this.label8.Size = new Size(81, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Clock Dither En";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(15, 208);
			this.label9.Name = "label9";
			this.label9.Size = new Size(70, 13);
			this.label9.TabIndex = 6;
			this.label9.Text = "Max Ndiv Val";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(15, 178);
			this.label10.Name = "label10";
			this.label10.Size = new Size(67, 13);
			this.label10.TabIndex = 5;
			this.label10.Text = "Min Ndiv Val";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(15, 148);
			this.label5.Name = "label5";
			this.label5.Size = new Size(58, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Freq Slope";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(15, 116);
			this.label4.Name = "label4";
			this.label4.Size = new Size(67, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Mode Select";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(15, 85);
			this.label3.Name = "label3";
			this.label3.Size = new Size(72, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Src Clock Div";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(15, 55);
			this.label2.Name = "label2";
			this.label2.Size = new Size(82, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "PMIC Clock Src";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(15, 25);
			this.label1.Name = "label1";
			this.label1.Size = new Size(94, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "PMIC Clock Ctl En";
			this.m_grpMCUClockOutConfig.Controls.Add(this.m_cboMCUClockSelect);
			this.m_grpMCUClockOutConfig.Controls.Add(this.m_chkMCUClockCtl);
			this.m_grpMCUClockOutConfig.Controls.Add(this.m_btnMCUClockOutCfg);
			this.m_grpMCUClockOutConfig.Controls.Add(this.m_nudMCUSrcClockDiv);
			this.m_grpMCUClockOutConfig.Controls.Add(this.label18);
			this.m_grpMCUClockOutConfig.Controls.Add(this.label19);
			this.m_grpMCUClockOutConfig.Controls.Add(this.label20);
			this.m_grpMCUClockOutConfig.Location = new Point(296, 16);
			this.m_grpMCUClockOutConfig.Name = "m_grpMCUClockOutConfig";
			this.m_grpMCUClockOutConfig.Size = new Size(224, 164);
			this.m_grpMCUClockOutConfig.TabIndex = 1;
			this.m_grpMCUClockOutConfig.TabStop = false;
			this.m_grpMCUClockOutConfig.Text = "MCU Clock Out Configuration";
			this.m_cboMCUClockSelect.DropDownStyle = ComboBoxStyle.DropDownList;
			this.m_cboMCUClockSelect.FormattingEnabled = true;
			this.m_cboMCUClockSelect.Items.AddRange(new object[]
			{
				"XTAL",
				"PLL-600"
			});
			this.m_cboMCUClockSelect.Location = new Point(121, 48);
			this.m_cboMCUClockSelect.Name = "m_cboMCUClockSelect";
			this.m_cboMCUClockSelect.Size = new Size(66, 21);
			this.m_cboMCUClockSelect.TabIndex = 25;
			this.m_chkMCUClockCtl.AutoSize = true;
			this.m_chkMCUClockCtl.Location = new Point(121, 25);
			this.m_chkMCUClockCtl.Name = "m_chkMCUClockCtl";
			this.m_chkMCUClockCtl.Size = new Size(15, 14);
			this.m_chkMCUClockCtl.TabIndex = 24;
			this.m_chkMCUClockCtl.UseVisualStyleBackColor = true;
			this.m_btnMCUClockOutCfg.Location = new Point(121, 120);
			this.m_btnMCUClockOutCfg.Name = "m_btnMCUClockOutCfg";
			this.m_btnMCUClockOutCfg.Size = new Size(66, 30);
			this.m_btnMCUClockOutCfg.TabIndex = 23;
			this.m_btnMCUClockOutCfg.Text = "Set";
			this.m_btnMCUClockOutCfg.UseVisualStyleBackColor = true;
			this.m_btnMCUClockOutCfg.Click += this.m_btnMCUClockOutCfg_Click;
			this.m_nudMCUSrcClockDiv.Location = new Point(121, 79);
			NumericUpDown nudMCUSrcClockDiv = this.m_nudMCUSrcClockDiv;
			int[] array5 = new int[4];
			array5[0] = 255;
			nudMCUSrcClockDiv.Maximum = new decimal(array5);
			this.m_nudMCUSrcClockDiv.Name = "m_nudMCUSrcClockDiv";
			this.m_nudMCUSrcClockDiv.Size = new Size(66, 20);
			this.m_nudMCUSrcClockDiv.TabIndex = 21;
			this.label18.AutoSize = true;
			this.label18.Location = new Point(17, 86);
			this.label18.Name = "label18";
			this.label18.Size = new Size(72, 13);
			this.label18.TabIndex = 12;
			this.label18.Text = "Src Clock Div";
			this.label19.AutoSize = true;
			this.label19.Location = new Point(17, 52);
			this.label19.Name = "label19";
			this.label19.Size = new Size(80, 13);
			this.label19.TabIndex = 11;
			this.label19.Text = "MCU Clock Src";
			this.label20.AutoSize = true;
			this.label20.Location = new Point(17, 25);
			this.label20.Name = "label20";
			this.label20.Size = new Size(92, 13);
			this.label20.TabIndex = 10;
			this.label20.Text = "MCU Clock Ctl En";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.m_grpMCUClockOutConfig);
			base.Controls.Add(this.f000171);
			base.Name = "ClockOutConfig";
			base.Size = new Size(896, 461);
			this.f000171.ResumeLayout(false);
			this.f000171.PerformLayout();
			((ISupportInitialize)this.m_nudMaxNDivVal).EndInit();
			((ISupportInitialize)this.m_nudMinNDivVal).EndInit();
			((ISupportInitialize)this.m_nudFreqSlope).EndInit();
			((ISupportInitialize)this.m_nudSrcClockDiv).EndInit();
			this.m_grpMCUClockOutConfig.ResumeLayout(false);
			this.m_grpMCUClockOutConfig.PerformLayout();
			((ISupportInitialize)this.m_nudMCUSrcClockDiv).EndInit();
			base.ResumeLayout(false);
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		public PMICClockOutConfigParams m_PMICClockOutConfigParams;

		public MCUClockOutConfigParams m_MCUClockOutConfigParams;

		private IContainer components;

		private GroupBox f000171;

		private GroupBox m_grpMCUClockOutConfig;

		private Button f000172;

		private NumericUpDown m_nudMaxNDivVal;

		private CheckBox m_chkClockDitherEn;

		private ComboBox m_cboModeSelect;

		private NumericUpDown m_nudMinNDivVal;

		private NumericUpDown m_nudFreqSlope;

		private NumericUpDown m_nudSrcClockDiv;

		private CheckBox f000173;

		private Label label8;

		private Label label9;

		private Label label10;

		private Label label5;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label label1;

		private CheckBox m_chkMCUClockCtl;

		private Button m_btnMCUClockOutCfg;

		private NumericUpDown m_nudMCUSrcClockDiv;

		private Label label18;

		private Label label19;

		private Label label20;

		private ComboBox m_cboMCUClockSelect;

		private ComboBox f000174;
	}
}
