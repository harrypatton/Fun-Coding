using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingStack {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Queue {

        private Stack<int> stack1 = new Stack<int>();
        private Stack<int> queue = new Stack<int>();

        // Push element x to the back of queue.
        public void Push(int x) {
            stack1.Push(x);
        }

        // Removes the element from front of queue.
        public void Pop() {
            Peek();
            queue.Pop();
        }

        // Get the front element.
        public int Peek() {
            if (!queue.Any()) {
                while (stack1.Any()) {
                    queue.Push(stack1.Pop());
                }
            }

            return queue.Peek();
        }

        // Return whether the queue is empty.
        public bool Empty() {
            return !stack1.Any() && !queue.Any();
        }
    }
}
