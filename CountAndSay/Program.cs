using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountAndSay
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public string CountAndSay(int n)
        {
            switch(n)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return "1";
            }
            
            string result = "1";

            for(int i = 2; i <= n; i ++)
            {
                int index = 0;
                int count = 0;

                string tempResult = string.Empty;

                while (index < result.Length)
                {
                    count++;

                    // reach last element or it is different from next element
                    // when the index reaches to the last one, we just simply add the result. we already have the correct count.                    
                    if (index == result.Length - 1 || result[index] != result[index + 1])
                    {
                        tempResult += count.ToString() + result[index].ToString();
                        count = 0;
                    }

                    index++;
                }

                result = tempResult;
            }
            
            return result;
        }

        public string CountAndSay2(int n)
        {
            switch (n)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return "1";
            }

            string previousResult = CountAndSay(n - 1);

            string result = string.Empty;

            int index = 0;
            int count = 0;

            while (index < previousResult.Length)
            {
                count++;

                // reach last element or it is different from next element
                if (index == previousResult.Length - 1 || previousResult[index] != previousResult[index + 1])
                {
                    result += count.ToString() + previousResult[index].ToString();
                    count = 0;
                }

                index++;
            }

            return result;
        }
    }
}
