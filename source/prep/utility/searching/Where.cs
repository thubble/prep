namespace prep.utility.searching
{
  public static class Where<ItemToFilter>
  {
	  public static HasAConditionGenerator<ItemToFilter, PropertyType> has_a<PropertyType>(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
		return new HasAConditionGenerator<ItemToFilter, PropertyType>(accessor);
    }
  }

	public class HasAConditionGenerator<ItemToFilter, PropertyType>
	{
		private PropertyAccessor<ItemToFilter, PropertyType> _accessor;

		public HasAConditionGenerator(PropertyAccessor<ItemToFilter, PropertyType> accessor)
		{
			_accessor = accessor;
		}

		public AnonymousCriteria<ItemToFilter> equal_to(PropertyType matchValue)
		{
			Condition<ItemToFilter> condition = (ItemToFilter value) =>
													{
														return object.Equals(_accessor(value), matchValue);
													};

			return new AnonymousCriteria<ItemToFilter>(condition);
		}

		public AnonymousCriteria<ItemToFilter> equal_to_any(params PropertyType[] matchValues)
		{
			Condition<ItemToFilter> condition = (ItemToFilter value) =>
			{
				PropertyType accessedProperty = _accessor(value);
				foreach(var matchValue in matchValues)
				{
					if (object.Equals(accessedProperty, matchValue))
						return true;
				}
				return false;
			};

			return new AnonymousCriteria<ItemToFilter>(condition);
		}
	}
}