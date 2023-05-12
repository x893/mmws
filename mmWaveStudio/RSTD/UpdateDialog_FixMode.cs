using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	public partial class UpdateDialog_FixMode : UpdateDialog
	{

		public UpdateDialog_FixMode(List<XmlNode> nodes)
		{
			this.InitializeComponent();
			this.m_XmlNodes = nodes;
			this.m_ValueAsStr = base.GetDefaultVal();
			this.CheckBoxesEnablingEvent += this.iCheckBoxesEnabling;
			this.m_bIsTransmit = false;
			this.ibParseValueIntoControls();
		}


		public override string GetValue()
		{
			this.ibControlsIntoStrValue();
			return this.m_ValueAsStr;
		}


		public override bool bHasValidValue()
		{
			return this.ibValidateData();
		}


		private void UpdateDialog_Load(object sender, EventArgs e)
		{
			base.Location = Control.MousePosition;
		}


		private void m_AcceptTransmitBtn_Click(object sender, EventArgs e)
		{
			this.m_bIsTransmit = true;
		}


		private void iQNotationOrAttributesControlChanged(object sender, EventArgs e)
		{
			string text = this.m_QNotationTextBox.Text;
			this.ibParseQNotationAndAttributesControlsIntoStrValue(ref text);
			this.m_QNotationTextBox.Text = text;
		}


		private void iQNotationStringChanges(object sender, EventArgs e)
		{
			if (this.m_QNotationTextBox.Text.Length <= 1)
			{
				this.m_QIntegerTextBox.Text = string.Empty;
				this.m_QFractionTextBox.Text = string.Empty;
				this.m_OverflowComboBox.Text = string.Empty;
				this.m_QuantizationComboBox.Text = string.Empty;
				this.iDisabeAndUncheckCheckBoxes();
			}
		}


		private void iCheckBoxesEnabling(object sender, EventArgs e)
		{
			this.m_SignedCheckBox.Enabled = true;
			this.m_SymmetricalCheckBox.Enabled = true;
			this.m_FullPrecisionCheckBox.Enabled = true;
		}


		private bool ibParseValueIntoControls()
		{
			this.m_QNotationTextBox.Text = this.m_ValueAsStr;
			int num = this.m_ValueAsStr.IndexOf('(');
			int num2 = this.m_ValueAsStr.IndexOf('Q');
			int num3 = this.m_ValueAsStr.IndexOf(')');
			int num4 = this.m_ValueAsStr.IndexOf('.');
			if (-1 == num || -1 == num2 || -1 == num3 || -1 == num4 || num2 != num + 1 || num3 < num || num4 < num || num4 > num3)
			{
				this.iDisabeAndUncheckCheckBoxes();
				return false;
			}
			string text = this.iGetValueSubString_NoEdges(num, num4);
			string text2 = this.iGetValueSubString_NoEdges(num4, num3);
			if (-1 == text2.IndexOf('u'))
			{
				this.m_SignedCheckBox.Checked = true;
			}
			else
			{
				this.m_SignedCheckBox.Checked = false;
			}
			int num5;
			int num6;
			if (!int.TryParse(text.TrimStart(new char[]
			{
				'Q'
			}), out num5) || (!int.TryParse(text2.TrimEnd(new char[]
			{
				'u'
			}), out num6) && !int.TryParse(text2.TrimEnd(new char[]
			{
				's'
			}), out num6)))
			{
				return false;
			}
			this.m_QIntegerTextBox.Text = num5.ToString();
			this.m_QFractionTextBox.Text = num6.ToString();
			string text3 = this.iGetValueSubString(num3 + 1, this.m_ValueAsStr.Length - 1);
			if (4 != text3.Length || !this.ibParseQuantizationAttribChar(text3[0]) || !this.ibParseOverflowAttribChar(text3[1]) || !this.ibParseSymmetryAttribChar(text3[2]) || !this.ibParseFullPrecAttribChar(text3[3]))
			{
				return false;
			}
			this.CheckBoxesEnablingEvent(this, null);
			return true;
		}


		private bool ibParseQuantizationAttribChar(char quantAttribChar)
		{
			if (quantAttribChar != 'F')
			{
				switch (quantAttribChar)
				{
				case 'R':
					this.m_QuantizationComboBox.SelectedIndex = 1;
					return true;
				case 'T':
					this.m_QuantizationComboBox.SelectedIndex = 0;
					return true;
				case 'U':
					this.m_QuantizationComboBox.SelectedIndex = 3;
					return true;
				}
				return false;
			}
			this.m_QuantizationComboBox.SelectedIndex = 2;
			return true;
		}


		private bool ibParseOverflowAttribChar(char overflowAttribChar)
		{
			if (overflowAttribChar != 'C')
			{
				if (overflowAttribChar != 'E')
				{
					if (overflowAttribChar != 'W')
					{
						return false;
					}
					this.m_OverflowComboBox.SelectedIndex = 1;
				}
				else
				{
					this.m_OverflowComboBox.SelectedIndex = 0;
				}
			}
			else
			{
				this.m_OverflowComboBox.SelectedIndex = 2;
			}
			return true;
		}


		private bool ibParseSymmetryAttribChar(char symmetryAttribChar)
		{
			if (symmetryAttribChar != 'A')
			{
				if (symmetryAttribChar != 'S')
				{
					return false;
				}
				this.m_SymmetricalCheckBox.Checked = true;
			}
			else
			{
				this.m_SymmetricalCheckBox.Checked = false;
			}
			return true;
		}


		private bool ibParseFullPrecAttribChar(char fullPrecAttribChar)
		{
			if (fullPrecAttribChar != 'F')
			{
				if (fullPrecAttribChar != 'T')
				{
					return false;
				}
				this.m_FullPrecisionCheckBox.Checked = true;
			}
			else
			{
				this.m_FullPrecisionCheckBox.Checked = false;
			}
			return true;
		}


		private string iGetValueSubString(int startIndex, int endIndex)
		{
			return this.m_ValueAsStr.Substring(startIndex, endIndex - startIndex + 1);
		}


		private string iGetValueSubString_NoEdges(int startEdge, int endEdge)
		{
			return this.iGetValueSubString(startEdge + 1, endEdge - 1);
		}


		private bool ibValidateData()
		{
			int num;
			return (int.TryParse(this.m_QIntegerTextBox.Text, out num) && int.TryParse(this.m_QFractionTextBox.Text, out num) && this.m_QuantizationComboBox.Text != "" && this.m_OverflowComboBox.Text != "") || this.m_QNotationTextBox.Text != "";
		}


		private bool ibControlsIntoStrValue()
		{
			if (this.m_QNotationTextBox.Text != string.Empty)
			{
				this.m_ValueAsStr = this.m_QNotationTextBox.Text;
				return true;
			}
			string empty = string.Empty;
			this.ibParseQNotationAndAttributesControlsIntoStrValue(ref empty);
			if (string.Empty != empty)
			{
				this.m_ValueAsStr = empty;
				return true;
			}
			return false;
		}


		private bool ibParseQNotationAndAttributesControlsIntoStrValue(ref string str_value)
		{
			if (string.Empty == this.m_QIntegerTextBox.Text || string.Empty == this.m_QFractionTextBox.Text || string.Empty == this.m_QuantizationComboBox.Text || string.Empty == this.m_OverflowComboBox.Text)
			{
				if (string.Empty == this.m_QIntegerTextBox.Text && string.Empty == this.m_QFractionTextBox.Text && string.Empty == this.m_QuantizationComboBox.Text && string.Empty == this.m_OverflowComboBox.Text)
				{
					this.iDisabeAndUncheckCheckBoxes();
				}
				return false;
			}
			str_value = string.Format("(Q{0}.{1}", this.m_QIntegerTextBox.Text, this.m_QFractionTextBox.Text);
			if (this.m_SignedCheckBox.Checked)
			{
				str_value += "s";
			}
			else
			{
				str_value += "u";
			}
			str_value += ")";
			str_value += this.m_QuantizationComboBox.Text[0].ToString();
			str_value += this.m_OverflowComboBox.Text[0].ToString();
			if (this.m_SymmetricalCheckBox.Checked)
			{
				str_value += "S";
			}
			else
			{
				str_value += "A";
			}
			if (this.m_FullPrecisionCheckBox.Checked)
			{
				str_value += "T";
			}
			else
			{
				str_value += "F";
			}
			this.CheckBoxesEnablingEvent(this, null);
			return true;
		}


		private void iDisabeAndUncheckCheckBoxes()
		{
			this.m_SignedCheckBox.Checked = false;
			this.m_SignedCheckBox.Enabled = false;
			this.m_SymmetricalCheckBox.Checked = false;
			this.m_SymmetricalCheckBox.Enabled = false;
			this.m_FullPrecisionCheckBox.Checked = false;
			this.m_FullPrecisionCheckBox.Enabled = false;
		}




		public event UpdateDialog_FixMode.UnManagedCheckBoxesEnablingDel CheckBoxesEnablingEvent;


		private string m_ValueAsStr;



		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void UnManagedCheckBoxesEnablingDel(object sender, EventArgs fe);
	}
}
