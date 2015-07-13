using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public bool IsValid(string s)
        {
            if (s == null)
            {
                return false;
            }

            Stack<char> stack = new Stack<char>();

            foreach(char c in s)
            {
                switch(c)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;
                    case ')':
                        if (!stack.Any() || stack.Pop() != '(')
                        {
                            return false;
                        }
                        break;
                    case '}':
                        if (!stack.Any() || stack.Pop() != '{')
                        {
                            return false;
                        }
                        break;
                    case ']':
                        if (!stack.Any() || stack.Pop() != '[')
                        {
                            return false;
                        }
                        break;
                }                
            }

            return !stack.Any();
        }
    }
}
