using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildTreeFromPreAndInOrder {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();
            int[] preorder = new int[] { 1, 2, 4, 5, 3, 6, 7 };
            int[] inorder = new int[] { 4, 2, 5, 1, 6, 3, 7 };
            var result = s.BuildTree(preorder, inorder);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public TreeNode BuildTree(int[] preorder, int[] inorder) {

            if (preorder == null || preorder.Length == 0) {
                return null;
            }

            int rootValue = preorder[0];
            TreeNode root = new TreeNode(rootValue);
            int rootIndex = -1;

            // find rootValue in inorder list
            for(int i = 0; i < inorder.Length; i++) {
                if (inorder[i] == rootValue) {
                    rootIndex = i;
                    break;
                }
            }

            int[] leftTreeInOrder = new int[rootIndex];
            Array.Copy(inorder, 0, leftTreeInOrder, 0, leftTreeInOrder.Length);

            int[] rightTreeInOrder = new int[inorder.Length - rootIndex - 1];
            Array.Copy(inorder, rootIndex + 1, rightTreeInOrder, 0, rightTreeInOrder.Length);

            int[] leftTreePreOrder = new int[leftTreeInOrder.Length];
            Array.Copy(preorder, 1, leftTreePreOrder, 0, leftTreePreOrder.Length);

            int[] rightTreePreOrder = new int[rightTreeInOrder.Length];
            Array.Copy(preorder, 1 + leftTreePreOrder.Length, rightTreePreOrder, 0, rightTreePreOrder.Length);

            root.left = BuildTree(leftTreePreOrder, leftTreeInOrder);
            root.right = BuildTree(rightTreePreOrder, rightTreeInOrder);

            return root;
        }
    }
}
