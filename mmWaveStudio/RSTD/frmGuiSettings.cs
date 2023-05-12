using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using LuaRegister;
using WeifenLuo.WinFormsUI.Docking;

namespace RSTD
{

	public partial class frmGuiSettings : Form
	{

		public frmGuiSettings(frmMain main_form)
		{
			this.InitializeComponent();
			this.m_MainForm = main_form;
			this.m_dockContents = null;
			this.m_idc = null;
			this.m_CurrentCellIndex = -1;
			this.m_PreviousSelectedIndex = -1;
			this.m_ClonedUserToolStrip = new List<UserToolStripInfo>();
			this.pathlinkLabel.Text = this.m_MainForm.SettingsOutputPath;
			this.iInitStandardButtonsImageList();
		}


		private void iInitStandardButtonsImageList()
		{
			this.m_lstStandardBtns.SmallImageList = new ImageList();
			this.m_lstStandardBtns.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
			for (int i = 0; i < this.m_MainForm.MainToolBar.Items.Count; i++)
			{
				ToolStripItem toolStripItem = this.m_MainForm.MainToolBar.Items[i];
				if (toolStripItem is ToolStripButton)
				{
					this.m_lstStandardBtns.SmallImageList.Images.Add(toolStripItem.Name, toolStripItem.Image);
				}
			}
		}


		public void UpdateForm(IDockContent idc)
		{
			this.CheckListBoxsUpdate(idc);
			this.iUpdateToolBarTab();
			this.iGetDefaultTypesSettings();
			this.m_PreviousSelectedIndex = -1;
			if (this.toolBarsComboBox.Items.Count > 0)
			{
				this.toolBarsComboBox.SelectedIndex = 0;
			}
		}


		private void iGetDefaultTypesSettings()
		{
			this.m_cboRegDefDisplay.SelectedIndex = this.iGetComboIndexForType(NodeType.REGISTER);
			this.m_cboFieldDefDisplay.SelectedIndex = this.iGetComboIndexForType(NodeType.FIELD);
		}


		private int iGetComboIndexForType(NodeType node_type)
		{
			int result = -1;
			switch (RstdGuiSettings.Default.DefaultTypesDict[node_type])
			{
			case DisplayType.DECIMAL:
				result = 0;
				break;
			case DisplayType.HEX:
				result = 1;
				break;
			case DisplayType.BINARY:
				result = 2;
				break;
			}
			return result;
		}


		private DisplayType iGetTypeFromComboIndex(int combo_index)
		{
			DisplayType result = DisplayType.DEFAULT;
			switch (combo_index)
			{
			case 0:
				result = DisplayType.DECIMAL;
				break;
			case 1:
				result = DisplayType.HEX;
				break;
			case 2:
				result = DisplayType.BINARY;
				break;
			}
			return result;
		}


		private void iUpdateToolBarTab()
		{
			this.rdoLargeButtons.Checked = (RstdGuiSettings.Default.StandardBtnsSize == StandardButtonsSize.LARGE);
			this.rdoSmallButtons.Checked = (RstdGuiSettings.Default.StandardBtnsSize == StandardButtonsSize.SMALL);
			this.iCopyToolStripList(RstdGuiSettings.Default.UserToolStrips, this.m_ClonedUserToolStrip);
			this.iUpdateStandardButtonsList();
			this.iSetToolBarComboBoxItems();
		}


		private void iCopyToolStripList(List<UserToolStripInfo> source, List<UserToolStripInfo> destination)
		{
			destination.Clear();
			foreach (UserToolStripInfo userToolStripInfo in source)
			{
				UserToolStripInfo userToolStripInfo2 = new UserToolStripInfo();
				userToolStripInfo2.Show = userToolStripInfo.Show;
				userToolStripInfo2.ToolBarBasePath = userToolStripInfo.ToolBarBasePath;
				userToolStripInfo2.ToolBarConfigFile = userToolStripInfo.ToolBarConfigFile;
				userToolStripInfo2.ToolBarName = userToolStripInfo.ToolBarName;
				foreach (UserButtonInfo userButtonInfo in userToolStripInfo.ToolBarUserButtons)
				{
					UserButtonInfo userButtonInfo2 = new UserButtonInfo();
					if (userButtonInfo.Icon != null)
					{
						userButtonInfo2.Icon = (Image)userButtonInfo.Icon.Clone();
					}
					else
					{
						userButtonInfo2.Icon = null;
					}
					userButtonInfo2.IconFile = userButtonInfo.IconFile;
					userButtonInfo2.Show = userButtonInfo.Show;
					userButtonInfo2.SourceType = userButtonInfo.SourceType;
					userButtonInfo2.Title = userButtonInfo.Title;
					userButtonInfo2.ToolTip = userButtonInfo.ToolTip;
					userButtonInfo2.UserButtonSource = userButtonInfo.UserButtonSource;
					userButtonInfo2.UserColor = userButtonInfo.UserColor;
					foreach (ScriptParam scriptParam in userButtonInfo.Params)
					{
						ScriptParam scriptParam2 = new ScriptParam();
						scriptParam2.Name = scriptParam.Name;
						scriptParam2.Type = scriptParam.Type;
						scriptParam2.Value = scriptParam.Value;
						userButtonInfo2.Params.Add(scriptParam2);
					}
					userToolStripInfo2.ToolBarUserButtons.Add(userButtonInfo2);
				}
				destination.Add(userToolStripInfo2);
			}
		}


		private void iSetToolBarComboBoxItems()
		{
			this.toolBarsComboBox.Items.Clear();
			foreach (object obj in this.m_MainForm.UserToolStripsList)
			{
				ToolStrip toolStrip = (ToolStrip)obj;
				this.toolBarsComboBox.Items.Add(toolStrip.Items[0].Text);
			}
		}


		private void iUpdateStandardButtonsList()
		{
			this.m_lstStandardBtns.Clear();
			for (int i = 0; i < this.m_MainForm.MainToolBar.Items.Count; i++)
			{
				ToolStripItem toolStripItem = this.m_MainForm.MainToolBar.Items[i];
				if (toolStripItem is ToolStripButton)
				{
					this.iAddStandardBtnToList(toolStripItem);
				}
			}
		}


		private void iAddStandardBtnToList(ToolStripItem btn)
		{
			ListViewItem value = new ListViewItem(btn.Text, btn.Name);
			this.m_lstStandardBtns.Items.Add(value);
			this.m_lstStandardBtns.Items[this.m_lstStandardBtns.Items.Count - 1].Checked = btn.Visible;
		}


		private void iUpdateUserButtonsGrid(int index)
		{
			this.m_dgvUserButtons.Rows.Clear();
			foreach (UserButtonInfo btn_info in this.m_ClonedUserToolStrip[index].ToolBarUserButtons)
			{
				this.iAddUserBtnToGrid(btn_info);
			}
		}


		private void iAddUserBtnToGrid(UserButtonInfo btn_info)
		{
			this.m_dgvUserButtons.Rows.Add();
			this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 2].Cells[this.colShow.Index].Value = btn_info.Show;
			this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 2].Cells[this.colIcon.Index].Value = btn_info.Icon;
			this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 2].Cells[this.colorColumn.Index].Style.BackColor = btn_info.UserColor;
			this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 2].Cells[this.colTitle.Index].Value = btn_info.Title;
			this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 2].Cells[this.colToolTip.Index].Value = btn_info.ToolTip;
			this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 2].Cells[this.colScript.Index].Value = btn_info.UserButtonSource;
			switch (btn_info.SourceType)
			{
			case LuaSourceType.File:
				this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 2].Cells[this.sourceTypeColumn.Index].Value = "File";
				break;
			case LuaSourceType.Function:
				this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 2].Cells[this.sourceTypeColumn.Index].Value = "Function";
				break;
			case LuaSourceType.LuaString:
				this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 2].Cells[this.sourceTypeColumn.Index].Value = "Inline";
				break;
			}
			this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 2].Tag = btn_info;
		}


		public void CheckListBoxsUpdate(IDockContent idc)
		{
			this.m_idc = idc;
			this.iCheckListBoxViewUpdate();
			this.CheckListBoxColumnsUpdate();
			this.CheckBoxGeneralUpdate();
		}


		public void CheckListBoxColumnsUpdate()
		{
			this.iCheckListBoxColumnsUpdate(this.m_chklbBTColumns, this.m_chkBTSortClmns, RstdGuiSettings.Default.bvisible_columns_in_browse_tree_arr, RstdGuiSettings.Default.IsSortBTColumns, RstdGuiSettings.Default.dBTColumnsOrderArr, 6);
			this.iCheckListBoxColumnsUpdate(this.m_chklbWSColumns, this.m_chkWSSortClmns, RstdGuiSettings.Default.bvisible_columns_in_work_set_arr, RstdGuiSettings.Default.IsSortWSColumns, RstdGuiSettings.Default.dWSColumnsOrderArr, 6);
		}


		private void iCheckListBoxColumnsUpdate(CheckedListBox chklb, CheckBox chkb_sort, bool[] visible_array, bool is_sort, int[] col_order_index, int num_columns)
		{
			CheckedListBox.ObjectCollection items = chklb.Items;
			for (int i = 0; i < num_columns; i++)
			{
				items[i] = RstdConstants.ListViewParseColumnNameToEnumVal(Enum.GetName(typeof(RstdConstants.ListViewSubItem_T), this.iGetColumnIndexFromListBoxIndex(i, col_order_index)));
				chklb.SetItemChecked(i, visible_array[this.iGetColumnIndexFromListBoxIndex(i, col_order_index)]);
			}
			chkb_sort.Checked = is_sort;
		}


		private void CheckBoxGeneralUpdate()
		{
			this.m_chktxtSaveDisplayAs.Checked = RstdGuiSettings.Default.bSaveDisplayAsForTxt;
			this.m_fadeOutSplashcheckBox.Checked = RstdGuiSettings.Default.bDisableFadeOutSplash;
		}


		private void iCheckListBoxViewUpdate()
		{
			this.iCheckListBoxViewToolBarsUpdate();
			this.iCheckListBoxViewWindowsUpdate();
		}


		private void iCheckListBoxViewWindowsUpdate()
		{
			DockContent[] array = new DockContent[]
			{
				this.m_MainForm.OutputForm,
				this.m_MainForm.browse_tree,
				this.m_MainForm.browse_tree.WorkSet,
				this.m_MainForm.browse_tree.MonitoredVars,
				this.m_MainForm.LuaShellForm
			};
			for (int i = 0; i < 5; i++)
			{
				this.iCheckListBoxViewWindowsVisibility(array[i], i);
			}
		}


		private void iCheckListBoxViewWindowsVisibility(DockContent dc, int index)
		{
			bool value = !dc.IsHidden;
			this.m_chklbViewWindows.SetItemChecked(index, value);
		}


		private void iCheckListBoxViewToolBarsUpdate()
		{
			for (int i = 0; i < 3; i++)
			{
				this.iCheckListBoxViewToolBarVisibility(i);
			}
			this.m_chkViewStatus.Checked = RstdGuiSettings.Default.CheckedToolBarsStatusBar;
		}


		private void iCheckListBoxViewToolBarVisibility(int index)
		{
			bool value = RstdGuiSettings.Default.CheckedToolBarsArr[index];
			this.m_chklbViewToolBars.SetItemChecked(index, value);
		}


		private void iUpdateWindowsVisiblity()
		{
			for (int i = 0; i < this.m_chklbViewWindows.Items.Count; i++)
			{
				bool itemChecked = this.m_chklbViewWindows.GetItemChecked(i);
				DockContent dockContent = this.iGetMatchingWindow(i);
				if (dockContent != null)
				{
					this.iSetWindowVisibility(dockContent, itemChecked);
				}
			}
		}


		private DockContent iGetMatchingWindow(int checkbox_index)
		{
			DockContent result = null;
			switch (checkbox_index)
			{
			case 0:
				result = this.m_MainForm.OutputForm;
				break;
			case 1:
				result = this.m_MainForm.browse_tree;
				break;
			case 2:
				result = this.m_MainForm.browse_tree.WorkSet;
				break;
			case 3:
				result = this.m_MainForm.browse_tree.MonitoredVars;
				break;
			case 4:
				result = this.m_MainForm.LuaShellForm;
				break;
			}
			return result;
		}


		private void iUpdateToolBarsVisibility()
		{
			for (int i = 0; i < this.m_chklbViewToolBars.Items.Count; i++)
			{
				bool itemChecked = this.m_chklbViewToolBars.GetItemChecked(i);
				RstdGuiSettings.Default.CheckedToolBarsArr[i] = itemChecked;
				ToolStrip toolStrip = this.iGetMatchingToolBar(i);
				if (toolStrip != null)
				{
					toolStrip.Visible = itemChecked;
				}
			}
		}


		private ToolStrip iGetMatchingToolBar(int checkbox_index)
		{
			ToolStrip result = null;
			switch (checkbox_index)
			{
			case 0:
				result = this.m_MainForm.MainToolBar;
				break;
			case 2:
				result = this.m_MainForm.BottomToolBar;
				break;
			}
			return result;
		}


		private void iUpdateStatusBarVisibility()
		{
			RstdGuiSettings.Default.CheckedToolBarsStatusBar = this.m_chkViewStatus.Checked;
			this.m_MainForm.StatusStrip.Visible = this.m_chkViewStatus.Checked;
		}


		private void iSetWindowVisibility(DockContent dc, bool is_visible)
		{
			if (is_visible)
			{
				this.m_MainForm.ShowWindow(dc);
				return;
			}
			this.m_MainForm.CloseContent(dc);
		}


		private void iUpdateColumnsVisibility(CheckedListBox clb, int index, bool[] bcheck_columns_visibility_arr, int[] col_order_index)
		{
			bool itemChecked = clb.GetItemChecked(index);
			bcheck_columns_visibility_arr[this.iGetColumnIndexFromListBoxIndex(index, col_order_index)] = itemChecked;
		}


		private bool iCheckBoxSortChanged(CheckBox chk_box, bool IsSort)
		{
			return chk_box.Checked;
		}


		private int iGetColumnIndexFromListBoxIndex(int index, int[] col_order_index)
		{
			int num = 0;
			for (int i = 0; i < col_order_index.Length; i++)
			{
				if (col_order_index[i] == index)
				{
					return num;
				}
				num++;
			}
			return -1;
		}


		private int iGetIntMatchForName(string Text)
		{
			if (Text.Equals(this.m_MainForm.OutputForm.TabText))
			{
				return 0;
			}
			if (Text.Equals(this.m_MainForm.browse_tree.TabText))
			{
				return 1;
			}
			if (Text.Equals(this.m_MainForm.browse_tree.WorkSet.TabText))
			{
				return 2;
			}
			if (Text.Equals(this.m_MainForm.browse_tree.MonitoredVars.TabText))
			{
				return 3;
			}
			if (Text.Equals(this.m_MainForm.LuaShellForm.TabText))
			{
				return 4;
			}
			return -1;
		}


		private string iGetEnumMatchForInt(int index, Type enum_type)
		{
			string value = index.ToString();
			return Enum.GetValues(enum_type).GetValue(Convert.ToInt32(value)).ToString();
		}


		private void iUpdateColumnsOrderArray(CheckedListBox chklb, Button btn, int num_columns, int[] order_col_array)
		{
			CheckedListBox.ObjectCollection items = chklb.Items;
			string value = string.Empty;
			for (int i = 0; i < num_columns; i++)
			{
				value = RstdConstants.ListViewParseColumnNameToEnumVal(Enum.GetName(typeof(RstdConstants.ListViewSubItem_T), i));
				order_col_array[i] = items.IndexOf(value);
			}
		}


		private void btn_OK_Click(object sender, EventArgs e)
		{
			this.m_dockContents = this.m_MainForm.DockingPanel.Contents;
			base.Hide();
			this.iUpdateWindowsVisiblity();
			this.iUpdateToolBarsVisibility();
			this.iUpdateStatusBarVisibility();
			int num = 0;
			while ((long)num < 6L)
			{
				this.iUpdateColumnsVisibility(this.m_chklbBTColumns, num, RstdGuiSettings.Default.bvisible_columns_in_browse_tree_arr, RstdGuiSettings.Default.dBTColumnsOrderArr);
				this.iUpdateColumnsVisibility(this.m_chklbWSColumns, num, RstdGuiSettings.Default.bvisible_columns_in_work_set_arr, RstdGuiSettings.Default.dWSColumnsOrderArr);
				num++;
			}
			RstdGuiSettings.Default.IsSortWSColumns = this.iCheckBoxSortChanged(this.m_chkWSSortClmns, RstdGuiSettings.Default.IsSortWSColumns);
			RstdGuiSettings.Default.IsSortBTColumns = this.iCheckBoxSortChanged(this.m_chkBTSortClmns, RstdGuiSettings.Default.IsSortBTColumns);
			this.m_MainForm.browse_tree.WorkSet.SetFunctionsDisplay(this.m_chkShowFunc.Checked);
			RstdGuiSettings.Default.DisplayFunctions = this.m_chkShowFunc.Checked;
			if (GuiCore.GetXmlTree() != null)
			{
				this.m_MainForm.browse_tree.UpdateBrowseTreeColumnsState();
				this.m_MainForm.browse_tree.UpdateWorkSetColumnsState();
			}
			if (this.m_idc != null)
			{
				int num2 = this.iGetIntMatchForName(this.m_idc.DockHandler.TabText);
				if (num2 > -1 && this.m_chklbViewWindows.GetItemChecked(num2))
				{
					this.m_idc.DockHandler.Activate();
				}
			}
			this.iUpdateStandardButtonsFromList();
			this.iUpdateStandardToolbarButtonsSize();
			if (this.toolBarsComboBox.SelectedIndex >= 0)
			{
				this.iUpdateUserButtonsFromGrid(this.toolBarsComboBox.SelectedIndex);
			}
			this.iCopyToolStripList(this.m_ClonedUserToolStrip, RstdGuiSettings.Default.UserToolStrips);
			this.m_MainForm.LoadUserToolStrips();
			this.iUpdateDefualtTypeSettings();
			RstdGuiSettings.Default.bSaveDisplayAsForTxt = this.m_chktxtSaveDisplayAs.Checked;
			RstdGuiSettings.Default.bDisableFadeOutSplash = this.m_fadeOutSplashcheckBox.Checked;
			RstdGuiSettings.Default.Save();
			this.m_MainForm.browse_tree.RefreshGui();
			base.DialogResult = DialogResult.OK;
		}


		private void iUpdateDefualtTypeSettings()
		{
			RstdGuiSettings.Default.DefaultTypesDict[NodeType.REGISTER] = this.iGetTypeFromComboIndex(this.m_cboRegDefDisplay.SelectedIndex);
			RstdGuiSettings.Default.DefaultTypesDict[NodeType.FIELD] = this.iGetTypeFromComboIndex(this.m_cboFieldDefDisplay.SelectedIndex);
		}


		private void iUpdateStandardButtonsFromList()
		{
			int num = 0;
			foreach (object obj in this.m_lstStandardBtns.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				bool flag = false;
				foreach (ToolBarBtnInfo toolBarBtnInfo in RstdGuiSettings.Default.StandardButtons)
				{
					if (toolBarBtnInfo.Title == listViewItem.Text)
					{
						toolBarBtnInfo.Show = listViewItem.Checked;
					}
				}
				int num2 = 0;
				while (num2 < this.m_MainForm.MainToolBar.Items.Count && !flag)
				{
					if (this.m_MainForm.MainToolBar.Items[num2] is ToolStripButton && this.m_MainForm.MainToolBar.Items[num2].Text == listViewItem.Text)
					{
						this.m_MainForm.MainToolBar.Items[num2].Visible = listViewItem.Checked;
						if (num2 != 0 && this.m_MainForm.MainToolBar.Items[num2 - 1] is ToolStripSeparator)
						{
							this.m_MainForm.MainToolBar.Items[num2 - 1].Visible = listViewItem.Checked;
						}
						num += (listViewItem.Checked ? 1 : 0);
						flag = true;
					}
					num2++;
				}
			}
		}


		private void iUpdateStandardToolbarButtonsSize()
		{
			if (this.rdoLargeButtons.Checked)
			{
				RstdGuiSettings.Default.StandardBtnsSize = StandardButtonsSize.LARGE;
			}
			else
			{
				RstdGuiSettings.Default.StandardBtnsSize = StandardButtonsSize.SMALL;
			}
			this.m_MainForm.UpdateStandardToolbarButtonsSize();
		}


		private void iUpdateUserButtonsFromGrid(int index)
		{
			this.m_ClonedUserToolStrip[index].ToolBarUserButtons.Clear();
			for (int i = 0; i < this.m_dgvUserButtons.Rows.Count - 1; i++)
			{
				DataGridViewRow dataGridViewRow = this.m_dgvUserButtons.Rows[i];
				UserButtonInfo userButtonInfo = new UserButtonInfo();
				userButtonInfo.Show = (bool)dataGridViewRow.Cells[this.colShow.Index].Value;
				userButtonInfo.Icon = (Image)dataGridViewRow.Cells[this.colIcon.Index].Value;
				userButtonInfo.UserColor = dataGridViewRow.Cells[this.colorColumn.Index].Style.BackColor;
				if (dataGridViewRow.Cells[this.colTitle.Index].Value != null)
				{
					userButtonInfo.Title = dataGridViewRow.Cells[this.colTitle.Index].Value.ToString();
				}
				if (dataGridViewRow.Cells[this.colToolTip.Index].Value != null)
				{
					userButtonInfo.ToolTip = dataGridViewRow.Cells[this.colToolTip.Index].Value.ToString();
				}
				if (dataGridViewRow.Cells[this.colScript.Index].Value != null)
				{
					userButtonInfo.UserButtonSource = dataGridViewRow.Cells[this.colScript.Index].Value.ToString();
				}
				string a = dataGridViewRow.Cells[this.sourceTypeColumn.Index].Value.ToString();
				if (!(a == "File"))
				{
					if (!(a == "Function"))
					{
						if (a == "Inline")
						{
							userButtonInfo.SourceType = LuaSourceType.LuaString;
						}
					}
					else
					{
						userButtonInfo.SourceType = LuaSourceType.Function;
					}
				}
				else
				{
					userButtonInfo.SourceType = LuaSourceType.File;
				}
				userButtonInfo.Params = ((UserButtonInfo)dataGridViewRow.Tag).Params;
				this.m_ClonedUserToolStrip[index].ToolBarUserButtons.Add(userButtonInfo);
			}
		}


		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Hide();
		}


		private void frmGuiSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			base.Hide();
		}


		private void iValidateMoveUp(Button btn)
		{
			if (this.m_CurrentCellIndex > 0)
			{
				btn.Enabled = true;
				return;
			}
			if (this.m_CurrentCellIndex == 0)
			{
				btn.Enabled = false;
			}
		}


		private void iValidateMoveDown(Button btn, int num_columns)
		{
			if (this.m_CurrentCellIndex < num_columns - 1)
			{
				btn.Enabled = true;
				return;
			}
			if (this.m_CurrentCellIndex == num_columns - 1)
			{
				btn.Enabled = false;
			}
		}


		private void iReorderColumnsMoveUp(CheckedListBox chk_list_box, int[] col_order_array, Button btn_up, Button btn_down, int num_columns)
		{
			string value = string.Empty;
			int currentCellIndex = this.m_CurrentCellIndex;
			CheckedListBox.ObjectCollection items = chk_list_box.Items;
			value = items[currentCellIndex - 1].ToString();
			bool itemChecked = chk_list_box.GetItemChecked(currentCellIndex - 1);
			items[currentCellIndex - 1] = items[currentCellIndex].ToString();
			chk_list_box.SetItemChecked(currentCellIndex - 1, chk_list_box.GetItemChecked(currentCellIndex));
			items[currentCellIndex] = value;
			chk_list_box.SetItemChecked(currentCellIndex, itemChecked);
			chk_list_box.SetSelected(this.m_CurrentCellIndex - 1, true);
			this.m_CurrentCellIndex--;
			this.iValidateMoveUp(btn_up);
			this.iValidateMoveDown(btn_down, num_columns);
			this.iUpdateColumnsOrderArray(chk_list_box, btn_up, num_columns, col_order_array);
		}


		private void iReorderColumnsMoveDown(CheckedListBox chk_list_box, int[] col_order_array, Button btn_up, Button btn_down, int num_columns)
		{
			string value = string.Empty;
			int currentCellIndex = this.m_CurrentCellIndex;
			CheckedListBox.ObjectCollection items = chk_list_box.Items;
			value = items[currentCellIndex + 1].ToString();
			bool itemChecked = chk_list_box.GetItemChecked(currentCellIndex + 1);
			items[currentCellIndex + 1] = items[currentCellIndex].ToString();
			chk_list_box.SetItemChecked(currentCellIndex + 1, chk_list_box.GetItemChecked(currentCellIndex));
			items[currentCellIndex] = value;
			chk_list_box.SetItemChecked(currentCellIndex, itemChecked);
			chk_list_box.SetSelected(this.m_CurrentCellIndex + 1, true);
			this.m_CurrentCellIndex++;
			this.iValidateMoveUp(btn_up);
			this.iValidateMoveDown(btn_down, num_columns);
			this.iUpdateColumnsOrderArray(chk_list_box, btn_down, num_columns, col_order_array);
		}


		private void m_btnBTMoveUp_Click(object sender, EventArgs e)
		{
			if (this.m_chklbBTColumns.SelectedIndex != -1)
			{
				this.iReorderColumnsMoveUp(this.m_chklbBTColumns, RstdGuiSettings.Default.dBTColumnsOrderArr, this.m_btnBTMoveUp, this.m_btnBTMoveDown, 6);
			}
			this.m_MainForm.browse_tree.UpdateBrowseTreeColumnsState();
		}


		private void m_chklbBT_MouseClick(object sender, MouseEventArgs e)
		{
			this.m_CurrentCellIndex = this.m_chklbBTColumns.IndexFromPoint(e.Location);
			this.iValidateMoveUp(this.m_btnBTMoveUp);
			this.iValidateMoveDown(this.m_btnBTMoveDown, 6);
		}


		private void m_btnWSMoveUp_Click(object sender, EventArgs e)
		{
			if (this.m_chklbWSColumns.SelectedIndex != -1)
			{
				this.iReorderColumnsMoveUp(this.m_chklbWSColumns, RstdGuiSettings.Default.dWSColumnsOrderArr, this.m_btnWSMoveUp, this.m_btnWSMoveDown, 6);
			}
			this.m_MainForm.browse_tree.UpdateWorkSetColumnsState();
		}


		private void m_chklbWS_MouseClick(object sender, MouseEventArgs e)
		{
			this.m_CurrentCellIndex = this.m_chklbWSColumns.IndexFromPoint(e.Location);
			this.iValidateMoveUp(this.m_btnWSMoveUp);
			this.iValidateMoveDown(this.m_btnWSMoveDown, 6);
		}


		private void m_btnBTMoveDown_Click(object sender, EventArgs e)
		{
			if (this.m_chklbBTColumns.SelectedIndex != -1)
			{
				this.iReorderColumnsMoveDown(this.m_chklbBTColumns, RstdGuiSettings.Default.dBTColumnsOrderArr, this.m_btnBTMoveUp, this.m_btnBTMoveDown, 6);
			}
			this.m_MainForm.browse_tree.UpdateBrowseTreeColumnsState();
		}


		private void m_btnWSMoveDown_Click(object sender, EventArgs e)
		{
			if (this.m_chklbWSColumns.SelectedIndex != -1)
			{
				this.iReorderColumnsMoveDown(this.m_chklbWSColumns, RstdGuiSettings.Default.dWSColumnsOrderArr, this.m_btnWSMoveUp, this.m_btnWSMoveDown, 6);
			}
			this.m_MainForm.browse_tree.UpdateWorkSetColumnsState();
		}


		private void dgvToolBarButtons_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != this.m_dgvUserButtons.Rows.Count - 1 && e.ColumnIndex == this.colBrowse.Index)
			{
				string value = GuiCore.OpenFileDialog(null, FileType.SCRIPT);
				if (!string.IsNullOrEmpty(value))
				{
					this.m_dgvUserButtons.Rows[e.RowIndex].Cells[this.colScript.Index].Value = value;
				}
			}
		}


		private void frmGuiSettings_Load(object sender, EventArgs e)
		{
			this.colIcon.DefaultCellStyle.NullValue = null;
			this.m_chkShowFunc.Checked = RstdGuiSettings.Default.DisplayFunctions;
		}


		private void m_dgvUserButtons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != this.m_dgvUserButtons.Rows.Count - 1 && e.ColumnIndex == this.colIcon.Index)
			{
				Image imageFromFile = GuiCore.GetImageFromFile(GuiCore.OpenFileDialog(null, FileType.ICON));
				if (imageFromFile != null)
				{
					this.m_dgvUserButtons.Rows[e.RowIndex].Cells[this.colIcon.Index].Value = imageFromFile;
					return;
				}
			}
			else if (e.RowIndex != this.m_dgvUserButtons.Rows.Count - 1 && e.ColumnIndex == this.colorColumn.Index)
			{
				ColorDialog colorDialog = new ColorDialog();
				colorDialog.FullOpen = true;
				if (colorDialog.ShowDialog() == DialogResult.OK)
				{
					this.m_dgvUserButtons.Rows[e.RowIndex].Cells[this.colorColumn.Index].Style.BackColor = colorDialog.Color;
				}
			}
		}


		private void m_dgvUserButtons_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 1].Cells[this.colIcon.Index].Value = null;
			this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 1].Cells[this.colShow.Index].Value = false;
			this.m_dgvUserButtons.Rows[this.m_dgvUserButtons.Rows.Count - 1].Cells[this.sourceTypeColumn.Index].Value = LuaSourceType.File.ToString();
		}


		private void m_dgvUserButtons_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.m_dgvUserButtons.SelectedCells.Count == 1 && this.m_dgvUserButtons.SelectedCells[0].ColumnIndex == this.colIcon.Index)
			{
				this.m_dgvUserButtons.SelectedCells[0].Value = null;
			}
		}


		private void toolBarsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.m_PreviousSelectedIndex > -1)
			{
				this.iUpdateUserButtonsFromGrid(this.m_PreviousSelectedIndex);
			}
			this.iUpdateUserButtonsGrid(this.toolBarsComboBox.SelectedIndex);
			this.m_PreviousSelectedIndex = this.toolBarsComboBox.SelectedIndex;
		}


		private void pathlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(this.pathlinkLabel.Text);
		}


		private frmMain m_MainForm;


		private DockContentCollection m_dockContents;


		private IDockContent m_idc;


		private int m_CurrentCellIndex;


		private List<UserToolStripInfo> m_ClonedUserToolStrip;


		private int m_PreviousSelectedIndex;
	}
}
