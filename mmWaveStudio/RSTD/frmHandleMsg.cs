using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RSTD.Properties;

namespace RSTD
{

	public partial class frmHandleMsg : Form
	{

		public frmHandleMsg(string msg, string msg_stack, RstdConstants.MESSAGE_TYPE msg_type, string title, RstdConstants.CORE_MSG_BTN core_msg_btn, Icon msg_box_icon)
		{
			this.InitializeComponent();
			this.iShowStackRelated(false);
			this.iShowMsg(msg, msg_stack, msg_type, title, core_msg_btn, msg_box_icon);
		}


		public void iShowMsg(string msg, string msg_stack, RstdConstants.MESSAGE_TYPE msg_type, string title, RstdConstants.CORE_MSG_BTN core_msg_btn, Icon msg_box_icon)
		{
			base.Icon = msg_box_icon;
			this.Text = title;
			this.iSetMessageImage(msg_type);
			this.iHandleMsg(msg, msg_stack);
			this.iButtonStatements(core_msg_btn);
		}


		private void iShowStackRelated(bool show)
		{
			this.detailsCheckBox.Visible = show;
			this.stackTraceTextBox.Visible = show;
			this.stackLayoutPanel.Visible = show;
		}


		private void iSetMessageImage(RstdConstants.MESSAGE_TYPE msg_type)
		{
			Bitmap image;
			switch (msg_type)
			{
			case RstdConstants.MESSAGE_TYPE.OK_INFORMATION:
			case RstdConstants.MESSAGE_TYPE.OK_CANCEL_INFORMATION:
			case RstdConstants.MESSAGE_TYPE.RSTD_DEF:
			case RstdConstants.MESSAGE_TYPE.GUI_CLIENT_MESSAGE:
				image = new Bitmap(Resources.message_info, new Size(36, 36));
				break;
			case RstdConstants.MESSAGE_TYPE.RSTD_EXCEPTION:
			case RstdConstants.MESSAGE_TYPE.RSTD_EXCEPTION_EXIT:
			case RstdConstants.MESSAGE_TYPE.OK_ERROR:
			case RstdConstants.MESSAGE_TYPE.GUI_CLIENT_ERROR:
				image = new Bitmap(Resources.message_error, new Size(36, 36));
				break;
			case RstdConstants.MESSAGE_TYPE.QEUSTION:
				image = new Bitmap(Resources.message_question, new Size(36, 36));
				break;
			case RstdConstants.MESSAGE_TYPE.YES_NO_WARNING:
			case RstdConstants.MESSAGE_TYPE.OK_WARNING:
				image = new Bitmap(Resources.message_warning, new Size(36, 36));
				break;
			default:
				image = new Bitmap(Resources.message_info, new Size(36, 36));
				break;
			}
			this.m_ImagePictureBox.Image = image;
		}


		private void iHandleMsg(string msg, string msg_stack)
		{
			if (msg_stack != "")
			{
				this.iShowStackRelated(true);
				this.txtMessage.Text = msg.Trim();
				this.stackTraceTextBox.Text = msg_stack.Trim().Replace("\n", Environment.NewLine);
				return;
			}
			this.iShowStackRelated(false);
			this.txtMessage.Text = msg.Trim();
		}


		private void iButtonStatements(RstdConstants.CORE_MSG_BTN core_msg_btn)
		{
			switch (core_msg_btn)
			{
			case RstdConstants.CORE_MSG_BTN.OK:
				this.iShowOkButton();
				break;
			case RstdConstants.CORE_MSG_BTN.ExitDebugIgnore:
				this.iShowExitRstdButton();
				this.iShowDebugButton();
				this.iShowIgnoreButton();
				break;
			case RstdConstants.CORE_MSG_BTN.OkCancel:
				this.iShowOkButton();
				this.iShowCancelButton();
				break;
			case RstdConstants.CORE_MSG_BTN.YesNo:
				this.iShowYesButton();
				this.iShowNoButton();
				break;
			case RstdConstants.CORE_MSG_BTN.ExitDebug:
				this.iShowExitRstdButton();
				this.iShowDebugButton();
				break;
			}
			if (this.m_flP_btn.Controls.Count > 0)
			{
				if (frmMain.bIsScriptRunning)
				{
					this.iShowStopLuaScriptButton();
				}
				int num = (this.m_flP_btn.Controls.Count == 1) ? -40 : 10;
				int left = (this.m_flP_btn.Width - this.m_flP_btn.Controls.Count * this.m_flP_btn.Controls[0].Width) / (this.m_flP_btn.Controls.Count + 1) + num;
				this.m_flP_btn.Padding = new Padding(left, 0, 0, 0);
			}
		}


		private void iShowOkButton()
		{
			this.m_btnOK = new Button();
			this.iSetBtnShape(this.m_btnOK, "OK");
			this.m_flP_btn.Controls.Add(this.m_btnOK);
			this.m_btnOK.DialogResult = DialogResult.OK;
		}


		private void iShowStopLuaScriptButton()
		{
			this.m_btnStopLuaScript = new Button();
			this.iSetBtnShape(this.m_btnStopLuaScript, "Stop Script");
			this.m_flP_btn.Controls.Add(this.m_btnStopLuaScript);
			this.m_btnStopLuaScript.DialogResult = DialogResult.Ignore;
			this.m_btnStopLuaScript.Click += this.m_btnStopLuaScript_Click;
		}


		private void m_btnStopLuaScript_Click(object sender, EventArgs e)
		{
			GuiCore.MainForm.StopScript();
		}


		private void iShowExitRstdButton()
		{
			this.m_btnExitRstd = new Button();
			this.iSetBtnShape(this.m_btnExitRstd, "Exit RSTD");
			this.m_flP_btn.Controls.Add(this.m_btnExitRstd);
			this.m_btnExitRstd.DialogResult = DialogResult.Abort;
		}


		private void iShowDebugButton()
		{
			this.m_btnDebug = new Button();
			this.iSetBtnShape(this.m_btnDebug, "Debug");
			this.m_flP_btn.Controls.Add(this.m_btnDebug);
			this.m_btnDebug.DialogResult = DialogResult.Retry;
		}


		private void iShowIgnoreButton()
		{
			this.m_btnIgnore = new Button();
			this.iSetBtnShape(this.m_btnIgnore, "Ignore");
			this.m_flP_btn.Controls.Add(this.m_btnIgnore);
			this.m_btnIgnore.DialogResult = DialogResult.Ignore;
		}


		private void iShowCancelButton()
		{
			this.m_btnCancel = new Button();
			this.iSetBtnShape(this.m_btnCancel, "Cancel");
			this.m_flP_btn.Controls.Add(this.m_btnCancel);
			this.m_btnCancel.DialogResult = DialogResult.Cancel;
		}


		private void iShowYesButton()
		{
			this.m_btnYes = new Button();
			this.iSetBtnShape(this.m_btnYes, "Yes");
			this.m_flP_btn.Controls.Add(this.m_btnYes);
			this.m_btnYes.DialogResult = DialogResult.Yes;
		}


		private void iShowNoButton()
		{
			this.m_btnNo = new Button();
			this.iSetBtnShape(this.m_btnNo, "No");
			this.m_flP_btn.Controls.Add(this.m_btnNo);
			this.m_btnNo.DialogResult = DialogResult.No;
		}


		private void iSetBtnShape(Button btn, string text)
		{
			btn.Text = text;
			btn.Font = new Font("Arial", 8.25f, FontStyle.Regular);
			btn.BackColor = SystemColors.Control;
			btn.UseVisualStyleBackColor = true;
			btn.Size = new Size(75, 25);
		}


		private void detailsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (this.detailsCheckBox.Checked)
			{
				this.stackTraceTextBox.Visible = true;
				this.stackLayoutPanel.Visible = true;
				base.Height = 413;
				return;
			}
			this.stackTraceTextBox.Visible = false;
			this.stackLayoutPanel.Visible = false;
			base.Height = 150;
		}


		private Button m_btnOK;


		private Button m_btnExitRstd;


		private Button m_btnDebug;


		private Button m_btnIgnore;


		private Button m_btnCancel;


		private Button m_btnYes;


		private Button m_btnNo;


		private Button m_btnStopLuaScript;
	}
}
