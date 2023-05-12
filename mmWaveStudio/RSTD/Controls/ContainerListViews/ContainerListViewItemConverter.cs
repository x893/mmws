using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Rstd.Controls.ContainerListViews
{

	public class ContainerListViewItemConverter : TypeConverter
	{

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}


		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value is ContainerListViewItem && destinationType == typeof(InstanceDescriptor))
			{
				ConstructorInfo constructor = typeof(ContainerListViewItem).GetConstructor(Type.EmptyTypes);
				if (constructor != null)
				{
					return new InstanceDescriptor(constructor, null, false);
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
