using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingQueue {
    class Program {
        static void Main(string[] args) {
        }
    }

    public class Stack {

        private Queue<int> queue = new Queue<int>();

        // Push element x onto stack.
        public void Push(int x) {
            int size = queue.Count;
            queue.Enqueue(x);

            for(int i = 0; i < size; i++) {
                queue.Enqueue(queue.Dequeue());
            }
        }

        // Removes the element on top of the stack.
        public void Pop() {
            queue.Dequeue();
        }

        // Get the top element.
        public int Top() {
            return queue.Peek();
        }

        // Return whether the stack is empty.
        public bool Empty() {
            return !queue.Any();
        }
    }
}
