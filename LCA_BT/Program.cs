using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCA_BT {
    class Program {
        static void Main(string[] args) {
            TreeNode n0 = new TreeNode(0);
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);
            TreeNode n6 = new TreeNode(6);
            TreeNode n7 = new TreeNode(7);
            TreeNode n8 = new TreeNode(8);

            n3.left = n5;
            n3.right = n1;

            n5.left = n6;
            n5.right = n2;

            n2.left = n7;
            n2.right = n4;

            n1.left = n0;
            n1.right = n8;

            var result = (new Solution()).LowestCommonAncestor(n3, n7, n8);
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

            var path1 = GetPath(root, p);
            var path2 = GetPath(root, q);

            int index = 0;

            while (index < path1.Count && index < path2.Count && path1[index] == path2[index]) {
                index++;
            }

            return path1[index - 1];
        }

        public List<TreeNode> GetPath(TreeNode root, TreeNode p) {
            List<TreeNode> path = new List<TreeNode>();

            if (root == p) {
                path.Add(root);
            }
            else {
                if (root.left != null) {
                    var result = GetPath(root.left, p);

                    if (result.Any()) {
                        path.Add(root);
                        path.AddRange(result);

                        return path;
                    }
                }

                if (root.right != null) {
                    var result = GetPath(root.right, p);

                    if (result.Any()) {
                        path.Add(root);
                        path.AddRange(result);

                        return path;
                    }
                }
            }

            return path;
        }
    }
}
