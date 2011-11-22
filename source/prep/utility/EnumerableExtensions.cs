﻿using System.Collections.Generic;
using prep.utility.searching;

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
  }
}