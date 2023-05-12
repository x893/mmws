namespace AR1xController
{
	public partial class ProfManager : global::System.Windows.Forms.Form
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
			this.dataGridView2 = new global::System.Windows.Forms.DataGridView();
			this.openFileDialog2 = new global::System.Windows.Forms.OpenFileDialog();
			this.m_btnBrowse = new global::System.Windows.Forms.Button();
			this.m_btnLoad = new global::System.Windows.Forms.Button();
			this.m_btnSave = new global::System.Windows.Forms.Button();
			this.m_btnActivate = new global::System.Windows.Forms.Button();
			this.notifyIcon1 = new global::System.Windows.Forms.NotifyIcon(this.components);
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.toolTip2 = new global::System.Windows.Forms.ToolTip(this.components);
			this.m_cboADCDataFileProfileConfig = new global::System.Windows.Forms.ComboBox();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView2).BeginInit();
			base.SuspendLayout();
			this.dataGridView2.BackgroundColor = global::System.Drawing.SystemColors.ButtonHighlight;
			this.dataGridView2.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Location = new global::System.Drawing.Point(4, 226);
			this.dataGridView2.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.Size = new global::System.Drawing.Size(1430, 519);
			this.dataGridView2.TabIndex = 5;
			this.dataGridView2.CellBeginEdit += new global::System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView2_CellBeginEdit);
			this.openFileDialog2.FileName = "openFileDialog1";
			this.m_btnBrowse.Location = new global::System.Drawing.Point(558, 45);
			this.m_btnBrowse.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.m_btnBrowse.Name = "m_btnBrowse";
			this.m_btnBrowse.Size = new global::System.Drawing.Size(109, 34);
			this.m_btnBrowse.TabIndex = 1;
			this.m_btnBrowse.Text = "Browse";
			this.m_btnBrowse.UseVisualStyleBackColor = true;
			this.m_btnBrowse.Click += new global::System.EventHandler(this.m_btnBrowse_Click);
			this.m_btnLoad.Location = new global::System.Drawing.Point(698, 45);
			this.m_btnLoad.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.m_btnLoad.Name = "m_btnLoad";
			this.m_btnLoad.Size = new global::System.Drawing.Size(109, 34);
			this.m_btnLoad.TabIndex = 2;
			this.m_btnLoad.Text = "Load";
			this.m_btnLoad.UseVisualStyleBackColor = true;
			this.m_btnLoad.Click += new global::System.EventHandler(this.m_btnLoad_Click);
			this.m_btnSave.Location = new global::System.Drawing.Point(838, 45);
			this.m_btnSave.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Size = new global::System.Drawing.Size(109, 34);
			this.m_btnSave.TabIndex = 3;
			this.m_btnSave.Text = "Save";
			this.m_btnSave.UseVisualStyleBackColor = true;
			this.m_btnSave.Click += new global::System.EventHandler(this.m_btnSave_Click);
			this.m_btnActivate.Location = new global::System.Drawing.Point(978, 45);
			this.m_btnActivate.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.m_btnActivate.Name = "m_btnActivate";
			this.m_btnActivate.Size = new global::System.Drawing.Size(109, 34);
			this.m_btnActivate.TabIndex = 4;
			this.m_btnActivate.Text = "Activate";
			this.m_btnActivate.UseVisualStyleBackColor = true;
			this.m_btnActivate.Click += new global::System.EventHandler(this.m_btnActivate_Click);
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			this.m_cboADCDataFileProfileConfig.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cboADCDataFileProfileConfig.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cboADCDataFileProfileConfig.FormattingEnabled = true;
			this.m_cboADCDataFileProfileConfig.Location = new global::System.Drawing.Point(41, 50);
			this.m_cboADCDataFileProfileConfig.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.m_cboADCDataFileProfileConfig.Name = "m_cboADCDataFileProfileConfig";
			this.m_cboADCDataFileProfileConfig.Size = new global::System.Drawing.Size(508, 25);
			this.m_cboADCDataFileProfileConfig.TabIndex = 8;
			this.m_cboADCDataFileProfileConfig.Text = "C:\\RadarStudio\\Clients\\AR1xController\\\\ProfConfigData.csv";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(120f, 120f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new global::System.Drawing.Size(1438, 746);
			base.Controls.Add(this.m_cboADCDataFileProfileConfig);
			base.Controls.Add(this.m_btnActivate);
			base.Controls.Add(this.m_btnSave);
			base.Controls.Add(this.dataGridView2);
			base.Controls.Add(this.m_btnLoad);
			base.Controls.Add(this.m_btnBrowse);
			this.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			base.Name = "ProfManager";
			this.Text = "ProfManager";
			base.Load += new global::System.EventHandler(this.ProfManager_Load);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView2).EndInit();
			base.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.OpenFileDialog openFileDialog2;

		private global::System.Windows.Forms.Button m_btnBrowse;

		private global::System.Windows.Forms.Button m_btnLoad;

		private global::System.Windows.Forms.DataGridView dataGridView2;

		private global::System.Windows.Forms.Button m_btnSave;

		private global::System.Windows.Forms.Button m_btnActivate;

		private global::System.Windows.Forms.NotifyIcon notifyIcon1;

		private global::System.Windows.Forms.ToolTip toolTip1;

		private global::System.Windows.Forms.ToolTip toolTip2;

		private global::System.Windows.Forms.ComboBox m_cboADCDataFileProfileConfig;
	}
}
