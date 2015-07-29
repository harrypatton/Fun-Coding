using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _173BinarySearchTreeIterator {
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


    public class BSTIterator {

        private Stack<TreeNode> stack;

        public BSTIterator(TreeNode root) {

            stack = new Stack<TreeNode>();

            while(root != null) {
                stack.Push(root);
                root = root.left;
            }

        }

        /** @return whether we have a next smallest number */
        public bool HasNext() {
            return stack.Any();
        }

        /** @return the next smallest number */
        public int Next() {

            if (!stack.Any()) {
                throw new InvalidOperationException();
            }

            TreeNode resultNode = stack.Pop();
            TreeNode right = resultNode.right;

            while(right != null) {
                stack.Push(right);
                right = right.left; // keep pushing left node.
            }

            return resultNode.val;
        }
    }

    /**
     * Your BSTIterator will be called like this:
     * BSTIterator i = new BSTIterator(root);
     * while (i.HasNext()) v[f()] = i.Next();
     */
}
