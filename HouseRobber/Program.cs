using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRobber {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).Rob(new int[] { 1, 2, 3, 4, 5, 6 });
        }
    }

    public class Solution {
        public int Rob(int[] nums) {
            if (nums == null || nums.Length <= 0) {
                return 0;
            }

            if (nums.Length == 1) {
                return nums[0];
            }

            int max = Math.Max(nums[0], nums[1]);
            int max_2_elements_before = nums[0];

            for(int i = 2; i < nums.Length; i++) {
                int temp = max;
                max = Math.Max(max, max_2_elements_before + nums[i]);
                max_2_elements_before = temp;
            }

            return max;
        }
    }
}
