using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using LuaDebuggerIDE;
using LuaInterface;
using LuaRegister;
using Microsoft.Win32.SafeHandles;
using RSTD.Properties;
using RstdGuiClientBase;
using RstdXml;
using WeifenLuo.WinFormsUI.Docking;

namespace RSTD
{

	public partial class frmMain : Form
	{



		public List<frmSubSet> SubSetList
		{
			get
			{
				return m_SubSetList;
			}
			set
			{
				m_SubSetList = value;
			}
		}




		public WatchDogManager WatchDogManager
		{
			get
			{
				return m_WatchDogManager;
			}
			set
			{
				m_WatchDogManager = value;
			}
		}




		public Splash SplashScreen
		{
			get
			{
				return m_SplashScreen;
			}
			set
			{
				m_SplashScreen = value;
			}
		}




		public frmLuaShell LuaShellForm
		{
			get
			{
				return m_LuaShellForm;
			}
			set
			{
				m_LuaShellForm = value;
			}
		}




		public frmOutput OutputForm
		{
			get
			{
				return m_OutputForm;
			}
			set
			{
				m_OutputForm = value;
			}
		}




		public frmRecord RecordForm
		{
			get
			{
				return m_RecordForm;
			}
			set
			{
				m_RecordForm = value;
			}
		}




		internal ToolStripEx MainToolBar
		{
			get
			{
				return m_ToolBar;
			}
			set
			{
				m_ToolBar = value;
			}
		}




		internal ToolStripEx BottomToolBar
		{
			get
			{
				return m_BottomToolStrip;
			}
			set
			{
				m_BottomToolStrip = value;
			}
		}




		public string LuaHistoryCommandFile
		{
			get
			{
				return m_LuaHistoryCommandFile;
			}
			set
			{
				m_LuaHistoryCommandFile = value;
			}
		}



		public bool bAllProcsImported
		{
			get
			{
				return m_bAllProcsImported;
			}
		}



		public bool bIsRstdClosing
		{
			get
			{
				return m_bIsRstdClosing;
			}
		}



		public bool bLoadingLayout
		{
			get
			{
				return m_bLoadingLayout;
			}
		}



		public DockPanel DockingPanel
		{
			get
			{
				return m_DockPanel;
			}
		}



		public RstdSettings RstdSettings
		{
			get
			{
				return m_RstdSettings;
			}
		}




		public BrowseTree browse_tree
		{
			get
			{
				return m_BrowseTree;
			}
			set
			{
				m_BrowseTree = value;
			}
		}




		public StatusStrip StatusStrip
		{
			get
			{
				return m_StatusStrip;
			}
			set
			{
				m_StatusStrip = value;
			}
		}




		public ToolStripComboBox ScriptNameComboBox
		{
			get
			{
				return m_ScriptNameComboBox;
			}
			set
			{
				m_ScriptNameComboBox = value;
			}
		}




		public ToolStripMenuItem MenuItemStatusBar
		{
			get
			{
				return menuItemStatusBar;
			}
			set
			{
				menuItemStatusBar = value;
			}
		}




		public ToolStripMenuItem MenuItemStandardToolBar
		{
			get
			{
				return menuItemStandardToolBar;
			}
			set
			{
				menuItemStandardToolBar = value;
			}
		}




		public ToolStripMenuItem MenuItemUserButtonsToolBar
		{
			get
			{
				return menuItemUserButtonsToolBar;
			}
			set
			{
				menuItemUserButtonsToolBar = value;
			}
		}




		public ToolStripMenuItem MenuItemScriptToolBar
		{
			get
			{
				return menuItemScriptToolBar;
			}
			set
			{
				menuItemScriptToolBar = value;
			}
		}




		public DockPanel DockPanel
		{
			get
			{
				return m_DockPanel;
			}
			set
			{
				m_DockPanel = value;
			}
		}




		public bool bIsClientRunning
		{
			get
			{
				return m_bIsClientRunning;
			}
			set
			{
				m_bIsClientRunning = value;
			}
		}




		public LuaExportedOperations LuaOps
		{
			get
			{
				return m_LuaExportedOps;
			}
			set
			{
				m_LuaExportedOps = value;
			}
		}




		public bool bIsStopPending
		{
			get
			{
				return m_bIsStopPending;
			}
			set
			{
				m_bIsStopPending = value;
			}
		}




		public StreamWriter LogStreamWriter
		{
			get
			{
				return m_LogStreamWriter;
			}
			set
			{
				m_LogStreamWriter = value;
			}
		}




		public StreamWriter LogVerboseStreamWriter
		{
			get
			{
				return m_LogVerboseStreamWriter;
			}
			set
			{
				m_LogVerboseStreamWriter = value;
			}
		}




		public StreamWriter LogUserStreamWriter
		{
			get
			{
				return m_LogUserStreamWriter;
			}
			set
			{
				m_LogUserStreamWriter = value;
			}
		}




		public string LastLogFileName
		{
			get
			{
				return m_LastLogFileName;
			}
			set
			{
				m_LastLogFileName = value;
			}
		}




		public bool WarnBeforeLogsDeletion
		{
			get
			{
				return m_bWarnBeforeLogsDeletion;
			}
			set
			{
				m_bWarnBeforeLogsDeletion = value;
			}
		}




		public int LimitLogFilesInLogFolder
		{
			get
			{
				return m_LogFilesToLeave;
			}
			set
			{
				m_LogFilesToLeave = value;
			}
		}




		public int MaxLogFiles
		{
			get
			{
				return m_MaxLogFiles;
			}
			set
			{
				m_MaxLogFiles = value;
			}
		}




		public ArrayList ReggaeProcess
		{
			get
			{
				return m_ReggaeProcess;
			}
			set
			{
				m_ReggaeProcess = value;
			}
		}




		public frmGuiSettings FrmGuiGettings
		{
			get
			{
				return m_frmGuiGettings;
			}
			set
			{
				m_frmGuiGettings = value;
			}
		}




		public List<RstdGuiModuleBase> GuiDllForms
		{
			get
			{
				return m_GuiDllForms;
			}
			set
			{
				m_GuiDllForms = value;
			}
		}



		public bool IsBuilding
		{
			get
			{
				return m_bIsBuilding;
			}
		}



		public bool IsUnBuilding
		{
			get
			{
				return m_bIsUnBuilding;
			}
		}




		public frmLuaDebugger LuaDebugger
		{
			get
			{
				return m_LuaDebuggerForm;
			}
			set
			{
				m_LuaDebuggerForm = value;
			}
		}



		public bool LuaDebuggerPresent
		{
			get
			{
				return m_LuaDebuggerForm != null && !m_LuaDebuggerForm.IsFormClosed;
			}
		}




		public TcpChannel ReggaeChannel
		{
			get
			{
				return m_ReggaeChannel;
			}
			set
			{
				m_ReggaeChannel = value;
			}
		}




		public string SettingsOutputPath
		{
			get
			{
				return m_SettingsOutputPath;
			}
			set
			{
				m_SettingsOutputPath = value;
			}
		}




		public List<RstdServer> Servers
		{
			get
			{
				return m_Servers;
			}
			set
			{
				m_Servers = value;
			}
		}



		public Control.ControlCollection UserToolStripsList
		{
			get
			{
				return toolStripContainer1.TopToolStripPanel.Controls;
			}
		}




		public bool ScriptAborted
		{
			get
			{
				return m_bScriptAborted;
			}
			set
			{
				m_bScriptAborted = value;
			}
		}


		public frmMain()
		{
			Thread.CurrentThread.Name = "GUI";
			InitializeComponent();
			GuiCore.MainForm = this;
			m_WatchDogManager = new WatchDogManager();
			m_SettingsOutputPath = iGetSettingsOutputPath();
			Splash.ShowSplashScreen();
			SetTitle(Program.Title);
			m_GuiDllForms = new List<RstdGuiModuleBase>();
			m_LuaHistoryCommandFile = m_SettingsOutputPath + "\\LuaHistoryCommandFile.txt";
			CheckImportedProcedures();
			m_DockPanel.ShowDocumentIcon = true;
			m_LuaExportedOps = new LuaExportedOperations();
			try
			{
				LuaWrapperUtils.LuaWrapper.GuiMain = this;
				LuaWrapperUtils.LuaWrapper.SettingsOutputPath = SettingsOutputPath;
				LuaWrapperUtils.LuaWrapper.ShowGuiFunc = new dShowGuiControllerDel(ShowGuiController);
				LuaWrapperUtils.LuaWrapper.RunDoStringFunc = new dRunDoString(RunDoString);
				LuaWrapperUtils.LuaWrapper.PrintFunc = new LuaRegister.del_v_s(AlwaysPrint);
				LuaWrapperUtils.LuaWrapper.PrintWarningFunc = new LuaRegister.del_v_s(WarningPrint);
				LuaWrapperUtils.LuaWrapper.PrintErrorFunc = new LuaRegister.del_v_s(ErrorPrint);
				LuaWrapperUtils.LuaWrapper.RegInfoFromPathFunc = new del_b_s_ob_oi_ou_oi_oi(GuiCore.GetRegisterInfoForPath);
				LuaWrapperUtils.LuaWrapper.GetNodeSonsFunc = new del_sarr_s(GuiCore.GetNodeChildNamesFromPath);
				LuaWrapperUtils.LuaWrapper.StartScriptFunc = new del_bStartScript(bStartScript);
				LuaWrapperUtils.LuaWrapper.IsAutomationOnFunc = new LuaRegister.del_b_v(GuiCore.IsAutomationModeOn);
				LuaWrapperUtils.LuaWrapper.RecordCommand = new del_v_s_s_s(RecordCommand);
				LuaWrapperUtils.LuaWrapper.RegisterLuaFunctions("RSTD", m_LuaExportedOps, "RSTD module - Contains all Rstd Exported functions for Lua");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error registering Lua functions\n" + ex.ToString());
			}
			m_OutputForm = new frmOutput(this);
			m_RecordForm = new frmRecord(this);
			m_RstdSettings = new RstdSettings();
			m_BrowseTree = new BrowseTree(this);
			m_deserializeDockContent = new DeserializeDockContent(iGetContentFromPersistString);
			GuiCore.IsClientBuilt = false;
			m_bIsBuilding = false;
			m_bIsUnBuilding = false;
			m_bIsClientRunning = false;
			m_bIsStopPending = false;
			frmMain.bIsScriptRunning = false;
			m_bScriptAborted = false;
			m_bLoadingLayout = false;
			m_bIsRstdClosing = false;
			m_MAX_NUM_COMMANDS_IN_FILE = 10000;
			frmMain.gGui_updated_mode = GUI_REGISTER_UPDATED_MODE.ON_FIELDS_UPDATE;
			iGetIniSettings();
			RstdGuiSettings.Default.Load();
			RstdGuiSettings.Default.BackupUserToolbars();
			InitLogFile();
			if (m_bAllProcsImported)
			{
				iLoadGuiSettings();
				GuiCore.Init(this, m_BrowseTree, m_RstdSettings, new ConsolePrintLevelDel(AlwaysPrint), new ConsolePrint(VerbosePrint), new ConsoleMessageDel(DoCoreMsg), new RefreshGuiDel(m_BrowseTree.RefreshGui), new ConsoleMessageBoxDel(DoCoreMsgBox));
				m_BrowseTree.Build();
				m_RstdSettings.LoadSettings();
				GuiCore.Transmit("/Settings", ReceiveTransmit_T.XML_PATH, true);
				iAddDefaultToolStrip(RstdGuiSettings.Default.DefaultUserButtonsFileName);
				LoadUserToolStrips();
			}
			m_LuaShellForm = new frmLuaShell(this);
			m_frmGuiGettings = new frmGuiSettings(this);
			m_ReggaeChannel = new TcpChannel();
			ChannelServices.RegisterChannel(m_ReggaeChannel, false);
			Splash.CloseForm();
			base.TopMost = true;
			CoreImports.SetForegroundWindow(base.Handle);
			base.Activate();
			base.TopMost = false;
			m_MaxLogFiles = RstdSettings.GetMaxLogFiles();
			m_LogFilesToLeave = RstdSettings.GetLogFilesToLeave();
			m_bWarnBeforeLogsDeletion = RstdSettings.GetWarnBeforeLogFilesDeletion();
			iCheckMaxLogFiles();
			m_Servers = new List<RstdServer>();
			m_SubSetList = new List<frmSubSet>();
			menuItemOperations.Visible = false;
			menuItemBrowseTree.Visible = false;
			menuItemWorkSet.Visible = false;
			menuItemMonitors.Visible = false;
			menuItemStandardToolBar.Visible = false;
			settingsToolStripMenuItem.Visible = false;
			menuItemLoadLayout.Visible = false;
			menuItemSaveLayout.Visible = false;
			menuItemClose.Visible = false;
			menuItemCloseAll.Visible = false;
			menuItemCloseAllButThisOne.Visible = false;
			menuItem4.Visible = false;
			menuItemSubSet.Visible = false;
			menuItemBuild.ShortcutKeys = Keys.None;
			menuItemGo.ShortcutKeys = Keys.None;
			m_UserButtonsContextMenuStrip.Items.Remove(DebugScriptToolStripMenuItem);
			m_BottomToolStrip.Items.Remove(m_btnDebug);
			if (Program.LuaExecutableScript != null)
			{
				m_ScriptNameComboBox.Text = Program.LuaExecutableScript;
				iStartScriptFromCombo();
			}
		}


		public void RecordCommand(string module_name, string op_name, string command)
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDelv_v_s_s_s method = new frmMain.GuiOperDelv_v_s_s_s(RecordCommand);
				base.Invoke(method, new object[]
				{
					module_name,
					op_name,
					command
				});
				return;
			}
			m_RecordForm.AddCommand(module_name, op_name, command);
		}


		private void iGetIniSettings()
		{
			string text = Application.StartupPath + "\\rttt_settings.ini";
			string text2 = Application.StartupPath + "\\def_rttt_settings.ini";
			if (!File.Exists(text) && File.Exists(text2))
			{
				File.Copy(text2, text);
				if (File.GetAttributes(text) == FileAttributes.ReadOnly)
				{
					File.SetAttributes(text, FileAttributes.Normal);
				}
			}
			GuiCore.ReadIniFile(text);
			m_OutputForm.ShowVerboseLogEnabled = GuiCore.UseVerboseLog;
			m_OutputForm.ShowUserLogEnabled = GuiCore.UseUserLog;
		}


		public void SetTitle(string title)
		{
			int id = Process.GetCurrentProcess().Id;
			if (!string.IsNullOrEmpty(title))
			{
				Text = string.Format("mmWave Studio {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
				return;
			}
			Text = string.Format("mmWave Studio {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
		}


		public void SetVersion(string title)
		{
			if (!string.IsNullOrEmpty(title))
			{
				Text = string.Format("mmWave Studio - {0} || VER: {1} ", Environment.UserName, title);
			}
		}


		private void iDispose()
		{
			if (m_bAllProcsImported)
			{
				GuiCore.Close();
			}
			m_OutputForm = null;
			m_BrowseTree = null;
			m_LastLogFileName = null;
			m_LogStreamWriter = null;
			m_LogVerboseStreamWriter = null;
			LogUserStreamWriter = null;
			m_frmGuiGettings = null;
			m_RecordForm = null;
		}


		public void InitLogFile()
		{
			try
			{
				string text = GetCorrectOutputPath() + Path.DirectorySeparatorChar.ToString() + "Log";
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				m_LastLogFileName = GuiCore.GetLastIndexedFileNameInPath("Log", "txt", text);
				if (string.IsNullOrEmpty(m_LastLogFileName))
				{
					m_LastLogFileName = text + Path.DirectorySeparatorChar.ToString() + "Log0000.txt";
				}
				else
				{
					GuiCore.IncrementFileNameIdx("Log", 4, ref m_LastLogFileName);
				}
				m_LastLogFileName = GuiCore.IncrementSubFileNameIdx(m_LastLogFileName);
				m_LogStreamWriter = File.CreateText(m_LastLogFileName);
				if (GuiCore.UseVerboseLog)
				{
					string path = m_LastLogFileName.Remove(m_LastLogFileName.Length - 4) + "_verbose.txt";
					m_LogVerboseStreamWriter = File.CreateText(path);
				}
				if (GuiCore.UseUserLog)
				{
					string path2 = m_LastLogFileName.Remove(m_LastLogFileName.Length - 4) + "_user.txt";
					m_LogUserStreamWriter = File.CreateText(path2);
				}
			}
			catch (Exception ex)
			{
				GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Log file generation error: \n" + ex.Message, ex.StackTrace);
				throw;
			}
		}


		public string GetCorrectOutputPath()
		{
			string outputPath;
			if (GuiCore.GetXmlTree() != null)
			{
				outputPath = m_RstdSettings.GetOutputPath();
			}
			else
			{
				outputPath = m_RstdSettings.OutputPath;
			}
			return outputPath;
		}


		public void iCheckMaxLogFiles()
		{
			string directoryName = Path.GetDirectoryName(m_LastLogFileName);
			int indexFromLogFileName = GetIndexFromLogFileName(m_LastLogFileName);
			int num = Directory.GetFiles(directoryName).Length;
			if (m_MaxLogFiles < m_LogFilesToLeave + 1)
			{
				MessageBox.Show("RSTD", "Wrong log parameters");
				return;
			}
			if (num > m_MaxLogFiles)
			{
				if (m_bWarnBeforeLogsDeletion)
				{
					if (new frmMaxLog(string.Format("There are more than {0} files in the Log dir.\nDelete old logs (leaving last {1}) ? (recommended)", m_MaxLogFiles, m_LogFilesToLeave), this).ShowDialog() == DialogResult.Yes)
					{
						DeleteLogFiles(directoryName, indexFromLogFileName);
						return;
					}
				}
				else
				{
					DeleteLogFiles(directoryName, indexFromLogFileName);
				}
			}
		}


		private void DeleteLogFiles(string log_output_path, int log_index)
		{
			foreach (string text in Directory.GetFiles(log_output_path))
			{
				if (LogFileIsUseless(text, log_index))
				{
					File.Delete(text);
				}
			}
		}


		private bool LogFileIsUseless(string log_file_name, int last_log_index)
		{
			int indexFromLogFileName = GetIndexFromLogFileName(log_file_name);
			return last_log_index - (m_LogFilesToLeave + 1) >= indexFromLogFileName;
		}


		private int GetIndexFromLogFileName(string log_file_name)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(log_file_name);
			int result = 0;
			int startIndex = fileNameWithoutExtension.IndexOf('_');
			if (!int.TryParse(fileNameWithoutExtension.Remove(startIndex).Remove(0, 3), out result))
			{
				Warning("wrong log index");
			}
			return result;
		}


		public void Warning(string text)
		{
			if (!text.EndsWith("\n"))
			{
				text += "\n";
			}
			string text2 = string.Format("WARNING:\n{0}", text);
			AlwaysPrint(0U, 2U, text2, false, true);
		}


		public void AlwaysPrint(string text)
		{
			AlwaysPrint(0U, 0U, text, false, false);
		}


		public void AlwaysPrint(uint print_level, string text)
		{
			AlwaysPrint(print_level, 0U, text, false, false);
		}


		public void AlwaysPrint(uint print_level, uint text_color, string text)
		{
			if (print_level == 4U || print_level == 3U)
			{
				AlwaysPrint(0U, text_color, text, false, true);
				return;
			}
			AlwaysPrint(print_level, text_color, text, false, false);
		}


		public void MustPrint(string text)
		{
			AlwaysPrint(0U, 0U, text, false, true);
		}


		public void ErrorPrint(string text)
		{
			AlwaysPrint(0U, 1U, text, false, true);
		}


		public void WarningPrint(string text)
		{
			AlwaysPrint(0U, 2U, text, false, true);
		}


		public void AlwaysPrint(uint print_level, uint text_color, string text, bool is_user_msg, bool must_print)
		{
			if (m_bIsRstdClosing)
			{
				return;
			}
			if (base.InvokeRequired)
			{
				ConsolePrintLevel2Del method = new ConsolePrintLevel2Del(AlwaysPrint);
				base.Invoke(method, new object[]
				{
					print_level,
					text_color,
					text,
					is_user_msg,
					must_print
				});
				return;
			}
			if (GuiCore.GetXmlTree() != null && RstdSettings.DisplayDateTime())
			{
				string text2 = string.Format("[{0}]  ", DateTime.Now.ToString(RstdSettings.DateTimeFormat()));
				if (text.EndsWith("\n"))
				{
					text = text.Remove(text.Length - 1, 1).Replace("\n", "\n" + text2) + "\n";
				}
				else
				{
					text = text.Replace("\n", "\n" + text2);
				}
				if (m_bIsLineStart)
				{
					text = string.Format("{0}{1}", text2, text);
				}
			}
			if (print_level == 0U)
			{
				m_OutputForm.AppendText(text, text_color, is_user_msg, must_print);
				m_LogStreamWriter.Write(text);
				m_LogStreamWriter.Flush();
			}
			if (GuiCore.UseVerboseLog)
			{
				m_LogVerboseStreamWriter.Write(text);
				m_LogVerboseStreamWriter.Flush();
			}
			if (GuiCore.UseUserLog && (is_user_msg || must_print))
			{
				LogUserStreamWriter.Write(text);
				LogUserStreamWriter.Flush();
			}
			if (text.EndsWith("\n"))
			{
				m_bIsLineStart = true;
				return;
			}
			m_bIsLineStart = false;
		}


		public void VerbosePrint(string text)
		{
			if (m_RstdSettings.IsVerbose())
			{
				AlwaysPrint(text);
			}
		}


		public void DoCoreMsg(string msg)
		{
			Thread.Sleep(200);
			if (msg.Equals("RstdStopRunning"))
			{
				if (m_bIsClientRunning && !m_bIsStopPending)
				{
					new Thread(new ThreadStart(m_LuaExportedOps.Stop))
					{
						IsBackground = true
					}.Start();
					return;
				}
			}
			else
			{
				try
				{
					string text = string.Format("DoCoreMsg:: Core sent an unknown message \"{0}\"", msg);
					if (GuiCore.IsOnScriptThread())
					{
						throw new LuaException(text);
					}
					throw new RstdException(text);
				}
				catch (RstdException ex)
				{
					GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, string.Concat(new object[]
					{
						"Error in operation: \n",
						ex.Message,
						"\n",
						ex.InnerException
					}), ex.StackTrace);
				}
			}
		}


		public uint DoCoreMsgBox(uint msg_type, string msg)
		{
			if (base.InvokeRequired)
			{
				ConsoleMessageBoxDel method = new ConsoleMessageBoxDel(DoCoreMsgBox);
				return (uint)base.Invoke(method, new object[]
				{
					msg_type,
					msg
				});
			}
			string[] array = new string[]
			{
				"\nStack Trace: \n"
			};
			if (msg.Contains(array[0]))
			{
				string[] array2 = msg.Split(array, StringSplitOptions.None);
				return GuiCore.RSTDMessage((RstdConstants.MESSAGE_TYPE)msg_type, array2[0], array2[1]);
			}
			return GuiCore.RSTDMessage((RstdConstants.MESSAGE_TYPE)msg_type, msg);
		}


		public void GoBegin()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(GoBegin);
				base.Invoke(method);
				return;
			}
			if (1 == CoreImports.IsDebuggerPresent())
			{
				MinimizeAllWindows();
			}
			m_bIsClientRunning = true;
		}


		public void GoEnd()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(GoEnd);
				base.Invoke(method);
			}
		}


		public void StopBegin()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(StopBegin);
				base.Invoke(method);
			}
		}


		public void StopEnd()
		{
			if (m_bIsRstdClosing)
			{
				return;
			}
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(StopEnd);
				base.Invoke(method);
				return;
			}
			GuiCore.SetAllNodesUpdateStatus(false);
			m_bIsClientRunning = false;
		}


		public void BuildBegin()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(BuildBegin);
				base.Invoke(method);
				return;
			}
			GuiCore.VerbosePrint("RSTD.Build()\n");
			m_bIsBuilding = true;
			GuiCore.DisableGui = true;
			SetControlsWait();
			m_RstdSettings.SaveSettings();
		}


		public void BuildEnd()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(BuildEnd);
				base.Invoke(method);
				return;
			}
			GuiCore.IsClientBuilt = true;
			GuiCore.BuildStatus |= EBuildStatus.Client_Built;
			m_BrowseTree.Build();
			iLoadGuiDll();
			GuiCore.DisableGui = false;
			SetControlsWait();
			m_bIsBuilding = false;
		}


		private void iLoadGuiDll()
		{
			string clientGuiDllPath = m_RstdSettings.GetClientGuiDllPath();
			if (string.IsNullOrEmpty(clientGuiDllPath))
			{
				return;
			}
			try
			{
				Type[] types = Assembly.LoadFrom(clientGuiDllPath).GetTypes();
				for (int i = 0; i < types.Length; i++)
				{
					if (types[i].BaseType.Name == "RstdGuiModule")
					{
						m_GuiDllForms.Add((RstdGuiModuleBase)Activator.CreateInstance(types[i], new object[]
						{
							LuaWrapperUtils.LuaWrapper
						}));
					}
				}
				if (m_GuiDllForms.Count == 0)
				{
					GuiCore.RstdMesssage(string.Format("The GUI DLL \"{0}\" does not contain a Gui form (DockContent)\nClient Gui will not be loaded.", clientGuiDllPath));
				}
				else
				{
					foreach (RstdGuiModuleBase rstdGuiModuleBase in m_GuiDllForms)
					{
						rstdGuiModuleBase.Show(m_DockPanel);
					}
				}
			}
			catch (Exception ex)
			{
				GuiCore.RstdException(ex.Message + "\n" + ex.InnerException, ex.StackTrace);
			}
		}


		public string GetDllModuleName(string dll_path)
		{
			LuaRegisterInfo luaRegisterInfo = new LuaRegisterInfo();
			luaRegisterInfo.DllPath = dll_path;
			GetDllModuleName(luaRegisterInfo);
			return luaRegisterInfo.Package;
		}


		public bool GetDllModuleName(LuaRegisterInfo reg_info)
		{
			try
			{
				if (!File.Exists(reg_info.DllPath))
				{
					return false;
				}
				Type[] types = Assembly.LoadFrom(reg_info.DllPath).GetTypes();
				int i = 0;
				while (i < types.Length)
				{
					if (types[i].BaseType != null && types[i].BaseType.Name == "LuaDllRegister")
					{
						FieldInfo field = types[i].GetField("ModuleName");
						if (field != null)
						{
							reg_info.Package = (string)field.GetValue(types[i]);
							return true;
						}
						LuaDllRegister luaDllRegister = (LuaDllRegister)Activator.CreateInstance(types[i], new object[]
						{
							LuaWrapperUtils.LuaWrapper
						});
						reg_info.Package = luaDllRegister.PackageName;
						return true;
					}
					else
					{
						i++;
					}
				}
			}
			catch (Exception ex)
			{
				GuiCore.RstdException(ex.Message, ex.StackTrace);
			}
			return false;
		}


		public bool RegisterDllToLua(LuaRegisterInfo reg_info)
		{
			bool flag = false;
			try
			{
				if (!File.Exists(reg_info.DllPath))
				{
					string msg = string.Format("Failed to register controller from \"{0}\". Could not locate the file.\n\nRemove dll from the list?", reg_info.DllPath);
					if (GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, msg) == 6U)
					{
						UnregisterLuaDll(reg_info);
						reg_info.ToBeRemoved = true;
					}
					return false;
				}
				Type[] types = Assembly.LoadFrom(reg_info.DllPath).GetTypes();
				int num = 0;
				while (num < types.Length && !flag)
				{
					if (types[num].BaseType != null && types[num].BaseType.Name == "LuaDllRegister")
					{
						LuaDllRegister luaDllRegister = (LuaDllRegister)Activator.CreateInstance(types[num], new object[]
						{
							LuaWrapperUtils.LuaWrapper
						});
						reg_info.Package = luaDllRegister.PackageName;
						luaDllRegister.RegisterFunctions();
						reg_info.ClassObj = luaDllRegister;
						reg_info.IsRegistered = true;
						flag = true;
					}
					num++;
				}
				if (!flag)
				{
					GuiCore.RstdMesssage(string.Format("The DLL \"{0}\" does not contain a LuaDllRegister class\n", reg_info.DllPath));
					return false;
				}
			}
			catch (Exception ex)
			{
				string arg = "";
				if (ex.InnerException != null)
				{
					if (ex.InnerException is LuaException)
					{
						throw ex.InnerException;
					}
					arg = ex.InnerException.Message;
				}
				GuiCore.RstdException(string.Format("Failed to register Controller from \"{0}\"\n{1}\n{2}", reg_info.DllPath, ex.Message, arg), ex.StackTrace);
				reg_info.Use = false;
				return false;
			}
			return true;
		}


		private Assembly domain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			string text = null;
			foreach (string dir_path in m_DllRegProbePaths.Split(new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries))
			{
				text = iFindAssemblyPathInDir(args.Name, dir_path);
				if (!string.IsNullOrEmpty(text))
				{
					break;
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			return Assembly.Load(File.ReadAllBytes(text));
		}


		private string iFindAssemblyPathInDir(string full_assembly_name, string dir_path)
		{
			string[] files = Directory.GetFiles(dir_path, "*.dll");
			string b = full_assembly_name.Substring(0, full_assembly_name.IndexOf(","));
			string result = null;
			foreach (string text in files)
			{
				if (Path.GetFileNameWithoutExtension(text) == b)
				{
					result = text;
					break;
				}
			}
			return result;
		}


		public void UnregisterLuaDll(LuaRegisterInfo reg_info)
		{
			if (reg_info.ClassObj != null)
			{
				reg_info.ClassObj.UnLoad();
				reg_info.ClassObj = null;
			}
			if (!string.IsNullOrEmpty(reg_info.Package))
			{
				LuaWrapperUtils.LuaWrapper.LuaVM.DoString(string.Format("{0}=nil", reg_info.Package));
			}
			reg_info.IsRegistered = false;
		}


		private void iUnLoadGuiDll()
		{
			for (int i = 0; i < m_GuiDllForms.Count; i++)
			{
				if (m_GuiDllForms[i] != null)
				{
					m_GuiDllForms[i].Close();
					m_GuiDllForms[i] = null;
				}
			}
			m_GuiDllForms.Clear();
		}


		public void UnBuildBegin()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(UnBuildBegin);
				base.Invoke(method);
				return;
			}
			GuiCore.VerbosePrint("RSTD.UnBuild()\n");
			m_bIsUnBuilding = true;
			iUnLoadGuiDll();
		}


		public void UnBuildEnd()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(UnBuildEnd);
				base.Invoke(method);
				return;
			}
			m_BrowseTree.UnBuild();
			GuiCore.IsClientBuilt = false;
			GuiCore.BuildStatus = (EBuildStatus.AL_Built | (GuiCore.BuildStatus & EBuildStatus.AL_Init) | (GuiCore.BuildStatus & EBuildStatus.AL_Reset));
		}


		public void SetControlsWait()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(SetControlsWait);
				base.Invoke(method);
				return;
			}
			bool disableGui = GuiCore.DisableGui;
			m_BrowseTree.SetControlsWait();
		}


		public void ShowVerboseLogFile()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(ShowVerboseLogFile);
				base.Invoke(method);
				return;
			}
			VerbosePrint("RSTD.ShowVerboseLogFile()\n");
			m_LogVerboseStreamWriter.Flush();
			string text = m_LastLogFileName.Remove(m_LastLogFileName.Length - 4) + "_verbose.txt";
			if (File.Exists(text))
			{
				Process.Start(text);
			}
		}


		public void ShowUserLogFile()
		{
			base.Invoke(new MethodInvoker(delegate()
			{
				VerbosePrint("RSTD.ShowUserLogFile()\n");
				m_LogUserStreamWriter.Flush();
				string text = m_LastLogFileName.Remove(m_LastLogFileName.Length - 4) + "_user.txt";
				if (File.Exists(text))
				{
					Process.Start(text);
				}
			}));
		}


		public void OpenLogFolder()
		{
			string directoryName = Path.GetDirectoryName(m_LastLogFileName);
			Process.Start("explorer.exe", directoryName);
		}


		public void StopPipeListener()
		{
			if (m_PipeReadThread.IsAlive)
			{
				m_StdoutPipe.Write("STOP_STDOUT_READ_BLOCKING");
				m_PipeReadThread.Abort();
			}
		}


		private void iOpenLuaDeubgger()
		{
			if (m_LuaDebuggerForm == null || m_LuaDebuggerForm.IsFormClosed)
			{
				m_LuaDebuggerForm = new frmLuaDebugger(LuaWrapperUtils.LuaWrapper.LuaVM, new frmLuaDebugger.ConsolePrintLevelDel(AlwaysPrint), new frmLuaDebugger.ScriptStartDel(bStartScript), new frmLuaDebugger.ScriptStopPauseDel(StopScript), new frmLuaDebugger.ScriptStopPauseDel(PauseScript), m_SettingsOutputPath, RstdGuiSettings.Default.LuaRegisterInfos, LuaWrapperUtils.LuaWrapper);
			}
		}


		public void ShowLuaDebugger()
		{
			if (!LuaDebuggerPresent)
			{
				return;
			}
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(ShowLuaDebugger);
				base.Invoke(method);
				return;
			}
			m_LuaDebuggerForm.Show();
			m_LuaDebuggerForm.Focus();
			GuiCore.RestoreWindow(m_LuaDebuggerForm);
		}


		public string GetToolbarScript()
		{
			return m_ScriptNameComboBox.Text;
		}


		public void ShowGuiController(Control content)
		{
			((DockContent)content).Show(m_DockPanel);
		}


		public object[] RunDoString(string lua_str, int op_id, dPostLuaOpDel post_func, out Thread dostring_thread, bool async, bool safe, out bool aborted)
		{
			frmMain.LuaScriptRunner luaScriptRunner = new frmMain.LuaScriptRunner(lua_str, this, null, LuaSourceType.LuaString, post_func, op_id, safe, true);
			dostring_thread = new Thread(new ThreadStart(luaScriptRunner.RunScript));
			dostring_thread.IsBackground = true;
			dostring_thread.Name = "DoStringThread";
			dostring_thread.Start();
			if (!async)
			{
				dostring_thread.Join();
			}
			aborted = luaScriptRunner.Aborted;
			return luaScriptRunner.Res;
		}


		public void SaveLuaLayoutToRstdGuiSettings()
		{
			RstdGuiSettings.Default.LuaFamilyFont = m_LuaShellForm.ShellTextBox.Font.FontFamily.Name;
			RstdGuiSettings.Default.LuaFontBold = m_LuaShellForm.ShellTextBox.Font.Bold.ToString();
			RstdGuiSettings.Default.LuaFontItalic = m_LuaShellForm.ShellTextBox.Font.Italic.ToString();
			RstdGuiSettings.Default.LuaFontSize = m_LuaShellForm.ShellTextBox.Font.Size.ToString();
			RstdGuiSettings.Default.LuaBackGroundColor = frmLuaShell.ConvertColorToHex(m_LuaShellForm.ShellTextBox.BackColor);
			RstdGuiSettings.Default.LuaForeGroundColor = frmLuaShell.ConvertColorToHex(m_LuaShellForm.ShellTextBox.ForeColor);
			RstdGuiSettings.Default.Save();
		}


		private void iRunStartupScript()
		{
			if (RstdSettings.UseStartupScript())
			{
				string text = RstdSettings.GetStartupScriptPath();
				if (!string.IsNullOrEmpty(text))
				{
					if (text.Contains("{rttt_path}"))
						text = text.Replace("{rttt_path}", Path.GetFullPath(Application.StartupPath + "\\.."));
					if (text.Contains("{cc_path}"))
						text = text.Replace("{cc_path}", RstdSettings.GetClearCasePath());
					text = Environment.ExpandEnvironmentVariables(text);
					if (File.Exists(text))
					{
                        MustPrint("############\n");
                        MustPrint("### x893 ###\n");
                        MustPrint("############\n");
                        MustPrint(string.Format("\n### Running Startup script: \"{0}\" ###\n", text));
						bStartScript(text);
					}
					else
						ErrorPrint(string.Format("Could not find startup script: \"{0}\"\n", text));
				}
			}
		}

		public RstdServer AddNewServer(int port)
		{
			RstdServer rstdServer = new RstdServer(port);
			rstdServer.StateChanged += Server_StateChanged;
			m_Servers.Add(rstdServer);
			return rstdServer;
		}


		public void RemoveServer(int port)
		{
			RstdServer server = GetServer(port);
			if (server != null)
			{
				m_Servers.Remove(server);
			}
		}


		public RstdServer GetServer(int port)
		{
			foreach (RstdServer rstdServer in m_Servers)
			{
				if (rstdServer.Port == port)
				{
					return rstdServer;
				}
			}
			return null;
		}


		public bool ServerExists(int port)
		{
			return GetServer(port) != null;
		}


		private void frmMain_Load(object sender, EventArgs e)
		{
			iLoadLayout();
			try
			{
				LuaWrapperUtils.LuaWrapper.DoFile(Application.StartupPath + "\\LuaScripts\\LoadPackages.lua");
				iRunStartupScript();
			}
			catch (Exception ex)
			{
				GuiCore.ErrorMessage("Error while running LoadPackages.lua\n" + ex.Message + ex.StackTrace);
			}
		}


		private void m_BuildBtn_Click(object sender, EventArgs e)
		{
			if (GuiCore.IsClientBuilt)
			{
				iUserUnBuild();
				return;
			}
			iUserBuild();
		}


		private void m_ScriptBrowseBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Open a script file";
			openFileDialog.Filter = "Script files (*.lua)|*.lua";
			openFileDialog.RestoreDirectory = true;
			if (!string.IsNullOrEmpty(m_ScriptNameComboBox.Text))
			{
				if (File.Exists(m_ScriptNameComboBox.Text))
				{
					openFileDialog.InitialDirectory = Path.GetDirectoryName(m_ScriptNameComboBox.Text);
				}
				else if (Directory.Exists(m_ScriptNameComboBox.Text))
				{
					openFileDialog.InitialDirectory = m_ScriptNameComboBox.Text;
				}
			}
			else
			{
				openFileDialog.InitialDirectory = RstdGuiSettings.Default.LastScriptPath;
			}
			if (DialogResult.OK == openFileDialog.ShowDialog())
			{
				RstdGuiSettings.Default.LastScriptPath = Path.GetDirectoryName(openFileDialog.FileName);
				RstdGuiSettings.Default.Save();
				if (!m_ScriptNameComboBox.Items.Contains(openFileDialog.FileName))
				{
					m_ScriptNameComboBox.Items.Insert(0, openFileDialog.FileName);
				}
				m_ScriptNameComboBox.SelectedIndex = m_ScriptNameComboBox.FindStringExact(openFileDialog.FileName);
			}
			if (openFileDialog != null)
			{
			}
		}


		private void m_EditScriptBtn_Click(object sender, EventArgs e)
		{
			iEditScript(m_ScriptNameComboBox.Text);
		}


		private void m_btnDebuggerEdit_Click(object sender, EventArgs e)
		{
			iDebugScript(m_ScriptNameComboBox.Text);
		}


		private void iDebugScript(string script_path)
		{
			if ("" != script_path && File.Exists(script_path))
			{
				iOpenLuaDeubgger();
				ShowLuaDebugger();
				if (LuaDebuggerPresent && m_LuaDebuggerForm.OpenFile(script_path) != null)
				{
					m_LuaDebuggerForm.AddFilePathToHistory(script_path);
				}
				iAddScriptToGuiSettings(script_path);
				return;
			}
			AlwaysPrint(string.Format("Error Opening script: Could not find script path \"{0}\"\n", script_path));
		}


		private void iEditScript(string script_path)
		{
			string fileName = "notepad.exe";
			if ("" != script_path && File.Exists(script_path))
			{
				try
				{
					Process.Start(script_path);
				}
				catch (Exception)
				{
					try
					{
						Process.Start(fileName, script_path);
					}
					catch (Exception ex)
					{
						GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, "Attempt to edit script caused an exception:\n" + ex.Message, ex.StackTrace);
					}
				}
				iAddScriptToGuiSettings(script_path);
				return;
			}
			AlwaysPrint(string.Format("Error Editing script: Could not find script path \"{0}\"\n", script_path));
		}


		private void m_GoStopBtn_Click(object sender, EventArgs e)
		{
			if (m_bIsClientRunning)
			{
				iUserStop();
				return;
			}
			iUserGo();
		}


		private void m_btnAbort_Click(object sender, EventArgs e)
		{
			iUserAbort();
		}


		private void m_ScriptRunStopBtn_Click(object sender, EventArgs e)
		{
			ScriptRunStop();
		}


		private void m_btnPause_Click(object sender, EventArgs e)
		{
			PauseScript();
		}


		private void m_btnDebug_Click(object sender, EventArgs e)
		{
			string text = m_ScriptNameComboBox.Text;
			StartDebug(text, false);
		}


		private void m_BrowseTreeBtn_Click(object sender, EventArgs e)
		{
			VerbosePrint("RSTD.BrowseTree()\n");
			m_LuaExportedOps.BrowseTree();
		}


		private void m_ReggaeBtn_Click(object sender, EventArgs e)
		{
			VerbosePrint("RSTD.Reggae()\n");
			m_LuaExportedOps.Reggae();
		}


		private void m_WorkSetBtn_Click(object sender, EventArgs e)
		{
			m_BrowseTree.WorkSet.Show(m_DockPanel);
		}


		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			VerbosePrint("RSTD.ExitRstd()\n");
			object lockerAutoUpdateTimer = browse_tree.LockerAutoUpdateTimer;
			lock (lockerAutoUpdateTimer)
			{
				browse_tree.AutoUpdateTimer.Stop();
			}
			m_RstdSettings.SaveSettings();
			iSaveGuiSettings();
			iSaveLuaHistory();
			m_bIsRstdClosing = true;
			if (m_bIsClientRunning)
			{
				iUserAbort();
			}
			if (m_BrowseTree.MonitoredVars.bIsMonitoring)
			{
				m_BrowseTree.MonitoredVars.MonitorStop();
			}
			if (GuiCore.IsClientBuilt)
			{
				m_LuaExportedOps.UnBuild();
			}
			if (GuiCore.IsAlBuilt)
			{
				GuiCore.AL_UnBuild(false);
			}
			iSaveLayout();
			if (m_RstdSettings.bHasClients())
			{
				m_RstdSettings.SaveSettings();
			}
			iUnregisterLuaDlls();
		}


		private void iSaveLuaHistory()
		{
			string[] commandHistory = m_LuaShellForm.ShellTextBox.GetCommandHistory();
			if (File.Exists(m_LuaHistoryCommandFile))
			{
				File.SetAttributes(m_LuaHistoryCommandFile, FileAttributes.Normal);
				CheckLuaHistoryFile(commandHistory, true);
				return;
			}
			CheckLuaHistoryFile(commandHistory, false);
		}


		private void CheckLuaHistoryFile(string[] CommandHistoryToSaveArr, bool bIfFileExist)
		{
			int num = 0;
			if (bIfFileExist)
			{
				string[] array = File.ReadAllLines(m_LuaHistoryCommandFile);
				if (!int.TryParse(array[array.Length - 1], out num))
				{
					File.Delete(m_LuaHistoryCommandFile);
				}
				if (m_MAX_NUM_COMMANDS_IN_FILE < num + m_LuaShellForm.NumCommandEntered)
				{
					DialogResult dialogResult = (DialogResult)GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, "Lua History File Warning:\nLua history file passed the default size - 10,000 commands!\n\nWould you like to save the whole history file?\n\nIn case you choose 'Yes' - whole history file will be saved,\notherwise, only last 10,000 commands will be stored into history file.\n");
					if (dialogResult == DialogResult.No)
					{
						File.Delete(m_LuaHistoryCommandFile);
						if (m_MAX_NUM_COMMANDS_IN_FILE <= CommandHistoryToSaveArr.Length)
						{
							for (int i = 0; i < m_MAX_NUM_COMMANDS_IN_FILE; i++)
							{
								if (i == 0)
								{
									File.AppendAllText(m_LuaHistoryCommandFile, CommandHistoryToSaveArr[CommandHistoryToSaveArr.Length - m_MAX_NUM_COMMANDS_IN_FILE + i]);
								}
								else
								{
									File.AppendAllText(m_LuaHistoryCommandFile, "\n" + CommandHistoryToSaveArr[CommandHistoryToSaveArr.Length - m_MAX_NUM_COMMANDS_IN_FILE + i]);
								}
							}
							File.AppendAllText(m_LuaHistoryCommandFile, "\n" + m_MAX_NUM_COMMANDS_IN_FILE.ToString());
							return;
						}
						if (m_MAX_NUM_COMMANDS_IN_FILE <= array.Length + CommandHistoryToSaveArr.Length)
						{
							for (int i = 0; i < m_MAX_NUM_COMMANDS_IN_FILE - CommandHistoryToSaveArr.Length; i++)
							{
								if (i == 0)
								{
									File.AppendAllText(m_LuaHistoryCommandFile, CommandHistoryToSaveArr[CommandHistoryToSaveArr.Length - m_MAX_NUM_COMMANDS_IN_FILE + i]);
								}
								else
								{
									File.AppendAllText(m_LuaHistoryCommandFile, "\n" + CommandHistoryToSaveArr[CommandHistoryToSaveArr.Length - m_MAX_NUM_COMMANDS_IN_FILE + i]);
								}
							}
							File.AppendAllText(m_LuaHistoryCommandFile, "\n" + m_MAX_NUM_COMMANDS_IN_FILE.ToString());
							return;
						}
					}
					else if (dialogResult == DialogResult.Yes)
					{
						DeleteNumCommandInTheEndOfLuaHistoryFile(array);
						AppendToLuaShellHistoryFile(CommandHistoryToSaveArr, num);
						File.AppendAllText(m_LuaHistoryCommandFile, "\n" + CommandHistoryToSaveArr.Length);
						return;
					}
				}
				else if (m_LuaShellForm.NumCommandEntered > 0)
				{
					if (!(CommandHistoryToSaveArr[CommandHistoryToSaveArr.Length - m_LuaShellForm.NumCommandEntered] == array[array.Length - 2]))
					{
						DeleteNumCommandInTheEndOfLuaHistoryFile(array);
						AppendToLuaShellHistoryFile(CommandHistoryToSaveArr, num);
						File.AppendAllText(m_LuaHistoryCommandFile, "\n" + CommandHistoryToSaveArr.Length);
						return;
					}
					DeleteNumCommandInTheEndOfLuaHistoryFile(array);
					for (int i = num; i < CommandHistoryToSaveArr.Length; i++)
					{
						if (i == num)
						{
							File.AppendAllText(m_LuaHistoryCommandFile, CommandHistoryToSaveArr[i]);
						}
						else
						{
							File.AppendAllText(m_LuaHistoryCommandFile, "\n" + CommandHistoryToSaveArr[i]);
						}
					}
					if (1 == m_LuaShellForm.NumCommandEntered)
					{
						File.AppendAllText(m_LuaHistoryCommandFile, CommandHistoryToSaveArr.Length.ToString());
						return;
					}
					File.AppendAllText(m_LuaHistoryCommandFile, "\n" + CommandHistoryToSaveArr.Length);
					return;
				}
			}
			else if (m_MAX_NUM_COMMANDS_IN_FILE <= CommandHistoryToSaveArr.Length)
			{
				if (GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, "Lua History File Warning: Lua history file passed the default size - 10,000 commands!\n\nWould you like to save the whole history file?\n\nIn case you choose 'Yes' - whole history file will be saved,\notherwise, only last 10,000 commands will be stored into history file.\n") == 7U)
				{
					int i;
					for (i = 0; i < m_MAX_NUM_COMMANDS_IN_FILE; i++)
					{
						if (i == 0)
						{
							File.AppendAllText(m_LuaHistoryCommandFile, CommandHistoryToSaveArr[CommandHistoryToSaveArr.Length - m_MAX_NUM_COMMANDS_IN_FILE + i]);
						}
						else
						{
							File.AppendAllText(m_LuaHistoryCommandFile, "\n" + CommandHistoryToSaveArr[CommandHistoryToSaveArr.Length - m_MAX_NUM_COMMANDS_IN_FILE + i]);
						}
					}
					File.AppendAllText(m_LuaHistoryCommandFile, "\n" + i.ToString());
					return;
				}
				AppendToLuaShellHistoryFile(CommandHistoryToSaveArr, num);
				File.AppendAllText(m_LuaHistoryCommandFile, "\n" + CommandHistoryToSaveArr.Length);
				return;
			}
			else if (CommandHistoryToSaveArr.Length != 0)
			{
				AppendToLuaShellHistoryFile(CommandHistoryToSaveArr, num);
				File.AppendAllText(m_LuaHistoryCommandFile, "\n" + CommandHistoryToSaveArr.Length);
			}
		}


		private void AppendToLuaShellHistoryFile(string[] CommandHistoryToSaveArr, int NumCommandsInFile)
		{
			if (CommandHistoryToSaveArr.Length > NumCommandsInFile)
			{
				for (int i = NumCommandsInFile; i < CommandHistoryToSaveArr.Length; i++)
				{
					if (i == NumCommandsInFile)
					{
						File.AppendAllText(m_LuaHistoryCommandFile, CommandHistoryToSaveArr[i]);
					}
					else
					{
						File.AppendAllText(m_LuaHistoryCommandFile, "\n" + CommandHistoryToSaveArr[i]);
					}
				}
			}
		}


		private void DeleteNumCommandInTheEndOfLuaHistoryFile(string[] FileLinesArr)
		{
			string text = "";
			foreach (string str in FileLinesArr)
			{
				text = text + "\n" + str;
			}
			FileStream fileStream = File.OpenWrite(m_LuaHistoryCommandFile);
			fileStream.SetLength(fileStream.Length - (fileStream.Length - (long)text.LastIndexOf('\n')));
			fileStream.Close();
		}


		private void m_BottomToolStrip_Resize(object sender, EventArgs e)
		{
			if (m_BottomToolStrip.Width > 0)
			{
				int num = 20;
				int num2 = 0;
				foreach (object obj in m_BottomToolStrip.Items)
				{
					ToolStripItem toolStripItem = (ToolStripItem)obj;
					if (toolStripItem != m_ScriptNameComboBox)
					{
						num2 += toolStripItem.Width;
					}
				}
				m_ScriptNameComboBox.Width = m_BottomToolStrip.Width - num2 - num;
			}
			m_ScriptNameComboBox.SelectionLength = 0;
		}


		private void m_MonitoredVarsBtn_Click(object sender, EventArgs e)
		{
			GuiCore.VerbosePrint("RSTD.MonitorShow()\n");
			m_BrowseTree.MonitorShow();
		}


		private void m_ConsoleBtn_Click(object sender, EventArgs e)
		{
			m_OutputForm.Show(m_DockPanel);
		}


		public void ShowWindow(DockContent window)
		{
			window.Show(m_DockPanel);
		}


		private void m_ScriptNameComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (GuiCore.OperationPending)
			{
				return;
			}
			if (e.KeyCode == Keys.Return && !frmMain.bIsScriptRunning)
			{
				iStartScriptFromCombo();
			}
		}


		private void frmMain_KeyDown(object sender, KeyEventArgs e)
		{
			bool operationPending = GuiCore.OperationPending;
		}


		private void m_BtnLuaShell_Click(object sender, EventArgs e)
		{
			m_LuaShellForm.Show(m_DockPanel);
		}


		private void m_btnLuaDebugger_Click(object sender, EventArgs e)
		{
			iOpenLuaDeubgger();
			ShowLuaDebugger();
		}


		private void Server_StateChanged(object sender, ServerEventArgs e)
		{
			iUpdateConnectionState((RstdServer)sender, e.State);
		}


		private void iUpdateConnectionState(RstdServer server, ServerState state)
		{
			if (base.InvokeRequired)
			{
				frmMain.dGuiOperDel_UpdateConState method = new frmMain.dGuiOperDel_UpdateConState(iUpdateConnectionState);
				base.Invoke(method, new object[]
				{
					server,
					state
				});
				return;
			}
			try
			{
				switch (state)
				{
				case ServerState.Disconnected:
					AlwaysPrint(string.Format("RstdNet: Port {0}: Closed\n", server.Port));
					break;
				case ServerState.Listening:
					if (server.ClientIP != null)
					{
						AlwaysPrint(string.Format("RstdNet: Port {0}: Client {1} - Disconnected\n", server.Port, server.ClientIP));
					}
					else
					{
						AlwaysPrint(string.Format("RstdNet: Port {0}: Listening..\n", server.Port));
					}
					break;
				case ServerState.Connected:
					if (server.ClientIP != null)
					{
						AlwaysPrint(string.Format("RstdNet: Port {0}: Client {1} - Connected\n", server.Port, server.ClientIP));
					}
					else
					{
						AlwaysPrint(string.Format("RstdNet: Port {0}: Client Connected (could not resolve address)\n", server.Port));
					}
					break;
				}
				string text = "";
				string arg = "";
				bool flag = false;
				foreach (RstdServer rstdServer in m_Servers)
				{
					ServerState state2 = rstdServer.State;
					if (state2 != ServerState.Listening)
					{
						if (state2 == ServerState.Connected)
						{
							arg = rstdServer.ClientIP;
							flag = true;
						}
					}
					else
					{
						arg = "listening..";
					}
					if (rstdServer.State != ServerState.Disconnected)
					{
						if (text != "")
						{
							text += " || ";
						}
						text += string.Format("{0}: {1}", rstdServer.Port, arg);
					}
				}
				if (text == "")
				{
					text = "Closed";
				}
				m_lblNetClientStatus.Text = text;
				if (flag)
				{
					m_lblNetClientStatus.ForeColor = Color.DarkGreen;
				}
				else
				{
					m_lblNetClientStatus.ForeColor = Color.DarkRed;
				}
			}
			catch (Exception ex)
			{
				GuiCore.RstdException(ex.Message + "\n" + ex.InnerException, ex.StackTrace);
			}
		}


		public void UpdateStandardToolbarButtonsSize()
		{
			if (RstdGuiSettings.Default.StandardBtnsSize == StandardButtonsSize.LARGE)
			{
				m_ToolBar.ImageScalingSize = new Size(49, 49);
			}
			else
			{
				m_ToolBar.ImageScalingSize = new Size(16, 16);
			}
			for (int i = 0; i < m_ToolBar.Items.Count; i++)
			{
				if (m_ToolBar.Items[i] is ToolStripButton)
				{
					if (RstdGuiSettings.Default.StandardBtnsSize == StandardButtonsSize.LARGE)
					{
						m_ToolBar.Items[i].AutoSize = false;
						m_ToolBar.Items[i].Size = new Size(49, 49);
						if (m_ToolBar.Items[i] == m_btnLuaDebugger)
						{
							m_ToolBar.Items[i].ImageScaling = ToolStripItemImageScaling.SizeToFit;
						}
						else
						{
							m_ToolBar.Items[i].ImageScaling = ToolStripItemImageScaling.None;
						}
						m_ToolBar.Items[i].DisplayStyle = ToolStripItemDisplayStyle.Image;
					}
					else
					{
						m_ToolBar.Items[i].AutoSize = true;
						m_ToolBar.Items[i].Size = new Size(49, 22);
						m_ToolBar.Items[i].ImageScaling = ToolStripItemImageScaling.SizeToFit;
						m_ToolBar.Items[i].DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
					}
				}
			}
		}


		private void btnNewScriptButton_Click(object sender, EventArgs e)
		{
			ToolStrip owner = ((ToolStripButton)sender).Owner;
			int num = RstdGuiSettings.Default.UserToolStrips.IndexOf((UserToolStripInfo)owner.Tag);
			frmUserButtonConfig frmUserButtonConfig = new frmUserButtonConfig(num);
			if (frmUserButtonConfig.ShowDialog() == DialogResult.OK)
			{
				((UserToolStripInfo)owner.Tag).ToolBarUserButtons.Add(frmUserButtonConfig.UserButtonInfo);
				iAddUserButton(frmUserButtonConfig.UserButtonInfo, owner);
				RstdGuiSettings.Default.SaveUserButtons(num);
			}
		}


		private void iAddUserButtonFromDragDrop(UserButtonInfo user_btn_info, ToolStrip tool_strip, int index)
		{
			if (!user_btn_info.Show)
			{
				return;
			}
			ToolStripButton toolStripButton = new ToolStripButton(iGetUserButtonText(user_btn_info));
			ToolStripSeparator value = new ToolStripSeparator();
			toolStripButton.ToolTipText = user_btn_info.ToolTip;
			toolStripButton.Tag = user_btn_info;
			toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
			toolStripButton.Image = user_btn_info.Icon;
			toolStripButton.Size = new Size(60, 22);
			toolStripButton.BackColor = user_btn_info.UserColor;
			tool_strip.Items.Insert(index, toolStripButton);
			tool_strip.Items.Insert(index + 1, value);
			toolStripButton.MouseDown += btnUserScript_MouseDown;
		}


		private void iAddUserButton(UserButtonInfo user_btn_info, ToolStrip tool_strip)
		{
			if (!user_btn_info.Show)
			{
				return;
			}
			ToolStripButton toolStripButton = new ToolStripButton(iGetUserButtonText(user_btn_info));
			ToolStripSeparator value = new ToolStripSeparator();
			toolStripButton.ToolTipText = user_btn_info.ToolTip;
			toolStripButton.Tag = user_btn_info;
			toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
			toolStripButton.Image = user_btn_info.Icon;
			toolStripButton.Size = new Size(60, 22);
			toolStripButton.BackColor = user_btn_info.UserColor;
			tool_strip.Items.Insert(tool_strip.Items.Count - 2, toolStripButton);
			tool_strip.Items.Insert(tool_strip.Items.Count - 2, value);
			toolStripButton.MouseDown += btnUserScript_MouseDown;
		}


		private void btnUserScript_MouseDown(object sender, MouseEventArgs e)
		{
			UserToolStripInfo userToolStripInfo = (UserToolStripInfo)((ToolStripButton)sender).Owner.Tag;
			m_ClickedToolStripIndex = RstdGuiSettings.Default.UserToolStrips.IndexOf(userToolStripInfo);
			if (e.Button == MouseButtons.Left)
			{
				if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					ToolStripItem item = (ToolStripButton)sender;
					m_UserButtonClicked = GetUserButtonClicked(item);
					if (m_UserButtonClicked != null)
					{
						base.DoDragDrop(m_UserButtonClicked, DragDropEffects.Move);
						return;
					}
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				ToolStripItem item2 = (ToolStripButton)sender;
				m_UserButtonClicked = GetUserButtonClicked(item2);
				if (m_UserButtonClicked != null && !m_UserButtonClicked.IsOnOverflow)
				{
					return;
				}
				m_UserButtonsContextMenuStrip.OwnerItem = (ToolStripButton)sender;
				m_UserButtonsContextMenuStrip.Show(Control.MousePosition.X - 220, Control.MousePosition.Y + 20);
				if (m_UserButtonClicked != null && m_UserButtonClicked.IsOnOverflow)
				{
					bool flag = ((UserButtonInfo)m_UserButtonClicked.Tag).SourceType == LuaSourceType.File;
					bool flag2 = ((UserButtonInfo)m_UserButtonClicked.Tag).SourceType == LuaSourceType.Function && !string.IsNullOrEmpty(((UserButtonInfo)m_UserButtonClicked.Tag).FunctionSource);
					m_UserButtonClicked.Checked = true;
					EditButtonToolStripMenuItem.Enabled = true;
					EditScriptToolStripMenuItem.Enabled = (flag || flag2);
					DebugScriptToolStripMenuItem.Enabled = flag;
					DeleteButtonToolStripMenuItem.Enabled = true;
				}
				else
				{
					EditButtonToolStripMenuItem.Enabled = false;
					EditScriptToolStripMenuItem.Enabled = false;
					DebugScriptToolStripMenuItem.Enabled = false;
					DeleteButtonToolStripMenuItem.Enabled = false;
				}
				iSetUserButtonMenuVisiblity(userToolStripInfo.IsReadOnly);
			}
		}


		private void new_toolstrip_DragEnter(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(typeof(ToolStripButton)))
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			e.Effect = DragDropEffects.Move;
		}


		private void new_toolstrip_DragLeave(object sender, EventArgs e)
		{
			((ToolStrip)sender).Items[m_LastDropIndex].BackColor = m_UserButtonBackColor;
		}


		private void new_toolstrip_DragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(ToolStripButton)))
			{
				ToolStrip toolStrip = (ToolStrip)sender;
				if (m_LastDropIndex != -1)
				{
					toolStrip.Items[m_LastDropIndex].BackColor = m_UserButtonBackColor;
				}
				m_LastDropIndex = GetDropIndex(toolStrip, toolStrip.PointToClient(new Point(e.X, e.Y)));
				m_UserButtonBackColor = toolStrip.Items[m_LastDropIndex].BackColor;
				toolStrip.Items[m_LastDropIndex].BackColor = Color.DarkSalmon;
			}
		}


		private void new_toolstrip_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(ToolStripButton)))
			{
				ToolStripButton toolStripButton = e.Data.GetData(typeof(ToolStripButton)) as ToolStripButton;
				ToolStrip owner = toolStripButton.Owner;
				ToolStrip toolStrip = (ToolStrip)sender;
				int num = RstdGuiSettings.Default.UserToolStrips.IndexOf((UserToolStripInfo)owner.Tag);
				int num2 = RstdGuiSettings.Default.UserToolStrips.IndexOf((UserToolStripInfo)toolStrip.Tag);
				if (iCheckToolStripFileIsReadOnly(num2))
				{
					return;
				}
				toolStrip.Items[m_LastDropIndex].BackColor = m_UserButtonBackColor;
				int dropIndex = GetDropIndex(toolStrip, toolStrip.PointToClient(new Point(e.X, e.Y)));
				if (dropIndex != -1)
				{
					int num3 = (dropIndex - 1) / 2;
					int num4 = RstdGuiSettings.Default.UserToolStrips[num].ToolBarUserButtons.IndexOf((UserButtonInfo)toolStripButton.Tag);
					RstdGuiSettings.Default.UserToolStrips[num2].ToolBarUserButtons.Insert((dropIndex - 1) / 2, (UserButtonInfo)toolStripButton.Tag);
					if (toolStrip == owner && (dropIndex - 1) / 2 < num4)
					{
						RstdGuiSettings.Default.UserToolStrips[num].ToolBarUserButtons.RemoveAt(num4 + 1);
					}
					else
					{
						RstdGuiSettings.Default.UserToolStrips[num].ToolBarUserButtons.RemoveAt(num4);
					}
					iAddUserButtonFromDragDrop((UserButtonInfo)toolStripButton.Tag, toolStrip, dropIndex);
					int index = toolStripButton.Owner.Items.IndexOf(toolStripButton);
					owner.Items.RemoveAt(index);
					owner.Items.RemoveAt(index);
					RstdGuiSettings.Default.SaveUserButtons(num);
					RstdGuiSettings.Default.SaveUserButtons(num2);
				}
			}
		}


		public void ExecuteUserButton(UserButtonInfo user_button_info)
		{
			string text = user_button_info.UserButtonSource;
			if (user_button_info.SourceType == LuaSourceType.File)
			{
				text = iGetFullFilePath(text);
				if (!File.Exists(text))
				{
					AlwaysPrint(string.Format("Error running script: Could not find script path \"{0}\"\n", text));
					return;
				}
				if (Path.GetExtension(text).ToLower() == ".lua")
				{
					bStartScript(text, user_button_info.Params, LuaSourceType.File);
					return;
				}
				if (Path.GetExtension(text).ToLower() == ".txt")
				{
					string arg = "/HAL6450/HCI/Functions/Run HCI Script Remotely";
					m_LuaExportedOps.RunFunction(string.Format("{0}({1})", arg, text));
					return;
				}
			}
			else
			{
				if (user_button_info.SourceType == LuaSourceType.Function && !string.IsNullOrEmpty(user_button_info.FunctionSource))
				{
					try
					{
						LuaWrapperUtils.LuaWrapper.DoFile(iGetFullFilePath(user_button_info.FunctionSource));
					}
					catch (Exception ex)
					{
						LuaWrapperUtils.LuaWrapper.PrintError(ex.Message);
						return;
					}
				}
				bStartScript(text, user_button_info.Params, user_button_info.SourceType);
			}
		}


		private void iActivateUserButton(ToolStripButton user_btn_info)
		{
			if (user_btn_info.Tag != null && !string.IsNullOrEmpty(((UserButtonInfo)user_btn_info.Tag).UserButtonSource))
			{
				ExecuteUserButton((UserButtonInfo)user_btn_info.Tag);
			}
		}


		private void iSetUserButtonMenuVisiblity(bool is_read_only)
		{
			EditButtonToolStripMenuItem.Visible = !is_read_only;
			DebugScriptToolStripMenuItem.Visible = !is_read_only;
			DeleteButtonToolStripMenuItem.Visible = !is_read_only;
			addButtonsToolStripMenuItem.Visible = !is_read_only;
			LoadButtonsToolStripMenuItem.Visible = !is_read_only;
			SaveButtonsToolStripMenuItem.Visible = !is_read_only;
			changeToolbarNameToolStripMenuItem.Visible = !is_read_only;
		}


		private void userToolStrip_MouseClick(object sender, MouseEventArgs e)
		{
			ToolStrip toolStrip = (ToolStrip)sender;
			UserToolStripInfo userToolStripInfo = (UserToolStripInfo)toolStrip.Tag;
			m_ClickedToolStripIndex = RstdGuiSettings.Default.UserToolStrips.IndexOf(userToolStripInfo);
			if (e.Button == MouseButtons.Right)
			{
				m_UserButtonClicked = GetUserButtonClicked(toolStrip, e.Location);
				if (m_UserButtonClicked != null && m_UserButtonClicked.IsOnOverflow)
				{
					return;
				}
				m_UserButtonsContextMenuStrip.Show(Control.MousePosition);
				if (m_UserButtonClicked != null)
				{
					if (m_UserButtonClicked.Tag != null)
					{
						bool flag = ((UserButtonInfo)m_UserButtonClicked.Tag).SourceType == LuaSourceType.File;
						bool flag2 = ((UserButtonInfo)m_UserButtonClicked.Tag).SourceType == LuaSourceType.Function && !string.IsNullOrEmpty(((UserButtonInfo)m_UserButtonClicked.Tag).FunctionSource);
						m_UserButtonClicked.Checked = true;
						EditButtonToolStripMenuItem.Enabled = true;
						EditScriptToolStripMenuItem.Enabled = (flag || flag2);
						DebugScriptToolStripMenuItem.Enabled = flag;
						DeleteButtonToolStripMenuItem.Enabled = true;
					}
					else
					{
						EditButtonToolStripMenuItem.Enabled = false;
						EditScriptToolStripMenuItem.Enabled = false;
						DebugScriptToolStripMenuItem.Enabled = false;
						DeleteButtonToolStripMenuItem.Enabled = false;
					}
				}
				else
				{
					EditButtonToolStripMenuItem.Enabled = false;
					EditScriptToolStripMenuItem.Enabled = false;
					DebugScriptToolStripMenuItem.Enabled = false;
					DeleteButtonToolStripMenuItem.Enabled = false;
				}
				iSetUserButtonMenuVisiblity(userToolStripInfo.IsReadOnly);
			}
		}


		private void new_toolstrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			m_UserButtonClicked = GetUserButtonClicked(e.ClickedItem);
			if (m_UserButtonClicked != null)
			{
				iActivateUserButton(m_UserButtonClicked);
			}
		}


		private ToolStripButton GetUserButtonClicked(ToolStrip user_toolstrip, Point location)
		{
			ToolStripItem itemAt = user_toolstrip.GetItemAt(location);
			if (itemAt is ToolStripButton)
			{
				return (ToolStripButton)itemAt;
			}
			return null;
		}


		private int GetDropIndex(ToolStrip user_toolstrip, Point location)
		{
			int num = -1;
			ToolStripItem itemAt = user_toolstrip.GetItemAt(location);
			if (itemAt != null)
			{
				num = user_toolstrip.Items.IndexOf(itemAt);
				if (itemAt is ToolStripSeparator)
				{
					num--;
				}
				else if (itemAt is ToolStripLabel)
				{
					num = 1;
				}
			}
			return num;
		}


		private ToolStripButton GetUserButtonClicked(ToolStripItem item)
		{
			if (item is ToolStripButton)
			{
				return (ToolStripButton)item;
			}
			return null;
		}


		private void EditScriptToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string text = (((UserButtonInfo)m_UserButtonClicked.Tag).SourceType == LuaSourceType.Function) ? ((UserButtonInfo)m_UserButtonClicked.Tag).FunctionSource : ((UserButtonInfo)m_UserButtonClicked.Tag).UserButtonSource;
			if (m_UserButtonClicked != null && (UserButtonInfo)m_UserButtonClicked.Tag != null && !string.IsNullOrEmpty(text))
			{
				text = iGetFullFilePath(text);
				iEditScript(text);
			}
		}


		private void DebugScriptToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_UserButtonClicked != null && (UserButtonInfo)m_UserButtonClicked.Tag != null && !string.IsNullOrEmpty(((UserButtonInfo)m_UserButtonClicked.Tag).UserButtonSource))
			{
				string script_path = iGetFullFilePath(((UserButtonInfo)m_UserButtonClicked.Tag).UserButtonSource);
				iDebugScript(script_path);
			}
		}


		private void EditButtonToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_UserButtonClicked != null)
			{
				m_UserButtonClicked.Checked = true;
				ToolStrip owner = m_UserButtonClicked.Owner;
				int num = RstdGuiSettings.Default.UserToolStrips.IndexOf((UserToolStripInfo)owner.Tag);
				if (new frmUserButtonConfig((UserButtonInfo)m_UserButtonClicked.Tag, num).ShowDialog() == DialogResult.OK)
				{
					m_UserButtonClicked.Text = iGetUserButtonText((UserButtonInfo)m_UserButtonClicked.Tag);
					m_UserButtonClicked.BackColor = ((UserButtonInfo)m_UserButtonClicked.Tag).UserColor;
					m_UserButtonClicked.Image = ((UserButtonInfo)m_UserButtonClicked.Tag).Icon;
					if (!((UserToolStripInfo)owner.Tag).IsFileReadOnly())
					{
						RstdGuiSettings.Default.SaveUserButtons(num);
					}
				}
				m_UserButtonClicked.Checked = false;
			}
		}


		private string iGetUserButtonText(UserButtonInfo btn_info)
		{
			string text = btn_info.Title;
			if (btn_info.Params != null && btn_info.Params.Count > 0)
			{
				text += "(";
				foreach (ScriptParam scriptParam in btn_info.Params)
				{
					if (text.Length + scriptParam.Value.Length > 45)
					{
						text += "...";
						break;
					}
					text += scriptParam.Value;
					if (!scriptParam.Equals(btn_info.Params[btn_info.Params.Count - 1]))
					{
						text += ",";
					}
				}
				text += ")";
			}
			return text;
		}


		private bool iCheckToolStripFileIsReadOnly(int tool_strip_idx)
		{
			UserToolStripInfo userToolStripInfo = RstdGuiSettings.Default.UserToolStrips[tool_strip_idx];
			if (userToolStripInfo.IsFileReadOnly())
			{
				GuiCore.WarningMsgBox(string.Format("Can't modify user tool strip since access to toolstrip file: \n\"{0}\" is denied.\nFile is read-only.", userToolStripInfo.ToolBarConfigFile));
				return true;
			}
			return false;
		}


		private void DeleteButtonToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool flag = false;
			ToolStripItem value = null;
			if (m_UserButtonClicked != null)
			{
				ToolStrip owner = m_UserButtonClicked.Owner;
				int num = RstdGuiSettings.Default.UserToolStrips.IndexOf((UserToolStripInfo)owner.Tag);
				if (iCheckToolStripFileIsReadOnly(num))
				{
					return;
				}
				int num2 = 0;
				while (num2 < owner.Items.Count && !flag)
				{
					if (owner.Items[num2] == m_UserButtonClicked)
					{
						value = owner.Items[num2 + 1];
						flag = true;
					}
					num2++;
				}
				if (flag)
				{
					string msg = string.Format("Button \"{0}\" Will be deleted. Are you sure?", ((UserButtonInfo)m_UserButtonClicked.Tag).Title);
					if (GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, msg) == 6U)
					{
						owner.Items.Remove(m_UserButtonClicked);
						owner.Items.Remove(value);
						RstdGuiSettings.Default.UserToolStrips[num].ToolBarUserButtons.Remove((UserButtonInfo)m_UserButtonClicked.Tag);
						RstdGuiSettings.Default.SaveUserButtons(num);
					}
				}
			}
		}


		private void AddButtonsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (iCheckToolStripFileIsReadOnly(m_ClickedToolStripIndex))
			{
				return;
			}
			string text = GuiCore.OpenFileDialog(null, FileType.XML);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			RstdGuiSettings.Default.Load(text, false, m_ClickedToolStripIndex);
			LoadUserButtons((ToolStrip)toolStripContainer1.TopToolStripPanel.Controls[m_ClickedToolStripIndex], RstdGuiSettings.Default.UserToolStrips[m_ClickedToolStripIndex]);
			RstdGuiSettings.Default.SaveUserButtons(m_ClickedToolStripIndex);
		}


		private void LoadButtonsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (iCheckToolStripFileIsReadOnly(m_ClickedToolStripIndex))
			{
				return;
			}
			string text = GuiCore.OpenFileDialog(null, FileType.XML);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, "All current buttons will be removed. Are you sure?") == 6U)
			{
				RstdGuiSettings.Default.Load(text, true, m_ClickedToolStripIndex);
				LoadUserButtons((ToolStrip)toolStripContainer1.TopToolStripPanel.Controls[m_ClickedToolStripIndex], RstdGuiSettings.Default.UserToolStrips[m_ClickedToolStripIndex]);
				RstdGuiSettings.Default.SaveUserButtons(m_ClickedToolStripIndex);
			}
		}


		public void LoadUserToolStrips()
		{
			toolStripContainer1.TopToolStripPanel.Controls.Clear();
			for (int i = 4; i < toolBarsToolStripMenuItem1.DropDownItems.Count; i++)
			{
				toolBarsToolStripMenuItem1.DropDownItems.Remove(toolBarsToolStripMenuItem1.DropDownItems[i]);
				i--;
			}
			List<ToolStrip> list = new List<ToolStrip>();
			foreach (UserToolStripInfo userToolStripInfo in RstdGuiSettings.Default.UserToolStrips)
			{
				ToolStrip toolStrip = iCreateNewToolStrip(userToolStripInfo);
				LoadUserButtons(toolStrip, userToolStripInfo);
				list.Add(toolStrip);
			}
			iDisplayToolStrips(list);
		}


		private void iDisplayToolStrips(List<ToolStrip> tool_strips)
		{
			tool_strips.Sort(new Comparison<ToolStrip>(iSortToolStrips));
			foreach (ToolStrip toolStrip in tool_strips)
			{
				UserToolStripInfo userToolStripInfo = (UserToolStripInfo)toolStrip.Tag;
				toolStripContainer1.TopToolStripPanel.Join(toolStrip, userToolStripInfo.RowIndex);
			}
		}


		private int iSortToolStrips(ToolStrip ts1, ToolStrip ts2)
		{
			UserToolStripInfo userToolStripInfo = (UserToolStripInfo)ts1.Tag;
			UserToolStripInfo userToolStripInfo2 = (UserToolStripInfo)ts2.Tag;
			if (userToolStripInfo.RowIndex > userToolStripInfo2.RowIndex)
			{
				return 1;
			}
			if (userToolStripInfo.RowIndex < userToolStripInfo2.RowIndex)
			{
				return -1;
			}
			if (userToolStripInfo.ColIndex > userToolStripInfo2.ColIndex)
			{
				return -1;
			}
			if (userToolStripInfo.ColIndex < userToolStripInfo2.ColIndex)
			{
				return 1;
			}
			return 0;
		}


		public void LoadUserButtons(ToolStrip tool_strip, UserToolStripInfo user_tool_info)
		{
			for (int i = tool_strip.Items.Count - 3; i > 0; i--)
			{
				tool_strip.Items.RemoveAt(i);
			}
			foreach (UserButtonInfo user_btn_info in user_tool_info.ToolBarUserButtons)
			{
				iAddUserButton(user_btn_info, tool_strip);
			}
		}


		private void SaveButtonsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string filename = GuiCore.SaveDialogTxtOrXml(null, 1);
			RstdGuiSettings.Default.SaveUserButtons(m_ClickedToolStripIndex, filename);
		}


		private void m_UserButtonsContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			if (m_UserButtonClicked != null)
			{
				m_UserButtonClicked.Checked = false;
			}
		}


		private void changeToolbarNameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStrip tool_strip = (ToolStrip)toolStripContainer1.TopToolStripPanel.Controls[m_ClickedToolStripIndex];
			frmToolBarInfo frmToolBarInfo = new frmToolBarInfo(RstdGuiSettings.Default.UserToolStrips[m_ClickedToolStripIndex]);
			if (frmToolBarInfo.ShowDialog() == DialogResult.OK)
			{
				ChangeToolBarSettings(tool_strip, frmToolBarInfo.ToolBarName, frmToolBarInfo.ToolBarBasePath);
				iChangeToolStripName(tool_strip);
			}
		}


		private void iChangeToolStripName(ToolStrip tool_strip)
		{
			for (int i = 4; i < toolBarsToolStripMenuItem1.DropDownItems.Count; i++)
			{
				if (tool_strip == toolBarsToolStripMenuItem1.DropDownItems[i].Tag)
				{
					toolBarsToolStripMenuItem1.DropDownItems[i].Text = tool_strip.Items[0].Text;
					return;
				}
			}
		}


		public void ChangeToolBarSettings(ToolStrip tool_strip, string name, string base_path)
		{
			tool_strip.Items[0].Text = name;
			int num = RstdGuiSettings.Default.UserToolStrips.IndexOf((UserToolStripInfo)tool_strip.Tag);
			RstdGuiSettings.Default.UserToolStrips[num].ToolBarName = name;
			RstdGuiSettings.Default.UserToolStrips[num].ToolBarBasePath = base_path;
			RstdGuiSettings.Default.SaveUserButtons(num);
		}


		private string iGetFullFilePath(string source)
		{
			if (source.StartsWith("\\"))
			{
				source = source.Remove(0, 1);
			}
			if (!Path.IsPathRooted(source))
			{
				source = Path.Combine(RstdGuiSettings.Default.ParseBasePath(RstdGuiSettings.Default.UserToolStrips[m_ClickedToolStripIndex].ToolBarBasePath), source);
			}
			return source;
		}


		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmToolBarInfo frmToolBarInfo = new frmToolBarInfo();
			if (frmToolBarInfo.ShowDialog() == DialogResult.OK)
			{
				string text = m_SettingsOutputPath + "\\ToolBars";
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				UserToolStripInfo userToolStripInfo = new UserToolStripInfo();
				userToolStripInfo.ToolBarName = frmToolBarInfo.ToolBarName;
				userToolStripInfo.ToolBarBasePath = frmToolBarInfo.ToolBarBasePath;
				if (File.Exists(Path.Combine(text, "UserButtons_" + userToolStripInfo.ToolBarName + ".xml")))
				{
					for (int i = 0; i < 1000; i++)
					{
						if (!File.Exists(Path.Combine(text, string.Concat(new object[]
						{
							"UserButtons_",
							userToolStripInfo.ToolBarName,
							i,
							".xml"
						}))))
						{
							userToolStripInfo.ToolBarConfigFile = Path.Combine(text, string.Concat(new object[]
							{
								"UserButtons_",
								userToolStripInfo.ToolBarName,
								i,
								".xml"
							}));
							break;
						}
					}
				}
				else
				{
					userToolStripInfo.ToolBarConfigFile = Path.Combine(text, "UserButtons_" + userToolStripInfo.ToolBarName + ".xml");
				}
				RstdGuiSettings.Default.UserToolStrips.Add(userToolStripInfo);
				RstdGuiSettings.Default.SaveUserButtons(RstdGuiSettings.Default.UserToolStrips.Count - 1);
				ToolStrip toolStripToDrag = iCreateNewToolStrip(userToolStripInfo);
				toolStripContainer1.TopToolStripPanel.Join(toolStripToDrag, toolStripContainer1.TopToolStripPanel.Rows.Length);
			}
		}


		private ToolStrip iCreateNewToolStrip(UserToolStripInfo tool_info)
		{
			ToolStrip toolStrip = new ToolStrip();
			toolStrip.AllowDrop = !tool_info.IsReadOnly;
			toolStrip.DragEnter += new_toolstrip_DragEnter;
			toolStrip.DragDrop += new_toolstrip_DragDrop;
			toolStrip.DragOver += new_toolstrip_DragOver;
			toolStrip.DragLeave += new_toolstrip_DragLeave;
			toolStrip.SuspendLayout();
			ToolStripLabel toolStripLabel = new ToolStripLabel(tool_info.ToolBarName);
			toolStripLabel.Font = new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			toolStripLabel.ForeColor = Color.MediumVioletRed;
			toolStripLabel.Margin = new Padding(3, 1, 3, 2);
			toolStripLabel.Name = "nameToolStripLabel";
			toolStripLabel.Size = new Size(105, 22);
			ToolStripButton toolStripButton = new ToolStripButton();
			toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
			toolStripButton.ImageTransparentColor = Color.Magenta;
			toolStripButton.Name = "btnNewScriptButton";
			toolStripButton.Size = new Size(47, 22);
			toolStripButton.Text = "<new>";
			toolStripButton.Visible = !tool_info.IsReadOnly;
			toolStripButton.Click += btnNewScriptButton_Click;
			ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
			toolStripSeparator.Visible = !tool_info.IsReadOnly;
			toolStrip.Dock = DockStyle.None;
			toolStrip.Items.AddRange(new ToolStripItem[]
			{
				toolStripLabel,
				toolStripButton,
				toolStripSeparator
			});
			toolStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
			toolStrip.Location = new Point(3, 0);
			toolStrip.Size = new Size(176, 25);
			toolStrip.MouseClick += userToolStrip_MouseClick;
			toolStrip.ItemClicked += new_toolstrip_ItemClicked;
			toolStrip.ResumeLayout(false);
			toolStrip.PerformLayout();
			toolStrip.Tag = tool_info;
			iAddToolStripMenuItem(toolStrip, tool_info);
			return toolStrip;
		}


		private void iAddToolStripMenuItem(ToolStrip tool_strip, UserToolStripInfo tool_info)
		{
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(tool_info.ToolBarName);
			toolStripMenuItem.Size = new Size(152, 22);
			toolStripMenuItem.Click += tool_strip_menu_Click;
			tool_strip.Visible = (toolStripMenuItem.Checked = tool_info.Show);
			toolStripMenuItem.Tag = tool_strip;
			toolBarsToolStripMenuItem1.DropDownItems.Add(toolStripMenuItem);
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("Remove");
			toolStripMenuItem2.Size = new Size(152, 22);
			toolStripMenuItem2.Click += delete_menu_Click;
			toolStripMenuItem.DropDownItems.Add(toolStripMenuItem2);
		}


		private void delete_menu_Click(object sender, EventArgs e)
		{
			if (GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.QEUSTION, "This Action will remove the selected toolbar. Are you sure?") == 6U)
			{
				ToolStrip tool_strip = (ToolStrip)((ToolStripMenuItem)sender).OwnerItem.Tag;
				iDeleteToolStrip(tool_strip);
				toolBarsToolStripMenuItem1.DropDownItems.Remove(((ToolStripMenuItem)sender).OwnerItem);
			}
		}


		private void iDeleteToolStrip(ToolStrip tool_strip)
		{
			toolStripContainer1.TopToolStripPanel.Controls.Remove(tool_strip);
			RstdGuiSettings.Default.UserToolStrips.Remove((UserToolStripInfo)tool_strip.Tag);
		}


		private void tool_strip_menu_Click(object sender, EventArgs e)
		{
			ToolStrip toolStrip = (ToolStrip)((ToolStripMenuItem)sender).Tag;
			if (((ToolStripMenuItem)sender).Checked)
			{
				((UserToolStripInfo)toolStrip.Tag).Show = (toolStrip.Visible = (((ToolStripMenuItem)sender).Checked = false));
				return;
			}
			((UserToolStripInfo)toolStrip.Tag).Show = (toolStrip.Visible = (((ToolStripMenuItem)sender).Checked = true));
		}


		private void toolStripContainer1_TopToolStripPanel_SizeChanged(object sender, EventArgs e)
		{
			toolStripContainer1.Height = toolStripContainer1.TopToolStripPanel.Height;
		}


		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string text = GuiCore.OpenFileDialog(null, FileType.XML);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			UserToolStripInfo userToolStripInfo = new UserToolStripInfo("", "", text, true);
			RstdGuiSettings.Default.Load(userToolStripInfo);
			RstdGuiSettings.Default.UserToolStrips.Add(userToolStripInfo);
			ToolStrip toolStrip = iCreateNewToolStrip(userToolStripInfo);
			LoadUserButtons(toolStrip, userToolStripInfo);
			toolStripContainer1.TopToolStripPanel.Join(toolStrip, toolStripContainer1.TopToolStripPanel.Rows.Length);
		}


		private void iAddDefaultToolStrip(string file_name)
		{
			if (string.IsNullOrEmpty(file_name))
			{
				return;
			}
			if (!File.Exists(file_name))
			{
				return;
			}
			UserToolStripInfo userToolStripInfo = new UserToolStripInfo("", "", file_name, true, true, true);
			RstdGuiSettings.Default.Load(userToolStripInfo);
			RstdGuiSettings.Default.UserToolStrips.Add(userToolStripInfo);
		}


		private void m_SubsetLoad_Click(object sender, EventArgs e)
		{
			string file_name = "New SubSet " + m_SubSetList.Count.ToString();
			file_name = GuiCore.OpenFileDialog(null, FileType.CSV);
			LoadSubset(file_name);
		}


		private void newSubSetMenu_Click(object sender, EventArgs e)
		{
			CreateSubset();
		}


		public int CreateSubset()
		{
			frmSubSet frmSubSet = new frmSubSet();
			frmSubSet.Text = "New SubSet " + m_SubSetList.Count.ToString();
			m_SubSetList.Add(frmSubSet);
			frmSubSet.Show(m_DockPanel);
			return (int)m_SubSetList[m_SubSetList.Count - 1].Handle;
		}


		public int LoadSubset(string file_name)
		{
			if (!string.IsNullOrEmpty(file_name))
			{
				foreach (frmSubSet frmSubSet in m_SubSetList)
				{
					if (frmSubSet.Name == file_name && frmSubSet.LoadSubSet(file_name))
					{
						frmSubSet.Show(m_DockPanel);
						return (int)frmSubSet.Handle;
					}
				}
				frmSubSet frmSubSet2 = new frmSubSet();
				if (frmSubSet2.LoadSubSet(file_name))
				{
					GuiCore.VerbosePrint(string.Format("RSTD.SubsetLoad(\"{0}\")\n", file_name.Replace('\\', '/')));
					m_SubSetList.Add(frmSubSet2);
					frmSubSet2.Show(m_DockPanel);
					return (int)frmSubSet2.Handle;
				}
				return 0;
			}
			return 0;
		}


		public void SaveSubset(int handle, string file_name)
		{
			frmSubSet frmSubSet = iGetSubsetByHandle(handle);
			if (frmSubSet != null)
			{
				if (Path.GetExtension(file_name).Equals(".csv"))
				{
					GuiCore.VerbosePrint(string.Format("RSTD.SubSetSave({0}, \"{1}\")\n", (int)frmSubSet.Handle, file_name.Replace('\\', '/')));
					frmSubSet.SaveAllSubset(file_name);
					return;
				}
				GuiCore.ErrorMessage("Failed to save subset. File format must be .csv");
			}
		}


		public void CloseSubset(int handle, bool b_save)
		{
			frmSubSet frmSubSet = iGetSubsetByHandle(handle);
			if (frmSubSet != null)
			{
				GuiCore.VerbosePrint(string.Format("RSTD.SubSetClose({0},{1})\n", (int)frmSubSet.Handle, b_save.ToString()));
				frmSubSet.Close();
				m_SubSetList.Remove(frmSubSet);
			}
			if (b_save)
			{
				frmSubSet.SaveAllSubSet();
			}
		}


		public void CloseSubset(frmSubSet st)
		{
			if (st.Dirty && RstdSettings.IsSubsetAskSaveOnClose())
			{
				st.Focus();
				string msg = string.Format("Save file {0}?", st.Text);
				if (6U == DoCoreMsgBox(3U, msg))
				{
					st.SaveAllSubSet();
				}
			}
			m_SubSetList.Remove(st);
		}


		public void ClearSubset(int handle)
		{
			frmSubSet frmSubSet = iGetSubsetByHandle(handle);
			if (frmSubSet != null)
			{
				GuiCore.VerbosePrint(string.Format("RSTD.SubSetClear({0})\n", (int)frmSubSet.Handle));
				frmSubSet.ClearSubSet();
			}
		}


		public void ReceiveSubset(int handle)
		{
			frmSubSet frmSubSet = iGetSubsetByHandle(handle);
			if (frmSubSet != null)
			{
				GuiCore.VerbosePrint(string.Format("RSTD.SubSetReceive({0})\n", (int)frmSubSet.Handle));
				frmSubSet.ReceiveSubSet(true);
			}
		}


		public void TransmitSubset(int handle)
		{
			frmSubSet frmSubSet = iGetSubsetByHandle(handle);
			if (frmSubSet != null)
			{
				GuiCore.VerbosePrint(string.Format("RSTD.SubSetTransmit({0})\n", (int)frmSubSet.Handle));
				frmSubSet.TransmitSubSet(true);
			}
		}


		public LuaTable GetSubset(int handle)
		{
			frmSubSet frmSubSet = iGetSubsetByHandle(handle);
			if (frmSubSet != null)
			{
				GuiCore.VerbosePrint(string.Format("RSTD.SubSetGet({0})\n", (int)frmSubSet.Handle));
				return frmSubSet.GetSubSet();
			}
			return null;
		}


		public void SubsetAdd(int handle, string reg_path)
		{
			frmSubSet frmSubSet = iGetSubsetByHandle(handle);
			if (frmSubSet != null)
			{
				XmlNode node;
				if (GuiCore.GetNodeFromPath(reg_path, out node))
				{
					GuiCore.VerbosePrint(string.Format("RSTD.SubsetAdd({0}, \"{1}\")\n", (int)frmSubSet.Handle, reg_path));
					frmSubSet.AddNodeToSubSet(node);
					return;
				}
				GuiCore.ErrorMessage(string.Format("Failed to add register to subset. Register path {0} not found", reg_path));
			}
		}


		public void SubsetRemove(int handle, string reg_path)
		{
			frmSubSet frmSubSet = iGetSubsetByHandle(handle);
			if (frmSubSet != null)
			{
				GuiCore.VerbosePrint(string.Format("RSTD.SubsetRemove({0}, \"{1}\")\n", (int)frmSubSet.Handle, reg_path));
				frmSubSet.RemoveFromSubSet(reg_path);
			}
		}


		private frmSubSet iGetSubsetByHandle(int handle)
		{
			foreach (frmSubSet frmSubSet in m_SubSetList)
			{
				if ((int)frmSubSet.Handle == handle)
				{
					return frmSubSet;
				}
			}
			GuiCore.ErrorMessage("Failed to find subset. Subset is not loaded");
			return null;
		}


		public void CleanSubsetList()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(CleanSubsetList);
				base.Invoke(method);
				return;
			}
			for (int i = 0; i < m_SubSetList.Count; i++)
			{
				m_SubSetList[i].Close();
				i--;
			}
			m_SubSetList.Clear();
		}


		private object[] iRunScript(string fileName, List<ScriptParam> script_params, LuaSourceType source_type, bool async, out bool aborted)
		{
			frmMain.LuaScriptRunner luaScriptRunner = new frmMain.LuaScriptRunner(fileName, this, script_params, source_type, new dPostLuaOpDel(iScriptCompleted), 0, true, false);
			m_LuaRunnerThread = new Thread(new ThreadStart(luaScriptRunner.RunScript));
			m_LuaRunnerThread.SetApartmentState(ApartmentState.MTA);
			m_LuaRunnerThread.IsBackground = true;
			m_LuaRunnerThread.Name = "ScriptThread";
			m_LuaRunnerThread.Start();
			if (!async)
			{
				m_LuaRunnerThread.Join();
			}
			aborted = luaScriptRunner.Aborted;
			return luaScriptRunner.Res;
		}


		private void iScriptCompleted(int op_id, object[] res)
		{
			if (base.InvokeRequired)
			{
				dPostLuaOpDel method = new dPostLuaOpDel(iScriptCompleted);
				base.Invoke(method, new object[]
				{
					op_id,
					res
				});
				return;
			}
			frmMain.bIsScriptRunning = false;
			m_ScriptRunStopBtn.Text = "Run!";
			m_ScriptRunStopBtn.Image = TreeIcons.green_light;
			m_ScriptRunStopBtn.Enabled = true;
			m_btnPause.Enabled = false;
			m_btnPause.Text = "Pause";
			m_btnDebug.Enabled = true;
			if (m_bScriptAborted)
			{
				MustPrint("\n*** Script aborted by user ***\n");
				if (m_bIsClientRunning)
				{
					m_LuaExportedOps.Abort();
				}
			}
			if (LuaDebuggerPresent && m_LuaDebuggerForm.IsDebuggerEnabled())
			{
				m_LuaDebuggerForm.StopDebuggingEnd(m_bScriptAborted);
			}
		}


		public void StopScript()
		{
			m_bScriptAborted = true;
			if ((m_LuaRunnerThread.ThreadState & System.Threading.ThreadState.Suspended) == System.Threading.ThreadState.Suspended)
			{
				m_LuaRunnerThread.Resume();
			}
			m_LuaRunnerThread.Abort();
			if (LuaDebuggerPresent && m_LuaDebuggerForm.IsDebuggerEnabled())
			{
				m_LuaDebuggerForm.StopDebuggingEnd(true);
				return;
			}
			LuaWrapperUtils.LuaWrapper.LuaVM.ResetStack();
		}


		public void PauseScript()
		{
			if (!m_LuaRunnerThread.IsAlive)
			{
				return;
			}
			if ((m_LuaRunnerThread.ThreadState & System.Threading.ThreadState.Suspended) != System.Threading.ThreadState.Suspended)
			{
				m_LuaRunnerThread.Suspend();
				m_btnPause.Text = "Resume";
			}
			else
			{
				m_LuaRunnerThread.Resume();
				m_btnPause.Text = "Pause";
			}
			if (LuaDebuggerPresent && m_LuaDebuggerForm.IsDebuggerEnabled())
			{
				m_LuaDebuggerForm.PauseEnd();
			}
		}


		public void PauseScriptInternal()
		{
			if (!m_LuaRunnerThread.IsAlive)
			{
				return;
			}
			if ((m_LuaRunnerThread.ThreadState & System.Threading.ThreadState.Suspended) != System.Threading.ThreadState.Suspended)
			{
				m_LuaRunnerThread.Suspend();
				m_bInternalSuspended = true;
				iSetStopPauseEnabledStatus(false);
				while ((m_LuaRunnerThread.ThreadState & System.Threading.ThreadState.Suspended) != System.Threading.ThreadState.Suspended)
				{
					Thread.Sleep(1);
				}
			}
		}


		private void iSetStopPauseEnabledStatus(bool enable)
		{
			if (base.InvokeRequired)
			{
				del_v_b method = new del_v_b(iSetStopPauseEnabledStatus);
				base.Invoke(method, new object[]
				{
					enable
				});
				return;
			}
			m_ScriptRunStopBtn.Enabled = enable;
			m_btnPause.Enabled = enable;
		}


		public void ResumeScriptInternal()
		{
			if (!m_LuaRunnerThread.IsAlive)
			{
				return;
			}
			if (m_bInternalSuspended && (m_LuaRunnerThread.ThreadState & System.Threading.ThreadState.Suspended) == System.Threading.ThreadState.Suspended)
			{
				m_LuaRunnerThread.Resume();
				m_bInternalSuspended = false;
				iSetStopPauseEnabledStatus(true);
			}
		}


		private void iStartScriptFromCombo()
		{
			if (bStartScript(m_ScriptNameComboBox.Text, null))
			{
				iAddScriptToGuiSettings(m_ScriptNameComboBox.Text);
			}
		}


		public void StartDebug(string script_path, bool full_run)
		{
			if (base.InvokeRequired)
			{
				del_v_s_b method = new del_v_s_b(StartDebug);
				base.Invoke(method, new object[]
				{
					script_path,
					full_run
				});
				return;
			}
			if (!string.IsNullOrEmpty(script_path) && File.Exists(script_path))
			{
				iOpenLuaDeubgger();
				ShowLuaDebugger();
				if (LuaDebuggerPresent && m_LuaDebuggerForm.DebugScript(script_path, full_run))
				{
					iAddScriptToGuiSettings(script_path);
					return;
				}
			}
			else
			{
				AlwaysPrint(string.Format("Error debugging script: Could not find script path \"{0}\"\n", script_path));
			}
		}


		public bool bStartScript(string full_path)
		{
			return bStartScript(full_path, null);
		}


		public bool bStartScript(string full_path, List<ScriptParam> script_params)
		{
			return bStartScript(full_path, script_params, LuaSourceType.File);
		}


		public bool bStartScript(string full_path, List<ScriptParam> script_params, LuaSourceType source_type)
		{
			object[] array = null;
			return bStartScript(full_path, script_params, source_type, true, out array);
		}


		public bool bStartScript(string full_path, List<ScriptParam> script_params, LuaSourceType source_type, bool async, out object[] res)
		{
			bool flag = false;
			res = null;
			if (full_path.Trim().Equals(""))
				return false;

			if (frmMain.bIsScriptRunning)
			{
				string arg;
				if (source_type == LuaSourceType.File)
				{
					arg = "\"" + full_path + "\"";
				}
				else if (source_type == LuaSourceType.Function)
				{
					arg = "Lua function";
				}
				else
				{
					arg = "Lua inline commands";
				}
				MustPrint(string.Format("Can't run {0} since another Lua operation is in process.\n", arg));
				return false;
			}
			if (source_type == LuaSourceType.File && !File.Exists(full_path))
			{
				GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, string.Format("Could not find script file {0}\n", full_path));
				return false;
			}
			iRunScriptBegin();
			res = iRunScript(full_path, script_params, source_type, async, out flag);
			return !flag;
		}


		public void ScriptRunStop()
		{
			if (!frmMain.bIsScriptRunning)
			{
				iStartScriptFromCombo();
				return;
			}
			StopScript();
		}


		private void iRunScriptBegin()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(iRunScriptBegin);
				base.Invoke(method);
				return;
			}
			frmMain.bIsScriptRunning = true;
			m_bScriptAborted = false;
			m_ScriptRunStopBtn.Text = "Stop!";
			m_ScriptRunStopBtn.Image = TreeIcons.red_light;
			m_btnPause.Enabled = true;
			m_btnPause.Text = "Pause";
			m_btnDebug.Enabled = false;
		}


		public bool AscertainModulesBuilt()
		{
			if (!GuiCore.IsClientBuilt)
			{
				GuiCore.RstdException("Modules must be built first!", "");
				return false;
			}
			return true;
		}


		public void MinimizeAllWindows()
		{
			if (base.InvokeRequired)
			{
				frmMain.GuiOperDel method = new frmMain.GuiOperDel(MinimizeAllWindows);
				base.Invoke(method);
				return;
			}
			base.WindowState = FormWindowState.Minimized;
		}


		private void iLoadGuiSettings()
		{
			iInitializeToolBarsVisibility();
			UpdateStandardToolbarButtonsSize();
			if (RstdGuiSettings.Default.OutputZoomFactor != 0f)
			{
				m_OutputForm.ConsoleText.ZoomFactor = RstdGuiSettings.Default.OutputZoomFactor;
			}
			if (RstdGuiSettings.Default.OutputFilterExclude != null)
			{
				m_OutputForm.TextExclude.Text = RstdGuiSettings.Default.OutputFilterExclude;
			}
			if (RstdGuiSettings.Default.OutputFilterInclude != null)
			{
				m_OutputForm.TextInclude.Text = RstdGuiSettings.Default.OutputFilterInclude;
			}
			m_OutputForm.ButtonUserMsgMask.Checked = RstdGuiSettings.Default.AllowOnlyUserMsgs;
			m_OutputForm.ButtonAutoScroll.Checked = RstdGuiSettings.Default.bAutoScrollOutput;
			if (RstdGuiSettings.Default.LastScriptsRun.Count > 0)
			{
				ComboBox.ObjectCollection items = m_ScriptNameComboBox.Items;
				object[] items2 = RstdGuiSettings.Default.LastScriptsRun.ToArray();
				items.AddRange(items2);
				m_ScriptNameComboBox.SelectedItem = m_ScriptNameComboBox.Items[0];
			}
			iRegisterDllsFromSettings();
		}


		private void iInitializeToolBarsVisibility()
		{
			m_ToolBar.Visible = false;
			toolStripContainer1.Visible = RstdGuiSettings.Default.CheckedToolBarsArr[1];
			m_BottomToolStrip.Visible = RstdGuiSettings.Default.CheckedToolBarsArr[2];
			m_StatusStrip.Visible = RstdGuiSettings.Default.CheckedToolBarsStatusBar;
		}


		private void iSaveGuiSettings()
		{
			RstdGuiSettings.Default.OutputZoomFactor = m_OutputForm.ConsoleText.ZoomFactor;
			RstdGuiSettings.Default.OutputFilterExclude = m_OutputForm.TextExclude.Text;
			RstdGuiSettings.Default.OutputFilterInclude = m_OutputForm.TextInclude.Text;
			for (int i = 0; i < toolStripContainer1.TopToolStripPanel.Rows.Length; i++)
			{
				for (int j = 0; j < toolStripContainer1.TopToolStripPanel.Rows[i].Controls.Length; j++)
				{
					UserToolStripInfo userToolStripInfo = (UserToolStripInfo)toolStripContainer1.TopToolStripPanel.Rows[i].Controls[j].Tag;
					userToolStripInfo.RowIndex = i;
					userToolStripInfo.ColIndex = j;
				}
			}
			RstdGuiSettings.Default.Save();
		}


		private void iAddScriptToGuiSettings(string scriptName)
		{
			List<string> lastScriptsRun = RstdGuiSettings.Default.LastScriptsRun;
			if (!lastScriptsRun.Contains(scriptName))
			{
				if (lastScriptsRun.Count >= 5)
				{
					lastScriptsRun.Remove(lastScriptsRun[lastScriptsRun.Count - 1]);
				}
				lastScriptsRun.Insert(0, scriptName);
			}
			else
			{
				lastScriptsRun.Remove(scriptName);
				lastScriptsRun.Insert(0, scriptName);
			}
			m_ScriptNameComboBox.Items.Clear();
			ComboBox.ObjectCollection items = m_ScriptNameComboBox.Items;
			object[] items2 = lastScriptsRun.ToArray();
			items.AddRange(items2);
			m_ScriptNameComboBox.Text = scriptName;
			RstdGuiSettings.Default.Save();
		}


		private void CheckImportedProcedures()
		{
			ArrayList arrayList = CoreImportsCheck.CheckImportedProcs();
			if (arrayList.Count != 0)
			{
				string text = "Could not import the following procedures:\n";
				foreach (object obj in arrayList)
				{
					string str = (string)obj;
					text = text + str + "\n";
				}
				text += "\nProgram will now exit.";
				GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_INFORMATION, "Loading rttt_core.dll procedures: \n" + text);
				m_bAllProcsImported = false;
				return;
			}
			m_bAllProcsImported = true;
		}


		private void iUserGo()
		{
			if (GuiCore.IsClientBuilt && !m_bIsClientRunning)
			{
				if (m_RstdSettings.GetMonitorOneClickStart() && !m_BrowseTree.MonitoredVars.bIsMonitoring && m_BrowseTree.MonitoredVars.MonitoredVarsList != null && m_BrowseTree.MonitoredVars.MonitoredVarsList.Count > 0)
				{
					m_BrowseTree.MonitoredVars.MonitorStart();
				}
				VerbosePrint("RSTD.Go()\n");
				m_LuaExportedOps.Go();
			}
		}


		private void iUserStop()
		{
			VerbosePrint("GUI: RSTD.Stop()\n");
			m_LuaExportedOps.Stop();
			if (m_RstdSettings.GetMonitorOneClickStart() && m_BrowseTree.MonitoredVars.bIsMonitoring)
			{
				m_BrowseTree.MonitoredVars.MonitorStop();
			}
		}


		private void iUserAbort()
		{
			m_LuaExportedOps.Abort();
		}


		private void iUserBuild()
		{
			m_LuaExportedOps.Build();
		}


		private void iUserUnBuild()
		{
			m_LuaExportedOps.UnBuild();
		}


		private void iSplitFilter(ToolStripTextBox txtBox, ref string[] mask)
		{
			if (string.Empty == txtBox.Text)
			{
				mask = null;
				return;
			}
			mask = txtBox.Text.Split(new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries);
		}


		private void iListenToStdOutput()
		{
			SafeFileHandle safeFileHandle = null;
			SafeFileHandle safeFileHandle2 = null;
			m_PipeListen = true;
			m_StdoutPipe = new NamedPipe(ref safeFileHandle, ref safeFileHandle2);
			m_StdoutPipe.SetClientHandleToStdIo(-11);
			m_StdoutPipe.SetClientHandleToStdIo(-12);
			m_PipeReadThread = new Thread(new ThreadStart(iPipeListener));
			m_PipeReadThread.IsBackground = true;
			m_PipeReadThread.Start();
		}


		private void iPipeListener()
		{
			while (m_PipeListen)
			{
				string text = m_StdoutPipe.Read();
				if (!text.Contains("STOP_STDOUT_READ_BLOCKING"))
				{
					AlwaysPrint(text);
				}
				Thread.Sleep(5);
			}
			StopPipeListener();
		}


		private void iShowQuickHelp()
		{
			Form form = GuiCore.GetOpenedForm("frmQuickHelp");
			if (form != null)
			{
				((frmQuickHelp)form).Show(m_DockPanel);
				return;
			}
			form = new frmQuickHelp();
			form.ShowDialog();
		}


		private string iGetSettingsOutputPath()
		{
			string text = "";
			if (!string.IsNullOrEmpty(Program.ConfigPath))
			{
				text = Program.ConfigPath;
			}
			else
			{
				text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				if (!string.IsNullOrEmpty(text))
				{
					text += "\\RSTD";
				}
				else
				{
					text = Application.StartupPath;
				}
			}
			try
			{
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
			}
			catch (Exception ex)
			{
				GuiCore.ErrorMessage(string.Format("Failed to create directory for RT3 settings: \"{0}\".\nGot error: {1} ", text, ex.Message));
			}
			return text;
		}


		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 74)
			{
				CoreImports.CopyDataStruct copyDataStruct = (CoreImports.CopyDataStruct)m.GetLParam(typeof(CoreImports.CopyDataStruct));
				if (copyDataStruct.ID == 1054)
				{
					iRunInjectedScript(copyDataStruct.Data);
				}
				if (copyDataStruct.ID == 1084)
				{
					AlwaysPrint("WatchDog exit signal received...\n");
					AlwaysPrint("Stopping current script ...\n");
					StopScript();
					AlwaysPrint("Exiting RSTD...\n");
					Application.Exit();
				}
			}
			base.WndProc(ref m);
		}


		private void iRunInjectedScript(string script_with_params)
		{
			List<ScriptParam> list = new List<ScriptParam>();
			string[] array = script_with_params.Split(new string[]
			{
				"@@"
			}, StringSplitOptions.RemoveEmptyEntries);
			string full_path = array[0];
			if (array.Length > 1)
			{
				foreach (string text in array[1].Split(new char[]
				{
					','
				}))
				{
					ScriptParam scriptParam = new ScriptParam();
					scriptParam.Value = text.Trim();
					double num;
					bool flag;
					if (double.TryParse(text, out num))
					{
						scriptParam.Type = ScriptParamType.Number;
					}
					else if (bool.TryParse(text, out flag))
					{
						scriptParam.Type = ScriptParamType.Bool;
					}
					else
					{
						scriptParam.Type = ScriptParamType.String;
					}
					list.Add(scriptParam);
				}
			}
			bStartScript(full_path, list);
		}


		private void menuItemFile_DropDownOpening(object sender, EventArgs e)
		{
			if (m_DockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				menuItemCloseAllButThisOne.Enabled = (menuItemClose.Enabled = (menuItemCloseAll.Enabled = (base.ActiveMdiChild != null)));
				return;
			}
			menuItemCloseAllButThisOne.Enabled = (menuItemClose.Enabled = (m_DockPanel.ActiveContent != null));
			menuItemCloseAll.Enabled = !ibAreAllContentsClosed();
		}


		private void menuItemLoadLayout_Click(object sender, EventArgs e)
		{
			string text = GuiCore.OpenFileDialog(null, FileType.XML);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			iLoadLayout(text);
		}


		private void menuItemSaveLayout_Click(object sender, EventArgs e)
		{
			string text = GuiCore.SaveDialogTxtOrXml(null, 1);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			iSaveLayout(text);
		}


		private void menuItemClose_Click(object sender, EventArgs e)
		{
			if (m_DockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				base.ActiveMdiChild.Close();
				return;
			}
			if (m_DockPanel.ActiveContent != null)
			{
				CloseContent(m_DockPanel.ActiveContent);
			}
		}


		private void menuItemCloseAll_Click(object sender, EventArgs e)
		{
			iCloseAllContents();
		}


		private void menuItemCloseAllButThisOne_Click(object sender, EventArgs e)
		{
			if (m_DockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				Form activeMdiChild = base.ActiveMdiChild;
				foreach (Form form in base.MdiChildren)
				{
					if (form != activeMdiChild)
					{
						form.Close();
					}
				}
				return;
			}
			DockContentCollection contents = m_DockPanel.Contents;
			for (int j = contents.Count - 1; j >= 0; j--)
			{
				if (!contents[j].DockHandler.IsActivated)
				{
					CloseContent(contents[j]);
				}
			}
		}


		public IDockContent whichDockContentIsInFocus()
		{
			return m_DockPanel.ActiveContent;
		}


		private void menuItemExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}


		private void exitWithoutSavingLayout_Click(object sender, EventArgs e)
		{
			m_bSaveLayout = false;
			base.Close();
			m_bSaveLayout = true;
		}


		private void menuItemOutput_Click(object sender, EventArgs e)
		{
			m_OutputForm.Show(m_DockPanel);
		}


		private void menuItemBrowseTree_Click(object sender, EventArgs e)
		{
			m_BrowseTree.Show(m_DockPanel);
		}


		private void menuItemWorkSet_Click(object sender, EventArgs e)
		{
			m_BrowseTree.WorkSet.Show(m_DockPanel);
		}


		private void menuItemMonitors_Click(object sender, EventArgs e)
		{
			m_BrowseTree.MonitoredVars.Show(m_DockPanel);
		}


		private void menuItemView_DropDownOpening(object sender, EventArgs e)
		{
			menuItemStandardToolBar.Checked = RstdGuiSettings.Default.CheckedToolBarsArr[0];
			menuItemUserButtonsToolBar.Checked = RstdGuiSettings.Default.CheckedToolBarsArr[1];
			menuItemScriptToolBar.Checked = RstdGuiSettings.Default.CheckedToolBarsArr[2];
			menuItemStatusBar.Checked = RstdGuiSettings.Default.CheckedToolBarsStatusBar;
		}


		private void menuItemStandardToolBar_Click(object sender, EventArgs e)
		{
			m_ToolBar.Visible = (menuItemStandardToolBar.Checked = !menuItemStandardToolBar.Checked);
			RstdGuiSettings.Default.CheckedToolBarsArr[0] = !RstdGuiSettings.Default.CheckedToolBarsArr[0];
		}


		private void menuItemUserButtonsToolBar_Click(object sender, EventArgs e)
		{
			toolStripContainer1.Visible = (menuItemUserButtonsToolBar.Checked = !menuItemUserButtonsToolBar.Checked);
			RstdGuiSettings.Default.CheckedToolBarsArr[1] = !RstdGuiSettings.Default.CheckedToolBarsArr[1];
		}


		private void menuItemScriptToolBar_Click(object sender, EventArgs e)
		{
			m_BottomToolStrip.Visible = (menuItemScriptToolBar.Checked = !menuItemScriptToolBar.Checked);
			RstdGuiSettings.Default.CheckedToolBarsArr[2] = !RstdGuiSettings.Default.CheckedToolBarsArr[2];
		}


		private void menuItemStatusBar_Click(object sender, EventArgs e)
		{
			m_StatusStrip.Visible = (menuItemStatusBar.Checked = !menuItemStatusBar.Checked);
			RstdGuiSettings.Default.CheckedToolBarsStatusBar = !RstdGuiSettings.Default.CheckedToolBarsStatusBar;
		}


		private void menuItemOperations_DropDownOpening(object sender, EventArgs e)
		{
			menuItemGo.Enabled = (GuiCore.IsClientBuilt && !m_bIsClientRunning);
			menuItemStop.Enabled = (GuiCore.IsClientBuilt && m_bIsClientRunning);
			menuItemBuild.Enabled = !GuiCore.IsClientBuilt;
			menuItemUnBuild.Enabled = (GuiCore.IsClientBuilt && !m_bIsClientRunning);
			menuItemALBuild.Enabled = !GuiCore.IsAlBuilt;
			menuItemALInit.Enabled = (GuiCore.IsAlBuilt && !GuiCore.IsClientBuilt);
			menuItemALReset.Enabled = (GuiCore.IsAlBuilt && !GuiCore.IsClientBuilt);
			menuItemALUnbuild.Enabled = GuiCore.IsAlBuilt;
			menuItemClientBuild.Enabled = (GuiCore.IsAlBuilt && !GuiCore.IsClientBuilt);
			menuItemClientInit.Enabled = GuiCore.IsClientBuilt;
			menuItemClientReset.Enabled = GuiCore.IsClientBuilt;
			menuItemClientUnbuild.Enabled = GuiCore.IsClientBuilt;
			menuItemALBuild.Checked = GuiCore.bHasBuildStatus(EBuildStatus.AL_Built);
			menuItemALInit.Checked = GuiCore.bHasBuildStatus(EBuildStatus.AL_Init);
			menuItemALReset.Checked = GuiCore.bHasBuildStatus(EBuildStatus.AL_Reset);
			menuItemClientBuild.Checked = GuiCore.bHasBuildStatus(EBuildStatus.Client_Built);
			menuItemClientInit.Checked = GuiCore.bHasBuildStatus(EBuildStatus.Client_Init);
			menuItemClientReset.Checked = GuiCore.bHasBuildStatus(EBuildStatus.Client_Reset);
		}


		private void menuItemBuild_Click(object sender, EventArgs e)
		{
			iUserBuild();
		}


		private void menuItemUnBuild_Click(object sender, EventArgs e)
		{
			iUserUnBuild();
		}


		private void menuItemGo_Click(object sender, EventArgs e)
		{
			iUserGo();
		}


		private void menuItemStop_Click(object sender, EventArgs e)
		{
			iUserStop();
		}


		private void menuItemALBuild_Click(object sender, EventArgs e)
		{
			GuiCore.AL_Build(true);
		}


		private void menuItemALInit_Click(object sender, EventArgs e)
		{
			GuiCore.AL_Init();
		}


		private void menuItemALReset_Click(object sender, EventArgs e)
		{
			GuiCore.AL_Reset();
		}


		private void menuItemClientBuild_Click(object sender, EventArgs e)
		{
			GuiCore.Clients_Build(true);
		}


		private void menuItemClientInit_Click(object sender, EventArgs e)
		{
			GuiCore.Clients_Init();
		}


		private void menuItemClientReset_Click(object sender, EventArgs e)
		{
			GuiCore.Clients_Reset();
		}


		private void menuItemClientUnbuild_Click(object sender, EventArgs e)
		{
			GuiCore.Clients_UnBuild(true);
		}


		private void menuItemALUnbuild_Click(object sender, EventArgs e)
		{
			GuiCore.AL_UnBuild(true);
		}


		private void menuItemTools_DropDownOpening(object sender, EventArgs e)
		{
			menuItemLockLayout.Checked = !m_DockPanel.AllowEndUserDocking;
		}


		private void menuItemLockLayout_Click(object sender, EventArgs e)
		{
			m_DockPanel.AllowEndUserDocking = !m_DockPanel.AllowEndUserDocking;
		}


		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			IDockContent idc = whichDockContentIsInFocus();
			m_frmGuiGettings.UpdateForm(idc);
			m_frmGuiGettings.ShowDialog();
		}


		private void registerDllsToLuaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form form = new frmLuaRegister();
			List<LuaRegisterInfo> list = new List<LuaRegisterInfo>();
			list.AddRange(RstdGuiSettings.Default.LuaRegisterInfos);
			if (form.ShowDialog() == DialogResult.OK)
			{
				iUnregisterRemovedDlls(list);
				iRegisterDllsFromSettings();
			}
		}


		private void iUnregisterRemovedDlls(List<LuaRegisterInfo> old_reg_infos)
		{
			for (int i = 0; i < old_reg_infos.Count; i++)
			{
				bool flag = false;
				using (List<LuaRegisterInfo>.Enumerator enumerator = RstdGuiSettings.Default.LuaRegisterInfos.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Package == old_reg_infos[i].Package)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					UnregisterLuaDll(old_reg_infos[i]);
				}
			}
			foreach (LuaRegisterInfo luaRegisterInfo in RstdGuiSettings.Default.LuaRegisterInfos)
			{
				if (!luaRegisterInfo.Use)
				{
					UnregisterLuaDll(luaRegisterInfo);
				}
			}
		}


		private void iUnregisterLuaDlls()
		{
			foreach (LuaRegisterInfo luaRegisterInfo in RstdGuiSettings.Default.LuaRegisterInfos)
			{
				if (luaRegisterInfo.Use)
				{
					UnregisterLuaDll(luaRegisterInfo);
				}
			}
		}


		private void iRegisterDllsFromSettings()
		{
			foreach (LuaRegisterInfo luaRegisterInfo in RstdGuiSettings.Default.LuaRegisterInfos)
			{
				if (luaRegisterInfo.Use && !luaRegisterInfo.IsRegistered && !string.IsNullOrEmpty(luaRegisterInfo.DllPath))
				{
					RegisterDllToLua(luaRegisterInfo);
				}
			}
			for (int i = 0; i < RstdGuiSettings.Default.LuaRegisterInfos.Count; i++)
			{
				LuaRegisterInfo luaRegisterInfo2 = RstdGuiSettings.Default.LuaRegisterInfos[i];
				if (luaRegisterInfo2.ToBeRemoved)
				{
					RstdGuiSettings.Default.LuaRegisterInfos.Remove(luaRegisterInfo2);
					i--;
				}
			}
		}


		private void helpF1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}


		private void luaWebPageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.lua.org/docs.html");
		}


		private void menuItemAbout_Click(object sender, EventArgs e)
		{
			new frmAbout().ShowDialog();
		}


		private void RadarICDLink_Click(object sender, EventArgs e)
		{
			Process.Start(".\\AR1xx_Radar_Interface_Control_Document.pdf");
		}


		private void iCloseAllContents()
		{
			DockContentCollection contents = m_DockPanel.Contents;
			for (int i = contents.Count - 1; i >= 0; i--)
			{
				CloseContent(contents[i]);
			}
		}


		public void CloseContent(IDockContent content)
		{
			if (content.DockHandler.HideOnClose)
			{
				content.DockHandler.Hide();
				return;
			}
			content.DockHandler.Close();
		}


		private bool ibAreAllContentsClosed()
		{
			DockContentCollection contents = m_DockPanel.Contents;
			for (int i = 0; i < contents.Count; i++)
			{
				if (!contents[i].DockHandler.IsHidden)
				{
					return false;
				}
			}
			return true;
		}


		private void iCloseAllDocuments()
		{
			if (m_DockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				Form[] mdiChildren = base.MdiChildren;
				for (int i = 0; i < mdiChildren.Length; i++)
				{
					mdiChildren[i].Close();
				}
				return;
			}
			IDockContent[] array = m_DockPanel.DocumentsToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].DockHandler.Close();
			}
		}


		private IDockContent iGetContentFromPersistString(string persistString)
		{
			if (persistString == typeof(frmOutput).ToString())
				return m_OutputForm;
			if (persistString == typeof(BrowseTree).ToString())
				return m_BrowseTree;
			if (persistString == typeof(MonitoredVars).ToString())
				return m_BrowseTree.MonitoredVars;
			if (persistString == typeof(frmWorkSet).ToString())
				return m_BrowseTree.WorkSet;
			if (persistString == typeof(frmLuaShell).ToString())
				return m_LuaShellForm;
			if (persistString == typeof(frmFind).ToString())
			{
				GuiCore.OpenFindForm("/");
				return (frmFind)GuiCore.GetOpenedForm("frmFind");
			}
			if (persistString == typeof(frmRecord).ToString())
				return m_RecordForm;
			return null;
		}

		private void iLoadLayout()
		{
			string DockConfig = Path.Combine(m_SettingsOutputPath, "DockConfig.xml");
			string DockCustDefault = Path.Combine(Application.StartupPath, "DockCustDefault.xml");
			if (File.Exists(DockConfig))
				iLoadLayout(DockConfig);
			else if (File.Exists(DockCustDefault))
                iLoadLayout(DockCustDefault);

			if (m_BrowseTree.Visible)
				m_BrowseTree.Hide();

			if (m_BrowseTree.MonitoredVars.Visible)
				m_BrowseTree.MonitoredVars.Hide();

			if (m_BrowseTree.WorkSet.Visible)
				m_BrowseTree.WorkSet.Hide();

			RadarICDLink.Visible = false;
			RadarICDLink.Visible = false;
		}


		private void iLoadLayout(string file_name)
		{
			m_bLoadingLayout = true;
			m_DockPanel.SuspendLayout(true);
			iCloseAllContents();
			if (File.Exists(file_name))
			{
				m_DockPanel.LoadFromXml(file_name, m_deserializeDockContent);
			}
			m_DockPanel.ResumeLayout(true, true);
			m_bLoadingLayout = false;
		}


		private void iSaveLayout()
		{
			string file_name = Path.Combine(m_SettingsOutputPath, "DockConfig.xml");
			iSaveLayout(file_name);
		}


		private void iSaveLayout(string file_name)
		{
			if (bIsRstdClosing)
			{
				iCloseForms("frmFind");
				iCloseForms("frmQuickHelp");
			}
			if (m_bSaveLayout)
			{
				m_DockPanel.SaveAsXml(file_name);
				return;
			}
			if (File.Exists(file_name))
			{
				File.Delete(file_name);
			}
		}


		private void iCloseForms(string form_name)
		{
			Form openedForm;
			do
			{
				openedForm = GuiCore.GetOpenedForm(form_name);
				if (openedForm != null)
				{
					openedForm.Close();
				}
			}
			while (openedForm != null);
		}


		public void MenuItemLuaShell_Click(object sender, EventArgs e)
		{
			m_LuaShellForm.Show(m_DockPanel);
		}


		private void openToolBarsFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(m_SettingsOutputPath + "\\ToolBars"))
			{
				Directory.CreateDirectory(m_SettingsOutputPath + "\\ToolBars");
			}
			Process.Start(m_SettingsOutputPath + "\\ToolBars");
		}


		private void m_btnMacroForm_Click(object sender, EventArgs e)
		{
			m_RecordForm.Show(m_DockPanel);
		}


		private void menuItemSubSet_DropDownOpened(object sender, EventArgs e)
		{
			m_SubsetLoad.Enabled = GuiCore.IsClientBuilt;
			m_SubsetNew.Enabled = GuiCore.IsClientBuilt;
		}


		private void toolStripStatusLabel3_Click(object sender, EventArgs e)
		{
		}


		private const int m_MaxLastScripts = 5;


		private const int STD_OUTPUT_HANDLE = -11;


		private const int STD_ERROR_HANDLE = -12;


		private const string STOP_BLOCKING_STRING = "STOP_STDOUT_READ_BLOCKING";


		private RstdSettings m_RstdSettings;


		private BrowseTree m_BrowseTree;


		private frmOutput m_OutputForm;


		private frmLuaShell m_LuaShellForm;


		private frmRecord m_RecordForm;


		private LuaExportedOperations m_LuaExportedOps;


		private string m_LastLogFileName;


		private int m_LogFilesToLeave;


		private int m_MaxLogFiles;


		private bool m_bWarnBeforeLogsDeletion = true;


		private StreamWriter m_LogStreamWriter;


		private StreamWriter m_LogVerboseStreamWriter;


		private StreamWriter m_LogUserStreamWriter;


		private string m_LuaHistoryCommandFile;


		private bool m_bIsBuilding;


		private bool m_bIsUnBuilding;


		private bool m_bIsClientRunning;


		private bool m_bIsStopPending;


		private bool m_bIsRstdClosing;


		private bool m_bLoadingLayout;


		private bool m_bAllProcsImported;


		public static bool bIsScriptRunning;


		private bool m_bScriptAborted;


		private ArrayList m_ReggaeProcess;


		private NamedPipe m_StdoutPipe;


		private Thread m_PipeReadThread;


		private bool m_PipeListen;


		private ToolStripButton m_UserButtonClicked;


		private readonly int m_MAX_NUM_COMMANDS_IN_FILE;


		private Thread m_LuaRunnerThread;


		private bool m_bInternalSuspended;


		private WatchDogManager m_WatchDogManager;


		private frmLuaDebugger m_LuaDebuggerForm;


		private bool m_bSaveLayout = true;


		private DeserializeDockContent m_deserializeDockContent;


		private frmGuiSettings m_frmGuiGettings;


		private List<RstdGuiModuleBase> m_GuiDllForms;


		private TcpChannel m_ReggaeChannel;


		private Splash m_SplashScreen;


		private bool m_bIsLineStart = true;


		private string m_SettingsOutputPath;


		private List<RstdServer> m_Servers;


		private int m_ClickedToolStripIndex;


		private Color m_UserButtonBackColor;


		private int m_LastDropIndex = -1;


		private string m_DllRegProbePaths = "";


		private List<frmSubSet> m_SubSetList;


		public static GUI_REGISTER_UPDATED_MODE gGui_updated_mode;



		private delegate void GuiOperDel();



		private delegate void GuiOperDel_1String(string varFullPath);



		private delegate void GuiOperDel_2String(string var1, string var2);



		private delegate void GuiOperDel_5String(string var1, string var2, string var3, string var4, string var5);



		private delegate void GuiOperDel_GuiMessage(string var1, bool var2);



		private delegate string GuiOperDelRetStr();



		private delegate void GuiOperDelv_v_s_s(string p1, string p2);



		private delegate void GuiOperDelv_v_s_s_s(string p1, string p2, string p3);



		private delegate void dGuiOperDel_UpdateConState(RstdServer server, ServerState state);


		public class LuaScriptRunner
		{



			public bool Aborted
			{
				get
				{
					return m_bAborted;
				}
				set
				{
					m_bAborted = value;
				}
			}




			public object[] Res
			{
				get
				{
					return m_Res;
				}
				set
				{
					m_Res = value;
				}
			}


			public LuaScriptRunner(string source, frmMain main_form, List<ScriptParam> script_params, LuaSourceType source_type, dPostLuaOpDel post_func, int op_id, bool safe, bool allow_pausing)
			{
				m_Source = source;
				m_Mainform = main_form;
				m_ScriptParams = script_params;
				m_SourceType = source_type;
				m_Res = null;
				m_PostFunc = post_func;
				m_OpId = op_id;
				m_bSafe = safe;
				m_bAllowPausing = allow_pausing;
			}


			public void RunScript()
			{
				if (m_SourceType == LuaSourceType.LuaString && m_bSafe)
				{
					if (!Monitor.TryEnter(LuaWrapperUtils.LuaWrapper.LuaVM, 1000))
					{
						m_Mainform.ErrorPrint(string.Format("Lua operation \"{0}\" timed out since another operation is already in progress\n", m_Source));
						try
						{
							if (m_PostFunc != null)
							{
								m_PostFunc.DynamicInvoke(new object[]
								{
									m_OpId,
									m_Res
								});
							}
						}
						catch (Exception ex)
						{
							m_Mainform.ErrorPrint(ex.ToString());
						}
						return;
					}
					frmMain.LuaScriptRunner.bDoStringInProgress = true;
				}
				if (1 == CoreImports.IsDebuggerPresent())
				{
					try
					{
						if (m_bSafe && m_SourceType == LuaSourceType.LuaString && frmMain.bIsScriptRunning && m_bAllowPausing)
						{
							m_Mainform.PauseScriptInternal();
							m_bScriptSuspended = true;
						}
						if (m_SourceType != LuaSourceType.LuaString && frmMain.LuaScriptRunner.bDoStringInProgress)
						{
							m_Mainform.ErrorPrint(string.Format("Lua operation \"{0}\" aborted since another operation is already in progress\n", m_Source));
							m_bAborted = true;
							return;
						}
						iInnerRunScript();
						return;
					}
					catch (LuaException ex2)
					{
						iPrintScriptException(ex2);
						if (m_Mainform.WatchDogManager.IsOnGuard)
						{
							m_Mainform.WatchDogManager.Suspend(RstdConstants.WATCHDOG_LEVEL.LUA_ERRORS);
						}
						return;
					}
					finally
					{
						if (m_SourceType == LuaSourceType.LuaString)
						{
							if (m_bScriptSuspended)
							{
								m_Mainform.ResumeScriptInternal();
							}
							if (m_bSafe)
							{
								Monitor.Exit(LuaWrapperUtils.LuaWrapper.LuaVM);
								frmMain.LuaScriptRunner.bDoStringInProgress = false;
							}
						}
						try
						{
							if (m_PostFunc != null)
							{
								m_PostFunc.DynamicInvoke(new object[]
								{
									m_OpId,
									m_Res
								});
							}
						}
						catch (Exception ex3)
						{
							m_Mainform.ErrorPrint(ex3.ToString());
						}
					}
				}
				try
				{
					if (m_bSafe && m_SourceType == LuaSourceType.LuaString && frmMain.bIsScriptRunning && m_bAllowPausing)
					{
						m_Mainform.PauseScriptInternal();
						m_bScriptSuspended = true;
					}
					if (m_SourceType != LuaSourceType.LuaString && frmMain.LuaScriptRunner.bDoStringInProgress)
					{
						m_Mainform.ErrorPrint(string.Format("Lua operation \"{0}\" aborted since another operation is already in progress\n", m_Source));
						m_bAborted = true;
					}
					else
					{
						iInnerRunScript();
					}
				}
				catch (ThreadAbortException)
				{
					m_bAborted = true;
				}
				catch (Exception ex4)
				{
					iPrintScriptException(ex4);
					if (m_Mainform.WatchDogManager.IsOnGuard)
					{
						m_Mainform.WatchDogManager.Suspend(RstdConstants.WATCHDOG_LEVEL.LUA_ERRORS);
					}
				}
				finally
				{
					if (m_SourceType == LuaSourceType.LuaString)
					{
						if (m_bScriptSuspended)
						{
							m_Mainform.ResumeScriptInternal();
						}
						if (m_bSafe)
						{
							Monitor.Exit(LuaWrapperUtils.LuaWrapper.LuaVM);
							frmMain.LuaScriptRunner.bDoStringInProgress = false;
						}
					}
					try
					{
						if (m_PostFunc != null)
						{
							m_PostFunc.DynamicInvoke(new object[]
							{
								m_OpId,
								m_Res
							});
						}
					}
					catch (Exception ex5)
					{
						m_Mainform.ErrorPrint(ex5.ToString());
					}
				}
			}


			private void iInnerRunScript()
			{
				if (m_SourceType == LuaSourceType.File)
				{
					if (m_ScriptParams == null || (m_ScriptParams != null && m_ScriptParams.Count == 0))
					{
						m_Res = LuaWrapperUtils.LuaWrapper.DoFile(m_Source);
					}
					else
					{
						List<object> list = new List<object>();
						LuaFunction luaFunction = LuaWrapperUtils.LuaWrapper.LoadFile(m_Source);
						foreach (ScriptParam scriptParam in m_ScriptParams)
						{
							switch (scriptParam.Type)
							{
							case ScriptParamType.String:
								list.Add(scriptParam.Value);
								break;
							case ScriptParamType.Number:
							{
								double num = double.Parse(scriptParam.Value);
								list.Add(num);
								break;
							}
							case ScriptParamType.Bool:
							{
								bool flag = bool.Parse(scriptParam.Value);
								list.Add(flag);
								break;
							}
							}
						}
						m_Res = luaFunction.Call(list.ToArray());
					}
				}
				else if (m_SourceType == LuaSourceType.LuaString)
				{
					m_Res = LuaWrapperUtils.LuaWrapper.LuaVM.DoString(m_Source);
				}
				else
				{
					string text = "";
					if (m_ScriptParams == null || (m_ScriptParams != null && m_ScriptParams.Count == 0))
					{
						string chunk = m_Source + "()";
						m_Res = LuaWrapperUtils.LuaWrapper.LuaVM.DoString(chunk);
					}
					else
					{
						foreach (ScriptParam scriptParam2 in m_ScriptParams)
						{
							text = text + scriptParam2.Value + ",";
						}
						text = text.Trim(new char[]
						{
							','
						});
						string chunk = string.Format("{0}({1})", m_Source, text);
						m_Res = LuaWrapperUtils.LuaWrapper.LuaVM.DoString(chunk);
					}
				}
				if (m_SourceType != LuaSourceType.LuaString)
				{
					m_Mainform.MustPrint("\n***Script completed successfully.***\n");
				}
			}


			private void iPrintScriptException(Exception ex)
			{
				if (!ex.Message.Equals("User Interrupt"))
				{
					string text;
					if (m_SourceType != LuaSourceType.LuaString)
					{
						text = "\n&&&&&&&&&&&&&&&&&&&&\n***Script FAILED!***\n&&&&&&&&&&&&&&&&&&&&\nException message is:\n" + ex.Message + "\n";
					}
					else
					{
						text = "\nLua Error:\n" + ex.Message + "\n";
					}
					if (m_Mainform.LuaDebuggerPresent && m_Mainform.LuaDebugger.GotoLuaException(ex.Message))
					{
						m_Mainform.ShowLuaDebugger();
					}
					m_Mainform.ErrorPrint(text);
				}
			}


			private string m_Source;


			private frmMain m_Mainform;


			private List<ScriptParam> m_ScriptParams;


			private LuaSourceType m_SourceType;


			private object[] m_Res;


			private dPostLuaOpDel m_PostFunc;


			private int m_OpId;


			private bool m_bScriptSuspended;


			private bool m_bAborted;


			private bool m_bSafe;


			private bool m_bAllowPausing;


			private static bool bDoStringInProgress;
		}
	}
}
