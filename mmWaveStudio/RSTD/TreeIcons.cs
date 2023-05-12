using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace RSTD
{

	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class TreeIcons
	{

		internal TreeIcons()
		{
		}



		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (TreeIcons.resourceMan == null)
				{
					TreeIcons.resourceMan = new ResourceManager("RSTD.TreeIcons", typeof(TreeIcons).Assembly);
				}
				return TreeIcons.resourceMan;
			}
		}




		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return TreeIcons.resourceCulture;
			}
			set
			{
				TreeIcons.resourceCulture = value;
			}
		}



		internal static Icon clock
		{
			get
			{
				return (Icon)TreeIcons.ResourceManager.GetObject("clock", TreeIcons.resourceCulture);
			}
		}



		internal static Bitmap copy
		{
			get
			{
				return (Bitmap)TreeIcons.ResourceManager.GetObject("copy", TreeIcons.resourceCulture);
			}
		}



		internal static Bitmap diskette
		{
			get
			{
				return (Bitmap)TreeIcons.ResourceManager.GetObject("diskette", TreeIcons.resourceCulture);
			}
		}



		internal static Bitmap find
		{
			get
			{
				return (Bitmap)TreeIcons.ResourceManager.GetObject("find", TreeIcons.resourceCulture);
			}
		}



		internal static Icon folder_close
		{
			get
			{
				return (Icon)TreeIcons.ResourceManager.GetObject("folder_close", TreeIcons.resourceCulture);
			}
		}



		internal static Icon folder_open
		{
			get
			{
				return (Icon)TreeIcons.ResourceManager.GetObject("folder_open", TreeIcons.resourceCulture);
			}
		}



		internal static Icon func_color
		{
			get
			{
				return (Icon)TreeIcons.ResourceManager.GetObject("func_color", TreeIcons.resourceCulture);
			}
		}



		internal static Icon func_gray
		{
			get
			{
				return (Icon)TreeIcons.ResourceManager.GetObject("func_gray", TreeIcons.resourceCulture);
			}
		}



		internal static Bitmap func_run
		{
			get
			{
				return (Bitmap)TreeIcons.ResourceManager.GetObject("func_run", TreeIcons.resourceCulture);
			}
		}



		internal static Bitmap green_light
		{
			get
			{
				return (Bitmap)TreeIcons.ResourceManager.GetObject("green_light", TreeIcons.resourceCulture);
			}
		}



		internal static Bitmap help
		{
			get
			{
				return (Bitmap)TreeIcons.ResourceManager.GetObject("help", TreeIcons.resourceCulture);
			}
		}



		internal static Icon parameter
		{
			get
			{
				return (Icon)TreeIcons.ResourceManager.GetObject("parameter", TreeIcons.resourceCulture);
			}
		}



		internal static Bitmap red_light
		{
			get
			{
				return (Bitmap)TreeIcons.ResourceManager.GetObject("red_light", TreeIcons.resourceCulture);
			}
		}



		internal static Bitmap refresh
		{
			get
			{
				return (Bitmap)TreeIcons.ResourceManager.GetObject("refresh", TreeIcons.resourceCulture);
			}
		}



		internal static Bitmap tx
		{
			get
			{
				return (Bitmap)TreeIcons.ResourceManager.GetObject("tx", TreeIcons.resourceCulture);
			}
		}



		internal static Icon var_auto_updated
		{
			get
			{
				return (Icon)TreeIcons.ResourceManager.GetObject("var_auto_updated", TreeIcons.resourceCulture);
			}
		}



		internal static Icon var_not_updated
		{
			get
			{
				return (Icon)TreeIcons.ResourceManager.GetObject("var_not_updated", TreeIcons.resourceCulture);
			}
		}



		internal static Icon var_updated
		{
			get
			{
				return (Icon)TreeIcons.ResourceManager.GetObject("var_updated", TreeIcons.resourceCulture);
			}
		}


		private static ResourceManager resourceMan;


		private static CultureInfo resourceCulture;
	}
}
