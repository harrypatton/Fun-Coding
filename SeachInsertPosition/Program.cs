using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeachInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int left = 0;
            int right = nums.Length - 1;

            while(left <= right)
            {
                int middle = (left + right) / 2;

                if (nums[middle] == target)
                {
                    return middle;
                }
                else if (nums[middle] > target)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return left;
        }
    }
}
