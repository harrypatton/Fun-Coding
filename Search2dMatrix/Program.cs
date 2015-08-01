using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search2dMatrix {
    class Program {
        static void Main(string[] args) {
            double total = 0;
            double result = 0.75;

            for(int i = 0; i < 100; i++) {
                total += result;
                result *= 0.75;
            }
        }
    }

    public class Solution {
        public bool SearchMatrix(int[,] matrix, int target) {
            if (matrix == null || matrix.Length == 0) {
                return false;
            }

            return SearchMatrix(matrix, target, 0, matrix.GetLength(1) - 1, 0, matrix.GetLength(0) - 1);
        }

        public bool SearchMatrix(int[,] matrix, int target, int left, int right, int top, int bottom) {
            if (left > right || top > bottom) {
                return false;
            }

            // use binary search
            if (left == right) {
                
                while (top <= bottom) {

                    int middle = (top + bottom) / 2;

                    if (matrix[middle, left] == target) {
                        return true;
                    }
                    else if (matrix[middle, left] > target) {
                        bottom = middle - 1;
                    }
                    else {
                        top = middle + 1;
                    }
                }

                return false;
            }

            // use binary search
            if (top == bottom) {
                
                while (left <= right) {

                    int middle = (left + right) / 2;

                    if (matrix[top, middle] == target) {
                        return true;
                    }
                    else if (matrix[top, middle] > target) {
                        right = middle - 1;
                    }
                    else {
                        left = middle + 1;
                    }
                }

                return false;
            }

            int middleX = (left + right) / 2;
            int middleY = (top + bottom) / 2;

            if (matrix[middleY, middleX] == target) {
                return true;
            }
            else if (matrix[middleY, middleX] < target) {
                return SearchMatrix(matrix, target, left, right, middleY + 1, bottom) || SearchMatrix(matrix, target, middleX + 1, right, top, middleY);
            }
            else {
                return SearchMatrix(matrix, target, left, right, top, middleY - 1) || SearchMatrix(matrix, target, left, middleX - 1, middleY, bottom);
            }
        }
    }
}
