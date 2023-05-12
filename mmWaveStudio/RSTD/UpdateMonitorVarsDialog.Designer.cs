namespace RSTD
{

	public partial class UpdateMonitorVarsDialog : global::System.Windows.Forms.Form
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
			this.m_VarNameLabel = new global::System.Windows.Forms.Label();
			this.m_VarName = new global::System.Windows.Forms.TextBox();
			this.m_VectorStrideTextBox = new global::System.Windows.Forms.TextBox();
			this.m_StrideLabel = new global::System.Windows.Forms.Label();
			this.m_LengthLabel = new global::System.Windows.Forms.Label();
			this.m_VectorLengthTextBox = new global::System.Windows.Forms.TextBox();
			this.m_ClocksListBox = new global::System.Windows.Forms.ListBox();
			this.m_VectorSettingsGroupBox = new global::System.Windows.Forms.GroupBox();
			this.m_OffsetLabel = new global::System.Windows.Forms.Label();
			this.m_VectorOffsetTextBox = new global::System.Windows.Forms.TextBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.m_AcceptBtn = new global::System.Windows.Forms.Button();
			this.m_CancelBtn = new global::System.Windows.Forms.Button();
			this.m_VectorSettingsGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.m_VarNameLabel.AutoSize = true;
			this.m_VarNameLabel.Location = new global::System.Drawing.Point(9, 13);
			this.m_VarNameLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_VarNameLabel.Name = "m_VarNameLabel";
			this.m_VarNameLabel.Size = new global::System.Drawing.Size(139, 13);
			this.m_VarNameLabel.TabIndex = 0;
			this.m_VarNameLabel.Text = "Monitor settings for variable:";
			this.m_VarName.BackColor = global::System.Drawing.SystemColors.Window;
			this.m_VarName.HideSelection = false;
			this.m_VarName.Location = new global::System.Drawing.Point(9, 29);
			this.m_VarName.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_VarName.Name = "m_VarName";
			this.m_VarName.ReadOnly = true;
			this.m_VarName.Size = new global::System.Drawing.Size(310, 20);
			this.m_VarName.TabIndex = 1;
			this.m_VectorStrideTextBox.Location = new global::System.Drawing.Point(153, 40);
			this.m_VectorStrideTextBox.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_VectorStrideTextBox.Name = "m_VectorStrideTextBox";
			this.m_VectorStrideTextBox.Size = new global::System.Drawing.Size(67, 20);
			this.m_VectorStrideTextBox.TabIndex = 2;
			this.m_StrideLabel.AutoSize = true;
			this.m_StrideLabel.Location = new global::System.Drawing.Point(98, 42);
			this.m_StrideLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_StrideLabel.Name = "m_StrideLabel";
			this.m_StrideLabel.Size = new global::System.Drawing.Size(37, 13);
			this.m_StrideLabel.TabIndex = 4;
			this.m_StrideLabel.Text = "Stride:";
			this.m_LengthLabel.AutoSize = true;
			this.m_LengthLabel.Location = new global::System.Drawing.Point(98, 65);
			this.m_LengthLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_LengthLabel.Name = "m_LengthLabel";
			this.m_LengthLabel.Size = new global::System.Drawing.Size(43, 13);
			this.m_LengthLabel.TabIndex = 5;
			this.m_LengthLabel.Text = "Length:";
			this.m_VectorLengthTextBox.Location = new global::System.Drawing.Point(153, 63);
			this.m_VectorLengthTextBox.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_VectorLengthTextBox.Name = "m_VectorLengthTextBox";
			this.m_VectorLengthTextBox.Size = new global::System.Drawing.Size(67, 20);
			this.m_VectorLengthTextBox.TabIndex = 6;
			this.m_ClocksListBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_ClocksListBox.FormattingEnabled = true;
			this.m_ClocksListBox.Location = new global::System.Drawing.Point(4, 24);
			this.m_ClocksListBox.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_ClocksListBox.Name = "m_ClocksListBox";
			this.m_ClocksListBox.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.m_ClocksListBox.Size = new global::System.Drawing.Size(299, 212);
			this.m_ClocksListBox.TabIndex = 7;
			this.m_VectorSettingsGroupBox.Controls.Add(this.m_OffsetLabel);
			this.m_VectorSettingsGroupBox.Controls.Add(this.m_VectorOffsetTextBox);
			this.m_VectorSettingsGroupBox.Controls.Add(this.m_StrideLabel);
			this.m_VectorSettingsGroupBox.Controls.Add(this.m_VectorStrideTextBox);
			this.m_VectorSettingsGroupBox.Controls.Add(this.m_LengthLabel);
			this.m_VectorSettingsGroupBox.Controls.Add(this.m_VectorLengthTextBox);
			this.m_VectorSettingsGroupBox.Location = new global::System.Drawing.Point(11, 64);
			this.m_VectorSettingsGroupBox.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_VectorSettingsGroupBox.Name = "m_VectorSettingsGroupBox";
			this.m_VectorSettingsGroupBox.Padding = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_VectorSettingsGroupBox.Size = new global::System.Drawing.Size(307, 90);
			this.m_VectorSettingsGroupBox.TabIndex = 9;
			this.m_VectorSettingsGroupBox.TabStop = false;
			this.m_VectorSettingsGroupBox.Text = "Vector Settings";
			this.m_OffsetLabel.AutoSize = true;
			this.m_OffsetLabel.Location = new global::System.Drawing.Point(98, 20);
			this.m_OffsetLabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_OffsetLabel.Name = "m_OffsetLabel";
			this.m_OffsetLabel.Size = new global::System.Drawing.Size(38, 13);
			this.m_OffsetLabel.TabIndex = 8;
			this.m_OffsetLabel.Text = "Offset:";
			this.m_VectorOffsetTextBox.Location = new global::System.Drawing.Point(153, 17);
			this.m_VectorOffsetTextBox.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_VectorOffsetTextBox.Name = "m_VectorOffsetTextBox";
			this.m_VectorOffsetTextBox.Size = new global::System.Drawing.Size(67, 20);
			this.m_VectorOffsetTextBox.TabIndex = 7;
			this.groupBox1.Controls.Add(this.m_ClocksListBox);
			this.groupBox1.Location = new global::System.Drawing.Point(11, 159);
			this.groupBox1.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Size = new global::System.Drawing.Size(307, 246);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sampling Clocks";
			this.m_AcceptBtn.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.m_AcceptBtn.Location = new global::System.Drawing.Point(96, 409);
			this.m_AcceptBtn.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_AcceptBtn.Name = "m_AcceptBtn";
			this.m_AcceptBtn.Size = new global::System.Drawing.Size(56, 26);
			this.m_AcceptBtn.TabIndex = 11;
			this.m_AcceptBtn.Text = "Accept";
			this.m_AcceptBtn.UseVisualStyleBackColor = true;
			this.m_AcceptBtn.Click += new global::System.EventHandler(this.m_AcceptBtn_Click);
			this.m_CancelBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.m_CancelBtn.Location = new global::System.Drawing.Point(175, 408);
			this.m_CancelBtn.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_CancelBtn.Name = "m_CancelBtn";
			this.m_CancelBtn.Size = new global::System.Drawing.Size(56, 26);
			this.m_CancelBtn.TabIndex = 12;
			this.m_CancelBtn.Text = "Cancel";
			this.m_CancelBtn.UseVisualStyleBackColor = true;
			this.m_CancelBtn.Click += new global::System.EventHandler(this.m_CancelBtn_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(328, 445);
			base.Controls.Add(this.m_CancelBtn);
			base.Controls.Add(this.m_AcceptBtn);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.m_VectorSettingsGroupBox);
			base.Controls.Add(this.m_VarName);
			base.Controls.Add(this.m_VarNameLabel);
			base.Margin = new global::System.Windows.Forms.Padding(2, 2, 2, 2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "UpdateMonitorVarsDialog";
			this.Text = "Modify monitor settings";
			this.m_VectorSettingsGroupBox.ResumeLayout(false);
			this.m_VectorSettingsGroupBox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.Label m_VarNameLabel;


		private global::System.Windows.Forms.TextBox m_VarName;


		private global::System.Windows.Forms.TextBox m_VectorStrideTextBox;


		private global::System.Windows.Forms.Label m_StrideLabel;


		private global::System.Windows.Forms.Label m_LengthLabel;


		private global::System.Windows.Forms.TextBox m_VectorLengthTextBox;


		private global::System.Windows.Forms.ListBox m_ClocksListBox;


		private global::System.Windows.Forms.GroupBox m_VectorSettingsGroupBox;


		private global::System.Windows.Forms.GroupBox groupBox1;


		private global::System.Windows.Forms.Button m_AcceptBtn;


		private global::System.Windows.Forms.Button m_CancelBtn;


		private global::System.Windows.Forms.Label m_OffsetLabel;


		private global::System.Windows.Forms.TextBox m_VectorOffsetTextBox;
	}
}
