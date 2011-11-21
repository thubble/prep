using System;

namespace prep.utility.searching
{
  public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    public IMatchAn<ItemToFilter> greater_than(PropertyType value)
    {
      throw new NotImplementedException();
    }

    public IMatchAn<ItemToFilter> between(PropertyType start, PropertyType end)
    {
      throw new NotImplementedException();
    }
  }
}