using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3sum
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
            {
                return result;
            }
            
            // sort first
            nums = nums.OrderBy(item => item).ToArray<int>();
            int prevNum = 0;

            for(int i = 0; i < nums.Length - 2; i ++)
            {
                // skp for the same integer to avoid duplicate results.
                if (i != 0 && prevNum == nums[i])
                {
                    continue;
                }

                prevNum = nums[i];

                // bi-directional find out the sum
                int first = i + 1;
                int last = nums.Length - 1;

                while(first < last)
                {
                    int sum = nums[first] + nums[last] + nums[i];

                    // found it. add to result.
                    if (sum == 0)
                    {
                        result.Add(new List<int>(new int[] { nums[i], nums[first], nums[last] }));
                    }
                    
                    // when sum is 0, we need to move both first and last pointers.

                    if (sum >= 0)
                    {
                        // move last to a different one
                        while( last > first && nums[last-1] == nums[last])
                        {
                            last--;
                        }

                        last--;
                    }

                    if (sum <= 0)
                    {
                        // move first to a different one
                        while (last > first && nums[first] == nums[first + 1])
                        {
                            first++;
                        }

                        first++;
                    }
                }
            }

            return result;
        }
    }
}
