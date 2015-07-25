using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidPalindrome {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public bool IsPalindrome(string s) {
            if (s == null || s.Length <= 1) {
                return true;
            }

            int left = 0;
            int right = s.Length - 1;

            while(left < right) {

                if (!IsValid(s[left])) {
                    left++;
                }
                else if (!IsValid(s[right])) {
                    right--;
                }
                else if (!IsEqual(s[left], s[right])) {
                    return false;
                }
                else {
                    left++;
                    right--;
                }
            }

            return true;
        }

        public bool IsValid(char c) {
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        public bool IsEqual(char c, char b) {
            if (c >= '0' && c <= '9') {
                return c == b;
            }

            if (c >= 'A' && c <= 'Z') {
                c = (char)(c + 'a' - 'A'); 
            }

            if (b >= 'A' && b <= 'Z') {
                b = (char)(b + 'a' - 'A');
            }

            return c == b;
        }
    }
}
