using System;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;

namespace Rstd.Controls.ContainerListViews
{

	public class ContainerListViewComparer : IComparer
	{

		public ContainerListViewComparer(ContainerListView listView)
		{
			this._sortColumns = listView.SortColumns;
			this._sortColumnIndices = new int[this._sortColumns.Length];
			for (int i = 0; i < this._sortColumns.Length; i++)
			{
				this._sortColumnIndices[i] = this._sortColumns[i].Index;
			}
			this._compareInfo = CultureInfo.CurrentCulture.CompareInfo;
		}


		public int Compare(ContainerListViewItem item1, ContainerListViewItem item2)
		{
			for (int i = 0; i < this._sortColumns.Length; i++)
			{
				ContainerListViewColumnHeader containerListViewColumnHeader = this._sortColumns[i];
				int index = this._sortColumnIndices[i];
				SortOrder sortOrder = containerListViewColumnHeader.SortOrder;
				SortDataType sortDataType = containerListViewColumnHeader.SortDataType;
				if (item1 == null || item2 == null || sortOrder == SortOrder.None || sortDataType == SortDataType.None)
				{
					return 0;
				}
				ContainerListViewSubItem containerListViewSubItem = (sortOrder == SortOrder.Ascending) ? item1.SubItems[index] : item2.SubItems[index];
				ContainerListViewSubItem containerListViewSubItem2 = (sortOrder == SortOrder.Ascending) ? item2.SubItems[index] : item1.SubItems[index];
				int num;
				if (sortDataType == SortDataType.Custom)
				{
					num = containerListViewColumnHeader.CustomSortComparer.Compare(containerListViewSubItem, containerListViewSubItem2);
				}
				else
				{
					num = this.CompareItems(containerListViewSubItem.Text, containerListViewSubItem2.Text, sortDataType);
				}
				if (num != 0)
				{
					return num;
				}
			}
			return 0;
		}


		private int CompareItems(string item1, string item2, SortDataType sortDataType)
		{
			if (item1.Length == 0)
			{
				if (item2.Length == 0)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (item2.Length == 0)
				{
					return 1;
				}
				switch (sortDataType)
				{
				case SortDataType.String:
					break;
				case SortDataType.Integer:
				{
					int num;
					int value;
					if (ContainerListViewComparer.TryParseInt32(item1, out num) && ContainerListViewComparer.TryParseInt32(item2, out value))
					{
						return num.CompareTo(value);
					}
					break;
				}
				case SortDataType.Double:
				{
					double num2;
					double value2;
					if (double.TryParse(item1, NumberStyles.Float, null, out num2) && double.TryParse(item2, NumberStyles.Float, null, out value2))
					{
						return num2.CompareTo(value2);
					}
					break;
				}
				case SortDataType.Date:
					try
					{
						DateTime t = DateTime.Parse(item1, null, DateTimeStyles.None);
						DateTime t2 = DateTime.Parse(item2, null, DateTimeStyles.None);
						return DateTime.Compare(t, t2);
					}
					catch (FormatException)
					{
					}
					break;
				default:
					return 0;
				}
				return this._compareInfo.Compare(item1, item2, CompareOptions.None);
			}
		}


		private static bool TryParseInt32(string s, out int result)
		{
			bool flag = false;
			result = 0;
			if (s.Length == 0)
			{
				return false;
			}
			int i = 0;
			if (s[0] == '+')
			{
				i++;
			}
			else if (s[0] == '-')
			{
				flag = true;
				i++;
			}
			while (i < s.Length)
			{
				char c = s[i];
				if (c < '0' || c > '9')
				{
					result = 0;
					return false;
				}
				result *= 10;
				result += (int)(c - '0');
				i++;
			}
			result *= (flag ? -1 : 1);
			return true;
		}


		int IComparer.Compare(object item1, object item2)
		{
			return this.Compare(item1 as ContainerListViewItem, item2 as ContainerListViewItem);
		}


		private CompareInfo _compareInfo;


		private ContainerListViewColumnHeader[] _sortColumns;


		private int[] _sortColumnIndices;
	}
}
