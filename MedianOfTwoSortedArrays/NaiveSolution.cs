using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianOfTwoSortedArrays
{
    public class NaiveSolution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
            {
                throw new ArgumentNullException();
            }

            int[] newValues = new int[nums1.Length + nums2.Length];
            int newArrayLength = newValues.Length;

            if (newArrayLength == 0)
            {
                throw new ArgumentException("There is no median value.");
            }

            int index1 = 0;
            int index2 = 0;
            int index = 0;

            while (index < newArrayLength)
            {
                if (index2 >= nums2.Length || (index1 < nums1.Length && nums1[index1] < nums2[index2]))
                {
                    newValues[index++] = nums1[index1++];
                }
                else
                {
                    newValues[index++] = nums2[index2++];
                }
            }

            if (newArrayLength % 2 == 1)
            {
                return newValues[newArrayLength / 2];
            }
            else
            {
                return (newValues[newArrayLength / 2 - 1] + newValues[newArrayLength / 2]) / (double)2;
            }
        }

    }
}
