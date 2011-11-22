using System.Collections.Generic;

namespace prep.utility.sort
{
  public class RankComparer<PropertyType> : IComparer<PropertyType>
  {
    IList<PropertyType> rankings;

    public RankComparer(params PropertyType[] rankings)
    {
      this.rankings = new List<PropertyType>(rankings);
    }

    public int Compare(PropertyType x, PropertyType y)
    {
      return rankings.IndexOf(x).CompareTo(rankings.IndexOf(y));
    }
  }
}