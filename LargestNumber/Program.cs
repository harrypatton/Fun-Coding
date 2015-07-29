using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestNumber {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).LargestNumber(new int[] { 34, 31, 301 });
        }
    }

    public class Solution {
        public string LargestNumber(int[] nums) {
            if (nums == null || nums.Length == 0) {
                return string.Empty;
            }

            if (nums.Length == 1) {
                return nums[0].ToString();
            }

            if (nums.All(item => item == 0)) {
                return "0";
            }

            Array.Sort<int>(nums, new MyComparer());

            string result = string.Empty;

            foreach(var n in nums) {
                result += n.ToString();
            }

            return result;
        }

        public class MyComparer : IComparer<int> {
            public int Compare(int x, int y) {
                string result1 = x.ToString() + y.ToString();
                string result2 = y.ToString() + x.ToString();

                // use descending order.
                return 0 - string.Compare(result1, result2);
            }
        }
    }
}
