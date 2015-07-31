using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitwiseAndNumberRange {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).RangeBitwiseAnd(5, 7);
        }
    }

    public class Solution {
        public int RangeBitwiseAnd(int m, int n) {
            int count = 0;

            while(m != n) {
                count++;
                m = m >> 1;
                n = n >> 1;
            }

            return m << count;
        }
    }

}
