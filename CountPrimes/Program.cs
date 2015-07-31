using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPrimes {
    class Program {
        static void Main(string[] args) {
            var count = (new Solution()).CountPrimes(100000000);
        }
    }

    public class Solution {
        public int CountPrimes(int n) {
            bool[] isNonPrime = new bool[n];
            
            int sqrt = (int)(Math.Sqrt(n));
            int count = 0;

            for(int i = 2; i < n; i++) {
                if (!isNonPrime[i]) {

                    // found a prime.
                    count++;

                    // handle all multiple ones
                    if (i <= sqrt) {
                        int mulNum = i * 2;

                        while (mulNum < n) {
                            isNonPrime[mulNum] = true;
                            mulNum += i;
                        }                        
                    }
                }
            }

            return count;
        }
    }
}
