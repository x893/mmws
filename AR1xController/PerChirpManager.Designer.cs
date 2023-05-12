namespace AR1xController
{
	public partial class PerChirpManager : global::System.Windows.Forms.Form
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
            this.m_btnChirpPhaseShifterBrowse = new System.Windows.Forms.Button();
            this.m_btnChirpPhaseShifterLoad = new System.Windows.Forms.Button();
            this.m_btnChirpPhaseShifterSave = new System.Windows.Forms.Button();
            this.m_btnChirpPhaseShifterActivate = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.m_cboADCDataFileChirpBasedPhaseShifterConfig = new System.Windows.Forms.ComboBox();
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
            // m_btnChirpPhaseShifterBrowse
            // 
            this.m_btnChirpPhaseShifterBrowse.Location = new System.Drawing.Point(542, 36);
            this.m_btnChirpPhaseShifterBrowse.Name = "m_btnChirpPhaseShifterBrowse";
            this.m_btnChirpPhaseShifterBrowse.Size = new System.Drawing.Size(87, 27);
            this.m_btnChirpPhaseShifterBrowse.TabIndex = 1;
            this.m_btnChirpPhaseShifterBrowse.Text = "Browse";
            this.m_btnChirpPhaseShifterBrowse.UseVisualStyleBackColor = true;
            this.m_btnChirpPhaseShifterBrowse.Click += new System.EventHandler(this.m_btnBrowse_Click);
            // 
            // m_btnChirpPhaseShifterLoad
            // 
            this.m_btnChirpPhaseShifterLoad.Location = new System.Drawing.Point(654, 36);
            this.m_btnChirpPhaseShifterLoad.Name = "m_btnChirpPhaseShifterLoad";
            this.m_btnChirpPhaseShifterLoad.Size = new System.Drawing.Size(87, 27);
            this.m_btnChirpPhaseShifterLoad.TabIndex = 2;
            this.m_btnChirpPhaseShifterLoad.Text = "Load";
            this.m_btnChirpPhaseShifterLoad.UseVisualStyleBackColor = true;
            this.m_btnChirpPhaseShifterLoad.Click += new System.EventHandler(this.m_btnLoad_Click);
            // 
            // m_btnChirpPhaseShifterSave
            // 
            this.m_btnChirpPhaseShifterSave.Location = new System.Drawing.Point(766, 36);
            this.m_btnChirpPhaseShifterSave.Name = "m_btnChirpPhaseShifterSave";
            this.m_btnChirpPhaseShifterSave.Size = new System.Drawing.Size(87, 27);
            this.m_btnChirpPhaseShifterSave.TabIndex = 3;
            this.m_btnChirpPhaseShifterSave.Text = "Save";
            this.m_btnChirpPhaseShifterSave.UseVisualStyleBackColor = true;
            this.m_btnChirpPhaseShifterSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnChirpPhaseShifterActivate
            // 
            this.m_btnChirpPhaseShifterActivate.Location = new System.Drawing.Point(878, 36);
            this.m_btnChirpPhaseShifterActivate.Name = "m_btnChirpPhaseShifterActivate";
            this.m_btnChirpPhaseShifterActivate.Size = new System.Drawing.Size(87, 27);
            this.m_btnChirpPhaseShifterActivate.TabIndex = 4;
            this.m_btnChirpPhaseShifterActivate.Text = "Activate";
            this.m_btnChirpPhaseShifterActivate.UseVisualStyleBackColor = true;
            this.m_btnChirpPhaseShifterActivate.Click += new System.EventHandler(this.m_btnActivate_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // m_cboADCDataFileChirpBasedPhaseShifterConfig
            // 
            this.m_cboADCDataFileChirpBasedPhaseShifterConfig.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_cboADCDataFileChirpBasedPhaseShifterConfig.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.m_cboADCDataFileChirpBasedPhaseShifterConfig.FormattingEnabled = true;
            this.m_cboADCDataFileChirpBasedPhaseShifterConfig.Location = new System.Drawing.Point(33, 40);
            this.m_cboADCDataFileChirpBasedPhaseShifterConfig.Name = "m_cboADCDataFileChirpBasedPhaseShifterConfig";
            this.m_cboADCDataFileChirpBasedPhaseShifterConfig.Size = new System.Drawing.Size(481, 23);
            this.m_cboADCDataFileChirpBasedPhaseShifterConfig.TabIndex = 8;
            this.m_cboADCDataFileChirpBasedPhaseShifterConfig.Text = "C:\\RadarStudio\\Clients\\AR1xController\\ChirpPhaseShifterConfigData.csv";
            // 
            // PerChirpManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1027, 597);
            this.Controls.Add(this.m_cboADCDataFileChirpBasedPhaseShifterConfig);
            this.Controls.Add(this.m_btnChirpPhaseShifterActivate);
            this.Controls.Add(this.m_btnChirpPhaseShifterSave);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.m_btnChirpPhaseShifterLoad);
            this.Controls.Add(this.m_btnChirpPhaseShifterBrowse);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PerChirpManager";
            this.Text = "PerChirpManager";
            this.Load += new System.EventHandler(this.ProfManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.OpenFileDialog openFileDialog2;

		private global::System.Windows.Forms.Button m_btnChirpPhaseShifterBrowse;

		private global::System.Windows.Forms.Button m_btnChirpPhaseShifterLoad;

		private global::System.Windows.Forms.DataGridView dataGridView2;

		private global::System.Windows.Forms.Button m_btnChirpPhaseShifterSave;

		private global::System.Windows.Forms.Button m_btnChirpPhaseShifterActivate;

		private global::System.Windows.Forms.NotifyIcon notifyIcon1;

		private global::System.Windows.Forms.ToolTip toolTip1;

		private global::System.Windows.Forms.ToolTip toolTip2;

		private global::System.Windows.Forms.ComboBox m_cboADCDataFileChirpBasedPhaseShifterConfig;
	}
}
