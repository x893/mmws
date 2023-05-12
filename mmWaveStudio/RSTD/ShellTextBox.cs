using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	[Serializable]
	internal class ShellTextBox : RichTextBox, ISerializable
	{



		public event ShellTextBox.EventCommandEntered CommandEntered;




		public string Prompt
		{
			get
			{
				return this.m_Prompt;
			}
			set
			{
				this.SetPromptText(value);
			}
		}




		internal CommandHistory CommandHistory
		{
			get
			{
				return this.m_CommandHistory;
			}
			set
			{
				this.m_CommandHistory = value;
			}
		}




		internal CommandHistory ValidCommandHistory
		{
			get
			{
				return this.m_ValidCommandHistory;
			}
			set
			{
				this.m_ValidCommandHistory = value;
			}
		}


		public string[] GetCommandHistory()
		{
			return this.m_CommandHistory.GetCommandHistory();
		}


		public string[] GetValidCommandHistory()
		{
			return this.m_ValidCommandHistory.GetCommandHistory();
		}


		protected ShellTextBox(SerializationInfo info, StreamingContext context)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			string text = (string)info.GetValue("HandWriting", typeof(string));
			this.Font = (Font)converter.ConvertFromString(text);
			TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(Color));
			text = (string)info.GetValue("FontColor", typeof(string));
			this.ForeColor = (Color)converter2.ConvertFromString(text);
			TypeConverter converter3 = TypeDescriptor.GetConverter(typeof(Color));
			text = (string)info.GetValue("BackGroundColor", typeof(string));
			this.BackColor = (Color)converter3.ConvertFromString(text);
		}


		internal ShellTextBox()
		{
			this.m_Components = null;
			this.m_Prompt = ">";
			this.m_PrevTokenInHistoryCommand = "";
			this.m_CommandHistory = new CommandHistory();
			this.m_ValidCommandHistory = new CommandHistory();
			this.m_CompletionList = new List<string>();
			this.m_LastCompletionModule = "";
			this.m_LastMatchingNode = null;
			this.m_CompletionIdx = 0;
			this.m_XmlPathCommands = new List<string>
			{
				"SetVar",
				"GetVar",
				"Transmit",
				"Receive",
				"TransmitArray",
				"ReceiveArray",
				"SetAndTransmit"
			};
			this.m_bWorkingOnCurrentHistoryCommand = 0;
			this.m_bWorkingOnRegularHistoryCommand = 0;
			this.InitializeComponent();
			this.printPrompt();
		}


		protected override void Dispose(bool disposing)
		{
			if (disposing && this.m_Components != null)
			{
				this.m_Components.Dispose();
			}
			base.Dispose(disposing);
		}


		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg != 12)
			{
				switch (msg)
				{
				case 768:
					break;
				case 769:
					goto IL_43;
				case 770:
					this.iHandlePaste();
					goto IL_43;
				case 771:
					return;
				default:
					goto IL_43;
				}
			}
			if (!this.IsCaretAtWritablePosition())
			{
				this.MoveCaretToEndOfText();
			}
			IL_43:
			if (m.Msg != 770)
			{
				base.WndProc(ref m);
			}
		}


		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.DetectUrls = false;
			base.AcceptsTab = true;
			this.Dock = DockStyle.Fill;
			base.Location = new Point(0, 0);
			base.Margin = new Padding(2, 2, 2, 2);
			this.MaxLength = 1048576;
			this.Multiline = true;
			this.Prompt = ">";
			base.ScrollBars = RichTextBoxScrollBars.Vertical;
			base.Size = new Size(400, 176);
			base.TabIndex = 0;
			this.Text = "";
			base.KeyDown += this.hShellTextBox_KeyDown;
			base.Name = "ShellTextBox";
			base.ResumeLayout(false);
		}


		private void hShellTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (!this.IsCaretAtWritablePosition() && !e.Control && e.KeyCode != Keys.Return)
			{
				this.MoveCaretToEndOfText();
			}
			Keys keyCode = e.KeyCode;
			if (keyCode <= Keys.Escape)
			{
				if (keyCode <= Keys.Tab)
				{
					if (keyCode != Keys.Back)
					{
						if (keyCode != Keys.Tab)
						{
							return;
						}
						this.iHandleTab();
						e.SuppressKeyPress = true;
						e.Handled = true;
						return;
					}
					else if (this.IsCaretJustBeforePrompt())
					{
						e.Handled = true;
						return;
					}
				}
				else
				{
					if (keyCode == Keys.Return)
					{
						string text = string.Empty;
						text = this.GetTextAtPrompt();
						if (text.Length != 0)
						{
							this.printLine();
							this.OnCommandEntered(text);
							this.m_CommandHistory.Add(text);
						}
						this.OrdinaryCommandHistoryCompletion();
						e.Handled = true;
						return;
					}
					if (keyCode != Keys.Escape)
					{
						return;
					}
					this.ReplaceTextAtPrompt("");
					return;
				}
			}
			else if (keyCode <= Keys.C)
			{
				switch (keyCode)
				{
				case Keys.Home:
					base.SelectionStart = base.GetFirstCharIndexOfCurrentLine() + this.m_Prompt.Length;
					this.SelectionLength = 0;
					e.Handled = true;
					return;
				case Keys.Left:
					if (this.IsCaretJustBeforePrompt())
					{
						e.Handled = true;
						return;
					}
					break;
				case Keys.Up:
					this.iHandleKeyUp();
					e.Handled = true;
					return;
				case Keys.Right:
				{
					string textAtPrompt = this.GetTextAtPrompt();
					string lastCommand = this.m_CommandHistory.LastCommand;
					if (lastCommand != null && (textAtPrompt.Length == 0 || lastCommand.StartsWith(textAtPrompt)) && lastCommand.Length > textAtPrompt.Length)
					{
						this.AddText(lastCommand[textAtPrompt.Length].ToString());
						return;
					}
					break;
				}
				case Keys.Down:
					this.iHandleKeyDown();
					e.Handled = true;
					return;
				default:
					if (keyCode != Keys.C)
					{
						return;
					}
					if (e.Control)
					{
						this.iHandleCopy();
						e.Handled = true;
						return;
					}
					break;
				}
			}
			else if (keyCode != Keys.Q)
			{
				switch (keyCode)
				{
				case Keys.V:
					if (e.Control)
					{
						this.iHandlePaste();
						e.Handled = true;
						return;
					}
					break;
				case Keys.W:
					break;
				case Keys.X:
					if (e.Control)
					{
						this.iHandleCut();
						e.Handled = true;
					}
					break;
				case Keys.Y:
					if (e.Control)
					{
						e.Handled = true;
						return;
					}
					break;
				case Keys.Z:
					if (e.Control)
					{
						e.Handled = true;
						return;
					}
					break;
				default:
					return;
				}
			}
			else if (e.Control)
			{
				((frmLuaShell)base.Parent).AbortLuaCommandThread();
				return;
			}
		}


		private bool iHandleTab()
		{
			bool result = false;
			try
			{
				string text = this.GetTextAtPrompt().Trim();
				if (text.EndsWith("("))
				{
					return false;
				}
				text = text.TrimEnd(new char[]
				{
					'(',
					')'
				});
				Match match = new Regex("(?<module>[A-Za-z_][\\w_]*)\\.((?<func>[A-Za-z_][\\w_]*)(\\((?<path>\"[ \\w/_-]*)?)?)?$").Match(text);
				if (match.Success)
				{
					string value = match.Groups["module"].Value;
					string value2 = match.Groups["func"].Value;
					string value3 = match.Groups["path"].Value;
					string prefix = text.Substring(0, match.Groups["module"].Index);
					result = this.iCompleteCommand(prefix, value, value2, value3);
				}
			}
			catch (Exception ex)
			{
				GuiCore.ErrorMessage(ex.Message);
				return false;
			}
			return result;
		}


		private bool iCompleteCommand(string prefix, string module_name, string func_name, string xml_path)
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			if (!LuaWrapperUtils.CheckIfLuaPackage(module_name))
			{
				return false;
			}
			if (xml_path != "")
			{
				if (this.iCompleteXmlPath(module_name, func_name, xml_path, out text3, out text2))
				{
					this.ReplaceTextAtPrompt(string.Format("{0}{1}.{2}(\"{3}{4}", new object[]
					{
						prefix,
						module_name,
						func_name,
						text3,
						text2
					}));
					return true;
				}
			}
			else if (this.iCompleteModuleFunc(module_name, func_name, out text))
			{
				string text4 = "";
				if (LuaWrapperUtils.LuaWrapper.GetFunctionNumParams(module_name, text) == 0)
				{
					text4 = "()";
				}
				this.ReplaceTextAtPrompt(string.Format("{0}{1}.{2}{3}", new object[]
				{
					prefix,
					module_name,
					text,
					text4
				}));
				return true;
			}
			return false;
		}


		private bool iCompleteModuleFunc(string module_name, string func_name, out string matching_func)
		{
			bool result = false;
			List<string> tableKeys = LuaWrapperUtils.GetTableKeys(module_name);
			matching_func = "";
			if (tableKeys.Count == 0)
			{
				return false;
			}
			if (this.m_CompletionList.Count > 0 && this.m_LastCompletionModule == module_name && this.m_CompletionList[this.m_CompletionIdx] == func_name)
			{
				this.m_CompletionIdx = this.iGetNextWrapIdxInList(this.m_CompletionList, this.m_CompletionIdx);
				matching_func = this.m_CompletionList[this.m_CompletionIdx];
				return true;
			}
			this.m_CompletionList.Clear();
			this.m_CompletionIdx = 0;
			this.m_LastCompletionModule = module_name;
			for (int i = 0; i < tableKeys.Count; i++)
			{
				if (tableKeys[i].ToLower().StartsWith(func_name.ToLower()))
				{
					this.m_CompletionList.Add(tableKeys[i]);
				}
			}
			if (this.m_CompletionList.Count > 0)
			{
				matching_func = this.m_CompletionList[this.m_CompletionIdx];
				result = true;
			}
			return result;
		}


		private int iGetNextWrapIdxInList(List<string> lst, int idx)
		{
			if (idx + 1 < lst.Count)
			{
				return idx + 1;
			}
			return 0;
		}


		private bool iCompleteXmlPath(string module_name, string func_name, string xml_path, out string node_path, out string matching_child)
		{
			bool result = false;
			XmlNode xmlNode = null;
			string text = "";
			node_path = "";
			matching_child = "";
			if (module_name.ToUpper() != "RTTT")
			{
				return false;
			}
			if (!this.m_XmlPathCommands.Contains(func_name))
			{
				return false;
			}
			if (xml_path == "\"")
			{
				matching_child = "/";
				return true;
			}
			xml_path = xml_path.Trim(new char[]
			{
				'"'
			});
			if (!this.iGetNodeForCompletion(xml_path, out xmlNode, out node_path, out text))
			{
				return false;
			}
			if (this.m_CompletionList.Count > 0 && this.m_LastMatchingNode == xmlNode && this.m_CompletionList[this.m_CompletionIdx] == text)
			{
				this.m_CompletionIdx = this.iGetNextWrapIdxInList(this.m_CompletionList, this.m_CompletionIdx);
				matching_child = this.m_CompletionList[this.m_CompletionIdx];
				return true;
			}
			this.m_CompletionList.Clear();
			this.m_CompletionIdx = 0;
			this.m_LastMatchingNode = xmlNode;
			this.iFillCompletionList(xmlNode, text);
			if (this.m_CompletionList.Count > 0)
			{
				matching_child = this.m_CompletionList[this.m_CompletionIdx];
				result = true;
			}
			return result;
		}


		private void iFillCompletionList(XmlNode node, string child_to_complete)
		{
			for (int i = 0; i < node.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = node.ChildNodes[i];
				NodeType nodeType = GuiCore.GetNodeType(xmlNode);
				if (xmlNode.Name != "#text" && nodeType != NodeType.ARGUMENT_LIST && nodeType != NodeType.RETURN_LIST)
				{
					string name;
					if (nodeType == NodeType.FIELD)
					{
						name = "field_name";
					}
					else
					{
						name = "name";
					}
					string value = xmlNode.Attributes[name].Value;
					if (value.ToLower().StartsWith(child_to_complete.ToLower()))
					{
						this.m_CompletionList.Add(value);
					}
				}
			}
		}


		private bool iGetNodeForCompletion(string xml_path, out XmlNode node, out string node_path, out string child_to_complete)
		{
			int num = xml_path.LastIndexOf("/");
			child_to_complete = "";
			node_path = "";
			node = null;
			if (num > -1)
			{
				node_path = xml_path.Substring(0, num + 1);
				if (GuiCore.GetNodeFromPath(node_path, out node, false))
				{
					child_to_complete = xml_path.Substring(num + 1);
					return true;
				}
			}
			return false;
		}


		private string iGetStringBeforeLastDot(string[] split_values)
		{
			string text = "";
			for (int i = 0; i < split_values.Length - 1; i++)
			{
				text = text + split_values[i] + ".";
			}
			if (text.Length > 0)
			{
				text = text.Remove(text.Length - 1);
			}
			return text;
		}


		private string iGetLastWordInPhrase(string phrase)
		{
			string text = phrase;
			if (phrase.Contains(" "))
			{
				text = phrase.Substring(phrase.LastIndexOf(" ") + 1);
			}
			if (text.Contains("("))
			{
				text = text.Substring(text.LastIndexOf('(') + 1);
			}
			return text;
		}


		public virtual void OnCommandEntered(string command)
		{
			if (this.CommandEntered != null)
			{
				this.CommandEntered(command, new CommandEnteredEventArgs(command));
			}
		}


		private void iHandleKeyUp()
		{
			string textAtPrompt = this.GetTextAtPrompt();
			if (!textAtPrompt.StartsWith(this.m_PrevTokenInHistoryCommand) || "" == this.m_PrevTokenInHistoryCommand || (textAtPrompt == this.m_PrevTokenInHistoryCommand && "" == textAtPrompt))
			{
				this.OrdinaryCommandHistoryCompletion();
			}
			if (this.m_bWorkingOnCurrentHistoryCommand == 0)
			{
				this.m_bWorkingOnCurrentHistoryCommand = 1;
				if (textAtPrompt == this.m_CommandHistory.Got_command_from_history || textAtPrompt == "")
				{
					this.m_bWorkingOnRegularHistoryCommand = 0;
					if (this.m_CommandHistory.DoesPreviousCommandExist())
					{
						this.ReplaceTextAtPrompt(this.m_CommandHistory.Got_command_from_history = this.m_CommandHistory.GetPreviousCommand().TrimEnd("\r\n".ToCharArray()));
						return;
					}
				}
				else
				{
					this.m_PrevTokenInHistoryCommand = textAtPrompt;
					if (this.m_CommandHistory.GetCommandsThatStartWithToken(textAtPrompt))
					{
						this.m_bWorkingOnCurrentHistoryCommand = 1;
						this.m_bWorkingOnRegularHistoryCommand = 1;
						this.ReplaceTextAtPrompt(this.m_CommandHistory.GetPreviousCommandThatStartsWithNoEmptyToken());
						return;
					}
					return;
				}
			}
			else if (this.m_bWorkingOnRegularHistoryCommand == 0)
			{
				if ("" == textAtPrompt)
				{
					this.m_CommandHistory.CurrentPosn = this.m_CommandHistory.CommandHistoryRegular.Count;
				}
				if (!this.m_CommandHistory.GetCommandsThatStartWithToken(textAtPrompt))
				{
					return;
				}
				if (this.m_CommandHistory.DoesPreviousCommandExist())
				{
					this.ReplaceTextAtPrompt(this.m_CommandHistory.Got_command_from_history = this.m_CommandHistory.GetPreviousCommand());
					return;
				}
			}
			else
			{
				if (!textAtPrompt.Equals(this.m_CommandHistory.LuaCurrentCommandHistory[this.m_CommandHistory.CurrentPosLua]))
				{
					this.m_CommandHistory.CurrentPosLua = this.m_CommandHistory.LuaCurrentCommandHistory.Count;
				}
				if (this.m_CommandHistory.DoesPreviousCommandThatStartsWithNoEmptyTokenExist())
				{
					this.ReplaceTextAtPrompt(this.m_CommandHistory.GetPreviousCommandThatStartsWithNoEmptyToken());
				}
			}
		}


		private void iHandleKeyDown()
		{
			if (this.m_bWorkingOnRegularHistoryCommand == 0)
			{
				if (this.m_CommandHistory.DoesNextCommandExist())
				{
					this.ReplaceTextAtPrompt(this.m_CommandHistory.Got_command_from_history = this.m_CommandHistory.GetNextCommand());
					return;
				}
			}
			else if (this.m_CommandHistory.DoesNextCommandThatStartsWithNoEmptyTokenExist())
			{
				this.ReplaceTextAtPrompt(this.m_CommandHistory.GetNextCommandThatStartsWithNoEmptyToken());
			}
		}


		public void OrdinaryCommandHistoryCompletion()
		{
			this.m_bWorkingOnCurrentHistoryCommand = 0;
			this.m_CommandHistory.EraseLuaCommandHistory();
		}


		private void iHandleCut()
		{
			if (!string.IsNullOrEmpty(this.SelectedText))
			{
				string selectedText = this.SelectedText;
				base.Cut();
				Clipboard.Clear();
				Clipboard.SetText(selectedText);
			}
		}


		private void iHandleCopy()
		{
			Clipboard.SetText(this.SelectedText);
		}


		private void iHandlePaste()
		{
			string text = "";
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			string text5 = string.Empty;
			string text6 = this.iClipBoardHandle();
			if (string.IsNullOrEmpty(text6))
			{
				return;
			}
			int selectionStart = base.SelectionStart;
			if (this.IsCaretAtWritablePosition())
			{
				text2 = this.GetTextAtPrompt();
				text3 = text2.Substring(0, text2.Length - (text2.Length - this.GetCurrentCaretColumnPositionForPaste()));
				text4 = text2.Substring(this.GetCurrentCaretColumnPositionForPaste() + this.SelectionLength);
				if (!string.IsNullOrEmpty(text4))
				{
					text6 = text6.TrimEnd("\r\n".ToCharArray());
				}
				text5 = text3 + text6 + text4;
				if (text5.EndsWith("\r\n"))
				{
					text5 = text5.Remove(text5.Length - 2, 2);
				}
				string[] array = text5.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 0)
				{
					this.Text = this.Text.Remove(selectionStart, text4.Length + this.SelectionLength);
					if (array.Length == 1)
					{
						this.AppendText(array[0].Substring(text3.Length));
						base.SelectionStart = selectionStart + text6.Length;
						return;
					}
					for (int i = 0; i < array.Length; i++)
					{
						text += array[i];
						if (i < array.Length - 1)
						{
							text += ";";
						}
						this.AppendText(array[i] + "\n");
					}
					this.iExecuteCommand(text);
				}
			}
		}


		private void iAppendCommandToShellAndExecute(string command)
		{
			this.AppendText(command);
			this.iExecuteCommand(command);
		}


		private void iExecuteCommand(string command)
		{
			this.printLine();
			this.OnCommandEntered(command);
			this.m_CommandHistory.Add(command);
		}


		private string iClipBoardHandle()
		{
			string result = string.Empty;
			DataObject dataObject = (DataObject)Clipboard.GetDataObject();
			if (dataObject.GetDataPresent(DataFormats.Text))
			{
				result = (string)dataObject.GetData(DataFormats.Text);
			}
			return result;
		}


		public void GetObjectData(SerializationInfo info, StreamingContext streamContext)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			Font font = this.Font;
			string value = TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(font);
			info.AddValue("HandWriting", value);
			Color foreColor = this.ForeColor;
			TypeDescriptor.GetConverter(typeof(Color));
			value = TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(foreColor);
			info.AddValue("FontColor", value);
			Color backColor = this.BackColor;
			TypeDescriptor.GetConverter(typeof(Color));
			value = TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(backColor);
			info.AddValue("BackGroundColor", value);
		}


		public void printPrompt()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.printPrompt);
				base.Invoke(method);
				return;
			}
			string text = this.Text;
			if (text.Length != 0 && '\n' != text[text.Length - 1])
			{
				this.printLine();
			}
			this.AddText(this.m_Prompt);
		}


		public void printLine()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.printLine);
				base.Invoke(method);
				return;
			}
			this.AddText("\r\n");
		}


		public string GetCurrentLine()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(this.GetCurrentLine);
				return (string)base.Invoke(method);
			}
			if (base.Lines.Length != 0)
			{
				return (string)base.Lines.GetValue(base.Lines.GetLength(0) - 1);
			}
			return "";
		}


		public string GetTextAtPrompt()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(this.GetTextAtPrompt);
				return (string)base.Invoke(method);
			}
			string result = "";
			string currentLine = this.GetCurrentLine();
			if (currentLine.Length > this.m_Prompt.Length)
			{
				result = currentLine.Substring(this.m_Prompt.Length);
			}
			return result;
		}


		private void ReplaceTextAtPrompt(string text)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.ReplaceTextAtPrompt);
				base.Invoke(method, new object[]
				{
					text
				});
				return;
			}
			int num = this.GetCurrentLine().Length - this.m_Prompt.Length;
			if (num == 0)
			{
				this.AddText(text);
				return;
			}
			base.Select(this.TextLength - num, num);
			this.SelectedText = text;
		}


		private bool IsCaretAtCurrentLine()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.IsCaretAtCurrentLine);
				return (bool)base.Invoke(method);
			}
			return this.TextLength - base.SelectionStart <= this.GetCurrentLine().Length;
		}


		private void MoveCaretToEndOfText()
		{
			if (base.InvokeRequired)
			{
				del_v_v method = new del_v_v(this.MoveCaretToEndOfText);
				base.Invoke(method);
				return;
			}
			base.SelectionStart = this.TextLength;
		}


		private bool IsCaretJustBeforePrompt()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.IsCaretJustBeforePrompt);
				return (bool)base.Invoke(method);
			}
			return this.IsCaretAtCurrentLine() && this.GetCurrentCaretColumnPosition() == this.m_Prompt.Length;
		}


		private int GetCurrentCaretColumnPosition()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(this.GetCurrentCaretColumnPosition);
				return (int)base.Invoke(method);
			}
			string currentLine = this.GetCurrentLine();
			return base.SelectionStart - this.TextLength + currentLine.Length;
		}


		private int GetCurrentCaretColumnPositionForPaste()
		{
			if (base.InvokeRequired)
			{
				del_i_v method = new del_i_v(this.GetCurrentCaretColumnPositionForPaste);
				return (int)base.Invoke(method);
			}
			string currentLine = this.GetCurrentLine();
			return base.SelectionStart - this.TextLength + currentLine.Length - this.m_Prompt.Length;
		}


		private bool IsCaretAtWritablePosition()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.IsCaretAtWritablePosition);
				return (bool)base.Invoke(method);
			}
			return this.IsCaretAtCurrentLine() && this.GetCurrentCaretColumnPosition() >= this.m_Prompt.Length;
		}


		private bool IsCaretAtWritablePositionForCopyPaste()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.IsCaretAtWritablePositionForCopyPaste);
				return (bool)base.Invoke(method);
			}
			return this.IsCaretAtCurrentLine() && this.GetCurrentCaretColumnPosition() >= this.m_Prompt.Length && this.GetCurrentCaretColumnPosition() < this.GetCurrentLine().Length;
		}


		private void SetPromptText(string val)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.SetPromptText);
				base.Invoke(method, new object[]
				{
					val
				});
				return;
			}
			this.GetCurrentLine();
			base.Select(0, this.m_Prompt.Length);
			this.SelectedText = val;
			this.m_Prompt = val;
		}


		public void WriteText(string text)
		{
			if (base.InvokeRequired)
			{
				UnManagedCoreMessageDel method = new UnManagedCoreMessageDel(this.WriteText);
				base.Invoke(method, new object[]
				{
					text
				});
				return;
			}
			this.AddText(text);
		}


		public void AddText(string text)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.AddText);
				base.Invoke(method, new object[]
				{
					text
				});
				return;
			}
			this.AppendText(text);
			this.MoveCaretToEndOfText();
		}


		public new void AppendText(string text)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.AppendText);
				base.Invoke(method, new object[]
				{
					text
				});
				return;
			}
			base.AppendText(text);
		}


		private string m_Prompt;


		private string m_PrevTokenInHistoryCommand;


		private short m_bWorkingOnCurrentHistoryCommand;


		private short m_bWorkingOnRegularHistoryCommand;


		private List<string> m_CompletionList;


		private int m_CompletionIdx;


		private string m_LastCompletionModule;


		private XmlNode m_LastMatchingNode;


		private List<string> m_XmlPathCommands;


		private CommandHistory m_CommandHistory;


		private CommandHistory m_ValidCommandHistory;


		private Container m_Components;



		public delegate void EventCommandEntered(object sender, CommandEnteredEventArgs e);


		private enum EHISTORY_COMPLETION
		{

			NOT_WORKING_ON_CURRENT_COMMAND,

			WORKING_ON_CURRENT_COMMAND
		}


		private enum ECOMPLETION_CRITERIA
		{

			EMPTY_LINE,

			NOT_EMPTY_LINE
		}
	}
}
