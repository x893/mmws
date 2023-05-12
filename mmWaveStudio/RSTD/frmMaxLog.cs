using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RSTD
{

	public partial class frmMaxLog : Form
	{

		public frmMaxLog(string message, frmMain main_form)
		{
			this.m_MainForm = main_form;
			this.InitializeComponent();
			this.lblMessage.Text = message;
		}


		private void btnYes_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}


		private void btnNo_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
		}


		private void btnOpenLogFolder_Click(object sender, EventArgs e)
		{
			this.m_MainForm.OpenLogFolder();
		}


		private frmMain m_MainForm;
	}
}
