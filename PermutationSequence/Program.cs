using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationSequence
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public string GetPermutation(int n, int k)
        {
            if (n == 0)
            {
                return string.Empty;
            }

            if (n == 1)
            {
                return k == 1 ? n.ToString() : string.Empty;
            }

            int[] nums = new int[n];
            int counter = 1; // we already have one to start

            for(int i = 0; i < nums.Length; i ++)
            {
                nums[i] = i + 1;
            }           

            // keep finding next geater permutation
            while (counter < k)
            {
                // from right to left, find the first one less than the right number.
                int left = nums.Length - 2;

                while (left >= 0 && nums[left] >= nums[left + 1])
                {
                    left--;
                }

                // we found all combinations
                if (left < 0)
                {
                    break;
                }

                // find the position on the right to be replace
                int right = nums.Length - 1;
                while (nums[right] <= nums[left])
                {
                    right--;
                }

                // swap both positions
                Swap(nums, left, right);

                // reverse letters on right side
                Reverse(nums, left + 1);

                // increase counter
                counter++;                
            }

            if (counter == k)
            {
                return new string(nums.Select(item => item.ToString()[0]).ToArray());
            }
            else
            {
                throw new ArgumentException("Bad input parameter?");
            }            
        }

        private void Swap(int[] nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }

        private void Reverse(int[] nums, int startIndex)
        {
            if (startIndex > nums.Length - 1)
            {
                return;
            }

            for (int i = 0; i < (nums.Length - startIndex) / 2; i++)
            {
                Swap(nums, startIndex + i, nums.Length - 1 - i);
            }
        }

    }
}
