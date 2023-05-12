using System;
using System.Drawing;
using System.Windows.Forms;

namespace RSTD
{

	public class ToolBarBtnInfo
	{



		public bool Show
		{
			get
			{
				return this.m_Show;
			}
			set
			{
				this.m_Show = value;
			}
		}




		public Image Icon
		{
			get
			{
				return this.m_Icon;
			}
			set
			{
				this.m_Icon = value;
			}
		}




		public Color UserColor
		{
			get
			{
				return this.m_UserColor;
			}
			set
			{
				this.m_UserColor = value;
			}
		}




		public string IconFile
		{
			get
			{
				return this.m_IconFile;
			}
			set
			{
				this.m_IconFile = value;
			}
		}




		public string Title
		{
			get
			{
				return this.m_Title;
			}
			set
			{
				this.m_Title = value;
			}
		}




		public string ToolTip
		{
			get
			{
				return this.m_ToolTip;
			}
			set
			{
				this.m_ToolTip = value;
			}
		}


		public ToolBarBtnInfo()
		{
			this.m_Show = true;
			this.m_Title = "";
			this.m_ToolTip = "";
			this.m_IconFile = "";
		}


		public ToolBarBtnInfo(bool show, Image icon, string user_color, string title, string tooltip)
		{
			this.m_Show = show;
			this.m_Icon = icon;
			this.m_Title = title;
			this.m_ToolTip = tooltip;
			this.m_UserColor = ColorTranslator.FromHtml(user_color);
			if (string.IsNullOrEmpty(tooltip))
			{
				this.m_ToolTip = title;
			}
		}


		public ToolBarBtnInfo(string title)
		{
			this.m_Show = true;
			this.m_Icon = null;
			this.m_Title = title;
			this.m_ToolTip = "";
		}


		public ToolBarBtnInfo(bool show, string icon_file, string user_color, string title, string tooltip)
		{
			this.m_Show = show;
			this.m_IconFile = icon_file;
			this.m_Title = title;
			this.m_ToolTip = tooltip;
			this.m_Icon = GuiCore.GetImageFromFile(icon_file);
			this.m_UserColor = ColorTranslator.FromHtml(user_color);
		}


		public ToolStripButton ToToolStripButton()
		{
			ToolStripButton toolStripButton = new ToolStripButton();
			toolStripButton.Text = this.m_Title;
			toolStripButton.ToolTipText = this.m_ToolTip;
			toolStripButton.Image = this.m_Icon;
			toolStripButton.Size = new Size(49, 49);
			toolStripButton.ImageTransparentColor = Color.Transparent;
			toolStripButton.ImageScaling = ToolStripItemImageScaling.None;
			toolStripButton.BackColor = this.m_UserColor;
			if (this.m_Icon != null)
			{
				toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
			}
			else
			{
				toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
			}
			return toolStripButton;
		}


		private bool m_Show;


		private Image m_Icon;


		private string m_IconFile;


		private string m_Title;


		private string m_ToolTip;


		private Color m_UserColor;
	}
}
