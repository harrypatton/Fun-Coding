using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSizeSubarraySum {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).MinSubArrayLen(7, new int[] { 2, 3, 1, 2, 4, 3 });
        }
    }

    public class Solution {

        public int MinSubArrayLen(int s, int[] nums) {

            if (nums == null || nums.Length == 0) {
                return 0;
            }

            int minLength = nums[0] >= s ? 1 : 0 ;
            int sum = nums[0];

            for(int i = 1; i < nums.Length; i++) {

                // find current minSum including current item
                if (nums[i] + sum >= s) {
                    int tempSum = 0;

                    for(int j = i; j >=0; j--) {
                        tempSum += nums[j];

                        if (tempSum >= s) { // found candidate
                            int length = i - j + 1;
                            minLength = (minLength == 0) ? length : Math.Min(length, minLength);
                            break;
                        }
                    }
                }

                sum += nums[i];
            }

            return minLength;
        }
    }
}
