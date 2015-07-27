using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleNumber {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public int SingleNumber(int[] nums) {
            if(nums == null || nums.Length % 2 == 0) {
                throw new ArgumentException();
            }

            int total = nums[0];

            for(int i = 1; i < nums.Length; i++) {
                total = total ^ nums[i];
            }

            return total;
        }
    }
}
