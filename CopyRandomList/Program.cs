using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyRandomList {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class RandomListNode {
        public int label;
        public RandomListNode next, random;
        public RandomListNode(int x) { this.label = x; }
    };

    public class Solution {
        public RandomListNode CopyRandomList(RandomListNode head) {
            if (head == null) {
                return head;
            }

            RandomListNode newHead = new RandomListNode(head.label);

            // save to cache
            Dictionary<RandomListNode, RandomListNode> cache = new Dictionary<RandomListNode, RandomListNode>();
            cache.Add(head, newHead);

            while(head != null) {

                foreach(var node in new RandomListNode[] { head, head.next, head.random }) {
                    if (node != null && !cache.ContainsKey(node)) {
                        cache.Add(node, new RandomListNode(node.label));
                    }
                }

                RandomListNode newNode = cache[head];
                newNode.next = head.next == null ? null : cache[head.next];
                newNode.random = head.random == null ? null : cache[head.random];

                head = head.next;
            }

            return newHead;
        }
    }
}
