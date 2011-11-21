using System;

namespace prep.utility.searching
{
  public static class DateFilteringExtensions
  {
    public static IMatchAn<ItemToFilter> greater_than<ItemToFilter>(
      this FilteringExtensionPoint<ItemToFilter, DateTime> extension_point, int year)
    {
      throw new NotImplementedException();
    }
  }
}