using System;

namespace prep.utility.ranges
{
  public class RangeWithNoUpperBound<T> : Range<T> where T : IComparable<T>
  {
    T start;

    public RangeWithNoUpperBound(T start)
    {
      this.start = start;
    }

    public bool contains(T item)
    {
      return item.CompareTo(start) > 0;
    }
  }
}