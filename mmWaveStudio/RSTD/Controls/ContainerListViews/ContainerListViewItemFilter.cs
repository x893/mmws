using System;
using System.Globalization;

namespace Rstd.Controls.ContainerListViews
{

	public class ContainerListViewItemFilter : IFilter
	{

		public ContainerListViewItemFilter(int columnIndex, string filterText)
		{
			this._columnIndex = columnIndex;
			if (filterText == null)
			{
				throw new ArgumentException("filterText", "filterText cannot be null. To reset the filter, call containerListView.ResetFilter()");
			}
			this._string = filterText.ToLower(CultureInfo.CurrentCulture);
		}


		public bool Belongs(object o)
		{
			ContainerListViewItem containerListViewItem = o as ContainerListViewItem;
			return o != null && containerListViewItem.SubItems[this._columnIndex].Text.ToLower(CultureInfo.CurrentCulture).IndexOf(this._string) != -1;
		}


		private int _columnIndex;


		private string _string;
	}
}
