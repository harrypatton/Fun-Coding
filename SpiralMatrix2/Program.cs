using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrix2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int[,] GenerateMatrix(int n)
        {
            int rank1 = n;
            int rank2 = n;
            int[,] matrix = new int[n, n];
            int iterationCount = (Math.Min(rank1, rank2) + 1) / 2;
            int value = 1;

            for (int x = 0; x < iterationCount; x++)
            {
                // Top Edge: (x, x) -> (x, rank2 - 1 - x)
                for (int y = x; y <= rank2 - 1 - x; y++)
                {
                    matrix[x, y] = value++;
                }

                // Right Edge: (x + 1, rank2 - 1 - x) -> (rank1 - 1 - x, rank2 - 1 - x)
                for (int y = x + 1; y <= rank1 - 1 - x; y++)
                {
                    matrix[y, rank2 - 1 - x] = value++;
                }

                // Bottom Edge: (rank1 - 1 - x, rank2 - 2 - x) -> (rank1 - 1 - x, x)
                if (rank1 - 1 - x > x) // must be below the top edge
                {
                    for (int y = rank2 - 2 - x; y >= x; y--)
                    {
                        matrix[rank1 - 1 - x, y] = value++;
                    }
                }

                // Left Edge: (rank1 - 2 - x, x) -> (x + 1, x)
                if (x < rank2 - 1 - x) // must be left on right edge
                {
                    for (int y = rank1 - 2 - x; y >= x + 1; y--)
                    {
                        matrix[y, x] = value++;
                    }
                }
            }

            return matrix;
        }
    }

}
