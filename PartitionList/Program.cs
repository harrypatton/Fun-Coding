using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartitionList {
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

        public ListNode Partition(ListNode head, int x) {

            ListNode smallList = new ListNode(0);
            ListNode currentInSmallList = smallList;
            ListNode bigList = new ListNode(0);
            ListNode currentInBigList = bigList;

            while(head != null) {
                ListNode tempNode = head;
                head = head.next;
                tempNode.next = null;

                if(tempNode.val < x) {
                    currentInSmallList.next = tempNode;
                    currentInSmallList = tempNode;
                }
                else {
                    currentInBigList.next = tempNode;
                    currentInBigList = tempNode;
                }                
            }

            currentInSmallList.next = bigList.next;

            return smallList.next;
        }

    }
}
