namespace prep.utility.searching
{
  public class FilteringExtensionPoint<ItemToFilter,PropertyType>
  {
    public PropertyAccessor<ItemToFilter, PropertyType> accessor { get; set; }

    public FilteringExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }
  }
}