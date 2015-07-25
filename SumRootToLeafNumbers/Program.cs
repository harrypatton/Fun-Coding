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

            List<int> result = new List<int>(new int[1] { root.val });
            List<TreeNode> parentNodes = new List<TreeNode>();
            parentNodes.Add(root);

            while (true) {
                // find next level of childs and also calculate the sum.
                List<TreeNode> nodes = new List<TreeNode>();
                List<int> sums = new List<int>();
                int indexInSum = 0;

                foreach(var parentNode in parentNodes) {
                    // handle parent which has children.
                    if (parentNode.left != null || parentNode.right != null) {                        
                        foreach (var child in new TreeNode[] { parentNode.left, parentNode.right }) {
                            if (child != null) {
                                nodes.Add(child);
                                sums.Add(result[indexInSum] * 10 + child.val);
                            }
                        }

                        indexInSum++;
                    }
                }

                // we need to add these leaves to the end so next iteration can find parent value using index.
                foreach (var parentNode in parentNodes) {
                    // handle parent without children later.
                    if (parentNode.left == null && parentNode.right == null) {
                        sums.Add(result[indexInSum]);
                        indexInSum++;
                    }                    
                }

                if (!nodes.Any()) {
                    break; // no more child found. exit the loop.
                }

                parentNodes = nodes;
                result = sums;
            }

            return result.Sum();
        }
    }
}
