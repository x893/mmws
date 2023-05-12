using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	public partial class UpdateDialog : Form
	{

		public UpdateDialog()
		{
		}


		public UpdateDialog(List<XmlNode> nodes)
		{
			this.InitializeComponent();
			this.m_XmlNodes = nodes;
			base.SuspendLayout();
			this.m_ErrorProvider = new ErrorProvider();
			this.m_ErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
			this.m_IsValid = true;
			this.m_IsRealValid = true;
			this.m_IsImagValid = true;
			string[] array;
			if (nodes.Count == 1 && GuiCore.bGetVarOptions(this.m_XmlNodes[0], out array))
			{
				this.m_ctrlValue = new ComboBox();
				ComboBox.ObjectCollection items = ((ComboBox)this.m_ctrlValue).Items;
				object[] items2 = array;
				items.AddRange(items2);
				((ComboBox)this.m_ctrlValue).DropDownStyle = ComboBoxStyle.DropDownList;
			}
			else
			{
				this.m_ctrlValue = new TextBox();
			}
			this.m_var_type = this.m_XmlNodes[0].Attributes["type"].Value;
			this.m_VarNameLabel.Text = this.m_XmlNodes[0].Attributes["name"].Value;
			this.m_VarTypeLabel.Text = this.m_var_type;
			this.DrawDynamicUI();
			base.ResumeLayout(true);
			this.m_bHasValidValue = false;
			this.m_bIsTransmit = false;
			foreach (object obj in this.groupBox1.Controls)
			{
				Control control = (Control)obj;
				if (typeof(RadioButton) == control.GetType() && GuiCore.bIsDisplayTypeValidForType((DisplayType)Enum.Parse(typeof(DisplayType), ((RadioButton)control).Text, true), this.m_var_type))
				{
					((RadioButton)control).Enabled = true;
				}
			}
			this.SelectDefaultDisplayValue();
			if (GuiCore.bAreAllFunctionArgs(nodes))
			{
				this.m_AcceptTransmitBtn.Enabled = false;
			}
		}


		public virtual string GetValue()
		{
			if (this.m_var_type == "FIXCPLX" || this.m_var_type == "FIXCPLXPTR" || this.m_var_type == "FLOAT64COMPLEX" || this.m_var_type == "FLOAT64COMPLEXPTR")
			{
				return this.iGetCorrectValueByDisplayType(this.m_realTextBox.Text, this.m_imaginaryTextBox.Text);
			}
			return this.iGetCorrectValueByDisplayType(this.m_ctrlValue.Text);
		}



		public bool bIsTransmit
		{
			get
			{
				return this.m_bIsTransmit;
			}
		}


		public virtual bool bHasValidValue()
		{
			return this.m_bHasValidValue;
		}


		private void UpdateDialog_Load(object sender, EventArgs e)
		{
		}


		private void m_AcceptBtn_Click(object sender, EventArgs e)
		{
			if (this.m_var_type == "FIXCPLX" || this.m_var_type == "FIXCPLXPTR" || this.m_var_type == "FLOAT64COMPLEX" || this.m_var_type == "FLOAT64COMPLEXPTR")
			{
				this.iValidateCplx();
				return;
			}
			this.iValidate();
		}


		private void m_AcceptTransmitBtn_Click(object sender, EventArgs e)
		{
			if (this.m_var_type == "FIXCPLX" || this.m_var_type == "FIXCPLXPTR" || this.m_var_type == "FLOAT64COMPLEX" || this.m_var_type == "FLOAT64COMPLEXPTR")
			{
				this.iValidateCplx();
			}
			else
			{
				this.iValidate();
			}
			this.m_bIsTransmit = true;
		}


		private void rdioButton_CheckedChanged(object sender, EventArgs e)
		{
			DisplayType displayType = (DisplayType)Enum.Parse(typeof(DisplayType), ((RadioButton)sender).Text, true);
			if (((RadioButton)sender).Checked)
			{
				string value = "";
				string text = "";
				string text2 = "";
				NodeType nodeType = GuiCore.GetNodeType(this.m_XmlNodes[0]);
				if (displayType == DisplayType.DEFAULT)
				{
					this.m_SelectedDisplayType = GuiCore.GetDefaultDispalyType(nodeType);
				}
				else
				{
					this.m_SelectedDisplayType = displayType;
				}
				if (!(this.m_var_type == "FIXCPLX") && !(this.m_var_type == "FLOAT64COMPLEX") && !(this.m_var_type == "FIXCPLXPTR") && !(this.m_var_type == "FLOAT64COMPLEXPTR"))
				{
					value = this.m_ctrlValue.Text;
					GuiCore.bGetNumericValueToSet(this.m_XmlNodes[0], this.m_PreviousDisplayType, ref value, true);
					this.m_ctrlValue.Text = this.GetDefaultVal(displayType, value);
					return;
				}
				text = this.m_realTextBox.Text;
				text2 = this.m_imaginaryTextBox.Text;
				if (text != "" && text2 != "")
				{
					GuiCore.bGetNumericValueToSet(this.m_XmlNodes[0], this.m_PreviousDisplayType, ref text, true);
					GuiCore.bGetNumericValueToSet(this.m_XmlNodes[0], this.m_PreviousDisplayType, ref text2, true);
					value = string.Concat(new string[]
					{
						"(",
						text,
						",",
						text2,
						")"
					});
					this.m_realTextBox.Text = GuiCore.GetDisplayedValueSegment(this.m_XmlNodes[0], displayType, text);
					this.m_imaginaryTextBox.Text = GuiCore.GetDisplayedValueSegment(this.m_XmlNodes[0], displayType, text2);
					return;
				}
			}
			else
			{
				this.m_PreviousDisplayType = displayType;
			}
		}


		private void ctrlValue_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && this.m_IsValid)
			{
				this.iValidate();
				base.DialogResult = DialogResult.OK;
			}
		}


		private void m_imaginaryTextBox_TextChanged(object sender, EventArgs e)
		{
			this.m_IsImagValid = this.iValidate(this.m_imaginaryTextBox);
			if (!this.m_IsRealValid || !this.m_IsImagValid)
			{
				this.m_AcceptBtn.Enabled = false;
				this.m_AcceptTransmitBtn.Enabled = false;
				return;
			}
			this.m_AcceptBtn.Enabled = true;
			this.m_AcceptTransmitBtn.Enabled = true;
		}


		private void m_realTextBox_TextChanged(object sender, EventArgs e)
		{
			this.m_IsRealValid = this.iValidate(this.m_realTextBox);
			if (!this.m_IsRealValid || !this.m_IsImagValid)
			{
				this.m_AcceptBtn.Enabled = false;
				this.m_AcceptTransmitBtn.Enabled = false;
				return;
			}
			this.m_AcceptBtn.Enabled = true;
			this.m_AcceptTransmitBtn.Enabled = true;
		}


		private void m_ctrlValue_TextChanged(object sender, EventArgs e)
		{
			this.m_IsValid = this.iValidate(this.m_ctrlValue);
			if (!this.m_IsValid)
			{
				this.m_AcceptBtn.Enabled = false;
				this.m_AcceptTransmitBtn.Enabled = false;
				return;
			}
			this.m_AcceptBtn.Enabled = true;
			this.m_AcceptTransmitBtn.Enabled = true;
		}


		private void UpdateDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.DialogResult = DialogResult.Cancel;
			}
		}


		private void DrawDynamicUI()
		{
			if (this.m_var_type == "FIXCPLX" || this.m_var_type == "FIXCPLXPTR" || this.m_var_type == "FLOAT64COMPLEX" || this.m_var_type == "FLOAT64COMPLEXPTR")
			{
				this.tableLayoutPanel3.Visible = true;
				this.tableLayoutPanel4.Visible = true;
				this.m_realTextBox = new TextBox();
				this.m_realTextBox.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
				this.m_realTextBox.Name = "realTextBox";
				this.m_realTextBox.TabIndex = 0;
				this.m_realTextBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
				this.m_realTextBox.Dock = DockStyle.Fill;
				this.m_realTextBox.TextChanged += this.m_realTextBox_TextChanged;
				this.tableLayoutPanel3.Controls.Add(this.m_realTextBox, 2, 0);
				this.label1.Text = "Real =";
				this.m_imaginaryTextBox = new TextBox();
				this.m_imaginaryTextBox.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
				this.m_imaginaryTextBox.Name = "imaginaryTextBox";
				this.m_imaginaryTextBox.TabIndex = 1;
				this.m_imaginaryTextBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
				this.m_imaginaryTextBox.Dock = DockStyle.Fill;
				this.m_imaginaryTextBox.TextChanged += this.m_imaginaryTextBox_TextChanged;
				Label label = new Label();
				label.Font = new Font("Arial", 9.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
				label.Name = "label2";
				label.Anchor = AnchorStyles.Left;
				label.AutoSize = true;
				label.ForeColor = SystemColors.ControlText;
				label.Text = "Imag =";
				this.tableLayoutPanel4.Controls.Add(label, 1, 0);
				this.tableLayoutPanel4.Controls.Add(this.m_imaginaryTextBox, 2, 0);
				string[] cplxValues = this.GetCplxValues(this.GetDefaultVal(DisplayType.DEFAULT));
				if (cplxValues.Length == 2)
				{
					this.m_realTextBox.Text = cplxValues[0];
					this.m_imaginaryTextBox.Text = cplxValues[1];
					return;
				}
			}
			else
			{
				this.tableLayoutPanel3.Visible = true;
				this.m_ctrlValue.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
				this.m_ctrlValue.Location = new Point(13, 75);
				this.m_ctrlValue.Name = "m_ctrlValue";
				this.m_ctrlValue.Size = new Size(base.Size.Width - this.m_ctrlValue.Location.X - 20, 22);
				this.m_ctrlValue.TabIndex = 0;
				this.m_ctrlValue.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
				this.m_ctrlValue.KeyDown += this.ctrlValue_KeyDown;
				this.tableLayoutPanel3.Controls.Add(this.m_ctrlValue, 2, 0);
				this.m_ctrlValue.Text = this.GetDefaultVal(DisplayType.DEFAULT);
				this.m_ctrlValue.TextChanged += this.m_ctrlValue_TextChanged;
			}
		}


		private string iGetCorrectValueByDisplayType(string value)
		{
			switch (this.m_SelectedDisplayType)
			{
			case DisplayType.HEX:
				if (!value.StartsWith("0x"))
				{
					value = value.Insert(0, "0x");
				}
				break;
			case DisplayType.BINARY:
				if (!value.StartsWith("0b"))
				{
					value = value.Insert(0, "0b");
				}
				break;
			case DisplayType.DB10:
			case DisplayType.DB20:
				if (!value.EndsWith("[db]"))
				{
					value += "[db]";
				}
				break;
			}
			return value;
		}


		private string iGetCorrectValueByDisplayType(string real, string imaginary)
		{
			switch (this.m_SelectedDisplayType)
			{
			case DisplayType.HEX:
				if (!real.StartsWith("0x"))
				{
					real = real.Insert(0, "0x");
				}
				if (!imaginary.StartsWith("0x"))
				{
					imaginary = imaginary.Insert(0, "0x");
				}
				break;
			case DisplayType.BINARY:
				if (!real.StartsWith("0b"))
				{
					real = real.Insert(0, "0b");
				}
				if (!imaginary.StartsWith("0b"))
				{
					imaginary = imaginary.Insert(0, "0b");
				}
				break;
			case DisplayType.DB10:
			case DisplayType.DB20:
				if (!real.EndsWith("[db]"))
				{
					real += "[db]";
				}
				if (!imaginary.EndsWith("[db]"))
				{
					imaginary += "[db]";
				}
				break;
			}
			return real + "," + imaginary;
		}


		private void SelectDefaultDisplayValue()
		{
			switch ((DisplayType)Enum.Parse(typeof(DisplayType), this.m_XmlNodes[0].Attributes["display_type"].Value, true))
			{
			case DisplayType.DEFAULT:
				this.defaultRadioButton.Checked = true;
				return;
			case DisplayType.DECIMAL:
				this.decimalRadioButton.Checked = true;
				return;
			case DisplayType.DECIMAL_SIGNED:
				this.decimalSignedRadioButton.Checked = true;
				return;
			case DisplayType.INTEGER:
				this.intRadioButton.Checked = true;
				return;
			case DisplayType.HEX:
				this.HexRadioButton.Checked = true;
				return;
			case DisplayType.BINARY:
				this.binRadioButton.Checked = true;
				return;
			case DisplayType.DB10:
				this.db10RadioButton.Checked = true;
				return;
			case DisplayType.DB20:
				this.db20RadioButton.Checked = true;
				return;
			default:
				return;
			}
		}


		private string[] GetCplxValues(string val)
		{
			if (val != null)
			{
				val = val.Trim(new char[]
				{
					'(',
					')'
				});
			}
			return val.Split(new char[]
			{
				','
			});
		}


		protected string GetDefaultVal()
		{
			if (1 == this.m_XmlNodes.Count)
			{
				return GuiCore.GetDisplayedValue(this.m_XmlNodes[0]);
			}
			return "";
		}


		protected string GetDefaultVal(DisplayType displayType)
		{
			if (1 == this.m_XmlNodes.Count)
			{
				return GuiCore.GetDisplayedValue(this.m_XmlNodes[0], displayType);
			}
			return "";
		}


		protected string GetDefaultVal(DisplayType displayType, string value)
		{
			if (1 == this.m_XmlNodes.Count)
			{
				return GuiCore.GetDisplayedValue(this.m_XmlNodes[0], displayType, value);
			}
			return "";
		}


		private void iValidate()
		{
			if (this.m_ctrlValue.Text.Equals("") && !this.ibAreAllStrings())
			{
				this.m_bHasValidValue = false;
				return;
			}
			this.m_bHasValidValue = true;
		}


		private void iValidateCplx()
		{
			if (this.m_realTextBox.Text.Equals("") && this.m_imaginaryTextBox.Text.Equals("") && !this.ibAreAllStrings())
			{
				this.m_bHasValidValue = false;
				return;
			}
			this.m_bHasValidValue = true;
		}


		private bool ibAreAllStrings()
		{
			bool flag = true;
			int num = 0;
			while (num < this.m_XmlNodes.Count && flag)
			{
				string value = this.m_XmlNodes[num].Attributes["type"].Value;
				flag = (value == "STRING" || value == "PATH" || value == "FILE");
				num++;
			}
			return flag;
		}


		private bool iValidateByDisplayType(string text, DisplayType disp_type, out string err_msg)
		{
			err_msg = "";
			switch (disp_type)
			{
			case DisplayType.DEFAULT:
			case DisplayType.DECIMAL:
			case DisplayType.DECIMAL_SIGNED:
				return false;
			case DisplayType.INTEGER:
			{
				int num;
				return int.TryParse(text, out num);
			}
			case DisplayType.HEX:
				return Regex.IsMatch(text, "\\A\\b(0[x])?[0-9a-fA-F]+\\b\\Z");
			case DisplayType.BINARY:
				return Regex.IsMatch(text, "\\A\\b(0[b])?[01]+\\b\\Z");
			case DisplayType.DB10:
			case DisplayType.DB20:
				return Regex.IsMatch(text, "^[-+]?\\d*(\\.\\d+)?\\[db\\]$");
			default:
				err_msg = "You have entered a wrong format value";
				return false;
			}
		}


		private bool iValidateInt(string type, string text, out string err_msg)
		{
			bool flag = true;
			uint num = PrivateImplementationDetails.ComputeStringHash(type);
			if (num <= 1517748251U)
			{
				if (num <= 200059396U)
				{
					if (num <= 72344531U)
					{
						if (num != 71211698U)
						{
							if (num != 72344531U)
							{
								goto IL_29E;
							}
							if (!(type == "UINT64"))
							{
								goto IL_29E;
							}
							goto IL_295;
						}
						else
						{
							if (!(type == "UINT16"))
							{
								goto IL_29E;
							}
							goto IL_27F;
						}
					}
					else if (num != 167029943U)
					{
						if (num != 200059396U)
						{
							goto IL_29E;
						}
						if (!(type == "INT64"))
						{
							goto IL_29E;
						}
					}
					else
					{
						if (!(type == "UINT8PTR"))
						{
							goto IL_29E;
						}
						goto IL_274;
					}
				}
				else if (num <= 324270942U)
				{
					if (num != 268302705U)
					{
						if (num != 324270942U)
						{
							goto IL_29E;
						}
						if (!(type == "INT64PTR"))
						{
							goto IL_29E;
						}
					}
					else
					{
						if (!(type == "INT16"))
						{
							goto IL_29E;
						}
						goto IL_253;
					}
				}
				else if (num != 665806367U)
				{
					if (num != 1517748251U)
					{
						goto IL_29E;
					}
					if (!(type == "UINT8"))
					{
						goto IL_29E;
					}
					goto IL_274;
				}
				else
				{
					if (!(type == "UINT64PTR"))
					{
						goto IL_29E;
					}
					goto IL_295;
				}
				long num2;
				flag = long.TryParse(text, out num2);
				goto IL_29E;
				IL_274:
				byte b;
				flag = byte.TryParse(text, out b);
				goto IL_29E;
				IL_295:
				ulong num3;
				flag = ulong.TryParse(text, out num3);
				goto IL_29E;
			}
			if (num <= 2676191253U)
			{
				if (num <= 2214109151U)
				{
					if (num != 2179202354U)
					{
						if (num != 2214109151U)
						{
							goto IL_29E;
						}
						if (!(type == "INT32"))
						{
							goto IL_29E;
						}
						goto IL_25E;
					}
					else if (!(type == "INT8"))
					{
						goto IL_29E;
					}
				}
				else if (num != 2286151596U)
				{
					if (num != 2676191253U)
					{
						goto IL_29E;
					}
					if (!(type == "INT16PTR"))
					{
						goto IL_29E;
					}
					goto IL_253;
				}
				else
				{
					if (!(type == "UINT32"))
					{
						goto IL_29E;
					}
					goto IL_28A;
				}
			}
			else if (num <= 3481363276U)
			{
				if (num != 3052385782U)
				{
					if (num != 3481363276U)
					{
						goto IL_29E;
					}
					if (!(type == "INT8PTR"))
					{
						goto IL_29E;
					}
				}
				else
				{
					if (!(type == "UINT32PTR"))
					{
						goto IL_29E;
					}
					goto IL_28A;
				}
			}
			else if (num != 3561912123U)
			{
				if (num != 3710781388U)
				{
					goto IL_29E;
				}
				if (!(type == "UINT16PTR"))
				{
					goto IL_29E;
				}
				goto IL_27F;
			}
			else
			{
				if (!(type == "INT32PTR"))
				{
					goto IL_29E;
				}
				goto IL_25E;
			}
			sbyte b2;
			flag = sbyte.TryParse(text, out b2);
			goto IL_29E;
			IL_25E:
			int num4;
			flag = int.TryParse(text, out num4);
			goto IL_29E;
			IL_28A:
			uint num5;
			flag = uint.TryParse(text, out num5);
			goto IL_29E;
			IL_253:
			short num6;
			flag = short.TryParse(text, out num6);
			goto IL_29E;
			IL_27F:
			ushort num7;
			flag = ushort.TryParse(text, out num7);
			IL_29E:
			if (!flag)
			{
				err_msg = "You have entered a wrong value";
			}
			else
			{
				err_msg = "";
			}
			return flag;
		}


		private bool iValidateFloatingPoint(string type, string text, out string err_msg)
		{
			bool flag = true;
			uint num = PrivateImplementationDetails.ComputeStringHash(type);
			if (num <= 2001733715U)
			{
				if (num <= 1415045173U)
				{
					if (num != 1212580912U)
					{
						if (num != 1414029642U)
						{
							if (num != 1415045173U)
							{
								goto IL_190;
							}
							if (!(type == "FLOAT80"))
							{
								goto IL_190;
							}
							goto IL_187;
						}
						else if (!(type == "FLOAT32PTR"))
						{
							goto IL_190;
						}
					}
					else if (!(type == "FLOAT32"))
					{
						goto IL_190;
					}
					float num2;
					flag = float.TryParse(text, out num2);
					goto IL_190;
				}
				if (num != 1450498067U)
				{
					if (num != 1758621869U)
					{
						if (num != 2001733715U)
						{
							goto IL_190;
						}
						if (!(type == "FIXVALPTR"))
						{
							goto IL_190;
						}
					}
					else if (!(type == "FLOAT64COMPLEX"))
					{
						goto IL_190;
					}
				}
				else if (!(type == "FLOAT64PTR"))
				{
					goto IL_190;
				}
			}
			else if (num <= 3211190303U)
			{
				if (num != 2149926011U)
				{
					if (num != 3178552161U)
					{
						if (num != 3211190303U)
						{
							goto IL_190;
						}
						if (!(type == "FIXCPLX"))
						{
							goto IL_190;
						}
					}
					else if (!(type == "FLOAT64COMPLEXPTR"))
					{
						goto IL_190;
					}
				}
				else if (!(type == "FIXCPLXPTR"))
				{
					goto IL_190;
				}
			}
			else if (num != 3695124071U)
			{
				if (num != 4052975833U)
				{
					if (num != 4122909080U)
					{
						goto IL_190;
					}
					if (!(type == "FIX"))
					{
						goto IL_190;
					}
				}
				else if (!(type == "FLOAT80PTR"))
				{
					goto IL_190;
				}
			}
			else if (!(type == "FLOAT64"))
			{
				goto IL_190;
			}
			IL_187:
			double num3;
			flag = double.TryParse(text, out num3);
			IL_190:
			if (!flag)
			{
				err_msg = "You have entered a wrong value";
			}
			else
			{
				err_msg = "";
			}
			return flag;
		}


		private bool iValidate(Control control)
		{
			string value = "";
			bool result = true;
			string text = control.Text;
			if (control is TextBox)
			{
				string var_type = this.m_var_type;
				uint num = PrivateImplementationDetails.ComputeStringHash(var_type);
				if (num <= 2149926011U)
				{
					if (num <= 1212580912U)
					{
						if (num <= 200059396U)
						{
							if (num <= 72344531U)
							{
								if (num != 71211698U)
								{
									if (num != 72344531U)
									{
										goto IL_616;
									}
									if (!(var_type == "UINT64"))
									{
										goto IL_616;
									}
									goto IL_5B8;
								}
								else
								{
									if (!(var_type == "UINT16"))
									{
										goto IL_616;
									}
									goto IL_5B8;
								}
							}
							else if (num != 167029943U)
							{
								if (num != 200059396U)
								{
									goto IL_616;
								}
								if (!(var_type == "INT64"))
								{
									goto IL_616;
								}
								goto IL_5B8;
							}
							else
							{
								if (!(var_type == "UINT8PTR"))
								{
									goto IL_616;
								}
								goto IL_5B8;
							}
						}
						else if (num <= 324270942U)
						{
							if (num != 268302705U)
							{
								if (num != 324270942U)
								{
									goto IL_616;
								}
								if (!(var_type == "INT64PTR"))
								{
									goto IL_616;
								}
								goto IL_5B8;
							}
							else
							{
								if (!(var_type == "INT16"))
								{
									goto IL_616;
								}
								goto IL_5B8;
							}
						}
						else if (num != 665806367U)
						{
							if (num != 1212580912U)
							{
								goto IL_616;
							}
							if (!(var_type == "FLOAT32"))
							{
								goto IL_616;
							}
							goto IL_5E8;
						}
						else
						{
							if (!(var_type == "UINT64PTR"))
							{
								goto IL_616;
							}
							goto IL_5B8;
						}
					}
					else if (num <= 1450498067U)
					{
						if (num <= 1414029642U)
						{
							if (num != 1371739963U)
							{
								if (num != 1414029642U)
								{
									goto IL_616;
								}
								if (!(var_type == "FLOAT32PTR"))
								{
									goto IL_616;
								}
								goto IL_5E8;
							}
							else
							{
								if (!(var_type == "BOOL8PTR"))
								{
									goto IL_616;
								}
								goto IL_5A6;
							}
						}
						else if (num != 1415045173U)
						{
							if (num != 1450498067U)
							{
								goto IL_616;
							}
							if (!(var_type == "FLOAT64PTR"))
							{
								goto IL_616;
							}
							goto IL_5E8;
						}
						else
						{
							if (!(var_type == "FLOAT80"))
							{
								goto IL_616;
							}
							goto IL_5E8;
						}
					}
					else if (num <= 1758621869U)
					{
						if (num != 1517748251U)
						{
							if (num != 1758621869U)
							{
								goto IL_616;
							}
							if (!(var_type == "FLOAT64COMPLEX"))
							{
								goto IL_616;
							}
							goto IL_5E8;
						}
						else
						{
							if (!(var_type == "UINT8"))
							{
								goto IL_616;
							}
							goto IL_5B8;
						}
					}
					else if (num != 1839435638U)
					{
						if (num != 2001733715U)
						{
							if (num != 2149926011U)
							{
								goto IL_616;
							}
							if (!(var_type == "FIXCPLXPTR"))
							{
								goto IL_616;
							}
							goto IL_5E8;
						}
						else
						{
							if (!(var_type == "FIXVALPTR"))
							{
								goto IL_616;
							}
							goto IL_5E8;
						}
					}
					else if (!(var_type == "PATH"))
					{
						goto IL_616;
					}
				}
				else
				{
					if (num <= 3067248607U)
					{
						if (num <= 2297176337U)
						{
							if (num <= 2214109151U)
							{
								if (num != 2179202354U)
								{
									if (num != 2214109151U)
									{
										goto IL_616;
									}
									if (!(var_type == "INT32"))
									{
										goto IL_616;
									}
									goto IL_5B8;
								}
								else
								{
									if (!(var_type == "INT8"))
									{
										goto IL_616;
									}
									goto IL_5B8;
								}
							}
							else if (num != 2286151596U)
							{
								if (num != 2297176337U)
								{
									goto IL_616;
								}
								if (!(var_type == "CHARPTR"))
								{
									goto IL_616;
								}
							}
							else
							{
								if (!(var_type == "UINT32"))
								{
									goto IL_616;
								}
								goto IL_5B8;
							}
						}
						else if (num <= 2778687069U)
						{
							if (num != 2676191253U)
							{
								if (num != 2778687069U)
								{
									goto IL_616;
								}
								if (!(var_type == "CHAR"))
								{
									goto IL_616;
								}
							}
							else
							{
								if (!(var_type == "INT16PTR"))
								{
									goto IL_616;
								}
								goto IL_5B8;
							}
						}
						else if (num != 2822617731U)
						{
							if (num != 3052385782U)
							{
								if (num != 3067248607U)
								{
									goto IL_616;
								}
								if (!(var_type == "BOOL8"))
								{
									goto IL_616;
								}
								goto IL_5A6;
							}
							else
							{
								if (!(var_type == "UINT32PTR"))
								{
									goto IL_616;
								}
								goto IL_5B8;
							}
						}
						else
						{
							if (!(var_type == "FILE"))
							{
								goto IL_616;
							}
							goto IL_596;
						}
						result = GuiCore.ValidateChar(control.Text, out value);
						goto IL_616;
					}
					if (num <= 3561912123U)
					{
						if (num <= 3211190303U)
						{
							if (num != 3178552161U)
							{
								if (num != 3211190303U)
								{
									goto IL_616;
								}
								if (!(var_type == "FIXCPLX"))
								{
									goto IL_616;
								}
								goto IL_5E8;
							}
							else
							{
								if (!(var_type == "FLOAT64COMPLEXPTR"))
								{
									goto IL_616;
								}
								goto IL_5E8;
							}
						}
						else if (num != 3481363276U)
						{
							if (num != 3561912123U)
							{
								goto IL_616;
							}
							if (!(var_type == "INT32PTR"))
							{
								goto IL_616;
							}
							goto IL_5B8;
						}
						else
						{
							if (!(var_type == "INT8PTR"))
							{
								goto IL_616;
							}
							goto IL_5B8;
						}
					}
					else if (num <= 3710781388U)
					{
						if (num != 3695124071U)
						{
							if (num != 3710781388U)
							{
								goto IL_616;
							}
							if (!(var_type == "UINT16PTR"))
							{
								goto IL_616;
							}
							goto IL_5B8;
						}
						else
						{
							if (!(var_type == "FLOAT64"))
							{
								goto IL_616;
							}
							goto IL_5E8;
						}
					}
					else if (num != 4052975833U)
					{
						if (num != 4122909080U)
						{
							if (num != 4127814520U)
							{
								goto IL_616;
							}
							if (!(var_type == "STRING"))
							{
								goto IL_616;
							}
						}
						else
						{
							if (!(var_type == "FIX"))
							{
								goto IL_616;
							}
							goto IL_5E8;
						}
					}
					else
					{
						if (!(var_type == "FLOAT80PTR"))
						{
							goto IL_616;
						}
						goto IL_5E8;
					}
				}
				IL_596:
				result = GuiCore.ValidateString(control.Text, out value);
				goto IL_616;
				IL_5A6:
				result = GuiCore.ValidateBool(control.Text, out text, out value);
				goto IL_616;
				IL_5B8:
				result = (this.iValidateByDisplayType(control.Text, this.m_SelectedDisplayType, out value) || this.iValidateInt(this.m_var_type, control.Text, out value));
				goto IL_616;
				IL_5E8:
				result = (this.iValidateByDisplayType(control.Text, this.m_SelectedDisplayType, out value) || this.iValidateFloatingPoint(this.m_var_type, control.Text, out value));
			}
			IL_616:
			this.m_ErrorProvider.SetError(control, value);
			return result;
		}


		private bool m_bHasValidValue;


		protected bool m_bIsTransmit;


		protected List<XmlNode> m_XmlNodes;


		private Control m_ctrlValue;


		private string m_var_type;


		private TextBox m_realTextBox;


		private TextBox m_imaginaryTextBox;


		private DisplayType m_PreviousDisplayType;


		private DisplayType m_SelectedDisplayType;


		private ErrorProvider m_ErrorProvider;


		private bool m_IsValid;


		private bool m_IsRealValid;


		private bool m_IsImagValid;
	}
}
