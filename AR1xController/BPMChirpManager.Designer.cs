namespace AR1xController
{
	public partial class BPMChirpManager : global::System.Windows.Forms.Form
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.m_btnBPMChirpBrowse = new System.Windows.Forms.Button();
            this.m_btnBPMChirpLoad = new System.Windows.Forms.Button();
            this.m_btnBPMChirpSave = new System.Windows.Forms.Button();
            this.m_btnBPMChirpActivate = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.m_cboADCDataFileBPMConfig = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 181);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1144, 415);
            this.dataGridView2.TabIndex = 5;
            this.dataGridView2.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView2_CellBeginEdit);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // m_btnBPMChirpBrowse
            // 
            this.m_btnBPMChirpBrowse.Location = new System.Drawing.Point(542, 36);
            this.m_btnBPMChirpBrowse.Name = "m_btnBPMChirpBrowse";
            this.m_btnBPMChirpBrowse.Size = new System.Drawing.Size(87, 27);
            this.m_btnBPMChirpBrowse.TabIndex = 1;
            this.m_btnBPMChirpBrowse.Text = "Browse";
            this.m_btnBPMChirpBrowse.UseVisualStyleBackColor = true;
            this.m_btnBPMChirpBrowse.Click += new System.EventHandler(this.m_btnBrowse_Click);
            // 
            // m_btnBPMChirpLoad
            // 
            this.m_btnBPMChirpLoad.Location = new System.Drawing.Point(654, 36);
            this.m_btnBPMChirpLoad.Name = "m_btnBPMChirpLoad";
            this.m_btnBPMChirpLoad.Size = new System.Drawing.Size(87, 27);
            this.m_btnBPMChirpLoad.TabIndex = 2;
            this.m_btnBPMChirpLoad.Text = "Load";
            this.m_btnBPMChirpLoad.UseVisualStyleBackColor = true;
            this.m_btnBPMChirpLoad.Click += new System.EventHandler(this.m_btnLoad_Click);
            // 
            // m_btnBPMChirpSave
            // 
            this.m_btnBPMChirpSave.Location = new System.Drawing.Point(766, 36);
            this.m_btnBPMChirpSave.Name = "m_btnBPMChirpSave";
            this.m_btnBPMChirpSave.Size = new System.Drawing.Size(87, 27);
            this.m_btnBPMChirpSave.TabIndex = 3;
            this.m_btnBPMChirpSave.Text = "Save";
            this.m_btnBPMChirpSave.UseVisualStyleBackColor = true;
            this.m_btnBPMChirpSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnBPMChirpActivate
            // 
            this.m_btnBPMChirpActivate.Location = new System.Drawing.Point(878, 36);
            this.m_btnBPMChirpActivate.Name = "m_btnBPMChirpActivate";
            this.m_btnBPMChirpActivate.Size = new System.Drawing.Size(87, 27);
            this.m_btnBPMChirpActivate.TabIndex = 4;
            this.m_btnBPMChirpActivate.Text = "Activate";
            this.m_btnBPMChirpActivate.UseVisualStyleBackColor = true;
            this.m_btnBPMChirpActivate.Click += new System.EventHandler(this.m_btnActivate_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // m_cboADCDataFileBPMConfig
            // 
            this.m_cboADCDataFileBPMConfig.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_cboADCDataFileBPMConfig.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.m_cboADCDataFileBPMConfig.FormattingEnabled = true;
            this.m_cboADCDataFileBPMConfig.Location = new System.Drawing.Point(33, 40);
            this.m_cboADCDataFileBPMConfig.Name = "m_cboADCDataFileBPMConfig";
            this.m_cboADCDataFileBPMConfig.Size = new System.Drawing.Size(481, 23);
            this.m_cboADCDataFileBPMConfig.TabIndex = 8;
            this.m_cboADCDataFileBPMConfig.Text = "C:\\RadarStudio\\Clients\\AR1xController\\BPMTxChannelData.csv";
            // 
            // BPMChirpManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1027, 597);
            this.Controls.Add(this.m_cboADCDataFileBPMConfig);
            this.Controls.Add(this.m_btnBPMChirpActivate);
            this.Controls.Add(this.m_btnBPMChirpSave);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.m_btnBPMChirpLoad);
            this.Controls.Add(this.m_btnBPMChirpBrowse);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BPMChirpManager";
            this.Text = "BPMChirpManager";
            this.Load += new System.EventHandler(this.ProfManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.OpenFileDialog openFileDialog2;

		private global::System.Windows.Forms.Button m_btnBPMChirpBrowse;

		private global::System.Windows.Forms.Button m_btnBPMChirpLoad;

		private global::System.Windows.Forms.DataGridView dataGridView2;

		private global::System.Windows.Forms.Button m_btnBPMChirpSave;

		private global::System.Windows.Forms.Button m_btnBPMChirpActivate;

		private global::System.Windows.Forms.NotifyIcon notifyIcon1;

		private global::System.Windows.Forms.ToolTip toolTip1;

		private global::System.Windows.Forms.ToolTip toolTip2;

		private global::System.Windows.Forms.ComboBox m_cboADCDataFileBPMConfig;
	}
}
