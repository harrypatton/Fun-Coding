using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricTree {
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
        public bool IsSymmetric(TreeNode root) {
            return root == null || IsSymmetric(root.left, root.right);
        }

        public bool IsSymmetric(TreeNode root1, TreeNode root2) {
            if (root1 == null && root2 == null) {
                return true;
            }

            return root1 != null && root2 != null && root1.val == root2.val && IsSymmetric(root1.left, root2.right) && IsSymmetric(root1.right, root2.left);
        }
    }
}
