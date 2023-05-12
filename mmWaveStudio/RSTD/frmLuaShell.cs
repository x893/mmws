using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using RSTD.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace RSTD
{

	public partial class frmLuaShell : DockContent
	{



		internal ShellTextBox ShellTextBox
		{
			get
			{
				return this.m_ShellTextBox;
			}
			set
			{
				this.m_ShellTextBox = value;
			}
		}




		public frmMain MainForm
		{
			get
			{
				return this.m_MainForm;
			}
			set
			{
				this.m_MainForm = value;
			}
		}




		public int NumCommandEntered
		{
			get
			{
				return this.m_numCommandEntered;
			}
			set
			{
				this.m_numCommandEntered = value;
			}
		}




		public bool bInBlock
		{
			get
			{
				return this.m_bInBlock;
			}
			set
			{
				this.m_bInBlock = value;
			}
		}




		public bool IsCommandRunning
		{
			get
			{
				return this.m_IsCommandRunning;
			}
			set
			{
				this.m_IsCommandRunning = value;
			}
		}


		public frmLuaShell(frmMain main_form)
		{
			this.m_numCommandEntered = 0;
			this.m_bInBlock = false;
			this.m_bWasCLS_command = false;
			this.m_StrBuffer = "";
			this.m_HoldRealPrompt = "";
			this.m_LuaShellTextFromStart = new StringBuilder("");
			this.m_ShellTextBox = new ShellTextBox();
			base.Controls.Add(this.m_ShellTextBox);
			this.InitializeComponent();
			this.m_MainForm = main_form;
			base.HideOnClose = true;
			this.PrimerHelpMenu();
			this.m_ShellTextBox.printPrompt();
			this.iRegisterShellPrintFunctionToLua();
			this.iLoadLuaHistory();
			this.RstdGuiSettingsToLuaShellLayout();
			this.m_ShellTextBox.CommandEntered += this.hLuaShellCommandEntered;
		}


		private void hLuaShellCommandEntered(object sender, CommandEnteredEventArgs e)
		{
			this.iHandleGuiBeforeAfterCommand(true);
			new dCommandEntered(this.iHandleCommandEntered).BeginInvoke(sender, e, new AsyncCallback(this.iCommandHandlingCompleted), null);
		}


		private void iCommandHandlingCompleted(IAsyncResult res)
		{
			this.iHandleCommandExceptions(res);
			this.m_ShellTextBox.printPrompt();
			this.iHandleGuiBeforeAfterCommand(false);
		}


		public bool IsLuaCommandThreadRunning()
		{
			return this.m_LuaCommandThread != null && (this.m_LuaCommandThread.ThreadState & ThreadState.Stopped) != ThreadState.Stopped;
		}


		public void AbortLuaCommandThread()
		{
			if (!this.IsLuaCommandThreadRunning())
			{
				return;
			}
			if ((this.m_LuaCommandThread.ThreadState & ThreadState.Suspended) == ThreadState.Suspended)
			{
				this.m_LuaCommandThread.Resume();
			}
			this.m_LuaCommandThread.Abort();
			this.m_ShellTextBox.AppendText("(Aborted by user)");
		}


		private void iHandleGuiBeforeAfterCommand(bool is_before)
		{
			if (base.InvokeRequired)
			{
				del_v_b method = new del_v_b(this.iHandleGuiBeforeAfterCommand);
				base.Invoke(method, new object[]
				{
					is_before
				});
				return;
			}
			if (is_before)
			{
				this.m_IsCommandRunning = true;
				this.m_btnAbort.Enabled = true;
				this.m_ShellTextBox.ReadOnly = true;
				return;
			}
			this.m_ShellTextBox.ReadOnly = false;
			this.m_btnAbort.Enabled = false;
			this.m_IsCommandRunning = false;
		}


		private void iHandleCommandExceptions(IAsyncResult res)
		{
			dCommandEntered dCommandEntered = (dCommandEntered)((AsyncResult)res).AsyncDelegate;
			try
			{
				dCommandEntered.EndInvoke(res);
			}
			catch (Exception ex)
			{
				GuiCore.RstdException(ex.Message.ToString(), ex.StackTrace);
			}
		}


		private void iHandleCommandEntered(object sender, CommandEnteredEventArgs e)
		{
			this.m_numCommandEntered++;
			if (e.Command == string.Empty)
			{
				return;
			}
			string[] array = this.iSplitShellCommands(e.Command.Trim());
			for (int i = 0; i < array.Length; i++)
			{
				string command;
				if (i == array.Length - 1 && !e.Command.EndsWith(";"))
				{
					command = array[i].Trim();
				}
				else
				{
					command = array[i].Trim() + ";";
				}
				if (!this.iHandleSingleCommand(command))
				{
					return;
				}
			}
		}


		private string[] iSplitShellCommands(string command)
		{
			List<string> list = new List<string>();
			bool flag = false;
			bool flag2 = false;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < command.Length; i++)
			{
				if (command[i] == '(')
				{
					flag = true;
				}
				if (command[i] == '"')
				{
					flag2 = (num % 2 == 0);
					num++;
				}
				if (command[i] == ')')
				{
					flag = false;
				}
				if (command[i] == ';' && !flag && !flag2)
				{
					string text = command.Substring(num3, i - num3).Trim();
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
						num2++;
					}
					num3 = i + 1;
				}
				if (i + 1 == command.Length)
				{
					string text = command.Substring(num3, i - num3 + 1).Trim();
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
				}
			}
			return list.ToArray();
		}


		private bool iHandleSingleCommand(string command)
		{
			List<string> if_return_value = null;
			try
			{
				if (!this.m_bInBlock && command == "beginblock")
				{
					this.iCommandBeginBlockHandle();
				}
				else if (this.m_bInBlock)
				{
					if (command == "breakblock")
					{
						this.iCommandBreakBlockHandle();
					}
					else if (command == "endblock")
					{
						if (!this.iCommandEndBlockHandle())
						{
							return false;
						}
					}
					else
					{
						this.m_StrBuffer = this.m_StrBuffer + command + "\n";
					}
				}
				else if (command == "cls")
				{
					this.iClearShell();
				}
				else if (command.StartsWith("help"))
				{
					if (command == "help")
					{
						this.CookHelpStrings("RSTD");
						this.HelpMenu();
					}
					else if (command.StartsWith("help "))
					{
						this.CookSpecificHelpArgs(ref command);
					}
				}
				else if (command == "history")
				{
					this.CookHistory();
				}
				else if (command.StartsWith("prompt"))
				{
					this.HandlePrompt(command);
				}
				else if (command == "packages")
				{
					this.PrintLuaPackages();
				}
				else if (command.StartsWith("package") && !command.StartsWith("packages"))
				{
					string[] array = command.Split(new char[]
					{
						' '
					});
					if (array.Length > 1)
					{
						this.HandleLuaPackage(array[1]);
					}
					else
					{
						this.m_ShellTextBox.AppendText("See help description for package command");
					}
				}
				else if (command == "clear history")
				{
					this.iHandleClearHistory();
				}
				else if (command.StartsWith("dofile"))
				{
					if (!this.iHandleDoFile(command))
					{
						return false;
					}
				}
				else if (command.StartsWith("print("))
				{
					this.iHandlePrint(command, "print");
				}
				else if (command.StartsWith("table.print("))
				{
					this.iHandlePrint(command, "table.print");
				}
				else if (!this.m_bInBlock && command != "endblock")
				{
					try
					{
						if (!this.TryExecuteLuaCommand(if_return_value, command))
						{
							return false;
						}
					}
					catch (Exception ex)
					{
						this.m_ShellTextBox.WriteText(ex.Message);
					}
				}
				this.iAppendToLuaShellCommandsStr(command);
			}
			catch (Exception ex2)
			{
				GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_ERROR, ex2.Message, ex2.StackTrace);
			}
			return true;
		}


		private bool TryExecuteLuaCommand(List<string> if_return_value, string command)
		{
			bool flag = false;
			if (command.Split("\r\n".ToCharArray()).Length > 1 || this.iShouldLuaCommandRunAsIs(command))
			{
				LuaWrapperUtils.DoLuaString(command, out this.m_LuaCommandThread, out flag);
				return flag;
			}
			if_return_value = LuaWrapperUtils.CheckIfLuaReturnValue(command, ref this.m_LuaCommandThread, out flag);
			if (flag)
			{
				return false;
			}
			if (if_return_value != null)
			{
				if (if_return_value[0].ToString() == "var_equals_value@")
				{
					this.iHandleVarEqualsValue(command, out flag);
				}
				else if (if_return_value.Count > 1)
				{
					string text = if_return_value[0];
					for (int i = 1; i < if_return_value.Count; i++)
					{
						text = text + "," + if_return_value[i];
					}
					this.m_ShellTextBox.WriteText("ans=" + text + "\r\n");
				}
				else
				{
					this.m_ShellTextBox.WriteText("ans=" + if_return_value[0] + "\r\n");
				}
				this.m_ShellTextBox.ValidCommandHistory.AddToValidArrayList(command);
			}
			return true;
		}


		private bool iShouldLuaCommandRunAsIs(string lua_command)
		{
			return lua_command.EndsWith(";") || lua_command.Contains("function");
		}


		private void iHandleVarEqualsValue(string command, out bool aborted)
		{
			string[] array = command.Split(new char[]
			{
				'='
			});
			LuaWrapperUtils.DoLuaString(command, out this.m_LuaCommandThread, out aborted);
			if (aborted)
			{
				return;
			}
			object[] array2 = LuaWrapperUtils.DoLuaString("return " + array[0].Trim(), out this.m_LuaCommandThread, out aborted);
			if (aborted)
			{
				return;
			}
			if (array2.Length != 0)
			{
				string str;
				if (array2[0] == null)
				{
					str = "nil";
					this.m_ShellTextBox.WriteText(array[0].Trim() + "=" + str);
					return;
				}
				List<string> list = new List<string>();
				if (array2.Length > 1)
				{
					for (int i = 0; i < array2.Length; i++)
					{
						if (array2[i] == null)
						{
							list.Add("nil");
						}
						else
						{
							list.Add(array2[i].ToString());
						}
					}
					string[] array3 = array[0].Split(new char[]
					{
						','
					});
					string text = array3[0].Trim() + "=" + list[0].Trim();
					for (int j = 1; j < array3.Length; j++)
					{
						text = string.Concat(new string[]
						{
							text,
							"\n",
							array3[j].Trim(),
							"=",
							list[j].Trim()
						});
					}
					this.m_ShellTextBox.WriteText(text);
					return;
				}
				str = array2[0].ToString();
				this.m_ShellTextBox.WriteText(array[0].Trim() + "=" + str);
			}
		}


		private void iClearShell()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.iClearShell);
				base.Invoke(method);
				return;
			}
			this.m_ShellTextBox.Clear();
		}


		private void CookHistory()
		{
			StringBuilder stringBuilder = new StringBuilder(this.m_ShellTextBox.GetCommandHistory().Length);
			this.HandleHistory(ref stringBuilder);
			this.m_ShellTextBox.WriteText(stringBuilder.ToString());
		}


		private void iCommandBreakBlockHandle()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.iCommandBreakBlockHandle);
				base.Invoke(method);
				return;
			}
			this.m_bInBlock = false;
			this.m_StrBuffer = "";
			this.m_ShellTextBox.Prompt = this.m_HoldRealPrompt;
		}


		private void CookSpecificHelpArgs(ref string command)
		{
			string text = command.Remove(0, 5).Trim();
			if (!text.Contains(" ") || text.Equals("clear history"))
			{
				try
				{
					this.PrintHelpSpecificCommand(text);
				}
				catch (Exception ex)
				{
					this.m_ShellTextBox.WriteText(ex.Message);
				}
			}
		}


		private void iHandleClearHistory()
		{
			this.m_ShellTextBox.CommandHistory.EraseCommandHistory();
			this.m_ShellTextBox.ValidCommandHistory.EraseCommandHistory();
			if (File.Exists(this.m_MainForm.LuaHistoryCommandFile))
			{
				File.SetAttributes(this.m_MainForm.LuaHistoryCommandFile, FileAttributes.Normal);
				File.Delete(this.m_MainForm.LuaHistoryCommandFile);
			}
		}


		private void iAppendToLuaShellCommandsStr(string command)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.iAppendToLuaShellCommandsStr);
				base.Invoke(method, new object[]
				{
					command
				});
				return;
			}
			if (0 >= this.m_LuaShellTextFromStart.Length)
			{
				this.m_LuaShellTextFromStart.Append(this.m_ShellTextBox.Text);
				return;
			}
			if ("cls" != command && !this.m_bWasCLS_command)
			{
				this.m_LuaShellTextFromStart.Remove(0, this.m_LuaShellTextFromStart.Length);
				this.m_LuaShellTextFromStart.Append(this.m_ShellTextBox.Text);
				return;
			}
			this.m_LuaShellTextFromStart.Append(command + "\r\n");
			this.m_bWasCLS_command = true;
		}


		private bool iCommandEndBlockHandle()
		{
			this.m_bInBlock = false;
			this.m_ShellTextBox.Prompt = this.m_HoldRealPrompt;
			bool flag = false;
			try
			{
				LuaWrapperUtils.DoLuaString(this.m_StrBuffer, out this.m_LuaCommandThread, out flag);
				if (flag)
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				this.m_ShellTextBox.WriteText(ex.Message);
			}
			finally
			{
				this.m_StrBuffer = "";
			}
			return true;
		}


		private void iCommandBeginBlockHandle()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.iCommandBeginBlockHandle);
				base.Invoke(method);
				return;
			}
			this.m_HoldRealPrompt = this.m_ShellTextBox.Prompt;
			this.m_ShellTextBox.Prompt = " ";
			this.m_bInBlock = true;
		}


		private void saveLuaShellLayoutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save a Layout";
			saveFileDialog.Filter = "Lua shell Settings file (*.txt)|*.txt";
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.ValidateNames = true;
			saveFileDialog.ShowDialog();
			if (!string.IsNullOrEmpty(saveFileDialog.FileName))
			{
				FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
				GuiCore.VerbosePrint(string.Format("LuaSaveXml(\"{0}\")\n", saveFileDialog.FileName.Replace('\\', '/')));
				binaryFormatter.Serialize(fileStream, this.m_ShellTextBox);
				fileStream.Close();
			}
		}


		private void loadLuaShellLayoutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Load a Layout";
			openFileDialog.Filter = "Lua shell Settings file (*.txt)|*.txt";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.InitialDirectory = RstdGuiSettings.Default.LastScriptPath;
			openFileDialog.ShowDialog();
			if (!string.IsNullOrEmpty(openFileDialog.FileName))
			{
				RstdGuiSettings.Default.LastScriptPath = Path.GetDirectoryName(openFileDialog.FileName);
				RstdGuiSettings.Default.Save();
				GuiCore.VerbosePrint(string.Format("LuaLoadXml(\"{0}\")\n", openFileDialog.FileName.Replace('\\', '/')));
				FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
				ShellTextBox shellTextBox = (ShellTextBox)binaryFormatter.Deserialize(fileStream);
				this.m_ShellTextBox.Font = shellTextBox.Font;
				this.m_ShellTextBox.ForeColor = shellTextBox.ForeColor;
				this.m_ShellTextBox.BackColor = shellTextBox.BackColor;
				this.m_MainForm.SaveLuaLayoutToRstdGuiSettings();
				fileStream.Close();
			}
		}


		private void loadCommandFleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Open a Lua shell commands file";
			openFileDialog.Filter = "Lua shell commands file (*.lua)|*.lua";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.InitialDirectory = RstdGuiSettings.Default.LastScriptPath;
			openFileDialog.ShowDialog();
			if (!string.IsNullOrEmpty(openFileDialog.FileName))
			{
				if (Path.GetExtension(openFileDialog.FileName).ToLower() != ".lua")
				{
					this.m_ShellTextBox.WriteText("Load is allowed only for files with *.lua extension!");
					this.m_ShellTextBox.printLine();
					this.m_ShellTextBox.printPrompt();
					return;
				}
				RstdGuiSettings.Default.LastScriptPath = Path.GetDirectoryName(openFileDialog.FileName);
				RstdGuiSettings.Default.Save();
				GuiCore.VerbosePrint(string.Format("LuaLoad(\"{0}\")\n", openFileDialog.FileName.Replace('\\', '/')));
				this.iRunScriptAndWriteToShell(openFileDialog.FileName);
			}
		}


		private void iRunScriptAndWriteToShell(string fileName)
		{
			foreach (string text in File.ReadAllLines(fileName))
			{
				if (text != "")
				{
					string text2 = text.TrimEnd(new char[0]);
					this.m_ShellTextBox.AppendText(text2);
					this.m_ShellTextBox.printLine();
					this.m_ShellTextBox.CommandHistory.Add(text2);
					this.m_numCommandEntered++;
					this.m_ShellTextBox.printPrompt();
				}
			}
			this.m_MainForm.bStartScript(fileName, null);
			GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Finished script!");
			this.m_ShellTextBox.printPrompt();
		}


		private void fontToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			FontDialog fontDialog = new FontDialog();
			if (fontDialog.ShowDialog() == DialogResult.OK)
			{
				this.m_ShellTextBox.Font = fontDialog.Font;
				RstdGuiSettings.Default.LuaFamilyFont = this.m_ShellTextBox.Font.FontFamily.Name;
				RstdGuiSettings.Default.LuaFontBold = this.m_ShellTextBox.Font.Bold.ToString();
				RstdGuiSettings.Default.LuaFontItalic = this.m_ShellTextBox.Font.Italic.ToString();
				RstdGuiSettings.Default.LuaFontSize = this.m_ShellTextBox.Font.Size.ToString();
				RstdGuiSettings.Default.Save();
			}
			fontDialog.AllowSimulations = true;
		}


		private void h_BackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.ShowDialog();
			this.m_ShellTextBox.BackColor = colorDialog.Color;
			this.m_BackgroundColor.BackColor = colorDialog.Color;
			RstdGuiSettings.Default.LuaBackGroundColor = frmLuaShell.ConvertColorToHex(this.m_ShellTextBox.BackColor);
			RstdGuiSettings.Default.Save();
		}


		private void h_foregroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.ShowDialog();
			this.m_ShellTextBox.ForeColor = colorDialog.Color;
			this.m_foregroundColor.ForeColor = colorDialog.Color;
			RstdGuiSettings.Default.LuaForeGroundColor = frmLuaShell.ConvertColorToHex(this.m_ShellTextBox.ForeColor);
			RstdGuiSettings.Default.Save();
		}


		public static string ConvertColorToHex(Color color)
		{
			string text = color.A.ToString("X2");
			string text2 = color.R.ToString("X2");
			string text3 = color.G.ToString("X2");
			string text4 = color.B.ToString("X2");
			return string.Concat(new string[]
			{
				text,
				text2,
				text3,
				text4
			});
		}


		public static Color ConvertHexToColor(string color)
		{
			int alpha = int.Parse(color.Substring(0, 2), NumberStyles.AllowHexSpecifier);
			int red = int.Parse(color.Substring(2, 2), NumberStyles.AllowHexSpecifier);
			int green = int.Parse(color.Substring(4, 2), NumberStyles.AllowHexSpecifier);
			int blue = int.Parse(color.Substring(6, 2), NumberStyles.AllowHexSpecifier);
			return Color.FromArgb(alpha, red, green, blue);
		}


		private void iLoadLuaHistory()
		{
			string[] separator = new string[]
			{
				"\n"
			};
			if (File.Exists(this.m_MainForm.LuaHistoryCommandFile))
			{
				string text = File.ReadAllText(this.m_MainForm.LuaHistoryCommandFile);
				if ("" != text)
				{
					text = text.Trim();
					string[] array = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
					for (int i = 0; i < array.Length - 1; i++)
					{
						array[i] = array[i].TrimEnd(new char[]
						{
							'\r'
						});
						this.m_ShellTextBox.CommandHistory.Add(array[i]);
					}
				}
			}
		}


		private void iHandlePrint(string command, string startCommand)
		{
			command = command.Remove(0, startCommand.Length);
			if (startCommand == "print")
			{
				command = command.Insert(0, "shellprint");
			}
			if (startCommand == "table.print")
			{
				command = command.Insert(0, "tableshellprint");
			}
			try
			{
				string text = LuaWrapperUtils.CheckPrintValue(command);
				this.m_ShellTextBox.WriteText(text);
			}
			catch (Exception ex)
			{
				this.m_ShellTextBox.WriteText(ex.Message);
			}
		}


		private bool iHandleDoFile(string command)
		{
			bool flag = false;
			try
			{
				LuaWrapperUtils.DoLuaString(command, out this.m_LuaCommandThread, out flag);
				if (flag)
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				this.m_ShellTextBox.WriteText(ex.Message);
			}
			return true;
		}


		private static string GetPathFromCommand(string command, string CommandWithConcat)
		{
			CommandWithConcat = command;
			CommandWithConcat = CommandWithConcat.Trim();
			CommandWithConcat = CommandWithConcat.TrimStart("dofile".ToCharArray());
			CommandWithConcat = CommandWithConcat.TrimStart(new char[0]);
			CommandWithConcat = CommandWithConcat.TrimStart(new char[]
			{
				'('
			});
			CommandWithConcat = CommandWithConcat.TrimEnd(new char[]
			{
				')'
			});
			return CommandWithConcat;
		}


		private void CookHelpStrings(string package_name)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.CookHelpStrings);
				base.Invoke(method, new object[]
				{
					package_name
				});
				return;
			}
			string[] array = LuaWrapperUtils.LuaWrapper.HelpCommand(package_name).Split(new char[]
			{
				'$'
			}, StringSplitOptions.RemoveEmptyEntries);
			this.m_ShellTextBox.WriteText("Available commands in " + package_name + ":\n\r\n");
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'-'
				});
				string text = (i + 1).ToString() + ". " + array2[0];
				string arg = array2[1];
				this.ParseMethodLineString(text);
				this.m_ShellTextBox.AppendText(string.Format("{0," + (text.Length - 80) + "} - {1}\r\n", "", arg));
			}
		}


		private void ChangeTextColor(Color color)
		{
			if (base.InvokeRequired)
			{
				del_v_color method = new del_v_color(this.ChangeTextColor);
				base.Invoke(method, new object[]
				{
					color
				});
				return;
			}
			this.m_ShellTextBox.SelectionColor = color;
			this.m_ShellTextBox.SelectionFont = this.m_ShellTextBox.Font;
		}


		private string ParseMethodLineString(string line)
		{
			if (base.InvokeRequired)
			{
				del_s_s method = new del_s_s(this.ParseMethodLineString);
				return (string)base.Invoke(method, new object[]
				{
					line
				});
			}
			string[] array = Regex.Split(line, "([ &\\t\n{}(),;])");
			int i = 0;
			while (i < array.Length)
			{
				string text = array[i];
				this.ChangeTextColor(Color.Black);
				uint num = PrivateImplementationDetails.ComputeStringHash(text);
				if (num <= 621580159U)
				{
					if (num <= 71344974U)
					{
						if (num != 70359236U)
						{
							if (num != 71344974U)
							{
								goto IL_1C4;
							}
							if (!(text == "_I_"))
							{
								goto IL_1C4;
							}
							goto IL_171;
						}
						else
						{
							if (!(text == "_O_"))
							{
								goto IL_1C4;
							}
							goto IL_171;
						}
					}
					else if (num != 588024921U)
					{
						if (num != 621580159U)
						{
							goto IL_1C4;
						}
						if (!(text == " "))
						{
							goto IL_1C4;
						}
						goto IL_160;
					}
					else
					{
						if (!(text == "&"))
						{
							goto IL_1C4;
						}
						this.ChangeTextColor(Color.Blue);
						this.m_ShellTextBox.SelectedText = text;
					}
				}
				else if (num <= 739023492U)
				{
					if (num != 688690635U)
					{
						if (num != 739023492U)
						{
							goto IL_1C4;
						}
						if (!(text == ")"))
						{
							goto IL_1C4;
						}
						goto IL_160;
					}
					else
					{
						if (!(text == ","))
						{
							goto IL_1C4;
						}
						goto IL_160;
					}
				}
				else if (num != 755801111U)
				{
					if (num != 3264848979U)
					{
						goto IL_1C4;
					}
					if (!(text == "_IO_"))
					{
						goto IL_1C4;
					}
					goto IL_171;
				}
				else
				{
					if (!(text == "("))
					{
						goto IL_1C4;
					}
					goto IL_160;
				}
				IL_299:
				i++;
				continue;
				IL_160:
				this.m_ShellTextBox.SelectedText = text;
				goto IL_299;
				IL_171:
				this.ChangeTextColor(Color.Black);
				this.m_ShellTextBox.SelectionFont = new Font("Courier New", 10.2f, FontStyle.Italic);
				this.m_ShellTextBox.SelectedText = text;
				goto IL_299;
				IL_1C4:
				if (text.Contains("."))
				{
					string[] array2 = text.Split(new char[]
					{
						'.'
					});
					if (array2[1] != "" && LuaWrapperUtils.LuaWrapper.bContainsPackage(array2[0]))
					{
						this.ChangeTextColor(Color.LightSeaGreen);
						this.m_ShellTextBox.SelectedText = array2[0];
						this.ChangeTextColor(Color.Black);
						this.m_ShellTextBox.AddText(".");
						this.ChangeTextColor(Color.DarkRed);
						this.m_ShellTextBox.SelectedText = array2[1];
						goto IL_299;
					}
					this.m_ShellTextBox.SelectedText = text;
					goto IL_299;
				}
				else
				{
					if (this.types.Contains(text))
					{
						this.ChangeTextColor(Color.Blue);
						this.m_ShellTextBox.SelectedText = text;
						goto IL_299;
					}
					this.m_ShellTextBox.SelectedText = text;
					goto IL_299;
				}
			}
			return this.m_ShellTextBox.SelectedText;
		}


		private void HandleHistory(ref StringBuilder stringBuilder)
		{
			foreach (string text in this.m_ShellTextBox.GetCommandHistory())
			{
				if (!text.Equals("clear history"))
				{
					stringBuilder.Append(text);
					stringBuilder.Append("\r\n");
				}
			}
		}


		private void HandlePrompt(string command)
		{
			string[] array = command.Split(new char[]
			{
				'='
			});
			if (array.Length == 2 && array[0].Trim() == "prompt")
			{
				this.m_ShellTextBox.Prompt = array[1].Trim();
			}
		}


		private void HelpMenu()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.HelpMenu);
				base.Invoke(method);
				return;
			}
			short num = 1;
			this.m_ShellTextBox.AppendText("Available user commands: \r\n");
			foreach (KeyValuePair<string, string> keyValuePair in LuaWrapperUtils.LuaShellCommands)
			{
				this.m_ShellTextBox.AppendText(string.Concat(new object[]
				{
					"(",
					num,
					") ",
					keyValuePair.Key,
					" - ",
					keyValuePair.Value,
					"\r\n"
				}));
				num += 1;
			}
		}


		private void PrimerHelpMenu()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.PrimerHelpMenu);
				base.Invoke(method);
				return;
			}
			short num = 1;
			this.m_ShellTextBox.AppendText("Available user commands: \r\n");
			foreach (KeyValuePair<string, string> keyValuePair in LuaWrapperUtils.LuaShellCommands)
			{
				this.m_ShellTextBox.AppendText(string.Concat(new object[]
				{
					"(",
					num,
					") ",
					keyValuePair.Key,
					" - ",
					keyValuePair.Value,
					"\r\n"
				}));
				if (num == 3)
				{
					break;
				}
				num += 1;
			}
		}


		private void PrintLuaPackages()
		{
			try
			{
				string chunk = "for aKey, aValue in pairs( _G ) do if type( rawget( _G, aKey ) ) == \"table\" and aKey~=\"TableDefinedInDotNet\" then print( aKey ) end end";
				LuaWrapperUtils.LuaWrapper.LuaVM.DoString(chunk);
			}
			catch (Exception ex)
			{
				this.m_ShellTextBox.WriteText(ex.Message);
			}
		}


		private void HandleLuaPackage(string package_name)
		{
			if (LuaWrapperUtils.LuaWrapper.bContainsPackage(package_name))
			{
				this.CookHelpStrings(package_name);
				return;
			}
			this.PrintPackageContent(package_name);
			uint num = PrivateImplementationDetails.ComputeStringHash(package_name);
			if (num <= 1580477207U)
			{
				if (num <= 1110998065U)
				{
					if (num != 398550328U)
					{
						if (num == 1110998065U)
						{
							if (package_name == "io")
							{
								this.m_ShellTextBox.AppendText("For information about the functionality of table go to - http://www.lua.org/manual/5.1/manual.html#5.7\r\n");
								return;
							}
						}
					}
					else if (package_name == "string")
					{
						this.m_ShellTextBox.AppendText("For information about the functionality of table go to - http://www.lua.org/manual/5.1/manual.html#5.4\r\n");
						return;
					}
				}
				else if (num != 1251777503U)
				{
					if (num != 1483009432U)
					{
						if (num == 1580477207U)
						{
							if (package_name == "os")
							{
								this.m_ShellTextBox.AppendText("For information about the functionality of os package go to - http://www.lua.org/manual/5.1/manual.html#5.8\r\n");
								return;
							}
						}
					}
					else if (package_name == "debug")
					{
						this.m_ShellTextBox.AppendText("For information about the functionality of table go to - http://www.lua.org/manual/5.1/manual.html#5.9\r\n");
						return;
					}
				}
				else if (package_name == "table")
				{
					this.m_ShellTextBox.AppendText("For information about the functionality of table go to - http://www.lua.org/manual/5.1/manual.html#5.5\r\n");
					return;
				}
			}
			else if (num <= 2166136261U)
			{
				if (num != 1726211973U)
				{
					if (num == 2166136261U)
					{
						if (package_name != null && package_name.Length != 0)
						{
						}
					}
				}
				else if (package_name == "coroutine")
				{
					this.m_ShellTextBox.AppendText("For information about the functionality of table go to - http://lua-users.org/wiki/CoroutinesTutorial\r\n");
					return;
				}
			}
			else if (num != 2436574203U)
			{
				if (num != 4001929615U)
				{
					if (num == 4275412884U)
					{
						if (package_name == "luanet")
						{
							return;
						}
					}
				}
				else if (package_name == "math")
				{
					this.m_ShellTextBox.AppendText("For information about the functionality of math package go to - http://www.lua.org/manual/5.1/manual.html#5.6\r\n");
					return;
				}
			}
			else if (package_name == "package")
			{
				this.m_ShellTextBox.AppendText("For information about the functionality of table go to - http://www.lua.org/manual/5.1/manual.html#5.3\r\n");
				return;
			}
			this.m_ShellTextBox.AppendText("This is not an existing package");
		}


		private void PrintPackageContent(string package_name)
		{
			string chunk = string.Concat(new string[]
			{
				"for aKey, aValue in pairs(",
				package_name,
				") do if type( rawget(",
				package_name,
				", aKey ) ) == \"function\" then print( aKey ) end end"
			});
			LuaWrapperUtils.LuaWrapper.LuaVM.DoString(chunk);
		}


		private void PrintHelpSpecificCommand(string specific_cmd)
		{
			string line = "";
			if (LuaWrapperUtils.LuaWrapper.bContainsPackage(specific_cmd))
			{
				this.HandleLuaPackage(specific_cmd);
				return;
			}
			uint num = PrivateImplementationDetails.ComputeStringHash(specific_cmd);
			if (num <= 1483009432U)
			{
				if (num <= 1110998065U)
				{
					if (num != 398550328U)
					{
						if (num != 1110998065U)
						{
							goto IL_150;
						}
						if (!(specific_cmd == "io"))
						{
							goto IL_150;
						}
					}
					else if (!(specific_cmd == "string"))
					{
						goto IL_150;
					}
				}
				else if (num != 1251777503U)
				{
					if (num != 1483009432U)
					{
						goto IL_150;
					}
					if (!(specific_cmd == "debug"))
					{
						goto IL_150;
					}
				}
				else if (!(specific_cmd == "table"))
				{
					goto IL_150;
				}
			}
			else if (num <= 1726211973U)
			{
				if (num != 1580477207U)
				{
					if (num != 1726211973U)
					{
						goto IL_150;
					}
					if (!(specific_cmd == "coroutine"))
					{
						goto IL_150;
					}
				}
				else if (!(specific_cmd == "os"))
				{
					goto IL_150;
				}
			}
			else if (num != 2436574203U)
			{
				if (num != 4001929615U)
				{
					if (num != 4275412884U)
					{
						goto IL_150;
					}
					if (!(specific_cmd == "luanet"))
					{
						goto IL_150;
					}
				}
				else if (!(specific_cmd == "math"))
				{
					goto IL_150;
				}
			}
			else
			{
				if (!(specific_cmd == "package"))
				{
					goto IL_150;
				}
				line = LuaWrapperUtils.LuaShellCommands["package <package name>"];
				goto IL_17C;
			}
			this.HandleLuaPackage(specific_cmd);
			goto IL_17C;
			IL_150:
			if (!this.ibCheckModuleFunction(specific_cmd, ref line))
			{
				if (LuaWrapperUtils.LuaShellCommands.ContainsKey(specific_cmd))
				{
					line = LuaWrapperUtils.LuaShellCommands[specific_cmd];
				}
				else
				{
					line = "The command is not supported.";
				}
			}
			IL_17C:
			this.m_ShellTextBox.AppendText(this.ParseMethodLineString(line) + "\r\n");
		}


		private bool ibCheckModuleFunction(string command, ref string helpOnSpecificCommand)
		{
			command = command.TrimEnd("()".ToCharArray());
			return LuaWrapperUtils.LuaWrapper.HelpOnCommand(command, ref helpOnSpecificCommand);
		}


		private bool HelpOnSpecificRSTDFunction(string is_rttt_function, ref string helpOnSpecificCommand)
		{
			return LuaWrapperUtils.LuaWrapper.HelpOnCommand(is_rttt_function, ref helpOnSpecificCommand);
		}


		private void iRegisterShellPrintFunctionToLua()
		{
			MethodInfo method = base.GetType().GetMethod("ShellPrint");
			LuaWrapperUtils.LuaWrapper.LuaVM.RegisterFunction("ShellPrint", this, method);
		}


		public void ShellPrint(string print_me)
		{
			if (base.InvokeRequired)
			{
				frmLuaShell.GuiOperDel_1String guiOperDel_1String = new frmLuaShell.GuiOperDel_1String(this.ShellPrint);
				Delegate method = guiOperDel_1String;
				object[] args = new string[]
				{
					print_me
				};
				base.Invoke(method, args);
				return;
			}
			this.m_ShellTextBox.AppendText(print_me);
		}


		private SaveFileDialog iHandleSave(string title, string filter)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = title;
			saveFileDialog.Filter = filter;
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.RestoreDirectory = true;
			string luaPath = this.m_MainForm.RstdSettings.GetLuaPath();
			if (luaPath != "")
			{
				string[] array = luaPath.Split(new char[]
				{
					';'
				});
				saveFileDialog.InitialDirectory = array[0];
			}
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.ValidateNames = true;
			saveFileDialog.ShowDialog();
			return saveFileDialog;
		}


		private void iSaveCommandsToFile(string fileName, StringBuilder whatToSave)
		{
			StreamWriter streamWriter = new StreamWriter(fileName);
			try
			{
				streamWriter.Write(whatToSave);
			}
			catch (IOException ex)
			{
				this.m_ShellTextBox.WriteText(ex.Message);
			}
			finally
			{
				streamWriter.Close();
			}
		}


		private void iSaveAllLuaShellToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string title = "Save all Lua shell file";
			string filter = "Lua shell commands file Text File(*.txt)|*.txt";
			SaveFileDialog saveFileDialog = this.iHandleSave(title, filter);
			if (!string.IsNullOrEmpty(saveFileDialog.FileName))
			{
				GuiCore.VerbosePrint(string.Format("LuaSave(\"{0}\")", saveFileDialog.FileName.Replace('\\', '/')));
				this.iSaveCommandsToFile(saveFileDialog.FileName, this.m_LuaShellTextFromStart);
			}
		}


		private void hSaveLuaShellCommandsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string title = "Save a Lua shell commands file";
			string filter = "Lua shell commands file (*.lua)|*.lua|Text File(*.txt)|*.txt";
			SaveFileDialog saveFileDialog = this.iHandleSave(title, filter);
			if (!string.IsNullOrEmpty(saveFileDialog.FileName))
			{
				GuiCore.VerbosePrint(string.Format("LuaSave(\"{0}\")", saveFileDialog.FileName.Replace('\\', '/')));
				string[] validCommandHistory = this.m_ShellTextBox.GetValidCommandHistory();
				StringBuilder stringBuilder = new StringBuilder(validCommandHistory.Length);
				foreach (string value in validCommandHistory)
				{
					stringBuilder.Append(value);
					stringBuilder.Append("\r\n");
				}
				if (stringBuilder.Length > 0)
				{
					this.iSaveCommandsToFile(saveFileDialog.FileName, stringBuilder);
					return;
				}
				GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.RSTD_DEF, "Save: \n There is no history to save");
			}
		}


		private StringBuilder iGetRelevantCommandFromHistory(string[] commands)
		{
			StringBuilder stringBuilder = new StringBuilder(commands.Length);
			foreach (string text in commands)
			{
				if (this.iCheckIfCommandIsPackageCommand(text))
				{
					bool flag = false;
					if (text.Contains("."))
					{
						string text2 = text.Substring(0, text.IndexOf('.'));
						if (LuaWrapperUtils.CheckIfLuaPackage(text2))
						{
							string text3 = text.Substring(text.IndexOf('.') + 1);
							int num = text3.IndexOf('(');
							if (num > 0)
							{
								text3 = text3.Substring(0, num);
								flag = LuaWrapperUtils.IfExistInTable(text2, text3);
								flag = true;
							}
						}
						if (flag)
						{
							stringBuilder.Append(text);
							stringBuilder.Append("\r\n");
						}
					}
				}
			}
			return stringBuilder;
		}


		private bool iCheckIfCommandIsPackageCommand(string command)
		{
			foreach (KeyValuePair<string, string> keyValuePair in LuaWrapperUtils.LuaShellCommands)
			{
				if (command.StartsWith(keyValuePair.Key))
				{
					return false;
				}
			}
			return true;
		}


		private void hSaveBtn_ButtonClick(object sender, EventArgs e)
		{
			this.hSaveLuaShellCommandsToolStripMenuItem_Click(sender, e);
		}


		private void hDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.m_ShellTextBox.Font = new Font("Courier New", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 177);
			this.m_ShellTextBox.BackColor = SystemColors.Window;
			this.m_ShellTextBox.ForeColor = SystemColors.ControlText;
			this.m_MainForm.SaveLuaLayoutToRstdGuiSettings();
		}


		public void RstdGuiSettingsToLuaShellLayout()
		{
			try
			{
				float emSize = float.Parse(RstdGuiSettings.Default.LuaFontSize, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
				this.m_ShellTextBox.BackColor = frmLuaShell.ConvertHexToColor(RstdGuiSettings.Default.LuaBackGroundColor);
				this.m_ShellTextBox.ForeColor = frmLuaShell.ConvertHexToColor(RstdGuiSettings.Default.LuaForeGroundColor);
				if ("True" == RstdGuiSettings.Default.LuaFontBold)
				{
					if ("True" == RstdGuiSettings.Default.LuaFontItalic)
					{
						this.m_ShellTextBox.Font = new Font(RstdGuiSettings.Default.LuaFamilyFont, emSize, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 177);
					}
					else
					{
						this.m_ShellTextBox.Font = new Font(RstdGuiSettings.Default.LuaFamilyFont, emSize, FontStyle.Bold, GraphicsUnit.Point, 177);
					}
				}
				else if ("True" == RstdGuiSettings.Default.LuaFontItalic)
				{
					this.m_ShellTextBox.Font = new Font(RstdGuiSettings.Default.LuaFamilyFont, emSize, FontStyle.Italic, GraphicsUnit.Point, 177);
				}
				else
				{
					this.m_ShellTextBox.Font = new Font(RstdGuiSettings.Default.LuaFamilyFont, emSize, FontStyle.Regular, GraphicsUnit.Point, 177);
				}
			}
			catch (Exception ex)
			{
				GuiCore.RstdException(ex.ToString(), ex.StackTrace);
			}
		}


		private void beginBlockToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.m_ShellTextBox.AppendText("beginblock");
			this.m_ShellTextBox.Focus();
			SendKeys.Send("{ENTER}");
		}


		private void endBlockToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.m_ShellTextBox.AppendText("endblock");
			this.m_ShellTextBox.Focus();
			SendKeys.Send("{ENTER}");
		}


		private void breakBlockToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.m_ShellTextBox.AppendText("breakblock");
			this.m_ShellTextBox.Focus();
			SendKeys.Send("{ENTER}");
		}


		private void btnAbort_Click(object sender, EventArgs e)
		{
			this.AbortLuaCommandThread();
		}


		private frmMain m_MainForm;


		private string m_StrBuffer;


		private bool m_bInBlock;


		private bool m_bWasCLS_command;


		private string m_HoldRealPrompt;


		private StringBuilder m_LuaShellTextFromStart;


		private int m_numCommandEntered;


		private ShellTextBox m_ShellTextBox;


		private Thread m_LuaCommandThread;


		private bool m_IsCommandRunning;


		private List<string> types = new List<string>(new string[]
		{
			"Void",
			"String",
			"Boolean",
			"Bool",
			"Int32",
			"Number",
			"UInt32",
			"LuaTable",
			"Function",
			"General"
		});



		private delegate void GuiOperDel_1String(string varFullPath);
	}
}
