namespace prep.utility.searching
{
  public class CriteriaFactory<ItemToFilter, PropertyType> : ICreateMatchers<ItemToFilter, PropertyType>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public CriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFilter> equal_to(PropertyType value)
    {
      return equal_to_any(value);
    }

    public IMatchAn<ItemToFilter> equal_to_any(params PropertyType[] potential_values)
    {
      return create_using(new EqualToAny<PropertyType>(potential_values));
    }

    public IMatchAn<ItemToFilter> create_using(IMatchAn<PropertyType> criteria)
    {
      return new PropertyMatch<ItemToFilter, PropertyType>(accessor, criteria);
    }

    public IMatchAn<ItemToFilter> not_equal_to(PropertyType value)
    {
      return equal_to(value).not();
    }
  }
}