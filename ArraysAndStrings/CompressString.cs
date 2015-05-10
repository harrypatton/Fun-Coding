using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class CompressString
    {
        public static string GetCompressedString(string str)
        {
            if (str == null || str.Length <= 2)
            {
                return str;
            }

            char[] compressedStr = new char[str.Length];
            char lastChar = str[0];
            compressedStr[0] = lastChar;
            int repeatNumber = 1;
            int index = 0;
            string numberString = null;

            for (int i = 1; i < str.Length; i++)
            {
                if (lastChar == str[i])
                {
                    repeatNumber++;
                }
                else
                {
                    numberString = repeatNumber.ToString();

                    if (index + numberString.Length + 2 < str.Length - 1)
                    {
                        lastChar = str[i];
                        for (int j = 0; j < numberString.Length; j ++)
                        {
                            compressedStr[index + 1 + j] = numberString[j];
                        }
                                                
                        compressedStr[index + numberString.Length + 1] = lastChar;
                        repeatNumber = 1;
                        index += numberString.Length + 1;
                    }
                    else
                    {
                        return str;
                    }
                }
            }

            numberString = repeatNumber.ToString();

            if (index + numberString.Length < str.Length - 1)
            {
                for (int j = 0; j < numberString.Length; j++)
                {
                    compressedStr[index + 1 + j] = numberString[j];
                }

                index += numberString.Length;
                return new string(compressedStr, 0, index + 1);
            }
            else
            {
                return str;
            }
        }
    }
}
