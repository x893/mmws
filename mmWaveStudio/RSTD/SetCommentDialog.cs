using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	public partial class SetCommentDialog : Form
	{

		public SetCommentDialog()
		{
		}


		public SetCommentDialog(List<XmlNode> nodes)
		{
			this.InitializeComponent();
			this.m_XmlNodes = nodes;
		}


		private void m_OkBtn_Click(object sender, EventArgs e)
		{
			foreach (XmlNode xmlNode in this.m_XmlNodes)
			{
				xmlNode.Attributes["comment"].Value = this.m_txtSetComment.Text;
			}
			base.DialogResult = DialogResult.OK;
		}


		private void m_CancelBtn_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}


		private void SetCommentDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.DialogResult = DialogResult.Cancel;
			}
		}


		private void SetCommentDialog_Load(object sender, EventArgs e)
		{
			if (this.m_XmlNodes.Count == 1)
			{
				this.m_txtSetComment.Text = this.m_XmlNodes[0].Attributes["comment"].Value;
			}
		}


		protected List<XmlNode> m_XmlNodes;
	}
}
