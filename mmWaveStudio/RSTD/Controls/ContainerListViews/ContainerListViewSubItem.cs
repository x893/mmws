using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rstd.Controls.ContainerListViews
{

	[DesignTimeVisible(false)]
	[TypeConverter("DotNetLib.Windows.Forms.ContainerListViewSubItemConverter")]
	public class ContainerListViewSubItem : ICloneable
	{

		public ContainerListViewSubItem(int index)
		{
			this._columnIndex = index;
		}


		public ContainerListViewSubItem(string text)
		{
			this._text = text;
		}


		public ContainerListViewSubItem(Control childControl)
		{
			this.ItemControl = childControl;
		}


		public ContainerListViewSubItem(Control childControl, ControlResizeBehavior resizeBehavior)
		{
			this.ItemControl = childControl;
			this._controlResizeBehavior = resizeBehavior;
		}




		[Category("Appearance")]
		[Description("The color to use to paint the back color of the sub item.")]
		[DefaultValue(typeof(Color), "Empty")]
		public Color BackColor
		{
			get
			{
				return this._backColor;
			}
			set
			{
				if (this._backColor != value)
				{
					this._backColor = value;
					this.Refresh();
				}
			}
		}




		[Category("Appearance")]
		[Description("The color to use to paint the text of the item.")]
		[DefaultValue(typeof(Color), "Empty")]
		public Color ForeColor
		{
			get
			{
				return this._foreColor;
			}
			set
			{
				if (this._foreColor != value)
				{
					this._foreColor = value;
					this.Refresh();
				}
			}
		}




		[Category("Appearance")]
		[Description("The font to use to draw the text of the column header.")]
		[AmbientValue(null)]
		public Font Font
		{
			get
			{
				if (this._font != null)
				{
					return this._font;
				}
				if (this.Item == null)
				{
					return Control.DefaultFont;
				}
				return this.Item.Font;
			}
			set
			{
				if (this._font != value)
				{
					this._font = value;
					this.Refresh();
				}
			}
		}




		[Category("Appearance")]
		[Description("The text of the subitem.")]
		[DefaultValue("")]
		public string Text
		{
			get
			{
				if (this._childControl != null)
				{
					return this._childControl.Text;
				}
				return this._text;
			}
			set
			{
				if (this._text != value)
				{
					this._text = value + string.Empty;
					if (this._childControl != null)
					{
						this._childControl.Text = this._text;
					}
					this.Refresh();
				}
			}
		}




		[Category("Behavior")]
		[Description("The control to embed in the subitem.")]
		[DefaultValue(null)]
		public Control ItemControl
		{
			get
			{
				return this._childControl;
			}
			set
			{
				if (this._childControl != value)
				{
					if (this._childControl != null)
					{
						this._childControl.MouseDown -= this.ItemControl_MouseDown;
						this._childControl.TextChanged -= this.ItemControl_TextChanged;
						this._childControl.Parent = null;
					}
					this._childControl = value;
					if (this._childControl != null)
					{
						this._childControl.Visible = false;
						this._childControl.MouseDown += this.ItemControl_MouseDown;
						this._childControl.TextChanged += this.ItemControl_TextChanged;
						if (this.Item != null)
						{
							this._childControl.Tag = this.Item.Tag;
						}
						this._childControlInitialSize = this._childControl.ClientSize;
					}
					this.Refresh();
				}
			}
		}




		[Category("Behavior")]
		[Description("The control to embed in the subitem.")]
		[DefaultValue(ControlResizeBehavior.BothFit)]
		public ControlResizeBehavior ControlResizeBehavior
		{
			get
			{
				return this._controlResizeBehavior;
			}
			set
			{
				if (this._controlResizeBehavior != value)
				{
					this._controlResizeBehavior = value;
					this.Refresh();
				}
			}
		}



		public int ColumnIndex
		{
			get
			{
				return this._columnIndex;
			}
		}




		[Category("Data")]
		[Description("User defined data associated with the subitem.")]
		public object Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				this._tag = value;
			}
		}



		[Browsable(false)]
		public ContainerListViewItem Item
		{
			get
			{
				if (this._collection == null)
				{
					return null;
				}
				return this._collection.OwningItem;
			}
		}




		internal ContainerListViewSubItemCollection Collection
		{
			get
			{
				return this._collection;
			}
			set
			{
				this._collection = value;
			}
		}



		internal Size ItemControlInitialSize
		{
			get
			{
				return this._childControlInitialSize;
			}
		}


		public ContainerListViewSubItem Clone()
		{
			return new ContainerListViewSubItem(this._columnIndex)
			{
				_backColor = this._backColor,
				_childControlInitialSize = this._childControlInitialSize,
				_controlResizeBehavior = this._controlResizeBehavior,
				_font = this._font,
				_foreColor = this._foreColor,
				_tag = this._tag,
				_text = this._text
			};
		}


		public void Refresh()
		{
			if (this.Item != null)
			{
				this.Item.Refresh(this);
			}
		}


		public override string ToString()
		{
			if (this._childControl != null)
			{
				return this._childControl.Text;
			}
			return this._text;
		}


		private void ItemControl_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.Item != null && this.Item.ListView != null)
			{
				this.Item.ListView.SubItemItemControlMouseDown(this);
			}
		}


		private void ItemControl_TextChanged(object sender, EventArgs e)
		{
			this._text = this._childControl.Text;
		}


		object ICloneable.Clone()
		{
			return this.Clone();
		}


		private ContainerListViewSubItemCollection _collection;
		private int _columnIndex;
		private string _text = string.Empty;
		private Font _font;
		private Color _backColor = Color.Empty;
		private Color _foreColor = Color.Empty;
		private Size _childControlInitialSize = Size.Empty;
		private Control _childControl;
		private ControlResizeBehavior _controlResizeBehavior;
		private object _tag;
	}
}
