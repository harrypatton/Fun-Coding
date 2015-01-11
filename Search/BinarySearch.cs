using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class BinarySearch
    {
        public static int Search(int[] numbers, int key)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("numbers");
            }

            int leftIndex = 0;
            int rightIndex = numbers.Length - 1;            

            while (leftIndex <= rightIndex)
            {
                int middleIndex = (rightIndex + leftIndex) / 2;

                if (numbers[middleIndex] == key)
                {
                    return middleIndex;
                }
                else if (numbers[middleIndex] > key)
                {
                    rightIndex = middleIndex - 1;
                }
                else
                {
                    leftIndex = middleIndex + 1;
                }
            }

            return -1;            
        }
    }
}
