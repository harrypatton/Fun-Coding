using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackQueue;

namespace StackQueueTest {

    [TestClass]
    public class StackWithMinValueTest {

        [TestMethod]
        public void Test1() {

            StackWithMinValue stack = new StackWithMinValue();
            stack.Push(5);
            stack.Push(2);
            stack.Push(3);
            stack.Push(1);
            stack.Push(1);

            StackElementValue value = stack.Pop();
            Assert.AreEqual<int>(1, value.value);
            Assert.AreEqual<int>(1, value.minValue);

            value = stack.Pop();
            Assert.AreEqual<int>(1, value.value);
            Assert.AreEqual<int>(1, value.minValue);

            value = stack.Pop();
            Assert.AreEqual<int>(3, value.value);
            Assert.AreEqual<int>(2, value.minValue);

            value = stack.Pop();
            Assert.AreEqual<int>(2, value.value);
            Assert.AreEqual<int>(2, value.minValue);

            value = stack.Pop();
            Assert.AreEqual<int>(5, value.value);
            Assert.AreEqual<int>(5, value.minValue);
        }

        [TestMethod]
        public void Test2() {

            StackWithMinValue stack = new StackWithMinValue();
            stack.Push(1);

            StackElementValue value = stack.Pop();
            Assert.AreEqual<int>(1, value.value);
            Assert.AreEqual<int>(1, value.minValue);
        }

        [TestMethod]
        public void Test3() {

            StackWithMinValue stack = new StackWithMinValue();
            stack.Push(1);
            stack.Push(1);

            StackElementValue value = stack.Pop();
            Assert.AreEqual<int>(1, value.value);
            Assert.AreEqual<int>(1, value.minValue);

            value = stack.Pop();
            Assert.AreEqual<int>(1, value.value);
            Assert.AreEqual<int>(1, value.minValue);
        }

        [TestMethod]
        public void Test4() {

            StackWithMinValue stack = new StackWithMinValue();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            StackElementValue value = stack.Pop();
            Assert.AreEqual<int>(3, value.value);
            Assert.AreEqual<int>(1, value.minValue);

            value = stack.Pop();
            Assert.AreEqual<int>(2, value.value);
            Assert.AreEqual<int>(1, value.minValue);

            value = stack.Pop();
            Assert.AreEqual<int>(1, value.value);
            Assert.AreEqual<int>(1, value.minValue);
        }

        [TestMethod]
        public void Test5() {

            StackWithMinValue stack = new StackWithMinValue();
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);

            StackElementValue value = stack.Pop();
            Assert.AreEqual<int>(1, value.value);
            Assert.AreEqual<int>(1, value.minValue);

            value = stack.Pop();
            Assert.AreEqual<int>(2, value.value);
            Assert.AreEqual<int>(2, value.minValue);

            value = stack.Pop();
            Assert.AreEqual<int>(3, value.value);
            Assert.AreEqual<int>(3, value.minValue);
        }
    }
}
