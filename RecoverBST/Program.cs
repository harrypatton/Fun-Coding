using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverBST {
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

        public void RecoverTree(TreeNode root) {
            if (root == null) {
                return;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode tempNode = root;

            TreeNode previousNode = null;
            TreeNode node1 = null;
            TreeNode node2 = null;
            bool sawFirstError = false;

            while (tempNode != null || stack.Any()) {

                while (tempNode != null) {
                    stack.Push(tempNode);
                    tempNode = tempNode.left;
                }

                tempNode = stack.Pop();

                // equal voilates the condition too.
                if (previousNode != null && previousNode.val >= tempNode.val) {
                    if (!sawFirstError) {
                        sawFirstError = true;
                        node1 = previousNode;
                    }

                    node2 = tempNode;
                }

                // update previous value
                previousNode = tempNode;

                // go to next one
                tempNode = tempNode.right;
            }

            int tempValue = node1.val;
            node1.val = node2.val;
            node2.val = tempValue;
        }
    }
}
