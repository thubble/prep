using System.Collections.Generic;

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
  }

	public static class Where<T>
	{
		public static AnonymousHasAMatcher<T, TResult> has_a<TResult>(System.Func<T, TResult> selector)
		{
			return new AnonymousHasAMatcher<T, TResult>(selector);
		}
	}

	public class AnonymousHasAMatcher<T, TResult>
	{
		private System.Func<T, TResult> _selector;
		public AnonymousHasAMatcher(System.Func<T, TResult> selector)
		{
			_selector = selector;
		}

		public AnonymousCriteria<T> equal_to(TResult matchValue)
		{
			Condition<T> condition = (T value) =>
										{
											return object.Equals(_selector(value), matchValue);
										};

			return new AnonymousCriteria<T>(condition);
		}
	}
}