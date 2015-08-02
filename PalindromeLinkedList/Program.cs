using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeLinkedList {
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
        public bool IsPalindrome(ListNode head) {

            if (head == null) {
                return true;
            }
            
            if (head.next == null) {
                return true;
            }

            ListNode slow = head;
            ListNode fast = head;

            while(fast != null && fast.next != null && fast.next.next != null && fast.next.next.next != null) {
                slow = slow.next;
                fast = fast.next.next;
            }

            ListNode head2;

            if (fast.next.next == null) { //even number
                head2 = slow.next;
            }
            else { // odd number
                head2 = slow.next.next;                
            }

            slow.next = null;

            head2 = ReverseList(head2);

            return IsSameList(head, head2);
        }

        public bool IsSameList(ListNode head1, ListNode head2) {
            while(head1 != null && head2 != null) {
                if (head1.val != head2.val) {
                    return false;
                }
                else {
                    head1 = head1.next;
                    head2 = head2.next;
                }
            }

            return head1 == null && head2 == null;
        }

        public ListNode ReverseList(ListNode head) {
            ListNode dummyHead = new ListNode(0);
            ListNode node = head;

            while(node != null) {
                var temp = node;
                node = node.next;

                temp.next = dummyHead.next;
                dummyHead.next = temp;
            }

            return dummyHead.next;
        }
    }
}
