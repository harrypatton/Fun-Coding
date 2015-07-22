using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoreIpAddress {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();
            var result = s.RestoreIpAddresses("25525511135");
        }
    }

    public class Solution {
        public IList<string> RestoreIpAddresses(string s) {
            return RestoreIpAddresses(s, 4);
        }

        public IList<string> RestoreIpAddresses(string s, int partCount) {
            List<string> result = new List<string>();

            if (partCount == 1) {
                if (IsInRange(s)) {
                    result.Add(s);
                }

                return result;
            }

            for (int i = 1; i <= 3; i ++) { 
                if (s.Length > i) {
                    string token = s.Substring(s.Length - i);

                    // if token is not in range, continue to next
                    if (!IsInRange(token)) {
                        continue;
                    }

                    string substring = s.Substring(0, s.Length - i);
                    IList<string> subResults = RestoreIpAddresses(substring, partCount - 1);

                    foreach(var partialResult in subResults) {
                        result.Add(partialResult + "." + token);
                    }
                }                
            }

            return result;
        }

        public bool IsInRange(string s) {
            
            // invalid number.
            if (s == null || s.Length == 0 || s.Length > 3) {
                return false;
            }

            // all chars must be digits
            foreach(char c in s) {
                if (c < '0' || c > '9') {
                    return false;
                }
            }

            // no 0 in the begining if length is 1 or 2. invalid number.
            if ((s.Length == 2 || s.Length == 3) && s[0] == '0') {
                return false;
            }

            // if s length is 3, the max is 255.
            if (s.Length == 3) {
                // first number should be 1 or 2.
                if (s[0] > '2') {
                    return false;
                }

                if (s[0] == '2' && (s[1] > '5' || (s[1] == '5' && s[2] > '5'))) {
                    return false;
                }
            }

            return true;
        }
    }
}
