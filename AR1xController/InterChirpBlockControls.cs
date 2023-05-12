using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class InterChirpBlockControls : UserControl
	{
		public InterChirpBlockControls()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_InterChirpBlockControlsConfigParams = this.m_GuiManager.TsParams.InterChirpBlockControlsConfigParams;
		}

		private int iSetInterChirpBlockControlsConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iInterChirpBlockControlsConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetInterChirpBlockControlsConfig()
		{
			this.iSetInterChirpBlockControlsConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetInterChirpBlockControlsConfigAsync()
		{
			new del_v_v(this.iSetInterChirpBlockControlsConfig).BeginInvoke(null, null);
		}

		private void m_btnInterChirpBlockControlsCfg_Click(object sender, EventArgs p1)
		{
			this.iSetInterChirpBlockControlsConfigAsync();
		}

		public bool UpdateInterChirpBlockControlsConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateInterChirpBlockControlsConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_InterChirpBlockControlsConfigParams.Rx02RFTurnOffTime = (double)this.m_nudRx02RFTurnOffTime.Value;
				this.m_InterChirpBlockControlsConfigParams.Rx13RFTurnOffTime = (double)this.m_nudRx13RFTurnOffTime.Value;
				this.m_InterChirpBlockControlsConfigParams.Rx02BBTurnOffTime = (double)this.m_nudRx02BBTurnOffTime.Value;
				this.m_InterChirpBlockControlsConfigParams.Rx13BBTurnOffTime = (double)this.m_nudRx13BBTurnOffTime.Value;
				this.m_InterChirpBlockControlsConfigParams.Rx02RFPreEnableTime = (double)this.m_nudRx02RFPreEnableTime.Value;
				this.m_InterChirpBlockControlsConfigParams.Rx24RFPreEnableTime = (double)this.m_nudRx24RFPreEnableTime.Value;
				this.m_InterChirpBlockControlsConfigParams.Rx02BBPreEnableTime = (double)this.m_nudRx02BBPreEnableTime.Value;
				this.m_InterChirpBlockControlsConfigParams.Rx13BBPreEnableTime = (double)this.m_nudRx13BBPreEnableTime.Value;
				this.m_InterChirpBlockControlsConfigParams.Rx02RFTurnOnTime = (double)this.m_nudRx02RFTurnOnTime.Value;
				this.m_InterChirpBlockControlsConfigParams.Rx13RFTurnOnTime = (double)this.m_nudRx13RFTurnOnTime.Value;
				this.m_InterChirpBlockControlsConfigParams.Rx02BBTurnOnTime = (double)this.m_nudRx02BBTurnOnTime.Value;
				this.m_InterChirpBlockControlsConfigParams.Rx13BBTurnOnTime = (double)this.m_nudRx13BBTurnOnTime.Value;
				this.m_InterChirpBlockControlsConfigParams.RxLOChainTurnOffTime = (double)this.m_nudRxLOChainTurnOffTime.Value;
				this.m_InterChirpBlockControlsConfigParams.TxLOChainTurnOffTime = (double)this.m_nudTxLOChainTurnOffTime.Value;
				this.m_InterChirpBlockControlsConfigParams.RxLOChainTurnOnTime = (double)this.m_nudRxLOChainTurnOnTime.Value;
				this.m_InterChirpBlockControlsConfigParams.TxLOChainTurnOnTime = (double)this.m_nudTxLOChainTurnOnTime.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateInterChirpCtlConfig(RootObject jobject, int p1)
		{
			bool result;
			try
			{
				if (jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.isConfigured == 0)
				{
					string msg = string.Format("Missing Inter Chirp Block Control Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg);
				}
				else
				{
					this.m_nudRx02RFTurnOffTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02RfTurnOffTime_us;
					this.m_nudRx13RFTurnOffTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx13RfTurnOffTime_us;
					this.m_nudRx02BBTurnOffTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02BbTurnOffTime_us;
					this.m_nudRx13BBTurnOffTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx12BbTurnOffTime_us;
					this.m_nudRx02RFPreEnableTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02RfPreEnTime_us;
					this.m_nudRx24RFPreEnableTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx13RfPreEnTime_us;
					this.m_nudRx02BBPreEnableTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02BbPreEnTime_us;
					this.m_nudRx13BBPreEnableTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx13BbPreEnTime_us;
					this.m_nudRx02RFTurnOnTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02RfTurnOnTime_us;
					this.m_nudRx13RFTurnOnTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx13RfTurnOnTime_us;
					this.m_nudRx02BBTurnOnTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx02BbTurnOnTime_us;
					this.m_nudRx13BBTurnOnTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rx13BbTurnOnTime_us;
					this.m_nudRxLOChainTurnOffTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rxLoChainTurnOffTime_us;
					this.m_nudTxLOChainTurnOffTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.txLoChainTurnOffTime_us;
					this.m_nudRxLOChainTurnOnTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.rxLoChainTurnOnTime_us;
					this.m_nudTxLOChainTurnOnTime.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlInterChirpBlkCtrlCfg_t.txLoChainTurnOnTime_us;
				}
				result = true;
			}
			catch
			{
				string msg2 = string.Format("Inter chirp Block Control Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg2);
				result = false;
			}
			return result;
		}

		public bool UpdateInterChirpBlockControlsConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateInterChirpBlockControlsConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudRx02RFTurnOffTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx02RFTurnOffTime;
				this.m_nudRx13RFTurnOffTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx13RFTurnOffTime;
				this.m_nudRx02BBTurnOffTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx02BBTurnOffTime;
				this.m_nudRx13BBTurnOffTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx13BBTurnOffTime;
				this.m_nudRx02RFPreEnableTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx02RFPreEnableTime;
				this.m_nudRx24RFPreEnableTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx24RFPreEnableTime;
				this.m_nudRx02BBPreEnableTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx02BBPreEnableTime;
				this.m_nudRx13BBPreEnableTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx13BBPreEnableTime;
				this.m_nudRx02RFTurnOnTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx02RFTurnOnTime;
				this.m_nudRx13RFTurnOnTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx13RFTurnOnTime;
				this.m_nudRx02BBTurnOnTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx02BBTurnOnTime;
				this.m_nudRx13BBTurnOnTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.Rx13BBTurnOnTime;
				this.m_nudRxLOChainTurnOffTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.RxLOChainTurnOffTime;
				this.m_nudTxLOChainTurnOffTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.TxLOChainTurnOffTime;
				this.m_nudRxLOChainTurnOnTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.RxLOChainTurnOnTime;
				this.m_nudTxLOChainTurnOnTime.Value = (decimal)this.m_InterChirpBlockControlsConfigParams.TxLOChainTurnOnTime;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
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
			this.groupBox1 = new GroupBox();
			this.m_nudTxLOChainTurnOnTime = new NumericUpDown();
			this.m_nudRxLOChainTurnOnTime = new NumericUpDown();
			this.m_nudTxLOChainTurnOffTime = new NumericUpDown();
			this.m_nudRxLOChainTurnOffTime = new NumericUpDown();
			this.m_nudRx13BBTurnOnTime = new NumericUpDown();
			this.m_nudRx02BBTurnOnTime = new NumericUpDown();
			this.m_nudRx13RFTurnOnTime = new NumericUpDown();
			this.m_nudRx02RFTurnOnTime = new NumericUpDown();
			this.m_nudRx13BBPreEnableTime = new NumericUpDown();
			this.m_nudRx02BBPreEnableTime = new NumericUpDown();
			this.m_nudRx24RFPreEnableTime = new NumericUpDown();
			this.m_nudRx02RFPreEnableTime = new NumericUpDown();
			this.m_nudRx13BBTurnOffTime = new NumericUpDown();
			this.m_nudRx02BBTurnOffTime = new NumericUpDown();
			this.m_nudRx13RFTurnOffTime = new NumericUpDown();
			this.m_nudRx02RFTurnOffTime = new NumericUpDown();
			this.label13 = new Label();
			this.label14 = new Label();
			this.label15 = new Label();
			this.label16 = new Label();
			this.label9 = new Label();
			this.label10 = new Label();
			this.label11 = new Label();
			this.label12 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this.label8 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.m_btnInterChirpBlockControlsCfg = new Button();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.m_nudTxLOChainTurnOnTime).BeginInit();
			((ISupportInitialize)this.m_nudRxLOChainTurnOnTime).BeginInit();
			((ISupportInitialize)this.m_nudTxLOChainTurnOffTime).BeginInit();
			((ISupportInitialize)this.m_nudRxLOChainTurnOffTime).BeginInit();
			((ISupportInitialize)this.m_nudRx13BBTurnOnTime).BeginInit();
			((ISupportInitialize)this.m_nudRx02BBTurnOnTime).BeginInit();
			((ISupportInitialize)this.m_nudRx13RFTurnOnTime).BeginInit();
			((ISupportInitialize)this.m_nudRx02RFTurnOnTime).BeginInit();
			((ISupportInitialize)this.m_nudRx13BBPreEnableTime).BeginInit();
			((ISupportInitialize)this.m_nudRx02BBPreEnableTime).BeginInit();
			((ISupportInitialize)this.m_nudRx24RFPreEnableTime).BeginInit();
			((ISupportInitialize)this.m_nudRx02RFPreEnableTime).BeginInit();
			((ISupportInitialize)this.m_nudRx13BBTurnOffTime).BeginInit();
			((ISupportInitialize)this.m_nudRx02BBTurnOffTime).BeginInit();
			((ISupportInitialize)this.m_nudRx13RFTurnOffTime).BeginInit();
			((ISupportInitialize)this.m_nudRx02RFTurnOffTime).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.m_nudTxLOChainTurnOnTime);
			this.groupBox1.Controls.Add(this.m_nudRxLOChainTurnOnTime);
			this.groupBox1.Controls.Add(this.m_nudTxLOChainTurnOffTime);
			this.groupBox1.Controls.Add(this.m_nudRxLOChainTurnOffTime);
			this.groupBox1.Controls.Add(this.m_nudRx13BBTurnOnTime);
			this.groupBox1.Controls.Add(this.m_nudRx02BBTurnOnTime);
			this.groupBox1.Controls.Add(this.m_nudRx13RFTurnOnTime);
			this.groupBox1.Controls.Add(this.m_nudRx02RFTurnOnTime);
			this.groupBox1.Controls.Add(this.m_nudRx13BBPreEnableTime);
			this.groupBox1.Controls.Add(this.m_nudRx02BBPreEnableTime);
			this.groupBox1.Controls.Add(this.m_nudRx24RFPreEnableTime);
			this.groupBox1.Controls.Add(this.m_nudRx02RFPreEnableTime);
			this.groupBox1.Controls.Add(this.m_nudRx13BBTurnOffTime);
			this.groupBox1.Controls.Add(this.m_nudRx02BBTurnOffTime);
			this.groupBox1.Controls.Add(this.m_nudRx13RFTurnOffTime);
			this.groupBox1.Controls.Add(this.m_nudRx02RFTurnOffTime);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.m_btnInterChirpBlockControlsCfg);
			this.groupBox1.Location = new Point(13, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(333, 446);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Inter Chirp Block Controls Configuration";
			this.m_nudTxLOChainTurnOnTime.DecimalPlaces = 2;
			this.m_nudTxLOChainTurnOnTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudTxLOChainTurnOnTime.Location = new Point(223, 378);
			this.m_nudTxLOChainTurnOnTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudTxLOChainTurnOnTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudTxLOChainTurnOnTime.Name = "m_nudTxLOChainTurnOnTime";
			this.m_nudTxLOChainTurnOnTime.Size = new Size(77, 20);
			this.m_nudTxLOChainTurnOnTime.TabIndex = 33;
			this.m_nudTxLOChainTurnOnTime.Value = new decimal(new int[]
			{
				25,
				0,
				0,
				65536
			});
			this.m_nudRxLOChainTurnOnTime.DecimalPlaces = 2;
			this.m_nudRxLOChainTurnOnTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRxLOChainTurnOnTime.Location = new Point(223, 354);
			this.m_nudRxLOChainTurnOnTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRxLOChainTurnOnTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRxLOChainTurnOnTime.Name = "m_nudRxLOChainTurnOnTime";
			this.m_nudRxLOChainTurnOnTime.Size = new Size(77, 20);
			this.m_nudRxLOChainTurnOnTime.TabIndex = 32;
			this.m_nudRxLOChainTurnOnTime.Value = new decimal(new int[]
			{
				15,
				0,
				0,
				-2147418112
			});
			this.m_nudTxLOChainTurnOffTime.DecimalPlaces = 2;
			this.m_nudTxLOChainTurnOffTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudTxLOChainTurnOffTime.Location = new Point(223, 330);
			this.m_nudTxLOChainTurnOffTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudTxLOChainTurnOffTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudTxLOChainTurnOffTime.Name = "m_nudTxLOChainTurnOffTime";
			this.m_nudTxLOChainTurnOffTime.Size = new Size(77, 20);
			this.m_nudTxLOChainTurnOffTime.TabIndex = 31;
			this.m_nudTxLOChainTurnOffTime.Value = new decimal(new int[]
			{
				4,
				0,
				0,
				65536
			});
			this.m_nudRxLOChainTurnOffTime.DecimalPlaces = 2;
			this.m_nudRxLOChainTurnOffTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRxLOChainTurnOffTime.Location = new Point(223, 306);
			this.m_nudRxLOChainTurnOffTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRxLOChainTurnOffTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRxLOChainTurnOffTime.Name = "m_nudRxLOChainTurnOffTime";
			this.m_nudRxLOChainTurnOffTime.Size = new Size(77, 20);
			this.m_nudRxLOChainTurnOffTime.TabIndex = 30;
			this.m_nudRx13BBTurnOnTime.DecimalPlaces = 2;
			this.m_nudRx13BBTurnOnTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx13BBTurnOnTime.Location = new Point(223, 282);
			this.m_nudRx13BBTurnOnTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx13BBTurnOnTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx13BBTurnOnTime.Name = "m_nudRx13BBTurnOnTime";
			this.m_nudRx13BBTurnOnTime.Size = new Size(77, 20);
			this.m_nudRx13BBTurnOnTime.TabIndex = 29;
			this.m_nudRx13BBTurnOnTime.Value = new decimal(new int[]
			{
				5,
				0,
				0,
				65536
			});
			this.m_nudRx02BBTurnOnTime.DecimalPlaces = 2;
			this.m_nudRx02BBTurnOnTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx02BBTurnOnTime.Location = new Point(223, 258);
			this.m_nudRx02BBTurnOnTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx02BBTurnOnTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx02BBTurnOnTime.Name = "m_nudRx02BBTurnOnTime";
			this.m_nudRx02BBTurnOnTime.Size = new Size(77, 20);
			this.m_nudRx02BBTurnOnTime.TabIndex = 28;
			this.m_nudRx02BBTurnOnTime.Value = new decimal(new int[]
			{
				5,
				0,
				0,
				-2147418112
			});
			this.m_nudRx13RFTurnOnTime.DecimalPlaces = 2;
			this.m_nudRx13RFTurnOnTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx13RFTurnOnTime.Location = new Point(223, 234);
			this.m_nudRx13RFTurnOnTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx13RFTurnOnTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx13RFTurnOnTime.Name = "m_nudRx13RFTurnOnTime";
			this.m_nudRx13RFTurnOnTime.Size = new Size(77, 20);
			this.m_nudRx13RFTurnOnTime.TabIndex = 27;
			NumericUpDown nudRx13RFTurnOnTime = this.m_nudRx13RFTurnOnTime;
			int[] array = new int[4];
			array[0] = 1;
			nudRx13RFTurnOnTime.Value = new decimal(array);
			this.m_nudRx02RFTurnOnTime.DecimalPlaces = 2;
			this.m_nudRx02RFTurnOnTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx02RFTurnOnTime.Location = new Point(223, 210);
			this.m_nudRx02RFTurnOnTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx02RFTurnOnTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx02RFTurnOnTime.Name = "m_nudRx02RFTurnOnTime";
			this.m_nudRx02RFTurnOnTime.Size = new Size(77, 20);
			this.m_nudRx02RFTurnOnTime.TabIndex = 26;
			this.m_nudRx13BBPreEnableTime.DecimalPlaces = 2;
			this.m_nudRx13BBPreEnableTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx13BBPreEnableTime.Location = new Point(223, 186);
			this.m_nudRx13BBPreEnableTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx13BBPreEnableTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx13BBPreEnableTime.Name = "m_nudRx13BBPreEnableTime";
			this.m_nudRx13BBPreEnableTime.Size = new Size(77, 20);
			this.m_nudRx13BBPreEnableTime.TabIndex = 25;
			this.m_nudRx13BBPreEnableTime.Value = new decimal(new int[]
			{
				5,
				0,
				0,
				-2147418112
			});
			this.m_nudRx02BBPreEnableTime.DecimalPlaces = 2;
			this.m_nudRx02BBPreEnableTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx02BBPreEnableTime.Location = new Point(223, 162);
			this.m_nudRx02BBPreEnableTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx02BBPreEnableTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx02BBPreEnableTime.Name = "m_nudRx02BBPreEnableTime";
			this.m_nudRx02BBPreEnableTime.Size = new Size(77, 20);
			this.m_nudRx02BBPreEnableTime.TabIndex = 24;
			this.m_nudRx02BBPreEnableTime.Value = new decimal(new int[]
			{
				15,
				0,
				0,
				-2147418112
			});
			this.m_nudRx24RFPreEnableTime.DecimalPlaces = 2;
			this.m_nudRx24RFPreEnableTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx24RFPreEnableTime.Location = new Point(223, 138);
			this.m_nudRx24RFPreEnableTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx24RFPreEnableTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx24RFPreEnableTime.Name = "m_nudRx24RFPreEnableTime";
			this.m_nudRx24RFPreEnableTime.Size = new Size(77, 20);
			this.m_nudRx24RFPreEnableTime.TabIndex = 23;
			this.m_nudRx02RFPreEnableTime.DecimalPlaces = 2;
			this.m_nudRx02RFPreEnableTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx02RFPreEnableTime.Location = new Point(223, 114);
			this.m_nudRx02RFPreEnableTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx02RFPreEnableTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx02RFPreEnableTime.Name = "m_nudRx02RFPreEnableTime";
			this.m_nudRx02RFPreEnableTime.Size = new Size(77, 20);
			this.m_nudRx02RFPreEnableTime.TabIndex = 22;
			this.m_nudRx02RFPreEnableTime.Value = new decimal(new int[]
			{
				1,
				0,
				0,
				int.MinValue
			});
			this.m_nudRx13BBTurnOffTime.DecimalPlaces = 2;
			this.m_nudRx13BBTurnOffTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx13BBTurnOffTime.Location = new Point(223, 90);
			this.m_nudRx13BBTurnOffTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx13BBTurnOffTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx13BBTurnOffTime.Name = "m_nudRx13BBTurnOffTime";
			this.m_nudRx13BBTurnOffTime.Size = new Size(77, 20);
			this.m_nudRx13BBTurnOffTime.TabIndex = 21;
			NumericUpDown nudRx13BBTurnOffTime = this.m_nudRx13BBTurnOffTime;
			int[] array2 = new int[4];
			array2[0] = 2;
			nudRx13BBTurnOffTime.Value = new decimal(array2);
			this.m_nudRx02BBTurnOffTime.DecimalPlaces = 2;
			this.m_nudRx02BBTurnOffTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx02BBTurnOffTime.Location = new Point(223, 66);
			this.m_nudRx02BBTurnOffTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx02BBTurnOffTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx02BBTurnOffTime.Name = "m_nudRx02BBTurnOffTime";
			this.m_nudRx02BBTurnOffTime.Size = new Size(77, 20);
			this.m_nudRx02BBTurnOffTime.TabIndex = 20;
			this.m_nudRx02BBTurnOffTime.Value = new decimal(new int[]
			{
				16,
				0,
				0,
				65536
			});
			this.m_nudRx13RFTurnOffTime.DecimalPlaces = 2;
			this.m_nudRx13RFTurnOffTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx13RFTurnOffTime.Location = new Point(223, 42);
			this.m_nudRx13RFTurnOffTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx13RFTurnOffTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx13RFTurnOffTime.Name = "m_nudRx13RFTurnOffTime";
			this.m_nudRx13RFTurnOffTime.Size = new Size(77, 20);
			this.m_nudRx13RFTurnOffTime.TabIndex = 19;
			this.m_nudRx13RFTurnOffTime.Value = new decimal(new int[]
			{
				12,
				0,
				0,
				65536
			});
			this.m_nudRx02RFTurnOffTime.DecimalPlaces = 2;
			this.m_nudRx02RFTurnOffTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRx02RFTurnOffTime.Location = new Point(223, 18);
			this.m_nudRx02RFTurnOffTime.Maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				131072
			});
			this.m_nudRx02RFTurnOffTime.Minimum = new decimal(new int[]
			{
				1024,
				0,
				0,
				-2147352576
			});
			this.m_nudRx02RFTurnOffTime.Name = "m_nudRx02RFTurnOffTime";
			this.m_nudRx02RFTurnOffTime.Size = new Size(77, 20);
			this.m_nudRx02RFTurnOffTime.TabIndex = 18;
			this.m_nudRx02RFTurnOffTime.Value = new decimal(new int[]
			{
				8,
				0,
				0,
				65536
			});
			this.label13.AutoSize = true;
			this.label13.Location = new Point(8, 382);
			this.label13.Name = "label13";
			this.label13.Size = new Size(154, 13);
			this.label13.TabIndex = 17;
			this.label13.Text = "Tx LO Chain Turn On Time (µs)";
			this.label14.AutoSize = true;
			this.label14.Location = new Point(8, 358);
			this.label14.Name = "label14";
			this.label14.Size = new Size(155, 13);
			this.label14.TabIndex = 16;
			this.label14.Text = "Rx LO Chain Turn On Time (µs)";
			this.label15.AutoSize = true;
			this.label15.Location = new Point(8, 334);
			this.label15.Name = "label15";
			this.label15.Size = new Size(154, 13);
			this.label15.TabIndex = 15;
			this.label15.Text = "Tx LO Chain Turn Off Time (µs)";
			this.label16.AutoSize = true;
			this.label16.Location = new Point(8, 310);
			this.label16.Name = "label16";
			this.label16.Size = new Size(155, 13);
			this.label16.TabIndex = 14;
			this.label16.Text = "Rx LO Chain Turn Off Time (µs)";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(8, 286);
			this.label9.Name = "label9";
			this.label9.Size = new Size(137, 13);
			this.label9.TabIndex = 13;
			this.label9.Text = "Rx13 BB Turn On Time (µs)";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(8, 262);
			this.label10.Name = "label10";
			this.label10.Size = new Size(137, 13);
			this.label10.TabIndex = 12;
			this.label10.Text = "Rx02 BB Turn On Time (µs)";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(8, 238);
			this.label11.Name = "label11";
			this.label11.Size = new Size(137, 13);
			this.label11.TabIndex = 11;
			this.label11.Text = "Rx13 RF Turn On Time (µs)";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(8, 214);
			this.label12.Name = "label12";
			this.label12.Size = new Size(137, 13);
			this.label12.TabIndex = 10;
			this.label12.Text = "Rx02 RF Turn On Time (µs)";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(8, 190);
			this.label5.Name = "label5";
			this.label5.Size = new Size(150, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Rx13 BB Pre Enable Time (µs)";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(8, 166);
			this.label6.Name = "label6";
			this.label6.Size = new Size(150, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Rx02 BB Pre Enable Time (µs)";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(8, 142);
			this.label7.Name = "label7";
			this.label7.Size = new Size(150, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "Rx24 RF Pre Enable Time (µs)";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(8, 118);
			this.label8.Name = "label8";
			this.label8.Size = new Size(150, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Rx02 RF Pre Enable Time (µs)";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(8, 94);
			this.label4.Name = "label4";
			this.label4.Size = new Size(137, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Rx13 BB Turn Off Time (µs)";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(8, 70);
			this.label3.Name = "label3";
			this.label3.Size = new Size(137, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Rx02 BB Turn Off Time (µs)";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 46);
			this.label2.Name = "label2";
			this.label2.Size = new Size(137, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Rx13 RF Turn Off Time (µs)";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(8, 22);
			this.label1.Name = "label1";
			this.label1.Size = new Size(137, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Rx02 RF Turn Off Time (µs)";
			this.m_btnInterChirpBlockControlsCfg.Location = new Point(225, 405);
			this.m_btnInterChirpBlockControlsCfg.Name = "m_btnInterChirpBlockControlsCfg";
			this.m_btnInterChirpBlockControlsCfg.Size = new Size(75, 30);
			this.m_btnInterChirpBlockControlsCfg.TabIndex = 1;
			this.m_btnInterChirpBlockControlsCfg.Text = "Set";
			this.m_btnInterChirpBlockControlsCfg.UseVisualStyleBackColor = true;
			this.m_btnInterChirpBlockControlsCfg.Click += this.m_btnInterChirpBlockControlsCfg_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.groupBox1);
			base.Name = "InterChirpBlockControls";
			base.Size = new Size(858, 515);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.m_nudTxLOChainTurnOnTime).EndInit();
			((ISupportInitialize)this.m_nudRxLOChainTurnOnTime).EndInit();
			((ISupportInitialize)this.m_nudTxLOChainTurnOffTime).EndInit();
			((ISupportInitialize)this.m_nudRxLOChainTurnOffTime).EndInit();
			((ISupportInitialize)this.m_nudRx13BBTurnOnTime).EndInit();
			((ISupportInitialize)this.m_nudRx02BBTurnOnTime).EndInit();
			((ISupportInitialize)this.m_nudRx13RFTurnOnTime).EndInit();
			((ISupportInitialize)this.m_nudRx02RFTurnOnTime).EndInit();
			((ISupportInitialize)this.m_nudRx13BBPreEnableTime).EndInit();
			((ISupportInitialize)this.m_nudRx02BBPreEnableTime).EndInit();
			((ISupportInitialize)this.m_nudRx24RFPreEnableTime).EndInit();
			((ISupportInitialize)this.m_nudRx02RFPreEnableTime).EndInit();
			((ISupportInitialize)this.m_nudRx13BBTurnOffTime).EndInit();
			((ISupportInitialize)this.m_nudRx02BBTurnOffTime).EndInit();
			((ISupportInitialize)this.m_nudRx13RFTurnOffTime).EndInit();
			((ISupportInitialize)this.m_nudRx02RFTurnOffTime).EndInit();
			base.ResumeLayout(false);
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		public InterChirpBlockControlsConfigParams m_InterChirpBlockControlsConfigParams;

		private IContainer components;

		private GroupBox groupBox1;

		private Button m_btnInterChirpBlockControlsCfg;

		private Label label13;

		private Label label14;

		private Label label15;

		private Label label16;

		private Label label9;

		private Label label10;

		private Label label11;

		private Label label12;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label label1;

		private NumericUpDown m_nudRx13BBTurnOffTime;

		private NumericUpDown m_nudRx02BBTurnOffTime;

		private NumericUpDown m_nudRx13RFTurnOffTime;

		private NumericUpDown m_nudRx02RFTurnOffTime;

		private NumericUpDown m_nudTxLOChainTurnOnTime;

		private NumericUpDown m_nudRxLOChainTurnOnTime;

		private NumericUpDown m_nudTxLOChainTurnOffTime;

		private NumericUpDown m_nudRxLOChainTurnOffTime;

		private NumericUpDown m_nudRx13BBTurnOnTime;

		private NumericUpDown m_nudRx02BBTurnOnTime;

		private NumericUpDown m_nudRx13RFTurnOnTime;

		private NumericUpDown m_nudRx02RFTurnOnTime;

		private NumericUpDown m_nudRx13BBPreEnableTime;

		private NumericUpDown m_nudRx02BBPreEnableTime;

		private NumericUpDown m_nudRx24RFPreEnableTime;

		private NumericUpDown m_nudRx02RFPreEnableTime;
	}
}
