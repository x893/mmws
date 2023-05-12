using System;

namespace Rstd.Controls.ContainerListViews
{

	public static class Helpers
	{
		public static void Swap<T>(ref T a, ref T b)
		{
			T t = a;
			a = b;
			b = t;
		}
	}
}
