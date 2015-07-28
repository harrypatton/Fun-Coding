using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortList {
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
        public ListNode InsertionSortList(ListNode head) {
            if (head == null || head.next == null) {
                return head;
            }

            ListNode dummyHead = new ListNode(0);

            while (head != null) {
                var tempNode = head;
                head = head.next;

                ListNode node = dummyHead;
                while(node.next != null && node.next.val <= tempNode.val) {
                    node = node.next;
                }

                tempNode.next = node.next;
                node.next = tempNode;
            }

            return dummyHead.next;
        }
    }
}
