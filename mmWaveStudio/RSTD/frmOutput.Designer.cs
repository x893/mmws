namespace RSTD
{

	public partial class frmOutput : global::WeifenLuo.WinFormsUI.Docking.DockContent
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.frmOutput));
			this.m_ConsoleTextContextMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.ConsoleTextMenuCopy = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.ConsoleTextMenuClear = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.showUserLogToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ConsoleTextMenuShowLogFile = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ConsoleTextMenuShowVerboseLog = new global::System.Windows.Forms.ToolStripMenuItem();
			this.openLogFolderToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ConsoleTextMenuZoom = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ConsoleTextMenuZoomComboBox = new global::System.Windows.Forms.ToolStripComboBox();
			this.m_toolStrip = new global::System.Windows.Forms.ToolStrip();
			this.btnClear = new global::System.Windows.Forms.ToolStripButton();
			this.btnAutoScroll = new global::System.Windows.Forms.ToolStripButton();
			this.m_txtInclude = new global::System.Windows.Forms.ToolStripTextBox();
			this.m_lblInclude = new global::System.Windows.Forms.ToolStripLabel();
			this.m_txtExclude = new global::System.Windows.Forms.ToolStripTextBox();
			this.m_lblExclude = new global::System.Windows.Forms.ToolStripLabel();
			this.toolStripButton1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_btnUserMsgMask = new global::System.Windows.Forms.ToolStripButton();
			this.m_ConsoleText = new global::System.Windows.Forms.RichTextBox();
			this.m_ConsoleTextContextMenuStrip.SuspendLayout();
			this.m_toolStrip.SuspendLayout();
			base.SuspendLayout();
			this.m_ConsoleTextContextMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.ConsoleTextMenuCopy,
				this.toolStripSeparator1,
				this.ConsoleTextMenuClear,
				this.toolStripSeparator2,
				this.showUserLogToolStripMenuItem,
				this.ConsoleTextMenuShowLogFile,
				this.ConsoleTextMenuShowVerboseLog,
				this.openLogFolderToolStripMenuItem,
				this.ConsoleTextMenuZoom
			});
			this.m_ConsoleTextContextMenuStrip.Name = "ConsoleTextContextMenuStrip";
			this.m_ConsoleTextContextMenuStrip.Size = new global::System.Drawing.Size(172, 170);
			this.ConsoleTextMenuCopy.Name = "ConsoleTextMenuCopy";
			this.ConsoleTextMenuCopy.Size = new global::System.Drawing.Size(171, 22);
			this.ConsoleTextMenuCopy.Text = "Copy";
			this.ConsoleTextMenuCopy.Click += new global::System.EventHandler(this.ConsoleTextMenuCopy_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(168, 6);
			this.ConsoleTextMenuClear.Name = "ConsoleTextMenuClear";
			this.ConsoleTextMenuClear.Size = new global::System.Drawing.Size(171, 22);
			this.ConsoleTextMenuClear.Text = "Clear";
			this.ConsoleTextMenuClear.Click += new global::System.EventHandler(this.ConsoleTextMenuClear_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(168, 6);
			this.showUserLogToolStripMenuItem.Name = "showUserLogToolStripMenuItem";
			this.showUserLogToolStripMenuItem.Size = new global::System.Drawing.Size(171, 22);
			this.showUserLogToolStripMenuItem.Text = "Show User Log";
			this.showUserLogToolStripMenuItem.Click += new global::System.EventHandler(this.showUserLogToolStripMenuItem_Click);
			this.ConsoleTextMenuShowLogFile.Name = "ConsoleTextMenuShowLogFile";
			this.ConsoleTextMenuShowLogFile.Size = new global::System.Drawing.Size(171, 22);
			this.ConsoleTextMenuShowLogFile.Text = "Show Log File";
			this.ConsoleTextMenuShowLogFile.Click += new global::System.EventHandler(this.ConsoleTextMenuShowLogFile_Click);
			this.ConsoleTextMenuShowVerboseLog.Name = "ConsoleTextMenuShowVerboseLog";
			this.ConsoleTextMenuShowVerboseLog.Size = new global::System.Drawing.Size(171, 22);
			this.ConsoleTextMenuShowVerboseLog.Text = "Show Verbose Log";
			this.ConsoleTextMenuShowVerboseLog.Click += new global::System.EventHandler(this.ConsoleTextMenuShowVerboseLog_Click);
			this.openLogFolderToolStripMenuItem.Name = "openLogFolderToolStripMenuItem";
			this.openLogFolderToolStripMenuItem.Size = new global::System.Drawing.Size(171, 22);
			this.openLogFolderToolStripMenuItem.Text = "Open Log Folder";
			this.openLogFolderToolStripMenuItem.Click += new global::System.EventHandler(this.openLogFolderToolStripMenuItem_Click);
			this.ConsoleTextMenuZoom.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.ConsoleTextMenuZoomComboBox
			});
			this.ConsoleTextMenuZoom.Name = "ConsoleTextMenuZoom";
			this.ConsoleTextMenuZoom.Size = new global::System.Drawing.Size(171, 22);
			this.ConsoleTextMenuZoom.Text = "Zoom";
			this.ConsoleTextMenuZoomComboBox.Items.AddRange(new object[]
			{
				"3.0",
				"2.5",
				"2.0",
				"1.5",
				"1.2",
				"1.0",
				"0.9",
				"0.8",
				"0.7",
				"0.6",
				"0.5"
			});
			this.ConsoleTextMenuZoomComboBox.Name = "ConsoleTextMenuZoomComboBox";
			this.ConsoleTextMenuZoomComboBox.Size = new global::System.Drawing.Size(75, 23);
			this.ConsoleTextMenuZoomComboBox.Text = "1.0";
			this.ConsoleTextMenuZoomComboBox.SelectedIndexChanged += new global::System.EventHandler(this.ConsoleTextMenuZoomComboBox_SelectedIndexChanged);
			this.m_toolStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.btnClear,
				this.btnAutoScroll,
				this.m_txtInclude,
				this.m_lblInclude,
				this.m_txtExclude,
				this.m_lblExclude,
				this.toolStripButton1,
				this.m_btnUserMsgMask
			});
			this.m_toolStrip.Location = new global::System.Drawing.Point(0, 0);
			this.m_toolStrip.Name = "m_toolStrip";
			this.m_toolStrip.Size = new global::System.Drawing.Size(520, 25);
			this.m_toolStrip.TabIndex = 5;
			this.m_toolStrip.Text = "toolStrip1";
			this.m_toolStrip.Resize += new global::System.EventHandler(this.m_toolStrip_Resize);
			this.btnClear.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnClear.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("btnClear.Image");
			this.btnClear.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new global::System.Drawing.Size(23, 22);
			this.btnClear.Text = "Clear";
			this.btnClear.Click += new global::System.EventHandler(this.btnClear_Click);
			this.btnAutoScroll.CheckOnClick = true;
			this.btnAutoScroll.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAutoScroll.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("btnAutoScroll.Image");
			this.btnAutoScroll.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.btnAutoScroll.Name = "btnAutoScroll";
			this.btnAutoScroll.Size = new global::System.Drawing.Size(23, 22);
			this.btnAutoScroll.Text = "AutoScroll";
			this.btnAutoScroll.Click += new global::System.EventHandler(this.btnAutoScroll_Click);
			this.m_txtInclude.AcceptsReturn = true;
			this.m_txtInclude.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_txtInclude.AutoSize = false;
			this.m_txtInclude.Name = "m_txtInclude";
			this.m_txtInclude.Overflow = global::System.Windows.Forms.ToolStripItemOverflow.Never;
			this.m_txtInclude.Size = new global::System.Drawing.Size(91, 21);
			this.m_txtInclude.ToolTipText = "Filter screen output- semicolon (;) delimited ";
			this.m_txtInclude.Leave += new global::System.EventHandler(this.m_txtFilter_Leave);
			this.m_txtInclude.TextChanged += new global::System.EventHandler(this.m_txtInclude_TextChanged);
			this.m_lblInclude.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_lblInclude.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_lblInclude.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_lblInclude.Image");
			this.m_lblInclude.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_lblInclude.Name = "m_lblInclude";
			this.m_lblInclude.Size = new global::System.Drawing.Size(26, 22);
			this.m_lblInclude.Text = "Inc:";
			this.m_txtExclude.AcceptsReturn = true;
			this.m_txtExclude.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_txtExclude.AutoSize = false;
			this.m_txtExclude.Name = "m_txtExclude";
			this.m_txtExclude.Overflow = global::System.Windows.Forms.ToolStripItemOverflow.Never;
			this.m_txtExclude.Size = new global::System.Drawing.Size(91, 21);
			this.m_txtExclude.ToolTipText = "Filter screen output- semicolon (;) delimited ";
			this.m_txtExclude.Leave += new global::System.EventHandler(this.m_txtFilter_Leave);
			this.m_txtExclude.TextChanged += new global::System.EventHandler(this.m_txtExclude_TextChanged);
			this.m_lblExclude.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_lblExclude.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_lblExclude.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_lblExclude.Image");
			this.m_lblExclude.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_lblExclude.Name = "m_lblExclude";
			this.m_lblExclude.Size = new global::System.Drawing.Size(27, 22);
			this.m_lblExclude.Text = "Exc:";
			this.toolStripButton1.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new global::System.Drawing.Size(6, 25);
			this.m_btnUserMsgMask.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_btnUserMsgMask.CheckOnClick = true;
			this.m_btnUserMsgMask.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_btnUserMsgMask.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_btnUserMsgMask.Image");
			this.m_btnUserMsgMask.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnUserMsgMask.Name = "m_btnUserMsgMask";
			this.m_btnUserMsgMask.Size = new global::System.Drawing.Size(123, 22);
			this.m_btnUserMsgMask.Text = "Script Messages Only";
			this.m_btnUserMsgMask.Click += new global::System.EventHandler(this.m_btnUserMsgMask_Click);
			this.m_ConsoleText.BackColor = global::System.Drawing.SystemColors.Window;
			this.m_ConsoleText.ContextMenuStrip = this.m_ConsoleTextContextMenuStrip;
			this.m_ConsoleText.DetectUrls = false;
			this.m_ConsoleText.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.m_ConsoleText.Font = new global::System.Drawing.Font("Courier New", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_ConsoleText.ForeColor = global::System.Drawing.SystemColors.WindowText;
			this.m_ConsoleText.Location = new global::System.Drawing.Point(0, 25);
			this.m_ConsoleText.Name = "m_ConsoleText";
			this.m_ConsoleText.ReadOnly = true;
			this.m_ConsoleText.Size = new global::System.Drawing.Size(520, 352);
			this.m_ConsoleText.TabIndex = 6;
			this.m_ConsoleText.Text = "";
			this.m_ConsoleText.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.m_ConsoleText_KeyDown);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(520, 377);
			base.Controls.Add(this.m_ConsoleText);
			base.Controls.Add(this.m_toolStrip);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "frmOutput";
			base.TabText = "Output";
			this.Text = "Output";
			this.m_ConsoleTextContextMenuStrip.ResumeLayout(false);
			this.m_toolStrip.ResumeLayout(false);
			this.m_toolStrip.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.ContextMenuStrip m_ConsoleTextContextMenuStrip;


		private global::System.Windows.Forms.ToolStripMenuItem ConsoleTextMenuCopy;


		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;


		private global::System.Windows.Forms.ToolStripMenuItem ConsoleTextMenuClear;


		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;


		private global::System.Windows.Forms.ToolStripMenuItem ConsoleTextMenuShowLogFile;


		private global::System.Windows.Forms.ToolStripMenuItem ConsoleTextMenuShowVerboseLog;


		private global::System.Windows.Forms.ToolStripMenuItem openLogFolderToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem ConsoleTextMenuZoom;


		private global::System.Windows.Forms.ToolStripComboBox ConsoleTextMenuZoomComboBox;


		private global::System.Windows.Forms.ToolStrip m_toolStrip;


		private global::System.Windows.Forms.RichTextBox m_ConsoleText;


		private global::System.Windows.Forms.ToolStripButton btnClear;


		private global::System.Windows.Forms.ToolStripButton btnAutoScroll;


		private global::System.Windows.Forms.ToolStripLabel m_lblExclude;


		private global::System.Windows.Forms.ToolStripTextBox m_txtExclude;


		private global::System.Windows.Forms.ToolStripLabel m_lblInclude;


		private global::System.Windows.Forms.ToolStripTextBox m_txtInclude;


		private global::System.Windows.Forms.ToolStripButton m_btnUserMsgMask;


		private global::System.Windows.Forms.ToolStripSeparator toolStripButton1;


		private global::System.Windows.Forms.ToolStripMenuItem showUserLogToolStripMenuItem;
	}
}
