using System;
using System.Collections.Generic;
using prep.utility.searching;

namespace prep.utility.sort
{
  public class ComparableComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
    where PropertyType : IComparable<PropertyType>
  {
    protected PropertyAccessor<ItemToSort, PropertyType> accessor;

    public ComparableComparer(PropertyAccessor<ItemToSort, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public int Compare(ItemToSort x, ItemToSort y)
    {
      return accessor(x).CompareTo(accessor(y));
    }
  }
}