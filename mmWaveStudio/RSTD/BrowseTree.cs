using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using RSTD.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace RSTD
{
	public partial class BrowseTree : DockContent
	{
		internal object AutoUpdateListLocker
		{
			get
			{
				return this.m_AutoUpdateListLocker;
			}
			set
			{
				this.m_AutoUpdateListLocker = value;
			}
		}

		public object LockerAutoUpdateTimer
		{
			get
			{
				return this.m_LockerAutoUpdateTimer;
			}
			set
			{
				this.m_LockerAutoUpdateTimer = value;
			}
		}

		public BrowseTree(frmMain main_form)
		{
			this.InitializeComponent();
			base.HideOnClose = true;
			this.m_IsBrowseTreeBuilding = false;
			this.m_AutoUpdateListLocker = new object();
			this.m_LockerAutoUpdateTimer = new object();
			this.m_AutoUpdateList = new List<string>();
			this.m_MonitoredVars = new MonitoredVars();
			this.m_WorkSet = new frmWorkSet();
			this.m_SubsetList = new List<frmSubSet>();
			this.m_MainForm = main_form;
			this.m_Version = "";
			this.CreateHandle();
		}

		public TabControl TabControl
		{
			get
			{
				return this.m_TabControl;
			}
			set
			{
				this.m_TabControl = value;
			}
		}

		public ToolStripStatusLabel lblQuickFind
		{
			get
			{
				return this.m_lblQuickFind;
			}
			set
			{
				this.m_lblQuickFind = value;
			}
		}

		public frmWorkSet WorkSet
		{
			get
			{
				return this.m_WorkSet;
			}
		}

		public MonitoredVars MonitoredVars
		{
			get
			{
				return this.m_MonitoredVars;
			}
		}

		public System.Timers.Timer AutoUpdateTimer
		{
			get
			{
				return this.m_AutoUpdateTimer;
			}
		}

		public List<string> AutoUpdateList
		{
			get
			{
				return this.m_AutoUpdateList;
			}
			set
			{
				this.m_AutoUpdateList = value;
			}
		}

		public string Version
		{
			get
			{
				return this.m_Version;
			}
			set
			{
				this.m_Version = value;
			}
		}

		public bool IsBrowseTreeBuilding
		{
			get
			{
				return this.m_IsBrowseTreeBuilding;
			}
		}

		public void Build()
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel method = new BrowseTree.GuiOperDel(this.Build);
				base.Invoke(method);
				return;
			}
			if (GuiCore.GetXmlTree() != null)
			{
				this.m_IsBrowseTreeBuilding = true;
				this.m_TabControl.TabPages.Clear();
				XmlNodeList elementsByTagName = GuiCore.GetXmlTree().GetElementsByTagName("Tab");
				for (int i = 0; i < elementsByTagName.Count; i++)
				{
					TabTreePage value = new TabTreePage(elementsByTagName[i]);
					this.m_TabControl.TabPages.Add(value);
				}
				this.UpdateBrowseTreeColumnsState();
				this.UpdateWorkSetColumnsState();
				this.m_BottomToolStrip.Enabled = true;
				if (this.m_TabControl.TabCount > 1)
				{
					this.m_TabControl.SelectedIndex = 1;
					this.m_MonitoredVars.Build();
				}
				this.m_AutoUpdateTimer.Interval = (double)((int)(this.m_MainForm.RstdSettings.GetAutoUpdateInterval() * 1000f));
				this.m_IsBrowseTreeBuilding = false;
			}
		}

		public void UpdateWorkSetColumnsState()
		{
			int num = 0;
			while ((long)num < 6L)
			{
				this.m_WorkSet.VarListView.Columns[num].Visible = RstdGuiSettings.Default.bvisible_columns_in_work_set_arr[num];
				this.m_WorkSet.ArgsListView.Columns[num].Visible = RstdGuiSettings.Default.bvisible_columns_in_work_set_arr[num];
				this.m_WorkSet.VarListView.SetColumnDisplayIndex(this.m_WorkSet.VarListView.Columns[num], RstdGuiSettings.Default.dWSColumnsOrderArr[num], false);
				this.m_WorkSet.ArgsListView.SetColumnDisplayIndex(this.m_WorkSet.ArgsListView.Columns[num], RstdGuiSettings.Default.dWSColumnsOrderArr[num], false);
				num++;
			}
			this.m_WorkSet.SortListViewColumns(RstdGuiSettings.Default.IsSortWSColumns);
		}

		public void UpdateBrowseTreeColumnsState()
		{
			foreach (object obj in this.m_TabControl.TabPages)
			{
				TabTreePage tabTreePage = (TabTreePage)obj;
				XmlNode node;
				GuiCore.GetNodeFromPath("/" + tabTreePage.Text, out node);
				if (GuiCore.bNodeContainsRegisters(node))
				{
					this.iMakeVisibleBrowseTreeAccordingSettingsMenuRegTab(tabTreePage);
				}
				else
				{
					this.iMakeVisibleBrowseTreeAccordingSettingsMenuForNotRegTab(tabTreePage);
				}
				this.iOrderBrowseTreeColumns(tabTreePage);
				tabTreePage.SortListViewColumns(RstdGuiSettings.Default.IsSortBTColumns);
			}
		}

		private void iMakeVisibleBrowseTreeAccordingSettingsMenuRegTab(TabTreePage tp)
		{
			int num = 0;
			while ((long)num < 6L)
			{
				tp.TVListView.Columns[num].Visible = RstdGuiSettings.Default.bvisible_columns_in_browse_tree_arr[num];
				num++;
			}
		}

		private void iOrderBrowseTreeColumns(TabTreePage tp)
		{
			int num = 0;
			while ((long)num < 6L)
			{
				tp.TVListView.SetColumnDisplayIndex(tp.TVListView.Columns[num], RstdGuiSettings.Default.dBTColumnsOrderArr[num], false);
				num++;
			}
		}

		private void iMakeVisibleBrowseTreeAccordingSettingsMenuForNotRegTab(TabTreePage tp)
		{
			int num = 0;
			while ((long)num < 6L)
			{
				if (tp.bCloumnIsReg(tp.TVListView.Columns[num]))
				{
					tp.TVListView.Columns[num].Visible = false;
				}
				else
				{
					tp.TVListView.Columns[num].Visible = RstdGuiSettings.Default.bvisible_columns_in_browse_tree_arr[num];
				}
				num++;
			}
			tp.Text = "Settings";
		}

		public void UnBuild()
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel method = new BrowseTree.GuiOperDel(this.UnBuild);
				base.Invoke(method);
				return;
			}
			object autoUpdateListLocker = this.m_AutoUpdateListLocker;
			lock (autoUpdateListLocker)
			{
				this.m_AutoUpdateList.Clear();
			}
			int num = this.m_TabControl.TabPages.Count - 1;
			while ((long)num >= (long)((ulong)GuiCore.GetNumRemainingTabs()))
			{
				this.m_TabControl.TabPages.RemoveAt(num);
				num--;
			}
			this.m_MonitoredVars.UnBuild();
			this.m_WorkSet.ClearWorkSet();
		}

		public void LoadExposeFile(string fileName)
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel_1String guiOperDel_1String = new BrowseTree.GuiOperDel_1String(this.LoadExposeFile);
				Delegate method = guiOperDel_1String;
				object[] args = new string[]
				{
					fileName
				};
				base.Invoke(method, args);
				return;
			}
			GuiCore.LoadExpose(fileName);
		}

		public void LoadFile(string fileName)
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel_1String guiOperDel_1String = new BrowseTree.GuiOperDel_1String(this.LoadFile);
				Delegate method = guiOperDel_1String;
				object[] args = new string[]
				{
					fileName
				};
				base.Invoke(method, args);
				return;
			}
			this.iAscertainClientBuilt();
			GuiCore.Load(fileName);
		}

		public void SavePath(string path, string fileName)
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel_2String guiOperDel_2String = new BrowseTree.GuiOperDel_2String(this.SavePath);
				Delegate method = guiOperDel_2String;
				object[] args = new string[]
				{
					path,
					fileName
				};
				base.Invoke(method, args);
				return;
			}
			this.iAscertainClientBuilt();
			if (!string.IsNullOrEmpty(fileName))
			{
				if (Path.GetExtension(fileName).Equals(".csv"))
				{
					List<XmlNode> nodeListFromPath = GuiCore.GetNodeListFromPath(path);
					GuiCore.Save2Csv(fileName, nodeListFromPath, false, null, null);
					return;
				}
				GuiCore.Save(path, fileName);
			}
		}

		public void ReceivePath(string path, bool is_script_operation)
		{
			this.iAscertainClientBuilt();
			GuiCore.Receive(path, ReceiveTransmit_T.XML_PATH, is_script_operation);
		}

		public void TransmitPath(string path, bool is_script_operation)
		{
			this.iAscertainClientBuilt();
			GuiCore.Transmit(path, ReceiveTransmit_T.XML_PATH, is_script_operation);
		}

		public void RefreshGui()
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel method = new BrowseTree.GuiOperDel(this.RefreshGui);
				base.Invoke(method);
				return;
			}
			if (GuiCore.MainForm.bIsRstdClosing)
			{
				return;
			}
			this.m_MainForm.SetControlsWait();
			if (!GuiCore.DisableGui)
			{
				this.iAscertainClientBuilt();
				if (!base.IsHidden)
				{
					((TabTreePage)this.m_TabControl.SelectedTab).RefreshDisplay();
				}
				Form openedForm = GuiCore.GetOpenedForm("frmFind");
				if (openedForm != null)
				{
					((frmFind)openedForm).RefreshDisplay();
				}
				this.m_MonitoredVars.RefreshGui();
				this.m_WorkSet.RefreshDisplay();
			}
		}

		public bool bJumpToPath(string path)
		{
			XmlNode node;
			return GuiCore.GetNodeFromPath(path, out node) && this.bJumpToPath(node);
		}

		public bool bJumpToPath(XmlNode node)
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel_bool_1XmlNode method = new BrowseTree.GuiOperDel_bool_1XmlNode(this.bJumpToPath);
				return (bool)base.Invoke(method, new object[]
				{
					node
				});
			}
			this.iAscertainClientBuilt();
			string pathFromNode = GuiCore.GetPathFromNode(node);
			char[] separator = new char[]
			{
				'/'
			};
			string[] array = pathFromNode.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			int i = 0;
			while (i < this.m_TabControl.TabCount)
			{
				if (this.m_TabControl.TabPages[i].Text.Equals(array[0]))
				{
					this.m_TabControl.SelectedTab = this.m_TabControl.TabPages[i];
					if (!base.Visible)
					{
						base.Visible = true;
					}
					if (((TabTreePage)this.m_TabControl.SelectedTab).bJumpToPath(array, node))
					{
						base.Activate();
						if (!base.Visible)
						{
							base.Visible = true;
						}
						return true;
					}
					return false;
				}
				else
				{
					i++;
				}
			}
			return false;
		}

		public void MonitorShow()
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel method = new BrowseTree.GuiOperDel(this.MonitorShow);
				base.Invoke(method);
				return;
			}
			this.iAscertainClientBuilt();
			this.m_MonitoredVars.Show(this.m_MainForm.DockingPanel);
		}

		public string MonitorStart()
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOper_String_Void method = new BrowseTree.GuiOper_String_Void(this.MonitorStart);
				return (string)base.Invoke(method);
			}
			this.iAscertainClientBuilt();
			return this.m_MonitoredVars.MonitorStart();
		}

		public void MonitorStop()
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel method = new BrowseTree.GuiOperDel(this.MonitorStop);
				base.Invoke(method);
				return;
			}
			this.iAscertainClientBuilt();
			this.m_MonitoredVars.MonitorStop();
		}

		public void MonitorLoad(string fileName)
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel_1String guiOperDel_1String = new BrowseTree.GuiOperDel_1String(this.MonitorLoad);
				Delegate method = guiOperDel_1String;
				object[] args = new string[]
				{
					fileName
				};
				base.Invoke(method, args);
				return;
			}
			this.iAscertainClientBuilt();
			this.m_MonitoredVars.MonitorLoad(fileName);
		}

		public void MonitorSave(string fileName)
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel_1String guiOperDel_1String = new BrowseTree.GuiOperDel_1String(this.MonitorSave);
				Delegate method = guiOperDel_1String;
				object[] args = new string[]
				{
					fileName
				};
				base.Invoke(method, args);
				return;
			}
			this.iAscertainClientBuilt();
			this.m_MonitoredVars.MonitorSave(fileName, true);
		}

		public void AddMonitorVar(string var_name, string rel_clocks, string vec_offset, string vec_stride, string vec_length)
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel_5String guiOperDel_5String = new BrowseTree.GuiOperDel_5String(this.AddMonitorVar);
				Delegate method = guiOperDel_5String;
				object[] args = new string[]
				{
					var_name,
					rel_clocks,
					vec_offset,
					vec_stride,
					vec_length
				};
				base.Invoke(method, args);
				return;
			}
			this.iAscertainClientBuilt();
			this.m_MonitoredVars.AddMonitorVar(var_name, rel_clocks, vec_offset, vec_stride, vec_length);
		}

		public void DeleteAllFiles()
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel method = new BrowseTree.GuiOperDel(this.DeleteAllFiles);
				base.Invoke(method);
				return;
			}
			this.iAscertainClientBuilt();
			this.m_MonitoredVars.DeleteAllFiles();
		}

		public void ShowLastFile()
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel method = new BrowseTree.GuiOperDel(this.ShowLastFile);
				base.Invoke(method);
				return;
			}
			this.m_MonitoredVars.ShowLastFile();
		}

		public void LoadXmlFile(ref string gui_settings_default_name, string file_name)
		{
			if (!string.IsNullOrEmpty(file_name))
			{
				gui_settings_default_name = Path.GetDirectoryName(file_name);
				RstdGuiSettings.Default.Save();
				GuiCore.VerbosePrint(string.Format("RSTD.LoadTree(\"{0}\")\n", file_name.Replace('\\', '/')));
			}
		}

		private void m_btnLoadExport_Click(object sender, EventArgs e)
		{
			string text = GuiCore.OpenFileDialog(RstdGuiSettings.Default.LastExportTreePath, FileType.XML);
			if (!string.IsNullOrEmpty(text))
			{
				RstdGuiSettings.Default.LastExportTreePath = Path.GetDirectoryName(text);
				RstdGuiSettings.Default.Save();
				GuiCore.VerbosePrint(string.Format("RSTD.LoadExposeTree(\"{0}\")\n", text.Replace('\\', '/')));
				this.LoadExposeFile(text);
			}
		}

		private void LoadBtn_Click(object sender, EventArgs e)
		{
			string text = GuiCore.OpenFileDialog(RstdGuiSettings.Default.LastTreePath, FileType.XML);
			if (!string.IsNullOrEmpty(text))
			{
				RstdGuiSettings.Default.LastTreePath = Path.GetDirectoryName(text);
				RstdGuiSettings.Default.Save();
				GuiCore.VerbosePrint(string.Format("RSTD.LoadTree(\"{0}\")\n", text.Replace('\\', '/')));
				this.LoadFile(text);
			}
		}

		private void m_SaveSplitBtn_ButtonClick(object sender, EventArgs e)
		{
			this.SaveSelection();
		}

		private void m_SaveSplitBtnAllMenuItem_Click(object sender, EventArgs e)
		{
			byte filetypes = 7;
			string text = GuiCore.SaveDialogTxtOrXml(RstdGuiSettings.Default.LastTreePath, filetypes);
			if (!string.IsNullOrEmpty(text))
			{
				this.SavePath("/", text);
			}
		}

		private void m_SaveSplitBtnTabMenuItem_Click(object sender, EventArgs e)
		{
			string path = this.iGetTabPath();
			byte filetypes = 7;
			string text = GuiCore.SaveDialogTxtOrXml(RstdGuiSettings.Default.LastTreePath, filetypes);
			if (!string.IsNullOrEmpty(text))
			{
				this.SavePath(path, text);
			}
		}

		private void m_SaveSplitBtnSelectionMenuItem_Click(object sender, EventArgs e)
		{
			this.SaveSelection();
		}

		private void SaveSelection()
		{
			TabTreePage tabTreePage = (TabTreePage)this.m_TabControl.SelectedTab;
			PassedVarData passedVarData = new PassedVarData(tabTreePage.TVListView.SelectedItems);
			byte filetypes = 7;
			string text = GuiCore.SaveDialogTxtOrXml(RstdGuiSettings.Default.LastTreePath, filetypes);
			if (tabTreePage.TVListView.SelectedItems.Count == 0)
			{
				string path = this.iGetSelectionPath();
				if (!string.IsNullOrEmpty(text))
				{
					this.SavePath(path, text);
					return;
				}
			}
			else if (!string.IsNullOrEmpty(text))
			{
				if (Path.GetExtension(text).Equals(".csv"))
				{
					GuiCore.Save2Csv(text, passedVarData.XmlNodes, false, null, null);
					return;
				}
				GuiCore.Save(passedVarData.XmlNodes, text);
			}
		}

		private void m_TransmitSplitBtn_ButtonClick(object sender, EventArgs e)
		{
			this.iInvokeTransmitSelection();
		}

		private void iInvokeTransmitSelection()
		{
			BrowseTree.dOperationWithPath doOperationWithParam = new BrowseTree.dOperationWithPath(this.TransmitPath);
			BrowseTree.dOperation doOperation = new BrowseTree.dOperation(GuiCore.Transmit);
			this.TxRxOnSelection(doOperationWithParam, doOperation);
		}

		private void m_TransmitSplitBtnAllMenuItem_Click(object sender, EventArgs e)
		{
			this.TransmitPath("/", false);
		}

		private void m_TransmitSplitBtnTabMenuItem_Click(object sender, EventArgs e)
		{
			string path = this.iGetTabPath();
			this.TransmitPath(path, false);
		}

		private void m_TransmitSplitBtnSelectionMenuItem_Click(object sender, EventArgs e)
		{
			this.iInvokeTransmitSelection();
		}

		private void m_ReceiveSplitBtn_ButtonClick(object sender, EventArgs e)
		{
			this.iInvokeReceiveSelection();
		}

		private void iInvokeReceiveSelection()
		{
			BrowseTree.dOperationWithPath doOperationWithParam = new BrowseTree.dOperationWithPath(this.ReceivePath);
			BrowseTree.dOperation doOperation = new BrowseTree.dOperation(GuiCore.Receive);
			this.TxRxOnSelection(doOperationWithParam, doOperation);
		}

		private void m_ReceiveSplitBtnAllMenuItem_Click(object sender, EventArgs e)
		{
			this.ReceivePath("/", false);
		}

		private void m_ReceiveSplitBtnTabMenuItem_Click(object sender, EventArgs e)
		{
			string path = this.iGetTabPath();
			this.ReceivePath(path, false);
		}

		private void m_ReceiveSplitBtnSelectionMenuItem_Click(object sender, EventArgs e)
		{
			this.iInvokeReceiveSelection();
		}

		private void TxRxOnSelection(BrowseTree.dOperationWithPath doOperationWithParam, BrowseTree.dOperation doOperation)
		{
			TabTreePage tabTreePage = (TabTreePage)this.m_TabControl.SelectedTab;
			if (tabTreePage.TVListView.SelectedItems.Count == 0)
			{
				string path = this.iGetSelectionPath();
				doOperationWithParam(path, false);
				return;
			}
			PassedVarData passedVarData = new PassedVarData(tabTreePage.TVListView.SelectedItems);
			doOperation(passedVarData.XmlNodes, ReceiveTransmit_T.XML_PATH, false);
		}

		private void m_FindBtn_Click(object sender, EventArgs e)
		{
			this.m_FindBtnMenuItemAll_Click(sender, e);
		}

		private void m_FindBtnMenuItemAll_Click(object sender, EventArgs e)
		{
			GuiCore.OpenFindForm("/");
		}

		private void m_FindBtnMenuItemTab_Click(object sender, EventArgs e)
		{
			if (this.m_TabControl.SelectedTab != null)
			{
				GuiCore.OpenFindForm("/" + this.m_TabControl.SelectedTab.Text);
			}
		}

		private void m_FindBtnMenuItemSelection_Click(object sender, EventArgs e)
		{
			if (this.m_TabControl.SelectedTab == null)
			{
				GuiCore.OpenFindForm("/");
				return;
			}
			GuiCore.OpenFindForm(((TabTreePage)this.m_TabControl.SelectedTab).GetFullTabAndFolderPath());
		}

		private void m_MonitoredVarsBtn_Click(object sender, EventArgs e)
		{
			GuiCore.VerbosePrint("RSTD.MonitorShow()\n");
			this.MonitorShow();
		}

		private void m_btnWorkSession_Click(object sender, EventArgs e)
		{
			this.m_WorkSet.Show(this.m_MainForm.DockingPanel);
		}

		private void BrowseTree_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void m_AutoUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			object lockerAutoUpdateTimer = this.m_LockerAutoUpdateTimer;
			lock (lockerAutoUpdateTimer)
			{
				if (this.m_AutoUpdateList == null || this.m_AutoUpdateList.Count != 0)
				{
					this.m_AutoUpdateTimer.Stop();
					if (!this.m_MainForm.bIsRstdClosing && !this.m_MainForm.IsBuilding && !this.m_MainForm.IsUnBuilding && !this.m_IsBrowseTreeBuilding && GuiCore.GetXmlTree().ChildNodes.Count > 1 && this.m_MainForm.RstdSettings.IsAutoUpdateEnabled())
					{
						this.m_AutoUpdateTimer.Interval = (double)((int)(this.m_MainForm.RstdSettings.GetAutoUpdateInterval() * 1000f));
						object autoUpdateListLocker = this.m_AutoUpdateListLocker;
						lock (autoUpdateListLocker)
						{
							foreach (string text in this.m_AutoUpdateList)
							{
								string actualVarValue = GuiCore.GetActualVarValue(text);
								XmlNode xmlNode;
								if (GuiCore.GetNodeFromPath(text, out xmlNode))
								{
									if (xmlNode.FirstChild == null)
									{
										xmlNode.InnerText = actualVarValue;
									}
									else
									{
										xmlNode.FirstChild.Value = actualVarValue;
									}
									xmlNode.Attributes["is_updated"].Value = true.ToString();
								}
							}
						}
						GuiCore.UpdateGuiClient();
					}
					this.m_AutoUpdateTimer.Start();
				}
			}
		}

		private void m_GoToPath_Click(object sender, EventArgs e)
		{
			this.OpenGoTo();
		}

		private void m_TabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.m_MainForm.IsBuilding && !this.m_MainForm.IsUnBuilding && !this.m_IsBrowseTreeBuilding && !base.IsHidden && this.m_TabControl.SelectedTab != null)
			{
				((TabTreePage)this.m_TabControl.SelectedTab).RefreshDisplay();
			}
		}

		private void BrowseTree_DockStateChanged(object sender, EventArgs e)
		{
			if (GuiCore.MainForm.bIsRstdClosing || GuiCore.MainForm.bLoadingLayout)
			{
				return;
			}
			if (base.DockState != DockState.Hidden && base.DockState != DockState.Unknown && this.m_TabControl.SelectedTab != null)
			{
				((TabTreePage)this.m_TabControl.SelectedTab).RefreshDisplay();
			}
		}

		private string iTdvLoadDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Open an XML file";
			openFileDialog.Filter = "XML Data Values files (*.xml)|*.xml";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.InitialDirectory = RstdGuiSettings.Default.LastTreePath;
			openFileDialog.ShowDialog();
			return openFileDialog.FileName;
		}

		private string iGetTabPath()
		{
			if (this.m_TabControl.SelectedTab == null)
			{
				return "";
			}
			return string.Format("/{0}/", this.m_TabControl.SelectedTab.Text);
		}

		private string iGetSelectionPath()
		{
			string result = "";
			if (this.m_TabControl.SelectedTab != null)
			{
				result = ((TabTreePage)this.m_TabControl.SelectedTab).GetFullTabAndFolderPath();
			}
			return result;
		}

		private void iAscertainClientBuilt()
		{
		}

		public void EnableLoadExpose()
		{
			this.m_btnLoadExpose.Enabled = true;
		}

		public void DisableLoadExpose()
		{
			this.m_btnLoadExpose.Enabled = false;
		}

		public void SetControlsWait()
		{
			if (base.InvokeRequired)
			{
				BrowseTree.GuiOperDel method = new BrowseTree.GuiOperDel(this.SetControlsWait);
				base.Invoke(method);
				return;
			}
			if (GuiCore.DisableGui)
			{
				this.Cursor = Cursors.WaitCursor;
				this.m_TabControl.Enabled = false;
				this.m_BottomToolStrip.Enabled = false;
				return;
			}
			if (this.Cursor == Cursors.WaitCursor)
			{
				this.Cursor = Cursors.Default;
				this.m_TabControl.Enabled = true;
				this.m_BottomToolStrip.Enabled = true;
			}
		}

		public void OpenGoTo()
		{
			frmGoTo frmGoTo = new frmGoTo();
			if (frmGoTo.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(frmGoTo.Path))
			{
				this.bJumpToPath(frmGoTo.Path);
			}
		}

		private MonitoredVars m_MonitoredVars;
		private frmWorkSet m_WorkSet;
		private List<frmSubSet> m_SubsetList;
		private frmMain m_MainForm;
		private List<string> m_AutoUpdateList;
		private object m_AutoUpdateListLocker;
		private object m_LockerAutoUpdateTimer;
		private string m_Version;
		private bool m_IsBrowseTreeBuilding;
		private delegate void GuiOperDel();

		private delegate void GuiOperDel_1String(string var);
		private delegate void GuiOperDel_2String(string var1, string var2);
		private delegate void GuiOperDel_5String(string var1, string var2, string var3, string var4, string var5);
		private delegate bool GuiOperDel_bool_1String(string var);
		private delegate bool GuiOperDel_bool_1XmlNode(XmlNode node);
		private delegate string GuiOper_String_Void();
		private delegate void dOperationWithPath(string path, bool bscript_oper);
		private delegate void dOperation(List<XmlNode> xml_nodes, ReceiveTransmit_T recieve_transmit, bool bsync);
	}
}
