using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	internal class VariableContextMenu : ContextMenuStrip
	{

		public VariableContextMenu(PassedVarData dataPassed, frmSubSet sub_set)
		{
			this.m_SubSet = sub_set;
			this.iInitMembers(dataPassed, RstdConstants.CONTEXT_MENU_ORIGIN.SUB_SET);
		}


		public VariableContextMenu(PassedVarData dataPassed, RstdConstants.CONTEXT_MENU_ORIGIN var_menu_display)
		{
			this.m_SubSet = null;
			this.iInitMembers(dataPassed, var_menu_display);
		}


		private void iInitMembers(PassedVarData dataPassed, RstdConstants.CONTEXT_MENU_ORIGIN var_menu_display)
		{
			this.m_XmlNodes = dataPassed.XmlNodes;
			this.m_TransmitMenuItem = new ToolStripMenuItem("Transmit Selection", TreeIcons.tx);
			this.m_ReceiveMenuItem = new ToolStripMenuItem("Receive Selection", TreeIcons.refresh);
			this.m_ChangeMenuItem = new ToolStripMenuItem("Change...");
			this.m_OnOffFullPrecisionMenuItem = new ToolStripMenuItem("On/Off Full Precision...");
			this.m_LoadFromFileMenuItem = new ToolStripMenuItem("Load Vector From File...");
			this.m_AddToMonitorMenuItem = new ToolStripMenuItem("Add To Monitor");
			this.m_RemoveFromMonitorMenuItem = new ToolStripMenuItem("Remove From Monitor");
			this.m_AddToWorkSetMenuItem = new ToolStripMenuItem("Add To WorkSet");
			this.m_RemoveFromWorkSetMenuItem = new ToolStripMenuItem("Remove From WorkSet");
			this.m_SetCommentMenuItem = new ToolStripMenuItem("Set Comment...");
			this.iAddMonitorClocksItems();
			if (1 == dataPassed.XmlNodes.Count)
			{
				this.m_CopyPathToClipBoard = new ToolStripMenuItem("Copy path to clipboard", TreeIcons.copy);
			}
			this.m_DisplayAsMenuItem = new ToolStripMenuItem("Display As...");
			this.m_ShowArrayMenuItem = new ToolStripMenuItem("Show Array");
			if (1 < dataPassed.XmlNodes.Count || this.m_XmlNodes[0].Attributes["type"].Value.Equals("FILE") || this.m_XmlNodes[0].Attributes["type"].Value.Equals("STRING") || this.m_XmlNodes[0].Attributes["type"].Value.Equals("PATH"))
			{
				this.m_ShowArrayMenuItem.Enabled = false;
			}
			this.m_SaveMenuItem = new ToolStripMenuItem("Save ...", TreeIcons.diskette);
			this.m_Separator1MenuItem = new ToolStripSeparator();
			this.m_Separator2MenuItem = new ToolStripSeparator();
			this.m_Separator3MenuItem = new ToolStripSeparator();
			this.m_Separator4MenuItem = new ToolStripSeparator();
			this.m_GotoFieldMenuItem = new ToolStripMenuItem("GoTo Field");
			this.m_DisplayAsDefaultMenuItem = new ToolStripMenuItem("Default");
			this.m_DisplayAsDecimalMenuItem = new ToolStripMenuItem("Decimal");
			this.m_DisplayAsDecimalSignedMenuItem = new ToolStripMenuItem("Decimal Signed");
			this.m_DisplayAsHexMenuItem = new ToolStripMenuItem("Hex");
			this.m_DisplayAsBinaryMenuItem = new ToolStripMenuItem("Binary");
			this.m_DisplayAsIntMenuItem = new ToolStripMenuItem("Integer");
			this.m_DisplayAsdb10MenuItem = new ToolStripMenuItem("db10");
			this.m_DisplayAsdb20MenuItem = new ToolStripMenuItem("db20");
			this.m_DisplayAsDefaultMenuItem.Tag = DisplayType.DEFAULT;
			this.m_DisplayAsDecimalMenuItem.Tag = DisplayType.DECIMAL;
			this.m_DisplayAsDecimalSignedMenuItem.Tag = DisplayType.DECIMAL_SIGNED;
			this.m_DisplayAsHexMenuItem.Tag = DisplayType.HEX;
			this.m_DisplayAsBinaryMenuItem.Tag = DisplayType.BINARY;
			this.m_DisplayAsIntMenuItem.Tag = DisplayType.INTEGER;
			this.m_DisplayAsdb10MenuItem.Tag = DisplayType.DB10;
			this.m_DisplayAsdb20MenuItem.Tag = DisplayType.DB20;
			this.m_OnFullPrecisionMenuItem = new ToolStripMenuItem("On");
			this.m_OffFullPrecisionMenuItem = new ToolStripMenuItem("Off");
			this.menu_display_as = new ToolStripMenuItem[]
			{
				this.m_DisplayAsDefaultMenuItem,
				this.m_DisplayAsDecimalMenuItem,
				this.m_DisplayAsDecimalSignedMenuItem,
				this.m_DisplayAsHexMenuItem,
				this.m_DisplayAsBinaryMenuItem,
				this.m_DisplayAsIntMenuItem,
				this.m_DisplayAsdb10MenuItem,
				this.m_DisplayAsdb20MenuItem
			};
			this.iAddDisplayAsItems();
			this.m_OnOffFullPrecisionMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.m_OnFullPrecisionMenuItem,
				this.m_OffFullPrecisionMenuItem
			});
			this.m_TransmitMenuItem.Name = "Transmit";
			this.m_ChangeMenuItem.Name = "Change";
			this.m_LoadFromFileMenuItem.Name = "LoadFromFile";
			if (var_menu_display != RstdConstants.CONTEXT_MENU_ORIGIN.MONITOR)
			{
				this.Items.Add(this.m_TransmitMenuItem);
				this.Items.Add(this.m_ReceiveMenuItem);
			}
			if (this.m_XmlNodes.Count == 1)
			{
				if (GuiCore.GetNodeType(this.m_XmlNodes[0]) == NodeType.MAPPED_VAR)
				{
					this.m_GotoFieldMenuItem.Text = "GoTo Field";
					this.Items.Add(this.m_GotoFieldMenuItem);
				}
				else if (GuiCore.GetNodeType(this.m_XmlNodes[0]) == NodeType.FIELD && GuiCore.RegisterMapping.ContainsValue(this.m_XmlNodes[0]))
				{
					this.m_GotoFieldMenuItem.Text = "GoTo Mapped Variable";
					this.Items.Add(this.m_GotoFieldMenuItem);
				}
			}
			if (var_menu_display != RstdConstants.CONTEXT_MENU_ORIGIN.MONITOR)
			{
				this.Items.Add(this.m_Separator1MenuItem);
				this.Items.Add(this.m_ChangeMenuItem);
				if (this.ibAreAllFixMode())
				{
					this.Items.Add(this.m_OnOffFullPrecisionMenuItem);
				}
				this.Items.Add(this.m_LoadFromFileMenuItem);
				this.Items.Add(this.m_Separator4MenuItem);
				this.Items.Add(this.m_SetCommentMenuItem);
				this.Items.Add(this.m_Separator2MenuItem);
			}
			if (var_menu_display == RstdConstants.CONTEXT_MENU_ORIGIN.MONITOR)
			{
				this.Items.Add(this.m_RemoveFromMonitorMenuItem);
				this.Items.Add(this.m_Separator3MenuItem);
				this.Items.Add(this.m_AddToWorkSetMenuItem);
				this.Items.Add(this.m_RemoveFromWorkSetMenuItem);
			}
			else if (var_menu_display == RstdConstants.CONTEXT_MENU_ORIGIN.WORKSET)
			{
				this.Items.Add(this.m_AddToMonitorMenuItem);
				this.Items.Add(this.m_RemoveFromMonitorMenuItem);
				this.Items.Add(this.m_Separator3MenuItem);
				this.Items.Add(this.m_RemoveFromWorkSetMenuItem);
			}
			else
			{
				this.Items.Add(this.m_AddToMonitorMenuItem);
				this.Items.Add(this.m_RemoveFromMonitorMenuItem);
				this.Items.Add(this.m_Separator3MenuItem);
				this.Items.Add(this.m_AddToWorkSetMenuItem);
				this.Items.Add(this.m_RemoveFromWorkSetMenuItem);
			}
			if (1 == this.m_XmlNodes.Count)
			{
				this.Items.Add(this.m_CopyPathToClipBoard);
			}
			this.Items.Add(this.m_ShowArrayMenuItem);
			if (var_menu_display != RstdConstants.CONTEXT_MENU_ORIGIN.MONITOR)
			{
				this.Items.Add(this.m_DisplayAsMenuItem);
			}
			this.Items.Add(this.m_SaveMenuItem);
			this.m_TransmitMenuItem.Click += this.iTransmitMenuItem_Click;
			this.m_ReceiveMenuItem.Click += this.iReceiveMenuItem_Click;
			this.m_ChangeMenuItem.Click += this.iChangeMenuItem_Click;
			this.m_OnFullPrecisionMenuItem.Click += this.iOnOffFullPrecisionMenuItem_Click;
			this.m_OffFullPrecisionMenuItem.Click += this.iOnOffFullPrecisionMenuItem_Click;
			this.m_LoadFromFileMenuItem.Click += this.iLoadFromFileMenuItem_Click;
			this.m_RemoveFromMonitorMenuItem.Click += this.iRemoveFromMonitorMenuItem_Click;
			this.m_AddToWorkSetMenuItem.Click += this.iAddToWorkSetMenuItem_Click;
			this.m_RemoveFromWorkSetMenuItem.Click += this.iRemoveFromWorkSetMenuItem_Click;
			this.m_SetCommentMenuItem.Click += this.iSetCommentMenuItem_Click;
			if (1 == this.m_XmlNodes.Count)
			{
				this.m_CopyPathToClipBoard.Click += this.iCopyToClipBoard_Click;
			}
			this.m_ShowArrayMenuItem.Click += this.iShowArrayMenuItem_Click;
			this.m_DisplayAsDefaultMenuItem.Click += this.iDisplayAsMenuItem_Click;
			this.m_DisplayAsDecimalMenuItem.Click += this.iDisplayAsMenuItem_Click;
			this.m_DisplayAsDecimalSignedMenuItem.Click += this.iDisplayAsMenuItem_Click;
			this.m_DisplayAsHexMenuItem.Click += this.iDisplayAsMenuItem_Click;
			this.m_DisplayAsBinaryMenuItem.Click += this.iDisplayAsMenuItem_Click;
			this.m_DisplayAsIntMenuItem.Click += this.iDisplayAsMenuItem_Click;
			this.m_DisplayAsdb10MenuItem.Click += this.iDisplayAsMenuItem_Click;
			this.m_DisplayAsdb20MenuItem.Click += this.iDisplayAsMenuItem_Click;
			this.m_SaveMenuItem.Click += this.iSaveMenuItem_Click;
			this.m_GotoFieldMenuItem.Click += this.iGotoFieldMenuItem_Click;
			base.Opening += this.VariableContextMenu_Opening;
			if (this.ibAreAllReadOnly())
			{
				this.Items["Transmit"].Enabled = false;
				this.Items["Change"].Enabled = false;
				this.Items["LoadFromFile"].Enabled = false;
			}
			if (GuiCore.bAreAllFunctionArgs(this.m_XmlNodes))
			{
				this.Items["Transmit"].Enabled = false;
			}
			base.Show(Control.MousePosition);
		}


		private void iAddDisplayAsItems()
		{
			for (int i = 0; i < this.menu_display_as.Length; i++)
			{
				bool flag = true;
				int num = 0;
				while (num < this.m_XmlNodes.Count && flag)
				{
					XmlNode xmlNode = this.iGetActualNode(this.m_XmlNodes[num]);
					if (!GuiCore.bIsDisplayTypeValidForType((DisplayType)this.menu_display_as[i].Tag, xmlNode.Attributes["type"].Value))
					{
						flag = false;
					}
					num++;
				}
				if (flag)
				{
					this.m_DisplayAsMenuItem.DropDownItems.Add(this.menu_display_as[i]);
				}
			}
		}


		private void iAddMonitorClocksItems()
		{
			this.m_ClockMenuItems = new List<ToolStripMenuItem>();
			string[] clocks = GuiCore.GetClocks();
			if (clocks != null)
			{
				for (int i = 0; i < clocks.Length; i++)
				{
					this.m_ClockMenuItems.Add(new ToolStripMenuItem(clocks[i]));
					this.m_ClockMenuItems[i].Tag = clocks[i];
				}
			}
			this.m_ClockMenuItems.Add(new ToolStripMenuItem("None"));
			this.m_ClockMenuItems[this.m_ClockMenuItems.Count - 1].Tag = "";
			ToolStripItemCollection dropDownItems = this.m_AddToMonitorMenuItem.DropDownItems;
			ToolStripItem[] toolStripItems = this.m_ClockMenuItems.ToArray();
			dropDownItems.AddRange(toolStripItems);
			for (int i = 0; i < this.m_ClockMenuItems.Count; i++)
			{
				this.m_ClockMenuItems[i].Click += this.iClockMenuItem_Click;
			}
		}


		~VariableContextMenu()
		{
			this.m_XmlNodes = null;
			this.Items.Clear();
			this.m_TransmitMenuItem = null;
			this.m_ReceiveMenuItem = null;
			this.m_ChangeMenuItem = null;
			this.m_OnOffFullPrecisionMenuItem = null;
			this.m_OnFullPrecisionMenuItem = null;
			this.m_OffFullPrecisionMenuItem = null;
			this.m_LoadFromFileMenuItem = null;
			this.m_AddToMonitorMenuItem = null;
			this.m_RemoveFromMonitorMenuItem = null;
			this.m_AddToWorkSetMenuItem = null;
			this.m_RemoveFromWorkSetMenuItem = null;
			this.m_SetCommentMenuItem = null;
			this.m_CopyPathToClipBoard = null;
			this.m_ShowArrayMenuItem = null;
			this.m_DisplayAsMenuItem = null;
			this.m_SaveMenuItem = null;
			this.m_Separator1MenuItem = null;
			this.m_Separator2MenuItem = null;
			this.m_Separator3MenuItem = null;
			this.m_Separator4MenuItem = null;
			this.m_GotoFieldMenuItem = null;
			this.m_DisplayAsDefaultMenuItem = null;
			this.m_DisplayAsDecimalMenuItem = null;
			this.m_DisplayAsDecimalSignedMenuItem = null;
			this.m_DisplayAsHexMenuItem = null;
			this.m_DisplayAsBinaryMenuItem = null;
			this.m_DisplayAsIntMenuItem = null;
			this.m_DisplayAsdb10MenuItem = null;
			this.m_DisplayAsdb20MenuItem = null;
		}


		public void ChangeSelVarsValues(UpdateDialog update_dlg)
		{
			if (DialogResult.OK == update_dlg.ShowDialog() && update_dlg.bHasValidValue())
			{
				bool flag = GuiCore.ChangeVarsValueBeforeTransmit(this.m_XmlNodes, update_dlg.GetValue(), this.m_SubSet);
				if (update_dlg.bIsTransmit && flag)
				{
					GuiCore.Transmit(this.m_XmlNodes, ReceiveTransmit_T.SET_AND_TRANSMIT, false, this.m_SubSet);
				}
			}
			update_dlg = null;
		}


		private bool ibAreAllFixMode()
		{
			using (List<XmlNode>.Enumerator enumerator = this.m_XmlNodes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.Attributes["type"].Value.Equals("FIXMODE"))
					{
						return false;
					}
				}
			}
			return true;
		}


		private bool ibAreAllReadOnly()
		{
			using (List<XmlNode>.Enumerator enumerator = this.m_XmlNodes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!(enumerator.Current.Attributes["permission"].Value == "R"))
					{
						return false;
					}
				}
			}
			return true;
		}


		private void iUpdateChecks()
		{
			DisplayType displayType = this.iGetNodesDisplayType();
			this.m_DisplayAsDefaultMenuItem.Checked = (displayType == DisplayType.DEFAULT);
			this.m_DisplayAsDecimalMenuItem.Checked = (displayType == DisplayType.DECIMAL);
			this.m_DisplayAsDecimalSignedMenuItem.Checked = (displayType == DisplayType.DECIMAL_SIGNED);
			this.m_DisplayAsHexMenuItem.Checked = (displayType == DisplayType.HEX);
			this.m_DisplayAsBinaryMenuItem.Checked = (displayType == DisplayType.BINARY);
			this.m_DisplayAsIntMenuItem.Checked = (displayType == DisplayType.INTEGER);
			if (this.ibAreAllFixMode())
			{
				FullPrecision fullPrecision = this.iGetNodesFullPrecision();
				this.m_OnFullPrecisionMenuItem.Checked = (fullPrecision == FullPrecision.ON);
				this.m_OffFullPrecisionMenuItem.Checked = (fullPrecision == FullPrecision.OFF);
			}
		}


		private void iUpdateNodesDisplayType(DisplayType display_type)
		{
			foreach (XmlNode node in this.m_XmlNodes)
			{
				XmlNode xmlNode = this.iGetActualNode(node);
				if (GuiCore.bIsDisplayTypeValidForType(display_type, xmlNode.Attributes["type"].Value))
				{
					xmlNode.Attributes["display_type"].Value = Enum.Format(typeof(DisplayType), display_type, "g").ToLower();
				}
			}
			GuiCore.RefreshGui();
		}


		private DisplayType iGetNodesDisplayType()
		{
			bool flag = false;
			DisplayType displayType = this.iGetNodeDisplayType(this.m_XmlNodes[0]);
			int num = 1;
			while (num < this.m_XmlNodes.Count && !flag)
			{
				if (this.iGetNodeDisplayType(this.m_XmlNodes[num]) != displayType)
				{
					flag = true;
				}
				num++;
			}
			if (!flag)
			{
				return displayType;
			}
			return DisplayType.MIXED;
		}


		private DisplayType iGetNodeDisplayType(XmlNode node)
		{
			this.iGetActualNode(this.m_XmlNodes[0]);
			return (DisplayType)Enum.Parse(typeof(DisplayType), node.Attributes["display_type"].Value.ToUpper());
		}


		private FullPrecision iGetNodesFullPrecision()
		{
			bool flag = false;
			FullPrecision fullPrecision = this.iGetNodeFullPrecision(this.m_XmlNodes[0]);
			int num = 1;
			while (num < this.m_XmlNodes.Count && !flag)
			{
				if (this.iGetNodeFullPrecision(this.m_XmlNodes[num]) != fullPrecision)
				{
					flag = true;
				}
				num++;
			}
			if (!flag)
			{
				return fullPrecision;
			}
			return FullPrecision.MIXED;
		}


		private FullPrecision iGetNodeFullPrecision(XmlNode node)
		{
			if ('F' == node.InnerText[node.InnerText.Length - 1])
			{
				return FullPrecision.OFF;
			}
			return FullPrecision.ON;
		}


		private XmlNode iGetActualNode(XmlNode node)
		{
			if (GuiCore.GetNodeType(node) == NodeType.MAPPED_VAR)
			{
				return GuiCore.RegisterMapping[node];
			}
			return node;
		}


		private void iUpdateFixModeFullPrecision(FullPrecision full_precision)
		{
			string str;
			if (FullPrecision.ON == full_precision)
			{
				str = "T";
			}
			else
			{
				str = "F";
			}
			foreach (XmlNode xmlNode in this.m_XmlNodes)
			{
				xmlNode.InnerText = xmlNode.InnerText.Remove(xmlNode.InnerText.Length - 1);
				XmlNode xmlNode2 = xmlNode;
				xmlNode2.InnerText += str;
				GuiCore.ChangeVarsValue(xmlNode, xmlNode.InnerText);
			}
			GuiCore.RefreshGui();
			if (this.m_SubSet != null)
			{
				this.m_SubSet.RefreshDisplay();
			}
		}


		private void iTransmitMenuItem_Click(object sender, EventArgs e)
		{
			GuiCore.Transmit(this.m_XmlNodes, ReceiveTransmit_T.XML_PATH, false, this.m_SubSet);
		}


		private void iReceiveMenuItem_Click(object sender, EventArgs e)
		{
			GuiCore.Receive(this.m_XmlNodes, ReceiveTransmit_T.XML_PATH, false, this.m_SubSet);
		}


		private void iChangeMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ibAreAllFixMode())
			{
				UpdateDialog_FixMode_New update_dlg = new UpdateDialog_FixMode_New(this.m_XmlNodes);
				this.ChangeSelVarsValues(update_dlg);
				return;
			}
			UpdateDialog update_dlg2 = new UpdateDialog(this.m_XmlNodes);
			this.ChangeSelVarsValues(update_dlg2);
		}


		private void iSetCommentMenuItem_Click(object sender, EventArgs e)
		{
			if (new SetCommentDialog(this.m_XmlNodes).ShowDialog() == DialogResult.OK)
			{
				GuiCore.RefreshGui();
			}
		}


		private void iOnOffFullPrecisionMenuItem_Click(object sender, EventArgs e)
		{
			if (sender == this.m_OnFullPrecisionMenuItem)
			{
				this.iUpdateFixModeFullPrecision(FullPrecision.ON);
				return;
			}
			this.iUpdateFixModeFullPrecision(FullPrecision.OFF);
		}


		private void iLoadFromFileMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Open a vector text file";
			openFileDialog.Filter = "Vector text files (*.txt)|*.txt";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.ShowDialog();
			if (!string.IsNullOrEmpty(openFileDialog.FileName))
			{
				for (int i = 0; i < this.m_XmlNodes.Count; i++)
				{
					string text = openFileDialog.FileName.Replace('\\', '/');
					string pathFromNode = GuiCore.GetPathFromNode(this.m_XmlNodes[i]);
					GuiCore.VerbosePrint(string.Concat(new string[]
					{
						"RSTD.LoadVarFromFile (\"",
						pathFromNode,
						"\" , \"",
						text,
						"\")\n"
					}));
					GuiCore.LoadVarFromFile(pathFromNode, text);
				}
			}
		}


		private void iClockMenuItem_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.m_XmlNodes.Count; i++)
			{
				GuiCore.MainForm.browse_tree.MonitoredVars.AddMonitorVar(GuiCore.GetPathFromNode(this.m_XmlNodes[i]), (string)((ToolStripMenuItem)sender).Tag, "0", "1", "1");
			}
		}


		private void iRemoveFromMonitorMenuItem_Click(object sender, EventArgs e)
		{
			GuiCore.RemoveAfterValidateFromMonitor(this.m_XmlNodes);
		}


		private void iAddToWorkSetMenuItem_Click(object sender, EventArgs e)
		{
			GuiCore.WorkSet.AddNodesToWorkSet(this.m_XmlNodes);
		}


		private void iRemoveFromWorkSetMenuItem_Click(object sender, EventArgs e)
		{
			GuiCore.WorkSet.RemoveFromWorkSet(this.m_XmlNodes);
		}


		private void iCopyToClipBoard_Click(object sender, EventArgs e)
		{
			if (this.m_XmlNodes.Count == 1)
			{
				Clipboard.SetDataObject(GuiCore.GetPathFromNode(this.m_XmlNodes[0]), true);
			}
		}


		private void iDisplayAsMenuItem_Click(object sender, EventArgs e)
		{
			this.iUpdateNodesDisplayType((DisplayType)((ToolStripItem)sender).Tag);
		}


		private void iShowArrayMenuItem_Click(object sender, EventArgs e)
		{
			if (GuiCore.ValidateSameShowArrayOpenOnlyOnce(this.m_XmlNodes[0]))
			{
				new frmUpdateArrayDialog(this.m_XmlNodes).Show();
			}
		}


		private void iSaveMenuItem_Click(object sender, EventArgs e)
		{
			string text;
			if (GuiCore.SaveDialogTxtOrXml(this.m_XmlNodes, out text, false, null, null) && Path.GetExtension(text).Equals(".xml"))
			{
				RstdGuiSettings.Default.LastWorksetFile = text;
				RstdGuiSettings.Default.Save();
			}
		}


		private void iGotoFieldMenuItem_Click(object sender, EventArgs e)
		{
			XmlNode node = null;
			if (GuiCore.GetNodeType(this.m_XmlNodes[0]) == NodeType.MAPPED_VAR)
			{
				node = GuiCore.RegisterMapping[this.m_XmlNodes[0]];
			}
			if (GuiCore.GetNodeType(this.m_XmlNodes[0]) == NodeType.FIELD)
			{
				node = GuiCore.RegisterMapping.ReverseLookup(this.m_XmlNodes[0]);
			}
			GuiCore.bJumpToPath(node);
		}


		private void VariableContextMenu_Opening(object sender, CancelEventArgs e)
		{
			this.iUpdateChecks();
		}


		protected List<XmlNode> m_XmlNodes;


		private ToolStripMenuItem m_TransmitMenuItem;


		private ToolStripMenuItem m_ReceiveMenuItem;


		private ToolStripSeparator m_Separator1MenuItem;


		private ToolStripMenuItem m_ChangeMenuItem;


		private ToolStripMenuItem m_LoadFromFileMenuItem;


		private ToolStripSeparator m_Separator2MenuItem;


		private ToolStripMenuItem m_AddToMonitorMenuItem;


		private ToolStripMenuItem m_RemoveFromMonitorMenuItem;


		private ToolStripSeparator m_Separator3MenuItem;


		private ToolStripSeparator m_Separator4MenuItem;


		private ToolStripMenuItem m_AddToWorkSetMenuItem;


		private ToolStripMenuItem m_RemoveFromWorkSetMenuItem;


		private ToolStripMenuItem m_SetCommentMenuItem;


		private ToolStripMenuItem m_CopyPathToClipBoard;


		private ToolStripMenuItem m_ShowArrayMenuItem;


		private ToolStripMenuItem m_DisplayAsMenuItem;


		private ToolStripMenuItem m_DisplayAsDefaultMenuItem;


		private ToolStripMenuItem m_DisplayAsDecimalMenuItem;


		private ToolStripMenuItem m_DisplayAsDecimalSignedMenuItem;


		private ToolStripMenuItem m_DisplayAsHexMenuItem;


		private ToolStripMenuItem m_DisplayAsBinaryMenuItem;


		private ToolStripMenuItem m_DisplayAsIntMenuItem;


		private ToolStripMenuItem m_DisplayAsdb10MenuItem;


		private ToolStripMenuItem m_DisplayAsdb20MenuItem;


		private ToolStripMenuItem m_SaveMenuItem;


		private ToolStripMenuItem m_GotoFieldMenuItem;


		private ToolStripMenuItem m_OnOffFullPrecisionMenuItem;


		private ToolStripMenuItem m_OnFullPrecisionMenuItem;


		private ToolStripMenuItem m_OffFullPrecisionMenuItem;


		private List<ToolStripMenuItem> m_ClockMenuItems;


		private ToolStripMenuItem[] menu_display_as;


		private frmSubSet m_SubSet;
	}
}
