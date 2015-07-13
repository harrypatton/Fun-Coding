using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsPalindromeInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int value1 = -7 % 10;
            int value2 = 7 % (-10);
        }
    }

    public class Solution
    {
        public bool isPalindrome(int x)
        {
            if (x < 0 || (x != 0 && x % 10 == 0)) return false;

            int rev = 0;

            while (x > rev)
            {
                rev = rev * 10 + x % 10;
                x = x / 10;
            }

            return (x == rev || x == rev / 10);
        }


        public bool IsPalindrome_Worse(int x)
        {
            // overflow case
            // negative integer

            if (x == int.MinValue)
            {
                return false;
            }

            if (x < 0)
            {
                //x = -x;
                return false; // treat negative one as not palindrom
            }

            int originalValue = x;
            int newValue = 0;

            while(x > 0)
            {
                int digit = x % 10;

                // overflow
                if ((newValue > int.MaxValue / 10) || (newValue == int.MaxValue / 10 && digit > 7))
                {                    
                    return false;
                }

                newValue = newValue * 10 + digit;
                x = x / 10;
            }

            return originalValue == newValue;
        }
    }
}
