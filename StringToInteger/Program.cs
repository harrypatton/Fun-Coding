using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int a = s.MyAtoi("2147483648");
        }
    }

    public class Solution
    {
        public int MyAtoi(string str)
        {
            // null or empty string
            // invalid chars
            // negative sign
            // only negative sign

            if (str == null)
            {
                //throw new ArgumentException();
                return 0; // per requirement.
            }

            str = str.Trim();

            if (str.Length == 0 || str == "-" || str == "+")
            {
                //throw new ArgumentException();
                return 0; // per requirement.
            }

            int i = 0;
            bool isNegative = false;

            // check negative sign
            if (str[i] == '-')
            {
                isNegative = true;
                i++;
            }
            else if (str[i] == '+')
            {
                isNegative = false;
                i++;
            }

            int result = 0;
            int baseResult = 0;

            // check condition
            while(i < str.Length)
            {
                int digit = str[i] - '0';
                if ( digit < 0 || digit > 9)
                {
                    //throw new ArgumentException(string.Format("Invalid char '{0}'", c));
                    break; //per requirement - return partial result; use what we have right now.
                }

                // check overflow
                if (baseResult > int.MaxValue / 10 || (baseResult == int.MaxValue / 10 && digit > 7))
                {
                    //throw new OverflowException();
                    if (isNegative)
                    {
                        return int.MinValue;
                    }
                    else
                    {
                        return int.MaxValue; // per requirement
                    }
                }

                result = baseResult * 10 + digit;
                baseResult = result;
                i++;
            }
            
            if (isNegative)
            {
                result = -result;
            }

            return result;
        }
    }
}
