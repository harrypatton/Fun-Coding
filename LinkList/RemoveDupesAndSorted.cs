using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList
{
    public class RemoveDupesAndSorted
    {
        public static void RemoveDuplications(ref Node head)
        {
            if (head == null)
            {
                throw new ArgumentNullException();
            }

            Node newHead = null;

            while (head != null)
            {
                Node node = head;
                head = head.Next;
                node.Next = null;

                InsertUniqueNode2(ref newHead, node);
            }

            head = newHead;
        }

        private static void InsertUniqueNode(ref Node head, Node newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException();
            }

            if (head == null || head.Value > newNode.Value)
            {
                newNode.Next = head;
                head = newNode;
                return;
            }
            else if (head.Value == newNode.Value)
            {
                return;
            }

            Node p = head;

            while (p.Next != null)
            {
                if (p.Next.Value == newNode.Value)
                {
                    return;
                }
                else if (p.Next.Value > newNode.Value)
                {
                    newNode.Next = p.Next;
                    p.Next = newNode;
                    return;

                }
                else
                {
                    p = p.Next;
                }
            }

            if (p.Next == null)
            {
                p.Next = newNode;
                newNode.Next = null;
            }
        }

        private static void InsertUniqueNode2(ref Node head, Node newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException();
            }
            
            if (head == null || head.Value > newNode.Value)
            {
                newNode.Next = head;
                head = newNode;
                return;
            }
            else if (head.Value == newNode.Value)
            {
                return;
            }

            Node next = head.Next;
            InsertUniqueNode2(ref next, newNode);
            head.Next = next;
        }
    }
}
