using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _172FactorialTrailingZeroes {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).TrailingZeroes(int.MaxValue);
        }
    }

    public class Solution {
        public int TrailingZeroes(int n) {
            int count = 0;

            while(n > 0) {
                count += n / 5;
                n = n / 5;
            }

            return count;
        }
    }
}
