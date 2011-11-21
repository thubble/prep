using System.Collections.Generic;
using prep.collections;

namespace prep.utility.searching
{
  public static class Where<ItemToFilter>
  {
    public static CriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      return new CriteriaFactory<ItemToFilter, PropertyType>(accessor);
    }
  }

  public class CriteriaFactory<ItemToFilter, PropertyType>
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
      return new AnonymousCriteria<ItemToFilter>(x => new List<PropertyType>(potential_values).Contains(accessor(x)));
    }

    public IMatchAn<ItemToFilter> not_equal_to(PropertyType value)
    {
      throw new System.NotImplementedException();
    }
  }
}