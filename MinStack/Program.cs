using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinStack {
    class Program {
        static void Main(string[] args) {
            MinStack stack = new MinStack();
            stack.Push(2);
            stack.Push(0);
            stack.Push(3);
            stack.Push(0);

            stack.GetMin();
            stack.Pop();
            stack.GetMin();
            stack.Pop();
            stack.GetMin();
            stack.Pop();
            stack.GetMin();
        }
    }

    public class MinStack {
        private Stack<int> stack = new Stack<int>();
        private Stack<int> min = new Stack<int>();

        public void Push(int x) {
            stack.Push(x);
            min.Push((!min.Any() || x < min.Peek()) ? x : min.Peek());
        }

        public void Pop() {
            stack.Pop();
            min.Pop();
        }

        public int Top() {
            return stack.Peek();
        }

        public int GetMin() {
            return min.Peek();
        }
    }
}
