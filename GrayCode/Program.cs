using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrayCode {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();
            var result = s.GrayCode(10);
            var result2 = s.GrayCode2(10);
        }
    }

    public class Solution {
        
        /// <summary>
        /// 1. Use examples to find the algorithm
        /// 2. Use a list to save the diff on each element.
        ///     a.N = 2, the list is 1, 2, -1
        ///     b.N = 3, the list is 1, 2, -1, 4, 1, -2, -1
        ///     c. When n + 1, the list is, (list of n), power(2, n), (list of n with opposite value and direction)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> GrayCode(int n) {

            List<int> result = new List<int>();

            if (n == 0) {
                result.Add(0);
                return result;
            }

            result.Add(0);
            result.Add(1);
            int middleValue = 1;

            // calculate the diff.
            for(int i = 2; i <= n; i ++) {
                middleValue *= 2;
                result.Add(middleValue);
                
                // double the list but with opposite value in opposite direction. the 0 position is 0 value.
                for(int j = result.Count - 2; j >=1; j--) {
                    result.Add(0 - result[j]);
                }
            }
            
            for(int i = 1; i < result.Count; i ++) {
                result[i] += result[i - 1];
            }

            return result;
        }
    }
}
