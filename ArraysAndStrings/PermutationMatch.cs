using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class PermutationMatch
    {
        public static bool IsPermutation(string str1, string str2)
        {
            if (str1 == null && str2 == null)
            {
                return true;
            }
            else if (str1 == null || str2 == null || str1.Length != str2.Length)
            {
                return false;
            }

            int[] charSet = new int[256];

            for(int i = 0; i < str1.Length; i ++)
            {
                charSet[str1[i]]++;
            }

            for(int i = 0; i < str2.Length; i ++)
            {
                if(--charSet[str2[i]] < 0)
                {
                    return false;
                }
            }

            //return charSet.All(num => num == 0);
            return true;
        }
    }
}
