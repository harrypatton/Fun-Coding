using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsPowerOfTwo {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).IsPowerOfTwo(int.MaxValue);
        }
    }

    public class Solution {
        public bool IsPowerOfTwo(int n) {
            if (n < 1) {
                return false;
            }

            while (n > 1) {
                int remainder = n % 2;

                if (remainder != 0) {
                    return false;
                }

                n = n >> 1;
            }

            return n == 1;
        }
    }
}
