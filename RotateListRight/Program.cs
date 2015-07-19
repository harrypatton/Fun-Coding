using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateListRight
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k <= 0)
            {
                return head;
            }

            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;

            ListNode p = dummyHead;
            ListNode q = p;
            int length = 0;

            // move q k steps forward.
            for (int i = 0; i < k; i ++)
            {
                if (q == null || q.next == null)
                {
                    // Leetcode doesn't want exception. it rotates back. say, length is 2, k = 3, so it is the same as k == 1.
                    // throw new ArgumentException("k is too big");
                    q = p;

                    // update k to quite the loop early.
                    i = 0;
                    k = k % length;
                    length = 0;

                    if (k == 0)
                    {
                        return head;
                    }
                }

                length++;
                q = q.next;
            }            

            // edge scenario
            if (q.next == null)
            {
                return head;
            }

            // normal scenario
            while(q.next != null)
            {
                p = p.next;
                q = q.next;
            }

            head = p.next;
            q.next = dummyHead.next;
            p.next = null;

            return head;
        }
    }
}
