namespace RSTD
{

	public partial class UpdateDialog_FixMode : global::RSTD.UpdateDialog
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
			this.m_QNotationGroupBox = new global::System.Windows.Forms.GroupBox();
			this.m_QFractionTextBox = new global::System.Windows.Forms.TextBox();
			this.m_QIntegerTextBox = new global::System.Windows.Forms.TextBox();
			this.m_QFractionLabel = new global::System.Windows.Forms.Label();
			this.m_QIntegerLabel = new global::System.Windows.Forms.Label();
			this.m_AttributesGroupBox = new global::System.Windows.Forms.GroupBox();
			this.m_OverflowLabel = new global::System.Windows.Forms.Label();
			this.m_OverflowComboBox = new global::System.Windows.Forms.ComboBox();
			this.m_QuantizationLabel = new global::System.Windows.Forms.Label();
			this.m_SymmetricalCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_SignedCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_FullPrecisionCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_QuantizationComboBox = new global::System.Windows.Forms.ComboBox();
			this.m_CancelBtn = new global::System.Windows.Forms.Button();
			this.m_AcceptBtn = new global::System.Windows.Forms.Button();
			this.m_AcceptTransmitBtn = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.m_QNotationTextBox = new global::System.Windows.Forms.TextBox();
			this.m_QNotationGroupBox.SuspendLayout();
			this.m_AttributesGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.m_QNotationGroupBox.Controls.Add(this.m_QFractionTextBox);
			this.m_QNotationGroupBox.Controls.Add(this.m_QIntegerTextBox);
			this.m_QNotationGroupBox.Controls.Add(this.m_QFractionLabel);
			this.m_QNotationGroupBox.Controls.Add(this.m_QIntegerLabel);
			this.m_QNotationGroupBox.Location = new global::System.Drawing.Point(10, 10);
			this.m_QNotationGroupBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_QNotationGroupBox.Name = "m_QNotationGroupBox";
			this.m_QNotationGroupBox.Padding = new global::System.Windows.Forms.Padding(2);
			this.m_QNotationGroupBox.Size = new global::System.Drawing.Size(159, 96);
			this.m_QNotationGroupBox.TabIndex = 23;
			this.m_QNotationGroupBox.TabStop = false;
			this.m_QNotationGroupBox.Text = "Q Notation:";
			this.m_QFractionTextBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_QFractionTextBox.Location = new global::System.Drawing.Point(76, 60);
			this.m_QFractionTextBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_QFractionTextBox.Name = "m_QFractionTextBox";
			this.m_QFractionTextBox.Size = new global::System.Drawing.Size(73, 20);
			this.m_QFractionTextBox.TabIndex = 26;
			this.m_QFractionTextBox.TextChanged += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_QIntegerTextBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_QIntegerTextBox.Location = new global::System.Drawing.Point(76, 35);
			this.m_QIntegerTextBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_QIntegerTextBox.Name = "m_QIntegerTextBox";
			this.m_QIntegerTextBox.Size = new global::System.Drawing.Size(73, 20);
			this.m_QIntegerTextBox.TabIndex = 25;
			this.m_QIntegerTextBox.TextChanged += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_QFractionLabel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_QFractionLabel.AutoSize = true;
			this.m_QFractionLabel.Location = new global::System.Drawing.Point(19, 63);
			this.m_QFractionLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_QFractionLabel.Name = "m_QFractionLabel";
			this.m_QFractionLabel.Size = new global::System.Drawing.Size(54, 15);
			this.m_QFractionLabel.TabIndex = 24;
			this.m_QFractionLabel.Text = "Fraction:";
			this.m_QIntegerLabel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_QIntegerLabel.AutoSize = true;
			this.m_QIntegerLabel.Location = new global::System.Drawing.Point(19, 35);
			this.m_QIntegerLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_QIntegerLabel.Name = "m_QIntegerLabel";
			this.m_QIntegerLabel.Size = new global::System.Drawing.Size(48, 15);
			this.m_QIntegerLabel.TabIndex = 23;
			this.m_QIntegerLabel.Text = "Integer:";
			this.m_AttributesGroupBox.Controls.Add(this.m_OverflowLabel);
			this.m_AttributesGroupBox.Controls.Add(this.m_OverflowComboBox);
			this.m_AttributesGroupBox.Controls.Add(this.m_QuantizationLabel);
			this.m_AttributesGroupBox.Controls.Add(this.m_SymmetricalCheckBox);
			this.m_AttributesGroupBox.Controls.Add(this.m_SignedCheckBox);
			this.m_AttributesGroupBox.Controls.Add(this.m_FullPrecisionCheckBox);
			this.m_AttributesGroupBox.Controls.Add(this.m_QuantizationComboBox);
			this.m_AttributesGroupBox.Location = new global::System.Drawing.Point(182, 10);
			this.m_AttributesGroupBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_AttributesGroupBox.Name = "m_AttributesGroupBox";
			this.m_AttributesGroupBox.Padding = new global::System.Windows.Forms.Padding(2);
			this.m_AttributesGroupBox.Size = new global::System.Drawing.Size(218, 176);
			this.m_AttributesGroupBox.TabIndex = 24;
			this.m_AttributesGroupBox.TabStop = false;
			this.m_AttributesGroupBox.Text = "Attributes:";
			this.m_OverflowLabel.AutoSize = true;
			this.m_OverflowLabel.Location = new global::System.Drawing.Point(28, 134);
			this.m_OverflowLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_OverflowLabel.Name = "m_OverflowLabel";
			this.m_OverflowLabel.Size = new global::System.Drawing.Size(57, 15);
			this.m_OverflowLabel.TabIndex = 23;
			this.m_OverflowLabel.Text = "Overflow:";
			this.m_OverflowComboBox.FormattingEnabled = true;
			this.m_OverflowComboBox.Items.AddRange(new object[]
			{
				"ERROR",
				"WRAP",
				"CLIP"
			});
			this.m_OverflowComboBox.Location = new global::System.Drawing.Point(110, 132);
			this.m_OverflowComboBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_OverflowComboBox.Name = "m_OverflowComboBox";
			this.m_OverflowComboBox.Size = new global::System.Drawing.Size(92, 21);
			this.m_OverflowComboBox.TabIndex = 22;
			this.m_OverflowComboBox.SelectedIndexChanged += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_OverflowComboBox.TextChanged += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_QuantizationLabel.AutoSize = true;
			this.m_QuantizationLabel.Location = new global::System.Drawing.Point(28, 110);
			this.m_QuantizationLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_QuantizationLabel.Name = "m_QuantizationLabel";
			this.m_QuantizationLabel.Size = new global::System.Drawing.Size(79, 15);
			this.m_QuantizationLabel.TabIndex = 21;
			this.m_QuantizationLabel.Text = "Quantization:";
			this.m_SymmetricalCheckBox.AutoSize = true;
			this.m_SymmetricalCheckBox.Location = new global::System.Drawing.Point(31, 79);
			this.m_SymmetricalCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_SymmetricalCheckBox.Name = "m_SymmetricalCheckBox";
			this.m_SymmetricalCheckBox.Size = new global::System.Drawing.Size(94, 19);
			this.m_SymmetricalCheckBox.TabIndex = 20;
			this.m_SymmetricalCheckBox.Text = "Symmetrical";
			this.m_SymmetricalCheckBox.UseVisualStyleBackColor = true;
			this.m_SymmetricalCheckBox.CheckStateChanged += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_SignedCheckBox.AutoSize = true;
			this.m_SignedCheckBox.Location = new global::System.Drawing.Point(31, 57);
			this.m_SignedCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_SignedCheckBox.Name = "m_SignedCheckBox";
			this.m_SignedCheckBox.Size = new global::System.Drawing.Size(65, 19);
			this.m_SignedCheckBox.TabIndex = 19;
			this.m_SignedCheckBox.Text = "Signed";
			this.m_SignedCheckBox.UseVisualStyleBackColor = true;
			this.m_SignedCheckBox.CheckStateChanged += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_FullPrecisionCheckBox.AutoSize = true;
			this.m_FullPrecisionCheckBox.Location = new global::System.Drawing.Point(31, 35);
			this.m_FullPrecisionCheckBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_FullPrecisionCheckBox.Name = "m_FullPrecisionCheckBox";
			this.m_FullPrecisionCheckBox.Size = new global::System.Drawing.Size(100, 19);
			this.m_FullPrecisionCheckBox.TabIndex = 18;
			this.m_FullPrecisionCheckBox.Text = "Full Precision";
			this.m_FullPrecisionCheckBox.UseVisualStyleBackColor = true;
			this.m_FullPrecisionCheckBox.CheckStateChanged += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_QuantizationComboBox.FormattingEnabled = true;
			this.m_QuantizationComboBox.Items.AddRange(new object[]
			{
				"TRUNC",
				"ROUND",
				"FIX",
				"UNBIASED_ROUND"
			});
			this.m_QuantizationComboBox.Location = new global::System.Drawing.Point(110, 107);
			this.m_QuantizationComboBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_QuantizationComboBox.Name = "m_QuantizationComboBox";
			this.m_QuantizationComboBox.Size = new global::System.Drawing.Size(92, 21);
			this.m_QuantizationComboBox.TabIndex = 17;
			this.m_QuantizationComboBox.SelectedIndexChanged += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_QuantizationComboBox.TextChanged += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_CancelBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_CancelBtn.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_CancelBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.m_CancelBtn.Location = new global::System.Drawing.Point(298, 205);
			this.m_CancelBtn.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_CancelBtn.Name = "m_CancelBtn";
			this.m_CancelBtn.Size = new global::System.Drawing.Size(61, 28);
			this.m_CancelBtn.TabIndex = 25;
			this.m_CancelBtn.Text = "Cancel";
			this.m_CancelBtn.UseVisualStyleBackColor = true;
			this.m_AcceptBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.m_AcceptBtn.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_AcceptBtn.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.m_AcceptBtn.Location = new global::System.Drawing.Point(37, 205);
			this.m_AcceptBtn.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_AcceptBtn.Name = "m_AcceptBtn";
			this.m_AcceptBtn.Size = new global::System.Drawing.Size(61, 28);
			this.m_AcceptBtn.TabIndex = 26;
			this.m_AcceptBtn.Text = "Accept";
			this.m_AcceptBtn.UseVisualStyleBackColor = true;
			this.m_AcceptTransmitBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.m_AcceptTransmitBtn.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_AcceptTransmitBtn.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.m_AcceptTransmitBtn.Location = new global::System.Drawing.Point(140, 205);
			this.m_AcceptTransmitBtn.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_AcceptTransmitBtn.Name = "m_AcceptTransmitBtn";
			this.m_AcceptTransmitBtn.Size = new global::System.Drawing.Size(116, 28);
			this.m_AcceptTransmitBtn.TabIndex = 28;
			this.m_AcceptTransmitBtn.Text = "Accept&&Transmit";
			this.m_AcceptTransmitBtn.UseVisualStyleBackColor = true;
			this.m_AcceptTransmitBtn.Click += new global::System.EventHandler(this.m_AcceptTransmitBtn_Click);
			this.groupBox1.Controls.Add(this.m_QNotationTextBox);
			this.groupBox1.Location = new global::System.Drawing.Point(10, 117);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(159, 69);
			this.groupBox1.TabIndex = 29;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Q-notation string";
			this.m_QNotationTextBox.Location = new global::System.Drawing.Point(22, 27);
			this.m_QNotationTextBox.Name = "m_QNotationTextBox";
			this.m_QNotationTextBox.Size = new global::System.Drawing.Size(113, 20);
			this.m_QNotationTextBox.TabIndex = 0;
			this.m_QNotationTextBox.TextChanged += new global::System.EventHandler(this.iQNotationStringChanges);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(412, 250);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.m_AcceptTransmitBtn);
			base.Controls.Add(this.m_CancelBtn);
			base.Controls.Add(this.m_AcceptBtn);
			base.Controls.Add(this.m_AttributesGroupBox);
			base.Controls.Add(this.m_QNotationGroupBox);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "UpdateDialog_FixMode";
			base.SizeGripStyle = global::System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "UpdateDialog - FixMode";
			this.m_QNotationGroupBox.ResumeLayout(false);
			this.m_QNotationGroupBox.PerformLayout();
			this.m_AttributesGroupBox.ResumeLayout(false);
			this.m_AttributesGroupBox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.GroupBox m_QNotationGroupBox;


		private global::System.Windows.Forms.TextBox m_QFractionTextBox;


		private global::System.Windows.Forms.TextBox m_QIntegerTextBox;


		private global::System.Windows.Forms.Label m_QFractionLabel;


		private global::System.Windows.Forms.Label m_QIntegerLabel;


		private global::System.Windows.Forms.GroupBox m_AttributesGroupBox;


		private global::System.Windows.Forms.Label m_OverflowLabel;


		private global::System.Windows.Forms.ComboBox m_OverflowComboBox;


		private global::System.Windows.Forms.Label m_QuantizationLabel;


		private global::System.Windows.Forms.CheckBox m_SymmetricalCheckBox;


		private global::System.Windows.Forms.CheckBox m_SignedCheckBox;


		private global::System.Windows.Forms.CheckBox m_FullPrecisionCheckBox;


		private global::System.Windows.Forms.ComboBox m_QuantizationComboBox;


		private global::System.Windows.Forms.Button m_CancelBtn;


		private global::System.Windows.Forms.Button m_AcceptBtn;


		private global::System.Windows.Forms.Button m_AcceptTransmitBtn;


		private global::System.Windows.Forms.GroupBox groupBox1;


		private global::System.Windows.Forms.TextBox m_QNotationTextBox;
	}
}
