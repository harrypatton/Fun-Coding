using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlattenBinaryTreeToLinkedList {
    class Program {
        static void Main(string[] args) {
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);

            n1.left = n2;
            n1.right = n3;

            Solution s = new Solution();
            s.Flatten(n1);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public void Flatten(TreeNode root) {
            FlattenAndGetTail(root);
        }

        public TreeNode FlattenAndGetTail(TreeNode root) {
            if (root == null || (root.left == null && root.right == null)) {
                return root;
            }

            var leftTreeLinkTail = FlattenAndGetTail(root.left);
            var rightTreeLinkTail = FlattenAndGetTail(root.right);

            if (leftTreeLinkTail == null) {
                return rightTreeLinkTail;
            }
            else if (rightTreeLinkTail == null) {
                root.right = root.left;
                root.left = null; // cut the left link
                return leftTreeLinkTail;
            }
            else {
                TreeNode tempRightNode = root.right;
                root.right = root.left;
                root.left = null; // cut the left link
                leftTreeLinkTail.right = tempRightNode;
                return rightTreeLinkTail;
            }
        }
    }
}
