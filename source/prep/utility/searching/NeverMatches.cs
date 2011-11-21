namespace prep.utility.searching
{
  public class NeverMatches<T> : IMatchAn<T>
  {
    public bool matches(T item)
    {
      return false;
    }
  }
}