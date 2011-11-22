using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.utility.searching;

namespace prep.utility.sort
{
    public class RankComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
    {
        protected PropertyAccessor<ItemToSort, PropertyType> accessor;
        protected PropertyType[] rankings;

        public RankComparer(PropertyAccessor<ItemToSort, PropertyType> accessor, params PropertyType[] rankings)
        {
            this.accessor = accessor;
            this.rankings = rankings;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            if (FindRankOf(accessor(x)) == FindRankOf(accessor(y)))
                return 0;
            if (FindRankOf(accessor(x)) > FindRankOf(accessor(y)))
                return 1;

            return -1;
        }

        private int FindRankOf(PropertyType itemToFindRank)
        {
            var listOfRankings = new List<PropertyType>(rankings);
            return listOfRankings.IndexOf(itemToFindRank);
        }
    }
}
