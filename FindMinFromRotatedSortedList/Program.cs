using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMinFromRotatedSortedList {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).FindMin(new int[] { 3, 4, 0, 1, 2 });
        }
    }

    public class Solution {
        public int FindMin(int[] nums) {
            if (nums == null || nums.Length == 0) {
                return 0;
            }

            if (nums.Length == 1) {
                return nums[0];
            }

            int left = 0;
            int right = nums.Length - 1;

            if (nums[left] < nums[right]) {
                return nums[left];
            }

            while(left < right) {
                int middle = (left + right) / 2;

                if (nums[middle] > nums[right]) {
                    left = middle + 1;
                }
                else {
                    right = middle;
                }
            }

            return nums[left];
        }
    }
}
