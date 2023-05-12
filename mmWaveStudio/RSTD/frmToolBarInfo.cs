using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RSTD.Properties;

namespace RSTD
{

	public partial class frmToolBarInfo : Form
	{



		public string ToolBarName
		{
			get
			{
				return this.m_ToolBarName;
			}
			set
			{
				this.m_ToolBarName = value;
			}
		}




		public string ToolBarBasePath
		{
			get
			{
				return this.m_ToolBarBasePath;
			}
			set
			{
				this.m_ToolBarBasePath = value;
			}
		}


		public frmToolBarInfo()
		{
			this.InitializeComponent();
			this.pathFlowLayoutPanel.Visible = false;
			this.m_ToolBarConfigFile = "";
		}


		public frmToolBarInfo(string name)
		{
			this.InitializeComponent();
			this.nameTextBox.Text = name;
			this.pathFlowLayoutPanel.Visible = false;
			this.m_ToolBarConfigFile = "";
		}


		public frmToolBarInfo(UserToolStripInfo tsi)
		{
			this.InitializeComponent();
			this.nameTextBox.Text = tsi.ToolBarName;
			this.basePathTextBox.Text = tsi.ToolBarBasePath;
			this.pathlinkLabel.Text = tsi.ToolBarConfigFile;
			this.m_ToolBarConfigFile = tsi.ToolBarConfigFile;
			this.iCheckFileAccess();
		}


		private void okButton_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.m_ToolBarConfigFile) && File.Exists(this.m_ToolBarConfigFile) && GuiCore.IsFileReadOnly(this.m_ToolBarConfigFile))
			{
				GuiCore.WarningMsgBox(string.Format("Can't save user toolbar to:\n\"{0}\".\nFile is read-only.", this.m_ToolBarConfigFile));
				return;
			}
			this.m_ToolBarName = this.nameTextBox.Text;
			this.m_ToolBarBasePath = this.basePathTextBox.Text;
			base.DialogResult = DialogResult.OK;
		}


		private void browseButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = "Choose Base Directory..";
			folderBrowserDialog.SelectedPath = this.basePathTextBox.Text;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				this.basePathTextBox.Text = folderBrowserDialog.SelectedPath;
			}
		}


		private void pathlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(this.pathlinkLabel.Text);
		}


		private void iCheckFileAccess()
		{
			bool flag = false;
			if (!string.IsNullOrEmpty(this.m_ToolBarConfigFile) && File.Exists(this.m_ToolBarConfigFile) && GuiCore.IsFileReadOnly(this.m_ToolBarConfigFile))
			{
				flag = true;
			}
			this.nameTextBox.ReadOnly = flag;
			this.basePathTextBox.ReadOnly = flag;
			this.browseButton.Enabled = !flag;
			this.okButton.Enabled = !flag;
		}


		private string m_ToolBarName;


		private string m_ToolBarBasePath;


		private string m_ToolBarConfigFile;
	}
}
