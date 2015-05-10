using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace LinkList {

    public class FindLoopStartPoint {

        public static Node GetLoopStartPoint(Node head) {
            if (head == null) {
                throw new ArgumentNullException();
            }

            Node slow = head;
            Node fast = head;

            do {
                if (slow.Next == null || fast.Next == null || fast.Next.Next == null) {
                    throw new ArgumentOutOfRangeException("The link doesn't have a loop.");
                }

                slow = slow.Next;
                fast = fast.Next.Next;
            }
            while (slow != fast);

            slow = head;
            while(slow != fast) {
                slow = slow.Next;
                fast = fast.Next;
            }

            return fast;
        }
    }
}
