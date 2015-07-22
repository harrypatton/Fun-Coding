using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {

        public IList<IList<int>> Combine(int n, int k) {

            if (n < k) {
                throw new ArgumentException("expect n >= k");
            }

            List<IList<int>> result = new List<IList<int>>();

            if (k == 1) {
                for (int i = 1; i <= n; i++) {
                    List<int> combination = new List<int>();
                    combination.Add(i);
                    result.Add(combination);
                }
            }
            else if (n == k) {
                List<int> combination = new List<int>();
                for (int i = 1; i <= n; i++) {                    
                    combination.Add(i);                    
                }
                result.Add(combination);
            }
            else {
                var result1 = Combine(n - 1, k - 1);
                var result2 = Combine(n - 1, k);

                foreach(var combination in result1) {
                    combination.Add(n);
                }

                result.AddRange(result1);
                result.AddRange(result2);
            }

            return result;
        }
    }
}
