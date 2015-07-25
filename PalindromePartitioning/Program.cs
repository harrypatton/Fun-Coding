using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromePartitioning {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();
            var result = s.Partition("aab");
        }
    }

    public class Solution {
        public IList<IList<string>> Partition(string s) {

            Dictionary<int, IList<IList<string>>> cache = new Dictionary<int, IList<IList<string>>>();
            return Partition(s, cache);
        }

        public IList<IList<string>> Partition(string s, Dictionary<int, IList<IList<string>>> cache) {

            List<IList<string>> result = new List<IList<string>>();

            if (s == null || s.Length == 0) {
                return result;
            }

            if (cache.ContainsKey(s.Length)) {
                return cache[s.Length];
            }
            
            for (int startIndex = 0; startIndex < s.Length; startIndex++) {
                string subString = s.Substring(startIndex);

                if (IsPalindrome(subString)) {
                    string previousSubstring = s.Substring(0, startIndex);
                    var previousResult = Partition(previousSubstring, cache);

                    if (previousResult.Any()) {
                        foreach (var myList in previousResult) {
                            List<string> list = new List<string>(myList);
                            list.Add(subString);
                            result.Add(list);
                        }
                    }
                    else {
                        List<string> list = new List<string>();
                        list.Add(s);
                        result.Add(list);
                    }
                }
            }

            cache.Add(s.Length, result);

            return result;
        }

        public bool IsPalindrome(string s) {
            if (s == null || s.Length <= 1) {
                return true;
            }

            for(int i = 0; i < s.Length / 2; i++) {
                if (s[i] != s[s.Length - 1 - i]) {
                    return false;
                }
            }

            return true;
        }
    }
}
