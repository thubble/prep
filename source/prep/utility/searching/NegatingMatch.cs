namespace prep.utility.searching
{
    public class NegatingMatch<ItemToMatch> : IMatchAn<ItemToMatch>
    {
        IMatchAn<ItemToMatch> original;

        public NegatingMatch(IMatchAn<ItemToMatch> original)
        {
            this.original = original;
        }

        public bool matches(ItemToMatch item)
        {
            return !original.matches(item);
        }
    }
}