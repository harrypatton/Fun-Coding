using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue {
    public class QueueUsingStack {

        private Stack<int> _in;
        private Stack<int> _out;

        public QueueUsingStack() {
            _in = new Stack<int>();
            _out = new Stack<int>();
        }

        public void Enqueue(int value) {
            _in.Push(value);
        }

        public int Dequeue() {
            if (!_in.Any() && !_out.Any()) {
                throw new QueueEmptyException();
            }

            if (!_out.Any()) {
                while(_in.Any()) {
                    _out.Push(_in.Pop());
                }
            }

            return _out.Pop();
        }
    }
}
