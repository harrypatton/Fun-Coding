using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvertBinaryTree {
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

        /// <summary>
        /// DFS - iteration
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertTree(TreeNode root) {
            if (root == null) {
                return root;
            }

            TreeNode result = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (root != null || stack.Any()) {
                while(root != null) {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                var tempNode = root;

                root = root.right;

                // swap left and right after we update the variable root.
                TreeNode temp = tempNode.left;
                tempNode.left = tempNode.right;
                tempNode.right = temp;
            }            

            return result;
        }

        public TreeNode InvertTree_BFS(TreeNode root) {
            if (root == null) {
                return root;
            }

            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);

            while (nodes.Any()) {
                var node = nodes.Dequeue();

                TreeNode temp = node.left;
                node.left = node.right;
                node.right = temp;

                if (node.left != null) {
                    nodes.Enqueue(node.left);
                }

                if (node.right != null) {
                    nodes.Enqueue(node.right);
                }
            }

            return root;
        }

        public TreeNode InvertTree_DFS_Recursive(TreeNode root) {
            if (root == null) {
                return root;
            }
            
            TreeNode temp = InvertTree(root.left);
            root.left = InvertTree(root.right);
            root.right = temp;

            return root;
        }
    }
}
