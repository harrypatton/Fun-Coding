using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _189RotateArray {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public void Rotate(int[] nums, int k) {
            if (nums == null || nums.Length <= 1 || k % nums.Length == 0) {
                return;
            }

            Reverse(nums, 0, nums.Length - 1);

            // adjust the step number.
            k = k % nums.Length;

            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        public void Reverse(int[] nums, int left, int right) {
            if (left >= right) {
                return;
            }

            int middle = (left + right - 1) / 2;

            for(int i = left; i <= middle; i++) {
                // swap two elements.
                int temp = nums[i];
                nums[i] = nums[right + left - i];
                nums[right + left - i] = temp;
            }
        }
    }    
}
