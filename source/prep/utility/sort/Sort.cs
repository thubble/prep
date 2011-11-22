﻿using System;
using System.Collections.Generic;
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
        new ComparerBuilder<ItemToSort>(
          new ReverseComparer<ItemToSort>(new ComparableComparer<ItemToSort, PropertyType>(accessor)));
    }

    public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor,
                                                               params PropertyType[] rankings)
    {
      throw new NotImplementedException();
    }

    public static ComparerBuilder<ItemToSort> by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return new ComparerBuilder<ItemToSort>(new ComparableComparer<ItemToSort, PropertyType>(accessor));
    }
  }

  public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
  {
    IComparer<ItemToSort> comparer;

    public ComparerBuilder(IComparer<ItemToSort> comparer)
    {
      this.comparer = comparer;
    }

    public int Compare(ItemToSort x, ItemToSort y)
    {
      return comparer.Compare(x, y);
    }

    public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor,
                                                             params PropertyType[] values)
    {
      throw new NotImplementedException();
    }
  }
}