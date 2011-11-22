using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.utility.searching;

namespace prep.utility.sort
{
	public class DescendingComparer<ItemToSort, PropertyType> : IComparer<ItemToSort> where PropertyType : IComparable<PropertyType>
	{
		protected PropertyAccessor<ItemToSort, PropertyType> accessor;

		public DescendingComparer(PropertyAccessor<ItemToSort, PropertyType> accessor)
		{
			this.accessor = accessor;
		}


		public int Compare(ItemToSort x, ItemToSort y)
		{
			return accessor(y).CompareTo(accessor(x));
		}
	}
}
