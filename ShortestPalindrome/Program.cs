using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPalindrome {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).ShortestPalindrome("abad");
        }
    }

    public class Solution {
        public string ShortestPalindrome(string s) {
            if (s == null || s.Length <= 1) {
                return s;
            }

            int left = 0;
            int right = s.Length - 1;

            while (right > left && !IsPalindrome(s, left, right)) {
                right--;
            }

            if (right == s.Length - 1) {
                return s;
            }
            else {
                return (new string(s.Substring(right + 1).Reverse().ToArray())) + s;
            }
        }

        public bool IsPalindrome(string s, int left, int right) {
            if (left >= right) {
                return true;
            }

            int middle = (left + right - 1) / 2;

            for(int i = left; i <= middle; i++) {
                if (s[i] != s[right + left - i]) {
                    return false;
                }
            }

            return true;
        }
    }
}
