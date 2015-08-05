using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculate {
    class Program {
        static void Main(string[] args) {
            int result = (new Solution()).Calculate("(4 + 9)");
        }
    }

    public class Solution {
        public int Calculate(string s) {
            if (s== null || s.Length == 0) {
                return 0;
            }

            char[] operatorMapping = new char[] { '+', '-', '(', ')' };
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
            for(int i = numberStrings.Length - 1; i >=0; i--) {
                string numStr = numberStrings[i].Trim();

                if (numStr != string.Empty) {
                    operands.Push(int.Parse(numStr));
                }
            }

            int result = 0;
            
            // consider scenario like "7", "(7)"

            while (operators.Any() && operands.Any()) {

                char currentOperator = operators.Pop();

                if (currentOperator == ')') { // finish current parenthese calculation, need to restore previous operator/operand.
                    if (internalOperands.Any()) { // have to check for scenario like "(4 + 9)"
                        operators.Push(internalOperators.Pop());
                        operands.Push(internalOperands.Pop());
                    }                    
                }
                else if (currentOperator == '(' && operators.Any() && operators.Peek() == ')') { // for scenario like (7). we just need to remove the parentheses.
                    operators.Pop();
                }
                else if (operators.Any() && operators.Peek() == '(') { // we need to temporary push the operator and operand to internal stack
                    operators.Pop(); // remove the left open brace.
                    internalOperators.Push(currentOperator);
                    internalOperands.Push(operands.Pop());                    
                }                
                else if (currentOperator != '(') { // calculate the result. add the condition for scenario like (4+9).
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

            return operands.Pop();
        }
    }
}
