using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedArrayToBST {
    class Program {
        static void Main(string[] args) {
        }
    }

     public class TreeNode {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { val = x; }
     }
 
    public class Solution {
        public TreeNode SortedArrayToBST(int[] nums) {
            if (nums == null) {
                return null;
            }

            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        public TreeNode SortedArrayToBST(int[] nums, int startIndex, int endIndex) {
            if (nums == null || nums.Length == 0 || startIndex > endIndex) {
                return null;
            }

            int middle = startIndex + (endIndex - startIndex) / 2;
            TreeNode root = new TreeNode(nums[middle]);

            root.left = SortedArrayToBST(nums, startIndex, middle - 1);
            root.right = SortedArrayToBST(nums, middle + 1, endIndex);

            return root;
        }
    }
}
