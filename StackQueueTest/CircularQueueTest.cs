using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackQueue;

namespace StackQueueTest {

    [TestClass]
    public class CircularQueueTest {

        [TestMethod]
        public void ValidSingleElementQueue() {
            CircularQueue queue = new CircularQueue(1);

            for(int i = 0; i < 3; i ++) {
                queue.Enqueue(i);
                int value = queue.Dequeue();
                Assert.AreEqual<int>(i, value);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(QueueFullException))]
        public void QueueFullTest1() {
            CircularQueue queue = new CircularQueue(1);
            queue.Enqueue(1);
            queue.Enqueue(2);
        }

        [TestMethod]
        [ExpectedException(typeof(QueueFullException))]
        public void QueueFullTest2() {
            CircularQueue queue = new CircularQueue(3);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Dequeue();

            for(int i = 0; i < 4; i ++) {
                queue.Enqueue(i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(QueueEmptyException))]
        public void QueueEmptyTest1() {
            CircularQueue queue = new CircularQueue(1);
            queue.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(QueueEmptyException))]
        public void QueueEmptyTest2() {
            CircularQueue queue = new CircularQueue(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
        }

        [TestMethod]
        public void ValidQueueTest1() {
            CircularQueue queue = new CircularQueue(4);

            for (int i = 0; i < 20; i++) {
                queue.Enqueue(i);
                int value = queue.Dequeue();
                Assert.AreEqual<int>(i, value);
            }
        }

        [TestMethod]
        public void ValidQueueTest2() {
            CircularQueue queue = new CircularQueue(4);
            int value = 0;

            for (int i = 0; i < 4; i++) {
                queue.Enqueue(i);
            }

            value = queue.Dequeue();
            Assert.AreEqual<int>(0, value);

            queue.Enqueue(4);
            value = queue.Dequeue();
            Assert.AreEqual<int>(1, value);

            queue.Enqueue(5);
            Assert.AreEqual<int>(2, queue.Dequeue());
            Assert.AreEqual<int>(3, queue.Dequeue());
            Assert.AreEqual<int>(4, queue.Dequeue());
            Assert.AreEqual<int>(5, queue.Dequeue());
        }
    }
}
