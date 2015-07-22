using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestHistogramRectangle {
    class Program {
        static void Main(string[] args) {

            Solution s = new Solution();
            int large = s.LargestRectangleArea(new int[] { 2, 4 });

        }
    }

    public class Solution {
        public int LargestRectangleArea(int[] height) {

            if (height == null || height.Length == 0) {
                return 0;
            }

            int maxRect = 0;
            Stack<int> stack = new Stack<int>();
            
            int i = 0;
            int leftWhenStackNotEmpty = -1;

            while (i < height.Length || stack.Any()) { 
                // if the element is greater or equal to top value in stack, push it to stack
                if (i < height.Length && (!stack.Any() || height[stack.Peek()] <= height[i])) {
                    stack.Push(i);

                    // next one
                    i++;
                }
                else {
                    // target: calculate area which uses target as minimum height
                    // left: the first smaller element when we scan the target to left.
                    // right: the first smaller element when we scan the target to right.                    

                    // the element is less than top one, so this element == right.
                    // target == stack top one.
                    // when i == height.length, it means we iteration all items. we just handle the rest of stacks.
                    int right = i;

                    if (i == height.Length) {
                        if (leftWhenStackNotEmpty == -1) {
                            leftWhenStackNotEmpty = stack.Peek();
                        }

                        right = leftWhenStackNotEmpty + 1;
                    }

                    int minHeight = height[stack.Pop()];

                    // find the left
                    // remember, after pop up element, current stack top could be equal to minHeight.
                    // When equal, we can simply ignore it because its max rect will be less than current one.
                    while(stack.Any() && height[stack.Peek()] == minHeight) {
                        stack.Pop();
                    }

                    int left = stack.Any() ? stack.Peek() : -1;

                    // the area doesn't include left and right
                    int rect = (right - left - 1) * minHeight;
                    maxRect = (maxRect < rect) ? rect : maxRect;

                    // don't increase variable i in this condition.
                }
            }            

            return maxRect;
        }
    }
}
