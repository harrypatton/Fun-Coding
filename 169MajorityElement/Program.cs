using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _169MajorityElement {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Solution {
        public int MajorityElement(int[] nums) {
            int count = 0;
            int majority = 0;

            foreach(var num in nums) {
                if (count == 0) {
                    count++;
                    majority = num;
                }
                else {
                    count = majority == num ? count + 1 : count - 1;
                }
            }

            return majority;
        }
    }
}
