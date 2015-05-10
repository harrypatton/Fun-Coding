using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class ReverseString
    {
        public static void Reverse(char[] str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i <str.Length / 2; i ++)
            {
                char temp = str[i];
                int j = str.Length - 1 - i;

                str[i] = str[j];
                str[j] = temp;
            }
        }
    }
}
