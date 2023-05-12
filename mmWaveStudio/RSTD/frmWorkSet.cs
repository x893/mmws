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
    public partial class frmWorkSet : DockContent
    {
        public frmWorkSet()
        {
            this.InitializeComponent();
            base.HideOnClose = true;
            this.SetFunctionsDisplay(RstdGuiSettings.Default.DisplayFunctions);
            this.iAddTreeListView();
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




        public ContainerListView ArgsListView
        {
            get
            {
                return this.m_ArgsListView;
            }
            set
            {
                this.m_ArgsListView = value;
            }
        }


        private void m_TreeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.m_TreeView.SelectedNode = this.m_TreeView.GetNodeAt(e.X, e.Y);
                if ((TreeViewNode)this.m_TreeView.SelectedNode != null)
                {
                    new FunctionContextMenu(GuiCore.GetPathFromNode((XmlNode)this.m_TreeView.SelectedNode.Tag)).Show(Control.MousePosition);
                }
            }
        }


        private void m_TreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((TreeViewNode)this.m_TreeView.SelectedNode != null)
            {
                GuiCore.RunFuncByXml(GuiCore.GetPathFromNode((XmlNode)this.m_TreeView.SelectedNode.Tag));
            }
        }


        private void m_TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.m_TreeView.SelectedNode != null)
            {
                this.m_ArgsListView.Items.Clear();
                foreach (object obj in ((XmlNode)this.m_TreeView.SelectedNode.Tag).SelectSingleNode("ArgumentList").ChildNodes)
                {
                    XmlNode xmlNode = (XmlNode)obj;
                    if (xmlNode.Attributes["type"].Value.ToUpper() != "THIS")
                    {
                        ContainerListViewItem item = GuiCore.CreateTreeListNode(xmlNode);
                        this.m_ArgsListView.Items.Add(item);
                    }
                }
            }
        }


        private void m_TreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.m_TreeView.SelectedNode == null)
            {
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                this.m_ArgsListView.Items.Clear();
                this.m_TreeView.SelectedNode.Remove();
                return;
            }
            this.iHandleKeyDown(sender, e);
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
                return;
            }
            this.iHandleKeyDown(sender, e);
        }


        private void m_ArgsListView_KeyDown(object sender, KeyEventArgs e)
        {
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
            if (sender == this.m_TreeView)
            {
                if (this.m_TreeView.SelectedNode != null)
                {
                    list.Add(GuiCore.GetPathFromNode((XmlNode)this.m_TreeView.SelectedNode.Tag));
                }
            }
            else if (sender is ContainerListView)
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
                    return;
                }
                if (gui_operation == RstdConstants.GUI_OPERATION.TRANSMIT)
                {
                    GuiCore.Transmit(list.ToArray(), ReceiveTransmit_T.XML_PATH, false);
                }
            }
        }


        public static void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            ContainerListView containerListView = (ContainerListView)sender;
            if (containerListView.SelectedItems.Count == 0)
            {
                return;
            }
            if (MouseButtons.Right == e.Button)
            {
                new VariableFormsContextMenu(new PassedVarData(containerListView.SelectedItems), RstdConstants.CONTEXT_MENU_ORIGIN.WORKSET);
            }
        }


        public void RemoveFromWorkSet(List<XmlNode> xml_nodes)
        {
            this.m_ListView.BeginUpdate();
            foreach (XmlNode xmlNode in xml_nodes)
            {
                foreach (object obj in ((IEnumerable)this.m_ListView.Items))
                {
                    ContainerListViewItem containerListViewItem = (ContainerListViewItem)obj;
                    if (xmlNode == containerListViewItem.Tag)
                    {
                        this.m_ListView.Items.Remove(containerListViewItem);
                        break;
                    }
                }
            }
            this.m_ListView.EndUpdate();
        }


        private void m_ListView_MouseMove(object sender, MouseEventArgs e)
        {
            GuiCore.DisplayToolTip((ContainerListView)sender, e, this.m_ToolTip);
        }


        private void m_ToolTip_Popup(object sender, PopupEventArgs e)
        {
            GuiCore.AdjustToolTipSize(sender, e);
        }


        private void frmWorkSet_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PassedVarData)))
            {
                e.Effect = DragDropEffects.Copy;
                return;
            }
            e.Effect = DragDropEffects.None;
        }


        private void frmWorkSet_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(PassedVarData)))
            {
                return;
            }
            PassedVarData passedVarData = (PassedVarData)e.Data.GetData(typeof(PassedVarData));
            this.AddNodesToWorkSet(passedVarData.XmlNodes);
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
            this.ClearWorkSet();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.iSaveAllWorkSet();
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            string file_name = GuiCore.OpenFileDialog(null, FileType.XML);
            this.LoadWorkSet(file_name);
        }


        private void btnLoadLast_Click(object sender, EventArgs e)
        {
            this.iLoadWorkSet(RstdGuiSettings.Default.LastWorksetFile);
        }


        private void m_TransmitSplitBtnWS_ButtonClick(object sender, EventArgs e)
        {
            this.TransmitWS(true);
        }


        private void selectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TransmitWS(false);
        }


        private void m_ReceiveSplitBtnWS_ButtonClick(object sender, EventArgs e)
        {
            this.ReceiveWS(true);
        }


        private void selectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ReceiveWS(false);
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


        public void ReceiveWS(bool b_all)
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
        }


        public void TransmitWS(bool b_all)
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
        }


        private void iAscertainClientBuilt()
        {
        }


        private void iAddTreeListView()
        {
            base.SuspendLayout();
            this.m_ListView = new ContainerListView();
            this.m_ArgsListView = new ContainerListView();
            this.m_TreeView = new TreeView();
            this.m_ToolTip = new ToolTip();
            this.m_ToolTip.InitialDelay = 100;
            this.iSetListViewProperties(ref this.m_ListView);
            this.iSetListViewProperties(ref this.m_ArgsListView);
            this.m_TreeView.Dock = DockStyle.Fill;
            this.m_TreeView.ImageList = new ImageList();
            this.m_TreeView.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            this.m_TreeView.ImageList.ImageSize = new Size(24, 24);
            this.m_TreeView.ImageList.TransparentColor = Color.Black;
            this.m_TreeView.ImageList.Images.Add(TreeIcons.folder_close);
            this.m_TreeView.ImageList.Images.Add(TreeIcons.folder_open);
            this.m_TreeView.ImageList.Images.Add(TreeIcons.func_gray);
            this.m_TreeView.ImageList.Images.Add(TreeIcons.func_color);
            this.m_TreeView.MouseClick += this.m_TreeView_MouseClick;
            this.m_TreeView.MouseDoubleClick += this.m_TreeView_MouseDoubleClick;
            this.m_TreeView.AfterSelect += this.m_TreeView_AfterSelect;
            this.m_TreeView.KeyDown += this.m_TreeView_KeyDown;
            this.AllowDrop = true;
            base.DragOver += this.frmWorkSet_DragOver;
            base.DragDrop += this.frmWorkSet_DragDrop;
            this.m_ListView.KeyDown += this.m_ListView_KeyDown;
            this.m_ListView.MouseMove += this.m_ListView_MouseMove;
            this.m_ListView.ColumnReordered += this.m_ListView_ColumnReordered;
            this.m_ListView.ItemDrag += this.iListView_ItemDrag;
            this.m_ArgsListView.KeyDown += this.m_ArgsListView_KeyDown;
            this.m_ArgsListView.ColumnReordered += this.iArgsListView_ColumnReordered;
            this.m_ToolTip.Popup += this.m_ToolTip_Popup;
            this.grpVariables.Controls.Add(this.m_ListView);
            this.m_SplitContainerFunctions.Panel1.Controls.Add(this.m_TreeView);
            this.m_SplitContainerFunctions.Panel2.Controls.Add(this.m_ArgsListView);
            this.m_SplitContainer.SplitterDistance = this.m_SplitContainer.Height / 2;
            base.ResumeLayout(true);
        }


        private void m_ListView_ColumnReordered(object sender, ContainerListViewEventArgs e)
        {
            ContainerListView containerListView = (ContainerListView)sender;
            this.iUpdateColumnMoveInMatchingListView(this.m_ArgsListView, this.m_ListView);
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
            this.iSaveAllWorkSet();
        }


        private void iArgsListView_ColumnReordered(object sender, ContainerListViewEventArgs e)
        {
            this.iUpdateColumnMoveInMatchingListView(this.m_ListView, this.m_ArgsListView);
        }


        private void iUpdateColumnMoveInMatchingListView(ContainerListView matching_list_view, ContainerListView orig_list_view)
        {
            for (int i = 0; i < matching_list_view.Columns.Count; i++)
            {
                matching_list_view.SetColumnDisplayIndex(matching_list_view.Columns[i], orig_list_view.Columns[i].DisplayIndex, false);
            }
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
            int num = 10;
            list_view.Columns.Add("Name", num * 18, HorizontalAlignment.Left);
            list_view.Columns.Add("Value", num * 6, HorizontalAlignment.Left);
            list_view.Columns.Add("Address", num * 10, HorizontalAlignment.Left);
            list_view.Columns.Add("Start Bit", num * 6, HorizontalAlignment.Left);
            list_view.Columns.Add("Stop Bit", num * 6, HorizontalAlignment.Left);
            list_view.Columns.Add("Description", num * 12, HorizontalAlignment.Left);
            this.iSortColumns(ref list_view);
            if (this.m_ListView == this.m_ArgsListView)
            {
                list_view.Columns[2].Visible = false;
                list_view.Columns[3].Visible = false;
                list_view.Columns[4].Visible = false;
                list_view.Columns[5].Visible = false;
            }
            list_view.SmallImageList = new ImageList();
            list_view.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
            list_view.SmallImageList.Images.Add(TreeIcons.var_updated);
            list_view.SmallImageList.Images.Add(TreeIcons.var_not_updated);
            list_view.SmallImageList.Images.Add(TreeIcons.parameter);
            list_view.SmallImageList.Images.Add(TreeIcons.clock);
            list_view.SmallImageList.Images.Add(TreeIcons.var_auto_updated);
            list_view.MouseClick += frmWorkSet.ListView_MouseClick;
            list_view.MouseDoubleClick += GuiCore.ListView_MouseDoubleClick;
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
            if (nodeType != NodeType.FUNCTION)
            {
                if (nodeType != NodeType.REGISTER && nodeType - NodeType.VAR > 2)
                {
                    return false;
                }
                foreach (ContainerListViewItem containerListViewItem in this.m_ListView.Items)
                {
                    if ((XmlNode)containerListViewItem.Tag == node)
                    {
                        return true;
                    }
                    string pathFromNode = GuiCore.GetPathFromNode(node);
                    if (GuiCore.GetPathFromNode((XmlNode)containerListViewItem.Tag) == pathFromNode)
                    {
                        this.iCopyNodeAttribs(node, (XmlNode)containerListViewItem.Tag);
                        return true;
                    }
                }
                return false;
            }

            foreach (TreeViewNode obj in this.m_TreeView.Nodes)
            {
                if ((XmlNode)obj.Tag == node)
                    return true;
            }
            return false;
        }


        private void iCopyNodeAttribs(XmlNode source, XmlNode target)
        {
            string nodeValue = GuiCore.GetNodeValue(source);
            GuiCore.ChangeVarsValue(target, nodeValue);
            target.Attributes["comment"].Value = source.Attributes["comment"].Value;
        }


        private bool iLoadWorkSet(string fileName)
        {
            string text = "";
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(fileName);
                this.ClearWorkSet();
            }
            catch (FileNotFoundException ex)
            {
                GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, ex.Message);
                return false;
            }
            RstdGuiSettings.Default.LastWorksetFile = fileName;
            RstdGuiSettings.Default.Save();
            XmlNode documentElement = xmlDocument.DocumentElement;
            GuiCore.ValidateRegisterValues_Rec(documentElement, ref text);
            if (text != "")
            {
                GuiCore.ErrorMessage(string.Format("Load failed.\nValues of the following registers don't match their fields:\n{0}", text));
                GuiCore.RefreshGui();
                xmlDocument = null;
                return false;
            }
            this.iRecursiveLoadItems(documentElement);
            GuiCore.RefreshGui();
            GuiCore.VerbosePrint(string.Format("RSTD.WorkSetLoad(\"{0}\")\n", fileName.Replace('\\', '/')));
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
                        if (nodeType - NodeType.VAR > 2)
                        {
                            this.iRecursiveLoadItems(xmlNode);
                            continue;
                        }
                    }
                    else
                    {
                        if (xmlNode.FirstChild.Value == null)
                        {
                            this.iRecursiveLoadItems(xmlNode);
                            continue;
                        }
                        XmlNode xmlNode2 = this.iAddMatchingTreeNode(xmlNode);
                        if (xmlNode2 != null)
                        {
                            GuiCore.bCalcFieldsFromRegister(xmlNode2);
                            continue;
                        }
                        continue;
                    }
                }
                this.iAddMatchingTreeNode(xmlNode);
            }
        }


        private XmlNode iAddMatchingTreeNode(XmlNode loaded_node)
        {
            XmlNode xmlNode;
            if (GuiCore.GetNodeFromPath(GuiCore.GetPathFromNode(loaded_node), out xmlNode))
            {
                this.UpdateXmlNodeFromLoadedNode(loaded_node, ref xmlNode);
                this.AddNodeToWorkSet(xmlNode);
                return xmlNode;
            }
            return null;
        }


        private void iSaveAllWorkSet()
        {
            List<XmlNode> node_list = this.FillNodesList();
            this.iSave(node_list);
        }


        private void iSave(List<XmlNode> node_list)
        {
            string text = null;
            if (GuiCore.SaveDialogTxtOrXml(node_list, out text, false, null, null) && Path.GetExtension(text).Equals(".xml"))
            {
                GuiCore.VerbosePrint(string.Format("RSTD.WorkSetSave(\"{0}\")", text.Replace('\\', '/')));
                RstdGuiSettings.Default.LastWorksetFile = text;
                RstdGuiSettings.Default.Save();
            }
        }


        public void SetFunctionsDisplay(bool show)
        {
            this.m_SplitContainer.Panel2Collapsed = !show;
        }


        public List<XmlNode> FillNodesList()
        {
            List<XmlNode> list = new List<XmlNode>();
            foreach (object obj in ((IEnumerable)this.m_ListView.Items))
            {
                ContainerListViewItem containerListViewItem = (ContainerListViewItem)obj;
                list.Add((XmlNode)containerListViewItem.Tag);
            }
            foreach (object obj2 in this.m_TreeView.Nodes)
            {
                TreeNode treeNode = (TreeNode)obj2;
                list.Add((XmlNode)treeNode.Tag);
            }
            return list;
        }


        public bool LoadWorkSet(string file_name)
        {
            return this.iLoadWorkSet(file_name);
        }


        public void SortListViewColumns(bool sort_state)
        {
            if (!sort_state)
            {
                int num = 0;
                while ((long)num < 6L)
                {
                    this.m_ListView.Columns[num].SortDataType = SortDataType.None;
                    this.m_ArgsListView.Columns[num].SortDataType = SortDataType.None;
                    num++;
                }
                return;
            }
            this.iSortColumns(ref this.m_ListView);
            this.iSortColumns(ref this.m_ArgsListView);
        }


        public void AddNodeToWorkSet(XmlNode node)
        {
            this.AddNodesToWorkSet(new List<XmlNode>
            {
                node
            });
        }


        public void AddNodesToWorkSet(List<XmlNode> xml_nodes)
        {
            this.m_ListView.BeginUpdate();
            foreach (XmlNode xmlNode in xml_nodes)
            {
                if (!this.ibIsNodeInListView(xmlNode))
                {
                    NodeType nodeType = GuiCore.GetNodeType(xmlNode);
                    if (nodeType != NodeType.FUNCTION)
                    {
                        if (nodeType != NodeType.REGISTER)
                        {
                            if (nodeType - NodeType.VAR <= 2)
                            {
                                ContainerListViewItem containerListViewItem = GuiCore.CreateTreeListNode(xmlNode);
                                this.m_ListView.Items.Add(containerListViewItem);
                            }
                        }
                        else
                        {
                            ContainerListViewItem containerListViewItem = GuiCore.CreateTreeListNode(xmlNode);
                            this.m_ListView.Items.Add(containerListViewItem);
                            for (int i = 1; i < xmlNode.ChildNodes.Count; i++)
                            {
                                ContainerListViewItem item = GuiCore.CreateTreeListNode(xmlNode.ChildNodes[i]);
                                containerListViewItem.Items.Add(item);
                            }
                        }
                    }
                    else
                    {
                        TreeViewNode treeViewNode = new TreeViewNode(xmlNode);
                        treeViewNode.Tag = xmlNode;
                        this.m_TreeView.Nodes.Add(treeViewNode);
                    }
                }
            }
            this.m_ListView.EndUpdate();
        }


        public void RefreshDisplay()
        {
            GuiCore.UpdateFolderList(this.m_ListView);
            GuiCore.UpdateFolderList(this.m_ArgsListView);
        }


        public void ClearWorkSet()
        {
            GuiCore.VerbosePrint("RSTD.ClearWorkSet()\n");
            this.m_ListView.Items.Clear();
            this.m_ArgsListView.Items.Clear();
            this.m_TreeView.Nodes.Clear();
        }


        public LuaTable GetWorkSet()
        {
            LuaTable result = null;
            List<XmlNode> list = new List<XmlNode>();
            List<object> list2 = new List<object>();
            GuiCore.VerbosePrint("RSTD.GetWorkSet()\n");
            foreach (object obj in ((IEnumerable)this.m_ListView.Items))
            {
                ContainerListViewItem containerListViewItem = (ContainerListViewItem)obj;
                list.Add((XmlNode)containerListViewItem.Tag);
            }
            if (list.Count == 0)
            {
                GuiCore.VerbosePrint("GetWorkSet: No results found!");
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


        public void UpdateXmlNodeFromLoadedNode(XmlNode loaded_node, ref XmlNode tree_node)
        {
            if (GuiCore.GetNodeType(loaded_node) == NodeType.MAPPED_VAR && loaded_node.FirstChild.Value != null)
            {
                GuiCore.RegisterMapping[tree_node].FirstChild.Value = loaded_node.FirstChild.Value;
            }
            else if (loaded_node.FirstChild.Value.StartsWith("0x"))
            {
                GuiCore.bSetLoadedValue(tree_node, loaded_node.FirstChild.Value);
            }
            else
            {
                tree_node.FirstChild.Value = GuiCore.GetNodeValue(loaded_node);
            }
            tree_node.Attributes["comment"].Value = loaded_node.Attributes["comment"].Value;
            tree_node.Attributes["offset"].Value = loaded_node.Attributes["offset"].Value;
            tree_node.Attributes["stride"].Value = loaded_node.Attributes["stride"].Value;
            tree_node.Attributes["length"].Value = loaded_node.Attributes["length"].Value;
            tree_node.Attributes["permission"].Value = loaded_node.Attributes["permission"].Value;
            tree_node.Attributes["options"].Value = loaded_node.Attributes["options"].Value;
            tree_node.Attributes["display_type"].Value = loaded_node.Attributes["display_type"].Value;
            tree_node.Attributes["is_updated"].Value = false.ToString();
        }


        private ContainerListView m_ListView;
        private ContainerListView m_ArgsListView;
        private TreeView m_TreeView;
        private ToolTip m_ToolTip;
    }
}
