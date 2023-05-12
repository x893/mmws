using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	public partial class UpdateDialog_FixMode_New : UpdateDialog
	{

		public UpdateDialog_FixMode_New(List<XmlNode> nodes)
		{
			this.InitializeComponent();
			this.m_cboQuantization.SelectedIndex = 0;
			this.m_cboOverflow.SelectedIndex = 3;
			this.m_XmlNodes = nodes;
			this.m_Value = base.GetDefaultVal();
			this.m_bIsTransmit = false;
			this.ibParseValueIntoControls(this.m_Value);
		}


		private void m_btnAcceptTransmit_Click(object sender, EventArgs e)
		{
			this.m_bIsTransmit = true;
		}


		private void iQNotationOrAttributesControlChanged(object sender, EventArgs e)
		{
			if (this.m_txtQNotation.Focused)
			{
				return;
			}
			this.ibUpdateTextboxFromControls();
		}


		private bool ibParseValueIntoControls(string fixmode_str)
		{
			Match match = Regex.Match(fixmode_str.ToUpper().Trim(), "\\((-?[0-9]+).(-?[0-9]+)([S|U])?\\)((T|R|UT|UR|C|AC|SC|E|AE|SE|W|F|L)(,(T|R|UT|UR|C|AC|SC|E|AE|SE|W|F|L)){0,3})?$");
			if (!match.Success)
			{
				return false;
			}
			this.m_txtQInteger.Text = match.Groups[1].Value;
			this.m_txtQFraction.Text = match.Groups[2].Value;
			this.m_chkSigned.Checked = (match.Groups[3].Value == "S");
			foreach (string text in match.Groups[4].Value.Split(new char[]
			{
				','
			}, StringSplitOptions.RemoveEmptyEntries))
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(text);
				if (num <= 1727238636U)
				{
					if (num <= 1443004851U)
					{
						if (num != 668277163U)
						{
							if (num != 768942877U)
							{
								if (num == 1443004851U)
								{
									if (text == "SC")
									{
										this.m_cboOverflow.SelectedIndex = 4;
									}
								}
							}
							else if (text == "AC")
							{
								this.m_cboOverflow.SelectedIndex = 3;
							}
						}
						else if (text == "AE")
						{
							this.m_cboOverflow.SelectedIndex = 0;
						}
					}
					else if (num != 1543670565U)
					{
						if (num != 1693683398U)
						{
							if (num == 1727238636U)
							{
								if (text == "UT")
								{
									this.m_cboQuantization.SelectedIndex = 1;
								}
							}
						}
						else if (text == "UR")
						{
							this.m_cboQuantization.SelectedIndex = 3;
						}
					}
					else if (text == "SE")
					{
						this.m_cboOverflow.SelectedIndex = 1;
					}
				}
				else if (num <= 3322673650U)
				{
					if (num != 3222007936U)
					{
						if (num != 3272340793U)
						{
							if (num == 3322673650U)
							{
								if (text == "C")
								{
									this.m_cboOverflow.SelectedIndex = 3;
								}
							}
						}
						else if (text == "F")
						{
							this.m_chkFullPrecision.Checked = true;
						}
					}
					else if (text == "E")
					{
						this.m_cboOverflow.SelectedIndex = 0;
					}
				}
				else if (num <= 3507227459U)
				{
					if (num != 3373006507U)
					{
						if (num == 3507227459U)
						{
							if (text == "T")
							{
								this.m_cboQuantization.SelectedIndex = 0;
							}
						}
					}
					else if (text == "L")
					{
						this.m_chkLog.Checked = true;
					}
				}
				else if (num != 3524005078U)
				{
					if (num == 3607893173U)
					{
						if (text == "R")
						{
							this.m_cboQuantization.SelectedIndex = 2;
						}
					}
				}
				else if (text == "W")
				{
					this.m_cboOverflow.SelectedIndex = 2;
				}
			}
			this.m_txtQNotation.Text = fixmode_str;
			return match.Success;
		}


		private bool ibUpdateTextboxFromControls()
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5;
			if (this.m_chkSigned.Checked)
			{
				text5 = "s";
			}
			else
			{
				text5 = "u";
			}
			if (this.m_chkFullPrecision.Checked)
			{
				text2 = "F,";
			}
			if (this.m_chkLog.Checked)
			{
				text = "L";
			}
			if (this.m_cboQuantization.Text != "")
			{
				switch (this.m_cboQuantization.SelectedIndex)
				{
				case 0:
					text3 = "T,";
					break;
				case 1:
					text3 = "UT,";
					break;
				case 2:
					text3 = "R,";
					break;
				case 3:
					text3 = "UR,";
					break;
				}
			}
			if (this.m_cboOverflow.Text != "")
			{
				switch (this.m_cboOverflow.SelectedIndex)
				{
				case 0:
					text4 = "AE,";
					break;
				case 1:
					text4 = "SE,";
					break;
				case 2:
					text4 = "W,";
					break;
				case 3:
					text4 = "AC,";
					break;
				case 4:
					text4 = "SC,";
					break;
				}
			}
			this.m_txtQNotation.Text = string.Format("({0}.{1}{2}){3}{4}{5}{6}", new object[]
			{
				this.m_txtQInteger.Text,
				this.m_txtQFraction.Text,
				text5,
				text3,
				text4,
				text2,
				text
			});
			this.m_txtQNotation.Text = this.m_txtQNotation.Text.Trim(new char[]
			{
				','
			});
			return true;
		}


		public override bool bHasValidValue()
		{
			return Regex.Match(this.m_txtQNotation.Text.ToUpper().Trim(), "\\((-?[0-9]+).(-?[0-9]+)([S|U])?\\)((T|R|UT|UR|C|AC|SC|E|AE|SE|W|F|L)(,(T|R|UT|UR|C|AC|SC|E|AE|SE|W|F|L)){0,3})?$").Success;
		}


		public override string GetValue()
		{
			return this.m_txtQNotation.Text;
		}


		private void m_txtQNotation_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.m_txtQNotation.Text))
			{
				this.ibParseValueIntoControls(this.m_txtQNotation.Text);
				return;
			}
			this.m_cboQuantization.SelectedIndex = 0;
			this.m_cboOverflow.SelectedIndex = 3;
			this.m_chkFullPrecision.Checked = false;
			this.m_chkLog.Checked = false;
		}


		private string m_Value;
	}
}
