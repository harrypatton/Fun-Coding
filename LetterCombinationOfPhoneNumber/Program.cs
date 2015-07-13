using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCombinationOfPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            string[] mapping = new string[10]
            {
                "0",
                "1",
                "abc",
                "def",
                "ghi",
                "jkl",
                "mno",
                "pqrs",
                "tuv",
                "wxyz"
            };

            List<string> result = new List<string>();
            
            foreach(char c in digits)
            {
                if (!result.Any())
                {
                    result.Add(string.Empty);
                }

                List<string> tempResult = new List<string>();

                foreach(char candidate in mapping[c - '0'])
                {
                    foreach(string str in result)
                    {
                        tempResult.Add(str + candidate.ToString());
                    }
                }

                result = tempResult;
            }

            return result;
        }
    }
}
