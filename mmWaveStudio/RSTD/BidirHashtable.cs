using System;
using System.Collections;
using System.Collections.Generic;

namespace RSTD
{
	public class BidirHashtable<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		public void Add(TKey key, TValue value)
		{
			this.m_Forward.Add(key, value);
			this.m_Backward.Add(value, key);
		}

		public bool ContainsKey(TKey key)
		{
			return this.m_Forward.ContainsKey(key);
		}

		public ICollection<TKey> Keys
		{
			get
			{
				return this.m_Forward.Keys;
			}
		}

		public bool Remove(TKey key)
		{
			this.m_Backward.Remove(this.m_Forward[key]);
			return this.m_Forward.Remove(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.m_Forward.TryGetValue(key, out value);
		}

		public ICollection<TValue> Values
		{
			get
			{
				return this.m_Forward.Values;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				return this.m_Forward[key];
			}
			set
			{
				this.m_Forward[key] = value;
			}
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			((ICollection<KeyValuePair<TKey, TValue>>)this.m_Forward).Add(item);
			((ICollection<KeyValuePair<TValue, TKey>>)this.m_Backward).Add(new KeyValuePair<TValue, TKey>(item.Value, item.Key));
		}

		public void Clear()
		{
			((ICollection<KeyValuePair<TKey, TValue>>)this.m_Forward).Clear();
			((ICollection<KeyValuePair<TValue, TKey>>)this.m_Backward).Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return ((ICollection<KeyValuePair<TKey, TValue>>)this.m_Forward).Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<TKey, TValue>>)this.m_Forward).CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get
			{
				return ((ICollection<KeyValuePair<TKey, TValue>>)this.m_Forward).Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return ((ICollection<KeyValuePair<TKey, TValue>>)this.m_Forward).IsReadOnly;
			}
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			this.m_Backward.Remove(item.Value);
			return ((ICollection<KeyValuePair<TKey, TValue>>)this.m_Forward).Remove(item);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return ((IEnumerable<KeyValuePair<TKey, TValue>>)this.m_Forward).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.m_Forward.GetEnumerator();
		}

		public bool ContainsValue(TValue value)
		{
			return this.m_Backward.ContainsKey(value);
		}

		public TKey ReverseLookup(TValue value)
		{
			return this.m_Backward[value];
		}

		private Dictionary<TKey, TValue> m_Forward = new Dictionary<TKey, TValue>();

		private Dictionary<TValue, TKey> m_Backward = new Dictionary<TValue, TKey>();
	}
}
