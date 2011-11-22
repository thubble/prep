using System;
using System.Collections.Generic;
using prep.utility.searching;
using prep.utility.sort;

namespace prep.utility
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
    {
      foreach (var item in items)
        yield return item;
    }

    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Condition<T> condition)
    {
      foreach (var item in items)
        if (condition(item)) yield return item;
    }

    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, IMatchAn<T> condition)
    {
      return items.all_items_matching(condition.matches);
    }

    public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items, IComparer<T> comparer)
    {
      var sorted = new List<T>(items);
      sorted.Sort(comparer);
      return sorted;
    }

	  public static SortedEnumerableBuilder<ItemToSort> order_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> enumerable,
		  PropertyAccessor<ItemToSort, PropertyType> accessor,
		  params PropertyType[] rankings)
	  {
		  return new SortedEnumerableBuilder<ItemToSort>(Sort<ItemToSort>.by(accessor, rankings), enumerable);
	  }

	  public static SortedEnumerableBuilder<ItemToSort> order_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> enumerable,
		  PropertyAccessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
	  {
		  return new SortedEnumerableBuilder<ItemToSort>(Sort<ItemToSort>.by(accessor), enumerable);
	  }

	  public static SortedEnumerableBuilder<ItemToSort> order_by_descending<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> enumerable,
		  PropertyAccessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
	  {
		  return new SortedEnumerableBuilder<ItemToSort>(Sort<ItemToSort>.by_descending(accessor), enumerable);
	  }
  }
}