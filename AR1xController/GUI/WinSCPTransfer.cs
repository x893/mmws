using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController.GUI
{
	public partial class WinSCPTransfer : Form
	{
		public WinSCPTransfer()
		{
			this.InitializeComponent();
			this.m_txtTotalFiles.Text = "0";
			this.m_txtTransferProgress.Text = "0";
			this.m_txtTransferSpeed.Text = "0";
		}

		public void UpdateTransferStatus(string filename, string transferProgress, string transferSpeed)
		{
			this.transfer_Filename = filename;
			this.transfer_Progress = transferProgress;
			this.transfer_Speed = transferSpeed;
			this.m_txtTotalFiles.Text = GlobalRef.g_numCaptureDirectoryFiles.ToString();
			this.m_txtFileNameTransfer.Text = filename;
			this.m_txtTransferProgress.Text = transferProgress + " %";
			this.m_TransferProgressBar.Value = Convert.ToInt32(transferProgress, 10);
			this.m_OverallProgressBar.Value = (int)(GlobalRef.g_numCaptureFilesTransferred / GlobalRef.g_numCaptureDirectoryFiles * 100.0);
			this.m_txtTransferSpeed.Text = transferSpeed + " MB/sec";
		}

		private void m_tmFW_Tick(object sender, EventArgs p1)
		{
			if (GlobalRef.GuiManager.MainTsForm.ChirpConfigTab.DownlaodFilesAbort)
			{
				base.DialogResult = DialogResult.Cancel;
			}
			this.m_tmFW.Stop();
			if (this.m_OverallProgressBar.Value < this.m_OverallProgressBar.Maximum)
			{
				if (this.m_TransferProgressBar.Value < this.m_TransferProgressBar.Maximum)
				{
					this.UpdateTransferStatus(GlobalRef.g_winSCPfilename, GlobalRef.g_winSCPprogress, GlobalRef.g_winSCPtransferSpeed);
				}
				else
				{
					this.m_TransferProgressBar.Value = 0;
				}
			}
			else
			{
				base.DialogResult = DialogResult.OK;
				this.m_OverallProgressBar.Value = this.m_OverallProgressBar.Maximum;
			}
			this.m_tmFW.Start();
		}

		private void frmProgressBar_Load(object sender, EventArgs p1)
		{
			this.m_OverallProgressBar.Value = 0;
			this.m_TransferProgressBar.Value = 0;
			this.m_tmFW.Start();
			base.Focus();
		}

		private void frmProgressBar_FormClosing(object sender, FormClosingEventArgs p1)
		{
			this.m_tmFW.Stop();
		}

		private void m_btnCancelTransfer_Click(object sender, EventArgs p1)
		{
			GlobalRef.GuiManager.MainTsForm.ChirpConfigTab.DownlaodFilesAbort = true;
			this.m_tmFW.Stop();
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		public string transfer_Filename = "";

		public string transfer_Progress = "0";

		public string transfer_Speed = "0";
	}
}
