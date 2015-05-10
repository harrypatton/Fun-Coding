using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue {

    public class StackWithMinValue {
        private Stack<int> _internalStack;
        private Stack<int> _minValueStack;

        public StackWithMinValue() {
            _internalStack = new Stack<int>();
            _minValueStack = new Stack<int>();
        }

        public StackElementValue Pop() {
            if (!_internalStack.Any()) {
                throw new InvalidOperationException();
            }

            int value = _internalStack.Pop();
            int minValue = _minValueStack.Peek();

            if (value == minValue) {
                _minValueStack.Pop();
            }

            return new StackElementValue(value, minValue);
        }

        public void Push(int value) {

            _internalStack.Push(value);

            if (!_minValueStack.Any()) {
                _minValueStack.Push(value);
            } else {
                int currentMinValue = _minValueStack.Peek();

                if (value <= currentMinValue) {
                    _minValueStack.Push(value);
                }
            }
        }
    }

    public struct StackElementValue {
        public int value;
        public int minValue;

        public StackElementValue(int pValue, int pMinValue) {
            value = pValue;
            minValue = pMinValue;
        }
    }

}
