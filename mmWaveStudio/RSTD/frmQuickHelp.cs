using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace RSTD
{

	public partial class frmQuickHelp : DockContent
	{

		public frmQuickHelp()
		{
			this.InitializeComponent();
		}


		private void frmQuickHelp_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}
	}
}
