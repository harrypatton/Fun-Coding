using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPeakElement {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public int FindPeakElement(int[] nums) {
            if (nums == null || nums.Length == 0) {
                throw new ArgumentNullException();
            }

            if (nums.Length == 1) {
                return 0;
            }

            int left = 0;
            int right = nums.Length - 1;

            while(left <= right) {

                if (left == right) {
                    return left;
                }
                else if (left + 1 == right) {
                    return nums[left] > nums[right] ? left : right;
                }
                else {
                    int middle = (left + right) / 2;

                    if (nums[middle - 1] < nums[middle] && nums[middle] > nums[middle + 1]) {
                        return middle;
                    }
                    else if (nums[middle - 1] < nums[middle] && nums[middle] < nums[middle + 1]) {
                        left = middle + 1;
                    }
                    else {
                        right = middle - 1;
                    }
                }                
            }

            return -1;
        }
    }
}
