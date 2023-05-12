using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class TxRxGainTempLUTCfg : UserControl
	{
		public TxRxGainTempLUTCfg()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_TxGainTempLUTConfigParameters = this.m_GuiManager.TsParams.TxGainTempLUTConfigParameters;
			this.m_TxGainTempLUTGetConfigParameters = this.m_GuiManager.TsParams.TxGainTempLUTGetConfigParameters;
			this.m_RxGainTempLUTConfigParameters = this.m_GuiManager.TsParams.RxGainTempLUTConfigParameters;
			this.m_RxGainTempLUTGetConfigParameters = this.m_GuiManager.TsParams.RxGainTempLUTGetConfigParameters;
		}

		private int iSetTxGainTempLUTConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetTxGainTempLUTConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetTxGainTempLUTConfig()
		{
			this.iSetTxGainTempLUTConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void iSetTxGainTempLUTConfigAsync()
		{
			new del_v_v(this.iSetTxGainTempLUTConfig).BeginInvoke(null, null);
		}

		private void m_btnTxGainTempLUTConfigSet_Click(object sender, EventArgs p1)
		{
			this.iSetTxGainTempLUTConfigAsync();
		}

		public bool UpdateTxGainTempLUTConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateTxGainTempLUTConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_TxGainTempLUTConfigParameters.ProfileIndex = (char)this.m_nudTXGainTempSetProfileIndex.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTempLessThanNeg30 = (char)this.m_nudTx1GainCodeSetLessNeg30.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTempNeg30ToNeg20 = (char)this.f000296.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTempNeg20ToNeg10 = (char)this.f000295.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTempNeg10To0 = (char)this.f000294.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp0To10 = (char)this.f000293.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp10To20 = (char)this.f000292.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp20To30 = (char)this.f000291.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp30To40 = (char)this.f000290.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp40To50 = (char)this.f00028f.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp50To60 = (char)this.f00028e.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp60To70 = (char)this.f00028d.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp70To80 = (char)this.f00028c.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp80To90 = (char)this.f00028b.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp90To100 = (char)this.f00028a.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp100To110 = (char)this.f000289.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp110To120 = (char)this.f000288.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp120To130 = (char)this.f000287.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp130To140 = (char)this.f000286.Value;
				this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTempMoreThan140 = (char)this.m_nudTx1GainCodeSetMoreThan140.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTempLessThanNeg30 = (char)this.m_nudTx2GainCodeSetLessNeg30.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTempNeg30ToNeg20 = (char)this.f000285.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTempNeg20ToNeg10 = (char)this.f000284.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTempNeg10To0 = (char)this.f000283.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp0To10 = (char)this.f000282.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp10To20 = (char)this.f000281.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp20To30 = (char)this.f000280.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp30To40 = (char)this.f00027f.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp40To50 = (char)this.f00027e.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp50To60 = (char)this.f00027d.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp60To70 = (char)this.f00027c.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp70To80 = (char)this.f00027b.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp80To90 = (char)this.f00027a.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp90To100 = (char)this.f000279.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp100To110 = (char)this.f000278.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp110To120 = (char)this.f000277.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp120To130 = (char)this.f000276.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp130To140 = (char)this.f000275.Value;
				this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTempMoreThan140 = (char)this.m_nudTx2GainCodeSetMoreThan140.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTempLessThanNeg30 = (char)this.m_nudTx3GainCodeSetLessNeg30.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTempNeg30ToNeg20 = (char)this.f000274.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTempNeg20ToNeg10 = (char)this.f000273.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTempNeg10To0 = (char)this.f000272.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp0To10 = (char)this.f000271.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp10To20 = (char)this.f000270.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp20To30 = (char)this.f00026f.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp30To40 = (char)this.f00026e.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp40To50 = (char)this.f00026d.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp50To60 = (char)this.f00026c.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp60To70 = (char)this.f00026b.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp70To80 = (char)this.f00026a.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp80To90 = (char)this.f000269.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp90To100 = (char)this.f000268.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp100To110 = (char)this.f000267.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp110To120 = (char)this.f000266.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp120To130 = (char)this.f000265.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp130To140 = (char)this.f000264.Value;
				this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTempMoreThan140 = (char)this.m_nudTx3GainCodeSetMoreThan140.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateTxGainTempLUTConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateTxGainTempLUTConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudTXGainTempSetProfileIndex.Value = this.m_TxGainTempLUTConfigParameters.ProfileIndex;
				this.m_nudTx1GainCodeSetLessNeg30.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTempLessThanNeg30;
				this.f000296.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTempNeg30ToNeg20;
				this.f000295.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTempNeg20ToNeg10;
				this.f000294.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTempNeg10To0;
				this.f000293.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp0To10;
				this.f000292.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp10To20;
				this.f000291.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp20To30;
				this.f000290.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp30To40;
				this.f00028f.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp40To50;
				this.f00028e.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp50To60;
				this.f00028d.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp60To70;
				this.f00028c.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp70To80;
				this.f00028b.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp80To90;
				this.f00028a.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp90To100;
				this.f000289.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp100To110;
				this.f000288.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp110To120;
				this.f000287.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp120To130;
				this.f000286.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTemp130To140;
				this.m_nudTx1GainCodeSetMoreThan140.Value = this.m_TxGainTempLUTConfigParameters.Tx1GainCodeTempMoreThan140;
				this.m_nudTx2GainCodeSetLessNeg30.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTempLessThanNeg30;
				this.f000285.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTempNeg30ToNeg20;
				this.f000284.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTempNeg20ToNeg10;
				this.f000283.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTempNeg10To0;
				this.f000282.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp0To10;
				this.f000281.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp10To20;
				this.f000280.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp20To30;
				this.f00027f.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp30To40;
				this.f00027e.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp40To50;
				this.f00027d.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp50To60;
				this.f00027c.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp60To70;
				this.f00027b.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp70To80;
				this.f00027a.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp80To90;
				this.f000279.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp90To100;
				this.f000278.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp100To110;
				this.f000277.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp110To120;
				this.f000276.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp120To130;
				this.f000275.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTemp130To140;
				this.m_nudTx2GainCodeSetMoreThan140.Value = this.m_TxGainTempLUTConfigParameters.Tx2GainCodeTempMoreThan140;
				this.m_nudTx3GainCodeSetLessNeg30.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTempLessThanNeg30;
				this.f000274.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTempNeg30ToNeg20;
				this.f000273.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTempNeg20ToNeg10;
				this.f000272.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTempNeg10To0;
				this.f000271.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp0To10;
				this.f000270.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp10To20;
				this.f00026f.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp20To30;
				this.f00026e.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp30To40;
				this.f00026d.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp40To50;
				this.f00026c.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp50To60;
				this.f00026b.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp60To70;
				this.f00026a.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp70To80;
				this.f000269.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp80To90;
				this.f000268.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp90To100;
				this.f000267.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp100To110;
				this.f000266.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp110To120;
				this.f000265.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp120To130;
				this.f000264.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTemp130To140;
				this.m_nudTx3GainCodeSetMoreThan140.Value = this.m_TxGainTempLUTConfigParameters.Tx3GainCodeTempMoreThan140;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iGetTxGainTempLUTConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iGetTxGainTempLUTConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iGetTxGainTempLUTConfig()
		{
			this.iGetTxGainTempLUTConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void iGetTxGainTempLUTConfigAsync()
		{
			new del_v_v(this.iGetTxGainTempLUTConfig).BeginInvoke(null, null);
		}

		private void m_btnTxGainTempLUTConfigGet_Click(object sender, EventArgs p1)
		{
			this.iGetTxGainTempLUTConfigAsync();
		}

		public bool UpdateTxGainTempLUTGetConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateTxGainTempLUTGetConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_TxGainTempLUTGetConfigParameters.ProfileIndex = (char)this.m_nudTXGainTempSetProfileIndex.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateTxGainTempLUTGetConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateTxGainTempLUTGetConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudTXGainTempSetProfileIndex.Value = this.m_TxGainTempLUTGetConfigParameters.ProfileIndex;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public void TxGainTempLutReportDataToGui(byte ProfileIndex, sbyte Tx1GainCodeTempLessThanNeg30, sbyte Tx1GainCodeTempNeg30ToNeg20, sbyte Tx1GainCodeTempNeg20ToNeg10, sbyte Tx1GainCodeTempNeg10To0, byte Tx1GainCodeTemp0To10, byte Tx1GainCodeTemp10To20, byte Tx1GainCodeTemp20To30, byte Tx1GainCodeTemp30To40, byte Tx1GainCodeTemp40To50, byte Tx1GainCodeTemp50To60, byte Tx1GainCodeTemp60To70, byte Tx1GainCodeTemp70To80, byte Tx1GainCodeTemp80To90, byte Tx1GainCodeTemp90To100, byte Tx1GainCodeTemp100To110, byte Tx1GainCodeTemp110To120, byte Tx1GainCodeTemp120To130, byte Tx1GainCodeTemp130To140, byte Tx1GainCodeTempMoreThan140, sbyte Tx2GainCodeTempLessThanNeg30, sbyte Tx2GainCodeTempNeg30ToNeg20, sbyte Tx2GainCodeTempNeg20ToNeg10, sbyte Tx2GainCodeTempNeg10To0, byte Tx2GainCodeTemp0To10, byte Tx2GainCodeTemp10To20, byte Tx2GainCodeTemp20To30, byte Tx2GainCodeTemp30To40, byte Tx2GainCodeTemp40To50, byte Tx2GainCodeTemp50To60, byte Tx2GainCodeTemp60To70, byte Tx2GainCodeTemp70To80, byte Tx2GainCodeTemp80To90, byte Tx2GainCodeTemp90To100, byte Tx2GainCodeTemp100To110, byte Tx2GainCodeTemp110To120, byte Tx2GainCodeTemp120To130, byte Tx2GainCodeTemp130To140, byte Tx2GainCodeTempMoreThan140, sbyte Tx3GainCodeTempLessThanNeg30, sbyte Tx3GainCodeTempNeg30ToNeg20, sbyte Tx3GainCodeTempNeg20ToNeg10, sbyte Tx3GainCodeTempNeg10To0, byte Tx3GainCodeTemp0To10, byte Tx3GainCodeTemp10To20, byte Tx3GainCodeTemp20To30, byte Tx3GainCodeTemp30To40, byte Tx3GainCodeTemp40To50, byte Tx3GainCodeTemp50To60, byte Tx3GainCodeTemp60To70, byte Tx3GainCodeTemp70To80, byte Tx3GainCodeTemp80To90, byte Tx3GainCodeTemp90To100, byte Tx3GainCodeTemp100To110, byte Tx3GainCodeTemp110To120, byte Tx3GainCodeTemp120To130, byte Tx3GainCodeTemp130To140, byte Tx3GainCodeTempMoreThan140)
		{
			if (base.InvokeRequired)
			{
				delegate0e6 method = new delegate0e6(this.TxGainTempLutReportDataToGui);
				base.Invoke(method, new object[]
				{
					ProfileIndex,
					Tx1GainCodeTempLessThanNeg30,
					Tx1GainCodeTempNeg30ToNeg20,
					Tx1GainCodeTempNeg20ToNeg10,
					Tx1GainCodeTempNeg10To0,
					Tx1GainCodeTemp0To10,
					Tx1GainCodeTemp10To20,
					Tx1GainCodeTemp20To30,
					Tx1GainCodeTemp30To40,
					Tx1GainCodeTemp40To50,
					Tx1GainCodeTemp50To60,
					Tx1GainCodeTemp60To70,
					Tx1GainCodeTemp70To80,
					Tx1GainCodeTemp80To90,
					Tx1GainCodeTemp90To100,
					Tx1GainCodeTemp100To110,
					Tx1GainCodeTemp110To120,
					Tx1GainCodeTemp120To130,
					Tx1GainCodeTemp130To140,
					Tx1GainCodeTempMoreThan140,
					Tx2GainCodeTempLessThanNeg30,
					Tx2GainCodeTempNeg30ToNeg20,
					Tx2GainCodeTempNeg20ToNeg10,
					Tx2GainCodeTempNeg10To0,
					Tx2GainCodeTemp0To10,
					Tx2GainCodeTemp10To20,
					Tx2GainCodeTemp20To30,
					Tx2GainCodeTemp30To40,
					Tx2GainCodeTemp40To50,
					Tx2GainCodeTemp50To60,
					Tx2GainCodeTemp60To70,
					Tx2GainCodeTemp70To80,
					Tx2GainCodeTemp80To90,
					Tx2GainCodeTemp90To100,
					Tx2GainCodeTemp100To110,
					Tx2GainCodeTemp110To120,
					Tx2GainCodeTemp120To130,
					Tx2GainCodeTemp130To140,
					Tx2GainCodeTempMoreThan140,
					Tx3GainCodeTempLessThanNeg30,
					Tx3GainCodeTempNeg30ToNeg20,
					Tx3GainCodeTempNeg20ToNeg10,
					Tx3GainCodeTempNeg10To0,
					Tx3GainCodeTemp0To10,
					Tx3GainCodeTemp10To20,
					Tx3GainCodeTemp20To30,
					Tx3GainCodeTemp30To40,
					Tx3GainCodeTemp40To50,
					Tx3GainCodeTemp50To60,
					Tx3GainCodeTemp60To70,
					Tx3GainCodeTemp70To80,
					Tx3GainCodeTemp80To90,
					Tx3GainCodeTemp90To100,
					Tx3GainCodeTemp100To110,
					Tx3GainCodeTemp110To120,
					Tx3GainCodeTemp120To130,
					Tx3GainCodeTemp130To140,
					Tx3GainCodeTempMoreThan140
				});
				return;
			}
			this.m_nudTXGainTempSetProfileIndex.Value = ProfileIndex;
			this.m_nudTx1GainCodeSetLessNeg30.Value = Tx1GainCodeTempLessThanNeg30;
			this.f000296.Value = Tx1GainCodeTempNeg30ToNeg20;
			this.f000295.Value = Tx1GainCodeTempNeg20ToNeg10;
			this.f000294.Value = Tx1GainCodeTempNeg10To0;
			this.f000293.Value = Tx1GainCodeTemp0To10;
			this.f000292.Value = Tx1GainCodeTemp10To20;
			this.f000291.Value = Tx1GainCodeTemp20To30;
			this.f000290.Value = Tx1GainCodeTemp30To40;
			this.f00028f.Value = Tx1GainCodeTemp40To50;
			this.f00028e.Value = Tx1GainCodeTemp50To60;
			this.f00028d.Value = Tx1GainCodeTemp60To70;
			this.f00028c.Value = Tx1GainCodeTemp70To80;
			this.f00028b.Value = Tx1GainCodeTemp80To90;
			this.f00028a.Value = Tx1GainCodeTemp90To100;
			this.f000289.Value = Tx1GainCodeTemp100To110;
			this.f000288.Value = Tx1GainCodeTemp110To120;
			this.f000287.Value = Tx1GainCodeTemp120To130;
			this.f000286.Value = Tx1GainCodeTemp130To140;
			this.m_nudTx1GainCodeSetMoreThan140.Value = Tx1GainCodeTempMoreThan140;
			this.m_nudTx2GainCodeSetLessNeg30.Value = Tx2GainCodeTempLessThanNeg30;
			this.f000285.Value = Tx2GainCodeTempNeg30ToNeg20;
			this.f000284.Value = Tx2GainCodeTempNeg20ToNeg10;
			this.f000283.Value = Tx2GainCodeTempNeg10To0;
			this.f000282.Value = Tx2GainCodeTemp0To10;
			this.f000281.Value = Tx2GainCodeTemp10To20;
			this.f000280.Value = Tx2GainCodeTemp20To30;
			this.f00027f.Value = Tx2GainCodeTemp30To40;
			this.f00027e.Value = Tx2GainCodeTemp40To50;
			this.f00027d.Value = Tx2GainCodeTemp50To60;
			this.f00027c.Value = Tx2GainCodeTemp60To70;
			this.f00027b.Value = Tx2GainCodeTemp70To80;
			this.f00027a.Value = Tx2GainCodeTemp80To90;
			this.f000279.Value = Tx2GainCodeTemp90To100;
			this.f000278.Value = Tx2GainCodeTemp100To110;
			this.f000277.Value = Tx2GainCodeTemp110To120;
			this.f000276.Value = Tx2GainCodeTemp120To130;
			this.f000275.Value = Tx2GainCodeTemp130To140;
			this.m_nudTx2GainCodeSetMoreThan140.Value = Tx2GainCodeTempMoreThan140;
			this.m_nudTx3GainCodeSetLessNeg30.Value = Tx3GainCodeTempLessThanNeg30;
			this.f000274.Value = Tx3GainCodeTempNeg30ToNeg20;
			this.f000273.Value = Tx3GainCodeTempNeg20ToNeg10;
			this.f000272.Value = Tx3GainCodeTempNeg10To0;
			this.f000271.Value = Tx3GainCodeTemp0To10;
			this.f000270.Value = Tx3GainCodeTemp10To20;
			this.f00026f.Value = Tx3GainCodeTemp20To30;
			this.f00026e.Value = Tx3GainCodeTemp30To40;
			this.f00026d.Value = Tx3GainCodeTemp40To50;
			this.f00026c.Value = Tx3GainCodeTemp50To60;
			this.f00026b.Value = Tx3GainCodeTemp60To70;
			this.f00026a.Value = Tx3GainCodeTemp70To80;
			this.f000269.Value = Tx3GainCodeTemp80To90;
			this.f000268.Value = Tx3GainCodeTemp90To100;
			this.f000267.Value = Tx3GainCodeTemp100To110;
			this.f000266.Value = Tx3GainCodeTemp110To120;
			this.f000265.Value = Tx3GainCodeTemp120To130;
			this.f000264.Value = Tx3GainCodeTemp130To140;
			this.m_nudTx3GainCodeSetMoreThan140.Value = Tx3GainCodeTempMoreThan140;
		}

		private int iSetRxGainTempLUTConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetRxGainTempLUTConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetRxGainTempLUTConfig()
		{
			this.iSetRxGainTempLUTConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void iSetRxGainTempLUTConfigAsync()
		{
			new del_v_v(this.iSetRxGainTempLUTConfig).BeginInvoke(null, null);
		}

		private void m_btnRxGainTempLUTConfigSet_Click(object sender, EventArgs p1)
		{
			this.iSetRxGainTempLUTConfigAsync();
		}

		public bool UpdateRxGainTempLUTConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRxGainTempLUTConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RxGainTempLUTConfigParameters.ProfileIndex = (char)this.m_nudRXGainTempSetProfileIndex.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTempLessThanNeg30 = (char)this.m_nudRx1GainCodeSetLessNeg30.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTempNeg30ToNeg20 = (char)this.f0002a7.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTempNeg20ToNeg10 = (char)this.f0002a6.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTempNeg10To0 = (char)this.f0002a5.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp0To10 = (char)this.f0002a4.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp10To20 = (char)this.f0002a3.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp20To30 = (char)this.f0002a2.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp30To40 = (char)this.f0002a1.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp40To50 = (char)this.f0002a0.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp50To60 = (char)this.f00029f.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp60To70 = (char)this.f00029e.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp70To80 = (char)this.f00029d.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp80To90 = (char)this.f00029c.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp90To100 = (char)this.f00029b.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp100To110 = (char)this.f00029a.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp110To120 = (char)this.f000299.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp120To130 = (char)this.f000298.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp130To140 = (char)this.f000297.Value;
				this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTempMoreThan140 = (char)this.m_nudRx1GainCodeSetMoreThan140.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRxGainTempLUTConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRxGainTempLUTConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudRXGainTempSetProfileIndex.Value = this.m_RxGainTempLUTConfigParameters.ProfileIndex;
				this.m_nudRx1GainCodeSetLessNeg30.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTempLessThanNeg30;
				this.f0002a7.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTempNeg30ToNeg20;
				this.f0002a6.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTempNeg20ToNeg10;
				this.f0002a5.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTempNeg10To0;
				this.f0002a4.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp0To10;
				this.f0002a3.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp10To20;
				this.f0002a2.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp20To30;
				this.f0002a1.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp30To40;
				this.f0002a0.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp40To50;
				this.f00029f.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp50To60;
				this.f00029e.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp60To70;
				this.f00029d.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp70To80;
				this.f00029c.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp80To90;
				this.f00029b.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp90To100;
				this.f00029a.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp100To110;
				this.f000299.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp110To120;
				this.f000298.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp120To130;
				this.f000297.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTemp130To140;
				this.m_nudRx1GainCodeSetMoreThan140.Value = this.m_RxGainTempLUTConfigParameters.Rx1GainCodeTempMoreThan140;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iGetRxGainTempLUTConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iGetRxGainTempLUTConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iGetRxGainTempLUTConfig()
		{
			this.iGetRxGainTempLUTConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void iGetRxGainTempLUTConfigAsync()
		{
			new del_v_v(this.iGetRxGainTempLUTConfig).BeginInvoke(null, null);
		}

		private void m_btnRxGainTempLUTConfigGet_Click(object sender, EventArgs p1)
		{
			this.iGetRxGainTempLUTConfigAsync();
		}

		public bool UpdateRxGainTempLUTGetConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRxGainTempLUTGetConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_RxGainTempLUTGetConfigParameters.ProfileIndex = (char)this.m_nudRXGainTempSetProfileIndex.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateRxGainTempLUTGetConfigDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateRxGainTempLUTGetConfigDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudRXGainTempSetProfileIndex.Value = this.m_RxGainTempLUTGetConfigParameters.ProfileIndex;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public void RxGainTempLutReportDataToGui(byte ProfileIndex, sbyte Rx1GainCodeTempLessThanNeg30, sbyte Rx1GainCodeTempNeg30ToNeg20, sbyte Rx1GainCodeTempNeg20ToNeg10, sbyte Rx1GainCodeTempNeg10To0, byte Rx1GainCodeTemp0To10, byte Rx1GainCodeTemp10To20, byte Rx1GainCodeTemp20To30, byte Rx1GainCodeTemp30To40, byte Rx1GainCodeTemp40To50, byte Rx1GainCodeTemp50To60, byte Rx1GainCodeTemp60To70, byte Rx1GainCodeTemp70To80, byte Rx1GainCodeTemp80To90, byte Rx1GainCodeTemp90To100, byte Rx1GainCodeTemp100To110, byte Rx1GainCodeTemp110To120, byte Rx1GainCodeTemp120To130, byte Rx1GainCodeTemp130To140, byte Rx1GainCodeTempMoreThan140)
		{
			if (base.InvokeRequired)
			{
				delegate0e7 method = new delegate0e7(this.RxGainTempLutReportDataToGui);
				base.Invoke(method, new object[]
				{
					ProfileIndex,
					Rx1GainCodeTempLessThanNeg30,
					Rx1GainCodeTempNeg30ToNeg20,
					Rx1GainCodeTempNeg20ToNeg10,
					Rx1GainCodeTempNeg10To0,
					Rx1GainCodeTemp0To10,
					Rx1GainCodeTemp10To20,
					Rx1GainCodeTemp20To30,
					Rx1GainCodeTemp30To40,
					Rx1GainCodeTemp40To50,
					Rx1GainCodeTemp50To60,
					Rx1GainCodeTemp60To70,
					Rx1GainCodeTemp70To80,
					Rx1GainCodeTemp80To90,
					Rx1GainCodeTemp90To100,
					Rx1GainCodeTemp100To110,
					Rx1GainCodeTemp110To120,
					Rx1GainCodeTemp120To130,
					Rx1GainCodeTemp130To140,
					Rx1GainCodeTempMoreThan140
				});
				return;
			}
			this.m_nudRXGainTempSetProfileIndex.Value = ProfileIndex;
			this.m_nudRx1GainCodeSetLessNeg30.Value = Rx1GainCodeTempLessThanNeg30;
			this.f0002a7.Value = Rx1GainCodeTempNeg30ToNeg20;
			this.f0002a6.Value = Rx1GainCodeTempNeg20ToNeg10;
			this.f0002a5.Value = Rx1GainCodeTempNeg10To0;
			this.f0002a4.Value = Rx1GainCodeTemp0To10;
			this.f0002a3.Value = Rx1GainCodeTemp10To20;
			this.f0002a2.Value = Rx1GainCodeTemp20To30;
			this.f0002a1.Value = Rx1GainCodeTemp30To40;
			this.f0002a0.Value = Rx1GainCodeTemp40To50;
			this.f00029f.Value = Rx1GainCodeTemp50To60;
			this.f00029e.Value = Rx1GainCodeTemp60To70;
			this.f00029d.Value = Rx1GainCodeTemp70To80;
			this.f00029c.Value = Rx1GainCodeTemp80To90;
			this.f00029b.Value = Rx1GainCodeTemp90To100;
			this.f00029a.Value = Rx1GainCodeTemp100To110;
			this.f000299.Value = Rx1GainCodeTemp110To120;
			this.f000298.Value = Rx1GainCodeTemp120To130;
			this.f000297.Value = Rx1GainCodeTemp130To140;
			this.m_nudRx1GainCodeSetMoreThan140.Value = Rx1GainCodeTempMoreThan140;
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
			this.m_btnTxGainTempLUTConfigGet = new Button();
			this.m_btnTxGainTempLUTConfigSet = new Button();
			this.m_nudTXGainTempSetProfileIndex = new NumericUpDown();
			this.m_nudTx3GainCodeSetMoreThan140 = new NumericUpDown();
			this.f000264 = new NumericUpDown();
			this.f000265 = new NumericUpDown();
			this.f000266 = new NumericUpDown();
			this.f000267 = new NumericUpDown();
			this.f000268 = new NumericUpDown();
			this.f000269 = new NumericUpDown();
			this.f00026a = new NumericUpDown();
			this.f00026b = new NumericUpDown();
			this.f00026c = new NumericUpDown();
			this.f00026d = new NumericUpDown();
			this.f00026e = new NumericUpDown();
			this.f00026f = new NumericUpDown();
			this.f000270 = new NumericUpDown();
			this.f000271 = new NumericUpDown();
			this.f000272 = new NumericUpDown();
			this.f000273 = new NumericUpDown();
			this.f000274 = new NumericUpDown();
			this.m_nudTx3GainCodeSetLessNeg30 = new NumericUpDown();
			this.m_nudTx2GainCodeSetMoreThan140 = new NumericUpDown();
			this.f000275 = new NumericUpDown();
			this.f000276 = new NumericUpDown();
			this.f000277 = new NumericUpDown();
			this.f000278 = new NumericUpDown();
			this.f000279 = new NumericUpDown();
			this.f00027a = new NumericUpDown();
			this.f00027b = new NumericUpDown();
			this.f00027c = new NumericUpDown();
			this.f00027d = new NumericUpDown();
			this.f00027e = new NumericUpDown();
			this.f00027f = new NumericUpDown();
			this.f000280 = new NumericUpDown();
			this.f000281 = new NumericUpDown();
			this.f000282 = new NumericUpDown();
			this.f000283 = new NumericUpDown();
			this.f000284 = new NumericUpDown();
			this.f000285 = new NumericUpDown();
			this.m_nudTx2GainCodeSetLessNeg30 = new NumericUpDown();
			this.m_nudTx1GainCodeSetMoreThan140 = new NumericUpDown();
			this.f000286 = new NumericUpDown();
			this.f000287 = new NumericUpDown();
			this.f000288 = new NumericUpDown();
			this.f000289 = new NumericUpDown();
			this.f00028a = new NumericUpDown();
			this.f00028b = new NumericUpDown();
			this.f00028c = new NumericUpDown();
			this.f00028d = new NumericUpDown();
			this.f00028e = new NumericUpDown();
			this.f00028f = new NumericUpDown();
			this.f000290 = new NumericUpDown();
			this.f000291 = new NumericUpDown();
			this.f000292 = new NumericUpDown();
			this.f000293 = new NumericUpDown();
			this.f000294 = new NumericUpDown();
			this.f000295 = new NumericUpDown();
			this.f000296 = new NumericUpDown();
			this.m_nudTx1GainCodeSetLessNeg30 = new NumericUpDown();
			this.label45 = new Label();
			this.label44 = new Label();
			this.label43 = new Label();
			this.label20 = new Label();
			this.label21 = new Label();
			this.label16 = new Label();
			this.label17 = new Label();
			this.label18 = new Label();
			this.label13 = new Label();
			this.label14 = new Label();
			this.label15 = new Label();
			this.label10 = new Label();
			this.label11 = new Label();
			this.label12 = new Label();
			this.label7 = new Label();
			this.label8 = new Label();
			this.label9 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.groupBox2 = new GroupBox();
			this.m_btnRxGainTempLUTConfigGet = new Button();
			this.m_btnRxGainTempLUTConfigSet = new Button();
			this.m_nudRx1GainCodeSetMoreThan140 = new NumericUpDown();
			this.m_nudRXGainTempSetProfileIndex = new NumericUpDown();
			this.label19 = new Label();
			this.f000297 = new NumericUpDown();
			this.f000298 = new NumericUpDown();
			this.f000299 = new NumericUpDown();
			this.f00029a = new NumericUpDown();
			this.f00029b = new NumericUpDown();
			this.f00029c = new NumericUpDown();
			this.f00029d = new NumericUpDown();
			this.f00029e = new NumericUpDown();
			this.f00029f = new NumericUpDown();
			this.f0002a0 = new NumericUpDown();
			this.f0002a1 = new NumericUpDown();
			this.f0002a2 = new NumericUpDown();
			this.f0002a3 = new NumericUpDown();
			this.f0002a4 = new NumericUpDown();
			this.f0002a5 = new NumericUpDown();
			this.f0002a6 = new NumericUpDown();
			this.f0002a7 = new NumericUpDown();
			this.m_nudRx1GainCodeSetLessNeg30 = new NumericUpDown();
			this.label22 = new Label();
			this.label23 = new Label();
			this.label25 = new Label();
			this.label26 = new Label();
			this.label27 = new Label();
			this.label28 = new Label();
			this.label29 = new Label();
			this.label30 = new Label();
			this.label31 = new Label();
			this.label32 = new Label();
			this.label33 = new Label();
			this.label34 = new Label();
			this.label35 = new Label();
			this.label36 = new Label();
			this.label37 = new Label();
			this.label38 = new Label();
			this.label39 = new Label();
			this.label40 = new Label();
			this.label41 = new Label();
			this.label42 = new Label();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.m_nudTXGainTempSetProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudTx3GainCodeSetMoreThan140).BeginInit();
			((ISupportInitialize)this.f000264).BeginInit();
			((ISupportInitialize)this.f000265).BeginInit();
			((ISupportInitialize)this.f000266).BeginInit();
			((ISupportInitialize)this.f000267).BeginInit();
			((ISupportInitialize)this.f000268).BeginInit();
			((ISupportInitialize)this.f000269).BeginInit();
			((ISupportInitialize)this.f00026a).BeginInit();
			((ISupportInitialize)this.f00026b).BeginInit();
			((ISupportInitialize)this.f00026c).BeginInit();
			((ISupportInitialize)this.f00026d).BeginInit();
			((ISupportInitialize)this.f00026e).BeginInit();
			((ISupportInitialize)this.f00026f).BeginInit();
			((ISupportInitialize)this.f000270).BeginInit();
			((ISupportInitialize)this.f000271).BeginInit();
			((ISupportInitialize)this.f000272).BeginInit();
			((ISupportInitialize)this.f000273).BeginInit();
			((ISupportInitialize)this.f000274).BeginInit();
			((ISupportInitialize)this.m_nudTx3GainCodeSetLessNeg30).BeginInit();
			((ISupportInitialize)this.m_nudTx2GainCodeSetMoreThan140).BeginInit();
			((ISupportInitialize)this.f000275).BeginInit();
			((ISupportInitialize)this.f000276).BeginInit();
			((ISupportInitialize)this.f000277).BeginInit();
			((ISupportInitialize)this.f000278).BeginInit();
			((ISupportInitialize)this.f000279).BeginInit();
			((ISupportInitialize)this.f00027a).BeginInit();
			((ISupportInitialize)this.f00027b).BeginInit();
			((ISupportInitialize)this.f00027c).BeginInit();
			((ISupportInitialize)this.f00027d).BeginInit();
			((ISupportInitialize)this.f00027e).BeginInit();
			((ISupportInitialize)this.f00027f).BeginInit();
			((ISupportInitialize)this.f000280).BeginInit();
			((ISupportInitialize)this.f000281).BeginInit();
			((ISupportInitialize)this.f000282).BeginInit();
			((ISupportInitialize)this.f000283).BeginInit();
			((ISupportInitialize)this.f000284).BeginInit();
			((ISupportInitialize)this.f000285).BeginInit();
			((ISupportInitialize)this.m_nudTx2GainCodeSetLessNeg30).BeginInit();
			((ISupportInitialize)this.m_nudTx1GainCodeSetMoreThan140).BeginInit();
			((ISupportInitialize)this.f000286).BeginInit();
			((ISupportInitialize)this.f000287).BeginInit();
			((ISupportInitialize)this.f000288).BeginInit();
			((ISupportInitialize)this.f000289).BeginInit();
			((ISupportInitialize)this.f00028a).BeginInit();
			((ISupportInitialize)this.f00028b).BeginInit();
			((ISupportInitialize)this.f00028c).BeginInit();
			((ISupportInitialize)this.f00028d).BeginInit();
			((ISupportInitialize)this.f00028e).BeginInit();
			((ISupportInitialize)this.f00028f).BeginInit();
			((ISupportInitialize)this.f000290).BeginInit();
			((ISupportInitialize)this.f000291).BeginInit();
			((ISupportInitialize)this.f000292).BeginInit();
			((ISupportInitialize)this.f000293).BeginInit();
			((ISupportInitialize)this.f000294).BeginInit();
			((ISupportInitialize)this.f000295).BeginInit();
			((ISupportInitialize)this.f000296).BeginInit();
			((ISupportInitialize)this.m_nudTx1GainCodeSetLessNeg30).BeginInit();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.m_nudRx1GainCodeSetMoreThan140).BeginInit();
			((ISupportInitialize)this.m_nudRXGainTempSetProfileIndex).BeginInit();
			((ISupportInitialize)this.f000297).BeginInit();
			((ISupportInitialize)this.f000298).BeginInit();
			((ISupportInitialize)this.f000299).BeginInit();
			((ISupportInitialize)this.f00029a).BeginInit();
			((ISupportInitialize)this.f00029b).BeginInit();
			((ISupportInitialize)this.f00029c).BeginInit();
			((ISupportInitialize)this.f00029d).BeginInit();
			((ISupportInitialize)this.f00029e).BeginInit();
			((ISupportInitialize)this.f00029f).BeginInit();
			((ISupportInitialize)this.f0002a0).BeginInit();
			((ISupportInitialize)this.f0002a1).BeginInit();
			((ISupportInitialize)this.f0002a2).BeginInit();
			((ISupportInitialize)this.f0002a3).BeginInit();
			((ISupportInitialize)this.f0002a4).BeginInit();
			((ISupportInitialize)this.f0002a5).BeginInit();
			((ISupportInitialize)this.f0002a6).BeginInit();
			((ISupportInitialize)this.f0002a7).BeginInit();
			((ISupportInitialize)this.m_nudRx1GainCodeSetLessNeg30).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.m_btnTxGainTempLUTConfigGet);
			this.groupBox1.Controls.Add(this.m_btnTxGainTempLUTConfigSet);
			this.groupBox1.Controls.Add(this.m_nudTXGainTempSetProfileIndex);
			this.groupBox1.Controls.Add(this.m_nudTx3GainCodeSetMoreThan140);
			this.groupBox1.Controls.Add(this.f000264);
			this.groupBox1.Controls.Add(this.f000265);
			this.groupBox1.Controls.Add(this.f000266);
			this.groupBox1.Controls.Add(this.f000267);
			this.groupBox1.Controls.Add(this.f000268);
			this.groupBox1.Controls.Add(this.f000269);
			this.groupBox1.Controls.Add(this.f00026a);
			this.groupBox1.Controls.Add(this.f00026b);
			this.groupBox1.Controls.Add(this.f00026c);
			this.groupBox1.Controls.Add(this.f00026d);
			this.groupBox1.Controls.Add(this.f00026e);
			this.groupBox1.Controls.Add(this.f00026f);
			this.groupBox1.Controls.Add(this.f000270);
			this.groupBox1.Controls.Add(this.f000271);
			this.groupBox1.Controls.Add(this.f000272);
			this.groupBox1.Controls.Add(this.f000273);
			this.groupBox1.Controls.Add(this.f000274);
			this.groupBox1.Controls.Add(this.m_nudTx3GainCodeSetLessNeg30);
			this.groupBox1.Controls.Add(this.m_nudTx2GainCodeSetMoreThan140);
			this.groupBox1.Controls.Add(this.f000275);
			this.groupBox1.Controls.Add(this.f000276);
			this.groupBox1.Controls.Add(this.f000277);
			this.groupBox1.Controls.Add(this.f000278);
			this.groupBox1.Controls.Add(this.f000279);
			this.groupBox1.Controls.Add(this.f00027a);
			this.groupBox1.Controls.Add(this.f00027b);
			this.groupBox1.Controls.Add(this.f00027c);
			this.groupBox1.Controls.Add(this.f00027d);
			this.groupBox1.Controls.Add(this.f00027e);
			this.groupBox1.Controls.Add(this.f00027f);
			this.groupBox1.Controls.Add(this.f000280);
			this.groupBox1.Controls.Add(this.f000281);
			this.groupBox1.Controls.Add(this.f000282);
			this.groupBox1.Controls.Add(this.f000283);
			this.groupBox1.Controls.Add(this.f000284);
			this.groupBox1.Controls.Add(this.f000285);
			this.groupBox1.Controls.Add(this.m_nudTx2GainCodeSetLessNeg30);
			this.groupBox1.Controls.Add(this.m_nudTx1GainCodeSetMoreThan140);
			this.groupBox1.Controls.Add(this.f000286);
			this.groupBox1.Controls.Add(this.f000287);
			this.groupBox1.Controls.Add(this.f000288);
			this.groupBox1.Controls.Add(this.f000289);
			this.groupBox1.Controls.Add(this.f00028a);
			this.groupBox1.Controls.Add(this.f00028b);
			this.groupBox1.Controls.Add(this.f00028c);
			this.groupBox1.Controls.Add(this.f00028d);
			this.groupBox1.Controls.Add(this.f00028e);
			this.groupBox1.Controls.Add(this.f00028f);
			this.groupBox1.Controls.Add(this.f000290);
			this.groupBox1.Controls.Add(this.f000291);
			this.groupBox1.Controls.Add(this.f000292);
			this.groupBox1.Controls.Add(this.f000293);
			this.groupBox1.Controls.Add(this.f000294);
			this.groupBox1.Controls.Add(this.f000295);
			this.groupBox1.Controls.Add(this.f000296);
			this.groupBox1.Controls.Add(this.m_nudTx1GainCodeSetLessNeg30);
			this.groupBox1.Controls.Add(this.label45);
			this.groupBox1.Controls.Add(this.label44);
			this.groupBox1.Controls.Add(this.label43);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new Point(4, 4);
			this.groupBox1.Margin = new Padding(4, 4, 4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new Padding(4, 4, 4, 4);
			this.groupBox1.Size = new Size(563, 649);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tx Gain Temp LUT Config";
			this.m_btnTxGainTempLUTConfigGet.Location = new Point(424, 609);
			this.m_btnTxGainTempLUTConfigGet.Margin = new Padding(4, 4, 4, 4);
			this.m_btnTxGainTempLUTConfigGet.Name = "m_btnTxGainTempLUTConfigGet";
			this.m_btnTxGainTempLUTConfigGet.Size = new Size(88, 28);
			this.m_btnTxGainTempLUTConfigGet.TabIndex = 83;
			this.m_btnTxGainTempLUTConfigGet.Text = "Get";
			this.m_btnTxGainTempLUTConfigGet.UseVisualStyleBackColor = true;
			this.m_btnTxGainTempLUTConfigGet.Click += this.m_btnTxGainTempLUTConfigGet_Click;
			this.m_btnTxGainTempLUTConfigSet.Location = new Point(280, 609);
			this.m_btnTxGainTempLUTConfigSet.Margin = new Padding(4, 4, 4, 4);
			this.m_btnTxGainTempLUTConfigSet.Name = "m_btnTxGainTempLUTConfigSet";
			this.m_btnTxGainTempLUTConfigSet.Size = new Size(88, 28);
			this.m_btnTxGainTempLUTConfigSet.TabIndex = 82;
			this.m_btnTxGainTempLUTConfigSet.Text = "Set";
			this.m_btnTxGainTempLUTConfigSet.UseVisualStyleBackColor = true;
			this.m_btnTxGainTempLUTConfigSet.Click += this.m_btnTxGainTempLUTConfigSet_Click;
			this.m_nudTXGainTempSetProfileIndex.Location = new Point(129, 18);
			this.m_nudTXGainTempSetProfileIndex.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudTXGainTempSetProfileIndex = this.m_nudTXGainTempSetProfileIndex;
			int[] array = new int[4];
			array[0] = 3;
			nudTXGainTempSetProfileIndex.Maximum = new decimal(array);
			this.m_nudTXGainTempSetProfileIndex.Name = "m_nudTXGainTempSetProfileIndex";
			this.m_nudTXGainTempSetProfileIndex.Size = new Size(87, 22);
			this.m_nudTXGainTempSetProfileIndex.TabIndex = 81;
			this.m_nudTx3GainCodeSetMoreThan140.Location = new Point(424, 576);
			this.m_nudTx3GainCodeSetMoreThan140.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudTx3GainCodeSetMoreThan = this.m_nudTx3GainCodeSetMoreThan140;
			int[] array2 = new int[4];
			array2[0] = 255;
			nudTx3GainCodeSetMoreThan.Maximum = new decimal(array2);
			this.m_nudTx3GainCodeSetMoreThan140.Name = "m_nudTx3GainCodeSetMoreThan140";
			this.m_nudTx3GainCodeSetMoreThan140.Size = new Size(87, 22);
			this.m_nudTx3GainCodeSetMoreThan140.TabIndex = 80;
			this.f000264.Location = new Point(424, 548);
			this.f000264.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown = this.f000264;
			int[] array3 = new int[4];
			array3[0] = 255;
			numericUpDown.Maximum = new decimal(array3);
			this.f000264.Name = "m_nudTx3GainCodeSet130to140";
			this.f000264.Size = new Size(87, 22);
			this.f000264.TabIndex = 79;
			this.f000265.Location = new Point(424, 519);
			this.f000265.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown2 = this.f000265;
			int[] array4 = new int[4];
			array4[0] = 255;
			numericUpDown2.Maximum = new decimal(array4);
			this.f000265.Name = "m_nudTx3GainCodeSet120to130";
			this.f000265.Size = new Size(87, 22);
			this.f000265.TabIndex = 78;
			this.f000266.Location = new Point(424, 491);
			this.f000266.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown3 = this.f000266;
			int[] array5 = new int[4];
			array5[0] = 255;
			numericUpDown3.Maximum = new decimal(array5);
			this.f000266.Name = "m_nudTx3GainCodeSet110to120";
			this.f000266.Size = new Size(87, 22);
			this.f000266.TabIndex = 77;
			this.f000267.Location = new Point(424, 463);
			this.f000267.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown4 = this.f000267;
			int[] array6 = new int[4];
			array6[0] = 255;
			numericUpDown4.Maximum = new decimal(array6);
			this.f000267.Name = "m_nudTx3GainCodeSet100to110";
			this.f000267.Size = new Size(87, 22);
			this.f000267.TabIndex = 76;
			this.f000268.Location = new Point(424, 434);
			this.f000268.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown5 = this.f000268;
			int[] array7 = new int[4];
			array7[0] = 255;
			numericUpDown5.Maximum = new decimal(array7);
			this.f000268.Name = "m_nudTx3GainCodeSet90to100";
			this.f000268.Size = new Size(87, 22);
			this.f000268.TabIndex = 75;
			this.f000269.Location = new Point(424, 406);
			this.f000269.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown6 = this.f000269;
			int[] array8 = new int[4];
			array8[0] = 255;
			numericUpDown6.Maximum = new decimal(array8);
			this.f000269.Name = "m_nudTx3GainCodeSet80to90";
			this.f000269.Size = new Size(87, 22);
			this.f000269.TabIndex = 74;
			this.f00026a.Location = new Point(424, 378);
			this.f00026a.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown7 = this.f00026a;
			int[] array9 = new int[4];
			array9[0] = 255;
			numericUpDown7.Maximum = new decimal(array9);
			this.f00026a.Name = "m_nudTx3GainCodeSet70to80";
			this.f00026a.Size = new Size(87, 22);
			this.f00026a.TabIndex = 73;
			this.f00026b.Location = new Point(424, 350);
			this.f00026b.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown8 = this.f00026b;
			int[] array10 = new int[4];
			array10[0] = 255;
			numericUpDown8.Maximum = new decimal(array10);
			this.f00026b.Name = "m_nudTx3GainCodeSet60to70";
			this.f00026b.Size = new Size(87, 22);
			this.f00026b.TabIndex = 72;
			this.f00026c.Location = new Point(424, 321);
			this.f00026c.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown9 = this.f00026c;
			int[] array11 = new int[4];
			array11[0] = 255;
			numericUpDown9.Maximum = new decimal(array11);
			this.f00026c.Name = "m_nudTx3GainCodeSet50to60";
			this.f00026c.Size = new Size(87, 22);
			this.f00026c.TabIndex = 71;
			this.f00026d.Location = new Point(424, 293);
			this.f00026d.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown10 = this.f00026d;
			int[] array12 = new int[4];
			array12[0] = 255;
			numericUpDown10.Maximum = new decimal(array12);
			this.f00026d.Name = "m_nudTx3GainCodeSet40to50";
			this.f00026d.Size = new Size(87, 22);
			this.f00026d.TabIndex = 70;
			this.f00026e.Location = new Point(424, 265);
			this.f00026e.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown11 = this.f00026e;
			int[] array13 = new int[4];
			array13[0] = 255;
			numericUpDown11.Maximum = new decimal(array13);
			this.f00026e.Name = "m_nudTx3GainCodeSet30to40";
			this.f00026e.Size = new Size(87, 22);
			this.f00026e.TabIndex = 69;
			this.f00026f.Location = new Point(424, 236);
			this.f00026f.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown12 = this.f00026f;
			int[] array14 = new int[4];
			array14[0] = 255;
			numericUpDown12.Maximum = new decimal(array14);
			this.f00026f.Name = "m_nudTx3GainCodeSet20to30";
			this.f00026f.Size = new Size(87, 22);
			this.f00026f.TabIndex = 68;
			this.f000270.Location = new Point(424, 208);
			this.f000270.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown13 = this.f000270;
			int[] array15 = new int[4];
			array15[0] = 255;
			numericUpDown13.Maximum = new decimal(array15);
			this.f000270.Name = "m_nudTx3GainCodeSet10to20";
			this.f000270.Size = new Size(87, 22);
			this.f000270.TabIndex = 67;
			this.f000271.Location = new Point(424, 180);
			this.f000271.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown14 = this.f000271;
			int[] array16 = new int[4];
			array16[0] = 255;
			numericUpDown14.Maximum = new decimal(array16);
			this.f000271.Name = "m_nudTx3GainCodeSet0to10";
			this.f000271.Size = new Size(87, 22);
			this.f000271.TabIndex = 66;
			this.f000272.Location = new Point(424, 151);
			this.f000272.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown15 = this.f000272;
			int[] array17 = new int[4];
			array17[0] = 255;
			numericUpDown15.Maximum = new decimal(array17);
			this.f000272.Name = "m_nudTx3GainCodeSetNeg10to0";
			this.f000272.Size = new Size(87, 22);
			this.f000272.TabIndex = 65;
			this.f000273.Location = new Point(424, 123);
			this.f000273.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown16 = this.f000273;
			int[] array18 = new int[4];
			array18[0] = 255;
			numericUpDown16.Maximum = new decimal(array18);
			this.f000273.Name = "m_nudTx3GainCodeSetNeg20to10";
			this.f000273.Size = new Size(87, 22);
			this.f000273.TabIndex = 64;
			this.f000274.Location = new Point(424, 95);
			this.f000274.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown17 = this.f000274;
			int[] array19 = new int[4];
			array19[0] = 255;
			numericUpDown17.Maximum = new decimal(array19);
			this.f000274.Name = "m_nudTx3GainCodeSetNeg30to20";
			this.f000274.Size = new Size(87, 22);
			this.f000274.TabIndex = 63;
			this.m_nudTx3GainCodeSetLessNeg30.Location = new Point(424, 66);
			this.m_nudTx3GainCodeSetLessNeg30.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudTx3GainCodeSetLessNeg = this.m_nudTx3GainCodeSetLessNeg30;
			int[] array20 = new int[4];
			array20[0] = 255;
			nudTx3GainCodeSetLessNeg.Maximum = new decimal(array20);
			this.m_nudTx3GainCodeSetLessNeg30.Name = "m_nudTx3GainCodeSetLessNeg30";
			this.m_nudTx3GainCodeSetLessNeg30.Size = new Size(87, 22);
			this.m_nudTx3GainCodeSetLessNeg30.TabIndex = 62;
			this.m_nudTx2GainCodeSetMoreThan140.Location = new Point(280, 576);
			this.m_nudTx2GainCodeSetMoreThan140.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudTx2GainCodeSetMoreThan = this.m_nudTx2GainCodeSetMoreThan140;
			int[] array21 = new int[4];
			array21[0] = 255;
			nudTx2GainCodeSetMoreThan.Maximum = new decimal(array21);
			this.m_nudTx2GainCodeSetMoreThan140.Name = "m_nudTx2GainCodeSetMoreThan140";
			this.m_nudTx2GainCodeSetMoreThan140.Size = new Size(87, 22);
			this.m_nudTx2GainCodeSetMoreThan140.TabIndex = 61;
			this.f000275.Location = new Point(280, 548);
			this.f000275.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown18 = this.f000275;
			int[] array22 = new int[4];
			array22[0] = 255;
			numericUpDown18.Maximum = new decimal(array22);
			this.f000275.Name = "m_nudTx2GainCodeSet130to140";
			this.f000275.Size = new Size(87, 22);
			this.f000275.TabIndex = 60;
			this.f000276.Location = new Point(280, 519);
			this.f000276.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown19 = this.f000276;
			int[] array23 = new int[4];
			array23[0] = 255;
			numericUpDown19.Maximum = new decimal(array23);
			this.f000276.Name = "m_nudTx2GainCodeSet120to130";
			this.f000276.Size = new Size(87, 22);
			this.f000276.TabIndex = 59;
			this.f000277.Location = new Point(280, 491);
			this.f000277.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown20 = this.f000277;
			int[] array24 = new int[4];
			array24[0] = 255;
			numericUpDown20.Maximum = new decimal(array24);
			this.f000277.Name = "m_nudTx2GainCodeSet110to120";
			this.f000277.Size = new Size(87, 22);
			this.f000277.TabIndex = 58;
			this.f000278.Location = new Point(280, 463);
			this.f000278.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown21 = this.f000278;
			int[] array25 = new int[4];
			array25[0] = 255;
			numericUpDown21.Maximum = new decimal(array25);
			this.f000278.Name = "m_nudTx2GainCodeSet100to110";
			this.f000278.Size = new Size(87, 22);
			this.f000278.TabIndex = 57;
			this.f000279.Location = new Point(280, 434);
			this.f000279.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown22 = this.f000279;
			int[] array26 = new int[4];
			array26[0] = 255;
			numericUpDown22.Maximum = new decimal(array26);
			this.f000279.Name = "m_nudTx2GainCodeSet90to100";
			this.f000279.Size = new Size(87, 22);
			this.f000279.TabIndex = 56;
			this.f00027a.Location = new Point(280, 406);
			this.f00027a.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown23 = this.f00027a;
			int[] array27 = new int[4];
			array27[0] = 255;
			numericUpDown23.Maximum = new decimal(array27);
			this.f00027a.Name = "m_nudTx2GainCodeSet80to90";
			this.f00027a.Size = new Size(87, 22);
			this.f00027a.TabIndex = 55;
			this.f00027b.Location = new Point(280, 378);
			this.f00027b.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown24 = this.f00027b;
			int[] array28 = new int[4];
			array28[0] = 255;
			numericUpDown24.Maximum = new decimal(array28);
			this.f00027b.Name = "m_nudTx2GainCodeSet70to80";
			this.f00027b.Size = new Size(87, 22);
			this.f00027b.TabIndex = 54;
			this.f00027c.Location = new Point(280, 350);
			this.f00027c.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown25 = this.f00027c;
			int[] array29 = new int[4];
			array29[0] = 255;
			numericUpDown25.Maximum = new decimal(array29);
			this.f00027c.Name = "m_nudTx2GainCodeSet60to70";
			this.f00027c.Size = new Size(87, 22);
			this.f00027c.TabIndex = 53;
			this.f00027d.Location = new Point(280, 321);
			this.f00027d.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown26 = this.f00027d;
			int[] array30 = new int[4];
			array30[0] = 255;
			numericUpDown26.Maximum = new decimal(array30);
			this.f00027d.Name = "m_nudTx2GainCodeSet50to60";
			this.f00027d.Size = new Size(87, 22);
			this.f00027d.TabIndex = 52;
			this.f00027e.Location = new Point(280, 293);
			this.f00027e.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown27 = this.f00027e;
			int[] array31 = new int[4];
			array31[0] = 255;
			numericUpDown27.Maximum = new decimal(array31);
			this.f00027e.Name = "m_nudTx2GainCodeSet40to50";
			this.f00027e.Size = new Size(87, 22);
			this.f00027e.TabIndex = 51;
			this.f00027f.Location = new Point(280, 265);
			this.f00027f.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown28 = this.f00027f;
			int[] array32 = new int[4];
			array32[0] = 255;
			numericUpDown28.Maximum = new decimal(array32);
			this.f00027f.Name = "m_nudTx2GainCodeSet30to40";
			this.f00027f.Size = new Size(87, 22);
			this.f00027f.TabIndex = 50;
			this.f000280.Location = new Point(280, 236);
			this.f000280.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown29 = this.f000280;
			int[] array33 = new int[4];
			array33[0] = 255;
			numericUpDown29.Maximum = new decimal(array33);
			this.f000280.Name = "m_nudTx2GainCodeSet20to30";
			this.f000280.Size = new Size(87, 22);
			this.f000280.TabIndex = 49;
			this.f000281.Location = new Point(280, 208);
			this.f000281.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown30 = this.f000281;
			int[] array34 = new int[4];
			array34[0] = 255;
			numericUpDown30.Maximum = new decimal(array34);
			this.f000281.Name = "m_nudTx2GainCodeSet10to20";
			this.f000281.Size = new Size(87, 22);
			this.f000281.TabIndex = 48;
			this.f000282.Location = new Point(280, 180);
			this.f000282.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown31 = this.f000282;
			int[] array35 = new int[4];
			array35[0] = 255;
			numericUpDown31.Maximum = new decimal(array35);
			this.f000282.Name = "m_nudTx2GainCodeSet0to10";
			this.f000282.Size = new Size(87, 22);
			this.f000282.TabIndex = 47;
			this.f000283.Location = new Point(280, 151);
			this.f000283.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown32 = this.f000283;
			int[] array36 = new int[4];
			array36[0] = 255;
			numericUpDown32.Maximum = new decimal(array36);
			this.f000283.Name = "m_nudTx2GainCodeSetNeg10to0";
			this.f000283.Size = new Size(87, 22);
			this.f000283.TabIndex = 46;
			this.f000284.Location = new Point(280, 123);
			this.f000284.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown33 = this.f000284;
			int[] array37 = new int[4];
			array37[0] = 255;
			numericUpDown33.Maximum = new decimal(array37);
			this.f000284.Name = "m_nudTx2GainCodeSetNeg20to10";
			this.f000284.Size = new Size(87, 22);
			this.f000284.TabIndex = 45;
			this.f000285.Location = new Point(280, 95);
			this.f000285.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown34 = this.f000285;
			int[] array38 = new int[4];
			array38[0] = 255;
			numericUpDown34.Maximum = new decimal(array38);
			this.f000285.Name = "m_nudTx2GainCodeSetNeg30to20";
			this.f000285.Size = new Size(87, 22);
			this.f000285.TabIndex = 44;
			this.m_nudTx2GainCodeSetLessNeg30.Location = new Point(280, 66);
			this.m_nudTx2GainCodeSetLessNeg30.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudTx2GainCodeSetLessNeg = this.m_nudTx2GainCodeSetLessNeg30;
			int[] array39 = new int[4];
			array39[0] = 255;
			nudTx2GainCodeSetLessNeg.Maximum = new decimal(array39);
			this.m_nudTx2GainCodeSetLessNeg30.Name = "m_nudTx2GainCodeSetLessNeg30";
			this.m_nudTx2GainCodeSetLessNeg30.Size = new Size(87, 22);
			this.m_nudTx2GainCodeSetLessNeg30.TabIndex = 43;
			this.m_nudTx1GainCodeSetMoreThan140.Location = new Point(129, 576);
			this.m_nudTx1GainCodeSetMoreThan140.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudTx1GainCodeSetMoreThan = this.m_nudTx1GainCodeSetMoreThan140;
			int[] array40 = new int[4];
			array40[0] = 255;
			nudTx1GainCodeSetMoreThan.Maximum = new decimal(array40);
			this.m_nudTx1GainCodeSetMoreThan140.Name = "m_nudTx1GainCodeSetMoreThan140";
			this.m_nudTx1GainCodeSetMoreThan140.Size = new Size(87, 22);
			this.m_nudTx1GainCodeSetMoreThan140.TabIndex = 42;
			this.f000286.Location = new Point(129, 548);
			this.f000286.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown35 = this.f000286;
			int[] array41 = new int[4];
			array41[0] = 255;
			numericUpDown35.Maximum = new decimal(array41);
			this.f000286.Name = "m_nudTx1GainCodeSet130to140";
			this.f000286.Size = new Size(87, 22);
			this.f000286.TabIndex = 41;
			this.f000287.Location = new Point(129, 519);
			this.f000287.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown36 = this.f000287;
			int[] array42 = new int[4];
			array42[0] = 255;
			numericUpDown36.Maximum = new decimal(array42);
			this.f000287.Name = "m_nudTx1GainCodeSet120to130";
			this.f000287.Size = new Size(87, 22);
			this.f000287.TabIndex = 40;
			this.f000288.Location = new Point(129, 491);
			this.f000288.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown37 = this.f000288;
			int[] array43 = new int[4];
			array43[0] = 255;
			numericUpDown37.Maximum = new decimal(array43);
			this.f000288.Name = "m_nudTx1GainCodeSet110to120";
			this.f000288.Size = new Size(87, 22);
			this.f000288.TabIndex = 39;
			this.f000289.Location = new Point(129, 463);
			this.f000289.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown38 = this.f000289;
			int[] array44 = new int[4];
			array44[0] = 255;
			numericUpDown38.Maximum = new decimal(array44);
			this.f000289.Name = "m_nudTx1GainCodeSet100to110";
			this.f000289.Size = new Size(87, 22);
			this.f000289.TabIndex = 38;
			this.f00028a.Location = new Point(129, 434);
			this.f00028a.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown39 = this.f00028a;
			int[] array45 = new int[4];
			array45[0] = 255;
			numericUpDown39.Maximum = new decimal(array45);
			this.f00028a.Name = "m_nudTx1GainCodeSet90to100";
			this.f00028a.Size = new Size(87, 22);
			this.f00028a.TabIndex = 37;
			this.f00028b.Location = new Point(129, 406);
			this.f00028b.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown40 = this.f00028b;
			int[] array46 = new int[4];
			array46[0] = 255;
			numericUpDown40.Maximum = new decimal(array46);
			this.f00028b.Name = "m_nudTx1GainCodeSet80to90";
			this.f00028b.Size = new Size(87, 22);
			this.f00028b.TabIndex = 36;
			this.f00028c.Location = new Point(129, 378);
			this.f00028c.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown41 = this.f00028c;
			int[] array47 = new int[4];
			array47[0] = 255;
			numericUpDown41.Maximum = new decimal(array47);
			this.f00028c.Name = "m_nudTx1GainCodeSet70to80";
			this.f00028c.Size = new Size(87, 22);
			this.f00028c.TabIndex = 35;
			this.f00028d.Location = new Point(129, 350);
			this.f00028d.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown42 = this.f00028d;
			int[] array48 = new int[4];
			array48[0] = 255;
			numericUpDown42.Maximum = new decimal(array48);
			this.f00028d.Name = "m_nudTx1GainCodeSet60to70";
			this.f00028d.Size = new Size(87, 22);
			this.f00028d.TabIndex = 34;
			this.f00028e.Location = new Point(129, 321);
			this.f00028e.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown43 = this.f00028e;
			int[] array49 = new int[4];
			array49[0] = 255;
			numericUpDown43.Maximum = new decimal(array49);
			this.f00028e.Name = "m_nudTx1GainCodeSet50to60";
			this.f00028e.Size = new Size(87, 22);
			this.f00028e.TabIndex = 33;
			this.f00028f.Location = new Point(129, 293);
			this.f00028f.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown44 = this.f00028f;
			int[] array50 = new int[4];
			array50[0] = 255;
			numericUpDown44.Maximum = new decimal(array50);
			this.f00028f.Name = "m_nudTx1GainCodeSet40to50";
			this.f00028f.Size = new Size(87, 22);
			this.f00028f.TabIndex = 32;
			this.f000290.Location = new Point(129, 265);
			this.f000290.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown45 = this.f000290;
			int[] array51 = new int[4];
			array51[0] = 255;
			numericUpDown45.Maximum = new decimal(array51);
			this.f000290.Name = "m_nudTx1GainCodeSet30to40";
			this.f000290.Size = new Size(87, 22);
			this.f000290.TabIndex = 31;
			this.f000291.Location = new Point(129, 236);
			this.f000291.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown46 = this.f000291;
			int[] array52 = new int[4];
			array52[0] = 255;
			numericUpDown46.Maximum = new decimal(array52);
			this.f000291.Name = "m_nudTx1GainCodeSet20to30";
			this.f000291.Size = new Size(87, 22);
			this.f000291.TabIndex = 30;
			this.f000292.Location = new Point(129, 208);
			this.f000292.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown47 = this.f000292;
			int[] array53 = new int[4];
			array53[0] = 255;
			numericUpDown47.Maximum = new decimal(array53);
			this.f000292.Name = "m_nudTx1GainCodeSet10to20";
			this.f000292.Size = new Size(87, 22);
			this.f000292.TabIndex = 29;
			this.f000293.Location = new Point(129, 180);
			this.f000293.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown48 = this.f000293;
			int[] array54 = new int[4];
			array54[0] = 255;
			numericUpDown48.Maximum = new decimal(array54);
			this.f000293.Name = "m_nudTx1GainCodeSet0to10";
			this.f000293.Size = new Size(87, 22);
			this.f000293.TabIndex = 28;
			this.f000294.Location = new Point(129, 151);
			this.f000294.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown49 = this.f000294;
			int[] array55 = new int[4];
			array55[0] = 255;
			numericUpDown49.Maximum = new decimal(array55);
			this.f000294.Name = "m_nudTx1GainCodeSetNeg10to0";
			this.f000294.Size = new Size(87, 22);
			this.f000294.TabIndex = 27;
			this.f000295.Location = new Point(129, 123);
			this.f000295.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown50 = this.f000295;
			int[] array56 = new int[4];
			array56[0] = 255;
			numericUpDown50.Maximum = new decimal(array56);
			this.f000295.Name = "m_nudTx1GainCodeSetNeg20to10";
			this.f000295.Size = new Size(87, 22);
			this.f000295.TabIndex = 26;
			this.f000296.Location = new Point(129, 95);
			this.f000296.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown51 = this.f000296;
			int[] array57 = new int[4];
			array57[0] = 255;
			numericUpDown51.Maximum = new decimal(array57);
			this.f000296.Name = "m_nudTx1GainCodeSetNeg30to20";
			this.f000296.Size = new Size(87, 22);
			this.f000296.TabIndex = 25;
			this.m_nudTx1GainCodeSetLessNeg30.Location = new Point(129, 66);
			this.m_nudTx1GainCodeSetLessNeg30.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudTx1GainCodeSetLessNeg = this.m_nudTx1GainCodeSetLessNeg30;
			int[] array58 = new int[4];
			array58[0] = 255;
			nudTx1GainCodeSetLessNeg.Maximum = new decimal(array58);
			this.m_nudTx1GainCodeSetLessNeg30.Name = "m_nudTx1GainCodeSetLessNeg30";
			this.m_nudTx1GainCodeSetLessNeg30.Size = new Size(87, 22);
			this.m_nudTx1GainCodeSetLessNeg30.TabIndex = 24;
			this.label45.AutoSize = true;
			this.label45.Location = new Point(420, 47);
			this.label45.Margin = new Padding(4, 0, 4, 0);
			this.label45.Name = "label45";
			this.label45.Size = new Size(133, 17);
			this.label45.TabIndex = 23;
			this.label45.Text = "Tx2 Gain Code (dB)";
			this.label44.AutoSize = true;
			this.label44.Location = new Point(276, 47);
			this.label44.Margin = new Padding(4, 0, 4, 0);
			this.label44.Name = "label44";
			this.label44.Size = new Size(133, 17);
			this.label44.TabIndex = 22;
			this.label44.Text = "Tx1 Gain Code (dB)";
			this.label43.AutoSize = true;
			this.label43.Location = new Point(125, 47);
			this.label43.Margin = new Padding(4, 0, 4, 0);
			this.label43.Name = "label43";
			this.label43.Size = new Size(137, 17);
			this.label43.TabIndex = 21;
			this.label43.Text = "Tx0 Gain Code  (dB)";
			this.label20.AutoSize = true;
			this.label20.Location = new Point(7, 581);
			this.label20.Margin = new Padding(4, 0, 4, 0);
			this.label20.Name = "label20";
			this.label20.Size = new Size(116, 17);
			this.label20.TabIndex = 19;
			this.label20.Text = " Temp [   >= 140]";
			this.label21.AutoSize = true;
			this.label21.Location = new Point(7, 553);
			this.label21.Margin = new Padding(4, 0, 4, 0);
			this.label21.Name = "label21";
			this.label21.Size = new Size(116, 17);
			this.label21.TabIndex = 18;
			this.label21.Text = " Temp [130, 140]";
			this.label16.AutoSize = true;
			this.label16.Location = new Point(7, 524);
			this.label16.Margin = new Padding(4, 0, 4, 0);
			this.label16.Name = "label16";
			this.label16.Size = new Size(116, 17);
			this.label16.TabIndex = 17;
			this.label16.Text = " Temp [120, 130]";
			this.label17.AutoSize = true;
			this.label17.Location = new Point(7, 497);
			this.label17.Margin = new Padding(4, 0, 4, 0);
			this.label17.Name = "label17";
			this.label17.Size = new Size(116, 17);
			this.label17.TabIndex = 16;
			this.label17.Text = " Temp [110, 120]";
			this.label18.AutoSize = true;
			this.label18.Location = new Point(7, 468);
			this.label18.Margin = new Padding(4, 0, 4, 0);
			this.label18.Name = "label18";
			this.label18.Size = new Size(116, 17);
			this.label18.TabIndex = 15;
			this.label18.Text = " Temp [100, 110]";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(7, 441);
			this.label13.Margin = new Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new Size(108, 17);
			this.label13.TabIndex = 14;
			this.label13.Text = " Temp [90, 100]";
			this.label14.AutoSize = true;
			this.label14.Location = new Point(7, 411);
			this.label14.Margin = new Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new Size(100, 17);
			this.label14.TabIndex = 13;
			this.label14.Text = " Temp [80, 90]";
			this.label15.AutoSize = true;
			this.label15.Location = new Point(7, 384);
			this.label15.Margin = new Padding(4, 0, 4, 0);
			this.label15.Name = "label15";
			this.label15.Size = new Size(100, 17);
			this.label15.TabIndex = 12;
			this.label15.Text = " Temp [70, 80]";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(7, 271);
			this.label10.Margin = new Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new Size(100, 17);
			this.label10.TabIndex = 11;
			this.label10.Text = " Temp [30, 40]";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(7, 241);
			this.label11.Margin = new Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new Size(100, 17);
			this.label11.TabIndex = 10;
			this.label11.Text = " Temp [20, 30]";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(7, 214);
			this.label12.Margin = new Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new Size(100, 17);
			this.label12.TabIndex = 9;
			this.label12.Text = " Temp [10, 20]";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(7, 357);
			this.label7.Margin = new Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(100, 17);
			this.label7.TabIndex = 8;
			this.label7.Text = " Temp [60, 70]";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(7, 327);
			this.label8.Margin = new Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(100, 17);
			this.label8.TabIndex = 7;
			this.label8.Text = " Temp [50, 60]";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(7, 302);
			this.label9.Margin = new Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new Size(100, 17);
			this.label9.TabIndex = 6;
			this.label9.Text = " Temp [40, 50]";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(7, 185);
			this.label4.Margin = new Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(92, 17);
			this.label4.TabIndex = 5;
			this.label4.Text = " Temp [0, 10]";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(7, 156);
			this.label5.Margin = new Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(97, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = " Temp [-10, 0]";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(7, 128);
			this.label6.Margin = new Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new Size(110, 17);
			this.label6.TabIndex = 3;
			this.label6.Text = " Temp [-20, -10]";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(7, 100);
			this.label3.Margin = new Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(110, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = " Temp [-30, -20]";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(7, 71);
			this.label2.Margin = new Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(101, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = " Temp [ < -30] ";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(7, 20);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(85, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Profile Index";
			this.groupBox2.Controls.Add(this.m_btnRxGainTempLUTConfigGet);
			this.groupBox2.Controls.Add(this.m_btnRxGainTempLUTConfigSet);
			this.groupBox2.Controls.Add(this.m_nudRx1GainCodeSetMoreThan140);
			this.groupBox2.Controls.Add(this.m_nudRXGainTempSetProfileIndex);
			this.groupBox2.Controls.Add(this.label19);
			this.groupBox2.Controls.Add(this.f000297);
			this.groupBox2.Controls.Add(this.f000298);
			this.groupBox2.Controls.Add(this.f000299);
			this.groupBox2.Controls.Add(this.f00029a);
			this.groupBox2.Controls.Add(this.f00029b);
			this.groupBox2.Controls.Add(this.f00029c);
			this.groupBox2.Controls.Add(this.f00029d);
			this.groupBox2.Controls.Add(this.f00029e);
			this.groupBox2.Controls.Add(this.f00029f);
			this.groupBox2.Controls.Add(this.f0002a0);
			this.groupBox2.Controls.Add(this.f0002a1);
			this.groupBox2.Controls.Add(this.f0002a2);
			this.groupBox2.Controls.Add(this.f0002a3);
			this.groupBox2.Controls.Add(this.f0002a4);
			this.groupBox2.Controls.Add(this.f0002a5);
			this.groupBox2.Controls.Add(this.f0002a6);
			this.groupBox2.Controls.Add(this.f0002a7);
			this.groupBox2.Controls.Add(this.m_nudRx1GainCodeSetLessNeg30);
			this.groupBox2.Controls.Add(this.label22);
			this.groupBox2.Controls.Add(this.label23);
			this.groupBox2.Controls.Add(this.label25);
			this.groupBox2.Controls.Add(this.label26);
			this.groupBox2.Controls.Add(this.label27);
			this.groupBox2.Controls.Add(this.label28);
			this.groupBox2.Controls.Add(this.label29);
			this.groupBox2.Controls.Add(this.label30);
			this.groupBox2.Controls.Add(this.label31);
			this.groupBox2.Controls.Add(this.label32);
			this.groupBox2.Controls.Add(this.label33);
			this.groupBox2.Controls.Add(this.label34);
			this.groupBox2.Controls.Add(this.label35);
			this.groupBox2.Controls.Add(this.label36);
			this.groupBox2.Controls.Add(this.label37);
			this.groupBox2.Controls.Add(this.label38);
			this.groupBox2.Controls.Add(this.label39);
			this.groupBox2.Controls.Add(this.label40);
			this.groupBox2.Controls.Add(this.label41);
			this.groupBox2.Controls.Add(this.label42);
			this.groupBox2.Location = new Point(601, 4);
			this.groupBox2.Margin = new Padding(4, 4, 4, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new Padding(4, 4, 4, 4);
			this.groupBox2.Size = new Size(268, 649);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Rx Gain Temp LUT Config";
			this.m_btnRxGainTempLUTConfigGet.Location = new Point(140, 609);
			this.m_btnRxGainTempLUTConfigGet.Margin = new Padding(4, 4, 4, 4);
			this.m_btnRxGainTempLUTConfigGet.Name = "m_btnRxGainTempLUTConfigGet";
			this.m_btnRxGainTempLUTConfigGet.Size = new Size(88, 28);
			this.m_btnRxGainTempLUTConfigGet.TabIndex = 66;
			this.m_btnRxGainTempLUTConfigGet.Text = "Get";
			this.m_btnRxGainTempLUTConfigGet.UseVisualStyleBackColor = true;
			this.m_btnRxGainTempLUTConfigGet.Click += this.m_btnRxGainTempLUTConfigGet_Click;
			this.m_btnRxGainTempLUTConfigSet.Location = new Point(19, 609);
			this.m_btnRxGainTempLUTConfigSet.Margin = new Padding(4, 4, 4, 4);
			this.m_btnRxGainTempLUTConfigSet.Name = "m_btnRxGainTempLUTConfigSet";
			this.m_btnRxGainTempLUTConfigSet.Size = new Size(88, 28);
			this.m_btnRxGainTempLUTConfigSet.TabIndex = 65;
			this.m_btnRxGainTempLUTConfigSet.Text = "Set";
			this.m_btnRxGainTempLUTConfigSet.UseVisualStyleBackColor = true;
			this.m_btnRxGainTempLUTConfigSet.Click += this.m_btnRxGainTempLUTConfigSet_Click;
			this.m_nudRx1GainCodeSetMoreThan140.Location = new Point(140, 576);
			this.m_nudRx1GainCodeSetMoreThan140.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudRx1GainCodeSetMoreThan = this.m_nudRx1GainCodeSetMoreThan140;
			int[] array59 = new int[4];
			array59[0] = 255;
			nudRx1GainCodeSetMoreThan.Maximum = new decimal(array59);
			this.m_nudRx1GainCodeSetMoreThan140.Name = "m_nudRx1GainCodeSetMoreThan140";
			this.m_nudRx1GainCodeSetMoreThan140.Size = new Size(87, 22);
			this.m_nudRx1GainCodeSetMoreThan140.TabIndex = 64;
			this.m_nudRXGainTempSetProfileIndex.Location = new Point(140, 20);
			this.m_nudRXGainTempSetProfileIndex.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudRXGainTempSetProfileIndex = this.m_nudRXGainTempSetProfileIndex;
			int[] array60 = new int[4];
			array60[0] = 3;
			nudRXGainTempSetProfileIndex.Maximum = new decimal(array60);
			this.m_nudRXGainTempSetProfileIndex.Name = "m_nudRXGainTempSetProfileIndex";
			this.m_nudRXGainTempSetProfileIndex.Size = new Size(87, 22);
			this.m_nudRXGainTempSetProfileIndex.TabIndex = 63;
			this.label19.AutoSize = true;
			this.label19.Location = new Point(7, 20);
			this.label19.Margin = new Padding(4, 0, 4, 0);
			this.label19.Name = "label19";
			this.label19.Size = new Size(85, 17);
			this.label19.TabIndex = 62;
			this.label19.Text = "Profile Index";
			this.f000297.Location = new Point(140, 548);
			this.f000297.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown52 = this.f000297;
			int[] array61 = new int[4];
			array61[0] = 255;
			numericUpDown52.Maximum = new decimal(array61);
			this.f000297.Name = "m_nudRx1GainCodeSet130to140";
			this.f000297.Size = new Size(87, 22);
			this.f000297.TabIndex = 60;
			this.f000298.Location = new Point(140, 519);
			this.f000298.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown53 = this.f000298;
			int[] array62 = new int[4];
			array62[0] = 255;
			numericUpDown53.Maximum = new decimal(array62);
			this.f000298.Name = "m_nudRx1GainCodeSet120to130";
			this.f000298.Size = new Size(87, 22);
			this.f000298.TabIndex = 59;
			this.f000299.Location = new Point(140, 491);
			this.f000299.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown54 = this.f000299;
			int[] array63 = new int[4];
			array63[0] = 255;
			numericUpDown54.Maximum = new decimal(array63);
			this.f000299.Name = "m_nudRx1GainCodeSet110to120";
			this.f000299.Size = new Size(87, 22);
			this.f000299.TabIndex = 58;
			this.f00029a.Location = new Point(140, 463);
			this.f00029a.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown55 = this.f00029a;
			int[] array64 = new int[4];
			array64[0] = 255;
			numericUpDown55.Maximum = new decimal(array64);
			this.f00029a.Name = "m_nudRx1GainCodeSet100to110";
			this.f00029a.Size = new Size(87, 22);
			this.f00029a.TabIndex = 57;
			this.f00029b.Location = new Point(140, 434);
			this.f00029b.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown56 = this.f00029b;
			int[] array65 = new int[4];
			array65[0] = 255;
			numericUpDown56.Maximum = new decimal(array65);
			this.f00029b.Name = "m_nudRx1GainCodeSet90to100";
			this.f00029b.Size = new Size(87, 22);
			this.f00029b.TabIndex = 56;
			this.f00029c.Location = new Point(140, 406);
			this.f00029c.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown57 = this.f00029c;
			int[] array66 = new int[4];
			array66[0] = 255;
			numericUpDown57.Maximum = new decimal(array66);
			this.f00029c.Name = "m_nudRx1GainCodeSet80to90";
			this.f00029c.Size = new Size(87, 22);
			this.f00029c.TabIndex = 55;
			this.f00029d.Location = new Point(140, 378);
			this.f00029d.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown58 = this.f00029d;
			int[] array67 = new int[4];
			array67[0] = 255;
			numericUpDown58.Maximum = new decimal(array67);
			this.f00029d.Name = "m_nudRx1GainCodeSet70to80";
			this.f00029d.Size = new Size(87, 22);
			this.f00029d.TabIndex = 54;
			this.f00029e.Location = new Point(140, 350);
			this.f00029e.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown59 = this.f00029e;
			int[] array68 = new int[4];
			array68[0] = 255;
			numericUpDown59.Maximum = new decimal(array68);
			this.f00029e.Name = "m_nudRx1GainCodeSet60to70";
			this.f00029e.Size = new Size(87, 22);
			this.f00029e.TabIndex = 53;
			this.f00029f.Location = new Point(140, 321);
			this.f00029f.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown60 = this.f00029f;
			int[] array69 = new int[4];
			array69[0] = 255;
			numericUpDown60.Maximum = new decimal(array69);
			this.f00029f.Name = "m_nudRx1GainCodeSet50to60";
			this.f00029f.Size = new Size(87, 22);
			this.f00029f.TabIndex = 52;
			this.f0002a0.Location = new Point(140, 293);
			this.f0002a0.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown61 = this.f0002a0;
			int[] array70 = new int[4];
			array70[0] = 255;
			numericUpDown61.Maximum = new decimal(array70);
			this.f0002a0.Name = "m_nudRx1GainCodeSet40to50";
			this.f0002a0.Size = new Size(87, 22);
			this.f0002a0.TabIndex = 51;
			this.f0002a1.Location = new Point(140, 265);
			this.f0002a1.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown62 = this.f0002a1;
			int[] array71 = new int[4];
			array71[0] = 255;
			numericUpDown62.Maximum = new decimal(array71);
			this.f0002a1.Name = "m_nudRx1GainCodeSet30to40";
			this.f0002a1.Size = new Size(87, 22);
			this.f0002a1.TabIndex = 50;
			this.f0002a2.Location = new Point(140, 236);
			this.f0002a2.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown63 = this.f0002a2;
			int[] array72 = new int[4];
			array72[0] = 255;
			numericUpDown63.Maximum = new decimal(array72);
			this.f0002a2.Name = "m_nudRx1GainCodeSet20to30";
			this.f0002a2.Size = new Size(87, 22);
			this.f0002a2.TabIndex = 49;
			this.f0002a3.Location = new Point(140, 208);
			this.f0002a3.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown64 = this.f0002a3;
			int[] array73 = new int[4];
			array73[0] = 255;
			numericUpDown64.Maximum = new decimal(array73);
			this.f0002a3.Name = "m_nudRx1GainCodeSet10to20";
			this.f0002a3.Size = new Size(87, 22);
			this.f0002a3.TabIndex = 48;
			this.f0002a4.Location = new Point(140, 180);
			this.f0002a4.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown65 = this.f0002a4;
			int[] array74 = new int[4];
			array74[0] = 255;
			numericUpDown65.Maximum = new decimal(array74);
			this.f0002a4.Name = "m_nudRx1GainCodeSet0to10";
			this.f0002a4.Size = new Size(87, 22);
			this.f0002a4.TabIndex = 47;
			this.f0002a5.Location = new Point(140, 151);
			this.f0002a5.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown66 = this.f0002a5;
			int[] array75 = new int[4];
			array75[0] = 255;
			numericUpDown66.Maximum = new decimal(array75);
			this.f0002a5.Name = "m_nudRx1GainCodeSetNeg10to0";
			this.f0002a5.Size = new Size(87, 22);
			this.f0002a5.TabIndex = 46;
			this.f0002a6.Location = new Point(140, 123);
			this.f0002a6.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown67 = this.f0002a6;
			int[] array76 = new int[4];
			array76[0] = 255;
			numericUpDown67.Maximum = new decimal(array76);
			this.f0002a6.Name = "m_nudRx1GainCodeSetNeg20to10";
			this.f0002a6.Size = new Size(87, 22);
			this.f0002a6.TabIndex = 45;
			this.f0002a7.Location = new Point(140, 95);
			this.f0002a7.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown numericUpDown68 = this.f0002a7;
			int[] array77 = new int[4];
			array77[0] = 255;
			numericUpDown68.Maximum = new decimal(array77);
			this.f0002a7.Name = "m_nudRx1GainCodeSetNeg30to20";
			this.f0002a7.Size = new Size(87, 22);
			this.f0002a7.TabIndex = 44;
			this.m_nudRx1GainCodeSetLessNeg30.Location = new Point(140, 66);
			this.m_nudRx1GainCodeSetLessNeg30.Margin = new Padding(4, 4, 4, 4);
			NumericUpDown nudRx1GainCodeSetLessNeg = this.m_nudRx1GainCodeSetLessNeg30;
			int[] array78 = new int[4];
			array78[0] = 255;
			nudRx1GainCodeSetLessNeg.Maximum = new decimal(array78);
			this.m_nudRx1GainCodeSetLessNeg30.Name = "m_nudRx1GainCodeSetLessNeg30";
			this.m_nudRx1GainCodeSetLessNeg30.Size = new Size(87, 22);
			this.m_nudRx1GainCodeSetLessNeg30.TabIndex = 43;
			this.label22.AutoSize = true;
			this.label22.Location = new Point(132, 47);
			this.label22.Margin = new Padding(4, 0, 4, 0);
			this.label22.Name = "label22";
			this.label22.Size = new Size(126, 17);
			this.label22.TabIndex = 41;
			this.label22.Text = "Rx Gain Code (dB)";
			this.label23.AutoSize = true;
			this.label23.Location = new Point(7, 581);
			this.label23.Margin = new Padding(4, 0, 4, 0);
			this.label23.Name = "label23";
			this.label23.Size = new Size(116, 17);
			this.label23.TabIndex = 40;
			this.label23.Text = " Temp [   >= 140]";
			this.label25.AutoSize = true;
			this.label25.Location = new Point(7, 554);
			this.label25.Margin = new Padding(4, 0, 4, 0);
			this.label25.Name = "label25";
			this.label25.Size = new Size(116, 17);
			this.label25.TabIndex = 38;
			this.label25.Text = " Temp [130, 140]";
			this.label26.AutoSize = true;
			this.label26.Location = new Point(7, 524);
			this.label26.Margin = new Padding(4, 0, 4, 0);
			this.label26.Name = "label26";
			this.label26.Size = new Size(116, 17);
			this.label26.TabIndex = 37;
			this.label26.Text = " Temp [120, 130]";
			this.label27.AutoSize = true;
			this.label27.Location = new Point(7, 496);
			this.label27.Margin = new Padding(4, 0, 4, 0);
			this.label27.Name = "label27";
			this.label27.Size = new Size(116, 17);
			this.label27.TabIndex = 36;
			this.label27.Text = " Temp [110, 120]";
			this.label28.AutoSize = true;
			this.label28.Location = new Point(7, 469);
			this.label28.Margin = new Padding(4, 0, 4, 0);
			this.label28.Name = "label28";
			this.label28.Size = new Size(116, 17);
			this.label28.TabIndex = 35;
			this.label28.Text = " Temp [100, 110]";
			this.label29.AutoSize = true;
			this.label29.Location = new Point(7, 439);
			this.label29.Margin = new Padding(4, 0, 4, 0);
			this.label29.Name = "label29";
			this.label29.Size = new Size(108, 17);
			this.label29.TabIndex = 34;
			this.label29.Text = " Temp [90, 100]";
			this.label30.AutoSize = true;
			this.label30.Location = new Point(7, 414);
			this.label30.Margin = new Padding(4, 0, 4, 0);
			this.label30.Name = "label30";
			this.label30.Size = new Size(100, 17);
			this.label30.TabIndex = 33;
			this.label30.Text = " Temp [80, 90]";
			this.label31.AutoSize = true;
			this.label31.Location = new Point(7, 298);
			this.label31.Margin = new Padding(4, 0, 4, 0);
			this.label31.Name = "label31";
			this.label31.Size = new Size(100, 17);
			this.label31.TabIndex = 32;
			this.label31.Text = " Temp [40, 50]";
			this.label32.AutoSize = true;
			this.label32.Location = new Point(7, 270);
			this.label32.Margin = new Padding(4, 0, 4, 0);
			this.label32.Name = "label32";
			this.label32.Size = new Size(100, 17);
			this.label32.TabIndex = 31;
			this.label32.Text = " Temp [30, 40]";
			this.label33.AutoSize = true;
			this.label33.Location = new Point(7, 242);
			this.label33.Margin = new Padding(4, 0, 4, 0);
			this.label33.Name = "label33";
			this.label33.Size = new Size(100, 17);
			this.label33.TabIndex = 30;
			this.label33.Text = " Temp [20, 30]";
			this.label34.AutoSize = true;
			this.label34.Location = new Point(7, 385);
			this.label34.Margin = new Padding(4, 0, 4, 0);
			this.label34.Name = "label34";
			this.label34.Size = new Size(100, 17);
			this.label34.TabIndex = 29;
			this.label34.Text = " Temp [70, 80]";
			this.label35.AutoSize = true;
			this.label35.Location = new Point(7, 354);
			this.label35.Margin = new Padding(4, 0, 4, 0);
			this.label35.Name = "label35";
			this.label35.Size = new Size(100, 17);
			this.label35.TabIndex = 28;
			this.label35.Text = " Temp [60, 70]";
			this.label36.AutoSize = true;
			this.label36.Location = new Point(7, 327);
			this.label36.Margin = new Padding(4, 0, 4, 0);
			this.label36.Name = "label36";
			this.label36.Size = new Size(100, 17);
			this.label36.TabIndex = 27;
			this.label36.Text = " Temp [50, 60]";
			this.label37.AutoSize = true;
			this.label37.Location = new Point(7, 214);
			this.label37.Margin = new Padding(4, 0, 4, 0);
			this.label37.Name = "label37";
			this.label37.Size = new Size(100, 17);
			this.label37.TabIndex = 26;
			this.label37.Text = " Temp [10, 20]";
			this.label38.AutoSize = true;
			this.label38.Location = new Point(7, 186);
			this.label38.Margin = new Padding(4, 0, 4, 0);
			this.label38.Name = "label38";
			this.label38.Size = new Size(92, 17);
			this.label38.TabIndex = 25;
			this.label38.Text = " Temp [0, 10]";
			this.label39.AutoSize = true;
			this.label39.Location = new Point(7, 155);
			this.label39.Margin = new Padding(4, 0, 4, 0);
			this.label39.Name = "label39";
			this.label39.Size = new Size(97, 17);
			this.label39.TabIndex = 24;
			this.label39.Text = " Temp [-10, 0]";
			this.label40.AutoSize = true;
			this.label40.Location = new Point(7, 127);
			this.label40.Margin = new Padding(4, 0, 4, 0);
			this.label40.Name = "label40";
			this.label40.Size = new Size(110, 17);
			this.label40.TabIndex = 23;
			this.label40.Text = " Temp [-20, -10]";
			this.label41.AutoSize = true;
			this.label41.Location = new Point(7, 100);
			this.label41.Margin = new Padding(4, 0, 4, 0);
			this.label41.Name = "label41";
			this.label41.Size = new Size(110, 17);
			this.label41.TabIndex = 22;
			this.label41.Text = " Temp [-30, -20]";
			this.label42.AutoSize = true;
			this.label42.Location = new Point(7, 74);
			this.label42.Margin = new Padding(4, 0, 4, 0);
			this.label42.Name = "label42";
			this.label42.Size = new Size(101, 17);
			this.label42.TabIndex = 21;
			this.label42.Text = " Temp [ < -30] ";
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Margin = new Padding(4, 4, 4, 4);
			base.Name = "TxRxGainTempLUTCfg";
			base.Size = new Size(1533, 676);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.m_nudTXGainTempSetProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudTx3GainCodeSetMoreThan140).EndInit();
			((ISupportInitialize)this.f000264).EndInit();
			((ISupportInitialize)this.f000265).EndInit();
			((ISupportInitialize)this.f000266).EndInit();
			((ISupportInitialize)this.f000267).EndInit();
			((ISupportInitialize)this.f000268).EndInit();
			((ISupportInitialize)this.f000269).EndInit();
			((ISupportInitialize)this.f00026a).EndInit();
			((ISupportInitialize)this.f00026b).EndInit();
			((ISupportInitialize)this.f00026c).EndInit();
			((ISupportInitialize)this.f00026d).EndInit();
			((ISupportInitialize)this.f00026e).EndInit();
			((ISupportInitialize)this.f00026f).EndInit();
			((ISupportInitialize)this.f000270).EndInit();
			((ISupportInitialize)this.f000271).EndInit();
			((ISupportInitialize)this.f000272).EndInit();
			((ISupportInitialize)this.f000273).EndInit();
			((ISupportInitialize)this.f000274).EndInit();
			((ISupportInitialize)this.m_nudTx3GainCodeSetLessNeg30).EndInit();
			((ISupportInitialize)this.m_nudTx2GainCodeSetMoreThan140).EndInit();
			((ISupportInitialize)this.f000275).EndInit();
			((ISupportInitialize)this.f000276).EndInit();
			((ISupportInitialize)this.f000277).EndInit();
			((ISupportInitialize)this.f000278).EndInit();
			((ISupportInitialize)this.f000279).EndInit();
			((ISupportInitialize)this.f00027a).EndInit();
			((ISupportInitialize)this.f00027b).EndInit();
			((ISupportInitialize)this.f00027c).EndInit();
			((ISupportInitialize)this.f00027d).EndInit();
			((ISupportInitialize)this.f00027e).EndInit();
			((ISupportInitialize)this.f00027f).EndInit();
			((ISupportInitialize)this.f000280).EndInit();
			((ISupportInitialize)this.f000281).EndInit();
			((ISupportInitialize)this.f000282).EndInit();
			((ISupportInitialize)this.f000283).EndInit();
			((ISupportInitialize)this.f000284).EndInit();
			((ISupportInitialize)this.f000285).EndInit();
			((ISupportInitialize)this.m_nudTx2GainCodeSetLessNeg30).EndInit();
			((ISupportInitialize)this.m_nudTx1GainCodeSetMoreThan140).EndInit();
			((ISupportInitialize)this.f000286).EndInit();
			((ISupportInitialize)this.f000287).EndInit();
			((ISupportInitialize)this.f000288).EndInit();
			((ISupportInitialize)this.f000289).EndInit();
			((ISupportInitialize)this.f00028a).EndInit();
			((ISupportInitialize)this.f00028b).EndInit();
			((ISupportInitialize)this.f00028c).EndInit();
			((ISupportInitialize)this.f00028d).EndInit();
			((ISupportInitialize)this.f00028e).EndInit();
			((ISupportInitialize)this.f00028f).EndInit();
			((ISupportInitialize)this.f000290).EndInit();
			((ISupportInitialize)this.f000291).EndInit();
			((ISupportInitialize)this.f000292).EndInit();
			((ISupportInitialize)this.f000293).EndInit();
			((ISupportInitialize)this.f000294).EndInit();
			((ISupportInitialize)this.f000295).EndInit();
			((ISupportInitialize)this.f000296).EndInit();
			((ISupportInitialize)this.m_nudTx1GainCodeSetLessNeg30).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((ISupportInitialize)this.m_nudRx1GainCodeSetMoreThan140).EndInit();
			((ISupportInitialize)this.m_nudRXGainTempSetProfileIndex).EndInit();
			((ISupportInitialize)this.f000297).EndInit();
			((ISupportInitialize)this.f000298).EndInit();
			((ISupportInitialize)this.f000299).EndInit();
			((ISupportInitialize)this.f00029a).EndInit();
			((ISupportInitialize)this.f00029b).EndInit();
			((ISupportInitialize)this.f00029c).EndInit();
			((ISupportInitialize)this.f00029d).EndInit();
			((ISupportInitialize)this.f00029e).EndInit();
			((ISupportInitialize)this.f00029f).EndInit();
			((ISupportInitialize)this.f0002a0).EndInit();
			((ISupportInitialize)this.f0002a1).EndInit();
			((ISupportInitialize)this.f0002a2).EndInit();
			((ISupportInitialize)this.f0002a3).EndInit();
			((ISupportInitialize)this.f0002a4).EndInit();
			((ISupportInitialize)this.f0002a5).EndInit();
			((ISupportInitialize)this.f0002a6).EndInit();
			((ISupportInitialize)this.f0002a7).EndInit();
			((ISupportInitialize)this.m_nudRx1GainCodeSetLessNeg30).EndInit();
			base.ResumeLayout(false);
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		private TxGainTempLUTConfigParameters m_TxGainTempLUTConfigParameters;

		private TxGainTempLUTGetConfigParameters m_TxGainTempLUTGetConfigParameters;

		private RxGainTempLUTConfigParameters m_RxGainTempLUTConfigParameters;

		private RxGainTempLUTGetConfigParameters m_RxGainTempLUTGetConfigParameters;

		private IContainer components;

		private GroupBox groupBox1;

		private NumericUpDown m_nudTXGainTempSetProfileIndex;

		private NumericUpDown m_nudTx3GainCodeSetMoreThan140;

		private NumericUpDown f000264;

		private NumericUpDown f000265;

		private NumericUpDown f000266;

		private NumericUpDown f000267;

		private NumericUpDown f000268;

		private NumericUpDown f000269;

		private NumericUpDown f00026a;

		private NumericUpDown f00026b;

		private NumericUpDown f00026c;

		private NumericUpDown f00026d;

		private NumericUpDown f00026e;

		private NumericUpDown f00026f;

		private NumericUpDown f000270;

		private NumericUpDown f000271;

		private NumericUpDown f000272;

		private NumericUpDown f000273;

		private NumericUpDown f000274;

		private NumericUpDown m_nudTx3GainCodeSetLessNeg30;

		private NumericUpDown m_nudTx2GainCodeSetMoreThan140;

		private NumericUpDown f000275;

		private NumericUpDown f000276;

		private NumericUpDown f000277;

		private NumericUpDown f000278;

		private NumericUpDown f000279;

		private NumericUpDown f00027a;

		private NumericUpDown f00027b;

		private NumericUpDown f00027c;

		private NumericUpDown f00027d;

		private NumericUpDown f00027e;

		private NumericUpDown f00027f;

		private NumericUpDown f000280;

		private NumericUpDown f000281;

		private NumericUpDown f000282;

		private NumericUpDown f000283;

		private NumericUpDown f000284;

		private NumericUpDown f000285;

		private NumericUpDown m_nudTx2GainCodeSetLessNeg30;

		private NumericUpDown m_nudTx1GainCodeSetMoreThan140;

		private NumericUpDown f000286;

		private NumericUpDown f000287;

		private NumericUpDown f000288;

		private NumericUpDown f000289;

		private NumericUpDown f00028a;

		private NumericUpDown f00028b;

		private NumericUpDown f00028c;

		private NumericUpDown f00028d;

		private NumericUpDown f00028e;

		private NumericUpDown f00028f;

		private NumericUpDown f000290;

		private NumericUpDown f000291;

		private NumericUpDown f000292;

		private NumericUpDown f000293;

		private NumericUpDown f000294;

		private NumericUpDown f000295;

		private NumericUpDown f000296;

		private NumericUpDown m_nudTx1GainCodeSetLessNeg30;

		private Label label45;

		private Label label44;

		private Label label43;

		private Label label20;

		private Label label21;

		private Label label16;

		private Label label17;

		private Label label18;

		private Label label13;

		private Label label14;

		private Label label15;

		private Label label10;

		private Label label11;

		private Label label12;

		private Label label7;

		private Label label8;

		private Label label9;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label3;

		private Label label2;

		private Label label1;

		private GroupBox groupBox2;

		private NumericUpDown f000297;

		private NumericUpDown f000298;

		private NumericUpDown f000299;

		private NumericUpDown f00029a;

		private NumericUpDown f00029b;

		private NumericUpDown f00029c;

		private NumericUpDown f00029d;

		private NumericUpDown f00029e;

		private NumericUpDown f00029f;

		private NumericUpDown f0002a0;

		private NumericUpDown f0002a1;

		private NumericUpDown f0002a2;

		private NumericUpDown f0002a3;

		private NumericUpDown f0002a4;

		private NumericUpDown f0002a5;

		private NumericUpDown f0002a6;

		private NumericUpDown f0002a7;

		private NumericUpDown m_nudRx1GainCodeSetLessNeg30;

		private Label label22;

		private Label label23;

		private Label label25;

		private Label label26;

		private Label label27;

		private Label label28;

		private Label label29;

		private Label label30;

		private Label label31;

		private Label label32;

		private Label label33;

		private Label label34;

		private Label label35;

		private Label label36;

		private Label label37;

		private Label label38;

		private Label label39;

		private Label label40;

		private Label label41;

		private Label label42;

		private Button m_btnTxGainTempLUTConfigGet;

		private Button m_btnTxGainTempLUTConfigSet;

		private NumericUpDown m_nudRXGainTempSetProfileIndex;

		private Label label19;

		private NumericUpDown m_nudRx1GainCodeSetMoreThan140;

		private Button m_btnRxGainTempLUTConfigSet;

		private Button m_btnRxGainTempLUTConfigGet;
	}
}
