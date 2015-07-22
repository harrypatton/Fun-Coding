using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchMatrix {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {

        public bool SearchMatrix(int[,] matrix, int target) {
            if (matrix == null || matrix.Length == 0) {
                return false;
            }

            int left = 0;
            int right = matrix.Length - 1;

            while(left <= right) {
                int middle = (left + right) / 2;

                // transfer to matrix location
                int x = middle / matrix.GetLength(1);
                int y = middle % matrix.GetLength(1);

                if (matrix[x, y] == target) {
                    return true;
                }
                else if (matrix[x,y] > target) {
                    right = middle - 1;
                }
                else {
                    left = middle + 1;
                }
            }

            return false;
        }
    }
}
