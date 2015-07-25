using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();

            // scenario #1
            List<List<int>> triangle = new List<List<int>>();
            triangle.Add(new List<int>(new int[] { 2 }));
            triangle.Add(new List<int>(new int[] { 3, 4 }));
            triangle.Add(new List<int>(new int[] { 6, 5, 7 }));
            triangle.Add(new List<int>(new int[] { 4, 1, 8, 3 }));

            // scenario #2
            //List<List<int>> triangle = new List<List<int>>();
            //triangle.Add(new List<int>(new int[] { -1 }));
            //triangle.Add(new List<int>(new int[] { 2, 3 }));
            //triangle.Add(new List<int>(new int[] { 1, -1, -3 }));

            var result = s.MinimumTotal(triangle);
        }
    }

    public class Solution {
        public int MinimumTotal(List<List<int>> triangle) {
            if (triangle == null || triangle.Count == 0) {
                return 0;
            }

            if (triangle.Count == 1) {
                return triangle[0][0];
            }

            for(int level = 2; level <= triangle.Count; level ++) {
                List<int> aboveLevel = triangle[level - 2];
                List<int> currentLevel = triangle[level - 1];
                for(int i = 0; i < currentLevel.Count; i++) {

                    // the first node - just add right parent value.
                    if (i == 0) {
                        currentLevel[i] += aboveLevel.First();
                    }
                    else if (i == currentLevel.Count - 1) { // last node  just add left parent value.
                        currentLevel[i] += aboveLevel.Last();
                    }
                    else {
                        // middle value - we can choose left or right parents
                        currentLevel[i] += Math.Min(aboveLevel[i-1], aboveLevel[i]);
                    }
                }
            }

            List<int> bottomLevel = triangle.Last();
            int min = bottomLevel[0];

            for(int i = 1; i < bottomLevel.Count; i++) {
                min = (bottomLevel[i] < min) ? bottomLevel[i] : min;
            }

            return min;
        }
    }
}
