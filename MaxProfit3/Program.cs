using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProfit3 {
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
            int secondMax = 0;

            int index = 1;
            int value = 0;

            while (index <= prices.Length) {
                // We reach the last value to evaluate or the price drops
                if (index == prices.Length || prices[index - 1] >= prices[index]) {

                    if (value >= max) { // equal is very important
                        secondMax = max;
                        max = value;
                    }
                    else if (value > secondMax) {
                        secondMax = value;
                    }

                    // reset value 
                    value = 0;
                }
                else { // price goes up
                    value += prices[index] - prices[index - 1];
                }

                // go to next price day
                index++;
            }

            return max + secondMax;
        }
    }
}
