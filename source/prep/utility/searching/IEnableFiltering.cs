namespace prep.utility.searching
{
  public interface IEnableFiltering<ItemToFilter, PropertyType>
  {
    IMatchAn<ItemToFilter> create_matcher_for(IMatchAn<PropertyType> criteria);
  }
}