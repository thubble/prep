using System;
using System.Collections.Generic;
using prep.utility.searching;

namespace prep.utility.sort
{
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
      return new ComparerBuilder<ItemToSort>(new CombinedComparer<ItemToSort>(comparer,
                                                                              Sort<ItemToSort>.by(accessor,values)));
    }

    public ComparerBuilder<ItemToSort> then_by<PropertyType>(PropertyAccessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return new ComparerBuilder<ItemToSort>(new CombinedComparer<ItemToSort>(comparer,
                                                                              Sort<ItemToSort>.by(accessor)));
    }
  }
}