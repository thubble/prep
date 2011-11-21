namespace prep.utility.searching
{
  public delegate PropertyType PropertyAccessor<in ItemToFilter, out PropertyType>(ItemToFilter item);
}