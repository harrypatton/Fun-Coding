using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _203RemoveLinkedListElements {
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
        public ListNode RemoveElements(ListNode head, int val) {
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
            head = dummyHead;

            while(head.next != null) {
                if (head.next.val == val) {
                    head.next = head.next.next;
                }
                else {
                    head = head.next;
                }
            }

            return dummyHead.next;
        }
    }
}
