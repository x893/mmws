using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RSTD
{

	public partial class UpdateMonitorVarsDialog : Form
	{

		public UpdateMonitorVarsDialog(string[] clockNameList, ListView.SelectedListViewItemCollection selVars)
		{
			this.InitializeComponent();
			this.m_SelectedVars = selVars;
			if (clockNameList != null)
			{
				this.m_ClocksListBox.Items.AddRange(clockNameList);
			}
			if (1 == this.m_SelectedVars.Count)
			{
				this.m_VarName.Text = this.m_SelectedVars[0].Text;
				this.m_VarName.SelectionStart = this.m_VarName.Text.Length;
				this.m_VectorOffsetTextBox.Text = this.m_SelectedVars[0].SubItems[2].Text;
				this.m_VectorStrideTextBox.Text = this.m_SelectedVars[0].SubItems[3].Text;
				this.m_VectorLengthTextBox.Text = this.m_SelectedVars[0].SubItems[4].Text;
				this.iSelectPrevClocksForSingleVar();
				return;
			}
			this.m_VarName.Text = "Multiple Selection";
			this.m_VectorOffsetTextBox.Enabled = false;
			this.m_VectorStrideTextBox.Enabled = false;
			this.m_VectorLengthTextBox.Enabled = false;
		}


		private void m_AcceptBtn_Click(object sender, EventArgs e)
		{
			string text = "";
			for (int i = 0; i < this.m_ClocksListBox.SelectedItems.Count; i++)
			{
				text = text + this.m_ClocksListBox.SelectedItems[i] + ";";
			}
			for (int i = 0; i < this.m_SelectedVars.Count; i++)
			{
				this.m_SelectedVars[i].SubItems[1].Text = text;
			}
			if (1 == this.m_SelectedVars.Count)
			{
				this.m_SelectedVars[0].SubItems[2].Text = this.m_VectorOffsetTextBox.Text;
				this.m_SelectedVars[0].SubItems[3].Text = this.m_VectorStrideTextBox.Text;
				this.m_SelectedVars[0].SubItems[4].Text = this.m_VectorLengthTextBox.Text;
			}
		}


		private void m_CancelBtn_Click(object sender, EventArgs e)
		{
		}


		private void iSelectPrevClocksForSingleVar()
		{
			string[] array = this.m_SelectedVars[0].SubItems[1].Text.Split(new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				int num = this.m_ClocksListBox.FindStringExact(array[i]);
				if (-1 == num)
				{
					throw new Exception("Previous clock list has invalid clock name");
				}
				this.m_ClocksListBox.SelectedIndices.Add(num);
			}
		}


		private ListView.SelectedListViewItemCollection m_SelectedVars;


		private enum EMonitorVarsListViewColumns
		{

			VARIABLE_NAMES,

			RELEVANT_CLOCKS,

			VECTOR_OFFSET,

			VECTOR_STRIDE,

			VECTOR_LENGTH
		}
	}
}
