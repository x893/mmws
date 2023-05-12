using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rstd.Controls.ContainerListViews
{

	[DefaultProperty("Text")]
	[DesignTimeVisible(false)]
	[ToolboxItem(false)]
	[TypeConverter("DotNetLib.Windows.Forms.ContainerListViewColumnHeaderConverter")]
	public class ContainerListViewColumnHeader : Component, ICloneable
	{

		public ContainerListViewColumnHeader()
		{
		}


		public ContainerListViewColumnHeader(string text)
		{
			if (text == null)
			{
				this._text = string.Empty;
				return;
			}
			this._text = text;
		}


		public ContainerListViewColumnHeader(string text, int width)
		{
			if (text == null)
			{
				this._text = string.Empty;
			}
			else
			{
				this._text = text;
			}
			this._width = width;
		}


		public ContainerListViewColumnHeader(string text, int width, HorizontalAlignment horizontalAlign)
		{
			if (text == null)
			{
				this._text = string.Empty;
			}
			else
			{
				this._text = text;
			}
			this._width = width;
			switch (horizontalAlign)
			{
			case HorizontalAlignment.Left:
				this._contentAlign = ContentAlignment.MiddleLeft;
				return;
			case HorizontalAlignment.Right:
				this._contentAlign = ContentAlignment.MiddleRight;
				return;
			case HorizontalAlignment.Center:
				this._contentAlign = ContentAlignment.MiddleCenter;
				return;
			default:
				return;
			}
		}


		public ContainerListViewColumnHeader(string text, int width, ContentAlignment contentAlign)
		{
			if (text == null)
			{
				this._text = string.Empty;
			}
			else
			{
				this._text = text;
			}
			this._width = width;
			this._contentAlign = contentAlign;
		}


		private bool ShouldSerializeFont()
		{
			return this._font != null;
		}




		[Category("Appearance")]
		[Description("The image to display in this header.")]
		[DefaultValue(null)]
		public Image Image
		{
			get
			{
				return this._image;
			}
			set
			{
				if (this._image != value)
				{
					this._image = value;
					this.Refresh(false, false);
				}
			}
		}




		[Category("Appearance")]
		[Description("The color to use to paint the text of the column header.")]
		[DefaultValue(typeof(Color), "ControlText")]
		public Color ForeColor
		{
			get
			{
				return this._foregroundBrush.Color;
			}
			set
			{
				if (this._foregroundBrush.Color != value)
				{
					this._foregroundBrush.Color = value;
					this.Refresh(false, false);
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
				if (this.ListView != null)
				{
					return this.ListView.Font;
				}
				return Control.DefaultFont;
			}
			set
			{
				if (this._font != value)
				{
					this._font = value;
					this.Refresh(false, false);
				}
			}
		}




		[Category("Appearance")]
		[Description("The title of this column header.")]
		[DefaultValue("")]
		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				if (this._text != value)
				{
					this._text = value;
					this.Refresh(false, false);
				}
			}
		}




		[Category("Appearance")]
		[Description("The alignment of the column headers content (text, image, sort icon).")]
		[DefaultValue(ContentAlignment.MiddleLeft)]
		public ContentAlignment ContentAlign
		{
			get
			{
				return this._contentAlign;
			}
			set
			{
				if (this._contentAlign != value)
				{
					this._contentAlign = value;
					this.Refresh(false, true);
				}
			}
		}




		[Category("Appearance")]
		[Description("The tooltip of the column")]
		[DefaultValue("")]
		public string ToolTip
		{
			get
			{
				return this._toolTip;
			}
			set
			{
				this._toolTip = value + string.Empty;
			}
		}




		[Category("Behavior")]
		[Description("The width in pixels of this column header.")]
		[DefaultValue(90)]
		public int Width
		{
			get
			{
				if (this._width < this._minimumWidth)
				{
					return this._minimumWidth;
				}
				if (this._maximumWidth != 0 && this._width > this._maximumWidth)
				{
					return this._maximumWidth;
				}
				return this._width;
			}
			set
			{
				if (value != this._width || value < 0)
				{
					if (value < 0)
					{
						this.AutoSizeWidth(value == -1);
						return;
					}
					this._width = value;
					this.Refresh(true, true);
				}
			}
		}




		[Category("Behavior")]
		[Description("The minimum width in pixels this column is allowed to be.")]
		[DefaultValue(0)]
		public int MinimumWidth
		{
			get
			{
				return this._minimumWidth;
			}
			set
			{
				this._minimumWidth = value;
				if (this._width < this._minimumWidth)
				{
					this.Refresh(false, true);
				}
			}
		}




		[Category("Behavior")]
		[Description("The maximum width in pixels this column is allowed to be. (0 = no max)")]
		[DefaultValue(0)]
		public int MaximumWidth
		{
			get
			{
				return this._maximumWidth;
			}
			set
			{
				this._maximumWidth = value;
				if (this._width > this._maximumWidth)
				{
					this.Refresh(false, true);
				}
			}
		}




		[Category("Behavior")]
		[Description("The behavior of the column when the list or other columns change size.")]
		[DefaultValue(ColumnWidthBehavior.Normal)]
		public ColumnWidthBehavior WidthBehavior
		{
			get
			{
				return this._widthBehavior;
			}
			set
			{
				this._widthBehavior = value;
			}
		}




		[Category("Behavior")]
		[Description("Determines whether the column is visible or hidden.")]
		[DefaultValue(true)]
		public bool Visible
		{
			get
			{
				return this._visible;
			}
			set
			{
				if (value != this._visible)
				{
					this._visible = value;
					this.Refresh(true, true);
				}
			}
		}




		[Category("Data")]
		[Description("User defined data associated with the Column")]
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




		[Category("Sorting")]
		[Description("What comparisons to use when sorting this column")]
		[DefaultValue(SortDataType.None)]
		public SortDataType SortDataType
		{
			get
			{
				return this._sortDataType;
			}
			set
			{
				this._sortDataType = value;
				if (this._sortDataType == SortDataType.None)
				{
					this._sortOrder = SortOrder.None;
				}
			}
		}




		public object CustomSortTag
		{
			get
			{
				return this._customSortTag;
			}
			set
			{
				this._customSortTag = value;
			}
		}




		[Category("Sorting")]
		[Description("What sort order this column will use when first sorted")]
		[DefaultValue(SortOrder.Ascending)]
		public SortOrder DefaultSortOrder
		{
			get
			{
				return this._defaultSortOrder;
			}
			set
			{
				this._defaultSortOrder = value;
			}
		}




		[Browsable(false)]
		[DefaultValue(null)]
		public IComparer CustomSortComparer
		{
			get
			{
				return this._customSort;
			}
			set
			{
				this._customSort = value;
			}
		}



		[Browsable(false)]
		public ContainerListView ListView
		{
			get
			{
				if (this._collection == null)
				{
					return null;
				}
				return this._collection.ListView;
			}
		}



		[Browsable(false)]
		[DefaultValue(SortOrder.None)]
		public SortOrder SortOrder
		{
			get
			{
				return this._sortOrder;
			}
		}



		[Browsable(false)]
		public int Index
		{
			get
			{
				if (this.ListView != null)
				{
					return this.ListView.GetColumnIndex(this);
				}
				return -1;
			}
		}




		[Browsable(false)]
		[DefaultValue(0)]
		public int DisplayIndex
		{
			get
			{
				if (this._collection != null)
				{
					return this._collection.DisplayIndexOf(this);
				}
				return 0;
			}
			set
			{
				if (this._collection != null)
				{
					this._collection.SetDisplayIndex(this, value);
				}
			}
		}




		[Browsable(false)]
		[DefaultValue(false)]
		public bool Hovered
		{
			get
			{
				return this.ListView != null && this.ListView.GetColumnHovered(this);
			}
			set
			{
				if (this.ListView != null)
				{
					this.ListView.SetColumnHovered(this, value);
				}
			}
		}




		[Browsable(false)]
		[DefaultValue(false)]
		public bool Pressed
		{
			get
			{
				return this.ListView != null && this.ListView.GetColumnPressed(this);
			}
			set
			{
				if (this.ListView != null)
				{
					this.ListView.SetColumnPressed(this, value);
				}
			}
		}




		internal ContainerListViewColumnHeaderCollection Collection
		{
			get
			{
				return this._collection;
			}
			set
			{
				if (this._collection != value)
				{
					this._collection = value;
					if (this._collection != null)
					{
						this.Width = this._width;
						this.Refresh(true, true);
					}
				}
			}
		}



		internal SortOrder InternalSortOrder
		{
			set
			{
				this._sortOrder = value;
			}
		}


		public void AutoSizeWidth(bool includeItemWidths)
		{
			int num = 0;
			if (includeItemWidths && this.ListView != null)
			{
				num = this.AutoSizeItems(this.ListView.Items);
			}
			int num2 = ContainerListViewColumnHeader.GetStringWidth(this._text, this.Font) + 5;
			if (num2 > num)
			{
				num = num2;
			}
			num += 5;
			this.Width = num;
		}


		private int AutoSizeItems(ContainerListViewItemCollection items)
		{
			int index = this.Index;
			int displayIndex = this.DisplayIndex;
			int num = 0;
			int num2 = 0;
			if (displayIndex == 0 && (this.ListView.ShowPlusMinus || (this.ListView.ShowTreeLines && this.ListView.ShowRootTreeLines)))
			{
				num2 += 16;
			}
			for (int i = 0; i < items.Count; i++)
			{
				int num3 = 0;
				ContainerListViewItem containerListViewItem = items[i];
				Font font = containerListViewItem.Font;
				if (font == null)
				{
					font = this.Font;
				}
				if (containerListViewItem.ImageIndex > -1 || containerListViewItem.SelectedImageIndex > -1)
				{
					num3 += 16;
				}
				if (displayIndex == 0)
				{
					num3 += num2 + 16 * (containerListViewItem.Depth - 1);
				}
				num3 += ContainerListViewColumnHeader.GetStringWidth(containerListViewItem.SubItems[index].Text, font) + 10;
				num3 += 5;
				if (num3 > num)
				{
					num = num3;
				}
				if (containerListViewItem.HasChildren && containerListViewItem.Expanded)
				{
					num3 = this.AutoSizeItems(containerListViewItem.Items);
					if (num3 > num)
					{
						num = num3;
					}
				}
			}
			return num;
		}


		private void Refresh(bool recalculateLayout, bool redrawItems)
		{
			if (this.ListView != null)
			{
				this.ListView.ColumnInvalidated(this, recalculateLayout, redrawItems);
			}
		}


		private static int GetStringWidth(string text, Font fnt)
		{
			int result;
			using (Graphics graphics = Graphics.FromImage(new Bitmap(32, 32)))
			{
				result = (int)graphics.MeasureString(text, fnt).Width;
			}
			return result;
		}


		public ContainerListViewColumnHeader Clone()
		{
			ContainerListViewColumnHeader containerListViewColumnHeader = new ContainerListViewColumnHeader();
			containerListViewColumnHeader._text = this._text;
			containerListViewColumnHeader._contentAlign = this._contentAlign;
			containerListViewColumnHeader._foregroundBrush = this._foregroundBrush;
			containerListViewColumnHeader._font = this._font;
			containerListViewColumnHeader._width = this._width;
			containerListViewColumnHeader._maximumWidth = this._maximumWidth;
			containerListViewColumnHeader._minimumWidth = this._minimumWidth;
			containerListViewColumnHeader._visible = this._visible;
			containerListViewColumnHeader._sortDataType = this._sortDataType;
			containerListViewColumnHeader._defaultSortOrder = this._defaultSortOrder;
			containerListViewColumnHeader._customSort = this._customSort;
			containerListViewColumnHeader._sortOrder = this._sortOrder;
			containerListViewColumnHeader._customSortTag = this._customSortTag;
			containerListViewColumnHeader._tag = this._tag;
			containerListViewColumnHeader._toolTip = this._toolTip;
			if (this._image != null)
			{
				containerListViewColumnHeader._image = (this._image.Clone() as Image);
			}
			return containerListViewColumnHeader;
		}


		object ICloneable.Clone()
		{
			return this.Clone();
		}


		private ContainerListViewColumnHeaderCollection _collection;


		private string _text = string.Empty;


		private Image _image;


		private ContentAlignment _contentAlign = ContentAlignment.MiddleLeft;


		private SolidBrush _foregroundBrush = SystemBrushes.ControlText as SolidBrush;


		private Font _font;


		private int _width = 90;


		private int _maximumWidth;


		private int _minimumWidth;


		private ColumnWidthBehavior _widthBehavior;


		private bool _visible = true;


		private object _tag;


		private SortDataType _sortDataType;


		private object _customSortTag;


		private SortOrder _defaultSortOrder = SortOrder.Ascending;


		private SortOrder _sortOrder;


		private IComparer _customSort;


		private string _toolTip = string.Empty;
	}
}
