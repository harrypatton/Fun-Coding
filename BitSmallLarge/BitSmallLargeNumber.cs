using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bits
{
    public class BitSmallLargeNumber {

        public static int GetSmallest(int value) {
            int length = 0;
            int numberOfOne = 0;
            GetInfo(value, out length, out numberOfOne);

            int result = 1 << numberOfOne;
            return result - 1;
        }

        public static int GetLargest(int value) {
            int length = 0;
            int numberOfOne = 0;
            GetInfo(value, out length, out numberOfOne);

            int result = GetSmallest(value);
            return result << (length - numberOfOne);
        }

        private static void GetInfo(int value, out int length, out int numberOfOne) {

            if (value < 0) {
                throw new NotSupportedException("No support for negative number.");
            }

            length = 0;
            numberOfOne = 0;

            while(value != 0) {
                length++;

                if (value % 2 == 1) {
                    numberOfOne++;
                }

                value /= 2;
            }
        }
    }
}
