using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            // check condition
            if (strs == null)
            {
                throw new ArgumentNullException();
            }

            string result = string.Empty;
            int index = 0;

            while(strs.Length > 0 && index < strs[0].Length)
            {
                bool reachLongest = false;
                for(int i = 1; i < strs.Length; i ++)
                {
                    if (index >= strs[i].Length || strs[i][index] != strs[i-1][index])
                    {
                        // we found the longest.
                        reachLongest = true;                                                
                        break;
                    }
                }

                if (reachLongest)
                {
                    break;
                }
                else
                {
                    result += strs[0][index].ToString();
                    index++;
                }
            }

            return result;
        }
    }
}
