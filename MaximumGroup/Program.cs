using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumGroup {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).MaximumGap(new int[] { 1, 2, 2, 2, 2, 4 });
        }
    }

    public class Solution {

        public class Bucket {
            public int max;
            public int min;

            public Bucket(int maxVal, int minVal) {
                max = maxVal;
                min = minVal;
            }
        }

        public int MaximumGap(int[] nums) {

            // check condition. return 0 per requirement.
            if (nums == null || nums.Length < 2) {
                return 0;
            }

            int max = nums[0];
            int min = nums[0];

            // from the 2nd element.
            for (int i = 1; i < nums.Length; i++) {
                max = Math.Max(max, nums[i]);
                min = Math.Min(min, nums[i]);
            }

            int bucketSize = 0;

            if (max == min) {
                return 0;
            }
            else {
                bucketSize = (max - min) / (nums.Length - 1);
            }

            // special handling
            if (bucketSize == 0) {
                bucketSize = 1;
            }

            // we're going to create n buckets. each bucket include numbers [x, x + k). left side is inclusive and right is exclusive.
            int bucketCount = (max - min) / bucketSize + 1;

            Bucket[] buckets = new Bucket[bucketCount];

            // bucket elements
            for(int i = 0; i < nums.Length; i++) {
                int index = (nums[i] - min) / bucketSize;
                
                if (buckets[index] == null) {
                    buckets[index] = new Bucket(nums[i], nums[i]);
                }
                else {
                    buckets[index].min = Math.Min(nums[i], buckets[index].min);
                    buckets[index].max = Math.Max(nums[i], buckets[index].max);
                }
            }

            int maxGap = 0;
            Bucket previousBucket = null;

            // scan all buckets. please note that bucket could be empty.
            for(int i = 0; i < buckets.Length; i++) {
                if (buckets[i] != null) {
                    if (previousBucket == null) {
                        previousBucket = buckets[i];
                    }
                    else {
                        maxGap = Math.Max(maxGap, buckets[i].min - previousBucket.max);
                        previousBucket = buckets[i];
                    }
                }
            }

            return maxGap;
        }
    }
}
