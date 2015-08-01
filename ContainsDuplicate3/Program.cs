using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainsDuplicate3 {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
            if (nums == null || nums.Length < 2) {
                return false;
            }

            for(int i = 0; i < nums.Length - 1; i++) {
                for (int j = i+1; j <= i + k; j++) {
                    if (j < nums.Length && Math.Abs((long)nums[i] - (long)nums[j]) <= (long)t) {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
