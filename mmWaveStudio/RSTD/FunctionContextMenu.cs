using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	internal class FunctionContextMenu : FolderContextMenu
	{

		public FunctionContextMenu(string fullPath) : base(new string[]
		{
			fullPath
		})
		{
			this.m_RunFunctionMenuItem = new ToolStripMenuItem("Run Function", TreeIcons.func_run);
			this.m_AddToWorkSetMenuItem = new ToolStripMenuItem("Add To WorkSet");
			this.m_SeparatorMenuItem2 = new ToolStripSeparator();
			this.Items.Insert(0, this.m_RunFunctionMenuItem);
			this.Items.Insert(1, this.m_AddToWorkSetMenuItem);
			this.Items.Insert(2, this.m_SeparatorMenuItem2);
			this.m_RunFunctionMenuItem.Click += this.iRunFunctionMenuItem_Click;
			this.m_AddToWorkSetMenuItem.Click += this.iAddToWorkSetMenuItem_Click;
			base.Show(Control.MousePosition);
		}


		~FunctionContextMenu()
		{
			this.Items.Clear();
			this.m_RunFunctionMenuItem = null;
			this.m_AddToWorkSetMenuItem = null;
			this.m_SeparatorMenuItem2 = null;
		}


		private void iRunFunctionMenuItem_Click(object sender, EventArgs e)
		{
			GuiCore.RunFuncByXml(this.m_FullPaths[0]);
		}


		private void iAddToWorkSetMenuItem_Click(object sender, EventArgs e)
		{
			List<XmlNode> list = new List<XmlNode>();
			string[] fullPaths = this.m_FullPaths;
			for (int i = 0; i < fullPaths.Length; i++)
			{
				XmlNode item;
				if (GuiCore.GetNodeFromPath(fullPaths[i], out item))
				{
					list.Add(item);
				}
			}
			GuiCore.WorkSet.AddNodesToWorkSet(list);
		}


		private ToolStripMenuItem m_RunFunctionMenuItem;


		private ToolStripMenuItem m_AddToWorkSetMenuItem;


		private ToolStripSeparator m_SeparatorMenuItem2;
	}
}
