using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace TrappingRainWater
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int result = s.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            //int result = s.Trap(new int[] { 2, 0, 2 });
        }
    }

    public class Solution
    {
        public int Trap(int[] height)
        {
            if (height == null || height.Length <= 2)
            {
                return 0;
            }

            int leftMax = height[0];
            int[] maxQueueOnRight = new int[height.Length - 2];
            Array.Copy(height, 2, maxQueueOnRight, 0, maxQueueOnRight.Length);
            maxQueueOnRight = maxQueueOnRight.OrderByDescending(item => item).ToArray();

            int result = 0;
            for(int i = 1; i < height.Length - 1; i ++)
            {
                int rightMax = GetMax(maxQueueOnRight);
                int max = Math.Min(leftMax, rightMax);

                if (max > height[i])
                {
                    result += max - height[i];
                }

                // update left max for next iteration
                if (height[i] > leftMax)
                {
                    leftMax = height[i];
                }

                // update right queue for next iteration
                RemoveElement(maxQueueOnRight, height[i + 1]);
            }

            return result;
        }

        public void RemoveElement(int[] list, int target)
        {
            for (int i = 0; i < list.Length; i ++)
            {
                if (list[i] == target)
                {
                    list[i] = -1;
                    break;
                }
            }
        }

        public int GetMax(int[] list)
        {
            int result = -1;

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != -1)
                {
                    result = list[i];
                    break;
                }
            }

            return result;
        }
    }
}
