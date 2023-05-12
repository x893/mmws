namespace AR1xController
{
	public partial class frmProgressBar : global::System.Windows.Forms.Form
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
			this.m_pbFW = new global::System.Windows.Forms.ProgressBar();
			this.m_tmFW = new global::System.Windows.Forms.Timer(this.components);
			this.m_btnCancelFw = new global::System.Windows.Forms.Button();
			this.m_lblDownloadFw = new global::System.Windows.Forms.Label();
			this.m_lblCancelMsg = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.m_pbFW.BackColor = global::System.Drawing.Color.FromArgb(255, 192, 128);
			this.m_pbFW.Location = new global::System.Drawing.Point(14, 68);
			this.m_pbFW.Name = "m_pbFW";
			this.m_pbFW.Size = new global::System.Drawing.Size(313, 27);
			this.m_pbFW.Step = 5;
			this.m_pbFW.Style = global::System.Windows.Forms.ProgressBarStyle.Continuous;
			this.m_pbFW.TabIndex = 0;
			this.m_tmFW.Interval = 200;
			this.m_tmFW.Tick += new global::System.EventHandler(this.m_tmFW_Tick);
			this.m_btnCancelFw.Location = new global::System.Drawing.Point(110, 100);
			this.m_btnCancelFw.Name = "m_btnCancelFw";
			this.m_btnCancelFw.Size = new global::System.Drawing.Size(87, 27);
			this.m_btnCancelFw.TabIndex = 1;
			this.m_btnCancelFw.Text = "Cancel";
			this.m_btnCancelFw.UseVisualStyleBackColor = true;
			this.m_btnCancelFw.Click += new global::System.EventHandler(this.m_btnCancelFw_Click);
			this.m_lblDownloadFw.AutoSize = true;
			this.m_lblDownloadFw.Location = new global::System.Drawing.Point(15, 15);
			this.m_lblDownloadFw.Name = "m_lblDownloadFw";
			this.m_lblDownloadFw.Size = new global::System.Drawing.Size(195, 15);
			this.m_lblDownloadFw.TabIndex = 2;
			this.m_lblDownloadFw.Text = "Downloading Firmware to device...";
			this.m_lblCancelMsg.AutoSize = true;
			this.m_lblCancelMsg.Location = new global::System.Drawing.Point(14, 35);
			this.m_lblCancelMsg.Name = "m_lblCancelMsg";
			this.m_lblCancelMsg.Size = new global::System.Drawing.Size(179, 15);
			this.m_lblCancelMsg.TabIndex = 3;
			this.m_lblCancelMsg.Text = "Please wait, you can't terminate";
			this.m_lblCancelMsg.Click += new global::System.EventHandler(this.m_lblCancelMsg_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new global::System.Drawing.Size(343, 152);
			base.ControlBox = false;
			base.Controls.Add(this.m_lblCancelMsg);
			base.Controls.Add(this.m_lblDownloadFw);
			base.Controls.Add(this.m_btnCancelFw);
			base.Controls.Add(this.m_pbFW);
			this.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmProgressBar";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Download FirmWare";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.frmProgressBar_FormClosing);
			base.Load += new global::System.EventHandler(this.frmProgressBar_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.ProgressBar m_pbFW;

		private global::System.Windows.Forms.Timer m_tmFW;

		private global::System.Windows.Forms.Button m_btnCancelFw;

		private global::System.Windows.Forms.Label m_lblDownloadFw;

		private global::System.Windows.Forms.Label m_lblCancelMsg;
	}
}
