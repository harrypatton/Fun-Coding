using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfIslands {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public int NumIslands(char[,] grid) {
            int count = 0;

            if (grid == null || grid.Length == 0) {
                return count;
            }

            int rowCount = grid.GetLength(0);
            int columnCount = grid.GetLength(1);

            int[] rowOffset = new int[] { 0, 0, 1, -1 };
            int[] columnOffset = new int[] { 1, -1, 0, 0 };

            for (int i = 0; i < rowCount; i++) {
                for(int j =0; j < columnCount; j++) {

                    Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();

                    if (grid[i, j] == '1') {
                        count++;
                        stack.Push(Tuple.Create<int, int>(i, j));
                    }

                    // update all adjacent nodes.
                    while (stack.Any()) {

                        var position = stack.Pop();
                        int x = position.Item1;
                        int y = position.Item2;

                        if (x >= 0 && y >=0 && x < rowCount && y <columnCount && grid[x, y] == '1') {

                            grid[x, y] = '0';

                            for (int k = 0; k < rowOffset.Length; k++) {
                                stack.Push(Tuple.Create<int, int>(
                                    x + rowOffset[k],
                                    y + columnOffset[k]
                                    ));
                            }
                        }                        
                    }                                       
                }
            }

            return count;
        }
    }
}
