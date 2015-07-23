using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList2 {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = null;

            var result = s.ReverseBetween(node1, 2, 4);
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution {
        public ListNode ReverseBetween(ListNode head, int m, int n) {
            
            if (head == null || head.next == null) {
                return head;
            }

            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
            ListNode current = dummyHead;
            int counter = 0;

            // find the mth element
            while(current.next != null && counter < m) {
                counter++;

                // move current to mth element until we found the mth element.
                if (counter < m) {
                    current = current.next;
                }                
            }

            // not enough elements
            if (counter < m) {
                return head;
            }

            ListNode reversedDummyHead = new ListNode(0);
            ListNode lastNodeInReversedList = null;
            ListNode nodeBeforeReverse = current;

            counter = 0;

            while(current.next != null && counter < n - m + 1) {
                counter++;

                ListNode tempNode = current.next;
                current.next = current.next.next;

                tempNode.next = reversedDummyHead.next;
                reversedDummyHead.next = tempNode;

                if(lastNodeInReversedList == null) {
                    lastNodeInReversedList = tempNode;
                }
            }

            lastNodeInReversedList.next = current.next;
            nodeBeforeReverse.next = reversedDummyHead.next;

            return dummyHead.next;
        }
    }

}
