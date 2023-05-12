namespace RSTD
{

	public partial class frmSubSet : global::WeifenLuo.WinFormsUI.Docking.DockContent
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.frmSubSet));
			this.tsBottom = new global::System.Windows.Forms.ToolStrip();
			this.m_btnSave = new global::System.Windows.Forms.ToolStripSplitButton();
			this.m_tsmi_all = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_tsmi_selection = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_btnLoad = new global::System.Windows.Forms.ToolStripButton();
			this.m_btnLoadLast = new global::System.Windows.Forms.ToolStripButton();
			this.m_btnClear = new global::System.Windows.Forms.ToolStripButton();
			this.m_TransmitSplitBtnWS = new global::System.Windows.Forms.ToolStripSplitButton();
			this.selectionToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_btnTransmitAll = new global::System.Windows.Forms.ToolStripMenuItem();
			this.m_ReceiveSplitBtnWS = new global::System.Windows.Forms.ToolStripSplitButton();
			this.selectionToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.allToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.grpRegisters = new global::System.Windows.Forms.GroupBox();
			this.m_lblSubVersion = new global::System.Windows.Forms.Label();
			this.m_txtSubVersion = new global::System.Windows.Forms.TextBox();
			this.tsBottom.SuspendLayout();
			base.SuspendLayout();
			this.tsBottom.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.tsBottom.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_btnSave,
				this.m_btnLoad,
				this.m_btnLoadLast,
				this.m_btnClear,
				this.m_TransmitSplitBtnWS,
				this.m_ReceiveSplitBtnWS
			});
			this.tsBottom.Location = new global::System.Drawing.Point(0, 239);
			this.tsBottom.Name = "tsBottom";
			this.tsBottom.Size = new global::System.Drawing.Size(717, 27);
			this.tsBottom.TabIndex = 8;
			this.tsBottom.Text = "toolStrip1";
			this.m_btnSave.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.m_tsmi_all,
				this.m_tsmi_selection
			});
			this.m_btnSave.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_btnSave.Image");
			this.m_btnSave.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_btnSave.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Size = new global::System.Drawing.Size(67, 24);
			this.m_btnSave.Text = "Save";
			this.m_btnSave.ButtonClick += new global::System.EventHandler(this.btnSave_Click);
			this.m_btnSave.DropDownOpened += new global::System.EventHandler(this.m_btnSave_DropDownOpened);
			this.m_tsmi_all.Name = "m_tsmi_all";
			this.m_tsmi_all.Size = new global::System.Drawing.Size(117, 22);
			this.m_tsmi_all.Text = "All";
			this.m_tsmi_all.Click += new global::System.EventHandler(this.itsmi_all_Click);
			this.m_tsmi_selection.Name = "m_tsmi_selection";
			this.m_tsmi_selection.Size = new global::System.Drawing.Size(117, 22);
			this.m_tsmi_selection.Text = "Selection";
			this.m_tsmi_selection.Click += new global::System.EventHandler(this.itsmi_selection_Click);
			this.m_btnLoad.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_btnLoad.Image");
			this.m_btnLoad.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_btnLoad.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnLoad.Name = "m_btnLoad";
			this.m_btnLoad.Size = new global::System.Drawing.Size(52, 24);
			this.m_btnLoad.Text = "Load";
			this.m_btnLoad.Click += new global::System.EventHandler(this.btnLoad_Click);
			this.m_btnLoadLast.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_btnLoadLast.Image");
			this.m_btnLoadLast.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_btnLoadLast.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnLoadLast.Name = "m_btnLoadLast";
			this.m_btnLoadLast.Size = new global::System.Drawing.Size(72, 24);
			this.m_btnLoadLast.Text = "LoadLast";
			this.m_btnLoadLast.Click += new global::System.EventHandler(this.btnLoadLast_Click);
			this.m_btnClear.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_btnClear.Image");
			this.m_btnClear.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnClear.Name = "m_btnClear";
			this.m_btnClear.Size = new global::System.Drawing.Size(52, 24);
			this.m_btnClear.Text = "Clear";
			this.m_btnClear.Click += new global::System.EventHandler(this.btnClear_Click);
			this.m_TransmitSplitBtnWS.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.selectionToolStripMenuItem,
				this.m_btnTransmitAll
			});
			this.m_TransmitSplitBtnWS.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_TransmitSplitBtnWS.Image");
			this.m_TransmitSplitBtnWS.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_TransmitSplitBtnWS.Name = "m_TransmitSplitBtnWS";
			this.m_TransmitSplitBtnWS.Size = new global::System.Drawing.Size(80, 24);
			this.m_TransmitSplitBtnWS.Text = "Transmit";
			this.m_TransmitSplitBtnWS.Click += new global::System.EventHandler(this.m_TransmitSplitBtnWS_ButtonClick);
			this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
			this.selectionToolStripMenuItem.Size = new global::System.Drawing.Size(117, 22);
			this.selectionToolStripMenuItem.Text = "Selection";
			this.selectionToolStripMenuItem.Click += new global::System.EventHandler(this.selectionToolStripMenuItem_Click);
			this.m_btnTransmitAll.Name = "m_btnTransmitAll";
			this.m_btnTransmitAll.Size = new global::System.Drawing.Size(117, 22);
			this.m_btnTransmitAll.Text = "All";
			this.m_btnTransmitAll.Click += new global::System.EventHandler(this.m_TransmitSplitBtnWS_ButtonClick);
			this.m_ReceiveSplitBtnWS.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.selectionToolStripMenuItem1,
				this.allToolStripMenuItem1
			});
			this.m_ReceiveSplitBtnWS.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_ReceiveSplitBtnWS.Image");
			this.m_ReceiveSplitBtnWS.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_ReceiveSplitBtnWS.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_ReceiveSplitBtnWS.Name = "m_ReceiveSplitBtnWS";
			this.m_ReceiveSplitBtnWS.Size = new global::System.Drawing.Size(77, 24);
			this.m_ReceiveSplitBtnWS.Text = "Receive";
			this.m_ReceiveSplitBtnWS.Click += new global::System.EventHandler(this.m_ReceiveSplitBtnWS_ButtonClick);
			this.selectionToolStripMenuItem1.Name = "selectionToolStripMenuItem1";
			this.selectionToolStripMenuItem1.Size = new global::System.Drawing.Size(117, 22);
			this.selectionToolStripMenuItem1.Text = "Selection";
			this.selectionToolStripMenuItem1.Click += new global::System.EventHandler(this.selectionToolStripMenuItem1_Click);
			this.allToolStripMenuItem1.Name = "allToolStripMenuItem1";
			this.allToolStripMenuItem1.Size = new global::System.Drawing.Size(117, 22);
			this.allToolStripMenuItem1.Text = "All";
			this.allToolStripMenuItem1.Click += new global::System.EventHandler(this.m_ReceiveSplitBtnWS_ButtonClick);
			this.grpRegisters.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.grpRegisters.Location = new global::System.Drawing.Point(0, 25);
			this.grpRegisters.Margin = new global::System.Windows.Forms.Padding(2);
			this.grpRegisters.Name = "grpRegisters";
			this.grpRegisters.Padding = new global::System.Windows.Forms.Padding(2);
			this.grpRegisters.Size = new global::System.Drawing.Size(717, 214);
			this.grpRegisters.TabIndex = 9;
			this.grpRegisters.TabStop = false;
			this.grpRegisters.Text = "Registers";
			this.m_lblSubVersion.AutoSize = true;
			this.m_lblSubVersion.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.m_lblSubVersion.Location = new global::System.Drawing.Point(8, 5);
			this.m_lblSubVersion.Name = "m_lblSubVersion";
			this.m_lblSubVersion.Size = new global::System.Drawing.Size(103, 15);
			this.m_lblSubVersion.TabIndex = 10;
			this.m_lblSubVersion.Text = "Subset Version";
			this.m_txtSubVersion.BackColor = global::System.Drawing.SystemColors.Control;
			this.m_txtSubVersion.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.m_txtSubVersion.Location = new global::System.Drawing.Point(143, 7);
			this.m_txtSubVersion.Name = "m_txtSubVersion";
			this.m_txtSubVersion.ReadOnly = true;
			this.m_txtSubVersion.Size = new global::System.Drawing.Size(92, 13);
			this.m_txtSubVersion.TabIndex = 11;
			this.m_txtSubVersion.Text = "<>";
			this.m_txtSubVersion.DoubleClick += new global::System.EventHandler(this.m_txtSrcVersion_DoubleClick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(717, 266);
			base.Controls.Add(this.m_txtSubVersion);
			base.Controls.Add(this.m_lblSubVersion);
			base.Controls.Add(this.grpRegisters);
			base.Controls.Add(this.tsBottom);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			base.Name = "frmSubSet";
			this.Text = "SubSet";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.frmSubSet_FormClosing);
			this.tsBottom.ResumeLayout(false);
			this.tsBottom.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.ToolStrip tsBottom;


		private global::System.Windows.Forms.ToolStripSplitButton m_btnSave;


		private global::System.Windows.Forms.ToolStripMenuItem m_tsmi_all;


		private global::System.Windows.Forms.ToolStripMenuItem m_tsmi_selection;


		private global::System.Windows.Forms.ToolStripButton m_btnLoad;


		private global::System.Windows.Forms.ToolStripButton m_btnLoadLast;


		private global::System.Windows.Forms.ToolStripButton m_btnClear;


		private global::System.Windows.Forms.ToolStripSplitButton m_TransmitSplitBtnWS;


		private global::System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem m_btnTransmitAll;


		private global::System.Windows.Forms.ToolStripSplitButton m_ReceiveSplitBtnWS;


		private global::System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem1;


		private global::System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem1;


		private global::System.Windows.Forms.GroupBox grpRegisters;


		private global::System.Windows.Forms.Label m_lblSubVersion;


		private global::System.Windows.Forms.TextBox m_txtSubVersion;
	}
}
