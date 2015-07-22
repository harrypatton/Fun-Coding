using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsets {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {

        public IList<IList<int>> Subsets(int[] nums) {

            List<IList<int>> result = new List<IList<int>>();

            if (nums == null || nums.Length == 0) {
                return result;
            }

            Array.Sort(nums);

            // handle base
            // add empty set
            result.Add(new List<int>());

            // add the first element itself.
            List<int> tempList = new List<int>();
            tempList.Add(nums[0]);
            result.Add(tempList); 

            for(int i = 1; i < nums.Length; i ++) {
                int count = result.Count;

                for(int j = 0; j < count; j++) {
                    // clone existing one
                    List<int> newList = new List<int>(result[j]);

                    // add new item
                    newList.Add(nums[i]);

                    // add to result
                    result.Add(newList);
                }
            }

            return result;
        }
    }
}
