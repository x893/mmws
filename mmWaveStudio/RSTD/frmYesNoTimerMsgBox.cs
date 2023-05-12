using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RSTD
{

	public partial class frmYesNoTimerMsgBox : Form
	{

		public frmYesNoTimerMsgBox()
		{
			this.InitializeComponent();
		}


		private void countDown()
		{
			for (int i = this.time; i >= 0; i--)
			{
				this.changeButtonText(i.ToString());
				Thread.Sleep(1000);
			}
			this.doClick();
		}


		private void btnNo_Click(object sender, EventArgs e)
		{
			this.timer.Abort();
			this.ans = false;
			base.Hide();
		}


		private void btnYes_Click(object sender, EventArgs e)
		{
			this.timer.Abort();
			this.ans = true;
			base.Hide();
		}


		public void configure(string text, bool defaultAns, int t)
		{
			this.QestionText.Text = text;
			this.time = t;
			this.ans = defaultAns;
			this.btnYes.Text = "Yes";
			this.btnNo.Text = "No";
			if (this.ans)
			{
				this.btnYes.Select();
			}
			else
			{
				this.btnNo.Select();
			}
			this.timer = new Thread(new ThreadStart(this.countDown));
			this.timer.IsBackground = true;
			this.timer.Start();
		}


		public void changeButtonText(string text)
		{
			if (base.InvokeRequired)
			{
				frmYesNoTimerMsgBox.changeBtnText method = new frmYesNoTimerMsgBox.changeBtnText(this.changeButtonText);
				base.Invoke(method, new object[]
				{
					text
				});
				return;
			}
			if (this.ans)
			{
				this.btnYes.Text = "Yes (" + text + ")";
				return;
			}
			this.btnNo.Text = "No (" + text + ")";
		}


		public void doClick()
		{
			if (base.InvokeRequired)
			{
				frmYesNoTimerMsgBox.general method = new frmYesNoTimerMsgBox.general(this.doClick);
				base.Invoke(method, new object[0]);
				return;
			}
			if (this.ans)
			{
				this.btnYes.PerformClick();
				return;
			}
			this.btnNo.PerformClick();
		}


		public bool ans;


		private int time = 20;


		private Thread timer;



		public delegate void changeBtnText(string Text);



		public delegate void general();
	}
}
