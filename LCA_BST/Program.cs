using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCA_BST {
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
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null || p == null || q == null) {
                return null;
            }

            while(root != null) {
                if (p.val > root.val && q.val > root.val) {
                    root = root.right;
                }
                else if (p.val < root.val && q.val < root.val) {
                    root = root.left;
                }
                else if (p.val == root.val) {
                    return p;
                }
                else if (q.val == root.val) {
                    return q;
                }
                else {
                    return root;
                }
            }

            // not found.
            return null;
        }
    }
}
