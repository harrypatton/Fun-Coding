using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KthSmallestElementInBST {
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
        public int KthSmallest(TreeNode root, int k) {

            Stack<TreeNode> stack = new Stack<TreeNode>();

            while(root != null || stack.Any()) {

                // push itself and all left nodes to stack
                while(root != null) {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                k--;

                if (k == 0) {
                    return root.val;
                }

                root = root.right;
            }

            throw new ApplicationException("Cannot find kth smallest element.");
        }
    }
}
