using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertSortedListToBST {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public TreeNode SortedListToBST(ListNode head) {

            // check condition.
            if (head == null) {
                return null;
            }

            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;

            ListNode nodePriorMiddle = dummyHead;
            ListNode nodeDoubleSteps = head;

            // use two pointers to find the middle.
            // every time pointer 1 moves 1 step, and pointer 2 moves 2 steps.
            // when pointer2.next == null or pointer2.next.next == null, pointer1 points to the element prior to middle.
            while(nodeDoubleSteps.next != null && nodeDoubleSteps.next.next != null) {
                nodeDoubleSteps = nodeDoubleSteps.next.next;
                nodePriorMiddle = nodePriorMiddle.next;
            }

            TreeNode root = new TreeNode(nodePriorMiddle.next.val);
            ListNode rightTreeHead = nodePriorMiddle.next.next;
            nodePriorMiddle.next = null;

            root.left = SortedListToBST(dummyHead.next);
            root.right = SortedListToBST(rightTreeHead);

            return root;
        }
    }
}
