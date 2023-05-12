using System;
using System.Windows.Forms;

namespace RSTD
{

	internal class VariableFindContextMenu : VariableContextMenu
	{

		public VariableFindContextMenu(PassedVarData dataPassed, RstdConstants.CONTEXT_MENU_ORIGIN var_menu_display) : base(dataPassed, var_menu_display)
		{
			this.m_GotoMenuItem = new ToolStripMenuItem("GoTo");
			this.m_Separator4MenuItem = new ToolStripSeparator();
			this.Items.Insert(0, this.m_GotoMenuItem);
			this.Items.Insert(1, this.m_Separator4MenuItem);
			if (this.m_XmlNodes.Count > 1)
			{
				this.m_GotoMenuItem.Enabled = false;
			}
			this.m_GotoMenuItem.Click += this.iGotoMenuItem_Click;
			base.Show(Control.MousePosition);
		}


		~VariableFindContextMenu()
		{
			this.Items.Clear();
			this.m_GotoMenuItem = null;
			this.m_Separator4MenuItem = null;
		}


		private void iGotoMenuItem_Click(object sender, EventArgs e)
		{
			GuiCore.bJumpToPath(this.m_XmlNodes[0]);
		}


		private ToolStripMenuItem m_GotoMenuItem;


		private ToolStripSeparator m_Separator4MenuItem;
	}
}
