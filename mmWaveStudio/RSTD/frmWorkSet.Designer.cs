namespace RSTD
{

	public partial class frmWorkSet : global::WeifenLuo.WinFormsUI.Docking.DockContent
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RSTD.frmWorkSet));
			this.m_SplitContainer = new global::System.Windows.Forms.SplitContainer();
			this.grpVariables = new global::System.Windows.Forms.GroupBox();
			this.grpFunctions = new global::System.Windows.Forms.GroupBox();
			this.m_SplitContainerFunctions = new global::System.Windows.Forms.SplitContainer();
			this.m_StatusStrip = new global::System.Windows.Forms.StatusStrip();
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
			((global::System.ComponentModel.ISupportInitialize)this.m_SplitContainer).BeginInit();
			this.m_SplitContainer.Panel1.SuspendLayout();
			this.m_SplitContainer.Panel2.SuspendLayout();
			this.m_SplitContainer.SuspendLayout();
			this.grpFunctions.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.m_SplitContainerFunctions).BeginInit();
			this.m_SplitContainerFunctions.SuspendLayout();
			this.tsBottom.SuspendLayout();
			base.SuspendLayout();
			this.m_SplitContainer.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.m_SplitContainer.Location = new global::System.Drawing.Point(0, 0);
			this.m_SplitContainer.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_SplitContainer.Name = "m_SplitContainer";
			this.m_SplitContainer.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.m_SplitContainer.Panel1.Controls.Add(this.grpVariables);
			this.m_SplitContainer.Panel2.Controls.Add(this.grpFunctions);
			this.m_SplitContainer.Size = new global::System.Drawing.Size(644, 241);
			this.m_SplitContainer.SplitterDistance = 157;
			this.m_SplitContainer.SplitterWidth = 3;
			this.m_SplitContainer.TabIndex = 0;
			this.grpVariables.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grpVariables.Location = new global::System.Drawing.Point(0, 0);
			this.grpVariables.Margin = new global::System.Windows.Forms.Padding(2);
			this.grpVariables.Name = "grpVariables";
			this.grpVariables.Padding = new global::System.Windows.Forms.Padding(2);
			this.grpVariables.Size = new global::System.Drawing.Size(644, 157);
			this.grpVariables.TabIndex = 1;
			this.grpVariables.TabStop = false;
			this.grpVariables.Text = "Variables";
			this.grpFunctions.Controls.Add(this.m_SplitContainerFunctions);
			this.grpFunctions.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grpFunctions.Location = new global::System.Drawing.Point(0, 0);
			this.grpFunctions.Margin = new global::System.Windows.Forms.Padding(2);
			this.grpFunctions.Name = "grpFunctions";
			this.grpFunctions.Padding = new global::System.Windows.Forms.Padding(2);
			this.grpFunctions.Size = new global::System.Drawing.Size(644, 81);
			this.grpFunctions.TabIndex = 0;
			this.grpFunctions.TabStop = false;
			this.grpFunctions.Text = "Functions";
			this.m_SplitContainerFunctions.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.m_SplitContainerFunctions.Location = new global::System.Drawing.Point(2, 15);
			this.m_SplitContainerFunctions.Margin = new global::System.Windows.Forms.Padding(2);
			this.m_SplitContainerFunctions.Name = "m_SplitContainerFunctions";
			this.m_SplitContainerFunctions.Size = new global::System.Drawing.Size(640, 64);
			this.m_SplitContainerFunctions.SplitterDistance = 213;
			this.m_SplitContainerFunctions.SplitterWidth = 3;
			this.m_SplitContainerFunctions.TabIndex = 1;
			this.m_StatusStrip.Location = new global::System.Drawing.Point(0, 270);
			this.m_StatusStrip.Name = "m_StatusStrip";
			this.m_StatusStrip.Padding = new global::System.Windows.Forms.Padding(1, 0, 10, 0);
			this.m_StatusStrip.Size = new global::System.Drawing.Size(644, 22);
			this.m_StatusStrip.TabIndex = 6;
			this.m_StatusStrip.Text = "statusStrip1";
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
			this.tsBottom.Location = new global::System.Drawing.Point(0, 242);
			this.tsBottom.Name = "tsBottom";
			this.tsBottom.Size = new global::System.Drawing.Size(644, 28);
			this.tsBottom.TabIndex = 7;
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
			this.m_btnSave.Size = new global::System.Drawing.Size(69, 25);
			this.m_btnSave.Text = "Save";
			this.m_btnSave.ButtonClick += new global::System.EventHandler(this.btnSave_Click);
			this.m_tsmi_all.Name = "m_tsmi_all";
			this.m_tsmi_all.Size = new global::System.Drawing.Size(152, 22);
			this.m_tsmi_all.Text = "All";
			this.m_tsmi_all.Click += new global::System.EventHandler(this.itsmi_all_Click);
			this.m_tsmi_selection.Name = "m_tsmi_selection";
			this.m_tsmi_selection.Size = new global::System.Drawing.Size(152, 22);
			this.m_tsmi_selection.Text = "Selection";
			this.m_tsmi_selection.Click += new global::System.EventHandler(this.itsmi_selection_Click);
			this.m_btnLoad.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_btnLoad.Image");
			this.m_btnLoad.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_btnLoad.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnLoad.Name = "m_btnLoad";
			this.m_btnLoad.Size = new global::System.Drawing.Size(53, 25);
			this.m_btnLoad.Text = "Load";
			this.m_btnLoad.Click += new global::System.EventHandler(this.btnLoad_Click);
			this.m_btnLoadLast.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_btnLoadLast.Image");
			this.m_btnLoadLast.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.m_btnLoadLast.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnLoadLast.Name = "m_btnLoadLast";
			this.m_btnLoadLast.Size = new global::System.Drawing.Size(76, 25);
			this.m_btnLoadLast.Text = "LoadLast";
			this.m_btnLoadLast.Click += new global::System.EventHandler(this.btnLoadLast_Click);
			this.m_btnClear.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("m_btnClear.Image");
			this.m_btnClear.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.m_btnClear.Name = "m_btnClear";
			this.m_btnClear.Size = new global::System.Drawing.Size(54, 25);
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
			this.m_TransmitSplitBtnWS.Size = new global::System.Drawing.Size(86, 25);
			this.m_TransmitSplitBtnWS.Text = "Transmit";
			this.m_TransmitSplitBtnWS.ButtonClick += new global::System.EventHandler(this.m_TransmitSplitBtnWS_ButtonClick);
			this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
			this.selectionToolStripMenuItem.Size = new global::System.Drawing.Size(152, 22);
			this.selectionToolStripMenuItem.Text = "Selection";
			this.selectionToolStripMenuItem.Click += new global::System.EventHandler(this.selectionToolStripMenuItem_Click);
			this.m_btnTransmitAll.Name = "m_btnTransmitAll";
			this.m_btnTransmitAll.Size = new global::System.Drawing.Size(152, 22);
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
			this.m_ReceiveSplitBtnWS.Size = new global::System.Drawing.Size(79, 25);
			this.m_ReceiveSplitBtnWS.Text = "Receive";
			this.m_ReceiveSplitBtnWS.ButtonClick += new global::System.EventHandler(this.m_ReceiveSplitBtnWS_ButtonClick);
			this.selectionToolStripMenuItem1.Name = "selectionToolStripMenuItem1";
			this.selectionToolStripMenuItem1.Size = new global::System.Drawing.Size(152, 22);
			this.selectionToolStripMenuItem1.Text = "Selection";
			this.selectionToolStripMenuItem1.Click += new global::System.EventHandler(this.selectionToolStripMenuItem1_Click);
			this.allToolStripMenuItem1.Name = "allToolStripMenuItem1";
			this.allToolStripMenuItem1.Size = new global::System.Drawing.Size(152, 22);
			this.allToolStripMenuItem1.Text = "All";
			this.allToolStripMenuItem1.Click += new global::System.EventHandler(this.m_ReceiveSplitBtnWS_ButtonClick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(644, 292);
			base.Controls.Add(this.tsBottom);
			base.Controls.Add(this.m_StatusStrip);
			base.Controls.Add(this.m_SplitContainer);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "frmWorkSet";
			base.TabText = "WorkSet";
			this.Text = "WorkSet";
			this.m_SplitContainer.Panel1.ResumeLayout(false);
			this.m_SplitContainer.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.m_SplitContainer).EndInit();
			this.m_SplitContainer.ResumeLayout(false);
			this.grpFunctions.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.m_SplitContainerFunctions).EndInit();
			this.m_SplitContainerFunctions.ResumeLayout(false);
			this.tsBottom.ResumeLayout(false);
			this.tsBottom.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;


		private global::System.Windows.Forms.SplitContainer m_SplitContainer;


		private global::System.Windows.Forms.GroupBox grpVariables;


		private global::System.Windows.Forms.GroupBox grpFunctions;


		private global::System.Windows.Forms.SplitContainer m_SplitContainerFunctions;


		private global::System.Windows.Forms.StatusStrip m_StatusStrip;


		private global::System.Windows.Forms.ToolStrip tsBottom;


		private global::System.Windows.Forms.ToolStripButton m_btnLoad;


		private global::System.Windows.Forms.ToolStripButton m_btnClear;


		private global::System.Windows.Forms.ToolStripButton m_btnLoadLast;


		private global::System.Windows.Forms.ToolStripSplitButton m_btnSave;


		private global::System.Windows.Forms.ToolStripMenuItem m_tsmi_all;


		private global::System.Windows.Forms.ToolStripMenuItem m_tsmi_selection;


		private global::System.Windows.Forms.ToolStripSplitButton m_TransmitSplitBtnWS;


		private global::System.Windows.Forms.ToolStripSplitButton m_ReceiveSplitBtnWS;


		private global::System.Windows.Forms.ToolStripMenuItem m_btnTransmitAll;


		private global::System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;


		private global::System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem1;


		private global::System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem1;
	}
}
