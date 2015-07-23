using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelOrder {
    class Program {
        static void Main(string[] args) {
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);

            n1.left = n2;
            n1.right = n3;
            n2.left = n4;
            n2.right = n5;

            Solution s = new Solution();
            var result = s.LevelOrder(n1);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public IList<IList<int>> LevelOrder(TreeNode root) {
            List<IList<int>> result = new List<IList<int>>();

            if (root == null) {
                return result;
            }

            List<TreeNode> currentLevel = new List<TreeNode>();
            currentLevel.Add(root);
            
            while(currentLevel.Any()) {
                List<int> currentLevelValue = currentLevel.Where(item => item != null).Select(item => item.val).ToList<int>();
                result.Add(currentLevelValue);

                var nextLevel = new List<TreeNode>();

                foreach(TreeNode node in currentLevel) {
                    if (node != null && node.left != null) {
                        nextLevel.Add(node.left);
                    }

                    if (node != null && node.right != null) {
                        nextLevel.Add(node.right);
                    }
                }

                currentLevel = nextLevel;
            }

            return result;
        }
    }
}
