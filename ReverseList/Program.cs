using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseList {
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
        public ListNode ReverseList(ListNode head) {
            ListNode dummyHead = new ListNode(0);

            while(head != null) {
                var tempNode = head;
                head = head.next;

                tempNode.next = dummyHead.next;
                dummyHead.next = tempNode;
            }

            return dummyHead.next;
        }
    }
}
