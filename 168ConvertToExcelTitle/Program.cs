using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _168ConvertToExcelTitle {
    class Program {
        static void Main(string[] args) {
            string result = (new Solution()).ConvertToTitle(26);
        }
    }

    public class Solution {

        const int Base = 'Z' - 'A' + 1;

        public string ConvertToTitle(int n) {

            if (n < 1) {
                throw new ArgumentException();
            }

            string result = string.Empty;
            int number = n - 1;

            while (true) {
                int remainder = number % Base;
                result = (char)(remainder + 'A') + result;

                number = number / Base;

                if (number == 0) {                    
                    break;
                }

                number = number - 1;
            }

            return result;
        }
    }
}
