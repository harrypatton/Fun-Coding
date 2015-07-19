using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengthOfLastWord
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int LengthOfLastWord(string s)
        {
            if (s == null)
            {
                return 0;
            }

            // find the end of last word
            int end = s.Length - 1;

            while(end >= 0 && s[end] == ' ')
            {
                end--;
            }

            // all strings are spaces.
            if (end < 0)
            {
                return 0;
            }

            // find the position before last word
            int start = end;

            while(start >= 0 && s[start] != ' ')
            {
                start--;
            }

            return end - start;
        }
    }
}
