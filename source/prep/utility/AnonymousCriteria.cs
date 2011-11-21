namespace prep.utility
{
  public class AnonymousCriteria<T> : IMatchAn<T>
  {
    Condition<T> condition;

    public AnonymousCriteria(Condition<T> condition)
    {
      this.condition = condition;
    }

    public bool matches(T item)
    {
      return condition(item);
    }
  }
}