using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainsDuplicate2 {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public bool ContainsNearbyDuplicate(int[] nums, int k) {

            if (nums == null || nums.Length < 2) {
                return false;
            }

            Dictionary<int, int> cache = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++) {
                if (cache.ContainsKey(nums[i])) {
                    if (i - cache[nums[i]] <= k) {
                        return true;
                    }
                    else {
                        // update with new one
                        cache[nums[i]] = i;
                    }
                }
                else {
                    cache.Add(nums[i], i);
                }
            }

            return false;
        }
    }
}
