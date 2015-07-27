using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    class Program {
        static void Main(string[] args) {
            int[] gas = new int[] { 5, 4, 4, 2 };
            int[] cost = new int[] { 3, 2, 5, 3 };
            Solution s = new Solution();
            var index = s.CanCompleteCircuit(gas, cost);
        }
    }

    public class Solution {
        public int CanCompleteCircuit(int[] gas, int[] cost) {

            if (gas == null || gas.Length == 0) {
                return -1;
            }

            if (gas.Length == 1) {
                return (gas[0] >= cost[0]) ? 0 : -1;
            }

            int start = 0;
            int end = 1;
            int totalCost = gas[start] - cost[start];

            while(start != end) {
                if (totalCost >= 0) {

                    totalCost += gas[end] - cost[end];
                    end = (end + 1) == gas.Length ? 0 : end + 1;                    
                }
                else {
                    start = (start - 1) == -1 ? gas.Length - 1 : start - 1;
                    totalCost += gas[start] - cost[start];
                }
            }

            return totalCost >= 0 ? start : -1;
        }
    }
}
