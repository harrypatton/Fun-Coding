using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionToDecimal {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).FractionToDecimal(int.MinValue, 1);
        }
    }

    public class Solution {
        public string FractionToDecimal(int numerator, int denominator) {

            if (denominator == 0) {
                throw new DivideByZeroException();
            }
            else if (numerator == 0) {
                return "0";
            }
            else if (numerator == denominator) {
                return "1";
            }

            return FractionToDecimal_Long(numerator, denominator);
        }

        public string FractionToDecimal_Long(long numerator, long denominator) {
            string result = string.Empty;

            if ((numerator > 0 && denominator < 0) || (numerator < 0 && denominator > 0)) {
                result += "-";

                numerator = numerator > 0 ? numerator : -numerator;
                denominator = denominator > 0 ? denominator : -denominator;
            }
            
            long division = numerator / denominator;
            long remainder = numerator % denominator;

            result += division.ToString();

            if (remainder == 0) {
                return result;
            }
            else {
                result += ".";
            }
            
            Dictionary<long, int> remainderList = new Dictionary<long, int>();

            while (remainder != 0) {                
                if (remainderList.ContainsKey(remainder)) {
                    int position = remainderList[remainder];
                    result = string.Format("{0}({1})", result.Substring(0, position), result.Substring(position));
                    break;
                }
                else {
                    long tempRemainder = remainder * 10 % denominator;
                    division = remainder * 10 / denominator;
                    result += division.ToString();
                    remainderList.Add(remainder, result.Length - 1);

                    // save for next iteration
                    remainder = tempRemainder;                    
                }
            }

            return result;
        }
    }
}
