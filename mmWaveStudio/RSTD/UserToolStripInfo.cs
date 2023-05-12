using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace RSTD
{

	public class UserToolStripInfo
	{



		public Point ToolStripLocation
		{
			get
			{
				return this.m_ToolStripLocation;
			}
			set
			{
				this.m_ToolStripLocation = value;
			}
		}




		public int RowIndex
		{
			get
			{
				return this.m_RowIndex;
			}
			set
			{
				this.m_RowIndex = value;
			}
		}




		public int ColIndex
		{
			get
			{
				return this.m_ColIndex;
			}
			set
			{
				this.m_ColIndex = value;
			}
		}




		public string ToolBarName
		{
			get
			{
				return this.m_ToolBarName;
			}
			set
			{
				this.m_ToolBarName = value;
			}
		}




		public string ToolBarBasePath
		{
			get
			{
				return this.m_ToolBarBasePath;
			}
			set
			{
				this.m_ToolBarBasePath = value;
			}
		}




		public string ToolBarConfigFile
		{
			get
			{
				return this.m_ToolBarConfigFile;
			}
			set
			{
				this.m_ToolBarConfigFile = value;
			}
		}




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




		public List<UserButtonInfo> ToolBarUserButtons
		{
			get
			{
				return this.m_ToolBarUserButtons;
			}
			set
			{
				this.m_ToolBarUserButtons = value;
			}
		}




		public bool IsDefualt
		{
			get
			{
				return this.m_IsDefualt;
			}
			set
			{
				this.m_IsDefualt = value;
			}
		}




		public bool IsReadOnly
		{
			get
			{
				return this.m_IsReadOnly;
			}
			set
			{
				this.m_IsReadOnly = value;
			}
		}


		public UserToolStripInfo()
		{
			this.m_ToolBarName = "ToolBar No.";
			this.m_ToolBarBasePath = "";
			this.m_ToolBarConfigFile = "";
			this.m_Show = true;
			this.m_IsDefualt = false;
			this.m_ToolBarUserButtons = new List<UserButtonInfo>();
			this.m_ToolStripLocation = default(Point);
		}


		public UserToolStripInfo(string name)
		{
			this.m_ToolBarName = name;
			this.m_ToolBarBasePath = "";
			this.m_ToolBarConfigFile = "";
			this.m_Show = true;
			this.m_IsDefualt = false;
			this.m_ToolBarUserButtons = new List<UserButtonInfo>();
			this.m_ToolStripLocation = default(Point);
		}


		public UserToolStripInfo(string name, string base_path, string config_file, bool show) : this(name, base_path, config_file, show, false, false)
		{
		}


		public UserToolStripInfo(string name, string base_path, string config_file, bool show, bool is_default, bool is_readonly)
		{
			this.m_ToolBarName = name;
			this.m_ToolBarBasePath = base_path;
			this.m_ToolBarConfigFile = config_file;
			this.m_Show = show;
			this.m_IsDefualt = is_default;
			this.m_IsReadOnly = is_readonly;
			this.m_ToolBarUserButtons = new List<UserButtonInfo>();
			this.m_ToolStripLocation = default(Point);
		}


		public bool IsFileReadOnly()
		{
			return File.Exists(this.m_ToolBarConfigFile) && GuiCore.IsFileReadOnly(this.m_ToolBarConfigFile);
		}


		private string m_ToolBarName;


		private string m_ToolBarBasePath;


		private string m_ToolBarConfigFile;


		private bool m_IsDefualt;


		private bool m_IsReadOnly;


		private bool m_Show;


		private List<UserButtonInfo> m_ToolBarUserButtons;


		private Point m_ToolStripLocation;


		private int m_RowIndex;


		private int m_ColIndex;
	}
}
