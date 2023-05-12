using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Rstd.Controls.ContainerListViews
{

	[DefaultProperty("Text")]
	[DesignTimeVisible(false)]
	[TypeConverter("DotNetLib.Windows.Forms.ContainerListViewItemConverter")]
	public class ContainerListViewItem : ICloneable
	{

		public ContainerListViewItem()
		{
			this._subItems = new ContainerListViewSubItemCollection(this);
			this._listView = null;
		}


		public ContainerListViewItem(string text) : this()
		{
			this.Text = text;
		}


		public ContainerListViewItem(string text, int imageIndex) : this()
		{
			this.Text = text;
			this._imageIndex = imageIndex;
		}


		public ContainerListViewItem(string text, int imageIndex, int selectedImageIndex) : this()
		{
			this.Text = text;
			this._imageIndex = imageIndex;
			this._selectedImageIndex = selectedImageIndex;
		}




		[Category("Appearance")]
		[Description("The color to use to paint the back color of the item.")]
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
				if (this._listView != null)
				{
					return this._listView.Font;
				}
				return Control.DefaultFont;
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
		[Description("The text of the first sub item of this item.")]
		[DefaultValue("")]
		public string Text
		{
			get
			{
				if (this._subItems.Count > 0)
				{
					return this._subItems[0].Text;
				}
				return string.Empty;
			}
			set
			{
				if (this._subItems.Count == 0 && this._listView == null)
				{
					this._subItems.Add(new ContainerListViewSubItem(0));
				}
				this._subItems[0].Text = value;
			}
		}




		[Category("Appearance")]
		[Description("The height of this item.")]
		[AmbientValue(-1)]
		public int Height
		{
			get
			{
				if (this._height != -1)
				{
					return this._height;
				}
				if (this._listView != null)
				{
					return this._listView.DefaultItemHeight;
				}
				return 17;
			}
			set
			{
				if (this._height != value)
				{
					this._height = value;
					this.Refresh();
				}
			}
		}




		[Category("Behavior")]
		[Description("Whether this item is currently expanded.")]
		[DefaultValue(false)]
		public bool Expanded
		{
			get
			{
				return this._expanded;
			}
			set
			{
				if (value)
				{
					this.Expand();
					return;
				}
				this.Collapse();
			}
		}




		[Category("Behavior")]
		[Description("The index into the image list for this item's image.")]
		[DefaultValue(-1)]
		public int ImageIndex
		{
			get
			{
				return this._imageIndex;
			}
			set
			{
				if (this._imageIndex != value)
				{
					this._imageIndex = value;
					this.Refresh();
				}
			}
		}




		[Category("Behavior")]
		[Description("The index into the image list for this item's image when it is selected.")]
		[DefaultValue(-1)]
		public int SelectedImageIndex
		{
			get
			{
				return this._selectedImageIndex;
			}
			set
			{
				if (this._selectedImageIndex != value)
				{
					this._selectedImageIndex = value;
					this.Refresh();
				}
			}
		}



		[Category("Behavior")]
		[Description("The items collection of sub controls.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
		public ContainerListViewSubItemCollection SubItems
		{
			get
			{
				return this._subItems;
			}
		}



		[Category("Data")]
		[Description("The child items contained in this item.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
		public ContainerListViewItemCollection Items
		{
			get
			{
				if (this._items == null)
				{
					this._items = new ContainerListViewItemCollection(this);
					this._items.InternalListView = this._listView;
				}
				return this._items;
			}
		}




		[Category("Data")]
		[Description("User defined data associated with the item.")]
		public object Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				foreach (object obj in ((IEnumerable)this.SubItems))
				{
					ContainerListViewSubItem containerListViewSubItem = (ContainerListViewSubItem)obj;
					if (containerListViewSubItem.ItemControl != null)
					{
						containerListViewSubItem.ItemControl.Tag = value;
					}
				}
				this._tag = value;
			}
		}




		[Browsable(false)]
		[DefaultValue(false)]
		public bool Selected
		{
			get
			{
				return this._listView != null && this._listView.GetItemSelected(this);
			}
			set
			{
				if (this._listView != null)
				{
					this._listView.SetItemSelected(this, value, true, true);
				}
			}
		}



		[Browsable(false)]
		public ContainerListViewItem PreviousVisibleItem
		{
			get
			{
				ContainerListViewItem containerListViewItem = this.PreviousItem;
				if (containerListViewItem == null)
				{
					containerListViewItem = this._parentItem;
				}
				else if (containerListViewItem.Expanded && containerListViewItem.HasChildren)
				{
					containerListViewItem = containerListViewItem.VeryLastItem;
				}
				if (containerListViewItem == null || containerListViewItem.ParentItem == null)
				{
					return null;
				}
				if (this._filter.Belongs(containerListViewItem))
				{
					return containerListViewItem;
				}
				return containerListViewItem.PreviousVisibleItem;
			}
		}



		[Browsable(false)]
		public ContainerListViewItem PreviousItem
		{
			get
			{
				if (this._container == null || this._previousItem == null)
				{
					return null;
				}
				if (this._filter.Belongs(this._previousItem))
				{
					return this._previousItem;
				}
				return this._previousItem.PreviousItem;
			}
		}



		[Browsable(false)]
		public ContainerListViewItem NextVisibleItem
		{
			get
			{
				ContainerListViewItem containerListViewItem;
				if (this._expanded && this._items != null && this._items.Count > 0)
				{
					containerListViewItem = this.FirstItem;
				}
				else
				{
					containerListViewItem = this.NextItem;
				}
				if (containerListViewItem == null)
				{
					ContainerListViewItem parentItem = this._parentItem;
					while (parentItem != null && containerListViewItem == null)
					{
						containerListViewItem = parentItem.NextItem;
						parentItem = parentItem.ParentItem;
					}
				}
				if (containerListViewItem == null || containerListViewItem.ParentItem == null)
				{
					return null;
				}
				if (this._filter.Belongs(containerListViewItem))
				{
					return containerListViewItem;
				}
				return containerListViewItem.NextVisibleItem;
			}
		}



		[Browsable(false)]
		public ContainerListViewItem NextItem
		{
			get
			{
				if (this._container == null || this._nextItem == null)
				{
					return null;
				}
				if (this._filter.Belongs(this._nextItem))
				{
					return this._nextItem;
				}
				return this._nextItem.NextItem;
			}
		}



		public ContainerListViewItem NextTreeItem
		{
			get
			{
				if (this._container == null)
				{
					return null;
				}
				if (this.HasChildren)
				{
					return this.FirstItem;
				}
				if (this._nextItem == null)
				{
					return this._parentItem._nextItem;
				}
				return this.NextItem;
			}
		}



		[Browsable(false)]
		public ContainerListViewItem FirstItem
		{
			get
			{
				if (this._items != null)
				{
					for (int i = 0; i < this._items.Count; i++)
					{
						ContainerListViewItem containerListViewItem = this._items[i];
						if (this._filter.Belongs(containerListViewItem))
						{
							return containerListViewItem;
						}
					}
				}
				return null;
			}
		}



		[Browsable(false)]
		public ContainerListViewItem LastItem
		{
			get
			{
				if (this._items != null)
				{
					for (int i = this._items.Count - 1; i >= 0; i--)
					{
						ContainerListViewItem containerListViewItem = this._items[i];
						if (this._filter.Belongs(containerListViewItem))
						{
							return containerListViewItem;
						}
					}
				}
				return null;
			}
		}



		[Browsable(false)]
		public ContainerListViewItem VeryLastItem
		{
			get
			{
				ContainerListViewItem lastItem = this.LastItem;
				if (lastItem != null)
				{
					if (lastItem.Expanded)
					{
						return lastItem.VeryLastItem;
					}
					return lastItem;
				}
				else
				{
					if (this._parentItem != null)
					{
						return this;
					}
					return null;
				}
			}
		}




		[Browsable(false)]
		[DefaultValue(false)]
		public bool Hovered
		{
			get
			{
				return this._listView != null && this._listView.GetItemHovered(this);
			}
			set
			{
				if (this._listView != null)
				{
					this._listView.SetItemHovered(this, value);
				}
			}
		}




		[Browsable(false)]
		public int Y
		{
			get
			{
				return this._y;
			}
			internal set
			{
				this._y = value;
			}
		}



		[Browsable(false)]
		public ContainerListView ListView
		{
			get
			{
				return this._listView;
			}
		}



		[Browsable(false)]
		public ContainerListViewItem ParentItem
		{
			get
			{
				return this._parentItem;
			}
		}



		[Browsable(false)]
		public int Depth
		{
			get
			{
				if (this._parentItem == null)
				{
					return 0;
				}
				return this._parentItem.Depth + 1;
			}
		}



		[Browsable(false)]
		[DefaultValue(false)]
		public bool IsFiltered
		{
			get
			{
				return !this._filter.Belongs(this) || (this._parentItem != null && this._parentItem.IsFiltered);
			}
		}




		[Browsable(false)]
		[DefaultValue(false)]
		public bool Focused
		{
			get
			{
				return this._listView != null && this._listView.GetItemFocused(this);
			}
			set
			{
				if (this._listView != null)
				{
					this._listView.SetItemFocused(this, value);
				}
			}
		}



		public bool HasChildren
		{
			get
			{
				if (this._hasChildren == NullableBoolean.NotSet)
				{
					return this._items != null && this._items.Count != 0;
				}
				return this._hasChildren == NullableBoolean.True;
			}
		}




		public NullableBoolean ForceHasChildren
		{
			get
			{
				return this._hasChildren;
			}
			set
			{
				if (this._hasChildren != value)
				{
					this._hasChildren = value;
					this.Refresh();
				}
			}
		}




		internal Rectangle Glyph
		{
			get
			{
				return this._glyph;
			}
			set
			{
				this._glyph = value;
			}
		}



		internal ContainerListView OwnerListView
		{
			set
			{
				this._listView = value;
				if (this._items != null)
				{
					this._items.InternalListView = value;
				}
				if (this._listView != null)
				{
					this._subItems.AdjustSize(this._listView.Columns.Count);
					if (!this._listView.InUpdateTransaction)
					{
						this._listView.RecalculateItemPositions(this.PreviousVisibleItem);
					}
				}
			}
		}




		internal ContainerListViewItem InternalParentItem
		{
			get
			{
				return this._parentItem;
			}
			set
			{
				this._parentItem = value;
				if (value == null)
				{
					this._container = null;
					return;
				}
				this._container = this._parentItem.Items;
			}
		}



		internal bool InternalIsVisible
		{
			get
			{
				return this._parentItem == null || (this._parentItem.HasChildren && this._parentItem.Expanded && this._parentItem.InternalIsVisible);
			}
		}




		internal ContainerListViewItem InternalPreviousItem
		{
			get
			{
				return this._previousItem;
			}
			set
			{
				this._previousItem = value;
			}
		}




		internal ContainerListViewItem InternalNextItem
		{
			get
			{
				return this._nextItem;
			}
			set
			{
				this._nextItem = value;
			}
		}


		public void BeginUpdate()
		{
			this._updateSuspended = true;
		}


		public void EndUpdate()
		{
			this._updateSuspended = false;
			this.Refresh();
		}


		internal ContainerListViewItem GetItemAt(int y)
		{
			ContainerListViewItem containerListViewItem = null;
			if (this._items != null)
			{
				for (int i = 0; i < this._items.Count; i++)
				{
					ContainerListViewItem containerListViewItem2 = this._items[i];
					if (y >= containerListViewItem2.Y && y < containerListViewItem2.Y + containerListViewItem2.Height && containerListViewItem2._filter.Belongs(containerListViewItem2))
					{
						return containerListViewItem2;
					}
					if (y < containerListViewItem2.Y && containerListViewItem != null && containerListViewItem.Expanded)
					{
						return containerListViewItem.GetItemAt(y);
					}
					containerListViewItem = containerListViewItem2;
				}
				if (containerListViewItem != null && containerListViewItem.Expanded)
				{
					return containerListViewItem.GetItemAt(y);
				}
			}
			return null;
		}


		public virtual void Expand()
		{
			if (this._expanded)
			{
				return;
			}
			if (this._listView != null)
			{
				ContainerListViewCancelEventArgs containerListViewCancelEventArgs = new ContainerListViewCancelEventArgs(null, this);
				this._listView.OnItemExpanding(containerListViewCancelEventArgs);
				if (containerListViewCancelEventArgs.Cancel)
				{
					return;
				}
			}
			this._expanded = true;
			if (this._items != null && this._items.Count > 0)
			{
				this._listView.RecalculateItemPositions(this);
			}
			else
			{
				this._listView.Invalidate();
			}
			if (this._listView != null)
			{
				this._listView.OnItemExpanded(new ContainerListViewEventArgs(null, this));
			}
		}


		public void Collapse()
		{
			if (!this._expanded)
			{
				return;
			}
			if (this._listView != null)
			{
				ContainerListViewCancelEventArgs containerListViewCancelEventArgs = new ContainerListViewCancelEventArgs(null, this);
				this._listView.OnItemCollapsing(containerListViewCancelEventArgs);
				if (containerListViewCancelEventArgs.Cancel)
				{
					return;
				}
			}
			this._expanded = false;
			if (this._items != null && this._items.Count > 0)
			{
				this._listView.RecalculateItemPositions(this);
			}
			else
			{
				this._listView.Invalidate();
			}
			if (this._listView != null)
			{
				this._listView.OnItemCollapsed(new ContainerListViewEventArgs(null, this));
			}
		}


		public void HideControls()
		{
			foreach (object obj in ((IEnumerable)this.SubItems))
			{
				ContainerListViewSubItem containerListViewSubItem = (ContainerListViewSubItem)obj;
				if (containerListViewSubItem.ItemControl != null)
				{
					containerListViewSubItem.ItemControl.Visible = false;
				}
			}
		}


		public void ShowControls()
		{
			foreach (object obj in ((IEnumerable)this.SubItems))
			{
				ContainerListViewSubItem containerListViewSubItem = (ContainerListViewSubItem)obj;
				if (containerListViewSubItem.ItemControl != null)
				{
					containerListViewSubItem.ItemControl.Visible = true;
				}
			}
		}


		public void SetFilter(IFilter filter, bool recursive)
		{
			if (filter == null)
			{
				filter = FilterStub.AllFilter;
			}
			this._filter = filter;
			try
			{
				if (recursive && this._items != null)
				{
					for (int i = 0; i < this._items.Count; i++)
					{
						this._items[i].SetFilter(this._filter, recursive);
					}
				}
			}
			catch (NullReferenceException)
			{
			}
			if (this._listView != null)
			{
				this._listView.RecalculateItemPositions(this);
			}
		}


		public void Refresh()
		{
			if (this._updateSuspended || this._listView == null || !this._listView.IsVisible(this))
			{
				return;
			}
			this._listView.Refresh(this);
		}


		public void Refresh(ContainerListViewSubItem subItem)
		{
			if (this._updateSuspended || this._listView == null || !this._listView.IsVisible(this))
			{
				return;
			}
			this._listView.Refresh(subItem);
		}


		internal void AddSubItem(int columnIndex)
		{
			this._subItems.Insert(columnIndex, new ContainerListViewSubItem(columnIndex));
		}


		internal void RemoveSubItem(int columnIndex)
		{
			this._subItems.RemoveAt(columnIndex);
			foreach (object obj in ((IEnumerable)this._items))
			{
				((ContainerListViewItem)obj).RemoveSubItem(columnIndex);
			}
		}


		public object Clone()
		{
			ContainerListViewItem containerListViewItem = new ContainerListViewItem();
			containerListViewItem._backColor = this._backColor;
			containerListViewItem._font = this._font;
			containerListViewItem._foreColor = this._foreColor;
			containerListViewItem._imageIndex = this._imageIndex;
			containerListViewItem._selectedImageIndex = this._selectedImageIndex;
			containerListViewItem._listView = this._listView;
			containerListViewItem._tag = this._tag;
			for (int i = 0; i < this._subItems.Count; i++)
			{
				containerListViewItem._subItems[i] = this._subItems[i].Clone();
			}
			return containerListViewItem;
		}


		private Color _backColor = Color.Empty;


		private Color _foreColor = Color.Empty;


		private Font _font;


		private int _imageIndex = -1;


		private int _selectedImageIndex = -1;


		private ContainerListView _listView;


		private ContainerListViewSubItemCollection _subItems;


		private ContainerListViewItem _parentItem;


		private ContainerListViewItem _previousItem;


		private ContainerListViewItem _nextItem;


		private ContainerListViewItemCollection _items;


		private ContainerListViewItemCollection _container;


		private int _y;


		private bool _expanded;


		private NullableBoolean _hasChildren;


		private int _height = -1;


		private object _tag;


		private IFilter _filter = FilterStub.AllFilter;


		private Rectangle _glyph;


		private bool _updateSuspended;
	}
}
