using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value) : this(value, null)
        {
        }

        public Node(int value, Node next)
        {
            this.Value = value;
            this.Next = next;
        }

        public void AppendNode(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node", "Cannot add a null node.");
            }

            Node tempNode = this.Next;
            this.Next = node;
            node.Next = tempNode;
        }
    }
}
