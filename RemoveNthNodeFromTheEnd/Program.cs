using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNthNodeFromTheEnd
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }



    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode first = new ListNode(0);
            first.next = head;

            ListNode second = first;
            int initialStepForSecond = n + 1;
            int count = 0;

            while(count < initialStepForSecond && second != null)
            {
                second = second.next;
                count++;
            }

            // there's no nth node from the end of list. the list is too short.
            if (count != initialStepForSecond)
            {
                return head;
            }

            while(second != null)
            {
                first = first.next;
                second = second.next;                
            }

            if (first.next == head)
            {
                head = head.next;
            }
            else
            {
                first.next = first.next.next;
            }            

            return head;
        }
    }
}
