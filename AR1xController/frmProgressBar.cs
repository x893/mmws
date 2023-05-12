using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AR1xController
{
	public partial class frmProgressBar : Form
	{
		public frmProgressBar()
		{
			this.InitializeComponent();
			this.m_pbPercentage = 0;
		}

		public void iUpdateProgressBar()
		{
			int fwDownloadProgress = GlobalRef.m_FwDownloadProgress;
			this.m_pbPercentage = (int)((double)fwDownloadProgress / (double)this.m_pbFW.Maximum * 100.0);
			this.Text = string.Format("{0}%", this.m_pbPercentage.ToString());
			this.m_pbFW.Value = fwDownloadProgress;
		}

		private void frmProgressBar_Load(object sender, EventArgs p1)
		{
			GlobalRef.m_FwDownloadProgress = 0;
			this.Text = string.Format("{0}%", this.m_pbPercentage.ToString());
			this.m_btnCancelFw.Enabled = false;
			this.m_pbFW.Value = 0;
			this.m_tmFW.Start();
		}

		private void m_tmFW_Tick(object sender, EventArgs p1)
		{
			if (GlobalRef.GuiManager.MainTsForm.ConnectTab.DownlaodFwAbort)
			{
				base.DialogResult = DialogResult.Cancel;
			}
			this.m_tmFW.Stop();
			if (this.m_pbFW.Value < this.m_pbFW.Maximum)
			{
				this.iUpdateProgressBar();
			}
			else
			{
				this.m_pbFW.Value = this.m_pbFW.Maximum;
				this.Text = string.Format("100%", new object[0]);
				base.DialogResult = DialogResult.OK;
			}
			this.m_tmFW.Start();
		}

		private void frmProgressBar_FormClosing(object sender, FormClosingEventArgs p1)
		{
			this.m_tmFW.Stop();
		}

		private void m_btnCancelFw_Click(object sender, EventArgs p1)
		{
			this.m_tmFW.Stop();
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		private void m_lblCancelMsg_Click(object sender, EventArgs p1)
		{
		}

		private int m_pbPercentage;
	}
}
