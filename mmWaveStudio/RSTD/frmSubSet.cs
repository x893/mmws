using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using LuaInterface;
using Rstd.Controls.ContainerListViews;
using WeifenLuo.WinFormsUI.Docking;

namespace RSTD
{

	public partial class frmSubSet : DockContent
	{

		public frmSubSet()
		{
			this.InitializeComponent();
			this.iAddListView();
			this.iCleanSubXml();
			this.m_Dirty = false;
			this.m_SubVersion = "";
			this.m_SrcVersion = "";
			this.m_txtSubVersion.Text = this.m_SubVersion;
		}




		public ContainerListView VarListView
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




		public bool Dirty
		{
			get
			{
				return this.m_Dirty;
			}
			set
			{
				this.m_Dirty = value;
			}
		}




		public string SrcVersion
		{
			get
			{
				return this.m_SubVersion;
			}
			set
			{
				this.m_SubVersion = value;
			}
		}


		private void m_ListView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			GuiCore.UpdateListView(sender, e, this);
			this.m_Dirty = true;
			this.iUpdateTitle();
		}


		private void m_ListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.m_ListView.SelectedItems.Count == 0)
			{
				return;
			}
			if (e.KeyCode == Keys.Delete)
			{
				for (int i = 0; i < this.m_ListView.SelectedItems.Count; i++)
				{
					this.m_ListView.SelectedItems[i].ParentItem.Items.Remove(this.m_ListView.SelectedItems[i]);
					i--;
				}
				this.m_Dirty = true;
				this.iUpdateTitle();
				return;
			}
			this.iHandleKeyDown(sender, e);
		}


		private void iHandleKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.R)
			{
				if (e.Control)
				{
					this.iDoGuiOperationByKeyShortcuts(sender, RstdConstants.GUI_OPERATION.RECEIVE);
					return;
				}
			}
			else if (e.KeyCode == Keys.T && e.Control)
			{
				this.iDoGuiOperationByKeyShortcuts(sender, RstdConstants.GUI_OPERATION.TRANSMIT);
			}
		}


		private void iDoGuiOperationByKeyShortcuts(object sender, RstdConstants.GUI_OPERATION gui_operation)
		{
			List<string> list = new List<string>();
			if (sender is ContainerListView)
			{
				for (int i = 0; i < ((ContainerListView)sender).SelectedItems.Count; i++)
				{
					list.Add(GuiCore.GetPathFromNode((XmlNode)((ContainerListView)sender).SelectedItems[i].Tag));
				}
			}
			if (list.Count > 0)
			{
				if (gui_operation == RstdConstants.GUI_OPERATION.RECEIVE)
				{
					GuiCore.Receive(list.ToArray(), ReceiveTransmit_T.XML_PATH, false);
				}
				else if (gui_operation == RstdConstants.GUI_OPERATION.TRANSMIT)
				{
					GuiCore.Transmit(list.ToArray(), ReceiveTransmit_T.XML_PATH, false);
				}
			}
			this.m_Dirty = false;
			this.iUpdateTitle();
		}


		public void ListView_MouseClick(object sender, MouseEventArgs e)
		{
			ContainerListView containerListView = (ContainerListView)sender;
			if (containerListView.SelectedItems.Count == 0)
			{
				return;
			}
			if (MouseButtons.Right == e.Button)
			{
				new VariableFormsContextMenu(new PassedVarData(containerListView.SelectedItems), this);
			}
		}


		private void m_ListView_MouseMove(object sender, MouseEventArgs e)
		{
			GuiCore.DisplayToolTip((ContainerListView)sender, e, this.m_ToolTip);
		}


		private void m_ToolTip_Popup(object sender, PopupEventArgs e)
		{
			GuiCore.AdjustToolTipSize(sender, e);
		}


		private void frmSubSet_DragOver(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(typeof(PassedVarData)))
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			if (((PassedVarData)e.Data.GetData(typeof(PassedVarData))).ValidSubset())
			{
				e.Effect = DragDropEffects.Copy;
				return;
			}
			e.Effect = DragDropEffects.None;
		}


		private void frmSubSet_DragDrop(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(typeof(PassedVarData)))
			{
				return;
			}
			PassedVarData passedVarData = (PassedVarData)e.Data.GetData(typeof(PassedVarData));
			this.AddNodesToSubSet(passedVarData.XmlNodes);
			this.m_Dirty = true;
			this.iUpdateTitle();
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


		private void btnClear_Click(object sender, EventArgs e)
		{
			this.ClearSubSet();
			this.m_Dirty = true;
			this.iUpdateTitle();
		}


		private void btnSave_Click(object sender, EventArgs e)
		{
			this.SaveAllSubSet();
		}


		private void btnLoad_Click(object sender, EventArgs e)
		{
			string text = GuiCore.OpenFileDialog(null, FileType.CSV);
			if (!string.IsNullOrEmpty(text))
			{
				this.LoadSubSet(text);
			}
		}


		private void btnLoadLast_Click(object sender, EventArgs e)
		{
			this.iLoadSubSet(RstdGuiSettings.Default.LastSubSetFile);
		}


		private void m_TransmitSplitBtnWS_ButtonClick(object sender, EventArgs e)
		{
			this.TransmitSubSet(true);
		}


		private void selectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.TransmitSubSet(false);
		}


		private void m_ReceiveSplitBtnWS_ButtonClick(object sender, EventArgs e)
		{
			this.ReceiveSubSet(true);
		}


		private void selectionToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.ReceiveSubSet(false);
		}


		private void m_ListView_ColumnReordered(object sender, ContainerListViewEventArgs e)
		{
			ContainerListView containerListView = (ContainerListView)sender;
			for (int i = 0; i < containerListView.Columns.Count; i++)
			{
				RstdGuiSettings.Default.dWSColumnsOrderArr[i] = containerListView.Columns[i].DisplayIndex;
			}
			GuiCore.MainForm.FrmGuiGettings.CheckListBoxColumnsUpdate();
		}


		private void itsmi_selection_Click(object sender, EventArgs e)
		{
			ContainerListViewSelectedItemCollection selectedItems = this.m_ListView.SelectedItems;
			PassedVarData passedVarData = new PassedVarData(this.m_ListView.SelectedItems);
			this.iSave(passedVarData.XmlNodes);
		}


		private void itsmi_all_Click(object sender, EventArgs e)
		{
			this.SaveAllSubSet();
		}


		private void m_btnSave_DropDownOpened(object sender, EventArgs e)
		{
			this.m_tsmi_selection.Enabled = (this.m_ListView.Items.Count != 0);
		}


		private void m_txtSrcVersion_DoubleClick(object sender, EventArgs e)
		{
			this.m_txtSubVersion.BackColor = SystemColors.ControlLightLight;
			this.m_txtSubVersion.ReadOnly = false;
		}


		private void m_txtSrcVersion_LostFocus(object sender, EventArgs e)
		{
			if (!this.m_txtSubVersion.ReadOnly)
			{
				this.m_txtSubVersion.BackColor = SystemColors.Control;
				this.m_txtSubVersion.ReadOnly = true;
				this.m_SubVersion = this.m_txtSubVersion.Text;
			}
		}


		private void frmSubSet_FormClosing(object sender, FormClosingEventArgs e)
		{
			GuiCore.MainForm.CloseSubset(this);
		}


		private List<XmlNode> iCreateRxTxListSelected()
		{
			List<XmlNode> list = new List<XmlNode>();
			for (int i = 0; i < this.m_ListView.SelectedItems.Count; i++)
			{
				list.Add((XmlNode)this.m_ListView.SelectedItems[i].Tag);
			}
			return list;
		}


		private List<XmlNode> iCreateListRxTxListAll()
		{
			List<XmlNode> list = new List<XmlNode>();
			for (int i = 0; i < this.m_ListView.Items.Count; i++)
			{
				list.Add((XmlNode)this.m_ListView.Items[i].Tag);
			}
			return list;
		}


		public void ReceiveSubSet(bool b_all)
		{
			this.iAscertainClientBuilt();
			List<XmlNode> nodes;
			if (b_all)
			{
				nodes = this.iCreateListRxTxListAll();
			}
			else
			{
				nodes = this.iCreateRxTxListSelected();
			}
			GuiCore.Receive(nodes, ReceiveTransmit_T.XML_PATH, false);
			this.m_Dirty = true;
			this.iUpdateTitle();
		}


		public void TransmitSubSet(bool b_all)
		{
			this.iAscertainClientBuilt();
			List<XmlNode> nodes;
			if (b_all)
			{
				nodes = this.iCreateListRxTxListAll();
			}
			else
			{
				nodes = this.iCreateRxTxListSelected();
			}
			GuiCore.Transmit(nodes, ReceiveTransmit_T.XML_PATH, false);
			this.m_Dirty = true;
			this.iUpdateTitle();
		}


		private void iAscertainClientBuilt()
		{
		}


		private void iCleanSubXml()
		{
			this.m_SubXml = null;
			this.m_SubXml = new XmlDocument();
			XmlElement newChild = this.m_SubXml.CreateElement("TreeRoot");
			this.m_SubXml.AppendChild(newChild);
		}


		private void iAddListView()
		{
			base.SuspendLayout();
			this.m_ListView = new ContainerListView();
			this.m_ToolTip = new ToolTip();
			this.m_ToolTip.InitialDelay = 100;
			this.iSetListViewProperties(ref this.m_ListView);
			this.AllowDrop = true;
			base.DragOver += this.frmSubSet_DragOver;
			base.DragDrop += this.frmSubSet_DragDrop;
			this.m_ListView.KeyDown += this.m_ListView_KeyDown;
			this.m_ListView.MouseMove += this.m_ListView_MouseMove;
			this.m_ListView.ColumnReordered += this.m_ListView_ColumnReordered;
			this.m_ListView.ItemDrag += this.iListView_ItemDrag;
			this.m_ToolTip.Popup += this.m_ToolTip_Popup;
			this.m_txtSubVersion.LostFocus += this.m_txtSrcVersion_LostFocus;
			this.grpRegisters.Controls.Add(this.m_ListView);
			base.ResumeLayout(true);
		}


		private void iSetListViewProperties(ref ContainerListView list_view)
		{
			list_view.Dock = DockStyle.Fill;
			list_view.AllowMultiSelect = true;
			list_view.VisualStyles = true;
			list_view.ShowPlusMinus = true;
			list_view.ShowRootTreeLines = true;
			list_view.ShowTreeLines = true;
			list_view.AllowColumnReorder = true;
			list_view.AllowColumnResize = true;
			list_view.AllowMultiSelect = true;
			list_view.MultipleColumnSort = true;
			list_view.ColumnSortColor = list_view.BackColor;
			list_view.AutoSizeColumnWidths(true);
			int num = 20;
			list_view.Columns.Add("Name", num * 18, HorizontalAlignment.Left);
			list_view.Columns.Add("Value", num * 6, HorizontalAlignment.Left);
			list_view.Columns.Add("Address", num * 10, HorizontalAlignment.Left);
			list_view.Columns.Add("Start Bit", num * 6, HorizontalAlignment.Left);
			list_view.Columns.Add("Stop Bit", num * 6, HorizontalAlignment.Left);
			list_view.Columns.Add("Description", num * 12, HorizontalAlignment.Left);
			this.iSortColumns(ref list_view);
			list_view.SmallImageList = new ImageList();
			list_view.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
			list_view.SmallImageList.Images.Add(TreeIcons.var_updated);
			list_view.SmallImageList.Images.Add(TreeIcons.var_not_updated);
			list_view.SmallImageList.Images.Add(TreeIcons.parameter);
			list_view.SmallImageList.Images.Add(TreeIcons.clock);
			list_view.SmallImageList.Images.Add(TreeIcons.var_auto_updated);
			list_view.MouseClick += this.ListView_MouseClick;
			list_view.MouseDoubleClick += this.m_ListView_MouseDoubleClick;
		}


		private void iSortColumns(ref ContainerListView list_view)
		{
			list_view.Columns[0].SortDataType = SortDataType.String;
			list_view.Columns[1].SortDataType = SortDataType.String;
			list_view.Columns[2].SortDataType = SortDataType.String;
			list_view.Columns[3].SortDataType = SortDataType.Integer;
			list_view.Columns[4].SortDataType = SortDataType.Integer;
			list_view.Columns[5].SortDataType = SortDataType.String;
		}


		private bool ibIsNodeInListView(XmlNode node)
		{
			NodeType nodeType = GuiCore.GetNodeType(node);
			if (nodeType == NodeType.REGISTER || nodeType - NodeType.VAR <= 2)
			{
				foreach (object obj in ((IEnumerable)this.m_ListView.Items))
				{
					ContainerListViewItem containerListViewItem = (ContainerListViewItem)obj;
					XmlNode xmlNode = (XmlNode)containerListViewItem.Tag;
					string pathFromNode = GuiCore.GetPathFromNode(node);
					if (GuiCore.GetPathFromNode((XmlNode)containerListViewItem.Tag) == pathFromNode)
					{
						this.iCopyNodeAttribs(node, (XmlNode)containerListViewItem.Tag);
						this.RefreshDisplay();
						return true;
					}
				}
				return false;
			}
			return false;
		}


		private void iCopyNodeAttribs(XmlNode source, XmlNode target)
		{
			string nodeValue = GuiCore.GetNodeValue(source);
			GuiCore.ChangeVarsValue(target, nodeValue);
			target.Attributes["comment"].Value = source.Attributes["comment"].Value;
		}


		private bool ibReadCSV(string fileName)
		{
			List<XmlNode> list = new List<XmlNode>();
			string text = "";
			bool result;
			try
			{
				using (TextReader textReader = new StreamReader(fileName))
				{
					string text2 = textReader.ReadLine();
					string[] array = text2.Split(new char[]
					{
						','
					});
					if (array[0].Trim().ToUpper().Equals("VERSION") && array.Length >= 2)
					{
						this.m_SubVersion = array[1];
						this.m_txtSubVersion.Text = this.m_SubVersion;
					}
					text2 = textReader.ReadLine();
					array = text2.Split(new char[]
					{
						','
					});
					if (array[0].Trim().ToUpper().Equals("SOURCE VERSION"))
					{
						if (array.Length >= 2)
						{
							this.m_SrcVersion = array[1].Trim();
						}
						if (!this.m_SrcVersion.Equals(GuiCore.MainForm.browse_tree.Version))
						{
							GuiCore.WarningMsgBox(string.Format("Subset version does not match the current loaded XML version:\nFile '{0}' contains version {1}\nBrowse Tree contains version {2}", fileName, this.m_SrcVersion, GuiCore.MainForm.browse_tree.Version));
						}
						this.m_SrcVersion = GuiCore.MainForm.browse_tree.Version;
					}
					while (!text2.Contains("register name"))
					{
						text2 = textReader.ReadLine();
					}
					array = text2.Split(new char[]
					{
						','
					});
					if (array.Length <= 9 || !array[9].Trim().Equals("type"))
					{
						textReader.Close();
						GuiCore.ErrorMessage("Failed to load file. Invalid csv format.\n");
						GuiCore.RefreshGui();
						result = false;
					}
					else
					{
						while ((text2 = textReader.ReadLine()) != null)
						{
							array = text2.Split(new char[]
							{
								','
							});
							if (array.Length >= 9)
							{
								string text3 = array[9];
								if (text3.Trim() == "R" || text3.Trim() == "SF")
								{
									XmlNode src_node;
									if (GuiCore.GetNodeFromPath(array[7], out src_node, false))
									{
										XmlNode xmlNode = null;
										this.iAddNodeToSubXml(src_node, out xmlNode);
										GuiCore.bSetVarValue(xmlNode, array[5]);
										list.Add(xmlNode);
									}
									else
									{
										text = text + array[0] + "\n";
									}
								}
							}
						}
						textReader.Close();
						this.AddNodesToSubSet(list);
						if (text != "")
						{
							GuiCore.ErrorMessage(string.Format("Failed to load the following registers since they don't exist in the source tree:\n{0}", text));
							GuiCore.RefreshGui();
							result = false;
						}
						else
						{
							GuiCore.ValidateRegisterValues_Rec(this.m_SubXml.DocumentElement, ref text);
							if (text != "")
							{
								GuiCore.ErrorMessage(string.Format("Load failed.\nValues of the following registers don't match their fields:\n{0}", text));
								GuiCore.RefreshGui();
								result = false;
							}
							else
							{
								result = true;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				GuiCore.ErrorMessage(string.Format("Load failed.\n{0}\n", ex.Message));
				GuiCore.RefreshGui();
				result = false;
			}
			return result;
		}


		private bool iLoadSubSet(string fileName)
		{
			if (!GuiCore.IsClientBuilt)
			{
				GuiCore.ErrorMessage("Client must be built before a subset can be loaded.");
				return false;
			}
			if (string.IsNullOrEmpty(fileName))
			{
				return false;
			}
			this.ClearSubSet();
			try
			{
				if (!this.ibReadCSV(fileName))
				{
					return false;
				}
			}
			catch (FileNotFoundException ex)
			{
				GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, ex.Message);
				return false;
			}
			RstdGuiSettings.Default.LastSubSetFile = fileName;
			RstdGuiSettings.Default.Save();
			base.Name = fileName;
			this.Text = Path.GetFileName(fileName);
			this.m_Dirty = false;
			this.iUpdateTitle();
			return true;
		}


		private void iRecursiveLoadItems(XmlNode node)
		{
			foreach (object obj in node.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				NodeType nodeType = GuiCore.GetNodeType(xmlNode);
				if (nodeType != NodeType.FUNCTION)
				{
					if (nodeType != NodeType.REGISTER)
					{
						switch (nodeType)
						{
						case NodeType.VAR:
						case NodeType.FIELD:
							this.iAddSubXmlNode(xmlNode);
							break;
						case NodeType.MAPPED_VAR:
							GuiCore.ErrorMessage("Node of type Mapped_var is not supported anymore.\n");
							break;
						default:
							this.iRecursiveLoadItems(xmlNode);
							break;
						}
					}
					else if (xmlNode.FirstChild.Value == null)
					{
						this.iRecursiveLoadItems(xmlNode);
					}
					else if (this.iAddSubXmlNode(xmlNode))
					{
						GuiCore.bCalcFieldsFromRegister(xmlNode);
					}
				}
			}
		}


		private bool iAddSubXmlNode(XmlNode loaded_node)
		{
			XmlNode xmlNode;
			if (GuiCore.GetNodeFromPath(GuiCore.GetPathFromNode(loaded_node), out xmlNode))
			{
				this.FixLoadedNodeForDisplay(loaded_node);
				this.AddNodeToSubSet(loaded_node);
				return true;
			}
			return false;
		}


		private void iSave(List<XmlNode> node_list)
		{
			string text = null;
			if (GuiCore.SaveDialogTxtOrXml(node_list, out text, true, this.m_SubVersion, this.m_SrcVersion) && Path.GetExtension(text).Equals(".csv"))
			{
				RstdGuiSettings.Default.LastSubSetFile = text;
				RstdGuiSettings.Default.Save();
				base.Name = text;
				this.Text = Path.GetFileName(text);
			}
		}


		private void iUpdateTitle()
		{
			string str;
			if (this.m_Dirty)
			{
				str = "*";
			}
			else
			{
				str = "";
			}
			this.Text = Path.GetFileName(base.Name) + str;
		}


		public List<XmlNode> FillNodesList()
		{
			List<XmlNode> list = new List<XmlNode>();
			foreach (object obj in ((IEnumerable)this.m_ListView.Items))
			{
				ContainerListViewItem containerListViewItem = (ContainerListViewItem)obj;
				list.Add((XmlNode)containerListViewItem.Tag);
			}
			return list;
		}


		public bool LoadSubSet(string file_name)
		{
			return this.iLoadSubSet(file_name);
		}


		public void RemoveFromSubSet(string path)
		{
			this.m_ListView.BeginUpdate();
			foreach (object obj in ((IEnumerable)this.m_ListView.Items))
			{
				ContainerListViewItem containerListViewItem = (ContainerListViewItem)obj;
				string pathFromNode = GuiCore.GetPathFromNode((XmlNode)containerListViewItem.Tag);
				if (path == pathFromNode)
				{
					this.m_ListView.Items.Remove(containerListViewItem);
					break;
				}
			}
			this.m_ListView.EndUpdate();
		}


		public void SortListViewColumns(bool sort_state)
		{
			if (!sort_state)
			{
				int num = 0;
				while ((long)num < 6L)
				{
					this.m_ListView.Columns[num].SortDataType = SortDataType.None;
					num++;
				}
				return;
			}
			this.iSortColumns(ref this.m_ListView);
		}


		public void AddNodeToSubSet(XmlNode node)
		{
			this.AddNodesToSubSet(new List<XmlNode>
			{
				node
			});
		}


		private void iAddNodeToSubXml(XmlNode src_node, out XmlNode dst_node)
		{
			List<XmlNode> list = this.iGetParentsNodes(src_node);
			XmlNode documentElement = this.m_SubXml.DocumentElement;
			for (int i = 0; i < list.Count; i++)
			{
				XmlNode xmlNode = list[i];
				if (!this.ibGetSameChild(xmlNode, ref documentElement))
				{
					this.iInsertSrcNodeToSubXml(xmlNode, ref documentElement);
				}
			}
			dst_node = documentElement;
		}


		private void iInsertSrcNodeToSubXml(XmlNode src_ref, ref XmlNode dst_ref)
		{
			XmlNode refChild = null;
			bool deep = false;
			NodeType nodeType = GuiCore.GetNodeType(src_ref);
			if (nodeType == NodeType.FIELD)
			{
				return;
			}
			if (nodeType == NodeType.REGISTER)
			{
				deep = true;
			}
			XmlNode xmlNode = this.m_SubXml.ImportNode(src_ref, deep);
			if (src_ref.NextSibling != null && this.ibGetSameNode(src_ref.NextSibling, out refChild))
			{
				dst_ref.InsertBefore(xmlNode, refChild);
			}
			else
			{
				dst_ref.AppendChild(xmlNode);
			}
			dst_ref = xmlNode;
		}


		private bool ibGetSameNode(XmlNode src_node, out XmlNode dst_node)
		{
			return GuiCore.GetNodeFromPath(GuiCore.GetPathFromNode(src_node), out dst_node, false, this.m_SubXml);
		}


		private bool ibGetSameChild(XmlNode src, ref XmlNode dst_ref)
		{
			string nodeAttribute = GuiCore.GetNodeAttribute(src, "name");
			foreach (object obj in dst_ref.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (!(xmlNode is XmlText))
				{
					string nodeAttribute2 = GuiCore.GetNodeAttribute(xmlNode, "name");
					if (nodeAttribute == nodeAttribute2)
					{
						dst_ref = xmlNode;
						return true;
					}
				}
			}
			return false;
		}


		private List<XmlNode> iGetParentsNodes(XmlNode node)
		{
			List<XmlNode> list = new List<XmlNode>();
			XmlNode xmlNode = node;
			bool flag = false;
			while (!flag)
			{
				if (xmlNode.Name.Equals("TreeRoot"))
				{
					break;
				}
				list.Insert(0, xmlNode);
				xmlNode = xmlNode.ParentNode;
			}
			return list;
		}


		public bool bIsExist(XmlNode node)
		{
			foreach (object obj in ((IEnumerable)this.m_ListView.Items))
			{
				ContainerListViewItem containerListViewItem = (ContainerListViewItem)obj;
				string pathFromNode = GuiCore.GetPathFromNode(node);
				if (GuiCore.GetPathFromNode((XmlNode)containerListViewItem.Tag) == pathFromNode)
				{
					this.iCopyNodeAttribs(node, (XmlNode)containerListViewItem.Tag);
					return true;
				}
			}
			return false;
		}


		public void AddNodesToSubSet(List<XmlNode> xml_nodes)
		{
			this.m_ListView.BeginUpdate();
			foreach (XmlNode xmlNode in xml_nodes)
			{
				if (!this.ibIsNodeInListView(xmlNode))
				{
					XmlNode xmlNode2;
					this.iAddNodeToSubXml(xmlNode, out xmlNode2);
					NodeType nodeType = GuiCore.GetNodeType(xmlNode2);
					if (nodeType != NodeType.REGISTER)
					{
						if (nodeType - NodeType.VAR <= 2)
						{
							ContainerListViewItem containerListViewItem = GuiCore.CreateTreeListNode(xmlNode2);
							this.m_ListView.Items.Add(containerListViewItem);
						}
					}
					else
					{
						ContainerListViewItem containerListViewItem = GuiCore.CreateTreeListNode(xmlNode2);
						this.m_ListView.Items.Add(containerListViewItem);
						for (int i = 1; i < xmlNode2.ChildNodes.Count; i++)
						{
							ContainerListViewItem item = GuiCore.CreateTreeListNode(xmlNode2.ChildNodes[i]);
							containerListViewItem.Items.Add(item);
						}
					}
				}
			}
			this.m_ListView.EndUpdate();
		}


		public void RefreshDisplay()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.RefreshDisplay);
				base.Invoke(method);
			}
			else
			{
				GuiCore.UpdateFolderList(this.m_ListView);
			}
			this.m_Dirty = true;
			this.iUpdateTitle();
		}


		public void ClearSubSet()
		{
			this.m_ListView.Items.Clear();
			this.iCleanSubXml();
		}


		public LuaTable GetSubSet()
		{
			LuaTable result = null;
			List<XmlNode> list = new List<XmlNode>();
			List<object> list2 = new List<object>();
			foreach (object obj in ((IEnumerable)this.m_ListView.Items))
			{
				ContainerListViewItem containerListViewItem = (ContainerListViewItem)obj;
				list.Add((XmlNode)containerListViewItem.Tag);
			}
			if (list.Count == 0)
			{
				GuiCore.VerbosePrint("SubsetGet: No results found!");
			}
			else
			{
				foreach (XmlNode xml_node in list)
				{
					list2.Add(GuiCore.GetPathFromNode(xml_node));
				}
				result = LuaWrapperUtils.LuaWrapper.CreateLuaTable(list2);
			}
			return result;
		}


		public void FixLoadedNodeForDisplay(XmlNode loaded_node)
		{
			int nodeType = (int)GuiCore.GetNodeType(loaded_node);
			this.iFixLoadedNodeHexValue(loaded_node);
			if (nodeType == 21)
			{
				foreach (object obj in loaded_node)
				{
					XmlNode xmlNode = (XmlNode)obj;
					if (GuiCore.GetNodeType(xmlNode) == NodeType.FIELD)
					{
						this.iFixLoadedNodeHexValue(xmlNode);
					}
				}
			}
			loaded_node.Attributes["is_updated"].Value = false.ToString();
		}


		public void SaveAllSubSet()
		{
			List<XmlNode> list = this.FillNodesList();
			if (list.Count > 0)
			{
				this.iSave(list);
				this.m_Dirty = false;
				this.iUpdateTitle();
				return;
			}
			GuiCore.ErrorMessage("Can not save empty subset.");
		}


		public void SaveAllSubset(string file_name)
		{
			List<XmlNode> list = this.FillNodesList();
			if (list.Count > 0)
			{
				GuiCore.Save2Csv(file_name, list, true, this.m_SubVersion, this.m_SrcVersion);
				this.m_Dirty = false;
				this.iUpdateTitle();
				return;
			}
			GuiCore.ErrorMessage("Can not save empty subset.");
		}


		private void iFixLoadedNodeHexValue(XmlNode loaded_node)
		{
			if (loaded_node.FirstChild.Value.StartsWith("0x"))
			{
				GuiCore.bSetLoadedValue(loaded_node, loaded_node.FirstChild.Value);
			}
		}


		private ContainerListView m_ListView;


		private ToolTip m_ToolTip;


		private XmlDocument m_SubXml;


		private bool m_Dirty;


		private string m_SubVersion;


		private string m_SrcVersion;
	}
}
