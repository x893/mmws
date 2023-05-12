namespace RSTD
{

	public partial class frmMain : global::System.Windows.Forms.Form
	{

		protected override void Dispose(bool disposing)
		{
			this.iDispose();
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}


		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.frmMain));
			global::WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin = new global::WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
			global::WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin = new global::WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
			global::WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient = new global::WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			global::WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient = new global::WeifenLuo.WinFormsUI.Docking.TabGradient();
			global::WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin = new global::WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
			global::WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient = new global::WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
			global::WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new global::WeifenLuo.WinFormsUI.Docking.TabGradient();
			global::WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new global::WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			global::WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new global::WeifenLuo.WinFormsUI.Docking.TabGradient();
			global::WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient = new global::WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
			global::WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new global::WeifenLuo.WinFormsUI.Docking.TabGradient();
			global::WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new global::WeifenLuo.WinFormsUI.Docking.TabGradient();
			global::WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new global::WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			global::WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new global::WeifenLuo.WinFormsUI.Docking.TabGradient();
			global::WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new global::WeifenLuo.WinFormsUI.Docking.TabGradient();
			this.m_StatusStrip = new global::System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.m_lblNetClientStatus = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel4 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.m_ToolBarImageList = new global::System.Windows.Forms.ImageList(this.components);
			this.m_UserButtonsContextMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.EditButtonToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.EditScriptToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.DebugScriptToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.DeleteButtonToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.addButtonsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.LoadButtonsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.SaveButtonsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.changeToolbarNameToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.mainMenu = new global::System.Windows.Forms.MenuStrip();
			this.menuItemFile = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemLoadLayout = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSaveLayout = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemClose = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemCloseAll = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemCloseAllButThisOne = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItem4 = new global::System.Windows.Forms.ToolStripSeparator();
			this.menuItemExit = new global::System.Windows.Forms.ToolStripMenuItem();
			this.exitWithoutSavingLayout = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemView = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemOutput = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemBrowseTree = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemWorkSet = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemMonitors = new global::System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemLuaShell = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItem1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolBarsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemStandardToolBar = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemUserButtonsToolBar = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemScriptToolBar = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemStatusBar = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemOperations = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemBuild = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemUnBuild = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemGo = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemStop = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemALBuild = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemALInit = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemALReset = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemClientBuild = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemClientInit = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemClientReset = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemClientUnbuild = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemALUnbuild = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemTools = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemLockLayout = new global::System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.registerDllsToLuaToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolBarsToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.openToolBarsFolderToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.menuItemWindow = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSubSet = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_SubsetLoad = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_SubsetNew = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemHelp = new global::System.Windows.Forms.ToolStripMenuItem();
			this.luaWebPageToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.RadarICDLink = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAbout = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_DockPanel = new global::WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.BottomToolStripPanel = new global::System.Windows.Forms.ToolStripPanel();
			this.TopToolStripPanel = new global::System.Windows.Forms.ToolStripPanel();
			this.RightToolStripPanel = new global::System.Windows.Forms.ToolStripPanel();
			this.LeftToolStripPanel = new global::System.Windows.Forms.ToolStripPanel();
			this.ContentPanel = new global::System.Windows.Forms.ToolStripContentPanel();
			this.toolStripContainer1 = new global::System.Windows.Forms.ToolStripContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.m_ToolBar = new global::RSTD.ToolStripEx();
			this.m_BrowseTreeBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_MonitoredVarsBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_toolStripSeparator6 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_WorkSetBtn = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_ConsoleBtn = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_btnLuaShell = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_btnLuaDebugger = new global::System.Windows.Forms.ToolStripButton();
			this.m_btnMacroForm = new global::System.Windows.Forms.ToolStripButton();
			this.m_BottomToolStrip = new global::RSTD.ToolStripEx();
			this.m_btnDebug = new global::System.Windows.Forms.ToolStripButton();
			this.m_ScriptRunStopBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_btnPause = new global::System.Windows.Forms.ToolStripButton();
			this.m_ScriptNameComboBox = new global::System.Windows.Forms.ToolStripComboBox();
			this.m_ScriptBrowseBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_EditScriptBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_btnDebuggerEdit = new global::System.Windows.Forms.ToolStripButton();
			this.m_StatusStrip.SuspendLayout();
			this.m_UserButtonsContextMenuStrip.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.m_ToolBar.SuspendLayout();
			this.m_BottomToolStrip.SuspendLayout();
			base.SuspendLayout();
			this.m_StatusStrip.BackColor = global::System.Drawing.SystemColors.ButtonFace;
			this.m_StatusStrip.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_StatusStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripStatusLabel1,
				this.m_lblNetClientStatus,
				this.toolStripStatusLabel2,
				this.toolStripStatusLabel4
			});
			this.m_StatusStrip.Location = new global::System.Drawing.Point(0, 433);
			this.m_StatusStrip.Name = "m_StatusStrip";
			this.m_StatusStrip.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.m_StatusStrip.Size = new global::System.Drawing.Size(663, 22);
			this.m_StatusStrip.SizingGrip = false;
			this.m_StatusStrip.TabIndex = 1;
			this.m_StatusStrip.Text = "statusStrip1";
			this.toolStripStatusLabel1.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new global::System.Drawing.Size(69, 17);
			this.toolStripStatusLabel1.Text = "Net Status:";
			this.toolStripStatusLabel1.Visible = false;
			this.m_lblNetClientStatus.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.m_lblNetClientStatus.ForeColor = global::System.Drawing.Color.DarkRed;
			this.m_lblNetClientStatus.Name = "m_lblNetClientStatus";
			this.m_lblNetClientStatus.Size = new global::System.Drawing.Size(44, 17);
			this.m_lblNetClientStatus.Text = "Closed";
			this.m_lblNetClientStatus.Visible = false;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new global::System.Drawing.Size(648, 17);
			this.toolStripStatusLabel2.Spring = true;
			this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
			this.toolStripStatusLabel4.Size = new global::System.Drawing.Size(0, 17);
			this.m_ToolBarImageList.ImageStream = (global::System.Windows.Forms.ImageListStreamer)resources.GetObject("m_ToolBarImageList.ImageStream");
			this.m_ToolBarImageList.TransparentColor = global::System.Drawing.Color.Transparent;
			this.m_ToolBarImageList.Images.SetKeyName(0, "brickwall_prebuilt.bmp");
			this.m_ToolBarImageList.Images.SetKeyName(1, "brickwall_built.bmp");
			this.m_ToolBarImageList.Images.SetKeyName(2, "folder_tree.gif");
			this.m_ToolBarImageList.Images.SetKeyName(3, "go.bmp");
			this.m_ToolBarImageList.Images.SetKeyName(4, "stop.gif");
			this.m_ToolBarImageList.Images.SetKeyName(5, "graph.bmp");
			this.m_ToolBarImageList.Images.SetKeyName(6, "swiss_knife.gif");
			this.m_UserButtonsContextMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.EditButtonToolStripMenuItem,
				this.EditScriptToolStripMenuItem,
				this.DebugScriptToolStripMenuItem,
				this.DeleteButtonToolStripMenuItem,
				this.addButtonsToolStripMenuItem,
				this.LoadButtonsToolStripMenuItem,
				this.SaveButtonsToolStripMenuItem,
				this.changeToolbarNameToolStripMenuItem
			});
			this.m_UserButtonsContextMenuStrip.Name = "m_UserButtonsContextMenuStrip";
			this.m_UserButtonsContextMenuStrip.Size = new global::System.Drawing.Size(164, 180);
			this.m_UserButtonsContextMenuStrip.Closed += new global::System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.m_UserButtonsContextMenuStrip_Closed);
			this.EditButtonToolStripMenuItem.Enabled = false;
			this.EditButtonToolStripMenuItem.Name = "EditButtonToolStripMenuItem";
			this.EditButtonToolStripMenuItem.Size = new global::System.Drawing.Size(163, 22);
			this.EditButtonToolStripMenuItem.Text = "Edit Button...";
			this.EditButtonToolStripMenuItem.Click += new global::System.EventHandler(this.EditButtonToolStripMenuItem_Click);
			this.EditScriptToolStripMenuItem.Enabled = false;
			this.EditScriptToolStripMenuItem.Image = global::RSTD.Properties.Resources.edit;
			this.EditScriptToolStripMenuItem.Name = "EditScriptToolStripMenuItem";
			this.EditScriptToolStripMenuItem.Size = new global::System.Drawing.Size(163, 22);
			this.EditScriptToolStripMenuItem.Text = "Edit Script";
			this.EditScriptToolStripMenuItem.Click += new global::System.EventHandler(this.EditScriptToolStripMenuItem_Click);
			this.DebugScriptToolStripMenuItem.Enabled = false;
			this.DebugScriptToolStripMenuItem.Image = global::RSTD.Properties.Resources.Debug;
			this.DebugScriptToolStripMenuItem.Name = "DebugScriptToolStripMenuItem";
			this.DebugScriptToolStripMenuItem.Size = new global::System.Drawing.Size(163, 22);
			this.DebugScriptToolStripMenuItem.Text = "Debug Script...";
			this.DebugScriptToolStripMenuItem.ToolTipText = "Open In Lua Debugger";
			this.DebugScriptToolStripMenuItem.Click += new global::System.EventHandler(this.DebugScriptToolStripMenuItem_Click);
			this.DeleteButtonToolStripMenuItem.Enabled = false;
			this.DeleteButtonToolStripMenuItem.Name = "DeleteButtonToolStripMenuItem";
			this.DeleteButtonToolStripMenuItem.Size = new global::System.Drawing.Size(163, 22);
			this.DeleteButtonToolStripMenuItem.Text = "Delete Button";
			this.DeleteButtonToolStripMenuItem.Click += new global::System.EventHandler(this.DeleteButtonToolStripMenuItem_Click);
			this.addButtonsToolStripMenuItem.Name = "addButtonsToolStripMenuItem";
			this.addButtonsToolStripMenuItem.Size = new global::System.Drawing.Size(163, 22);
			this.addButtonsToolStripMenuItem.Text = "Add Buttons...";
			this.addButtonsToolStripMenuItem.ToolTipText = "Add buttons from file";
			this.addButtonsToolStripMenuItem.Click += new global::System.EventHandler(this.AddButtonsToolStripMenuItem_Click);
			this.LoadButtonsToolStripMenuItem.Name = "LoadButtonsToolStripMenuItem";
			this.LoadButtonsToolStripMenuItem.Size = new global::System.Drawing.Size(163, 22);
			this.LoadButtonsToolStripMenuItem.Text = "Load Buttons...";
			this.LoadButtonsToolStripMenuItem.ToolTipText = "Load buttons from file (will clear existing)";
			this.LoadButtonsToolStripMenuItem.Click += new global::System.EventHandler(this.LoadButtonsToolStripMenuItem_Click);
			this.SaveButtonsToolStripMenuItem.Name = "SaveButtonsToolStripMenuItem";
			this.SaveButtonsToolStripMenuItem.Size = new global::System.Drawing.Size(163, 22);
			this.SaveButtonsToolStripMenuItem.Text = "Save ToolBar...";
			this.SaveButtonsToolStripMenuItem.ToolTipText = "Save buttons to file";
			this.SaveButtonsToolStripMenuItem.Click += new global::System.EventHandler(this.SaveButtonsToolStripMenuItem_Click);
			this.changeToolbarNameToolStripMenuItem.Name = "changeToolbarNameToolStripMenuItem";
			this.changeToolbarNameToolStripMenuItem.Size = new global::System.Drawing.Size(163, 22);
			this.changeToolbarNameToolStripMenuItem.Text = "Config ToolBar...";
			this.changeToolbarNameToolStripMenuItem.Click += new global::System.EventHandler(this.changeToolbarNameToolStripMenuItem_Click);
			this.mainMenu.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.menuItemFile,
				this.menuItemView,
				this.menuItemOperations,
				this.menuItemTools,
				this.toolBarsToolStripMenuItem1,
				this.menuItemWindow,
				this.menuItemSubSet,
				this.menuItemHelp
			});
			this.mainMenu.Location = new global::System.Drawing.Point(0, 0);
			this.mainMenu.MdiWindowListItem = this.menuItemWindow;
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Padding = new global::System.Windows.Forms.Padding(4, 2, 0, 2);
			this.mainMenu.Size = new global::System.Drawing.Size(663, 24);
			this.mainMenu.TabIndex = 9;
			this.menuItemFile.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.menuItemLoadLayout,
				this.menuItemSaveLayout,
				this.menuItemClose,
				this.menuItemCloseAll,
				this.menuItemCloseAllButThisOne,
				this.menuItem4,
				this.menuItemExit,
				this.exitWithoutSavingLayout
			});
			this.menuItemFile.Name = "menuItemFile";
			this.menuItemFile.Size = new global::System.Drawing.Size(37, 20);
			this.menuItemFile.Text = "&File";
			this.menuItemFile.DropDownOpening += new global::System.EventHandler(this.menuItemFile_DropDownOpening);
			this.menuItemLoadLayout.Name = "menuItemLoadLayout";
			this.menuItemLoadLayout.Size = new global::System.Drawing.Size(215, 22);
			this.menuItemLoadLayout.Text = "&Load Layout...";
			this.menuItemLoadLayout.Click += new global::System.EventHandler(this.menuItemLoadLayout_Click);
			this.menuItemSaveLayout.Name = "menuItemSaveLayout";
			this.menuItemSaveLayout.Size = new global::System.Drawing.Size(215, 22);
			this.menuItemSaveLayout.Text = "&Save Layout...";
			this.menuItemSaveLayout.Click += new global::System.EventHandler(this.menuItemSaveLayout_Click);
			this.menuItemClose.Name = "menuItemClose";
			this.menuItemClose.Size = new global::System.Drawing.Size(215, 22);
			this.menuItemClose.Text = "&Close";
			this.menuItemClose.Click += new global::System.EventHandler(this.menuItemClose_Click);
			this.menuItemCloseAll.Name = "menuItemCloseAll";
			this.menuItemCloseAll.Size = new global::System.Drawing.Size(215, 22);
			this.menuItemCloseAll.Text = "Close &All";
			this.menuItemCloseAll.Click += new global::System.EventHandler(this.menuItemCloseAll_Click);
			this.menuItemCloseAllButThisOne.Name = "menuItemCloseAllButThisOne";
			this.menuItemCloseAllButThisOne.Size = new global::System.Drawing.Size(215, 22);
			this.menuItemCloseAllButThisOne.Text = "Close All &But This One";
			this.menuItemCloseAllButThisOne.Click += new global::System.EventHandler(this.menuItemCloseAllButThisOne_Click);
			this.menuItem4.Name = "menuItem4";
			this.menuItem4.Size = new global::System.Drawing.Size(212, 6);
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.Size = new global::System.Drawing.Size(215, 22);
			this.menuItemExit.Text = "E&xit";
			this.menuItemExit.Click += new global::System.EventHandler(this.menuItemExit_Click);
			this.exitWithoutSavingLayout.Name = "exitWithoutSavingLayout";
			this.exitWithoutSavingLayout.Size = new global::System.Drawing.Size(215, 22);
			this.exitWithoutSavingLayout.Text = "Exit &Without Saving Layout";
			this.exitWithoutSavingLayout.Click += new global::System.EventHandler(this.exitWithoutSavingLayout_Click);
			this.menuItemView.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.menuItemOutput,
				this.menuItemBrowseTree,
				this.menuItemWorkSet,
				this.menuItemMonitors,
				this.MenuItemLuaShell,
				this.menuItem1,
				this.toolBarsToolStripMenuItem,
				this.menuItemStatusBar
			});
			this.menuItemView.MergeIndex = 1;
			this.menuItemView.Name = "menuItemView";
			this.menuItemView.Size = new global::System.Drawing.Size(44, 20);
			this.menuItemView.Text = "&View";
			this.menuItemView.DropDownOpening += new global::System.EventHandler(this.menuItemView_DropDownOpening);
			this.menuItemOutput.Image = (global::System.Drawing.Image)resources.GetObject("menuItemOutput.Image");
			this.menuItemOutput.Name = "menuItemOutput";
			this.menuItemOutput.Size = new global::System.Drawing.Size(135, 22);
			this.menuItemOutput.Text = "&Output";
			this.menuItemOutput.Click += new global::System.EventHandler(this.menuItemOutput_Click);
			this.menuItemBrowseTree.Image = (global::System.Drawing.Image)resources.GetObject("menuItemBrowseTree.Image");
			this.menuItemBrowseTree.Name = "menuItemBrowseTree";
			this.menuItemBrowseTree.Size = new global::System.Drawing.Size(135, 22);
			this.menuItemBrowseTree.Text = "&BrowseTree";
			this.menuItemBrowseTree.Click += new global::System.EventHandler(this.menuItemBrowseTree_Click);
			this.menuItemWorkSet.Image = global::RSTD.Properties.Resources.WorksetImage;
			this.menuItemWorkSet.Name = "menuItemWorkSet";
			this.menuItemWorkSet.Size = new global::System.Drawing.Size(135, 22);
			this.menuItemWorkSet.Text = "&WorkSet";
			this.menuItemWorkSet.Click += new global::System.EventHandler(this.menuItemWorkSet_Click);
			this.menuItemMonitors.Image = (global::System.Drawing.Image)resources.GetObject("menuItemMonitors.Image");
			this.menuItemMonitors.Name = "menuItemMonitors";
			this.menuItemMonitors.Size = new global::System.Drawing.Size(135, 22);
			this.menuItemMonitors.Text = "&Monitors";
			this.menuItemMonitors.Click += new global::System.EventHandler(this.menuItemMonitors_Click);
			this.MenuItemLuaShell.Image = (global::System.Drawing.Image)resources.GetObject("MenuItemLuaShell.Image");
			this.MenuItemLuaShell.Name = "MenuItemLuaShell";
			this.MenuItemLuaShell.Size = new global::System.Drawing.Size(135, 22);
			this.MenuItemLuaShell.Text = "LuaShell";
			this.MenuItemLuaShell.Click += new global::System.EventHandler(this.MenuItemLuaShell_Click);
			this.menuItem1.Name = "menuItem1";
			this.menuItem1.Size = new global::System.Drawing.Size(132, 6);
			this.toolBarsToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.menuItemStandardToolBar,
				this.menuItemUserButtonsToolBar,
				this.menuItemScriptToolBar
			});
			this.toolBarsToolStripMenuItem.Name = "toolBarsToolStripMenuItem";
			this.toolBarsToolStripMenuItem.Size = new global::System.Drawing.Size(135, 22);
			this.toolBarsToolStripMenuItem.Text = "&ToolBars";
			this.menuItemStandardToolBar.Checked = true;
			this.menuItemStandardToolBar.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.menuItemStandardToolBar.Name = "menuItemStandardToolBar";
			this.menuItemStandardToolBar.Size = new global::System.Drawing.Size(141, 22);
			this.menuItemStandardToolBar.Text = "Standard";
			this.menuItemStandardToolBar.Click += new global::System.EventHandler(this.menuItemStandardToolBar_Click);
			this.menuItemUserButtonsToolBar.Checked = true;
			this.menuItemUserButtonsToolBar.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.menuItemUserButtonsToolBar.Name = "menuItemUserButtonsToolBar";
			this.menuItemUserButtonsToolBar.Size = new global::System.Drawing.Size(141, 22);
			this.menuItemUserButtonsToolBar.Text = "User Buttons";
			this.menuItemUserButtonsToolBar.Click += new global::System.EventHandler(this.menuItemUserButtonsToolBar_Click);
			this.menuItemScriptToolBar.Checked = true;
			this.menuItemScriptToolBar.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.menuItemScriptToolBar.Name = "menuItemScriptToolBar";
			this.menuItemScriptToolBar.Size = new global::System.Drawing.Size(141, 22);
			this.menuItemScriptToolBar.Text = "Script";
			this.menuItemScriptToolBar.Click += new global::System.EventHandler(this.menuItemScriptToolBar_Click);
			this.menuItemStatusBar.Checked = true;
			this.menuItemStatusBar.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.menuItemStatusBar.Name = "menuItemStatusBar";
			this.menuItemStatusBar.Size = new global::System.Drawing.Size(135, 22);
			this.menuItemStatusBar.Text = "&Status Bar";
			this.menuItemStatusBar.Click += new global::System.EventHandler(this.menuItemStatusBar_Click);
			this.menuItemOperations.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.menuItemBuild,
				this.menuItemUnBuild,
				this.menuItemGo,
				this.menuItemStop,
				this.menuItemALBuild,
				this.menuItemALInit,
				this.menuItemALReset,
				this.menuItemClientBuild,
				this.menuItemClientInit,
				this.menuItemClientReset,
				this.menuItemClientUnbuild,
				this.menuItemALUnbuild
			});
			this.menuItemOperations.Name = "menuItemOperations";
			this.menuItemOperations.Size = new global::System.Drawing.Size(77, 20);
			this.menuItemOperations.Text = "&Operations";
			this.menuItemOperations.Visible = false;
			this.menuItemOperations.DropDownOpening += new global::System.EventHandler(this.menuItemOperations_DropDownOpening);
			this.menuItemBuild.Name = "menuItemBuild";
			this.menuItemBuild.ShortcutKeys = global::System.Windows.Forms.Keys.F7;
			this.menuItemBuild.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemBuild.Text = "&Build";
			this.menuItemBuild.Click += new global::System.EventHandler(this.menuItemBuild_Click);
			this.menuItemUnBuild.Enabled = false;
			this.menuItemUnBuild.Name = "menuItemUnBuild";
			this.menuItemUnBuild.ShortcutKeys = (global::System.Windows.Forms.Keys)65654;
			this.menuItemUnBuild.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemUnBuild.Text = "&UnBuild";
			this.menuItemUnBuild.Click += new global::System.EventHandler(this.menuItemUnBuild_Click);
			this.menuItemGo.Name = "menuItemGo";
			this.menuItemGo.ShortcutKeys = global::System.Windows.Forms.Keys.F5;
			this.menuItemGo.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemGo.Text = "&Go";
			this.menuItemGo.Click += new global::System.EventHandler(this.menuItemGo_Click);
			this.menuItemStop.Enabled = false;
			this.menuItemStop.Name = "menuItemStop";
			this.menuItemStop.ShortcutKeys = (global::System.Windows.Forms.Keys)65652;
			this.menuItemStop.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemStop.Text = "&Stop";
			this.menuItemStop.Click += new global::System.EventHandler(this.menuItemStop_Click);
			this.menuItemALBuild.Name = "menuItemALBuild";
			this.menuItemALBuild.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemALBuild.Text = "AL Build";
			this.menuItemALBuild.Click += new global::System.EventHandler(this.menuItemALBuild_Click);
			this.menuItemALInit.Enabled = false;
			this.menuItemALInit.Name = "menuItemALInit";
			this.menuItemALInit.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemALInit.Text = "AL Init";
			this.menuItemALInit.Click += new global::System.EventHandler(this.menuItemALInit_Click);
			this.menuItemALReset.Enabled = false;
			this.menuItemALReset.Name = "menuItemALReset";
			this.menuItemALReset.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemALReset.Text = "AL Reset";
			this.menuItemALReset.Click += new global::System.EventHandler(this.menuItemALReset_Click);
			this.menuItemClientBuild.Enabled = false;
			this.menuItemClientBuild.Name = "menuItemClientBuild";
			this.menuItemClientBuild.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemClientBuild.Text = "Client Build";
			this.menuItemClientBuild.Click += new global::System.EventHandler(this.menuItemClientBuild_Click);
			this.menuItemClientInit.Enabled = false;
			this.menuItemClientInit.Name = "menuItemClientInit";
			this.menuItemClientInit.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemClientInit.Text = "Client Init";
			this.menuItemClientInit.Click += new global::System.EventHandler(this.menuItemClientInit_Click);
			this.menuItemClientReset.Enabled = false;
			this.menuItemClientReset.Name = "menuItemClientReset";
			this.menuItemClientReset.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemClientReset.Text = "Client Reset";
			this.menuItemClientReset.Click += new global::System.EventHandler(this.menuItemClientReset_Click);
			this.menuItemClientUnbuild.Enabled = false;
			this.menuItemClientUnbuild.Name = "menuItemClientUnbuild";
			this.menuItemClientUnbuild.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemClientUnbuild.Text = "Client Unbuild";
			this.menuItemClientUnbuild.Click += new global::System.EventHandler(this.menuItemClientUnbuild_Click);
			this.menuItemALUnbuild.Enabled = false;
			this.menuItemALUnbuild.Name = "menuItemALUnbuild";
			this.menuItemALUnbuild.Size = new global::System.Drawing.Size(167, 22);
			this.menuItemALUnbuild.Text = "AL Unbuild";
			this.menuItemALUnbuild.Click += new global::System.EventHandler(this.menuItemALUnbuild_Click);
			this.menuItemTools.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.menuItemLockLayout,
				this.settingsToolStripMenuItem,
				this.registerDllsToLuaToolStripMenuItem
			});
			this.menuItemTools.MergeIndex = 2;
			this.menuItemTools.Name = "menuItemTools";
			this.menuItemTools.Size = new global::System.Drawing.Size(48, 20);
			this.menuItemTools.Text = "&Tools";
			this.menuItemTools.DropDownOpening += new global::System.EventHandler(this.menuItemTools_DropDownOpening);
			this.menuItemLockLayout.Name = "menuItemLockLayout";
			this.menuItemLockLayout.Size = new global::System.Drawing.Size(186, 22);
			this.menuItemLockLayout.Text = "&Lock Layout";
			this.menuItemLockLayout.Click += new global::System.EventHandler(this.menuItemLockLayout_Click);
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new global::System.Drawing.Size(186, 22);
			this.settingsToolStripMenuItem.Text = "&Customize...";
			this.settingsToolStripMenuItem.Click += new global::System.EventHandler(this.settingsToolStripMenuItem_Click);
			this.registerDllsToLuaToolStripMenuItem.Name = "registerDllsToLuaToolStripMenuItem";
			this.registerDllsToLuaToolStripMenuItem.Size = new global::System.Drawing.Size(186, 22);
			this.registerDllsToLuaToolStripMenuItem.Text = "Register Dlls To Lua...";
			this.registerDllsToLuaToolStripMenuItem.Click += new global::System.EventHandler(this.registerDllsToLuaToolStripMenuItem_Click);
			this.toolBarsToolStripMenuItem1.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.loadToolStripMenuItem,
				this.newToolStripMenuItem,
				this.openToolBarsFolderToolStripMenuItem,
				this.toolStripSeparator3
			});
			this.toolBarsToolStripMenuItem1.Name = "toolBarsToolStripMenuItem1";
			this.toolBarsToolStripMenuItem1.Size = new global::System.Drawing.Size(65, 20);
			this.toolBarsToolStripMenuItem1.Text = "ToolBars";
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new global::System.Drawing.Size(188, 22);
			this.loadToolStripMenuItem.Text = "Load...";
			this.loadToolStripMenuItem.Click += new global::System.EventHandler(this.loadToolStripMenuItem_Click);
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new global::System.Drawing.Size(188, 22);
			this.newToolStripMenuItem.Text = "New...";
			this.newToolStripMenuItem.Click += new global::System.EventHandler(this.newToolStripMenuItem_Click);
			this.openToolBarsFolderToolStripMenuItem.Name = "openToolBarsFolderToolStripMenuItem";
			this.openToolBarsFolderToolStripMenuItem.Size = new global::System.Drawing.Size(188, 22);
			this.openToolBarsFolderToolStripMenuItem.Text = "Open ToolBars Folder";
			this.openToolBarsFolderToolStripMenuItem.Click += new global::System.EventHandler(this.openToolBarsFolderToolStripMenuItem_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new global::System.Drawing.Size(185, 6);
			this.menuItemWindow.MergeIndex = 2;
			this.menuItemWindow.Name = "menuItemWindow";
			this.menuItemWindow.Size = new global::System.Drawing.Size(63, 20);
			this.menuItemWindow.Text = "&Window";
			this.menuItemSubSet.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_SubsetLoad,
				this.m_SubsetNew
			});
			this.menuItemSubSet.Name = "menuItemSubSet";
			this.menuItemSubSet.Size = new global::System.Drawing.Size(55, 20);
			this.menuItemSubSet.Text = "SubSet";
			this.menuItemSubSet.DropDownOpened += new global::System.EventHandler(this.menuItemSubSet_DropDownOpened);
			this.m_SubsetLoad.Name = "m_SubsetLoad";
			this.m_SubsetLoad.Size = new global::System.Drawing.Size(109, 22);
			this.m_SubsetLoad.Text = "Load...";
			this.m_SubsetLoad.Click += new global::System.EventHandler(this.m_SubsetLoad_Click);
			this.m_SubsetNew.Name = "m_SubsetNew";
			this.m_SubsetNew.Size = new global::System.Drawing.Size(109, 22);
			this.m_SubsetNew.Text = "New...";
			this.m_SubsetNew.Click += new global::System.EventHandler(this.newSubSetMenu_Click);
			this.menuItemHelp.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.luaWebPageToolStripMenuItem,
				this.RadarICDLink,
				this.menuItemAbout
			});
			this.menuItemHelp.MergeIndex = 3;
			this.menuItemHelp.Name = "menuItemHelp";
			this.menuItemHelp.Size = new global::System.Drawing.Size(44, 20);
			this.menuItemHelp.Text = "&Help";
			this.luaWebPageToolStripMenuItem.Image = global::RSTD.Properties.Resources.luaImage;
			this.luaWebPageToolStripMenuItem.Name = "luaWebPageToolStripMenuItem";
			this.luaWebPageToolStripMenuItem.Size = new global::System.Drawing.Size(255, 22);
			this.luaWebPageToolStripMenuItem.Text = "Lua Web Page";
			this.luaWebPageToolStripMenuItem.Click += new global::System.EventHandler(this.luaWebPageToolStripMenuItem_Click);
			this.RadarICDLink.Name = "RadarICDLink";
			this.RadarICDLink.Size = new global::System.Drawing.Size(255, 22);
			this.RadarICDLink.Text = "Radar Interface Control Document";
			this.RadarICDLink.Click += new global::System.EventHandler(this.RadarICDLink_Click);
			this.menuItemAbout.Name = "menuItemAbout";
			this.menuItemAbout.Size = new global::System.Drawing.Size(255, 22);
			this.menuItemAbout.Text = "&About mmWave Studio...";
			this.menuItemAbout.Click += new global::System.EventHandler(this.menuItemAbout_Click);
			this.m_DockPanel.ActiveAutoHideContent = null;
			this.m_DockPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.m_DockPanel.DockBackColor = global::System.Drawing.SystemColors.AppWorkspace;
			this.m_DockPanel.Location = new global::System.Drawing.Point(0, 104);
			this.m_DockPanel.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_DockPanel.Name = "m_DockPanel";
			this.m_DockPanel.Size = new global::System.Drawing.Size(663, 303);
			dockPanelGradient.EndColor = global::System.Drawing.SystemColors.ControlLight;
			dockPanelGradient.StartColor = global::System.Drawing.SystemColors.ControlLight;
			autoHideStripSkin.DockStripGradient = dockPanelGradient;
			tabGradient.EndColor = global::System.Drawing.SystemColors.Control;
			tabGradient.StartColor = global::System.Drawing.SystemColors.Control;
			tabGradient.TextColor = global::System.Drawing.SystemColors.ControlDarkDark;
			autoHideStripSkin.TabGradient = tabGradient;
			dockPanelSkin.AutoHideStripSkin = autoHideStripSkin;
			tabGradient2.EndColor = global::System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.StartColor = global::System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.TextColor = global::System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient.ActiveTabGradient = tabGradient2;
			dockPanelGradient2.EndColor = global::System.Drawing.SystemColors.Control;
			dockPanelGradient2.StartColor = global::System.Drawing.SystemColors.Control;
			dockPaneStripGradient.DockStripGradient = dockPanelGradient2;
			tabGradient3.EndColor = global::System.Drawing.SystemColors.ControlLight;
			tabGradient3.StartColor = global::System.Drawing.SystemColors.ControlLight;
			tabGradient3.TextColor = global::System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient.InactiveTabGradient = tabGradient3;
			dockPaneStripSkin.DocumentGradient = dockPaneStripGradient;
			tabGradient4.EndColor = global::System.Drawing.SystemColors.ActiveCaption;
			tabGradient4.LinearGradientMode = global::System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient4.StartColor = global::System.Drawing.SystemColors.GradientActiveCaption;
			tabGradient4.TextColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			dockPaneStripToolWindowGradient.ActiveCaptionGradient = tabGradient4;
			tabGradient5.EndColor = global::System.Drawing.SystemColors.Control;
			tabGradient5.StartColor = global::System.Drawing.SystemColors.Control;
			tabGradient5.TextColor = global::System.Drawing.SystemColors.ControlText;
			dockPaneStripToolWindowGradient.ActiveTabGradient = tabGradient5;
			dockPanelGradient3.EndColor = global::System.Drawing.SystemColors.ControlLight;
			dockPanelGradient3.StartColor = global::System.Drawing.SystemColors.ControlLight;
			dockPaneStripToolWindowGradient.DockStripGradient = dockPanelGradient3;
			tabGradient6.EndColor = global::System.Drawing.SystemColors.ControlDark;
			tabGradient6.LinearGradientMode = global::System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient6.StartColor = global::System.Drawing.SystemColors.ControlDark;
			tabGradient6.TextColor = global::System.Drawing.SystemColors.ControlText;
			dockPaneStripToolWindowGradient.InactiveCaptionGradient = tabGradient6;
			tabGradient7.EndColor = global::System.Drawing.Color.Transparent;
			tabGradient7.StartColor = global::System.Drawing.Color.Transparent;
			tabGradient7.TextColor = global::System.Drawing.SystemColors.ControlDarkDark;
			dockPaneStripToolWindowGradient.InactiveTabGradient = tabGradient7;
			dockPaneStripSkin.ToolWindowGradient = dockPaneStripToolWindowGradient;
			dockPanelSkin.DockPaneStripSkin = dockPaneStripSkin;
			this.m_DockPanel.Skin = dockPanelSkin;
			this.m_DockPanel.TabIndex = 15;
			this.BottomToolStripPanel.Location = new global::System.Drawing.Point(0, 0);
			this.BottomToolStripPanel.Name = "BottomToolStripPanel";
			this.BottomToolStripPanel.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.BottomToolStripPanel.RowMargin = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.BottomToolStripPanel.Size = new global::System.Drawing.Size(0, 0);
			this.TopToolStripPanel.Location = new global::System.Drawing.Point(0, 0);
			this.TopToolStripPanel.Name = "TopToolStripPanel";
			this.TopToolStripPanel.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.TopToolStripPanel.RowMargin = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.TopToolStripPanel.Size = new global::System.Drawing.Size(0, 0);
			this.RightToolStripPanel.Location = new global::System.Drawing.Point(0, 0);
			this.RightToolStripPanel.Name = "RightToolStripPanel";
			this.RightToolStripPanel.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.RightToolStripPanel.RowMargin = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.RightToolStripPanel.Size = new global::System.Drawing.Size(0, 0);
			this.LeftToolStripPanel.Location = new global::System.Drawing.Point(0, 0);
			this.LeftToolStripPanel.Name = "LeftToolStripPanel";
			this.LeftToolStripPanel.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.LeftToolStripPanel.RowMargin = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.LeftToolStripPanel.Size = new global::System.Drawing.Size(0, 0);
			this.ContentPanel.BackColor = global::System.Drawing.Color.Transparent;
			this.ContentPanel.Size = new global::System.Drawing.Size(522, 190);
			this.toolStripContainer1.BottomToolStripPanelVisible = false;
			this.toolStripContainer1.ContentPanel.Size = new global::System.Drawing.Size(663, 0);
			this.toolStripContainer1.ContentPanel.Visible = false;
			this.toolStripContainer1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new global::System.Drawing.Point(0, 81);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new global::System.Drawing.Size(663, 23);
			this.toolStripContainer1.TabIndex = 18;
			this.toolStripContainer1.Text = "toolStripContainer1";
			this.toolStripContainer1.TopToolStripPanel.SizeChanged += new global::System.EventHandler(this.toolStripContainer1_TopToolStripPanel_SizeChanged);
			this.pictureBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.pictureBox1.BackColor = global::System.Drawing.SystemColors.Control;
			this.pictureBox1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBox1.ErrorImage = (global::System.Drawing.Image)resources.GetObject("pictureBox1.ErrorImage");
			this.pictureBox1.Image = (global::System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.InitialImage = (global::System.Drawing.Image)resources.GetObject("pictureBox1.InitialImage");
			this.pictureBox1.Location = new global::System.Drawing.Point(478, 432);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(169, 21);
			this.pictureBox1.TabIndex = 20;
			this.pictureBox1.TabStop = false;
			this.m_ToolBar.ClickThrough = true;
			this.m_ToolBar.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.m_ToolBar.ImageScalingSize = new global::System.Drawing.Size(49, 49);
			this.m_ToolBar.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_BrowseTreeBtn,
				this.m_toolStripSeparator2,
				this.m_MonitoredVarsBtn,
				this.m_toolStripSeparator6,
				this.m_WorkSetBtn,
				this.toolStripSeparator2,
				this.m_ConsoleBtn,
				this.toolStripSeparator1,
				this.m_btnLuaShell,
				this.toolStripSeparator5,
				this.m_btnLuaDebugger,
				this.m_btnMacroForm
			});
			this.m_ToolBar.Location = new global::System.Drawing.Point(0, 24);
			this.m_ToolBar.Name = "m_ToolBar";
			this.m_ToolBar.Size = new global::System.Drawing.Size(663, 57);
			this.m_ToolBar.TabIndex = 10;
			this.m_ToolBar.Text = "toolStrip1";
			this.m_BrowseTreeBtn.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_BrowseTreeBtn.Image = (global::System.Drawing.Image)resources.GetObject("m_BrowseTreeBtn.Image");
			this.m_BrowseTreeBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_BrowseTreeBtn.ImageTransparentColor = global::System.Drawing.Color.Transparent;
			this.m_BrowseTreeBtn.Name = "m_BrowseTreeBtn";
			this.m_BrowseTreeBtn.Size = new global::System.Drawing.Size(54, 54);
			this.m_BrowseTreeBtn.Text = "Browse Tree";
			this.m_BrowseTreeBtn.ToolTipText = "Browse exported tree";
			this.m_BrowseTreeBtn.Click += new global::System.EventHandler(this.m_BrowseTreeBtn_Click);
			this.m_toolStripSeparator2.Name = "m_toolStripSeparator2";
			this.m_toolStripSeparator2.Size = new global::System.Drawing.Size(6, 57);
			this.m_MonitoredVarsBtn.AutoSize = false;
			this.m_MonitoredVarsBtn.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_MonitoredVarsBtn.Image = (global::System.Drawing.Image)resources.GetObject("m_MonitoredVarsBtn.Image");
			this.m_MonitoredVarsBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_MonitoredVarsBtn.ImageTransparentColor = global::System.Drawing.Color.Transparent;
			this.m_MonitoredVarsBtn.Name = "m_MonitoredVarsBtn";
			this.m_MonitoredVarsBtn.Size = new global::System.Drawing.Size(49, 49);
			this.m_MonitoredVarsBtn.Text = "Monitored Variables";
			this.m_MonitoredVarsBtn.Click += new global::System.EventHandler(this.m_MonitoredVarsBtn_Click);
			this.m_toolStripSeparator6.Name = "m_toolStripSeparator6";
			this.m_toolStripSeparator6.Size = new global::System.Drawing.Size(6, 57);
			this.m_WorkSetBtn.AutoSize = false;
			this.m_WorkSetBtn.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_WorkSetBtn.Image = (global::System.Drawing.Image)resources.GetObject("m_WorkSetBtn.Image");
			this.m_WorkSetBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_WorkSetBtn.ImageTransparentColor = global::System.Drawing.Color.Transparent;
			this.m_WorkSetBtn.Name = "m_WorkSetBtn";
			this.m_WorkSetBtn.Size = new global::System.Drawing.Size(49, 49);
			this.m_WorkSetBtn.Text = "WorkSet";
			this.m_WorkSetBtn.Click += new global::System.EventHandler(this.m_WorkSetBtn_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(6, 57);
			this.m_ConsoleBtn.AutoSize = false;
			this.m_ConsoleBtn.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_ConsoleBtn.Image = (global::System.Drawing.Image)resources.GetObject("m_ConsoleBtn.Image");
			this.m_ConsoleBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_ConsoleBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_ConsoleBtn.Name = "m_ConsoleBtn";
			this.m_ConsoleBtn.Size = new global::System.Drawing.Size(49, 49);
			this.m_ConsoleBtn.Text = "Output";
			this.m_ConsoleBtn.ToolTipText = "Output";
			this.m_ConsoleBtn.Click += new global::System.EventHandler(this.m_ConsoleBtn_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(6, 57);
			this.m_btnLuaShell.AutoSize = false;
			this.m_btnLuaShell.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_btnLuaShell.Image = (global::System.Drawing.Image)resources.GetObject("m_btnLuaShell.Image");
			this.m_btnLuaShell.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_btnLuaShell.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnLuaShell.Name = "m_btnLuaShell";
			this.m_btnLuaShell.Size = new global::System.Drawing.Size(53, 49);
			this.m_btnLuaShell.Text = "Lua Shell";
			this.m_btnLuaShell.Click += new global::System.EventHandler(this.m_BtnLuaShell_Click);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new global::System.Drawing.Size(6, 57);
			this.m_btnLuaDebugger.AutoSize = false;
			this.m_btnLuaDebugger.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_btnLuaDebugger.Image = (global::System.Drawing.Image)resources.GetObject("m_btnLuaDebugger.Image");
			this.m_btnLuaDebugger.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnLuaDebugger.Name = "m_btnLuaDebugger";
			this.m_btnLuaDebugger.Size = new global::System.Drawing.Size(49, 49);
			this.m_btnLuaDebugger.Text = "Lua Debugger";
			this.m_btnLuaDebugger.Click += new global::System.EventHandler(this.m_btnLuaDebugger_Click);
			this.m_btnMacroForm.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_btnMacroForm.Image = (global::System.Drawing.Image)resources.GetObject("m_btnMacroForm.Image");
			this.m_btnMacroForm.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_btnMacroForm.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnMacroForm.Name = "m_btnMacroForm";
			this.m_btnMacroForm.Size = new global::System.Drawing.Size(54, 54);
			this.m_btnMacroForm.Text = "Recorder";
			this.m_btnMacroForm.Click += new global::System.EventHandler(this.m_btnMacroForm_Click);
			this.m_BottomToolStrip.ClickThrough = true;
			this.m_BottomToolStrip.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.m_BottomToolStrip.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.m_BottomToolStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_btnDebug,
				this.m_ScriptRunStopBtn,
				this.m_btnPause,
				this.m_ScriptNameComboBox,
				this.m_ScriptBrowseBtn,
				this.m_EditScriptBtn,
				this.m_btnDebuggerEdit
			});
			this.m_BottomToolStrip.LayoutStyle = global::System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.m_BottomToolStrip.Location = new global::System.Drawing.Point(0, 407);
			this.m_BottomToolStrip.Name = "m_BottomToolStrip";
			this.m_BottomToolStrip.Size = new global::System.Drawing.Size(663, 26);
			this.m_BottomToolStrip.TabIndex = 2;
			this.m_BottomToolStrip.Text = "toolStrip1";
			this.m_BottomToolStrip.Resize += new global::System.EventHandler(this.m_BottomToolStrip_Resize);
			this.m_btnDebug.Image = (global::System.Drawing.Image)resources.GetObject("m_btnDebug.Image");
			this.m_btnDebug.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnDebug.Name = "m_btnDebug";
			this.m_btnDebug.Size = new global::System.Drawing.Size(62, 23);
			this.m_btnDebug.Text = "Debug";
			this.m_btnDebug.ToolTipText = "Debug (Run in Lua Debugger)";
			this.m_btnDebug.Click += new global::System.EventHandler(this.m_btnDebug_Click);
			this.m_ScriptRunStopBtn.AutoSize = false;
			this.m_ScriptRunStopBtn.Image = (global::System.Drawing.Image)resources.GetObject("m_ScriptRunStopBtn.Image");
			this.m_ScriptRunStopBtn.ImageTransparentColor = global::System.Drawing.Color.White;
			this.m_ScriptRunStopBtn.Name = "m_ScriptRunStopBtn";
			this.m_ScriptRunStopBtn.Size = new global::System.Drawing.Size(60, 23);
			this.m_ScriptRunStopBtn.Text = "Run!";
			this.m_ScriptRunStopBtn.Click += new global::System.EventHandler(this.m_ScriptRunStopBtn_Click);
			this.m_btnPause.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_btnPause.Enabled = false;
			this.m_btnPause.Image = (global::System.Drawing.Image)resources.GetObject("m_btnPause.Image");
			this.m_btnPause.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnPause.Name = "m_btnPause";
			this.m_btnPause.Size = new global::System.Drawing.Size(42, 23);
			this.m_btnPause.Text = "Pause";
			this.m_btnPause.Click += new global::System.EventHandler(this.m_btnPause_Click);
			this.m_ScriptNameComboBox.AutoSize = false;
			this.m_ScriptNameComboBox.Name = "m_ScriptNameComboBox";
			this.m_ScriptNameComboBox.Overflow = global::System.Windows.Forms.ToolStripItemOverflow.Never;
			this.m_ScriptNameComboBox.Size = new global::System.Drawing.Size(280, 23);
			this.m_ScriptNameComboBox.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.m_ScriptNameComboBox_KeyDown);
			this.m_ScriptBrowseBtn.Image = (global::System.Drawing.Image)resources.GetObject("m_ScriptBrowseBtn.Image");
			this.m_ScriptBrowseBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_ScriptBrowseBtn.Name = "m_ScriptBrowseBtn";
			this.m_ScriptBrowseBtn.Size = new global::System.Drawing.Size(65, 23);
			this.m_ScriptBrowseBtn.Text = "Browse";
			this.m_ScriptBrowseBtn.ToolTipText = "Browse for script files";
			this.m_ScriptBrowseBtn.Click += new global::System.EventHandler(this.m_ScriptBrowseBtn_Click);
			this.m_EditScriptBtn.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_EditScriptBtn.Image = (global::System.Drawing.Image)resources.GetObject("m_EditScriptBtn.Image");
			this.m_EditScriptBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_EditScriptBtn.Name = "m_EditScriptBtn";
			this.m_EditScriptBtn.Size = new global::System.Drawing.Size(23, 23);
			this.m_EditScriptBtn.Text = "Edit script";
			this.m_EditScriptBtn.Click += new global::System.EventHandler(this.m_EditScriptBtn_Click);
			this.m_btnDebuggerEdit.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_btnDebuggerEdit.Image = global::RSTD.Properties.Resources.edit_debug;
			this.m_btnDebuggerEdit.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnDebuggerEdit.Name = "m_btnDebuggerEdit";
			this.m_btnDebuggerEdit.Size = new global::System.Drawing.Size(23, 23);
			this.m_btnDebuggerEdit.Text = "Edit in Debugger";
			this.m_btnDebuggerEdit.Click += new global::System.EventHandler(this.m_btnDebuggerEdit_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new global::System.Drawing.Size(663, 455);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.m_DockPanel);
			base.Controls.Add(this.toolStripContainer1);
			base.Controls.Add(this.m_ToolBar);
			base.Controls.Add(this.mainMenu);
			base.Controls.Add(this.m_BottomToolStrip);
			base.Controls.Add(this.m_StatusStrip);
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.IsMdiContainer = true;
			base.KeyPreview = true;
			base.Name = "frmMain";
			this.Text = "Radar Studio";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			base.Load += new global::System.EventHandler(this.frmMain_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
			this.m_StatusStrip.ResumeLayout(false);
			this.m_StatusStrip.PerformLayout();
			this.m_UserButtonsContextMenuStrip.ResumeLayout(false);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.m_ToolBar.ResumeLayout(false);
			this.m_ToolBar.PerformLayout();
			this.m_BottomToolStrip.ResumeLayout(false);
			this.m_BottomToolStrip.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.StatusStrip m_StatusStrip;


		private global::RSTD.ToolStripEx m_BottomToolStrip;


		private global::System.Windows.Forms.ToolStripButton m_ScriptRunStopBtn;


		private global::System.Windows.Forms.ToolStripComboBox m_ScriptNameComboBox;


		private global::System.Windows.Forms.ToolStripButton m_ScriptBrowseBtn;


		private global::System.Windows.Forms.ImageList m_ToolBarImageList;


		private global::System.Windows.Forms.ToolStripButton m_EditScriptBtn;


		private global::System.Windows.Forms.ContextMenuStrip m_UserButtonsContextMenuStrip;


		private global::System.Windows.Forms.ToolStripMenuItem EditScriptToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem LoadButtonsToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem SaveButtonsToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem EditButtonToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem DeleteButtonToolStripMenuItem;


		private global::System.Windows.Forms.MenuStrip mainMenu;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemFile;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemLoadLayout;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemSaveLayout;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemCloseAll;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemCloseAllButThisOne;


		private global::System.Windows.Forms.ToolStripSeparator menuItem4;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemExit;


		private global::System.Windows.Forms.ToolStripMenuItem exitWithoutSavingLayout;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemView;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemOutput;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemBrowseTree;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemMonitors;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemWorkSet;


		private global::System.Windows.Forms.ToolStripSeparator menuItem1;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemStatusBar;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemTools;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemLockLayout;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemWindow;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemHelp;


		private global::RSTD.ToolStripEx m_ToolBar;


		private global::System.Windows.Forms.ToolStripButton m_BrowseTreeBtn;


		private global::System.Windows.Forms.ToolStripSeparator m_toolStripSeparator2;


		private global::System.Windows.Forms.ToolStripButton m_MonitoredVarsBtn;


		private global::System.Windows.Forms.ToolStripSeparator m_toolStripSeparator6;


		private global::System.Windows.Forms.ToolStripButton m_ConsoleBtn;


		private global::System.Windows.Forms.ToolStripMenuItem toolBarsToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemStandardToolBar;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemUserButtonsToolBar;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemScriptToolBar;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemClose;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemOperations;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemBuild;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemUnBuild;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemGo;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemStop;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemALBuild;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemALInit;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemALReset;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemClientBuild;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemClientInit;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemClientReset;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemClientUnbuild;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemALUnbuild;


		private global::WeifenLuo.WinFormsUI.Docking.DockPanel m_DockPanel;


		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;


		private global::System.Windows.Forms.ToolStripButton m_WorkSetBtn;


		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;


		private global::System.Windows.Forms.ToolStripButton m_btnLuaShell;


		private global::System.Windows.Forms.ToolStripMenuItem MenuItemLuaShell;


		private global::System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem registerDllsToLuaToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripButton m_btnPause;


		private global::System.Windows.Forms.ToolStripButton m_btnLuaDebugger;


		private global::System.Windows.Forms.ToolStripMenuItem luaWebPageToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator5;


		private global::System.Windows.Forms.ToolStripButton m_btnDebuggerEdit;


		private global::System.Windows.Forms.ToolStripMenuItem addButtonsToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;


		private global::System.Windows.Forms.ToolStripStatusLabel m_lblNetClientStatus;


		private global::System.Windows.Forms.ToolStripMenuItem DebugScriptToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem changeToolbarNameToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem toolBarsToolStripMenuItem1;


		private global::System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripPanel BottomToolStripPanel;


		private global::System.Windows.Forms.ToolStripPanel TopToolStripPanel;


		private global::System.Windows.Forms.ToolStripPanel RightToolStripPanel;


		private global::System.Windows.Forms.ToolStripPanel LeftToolStripPanel;


		private global::System.Windows.Forms.ToolStripContentPanel ContentPanel;


		private global::System.Windows.Forms.ToolStripContainer toolStripContainer1;


		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator3;


		private global::System.Windows.Forms.ToolStripMenuItem openToolBarsFolderToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripButton m_btnDebug;


		private global::System.Windows.Forms.ToolStripButton m_btnMacroForm;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemSubSet;


		private global::System.Windows.Forms.ToolStripMenuItem m_SubsetLoad;


		private global::System.Windows.Forms.ToolStripMenuItem m_SubsetNew;


		private global::System.Windows.Forms.ToolStripMenuItem RadarICDLink;


		private global::System.Windows.Forms.ToolStripMenuItem menuItemAbout;


		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;


		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;


		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
