namespace prep.utility.searching
{
  public static class Where<ItemToFilter>
  {
    public static FilteringExtensionPoint<ItemToFilter, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      return new FilteringExtensionPoint<ItemToFilter, PropertyType>(accessor);
    }
  }
}