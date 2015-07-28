using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMinFromRotatedSortedList2 {
    class Program {
        static void Main(string[] args) {
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

                if (nums[middle] > nums[right]) { // minimum is on the right side.
                    left = middle + 1;
                }
                else if (nums[middle] < nums[right]) { // minimum is on the left side.
                    right = middle;
                }
                else { // this one is tricky when middle == right. move right one step (because middle could be the minimum at least)
                    right--;
                }
            }

            return nums[left];
        }
    }
}
