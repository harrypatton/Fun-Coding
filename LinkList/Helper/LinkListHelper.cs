using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList
{
    public class LinkListHelper
    {
        public static Node CreateLinkList(int[] values)
        {
            if (values == null)
            {
                return null;
            }

            Node dummyHead = new Node(0);
            Node tempNode = dummyHead;

            for (int i = 0; i < values.Length; i++)
            {
                Node newNode = new Node(values[i]);
                tempNode.AppendNode(newNode);
                tempNode = tempNode.Next;
            }

            return dummyHead.Next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="loopStartIndex">starts at 1.</param>
        /// <returns></returns>
        public static Node CreateLinkListWithLoop(int[] values, int loopStartIndex) {

            if (values == null) {
                return null;
            }

            Node dummyHead = new Node(0);
            Node tempNode = dummyHead;
            Node loopStartNode = null;

            for (int i = 0; i < values.Length; i++) {
                Node newNode = new Node(values[i]);
                tempNode.AppendNode(newNode);
                tempNode = newNode;

                if (loopStartIndex == i + 1) {
                    loopStartNode = newNode;
                }
            }

            tempNode.Next = loopStartNode;

            return dummyHead.Next;

        }

        public static bool IsEqual(Node head, int[] values)
        {
            int[] valuesInList = null;

            if (head != null)
            {
                List<int> tempValues = new List<int>();

                while(head != null)
                {
                    tempValues.Add(head.Value);
                    head = head.Next;
                }

                valuesInList = tempValues.ToArray();
            }

            return IsEqual(valuesInList, values);
        }

        public static bool IsEqual(int[] values1, int[] values2)
        {
            if (values1 == null || values2 == null)
            {
                return values1 == null && values2 == null;
            }

            return values1.SequenceEqual<int>(values2);
        }
    }
}
