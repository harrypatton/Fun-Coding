using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectRightTreeNode {
    class Program {
        static void Main(string[] args) {
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);
            TreeNode n6 = new TreeNode(6);
            TreeNode n7 = new TreeNode(7);

            n1.left = n2;
            n1.right = n3;

            n2.left = n4;
            n2.right = n5;

            n3.left = n6;
            n3.right = n7;

            Solution s = new Solution();
            s.Connect(n1);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode next;

        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public void Connect(TreeNode root) { 
            
            if (root == null || (root.left == null && root.right == null)) {
                return;
            }

            TreeNode headOnAboveLevel = root;
            TreeNode headOnCurrentLevel = root.left;
            
            while(headOnCurrentLevel != null) {

                TreeNode nodeOnAboveLevel = headOnAboveLevel;
                TreeNode nodeOnCurrentLevel = headOnCurrentLevel;

                while (nodeOnAboveLevel != null) {
                    nodeOnCurrentLevel.next = nodeOnAboveLevel.right;
                    nodeOnCurrentLevel.next.next = nodeOnAboveLevel.next == null ? null : nodeOnAboveLevel.next.left;
                    nodeOnCurrentLevel = nodeOnCurrentLevel.next.next;
                    nodeOnAboveLevel = nodeOnAboveLevel.next;
                }

                headOnAboveLevel = headOnCurrentLevel;
                headOnCurrentLevel = headOnAboveLevel.left;
            }            
        }
    }
}
