using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortColors {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();
            int[] colors = new int[] { 0, 1 };
            s.SortColors(colors);
        }
    }

    public class Solution {
        public void SortColors(int[] nums) {
            if (nums == null || nums.Length < 2) {
                return;
            }

            int low = 0;
            int high = nums.Length - 1;

            for(int i = 0; i < nums.Length; i++) {

                // if current value is 2, we need to move to the end.
                while(nums[i] == 2 && i < high) {
                    Swap(nums, i, high--);
                }

                // if current value is 0, we need to move to the front
                while(nums[i] == 0 && i > low) {
                    Swap(nums, i, low++);
                }
            }
        }

        public void Swap(int[] numbers, int index1, int index2) {
            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;
        }
    }
}
