using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	internal class MonitorContextMenu : ContextMenuStrip
	{

		public MonitorContextMenu(MonitoredVars mv, PassedVarData dataPassed, RstdConstants.CONTEXT_MENU_ORIGIN var_menu_display)
		{
			this.m_MonitorVars = mv;
			this.m_XmlNodes = dataPassed.XmlNodes;
			this.m_GotoMenuItem = new ToolStripMenuItem("GoTo");
			this.m_Separator1MenuItem = new ToolStripSeparator();
			this.m_Separator2MenuItem = new ToolStripSeparator();
			this.m_RemoveFromMonitorMenuItem = new ToolStripMenuItem("Remove From Monitor");
			this.m_AddToWorkSetMenuItem = new ToolStripMenuItem("Add To WorkSet");
			this.m_RemoveFromWorkSetMenuItem = new ToolStripMenuItem("Remove From WorkSet");
			if (1 == dataPassed.XmlNodes.Count)
			{
				this.m_CopyPathToClipBoard = new ToolStripMenuItem("Copy path to clipboard", TreeIcons.copy);
			}
			this.m_ShowArrayMenuItem = new ToolStripMenuItem("Show Array");
			this.m_SaveMenuItem = new ToolStripMenuItem("Save ...", TreeIcons.diskette);
			this.Items.Add(this.m_GotoMenuItem);
			this.Items.Add(this.m_Separator1MenuItem);
			this.Items.Add(this.m_RemoveFromMonitorMenuItem);
			this.Items.Add(this.m_Separator2MenuItem);
			this.Items.Add(this.m_AddToWorkSetMenuItem);
			this.Items.Add(this.m_RemoveFromWorkSetMenuItem);
			if (1 == this.m_XmlNodes.Count)
			{
				this.Items.Add(this.m_CopyPathToClipBoard);
			}
			this.Items.Add(this.m_ShowArrayMenuItem);
			this.Items.Add(this.m_SaveMenuItem);
			if (this.m_XmlNodes.Count > 1)
			{
				this.m_GotoMenuItem.Enabled = false;
			}
			this.m_GotoMenuItem.Click += this.iGotoMenuItem_Click;
			this.m_RemoveFromMonitorMenuItem.Click += this.iRemoveFromMonitorMenuItem_Click;
			this.m_AddToWorkSetMenuItem.Click += this.iAddToWorkSetMenuItem_Click;
			this.m_RemoveFromWorkSetMenuItem.Click += this.iRemoveFromWorkSetMenuItem_Click;
			if (1 == this.m_XmlNodes.Count)
			{
				this.m_CopyPathToClipBoard.Click += this.iCopyToClipBoard_Click;
			}
			this.m_ShowArrayMenuItem.Click += this.iShowArrayMenuItem_Click;
			this.m_SaveMenuItem.Click += this.iSaveMenuItem_Click;
			base.Show(Control.MousePosition);
		}


		~MonitorContextMenu()
		{
			this.m_XmlNodes = null;
			this.Items.Clear();
			this.m_GotoMenuItem = null;
			this.m_RemoveFromMonitorMenuItem = null;
			this.m_AddToWorkSetMenuItem = null;
			this.m_RemoveFromWorkSetMenuItem = null;
			this.m_CopyPathToClipBoard = null;
			this.m_ShowArrayMenuItem = null;
			this.m_SaveMenuItem = null;
			this.m_Separator1MenuItem = null;
			this.m_Separator2MenuItem = null;
		}


		private void iGotoMenuItem_Click(object sender, EventArgs e)
		{
			GuiCore.bJumpToPath(this.m_XmlNodes[0]);
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


		private void iShowArrayMenuItem_Click(object sender, EventArgs e)
		{
			if (GuiCore.ValidateSameShowArrayOpenOnlyOnce(this.m_XmlNodes[0]))
			{
				new frmUpdateArrayDialog(this.m_XmlNodes).Show();
			}
		}


		private void iSaveMenuItem_Click(object sender, EventArgs e)
		{
			this.m_MonitorVars.MonitorSave(false);
		}


		private ToolStripMenuItem m_GotoMenuItem;


		private ToolStripMenuItem m_RemoveFromMonitorMenuItem;


		private ToolStripMenuItem m_AddToWorkSetMenuItem;


		private ToolStripMenuItem m_RemoveFromWorkSetMenuItem;


		private ToolStripMenuItem m_CopyPathToClipBoard;


		private ToolStripMenuItem m_ShowArrayMenuItem;


		private ToolStripMenuItem m_SaveMenuItem;


		private ToolStripSeparator m_Separator1MenuItem;


		private ToolStripSeparator m_Separator2MenuItem;


		protected List<XmlNode> m_XmlNodes;


		private MonitoredVars m_MonitorVars;
	}
}
