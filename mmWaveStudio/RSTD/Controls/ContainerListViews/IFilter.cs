using System;

namespace Rstd.Controls.ContainerListViews
{

	public interface IFilter
	{
		bool Belongs(object o);
	}
}
