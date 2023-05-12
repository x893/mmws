using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RSTD
{

	public partial class frmMessage : Form
	{

		public frmMessage(string message)
		{
			this.InitializeComponent();
			this.lblMessage.Text = message;
		}


		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
