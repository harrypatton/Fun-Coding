using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class StringWithUnqiueChars
    {
        public static bool IsStringWithAllUniqueChars(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            // one optimization - cannot exceed 256 chars if only extended ASCII chars in this problem domain
            if (str.Length > 256)
            {
                return false;
            }

            bool[] charset = new bool[256];
            for(int i = 0; i < charset.Length; i ++)
            {
                charset[i] = false;
            }

            for(int i = 0; i < str.Length; i ++)
            {
                int index = str[i];
                if (charset[index])
                {
                    return false;
                }
                else
                {
                    charset[index] = true;
                }
            }

            return true;
        }
    }
}
