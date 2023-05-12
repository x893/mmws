using System;
using System.Collections;
using System.Collections.Generic;

namespace Rstd.Controls.ContainerListViews
{

	public sealed class ContainerListViewItemCollection : IList, ICollection, IEnumerable
	{

		internal ContainerListViewItemCollection(ContainerListViewItem owningItem)
		{
			this._owningItem = owningItem;
		}


		public ContainerListViewItem this[int index]
		{
			get
			{
				return this._data[index] as ContainerListViewItem;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value", "ContainerListView cannot contain null ContainerListViewItems");
				}
				if (value != this._data[index])
				{
					this[index].OwnerListView = null;
					this._data[index] = value;
					value.OwnerListView = this._listView;
				}
			}
		}


		public int Add(ContainerListViewItem item)
		{
			int count = this._data.Count;
			this.Insert(count, item);
			return count;
		}


		public ContainerListViewItem Add(string text)
		{
			return this.Insert(this._data.Count, text);
		}


		public ContainerListViewItem Add(string text, int imageIndex)
		{
			return this.Insert(this._data.Count, text, imageIndex);
		}


		public ContainerListViewItem Add(string text, int imageIndex, int selectedImageIndex)
		{
			return this.Insert(this._data.Count, text, imageIndex, selectedImageIndex);
		}


		public void Insert(int index, ContainerListViewItem item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (this._data.Count != 0 && index > 0)
			{
				ContainerListViewItem containerListViewItem = this._data[index - 1] as ContainerListViewItem;
				item.InternalPreviousItem = containerListViewItem;
				containerListViewItem.InternalNextItem = item;
			}
			if (this._data.Count - 1 >= index)
			{
				ContainerListViewItem internalNextItem = this._data[index] as ContainerListViewItem;
				item.InternalNextItem = internalNextItem;
			}
			object syncRoot = this._data.SyncRoot;
			lock (syncRoot)
			{
				this._data.Insert(index, item);
			}
			item.InternalParentItem = this._owningItem;
			item.OwnerListView = this._listView;
			foreach (object obj in ((IEnumerable)item.Items))
			{
				((ContainerListViewItem)obj).OwnerListView = this._listView;
			}
		}


		public ContainerListViewItem Insert(int index, string text)
		{
			ContainerListViewItem containerListViewItem = new ContainerListViewItem(text);
			this.Insert(index, containerListViewItem);
			return containerListViewItem;
		}


		public ContainerListViewItem Insert(int index, string text, int imageIndex)
		{
			ContainerListViewItem containerListViewItem = new ContainerListViewItem(text, imageIndex);
			this.Insert(index, containerListViewItem);
			return containerListViewItem;
		}


		public ContainerListViewItem Insert(int index, string text, int imageIndex, int selectedImageIndex)
		{
			ContainerListViewItem containerListViewItem = new ContainerListViewItem(text, imageIndex, selectedImageIndex);
			this.Insert(index, containerListViewItem);
			return containerListViewItem;
		}


		public void Remove(ContainerListViewItem item)
		{
			if (item == null)
			{
				return;
			}
			this._listView.BeginUpdate();
			ContainerListViewItem startAt = this.RemoveInternal(item);
			this._listView.RecalculateItemPositions(startAt);
			this._listView.EndUpdate();
		}


		public void RemoveRange(ContainerListViewItemCollection items)
		{
			if (items == null)
			{
				return;
			}
			this._listView.BeginUpdate();
			ContainerListViewItem containerListViewItem = null;
			for (int i = items.Count - 1; i >= 0; i--)
			{
				ContainerListViewItem containerListViewItem2 = this.RemoveInternal(items[i]);
				if (containerListViewItem == null || containerListViewItem2.Y < containerListViewItem.Y)
				{
					containerListViewItem = containerListViewItem2;
				}
			}
			this._listView.RecalculateItemPositions(containerListViewItem);
			this._listView.EndUpdate();
		}


		public void RemoveRange(IList<ContainerListViewItem> items)
		{
			if (items == null)
			{
				return;
			}
			this._listView.BeginUpdate();
			ContainerListViewItem containerListViewItem = null;
			for (int i = items.Count - 1; i >= 0; i--)
			{
				ContainerListViewItem containerListViewItem2 = this.RemoveInternal(items[i]);
				if (containerListViewItem == null || containerListViewItem2.Y < containerListViewItem.Y)
				{
					containerListViewItem = containerListViewItem2;
				}
			}
			this._listView.RecalculateItemPositions(containerListViewItem);
			this._listView.EndUpdate();
		}


		internal ContainerListViewItem RemoveInternal(ContainerListViewItem item)
		{
			ContainerListViewItem result = null;
			if (item.InternalPreviousItem != null && item.InternalNextItem != null)
			{
				item.InternalPreviousItem.InternalNextItem = item.InternalNextItem;
				item.InternalNextItem.InternalPreviousItem = item.InternalPreviousItem;
				result = item.InternalPreviousItem;
			}
			else if (item.InternalPreviousItem != null)
			{
				item.InternalPreviousItem.InternalNextItem = null;
				result = item.InternalPreviousItem;
			}
			else if (item.InternalNextItem != null)
			{
				item.InternalNextItem.InternalPreviousItem = null;
			}
			object syncRoot = this._data.SyncRoot;
			lock (syncRoot)
			{
				this._data.Remove(item);
			}
			item.Selected = false;
			item.Focused = false;
			item.OwnerListView = null;
			item.InternalParentItem = null;
			foreach (object obj in ((IEnumerable)item.SubItems))
			{
				ContainerListViewSubItem containerListViewSubItem = (ContainerListViewSubItem)obj;
				if (containerListViewSubItem.ItemControl != null)
				{
					containerListViewSubItem.ItemControl.Visible = false;
				}
			}
			return result;
		}


		public void AddRange(ContainerListViewItem[] items)
		{
			if (items == null)
			{
				return;
			}
			this._listView.BeginUpdate();
			object syncRoot = this._data.SyncRoot;
			lock (syncRoot)
			{
				for (int i = 0; i < items.Length; i++)
				{
					this.Add(items[i]);
				}
			}
			this._listView.EndUpdate();
		}


		public int IndexOf(ContainerListViewItem item)
		{
			return this._data.IndexOf(item);
		}


		public bool Contains(ContainerListViewItem item)
		{
			return this._data.Contains(item);
		}


		public void Clear()
		{
			this._listView.BeginUpdate();
			if (this._listView.SelectedItems.Count > 0)
			{
				this._listView.SelectedItems.Clear();
			}
			for (int i = 0; i < this._data.Count; i++)
			{
				ContainerListViewItem containerListViewItem = this[i];
				containerListViewItem.Selected = false;
				containerListViewItem.Focused = false;
				containerListViewItem.OwnerListView = null;
				for (int j = 0; j < containerListViewItem.SubItems.Count; j++)
				{
					if (containerListViewItem.SubItems[j].ItemControl != null)
					{
						containerListViewItem.SubItems[j].ItemControl.Parent = null;
						containerListViewItem.SubItems[j].ItemControl.Visible = false;
						containerListViewItem.SubItems[j].ItemControl = null;
					}
				}
			}
			this._data.Clear();
			this._listView.EndUpdate();
		}


		public void Sort(IComparer comparer, bool recursiveSort)
		{
			try
			{
				this._data.Sort(comparer);
				ContainerListViewItem containerListViewItem = null;
				ContainerListViewItem containerListViewItem2 = null;
				for (int i = 0; i < this._data.Count; i++)
				{
					containerListViewItem2 = this[i];
					containerListViewItem2.InternalPreviousItem = containerListViewItem;
					if (containerListViewItem != null)
					{
						containerListViewItem.InternalNextItem = containerListViewItem2;
					}
					containerListViewItem = containerListViewItem2;
					if (recursiveSort && containerListViewItem2.HasChildren)
					{
						containerListViewItem2.Items.Sort(comparer, recursiveSort);
					}
				}
				if (containerListViewItem2 != null)
				{
					containerListViewItem2.InternalNextItem = null;
				}
			}
			catch
			{
			}
		}


		public void CopyTo(ContainerListViewItem[] array, int arrayIndex)
		{
			this._data.CopyTo(array, arrayIndex);
		}



		public int Count
		{
			get
			{
				return this._data.Count;
			}
		}


		int IList.Add(object value)
		{
			return this.Add(value as ContainerListViewItem);
		}


		bool IList.Contains(object value)
		{
			return this.Contains(value as ContainerListViewItem);
		}


		int IList.IndexOf(object value)
		{
			return this.IndexOf(value as ContainerListViewItem);
		}


		void IList.Insert(int index, object value)
		{
			this.Insert(index, value as ContainerListViewItem);
		}


		void IList.Remove(object value)
		{
			this.Remove(value as ContainerListViewItem);
		}


		void IList.RemoveAt(int index)
		{
			this._data.RemoveAt(index);
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
				this[index] = (value as ContainerListViewItem);
			}
		}


		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyTo((ContainerListViewItem[])array, index);
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



		internal ContainerListView InternalListView
		{
			set
			{
				this._listView = value;
			}
		}


		private ContainerListView _listView;


		private ContainerListViewItem _owningItem;


		private ArrayList _data = new ArrayList();
	}
}
