using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListCycle {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int x) {
         val = x;
         next = null;
     }
 }
 
    public class Solution {
        public bool HasCycle(ListNode head) {
            if (head == null) {
                return false;
            }

            ListNode slow = head;
            ListNode fast = head.next;

            while(fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast) {
                    return true;
                }
            }

            return false;
        }
    }
}
