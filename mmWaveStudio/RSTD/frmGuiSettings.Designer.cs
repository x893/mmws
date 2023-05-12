namespace RSTD
{

	public partial class frmGuiSettings : global::System.Windows.Forms.Form
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
			this.components = new global::System.ComponentModel.Container();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.frmGuiSettings));
			this.checkBox2 = new global::System.Windows.Forms.CheckBox();
			this.checkedListBox5 = new global::System.Windows.Forms.CheckedListBox();
			this.checkedListBox6 = new global::System.Windows.Forms.CheckedListBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.checkBox3 = new global::System.Windows.Forms.CheckBox();
			this.checkedListBox7 = new global::System.Windows.Forms.CheckedListBox();
			this.checkedListBox8 = new global::System.Windows.Forms.CheckedListBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.tabPageView = new global::System.Windows.Forms.TabPage();
			this.m_lblToolBars = new global::System.Windows.Forms.Label();
			this.m_lblWindows = new global::System.Windows.Forms.Label();
			this.m_chkViewStatus = new global::System.Windows.Forms.CheckBox();
			this.m_chklbViewToolBars = new global::System.Windows.Forms.CheckedListBox();
			this.m_chklbViewWindows = new global::System.Windows.Forms.CheckedListBox();
			this.tabPageBrowseTree = new global::System.Windows.Forms.TabPage();
			this.m_grpDisplayTypes = new global::System.Windows.Forms.GroupBox();
			this.lblFields = new global::System.Windows.Forms.Label();
			this.m_cboFieldDefDisplay = new global::System.Windows.Forms.ComboBox();
			this.lblRegister = new global::System.Windows.Forms.Label();
			this.m_cboRegDefDisplay = new global::System.Windows.Forms.ComboBox();
			this.m_btnBTMoveDown = new global::System.Windows.Forms.Button();
			this.m_btnBTMoveUp = new global::System.Windows.Forms.Button();
			this.m_chkBTSortClmns = new global::System.Windows.Forms.CheckBox();
			this.m_lblBTColumns = new global::System.Windows.Forms.Label();
			this.m_chklbBTColumns = new global::System.Windows.Forms.CheckedListBox();
			this.btn_Cancel = new global::System.Windows.Forms.Button();
			this.btn_OK = new global::System.Windows.Forms.Button();
			this.m_tbC = new global::System.Windows.Forms.TabControl();
			this.tabPageWorkSet = new global::System.Windows.Forms.TabPage();
			this.m_chkShowFunc = new global::System.Windows.Forms.CheckBox();
			this.m_chkWSSortClmns = new global::System.Windows.Forms.CheckBox();
			this.m_btnWSMoveDown = new global::System.Windows.Forms.Button();
			this.m_btnWSMoveUp = new global::System.Windows.Forms.Button();
			this.m_lbWSColumns = new global::System.Windows.Forms.Label();
			this.m_chklbWSColumns = new global::System.Windows.Forms.CheckedListBox();
			this.tpToolBars = new global::System.Windows.Forms.TabPage();
			this.grpStandardBtns = new global::System.Windows.Forms.GroupBox();
			this.rdoSmallButtons = new global::System.Windows.Forms.RadioButton();
			this.m_lstStandardBtns = new global::System.Windows.Forms.ListView();
			this.label1 = new global::System.Windows.Forms.Label();
			this.rdoLargeButtons = new global::System.Windows.Forms.RadioButton();
			this.grpUserBtns = new global::System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.m_dgvUserButtons = new global::System.Windows.Forms.DataGridView();
			this.colShow = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.colIcon = new global::System.Windows.Forms.DataGridViewImageColumn();
			this.colorColumn = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTitle = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colToolTip = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sourceTypeColumn = new global::System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colScript = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colBrowse = new global::System.Windows.Forms.DataGridViewButtonColumn();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.toolBarsComboBox = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.m_imglistTabs = new global::System.Windows.Forms.ImageList(this.components);
			this.m_chktxtSaveDisplayAs = new global::System.Windows.Forms.CheckBox();
			this.m_fadeOutSplashcheckBox = new global::System.Windows.Forms.CheckBox();
			this.pathlinkLabel = new global::System.Windows.Forms.LinkLabel();
			this.m_lblConfigPath = new global::System.Windows.Forms.Label();
			this.tabPageGeneral = new global::System.Windows.Forms.TabPage();
			this.tabPageView.SuspendLayout();
			this.tabPageBrowseTree.SuspendLayout();
			this.m_grpDisplayTypes.SuspendLayout();
			this.m_tbC.SuspendLayout();
			this.tabPageWorkSet.SuspendLayout();
			this.tpToolBars.SuspendLayout();
			this.grpStandardBtns.SuspendLayout();
			this.grpUserBtns.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.m_dgvUserButtons).BeginInit();
			this.panel1.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			base.SuspendLayout();
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new global::System.Drawing.Point(8, 250);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox2.TabIndex = 9;
			this.checkBox2.Text = "Status Bar";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkedListBox5.Font = new global::System.Drawing.Font("Times New Roman", 7.333333f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkedListBox5.FormattingEnabled = true;
			this.checkedListBox5.Items.AddRange(new object[]
			{
				"ToolBars",
				"Standard",
				"User Buttons",
				"Script"
			});
			this.checkedListBox5.Location = new global::System.Drawing.Point(7, 154);
			this.checkedListBox5.Name = "checkedListBox5";
			this.checkedListBox5.Size = new global::System.Drawing.Size(103, 60);
			this.checkedListBox5.TabIndex = 8;
			this.checkedListBox6.Font = new global::System.Drawing.Font("Times New Roman", 7.333333f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkedListBox6.FormattingEnabled = true;
			this.checkedListBox6.Items.AddRange(new object[]
			{
				"Output",
				"BrowseTree",
				"WorkSet",
				"Monitors",
				"LuaShell"
			});
			this.checkedListBox6.Location = new global::System.Drawing.Point(7, 47);
			this.checkedListBox6.Name = "checkedListBox6";
			this.checkedListBox6.Size = new global::System.Drawing.Size(103, 74);
			this.checkedListBox6.TabIndex = 7;
			this.label4.AutoSize = true;
			this.label4.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.label4.Location = new global::System.Drawing.Point(4, 19);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(33, 15);
			this.label4.TabIndex = 6;
			this.label4.Text = "View";
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new global::System.Drawing.Point(8, 250);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox3.TabIndex = 9;
			this.checkBox3.Text = "Status Bar";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkedListBox7.Font = new global::System.Drawing.Font("Times New Roman", 7.333333f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkedListBox7.FormattingEnabled = true;
			this.checkedListBox7.Items.AddRange(new object[]
			{
				"ToolBars",
				"Standard",
				"User Buttons",
				"Script"
			});
			this.checkedListBox7.Location = new global::System.Drawing.Point(7, 154);
			this.checkedListBox7.Name = "checkedListBox7";
			this.checkedListBox7.Size = new global::System.Drawing.Size(103, 60);
			this.checkedListBox7.TabIndex = 8;
			this.checkedListBox8.Font = new global::System.Drawing.Font("Times New Roman", 7.333333f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkedListBox8.FormattingEnabled = true;
			this.checkedListBox8.Items.AddRange(new object[]
			{
				"Output",
				"BrowseTree",
				"WorkSet",
				"Monitors",
				"LuaShell"
			});
			this.checkedListBox8.Location = new global::System.Drawing.Point(7, 47);
			this.checkedListBox8.Name = "checkedListBox8";
			this.checkedListBox8.Size = new global::System.Drawing.Size(103, 74);
			this.checkedListBox8.TabIndex = 7;
			this.label5.AutoSize = true;
			this.label5.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.label5.Location = new global::System.Drawing.Point(4, 19);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(33, 15);
			this.label5.TabIndex = 6;
			this.label5.Text = "View";
			this.tabPageView.Controls.Add(this.m_lblToolBars);
			this.tabPageView.Controls.Add(this.m_lblWindows);
			this.tabPageView.Controls.Add(this.m_chkViewStatus);
			this.tabPageView.Controls.Add(this.m_chklbViewToolBars);
			this.tabPageView.Controls.Add(this.m_chklbViewWindows);
			this.tabPageView.ImageIndex = 2;
			this.tabPageView.Location = new global::System.Drawing.Point(4, 23);
			this.tabPageView.Name = "tabPageView";
			this.tabPageView.Size = new global::System.Drawing.Size(621, 332);
			this.tabPageView.TabIndex = 2;
			this.tabPageView.Text = "View";
			this.tabPageView.UseVisualStyleBackColor = true;
			this.m_lblToolBars.AutoSize = true;
			this.m_lblToolBars.Font = new global::System.Drawing.Font("Georgia", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.m_lblToolBars.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.m_lblToolBars.Location = new global::System.Drawing.Point(9, 159);
			this.m_lblToolBars.Name = "m_lblToolBars";
			this.m_lblToolBars.Size = new global::System.Drawing.Size(74, 16);
			this.m_lblToolBars.TabIndex = 12;
			this.m_lblToolBars.Text = "ToolBars";
			this.m_lblWindows.AutoSize = true;
			this.m_lblWindows.Font = new global::System.Drawing.Font("Georgia", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.m_lblWindows.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.m_lblWindows.Location = new global::System.Drawing.Point(9, 18);
			this.m_lblWindows.Name = "m_lblWindows";
			this.m_lblWindows.Size = new global::System.Drawing.Size(74, 16);
			this.m_lblWindows.TabIndex = 11;
			this.m_lblWindows.Text = "Windows";
			this.m_chkViewStatus.AutoSize = true;
			this.m_chkViewStatus.BackColor = global::System.Drawing.SystemColors.InactiveCaptionText;
			this.m_chkViewStatus.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_chkViewStatus.Location = new global::System.Drawing.Point(18, 260);
			this.m_chkViewStatus.Name = "m_chkViewStatus";
			this.m_chkViewStatus.Size = new global::System.Drawing.Size(92, 20);
			this.m_chkViewStatus.TabIndex = 10;
			this.m_chkViewStatus.Text = "Status Bar";
			this.m_chkViewStatus.UseVisualStyleBackColor = false;
			this.m_chklbViewToolBars.BackColor = global::System.Drawing.SystemColors.Window;
			this.m_chklbViewToolBars.CheckOnClick = true;
			this.m_chklbViewToolBars.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_chklbViewToolBars.ForeColor = global::System.Drawing.Color.MidnightBlue;
			this.m_chklbViewToolBars.FormattingEnabled = true;
			this.m_chklbViewToolBars.Items.AddRange(new object[]
			{
				"Standard",
				"User Buttons",
				"Script"
			});
			this.m_chklbViewToolBars.Location = new global::System.Drawing.Point(9, 179);
			this.m_chklbViewToolBars.Name = "m_chklbViewToolBars";
			this.m_chklbViewToolBars.Size = new global::System.Drawing.Size(119, 55);
			this.m_chklbViewToolBars.TabIndex = 9;
			this.m_chklbViewWindows.BackColor = global::System.Drawing.SystemColors.Window;
			this.m_chklbViewWindows.CheckOnClick = true;
			this.m_chklbViewWindows.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 178);
			this.m_chklbViewWindows.ForeColor = global::System.Drawing.Color.MidnightBlue;
			this.m_chklbViewWindows.FormattingEnabled = true;
			this.m_chklbViewWindows.Items.AddRange(new object[]
			{
				"Output",
				"BrowseTree",
				"WorkSet",
				"Monitors",
				"LuaShell"
			});
			this.m_chklbViewWindows.Location = new global::System.Drawing.Point(9, 42);
			this.m_chklbViewWindows.Name = "m_chklbViewWindows";
			this.m_chklbViewWindows.Size = new global::System.Drawing.Size(119, 89);
			this.m_chklbViewWindows.TabIndex = 8;
			this.tabPageBrowseTree.Controls.Add(this.m_grpDisplayTypes);
			this.tabPageBrowseTree.Controls.Add(this.m_btnBTMoveDown);
			this.tabPageBrowseTree.Controls.Add(this.m_btnBTMoveUp);
			this.tabPageBrowseTree.Controls.Add(this.m_chkBTSortClmns);
			this.tabPageBrowseTree.Controls.Add(this.m_lblBTColumns);
			this.tabPageBrowseTree.Controls.Add(this.m_chklbBTColumns);
			this.tabPageBrowseTree.ImageIndex = 1;
			this.tabPageBrowseTree.Location = new global::System.Drawing.Point(4, 23);
			this.tabPageBrowseTree.Name = "tabPageBrowseTree";
			this.tabPageBrowseTree.Size = new global::System.Drawing.Size(621, 332);
			this.tabPageBrowseTree.TabIndex = 1;
			this.tabPageBrowseTree.Text = "BrowseTree";
			this.tabPageBrowseTree.UseVisualStyleBackColor = true;
			this.m_grpDisplayTypes.Controls.Add(this.lblFields);
			this.m_grpDisplayTypes.Controls.Add(this.m_cboFieldDefDisplay);
			this.m_grpDisplayTypes.Controls.Add(this.lblRegister);
			this.m_grpDisplayTypes.Controls.Add(this.m_cboRegDefDisplay);
			this.m_grpDisplayTypes.Location = new global::System.Drawing.Point(313, 38);
			this.m_grpDisplayTypes.Name = "m_grpDisplayTypes";
			this.m_grpDisplayTypes.Size = new global::System.Drawing.Size(181, 110);
			this.m_grpDisplayTypes.TabIndex = 9;
			this.m_grpDisplayTypes.TabStop = false;
			this.m_grpDisplayTypes.Text = "Default Display Types";
			this.lblFields.AutoSize = true;
			this.lblFields.Location = new global::System.Drawing.Point(16, 68);
			this.lblFields.Name = "lblFields";
			this.lblFields.Size = new global::System.Drawing.Size(37, 13);
			this.lblFields.TabIndex = 3;
			this.lblFields.Text = "Fields:";
			this.m_cboFieldDefDisplay.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFieldDefDisplay.FormattingEnabled = true;
			this.m_cboFieldDefDisplay.Items.AddRange(new object[]
			{
				"Dec",
				"Hex",
				"Bin"
			});
			this.m_cboFieldDefDisplay.Location = new global::System.Drawing.Point(73, 64);
			this.m_cboFieldDefDisplay.Name = "m_cboFieldDefDisplay";
			this.m_cboFieldDefDisplay.Size = new global::System.Drawing.Size(81, 21);
			this.m_cboFieldDefDisplay.TabIndex = 2;
			this.lblRegister.AutoSize = true;
			this.lblRegister.Location = new global::System.Drawing.Point(16, 35);
			this.lblRegister.Name = "lblRegister";
			this.lblRegister.Size = new global::System.Drawing.Size(54, 13);
			this.lblRegister.TabIndex = 1;
			this.lblRegister.Text = "Registers:";
			this.m_cboRegDefDisplay.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboRegDefDisplay.FormattingEnabled = true;
			this.m_cboRegDefDisplay.Items.AddRange(new object[]
			{
				"Dec",
				"Hex",
				"Bin"
			});
			this.m_cboRegDefDisplay.Location = new global::System.Drawing.Point(73, 31);
			this.m_cboRegDefDisplay.Name = "m_cboRegDefDisplay";
			this.m_cboRegDefDisplay.Size = new global::System.Drawing.Size(81, 21);
			this.m_cboRegDefDisplay.TabIndex = 0;
			this.m_btnBTMoveDown.BackColor = global::System.Drawing.SystemColors.Control;
			this.m_btnBTMoveDown.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.m_btnBTMoveDown.ForeColor = global::System.Drawing.Color.Navy;
			this.m_btnBTMoveDown.Location = new global::System.Drawing.Point(193, 77);
			this.m_btnBTMoveDown.Name = "m_btnBTMoveDown";
			this.m_btnBTMoveDown.Size = new global::System.Drawing.Size(94, 33);
			this.m_btnBTMoveDown.TabIndex = 8;
			this.m_btnBTMoveDown.Text = "Move Down";
			this.m_btnBTMoveDown.UseVisualStyleBackColor = true;
			this.m_btnBTMoveDown.Click += new global::System.EventHandler(this.m_btnBTMoveDown_Click);
			this.m_btnBTMoveUp.BackColor = global::System.Drawing.SystemColors.Control;
			this.m_btnBTMoveUp.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.m_btnBTMoveUp.ForeColor = global::System.Drawing.Color.Navy;
			this.m_btnBTMoveUp.Location = new global::System.Drawing.Point(193, 38);
			this.m_btnBTMoveUp.Name = "m_btnBTMoveUp";
			this.m_btnBTMoveUp.Size = new global::System.Drawing.Size(94, 33);
			this.m_btnBTMoveUp.TabIndex = 7;
			this.m_btnBTMoveUp.Text = "Move Up";
			this.m_btnBTMoveUp.UseVisualStyleBackColor = true;
			this.m_btnBTMoveUp.Click += new global::System.EventHandler(this.m_btnBTMoveUp_Click);
			this.m_chkBTSortClmns.AutoSize = true;
			this.m_chkBTSortClmns.BackColor = global::System.Drawing.SystemColors.InactiveCaptionText;
			this.m_chkBTSortClmns.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_chkBTSortClmns.Location = new global::System.Drawing.Point(9, 277);
			this.m_chkBTSortClmns.Name = "m_chkBTSortClmns";
			this.m_chkBTSortClmns.Size = new global::System.Drawing.Size(174, 20);
			this.m_chkBTSortClmns.TabIndex = 6;
			this.m_chkBTSortClmns.Text = "Enable Column Sorting";
			this.m_chkBTSortClmns.UseVisualStyleBackColor = false;
			this.m_lblBTColumns.AutoSize = true;
			this.m_lblBTColumns.Font = new global::System.Drawing.Font("Georgia", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.m_lblBTColumns.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.m_lblBTColumns.Location = new global::System.Drawing.Point(9, 15);
			this.m_lblBTColumns.Name = "m_lblBTColumns";
			this.m_lblBTColumns.Size = new global::System.Drawing.Size(74, 16);
			this.m_lblBTColumns.TabIndex = 4;
			this.m_lblBTColumns.Text = "Columns";
			this.m_chklbBTColumns.BackColor = global::System.Drawing.SystemColors.Window;
			this.m_chklbBTColumns.CheckOnClick = true;
			this.m_chklbBTColumns.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_chklbBTColumns.ForeColor = global::System.Drawing.Color.MidnightBlue;
			this.m_chklbBTColumns.FormattingEnabled = true;
			this.m_chklbBTColumns.Items.AddRange(new object[]
			{
				"Name",
				"Value",
				"Length",
				"Address",
				"Start Bit",
				"Stop Bit",
				"Description"
			});
			this.m_chklbBTColumns.Location = new global::System.Drawing.Point(9, 38);
			this.m_chklbBTColumns.Name = "m_chklbBTColumns";
			this.m_chklbBTColumns.Size = new global::System.Drawing.Size(166, 225);
			this.m_chklbBTColumns.TabIndex = 2;
			this.m_chklbBTColumns.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.m_chklbBT_MouseClick);
			this.btn_Cancel.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.btn_Cancel.ForeColor = global::System.Drawing.Color.Navy;
			this.btn_Cancel.Location = new global::System.Drawing.Point(336, 369);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new global::System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 2;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new global::System.EventHandler(this.btn_Cancel_Click);
			this.btn_OK.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.btn_OK.ForeColor = global::System.Drawing.Color.Navy;
			this.btn_OK.Location = new global::System.Drawing.Point(218, 369);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.Size = new global::System.Drawing.Size(75, 23);
			this.btn_OK.TabIndex = 1;
			this.btn_OK.Text = "OK";
			this.btn_OK.UseVisualStyleBackColor = true;
			this.btn_OK.Click += new global::System.EventHandler(this.btn_OK_Click);
			this.m_tbC.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_tbC.Controls.Add(this.tabPageGeneral);
			this.m_tbC.Controls.Add(this.tabPageView);
			this.m_tbC.Controls.Add(this.tabPageBrowseTree);
			this.m_tbC.Controls.Add(this.tabPageWorkSet);
			this.m_tbC.Controls.Add(this.tpToolBars);
			this.m_tbC.ImageList = this.m_imglistTabs;
			this.m_tbC.Location = new global::System.Drawing.Point(2, 1);
			this.m_tbC.Name = "m_tbC";
			this.m_tbC.SelectedIndex = 0;
			this.m_tbC.Size = new global::System.Drawing.Size(629, 359);
			this.m_tbC.TabIndex = 0;
			this.tabPageWorkSet.Controls.Add(this.m_chkShowFunc);
			this.tabPageWorkSet.Controls.Add(this.m_chkWSSortClmns);
			this.tabPageWorkSet.Controls.Add(this.m_btnWSMoveDown);
			this.tabPageWorkSet.Controls.Add(this.m_btnWSMoveUp);
			this.tabPageWorkSet.Controls.Add(this.m_lbWSColumns);
			this.tabPageWorkSet.Controls.Add(this.m_chklbWSColumns);
			this.tabPageWorkSet.ImageIndex = 0;
			this.tabPageWorkSet.Location = new global::System.Drawing.Point(4, 23);
			this.tabPageWorkSet.Name = "tabPageWorkSet";
			this.tabPageWorkSet.Size = new global::System.Drawing.Size(621, 332);
			this.tabPageWorkSet.TabIndex = 3;
			this.tabPageWorkSet.Text = "WorkSet";
			this.tabPageWorkSet.UseVisualStyleBackColor = true;
			this.m_chkShowFunc.AutoSize = true;
			this.m_chkShowFunc.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.m_chkShowFunc.Location = new global::System.Drawing.Point(330, 38);
			this.m_chkShowFunc.Name = "m_chkShowFunc";
			this.m_chkShowFunc.Size = new global::System.Drawing.Size(134, 20);
			this.m_chkShowFunc.TabIndex = 15;
			this.m_chkShowFunc.Text = "Display functions";
			this.m_chkShowFunc.UseVisualStyleBackColor = true;
			this.m_chkWSSortClmns.AutoSize = true;
			this.m_chkWSSortClmns.BackColor = global::System.Drawing.SystemColors.InactiveCaptionText;
			this.m_chkWSSortClmns.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_chkWSSortClmns.Location = new global::System.Drawing.Point(9, 277);
			this.m_chkWSSortClmns.Name = "m_chkWSSortClmns";
			this.m_chkWSSortClmns.Size = new global::System.Drawing.Size(174, 20);
			this.m_chkWSSortClmns.TabIndex = 14;
			this.m_chkWSSortClmns.Text = "Enable Column Sorting";
			this.m_chkWSSortClmns.UseVisualStyleBackColor = false;
			this.m_btnWSMoveDown.BackColor = global::System.Drawing.SystemColors.Control;
			this.m_btnWSMoveDown.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_btnWSMoveDown.ForeColor = global::System.Drawing.Color.DarkBlue;
			this.m_btnWSMoveDown.Location = new global::System.Drawing.Point(193, 77);
			this.m_btnWSMoveDown.Name = "m_btnWSMoveDown";
			this.m_btnWSMoveDown.Size = new global::System.Drawing.Size(94, 33);
			this.m_btnWSMoveDown.TabIndex = 13;
			this.m_btnWSMoveDown.Text = "Move Down";
			this.m_btnWSMoveDown.UseVisualStyleBackColor = true;
			this.m_btnWSMoveDown.Click += new global::System.EventHandler(this.m_btnWSMoveDown_Click);
			this.m_btnWSMoveUp.BackColor = global::System.Drawing.SystemColors.Control;
			this.m_btnWSMoveUp.FlatAppearance.BorderColor = global::System.Drawing.Color.Blue;
			this.m_btnWSMoveUp.FlatAppearance.BorderSize = 5;
			this.m_btnWSMoveUp.Font = new global::System.Drawing.Font("Georgia", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_btnWSMoveUp.ForeColor = global::System.Drawing.Color.DarkBlue;
			this.m_btnWSMoveUp.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.m_btnWSMoveUp.Location = new global::System.Drawing.Point(193, 38);
			this.m_btnWSMoveUp.Name = "m_btnWSMoveUp";
			this.m_btnWSMoveUp.Size = new global::System.Drawing.Size(94, 33);
			this.m_btnWSMoveUp.TabIndex = 12;
			this.m_btnWSMoveUp.Text = "Move Up";
			this.m_btnWSMoveUp.UseVisualStyleBackColor = true;
			this.m_btnWSMoveUp.Click += new global::System.EventHandler(this.m_btnWSMoveUp_Click);
			this.m_lbWSColumns.AutoSize = true;
			this.m_lbWSColumns.Font = new global::System.Drawing.Font("Georgia", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.m_lbWSColumns.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			this.m_lbWSColumns.Location = new global::System.Drawing.Point(9, 15);
			this.m_lbWSColumns.Name = "m_lbWSColumns";
			this.m_lbWSColumns.Size = new global::System.Drawing.Size(74, 16);
			this.m_lbWSColumns.TabIndex = 11;
			this.m_lbWSColumns.Text = "Columns";
			this.m_chklbWSColumns.BackColor = global::System.Drawing.SystemColors.Window;
			this.m_chklbWSColumns.CheckOnClick = true;
			this.m_chklbWSColumns.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_chklbWSColumns.ForeColor = global::System.Drawing.Color.MidnightBlue;
			this.m_chklbWSColumns.FormattingEnabled = true;
			this.m_chklbWSColumns.Items.AddRange(new object[]
			{
				"Name",
				"Value",
				"Address",
				"Start Bit",
				"Stop Bit",
				"Description"
			});
			this.m_chklbWSColumns.Location = new global::System.Drawing.Point(9, 38);
			this.m_chklbWSColumns.Name = "m_chklbWSColumns";
			this.m_chklbWSColumns.Size = new global::System.Drawing.Size(166, 225);
			this.m_chklbWSColumns.TabIndex = 10;
			this.m_chklbWSColumns.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.m_chklbWS_MouseClick);
			this.tpToolBars.Controls.Add(this.grpStandardBtns);
			this.tpToolBars.Controls.Add(this.grpUserBtns);
			this.tpToolBars.Location = new global::System.Drawing.Point(4, 23);
			this.tpToolBars.Name = "tpToolBars";
			this.tpToolBars.Padding = new global::System.Windows.Forms.Padding(3);
			this.tpToolBars.Size = new global::System.Drawing.Size(621, 332);
			this.tpToolBars.TabIndex = 5;
			this.tpToolBars.Text = "ToolBars";
			this.tpToolBars.UseVisualStyleBackColor = true;
			this.grpStandardBtns.Controls.Add(this.rdoSmallButtons);
			this.grpStandardBtns.Controls.Add(this.m_lstStandardBtns);
			this.grpStandardBtns.Controls.Add(this.label1);
			this.grpStandardBtns.Controls.Add(this.rdoLargeButtons);
			this.grpStandardBtns.Location = new global::System.Drawing.Point(3, 6);
			this.grpStandardBtns.Name = "grpStandardBtns";
			this.grpStandardBtns.Size = new global::System.Drawing.Size(615, 114);
			this.grpStandardBtns.TabIndex = 3;
			this.grpStandardBtns.TabStop = false;
			this.grpStandardBtns.Text = "Standard Buttons";
			this.rdoSmallButtons.AutoSize = true;
			this.rdoSmallButtons.Location = new global::System.Drawing.Point(155, 88);
			this.rdoSmallButtons.Name = "rdoSmallButtons";
			this.rdoSmallButtons.Size = new global::System.Drawing.Size(50, 17);
			this.rdoSmallButtons.TabIndex = 10;
			this.rdoSmallButtons.TabStop = true;
			this.rdoSmallButtons.Text = "Small";
			this.rdoSmallButtons.UseVisualStyleBackColor = true;
			this.m_lstStandardBtns.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_lstStandardBtns.CheckBoxes = true;
			this.m_lstStandardBtns.Location = new global::System.Drawing.Point(3, 24);
			this.m_lstStandardBtns.Name = "m_lstStandardBtns";
			this.m_lstStandardBtns.Size = new global::System.Drawing.Size(609, 56);
			this.m_lstStandardBtns.TabIndex = 0;
			this.m_lstStandardBtns.UseCompatibleStateImageBehavior = false;
			this.m_lstStandardBtns.View = global::System.Windows.Forms.View.List;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(20, 90);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(64, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Button Size:";
			this.rdoLargeButtons.AutoSize = true;
			this.rdoLargeButtons.Location = new global::System.Drawing.Point(97, 88);
			this.rdoLargeButtons.Name = "rdoLargeButtons";
			this.rdoLargeButtons.Size = new global::System.Drawing.Size(52, 17);
			this.rdoLargeButtons.TabIndex = 9;
			this.rdoLargeButtons.TabStop = true;
			this.rdoLargeButtons.Text = "Large";
			this.rdoLargeButtons.UseVisualStyleBackColor = true;
			this.grpUserBtns.Controls.Add(this.tableLayoutPanel1);
			this.grpUserBtns.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.grpUserBtns.Location = new global::System.Drawing.Point(3, 126);
			this.grpUserBtns.Name = "grpUserBtns";
			this.grpUserBtns.Size = new global::System.Drawing.Size(615, 203);
			this.grpUserBtns.TabIndex = 2;
			this.grpUserBtns.TabStop = false;
			this.grpUserBtns.Text = "User Buttons";
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel1.Controls.Add(this.m_dgvUserButtons, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new global::System.Drawing.Point(3, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 15.76087f));
			this.tableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 84.23913f));
			this.tableLayoutPanel1.Size = new global::System.Drawing.Size(609, 184);
			this.tableLayoutPanel1.TabIndex = 2;
			this.m_dgvUserButtons.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_dgvUserButtons.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.colShow,
				this.colIcon,
				this.colorColumn,
				this.colTitle,
				this.colToolTip,
				this.sourceTypeColumn,
				this.colScript,
				this.colBrowse
			});
			this.m_dgvUserButtons.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.m_dgvUserButtons.EditMode = global::System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.m_dgvUserButtons.Location = new global::System.Drawing.Point(3, 32);
			this.m_dgvUserButtons.Name = "m_dgvUserButtons";
			this.m_dgvUserButtons.RowHeadersWidth = 30;
			this.m_dgvUserButtons.RowHeadersWidthSizeMode = global::System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.m_dgvUserButtons.Size = new global::System.Drawing.Size(603, 149);
			this.m_dgvUserButtons.TabIndex = 1;
			this.m_dgvUserButtons.CellContentClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dgvToolBarButtons_CellContentClick);
			this.m_dgvUserButtons.CellDoubleClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvUserButtons_CellDoubleClick);
			this.m_dgvUserButtons.RowsAdded += new global::System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvUserButtons_RowsAdded);
			this.m_dgvUserButtons.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.m_dgvUserButtons_KeyDown);
			this.colShow.HeaderText = "Show";
			this.colShow.MinimumWidth = 40;
			this.colShow.Name = "colShow";
			this.colShow.Width = 40;
			this.colIcon.HeaderText = "Icon";
			this.colIcon.ImageLayout = global::System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.colIcon.MinimumWidth = 35;
			this.colIcon.Name = "colIcon";
			this.colIcon.Resizable = global::System.Windows.Forms.DataGridViewTriState.False;
			this.colIcon.Width = 35;
			dataGridViewCellStyle.Padding = new global::System.Windows.Forms.Padding(10, 0, 10, 0);
			this.colorColumn.DefaultCellStyle = dataGridViewCellStyle;
			this.colorColumn.HeaderText = "Color";
			this.colorColumn.Name = "colorColumn";
			this.colorColumn.ReadOnly = true;
			this.colorColumn.Resizable = global::System.Windows.Forms.DataGridViewTriState.False;
			this.colorColumn.Width = 40;
			this.colTitle.HeaderText = "Title";
			this.colTitle.Name = "colTitle";
			this.colToolTip.HeaderText = "ToolTip";
			this.colToolTip.Name = "colToolTip";
			this.sourceTypeColumn.HeaderText = "Source Type";
			this.sourceTypeColumn.Items.AddRange(new object[]
			{
				"File",
				"Function",
				"Inline"
			});
			this.sourceTypeColumn.Name = "sourceTypeColumn";
			this.sourceTypeColumn.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.sourceTypeColumn.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.colScript.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colScript.HeaderText = "Script";
			this.colScript.Name = "colScript";
			dataGridViewCellStyle2.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.NullValue = "...";
			this.colBrowse.DefaultCellStyle = dataGridViewCellStyle2;
			this.colBrowse.HeaderText = "";
			this.colBrowse.MinimumWidth = 25;
			this.colBrowse.Name = "colBrowse";
			this.colBrowse.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.colBrowse.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.colBrowse.Text = "...";
			this.colBrowse.ToolTipText = "Browse For A Script...";
			this.colBrowse.Width = 25;
			this.panel1.Controls.Add(this.toolBarsComboBox);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(609, 29);
			this.panel1.TabIndex = 2;
			this.toolBarsComboBox.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.toolBarsComboBox.FormattingEnabled = true;
			this.toolBarsComboBox.Location = new global::System.Drawing.Point(218, 3);
			this.toolBarsComboBox.Name = "toolBarsComboBox";
			this.toolBarsComboBox.Size = new global::System.Drawing.Size(121, 21);
			this.toolBarsComboBox.TabIndex = 1;
			this.toolBarsComboBox.SelectedIndexChanged += new global::System.EventHandler(this.toolBarsComboBox_SelectedIndexChanged);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(130, 6);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(85, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Choose Toolbar:";
			this.m_imglistTabs.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("m_imglistTabs.ImageStream");
			this.m_imglistTabs.TransparentColor = global::System.Drawing.Color.Transparent;
			this.m_imglistTabs.Images.SetKeyName(0, "workset.png");
			this.m_imglistTabs.Images.SetKeyName(1, "folder_tree.gif");
			this.m_imglistTabs.Images.SetKeyName(2, "RadarLogo.png");
			this.m_chktxtSaveDisplayAs.AutoSize = true;
			this.m_chktxtSaveDisplayAs.BackColor = global::System.Drawing.SystemColors.InactiveCaptionText;
			this.m_chktxtSaveDisplayAs.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_chktxtSaveDisplayAs.Location = new global::System.Drawing.Point(20, 25);
			this.m_chktxtSaveDisplayAs.Name = "m_chktxtSaveDisplayAs";
			this.m_chktxtSaveDisplayAs.Size = new global::System.Drawing.Size(273, 20);
			this.m_chktxtSaveDisplayAs.TabIndex = 0;
			this.m_chktxtSaveDisplayAs.Text = "Save values in .txt with current display";
			this.m_chktxtSaveDisplayAs.UseVisualStyleBackColor = false;
			this.m_fadeOutSplashcheckBox.AutoSize = true;
			this.m_fadeOutSplashcheckBox.BackColor = global::System.Drawing.SystemColors.InactiveCaptionText;
			this.m_fadeOutSplashcheckBox.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_fadeOutSplashcheckBox.Location = new global::System.Drawing.Point(20, 70);
			this.m_fadeOutSplashcheckBox.Name = "m_fadeOutSplashcheckBox";
			this.m_fadeOutSplashcheckBox.Size = new global::System.Drawing.Size(240, 20);
			this.m_fadeOutSplashcheckBox.TabIndex = 1;
			this.m_fadeOutSplashcheckBox.Text = "Disable fade out of splash screen ";
			this.m_fadeOutSplashcheckBox.UseVisualStyleBackColor = false;
			this.pathlinkLabel.AutoSize = true;
			this.pathlinkLabel.Location = new global::System.Drawing.Point(17, 152);
			this.pathlinkLabel.Name = "pathlinkLabel";
			this.pathlinkLabel.Size = new global::System.Drawing.Size(0, 13);
			this.pathlinkLabel.TabIndex = 11;
			this.pathlinkLabel.TabStop = true;
			this.pathlinkLabel.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.pathlinkLabel_LinkClicked);
			this.m_lblConfigPath.AutoSize = true;
			this.m_lblConfigPath.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.m_lblConfigPath.Location = new global::System.Drawing.Point(17, 137);
			this.m_lblConfigPath.Name = "m_lblConfigPath";
			this.m_lblConfigPath.Size = new global::System.Drawing.Size(0, 13);
			this.m_lblConfigPath.TabIndex = 12;
			this.tabPageGeneral.Controls.Add(this.m_lblConfigPath);
			this.tabPageGeneral.Controls.Add(this.pathlinkLabel);
			this.tabPageGeneral.Controls.Add(this.m_fadeOutSplashcheckBox);
			this.tabPageGeneral.Controls.Add(this.m_chktxtSaveDisplayAs);
			this.tabPageGeneral.Location = new global::System.Drawing.Point(4, 23);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Size = new global::System.Drawing.Size(621, 332);
			this.tabPageGeneral.TabIndex = 4;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(634, 404);
			base.Controls.Add(this.btn_Cancel);
			base.Controls.Add(this.btn_OK);
			base.Controls.Add(this.m_tbC);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmGuiSettings";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Customize";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.frmGuiSettings_FormClosing);
			base.Load += new global::System.EventHandler(this.frmGuiSettings_Load);
			this.tabPageView.ResumeLayout(false);
			this.tabPageView.PerformLayout();
			this.tabPageBrowseTree.ResumeLayout(false);
			this.tabPageBrowseTree.PerformLayout();
			this.m_grpDisplayTypes.ResumeLayout(false);
			this.m_grpDisplayTypes.PerformLayout();
			this.m_tbC.ResumeLayout(false);
			this.tabPageWorkSet.ResumeLayout(false);
			this.tabPageWorkSet.PerformLayout();
			this.tpToolBars.ResumeLayout(false);
			this.grpStandardBtns.ResumeLayout(false);
			this.grpStandardBtns.PerformLayout();
			this.grpUserBtns.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.m_dgvUserButtons).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.CheckBox checkBox2;


		private global::System.Windows.Forms.CheckedListBox checkedListBox5;


		private global::System.Windows.Forms.CheckedListBox checkedListBox6;


		private global::System.Windows.Forms.Label label4;


		private global::System.Windows.Forms.CheckBox checkBox3;


		private global::System.Windows.Forms.CheckedListBox checkedListBox7;


		private global::System.Windows.Forms.CheckedListBox checkedListBox8;


		private global::System.Windows.Forms.Label label5;


		private global::System.Windows.Forms.TabPage tabPageView;


		private global::System.Windows.Forms.CheckedListBox m_chklbViewToolBars;


		private global::System.Windows.Forms.CheckedListBox m_chklbViewWindows;


		private global::System.Windows.Forms.TabPage tabPageBrowseTree;


		private global::System.Windows.Forms.Label m_lblBTColumns;


		private global::System.Windows.Forms.CheckedListBox m_chklbBTColumns;


		private global::System.Windows.Forms.TabControl m_tbC;


		private global::System.Windows.Forms.Label m_lblWindows;


		private global::System.Windows.Forms.CheckBox m_chkViewStatus;


		private global::System.Windows.Forms.Button btn_OK;


		private global::System.Windows.Forms.Button btn_Cancel;


		private global::System.Windows.Forms.CheckBox m_chkBTSortClmns;


		private global::System.Windows.Forms.TabPage tabPageWorkSet;


		private global::System.Windows.Forms.Label m_lblToolBars;


		private global::System.Windows.Forms.ImageList m_imglistTabs;


		private global::System.Windows.Forms.Button m_btnBTMoveDown;


		private global::System.Windows.Forms.Button m_btnBTMoveUp;


		private global::System.Windows.Forms.Label m_lbWSColumns;


		private global::System.Windows.Forms.CheckedListBox m_chklbWSColumns;


		private global::System.Windows.Forms.Button m_btnWSMoveUp;


		private global::System.Windows.Forms.Button m_btnWSMoveDown;


		private global::System.Windows.Forms.CheckBox m_chkWSSortClmns;


		private global::System.Windows.Forms.TabPage tpToolBars;


		private global::System.Windows.Forms.GroupBox grpUserBtns;


		private global::System.Windows.Forms.DataGridView m_dgvUserButtons;


		private global::System.Windows.Forms.GroupBox grpStandardBtns;


		private global::System.Windows.Forms.ListView m_lstStandardBtns;


		private global::System.Windows.Forms.RadioButton rdoSmallButtons;


		private global::System.Windows.Forms.Label label1;


		private global::System.Windows.Forms.RadioButton rdoLargeButtons;


		private global::System.Windows.Forms.GroupBox m_grpDisplayTypes;


		private global::System.Windows.Forms.Label lblFields;


		private global::System.Windows.Forms.ComboBox m_cboFieldDefDisplay;


		private global::System.Windows.Forms.Label lblRegister;


		private global::System.Windows.Forms.ComboBox m_cboRegDefDisplay;


		private global::System.Windows.Forms.CheckBox m_chkShowFunc;


		private global::System.Windows.Forms.DataGridViewCheckBoxColumn colShow;


		private global::System.Windows.Forms.DataGridViewImageColumn colIcon;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colorColumn;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colTitle;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colToolTip;


		private global::System.Windows.Forms.DataGridViewComboBoxColumn sourceTypeColumn;


		private global::System.Windows.Forms.DataGridViewTextBoxColumn colScript;


		private global::System.Windows.Forms.DataGridViewButtonColumn colBrowse;


		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;


		private global::System.Windows.Forms.Panel panel1;


		private global::System.Windows.Forms.ComboBox toolBarsComboBox;


		private global::System.Windows.Forms.Label label2;


		private global::System.Windows.Forms.TabPage tabPageGeneral;


		private global::System.Windows.Forms.Label m_lblConfigPath;


		private global::System.Windows.Forms.LinkLabel pathlinkLabel;


		private global::System.Windows.Forms.CheckBox m_fadeOutSplashcheckBox;


		private global::System.Windows.Forms.CheckBox m_chktxtSaveDisplayAs;
	}
}
