using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RSTD
{

	public partial class frmInteractiveMsgBox : Form
	{



		public string Answer
		{
			get
			{
				return this.m_Answer;
			}
			set
			{
				this.m_Answer = value;
			}
		}


		public frmInteractiveMsgBox(string txt)
		{
			this.InitializeComponent();
			this.lblQuestionText.Text = txt;
			this.m_Answer = "";
		}


		private void btnOK_Click(object sender, EventArgs e)
		{
			this.iReturnInput();
		}


		private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.iReturnInput();
			}
		}


		private void iReturnInput()
		{
			this.m_Answer = this.txtAnswer.Text;
			base.DialogResult = DialogResult.OK;
		}


		private string m_Answer;
	}
}
