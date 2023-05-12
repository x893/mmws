using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace RSTD.Properties
{
//	[CompilerGenerated]
//	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{


		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("50, 50")]
		public Point MainConsolePosition
		{
			get
			{
				return (Point)this["MainConsolePosition"];
			}
			set
			{
				this["MainConsolePosition"] = value;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("625, 566")]
		public Size MainConsoleSize
		{
			get
			{
				return (Size)this["MainConsoleSize"];
			}
			set
			{
				this["MainConsoleSize"] = value;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("1")]
		public float MainConsoleZoomFactor
		{
			get
			{
				return (float)this["MainConsoleZoomFactor"];
			}
			set
			{
				this["MainConsoleZoomFactor"] = value;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string MainConsoleFilterExclude
		{
			get
			{
				return (string)this["MainConsoleFilterExclude"];
			}
			set
			{
				this["MainConsoleFilterExclude"] = value;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string LastScriptsRun
		{
			get
			{
				return (string)this["LastScriptsRun"];
			}
			set
			{
				this["LastScriptsRun"] = value;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string LastTreePath
		{
			get
			{
				return (string)this["LastTreePath"];
			}
			set
			{
				this["LastTreePath"] = value;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string LastMonitorPath
		{
			get
			{
				return (string)this["LastMonitorPath"];
			}
			set
			{
				this["LastMonitorPath"] = value;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("854, 582")]
		public Size BrowseTreeSize
		{
			get
			{
				return (Size)this["BrowseTreeSize"];
			}
			set
			{
				this["BrowseTreeSize"] = value;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("343, 338")]
		public Point BrowseTreePosition
		{
			get
			{
				return (Point)this["BrowseTreePosition"];
			}
			set
			{
				this["BrowseTreePosition"] = value;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string LastScriptPath
		{
			get
			{
				return (string)this["LastScriptPath"];
			}
			set
			{
				this["LastScriptPath"] = value;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string LastDllPath
		{
			get
			{
				return (string)this["LastDllPath"];
			}
			set
			{
				this["LastDllPath"] = value;
			}
		}




		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string MainConsoleFilterInclude
		{
			get
			{
				return (string)this["MainConsoleFilterInclude"];
			}
			set
			{
				this["MainConsoleFilterInclude"] = value;
			}
		}


		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
