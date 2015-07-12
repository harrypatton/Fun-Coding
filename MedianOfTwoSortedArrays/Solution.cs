using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianOfTwoSortedArrays
{
    public class Solution
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

            // swap arrays so nums1 is the smaller array.
            if (nums1.Length > nums2.Length)
            {
                var temp = nums2;
                nums2 = nums1;
                nums1 = temp;
            }

            int i = 0;
            int j = 0;
            int m = nums1.Length;
            int n = nums2.Length;

            // if first array is empty; we get the result directly. Please note, because nums1 is always the smaller one 
            // and we already checked if both array are empty, this is the only scenario to check.
            if (m == 0)
            {
                if ((m + n ) % 2 == 1)
                {
                    return nums2[n / 2];
                }
                else
                {
                    return (nums2[n / 2 - 1] + nums2[n / 2]) / (double)2;
                }
            }

            // assume all elements in array A are in LEFT part
            i = m - 1; // 0
            j = (m + n) / 2 - i - 2; // 0

            if (nums1[i] <= nums2[j+1])
            {
                return GetMedian(nums1, i, nums2, j);
            }

            // assume all elements in array A are in RIGHT part
            i = - 1;
            j = (m + n) / 2 - i - 2;

            if (nums2[j] <= nums1[0])
            {
                return GetMedian(nums1, i, nums2, j);
            }

            int first = 0;
            int last = m - 1;

            while(first <= last)
            {
                i = (first + last) / 2;
                j = (m + n) / 2 - i - 2;

                if (nums1[i] <= nums2[j + 1] && nums2[j] <= nums1[i + 1])
                {
                    return GetMedian(nums1, i, nums2, j);
                }
                else if (nums1[i] > nums2[ j + 1])
                {
                    last = i - 1;
                }
                else
                {
                    first = i + 1;
                }
            }

            throw new ApplicationException("this should never happen. a bug here.");
        }

        public double GetMedian(int[] nums1, int i, int[] nums2, int j)
        {
            bool isOdd = (nums1.Length + nums2.Length) % 2 == 1;

            if (isOdd)
            {
                return GetMin(nums1, i + 1, nums2, j + 1);
            }
            else
            {
                return (GetMin(nums1, i + 1, nums2, j + 1) + GetMax(nums1, i, nums2, j)) / (double)2;
            }
        }

        public double GetMin(int[] nums1, int i, int[] nums2, int j)
        {
            if (i == -1 || i == nums1.Length)
            {
                return nums2[j];
            }
            else if (j == -1 || j == nums2.Length)
            {
                return nums1[i];
            }
            else
            {
                return Math.Min(nums1[i], nums2[j]);
            }
        }

        public double GetMax(int[] nums1, int i, int[] nums2, int j)
        {
            if (i == -1 || i == nums1.Length)
            {
                return nums2[j];
            }
            else if (j == -1 || j == nums2.Length)
            {
                return nums1[i];
            }
            else
            {
                return Math.Max(nums1[i], nums2[j]);
            }
        }
    }
}
