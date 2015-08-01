using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainsDuplicate3 {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).ContainsNearbyAlmostDuplicate(new int[] { -1, -1 }, 1, 0);
        }
    }

    public class Solution {
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
            if (nums == null || nums.Length < 2 || k < 1 || t < 0) {
                return false;
            }

            Dictionary<long, long> buckets = new Dictionary<long, long>();

            for(int i = 0; i < nums.Length; i++) {

                long bucketId;

                // we only keep k elements at most
                if (i > k) {
                    int index = i - k - 1;
                    bucketId = ((long)nums[index] - int.MinValue) / (t + 1);

                    if (buckets.ContainsKey(bucketId)) {
                        buckets.Remove(bucketId);
                    }
                }

                bucketId = ((long)nums[i] - int.MinValue) / (t + 1);

                if (buckets.ContainsKey(bucketId) 
                    || (buckets.ContainsKey(bucketId - 1) && Math.Abs(buckets[bucketId - 1] - nums[i]) <= t )
                    || (buckets.ContainsKey(bucketId + 1) && Math.Abs(buckets[bucketId + 1] - nums[i]) <= t)) {
                    return true;
                }

                buckets.Add(bucketId, nums[i]);
            }

            return false;
        }
    }
}
