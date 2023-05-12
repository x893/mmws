namespace RSTD
{

	public partial class frmLuaShell : global::WeifenLuo.WinFormsUI.Docking.DockContent
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.frmLuaShell));
			this.m_ToolStripSeperator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_ToolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_SettingsBtn = new global::System.Windows.Forms.ToolStripDropDownButton();
			this.m_color = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_foregroundColor = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_BackgroundColor = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_font = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_ShowLastFileBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_DeleteAllFilesBtn = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripEx1 = new global::RSTD.ToolStripEx();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_ToolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripSplitButton1 = new global::System.Windows.Forms.ToolStripSplitButton();
			this.colorToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.foregroundColorToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.backgroundColorToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.fontToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.defaultToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_SaveBtn = new global::System.Windows.Forms.ToolStripSplitButton();
			this.saveLuaShellCommandsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.saveLuaShellToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.saveLuaShellLayoutToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_LoadBtn = new global::System.Windows.Forms.ToolStripSplitButton();
			this.loadCommandFleToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.loadLuaShellLayoutToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripDropDownButton1 = new global::System.Windows.Forms.ToolStripDropDownButton();
			this.beginBlockToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.endBlockToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.breakBlockToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_btnAbort = new global::System.Windows.Forms.ToolStripButton();
			this.m_BottomToolStrip = new global::RSTD.ToolStripEx();
			this.toolStripEx1.SuspendLayout();
			base.SuspendLayout();
			this.m_ToolStripSeperator1.Name = "m_ToolStripSeperator1";
			this.m_ToolStripSeperator1.Size = new global::System.Drawing.Size(6, 25);
			this.m_ToolStripSeparator3.Name = "m_ToolStripSeparator3";
			this.m_ToolStripSeparator3.Size = new global::System.Drawing.Size(6, 25);
			this.m_SettingsBtn.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_SettingsBtn.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_color,
				this.m_font
			});
			this.m_SettingsBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_SettingsBtn.Image");
			this.m_SettingsBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_SettingsBtn.Name = "m_SettingsBtn";
			this.m_SettingsBtn.RightToLeftAutoMirrorImage = true;
			this.m_SettingsBtn.Size = new global::System.Drawing.Size(59, 24);
			this.m_SettingsBtn.Text = "Settings";
			this.m_color.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_foregroundColor,
				this.m_BackgroundColor
			});
			this.m_color.Name = "m_color";
			this.m_color.Size = new global::System.Drawing.Size(103, 22);
			this.m_color.Text = "Color";
			this.m_foregroundColor.Name = "m_foregroundColor";
			this.m_foregroundColor.Size = new global::System.Drawing.Size(170, 22);
			this.m_foregroundColor.Text = "Foreground Color";
			this.m_foregroundColor.Click += new global::System.EventHandler(this.h_foregroundColorToolStripMenuItem_Click);
			this.m_BackgroundColor.Name = "m_BackgroundColor";
			this.m_BackgroundColor.Size = new global::System.Drawing.Size(170, 22);
			this.m_BackgroundColor.Text = "Background Color";
			this.m_BackgroundColor.Click += new global::System.EventHandler(this.h_BackgroundColorToolStripMenuItem_Click);
			this.m_font.Name = "m_font";
			this.m_font.Size = new global::System.Drawing.Size(103, 22);
			this.m_font.Text = "Font ";
			this.m_ShowLastFileBtn.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_ShowLastFileBtn.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_ShowLastFileBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_ShowLastFileBtn.Image");
			this.m_ShowLastFileBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_ShowLastFileBtn.Name = "m_ShowLastFileBtn";
			this.m_ShowLastFileBtn.Size = new global::System.Drawing.Size(79, 24);
			this.m_ShowLastFileBtn.Text = "Show Last File";
			this.m_DeleteAllFilesBtn.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_DeleteAllFilesBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_DeleteAllFilesBtn.Image");
			this.m_DeleteAllFilesBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_DeleteAllFilesBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_DeleteAllFilesBtn.Name = "m_DeleteAllFilesBtn";
			this.m_DeleteAllFilesBtn.Size = new global::System.Drawing.Size(96, 24);
			this.m_DeleteAllFilesBtn.Text = "Delete All Files";
			this.toolStripEx1.ClickThrough = true;
			this.toolStripEx1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.toolStripEx1.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripEx1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripSeparator1,
				this.m_ToolStripSeparator4,
				this.toolStripSplitButton1,
				this.m_SaveBtn,
				this.m_LoadBtn,
				this.toolStripSeparator2,
				this.toolStripDropDownButton1,
				this.m_btnAbort
			});
			this.toolStripEx1.Location = new global::System.Drawing.Point(0, 216);
			this.toolStripEx1.Name = "toolStripEx1";
			this.toolStripEx1.Size = new global::System.Drawing.Size(432, 28);
			this.toolStripEx1.TabIndex = 3;
			this.toolStripEx1.Text = "toolStrip1";
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(6, 28);
			this.m_ToolStripSeparator4.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_ToolStripSeparator4.Name = "m_ToolStripSeparator4";
			this.m_ToolStripSeparator4.Size = new global::System.Drawing.Size(6, 28);
			this.toolStripSplitButton1.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripSplitButton1.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.colorToolStripMenuItem,
				this.fontToolStripMenuItem,
				this.defaultToolStripMenuItem
			});
			this.toolStripSplitButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("toolStripSplitButton1.Image");
			this.toolStripSplitButton1.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.toolStripSplitButton1.Name = "toolStripSplitButton1";
			this.toolStripSplitButton1.Size = new global::System.Drawing.Size(65, 25);
			this.toolStripSplitButton1.Text = "Settings";
			this.colorToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.foregroundColorToolStripMenuItem,
				this.backgroundColorToolStripMenuItem
			});
			this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
			this.colorToolStripMenuItem.Size = new global::System.Drawing.Size(112, 22);
			this.colorToolStripMenuItem.Text = "Color";
			this.foregroundColorToolStripMenuItem.Name = "foregroundColorToolStripMenuItem";
			this.foregroundColorToolStripMenuItem.Size = new global::System.Drawing.Size(168, 22);
			this.foregroundColorToolStripMenuItem.Text = "Foreground Color";
			this.foregroundColorToolStripMenuItem.Click += new global::System.EventHandler(this.h_foregroundColorToolStripMenuItem_Click);
			this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
			this.backgroundColorToolStripMenuItem.Size = new global::System.Drawing.Size(168, 22);
			this.backgroundColorToolStripMenuItem.Text = "BackgroundColor";
			this.backgroundColorToolStripMenuItem.Click += new global::System.EventHandler(this.h_BackgroundColorToolStripMenuItem_Click);
			this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
			this.fontToolStripMenuItem.Size = new global::System.Drawing.Size(112, 22);
			this.fontToolStripMenuItem.Text = "Font";
			this.fontToolStripMenuItem.Click += new global::System.EventHandler(this.fontToolStripMenuItem_Click_1);
			this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
			this.defaultToolStripMenuItem.Size = new global::System.Drawing.Size(112, 22);
			this.defaultToolStripMenuItem.Text = "Default";
			this.defaultToolStripMenuItem.Click += new global::System.EventHandler(this.hDefaultToolStripMenuItem_Click);
			this.m_SaveBtn.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.saveLuaShellCommandsToolStripMenuItem,
				this.saveLuaShellToolStripMenuItem,
				this.saveLuaShellLayoutToolStripMenuItem
			});
			this.m_SaveBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_SaveBtn.Image");
			this.m_SaveBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_SaveBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_SaveBtn.Name = "m_SaveBtn";
			this.m_SaveBtn.Size = new global::System.Drawing.Size(69, 25);
			this.m_SaveBtn.Text = "Save";
			this.m_SaveBtn.ToolTipText = "Save monitor settings to file";
			this.m_SaveBtn.ButtonClick += new global::System.EventHandler(this.hSaveBtn_ButtonClick);
			this.saveLuaShellCommandsToolStripMenuItem.Name = "saveLuaShellCommandsToolStripMenuItem";
			this.saveLuaShellCommandsToolStripMenuItem.Size = new global::System.Drawing.Size(213, 22);
			this.saveLuaShellCommandsToolStripMenuItem.Text = "Save Lua Shell Commands";
			this.saveLuaShellCommandsToolStripMenuItem.Click += new global::System.EventHandler(this.hSaveLuaShellCommandsToolStripMenuItem_Click);
			this.saveLuaShellToolStripMenuItem.Name = "saveLuaShellToolStripMenuItem";
			this.saveLuaShellToolStripMenuItem.Size = new global::System.Drawing.Size(213, 22);
			this.saveLuaShellToolStripMenuItem.Text = "Save Lua Shell";
			this.saveLuaShellToolStripMenuItem.Click += new global::System.EventHandler(this.iSaveAllLuaShellToolStripMenuItem_Click);
			this.saveLuaShellLayoutToolStripMenuItem.Name = "saveLuaShellLayoutToolStripMenuItem";
			this.saveLuaShellLayoutToolStripMenuItem.Size = new global::System.Drawing.Size(213, 22);
			this.saveLuaShellLayoutToolStripMenuItem.Text = "Save Lua Shell Layout";
			this.saveLuaShellLayoutToolStripMenuItem.Click += new global::System.EventHandler(this.saveLuaShellLayoutToolStripMenuItem_Click);
			this.m_LoadBtn.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.loadCommandFleToolStripMenuItem,
				this.loadLuaShellLayoutToolStripMenuItem
			});
			this.m_LoadBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_LoadBtn.Image");
			this.m_LoadBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_LoadBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_LoadBtn.Name = "m_LoadBtn";
			this.m_LoadBtn.Size = new global::System.Drawing.Size(65, 25);
			this.m_LoadBtn.Text = "Load";
			this.m_LoadBtn.ToolTipText = "Load monitor settings from file";
			this.loadCommandFleToolStripMenuItem.Name = "loadCommandFleToolStripMenuItem";
			this.loadCommandFleToolStripMenuItem.Size = new global::System.Drawing.Size(208, 22);
			this.loadCommandFleToolStripMenuItem.Text = "Load Lua Commands File";
			this.loadCommandFleToolStripMenuItem.Click += new global::System.EventHandler(this.loadCommandFleToolStripMenuItem_Click);
			this.loadLuaShellLayoutToolStripMenuItem.Name = "loadLuaShellLayoutToolStripMenuItem";
			this.loadLuaShellLayoutToolStripMenuItem.Size = new global::System.Drawing.Size(208, 22);
			this.loadLuaShellLayoutToolStripMenuItem.Text = "Load Lua Shell Layout";
			this.loadLuaShellLayoutToolStripMenuItem.Click += new global::System.EventHandler(this.loadLuaShellLayoutToolStripMenuItem_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(6, 28);
			this.toolStripDropDownButton1.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.beginBlockToolStripMenuItem,
				this.endBlockToolStripMenuItem,
				this.breakBlockToolStripMenuItem
			});
			this.toolStripDropDownButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("toolStripDropDownButton1.Image");
			this.toolStripDropDownButton1.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new global::System.Drawing.Size(124, 25);
			this.toolStripDropDownButton1.Text = "{ } Block Operations";
			this.beginBlockToolStripMenuItem.Image = global::RSTD.Properties.Resources.bracket_curley_left;
			this.beginBlockToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.Transparent;
			this.beginBlockToolStripMenuItem.Name = "beginBlockToolStripMenuItem";
			this.beginBlockToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)262210;
			this.beginBlockToolStripMenuItem.Size = new global::System.Drawing.Size(201, 22);
			this.beginBlockToolStripMenuItem.Text = "BeginBlock";
			this.beginBlockToolStripMenuItem.Click += new global::System.EventHandler(this.beginBlockToolStripMenuItem_Click);
			this.endBlockToolStripMenuItem.Image = global::RSTD.Properties.Resources.bracket_curley_right;
			this.endBlockToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.Transparent;
			this.endBlockToolStripMenuItem.Name = "endBlockToolStripMenuItem";
			this.endBlockToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)262213;
			this.endBlockToolStripMenuItem.Size = new global::System.Drawing.Size(201, 22);
			this.endBlockToolStripMenuItem.Text = "EndBlock";
			this.endBlockToolStripMenuItem.Click += new global::System.EventHandler(this.endBlockToolStripMenuItem_Click);
			this.breakBlockToolStripMenuItem.Name = "breakBlockToolStripMenuItem";
			this.breakBlockToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)327746;
			this.breakBlockToolStripMenuItem.Size = new global::System.Drawing.Size(201, 22);
			this.breakBlockToolStripMenuItem.Text = "BreakBlock";
			this.breakBlockToolStripMenuItem.Click += new global::System.EventHandler(this.breakBlockToolStripMenuItem_Click);
			this.m_btnAbort.Enabled = false;
			this.m_btnAbort.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_btnAbort.Image");
			this.m_btnAbort.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnAbort.Name = "m_btnAbort";
			this.m_btnAbort.Size = new global::System.Drawing.Size(57, 25);
			this.m_btnAbort.Text = "Abort";
			this.m_btnAbort.ToolTipText = "Abort (Ctrl+Q)";
			this.m_btnAbort.Click += new global::System.EventHandler(this.btnAbort_Click);
			this.m_BottomToolStrip.ClickThrough = true;
			this.m_BottomToolStrip.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.m_BottomToolStrip.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.m_BottomToolStrip.Location = new global::System.Drawing.Point(0, 244);
			this.m_BottomToolStrip.Name = "m_BottomToolStrip";
			this.m_BottomToolStrip.Size = new global::System.Drawing.Size(432, 25);
			this.m_BottomToolStrip.TabIndex = 2;
			this.m_BottomToolStrip.Text = "toolStrip1";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.Control;
			base.ClientSize = new global::System.Drawing.Size(432, 269);
			base.Controls.Add(this.toolStripEx1);
			base.Controls.Add(this.m_BottomToolStrip);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmLuaShell";
			base.TabText = "Lua Shell";
			this.Text = "Lua Shell";
			this.toolStripEx1.ResumeLayout(false);
			this.toolStripEx1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::RSTD.ToolStripEx m_BottomToolStrip;


		private global::System.Windows.Forms.ToolStripButton m_ShowLastFileBtn;


		private global::System.Windows.Forms.ToolStripSeparator m_ToolStripSeperator1;


		private global::System.Windows.Forms.ToolStripButton m_DeleteAllFilesBtn;


		private global::System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator3;


		private global::System.Windows.Forms.ToolStripDropDownButton m_SettingsBtn;


		private global::System.Windows.Forms.ToolStripMenuItem m_font;


		private global::System.Windows.Forms.ToolStripMenuItem m_color;


		private global::System.Windows.Forms.ToolStripMenuItem m_foregroundColor;


		private global::System.Windows.Forms.ToolStripMenuItem m_BackgroundColor;


		private global::RSTD.ToolStripEx toolStripEx1;


		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;


		private global::System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator4;


		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;


		private global::System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;


		private global::System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem foregroundColorToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripSplitButton m_SaveBtn;


		private global::System.Windows.Forms.ToolStripMenuItem saveLuaShellCommandsToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem saveLuaShellToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem saveLuaShellLayoutToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripSplitButton m_LoadBtn;


		private global::System.Windows.Forms.ToolStripMenuItem loadCommandFleToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem loadLuaShellLayoutToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;


		private global::System.Windows.Forms.ToolStripMenuItem beginBlockToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem endBlockToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem breakBlockToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripButton m_btnAbort;
	}
}
