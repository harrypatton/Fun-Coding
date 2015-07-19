using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            List<Interval> list = new List<Interval>();            
            var result = s.Insert(list, new Interval(5, 7));
        }
    }

    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class IntervalComparer : IComparer<Interval>
    {
        public int Compare(Interval x, Interval y)
        {
            if (x.start < y.start)
            {
                return -1;
            }
            else if (x.start > y.start)
            {
                return 1;
            }
            else
            {
                return (x.end < y.end) ? -1 : 1;
            }
        }
    }

    public class Solution
    {
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            if (intervals == null)
            {
                throw new ArgumentNullException();
            }
            
            int removeStartIndex = 0;
            int removeEndIndex = -1;
            int positionToInsert = 0;
            int position = 0;

            bool leftEdgeFound = BinarySearch(intervals, newInterval.start, out position);

            // we're going to know the start index of intervals to remove and the index to insert new interval.
            removeStartIndex = position;
            positionToInsert = position;

            if (leftEdgeFound) // merge existing one.
            {
                newInterval.start = intervals[position].start;
            }

            bool rightEdgeFound = BinarySearch(intervals, newInterval.end, out position);

            if (rightEdgeFound)
            {
                newInterval.end = intervals[position].end;
                removeEndIndex = position;
            }
            else
            {
                // we need to remove previous one.
                removeEndIndex = position - 1;
            }

            // copy a new one; because the input one might be read-only collection.
            List<Interval> newIntervalList = new List<Interval>(intervals);
            
            for (int i = 0; i < removeEndIndex - removeStartIndex + 1; i++)
            {
                newIntervalList.RemoveAt(removeStartIndex);
            }

            newIntervalList.Insert(positionToInsert, newInterval);

            return newIntervalList;
        }

        public bool BinarySearch(IList<Interval> intervals, int target, out int position)
        {
            if (intervals == null)
            {
                throw new ArgumentNullException();
            }

            int left = 0;
            int right = intervals.Count - 1;
            bool found = false;
            position = -1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (target >= intervals[middle].start && target <= intervals[middle].end)
                {
                    position = middle;
                    found = true;
                    break;
                }
                else if (target > intervals[middle].end)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            if (left > right)
            {
                position = left;
            }

            return found;
        }
    }
}
