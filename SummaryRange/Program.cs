using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryRange {
    class Program {
        static void Main(string[] args) {
            var ranges = (new Solution()).SummaryRanges(new int[] { 0, 1, 2, 4, 5, 7 });
        }
    }

    public class Solution {
        public IList<string> SummaryRanges(int[] nums) {
            List<string> ranges = new List<string>();

            if (nums== null || nums.Length == 0) {
                return ranges;
            }

            int start = nums[0];
            int expectedNumber = start + 1;

            for(int i = 1; i < nums.Length; i++) {
                if (nums[i] == expectedNumber) {
                    expectedNumber++;
                }
                else {
                    ranges.Add(GetResult(start, expectedNumber - 1));
                    start = nums[i];
                    expectedNumber = start + 1;
                }
            }

            ranges.Add(GetResult(start, expectedNumber - 1));

            return ranges;
        }

        private string GetResult(int start, int end) {
            return start == end ? start.ToString() : string.Format("{0}->{1}", start, end);
        }
    }
}
