using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeApp {

    public class BinaryTree {
        public Node Root { get; private set; }
        public static bool UseNewSolution { get; set; }
        
        public BinaryTree(Node root) {
            this.Root = root;
        }

        public bool IsBalanced {
            get {
                if (UseNewSolution) {
                    return this.IsBalancedHelper2(this.Root);
                }
                else {
                    return this.IsBalancedHelper(this.Root);
                }                
            }
        }

        public int Depth {
            get {
                return this.GetDepth(this.Root);
            }
        }

        public static Node[] InOrderTraverseRecursively(Node node) {

            if (node == null) {
                return null;
            }

            List<Node> nodeList = new List<Node>();

            if (node.LeftChild != null) {
                nodeList.AddRange(InOrderTraverseRecursively(node.LeftChild));
            }

            nodeList.Add(node);

            if (node.RightChild != null) {
                nodeList.AddRange(InOrderTraverseRecursively(node.RightChild));
            }

            return nodeList.ToArray();            
        }

        public static Node[] InOrderTraverseNonRecursively(Node node) {

            if (node == null) {
                return null;
            }

            List<Node> nodeList = new List<Node>();
            Stack<Node> s = new Stack<Node>();
            PushNodeAndLeftNodes(node, s);

            while (s.Any()) {
                Node currentNode = s.Pop();
                nodeList.Add(currentNode);

                if (currentNode.RightChild != null) {
                    PushNodeAndLeftNodes(currentNode.RightChild, s);
                }
            }

            return nodeList.ToArray();
        }

        private static void PushNodeAndLeftNodes(Node node, Stack<Node> s) {
            while(node != null) {
                s.Push(node);
                node = node.LeftChild;
            }
        }

        private bool IsBalancedHelper(Node node) {
            if (node == null) {
                return true;
            }

            int leftSubTreeDepth = this.GetDepth(node.LeftChild);
            int rightSubTreeDepth = this.GetDepth(node.RightChild);

            return Math.Abs(leftSubTreeDepth - rightSubTreeDepth) <= 1
                && this.IsBalancedHelper(node.LeftChild)
                && this.IsBalancedHelper(node.RightChild);
        }

        private int GetDepth(Node node) {
            if (node == null) {
                return 0;
            }

            if (node.LeftChild == null && node.RightChild == null) {
                return 1;
            }

            return 1 + Math.Max(GetDepth(node.LeftChild), GetDepth(node.RightChild));
        }

        private bool IsBalancedHelper2(Node node) {
            if (GetDepth2(node) == -1) {
                return false;
            }
            else {
                return true;
            }
        }

        private int GetDepth2(Node node) {
            if (node == null) {
                return 0;
            }

            if (node.LeftChild == null && node.RightChild == null) {
                return 1;
            }

            int leftChildDepth = GetDepth2(node.LeftChild);

            if (leftChildDepth == -1) {
                return -1;
            }

            int rightChildDepth = GetDepth2(node.RightChild);

            if (rightChildDepth == -1) {
                return -1;
            }

            if (Math.Abs(leftChildDepth - rightChildDepth) > 1) {
                return -1;
            }
            else {
                return 1 + Math.Max(leftChildDepth, rightChildDepth);
            }            
        }
    }
}
