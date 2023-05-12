namespace RSTD
{

	public partial class SettingsForm : global::System.Windows.Forms.Form
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
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.SettingsForm));
			this.m_TabControl = new global::System.Windows.Forms.TabControl();
			this.tpClients = new global::System.Windows.Forms.TabPage();
			this.grpClient = new global::System.Windows.Forms.GroupBox();
			this.dgvClientDlls = new global::System.Windows.Forms.DataGridView();
			this.colUseClient = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.colPriority = new global::System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colClientDll = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colBrowseClientDll = new global::System.Windows.Forms.DataGridViewButtonColumn();
			this.colClientXml = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colBrowseClientXml = new global::System.Windows.Forms.DataGridViewButtonColumn();
			this.m_ClientsTabLabel = new global::System.Windows.Forms.Label();
			this.tpCom = new global::System.Windows.Forms.TabPage();
			this.label1 = new global::System.Windows.Forms.Label();
			this.grpCom = new global::System.Windows.Forms.GroupBox();
			this.dgvComDlls = new global::System.Windows.Forms.DataGridView();
			this.colUseCom = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.colComDll = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colBrowseComDll = new global::System.Windows.Forms.DataGridViewButtonColumn();
			this.colComXml = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colBrowseComXml = new global::System.Windows.Forms.DataGridViewButtonColumn();
			this.tpPaths = new global::System.Windows.Forms.TabPage();
			this.m_PathsTabLabel = new global::System.Windows.Forms.Label();
			this.m_ConfigGrpBox = new global::System.Windows.Forms.GroupBox();
			this.m_ConfigPathBrowseBtn = new global::System.Windows.Forms.Button();
			this.m_ConfigPathComboBox = new global::System.Windows.Forms.ComboBox();
			this.m_OutputGrpBox = new global::System.Windows.Forms.GroupBox();
			this.m_OutputPathBrowseBtn = new global::System.Windows.Forms.Button();
			this.m_OutputPathComboBox = new global::System.Windows.Forms.ComboBox();
			this.m_InputGrpBox = new global::System.Windows.Forms.GroupBox();
			this.m_InputPathBrowseBtn = new global::System.Windows.Forms.Button();
			this.m_InputPathComboBox = new global::System.Windows.Forms.ComboBox();
			this.flowLayoutPanel1 = new global::System.Windows.Forms.FlowLayoutPanel();
			this.tpScripter = new global::System.Windows.Forms.TabPage();
			this.m_ScripterTabLabel = new global::System.Windows.Forms.Label();
			this.m_ScripterVerboseModeCheckBox = new global::System.Windows.Forms.CheckBox();
			this.m_BottomToolStrip = new global::RSTD.ToolStripEx();
			this.m_BottomToolStripOkBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_ToolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_BottomToolStripCancelBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_ToolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_SaveAsBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_ToolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_LoadBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_ToolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_TabControl.SuspendLayout();
			this.tpClients.SuspendLayout();
			this.grpClient.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dgvClientDlls).BeginInit();
			this.tpCom.SuspendLayout();
			this.grpCom.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dgvComDlls).BeginInit();
			this.tpPaths.SuspendLayout();
			this.m_ConfigGrpBox.SuspendLayout();
			this.m_OutputGrpBox.SuspendLayout();
			this.m_InputGrpBox.SuspendLayout();
			this.tpScripter.SuspendLayout();
			this.m_BottomToolStrip.SuspendLayout();
			base.SuspendLayout();
			this.m_TabControl.Controls.Add(this.tpClients);
			this.m_TabControl.Controls.Add(this.tpCom);
			this.m_TabControl.Controls.Add(this.tpPaths);
			this.m_TabControl.Controls.Add(this.tpScripter);
			this.m_TabControl.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.m_TabControl.Location = new global::System.Drawing.Point(0, 0);
			this.m_TabControl.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_TabControl.Name = "m_TabControl";
			this.m_TabControl.SelectedIndex = 0;
			this.m_TabControl.Size = new global::System.Drawing.Size(771, 465);
			this.m_TabControl.TabIndex = 0;
			this.tpClients.Controls.Add(this.grpClient);
			this.tpClients.Controls.Add(this.m_ClientsTabLabel);
			this.tpClients.Location = new global::System.Drawing.Point(4, 25);
			this.tpClients.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tpClients.Name = "tpClients";
			this.tpClients.Padding = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tpClients.Size = new global::System.Drawing.Size(763, 436);
			this.tpClients.TabIndex = 0;
			this.tpClients.Text = "Clients";
			this.tpClients.UseVisualStyleBackColor = true;
			this.grpClient.Controls.Add(this.dgvClientDlls);
			this.grpClient.Location = new global::System.Drawing.Point(30, 106);
			this.grpClient.Name = "grpClient";
			this.grpClient.Size = new global::System.Drawing.Size(712, 277);
			this.grpClient.TabIndex = 17;
			this.grpClient.TabStop = false;
			this.grpClient.Text = "Client Settings";
			this.dgvClientDlls.AllowUserToOrderColumns = true;
			this.dgvClientDlls.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvClientDlls.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.colUseClient,
				this.colPriority,
				this.colClientDll,
				this.colBrowseClientDll,
				this.colClientXml,
				this.colBrowseClientXml
			});
			this.dgvClientDlls.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dgvClientDlls.EditMode = global::System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvClientDlls.Location = new global::System.Drawing.Point(3, 18);
			this.dgvClientDlls.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvClientDlls.Name = "dgvClientDlls";
			this.dgvClientDlls.RowHeadersWidthSizeMode = global::System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvClientDlls.RowTemplate.Height = 24;
			this.dgvClientDlls.Size = new global::System.Drawing.Size(706, 256);
			this.dgvClientDlls.TabIndex = 16;
			this.dgvClientDlls.CellContentClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientDlls_CellContentClick);
			this.colUseClient.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.colUseClient.HeaderText = "Use";
			this.colUseClient.IndeterminateValue = "";
			this.colUseClient.Name = "colUseClient";
			this.colUseClient.ToolTipText = "Enable running this client DLL";
			this.colUseClient.Width = 39;
			dataGridViewCellStyle.NullValue = "NORAML";
			this.colPriority.DefaultCellStyle = dataGridViewCellStyle;
			this.colPriority.HeaderText = "Priority";
			this.colPriority.Items.AddRange(new object[]
			{
				"IDLE",
				"LOW",
				"NORMAL",
				"HIGH",
				"HIGHEST"
			});
			this.colPriority.Name = "colPriority";
			this.colPriority.ToolTipText = "Priority for the current client DLL";
			this.colClientDll.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colClientDll.HeaderText = "Client DLL";
			this.colClientDll.Name = "colClientDll";
			this.colClientDll.ToolTipText = "Select client DLL here";
			this.colBrowseClientDll.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle2.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = global::System.Drawing.Color.Silver;
			dataGridViewCellStyle2.ForeColor = global::System.Drawing.Color.Black;
			dataGridViewCellStyle2.NullValue = "...";
			this.colBrowseClientDll.DefaultCellStyle = dataGridViewCellStyle2;
			this.colBrowseClientDll.HeaderText = "";
			this.colBrowseClientDll.Name = "colBrowseClientDll";
			this.colBrowseClientDll.ReadOnly = true;
			this.colBrowseClientDll.Text = "...";
			this.colBrowseClientDll.ToolTipText = "Browse for a client DLL";
			this.colBrowseClientDll.Width = 31;
			this.colClientXml.HeaderText = "Defualt Xml";
			this.colClientXml.Name = "colClientXml";
			this.colClientXml.ToolTipText = "Select client Default Xml here";
			this.colClientXml.Visible = false;
			this.colClientXml.Width = 130;
			dataGridViewCellStyle3.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.NullValue = "...";
			this.colBrowseClientXml.DefaultCellStyle = dataGridViewCellStyle3;
			this.colBrowseClientXml.HeaderText = "";
			this.colBrowseClientXml.MinimumWidth = 31;
			this.colBrowseClientXml.Name = "colBrowseClientXml";
			this.colBrowseClientXml.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.colBrowseClientXml.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.colBrowseClientXml.Text = "...";
			this.colBrowseClientXml.ToolTipText = "Browse for a communication xml";
			this.colBrowseClientXml.Visible = false;
			this.colBrowseClientXml.Width = 31;
			this.m_ClientsTabLabel.Location = new global::System.Drawing.Point(47, 19);
			this.m_ClientsTabLabel.Name = "m_ClientsTabLabel";
			this.m_ClientsTabLabel.Size = new global::System.Drawing.Size(660, 80);
			this.m_ClientsTabLabel.TabIndex = 4;
			this.m_ClientsTabLabel.Text = "RTTT requires a client DLL to run. \r\nAt most, 5 clients can be used concurrently. \r\nList those DLLs in the following table; \r\nNote the check-box, only enabled DLLs will be built and run.";
			this.tpCom.Controls.Add(this.label1);
			this.tpCom.Controls.Add(this.grpCom);
			this.tpCom.Location = new global::System.Drawing.Point(4, 25);
			this.tpCom.Name = "tpCom";
			this.tpCom.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpCom.Size = new global::System.Drawing.Size(763, 436);
			this.tpCom.TabIndex = 5;
			this.tpCom.Text = "Communication";
			this.tpCom.UseVisualStyleBackColor = true;
			this.label1.Location = new global::System.Drawing.Point(39, 23);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(660, 50);
			this.label1.TabIndex = 20;
			this.label1.Text = "Choose the Communication Dll for the clients.\r\nNote the check-box, only enabled DLLs will be built and run.";
			this.grpCom.Controls.Add(this.dgvComDlls);
			this.grpCom.Location = new global::System.Drawing.Point(33, 86);
			this.grpCom.Name = "grpCom";
			this.grpCom.Size = new global::System.Drawing.Size(709, 181);
			this.grpCom.TabIndex = 19;
			this.grpCom.TabStop = false;
			this.grpCom.Text = "Communication Settings";
			this.dgvComDlls.AllowUserToOrderColumns = true;
			this.dgvComDlls.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvComDlls.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.colUseCom,
				this.colComDll,
				this.colBrowseComDll,
				this.colComXml,
				this.colBrowseComXml
			});
			this.dgvComDlls.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dgvComDlls.EditMode = global::System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvComDlls.Location = new global::System.Drawing.Point(3, 18);
			this.dgvComDlls.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvComDlls.Name = "dgvComDlls";
			this.dgvComDlls.RowHeadersWidthSizeMode = global::System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvComDlls.RowTemplate.Height = 24;
			this.dgvComDlls.Size = new global::System.Drawing.Size(703, 160);
			this.dgvComDlls.TabIndex = 17;
			this.dgvComDlls.CellContentClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComDlls_CellContentClick);
			this.colUseCom.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.colUseCom.HeaderText = "Use";
			this.colUseCom.IndeterminateValue = "";
			this.colUseCom.Name = "colUseCom";
			this.colUseCom.ToolTipText = "Enable running this client DLL";
			this.colUseCom.Width = 39;
			this.colComDll.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colComDll.HeaderText = "Communication DLL";
			this.colComDll.Name = "colComDll";
			this.colComDll.ToolTipText = "Select client DLL here";
			this.colBrowseComDll.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle4.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = global::System.Drawing.Color.Silver;
			dataGridViewCellStyle4.ForeColor = global::System.Drawing.Color.Black;
			dataGridViewCellStyle4.NullValue = "...";
			this.colBrowseComDll.DefaultCellStyle = dataGridViewCellStyle4;
			this.colBrowseComDll.HeaderText = "";
			this.colBrowseComDll.Name = "colBrowseComDll";
			this.colBrowseComDll.ReadOnly = true;
			this.colBrowseComDll.Text = "...";
			this.colBrowseComDll.ToolTipText = "Browse for a Communication DLL";
			this.colBrowseComDll.Width = 31;
			this.colComXml.HeaderText = "Defualt Xml";
			this.colComXml.Name = "colComXml";
			this.colComXml.Width = 130;
			this.colBrowseComXml.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle5.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.NullValue = "...";
			this.colBrowseComXml.DefaultCellStyle = dataGridViewCellStyle5;
			this.colBrowseComXml.HeaderText = "";
			this.colBrowseComXml.MinimumWidth = 31;
			this.colBrowseComXml.Name = "colBrowseComXml";
			this.colBrowseComXml.ReadOnly = true;
			this.colBrowseComXml.Text = "...";
			this.colBrowseComXml.ToolTipText = "Browse for a Communication Xml";
			this.colBrowseComXml.Width = 31;
			this.tpPaths.Controls.Add(this.m_PathsTabLabel);
			this.tpPaths.Controls.Add(this.m_ConfigGrpBox);
			this.tpPaths.Controls.Add(this.m_OutputGrpBox);
			this.tpPaths.Controls.Add(this.m_InputGrpBox);
			this.tpPaths.Controls.Add(this.flowLayoutPanel1);
			this.tpPaths.Location = new global::System.Drawing.Point(4, 25);
			this.tpPaths.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tpPaths.Name = "tpPaths";
			this.tpPaths.Size = new global::System.Drawing.Size(763, 436);
			this.tpPaths.TabIndex = 2;
			this.tpPaths.Text = "Paths";
			this.tpPaths.UseVisualStyleBackColor = true;
			this.m_PathsTabLabel.Location = new global::System.Drawing.Point(48, 48);
			this.m_PathsTabLabel.Name = "m_PathsTabLabel";
			this.m_PathsTabLabel.Size = new global::System.Drawing.Size(433, 23);
			this.m_PathsTabLabel.TabIndex = 3;
			this.m_PathsTabLabel.Text = "Folder paths for RTTT GUI and client to load/save files.";
			this.m_ConfigGrpBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_ConfigGrpBox.Controls.Add(this.m_ConfigPathBrowseBtn);
			this.m_ConfigGrpBox.Controls.Add(this.m_ConfigPathComboBox);
			this.m_ConfigGrpBox.Location = new global::System.Drawing.Point(51, 234);
			this.m_ConfigGrpBox.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_ConfigGrpBox.Name = "m_ConfigGrpBox";
			this.m_ConfigGrpBox.Padding = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_ConfigGrpBox.Size = new global::System.Drawing.Size(634, 74);
			this.m_ConfigGrpBox.TabIndex = 2;
			this.m_ConfigGrpBox.TabStop = false;
			this.m_ConfigGrpBox.Text = "Config";
			this.m_ConfigPathBrowseBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_ConfigPathBrowseBtn.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.m_ConfigPathBrowseBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_ConfigPathBrowseBtn.Image");
			this.m_ConfigPathBrowseBtn.Location = new global::System.Drawing.Point(602, 30);
			this.m_ConfigPathBrowseBtn.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_ConfigPathBrowseBtn.Name = "m_ConfigPathBrowseBtn";
			this.m_ConfigPathBrowseBtn.Size = new global::System.Drawing.Size(27, 25);
			this.m_ConfigPathBrowseBtn.TabIndex = 5;
			this.m_ConfigPathBrowseBtn.UseVisualStyleBackColor = true;
			this.m_ConfigPathBrowseBtn.Click += new global::System.EventHandler(this.m_ConfigPathBrowseBtn_Click);
			this.m_ConfigPathComboBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_ConfigPathComboBox.FormattingEnabled = true;
			this.m_ConfigPathComboBox.Location = new global::System.Drawing.Point(5, 31);
			this.m_ConfigPathComboBox.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_ConfigPathComboBox.Name = "m_ConfigPathComboBox";
			this.m_ConfigPathComboBox.Size = new global::System.Drawing.Size(590, 24);
			this.m_ConfigPathComboBox.TabIndex = 4;
			this.m_OutputGrpBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_OutputGrpBox.Controls.Add(this.m_OutputPathBrowseBtn);
			this.m_OutputGrpBox.Controls.Add(this.m_OutputPathComboBox);
			this.m_OutputGrpBox.Location = new global::System.Drawing.Point(51, 154);
			this.m_OutputGrpBox.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_OutputGrpBox.Name = "m_OutputGrpBox";
			this.m_OutputGrpBox.Padding = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_OutputGrpBox.Size = new global::System.Drawing.Size(634, 74);
			this.m_OutputGrpBox.TabIndex = 1;
			this.m_OutputGrpBox.TabStop = false;
			this.m_OutputGrpBox.Text = "Output";
			this.m_OutputPathBrowseBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_OutputPathBrowseBtn.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.m_OutputPathBrowseBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_OutputPathBrowseBtn.Image");
			this.m_OutputPathBrowseBtn.Location = new global::System.Drawing.Point(602, 30);
			this.m_OutputPathBrowseBtn.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_OutputPathBrowseBtn.Name = "m_OutputPathBrowseBtn";
			this.m_OutputPathBrowseBtn.Size = new global::System.Drawing.Size(27, 25);
			this.m_OutputPathBrowseBtn.TabIndex = 3;
			this.m_OutputPathBrowseBtn.UseVisualStyleBackColor = true;
			this.m_OutputPathBrowseBtn.Click += new global::System.EventHandler(this.m_OutputPathBrowseBtn_Click);
			this.m_OutputPathComboBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_OutputPathComboBox.FormattingEnabled = true;
			this.m_OutputPathComboBox.Location = new global::System.Drawing.Point(5, 30);
			this.m_OutputPathComboBox.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_OutputPathComboBox.Name = "m_OutputPathComboBox";
			this.m_OutputPathComboBox.Size = new global::System.Drawing.Size(590, 24);
			this.m_OutputPathComboBox.TabIndex = 2;
			this.m_InputGrpBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_InputGrpBox.Controls.Add(this.m_InputPathBrowseBtn);
			this.m_InputGrpBox.Controls.Add(this.m_InputPathComboBox);
			this.m_InputGrpBox.Location = new global::System.Drawing.Point(51, 74);
			this.m_InputGrpBox.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_InputGrpBox.Name = "m_InputGrpBox";
			this.m_InputGrpBox.Padding = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_InputGrpBox.Size = new global::System.Drawing.Size(634, 74);
			this.m_InputGrpBox.TabIndex = 0;
			this.m_InputGrpBox.TabStop = false;
			this.m_InputGrpBox.Text = "Input";
			this.m_InputPathBrowseBtn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_InputPathBrowseBtn.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.m_InputPathBrowseBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_InputPathBrowseBtn.Image");
			this.m_InputPathBrowseBtn.Location = new global::System.Drawing.Point(602, 32);
			this.m_InputPathBrowseBtn.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_InputPathBrowseBtn.Name = "m_InputPathBrowseBtn";
			this.m_InputPathBrowseBtn.Size = new global::System.Drawing.Size(27, 25);
			this.m_InputPathBrowseBtn.TabIndex = 1;
			this.m_InputPathBrowseBtn.UseVisualStyleBackColor = true;
			this.m_InputPathBrowseBtn.Click += new global::System.EventHandler(this.m_InputPathBrowseBtn_Click);
			this.m_InputPathComboBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_InputPathComboBox.FormattingEnabled = true;
			this.m_InputPathComboBox.Location = new global::System.Drawing.Point(5, 32);
			this.m_InputPathComboBox.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_InputPathComboBox.Name = "m_InputPathComboBox";
			this.m_InputPathComboBox.Size = new global::System.Drawing.Size(590, 24);
			this.m_InputPathComboBox.TabIndex = 0;
			this.flowLayoutPanel1.Location = new global::System.Drawing.Point(51, 74);
			this.flowLayoutPanel1.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new global::System.Drawing.Size(620, 234);
			this.flowLayoutPanel1.TabIndex = 0;
			this.tpScripter.Controls.Add(this.m_ScripterTabLabel);
			this.tpScripter.Controls.Add(this.m_ScripterVerboseModeCheckBox);
			this.tpScripter.Location = new global::System.Drawing.Point(4, 25);
			this.tpScripter.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tpScripter.Name = "tpScripter";
			this.tpScripter.Size = new global::System.Drawing.Size(763, 436);
			this.tpScripter.TabIndex = 4;
			this.tpScripter.Text = "Scripter";
			this.tpScripter.UseVisualStyleBackColor = true;
			this.m_ScripterTabLabel.Location = new global::System.Drawing.Point(48, 48);
			this.m_ScripterTabLabel.Name = "m_ScripterTabLabel";
			this.m_ScripterTabLabel.Size = new global::System.Drawing.Size(532, 59);
			this.m_ScripterTabLabel.TabIndex = 1;
			this.m_ScripterTabLabel.Text = "Verbose mode generates the equivalent script line for eacho GUI operation.\r\nThe line will be displayed in the console as well as recorded into the log.";
			this.m_ScripterVerboseModeCheckBox.AccessibleName = "VerboseScriptMode";
			this.m_ScripterVerboseModeCheckBox.AccessibleRole = global::System.Windows.Forms.AccessibleRole.CheckButton;
			this.m_ScripterVerboseModeCheckBox.AutoSize = true;
			this.m_ScripterVerboseModeCheckBox.Location = new global::System.Drawing.Point(51, 110);
			this.m_ScripterVerboseModeCheckBox.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			this.m_ScripterVerboseModeCheckBox.Name = "m_ScripterVerboseModeCheckBox";
			this.m_ScripterVerboseModeCheckBox.Size = new global::System.Drawing.Size(122, 21);
			this.m_ScripterVerboseModeCheckBox.TabIndex = 0;
			this.m_ScripterVerboseModeCheckBox.Text = "Verbose mode";
			this.m_ScripterVerboseModeCheckBox.UseVisualStyleBackColor = true;
			this.m_BottomToolStrip.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.m_BottomToolStrip.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.m_BottomToolStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_BottomToolStripOkBtn,
				this.m_ToolStripSeparator1,
				this.m_BottomToolStripCancelBtn,
				this.m_ToolStripSeparator2,
				this.m_SaveAsBtn,
				this.m_ToolStripSeparator3,
				this.m_LoadBtn,
				this.m_ToolStripSeparator4
			});
			this.m_BottomToolStrip.Location = new global::System.Drawing.Point(0, 438);
			this.m_BottomToolStrip.Name = "m_BottomToolStrip";
			this.m_BottomToolStrip.Size = new global::System.Drawing.Size(771, 27);
			this.m_BottomToolStrip.TabIndex = 1;
			this.m_BottomToolStrip.Text = "toolStrip1";
			this.m_BottomToolStripOkBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_BottomToolStripOkBtn.Image");
			this.m_BottomToolStripOkBtn.ImageTransparentColor = global::System.Drawing.Color.White;
			this.m_BottomToolStripOkBtn.Name = "m_BottomToolStripOkBtn";
			this.m_BottomToolStripOkBtn.Size = new global::System.Drawing.Size(48, 24);
			this.m_BottomToolStripOkBtn.Text = "OK";
			this.m_BottomToolStripOkBtn.ToolTipText = "Accept changes";
			this.m_BottomToolStripOkBtn.Click += new global::System.EventHandler(this.m_BottomToolStripOkBtn_Click);
			this.m_ToolStripSeparator1.Name = "m_ToolStripSeparator1";
			this.m_ToolStripSeparator1.Size = new global::System.Drawing.Size(6, 27);
			this.m_BottomToolStripCancelBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_BottomToolStripCancelBtn.Image");
			this.m_BottomToolStripCancelBtn.ImageTransparentColor = global::System.Drawing.Color.White;
			this.m_BottomToolStripCancelBtn.Name = "m_BottomToolStripCancelBtn";
			this.m_BottomToolStripCancelBtn.Size = new global::System.Drawing.Size(70, 24);
			this.m_BottomToolStripCancelBtn.Text = "Cancel";
			this.m_BottomToolStripCancelBtn.ToolTipText = "Ignore changes";
			this.m_BottomToolStripCancelBtn.Click += new global::System.EventHandler(this.m_BottomToolStripCancelBtn_Click);
			this.m_ToolStripSeparator2.Name = "m_ToolStripSeparator2";
			this.m_ToolStripSeparator2.Size = new global::System.Drawing.Size(6, 27);
			this.m_SaveAsBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_SaveAsBtn.Image");
			this.m_SaveAsBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_SaveAsBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_SaveAsBtn.Name = "m_SaveAsBtn";
			this.m_SaveAsBtn.Size = new global::System.Drawing.Size(85, 24);
			this.m_SaveAsBtn.Text = "Save As";
			this.m_SaveAsBtn.ToolTipText = "Save to a different file name";
			this.m_SaveAsBtn.Click += new global::System.EventHandler(this.m_SaveBtn_Click);
			this.m_ToolStripSeparator3.Name = "m_ToolStripSeparator3";
			this.m_ToolStripSeparator3.Size = new global::System.Drawing.Size(6, 27);
			this.m_LoadBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_LoadBtn.Image");
			this.m_LoadBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_LoadBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_LoadBtn.Name = "m_LoadBtn";
			this.m_LoadBtn.Size = new global::System.Drawing.Size(61, 24);
			this.m_LoadBtn.Text = "Load";
			this.m_LoadBtn.ToolTipText = "Load from a different file name";
			this.m_LoadBtn.Click += new global::System.EventHandler(this.m_LoadBtn_Click);
			this.m_ToolStripSeparator4.Name = "m_ToolStripSeparator4";
			this.m_ToolStripSeparator4.Size = new global::System.Drawing.Size(6, 27);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(771, 465);
			base.Controls.Add(this.m_BottomToolStrip);
			base.Controls.Add(this.m_TabControl);
			base.Margin = new global::System.Windows.Forms.Padding(3, 2, 3, 2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SettingsForm";
			base.ShowInTaskbar = false;
			this.Text = "Settings";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
			this.m_TabControl.ResumeLayout(false);
			this.tpClients.ResumeLayout(false);
			this.grpClient.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dgvClientDlls).EndInit();
			this.tpCom.ResumeLayout(false);
			this.grpCom.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dgvComDlls).EndInit();
			this.tpPaths.ResumeLayout(false);
			this.m_ConfigGrpBox.ResumeLayout(false);
			this.m_OutputGrpBox.ResumeLayout(false);
			this.m_InputGrpBox.ResumeLayout(false);
			this.tpScripter.ResumeLayout(false);
			this.tpScripter.PerformLayout();
			this.m_BottomToolStrip.ResumeLayout(false);
			this.m_BottomToolStrip.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.TabControl m_TabControl;


		private global::System.Windows.Forms.TabPage tpClients;


		private global::System.Windows.Forms.TabPage tpPaths;


		private global::System.Windows.Forms.TabPage tpScripter;


		private global::System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;


		private global::System.Windows.Forms.GroupBox m_InputGrpBox;


		private global::System.Windows.Forms.GroupBox m_ConfigGrpBox;


		private global::System.Windows.Forms.GroupBox m_OutputGrpBox;


		private global::System.Windows.Forms.ComboBox m_InputPathComboBox;


		private global::System.Windows.Forms.Button m_InputPathBrowseBtn;


		private global::System.Windows.Forms.Button m_OutputPathBrowseBtn;


		private global::System.Windows.Forms.ComboBox m_OutputPathComboBox;


		private global::System.Windows.Forms.Button m_ConfigPathBrowseBtn;


		private global::System.Windows.Forms.ComboBox m_ConfigPathComboBox;


		private global::System.Windows.Forms.Label m_ScripterTabLabel;


		private global::System.Windows.Forms.CheckBox m_ScripterVerboseModeCheckBox;


		private global::System.Windows.Forms.Label m_PathsTabLabel;


		private global::System.Windows.Forms.Label m_ClientsTabLabel;


		private global::RSTD.ToolStripEx m_BottomToolStrip;


		private global::System.Windows.Forms.ToolStripButton m_BottomToolStripOkBtn;


		private global::System.Windows.Forms.ToolStripButton m_BottomToolStripCancelBtn;


		private global::System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator1;


		private global::System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator2;


		private global::System.Windows.Forms.ToolStripButton m_SaveAsBtn;


		private global::System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator3;


		private global::System.Windows.Forms.ToolStripButton m_LoadBtn;


		private global::System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator4;


		private global::System.Windows.Forms.GroupBox grpClient;


		private global::System.Windows.Forms.DataGridView dgvClientDlls;


		private global::System.Windows.Forms.TabPage tpCom;


		private global::System.Windows.Forms.Label label1;


		private global::System.Windows.Forms.GroupBox grpCom;


		private global::System.Windows.Forms.DataGridView dgvComDlls;


		private global::System.Windows.Forms.DataGridViewCheckBoxColumn colUseCom;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colComDll;


		private global::System.Windows.Forms.DataGridViewButtonColumn colBrowseComDll;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colComXml;


		private global::System.Windows.Forms.DataGridViewButtonColumn colBrowseComXml;


		private global::System.Windows.Forms.DataGridViewCheckBoxColumn colUseClient;


		private global::System.Windows.Forms.DataGridViewComboBoxColumn colPriority;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colClientDll;


		private global::System.Windows.Forms.DataGridViewButtonColumn colBrowseClientDll;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colClientXml;


		private global::System.Windows.Forms.DataGridViewButtonColumn colBrowseClientXml;
	}
}
