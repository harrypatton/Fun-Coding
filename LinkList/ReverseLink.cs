using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList {
    public class ReverseLink {

        public static Node Reverse(Node head) {
            Node reversedNode = null;
            Node current = head;

            while (current != null) {
                Node next = current.Next;
                current.Next = reversedNode;
                reversedNode = current;
                current = next;
            }

            return reversedNode;
        }
    }
}
