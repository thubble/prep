using System.Collections.Generic;
using prep.utility.searching;

namespace prep.utility.sort
{
  public class PropertyComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
  {
    IComparer<PropertyType> real_comparison;
    PropertyAccessor<ItemToSort, PropertyType> accessor;

    public PropertyComparer(IComparer<PropertyType> real_comparison, PropertyAccessor<ItemToSort, PropertyType> accessor)
    {
      this.real_comparison = real_comparison;
      this.accessor = accessor;
    }

    public int Compare(ItemToSort x, ItemToSort y)

    {
      return real_comparison.Compare(accessor(x), accessor(y));
    }
  }
}