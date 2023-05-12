using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Rstd.Controls.ContainerListViews;

namespace RSTD
{

	internal class TabTreePage : TabPage
	{

		public TabTreePage(XmlNode xmlTab)
		{
			this.m_SplitContainer = new SplitContainer();
			this.m_TreeView = new TreeView();
			this.m_ListView = new ContainerListView();
			this.m_ToolTip = new ToolTip();
			this.m_SplitContainer.Panel1.Controls.Add(this.m_TreeView);
			this.m_SplitContainer.Panel2.Controls.Add(this.m_ListView);
			int num;
			if (GuiCore.bNodeContainsRegisters(xmlTab))
			{
				num = 1;
			}
			else
			{
				num = 2;
			}
			this.m_SplitContainer.SplitterDistance = this.m_SplitContainer.Width / 5 * num;
			base.Controls.Add(this.m_SplitContainer);
			this.m_ToolTip.InitialDelay = 100;
			this.m_TreeView.HideSelection = false;
			this.m_TreeView.Dock = DockStyle.Fill;
			this.m_ListView.Dock = DockStyle.Fill;
			this.m_SplitContainer.Dock = DockStyle.Fill;
			this.m_ListView.AllowMultiSelect = true;
			this.m_ListView.VisualStyles = true;
			this.m_ListView.ShowPlusMinus = true;
			this.m_ListView.ShowRootTreeLines = true;
			this.m_ListView.ShowTreeLines = true;
			this.m_ListView.AllowColumnReorder = true;
			this.m_ListView.AllowColumnResize = true;
			this.m_ListView.AllowMultiSelect = true;
			this.m_ListView.MultipleColumnSort = true;
			this.m_ListView.ColumnSortColor = this.m_ListView.BackColor;
			int num2 = 10;
			this.m_ListView.Columns.Add("Name", num2 * 18, HorizontalAlignment.Left);
			this.m_ListView.Columns.Add("Value", num2 * 12, HorizontalAlignment.Left);
			this.m_ListView.Columns.Add("Address", num2 * 10, HorizontalAlignment.Left);
			this.m_ListView.Columns.Add("Start Bit", num2 * 6, HorizontalAlignment.Left);
			this.m_ListView.Columns.Add("Stop Bit", num2 * 6, HorizontalAlignment.Left);
			this.m_ListView.Columns.Add("Description", num2 * 12, HorizontalAlignment.Left);
			this.iSortColumns();
			if (!GuiCore.bNodeContainsRegisters(xmlTab))
			{
				this.m_ListView.Columns[2].Visible = false;
				this.m_ListView.Columns[3].Visible = false;
				this.m_ListView.Columns[4].Visible = false;
				this.m_ListView.Columns[5].Visible = false;
			}
			this.m_TreeView.MouseClick += this.iTreeView_MouseClick;
			this.m_TreeView.MouseDoubleClick += this.iTreeView_MouseDoubleClick;
			this.m_TreeView.AfterSelect += this.iTreeView_AfterSelect;
			this.m_TreeView.GotFocus += this.m_TreeView_GotFocus;
			this.m_TreeView.ItemDrag += this.iTreeView_ItemDrag;
			this.m_TreeView.KeyPress += this.iTreeView_KeyPress;
			this.m_TreeView.KeyDown += this.TreeView_KeyDown;
			this.m_TreeView.LostFocus += this.iTreeView_LostFocus;
			this.m_ListView.MouseClick += this.iListView_MouseClick;
			this.m_ListView.MouseDoubleClick += GuiCore.ListView_MouseDoubleClick;
			this.m_ListView.ItemDrag += this.iListView_ItemDrag;
			this.m_ListView.MouseMove += this.iListView_MouseMove;
			this.m_ListView.KeyPress += this.iListView_KeyPress;
			this.m_ListView.KeyDown += this.iListView_KeyDown;
			this.m_ListView.LostFocus += this.iListView_LostFocus;
			this.m_ListView.ColumnReordered += this.iListView_ColumnReordered;
			this.m_ToolTip.Popup += this.iToolTip_Popup;
			this.m_ListView.SmallImageList = new ImageList();
			this.m_TreeView.ImageList = new ImageList();
			this.m_ListView.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
			this.m_ListView.SmallImageList.Images.Add(TreeIcons.var_updated);
			this.m_ListView.SmallImageList.Images.Add(TreeIcons.var_not_updated);
			this.m_ListView.SmallImageList.Images.Add(TreeIcons.parameter);
			this.m_ListView.SmallImageList.Images.Add(TreeIcons.clock);
			this.m_ListView.SmallImageList.Images.Add(TreeIcons.var_auto_updated);
			this.m_TreeView.ImageList.ColorDepth = ColorDepth.Depth32Bit;
			this.m_TreeView.ImageList.ImageSize = new Size(24, 24);
			this.m_TreeView.ImageList.TransparentColor = Color.Black;
			this.m_TreeView.ImageList.Images.Add(TreeIcons.folder_close);
			this.m_TreeView.ImageList.Images.Add(TreeIcons.folder_open);
			this.m_TreeView.ImageList.Images.Add(TreeIcons.func_gray);
			this.m_TreeView.ImageList.Images.Add(TreeIcons.func_color);
			this.Text = GuiCore.GetNodeValue(xmlTab.Attributes["name"]);
			this.iPopulateFoldersAndFuncs(xmlTab);
		}


		private void m_TreeView_GotFocus(object sender, EventArgs e)
		{
			if (this.m_ListView.SelectedItems.Count > 0)
			{
				this.m_ListView.SelectedItems.Clear();
				this.m_ListView.Invalidate();
			}
		}


		~TabTreePage()
		{
			this.m_SplitContainer = null;
			this.m_TreeView = null;
			this.m_ListView = null;
		}


		public void RefreshDisplay()
		{
			if (GuiCore.MainForm.bIsRstdClosing)
			{
				return;
			}
			if (this.m_ListView.Items.Count > 0 || (this.m_TreeView.SelectedNode != null && ((XmlNode)this.m_TreeView.SelectedNode.Tag).ChildNodes.Count > 0))
			{
				this.iDrawCurrentFolder();
			}
		}


		private void iPopulateFoldersAndFuncs(XmlNode xmlChild)
		{
			if (xmlChild.HasChildNodes)
			{
				for (int i = 0; i < xmlChild.ChildNodes.Count; i++)
				{
					if (xmlChild.ChildNodes[i].Name.Equals("Folder") || xmlChild.ChildNodes[i].Name.Equals("Function"))
					{
						TreeViewNode treeViewNode = new TreeViewNode(xmlChild.ChildNodes[i]);
						treeViewNode.Tag = xmlChild.ChildNodes[i];
						this.m_TreeView.Nodes.Add(treeViewNode);
					}
				}
			}
		}


		private void iSortColumns()
		{
			this.m_ListView.Columns[0].SortDataType = SortDataType.String;
			this.m_ListView.Columns[1].SortDataType = SortDataType.String;
			this.m_ListView.Columns[2].SortDataType = SortDataType.Integer;
			this.m_ListView.Columns[3].SortDataType = SortDataType.Integer;
			this.m_ListView.Columns[4].SortDataType = SortDataType.Integer;
			this.m_ListView.Columns[5].SortDataType = SortDataType.String;
		}


		public void SortListViewColumns(bool SortState)
		{
			if (!SortState)
			{
				int num = 0;
				while ((long)num < 6L)
				{
					this.m_ListView.Columns[num].SortDataType = SortDataType.None;
					num++;
				}
				return;
			}
			this.iSortColumns();
		}


		public bool bCloumnIsReg(ContainerListViewColumnHeader column)
		{
			return !column.Text.Equals("Name") && !column.Text.Equals("Offset") && !column.Text.Equals("Stride") && !column.Text.Equals("Length") && !column.Text.Equals("Type") && !column.Text.Equals("Value") && !column.Text.Equals("Fixmode") && !column.Text.Equals("Comment");
		}


		private void iTreeView_MouseClick(object sender, MouseEventArgs e)
		{
			this.iClearQuickFind();
			if (e.Button == MouseButtons.Right)
			{
				this.m_TreeView.SelectedNode = this.m_TreeView.GetNodeAt(e.X, e.Y);
				TreeViewNode treeViewNode = (TreeViewNode)this.m_TreeView.SelectedNode;
				if (treeViewNode != null)
				{
					if (treeViewNode.bIsFunction())
					{
						new FunctionContextMenu(this.GetFullTabAndFolderPath()).Show(Control.MousePosition);
						return;
					}
					new FolderContextMenu(new string[]
					{
						this.GetFullTabAndFolderPath()
					});
				}
			}
		}


		private void iTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			TreeViewNode treeViewNode = (TreeViewNode)this.m_TreeView.SelectedNode;
			if (treeViewNode != null && treeViewNode.bIsFunction())
			{
				GuiCore.RunFuncByXml(this.GetFullTabAndFolderPath());
			}
		}


		private void iTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Action != TreeViewAction.Unknown)
			{
				this.iDrawCurrentFolder();
			}
		}


		private void iListView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (e.Button != MouseButtons.Left || this.m_ListView.SelectedItems.Count == 0 || this.m_ListView.ReorderingColumn)
			{
				return;
			}
			PassedVarData passedVarData = new PassedVarData(this.m_ListView.SelectedItems);
			if (passedVarData != null)
			{
				this.m_ListView.DoDragDrop(passedVarData, DragDropEffects.Copy);
			}
		}


		private void iTreeView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			PassedVarData passedVarData = new PassedVarData((TreeNode)e.Item);
			if (passedVarData != null)
			{
				this.m_TreeView.DoDragDrop(passedVarData, DragDropEffects.Copy);
			}
			this.m_TreeView.DoDragDrop(passedVarData, DragDropEffects.Copy);
		}


		private void iTreeView_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.iIncrementalSearchKeyPress(sender, e);
		}


		public void TreeView_KeyDown(object sender, KeyEventArgs e)
		{
			this.iHandleKeyDown(sender, e);
		}


		private void iDoGuiOperationByKeyShortcuts(object sender, RstdConstants.GUI_OPERATION gui_operation)
		{
			List<string> list = new List<string>();
			if (sender == this.m_TreeView)
			{
				if (this.m_TreeView.SelectedNode != null)
				{
					list.Add(this.GetFullTabAndFolderPath());
				}
			}
			else if (sender == this.m_ListView)
			{
				for (int i = 0; i < this.m_ListView.SelectedItems.Count; i++)
				{
					list.Add(GuiCore.GetPathFromNode((XmlNode)this.m_ListView.SelectedItems[i].Tag));
				}
			}
			if (list.Count > 0)
			{
				if (gui_operation == RstdConstants.GUI_OPERATION.RECEIVE)
				{
					GuiCore.Receive(list.ToArray(), ReceiveTransmit_T.XML_PATH, false);
					return;
				}
				if (gui_operation == RstdConstants.GUI_OPERATION.TRANSMIT)
				{
					GuiCore.Transmit(list.ToArray(), ReceiveTransmit_T.XML_PATH, false);
				}
			}
		}


		private void iTreeView_LostFocus(object sender, EventArgs e)
		{
			this.iClearQuickFind();
		}


		private void iListView_MouseClick(object sender, MouseEventArgs e)
		{
			ContainerListView containerListView = (ContainerListView)sender;
			this.iClearQuickFind();
			if (containerListView.SelectedItems.Count == 0)
			{
				return;
			}
			if (MouseButtons.Right == e.Button)
			{
				new VariableContextMenu(new PassedVarData(containerListView.SelectedItems), RstdConstants.CONTEXT_MENU_ORIGIN.BROWSE_TREE);
			}
		}


		private void iListView_LostFocus(object sender, EventArgs e)
		{
			this.iClearQuickFind();
		}


		private void iListView_KeyDown(object sender, KeyEventArgs e)
		{
			this.iHandleKeyDown(sender, e);
		}


		private void iHandleKeyDown(object sender, KeyEventArgs e)
		{
			bool flag = false;
			if (e.KeyCode == Keys.R)
			{
				if (e.Control)
				{
					this.iDoGuiOperationByKeyShortcuts(sender, RstdConstants.GUI_OPERATION.RECEIVE);
					flag = true;
				}
			}
			else if (e.KeyCode == Keys.T && e.Control)
			{
				this.iDoGuiOperationByKeyShortcuts(sender, RstdConstants.GUI_OPERATION.TRANSMIT);
				flag = true;
			}
			if (!flag)
			{
				this.iIncremetalSearchKeyDown(sender, e);
			}
		}


		private void iListView_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.iIncrementalSearchKeyPress(sender, e);
		}


		private void iListView_MouseMove(object sender, MouseEventArgs e)
		{
			GuiCore.DisplayToolTip((ContainerListView)sender, e, this.m_ToolTip);
		}


		private void iListView_ColumnReordered(object sender, ContainerListViewEventArgs e)
		{
			ContainerListView containerListView = (ContainerListView)sender;
			for (int i = 0; i < containerListView.Columns.Count; i++)
			{
				RstdGuiSettings.Default.dBTColumnsOrderArr[i] = containerListView.Columns[i].DisplayIndex;
			}
			GuiCore.MainForm.FrmGuiGettings.CheckListBoxColumnsUpdate();
		}


		private void iToolTip_Popup(object sender, PopupEventArgs e)
		{
			GuiCore.AdjustToolTipSize(sender, e);
		}




		public ContainerListView TVListView
		{
			get
			{
				return this.m_ListView;
			}
			set
			{
				this.m_ListView = value;
			}
		}


		public bool bJumpToPath(string[] splitPath, XmlNode node)
		{
			TreeNodeCollection nodes = this.m_TreeView.Nodes;
			int i = 1;
			NodeType nodeType = GuiCore.GetNodeType(node);
			while (i < splitPath.Length)
			{
				this.m_TreeView.SelectedNode = this.iFindTreeNodeInCollection(splitPath[i], nodes);
				if (this.m_TreeView.SelectedNode == null)
				{
					return false;
				}
				this.iDrawCurrentFolder();
				nodes = this.m_TreeView.SelectedNode.Nodes;
				if (i == splitPath.Length - 2)
				{
					if (nodeType == NodeType.VAR || nodeType == NodeType.MAPPED_VAR || nodeType == NodeType.REGISTER)
					{
						return this.ibJumpToListViewItem(splitPath[i + 1]);
					}
				}
				else if (i == splitPath.Length - 3 && nodeType == NodeType.FIELD)
				{
					return this.ibJumpToRegisterField(splitPath);
				}
				i++;
			}
			if (nodeType == NodeType.FUNCTION || nodeType == NodeType.FOLDER)
			{
				this.m_TreeView.Focus();
				return true;
			}
			return false;
		}


		public string GetFullTabAndFolderPath()
		{
			string text = "\\" + this.Text;
			if (this.m_TreeView.SelectedNode != null)
			{
				text += "\\";
				text += this.m_TreeView.SelectedNode.FullPath;
			}
			return text.Replace('\\', '/');
		}


		private TreeNode iFindTreeNodeInCollection(string searchText, TreeNodeCollection nodeCollection)
		{
			int count = nodeCollection.Count;
			for (int i = 0; i < count; i++)
			{
				if (nodeCollection[i].Text.Equals(searchText))
				{
					return nodeCollection[i];
				}
			}
			return null;
		}


		private void iGetVarListOfFolder(XmlNode xmlFolder)
		{
			if (this.m_ListView.Items.Count > 0 && ((XmlNode)this.m_ListView.Items[0].Tag).ParentNode == xmlFolder)
			{
				GuiCore.UpdateFolderList(this.m_ListView);
				return;
			}
			this.m_ListView.BeginUpdate();
			this.m_ListView.Items.Clear();
			for (int i = 0; i < xmlFolder.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xmlFolder.ChildNodes[i];
				if (xmlNode.Name.Equals("Var") && xmlNode.Attributes["type"].Value.ToUpper() != "THIS")
				{
					ContainerListViewItem item = GuiCore.CreateTreeListNode(xmlNode);
					this.m_ListView.Items.Add(item);
				}
				if (xmlNode.Name.Equals("Register"))
				{
					ContainerListViewItem containerListViewItem = GuiCore.CreateTreeListNode(xmlNode);
					for (int j = 1; j < xmlNode.ChildNodes.Count; j++)
					{
						ContainerListViewItem item2 = GuiCore.CreateTreeListNode(xmlNode.ChildNodes[j]);
						containerListViewItem.Items.Add(item2);
					}
					this.m_ListView.Items.Add(containerListViewItem);
				}
			}
			this.m_ListView.EndUpdate();
		}


		private void iGetVarListOfFunction(XmlNode xmlFunction)
		{
			XmlNode xmlFolder = xmlFunction.SelectSingleNode("ArgumentList");
			this.iGetVarListOfFolder(xmlFolder);
		}


		private void iSetListViewFolder(string path)
		{
			XmlNode xmlNode;
			if (GuiCore.bGetFolder(path, out xmlNode))
			{
				if (xmlNode.Name.Equals("Folder"))
				{
					this.iGetVarListOfFolder(xmlNode);
				}
				else
				{
					if (!xmlNode.Name.Equals("Function"))
					{
						throw new Exception("iSetListViewFolder: wrong path type");
					}
					this.iGetVarListOfFunction(xmlNode);
				}
				if (this.m_ListView.SortColumns.Length != 0)
				{
					this.m_ListView.Sort(true);
				}
				if (GuiCore.AutoSizeColumns)
				{
					this.m_ListView.AutoSizeColumnWidths(true);
				}
			}
		}


		private void iDrawCurrentFolder()
		{
			if (this.m_TreeView.SelectedNode != null)
			{
				this.iSetListViewFolder(this.GetFullTabAndFolderPath());
			}
		}


		private bool ibJumpToListViewItem(string itemName)
		{
			for (int i = 0; i < this.m_ListView.Items.Count; i++)
			{
				if (this.m_ListView.Items[i].Text.Equals(itemName))
				{
					this.m_ListView.SelectAndShowSingleItem(this.m_ListView.Items[i]);
					this.m_ListView.Select();
					return true;
				}
			}
			return false;
		}


		private bool ibJumpToRegisterField(string[] splitPath)
		{
			for (int i = 0; i < this.m_ListView.Items.Count; i++)
			{
				if (this.m_ListView.Items[i].Text.Equals(splitPath[splitPath.Length - 2]))
				{
					for (int j = 0; j < this.m_ListView.Items[i].Items.Count; j++)
					{
						if (this.m_ListView.Items[i].Items[j].Text.Equals(splitPath[splitPath.Length - 1]))
						{
							this.m_ListView.SelectAndShowSingleItem(this.m_ListView.Items[i].Items[j]);
							this.m_ListView.Select();
							return true;
						}
					}
				}
			}
			return false;
		}


		private bool ibIsNodeRegisterField(ContainerListViewItem sel_node)
		{
			XmlNode xmlNode = (XmlNode)sel_node.Tag;
			return xmlNode != null && xmlNode.ParentNode.Name == "Register";
		}


		private void iClearQuickFind()
		{
			if (base.Parent != null)
			{
				((BrowseTree)base.Parent.Parent).lblQuickFind.Text = "";
			}
		}


		private bool iTreeQuickFind(string search_str, bool find_next)
		{
			if (this.m_TreeView.Nodes.Count == 0)
			{
				return false;
			}
			TreeViewNode treeViewNode = (TreeViewNode)this.m_TreeView.SelectedNode;
			TreeViewNode end_item = this.iGetLastTreeNode();
			TreeViewNode treeViewNode2 = (TreeViewNode)this.m_TreeView.Nodes[0];
			if (treeViewNode == null)
			{
				treeViewNode = treeViewNode2;
			}
			else if (find_next)
			{
				treeViewNode = this.iGetNextTreeNode(treeViewNode);
			}
			if (treeViewNode == null)
			{
				treeViewNode = treeViewNode2;
			}
			if (!this.iQuickFind(search_str, treeViewNode, end_item))
			{
				this.iQuickFind(search_str, treeViewNode2, treeViewNode);
			}
			return false;
		}


		private bool iQuickFind(string search_str, TreeViewNode start_item, TreeViewNode end_item)
		{
			TreeViewNode treeViewNode = start_item;
			search_str = search_str.Replace("_", "").ToLower();
			while (treeViewNode != this.iGetNextTreeNode(end_item) && treeViewNode != null)
			{
				if (treeViewNode.Text.Replace("_", "").ToLower().Contains(search_str))
				{
					this.m_TreeView.SelectedNode = treeViewNode;
					return true;
				}
				treeViewNode = this.iGetNextTreeNode(treeViewNode);
			}
			return false;
		}


		private TreeViewNode iGetLastTreeNode()
		{
			TreeViewNode treeViewNode = (TreeViewNode)this.m_TreeView.Nodes[this.m_TreeView.Nodes.Count - 1];
			while (treeViewNode.Nodes.Count > 0)
			{
				treeViewNode = (TreeViewNode)treeViewNode.Nodes[treeViewNode.Nodes.Count - 1];
			}
			return treeViewNode;
		}


		private TreeViewNode iGetNextTreeNode(TreeViewNode node)
		{
			if (node.FirstNode != null)
			{
				return (TreeViewNode)node.FirstNode;
			}
			if (node.NextNode == null && node.Parent != null)
			{
				return (TreeViewNode)node.Parent.NextNode;
			}
			return (TreeViewNode)node.NextNode;
		}


		private void iIncrementalSearchKeyPress(object sender, KeyPressEventArgs e)
		{
			ToolStripStatusLabel lblQuickFind = ((BrowseTree)base.Parent.Parent).lblQuickFind;
			if (e.KeyChar == '\b')
			{
				if (lblQuickFind.Text.Length > 0)
				{
					lblQuickFind.Text = lblQuickFind.Text.Remove(lblQuickFind.Text.Length - 1, 1);
				}
			}
			else if (e.KeyChar > '\u001f' && e.KeyChar < '\u007f')
			{
				ToolStripStatusLabel toolStripStatusLabel = lblQuickFind;
				toolStripStatusLabel.Text += e.KeyChar.ToString();
				if (sender == this.m_TreeView)
				{
					this.iTreeQuickFind(lblQuickFind.Text, false);
					e.Handled = true;
				}
				else if (sender == this.m_ListView)
				{
					this.m_ListView.QuickFind(lblQuickFind.Text, false);
				}
			}
			base.OnKeyPress(e);
		}


		private void iIncremetalSearchKeyDown(object sender, KeyEventArgs e)
		{
			ToolStripStatusLabel lblQuickFind = ((BrowseTree)base.Parent.Parent).lblQuickFind;
			Keys keyCode = e.KeyCode;
			if (keyCode - Keys.Left > 3 && keyCode != Keys.Delete)
			{
				if (keyCode == Keys.F3)
				{
					if (sender == this.m_TreeView)
					{
						this.iTreeQuickFind(lblQuickFind.Text, true);
					}
					else if (sender == this.m_ListView)
					{
						this.m_ListView.QuickFind(lblQuickFind.Text, true);
					}
				}
			}
			else
			{
				lblQuickFind.Text = "";
			}
			base.OnKeyDown(e);
		}


		private SplitContainer m_SplitContainer;


		private TreeView m_TreeView;


		private ContainerListView m_ListView;


		private ToolTip m_ToolTip;
	}
}
