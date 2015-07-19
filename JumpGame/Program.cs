using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpGame
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return false;
            }
            
            if (nums.Length == 1 && nums[0] == 0)
            {
                return true;
            }

            int blockerIndex = -1;

            for(int i = nums.Length - 1; i >= 0; i --)
            {
                // there is no blocker after that position
                if (blockerIndex == -1)
                {
                    if (nums[i] == 0)
                    {
                        // set this blocker
                        blockerIndex = i;
                    }
                }
                else // there is a blocker after that position
                {
                    if (nums[i] != 0)
                    {
                        // when we can pass the position, or we can reach the blocker and the blocker is the final position,
                        // clear the blocker
                        if (i + nums[i] > blockerIndex || (blockerIndex == nums.Length - 1 && (i + nums[i] == blockerIndex)))
                        {
                            blockerIndex = -1;
                        }
                    }                    
                }                
            }

            return blockerIndex == -1;
        }
    }
}
