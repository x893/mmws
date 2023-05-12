using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Rstd.Controls.ContainerListViews.Design;
using RSTD.Properties;

namespace Rstd.Controls.ContainerListViews
{

    [DefaultProperty("Items")]
    [Designer(typeof(ContainerListViewDesigner))]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ContainerListView), "Resources.listview.bmp")]
    [DefaultEvent("SelectedItemsChanged")]
    public class ContainerListView : Control
    {



        [Category("Appearance")]
        [Description("The default background color of items in the list.")]
        [DefaultValue(typeof(Color), "Window")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }




        [Category("Appearance")]
        [Description("Specifies the height of the header.")]
        [DefaultValue(20)]
        public int HeaderHeight
        {
            get
            {
                return this._userHeaderHeight;
            }
            set
            {
                if (value != this._userHeaderHeight)
                {
                    this._userHeaderHeight = value;
                    this.HeaderStyle = this.HeaderStyle;
                    this.RecalculateLayout(true, false);
                    base.Invalidate();
                }
            }
        }


        public Rectangle HeaderColumnRect(int column_index)
        {
            return this._headerColumnRects[column_index];
        }




        [Category("Appearance")]
        [Description("Specifies whether the control will attempt to use Visual Styles when rendering the control.")]
        [DefaultValue(true)]
        public bool VisualStyles
        {
            get
            {
                return this._visualStyles;
            }
            set
            {
                if (this._visualStyles != value)
                {
                    this._visualStyles = value;
                    this.BorderStyle = this.BorderStyle;
                }
            }
        }




        [Category("Behavior")]
        [Description("Specifies wether the control will capture the click used to focus the control and adjust the selection accordingly, or not.")]
        [DefaultValue(true)]
        public bool CaptureFocusClick
        {
            get
            {
                return this._captureFocusClick;
            }
            set
            {
                this._captureFocusClick = value;
            }
        }




        [Category("Behavior")]
        [Description("The context menu displayed when the header is right-clicked.")]
        [DefaultValue(null)]
        public ContextMenuStrip HeaderContextMenu
        {
            get
            {
                return this._headerMenu;
            }
            set
            {
                this._headerMenu = value;
            }
        }




        [Category("Behavior")]
        [Description("The context menu displayed when an item is right-clicked.")]
        [DefaultValue(null)]
        public ContextMenuStrip ItemContextMenu
        {
            get
            {
                return this._itemMenu;
            }
            set
            {
                this._itemMenu = value;
            }
        }




        [Category("Behavior")]
        [Description("The context menu displayed when the control is right-clicked.")]
        [DefaultValue(null)]
        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this._contextMenu;
            }
            set
            {
                this._contextMenu = value;
            }
        }



        [Category("Behavior")]
        [Description("The lists column headers.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public ContainerListViewColumnHeaderCollection Columns
        {
            get
            {
                return this._columns;
            }
        }



        [Category("Data")]
        [Description("The items contained at the root of the list.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public virtual ContainerListViewItemCollection Items
        {
            get
            {
                return this._items;
            }
        }




        [Category("Behavior")]
        [Description("Specifies what action activates and item.")]
        [DefaultValue(ItemActivation.Standard)]
        public ItemActivation Activation
        {
            get
            {
                return this._activationMethod;
            }
            set
            {
                this._activationMethod = value;
            }
        }




        [Category("Behavior")]
        [Description("Specifies whether column headers may be reordered.")]
        [DefaultValue(false)]
        public bool AllowColumnReorder
        {
            get
            {
                return this._allowColumnReorder;
            }
            set
            {
                this._allowColumnReorder = value;
            }
        }




        [Category("Behavior")]
        [Description("Specifies whether column headers may be resized.")]
        [DefaultValue(true)]
        public bool AllowColumnResize
        {
            get
            {
                return this._allowColumnResize;
            }
            set
            {
                if (this._allowColumnResize == value)
                {
                    return;
                }
                this._allowColumnResize = value;
                this.RecalculateLayout(false, false);
            }
        }




        [Category("Appearance")]
        [Description("Specifies what style border the control has.")]
        [DefaultValue(BorderStyle.Fixed3D)]
        public BorderStyle BorderStyle
        {
            get
            {
                return this._borderStyle;
            }
            set
            {
                if (this._borderStyle == value)
                {
                    return;
                }
                this._borderStyle = value;
                if (this.UseVisualStyle || this._borderStyle == BorderStyle.Fixed3D)
                {
                    this._borderSize = 2;
                }
                else if (this._borderStyle == BorderStyle.FixedSingle)
                {
                    this._borderSize = 1;
                }
                else
                {
                    this._borderSize = 0;
                }
                this.RecalculateLayout(true, false);
                base.Invalidate();
            }
        }




        [Category("Appearance")]
        [Description("Specifies wether to show column headers, and whether they respond to mouse clicks.")]
        [DefaultValue(ColumnHeaderStyle.Clickable)]
        public ColumnHeaderStyle HeaderStyle
        {
            get
            {
                return this._headerStyle;
            }
            set
            {
                if (this._headerStyle == value)
                {
                    return;
                }
                this._headerStyle = value;
                if (this._headerStyle == ColumnHeaderStyle.None)
                {
                    this._headerHeight = 0;
                }
                else
                {
                    this._headerHeight = this._userHeaderHeight;
                }
                this.RecalculateLayout(false, false);
                base.Invalidate();
            }
        }




        [Category("Behavior")]
        [Description("Enables column tracking, highlighting the column when the mouse hovers over its header.")]
        [DefaultValue(false)]
        public bool ColumnTracking
        {
            get
            {
                return this._columnTracking;
            }
            set
            {
                this._columnTracking = value;
            }
        }




        [Category("Appearance")]
        [Description("Specifies the color used for column hot-tracking.")]
        [DefaultValue(typeof(Color), "WhiteSmoke")]
        public Color ColumnTrackingColor
        {
            get
            {
                return this._columnTrackingBrush.Color;
            }
            set
            {
                this._columnTrackingBrush.Color = value;
            }
        }




        [Category("Appearance")]
        [Description("Specifies the color used for the currently selected sorting column.")]
        [DefaultValue(typeof(Color), "Gainsboro")]
        public Color ColumnSortColor
        {
            get
            {
                return this._columnSortBrush.Color;
            }
            set
            {
                this._columnSortBrush.Color = value;
            }
        }




        [Category("Behavior")]
        [Description("Enables item tracking, highlighting the item gray when the mouse hovers over it.")]
        [DefaultValue(false)]
        public bool ItemTracking
        {
            get
            {
                return this._itemTracking;
            }
            set
            {
                this._itemTracking = value;
            }
        }




        [Category("Appearance")]
        [Description("Specifies the color used for item hot-tracking.")]
        [DefaultValue(typeof(Color), "WhiteSmoke")]
        public Color ItemTrackingColor
        {
            get
            {
                return this._itemTrackingBrush.Color;
            }
            set
            {
                this._itemTrackingBrush.Color = value;
            }
        }




        [Category("Appearance")]
        [Description("Specifies the color used for selected items.")]
        [DefaultValue(typeof(Color), "Highlight")]
        public Color ItemSelectedColor
        {
            get
            {
                return this._itemSelectedColor;
            }
            set
            {
                this._itemSelectedColor = value;
            }
        }




        [Category("Behavior")]
        [Description("Determines wether to highlight the full item or just the label of selected items.")]
        [DefaultValue(true)]
        public bool FullItemSelect
        {
            get
            {
                return this._fullItemSelect;
            }
            set
            {
                this._fullItemSelect = value;
            }
        }




        [Category("Appearance")]
        [Description("Specifies the color used for grid lines.")]
        [DefaultValue(typeof(Color), "WhiteSmoke")]
        public Color GridLineColor
        {
            get
            {
                return this._gridLinePen.Color;
            }
            set
            {
                this._gridLinePen.Color = value;
            }
        }




        [Category("Behavior")]
        [Description("Specifies wether to show grid lines.")]
        [DefaultValue(false)]
        public bool ShowPlusMinus
        {
            get
            {
                return this._showPlusMinus;
            }
            set
            {
                if (this._showPlusMinus == value)
                {
                    return;
                }
                this._showPlusMinus = value;
                this.RecalculateItemPositions(this._rootItem);
                base.Invalidate();
            }
        }




        [Category("Behavior")]
        [Description("Specifies wether to show grid lines.")]
        [DefaultValue(false)]
        public bool ShowRootTreeLines
        {
            get
            {
                return this._showRootTreeLines;
            }
            set
            {
                if (this._showRootTreeLines == value)
                {
                    return;
                }
                this._showRootTreeLines = value;
                this.RecalculateItemPositions(this._rootItem);
                base.Invalidate();
            }
        }




        [Category("Appearance")]
        [Description("The default item height for items.")]
        [DefaultValue(17)]
        public int DefaultItemHeight
        {
            get
            {
                return this._defaultItemHeight;
            }
            set
            {
                if (this._defaultItemHeight == value)
                {
                    return;
                }
                this._defaultItemHeight = value;
                this._vScrollBar.SmallChange = value;
                this.RecalculateItemPositions(this._rootItem);
                base.Invalidate();
            }
        }




        [Category("Behavior")]
        [Description("Specifies whether to show grid lines.")]
        [DefaultValue(false)]
        public bool ShowTreeLines
        {
            get
            {
                return this._showTreeLines;
            }
            set
            {
                if (this._showTreeLines == value)
                {
                    return;
                }
                this._showTreeLines = value;
                this.RecalculateItemPositions(this._rootItem);
                base.Invalidate();
            }
        }




        [Category("Behavior")]
        [Description("Specifies whether and which grid lines to show.")]
        [DefaultValue(GridLines.None)]
        public GridLines GridLines
        {
            get
            {
                return this._gridLines;
            }
            set
            {
                if (this._gridLines == value)
                {
                    return;
                }
                this._gridLines = value;
                base.Invalidate();
            }
        }




        [Category("Behavior")]
        [Description("The lists small image list (16x16).")]
        [DefaultValue(null)]
        public ImageList SmallImageList
        {
            get
            {
                return this._smallImageList;
            }
            set
            {
                if (this._smallImageList == value)
                {
                    return;
                }
                this._smallImageList = value;
                base.Invalidate();
            }
        }




        [Category("Behavior")]
        [Description("The lists custom state image list (16x16).")]
        [DefaultValue(null)]
        public ImageList SelectedImageList
        {
            get
            {
                return this._selectedImageList;
            }
            set
            {
                this._selectedImageList = value;
            }
        }




        [Category("Behavior")]
        [Description("Determines whether to hide the selected items when the control looses focus.")]
        [DefaultValue(true)]
        public bool HideSelection
        {
            get
            {
                return this._hideSelection;
            }
            set
            {
                if (this._hideSelection != value)
                {
                    this._hideSelection = value;
                    base.Invalidate();
                }
            }
        }




        [Category("Behavior")]
        [Description("Determines whether to automatically select a item when the mouse is hovered over it for a short time.")]
        [DefaultValue(false)]
        public bool HoverSelection
        {
            get
            {
                return this._hoverSelection;
            }
            set
            {
                this._hoverSelection = value;
            }
        }




        [Category("Behavior")]
        [Description("Determines whether the control will allow multiple selections.")]
        [DefaultValue(false)]
        public bool AllowMultiSelect
        {
            get
            {
                return this._allowMultipleSelect;
            }
            set
            {
                this._allowMultipleSelect = value;
                if (!this._allowMultipleSelect && this._selectedItems.Count > 1)
                {
                    if (this._focusedItem != null)
                    {
                        this.SetItemSelected(this._focusedItem, true, true, false);
                        return;
                    }
                    this.SetItemSelected(this._selectedItems[0], true, true, false);
                }
            }
        }




        [Category("Behavior")]
        [Description("Determines whether the control will allow a multiple column sort.")]
        [DefaultValue(false)]
        public bool MultipleColumnSort
        {
            get
            {
                return this._allowMultipleColumnSort;
            }
            set
            {
                this._allowMultipleColumnSort = value;
            }
        }




        public bool ReorderingColumn
        {
            get
            {
                return this._reorderingColumn;
            }
            set
            {
                this._reorderingColumn = value;
            }
        }



        [Browsable(false)]
        public ContainerListViewItem TopItem
        {
            get
            {
                return this.GetItemAt(this._vScrollBar.Value);
            }
        }



        [Browsable(false)]
        public ContainerListViewItem BottomItemCompletelyVisible
        {
            get
            {
                ContainerListViewItem containerListViewItem = this.BottomItemPartiallyVisible;
                if (containerListViewItem.Y + containerListViewItem.Height > this._vScrollBar.Value + this._detailVisibleRect.Height)
                {
                    containerListViewItem = containerListViewItem.PreviousItem;
                }
                return containerListViewItem;
            }
        }



        [Browsable(false)]
        public ContainerListViewItem BottomItemPartiallyVisible
        {
            get
            {
                ContainerListViewItem containerListViewItem = this.GetItemAt(this._vScrollBar.Value + this._detailVisibleRect.Height);
                if (containerListViewItem == null)
                {
                    containerListViewItem = this._rootItem.VeryLastItem;
                }
                return containerListViewItem;
            }
        }



        [Browsable(false)]
        public ContainerListViewColumnHeader[] SortColumns
        {
            get
            {
                return (ContainerListViewColumnHeader[])this._columnsSorted.ToArray(typeof(ContainerListViewColumnHeader));
            }
        }



        [Browsable(false)]
        public ContainerListViewSelectedItemCollection SelectedItems
        {
            get
            {
                return this._selectedItems;
            }
        }



        protected internal bool InUpdateTransaction
        {
            get
            {
                return this._updateTransactions.Count > 0;
            }
        }



        internal bool UseVisualStyle
        {
            get
            {
                return this.VisualStyles & (!base.DesignMode && Application.RenderWithVisualStyles);
            }
        }



        internal ContainerListViewItem RootItem
        {
            get
            {
                return this._rootItem;
            }
        }


        public ContainerListView()
        {
            this.Construct();
        }


        private void Construct()
        {
            base.SetStyle(ControlStyles.ContainerControl | ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.BackColor = SystemColors.Window;
            this._columns = new ContainerListViewColumnHeaderCollection(this);
            this._columnDisplayOrder = new ArrayList();
            this._columnsSorted = new ArrayList();
            this._rootItem = new ContainerListViewItem();
            this._rootItem.OwnerListView = this;
            this._rootItem.Height = 0;
            this._rootItem.Expanded = true;
            this._items = this._rootItem.Items;
            this._selectedItems = new ContainerListViewSelectedItemCollection(this);
            this._headerHeight = 20;
            this._defaultItemHeight = 20;
            this._hScrollBar = new HScrollBar();
            this._hScrollBar.Parent = this;
            this._hScrollBar.Minimum = 0;
            this._hScrollBar.Maximum = 0;
            this._hScrollBar.SmallChange = 10;
            this._hScrollBar.Hide();
            this._vScrollBar = new VScrollBar();
            this._vScrollBar.Parent = this;
            this._vScrollBar.Minimum = 0;
            this._vScrollBar.Maximum = 0;
            this._vScrollBar.SmallChange = this.DefaultItemHeight;
            this._vScrollBar.Hide();
            this._hScrollBar.ValueChanged += this.OnScroll;
            this._vScrollBar.ValueChanged += this.OnScroll;
            this._vScrollBar.Scroll += this._vScrollBar_Scroll;
            this.RecalculateLayout(false, false);
            this._toolTipControl = new ToolTip();
            this._toolTipControl.InitialDelay = 2000;
            this._toolTipControl.AutoPopDelay = 5000;
            this._toolTipControl.ReshowDelay = 1000;
        }




        public event EventHandler SelectedItemsChanged
        {
            add
            {
                this._selectedItemsChanged = (EventHandler)Delegate.Combine(this._selectedItemsChanged, value);
            }
            remove
            {
                this._selectedItemsChanged = (EventHandler)Delegate.Remove(this._selectedItemsChanged, value);
            }
        }




        public event ContainerListViewEventHandler ColumnClick
        {
            add
            {
                this._columnClick = (ContainerListViewEventHandler)Delegate.Combine(this._columnClick, value);
            }
            remove
            {
                this._columnClick = (ContainerListViewEventHandler)Delegate.Remove(this._columnClick, value);
            }
        }




        public event ContainerListViewEventHandler PopColumnHeaderContextMenu
        {
            add
            {
                this._popColumnContextMenu = (ContainerListViewEventHandler)Delegate.Combine(this._popColumnContextMenu, value);
            }
            remove
            {
                this._popColumnContextMenu = (ContainerListViewEventHandler)Delegate.Remove(this._popColumnContextMenu, value);
            }
        }




        public event ContainerListViewEventHandler ColumnReordered
        {
            add
            {
                this._columnReordered = (ContainerListViewEventHandler)Delegate.Combine(this._columnReordered, value);
            }
            remove
            {
                this._columnReordered = (ContainerListViewEventHandler)Delegate.Remove(this._columnReordered, value);
            }
        }




        public event ContainerListViewEventHandler PopItemContextMenu
        {
            add
            {
                this._popItemContextMenu = (ContainerListViewEventHandler)Delegate.Combine(this._popItemContextMenu, value);
            }
            remove
            {
                this._popItemContextMenu = (ContainerListViewEventHandler)Delegate.Remove(this._popItemContextMenu, value);
            }
        }




        public event ContainerListViewEventHandler PopContextMenu
        {
            add
            {
                this._popContextMenu = (ContainerListViewEventHandler)Delegate.Combine(this._popContextMenu, value);
            }
            remove
            {
                this._popContextMenu = (ContainerListViewEventHandler)Delegate.Remove(this._popContextMenu, value);
            }
        }




        public event ContainerListViewCancelEventHandler ItemExpanding
        {
            add
            {
                this._itemExpanding = (ContainerListViewCancelEventHandler)Delegate.Combine(this._itemExpanding, value);
            }
            remove
            {
                this._itemExpanding = (ContainerListViewCancelEventHandler)Delegate.Remove(this._itemExpanding, value);
            }
        }




        public event ContainerListViewEventHandler ItemExpanded
        {
            add
            {
                this._itemExpanded = (ContainerListViewEventHandler)Delegate.Combine(this._itemExpanded, value);
            }
            remove
            {
                this._itemExpanded = (ContainerListViewEventHandler)Delegate.Remove(this._itemExpanded, value);
            }
        }




        public event ContainerListViewCancelEventHandler ItemCollapsing
        {
            add
            {
                this._itemCollapsing = (ContainerListViewCancelEventHandler)Delegate.Combine(this._itemCollapsing, value);
            }
            remove
            {
                this._itemCollapsing = (ContainerListViewCancelEventHandler)Delegate.Remove(this._itemCollapsing, value);
            }
        }




        public event ContainerListViewEventHandler ItemCollapsed
        {
            add
            {
                this._itemCollapsed = (ContainerListViewEventHandler)Delegate.Combine(this._itemCollapsed, value);
            }
            remove
            {
                this._itemCollapsed = (ContainerListViewEventHandler)Delegate.Remove(this._itemCollapsed, value);
            }
        }




        public event ItemDragEventHandler ItemDrag
        {
            add
            {
                this._itemDrag = (ItemDragEventHandler)Delegate.Combine(this._itemDrag, value);
            }
            remove
            {
                this._itemDrag = (ItemDragEventHandler)Delegate.Remove(this._itemDrag, value);
            }
        }


        protected void OnColumnClick(ContainerListViewEventArgs e)
        {
            if (this._columnClick != null)
            {
                this._columnClick(this, e);
            }
            this.Sort(e.ColumnHeader.Index, true, (Control.ModifierKeys & Keys.Control) != Keys.Control);
        }


        protected void OnColumnReorder(ContainerListViewEventArgs e)
        {
            if (this._columnReordered != null)
            {
                this._columnReordered(this, e);
            }
        }


        protected void OnSelectedItemsChanged()
        {
            if (this._selectedItemsChanged != null)
            {
                this._selectedItemsChanged(this, EventArgs.Empty);
            }
        }


        protected void OnPopContextMenu(ContainerListViewEventArgs e)
        {
            if (this._popContextMenu != null)
            {
                this._popContextMenu(this, e);
            }
            this.PopMenu(this._contextMenu, e);
        }


        protected void OnPopItemContextMenu(ContainerListViewEventArgs e)
        {
            if (this._popItemContextMenu != null)
            {
                this._popItemContextMenu(this, e);
            }
            if (this._itemMenu != null)
            {
                this.PopMenu(this._itemMenu, e);
            }
        }


        protected void OnPopColumnContextMenu(ContainerListViewEventArgs e)
        {
            if (this._popColumnContextMenu != null)
            {
                this._popColumnContextMenu(this, e);
            }
            if (this._headerMenu == null)
            {
                this.PopMenu(this._contextMenu, e);
                return;
            }
            this.PopMenu(this._headerMenu, e);
        }


        protected internal void OnItemExpanding(ContainerListViewCancelEventArgs e)
        {
            if (this._itemExpanding != null)
            {
                this._itemExpanding(this, e);
            }
        }


        protected internal void OnItemExpanded(ContainerListViewEventArgs e)
        {
            if (this._itemExpanded != null)
            {
                this._itemExpanded(this, e);
            }
        }


        protected internal void OnItemCollapsing(ContainerListViewCancelEventArgs e)
        {
            if (this._itemCollapsing != null)
            {
                this._itemCollapsing(this, e);
            }
        }


        protected internal void OnItemCollapsed(ContainerListViewEventArgs e)
        {
            if (this._itemCollapsed != null)
            {
                this._itemCollapsed(this, e);
            }
        }


        protected void OnItemDrag(ItemDragEventArgs e)
        {
            if (this._itemDrag != null)
            {
                this._itemDrag(this, e);
            }
        }


        protected internal virtual void SubItemItemControlMouseDown(ContainerListViewSubItem subItem)
        {
        }


        private void _vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this._isScrollingUp = (e.NewValue < e.OldValue);
        }


        protected void OnScroll(object sender, EventArgs e)
        {
            if (!base.ContainsFocus)
            {
                base.Focus();
            }
            int num = this._vScrollBar.Value;
            if (this._vScrollBar.Visible)
            {
                ContainerListViewItem containerListViewItem = this.TopItem;
                if (containerListViewItem == null)
                {
                    return;
                }
                if (num != containerListViewItem.Y)
                {
                    num = containerListViewItem.Y;
                    if (!this._isScrollingUp)
                    {
                        containerListViewItem = containerListViewItem.NextVisibleItem;
                    }
                    if (containerListViewItem != null)
                    {
                        num = containerListViewItem.Y;
                    }
                }
                if (num > this._vScrollBar.Maximum - this._vScrollBar.LargeChange)
                {
                    num = this._vScrollBar.Maximum - this._vScrollBar.LargeChange;
                    containerListViewItem = this.GetItemAt(num);
                    if (containerListViewItem != null)
                    {
                        containerListViewItem = containerListViewItem.NextVisibleItem;
                        if (containerListViewItem != null && containerListViewItem.Y != num)
                        {
                            num = containerListViewItem.Y;
                        }
                    }
                }
                if (num != this._vScrollBar.Value)
                {
                    this._vScrollBar.Value = Math.Max(num, 0);
                    return;
                }
            }
            base.Invalidate(this._detailVisibleRect);
            if (sender is HScrollBar)
            {
                base.Invalidate(this._headerVisibleRect);
                this.RecalculateLayout(false, false);
            }
        }


        internal void ColumnInvalidated(ContainerListViewColumnHeader column, bool recalculateLayout, bool redrawItems)
        {
            if (recalculateLayout)
            {
                this.RecalculateLayout(true, false);
            }
            if (redrawItems)
            {
                base.Invalidate();
                return;
            }
            base.Invalidate(this._headerVisibleRect);
        }


        public void BeginUpdate()
        {
            this._updateTransactions.Push(this);
        }


        public void EndUpdate()
        {
            if (this._updateTransactions.Count > 0)
            {
                this._updateTransactions.Pop();
            }
            if (!this.InUpdateTransaction)
            {
                this.RecalculateLayout(true, true);
                base.Invalidate();
            }
        }


        public void EnsureVisible()
        {
            this.EnsureVisible(this._focusedItem);
        }


        public void EnsureVisible(ContainerListViewItem item)
        {
            if (item != null && this._vScrollBar.Visible)
            {
                int y = item.Y;
                int num = y + item.Height;
                if (num >= this._vScrollBar.Value + this._vScrollBar.Height)
                {
                    this._vScrollBar.Value += num - (this._vScrollBar.Value + this._vScrollBar.Height);
                    return;
                }
                if (y < this._vScrollBar.Value)
                {
                    this._vScrollBar.Value = y;
                }
            }
        }


        public bool IsVisible(ContainerListViewItem item)
        {
            if (item == null || this._vScrollBar == null)
            {
                return false;
            }
            if (!this._vScrollBar.Visible)
            {
                return true;
            }
            int y = item.Y;
            int num = y + item.Height;
            return y < this._vScrollBar.Value + this._vScrollBar.Height && num >= this._vScrollBar.Value;
        }


        public void Sort(bool recursive)
        {
            this.Cursor = Cursors.WaitCursor;
            this._items.Sort(new ContainerListViewComparer(this), recursive);
            this.RecalculateItemPositions(this._rootItem, false);
            this.Cursor = Cursors.Default;
        }


        public void Sort(int columnIndex, bool autoSortOrder, bool clearCurrentSort)
        {
            if (columnIndex < 0 || columnIndex >= this._columns.Count)
            {
                columnIndex = 0;
            }
            ContainerListViewColumnHeader containerListViewColumnHeader = this._columns[columnIndex];
            if (containerListViewColumnHeader.SortDataType == SortDataType.None)
            {
                return;
            }
            SortOrder sortOrder = containerListViewColumnHeader.SortOrder;
            if (autoSortOrder || sortOrder == SortOrder.None)
            {
                if (containerListViewColumnHeader.SortOrder == SortOrder.Ascending)
                {
                    sortOrder = SortOrder.Descending;
                }
                else if (containerListViewColumnHeader.SortOrder == SortOrder.Descending)
                {
                    sortOrder = SortOrder.Ascending;
                }
            }
            if (sortOrder == SortOrder.None)
            {
                sortOrder = ((containerListViewColumnHeader.DefaultSortOrder == SortOrder.None) ? SortOrder.Ascending : containerListViewColumnHeader.DefaultSortOrder);
            }
            this.Sort(columnIndex, sortOrder, clearCurrentSort);
        }


        public void Sort(int columnIndex, SortOrder sortOrder, bool clearCurrentSort)
        {
            if (columnIndex < 0 || columnIndex >= this._columns.Count)
            {
                columnIndex = 0;
            }
            ContainerListViewColumnHeader containerListViewColumnHeader = this._columns[columnIndex];
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                if (this._columnsSorted.Count == 0)
                {
                    return;
                }
                containerListViewColumnHeader.InternalSortOrder = SortOrder.None;
                if (!this._columnsSorted.Contains(containerListViewColumnHeader))
                {
                    return;
                }
                this._columnsSorted.Remove(containerListViewColumnHeader);
            }
            else
            {
                if (clearCurrentSort || !this._allowMultipleColumnSort)
                {
                    foreach (object obj in this._columnsSorted)
                    {
                        ((ContainerListViewColumnHeader)obj).InternalSortOrder = SortOrder.None;
                    }
                    this._columnsSorted.Clear();
                }
                this.SetColumnSort(containerListViewColumnHeader, sortOrder);
            }
            this.Sort(true);
            base.Invalidate();
        }


        public void SetFilter(int columnIndex, string filterText)
        {
            if (filterText == null || filterText.Length == 0)
            {
                this.ResetFilter();
                return;
            }
            this.SetFilter(new ContainerListViewItemFilter(columnIndex, filterText));
        }


        public void SetFilter(IFilter filter)
        {
            this.BeginUpdate();
            this._rootItem.SetFilter(filter, true);
            this.EndUpdate();
        }


        public void ResetFilter()
        {
            this.SetFilter(null);
        }


        public void AutoSizeColumnWidths(bool includeItemWidths)
        {
            this.BeginUpdate();
            foreach (object obj in this._columns)
            {
                ((ContainerListViewColumnHeader)obj).AutoSizeWidth(includeItemWidths);
            }
            this.EndUpdate();
        }


        public new void Refresh()
        {
            base.Refresh();
        }


        public void Refresh(ContainerListViewItem item)
        {
            if (item == null)
            {
                return;
            }
            if (this._vScrollBar == null)
            {
                return;
            }
            Rectangle rc = new Rectangle(this._detailVisibleRect.Left, this._detailVisibleRect.Top + item.Y - this._vScrollBar.Value, this._detailRect.Width, item.Height);
            base.Invalidate(rc);
        }


        public void Refresh(ContainerListViewSubItem subItem)
        {
            if (subItem == null)
            {
                return;
            }
            Rectangle rectangle = this._headerColumnRects[subItem.ColumnIndex];
            Rectangle rc = new Rectangle(rectangle.Left, this._detailVisibleRect.Top + subItem.Item.Y - this._vScrollBar.Value, rectangle.Width, subItem.Item.Height);
            base.Invalidate(rc);
        }


        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rectangle = base.ClientRectangle;
            rectangle.Inflate(-this._borderSize, -this._borderSize);
            if (!rectangle.Contains(e.ClipRectangle))
            {
                graphics.Clip = new Region(base.ClientRectangle);
                graphics.ExcludeClip(rectangle);
                this.DrawBorder(graphics);
            }
            rectangle = Rectangle.Intersect(this._headerVisibleRect, e.ClipRectangle);
            if (rectangle.Width != 0 && rectangle.Height != 0)
            {
                this.DrawHeaders(graphics, rectangle);
            }
            rectangle = Rectangle.Intersect(this._detailVisibleRect, e.ClipRectangle);
            if (rectangle.Width != 0 && rectangle.Height != 0)
            {
                graphics.Clip = new Region(rectangle);
                this.DrawBackground(graphics, rectangle);
                this.DrawItems(graphics, rectangle);
                this.DrawGridLines(graphics, rectangle);
            }
            if (this._vScrollBar.Visible && this._hScrollBar.Visible)
            {
                Rectangle clip = new Rectangle(this._vScrollBar.Left, this._hScrollBar.Top, this._vScrollBar.Width, this._hScrollBar.Height);
                clip.Intersect(e.ClipRectangle);
                if (clip.Width != 0 && clip.Height != 0)
                {
                    this.DrawExtra(graphics, clip);
                }
            }
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.RecalculateLayout(true, false);
            if (this._vScrollBar.Visible && this._vScrollBar.Value > this._vScrollBar.Maximum - this._vScrollBar.LargeChange)
            {
                this._vScrollBar.Value = this._vScrollBar.Maximum - this._vScrollBar.LargeChange;
            }
            if (this._hScrollBar.Visible && this._hScrollBar.Value > this._hScrollBar.Maximum - this._hScrollBar.LargeChange)
            {
                this._hScrollBar.Value = this._hScrollBar.Maximum - this._hScrollBar.LargeChange;
            }
            base.Invalidate();
        }


        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 135)
            {
                m.Result = new IntPtr(129 | m.Result.ToInt32());
            }
        }


        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
            if (this.BackgroundImage != null)
            {
                this._backgroundImageBrush = new TextureBrush(this.BackgroundImage);
            }
            else
            {
                this._backgroundImageBrush = null;
            }
            base.Invalidate(this._detailVisibleRect);
        }


        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
            base.Invalidate(this._detailVisibleRect);
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            this.SetItemHovered(this._hoveredItem, false);
            this.SetColumnHovered(this._hoveredColumnHeader, false);
            this.SetColumnPressed(this._pressedColumnHeader, false);
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this._pressedColumnHeader != null && this._allowColumnReorder)
            {
                if (this._reorderingColumn || Math.Abs(e.X - this._lastClickedPoint.X) > 3)
                {
                    this._reorderingColumn = true;
                    this._reorderingColumnDelta = e.X - this._lastClickedPoint.X;
                    int i;
                    for (i = 0; i < this._columnDisplayOrder.Count; i++)
                    {
                        this._reorderingColumnDropIndex = ((ContainerListViewColumnHeader)this._columnDisplayOrder[i]).Index;
                        Rectangle rectangle = this._headerColumnRects[this._reorderingColumnDropIndex];
                        int num = rectangle.Left + rectangle.Width / 2;
                        if (e.X < num)
                        {
                            break;
                        }
                    }
                    if (i == this._columnDisplayOrder.Count)
                    {
                        this._reorderingColumnDropIndex = this._columnDisplayOrder.Count;
                    }
                    base.Invalidate(this._headerVisibleRect);
                    return;
                }
            }
            else
            {
                if (this._sizingColumn)
                {
                    this.Cursor = Cursors.VSplit;
                    this._sizingColumnDelta = e.X - this._lastClickedPoint.X;
                    this._sizingColumnHeader.Width = Math.Max(this._sizingColumnDelta + this._sizingColumnOriginalWidth, 0);
                    return;
                }
                if (e.Button != MouseButtons.None && this._selectedItems.Count > 0 && Math.Abs(Math.Sqrt(Math.Pow((double)(e.X - this._lastClickedPoint.X), 2.0) + Math.Pow((double)(e.Y - this._lastClickedPoint.Y), 2.0))) > 3.0 && ContainerListView.MouseInRectangle(e, this._detailRect))
                {
                    this.OnItemDrag(new ItemDragEventArgs(e.Button, this._selectedItems[0]));
                    return;
                }
                if (this._headerStyle != ColumnHeaderStyle.None)
                {
                    this.Cursor = Cursors.Default;
                    if (ContainerListView.MouseInRectangle(e, this._headerVisibleRect))
                    {
                        this.SetItemHovered(this._hoveredItem, false);
                        ContainerListViewColumnHeader containerListViewColumnHeader = null;
                        for (int j = 0; j < this._columns.Count; j++)
                        {
                            if (ContainerListView.MouseInRectangle(e, this._headerColumnSizeRects[j]))
                            {
                                this.Cursor = Cursors.VSplit;
                                break;
                            }
                            if (this._pressedColumnHeader == null && ContainerListView.MouseInRectangle(e, this._headerColumnRects[j]))
                            {
                                containerListViewColumnHeader = this._columns[j];
                                if (this._toolTipControl.GetToolTip(this) != this._columns[j].ToolTip)
                                {
                                    this._toolTipControl.SetToolTip(this, this._columns[j].ToolTip);
                                }
                            }
                        }
                        if (containerListViewColumnHeader == null)
                        {
                            this.SetColumnHovered(this._hoveredColumnHeader, false);
                            return;
                        }
                        if (this._hoveredColumnHeader != containerListViewColumnHeader)
                        {
                            this.SetColumnHovered(containerListViewColumnHeader, true);
                        }
                        return;
                    }
                    else if (this._toolTipControl.GetToolTip(this).Length != 0)
                    {
                        this._toolTipControl.SetToolTip(this, string.Empty);
                    }
                }
                this.SetColumnHovered(this._hoveredColumnHeader, false);
                if (ContainerListView.MouseInRectangle(e, this._detailVisibleRect) && this._pressedColumnHeader == null)
                {
                    ContainerListViewItem itemAt = this.GetItemAt(e.Y - this._detailVisibleRect.Top + this._vScrollBar.Value);
                    if (itemAt != null)
                    {
                        this.SetItemHovered(itemAt, true);
                        return;
                    }
                    this.SetItemHovered(this._hoveredItem, false);
                    return;
                }
                else
                {
                    this.SetItemHovered(this._hoveredItem, false);
                }
            }
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!this.Focused)
            {
                base.Focus();
                if (!this._captureFocusClick)
                {
                    return;
                }
            }
            this._lastClickedPoint = new Point(e.X, e.Y);
            if (this._headerStyle == ColumnHeaderStyle.Clickable && ContainerListView.MouseInRectangle(e, this._headerVisibleRect) && e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < this._columns.Count; i++)
                {
                    if (ContainerListView.MouseInRectangle(e, this._headerColumnSizeRects[i]))
                    {
                        if (e.Clicks == 2 && e.Button == MouseButtons.Left && this._items.Count > 0)
                        {
                            this._columns[i].AutoSizeWidth(true);
                        }
                        else
                        {
                            this._sizingColumn = true;
                            this._sizingColumnOriginalWidth = this._headerColumnRects[i].Width;
                            this._sizingColumnHeader = this._columns[i];
                        }
                    }
                    else if (ContainerListView.MouseInRectangle(e, this._headerColumnRects[i]))
                    {
                        this.SetColumnPressed(this._columns[i], true);
                    }
                }
                base.Invalidate(this._headerVisibleRect);
                return;
            }
            if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && ContainerListView.MouseInRectangle(e, this._detailVisibleRect) && this._items.Count > 0)
            {
                ContainerListViewItem itemAt = this.GetItemAt(e.Y - this._detailVisibleRect.Top + this._vScrollBar.Value);
                if (itemAt != null)
                {
                    if (itemAt.HasChildren && ContainerListView.MouseInRectangle(e, itemAt.Glyph))
                    {
                        itemAt.Expanded = !itemAt.Expanded;
                        return;
                    }
                    this.MouseSelection(itemAt, e.Button);
                }
            }
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this._lastClickedPoint = Point.Empty;
            if (this._sizingColumn)
            {
                this._sizingColumn = false;
                this._sizingColumnDelta = 0;
                this._sizingColumnOriginalWidth = 0;
                this._sizingColumnHeader = null;
            }
            if (this._reorderingColumn)
            {
                this.SetColumnDisplayIndex(this._pressedColumnHeader, this._reorderingColumnDropIndex, true);
                this._reorderingColumn = false;
                this._reorderingColumnDelta = 0;
                this._reorderingColumnDropIndex = -1;
                ContainerListViewColumnHeader pressedColumnHeader = this._pressedColumnHeader;
                this.SetColumnPressed(this._pressedColumnHeader, false);
                this.OnColumnReorder(new ContainerListViewEventArgs(pressedColumnHeader, null));
            }
            if (this._pressedColumnHeader != null && !this._reorderingColumn)
            {
                int index = this._pressedColumnHeader.Index;
                if (ContainerListView.MouseInRectangle(e, this._headerColumnRects[index]) && !ContainerListView.MouseInRectangle(e, this._headerColumnSizeRects[index]) && e.Button == MouseButtons.Left)
                {
                    this.OnColumnClick(new ContainerListViewEventArgs(this._pressedColumnHeader, null, e));
                }
            }
            this.SetColumnPressed(this._pressedColumnHeader, false);
            if (e.Button == MouseButtons.Right)
            {
                if (ContainerListView.MouseInRectangle(e, this._headerVisibleRect))
                {
                    this.OnPopColumnContextMenu(new ContainerListViewEventArgs(this._hoveredColumnHeader, null, e));
                }
                else if (ContainerListView.MouseInRectangle(e, this._detailVisibleRect))
                {
                    ContainerListViewItem itemAt = this.GetItemAt(e.Y - this._detailVisibleRect.Top + this._vScrollBar.Value);
                    if (itemAt != null)
                    {
                        this.OnPopItemContextMenu(new ContainerListViewEventArgs(this._hoveredColumnHeader, itemAt, e));
                    }
                    else
                    {
                        this.OnPopContextMenu(new ContainerListViewEventArgs(this._hoveredColumnHeader, itemAt, e));
                    }
                }
                else
                {
                    this.OnPopContextMenu(new ContainerListViewEventArgs(this._hoveredColumnHeader, null, e));
                }
                if (this._lastUserSingleClickedItem != null && this._lastUserSingleClickedItem.ListView != null)
                {
                    bool selected = this._lastUserSingleClickedItem.Selected;
                }
            }
            if (this._lastUserSingleClickedItem != null && (Control.ModifierKeys & Keys.Shift) == Keys.None && (Control.ModifierKeys & Keys.Control) == Keys.None && this._lastUserSingleClickedItem.ListView != null)
            {
                if (!this._lastUserSingleClickedItem.Selected || e.Button != MouseButtons.Right)
                {
                    this.ClearSelectedItems(false);
                }
                this.SetItemSelected(this._lastUserSingleClickedItem, true, true, true);
                this._lastUserSingleClickedItem = null;
            }
        }


        protected override void OnDoubleClick(EventArgs e)
        {
            if (base.PointToClient(Control.MousePosition).Y > this._headerHeight)
            {
                base.OnDoubleClick(e);
            }
        }


        protected override void OnMouseWheel(MouseEventArgs e)
        {
            try
            {
                if (e.Delta > 0)
                {
                    if (this._vScrollBar.Visible)
                    {
                        this._vScrollBar.Value = ((this._vScrollBar.Value - this._defaultItemHeight * (e.Delta / 100) < 0) ? 0 : (this._vScrollBar.Value - this._defaultItemHeight * (e.Delta / 100)));
                    }
                    else if (this._hScrollBar.Visible)
                    {
                        this._hScrollBar.Value = ((this._hScrollBar.Value - this._defaultItemHeight * (e.Delta / 100) < 0) ? 0 : (this._hScrollBar.Value - this._defaultItemHeight * (e.Delta / 100)));
                    }
                }
                else if (e.Delta < 0)
                {
                    if (this._vScrollBar.Visible)
                    {
                        this._vScrollBar.Value = ((this._vScrollBar.Value - this._vScrollBar.SmallChange * (e.Delta / 100) > this._vScrollBar.Maximum - this._vScrollBar.LargeChange) ? (this._vScrollBar.Maximum - this._vScrollBar.LargeChange) : (this._vScrollBar.Value - this._vScrollBar.SmallChange * (e.Delta / 100)));
                    }
                    else if (this._hScrollBar.Visible)
                    {
                        this._hScrollBar.Value = ((this._hScrollBar.Value - this._hScrollBar.SmallChange * (e.Delta / 100) > this._hScrollBar.Maximum - this._hScrollBar.LargeChange) ? (this._hScrollBar.Maximum - this._hScrollBar.LargeChange) : (this._hScrollBar.Value - this._hScrollBar.SmallChange * (e.Delta / 100)));
                    }
                }
            }
            catch (ArgumentException)
            {
            }
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            Keys keyCode = e.KeyCode;
            if (keyCode - Keys.Space > 8 && keyCode != Keys.A)
            {
                switch (keyCode)
                {
                    case Keys.Multiply:
                    case Keys.Subtract:
                    case Keys.Divide:
                        break;
                    case Keys.Add:
                        if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt && this._allowColumnResize)
                        {
                            this.AutoSizeColumnWidths(true);
                            e.Handled = true;
                            return;
                        }
                        this.OnSelectionKeys(e);
                        goto IL_6F;
                    case Keys.Separator:
                    case Keys.Decimal:
                        goto IL_6F;
                    default:
                        goto IL_6F;
                }
            }
            this.OnSelectionKeys(e);
        IL_6F:
            base.OnKeyDown(e);
        }


        public bool QuickFind(string search_str, bool find_next)
        {
            if (this.Items.Count == 0)
            {
                return false;
            }
            ContainerListViewItem containerListViewItem = this._focusedItem;
            ContainerListViewItem containerListViewItem2 = this._rootItem.VeryLastItem;
            if (containerListViewItem2.HasChildren)
            {
                containerListViewItem2 = containerListViewItem2.LastItem;
            }
            if (containerListViewItem == null)
            {
                containerListViewItem = this._rootItem.FirstItem;
            }
            else if (find_next)
            {
                containerListViewItem = containerListViewItem.NextTreeItem;
            }
            if (containerListViewItem == null)
            {
                containerListViewItem = this._rootItem.FirstItem;
            }
            if (!this.iQuickFind(search_str, containerListViewItem, containerListViewItem2))
            {
                this.iQuickFind(search_str, this._rootItem.FirstItem, containerListViewItem);
            }
            return false;
        }


        private bool iQuickFind(string search_str, ContainerListViewItem start_item, ContainerListViewItem end_item)
        {
            ContainerListViewItem containerListViewItem = start_item;
            search_str = search_str.Replace("_", "").ToLower();
            while (containerListViewItem != end_item.NextTreeItem)
            {
                if (containerListViewItem.Text.Replace("_", "").ToLower().Contains(search_str))
                {
                    this.SelectAndShowSingleItem(containerListViewItem);
                    return true;
                }
                containerListViewItem = containerListViewItem.NextTreeItem;
            }
            return false;
        }


        public void SelectAndShowSingleItem(ContainerListViewItem item)
        {
            this.ClearSelectedItems(false);
            if (item.ParentItem != this._rootItem)
            {
                item.ParentItem.Expand();
            }
            item.Selected = true;
            item.Focused = true;
            this.EnsureVisible(item);
        }


        protected virtual void OnSelectionKeys(KeyEventArgs e)
        {
            if (this._items.Count == 0)
            {
                return;
            }
            if (this._focusedItem == null)
            {
                this._focusedItem = this._items[0];
            }
            ContainerListViewItem containerListViewItem = this._focusedItem;
            Keys keyCode = e.KeyCode;
            switch (keyCode)
            {
                case Keys.Space:
                    if (this._allowMultipleSelect)
                    {
                        this.SetItemSelected(this._focusedItem, !this._focusedItem.Selected, true, true);
                    }
                    else
                    {
                        this.SetItemSelected(this._focusedItem, true, true, true);
                    }
                    e.Handled = true;
                    return;
                case Keys.Prior:
                    {
                        ContainerListViewItem topItem = this.TopItem;
                        if (topItem == containerListViewItem)
                        {
                            containerListViewItem = this.GetItemAt(Math.Max(topItem.Y + topItem.Height - this._vScrollBar.Height, 0));
                        }
                        else
                        {
                            containerListViewItem = topItem;
                        }
                        break;
                    }
                case Keys.Next:
                    if (this._vScrollBar.Visible && this._vScrollBar.Value + this._vScrollBar.LargeChange < this._vScrollBar.Maximum)
                    {
                        ContainerListViewItem bottomItemCompletelyVisible = this.BottomItemCompletelyVisible;
                        if (bottomItemCompletelyVisible == containerListViewItem)
                        {
                            containerListViewItem = (this.GetItemAt(bottomItemCompletelyVisible.Y + this._vScrollBar.Height) ?? this._items[this._items.Count - 1]);
                        }
                        else
                        {
                            containerListViewItem = bottomItemCompletelyVisible;
                        }
                    }
                    else
                    {
                        containerListViewItem = this._rootItem.VeryLastItem;
                    }
                    break;
                case Keys.End:
                    containerListViewItem = this._rootItem.VeryLastItem;
                    break;
                case Keys.Home:
                    containerListViewItem = this._rootItem.FirstItem;
                    break;
                case Keys.Left:
                    if (containerListViewItem.Expanded && containerListViewItem.HasChildren)
                    {
                        containerListViewItem.Expanded = false;
                    }
                    else
                    {
                        containerListViewItem = containerListViewItem.ParentItem;
                    }
                    break;
                case Keys.Up:
                    containerListViewItem = containerListViewItem.PreviousVisibleItem;
                    break;
                case Keys.Right:
                    if (!containerListViewItem.Expanded && containerListViewItem.HasChildren)
                    {
                        containerListViewItem.Expanded = true;
                    }
                    else
                    {
                        containerListViewItem = containerListViewItem.FirstItem;
                    }
                    break;
                case Keys.Down:
                    containerListViewItem = containerListViewItem.NextVisibleItem;
                    break;
                default:
                    if (keyCode != Keys.A)
                    {
                        switch (keyCode)
                        {
                            case Keys.Multiply:
                                containerListViewItem.Expanded = true;
                                break;
                            case Keys.Add:
                                if (e.Control)
                                {
                                    foreach (ContainerListViewItem obj in Items)
                                        obj.Expanded = true;
                                    break;
                                }
                                containerListViewItem.Expanded = true;
                                break;
                            case Keys.Subtract:
                                if (e.Control)
                                {
                                    foreach (ContainerListViewItem obj in Items)
                                        obj.Expanded = false;
                                    break;
                                }
                                containerListViewItem.Expanded = false;
                                break;
                            case Keys.Divide:
                                containerListViewItem.Expanded = false;
                                break;
                        }
                    }
                    else
                    {
                        if ((Control.ModifierKeys & Keys.Control) != Keys.Control || !this._allowMultipleSelect)
                        {
                            return;
                        }
                        this.ClearSelectedItems(false);
                        for (containerListViewItem = this._rootItem.FirstItem; containerListViewItem != this._rootItem.VeryLastItem; containerListViewItem = containerListViewItem.NextVisibleItem)
                        {
                            this.SetItemSelected(containerListViewItem, true, false, false);
                        }
                        this.SetItemSelected(containerListViewItem, true, false, true);
                        e.Handled = true;
                        return;
                    }
                    break;
            }
            this.KeyboardSelection(containerListViewItem);
            e.Handled = true;
        }


        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            base.Invalidate();
        }


        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            base.Invalidate();
        }


        internal void SetColumnSort(ContainerListViewColumnHeader column, SortOrder sortOrder)
        {
            if (column == null)
            {
                return;
            }
            if (sortOrder == SortOrder.None && this._columnsSorted.Contains(column))
            {
                this._columnsSorted.Remove(column);
                return;
            }
            if (!this._columnsSorted.Contains(column))
            {
                this._columnsSorted.Add(column);
            }
            column.InternalSortOrder = sortOrder;
        }


        internal bool GetColumnHovered(ContainerListViewColumnHeader column)
        {
            return this._hoveredColumnHeader != null && this._hoveredColumnHeader.Equals(column);
        }


        internal void SetColumnHovered(ContainerListViewColumnHeader column, bool isHovered)
        {
            if (isHovered)
            {
                if (this._hoveredColumnHeader == null || !this._hoveredColumnHeader.Equals(column))
                {
                    ContainerListViewColumnHeader hoveredColumnHeader = this._hoveredColumnHeader;
                    this._hoveredColumnHeader = column;
                    if (this._columnTracking)
                    {
                        this.InvalidateColumnHeader(true, hoveredColumnHeader);
                        this.InvalidateColumnHeader(true, column);
                        return;
                    }
                }
            }
            else if (this._hoveredColumnHeader != null && this._hoveredColumnHeader.Equals(column))
            {
                ContainerListViewColumnHeader hoveredColumnHeader2 = this._hoveredColumnHeader;
                this._hoveredColumnHeader = null;
                if (this._columnTracking)
                {
                    this.InvalidateColumnHeader(true, hoveredColumnHeader2);
                }
            }
        }


        internal bool GetColumnPressed(ContainerListViewColumnHeader column)
        {
            return this._pressedColumnHeader != null && this._pressedColumnHeader.Equals(column);
        }


        internal void SetColumnPressed(ContainerListViewColumnHeader column, bool isPressed)
        {
            if (isPressed)
            {
                if (this._pressedColumnHeader == null || !this._pressedColumnHeader.Equals(column))
                {
                    ContainerListViewColumnHeader pressedColumnHeader = this._pressedColumnHeader;
                    this._pressedColumnHeader = column;
                    this.SetColumnHovered(this._hoveredColumnHeader, false);
                    this.SetItemHovered(this._hoveredItem, false);
                    this.InvalidateColumnHeader(false, pressedColumnHeader);
                    this.InvalidateColumnHeader(false, column);
                    return;
                }
            }
            else if (this._pressedColumnHeader != null && this._pressedColumnHeader.Equals(column))
            {
                ContainerListViewColumnHeader pressedColumnHeader2 = this._pressedColumnHeader;
                this._pressedColumnHeader = null;
                this.InvalidateColumnHeader(false, pressedColumnHeader2);
            }
        }


        internal int GetColumnDisplayIndex(ContainerListViewColumnHeader column)
        {
            if (this._columnDisplayOrder.Count != this._columns.Count)
            {
                this.RecalculateLayout(false, false);
            }
            if (column != null)
            {
                return this._columnDisplayOrder.IndexOf(column);
            }
            return -1;
        }


        internal void SetColumnDisplayIndex(ContainerListViewColumnHeader column, int index, bool is_drag_and_drop)
        {
            int displayIndex = column.DisplayIndex;
            int num;
            if (is_drag_and_drop)
            {
                num = ((index == this._columns.Count) ? this._columns.Count : this._columns[index].DisplayIndex);
            }
            else
            {
                num = index;
            }
            if (displayIndex != num && displayIndex != num - 1)
            {
                if (num > displayIndex)
                {
                    this._columnDisplayOrder.Insert(num, column);
                    this._columnDisplayOrder.RemoveAt(displayIndex);
                    column.DisplayIndex = num - 1;
                }
                else
                {
                    this._columnDisplayOrder.RemoveAt(displayIndex);
                    this._columnDisplayOrder.Insert(num, column);
                    column.DisplayIndex = num;
                }
                this.RecalculateLayout(false, false);
            }
            base.Invalidate();
        }


        internal int GetColumnIndex(ContainerListViewColumnHeader column)
        {
            return this._columns.IndexOf(column);
        }


        internal bool GetItemFocused(ContainerListViewItem item)
        {
            return this._focusedItem != null && this._focusedItem.Equals(item);
        }


        internal void SetItemFocused(ContainerListViewItem item, bool isFocused)
        {
            if (isFocused)
            {
                if (this._focusedItem == null || !this._focusedItem.Equals(item))
                {
                    ContainerListViewItem focusedItem = this._focusedItem;
                    this._focusedItem = item;
                    this.InvalidateDetailItem(focusedItem);
                    this.InvalidateDetailItem(item);
                    return;
                }
            }
            else if (this._focusedItem != null && this._focusedItem.Equals(item))
            {
                ContainerListViewItem focusedItem2 = this._focusedItem;
                this._focusedItem = null;
                this.InvalidateDetailItem(focusedItem2);
            }
        }


        internal bool GetItemHovered(ContainerListViewItem item)
        {
            return this._hoveredItem != null && this._hoveredItem.Equals(item);
        }


        internal void SetItemHovered(ContainerListViewItem item, bool isHovered)
        {
            if (isHovered)
            {
                if (this._hoveredItem == null || !this._hoveredItem.Equals(item))
                {
                    ContainerListViewItem hoveredItem = this._hoveredItem;
                    this._hoveredItem = item;
                    this.InvalidateDetailItem(hoveredItem);
                    this.InvalidateDetailItem(item);
                    return;
                }
            }
            else if (this._hoveredItem != null && this._hoveredItem.Equals(item))
            {
                ContainerListViewItem hoveredItem2 = this._hoveredItem;
                this._hoveredItem = null;
                this.InvalidateDetailItem(hoveredItem2);
            }
        }


        internal bool GetItemSelected(ContainerListViewItem item)
        {
            return this._selectedItems.Contains(item);
        }


        internal void ClearSelectedItems(bool sendEvent)
        {
            if (this._selectedItems.Count > 0)
            {
                this._selectedItems.InternalClear();
                if (sendEvent)
                {
                    this.OnSelectedItemsChanged();
                }
            }
        }


        public void SetItemSelected(ContainerListViewItem item, bool isSelected, bool sendEvent, bool userFocused)
        {
            this.SetItemSelected(item, isSelected, sendEvent, userFocused, false);
        }


        public void SetItemSelected(ContainerListViewItem item, bool isSelected, bool sendEvent, bool userFocused, bool selectChildren)
        {
            if (item == null)
            {
                return;
            }
            if (userFocused && isSelected)
            {
                this._lastUserSelectedItem = item;
            }
            if (this._allowMultipleSelect)
            {
                if (isSelected)
                {
                    if (!this._selectedItems.Contains(item))
                    {
                        this._selectedItems.Add(item);
                    }
                    else
                    {
                        sendEvent = false;
                    }
                    if (selectChildren)
                    {
                        foreach (ContainerListViewItem item2 in item.Items)
                            this.SetItemSelected(item2, isSelected, false, userFocused, true);
                    }
                }
                else
                {
                    if (this._selectedItems.Contains(item))
                    {
                        this._selectedItems.Remove(item);
                    }
                    else
                    {
                        sendEvent = false;
                    }
                    if (selectChildren)
                    {
                        foreach (ContainerListViewItem item3 in item.Items)
                            this.SetItemSelected(item3, isSelected, false, userFocused, true);
                    }
                }
            }
            else
            {
                if (isSelected)
                {
                    if (this._selectedItems.Count == 1 && this._selectedItems.Contains(item))
                    {
                        sendEvent = false;
                    }
                    else
                    {
                        this.ClearSelectedItems(false);
                        this._selectedItems.Add(item);
                    }
                }
                else if (this._selectedItems.Contains(item))
                {
                    this.ClearSelectedItems(false);
                }
            }

            base.Invalidate(this._detailVisibleRect);
            if (sendEvent)
            {
                this.OnSelectedItemsChanged();
            }
        }


        private void PopMenu(ContextMenuStrip theMenu, ContainerListViewEventArgs e)
        {
            if (theMenu != null)
            {
                theMenu.Show(this, e.MousePosition);
            }
        }


        public ContainerListViewItem GetItemAt(int y)
        {
            return this._rootItem.GetItemAt(y);
        }


        public ContainerListViewItem GetItemAtMousePos(MouseEventArgs e)
        {
            return this.GetItemAt(e.Y - this._detailVisibleRect.Top + this._vScrollBar.Value);
        }


        protected void RecalculateLayout(bool recalculateScrollbars, bool recalculateItems)
        {
            if (this.InUpdateTransaction || this._hScrollBar == null)
            {
                return;
            }
            this._headerColumnRects = new Rectangle[this._columns.Count + 1];
            this._headerColumnSizeRects = new Rectangle[this._columns.Count + 1];
            for (int i = 0; i < this._columnDisplayOrder.Count; i++)
            {
                ContainerListViewColumnHeader containerListViewColumnHeader = (ContainerListViewColumnHeader)this._columnDisplayOrder[i];
                if (!this._columns.Contains(containerListViewColumnHeader))
                {
                    this._columnDisplayOrder.Remove(containerListViewColumnHeader);
                    i--;
                }
            }
            for (int j = 0; j < this._columns.Count; j++)
            {
                ContainerListViewColumnHeader item = this._columns[j];
                if (!this._columnDisplayOrder.Contains(item))
                {
                    this._columnDisplayOrder.Add(this._columns[j]);
                }
            }
            int num = this._borderSize - this._hScrollBar.Value;
            int num2 = num;
            int num3 = 0;
            int borderSize = this._borderSize;
            for (int k = 0; k < this._columnDisplayOrder.Count; k++)
            {
                int index = ((ContainerListViewColumnHeader)this._columnDisplayOrder[k]).Index;
                if (this._columns[index].Visible)
                {
                    this._headerColumnRects[index] = new Rectangle(num2, borderSize, this._columns[index].Width, this._headerHeight);
                    num2 += this._columns[index].Width;
                    num3 += this._columns[index].Width;
                    if (this._allowColumnResize)
                    {
                        this._headerColumnSizeRects[index] = new Rectangle(num2 - 4, borderSize, 4, this._headerHeight);
                    }
                    else
                    {
                        this._headerColumnSizeRects[index] = Rectangle.Empty;
                    }
                }
                else
                {
                    this._headerColumnRects[index] = Rectangle.Empty;
                    this._headerColumnSizeRects[index] = Rectangle.Empty;
                }
            }
            int width = Math.Max(base.ClientRectangle.Right - this._borderSize - num2, 0);
            this._headerColumnRects[this._headerColumnRects.Length - 1] = new Rectangle(num2, borderSize, width, this._headerHeight);
            this._headerColumnSizeRects[this._headerColumnRects.Length - 1] = Rectangle.Empty;
            this._headerVisibleRect = new Rectangle(this._borderSize, this._borderSize, base.ClientRectangle.Width - this._borderSize * 2, this._headerHeight);
            if (recalculateItems)
            {
                this.RecalculateItemPositions(this._rootItem, false);
            }
            this._detailVisibleRect = Rectangle.FromLTRB(base.ClientRectangle.Left + this._borderSize, base.ClientRectangle.Top + this._borderSize + this._headerHeight, base.ClientRectangle.Right - this._borderSize - (this._vScrollBar.Visible ? this._vScrollBar.Width : 0), base.ClientRectangle.Bottom - this._borderSize - (this._hScrollBar.Visible ? this._hScrollBar.Height : 0));
            if (this._rootItem.VeryLastItem == null)
            {
                this._detailRect = new Rectangle(num, borderSize + this._headerHeight, num3, 0);
            }
            else
            {
                this._detailRect = new Rectangle(num, borderSize + this._headerHeight, num3, this._rootItem.VeryLastItem.Y + this._rootItem.VeryLastItem.Height);
            }
            if (recalculateScrollbars)
            {
                this.UpdateScrollbars();
            }
        }


        private void RecalculateItemPositions(ContainerListViewItem startAt, bool updateScrollBars)
        {
            if (this.InUpdateTransaction)
            {
                return;
            }
            if (startAt == null && this._rootItem != null)
            {
                startAt = this._rootItem;
            }
            if (startAt == null)
            {
                return;
            }
            ContainerListViewItem containerListViewItem = startAt;
            for (ContainerListViewItem parentItem = containerListViewItem.ParentItem; parentItem != null; parentItem = parentItem.ParentItem)
            {
                if (!parentItem.Expanded)
                {
                    this.RecalculateItemPositions(parentItem, updateScrollBars);
                    return;
                }
            }
            int num = containerListViewItem.Y;
            while (containerListViewItem != null)
            {
                containerListViewItem.Y = num;
                num += containerListViewItem.Height;
                containerListViewItem = containerListViewItem.NextVisibleItem;
            }
            if (updateScrollBars)
            {
                this.RecalculateLayout(true, false);
            }
            base.Invalidate();
        }


        internal void RecalculateItemPositions(ContainerListViewItem startAt)
        {
            this.RecalculateItemPositions(startAt, true);
        }


        protected virtual void UpdateScrollbars()
        {
            if (this._detailRect.IsEmpty)
            {
                return;
            }
            bool flag = this._detailRect.Width > base.Width - this._borderSize * 2 - this._vScrollBar.Width;
            bool flag2 = this._detailRect.Width > base.Width - this._borderSize * 2;
            bool flag3 = this._detailRect.Height > base.Height - this._borderSize * 2 - this._headerHeight - this._hScrollBar.Height;
            bool flag4 = this._detailRect.Height > base.Height - this._borderSize * 2 - this._headerHeight;
            bool flag5 = false;
            bool flag6 = false;
            if (flag2 || flag4)
            {
                flag5 = (flag || flag2);
                flag6 = (flag3 || flag4);
            }
            this._hScrollBar.Left = this._borderSize;
            this._hScrollBar.Top = base.Height - this._borderSize - this._hScrollBar.Height;
            this._hScrollBar.Width = base.Width - this._borderSize * 2 - (flag6 ? this._vScrollBar.Width : 0);
            this._hScrollBar.Maximum = this._detailRect.Width;
            this._hScrollBar.LargeChange = Math.Max(this._hScrollBar.Width, 0);
            this._vScrollBar.Left = base.Width - this._borderSize - this._vScrollBar.Width;
            this._vScrollBar.Top = this._borderSize + this._headerHeight;
            this._vScrollBar.Height = base.Height - this._headerHeight - this._borderSize * 2 - (flag5 ? this._hScrollBar.Height : 0);
            this._vScrollBar.Maximum = this._detailRect.Height;
            this._vScrollBar.LargeChange = Math.Max(this._vScrollBar.Height, 0);
            if (flag5 != this._hScrollBar.Visible)
            {
                this._hScrollBar.Value = 0;
                this._hScrollBar.Visible = flag5;
                this.RecalculateLayout(false, false);
            }
            if (flag6 != this._vScrollBar.Visible)
            {
                this._vScrollBar.Value = 0;
                this._vScrollBar.Visible = flag6;
                this.RecalculateLayout(false, false);
            }
        }


        private void InvalidateColumnHeader(bool invalidateEntireColumn, ContainerListViewColumnHeader column)
        {
            if (column == null)
            {
                return;
            }
            Rectangle rc = this._headerColumnRects[column.Index];
            if (invalidateEntireColumn)
            {
                rc.Height += this._detailVisibleRect.Height;
            }
            base.Invalidate(rc);
        }


        private void InvalidateDetailItem(ContainerListViewItem item)
        {
            if (item == null)
            {
                return;
            }
            Rectangle rc = new Rectangle(this._detailVisibleRect.Left, this._detailVisibleRect.Top + item.Y - this._vScrollBar.Value, this._detailVisibleRect.Width, item.Height + 1);
            base.Invalidate(rc);
        }


        public static bool MouseInRectangle(MouseEventArgs mouseArgs, Rectangle r)
        {
            return r.Contains(mouseArgs.X, mouseArgs.Y);
        }


        public bool ClickedInsideItemList(MouseEventArgs e)
        {
            return ContainerListView.MouseInRectangle(e, this._detailVisibleRect);
        }


        public static string TruncatedString(string s, int width, int height, int offset, Font font, Graphics g)
        {
            int i = s.Length;
            int num = width - offset;
            int num2 = height / font.Height;
            if (num2 == 0)
            {
                return string.Empty;
            }
            if ((int)g.MeasureString(s, font).Width <= num)
            {
                return s;
            }
            if (num2 <= 1)
            {
                for (i -= 3; i > 1; i--)
                {
                    string text = s.Substring(0, i) + "...";
                    if ((int)g.MeasureString(text, font).Width <= num)
                    {
                        return text;
                    }
                }
                return s.Substring(0, 1) + "...";
            }
            int num3 = 0;
            while (num3 < s.Length && (int)g.MeasureString(s.Substring(0, num3 + 1), font).Width <= num)
            {
                num3++;
            }
            int num4 = s.LastIndexOfAny(new char[]
            {
                ' ',
                '-'
            }, num3);
            if (num4 == -1)
            {
                num4 = num3;
            }
            string text2 = ContainerListView.TruncatedString(s.Substring(num4), width, height - font.Height, offset, font, g);
            if (text2.Length == 0)
            {
                return ContainerListView.TruncatedString(s, width, height - font.Height, offset, font, g);
            }
            return s.Substring(0, num4) + "\n" + text2;
        }


        private void KeyboardSelection(ContainerListViewItem item)
        {
            if (item == null || item == this._rootItem)
            {
                return;
            }
            if (this._allowMultipleSelect)
            {
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    ContainerListViewItem containerListViewItem = this._lastUserSelectedItem;
                    if (containerListViewItem == null)
                    {
                        containerListViewItem = this._focusedItem;
                    }
                    if (containerListViewItem != null)
                    {
                        this.ClearSelectedItems(false);
                        this.selectRange(containerListViewItem, item);
                    }
                    else
                    {
                        this.SetItemSelected(item, true, true, true);
                    }
                    this.SetItemFocused(item, true);
                }
                else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    this.SetItemFocused(item, true);
                }
                else
                {
                    this.ClearSelectedItems(false);
                    this.SetItemFocused(item, true);
                    this.SetItemSelected(item, true, true, true);
                }
            }
            else
            {
                this.SetItemFocused(item, true);
                this.SetItemSelected(item, true, true, true);
            }
            this.EnsureVisible();
        }


        private void MouseSelection(ContainerListViewItem item, MouseButtons mouseButton)
        {
            if (!this._allowMultipleSelect)
            {
                this.KeyboardSelection(item);
                return;
            }
            if (item == null || item == this._rootItem)
            {
                return;
            }
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && (Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                ContainerListViewItem containerListViewItem = this._lastUserSelectedItem;
                if (containerListViewItem == null)
                {
                    containerListViewItem = this._focusedItem;
                }
                if (containerListViewItem != null)
                {
                    this.selectRange(containerListViewItem, item);
                }
                else
                {
                    this.SetItemSelected(item, true, true, true);
                }
            }
            else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                ContainerListViewItem containerListViewItem2 = this._lastUserSelectedItem;
                if (containerListViewItem2 == null)
                {
                    containerListViewItem2 = this._focusedItem;
                }
                if (containerListViewItem2 != null)
                {
                    this.ClearSelectedItems(false);
                    this.selectRange(containerListViewItem2, item);
                }
                else
                {
                    this.SetItemSelected(item, true, true, true);
                }
            }
            else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                this.SetItemSelected(item, !item.Selected, true, true);
            }
            else
            {
                if (!item.Selected)
                {
                    this.ClearSelectedItems(false);
                }
                else
                {
                    this._lastUserSingleClickedItem = item;
                }
                this.SetItemSelected(item, true, true, true);
            }
            this.SetItemFocused(item, true);
            this.EnsureVisible();
        }


        private void selectRange(ContainerListViewItem itemFrom, ContainerListViewItem itemTo)
        {
            if (itemFrom == null || itemTo == null)
            {
                if (itemFrom != null)
                {
                    this.SetItemSelected(itemFrom, true, false, false, true);
                    return;
                }
                if (itemTo != null)
                {
                    this.SetItemSelected(itemTo, true, false, false, true);
                }
                return;
            }
            else
            {
                if (itemFrom.Depth == itemTo.Depth && itemFrom.ParentItem == itemTo.ParentItem)
                {
                    ContainerListViewItemCollection items = itemFrom.ParentItem.Items;
                    int num = items.IndexOf(itemFrom);
                    int num2 = items.IndexOf(itemTo);
                    if (num > num2)
                    {
                        Helpers.Swap<ContainerListViewItem>(ref itemFrom, ref itemTo);
                        Helpers.Swap<int>(ref num, ref num2);
                    }
                    if (num == -1)
                    {
                        num = num2;
                    }
                    for (int i = num; i < num2; i++)
                    {
                        this.SetItemSelected(items[i], true, false, false, false);
                    }
                    this.SetItemSelected(itemTo, true, true, false, false);
                    return;
                }
                if (itemFrom.Depth < itemTo.Depth)
                {
                    Helpers.Swap<ContainerListViewItem>(ref itemFrom, ref itemTo);
                }
                ContainerListViewItem containerListViewItem = itemFrom;
                for (int j = itemFrom.Depth; j > itemTo.Depth; j--)
                {
                    containerListViewItem = containerListViewItem.ParentItem;
                }
                ContainerListViewItemCollection items2 = containerListViewItem.ParentItem.Items;
                if (items2.IndexOf(itemTo) <= items2.IndexOf(containerListViewItem))
                {
                    this.selectRange(itemFrom.ParentItem.Items[0], itemFrom);
                    this.selectRange(itemTo, itemFrom.ParentItem);
                    return;
                }
                this.selectRange(itemFrom.ParentItem.Items[itemFrom.ParentItem.Items.Count - 1], itemFrom);
                this.SetItemSelected(itemFrom.ParentItem.Items[itemFrom.ParentItem.Items.Count - 1], true, true, true, true);
                ContainerListViewItem containerListViewItem2 = itemFrom;
                do
                {
                    containerListViewItem2 = containerListViewItem2.ParentItem;
                }
                while (containerListViewItem2.NextItem == null);
                this.selectRange(itemTo, containerListViewItem2.NextItem);
                return;
            }
        }


        protected virtual void DrawBorder(Graphics g)
        {
            if (this.UseVisualStyle)
            {
                this.drawBorderWithStyles(g);
                return;
            }
            this.drawBorderWithoutStyles(g);
        }


        private void drawBorderWithStyles(Graphics g)
        {
            VisualStyleElement visualStyleElement = null;
            if (VisualStyleRenderer.IsElementDefined(VisualStyleElement.ListView.Detail.Normal))
            {
                visualStyleElement = VisualStyleElement.ListView.Detail.Normal;
            }
            else if (VisualStyleRenderer.IsElementDefined(VisualStyleElement.TextBox.TextEdit.Normal))
            {
                visualStyleElement = VisualStyleElement.TextBox.TextEdit.Normal;
            }
            if (visualStyleElement != null)
            {
                new VisualStyleRenderer(visualStyleElement).DrawBackground(g, base.ClientRectangle);
                return;
            }
            this.drawBorderWithoutStyles(g);
        }


        private void drawBorderWithoutStyles(Graphics g)
        {
            if (this._borderStyle == BorderStyle.FixedSingle)
            {
                g.DrawRectangle(SystemPens.ControlDarkDark, base.ClientRectangle);
                return;
            }
            if (this._borderStyle == BorderStyle.Fixed3D)
            {
                ControlPaint.DrawBorder3D(g, base.ClientRectangle, Border3DStyle.Sunken);
            }
        }


        protected virtual void DrawBackground(Graphics g, Rectangle rectangle)
        {
            Brush brush;
            Brush brush2;
            Brush brush3;
            if (this.BackgroundImage != null)
            {
                this._backgroundImageBrush.ResetTransform();
                Matrix transform = this._backgroundImageBrush.Transform;
                transform.Translate((float)(-(float)this._hScrollBar.Value), (float)(-(float)this._vScrollBar.Value));
                this._backgroundImageBrush.Transform = transform;
                brush = this._backgroundImageBrush;
                Color color = this._columnTrackingBrush.Color;
                brush2 = new SolidBrush(Color.FromArgb(69, (int)Math.Min(255f, (float)color.R * 0.75f), (int)Math.Min(255f, (float)color.G * 0.75f), (int)Math.Min(255f, (float)color.B * 0.75f)));
                color = this._columnSortBrush.Color;
                brush3 = new SolidBrush(Color.FromArgb(69, (int)Math.Min(255f, (float)color.R * 0.75f), (int)Math.Min(255f, (float)color.G * 0.75f), (int)Math.Min(255f, (float)color.B * 0.75f)));
            }
            else
            {
                brush = new SolidBrush(this.BackColor);
                brush2 = this._columnTrackingBrush;
                brush3 = this._columnSortBrush;
            }
            g.FillRectangle(brush, rectangle);
            try
            {
                for (int i = 0; i < this._columns.Count; i++)
                {
                    ContainerListViewColumnHeader containerListViewColumnHeader = this._columns[i];
                    if (containerListViewColumnHeader.Visible)
                    {
                        Brush brush4 = null;
                        if (this._columnsSorted.Contains(containerListViewColumnHeader))
                        {
                            brush4 = brush3;
                        }
                        else if (this._columnTracking && this._hoveredColumnHeader == containerListViewColumnHeader)
                        {
                            brush4 = brush2;
                        }
                        if (brush4 != null)
                        {
                            Rectangle rectangle2 = this._headerColumnRects[containerListViewColumnHeader.Index];
                            g.FillRectangle(brush4, rectangle2.Left, rectangle2.Bottom, rectangle2.Width, base.ClientRectangle.Height);
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
        }


        private void DrawGridLines(Graphics g, Rectangle rect)
        {
            if (this._gridLines == GridLines.None)
            {
                return;
            }
            if ((this._gridLines & GridLines.Vertical) == GridLines.Vertical)
            {
                for (int i = 0; i < this._columns.Count; i++)
                {
                    if (this._columns[i].Visible && this._headerColumnRects[i].Right >= rect.Left && this._headerColumnRects[i].Right <= rect.Right)
                    {
                        g.DrawLine(this._gridLinePen, new Point(this._headerColumnRects[i].Right, rect.Top), new Point(this._headerColumnRects[i].Right, rect.Bottom));
                    }
                }
            }
            if ((this._gridLines & GridLines.Horizontal) == GridLines.Horizontal)
            {
                ContainerListViewItem bottomItemPartiallyVisible = this.BottomItemPartiallyVisible;
                for (ContainerListViewItem containerListViewItem = this.TopItem; containerListViewItem != bottomItemPartiallyVisible; containerListViewItem = containerListViewItem.NextVisibleItem)
                {
                    g.DrawLine(this._gridLinePen, new Point(rect.Left, this._detailVisibleRect.Top + containerListViewItem.Y + containerListViewItem.Height - this._vScrollBar.Value), new Point(rect.Right, this._detailVisibleRect.Top + containerListViewItem.Y + containerListViewItem.Height - this._vScrollBar.Value));
                }
            }
        }


        protected virtual void DrawHeaders(Graphics g, Rectangle clip)
        {
            for (int i = 0; i < this._headerColumnRects.Length; i++)
            {
                Rectangle clip2 = Rectangle.Intersect(this._headerColumnRects[i], clip);
                if (clip2.Height != 0 && clip2.Width != 0)
                {
                    this.DrawColumnHeader(g, i, clip2, this._headerColumnRects[i]);
                }
            }
            g.ResetClip();
            if (this._reorderingColumn)
            {
                int x = this._headerColumnRects[this._reorderingColumnDropIndex].Left - 1;
                g.FillRectangle(SystemBrushes.HotTrack, x, this._headerVisibleRect.Top, 2, this._headerVisibleRect.Height);
                int index = this._pressedColumnHeader.Index;
                Rectangle headerBounds = this._headerColumnRects[index];
                headerBounds.Offset(this._reorderingColumnDelta, 0);
                Bitmap image = new Bitmap(this._headerVisibleRect.Right, this._headerVisibleRect.Bottom);
                Graphics g2 = Graphics.FromImage(image);
                ImageAttributes imageAttributes = new ImageAttributes();
                float[][] array = new float[5][];
                int num = 0;
                float[] array2 = new float[5];
                array2[0] = 1f;
                array[num] = array2;
                int num2 = 1;
                float[] array3 = new float[5];
                array3[1] = 1f;
                array[num2] = array3;
                int num3 = 2;
                float[] array4 = new float[5];
                array4[2] = 1f;
                array[num3] = array4;
                int num4 = 3;
                float[] array5 = new float[5];
                array5[3] = 0.5f;
                array[num4] = array5;
                array[4] = new float[]
                {
                    0f,
                    0f,
                    0f,
                    0f,
                    1f
                };
                ColorMatrix newColorMatrix = new ColorMatrix(array);
                imageAttributes.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                this.DrawColumnHeader(g2, index, this._headerVisibleRect, headerBounds);
                g.DrawImage(image, this._headerVisibleRect, this._headerVisibleRect.Left, this._headerVisibleRect.Top, this._headerVisibleRect.Width, this._headerVisibleRect.Height, GraphicsUnit.Pixel, imageAttributes);
            }
        }


        protected virtual void DrawColumnHeader(Graphics g, int columnIndex, Rectangle clip, Rectangle headerBounds)
        {
            g.Clip = new Region(clip);
            ContainerListViewColumnHeader containerListViewColumnHeader = (columnIndex == this._columns.Count) ? null : this._columns[columnIndex];
            VisualStyleElement visualStyleElement = null;
            if (this.UseVisualStyle)
            {
                if (columnIndex == this._columns.Count)
                {
                    if (this._headerStyle == ColumnHeaderStyle.Clickable && containerListViewColumnHeader != null && containerListViewColumnHeader.Pressed)
                    {
                        visualStyleElement = VisualStyleElement.Header.ItemRight.Pressed;
                    }
                    else if (this._headerStyle != ColumnHeaderStyle.None && containerListViewColumnHeader != null && containerListViewColumnHeader.Hovered)
                    {
                        visualStyleElement = VisualStyleElement.Header.ItemRight.Hot;
                    }
                    else
                    {
                        visualStyleElement = VisualStyleElement.Header.Item.Normal;
                    }
                }
                else if (this._headerStyle == ColumnHeaderStyle.Clickable && containerListViewColumnHeader != null && containerListViewColumnHeader.Pressed)
                {
                    visualStyleElement = VisualStyleElement.Header.Item.Pressed;
                }
                else if (this._headerStyle != ColumnHeaderStyle.None && containerListViewColumnHeader != null && containerListViewColumnHeader.Hovered)
                {
                    visualStyleElement = VisualStyleElement.Header.Item.Hot;
                }
                else
                {
                    visualStyleElement = VisualStyleElement.Header.Item.Normal;
                }
                if (!VisualStyleRenderer.IsElementDefined(visualStyleElement))
                {
                    visualStyleElement = null;
                }
            }
            if (visualStyleElement != null)
            {
                new VisualStyleRenderer(visualStyleElement).DrawBackground(g, headerBounds, clip);
            }
            else
            {
                g.FillRectangle(new SolidBrush(SystemColors.Control), headerBounds);
                ButtonState state;
                if (this._headerStyle == ColumnHeaderStyle.Clickable && containerListViewColumnHeader != null && containerListViewColumnHeader.Pressed)
                {
                    state = ButtonState.Pushed;
                }
                else
                {
                    state = ButtonState.Normal;
                }
                if (headerBounds.Width < 0)
                {
                    return;
                }
                ControlPaint.DrawButton(g, headerBounds, state);
            }
            if (containerListViewColumnHeader == null)
            {
                return;
            }
            headerBounds.Offset(6, 0);
            headerBounds.Width -= 8;
            headerBounds.Height -= 4;
            clip.Intersect(headerBounds);
            if (headerBounds.Width <= 0 || headerBounds.Height <= 0)
            {
                return;
            }
            int num = (containerListViewColumnHeader.SortOrder == SortOrder.None) ? 0 : 16;
            int num2 = (containerListViewColumnHeader.Image == null) ? 0 : 20;
            string text = ContainerListView.TruncatedString(containerListViewColumnHeader.Text, headerBounds.Width, headerBounds.Height, num + num2, containerListViewColumnHeader.Font, g);
            StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.None;
            int num3 = (int)g.MeasureString(text, containerListViewColumnHeader.Font, headerBounds.Width, stringFormat).Width;
            int num4;
            if (containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.MiddleRight || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.TopRight || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.BottomRight)
            {
                num4 = headerBounds.Width - (num + num2 + num3) - 2;
                stringFormat.Alignment = StringAlignment.Far;
            }
            else if (containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.MiddleCenter || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.TopCenter || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.BottomCenter)
            {
                num4 = (headerBounds.Width - (num + num2 + num3)) / 2;
                stringFormat.Alignment = StringAlignment.Center;
            }
            else
            {
                num4 = 0;
                stringFormat.Alignment = StringAlignment.Near;
            }
            if (num4 < 0 || text != containerListViewColumnHeader.Text)
            {
                num4 = 0;
            }
            num4 += headerBounds.Left;
            if (containerListViewColumnHeader.SortOrder != SortOrder.None)
            {
                int num5 = num4 + num3 + num2 + num - 11;
                if (text != containerListViewColumnHeader.Text || num5 > headerBounds.Right - 11)
                {
                    num5 = headerBounds.Right - 13;
                }
                if (num5 < 0)
                {
                    num5 = 0;
                }
                this.DrawSortTriangle(containerListViewColumnHeader, g, new Rectangle(num5, headerBounds.Top + 1, 13, headerBounds.Height));
                g.ExcludeClip(new Rectangle(headerBounds.Width - num, 0, num, headerBounds.Height));
            }
            else
            {
                g.ExcludeClip(new Rectangle(headerBounds.Width - 3, 0, 3, headerBounds.Height));
            }
            if (containerListViewColumnHeader.Image != null)
            {
                int num6 = (headerBounds.Height - Math.Min(containerListViewColumnHeader.Image.Height, 16)) / 2;
                num6 = Math.Max(num6, 1);
                g.DrawImage(containerListViewColumnHeader.Image, new Rectangle(num4, num6, 16, 16));
            }
            Rectangle r = new Rectangle(num4 + num2, headerBounds.Top, num3, headerBounds.Height);
            g.DrawString(text, containerListViewColumnHeader.Font, SystemBrushes.ControlText, r, stringFormat);
        }


        protected virtual void DrawSortTriangle(ContainerListViewColumnHeader col, Graphics g, Rectangle rectangle)
        {
            int num = (this._columnsSorted.Count > 1) ? 3 : 4;
            Bitmap bitmap = new Bitmap(9, num + 1);
            Graphics graphics = Graphics.FromImage(bitmap);
            Pen controlLightLight = SystemPens.ControlLightLight;
            Pen controlDark = SystemPens.ControlDark;
            bitmap.SetPixel(4, 0, controlDark.Color);
            for (int i = 1; i <= num; i++)
            {
                graphics.DrawLine(controlDark, 4 - i, i, 4 + i, i);
            }
            graphics.Dispose();
            if (this._columnsSorted.Count > 1)
            {
                Font font = new Font(col.Font.FontFamily, 5f, col.Font.Style, col.Font.Unit, col.Font.GdiCharSet, col.Font.GdiVerticalFont);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                g.DrawString((this._columnsSorted.IndexOf(col) + 1).ToString(CultureInfo.CurrentCulture), font, SystemBrushes.ControlText, (float)(rectangle.Left + 4), (float)rectangle.Top, stringFormat);
            }
            if (col.SortOrder == SortOrder.Descending)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
            if (this._columnsSorted.Count > 1)
            {
                g.DrawImage(bitmap, rectangle.Left, rectangle.Top + 3 + (rectangle.Height - 5) / 2);
                return;
            }
            g.DrawImage(bitmap, rectangle.Left, rectangle.Top + (rectangle.Height - 5) / 2);
        }


        protected virtual void DrawItems(Graphics g, Rectangle clip)
        {
            if (this.InUpdateTransaction)
            {
                return;
            }
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < this._visibleItems.Count; i++)
            {
                ContainerListViewItem containerListViewItem = this._visibleItems[i] as ContainerListViewItem;
                if (containerListViewItem.Y >= this._vScrollBar.Value && containerListViewItem.Y <= this._vScrollBar.Value + this._detailVisibleRect.Height && containerListViewItem.InternalIsVisible)
                {
                    arrayList.Add(containerListViewItem);
                }
                else
                {
                    for (int j = 0; j < containerListViewItem.SubItems.Count; j++)
                    {
                        if (containerListViewItem.SubItems[j].ItemControl != null)
                        {
                            containerListViewItem.SubItems[j].ItemControl.Visible = false;
                        }
                    }
                }
            }
            this._visibleItems = arrayList;
            int y = clip.Top + this._vScrollBar.Value - this._detailVisibleRect.Top;
            int y2 = clip.Bottom + this._vScrollBar.Value - this._detailVisibleRect.Top;
            ContainerListViewItem containerListViewItem2 = this.GetItemAt(y2);
            if (containerListViewItem2 == null)
            {
                containerListViewItem2 = this._rootItem.VeryLastItem;
            }
            if (containerListViewItem2 == null)
            {
                return;
            }
            containerListViewItem2 = containerListViewItem2.NextVisibleItem;
            ContainerListViewItem containerListViewItem3 = this.GetItemAt(y);
            while (containerListViewItem3 != containerListViewItem2 && containerListViewItem3 != null)
            {
                Rectangle itemBounds = new Rectangle(this._detailRect.Left, this._detailVisibleRect.Top + containerListViewItem3.Y - this._vScrollBar.Value, this._detailRect.Width, containerListViewItem3.Height);
                g.Clip = new Region(this._detailVisibleRect);
                if (!this._visibleItems.Contains(containerListViewItem3))
                {
                    this._visibleItems.Add(containerListViewItem3);
                }
                this.DrawItem(g, containerListViewItem3, clip, itemBounds);
                containerListViewItem3 = containerListViewItem3.NextVisibleItem;
            }
            g.ResetClip();
        }


        private void DrawItem(Graphics g, ContainerListViewItem item, Rectangle clip, Rectangle itemBounds)
        {
            int num = this._detailRect.Width;
            if (!this._fullItemSelect)
            {
                num = this._columns[0].Width;
            }
            int num2 = 16 * (item.Depth - 1);
            int num3 = ((this._showRootTreeLines && (this._showPlusMinus || this._showTreeLines)) ? 16 : 0) + 3;
            num -= num2 + num3;
            Rectangle rectangle = new Rectangle(itemBounds.Left + num2 + num3, itemBounds.Top, num, itemBounds.Height);
            if (this._itemTracking && item.Hovered)
            {
                g.FillRectangle(this._itemTrackingBrush, clip.Left, this._detailVisibleRect.Top + item.Y - this._vScrollBar.Value, clip.Right, item.Height);
            }
            else if (item.BackColor != Color.Empty)
            {
                g.FillRectangle(new SolidBrush(item.BackColor), clip.Left, this._detailVisibleRect.Top + item.Y - this._vScrollBar.Value, clip.Right, item.Height);
            }
            Color backColor = item.BackColor;
            if (backColor == Color.Empty)
            {
                backColor = this.BackColor;
            }
            Color foreColor = this.ForeColor;
            if (item.Selected)
            {
                ContainerListViewItem nextVisibleItem = item.NextVisibleItem;
                ContainerListViewItem previousVisibleItem = item.PreviousVisibleItem;
                bool flag = nextVisibleItem != null && nextVisibleItem.Selected;
                bool flag2 = previousVisibleItem != null && previousVisibleItem.Selected;
                Color border;
                if (base.ContainsFocus)
                {
                    border = this._itemSelectedColor;
                }
                else
                {
                    border = Color.FromArgb(120, this._itemSelectedColor);
                }
                this.DrawSelectionBox(g, rectangle, border, !flag2, !flag);
            }
            if (item.Focused && this._allowMultipleSelect && base.ContainsFocus)
            {
                ControlPaint.DrawFocusRectangle(g, rectangle, foreColor, backColor);
            }
            Font font = item.Font;
            if (font == null)
            {
                font = this.Font;
            }
            for (int i = 0; i < this._columns.Count; i++)
            {
                this.DrawSubitem(g, item, itemBounds, num2, font, i);
            }
        }


        private void DrawSubitem(Graphics g, ContainerListViewItem item, Rectangle itemBounds, int indent, Font fnt, int colIndex)
        {
            ContainerListViewColumnHeader containerListViewColumnHeader = this._columns[colIndex];
            Rectangle rectangle = this._headerColumnRects[colIndex];
            rectangle.Offset(5, 0);
            rectangle.Width -= 5;
            if (containerListViewColumnHeader.Visible && rectangle.Right > this._detailVisibleRect.Left && rectangle.Left < this._detailVisibleRect.Right)
            {
                string text = null;
                int num = 0;
                g.Clip = new Region(new Rectangle(rectangle.Left, itemBounds.Top, rectangle.Width, itemBounds.Height));
                g.IntersectClip(this._detailVisibleRect);
                if (containerListViewColumnHeader.DisplayIndex == 0)
                {
                    if ((item.Depth == 1 && this._showRootTreeLines && (this._showPlusMinus || this._showTreeLines)) || item.Depth != 1)
                    {
                        indent = 0;
                        if (item.Depth != 1)
                        {
                            for (int i = (this._showRootTreeLines && (this._showPlusMinus || this._showTreeLines)) ? 1 : 2; i < item.Depth; i++)
                            {
                                ContainerListViewItem containerListViewItem = item;
                                for (int j = 0; j < item.Depth - i; j++)
                                {
                                    containerListViewItem = containerListViewItem.ParentItem;
                                }
                                if (this._showTreeLines && containerListViewItem.NextItem != null)
                                {
                                    Point pt = new Point(rectangle.Left + 4, itemBounds.Top);
                                    Point pt2 = new Point(rectangle.Left + 4, itemBounds.Bottom);
                                    if (pt.Y % 2 != 0)
                                    {
                                        int y = pt.Y + 1;
                                        pt.Y = y;
                                    }
                                    if (pt2.Y % 2 != 0)
                                    {
                                        int y = pt2.Y + 1;
                                        pt2.Y = y;
                                    }
                                    if (item.PreviousVisibleItem != null)
                                    {
                                        pt.Y = itemBounds.Top + ((itemBounds.Top % 2 == 0) ? 0 : 1);
                                    }
                                    if (item.NextVisibleItem != null)
                                    {
                                        pt2.Y = itemBounds.Bottom + ((itemBounds.Bottom % 2 == 0) ? 0 : 1);
                                    }
                                    g.DrawLine(new Pen(SystemColors.GrayText, 1f)
                                    {
                                        DashStyle = DashStyle.Dot
                                    }, pt, pt2);
                                }
                                rectangle.Offset(16, 0);
                                rectangle.Width -= 16;
                            }
                        }
                        rectangle.Offset(indent, 0);
                        rectangle.Width -= indent;
                        if (this._showTreeLines)
                        {
                            Point point = new Point(rectangle.Left + 4, itemBounds.Top + itemBounds.Height / 2);
                            if (point.Y % 2 != 0 && !this._showPlusMinus)
                            {
                                int y = point.Y - 1;
                                point.Y = y;
                            }
                            Point pt3 = new Point(rectangle.Left + 16, point.Y);
                            Point point2 = point;
                            Point pt4 = point2;
                            if (item.PreviousVisibleItem != null)
                            {
                                point2.Y = itemBounds.Top + ((itemBounds.Top % 2 == 0) ? 0 : 1);
                            }
                            if (item.NextItem != null)
                            {
                                pt4.Y = itemBounds.Bottom + ((itemBounds.Bottom % 2 == 0) ? 0 : 1);
                            }
                            Pen pen = new Pen(SystemColors.GrayText, 1f);
                            pen.DashStyle = DashStyle.Dot;
                            g.DrawLine(pen, point2, pt4);
                            g.DrawLine(pen, point, pt3);
                        }
                        if (item.HasChildren && this._showPlusMinus)
                        {
                            Rectangle rectangle2 = new Rectangle(rectangle.Left, itemBounds.Top + (itemBounds.Height - 9) / 2, 9, 9);
                            this.DrawTreeExpander(g, rectangle2, item.Expanded);
                            item.Glyph = rectangle2;
                        }
                        else
                        {
                            item.Glyph = Rectangle.Empty;
                        }
                        rectangle.Offset(16, 0);
                        rectangle.Width -= 16;
                    }
                    if (this._smallImageList != null || this._selectedImageList != null)
                    {
                        ImageList imageList = this._smallImageList;
                        int num2 = item.ImageIndex;
                        if (imageList == null || (item.Selected && this._selectedImageList != null))
                        {
                            imageList = this._selectedImageList;
                        }
                        if (num2 == -1 || (item.Selected && item.SelectedImageIndex != -1))
                        {
                            num2 = item.SelectedImageIndex;
                        }
                        if (num2 != -1)
                        {
                            g.DrawImage(imageList.Images[num2], rectangle.Left + 2, itemBounds.Top + (itemBounds.Height - 16) / 2, 16, 16);
                            num = 20;
                        }
                    }
                }
                ContainerListViewSubItem containerListViewSubItem = item.SubItems[colIndex];
                Control itemControl = containerListViewSubItem.ItemControl;
                if (itemControl != null)
                {
                    Size itemControlInitialSize = containerListViewSubItem.ItemControlInitialSize;
                    int num3 = itemControlInitialSize.Width;
                    int num4 = itemControlInitialSize.Height;
                    if (containerListViewSubItem.ControlResizeBehavior == ControlResizeBehavior.HeightFitMaintainRatio || containerListViewSubItem.ControlResizeBehavior == ControlResizeBehavior.HeightFit || containerListViewSubItem.ControlResizeBehavior == ControlResizeBehavior.BothFit)
                    {
                        num4 = item.Height - itemControl.Margin.Top - itemControl.Margin.Bottom;
                    }
                    if (containerListViewSubItem.ControlResizeBehavior == ControlResizeBehavior.WidthFitMaintainRatio || containerListViewSubItem.ControlResizeBehavior == ControlResizeBehavior.WidthFit || containerListViewSubItem.ControlResizeBehavior == ControlResizeBehavior.BothFit)
                    {
                        num3 = rectangle.Width - itemControl.Margin.Left - itemControl.Margin.Right;
                    }
                    if (containerListViewSubItem.ControlResizeBehavior == ControlResizeBehavior.HeightFitMaintainRatio)
                    {
                        num3 = num4 * itemControlInitialSize.Width / itemControlInitialSize.Height;
                        if (num3 > rectangle.Width)
                        {
                            num3 = rectangle.Width;
                            num4 = num3 * itemControlInitialSize.Height / itemControlInitialSize.Width;
                        }
                    }
                    else if (containerListViewSubItem.ControlResizeBehavior == ControlResizeBehavior.WidthFitMaintainRatio)
                    {
                        num4 = num3 * itemControlInitialSize.Height / itemControlInitialSize.Width;
                        if (num4 > itemBounds.Height)
                        {
                            num4 = itemBounds.Height;
                            num3 = num4 * itemControlInitialSize.Width / itemControlInitialSize.Height;
                        }
                    }
                    int x;
                    if (containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.MiddleRight || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.TopRight || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.BottomRight)
                    {
                        x = rectangle.Right - 3 - num3;
                    }
                    else if (containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.MiddleCenter || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.TopCenter || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.BottomCenter)
                    {
                        x = rectangle.Left + (rectangle.Width - num3) / 2;
                    }
                    else
                    {
                        x = rectangle.Left + itemControl.Margin.Left;
                    }
                    int y2 = itemBounds.Top + (itemBounds.Height - num4) / 2;
                    itemControl.SetBounds(x, y2, num3, num4, BoundsSpecified.All);
                    itemControl.Visible = true;
                    if (this._detailVisibleRect.Contains(itemControl.Bounds))
                    {
                        itemControl.Region = null;
                    }
                    else
                    {
                        Rectangle rect = Rectangle.Intersect(itemControl.Bounds, this._detailVisibleRect);
                        rect.Location = new Point(0, 0);
                        itemControl.Region = new Region(rect);
                    }
                    itemControl.Parent = this;
                }
                else
                {
                    text = containerListViewSubItem.Text;
                }
                Color foreColor = containerListViewSubItem.ForeColor;
                if (foreColor == Color.Empty)
                {
                    foreColor = item.ForeColor;
                    if (foreColor == Color.Empty)
                    {
                        foreColor = this.ForeColor;
                    }
                }
                if (text != null && text.Length != 0)
                {
                    string text2 = ContainerListView.TruncatedString(text, rectangle.Width, itemBounds.Height, num, fnt, g);
                    StringFormat format = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
                    Size size = g.MeasureString(text2, fnt).ToSize();
                    int num5;
                    if (containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.MiddleRight || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.TopRight || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.BottomRight)
                    {
                        num5 = rectangle.Right - (num + size.Width + 4);
                    }
                    else if (containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.MiddleCenter || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.TopCenter || containerListViewColumnHeader.ContentAlign == System.Drawing.ContentAlignment.BottomCenter)
                    {
                        num5 = rectangle.Left + (rectangle.Width - (num + size.Width)) / 2;
                    }
                    else
                    {
                        num5 = rectangle.Left;
                    }
                    if (num5 < rectangle.Left || text2 != text)
                    {
                        num5 = rectangle.Left;
                    }
                    g.DrawString(text2, fnt, new SolidBrush(foreColor), (float)(num5 + num), (float)(itemBounds.Top + (itemBounds.Height - size.Height) / 2), format);
                    return;
                }
            }
            else
            {
                Control itemControl2 = item.SubItems[colIndex].ItemControl;
                if (itemControl2 != null)
                {
                    itemControl2.Visible = false;
                }
            }
        }


        private void DrawTreeExpander(Graphics g, Rectangle rectangle, bool expanded)
        {
            VisualStyleElement visualStyleElement = null;
            if (this.UseVisualStyle)
            {
                visualStyleElement = (expanded ? VisualStyleElement.TreeView.Glyph.Opened : VisualStyleElement.TreeView.Glyph.Closed);
                if (!VisualStyleRenderer.IsElementDefined(visualStyleElement))
                {
                    visualStyleElement = null;
                }
            }
            if (visualStyleElement != null)
            {
                new VisualStyleRenderer(visualStyleElement).DrawBackground(g, rectangle);
                return;
            }
            Image image;
            if (expanded)
            {
                image = Resources.tv_minus;
            }
            else
            {
                image = Resources.tv_plus;
            }
            g.DrawImage(image, rectangle);
        }


        private void DrawSelectionBox(Graphics g, Rectangle r, Color border, bool drawTop, bool drawBottom)
        {
            Pen pen = new Pen(border);
            g.FillRectangle(new SolidBrush(Color.FromArgb((int)(border.A * 27 / 100), this._itemSelectedColor)), r.Left + 1, r.Top, r.Width - 2, r.Height);
            g.DrawLine(pen, r.Left, r.Top, r.Left, r.Bottom - 1);
            g.DrawLine(pen, r.Right - 1, r.Top, r.Right - 1, r.Bottom - 1);
            if (drawTop)
            {
                g.DrawLine(pen, r.Left + 1, r.Top, r.Right - 2, r.Top);
            }
            if (drawBottom)
            {
                g.DrawLine(pen, r.Left + 1, r.Bottom - 1, r.Right - 2, r.Bottom - 1);
            }
        }


        protected virtual void DrawExtra(Graphics g, Rectangle clip)
        {
            g.ResetClip();
            g.FillRectangle(SystemBrushes.Control, clip);
        }


        private ItemActivation _activationMethod;


        private BorderStyle _borderStyle = BorderStyle.Fixed3D;


        private ColumnHeaderStyle _headerStyle = ColumnHeaderStyle.Clickable;


        private ContainerListViewColumnHeaderCollection _columns;


        private ArrayList _columnDisplayOrder;


        private ArrayList _columnsSorted;


        private int _defaultItemHeight;


        private int _userHeaderHeight = 20;


        private int _headerHeight = 20;


        private int _borderSize = 2;


        private ContainerListViewItem _rootItem;


        private bool _allowColumnReorder;


        private bool _allowColumnResize = true;


        private bool _allowMultipleColumnSort;


        private bool _allowMultipleSelect;


        private bool _showRootTreeLines;


        private bool _showPlusMinus;


        private bool _showTreeLines;


        private GridLines _gridLines = GridLines.Horizontal;


        private bool _hideSelection = true;


        private bool _hoverSelection;


        private bool _itemTracking;


        private bool _columnTracking;


        private bool _fullItemSelect = true;


        private bool _captureFocusClick = true;


        private bool _visualStyles = true;


        private ContainerListViewItemCollection _items;


        private ImageList _smallImageList;


        private ImageList _selectedImageList;


        private ContainerListViewColumnHeader _hoveredColumnHeader;


        private ContainerListViewColumnHeader _pressedColumnHeader;


        private ContainerListViewColumnHeader _sizingColumnHeader;


        private int _sizingColumnDelta;


        private int _sizingColumnOriginalWidth;


        private bool _sizingColumn;


        private bool _reorderingColumn;


        private int _reorderingColumnDelta;


        private int _reorderingColumnDropIndex = -1;


        private ContainerListViewSelectedItemCollection _selectedItems;


        private ContainerListViewItem _lastUserSelectedItem;


        private ContainerListViewItem _lastUserSingleClickedItem;


        private ContainerListViewItem _focusedItem;


        private ContainerListViewItem _hoveredItem;


        private Rectangle _headerVisibleRect;


        internal Rectangle _detailVisibleRect;


        private Rectangle _detailRect;


        internal Rectangle[] _headerColumnRects;


        private Rectangle[] _headerColumnSizeRects;


        private ContextMenuStrip _headerMenu;


        private ContextMenuStrip _itemMenu;


        private ContextMenuStrip _contextMenu;


        private HScrollBar _hScrollBar;


        private VScrollBar _vScrollBar;


        private bool _isScrollingUp;


        private ToolTip _toolTipControl;


        private Stack _updateTransactions = new Stack();


        private Color _itemSelectedColor = SystemColors.Highlight;


        private SolidBrush _columnTrackingBrush = new SolidBrush(Color.WhiteSmoke);


        private SolidBrush _itemTrackingBrush = new SolidBrush(Color.WhiteSmoke);


        private SolidBrush _columnSortBrush = new SolidBrush(Color.Gainsboro);


        private Pen _gridLinePen = new Pen(Color.WhiteSmoke);


        private TextureBrush _backgroundImageBrush;


        private Point _lastClickedPoint;


        private ArrayList _visibleItems = new ArrayList();


        private EventHandler _selectedItemsChanged;


        private ContainerListViewEventHandler _columnClick;


        private ContainerListViewEventHandler _columnReordered;


        private ContainerListViewEventHandler _popColumnContextMenu;


        private ContainerListViewEventHandler _popItemContextMenu;


        private ContainerListViewEventHandler _popContextMenu;


        private ContainerListViewEventHandler _itemExpanded;


        private ContainerListViewEventHandler _itemCollapsed;


        private ContainerListViewCancelEventHandler _itemExpanding;


        private ContainerListViewCancelEventHandler _itemCollapsing;


        private ItemDragEventHandler _itemDrag;
    }
}
