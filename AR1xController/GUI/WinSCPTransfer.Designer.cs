namespace AR1xController.GUI
{
	public partial class WinSCPTransfer : global::System.Windows.Forms.Form
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
			this.m_lblDownloadFw = new global::System.Windows.Forms.Label();
			this.m_tmFW = new global::System.Windows.Forms.Timer(this.components);
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.m_txtFileNameTransfer = new global::System.Windows.Forms.Label();
			this.m_txtTransferProgress = new global::System.Windows.Forms.Label();
			this.m_txtTransferSpeed = new global::System.Windows.Forms.Label();
			this.m_TransferProgressBar = new global::System.Windows.Forms.ProgressBar();
			this.m_OverallProgressBar = new global::System.Windows.Forms.ProgressBar();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.m_txtTotalFiles = new global::System.Windows.Forms.Label();
			this.m_btnCancelTransfer = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.m_lblDownloadFw.AutoSize = true;
			this.m_lblDownloadFw.Location = new global::System.Drawing.Point(32, 245);
			this.m_lblDownloadFw.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_lblDownloadFw.Name = "m_lblDownloadFw";
			this.m_lblDownloadFw.Size = new global::System.Drawing.Size(120, 17);
			this.m_lblDownloadFw.TabIndex = 3;
			this.m_lblDownloadFw.Text = "Transferring File :";
			this.m_tmFW.Interval = 200;
			this.m_tmFW.Tick += new global::System.EventHandler(this.m_tmFW_Tick);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(32, 284);
			this.label1.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(175, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Progress of the Transfer  :";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(32, 322);
			this.label2.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(119, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "Transfer Speed  :";
			this.m_txtFileNameTransfer.AutoSize = true;
			this.m_txtFileNameTransfer.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_txtFileNameTransfer.ForeColor = global::System.Drawing.Color.FromArgb(0, 0, 192);
			this.m_txtFileNameTransfer.Location = new global::System.Drawing.Point(160, 245);
			this.m_txtFileNameTransfer.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_txtFileNameTransfer.Name = "m_txtFileNameTransfer";
			this.m_txtFileNameTransfer.Size = new global::System.Drawing.Size(0, 18);
			this.m_txtFileNameTransfer.TabIndex = 6;
			this.m_txtTransferProgress.AutoSize = true;
			this.m_txtTransferProgress.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_txtTransferProgress.ForeColor = global::System.Drawing.Color.FromArgb(0, 0, 192);
			this.m_txtTransferProgress.Location = new global::System.Drawing.Point(221, 284);
			this.m_txtTransferProgress.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_txtTransferProgress.Name = "m_txtTransferProgress";
			this.m_txtTransferProgress.Size = new global::System.Drawing.Size(0, 18);
			this.m_txtTransferProgress.TabIndex = 7;
			this.m_txtTransferSpeed.AutoSize = true;
			this.m_txtTransferSpeed.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_txtTransferSpeed.ForeColor = global::System.Drawing.Color.FromArgb(0, 0, 192);
			this.m_txtTransferSpeed.Location = new global::System.Drawing.Point(160, 322);
			this.m_txtTransferSpeed.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_txtTransferSpeed.Name = "m_txtTransferSpeed";
			this.m_txtTransferSpeed.Size = new global::System.Drawing.Size(0, 18);
			this.m_txtTransferSpeed.TabIndex = 8;
			this.m_TransferProgressBar.Location = new global::System.Drawing.Point(35, 193);
			this.m_TransferProgressBar.Name = "m_TransferProgressBar";
			this.m_TransferProgressBar.Size = new global::System.Drawing.Size(587, 23);
			this.m_TransferProgressBar.Step = 5;
			this.m_TransferProgressBar.Style = global::System.Windows.Forms.ProgressBarStyle.Continuous;
			this.m_TransferProgressBar.TabIndex = 0;
			this.m_OverallProgressBar.Location = new global::System.Drawing.Point(30, 60);
			this.m_OverallProgressBar.Name = "m_OverallProgressBar";
			this.m_OverallProgressBar.Size = new global::System.Drawing.Size(587, 23);
			this.m_OverallProgressBar.Step = 5;
			this.m_OverallProgressBar.Style = global::System.Windows.Forms.ProgressBarStyle.Continuous;
			this.m_OverallProgressBar.TabIndex = 0;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(225, 28);
			this.label3.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(172, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "Overall Transfer Progress";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(234, 162);
			this.label4.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(149, 17);
			this.label4.TabIndex = 11;
			this.label4.Text = "File Transfer Progress";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(32, 112);
			this.label5.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(187, 17);
			this.label5.TabIndex = 12;
			this.label5.Text = "Total files to be transferred :";
			this.m_txtTotalFiles.AutoSize = true;
			this.m_txtTotalFiles.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.m_txtTotalFiles.ForeColor = global::System.Drawing.Color.FromArgb(0, 0, 192);
			this.m_txtTotalFiles.Location = new global::System.Drawing.Point(234, 112);
			this.m_txtTotalFiles.Name = "m_txtTotalFiles";
			this.m_txtTotalFiles.Size = new global::System.Drawing.Size(16, 17);
			this.m_txtTotalFiles.TabIndex = 13;
			this.m_txtTotalFiles.Text = "0";
			this.m_btnCancelTransfer.Location = new global::System.Drawing.Point(250, 357);
			this.m_btnCancelTransfer.Name = "m_btnCancelTransfer";
			this.m_btnCancelTransfer.Size = new global::System.Drawing.Size(109, 37);
			this.m_btnCancelTransfer.TabIndex = 14;
			this.m_btnCancelTransfer.TabStop = false;
			this.m_btnCancelTransfer.Text = "Cancel";
			this.m_btnCancelTransfer.UseVisualStyleBackColor = true;
			this.m_btnCancelTransfer.Click += new global::System.EventHandler(this.m_btnCancelTransfer_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(646, 408);
			base.Controls.Add(this.m_btnCancelTransfer);
			base.Controls.Add(this.m_txtTotalFiles);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.m_OverallProgressBar);
			base.Controls.Add(this.m_TransferProgressBar);
			base.Controls.Add(this.m_txtTransferSpeed);
			base.Controls.Add(this.m_txtTransferProgress);
			base.Controls.Add(this.m_txtFileNameTransfer);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.m_lblDownloadFw);
			base.Name = "WinSCPTransfer";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WinSCP Transfer Status";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.frmProgressBar_FormClosing);
			base.Load += new global::System.EventHandler(this.frmProgressBar_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Label m_lblDownloadFw;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.Label m_txtFileNameTransfer;

		private global::System.Windows.Forms.Label m_txtTransferProgress;

		private global::System.Windows.Forms.Label m_txtTransferSpeed;

		private global::System.Windows.Forms.Timer m_tmFW;

		private global::System.Windows.Forms.ProgressBar m_TransferProgressBar;

		private global::System.Windows.Forms.ProgressBar m_OverallProgressBar;

		private global::System.Windows.Forms.Label label3;

		private global::System.Windows.Forms.Label label4;

		private global::System.Windows.Forms.Label label5;

		private global::System.Windows.Forms.Label m_txtTotalFiles;

		private global::System.Windows.Forms.Button m_btnCancelTransfer;
	}
}
