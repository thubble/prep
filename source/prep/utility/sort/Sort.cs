using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.utility.searching;

namespace prep.utility.sort
{
	public static class Sort<ItemToSort>
	{
		public static IComparer<ItemToSort> by_descending<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
		{
			return new DescendingComparer<ItemToSort, PropertyType>(accessor);
		}
	}
}
