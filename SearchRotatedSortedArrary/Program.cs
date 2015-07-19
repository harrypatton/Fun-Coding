using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRotatedSortedArrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int result = s.Search(new int[] { 4, 5, 6, 1, 2, 3 });

            int.MaxValue
        }
    }

    public class Solution
    {
        public int Search(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }            

            int left = 0;
            int right = nums.Length - 1;

            if (nums[left] < nums[right])
            {
                return left;
            }

            while(left <= right)
            {
                int middle = (left + right) / 2;

                // found it. the pivot is the only element which is smaller than previous one.
                if (middle == 0 || nums[middle] < nums[middle - 1])
                {
                    return middle;
                }

                if (nums[middle] >= nums[left])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }   
    }
}
