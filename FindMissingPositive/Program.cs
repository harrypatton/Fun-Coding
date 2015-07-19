using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMissingPositive
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var result = s.FirstMissingPositive(new int[] { 2, 2 });
        }
    }

    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 1;
            }

            int index = 0;

            while(index < nums.Length)
            {
                // Move under the following conditions
                // - current value is in right position
                // - there's no position in this array for this element
                // - current position has right position
                if (nums[index] <= 0 || nums[index] > nums.Length || nums[index] == index + 1 || nums[nums[index] - 1] == nums[index])
                {
                    index++;
                }
                else // swap and continue to evaluate current position
                {
                    int positiveNum = nums[index];
                    nums[index] = nums[positiveNum - 1];
                    nums[positiveNum - 1] = positiveNum;
                }
            }

            for(index = 0; index < nums.Length; index ++)
            {
                if (index + 1 != nums[index])
                {
                    return index + 1;
                }
            }

            // all numbers exist so return the next greater one.
            return nums.Length + 1;
        }
    }
}
