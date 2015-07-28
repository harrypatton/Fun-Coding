using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumProductSubarray {
    class Program {
        static void Main(string[] args) {
            //int[] nums = { 2, 3, -2, 4 };
            int[] nums = { -2, 3, -4 };
            var result = (new Solution()).MaxProduct(nums);
        }
    }

    public class Solution {
        public int MaxProduct(int[] nums) {
            if (nums == null || nums.Length == 0) {
                throw new ArgumentException();
            }

            int max = nums[0];
            int tailingMax = max;
            int tailingMin = max;
            
            for (int i = 1; i < nums.Length; i++) {
                int newProductMax = tailingMax * nums[i];
                int newProductMin = tailingMin * nums[i];

                tailingMax = Math.Max(nums[i], Math.Max(newProductMax, newProductMin));
                tailingMin = Math.Min(nums[i], Math.Min(newProductMax, newProductMin));

                if (tailingMax > max) {
                    max = tailingMax;
                }
            }

            return max;
        }
    }
}
