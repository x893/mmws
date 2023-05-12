namespace RSTD
{

	public partial class frmUserButtonConfig : global::System.Windows.Forms.Form
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
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.frmUserButtonConfig));
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtButtonTitle = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.txtScriptLocation = new global::System.Windows.Forms.TextBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.m_dgvScriptParams = new global::System.Windows.Forms.DataGridView();
			this.colVarType = new global::System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colVarName = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colVarValue = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnExecute = new global::System.Windows.Forms.Button();
			this.Panel = new global::System.Windows.Forms.Panel();
			this.FunactionPanel = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel9 = new global::System.Windows.Forms.TableLayoutPanel();
			this.functionNameTextBox = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.scriptLocationPanel = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel5 = new global::System.Windows.Forms.TableLayoutPanel();
			this.btnOpenFileDialog = new global::System.Windows.Forms.Button();
			this.btnNewFileDialog = new global::System.Windows.Forms.Button();
			this.label5 = new global::System.Windows.Forms.Label();
			this.ParameterPanel = new global::System.Windows.Forms.Panel();
			this.tableLayoutPanel8 = new global::System.Windows.Forms.TableLayoutPanel();
			this.embeddedScriptPanel = new global::System.Windows.Forms.Panel();
			this.inlineTextBox = new global::System.Windows.Forms.TextBox();
			this.tableLayoutPanel2 = new global::System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new global::System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel4 = new global::System.Windows.Forms.TableLayoutPanel();
			this.typeSelectComboBox = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.colorButton = new global::System.Windows.Forms.Button();
			this.iconButton = new global::System.Windows.Forms.Button();
			this.colorPictureBox = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.tableLayoutPanel6 = new global::System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel7 = new global::System.Windows.Forms.TableLayoutPanel();
			this.label7 = new global::System.Windows.Forms.Label();
			this.tableLayoutPanel10 = new global::System.Windows.Forms.TableLayoutPanel();
			this.m_BrowseFunctionButton = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.m_FunctionLocationTextBox = new global::System.Windows.Forms.TextBox();
			((global::System.ComponentModel.ISupportInitialize)this.m_dgvScriptParams).BeginInit();
			this.Panel.SuspendLayout();
			this.FunactionPanel.SuspendLayout();
			this.tableLayoutPanel9.SuspendLayout();
			this.scriptLocationPanel.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.ParameterPanel.SuspendLayout();
			this.tableLayoutPanel8.SuspendLayout();
			this.embeddedScriptPanel.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.colorPictureBox).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			this.tableLayoutPanel6.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			this.tableLayoutPanel10.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(22, 0);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(61, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Button Title";
			this.txtButtonTitle.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.txtButtonTitle.Location = new global::System.Drawing.Point(22, 15);
			this.txtButtonTitle.Margin = new global::System.Windows.Forms.Padding(2);
			this.txtButtonTitle.Name = "txtButtonTitle";
			this.txtButtonTitle.Size = new global::System.Drawing.Size(453, 20);
			this.txtButtonTitle.TabIndex = 1;
			this.txtButtonTitle.TextChanged += new global::System.EventHandler(this.TextBoxes_TextChanged);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(7, 64);
			this.label2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(0, 13);
			this.label2.TabIndex = 2;
			this.txtScriptLocation.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.txtScriptLocation.Location = new global::System.Drawing.Point(2, 22);
			this.txtScriptLocation.Margin = new global::System.Windows.Forms.Padding(2);
			this.txtScriptLocation.Name = "txtScriptLocation";
			this.txtScriptLocation.Size = new global::System.Drawing.Size(420, 20);
			this.txtScriptLocation.TabIndex = 3;
			this.txtScriptLocation.TextChanged += new global::System.EventHandler(this.TextBoxes_TextChanged);
			this.btnOK.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.btnOK.Location = new global::System.Drawing.Point(230, 7);
			this.btnOK.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(84, 28);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.btnCancel.Location = new global::System.Drawing.Point(398, 7);
			this.btnCancel.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(84, 28);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(2, 0);
			this.label3.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(60, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Parameters";
			dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = global::System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			dataGridViewCellStyle.ForeColor = global::System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgvScriptParams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.m_dgvScriptParams.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_dgvScriptParams.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.colVarType,
				this.colVarName,
				this.colVarValue
			});
			dataGridViewCellStyle2.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			dataGridViewCellStyle2.ForeColor = global::System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = global::System.Windows.Forms.DataGridViewTriState.False;
			this.m_dgvScriptParams.DefaultCellStyle = dataGridViewCellStyle2;
			this.m_dgvScriptParams.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.m_dgvScriptParams.Location = new global::System.Drawing.Point(3, 24);
			this.m_dgvScriptParams.Name = "m_dgvScriptParams";
			dataGridViewCellStyle3.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = global::System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			dataGridViewCellStyle3.ForeColor = global::System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgvScriptParams.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.m_dgvScriptParams.RowHeadersWidth = 30;
			this.m_dgvScriptParams.RowHeadersWidthSizeMode = global::System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.m_dgvScriptParams.Size = new global::System.Drawing.Size(468, 149);
			this.m_dgvScriptParams.TabIndex = 9;
			this.m_dgvScriptParams.RowsAdded += new global::System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvScriptParams_RowsAdded);
			this.colVarType.HeaderText = "Type";
			this.colVarType.Items.AddRange(new object[]
			{
				"String",
				"Number",
				"Bool"
			});
			this.colVarType.Name = "colVarType";
			this.colVarType.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.colVarType.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.colVarType.Width = 70;
			this.colVarName.HeaderText = "Name";
			this.colVarName.Name = "colVarName";
			this.colVarValue.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colVarValue.HeaderText = "Value";
			this.colVarValue.Name = "colVarValue";
			this.btnExecute.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.btnExecute.Location = new global::System.Drawing.Point(62, 7);
			this.btnExecute.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new global::System.Drawing.Size(84, 28);
			this.btnExecute.TabIndex = 13;
			this.btnExecute.Text = "Execute";
			this.btnExecute.UseVisualStyleBackColor = true;
			this.btnExecute.Click += new global::System.EventHandler(this.btnExecute_Click);
			this.Panel.Controls.Add(this.FunactionPanel);
			this.Panel.Controls.Add(this.scriptLocationPanel);
			this.Panel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.Panel.Location = new global::System.Drawing.Point(3, 3);
			this.Panel.Name = "Panel";
			this.Panel.Size = new global::System.Drawing.Size(474, 94);
			this.Panel.TabIndex = 14;
			this.FunactionPanel.Controls.Add(this.tableLayoutPanel9);
			this.FunactionPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.FunactionPanel.Location = new global::System.Drawing.Point(0, 0);
			this.FunactionPanel.Name = "FunactionPanel";
			this.FunactionPanel.Size = new global::System.Drawing.Size(474, 94);
			this.FunactionPanel.TabIndex = 2;
			this.tableLayoutPanel9.ColumnCount = 1;
			this.tableLayoutPanel9.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 0, 3);
			this.tableLayoutPanel9.Controls.Add(this.functionNameTextBox, 0, 1);
			this.tableLayoutPanel9.Controls.Add(this.label6, 0, 0);
			this.tableLayoutPanel9.Controls.Add(this.label7, 0, 2);
			this.tableLayoutPanel9.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel9.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 4;
			this.tableLayoutPanel9.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanel9.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 42.64706f));
			this.tableLayoutPanel9.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanel9.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 57.35294f));
			this.tableLayoutPanel9.Size = new global::System.Drawing.Size(474, 94);
			this.tableLayoutPanel9.TabIndex = 2;
			this.functionNameTextBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.functionNameTextBox.Location = new global::System.Drawing.Point(2, 15);
			this.functionNameTextBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.functionNameTextBox.Name = "functionNameTextBox";
			this.functionNameTextBox.Size = new global::System.Drawing.Size(470, 20);
			this.functionNameTextBox.TabIndex = 10;
			this.functionNameTextBox.TextChanged += new global::System.EventHandler(this.TextBoxes_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(3, 0);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(38, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Name:";
			this.scriptLocationPanel.Controls.Add(this.tableLayoutPanel5);
			this.scriptLocationPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.scriptLocationPanel.Location = new global::System.Drawing.Point(0, 0);
			this.scriptLocationPanel.Name = "scriptLocationPanel";
			this.scriptLocationPanel.Size = new global::System.Drawing.Size(474, 94);
			this.scriptLocationPanel.TabIndex = 1;
			this.tableLayoutPanel5.ColumnCount = 3;
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.Controls.Add(this.btnOpenFileDialog, 1, 1);
			this.tableLayoutPanel5.Controls.Add(this.btnNewFileDialog, 2, 1);
			this.tableLayoutPanel5.Controls.Add(this.txtScriptLocation, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.label5, 0, 0);
			this.tableLayoutPanel5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 2;
			this.tableLayoutPanel5.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel5.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel5.Size = new global::System.Drawing.Size(474, 94);
			this.tableLayoutPanel5.TabIndex = 0;
			this.btnOpenFileDialog.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnOpenFileDialog.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnOpenFileDialog.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("btnOpenFileDialog.Image");
			this.btnOpenFileDialog.Location = new global::System.Drawing.Point(426, 22);
			this.btnOpenFileDialog.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnOpenFileDialog.Name = "btnOpenFileDialog";
			this.btnOpenFileDialog.Size = new global::System.Drawing.Size(20, 20);
			this.btnOpenFileDialog.TabIndex = 4;
			this.btnOpenFileDialog.UseVisualStyleBackColor = true;
			this.btnOpenFileDialog.Click += new global::System.EventHandler(this.btnOpenFileDialog_Click);
			this.btnNewFileDialog.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnNewFileDialog.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnNewFileDialog.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.btnNewFileDialog.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("btnNewFileDialog.Image");
			this.btnNewFileDialog.Location = new global::System.Drawing.Point(451, 23);
			this.btnNewFileDialog.Name = "btnNewFileDialog";
			this.btnNewFileDialog.Size = new global::System.Drawing.Size(20, 20);
			this.btnNewFileDialog.TabIndex = 10;
			this.btnNewFileDialog.UseVisualStyleBackColor = true;
			this.btnNewFileDialog.Click += new global::System.EventHandler(this.btnNewFileDialog_Click);
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(51, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Location:";
			this.ParameterPanel.Controls.Add(this.tableLayoutPanel8);
			this.ParameterPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.ParameterPanel.Location = new global::System.Drawing.Point(3, 103);
			this.ParameterPanel.Name = "ParameterPanel";
			this.ParameterPanel.Size = new global::System.Drawing.Size(474, 176);
			this.ParameterPanel.TabIndex = 15;
			this.ParameterPanel.Visible = false;
			this.tableLayoutPanel8.ColumnCount = 1;
			this.tableLayoutPanel8.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel8.Controls.Add(this.m_dgvScriptParams, 0, 1);
			this.tableLayoutPanel8.Controls.Add(this.label3, 0, 0);
			this.tableLayoutPanel8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel8.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 2;
			this.tableLayoutPanel8.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 21f));
			this.tableLayoutPanel8.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel8.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel8.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel8.Size = new global::System.Drawing.Size(474, 176);
			this.tableLayoutPanel8.TabIndex = 0;
			this.embeddedScriptPanel.Controls.Add(this.inlineTextBox);
			this.embeddedScriptPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.embeddedScriptPanel.Location = new global::System.Drawing.Point(3, 285);
			this.embeddedScriptPanel.Name = "embeddedScriptPanel";
			this.embeddedScriptPanel.Size = new global::System.Drawing.Size(474, 179);
			this.embeddedScriptPanel.TabIndex = 16;
			this.embeddedScriptPanel.Visible = false;
			this.inlineTextBox.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.inlineTextBox.Location = new global::System.Drawing.Point(0, 0);
			this.inlineTextBox.Multiline = true;
			this.inlineTextBox.Name = "inlineTextBox";
			this.inlineTextBox.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.inlineTextBox.Size = new global::System.Drawing.Size(474, 179);
			this.inlineTextBox.TabIndex = 0;
			this.inlineTextBox.TextChanged += new global::System.EventHandler(this.TextBoxes_TextChanged);
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 0, 5);
			this.tableLayoutPanel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 6;
			this.tableLayoutPanel2.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 38f));
			this.tableLayoutPanel2.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 2.5f));
			this.tableLayoutPanel2.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 97.5f));
			this.tableLayoutPanel2.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 9f));
			this.tableLayoutPanel2.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 48f));
			this.tableLayoutPanel2.Size = new global::System.Drawing.Size(552, 462);
			this.tableLayoutPanel2.TabIndex = 19;
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel3.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 86.93957f));
			this.tableLayoutPanel3.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 13.06043f));
			this.tableLayoutPanel3.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.txtButtonTitle, 1, 1);
			this.tableLayoutPanel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new global::System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.Size = new global::System.Drawing.Size(546, 42);
			this.tableLayoutPanel3.TabIndex = 0;
			this.tableLayoutPanel4.ColumnCount = 11;
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 48f));
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 56.49612f));
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 43.50388f));
			this.tableLayoutPanel4.Controls.Add(this.typeSelectComboBox, 2, 0);
			this.tableLayoutPanel4.Controls.Add(this.label4, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.colorButton, 5, 0);
			this.tableLayoutPanel4.Controls.Add(this.iconButton, 9, 0);
			this.tableLayoutPanel4.Controls.Add(this.colorPictureBox, 3, 0);
			this.tableLayoutPanel4.Controls.Add(this.pictureBox1, 7, 0);
			this.tableLayoutPanel4.Controls.Add(this.pictureBox2, 4, 0);
			this.tableLayoutPanel4.Controls.Add(this.pictureBox3, 8, 0);
			this.tableLayoutPanel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new global::System.Drawing.Point(3, 51);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.tableLayoutPanel4.Size = new global::System.Drawing.Size(546, 32);
			this.tableLayoutPanel4.TabIndex = 1;
			this.typeSelectComboBox.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeSelectComboBox.FormattingEnabled = true;
			this.typeSelectComboBox.Items.AddRange(new object[]
			{
				"File",
				"Function",
				"Inline"
			});
			this.typeSelectComboBox.Location = new global::System.Drawing.Point(71, 3);
			this.typeSelectComboBox.Name = "typeSelectComboBox";
			this.typeSelectComboBox.Size = new global::System.Drawing.Size(128, 21);
			this.typeSelectComboBox.TabIndex = 18;
			this.typeSelectComboBox.SelectedIndexChanged += new global::System.EventHandler(this.typeSelectComboBox_SelectedIndexChanged);
			this.label4.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(27, 9);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(34, 13);
			this.label4.TabIndex = 19;
			this.label4.Text = "Type:";
			this.colorButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.colorButton.Location = new global::System.Drawing.Point(285, 3);
			this.colorButton.Name = "colorButton";
			this.colorButton.Size = new global::System.Drawing.Size(28, 26);
			this.colorButton.TabIndex = 21;
			this.colorButton.UseVisualStyleBackColor = true;
			this.colorButton.Click += new global::System.EventHandler(this.colorButton_Click);
			this.colorButton.MouseEnter += new global::System.EventHandler(this.colorButton_MouseEnter);
			this.colorButton.MouseLeave += new global::System.EventHandler(this.colorButton_MouseLeave);
			this.iconButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.iconButton.Location = new global::System.Drawing.Point(397, 3);
			this.iconButton.Name = "iconButton";
			this.iconButton.Size = new global::System.Drawing.Size(28, 26);
			this.iconButton.TabIndex = 23;
			this.iconButton.UseVisualStyleBackColor = true;
			this.iconButton.Click += new global::System.EventHandler(this.iconButton_Click);
			this.iconButton.MouseEnter += new global::System.EventHandler(this.iconButton_MouseEnter);
			this.iconButton.MouseLeave += new global::System.EventHandler(this.iconButton_MouseLeave);
			this.colorPictureBox.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.colorPictureBox.Image = global::RSTD.Properties.Resources.color_palette_36;
			this.colorPictureBox.Location = new global::System.Drawing.Point(222, 3);
			this.colorPictureBox.Name = "colorPictureBox";
			this.colorPictureBox.Size = new global::System.Drawing.Size(37, 26);
			this.colorPictureBox.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.colorPictureBox.TabIndex = 24;
			this.colorPictureBox.TabStop = false;
			this.colorPictureBox.Tag = "Color";
			this.colorPictureBox.Click += new global::System.EventHandler(this.colorPictureBox_Click);
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Image = global::RSTD.Properties.Resources.image_32;
			this.pictureBox1.Location = new global::System.Drawing.Point(339, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(32, 26);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 25;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Tag = "Color";
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.pictureBox2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pictureBox2.Image = global::RSTD.Properties.Resources.arrow_2_dots;
			this.pictureBox2.Location = new global::System.Drawing.Point(265, 3);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(14, 26);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox2.TabIndex = 26;
			this.pictureBox2.TabStop = false;
			this.pictureBox3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pictureBox3.Image = global::RSTD.Properties.Resources.arrow_2_dots;
			this.pictureBox3.Location = new global::System.Drawing.Point(377, 3);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(14, 26);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox3.TabIndex = 27;
			this.pictureBox3.TabStop = false;
			this.tableLayoutPanel6.ColumnCount = 3;
			this.tableLayoutPanel6.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 30f));
			this.tableLayoutPanel6.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel6.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 30f));
			this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel1, 1, 0);
			this.tableLayoutPanel6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel6.Location = new global::System.Drawing.Point(3, 96);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel6.Size = new global::System.Drawing.Size(546, 305);
			this.tableLayoutPanel6.TabIndex = 2;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.Controls.Add(this.embeddedScriptPanel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.Panel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.ParameterPanel, 0, 1);
			this.tableLayoutPanel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new global::System.Drawing.Point(33, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new global::System.Drawing.Size(480, 299);
			this.tableLayoutPanel1.TabIndex = 0;
			this.tableLayoutPanel7.ColumnCount = 5;
			this.tableLayoutPanel7.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel7.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
			this.tableLayoutPanel7.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
			this.tableLayoutPanel7.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
			this.tableLayoutPanel7.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 22f));
			this.tableLayoutPanel7.Controls.Add(this.btnCancel, 3, 0);
			this.tableLayoutPanel7.Controls.Add(this.btnOK, 2, 0);
			this.tableLayoutPanel7.Controls.Add(this.btnExecute, 1, 0);
			this.tableLayoutPanel7.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel7.Location = new global::System.Drawing.Point(3, 416);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel7.Size = new global::System.Drawing.Size(546, 43);
			this.tableLayoutPanel7.TabIndex = 3;
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(3, 42);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(51, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Location:";
			this.tableLayoutPanel10.ColumnCount = 3;
			this.tableLayoutPanel10.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel10.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel10.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel10.Controls.Add(this.m_BrowseFunctionButton, 1, 0);
			this.tableLayoutPanel10.Controls.Add(this.button2, 2, 0);
			this.tableLayoutPanel10.Controls.Add(this.m_FunctionLocationTextBox, 0, 0);
			this.tableLayoutPanel10.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel10.Location = new global::System.Drawing.Point(3, 58);
			this.tableLayoutPanel10.Name = "tableLayoutPanel10";
			this.tableLayoutPanel10.RowCount = 1;
			this.tableLayoutPanel10.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel10.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel10.Size = new global::System.Drawing.Size(468, 33);
			this.tableLayoutPanel10.TabIndex = 13;
			this.m_BrowseFunctionButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_BrowseFunctionButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.m_BrowseFunctionButton.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_BrowseFunctionButton.Image");
			this.m_BrowseFunctionButton.Location = new global::System.Drawing.Point(420, 2);
			this.m_BrowseFunctionButton.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_BrowseFunctionButton.Name = "m_BrowseFunctionButton";
			this.m_BrowseFunctionButton.Size = new global::System.Drawing.Size(20, 20);
			this.m_BrowseFunctionButton.TabIndex = 4;
			this.m_BrowseFunctionButton.UseVisualStyleBackColor = true;
			this.m_BrowseFunctionButton.Click += new global::System.EventHandler(this.m_BrowseFunctionButton_Click);
			this.button2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.button2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("button2.Image");
			this.button2.Location = new global::System.Drawing.Point(445, 3);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(20, 19);
			this.button2.TabIndex = 10;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			this.m_FunctionLocationTextBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_FunctionLocationTextBox.Location = new global::System.Drawing.Point(2, 2);
			this.m_FunctionLocationTextBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_FunctionLocationTextBox.Name = "m_FunctionLocationTextBox";
			this.m_FunctionLocationTextBox.Size = new global::System.Drawing.Size(414, 20);
			this.m_FunctionLocationTextBox.TabIndex = 3;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(552, 462);
			base.Controls.Add(this.tableLayoutPanel2);
			base.Controls.Add(this.label2);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(560, 378);
			base.Name = "frmUserButtonConfig";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "User Button Configuration";
			base.Load += new global::System.EventHandler(this.frmUserButtonConfig_Load);
			((global::System.ComponentModel.ISupportInitialize)this.m_dgvScriptParams).EndInit();
			this.Panel.ResumeLayout(false);
			this.FunactionPanel.ResumeLayout(false);
			this.tableLayoutPanel9.ResumeLayout(false);
			this.tableLayoutPanel9.PerformLayout();
			this.scriptLocationPanel.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.ParameterPanel.ResumeLayout(false);
			this.tableLayoutPanel8.ResumeLayout(false);
			this.tableLayoutPanel8.PerformLayout();
			this.embeddedScriptPanel.ResumeLayout(false);
			this.embeddedScriptPanel.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.colorPictureBox).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel7.ResumeLayout(false);
			this.tableLayoutPanel10.ResumeLayout(false);
			this.tableLayoutPanel10.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.Label label1;


		private global::System.Windows.Forms.TextBox txtButtonTitle;


		private global::System.Windows.Forms.Label label2;


		private global::System.Windows.Forms.TextBox txtScriptLocation;


		private global::System.Windows.Forms.Button btnOpenFileDialog;


		public global::System.Windows.Forms.Button btnOK;


		private global::System.Windows.Forms.Button btnCancel;


		private global::System.Windows.Forms.Label label3;


		private global::System.Windows.Forms.DataGridView m_dgvScriptParams;


		private global::System.Windows.Forms.DataGridViewComboBoxColumn colVarType;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colVarName;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colVarValue;


		private global::System.Windows.Forms.Button btnNewFileDialog;


		public global::System.Windows.Forms.Button btnExecute;


		private global::System.Windows.Forms.Panel Panel;


		private global::System.Windows.Forms.Panel ParameterPanel;


		private global::System.Windows.Forms.TextBox functionNameTextBox;


		private global::System.Windows.Forms.Panel embeddedScriptPanel;


		private global::System.Windows.Forms.TextBox inlineTextBox;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;


		private global::System.Windows.Forms.ComboBox typeSelectComboBox;


		private global::System.Windows.Forms.Label label4;


		private global::System.Windows.Forms.Label label5;


		private global::System.Windows.Forms.Label label6;


		private global::System.Windows.Forms.Panel scriptLocationPanel;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;


		private global::System.Windows.Forms.Panel FunactionPanel;


		private global::System.Windows.Forms.Button colorButton;


		private global::System.Windows.Forms.Button iconButton;


		private global::System.Windows.Forms.PictureBox colorPictureBox;


		private global::System.Windows.Forms.PictureBox pictureBox1;


		private global::System.Windows.Forms.PictureBox pictureBox2;


		private global::System.Windows.Forms.PictureBox pictureBox3;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;


		private global::System.Windows.Forms.Button m_BrowseFunctionButton;


		private global::System.Windows.Forms.Button button2;


		private global::System.Windows.Forms.TextBox m_FunctionLocationTextBox;


		private global::System.Windows.Forms.Label label7;
	}
}
