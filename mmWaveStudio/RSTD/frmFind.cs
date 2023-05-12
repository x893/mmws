using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;

namespace RSTD
{

	public partial class frmFind : DockContent
	{

		public frmFind(string basePath)
		{
			this.InitializeComponent();
			this.m_ListFindChosenItems = new ArrayList(RstdGuiSettings.Default.ListFindChosenItemsFromLoad);
			this.m_ResultsListView.SmallImageList = new ImageList();
			this.m_ResultsListView.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
			this.m_ResultsListView.SmallImageList.Images.Add(TreeIcons.var_updated);
			this.m_ResultsListView.SmallImageList.Images.Add(TreeIcons.var_not_updated);
			this.m_ResultsListView.SmallImageList.Images.Add(TreeIcons.parameter);
			this.m_ResultsListView.SmallImageList.Images.Add(TreeIcons.clock);
			this.m_ResultsListView.SmallImageList.Images.Add(TreeIcons.var_auto_updated);
			this.m_ResultsListView.SmallImageList.Images.Add(TreeIcons.func_gray);
			this.m_BasePathComboBox.Text = basePath;
			this.m_ResultsListView.MouseClick += this.m_ResultsListView_MouseClick;
			this.m_ResultsListView.MouseMove += this.m_ResultsListView_MouseMove;
			this.m_ResultsListView.MouseDown += this.m_ResultsListView_MouseDown;
			if (this.m_ListFindChosenItems.Count > 0)
			{
				this.m_SearchForComboBox.Items.AddRange(this.m_ListFindChosenItems.ToArray());
				this.m_SearchForComboBox.Text = this.m_ListFindChosenItems[0].ToString();
			}
			this.m_SearchForComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.m_SearchForComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
			this.m_SearchForComboBox.Select();
		}


		public frmFind(JumpToPathDel dJumpFunc)
		{
			this.InitializeComponent();
		}




		public ArrayList ListFindChosenItems
		{
			get
			{
				return this.m_ListFindChosenItems;
			}
			set
			{
				this.m_ListFindChosenItems = value;
			}
		}




		public string BasePath
		{
			get
			{
				return this.m_BasePathComboBox.Text;
			}
			set
			{
				this.m_BasePathComboBox.Text = value;
			}
		}



		public ComboBox SearchForComboBox
		{
			get
			{
				return this.m_SearchForComboBox;
			}
		}


		private void m_FindBtn_Click(object sender, EventArgs e)
		{
			this.iAddFindItemToList();
			this.iSearch();
		}


		private void m_ResultsListView_DoubleClick(object sender, EventArgs e)
		{
			GuiCore.bJumpToPath((XmlNode)this.m_ResultsListView.SelectedItems[0].Tag);
		}


		private void ibtn_ClearHistory_Click(object sender, EventArgs e)
		{
			this.m_ListFindChosenItems.Clear();
			this.m_SearchForComboBox.Items.Clear();
		}


		private void m_ResultsListView_MouseClick(object sender, MouseEventArgs e)
		{
			if (MouseButtons.Right == e.Button)
			{
				PassedVarData passedVarData = new PassedVarData(this.m_ResultsListView.SelectedItems);
				bool flag = false;
				int num = 0;
				while (num < passedVarData.XmlNodes.Count && !flag)
				{
					if (GuiCore.GetNodeType(passedVarData.XmlNodes[num]) == NodeType.FUNCTION)
					{
						flag = true;
					}
					num++;
				}
				ContextMenuStrip contextMenuStrip;
				if (flag)
				{
					if (passedVarData.XmlNodes.Count != 1)
					{
						return;
					}
					contextMenuStrip = new FunctionFindContextMenu(GuiCore.GetPathFromNode(passedVarData.XmlNodes[0]));
				}
				else
				{
					contextMenuStrip = new VariableFindContextMenu(passedVarData, RstdConstants.CONTEXT_MENU_ORIGIN.FIND_FORM);
				}
				contextMenuStrip.Show(Control.MousePosition);
			}
		}


		private void m_ResultsListView_MouseDown(object sender, MouseEventArgs e)
		{
			if (MouseButtons.Left == e.Button)
			{
				this.m_mouseDownStartPosition = e.Location;
			}
		}


		private void m_ResultsListView_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			if (this.m_ResultsListView.SelectedItems.Count == 0)
			{
				return;
			}
			int num = Math.Abs(e.X - this.m_mouseDownStartPosition.X);
			int num2 = Math.Abs(e.Y - this.m_mouseDownStartPosition.Y);
			if (num < 3 || num2 < 3)
			{
				return;
			}
			PassedVarData passedVarData = new PassedVarData(this.m_ResultsListView.SelectedItems);
			if (passedVarData != null)
			{
				this.m_ResultsListView.DoDragDrop(passedVarData, DragDropEffects.Copy);
			}
		}


		private void m_SaveSplitBtn_ButtonClick(object sender, EventArgs e)
		{
			this.m_SaveSplitBtnSelectionMenuItem_Click(sender, e);
		}


		private void m_SaveSplitBtnAllMenuItem_Click(object sender, EventArgs e)
		{
			if (this.m_ResultsListView.Items.Count > 0)
			{
				List<XmlNode> list = new List<XmlNode>();
				for (int i = 0; i < this.m_ResultsListView.Items.Count; i++)
				{
					list.Add((XmlNode)this.m_ResultsListView.Items[i].Tag);
				}
				this.iSaveToFile(list);
				return;
			}
			GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Save to file: \n The list is empty.");
		}


		private void m_SaveSplitBtnSelectionMenuItem_Click(object sender, EventArgs e)
		{
			if (this.m_ResultsListView.SelectedItems.Count > 0)
			{
				List<XmlNode> list = new List<XmlNode>();
				for (int i = 0; i < this.m_ResultsListView.Items.Count; i++)
				{
					list.Add((XmlNode)this.m_ResultsListView.Items[i].Tag);
				}
				this.iSaveToFile(list);
				return;
			}
			string str;
			if (this.m_ResultsListView.Items.Count == 0)
			{
				str = "The list is empty.";
			}
			else
			{
				str = "No Items were selected.";
			}
			GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Save to file: \n" + str);
		}


		private void m_SearchForComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.iAddFindItemToList();
				this.iSearch();
			}
		}


		private void m_BasePathComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.m_SearchForComboBox.Focus();
			}
		}


		private void iAddFindItemToList()
		{
			string text = this.m_SearchForComboBox.Text;
			if (this.m_SearchForComboBox.Text.Trim() == "")
			{
				return;
			}
			if (this.m_ListFindChosenItems.Count == 20)
			{
				this.m_ListFindChosenItems.RemoveAt(19);
			}
			if (this.m_ListFindChosenItems.Contains(text))
			{
				this.m_ListFindChosenItems.Remove(text);
				this.m_SearchForComboBox.Items.Remove(text);
				this.m_SearchForComboBox.Text = text;
			}
			this.m_ListFindChosenItems.Insert(0, text);
			this.m_SearchForComboBox.Items.Add(text);
		}


		private void iSearch()
		{
			this.m_ResultsListView.Items.Clear();
			if (string.IsNullOrEmpty(this.m_BasePathComboBox.Text))
			{
				GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Find: \n Cannot have an empty base search path!");
				return;
			}
			if (string.IsNullOrEmpty(this.m_SearchForComboBox.Text))
			{
				GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Find: \n Cannot have an empty search string!");
				return;
			}
			XmlNode basePathNode;
			if (GuiCore.bGetFolder(this.m_BasePathComboBox.Text, out basePathNode))
			{
				List<XmlNode> list = new List<XmlNode>();
				try
				{
					GuiCore.RecursiveFind(basePathNode, this.m_IsRecursiveCheckBox.Checked, this.m_SearchForComboBox.Text, this.m_NameCheckBox.Checked, this.m_ValueCheckBox.Checked, this.m_CommentCheckBox.Checked, this.m_TypeCheckBox.Checked, this.m_AddressCheckBox.Checked, this.m_DescriptionCheckBox.Checked, this.m_CaseSensitiveCheckBox.Checked, this.m_MatchWholeWordCheckBox.Checked, this.m_chkRegularExpression.Checked, list);
				}
				catch (Exception ex)
				{
					string str = "Error in search:\n" + ex.Message;
					GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Find: \n" + str);
					return;
				}
				foreach (XmlNode xml_node in list)
				{
					this.iAddItemToResults(xml_node);
				}
				if (this.m_ResultsListView.Items.Count == 0)
				{
					GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Find:\n No results found!");
					return;
				}
				this.iSetSaveMsg();
				return;
			}
			else
			{
				GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Find:\n Invalid base path!!");
			}
		}


		private void iAddItemToResults(XmlNode xml_node)
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			NodeType nodeType = GuiCore.GetNodeType(xml_node);
			int imageIndex;
			if (nodeType != NodeType.FUNCTION)
			{
				text2 = GuiCore.GetDisplayedFixMode(xml_node);
				text3 = GuiCore.GetDisplayedType(xml_node);
				text = GuiCore.GetDisplayedValue(xml_node);
				imageIndex = (int)GuiCore.GetVarIcon(xml_node);
				text4 = xml_node.Attributes["comment"].Value;
				text5 = xml_node.Attributes["permission"].Value;
				if (xml_node.Attributes["address"] != null)
				{
					text6 = xml_node.Attributes["address"].Value;
				}
				if (nodeType == NodeType.FIELD)
				{
					text7 = xml_node.LastChild.Attributes["description"].Value;
				}
			}
			else
			{
				imageIndex = this.m_ResultsListView.SmallImageList.Images.Count - 1;
			}
			ListViewItem listViewItem = new ListViewItem(new string[]
			{
				GuiCore.GetUpperPath(xml_node),
				xml_node.Attributes["name"].Value,
				text3,
				text,
				text2,
				text4,
				text5,
				text6,
				text7
			}, imageIndex);
			listViewItem.Tag = xml_node;
			if (nodeType != NodeType.FUNCTION && xml_node.Attributes["permission"].Value == "R")
			{
				listViewItem.UseItemStyleForSubItems = false;
				listViewItem.ForeColor = Color.Gray;
				for (int i = 0; i < listViewItem.SubItems.Count; i++)
				{
					listViewItem.SubItems[i].ForeColor = Color.Gray;
				}
			}
			this.m_ResultsListView.Items.Add(listViewItem);
		}


		private void iRefreshList()
		{
			foreach (object obj in this.m_ResultsListView.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				XmlNode xmlNode = (XmlNode)listViewItem.Tag;
				if (GuiCore.GetNodeType(xmlNode) != NodeType.FUNCTION)
				{
					listViewItem.SubItems[3].Text = GuiCore.GetDisplayedValue(xmlNode);
					listViewItem.ImageIndex = (int)GuiCore.GetVarIcon(xmlNode);
				}
			}
		}


		private void iSaveToFile(List<XmlNode> selNodes)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Select destination file...";
			saveFileDialog.Filter = "Text Files (*.txt)|*.txt|XML Tree Data Values files (*.xml)|*.xml";
			saveFileDialog.RestoreDirectory = true;
			if (DialogResult.OK == saveFileDialog.ShowDialog())
			{
				this.m_SaveMessage += string.Format(",\"{0}\")\n", saveFileDialog.FileName.Replace("\\", "\\\\"));
				GuiCore.VerbosePrint(this.m_SaveMessage.ToString());
				GuiCore.Save(selNodes, saveFileDialog.FileName);
			}
		}


		private void iSetSaveMsg()
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (this.m_NameCheckBox.Checked)
			{
				text += "Name|";
			}
			if (this.m_ValueCheckBox.Checked)
			{
				text += "Value|";
			}
			if (this.m_CommentCheckBox.Checked)
			{
				text += "Comment";
			}
			if (this.m_TypeCheckBox.Checked)
			{
				text += "Type";
			}
			if (this.m_AddressCheckBox.Checked)
			{
				text += "Address";
			}
			if (this.m_DescriptionCheckBox.Checked)
			{
				text += "Description";
			}
			if (text.ToString().EndsWith("|"))
			{
				text = text.Remove(text.Length - 1);
			}
			if (this.m_CaseSensitiveCheckBox.Checked)
			{
				text2 += "MatchCase|";
			}
			if (this.m_MatchWholeWordCheckBox.Checked)
			{
				text2 += "WholeWord|";
			}
			if (this.m_chkRegularExpression.Checked)
			{
				text2 += "RegularExpression";
			}
			if (text2.ToString().EndsWith("|"))
			{
				text2 = text2.Remove(text2.Length - 1);
			}
			this.m_SaveMessage = string.Format("SaveSearch(\"{0}\",\"{1}\",\"{2}\",\"{3}\"", new object[]
			{
				this.m_BasePathComboBox.Text,
				this.m_SearchForComboBox.Text,
				text,
				text2
			});
		}


		public void RefreshDisplay()
		{
			this.iRefreshList();
		}


		private string m_SaveMessage;


		private Point m_mouseDownStartPosition;


		private ArrayList m_ListFindChosenItems;


		private const ushort m_maxListFindChosenItems = 20;
	}
}
