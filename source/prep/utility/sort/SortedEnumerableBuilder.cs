using System;
using System.Collections.Generic;
using prep.utility.searching;

namespace prep.utility.sort
{
	public class SortedEnumerableBuilder<ItemToSort> : IEnumerable<ItemToSort>
	{
		ComparerBuilder<ItemToSort> comparer_builder;
		IEnumerable<ItemToSort> enumerable;

		public SortedEnumerableBuilder(ComparerBuilder<ItemToSort> comparer_builder, IEnumerable<ItemToSort> enumerable)
		{
			this.comparer_builder = comparer_builder;
			this.enumerable = enumerable;
		}

		public IEnumerator<ItemToSort> GetEnumerator()
		{
			return enumerable.sort_using(comparer_builder).GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public SortedEnumerableBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor,
		                                                                 params PropertyType[] values)
		{
			return new SortedEnumerableBuilder<ItemToSort>(this.comparer_builder.then_by(accessor, values), enumerable);
		}

		public SortedEnumerableBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
			where PropertyType : IComparable<PropertyType>
		{
			return new SortedEnumerableBuilder<ItemToSort>(this.comparer_builder.then_by(accessor), enumerable);
		}
	}
}