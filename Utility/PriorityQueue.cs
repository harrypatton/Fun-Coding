using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class PriorityQueue<TKey, TValue> : SortedList<TKey, TValue> where TKey : IComparable
    {
        public PriorityQueue(bool isAscending) : base(new DuplicateKeyComparer<TKey>(isAscending))
        {            
        }
    }

    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        private bool _isAscending;

        public DuplicateKeyComparer(bool isAscending)
        {
            _isAscending = isAscending;
        }

        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);
            
            if (result == 0)
                result = 1;   // Handle equality as being greater

            return _isAscending ? result : -result;
        }
    }

}
