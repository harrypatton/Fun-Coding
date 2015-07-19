using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            if (s == null || s.Length < 2)
            {
                return 0;
            }

            int maxLength = 0;
            int currentLength = 0;
            int counter = 0;

            foreach (char c in s)
            {
                counter = counter + (c == '(' ? 1 : -1);

                // a valid just ends.
                if (counter < 0)
                {
                    maxLength = (maxLength > currentLength) ? maxLength : currentLength;
                    counter = 0;
                    currentLength = 0;
                }
                else
                {
                    currentLength++;
                }
            }

            if (counter == 0)
            {
                currentLength = currentLength - counter;
                maxLength = (maxLength > currentLength) ? maxLength : currentLength;
            }
            else
            {

            }

            return maxLength;
        }
    }

}
