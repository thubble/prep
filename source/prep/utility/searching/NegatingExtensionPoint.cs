namespace prep.utility.searching
{
  public class NegatingExtensionPoint<ItemToFilter, PropertyType> : IEnableFiltering<ItemToFilter, PropertyType>
  {
    IEnableFiltering<ItemToFilter, PropertyType> original;

    public NegatingExtensionPoint(IEnableFiltering<ItemToFilter, PropertyType> original)
    {
      this.original = original;
    }

    public IMatchAn<ItemToFilter> create_matcher_for(IMatchAn<PropertyType> criteria)
    {
      return original.create_matcher_for(criteria).not();
    }
  }
}