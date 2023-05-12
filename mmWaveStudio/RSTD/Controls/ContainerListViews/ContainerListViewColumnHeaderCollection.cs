using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Rstd.Controls.ContainerListViews
{

	public sealed class ContainerListViewColumnHeaderCollection : IList, ICollection, IEnumerable
	{

		internal ContainerListViewColumnHeaderCollection(ContainerListView listView)
		{
			this._listView = listView;
		}


		public ContainerListViewColumnHeader this[int index]
		{
			get
			{
				return this._physicalData[index] as ContainerListViewColumnHeader;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value", "ContainerListView cannot contain null ContainerListViewColumnHeaders");
				}
				if (value == this._physicalData[index])
				{
					return;
				}
				ContainerListViewColumnHeader containerListViewColumnHeader = this[index];
				if (value.Collection == this)
				{
					this._physicalData[value.Index] = containerListViewColumnHeader;
					this._physicalData[index] = value;
					return;
				}
				containerListViewColumnHeader.Collection = null;
				if (value.Collection != null)
				{
					value.Collection.Remove(value);
				}
				this._physicalData[index] = value;
				this._logicalData[index] = value;
				value.Collection = this;
			}
		}



		public int Count
		{
			get
			{
				return this._physicalData.Count;
			}
		}



		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}



		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}



		public object SyncRoot
		{
			get
			{
				return this._physicalData.SyncRoot;
			}
		}



		public bool IsSynchronized
		{
			get
			{
				return this._physicalData.IsSynchronized;
			}
		}



		public ContainerListView ListView
		{
			get
			{
				return this._listView;
			}
		}


		public int Add(ContainerListViewColumnHeader column)
		{
			int count = this._physicalData.Count;
			this.Insert(count, column);
			return count;
		}


		public ContainerListViewColumnHeader Add(string text)
		{
			return this.Insert(this._physicalData.Count, text);
		}


		public ContainerListViewColumnHeader Add(string text, int width)
		{
			return this.Insert(this._physicalData.Count, text, width);
		}


		public ContainerListViewColumnHeader Add(string text, int width, SortDataType sortDataType)
		{
			return this.Insert(this._physicalData.Count, text, width, sortDataType);
		}


		public ContainerListViewColumnHeader Add(string text, int width, HorizontalAlignment horizontalAlign)
		{
			return this.Insert(this._physicalData.Count, text, width, horizontalAlign);
		}


		public ContainerListViewColumnHeader Add(string text, int width, ContentAlignment contentAlign)
		{
			return this.Insert(this._physicalData.Count, text, width, contentAlign);
		}


		public void AddRange(ContainerListViewColumnHeader[] columns)
		{
			if (columns == null)
			{
				return;
			}
			this._listView.BeginUpdate();
			object syncRoot = this._physicalData.SyncRoot;
			lock (syncRoot)
			{
				for (int i = 0; i < columns.Length; i++)
				{
					this.Add(columns[i]);
				}
			}
			this._listView.EndUpdate();
		}


		public void Insert(int index, ContainerListViewColumnHeader column)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			object syncRoot = this._physicalData.SyncRoot;
			lock (syncRoot)
			{
				this._physicalData.Insert(index, column);
				this._logicalData.Add(column);
				column.Collection = this;
			}
			if (this.ListView != null)
			{
				foreach (object obj in ((IEnumerable)this.ListView.Items))
				{
					((ContainerListViewItem)obj).SubItems.InternalInsert(index, new ContainerListViewSubItem(index));
				}
				this.ListView.ColumnInvalidated(column, true, true);
			}
		}


		public ContainerListViewColumnHeader Insert(int index, string text)
		{
			ContainerListViewColumnHeader containerListViewColumnHeader = new ContainerListViewColumnHeader(text);
			this.Insert(index, containerListViewColumnHeader);
			return containerListViewColumnHeader;
		}


		public ContainerListViewColumnHeader Insert(int index, string text, int width)
		{
			ContainerListViewColumnHeader containerListViewColumnHeader = new ContainerListViewColumnHeader(text, width);
			this.Insert(index, containerListViewColumnHeader);
			return containerListViewColumnHeader;
		}


		public ContainerListViewColumnHeader Insert(int index, string text, int width, SortDataType sortDataType)
		{
			ContainerListViewColumnHeader containerListViewColumnHeader = new ContainerListViewColumnHeader(text, width);
			containerListViewColumnHeader.SortDataType = sortDataType;
			this.Insert(index, containerListViewColumnHeader);
			return containerListViewColumnHeader;
		}


		public ContainerListViewColumnHeader Insert(int index, string text, int width, HorizontalAlignment horizontalAlign)
		{
			ContainerListViewColumnHeader containerListViewColumnHeader = new ContainerListViewColumnHeader(text, width, horizontalAlign);
			this.Insert(index, containerListViewColumnHeader);
			return containerListViewColumnHeader;
		}


		public ContainerListViewColumnHeader Insert(int index, string text, int width, ContentAlignment contentAlign)
		{
			ContainerListViewColumnHeader containerListViewColumnHeader = new ContainerListViewColumnHeader(text, width, contentAlign);
			this.Insert(index, containerListViewColumnHeader);
			return containerListViewColumnHeader;
		}


		public void Remove(ContainerListViewColumnHeader column)
		{
			this.Remove(column, false);
		}


		public void Remove(ContainerListViewColumnHeader column, bool removeSubItems)
		{
			if (column == null)
			{
				return;
			}
			object syncRoot = this._physicalData.SyncRoot;
			lock (syncRoot)
			{
				if (this._listView != null)
				{
					if (removeSubItems)
					{
						foreach (ContainerListViewItem obj in _listView.Items)
							obj.RemoveSubItem(column.Index);
					}
					else
					{
						foreach (ContainerListViewItem obj2 in ((IEnumerable)this._listView.Items))
						{
							Control itemControl = obj2.SubItems[column.Index].ItemControl;
							if (itemControl != null)
								itemControl.Visible = false;
						}
					}
				}
				_physicalData.Remove(column);
				_logicalData.Remove(column);
				column.Collection = null;
			}
			if (this.ListView != null)
			{
				this.ListView.ColumnInvalidated(column, true, true);
			}
		}


		public void RemoveAt(int index)
		{
			this.RemoveAt(index, false);
		}


		public void RemoveAt(int index, bool removeSubItems)
		{
			this.Remove(this[index], removeSubItems);
		}


		public int IndexOf(ContainerListViewColumnHeader column)
		{
			return this._physicalData.IndexOf(column);
		}


		public int DisplayIndexOf(ContainerListViewColumnHeader column)
		{
			return this._logicalData.IndexOf(column);
		}


		public bool Contains(ContainerListViewColumnHeader column)
		{
			return this._physicalData.Contains(column);
		}


		public void Clear()
		{
			this._listView.BeginUpdate();
			object syncRoot = this._physicalData.SyncRoot;
			lock (syncRoot)
			{
				for (int i = 0; i < this._physicalData.Count; i++)
				{
					this[i].Collection = null;
				}
				this._physicalData.Clear();
				this._logicalData.Clear();
			}
			this._listView.EndUpdate();
		}


		public void CopyTo(ContainerListViewItem[] array, int arrayIndex)
		{
			this._physicalData.CopyTo(array, arrayIndex);
		}


		public IEnumerator GetEnumerator()
		{
			return this._physicalData.GetEnumerator();
		}


		public IEnumerable GetDisplayOrderEnumerator()
		{
			return this._logicalData;
		}


		internal void SetDisplayIndex(ContainerListViewColumnHeader column, int newDisplayIndex)
		{
			if (!this.Contains(column))
			{
				return;
			}
			if (newDisplayIndex >= this.Count)
			{
				newDisplayIndex = this.Count - 1;
			}
			int displayIndex = column.DisplayIndex;
			if (displayIndex == newDisplayIndex)
			{
				return;
			}
			this._logicalData.RemoveAt(displayIndex);
			this._logicalData.Insert(newDisplayIndex, column);
			if (this._listView != null)
			{
				this._listView.ColumnInvalidated(null, false, true);
			}
		}


		int IList.Add(object value)
		{
			return this.Add(value as ContainerListViewColumnHeader);
		}


		bool IList.Contains(object value)
		{
			return this.Contains(value as ContainerListViewColumnHeader);
		}


		int IList.IndexOf(object value)
		{
			return this.IndexOf(value as ContainerListViewColumnHeader);
		}


		void IList.Insert(int index, object value)
		{
			this.Insert(index, value as ContainerListViewColumnHeader);
		}


		void IList.Remove(object value)
		{
			this.Remove(value as ContainerListViewColumnHeader);
		}


		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (value as ContainerListViewColumnHeader);
			}
		}


		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyTo((ContainerListViewItem[])array, index);
		}


		private ContainerListView _listView;


		private ArrayList _physicalData = new ArrayList();


		private ArrayList _logicalData = new ArrayList();
	}
}
