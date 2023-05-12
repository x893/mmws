using System;
using System.Collections;
using System.Collections.Generic;

namespace Rstd.Controls.ContainerListViews
{

	public sealed class ContainerListViewSelectedItemCollection : IList, ICollection, IEnumerable, IList<ContainerListViewItem>, ICollection<ContainerListViewItem>, IEnumerable<ContainerListViewItem>
	{

		internal ContainerListViewSelectedItemCollection(ContainerListView listView)
		{
			this._listView = listView;
		}


		public ContainerListViewItem this[int index]
		{
			get
			{
				return this._data[index] as ContainerListViewItem;
			}
			set
			{
				this.Insert(index, value);
			}
		}


		public int Add(ContainerListViewItem item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (item.ListView != this._listView)
			{
				throw new ArgumentException("Cannot select an item that isn't part of this ContainerListView", "item");
			}
			return this._data.Add(item);
		}


		public void Insert(int index, ContainerListViewItem item)
		{
			throw new NotSupportedException("Cannot insert an item into the selected collection at an arbitrary location.");
		}


		public void Remove(ContainerListViewItem item)
		{
			this._data.Remove(item);
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
					this._data.Add(items[i]);
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
			this._listView.ClearSelectedItems(true);
		}



		public int Count
		{
			get
			{
				return this._data.Count;
			}
		}


		public void CopyTo(ContainerListViewItem[] array, int arrayIndex)
		{
			this._data.CopyTo(array, arrayIndex);
		}


		internal void InternalClear()
		{
			this._data.Clear();
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
				throw new NotSupportedException("Cannot insert an item at an arbitrary position.  Use Add instead.");
			}
		}


		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			this.CopyTo((ContainerListViewItem[])array, arrayIndex);
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


		public void RemoveAt(int index)
		{
			this._data.RemoveAt(index);
		}



		public bool IsReadOnly
		{
			get
			{
				return this._data.IsReadOnly;
			}
		}


		bool ICollection<ContainerListViewItem>.Remove(ContainerListViewItem item)
		{
			this.Remove(item);
			return true;
		}


		void ICollection<ContainerListViewItem>.Add(ContainerListViewItem item)
		{
			this.Add(item);
		}


		public IEnumerator<ContainerListViewItem> GetEnumerator()
		{
			int num;
			for (int i = 0; i < this._data.Count; i = num + 1)
			{
				yield return this._data[i] as ContainerListViewItem;
				num = i;
			}
			yield break;
		}


		private ContainerListView _listView;


		private ArrayList _data = new ArrayList();
	}
}
