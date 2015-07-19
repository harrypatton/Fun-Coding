using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string[] boardString = new string[] { "..9748...", "7........", ".2.1.9...", "..7...24.", ".64.1.59.", ".98...3..", "...8.3.2.", "........6", "...2759.." };
            char[,] board = new char[9, 9];

            for(int i = 0; i < 9; i ++)
            {
                for (int j = 0; j < 9; j ++)
                {
                    board[i, j] = boardString[i][j];
                }
            }

            s.SolveSudoku(board);
        }
    }

    public class Solution
    {
        public void SolveSudoku(char[,] board)
        {
            bool solved = SolveSudokuHelper(board);
            
            if (!solved)
            {
                throw new ApplicationException("Soduku not solved.");
            }
        }

        public bool SolveSudokuHelper(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    int value = 0;

                    // we need to fill in this cell.
                    if (!GetValue(board[i, j], out value))
                    {
                        for(char candidate = '1'; candidate <= '9'; candidate ++)
                        {
                            board[i, j] = candidate;

                            if (IsValid(board, i, j) && SolveSudokuHelper(board))
                            {
                                return true;
                            }
                        }

                        // cannot find a candidate, back off
                        board[i, j] = '.';
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsValid(char[,] board, int row, int column)
        {
            bool[] charExists = new bool[9];
            int value = 0;
            
            // check all elements on the row
            for (int k = 0; k < board.GetLength(1); k++)
            {
                if (GetValue(board[row, k], out value))
                {
                    if (charExists[value - 1])
                    {
                        return false;
                    }
                    else
                    {
                        charExists[value - 1] = true;
                    }
                }
            }

            // check all elements on the column
            charExists = new bool[9];
            for (int k = 0; k < board.GetLength(0); k++)
            {
                if (GetValue(board[k, column], out value))
                {
                    if (charExists[value - 1])
                    {
                        return false;
                    }
                    else
                    {
                        charExists[value - 1] = true;
                    }
                }
            }

            // check all elements on the subset
            charExists = new bool[9];
            int startRowIndex = (row / 3) * 3;
            int startColumnIndex = (column / 3) * 3;

            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                    if (GetValue(board[startRowIndex + rowIndex, startColumnIndex + columnIndex], out value))
                    {
                        if (charExists[value - 1])
                        {
                            return false;
                        }
                        else
                        {
                            charExists[value - 1] = true;
                        }
                    }
                }
            }

            return true;
        }

        public bool GetValue(char c, out int value)
        {
            value = c - '0';
            return value >= 1 && value <= 9;
        }
    }
}
