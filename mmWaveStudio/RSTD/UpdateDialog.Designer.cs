namespace RSTD
{

	public partial class UpdateDialog : global::System.Windows.Forms.Form
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.UpdateDialog));
			this.m_AcceptBtn = new global::System.Windows.Forms.Button();
			this.m_CancelBtn = new global::System.Windows.Forms.Button();
			this.m_UpdateLabel = new global::System.Windows.Forms.Label();
			this.m_AcceptTransmitBtn = new global::System.Windows.Forms.Button();
			this.HexRadioButton = new global::System.Windows.Forms.RadioButton();
			this.intRadioButton = new global::System.Windows.Forms.RadioButton();
			this.binRadioButton = new global::System.Windows.Forms.RadioButton();
			this.defaultRadioButton = new global::System.Windows.Forms.RadioButton();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.decimalRadioButton = new global::System.Windows.Forms.RadioButton();
			this.db20RadioButton = new global::System.Windows.Forms.RadioButton();
			this.db10RadioButton = new global::System.Windows.Forms.RadioButton();
			this.decimalSignedRadioButton = new global::System.Windows.Forms.RadioButton();
			this.tableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new global::System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new global::System.Windows.Forms.TableLayoutPanel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.tableLayoutPanel4 = new global::System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel5 = new global::System.Windows.Forms.TableLayoutPanel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.m_VarNameLabel = new global::System.Windows.Forms.Label();
			this.m_VarTypeLabel = new global::System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			base.SuspendLayout();
			this.m_AcceptBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.m_AcceptBtn.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_AcceptBtn.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.m_AcceptBtn.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_AcceptBtn.ForeColor = global::System.Drawing.Color.Navy;
			this.m_AcceptBtn.Location = new global::System.Drawing.Point(95, 7);
			this.m_AcceptBtn.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_AcceptBtn.Name = "m_AcceptBtn";
			this.m_AcceptBtn.Size = new global::System.Drawing.Size(62, 29);
			this.m_AcceptBtn.TabIndex = 0;
			this.m_AcceptBtn.Text = "Accept";
			this.m_AcceptBtn.UseVisualStyleBackColor = true;
			this.m_AcceptBtn.Click += new global::System.EventHandler(this.m_AcceptBtn_Click);
			this.m_CancelBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.m_CancelBtn.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_CancelBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.m_CancelBtn.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_CancelBtn.ForeColor = global::System.Drawing.Color.Navy;
			this.m_CancelBtn.Location = new global::System.Drawing.Point(302, 7);
			this.m_CancelBtn.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_CancelBtn.Name = "m_CancelBtn";
			this.m_CancelBtn.Size = new global::System.Drawing.Size(64, 29);
			this.m_CancelBtn.TabIndex = 2;
			this.m_CancelBtn.Text = "Cancel";
			this.m_CancelBtn.UseVisualStyleBackColor = true;
			this.m_UpdateLabel.AutoSize = true;
			this.m_UpdateLabel.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_UpdateLabel.ForeColor = global::System.Drawing.Color.Navy;
			this.m_UpdateLabel.Location = new global::System.Drawing.Point(3, 0);
			this.m_UpdateLabel.Name = "m_UpdateLabel";
			this.m_UpdateLabel.Size = new global::System.Drawing.Size(156, 14);
			this.m_UpdateLabel.TabIndex = 4;
			this.m_UpdateLabel.Text = "Update variable value:";
			this.m_AcceptTransmitBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.m_AcceptTransmitBtn.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_AcceptTransmitBtn.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.m_AcceptTransmitBtn.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_AcceptTransmitBtn.ForeColor = global::System.Drawing.Color.Navy;
			this.m_AcceptTransmitBtn.Location = new global::System.Drawing.Point(163, 7);
			this.m_AcceptTransmitBtn.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_AcceptTransmitBtn.Name = "m_AcceptTransmitBtn";
			this.m_AcceptTransmitBtn.Size = new global::System.Drawing.Size(133, 29);
			this.m_AcceptTransmitBtn.TabIndex = 1;
			this.m_AcceptTransmitBtn.Text = "Accept&&Transmit";
			this.m_AcceptTransmitBtn.UseVisualStyleBackColor = true;
			this.m_AcceptTransmitBtn.Click += new global::System.EventHandler(this.m_AcceptTransmitBtn_Click);
			this.HexRadioButton.AutoSize = true;
			this.HexRadioButton.Enabled = false;
			this.HexRadioButton.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.HexRadioButton.Location = new global::System.Drawing.Point(323, 12);
			this.HexRadioButton.Name = "HexRadioButton";
			this.HexRadioButton.Size = new global::System.Drawing.Size(44, 17);
			this.HexRadioButton.TabIndex = 4;
			this.HexRadioButton.Text = "Hex";
			this.HexRadioButton.UseVisualStyleBackColor = true;
			this.HexRadioButton.CheckedChanged += new global::System.EventHandler(this.rdioButton_CheckedChanged);
			this.intRadioButton.AutoSize = true;
			this.intRadioButton.Enabled = false;
			this.intRadioButton.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.intRadioButton.Location = new global::System.Drawing.Point(171, 12);
			this.intRadioButton.Name = "intRadioButton";
			this.intRadioButton.Size = new global::System.Drawing.Size(58, 17);
			this.intRadioButton.TabIndex = 2;
			this.intRadioButton.Text = "Integer";
			this.intRadioButton.UseVisualStyleBackColor = true;
			this.intRadioButton.CheckedChanged += new global::System.EventHandler(this.rdioButton_CheckedChanged);
			this.binRadioButton.AutoSize = true;
			this.binRadioButton.Enabled = false;
			this.binRadioButton.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.binRadioButton.Location = new global::System.Drawing.Point(245, 12);
			this.binRadioButton.Name = "binRadioButton";
			this.binRadioButton.Size = new global::System.Drawing.Size(54, 17);
			this.binRadioButton.TabIndex = 3;
			this.binRadioButton.Text = "Binary";
			this.binRadioButton.UseVisualStyleBackColor = true;
			this.binRadioButton.CheckedChanged += new global::System.EventHandler(this.rdioButton_CheckedChanged);
			this.defaultRadioButton.AutoSize = true;
			this.defaultRadioButton.Enabled = false;
			this.defaultRadioButton.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.defaultRadioButton.Location = new global::System.Drawing.Point(25, 12);
			this.defaultRadioButton.Name = "defaultRadioButton";
			this.defaultRadioButton.Size = new global::System.Drawing.Size(59, 17);
			this.defaultRadioButton.TabIndex = 0;
			this.defaultRadioButton.Text = "Default";
			this.defaultRadioButton.UseVisualStyleBackColor = true;
			this.defaultRadioButton.CheckedChanged += new global::System.EventHandler(this.rdioButton_CheckedChanged);
			this.groupBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.decimalRadioButton);
			this.groupBox1.Controls.Add(this.db20RadioButton);
			this.groupBox1.Controls.Add(this.db10RadioButton);
			this.groupBox1.Controls.Add(this.decimalSignedRadioButton);
			this.groupBox1.Controls.Add(this.HexRadioButton);
			this.groupBox1.Controls.Add(this.defaultRadioButton);
			this.groupBox1.Controls.Add(this.intRadioButton);
			this.groupBox1.Controls.Add(this.binRadioButton);
			this.groupBox1.Location = new global::System.Drawing.Point(23, 119);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(421, 64);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.decimalRadioButton.AutoSize = true;
			this.decimalRadioButton.Enabled = false;
			this.decimalRadioButton.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.decimalRadioButton.Location = new global::System.Drawing.Point(94, 12);
			this.decimalRadioButton.Name = "decimalRadioButton";
			this.decimalRadioButton.Size = new global::System.Drawing.Size(63, 17);
			this.decimalRadioButton.TabIndex = 1;
			this.decimalRadioButton.TabStop = true;
			this.decimalRadioButton.Text = "Decimal";
			this.decimalRadioButton.UseVisualStyleBackColor = true;
			this.decimalRadioButton.CheckedChanged += new global::System.EventHandler(this.rdioButton_CheckedChanged);
			this.db20RadioButton.AutoSize = true;
			this.db20RadioButton.Enabled = false;
			this.db20RadioButton.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.db20RadioButton.Location = new global::System.Drawing.Point(94, 36);
			this.db20RadioButton.Name = "db20RadioButton";
			this.db20RadioButton.Size = new global::System.Drawing.Size(52, 17);
			this.db20RadioButton.TabIndex = 6;
			this.db20RadioButton.TabStop = true;
			this.db20RadioButton.Text = "DB20";
			this.db20RadioButton.UseVisualStyleBackColor = true;
			this.db20RadioButton.CheckedChanged += new global::System.EventHandler(this.rdioButton_CheckedChanged);
			this.db10RadioButton.AutoSize = true;
			this.db10RadioButton.Enabled = false;
			this.db10RadioButton.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.db10RadioButton.Location = new global::System.Drawing.Point(25, 36);
			this.db10RadioButton.Name = "db10RadioButton";
			this.db10RadioButton.Size = new global::System.Drawing.Size(52, 17);
			this.db10RadioButton.TabIndex = 5;
			this.db10RadioButton.TabStop = true;
			this.db10RadioButton.Text = "DB10";
			this.db10RadioButton.UseVisualStyleBackColor = true;
			this.db10RadioButton.CheckedChanged += new global::System.EventHandler(this.rdioButton_CheckedChanged);
			this.decimalSignedRadioButton.AutoSize = true;
			this.decimalSignedRadioButton.Enabled = false;
			this.decimalSignedRadioButton.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.decimalSignedRadioButton.Location = new global::System.Drawing.Point(171, 36);
			this.decimalSignedRadioButton.Name = "decimalSignedRadioButton";
			this.decimalSignedRadioButton.Size = new global::System.Drawing.Size(102, 17);
			this.decimalSignedRadioButton.TabIndex = 7;
			this.decimalSignedRadioButton.TabStop = true;
			this.decimalSignedRadioButton.Text = "Decimal_Signed";
			this.decimalSignedRadioButton.UseVisualStyleBackColor = true;
			this.decimalSignedRadioButton.CheckedChanged += new global::System.EventHandler(this.rdioButton_CheckedChanged);
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.Controls.Add(this.m_UpdateLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 1);
			this.tableLayoutPanel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 14f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 30f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 70f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.Size = new global::System.Drawing.Size(468, 230);
			this.tableLayoutPanel1.TabIndex = 10;
			this.tableLayoutPanel2.ColumnCount = 5;
			this.tableLayoutPanel2.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel2.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel2.Controls.Add(this.m_AcceptBtn, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_CancelBtn, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_AcceptTransmitBtn, 2, 0);
			this.tableLayoutPanel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new global::System.Drawing.Point(3, 189);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.Size = new global::System.Drawing.Size(462, 38);
			this.tableLayoutPanel2.TabIndex = 3;
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tableLayoutPanel3.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel3.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 63f));
			this.tableLayoutPanel3.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel3.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new global::System.Drawing.Point(3, 47);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.Size = new global::System.Drawing.Size(462, 30);
			this.tableLayoutPanel3.TabIndex = 0;
			this.tableLayoutPanel3.Visible = false;
			this.label1.Anchor = global::System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Arial", 9.5f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.label1.Location = new global::System.Drawing.Point(23, 7);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(57, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Value =";
			this.tableLayoutPanel4.ColumnCount = 4;
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 63f));
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new global::System.Drawing.Point(3, 83);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new global::System.Drawing.Size(462, 30);
			this.tableLayoutPanel4.TabIndex = 1;
			this.tableLayoutPanel4.Visible = false;
			this.tableLayoutPanel5.ColumnCount = 7;
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 44f));
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 21f));
			this.tableLayoutPanel5.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel5.Controls.Add(this.label3, 4, 0);
			this.tableLayoutPanel5.Controls.Add(this.m_VarNameLabel, 2, 0);
			this.tableLayoutPanel5.Controls.Add(this.m_VarTypeLabel, 5, 0);
			this.tableLayoutPanel5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Location = new global::System.Drawing.Point(3, 17);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 1;
			this.tableLayoutPanel5.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel5.Size = new global::System.Drawing.Size(462, 24);
			this.tableLayoutPanel5.TabIndex = 5;
			this.label2.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(23, 4);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(65, 15);
			this.label2.TabIndex = 0;
			this.label2.Text = "Var Name:";
			this.label3.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(183, 4);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(57, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Var Type:";
			this.m_VarNameLabel.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.m_VarNameLabel.AutoSize = true;
			this.m_VarNameLabel.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_VarNameLabel.ForeColor = global::System.Drawing.Color.Black;
			this.m_VarNameLabel.Location = new global::System.Drawing.Point(94, 4);
			this.m_VarNameLabel.Name = "m_VarNameLabel";
			this.m_VarNameLabel.Size = new global::System.Drawing.Size(39, 15);
			this.m_VarNameLabel.TabIndex = 2;
			this.m_VarNameLabel.Text = "name";
			this.m_VarTypeLabel.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.m_VarTypeLabel.AutoSize = true;
			this.m_VarTypeLabel.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_VarTypeLabel.ForeColor = global::System.Drawing.Color.Black;
			this.m_VarTypeLabel.Location = new global::System.Drawing.Point(246, 4);
			this.m_VarTypeLabel.Name = "m_VarTypeLabel";
			this.m_VarTypeLabel.Size = new global::System.Drawing.Size(31, 15);
			this.m_VarTypeLabel.TabIndex = 3;
			this.m_VarTypeLabel.Text = "type";
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(468, 230);
			base.Controls.Add(this.tableLayoutPanel1);
			this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "UpdateDialog";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Update Dialog";
			base.Load += new global::System.EventHandler(this.UpdateDialog_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.UpdateDialog_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.Button m_AcceptBtn;


		private global::System.Windows.Forms.Button m_CancelBtn;


		private global::System.Windows.Forms.Label m_UpdateLabel;


		private global::System.Windows.Forms.Button m_AcceptTransmitBtn;


		private global::System.Windows.Forms.RadioButton HexRadioButton;


		private global::System.Windows.Forms.RadioButton intRadioButton;


		private global::System.Windows.Forms.RadioButton binRadioButton;


		private global::System.Windows.Forms.RadioButton defaultRadioButton;


		private global::System.Windows.Forms.GroupBox groupBox1;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;


		private global::System.Windows.Forms.Label label1;


		private global::System.Windows.Forms.RadioButton decimalRadioButton;


		private global::System.Windows.Forms.RadioButton db20RadioButton;


		private global::System.Windows.Forms.RadioButton db10RadioButton;


		private global::System.Windows.Forms.RadioButton decimalSignedRadioButton;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;


		private global::System.Windows.Forms.Label label2;


		private global::System.Windows.Forms.Label label3;


		private global::System.Windows.Forms.Label m_VarNameLabel;


		private global::System.Windows.Forms.Label m_VarTypeLabel;
	}
}
