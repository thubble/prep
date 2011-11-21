namespace prep.utility
{
  public static class CriteriaExtensions
  {
    public static IMatchAn<T> or<T>(this IMatchAn<T> left, IMatchAn<T> right)
    {
      return new OrMatch<T>(left, right);
    }
  }
}