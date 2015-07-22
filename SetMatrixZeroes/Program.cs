using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetMatrixZeroes {

    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {

        public void SetZeroes(int[,] matrix) {

            // check condition
            if (matrix == null || matrix.Length == 0) {
                return;
            }

            bool[] isRowZero = new bool[matrix.GetLength(0)];
            bool[] isColumnZero = new bool[matrix.GetLength(1)];

            // find which row/column to set zero
            for(int i = 0; i < matrix.GetLength(0); i ++) {
                for(int j = 0; j < matrix.GetLength(1); j++) {
                    if (matrix[i, j] == 0) {
                        isRowZero[i] = true;
                        isColumnZero[j] = true;
                    }
                }
            }

            // set zero for rows.
            for(int i = 0; i <isRowZero.Length; i ++) {
                if (isRowZero[i]) {
                    for(int j = 0; j < matrix.GetLength(1); j ++) {
                        matrix[i, j] = 0;
                    }
                }
            }

            // set zero for columns.
            for (int j = 0; j < isColumnZero.Length; j++) {
                if (isColumnZero[j]) {
                    for (int i = 0; i < matrix.GetLength(0); i++) {
                        matrix[i, j] = 0;
                    }
                }
            }
        }
    }
}
