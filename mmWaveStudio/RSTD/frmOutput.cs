using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace RSTD
{

	public partial class frmOutput : DockContent
	{


		public RichTextBox ConsoleText
		{
			get
			{
				return this.m_ConsoleText;
			}
		}



		public ToolStripButton ButtonUserMsgMask
		{
			get
			{
				return this.m_btnUserMsgMask;
			}
		}



		public ToolStripButton ButtonAutoScroll
		{
			get
			{
				return this.btnAutoScroll;
			}
		}



		public ToolStripTextBox TextExclude
		{
			get
			{
				return this.m_txtExclude;
			}
		}



		public ToolStripTextBox TextInclude
		{
			get
			{
				return this.m_txtInclude;
			}
		}




		public bool ShowVerboseLogEnabled
		{
			get
			{
				return this.ConsoleTextMenuShowVerboseLog.Enabled;
			}
			set
			{
				this.ConsoleTextMenuShowVerboseLog.Enabled = value;
			}
		}




		public bool ShowUserLogEnabled
		{
			get
			{
				return this.showUserLogToolStripMenuItem.Enabled;
			}
			set
			{
				this.showUserLogToolStripMenuItem.Enabled = value;
			}
		}


		public frmOutput(frmMain main_form)
		{
			this.InitializeComponent();
			base.HideOnClose = true;
			this.m_MainForm = main_form;
			this.m_ConsoleText.ContentsResized += this.m_ConsoleText_ContentsResized;
		}


		private void m_ConsoleText_ContentsResized(object sender, ContentsResizedEventArgs e)
		{
			this.ConsoleTextMenuZoomComboBox.Text = this.m_ConsoleText.ZoomFactor.ToString();
		}


		private void ConsoleTextMenuCopy_Click(object sender, EventArgs e)
		{
			this.iHandleCopy();
		}


		private void ConsoleTextMenuClear_Click(object sender, EventArgs e)
		{
			this.ClearOutput();
		}


		private void ConsoleTextMenuZoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.m_ConsoleText.ZoomFactor = float.Parse(this.ConsoleTextMenuZoomComboBox.Text.ToString(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
		}


		private void ConsoleTextMenuShowLogFile_Click(object sender, EventArgs e)
		{
			this.m_MainForm.LuaOps.ShowLogFile();
		}


		private void ConsoleTextMenuShowVerboseLog_Click(object sender, EventArgs e)
		{
			this.m_MainForm.ShowVerboseLogFile();
		}


		private void showUserLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.m_MainForm.ShowUserLogFile();
		}


		private void openLogFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.m_MainForm.OpenLogFolder();
		}


		private void btnClear_Click(object sender, EventArgs e)
		{
			this.ClearOutput();
		}


		private void btnAutoScroll_Click(object sender, EventArgs e)
		{
			RstdGuiSettings.Default.bAutoScrollOutput = this.btnAutoScroll.Checked;
		}


		private void m_txtExclude_TextChanged(object sender, EventArgs e)
		{
			this.iSplitFilter((ToolStripTextBox)sender, ref this.m_MaskListExclude);
		}


		private void m_txtInclude_TextChanged(object sender, EventArgs e)
		{
			this.iSplitFilter((ToolStripTextBox)sender, ref this.m_MaskListInclude);
		}


		private void m_txtFilter_Leave(object sender, EventArgs e)
		{
			if (((ToolStripTextBox)sender).Text.StartsWith("[") && !((ToolStripTextBox)sender).Text.Contains("]"))
			{
				((ToolStripTextBox)sender).Text = "\\" + ((ToolStripTextBox)sender).Text;
			}
		}


		private void m_toolStrip_Resize(object sender, EventArgs e)
		{
			if (this.m_toolStrip.Width > 0)
			{
				int num = 20;
				int num2 = 0;
				foreach (object obj in this.m_toolStrip.Items)
				{
					ToolStripItem toolStripItem = (ToolStripItem)obj;
					if (toolStripItem != this.m_txtExclude && toolStripItem != this.m_txtInclude)
					{
						num2 += toolStripItem.Width;
					}
				}
				this.m_txtExclude.Width = (this.m_toolStrip.Width - num2 - num) / 2;
				this.m_txtInclude.Width = (this.m_toolStrip.Width - num2 - num) / 2;
				this.m_txtExclude.Width = (int)((double)this.m_txtExclude.Width * 0.7);
				this.m_txtInclude.Width = (int)((double)this.m_txtInclude.Width * 0.7);
			}
		}


		private void m_btnUserMsgMask_Click(object sender, EventArgs e)
		{
			RstdGuiSettings.Default.AllowOnlyUserMsgs = this.m_btnUserMsgMask.Checked;
		}


		private void m_ConsoleText_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.C && e.Control)
			{
				this.iHandleCopy();
				e.SuppressKeyPress = true;
			}
		}


		private TEXT_COLOR_T iGetTextColor(string color)
		{
			string text = color.ToUpper();
			uint num = PrivateImplementationDetails.ComputeStringHash(text);
			if (num <= 1406051114U)
			{
				if (num <= 1342486232U)
				{
					if (num != 1339926376U)
					{
						if (num == 1342486232U)
						{
							if (text == "R}")
							{
								return TEXT_COLOR_T.Red;
							}
						}
					}
					else if (text == "B}")
					{
						return TEXT_COLOR_T.Blue;
					}
				}
				else if (num != 1343324875U)
				{
					if (num == 1406051114U)
					{
						if (text == "D}")
						{
							return TEXT_COLOR_T.DarkGoldenrod;
						}
					}
				}
				else if (text == "Y}")
				{
					return TEXT_COLOR_T.Yellow;
				}
			}
			else if (num <= 1407478137U)
			{
				if (num != 1406198209U)
				{
					if (num == 1407478137U)
					{
						if (text == "O}")
						{
							return TEXT_COLOR_T.Orange;
						}
					}
				}
				else if (text == "G}")
				{
					return TEXT_COLOR_T.Green;
				}
			}
			else if (num != 1408169685U)
			{
				if (num == 1409302518U)
				{
					if (text == "P}")
					{
						return TEXT_COLOR_T.Purple;
					}
				}
			}
			else if (text == "K}")
			{
				return TEXT_COLOR_T.Black;
			}
			return TEXT_COLOR_T.Error;
		}


		private TEXT_COLOR_T iGetTextColor(uint text_color)
		{
			switch (text_color)
			{
			case 0U:
				return TEXT_COLOR_T.WindowText;
			case 1U:
				return TEXT_COLOR_T.Red;
			case 2U:
				return TEXT_COLOR_T.DarkGoldenrod;
			case 3U:
				return TEXT_COLOR_T.Blue;
			case 4U:
				return TEXT_COLOR_T.Green;
			case 5U:
				return TEXT_COLOR_T.Black;
			case 6U:
				return TEXT_COLOR_T.Yellow;
			case 7U:
				return TEXT_COLOR_T.Orange;
			case 8U:
				return TEXT_COLOR_T.Purple;
			default:
				return TEXT_COLOR_T.WindowText;
			}
		}


		public void AppendText(string text, uint text_color, bool is_user_msg, bool must_print)
		{
			string text2 = "";
			TEXT_COLOR_T color = this.iGetTextColor(text_color);
			TEXT_COLOR_LENGTH[] array2;
			if (text.Contains("{"))
			{
				string[] array = text.Split(new char[]
				{
					'{'
				});
				int num = array.Length;
				array2 = new TEXT_COLOR_LENGTH[num];
				for (int i = 0; i < num; i++)
				{
					array2[i] = default(TEXT_COLOR_LENGTH);
					if (i == 0)
					{
						array2[i].color = color;
						array2[i].length = array[i].Length;
						text2 += array[i];
					}
					else if (array[i].Length == 0)
					{
						array2[i].color = array2[i - 1].color;
						array2[i].length = 1;
						text2 += "{";
					}
					else
					{
						if (array[i].Length > 1)
						{
							array2[i].color = this.iGetTextColor(array[i][0].ToString() + array[i][1].ToString());
						}
						else
						{
							array2[i].color = TEXT_COLOR_T.Error;
						}
						if (array2[i].color == TEXT_COLOR_T.Error)
						{
							array2[i].color = array2[i - 1].color;
							array2[i].length = array[i].Length + 1;
							text2 = text2 + "{" + array[i];
						}
						else
						{
							string text3 = array[i].Substring(2);
							array2[i].length = text3.Length;
							text2 += text3;
						}
					}
				}
			}
			else
			{
				text2 = text;
				array2 = new TEXT_COLOR_LENGTH[1];
				array2[0].color = color;
				array2[0].length = text.Length;
			}
			if (must_print || this.ibTextPassesMask(text, is_user_msg))
			{
				int length = text2.Length;
				if ((long)(this.m_Position + length) > 1048576L)
				{
					this.ClearOutput();
					this.m_ConsoleText.AppendText("--- Auto-clean of console text in order to save memory ---\n--- Worry not! the outputs still exist in the LogFile ---\n\n");
				}
				if (text2.Contains("\r"))
				{
					int num2 = this.m_ConsoleText.Lines.Length;
					if (num2 > 0)
					{
						int length2 = this.m_ConsoleText.Lines[num2 - 1].Length;
						if (length2 > 0)
						{
							this.m_ConsoleText.Select(this.m_Position - length2, length2);
							while (this.m_ConsoleText.SelectedText != this.m_ConsoleText.Lines[num2 - 1])
							{
								this.m_Position--;
								this.m_ConsoleText.Select(this.m_Position - length2, length2);
							}
							if (this.m_ConsoleText.ReadOnly)
							{
								this.m_ConsoleText.ReadOnly = false;
								this.m_ConsoleText.SelectedText = "";
								this.m_ConsoleText.ReadOnly = true;
							}
							else
							{
								this.m_ConsoleText.SelectedText = "";
							}
							this.m_Position -= length2;
						}
					}
					int startIndex = text2.IndexOf("\r", 0);
					text = text2.Remove(startIndex, 1);
					this.m_ConsoleText.AppendText(text);
				}
				else
				{
					this.m_ConsoleText.AppendText(text2);
				}
				for (int j = 0; j < array2.Length; j++)
				{
					this.m_Position += array2[j].length;
					this.m_ConsoleText.Select(this.m_Position - array2[j].length, array2[j].length);
					Font font = this.m_ConsoleText.Font;
					this.m_ConsoleText.SelectionFont = font;
					this.m_ConsoleText.SelectionColor = Color.FromName(array2[j].color.ToString());
					this.m_ConsoleText.DeselectAll();
				}
				if (RstdGuiSettings.Default.bAutoScrollOutput & !this.m_ConsoleText.Focused)
				{
					CoreImports.SendMessage(this.m_ConsoleText.Handle, 277, 7, IntPtr.Zero);
				}
			}
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


		private bool ibTextPassesMask(string text, bool is_user_message)
		{
			return this.ibTextPassesMask(text, this.m_MaskListExclude, false, is_user_message) && this.ibTextPassesMask(text, this.m_MaskListInclude, true, is_user_message);
		}


		private bool ibTextPassesMask(string text, string[] mask, bool isInclude, bool is_user_msg)
		{
			if (text.Contains("WARNING") || text.Contains("ERROR"))
			{
				return true;
			}
			if (RstdGuiSettings.Default.AllowOnlyUserMsgs && !is_user_msg)
			{
				return false;
			}
			if (mask != null)
			{
				for (int i = 0; i < mask.Length; i++)
				{
					if (this.ibMatchRegEx(text, mask[i]))
					{
						return isInclude;
					}
				}
				return !isInclude;
			}
			return true;
		}


		public bool ibMatchRegEx(string text, string pattern)
		{
			try
			{
				pattern = pattern.Trim();
				if (pattern.StartsWith("[") && !pattern.Contains("]"))
				{
					pattern = "\\" + pattern;
				}
				if (Regex.Match(text, pattern).Success)
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				GuiCore.RSTDMessage(RstdConstants.MESSAGE_TYPE.OK_INFORMATION, "Error filtering text:\n Error in Regular Expression:\r\n" + ex.Message, ex.StackTrace);
				this.m_txtExclude.Text = string.Empty;
				this.m_txtInclude.Text = string.Empty;
				return false;
			}
			return false;
		}


		public void ClearOutput()
		{
			this.m_ConsoleText.Clear();
			this.m_Position = 0;
		}


		private void iHandleCopy()
		{
			if (string.IsNullOrEmpty(this.m_ConsoleText.SelectedText))
			{
				return;
			}
			Clipboard.SetText(this.m_ConsoleText.SelectedText);
		}


		private const long m_MaxConsoleTxtLen = 1048576L;


		private frmMain m_MainForm;


		private string[] m_MaskListExclude;


		private string[] m_MaskListInclude;


		private int m_Position;
	}
}
