using System;

namespace Rstd.Controls.ContainerListViews
{

	public class FilterStub : IFilter
	{

		private FilterStub(bool value)
		{
			this._value = value;
		}

		public bool Belongs(object o)
		{
			return this._value;
		}

		public static readonly FilterStub AllFilter = new FilterStub(true);
		public static readonly FilterStub NoneFilter = new FilterStub(false);
		private bool _value;
	}
}
