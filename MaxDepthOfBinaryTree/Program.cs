using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxDepthOfBinaryTree {
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
        public int MaxDepth(TreeNode root) {
            return MaxDepth(root, 0);
        }

        public int MaxDepth(TreeNode root, int upperLevel) {
            if (root == null) {
                return upperLevel;
            }
            else {
                upperLevel += 1;
                return Math.Max(MaxDepth(root.left, upperLevel), MaxDepth(root.right, upperLevel));
            }
        }
    }
}
