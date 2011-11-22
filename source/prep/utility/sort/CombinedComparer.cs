using System.Collections.Generic;

namespace prep.utility.sort
{
  public class CombinedComparer<T> : IComparer<T>
  {
    IComparer<T> first;
    IComparer<T> second;

    public CombinedComparer(IComparer<T> first, IComparer<T> second)
    {
      this.first = first;
      this.second = second;
    }

    public int Compare(T x, T y)
    {
      var result = first.Compare(x, y);
      return result == 0 ? second.Compare(x, y) : result;
    }
  }
}