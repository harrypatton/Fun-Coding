using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeApp;

namespace BinaryTreeTest {
    [TestClass]
    public class BalancedTreeTest {
        [ClassInitialize]
        public static void Init(TestContext context) {
            BinaryTree.UseNewSolution = true;
        }

        [TestMethod]
        public void EmptyTreeTest() {
            BinaryTree bt = new BinaryTree(null);
            Assert.IsTrue(bt.IsBalanced);
        }

        [TestMethod]
        public void BalancedTreeTest1() {
            Node node = new Node(1);
            BinaryTree bt = new BinaryTree(node);
            Assert.IsTrue(bt.IsBalanced);
        }

        [TestMethod]
        public void BalancedTreeTest2() {

            // 0 -> 1, 2
            // 1 -> 3, 4
            // 4 -> 6, x
            // 2 -> x, 5

            Node[] nodes = new Node[7];
            for (int i = 0; i < nodes.Length; i ++) {
                nodes[i] = new Node(i);
            }

            nodes[0].UpdateChilds(nodes[1], nodes[2]);
            nodes[1].UpdateChilds(nodes[3], nodes[4]);
            nodes[4].UpdateChilds(nodes[6], null);
            nodes[2].UpdateChilds(null, nodes[5]);

            BinaryTree bt = new BinaryTree(nodes[0]);
            Assert.IsTrue(bt.IsBalanced);
        }

        [TestMethod]
        public void UnbalancedTreeTest1() {
            // 0 -> 1, x
            // 1 -> x, 2

            Node[] nodes = new Node[3];
            for (int i = 0; i < nodes.Length; i++) {
                nodes[i] = new Node(i);
            }

            nodes[0].UpdateChilds(nodes[1], null);
            nodes[1].UpdateChilds(null, nodes[2]);

            BinaryTree bt = new BinaryTree(nodes[0]);
            Assert.IsFalse(bt.IsBalanced);
        }

        [TestMethod]
        public void UnbalancedTreeTest2() {
            // 0 -> 1, 2
            // 1 -> 3, 4
            // 4 -> 6, x
            // 6 -> x, 7
            // 2 -> x, 5

            Node[] nodes = new Node[8];
            for (int i = 0; i < nodes.Length; i++) {
                nodes[i] = new Node(i);
            }

            nodes[0].UpdateChilds(nodes[1], nodes[2]);
            nodes[1].UpdateChilds(nodes[3], nodes[4]);
            nodes[4].UpdateChilds(nodes[6], null);
            nodes[6].UpdateChilds(null, nodes[7]);
            nodes[2].UpdateChilds(null, nodes[5]);

            BinaryTree bt = new BinaryTree(nodes[0]);
            Assert.IsFalse(bt.IsBalanced);
        }

        [TestMethod]
        public void UnbalancedTreeTest3() {
            // 0 -> 1, 2
            // 1 -> 3, x
            // 3 -> 5, x
            // 2 -> x, 4

            Node[] nodes = new Node[6];
            for (int i = 0; i < nodes.Length; i++) {
                nodes[i] = new Node(i);
            }

            nodes[0].UpdateChilds(nodes[1], nodes[2]);
            nodes[1].UpdateChilds(nodes[3], null);
            nodes[3].UpdateChilds(nodes[5], null);
            nodes[2].UpdateChilds(null, nodes[4]);

            BinaryTree bt = new BinaryTree(nodes[0]);
            Assert.IsFalse(bt.IsBalanced);
        }
    }
}
