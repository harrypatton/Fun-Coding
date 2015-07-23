using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLevelOrderTraversal2 {
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
        public IList<IList<int>> LevelOrderBottom(TreeNode root) {
            List<IList<int>> result = new List<IList<int>>();

            if (root == null) {
                return result;
            }

            List<TreeNode> currentLevel = new List<TreeNode>();
            currentLevel.Add(root);

            while (currentLevel.Any()) {
                List<int> currentLevelValue = currentLevel.Where(item => item != null).Select(item => item.val).ToList<int>();
                result.Add(currentLevelValue);

                var nextLevel = new List<TreeNode>();

                foreach (TreeNode node in currentLevel) {
                    if (node != null && node.left != null) {
                        nextLevel.Add(node.left);
                    }

                    if (node != null && node.right != null) {
                        nextLevel.Add(node.right);
                    }
                }

                currentLevel = nextLevel;
            }

            result.Reverse();
            return result;
        }
    }
}
