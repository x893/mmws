using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	internal class FolderContextMenu : ContextMenuStrip
	{

		public FolderContextMenu(string[] fullPaths)
		{
			this.m_FullPaths = fullPaths;
			this.m_TransmitMenuItem = new ToolStripMenuItem("Transmit Selection", TreeIcons.tx);
			this.m_ReceiveMenuItem = new ToolStripMenuItem("Receive Selection", TreeIcons.refresh);
			this.m_SaveMenuItem = new ToolStripMenuItem("Save", TreeIcons.diskette);
			this.m_FindMenuItem = new ToolStripMenuItem("Find", TreeIcons.find);
			this.m_CopyToClipBoard = new ToolStripMenuItem("Copy path to clipboard", TreeIcons.copy);
			this.m_SeparatorMenuItem = new ToolStripSeparator();
			this.Items.Add(this.m_TransmitMenuItem);
			this.Items.Add(this.m_ReceiveMenuItem);
			this.Items.Add(this.m_SeparatorMenuItem);
			this.Items.Add(this.m_FindMenuItem);
			this.Items.Add(this.m_SaveMenuItem);
			this.Items.Add(this.m_CopyToClipBoard);
			if (fullPaths.Length > 1)
			{
				this.m_SaveMenuItem.Enabled = false;
				this.m_FindMenuItem.Enabled = false;
			}
			this.m_TransmitMenuItem.Click += this.iTransmitMenuItem_Click;
			this.m_ReceiveMenuItem.Click += this.iReceiveMenuItem_Click;
			this.m_SaveMenuItem.Click += this.iSaveMenuItem_Click;
			this.m_FindMenuItem.Click += this.iFindMenuItem_Click;
			this.m_CopyToClipBoard.Click += this.iCopyToClipBoard_Click;
			base.Show(Control.MousePosition);
		}


		~FolderContextMenu()
		{
			this.Items.Clear();
			this.m_TransmitMenuItem = null;
			this.m_ReceiveMenuItem = null;
			this.m_SaveMenuItem = null;
			this.m_FindMenuItem = null;
			this.m_SeparatorMenuItem = null;
		}


		private void iTransmitMenuItem_Click(object sender, EventArgs e)
		{
			GuiCore.Transmit(this.m_FullPaths, ReceiveTransmit_T.XML_PATH, false);
		}


		private void iReceiveMenuItem_Click(object sender, EventArgs e)
		{
			GuiCore.Receive(this.m_FullPaths, ReceiveTransmit_T.XML_PATH, false);
		}


		private void iSaveMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			List<XmlNode> nodeListFromPath = GuiCore.GetNodeListFromPath(this.m_FullPaths[0]);
			saveFileDialog.Title = "Select destination file...";
			saveFileDialog.Filter = "XML Tree Data Values files (*.xml)|*.xml";
			SaveFileDialog saveFileDialog2 = saveFileDialog;
			saveFileDialog2.Filter += "|Csv Files (*.csv)|*.csv";
			saveFileDialog.RestoreDirectory = true;
			if (DialogResult.OK == saveFileDialog.ShowDialog())
			{
				if (Path.GetExtension(saveFileDialog.FileName).Equals(".csv"))
				{
					GuiCore.Save2Csv(saveFileDialog.FileName, nodeListFromPath, false, null, null);
					return;
				}
				GuiCore.Save(this.m_FullPaths[0], saveFileDialog.FileName);
			}
		}


		private void iFindMenuItem_Click(object sender, EventArgs e)
		{
			GuiCore.OpenFindForm(this.m_FullPaths[0]);
		}


		private void iCopyToClipBoard_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(this.m_FullPaths[0], true);
		}


		protected string[] m_FullPaths;


		private ToolStripMenuItem m_TransmitMenuItem;


		private ToolStripMenuItem m_ReceiveMenuItem;


		private ToolStripMenuItem m_SaveMenuItem;


		private ToolStripMenuItem m_FindMenuItem;


		private ToolStripSeparator m_SeparatorMenuItem;


		private ToolStripMenuItem m_CopyToClipBoard;
	}
}
