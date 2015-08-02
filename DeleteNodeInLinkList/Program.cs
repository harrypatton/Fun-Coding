using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteNodeInLinkList {
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
        public void DeleteNode(ListNode node) {

            if (node != null && node.next != null) {
                node.val = node.next.val;
                node.next = node.next.next;
            }            
        }
    }
}
