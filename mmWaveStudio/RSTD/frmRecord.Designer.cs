namespace RSTD
{

	public partial class frmRecord : global::WeifenLuo.WinFormsUI.Docking.DockContent
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.frmRecord));
			this.m_MainToolStrip = new global::System.Windows.Forms.ToolStrip();
			this.m_RecordToolStripButton = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_SaveToolStripButton = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.m_ClearToolStripButton = new global::System.Windows.Forms.ToolStripButton();
			this.m_btnShowDate = new global::System.Windows.Forms.ToolStripButton();
			this.m_lstCommands = new global::System.Windows.Forms.ListView();
			this.colTime = new global::System.Windows.Forms.ColumnHeader();
			this.colModule = new global::System.Windows.Forms.ColumnHeader();
			this.colOperation = new global::System.Windows.Forms.ColumnHeader();
			this.colCommand = new global::System.Windows.Forms.ColumnHeader();
			this.m_ListContextMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.DeleteToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.undoDeleteToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_DummyImageList = new global::System.Windows.Forms.ImageList(this.components);
			this.m_MainToolStrip.SuspendLayout();
			this.m_ListContextMenuStrip.SuspendLayout();
			base.SuspendLayout();
			this.m_MainToolStrip.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.m_MainToolStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_RecordToolStripButton,
				this.toolStripSeparator1,
				this.m_SaveToolStripButton,
				this.toolStripSeparator2,
				this.m_ClearToolStripButton,
				this.m_btnShowDate
			});
			this.m_MainToolStrip.Location = new global::System.Drawing.Point(0, 0);
			this.m_MainToolStrip.Name = "m_MainToolStrip";
			this.m_MainToolStrip.Size = new global::System.Drawing.Size(335, 25);
			this.m_MainToolStrip.TabIndex = 0;
			this.m_MainToolStrip.Text = "toolStrip1";
			this.m_RecordToolStripButton.CheckOnClick = true;
			this.m_RecordToolStripButton.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_RecordToolStripButton.Image = global::RSTD.Properties.Resources.record_button;
			this.m_RecordToolStripButton.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_RecordToolStripButton.Name = "m_RecordToolStripButton";
			this.m_RecordToolStripButton.Size = new global::System.Drawing.Size(23, 22);
			this.m_RecordToolStripButton.Text = "Enable";
			this.m_RecordToolStripButton.Click += new global::System.EventHandler(this.m_RecordToolStripButton_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(6, 25);
			this.m_SaveToolStripButton.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_SaveToolStripButton.Image = global::RSTD.Properties.Resources.save_to_file;
			this.m_SaveToolStripButton.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_SaveToolStripButton.Name = "m_SaveToolStripButton";
			this.m_SaveToolStripButton.Size = new global::System.Drawing.Size(23, 22);
			this.m_SaveToolStripButton.Text = "Save To File";
			this.m_SaveToolStripButton.Click += new global::System.EventHandler(this.m_SaveToolStripButton_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(6, 25);
			this.m_ClearToolStripButton.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_ClearToolStripButton.Image = global::RSTD.Properties.Resources.clear_list;
			this.m_ClearToolStripButton.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_ClearToolStripButton.Name = "m_ClearToolStripButton";
			this.m_ClearToolStripButton.Size = new global::System.Drawing.Size(23, 22);
			this.m_ClearToolStripButton.Text = "Clear List";
			this.m_ClearToolStripButton.Click += new global::System.EventHandler(this.m_ClearToolStripButton_Click);
			this.m_btnShowDate.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.m_btnShowDate.Image = global::RSTD.Properties.Resources.date;
			this.m_btnShowDate.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnShowDate.Name = "m_btnShowDate";
			this.m_btnShowDate.Size = new global::System.Drawing.Size(23, 22);
			this.m_btnShowDate.Text = "Show Date";
			this.m_btnShowDate.Click += new global::System.EventHandler(this.m_btnTimeFormat_Click);
			this.m_lstCommands.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.colTime,
				this.colModule,
				this.colOperation,
				this.colCommand
			});
			this.m_lstCommands.ContextMenuStrip = this.m_ListContextMenuStrip;
			this.m_lstCommands.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.m_lstCommands.FullRowSelect = true;
			this.m_lstCommands.GridLines = true;
			this.m_lstCommands.HideSelection = false;
			this.m_lstCommands.Location = new global::System.Drawing.Point(0, 25);
			this.m_lstCommands.Name = "m_lstCommands";
			this.m_lstCommands.Size = new global::System.Drawing.Size(335, 400);
			this.m_lstCommands.StateImageList = this.m_DummyImageList;
			this.m_lstCommands.TabIndex = 1;
			this.m_lstCommands.UseCompatibleStateImageBehavior = false;
			this.m_lstCommands.View = global::System.Windows.Forms.View.Details;
			this.m_lstCommands.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.m_CommandsListView_KeyDown);
			this.colTime.Text = "Time";
			this.colTime.Width = 80;
			this.colModule.Text = "Module";
			this.colModule.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.colOperation.Text = "Operation";
			this.colOperation.Width = 130;
			this.colCommand.Text = "Command";
			this.colCommand.Width = 228;
			this.m_ListContextMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.DeleteToolStripMenuItem,
				this.undoDeleteToolStripMenuItem
			});
			this.m_ListContextMenuStrip.Name = "m_ListContextMenuStrip";
			this.m_ListContextMenuStrip.Size = new global::System.Drawing.Size(140, 48);
			this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
			this.DeleteToolStripMenuItem.Size = new global::System.Drawing.Size(139, 22);
			this.DeleteToolStripMenuItem.Text = "Delete";
			this.DeleteToolStripMenuItem.Click += new global::System.EventHandler(this.DeleteToolStripMenuItem_Click);
			this.undoDeleteToolStripMenuItem.Name = "undoDeleteToolStripMenuItem";
			this.undoDeleteToolStripMenuItem.Size = new global::System.Drawing.Size(139, 22);
			this.undoDeleteToolStripMenuItem.Text = "Undo Delete";
			this.undoDeleteToolStripMenuItem.Click += new global::System.EventHandler(this.undoDeleteToolStripMenuItem_Click);
			this.m_DummyImageList.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth8Bit;
			this.m_DummyImageList.ImageSize = new global::System.Drawing.Size(1, 16);
			this.m_DummyImageList.TransparentColor = global::System.Drawing.Color.Transparent;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(335, 425);
			base.Controls.Add(this.m_lstCommands);
			base.Controls.Add(this.m_MainToolStrip);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmRecord";
			this.Text = "Recorder";
			this.m_MainToolStrip.ResumeLayout(false);
			this.m_MainToolStrip.PerformLayout();
			this.m_ListContextMenuStrip.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.ToolStrip m_MainToolStrip;


		private global::System.Windows.Forms.ToolStripButton m_RecordToolStripButton;


		private global::System.Windows.Forms.ListView m_lstCommands;


		private global::System.Windows.Forms.ColumnHeader colOperation;


		private global::System.Windows.Forms.ColumnHeader colCommand;


		private global::System.Windows.Forms.ToolStripButton m_ClearToolStripButton;


		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;


		private global::System.Windows.Forms.ToolStripButton m_SaveToolStripButton;


		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;


		private global::System.Windows.Forms.ImageList m_DummyImageList;


		private global::System.Windows.Forms.ContextMenuStrip m_ListContextMenuStrip;


		private global::System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem undoDeleteToolStripMenuItem;


		private global::System.Windows.Forms.ColumnHeader colTime;


		private global::System.Windows.Forms.ToolStripButton m_btnShowDate;


		private global::System.Windows.Forms.ColumnHeader colModule;
	}
}
