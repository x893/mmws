using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Rstd.Controls.ContainerListViews;

namespace RSTD
{

	internal class PassedVarData
	{

		public PassedVarData(ListView.SelectedListViewItemCollection selItems)
		{
			this.m_xmlNodes = new List<XmlNode>();
			for (int i = 0; i < selItems.Count; i++)
			{
				XmlNode xmlNode = (XmlNode)selItems[i].Tag;
				if (xmlNode != null)
				{
					this.m_xmlNodes.Add(xmlNode);
				}
			}
		}


		public PassedVarData(ContainerListViewSelectedItemCollection selItems)
		{
			this.m_xmlNodes = new List<XmlNode>();
			for (int i = 0; i < selItems.Count; i++)
			{
				XmlNode xmlNode = (XmlNode)selItems[i].Tag;
				if (xmlNode != null)
				{
					this.m_xmlNodes.Add(xmlNode);
				}
			}
		}


		public PassedVarData(TreeNode selItem)
		{
			this.m_xmlNodes = new List<XmlNode>();
			this.m_xmlNodes.Add((XmlNode)selItem.Tag);
		}



		public List<XmlNode> XmlNodes
		{
			get
			{
				return this.m_xmlNodes;
			}
		}


		public bool ValidSubset()
		{
			foreach (XmlNode node in this.m_xmlNodes)
			{
				if (GuiCore.GetNodeType(node) != NodeType.REGISTER && GuiCore.GetNodeType(node) != NodeType.FIELD)
				{
					return false;
				}
			}
			return true;
		}


		private List<XmlNode> m_xmlNodes;
	}
}
