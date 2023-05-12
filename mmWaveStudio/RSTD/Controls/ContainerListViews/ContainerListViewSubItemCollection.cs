using System;
using System.Collections;

namespace Rstd.Controls.ContainerListViews
{

	public sealed class ContainerListViewSubItemCollection : IList, ICollection, IEnumerable
	{

		internal ContainerListViewSubItemCollection(ContainerListViewItem item)
		{
			this._owningItem = item;
			if (this._owningItem.ListView != null)
			{
				this._data = new ArrayList(this._owningItem.ListView.Columns.Count);
				return;
			}
			this._data = new ArrayList();
		}


		public ContainerListViewSubItem this[int index]
		{
			get
			{
				return this._data[index] as ContainerListViewSubItem;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value", "ContainerListViewItem cannot contain null sub items");
				}
				if (value != this._data[index])
				{
					this[index].Collection = null;
					this._data[index] = value;
					value.Collection = this;
				}
			}
		}



		public int Count
		{
			get
			{
				return this._data.Count;
			}
		}



		public ContainerListViewItem OwningItem
		{
			get
			{
				return this._owningItem;
			}
		}


		public int Add(ContainerListViewSubItem subItem)
		{
			if (this._owningItem.ListView != null)
			{
				throw new NotSupportedException("Cannot modify sub item collection while the item is attached to a list.");
			}
			int count = this._data.Count;
			this.InternalInsert(count, subItem);
			return count;
		}


		public void Insert(int index, ContainerListViewSubItem subItem)
		{
			if (this._owningItem.ListView != null)
			{
				throw new NotSupportedException("Cannot modify sub item collection while the item is attached to a list.");
			}
			this.InternalInsert(index, subItem);
		}


		public void Remove(ContainerListViewSubItem subItem)
		{
			if (subItem == null)
			{
				return;
			}
			if (this._owningItem.ListView != null)
			{
				throw new NotSupportedException("Cannot modify sub item collection while the item is attached to a list.");
			}
			object syncRoot = this._data.SyncRoot;
			lock (syncRoot)
			{
				this._data.Remove(subItem);
				subItem.Collection = null;
				if (subItem.ItemControl != null)
				{
					subItem.ItemControl.Visible = false;
				}
			}
		}


		public void RemoveAt(int index)
		{
			if (this._owningItem.ListView != null)
			{
				throw new NotSupportedException("Cannot modify a sub item collection while the item is attached to a list.");
			}
			ContainerListViewSubItem containerListViewSubItem = this[index];
			object syncRoot = this._data.SyncRoot;
			lock (syncRoot)
			{
				this._data.RemoveAt(index);
				containerListViewSubItem.Collection = null;
				if (containerListViewSubItem.ItemControl != null)
				{
					containerListViewSubItem.ItemControl.Visible = false;
				}
			}
		}


		public void AddRange(ContainerListViewSubItem[] subItems)
		{
			if (subItems == null)
			{
				return;
			}
			if (this._owningItem.ListView != null)
			{
				throw new NotSupportedException("Cannot modify sub item collection while the item is attached to a list.");
			}
			object syncRoot = this._data.SyncRoot;
			lock (syncRoot)
			{
				foreach (ContainerListViewSubItem subItem in subItems)
				{
					this.Add(subItem);
				}
			}
		}


		public int IndexOf(ContainerListViewSubItem item)
		{
			return this._data.IndexOf(item);
		}


		public bool Contains(ContainerListViewSubItem item)
		{
			return this._data.Contains(item);
		}


		public void Clear()
		{
			if (this._owningItem.ListView != null)
			{
				throw new NotSupportedException("Cannot modify sub item collection while the item is attached to a list.");
			}
			object syncRoot = this._data.SyncRoot;
			lock (syncRoot)
			{
				this._data.Clear();
			}
		}


		public void CopyTo(ContainerListViewSubItem[] array, int arrayIndex)
		{
			this._data.CopyTo(array, arrayIndex);
		}


		internal void InternalInsert(int index, ContainerListViewSubItem subItem)
		{
			object syncRoot = this._data.SyncRoot;
			lock (syncRoot)
			{
				this._data.Insert(index, subItem);
				subItem.Collection = this;
			}
		}


		internal void AdjustSize(int newSize)
		{
			for (int i = this.Count; i < newSize; i++)
			{
				this.InternalInsert(i, new ContainerListViewSubItem(i));
			}
			for (int j = this.Count - 1; j >= newSize; j--)
			{
				this._data.RemoveAt(j);
			}
		}


		int IList.Add(object value)
		{
			return this.Add(value as ContainerListViewSubItem);
		}


		bool IList.Contains(object value)
		{
			return this.Contains(value as ContainerListViewSubItem);
		}


		int IList.IndexOf(object value)
		{
			return this.IndexOf(value as ContainerListViewSubItem);
		}


		void IList.Insert(int index, object value)
		{
			this.Insert(index, value as ContainerListViewSubItem);
		}


		void IList.Remove(object value)
		{
			this.Remove(value as ContainerListViewSubItem);
		}



		bool IList.IsFixedSize
		{
			get
			{
				return false;
			}
		}



		bool IList.IsReadOnly
		{
			get
			{
				return false;
			}
		}


		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (value as ContainerListViewSubItem);
			}
		}


		void ICollection.CopyTo(Array array, int index)
		{
			this._data.CopyTo(array, index);
		}



		object ICollection.SyncRoot
		{
			get
			{
				return this._data.SyncRoot;
			}
		}



		bool ICollection.IsSynchronized
		{
			get
			{
				return this._data.IsSynchronized;
			}
		}


		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._data.GetEnumerator();
		}


		private ContainerListViewItem _owningItem;


		private ArrayList _data;
	}
}
