using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rstd.Controls.ContainerListViews
{

	public class ContainerListViewCancelEventArgs : CancelEventArgs
	{


		public ContainerListViewColumnHeader ColumnHeader
		{
			get
			{
				return this._column;
			}
		}



		public ContainerListViewItem Item
		{
			get
			{
				return this._item;
			}
		}



		public Point MousePosition
		{
			get
			{
				return this._mousePosition;
			}
		}



		public MouseButtons MouseButton
		{
			get
			{
				return this._mouseButton;
			}
		}


		internal ContainerListViewCancelEventArgs(ContainerListViewColumnHeader column, ContainerListViewItem item)
		{
			this._column = column;
			this._item = item;
		}


		internal ContainerListViewCancelEventArgs(ContainerListViewColumnHeader column, ContainerListViewItem item, MouseEventArgs e)
		{
			this._column = column;
			this._item = item;
			this._mousePosition = new Point(e.X, e.Y);
			this._mouseButton = e.Button;
		}


		internal ContainerListViewCancelEventArgs(ContainerListViewColumnHeader column, ContainerListViewItem item, int mouseX, int mouseY, MouseButtons mouseButton)
		{
			this._column = column;
			this._item = item;
			this._mousePosition = new Point(mouseX, mouseY);
			this._mouseButton = mouseButton;
		}


		private ContainerListViewColumnHeader _column;


		private ContainerListViewItem _item;


		private Point _mousePosition;


		private MouseButtons _mouseButton;
	}
}
