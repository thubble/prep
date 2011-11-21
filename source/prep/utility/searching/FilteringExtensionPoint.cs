namespace prep.utility.searching
{
  public class FilteringExtensionPoint<ItemToFilter,PropertyType> : IEnableFiltering<ItemToFilter, PropertyType>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public IEnableFiltering<ItemToFilter,PropertyType> not
    {
      get
      {
        return new NegatingExtensionPoint<ItemToFilter, PropertyType>(this);
      }
    }

    public FilteringExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFilter> create_matcher_for(IMatchAn<PropertyType> criteria)
    {
      return new PropertyMatch<ItemToFilter, PropertyType>(accessor, criteria);
    }
  }
}