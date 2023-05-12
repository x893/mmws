using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LuaInterface;

namespace RSTD
{

	public partial class FolderBrowseDialog : Form
	{



		public LuaTable Folders
		{
			get
			{
				return this.m_Folders;
			}
			set
			{
				this.m_Folders = value;
			}
		}


		public FolderBrowseDialog()
		{
			this.InitializeComponent();
			this.m_StringFolders = new List<string>();
			this.PopulateDrives();
		}


		private void m_CancelButton_Click(object sender, EventArgs e)
		{
			base.Close();
		}


		private void m_OkButton_Click(object sender, EventArgs e)
		{
			if (this.m_StringFolders.Count == 0)
			{
				base.Close();
				return;
			}
			StringBuilder stringBuilder = new StringBuilder("{");
			foreach (string text in this.m_StringFolders)
			{
				string value = text.Replace("\\", "\\\\");
				stringBuilder.Append("\"");
				stringBuilder.Append(value);
				stringBuilder.Append("\",");
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			stringBuilder.Append("}");
			string chunk = string.Format("local out_table = {0} return out_table", stringBuilder.ToString());
			this.m_Folders = (LuaTable)LuaWrapperUtils.LuaWrapper.LuaVM.DoString(chunk)[0];
			base.Close();
		}


		private void m_FolderTreeView_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Checked)
			{
				this.m_StringFolders.Add(e.Node.FullPath);
				return;
			}
			this.m_StringFolders.Remove(e.Node.FullPath);
		}


		private void m_FolderTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node.Nodes[0].Text == "")
			{
				this.PopulateDirectories(e.Node);
			}
		}


		private void PopulateDrives()
		{
			foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
			{
				if (driveInfo.IsReady)
				{
					TreeNode treeNode = new TreeNode();
					switch (driveInfo.DriveType)
					{
					case DriveType.Removable:
						treeNode.ImageIndex = 3;
						treeNode.SelectedImageIndex = 3;
						break;
					case DriveType.Fixed:
						treeNode.ImageIndex = 0;
						treeNode.SelectedImageIndex = 0;
						break;
					case DriveType.Network:
						treeNode.ImageIndex = 4;
						treeNode.SelectedImageIndex = 4;
						break;
					case DriveType.CDRom:
						treeNode.ImageIndex = 2;
						treeNode.SelectedImageIndex = 2;
						break;
					default:
						treeNode.ImageIndex = 0;
						treeNode.SelectedImageIndex = 0;
						break;
					}
					try
					{
						DirectoryInfo[] directories = new DirectoryInfo(driveInfo.Name).GetDirectories();
						new TreeNode();
						treeNode.Text = driveInfo.Name;
						if (directories.Length != 0)
						{
							treeNode.Nodes.Add("");
						}
						this.m_FolderTreeView.Nodes.Add(treeNode);
					}
					catch (UnauthorizedAccessException)
					{
						new TreeNode();
						treeNode.Text = driveInfo.Name;
						treeNode.ImageIndex = 5;
						treeNode.SelectedImageIndex = 5;
						this.m_FolderTreeView.Nodes.Add(treeNode);
					}
				}
			}
		}


		private void PopulateDirectories(TreeNode parentNode)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(parentNode.FullPath);
			parentNode.Nodes[0].Remove();
			foreach (DirectoryInfo directoryInfo2 in directoryInfo.GetDirectories())
			{
				try
				{
					DirectoryInfo[] directories2 = directoryInfo2.GetDirectories();
					TreeNode treeNode = new TreeNode();
					treeNode.Text = directoryInfo2.Name;
					if (directories2.Length != 0)
					{
						treeNode.Nodes.Add("");
					}
					treeNode.ImageIndex = 1;
					treeNode.SelectedImageIndex = 1;
					parentNode.Nodes.Add(treeNode);
				}
				catch (UnauthorizedAccessException)
				{
					TreeNode treeNode2 = new TreeNode();
					treeNode2.Text = directoryInfo2.Name;
					treeNode2.ImageIndex = 5;
					treeNode2.SelectedImageIndex = 5;
					parentNode.Nodes.Add(treeNode2);
				}
			}
		}


		private List<string> m_StringFolders;
		private LuaTable m_Folders;
	}
}
