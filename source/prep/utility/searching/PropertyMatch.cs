namespace prep.utility.searching
{
  public class PropertyMatch<ItemToFilter,PropertyType> : IMatchAn<ItemToFilter>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;
    IMatchAn<PropertyType> real_criteria;

    public PropertyMatch(PropertyAccessor<ItemToFilter, PropertyType> accessor, IMatchAn<PropertyType> real_criteria)
    {
      this.accessor = accessor;
      this.real_criteria = real_criteria;
    }

    public bool matches(ItemToFilter item)
    {
      return real_criteria.matches(accessor(item));
    }
  }
}