namespace RSTD
{
	public partial class BrowseTree : global::WeifenLuo.WinFormsUI.Docking.DockContent
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.BrowseTree));
			this.m_StatusStrip = new global::System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.m_lblQuickFind = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.m_TabControl = new global::System.Windows.Forms.TabControl();
			this.m_AutoUpdateTimer = new global::System.Timers.Timer();
			this.m_BottomToolStrip = new global::RSTD.ToolStripEx();
			this.m_TransmitSplitBtn = new global::System.Windows.Forms.ToolStripSplitButton();
			this.m_TransmitSplitBtnSelectionMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_TransmitSplitBtnTabMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_TransmitSplitBtnAllMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_ReceiveSplitBtn = new global::System.Windows.Forms.ToolStripSplitButton();
			this.m_ReceiveSplitBtnSelectionMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_ReceiveSplitBtnTabMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_ReceiveSplitBtnAllMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_SaveSplitBtn = new global::System.Windows.Forms.ToolStripSplitButton();
			this.m_SaveSplitBtnSelectionMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_SaveSplitBtnTabMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_SaveSplitBtnAllMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_LoadBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_MonitoredVarsBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_toolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_FindBtn = new global::System.Windows.Forms.ToolStripSplitButton();
			this.m_FindBtnMenuItemSelection = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_FindBtnMenuItemTab = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_FindBtnMenuItemAll = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_btnWorkSession = new global::System.Windows.Forms.ToolStripButton();
			this.m_GoToPath = new global::System.Windows.Forms.ToolStripButton();
			this.m_btnLoadExpose = new global::System.Windows.Forms.ToolStripButton();
			this.m_StatusStrip.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.m_AutoUpdateTimer).BeginInit();
			this.m_BottomToolStrip.SuspendLayout();
			base.SuspendLayout();
			this.m_StatusStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripStatusLabel1,
				this.m_lblQuickFind
			});
			this.m_StatusStrip.Location = new global::System.Drawing.Point(0, 437);
			this.m_StatusStrip.Name = "m_StatusStrip";
			this.m_StatusStrip.Padding = new global::System.Windows.Forms.Padding(1, 0, 10, 0);
			this.m_StatusStrip.Size = new global::System.Drawing.Size(746, 22);
			this.m_StatusStrip.TabIndex = 0;
			this.m_StatusStrip.Text = "statusStrip1";
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new global::System.Drawing.Size(114, 17);
			this.toolStripStatusLabel1.Text = "Incremental Search: ";
			this.m_lblQuickFind.Name = "m_lblQuickFind";
			this.m_lblQuickFind.Size = new global::System.Drawing.Size(0, 17);
			this.m_TabControl.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.m_TabControl.Location = new global::System.Drawing.Point(0, 0);
			this.m_TabControl.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_TabControl.Name = "m_TabControl";
			this.m_TabControl.SelectedIndex = 0;
			this.m_TabControl.Size = new global::System.Drawing.Size(746, 409);
			this.m_TabControl.TabIndex = 2;
			this.m_TabControl.SelectedIndexChanged += new global::System.EventHandler(this.m_TabControl_SelectedIndexChanged);
			this.m_AutoUpdateTimer.SynchronizingObject = this;
			this.m_AutoUpdateTimer.Elapsed += new global::System.Timers.ElapsedEventHandler(this.m_AutoUpdateTimer_Elapsed);
			this.m_BottomToolStrip.ClickThrough = true;
			this.m_BottomToolStrip.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.m_BottomToolStrip.Enabled = false;
			this.m_BottomToolStrip.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.m_BottomToolStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_TransmitSplitBtn,
				this.m_ReceiveSplitBtn,
				this.m_toolStripSeparator1,
				this.m_SaveSplitBtn,
				this.m_LoadBtn,
				this.m_toolStripSeparator2,
				this.m_MonitoredVarsBtn,
				this.m_toolStripSeparator3,
				this.m_FindBtn,
				this.m_btnWorkSession,
				this.m_GoToPath,
				this.m_btnLoadExpose
			});
			this.m_BottomToolStrip.Location = new global::System.Drawing.Point(0, 409);
			this.m_BottomToolStrip.Name = "m_BottomToolStrip";
			this.m_BottomToolStrip.Size = new global::System.Drawing.Size(746, 28);
			this.m_BottomToolStrip.TabIndex = 1;
			this.m_BottomToolStrip.Text = "toolStrip1";
			this.m_TransmitSplitBtn.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_TransmitSplitBtnSelectionMenuItem,
				this.m_TransmitSplitBtnTabMenuItem,
				this.m_TransmitSplitBtnAllMenuItem
			});
			this.m_TransmitSplitBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_TransmitSplitBtn.Image");
			this.m_TransmitSplitBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_TransmitSplitBtn.Name = "m_TransmitSplitBtn";
			this.m_TransmitSplitBtn.Size = new global::System.Drawing.Size(86, 25);
			this.m_TransmitSplitBtn.Text = "Transmit";
			this.m_TransmitSplitBtn.ButtonClick += new global::System.EventHandler(this.m_TransmitSplitBtn_ButtonClick);
			this.m_TransmitSplitBtnSelectionMenuItem.Name = "m_TransmitSplitBtnSelectionMenuItem";
			this.m_TransmitSplitBtnSelectionMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.m_TransmitSplitBtnSelectionMenuItem.Text = "Selection";
			this.m_TransmitSplitBtnSelectionMenuItem.Click += new global::System.EventHandler(this.m_TransmitSplitBtnSelectionMenuItem_Click);
			this.m_TransmitSplitBtnTabMenuItem.Name = "m_TransmitSplitBtnTabMenuItem";
			this.m_TransmitSplitBtnTabMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.m_TransmitSplitBtnTabMenuItem.Text = "Tab";
			this.m_TransmitSplitBtnTabMenuItem.Click += new global::System.EventHandler(this.m_TransmitSplitBtnTabMenuItem_Click);
			this.m_TransmitSplitBtnAllMenuItem.Name = "m_TransmitSplitBtnAllMenuItem";
			this.m_TransmitSplitBtnAllMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.m_TransmitSplitBtnAllMenuItem.Text = "All";
			this.m_TransmitSplitBtnAllMenuItem.Click += new global::System.EventHandler(this.m_TransmitSplitBtnAllMenuItem_Click);
			this.m_ReceiveSplitBtn.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_ReceiveSplitBtnSelectionMenuItem,
				this.m_ReceiveSplitBtnTabMenuItem,
				this.m_ReceiveSplitBtnAllMenuItem
			});
			this.m_ReceiveSplitBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_ReceiveSplitBtn.Image");
			this.m_ReceiveSplitBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_ReceiveSplitBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_ReceiveSplitBtn.Name = "m_ReceiveSplitBtn";
			this.m_ReceiveSplitBtn.Size = new global::System.Drawing.Size(79, 25);
			this.m_ReceiveSplitBtn.Text = "Receive";
			this.m_ReceiveSplitBtn.ButtonClick += new global::System.EventHandler(this.m_ReceiveSplitBtn_ButtonClick);
			this.m_ReceiveSplitBtnSelectionMenuItem.Name = "m_ReceiveSplitBtnSelectionMenuItem";
			this.m_ReceiveSplitBtnSelectionMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.m_ReceiveSplitBtnSelectionMenuItem.Text = "Selection";
			this.m_ReceiveSplitBtnSelectionMenuItem.Click += new global::System.EventHandler(this.m_ReceiveSplitBtnSelectionMenuItem_Click);
			this.m_ReceiveSplitBtnTabMenuItem.Name = "m_ReceiveSplitBtnTabMenuItem";
			this.m_ReceiveSplitBtnTabMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.m_ReceiveSplitBtnTabMenuItem.Text = "Tab";
			this.m_ReceiveSplitBtnTabMenuItem.Click += new global::System.EventHandler(this.m_ReceiveSplitBtnTabMenuItem_Click);
			this.m_ReceiveSplitBtnAllMenuItem.Name = "m_ReceiveSplitBtnAllMenuItem";
			this.m_ReceiveSplitBtnAllMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.m_ReceiveSplitBtnAllMenuItem.Text = "All";
			this.m_ReceiveSplitBtnAllMenuItem.Click += new global::System.EventHandler(this.m_ReceiveSplitBtnAllMenuItem_Click);
			this.m_toolStripSeparator1.Name = "m_toolStripSeparator1";
			this.m_toolStripSeparator1.Size = new global::System.Drawing.Size(6, 28);
			this.m_SaveSplitBtn.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_SaveSplitBtnSelectionMenuItem,
				this.m_SaveSplitBtnTabMenuItem,
				this.m_SaveSplitBtnAllMenuItem
			});
			this.m_SaveSplitBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_SaveSplitBtn.Image");
			this.m_SaveSplitBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_SaveSplitBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_SaveSplitBtn.Name = "m_SaveSplitBtn";
			this.m_SaveSplitBtn.Size = new global::System.Drawing.Size(69, 25);
			this.m_SaveSplitBtn.Text = "Save";
			this.m_SaveSplitBtn.ButtonClick += new global::System.EventHandler(this.m_SaveSplitBtn_ButtonClick);
			this.m_SaveSplitBtnSelectionMenuItem.Name = "m_SaveSplitBtnSelectionMenuItem";
			this.m_SaveSplitBtnSelectionMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.m_SaveSplitBtnSelectionMenuItem.Text = "Selection";
			this.m_SaveSplitBtnSelectionMenuItem.Click += new global::System.EventHandler(this.m_SaveSplitBtnSelectionMenuItem_Click);
			this.m_SaveSplitBtnTabMenuItem.Name = "m_SaveSplitBtnTabMenuItem";
			this.m_SaveSplitBtnTabMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.m_SaveSplitBtnTabMenuItem.Text = "Tab";
			this.m_SaveSplitBtnTabMenuItem.Click += new global::System.EventHandler(this.m_SaveSplitBtnTabMenuItem_Click);
			this.m_SaveSplitBtnAllMenuItem.Name = "m_SaveSplitBtnAllMenuItem";
			this.m_SaveSplitBtnAllMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.m_SaveSplitBtnAllMenuItem.Text = "All";
			this.m_SaveSplitBtnAllMenuItem.Click += new global::System.EventHandler(this.m_SaveSplitBtnAllMenuItem_Click);
			this.m_LoadBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_LoadBtn.Image");
			this.m_LoadBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_LoadBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_LoadBtn.Name = "m_LoadBtn";
			this.m_LoadBtn.Size = new global::System.Drawing.Size(53, 25);
			this.m_LoadBtn.Text = "Load";
			this.m_LoadBtn.Click += new global::System.EventHandler(this.LoadBtn_Click);
			this.m_toolStripSeparator2.Name = "m_toolStripSeparator2";
			this.m_toolStripSeparator2.Size = new global::System.Drawing.Size(6, 28);
			this.m_MonitoredVarsBtn.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_MonitoredVarsBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_MonitoredVarsBtn.Image");
			this.m_MonitoredVarsBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_MonitoredVarsBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_MonitoredVarsBtn.Name = "m_MonitoredVarsBtn";
			this.m_MonitoredVarsBtn.Size = new global::System.Drawing.Size(133, 25);
			this.m_MonitoredVarsBtn.Text = "Monitored Variables";
			this.m_MonitoredVarsBtn.Click += new global::System.EventHandler(this.m_MonitoredVarsBtn_Click);
			this.m_toolStripSeparator3.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_toolStripSeparator3.Name = "m_toolStripSeparator3";
			this.m_toolStripSeparator3.Size = new global::System.Drawing.Size(6, 28);
			this.m_FindBtn.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_FindBtnMenuItemSelection,
				this.m_FindBtnMenuItemTab,
				this.m_FindBtnMenuItemAll
			});
			this.m_FindBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_FindBtn.Image");
			this.m_FindBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_FindBtn.Name = "m_FindBtn";
			this.m_FindBtn.Size = new global::System.Drawing.Size(62, 25);
			this.m_FindBtn.Text = "Find";
			this.m_FindBtn.ButtonClick += new global::System.EventHandler(this.m_FindBtn_Click);
			this.m_FindBtnMenuItemSelection.Name = "m_FindBtnMenuItemSelection";
			this.m_FindBtnMenuItemSelection.Size = new global::System.Drawing.Size(122, 22);
			this.m_FindBtnMenuItemSelection.Text = "Selection";
			this.m_FindBtnMenuItemSelection.Click += new global::System.EventHandler(this.m_FindBtnMenuItemSelection_Click);
			this.m_FindBtnMenuItemTab.Name = "m_FindBtnMenuItemTab";
			this.m_FindBtnMenuItemTab.Size = new global::System.Drawing.Size(122, 22);
			this.m_FindBtnMenuItemTab.Text = "Tab";
			this.m_FindBtnMenuItemTab.Click += new global::System.EventHandler(this.m_FindBtnMenuItemTab_Click);
			this.m_FindBtnMenuItemAll.Name = "m_FindBtnMenuItemAll";
			this.m_FindBtnMenuItemAll.Size = new global::System.Drawing.Size(122, 22);
			this.m_FindBtnMenuItemAll.Text = "All";
			this.m_FindBtnMenuItemAll.Click += new global::System.EventHandler(this.m_FindBtnMenuItemAll_Click);
			this.m_btnWorkSession.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_btnWorkSession.Image = global::RSTD.Properties.Resources.WorksetImage;
			this.m_btnWorkSession.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnWorkSession.Name = "m_btnWorkSession";
			this.m_btnWorkSession.Size = new global::System.Drawing.Size(71, 25);
			this.m_btnWorkSession.Text = "WorkSet";
			this.m_btnWorkSession.Click += new global::System.EventHandler(this.m_btnWorkSession_Click);
			this.m_GoToPath.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_GoToPath.Image");
			this.m_GoToPath.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_GoToPath.Name = "m_GoToPath";
			this.m_GoToPath.Size = new global::System.Drawing.Size(59, 25);
			this.m_GoToPath.Text = "Go To";
			this.m_GoToPath.Click += new global::System.EventHandler(this.m_GoToPath_Click);
			this.m_btnLoadExpose.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_btnLoadExpose.Image");
			this.m_btnLoadExpose.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_btnLoadExpose.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnLoadExpose.Name = "m_btnLoadExpose";
			this.m_btnLoadExpose.Size = new global::System.Drawing.Size(92, 25);
			this.m_btnLoadExpose.Text = "Load Expose";
			this.m_btnLoadExpose.Click += new global::System.EventHandler(this.m_btnLoadExport_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(746, 459);
			base.Controls.Add(this.m_TabControl);
			base.Controls.Add(this.m_BottomToolStrip);
			base.Controls.Add(this.m_StatusStrip);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "BrowseTree";
			base.TabText = "BrowseTree";
			this.Text = "BrowseTree";
			base.DockStateChanged += new global::System.EventHandler(this.BrowseTree_DockStateChanged);
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.BrowseTree_FormClosing);
			this.m_StatusStrip.ResumeLayout(false);
			this.m_StatusStrip.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.m_AutoUpdateTimer).EndInit();
			this.m_BottomToolStrip.ResumeLayout(false);
			this.m_BottomToolStrip.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;
		private global::System.Windows.Forms.StatusStrip m_StatusStrip;
		private global::RSTD.ToolStripEx m_BottomToolStrip;
		private global::System.Windows.Forms.TabControl m_TabControl;
		private global::System.Windows.Forms.ToolStripSplitButton m_TransmitSplitBtn;
		private global::System.Windows.Forms.ToolStripMenuItem m_TransmitSplitBtnSelectionMenuItem;
		private global::System.Windows.Forms.ToolStripMenuItem m_TransmitSplitBtnTabMenuItem;
		private global::System.Windows.Forms.ToolStripMenuItem m_TransmitSplitBtnAllMenuItem;
		private global::System.Windows.Forms.ToolStripSplitButton m_ReceiveSplitBtn;
		private global::System.Windows.Forms.ToolStripMenuItem m_ReceiveSplitBtnSelectionMenuItem;
		private global::System.Windows.Forms.ToolStripMenuItem m_ReceiveSplitBtnTabMenuItem;
		private global::System.Windows.Forms.ToolStripMenuItem m_ReceiveSplitBtnAllMenuItem;
		private global::System.Windows.Forms.ToolStripSeparator m_toolStripSeparator1;
		private global::System.Windows.Forms.ToolStripSplitButton m_SaveSplitBtn;
		private global::System.Windows.Forms.ToolStripMenuItem m_SaveSplitBtnSelectionMenuItem;
		private global::System.Windows.Forms.ToolStripMenuItem m_SaveSplitBtnTabMenuItem;
		private global::System.Windows.Forms.ToolStripMenuItem m_SaveSplitBtnAllMenuItem;
		private global::System.Windows.Forms.ToolStripSeparator m_toolStripSeparator2;
		private global::System.Windows.Forms.ToolStripButton m_MonitoredVarsBtn;
		private global::System.Windows.Forms.ToolStripButton m_LoadBtn;
		private global::System.Windows.Forms.ToolStripSeparator m_toolStripSeparator3;
		private global::System.Windows.Forms.ToolStripSplitButton m_FindBtn;
		private global::System.Windows.Forms.ToolStripMenuItem m_FindBtnMenuItemSelection;
		private global::System.Windows.Forms.ToolStripMenuItem m_FindBtnMenuItemTab;
		private global::System.Windows.Forms.ToolStripMenuItem m_FindBtnMenuItemAll;
		private global::System.Windows.Forms.ToolStripButton m_btnWorkSession;
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private global::System.Windows.Forms.ToolStripStatusLabel m_lblQuickFind;
		private global::System.Timers.Timer m_AutoUpdateTimer;
		private global::System.Windows.Forms.ToolStripButton m_GoToPath;
		private global::System.Windows.Forms.ToolStripButton m_btnLoadExpose;
	}
}
