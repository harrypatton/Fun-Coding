using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSum {
    class Program {
        static void Main(string[] args) {
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);

            n1.left = n2;
            n1.right = n3;

            Solution s = new Solution();
            var result = s.PathSum(n1, 4);
        }
    }
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public bool HasPathSum(TreeNode root, int sum) {
            if (root == null) {
                return false;
            }

            if (root.left == null && root.right == null) {
                return root.val == sum;
            }
            else {
                return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
            }
        }

        public IList<IList<int>> PathSum(TreeNode root, int sum) {
            IList<IList<int>> result = new List<IList<int>>();
            FindPath(root, sum, new List<int>(), result);

            return result;
        }

        public void FindPath(TreeNode root, int sum, List<int> currentPath, IList<IList<int>> result) {
            // no found
            if (root == null) {
                return;
            }

            // this is a matched leaf node.
            if (root.left == null && root.right == null && root.val == sum) {
                List<int> finalPath = new List<int>(currentPath);
                finalPath.Add(root.val);
                result.Add(finalPath);
                return;
            }

            List<int> newCurrentPath = new List<int>(currentPath);
            newCurrentPath.Add(root.val);
            FindPath(root.left, sum - root.val, newCurrentPath, result);
            FindPath(root.right, sum - root.val, newCurrentPath, result);
        }
    }
}
