using System.Collections.Generic;

namespace prep.utility.searching
{
  public class EqualToAny<T> : IMatchAn<T>
  {
    IList<T> items;

    public EqualToAny(params T[] values)
    {
      this.items = new List<T>(values);
    }

    public bool matches(T item)
    {
      return items.Contains(item);
    }
  }
}