using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _171ConvertExcelTitleToNumber {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public int TitleToNumber(string s) {
            int result = 0;

            foreach(char c in s) {
                result = result * 26 + (c - 'A' + 1);
            }

            return result;
        }
    }
}
