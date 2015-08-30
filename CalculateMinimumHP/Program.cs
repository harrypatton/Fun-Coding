using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateMinimumHP {
    class Program {
        static void Main(string[] args) {
            int[,] dungeon = new int[,] { 
                { 1, -3, 3 }, 
                { 0, -2, 0 }, 
                { -3, -3, -3 } };

            var result = (new Solution()).CalculateMinimumHP(dungeon);
        }
    }

    public class Solution {
        public int CalculateMinimumHP(int[,] dungeon) {
            if (dungeon == null || dungeon.Length == 0) {
                return 0;
            }

            int rowSize = dungeon.GetLength(0);
            int columnSize = dungeon.GetLength(1);
            int[] minHP = new int[columnSize];
            int[] remainingHP = new int[columnSize];            

            for (int i = 0; i < rowSize; i++) {
                for (int j = 0; j < columnSize; j++) {
                    int? minHpFromAbove = null;
                    int? minHpFromLeft = null;

                    if (i != 0) {
                        minHpFromAbove = GetMinHP(remainingHP[j], minHP[j], dungeon[i, j]); // above cell
                    }

                    if (j != 0) {
                        minHpFromLeft = GetMinHP(remainingHP[j - 1], minHP[j - 1], dungeon[i, j]); // left cell
                    }

                    if (!minHpFromLeft.HasValue && !minHpFromAbove.HasValue) { // the top-left corner cell, ignore it.
                        minHP[0] = dungeon[0, 0] > 0 ? 1 : 1 - dungeon[0, 0];
                        remainingHP[0] = minHP[0] + dungeon[0, 0];
                        continue;
                    }

                    // if above cell is the only choice, or above cell has a better min, choose above cell
                    if (!minHpFromLeft.HasValue || minHpFromAbove < minHpFromLeft) {
                        remainingHP[j] = (minHpFromAbove == minHP[j]) ? remainingHP[j] + dungeon[i, j] : 1;
                        minHP[j] = minHpFromAbove.Value;
                    }
                    else if (!minHpFromAbove.HasValue || minHpFromLeft <= minHpFromAbove) { // choose left cell
                        remainingHP[j] = (minHpFromLeft == minHP[j - 1]) ? remainingHP[j - 1] + dungeon[i, j] : 1;
                        minHP[j] = minHpFromLeft.Value;
                    }
                }
            }

            return minHP.Last();
        }

        public int GetMinHP(int remainingHP, int previousMinHP, int cellValue) {
            int tempHP = remainingHP + cellValue;

            if (tempHP > 0) {
                return previousMinHP;
            }
            else {
                return previousMinHP + 1 - tempHP;
            }
        }
    }
}
