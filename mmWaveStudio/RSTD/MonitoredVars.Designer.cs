namespace RSTD
{

	public partial class MonitoredVars : global::WeifenLuo.WinFormsUI.Docking.DockContent
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.MonitoredVars));
			this.m_ListView = new global::System.Windows.Forms.ListView();
			this.Variables = new global::System.Windows.Forms.ColumnHeader();
			this.RelevantClocks = new global::System.Windows.Forms.ColumnHeader();
			this.Offset = new global::System.Windows.Forms.ColumnHeader();
			this.Stride = new global::System.Windows.Forms.ColumnHeader();
			this.Length = new global::System.Windows.Forms.ColumnHeader();
			this.m_StatusStrip = new global::System.Windows.Forms.StatusStrip();
			this.m_AutoFlushTimer = new global::System.Windows.Forms.Timer(this.components);
			this.m_BottomToolStrip = new global::RSTD.ToolStripEx();
			this.m_StartStopBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_ShowLastFileBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_ToolStripSeperator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_DeleteAllFilesBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_ToolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_SaveBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_LoadBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_LoadLastBtn = new global::System.Windows.Forms.ToolStripButton();
			this.m_ToolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_btnClear = new global::System.Windows.Forms.ToolStripButton();
			this.m_BottomToolStrip.SuspendLayout();
			base.SuspendLayout();
			this.m_ListView.AllowDrop = true;
			this.m_ListView.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_ListView.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.Variables,
				this.RelevantClocks,
				this.Offset,
				this.Stride,
				this.Length
			});
			this.m_ListView.FullRowSelect = true;
			this.m_ListView.GridLines = true;
			this.m_ListView.Location = new global::System.Drawing.Point(0, 0);
			this.m_ListView.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_ListView.Name = "m_ListView";
			this.m_ListView.Size = new global::System.Drawing.Size(645, 251);
			this.m_ListView.TabIndex = 1;
			this.m_ListView.UseCompatibleStateImageBehavior = false;
			this.m_ListView.View = global::System.Windows.Forms.View.Details;
			this.m_ListView.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.m_ListView_DragDrop);
			this.m_ListView.DragOver += new global::System.Windows.Forms.DragEventHandler(this.m_ListView_DragOver);
			this.m_ListView.DoubleClick += new global::System.EventHandler(this.m_ListView_DoubleClick);
			this.m_ListView.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.m_ListView_KeyDown);
			this.m_ListView.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.m_ListView_MouseClick);
			this.Variables.Text = "Variables";
			this.Variables.Width = 412;
			this.RelevantClocks.Text = "Relevant Clocks";
			this.RelevantClocks.Width = 295;
			this.Offset.Text = "Offset";
			this.Offset.Width = 47;
			this.Stride.Text = "Stride";
			this.Stride.Width = 49;
			this.Length.Text = "Length";
			this.Length.Width = 52;
			this.m_StatusStrip.Location = new global::System.Drawing.Point(0, 280);
			this.m_StatusStrip.Name = "m_StatusStrip";
			this.m_StatusStrip.Padding = new global::System.Windows.Forms.Padding(1, 0, 10, 0);
			this.m_StatusStrip.Size = new global::System.Drawing.Size(644, 22);
			this.m_StatusStrip.TabIndex = 5;
			this.m_StatusStrip.Text = "statusStrip1";
			this.m_AutoFlushTimer.Interval = 500;
			this.m_AutoFlushTimer.Tick += new global::System.EventHandler(this.m_AutoFlushTimer_Tick);
			this.m_BottomToolStrip.ClickThrough = true;
			this.m_BottomToolStrip.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.m_BottomToolStrip.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.m_BottomToolStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_StartStopBtn,
				this.m_ShowLastFileBtn,
				this.m_ToolStripSeperator1,
				this.m_DeleteAllFilesBtn,
				this.m_ToolStripSeparator4,
				this.m_SaveBtn,
				this.m_LoadBtn,
				this.m_LoadLastBtn,
				this.m_ToolStripSeparator3,
				this.m_btnClear
			});
			this.m_BottomToolStrip.Location = new global::System.Drawing.Point(0, 252);
			this.m_BottomToolStrip.Name = "m_BottomToolStrip";
			this.m_BottomToolStrip.Size = new global::System.Drawing.Size(644, 28);
			this.m_BottomToolStrip.TabIndex = 1;
			this.m_BottomToolStrip.Text = "toolStrip1";
			this.m_StartStopBtn.Image = global::RSTD.TreeIcons.green_light;
			this.m_StartStopBtn.ImageTransparentColor = global::System.Drawing.Color.White;
			this.m_StartStopBtn.Name = "m_StartStopBtn";
			this.m_StartStopBtn.Size = new global::System.Drawing.Size(51, 25);
			this.m_StartStopBtn.Text = "Start";
			this.m_StartStopBtn.Click += new global::System.EventHandler(this.m_StartStopBtn_Click);
			this.m_ShowLastFileBtn.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_ShowLastFileBtn.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_ShowLastFileBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_ShowLastFileBtn.Image");
			this.m_ShowLastFileBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_ShowLastFileBtn.Name = "m_ShowLastFileBtn";
			this.m_ShowLastFileBtn.Size = new global::System.Drawing.Size(85, 25);
			this.m_ShowLastFileBtn.Text = "Show Last File";
			this.m_ShowLastFileBtn.Click += new global::System.EventHandler(this.m_ShowLastFileBtn_Click);
			this.m_ToolStripSeperator1.Name = "m_ToolStripSeperator1";
			this.m_ToolStripSeperator1.Size = new global::System.Drawing.Size(6, 28);
			this.m_DeleteAllFilesBtn.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_DeleteAllFilesBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_DeleteAllFilesBtn.Image");
			this.m_DeleteAllFilesBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_DeleteAllFilesBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_DeleteAllFilesBtn.Name = "m_DeleteAllFilesBtn";
			this.m_DeleteAllFilesBtn.Size = new global::System.Drawing.Size(103, 25);
			this.m_DeleteAllFilesBtn.Text = "Delete All Files";
			this.m_DeleteAllFilesBtn.Click += new global::System.EventHandler(this.m_DeleteAllFilesBtn_Click);
			this.m_ToolStripSeparator4.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
			this.m_ToolStripSeparator4.Name = "m_ToolStripSeparator4";
			this.m_ToolStripSeparator4.Size = new global::System.Drawing.Size(6, 28);
			this.m_SaveBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_SaveBtn.Image");
			this.m_SaveBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_SaveBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_SaveBtn.Name = "m_SaveBtn";
			this.m_SaveBtn.Size = new global::System.Drawing.Size(57, 25);
			this.m_SaveBtn.Text = "Save";
			this.m_SaveBtn.ToolTipText = "Save monitor settings to file";
			this.m_SaveBtn.Click += new global::System.EventHandler(this.m_SaveBtn_Click);
			this.m_LoadBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_LoadBtn.Image");
			this.m_LoadBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_LoadBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_LoadBtn.Name = "m_LoadBtn";
			this.m_LoadBtn.Size = new global::System.Drawing.Size(53, 25);
			this.m_LoadBtn.Text = "Load";
			this.m_LoadBtn.ToolTipText = "Load monitor settings from file";
			this.m_LoadBtn.Click += new global::System.EventHandler(this.m_LoadBtn_Click);
			this.m_LoadLastBtn.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.m_LoadLastBtn.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_LoadLastBtn.Image");
			this.m_LoadLastBtn.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_LoadLastBtn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_LoadLastBtn.Name = "m_LoadLastBtn";
			this.m_LoadLastBtn.Size = new global::System.Drawing.Size(76, 25);
			this.m_LoadLastBtn.Text = "LoadLast";
			this.m_LoadLastBtn.ToolTipText = "Load last monitor settings from file";
			this.m_LoadLastBtn.Click += new global::System.EventHandler(this.m_LoadLastBtn_Click);
			this.m_ToolStripSeparator3.Name = "m_ToolStripSeparator3";
			this.m_ToolStripSeparator3.Size = new global::System.Drawing.Size(6, 28);
			this.m_btnClear.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_btnClear.Image");
			this.m_btnClear.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnClear.Name = "m_btnClear";
			this.m_btnClear.Size = new global::System.Drawing.Size(54, 25);
			this.m_btnClear.Text = "Clear";
			this.m_btnClear.Click += new global::System.EventHandler(this.m_btnClear_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(644, 302);
			base.Controls.Add(this.m_BottomToolStrip);
			base.Controls.Add(this.m_StatusStrip);
			base.Controls.Add(this.m_ListView);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "MonitoredVars";
			base.TabText = "Monitored Variables";
			this.Text = "Monitored Variables";
			this.m_BottomToolStrip.ResumeLayout(false);
			this.m_BottomToolStrip.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.ListView m_ListView;


		private global::System.Windows.Forms.StatusStrip m_StatusStrip;


		private global::RSTD.ToolStripEx m_BottomToolStrip;


		private global::System.Windows.Forms.ToolStripButton m_StartStopBtn;


		private global::System.Windows.Forms.ToolStripButton m_ShowLastFileBtn;


		private global::System.Windows.Forms.ToolStripSeparator m_ToolStripSeperator1;


		private global::System.Windows.Forms.ToolStripButton m_DeleteAllFilesBtn;


		private global::System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator4;


		private global::System.Windows.Forms.ToolStripButton m_SaveBtn;


		private global::System.Windows.Forms.ToolStripButton m_LoadBtn;


		private global::System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator3;


		private global::System.Windows.Forms.ColumnHeader Variables;


		private global::System.Windows.Forms.ColumnHeader RelevantClocks;


		private global::System.Windows.Forms.ColumnHeader Stride;


		private global::System.Windows.Forms.ColumnHeader Length;


		private global::System.Windows.Forms.ColumnHeader Offset;


		private global::System.Windows.Forms.Timer m_AutoFlushTimer;


		private global::System.Windows.Forms.ToolStripButton m_btnClear;


		private global::System.Windows.Forms.ToolStripButton m_LoadLastBtn;
	}
}
