using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace RSTD
{

	public partial class frmUpdateArrayDialog : Form
	{



		public TextBox txtArrayName
		{
			get
			{
				return this.m_txtArrayName;
			}
			set
			{
				this.m_txtArrayName = value;
			}
		}


		public frmUpdateArrayDialog(List<XmlNode> xmlNode)
		{
			this.m_XmlNodes = xmlNode;
			this.InitializeComponent();
			this.colIndex.ReadOnly = true;
			this.m_dgvArray.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(216, 231, 255);
			this.m_dgvArray.Height = 12 * this.m_dgvArray.RowTemplate.Height + 21 + 3;
			this.m_Xvalue = new List<double>();
			this.m_YvalReal = new List<double>();
			this.m_YvalImage = new List<double>();
			if (GuiCore.bNodeIsReadOnly(xmlNode[0]))
			{
				this.m_btnTransmit.Enabled = false;
				this.m_dgvArray.ReadOnly = true;
			}
			this.iInitializeArrayDialog();
			this.iFillUpdateArrayDialog();
		}


		private void iInitializeArrayDialog()
		{
			this.m_txtArrayName.Text = GuiCore.GetPathFromNode(this.m_XmlNodes[0]);
			this.m_txtArrayName.SelectionStart = this.m_txtArrayName.Text.Length;
			this.m_txtArrayOffset.Text = this.m_XmlNodes[0].Attributes["offset"].Value;
			this.m_txtArrayStride.Text = this.m_XmlNodes[0].Attributes["stride"].Value;
			this.m_txtArrayLength.Text = this.m_XmlNodes[0].Attributes["length"].Value;
			this.m_array_icon.Image = this.iGetArrayIcon(this.m_XmlNodes[0]).ToBitmap();
		}


		private void iFillUpdateArrayDialog()
		{
			int num = -1;
			int num2 = -1;
			string[] array = GuiCore.GetDisplayedValue(this.m_XmlNodes[0]).Split(new char[]
			{
				' '
			});
			int num3 = int.Parse(this.m_XmlNodes[0].Attributes["offset"].Value);
			int num4 = int.Parse(this.m_XmlNodes[0].Attributes["stride"].Value);
			int num5 = int.Parse(this.m_XmlNodes[0].Attributes["length"].Value);
			if (this.m_dgvArray.CurrentCell != null && this.m_dgvArray.CurrentCell.RowIndex < num5)
			{
				this.m_dgvArray[0, 0].Selected = false;
				num2 = this.m_dgvArray.CurrentCell.ColumnIndex;
				num = this.m_dgvArray.CurrentCell.RowIndex;
			}
			base.Height += this.CalcGridHeight(num5) - this.m_dgvArray.Height;
			this.m_dgvArray.Rows.Clear();
			try
			{
				int i = 0;
				int num6 = num3;
				while (i < array.Length)
				{
					this.m_dgvArray.Rows.Add();
					this.m_dgvArray[this.colIndex.Index, i].Value = num6;
					this.m_dgvArray[this.colValue.Index, i].Value = array[i];
					num6 += num4;
					i++;
				}
				this.m_dgvArray[0, 0].Selected = false;
				if (num != -1 && num2 != -1)
				{
					this.m_dgvArray[num2, num].Selected = true;
					this.m_dgvArray.CurrentCell = this.m_dgvArray[num2, num];
				}
				else
				{
					this.m_dgvArray[0, 0].Selected = true;
				}
			}
			catch (Exception ex)
			{
				GuiCore.RstdException(ex.ToString(), ex.StackTrace);
			}
		}


		private bool iFillUpdateXYList(bool b_is_complex)
		{
			double item = 0.0;
			string[] array = GuiCore.GetDisplayedValue(this.m_XmlNodes[0]).Split(new char[]
			{
				' '
			});
			this.m_Xvalue.Clear();
			this.m_YvalReal.Clear();
			this.m_YvalImage.Clear();
			int num = int.Parse(this.m_XmlNodes[0].Attributes["offset"].Value);
			int num2 = int.Parse(this.m_XmlNodes[0].Attributes["stride"].Value);
			int.Parse(this.m_XmlNodes[0].Attributes["length"].Value);
			try
			{
				int i = 0;
				int num3 = num;
				while (i < array.Length)
				{
					string[] array2 = array[i].Trim(new char[]
					{
						'(',
						')'
					}).Split(new char[]
					{
						','
					});
					this.m_Xvalue.Add((double)num3);
					if (b_is_complex)
					{
						this.m_YvalReal.Add(double.Parse(array2[0]));
						this.m_YvalImage.Add(double.Parse(array2[1]));
					}
					else
					{
						if (!double.TryParse(array2[0], out item))
						{
							bool flag;
							if (!bool.TryParse(array2[0], out flag))
							{
								return false;
							}
							if (flag)
							{
								item = 1.0;
							}
							else
							{
								item = 0.0;
							}
						}
						this.m_YvalReal.Add(item);
					}
					num3 += num2;
					i++;
				}
			}
			catch (Exception ex)
			{
				GuiCore.RstdException(ex.ToString(), ex.StackTrace);
				return false;
			}
			return true;
		}


		private int CalcGridHeight(int array_length)
		{
			int num = this.m_dgvArray.RowTemplate.Height * array_length + 21 + 3;
			int num2 = this.m_dgvArray.RowTemplate.Height * 12 + 21 + 3;
			int num3 = this.m_dgvArray.RowTemplate.Height * 25 + 21 + 3;
			if (num > num3)
			{
				num = num3;
			}
			else if (num < num2)
			{
				num = num2;
			}
			return num;
		}


		private bool ibCheckIfGridChanged()
		{
			if (this.m_XmlNodes[0].Attributes["offset"].Value != this.m_txtArrayOffset.Text || this.m_XmlNodes[0].Attributes["stride"].Value != this.m_txtArrayStride.Text || this.m_XmlNodes[0].Attributes["length"].Value != this.m_txtArrayLength.Text)
			{
				return true;
			}
			string[] array = GuiCore.GetNodeValue(this.m_XmlNodes[0]).Split(new char[0]);
			for (int i = 0; i < array.Length; i++)
			{
				if (this.m_dgvArray[this.colValue.Index, i].Value.ToString() != array[i])
				{
					return true;
				}
			}
			return false;
		}


		private void iUpdateXmlFromGrid()
		{
			this.m_XmlNodes[0].Attributes["offset"].Value = this.m_txtArrayOffset.Text;
			this.m_XmlNodes[0].Attributes["stride"].Value = this.m_txtArrayStride.Text;
			this.m_XmlNodes[0].Attributes["length"].Value = this.m_txtArrayLength.Text;
			string value = this.iConvertValueColumnToOneString();
			GuiCore.bChangeValue(this.m_XmlNodes[0], value);
			GuiCore.RefreshGui();
		}


		private Icon iGetArrayIcon(XmlNode xmlNode)
		{
			if (GuiCore.GetNodeType(xmlNode) == NodeType.MAPPED_VAR)
			{
				xmlNode = GuiCore.RegisterMapping[xmlNode];
			}
			if (!bool.Parse(xmlNode.Attributes["is_updated"].Value))
			{
				return TreeIcons.var_not_updated;
			}
			return TreeIcons.var_updated;
		}


		private string iConvertValueColumnToOneString()
		{
			int.Parse(this.m_txtArrayLength.Text);
			string text = "";
			for (int i = 0; i < this.m_dgvArray.Rows.Count; i++)
			{
				text = text + this.m_dgvArray[this.colValue.Index, i].Value + " ";
			}
			return text.Trim();
		}


		private bool bCheckComplex(string node_type)
		{
			return node_type == "FIXCPLXVECT" || node_type == "FIXCPLX" || node_type == "FLOAT64COMPLEX" || node_type == "FIXCPLXVECTPTR" || node_type == "FIXCPLXPTR" || node_type == "FLOAT64COMPLEXPTR";
		}


		private void m_btnArrayPlot_Click(object sender, EventArgs e)
		{
			string chart_name = "Plot";
			string value = this.m_XmlNodes[0].Attributes["name"].Value;
			bool b_is_complex = this.bCheckComplex(this.m_XmlNodes[0].Attributes["type"].Value);
			if (!this.iFillUpdateXYList(b_is_complex))
			{
				return;
			}
			GuiCore.MainForm.LuaOps.CallReggaePlot(chart_name, value, this.m_Xvalue.ToArray(), this.m_YvalReal.ToArray(), this.m_YvalImage.ToArray(), b_is_complex);
		}


		private void m_btnOK_Click(object sender, EventArgs e)
		{
			if (this.ibCheckIfGridChanged())
			{
				this.iUpdateXmlFromGrid();
			}
			base.Close();
		}


		private void m_btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}


		private void m_btnReceive_Click(object sender, EventArgs e)
		{
			this.m_XmlNodes[0].Attributes["offset"].Value = this.m_txtArrayOffset.Text;
			this.m_XmlNodes[0].Attributes["stride"].Value = this.m_txtArrayStride.Text;
			this.m_XmlNodes[0].Attributes["length"].Value = this.m_txtArrayLength.Text;
			GuiCore.Receive(this.m_XmlNodes[0], ReceiveTransmit_T.ARRAY_VAR, false);
			this.m_dgvArray[0, 0].Selected = false;
			this.m_dgvArray.CurrentCell.Selected = true;
			this.iFillUpdateArrayDialog();
			this.m_array_icon.Image = TreeIcons.var_updated.ToBitmap();
		}


		private void m_btnTransmit_Click(object sender, EventArgs e)
		{
			string value = this.iConvertValueColumnToOneString();
			GuiCore.bChangeArrayBeforeTransmit(this.m_XmlNodes[0], value);
			GuiCore.Transmit(this.m_XmlNodes, ReceiveTransmit_T.ARRAY_VAR, false);
			this.m_array_icon.Image = TreeIcons.var_updated.ToBitmap();
		}


		private void m_ArrayDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			string text = "";
			DataGridViewSelectedCellCollection selectedCells = this.m_dgvArray.SelectedCells;
			for (int i = 0; i < selectedCells.Count; i++)
			{
				text += selectedCells[i].Value;
				text += " ";
			}
		}


		private void m_ArrayDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			this.m_var_value_before_edit = this.m_dgvArray[this.colValue.Index, e.RowIndex].Value.ToString();
		}


		private void m_ArrayDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (this.m_dgvArray[this.colValue.Index, e.RowIndex].Value == null)
			{
				this.m_dgvArray[this.colValue.Index, e.RowIndex].Value = this.m_var_value_before_edit;
				return;
			}
			string value = this.m_dgvArray[this.colValue.Index, e.RowIndex].Value.ToString();
			if (!this.m_var_value_before_edit.Equals(value))
			{
				this.m_array_icon.Image = TreeIcons.var_not_updated.ToBitmap();
			}
		}


		private List<XmlNode> m_XmlNodes;


		private List<double> m_Xvalue;


		private List<double> m_YvalReal;


		private List<double> m_YvalImage;


		private string m_var_value_before_edit;


		private const int m_MIN_ROWS_IN_GRID = 12;


		private const int m_MAX_ROWS_IN_GRID = 25;


		private const int m_GRID_ADDED_HEIGHT = 3;


		private const int m_GRID_COLUMNS_HEADER_HEIGHT = 21;
	}
}
