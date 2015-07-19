using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.SearchRange(new int[] { 2, 2, }, 2);
        }
    }

    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int start = -1;
            int end = -1;

            if (nums == null || nums.Length == 0)
            {
                return new int[] { start, end };
            }

            int left = 0;
            int right = nums.Length - 1;

            // search for the most left
            while(left < right)
            {
                int middle = (left + right) / 2;

                if (nums[middle] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            start = (nums[left] == target) ? left : -1;

            // search for the most right
            // the left one is either the left most target or a different element so no need to reset it.
            right = nums.Length - 1;    
                    
            while (left < right)
            {
                // choose one biase to the right
                int middle = (left + right) / 2 + 1;

                if (nums[middle] > target)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle;
                }
            }

            end = (nums[left] == target) ? left : -1;

            return new int[] { start, end };
        }
    }
}
