using System;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	internal class FunctionFindContextMenu : FunctionContextMenu
	{

		public FunctionFindContextMenu(string fullPath) : base(fullPath)
		{
			this.m_GotoMenuItem = new ToolStripMenuItem("GoTo");
			this.m_SeparatorMenuItem3 = new ToolStripSeparator();
			this.Items.Insert(0, this.m_GotoMenuItem);
			this.Items.Insert(1, this.m_SeparatorMenuItem3);
			this.m_GotoMenuItem.Click += this.iGotoMenuItem_Click;
			base.Show(Control.MousePosition);
		}


		~FunctionFindContextMenu()
		{
			this.Items.Clear();
			this.m_GotoMenuItem = null;
			this.m_SeparatorMenuItem3 = null;
		}


		private void iGotoMenuItem_Click(object sender, EventArgs e)
		{
			XmlNode node;
			if (GuiCore.GetNodeFromPath(this.m_FullPaths[0], out node))
			{
				GuiCore.bJumpToPath(node);
			}
		}


		private ToolStripMenuItem m_GotoMenuItem;


		private ToolStripSeparator m_SeparatorMenuItem3;
	}
}
