using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildcardMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            bool result = s.IsMatch("", "*"); // -> true
            result = s.IsMatch("aa", "a"); // -> false
            result = s.IsMatch("aa", "aa"); // → true
            result = s.IsMatch("aaa", "aa"); // → false
            result = s.IsMatch("aa", "*"); // → true
            result = s.IsMatch("aa", "a*"); // → true
            result = s.IsMatch("ab", "?*"); // → true
            result = s.IsMatch("aab", "c*a*b"); // → false
            result = s.IsMatch("a", "aa"); // → false
            result = s.IsMatch("babaaababaabababbbbbbaabaabbabababbaababbaaabbbaaab", "***bba**a*bbba**aab**b");
            result = s.IsMatch("abbabbbaabaaabbbbbabbabbabbbabbaaabbbababbabaaabbab", "*aabb***aa**a******aa*");
            result = s.IsMatch("aaabbbaabaaaaababaabaaabbabbbbbbbbaabababbabbbaaaaba", "a*******b");
            result = s.IsMatch("abbabaaabbabbaababbabbbbbabbbabbbabaaaaababababbbabababaabbababaabbbbbbaaaabababbbaabbbbaabbbbababababbaabbaababaabbbababababbbbaaabbbbbabaaaabbababbbbaababaabbababbbbbababbbabaaaaaaaabbbbbaabaaababaaaabb", 
                "**aa*****ba*a*bb**aa*ab****a*aaaaaa***a*aaaa**bbabb*b*b**aaaaaaaaa*a********ba*bbb***a*ba*bb*bb**a*b*bb");
        }
    }

    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            // consecutive * could be reduced to one to improve performance.


            if (s == null)
            {
                return false;
            }

            if (s.Length == 0)
            {
                return p != null && p.Length == 1 && p[0] == '*';
            }

            int index = 0;

            for(int i = 0; i < s.Length; i ++)
            {
                // no more characters in pattern string
                if (index >= p.Length)
                {
                    return false;
                }

                if (p[index] == '*')
                {
                    // shortcut - find the right most position in the * sequence
                    while(index + 1 < p.Length && p[index + 1] == '*')
                    {
                        index++;
                    }

                    // shortcut.
                    if (index == p.Length - 1)
                    {
                        return true;
                    }

                    // use * to replace multiple chars
                    for(int j = i; j < s.Length; j++)
                    {
                        if (IsMatch(s.Substring(j), p.Substring(index+1)))
                        {
                            return true;
                        }
                    }

                    return false;
                }
                else if (s[i] == p[index] || p[index] == '?') // equal or use ?
                {
                    // compare next one.
                    index++;
                }
                else
                {
                    return false;
                }
            }

            // pattern string still has remaining characters.
            while (index < p.Length)
            {
                if (p[index] != '*')
                {
                    return false;
                }
                else
                {
                    index++;
                }
            }

            return true;
        }
    }
}
