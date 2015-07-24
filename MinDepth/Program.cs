using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinDepth {
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
        public int MinDepth(TreeNode root) {
            if (root == null) {
                return 0;
            }

            if (root.left == null && root.right == null) {
                return 1;
            }
            else if (root.left == null) {
                return 1 + MinDepth(root.right);
            }
            else if (root.right == null) {
                return 1 + MinDepth(root.left);
            }
            else {
                return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
            }            
        }
    }
}
