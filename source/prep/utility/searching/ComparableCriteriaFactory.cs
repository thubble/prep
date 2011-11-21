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

		public IMatchAn<ItemToFilter> equal_to(PropertyType value)
		{
			return new CriteriaFactory<ItemToFilter, PropertyType>(accessor).equal_to(value);
		}

		public IMatchAn<ItemToFilter> equal_to_any(params PropertyType[] potential_values)
		{
			return new CriteriaFactory<ItemToFilter, PropertyType>(accessor).equal_to_any(potential_values);

		}

		public IMatchAn<ItemToFilter> not_equal_to(PropertyType value)
		{
			return new CriteriaFactory<ItemToFilter, PropertyType>(accessor).not_equal_to(value);
		}
	}
}