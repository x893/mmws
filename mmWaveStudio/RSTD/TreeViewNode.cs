using System;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	internal class TreeViewNode : TreeNode
	{

		public TreeViewNode(XmlNode xmlNode)
		{
			base.Text = GuiCore.GetNodeValue(xmlNode.Attributes["name"]);
			if (xmlNode.Name.Equals("Function"))
			{
				this.m_bIsFunction = true;
			}
			else
			{
				if (!xmlNode.Name.Equals("Folder"))
				{
					throw new Exception(string.Format("TreeViewNode constructor: illegal node type {0}", xmlNode.Name));
				}
				this.m_bIsFunction = false;
			}
			if (xmlNode.HasChildNodes)
			{
				for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
				{
					if (xmlNode.ChildNodes[i].Name.Equals("Folder") || xmlNode.ChildNodes[i].Name.Equals("Function"))
					{
						TreeViewNode treeViewNode = new TreeViewNode(xmlNode.ChildNodes[i]);
						treeViewNode.Tag = xmlNode.ChildNodes[i];
						base.Nodes.Add(treeViewNode);
					}
				}
			}
			if (this.m_bIsFunction)
			{
				base.ImageIndex = 2;
				base.SelectedImageIndex = 3;
				return;
			}
			base.ImageIndex = 0;
			base.SelectedImageIndex = 1;
		}


		public bool bIsFunction()
		{
			return this.m_bIsFunction;
		}


		private bool m_bIsFunction;
	}
}
