namespace prep.utility.searching
{
  public interface ICreateMatchers<ItemToFilter, PropertyType>
  {
    IMatchAn<ItemToFilter> create_using(IMatchAn<PropertyType> criteria);
    IMatchAn<ItemToFilter> equal_to(PropertyType value);
    IMatchAn<ItemToFilter> equal_to_any(params PropertyType[] potential_values);
    IMatchAn<ItemToFilter> not_equal_to(PropertyType value);
  }
}