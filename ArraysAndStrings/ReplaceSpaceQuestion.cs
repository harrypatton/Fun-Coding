using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class ReplaceSpaceQuestion
    {
        public static void ReplaceSpace(char[] str, int length)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            if (str.Length < length)
            {
                throw new ArgumentException();
            }

            int spaceCount = 0;

            for (int i = 0; i < length; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            if ((length + 2 * spaceCount) != str.Length)
            {
                throw new ArgumentException();
            }

            int j = str.Length;

            for (int i = length - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    j -= 3;
                    str[j] = '%';
                    str[j + 1] = '2';
                    str[j + 2] = '0';
                }
                else
                {
                    j -= 1;
                    str[j] = str[i];
                }
            }
        }
    }
}
