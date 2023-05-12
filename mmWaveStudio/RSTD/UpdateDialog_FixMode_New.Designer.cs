namespace RSTD
{

	public partial class UpdateDialog_FixMode_New : global::RSTD.UpdateDialog
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
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.m_txtQNotation = new global::System.Windows.Forms.TextBox();
			this.m_btnAcceptTransmit = new global::System.Windows.Forms.Button();
			this.m_OverflowLabel = new global::System.Windows.Forms.Label();
			this.m_QuantizationLabel = new global::System.Windows.Forms.Label();
			this.m_btnCancel = new global::System.Windows.Forms.Button();
			this.m_btnAccept = new global::System.Windows.Forms.Button();
			this.m_cboOverflow = new global::System.Windows.Forms.ComboBox();
			this.m_QNotationGroupBox = new global::System.Windows.Forms.GroupBox();
			this.m_txtQFraction = new global::System.Windows.Forms.TextBox();
			this.m_txtQInteger = new global::System.Windows.Forms.TextBox();
			this.m_QFractionLabel = new global::System.Windows.Forms.Label();
			this.m_QIntegerLabel = new global::System.Windows.Forms.Label();
			this.m_AttributesGroupBox = new global::System.Windows.Forms.GroupBox();
			this.m_chkLog = new global::System.Windows.Forms.CheckBox();
			this.m_chkSigned = new global::System.Windows.Forms.CheckBox();
			this.m_chkFullPrecision = new global::System.Windows.Forms.CheckBox();
			this.m_cboQuantization = new global::System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.m_QNotationGroupBox.SuspendLayout();
			this.m_AttributesGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.m_txtQNotation);
			this.groupBox1.Location = new global::System.Drawing.Point(10, 120);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(159, 69);
			this.groupBox1.TabIndex = 35;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Q-notation string";
			this.m_txtQNotation.Location = new global::System.Drawing.Point(14, 27);
			this.m_txtQNotation.Name = "m_txtQNotation";
			this.m_txtQNotation.Size = new global::System.Drawing.Size(122, 20);
			this.m_txtQNotation.TabIndex = 0;
			this.m_txtQNotation.TextChanged += new global::System.EventHandler(this.m_txtQNotation_TextChanged);
			this.m_btnAcceptTransmit.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.m_btnAcceptTransmit.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnAcceptTransmit.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.m_btnAcceptTransmit.Location = new global::System.Drawing.Point(163, 208);
			this.m_btnAcceptTransmit.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_btnAcceptTransmit.Name = "m_btnAcceptTransmit";
			this.m_btnAcceptTransmit.Size = new global::System.Drawing.Size(116, 28);
			this.m_btnAcceptTransmit.TabIndex = 34;
			this.m_btnAcceptTransmit.Text = "Accept&&Transmit";
			this.m_btnAcceptTransmit.UseVisualStyleBackColor = true;
			this.m_btnAcceptTransmit.Click += new global::System.EventHandler(this.m_btnAcceptTransmit_Click);
			this.m_OverflowLabel.AutoSize = true;
			this.m_OverflowLabel.Location = new global::System.Drawing.Point(28, 138);
			this.m_OverflowLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_OverflowLabel.Name = "m_OverflowLabel";
			this.m_OverflowLabel.Size = new global::System.Drawing.Size(52, 13);
			this.m_OverflowLabel.TabIndex = 23;
			this.m_OverflowLabel.Text = "Overflow:";
			this.m_QuantizationLabel.AutoSize = true;
			this.m_QuantizationLabel.Location = new global::System.Drawing.Point(28, 110);
			this.m_QuantizationLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_QuantizationLabel.Name = "m_QuantizationLabel";
			this.m_QuantizationLabel.Size = new global::System.Drawing.Size(69, 13);
			this.m_QuantizationLabel.TabIndex = 21;
			this.m_QuantizationLabel.Text = "Quantization:";
			this.m_btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_btnCancel.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new global::System.Drawing.Point(343, 208);
			this.m_btnCancel.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new global::System.Drawing.Size(61, 28);
			this.m_btnCancel.TabIndex = 32;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnAccept.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.m_btnAccept.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnAccept.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.m_btnAccept.Location = new global::System.Drawing.Point(37, 208);
			this.m_btnAccept.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_btnAccept.Name = "m_btnAccept";
			this.m_btnAccept.Size = new global::System.Drawing.Size(61, 28);
			this.m_btnAccept.TabIndex = 33;
			this.m_btnAccept.Text = "Accept";
			this.m_btnAccept.UseVisualStyleBackColor = true;
			this.m_cboOverflow.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboOverflow.FormattingEnabled = true;
			this.m_cboOverflow.Items.AddRange(new object[]
			{
				"ASYMMETRIC_ERROR",
				"SYMMETRIC_ERROR",
				"WRAP",
				"ASYMMETRIC_CLIP",
				"SYMMETRIC_CLIP"
			});
			this.m_cboOverflow.Location = new global::System.Drawing.Point(100, 136);
			this.m_cboOverflow.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_cboOverflow.Name = "m_cboOverflow";
			this.m_cboOverflow.Size = new global::System.Drawing.Size(145, 21);
			this.m_cboOverflow.TabIndex = 22;
			this.m_cboOverflow.SelectionChangeCommitted += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_QNotationGroupBox.Controls.Add(this.m_txtQFraction);
			this.m_QNotationGroupBox.Controls.Add(this.m_txtQInteger);
			this.m_QNotationGroupBox.Controls.Add(this.m_QFractionLabel);
			this.m_QNotationGroupBox.Controls.Add(this.m_QIntegerLabel);
			this.m_QNotationGroupBox.Location = new global::System.Drawing.Point(10, 13);
			this.m_QNotationGroupBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_QNotationGroupBox.Name = "m_QNotationGroupBox";
			this.m_QNotationGroupBox.Padding = new global::System.Windows.Forms.Padding(2);
			this.m_QNotationGroupBox.Size = new global::System.Drawing.Size(159, 96);
			this.m_QNotationGroupBox.TabIndex = 30;
			this.m_QNotationGroupBox.TabStop = false;
			this.m_QNotationGroupBox.Text = "Q Notation:";
			this.m_txtQFraction.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_txtQFraction.Location = new global::System.Drawing.Point(76, 60);
			this.m_txtQFraction.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_txtQFraction.Name = "m_txtQFraction";
			this.m_txtQFraction.Size = new global::System.Drawing.Size(73, 20);
			this.m_txtQFraction.TabIndex = 26;
			this.m_txtQFraction.TextChanged += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_txtQInteger.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_txtQInteger.Location = new global::System.Drawing.Point(76, 35);
			this.m_txtQInteger.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_txtQInteger.Name = "m_txtQInteger";
			this.m_txtQInteger.Size = new global::System.Drawing.Size(73, 20);
			this.m_txtQInteger.TabIndex = 25;
			this.m_txtQInteger.TextChanged += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_QFractionLabel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_QFractionLabel.AutoSize = true;
			this.m_QFractionLabel.Location = new global::System.Drawing.Point(19, 63);
			this.m_QFractionLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_QFractionLabel.Name = "m_QFractionLabel";
			this.m_QFractionLabel.Size = new global::System.Drawing.Size(48, 13);
			this.m_QFractionLabel.TabIndex = 24;
			this.m_QFractionLabel.Text = "Fraction:";
			this.m_QIntegerLabel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_QIntegerLabel.AutoSize = true;
			this.m_QIntegerLabel.Location = new global::System.Drawing.Point(19, 35);
			this.m_QIntegerLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_QIntegerLabel.Name = "m_QIntegerLabel";
			this.m_QIntegerLabel.Size = new global::System.Drawing.Size(43, 13);
			this.m_QIntegerLabel.TabIndex = 23;
			this.m_QIntegerLabel.Text = "Integer:";
			this.m_AttributesGroupBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_AttributesGroupBox.Controls.Add(this.m_chkLog);
			this.m_AttributesGroupBox.Controls.Add(this.m_OverflowLabel);
			this.m_AttributesGroupBox.Controls.Add(this.m_cboOverflow);
			this.m_AttributesGroupBox.Controls.Add(this.m_QuantizationLabel);
			this.m_AttributesGroupBox.Controls.Add(this.m_chkSigned);
			this.m_AttributesGroupBox.Controls.Add(this.m_chkFullPrecision);
			this.m_AttributesGroupBox.Controls.Add(this.m_cboQuantization);
			this.m_AttributesGroupBox.Location = new global::System.Drawing.Point(182, 13);
			this.m_AttributesGroupBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_AttributesGroupBox.Name = "m_AttributesGroupBox";
			this.m_AttributesGroupBox.Padding = new global::System.Windows.Forms.Padding(2);
			this.m_AttributesGroupBox.Size = new global::System.Drawing.Size(263, 176);
			this.m_AttributesGroupBox.TabIndex = 31;
			this.m_AttributesGroupBox.TabStop = false;
			this.m_AttributesGroupBox.Text = "Attributes:";
			this.m_chkLog.AutoSize = true;
			this.m_chkLog.Location = new global::System.Drawing.Point(31, 80);
			this.m_chkLog.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_chkLog.Name = "m_chkLog";
			this.m_chkLog.Size = new global::System.Drawing.Size(44, 17);
			this.m_chkLog.TabIndex = 24;
			this.m_chkLog.Text = "Log";
			this.m_chkLog.UseVisualStyleBackColor = true;
			this.m_chkLog.Click += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_chkSigned.AutoSize = true;
			this.m_chkSigned.Location = new global::System.Drawing.Point(31, 57);
			this.m_chkSigned.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_chkSigned.Name = "m_chkSigned";
			this.m_chkSigned.Size = new global::System.Drawing.Size(59, 17);
			this.m_chkSigned.TabIndex = 19;
			this.m_chkSigned.Text = "Signed";
			this.m_chkSigned.UseVisualStyleBackColor = true;
			this.m_chkSigned.Click += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_chkFullPrecision.AutoSize = true;
			this.m_chkFullPrecision.Location = new global::System.Drawing.Point(31, 35);
			this.m_chkFullPrecision.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_chkFullPrecision.Name = "m_chkFullPrecision";
			this.m_chkFullPrecision.Size = new global::System.Drawing.Size(88, 17);
			this.m_chkFullPrecision.TabIndex = 18;
			this.m_chkFullPrecision.Text = "Full Precision";
			this.m_chkFullPrecision.UseVisualStyleBackColor = true;
			this.m_chkFullPrecision.Click += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			this.m_cboQuantization.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboQuantization.FormattingEnabled = true;
			this.m_cboQuantization.Items.AddRange(new object[]
			{
				"TRUNC",
				"UNBIASED_TRUNC",
				"ROUND",
				"UNBIASED_ROUND"
			});
			this.m_cboQuantization.Location = new global::System.Drawing.Point(100, 107);
			this.m_cboQuantization.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_cboQuantization.Name = "m_cboQuantization";
			this.m_cboQuantization.Size = new global::System.Drawing.Size(145, 21);
			this.m_cboQuantization.TabIndex = 17;
			this.m_cboQuantization.SelectionChangeCommitted += new global::System.EventHandler(this.iQNotationOrAttributesControlChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(455, 248);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.m_btnAcceptTransmit);
			base.Controls.Add(this.m_btnCancel);
			base.Controls.Add(this.m_btnAccept);
			base.Controls.Add(this.m_QNotationGroupBox);
			base.Controls.Add(this.m_AttributesGroupBox);
			base.Name = "UpdateDialog_FixMode_New";
			this.Text = "UpdateDialog - FixMode";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.m_QNotationGroupBox.ResumeLayout(false);
			this.m_QNotationGroupBox.PerformLayout();
			this.m_AttributesGroupBox.ResumeLayout(false);
			this.m_AttributesGroupBox.PerformLayout();
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;
		private global::System.Windows.Forms.GroupBox groupBox1;
		private global::System.Windows.Forms.TextBox m_txtQNotation;
		private global::System.Windows.Forms.Button m_btnAcceptTransmit;
		private global::System.Windows.Forms.Label m_OverflowLabel;
		private global::System.Windows.Forms.Label m_QuantizationLabel;
		private global::System.Windows.Forms.Button m_btnCancel;
		private global::System.Windows.Forms.Button m_btnAccept;
		private global::System.Windows.Forms.ComboBox m_cboOverflow;
		private global::System.Windows.Forms.GroupBox m_QNotationGroupBox;
		private global::System.Windows.Forms.TextBox m_txtQFraction;
		private global::System.Windows.Forms.TextBox m_txtQInteger;
		private global::System.Windows.Forms.Label m_QFractionLabel;
		private global::System.Windows.Forms.Label m_QIntegerLabel;
		private global::System.Windows.Forms.GroupBox m_AttributesGroupBox;
		private global::System.Windows.Forms.CheckBox m_chkSigned;
		private global::System.Windows.Forms.CheckBox m_chkFullPrecision;
		private global::System.Windows.Forms.ComboBox m_cboQuantization;
		private global::System.Windows.Forms.CheckBox m_chkLog;
	}
}
