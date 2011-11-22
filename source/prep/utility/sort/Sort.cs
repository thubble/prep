using System;
using prep.utility.searching;

namespace prep.utility.sort
{
  public static class Sort<ItemToSort>
  {
    public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(
      PropertyAccessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return
        new ComparerBuilder<ItemToSort>(new ReverseComparer<ItemToSort>(new PropertyComparer<ItemToSort,PropertyType>(new ComparableComparer<PropertyType>(),accessor)));
    }

    public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor,
                                                               params PropertyType[] rankings)
    {
      return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort,PropertyType>(new RankComparer<PropertyType>(rankings),accessor));
    }

    public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(new ComparableComparer<PropertyType>(),accessor));
    }
  }
}