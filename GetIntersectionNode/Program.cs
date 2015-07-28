using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIntersectionNode {
    class Program {
        static void Main(string[] args) {
            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(3);
            n1.next = n2;
            n3.next = n2;

            var result = (new Solution()).GetIntersectionNode(n1, n3);
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {

            if (headA == null || headB == null) {
                return null;
            }

            // link two lists together
            ListNode node = headA;

            while (node.next != null) {
                node = node.next;
            }

            ListNode tailNode = node;
            node.next = headB;

            // need to find the first circle point
            ListNode slow = headA;
            ListNode fast = headA;

            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast) {
                    break;
                }
            }

            if (slow != fast) {
                // restore two lists structure
                tailNode.next = null;
                return null;
            }

            // now the two pointers meet. 
            // slow goes back to the beginning, and both go one step each time. when they're meet, it is the cycle start point.
            slow = headA;

            while (slow != fast) {
                slow = slow.next;
                fast = fast.next;
            }

            // restore two lists structure
            tailNode.next = null;

            return slow;
        }
    }
}
