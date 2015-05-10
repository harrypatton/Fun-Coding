using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkList;

namespace LinkListTest {

    [TestClass]
    public class FindLoopStartPointTest {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTest() {
            Node head = null;
            FindLoopStartPoint.GetLoopStartPoint(head);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NoLoopLinkTestTest() {
            Node head = LinkListHelper.CreateLinkList(new int[] { 1, 2, 3, 4 });
            FindLoopStartPoint.GetLoopStartPoint(head);
        }

        [TestMethod]
        public void Test1() {
            Node head = LinkListHelper.CreateLinkListWithLoop(new int[] { 1 }, 1);
            Node startPoint = FindLoopStartPoint.GetLoopStartPoint(head);
            Assert.AreEqual<int>(1, startPoint.Value);
        }

        [TestMethod]
        public void Test2() {
            Node head = LinkListHelper.CreateLinkListWithLoop(new int[] { 1, 2 }, 2);
            Node startPoint = FindLoopStartPoint.GetLoopStartPoint(head);
            Assert.AreEqual<int>(2, startPoint.Value);
        }

        [TestMethod]
        public void Test3() {
            Node head = LinkListHelper.CreateLinkListWithLoop(new int[] { 1, 2, 3 }, 2);
            Node startPoint = FindLoopStartPoint.GetLoopStartPoint(head);
            Assert.AreEqual<int>(2, startPoint.Value);
        }

        [TestMethod]
        public void Test4() {
            Node head = LinkListHelper.CreateLinkListWithLoop(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 6);
            Node startPoint = FindLoopStartPoint.GetLoopStartPoint(head);
            Assert.AreEqual<int>(6, startPoint.Value);
        }

        [TestMethod]
        public void Test5() {
            Node head = LinkListHelper.CreateLinkListWithLoop(new int[] { 1, 2, 3, 4, 5, 6 }, 3);
            Node startPoint = FindLoopStartPoint.GetLoopStartPoint(head);
            Assert.AreEqual<int>(3, startPoint.Value);
        }
    }
}
