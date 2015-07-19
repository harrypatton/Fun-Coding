using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public bool IsValidSudoku(char[,] board)
        {
            bool[,] rows = new bool[9,9];
            bool[,] columns = new bool[9, 9];
            bool[,] subsets = new bool[9, 9];

            for(int i = 0; i < board.GetLength(0); i ++)
            {
                for(int j = 0; j < board.GetLength(1); j ++)
                {
                    int value = board[i, j] - '0';

                    if (value >= 1 && value <= 9)
                    {
                        int numberIndex = value - 1;
                        int subsetIndex = (i / 3) * 3 + j / 3;

                        if (rows[numberIndex, i] || columns[numberIndex, j] || subsets[numberIndex, subsetIndex])
                        {
                            return false;
                        }
                        else
                        {
                            rows[numberIndex, i] = true;
                            columns[numberIndex, j] = true;
                            subsets[numberIndex, subsetIndex] = true;
                        }
                    }
                }
            }

            return true;
        }
    }
}
