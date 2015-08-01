using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parenthese {
    class Program {
        static void Main(string[] args) {
            //var result = (new Solution()).DiffWaysToCompute("2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2+2");
            var result = (new Solution()).DiffWaysToCompute("2+2+2+2+2+2+2+2+2+2+2+2+2+2");
        }
    }

    public class Solution {
        public IList<int> DiffWaysToCompute(string input) {
            Dictionary<string, IList<int>> cache = new Dictionary<string, IList<int>>();
            return DiffWaysToComputeHelper(input, cache);
        }

        public IList<int> DiffWaysToComputeHelper(string input, Dictionary<string, IList<int>> cache) {

            if (cache.ContainsKey(input)) {
                return cache[input];
            }

            IList<int> results = new List<int>();
            char[] operators = new char[] { '+', '-', '*' };

            for (int i = 0; i < input.Length; i++) {
                if (operators.Contains(input[i])) {
                    IList<int> values1 = DiffWaysToComputeHelper(input.Substring(0, i), cache);
                    IList<int> values2 = DiffWaysToComputeHelper(input.Substring(i + 1), cache);

                    foreach (var v1 in values1) {
                        foreach (var v2 in values2) {
                            int result = 0;
                            switch (input[i]) {
                                case '-':
                                    result = v1 - v2;
                                    break;
                                case '+':
                                    result = v1 + v2;
                                    break;
                                case '*':
                                    result = v1 * v2;
                                    break;
                            }

                            results.Add(result);
                        }
                    }
                }
            }

            if (!results.Any()) {
                results.Add(int.Parse(input));
            }

            cache.Add(input, results);

            return results;
        }
    }
}
