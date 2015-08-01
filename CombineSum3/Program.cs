using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombineSum3 {
    class Program {
        static void Main(string[] args) {
            //var result = (new Solution()).FindBaseList(3, 15, 1);
            var result = (new Solution()).CombinationSum3(3, 15);
        }
    }

    public class Solution {
        public IList<IList<int>> CombinationSum3(int k, int n) {
            return FindList(k, n, 1);
        }

        public IList<IList<int>> FindList(int k, int n, int baseValue) {

            List<IList<int>> list = new List<IList<int>>();

            if (n < 1) {
                return list;
            }
            
            if (k == 1) {
                if (n >= baseValue && n <= 9) {
                    List<int> result = new List<int>(new int[] { n });
                    list.Add(result);
                    return list;
                }
                else {
                    return list;
                }
            }

            for(int i = baseValue; i <= 10 - k; i++) {
                var subResults = FindList(k - 1, n - i, i + 1);

                if (subResults.Any()) {

                    foreach(var subResult in subResults) {
                        List<int> result = new List<int>(new int[] { i });
                        result.AddRange(subResult);
                        list.Add(result);
                    }                    
                }
            }

            return list;
        }        
    }
}
