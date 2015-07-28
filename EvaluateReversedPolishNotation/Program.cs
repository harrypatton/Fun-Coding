using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluateReversedPolishNotation {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public int EvalRPN(string[] tokens) {

            string[] operators = { "+", "-", "*", "/" };

            if (tokens == null) {
                throw new ArgumentNullException();
            }

            if (tokens.Length == 1) {
                return int.Parse(tokens[0].ToString());
            }

            Stack<int> operands = new Stack<int>();
            
            foreach(string token in tokens) {
                if (operators.Contains(token)) {
                    int operand2 = operands.Pop();
                    int operand1 = operands.Pop();

                    int result = 0;
                    switch (token) {
                        case "+":
                            result = operand1 + operand2;
                            break;
                        case "-":
                            result = operand1 - operand2;
                            break;
                        case "*":
                            result = operand1 * operand2;
                            break;
                        case "/":
                            result = operand1 / operand2;
                            break;
                    }

                    operands.Push(result);
                }
                else {
                    operands.Push(int.Parse(token));
                }
            }

            return operands.Pop();
        }
    }
}
