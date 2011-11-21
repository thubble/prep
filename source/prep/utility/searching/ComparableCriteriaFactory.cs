using System;
using prep.utility.ranges;

namespace prep.utility.searching
{
  public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : ICreateMatchers<ItemToFilter, PropertyType>
    where PropertyType : IComparable<PropertyType>
  {
    public IMatchAn<ItemToFilter> equal_to(PropertyType value)
    {
      return factory.equal_to(value);
    }

    public IMatchAn<ItemToFilter> create_using(IMatchAn<PropertyType> criteria)
    {
      return factory.create_using(criteria);
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

    public ComparableCriteriaFactory(ICreateMatchers<ItemToFilter, PropertyType> factory)
    {
      this.factory = factory;
    }

    public IMatchAn<ItemToFilter> greater_than(PropertyType value)
    {
      return create_using(new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value)));
    }

    public IMatchAn<ItemToFilter> between(PropertyType start, PropertyType end)
    {
      return create_using(new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));
    }
  }
}