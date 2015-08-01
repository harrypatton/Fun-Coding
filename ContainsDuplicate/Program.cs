using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainsDuplicate {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public bool ContainsDuplicate(int[] nums) {
            if (nums == null || nums.Length < 2) {
                return false;
            }

            HashSet<int> values = new HashSet<int>();

            foreach(var num in nums) {
                if (values.Contains(num)) {
                    return true;
                }
                else {
                    values.Add(num);
                }
            }

            return false;
        }
    }
}
