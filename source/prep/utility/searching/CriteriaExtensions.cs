namespace prep.utility.searching
{
  public static class CriteriaExtensions
  {
    public static IMatchAn<T> not<T>(this IMatchAn<T> to_negate)
    {
      return new NegatingMatch<T>(to_negate);
    }
    public static IMatchAn<T> or<T>(this IMatchAn<T> left, IMatchAn<T> right)
    {
      return new OrMatch<T>(left, right);
    }

  }
}