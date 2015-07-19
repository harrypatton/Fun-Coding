using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[,] matrix = { { 1 } };
            var result = s.SpiralOrder(matrix);
        }
    }

    public class Solution
    {
        public IList<int> SpiralOrder(int[,] matrix)
        {
            if (matrix == null)
            {
                return null;
            }

            int rank1 = matrix.GetLength(0);
            int rank2 = matrix.GetLength(1);
            int[] result = new int[rank1 * rank2];
            int iterationCount = (Math.Min(rank1, rank2) + 1) / 2;
            int index = 0;

            for (int x = 0; x < iterationCount; x++)
            {
                // Top Edge: (x, x) -> (x, rank2 - 1 - x)
                for (int y = x; y <= rank2 - 1 - x; y++)
                {
                    result[index++] = matrix[x, y];
                }

                // Right Edge: (x + 1, rank2 - 1 - x) -> (rank1 - 1 - x, rank2 - 1 - x)
                for (int y = x + 1; y <= rank1 - 1 - x; y++)
                {
                    result[index++] = matrix[y, rank2 - 1 - x];
                }

                // Bottom Edge: (rank1 - 1 - x, rank2 - 2 - x) -> (rank1 - 1 - x, x)
                if (rank1 - 1 - x > x) // must be below the top edge
                {
                    for (int y = rank2 - 2 - x; y >= x; y--)
                    {
                        result[index++] = matrix[rank1 - 1 - x, y];
                    }
                }

                // Left Edge: (rank1 - 2 - x, x) -> (x + 1, x)
                if (x < rank2 - 1 - x) // must be left on right edge
                {
                    for (int y = rank1 - 2 - x; y >= x + 1; y--)
                    {
                        result[index++] = matrix[y, x];
                    }
                }
            }

            if (index != rank1 * rank2)
            {
                throw new ApplicationException("bug. count doesn't match");
            }

            return new List<int>(result);
        }
    }
}
