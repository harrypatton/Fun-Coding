using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreePreorderTraversal {
    class Program {
        static void Main(string[] args) {
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            n1.left = n2;
            n1.right = n3;
            var result = (new Solution()).PreorderTraversal(n1);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public IList<int> PreorderTraversal(TreeNode root) {

            List<int> result = new List<int>();

            if (root == null) {
                return result;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Any()) {
                TreeNode node = stack.Pop();
                
                while(node != null) {
                    result.Add(node.val);

                    if (node.right != null) {
                        stack.Push(node.right);
                    }

                    node = node.left;
                }
            }

            return result;
        }
    }
}
