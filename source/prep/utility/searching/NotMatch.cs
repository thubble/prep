namespace prep.utility.searching
{
    public class NotMatch<ItemToMatch> : IMatchAn<ItemToMatch>
    {
        IMatchAn<ItemToMatch> underlying_match;

        public NotMatch(IMatchAn<ItemToMatch> underlyingMatch)
        {
            underlying_match = underlyingMatch;
        }

        public bool matches(ItemToMatch item)
        {
            return !underlying_match.matches(item);
        }
    }
}