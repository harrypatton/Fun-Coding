using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumRootToLeafNumbers {
    class Program {
        static void Main(string[] args) {
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);

            n1.left = n2;
            n1.right = n3;

            Solution s = new Solution();
            var result = s.SumNumbers(n1);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public int SumNumbers(TreeNode root) {
            if (root == null) {
                return 0;
            }

            List<int> parentResults = new List<int>(new int[1] { root.val });
            List<TreeNode> parentNodes = new List<TreeNode>();
            List<int> leavesResults = new List<int>();
            parentNodes.Add(root);

            while (true) {
                // find next level of childs and also calculate the sum.
                List<TreeNode> nodes = new List<TreeNode>();
                List<int> results = new List<int>();
                int indexInParentResults = 0;

                foreach(var parentNode in parentNodes) {
                    // handle parent which has children.
                    if (parentNode.left != null || parentNode.right != null) {                        
                        foreach (var child in new TreeNode[] { parentNode.left, parentNode.right }) {
                            if (child != null) {
                                nodes.Add(child);
                                results.Add(parentResults[indexInParentResults] * 10 + child.val);
                            }
                        }
                    }
                    else { // this is leaf node. save the result.
                        leavesResults.Add(parentResults[indexInParentResults]);
                    }

                    indexInParentResults++;
                }

                if (!nodes.Any()) {
                    break; // no more child found. exit the loop.
                }

                parentNodes = nodes;
                parentResults = results;
            }

            return leavesResults.Sum();
        }
    }
}
