using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeRightSideView {
    class Program {
        static void Main(string[] args) {

            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);

            n1.left = n2;
            n1.right = n3;
            n2.right = n5;
            n3.right = n4;

            var result = (new Solution()).RightSideView(n1);

        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public IList<int> RightSideView(TreeNode root) {
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            List<int> result = new List<int>();

            if (root == null) {
                return result;
            }

            nodes.Enqueue(root);

            while (nodes.Any()) {
                result.Add(nodes.Last().val);

                int count = nodes.Count;

                for(int i = 0; i < count; i++) {
                    var node = nodes.Dequeue();

                    if (node.left != null) {
                        nodes.Enqueue(node.left);
                    }

                    if (node.right != null) {
                        nodes.Enqueue(node.right);
                    }
                }
            }

            return result;
        }
    }
}
