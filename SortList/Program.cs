using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortList {
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
        public ListNode SortList(ListNode head) {

            // handle base
            if (head == null || head.next == null) {
                return head;
            }

            // find the middle
            ListNode slow = head;
            ListNode fast = head;

            while (fast.next != null && fast.next.next != null) {
                slow = slow.next;
                fast = fast.next.next;
            }

            // sort right halve.
            ListNode list2 = SortList(slow.next);

            // sort left halve.
            slow.next = null;
            ListNode list1 = SortList(head);

            return MergeSort(list1, list2);
        }

        public ListNode MergeSort(ListNode list1, ListNode list2) {
            // merge two list together by creating a new list
            ListNode dummyHead = new ListNode(0);
            ListNode node = dummyHead;

            while (list2 != null && list1 != null) {
                if (list2.val < list1.val) {
                    node.next = list2;
                    list2 = list2.next;
                    node = node.next;
                }
                else {
                    node.next = list1;
                    list1 = list1.next;
                    node = node.next;
                }
            }

            if (list1 == null && list2 == null) {
                node.next = null;
            }
            else {
                node.next = (list1 != null) ? list1 : list2;
            }

            return dummyHead.next;
        }

        public ListNode MergeSort2(ListNode list1, ListNode list2) {
            if (list1 == null) {
                return list2;
            }
            else if (list2 == null) {
                return list1;
            }

            ListNode dummyHead = new ListNode(0);
            dummyHead.next = list1;
            ListNode node = dummyHead;

            while(list2 != null && node.next != null) {
                if (list2.val < node.next.val) {
                    var tempNode = list2;
                    list2 = list2.next;

                    tempNode.next = node.next;
                    node.next = tempNode;
                    node = node.next;
                }
                else {
                    node = node.next;
                }
            }

            if (list2 != null) {
                node.next = list2;
            }

            return dummyHead.next;
        }
    }
}
