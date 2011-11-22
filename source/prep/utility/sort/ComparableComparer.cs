using System;
using System.Collections.Generic;

namespace prep.utility.sort
{
  public class ComparableComparer<PropertyType> : IComparer<PropertyType>
    where PropertyType : IComparable<PropertyType>
  {
    public int Compare(PropertyType x, PropertyType y)
    {
      return x.CompareTo(y);
    }
  }
}