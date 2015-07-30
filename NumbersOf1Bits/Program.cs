using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersOf1Bits {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).HammingWeight(9);
        }
    }

    public class Solution {
        public int HammingWeight(uint n) {
            uint result = 0;

            while( n!= 0) {
                result += n & 1;
                n = n >> 1;
            }

            return (int)result;
        }
    }
}
