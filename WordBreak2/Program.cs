using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordBreak2 {
    class Program {
        static void Main(string[] args) {

            string s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab";
            string[] words = { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" };
            HashSet<string> wordDict = new HashSet<string>(words);

            var result = (new Solution()).WordBreak(s, wordDict);
        }
    }

    public class Solution {
        public IList<string> WordBreak(string s, ISet<string> wordDict) {
            
            List<string> result = new List<string>();

            if (s == null || s.Length == 0) {
                return result;
            }

            // check we have candidate from backward
            for (int j = s.Length - 1; j >= 0; j--) {
                string substring = s.Substring(j);

                if (wordDict.Contains(substring)) {
                    break;
                }
                else if (j == 0) {
                    return result;
                }
            }

            for (int i = 0; i < s.Length - 1; i++) {
                string substring = s.Substring(0, i + 1);

                if (wordDict.Contains(substring)) {
                    var tempResult = WordBreak(s.Substring(i + 1), wordDict);

                    foreach(var str in tempResult) {
                        result.Add(substring + " " + str);
                    }
                }
            }

            if (wordDict.Contains(s)) {
                result.Add(s);
            }

            return result;
        }
    }
}
