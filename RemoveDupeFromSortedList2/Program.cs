using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDupeFromSortedList2 {
    class Program {
        static void Main(string[] args) {
        }
    }


    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution {
        public ListNode DeleteDuplicates(ListNode head) {

            if (head == null || head.next == null) {
                return head;
            }

            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;

            ListNode stableNode= dummyHead;            
            int value = stableNode.next.val;
            ListNode current = stableNode.next.next;

            while(current != null) {
                // same value as previous one. remove all nodes.
                if (current.val == value) {
                    stableNode.next = null;
                }
                else {
                    if (stableNode.next != null) {
                        stableNode = stableNode.next;
                    }

                    stableNode.next = current;
                    value = current.val;
                }

                current = current.next;
            }

            return dummyHead.next;
        }
    }
}
