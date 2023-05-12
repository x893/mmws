using System;
using System.Windows.Forms;

namespace RSTD
{

	internal class ToolStripEx : ToolStrip
	{



		public bool ClickThrough
		{
			get
			{
				return this.clickThrough;
			}
			set
			{
				this.clickThrough = value;
			}
		}


		public ToolStripEx()
		{
		}


		public ToolStripEx(params ToolStripItem[] items) : base(items)
		{
		}


		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (this.clickThrough && (long)m.Msg == 33L && m.Result == (IntPtr)((long)((ulong)2)))
			{
				m.Result = (IntPtr)((long)((ulong)1));
			}
		}


		private bool clickThrough = true;


		internal sealed class NativeConstants
		{

			private NativeConstants()
			{
			}


			internal const uint WM_MOUSEACTIVATE = 33U;


			internal const uint MA_ACTIVATE = 1U;


			internal const uint MA_ACTIVATEANDEAT = 2U;


			internal const uint MA_NOACTIVATE = 3U;


			internal const uint MA_NOACTIVATEANDEAT = 4U;
		}
	}
}
