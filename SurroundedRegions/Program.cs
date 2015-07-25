using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurroundedRegions {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {

        public const char valueO = 'O';
        public const char valueX = 'X';
        public const char valueC = 'C';

        public void Solve(char[,] board) {
            if (board == null || board.Length == 1) {
                return;
            }

            // check two boundary rows.
            foreach(int i in new int[] { 0, board.GetLength(0) - 1 }) {
                for (int j = 0; j < board.GetLength(1); j++) {
                    if (board[i, j] == valueO) {
                        MarkAdjacentNodes(board, i, j);
                    }
                }
            }

            // check two boundary columns.
            foreach (int j in new int[] { 0, board.GetLength(1) - 1 }) {
                for (int i = 0; i < board.GetLength(0); i++) {
                    if (board[i, j] == valueO) {
                        MarkAdjacentNodes(board, i, j);
                    }
                }
            }

            for (int i = 0; i < board.GetLength(0); i++) {
                for (int j = 0; j < board.GetLength(1); j++) {
                    if (board[i, j] == valueO) {
                        board[i, j] = valueX;
                    }
                    else if (board[i, j] == valueC) {
                        board[i, j] = valueO;
                    }
                }
            }
        }

        public void MarkAdjacentNodes(char[,] board, int i, int j) {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            stack.Push(Tuple.Create<int, int>(i, j));

            while (stack.Any()) {
                var position = stack.Pop();

                i = position.Item1;
                j = position.Item2;

                if (board[i, j] != valueO) {
                    continue;
                }

                board[i, j] = valueC;

                // check top adjacent node
                if (position.Item1 > 0) {
                    stack.Push(Tuple.Create<int, int>(i - 1, j));
                }

                // check right adjacent node
                if (position.Item2 < board.GetLength(1) - 1) {
                    stack.Push(Tuple.Create<int, int>(i, j + 1));
                }

                // check bottom adjacent node
                if (position.Item1 < board.GetLength(0) - 1) {
                    stack.Push(Tuple.Create<int, int>(i + 1, j));
                }

                // check left adjacent node
                if (position.Item2 > 0) {
                    stack.Push(Tuple.Create<int, int>(i, j - 1));
                }
            }
        }
    }
}
