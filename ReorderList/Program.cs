using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderList {
    class Program {
        static void Main(string[] args) {
            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(3);

            n1.next = n2;
            n2.next = n3;

            (new Solution()).ReorderList(n1);
        }
    }
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    
    public class Solution {
        public void ReorderList(ListNode head) {

            if (head == null || head.next == null) {
                return;
            }

            ListNode slow = head;
            ListNode fast = head;

            while(fast.next != null && fast.next.next != null) {
                slow = slow.next;
                fast = fast.next.next;
            }

            // create two list.
            // this one is going to be reversed.
            ListNode dummyHead2 = new ListNode(0);
            dummyHead2.next = slow.next;

            // this one is in order.
            ListNode dummyHead1 = new ListNode(0);
            slow.next = null;
            dummyHead1.next = head;

            ListNode node = dummyHead2.next;

            // reset the list to be reversed.
            dummyHead2.next = null;

            // reverse the second list
            while(node != null) {
                var addedNode = node;
                node = node.next;

                addedNode.next = dummyHead2.next;
                dummyHead2.next = addedNode;
            }            

            // merge two lists
            var node1 = dummyHead1.next;
            var node2 = dummyHead2.next;

            while(node1 != null && node2 != null) {
                var tempNode = node2;
                node2 = node2.next;

                tempNode.next = node1.next;
                node1.next = tempNode;
                node1 = node1.next.next;
            }            
        }
    }
}
