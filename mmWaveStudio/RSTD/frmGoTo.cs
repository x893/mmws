using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RSTD
{

	public partial class frmGoTo : Form
	{



		public string Path
		{
			get
			{
				return this.m_Path;
			}
			set
			{
				this.m_Path = value;
			}
		}


		public frmGoTo()
		{
			this.InitializeComponent();
			this.m_txtPath.Text = "";
			this.m_Path = "";
		}


		private void btnOK_Click(object sender, EventArgs e)
		{
			this.iOK();
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}


		private void m_txtPath_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.iOK();
				return;
			}
			if (e.KeyCode == Keys.Escape)
			{
				base.DialogResult = DialogResult.Cancel;
			}
		}


		private void iOK()
		{
			this.m_Path = this.m_txtPath.Text;
			base.DialogResult = DialogResult.OK;
		}


		protected override bool ProcessDialogKey(Keys key)
		{
			if (key == Keys.Tab)
			{
				this.iHandleTabKey();
				return true;
			}
			base.ProcessDialogKey(key);
			return false;
		}


		private void iHandleTabKey()
		{
			int num = 0;
			string text = this.m_txtPath.Text;
			if (string.IsNullOrEmpty(text))
			{
				text = (this.m_txtPath.Text = "/");
			}
			string path;
			string son_cand;
			if (this.ibVerificateComplete(text, out path, out son_cand, out num))
			{
				List<string> nodesSons = LuaWrapperUtils.LuaWrapper.GetNodesSons(path);
				if (nodesSons == null)
				{
					return;
				}
				if (this.iGetNextSon(nodesSons, son_cand))
				{
					this.m_txtPath.SelectionStart = num + 1;
					this.m_txtPath.SelectionLength = this.m_LastSonLength;
					this.m_txtPath.SelectedText = string.Empty;
					this.m_LastSonLength = this.m_RelevantSonName.Length;
					this.m_txtPath.SelectedText = this.m_RelevantSonName;
					this.m_txtPath.SelectionStart = num + 1 + this.m_RelevantSonName.Length;
				}
			}
		}


		private bool ibGetCommandBorders(string current_line, out string command)
		{
			int num = 0;
			int num2;
			if (!this.m_txtPath.Text.StartsWith("/"))
			{
				num2 = current_line.Length;
				command = "";
				return false;
			}
			if (this.m_txtPath.SelectionStart < num)
			{
				num2 = current_line.Length;
				command = "";
				return false;
			}
			num2 = current_line.LastIndexOf('/');
			command = current_line.Substring(num, num2 + 1 - num);
			return true;
		}


		private bool ibVerificateComplete(string current_line, out string path, out string son_cand, out int current_line_until_candidate)
		{
			string text;
			if (this.ibGetCommandBorders(current_line, out text))
			{
				int num = text.IndexOf("/");
				int num2 = text.LastIndexOf("/");
				current_line_until_candidate = current_line.LastIndexOf("/");
				if (num < num2)
				{
					path = text.Substring(num, num2 - num);
				}
				else
				{
					path = "/";
				}
				if (current_line.Length == num2 + 1)
				{
					son_cand = "";
				}
				else
				{
					son_cand = current_line.Substring(current_line_until_candidate + 1, current_line.Length - (current_line_until_candidate + 1));
				}
				return true;
			}
			path = "";
			son_cand = "";
			current_line_until_candidate = this.m_txtPath.SelectionStart;
			return false;
		}


		private bool iGetNextSon(List<string> list_of_sons, string son_cand)
		{
			if (string.IsNullOrEmpty(son_cand))
			{
				this.m_RelevantSonName = list_of_sons[0];
				return true;
			}
			int i = 0;
			while (i < list_of_sons.Count)
			{
				if (son_cand.Equals(list_of_sons[i]))
				{
					if (i + 1 == list_of_sons.Count)
					{
						this.m_RelevantSonName = list_of_sons[0];
						return true;
					}
					this.m_RelevantSonName = list_of_sons[i + 1];
					return true;
				}
				else
				{
					if (list_of_sons[i].StartsWith(son_cand))
					{
						this.m_RelevantSonName = list_of_sons[i];
						return true;
					}
					i++;
				}
			}
			this.m_RelevantSonName = son_cand;
			return false;
		}


		private string m_Path;


		private int m_LastSonLength;


		private string m_RelevantSonName;
	}
}
