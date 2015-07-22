using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InOrderTraversal {
    class Program {
        static void Main(string[] args) {
            TreeNode root = new TreeNode(1);
            TreeNode rightNode = new TreeNode(2);
            root.right = rightNode;

            TreeNode leftInRightNode = new TreeNode(3);
            rightNode.left = leftInRightNode;

            Solution s = new Solution();
            var result = s.InorderTraversal(root);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public IList<int> InorderTraversal(TreeNode root) {

            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (root == null) {
                return result;
            }

            TreeNode dummyNode = new TreeNode(0);
            dummyNode.right = root;
            stack.Push(dummyNode);

            while (stack.Any()) {
                // pop up
                TreeNode topNode = stack.Pop();

                // add it to result
                if (topNode != dummyNode) {
                    result.Add(topNode.val);
                }

                // if right is not null, push it first.
                // and then push all left nodes if any to stack 
                if (topNode.right != null) {
                    stack.Push(topNode.right);
                    topNode = topNode.right;

                    while (topNode.left != null) {
                        stack.Push(topNode.left);
                        topNode = topNode.left;
                    }
                }                
            }

            return result;
        }
    }
}
