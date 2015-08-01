using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRobber2 {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).Rob(new int[] { 1, 1, 1, 1 });
        }
    }

    public class Solution {
        public int Rob(int[] nums) {
            if (nums == null || nums.Length == 0) {
                return 0;
            }

            if (nums.Length == 1) {
                return nums[0];
            }

            int maxExcludingFirst = nums[1];
            int maxIncludingFirst = nums[0] > nums[1] ? nums[0] : nums[1];
            int preMaxExcludingFirst = 0;
            int preMaxIncludingFirst = nums[0];

            for (int i = 2; i < nums.Length; i++) {
                int tempMaxExcludingFirst = maxExcludingFirst;
                int tempMaxIncludingFirst = maxIncludingFirst;

                maxExcludingFirst = Math.Max(maxExcludingFirst, preMaxExcludingFirst + nums[i]);

                if (i != nums.Length - 1) {
                    maxIncludingFirst = Math.Max(maxIncludingFirst, preMaxIncludingFirst + nums[i]);
                }                

                preMaxExcludingFirst = tempMaxExcludingFirst;
                preMaxIncludingFirst = tempMaxIncludingFirst;
            }

            return Math.Max(maxExcludingFirst, maxIncludingFirst);
        }
    }
}
