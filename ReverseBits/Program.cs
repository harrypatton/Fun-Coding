using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseBits {
    class Program {
        static void Main(string[] args) {
            //var result = (new Solution()).reverseBits_onetime(43261596);
            var result = (new Solution()).reverseBits(43261596);
            //var result = (new Solution()).reverseBits(11);
        }
    }

    public class Solution {

        /// <summary>
        /// this one is the optimal solution
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public uint reverseBits(uint n) {
            Dictionary<uint, uint> singleBitMapping = new Dictionary<uint, uint>();
            singleBitMapping.Add(0, 0);
            singleBitMapping.Add(1, 1);

            Dictionary<uint, uint> mapping = new Dictionary<uint, uint>();

            for(uint i = 0; i < 256; i++) {
                mapping.Add(i, ReverseBits(i, 8, 1, singleBitMapping));
            }

            return ReverseBits(n, 4, 8, mapping);
        }

        public uint reverseBits_onetime(uint n) {
            Dictionary<uint, uint> mapping = new Dictionary<uint, uint>();
            mapping.Add(0, 0);
            mapping.Add(1, 1);

            return ReverseBits(n, 32, 1, mapping);
        }

        public uint ReverseBits(uint n, uint moveCount, uint shiftStep, Dictionary<uint, uint> mapping) {
            uint result = 0;
            uint one = 1;

            for (uint i = 0; i < moveCount; i++) {
                uint digit = n & ((one << (int)shiftStep) - 1);
                result = (result << (int)shiftStep) | mapping[digit];
                n = n >> (int)shiftStep;
            }

            return result;
        }
    }
}
