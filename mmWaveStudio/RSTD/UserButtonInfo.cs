using System;
using System.Collections.Generic;
using System.Drawing;
using LuaRegister;

namespace RSTD
{

	public class UserButtonInfo : ToolBarBtnInfo
	{



		public string UserButtonSource
		{
			get
			{
				return this.m_UserButtonSource;
			}
			set
			{
				this.m_UserButtonSource = value;
			}
		}




		public List<ScriptParam> Params
		{
			get
			{
				return this.m_Params;
			}
			set
			{
				this.m_Params = value;
			}
		}




		public LuaSourceType SourceType
		{
			get
			{
				return this.m_SourceType;
			}
			set
			{
				this.m_SourceType = value;
			}
		}




		public string FunctionSource
		{
			get
			{
				return this.m_FunctionSource;
			}
			set
			{
				this.m_FunctionSource = value;
			}
		}


		public UserButtonInfo()
		{
			this.m_SourceType = LuaSourceType.File;
			this.m_UserButtonSource = "";
			this.m_Params = new List<ScriptParam>();
			this.m_FunctionSource = "";
		}


		public UserButtonInfo(bool show, Image icon, string user_color, string title, string tooltip, string source, LuaSourceType source_type, string function_source) : base(show, icon, user_color, title, tooltip)
		{
			this.m_SourceType = source_type;
			this.m_UserButtonSource = source;
			this.m_Params = new List<ScriptParam>();
			this.m_FunctionSource = function_source;
		}


		public UserButtonInfo(bool show, string icon_file, string user_color, string title, string tooltip, string source, LuaSourceType source_type, string function_source) : base(show, icon_file, user_color, title, tooltip)
		{
			this.m_SourceType = source_type;
			this.m_UserButtonSource = source;
			this.m_Params = new List<ScriptParam>();
			this.m_FunctionSource = function_source;
		}


		private string m_UserButtonSource;


		private List<ScriptParam> m_Params;


		private LuaSourceType m_SourceType;


		private string m_FunctionSource;
	}
}
