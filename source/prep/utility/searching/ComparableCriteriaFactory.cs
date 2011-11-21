using System;

namespace prep.utility.searching
{
  public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : ICreateMatchers<ItemToFilter, PropertyType>
    where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public IMatchAn<ItemToFilter> equal_to(PropertyType value)
    {
      return factory.equal_to(value);
    }

    public IMatchAn<ItemToFilter> equal_to_any(params PropertyType[] potential_values)
    {
      return factory.equal_to_any(potential_values);
    }

    public IMatchAn<ItemToFilter> not_equal_to(PropertyType value)
    {
      return factory.not_equal_to(value);
    }

    ICreateMatchers<ItemToFilter, PropertyType> factory;

    public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor,
                                     ICreateMatchers<ItemToFilter, PropertyType> factory)
    {
      this.accessor = accessor;
      this.factory = factory;
    }

    public IMatchAn<ItemToFilter> greater_than(PropertyType value)
    {
      return new AnonymousCriteria<ItemToFilter>(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchAn<ItemToFilter> between(PropertyType start, PropertyType end)
    {
      return
        new AnonymousCriteria<ItemToFilter>(x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
    }
  }
}