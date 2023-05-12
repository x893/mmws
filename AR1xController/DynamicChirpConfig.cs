using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public class DynamicChirpConfig : UserControl
	{
		public DynamicChirpConfig()
		{
			this.InitializeComponent();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_DynamicChirpConfigParams = this.m_GuiManager.TsParams.DynamicChirpConfigParams;
			this.m_DynamicChirpEnableConfigParams = this.m_GuiManager.TsParams.DynamicChirpEnableConfigParams;
			this.m_DynamicPerChirpPhaseShiftConfigParams = this.m_GuiManager.TsParams.DynamicPerChirpPhaseShiftConfigParams;
			this.Row1(true, 0);
			this.Row2(true, 0);
			this.Row3(true, 0);
		}

		private int iSetDynamicChirpConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iDynamicChirpConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetDynamicChirpConfig()
		{
			this.iSetDynamicChirpConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetDynamicChirpConfigAsync()
		{
			new del_v_v(this.iSetDynamicChirpConfig).BeginInvoke(null, null);
		}

		private void m_btnDynamicChirpConfigSet_Click(object sender, EventArgs p1)
		{
			this.iSetDynamicChirpConfigAsync();
		}

		private void UpdateAllRows()
		{
			this.m_DynamicChirpConfigParams.Chirp1R1ProfileIndex = (byte)this.m_nudChirp1ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp1R1FreqSlopeVar = (float)this.m_nudChirp1FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp1R1Tx1Enable = (byte)(this.m_ChbChirp1Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp1R1Tx2Enable = (byte)(this.m_ChbChirp1Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp1R1Tx3Enable = (byte)(this.m_ChbChirp1Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp1R1BPMConstVal = (byte)this.m_nudChirp1BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp1R2FreqStartVar = (double)this.m_nudChirp1FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp1R3IdleTimeVar = (float)this.m_nudChirp1IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp1R3ADCStartTimeVar = (float)this.m_nudChirp1ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp2R1ProfileIndex = (byte)this.m_nudChirp2ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp2R1FreqSlopeVar = (float)this.m_nudChirp2FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp2R1Tx1Enable = (byte)(this.m_ChbChirp2Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp2R1Tx2Enable = (byte)(this.m_ChbChirp2Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp2R1Tx3Enable = (byte)(this.m_ChbChirp2Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp2R1BPMConstVal = (byte)this.m_nudChirp2BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp2R2FreqStartVar = (double)this.m_nudChirp2FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp2R3IdleTimeVar = (float)this.m_nudChirp2IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp2R3ADCStartTimeVar = (float)this.m_nudChirp2ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp3R1ProfileIndex = (byte)this.m_nudChirp3ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp3R1FreqSlopeVar = (float)this.m_nudChirp3FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp3R1Tx1Enable = (byte)(this.m_ChbChirp3Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp3R1Tx2Enable = (byte)(this.m_ChbChirp3Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp3R1Tx3Enable = (byte)(this.m_ChbChirp3Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp3R1BPMConstVal = (byte)this.m_nudChirp3BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp3R2FreqStartVar = (double)this.m_nudChirp3FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp3R3IdleTimeVar = (float)this.m_nudChirp3IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp3R3ADCStartTimeVar = (float)this.m_nudChirp3ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp4R1ProfileIndex = (byte)this.m_nudChirp4ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp4R1FreqSlopeVar = (float)this.m_nudChirp4FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp4R1Tx1Enable = (byte)(this.m_ChbChirp4Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp4R1Tx2Enable = (byte)(this.m_ChbChirp4Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp4R1Tx3Enable = (byte)(this.m_ChbChirp4Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp4R1BPMConstVal = (byte)this.m_nudChirp4BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp4R2FreqStartVar = (double)this.m_nudChirp4FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp4R3IdleTimeVar = (float)this.m_nudChirp4IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp4R3ADCStartTimeVar = (float)this.m_nudChirp4ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp5R1ProfileIndex = (byte)this.m_nudChirp5ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp5R1FreqSlopeVar = (float)this.m_nudChirp5FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp5R1Tx1Enable = (byte)(this.m_ChbChirp5Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp5R1Tx2Enable = (byte)(this.m_ChbChirp5Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp5R1Tx3Enable = (byte)(this.m_ChbChirp5Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp5R1BPMConstVal = (byte)this.m_nudChirp5BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp5R2FreqStartVar = (double)this.m_nudChirp5FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp5R3IdleTimeVar = (float)this.m_nudChirp5IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp5R3ADCStartTimeVar = (float)this.m_nudChirp5ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp6R1ProfileIndex = (byte)this.m_nudChirp6ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp6R1FreqSlopeVar = (float)this.m_nudChirp6FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp6R1Tx1Enable = (byte)(this.m_ChbChirp6Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp6R1Tx2Enable = (byte)(this.m_ChbChirp6Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp6R1Tx3Enable = (byte)(this.m_ChbChirp6Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp6R1BPMConstVal = (byte)this.m_nudChirp6BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp6R2FreqStartVar = (double)this.m_nudChirp6FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp6R3IdleTimeVar = (float)this.m_nudChirp6IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp6R3ADCStartTimeVar = (float)this.m_nudChirp6ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp7R1ProfileIndex = (byte)this.m_nudChirp7ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp7R1FreqSlopeVar = (float)this.m_nudChirp7FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp7R1Tx1Enable = (byte)(this.m_ChbChirp7Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp7R1Tx2Enable = (byte)(this.m_ChbChirp7Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp7R1Tx3Enable = (byte)(this.m_ChbChirp7Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp7R1BPMConstVal = (byte)this.m_nudChirp7BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp7R2FreqStartVar = (double)this.m_nudChirp7FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp7R3IdleTimeVar = (float)this.m_nudChirp7IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp7R3ADCStartTimeVar = (float)this.m_nudChirp7ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp8R1ProfileIndex = (byte)this.m_nudChirp8ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp8R1FreqSlopeVar = (float)this.m_nudChirp8FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp8R1Tx1Enable = (byte)(this.m_ChbChirp8Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp8R1Tx2Enable = (byte)(this.m_ChbChirp8Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp8R1Tx3Enable = (byte)(this.m_ChbChirp8Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp8R1BPMConstVal = (byte)this.m_nudChirp8BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp8R2FreqStartVar = (double)this.m_nudChirp8FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp8R3IdleTimeVar = (float)this.m_nudChirp8IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp8R3ADCStartTimeVar = (float)this.m_nudChirp8ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp9R1ProfileIndex = (byte)this.m_nudChirp9ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp9R1FreqSlopeVar = (float)this.m_nudChirp9FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp9R1Tx1Enable = (byte)(this.m_ChbChirp9Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp9R1Tx2Enable = (byte)(this.m_ChbChirp9Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp9R1Tx3Enable = (byte)(this.m_ChbChirp9Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp9R1BPMConstVal = (byte)this.m_nudChirp9BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp9R2FreqStartVar = (double)this.m_nudChirp9FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp9R3IdleTimeVar = (float)this.m_nudChirp9IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp9R3ADCStartTimeVar = (float)this.m_nudChirp9ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp10R1ProfileIndex = (byte)this.m_nudChirp10ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp10R1FreqSlopeVar = (float)this.m_nudChirp10FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp10R1Tx1Enable = (byte)(this.m_ChbChirp10Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp10R1Tx2Enable = (byte)(this.m_ChbChirp10Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp10R1Tx3Enable = (byte)(this.m_ChbChirp10Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp10R1BPMConstVal = (byte)this.m_nudChirp10BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp10R2FreqStartVar = (double)this.m_nudChirp10FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp10R3IdleTimeVar = (float)this.m_nudChirp10IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp10R3ADCStartTimeVar = (float)this.m_nudChirp10ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp11R1ProfileIndex = (byte)this.m_nudChirp11ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp11R1FreqSlopeVar = (float)this.m_nudChirp11FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp11R1Tx1Enable = (byte)(this.m_ChbChirp11Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp11R1Tx2Enable = (byte)(this.m_ChbChirp11Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp11R1Tx3Enable = (byte)(this.m_ChbChirp11Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp11R1BPMConstVal = (byte)this.m_nudChirp11BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp11R2FreqStartVar = (double)this.m_nudChirp11FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp11R3IdleTimeVar = (float)this.m_nudChirp11IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp11R3ADCStartTimeVar = (float)this.m_nudChirp11ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp12R1ProfileIndex = (byte)this.m_nudChirp12ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp12R1FreqSlopeVar = (float)this.m_nudChirp12FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp12R1Tx1Enable = (byte)(this.m_ChbChirp12Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp12R1Tx2Enable = (byte)(this.m_ChbChirp12Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp12R1Tx3Enable = (byte)(this.m_ChbChirp12Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp12R1BPMConstVal = (byte)this.m_nudChirp12BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp12R2FreqStartVar = (double)this.m_nudChirp12FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp12R3IdleTimeVar = (float)this.m_nudChirp12IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp12R3ADCStartTimeVar = (float)this.m_nudChirp12ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp13R1ProfileIndex = (byte)this.m_nudChirp13ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp13R1FreqSlopeVar = (float)this.m_nudChirp13FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp13R1Tx1Enable = (byte)(this.m_ChbChirp13Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp13R1Tx2Enable = (byte)(this.m_ChbChirp13Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp13R1Tx3Enable = (byte)(this.m_ChbChirp13Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp13R1BPMConstVal = (byte)this.m_nudChirp13BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp13R2FreqStartVar = (double)this.m_nudChirp13FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp13R3IdleTimeVar = (float)this.m_nudChirp13IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp13R3ADCStartTimeVar = (float)this.m_nudChirp13ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp14R1ProfileIndex = (byte)this.m_nudChirp14ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp14R1FreqSlopeVar = (float)this.m_nudChirp14FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp14R1Tx1Enable = (byte)(this.m_ChbChirp14Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp14R1Tx2Enable = (byte)(this.m_ChbChirp14Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp14R1Tx3Enable = (byte)(this.m_ChbChirp14Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp14R1BPMConstVal = (byte)this.m_nudChirp14BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp14R2FreqStartVar = (double)this.m_nudChirp14FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp14R3IdleTimeVar = (float)this.m_nudChirp14IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp14R3ADCStartTimeVar = (float)this.m_nudChirp14ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp15R1ProfileIndex = (byte)this.m_nudChirp15ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp15R1FreqSlopeVar = (float)this.m_nudChirp15FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp15R1Tx1Enable = (byte)(this.m_ChbChirp15Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp15R1Tx2Enable = (byte)(this.m_ChbChirp15Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp15R1Tx3Enable = (byte)(this.m_ChbChirp15Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp15R1BPMConstVal = (byte)this.m_nudChirp15BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp15R2FreqStartVar = (double)this.m_nudChirp15FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp15R3IdleTimeVar = (float)this.m_nudChirp15IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp15R3ADCStartTimeVar = (float)this.m_nudChirp15ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp16R1ProfileIndex = (byte)this.m_nudChirp16ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp16R1FreqSlopeVar = (float)this.m_nudChirp16FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp16R1Tx1Enable = (byte)(this.m_ChbChirp16Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp16R1Tx2Enable = (byte)(this.m_ChbChirp16Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp16R1Tx3Enable = (byte)(this.m_ChbChirp16Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp16R1BPMConstVal = (byte)this.m_nudChirp16BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp16R2FreqStartVar = (double)this.m_nudChirp16FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp16R3IdleTimeVar = (float)this.m_nudChirp16IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp16R3ADCStartTimeVar = (float)this.m_nudChirp16ADCStartTimeVar.Value;
		}

		private void UpdateRow1()
		{
			this.m_DynamicChirpConfigParams.Chirp1R1ProfileIndex = (byte)this.m_nudChirp1ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp1R1FreqSlopeVar = (float)this.m_nudChirp1FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp1R1Tx1Enable = (byte)(this.m_ChbChirp1Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp1R1Tx2Enable = (byte)(this.m_ChbChirp1Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp1R1Tx3Enable = (byte)(this.m_ChbChirp1Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp1R1BPMConstVal = (byte)this.m_nudChirp1BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp2R1ProfileIndex = (byte)this.m_nudChirp2ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp2R1FreqSlopeVar = (float)this.m_nudChirp2FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp2R1Tx1Enable = (byte)(this.m_ChbChirp2Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp2R1Tx2Enable = (byte)(this.m_ChbChirp2Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp2R1Tx3Enable = (byte)(this.m_ChbChirp2Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp2R1BPMConstVal = (byte)this.m_nudChirp2BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp3R1ProfileIndex = (byte)this.m_nudChirp3ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp3R1FreqSlopeVar = (float)this.m_nudChirp3FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp3R1Tx1Enable = (byte)(this.m_ChbChirp3Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp3R1Tx2Enable = (byte)(this.m_ChbChirp3Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp3R1Tx3Enable = (byte)(this.m_ChbChirp3Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp3R1BPMConstVal = (byte)this.m_nudChirp3BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp4R1ProfileIndex = (byte)this.m_nudChirp4ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp4R1FreqSlopeVar = (float)this.m_nudChirp4FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp4R1Tx1Enable = (byte)(this.m_ChbChirp4Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp4R1Tx2Enable = (byte)(this.m_ChbChirp4Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp4R1Tx3Enable = (byte)(this.m_ChbChirp4Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp4R1BPMConstVal = (byte)this.m_nudChirp4BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp5R1ProfileIndex = (byte)this.m_nudChirp5ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp5R1FreqSlopeVar = (float)this.m_nudChirp5FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp5R1Tx1Enable = (byte)(this.m_ChbChirp5Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp5R1Tx2Enable = (byte)(this.m_ChbChirp5Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp5R1Tx3Enable = (byte)(this.m_ChbChirp5Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp5R1BPMConstVal = (byte)this.m_nudChirp5BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp6R1ProfileIndex = (byte)this.m_nudChirp6ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp6R1FreqSlopeVar = (float)this.m_nudChirp6FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp6R1Tx1Enable = (byte)(this.m_ChbChirp6Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp6R1Tx2Enable = (byte)(this.m_ChbChirp6Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp6R1Tx3Enable = (byte)(this.m_ChbChirp6Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp6R1BPMConstVal = (byte)this.m_nudChirp6BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp7R1ProfileIndex = (byte)this.m_nudChirp7ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp7R1FreqSlopeVar = (float)this.m_nudChirp7FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp7R1Tx1Enable = (byte)(this.m_ChbChirp7Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp7R1Tx2Enable = (byte)(this.m_ChbChirp7Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp7R1Tx3Enable = (byte)(this.m_ChbChirp7Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp7R1BPMConstVal = (byte)this.m_nudChirp7BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp8R1ProfileIndex = (byte)this.m_nudChirp8ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp8R1FreqSlopeVar = (float)this.m_nudChirp8FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp8R1Tx1Enable = (byte)(this.m_ChbChirp8Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp8R1Tx2Enable = (byte)(this.m_ChbChirp8Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp8R1Tx3Enable = (byte)(this.m_ChbChirp8Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp8R1BPMConstVal = (byte)this.m_nudChirp8BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp9R1ProfileIndex = (byte)this.m_nudChirp9ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp9R1FreqSlopeVar = (float)this.m_nudChirp9FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp9R1Tx1Enable = (byte)(this.m_ChbChirp9Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp9R1Tx2Enable = (byte)(this.m_ChbChirp9Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp9R1Tx3Enable = (byte)(this.m_ChbChirp9Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp9R1BPMConstVal = (byte)this.m_nudChirp9BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp10R1ProfileIndex = (byte)this.m_nudChirp10ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp10R1FreqSlopeVar = (float)this.m_nudChirp10FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp10R1Tx1Enable = (byte)(this.m_ChbChirp10Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp10R1Tx2Enable = (byte)(this.m_ChbChirp10Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp10R1Tx3Enable = (byte)(this.m_ChbChirp10Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp10R1BPMConstVal = (byte)this.m_nudChirp10BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp11R1ProfileIndex = (byte)this.m_nudChirp11ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp11R1FreqSlopeVar = (float)this.m_nudChirp11FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp11R1Tx1Enable = (byte)(this.m_ChbChirp11Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp11R1Tx2Enable = (byte)(this.m_ChbChirp11Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp11R1Tx3Enable = (byte)(this.m_ChbChirp11Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp11R1BPMConstVal = (byte)this.m_nudChirp11BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp12R1ProfileIndex = (byte)this.m_nudChirp12ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp12R1FreqSlopeVar = (float)this.m_nudChirp12FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp12R1Tx1Enable = (byte)(this.m_ChbChirp12Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp12R1Tx2Enable = (byte)(this.m_ChbChirp12Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp12R1Tx3Enable = (byte)(this.m_ChbChirp12Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp12R1BPMConstVal = (byte)this.m_nudChirp12BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp13R1ProfileIndex = (byte)this.m_nudChirp13ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp13R1FreqSlopeVar = (float)this.m_nudChirp13FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp13R1Tx1Enable = (byte)(this.m_ChbChirp13Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp13R1Tx2Enable = (byte)(this.m_ChbChirp13Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp13R1Tx3Enable = (byte)(this.m_ChbChirp13Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp13R1BPMConstVal = (byte)this.m_nudChirp13BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp14R1ProfileIndex = (byte)this.m_nudChirp14ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp14R1FreqSlopeVar = (float)this.m_nudChirp14FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp14R1Tx1Enable = (byte)(this.m_ChbChirp14Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp14R1Tx2Enable = (byte)(this.m_ChbChirp14Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp14R1Tx3Enable = (byte)(this.m_ChbChirp14Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp14R1BPMConstVal = (byte)this.m_nudChirp14BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp15R1ProfileIndex = (byte)this.m_nudChirp15ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp15R1FreqSlopeVar = (float)this.m_nudChirp15FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp15R1Tx1Enable = (byte)(this.m_ChbChirp15Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp15R1Tx2Enable = (byte)(this.m_ChbChirp15Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp15R1Tx3Enable = (byte)(this.m_ChbChirp15Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp15R1BPMConstVal = (byte)this.m_nudChirp15BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp16R1ProfileIndex = (byte)this.m_nudChirp16ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp16R1FreqSlopeVar = (float)this.m_nudChirp16FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp16R1Tx1Enable = (byte)(this.m_ChbChirp16Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp16R1Tx2Enable = (byte)(this.m_ChbChirp16Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp16R1Tx3Enable = (byte)(this.m_ChbChirp16Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp16R1BPMConstVal = (byte)this.m_nudChirp16BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp17R1ProfileIndex = (byte)this.m_nudChirp17ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp17R1FreqSlopeVar = (float)this.m_nudChirp17FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp17R1Tx1Enable = (byte)(this.m_ChbChirp17Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp17R1Tx2Enable = (byte)(this.m_ChbChirp17Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp17R1Tx3Enable = (byte)(this.m_ChbChirp17Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp17R1BPMConstVal = (byte)this.m_nudChirp17BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp18R1ProfileIndex = (byte)this.m_nudChirp18ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp18R1FreqSlopeVar = (float)this.m_nudChirp18FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp18R1Tx1Enable = (byte)(this.m_ChbChirp18Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp18R1Tx2Enable = (byte)(this.m_ChbChirp18Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp18R1Tx3Enable = (byte)(this.m_ChbChirp18Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp18R1BPMConstVal = (byte)this.m_nudChirp18BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp19R1ProfileIndex = (byte)this.m_nudChirp19ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp19R1FreqSlopeVar = (float)this.m_nudChirp19FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp19R1Tx1Enable = (byte)(this.m_ChbChirp19Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp19R1Tx2Enable = (byte)(this.m_ChbChirp19Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp19R1Tx3Enable = (byte)(this.m_ChbChirp19Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp19R1BPMConstVal = (byte)this.m_nudChirp19BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp20R1ProfileIndex = (byte)this.m_nudChirp20ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp20R1FreqSlopeVar = (float)this.m_nudChirp20FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp20R1Tx1Enable = (byte)(this.m_ChbChirp20Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp20R1Tx2Enable = (byte)(this.m_ChbChirp20Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp20R1Tx3Enable = (byte)(this.m_ChbChirp20Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp20R1BPMConstVal = (byte)this.m_nudChirp20BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp21R1ProfileIndex = (byte)this.m_nudChirp21ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp21R1FreqSlopeVar = (float)this.m_nudChirp21FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp21R1Tx1Enable = (byte)(this.m_ChbChirp21Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp21R1Tx2Enable = (byte)(this.m_ChbChirp21Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp21R1Tx3Enable = (byte)(this.m_ChbChirp21Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp21R1BPMConstVal = (byte)this.m_nudChirp21BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp22R1ProfileIndex = (byte)this.m_nudChirp22ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp22R1FreqSlopeVar = (float)this.m_nudChirp22FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp22R1Tx1Enable = (byte)(this.m_ChbChirp22Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp22R1Tx2Enable = (byte)(this.m_ChbChirp22Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp22R1Tx3Enable = (byte)(this.m_ChbChirp22Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp22R1BPMConstVal = (byte)this.m_nudChirp22BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp23R1ProfileIndex = (byte)this.m_nudChirp23ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp23R1FreqSlopeVar = (float)this.m_nudChirp23FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp23R1Tx1Enable = (byte)(this.m_ChbChirp23Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp23R1Tx2Enable = (byte)(this.m_ChbChirp23Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp23R1Tx3Enable = (byte)(this.m_ChbChirp23Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp23R1BPMConstVal = (byte)this.m_nudChirp23BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp24R1ProfileIndex = (byte)this.m_nudChirp24ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp24R1FreqSlopeVar = (float)this.m_nudChirp24FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp24R1Tx1Enable = (byte)(this.m_ChbChirp24Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp24R1Tx2Enable = (byte)(this.m_ChbChirp24Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp24R1Tx3Enable = (byte)(this.m_ChbChirp24Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp24R1BPMConstVal = (byte)this.m_nudChirp24BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp25R1ProfileIndex = (byte)this.m_nudChirp25ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp25R1FreqSlopeVar = (float)this.m_nudChirp25FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp25R1Tx1Enable = (byte)(this.m_ChbChirp25Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp25R1Tx2Enable = (byte)(this.m_ChbChirp25Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp25R1Tx3Enable = (byte)(this.m_ChbChirp25Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp25R1BPMConstVal = (byte)this.m_nudChirp25BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp26R1ProfileIndex = (byte)this.m_nudChirp26ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp26R1FreqSlopeVar = (float)this.m_nudChirp26FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp26R1Tx1Enable = (byte)(this.m_ChbChirp26Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp26R1Tx2Enable = (byte)(this.m_ChbChirp26Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp26R1Tx3Enable = (byte)(this.m_ChbChirp26Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp26R1BPMConstVal = (byte)this.m_nudChirp26BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp27R1ProfileIndex = (byte)this.m_nudChirp27ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp27R1FreqSlopeVar = (float)this.m_nudChirp27FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp27R1Tx1Enable = (byte)(this.m_ChbChirp27Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp27R1Tx2Enable = (byte)(this.m_ChbChirp27Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp27R1Tx3Enable = (byte)(this.m_ChbChirp27Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp27R1BPMConstVal = (byte)this.m_nudChirp27BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp28R1ProfileIndex = (byte)this.m_nudChirp28ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp28R1FreqSlopeVar = (float)this.m_nudChirp28FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp28R1Tx1Enable = (byte)(this.m_ChbChirp28Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp28R1Tx2Enable = (byte)(this.m_ChbChirp28Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp28R1Tx3Enable = (byte)(this.m_ChbChirp28Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp28R1BPMConstVal = (byte)this.m_nudChirp28BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp29R1ProfileIndex = (byte)this.m_nudChirp29ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp29R1FreqSlopeVar = (float)this.m_nudChirp29FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp29R1Tx1Enable = (byte)(this.m_ChbChirp29Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp29R1Tx2Enable = (byte)(this.m_ChbChirp29Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp29R1Tx3Enable = (byte)(this.m_ChbChirp29Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp29R1BPMConstVal = (byte)this.m_nudChirp29BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp30R1ProfileIndex = (byte)this.m_nudChirp30ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp30R1FreqSlopeVar = (float)this.m_nudChirp30FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp30R1Tx1Enable = (byte)(this.m_ChbChirp30Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp30R1Tx2Enable = (byte)(this.m_ChbChirp30Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp30R1Tx3Enable = (byte)(this.m_ChbChirp30Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp30R1BPMConstVal = (byte)this.m_nudChirp30BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp31R1ProfileIndex = (byte)this.m_nudChirp31ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp31R1FreqSlopeVar = (float)this.m_nudChirp31FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp31R1Tx1Enable = (byte)(this.m_ChbChirp31Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp31R1Tx2Enable = (byte)(this.m_ChbChirp31Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp31R1Tx3Enable = (byte)(this.m_ChbChirp31Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp31R1BPMConstVal = (byte)this.m_nudChirp31BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp32R1ProfileIndex = (byte)this.m_nudChirp32ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp32R1FreqSlopeVar = (float)this.m_nudChirp32FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp32R1Tx1Enable = (byte)(this.m_ChbChirp32Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp32R1Tx2Enable = (byte)(this.m_ChbChirp32Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp32R1Tx3Enable = (byte)(this.m_ChbChirp32Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp32R1BPMConstVal = (byte)this.m_nudChirp32BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp33R1ProfileIndex = (byte)this.m_nudChirp33ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp33R1FreqSlopeVar = (float)this.m_nudChirp33FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp33R1Tx1Enable = (byte)(this.m_ChbChirp33Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp33R1Tx2Enable = (byte)(this.m_ChbChirp33Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp33R1Tx3Enable = (byte)(this.m_ChbChirp33Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp33R1BPMConstVal = (byte)this.m_nudChirp33BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp34R1ProfileIndex = (byte)this.m_nudChirp34ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp34R1FreqSlopeVar = (float)this.m_nudChirp34FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp34R1Tx1Enable = (byte)(this.m_ChbChirp34Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp34R1Tx2Enable = (byte)(this.m_ChbChirp34Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp34R1Tx3Enable = (byte)(this.m_ChbChirp34Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp34R1BPMConstVal = (byte)this.m_nudChirp34BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp35R1ProfileIndex = (byte)this.m_nudChirp35ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp35R1FreqSlopeVar = (float)this.m_nudChirp35FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp35R1Tx1Enable = (byte)(this.m_ChbChirp35Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp35R1Tx2Enable = (byte)(this.m_ChbChirp35Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp35R1Tx3Enable = (byte)(this.m_ChbChirp35Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp35R1BPMConstVal = (byte)this.m_nudChirp35BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp36R1ProfileIndex = (byte)this.m_nudChirp36ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp36R1FreqSlopeVar = (float)this.m_nudChirp36FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp36R1Tx1Enable = (byte)(this.m_ChbChirp36Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp36R1Tx2Enable = (byte)(this.m_ChbChirp36Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp36R1Tx3Enable = (byte)(this.m_ChbChirp36Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp36R1BPMConstVal = (byte)this.m_nudChirp36BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp37R1ProfileIndex = (byte)this.m_nudChirp37ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp37R1FreqSlopeVar = (float)this.m_nudChirp37FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp37R1Tx1Enable = (byte)(this.m_ChbChirp37Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp37R1Tx2Enable = (byte)(this.m_ChbChirp37Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp37R1Tx3Enable = (byte)(this.m_ChbChirp37Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp37R1BPMConstVal = (byte)this.m_nudChirp37BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp38R1ProfileIndex = (byte)this.m_nudChirp38ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp38R1FreqSlopeVar = (float)this.m_nudChirp38FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp38R1Tx1Enable = (byte)(this.m_ChbChirp38Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp38R1Tx2Enable = (byte)(this.m_ChbChirp38Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp38R1Tx3Enable = (byte)(this.m_ChbChirp38Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp38R1BPMConstVal = (byte)this.m_nudChirp38BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp39R1ProfileIndex = (byte)this.m_nudChirp39ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp39R1FreqSlopeVar = (float)this.m_nudChirp39FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp39R1Tx1Enable = (byte)(this.m_ChbChirp39Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp39R1Tx2Enable = (byte)(this.m_ChbChirp39Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp39R1Tx3Enable = (byte)(this.m_ChbChirp39Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp39R1BPMConstVal = (byte)this.m_nudChirp39BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp40R1ProfileIndex = (byte)this.m_nudChirp40ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp40R1FreqSlopeVar = (float)this.m_nudChirp40FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp40R1Tx1Enable = (byte)(this.m_ChbChirp40Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp40R1Tx2Enable = (byte)(this.m_ChbChirp40Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp40R1Tx3Enable = (byte)(this.m_ChbChirp40Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp40R1BPMConstVal = (byte)this.m_nudChirp40BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp41R1ProfileIndex = (byte)this.m_nudChirp41ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp41R1FreqSlopeVar = (float)this.m_nudChirp41FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp41R1Tx1Enable = (byte)(this.m_ChbChirp41Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp41R1Tx2Enable = (byte)(this.m_ChbChirp41Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp41R1Tx3Enable = (byte)(this.m_ChbChirp41Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp41R1BPMConstVal = (byte)this.m_nudChirp41BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp42R1ProfileIndex = (byte)this.m_nudChirp42ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp42R1FreqSlopeVar = (float)this.m_nudChirp42FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp42R1Tx1Enable = (byte)(this.m_ChbChirp42Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp42R1Tx2Enable = (byte)(this.m_ChbChirp42Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp42R1Tx3Enable = (byte)(this.m_ChbChirp42Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp42R1BPMConstVal = (byte)this.m_nudChirp42BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp43R1ProfileIndex = (byte)this.m_nudChirp43ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp43R1FreqSlopeVar = (float)this.m_nudChirp43FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp43R1Tx1Enable = (byte)(this.m_ChbChirp43Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp43R1Tx2Enable = (byte)(this.m_ChbChirp43Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp43R1Tx3Enable = (byte)(this.m_ChbChirp43Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp43R1BPMConstVal = (byte)this.m_nudChirp43BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp44R1ProfileIndex = (byte)this.m_nudChirp44ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp44R1FreqSlopeVar = (float)this.m_nudChirp44FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp44R1Tx1Enable = (byte)(this.m_ChbChirp44Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp44R1Tx2Enable = (byte)(this.m_ChbChirp44Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp44R1Tx3Enable = (byte)(this.m_ChbChirp44Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp44R1BPMConstVal = (byte)this.m_nudChirp44BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp45R1ProfileIndex = (byte)this.m_nudChirp45ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp45R1FreqSlopeVar = (float)this.m_nudChirp45FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp45R1Tx1Enable = (byte)(this.m_ChbChirp45Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp45R1Tx2Enable = (byte)(this.m_ChbChirp45Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp45R1Tx3Enable = (byte)(this.m_ChbChirp45Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp45R1BPMConstVal = (byte)this.m_nudChirp45BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp46R1ProfileIndex = (byte)this.m_nudChirp46ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp46R1FreqSlopeVar = (float)this.m_nudChirp46FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp46R1Tx1Enable = (byte)(this.m_ChbChirp46Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp46R1Tx2Enable = (byte)(this.m_ChbChirp46Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp46R1Tx3Enable = (byte)(this.m_ChbChirp46Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp46R1BPMConstVal = (byte)this.m_nudChirp46BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp47R1ProfileIndex = (byte)this.m_nudChirp47ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp47R1FreqSlopeVar = (float)this.m_nudChirp47FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp47R1Tx1Enable = (byte)(this.m_ChbChirp47Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp47R1Tx2Enable = (byte)(this.m_ChbChirp47Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp47R1Tx3Enable = (byte)(this.m_ChbChirp47Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp47R1BPMConstVal = (byte)this.m_nudChirp47BPMConstVal.Value;
			this.m_DynamicChirpConfigParams.Chirp48R1ProfileIndex = (byte)this.m_nudChirp48ProfileIndex.Value;
			this.m_DynamicChirpConfigParams.Chirp48R1FreqSlopeVar = (float)this.m_nudChirp48FreqSlopeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp48R1Tx1Enable = (byte)(this.m_ChbChirp48Tx1Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp48R1Tx2Enable = (byte)(this.m_ChbChirp48Tx2Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp48R1Tx3Enable = (byte)(this.m_ChbChirp48Tx3Enable.Checked ? 1 : 0);
			this.m_DynamicChirpConfigParams.Chirp48R1BPMConstVal = (byte)this.m_nudChirp48BPMConstVal.Value;
		}

		private void UpdateRow2()
		{
			this.m_DynamicChirpConfigParams.Chirp1R2FreqStartVar = (double)this.m_nudChirp1FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp2R2FreqStartVar = (double)this.m_nudChirp2FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp3R2FreqStartVar = (double)this.m_nudChirp3FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp4R2FreqStartVar = (double)this.m_nudChirp4FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp5R2FreqStartVar = (double)this.m_nudChirp5FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp6R2FreqStartVar = (double)this.m_nudChirp6FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp7R2FreqStartVar = (double)this.m_nudChirp7FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp8R2FreqStartVar = (double)this.m_nudChirp8FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp9R2FreqStartVar = (double)this.m_nudChirp9FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp10R2FreqStartVar = (double)this.m_nudChirp10FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp11R2FreqStartVar = (double)this.m_nudChirp11FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp12R2FreqStartVar = (double)this.m_nudChirp12FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp13R2FreqStartVar = (double)this.m_nudChirp13FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp14R2FreqStartVar = (double)this.m_nudChirp14FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp15R2FreqStartVar = (double)this.m_nudChirp15FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp16R2FreqStartVar = (double)this.m_nudChirp16FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp17R2FreqStartVar = (double)this.m_nudChirp17FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp18R2FreqStartVar = (double)this.m_nudChirp18FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp19R2FreqStartVar = (double)this.m_nudChirp19FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp20R2FreqStartVar = (double)this.m_nudChirp20FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp21R2FreqStartVar = (double)this.m_nudChirp21FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp22R2FreqStartVar = (double)this.m_nudChirp22FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp23R2FreqStartVar = (double)this.m_nudChirp23FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp24R2FreqStartVar = (double)this.m_nudChirp24FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp25R2FreqStartVar = (double)this.m_nudChirp25FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp26R2FreqStartVar = (double)this.m_nudChirp26FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp27R2FreqStartVar = (double)this.m_nudChirp27FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp28R2FreqStartVar = (double)this.m_nudChirp28FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp29R2FreqStartVar = (double)this.m_nudChirp29FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp30R2FreqStartVar = (double)this.m_nudChirp30FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp31R2FreqStartVar = (double)this.m_nudChirp31FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp32R2FreqStartVar = (double)this.m_nudChirp32FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp33R2FreqStartVar = (double)this.m_nudChirp33FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp34R2FreqStartVar = (double)this.m_nudChirp34FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp35R2FreqStartVar = (double)this.m_nudChirp35FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp36R2FreqStartVar = (double)this.m_nudChirp36FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp37R2FreqStartVar = (double)this.m_nudChirp37FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp38R2FreqStartVar = (double)this.m_nudChirp38FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp39R2FreqStartVar = (double)this.m_nudChirp39FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp40R2FreqStartVar = (double)this.m_nudChirp40FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp41R2FreqStartVar = (double)this.m_nudChirp41FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp42R2FreqStartVar = (double)this.m_nudChirp42FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp43R2FreqStartVar = (double)this.m_nudChirp43FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp44R2FreqStartVar = (double)this.m_nudChirp44FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp45R2FreqStartVar = (double)this.m_nudChirp45FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp46R2FreqStartVar = (double)this.m_nudChirp46FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp47R2FreqStartVar = (double)this.m_nudChirp47FreqStartVar.Value;
			this.m_DynamicChirpConfigParams.Chirp48R2FreqStartVar = (double)this.m_nudChirp48FreqStartVar.Value;
		}

		private void UpdateRow3()
		{
			this.m_DynamicChirpConfigParams.Chirp1R3IdleTimeVar = (float)this.m_nudChirp1IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp1R3ADCStartTimeVar = (float)this.m_nudChirp1ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp2R3IdleTimeVar = (float)this.m_nudChirp2IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp2R3ADCStartTimeVar = (float)this.m_nudChirp2ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp3R3IdleTimeVar = (float)this.m_nudChirp3IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp3R3ADCStartTimeVar = (float)this.m_nudChirp3ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp4R3IdleTimeVar = (float)this.m_nudChirp4IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp4R3ADCStartTimeVar = (float)this.m_nudChirp4ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp5R3IdleTimeVar = (float)this.m_nudChirp5IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp5R3ADCStartTimeVar = (float)this.m_nudChirp5ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp6R3IdleTimeVar = (float)this.m_nudChirp6IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp6R3ADCStartTimeVar = (float)this.m_nudChirp6ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp7R3IdleTimeVar = (float)this.m_nudChirp7IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp7R3ADCStartTimeVar = (float)this.m_nudChirp7ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp8R3IdleTimeVar = (float)this.m_nudChirp8IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp8R3ADCStartTimeVar = (float)this.m_nudChirp8ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp9R3IdleTimeVar = (float)this.m_nudChirp9IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp9R3ADCStartTimeVar = (float)this.m_nudChirp9ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp10R3IdleTimeVar = (float)this.m_nudChirp10IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp10R3ADCStartTimeVar = (float)this.m_nudChirp10ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp11R3IdleTimeVar = (float)this.m_nudChirp11IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp11R3ADCStartTimeVar = (float)this.m_nudChirp11ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp12R3IdleTimeVar = (float)this.m_nudChirp12IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp12R3ADCStartTimeVar = (float)this.m_nudChirp12ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp13R3IdleTimeVar = (float)this.m_nudChirp13IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp13R3ADCStartTimeVar = (float)this.m_nudChirp13ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp14R3IdleTimeVar = (float)this.m_nudChirp14IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp14R3ADCStartTimeVar = (float)this.m_nudChirp14ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp15R3IdleTimeVar = (float)this.m_nudChirp15IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp15R3ADCStartTimeVar = (float)this.m_nudChirp15ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp16R3IdleTimeVar = (float)this.m_nudChirp16IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp16R3ADCStartTimeVar = (float)this.m_nudChirp16ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp17R3IdleTimeVar = (float)this.m_nudChirp17IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp17R3ADCStartTimeVar = (float)this.m_nudChirp17ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp18R3IdleTimeVar = (float)this.m_nudChirp18IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp18R3ADCStartTimeVar = (float)this.m_nudChirp18ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp19R3IdleTimeVar = (float)this.m_nudChirp19IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp19R3ADCStartTimeVar = (float)this.m_nudChirp19ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp20R3IdleTimeVar = (float)this.m_nudChirp20IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp20R3ADCStartTimeVar = (float)this.m_nudChirp20ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp21R3IdleTimeVar = (float)this.m_nudChirp21IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp21R3ADCStartTimeVar = (float)this.m_nudChirp21ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp22R3IdleTimeVar = (float)this.m_nudChirp22IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp22R3ADCStartTimeVar = (float)this.m_nudChirp22ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp23R3IdleTimeVar = (float)this.m_nudChirp23IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp23R3ADCStartTimeVar = (float)this.m_nudChirp23ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp24R3IdleTimeVar = (float)this.m_nudChirp24IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp24R3ADCStartTimeVar = (float)this.m_nudChirp24ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp25R3IdleTimeVar = (float)this.m_nudChirp25IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp25R3ADCStartTimeVar = (float)this.m_nudChirp25ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp26R3IdleTimeVar = (float)this.m_nudChirp26IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp26R3ADCStartTimeVar = (float)this.m_nudChirp26ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp27R3IdleTimeVar = (float)this.m_nudChirp27IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp27R3ADCStartTimeVar = (float)this.m_nudChirp27ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp28R3IdleTimeVar = (float)this.m_nudChirp28IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp28R3ADCStartTimeVar = (float)this.m_nudChirp28ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp29R3IdleTimeVar = (float)this.m_nudChirp29IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp29R3ADCStartTimeVar = (float)this.m_nudChirp29ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp30R3IdleTimeVar = (float)this.m_nudChirp30IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp30R3ADCStartTimeVar = (float)this.m_nudChirp30ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp31R3IdleTimeVar = (float)this.m_nudChirp31IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp31R3ADCStartTimeVar = (float)this.m_nudChirp31ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp32R3IdleTimeVar = (float)this.m_nudChirp32IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp32R3ADCStartTimeVar = (float)this.m_nudChirp32ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp33R3IdleTimeVar = (float)this.m_nudChirp33IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp33R3ADCStartTimeVar = (float)this.m_nudChirp33ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp34R3IdleTimeVar = (float)this.m_nudChirp34IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp34R3ADCStartTimeVar = (float)this.m_nudChirp34ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp35R3IdleTimeVar = (float)this.m_nudChirp35IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp35R3ADCStartTimeVar = (float)this.m_nudChirp35ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp36R3IdleTimeVar = (float)this.m_nudChirp36IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp36R3ADCStartTimeVar = (float)this.m_nudChirp36ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp37R3IdleTimeVar = (float)this.m_nudChirp37IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp37R3ADCStartTimeVar = (float)this.m_nudChirp37ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp38R3IdleTimeVar = (float)this.m_nudChirp38IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp38R3ADCStartTimeVar = (float)this.m_nudChirp38ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp39R3IdleTimeVar = (float)this.m_nudChirp39IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp39R3ADCStartTimeVar = (float)this.m_nudChirp39ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp40R3IdleTimeVar = (float)this.m_nudChirp40IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp40R3ADCStartTimeVar = (float)this.m_nudChirp40ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp41R3IdleTimeVar = (float)this.m_nudChirp41IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp41R3ADCStartTimeVar = (float)this.m_nudChirp41ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp42R3IdleTimeVar = (float)this.m_nudChirp42IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp42R3ADCStartTimeVar = (float)this.m_nudChirp42ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp43R3IdleTimeVar = (float)this.m_nudChirp43IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp43R3ADCStartTimeVar = (float)this.m_nudChirp43ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp44R3IdleTimeVar = (float)this.m_nudChirp44IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp44R3ADCStartTimeVar = (float)this.m_nudChirp44ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp45R3IdleTimeVar = (float)this.m_nudChirp45IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp45R3ADCStartTimeVar = (float)this.m_nudChirp45ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp46R3IdleTimeVar = (float)this.m_nudChirp46IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp46R3ADCStartTimeVar = (float)this.m_nudChirp46ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp47R3IdleTimeVar = (float)this.m_nudChirp47IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp47R3ADCStartTimeVar = (float)this.m_nudChirp47ADCStartTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp48R3IdleTimeVar = (float)this.m_nudChirp48IdleTimeVar.Value;
			this.m_DynamicChirpConfigParams.Chirp48R3ADCStartTimeVar = (float)this.m_nudChirp48ADCStartTimeVar.Value;
		}

		public bool UpdateDynamicChirpConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateDynamicChirpConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_DynamicChirpConfigParams.ChirpSegmentSelect = (byte)this.m_nudChirpSegmentSelect.Value;
				this.m_DynamicChirpConfigParams.ChirpRowSelect = (byte)this.m_nudChirpRowSelect.Value;
				this.m_DynamicChirpConfigParams.ProgramMode = (ushort)(this.m_ChbProgramModeEnable.Checked ? 1 : 0);
				switch (this.m_DynamicChirpConfigParams.ChirpRowSelect)
				{
				case 0:
					this.UpdateAllRows();
					break;
				case 1:
					this.UpdateRow1();
					break;
				case 2:
					this.UpdateRow2();
					break;
				case 3:
					this.UpdateRow3();
					break;
				default:
					this.UpdateAllRows();
					break;
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

		public bool UpdateDynamicPerChirpPhaseShiftGui(RootObject jobject, int p1, int chirpSegInd)
		{
			if (jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs.Count == 0)
			{
				string msg = string.Format("Missing Dynamic per Chirp Phase Shift Configuration for Device {0}. Skipping..", p1);
				GlobalRef.LuaWrapper.PrintWarning(msg);
			}
			else
			{
				this.m_nudPerChirpSegmentSelect.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.chirpSegSel;
				this.m_nudChirp1Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[0].rlChirpPhShiftPerTx_t.chirpTx0PhaseShifter;
				this.m_nudChirp1Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[0].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp1Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[0].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp2Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[1].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp2Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[1].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp2Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[1].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp3Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[2].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp3Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[2].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp3Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[2].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp4Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[3].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp4Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[3].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp4Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[3].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp5Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[4].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp5Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[4].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp5Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[4].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp6Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[5].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp6Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[5].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp6Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[5].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp7Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[6].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp7Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[6].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp7Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[6].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp8Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[7].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp8Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[7].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp8Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[7].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp9Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[8].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp9Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[8].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp9Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[8].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp10Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[9].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp10Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[9].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp10Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[9].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp11Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[10].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp11Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[10].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp11Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[10].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp12Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[11].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp12Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[11].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp12Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[11].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp13Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[12].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp13Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[12].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp13Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[12].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp14Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[13].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp14Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[13].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp14Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[13].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp15Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[14].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp15Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[14].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp15Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[14].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
				this.m_nudChirp16Tx1PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[15].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp16Tx2PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[15].rlChirpPhShiftPerTx_t.chirpTx1PhaseShifter;
				this.m_nudChirp16Tx3PhaseShiftter.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs[chirpSegInd].rlDynPerChirpPhShftCfg_t.rlChirpPhShiftPerTxs[15].rlChirpPhShiftPerTx_t.chirpTx2PhaseShifter;
			}
			return true;
		}

		public bool UpdateDynamicChirpData(RootObject jobject, int p1)
		{
			if (jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs != null)
			{
				this.UpdateDynamicChirpDataGui(jobject, p1, 0);
			}
			if (jobject.mmWaveDevices[p1].rfConfig.rlDynPerChirpPhShftCfgs != null && (GlobalRef.g_AR12xxDevice || GlobalRef.g_AR1843Device))
			{
				this.UpdateDynamicPerChirpPhaseShiftGui(jobject, p1, 0);
			}
			return true;
		}

		public bool UpdateDynamicChirpDataGui(RootObject jobject, int p1, int chirpSegInd)
		{
			if (jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs.Count == 0)
			{
				string msg = string.Format("Missing Dynamic Chirps Configuration for Device {0}. Skipping..", p1);
				GlobalRef.LuaWrapper.PrintWarning(msg);
			}
			else
			{
				this.m_nudChirpSegmentSelect.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.chirpSegSel;
				this.m_nudChirpRowSelect.Value = jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.chirpRowSel;
				this.m_ChbProgramModeEnable.Checked = (jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.programMode == 1);
				switch (jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.chirpRowSel)
				{
				case 0:
					this.UpdateAllRows_JSON(jobject, p1, chirpSegInd);
					break;
				case 1:
					this.UpdateRow1_JSON(jobject, p1, chirpSegInd);
					break;
				case 2:
					this.UpdateRow2_JSON(jobject, p1, chirpSegInd);
					break;
				case 3:
					this.UpdateRow3_JSON(jobject, p1, chirpSegInd);
					break;
				default:
					this.UpdateAllRows_JSON(jobject, p1, chirpSegInd);
					break;
				}
			}
			return true;
		}

		public void UpdateAllRows_JSON(RootObject jobject, int p1, int chirpSegInd)
		{
			this.m_nudChirp1ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp1FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp1Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp1Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp1Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp1BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp1FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp1IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp1ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp2ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp2FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp2Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp2Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp2Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp2BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp2FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp2IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp2ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp3ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp3FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp3Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp3Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp3Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp3BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp3FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp3IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp3ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp4ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp4FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp4Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp4Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp4Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp4BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp4FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp4IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp4ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp5ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp5FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp5Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp5Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp5Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp5BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp5FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp5IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp5ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp6ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp6FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp6Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp6Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp6Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp6BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp6FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp6IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp6ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp7ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp7FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp7Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp7Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp7Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp7BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp7FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp7IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp7ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp8ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp8FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp8Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp8Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp8Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp8BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp8FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp8IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp8ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp9ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp9FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp9Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp9Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp9Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp9BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp9FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp9IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp9ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp10ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp10FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp10Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp10Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp10Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp10BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp10FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp10IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp10ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp11ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp11FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp11Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp11Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp11Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp11BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp11FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp11IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp11ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp12ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp12FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp12Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp12Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp12Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp12BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp12FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp12IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp12ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp13ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp13FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp13Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp13Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp13Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp13BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp13FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp13IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp13ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp14ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp14FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp14Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp14Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp14Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp14BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp14FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp14IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp14ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp15ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp15FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp15Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp15Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp15Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp15BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp15FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp15IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp15ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp16ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp16FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp16Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp16Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp16Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp16BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp16FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp16IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp16ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
		}

		public void UpdateRow1_JSON(RootObject jobject, int p1, int chirpSegInd)
		{
			this.m_nudChirp1ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp1FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp1Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp1Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp1Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp1BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp2ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp2FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp2Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp2Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp2Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp2BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp3ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp3FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp3Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp3Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp3Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp3BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp4ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp4FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp4Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp4Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp4Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp4BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp5ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp5FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp5Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp5Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp5Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp5BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp6ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp6FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp6Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp6Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp6Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp6BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp7ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp7FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp7Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp7Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp7Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp7BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp8ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp8FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp8Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp8Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp8Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp8BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp9ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp9FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp9Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp9Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp9Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp9BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp10ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp10FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp10Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp10Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp10Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp10BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp11ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp11FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp11Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp11Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp11Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp11BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp12ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp12FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp12Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp12Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp12Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp12BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp13ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp13FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp13Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp13Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp13Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp13BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp14ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp14FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp14Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp14Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp14Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp14BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp15ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp15FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp15Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp15Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp15Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp15BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp16ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp16FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp16Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp16Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp16Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp16BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp17ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[16].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp17FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[16].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp17Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[16].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp17Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[16].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp17Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[16].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp17BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[16].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp18ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[17].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp18FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[17].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp18Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[17].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp18Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[17].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp18Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[17].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp18BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[17].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp19ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[18].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp19FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[18].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp19Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[18].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp19Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[18].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp19Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[18].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp19BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[18].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp20ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[19].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp20FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[19].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp20Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[19].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp20Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[19].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp20Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[19].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp20BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[19].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp21ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[20].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp21FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[20].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp21Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[20].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp21Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[20].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp21Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[20].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp21BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[20].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp22ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[21].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp22FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[21].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp22Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[21].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp22Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[21].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp22Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[21].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp22BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[21].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp23ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[22].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp23FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[22].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp23Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[22].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp23Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[22].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp23Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[22].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp23BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[22].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp24ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[23].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp24FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[23].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp24Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[23].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp24Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[23].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp24Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[23].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp24BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[23].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp25ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[24].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp25FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[24].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp25Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[24].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp25Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[24].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp25Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[24].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp25BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[24].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp26ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[25].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp26FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[25].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp26Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[25].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp26Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[25].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp26Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[25].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp26BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[25].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp27ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[26].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp27FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[26].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp27Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[26].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp27Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[26].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp27Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[26].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp27BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[26].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp28ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[27].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp28FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[27].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp28Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[27].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp28Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[27].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp28Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[27].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp28BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[27].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp29ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[28].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp29FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[28].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp29Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[28].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp29Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[28].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp29Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[28].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp29BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[28].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp30ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[29].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp30FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[29].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp30Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[29].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp30Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[29].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp30Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[29].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp30BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[29].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp31ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[30].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp31FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[30].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp31Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[30].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp31Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[30].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp31Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[30].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp31BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[30].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp32ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[31].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp32FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[31].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp32Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[31].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp32Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[31].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp32Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[31].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp32BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[31].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp33ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[32].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp33FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[32].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp33Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[32].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp33Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[32].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp33Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[32].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp33BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[32].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp34ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[33].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp34FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[33].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp34Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[33].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp34Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[33].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp34Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[33].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp34BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[33].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp35ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[34].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp35FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[34].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp35Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[34].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp35Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[34].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp35Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[34].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp35BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[34].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp36ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[35].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp36FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[35].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp36Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[35].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp36Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[35].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp36Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[35].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp36BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[35].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp37ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[36].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp37FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[36].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp37Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[36].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp37Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[36].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp37Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[36].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp37BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[36].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp38ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[37].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp38FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[37].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp38Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[37].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp38Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[37].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp38Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[37].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp38BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[37].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp39ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[38].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp39FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[38].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp39Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[38].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp39Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[38].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp39Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[38].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp39BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[38].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp40ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[39].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp40FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[39].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp40Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[39].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp40Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[39].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp40Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[39].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp40BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[39].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp41ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[40].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp41FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[40].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp41Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[40].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp41Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[40].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp41Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[40].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp41BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[40].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp42ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[41].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp42FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[41].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp42Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[41].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp42Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[41].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp42Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[41].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp42BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[41].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp43ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[42].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp43FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[42].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp43Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[42].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp43Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[42].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp43Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[42].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp43BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[42].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp44ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[43].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp44FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[43].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp44Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[43].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp44Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[43].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp44Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[43].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp44BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[43].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp45ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[44].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp45FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[44].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp45Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[44].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp45Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[44].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp45Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[44].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp45BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[44].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp46ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[45].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp46FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[45].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp46Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[45].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp46Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[45].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp46Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[45].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp46BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[45].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp47ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[46].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp47FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[46].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp47Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[46].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp47Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[46].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp47Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[46].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp47BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[46].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
			this.m_nudChirp48ProfileIndex.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[47].rlChirpRow_t.chirpNR1, 16) & 15);
			this.m_nudChirp48FreqSlopeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[47].rlChirpRow_t.chirpNR1, 16) & 16128) >> 8;
			this.m_ChbChirp48Tx1Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[47].rlChirpRow_t.chirpNR1, 16) & 65536) >> 16 == 1);
			this.m_ChbChirp48Tx2Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[47].rlChirpRow_t.chirpNR1, 16) & 131072) >> 17 == 1);
			this.m_ChbChirp48Tx3Enable.Checked = ((Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[47].rlChirpRow_t.chirpNR1, 16) & 262144) >> 18 == 1);
			this.m_nudChirp48BPMConstVal.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[47].rlChirpRow_t.chirpNR1, 16) & 1056964608) >> 24;
		}

		public void UpdateRow2_JSON(RootObject jobject, int p1, int chirpSegInd)
		{
			this.m_nudChirp1FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp2FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp3FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp4FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp5FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp6FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp7FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp8FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp9FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp10FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp11FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp12FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp13FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp14FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp15FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp16FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp17FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[16].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp18FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[17].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp19FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[18].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp20FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[19].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp21FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[20].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp22FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[21].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp23FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[22].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp24FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[23].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp25FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[24].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp26FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[25].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp27FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[26].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp28FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[27].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp29FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[28].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp30FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[29].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp31FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[30].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp32FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[31].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp33FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[32].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp34FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[33].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp35FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[34].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp36FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[35].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp37FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[36].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp38FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[37].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp39FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[38].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp40FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[39].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp41FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[40].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp42FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[41].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp43FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[42].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp44FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[43].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp45FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[44].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp46FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[45].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp47FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[46].rlChirpRow_t.chirpNR2, 16) & 8388607);
			this.m_nudChirp48FreqStartVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[47].rlChirpRow_t.chirpNR2, 16) & 8388607);
		}

		public void UpdateRow3_JSON(RootObject jobject, int p1, int chirpSegInd)
		{
			this.m_nudChirp1IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp1ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[0].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp2IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp2ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[1].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp3IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp3ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[2].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp4IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp4ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[3].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp5IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp5ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[4].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp6IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp6ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[5].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp7IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp7ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[6].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp8IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp8ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[7].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp9IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp9ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[8].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp10IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp10ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[9].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp11IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp11ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[10].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp12IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp12ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[11].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp13IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp13ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[12].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp14IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp14ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[13].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp15IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp15ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[14].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp16IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp16ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[15].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp17IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[16].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp17ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[16].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp18IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[17].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp18ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[17].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp19IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[18].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp19ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[18].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp20IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[19].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp20ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[19].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp21IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[20].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp21ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[20].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp22IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[21].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp22ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[21].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp23IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[22].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp23ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[22].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp24IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[23].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp24ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[23].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp25IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[24].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp25ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[24].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp26IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[25].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp26ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[25].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp27IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[26].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp27ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[26].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp28IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[27].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp28ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[27].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp29IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[28].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp29ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[28].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp30IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[29].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp30ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[29].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp31IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[30].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp31ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[30].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp32IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[31].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp32ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[31].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp33IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[32].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp33ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[32].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp34IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[33].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp34ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[33].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp35IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[34].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp35ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[34].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp36IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[35].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp36ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[35].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp37IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[36].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp37ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[36].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp38IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[37].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp38ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[37].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp39IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[38].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp39ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[38].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp40IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[39].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp40ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[39].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp41IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[40].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp41ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[40].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp42IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[41].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp42ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[41].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp43IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[42].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp43ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[42].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp44IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[43].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp44ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[43].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp45IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[44].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp45ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[44].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp46IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[45].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp46ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[45].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp47IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[46].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp47ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[46].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
			this.m_nudChirp48IdleTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[47].rlChirpRow_t.chirpNR3, 16) & 4095);
			this.m_nudChirp48ADCStartTimeVar.Value = (Convert.ToInt32(jobject.mmWaveDevices[p1].rfConfig.rlDynChirpCfgs[chirpSegInd].rlDynChirpCfg_t.rlChirpRows[47].rlChirpRow_t.chirpNR3, 16) & 268369920) >> 16;
		}

		private void UpdateAllRowsFrmCmd()
		{
			this.m_nudChirp1ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp1R1ProfileIndex;
			this.m_nudChirp1FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp1R1FreqSlopeVar;
			this.m_ChbChirp1Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp1R1Tx1Enable == 1);
			this.m_ChbChirp1Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp1R1Tx2Enable == 1);
			this.m_ChbChirp1Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp1R1Tx3Enable == 1);
			this.m_nudChirp1BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp1R1BPMConstVal;
			this.m_nudChirp1FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp1R2FreqStartVar;
			this.m_nudChirp1IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp1R3IdleTimeVar;
			this.m_nudChirp1ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp1R3ADCStartTimeVar;
			this.m_nudChirp2ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp2R1ProfileIndex;
			this.m_nudChirp2FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp2R1FreqSlopeVar;
			this.m_ChbChirp2Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp2R1Tx1Enable == 1);
			this.m_ChbChirp2Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp2R1Tx2Enable == 1);
			this.m_ChbChirp2Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp2R1Tx3Enable == 1);
			this.m_nudChirp2BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp2R1BPMConstVal;
			this.m_nudChirp2FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp2R2FreqStartVar;
			this.m_nudChirp2IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp2R3IdleTimeVar;
			this.m_nudChirp2ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp2R3ADCStartTimeVar;
			this.m_nudChirp3ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp3R1ProfileIndex;
			this.m_nudChirp3FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp3R1FreqSlopeVar;
			this.m_ChbChirp3Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp3R1Tx1Enable == 1);
			this.m_ChbChirp3Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp3R1Tx2Enable == 1);
			this.m_ChbChirp3Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp3R1Tx3Enable == 1);
			this.m_nudChirp3BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp3R1BPMConstVal;
			this.m_nudChirp3FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp3R2FreqStartVar;
			this.m_nudChirp3IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp3R3IdleTimeVar;
			this.m_nudChirp3ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp3R3ADCStartTimeVar;
			this.m_nudChirp4ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp4R1ProfileIndex;
			this.m_nudChirp4FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp4R1FreqSlopeVar;
			this.m_ChbChirp4Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp4R1Tx1Enable == 1);
			this.m_ChbChirp4Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp4R1Tx2Enable == 1);
			this.m_ChbChirp4Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp4R1Tx3Enable == 1);
			this.m_nudChirp4BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp4R1BPMConstVal;
			this.m_nudChirp4FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp4R2FreqStartVar;
			this.m_nudChirp4IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp4R3IdleTimeVar;
			this.m_nudChirp4ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp4R3ADCStartTimeVar;
			this.m_nudChirp5ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp5R1ProfileIndex;
			this.m_nudChirp5FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp5R1FreqSlopeVar;
			this.m_ChbChirp5Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp5R1Tx1Enable == 1);
			this.m_ChbChirp5Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp5R1Tx2Enable == 1);
			this.m_ChbChirp5Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp5R1Tx3Enable == 1);
			this.m_nudChirp5BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp5R1BPMConstVal;
			this.m_nudChirp5FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp5R2FreqStartVar;
			this.m_nudChirp5IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp5R3IdleTimeVar;
			this.m_nudChirp5ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp5R3ADCStartTimeVar;
			this.m_nudChirp6ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp6R1ProfileIndex;
			this.m_nudChirp6FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp6R1FreqSlopeVar;
			this.m_ChbChirp6Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp6R1Tx1Enable == 1);
			this.m_ChbChirp6Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp6R1Tx2Enable == 1);
			this.m_ChbChirp6Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp6R1Tx3Enable == 1);
			this.m_nudChirp6BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp6R1BPMConstVal;
			this.m_nudChirp6FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp6R2FreqStartVar;
			this.m_nudChirp6IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp6R3IdleTimeVar;
			this.m_nudChirp6ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp6R3ADCStartTimeVar;
			this.m_nudChirp7ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp7R1ProfileIndex;
			this.m_nudChirp7FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp7R1FreqSlopeVar;
			this.m_ChbChirp7Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp7R1Tx1Enable == 1);
			this.m_ChbChirp7Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp7R1Tx2Enable == 1);
			this.m_ChbChirp7Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp7R1Tx3Enable == 1);
			this.m_nudChirp7BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp7R1BPMConstVal;
			this.m_nudChirp7FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp7R2FreqStartVar;
			this.m_nudChirp7IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp7R3IdleTimeVar;
			this.m_nudChirp7ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp7R3ADCStartTimeVar;
			this.m_nudChirp8ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp8R1ProfileIndex;
			this.m_nudChirp8FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp8R1FreqSlopeVar;
			this.m_ChbChirp8Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp8R1Tx1Enable == 1);
			this.m_ChbChirp8Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp8R1Tx2Enable == 1);
			this.m_ChbChirp8Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp8R1Tx3Enable == 1);
			this.m_nudChirp8BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp8R1BPMConstVal;
			this.m_nudChirp8FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp8R2FreqStartVar;
			this.m_nudChirp8IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp8R3IdleTimeVar;
			this.m_nudChirp8ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp8R3ADCStartTimeVar;
			this.m_nudChirp9ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp9R1ProfileIndex;
			this.m_nudChirp9FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp9R1FreqSlopeVar;
			this.m_ChbChirp9Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp9R1Tx1Enable == 1);
			this.m_ChbChirp9Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp9R1Tx2Enable == 1);
			this.m_ChbChirp9Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp9R1Tx3Enable == 1);
			this.m_nudChirp9BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp9R1BPMConstVal;
			this.m_nudChirp9FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp9R2FreqStartVar;
			this.m_nudChirp9IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp9R3IdleTimeVar;
			this.m_nudChirp9ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp9R3ADCStartTimeVar;
			this.m_nudChirp10ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp10R1ProfileIndex;
			this.m_nudChirp10FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp10R1FreqSlopeVar;
			this.m_ChbChirp10Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp10R1Tx1Enable == 1);
			this.m_ChbChirp10Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp10R1Tx2Enable == 1);
			this.m_ChbChirp10Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp10R1Tx3Enable == 1);
			this.m_nudChirp10BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp10R1BPMConstVal;
			this.m_nudChirp10FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp10R2FreqStartVar;
			this.m_nudChirp10IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp10R3IdleTimeVar;
			this.m_nudChirp10ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp10R3ADCStartTimeVar;
			this.m_nudChirp11ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp11R1ProfileIndex;
			this.m_nudChirp11FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp11R1FreqSlopeVar;
			this.m_ChbChirp11Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp11R1Tx1Enable == 1);
			this.m_ChbChirp11Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp11R1Tx2Enable == 1);
			this.m_ChbChirp11Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp11R1Tx3Enable == 1);
			this.m_nudChirp11BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp11R1BPMConstVal;
			this.m_nudChirp11FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp11R2FreqStartVar;
			this.m_nudChirp11IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp11R3IdleTimeVar;
			this.m_nudChirp11ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp11R3ADCStartTimeVar;
			this.m_nudChirp12ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp12R1ProfileIndex;
			this.m_nudChirp12FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp12R1FreqSlopeVar;
			this.m_ChbChirp12Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp12R1Tx1Enable == 1);
			this.m_ChbChirp12Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp12R1Tx2Enable == 1);
			this.m_ChbChirp12Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp12R1Tx3Enable == 1);
			this.m_nudChirp12BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp12R1BPMConstVal;
			this.m_nudChirp12FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp12R2FreqStartVar;
			this.m_nudChirp12IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp12R3IdleTimeVar;
			this.m_nudChirp12ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp12R3ADCStartTimeVar;
			this.m_nudChirp13ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp13R1ProfileIndex;
			this.m_nudChirp13FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp13R1FreqSlopeVar;
			this.m_ChbChirp13Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp13R1Tx1Enable == 1);
			this.m_ChbChirp13Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp13R1Tx2Enable == 1);
			this.m_ChbChirp13Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp13R1Tx3Enable == 1);
			this.m_nudChirp13BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp13R1BPMConstVal;
			this.m_nudChirp13FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp13R2FreqStartVar;
			this.m_nudChirp13IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp13R3IdleTimeVar;
			this.m_nudChirp13ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp13R3ADCStartTimeVar;
			this.m_nudChirp14ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp14R1ProfileIndex;
			this.m_nudChirp14FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp14R1FreqSlopeVar;
			this.m_ChbChirp14Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp14R1Tx1Enable == 1);
			this.m_ChbChirp14Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp14R1Tx2Enable == 1);
			this.m_ChbChirp14Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp14R1Tx3Enable == 1);
			this.m_nudChirp14BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp14R1BPMConstVal;
			this.m_nudChirp14FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp14R2FreqStartVar;
			this.m_nudChirp14IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp14R3IdleTimeVar;
			this.m_nudChirp14ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp14R3ADCStartTimeVar;
			this.m_nudChirp15ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp15R1ProfileIndex;
			this.m_nudChirp15FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp15R1FreqSlopeVar;
			this.m_ChbChirp15Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp15R1Tx1Enable == 1);
			this.m_ChbChirp15Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp15R1Tx2Enable == 1);
			this.m_ChbChirp15Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp15R1Tx3Enable == 1);
			this.m_nudChirp15BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp15R1BPMConstVal;
			this.m_nudChirp15FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp15R2FreqStartVar;
			this.m_nudChirp15IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp15R3IdleTimeVar;
			this.m_nudChirp15ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp15R3ADCStartTimeVar;
			this.m_nudChirp16ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp16R1ProfileIndex;
			this.m_nudChirp16FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp16R1FreqSlopeVar;
			this.m_ChbChirp16Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp16R1Tx1Enable == 1);
			this.m_ChbChirp16Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp16R1Tx2Enable == 1);
			this.m_ChbChirp16Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp16R1Tx3Enable == 1);
			this.m_nudChirp16BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp16R1BPMConstVal;
			this.m_nudChirp16FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp16R2FreqStartVar;
			this.m_nudChirp16IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp16R3IdleTimeVar;
			this.m_nudChirp16ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp16R3ADCStartTimeVar;
		}

		private void UpdateRow1FrmCmd()
		{
			this.m_nudChirp1ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp1R1ProfileIndex;
			this.m_nudChirp1FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp1R1FreqSlopeVar;
			this.m_ChbChirp1Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp1R1Tx1Enable == 1);
			this.m_ChbChirp1Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp1R1Tx2Enable == 1);
			this.m_ChbChirp1Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp1R1Tx3Enable == 1);
			this.m_nudChirp1BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp1R1BPMConstVal;
			this.m_nudChirp2ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp2R1ProfileIndex;
			this.m_nudChirp2FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp2R1FreqSlopeVar;
			this.m_ChbChirp2Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp2R1Tx1Enable == 1);
			this.m_ChbChirp2Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp2R1Tx2Enable == 1);
			this.m_ChbChirp2Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp2R1Tx3Enable == 1);
			this.m_nudChirp2BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp2R1BPMConstVal;
			this.m_nudChirp3ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp3R1ProfileIndex;
			this.m_nudChirp3FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp3R1FreqSlopeVar;
			this.m_ChbChirp3Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp3R1Tx1Enable == 1);
			this.m_ChbChirp3Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp3R1Tx2Enable == 1);
			this.m_ChbChirp3Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp3R1Tx3Enable == 1);
			this.m_nudChirp3BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp3R1BPMConstVal;
			this.m_nudChirp4ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp4R1ProfileIndex;
			this.m_nudChirp4FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp4R1FreqSlopeVar;
			this.m_ChbChirp4Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp4R1Tx1Enable == 1);
			this.m_ChbChirp4Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp4R1Tx2Enable == 1);
			this.m_ChbChirp4Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp4R1Tx3Enable == 1);
			this.m_nudChirp4BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp4R1BPMConstVal;
			this.m_nudChirp5ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp5R1ProfileIndex;
			this.m_nudChirp5FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp5R1FreqSlopeVar;
			this.m_ChbChirp5Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp5R1Tx1Enable == 1);
			this.m_ChbChirp5Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp5R1Tx2Enable == 1);
			this.m_ChbChirp5Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp5R1Tx3Enable == 1);
			this.m_nudChirp5BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp5R1BPMConstVal;
			this.m_nudChirp6ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp6R1ProfileIndex;
			this.m_nudChirp6FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp6R1FreqSlopeVar;
			this.m_ChbChirp6Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp6R1Tx1Enable == 1);
			this.m_ChbChirp6Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp6R1Tx2Enable == 1);
			this.m_ChbChirp6Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp6R1Tx3Enable == 1);
			this.m_nudChirp6BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp6R1BPMConstVal;
			this.m_nudChirp7ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp7R1ProfileIndex;
			this.m_nudChirp7FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp7R1FreqSlopeVar;
			this.m_ChbChirp7Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp7R1Tx1Enable == 1);
			this.m_ChbChirp7Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp7R1Tx2Enable == 1);
			this.m_ChbChirp7Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp7R1Tx3Enable == 1);
			this.m_nudChirp7BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp7R1BPMConstVal;
			this.m_nudChirp8ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp8R1ProfileIndex;
			this.m_nudChirp8FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp8R1FreqSlopeVar;
			this.m_ChbChirp8Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp8R1Tx1Enable == 1);
			this.m_ChbChirp8Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp8R1Tx2Enable == 1);
			this.m_ChbChirp8Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp8R1Tx3Enable == 1);
			this.m_nudChirp8BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp8R1BPMConstVal;
			this.m_nudChirp9ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp9R1ProfileIndex;
			this.m_nudChirp9FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp9R1FreqSlopeVar;
			this.m_ChbChirp9Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp9R1Tx1Enable == 1);
			this.m_ChbChirp9Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp9R1Tx2Enable == 1);
			this.m_ChbChirp9Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp9R1Tx3Enable == 1);
			this.m_nudChirp9BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp9R1BPMConstVal;
			this.m_nudChirp10ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp10R1ProfileIndex;
			this.m_nudChirp10FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp10R1FreqSlopeVar;
			this.m_ChbChirp10Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp10R1Tx1Enable == 1);
			this.m_ChbChirp10Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp10R1Tx2Enable == 1);
			this.m_ChbChirp10Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp10R1Tx3Enable == 1);
			this.m_nudChirp10BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp10R1BPMConstVal;
			this.m_nudChirp11ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp11R1ProfileIndex;
			this.m_nudChirp11FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp11R1FreqSlopeVar;
			this.m_ChbChirp11Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp11R1Tx1Enable == 1);
			this.m_ChbChirp11Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp11R1Tx2Enable == 1);
			this.m_ChbChirp11Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp11R1Tx3Enable == 1);
			this.m_nudChirp11BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp11R1BPMConstVal;
			this.m_nudChirp12ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp12R1ProfileIndex;
			this.m_nudChirp12FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp12R1FreqSlopeVar;
			this.m_ChbChirp12Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp12R1Tx1Enable == 1);
			this.m_ChbChirp12Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp12R1Tx2Enable == 1);
			this.m_ChbChirp12Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp12R1Tx3Enable == 1);
			this.m_nudChirp12BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp12R1BPMConstVal;
			this.m_nudChirp13ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp13R1ProfileIndex;
			this.m_nudChirp13FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp13R1FreqSlopeVar;
			this.m_ChbChirp13Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp13R1Tx1Enable == 1);
			this.m_ChbChirp13Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp13R1Tx2Enable == 1);
			this.m_ChbChirp13Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp13R1Tx3Enable == 1);
			this.m_nudChirp13BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp13R1BPMConstVal;
			this.m_nudChirp14ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp14R1ProfileIndex;
			this.m_nudChirp14FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp14R1FreqSlopeVar;
			this.m_ChbChirp14Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp14R1Tx1Enable == 1);
			this.m_ChbChirp14Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp14R1Tx2Enable == 1);
			this.m_ChbChirp14Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp14R1Tx3Enable == 1);
			this.m_nudChirp14BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp14R1BPMConstVal;
			this.m_nudChirp15ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp15R1ProfileIndex;
			this.m_nudChirp15FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp15R1FreqSlopeVar;
			this.m_ChbChirp15Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp15R1Tx1Enable == 1);
			this.m_ChbChirp15Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp15R1Tx2Enable == 1);
			this.m_ChbChirp15Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp15R1Tx3Enable == 1);
			this.m_nudChirp15BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp15R1BPMConstVal;
			this.m_nudChirp16ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp16R1ProfileIndex;
			this.m_nudChirp16FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp16R1FreqSlopeVar;
			this.m_ChbChirp16Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp16R1Tx1Enable == 1);
			this.m_ChbChirp16Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp16R1Tx2Enable == 1);
			this.m_ChbChirp16Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp16R1Tx3Enable == 1);
			this.m_nudChirp16BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp16R1BPMConstVal;
			this.m_nudChirp17ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp17R1ProfileIndex;
			this.m_nudChirp17FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp17R1FreqSlopeVar;
			this.m_ChbChirp17Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp17R1Tx1Enable == 1);
			this.m_ChbChirp17Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp17R1Tx2Enable == 1);
			this.m_ChbChirp17Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp17R1Tx3Enable == 1);
			this.m_nudChirp17BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp17R1BPMConstVal;
			this.m_nudChirp18ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp18R1ProfileIndex;
			this.m_nudChirp18FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp18R1FreqSlopeVar;
			this.m_ChbChirp18Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp18R1Tx1Enable == 1);
			this.m_ChbChirp18Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp18R1Tx2Enable == 1);
			this.m_ChbChirp18Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp18R1Tx3Enable == 1);
			this.m_nudChirp18BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp18R1BPMConstVal;
			this.m_nudChirp19ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp19R1ProfileIndex;
			this.m_nudChirp19FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp19R1FreqSlopeVar;
			this.m_ChbChirp19Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp19R1Tx1Enable == 1);
			this.m_ChbChirp19Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp19R1Tx2Enable == 1);
			this.m_ChbChirp19Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp19R1Tx3Enable == 1);
			this.m_nudChirp19BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp19R1BPMConstVal;
			this.m_nudChirp20ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp20R1ProfileIndex;
			this.m_nudChirp20FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp20R1FreqSlopeVar;
			this.m_ChbChirp20Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp20R1Tx1Enable == 1);
			this.m_ChbChirp20Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp20R1Tx2Enable == 1);
			this.m_ChbChirp20Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp20R1Tx3Enable == 1);
			this.m_nudChirp20BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp20R1BPMConstVal;
			this.m_nudChirp21ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp21R1ProfileIndex;
			this.m_nudChirp21FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp21R1FreqSlopeVar;
			this.m_ChbChirp21Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp21R1Tx1Enable == 1);
			this.m_ChbChirp21Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp21R1Tx2Enable == 1);
			this.m_ChbChirp21Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp21R1Tx3Enable == 1);
			this.m_nudChirp21BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp21R1BPMConstVal;
			this.m_nudChirp22ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp22R1ProfileIndex;
			this.m_nudChirp22FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp22R1FreqSlopeVar;
			this.m_ChbChirp22Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp22R1Tx1Enable == 1);
			this.m_ChbChirp22Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp22R1Tx2Enable == 1);
			this.m_ChbChirp22Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp22R1Tx3Enable == 1);
			this.m_nudChirp22BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp22R1BPMConstVal;
			this.m_nudChirp23ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp23R1ProfileIndex;
			this.m_nudChirp23FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp23R1FreqSlopeVar;
			this.m_ChbChirp23Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp23R1Tx1Enable == 1);
			this.m_ChbChirp23Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp23R1Tx2Enable == 1);
			this.m_ChbChirp23Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp23R1Tx3Enable == 1);
			this.m_nudChirp23BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp23R1BPMConstVal;
			this.m_nudChirp24ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp24R1ProfileIndex;
			this.m_nudChirp24FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp24R1FreqSlopeVar;
			this.m_ChbChirp24Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp24R1Tx1Enable == 1);
			this.m_ChbChirp24Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp24R1Tx2Enable == 1);
			this.m_ChbChirp24Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp24R1Tx3Enable == 1);
			this.m_nudChirp24BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp24R1BPMConstVal;
			this.m_nudChirp25ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp25R1ProfileIndex;
			this.m_nudChirp25FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp25R1FreqSlopeVar;
			this.m_ChbChirp25Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp25R1Tx1Enable == 1);
			this.m_ChbChirp25Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp25R1Tx2Enable == 1);
			this.m_ChbChirp25Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp25R1Tx3Enable == 1);
			this.m_nudChirp25BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp25R1BPMConstVal;
			this.m_nudChirp26ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp26R1ProfileIndex;
			this.m_nudChirp26FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp26R1FreqSlopeVar;
			this.m_ChbChirp26Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp26R1Tx1Enable == 1);
			this.m_ChbChirp26Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp26R1Tx2Enable == 1);
			this.m_ChbChirp26Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp26R1Tx3Enable == 1);
			this.m_nudChirp26BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp26R1BPMConstVal;
			this.m_nudChirp27ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp27R1ProfileIndex;
			this.m_nudChirp27FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp27R1FreqSlopeVar;
			this.m_ChbChirp27Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp27R1Tx1Enable == 1);
			this.m_ChbChirp27Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp27R1Tx2Enable == 1);
			this.m_ChbChirp27Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp27R1Tx3Enable == 1);
			this.m_nudChirp27BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp27R1BPMConstVal;
			this.m_nudChirp28ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp28R1ProfileIndex;
			this.m_nudChirp28FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp28R1FreqSlopeVar;
			this.m_ChbChirp28Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp28R1Tx1Enable == 1);
			this.m_ChbChirp28Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp28R1Tx2Enable == 1);
			this.m_ChbChirp28Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp28R1Tx3Enable == 1);
			this.m_nudChirp28BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp28R1BPMConstVal;
			this.m_nudChirp29ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp29R1ProfileIndex;
			this.m_nudChirp29FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp29R1FreqSlopeVar;
			this.m_ChbChirp29Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp29R1Tx1Enable == 1);
			this.m_ChbChirp29Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp29R1Tx2Enable == 1);
			this.m_ChbChirp29Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp29R1Tx3Enable == 1);
			this.m_nudChirp29BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp29R1BPMConstVal;
			this.m_nudChirp30ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp30R1ProfileIndex;
			this.m_nudChirp30FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp30R1FreqSlopeVar;
			this.m_ChbChirp30Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp30R1Tx1Enable == 1);
			this.m_ChbChirp30Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp30R1Tx2Enable == 1);
			this.m_ChbChirp30Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp30R1Tx3Enable == 1);
			this.m_nudChirp30BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp30R1BPMConstVal;
			this.m_nudChirp31ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp31R1ProfileIndex;
			this.m_nudChirp31FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp31R1FreqSlopeVar;
			this.m_ChbChirp31Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp31R1Tx1Enable == 1);
			this.m_ChbChirp31Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp31R1Tx2Enable == 1);
			this.m_ChbChirp31Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp31R1Tx3Enable == 1);
			this.m_nudChirp31BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp31R1BPMConstVal;
			this.m_nudChirp32ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp32R1ProfileIndex;
			this.m_nudChirp32FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp32R1FreqSlopeVar;
			this.m_ChbChirp32Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp32R1Tx1Enable == 1);
			this.m_ChbChirp32Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp32R1Tx2Enable == 1);
			this.m_ChbChirp32Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp32R1Tx3Enable == 1);
			this.m_nudChirp32BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp32R1BPMConstVal;
			this.m_nudChirp33ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp33R1ProfileIndex;
			this.m_nudChirp33FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp33R1FreqSlopeVar;
			this.m_ChbChirp33Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp33R1Tx1Enable == 1);
			this.m_ChbChirp33Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp33R1Tx2Enable == 1);
			this.m_ChbChirp33Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp33R1Tx3Enable == 1);
			this.m_nudChirp33BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp33R1BPMConstVal;
			this.m_nudChirp34ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp34R1ProfileIndex;
			this.m_nudChirp34FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp34R1FreqSlopeVar;
			this.m_ChbChirp34Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp34R1Tx1Enable == 1);
			this.m_ChbChirp34Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp34R1Tx2Enable == 1);
			this.m_ChbChirp34Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp34R1Tx3Enable == 1);
			this.m_nudChirp34BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp34R1BPMConstVal;
			this.m_nudChirp35ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp35R1ProfileIndex;
			this.m_nudChirp35FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp35R1FreqSlopeVar;
			this.m_ChbChirp35Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp35R1Tx1Enable == 1);
			this.m_ChbChirp35Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp35R1Tx2Enable == 1);
			this.m_ChbChirp35Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp35R1Tx3Enable == 1);
			this.m_nudChirp35BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp35R1BPMConstVal;
			this.m_nudChirp36ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp36R1ProfileIndex;
			this.m_nudChirp36FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp36R1FreqSlopeVar;
			this.m_ChbChirp36Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp36R1Tx1Enable == 1);
			this.m_ChbChirp36Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp36R1Tx2Enable == 1);
			this.m_ChbChirp36Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp36R1Tx3Enable == 1);
			this.m_nudChirp36BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp36R1BPMConstVal;
			this.m_nudChirp37ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp37R1ProfileIndex;
			this.m_nudChirp37FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp37R1FreqSlopeVar;
			this.m_ChbChirp37Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp37R1Tx1Enable == 1);
			this.m_ChbChirp37Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp37R1Tx2Enable == 1);
			this.m_ChbChirp37Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp37R1Tx3Enable == 1);
			this.m_nudChirp37BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp37R1BPMConstVal;
			this.m_nudChirp38ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp38R1ProfileIndex;
			this.m_nudChirp38FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp38R1FreqSlopeVar;
			this.m_ChbChirp38Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp38R1Tx1Enable == 1);
			this.m_ChbChirp38Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp38R1Tx2Enable == 1);
			this.m_ChbChirp38Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp38R1Tx3Enable == 1);
			this.m_nudChirp38BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp38R1BPMConstVal;
			this.m_nudChirp39ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp39R1ProfileIndex;
			this.m_nudChirp39FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp39R1FreqSlopeVar;
			this.m_ChbChirp39Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp39R1Tx1Enable == 1);
			this.m_ChbChirp39Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp39R1Tx2Enable == 1);
			this.m_ChbChirp39Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp39R1Tx3Enable == 1);
			this.m_nudChirp39BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp39R1BPMConstVal;
			this.m_nudChirp40ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp40R1ProfileIndex;
			this.m_nudChirp40FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp40R1FreqSlopeVar;
			this.m_ChbChirp40Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp40R1Tx1Enable == 1);
			this.m_ChbChirp40Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp40R1Tx2Enable == 1);
			this.m_ChbChirp40Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp40R1Tx3Enable == 1);
			this.m_nudChirp40BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp40R1BPMConstVal;
			this.m_nudChirp41ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp41R1ProfileIndex;
			this.m_nudChirp41FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp41R1FreqSlopeVar;
			this.m_ChbChirp41Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp41R1Tx1Enable == 1);
			this.m_ChbChirp41Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp41R1Tx2Enable == 1);
			this.m_ChbChirp41Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp41R1Tx3Enable == 1);
			this.m_nudChirp41BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp41R1BPMConstVal;
			this.m_nudChirp42ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp42R1ProfileIndex;
			this.m_nudChirp42FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp42R1FreqSlopeVar;
			this.m_ChbChirp42Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp42R1Tx1Enable == 1);
			this.m_ChbChirp42Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp42R1Tx2Enable == 1);
			this.m_ChbChirp42Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp42R1Tx3Enable == 1);
			this.m_nudChirp42BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp42R1BPMConstVal;
			this.m_nudChirp43ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp43R1ProfileIndex;
			this.m_nudChirp43FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp43R1FreqSlopeVar;
			this.m_ChbChirp43Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp43R1Tx1Enable == 1);
			this.m_ChbChirp43Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp43R1Tx2Enable == 1);
			this.m_ChbChirp43Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp43R1Tx3Enable == 1);
			this.m_nudChirp43BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp43R1BPMConstVal;
			this.m_nudChirp44ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp44R1ProfileIndex;
			this.m_nudChirp44FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp44R1FreqSlopeVar;
			this.m_ChbChirp44Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp44R1Tx1Enable == 1);
			this.m_ChbChirp44Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp44R1Tx2Enable == 1);
			this.m_ChbChirp44Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp44R1Tx3Enable == 1);
			this.m_nudChirp44BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp44R1BPMConstVal;
			this.m_nudChirp45ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp45R1ProfileIndex;
			this.m_nudChirp45FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp45R1FreqSlopeVar;
			this.m_ChbChirp45Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp45R1Tx1Enable == 1);
			this.m_ChbChirp45Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp45R1Tx2Enable == 1);
			this.m_ChbChirp45Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp45R1Tx3Enable == 1);
			this.m_nudChirp45BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp45R1BPMConstVal;
			this.m_nudChirp46ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp46R1ProfileIndex;
			this.m_nudChirp46FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp46R1FreqSlopeVar;
			this.m_ChbChirp46Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp46R1Tx1Enable == 1);
			this.m_ChbChirp46Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp46R1Tx2Enable == 1);
			this.m_ChbChirp46Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp46R1Tx3Enable == 1);
			this.m_nudChirp46BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp46R1BPMConstVal;
			this.m_nudChirp47ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp47R1ProfileIndex;
			this.m_nudChirp47FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp47R1FreqSlopeVar;
			this.m_ChbChirp47Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp47R1Tx1Enable == 1);
			this.m_ChbChirp47Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp47R1Tx2Enable == 1);
			this.m_ChbChirp47Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp47R1Tx3Enable == 1);
			this.m_nudChirp47BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp47R1BPMConstVal;
			this.m_nudChirp48ProfileIndex.Value = this.m_DynamicChirpConfigParams.Chirp48R1ProfileIndex;
			this.m_nudChirp48FreqSlopeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp48R1FreqSlopeVar;
			this.m_ChbChirp48Tx1Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp48R1Tx1Enable == 1);
			this.m_ChbChirp48Tx2Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp48R1Tx2Enable == 1);
			this.m_ChbChirp48Tx3Enable.Checked = (this.m_DynamicChirpConfigParams.Chirp48R1Tx3Enable == 1);
			this.m_nudChirp48BPMConstVal.Value = this.m_DynamicChirpConfigParams.Chirp48R1BPMConstVal;
		}

		private void UpdateRow2FrmCmd()
		{
			this.m_nudChirp1FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp1R2FreqStartVar;
			this.m_nudChirp2FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp2R2FreqStartVar;
			this.m_nudChirp3FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp3R2FreqStartVar;
			this.m_nudChirp4FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp4R2FreqStartVar;
			this.m_nudChirp5FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp5R2FreqStartVar;
			this.m_nudChirp6FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp6R2FreqStartVar;
			this.m_nudChirp7FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp7R2FreqStartVar;
			this.m_nudChirp8FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp8R2FreqStartVar;
			this.m_nudChirp9FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp9R2FreqStartVar;
			this.m_nudChirp10FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp10R2FreqStartVar;
			this.m_nudChirp11FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp11R2FreqStartVar;
			this.m_nudChirp12FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp12R2FreqStartVar;
			this.m_nudChirp13FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp13R2FreqStartVar;
			this.m_nudChirp14FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp14R2FreqStartVar;
			this.m_nudChirp15FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp15R2FreqStartVar;
			this.m_nudChirp16FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp16R2FreqStartVar;
			this.m_nudChirp17FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp17R2FreqStartVar;
			this.m_nudChirp18FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp18R2FreqStartVar;
			this.m_nudChirp19FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp19R2FreqStartVar;
			this.m_nudChirp20FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp20R2FreqStartVar;
			this.m_nudChirp21FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp21R2FreqStartVar;
			this.m_nudChirp22FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp22R2FreqStartVar;
			this.m_nudChirp23FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp23R2FreqStartVar;
			this.m_nudChirp24FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp24R2FreqStartVar;
			this.m_nudChirp25FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp25R2FreqStartVar;
			this.m_nudChirp26FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp26R2FreqStartVar;
			this.m_nudChirp27FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp27R2FreqStartVar;
			this.m_nudChirp28FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp28R2FreqStartVar;
			this.m_nudChirp29FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp29R2FreqStartVar;
			this.m_nudChirp30FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp30R2FreqStartVar;
			this.m_nudChirp31FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp31R2FreqStartVar;
			this.m_nudChirp32FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp32R2FreqStartVar;
			this.m_nudChirp33FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp33R2FreqStartVar;
			this.m_nudChirp34FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp34R2FreqStartVar;
			this.m_nudChirp35FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp35R2FreqStartVar;
			this.m_nudChirp36FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp36R2FreqStartVar;
			this.m_nudChirp37FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp37R2FreqStartVar;
			this.m_nudChirp38FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp38R2FreqStartVar;
			this.m_nudChirp39FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp39R2FreqStartVar;
			this.m_nudChirp40FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp40R2FreqStartVar;
			this.m_nudChirp41FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp41R2FreqStartVar;
			this.m_nudChirp42FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp42R2FreqStartVar;
			this.m_nudChirp43FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp43R2FreqStartVar;
			this.m_nudChirp44FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp44R2FreqStartVar;
			this.m_nudChirp45FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp45R2FreqStartVar;
			this.m_nudChirp46FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp46R2FreqStartVar;
			this.m_nudChirp47FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp47R2FreqStartVar;
			this.m_nudChirp48FreqStartVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp48R2FreqStartVar;
		}

		private void UpdateRow3FrmCmd()
		{
			this.m_nudChirp1IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp1R3IdleTimeVar;
			this.m_nudChirp1ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp1R3ADCStartTimeVar;
			this.m_nudChirp2IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp2R3IdleTimeVar;
			this.m_nudChirp2ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp2R3ADCStartTimeVar;
			this.m_nudChirp3IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp3R3IdleTimeVar;
			this.m_nudChirp3ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp3R3ADCStartTimeVar;
			this.m_nudChirp4IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp4R3IdleTimeVar;
			this.m_nudChirp4ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp4R3ADCStartTimeVar;
			this.m_nudChirp5IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp5R3IdleTimeVar;
			this.m_nudChirp5ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp5R3ADCStartTimeVar;
			this.m_nudChirp6IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp6R3IdleTimeVar;
			this.m_nudChirp6ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp6R3ADCStartTimeVar;
			this.m_nudChirp7IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp7R3IdleTimeVar;
			this.m_nudChirp7ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp7R3ADCStartTimeVar;
			this.m_nudChirp8IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp8R3IdleTimeVar;
			this.m_nudChirp8ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp8R3ADCStartTimeVar;
			this.m_nudChirp9IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp9R3IdleTimeVar;
			this.m_nudChirp9ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp9R3ADCStartTimeVar;
			this.m_nudChirp10IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp10R3IdleTimeVar;
			this.m_nudChirp10ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp10R3ADCStartTimeVar;
			this.m_nudChirp11IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp11R3IdleTimeVar;
			this.m_nudChirp11ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp11R3ADCStartTimeVar;
			this.m_nudChirp12IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp12R3IdleTimeVar;
			this.m_nudChirp12ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp12R3ADCStartTimeVar;
			this.m_nudChirp13IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp13R3IdleTimeVar;
			this.m_nudChirp13ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp13R3ADCStartTimeVar;
			this.m_nudChirp14IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp14R3IdleTimeVar;
			this.m_nudChirp14ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp14R3ADCStartTimeVar;
			this.m_nudChirp15IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp15R3IdleTimeVar;
			this.m_nudChirp15ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp15R3ADCStartTimeVar;
			this.m_nudChirp16IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp16R3IdleTimeVar;
			this.m_nudChirp16ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp16R3ADCStartTimeVar;
			this.m_nudChirp17IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp17R3IdleTimeVar;
			this.m_nudChirp17ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp17R3ADCStartTimeVar;
			this.m_nudChirp18IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp18R3IdleTimeVar;
			this.m_nudChirp18ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp18R3ADCStartTimeVar;
			this.m_nudChirp19IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp19R3IdleTimeVar;
			this.m_nudChirp19ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp19R3ADCStartTimeVar;
			this.m_nudChirp20IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp20R3IdleTimeVar;
			this.m_nudChirp20ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp20R3ADCStartTimeVar;
			this.m_nudChirp21IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp21R3IdleTimeVar;
			this.m_nudChirp21ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp21R3ADCStartTimeVar;
			this.m_nudChirp22IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp22R3IdleTimeVar;
			this.m_nudChirp22ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp22R3ADCStartTimeVar;
			this.m_nudChirp23IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp23R3IdleTimeVar;
			this.m_nudChirp23ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp23R3ADCStartTimeVar;
			this.m_nudChirp24IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp24R3IdleTimeVar;
			this.m_nudChirp24ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp24R3ADCStartTimeVar;
			this.m_nudChirp25IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp25R3IdleTimeVar;
			this.m_nudChirp25ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp25R3ADCStartTimeVar;
			this.m_nudChirp26IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp26R3IdleTimeVar;
			this.m_nudChirp26ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp26R3ADCStartTimeVar;
			this.m_nudChirp27IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp27R3IdleTimeVar;
			this.m_nudChirp27ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp27R3ADCStartTimeVar;
			this.m_nudChirp28IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp28R3IdleTimeVar;
			this.m_nudChirp28ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp28R3ADCStartTimeVar;
			this.m_nudChirp29IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp29R3IdleTimeVar;
			this.m_nudChirp29ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp29R3ADCStartTimeVar;
			this.m_nudChirp30IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp30R3IdleTimeVar;
			this.m_nudChirp30ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp30R3ADCStartTimeVar;
			this.m_nudChirp31IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp31R3IdleTimeVar;
			this.m_nudChirp31ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp31R3ADCStartTimeVar;
			this.m_nudChirp32IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp32R3IdleTimeVar;
			this.m_nudChirp32ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp32R3ADCStartTimeVar;
			this.m_nudChirp33IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp33R3IdleTimeVar;
			this.m_nudChirp33ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp33R3ADCStartTimeVar;
			this.m_nudChirp34IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp34R3IdleTimeVar;
			this.m_nudChirp34ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp34R3ADCStartTimeVar;
			this.m_nudChirp35IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp35R3IdleTimeVar;
			this.m_nudChirp35ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp35R3ADCStartTimeVar;
			this.m_nudChirp36IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp36R3IdleTimeVar;
			this.m_nudChirp36ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp36R3ADCStartTimeVar;
			this.m_nudChirp37IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp37R3IdleTimeVar;
			this.m_nudChirp37ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp37R3ADCStartTimeVar;
			this.m_nudChirp38IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp38R3IdleTimeVar;
			this.m_nudChirp38ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp38R3ADCStartTimeVar;
			this.m_nudChirp39IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp39R3IdleTimeVar;
			this.m_nudChirp39ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp39R3ADCStartTimeVar;
			this.m_nudChirp40IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp40R3IdleTimeVar;
			this.m_nudChirp40ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp40R3ADCStartTimeVar;
			this.m_nudChirp41IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp41R3IdleTimeVar;
			this.m_nudChirp41ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp41R3ADCStartTimeVar;
			this.m_nudChirp42IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp42R3IdleTimeVar;
			this.m_nudChirp42ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp42R3ADCStartTimeVar;
			this.m_nudChirp43IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp43R3IdleTimeVar;
			this.m_nudChirp43ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp43R3ADCStartTimeVar;
			this.m_nudChirp44IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp44R3IdleTimeVar;
			this.m_nudChirp44ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp44R3ADCStartTimeVar;
			this.m_nudChirp45IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp45R3IdleTimeVar;
			this.m_nudChirp45ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp45R3ADCStartTimeVar;
			this.m_nudChirp46IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp46R3IdleTimeVar;
			this.m_nudChirp46ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp46R3ADCStartTimeVar;
			this.m_nudChirp47IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp47R3IdleTimeVar;
			this.m_nudChirp47ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp47R3ADCStartTimeVar;
			this.m_nudChirp48IdleTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp48R3IdleTimeVar;
			this.m_nudChirp48ADCStartTimeVar.Value = (decimal)this.m_DynamicChirpConfigParams.Chirp48R3ADCStartTimeVar;
		}

		public bool UpdateDynamicChirpConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateDynamicChirpConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudChirpSegmentSelect.Value = this.m_DynamicChirpConfigParams.ChirpSegmentSelect;
				this.m_nudChirpRowSelect.Value = this.m_DynamicChirpConfigParams.ChirpRowSelect;
				this.m_ChbProgramModeEnable.Checked = (this.m_DynamicChirpConfigParams.ProgramMode == 1);
				switch (this.m_DynamicChirpConfigParams.ChirpRowSelect)
				{
				case 0:
					this.UpdateAllRowsFrmCmd();
					break;
				case 1:
					this.UpdateRow1FrmCmd();
					break;
				case 2:
					this.UpdateRow2FrmCmd();
					break;
				case 3:
					this.UpdateRow3FrmCmd();
					break;
				default:
					this.UpdateAllRows();
					break;
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

		private void m_nudChirp1FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp1FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp1FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp2FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp2FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp2FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp3FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp3FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp3FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp4FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp4FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp4FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp5FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp5FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp5FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp6FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp6FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp6FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp7FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp7FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp7FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp8FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp8FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp8FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp9FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp9FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp9FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp10FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp10FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp10FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp11FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp11FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp11FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp12FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp12FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp12FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp13FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp13FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp13FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp14FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp14FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp14FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp15FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp15FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp15FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp16FreqSlope_ValueChanged(object sender, EventArgs p1)
		{
			double value = (double)((ushort)Math.Round((double)this.m_nudChirp16FreqSlopeVar.Value * 20.712612345679013)) * 3240000.0 / 67108864.0;
			this.m_nudChirp16FreqSlopeVar.Value = (decimal)value;
		}

		private void m_nudChirp1StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp1FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp1FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp2StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp2FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp2FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp3StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp3FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp3FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp4StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp4FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp4FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp5StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp5FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp5FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp6StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp6FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp6FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp7StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp7FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp7FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp8StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp8FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp8FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp9StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp9FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp9FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp10StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp10FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp10FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp11StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp11FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp11FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp12StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp12FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp12FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp13StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp13FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp13FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp14StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp14FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp14FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp15StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp15FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp15FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp16StartFreqConst_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp16FreqStartVar.Value / 3.6 * 67108864.0) / 67108864.0 * 3.6;
			this.m_nudChirp16FreqStartVar.Value = (decimal)value;
		}

		private void m_nudChirp1IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp1IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp1IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp2IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp2IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp2IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp3IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp3IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp3IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp4IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp4IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp4IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp5IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp5IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp5IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp6IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp6IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp6IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp7IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp7IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp7IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp8IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp8IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp8IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp9IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp9IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp9IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp10IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp10IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp10IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp11IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp11IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp11IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp12IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp12IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp12IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp13IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp13IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp13IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp14IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp14IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp14IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp15IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp15IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp15IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp16IdleTime_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp16IdleTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp16IdleTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp1AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp1ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp1ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp2AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp2ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp2ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp3AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp3ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp3ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp4AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp4ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp4ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp5AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp5ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp5ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp6AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp6ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp6ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp7AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp7ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp7ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp8AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp8ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp8ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp9AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp9ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp9ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp10AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp10ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp10ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp11AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp11ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp11ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp12AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp12ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp12ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp13AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp13ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp13ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp14AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp14ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp14ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp15AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp15ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp15ADCStartTimeVar.Value = (decimal)value;
		}

		private void m_nudChirp16AdcStart_ValueChanged(object sender, EventArgs p1)
		{
			double value = (uint)Math.Round((double)this.m_nudChirp16ADCStartTimeVar.Value * 100.0) / 100.0;
			this.m_nudChirp16ADCStartTimeVar.Value = (decimal)value;
		}

		private int iSetDynamicPerChirpPhaseShifterConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iDynamicPerChirpPhaseShifterConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetDynamicPerChirpPhaseShifterConfig()
		{
			this.iSetDynamicPerChirpPhaseShifterConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetDynamicPerChirpPhaseShifterConfigAsync()
		{
			new del_v_v(this.iSetDynamicPerChirpPhaseShifterConfig).BeginInvoke(null, null);
		}

		private void m_btnDynamicPerChirpPhaseShifterConfigSet_Click(object sender, EventArgs p1)
		{
			this.iSetDynamicPerChirpPhaseShifterConfigAsync();
		}

		public bool UpdateDynamicPerChirpPhaseShifterConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateDynamicPerChirpPhaseShifterConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_DynamicPerChirpPhaseShiftConfigParams.ChirpSegmentSelect = (byte)this.m_nudPerChirpSegmentSelect.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp1Tx1PhaseShifter = (byte)this.m_nudChirp1Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp1Tx2PhaseShifter = (byte)this.m_nudChirp1Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp1Tx3PhaseShifter = (byte)this.m_nudChirp1Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp2Tx1PhaseShifter = (byte)this.m_nudChirp2Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp2Tx2PhaseShifter = (byte)this.m_nudChirp2Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp2Tx3PhaseShifter = (byte)this.m_nudChirp2Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp3Tx1PhaseShifter = (byte)this.m_nudChirp3Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp3Tx2PhaseShifter = (byte)this.m_nudChirp3Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp3Tx3PhaseShifter = (byte)this.m_nudChirp3Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp4Tx1PhaseShifter = (byte)this.m_nudChirp4Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp4Tx2PhaseShifter = (byte)this.m_nudChirp4Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp4Tx3PhaseShifter = (byte)this.m_nudChirp4Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp5Tx1PhaseShifter = (byte)this.m_nudChirp5Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp5Tx2PhaseShifter = (byte)this.m_nudChirp5Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp5Tx3PhaseShifter = (byte)this.m_nudChirp5Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp6Tx1PhaseShifter = (byte)this.m_nudChirp6Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp6Tx2PhaseShifter = (byte)this.m_nudChirp6Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp6Tx3PhaseShifter = (byte)this.m_nudChirp6Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp7Tx1PhaseShifter = (byte)this.m_nudChirp7Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp7Tx2PhaseShifter = (byte)this.m_nudChirp7Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp7Tx3PhaseShifter = (byte)this.m_nudChirp7Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp8Tx1PhaseShifter = (byte)this.m_nudChirp8Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp8Tx2PhaseShifter = (byte)this.m_nudChirp8Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp8Tx3PhaseShifter = (byte)this.m_nudChirp8Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp9Tx1PhaseShifter = (byte)this.m_nudChirp9Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp9Tx2PhaseShifter = (byte)this.m_nudChirp9Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp9Tx3PhaseShifter = (byte)this.m_nudChirp9Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp10Tx1PhaseShifter = (byte)this.m_nudChirp10Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp10Tx2PhaseShifter = (byte)this.m_nudChirp10Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp10Tx3PhaseShifter = (byte)this.m_nudChirp10Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp11Tx1PhaseShifter = (byte)this.m_nudChirp11Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp11Tx2PhaseShifter = (byte)this.m_nudChirp11Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp11Tx3PhaseShifter = (byte)this.m_nudChirp11Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp12Tx1PhaseShifter = (byte)this.m_nudChirp12Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp12Tx2PhaseShifter = (byte)this.m_nudChirp12Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp12Tx3PhaseShifter = (byte)this.m_nudChirp12Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp13Tx1PhaseShifter = (byte)this.m_nudChirp13Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp13Tx2PhaseShifter = (byte)this.m_nudChirp13Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp13Tx3PhaseShifter = (byte)this.m_nudChirp13Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp14Tx1PhaseShifter = (byte)this.m_nudChirp14Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp14Tx2PhaseShifter = (byte)this.m_nudChirp14Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp14Tx3PhaseShifter = (byte)this.m_nudChirp14Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp15Tx1PhaseShifter = (byte)this.m_nudChirp15Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp15Tx2PhaseShifter = (byte)this.m_nudChirp15Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp15Tx3PhaseShifter = (byte)this.m_nudChirp15Tx3PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp16Tx1PhaseShifter = (byte)this.m_nudChirp16Tx1PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp16Tx2PhaseShifter = (byte)this.m_nudChirp16Tx2PhaseShiftter.Value;
				this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp16Tx3PhaseShifter = (byte)this.m_nudChirp16Tx3PhaseShiftter.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateDynamicPerChirpPhaseShifterConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateDynamicPerChirpPhaseShifterConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudPerChirpSegmentSelect.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.ChirpSegmentSelect;
				this.m_nudChirp1Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp1Tx1PhaseShifter;
				this.m_nudChirp1Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp1Tx2PhaseShifter;
				this.m_nudChirp1Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp1Tx3PhaseShifter;
				this.m_nudChirp2Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp2Tx1PhaseShifter;
				this.m_nudChirp2Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp2Tx2PhaseShifter;
				this.m_nudChirp2Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp2Tx3PhaseShifter;
				this.m_nudChirp3Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp3Tx1PhaseShifter;
				this.m_nudChirp3Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp3Tx2PhaseShifter;
				this.m_nudChirp3Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp3Tx3PhaseShifter;
				this.m_nudChirp4Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp4Tx1PhaseShifter;
				this.m_nudChirp4Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp4Tx2PhaseShifter;
				this.m_nudChirp4Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp4Tx3PhaseShifter;
				this.m_nudChirp5Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp5Tx1PhaseShifter;
				this.m_nudChirp5Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp5Tx2PhaseShifter;
				this.m_nudChirp5Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp5Tx3PhaseShifter;
				this.m_nudChirp6Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp6Tx1PhaseShifter;
				this.m_nudChirp6Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp6Tx2PhaseShifter;
				this.m_nudChirp6Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp6Tx3PhaseShifter;
				this.m_nudChirp7Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp7Tx1PhaseShifter;
				this.m_nudChirp7Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp7Tx2PhaseShifter;
				this.m_nudChirp7Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp7Tx3PhaseShifter;
				this.m_nudChirp8Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp8Tx1PhaseShifter;
				this.m_nudChirp8Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp8Tx2PhaseShifter;
				this.m_nudChirp8Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp8Tx3PhaseShifter;
				this.m_nudChirp9Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp9Tx1PhaseShifter;
				this.m_nudChirp9Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp9Tx2PhaseShifter;
				this.m_nudChirp9Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp9Tx3PhaseShifter;
				this.m_nudChirp10Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp10Tx1PhaseShifter;
				this.m_nudChirp10Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp10Tx2PhaseShifter;
				this.m_nudChirp10Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp10Tx3PhaseShifter;
				this.m_nudChirp11Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp11Tx1PhaseShifter;
				this.m_nudChirp11Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp11Tx2PhaseShifter;
				this.m_nudChirp11Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp11Tx3PhaseShifter;
				this.m_nudChirp12Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp12Tx1PhaseShifter;
				this.m_nudChirp12Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp12Tx2PhaseShifter;
				this.m_nudChirp12Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp12Tx3PhaseShifter;
				this.m_nudChirp13Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp13Tx1PhaseShifter;
				this.m_nudChirp13Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp13Tx2PhaseShifter;
				this.m_nudChirp13Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp13Tx3PhaseShifter;
				this.m_nudChirp14Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp14Tx1PhaseShifter;
				this.m_nudChirp14Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp14Tx2PhaseShifter;
				this.m_nudChirp14Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp14Tx3PhaseShifter;
				this.m_nudChirp15Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp15Tx1PhaseShifter;
				this.m_nudChirp15Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp15Tx2PhaseShifter;
				this.m_nudChirp15Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp15Tx3PhaseShifter;
				this.m_nudChirp16Tx1PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp16Tx1PhaseShifter;
				this.m_nudChirp16Tx2PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp16Tx2PhaseShifter;
				this.m_nudChirp16Tx3PhaseShiftter.Value = this.m_DynamicPerChirpPhaseShiftConfigParams.Chirp16Tx3PhaseShifter;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private int iSetDynamicChirpEnableConfig_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iDynamicChirpEnableConfig_Gui(is_starting_op, is_ending_op);
		}

		private void iSetDynamicChirpEnableConfig()
		{
			this.iSetDynamicChirpEnableConfig_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetDynamicChirpEnableConfigAsync()
		{
			new del_v_v(this.iSetDynamicChirpEnableConfig).BeginInvoke(null, null);
		}

		private void m_btnDynamicChirpEnableConfigSet_Click(object sender, EventArgs p1)
		{
			this.iSetDynamicChirpEnableConfigAsync();
		}

		public bool UpdateDynamicChirpEnableConfigData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateDynamicChirpEnableConfigData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_DynamicChirpEnableConfigParams.Reserved = 0U;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateDynamicChirpEnableConfigDataFrmCmd()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateDynamicChirpEnableConfigDataFrmCmd);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_DynamicChirpEnableConfigParams.Reserved = 0U;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		private void m_nudChirpSegmentSelect_ValueChanged(object sender, EventArgs p1)
		{
			this.f00017c = (int)this.m_nudChirpSegmentSelect.Value;
		}

		public void Row1(bool res, int rowNo)
		{
			this.m_nudChirp1ProfileIndex.Enabled = res;
			this.m_nudChirp2ProfileIndex.Enabled = res;
			this.m_nudChirp3ProfileIndex.Enabled = res;
			this.m_nudChirp4ProfileIndex.Enabled = res;
			this.m_nudChirp5ProfileIndex.Enabled = res;
			this.m_nudChirp6ProfileIndex.Enabled = res;
			this.m_nudChirp7ProfileIndex.Enabled = res;
			this.m_nudChirp8ProfileIndex.Enabled = res;
			this.m_nudChirp9ProfileIndex.Enabled = res;
			this.m_nudChirp10ProfileIndex.Enabled = res;
			this.m_nudChirp11ProfileIndex.Enabled = res;
			this.m_nudChirp12ProfileIndex.Enabled = res;
			this.m_nudChirp13ProfileIndex.Enabled = res;
			this.m_nudChirp14ProfileIndex.Enabled = res;
			this.m_nudChirp15ProfileIndex.Enabled = res;
			this.m_nudChirp16ProfileIndex.Enabled = res;
			this.m_nudChirp1FreqSlopeVar.Enabled = res;
			this.m_nudChirp2FreqSlopeVar.Enabled = res;
			this.m_nudChirp3FreqSlopeVar.Enabled = res;
			this.m_nudChirp4FreqSlopeVar.Enabled = res;
			this.m_nudChirp5FreqSlopeVar.Enabled = res;
			this.m_nudChirp6FreqSlopeVar.Enabled = res;
			this.m_nudChirp7FreqSlopeVar.Enabled = res;
			this.m_nudChirp8FreqSlopeVar.Enabled = res;
			this.m_nudChirp9FreqSlopeVar.Enabled = res;
			this.m_nudChirp10FreqSlopeVar.Enabled = res;
			this.m_nudChirp11FreqSlopeVar.Enabled = res;
			this.m_nudChirp12FreqSlopeVar.Enabled = res;
			this.m_nudChirp13FreqSlopeVar.Enabled = res;
			this.m_nudChirp14FreqSlopeVar.Enabled = res;
			this.m_nudChirp15FreqSlopeVar.Enabled = res;
			this.m_nudChirp16FreqSlopeVar.Enabled = res;
			this.m_ChbChirp1Tx1Enable.Enabled = res;
			this.m_ChbChirp2Tx1Enable.Enabled = res;
			this.m_ChbChirp3Tx1Enable.Enabled = res;
			this.m_ChbChirp4Tx1Enable.Enabled = res;
			this.m_ChbChirp5Tx1Enable.Enabled = res;
			this.m_ChbChirp6Tx1Enable.Enabled = res;
			this.m_ChbChirp7Tx1Enable.Enabled = res;
			this.m_ChbChirp8Tx1Enable.Enabled = res;
			this.m_ChbChirp9Tx1Enable.Enabled = res;
			this.m_ChbChirp10Tx1Enable.Enabled = res;
			this.m_ChbChirp11Tx1Enable.Enabled = res;
			this.m_ChbChirp12Tx1Enable.Enabled = res;
			this.m_ChbChirp13Tx1Enable.Enabled = res;
			this.m_ChbChirp14Tx1Enable.Enabled = res;
			this.m_ChbChirp15Tx1Enable.Enabled = res;
			this.m_ChbChirp16Tx1Enable.Enabled = res;
			this.m_ChbChirp1Tx2Enable.Enabled = res;
			this.m_ChbChirp2Tx2Enable.Enabled = res;
			this.m_ChbChirp3Tx2Enable.Enabled = res;
			this.m_ChbChirp4Tx2Enable.Enabled = res;
			this.m_ChbChirp5Tx2Enable.Enabled = res;
			this.m_ChbChirp6Tx2Enable.Enabled = res;
			this.m_ChbChirp7Tx2Enable.Enabled = res;
			this.m_ChbChirp8Tx2Enable.Enabled = res;
			this.m_ChbChirp9Tx2Enable.Enabled = res;
			this.m_ChbChirp10Tx2Enable.Enabled = res;
			this.m_ChbChirp11Tx2Enable.Enabled = res;
			this.m_ChbChirp12Tx2Enable.Enabled = res;
			this.m_ChbChirp13Tx2Enable.Enabled = res;
			this.m_ChbChirp14Tx2Enable.Enabled = res;
			this.m_ChbChirp15Tx2Enable.Enabled = res;
			this.m_ChbChirp16Tx2Enable.Enabled = res;
			this.m_ChbChirp1Tx3Enable.Enabled = res;
			this.m_ChbChirp2Tx3Enable.Enabled = res;
			this.m_ChbChirp3Tx3Enable.Enabled = res;
			this.m_ChbChirp4Tx3Enable.Enabled = res;
			this.m_ChbChirp5Tx3Enable.Enabled = res;
			this.m_ChbChirp6Tx3Enable.Enabled = res;
			this.m_ChbChirp7Tx3Enable.Enabled = res;
			this.m_ChbChirp8Tx3Enable.Enabled = res;
			this.m_ChbChirp9Tx3Enable.Enabled = res;
			this.m_ChbChirp10Tx3Enable.Enabled = res;
			this.m_ChbChirp11Tx3Enable.Enabled = res;
			this.m_ChbChirp12Tx3Enable.Enabled = res;
			this.m_ChbChirp13Tx3Enable.Enabled = res;
			this.m_ChbChirp14Tx3Enable.Enabled = res;
			this.m_ChbChirp15Tx3Enable.Enabled = res;
			this.m_ChbChirp16Tx3Enable.Enabled = res;
			this.m_nudChirp1BPMConstVal.Enabled = res;
			this.m_nudChirp2BPMConstVal.Enabled = res;
			this.m_nudChirp3BPMConstVal.Enabled = res;
			this.m_nudChirp4BPMConstVal.Enabled = res;
			this.m_nudChirp5BPMConstVal.Enabled = res;
			this.m_nudChirp6BPMConstVal.Enabled = res;
			this.m_nudChirp7BPMConstVal.Enabled = res;
			this.m_nudChirp8BPMConstVal.Enabled = res;
			this.m_nudChirp9BPMConstVal.Enabled = res;
			this.m_nudChirp10BPMConstVal.Enabled = res;
			this.m_nudChirp11BPMConstVal.Enabled = res;
			this.m_nudChirp12BPMConstVal.Enabled = res;
			this.m_nudChirp13BPMConstVal.Enabled = res;
			this.m_nudChirp14BPMConstVal.Enabled = res;
			this.m_nudChirp15BPMConstVal.Enabled = res;
			this.m_nudChirp16BPMConstVal.Enabled = res;
			if (rowNo == 0)
			{
				res = !res;
			}
			this.m_nudChirp17ProfileIndex.Enabled = res;
			this.m_nudChirp18ProfileIndex.Enabled = res;
			this.m_nudChirp19ProfileIndex.Enabled = res;
			this.m_nudChirp20ProfileIndex.Enabled = res;
			this.m_nudChirp21ProfileIndex.Enabled = res;
			this.m_nudChirp22ProfileIndex.Enabled = res;
			this.m_nudChirp23ProfileIndex.Enabled = res;
			this.m_nudChirp24ProfileIndex.Enabled = res;
			this.m_nudChirp25ProfileIndex.Enabled = res;
			this.m_nudChirp26ProfileIndex.Enabled = res;
			this.m_nudChirp27ProfileIndex.Enabled = res;
			this.m_nudChirp28ProfileIndex.Enabled = res;
			this.m_nudChirp29ProfileIndex.Enabled = res;
			this.m_nudChirp30ProfileIndex.Enabled = res;
			this.m_nudChirp31ProfileIndex.Enabled = res;
			this.m_nudChirp32ProfileIndex.Enabled = res;
			this.m_nudChirp17FreqSlopeVar.Enabled = res;
			this.m_nudChirp18FreqSlopeVar.Enabled = res;
			this.m_nudChirp19FreqSlopeVar.Enabled = res;
			this.m_nudChirp20FreqSlopeVar.Enabled = res;
			this.m_nudChirp21FreqSlopeVar.Enabled = res;
			this.m_nudChirp22FreqSlopeVar.Enabled = res;
			this.m_nudChirp23FreqSlopeVar.Enabled = res;
			this.m_nudChirp24FreqSlopeVar.Enabled = res;
			this.m_nudChirp25FreqSlopeVar.Enabled = res;
			this.m_nudChirp26FreqSlopeVar.Enabled = res;
			this.m_nudChirp27FreqSlopeVar.Enabled = res;
			this.m_nudChirp28FreqSlopeVar.Enabled = res;
			this.m_nudChirp29FreqSlopeVar.Enabled = res;
			this.m_nudChirp30FreqSlopeVar.Enabled = res;
			this.m_nudChirp31FreqSlopeVar.Enabled = res;
			this.m_nudChirp32FreqSlopeVar.Enabled = res;
			this.m_ChbChirp17Tx1Enable.Enabled = res;
			this.m_ChbChirp18Tx1Enable.Enabled = res;
			this.m_ChbChirp19Tx1Enable.Enabled = res;
			this.m_ChbChirp20Tx1Enable.Enabled = res;
			this.m_ChbChirp21Tx1Enable.Enabled = res;
			this.m_ChbChirp22Tx1Enable.Enabled = res;
			this.m_ChbChirp23Tx1Enable.Enabled = res;
			this.m_ChbChirp24Tx1Enable.Enabled = res;
			this.m_ChbChirp25Tx1Enable.Enabled = res;
			this.m_ChbChirp26Tx1Enable.Enabled = res;
			this.m_ChbChirp27Tx1Enable.Enabled = res;
			this.m_ChbChirp28Tx1Enable.Enabled = res;
			this.m_ChbChirp29Tx1Enable.Enabled = res;
			this.m_ChbChirp30Tx1Enable.Enabled = res;
			this.m_ChbChirp31Tx1Enable.Enabled = res;
			this.m_ChbChirp32Tx1Enable.Enabled = res;
			this.m_ChbChirp17Tx2Enable.Enabled = res;
			this.m_ChbChirp18Tx2Enable.Enabled = res;
			this.m_ChbChirp19Tx2Enable.Enabled = res;
			this.m_ChbChirp20Tx2Enable.Enabled = res;
			this.m_ChbChirp21Tx2Enable.Enabled = res;
			this.m_ChbChirp22Tx2Enable.Enabled = res;
			this.m_ChbChirp23Tx2Enable.Enabled = res;
			this.m_ChbChirp24Tx2Enable.Enabled = res;
			this.m_ChbChirp25Tx2Enable.Enabled = res;
			this.m_ChbChirp26Tx2Enable.Enabled = res;
			this.m_ChbChirp27Tx2Enable.Enabled = res;
			this.m_ChbChirp28Tx2Enable.Enabled = res;
			this.m_ChbChirp29Tx2Enable.Enabled = res;
			this.m_ChbChirp30Tx2Enable.Enabled = res;
			this.m_ChbChirp31Tx2Enable.Enabled = res;
			this.m_ChbChirp32Tx2Enable.Enabled = res;
			this.m_ChbChirp17Tx3Enable.Enabled = res;
			this.m_ChbChirp18Tx3Enable.Enabled = res;
			this.m_ChbChirp19Tx3Enable.Enabled = res;
			this.m_ChbChirp20Tx3Enable.Enabled = res;
			this.m_ChbChirp21Tx3Enable.Enabled = res;
			this.m_ChbChirp22Tx3Enable.Enabled = res;
			this.m_ChbChirp23Tx3Enable.Enabled = res;
			this.m_ChbChirp24Tx3Enable.Enabled = res;
			this.m_ChbChirp25Tx3Enable.Enabled = res;
			this.m_ChbChirp26Tx3Enable.Enabled = res;
			this.m_ChbChirp27Tx3Enable.Enabled = res;
			this.m_ChbChirp28Tx3Enable.Enabled = res;
			this.m_ChbChirp29Tx3Enable.Enabled = res;
			this.m_ChbChirp30Tx3Enable.Enabled = res;
			this.m_ChbChirp31Tx3Enable.Enabled = res;
			this.m_ChbChirp32Tx3Enable.Enabled = res;
			this.m_nudChirp17BPMConstVal.Enabled = res;
			this.m_nudChirp18BPMConstVal.Enabled = res;
			this.m_nudChirp19BPMConstVal.Enabled = res;
			this.m_nudChirp20BPMConstVal.Enabled = res;
			this.m_nudChirp21BPMConstVal.Enabled = res;
			this.m_nudChirp22BPMConstVal.Enabled = res;
			this.m_nudChirp23BPMConstVal.Enabled = res;
			this.m_nudChirp24BPMConstVal.Enabled = res;
			this.m_nudChirp25BPMConstVal.Enabled = res;
			this.m_nudChirp26BPMConstVal.Enabled = res;
			this.m_nudChirp27BPMConstVal.Enabled = res;
			this.m_nudChirp28BPMConstVal.Enabled = res;
			this.m_nudChirp29BPMConstVal.Enabled = res;
			this.m_nudChirp30BPMConstVal.Enabled = res;
			this.m_nudChirp31BPMConstVal.Enabled = res;
			this.m_nudChirp32BPMConstVal.Enabled = res;
			if (this.m_nudChirpSegmentSelect.Value == 10m && rowNo != 0)
			{
				res = false;
			}
			this.m_nudChirp33ProfileIndex.Enabled = res;
			this.m_nudChirp34ProfileIndex.Enabled = res;
			this.m_nudChirp35ProfileIndex.Enabled = res;
			this.m_nudChirp36ProfileIndex.Enabled = res;
			this.m_nudChirp37ProfileIndex.Enabled = res;
			this.m_nudChirp38ProfileIndex.Enabled = res;
			this.m_nudChirp39ProfileIndex.Enabled = res;
			this.m_nudChirp40ProfileIndex.Enabled = res;
			this.m_nudChirp41ProfileIndex.Enabled = res;
			this.m_nudChirp42ProfileIndex.Enabled = res;
			this.m_nudChirp43ProfileIndex.Enabled = res;
			this.m_nudChirp44ProfileIndex.Enabled = res;
			this.m_nudChirp45ProfileIndex.Enabled = res;
			this.m_nudChirp46ProfileIndex.Enabled = res;
			this.m_nudChirp47ProfileIndex.Enabled = res;
			this.m_nudChirp48ProfileIndex.Enabled = res;
			this.m_nudChirp33FreqSlopeVar.Enabled = res;
			this.m_nudChirp34FreqSlopeVar.Enabled = res;
			this.m_nudChirp35FreqSlopeVar.Enabled = res;
			this.m_nudChirp36FreqSlopeVar.Enabled = res;
			this.m_nudChirp37FreqSlopeVar.Enabled = res;
			this.m_nudChirp38FreqSlopeVar.Enabled = res;
			this.m_nudChirp39FreqSlopeVar.Enabled = res;
			this.m_nudChirp40FreqSlopeVar.Enabled = res;
			this.m_nudChirp41FreqSlopeVar.Enabled = res;
			this.m_nudChirp42FreqSlopeVar.Enabled = res;
			this.m_nudChirp43FreqSlopeVar.Enabled = res;
			this.m_nudChirp44FreqSlopeVar.Enabled = res;
			this.m_nudChirp45FreqSlopeVar.Enabled = res;
			this.m_nudChirp46FreqSlopeVar.Enabled = res;
			this.m_nudChirp47FreqSlopeVar.Enabled = res;
			this.m_nudChirp48FreqSlopeVar.Enabled = res;
			this.m_ChbChirp33Tx1Enable.Enabled = res;
			this.m_ChbChirp34Tx1Enable.Enabled = res;
			this.m_ChbChirp35Tx1Enable.Enabled = res;
			this.m_ChbChirp36Tx1Enable.Enabled = res;
			this.m_ChbChirp37Tx1Enable.Enabled = res;
			this.m_ChbChirp38Tx1Enable.Enabled = res;
			this.m_ChbChirp39Tx1Enable.Enabled = res;
			this.m_ChbChirp40Tx1Enable.Enabled = res;
			this.m_ChbChirp41Tx1Enable.Enabled = res;
			this.m_ChbChirp42Tx1Enable.Enabled = res;
			this.m_ChbChirp43Tx1Enable.Enabled = res;
			this.m_ChbChirp44Tx1Enable.Enabled = res;
			this.m_ChbChirp45Tx1Enable.Enabled = res;
			this.m_ChbChirp46Tx1Enable.Enabled = res;
			this.m_ChbChirp47Tx1Enable.Enabled = res;
			this.m_ChbChirp48Tx1Enable.Enabled = res;
			this.m_ChbChirp33Tx2Enable.Enabled = res;
			this.m_ChbChirp34Tx2Enable.Enabled = res;
			this.m_ChbChirp35Tx2Enable.Enabled = res;
			this.m_ChbChirp36Tx2Enable.Enabled = res;
			this.m_ChbChirp37Tx2Enable.Enabled = res;
			this.m_ChbChirp38Tx2Enable.Enabled = res;
			this.m_ChbChirp39Tx2Enable.Enabled = res;
			this.m_ChbChirp40Tx2Enable.Enabled = res;
			this.m_ChbChirp41Tx2Enable.Enabled = res;
			this.m_ChbChirp42Tx2Enable.Enabled = res;
			this.m_ChbChirp43Tx2Enable.Enabled = res;
			this.m_ChbChirp44Tx2Enable.Enabled = res;
			this.m_ChbChirp45Tx2Enable.Enabled = res;
			this.m_ChbChirp46Tx2Enable.Enabled = res;
			this.m_ChbChirp47Tx2Enable.Enabled = res;
			this.m_ChbChirp48Tx2Enable.Enabled = res;
			this.m_ChbChirp33Tx3Enable.Enabled = res;
			this.m_ChbChirp34Tx3Enable.Enabled = res;
			this.m_ChbChirp35Tx3Enable.Enabled = res;
			this.m_ChbChirp36Tx3Enable.Enabled = res;
			this.m_ChbChirp37Tx3Enable.Enabled = res;
			this.m_ChbChirp38Tx3Enable.Enabled = res;
			this.m_ChbChirp39Tx3Enable.Enabled = res;
			this.m_ChbChirp40Tx3Enable.Enabled = res;
			this.m_ChbChirp41Tx3Enable.Enabled = res;
			this.m_ChbChirp42Tx3Enable.Enabled = res;
			this.m_ChbChirp43Tx3Enable.Enabled = res;
			this.m_ChbChirp44Tx3Enable.Enabled = res;
			this.m_ChbChirp45Tx3Enable.Enabled = res;
			this.m_ChbChirp46Tx3Enable.Enabled = res;
			this.m_ChbChirp47Tx3Enable.Enabled = res;
			this.m_ChbChirp48Tx3Enable.Enabled = res;
			this.m_nudChirp33BPMConstVal.Enabled = res;
			this.m_nudChirp34BPMConstVal.Enabled = res;
			this.m_nudChirp35BPMConstVal.Enabled = res;
			this.m_nudChirp36BPMConstVal.Enabled = res;
			this.m_nudChirp37BPMConstVal.Enabled = res;
			this.m_nudChirp38BPMConstVal.Enabled = res;
			this.m_nudChirp39BPMConstVal.Enabled = res;
			this.m_nudChirp40BPMConstVal.Enabled = res;
			this.m_nudChirp41BPMConstVal.Enabled = res;
			this.m_nudChirp42BPMConstVal.Enabled = res;
			this.m_nudChirp43BPMConstVal.Enabled = res;
			this.m_nudChirp44BPMConstVal.Enabled = res;
			this.m_nudChirp45BPMConstVal.Enabled = res;
			this.m_nudChirp46BPMConstVal.Enabled = res;
			this.m_nudChirp47BPMConstVal.Enabled = res;
			this.m_nudChirp48BPMConstVal.Enabled = res;
		}

		public void Row2(bool res, int rowNo)
		{
			this.m_nudChirp1FreqStartVar.Enabled = res;
			this.m_nudChirp2FreqStartVar.Enabled = res;
			this.m_nudChirp3FreqStartVar.Enabled = res;
			this.m_nudChirp4FreqStartVar.Enabled = res;
			this.m_nudChirp5FreqStartVar.Enabled = res;
			this.m_nudChirp6FreqStartVar.Enabled = res;
			this.m_nudChirp7FreqStartVar.Enabled = res;
			this.m_nudChirp8FreqStartVar.Enabled = res;
			this.m_nudChirp9FreqStartVar.Enabled = res;
			this.m_nudChirp10FreqStartVar.Enabled = res;
			this.m_nudChirp11FreqStartVar.Enabled = res;
			this.m_nudChirp12FreqStartVar.Enabled = res;
			this.m_nudChirp13FreqStartVar.Enabled = res;
			this.m_nudChirp14FreqStartVar.Enabled = res;
			this.m_nudChirp15FreqStartVar.Enabled = res;
			this.m_nudChirp16FreqStartVar.Enabled = res;
			if (rowNo == 0)
			{
				res = !res;
			}
			this.m_nudChirp17FreqStartVar.Enabled = res;
			this.m_nudChirp18FreqStartVar.Enabled = res;
			this.m_nudChirp19FreqStartVar.Enabled = res;
			this.m_nudChirp20FreqStartVar.Enabled = res;
			this.m_nudChirp21FreqStartVar.Enabled = res;
			this.m_nudChirp22FreqStartVar.Enabled = res;
			this.m_nudChirp23FreqStartVar.Enabled = res;
			this.m_nudChirp24FreqStartVar.Enabled = res;
			this.m_nudChirp25FreqStartVar.Enabled = res;
			this.m_nudChirp26FreqStartVar.Enabled = res;
			this.m_nudChirp27FreqStartVar.Enabled = res;
			this.m_nudChirp28FreqStartVar.Enabled = res;
			this.m_nudChirp29FreqStartVar.Enabled = res;
			this.m_nudChirp30FreqStartVar.Enabled = res;
			this.m_nudChirp31FreqStartVar.Enabled = res;
			this.m_nudChirp32FreqStartVar.Enabled = res;
			if (this.m_nudChirpSegmentSelect.Value == 10m && rowNo != 0)
			{
				res = false;
			}
			this.m_nudChirp33FreqStartVar.Enabled = res;
			this.m_nudChirp34FreqStartVar.Enabled = res;
			this.m_nudChirp35FreqStartVar.Enabled = res;
			this.m_nudChirp36FreqStartVar.Enabled = res;
			this.m_nudChirp37FreqStartVar.Enabled = res;
			this.m_nudChirp38FreqStartVar.Enabled = res;
			this.m_nudChirp39FreqStartVar.Enabled = res;
			this.m_nudChirp40FreqStartVar.Enabled = res;
			this.m_nudChirp41FreqStartVar.Enabled = res;
			this.m_nudChirp42FreqStartVar.Enabled = res;
			this.m_nudChirp43FreqStartVar.Enabled = res;
			this.m_nudChirp44FreqStartVar.Enabled = res;
			this.m_nudChirp45FreqStartVar.Enabled = res;
			this.m_nudChirp46FreqStartVar.Enabled = res;
			this.m_nudChirp47FreqStartVar.Enabled = res;
			this.m_nudChirp48FreqStartVar.Enabled = res;
		}

		public void Row3(bool res, int rowNo)
		{
			this.m_nudChirp1IdleTimeVar.Enabled = res;
			this.m_nudChirp2IdleTimeVar.Enabled = res;
			this.m_nudChirp3IdleTimeVar.Enabled = res;
			this.m_nudChirp4IdleTimeVar.Enabled = res;
			this.m_nudChirp5IdleTimeVar.Enabled = res;
			this.m_nudChirp6IdleTimeVar.Enabled = res;
			this.m_nudChirp7IdleTimeVar.Enabled = res;
			this.m_nudChirp8IdleTimeVar.Enabled = res;
			this.m_nudChirp9IdleTimeVar.Enabled = res;
			this.m_nudChirp10IdleTimeVar.Enabled = res;
			this.m_nudChirp11IdleTimeVar.Enabled = res;
			this.m_nudChirp12IdleTimeVar.Enabled = res;
			this.m_nudChirp13IdleTimeVar.Enabled = res;
			this.m_nudChirp14IdleTimeVar.Enabled = res;
			this.m_nudChirp15IdleTimeVar.Enabled = res;
			this.m_nudChirp16IdleTimeVar.Enabled = res;
			this.m_nudChirp1ADCStartTimeVar.Enabled = res;
			this.m_nudChirp2ADCStartTimeVar.Enabled = res;
			this.m_nudChirp3ADCStartTimeVar.Enabled = res;
			this.m_nudChirp4ADCStartTimeVar.Enabled = res;
			this.m_nudChirp5ADCStartTimeVar.Enabled = res;
			this.m_nudChirp6ADCStartTimeVar.Enabled = res;
			this.m_nudChirp7ADCStartTimeVar.Enabled = res;
			this.m_nudChirp8ADCStartTimeVar.Enabled = res;
			this.m_nudChirp9ADCStartTimeVar.Enabled = res;
			this.m_nudChirp10ADCStartTimeVar.Enabled = res;
			this.m_nudChirp11ADCStartTimeVar.Enabled = res;
			this.m_nudChirp12ADCStartTimeVar.Enabled = res;
			this.m_nudChirp13ADCStartTimeVar.Enabled = res;
			this.m_nudChirp14ADCStartTimeVar.Enabled = res;
			this.m_nudChirp15ADCStartTimeVar.Enabled = res;
			this.m_nudChirp16ADCStartTimeVar.Enabled = res;
			if (rowNo == 0)
			{
				res = !res;
			}
			this.m_nudChirp17IdleTimeVar.Enabled = res;
			this.m_nudChirp18IdleTimeVar.Enabled = res;
			this.m_nudChirp19IdleTimeVar.Enabled = res;
			this.m_nudChirp20IdleTimeVar.Enabled = res;
			this.m_nudChirp21IdleTimeVar.Enabled = res;
			this.m_nudChirp22IdleTimeVar.Enabled = res;
			this.m_nudChirp23IdleTimeVar.Enabled = res;
			this.m_nudChirp24IdleTimeVar.Enabled = res;
			this.m_nudChirp25IdleTimeVar.Enabled = res;
			this.m_nudChirp26IdleTimeVar.Enabled = res;
			this.m_nudChirp27IdleTimeVar.Enabled = res;
			this.m_nudChirp28IdleTimeVar.Enabled = res;
			this.m_nudChirp29IdleTimeVar.Enabled = res;
			this.m_nudChirp30IdleTimeVar.Enabled = res;
			this.m_nudChirp31IdleTimeVar.Enabled = res;
			this.m_nudChirp32IdleTimeVar.Enabled = res;
			this.m_nudChirp17ADCStartTimeVar.Enabled = res;
			this.m_nudChirp18ADCStartTimeVar.Enabled = res;
			this.m_nudChirp19ADCStartTimeVar.Enabled = res;
			this.m_nudChirp20ADCStartTimeVar.Enabled = res;
			this.m_nudChirp21ADCStartTimeVar.Enabled = res;
			this.m_nudChirp22ADCStartTimeVar.Enabled = res;
			this.m_nudChirp23ADCStartTimeVar.Enabled = res;
			this.m_nudChirp24ADCStartTimeVar.Enabled = res;
			this.m_nudChirp25ADCStartTimeVar.Enabled = res;
			this.m_nudChirp26ADCStartTimeVar.Enabled = res;
			this.m_nudChirp27ADCStartTimeVar.Enabled = res;
			this.m_nudChirp28ADCStartTimeVar.Enabled = res;
			this.m_nudChirp29ADCStartTimeVar.Enabled = res;
			this.m_nudChirp30ADCStartTimeVar.Enabled = res;
			this.m_nudChirp31ADCStartTimeVar.Enabled = res;
			this.m_nudChirp32ADCStartTimeVar.Enabled = res;
			if (this.m_nudChirpSegmentSelect.Value == 10m && rowNo != 0)
			{
				res = false;
			}
			this.m_nudChirp33IdleTimeVar.Enabled = res;
			this.m_nudChirp34IdleTimeVar.Enabled = res;
			this.m_nudChirp35IdleTimeVar.Enabled = res;
			this.m_nudChirp36IdleTimeVar.Enabled = res;
			this.m_nudChirp37IdleTimeVar.Enabled = res;
			this.m_nudChirp38IdleTimeVar.Enabled = res;
			this.m_nudChirp39IdleTimeVar.Enabled = res;
			this.m_nudChirp40IdleTimeVar.Enabled = res;
			this.m_nudChirp41IdleTimeVar.Enabled = res;
			this.m_nudChirp42IdleTimeVar.Enabled = res;
			this.m_nudChirp43IdleTimeVar.Enabled = res;
			this.m_nudChirp44IdleTimeVar.Enabled = res;
			this.m_nudChirp45IdleTimeVar.Enabled = res;
			this.m_nudChirp46IdleTimeVar.Enabled = res;
			this.m_nudChirp47IdleTimeVar.Enabled = res;
			this.m_nudChirp48IdleTimeVar.Enabled = res;
			this.m_nudChirp33ADCStartTimeVar.Enabled = res;
			this.m_nudChirp34ADCStartTimeVar.Enabled = res;
			this.m_nudChirp35ADCStartTimeVar.Enabled = res;
			this.m_nudChirp36ADCStartTimeVar.Enabled = res;
			this.m_nudChirp37ADCStartTimeVar.Enabled = res;
			this.m_nudChirp38ADCStartTimeVar.Enabled = res;
			this.m_nudChirp39ADCStartTimeVar.Enabled = res;
			this.m_nudChirp40ADCStartTimeVar.Enabled = res;
			this.m_nudChirp41ADCStartTimeVar.Enabled = res;
			this.m_nudChirp42ADCStartTimeVar.Enabled = res;
			this.m_nudChirp43ADCStartTimeVar.Enabled = res;
			this.m_nudChirp44ADCStartTimeVar.Enabled = res;
			this.m_nudChirp45ADCStartTimeVar.Enabled = res;
			this.m_nudChirp46ADCStartTimeVar.Enabled = res;
			this.m_nudChirp47ADCStartTimeVar.Enabled = res;
			this.m_nudChirp48ADCStartTimeVar.Enabled = res;
		}

		private void m_nudChirpRowSelect_ValueChanged(object sender, EventArgs p1)
		{
			if (this.m_nudChirpRowSelect.Value == 0m)
			{
				this.m_nudChirpSegmentSelect.Maximum = 31m;
				this.Row1(true, 0);
				this.Row2(true, 0);
				this.Row3(true, 0);
				return;
			}
			if (this.m_nudChirpRowSelect.Value == 1m)
			{
				this.m_nudChirpSegmentSelect.Maximum = 10m;
				this.Row1(true, 1);
				this.Row2(false, 1);
				this.Row3(false, 1);
				return;
			}
			if (this.m_nudChirpRowSelect.Value == 2m)
			{
				this.m_nudChirpSegmentSelect.Maximum = 10m;
				this.Row1(false, 2);
				this.Row2(true, 2);
				this.Row3(false, 2);
				return;
			}
			if (this.m_nudChirpRowSelect.Value == 3m)
			{
				this.m_nudChirpSegmentSelect.Maximum = 10m;
				this.Row1(false, 3);
				this.Row2(false, 3);
				this.Row3(true, 3);
			}
		}

		private void m_btnDynamicChirpConfigSet_Click_1(object sender, EventArgs p1)
		{
			this.iSetDynamicChirpConfigAsync();
		}

		private void m_nudChirpSegmentSelect_ValueChanged_1(object sender, EventArgs p1)
		{
			if (this.m_nudChirpRowSelect.Value == 0m)
			{
				this.m_nudChirpSegmentSelect.Maximum = 31m;
				this.Row1(true, 0);
				this.Row2(true, 0);
				this.Row3(true, 0);
				return;
			}
			if (this.m_nudChirpRowSelect.Value == 1m)
			{
				this.m_nudChirpSegmentSelect.Maximum = 10m;
				this.Row1(true, 1);
				this.Row2(false, 1);
				this.Row3(false, 1);
				return;
			}
			if (this.m_nudChirpRowSelect.Value == 2m)
			{
				this.m_nudChirpSegmentSelect.Maximum = 10m;
				this.Row1(false, 2);
				this.Row2(true, 2);
				this.Row3(false, 2);
				return;
			}
			if (this.m_nudChirpRowSelect.Value == 3m)
			{
				this.m_nudChirpSegmentSelect.Maximum = 10m;
				this.Row1(false, 3);
				this.Row2(false, 3);
				this.Row3(true, 3);
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
			this.groupBox2 = new GroupBox();
			this.label2 = new Label();
			this.m_btnDynamicPerChirpPhaseShifterConfigSet = new Button();
			this.m_nudChirp14Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp13Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp12Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp16Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp15Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp11Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp10Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp9Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp8Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp7Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp6Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp5Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp4Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp3Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp2Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp1Tx2PhaseShiftter = new NumericUpDown();
			this.m_nudChirp14Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp13Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp12Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp16Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp15Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp11Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp10Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp9Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp8Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp7Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp6Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp5Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp4Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp3Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp2Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp1Tx3PhaseShiftter = new NumericUpDown();
			this.m_nudChirp14Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp13Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp12Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp16Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp15Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp11Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp10Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp9Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp8Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp7Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp6Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp5Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp4Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp3Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp2Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudChirp1Tx1PhaseShiftter = new NumericUpDown();
			this.m_nudPerChirpSegmentSelect = new NumericUpDown();
			this.label52 = new Label();
			this.label54 = new Label();
			this.label55 = new Label();
			this.label24 = new Label();
			this.label40 = new Label();
			this.label41 = new Label();
			this.label42 = new Label();
			this.label43 = new Label();
			this.label44 = new Label();
			this.label45 = new Label();
			this.label46 = new Label();
			this.label47 = new Label();
			this.label38 = new Label();
			this.label39 = new Label();
			this.label22 = new Label();
			this.label37 = new Label();
			this.label19 = new Label();
			this.label21 = new Label();
			this.label1 = new Label();
			this.label15 = new Label();
			this.groupBox3 = new GroupBox();
			this.m_btnDynamicChirpEnableConfigSet = new Button();
			this.groupBox1 = new GroupBox();
			this.m_ChbProgramModeEnable = new CheckBox();
			this.m_nudChirpRowSelect = new NumericUpDown();
			this.label49 = new Label();
			this.label48 = new Label();
			this.m_btnDynamicChirpConfigSet = new Button();
			this.label20 = new Label();
			this.label17 = new Label();
			this.label18 = new Label();
			this.label16 = new Label();
			this.m_nudChirpSegmentSelect = new NumericUpDown();
			this.label13 = new Label();
			this.label14 = new Label();
			this.label11 = new Label();
			this.label12 = new Label();
			this.label9 = new Label();
			this.label10 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label4 = new Label();
			this.panel1 = new Panel();
			this.m_nudChirp48BPMConstVal = new NumericUpDown();
			this.m_ChbChirp48Tx3Enable = new CheckBox();
			this.m_ChbChirp48Tx2Enable = new CheckBox();
			this.m_ChbChirp48Tx1Enable = new CheckBox();
			this.m_nudChirp48FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp48ProfileIndex = new NumericUpDown();
			this.m_nudChirp48FreqStartVar = new NumericUpDown();
			this.m_nudChirp48ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp48IdleTimeVar = new NumericUpDown();
			this.m_nudChirp47BPMConstVal = new NumericUpDown();
			this.m_ChbChirp47Tx3Enable = new CheckBox();
			this.m_ChbChirp47Tx2Enable = new CheckBox();
			this.m_ChbChirp47Tx1Enable = new CheckBox();
			this.m_nudChirp47FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp47ProfileIndex = new NumericUpDown();
			this.m_nudChirp47FreqStartVar = new NumericUpDown();
			this.m_nudChirp47ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp47IdleTimeVar = new NumericUpDown();
			this.m_nudChirp46BPMConstVal = new NumericUpDown();
			this.m_ChbChirp46Tx3Enable = new CheckBox();
			this.m_ChbChirp46Tx2Enable = new CheckBox();
			this.m_ChbChirp46Tx1Enable = new CheckBox();
			this.m_nudChirp46FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp46ProfileIndex = new NumericUpDown();
			this.m_nudChirp46FreqStartVar = new NumericUpDown();
			this.m_nudChirp46ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp46IdleTimeVar = new NumericUpDown();
			this.m_nudChirp44BPMConstVal = new NumericUpDown();
			this.m_ChbChirp44Tx3Enable = new CheckBox();
			this.m_ChbChirp44Tx2Enable = new CheckBox();
			this.m_ChbChirp44Tx1Enable = new CheckBox();
			this.m_nudChirp44FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp44ProfileIndex = new NumericUpDown();
			this.m_nudChirp44FreqStartVar = new NumericUpDown();
			this.m_nudChirp44ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp44IdleTimeVar = new NumericUpDown();
			this.m_nudChirp45BPMConstVal = new NumericUpDown();
			this.m_ChbChirp45Tx3Enable = new CheckBox();
			this.m_ChbChirp45Tx2Enable = new CheckBox();
			this.m_ChbChirp45Tx1Enable = new CheckBox();
			this.m_nudChirp45FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp45ProfileIndex = new NumericUpDown();
			this.m_nudChirp45FreqStartVar = new NumericUpDown();
			this.m_nudChirp45ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp45IdleTimeVar = new NumericUpDown();
			this.m_nudChirp43BPMConstVal = new NumericUpDown();
			this.m_ChbChirp43Tx3Enable = new CheckBox();
			this.m_ChbChirp43Tx2Enable = new CheckBox();
			this.m_ChbChirp43Tx1Enable = new CheckBox();
			this.m_nudChirp43FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp43ProfileIndex = new NumericUpDown();
			this.m_nudChirp43FreqStartVar = new NumericUpDown();
			this.m_nudChirp43ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp43IdleTimeVar = new NumericUpDown();
			this.m_nudChirp42BPMConstVal = new NumericUpDown();
			this.m_ChbChirp42Tx3Enable = new CheckBox();
			this.m_ChbChirp42Tx2Enable = new CheckBox();
			this.m_ChbChirp42Tx1Enable = new CheckBox();
			this.m_nudChirp42FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp42ProfileIndex = new NumericUpDown();
			this.m_nudChirp42FreqStartVar = new NumericUpDown();
			this.m_nudChirp42ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp42IdleTimeVar = new NumericUpDown();
			this.m_nudChirp41BPMConstVal = new NumericUpDown();
			this.m_ChbChirp41Tx3Enable = new CheckBox();
			this.m_ChbChirp41Tx2Enable = new CheckBox();
			this.m_ChbChirp41Tx1Enable = new CheckBox();
			this.m_nudChirp41FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp41ProfileIndex = new NumericUpDown();
			this.m_nudChirp41FreqStartVar = new NumericUpDown();
			this.m_nudChirp41ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp41IdleTimeVar = new NumericUpDown();
			this.m_nudChirp40BPMConstVal = new NumericUpDown();
			this.m_ChbChirp40Tx3Enable = new CheckBox();
			this.m_ChbChirp40Tx2Enable = new CheckBox();
			this.m_ChbChirp40Tx1Enable = new CheckBox();
			this.m_nudChirp40FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp40ProfileIndex = new NumericUpDown();
			this.m_nudChirp40FreqStartVar = new NumericUpDown();
			this.m_nudChirp40ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp40IdleTimeVar = new NumericUpDown();
			this.label67 = new Label();
			this.label69 = new Label();
			this.label70 = new Label();
			this.label71 = new Label();
			this.label72 = new Label();
			this.label73 = new Label();
			this.label74 = new Label();
			this.label75 = new Label();
			this.label76 = new Label();
			this.m_nudChirp39BPMConstVal = new NumericUpDown();
			this.m_ChbChirp39Tx3Enable = new CheckBox();
			this.m_ChbChirp39Tx2Enable = new CheckBox();
			this.m_ChbChirp39Tx1Enable = new CheckBox();
			this.m_nudChirp39FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp39ProfileIndex = new NumericUpDown();
			this.m_nudChirp39FreqStartVar = new NumericUpDown();
			this.m_nudChirp39ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp39IdleTimeVar = new NumericUpDown();
			this.m_nudChirp37BPMConstVal = new NumericUpDown();
			this.m_ChbChirp37Tx3Enable = new CheckBox();
			this.m_ChbChirp37Tx2Enable = new CheckBox();
			this.m_ChbChirp37Tx1Enable = new CheckBox();
			this.m_nudChirp37FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp37ProfileIndex = new NumericUpDown();
			this.m_nudChirp37FreqStartVar = new NumericUpDown();
			this.m_nudChirp37ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp37IdleTimeVar = new NumericUpDown();
			this.m_nudChirp38BPMConstVal = new NumericUpDown();
			this.m_ChbChirp38Tx3Enable = new CheckBox();
			this.m_ChbChirp38Tx2Enable = new CheckBox();
			this.m_ChbChirp38Tx1Enable = new CheckBox();
			this.m_nudChirp38FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp38ProfileIndex = new NumericUpDown();
			this.m_nudChirp38FreqStartVar = new NumericUpDown();
			this.m_nudChirp38ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp38IdleTimeVar = new NumericUpDown();
			this.m_nudChirp36BPMConstVal = new NumericUpDown();
			this.m_ChbChirp36Tx3Enable = new CheckBox();
			this.m_ChbChirp36Tx2Enable = new CheckBox();
			this.m_ChbChirp36Tx1Enable = new CheckBox();
			this.m_nudChirp36FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp36ProfileIndex = new NumericUpDown();
			this.m_nudChirp36FreqStartVar = new NumericUpDown();
			this.m_nudChirp36ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp36IdleTimeVar = new NumericUpDown();
			this.m_nudChirp35BPMConstVal = new NumericUpDown();
			this.m_ChbChirp35Tx3Enable = new CheckBox();
			this.m_ChbChirp35Tx2Enable = new CheckBox();
			this.m_ChbChirp35Tx1Enable = new CheckBox();
			this.m_nudChirp35FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp35ProfileIndex = new NumericUpDown();
			this.m_nudChirp35FreqStartVar = new NumericUpDown();
			this.m_nudChirp35ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp35IdleTimeVar = new NumericUpDown();
			this.m_nudChirp34BPMConstVal = new NumericUpDown();
			this.m_ChbChirp34Tx3Enable = new CheckBox();
			this.m_ChbChirp34Tx2Enable = new CheckBox();
			this.m_ChbChirp34Tx1Enable = new CheckBox();
			this.m_nudChirp34FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp34ProfileIndex = new NumericUpDown();
			this.m_nudChirp34FreqStartVar = new NumericUpDown();
			this.m_nudChirp34ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp34IdleTimeVar = new NumericUpDown();
			this.m_nudChirp32BPMConstVal = new NumericUpDown();
			this.m_ChbChirp32Tx3Enable = new CheckBox();
			this.m_ChbChirp32Tx2Enable = new CheckBox();
			this.m_ChbChirp32Tx1Enable = new CheckBox();
			this.m_nudChirp32FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp32ProfileIndex = new NumericUpDown();
			this.m_nudChirp32FreqStartVar = new NumericUpDown();
			this.m_nudChirp32ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp32IdleTimeVar = new NumericUpDown();
			this.m_nudChirp33BPMConstVal = new NumericUpDown();
			this.m_ChbChirp33Tx3Enable = new CheckBox();
			this.m_ChbChirp33Tx2Enable = new CheckBox();
			this.m_ChbChirp33Tx1Enable = new CheckBox();
			this.m_nudChirp33FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp33ProfileIndex = new NumericUpDown();
			this.m_nudChirp33FreqStartVar = new NumericUpDown();
			this.m_nudChirp33ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp33IdleTimeVar = new NumericUpDown();
			this.m_nudChirp31BPMConstVal = new NumericUpDown();
			this.m_ChbChirp31Tx3Enable = new CheckBox();
			this.m_ChbChirp31Tx2Enable = new CheckBox();
			this.m_ChbChirp31Tx1Enable = new CheckBox();
			this.m_nudChirp31FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp31ProfileIndex = new NumericUpDown();
			this.m_nudChirp31FreqStartVar = new NumericUpDown();
			this.m_nudChirp31ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp31IdleTimeVar = new NumericUpDown();
			this.m_nudChirp30BPMConstVal = new NumericUpDown();
			this.m_ChbChirp30Tx3Enable = new CheckBox();
			this.m_ChbChirp30Tx2Enable = new CheckBox();
			this.m_ChbChirp30Tx1Enable = new CheckBox();
			this.m_nudChirp30FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp30ProfileIndex = new NumericUpDown();
			this.m_nudChirp30FreqStartVar = new NumericUpDown();
			this.m_nudChirp30ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp30IdleTimeVar = new NumericUpDown();
			this.m_nudChirp29BPMConstVal = new NumericUpDown();
			this.m_ChbChirp29Tx3Enable = new CheckBox();
			this.m_ChbChirp29Tx2Enable = new CheckBox();
			this.m_ChbChirp29Tx1Enable = new CheckBox();
			this.m_nudChirp29FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp29ProfileIndex = new NumericUpDown();
			this.m_nudChirp29FreqStartVar = new NumericUpDown();
			this.m_nudChirp29ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp29IdleTimeVar = new NumericUpDown();
			this.label77 = new Label();
			this.label78 = new Label();
			this.label79 = new Label();
			this.label80 = new Label();
			this.label81 = new Label();
			this.label82 = new Label();
			this.label83 = new Label();
			this.label84 = new Label();
			this.label85 = new Label();
			this.label86 = new Label();
			this.label87 = new Label();
			this.m_nudChirp28BPMConstVal = new NumericUpDown();
			this.m_ChbChirp28Tx3Enable = new CheckBox();
			this.m_ChbChirp28Tx2Enable = new CheckBox();
			this.m_ChbChirp28Tx1Enable = new CheckBox();
			this.m_nudChirp28FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp28ProfileIndex = new NumericUpDown();
			this.m_nudChirp28FreqStartVar = new NumericUpDown();
			this.m_nudChirp28ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp28IdleTimeVar = new NumericUpDown();
			this.m_nudChirp26BPMConstVal = new NumericUpDown();
			this.m_ChbChirp26Tx3Enable = new CheckBox();
			this.m_ChbChirp26Tx2Enable = new CheckBox();
			this.m_ChbChirp26Tx1Enable = new CheckBox();
			this.m_nudChirp26FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp26ProfileIndex = new NumericUpDown();
			this.m_nudChirp26FreqStartVar = new NumericUpDown();
			this.m_nudChirp26ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp26IdleTimeVar = new NumericUpDown();
			this.m_nudChirp27BPMConstVal = new NumericUpDown();
			this.m_ChbChirp27Tx3Enable = new CheckBox();
			this.m_ChbChirp27Tx2Enable = new CheckBox();
			this.m_ChbChirp27Tx1Enable = new CheckBox();
			this.m_nudChirp27FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp27ProfileIndex = new NumericUpDown();
			this.m_nudChirp27FreqStartVar = new NumericUpDown();
			this.m_nudChirp27ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp27IdleTimeVar = new NumericUpDown();
			this.m_nudChirp25BPMConstVal = new NumericUpDown();
			this.m_ChbChirp25Tx3Enable = new CheckBox();
			this.m_ChbChirp25Tx2Enable = new CheckBox();
			this.m_ChbChirp25Tx1Enable = new CheckBox();
			this.m_nudChirp25FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp25ProfileIndex = new NumericUpDown();
			this.m_nudChirp25FreqStartVar = new NumericUpDown();
			this.m_nudChirp25ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp25IdleTimeVar = new NumericUpDown();
			this.m_nudChirp24BPMConstVal = new NumericUpDown();
			this.m_ChbChirp24Tx3Enable = new CheckBox();
			this.m_ChbChirp24Tx2Enable = new CheckBox();
			this.m_ChbChirp24Tx1Enable = new CheckBox();
			this.m_nudChirp24FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp24ProfileIndex = new NumericUpDown();
			this.m_nudChirp24FreqStartVar = new NumericUpDown();
			this.m_nudChirp24ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp24IdleTimeVar = new NumericUpDown();
			this.m_nudChirp23BPMConstVal = new NumericUpDown();
			this.m_ChbChirp23Tx3Enable = new CheckBox();
			this.m_ChbChirp23Tx2Enable = new CheckBox();
			this.m_ChbChirp23Tx1Enable = new CheckBox();
			this.m_nudChirp23FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp23ProfileIndex = new NumericUpDown();
			this.m_nudChirp23FreqStartVar = new NumericUpDown();
			this.m_nudChirp23ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp23IdleTimeVar = new NumericUpDown();
			this.m_nudChirp21BPMConstVal = new NumericUpDown();
			this.m_ChbChirp21Tx3Enable = new CheckBox();
			this.m_ChbChirp21Tx2Enable = new CheckBox();
			this.m_ChbChirp21Tx1Enable = new CheckBox();
			this.m_nudChirp21FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp21ProfileIndex = new NumericUpDown();
			this.m_nudChirp21FreqStartVar = new NumericUpDown();
			this.m_nudChirp21ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp21IdleTimeVar = new NumericUpDown();
			this.m_nudChirp22BPMConstVal = new NumericUpDown();
			this.m_ChbChirp22Tx3Enable = new CheckBox();
			this.m_ChbChirp22Tx2Enable = new CheckBox();
			this.m_ChbChirp22Tx1Enable = new CheckBox();
			this.m_nudChirp22FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp22ProfileIndex = new NumericUpDown();
			this.m_nudChirp22FreqStartVar = new NumericUpDown();
			this.m_nudChirp22ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp22IdleTimeVar = new NumericUpDown();
			this.m_nudChirp20BPMConstVal = new NumericUpDown();
			this.m_ChbChirp20Tx3Enable = new CheckBox();
			this.m_ChbChirp20Tx2Enable = new CheckBox();
			this.m_ChbChirp20Tx1Enable = new CheckBox();
			this.m_nudChirp20FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp20ProfileIndex = new NumericUpDown();
			this.m_nudChirp20FreqStartVar = new NumericUpDown();
			this.m_nudChirp20ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp20IdleTimeVar = new NumericUpDown();
			this.m_nudChirp19BPMConstVal = new NumericUpDown();
			this.m_ChbChirp19Tx3Enable = new CheckBox();
			this.m_ChbChirp19Tx2Enable = new CheckBox();
			this.m_ChbChirp19Tx1Enable = new CheckBox();
			this.m_nudChirp19FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp19ProfileIndex = new NumericUpDown();
			this.m_nudChirp19FreqStartVar = new NumericUpDown();
			this.m_nudChirp19ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp19IdleTimeVar = new NumericUpDown();
			this.m_nudChirp18BPMConstVal = new NumericUpDown();
			this.m_ChbChirp18Tx3Enable = new CheckBox();
			this.m_ChbChirp18Tx2Enable = new CheckBox();
			this.m_ChbChirp18Tx1Enable = new CheckBox();
			this.m_nudChirp18FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp18ProfileIndex = new NumericUpDown();
			this.m_nudChirp18FreqStartVar = new NumericUpDown();
			this.m_nudChirp18ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp18IdleTimeVar = new NumericUpDown();
			this.m_nudChirp17BPMConstVal = new NumericUpDown();
			this.m_ChbChirp17Tx3Enable = new CheckBox();
			this.m_ChbChirp17Tx2Enable = new CheckBox();
			this.m_ChbChirp17Tx1Enable = new CheckBox();
			this.m_nudChirp17FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp17ProfileIndex = new NumericUpDown();
			this.m_nudChirp17FreqStartVar = new NumericUpDown();
			this.m_nudChirp17ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp17IdleTimeVar = new NumericUpDown();
			this.label50 = new Label();
			this.label51 = new Label();
			this.label53 = new Label();
			this.label56 = new Label();
			this.label57 = new Label();
			this.label58 = new Label();
			this.label59 = new Label();
			this.label60 = new Label();
			this.label61 = new Label();
			this.label62 = new Label();
			this.label63 = new Label();
			this.label64 = new Label();
			this.m_nudChirp16BPMConstVal = new NumericUpDown();
			this.m_ChbChirp16Tx3Enable = new CheckBox();
			this.m_ChbChirp16Tx2Enable = new CheckBox();
			this.m_ChbChirp16Tx1Enable = new CheckBox();
			this.m_nudChirp16FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp16ProfileIndex = new NumericUpDown();
			this.m_nudChirp16FreqStartVar = new NumericUpDown();
			this.m_nudChirp16ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp16IdleTimeVar = new NumericUpDown();
			this.m_nudChirp14BPMConstVal = new NumericUpDown();
			this.m_ChbChirp14Tx3Enable = new CheckBox();
			this.m_ChbChirp14Tx2Enable = new CheckBox();
			this.m_ChbChirp14Tx1Enable = new CheckBox();
			this.m_nudChirp14FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp14ProfileIndex = new NumericUpDown();
			this.m_nudChirp14FreqStartVar = new NumericUpDown();
			this.m_nudChirp14ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp14IdleTimeVar = new NumericUpDown();
			this.m_nudChirp15BPMConstVal = new NumericUpDown();
			this.m_ChbChirp15Tx3Enable = new CheckBox();
			this.m_ChbChirp15Tx2Enable = new CheckBox();
			this.m_ChbChirp15Tx1Enable = new CheckBox();
			this.m_nudChirp15FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp15ProfileIndex = new NumericUpDown();
			this.m_nudChirp15FreqStartVar = new NumericUpDown();
			this.m_nudChirp15ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp15IdleTimeVar = new NumericUpDown();
			this.m_nudChirp13BPMConstVal = new NumericUpDown();
			this.m_ChbChirp13Tx3Enable = new CheckBox();
			this.m_ChbChirp13Tx2Enable = new CheckBox();
			this.m_ChbChirp13Tx1Enable = new CheckBox();
			this.m_nudChirp13FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp13ProfileIndex = new NumericUpDown();
			this.m_nudChirp13FreqStartVar = new NumericUpDown();
			this.m_nudChirp13ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp13IdleTimeVar = new NumericUpDown();
			this.m_nudChirp12BPMConstVal = new NumericUpDown();
			this.m_ChbChirp12Tx3Enable = new CheckBox();
			this.m_ChbChirp12Tx2Enable = new CheckBox();
			this.m_ChbChirp12Tx1Enable = new CheckBox();
			this.m_nudChirp12FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp12ProfileIndex = new NumericUpDown();
			this.m_nudChirp12FreqStartVar = new NumericUpDown();
			this.m_nudChirp12ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp12IdleTimeVar = new NumericUpDown();
			this.m_nudChirp11BPMConstVal = new NumericUpDown();
			this.m_ChbChirp11Tx3Enable = new CheckBox();
			this.m_ChbChirp11Tx2Enable = new CheckBox();
			this.m_ChbChirp11Tx1Enable = new CheckBox();
			this.m_nudChirp11FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp11ProfileIndex = new NumericUpDown();
			this.m_nudChirp11FreqStartVar = new NumericUpDown();
			this.m_nudChirp11ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp11IdleTimeVar = new NumericUpDown();
			this.m_nudChirp9BPMConstVal = new NumericUpDown();
			this.m_ChbChirp9Tx3Enable = new CheckBox();
			this.m_ChbChirp9Tx2Enable = new CheckBox();
			this.m_ChbChirp9Tx1Enable = new CheckBox();
			this.m_nudChirp9FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp9ProfileIndex = new NumericUpDown();
			this.m_nudChirp9FreqStartVar = new NumericUpDown();
			this.m_nudChirp9ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp9IdleTimeVar = new NumericUpDown();
			this.m_nudChirp10BPMConstVal = new NumericUpDown();
			this.m_ChbChirp10Tx3Enable = new CheckBox();
			this.m_ChbChirp10Tx2Enable = new CheckBox();
			this.m_ChbChirp10Tx1Enable = new CheckBox();
			this.m_nudChirp10FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp10ProfileIndex = new NumericUpDown();
			this.m_nudChirp10FreqStartVar = new NumericUpDown();
			this.m_nudChirp10ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp10IdleTimeVar = new NumericUpDown();
			this.m_nudChirp8BPMConstVal = new NumericUpDown();
			this.m_ChbChirp8Tx3Enable = new CheckBox();
			this.m_ChbChirp8Tx2Enable = new CheckBox();
			this.m_ChbChirp8Tx1Enable = new CheckBox();
			this.m_nudChirp8FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp8ProfileIndex = new NumericUpDown();
			this.m_nudChirp8FreqStartVar = new NumericUpDown();
			this.m_nudChirp8ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp8IdleTimeVar = new NumericUpDown();
			this.m_nudChirp7BPMConstVal = new NumericUpDown();
			this.m_ChbChirp7Tx3Enable = new CheckBox();
			this.m_ChbChirp7Tx2Enable = new CheckBox();
			this.m_ChbChirp7Tx1Enable = new CheckBox();
			this.m_nudChirp7FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp7ProfileIndex = new NumericUpDown();
			this.m_nudChirp7FreqStartVar = new NumericUpDown();
			this.m_nudChirp7ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp7IdleTimeVar = new NumericUpDown();
			this.m_nudChirp6BPMConstVal = new NumericUpDown();
			this.m_ChbChirp6Tx3Enable = new CheckBox();
			this.m_ChbChirp6Tx2Enable = new CheckBox();
			this.m_ChbChirp6Tx1Enable = new CheckBox();
			this.m_nudChirp6FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp6ProfileIndex = new NumericUpDown();
			this.m_nudChirp6FreqStartVar = new NumericUpDown();
			this.m_nudChirp6ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp6IdleTimeVar = new NumericUpDown();
			this.m_nudChirp4BPMConstVal = new NumericUpDown();
			this.m_ChbChirp4Tx3Enable = new CheckBox();
			this.m_ChbChirp4Tx2Enable = new CheckBox();
			this.m_ChbChirp4Tx1Enable = new CheckBox();
			this.m_nudChirp4FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp4ProfileIndex = new NumericUpDown();
			this.m_nudChirp4FreqStartVar = new NumericUpDown();
			this.m_nudChirp4ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp4IdleTimeVar = new NumericUpDown();
			this.m_nudChirp5BPMConstVal = new NumericUpDown();
			this.m_ChbChirp5Tx3Enable = new CheckBox();
			this.m_ChbChirp5Tx2Enable = new CheckBox();
			this.m_ChbChirp5Tx1Enable = new CheckBox();
			this.m_nudChirp5FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp5ProfileIndex = new NumericUpDown();
			this.m_nudChirp5FreqStartVar = new NumericUpDown();
			this.m_nudChirp5ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp5IdleTimeVar = new NumericUpDown();
			this.m_nudChirp3BPMConstVal = new NumericUpDown();
			this.m_ChbChirp3Tx3Enable = new CheckBox();
			this.m_ChbChirp3Tx2Enable = new CheckBox();
			this.m_ChbChirp3Tx1Enable = new CheckBox();
			this.m_nudChirp3FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp3ProfileIndex = new NumericUpDown();
			this.m_nudChirp3FreqStartVar = new NumericUpDown();
			this.m_nudChirp3ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp3IdleTimeVar = new NumericUpDown();
			this.m_nudChirp2BPMConstVal = new NumericUpDown();
			this.m_ChbChirp2Tx3Enable = new CheckBox();
			this.m_ChbChirp2Tx2Enable = new CheckBox();
			this.m_ChbChirp2Tx1Enable = new CheckBox();
			this.m_nudChirp2FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp2ProfileIndex = new NumericUpDown();
			this.m_nudChirp2FreqStartVar = new NumericUpDown();
			this.m_nudChirp2ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp2IdleTimeVar = new NumericUpDown();
			this.label35 = new Label();
			this.label36 = new Label();
			this.label33 = new Label();
			this.label34 = new Label();
			this.label31 = new Label();
			this.label32 = new Label();
			this.m_nudChirp1BPMConstVal = new NumericUpDown();
			this.label29 = new Label();
			this.label30 = new Label();
			this.label27 = new Label();
			this.label28 = new Label();
			this.label25 = new Label();
			this.label26 = new Label();
			this.label23 = new Label();
			this.m_ChbChirp1Tx3Enable = new CheckBox();
			this.m_ChbChirp1Tx2Enable = new CheckBox();
			this.m_ChbChirp1Tx1Enable = new CheckBox();
			this.m_nudChirp1FreqSlopeVar = new NumericUpDown();
			this.m_nudChirp1ProfileIndex = new NumericUpDown();
			this.m_nudChirp1FreqStartVar = new NumericUpDown();
			this.m_nudChirp1ADCStartTimeVar = new NumericUpDown();
			this.m_nudChirp1IdleTimeVar = new NumericUpDown();
			this.label7 = new Label();
			this.label8 = new Label();
			this.label3 = new Label();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.m_nudChirp14Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp13Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp12Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp16Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp15Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp11Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp10Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp9Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp8Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp7Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp6Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp5Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp4Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp3Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp2Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp1Tx2PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp14Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp13Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp12Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp16Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp15Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp11Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp10Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp9Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp8Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp7Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp6Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp5Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp4Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp3Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp2Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp1Tx3PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp14Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp13Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp12Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp16Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp15Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp11Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp10Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp9Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp8Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp7Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp6Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp5Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp4Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp3Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp2Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudChirp1Tx1PhaseShiftter).BeginInit();
			((ISupportInitialize)this.m_nudPerChirpSegmentSelect).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.m_nudChirpRowSelect).BeginInit();
			((ISupportInitialize)this.m_nudChirpSegmentSelect).BeginInit();
			this.panel1.SuspendLayout();
			((ISupportInitialize)this.m_nudChirp48BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp48FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp48ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp48FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp48ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp48IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp47BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp47FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp47ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp47FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp47ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp47IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp46BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp46FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp46ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp46FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp46ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp46IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp44BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp44FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp44ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp44FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp44ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp44IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp45BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp45FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp45ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp45FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp45ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp45IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp43BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp43FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp43ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp43FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp43ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp43IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp42BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp42FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp42ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp42FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp42ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp42IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp41BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp41FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp41ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp41FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp41ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp41IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp40BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp40FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp40ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp40FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp40ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp40IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp39BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp39FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp39ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp39FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp39ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp39IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp37BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp37FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp37ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp37FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp37ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp37IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp38BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp38FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp38ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp38FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp38ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp38IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp36BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp36FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp36ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp36FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp36ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp36IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp35BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp35FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp35ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp35FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp35ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp35IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp34BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp34FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp34ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp34FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp34ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp34IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp32BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp32FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp32ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp32FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp32ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp32IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp33BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp33FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp33ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp33FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp33ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp33IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp31BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp31FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp31ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp31FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp31ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp31IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp30BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp30FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp30ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp30FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp30ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp30IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp29BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp29FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp29ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp29FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp29ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp29IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp28BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp28FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp28ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp28FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp28ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp28IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp26BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp26FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp26ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp26FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp26ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp26IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp27BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp27FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp27ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp27FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp27ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp27IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp25BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp25FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp25ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp25FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp25ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp25IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp24BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp24FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp24ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp24FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp24ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp24IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp23BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp23FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp23ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp23FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp23ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp23IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp21BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp21FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp21ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp21FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp21ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp21IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp22BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp22FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp22ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp22FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp22ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp22IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp20BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp20FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp20ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp20FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp20ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp20IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp19BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp19FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp19ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp19FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp19ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp19IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp18BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp18FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp18ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp18FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp18ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp18IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp17BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp17FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp17ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp17FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp17ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp17IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp16BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp16FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp16ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp16FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp16ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp16IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp14BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp14FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp14ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp14FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp14ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp14IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp15BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp15FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp15ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp15FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp15ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp15IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp13BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp13FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp13ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp13FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp13ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp13IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp12BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp12FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp12ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp12FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp12ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp12IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp11BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp11FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp11ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp11FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp11ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp11IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp9BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp9FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp9ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp9FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp9ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp9IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp10BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp10FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp10ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp10FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp10ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp10IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp8BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp8FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp8ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp8FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp8ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp8IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp7BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp7FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp7ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp7FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp7ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp7IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp6BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp6FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp6ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp6FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp6ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp6IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp4BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp4FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp4ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp4FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp4ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp4IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp5BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp5FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp5ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp5FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp5ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp5IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp3BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp3FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp3ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp3FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp3ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp3IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp2BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp2FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp2ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp2FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp2ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp2IdleTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp1BPMConstVal).BeginInit();
			((ISupportInitialize)this.m_nudChirp1FreqSlopeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp1ProfileIndex).BeginInit();
			((ISupportInitialize)this.m_nudChirp1FreqStartVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp1ADCStartTimeVar).BeginInit();
			((ISupportInitialize)this.m_nudChirp1IdleTimeVar).BeginInit();
			base.SuspendLayout();
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.m_btnDynamicPerChirpPhaseShifterConfigSet);
			this.groupBox2.Controls.Add(this.m_nudChirp14Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp13Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp12Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp16Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp15Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp11Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp10Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp9Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp8Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp7Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp6Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp5Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp4Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp3Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp2Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp1Tx2PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp14Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp13Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp12Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp16Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp15Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp11Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp10Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp9Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp8Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp7Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp6Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp5Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp4Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp3Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp2Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp1Tx3PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp14Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp13Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp12Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp16Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp15Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp11Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp10Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp9Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp8Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp7Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp6Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp5Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp4Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp3Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp2Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudChirp1Tx1PhaseShiftter);
			this.groupBox2.Controls.Add(this.m_nudPerChirpSegmentSelect);
			this.groupBox2.Controls.Add(this.label52);
			this.groupBox2.Controls.Add(this.label54);
			this.groupBox2.Controls.Add(this.label55);
			this.groupBox2.Controls.Add(this.label24);
			this.groupBox2.Controls.Add(this.label40);
			this.groupBox2.Controls.Add(this.label41);
			this.groupBox2.Controls.Add(this.label42);
			this.groupBox2.Controls.Add(this.label43);
			this.groupBox2.Controls.Add(this.label44);
			this.groupBox2.Controls.Add(this.label45);
			this.groupBox2.Controls.Add(this.label46);
			this.groupBox2.Controls.Add(this.label47);
			this.groupBox2.Controls.Add(this.label38);
			this.groupBox2.Controls.Add(this.label39);
			this.groupBox2.Controls.Add(this.label22);
			this.groupBox2.Controls.Add(this.label37);
			this.groupBox2.Controls.Add(this.label19);
			this.groupBox2.Controls.Add(this.label21);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Location = new Point(925, 0);
			this.groupBox2.Margin = new Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new Padding(4);
			this.groupBox2.Size = new Size(581, 625);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Dynamic Per Chirp Phase shifter Configuration";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(297, 21);
			this.label2.Margin = new Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(126, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "1 LSB = 5.625 deg";
			this.m_btnDynamicPerChirpPhaseShifterConfigSet.Location = new Point(436, 586);
			this.m_btnDynamicPerChirpPhaseShifterConfigSet.Margin = new Padding(4);
			this.m_btnDynamicPerChirpPhaseShifterConfigSet.Name = "m_btnDynamicPerChirpPhaseShifterConfigSet";
			this.m_btnDynamicPerChirpPhaseShifterConfigSet.Size = new Size(100, 28);
			this.m_btnDynamicPerChirpPhaseShifterConfigSet.TabIndex = 78;
			this.m_btnDynamicPerChirpPhaseShifterConfigSet.Text = "Set";
			this.m_btnDynamicPerChirpPhaseShifterConfigSet.UseVisualStyleBackColor = true;
			this.m_btnDynamicPerChirpPhaseShifterConfigSet.Click += this.m_btnDynamicPerChirpPhaseShifterConfigSet_Click;
			this.m_nudChirp14Tx2PhaseShiftter.Location = new Point(301, 491);
			this.m_nudChirp14Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array = new int[4];
			array[0] = 63;
            this.m_nudChirp14Tx2PhaseShiftter.Maximum = new decimal(array);
			this.m_nudChirp14Tx2PhaseShiftter.Name = "m_nudChirp14Tx2PhaseShiftter";
			this.m_nudChirp14Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp14Tx2PhaseShiftter.TabIndex = 77;
			this.m_nudChirp13Tx2PhaseShiftter.Location = new Point(301, 458);
			this.m_nudChirp13Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array2 = new int[4];
			array2[0] = 63;
            this.m_nudChirp13Tx2PhaseShiftter.Maximum = new decimal(array2);
			this.m_nudChirp13Tx2PhaseShiftter.Name = "m_nudChirp13Tx2PhaseShiftter";
			this.m_nudChirp13Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp13Tx2PhaseShiftter.TabIndex = 76;
			this.m_nudChirp12Tx2PhaseShiftter.Location = new Point(301, 426);
			this.m_nudChirp12Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array3 = new int[4];
			array3[0] = 63;
            this.m_nudChirp12Tx2PhaseShiftter.Maximum = new decimal(array3);
			this.m_nudChirp12Tx2PhaseShiftter.Name = "m_nudChirp12Tx2PhaseShiftter";
			this.m_nudChirp12Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp12Tx2PhaseShiftter.TabIndex = 75;
			this.m_nudChirp16Tx2PhaseShiftter.Location = new Point(301, 556);
			this.m_nudChirp16Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array4 = new int[4];
			array4[0] = 63;
            this.m_nudChirp16Tx2PhaseShiftter.Maximum = new decimal(array4);
			this.m_nudChirp16Tx2PhaseShiftter.Name = "m_nudChirp16Tx2PhaseShiftter";
			this.m_nudChirp16Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp16Tx2PhaseShiftter.TabIndex = 63;
			this.m_nudChirp15Tx2PhaseShiftter.Location = new Point(301, 523);
			this.m_nudChirp15Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array5 = new int[4];
			array5[0] = 63;
            this.m_nudChirp15Tx2PhaseShiftter.Maximum = new decimal(array5);
			this.m_nudChirp15Tx2PhaseShiftter.Name = "m_nudChirp15Tx2PhaseShiftter";
			this.m_nudChirp15Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp15Tx2PhaseShiftter.TabIndex = 62;
			this.m_nudChirp11Tx2PhaseShiftter.Location = new Point(301, 393);
			this.m_nudChirp11Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array6 = new int[4];
			array6[0] = 63;
            this.m_nudChirp11Tx2PhaseShiftter.Maximum = new decimal(array6);
			this.m_nudChirp11Tx2PhaseShiftter.Name = "m_nudChirp11Tx2PhaseShiftter";
			this.m_nudChirp11Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp11Tx2PhaseShiftter.TabIndex = 74;
			this.m_nudChirp10Tx2PhaseShiftter.Location = new Point(301, 361);
			this.m_nudChirp10Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array7 = new int[4];
			array7[0] = 63;
            this.m_nudChirp10Tx2PhaseShiftter.Maximum = new decimal(array7);
			this.m_nudChirp10Tx2PhaseShiftter.Name = "m_nudChirp10Tx2PhaseShiftter";
			this.m_nudChirp10Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp10Tx2PhaseShiftter.TabIndex = 73;
			this.m_nudChirp9Tx2PhaseShiftter.Location = new Point(301, 327);
			this.m_nudChirp9Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array8 = new int[4];
			array8[0] = 63;
            this.m_nudChirp9Tx2PhaseShiftter.Maximum = new decimal(array8);
			this.m_nudChirp9Tx2PhaseShiftter.Name = "m_nudChirp9Tx2PhaseShiftter";
			this.m_nudChirp9Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp9Tx2PhaseShiftter.TabIndex = 72;
			this.m_nudChirp8Tx2PhaseShiftter.Location = new Point(301, 297);
			this.m_nudChirp8Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array9 = new int[4];
			array9[0] = 63;
            this.m_nudChirp8Tx2PhaseShiftter.Maximum = new decimal(array9);
			this.m_nudChirp8Tx2PhaseShiftter.Name = "m_nudChirp8Tx2PhaseShiftter";
			this.m_nudChirp8Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp8Tx2PhaseShiftter.TabIndex = 71;
			this.m_nudChirp7Tx2PhaseShiftter.Location = new Point(301, 268);
			this.m_nudChirp7Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array10 = new int[4];
			array10[0] = 63;
            this.m_nudChirp7Tx2PhaseShiftter.Maximum = new decimal(array10);
			this.m_nudChirp7Tx2PhaseShiftter.Name = "m_nudChirp7Tx2PhaseShiftter";
			this.m_nudChirp7Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp7Tx2PhaseShiftter.TabIndex = 70;
			this.m_nudChirp6Tx2PhaseShiftter.Location = new Point(301, 235);
			this.m_nudChirp6Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array11 = new int[4];
			array11[0] = 63;
            this.m_nudChirp6Tx2PhaseShiftter.Maximum = new decimal(array11);
			this.m_nudChirp6Tx2PhaseShiftter.Name = "m_nudChirp6Tx2PhaseShiftter";
			this.m_nudChirp6Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp6Tx2PhaseShiftter.TabIndex = 69;
			this.m_nudChirp5Tx2PhaseShiftter.Location = new Point(301, 203);
			this.m_nudChirp5Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array12 = new int[4];
			array12[0] = 63;
            this.m_nudChirp5Tx2PhaseShiftter.Maximum = new decimal(array12);
			this.m_nudChirp5Tx2PhaseShiftter.Name = "m_nudChirp5Tx2PhaseShiftter";
			this.m_nudChirp5Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp5Tx2PhaseShiftter.TabIndex = 68;
			this.m_nudChirp4Tx2PhaseShiftter.Location = new Point(301, 170);
			this.m_nudChirp4Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array13 = new int[4];
			array13[0] = 63;
            this.m_nudChirp4Tx2PhaseShiftter.Maximum = new decimal(array13);
			this.m_nudChirp4Tx2PhaseShiftter.Name = "m_nudChirp4Tx2PhaseShiftter";
			this.m_nudChirp4Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp4Tx2PhaseShiftter.TabIndex = 67;
			this.m_nudChirp3Tx2PhaseShiftter.Location = new Point(301, 138);
			this.m_nudChirp3Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array14 = new int[4];
			array14[0] = 63;
            this.m_nudChirp3Tx2PhaseShiftter.Maximum = new decimal(array14);
			this.m_nudChirp3Tx2PhaseShiftter.Name = "m_nudChirp3Tx2PhaseShiftter";
			this.m_nudChirp3Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp3Tx2PhaseShiftter.TabIndex = 66;
			this.m_nudChirp2Tx2PhaseShiftter.Location = new Point(301, 105);
			this.m_nudChirp2Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array15 = new int[4];
			array15[0] = 63;
            this.m_nudChirp2Tx2PhaseShiftter.Maximum = new decimal(array15);
			this.m_nudChirp2Tx2PhaseShiftter.Name = "m_nudChirp2Tx2PhaseShiftter";
			this.m_nudChirp2Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp2Tx2PhaseShiftter.TabIndex = 65;
			this.m_nudChirp1Tx2PhaseShiftter.Location = new Point(301, 74);
			this.m_nudChirp1Tx2PhaseShiftter.Margin = new Padding(4);
			int[] array16 = new int[4];
			array16[0] = 63;
            this.m_nudChirp1Tx2PhaseShiftter.Maximum = new decimal(array16);
			this.m_nudChirp1Tx2PhaseShiftter.Name = "m_nudChirp1Tx2PhaseShiftter";
			this.m_nudChirp1Tx2PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp1Tx2PhaseShiftter.TabIndex = 64;
			this.m_nudChirp14Tx3PhaseShiftter.Location = new Point(433, 489);
			this.m_nudChirp14Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array17 = new int[4];
			array17[0] = 63;
            this.m_nudChirp14Tx3PhaseShiftter.Maximum = new decimal(array17);
			this.m_nudChirp14Tx3PhaseShiftter.Name = "m_nudChirp14Tx3PhaseShiftter";
			this.m_nudChirp14Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp14Tx3PhaseShiftter.TabIndex = 61;
			this.m_nudChirp13Tx3PhaseShiftter.Location = new Point(433, 455);
			this.m_nudChirp13Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array18 = new int[4];
			array18[0] = 63;
            this.m_nudChirp13Tx3PhaseShiftter.Maximum = new decimal(array18);
			this.m_nudChirp13Tx3PhaseShiftter.Name = "m_nudChirp13Tx3PhaseShiftter";
			this.m_nudChirp13Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp13Tx3PhaseShiftter.TabIndex = 60;
			this.m_nudChirp12Tx3PhaseShiftter.Location = new Point(433, 423);
			this.m_nudChirp12Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array19 = new int[4];
			array19[0] = 63;
            this.m_nudChirp12Tx3PhaseShiftter.Maximum = new decimal(array19);
			this.m_nudChirp12Tx3PhaseShiftter.Name = "m_nudChirp12Tx3PhaseShiftter";
			this.m_nudChirp12Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp12Tx3PhaseShiftter.TabIndex = 59;
			this.m_nudChirp16Tx3PhaseShiftter.Location = new Point(433, 554);
			this.m_nudChirp16Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array20 = new int[4];
			array20[0] = 63;
            this.m_nudChirp16Tx3PhaseShiftter.Maximum = new decimal(array20);
			this.m_nudChirp16Tx3PhaseShiftter.Name = "m_nudChirp16Tx3PhaseShiftter";
			this.m_nudChirp16Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp16Tx3PhaseShiftter.TabIndex = 47;
			this.m_nudChirp15Tx3PhaseShiftter.Location = new Point(433, 521);
			this.m_nudChirp15Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array21 = new int[4];
			array21[0] = 63;
            this.m_nudChirp15Tx3PhaseShiftter.Maximum = new decimal(array21);
			this.m_nudChirp15Tx3PhaseShiftter.Name = "m_nudChirp15Tx3PhaseShiftter";
			this.m_nudChirp15Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp15Tx3PhaseShiftter.TabIndex = 46;
			this.m_nudChirp11Tx3PhaseShiftter.Location = new Point(433, 390);
			this.m_nudChirp11Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array22 = new int[4];
			array22[0] = 63;
            this.m_nudChirp11Tx3PhaseShiftter.Maximum = new decimal(array22);
			this.m_nudChirp11Tx3PhaseShiftter.Name = "m_nudChirp11Tx3PhaseShiftter";
			this.m_nudChirp11Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp11Tx3PhaseShiftter.TabIndex = 58;
			this.m_nudChirp10Tx3PhaseShiftter.Location = new Point(433, 358);
			this.m_nudChirp10Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array23 = new int[4];
			array23[0] = 63;
            this.m_nudChirp10Tx3PhaseShiftter.Maximum = new decimal(array23);
			this.m_nudChirp10Tx3PhaseShiftter.Name = "m_nudChirp10Tx3PhaseShiftter";
			this.m_nudChirp10Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp10Tx3PhaseShiftter.TabIndex = 57;
			this.m_nudChirp9Tx3PhaseShiftter.Location = new Point(433, 325);
			this.m_nudChirp9Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array24 = new int[4];
			array24[0] = 63;
            this.m_nudChirp9Tx3PhaseShiftter.Maximum = new decimal(array24);
			this.m_nudChirp9Tx3PhaseShiftter.Name = "m_nudChirp9Tx3PhaseShiftter";
			this.m_nudChirp9Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp9Tx3PhaseShiftter.TabIndex = 56;
			this.m_nudChirp8Tx3PhaseShiftter.Location = new Point(433, 294);
			this.m_nudChirp8Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array25 = new int[4];
			array25[0] = 63;
            this.m_nudChirp8Tx3PhaseShiftter.Maximum = new decimal(array25);
			this.m_nudChirp8Tx3PhaseShiftter.Name = "m_nudChirp8Tx3PhaseShiftter";
			this.m_nudChirp8Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp8Tx3PhaseShiftter.TabIndex = 55;
			this.m_nudChirp7Tx3PhaseShiftter.Location = new Point(433, 266);
			this.m_nudChirp7Tx3PhaseShiftter.Margin = new Padding(4);
			NumericUpDown nudChirp7Tx3PhaseShiftter = this.m_nudChirp7Tx3PhaseShiftter;
			int[] array26 = new int[4];
			array26[0] = 63;
			nudChirp7Tx3PhaseShiftter.Maximum = new decimal(array26);
			this.m_nudChirp7Tx3PhaseShiftter.Name = "m_nudChirp7Tx3PhaseShiftter";
			this.m_nudChirp7Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp7Tx3PhaseShiftter.TabIndex = 54;
			this.m_nudChirp6Tx3PhaseShiftter.Location = new Point(433, 233);
			this.m_nudChirp6Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array27 = new int[4];
			array27[0] = 63;
            this.m_nudChirp6Tx3PhaseShiftter.Maximum = new decimal(array27);
			this.m_nudChirp6Tx3PhaseShiftter.Name = "m_nudChirp6Tx3PhaseShiftter";
			this.m_nudChirp6Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp6Tx3PhaseShiftter.TabIndex = 53;
			this.m_nudChirp5Tx3PhaseShiftter.Location = new Point(433, 201);
			this.m_nudChirp5Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array28 = new int[4];
			array28[0] = 63;
            this.m_nudChirp5Tx3PhaseShiftter.Maximum = new decimal(array28);
			this.m_nudChirp5Tx3PhaseShiftter.Name = "m_nudChirp5Tx3PhaseShiftter";
			this.m_nudChirp5Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp5Tx3PhaseShiftter.TabIndex = 52;
			this.m_nudChirp4Tx3PhaseShiftter.Location = new Point(433, 167);
			this.m_nudChirp4Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array29 = new int[4];
			array29[0] = 63;
            this.m_nudChirp4Tx3PhaseShiftter.Maximum = new decimal(array29);
			this.m_nudChirp4Tx3PhaseShiftter.Name = "m_nudChirp4Tx3PhaseShiftter";
			this.m_nudChirp4Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp4Tx3PhaseShiftter.TabIndex = 51;
			this.m_nudChirp3Tx3PhaseShiftter.Location = new Point(433, 135);
			this.m_nudChirp3Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array30 = new int[4];
			array30[0] = 63;
            this.m_nudChirp3Tx3PhaseShiftter.Maximum = new decimal(array30);
			this.m_nudChirp3Tx3PhaseShiftter.Name = "m_nudChirp3Tx3PhaseShiftter";
			this.m_nudChirp3Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp3Tx3PhaseShiftter.TabIndex = 50;
			this.m_nudChirp2Tx3PhaseShiftter.Location = new Point(433, 103);
			this.m_nudChirp2Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array31 = new int[4];
			array31[0] = 63;
            this.m_nudChirp2Tx3PhaseShiftter.Maximum = new decimal(array31);
			this.m_nudChirp2Tx3PhaseShiftter.Name = "m_nudChirp2Tx3PhaseShiftter";
			this.m_nudChirp2Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp2Tx3PhaseShiftter.TabIndex = 49;
			this.m_nudChirp1Tx3PhaseShiftter.Location = new Point(433, 73);
			this.m_nudChirp1Tx3PhaseShiftter.Margin = new Padding(4);
			int[] array32 = new int[4];
			array32[0] = 63;
            this.m_nudChirp1Tx3PhaseShiftter.Maximum = new decimal(array32);
			this.m_nudChirp1Tx3PhaseShiftter.Name = "m_nudChirp1Tx3PhaseShiftter";
			this.m_nudChirp1Tx3PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp1Tx3PhaseShiftter.TabIndex = 48;
			this.m_nudChirp14Tx1PhaseShiftter.Location = new Point(153, 490);
			this.m_nudChirp14Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array33 = new int[4];
			array33[0] = 63;
            this.m_nudChirp14Tx1PhaseShiftter.Maximum = new decimal(array33);
			this.m_nudChirp14Tx1PhaseShiftter.Name = "m_nudChirp14Tx1PhaseShiftter";
			this.m_nudChirp14Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp14Tx1PhaseShiftter.TabIndex = 45;
			this.m_nudChirp13Tx1PhaseShiftter.Location = new Point(153, 457);
			this.m_nudChirp13Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array34 = new int[4];
			array34[0] = 63;
            this.m_nudChirp13Tx1PhaseShiftter.Maximum = new decimal(array34);
			this.m_nudChirp13Tx1PhaseShiftter.Name = "m_nudChirp13Tx1PhaseShiftter";
			this.m_nudChirp13Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp13Tx1PhaseShiftter.TabIndex = 44;
			this.m_nudChirp12Tx1PhaseShiftter.Location = new Point(153, 425);
			this.m_nudChirp12Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array35 = new int[4];
			array35[0] = 63;
            this.m_nudChirp12Tx1PhaseShiftter.Maximum = new decimal(array35);
			this.m_nudChirp12Tx1PhaseShiftter.Name = "m_nudChirp12Tx1PhaseShiftter";
			this.m_nudChirp12Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp12Tx1PhaseShiftter.TabIndex = 43;
			this.m_nudChirp16Tx1PhaseShiftter.Location = new Point(153, 555);
			this.m_nudChirp16Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array36 = new int[4];
			array36[0] = 63;
            this.m_nudChirp16Tx1PhaseShiftter.Maximum = new decimal(array36);
			this.m_nudChirp16Tx1PhaseShiftter.Name = "m_nudChirp16Tx1PhaseShiftter";
			this.m_nudChirp16Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp16Tx1PhaseShiftter.TabIndex = 6;
			this.m_nudChirp15Tx1PhaseShiftter.Location = new Point(153, 522);
			this.m_nudChirp15Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array37 = new int[4];
			array37[0] = 63;
            this.m_nudChirp15Tx1PhaseShiftter.Maximum = new decimal(array37);
			this.m_nudChirp15Tx1PhaseShiftter.Name = "m_nudChirp15Tx1PhaseShiftter";
			this.m_nudChirp15Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp15Tx1PhaseShiftter.TabIndex = 5;
			this.m_nudChirp11Tx1PhaseShiftter.Location = new Point(153, 391);
			this.m_nudChirp11Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array38 = new int[4];
			array38[0] = 63;
            this.m_nudChirp11Tx1PhaseShiftter.Maximum = new decimal(array38);
			this.m_nudChirp11Tx1PhaseShiftter.Name = "m_nudChirp11Tx1PhaseShiftter";
			this.m_nudChirp11Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp11Tx1PhaseShiftter.TabIndex = 42;
			this.m_nudChirp10Tx1PhaseShiftter.Location = new Point(153, 359);
			this.m_nudChirp10Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array39 = new int[4];
			array39[0] = 63;
            this.m_nudChirp10Tx1PhaseShiftter.Maximum = new decimal(array39);
			this.m_nudChirp10Tx1PhaseShiftter.Name = "m_nudChirp10Tx1PhaseShiftter";
			this.m_nudChirp10Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp10Tx1PhaseShiftter.TabIndex = 41;
			this.m_nudChirp9Tx1PhaseShiftter.Location = new Point(153, 326);
			this.m_nudChirp9Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array40 = new int[4];
			array40[0] = 63;
            this.m_nudChirp9Tx1PhaseShiftter.Maximum = new decimal(array40);
			this.m_nudChirp9Tx1PhaseShiftter.Name = "m_nudChirp9Tx1PhaseShiftter";
			this.m_nudChirp9Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp9Tx1PhaseShiftter.TabIndex = 40;
			this.m_nudChirp8Tx1PhaseShiftter.Location = new Point(153, 295);
			this.m_nudChirp8Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array41 = new int[4];
			array41[0] = 63;
            this.m_nudChirp8Tx1PhaseShiftter.Maximum = new decimal(array41);
			this.m_nudChirp8Tx1PhaseShiftter.Name = "m_nudChirp8Tx1PhaseShiftter";
			this.m_nudChirp8Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp8Tx1PhaseShiftter.TabIndex = 39;
			this.m_nudChirp7Tx1PhaseShiftter.Location = new Point(153, 265);
			this.m_nudChirp7Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array42 = new int[4];
			array42[0] = 63;
            this.m_nudChirp7Tx1PhaseShiftter.Maximum = new decimal(array42);
			this.m_nudChirp7Tx1PhaseShiftter.Name = "m_nudChirp7Tx1PhaseShiftter";
			this.m_nudChirp7Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp7Tx1PhaseShiftter.TabIndex = 38;
			this.m_nudChirp6Tx1PhaseShiftter.Location = new Point(153, 234);
			this.m_nudChirp6Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array43 = new int[4];
			array43[0] = 63;
            this.m_nudChirp6Tx1PhaseShiftter.Maximum = new decimal(array43);
			this.m_nudChirp6Tx1PhaseShiftter.Name = "m_nudChirp6Tx1PhaseShiftter";
			this.m_nudChirp6Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp6Tx1PhaseShiftter.TabIndex = 37;
			this.m_nudChirp5Tx1PhaseShiftter.Location = new Point(153, 202);
			this.m_nudChirp5Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array44 = new int[4];
			array44[0] = 63;
            this.m_nudChirp5Tx1PhaseShiftter.Maximum = new decimal(array44);
			this.m_nudChirp5Tx1PhaseShiftter.Name = "m_nudChirp5Tx1PhaseShiftter";
			this.m_nudChirp5Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp5Tx1PhaseShiftter.TabIndex = 36;
			this.m_nudChirp4Tx1PhaseShiftter.Location = new Point(153, 169);
			this.m_nudChirp4Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array45 = new int[4];
			array45[0] = 63;
            this.m_nudChirp4Tx1PhaseShiftter.Maximum = new decimal(array45);
			this.m_nudChirp4Tx1PhaseShiftter.Name = "m_nudChirp4Tx1PhaseShiftter";
			this.m_nudChirp4Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp4Tx1PhaseShiftter.TabIndex = 35;
			this.m_nudChirp3Tx1PhaseShiftter.Location = new Point(153, 137);
			this.m_nudChirp3Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array46 = new int[4];
			array46[0] = 63;
            this.m_nudChirp3Tx1PhaseShiftter.Maximum = new decimal(array46);
			this.m_nudChirp3Tx1PhaseShiftter.Name = "m_nudChirp3Tx1PhaseShiftter";
			this.m_nudChirp3Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp3Tx1PhaseShiftter.TabIndex = 34;
			this.m_nudChirp2Tx1PhaseShiftter.Location = new Point(153, 103);
			this.m_nudChirp2Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array47 = new int[4];
			array47[0] = 63;
            this.m_nudChirp2Tx1PhaseShiftter.Maximum = new decimal(array47);
			this.m_nudChirp2Tx1PhaseShiftter.Name = "m_nudChirp2Tx1PhaseShiftter";
			this.m_nudChirp2Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp2Tx1PhaseShiftter.TabIndex = 33;
			this.m_nudChirp1Tx1PhaseShiftter.Location = new Point(153, 73);
			this.m_nudChirp1Tx1PhaseShiftter.Margin = new Padding(4);
			int[] array48 = new int[4];
			array48[0] = 63;
            this.m_nudChirp1Tx1PhaseShiftter.Maximum = new decimal(array48);
			this.m_nudChirp1Tx1PhaseShiftter.Name = "m_nudChirp1Tx1PhaseShiftter";
			this.m_nudChirp1Tx1PhaseShiftter.Size = new Size(99, 22);
			this.m_nudChirp1Tx1PhaseShiftter.TabIndex = 32;
			this.m_nudPerChirpSegmentSelect.Location = new Point(152, 18);
			this.m_nudPerChirpSegmentSelect.Margin = new Padding(4);
			int[] array49 = new int[4];
			array49[0] = 31;
            this.m_nudPerChirpSegmentSelect.Maximum = new decimal(array49);
			this.m_nudPerChirpSegmentSelect.Name = "m_nudPerChirpSegmentSelect";
			this.m_nudPerChirpSegmentSelect.Size = new Size(99, 22);
			this.m_nudPerChirpSegmentSelect.TabIndex = 31;
			this.label52.AutoSize = true;
			this.label52.Location = new Point(425, 52);
			this.label52.Margin = new Padding(4, 0, 4, 0);
			this.label52.Name = "label52";
			this.label52.Size = new Size(120, 17);
			this.label52.TabIndex = 30;
			this.label52.Text = "Tx2 Phase Shifter";
			this.label54.AutoSize = true;
			this.label54.Location = new Point(145, 52);
			this.label54.Margin = new Padding(4, 0, 4, 0);
			this.label54.Name = "label54";
			this.label54.Size = new Size(120, 17);
			this.label54.TabIndex = 28;
			this.label54.Text = "Tx0 Phase Shifter";
			this.label55.AutoSize = true;
			this.label55.Location = new Point(293, 52);
			this.label55.Margin = new Padding(4, 0, 4, 0);
			this.label55.Name = "label55";
			this.label55.Size = new Size(120, 17);
			this.label55.TabIndex = 27;
			this.label55.Text = "Tx1 Phase Shifter";
			this.label24.AutoSize = true;
			this.label24.Location = new Point(5, 560);
			this.label24.Margin = new Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new Size(61, 17);
			this.label24.TabIndex = 10;
			this.label24.Text = "Chirp 16";
			this.label40.AutoSize = true;
			this.label40.Location = new Point(5, 495);
			this.label40.Margin = new Padding(4, 0, 4, 0);
			this.label40.Name = "label40";
			this.label40.Size = new Size(61, 17);
			this.label40.TabIndex = 26;
			this.label40.Text = "Chirp 14";
			this.label41.AutoSize = true;
			this.label41.Location = new Point(5, 526);
			this.label41.Margin = new Padding(4, 0, 4, 0);
			this.label41.Name = "label41";
			this.label41.Size = new Size(61, 17);
			this.label41.TabIndex = 25;
			this.label41.Text = "Chirp 15";
			this.label42.AutoSize = true;
			this.label42.Location = new Point(5, 426);
			this.label42.Margin = new Padding(4, 0, 4, 0);
			this.label42.Name = "label42";
			this.label42.Size = new Size(61, 17);
			this.label42.TabIndex = 24;
			this.label42.Text = "Chirp 12";
			this.label43.AutoSize = true;
			this.label43.Location = new Point(5, 459);
			this.label43.Margin = new Padding(4, 0, 4, 0);
			this.label43.Name = "label43";
			this.label43.Size = new Size(61, 17);
			this.label43.TabIndex = 23;
			this.label43.Text = "Chirp 13";
			this.label44.AutoSize = true;
			this.label44.Location = new Point(5, 362);
			this.label44.Margin = new Padding(4, 0, 4, 0);
			this.label44.Name = "label44";
			this.label44.Size = new Size(61, 17);
			this.label44.TabIndex = 22;
			this.label44.Text = "Chirp 10";
			this.label45.AutoSize = true;
			this.label45.Location = new Point(5, 398);
			this.label45.Margin = new Padding(4, 0, 4, 0);
			this.label45.Name = "label45";
			this.label45.Size = new Size(61, 17);
			this.label45.TabIndex = 21;
			this.label45.Text = "Chirp 11";
			this.label46.AutoSize = true;
			this.label46.Location = new Point(5, 299);
			this.label46.Margin = new Padding(4, 0, 4, 0);
			this.label46.Name = "label46";
			this.label46.Size = new Size(53, 17);
			this.label46.TabIndex = 20;
			this.label46.Text = "Chirp 8";
			this.label47.AutoSize = true;
			this.label47.Location = new Point(5, 329);
			this.label47.Margin = new Padding(4, 0, 4, 0);
			this.label47.Name = "label47";
			this.label47.Size = new Size(53, 17);
			this.label47.TabIndex = 19;
			this.label47.Text = "Chirp 9";
			this.label38.AutoSize = true;
			this.label38.Location = new Point(5, 240);
			this.label38.Margin = new Padding(4, 0, 4, 0);
			this.label38.Name = "label38";
			this.label38.Size = new Size(53, 17);
			this.label38.TabIndex = 18;
			this.label38.Text = "Chirp 6";
			this.label39.AutoSize = true;
			this.label39.Location = new Point(5, 271);
			this.label39.Margin = new Padding(4, 0, 4, 0);
			this.label39.Name = "label39";
			this.label39.Size = new Size(53, 17);
			this.label39.TabIndex = 17;
			this.label39.Text = "Chirp 7";
			this.label22.AutoSize = true;
			this.label22.Location = new Point(5, 171);
			this.label22.Margin = new Padding(4, 0, 4, 0);
			this.label22.Name = "label22";
			this.label22.Size = new Size(53, 17);
			this.label22.TabIndex = 16;
			this.label22.Text = "Chirp 4";
			this.label37.AutoSize = true;
			this.label37.Location = new Point(5, 206);
			this.label37.Margin = new Padding(4, 0, 4, 0);
			this.label37.Name = "label37";
			this.label37.Size = new Size(53, 17);
			this.label37.TabIndex = 15;
			this.label37.Text = "Chirp 5";
			this.label19.AutoSize = true;
			this.label19.Location = new Point(5, 110);
			this.label19.Margin = new Padding(4, 0, 4, 0);
			this.label19.Name = "label19";
			this.label19.Size = new Size(53, 17);
			this.label19.TabIndex = 14;
			this.label19.Text = "Chirp 2";
			this.label21.AutoSize = true;
			this.label21.Location = new Point(5, 140);
			this.label21.Margin = new Padding(4, 0, 4, 0);
			this.label21.Name = "label21";
			this.label21.Size = new Size(53, 17);
			this.label21.TabIndex = 13;
			this.label21.Text = "Chirp 3";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(5, 20);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(144, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "Chirp Segment Select";
			this.label15.AutoSize = true;
			this.label15.Location = new Point(5, 79);
			this.label15.Margin = new Padding(4, 0, 4, 0);
			this.label15.Name = "label15";
			this.label15.Size = new Size(53, 17);
			this.label15.TabIndex = 11;
			this.label15.Text = "Chirp 1";
			this.groupBox3.Controls.Add(this.m_btnDynamicChirpEnableConfigSet);
			this.groupBox3.Location = new Point(8, 652);
			this.groupBox3.Margin = new Padding(4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new Padding(4);
			this.groupBox3.Size = new Size(360, 60);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Dynamic Chirp Enable Configuration";
			this.m_btnDynamicChirpEnableConfigSet.Location = new Point(155, 21);
			this.m_btnDynamicChirpEnableConfigSet.Margin = new Padding(4);
			this.m_btnDynamicChirpEnableConfigSet.Name = "m_btnDynamicChirpEnableConfigSet";
			this.m_btnDynamicChirpEnableConfigSet.Size = new Size(100, 31);
			this.m_btnDynamicChirpEnableConfigSet.TabIndex = 0;
			this.m_btnDynamicChirpEnableConfigSet.Text = "Set";
			this.m_btnDynamicChirpEnableConfigSet.UseVisualStyleBackColor = true;
			this.m_btnDynamicChirpEnableConfigSet.Click += this.m_btnDynamicChirpEnableConfigSet_Click;
			this.groupBox1.Controls.Add(this.m_ChbProgramModeEnable);
			this.groupBox1.Controls.Add(this.m_nudChirpRowSelect);
			this.groupBox1.Controls.Add(this.label49);
			this.groupBox1.Controls.Add(this.label48);
			this.groupBox1.Controls.Add(this.m_btnDynamicChirpConfigSet);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.m_nudChirpSegmentSelect);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.ForeColor = SystemColors.ControlText;
			this.groupBox1.Location = new Point(8, -1);
			this.groupBox1.Margin = new Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new Padding(4);
			this.groupBox1.Size = new Size(909, 626);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dynamic Chirp Configuration";
			this.m_ChbProgramModeEnable.AutoSize = true;
			this.m_ChbProgramModeEnable.Location = new Point(735, 25);
			this.m_ChbProgramModeEnable.Margin = new Padding(4);
			this.m_ChbProgramModeEnable.Name = "m_ChbProgramModeEnable";
			this.m_ChbProgramModeEnable.Size = new Size(18, 17);
			this.m_ChbProgramModeEnable.TabIndex = 389;
			this.m_ChbProgramModeEnable.UseVisualStyleBackColor = true;
			this.m_nudChirpRowSelect.Location = new Point(161, 25);
			this.m_nudChirpRowSelect.Margin = new Padding(4);
			int[] array50 = new int[4];
			array50[0] = 3;
            this.m_nudChirpRowSelect.Maximum = new decimal(array50);
			this.m_nudChirpRowSelect.Name = "m_nudChirpRowSelect";
			this.m_nudChirpRowSelect.Size = new Size(104, 22);
			this.m_nudChirpRowSelect.TabIndex = 388;
			this.m_nudChirpRowSelect.ValueChanged += this.m_nudChirpRowSelect_ValueChanged;
			this.label49.AutoSize = true;
			this.label49.Location = new Point(617, 25);
			this.label49.Margin = new Padding(4, 0, 4, 0);
			this.label49.Name = "label49";
			this.label49.Size = new Size(101, 17);
			this.label49.TabIndex = 387;
			this.label49.Text = "Program Mode";
			this.label48.AutoSize = true;
			this.label48.Location = new Point(34, 30);
			this.label48.Margin = new Padding(4, 0, 4, 0);
			this.label48.Name = "label48";
			this.label48.Size = new Size(115, 17);
			this.label48.TabIndex = 386;
			this.label48.Text = "Chirp Row Select";
			this.m_btnDynamicChirpConfigSet.Location = new Point(778, 18);
			this.m_btnDynamicChirpConfigSet.Margin = new Padding(4);
			this.m_btnDynamicChirpConfigSet.Name = "m_btnDynamicChirpConfigSet";
			this.m_btnDynamicChirpConfigSet.Size = new Size(100, 28);
			this.m_btnDynamicChirpConfigSet.TabIndex = 385;
			this.m_btnDynamicChirpConfigSet.Text = "Set";
			this.m_btnDynamicChirpConfigSet.UseVisualStyleBackColor = true;
			this.m_btnDynamicChirpConfigSet.Click += this.m_btnDynamicChirpConfigSet_Click_1;
			this.label20.AutoSize = true;
			this.label20.Location = new Point(351, 76);
			this.label20.Margin = new Padding(4, 0, 4, 0);
			this.label20.Name = "label20";
			this.label20.Size = new Size(31, 17);
			this.label20.TabIndex = 384;
			this.label20.Text = "Tx2";
			this.label17.AutoSize = true;
			this.label17.Location = new Point(311, 76);
			this.label17.Margin = new Padding(4, 0, 4, 0);
			this.label17.Name = "label17";
			this.label17.Size = new Size(31, 17);
			this.label17.TabIndex = 383;
			this.label17.Text = "Tx1";
			this.label18.AutoSize = true;
			this.label18.Location = new Point(277, 76);
			this.label18.Margin = new Padding(4, 0, 4, 0);
			this.label18.Name = "label18";
			this.label18.Size = new Size(31, 17);
			this.label18.TabIndex = 382;
			this.label18.Text = "Tx0";
			this.label16.AutoSize = true;
			this.label16.Location = new Point(391, 76);
			this.label16.Margin = new Padding(4, 0, 4, 0);
			this.label16.Name = "label16";
			this.label16.Size = new Size(101, 17);
			this.label16.TabIndex = 381;
			this.label16.Text = "BPM Const Val";
			this.m_nudChirpSegmentSelect.Location = new Point(463, 23);
			this.m_nudChirpSegmentSelect.Margin = new Padding(4);
			int[] array51 = new int[4];
			array51[0] = 31;
            this.m_nudChirpSegmentSelect.Maximum = new decimal(array51);
			this.m_nudChirpSegmentSelect.Name = "m_nudChirpSegmentSelect";
			this.m_nudChirpSegmentSelect.Size = new Size(99, 22);
			this.m_nudChirpSegmentSelect.TabIndex = 380;
			this.m_nudChirpSegmentSelect.ValueChanged += this.m_nudChirpSegmentSelect_ValueChanged_1;
			this.label13.AutoSize = true;
			this.label13.ForeColor = SystemColors.HotTrack;
			this.label13.Location = new Point(632, 51);
			this.label13.Margin = new Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new Size(228, 17);
			this.label13.TabIndex = 379;
			this.label13.Text = "<-----------------  R3  ----------------->";
			this.label14.AutoSize = true;
			this.label14.Location = new Point(626, 77);
			this.label14.Margin = new Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new Size(116, 17);
			this.label14.TabIndex = 378;
			this.label14.Text = "Idle Time Var(us)";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(171, 67);
			this.label11.Margin = new Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new Size(103, 34);
			this.label11.TabIndex = 377;
			this.label11.Text = "Freq Slope Var\r (MHz/us)";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(78, 77);
			this.label12.Margin = new Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new Size(85, 17);
			this.label12.TabIndex = 376;
			this.label12.Text = "Profile Index";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(491, 77);
			this.label9.Margin = new Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new Size(139, 17);
			this.label9.TabIndex = 375;
			this.label9.Text = "Freq Start Var (GHz)";
			this.label10.AutoSize = true;
			this.label10.ForeColor = SystemColors.HotTrack;
			this.label10.Location = new Point(508, 51);
			this.label10.Margin = new Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new Size(120, 17);
			this.label10.TabIndex = 374;
			this.label10.Text = "<-------- R2 ------>";
			this.label5.AutoSize = true;
			this.label5.ForeColor = SystemColors.HotTrack;
			this.label5.Location = new Point(70, 51);
			this.label5.Margin = new Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(440, 17);
			this.label5.TabIndex = 373;
			this.label5.Text = "<----------------------------------- R1 ------------------------------------------->";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(745, 77);
			this.label6.Margin = new Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new Size(156, 17);
			this.label6.TabIndex = 372;
			this.label6.Text = "ADC Start Time Var(us)";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(310, 26);
			this.label4.Margin = new Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(144, 17);
			this.label4.TabIndex = 371;
			this.label4.Text = "Chirp Segment Select";
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.m_nudChirp48BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp48Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp48Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp48Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp48FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp48ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp48FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp48ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp48IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp47BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp47Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp47Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp47Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp47FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp47ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp47FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp47ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp47IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp46BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp46Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp46Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp46Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp46FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp46ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp46FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp46ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp46IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp44BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp44Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp44Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp44Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp44FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp44ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp44FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp44ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp44IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp45BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp45Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp45Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp45Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp45FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp45ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp45FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp45ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp45IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp43BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp43Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp43Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp43Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp43FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp43ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp43FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp43ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp43IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp42BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp42Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp42Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp42Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp42FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp42ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp42FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp42ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp42IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp41BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp41Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp41Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp41Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp41FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp41ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp41FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp41ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp41IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp40BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp40Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp40Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp40Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp40FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp40ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp40FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp40ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp40IdleTimeVar);
			this.panel1.Controls.Add(this.label67);
			this.panel1.Controls.Add(this.label69);
			this.panel1.Controls.Add(this.label70);
			this.panel1.Controls.Add(this.label71);
			this.panel1.Controls.Add(this.label72);
			this.panel1.Controls.Add(this.label73);
			this.panel1.Controls.Add(this.label74);
			this.panel1.Controls.Add(this.label75);
			this.panel1.Controls.Add(this.label76);
			this.panel1.Controls.Add(this.m_nudChirp39BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp39Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp39Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp39Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp39FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp39ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp39FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp39ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp39IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp37BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp37Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp37Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp37Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp37FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp37ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp37FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp37ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp37IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp38BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp38Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp38Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp38Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp38FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp38ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp38FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp38ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp38IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp36BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp36Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp36Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp36Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp36FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp36ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp36FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp36ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp36IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp35BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp35Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp35Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp35Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp35FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp35ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp35FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp35ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp35IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp34BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp34Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp34Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp34Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp34FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp34ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp34FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp34ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp34IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp32BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp32Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp32Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp32Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp32FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp32ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp32FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp32ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp32IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp33BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp33Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp33Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp33Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp33FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp33ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp33FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp33ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp33IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp31BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp31Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp31Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp31Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp31FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp31ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp31FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp31ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp31IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp30BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp30Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp30Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp30Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp30FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp30ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp30FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp30ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp30IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp29BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp29Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp29Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp29Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp29FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp29ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp29FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp29ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp29IdleTimeVar);
			this.panel1.Controls.Add(this.label77);
			this.panel1.Controls.Add(this.label78);
			this.panel1.Controls.Add(this.label79);
			this.panel1.Controls.Add(this.label80);
			this.panel1.Controls.Add(this.label81);
			this.panel1.Controls.Add(this.label82);
			this.panel1.Controls.Add(this.label83);
			this.panel1.Controls.Add(this.label84);
			this.panel1.Controls.Add(this.label85);
			this.panel1.Controls.Add(this.label86);
			this.panel1.Controls.Add(this.label87);
			this.panel1.Controls.Add(this.m_nudChirp28BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp28Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp28Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp28Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp28FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp28ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp28FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp28ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp28IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp26BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp26Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp26Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp26Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp26FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp26ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp26FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp26ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp26IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp27BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp27Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp27Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp27Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp27FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp27ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp27FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp27ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp27IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp25BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp25Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp25Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp25Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp25FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp25ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp25FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp25ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp25IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp24BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp24Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp24Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp24Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp24FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp24ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp24FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp24ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp24IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp23BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp23Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp23Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp23Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp23FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp23ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp23FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp23ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp23IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp21BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp21Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp21Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp21Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp21FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp21ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp21FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp21ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp21IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp22BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp22Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp22Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp22Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp22FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp22ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp22FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp22ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp22IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp20BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp20Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp20Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp20Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp20FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp20ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp20FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp20ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp20IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp19BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp19Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp19Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp19Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp19FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp19ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp19FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp19ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp19IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp18BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp18Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp18Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp18Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp18FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp18ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp18FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp18ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp18IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp17BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp17Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp17Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp17Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp17FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp17ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp17FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp17ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp17IdleTimeVar);
			this.panel1.Controls.Add(this.label50);
			this.panel1.Controls.Add(this.label51);
			this.panel1.Controls.Add(this.label53);
			this.panel1.Controls.Add(this.label56);
			this.panel1.Controls.Add(this.label57);
			this.panel1.Controls.Add(this.label58);
			this.panel1.Controls.Add(this.label59);
			this.panel1.Controls.Add(this.label60);
			this.panel1.Controls.Add(this.label61);
			this.panel1.Controls.Add(this.label62);
			this.panel1.Controls.Add(this.label63);
			this.panel1.Controls.Add(this.label64);
			this.panel1.Controls.Add(this.m_nudChirp16BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp16Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp16Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp16Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp16FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp16ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp16FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp16ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp16IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp14BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp14Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp14Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp14Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp14FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp14ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp14FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp14ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp14IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp15BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp15Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp15Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp15Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp15FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp15ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp15FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp15ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp15IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp13BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp13Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp13Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp13Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp13FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp13ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp13FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp13ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp13IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp12BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp12Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp12Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp12Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp12FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp12ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp12FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp12ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp12IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp11BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp11Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp11Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp11Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp11FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp11ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp11FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp11ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp11IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp9BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp9Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp9Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp9Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp9FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp9ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp9FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp9ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp9IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp10BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp10Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp10Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp10Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp10FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp10ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp10FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp10ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp10IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp8BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp8Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp8Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp8Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp8FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp8ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp8FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp8ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp8IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp7BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp7Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp7Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp7Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp7FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp7ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp7FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp7ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp7IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp6BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp6Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp6Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp6Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp6FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp6ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp6FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp6ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp6IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp4BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp4Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp4Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp4Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp4FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp4ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp4FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp4ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp4IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp5BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp5Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp5Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp5Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp5FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp5ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp5FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp5ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp5IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp3BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp3Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp3Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp3Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp3FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp3ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp3FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp3ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp3IdleTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp2BPMConstVal);
			this.panel1.Controls.Add(this.m_ChbChirp2Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp2Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp2Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp2FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp2ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp2FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp2ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp2IdleTimeVar);
			this.panel1.Controls.Add(this.label35);
			this.panel1.Controls.Add(this.label36);
			this.panel1.Controls.Add(this.label33);
			this.panel1.Controls.Add(this.label34);
			this.panel1.Controls.Add(this.label31);
			this.panel1.Controls.Add(this.label32);
			this.panel1.Controls.Add(this.m_nudChirp1BPMConstVal);
			this.panel1.Controls.Add(this.label29);
			this.panel1.Controls.Add(this.label30);
			this.panel1.Controls.Add(this.label27);
			this.panel1.Controls.Add(this.label28);
			this.panel1.Controls.Add(this.label25);
			this.panel1.Controls.Add(this.label26);
			this.panel1.Controls.Add(this.label23);
			this.panel1.Controls.Add(this.m_ChbChirp1Tx3Enable);
			this.panel1.Controls.Add(this.m_ChbChirp1Tx2Enable);
			this.panel1.Controls.Add(this.m_ChbChirp1Tx1Enable);
			this.panel1.Controls.Add(this.m_nudChirp1FreqSlopeVar);
			this.panel1.Controls.Add(this.m_nudChirp1ProfileIndex);
			this.panel1.Controls.Add(this.m_nudChirp1FreqStartVar);
			this.panel1.Controls.Add(this.m_nudChirp1ADCStartTimeVar);
			this.panel1.Controls.Add(this.m_nudChirp1IdleTimeVar);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new Point(0, 104);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(878, 497);
			this.panel1.TabIndex = 0;
			this.m_nudChirp48BPMConstVal.Location = new Point(399, 1460);
			this.m_nudChirp48BPMConstVal.Margin = new Padding(4);
			int[] array52 = new int[4];
			array52[0] = 63;
            this.m_nudChirp48BPMConstVal.Maximum = new decimal(array52);
			this.m_nudChirp48BPMConstVal.Name = "m_nudChirp48BPMConstVal";
			this.m_nudChirp48BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp48BPMConstVal.TabIndex = 840;
			this.m_ChbChirp48Tx3Enable.AutoSize = true;
			this.m_ChbChirp48Tx3Enable.Location = new Point(359, 1464);
			this.m_ChbChirp48Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp48Tx3Enable.Name = "m_ChbChirp48Tx3Enable";
			this.m_ChbChirp48Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp48Tx3Enable.TabIndex = 848;
			this.m_ChbChirp48Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp48Tx2Enable.AutoSize = true;
			this.m_ChbChirp48Tx2Enable.Location = new Point(319, 1465);
			this.m_ChbChirp48Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp48Tx2Enable.Name = "m_ChbChirp48Tx2Enable";
			this.m_ChbChirp48Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp48Tx2Enable.TabIndex = 847;
			this.m_ChbChirp48Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp48Tx1Enable.AutoSize = true;
			this.m_ChbChirp48Tx1Enable.Location = new Point(285, 1465);
			this.m_ChbChirp48Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp48Tx1Enable.Name = "m_ChbChirp48Tx1Enable";
			this.m_ChbChirp48Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp48Tx1Enable.TabIndex = 846;
			this.m_ChbChirp48Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp48FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp48FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp48FreqSlopeVar.Location = new Point(178, 1462);
			this.m_nudChirp48FreqSlopeVar.Margin = new Padding(4);
			int[] array53 = new int[4];
			array53[0] = 4;
            this.m_nudChirp48FreqSlopeVar.Maximum = new decimal(array53);
			this.m_nudChirp48FreqSlopeVar.Name = "m_nudChirp48FreqSlopeVar";
			this.m_nudChirp48FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp48FreqSlopeVar.TabIndex = 845;
			this.m_nudChirp48ProfileIndex.Location = new Point(82, 1462);
			this.m_nudChirp48ProfileIndex.Margin = new Padding(4);
			int[] array54 = new int[4];
			array54[0] = 3;
            this.m_nudChirp48ProfileIndex.Maximum = new decimal(array54);
			this.m_nudChirp48ProfileIndex.Name = "m_nudChirp48ProfileIndex";
			this.m_nudChirp48ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp48ProfileIndex.TabIndex = 844;
			this.m_nudChirp48FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp48FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp48FreqStartVar.Location = new Point(513, 1464);
			this.m_nudChirp48FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp48FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp48FreqStartVar.Name = "m_nudChirp48FreqStartVar";
			this.m_nudChirp48FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp48FreqStartVar.TabIndex = 843;
			this.m_nudChirp48ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp48ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp48ADCStartTimeVar.Location = new Point(755, 1464);
			this.m_nudChirp48ADCStartTimeVar.Margin = new Padding(4);
			int[] array55 = new int[4];
			array55[0] = 4095;
            this.m_nudChirp48ADCStartTimeVar.Maximum = new decimal(array55);
			this.m_nudChirp48ADCStartTimeVar.Name = "m_nudChirp48ADCStartTimeVar";
			this.m_nudChirp48ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp48ADCStartTimeVar.TabIndex = 842;
			this.m_nudChirp48IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp48IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp48IdleTimeVar.Location = new Point(647, 1464);
			this.m_nudChirp48IdleTimeVar.Margin = new Padding(4);
			int[] array56 = new int[4];
			array56[0] = 4095;
            this.m_nudChirp48IdleTimeVar.Maximum = new decimal(array56);
			this.m_nudChirp48IdleTimeVar.Name = "m_nudChirp48IdleTimeVar";
			this.m_nudChirp48IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp48IdleTimeVar.TabIndex = 841;
			this.m_nudChirp47BPMConstVal.Location = new Point(399, 1428);
			this.m_nudChirp47BPMConstVal.Margin = new Padding(4);
			int[] array57 = new int[4];
			array57[0] = 63;
            this.m_nudChirp47BPMConstVal.Maximum = new decimal(array57);
			this.m_nudChirp47BPMConstVal.Name = "m_nudChirp47BPMConstVal";
			this.m_nudChirp47BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp47BPMConstVal.TabIndex = 831;
			this.m_ChbChirp47Tx3Enable.AutoSize = true;
			this.m_ChbChirp47Tx3Enable.Location = new Point(359, 1432);
			this.m_ChbChirp47Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp47Tx3Enable.Name = "m_ChbChirp47Tx3Enable";
			this.m_ChbChirp47Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp47Tx3Enable.TabIndex = 839;
			this.m_ChbChirp47Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp47Tx2Enable.AutoSize = true;
			this.m_ChbChirp47Tx2Enable.Location = new Point(319, 1433);
			this.m_ChbChirp47Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp47Tx2Enable.Name = "m_ChbChirp47Tx2Enable";
			this.m_ChbChirp47Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp47Tx2Enable.TabIndex = 838;
			this.m_ChbChirp47Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp47Tx1Enable.AutoSize = true;
			this.m_ChbChirp47Tx1Enable.Location = new Point(285, 1433);
			this.m_ChbChirp47Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp47Tx1Enable.Name = "m_ChbChirp47Tx1Enable";
			this.m_ChbChirp47Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp47Tx1Enable.TabIndex = 837;
			this.m_ChbChirp47Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp47FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp47FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp47FreqSlopeVar.Location = new Point(178, 1430);
			this.m_nudChirp47FreqSlopeVar.Margin = new Padding(4);
			int[] array58 = new int[4];
			array58[0] = 4;
            this.m_nudChirp47FreqSlopeVar.Maximum = new decimal(array58);
			this.m_nudChirp47FreqSlopeVar.Name = "m_nudChirp47FreqSlopeVar";
			this.m_nudChirp47FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp47FreqSlopeVar.TabIndex = 836;
			this.m_nudChirp47ProfileIndex.Location = new Point(82, 1430);
			this.m_nudChirp47ProfileIndex.Margin = new Padding(4);
			int[] array59 = new int[4];
			array59[0] = 3;
            this.m_nudChirp47ProfileIndex.Maximum = new decimal(array59);
			this.m_nudChirp47ProfileIndex.Name = "m_nudChirp47ProfileIndex";
			this.m_nudChirp47ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp47ProfileIndex.TabIndex = 835;
			this.m_nudChirp47FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp47FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp47FreqStartVar.Location = new Point(513, 1432);
			this.m_nudChirp47FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp47FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp47FreqStartVar.Name = "m_nudChirp47FreqStartVar";
			this.m_nudChirp47FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp47FreqStartVar.TabIndex = 834;
			this.m_nudChirp47ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp47ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp47ADCStartTimeVar.Location = new Point(755, 1432);
			this.m_nudChirp47ADCStartTimeVar.Margin = new Padding(4);
			int[] array60 = new int[4];
			array60[0] = 4095;
            this.m_nudChirp47ADCStartTimeVar.Maximum = new decimal(array60);
			this.m_nudChirp47ADCStartTimeVar.Name = "m_nudChirp47ADCStartTimeVar";
			this.m_nudChirp47ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp47ADCStartTimeVar.TabIndex = 833;
			this.m_nudChirp47IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp47IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp47IdleTimeVar.Location = new Point(647, 1432);
			this.m_nudChirp47IdleTimeVar.Margin = new Padding(4);
			int[] array61 = new int[4];
			array61[0] = 4095;
            this.m_nudChirp47IdleTimeVar.Maximum = new decimal(array61);
			this.m_nudChirp47IdleTimeVar.Name = "m_nudChirp47IdleTimeVar";
			this.m_nudChirp47IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp47IdleTimeVar.TabIndex = 832;
			this.m_nudChirp46BPMConstVal.Location = new Point(399, 1397);
			this.m_nudChirp46BPMConstVal.Margin = new Padding(4);
			int[] array62 = new int[4];
			array62[0] = 63;
            this.m_nudChirp46BPMConstVal.Maximum = new decimal(array62);
			this.m_nudChirp46BPMConstVal.Name = "m_nudChirp46BPMConstVal";
			this.m_nudChirp46BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp46BPMConstVal.TabIndex = 822;
			this.m_ChbChirp46Tx3Enable.AutoSize = true;
			this.m_ChbChirp46Tx3Enable.Location = new Point(359, 1401);
			this.m_ChbChirp46Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp46Tx3Enable.Name = "m_ChbChirp46Tx3Enable";
			this.m_ChbChirp46Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp46Tx3Enable.TabIndex = 830;
			this.m_ChbChirp46Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp46Tx2Enable.AutoSize = true;
			this.m_ChbChirp46Tx2Enable.Location = new Point(319, 1402);
			this.m_ChbChirp46Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp46Tx2Enable.Name = "m_ChbChirp46Tx2Enable";
			this.m_ChbChirp46Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp46Tx2Enable.TabIndex = 829;
			this.m_ChbChirp46Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp46Tx1Enable.AutoSize = true;
			this.m_ChbChirp46Tx1Enable.Location = new Point(285, 1402);
			this.m_ChbChirp46Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp46Tx1Enable.Name = "m_ChbChirp46Tx1Enable";
			this.m_ChbChirp46Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp46Tx1Enable.TabIndex = 828;
			this.m_ChbChirp46Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp46FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp46FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp46FreqSlopeVar.Location = new Point(178, 1400);
			this.m_nudChirp46FreqSlopeVar.Margin = new Padding(4);
			int[] array63 = new int[4];
			array63[0] = 4;
            this.m_nudChirp46FreqSlopeVar.Maximum = new decimal(array63);
			this.m_nudChirp46FreqSlopeVar.Name = "m_nudChirp46FreqSlopeVar";
			this.m_nudChirp46FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp46FreqSlopeVar.TabIndex = 827;
			this.m_nudChirp46ProfileIndex.Location = new Point(82, 1400);
			this.m_nudChirp46ProfileIndex.Margin = new Padding(4);
			int[] array64 = new int[4];
			array64[0] = 3;
            this.m_nudChirp46ProfileIndex.Maximum = new decimal(array64);
			this.m_nudChirp46ProfileIndex.Name = "m_nudChirp46ProfileIndex";
			this.m_nudChirp46ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp46ProfileIndex.TabIndex = 826;
			this.m_nudChirp46FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp46FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp46FreqStartVar.Location = new Point(513, 1401);
			this.m_nudChirp46FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp46FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp46FreqStartVar.Name = "m_nudChirp46FreqStartVar";
			this.m_nudChirp46FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp46FreqStartVar.TabIndex = 825;
			this.m_nudChirp46ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp46ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp46ADCStartTimeVar.Location = new Point(755, 1401);
			this.m_nudChirp46ADCStartTimeVar.Margin = new Padding(4);
			int[] array65 = new int[4];
			array65[0] = 4095;
            this.m_nudChirp46ADCStartTimeVar.Maximum = new decimal(array65);
			this.m_nudChirp46ADCStartTimeVar.Name = "m_nudChirp46ADCStartTimeVar";
			this.m_nudChirp46ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp46ADCStartTimeVar.TabIndex = 824;
			this.m_nudChirp46IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp46IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp46IdleTimeVar.Location = new Point(647, 1401);
			this.m_nudChirp46IdleTimeVar.Margin = new Padding(4);
			int[] array66 = new int[4];
			array66[0] = 4095;
            this.m_nudChirp46IdleTimeVar.Maximum = new decimal(array66);
			this.m_nudChirp46IdleTimeVar.Name = "m_nudChirp46IdleTimeVar";
			this.m_nudChirp46IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp46IdleTimeVar.TabIndex = 823;
			this.m_nudChirp44BPMConstVal.Location = new Point(399, 1339);
			this.m_nudChirp44BPMConstVal.Margin = new Padding(4);
			int[] array67 = new int[4];
			array67[0] = 63;
            this.m_nudChirp44BPMConstVal.Maximum = new decimal(array67);
			this.m_nudChirp44BPMConstVal.Name = "m_nudChirp44BPMConstVal";
			this.m_nudChirp44BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp44BPMConstVal.TabIndex = 813;
			this.m_ChbChirp44Tx3Enable.AutoSize = true;
			this.m_ChbChirp44Tx3Enable.Location = new Point(359, 1343);
			this.m_ChbChirp44Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp44Tx3Enable.Name = "m_ChbChirp44Tx3Enable";
			this.m_ChbChirp44Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp44Tx3Enable.TabIndex = 821;
			this.m_ChbChirp44Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp44Tx2Enable.AutoSize = true;
			this.m_ChbChirp44Tx2Enable.Location = new Point(319, 1344);
			this.m_ChbChirp44Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp44Tx2Enable.Name = "m_ChbChirp44Tx2Enable";
			this.m_ChbChirp44Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp44Tx2Enable.TabIndex = 820;
			this.m_ChbChirp44Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp44Tx1Enable.AutoSize = true;
			this.m_ChbChirp44Tx1Enable.Location = new Point(285, 1344);
			this.m_ChbChirp44Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp44Tx1Enable.Name = "m_ChbChirp44Tx1Enable";
			this.m_ChbChirp44Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp44Tx1Enable.TabIndex = 819;
			this.m_ChbChirp44Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp44FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp44FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp44FreqSlopeVar.Location = new Point(178, 1342);
			this.m_nudChirp44FreqSlopeVar.Margin = new Padding(4);
			int[] array68 = new int[4];
			array68[0] = 4;
            this.m_nudChirp44FreqSlopeVar.Maximum = new decimal(array68);
			this.m_nudChirp44FreqSlopeVar.Name = "m_nudChirp44FreqSlopeVar";
			this.m_nudChirp44FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp44FreqSlopeVar.TabIndex = 818;
			this.m_nudChirp44ProfileIndex.Location = new Point(82, 1342);
			this.m_nudChirp44ProfileIndex.Margin = new Padding(4);
			int[] array69 = new int[4];
			array69[0] = 3;
            this.m_nudChirp44ProfileIndex.Maximum = new decimal(array69);
			this.m_nudChirp44ProfileIndex.Name = "m_nudChirp44ProfileIndex";
			this.m_nudChirp44ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp44ProfileIndex.TabIndex = 817;
			this.m_nudChirp44FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp44FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp44FreqStartVar.Location = new Point(513, 1343);
			this.m_nudChirp44FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp44FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp44FreqStartVar.Name = "m_nudChirp44FreqStartVar";
			this.m_nudChirp44FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp44FreqStartVar.TabIndex = 816;
			this.m_nudChirp44ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp44ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp44ADCStartTimeVar.Location = new Point(755, 1343);
			this.m_nudChirp44ADCStartTimeVar.Margin = new Padding(4);
			int[] array70 = new int[4];
			array70[0] = 4095;
            this.m_nudChirp44ADCStartTimeVar.Maximum = new decimal(array70);
			this.m_nudChirp44ADCStartTimeVar.Name = "m_nudChirp44ADCStartTimeVar";
			this.m_nudChirp44ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp44ADCStartTimeVar.TabIndex = 815;
			this.m_nudChirp44IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp44IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp44IdleTimeVar.Location = new Point(647, 1343);
			this.m_nudChirp44IdleTimeVar.Margin = new Padding(4);
			int[] array71 = new int[4];
			array71[0] = 4095;
            this.m_nudChirp44IdleTimeVar.Maximum = new decimal(array71);
			this.m_nudChirp44IdleTimeVar.Name = "m_nudChirp44IdleTimeVar";
			this.m_nudChirp44IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp44IdleTimeVar.TabIndex = 814;
			this.m_nudChirp45BPMConstVal.Location = new Point(399, 1369);
			this.m_nudChirp45BPMConstVal.Margin = new Padding(4);
			int[] array72 = new int[4];
			array72[0] = 63;
            this.m_nudChirp45BPMConstVal.Maximum = new decimal(array72);
			this.m_nudChirp45BPMConstVal.Name = "m_nudChirp45BPMConstVal";
			this.m_nudChirp45BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp45BPMConstVal.TabIndex = 804;
			this.m_ChbChirp45Tx3Enable.AutoSize = true;
			this.m_ChbChirp45Tx3Enable.Location = new Point(359, 1373);
			this.m_ChbChirp45Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp45Tx3Enable.Name = "m_ChbChirp45Tx3Enable";
			this.m_ChbChirp45Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp45Tx3Enable.TabIndex = 812;
			this.m_ChbChirp45Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp45Tx2Enable.AutoSize = true;
			this.m_ChbChirp45Tx2Enable.Location = new Point(319, 1374);
			this.m_ChbChirp45Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp45Tx2Enable.Name = "m_ChbChirp45Tx2Enable";
			this.m_ChbChirp45Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp45Tx2Enable.TabIndex = 811;
			this.m_ChbChirp45Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp45Tx1Enable.AutoSize = true;
			this.m_ChbChirp45Tx1Enable.Location = new Point(285, 1374);
			this.m_ChbChirp45Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp45Tx1Enable.Name = "m_ChbChirp45Tx1Enable";
			this.m_ChbChirp45Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp45Tx1Enable.TabIndex = 810;
			this.m_ChbChirp45Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp45FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp45FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp45FreqSlopeVar.Location = new Point(178, 1371);
			this.m_nudChirp45FreqSlopeVar.Margin = new Padding(4);
			int[] array73 = new int[4];
			array73[0] = 4;
            this.m_nudChirp45FreqSlopeVar.Maximum = new decimal(array73);
			this.m_nudChirp45FreqSlopeVar.Name = "m_nudChirp45FreqSlopeVar";
			this.m_nudChirp45FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp45FreqSlopeVar.TabIndex = 809;
			this.m_nudChirp45ProfileIndex.Location = new Point(82, 1371);
			this.m_nudChirp45ProfileIndex.Margin = new Padding(4);
			int[] array74 = new int[4];
			array74[0] = 3;
            this.m_nudChirp45ProfileIndex.Maximum = new decimal(array74);
			this.m_nudChirp45ProfileIndex.Name = "m_nudChirp45ProfileIndex";
			this.m_nudChirp45ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp45ProfileIndex.TabIndex = 808;
			this.m_nudChirp45FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp45FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp45FreqStartVar.Location = new Point(513, 1373);
			this.m_nudChirp45FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp45FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp45FreqStartVar.Name = "m_nudChirp45FreqStartVar";
			this.m_nudChirp45FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp45FreqStartVar.TabIndex = 807;
			this.m_nudChirp45ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp45ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp45ADCStartTimeVar.Location = new Point(755, 1373);
			this.m_nudChirp45ADCStartTimeVar.Margin = new Padding(4);
			int[] array75 = new int[4];
			array75[0] = 4095;
            this.m_nudChirp45ADCStartTimeVar.Maximum = new decimal(array75);
			this.m_nudChirp45ADCStartTimeVar.Name = "m_nudChirp45ADCStartTimeVar";
			this.m_nudChirp45ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp45ADCStartTimeVar.TabIndex = 806;
			this.m_nudChirp45IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp45IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp45IdleTimeVar.Location = new Point(647, 1373);
			this.m_nudChirp45IdleTimeVar.Margin = new Padding(4);
			int[] array76 = new int[4];
			array76[0] = 4095;
            this.m_nudChirp45IdleTimeVar.Maximum = new decimal(array76);
			this.m_nudChirp45IdleTimeVar.Name = "m_nudChirp45IdleTimeVar";
			this.m_nudChirp45IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp45IdleTimeVar.TabIndex = 805;
			this.m_nudChirp43BPMConstVal.Location = new Point(400, 1303);
			this.m_nudChirp43BPMConstVal.Margin = new Padding(4);
			int[] array77 = new int[4];
			array77[0] = 63;
            this.m_nudChirp43BPMConstVal.Maximum = new decimal(array77);
			this.m_nudChirp43BPMConstVal.Name = "m_nudChirp43BPMConstVal";
			this.m_nudChirp43BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp43BPMConstVal.TabIndex = 795;
			this.m_ChbChirp43Tx3Enable.AutoSize = true;
			this.m_ChbChirp43Tx3Enable.Location = new Point(360, 1307);
			this.m_ChbChirp43Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp43Tx3Enable.Name = "m_ChbChirp43Tx3Enable";
			this.m_ChbChirp43Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp43Tx3Enable.TabIndex = 803;
			this.m_ChbChirp43Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp43Tx2Enable.AutoSize = true;
			this.m_ChbChirp43Tx2Enable.Location = new Point(320, 1308);
			this.m_ChbChirp43Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp43Tx2Enable.Name = "m_ChbChirp43Tx2Enable";
			this.m_ChbChirp43Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp43Tx2Enable.TabIndex = 802;
			this.m_ChbChirp43Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp43Tx1Enable.AutoSize = true;
			this.m_ChbChirp43Tx1Enable.Location = new Point(286, 1308);
			this.m_ChbChirp43Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp43Tx1Enable.Name = "m_ChbChirp43Tx1Enable";
			this.m_ChbChirp43Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp43Tx1Enable.TabIndex = 801;
			this.m_ChbChirp43Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp43FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp43FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp43FreqSlopeVar.Location = new Point(179, 1306);
			this.m_nudChirp43FreqSlopeVar.Margin = new Padding(4);
			int[] array78 = new int[4];
			array78[0] = 4;
            this.m_nudChirp43FreqSlopeVar.Maximum = new decimal(array78);
			this.m_nudChirp43FreqSlopeVar.Name = "m_nudChirp43FreqSlopeVar";
			this.m_nudChirp43FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp43FreqSlopeVar.TabIndex = 800;
			this.m_nudChirp43ProfileIndex.Location = new Point(83, 1306);
			this.m_nudChirp43ProfileIndex.Margin = new Padding(4);
			int[] array79 = new int[4];
			array79[0] = 3;
            this.m_nudChirp43ProfileIndex.Maximum = new decimal(array79);
			this.m_nudChirp43ProfileIndex.Name = "m_nudChirp43ProfileIndex";
			this.m_nudChirp43ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp43ProfileIndex.TabIndex = 799;
			this.m_nudChirp43FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp43FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp43FreqStartVar.Location = new Point(514, 1307);
			this.m_nudChirp43FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp43FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp43FreqStartVar.Name = "m_nudChirp43FreqStartVar";
			this.m_nudChirp43FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp43FreqStartVar.TabIndex = 798;
			this.m_nudChirp43ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp43ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp43ADCStartTimeVar.Location = new Point(756, 1307);
			this.m_nudChirp43ADCStartTimeVar.Margin = new Padding(4);
			int[] array80 = new int[4];
			array80[0] = 4095;
            this.m_nudChirp43ADCStartTimeVar.Maximum = new decimal(array80);
			this.m_nudChirp43ADCStartTimeVar.Name = "m_nudChirp43ADCStartTimeVar";
			this.m_nudChirp43ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp43ADCStartTimeVar.TabIndex = 797;
			this.m_nudChirp43IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp43IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp43IdleTimeVar.Location = new Point(648, 1307);
			this.m_nudChirp43IdleTimeVar.Margin = new Padding(4);
			int[] array81 = new int[4];
			array81[0] = 4095;
            this.m_nudChirp43IdleTimeVar.Maximum = new decimal(array81);
			this.m_nudChirp43IdleTimeVar.Name = "m_nudChirp43IdleTimeVar";
			this.m_nudChirp43IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp43IdleTimeVar.TabIndex = 796;
			this.m_nudChirp42BPMConstVal.Location = new Point(400, 1271);
			this.m_nudChirp42BPMConstVal.Margin = new Padding(4);
			int[] array82 = new int[4];
			array82[0] = 63;
            this.m_nudChirp42BPMConstVal.Maximum = new decimal(array82);
			this.m_nudChirp42BPMConstVal.Name = "m_nudChirp42BPMConstVal";
			this.m_nudChirp42BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp42BPMConstVal.TabIndex = 786;
			this.m_ChbChirp42Tx3Enable.AutoSize = true;
			this.m_ChbChirp42Tx3Enable.Location = new Point(360, 1275);
			this.m_ChbChirp42Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp42Tx3Enable.Name = "m_ChbChirp42Tx3Enable";
			this.m_ChbChirp42Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp42Tx3Enable.TabIndex = 794;
			this.m_ChbChirp42Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp42Tx2Enable.AutoSize = true;
			this.m_ChbChirp42Tx2Enable.Location = new Point(320, 1276);
			this.m_ChbChirp42Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp42Tx2Enable.Name = "m_ChbChirp42Tx2Enable";
			this.m_ChbChirp42Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp42Tx2Enable.TabIndex = 793;
			this.m_ChbChirp42Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp42Tx1Enable.AutoSize = true;
			this.m_ChbChirp42Tx1Enable.Location = new Point(286, 1276);
			this.m_ChbChirp42Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp42Tx1Enable.Name = "m_ChbChirp42Tx1Enable";
			this.m_ChbChirp42Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp42Tx1Enable.TabIndex = 792;
			this.m_ChbChirp42Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp42FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp42FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp42FreqSlopeVar.Location = new Point(179, 1274);
			this.m_nudChirp42FreqSlopeVar.Margin = new Padding(4);
			int[] array83 = new int[4];
			array83[0] = 4;
            this.m_nudChirp42FreqSlopeVar.Maximum = new decimal(array83);
			this.m_nudChirp42FreqSlopeVar.Name = "m_nudChirp42FreqSlopeVar";
			this.m_nudChirp42FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp42FreqSlopeVar.TabIndex = 791;
			this.m_nudChirp42ProfileIndex.Location = new Point(83, 1274);
			this.m_nudChirp42ProfileIndex.Margin = new Padding(4);
			int[] array84 = new int[4];
			array84[0] = 3;
            this.m_nudChirp42ProfileIndex.Maximum = new decimal(array84);
			this.m_nudChirp42ProfileIndex.Name = "m_nudChirp42ProfileIndex";
			this.m_nudChirp42ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp42ProfileIndex.TabIndex = 790;
			this.m_nudChirp42FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp42FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp42FreqStartVar.Location = new Point(514, 1275);
			this.m_nudChirp42FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp42FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp42FreqStartVar.Name = "m_nudChirp42FreqStartVar";
			this.m_nudChirp42FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp42FreqStartVar.TabIndex = 789;
			this.m_nudChirp42ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp42ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp42ADCStartTimeVar.Location = new Point(756, 1275);
			this.m_nudChirp42ADCStartTimeVar.Margin = new Padding(4);
			int[] array85 = new int[4];
			array85[0] = 4095;
            this.m_nudChirp42ADCStartTimeVar.Maximum = new decimal(array85);
			this.m_nudChirp42ADCStartTimeVar.Name = "m_nudChirp42ADCStartTimeVar";
			this.m_nudChirp42ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp42ADCStartTimeVar.TabIndex = 788;
			this.m_nudChirp42IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp42IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp42IdleTimeVar.Location = new Point(648, 1275);
			this.m_nudChirp42IdleTimeVar.Margin = new Padding(4);
			int[] array86 = new int[4];
			array86[0] = 4095;
            this.m_nudChirp42IdleTimeVar.Maximum = new decimal(array86);
			this.m_nudChirp42IdleTimeVar.Name = "m_nudChirp42IdleTimeVar";
			this.m_nudChirp42IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp42IdleTimeVar.TabIndex = 787;
			this.m_nudChirp41BPMConstVal.Location = new Point(400, 1241);
			this.m_nudChirp41BPMConstVal.Margin = new Padding(4);
			int[] array87 = new int[4];
			array87[0] = 63;
            this.m_nudChirp41BPMConstVal.Maximum = new decimal(array87);
			this.m_nudChirp41BPMConstVal.Name = "m_nudChirp41BPMConstVal";
			this.m_nudChirp41BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp41BPMConstVal.TabIndex = 777;
			this.m_ChbChirp41Tx3Enable.AutoSize = true;
			this.m_ChbChirp41Tx3Enable.Location = new Point(360, 1244);
			this.m_ChbChirp41Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp41Tx3Enable.Name = "m_ChbChirp41Tx3Enable";
			this.m_ChbChirp41Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp41Tx3Enable.TabIndex = 785;
			this.m_ChbChirp41Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp41Tx2Enable.AutoSize = true;
			this.m_ChbChirp41Tx2Enable.Location = new Point(320, 1245);
			this.m_ChbChirp41Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp41Tx2Enable.Name = "m_ChbChirp41Tx2Enable";
			this.m_ChbChirp41Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp41Tx2Enable.TabIndex = 784;
			this.m_ChbChirp41Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp41Tx1Enable.AutoSize = true;
			this.m_ChbChirp41Tx1Enable.Location = new Point(286, 1245);
			this.m_ChbChirp41Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp41Tx1Enable.Name = "m_ChbChirp41Tx1Enable";
			this.m_ChbChirp41Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp41Tx1Enable.TabIndex = 783;
			this.m_ChbChirp41Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp41FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp41FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp41FreqSlopeVar.Location = new Point(179, 1243);
			this.m_nudChirp41FreqSlopeVar.Margin = new Padding(4);
			int[] array88 = new int[4];
			array88[0] = 4;
            this.m_nudChirp41FreqSlopeVar.Maximum = new decimal(array88);
			this.m_nudChirp41FreqSlopeVar.Name = "m_nudChirp41FreqSlopeVar";
			this.m_nudChirp41FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp41FreqSlopeVar.TabIndex = 782;
			this.m_nudChirp41ProfileIndex.Location = new Point(83, 1243);
			this.m_nudChirp41ProfileIndex.Margin = new Padding(4);
			int[] array89 = new int[4];
			array89[0] = 3;
            this.m_nudChirp41ProfileIndex.Maximum = new decimal(array89);
			this.m_nudChirp41ProfileIndex.Name = "m_nudChirp41ProfileIndex";
			this.m_nudChirp41ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp41ProfileIndex.TabIndex = 781;
			this.m_nudChirp41FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp41FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp41FreqStartVar.Location = new Point(514, 1244);
			this.m_nudChirp41FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp41FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp41FreqStartVar.Name = "m_nudChirp41FreqStartVar";
			this.m_nudChirp41FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp41FreqStartVar.TabIndex = 780;
			this.m_nudChirp41ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp41ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp41ADCStartTimeVar.Location = new Point(756, 1244);
			this.m_nudChirp41ADCStartTimeVar.Margin = new Padding(4);
			int[] array90 = new int[4];
			array90[0] = 4095;
            this.m_nudChirp41ADCStartTimeVar.Maximum = new decimal(array90);
			this.m_nudChirp41ADCStartTimeVar.Name = "m_nudChirp41ADCStartTimeVar";
			this.m_nudChirp41ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp41ADCStartTimeVar.TabIndex = 779;
			this.m_nudChirp41IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp41IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp41IdleTimeVar.Location = new Point(648, 1244);
			this.m_nudChirp41IdleTimeVar.Margin = new Padding(4);
			int[] array91 = new int[4];
			array91[0] = 4095;
            this.m_nudChirp41IdleTimeVar.Maximum = new decimal(array91);
			this.m_nudChirp41IdleTimeVar.Name = "m_nudChirp41IdleTimeVar";
			this.m_nudChirp41IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp41IdleTimeVar.TabIndex = 778;
			this.m_nudChirp40BPMConstVal.Location = new Point(400, 1212);
			this.m_nudChirp40BPMConstVal.Margin = new Padding(4);
			int[] array92 = new int[4];
			array92[0] = 63;
            this.m_nudChirp40BPMConstVal.Maximum = new decimal(array92);
			this.m_nudChirp40BPMConstVal.Name = "m_nudChirp40BPMConstVal";
			this.m_nudChirp40BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp40BPMConstVal.TabIndex = 768;
			this.m_ChbChirp40Tx3Enable.AutoSize = true;
			this.m_ChbChirp40Tx3Enable.Location = new Point(360, 1216);
			this.m_ChbChirp40Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp40Tx3Enable.Name = "m_ChbChirp40Tx3Enable";
			this.m_ChbChirp40Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp40Tx3Enable.TabIndex = 776;
			this.m_ChbChirp40Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp40Tx2Enable.AutoSize = true;
			this.m_ChbChirp40Tx2Enable.Location = new Point(320, 1217);
			this.m_ChbChirp40Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp40Tx2Enable.Name = "m_ChbChirp40Tx2Enable";
			this.m_ChbChirp40Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp40Tx2Enable.TabIndex = 775;
			this.m_ChbChirp40Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp40Tx1Enable.AutoSize = true;
			this.m_ChbChirp40Tx1Enable.Location = new Point(286, 1217);
			this.m_ChbChirp40Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp40Tx1Enable.Name = "m_ChbChirp40Tx1Enable";
			this.m_ChbChirp40Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp40Tx1Enable.TabIndex = 774;
			this.m_ChbChirp40Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp40FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp40FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp40FreqSlopeVar.Location = new Point(179, 1215);
			this.m_nudChirp40FreqSlopeVar.Margin = new Padding(4);
			int[] array93 = new int[4];
			array93[0] = 4;
            this.m_nudChirp40FreqSlopeVar.Maximum = new decimal(array93);
			this.m_nudChirp40FreqSlopeVar.Name = "m_nudChirp40FreqSlopeVar";
			this.m_nudChirp40FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp40FreqSlopeVar.TabIndex = 773;
			this.m_nudChirp40ProfileIndex.Location = new Point(83, 1215);
			this.m_nudChirp40ProfileIndex.Margin = new Padding(4);
			int[] array94 = new int[4];
			array94[0] = 3;
            this.m_nudChirp40ProfileIndex.Maximum = new decimal(array94);
			this.m_nudChirp40ProfileIndex.Name = "m_nudChirp40ProfileIndex";
			this.m_nudChirp40ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp40ProfileIndex.TabIndex = 772;
			this.m_nudChirp40FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp40FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp40FreqStartVar.Location = new Point(514, 1216);
			this.m_nudChirp40FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp40FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp40FreqStartVar.Name = "m_nudChirp40FreqStartVar";
			this.m_nudChirp40FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp40FreqStartVar.TabIndex = 771;
			this.m_nudChirp40ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp40ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp40ADCStartTimeVar.Location = new Point(756, 1216);
			this.m_nudChirp40ADCStartTimeVar.Margin = new Padding(4);
			int[] array95 = new int[4];
			array95[0] = 4095;
            this.m_nudChirp40ADCStartTimeVar.Maximum = new decimal(array95);
			this.m_nudChirp40ADCStartTimeVar.Name = "m_nudChirp40ADCStartTimeVar";
			this.m_nudChirp40ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp40ADCStartTimeVar.TabIndex = 770;
			this.m_nudChirp40IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp40IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp40IdleTimeVar.Location = new Point(648, 1216);
			this.m_nudChirp40IdleTimeVar.Margin = new Padding(4);
			int[] array96 = new int[4];
			array96[0] = 4095;
            this.m_nudChirp40IdleTimeVar.Maximum = new decimal(array96);
			this.m_nudChirp40IdleTimeVar.Name = "m_nudChirp40IdleTimeVar";
			this.m_nudChirp40IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp40IdleTimeVar.TabIndex = 769;
			this.label67.AutoSize = true;
			this.label67.Location = new Point(3, 1466);
			this.label67.Margin = new Padding(4, 0, 4, 0);
			this.label67.Name = "label67";
			this.label67.Size = new Size(61, 17);
			this.label67.TabIndex = 765;
			this.label67.Text = "Chirp 48";
			this.label69.AutoSize = true;
			this.label69.Location = new Point(3, 1403);
			this.label69.Margin = new Padding(4, 0, 4, 0);
			this.label69.Name = "label69";
			this.label69.Size = new Size(61, 17);
			this.label69.TabIndex = 763;
			this.label69.Text = "Chirp 46";
			this.label70.AutoSize = true;
			this.label70.Location = new Point(3, 1434);
			this.label70.Margin = new Padding(4, 0, 4, 0);
			this.label70.Name = "label70";
			this.label70.Size = new Size(61, 17);
			this.label70.TabIndex = 762;
			this.label70.Text = "Chirp 47";
			this.label71.AutoSize = true;
			this.label71.Location = new Point(4, 1219);
			this.label71.Margin = new Padding(4, 0, 4, 0);
			this.label71.Name = "label71";
			this.label71.Size = new Size(61, 17);
			this.label71.TabIndex = 761;
			this.label71.Text = "Chirp 40";
			this.label72.AutoSize = true;
			this.label72.Location = new Point(3, 1345);
			this.label72.Margin = new Padding(4, 0, 4, 0);
			this.label72.Name = "label72";
			this.label72.Size = new Size(61, 17);
			this.label72.TabIndex = 760;
			this.label72.Text = "Chirp 44";
			this.label73.AutoSize = true;
			this.label73.Location = new Point(3, 1376);
			this.label73.Margin = new Padding(4, 0, 4, 0);
			this.label73.Name = "label73";
			this.label73.Size = new Size(61, 17);
			this.label73.TabIndex = 759;
			this.label73.Text = "Chirp 45";
			this.label74.AutoSize = true;
			this.label74.Location = new Point(4, 1247);
			this.label74.Margin = new Padding(4, 0, 4, 0);
			this.label74.Name = "label74";
			this.label74.Size = new Size(61, 17);
			this.label74.TabIndex = 758;
			this.label74.Text = "Chirp 41";
			this.label75.AutoSize = true;
			this.label75.Location = new Point(4, 1277);
			this.label75.Margin = new Padding(4, 0, 4, 0);
			this.label75.Name = "label75";
			this.label75.Size = new Size(61, 17);
			this.label75.TabIndex = 757;
			this.label75.Text = "Chirp 42";
			this.label76.AutoSize = true;
			this.label76.Location = new Point(4, 1308);
			this.label76.Margin = new Padding(4, 0, 4, 0);
			this.label76.Name = "label76";
			this.label76.Size = new Size(61, 17);
			this.label76.TabIndex = 756;
			this.label76.Text = "Chirp 43";
			this.m_nudChirp39BPMConstVal.Location = new Point(400, 1179);
			this.m_nudChirp39BPMConstVal.Margin = new Padding(4);
			int[] array97 = new int[4];
			array97[0] = 63;
            this.m_nudChirp39BPMConstVal.Maximum = new decimal(array97);
			this.m_nudChirp39BPMConstVal.Name = "m_nudChirp39BPMConstVal";
			this.m_nudChirp39BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp39BPMConstVal.TabIndex = 747;
			this.m_ChbChirp39Tx3Enable.AutoSize = true;
			this.m_ChbChirp39Tx3Enable.Location = new Point(360, 1183);
			this.m_ChbChirp39Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp39Tx3Enable.Name = "m_ChbChirp39Tx3Enable";
			this.m_ChbChirp39Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp39Tx3Enable.TabIndex = 755;
			this.m_ChbChirp39Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp39Tx2Enable.AutoSize = true;
			this.m_ChbChirp39Tx2Enable.Location = new Point(320, 1184);
			this.m_ChbChirp39Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp39Tx2Enable.Name = "m_ChbChirp39Tx2Enable";
			this.m_ChbChirp39Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp39Tx2Enable.TabIndex = 754;
			this.m_ChbChirp39Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp39Tx1Enable.AutoSize = true;
			this.m_ChbChirp39Tx1Enable.Location = new Point(286, 1184);
			this.m_ChbChirp39Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp39Tx1Enable.Name = "m_ChbChirp39Tx1Enable";
			this.m_ChbChirp39Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp39Tx1Enable.TabIndex = 753;
			this.m_ChbChirp39Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp39FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp39FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp39FreqSlopeVar.Location = new Point(179, 1182);
			this.m_nudChirp39FreqSlopeVar.Margin = new Padding(4);
			int[] array98 = new int[4];
			array98[0] = 4;
            this.m_nudChirp39FreqSlopeVar.Maximum = new decimal(array98);
			this.m_nudChirp39FreqSlopeVar.Name = "m_nudChirp39FreqSlopeVar";
			this.m_nudChirp39FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp39FreqSlopeVar.TabIndex = 752;
			this.m_nudChirp39ProfileIndex.Location = new Point(83, 1182);
			this.m_nudChirp39ProfileIndex.Margin = new Padding(4);
			int[] array99 = new int[4];
			array99[0] = 3;
            this.m_nudChirp39ProfileIndex.Maximum = new decimal(array99);
			this.m_nudChirp39ProfileIndex.Name = "m_nudChirp39ProfileIndex";
			this.m_nudChirp39ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp39ProfileIndex.TabIndex = 751;
			this.m_nudChirp39FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp39FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp39FreqStartVar.Location = new Point(514, 1183);
			this.m_nudChirp39FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp39FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp39FreqStartVar.Name = "m_nudChirp39FreqStartVar";
			this.m_nudChirp39FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp39FreqStartVar.TabIndex = 750;
			this.m_nudChirp39ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp39ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp39ADCStartTimeVar.Location = new Point(756, 1183);
			this.m_nudChirp39ADCStartTimeVar.Margin = new Padding(4);
			int[] array100 = new int[4];
			array100[0] = 4095;
            this.m_nudChirp39ADCStartTimeVar.Maximum = new decimal(array100);
			this.m_nudChirp39ADCStartTimeVar.Name = "m_nudChirp39ADCStartTimeVar";
			this.m_nudChirp39ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp39ADCStartTimeVar.TabIndex = 749;
			this.m_nudChirp39IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp39IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp39IdleTimeVar.Location = new Point(648, 1183);
			this.m_nudChirp39IdleTimeVar.Margin = new Padding(4);
			int[] array101 = new int[4];
			array101[0] = 4095;
            this.m_nudChirp39IdleTimeVar.Maximum = new decimal(array101);
			this.m_nudChirp39IdleTimeVar.Name = "m_nudChirp39IdleTimeVar";
			this.m_nudChirp39IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp39IdleTimeVar.TabIndex = 748;
			this.m_nudChirp37BPMConstVal.Location = new Point(400, 1118);
			this.m_nudChirp37BPMConstVal.Margin = new Padding(4);
			int[] array102 = new int[4];
			array102[0] = 63;
            this.m_nudChirp37BPMConstVal.Maximum = new decimal(array102);
			this.m_nudChirp37BPMConstVal.Name = "m_nudChirp37BPMConstVal";
			this.m_nudChirp37BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp37BPMConstVal.TabIndex = 738;
			this.m_ChbChirp37Tx3Enable.AutoSize = true;
			this.m_ChbChirp37Tx3Enable.Location = new Point(360, 1122);
			this.m_ChbChirp37Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp37Tx3Enable.Name = "m_ChbChirp37Tx3Enable";
			this.m_ChbChirp37Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp37Tx3Enable.TabIndex = 746;
			this.m_ChbChirp37Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp37Tx2Enable.AutoSize = true;
			this.m_ChbChirp37Tx2Enable.Location = new Point(320, 1123);
			this.m_ChbChirp37Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp37Tx2Enable.Name = "m_ChbChirp37Tx2Enable";
			this.m_ChbChirp37Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp37Tx2Enable.TabIndex = 745;
			this.m_ChbChirp37Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp37Tx1Enable.AutoSize = true;
			this.m_ChbChirp37Tx1Enable.Location = new Point(286, 1123);
			this.m_ChbChirp37Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp37Tx1Enable.Name = "m_ChbChirp37Tx1Enable";
			this.m_ChbChirp37Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp37Tx1Enable.TabIndex = 744;
			this.m_ChbChirp37Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp37FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp37FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp37FreqSlopeVar.Location = new Point(179, 1120);
			this.m_nudChirp37FreqSlopeVar.Margin = new Padding(4);
			int[] array103 = new int[4];
			array103[0] = 4;
            this.m_nudChirp37FreqSlopeVar.Maximum = new decimal(array103);
			this.m_nudChirp37FreqSlopeVar.Name = "m_nudChirp37FreqSlopeVar";
			this.m_nudChirp37FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp37FreqSlopeVar.TabIndex = 743;
			this.m_nudChirp37ProfileIndex.Location = new Point(83, 1120);
			this.m_nudChirp37ProfileIndex.Margin = new Padding(4);
			int[] array104 = new int[4];
			array104[0] = 3;
            this.m_nudChirp37ProfileIndex.Maximum = new decimal(array104);
			this.m_nudChirp37ProfileIndex.Name = "m_nudChirp37ProfileIndex";
			this.m_nudChirp37ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp37ProfileIndex.TabIndex = 742;
			this.m_nudChirp37FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp37FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp37FreqStartVar.Location = new Point(514, 1122);
			this.m_nudChirp37FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp37FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp37FreqStartVar.Name = "m_nudChirp37FreqStartVar";
			this.m_nudChirp37FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp37FreqStartVar.TabIndex = 741;
			this.m_nudChirp37ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp37ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp37ADCStartTimeVar.Location = new Point(756, 1122);
			this.m_nudChirp37ADCStartTimeVar.Margin = new Padding(4);
			int[] array105 = new int[4];
			array105[0] = 4095;
            this.m_nudChirp37ADCStartTimeVar.Maximum = new decimal(array105);
			this.m_nudChirp37ADCStartTimeVar.Name = "m_nudChirp37ADCStartTimeVar";
			this.m_nudChirp37ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp37ADCStartTimeVar.TabIndex = 740;
			this.m_nudChirp37IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp37IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp37IdleTimeVar.Location = new Point(648, 1122);
			this.m_nudChirp37IdleTimeVar.Margin = new Padding(4);
			int[] array106 = new int[4];
			array106[0] = 4095;
            this.m_nudChirp37IdleTimeVar.Maximum = new decimal(array106);
			this.m_nudChirp37IdleTimeVar.Name = "m_nudChirp37IdleTimeVar";
			this.m_nudChirp37IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp37IdleTimeVar.TabIndex = 739;
			this.m_nudChirp38BPMConstVal.Location = new Point(400, 1147);
			this.m_nudChirp38BPMConstVal.Margin = new Padding(4);
			int[] array107 = new int[4];
			array107[0] = 63;
            this.m_nudChirp38BPMConstVal.Maximum = new decimal(array107);
			this.m_nudChirp38BPMConstVal.Name = "m_nudChirp38BPMConstVal";
			this.m_nudChirp38BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp38BPMConstVal.TabIndex = 729;
			this.m_ChbChirp38Tx3Enable.AutoSize = true;
			this.m_ChbChirp38Tx3Enable.Location = new Point(360, 1151);
			this.m_ChbChirp38Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp38Tx3Enable.Name = "m_ChbChirp38Tx3Enable";
			this.m_ChbChirp38Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp38Tx3Enable.TabIndex = 737;
			this.m_ChbChirp38Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp38Tx2Enable.AutoSize = true;
			this.m_ChbChirp38Tx2Enable.Location = new Point(320, 1152);
			this.m_ChbChirp38Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp38Tx2Enable.Name = "m_ChbChirp38Tx2Enable";
			this.m_ChbChirp38Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp38Tx2Enable.TabIndex = 736;
			this.m_ChbChirp38Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp38Tx1Enable.AutoSize = true;
			this.m_ChbChirp38Tx1Enable.Location = new Point(286, 1152);
			this.m_ChbChirp38Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp38Tx1Enable.Name = "m_ChbChirp38Tx1Enable";
			this.m_ChbChirp38Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp38Tx1Enable.TabIndex = 735;
			this.m_ChbChirp38Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp38FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp38FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp38FreqSlopeVar.Location = new Point(179, 1150);
			this.m_nudChirp38FreqSlopeVar.Margin = new Padding(4);
			int[] array108 = new int[4];
			array108[0] = 4;
            this.m_nudChirp38FreqSlopeVar.Maximum = new decimal(array108);
			this.m_nudChirp38FreqSlopeVar.Name = "m_nudChirp38FreqSlopeVar";
			this.m_nudChirp38FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp38FreqSlopeVar.TabIndex = 734;
			this.m_nudChirp38ProfileIndex.Location = new Point(83, 1150);
			this.m_nudChirp38ProfileIndex.Margin = new Padding(4);
			int[] array109 = new int[4];
			array109[0] = 3;
            this.m_nudChirp38ProfileIndex.Maximum = new decimal(array109);
			this.m_nudChirp38ProfileIndex.Name = "m_nudChirp38ProfileIndex";
			this.m_nudChirp38ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp38ProfileIndex.TabIndex = 733;
			this.m_nudChirp38FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp38FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp38FreqStartVar.Location = new Point(514, 1151);
			this.m_nudChirp38FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp38FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp38FreqStartVar.Name = "m_nudChirp38FreqStartVar";
			this.m_nudChirp38FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp38FreqStartVar.TabIndex = 732;
			this.m_nudChirp38ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp38ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp38ADCStartTimeVar.Location = new Point(756, 1151);
			this.m_nudChirp38ADCStartTimeVar.Margin = new Padding(4);
			int[] array110 = new int[4];
			array110[0] = 4095;
            this.m_nudChirp38ADCStartTimeVar.Maximum = new decimal(array110);
			this.m_nudChirp38ADCStartTimeVar.Name = "m_nudChirp38ADCStartTimeVar";
			this.m_nudChirp38ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp38ADCStartTimeVar.TabIndex = 731;
			this.m_nudChirp38IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp38IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp38IdleTimeVar.Location = new Point(648, 1151);
			this.m_nudChirp38IdleTimeVar.Margin = new Padding(4);
			int[] array111 = new int[4];
			array111[0] = 4095;
            this.m_nudChirp38IdleTimeVar.Maximum = new decimal(array111);
			this.m_nudChirp38IdleTimeVar.Name = "m_nudChirp38IdleTimeVar";
			this.m_nudChirp38IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp38IdleTimeVar.TabIndex = 730;
			this.m_nudChirp36BPMConstVal.Location = new Point(400, 1086);
			this.m_nudChirp36BPMConstVal.Margin = new Padding(4);
			int[] array112 = new int[4];
			array112[0] = 63;
            this.m_nudChirp36BPMConstVal.Maximum = new decimal(array112);
			this.m_nudChirp36BPMConstVal.Name = "m_nudChirp36BPMConstVal";
			this.m_nudChirp36BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp36BPMConstVal.TabIndex = 720;
			this.m_ChbChirp36Tx3Enable.AutoSize = true;
			this.m_ChbChirp36Tx3Enable.Location = new Point(360, 1090);
			this.m_ChbChirp36Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp36Tx3Enable.Name = "m_ChbChirp36Tx3Enable";
			this.m_ChbChirp36Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp36Tx3Enable.TabIndex = 728;
			this.m_ChbChirp36Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp36Tx2Enable.AutoSize = true;
			this.m_ChbChirp36Tx2Enable.Location = new Point(320, 1091);
			this.m_ChbChirp36Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp36Tx2Enable.Name = "m_ChbChirp36Tx2Enable";
			this.m_ChbChirp36Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp36Tx2Enable.TabIndex = 727;
			this.m_ChbChirp36Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp36Tx1Enable.AutoSize = true;
			this.m_ChbChirp36Tx1Enable.Location = new Point(286, 1091);
			this.m_ChbChirp36Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp36Tx1Enable.Name = "m_ChbChirp36Tx1Enable";
			this.m_ChbChirp36Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp36Tx1Enable.TabIndex = 726;
			this.m_ChbChirp36Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp36FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp36FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp36FreqSlopeVar.Location = new Point(179, 1088);
			this.m_nudChirp36FreqSlopeVar.Margin = new Padding(4);
			int[] array113 = new int[4];
			array113[0] = 4;
            this.m_nudChirp36FreqSlopeVar.Maximum = new decimal(array113);
			this.m_nudChirp36FreqSlopeVar.Name = "m_nudChirp36FreqSlopeVar";
			this.m_nudChirp36FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp36FreqSlopeVar.TabIndex = 725;
			this.m_nudChirp36ProfileIndex.Location = new Point(83, 1088);
			this.m_nudChirp36ProfileIndex.Margin = new Padding(4);
			int[] array114 = new int[4];
			array114[0] = 3;
            this.m_nudChirp36ProfileIndex.Maximum = new decimal(array114);
			this.m_nudChirp36ProfileIndex.Name = "m_nudChirp36ProfileIndex";
			this.m_nudChirp36ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp36ProfileIndex.TabIndex = 724;
			this.m_nudChirp36FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp36FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp36FreqStartVar.Location = new Point(514, 1090);
			this.m_nudChirp36FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp36FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp36FreqStartVar.Name = "m_nudChirp36FreqStartVar";
			this.m_nudChirp36FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp36FreqStartVar.TabIndex = 723;
			this.m_nudChirp36ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp36ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp36ADCStartTimeVar.Location = new Point(756, 1090);
			this.m_nudChirp36ADCStartTimeVar.Margin = new Padding(4);
			int[] array115 = new int[4];
			array115[0] = 4095;
            this.m_nudChirp36ADCStartTimeVar.Maximum = new decimal(array115);
			this.m_nudChirp36ADCStartTimeVar.Name = "m_nudChirp36ADCStartTimeVar";
			this.m_nudChirp36ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp36ADCStartTimeVar.TabIndex = 722;
			this.m_nudChirp36IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp36IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp36IdleTimeVar.Location = new Point(648, 1090);
			this.m_nudChirp36IdleTimeVar.Margin = new Padding(4);
			int[] array116 = new int[4];
			array116[0] = 4095;
            this.m_nudChirp36IdleTimeVar.Maximum = new decimal(array116);
			this.m_nudChirp36IdleTimeVar.Name = "m_nudChirp36IdleTimeVar";
			this.m_nudChirp36IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp36IdleTimeVar.TabIndex = 721;
			this.m_nudChirp35BPMConstVal.Location = new Point(400, 1054);
			this.m_nudChirp35BPMConstVal.Margin = new Padding(4);
			int[] array117 = new int[4];
			array117[0] = 63;
            this.m_nudChirp35BPMConstVal.Maximum = new decimal(array117);
			this.m_nudChirp35BPMConstVal.Name = "m_nudChirp35BPMConstVal";
			this.m_nudChirp35BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp35BPMConstVal.TabIndex = 711;
			this.m_ChbChirp35Tx3Enable.AutoSize = true;
			this.m_ChbChirp35Tx3Enable.Location = new Point(360, 1058);
			this.m_ChbChirp35Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp35Tx3Enable.Name = "m_ChbChirp35Tx3Enable";
			this.m_ChbChirp35Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp35Tx3Enable.TabIndex = 719;
			this.m_ChbChirp35Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp35Tx2Enable.AutoSize = true;
			this.m_ChbChirp35Tx2Enable.Location = new Point(320, 1059);
			this.m_ChbChirp35Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp35Tx2Enable.Name = "m_ChbChirp35Tx2Enable";
			this.m_ChbChirp35Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp35Tx2Enable.TabIndex = 718;
			this.m_ChbChirp35Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp35Tx1Enable.AutoSize = true;
			this.m_ChbChirp35Tx1Enable.Location = new Point(286, 1059);
			this.m_ChbChirp35Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp35Tx1Enable.Name = "m_ChbChirp35Tx1Enable";
			this.m_ChbChirp35Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp35Tx1Enable.TabIndex = 717;
			this.m_ChbChirp35Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp35FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp35FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp35FreqSlopeVar.Location = new Point(179, 1056);
			this.m_nudChirp35FreqSlopeVar.Margin = new Padding(4);
			int[] array118 = new int[4];
			array118[0] = 4;
            this.m_nudChirp35FreqSlopeVar.Maximum = new decimal(array118);
			this.m_nudChirp35FreqSlopeVar.Name = "m_nudChirp35FreqSlopeVar";
			this.m_nudChirp35FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp35FreqSlopeVar.TabIndex = 716;
			this.m_nudChirp35ProfileIndex.Location = new Point(83, 1056);
			this.m_nudChirp35ProfileIndex.Margin = new Padding(4);
			int[] array119 = new int[4];
			array119[0] = 3;
            this.m_nudChirp35ProfileIndex.Maximum = new decimal(array119);
			this.m_nudChirp35ProfileIndex.Name = "m_nudChirp35ProfileIndex";
			this.m_nudChirp35ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp35ProfileIndex.TabIndex = 715;
			this.m_nudChirp35FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp35FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp35FreqStartVar.Location = new Point(514, 1058);
			this.m_nudChirp35FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp35FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp35FreqStartVar.Name = "m_nudChirp35FreqStartVar";
			this.m_nudChirp35FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp35FreqStartVar.TabIndex = 714;
			this.m_nudChirp35ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp35ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp35ADCStartTimeVar.Location = new Point(756, 1058);
			this.m_nudChirp35ADCStartTimeVar.Margin = new Padding(4);
			int[] array120 = new int[4];
			array120[0] = 4095;
            this.m_nudChirp35ADCStartTimeVar.Maximum = new decimal(array120);
			this.m_nudChirp35ADCStartTimeVar.Name = "m_nudChirp35ADCStartTimeVar";
			this.m_nudChirp35ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp35ADCStartTimeVar.TabIndex = 713;
			this.m_nudChirp35IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp35IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp35IdleTimeVar.Location = new Point(648, 1058);
			this.m_nudChirp35IdleTimeVar.Margin = new Padding(4);
			int[] array121 = new int[4];
			array121[0] = 4095;
            this.m_nudChirp35IdleTimeVar.Maximum = new decimal(array121);
			this.m_nudChirp35IdleTimeVar.Name = "m_nudChirp35IdleTimeVar";
			this.m_nudChirp35IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp35IdleTimeVar.TabIndex = 712;
			this.m_nudChirp34BPMConstVal.Location = new Point(400, 1023);
			this.m_nudChirp34BPMConstVal.Margin = new Padding(4);
			int[] array122 = new int[4];
			array122[0] = 63;
            this.m_nudChirp34BPMConstVal.Maximum = new decimal(array122);
			this.m_nudChirp34BPMConstVal.Name = "m_nudChirp34BPMConstVal";
			this.m_nudChirp34BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp34BPMConstVal.TabIndex = 702;
			this.m_ChbChirp34Tx3Enable.AutoSize = true;
			this.m_ChbChirp34Tx3Enable.Location = new Point(360, 1027);
			this.m_ChbChirp34Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp34Tx3Enable.Name = "m_ChbChirp34Tx3Enable";
			this.m_ChbChirp34Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp34Tx3Enable.TabIndex = 710;
			this.m_ChbChirp34Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp34Tx2Enable.AutoSize = true;
			this.m_ChbChirp34Tx2Enable.Location = new Point(320, 1028);
			this.m_ChbChirp34Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp34Tx2Enable.Name = "m_ChbChirp34Tx2Enable";
			this.m_ChbChirp34Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp34Tx2Enable.TabIndex = 709;
			this.m_ChbChirp34Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp34Tx1Enable.AutoSize = true;
			this.m_ChbChirp34Tx1Enable.Location = new Point(286, 1028);
			this.m_ChbChirp34Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp34Tx1Enable.Name = "m_ChbChirp34Tx1Enable";
			this.m_ChbChirp34Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp34Tx1Enable.TabIndex = 708;
			this.m_ChbChirp34Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp34FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp34FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp34FreqSlopeVar.Location = new Point(179, 1026);
			this.m_nudChirp34FreqSlopeVar.Margin = new Padding(4);
			int[] array123 = new int[4];
			array123[0] = 4;
            this.m_nudChirp34FreqSlopeVar.Maximum = new decimal(array123);
			this.m_nudChirp34FreqSlopeVar.Name = "m_nudChirp34FreqSlopeVar";
			this.m_nudChirp34FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp34FreqSlopeVar.TabIndex = 707;
			this.m_nudChirp34ProfileIndex.Location = new Point(83, 1026);
			this.m_nudChirp34ProfileIndex.Margin = new Padding(4);
			int[] array124 = new int[4];
			array124[0] = 3;
            this.m_nudChirp34ProfileIndex.Maximum = new decimal(array124);
			this.m_nudChirp34ProfileIndex.Name = "m_nudChirp34ProfileIndex";
			this.m_nudChirp34ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp34ProfileIndex.TabIndex = 706;
			this.m_nudChirp34FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp34FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp34FreqStartVar.Location = new Point(514, 1027);
			this.m_nudChirp34FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp34FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp34FreqStartVar.Name = "m_nudChirp34FreqStartVar";
			this.m_nudChirp34FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp34FreqStartVar.TabIndex = 705;
			this.m_nudChirp34ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp34ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp34ADCStartTimeVar.Location = new Point(756, 1027);
			this.m_nudChirp34ADCStartTimeVar.Margin = new Padding(4);
			int[] array125 = new int[4];
			array125[0] = 4095;
            this.m_nudChirp34ADCStartTimeVar.Maximum = new decimal(array125);
			this.m_nudChirp34ADCStartTimeVar.Name = "m_nudChirp34ADCStartTimeVar";
			this.m_nudChirp34ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp34ADCStartTimeVar.TabIndex = 704;
			this.m_nudChirp34IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp34IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp34IdleTimeVar.Location = new Point(648, 1027);
			this.m_nudChirp34IdleTimeVar.Margin = new Padding(4);
			int[] array126 = new int[4];
			array126[0] = 4095;
            this.m_nudChirp34IdleTimeVar.Maximum = new decimal(array126);
			this.m_nudChirp34IdleTimeVar.Name = "m_nudChirp34IdleTimeVar";
			this.m_nudChirp34IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp34IdleTimeVar.TabIndex = 703;
			this.m_nudChirp32BPMConstVal.Location = new Point(400, 965);
			this.m_nudChirp32BPMConstVal.Margin = new Padding(4);
			int[] array127 = new int[4];
			array127[0] = 63;
            this.m_nudChirp32BPMConstVal.Maximum = new decimal(array127);
			this.m_nudChirp32BPMConstVal.Name = "m_nudChirp32BPMConstVal";
			this.m_nudChirp32BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp32BPMConstVal.TabIndex = 693;
			this.m_ChbChirp32Tx3Enable.AutoSize = true;
			this.m_ChbChirp32Tx3Enable.Location = new Point(360, 969);
			this.m_ChbChirp32Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp32Tx3Enable.Name = "m_ChbChirp32Tx3Enable";
			this.m_ChbChirp32Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp32Tx3Enable.TabIndex = 701;
			this.m_ChbChirp32Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp32Tx2Enable.AutoSize = true;
			this.m_ChbChirp32Tx2Enable.Location = new Point(320, 970);
			this.m_ChbChirp32Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp32Tx2Enable.Name = "m_ChbChirp32Tx2Enable";
			this.m_ChbChirp32Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp32Tx2Enable.TabIndex = 700;
			this.m_ChbChirp32Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp32Tx1Enable.AutoSize = true;
			this.m_ChbChirp32Tx1Enable.Location = new Point(286, 970);
			this.m_ChbChirp32Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp32Tx1Enable.Name = "m_ChbChirp32Tx1Enable";
			this.m_ChbChirp32Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp32Tx1Enable.TabIndex = 699;
			this.m_ChbChirp32Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp32FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp32FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp32FreqSlopeVar.Location = new Point(179, 968);
			this.m_nudChirp32FreqSlopeVar.Margin = new Padding(4);
			int[] array128 = new int[4];
			array128[0] = 4;
            this.m_nudChirp32FreqSlopeVar.Maximum = new decimal(array128);
			this.m_nudChirp32FreqSlopeVar.Name = "m_nudChirp32FreqSlopeVar";
			this.m_nudChirp32FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp32FreqSlopeVar.TabIndex = 698;
			this.m_nudChirp32ProfileIndex.Location = new Point(83, 968);
			this.m_nudChirp32ProfileIndex.Margin = new Padding(4);
			int[] array129 = new int[4];
			array129[0] = 3;
            this.m_nudChirp32ProfileIndex.Maximum = new decimal(array129);
			this.m_nudChirp32ProfileIndex.Name = "m_nudChirp32ProfileIndex";
			this.m_nudChirp32ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp32ProfileIndex.TabIndex = 697;
			this.m_nudChirp32FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp32FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp32FreqStartVar.Location = new Point(514, 969);
			this.m_nudChirp32FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp32FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp32FreqStartVar.Name = "m_nudChirp32FreqStartVar";
			this.m_nudChirp32FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp32FreqStartVar.TabIndex = 696;
			this.m_nudChirp32ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp32ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp32ADCStartTimeVar.Location = new Point(756, 969);
			this.m_nudChirp32ADCStartTimeVar.Margin = new Padding(4);
			int[] array130 = new int[4];
			array130[0] = 4095;
            this.m_nudChirp32ADCStartTimeVar.Maximum = new decimal(array130);
			this.m_nudChirp32ADCStartTimeVar.Name = "m_nudChirp32ADCStartTimeVar";
			this.m_nudChirp32ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp32ADCStartTimeVar.TabIndex = 695;
			this.m_nudChirp32IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp32IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp32IdleTimeVar.Location = new Point(648, 969);
			this.m_nudChirp32IdleTimeVar.Margin = new Padding(4);
			int[] array131 = new int[4];
			array131[0] = 4095;
            this.m_nudChirp32IdleTimeVar.Maximum = new decimal(array131);
			this.m_nudChirp32IdleTimeVar.Name = "m_nudChirp32IdleTimeVar";
			this.m_nudChirp32IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp32IdleTimeVar.TabIndex = 694;
			this.m_nudChirp33BPMConstVal.Location = new Point(400, 995);
			this.m_nudChirp33BPMConstVal.Margin = new Padding(4);
			int[] array132 = new int[4];
			array132[0] = 63;
            this.m_nudChirp33BPMConstVal.Maximum = new decimal(array132);
			this.m_nudChirp33BPMConstVal.Name = "m_nudChirp33BPMConstVal";
			this.m_nudChirp33BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp33BPMConstVal.TabIndex = 684;
			this.m_ChbChirp33Tx3Enable.AutoSize = true;
			this.m_ChbChirp33Tx3Enable.Location = new Point(360, 999);
			this.m_ChbChirp33Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp33Tx3Enable.Name = "m_ChbChirp33Tx3Enable";
			this.m_ChbChirp33Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp33Tx3Enable.TabIndex = 692;
			this.m_ChbChirp33Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp33Tx2Enable.AutoSize = true;
			this.m_ChbChirp33Tx2Enable.Location = new Point(320, 1000);
			this.m_ChbChirp33Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp33Tx2Enable.Name = "m_ChbChirp33Tx2Enable";
			this.m_ChbChirp33Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp33Tx2Enable.TabIndex = 691;
			this.m_ChbChirp33Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp33Tx1Enable.AutoSize = true;
			this.m_ChbChirp33Tx1Enable.Location = new Point(286, 1000);
			this.m_ChbChirp33Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp33Tx1Enable.Name = "m_ChbChirp33Tx1Enable";
			this.m_ChbChirp33Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp33Tx1Enable.TabIndex = 690;
			this.m_ChbChirp33Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp33FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp33FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp33FreqSlopeVar.Location = new Point(179, 997);
			this.m_nudChirp33FreqSlopeVar.Margin = new Padding(4);
			int[] array133 = new int[4];
			array133[0] = 4;
            this.m_nudChirp33FreqSlopeVar.Maximum = new decimal(array133);
			this.m_nudChirp33FreqSlopeVar.Name = "m_nudChirp33FreqSlopeVar";
			this.m_nudChirp33FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp33FreqSlopeVar.TabIndex = 689;
			this.m_nudChirp33ProfileIndex.Location = new Point(83, 997);
			this.m_nudChirp33ProfileIndex.Margin = new Padding(4);
			int[] array134 = new int[4];
			array134[0] = 3;
            this.m_nudChirp33ProfileIndex.Maximum = new decimal(array134);
			this.m_nudChirp33ProfileIndex.Name = "m_nudChirp33ProfileIndex";
			this.m_nudChirp33ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp33ProfileIndex.TabIndex = 688;
			this.m_nudChirp33FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp33FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp33FreqStartVar.Location = new Point(514, 999);
			this.m_nudChirp33FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp33FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp33FreqStartVar.Name = "m_nudChirp33FreqStartVar";
			this.m_nudChirp33FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp33FreqStartVar.TabIndex = 687;
			this.m_nudChirp33ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp33ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp33ADCStartTimeVar.Location = new Point(756, 999);
			this.m_nudChirp33ADCStartTimeVar.Margin = new Padding(4);
			int[] array135 = new int[4];
			array135[0] = 4095;
            this.m_nudChirp33ADCStartTimeVar.Maximum = new decimal(array135);
			this.m_nudChirp33ADCStartTimeVar.Name = "m_nudChirp33ADCStartTimeVar";
			this.m_nudChirp33ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp33ADCStartTimeVar.TabIndex = 686;
			this.m_nudChirp33IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp33IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp33IdleTimeVar.Location = new Point(648, 999);
			this.m_nudChirp33IdleTimeVar.Margin = new Padding(4);
			int[] array136 = new int[4];
			array136[0] = 4095;
            this.m_nudChirp33IdleTimeVar.Maximum = new decimal(array136);
			this.m_nudChirp33IdleTimeVar.Name = "m_nudChirp33IdleTimeVar";
			this.m_nudChirp33IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp33IdleTimeVar.TabIndex = 685;
			this.m_nudChirp31BPMConstVal.Location = new Point(400, 933);
			this.m_nudChirp31BPMConstVal.Margin = new Padding(4);
			int[] array137 = new int[4];
			array137[0] = 63;
            this.m_nudChirp31BPMConstVal.Maximum = new decimal(array137);
			this.m_nudChirp31BPMConstVal.Name = "m_nudChirp31BPMConstVal";
			this.m_nudChirp31BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp31BPMConstVal.TabIndex = 675;
			this.m_ChbChirp31Tx3Enable.AutoSize = true;
			this.m_ChbChirp31Tx3Enable.Location = new Point(360, 937);
			this.m_ChbChirp31Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp31Tx3Enable.Name = "m_ChbChirp31Tx3Enable";
			this.m_ChbChirp31Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp31Tx3Enable.TabIndex = 683;
			this.m_ChbChirp31Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp31Tx2Enable.AutoSize = true;
			this.m_ChbChirp31Tx2Enable.Location = new Point(320, 938);
			this.m_ChbChirp31Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp31Tx2Enable.Name = "m_ChbChirp31Tx2Enable";
			this.m_ChbChirp31Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp31Tx2Enable.TabIndex = 682;
			this.m_ChbChirp31Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp31Tx1Enable.AutoSize = true;
			this.m_ChbChirp31Tx1Enable.Location = new Point(286, 938);
			this.m_ChbChirp31Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp31Tx1Enable.Name = "m_ChbChirp31Tx1Enable";
			this.m_ChbChirp31Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp31Tx1Enable.TabIndex = 681;
			this.m_ChbChirp31Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp31FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp31FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp31FreqSlopeVar.Location = new Point(179, 936);
			this.m_nudChirp31FreqSlopeVar.Margin = new Padding(4);
			int[] array138 = new int[4];
			array138[0] = 4;
            this.m_nudChirp31FreqSlopeVar.Maximum = new decimal(array138);
			this.m_nudChirp31FreqSlopeVar.Name = "m_nudChirp31FreqSlopeVar";
			this.m_nudChirp31FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp31FreqSlopeVar.TabIndex = 680;
			this.m_nudChirp31ProfileIndex.Location = new Point(83, 936);
			this.m_nudChirp31ProfileIndex.Margin = new Padding(4);
			int[] array139 = new int[4];
			array139[0] = 3;
            this.m_nudChirp31ProfileIndex.Maximum = new decimal(array139);
			this.m_nudChirp31ProfileIndex.Name = "m_nudChirp31ProfileIndex";
			this.m_nudChirp31ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp31ProfileIndex.TabIndex = 679;
			this.m_nudChirp31FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp31FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp31FreqStartVar.Location = new Point(514, 937);
			this.m_nudChirp31FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp31FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp31FreqStartVar.Name = "m_nudChirp31FreqStartVar";
			this.m_nudChirp31FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp31FreqStartVar.TabIndex = 678;
			this.m_nudChirp31ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp31ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp31ADCStartTimeVar.Location = new Point(756, 937);
			this.m_nudChirp31ADCStartTimeVar.Margin = new Padding(4);
			int[] array140 = new int[4];
			array140[0] = 4095;
            this.m_nudChirp31ADCStartTimeVar.Maximum = new decimal(array140);
			this.m_nudChirp31ADCStartTimeVar.Name = "m_nudChirp31ADCStartTimeVar";
			this.m_nudChirp31ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp31ADCStartTimeVar.TabIndex = 677;
			this.m_nudChirp31IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp31IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp31IdleTimeVar.Location = new Point(648, 937);
			this.m_nudChirp31IdleTimeVar.Margin = new Padding(4);
			int[] array141 = new int[4];
			array141[0] = 4095;
            this.m_nudChirp31IdleTimeVar.Maximum = new decimal(array141);
			this.m_nudChirp31IdleTimeVar.Name = "m_nudChirp31IdleTimeVar";
			this.m_nudChirp31IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp31IdleTimeVar.TabIndex = 676;
			this.m_nudChirp30BPMConstVal.Location = new Point(400, 901);
			this.m_nudChirp30BPMConstVal.Margin = new Padding(4);
			int[] array142 = new int[4];
			array142[0] = 63;
            this.m_nudChirp30BPMConstVal.Maximum = new decimal(array142);
			this.m_nudChirp30BPMConstVal.Name = "m_nudChirp30BPMConstVal";
			this.m_nudChirp30BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp30BPMConstVal.TabIndex = 666;
			this.m_ChbChirp30Tx3Enable.AutoSize = true;
			this.m_ChbChirp30Tx3Enable.Location = new Point(360, 905);
			this.m_ChbChirp30Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp30Tx3Enable.Name = "m_ChbChirp30Tx3Enable";
			this.m_ChbChirp30Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp30Tx3Enable.TabIndex = 674;
			this.m_ChbChirp30Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp30Tx2Enable.AutoSize = true;
			this.m_ChbChirp30Tx2Enable.Location = new Point(320, 906);
			this.m_ChbChirp30Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp30Tx2Enable.Name = "m_ChbChirp30Tx2Enable";
			this.m_ChbChirp30Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp30Tx2Enable.TabIndex = 673;
			this.m_ChbChirp30Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp30Tx1Enable.AutoSize = true;
			this.m_ChbChirp30Tx1Enable.Location = new Point(286, 906);
			this.m_ChbChirp30Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp30Tx1Enable.Name = "m_ChbChirp30Tx1Enable";
			this.m_ChbChirp30Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp30Tx1Enable.TabIndex = 672;
			this.m_ChbChirp30Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp30FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp30FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp30FreqSlopeVar.Location = new Point(179, 904);
			this.m_nudChirp30FreqSlopeVar.Margin = new Padding(4);
			int[] array143 = new int[4];
			array143[0] = 4;
            this.m_nudChirp30FreqSlopeVar.Maximum = new decimal(array143);
			this.m_nudChirp30FreqSlopeVar.Name = "m_nudChirp30FreqSlopeVar";
			this.m_nudChirp30FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp30FreqSlopeVar.TabIndex = 671;
			this.m_nudChirp30ProfileIndex.Location = new Point(83, 904);
			this.m_nudChirp30ProfileIndex.Margin = new Padding(4);
			int[] array144 = new int[4];
			array144[0] = 3;
            this.m_nudChirp30ProfileIndex.Maximum = new decimal(array144);
			this.m_nudChirp30ProfileIndex.Name = "m_nudChirp30ProfileIndex";
			this.m_nudChirp30ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp30ProfileIndex.TabIndex = 670;
			this.m_nudChirp30FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp30FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp30FreqStartVar.Location = new Point(514, 905);
			this.m_nudChirp30FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp30FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp30FreqStartVar.Name = "m_nudChirp30FreqStartVar";
			this.m_nudChirp30FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp30FreqStartVar.TabIndex = 669;
			this.m_nudChirp30ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp30ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp30ADCStartTimeVar.Location = new Point(756, 905);
			this.m_nudChirp30ADCStartTimeVar.Margin = new Padding(4);
			int[] array145 = new int[4];
			array145[0] = 4095;
            this.m_nudChirp30ADCStartTimeVar.Maximum = new decimal(array145);
			this.m_nudChirp30ADCStartTimeVar.Name = "m_nudChirp30ADCStartTimeVar";
			this.m_nudChirp30ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp30ADCStartTimeVar.TabIndex = 668;
			this.m_nudChirp30IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp30IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp30IdleTimeVar.Location = new Point(648, 905);
			this.m_nudChirp30IdleTimeVar.Margin = new Padding(4);
			int[] array146 = new int[4];
			array146[0] = 4095;
            this.m_nudChirp30IdleTimeVar.Maximum = new decimal(array146);
			this.m_nudChirp30IdleTimeVar.Name = "m_nudChirp30IdleTimeVar";
			this.m_nudChirp30IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp30IdleTimeVar.TabIndex = 667;
			this.m_nudChirp29BPMConstVal.Location = new Point(400, 871);
			this.m_nudChirp29BPMConstVal.Margin = new Padding(4);
			int[] array147 = new int[4];
			array147[0] = 63;
            this.m_nudChirp29BPMConstVal.Maximum = new decimal(array147);
			this.m_nudChirp29BPMConstVal.Name = "m_nudChirp29BPMConstVal";
			this.m_nudChirp29BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp29BPMConstVal.TabIndex = 657;
			this.m_ChbChirp29Tx3Enable.AutoSize = true;
			this.m_ChbChirp29Tx3Enable.Location = new Point(360, 874);
			this.m_ChbChirp29Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp29Tx3Enable.Name = "m_ChbChirp29Tx3Enable";
			this.m_ChbChirp29Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp29Tx3Enable.TabIndex = 665;
			this.m_ChbChirp29Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp29Tx2Enable.AutoSize = true;
			this.m_ChbChirp29Tx2Enable.Location = new Point(320, 875);
			this.m_ChbChirp29Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp29Tx2Enable.Name = "m_ChbChirp29Tx2Enable";
			this.m_ChbChirp29Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp29Tx2Enable.TabIndex = 664;
			this.m_ChbChirp29Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp29Tx1Enable.AutoSize = true;
			this.m_ChbChirp29Tx1Enable.Location = new Point(286, 875);
			this.m_ChbChirp29Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp29Tx1Enable.Name = "m_ChbChirp29Tx1Enable";
			this.m_ChbChirp29Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp29Tx1Enable.TabIndex = 663;
			this.m_ChbChirp29Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp29FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp29FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp29FreqSlopeVar.Location = new Point(179, 873);
			this.m_nudChirp29FreqSlopeVar.Margin = new Padding(4);
			int[] array148 = new int[4];
			array148[0] = 4;
            this.m_nudChirp29FreqSlopeVar.Maximum = new decimal(array148);
			this.m_nudChirp29FreqSlopeVar.Name = "m_nudChirp29FreqSlopeVar";
			this.m_nudChirp29FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp29FreqSlopeVar.TabIndex = 662;
			this.m_nudChirp29ProfileIndex.Location = new Point(83, 873);
			this.m_nudChirp29ProfileIndex.Margin = new Padding(4);
			int[] array149 = new int[4];
			array149[0] = 3;
            this.m_nudChirp29ProfileIndex.Maximum = new decimal(array149);
			this.m_nudChirp29ProfileIndex.Name = "m_nudChirp29ProfileIndex";
			this.m_nudChirp29ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp29ProfileIndex.TabIndex = 661;
			this.m_nudChirp29FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp29FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp29FreqStartVar.Location = new Point(514, 874);
			this.m_nudChirp29FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp29FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp29FreqStartVar.Name = "m_nudChirp29FreqStartVar";
			this.m_nudChirp29FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp29FreqStartVar.TabIndex = 660;
			this.m_nudChirp29ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp29ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp29ADCStartTimeVar.Location = new Point(756, 874);
			this.m_nudChirp29ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp29ADCStartTimeVar = this.m_nudChirp29ADCStartTimeVar;
			int[] array150 = new int[4];
			array150[0] = 4095;
			nudChirp29ADCStartTimeVar.Maximum = new decimal(array150);
			this.m_nudChirp29ADCStartTimeVar.Name = "m_nudChirp29ADCStartTimeVar";
			this.m_nudChirp29ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp29ADCStartTimeVar.TabIndex = 659;
			this.m_nudChirp29IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp29IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp29IdleTimeVar.Location = new Point(648, 874);
			this.m_nudChirp29IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp29IdleTimeVar = this.m_nudChirp29IdleTimeVar;
			int[] array151 = new int[4];
			array151[0] = 4095;
			nudChirp29IdleTimeVar.Maximum = new decimal(array151);
			this.m_nudChirp29IdleTimeVar.Name = "m_nudChirp29IdleTimeVar";
			this.m_nudChirp29IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp29IdleTimeVar.TabIndex = 658;
			this.label77.AutoSize = true;
			this.label77.Location = new Point(4, 1152);
			this.label77.Margin = new Padding(4, 0, 4, 0);
			this.label77.Name = "label77";
			this.label77.Size = new Size(61, 17);
			this.label77.TabIndex = 656;
			this.label77.Text = "Chirp 38";
			this.label78.AutoSize = true;
			this.label78.Location = new Point(4, 1185);
			this.label78.Margin = new Padding(4, 0, 4, 0);
			this.label78.Name = "label78";
			this.label78.Size = new Size(61, 17);
			this.label78.TabIndex = 655;
			this.label78.Text = "Chirp 39";
			this.label79.AutoSize = true;
			this.label79.Location = new Point(4, 1091);
			this.label79.Margin = new Padding(4, 0, 4, 0);
			this.label79.Name = "label79";
			this.label79.Size = new Size(61, 17);
			this.label79.TabIndex = 654;
			this.label79.Text = "Chirp 36";
			this.label80.AutoSize = true;
			this.label80.Location = new Point(4, 1123);
			this.label80.Margin = new Padding(4, 0, 4, 0);
			this.label80.Name = "label80";
			this.label80.Size = new Size(61, 17);
			this.label80.TabIndex = 653;
			this.label80.Text = "Chirp 37";
			this.label81.AutoSize = true;
			this.label81.Location = new Point(4, 1028);
			this.label81.Margin = new Padding(4, 0, 4, 0);
			this.label81.Name = "label81";
			this.label81.Size = new Size(61, 17);
			this.label81.TabIndex = 652;
			this.label81.Text = "Chirp 34";
			this.label82.AutoSize = true;
			this.label82.Location = new Point(4, 1059);
			this.label82.Margin = new Padding(4, 0, 4, 0);
			this.label82.Name = "label82";
			this.label82.Size = new Size(61, 17);
			this.label82.TabIndex = 651;
			this.label82.Text = "Chirp 35";
			this.label83.AutoSize = true;
			this.label83.Location = new Point(4, 970);
			this.label83.Margin = new Padding(4, 0, 4, 0);
			this.label83.Name = "label83";
			this.label83.Size = new Size(61, 17);
			this.label83.TabIndex = 650;
			this.label83.Text = "Chirp 32";
			this.label84.AutoSize = true;
			this.label84.Location = new Point(4, 1001);
			this.label84.Margin = new Padding(4, 0, 4, 0);
			this.label84.Name = "label84";
			this.label84.Size = new Size(61, 17);
			this.label84.TabIndex = 649;
			this.label84.Text = "Chirp 33";
			this.label85.AutoSize = true;
			this.label85.Location = new Point(4, 877);
			this.label85.Margin = new Padding(4, 0, 4, 0);
			this.label85.Name = "label85";
			this.label85.Size = new Size(61, 17);
			this.label85.TabIndex = 648;
			this.label85.Text = "Chirp 29";
			this.label86.AutoSize = true;
			this.label86.Location = new Point(4, 907);
			this.label86.Margin = new Padding(4, 0, 4, 0);
			this.label86.Name = "label86";
			this.label86.Size = new Size(61, 17);
			this.label86.TabIndex = 647;
			this.label86.Text = "Chirp 30";
			this.label87.AutoSize = true;
			this.label87.Location = new Point(4, 936);
			this.label87.Margin = new Padding(4, 0, 4, 0);
			this.label87.Name = "label87";
			this.label87.Size = new Size(61, 17);
			this.label87.TabIndex = 646;
			this.label87.Text = "Chirp 31";
			this.m_nudChirp28BPMConstVal.Location = new Point(399, 834);
			this.m_nudChirp28BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp28BPMConstVal = this.m_nudChirp28BPMConstVal;
			int[] array152 = new int[4];
			array152[0] = 63;
			nudChirp28BPMConstVal.Maximum = new decimal(array152);
			this.m_nudChirp28BPMConstVal.Name = "m_nudChirp28BPMConstVal";
			this.m_nudChirp28BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp28BPMConstVal.TabIndex = 637;
			this.m_ChbChirp28Tx3Enable.AutoSize = true;
			this.m_ChbChirp28Tx3Enable.Location = new Point(359, 838);
			this.m_ChbChirp28Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp28Tx3Enable.Name = "m_ChbChirp28Tx3Enable";
			this.m_ChbChirp28Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp28Tx3Enable.TabIndex = 645;
			this.m_ChbChirp28Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp28Tx2Enable.AutoSize = true;
			this.m_ChbChirp28Tx2Enable.Location = new Point(319, 839);
			this.m_ChbChirp28Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp28Tx2Enable.Name = "m_ChbChirp28Tx2Enable";
			this.m_ChbChirp28Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp28Tx2Enable.TabIndex = 644;
			this.m_ChbChirp28Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp28Tx1Enable.AutoSize = true;
			this.m_ChbChirp28Tx1Enable.Location = new Point(285, 839);
			this.m_ChbChirp28Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp28Tx1Enable.Name = "m_ChbChirp28Tx1Enable";
			this.m_ChbChirp28Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp28Tx1Enable.TabIndex = 643;
			this.m_ChbChirp28Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp28FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp28FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp28FreqSlopeVar.Location = new Point(178, 837);
			this.m_nudChirp28FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp28FreqSlopeVar = this.m_nudChirp28FreqSlopeVar;
			int[] array153 = new int[4];
			array153[0] = 4;
			nudChirp28FreqSlopeVar.Maximum = new decimal(array153);
			this.m_nudChirp28FreqSlopeVar.Name = "m_nudChirp28FreqSlopeVar";
			this.m_nudChirp28FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp28FreqSlopeVar.TabIndex = 642;
			this.m_nudChirp28ProfileIndex.Location = new Point(82, 837);
			this.m_nudChirp28ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp28ProfileIndex = this.m_nudChirp28ProfileIndex;
			int[] array154 = new int[4];
			array154[0] = 3;
			nudChirp28ProfileIndex.Maximum = new decimal(array154);
			this.m_nudChirp28ProfileIndex.Name = "m_nudChirp28ProfileIndex";
			this.m_nudChirp28ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp28ProfileIndex.TabIndex = 641;
			this.m_nudChirp28FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp28FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp28FreqStartVar.Location = new Point(513, 838);
			this.m_nudChirp28FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp28FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp28FreqStartVar.Name = "m_nudChirp28FreqStartVar";
			this.m_nudChirp28FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp28FreqStartVar.TabIndex = 640;
			this.m_nudChirp28ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp28ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp28ADCStartTimeVar.Location = new Point(755, 838);
			this.m_nudChirp28ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp28ADCStartTimeVar = this.m_nudChirp28ADCStartTimeVar;
			int[] array155 = new int[4];
			array155[0] = 4095;
			nudChirp28ADCStartTimeVar.Maximum = new decimal(array155);
			this.m_nudChirp28ADCStartTimeVar.Name = "m_nudChirp28ADCStartTimeVar";
			this.m_nudChirp28ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp28ADCStartTimeVar.TabIndex = 639;
			this.m_nudChirp28IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp28IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp28IdleTimeVar.Location = new Point(647, 838);
			this.m_nudChirp28IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp28IdleTimeVar = this.m_nudChirp28IdleTimeVar;
			int[] array156 = new int[4];
			array156[0] = 4095;
			nudChirp28IdleTimeVar.Maximum = new decimal(array156);
			this.m_nudChirp28IdleTimeVar.Name = "m_nudChirp28IdleTimeVar";
			this.m_nudChirp28IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp28IdleTimeVar.TabIndex = 638;
			this.m_nudChirp26BPMConstVal.Location = new Point(399, 773);
			this.m_nudChirp26BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp26BPMConstVal = this.m_nudChirp26BPMConstVal;
			int[] array157 = new int[4];
			array157[0] = 63;
			nudChirp26BPMConstVal.Maximum = new decimal(array157);
			this.m_nudChirp26BPMConstVal.Name = "m_nudChirp26BPMConstVal";
			this.m_nudChirp26BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp26BPMConstVal.TabIndex = 628;
			this.m_ChbChirp26Tx3Enable.AutoSize = true;
			this.m_ChbChirp26Tx3Enable.Location = new Point(359, 777);
			this.m_ChbChirp26Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp26Tx3Enable.Name = "m_ChbChirp26Tx3Enable";
			this.m_ChbChirp26Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp26Tx3Enable.TabIndex = 636;
			this.m_ChbChirp26Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp26Tx2Enable.AutoSize = true;
			this.m_ChbChirp26Tx2Enable.Location = new Point(319, 778);
			this.m_ChbChirp26Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp26Tx2Enable.Name = "m_ChbChirp26Tx2Enable";
			this.m_ChbChirp26Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp26Tx2Enable.TabIndex = 635;
			this.m_ChbChirp26Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp26Tx1Enable.AutoSize = true;
			this.m_ChbChirp26Tx1Enable.Location = new Point(285, 778);
			this.m_ChbChirp26Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp26Tx1Enable.Name = "m_ChbChirp26Tx1Enable";
			this.m_ChbChirp26Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp26Tx1Enable.TabIndex = 634;
			this.m_ChbChirp26Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp26FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp26FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp26FreqSlopeVar.Location = new Point(178, 775);
			this.m_nudChirp26FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp26FreqSlopeVar = this.m_nudChirp26FreqSlopeVar;
			int[] array158 = new int[4];
			array158[0] = 4;
			nudChirp26FreqSlopeVar.Maximum = new decimal(array158);
			this.m_nudChirp26FreqSlopeVar.Name = "m_nudChirp26FreqSlopeVar";
			this.m_nudChirp26FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp26FreqSlopeVar.TabIndex = 633;
			this.m_nudChirp26ProfileIndex.Location = new Point(82, 775);
			this.m_nudChirp26ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp26ProfileIndex = this.m_nudChirp26ProfileIndex;
			int[] array159 = new int[4];
			array159[0] = 3;
			nudChirp26ProfileIndex.Maximum = new decimal(array159);
			this.m_nudChirp26ProfileIndex.Name = "m_nudChirp26ProfileIndex";
			this.m_nudChirp26ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp26ProfileIndex.TabIndex = 632;
			this.m_nudChirp26FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp26FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp26FreqStartVar.Location = new Point(513, 777);
			this.m_nudChirp26FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp26FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp26FreqStartVar.Name = "m_nudChirp26FreqStartVar";
			this.m_nudChirp26FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp26FreqStartVar.TabIndex = 631;
			this.m_nudChirp26ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp26ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp26ADCStartTimeVar.Location = new Point(755, 777);
			this.m_nudChirp26ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp26ADCStartTimeVar = this.m_nudChirp26ADCStartTimeVar;
			int[] array160 = new int[4];
			array160[0] = 4095;
			nudChirp26ADCStartTimeVar.Maximum = new decimal(array160);
			this.m_nudChirp26ADCStartTimeVar.Name = "m_nudChirp26ADCStartTimeVar";
			this.m_nudChirp26ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp26ADCStartTimeVar.TabIndex = 630;
			this.m_nudChirp26IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp26IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp26IdleTimeVar.Location = new Point(647, 777);
			this.m_nudChirp26IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp26IdleTimeVar = this.m_nudChirp26IdleTimeVar;
			int[] array161 = new int[4];
			array161[0] = 4095;
			nudChirp26IdleTimeVar.Maximum = new decimal(array161);
			this.m_nudChirp26IdleTimeVar.Name = "m_nudChirp26IdleTimeVar";
			this.m_nudChirp26IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp26IdleTimeVar.TabIndex = 629;
			this.m_nudChirp27BPMConstVal.Location = new Point(399, 802);
			this.m_nudChirp27BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp27BPMConstVal = this.m_nudChirp27BPMConstVal;
			int[] array162 = new int[4];
			array162[0] = 63;
			nudChirp27BPMConstVal.Maximum = new decimal(array162);
			this.m_nudChirp27BPMConstVal.Name = "m_nudChirp27BPMConstVal";
			this.m_nudChirp27BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp27BPMConstVal.TabIndex = 619;
			this.m_ChbChirp27Tx3Enable.AutoSize = true;
			this.m_ChbChirp27Tx3Enable.Location = new Point(359, 806);
			this.m_ChbChirp27Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp27Tx3Enable.Name = "m_ChbChirp27Tx3Enable";
			this.m_ChbChirp27Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp27Tx3Enable.TabIndex = 627;
			this.m_ChbChirp27Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp27Tx2Enable.AutoSize = true;
			this.m_ChbChirp27Tx2Enable.Location = new Point(319, 807);
			this.m_ChbChirp27Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp27Tx2Enable.Name = "m_ChbChirp27Tx2Enable";
			this.m_ChbChirp27Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp27Tx2Enable.TabIndex = 626;
			this.m_ChbChirp27Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp27Tx1Enable.AutoSize = true;
			this.m_ChbChirp27Tx1Enable.Location = new Point(285, 807);
			this.m_ChbChirp27Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp27Tx1Enable.Name = "m_ChbChirp27Tx1Enable";
			this.m_ChbChirp27Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp27Tx1Enable.TabIndex = 625;
			this.m_ChbChirp27Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp27FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp27FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp27FreqSlopeVar.Location = new Point(178, 805);
			this.m_nudChirp27FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp27FreqSlopeVar = this.m_nudChirp27FreqSlopeVar;
			int[] array163 = new int[4];
			array163[0] = 4;
			nudChirp27FreqSlopeVar.Maximum = new decimal(array163);
			this.m_nudChirp27FreqSlopeVar.Name = "m_nudChirp27FreqSlopeVar";
			this.m_nudChirp27FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp27FreqSlopeVar.TabIndex = 624;
			this.m_nudChirp27ProfileIndex.Location = new Point(82, 805);
			this.m_nudChirp27ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp27ProfileIndex = this.m_nudChirp27ProfileIndex;
			int[] array164 = new int[4];
			array164[0] = 3;
			nudChirp27ProfileIndex.Maximum = new decimal(array164);
			this.m_nudChirp27ProfileIndex.Name = "m_nudChirp27ProfileIndex";
			this.m_nudChirp27ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp27ProfileIndex.TabIndex = 623;
			this.m_nudChirp27FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp27FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp27FreqStartVar.Location = new Point(513, 806);
			this.m_nudChirp27FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp27FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp27FreqStartVar.Name = "m_nudChirp27FreqStartVar";
			this.m_nudChirp27FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp27FreqStartVar.TabIndex = 622;
			this.m_nudChirp27ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp27ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp27ADCStartTimeVar.Location = new Point(755, 806);
			this.m_nudChirp27ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp27ADCStartTimeVar = this.m_nudChirp27ADCStartTimeVar;
			int[] array165 = new int[4];
			array165[0] = 4095;
			nudChirp27ADCStartTimeVar.Maximum = new decimal(array165);
			this.m_nudChirp27ADCStartTimeVar.Name = "m_nudChirp27ADCStartTimeVar";
			this.m_nudChirp27ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp27ADCStartTimeVar.TabIndex = 621;
			this.m_nudChirp27IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp27IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp27IdleTimeVar.Location = new Point(647, 806);
			this.m_nudChirp27IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp27IdleTimeVar = this.m_nudChirp27IdleTimeVar;
			int[] array166 = new int[4];
			array166[0] = 4095;
			nudChirp27IdleTimeVar.Maximum = new decimal(array166);
			this.m_nudChirp27IdleTimeVar.Name = "m_nudChirp27IdleTimeVar";
			this.m_nudChirp27IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp27IdleTimeVar.TabIndex = 620;
			this.m_nudChirp25BPMConstVal.Location = new Point(399, 741);
			this.m_nudChirp25BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp25BPMConstVal = this.m_nudChirp25BPMConstVal;
			int[] array167 = new int[4];
			array167[0] = 63;
			nudChirp25BPMConstVal.Maximum = new decimal(array167);
			this.m_nudChirp25BPMConstVal.Name = "m_nudChirp25BPMConstVal";
			this.m_nudChirp25BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp25BPMConstVal.TabIndex = 610;
			this.m_ChbChirp25Tx3Enable.AutoSize = true;
			this.m_ChbChirp25Tx3Enable.Location = new Point(359, 745);
			this.m_ChbChirp25Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp25Tx3Enable.Name = "m_ChbChirp25Tx3Enable";
			this.m_ChbChirp25Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp25Tx3Enable.TabIndex = 618;
			this.m_ChbChirp25Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp25Tx2Enable.AutoSize = true;
			this.m_ChbChirp25Tx2Enable.Location = new Point(319, 746);
			this.m_ChbChirp25Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp25Tx2Enable.Name = "m_ChbChirp25Tx2Enable";
			this.m_ChbChirp25Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp25Tx2Enable.TabIndex = 617;
			this.m_ChbChirp25Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp25Tx1Enable.AutoSize = true;
			this.m_ChbChirp25Tx1Enable.Location = new Point(285, 746);
			this.m_ChbChirp25Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp25Tx1Enable.Name = "m_ChbChirp25Tx1Enable";
			this.m_ChbChirp25Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp25Tx1Enable.TabIndex = 616;
			this.m_ChbChirp25Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp25FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp25FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp25FreqSlopeVar.Location = new Point(178, 743);
			this.m_nudChirp25FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp25FreqSlopeVar = this.m_nudChirp25FreqSlopeVar;
			int[] array168 = new int[4];
			array168[0] = 4;
			nudChirp25FreqSlopeVar.Maximum = new decimal(array168);
			this.m_nudChirp25FreqSlopeVar.Name = "m_nudChirp25FreqSlopeVar";
			this.m_nudChirp25FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp25FreqSlopeVar.TabIndex = 615;
			this.m_nudChirp25ProfileIndex.Location = new Point(82, 743);
			this.m_nudChirp25ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp25ProfileIndex = this.m_nudChirp25ProfileIndex;
			int[] array169 = new int[4];
			array169[0] = 3;
			nudChirp25ProfileIndex.Maximum = new decimal(array169);
			this.m_nudChirp25ProfileIndex.Name = "m_nudChirp25ProfileIndex";
			this.m_nudChirp25ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp25ProfileIndex.TabIndex = 614;
			this.m_nudChirp25FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp25FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp25FreqStartVar.Location = new Point(513, 745);
			this.m_nudChirp25FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp25FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp25FreqStartVar.Name = "m_nudChirp25FreqStartVar";
			this.m_nudChirp25FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp25FreqStartVar.TabIndex = 613;
			this.m_nudChirp25ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp25ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp25ADCStartTimeVar.Location = new Point(755, 745);
			this.m_nudChirp25ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp25ADCStartTimeVar = this.m_nudChirp25ADCStartTimeVar;
			int[] array170 = new int[4];
			array170[0] = 4095;
			nudChirp25ADCStartTimeVar.Maximum = new decimal(array170);
			this.m_nudChirp25ADCStartTimeVar.Name = "m_nudChirp25ADCStartTimeVar";
			this.m_nudChirp25ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp25ADCStartTimeVar.TabIndex = 612;
			this.m_nudChirp25IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp25IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp25IdleTimeVar.Location = new Point(647, 745);
			this.m_nudChirp25IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp25IdleTimeVar = this.m_nudChirp25IdleTimeVar;
			int[] array171 = new int[4];
			array171[0] = 4095;
			nudChirp25IdleTimeVar.Maximum = new decimal(array171);
			this.m_nudChirp25IdleTimeVar.Name = "m_nudChirp25IdleTimeVar";
			this.m_nudChirp25IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp25IdleTimeVar.TabIndex = 611;
			this.m_nudChirp24BPMConstVal.Location = new Point(399, 709);
			this.m_nudChirp24BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp24BPMConstVal = this.m_nudChirp24BPMConstVal;
			int[] array172 = new int[4];
			array172[0] = 63;
			nudChirp24BPMConstVal.Maximum = new decimal(array172);
			this.m_nudChirp24BPMConstVal.Name = "m_nudChirp24BPMConstVal";
			this.m_nudChirp24BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp24BPMConstVal.TabIndex = 601;
			this.m_ChbChirp24Tx3Enable.AutoSize = true;
			this.m_ChbChirp24Tx3Enable.Location = new Point(359, 713);
			this.m_ChbChirp24Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp24Tx3Enable.Name = "m_ChbChirp24Tx3Enable";
			this.m_ChbChirp24Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp24Tx3Enable.TabIndex = 609;
			this.m_ChbChirp24Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp24Tx2Enable.AutoSize = true;
			this.m_ChbChirp24Tx2Enable.Location = new Point(319, 714);
			this.m_ChbChirp24Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp24Tx2Enable.Name = "m_ChbChirp24Tx2Enable";
			this.m_ChbChirp24Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp24Tx2Enable.TabIndex = 608;
			this.m_ChbChirp24Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp24Tx1Enable.AutoSize = true;
			this.m_ChbChirp24Tx1Enable.Location = new Point(285, 714);
			this.m_ChbChirp24Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp24Tx1Enable.Name = "m_ChbChirp24Tx1Enable";
			this.m_ChbChirp24Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp24Tx1Enable.TabIndex = 607;
			this.m_ChbChirp24Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp24FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp24FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp24FreqSlopeVar.Location = new Point(178, 711);
			this.m_nudChirp24FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp24FreqSlopeVar = this.m_nudChirp24FreqSlopeVar;
			int[] array173 = new int[4];
			array173[0] = 4;
			nudChirp24FreqSlopeVar.Maximum = new decimal(array173);
			this.m_nudChirp24FreqSlopeVar.Name = "m_nudChirp24FreqSlopeVar";
			this.m_nudChirp24FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp24FreqSlopeVar.TabIndex = 606;
			this.m_nudChirp24ProfileIndex.Location = new Point(82, 711);
			this.m_nudChirp24ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp24ProfileIndex = this.m_nudChirp24ProfileIndex;
			int[] array174 = new int[4];
			array174[0] = 3;
			nudChirp24ProfileIndex.Maximum = new decimal(array174);
			this.m_nudChirp24ProfileIndex.Name = "m_nudChirp24ProfileIndex";
			this.m_nudChirp24ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp24ProfileIndex.TabIndex = 605;
			this.m_nudChirp24FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp24FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp24FreqStartVar.Location = new Point(513, 713);
			this.m_nudChirp24FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp24FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp24FreqStartVar.Name = "m_nudChirp24FreqStartVar";
			this.m_nudChirp24FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp24FreqStartVar.TabIndex = 604;
			this.m_nudChirp24ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp24ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp24ADCStartTimeVar.Location = new Point(755, 713);
			this.m_nudChirp24ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp24ADCStartTimeVar = this.m_nudChirp24ADCStartTimeVar;
			int[] array175 = new int[4];
			array175[0] = 4095;
			nudChirp24ADCStartTimeVar.Maximum = new decimal(array175);
			this.m_nudChirp24ADCStartTimeVar.Name = "m_nudChirp24ADCStartTimeVar";
			this.m_nudChirp24ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp24ADCStartTimeVar.TabIndex = 603;
			this.m_nudChirp24IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp24IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp24IdleTimeVar.Location = new Point(647, 713);
			this.m_nudChirp24IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp24IdleTimeVar = this.m_nudChirp24IdleTimeVar;
			int[] array176 = new int[4];
			array176[0] = 4095;
			nudChirp24IdleTimeVar.Maximum = new decimal(array176);
			this.m_nudChirp24IdleTimeVar.Name = "m_nudChirp24IdleTimeVar";
			this.m_nudChirp24IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp24IdleTimeVar.TabIndex = 602;
			this.m_nudChirp23BPMConstVal.Location = new Point(399, 678);
			this.m_nudChirp23BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp23BPMConstVal = this.m_nudChirp23BPMConstVal;
			int[] array177 = new int[4];
			array177[0] = 63;
			nudChirp23BPMConstVal.Maximum = new decimal(array177);
			this.m_nudChirp23BPMConstVal.Name = "m_nudChirp23BPMConstVal";
			this.m_nudChirp23BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp23BPMConstVal.TabIndex = 592;
			this.m_ChbChirp23Tx3Enable.AutoSize = true;
			this.m_ChbChirp23Tx3Enable.Location = new Point(359, 682);
			this.m_ChbChirp23Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp23Tx3Enable.Name = "m_ChbChirp23Tx3Enable";
			this.m_ChbChirp23Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp23Tx3Enable.TabIndex = 600;
			this.m_ChbChirp23Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp23Tx2Enable.AutoSize = true;
			this.m_ChbChirp23Tx2Enable.Location = new Point(319, 683);
			this.m_ChbChirp23Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp23Tx2Enable.Name = "m_ChbChirp23Tx2Enable";
			this.m_ChbChirp23Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp23Tx2Enable.TabIndex = 599;
			this.m_ChbChirp23Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp23Tx1Enable.AutoSize = true;
			this.m_ChbChirp23Tx1Enable.Location = new Point(285, 683);
			this.m_ChbChirp23Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp23Tx1Enable.Name = "m_ChbChirp23Tx1Enable";
			this.m_ChbChirp23Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp23Tx1Enable.TabIndex = 598;
			this.m_ChbChirp23Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp23FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp23FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp23FreqSlopeVar.Location = new Point(178, 681);
			this.m_nudChirp23FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp23FreqSlopeVar = this.m_nudChirp23FreqSlopeVar;
			int[] array178 = new int[4];
			array178[0] = 4;
			nudChirp23FreqSlopeVar.Maximum = new decimal(array178);
			this.m_nudChirp23FreqSlopeVar.Name = "m_nudChirp23FreqSlopeVar";
			this.m_nudChirp23FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp23FreqSlopeVar.TabIndex = 597;
			this.m_nudChirp23ProfileIndex.Location = new Point(82, 681);
			this.m_nudChirp23ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp23ProfileIndex = this.m_nudChirp23ProfileIndex;
			int[] array179 = new int[4];
			array179[0] = 3;
			nudChirp23ProfileIndex.Maximum = new decimal(array179);
			this.m_nudChirp23ProfileIndex.Name = "m_nudChirp23ProfileIndex";
			this.m_nudChirp23ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp23ProfileIndex.TabIndex = 596;
			this.m_nudChirp23FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp23FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp23FreqStartVar.Location = new Point(513, 682);
			this.m_nudChirp23FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp23FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp23FreqStartVar.Name = "m_nudChirp23FreqStartVar";
			this.m_nudChirp23FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp23FreqStartVar.TabIndex = 595;
			this.m_nudChirp23ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp23ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp23ADCStartTimeVar.Location = new Point(755, 682);
			this.m_nudChirp23ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp23ADCStartTimeVar = this.m_nudChirp23ADCStartTimeVar;
			int[] array180 = new int[4];
			array180[0] = 4095;
			nudChirp23ADCStartTimeVar.Maximum = new decimal(array180);
			this.m_nudChirp23ADCStartTimeVar.Name = "m_nudChirp23ADCStartTimeVar";
			this.m_nudChirp23ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp23ADCStartTimeVar.TabIndex = 594;
			this.m_nudChirp23IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp23IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp23IdleTimeVar.Location = new Point(647, 682);
			this.m_nudChirp23IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp23IdleTimeVar = this.m_nudChirp23IdleTimeVar;
			int[] array181 = new int[4];
			array181[0] = 4095;
			nudChirp23IdleTimeVar.Maximum = new decimal(array181);
			this.m_nudChirp23IdleTimeVar.Name = "m_nudChirp23IdleTimeVar";
			this.m_nudChirp23IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp23IdleTimeVar.TabIndex = 593;
			this.m_nudChirp21BPMConstVal.Location = new Point(399, 620);
			this.m_nudChirp21BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp21BPMConstVal = this.m_nudChirp21BPMConstVal;
			int[] array182 = new int[4];
			array182[0] = 63;
			nudChirp21BPMConstVal.Maximum = new decimal(array182);
			this.m_nudChirp21BPMConstVal.Name = "m_nudChirp21BPMConstVal";
			this.m_nudChirp21BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp21BPMConstVal.TabIndex = 583;
			this.m_ChbChirp21Tx3Enable.AutoSize = true;
			this.m_ChbChirp21Tx3Enable.Location = new Point(359, 624);
			this.m_ChbChirp21Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp21Tx3Enable.Name = "m_ChbChirp21Tx3Enable";
			this.m_ChbChirp21Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp21Tx3Enable.TabIndex = 591;
			this.m_ChbChirp21Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp21Tx2Enable.AutoSize = true;
			this.m_ChbChirp21Tx2Enable.Location = new Point(319, 625);
			this.m_ChbChirp21Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp21Tx2Enable.Name = "m_ChbChirp21Tx2Enable";
			this.m_ChbChirp21Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp21Tx2Enable.TabIndex = 590;
			this.m_ChbChirp21Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp21Tx1Enable.AutoSize = true;
			this.m_ChbChirp21Tx1Enable.Location = new Point(285, 625);
			this.m_ChbChirp21Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp21Tx1Enable.Name = "m_ChbChirp21Tx1Enable";
			this.m_ChbChirp21Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp21Tx1Enable.TabIndex = 589;
			this.m_ChbChirp21Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp21FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp21FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp21FreqSlopeVar.Location = new Point(178, 623);
			this.m_nudChirp21FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp21FreqSlopeVar = this.m_nudChirp21FreqSlopeVar;
			int[] array183 = new int[4];
			array183[0] = 4;
			nudChirp21FreqSlopeVar.Maximum = new decimal(array183);
			this.m_nudChirp21FreqSlopeVar.Name = "m_nudChirp21FreqSlopeVar";
			this.m_nudChirp21FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp21FreqSlopeVar.TabIndex = 588;
			this.m_nudChirp21ProfileIndex.Location = new Point(82, 623);
			this.m_nudChirp21ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp21ProfileIndex = this.m_nudChirp21ProfileIndex;
			int[] array184 = new int[4];
			array184[0] = 3;
			nudChirp21ProfileIndex.Maximum = new decimal(array184);
			this.m_nudChirp21ProfileIndex.Name = "m_nudChirp21ProfileIndex";
			this.m_nudChirp21ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp21ProfileIndex.TabIndex = 587;
			this.m_nudChirp21FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp21FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp21FreqStartVar.Location = new Point(513, 624);
			this.m_nudChirp21FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp21FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp21FreqStartVar.Name = "m_nudChirp21FreqStartVar";
			this.m_nudChirp21FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp21FreqStartVar.TabIndex = 586;
			this.m_nudChirp21ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp21ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp21ADCStartTimeVar.Location = new Point(755, 624);
			this.m_nudChirp21ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp21ADCStartTimeVar = this.m_nudChirp21ADCStartTimeVar;
			int[] array185 = new int[4];
			array185[0] = 4095;
			nudChirp21ADCStartTimeVar.Maximum = new decimal(array185);
			this.m_nudChirp21ADCStartTimeVar.Name = "m_nudChirp21ADCStartTimeVar";
			this.m_nudChirp21ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp21ADCStartTimeVar.TabIndex = 585;
			this.m_nudChirp21IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp21IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp21IdleTimeVar.Location = new Point(647, 624);
			this.m_nudChirp21IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp21IdleTimeVar = this.m_nudChirp21IdleTimeVar;
			int[] array186 = new int[4];
			array186[0] = 4095;
			nudChirp21IdleTimeVar.Maximum = new decimal(array186);
			this.m_nudChirp21IdleTimeVar.Name = "m_nudChirp21IdleTimeVar";
			this.m_nudChirp21IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp21IdleTimeVar.TabIndex = 584;
			this.m_nudChirp22BPMConstVal.Location = new Point(399, 650);
			this.m_nudChirp22BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp22BPMConstVal = this.m_nudChirp22BPMConstVal;
			int[] array187 = new int[4];
			array187[0] = 63;
			nudChirp22BPMConstVal.Maximum = new decimal(array187);
			this.m_nudChirp22BPMConstVal.Name = "m_nudChirp22BPMConstVal";
			this.m_nudChirp22BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp22BPMConstVal.TabIndex = 574;
			this.m_ChbChirp22Tx3Enable.AutoSize = true;
			this.m_ChbChirp22Tx3Enable.Location = new Point(359, 654);
			this.m_ChbChirp22Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp22Tx3Enable.Name = "m_ChbChirp22Tx3Enable";
			this.m_ChbChirp22Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp22Tx3Enable.TabIndex = 582;
			this.m_ChbChirp22Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp22Tx2Enable.AutoSize = true;
			this.m_ChbChirp22Tx2Enable.Location = new Point(319, 655);
			this.m_ChbChirp22Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp22Tx2Enable.Name = "m_ChbChirp22Tx2Enable";
			this.m_ChbChirp22Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp22Tx2Enable.TabIndex = 581;
			this.m_ChbChirp22Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp22Tx1Enable.AutoSize = true;
			this.m_ChbChirp22Tx1Enable.Location = new Point(285, 655);
			this.m_ChbChirp22Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp22Tx1Enable.Name = "m_ChbChirp22Tx1Enable";
			this.m_ChbChirp22Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp22Tx1Enable.TabIndex = 580;
			this.m_ChbChirp22Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp22FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp22FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp22FreqSlopeVar.Location = new Point(178, 652);
			this.m_nudChirp22FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp22FreqSlopeVar = this.m_nudChirp22FreqSlopeVar;
			int[] array188 = new int[4];
			array188[0] = 4;
			nudChirp22FreqSlopeVar.Maximum = new decimal(array188);
			this.m_nudChirp22FreqSlopeVar.Name = "m_nudChirp22FreqSlopeVar";
			this.m_nudChirp22FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp22FreqSlopeVar.TabIndex = 579;
			this.m_nudChirp22ProfileIndex.Location = new Point(82, 652);
			this.m_nudChirp22ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp22ProfileIndex = this.m_nudChirp22ProfileIndex;
			int[] array189 = new int[4];
			array189[0] = 3;
			nudChirp22ProfileIndex.Maximum = new decimal(array189);
			this.m_nudChirp22ProfileIndex.Name = "m_nudChirp22ProfileIndex";
			this.m_nudChirp22ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp22ProfileIndex.TabIndex = 578;
			this.m_nudChirp22FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp22FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp22FreqStartVar.Location = new Point(513, 654);
			this.m_nudChirp22FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp22FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp22FreqStartVar.Name = "m_nudChirp22FreqStartVar";
			this.m_nudChirp22FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp22FreqStartVar.TabIndex = 577;
			this.m_nudChirp22ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp22ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp22ADCStartTimeVar.Location = new Point(755, 654);
			this.m_nudChirp22ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp22ADCStartTimeVar = this.m_nudChirp22ADCStartTimeVar;
			int[] array190 = new int[4];
			array190[0] = 4095;
			nudChirp22ADCStartTimeVar.Maximum = new decimal(array190);
			this.m_nudChirp22ADCStartTimeVar.Name = "m_nudChirp22ADCStartTimeVar";
			this.m_nudChirp22ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp22ADCStartTimeVar.TabIndex = 576;
			this.m_nudChirp22IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp22IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp22IdleTimeVar.Location = new Point(647, 654);
			this.m_nudChirp22IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp22IdleTimeVar = this.m_nudChirp22IdleTimeVar;
			int[] array191 = new int[4];
			array191[0] = 4095;
			nudChirp22IdleTimeVar.Maximum = new decimal(array191);
			this.m_nudChirp22IdleTimeVar.Name = "m_nudChirp22IdleTimeVar";
			this.m_nudChirp22IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp22IdleTimeVar.TabIndex = 575;
			this.m_nudChirp20BPMConstVal.Location = new Point(399, 588);
			this.m_nudChirp20BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp20BPMConstVal = this.m_nudChirp20BPMConstVal;
			int[] array192 = new int[4];
			array192[0] = 63;
			nudChirp20BPMConstVal.Maximum = new decimal(array192);
			this.m_nudChirp20BPMConstVal.Name = "m_nudChirp20BPMConstVal";
			this.m_nudChirp20BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp20BPMConstVal.TabIndex = 565;
			this.m_ChbChirp20Tx3Enable.AutoSize = true;
			this.m_ChbChirp20Tx3Enable.Location = new Point(359, 592);
			this.m_ChbChirp20Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp20Tx3Enable.Name = "m_ChbChirp20Tx3Enable";
			this.m_ChbChirp20Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp20Tx3Enable.TabIndex = 573;
			this.m_ChbChirp20Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp20Tx2Enable.AutoSize = true;
			this.m_ChbChirp20Tx2Enable.Location = new Point(319, 593);
			this.m_ChbChirp20Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp20Tx2Enable.Name = "m_ChbChirp20Tx2Enable";
			this.m_ChbChirp20Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp20Tx2Enable.TabIndex = 572;
			this.m_ChbChirp20Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp20Tx1Enable.AutoSize = true;
			this.m_ChbChirp20Tx1Enable.Location = new Point(285, 593);
			this.m_ChbChirp20Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp20Tx1Enable.Name = "m_ChbChirp20Tx1Enable";
			this.m_ChbChirp20Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp20Tx1Enable.TabIndex = 571;
			this.m_ChbChirp20Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp20FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp20FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp20FreqSlopeVar.Location = new Point(178, 591);
			this.m_nudChirp20FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp20FreqSlopeVar = this.m_nudChirp20FreqSlopeVar;
			int[] array193 = new int[4];
			array193[0] = 4;
			nudChirp20FreqSlopeVar.Maximum = new decimal(array193);
			this.m_nudChirp20FreqSlopeVar.Name = "m_nudChirp20FreqSlopeVar";
			this.m_nudChirp20FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp20FreqSlopeVar.TabIndex = 570;
			this.m_nudChirp20ProfileIndex.Location = new Point(82, 591);
			this.m_nudChirp20ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp20ProfileIndex = this.m_nudChirp20ProfileIndex;
			int[] array194 = new int[4];
			array194[0] = 3;
			nudChirp20ProfileIndex.Maximum = new decimal(array194);
			this.m_nudChirp20ProfileIndex.Name = "m_nudChirp20ProfileIndex";
			this.m_nudChirp20ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp20ProfileIndex.TabIndex = 569;
			this.m_nudChirp20FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp20FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp20FreqStartVar.Location = new Point(513, 592);
			this.m_nudChirp20FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp20FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp20FreqStartVar.Name = "m_nudChirp20FreqStartVar";
			this.m_nudChirp20FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp20FreqStartVar.TabIndex = 568;
			this.m_nudChirp20ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp20ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp20ADCStartTimeVar.Location = new Point(755, 592);
			this.m_nudChirp20ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp20ADCStartTimeVar = this.m_nudChirp20ADCStartTimeVar;
			int[] array195 = new int[4];
			array195[0] = 4095;
			nudChirp20ADCStartTimeVar.Maximum = new decimal(array195);
			this.m_nudChirp20ADCStartTimeVar.Name = "m_nudChirp20ADCStartTimeVar";
			this.m_nudChirp20ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp20ADCStartTimeVar.TabIndex = 567;
			this.m_nudChirp20IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp20IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp20IdleTimeVar.Location = new Point(647, 592);
			this.m_nudChirp20IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp20IdleTimeVar = this.m_nudChirp20IdleTimeVar;
			int[] array196 = new int[4];
			array196[0] = 4095;
			nudChirp20IdleTimeVar.Maximum = new decimal(array196);
			this.m_nudChirp20IdleTimeVar.Name = "m_nudChirp20IdleTimeVar";
			this.m_nudChirp20IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp20IdleTimeVar.TabIndex = 566;
			this.m_nudChirp19BPMConstVal.Location = new Point(399, 556);
			this.m_nudChirp19BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp19BPMConstVal = this.m_nudChirp19BPMConstVal;
			int[] array197 = new int[4];
			array197[0] = 63;
			nudChirp19BPMConstVal.Maximum = new decimal(array197);
			this.m_nudChirp19BPMConstVal.Name = "m_nudChirp19BPMConstVal";
			this.m_nudChirp19BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp19BPMConstVal.TabIndex = 556;
			this.m_ChbChirp19Tx3Enable.AutoSize = true;
			this.m_ChbChirp19Tx3Enable.Location = new Point(359, 560);
			this.m_ChbChirp19Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp19Tx3Enable.Name = "m_ChbChirp19Tx3Enable";
			this.m_ChbChirp19Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp19Tx3Enable.TabIndex = 564;
			this.m_ChbChirp19Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp19Tx2Enable.AutoSize = true;
			this.m_ChbChirp19Tx2Enable.Location = new Point(319, 561);
			this.m_ChbChirp19Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp19Tx2Enable.Name = "m_ChbChirp19Tx2Enable";
			this.m_ChbChirp19Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp19Tx2Enable.TabIndex = 563;
			this.m_ChbChirp19Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp19Tx1Enable.AutoSize = true;
			this.m_ChbChirp19Tx1Enable.Location = new Point(285, 561);
			this.m_ChbChirp19Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp19Tx1Enable.Name = "m_ChbChirp19Tx1Enable";
			this.m_ChbChirp19Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp19Tx1Enable.TabIndex = 562;
			this.m_ChbChirp19Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp19FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp19FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp19FreqSlopeVar.Location = new Point(178, 559);
			this.m_nudChirp19FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp19FreqSlopeVar = this.m_nudChirp19FreqSlopeVar;
			int[] array198 = new int[4];
			array198[0] = 4;
			nudChirp19FreqSlopeVar.Maximum = new decimal(array198);
			this.m_nudChirp19FreqSlopeVar.Name = "m_nudChirp19FreqSlopeVar";
			this.m_nudChirp19FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp19FreqSlopeVar.TabIndex = 561;
			this.m_nudChirp19ProfileIndex.Location = new Point(82, 559);
			this.m_nudChirp19ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp19ProfileIndex = this.m_nudChirp19ProfileIndex;
			int[] array199 = new int[4];
			array199[0] = 3;
			nudChirp19ProfileIndex.Maximum = new decimal(array199);
			this.m_nudChirp19ProfileIndex.Name = "m_nudChirp19ProfileIndex";
			this.m_nudChirp19ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp19ProfileIndex.TabIndex = 560;
			this.m_nudChirp19FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp19FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp19FreqStartVar.Location = new Point(513, 560);
			this.m_nudChirp19FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp19FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp19FreqStartVar.Name = "m_nudChirp19FreqStartVar";
			this.m_nudChirp19FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp19FreqStartVar.TabIndex = 559;
			this.m_nudChirp19ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp19ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp19ADCStartTimeVar.Location = new Point(755, 560);
			this.m_nudChirp19ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp19ADCStartTimeVar = this.m_nudChirp19ADCStartTimeVar;
			int[] array200 = new int[4];
			array200[0] = 4095;
			nudChirp19ADCStartTimeVar.Maximum = new decimal(array200);
			this.m_nudChirp19ADCStartTimeVar.Name = "m_nudChirp19ADCStartTimeVar";
			this.m_nudChirp19ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp19ADCStartTimeVar.TabIndex = 558;
			this.m_nudChirp19IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp19IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp19IdleTimeVar.Location = new Point(647, 560);
			this.m_nudChirp19IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp19IdleTimeVar = this.m_nudChirp19IdleTimeVar;
			int[] array201 = new int[4];
			array201[0] = 4095;
			nudChirp19IdleTimeVar.Maximum = new decimal(array201);
			this.m_nudChirp19IdleTimeVar.Name = "m_nudChirp19IdleTimeVar";
			this.m_nudChirp19IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp19IdleTimeVar.TabIndex = 557;
			this.m_nudChirp18BPMConstVal.Location = new Point(399, 526);
			this.m_nudChirp18BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp18BPMConstVal = this.m_nudChirp18BPMConstVal;
			int[] array202 = new int[4];
			array202[0] = 63;
			nudChirp18BPMConstVal.Maximum = new decimal(array202);
			this.m_nudChirp18BPMConstVal.Name = "m_nudChirp18BPMConstVal";
			this.m_nudChirp18BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp18BPMConstVal.TabIndex = 547;
			this.m_ChbChirp18Tx3Enable.AutoSize = true;
			this.m_ChbChirp18Tx3Enable.Location = new Point(359, 529);
			this.m_ChbChirp18Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp18Tx3Enable.Name = "m_ChbChirp18Tx3Enable";
			this.m_ChbChirp18Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp18Tx3Enable.TabIndex = 555;
			this.m_ChbChirp18Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp18Tx2Enable.AutoSize = true;
			this.m_ChbChirp18Tx2Enable.Location = new Point(319, 530);
			this.m_ChbChirp18Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp18Tx2Enable.Name = "m_ChbChirp18Tx2Enable";
			this.m_ChbChirp18Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp18Tx2Enable.TabIndex = 554;
			this.m_ChbChirp18Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp18Tx1Enable.AutoSize = true;
			this.m_ChbChirp18Tx1Enable.Location = new Point(285, 530);
			this.m_ChbChirp18Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp18Tx1Enable.Name = "m_ChbChirp18Tx1Enable";
			this.m_ChbChirp18Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp18Tx1Enable.TabIndex = 553;
			this.m_ChbChirp18Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp18FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp18FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp18FreqSlopeVar.Location = new Point(178, 528);
			this.m_nudChirp18FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp18FreqSlopeVar = this.m_nudChirp18FreqSlopeVar;
			int[] array203 = new int[4];
			array203[0] = 4;
			nudChirp18FreqSlopeVar.Maximum = new decimal(array203);
			this.m_nudChirp18FreqSlopeVar.Name = "m_nudChirp18FreqSlopeVar";
			this.m_nudChirp18FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp18FreqSlopeVar.TabIndex = 552;
			this.m_nudChirp18ProfileIndex.Location = new Point(82, 528);
			this.m_nudChirp18ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp18ProfileIndex = this.m_nudChirp18ProfileIndex;
			int[] array204 = new int[4];
			array204[0] = 3;
			nudChirp18ProfileIndex.Maximum = new decimal(array204);
			this.m_nudChirp18ProfileIndex.Name = "m_nudChirp18ProfileIndex";
			this.m_nudChirp18ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp18ProfileIndex.TabIndex = 551;
			this.m_nudChirp18FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp18FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp18FreqStartVar.Location = new Point(513, 529);
			this.m_nudChirp18FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp18FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp18FreqStartVar.Name = "m_nudChirp18FreqStartVar";
			this.m_nudChirp18FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp18FreqStartVar.TabIndex = 550;
			this.m_nudChirp18ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp18ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp18ADCStartTimeVar.Location = new Point(755, 529);
			this.m_nudChirp18ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp18ADCStartTimeVar = this.m_nudChirp18ADCStartTimeVar;
			int[] array205 = new int[4];
			array205[0] = 4095;
			nudChirp18ADCStartTimeVar.Maximum = new decimal(array205);
			this.m_nudChirp18ADCStartTimeVar.Name = "m_nudChirp18ADCStartTimeVar";
			this.m_nudChirp18ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp18ADCStartTimeVar.TabIndex = 549;
			this.m_nudChirp18IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp18IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp18IdleTimeVar.Location = new Point(647, 529);
			this.m_nudChirp18IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp18IdleTimeVar = this.m_nudChirp18IdleTimeVar;
			int[] array206 = new int[4];
			array206[0] = 4095;
			nudChirp18IdleTimeVar.Maximum = new decimal(array206);
			this.m_nudChirp18IdleTimeVar.Name = "m_nudChirp18IdleTimeVar";
			this.m_nudChirp18IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp18IdleTimeVar.TabIndex = 548;
			this.m_nudChirp17BPMConstVal.Location = new Point(399, 497);
			this.m_nudChirp17BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp17BPMConstVal = this.m_nudChirp17BPMConstVal;
			int[] array207 = new int[4];
			array207[0] = 63;
			nudChirp17BPMConstVal.Maximum = new decimal(array207);
			this.m_nudChirp17BPMConstVal.Name = "m_nudChirp17BPMConstVal";
			this.m_nudChirp17BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp17BPMConstVal.TabIndex = 538;
			this.m_ChbChirp17Tx3Enable.AutoSize = true;
			this.m_ChbChirp17Tx3Enable.Location = new Point(359, 501);
			this.m_ChbChirp17Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp17Tx3Enable.Name = "m_ChbChirp17Tx3Enable";
			this.m_ChbChirp17Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp17Tx3Enable.TabIndex = 546;
			this.m_ChbChirp17Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp17Tx2Enable.AutoSize = true;
			this.m_ChbChirp17Tx2Enable.Location = new Point(319, 502);
			this.m_ChbChirp17Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp17Tx2Enable.Name = "m_ChbChirp17Tx2Enable";
			this.m_ChbChirp17Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp17Tx2Enable.TabIndex = 545;
			this.m_ChbChirp17Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp17Tx1Enable.AutoSize = true;
			this.m_ChbChirp17Tx1Enable.Location = new Point(285, 502);
			this.m_ChbChirp17Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp17Tx1Enable.Name = "m_ChbChirp17Tx1Enable";
			this.m_ChbChirp17Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp17Tx1Enable.TabIndex = 544;
			this.m_ChbChirp17Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp17FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp17FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp17FreqSlopeVar.Location = new Point(178, 500);
			this.m_nudChirp17FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp17FreqSlopeVar = this.m_nudChirp17FreqSlopeVar;
			int[] array208 = new int[4];
			array208[0] = 4;
			nudChirp17FreqSlopeVar.Maximum = new decimal(array208);
			this.m_nudChirp17FreqSlopeVar.Name = "m_nudChirp17FreqSlopeVar";
			this.m_nudChirp17FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp17FreqSlopeVar.TabIndex = 543;
			this.m_nudChirp17ProfileIndex.Location = new Point(82, 500);
			this.m_nudChirp17ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp17ProfileIndex = this.m_nudChirp17ProfileIndex;
			int[] array209 = new int[4];
			array209[0] = 3;
			nudChirp17ProfileIndex.Maximum = new decimal(array209);
			this.m_nudChirp17ProfileIndex.Name = "m_nudChirp17ProfileIndex";
			this.m_nudChirp17ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp17ProfileIndex.TabIndex = 542;
			this.m_nudChirp17FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp17FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp17FreqStartVar.Location = new Point(513, 501);
			this.m_nudChirp17FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp17FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp17FreqStartVar.Name = "m_nudChirp17FreqStartVar";
			this.m_nudChirp17FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp17FreqStartVar.TabIndex = 541;
			this.m_nudChirp17ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp17ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp17ADCStartTimeVar.Location = new Point(755, 501);
			this.m_nudChirp17ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp17ADCStartTimeVar = this.m_nudChirp17ADCStartTimeVar;
			int[] array210 = new int[4];
			array210[0] = 4095;
			nudChirp17ADCStartTimeVar.Maximum = new decimal(array210);
			this.m_nudChirp17ADCStartTimeVar.Name = "m_nudChirp17ADCStartTimeVar";
			this.m_nudChirp17ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp17ADCStartTimeVar.TabIndex = 540;
			this.m_nudChirp17IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp17IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp17IdleTimeVar.Location = new Point(647, 501);
			this.m_nudChirp17IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp17IdleTimeVar = this.m_nudChirp17IdleTimeVar;
			int[] array211 = new int[4];
			array211[0] = 4095;
			nudChirp17IdleTimeVar.Maximum = new decimal(array211);
			this.m_nudChirp17IdleTimeVar.Name = "m_nudChirp17IdleTimeVar";
			this.m_nudChirp17IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp17IdleTimeVar.TabIndex = 539;
			this.label50.AutoSize = true;
			this.label50.Location = new Point(3, 808);
			this.label50.Margin = new Padding(4, 0, 4, 0);
			this.label50.Name = "label50";
			this.label50.Size = new Size(61, 17);
			this.label50.TabIndex = 537;
			this.label50.Text = "Chirp 27";
			this.label51.AutoSize = true;
			this.label51.Location = new Point(3, 840);
			this.label51.Margin = new Padding(4, 0, 4, 0);
			this.label51.Name = "label51";
			this.label51.Size = new Size(61, 17);
			this.label51.TabIndex = 536;
			this.label51.Text = "Chirp 28";
			this.label53.AutoSize = true;
			this.label53.Location = new Point(3, 747);
			this.label53.Margin = new Padding(4, 0, 4, 0);
			this.label53.Name = "label53";
			this.label53.Size = new Size(61, 17);
			this.label53.TabIndex = 535;
			this.label53.Text = "Chirp 25";
			this.label56.AutoSize = true;
			this.label56.Location = new Point(3, 779);
			this.label56.Margin = new Padding(4, 0, 4, 0);
			this.label56.Name = "label56";
			this.label56.Size = new Size(61, 17);
			this.label56.TabIndex = 534;
			this.label56.Text = "Chirp 26";
			this.label57.AutoSize = true;
			this.label57.Location = new Point(3, 684);
			this.label57.Margin = new Padding(4, 0, 4, 0);
			this.label57.Name = "label57";
			this.label57.Size = new Size(61, 17);
			this.label57.TabIndex = 533;
			this.label57.Text = "Chirp 23";
			this.label58.AutoSize = true;
			this.label58.Location = new Point(3, 715);
			this.label58.Margin = new Padding(4, 0, 4, 0);
			this.label58.Name = "label58";
			this.label58.Size = new Size(61, 17);
			this.label58.TabIndex = 532;
			this.label58.Text = "Chirp 24";
			this.label59.AutoSize = true;
			this.label59.Location = new Point(3, 503);
			this.label59.Margin = new Padding(4, 0, 4, 0);
			this.label59.Name = "label59";
			this.label59.Size = new Size(61, 17);
			this.label59.TabIndex = 531;
			this.label59.Text = "Chirp 17";
			this.label60.AutoSize = true;
			this.label60.Location = new Point(3, 626);
			this.label60.Margin = new Padding(4, 0, 4, 0);
			this.label60.Name = "label60";
			this.label60.Size = new Size(61, 17);
			this.label60.TabIndex = 530;
			this.label60.Text = "Chirp 21";
			this.label61.AutoSize = true;
			this.label61.Location = new Point(3, 657);
			this.label61.Margin = new Padding(4, 0, 4, 0);
			this.label61.Name = "label61";
			this.label61.Size = new Size(61, 17);
			this.label61.TabIndex = 529;
			this.label61.Text = "Chirp 22";
			this.label62.AutoSize = true;
			this.label62.Location = new Point(3, 531);
			this.label62.Margin = new Padding(4, 0, 4, 0);
			this.label62.Name = "label62";
			this.label62.Size = new Size(61, 17);
			this.label62.TabIndex = 528;
			this.label62.Text = "Chirp 18";
			this.label63.AutoSize = true;
			this.label63.Location = new Point(3, 561);
			this.label63.Margin = new Padding(4, 0, 4, 0);
			this.label63.Name = "label63";
			this.label63.Size = new Size(61, 17);
			this.label63.TabIndex = 527;
			this.label63.Text = "Chirp 19";
			this.label64.AutoSize = true;
			this.label64.Location = new Point(3, 590);
			this.label64.Margin = new Padding(4, 0, 4, 0);
			this.label64.Name = "label64";
			this.label64.Size = new Size(61, 17);
			this.label64.TabIndex = 526;
			this.label64.Text = "Chirp 20";
			this.m_nudChirp16BPMConstVal.Location = new Point(399, 464);
			this.m_nudChirp16BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp16BPMConstVal = this.m_nudChirp16BPMConstVal;
			int[] array212 = new int[4];
			array212[0] = 63;
			nudChirp16BPMConstVal.Maximum = new decimal(array212);
			this.m_nudChirp16BPMConstVal.Name = "m_nudChirp16BPMConstVal";
			this.m_nudChirp16BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp16BPMConstVal.TabIndex = 517;
			this.m_ChbChirp16Tx3Enable.AutoSize = true;
			this.m_ChbChirp16Tx3Enable.Location = new Point(359, 468);
			this.m_ChbChirp16Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp16Tx3Enable.Name = "m_ChbChirp16Tx3Enable";
			this.m_ChbChirp16Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp16Tx3Enable.TabIndex = 525;
			this.m_ChbChirp16Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp16Tx2Enable.AutoSize = true;
			this.m_ChbChirp16Tx2Enable.Location = new Point(319, 469);
			this.m_ChbChirp16Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp16Tx2Enable.Name = "m_ChbChirp16Tx2Enable";
			this.m_ChbChirp16Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp16Tx2Enable.TabIndex = 524;
			this.m_ChbChirp16Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp16Tx1Enable.AutoSize = true;
			this.m_ChbChirp16Tx1Enable.Location = new Point(285, 469);
			this.m_ChbChirp16Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp16Tx1Enable.Name = "m_ChbChirp16Tx1Enable";
			this.m_ChbChirp16Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp16Tx1Enable.TabIndex = 523;
			this.m_ChbChirp16Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp16FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp16FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp16FreqSlopeVar.Location = new Point(178, 467);
			this.m_nudChirp16FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp16FreqSlopeVar = this.m_nudChirp16FreqSlopeVar;
			int[] array213 = new int[4];
			array213[0] = 4;
			nudChirp16FreqSlopeVar.Maximum = new decimal(array213);
			this.m_nudChirp16FreqSlopeVar.Name = "m_nudChirp16FreqSlopeVar";
			this.m_nudChirp16FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp16FreqSlopeVar.TabIndex = 522;
			this.m_nudChirp16ProfileIndex.Location = new Point(82, 467);
			this.m_nudChirp16ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp16ProfileIndex = this.m_nudChirp16ProfileIndex;
			int[] array214 = new int[4];
			array214[0] = 3;
			nudChirp16ProfileIndex.Maximum = new decimal(array214);
			this.m_nudChirp16ProfileIndex.Name = "m_nudChirp16ProfileIndex";
			this.m_nudChirp16ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp16ProfileIndex.TabIndex = 521;
			this.m_nudChirp16FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp16FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp16FreqStartVar.Location = new Point(513, 468);
			this.m_nudChirp16FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp16FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp16FreqStartVar.Name = "m_nudChirp16FreqStartVar";
			this.m_nudChirp16FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp16FreqStartVar.TabIndex = 520;
			this.m_nudChirp16ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp16ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp16ADCStartTimeVar.Location = new Point(755, 468);
			this.m_nudChirp16ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp16ADCStartTimeVar = this.m_nudChirp16ADCStartTimeVar;
			int[] array215 = new int[4];
			array215[0] = 4095;
			nudChirp16ADCStartTimeVar.Maximum = new decimal(array215);
			this.m_nudChirp16ADCStartTimeVar.Name = "m_nudChirp16ADCStartTimeVar";
			this.m_nudChirp16ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp16ADCStartTimeVar.TabIndex = 519;
			this.m_nudChirp16IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp16IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp16IdleTimeVar.Location = new Point(647, 468);
			this.m_nudChirp16IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp16IdleTimeVar = this.m_nudChirp16IdleTimeVar;
			int[] array216 = new int[4];
			array216[0] = 4095;
			nudChirp16IdleTimeVar.Maximum = new decimal(array216);
			this.m_nudChirp16IdleTimeVar.Name = "m_nudChirp16IdleTimeVar";
			this.m_nudChirp16IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp16IdleTimeVar.TabIndex = 518;
			this.m_nudChirp14BPMConstVal.Location = new Point(399, 403);
			this.m_nudChirp14BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp14BPMConstVal = this.m_nudChirp14BPMConstVal;
			int[] array217 = new int[4];
			array217[0] = 63;
			nudChirp14BPMConstVal.Maximum = new decimal(array217);
			this.m_nudChirp14BPMConstVal.Name = "m_nudChirp14BPMConstVal";
			this.m_nudChirp14BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp14BPMConstVal.TabIndex = 508;
			this.m_ChbChirp14Tx3Enable.AutoSize = true;
			this.m_ChbChirp14Tx3Enable.Location = new Point(359, 407);
			this.m_ChbChirp14Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp14Tx3Enable.Name = "m_ChbChirp14Tx3Enable";
			this.m_ChbChirp14Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp14Tx3Enable.TabIndex = 516;
			this.m_ChbChirp14Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp14Tx2Enable.AutoSize = true;
			this.m_ChbChirp14Tx2Enable.Location = new Point(319, 408);
			this.m_ChbChirp14Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp14Tx2Enable.Name = "m_ChbChirp14Tx2Enable";
			this.m_ChbChirp14Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp14Tx2Enable.TabIndex = 515;
			this.m_ChbChirp14Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp14Tx1Enable.AutoSize = true;
			this.m_ChbChirp14Tx1Enable.Location = new Point(285, 408);
			this.m_ChbChirp14Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp14Tx1Enable.Name = "m_ChbChirp14Tx1Enable";
			this.m_ChbChirp14Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp14Tx1Enable.TabIndex = 514;
			this.m_ChbChirp14Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp14FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp14FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp14FreqSlopeVar.Location = new Point(178, 405);
			this.m_nudChirp14FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp14FreqSlopeVar = this.m_nudChirp14FreqSlopeVar;
			int[] array218 = new int[4];
			array218[0] = 4;
			nudChirp14FreqSlopeVar.Maximum = new decimal(array218);
			this.m_nudChirp14FreqSlopeVar.Name = "m_nudChirp14FreqSlopeVar";
			this.m_nudChirp14FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp14FreqSlopeVar.TabIndex = 513;
			this.m_nudChirp14ProfileIndex.Location = new Point(82, 405);
			this.m_nudChirp14ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp14ProfileIndex = this.m_nudChirp14ProfileIndex;
			int[] array219 = new int[4];
			array219[0] = 3;
			nudChirp14ProfileIndex.Maximum = new decimal(array219);
			this.m_nudChirp14ProfileIndex.Name = "m_nudChirp14ProfileIndex";
			this.m_nudChirp14ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp14ProfileIndex.TabIndex = 512;
			this.m_nudChirp14FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp14FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp14FreqStartVar.Location = new Point(513, 407);
			this.m_nudChirp14FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp14FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp14FreqStartVar.Name = "m_nudChirp14FreqStartVar";
			this.m_nudChirp14FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp14FreqStartVar.TabIndex = 511;
			this.m_nudChirp14ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp14ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp14ADCStartTimeVar.Location = new Point(755, 407);
			this.m_nudChirp14ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp14ADCStartTimeVar = this.m_nudChirp14ADCStartTimeVar;
			int[] array220 = new int[4];
			array220[0] = 4095;
			nudChirp14ADCStartTimeVar.Maximum = new decimal(array220);
			this.m_nudChirp14ADCStartTimeVar.Name = "m_nudChirp14ADCStartTimeVar";
			this.m_nudChirp14ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp14ADCStartTimeVar.TabIndex = 510;
			this.m_nudChirp14IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp14IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp14IdleTimeVar.Location = new Point(647, 407);
			this.m_nudChirp14IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp14IdleTimeVar = this.m_nudChirp14IdleTimeVar;
			int[] array221 = new int[4];
			array221[0] = 4095;
			nudChirp14IdleTimeVar.Maximum = new decimal(array221);
			this.m_nudChirp14IdleTimeVar.Name = "m_nudChirp14IdleTimeVar";
			this.m_nudChirp14IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp14IdleTimeVar.TabIndex = 509;
			this.m_nudChirp15BPMConstVal.Location = new Point(399, 432);
			this.m_nudChirp15BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp15BPMConstVal = this.m_nudChirp15BPMConstVal;
			int[] array222 = new int[4];
			array222[0] = 63;
			nudChirp15BPMConstVal.Maximum = new decimal(array222);
			this.m_nudChirp15BPMConstVal.Name = "m_nudChirp15BPMConstVal";
			this.m_nudChirp15BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp15BPMConstVal.TabIndex = 499;
			this.m_ChbChirp15Tx3Enable.AutoSize = true;
			this.m_ChbChirp15Tx3Enable.Location = new Point(359, 436);
			this.m_ChbChirp15Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp15Tx3Enable.Name = "m_ChbChirp15Tx3Enable";
			this.m_ChbChirp15Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp15Tx3Enable.TabIndex = 507;
			this.m_ChbChirp15Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp15Tx2Enable.AutoSize = true;
			this.m_ChbChirp15Tx2Enable.Location = new Point(319, 437);
			this.m_ChbChirp15Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp15Tx2Enable.Name = "m_ChbChirp15Tx2Enable";
			this.m_ChbChirp15Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp15Tx2Enable.TabIndex = 506;
			this.m_ChbChirp15Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp15Tx1Enable.AutoSize = true;
			this.m_ChbChirp15Tx1Enable.Location = new Point(285, 437);
			this.m_ChbChirp15Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp15Tx1Enable.Name = "m_ChbChirp15Tx1Enable";
			this.m_ChbChirp15Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp15Tx1Enable.TabIndex = 505;
			this.m_ChbChirp15Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp15FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp15FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp15FreqSlopeVar.Location = new Point(178, 435);
			this.m_nudChirp15FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp15FreqSlopeVar = this.m_nudChirp15FreqSlopeVar;
			int[] array223 = new int[4];
			array223[0] = 4;
			nudChirp15FreqSlopeVar.Maximum = new decimal(array223);
			this.m_nudChirp15FreqSlopeVar.Name = "m_nudChirp15FreqSlopeVar";
			this.m_nudChirp15FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp15FreqSlopeVar.TabIndex = 504;
			this.m_nudChirp15ProfileIndex.Location = new Point(82, 435);
			this.m_nudChirp15ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp15ProfileIndex = this.m_nudChirp15ProfileIndex;
			int[] array224 = new int[4];
			array224[0] = 3;
			nudChirp15ProfileIndex.Maximum = new decimal(array224);
			this.m_nudChirp15ProfileIndex.Name = "m_nudChirp15ProfileIndex";
			this.m_nudChirp15ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp15ProfileIndex.TabIndex = 503;
			this.m_nudChirp15FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp15FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp15FreqStartVar.Location = new Point(513, 436);
			this.m_nudChirp15FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp15FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp15FreqStartVar.Name = "m_nudChirp15FreqStartVar";
			this.m_nudChirp15FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp15FreqStartVar.TabIndex = 502;
			this.m_nudChirp15ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp15ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp15ADCStartTimeVar.Location = new Point(755, 436);
			this.m_nudChirp15ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp15ADCStartTimeVar = this.m_nudChirp15ADCStartTimeVar;
			int[] array225 = new int[4];
			array225[0] = 4095;
			nudChirp15ADCStartTimeVar.Maximum = new decimal(array225);
			this.m_nudChirp15ADCStartTimeVar.Name = "m_nudChirp15ADCStartTimeVar";
			this.m_nudChirp15ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp15ADCStartTimeVar.TabIndex = 501;
			this.m_nudChirp15IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp15IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp15IdleTimeVar.Location = new Point(647, 436);
			this.m_nudChirp15IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp15IdleTimeVar = this.m_nudChirp15IdleTimeVar;
			int[] array226 = new int[4];
			array226[0] = 4095;
			nudChirp15IdleTimeVar.Maximum = new decimal(array226);
			this.m_nudChirp15IdleTimeVar.Name = "m_nudChirp15IdleTimeVar";
			this.m_nudChirp15IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp15IdleTimeVar.TabIndex = 500;
			this.m_nudChirp13BPMConstVal.Location = new Point(399, 371);
			this.m_nudChirp13BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp13BPMConstVal = this.m_nudChirp13BPMConstVal;
			int[] array227 = new int[4];
			array227[0] = 63;
			nudChirp13BPMConstVal.Maximum = new decimal(array227);
			this.m_nudChirp13BPMConstVal.Name = "m_nudChirp13BPMConstVal";
			this.m_nudChirp13BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp13BPMConstVal.TabIndex = 490;
			this.m_ChbChirp13Tx3Enable.AutoSize = true;
			this.m_ChbChirp13Tx3Enable.Location = new Point(359, 375);
			this.m_ChbChirp13Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp13Tx3Enable.Name = "m_ChbChirp13Tx3Enable";
			this.m_ChbChirp13Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp13Tx3Enable.TabIndex = 498;
			this.m_ChbChirp13Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp13Tx2Enable.AutoSize = true;
			this.m_ChbChirp13Tx2Enable.Location = new Point(319, 376);
			this.m_ChbChirp13Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp13Tx2Enable.Name = "m_ChbChirp13Tx2Enable";
			this.m_ChbChirp13Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp13Tx2Enable.TabIndex = 497;
			this.m_ChbChirp13Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp13Tx1Enable.AutoSize = true;
			this.m_ChbChirp13Tx1Enable.Location = new Point(285, 376);
			this.m_ChbChirp13Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp13Tx1Enable.Name = "m_ChbChirp13Tx1Enable";
			this.m_ChbChirp13Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp13Tx1Enable.TabIndex = 496;
			this.m_ChbChirp13Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp13FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp13FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp13FreqSlopeVar.Location = new Point(178, 373);
			this.m_nudChirp13FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp13FreqSlopeVar = this.m_nudChirp13FreqSlopeVar;
			int[] array228 = new int[4];
			array228[0] = 4;
			nudChirp13FreqSlopeVar.Maximum = new decimal(array228);
			this.m_nudChirp13FreqSlopeVar.Name = "m_nudChirp13FreqSlopeVar";
			this.m_nudChirp13FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp13FreqSlopeVar.TabIndex = 495;
			this.m_nudChirp13ProfileIndex.Location = new Point(82, 373);
			this.m_nudChirp13ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp13ProfileIndex = this.m_nudChirp13ProfileIndex;
			int[] array229 = new int[4];
			array229[0] = 3;
			nudChirp13ProfileIndex.Maximum = new decimal(array229);
			this.m_nudChirp13ProfileIndex.Name = "m_nudChirp13ProfileIndex";
			this.m_nudChirp13ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp13ProfileIndex.TabIndex = 494;
			this.m_nudChirp13FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp13FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp13FreqStartVar.Location = new Point(513, 375);
			this.m_nudChirp13FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp13FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp13FreqStartVar.Name = "m_nudChirp13FreqStartVar";
			this.m_nudChirp13FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp13FreqStartVar.TabIndex = 493;
			this.m_nudChirp13ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp13ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp13ADCStartTimeVar.Location = new Point(755, 375);
			this.m_nudChirp13ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp13ADCStartTimeVar = this.m_nudChirp13ADCStartTimeVar;
			int[] array230 = new int[4];
			array230[0] = 4095;
			nudChirp13ADCStartTimeVar.Maximum = new decimal(array230);
			this.m_nudChirp13ADCStartTimeVar.Name = "m_nudChirp13ADCStartTimeVar";
			this.m_nudChirp13ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp13ADCStartTimeVar.TabIndex = 492;
			this.m_nudChirp13IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp13IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp13IdleTimeVar.Location = new Point(647, 375);
			this.m_nudChirp13IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp13IdleTimeVar = this.m_nudChirp13IdleTimeVar;
			int[] array231 = new int[4];
			array231[0] = 4095;
			nudChirp13IdleTimeVar.Maximum = new decimal(array231);
			this.m_nudChirp13IdleTimeVar.Name = "m_nudChirp13IdleTimeVar";
			this.m_nudChirp13IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp13IdleTimeVar.TabIndex = 491;
			this.m_nudChirp12BPMConstVal.Location = new Point(399, 339);
			this.m_nudChirp12BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp12BPMConstVal = this.m_nudChirp12BPMConstVal;
			int[] array232 = new int[4];
			array232[0] = 63;
			nudChirp12BPMConstVal.Maximum = new decimal(array232);
			this.m_nudChirp12BPMConstVal.Name = "m_nudChirp12BPMConstVal";
			this.m_nudChirp12BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp12BPMConstVal.TabIndex = 481;
			this.m_ChbChirp12Tx3Enable.AutoSize = true;
			this.m_ChbChirp12Tx3Enable.Location = new Point(359, 343);
			this.m_ChbChirp12Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp12Tx3Enable.Name = "m_ChbChirp12Tx3Enable";
			this.m_ChbChirp12Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp12Tx3Enable.TabIndex = 489;
			this.m_ChbChirp12Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp12Tx2Enable.AutoSize = true;
			this.m_ChbChirp12Tx2Enable.Location = new Point(319, 344);
			this.m_ChbChirp12Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp12Tx2Enable.Name = "m_ChbChirp12Tx2Enable";
			this.m_ChbChirp12Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp12Tx2Enable.TabIndex = 488;
			this.m_ChbChirp12Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp12Tx1Enable.AutoSize = true;
			this.m_ChbChirp12Tx1Enable.Location = new Point(285, 344);
			this.m_ChbChirp12Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp12Tx1Enable.Name = "m_ChbChirp12Tx1Enable";
			this.m_ChbChirp12Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp12Tx1Enable.TabIndex = 487;
			this.m_ChbChirp12Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp12FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp12FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp12FreqSlopeVar.Location = new Point(178, 341);
			this.m_nudChirp12FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp12FreqSlopeVar = this.m_nudChirp12FreqSlopeVar;
			int[] array233 = new int[4];
			array233[0] = 4;
			nudChirp12FreqSlopeVar.Maximum = new decimal(array233);
			this.m_nudChirp12FreqSlopeVar.Name = "m_nudChirp12FreqSlopeVar";
			this.m_nudChirp12FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp12FreqSlopeVar.TabIndex = 486;
			this.m_nudChirp12ProfileIndex.Location = new Point(82, 341);
			this.m_nudChirp12ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp12ProfileIndex = this.m_nudChirp12ProfileIndex;
			int[] array234 = new int[4];
			array234[0] = 3;
			nudChirp12ProfileIndex.Maximum = new decimal(array234);
			this.m_nudChirp12ProfileIndex.Name = "m_nudChirp12ProfileIndex";
			this.m_nudChirp12ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp12ProfileIndex.TabIndex = 485;
			this.m_nudChirp12FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp12FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp12FreqStartVar.Location = new Point(513, 343);
			this.m_nudChirp12FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp12FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp12FreqStartVar.Name = "m_nudChirp12FreqStartVar";
			this.m_nudChirp12FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp12FreqStartVar.TabIndex = 484;
			this.m_nudChirp12ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp12ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp12ADCStartTimeVar.Location = new Point(755, 343);
			this.m_nudChirp12ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp12ADCStartTimeVar = this.m_nudChirp12ADCStartTimeVar;
			int[] array235 = new int[4];
			array235[0] = 4095;
			nudChirp12ADCStartTimeVar.Maximum = new decimal(array235);
			this.m_nudChirp12ADCStartTimeVar.Name = "m_nudChirp12ADCStartTimeVar";
			this.m_nudChirp12ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp12ADCStartTimeVar.TabIndex = 483;
			this.m_nudChirp12IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp12IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp12IdleTimeVar.Location = new Point(647, 343);
			this.m_nudChirp12IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp12IdleTimeVar = this.m_nudChirp12IdleTimeVar;
			int[] array236 = new int[4];
			array236[0] = 4095;
			nudChirp12IdleTimeVar.Maximum = new decimal(array236);
			this.m_nudChirp12IdleTimeVar.Name = "m_nudChirp12IdleTimeVar";
			this.m_nudChirp12IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp12IdleTimeVar.TabIndex = 482;
			this.m_nudChirp11BPMConstVal.Location = new Point(399, 308);
			this.m_nudChirp11BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp11BPMConstVal = this.m_nudChirp11BPMConstVal;
			int[] array237 = new int[4];
			array237[0] = 63;
			nudChirp11BPMConstVal.Maximum = new decimal(array237);
			this.m_nudChirp11BPMConstVal.Name = "m_nudChirp11BPMConstVal";
			this.m_nudChirp11BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp11BPMConstVal.TabIndex = 472;
			this.m_ChbChirp11Tx3Enable.AutoSize = true;
			this.m_ChbChirp11Tx3Enable.Location = new Point(359, 312);
			this.m_ChbChirp11Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp11Tx3Enable.Name = "m_ChbChirp11Tx3Enable";
			this.m_ChbChirp11Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp11Tx3Enable.TabIndex = 480;
			this.m_ChbChirp11Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp11Tx2Enable.AutoSize = true;
			this.m_ChbChirp11Tx2Enable.Location = new Point(319, 313);
			this.m_ChbChirp11Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp11Tx2Enable.Name = "m_ChbChirp11Tx2Enable";
			this.m_ChbChirp11Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp11Tx2Enable.TabIndex = 479;
			this.m_ChbChirp11Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp11Tx1Enable.AutoSize = true;
			this.m_ChbChirp11Tx1Enable.Location = new Point(285, 313);
			this.m_ChbChirp11Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp11Tx1Enable.Name = "m_ChbChirp11Tx1Enable";
			this.m_ChbChirp11Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp11Tx1Enable.TabIndex = 478;
			this.m_ChbChirp11Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp11FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp11FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp11FreqSlopeVar.Location = new Point(178, 311);
			this.m_nudChirp11FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp11FreqSlopeVar = this.m_nudChirp11FreqSlopeVar;
			int[] array238 = new int[4];
			array238[0] = 4;
			nudChirp11FreqSlopeVar.Maximum = new decimal(array238);
			this.m_nudChirp11FreqSlopeVar.Name = "m_nudChirp11FreqSlopeVar";
			this.m_nudChirp11FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp11FreqSlopeVar.TabIndex = 477;
			this.m_nudChirp11ProfileIndex.Location = new Point(82, 311);
			this.m_nudChirp11ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp11ProfileIndex = this.m_nudChirp11ProfileIndex;
			int[] array239 = new int[4];
			array239[0] = 3;
			nudChirp11ProfileIndex.Maximum = new decimal(array239);
			this.m_nudChirp11ProfileIndex.Name = "m_nudChirp11ProfileIndex";
			this.m_nudChirp11ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp11ProfileIndex.TabIndex = 476;
			this.m_nudChirp11FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp11FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp11FreqStartVar.Location = new Point(513, 312);
			this.m_nudChirp11FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp11FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp11FreqStartVar.Name = "m_nudChirp11FreqStartVar";
			this.m_nudChirp11FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp11FreqStartVar.TabIndex = 475;
			this.m_nudChirp11ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp11ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp11ADCStartTimeVar.Location = new Point(755, 312);
			this.m_nudChirp11ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp11ADCStartTimeVar = this.m_nudChirp11ADCStartTimeVar;
			int[] array240 = new int[4];
			array240[0] = 4095;
			nudChirp11ADCStartTimeVar.Maximum = new decimal(array240);
			this.m_nudChirp11ADCStartTimeVar.Name = "m_nudChirp11ADCStartTimeVar";
			this.m_nudChirp11ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp11ADCStartTimeVar.TabIndex = 474;
			this.m_nudChirp11IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp11IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp11IdleTimeVar.Location = new Point(647, 312);
			this.m_nudChirp11IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp11IdleTimeVar = this.m_nudChirp11IdleTimeVar;
			int[] array241 = new int[4];
			array241[0] = 4095;
			nudChirp11IdleTimeVar.Maximum = new decimal(array241);
			this.m_nudChirp11IdleTimeVar.Name = "m_nudChirp11IdleTimeVar";
			this.m_nudChirp11IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp11IdleTimeVar.TabIndex = 473;
			this.m_nudChirp9BPMConstVal.Location = new Point(399, 250);
			this.m_nudChirp9BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp9BPMConstVal = this.m_nudChirp9BPMConstVal;
			int[] array242 = new int[4];
			array242[0] = 63;
			nudChirp9BPMConstVal.Maximum = new decimal(array242);
			this.m_nudChirp9BPMConstVal.Name = "m_nudChirp9BPMConstVal";
			this.m_nudChirp9BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp9BPMConstVal.TabIndex = 463;
			this.m_ChbChirp9Tx3Enable.AutoSize = true;
			this.m_ChbChirp9Tx3Enable.Location = new Point(359, 254);
			this.m_ChbChirp9Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp9Tx3Enable.Name = "m_ChbChirp9Tx3Enable";
			this.m_ChbChirp9Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp9Tx3Enable.TabIndex = 471;
			this.m_ChbChirp9Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp9Tx2Enable.AutoSize = true;
			this.m_ChbChirp9Tx2Enable.Location = new Point(319, 255);
			this.m_ChbChirp9Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp9Tx2Enable.Name = "m_ChbChirp9Tx2Enable";
			this.m_ChbChirp9Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp9Tx2Enable.TabIndex = 470;
			this.m_ChbChirp9Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp9Tx1Enable.AutoSize = true;
			this.m_ChbChirp9Tx1Enable.Location = new Point(285, 255);
			this.m_ChbChirp9Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp9Tx1Enable.Name = "m_ChbChirp9Tx1Enable";
			this.m_ChbChirp9Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp9Tx1Enable.TabIndex = 469;
			this.m_ChbChirp9Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp9FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp9FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp9FreqSlopeVar.Location = new Point(178, 253);
			this.m_nudChirp9FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp9FreqSlopeVar = this.m_nudChirp9FreqSlopeVar;
			int[] array243 = new int[4];
			array243[0] = 4;
			nudChirp9FreqSlopeVar.Maximum = new decimal(array243);
			this.m_nudChirp9FreqSlopeVar.Name = "m_nudChirp9FreqSlopeVar";
			this.m_nudChirp9FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp9FreqSlopeVar.TabIndex = 468;
			this.m_nudChirp9ProfileIndex.Location = new Point(82, 253);
			this.m_nudChirp9ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp9ProfileIndex = this.m_nudChirp9ProfileIndex;
			int[] array244 = new int[4];
			array244[0] = 3;
			nudChirp9ProfileIndex.Maximum = new decimal(array244);
			this.m_nudChirp9ProfileIndex.Name = "m_nudChirp9ProfileIndex";
			this.m_nudChirp9ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp9ProfileIndex.TabIndex = 467;
			this.m_nudChirp9FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp9FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp9FreqStartVar.Location = new Point(513, 254);
			this.m_nudChirp9FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp9FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp9FreqStartVar.Name = "m_nudChirp9FreqStartVar";
			this.m_nudChirp9FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp9FreqStartVar.TabIndex = 466;
			this.m_nudChirp9ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp9ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp9ADCStartTimeVar.Location = new Point(755, 254);
			this.m_nudChirp9ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp9ADCStartTimeVar = this.m_nudChirp9ADCStartTimeVar;
			int[] array245 = new int[4];
			array245[0] = 4095;
			nudChirp9ADCStartTimeVar.Maximum = new decimal(array245);
			this.m_nudChirp9ADCStartTimeVar.Name = "m_nudChirp9ADCStartTimeVar";
			this.m_nudChirp9ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp9ADCStartTimeVar.TabIndex = 465;
			this.m_nudChirp9IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp9IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp9IdleTimeVar.Location = new Point(647, 254);
			this.m_nudChirp9IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp9IdleTimeVar = this.m_nudChirp9IdleTimeVar;
			int[] array246 = new int[4];
			array246[0] = 4095;
			nudChirp9IdleTimeVar.Maximum = new decimal(array246);
			this.m_nudChirp9IdleTimeVar.Name = "m_nudChirp9IdleTimeVar";
			this.m_nudChirp9IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp9IdleTimeVar.TabIndex = 464;
			this.m_nudChirp10BPMConstVal.Location = new Point(399, 280);
			this.m_nudChirp10BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp10BPMConstVal = this.m_nudChirp10BPMConstVal;
			int[] array247 = new int[4];
			array247[0] = 63;
			nudChirp10BPMConstVal.Maximum = new decimal(array247);
			this.m_nudChirp10BPMConstVal.Name = "m_nudChirp10BPMConstVal";
			this.m_nudChirp10BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp10BPMConstVal.TabIndex = 454;
			this.m_ChbChirp10Tx3Enable.AutoSize = true;
			this.m_ChbChirp10Tx3Enable.Location = new Point(359, 284);
			this.m_ChbChirp10Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp10Tx3Enable.Name = "m_ChbChirp10Tx3Enable";
			this.m_ChbChirp10Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp10Tx3Enable.TabIndex = 462;
			this.m_ChbChirp10Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp10Tx2Enable.AutoSize = true;
			this.m_ChbChirp10Tx2Enable.Location = new Point(319, 285);
			this.m_ChbChirp10Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp10Tx2Enable.Name = "m_ChbChirp10Tx2Enable";
			this.m_ChbChirp10Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp10Tx2Enable.TabIndex = 461;
			this.m_ChbChirp10Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp10Tx1Enable.AutoSize = true;
			this.m_ChbChirp10Tx1Enable.Location = new Point(285, 285);
			this.m_ChbChirp10Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp10Tx1Enable.Name = "m_ChbChirp10Tx1Enable";
			this.m_ChbChirp10Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp10Tx1Enable.TabIndex = 460;
			this.m_ChbChirp10Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp10FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp10FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp10FreqSlopeVar.Location = new Point(178, 282);
			this.m_nudChirp10FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp10FreqSlopeVar = this.m_nudChirp10FreqSlopeVar;
			int[] array248 = new int[4];
			array248[0] = 4;
			nudChirp10FreqSlopeVar.Maximum = new decimal(array248);
			this.m_nudChirp10FreqSlopeVar.Name = "m_nudChirp10FreqSlopeVar";
			this.m_nudChirp10FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp10FreqSlopeVar.TabIndex = 459;
			this.m_nudChirp10ProfileIndex.Location = new Point(82, 282);
			this.m_nudChirp10ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp10ProfileIndex = this.m_nudChirp10ProfileIndex;
			int[] array249 = new int[4];
			array249[0] = 3;
			nudChirp10ProfileIndex.Maximum = new decimal(array249);
			this.m_nudChirp10ProfileIndex.Name = "m_nudChirp10ProfileIndex";
			this.m_nudChirp10ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp10ProfileIndex.TabIndex = 458;
			this.m_nudChirp10FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp10FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp10FreqStartVar.Location = new Point(513, 284);
			this.m_nudChirp10FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp10FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp10FreqStartVar.Name = "m_nudChirp10FreqStartVar";
			this.m_nudChirp10FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp10FreqStartVar.TabIndex = 457;
			this.m_nudChirp10ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp10ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp10ADCStartTimeVar.Location = new Point(755, 284);
			this.m_nudChirp10ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp10ADCStartTimeVar = this.m_nudChirp10ADCStartTimeVar;
			int[] array250 = new int[4];
			array250[0] = 4095;
			nudChirp10ADCStartTimeVar.Maximum = new decimal(array250);
			this.m_nudChirp10ADCStartTimeVar.Name = "m_nudChirp10ADCStartTimeVar";
			this.m_nudChirp10ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp10ADCStartTimeVar.TabIndex = 456;
			this.m_nudChirp10IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp10IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp10IdleTimeVar.Location = new Point(647, 284);
			this.m_nudChirp10IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp10IdleTimeVar = this.m_nudChirp10IdleTimeVar;
			int[] array251 = new int[4];
			array251[0] = 4095;
			nudChirp10IdleTimeVar.Maximum = new decimal(array251);
			this.m_nudChirp10IdleTimeVar.Name = "m_nudChirp10IdleTimeVar";
			this.m_nudChirp10IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp10IdleTimeVar.TabIndex = 455;
			this.m_nudChirp8BPMConstVal.Location = new Point(399, 218);
			this.m_nudChirp8BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp8BPMConstVal = this.m_nudChirp8BPMConstVal;
			int[] array252 = new int[4];
			array252[0] = 63;
			nudChirp8BPMConstVal.Maximum = new decimal(array252);
			this.m_nudChirp8BPMConstVal.Name = "m_nudChirp8BPMConstVal";
			this.m_nudChirp8BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp8BPMConstVal.TabIndex = 445;
			this.m_ChbChirp8Tx3Enable.AutoSize = true;
			this.m_ChbChirp8Tx3Enable.Location = new Point(359, 222);
			this.m_ChbChirp8Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp8Tx3Enable.Name = "m_ChbChirp8Tx3Enable";
			this.m_ChbChirp8Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp8Tx3Enable.TabIndex = 453;
			this.m_ChbChirp8Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp8Tx2Enable.AutoSize = true;
			this.m_ChbChirp8Tx2Enable.Location = new Point(319, 223);
			this.m_ChbChirp8Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp8Tx2Enable.Name = "m_ChbChirp8Tx2Enable";
			this.m_ChbChirp8Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp8Tx2Enable.TabIndex = 452;
			this.m_ChbChirp8Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp8Tx1Enable.AutoSize = true;
			this.m_ChbChirp8Tx1Enable.Location = new Point(285, 223);
			this.m_ChbChirp8Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp8Tx1Enable.Name = "m_ChbChirp8Tx1Enable";
			this.m_ChbChirp8Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp8Tx1Enable.TabIndex = 451;
			this.m_ChbChirp8Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp8FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp8FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp8FreqSlopeVar.Location = new Point(178, 221);
			this.m_nudChirp8FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp8FreqSlopeVar = this.m_nudChirp8FreqSlopeVar;
			int[] array253 = new int[4];
			array253[0] = 4;
			nudChirp8FreqSlopeVar.Maximum = new decimal(array253);
			this.m_nudChirp8FreqSlopeVar.Name = "m_nudChirp8FreqSlopeVar";
			this.m_nudChirp8FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp8FreqSlopeVar.TabIndex = 450;
			this.m_nudChirp8ProfileIndex.Location = new Point(82, 221);
			this.m_nudChirp8ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp8ProfileIndex = this.m_nudChirp8ProfileIndex;
			int[] array254 = new int[4];
			array254[0] = 3;
			nudChirp8ProfileIndex.Maximum = new decimal(array254);
			this.m_nudChirp8ProfileIndex.Name = "m_nudChirp8ProfileIndex";
			this.m_nudChirp8ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp8ProfileIndex.TabIndex = 449;
			this.m_nudChirp8FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp8FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp8FreqStartVar.Location = new Point(513, 222);
			this.m_nudChirp8FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp8FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp8FreqStartVar.Name = "m_nudChirp8FreqStartVar";
			this.m_nudChirp8FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp8FreqStartVar.TabIndex = 448;
			this.m_nudChirp8ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp8ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp8ADCStartTimeVar.Location = new Point(755, 222);
			this.m_nudChirp8ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp8ADCStartTimeVar = this.m_nudChirp8ADCStartTimeVar;
			int[] array255 = new int[4];
			array255[0] = 4095;
			nudChirp8ADCStartTimeVar.Maximum = new decimal(array255);
			this.m_nudChirp8ADCStartTimeVar.Name = "m_nudChirp8ADCStartTimeVar";
			this.m_nudChirp8ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp8ADCStartTimeVar.TabIndex = 447;
			this.m_nudChirp8IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp8IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp8IdleTimeVar.Location = new Point(647, 222);
			this.m_nudChirp8IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp8IdleTimeVar = this.m_nudChirp8IdleTimeVar;
			int[] array256 = new int[4];
			array256[0] = 4095;
			nudChirp8IdleTimeVar.Maximum = new decimal(array256);
			this.m_nudChirp8IdleTimeVar.Name = "m_nudChirp8IdleTimeVar";
			this.m_nudChirp8IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp8IdleTimeVar.TabIndex = 446;
			this.m_nudChirp7BPMConstVal.Location = new Point(399, 186);
			this.m_nudChirp7BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp7BPMConstVal = this.m_nudChirp7BPMConstVal;
			int[] array257 = new int[4];
			array257[0] = 63;
			nudChirp7BPMConstVal.Maximum = new decimal(array257);
			this.m_nudChirp7BPMConstVal.Name = "m_nudChirp7BPMConstVal";
			this.m_nudChirp7BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp7BPMConstVal.TabIndex = 436;
			this.m_ChbChirp7Tx3Enable.AutoSize = true;
			this.m_ChbChirp7Tx3Enable.Location = new Point(359, 190);
			this.m_ChbChirp7Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp7Tx3Enable.Name = "m_ChbChirp7Tx3Enable";
			this.m_ChbChirp7Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp7Tx3Enable.TabIndex = 444;
			this.m_ChbChirp7Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp7Tx2Enable.AutoSize = true;
			this.m_ChbChirp7Tx2Enable.Location = new Point(319, 191);
			this.m_ChbChirp7Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp7Tx2Enable.Name = "m_ChbChirp7Tx2Enable";
			this.m_ChbChirp7Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp7Tx2Enable.TabIndex = 443;
			this.m_ChbChirp7Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp7Tx1Enable.AutoSize = true;
			this.m_ChbChirp7Tx1Enable.Location = new Point(285, 191);
			this.m_ChbChirp7Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp7Tx1Enable.Name = "m_ChbChirp7Tx1Enable";
			this.m_ChbChirp7Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp7Tx1Enable.TabIndex = 442;
			this.m_ChbChirp7Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp7FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp7FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp7FreqSlopeVar.Location = new Point(178, 189);
			this.m_nudChirp7FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp7FreqSlopeVar = this.m_nudChirp7FreqSlopeVar;
			int[] array258 = new int[4];
			array258[0] = 4;
			nudChirp7FreqSlopeVar.Maximum = new decimal(array258);
			this.m_nudChirp7FreqSlopeVar.Name = "m_nudChirp7FreqSlopeVar";
			this.m_nudChirp7FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp7FreqSlopeVar.TabIndex = 441;
			this.m_nudChirp7ProfileIndex.Location = new Point(82, 189);
			this.m_nudChirp7ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp7ProfileIndex = this.m_nudChirp7ProfileIndex;
			int[] array259 = new int[4];
			array259[0] = 3;
			nudChirp7ProfileIndex.Maximum = new decimal(array259);
			this.m_nudChirp7ProfileIndex.Name = "m_nudChirp7ProfileIndex";
			this.m_nudChirp7ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp7ProfileIndex.TabIndex = 440;
			this.m_nudChirp7FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp7FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp7FreqStartVar.Location = new Point(513, 190);
			this.m_nudChirp7FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp7FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp7FreqStartVar.Name = "m_nudChirp7FreqStartVar";
			this.m_nudChirp7FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp7FreqStartVar.TabIndex = 439;
			this.m_nudChirp7ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp7ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp7ADCStartTimeVar.Location = new Point(755, 190);
			this.m_nudChirp7ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp7ADCStartTimeVar = this.m_nudChirp7ADCStartTimeVar;
			int[] array260 = new int[4];
			array260[0] = 4095;
			nudChirp7ADCStartTimeVar.Maximum = new decimal(array260);
			this.m_nudChirp7ADCStartTimeVar.Name = "m_nudChirp7ADCStartTimeVar";
			this.m_nudChirp7ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp7ADCStartTimeVar.TabIndex = 438;
			this.m_nudChirp7IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp7IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp7IdleTimeVar.Location = new Point(647, 190);
			this.m_nudChirp7IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp7IdleTimeVar = this.m_nudChirp7IdleTimeVar;
			int[] array261 = new int[4];
			array261[0] = 4095;
			nudChirp7IdleTimeVar.Maximum = new decimal(array261);
			this.m_nudChirp7IdleTimeVar.Name = "m_nudChirp7IdleTimeVar";
			this.m_nudChirp7IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp7IdleTimeVar.TabIndex = 437;
			this.m_nudChirp6BPMConstVal.Location = new Point(399, 156);
			this.m_nudChirp6BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp6BPMConstVal = this.m_nudChirp6BPMConstVal;
			int[] array262 = new int[4];
			array262[0] = 63;
			nudChirp6BPMConstVal.Maximum = new decimal(array262);
			this.m_nudChirp6BPMConstVal.Name = "m_nudChirp6BPMConstVal";
			this.m_nudChirp6BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp6BPMConstVal.TabIndex = 427;
			this.m_ChbChirp6Tx3Enable.AutoSize = true;
			this.m_ChbChirp6Tx3Enable.Location = new Point(359, 159);
			this.m_ChbChirp6Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp6Tx3Enable.Name = "m_ChbChirp6Tx3Enable";
			this.m_ChbChirp6Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp6Tx3Enable.TabIndex = 435;
			this.m_ChbChirp6Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp6Tx2Enable.AutoSize = true;
			this.m_ChbChirp6Tx2Enable.Location = new Point(319, 160);
			this.m_ChbChirp6Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp6Tx2Enable.Name = "m_ChbChirp6Tx2Enable";
			this.m_ChbChirp6Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp6Tx2Enable.TabIndex = 434;
			this.m_ChbChirp6Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp6Tx1Enable.AutoSize = true;
			this.m_ChbChirp6Tx1Enable.Location = new Point(285, 160);
			this.m_ChbChirp6Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp6Tx1Enable.Name = "m_ChbChirp6Tx1Enable";
			this.m_ChbChirp6Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp6Tx1Enable.TabIndex = 433;
			this.m_ChbChirp6Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp6FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp6FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp6FreqSlopeVar.Location = new Point(178, 158);
			this.m_nudChirp6FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp6FreqSlopeVar = this.m_nudChirp6FreqSlopeVar;
			int[] array263 = new int[4];
			array263[0] = 4;
			nudChirp6FreqSlopeVar.Maximum = new decimal(array263);
			this.m_nudChirp6FreqSlopeVar.Name = "m_nudChirp6FreqSlopeVar";
			this.m_nudChirp6FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp6FreqSlopeVar.TabIndex = 432;
			this.m_nudChirp6ProfileIndex.Location = new Point(82, 158);
			this.m_nudChirp6ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp6ProfileIndex = this.m_nudChirp6ProfileIndex;
			int[] array264 = new int[4];
			array264[0] = 3;
			nudChirp6ProfileIndex.Maximum = new decimal(array264);
			this.m_nudChirp6ProfileIndex.Name = "m_nudChirp6ProfileIndex";
			this.m_nudChirp6ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp6ProfileIndex.TabIndex = 431;
			this.m_nudChirp6FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp6FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp6FreqStartVar.Location = new Point(513, 159);
			this.m_nudChirp6FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp6FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp6FreqStartVar.Name = "m_nudChirp6FreqStartVar";
			this.m_nudChirp6FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp6FreqStartVar.TabIndex = 430;
			this.m_nudChirp6ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp6ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp6ADCStartTimeVar.Location = new Point(755, 159);
			this.m_nudChirp6ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp6ADCStartTimeVar = this.m_nudChirp6ADCStartTimeVar;
			int[] array265 = new int[4];
			array265[0] = 4095;
			nudChirp6ADCStartTimeVar.Maximum = new decimal(array265);
			this.m_nudChirp6ADCStartTimeVar.Name = "m_nudChirp6ADCStartTimeVar";
			this.m_nudChirp6ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp6ADCStartTimeVar.TabIndex = 429;
			this.m_nudChirp6IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp6IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp6IdleTimeVar.Location = new Point(647, 159);
			this.m_nudChirp6IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp6IdleTimeVar = this.m_nudChirp6IdleTimeVar;
			int[] array266 = new int[4];
			array266[0] = 4095;
			nudChirp6IdleTimeVar.Maximum = new decimal(array266);
			this.m_nudChirp6IdleTimeVar.Name = "m_nudChirp6IdleTimeVar";
			this.m_nudChirp6IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp6IdleTimeVar.TabIndex = 428;
			this.m_nudChirp4BPMConstVal.Location = new Point(399, 98);
			this.m_nudChirp4BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp4BPMConstVal = this.m_nudChirp4BPMConstVal;
			int[] array267 = new int[4];
			array267[0] = 63;
			nudChirp4BPMConstVal.Maximum = new decimal(array267);
			this.m_nudChirp4BPMConstVal.Name = "m_nudChirp4BPMConstVal";
			this.m_nudChirp4BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp4BPMConstVal.TabIndex = 418;
			this.m_ChbChirp4Tx3Enable.AutoSize = true;
			this.m_ChbChirp4Tx3Enable.Location = new Point(359, 101);
			this.m_ChbChirp4Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp4Tx3Enable.Name = "m_ChbChirp4Tx3Enable";
			this.m_ChbChirp4Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp4Tx3Enable.TabIndex = 426;
			this.m_ChbChirp4Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp4Tx2Enable.AutoSize = true;
			this.m_ChbChirp4Tx2Enable.Location = new Point(319, 103);
			this.m_ChbChirp4Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp4Tx2Enable.Name = "m_ChbChirp4Tx2Enable";
			this.m_ChbChirp4Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp4Tx2Enable.TabIndex = 425;
			this.m_ChbChirp4Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp4Tx1Enable.AutoSize = true;
			this.m_ChbChirp4Tx1Enable.Location = new Point(285, 103);
			this.m_ChbChirp4Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp4Tx1Enable.Name = "m_ChbChirp4Tx1Enable";
			this.m_ChbChirp4Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp4Tx1Enable.TabIndex = 424;
			this.m_ChbChirp4Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp4FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp4FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp4FreqSlopeVar.Location = new Point(178, 100);
			this.m_nudChirp4FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp4FreqSlopeVar = this.m_nudChirp4FreqSlopeVar;
			int[] array268 = new int[4];
			array268[0] = 4;
			nudChirp4FreqSlopeVar.Maximum = new decimal(array268);
			this.m_nudChirp4FreqSlopeVar.Name = "m_nudChirp4FreqSlopeVar";
			this.m_nudChirp4FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp4FreqSlopeVar.TabIndex = 423;
			this.m_nudChirp4ProfileIndex.Location = new Point(82, 100);
			this.m_nudChirp4ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp4ProfileIndex = this.m_nudChirp4ProfileIndex;
			int[] array269 = new int[4];
			array269[0] = 3;
			nudChirp4ProfileIndex.Maximum = new decimal(array269);
			this.m_nudChirp4ProfileIndex.Name = "m_nudChirp4ProfileIndex";
			this.m_nudChirp4ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp4ProfileIndex.TabIndex = 422;
			this.m_nudChirp4FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp4FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp4FreqStartVar.Location = new Point(513, 101);
			this.m_nudChirp4FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp4FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp4FreqStartVar.Name = "m_nudChirp4FreqStartVar";
			this.m_nudChirp4FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp4FreqStartVar.TabIndex = 421;
			this.m_nudChirp4ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp4ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp4ADCStartTimeVar.Location = new Point(755, 101);
			this.m_nudChirp4ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp4ADCStartTimeVar = this.m_nudChirp4ADCStartTimeVar;
			int[] array270 = new int[4];
			array270[0] = 4095;
			nudChirp4ADCStartTimeVar.Maximum = new decimal(array270);
			this.m_nudChirp4ADCStartTimeVar.Name = "m_nudChirp4ADCStartTimeVar";
			this.m_nudChirp4ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp4ADCStartTimeVar.TabIndex = 420;
			this.m_nudChirp4IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp4IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp4IdleTimeVar.Location = new Point(647, 101);
			this.m_nudChirp4IdleTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp4IdleTimeVar = this.m_nudChirp4IdleTimeVar;
			int[] array271 = new int[4];
			array271[0] = 4095;
			nudChirp4IdleTimeVar.Maximum = new decimal(array271);
			this.m_nudChirp4IdleTimeVar.Name = "m_nudChirp4IdleTimeVar";
			this.m_nudChirp4IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp4IdleTimeVar.TabIndex = 419;
			this.m_nudChirp5BPMConstVal.Location = new Point(399, 127);
			this.m_nudChirp5BPMConstVal.Margin = new Padding(4);
			NumericUpDown nudChirp5BPMConstVal = this.m_nudChirp5BPMConstVal;
			int[] array272 = new int[4];
			array272[0] = 63;
			nudChirp5BPMConstVal.Maximum = new decimal(array272);
			this.m_nudChirp5BPMConstVal.Name = "m_nudChirp5BPMConstVal";
			this.m_nudChirp5BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp5BPMConstVal.TabIndex = 409;
			this.m_ChbChirp5Tx3Enable.AutoSize = true;
			this.m_ChbChirp5Tx3Enable.Location = new Point(359, 131);
			this.m_ChbChirp5Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp5Tx3Enable.Name = "m_ChbChirp5Tx3Enable";
			this.m_ChbChirp5Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp5Tx3Enable.TabIndex = 417;
			this.m_ChbChirp5Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp5Tx2Enable.AutoSize = true;
			this.m_ChbChirp5Tx2Enable.Location = new Point(319, 132);
			this.m_ChbChirp5Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp5Tx2Enable.Name = "m_ChbChirp5Tx2Enable";
			this.m_ChbChirp5Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp5Tx2Enable.TabIndex = 416;
			this.m_ChbChirp5Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp5Tx1Enable.AutoSize = true;
			this.m_ChbChirp5Tx1Enable.Location = new Point(285, 132);
			this.m_ChbChirp5Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp5Tx1Enable.Name = "m_ChbChirp5Tx1Enable";
			this.m_ChbChirp5Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp5Tx1Enable.TabIndex = 415;
			this.m_ChbChirp5Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp5FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp5FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp5FreqSlopeVar.Location = new Point(178, 130);
			this.m_nudChirp5FreqSlopeVar.Margin = new Padding(4);
			NumericUpDown nudChirp5FreqSlopeVar = this.m_nudChirp5FreqSlopeVar;
			int[] array273 = new int[4];
			array273[0] = 4;
			nudChirp5FreqSlopeVar.Maximum = new decimal(array273);
			this.m_nudChirp5FreqSlopeVar.Name = "m_nudChirp5FreqSlopeVar";
			this.m_nudChirp5FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp5FreqSlopeVar.TabIndex = 414;
			this.m_nudChirp5ProfileIndex.Location = new Point(82, 130);
			this.m_nudChirp5ProfileIndex.Margin = new Padding(4);
			NumericUpDown nudChirp5ProfileIndex = this.m_nudChirp5ProfileIndex;
			int[] array274 = new int[4];
			array274[0] = 3;
			nudChirp5ProfileIndex.Maximum = new decimal(array274);
			this.m_nudChirp5ProfileIndex.Name = "m_nudChirp5ProfileIndex";
			this.m_nudChirp5ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp5ProfileIndex.TabIndex = 413;
			this.m_nudChirp5FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp5FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp5FreqStartVar.Location = new Point(513, 131);
			this.m_nudChirp5FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp5FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp5FreqStartVar.Name = "m_nudChirp5FreqStartVar";
			this.m_nudChirp5FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp5FreqStartVar.TabIndex = 412;
			this.m_nudChirp5ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp5ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp5ADCStartTimeVar.Location = new Point(755, 131);
			this.m_nudChirp5ADCStartTimeVar.Margin = new Padding(4);
			NumericUpDown nudChirp5ADCStartTimeVar = this.m_nudChirp5ADCStartTimeVar;
			int[] array275 = new int[4];
			array275[0] = 4095;
			nudChirp5ADCStartTimeVar.Maximum = new decimal(array275);
			this.m_nudChirp5ADCStartTimeVar.Name = "m_nudChirp5ADCStartTimeVar";
			this.m_nudChirp5ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp5ADCStartTimeVar.TabIndex = 411;
			this.m_nudChirp5IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp5IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp5IdleTimeVar.Location = new Point(647, 131);
			this.m_nudChirp5IdleTimeVar.Margin = new Padding(4);
			int[] array276 = new int[4];
			array276[0] = 4095;
            this.m_nudChirp5IdleTimeVar.Maximum = new decimal(array276);
			this.m_nudChirp5IdleTimeVar.Name = "m_nudChirp5IdleTimeVar";
			this.m_nudChirp5IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp5IdleTimeVar.TabIndex = 410;
			this.m_nudChirp3BPMConstVal.Location = new Point(399, 66);
			this.m_nudChirp3BPMConstVal.Margin = new Padding(4);
			int[] array277 = new int[4];
			array277[0] = 63;
            this.m_nudChirp3BPMConstVal.Maximum = new decimal(array277);
			this.m_nudChirp3BPMConstVal.Name = "m_nudChirp3BPMConstVal";
			this.m_nudChirp3BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp3BPMConstVal.TabIndex = 400;
			this.m_ChbChirp3Tx3Enable.AutoSize = true;
			this.m_ChbChirp3Tx3Enable.Location = new Point(359, 69);
			this.m_ChbChirp3Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp3Tx3Enable.Name = "m_ChbChirp3Tx3Enable";
			this.m_ChbChirp3Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp3Tx3Enable.TabIndex = 408;
			this.m_ChbChirp3Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp3Tx2Enable.AutoSize = true;
			this.m_ChbChirp3Tx2Enable.Location = new Point(319, 71);
			this.m_ChbChirp3Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp3Tx2Enable.Name = "m_ChbChirp3Tx2Enable";
			this.m_ChbChirp3Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp3Tx2Enable.TabIndex = 407;
			this.m_ChbChirp3Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp3Tx1Enable.AutoSize = true;
			this.m_ChbChirp3Tx1Enable.Location = new Point(285, 71);
			this.m_ChbChirp3Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp3Tx1Enable.Name = "m_ChbChirp3Tx1Enable";
			this.m_ChbChirp3Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp3Tx1Enable.TabIndex = 406;
			this.m_ChbChirp3Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp3FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp3FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp3FreqSlopeVar.Location = new Point(178, 68);
			this.m_nudChirp3FreqSlopeVar.Margin = new Padding(4);
			int[] array278 = new int[4];
			array278[0] = 4;
            this.m_nudChirp3FreqSlopeVar.Maximum = new decimal(array278);
			this.m_nudChirp3FreqSlopeVar.Name = "m_nudChirp3FreqSlopeVar";
			this.m_nudChirp3FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp3FreqSlopeVar.TabIndex = 405;
			this.m_nudChirp3ProfileIndex.Location = new Point(82, 68);
			this.m_nudChirp3ProfileIndex.Margin = new Padding(4);
			int[] array279 = new int[4];
			array279[0] = 3;
            this.m_nudChirp3ProfileIndex.Maximum = new decimal(array279);
			this.m_nudChirp3ProfileIndex.Name = "m_nudChirp3ProfileIndex";
			this.m_nudChirp3ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp3ProfileIndex.TabIndex = 404;
			this.m_nudChirp3FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp3FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp3FreqStartVar.Location = new Point(513, 69);
			this.m_nudChirp3FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp3FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp3FreqStartVar.Name = "m_nudChirp3FreqStartVar";
			this.m_nudChirp3FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp3FreqStartVar.TabIndex = 403;
			this.m_nudChirp3ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp3ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp3ADCStartTimeVar.Location = new Point(755, 69);
			this.m_nudChirp3ADCStartTimeVar.Margin = new Padding(4);
			int[] array280 = new int[4];
			array280[0] = 4095;
            this.m_nudChirp3ADCStartTimeVar.Maximum = new decimal(array280);
			this.m_nudChirp3ADCStartTimeVar.Name = "m_nudChirp3ADCStartTimeVar";
			this.m_nudChirp3ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp3ADCStartTimeVar.TabIndex = 402;
			this.m_nudChirp3IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp3IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp3IdleTimeVar.Location = new Point(647, 69);
			this.m_nudChirp3IdleTimeVar.Margin = new Padding(4);
			int[] array281 = new int[4];
			array281[0] = 4095;
            this.m_nudChirp3IdleTimeVar.Maximum = new decimal(array281);
			this.m_nudChirp3IdleTimeVar.Name = "m_nudChirp3IdleTimeVar";
			this.m_nudChirp3IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp3IdleTimeVar.TabIndex = 401;
			this.m_nudChirp2BPMConstVal.Location = new Point(399, 34);
			this.m_nudChirp2BPMConstVal.Margin = new Padding(4);
			int[] array282 = new int[4];
			array282[0] = 63;
            this.m_nudChirp2BPMConstVal.Maximum = new decimal(array282);
			this.m_nudChirp2BPMConstVal.Name = "m_nudChirp2BPMConstVal";
			this.m_nudChirp2BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp2BPMConstVal.TabIndex = 391;
			this.m_ChbChirp2Tx3Enable.AutoSize = true;
			this.m_ChbChirp2Tx3Enable.Location = new Point(359, 37);
			this.m_ChbChirp2Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp2Tx3Enable.Name = "m_ChbChirp2Tx3Enable";
			this.m_ChbChirp2Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp2Tx3Enable.TabIndex = 399;
			this.m_ChbChirp2Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp2Tx2Enable.AutoSize = true;
			this.m_ChbChirp2Tx2Enable.Location = new Point(319, 39);
			this.m_ChbChirp2Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp2Tx2Enable.Name = "m_ChbChirp2Tx2Enable";
			this.m_ChbChirp2Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp2Tx2Enable.TabIndex = 398;
			this.m_ChbChirp2Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp2Tx1Enable.AutoSize = true;
			this.m_ChbChirp2Tx1Enable.Location = new Point(285, 39);
			this.m_ChbChirp2Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp2Tx1Enable.Name = "m_ChbChirp2Tx1Enable";
			this.m_ChbChirp2Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp2Tx1Enable.TabIndex = 397;
			this.m_ChbChirp2Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp2FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp2FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp2FreqSlopeVar.Location = new Point(178, 36);
			this.m_nudChirp2FreqSlopeVar.Margin = new Padding(4);
			int[] array283 = new int[4];
			array283[0] = 4;
            this.m_nudChirp2FreqSlopeVar.Maximum = new decimal(array283);
			this.m_nudChirp2FreqSlopeVar.Name = "m_nudChirp2FreqSlopeVar";
			this.m_nudChirp2FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp2FreqSlopeVar.TabIndex = 396;
			this.m_nudChirp2ProfileIndex.Location = new Point(82, 36);
			this.m_nudChirp2ProfileIndex.Margin = new Padding(4);
			int[] array284 = new int[4];
			array284[0] = 3;
            this.m_nudChirp2ProfileIndex.Maximum = new decimal(array284);
			this.m_nudChirp2ProfileIndex.Name = "m_nudChirp2ProfileIndex";
			this.m_nudChirp2ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp2ProfileIndex.TabIndex = 395;
			this.m_nudChirp2FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp2FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp2FreqStartVar.Location = new Point(513, 37);
			this.m_nudChirp2FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp2FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp2FreqStartVar.Name = "m_nudChirp2FreqStartVar";
			this.m_nudChirp2FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp2FreqStartVar.TabIndex = 394;
			this.m_nudChirp2ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp2ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp2ADCStartTimeVar.Location = new Point(755, 37);
			this.m_nudChirp2ADCStartTimeVar.Margin = new Padding(4);
			int[] array285 = new int[4];
			array285[0] = 4095;
            this.m_nudChirp2ADCStartTimeVar.Maximum = new decimal(array285);
			this.m_nudChirp2ADCStartTimeVar.Name = "m_nudChirp2ADCStartTimeVar";
			this.m_nudChirp2ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp2ADCStartTimeVar.TabIndex = 393;
			this.m_nudChirp2IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp2IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp2IdleTimeVar.Location = new Point(647, 37);
			this.m_nudChirp2IdleTimeVar.Margin = new Padding(4);
			int[] array286 = new int[4];
			array286[0] = 4095;
            this.m_nudChirp2IdleTimeVar.Maximum = new decimal(array286);
			this.m_nudChirp2IdleTimeVar.Name = "m_nudChirp2IdleTimeVar";
			this.m_nudChirp2IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp2IdleTimeVar.TabIndex = 392;
			this.label35.AutoSize = true;
			this.label35.Location = new Point(3, 436);
			this.label35.Margin = new Padding(4, 0, 4, 0);
			this.label35.Name = "label35";
			this.label35.Size = new Size(61, 17);
			this.label35.TabIndex = 390;
			this.label35.Text = "Chirp 15";
			this.label36.AutoSize = true;
			this.label36.Location = new Point(3, 469);
			this.label36.Margin = new Padding(4, 0, 4, 0);
			this.label36.Name = "label36";
			this.label36.Size = new Size(61, 17);
			this.label36.TabIndex = 389;
			this.label36.Text = "Chirp 16";
			this.label33.AutoSize = true;
			this.label33.Location = new Point(3, 375);
			this.label33.Margin = new Padding(4, 0, 4, 0);
			this.label33.Name = "label33";
			this.label33.Size = new Size(61, 17);
			this.label33.TabIndex = 388;
			this.label33.Text = "Chirp 13";
			this.label34.AutoSize = true;
			this.label34.Location = new Point(3, 407);
			this.label34.Margin = new Padding(4, 0, 4, 0);
			this.label34.Name = "label34";
			this.label34.Size = new Size(61, 17);
			this.label34.TabIndex = 387;
			this.label34.Text = "Chirp 14";
			this.label31.AutoSize = true;
			this.label31.Location = new Point(3, 312);
			this.label31.Margin = new Padding(4, 0, 4, 0);
			this.label31.Name = "label31";
			this.label31.Size = new Size(61, 17);
			this.label31.TabIndex = 386;
			this.label31.Text = "Chirp 11";
			this.label32.AutoSize = true;
			this.label32.Location = new Point(3, 343);
			this.label32.Margin = new Padding(4, 0, 4, 0);
			this.label32.Name = "label32";
			this.label32.Size = new Size(61, 17);
			this.label32.TabIndex = 385;
			this.label32.Text = "Chirp 12";
			this.m_nudChirp1BPMConstVal.Location = new Point(399, 3);
			this.m_nudChirp1BPMConstVal.Margin = new Padding(4);
			int[] array287 = new int[4];
			array287[0] = 63;
            this.m_nudChirp1BPMConstVal.Maximum = new decimal(array287);
			this.m_nudChirp1BPMConstVal.Name = "m_nudChirp1BPMConstVal";
			this.m_nudChirp1BPMConstVal.Size = new Size(75, 22);
			this.m_nudChirp1BPMConstVal.TabIndex = 366;
			this.label29.AutoSize = true;
			this.label29.Location = new Point(3, 102);
			this.label29.Margin = new Padding(4, 0, 4, 0);
			this.label29.Name = "label29";
			this.label29.Size = new Size(53, 17);
			this.label29.TabIndex = 384;
			this.label29.Text = "Chirp 4";
			this.label30.AutoSize = true;
			this.label30.Location = new Point(3, 133);
			this.label30.Margin = new Padding(4, 0, 4, 0);
			this.label30.Name = "label30";
			this.label30.Size = new Size(53, 17);
			this.label30.TabIndex = 383;
			this.label30.Text = "Chirp 5";
			this.label27.AutoSize = true;
			this.label27.Location = new Point(3, 256);
			this.label27.Margin = new Padding(4, 0, 4, 0);
			this.label27.Name = "label27";
			this.label27.Size = new Size(53, 17);
			this.label27.TabIndex = 382;
			this.label27.Text = "Chirp 9";
			this.label28.AutoSize = true;
			this.label28.Location = new Point(3, 285);
			this.label28.Margin = new Padding(4, 0, 4, 0);
			this.label28.Name = "label28";
			this.label28.Size = new Size(61, 17);
			this.label28.TabIndex = 381;
			this.label28.Text = "Chirp 10";
			this.label25.AutoSize = true;
			this.label25.Location = new Point(3, 162);
			this.label25.Margin = new Padding(4, 0, 4, 0);
			this.label25.Name = "label25";
			this.label25.Size = new Size(53, 17);
			this.label25.TabIndex = 380;
			this.label25.Text = "Chirp 6";
			this.label26.AutoSize = true;
			this.label26.Location = new Point(3, 192);
			this.label26.Margin = new Padding(4, 0, 4, 0);
			this.label26.Name = "label26";
			this.label26.Size = new Size(53, 17);
			this.label26.TabIndex = 379;
			this.label26.Text = "Chirp 7";
			this.label23.AutoSize = true;
			this.label23.Location = new Point(3, 224);
			this.label23.Margin = new Padding(4, 0, 4, 0);
			this.label23.Name = "label23";
			this.label23.Size = new Size(53, 17);
			this.label23.TabIndex = 378;
			this.label23.Text = "Chirp 8";
			this.m_ChbChirp1Tx3Enable.AutoSize = true;
			this.m_ChbChirp1Tx3Enable.Location = new Point(359, 7);
			this.m_ChbChirp1Tx3Enable.Margin = new Padding(4);
			this.m_ChbChirp1Tx3Enable.Name = "m_ChbChirp1Tx3Enable";
			this.m_ChbChirp1Tx3Enable.Size = new Size(18, 17);
			this.m_ChbChirp1Tx3Enable.TabIndex = 377;
			this.m_ChbChirp1Tx3Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp1Tx2Enable.AutoSize = true;
			this.m_ChbChirp1Tx2Enable.Location = new Point(319, 8);
			this.m_ChbChirp1Tx2Enable.Margin = new Padding(4);
			this.m_ChbChirp1Tx2Enable.Name = "m_ChbChirp1Tx2Enable";
			this.m_ChbChirp1Tx2Enable.Size = new Size(18, 17);
			this.m_ChbChirp1Tx2Enable.TabIndex = 376;
			this.m_ChbChirp1Tx2Enable.UseVisualStyleBackColor = true;
			this.m_ChbChirp1Tx1Enable.AutoSize = true;
			this.m_ChbChirp1Tx1Enable.Location = new Point(285, 8);
			this.m_ChbChirp1Tx1Enable.Margin = new Padding(4);
			this.m_ChbChirp1Tx1Enable.Name = "m_ChbChirp1Tx1Enable";
			this.m_ChbChirp1Tx1Enable.Size = new Size(18, 17);
			this.m_ChbChirp1Tx1Enable.TabIndex = 375;
			this.m_ChbChirp1Tx1Enable.UseVisualStyleBackColor = true;
			this.m_nudChirp1FreqSlopeVar.DecimalPlaces = 3;
			this.m_nudChirp1FreqSlopeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.m_nudChirp1FreqSlopeVar.Location = new Point(178, 5);
			this.m_nudChirp1FreqSlopeVar.Margin = new Padding(4);
			int[] array288 = new int[4];
			array288[0] = 4;
            this.m_nudChirp1FreqSlopeVar.Maximum = new decimal(array288);
			this.m_nudChirp1FreqSlopeVar.Name = "m_nudChirp1FreqSlopeVar";
			this.m_nudChirp1FreqSlopeVar.Size = new Size(75, 22);
			this.m_nudChirp1FreqSlopeVar.TabIndex = 374;
			this.m_nudChirp1ProfileIndex.Location = new Point(82, 5);
			this.m_nudChirp1ProfileIndex.Margin = new Padding(4);
			int[] array289 = new int[4];
			array289[0] = 3;
            this.m_nudChirp1ProfileIndex.Maximum = new decimal(array289);
			this.m_nudChirp1ProfileIndex.Name = "m_nudChirp1ProfileIndex";
			this.m_nudChirp1ProfileIndex.Size = new Size(75, 22);
			this.m_nudChirp1ProfileIndex.TabIndex = 373;
			this.m_nudChirp1FreqStartVar.DecimalPlaces = 6;
			this.m_nudChirp1FreqStartVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudChirp1FreqStartVar.Location = new Point(513, 7);
			this.m_nudChirp1FreqStartVar.Margin = new Padding(4);
			this.m_nudChirp1FreqStartVar.Maximum = new decimal(new int[]
			{
				45,
				0,
				0,
				131072
			});
			this.m_nudChirp1FreqStartVar.Name = "m_nudChirp1FreqStartVar";
			this.m_nudChirp1FreqStartVar.Size = new Size(99, 22);
			this.m_nudChirp1FreqStartVar.TabIndex = 372;
			this.m_nudChirp1ADCStartTimeVar.DecimalPlaces = 2;
			this.m_nudChirp1ADCStartTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp1ADCStartTimeVar.Location = new Point(755, 7);
			this.m_nudChirp1ADCStartTimeVar.Margin = new Padding(4);
			int[] array290 = new int[4];
			array290[0] = 4095;
            this.m_nudChirp1ADCStartTimeVar.Maximum = new decimal(array290);
			this.m_nudChirp1ADCStartTimeVar.Name = "m_nudChirp1ADCStartTimeVar";
			this.m_nudChirp1ADCStartTimeVar.Size = new Size(99, 22);
			this.m_nudChirp1ADCStartTimeVar.TabIndex = 371;
			this.m_nudChirp1IdleTimeVar.DecimalPlaces = 2;
			this.m_nudChirp1IdleTimeVar.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudChirp1IdleTimeVar.Location = new Point(647, 7);
			this.m_nudChirp1IdleTimeVar.Margin = new Padding(4);
			int[] array291 = new int[4];
			array291[0] = 4095;
            this.m_nudChirp1IdleTimeVar.Maximum = new decimal(array291);
			this.m_nudChirp1IdleTimeVar.Name = "m_nudChirp1IdleTimeVar";
			this.m_nudChirp1IdleTimeVar.Size = new Size(83, 22);
			this.m_nudChirp1IdleTimeVar.TabIndex = 370;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(3, 70);
			this.label7.Margin = new Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(53, 17);
			this.label7.TabIndex = 369;
			this.label7.Text = "Chirp 3";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(3, 38);
			this.label8.Margin = new Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(53, 17);
			this.label8.TabIndex = 368;
			this.label8.Text = "Chirp 2";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(3, 8);
			this.label3.Margin = new Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(53, 17);
			this.label3.TabIndex = 367;
			this.label3.Text = "Chirp 1";
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoScroll = true;
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Margin = new Padding(4);
			base.Name = "DynamicChirpConfig";
			base.Size = new Size(1631, 745);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((ISupportInitialize)this.m_nudChirp14Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp13Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp12Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp16Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp15Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp11Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp10Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp9Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp8Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp7Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp6Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp5Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp4Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp3Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp2Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp1Tx2PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp14Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp13Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp12Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp16Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp15Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp11Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp10Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp9Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp8Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp7Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp6Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp5Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp4Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp3Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp2Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp1Tx3PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp14Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp13Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp12Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp16Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp15Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp11Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp10Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp9Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp8Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp7Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp6Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp5Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp4Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp3Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp2Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudChirp1Tx1PhaseShiftter).EndInit();
			((ISupportInitialize)this.m_nudPerChirpSegmentSelect).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.m_nudChirpRowSelect).EndInit();
			((ISupportInitialize)this.m_nudChirpSegmentSelect).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((ISupportInitialize)this.m_nudChirp48BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp48FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp48ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp48FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp48ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp48IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp47BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp47FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp47ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp47FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp47ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp47IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp46BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp46FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp46ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp46FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp46ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp46IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp44BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp44FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp44ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp44FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp44ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp44IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp45BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp45FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp45ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp45FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp45ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp45IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp43BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp43FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp43ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp43FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp43ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp43IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp42BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp42FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp42ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp42FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp42ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp42IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp41BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp41FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp41ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp41FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp41ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp41IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp40BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp40FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp40ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp40FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp40ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp40IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp39BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp39FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp39ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp39FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp39ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp39IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp37BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp37FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp37ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp37FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp37ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp37IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp38BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp38FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp38ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp38FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp38ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp38IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp36BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp36FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp36ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp36FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp36ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp36IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp35BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp35FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp35ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp35FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp35ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp35IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp34BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp34FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp34ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp34FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp34ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp34IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp32BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp32FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp32ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp32FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp32ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp32IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp33BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp33FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp33ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp33FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp33ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp33IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp31BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp31FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp31ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp31FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp31ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp31IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp30BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp30FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp30ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp30FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp30ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp30IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp29BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp29FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp29ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp29FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp29ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp29IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp28BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp28FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp28ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp28FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp28ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp28IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp26BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp26FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp26ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp26FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp26ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp26IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp27BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp27FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp27ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp27FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp27ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp27IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp25BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp25FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp25ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp25FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp25ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp25IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp24BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp24FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp24ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp24FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp24ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp24IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp23BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp23FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp23ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp23FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp23ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp23IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp21BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp21FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp21ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp21FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp21ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp21IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp22BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp22FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp22ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp22FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp22ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp22IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp20BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp20FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp20ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp20FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp20ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp20IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp19BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp19FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp19ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp19FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp19ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp19IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp18BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp18FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp18ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp18FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp18ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp18IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp17BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp17FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp17ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp17FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp17ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp17IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp16BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp16FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp16ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp16FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp16ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp16IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp14BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp14FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp14ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp14FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp14ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp14IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp15BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp15FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp15ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp15FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp15ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp15IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp13BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp13FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp13ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp13FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp13ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp13IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp12BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp12FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp12ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp12FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp12ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp12IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp11BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp11FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp11ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp11FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp11ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp11IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp9BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp9FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp9ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp9FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp9ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp9IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp10BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp10FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp10ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp10FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp10ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp10IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp8BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp8FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp8ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp8FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp8ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp8IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp7BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp7FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp7ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp7FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp7ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp7IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp6BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp6FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp6ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp6FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp6ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp6IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp4BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp4FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp4ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp4FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp4ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp4IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp5BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp5FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp5ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp5FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp5ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp5IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp3BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp3FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp3ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp3FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp3ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp3IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp2BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp2FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp2ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp2FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp2ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp2IdleTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp1BPMConstVal).EndInit();
			((ISupportInitialize)this.m_nudChirp1FreqSlopeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp1ProfileIndex).EndInit();
			((ISupportInitialize)this.m_nudChirp1FreqStartVar).EndInit();
			((ISupportInitialize)this.m_nudChirp1ADCStartTimeVar).EndInit();
			((ISupportInitialize)this.m_nudChirp1IdleTimeVar).EndInit();
			base.ResumeLayout(false);
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		public DynamicChirpConfigParams m_DynamicChirpConfigParams;

		public DynamicChirpEnableConfigParams m_DynamicChirpEnableConfigParams;

		public DynamicPerChirpPhaseShiftConfigParams m_DynamicPerChirpPhaseShiftConfigParams;

		private int f00017c;

		private IContainer components;

		private GroupBox groupBox2;

		private NumericUpDown m_nudChirp15Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp16Tx1PhaseShiftter;

		private Label label24;

		private Button m_btnDynamicPerChirpPhaseShifterConfigSet;

		private NumericUpDown m_nudChirp14Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp13Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp12Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp16Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp15Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp11Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp10Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp9Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp8Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp7Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp6Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp5Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp4Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp3Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp2Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp1Tx2PhaseShiftter;

		private NumericUpDown m_nudChirp14Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp13Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp12Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp16Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp15Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp11Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp10Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp9Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp8Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp7Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp6Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp5Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp4Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp3Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp2Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp1Tx3PhaseShiftter;

		private NumericUpDown m_nudChirp14Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp13Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp12Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp11Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp10Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp9Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp8Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp7Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp6Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp5Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp4Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp3Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp2Tx1PhaseShiftter;

		private NumericUpDown m_nudChirp1Tx1PhaseShiftter;

		private NumericUpDown m_nudPerChirpSegmentSelect;

		private Label label52;

		private Label label54;

		private Label label55;

		private Label label40;

		private Label label41;

		private Label label42;

		private Label label43;

		private Label label44;

		private Label label45;

		private Label label46;

		private Label label47;

		private Label label38;

		private Label label39;

		private Label label22;

		private Label label37;

		private Label label19;

		private Label label21;

		private Label label1;

		private Label label15;

		private GroupBox groupBox3;

		private Button m_btnDynamicChirpEnableConfigSet;

		private Label label2;

		private GroupBox groupBox1;

		private CheckBox m_ChbProgramModeEnable;

		private NumericUpDown m_nudChirpRowSelect;

		private Label label49;

		private Label label48;

		private Button m_btnDynamicChirpConfigSet;

		private Label label20;

		private Label label17;

		private Label label18;

		private Label label16;

		private NumericUpDown m_nudChirpSegmentSelect;

		private Label label13;

		private Label label14;

		private Label label11;

		private Label label12;

		private Label label9;

		private Label label10;

		private Label label5;

		private Label label6;

		private Label label4;

		private Panel panel1;

		private NumericUpDown m_nudChirp16BPMConstVal;

		private CheckBox m_ChbChirp16Tx3Enable;

		private CheckBox m_ChbChirp16Tx2Enable;

		private CheckBox m_ChbChirp16Tx1Enable;

		private NumericUpDown m_nudChirp16FreqSlopeVar;

		private NumericUpDown m_nudChirp16ProfileIndex;

		private NumericUpDown m_nudChirp16FreqStartVar;

		private NumericUpDown m_nudChirp16ADCStartTimeVar;

		private NumericUpDown m_nudChirp16IdleTimeVar;

		private NumericUpDown m_nudChirp14BPMConstVal;

		private CheckBox m_ChbChirp14Tx3Enable;

		private CheckBox m_ChbChirp14Tx2Enable;

		private CheckBox m_ChbChirp14Tx1Enable;

		private NumericUpDown m_nudChirp14FreqSlopeVar;

		private NumericUpDown m_nudChirp14ProfileIndex;

		private NumericUpDown m_nudChirp14FreqStartVar;

		private NumericUpDown m_nudChirp14ADCStartTimeVar;

		private NumericUpDown m_nudChirp14IdleTimeVar;

		private NumericUpDown m_nudChirp15BPMConstVal;

		private CheckBox m_ChbChirp15Tx3Enable;

		private CheckBox m_ChbChirp15Tx2Enable;

		private CheckBox m_ChbChirp15Tx1Enable;

		private NumericUpDown m_nudChirp15FreqSlopeVar;

		private NumericUpDown m_nudChirp15ProfileIndex;

		private NumericUpDown m_nudChirp15FreqStartVar;

		private NumericUpDown m_nudChirp15ADCStartTimeVar;

		private NumericUpDown m_nudChirp15IdleTimeVar;

		private NumericUpDown m_nudChirp13BPMConstVal;

		private CheckBox m_ChbChirp13Tx3Enable;

		private CheckBox m_ChbChirp13Tx2Enable;

		private CheckBox m_ChbChirp13Tx1Enable;

		private NumericUpDown m_nudChirp13FreqSlopeVar;

		private NumericUpDown m_nudChirp13ProfileIndex;

		private NumericUpDown m_nudChirp13FreqStartVar;

		private NumericUpDown m_nudChirp13ADCStartTimeVar;

		private NumericUpDown m_nudChirp13IdleTimeVar;

		private NumericUpDown m_nudChirp12BPMConstVal;

		private CheckBox m_ChbChirp12Tx3Enable;

		private CheckBox m_ChbChirp12Tx2Enable;

		private CheckBox m_ChbChirp12Tx1Enable;

		private NumericUpDown m_nudChirp12FreqSlopeVar;

		private NumericUpDown m_nudChirp12ProfileIndex;

		private NumericUpDown m_nudChirp12FreqStartVar;

		private NumericUpDown m_nudChirp12ADCStartTimeVar;

		private NumericUpDown m_nudChirp12IdleTimeVar;

		private NumericUpDown m_nudChirp11BPMConstVal;

		private CheckBox m_ChbChirp11Tx3Enable;

		private CheckBox m_ChbChirp11Tx2Enable;

		private CheckBox m_ChbChirp11Tx1Enable;

		private NumericUpDown m_nudChirp11FreqSlopeVar;

		private NumericUpDown m_nudChirp11ProfileIndex;

		private NumericUpDown m_nudChirp11FreqStartVar;

		private NumericUpDown m_nudChirp11ADCStartTimeVar;

		private NumericUpDown m_nudChirp11IdleTimeVar;

		private NumericUpDown m_nudChirp9BPMConstVal;

		private CheckBox m_ChbChirp9Tx3Enable;

		private CheckBox m_ChbChirp9Tx2Enable;

		private CheckBox m_ChbChirp9Tx1Enable;

		private NumericUpDown m_nudChirp9FreqSlopeVar;

		private NumericUpDown m_nudChirp9ProfileIndex;

		private NumericUpDown m_nudChirp9FreqStartVar;

		private NumericUpDown m_nudChirp9ADCStartTimeVar;

		private NumericUpDown m_nudChirp9IdleTimeVar;

		private NumericUpDown m_nudChirp10BPMConstVal;

		private CheckBox m_ChbChirp10Tx3Enable;

		private CheckBox m_ChbChirp10Tx2Enable;

		private CheckBox m_ChbChirp10Tx1Enable;

		private NumericUpDown m_nudChirp10FreqSlopeVar;

		private NumericUpDown m_nudChirp10ProfileIndex;

		private NumericUpDown m_nudChirp10FreqStartVar;

		private NumericUpDown m_nudChirp10ADCStartTimeVar;

		private NumericUpDown m_nudChirp10IdleTimeVar;

		private NumericUpDown m_nudChirp8BPMConstVal;

		private CheckBox m_ChbChirp8Tx3Enable;

		private CheckBox m_ChbChirp8Tx2Enable;

		private CheckBox m_ChbChirp8Tx1Enable;

		private NumericUpDown m_nudChirp8FreqSlopeVar;

		private NumericUpDown m_nudChirp8ProfileIndex;

		private NumericUpDown m_nudChirp8FreqStartVar;

		private NumericUpDown m_nudChirp8ADCStartTimeVar;

		private NumericUpDown m_nudChirp8IdleTimeVar;

		private NumericUpDown m_nudChirp7BPMConstVal;

		private CheckBox m_ChbChirp7Tx3Enable;

		private CheckBox m_ChbChirp7Tx2Enable;

		private CheckBox m_ChbChirp7Tx1Enable;

		private NumericUpDown m_nudChirp7FreqSlopeVar;

		private NumericUpDown m_nudChirp7ProfileIndex;

		private NumericUpDown m_nudChirp7FreqStartVar;

		private NumericUpDown m_nudChirp7ADCStartTimeVar;

		private NumericUpDown m_nudChirp7IdleTimeVar;

		private NumericUpDown m_nudChirp6BPMConstVal;

		private CheckBox m_ChbChirp6Tx3Enable;

		private CheckBox m_ChbChirp6Tx2Enable;

		private CheckBox m_ChbChirp6Tx1Enable;

		private NumericUpDown m_nudChirp6FreqSlopeVar;

		private NumericUpDown m_nudChirp6ProfileIndex;

		private NumericUpDown m_nudChirp6FreqStartVar;

		private NumericUpDown m_nudChirp6ADCStartTimeVar;

		private NumericUpDown m_nudChirp6IdleTimeVar;

		private NumericUpDown m_nudChirp4BPMConstVal;

		private CheckBox m_ChbChirp4Tx3Enable;

		private CheckBox m_ChbChirp4Tx2Enable;

		private CheckBox m_ChbChirp4Tx1Enable;

		private NumericUpDown m_nudChirp4FreqSlopeVar;

		private NumericUpDown m_nudChirp4ProfileIndex;

		private NumericUpDown m_nudChirp4FreqStartVar;

		private NumericUpDown m_nudChirp4ADCStartTimeVar;

		private NumericUpDown m_nudChirp4IdleTimeVar;

		private NumericUpDown m_nudChirp5BPMConstVal;

		private CheckBox m_ChbChirp5Tx3Enable;

		private CheckBox m_ChbChirp5Tx2Enable;

		private CheckBox m_ChbChirp5Tx1Enable;

		private NumericUpDown m_nudChirp5FreqSlopeVar;

		private NumericUpDown m_nudChirp5ProfileIndex;

		private NumericUpDown m_nudChirp5FreqStartVar;

		private NumericUpDown m_nudChirp5ADCStartTimeVar;

		private NumericUpDown m_nudChirp5IdleTimeVar;

		private NumericUpDown m_nudChirp3BPMConstVal;

		private CheckBox m_ChbChirp3Tx3Enable;

		private CheckBox m_ChbChirp3Tx2Enable;

		private CheckBox m_ChbChirp3Tx1Enable;

		private NumericUpDown m_nudChirp3FreqSlopeVar;

		private NumericUpDown m_nudChirp3ProfileIndex;

		private NumericUpDown m_nudChirp3FreqStartVar;

		private NumericUpDown m_nudChirp3ADCStartTimeVar;

		private NumericUpDown m_nudChirp3IdleTimeVar;

		private NumericUpDown m_nudChirp2BPMConstVal;

		private CheckBox m_ChbChirp2Tx3Enable;

		private CheckBox m_ChbChirp2Tx2Enable;

		private CheckBox m_ChbChirp2Tx1Enable;

		private NumericUpDown m_nudChirp2FreqSlopeVar;

		private NumericUpDown m_nudChirp2ProfileIndex;

		private NumericUpDown m_nudChirp2FreqStartVar;

		private NumericUpDown m_nudChirp2ADCStartTimeVar;

		private NumericUpDown m_nudChirp2IdleTimeVar;

		private Label label35;

		private Label label36;

		private Label label33;

		private Label label34;

		private Label label31;

		private Label label32;

		private NumericUpDown m_nudChirp1BPMConstVal;

		private Label label29;

		private Label label30;

		private Label label27;

		private Label label28;

		private Label label25;

		private Label label26;

		private Label label23;

		private CheckBox m_ChbChirp1Tx3Enable;

		private CheckBox m_ChbChirp1Tx2Enable;

		private CheckBox m_ChbChirp1Tx1Enable;

		private NumericUpDown m_nudChirp1FreqSlopeVar;

		private NumericUpDown m_nudChirp1ProfileIndex;

		private NumericUpDown m_nudChirp1FreqStartVar;

		private NumericUpDown m_nudChirp1ADCStartTimeVar;

		private NumericUpDown m_nudChirp1IdleTimeVar;

		private Label label7;

		private Label label8;

		private Label label3;

		private NumericUpDown m_nudChirp48BPMConstVal;

		private CheckBox m_ChbChirp48Tx3Enable;

		private CheckBox m_ChbChirp48Tx2Enable;

		private CheckBox m_ChbChirp48Tx1Enable;

		private NumericUpDown m_nudChirp48FreqSlopeVar;

		private NumericUpDown m_nudChirp48ProfileIndex;

		private NumericUpDown m_nudChirp48FreqStartVar;

		private NumericUpDown m_nudChirp48ADCStartTimeVar;

		private NumericUpDown m_nudChirp48IdleTimeVar;

		private NumericUpDown m_nudChirp47BPMConstVal;

		private CheckBox m_ChbChirp47Tx3Enable;

		private CheckBox m_ChbChirp47Tx2Enable;

		private CheckBox m_ChbChirp47Tx1Enable;

		private NumericUpDown m_nudChirp47FreqSlopeVar;

		private NumericUpDown m_nudChirp47ProfileIndex;

		private NumericUpDown m_nudChirp47FreqStartVar;

		private NumericUpDown m_nudChirp47ADCStartTimeVar;

		private NumericUpDown m_nudChirp47IdleTimeVar;

		private NumericUpDown m_nudChirp46BPMConstVal;

		private CheckBox m_ChbChirp46Tx3Enable;

		private CheckBox m_ChbChirp46Tx2Enable;

		private CheckBox m_ChbChirp46Tx1Enable;

		private NumericUpDown m_nudChirp46FreqSlopeVar;

		private NumericUpDown m_nudChirp46ProfileIndex;

		private NumericUpDown m_nudChirp46FreqStartVar;

		private NumericUpDown m_nudChirp46ADCStartTimeVar;

		private NumericUpDown m_nudChirp46IdleTimeVar;

		private NumericUpDown m_nudChirp44BPMConstVal;

		private CheckBox m_ChbChirp44Tx3Enable;

		private CheckBox m_ChbChirp44Tx2Enable;

		private CheckBox m_ChbChirp44Tx1Enable;

		private NumericUpDown m_nudChirp44FreqSlopeVar;

		private NumericUpDown m_nudChirp44ProfileIndex;

		private NumericUpDown m_nudChirp44FreqStartVar;

		private NumericUpDown m_nudChirp44ADCStartTimeVar;

		private NumericUpDown m_nudChirp44IdleTimeVar;

		private NumericUpDown m_nudChirp45BPMConstVal;

		private CheckBox m_ChbChirp45Tx3Enable;

		private CheckBox m_ChbChirp45Tx2Enable;

		private CheckBox m_ChbChirp45Tx1Enable;

		private NumericUpDown m_nudChirp45FreqSlopeVar;

		private NumericUpDown m_nudChirp45ProfileIndex;

		private NumericUpDown m_nudChirp45FreqStartVar;

		private NumericUpDown m_nudChirp45ADCStartTimeVar;

		private NumericUpDown m_nudChirp45IdleTimeVar;

		private NumericUpDown m_nudChirp43BPMConstVal;

		private CheckBox m_ChbChirp43Tx3Enable;

		private CheckBox m_ChbChirp43Tx2Enable;

		private CheckBox m_ChbChirp43Tx1Enable;

		private NumericUpDown m_nudChirp43FreqSlopeVar;

		private NumericUpDown m_nudChirp43ProfileIndex;

		private NumericUpDown m_nudChirp43FreqStartVar;

		private NumericUpDown m_nudChirp43ADCStartTimeVar;

		private NumericUpDown m_nudChirp43IdleTimeVar;

		private NumericUpDown m_nudChirp42BPMConstVal;

		private CheckBox m_ChbChirp42Tx3Enable;

		private CheckBox m_ChbChirp42Tx2Enable;

		private CheckBox m_ChbChirp42Tx1Enable;

		private NumericUpDown m_nudChirp42FreqSlopeVar;

		private NumericUpDown m_nudChirp42ProfileIndex;

		private NumericUpDown m_nudChirp42FreqStartVar;

		private NumericUpDown m_nudChirp42ADCStartTimeVar;

		private NumericUpDown m_nudChirp42IdleTimeVar;

		private NumericUpDown m_nudChirp41BPMConstVal;

		private CheckBox m_ChbChirp41Tx3Enable;

		private CheckBox m_ChbChirp41Tx2Enable;

		private CheckBox m_ChbChirp41Tx1Enable;

		private NumericUpDown m_nudChirp41FreqSlopeVar;

		private NumericUpDown m_nudChirp41ProfileIndex;

		private NumericUpDown m_nudChirp41FreqStartVar;

		private NumericUpDown m_nudChirp41ADCStartTimeVar;

		private NumericUpDown m_nudChirp41IdleTimeVar;

		private NumericUpDown m_nudChirp40BPMConstVal;

		private CheckBox m_ChbChirp40Tx3Enable;

		private CheckBox m_ChbChirp40Tx2Enable;

		private CheckBox m_ChbChirp40Tx1Enable;

		private NumericUpDown m_nudChirp40FreqSlopeVar;

		private NumericUpDown m_nudChirp40ProfileIndex;

		private NumericUpDown m_nudChirp40FreqStartVar;

		private NumericUpDown m_nudChirp40ADCStartTimeVar;

		private NumericUpDown m_nudChirp40IdleTimeVar;

		private Label label67;

		private Label label69;

		private Label label70;

		private Label label71;

		private Label label72;

		private Label label73;

		private Label label74;

		private Label label75;

		private Label label76;

		private NumericUpDown m_nudChirp39BPMConstVal;

		private CheckBox m_ChbChirp39Tx3Enable;

		private CheckBox m_ChbChirp39Tx2Enable;

		private CheckBox m_ChbChirp39Tx1Enable;

		private NumericUpDown m_nudChirp39FreqSlopeVar;

		private NumericUpDown m_nudChirp39ProfileIndex;

		private NumericUpDown m_nudChirp39FreqStartVar;

		private NumericUpDown m_nudChirp39ADCStartTimeVar;

		private NumericUpDown m_nudChirp39IdleTimeVar;

		private NumericUpDown m_nudChirp37BPMConstVal;

		private CheckBox m_ChbChirp37Tx3Enable;

		private CheckBox m_ChbChirp37Tx2Enable;

		private CheckBox m_ChbChirp37Tx1Enable;

		private NumericUpDown m_nudChirp37FreqSlopeVar;

		private NumericUpDown m_nudChirp37ProfileIndex;

		private NumericUpDown m_nudChirp37FreqStartVar;

		private NumericUpDown m_nudChirp37ADCStartTimeVar;

		private NumericUpDown m_nudChirp37IdleTimeVar;

		private NumericUpDown m_nudChirp38BPMConstVal;

		private CheckBox m_ChbChirp38Tx3Enable;

		private CheckBox m_ChbChirp38Tx2Enable;

		private CheckBox m_ChbChirp38Tx1Enable;

		private NumericUpDown m_nudChirp38FreqSlopeVar;

		private NumericUpDown m_nudChirp38ProfileIndex;

		private NumericUpDown m_nudChirp38FreqStartVar;

		private NumericUpDown m_nudChirp38ADCStartTimeVar;

		private NumericUpDown m_nudChirp38IdleTimeVar;

		private NumericUpDown m_nudChirp36BPMConstVal;

		private CheckBox m_ChbChirp36Tx3Enable;

		private CheckBox m_ChbChirp36Tx2Enable;

		private CheckBox m_ChbChirp36Tx1Enable;

		private NumericUpDown m_nudChirp36FreqSlopeVar;

		private NumericUpDown m_nudChirp36ProfileIndex;

		private NumericUpDown m_nudChirp36FreqStartVar;

		private NumericUpDown m_nudChirp36ADCStartTimeVar;

		private NumericUpDown m_nudChirp36IdleTimeVar;

		private NumericUpDown m_nudChirp35BPMConstVal;

		private CheckBox m_ChbChirp35Tx3Enable;

		private CheckBox m_ChbChirp35Tx2Enable;

		private CheckBox m_ChbChirp35Tx1Enable;

		private NumericUpDown m_nudChirp35FreqSlopeVar;

		private NumericUpDown m_nudChirp35ProfileIndex;

		private NumericUpDown m_nudChirp35FreqStartVar;

		private NumericUpDown m_nudChirp35ADCStartTimeVar;

		private NumericUpDown m_nudChirp35IdleTimeVar;

		private NumericUpDown m_nudChirp34BPMConstVal;

		private CheckBox m_ChbChirp34Tx3Enable;

		private CheckBox m_ChbChirp34Tx2Enable;

		private CheckBox m_ChbChirp34Tx1Enable;

		private NumericUpDown m_nudChirp34FreqSlopeVar;

		private NumericUpDown m_nudChirp34ProfileIndex;

		private NumericUpDown m_nudChirp34FreqStartVar;

		private NumericUpDown m_nudChirp34ADCStartTimeVar;

		private NumericUpDown m_nudChirp34IdleTimeVar;

		private NumericUpDown m_nudChirp32BPMConstVal;

		private CheckBox m_ChbChirp32Tx3Enable;

		private CheckBox m_ChbChirp32Tx2Enable;

		private CheckBox m_ChbChirp32Tx1Enable;

		private NumericUpDown m_nudChirp32FreqSlopeVar;

		private NumericUpDown m_nudChirp32ProfileIndex;

		private NumericUpDown m_nudChirp32FreqStartVar;

		private NumericUpDown m_nudChirp32ADCStartTimeVar;

		private NumericUpDown m_nudChirp32IdleTimeVar;

		private NumericUpDown m_nudChirp33BPMConstVal;

		private CheckBox m_ChbChirp33Tx3Enable;

		private CheckBox m_ChbChirp33Tx2Enable;

		private CheckBox m_ChbChirp33Tx1Enable;

		private NumericUpDown m_nudChirp33FreqSlopeVar;

		private NumericUpDown m_nudChirp33ProfileIndex;

		private NumericUpDown m_nudChirp33FreqStartVar;

		private NumericUpDown m_nudChirp33ADCStartTimeVar;

		private NumericUpDown m_nudChirp33IdleTimeVar;

		private NumericUpDown m_nudChirp31BPMConstVal;

		private CheckBox m_ChbChirp31Tx3Enable;

		private CheckBox m_ChbChirp31Tx2Enable;

		private CheckBox m_ChbChirp31Tx1Enable;

		private NumericUpDown m_nudChirp31FreqSlopeVar;

		private NumericUpDown m_nudChirp31ProfileIndex;

		private NumericUpDown m_nudChirp31FreqStartVar;

		private NumericUpDown m_nudChirp31ADCStartTimeVar;

		private NumericUpDown m_nudChirp31IdleTimeVar;

		private NumericUpDown m_nudChirp30BPMConstVal;

		private CheckBox m_ChbChirp30Tx3Enable;

		private CheckBox m_ChbChirp30Tx2Enable;

		private CheckBox m_ChbChirp30Tx1Enable;

		private NumericUpDown m_nudChirp30FreqSlopeVar;

		private NumericUpDown m_nudChirp30ProfileIndex;

		private NumericUpDown m_nudChirp30FreqStartVar;

		private NumericUpDown m_nudChirp30ADCStartTimeVar;

		private NumericUpDown m_nudChirp30IdleTimeVar;

		private NumericUpDown m_nudChirp29BPMConstVal;

		private CheckBox m_ChbChirp29Tx3Enable;

		private CheckBox m_ChbChirp29Tx2Enable;

		private CheckBox m_ChbChirp29Tx1Enable;

		private NumericUpDown m_nudChirp29FreqSlopeVar;

		private NumericUpDown m_nudChirp29ProfileIndex;

		private NumericUpDown m_nudChirp29FreqStartVar;

		private NumericUpDown m_nudChirp29ADCStartTimeVar;

		private NumericUpDown m_nudChirp29IdleTimeVar;

		private Label label77;

		private Label label78;

		private Label label79;

		private Label label80;

		private Label label81;

		private Label label82;

		private Label label83;

		private Label label84;

		private Label label85;

		private Label label86;

		private Label label87;

		private NumericUpDown m_nudChirp28BPMConstVal;

		private CheckBox m_ChbChirp28Tx3Enable;

		private CheckBox m_ChbChirp28Tx2Enable;

		private CheckBox m_ChbChirp28Tx1Enable;

		private NumericUpDown m_nudChirp28FreqSlopeVar;

		private NumericUpDown m_nudChirp28ProfileIndex;

		private NumericUpDown m_nudChirp28FreqStartVar;

		private NumericUpDown m_nudChirp28ADCStartTimeVar;

		private NumericUpDown m_nudChirp28IdleTimeVar;

		private NumericUpDown m_nudChirp26BPMConstVal;

		private CheckBox m_ChbChirp26Tx3Enable;

		private CheckBox m_ChbChirp26Tx2Enable;

		private CheckBox m_ChbChirp26Tx1Enable;

		private NumericUpDown m_nudChirp26FreqSlopeVar;

		private NumericUpDown m_nudChirp26ProfileIndex;

		private NumericUpDown m_nudChirp26FreqStartVar;

		private NumericUpDown m_nudChirp26ADCStartTimeVar;

		private NumericUpDown m_nudChirp26IdleTimeVar;

		private NumericUpDown m_nudChirp27BPMConstVal;

		private CheckBox m_ChbChirp27Tx3Enable;

		private CheckBox m_ChbChirp27Tx2Enable;

		private CheckBox m_ChbChirp27Tx1Enable;

		private NumericUpDown m_nudChirp27FreqSlopeVar;

		private NumericUpDown m_nudChirp27ProfileIndex;

		private NumericUpDown m_nudChirp27FreqStartVar;

		private NumericUpDown m_nudChirp27ADCStartTimeVar;

		private NumericUpDown m_nudChirp27IdleTimeVar;

		private NumericUpDown m_nudChirp25BPMConstVal;

		private CheckBox m_ChbChirp25Tx3Enable;

		private CheckBox m_ChbChirp25Tx2Enable;

		private CheckBox m_ChbChirp25Tx1Enable;

		private NumericUpDown m_nudChirp25FreqSlopeVar;

		private NumericUpDown m_nudChirp25ProfileIndex;

		private NumericUpDown m_nudChirp25FreqStartVar;

		private NumericUpDown m_nudChirp25ADCStartTimeVar;

		private NumericUpDown m_nudChirp25IdleTimeVar;

		private NumericUpDown m_nudChirp24BPMConstVal;

		private CheckBox m_ChbChirp24Tx3Enable;

		private CheckBox m_ChbChirp24Tx2Enable;

		private CheckBox m_ChbChirp24Tx1Enable;

		private NumericUpDown m_nudChirp24FreqSlopeVar;

		private NumericUpDown m_nudChirp24ProfileIndex;

		private NumericUpDown m_nudChirp24FreqStartVar;

		private NumericUpDown m_nudChirp24ADCStartTimeVar;

		private NumericUpDown m_nudChirp24IdleTimeVar;

		private NumericUpDown m_nudChirp23BPMConstVal;

		private CheckBox m_ChbChirp23Tx3Enable;

		private CheckBox m_ChbChirp23Tx2Enable;

		private CheckBox m_ChbChirp23Tx1Enable;

		private NumericUpDown m_nudChirp23FreqSlopeVar;

		private NumericUpDown m_nudChirp23ProfileIndex;

		private NumericUpDown m_nudChirp23FreqStartVar;

		private NumericUpDown m_nudChirp23ADCStartTimeVar;

		private NumericUpDown m_nudChirp23IdleTimeVar;

		private NumericUpDown m_nudChirp21BPMConstVal;

		private CheckBox m_ChbChirp21Tx3Enable;

		private CheckBox m_ChbChirp21Tx2Enable;

		private CheckBox m_ChbChirp21Tx1Enable;

		private NumericUpDown m_nudChirp21FreqSlopeVar;

		private NumericUpDown m_nudChirp21ProfileIndex;

		private NumericUpDown m_nudChirp21FreqStartVar;

		private NumericUpDown m_nudChirp21ADCStartTimeVar;

		private NumericUpDown m_nudChirp21IdleTimeVar;

		private NumericUpDown m_nudChirp22BPMConstVal;

		private CheckBox m_ChbChirp22Tx3Enable;

		private CheckBox m_ChbChirp22Tx2Enable;

		private CheckBox m_ChbChirp22Tx1Enable;

		private NumericUpDown m_nudChirp22FreqSlopeVar;

		private NumericUpDown m_nudChirp22ProfileIndex;

		private NumericUpDown m_nudChirp22FreqStartVar;

		private NumericUpDown m_nudChirp22ADCStartTimeVar;

		private NumericUpDown m_nudChirp22IdleTimeVar;

		private NumericUpDown m_nudChirp20BPMConstVal;

		private CheckBox m_ChbChirp20Tx3Enable;

		private CheckBox m_ChbChirp20Tx2Enable;

		private CheckBox m_ChbChirp20Tx1Enable;

		private NumericUpDown m_nudChirp20FreqSlopeVar;

		private NumericUpDown m_nudChirp20ProfileIndex;

		private NumericUpDown m_nudChirp20FreqStartVar;

		private NumericUpDown m_nudChirp20ADCStartTimeVar;

		private NumericUpDown m_nudChirp20IdleTimeVar;

		private NumericUpDown m_nudChirp19BPMConstVal;

		private CheckBox m_ChbChirp19Tx3Enable;

		private CheckBox m_ChbChirp19Tx2Enable;

		private CheckBox m_ChbChirp19Tx1Enable;

		private NumericUpDown m_nudChirp19FreqSlopeVar;

		private NumericUpDown m_nudChirp19ProfileIndex;

		private NumericUpDown m_nudChirp19FreqStartVar;

		private NumericUpDown m_nudChirp19ADCStartTimeVar;

		private NumericUpDown m_nudChirp19IdleTimeVar;

		private NumericUpDown m_nudChirp18BPMConstVal;

		private CheckBox m_ChbChirp18Tx3Enable;

		private CheckBox m_ChbChirp18Tx2Enable;

		private CheckBox m_ChbChirp18Tx1Enable;

		private NumericUpDown m_nudChirp18FreqSlopeVar;

		private NumericUpDown m_nudChirp18ProfileIndex;

		private NumericUpDown m_nudChirp18FreqStartVar;

		private NumericUpDown m_nudChirp18ADCStartTimeVar;

		private NumericUpDown m_nudChirp18IdleTimeVar;

		private NumericUpDown m_nudChirp17BPMConstVal;

		private CheckBox m_ChbChirp17Tx3Enable;

		private CheckBox m_ChbChirp17Tx2Enable;

		private CheckBox m_ChbChirp17Tx1Enable;

		private NumericUpDown m_nudChirp17FreqSlopeVar;

		private NumericUpDown m_nudChirp17ProfileIndex;

		private NumericUpDown m_nudChirp17FreqStartVar;

		private NumericUpDown m_nudChirp17ADCStartTimeVar;

		private NumericUpDown m_nudChirp17IdleTimeVar;

		private Label label50;

		private Label label51;

		private Label label53;

		private Label label56;

		private Label label57;

		private Label label58;

		private Label label59;

		private Label label60;

		private Label label61;

		private Label label62;

		private Label label63;

		private Label label64;
	}
}
