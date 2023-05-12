using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RSTD
{

	public partial class frmFilter : Form
	{

		public frmFilter(string includeText, string excludeText)
		{
			this.InitializeComponent();
			this.txtInclude.Text = includeText;
			this.txtExclude.Text = excludeText;
		}



		public string IncludeText
		{
			get
			{
				return this.m_IncludeText;
			}
		}



		public string ExcludeText
		{
			get
			{
				return this.m_ExcludeText;
			}
		}


		private void btnOK_Click(object sender, EventArgs e)
		{
			this.m_IncludeText = this.txtInclude.Text;
			this.m_ExcludeText = this.txtExclude.Text;
			base.DialogResult = DialogResult.OK;
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}


		private string m_IncludeText;


		private string m_ExcludeText;
	}
}
