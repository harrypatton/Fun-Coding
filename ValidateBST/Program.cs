using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBST {
    class Program {
        static void Main(string[] args) {
            TreeNode n2 = new TreeNode(2);
            TreeNode n1 = new TreeNode(1);
            TreeNode n3 = new TreeNode(3);
            
            Solution s = new Solution();

            bool isValid = s.IsValidBST(n2);

            //n2.left = n1;
            //n2.right = n3;
            //bool isValid = s.IsValidBST(n3);

            //n3.left = n1;
            //n3.right = n2;
            //bool isValid = s.IsValidBST(n3);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {

        public bool IsValidBST(TreeNode root) {
            if (root == null) {
                return true;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode tempNode = root;
            
            int? previousValue = null;

            while (tempNode != null || stack.Any()) {

                while (tempNode != null) {
                    // early detection
                    // equal voilates the condition too.
                    if (stack.Any() && tempNode.val >= stack.Peek().val) {
                        return false;
                    }

                    stack.Push(tempNode);                    
                    tempNode = tempNode.left;
                }

                tempNode = stack.Pop();

                // equal voilates the condition too.
                if (previousValue.HasValue && previousValue.Value >= tempNode.val) {
                    return false;
                }

                // update previous value
                previousValue = tempNode.val;

                // go to next one
                tempNode = tempNode.right;                
            }

            return true;
        }
    }
}
