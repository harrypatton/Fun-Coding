using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class RotatedString
    {
        public static bool IsRotated(string testString, string baseString)
        {
            if (testString == null || baseString == null)
            {
                throw new ArgumentNullException();
            }

            if (testString.Length != baseString.Length)
            {
                return false;
            }

            string concatedString = testString + testString;
            return concatedString.IndexOf(baseString) >= 0;
        }
    }
}
