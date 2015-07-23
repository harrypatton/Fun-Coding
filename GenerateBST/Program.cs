using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBST {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();
            var result = s.GenerateTrees(3);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }        
    }

    public class Solution {

        public struct Range {
            public int start;
            public int end;

            public Range(int startValue, int endValue) {
                start = startValue;
                end = endValue;
            }
        }

        public IList<TreeNode> GenerateTrees(int n) {
            Range range = new Range(1, n);
            Dictionary<Range, IList<TreeNode>> cache = new Dictionary<Range, IList<TreeNode>>();

            return GenerateTrees(range, cache);
        }

        public IList<TreeNode> GenerateTrees(Range range, Dictionary<Range, IList<TreeNode>> cache) {
            
            if (cache.ContainsKey(range)) {
                return cache[range];
            }

            IList<TreeNode> result = new List<TreeNode>();
            TreeNode rootNode = null;

            if (range.end - range.start + 1 <= 0) {
                rootNode = null;
                result.Add(rootNode);
            }
            else if (range.end == range.start) {
                rootNode = new TreeNode(range.start);
                result.Add(rootNode);
            }
            else {
                // each number could be root.
                for (int i = range.start; i <= range.end; i++) {
                    IList<TreeNode> leftChilds = GenerateTrees(new Range(range.start, i - 1), cache);
                    IList<TreeNode> rightChilds = GenerateTrees(new Range(i + 1, range.end), cache);

                    // combine all possibilities
                    foreach (TreeNode leftChildNode in leftChilds) {
                        foreach (TreeNode rightChildNode in rightChilds) {
                            rootNode = new TreeNode(i);
                            rootNode.left = CloneTreeNode(leftChildNode);
                            rootNode.right = CloneTreeNode(rightChildNode);
                            result.Add(rootNode);
                        }
                    }
                }
            }
            
            // add to cache
            cache.Add(range, result);

            return result;
        }

        public TreeNode CloneTreeNode(TreeNode node) {
            if (node == null) {
                return node;
            }

            TreeNode newNode = new TreeNode(node.val);
            newNode.left = CloneTreeNode(node.left);
            newNode.right = CloneTreeNode(node.right);

            return newNode;
        }
    }
}
