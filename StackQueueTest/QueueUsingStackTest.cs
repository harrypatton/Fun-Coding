using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackQueue;

namespace StackQueueTest {

    [TestClass]
    public class QueueUsingStackTest {

        [TestMethod]
        [ExpectedException(typeof(QueueEmptyException))]
        public void EmptyQueueTest() {
            QueueUsingStack q = new QueueUsingStack();
            q.Enqueue(1);

            q.Dequeue();
            q.Dequeue();
        }

        [TestMethod]
        public void ValidQueueTest1() {
            QueueUsingStack q = new QueueUsingStack();

            for(int i = 0; i < 5; i ++) {
                q.Enqueue(i);
                int value = q.Dequeue();
                Assert.AreEqual<int>(i, value);
            }
        }

        [TestMethod]
        public void ValidQueueTest2() {
            QueueUsingStack q = new QueueUsingStack();

            for (int i = 0; i < 5; i++) {
                q.Enqueue(i);
            }

            for (int i = 0; i < 5; i++) {
                int value = q.Dequeue();
                Assert.AreEqual<int>(i, value);
            }
        }

        [TestMethod]
        public void ValidQueueTest3() {
            QueueUsingStack q = new QueueUsingStack();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Assert.AreEqual<int>(1, q.Dequeue());

            q.Enqueue(4);
            q.Enqueue(5);

            Assert.AreEqual<int>(2, q.Dequeue());
            Assert.AreEqual<int>(3, q.Dequeue());
            Assert.AreEqual<int>(4, q.Dequeue());

            q.Enqueue(6);
            Assert.AreEqual<int>(5, q.Dequeue());
        }
    }
}
