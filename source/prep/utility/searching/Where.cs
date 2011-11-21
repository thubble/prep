using System;

namespace prep.utility.searching
{
	public static class Where<ItemToFilter>
	{
		public static CriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
		  PropertyAccessor<ItemToFilter, PropertyType> accessor)
		{
			return new CriteriaFactory<ItemToFilter, PropertyType>(accessor);
		}

		public static ComparableCriteriaFactory<ItemToFilter, PropertyType> has_an<PropertyType>(PropertyAccessor<ItemToFilter, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
		{
			return new ComparableCriteriaFactory<ItemToFilter, PropertyType>(accessor,has_a(accessor));
		}
	}
}