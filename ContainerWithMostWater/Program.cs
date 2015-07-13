using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int MaxArea(int[] height)
        {
            if (height == null || height.Length <= 1)
            {
                throw new ArgumentException();
            }

            int max = 0;

            int first = 0;
            int last = height.Length - 1;

            while(first < last)
            {
                int area = (last - first) * Math.Min(height[first], height[last]);

                if (area > max)
                {
                    max = area;
                }

                if (height[first] < height[last])
                {
                    first++; // it becauses the same first with any other last wouldn't be better.
                }
                else
                {
                    last--;
                }
            }

            return max;
        }
    }
}
