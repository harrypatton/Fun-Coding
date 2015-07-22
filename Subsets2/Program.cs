using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsets2 {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();
            var result = s.SubsetsWithDup(new int[] { 1, 1 });
        }
    }

    public class Solution {
        public IList<IList<int>> SubsetsWithDup(int[] nums) {
            List<IList<int>> result = new List<IList<int>>();
            result.Add(new List<int>());

            if (nums == null || nums.Length == 0) {
                return result;
            }

            Array.Sort(nums);

            int dupeCount = 0;

            for(int i = 0; i < nums.Length; i ++) {
                bool isNormalScenario = i == 0 || nums[i] != nums[i - 1];
                dupeCount = isNormalScenario ? 0 : dupeCount + 1;

                // save the count before updating result collection.
                int count = result.Count;

                for (int j = 0; j < count; j ++) {
                    int numberCount = result[j].Count;
                    bool isCandidate = isNormalScenario || (numberCount > 0 && numberCount >= dupeCount && result[j][numberCount - dupeCount] == nums[i]);

                    if (isCandidate) {
                        IList<int> cloneList = new List<int>(result[j]);
                        cloneList.Add(nums[i]);
                        result.Add(cloneList);
                    }                    
                }
            }

            return result;
        }
    }
}
