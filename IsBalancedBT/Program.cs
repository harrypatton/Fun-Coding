using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBalancedBT {
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
        public bool IsBalanced(TreeNode root) {
            if (root == null) {
                return true;
            }

            Dictionary<TreeNode, int> cache = new Dictionary<TreeNode, int>();

            return IsBalanced(root.left) && IsBalanced(root.right) 
                && Math.Abs(GetDepth(root.left, cache) - GetDepth(root.right, cache)) <= 1;
        }
        
        public int GetDepth(TreeNode root, Dictionary<TreeNode, int> cache) {

            // DO NOT cache the null result. 
            if (root == null) {
                return 0;
            }

            if (cache.ContainsKey(root)) {
                return cache[root];
            }
            
            int result = 1 + Math.Max(GetDepth(root.left, cache), GetDepth(root.right, cache));
            cache.Add(root, result);

            return result;
        }
    }
}
