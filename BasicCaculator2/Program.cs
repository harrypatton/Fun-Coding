using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCaculator2 {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public int Calculate(string s) {
            if (s == null || s.Length == 0) {
                return 0;
            }

            char[] operatorMapping = new char[] { '+', '-', '*', '/' };
            Stack<char> operators = new Stack<char>();
            Stack<int> operands = new Stack<int>();
            Stack<char> internalOperators = new Stack<char>();
            Stack<int> internalOperands = new Stack<int>();

            for (int i = s.Length - 1; i >= 0; i--) {
                if (operatorMapping.Contains(s[i])) {
                    operators.Push(s[i]);
                }
            }

            string[] numberStrings = s.Split(operatorMapping, StringSplitOptions.RemoveEmptyEntries);
            for (int i = numberStrings.Length - 1; i >= 0; i--) {
                string numStr = numberStrings[i].Trim();

                if (numStr != string.Empty) {
                    operands.Push(int.Parse(numStr));
                }
            }

            int result = 0;

            // consider scenario like "7"

            while (operators.Any() && operands.Any()) {

                char currentOperator = operators.Pop();

                if (currentOperator == '*' || currentOperator == '/') {
                    int operand1 = operands.Pop();
                    int operand2 = operands.Pop();

                    if (currentOperator == '*') {
                        result = operand1 * operand2;
                    }
                    else if (currentOperator == '/') {
                        result = operand1 / operand2;
                    }

                    operands.Push(result); // for next calculation or final result

                    // if we have backup oerators, and there's no next operator OR next one is + or -, we pop up backup operators.
                    if ((!operators.Any() || operators.Peek() == '+' || operators.Peek() == '-') && internalOperands.Any() && internalOperators.Any()) {
                        operators.Push(internalOperators.Pop());
                        operands.Push(internalOperands.Pop());
                    }
                }
                else if (currentOperator == '+' || currentOperator == '-') {
                    if (operators.Any() && (operators.Peek() == '*' || operators.Peek() == '/')) {
                        internalOperands.Push(operands.Pop());
                        internalOperators.Push(currentOperator);
                    }
                    else {
                        int operand1 = operands.Pop();
                        int operand2 = operands.Pop();

                        if (currentOperator == '+') {
                            result = operand1 + operand2;
                        }
                        else if (currentOperator == '-') {
                            result = operand1 - operand2;
                        }

                        operands.Push(result); // for next calculation or final result
                    }
                }
            }

            return operands.Pop();
        }
    }
}
