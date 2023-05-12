using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LuaRegister;
using RSTD.Properties;

namespace RSTD
{

	public partial class frmUserButtonConfig : Form
	{



		internal UserButtonInfo UserButtonInfo
		{
			get
			{
				return this.m_UserButtonInfo;
			}
			set
			{
				this.m_UserButtonInfo = value;
			}
		}


		public frmUserButtonConfig(int tool_strip_idx)
		{
			this.iInitForm();
			this.m_ToolStripIndex = tool_strip_idx;
			this.m_UserButtonInfo = new UserButtonInfo();
			this.m_UserButtonInfo.Show = true;
		}


		public frmUserButtonConfig(UserButtonInfo user_btn, int tool_strip_idx)
		{
			this.iInitForm();
			this.m_ToolStripIndex = tool_strip_idx;
			this.m_UserButtonInfo = user_btn;
			this.m_UserButtonInfo.Params = user_btn.Params;
		}


		private void iInitForm()
		{
			this.InitializeComponent();
			ToolTip toolTip = new ToolTip();
			toolTip.SetToolTip(this.btnOpenFileDialog, "Open existing script file");
			toolTip.SetToolTip(this.btnNewFileDialog, "New script file");
			toolTip.SetToolTip(this.colorPictureBox, "Background Color\n(Click on the image to set Transparent background)");
			toolTip.SetToolTip(this.iconButton, "Button Icon\n(Click on the image to set no icon)");
		}


		private void btnOpenFileDialog_Click(object sender, EventArgs e)
		{
			string text = GuiCore.OpenFileDialog(null, FileType.SCRIPT);
			if (!string.IsNullOrEmpty(text))
			{
				this.txtScriptLocation.Text = text;
			}
		}


		private void btnNewFileDialog_Click(object sender, EventArgs e)
		{
			string text = GuiCore.SaveFileDialog(null, FileType.SCRIPT);
			if (!string.IsNullOrEmpty(text))
			{
				new FileStream(text, FileMode.Create).Close();
				this.txtScriptLocation.Text = text;
			}
		}


		private void btnExecute_Click(object sender, EventArgs e)
		{
			this.iUpdateParamsFromGrid();
			switch (this.m_UserButtonInfo.SourceType)
			{
			case LuaSourceType.File:
				this.m_UserButtonInfo.UserButtonSource = this.txtScriptLocation.Text;
				break;
			case LuaSourceType.Function:
				this.m_UserButtonInfo.UserButtonSource = this.functionNameTextBox.Text;
				break;
			case LuaSourceType.LuaString:
				this.m_UserButtonInfo.UserButtonSource = this.inlineTextBox.Text;
				break;
			}
			GuiCore.MainForm.ExecuteUserButton(this.m_UserButtonInfo);
		}


		private void btnOK_Click(object sender, EventArgs e)
		{
			UserToolStripInfo userToolStripInfo = RstdGuiSettings.Default.UserToolStrips[this.m_ToolStripIndex];
			this.m_UserButtonInfo.Title = this.txtButtonTitle.Text;
			if (this.m_IsTransparent)
			{
				this.m_UserButtonInfo.UserColor = Color.Transparent;
			}
			else
			{
				this.m_UserButtonInfo.UserColor = this.colorButton.BackColor;
			}
			if (this.m_IsNoIcon)
			{
				this.m_UserButtonInfo.Icon = null;
				this.m_UserButtonInfo.IconFile = "";
			}
			else if (this.iconButton.Image != null)
			{
				this.m_UserButtonInfo.Icon = this.iconButton.Image;
				if (!userToolStripInfo.IsFileReadOnly())
				{
					RstdGuiSettings.Default.Save();
				}
			}
			string a = this.typeSelectComboBox.SelectedItem.ToString();
			if (!(a == "File"))
			{
				if (!(a == "Function"))
				{
					if (a == "Inline")
					{
						this.m_UserButtonInfo.UserButtonSource = this.inlineTextBox.Text;
						this.m_UserButtonInfo.SourceType = LuaSourceType.LuaString;
					}
				}
				else
				{
					this.m_UserButtonInfo.UserButtonSource = this.functionNameTextBox.Text;
					this.m_UserButtonInfo.FunctionSource = this.m_FunctionLocationTextBox.Text;
					this.m_UserButtonInfo.SourceType = LuaSourceType.Function;
				}
			}
			else
			{
				this.m_UserButtonInfo.SourceType = LuaSourceType.File;
				this.m_UserButtonInfo.UserButtonSource = this.txtScriptLocation.Text;
			}
			if (string.IsNullOrEmpty(this.m_UserButtonInfo.ToolTip))
			{
				this.m_UserButtonInfo.ToolTip = this.txtButtonTitle.Text;
			}
			this.iUpdateParamsFromGrid();
			base.DialogResult = DialogResult.OK;
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.m_UserButtonInfo.SourceType = this.lastSource;
			base.DialogResult = DialogResult.Cancel;
		}


		private void frmUserButtonConfig_Load(object sender, EventArgs e)
		{
			this.lastSource = this.m_UserButtonInfo.SourceType;
			if (this.m_UserButtonInfo.SourceType == LuaSourceType.Function)
			{
				this.typeSelectComboBox.SelectedItem = "Function";
				if (!string.IsNullOrEmpty(this.m_UserButtonInfo.UserButtonSource))
				{
					this.functionNameTextBox.Text = this.m_UserButtonInfo.UserButtonSource;
				}
				if (!string.IsNullOrEmpty(this.m_UserButtonInfo.FunctionSource))
				{
					this.m_FunctionLocationTextBox.Text = this.m_UserButtonInfo.FunctionSource;
				}
			}
			else if (this.m_UserButtonInfo.SourceType == LuaSourceType.LuaString)
			{
				this.typeSelectComboBox.SelectedItem = "Inline";
				if (!string.IsNullOrEmpty(this.m_UserButtonInfo.UserButtonSource))
				{
					this.inlineTextBox.Text = this.m_UserButtonInfo.UserButtonSource;
				}
			}
			else
			{
				this.typeSelectComboBox.SelectedItem = "File";
				if (!string.IsNullOrEmpty(this.m_UserButtonInfo.UserButtonSource))
				{
					this.txtScriptLocation.Text = this.m_UserButtonInfo.UserButtonSource;
				}
			}
			if (!string.IsNullOrEmpty(this.m_UserButtonInfo.Title))
			{
				this.txtButtonTitle.Text = this.m_UserButtonInfo.Title;
			}
			this.colorButton.BackColor = this.m_UserButtonInfo.UserColor;
			if (this.m_UserButtonInfo.Icon != null)
			{
				this.iconButton.Image = this.m_UserButtonInfo.Icon;
			}
			this.iUpdateGridFromParams();
			this.iCheckFileAccess();
		}


		private void TextBoxes_TextChanged(object sender, EventArgs e)
		{
			this.iEnableOkButton();
		}


		private void m_dgvScriptParams_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			this.m_dgvScriptParams.Rows[this.m_dgvScriptParams.Rows.Count - 1].Cells[this.colVarType.Index].Value = ScriptParamType.String.ToString();
			this.m_dgvScriptParams.Rows[this.m_dgvScriptParams.Rows.Count - 1].Cells[this.colVarName.Index].Value = "";
			this.m_dgvScriptParams.Rows[this.m_dgvScriptParams.Rows.Count - 1].Cells[this.colVarValue.Index].Value = "";
		}


		private void typeSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			string a = this.typeSelectComboBox.SelectedItem.ToString();
			if (!(a == "File"))
			{
				if (!(a == "Function"))
				{
					if (a == "Inline")
					{
						this.scriptLocationPanel.Visible = false;
						this.ParameterPanel.Visible = false;
						this.FunactionPanel.Visible = false;
						this.embeddedScriptPanel.Visible = true;
						this.m_UserButtonInfo.SourceType = LuaSourceType.LuaString;
					}
				}
				else
				{
					this.scriptLocationPanel.Visible = false;
					this.FunactionPanel.Visible = true;
					this.ParameterPanel.Visible = true;
					this.embeddedScriptPanel.Visible = false;
					this.m_UserButtonInfo.SourceType = LuaSourceType.Function;
				}
			}
			else
			{
				this.scriptLocationPanel.Visible = true;
				this.ParameterPanel.Visible = true;
				this.FunactionPanel.Visible = false;
				this.embeddedScriptPanel.Visible = false;
				this.m_UserButtonInfo.SourceType = LuaSourceType.File;
			}
			this.iEnableOkButton();
		}


		private void colorButton_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.FullOpen = true;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				this.colorButton.BackColor = colorDialog.Color;
			}
		}


		private void colorButton_MouseEnter(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Hand;
		}


		private void colorButton_MouseLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
		}


		private void iconButton_Click(object sender, EventArgs e)
		{
			Image imageFromFile = GuiCore.GetImageFromFile(GuiCore.OpenFileDialog(null, FileType.ICON));
			if (imageFromFile != null)
			{
				this.iconButton.Image = GuiCore.ResizeImage(imageFromFile, new Size(24, 24));
			}
		}


		private void iconButton_MouseEnter(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Hand;
		}


		private void iconButton_MouseLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
		}


		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (this.pictureBox1.Tag.ToString() == "Color")
			{
				this.pictureBox1.Image = Resources.image_gray_32;
				this.pictureBox1.Tag = "Gray";
				this.m_IsNoIcon = true;
				return;
			}
			this.pictureBox1.Image = Resources.image_32;
			this.pictureBox1.Tag = "Color";
			this.m_IsNoIcon = false;
		}


		private void colorPictureBox_Click(object sender, EventArgs e)
		{
			if (this.colorPictureBox.Tag.ToString() == "Color")
			{
				this.colorPictureBox.Image = Resources.color_palette_gray_36;
				this.colorPictureBox.Tag = "Gray";
				this.m_IsTransparent = true;
				return;
			}
			this.colorPictureBox.Image = Resources.color_palette_36;
			this.colorPictureBox.Tag = "Color";
			this.m_IsTransparent = false;
		}


		private void m_BrowseFunctionButton_Click(object sender, EventArgs e)
		{
			string text = GuiCore.OpenFileDialog(null, FileType.SCRIPT);
			if (!string.IsNullOrEmpty(text))
			{
				this.m_FunctionLocationTextBox.Text = text;
			}
		}


		private void iUpdateParamsFromGrid()
		{
			this.m_UserButtonInfo.Params.Clear();
			for (int i = 0; i < this.m_dgvScriptParams.Rows.Count - 1; i++)
			{
				DataGridViewRow dataGridViewRow = this.m_dgvScriptParams.Rows[i];
				ScriptParam scriptParam = new ScriptParam();
				if (dataGridViewRow.Cells[this.colVarType.Index].Value != null)
				{
					scriptParam.Type = (ScriptParamType)Enum.Parse(typeof(ScriptParamType), dataGridViewRow.Cells[this.colVarType.Index].Value.ToString());
				}
				else
				{
					scriptParam.Type = ScriptParamType.String;
				}
				if (dataGridViewRow.Cells[this.colVarName.Index].Value != null)
				{
					scriptParam.Name = (string)dataGridViewRow.Cells[this.colVarName.Index].Value;
				}
				else
				{
					scriptParam.Name = "";
				}
				if (dataGridViewRow.Cells[this.colVarValue.Index].Value != null)
				{
					if (scriptParam.Type == ScriptParamType.String)
					{
						scriptParam.Value = this.iFixStringValue((string)dataGridViewRow.Cells[this.colVarValue.Index].Value);
					}
					else
					{
						scriptParam.Value = (string)dataGridViewRow.Cells[this.colVarValue.Index].Value;
					}
				}
				else
				{
					scriptParam.Value = "";
				}
				this.m_UserButtonInfo.Params.Add(scriptParam);
			}
		}


		private string iFixStringValue(string value)
		{
			string str = value.Trim(new char[]
			{
				'"'
			});
			return "\"" + str + "\"";
		}


		private void iUpdateGridFromParams()
		{
			this.m_dgvScriptParams.Rows.Clear();
			if (this.m_UserButtonInfo.Params == null)
			{
				return;
			}
			foreach (ScriptParam param in this.m_UserButtonInfo.Params)
			{
				this.iAddParamToGrid(param);
			}
		}


		private void iAddParamToGrid(ScriptParam param)
		{
			this.m_dgvScriptParams.Rows.Add();
			this.m_dgvScriptParams.Rows[this.m_dgvScriptParams.Rows.Count - 2].Cells[this.colVarType.Index].Value = param.Type.ToString();
			this.m_dgvScriptParams.Rows[this.m_dgvScriptParams.Rows.Count - 2].Cells[this.colVarName.Index].Value = param.Name;
			this.m_dgvScriptParams.Rows[this.m_dgvScriptParams.Rows.Count - 2].Cells[this.colVarValue.Index].Value = param.Value;
		}


		private void iEnableOkButton()
		{
			bool flag = true;
			if (this.m_UserButtonInfo != null && this.m_UserButtonInfo.SourceType == LuaSourceType.File)
			{
				flag = this.iCheckScriptLocation();
			}
			string a = this.typeSelectComboBox.SelectedItem.ToString();
			if (a == "File")
			{
				this.btnOK.Enabled = (this.txtButtonTitle.Text != "" && this.txtScriptLocation.Text != "" && flag);
				return;
			}
			if (a == "Function")
			{
				this.btnOK.Enabled = (this.txtButtonTitle.Text != "" && this.functionNameTextBox.Text != "");
				return;
			}
			if (!(a == "Inline"))
			{
				return;
			}
			this.btnOK.Enabled = (this.txtButtonTitle.Text != "" && this.inlineTextBox.Text != "");
		}


		private bool iCheckScriptLocation()
		{
			if (File.Exists(this.txtScriptLocation.Text))
			{
				return true;
			}
			string clearCasePath = GuiCore.MainForm.RstdSettings.GetClearCasePath();
			return !string.IsNullOrEmpty(clearCasePath) && File.Exists(Path.Combine(clearCasePath, this.txtScriptLocation.Text.TrimStart(new char[]
			{
				'\\'
			})));
		}


		private void iCheckFileAccess()
		{
			UserToolStripInfo userToolStripInfo = RstdGuiSettings.Default.UserToolStrips[this.m_ToolStripIndex];
			bool flag = false;
			if (!string.IsNullOrEmpty(userToolStripInfo.ToolBarConfigFile) && File.Exists(userToolStripInfo.ToolBarConfigFile) && GuiCore.IsFileReadOnly(userToolStripInfo.ToolBarConfigFile))
			{
				flag = true;
			}
			this.btnOpenFileDialog.Enabled = !flag;
			this.btnNewFileDialog.Enabled = !flag;
			this.txtScriptLocation.ReadOnly = flag;
			this.colorButton.Enabled = !flag;
			this.iconButton.Enabled = !flag;
			this.pictureBox1.Enabled = !flag;
			this.colorPictureBox.Enabled = !flag;
			this.txtButtonTitle.ReadOnly = flag;
			this.functionNameTextBox.ReadOnly = flag;
			this.inlineTextBox.ReadOnly = flag;
			this.m_FunctionLocationTextBox.ReadOnly = flag;
			this.m_BrowseFunctionButton.Enabled = !flag;
			this.typeSelectComboBox.Enabled = !flag;
			this.functionNameTextBox.Enabled = !flag;
		}


		private UserButtonInfo m_UserButtonInfo;


		private LuaSourceType lastSource;


		private bool m_IsTransparent;


		private bool m_IsNoIcon;


		private int m_ToolStripIndex;
	}
}
