using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsomorphicStrings {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public bool IsIsomorphic(string s, string t) {

            if (s == null && t == null) {
                return true;
            }
            else if (s == null || t== null) {
                return false;
            }

            Dictionary<char, char> mapping = new Dictionary<char, char>();
            HashSet<char> values = new HashSet<char>();

            for(int i = 0; i < s.Length; i++) {

                // two invalid scenarios
                // 1. the same s char maps to another different char.
                // 2. two different s chars maps to the same char.
                // Note: ContainsValue is O(n) operation, so we uses a separate HashSet object.
                if ((mapping.ContainsKey(s[i]) && mapping[s[i]] != t[i])
                    || (!mapping.ContainsKey(s[i]) && values.Contains(t[i]))){
                    return false;
                }
                
                if (!mapping.ContainsKey(s[i])) {
                    mapping.Add(s[i], t[i]);
                    values.Add(t[i]);
                }
            }

            return true;
        }
    }
}
