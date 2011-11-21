namespace prep.utility.searching
{
  public interface ICreateMatchers<ItemToFilter, PropertyType>
  {
	  IMatchAn<ItemToFilter> matches_condition(Condition<PropertyType> condition);
	IMatchAn<ItemToFilter> equal_to(PropertyType value);
    IMatchAn<ItemToFilter> equal_to_any(params PropertyType[] potential_values);
    IMatchAn<ItemToFilter> not_equal_to(PropertyType value);
  }
}