using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using RSTD.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace RSTD
{

	public partial class frmRecord : DockContent
	{

		public frmRecord(frmMain main_form)
		{
			this.InitializeComponent();
			base.HideOnClose = true;
			this.m_MainForm = main_form;
			this.iSetDateFormat();
		}


		private void m_RecordToolStripButton_Click(object sender, EventArgs e)
		{
			if (this.m_RecordToolStripButton.Checked)
			{
				this.m_RecordToolStripButton.Image = Resources.stop_button;
				this.m_RecordToolStripButton.Text = "Disable";
				LuaWrapperUtils.LuaWrapper.IsMacroOn = true;
				return;
			}
			this.m_RecordToolStripButton.Image = Resources.record_button;
			this.m_RecordToolStripButton.Text = "Enable";
			LuaWrapperUtils.LuaWrapper.IsMacroOn = false;
		}


		private void m_ClearToolStripButton_Click(object sender, EventArgs e)
		{
			this.m_lstCommands.Items.Clear();
		}


		private void m_btnTimeFormat_Click(object sender, EventArgs e)
		{
			this.m_btnShowDate.Checked = !this.m_btnShowDate.Checked;
			if (this.m_btnShowDate.Checked)
			{
				this.m_btnShowDate.ToolTipText = "Hide Date";
			}
			else
			{
				this.m_btnShowDate.ToolTipText = "Show Date";
			}
			this.iSetDateFormat();
			foreach (object obj in this.m_lstCommands.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				listViewItem.SubItems[this.colTime.Index].Text = ((RecordItem)listViewItem.Tag).TimeStamp.ToString(this.m_TimeFormat);
			}
			this.m_lstCommands.Columns[this.colTime.Index].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
		}


		private void m_SaveToolStripButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save To Lua File";
			saveFileDialog.Filter = "Lua shell commands file (*.lua)|*.lua";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				TextWriter textWriter = null;
				try
				{
					textWriter = new StreamWriter(saveFileDialog.FileName);
					foreach (object obj in this.m_lstCommands.Items)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						if (((RecordItem)listViewItem.Tag).Deleted)
						{
							textWriter.Write("--");
							textWriter.WriteLine(listViewItem.SubItems[this.colCommand.Index].Text);
						}
						else
						{
							textWriter.WriteLine(listViewItem.SubItems[this.colCommand.Index].Text);
						}
					}
				}
				catch (Exception ex)
				{
					new frmHandleMsg(ex.Message, ex.StackTrace, RstdConstants.MESSAGE_TYPE.OK_ERROR, "Error", RstdConstants.CORE_MSG_BTN.OK, SystemIcons.Error).ShowDialog(this.m_MainForm);
				}
				finally
				{
					if (textWriter != null)
					{
						textWriter.Close();
					}
				}
			}
		}


		private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.m_lstCommands.SelectedItems.Count > 0)
			{
				this.m_lstCommands.BeginUpdate();
				foreach (object obj in this.m_lstCommands.SelectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					if (!((RecordItem)listViewItem.Tag).Deleted)
					{
						listViewItem.SubItems[this.colOperation.Index].Font = new Font("Microsoft Sans Serif", 8.25f, listViewItem.SubItems[this.colOperation.Index].Font.Style | FontStyle.Strikeout, GraphicsUnit.Point, 0);
						listViewItem.SubItems[this.colOperation.Index].ForeColor = Color.LightGray;
						listViewItem.SubItems[this.colCommand.Index].Font = new Font("Microsoft Sans Serif", 8.25f, listViewItem.SubItems[this.colCommand.Index].Font.Style | FontStyle.Strikeout, GraphicsUnit.Point, 0);
						listViewItem.SubItems[this.colCommand.Index].ForeColor = Color.LightGray;
						((RecordItem)listViewItem.Tag).Deleted = true;
					}
				}
				this.m_lstCommands.EndUpdate();
			}
		}


		private void undoDeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.m_lstCommands.SelectedItems.Count > 0)
			{
				this.m_lstCommands.BeginUpdate();
				foreach (object obj in this.m_lstCommands.SelectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					if (((RecordItem)listViewItem.Tag).Deleted)
					{
						listViewItem.SubItems[this.colOperation.Index].Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
						listViewItem.SubItems[this.colOperation.Index].ForeColor = Color.Black;
						listViewItem.SubItems[this.colCommand.Index].Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
						listViewItem.SubItems[this.colCommand.Index].ForeColor = Color.Black;
						((RecordItem)listViewItem.Tag).Deleted = false;
					}
				}
				this.m_lstCommands.EndUpdate();
			}
		}


		private void m_CommandsListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.C)
			{
				this.iCopyItems();
			}
		}


		public void AddCommand(string module_name, string op_name, string command)
		{
			this.m_lstCommands.BeginUpdate();
			RecordItem recordItem = new RecordItem(DateTime.Now, module_name, op_name, command);
			string text = recordItem.TimeStamp.ToString(this.m_TimeFormat);
			ListViewItem listViewItem = new ListViewItem(new string[]
			{
				text,
				module_name,
				recordItem.OpName,
				recordItem.Command
			});
			listViewItem.Tag = recordItem;
			listViewItem.UseItemStyleForSubItems = false;
			listViewItem.SubItems[this.colOperation.Index].Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.m_lstCommands.Items.Add(listViewItem);
			this.m_lstCommands.EnsureVisible(this.m_lstCommands.Items.Count - 1);
			this.m_lstCommands.SelectedItems.Clear();
			this.m_lstCommands.Items[this.m_lstCommands.Items.Count - 1].Selected = true;
			this.m_lstCommands.Columns[this.colTime.Index].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			this.m_lstCommands.Columns[this.colOperation.Index].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			this.m_lstCommands.EndUpdate();
		}


		private void iCopyItems()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (object obj in this.m_lstCommands.SelectedItems)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				stringBuilder.Append(listViewItem.SubItems[this.colCommand.Index].Text);
				stringBuilder.Append("\n");
			}
			if (stringBuilder.Length > 0)
			{
				Clipboard.Clear();
				Clipboard.SetText(stringBuilder.ToString());
			}
		}


		private void iSetDateFormat()
		{
			if (this.m_btnShowDate.Checked)
			{
				this.m_TimeFormat = "dd/MM/yy HH:mm:ss.fff";
				return;
			}
			this.m_TimeFormat = "HH:mm:ss.fff";
		}


		private frmMain m_MainForm;


		private string m_TimeFormat;
	}
}
