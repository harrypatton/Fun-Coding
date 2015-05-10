using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList
{
    public class FindNthToLastElement
    {
        public static Node Find(Node head, int nthToLast)
        {
            if (head == null)
            {
                throw new ArgumentNullException("head");
            }

            if (nthToLast <= 0)
            {
                throw new ArgumentException("must be 1 or greater number.", "nthToLast");
            }

            Node first = head;
            Node second = first;

            for (int i = 0; i < nthToLast - 1; i ++)
            {
                second = second.Next;

                if (second == null)
                {
                    throw new ArgumentException("cannot find nth element to the last.", "nthToLast");
                }
            }

            while(second.Next != null)
            {
                second = second.Next;
                first = first.Next;
            }

            return first;
        }
    }
}
