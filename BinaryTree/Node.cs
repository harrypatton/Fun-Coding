using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeApp
{
    public class Node
    {
        public int Value { get; private set; }

        public Node LeftChild { get; private set; }

        public Node RightChild { get; private set; }

        public Node(int value) : this(value, null, null) {            
        }

        public Node(int value, Node leftChild, Node rightChild) {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public void UpdateChilds(Node leftChild, Node rightChild) {
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }
    }
}
