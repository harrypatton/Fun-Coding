using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList {
    public class PartitionList {
        public static Node DoPartition(Node head, int value) {
            if (head == null) {
                throw new ArgumentNullException("head");
            }

            Node leftStart = null, leftEnd = null, rightStart = null, rightEnd = null;
            Node current = head;

            while (current != null) {
                if (current.Value < value) {
                    if (leftStart == null) {
                        leftStart = current;
                    } else {
                        leftEnd.Next = current;
                    }

                    leftEnd = current;
                } else {
                    if (rightStart == null) {
                        rightStart = current;
                    } else {
                        rightEnd.Next = current;
                    }

                    rightEnd = current;
                }

                current = current.Next;
            }

            if (leftEnd != null) {
                leftEnd.Next = null;
            }

            if (rightEnd != null) {
                rightEnd.Next = null;
            }

            if (leftStart == null) {
                leftStart = rightStart;
            } else {
                leftEnd.Next = rightStart;
            }

            return leftStart;
        }
    }
}
