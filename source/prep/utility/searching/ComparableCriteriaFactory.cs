using System;

namespace prep.utility.searching
{
	public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
	{
		PropertyAccessor<ItemToFilter, PropertyType> accessor;

		public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor)
		{
			this.accessor = accessor;
		}

		public IMatchAn<ItemToFilter> greater_than(PropertyType value)
		{
			return new AnonymousCriteria<ItemToFilter>(x => accessor(x).CompareTo(value) > 0);
		}

		public IMatchAn<ItemToFilter> between(PropertyType start, PropertyType end)
		{
			return new AnonymousCriteria<ItemToFilter>(x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
		}
	}
}