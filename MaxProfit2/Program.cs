using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProfit2 {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public int MaxProfit(int[] prices) {
            if (prices == null || prices.Length <= 1) {
                return 0;
            }

            int max = 0;

            for(int i = 0; i < prices.Length - 1; i++) {
                if (prices[i] < prices[i + 1]) {
                    max += prices[i + 1] - prices[i];
                }
            }

            return max;
        }
    }
}
