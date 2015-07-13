using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3sumclosest
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            int minDiff = -1;
            int result = -1;

            if (nums == null || nums.Length <= 2)
            {
                throw new ArgumentException();
            }

            nums = nums.OrderBy(item => item).ToArray();

            for(int i = 0; i < nums.Length - 2; i ++)
            {
                if (i == 0 || nums[i] != nums[i-1])
                {
                    int first = i + 1;
                    int last = nums.Length - 1;

                    while(first < last)
                    {
                        int sumDiff = nums[i] + nums[first] + nums[last] - target;

                        if (minDiff < 0 || Math.Abs(sumDiff) < minDiff)
                        {
                            minDiff = Math.Abs(sumDiff);
                            result = sumDiff + target;
                        }

                        if (sumDiff == 0)
                        {
                            return result;
                        }

                        if (sumDiff < 0)
                        {
                            first++;
                        }
                        else
                        {
                            last--;
                        }
                    }
                }
            }

            return result;
        }
    }
}
