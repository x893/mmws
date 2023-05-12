using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LuaRegister;

namespace RSTD
{

	public partial class frmLuaRegister : Form
	{

		public frmLuaRegister()
		{
			this.InitializeComponent();
		}


		private void m_dgvDllRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == this.colBrowse.Index)
			{
				string text = GuiCore.OpenFileDialog(null, FileType.DLL);
				if (!string.IsNullOrEmpty(text))
				{
					string dllModuleName = GuiCore.MainForm.GetDllModuleName(text);
					if (!string.IsNullOrEmpty(dllModuleName))
					{
						if (this.m_dgvDllRegister.Rows[e.RowIndex].IsNewRow)
						{
							this.m_dgvDllRegister.Rows.Add();
						}
						this.m_dgvDllRegister.Rows[e.RowIndex].Cells[this.colPath.Index].Value = text;
						this.m_dgvDllRegister.Rows[e.RowIndex].Cells[this.colPackage.Index].Value = dllModuleName;
						this.m_dgvDllRegister.Rows[e.RowIndex].Cells[this.colIsRegistered.Index].Value = false;
						this.m_dgvDllRegister.Rows[e.RowIndex].Cells[this.colUse.Index].Value = true;
						return;
					}
					MessageBox.Show("Selected file does not contain a Lua module.", "RTTT");
				}
			}
		}


		private void iUpdateDllsFromGrid()
		{
			RstdGuiSettings.Default.LuaRegisterInfos.Clear();
			for (int i = 0; i < this.m_dgvDllRegister.Rows.Count - 1; i++)
			{
				DataGridViewRow dataGridViewRow = this.m_dgvDllRegister.Rows[i];
				if (!string.IsNullOrEmpty((string)dataGridViewRow.Cells[this.colPath.Index].Value))
				{
					LuaRegisterInfo luaRegisterInfo = (LuaRegisterInfo)dataGridViewRow.Tag;
					if (luaRegisterInfo == null)
					{
						luaRegisterInfo = new LuaRegisterInfo();
					}
					if (dataGridViewRow.Cells[this.colUse.Index].Value != null)
					{
						luaRegisterInfo.Use = (bool)dataGridViewRow.Cells[this.colUse.Index].Value;
						luaRegisterInfo.IsRegistered = (bool)dataGridViewRow.Cells[this.colIsRegistered.Index].Value;
					}
					if (dataGridViewRow.Cells[this.colPackage.Index].Value != null)
					{
						luaRegisterInfo.Package = dataGridViewRow.Cells[this.colPackage.Index].Value.ToString();
					}
					if (dataGridViewRow.Cells[this.colPath.Index].Value != null)
					{
						luaRegisterInfo.DllPath = dataGridViewRow.Cells[this.colPath.Index].Value.ToString();
					}
					RstdGuiSettings.Default.LuaRegisterInfos.Add(luaRegisterInfo);
				}
			}
		}


		private void iUpdateGridFromDlls()
		{
			this.m_dgvDllRegister.Rows.Clear();
			foreach (LuaRegisterInfo lua_reg_info in RstdGuiSettings.Default.LuaRegisterInfos)
			{
				this.iAddDllToGrid(lua_reg_info);
			}
		}


		private void iAddDllToGrid(LuaRegisterInfo lua_reg_info)
		{
			this.m_dgvDllRegister.Rows.Add();
			this.m_dgvDllRegister.Rows[this.m_dgvDllRegister.Rows.Count - 2].Cells[this.colUse.Index].Value = lua_reg_info.Use;
			this.m_dgvDllRegister.Rows[this.m_dgvDllRegister.Rows.Count - 2].Cells[this.colIsRegistered.Index].Value = lua_reg_info.IsRegistered;
			this.m_dgvDllRegister.Rows[this.m_dgvDllRegister.Rows.Count - 2].Cells[this.colPackage.Index].Value = lua_reg_info.Package;
			this.m_dgvDllRegister.Rows[this.m_dgvDllRegister.Rows.Count - 2].Cells[this.colPath.Index].Value = lua_reg_info.DllPath;
			this.m_dgvDllRegister.Rows[this.m_dgvDllRegister.Rows.Count - 2].Tag = lua_reg_info;
		}


		private void btn_OK_Click(object sender, EventArgs e)
		{
			this.iUpdateDllsFromGrid();
			RstdGuiSettings.Default.Save();
			base.DialogResult = DialogResult.OK;
		}


		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}


		private void frmLuaRegister_Load(object sender, EventArgs e)
		{
			this.iUpdateGridFromDlls();
		}


		private void m_dgvDllRegister_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			this.m_dgvDllRegister.Rows[this.m_dgvDllRegister.Rows.Count - 1].Cells[this.colUse.Index].Value = false;
			this.m_dgvDllRegister.Rows[this.m_dgvDllRegister.Rows.Count - 1].Cells[this.colIsRegistered.Index].Value = false;
		}


		private void frmLuaRegister_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.DialogResult = DialogResult.Cancel;
			}
		}
	}
}
