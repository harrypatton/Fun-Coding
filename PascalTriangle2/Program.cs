using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle2 {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();
            var result = s.GetRow(3);
        }
    }

    public class Solution {
        public IList<int> GetRow(int rowIndex) {
            int rowCount = rowIndex + 1;
            int[] result = new int[rowCount];

            if (rowCount <= 0) {
                return new List<int>(result);
            }

            switch (rowCount) {
                case 1:
                    result[0] = 1;
                    break;
                default:
                    result[rowCount - 1] = 1;
                    result[rowCount - 2] = 1;

                    for (int level = 3; level <= rowCount; level++) {
                        int left = rowCount - level + 1;
                        int right = rowCount - 1;

                        for(int i = left; i < right; i ++) {
                            result[i] = result[i] + result[i + 1];
                        }

                        result[left - 1] = 1;
                    }
                    break;
            }

            return new List<int>(result);
        }
    }
}
