using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue {

    public class CircularQueue {

        private int[] _valueArray = null;
        private int _length;
        private int _first;
        private int _last;

        public CircularQueue(int capacity) {
            if (capacity <= 0) {
                throw new ArgumentException();
            }

            _length = capacity;
            _valueArray = new int[_length];
            _first = -1;
            _last = -1;
        }

        public void Enqueue(int value) {
            if (_first == -1) {
                _first = _length - 1;
                _last = _first;
                _valueArray[_first] = value;
            }
            else {
                _last = _last - 1;

                if (_last == -1) {
                    _last = _length - 1;
                }

                if (_first == _last) {
                    throw new QueueFullException();
                }
                else {
                    _valueArray[_last] = value;
                }
            }
        }

        public int Dequeue() {
            if (_last == -1) {
                throw new QueueEmptyException();
            }

            int value = _valueArray[_first];

            if (_first == _last) {
                _first = -1;
                _last = -1;
            }
            else {                
                _first--;

                if (_first == -1) {
                    _first = _length - 1;
                }
            }

            return value;
        }

        public int Count {
            get {
                if (_first == -1) {
                    return 0;
                }
                else {
                    return _first - _last + 1;
                }                
            }
        }
    }

    public class QueueEmptyException : Exception {

    }

    public class QueueFullException : Exception {

    }
}
