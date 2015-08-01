using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAnagram {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public bool IsAnagram(string s, string t) {

            if (s == null || t == null || s.Length != t.Length) {
                return false;
            }

            Dictionary<char, int> mapping = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++) {
                if (s[i] != t[i]) {

                    if (mapping.ContainsKey(s[i])) {
                        mapping[s[i]]++;
                    }
                    else {
                        mapping.Add(s[i], 1);
                    }

                    if (mapping.ContainsKey(t[i])) {
                        mapping[t[i]]--;
                    }
                    else {
                        mapping.Add(t[i], -1);
                    }
                }
            }

            return mapping.All(item => item.Value == 0);
        }
    }
}
