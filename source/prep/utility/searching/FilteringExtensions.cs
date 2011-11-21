using System;
using prep.utility.ranges;

namespace prep.utility.searching
{
  public static class FilteringExtensions
  {
    public static IMatchAn<ItemToFilter> equal_to<ItemToFilter, PropertyType>(
      this IEnableFiltering<ItemToFilter, PropertyType> extension_point, PropertyType value)
    {
      return equal_to_any(extension_point, value);
    }

    public static IMatchAn<ItemToFilter> equal_to_any<ItemToFilter, PropertyType>(
      this IEnableFiltering<ItemToFilter, PropertyType> extension_point, params PropertyType[] potential_values)
    {
      return create_using(extension_point, new EqualToAny<PropertyType>(potential_values));
    }

    public static IMatchAn<ItemToFilter> create_using<ItemToFilter, PropertyType>(
      this IEnableFiltering<ItemToFilter, PropertyType> extension_point, IMatchAn<PropertyType> criteria)
    {
      return extension_point.create_matcher_for(criteria);
    }

    public static IMatchAn<ItemToFilter> not_equal_to<ItemToFilter, PropertyType>(
      this IEnableFiltering<ItemToFilter, PropertyType> extension_point, PropertyType value)
    {
      return equal_to(extension_point, value).not();
    }

    public static IMatchAn<ItemToFilter> greater_than<ItemToFilter, PropertyType>(
      this IEnableFiltering<ItemToFilter, PropertyType> extension_point, PropertyType value)
      where PropertyType : IComparable<PropertyType>
    {
      return create_using(extension_point,
                          new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value)));
    }

    public static IMatchAn<ItemToFilter> between<ItemToFilter, PropertyType>(
      this IEnableFiltering<ItemToFilter, PropertyType> extension_point, PropertyType start, PropertyType end)
      where PropertyType : IComparable<PropertyType>
    {
      return create_using(extension_point, new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));
    }
  }
}