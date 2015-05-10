using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList
{
    public class RemoveDupes
    {
        public static void RemoveDuplications(Node head)
        {
            if (head == null || head.Next == null)
            {
                return;
            }

            Node p = head;

            while (p!= null)
            {
                Node q = p;

                while(q.Next !=null)
                {
                    if (q.Next.Value == p.Value)
                    {
                        q.Next = q.Next.Next;
                    }
                    else
                    {
                        q = q.Next;
                    }
                }

                p = p.Next;
            }
        }
    }
}
