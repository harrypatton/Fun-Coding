using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombineSum3 {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).CombinationSum3(3, 15);
        }
    }

    public class Solution {
        public IList<IList<int>> CombinationSum3(int k, int n) {
            IList<IList<int>> result = new List<IList<int>>();

            var baseList = FindNextOne(new int[k], 0, n);
            if (baseList != null) {
                result.Add(baseList);
            }
            else {
                return result;
            }

            // start the first to the one before last element.
            for(int i = 0; i < k - 1; i++) {
                int count = result.Count;

                for (int j = 0; j < count; j++) {
                    var list = result[j];

                    while (true) {
                        list = FindNextOne(list.ToArray(), i, n);

                        if (list != null) {
                            result.Add(list);
                        }
                        else {
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public int[] FindNextOne(int[] baseList, int index, int n) {

            // no candidate anymore.
            if (baseList[index] == 9) {
                return null;
            }

            int totalCount = baseList.Length;
            int[] result = new int[totalCount];

            Array.Copy(baseList, result, totalCount);
            result[index]++; // incease one number.
            result[totalCount - 1] = 0;

            for(int i = index + 1; i < totalCount - 1; i++) {
                result[i] = result[i - 1] + 1;
            }

            int lastValue = (n - result.Sum());

            if (lastValue > result[totalCount - 2] && lastValue <= 9) {
                result[totalCount - 1] = lastValue;
                return result.ToArray();
            }
            else {
                return null;
            }
        }
    }
}
