using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumOfBST {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();
            var result = s.NumTrees(3);
        }
    }

    public class Solution {
        public int NumTrees(int n) {

            Dictionary<int, int> cache = new Dictionary<int, int>();
            return NumTrees(n, cache);
        }

        public int NumTrees(int n, Dictionary<int, int> cache) {

            if (cache.ContainsKey(n)) {
                return cache[n];
            }

            int result = 0;

            switch(n) {
                case 0:
                    result = 0;
                    break;
                case 1:
                    result = 1;
                    break;
                default:
                    // each number could be root.
                    for(int i = 0; i < n; i ++) {
                        int leftCount = i;
                        int rightCount = n - 1 - i;

                        int leftNumTress = (leftCount <= 0) ? 1 : NumTrees(leftCount, cache);
                        int rightNumTrees = (rightCount <= 0) ? 1 : NumTrees(rightCount, cache);

                        result += leftNumTress * rightNumTrees;
                    }
                    break;
            }

            // add to cache
            cache.Add(n, result);

            return result;
        }
    }
}
