using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyNumber {
    class Program {
        static void Main(string[] args) {
            var result = (new Solution()).IsHappy(18);
        }
    }

    public class Solution {

        public bool IsHappy(int n) {

            int slow = n;
            int fast = n;

            while (true) {
                slow = GetNextNumber(slow);
                fast = GetNextNumber(fast);
                fast = GetNextNumber(fast);

                if (slow == fast) {
                    break;
                }
            }

            return slow == 1;
        }

        public bool IsHappy_MoreMemory(int n) {

            HashSet<int> cache = new HashSet<int>();

            while (!cache.Contains(n)) {
                cache.Add(n);

                n = GetNextNumber(n);
            }

            return n == 1;
        }

        public int GetNextNumber(int num) {
            int result = 0;

            while (num != 0) {
                int remainder = num % 10;
                result += remainder * remainder;

                num = num / 10;
            }

            return result;
        }
    }
}
