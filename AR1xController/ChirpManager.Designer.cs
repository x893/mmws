namespace AR1xController
{
	public partial class ChirpManager : global::System.Windows.Forms.Form
	{
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
			this.dataGridView1 = new global::System.Windows.Forms.DataGridView();
			this.openFileDialog1 = new global::System.Windows.Forms.OpenFileDialog();
			this.m_btnBrowse = new global::System.Windows.Forms.Button();
			this.m_btnLoad = new global::System.Windows.Forms.Button();
			this.m_btnSave = new global::System.Windows.Forms.Button();
			this.m_btnActivate = new global::System.Windows.Forms.Button();
			this.m_grpProfile = new global::System.Windows.Forms.GroupBox();
			this.m_nudTx1OutPowerBackoffCode = new global::System.Windows.Forms.NumericUpDown();
			this.m_nudTx2OutPowerBackoffCode = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfileTx1OpPwrBackoff = new global::System.Windows.Forms.Label();
			this.m_lblProfileTx2OpPwrBackoff = new global::System.Windows.Forms.Label();
			this.radioButton4 = new global::System.Windows.Forms.RadioButton();
			this.label2 = new global::System.Windows.Forms.Label();
			this.radioButton3 = new global::System.Windows.Forms.RadioButton();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radioButton2 = new global::System.Windows.Forms.RadioButton();
			this.m_nudTx3PhaseShifter = new global::System.Windows.Forms.NumericUpDown();
			this.radioButton1 = new global::System.Windows.Forms.RadioButton();
			this.m_nudTx2PhaseShifter = new global::System.Windows.Forms.NumericUpDown();
			this.m_nudProfileRxGain = new global::System.Windows.Forms.NumericUpDown();
			this.m_nudTxStartTime = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfileTxStartTime = new global::System.Windows.Forms.Label();
			this.m_nudFreqSlopeConst = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfileFreqSlope = new global::System.Windows.Forms.Label();
			this.m_nudTx1PhaseShifter = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfilePhaseShifter = new global::System.Windows.Forms.Label();
			this.m_nudTx3OutPowerBackoffCode = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfileTx3OpPwrBackoff = new global::System.Windows.Forms.Label();
			this.m_nudStartFreqConst = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfileStartFreqConst = new global::System.Windows.Forms.Label();
			this.m_nudRampEndTime = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfileRampEndTime = new global::System.Windows.Forms.Label();
			this.m_nudIdleTimeConst = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfileIdleTime = new global::System.Windows.Forms.Label();
			this.m_nudAdcStartTimeConst = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfileAdcStartTime = new global::System.Windows.Forms.Label();
			this.m_nudNumAdcSamples = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfileAdcSamples = new global::System.Windows.Forms.Label();
			this.m_nudDigOutSampleRate = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfileSampleRate = new global::System.Windows.Forms.Label();
			this.m_lblProfileRxGain = new global::System.Windows.Forms.Label();
			this.m_cboProfileHpf2 = new global::System.Windows.Forms.ComboBox();
			this.m_lblProfileHpf2 = new global::System.Windows.Forms.Label();
			this.m_cboProfileHpf1 = new global::System.Windows.Forms.ComboBox();
			this.m_lblProfileHpf1 = new global::System.Windows.Forms.Label();
			this.m_nudProfileProfileId = new global::System.Windows.Forms.NumericUpDown();
			this.m_lblProfileProfileId = new global::System.Windows.Forms.Label();
			this.m_cboADCDataFileChirpConfig = new global::System.Windows.Forms.ComboBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.m_cboProfileRFGainTargetMnger = new global::System.Windows.Forms.ComboBox();
			this.m_cboChripMngrProfileVCOSelect = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.m_chbChirpMngProfileForceVCOSelect = new global::System.Windows.Forms.CheckBox();
			this.m_chbChirpMngrProfileRetainTxCalLUT = new global::System.Windows.Forms.CheckBox();
			this.m_chbChirpMngrProfileRetainRxCalLUT = new global::System.Windows.Forms.CheckBox();
			this.label5 = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
			this.m_grpProfile.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx1OutPowerBackoffCode).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx2OutPowerBackoffCode).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx3PhaseShifter).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx2PhaseShifter).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudProfileRxGain).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTxStartTime).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudFreqSlopeConst).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx1PhaseShifter).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx3OutPowerBackoffCode).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudStartFreqConst).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudRampEndTime).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudIdleTimeConst).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudAdcStartTimeConst).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudNumAdcSamples).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudDigOutSampleRate).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudProfileProfileId).BeginInit();
			base.SuspendLayout();
			this.dataGridView1.BackgroundColor = global::System.Drawing.SystemColors.ButtonHighlight;
			this.dataGridView1.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new global::System.Drawing.Point(1, 436);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new global::System.Drawing.Size(1200, 295);
			this.dataGridView1.TabIndex = 28;
			this.dataGridView1.CellBeginEdit += new global::System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
			this.openFileDialog1.FileName = "openFileDialog1";
			this.m_btnBrowse.Location = new global::System.Drawing.Point(440, 383);
			this.m_btnBrowse.Name = "m_btnBrowse";
			this.m_btnBrowse.Size = new global::System.Drawing.Size(87, 27);
			this.m_btnBrowse.TabIndex = 24;
			this.m_btnBrowse.Text = "Browse";
			this.m_btnBrowse.UseVisualStyleBackColor = true;
			this.m_btnBrowse.Click += new global::System.EventHandler(this.m_btnBrowse_Click);
			this.m_btnLoad.Location = new global::System.Drawing.Point(563, 383);
			this.m_btnLoad.Name = "m_btnLoad";
			this.m_btnLoad.Size = new global::System.Drawing.Size(87, 27);
			this.m_btnLoad.TabIndex = 25;
			this.m_btnLoad.Text = "Load";
			this.m_btnLoad.UseVisualStyleBackColor = true;
			this.m_btnLoad.Click += new global::System.EventHandler(this.m_btnLoad_Click);
			this.m_btnSave.Location = new global::System.Drawing.Point(685, 383);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Size = new global::System.Drawing.Size(87, 27);
			this.m_btnSave.TabIndex = 26;
			this.m_btnSave.Text = "Save";
			this.m_btnSave.UseVisualStyleBackColor = true;
			this.m_btnSave.Click += new global::System.EventHandler(this.m_btnSave_Click);
			this.m_btnActivate.Location = new global::System.Drawing.Point(810, 383);
			this.m_btnActivate.Name = "m_btnActivate";
			this.m_btnActivate.Size = new global::System.Drawing.Size(87, 27);
			this.m_btnActivate.TabIndex = 27;
			this.m_btnActivate.Text = "Activate";
			this.m_btnActivate.UseVisualStyleBackColor = true;
			this.m_btnActivate.Click += new global::System.EventHandler(this.m_btnActivate_Click);
			this.m_grpProfile.Controls.Add(this.label5);
			this.m_grpProfile.Controls.Add(this.m_chbChirpMngrProfileRetainRxCalLUT);
			this.m_grpProfile.Controls.Add(this.m_chbChirpMngrProfileRetainTxCalLUT);
			this.m_grpProfile.Controls.Add(this.m_chbChirpMngProfileForceVCOSelect);
			this.m_grpProfile.Controls.Add(this.label4);
			this.m_grpProfile.Controls.Add(this.m_cboChripMngrProfileVCOSelect);
			this.m_grpProfile.Controls.Add(this.m_cboProfileRFGainTargetMnger);
			this.m_grpProfile.Controls.Add(this.label3);
			this.m_grpProfile.Controls.Add(this.m_nudTx1OutPowerBackoffCode);
			this.m_grpProfile.Controls.Add(this.m_nudTx2OutPowerBackoffCode);
			this.m_grpProfile.Controls.Add(this.m_lblProfileTx1OpPwrBackoff);
			this.m_grpProfile.Controls.Add(this.m_lblProfileTx2OpPwrBackoff);
			this.m_grpProfile.Controls.Add(this.radioButton4);
			this.m_grpProfile.Controls.Add(this.label2);
			this.m_grpProfile.Controls.Add(this.radioButton3);
			this.m_grpProfile.Controls.Add(this.label1);
			this.m_grpProfile.Controls.Add(this.radioButton2);
			this.m_grpProfile.Controls.Add(this.m_nudTx3PhaseShifter);
			this.m_grpProfile.Controls.Add(this.radioButton1);
			this.m_grpProfile.Controls.Add(this.m_nudTx2PhaseShifter);
			this.m_grpProfile.Controls.Add(this.m_nudProfileRxGain);
			this.m_grpProfile.Controls.Add(this.m_nudTxStartTime);
			this.m_grpProfile.Controls.Add(this.m_lblProfileTxStartTime);
			this.m_grpProfile.Controls.Add(this.m_nudFreqSlopeConst);
			this.m_grpProfile.Controls.Add(this.m_lblProfileFreqSlope);
			this.m_grpProfile.Controls.Add(this.m_nudTx1PhaseShifter);
			this.m_grpProfile.Controls.Add(this.m_lblProfilePhaseShifter);
			this.m_grpProfile.Controls.Add(this.m_nudTx3OutPowerBackoffCode);
			this.m_grpProfile.Controls.Add(this.m_lblProfileTx3OpPwrBackoff);
			this.m_grpProfile.Controls.Add(this.m_nudStartFreqConst);
			this.m_grpProfile.Controls.Add(this.m_lblProfileStartFreqConst);
			this.m_grpProfile.Controls.Add(this.m_nudRampEndTime);
			this.m_grpProfile.Controls.Add(this.m_lblProfileRampEndTime);
			this.m_grpProfile.Controls.Add(this.m_nudIdleTimeConst);
			this.m_grpProfile.Controls.Add(this.m_lblProfileIdleTime);
			this.m_grpProfile.Controls.Add(this.m_nudAdcStartTimeConst);
			this.m_grpProfile.Controls.Add(this.m_lblProfileAdcStartTime);
			this.m_grpProfile.Controls.Add(this.m_nudNumAdcSamples);
			this.m_grpProfile.Controls.Add(this.m_lblProfileAdcSamples);
			this.m_grpProfile.Controls.Add(this.m_nudDigOutSampleRate);
			this.m_grpProfile.Controls.Add(this.m_lblProfileSampleRate);
			this.m_grpProfile.Controls.Add(this.m_lblProfileRxGain);
			this.m_grpProfile.Controls.Add(this.m_cboProfileHpf2);
			this.m_grpProfile.Controls.Add(this.m_lblProfileHpf2);
			this.m_grpProfile.Controls.Add(this.m_cboProfileHpf1);
			this.m_grpProfile.Controls.Add(this.m_lblProfileHpf1);
			this.m_grpProfile.Controls.Add(this.m_nudProfileProfileId);
			this.m_grpProfile.Controls.Add(this.m_lblProfileProfileId);
			this.m_grpProfile.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.m_grpProfile.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_grpProfile.Location = new global::System.Drawing.Point(14, 0);
			this.m_grpProfile.Name = "m_grpProfile";
			this.m_grpProfile.Size = new global::System.Drawing.Size(591, 377);
			this.m_grpProfile.TabIndex = 13;
			this.m_grpProfile.TabStop = false;
			this.m_grpProfile.Text = "Profile";
			this.m_nudTx1OutPowerBackoffCode.Enabled = false;
			this.m_nudTx1OutPowerBackoffCode.Location = new global::System.Drawing.Point(470, 84);
			global::System.Windows.Forms.NumericUpDown nudTx1OutPowerBackoffCode = this.m_nudTx1OutPowerBackoffCode;
			int[] array = new int[4];
			array[0] = 30;
			nudTx1OutPowerBackoffCode.Maximum = new decimal(array);
			this.m_nudTx1OutPowerBackoffCode.Name = "m_nudTx1OutPowerBackoffCode";
			this.m_nudTx1OutPowerBackoffCode.Size = new global::System.Drawing.Size(107, 21);
			this.m_nudTx1OutPowerBackoffCode.TabIndex = 6;
			this.m_nudTx2OutPowerBackoffCode.Enabled = false;
			this.m_nudTx2OutPowerBackoffCode.Location = new global::System.Drawing.Point(470, 114);
			global::System.Windows.Forms.NumericUpDown nudTx2OutPowerBackoffCode = this.m_nudTx2OutPowerBackoffCode;
			int[] array2 = new int[4];
			array2[0] = 30;
			nudTx2OutPowerBackoffCode.Maximum = new decimal(array2);
			this.m_nudTx2OutPowerBackoffCode.Name = "m_nudTx2OutPowerBackoffCode";
			this.m_nudTx2OutPowerBackoffCode.Size = new global::System.Drawing.Size(107, 21);
			this.m_nudTx2OutPowerBackoffCode.TabIndex = 8;
			this.m_lblProfileTx1OpPwrBackoff.AutoSize = true;
			this.m_lblProfileTx1OpPwrBackoff.Location = new global::System.Drawing.Point(306, 89);
			this.m_lblProfileTx1OpPwrBackoff.Name = "m_lblProfileTx1OpPwrBackoff";
			this.m_lblProfileTx1OpPwrBackoff.Size = new global::System.Drawing.Size(143, 15);
			this.m_lblProfileTx1OpPwrBackoff.TabIndex = 52;
			this.m_lblProfileTx1OpPwrBackoff.Text = "O/p Pwr Backoff TX0 (dB)";
			this.m_lblProfileTx2OpPwrBackoff.AutoSize = true;
			this.m_lblProfileTx2OpPwrBackoff.Location = new global::System.Drawing.Point(306, 118);
			this.m_lblProfileTx2OpPwrBackoff.Name = "m_lblProfileTx2OpPwrBackoff";
			this.m_lblProfileTx2OpPwrBackoff.Size = new global::System.Drawing.Size(143, 15);
			this.m_lblProfileTx2OpPwrBackoff.TabIndex = 51;
			this.m_lblProfileTx2OpPwrBackoff.Text = "O/p Pwr Backoff TX1 (dB)";
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new global::System.Drawing.Point(320, 351);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new global::System.Drawing.Size(70, 19);
			this.radioButton4.TabIndex = 22;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Profile 3";
			this.radioButton4.UseVisualStyleBackColor = true;
			this.radioButton4.CheckedChanged += new global::System.EventHandler(this.radioButton4_CheckedChanged);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(306, 237);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(137, 15);
			this.label2.TabIndex = 50;
			this.label2.Text = "Phase Shifter TX2 (deg)";
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new global::System.Drawing.Point(212, 351);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new global::System.Drawing.Size(70, 19);
			this.radioButton3.TabIndex = 21;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Profile 2";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.CheckedChanged += new global::System.EventHandler(this.radioButton3_CheckedChanged);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(306, 208);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(137, 15);
			this.label1.TabIndex = 49;
			this.label1.Text = "Phase Shifter TX1 (deg)";
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new global::System.Drawing.Point(106, 351);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new global::System.Drawing.Size(70, 19);
			this.radioButton2.TabIndex = 20;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Profile 1";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new global::System.EventHandler(this.radioButton2_CheckedChanged);
			this.m_nudTx3PhaseShifter.DecimalPlaces = 1;
			this.m_nudTx3PhaseShifter.Enabled = false;
			this.m_nudTx3PhaseShifter.Location = new global::System.Drawing.Point(470, 234);
			global::System.Windows.Forms.NumericUpDown nudTx3PhaseShifter = this.m_nudTx3PhaseShifter;
			int[] array3 = new int[4];
			array3[0] = 360;
			nudTx3PhaseShifter.Maximum = new decimal(array3);
			this.m_nudTx3PhaseShifter.Name = "m_nudTx3PhaseShifter";
			this.m_nudTx3PhaseShifter.Size = new global::System.Drawing.Size(107, 21);
			this.m_nudTx3PhaseShifter.TabIndex = 16;
			this.m_nudTx3PhaseShifter.ValueChanged += new global::System.EventHandler(this.ChirpMngrTx3PhaseShifter_ValueChanged);
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new global::System.Drawing.Point(13, 351);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new global::System.Drawing.Size(70, 19);
			this.radioButton1.TabIndex = 19;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Profile 0";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new global::System.EventHandler(this.radioButton1_CheckedChanged);
			this.m_nudTx2PhaseShifter.DecimalPlaces = 1;
			this.m_nudTx2PhaseShifter.Enabled = false;
			this.m_nudTx2PhaseShifter.Location = new global::System.Drawing.Point(470, 204);
			global::System.Windows.Forms.NumericUpDown nudTx2PhaseShifter = this.m_nudTx2PhaseShifter;
			int[] array4 = new int[4];
			array4[0] = 360;
			nudTx2PhaseShifter.Maximum = new decimal(array4);
			this.m_nudTx2PhaseShifter.Name = "m_nudTx2PhaseShifter";
			this.m_nudTx2PhaseShifter.Size = new global::System.Drawing.Size(107, 21);
			this.m_nudTx2PhaseShifter.TabIndex = 14;
			this.m_nudTx2PhaseShifter.ValueChanged += new global::System.EventHandler(this.ChirpMngrTx2PhaseShifter_ValueChanged);
			this.m_nudProfileRxGain.Enabled = false;
			global::System.Windows.Forms.NumericUpDown nudProfileRxGain = this.m_nudProfileRxGain;
			int[] array5 = new int[4];
			array5[0] = 2;
			nudProfileRxGain.Increment = new decimal(array5);
			this.m_nudProfileRxGain.Location = new global::System.Drawing.Point(178, 292);
			global::System.Windows.Forms.NumericUpDown nudProfileRxGain2 = this.m_nudProfileRxGain;
			int[] array6 = new int[4];
			array6[0] = 54;
			nudProfileRxGain2.Maximum = new decimal(array6);
			global::System.Windows.Forms.NumericUpDown nudProfileRxGain3 = this.m_nudProfileRxGain;
			int[] array7 = new int[4];
			array7[0] = 24;
			nudProfileRxGain3.Minimum = new decimal(array7);
			this.m_nudProfileRxGain.Name = "m_nudProfileRxGain";
			this.m_nudProfileRxGain.Size = new global::System.Drawing.Size(94, 21);
			this.m_nudProfileRxGain.TabIndex = 18;
			global::System.Windows.Forms.NumericUpDown nudProfileRxGain4 = this.m_nudProfileRxGain;
			int[] array8 = new int[4];
			array8[0] = 30;
			nudProfileRxGain4.Value = new decimal(array8);
			this.m_nudProfileRxGain.ValueChanged += new global::System.EventHandler(this.ChirpMngrProfileRxGain_ValueChanged_1);
			this.m_nudTxStartTime.DecimalPlaces = 2;
			this.m_nudTxStartTime.Enabled = false;
			this.m_nudTxStartTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudTxStartTime.Location = new global::System.Drawing.Point(178, 144);
			global::System.Windows.Forms.NumericUpDown nudTxStartTime = this.m_nudTxStartTime;
			int[] array9 = new int[4];
			array9[0] = 40;
			nudTxStartTime.Maximum = new decimal(array9);
			this.m_nudTxStartTime.Minimum = new decimal(new int[]
			{
				40,
				0,
				0,
				int.MinValue
			});
			this.m_nudTxStartTime.Name = "m_nudTxStartTime";
			this.m_nudTxStartTime.Size = new global::System.Drawing.Size(94, 21);
			this.m_nudTxStartTime.TabIndex = 9;
			this.m_nudTxStartTime.Value = new decimal(new int[]
			{
				10,
				0,
				0,
				65536
			});
			this.m_nudTxStartTime.ValueChanged += new global::System.EventHandler(this.ChirpMngrTxStartTime_ValueChanged);
			this.m_lblProfileTxStartTime.AutoSize = true;
			this.m_lblProfileTxStartTime.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileTxStartTime.Location = new global::System.Drawing.Point(7, 147);
			this.m_lblProfileTxStartTime.Name = "m_lblProfileTxStartTime";
			this.m_lblProfileTxStartTime.Size = new global::System.Drawing.Size(105, 15);
			this.m_lblProfileTxStartTime.TabIndex = 44;
			this.m_lblProfileTxStartTime.Text = "TX Start Time (µs)";
			this.m_nudFreqSlopeConst.DecimalPlaces = 3;
			this.m_nudFreqSlopeConst.Enabled = false;
			this.m_nudFreqSlopeConst.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudFreqSlopeConst.Location = new global::System.Drawing.Point(178, 82);
			global::System.Windows.Forms.NumericUpDown nudFreqSlopeConst = this.m_nudFreqSlopeConst;
			int[] array10 = new int[4];
			array10[0] = 327;
			nudFreqSlopeConst.Maximum = new decimal(array10);
			this.m_nudFreqSlopeConst.Minimum = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudFreqSlopeConst.Name = "m_nudFreqSlopeConst";
			this.m_nudFreqSlopeConst.Size = new global::System.Drawing.Size(94, 21);
			this.m_nudFreqSlopeConst.TabIndex = 5;
			global::System.Windows.Forms.NumericUpDown nudFreqSlopeConst2 = this.m_nudFreqSlopeConst;
			int[] array11 = new int[4];
			array11[0] = 30;
			nudFreqSlopeConst2.Value = new decimal(array11);
			this.m_nudFreqSlopeConst.ValueChanged += new global::System.EventHandler(this.ChirpMngrFreqSlopeConst_ValueChanged);
			this.m_lblProfileFreqSlope.AutoSize = true;
			this.m_lblProfileFreqSlope.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileFreqSlope.Location = new global::System.Drawing.Point(7, 85);
			this.m_lblProfileFreqSlope.Name = "m_lblProfileFreqSlope";
			this.m_lblProfileFreqSlope.Size = new global::System.Drawing.Size(150, 15);
			this.m_lblProfileFreqSlope.TabIndex = 42;
			this.m_lblProfileFreqSlope.Text = "Frequency Slope (MHz/µs)";
			this.m_nudTx1PhaseShifter.DecimalPlaces = 1;
			this.m_nudTx1PhaseShifter.Enabled = false;
			this.m_nudTx1PhaseShifter.Location = new global::System.Drawing.Point(470, 174);
			global::System.Windows.Forms.NumericUpDown nudTx1PhaseShifter = this.m_nudTx1PhaseShifter;
			int[] array12 = new int[4];
			array12[0] = 360;
			nudTx1PhaseShifter.Maximum = new decimal(array12);
			this.m_nudTx1PhaseShifter.Name = "m_nudTx1PhaseShifter";
			this.m_nudTx1PhaseShifter.Size = new global::System.Drawing.Size(107, 21);
			this.m_nudTx1PhaseShifter.TabIndex = 12;
			this.m_nudTx1PhaseShifter.VisibleChanged += new global::System.EventHandler(this.ChirpMngrTx1PhaseShifter_ValueChanged);
			this.m_lblProfilePhaseShifter.AutoSize = true;
			this.m_lblProfilePhaseShifter.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfilePhaseShifter.Location = new global::System.Drawing.Point(306, 179);
			this.m_lblProfilePhaseShifter.Name = "m_lblProfilePhaseShifter";
			this.m_lblProfilePhaseShifter.Size = new global::System.Drawing.Size(137, 15);
			this.m_lblProfilePhaseShifter.TabIndex = 40;
			this.m_lblProfilePhaseShifter.Text = "Phase Shifter TX0 (deg)";
			this.m_nudTx3OutPowerBackoffCode.Enabled = false;
			this.m_nudTx3OutPowerBackoffCode.Location = new global::System.Drawing.Point(470, 144);
			global::System.Windows.Forms.NumericUpDown nudTx3OutPowerBackoffCode = this.m_nudTx3OutPowerBackoffCode;
			int[] array13 = new int[4];
			array13[0] = 30;
			nudTx3OutPowerBackoffCode.Maximum = new decimal(array13);
			this.m_nudTx3OutPowerBackoffCode.Name = "m_nudTx3OutPowerBackoffCode";
			this.m_nudTx3OutPowerBackoffCode.Size = new global::System.Drawing.Size(107, 21);
			this.m_nudTx3OutPowerBackoffCode.TabIndex = 10;
			this.m_lblProfileTx3OpPwrBackoff.AutoSize = true;
			this.m_lblProfileTx3OpPwrBackoff.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileTx3OpPwrBackoff.Location = new global::System.Drawing.Point(306, 148);
			this.m_lblProfileTx3OpPwrBackoff.Name = "m_lblProfileTx3OpPwrBackoff";
			this.m_lblProfileTx3OpPwrBackoff.Size = new global::System.Drawing.Size(143, 15);
			this.m_lblProfileTx3OpPwrBackoff.TabIndex = 38;
			this.m_lblProfileTx3OpPwrBackoff.Text = "O/p Pwr Backoff TX2 (dB)";
			this.m_nudStartFreqConst.DecimalPlaces = 6;
			this.m_nudStartFreqConst.Enabled = false;
			this.m_nudStartFreqConst.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				393216
			});
			this.m_nudStartFreqConst.Location = new global::System.Drawing.Point(178, 50);
			global::System.Windows.Forms.NumericUpDown nudStartFreqConst = this.m_nudStartFreqConst;
			int[] array14 = new int[4];
			array14[0] = 81;
			nudStartFreqConst.Maximum = new decimal(array14);
			this.m_nudStartFreqConst.Name = "m_nudStartFreqConst";
			this.m_nudStartFreqConst.Size = new global::System.Drawing.Size(94, 21);
			this.m_nudStartFreqConst.TabIndex = 3;
			this.m_nudStartFreqConst.Value = new decimal(new int[]
			{
				760,
				0,
				0,
				65536
			});
			this.m_nudStartFreqConst.ValueChanged += new global::System.EventHandler(this.ChirpMangrStartFreqConst_ValueChanged);
			this.m_lblProfileStartFreqConst.AutoSize = true;
			this.m_lblProfileStartFreqConst.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileStartFreqConst.Location = new global::System.Drawing.Point(7, 56);
			this.m_lblProfileStartFreqConst.Name = "m_lblProfileStartFreqConst";
			this.m_lblProfileStartFreqConst.Size = new global::System.Drawing.Size(94, 15);
			this.m_lblProfileStartFreqConst.TabIndex = 36;
			this.m_lblProfileStartFreqConst.Text = "Start Freq (GHz)";
			this.m_nudRampEndTime.DecimalPlaces = 2;
			this.m_nudRampEndTime.Enabled = false;
			this.m_nudRampEndTime.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudRampEndTime.Location = new global::System.Drawing.Point(178, 261);
			global::System.Windows.Forms.NumericUpDown nudRampEndTime = this.m_nudRampEndTime;
			int[] array15 = new int[4];
			array15[0] = 5000;
			nudRampEndTime.Maximum = new decimal(array15);
			this.m_nudRampEndTime.Name = "m_nudRampEndTime";
			this.m_nudRampEndTime.Size = new global::System.Drawing.Size(94, 21);
			this.m_nudRampEndTime.TabIndex = 17;
			this.m_nudRampEndTime.Value = new decimal(new int[]
			{
				3,
				0,
				0,
				65536
			});
			this.m_nudRampEndTime.ValueChanged += new global::System.EventHandler(this.ChirpMngrRampEndTime_ValueChanged);
			this.m_lblProfileRampEndTime.AutoSize = true;
			this.m_lblProfileRampEndTime.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileRampEndTime.Location = new global::System.Drawing.Point(9, 267);
			this.m_lblProfileRampEndTime.Name = "m_lblProfileRampEndTime";
			this.m_lblProfileRampEndTime.Size = new global::System.Drawing.Size(122, 15);
			this.m_lblProfileRampEndTime.TabIndex = 34;
			this.m_lblProfileRampEndTime.Text = "Ramp End Time (µs)";
			this.m_nudIdleTimeConst.DecimalPlaces = 2;
			this.m_nudIdleTimeConst.Enabled = false;
			this.m_nudIdleTimeConst.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudIdleTimeConst.Location = new global::System.Drawing.Point(178, 113);
			this.m_nudIdleTimeConst.Maximum = new decimal(new int[]
			{
				524287,
				0,
				0,
				131072
			});
			this.m_nudIdleTimeConst.Name = "m_nudIdleTimeConst";
			this.m_nudIdleTimeConst.Size = new global::System.Drawing.Size(94, 21);
			this.m_nudIdleTimeConst.TabIndex = 7;
			global::System.Windows.Forms.NumericUpDown nudIdleTimeConst = this.m_nudIdleTimeConst;
			int[] array16 = new int[4];
			array16[0] = 1;
			nudIdleTimeConst.Value = new decimal(array16);
			this.m_nudIdleTimeConst.ValueChanged += new global::System.EventHandler(this.ChirpMngrIdleTimeConst_ValueChanged);
			this.m_lblProfileIdleTime.AutoSize = true;
			this.m_lblProfileIdleTime.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileIdleTime.Location = new global::System.Drawing.Point(7, 117);
			this.m_lblProfileIdleTime.Name = "m_lblProfileIdleTime";
			this.m_lblProfileIdleTime.Size = new global::System.Drawing.Size(83, 15);
			this.m_lblProfileIdleTime.TabIndex = 32;
			this.m_lblProfileIdleTime.Text = "Idle Time (µs)";
			this.m_nudAdcStartTimeConst.DecimalPlaces = 2;
			this.m_nudAdcStartTimeConst.Enabled = false;
			this.m_nudAdcStartTimeConst.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudAdcStartTimeConst.Location = new global::System.Drawing.Point(178, 174);
			global::System.Windows.Forms.NumericUpDown nudAdcStartTimeConst = this.m_nudAdcStartTimeConst;
			int[] array17 = new int[4];
			array17[0] = 5000;
			nudAdcStartTimeConst.Maximum = new decimal(array17);
			this.m_nudAdcStartTimeConst.Name = "m_nudAdcStartTimeConst";
			this.m_nudAdcStartTimeConst.Size = new global::System.Drawing.Size(94, 21);
			this.m_nudAdcStartTimeConst.TabIndex = 11;
			global::System.Windows.Forms.NumericUpDown nudAdcStartTimeConst2 = this.m_nudAdcStartTimeConst;
			int[] array18 = new int[4];
			array18[0] = 3;
			nudAdcStartTimeConst2.Value = new decimal(array18);
			this.m_nudAdcStartTimeConst.ValueChanged += new global::System.EventHandler(this.ChirpMngrAdcStartTimeConst_ValueChanged);
			this.m_lblProfileAdcStartTime.AutoSize = true;
			this.m_lblProfileAdcStartTime.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileAdcStartTime.Location = new global::System.Drawing.Point(7, 179);
			this.m_lblProfileAdcStartTime.Name = "m_lblProfileAdcStartTime";
			this.m_lblProfileAdcStartTime.Size = new global::System.Drawing.Size(116, 15);
			this.m_lblProfileAdcStartTime.TabIndex = 30;
			this.m_lblProfileAdcStartTime.Text = "ADC Start Time (µs)";
			this.m_nudNumAdcSamples.Enabled = false;
			this.m_nudNumAdcSamples.Location = new global::System.Drawing.Point(178, 203);
			global::System.Windows.Forms.NumericUpDown nudNumAdcSamples = this.m_nudNumAdcSamples;
			int[] array19 = new int[4];
			array19[0] = 4096;
			nudNumAdcSamples.Maximum = new decimal(array19);
			global::System.Windows.Forms.NumericUpDown nudNumAdcSamples2 = this.m_nudNumAdcSamples;
			int[] array20 = new int[4];
			array20[0] = 64;
			nudNumAdcSamples2.Minimum = new decimal(array20);
			this.m_nudNumAdcSamples.Name = "m_nudNumAdcSamples";
			this.m_nudNumAdcSamples.Size = new global::System.Drawing.Size(94, 21);
			this.m_nudNumAdcSamples.TabIndex = 13;
			global::System.Windows.Forms.NumericUpDown nudNumAdcSamples3 = this.m_nudNumAdcSamples;
			int[] array21 = new int[4];
			array21[0] = 256;
			nudNumAdcSamples3.Value = new decimal(array21);
			this.m_lblProfileAdcSamples.AutoSize = true;
			this.m_lblProfileAdcSamples.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileAdcSamples.Location = new global::System.Drawing.Point(7, 205);
			this.m_lblProfileAdcSamples.Name = "m_lblProfileAdcSamples";
			this.m_lblProfileAdcSamples.Size = new global::System.Drawing.Size(85, 15);
			this.m_lblProfileAdcSamples.TabIndex = 28;
			this.m_lblProfileAdcSamples.Text = "ADC Samples";
			this.m_nudDigOutSampleRate.Enabled = false;
			this.m_nudDigOutSampleRate.Location = new global::System.Drawing.Point(178, 231);
			global::System.Windows.Forms.NumericUpDown nudDigOutSampleRate = this.m_nudDigOutSampleRate;
			int[] array22 = new int[4];
			array22[0] = 375000;
			nudDigOutSampleRate.Maximum = new decimal(array22);
			this.m_nudDigOutSampleRate.Name = "m_nudDigOutSampleRate";
			this.m_nudDigOutSampleRate.Size = new global::System.Drawing.Size(94, 21);
			this.m_nudDigOutSampleRate.TabIndex = 15;
			global::System.Windows.Forms.NumericUpDown nudDigOutSampleRate2 = this.m_nudDigOutSampleRate;
			int[] array23 = new int[4];
			array23[0] = 10000;
			nudDigOutSampleRate2.Value = new decimal(array23);
			this.m_lblProfileSampleRate.AutoSize = true;
			this.m_lblProfileSampleRate.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileSampleRate.Location = new global::System.Drawing.Point(7, 233);
			this.m_lblProfileSampleRate.Name = "m_lblProfileSampleRate";
			this.m_lblProfileSampleRate.Size = new global::System.Drawing.Size(117, 15);
			this.m_lblProfileSampleRate.TabIndex = 26;
			this.m_lblProfileSampleRate.Text = "Sample Rate (ksps)";
			this.m_lblProfileRxGain.AutoSize = true;
			this.m_lblProfileRxGain.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileRxGain.Location = new global::System.Drawing.Point(9, 299);
			this.m_lblProfileRxGain.Name = "m_lblProfileRxGain";
			this.m_lblProfileRxGain.Size = new global::System.Drawing.Size(78, 15);
			this.m_lblProfileRxGain.TabIndex = 24;
			this.m_lblProfileRxGain.Text = "RX Gain (dB)";
			this.m_cboProfileHpf2.DisplayMember = "0";
			this.m_cboProfileHpf2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboProfileHpf2.Enabled = false;
			this.m_cboProfileHpf2.FormattingEnabled = true;
			this.m_cboProfileHpf2.Items.AddRange(new object[]
			{
				"350K",
				"700K",
				"1.4M",
				"2.8M"
			});
			this.m_cboProfileHpf2.Location = new global::System.Drawing.Point(470, 50);
			this.m_cboProfileHpf2.Name = "m_cboProfileHpf2";
			this.m_cboProfileHpf2.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.m_cboProfileHpf2.Size = new global::System.Drawing.Size(107, 23);
			this.m_cboProfileHpf2.TabIndex = 4;
			this.m_lblProfileHpf2.AutoSize = true;
			this.m_lblProfileHpf2.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileHpf2.Location = new global::System.Drawing.Point(306, 55);
			this.m_lblProfileHpf2.Name = "m_lblProfileHpf2";
			this.m_lblProfileHpf2.Size = new global::System.Drawing.Size(107, 15);
			this.m_lblProfileHpf2.TabIndex = 22;
			this.m_lblProfileHpf2.Text = "HPF2 Corner Freq";
			this.m_cboProfileHpf1.DisplayMember = "0";
			this.m_cboProfileHpf1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboProfileHpf1.Enabled = false;
			this.m_cboProfileHpf1.FormattingEnabled = true;
			this.m_cboProfileHpf1.Items.AddRange(new object[]
			{
				"175K",
				"235K",
				"350K",
				"700K"
			});
			this.m_cboProfileHpf1.Location = new global::System.Drawing.Point(470, 16);
			this.m_cboProfileHpf1.Name = "m_cboProfileHpf1";
			this.m_cboProfileHpf1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.m_cboProfileHpf1.Size = new global::System.Drawing.Size(107, 23);
			this.m_cboProfileHpf1.TabIndex = 2;
			this.m_lblProfileHpf1.AutoSize = true;
			this.m_lblProfileHpf1.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileHpf1.Location = new global::System.Drawing.Point(306, 20);
			this.m_lblProfileHpf1.Name = "m_lblProfileHpf1";
			this.m_lblProfileHpf1.Size = new global::System.Drawing.Size(107, 15);
			this.m_lblProfileHpf1.TabIndex = 20;
			this.m_lblProfileHpf1.Text = "HPF1 Corner Freq";
			this.m_nudProfileProfileId.Enabled = false;
			this.m_nudProfileProfileId.Location = new global::System.Drawing.Point(178, 18);
			global::System.Windows.Forms.NumericUpDown nudProfileProfileId = this.m_nudProfileProfileId;
			int[] array24 = new int[4];
			array24[0] = 15;
			nudProfileProfileId.Maximum = new decimal(array24);
			this.m_nudProfileProfileId.Name = "m_nudProfileProfileId";
			this.m_nudProfileProfileId.Size = new global::System.Drawing.Size(94, 21);
			this.m_nudProfileProfileId.TabIndex = 1;
			this.m_lblProfileProfileId.AutoSize = true;
			this.m_lblProfileProfileId.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_lblProfileProfileId.Location = new global::System.Drawing.Point(7, 24);
			this.m_lblProfileProfileId.Name = "m_lblProfileProfileId";
			this.m_lblProfileProfileId.Size = new global::System.Drawing.Size(55, 15);
			this.m_lblProfileProfileId.TabIndex = 2;
			this.m_lblProfileProfileId.Text = "Profile Id";
			this.m_cboADCDataFileChirpConfig.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cboADCDataFileChirpConfig.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cboADCDataFileChirpConfig.FormattingEnabled = true;
			this.m_cboADCDataFileChirpConfig.Location = new global::System.Drawing.Point(14, 387);
			this.m_cboADCDataFileChirpConfig.Name = "m_cboADCDataFileChirpConfig";
			this.m_cboADCDataFileChirpConfig.Size = new global::System.Drawing.Size(413, 23);
			this.m_cboADCDataFileChirpConfig.TabIndex = 29;
			this.m_cboADCDataFileChirpConfig.Text = "C:\\RadarStudio\\Clients\\AR1xController\\ChirpConfigData.csv";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(10, 325);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(89, 15);
			this.label3.TabIndex = 53;
			this.label3.Text = "RF Gain Target";
			this.m_cboProfileRFGainTargetMnger.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboProfileRFGainTargetMnger.FormattingEnabled = true;
			this.m_cboProfileRFGainTargetMnger.Items.AddRange(new object[]
			{
				"30dB",
				"34dB",
				"26dB"
			});
			this.m_cboProfileRFGainTargetMnger.Location = new global::System.Drawing.Point(178, 319);
			this.m_cboProfileRFGainTargetMnger.Name = "m_cboProfileRFGainTargetMnger";
			this.m_cboProfileRFGainTargetMnger.Size = new global::System.Drawing.Size(94, 23);
			this.m_cboProfileRFGainTargetMnger.TabIndex = 55;
			this.m_cboChripMngrProfileVCOSelect.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboChripMngrProfileVCOSelect.FormattingEnabled = true;
			this.m_cboChripMngrProfileVCOSelect.Items.AddRange(new object[]
			{
				"VCO1",
				"VCO2"
			});
			this.m_cboChripMngrProfileVCOSelect.Location = new global::System.Drawing.Point(470, 262);
			this.m_cboChripMngrProfileVCOSelect.Name = "m_cboChripMngrProfileVCOSelect";
			this.m_cboChripMngrProfileVCOSelect.Size = new global::System.Drawing.Size(107, 23);
			this.m_cboChripMngrProfileVCOSelect.TabIndex = 56;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(309, 268);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(69, 15);
			this.label4.TabIndex = 57;
			this.label4.Text = "VCO Select";
			this.m_chbChirpMngProfileForceVCOSelect.AutoSize = true;
			this.m_chbChirpMngProfileForceVCOSelect.Location = new global::System.Drawing.Point(470, 296);
			this.m_chbChirpMngProfileForceVCOSelect.Name = "m_chbChirpMngProfileForceVCOSelect";
			this.m_chbChirpMngProfileForceVCOSelect.Size = new global::System.Drawing.Size(122, 19);
			this.m_chbChirpMngProfileForceVCOSelect.TabIndex = 58;
			this.m_chbChirpMngProfileForceVCOSelect.Text = "Force VCO Select";
			this.m_chbChirpMngProfileForceVCOSelect.UseVisualStyleBackColor = true;
			this.m_chbChirpMngrProfileRetainTxCalLUT.AutoSize = true;
			this.m_chbChirpMngrProfileRetainTxCalLUT.Location = new global::System.Drawing.Point(470, 325);
			this.m_chbChirpMngrProfileRetainTxCalLUT.Name = "m_chbChirpMngrProfileRetainTxCalLUT";
			this.m_chbChirpMngrProfileRetainTxCalLUT.Size = new global::System.Drawing.Size(116, 19);
			this.m_chbChirpMngrProfileRetainTxCalLUT.TabIndex = 59;
			this.m_chbChirpMngrProfileRetainTxCalLUT.Text = "RetainTxCalLUT";
			this.m_chbChirpMngrProfileRetainTxCalLUT.UseVisualStyleBackColor = true;
			this.m_chbChirpMngrProfileRetainRxCalLUT.AutoSize = true;
			this.m_chbChirpMngrProfileRetainRxCalLUT.Location = new global::System.Drawing.Point(470, 351);
			this.m_chbChirpMngrProfileRetainRxCalLUT.Name = "m_chbChirpMngrProfileRetainRxCalLUT";
			this.m_chbChirpMngrProfileRetainRxCalLUT.Size = new global::System.Drawing.Size(118, 19);
			this.m_chbChirpMngrProfileRetainRxCalLUT.TabIndex = 60;
			this.m_chbChirpMngrProfileRetainRxCalLUT.Text = "RetainRxCalLUT";
			this.m_chbChirpMngrProfileRetainRxCalLUT.UseVisualStyleBackColor = true;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(312, 325);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(105, 15);
			this.label5.TabIndex = 61;
			this.label5.Text = "Calib LUT Update";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new global::System.Drawing.Size(1202, 726);
			base.Controls.Add(this.m_cboADCDataFileChirpConfig);
			base.Controls.Add(this.m_grpProfile);
			base.Controls.Add(this.m_btnActivate);
			base.Controls.Add(this.m_btnSave);
			base.Controls.Add(this.m_btnLoad);
			base.Controls.Add(this.m_btnBrowse);
			base.Controls.Add(this.dataGridView1);
			this.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Name = "ChirpManager";
			this.Text = "ChirpManager";
			base.Load += new global::System.EventHandler(this.ChirpManager_Load);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
			this.m_grpProfile.ResumeLayout(false);
			this.m_grpProfile.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx1OutPowerBackoffCode).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx2OutPowerBackoffCode).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx3PhaseShifter).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx2PhaseShifter).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudProfileRxGain).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTxStartTime).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudFreqSlopeConst).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx1PhaseShifter).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudTx3OutPowerBackoffCode).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudStartFreqConst).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudRampEndTime).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudIdleTimeConst).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudAdcStartTimeConst).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudNumAdcSamples).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudDigOutSampleRate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.m_nudProfileProfileId).EndInit();
			base.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.DataGridView dataGridView1;

		private global::System.Windows.Forms.OpenFileDialog openFileDialog1;

		private global::System.Windows.Forms.Button m_btnBrowse;

		private global::System.Windows.Forms.Button m_btnLoad;

		private global::System.Windows.Forms.Button m_btnSave;

		private global::System.Windows.Forms.Button m_btnActivate;

		private global::System.Windows.Forms.GroupBox m_grpProfile;

		private global::System.Windows.Forms.RadioButton radioButton4;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.RadioButton radioButton3;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.RadioButton radioButton2;

		private global::System.Windows.Forms.NumericUpDown m_nudTx3PhaseShifter;

		private global::System.Windows.Forms.RadioButton radioButton1;

		private global::System.Windows.Forms.NumericUpDown m_nudTx2PhaseShifter;

		private global::System.Windows.Forms.NumericUpDown m_nudProfileRxGain;

		private global::System.Windows.Forms.NumericUpDown m_nudTxStartTime;

		private global::System.Windows.Forms.Label m_lblProfileTxStartTime;

		private global::System.Windows.Forms.NumericUpDown m_nudFreqSlopeConst;

		private global::System.Windows.Forms.Label m_lblProfileFreqSlope;

		private global::System.Windows.Forms.NumericUpDown m_nudTx1PhaseShifter;

		private global::System.Windows.Forms.Label m_lblProfilePhaseShifter;

		private global::System.Windows.Forms.NumericUpDown m_nudTx3OutPowerBackoffCode;

		private global::System.Windows.Forms.Label m_lblProfileTx3OpPwrBackoff;

		private global::System.Windows.Forms.NumericUpDown m_nudStartFreqConst;

		private global::System.Windows.Forms.Label m_lblProfileStartFreqConst;

		private global::System.Windows.Forms.NumericUpDown m_nudRampEndTime;

		private global::System.Windows.Forms.Label m_lblProfileRampEndTime;

		private global::System.Windows.Forms.NumericUpDown m_nudIdleTimeConst;

		private global::System.Windows.Forms.Label m_lblProfileIdleTime;

		private global::System.Windows.Forms.NumericUpDown m_nudAdcStartTimeConst;

		private global::System.Windows.Forms.Label m_lblProfileAdcStartTime;

		private global::System.Windows.Forms.NumericUpDown m_nudNumAdcSamples;

		private global::System.Windows.Forms.Label m_lblProfileAdcSamples;

		private global::System.Windows.Forms.NumericUpDown m_nudDigOutSampleRate;

		private global::System.Windows.Forms.Label m_lblProfileSampleRate;

		private global::System.Windows.Forms.Label m_lblProfileRxGain;

		private global::System.Windows.Forms.ComboBox m_cboProfileHpf2;

		private global::System.Windows.Forms.Label m_lblProfileHpf2;

		private global::System.Windows.Forms.ComboBox m_cboProfileHpf1;

		private global::System.Windows.Forms.Label m_lblProfileHpf1;

		private global::System.Windows.Forms.NumericUpDown m_nudProfileProfileId;

		private global::System.Windows.Forms.Label m_lblProfileProfileId;

		private global::System.Windows.Forms.NumericUpDown m_nudTx1OutPowerBackoffCode;

		private global::System.Windows.Forms.NumericUpDown m_nudTx2OutPowerBackoffCode;

		private global::System.Windows.Forms.Label m_lblProfileTx1OpPwrBackoff;

		private global::System.Windows.Forms.Label m_lblProfileTx2OpPwrBackoff;

		private global::System.Windows.Forms.ComboBox m_cboADCDataFileChirpConfig;

		private global::System.Windows.Forms.Label label3;

		private global::System.Windows.Forms.ComboBox m_cboProfileRFGainTargetMnger;

		private global::System.Windows.Forms.Label label4;

		private global::System.Windows.Forms.ComboBox m_cboChripMngrProfileVCOSelect;

		private global::System.Windows.Forms.Label label5;

		private global::System.Windows.Forms.CheckBox m_chbChirpMngrProfileRetainRxCalLUT;

		private global::System.Windows.Forms.CheckBox m_chbChirpMngrProfileRetainTxCalLUT;

		private global::System.Windows.Forms.CheckBox m_chbChirpMngProfileForceVCOSelect;
	}
}
