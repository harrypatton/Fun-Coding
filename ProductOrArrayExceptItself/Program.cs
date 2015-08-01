using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrArrayExceptItself {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution().ProductExceptSelf(new int[] { 1, 2, 3, 4 }));
        }
    }

    public class Solution {
        public int[] ProductExceptSelf(int[] nums) {

            if (nums == null) {
                return null;
            }

            if (nums.Length == 1) {
                return new int[] { 1 };
            }

            int[] results = new int[nums.Length];
            results[0] = 1;

            for(int i = 1; i < nums.Length; i++) {
                results[i] = results[i - 1] * nums[i - 1];
            }

            int factor = 1;
            for(int i = nums.Length - 2; i >= 0; i--) {
                factor = factor * nums[i + 1];
                results[i] = results[i] * factor;
            }

            return results;
        }
    }
}
