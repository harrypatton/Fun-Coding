using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            List<Interval> list = new List<Interval>();
            list.Add(new Interval(1, 3));
            list.Add(new Interval(2, 6));
            list.Add(new Interval(8, 10));
            list.Add(new Interval(15, 18));

            var result = s.Merge(list);

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
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count <= 1)
            {
                return intervals;
            }

            intervals = intervals.OrderBy(item => item, new IntervalComparer()).ToList();            
            List<Interval> result = new List<Interval>();

            Interval baseInterval = intervals[0];

            for(int i = 1; i < intervals.Count; i ++)
            {
                Interval newInterval = intervals[i];

                if (newInterval.start <= baseInterval.end && newInterval.end <= baseInterval.end)
                {
                    // do nothing. already included.
                }
                else if (newInterval.start <= baseInterval.end && newInterval.end > baseInterval.end) // extend current one
                { 
                    baseInterval.end = newInterval.end;
                }
                else // a separate one
                {
                    result.Add(baseInterval);
                    baseInterval = newInterval;
                }
            }

            // don't forget the base interval:)
            result.Add(baseInterval);

            return result;
        }
    }
}
