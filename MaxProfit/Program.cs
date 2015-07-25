using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProfit {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public int MaxProfit(int[] prices) {
            if (prices == null || prices.Length <= 1) {
                return 0;
            }

            int maxProfit = 0;
            int minPrice = prices[0];

            for(int i = 1; i < prices.Length; i++) {
                int maxProfitCandidate = prices[i] - minPrice;
                maxProfit = (maxProfit > maxProfitCandidate) ? maxProfit : maxProfitCandidate;
                minPrice = Math.Min(minPrice, prices[i]);
            }

            return maxProfit;
        }
    }
}
