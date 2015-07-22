using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeWays {
    class Program {
        static void Main(string[] args) {

            Solution s = new Solution();
            int num = s.NumDecodings("110");

        }
    }

    public class Solution {
        public int NumDecodings(string s) {

            if (s == null || s.Length == 0) {
                return 0;
            }

            // f(n-2) result
            int fn2 = 0;

            // f(n-1) result
            int fn1 = 1;            

            // f(n) result
            int fn = 0;

            for(int i = 0; i < s.Length; i ++) {
                bool canUseDoubleDigits = i > 0 && (s[i - 1] == '1' || (s[i - 1] == '2' && s[i] >= '0' && s[i] <= '6'));
                bool canUseSingleDigit = s[i] >= '1' && s[i] <= '9';
                
                fn = 0;

                if (!canUseDoubleDigits && !canUseSingleDigit) {
                    break; // cannot interprete the number.
                }

                if (canUseDoubleDigits) {
                    fn += fn2;
                }

                if (canUseSingleDigit){
                    fn += fn1;
                }

                fn2 = fn1;
                fn1 = fn;                
            }

            return fn;
        }
    }
}
