using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeRectangleArea {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) {

            int left1 = A;
            int bottom1 = B;
            int right1 = C;
            int top1 = D;

            int left2 = E;
            int bottom2 = F;
            int right2 = G;
            int top2 = H;

            int sumArea = (right1 - left1) * (top1 - bottom1) + (right2 - left2) * (top2 - bottom2);

            if (right1 <= left2 || right2 <= left1 || top1 <= bottom2 || top2 <= bottom1) { // no overlap
                return sumArea;
            }
            else { // overlap
                // calculate overlap area.
                int overlap = (Math.Min(right1, right2) - Math.Max(left1, left2)) * (Math.Min(top1, top2) - Math.Max(bottom1, bottom2));
                return sumArea - overlap;
            }
        }
    }
}
