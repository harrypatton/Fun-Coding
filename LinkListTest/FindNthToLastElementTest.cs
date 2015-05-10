using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkList;

namespace LinkListTest
{
    [TestClass]
    public class FindNthToLastElementTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTest()
        {
            FindNthToLastElement.Find(null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidNTest1()
        {
            Node head = LinkListHelper.CreateLinkList(new int[] { 1 });
            FindNthToLastElement.Find(head, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidNTest2()
        {
            Node head = LinkListHelper.CreateLinkList(new int[] { 1, 2 });
            FindNthToLastElement.Find(head, 3);
        }

        [TestMethod]
        public void ValidTest1()
        {
            int[] values = new int[] { 1 };
            VerifyScenario(values, 1, 1);
        }

        [TestMethod]
        public void ValidTest2()
        {
            int[] values = new int[] { 1, 2 };
            VerifyScenario(values, 1, 2);
        }

        [TestMethod]
        public void ValidTest3()
        {
            int[] values = new int[] { 1, 2 };
            VerifyScenario(values, 2, 1);
        }

        [TestMethod]
        public void ValidTest4()
        {
            int[] values = new int[] { 1, 3, 5, 7, 11, 13 };
            Node head = LinkListHelper.CreateLinkList(values);

            for(int i = 1; i <= values.Length; i ++)
            {
                var node = FindNthToLastElement.Find(head, i);
                Assert.AreEqual<int>(values[values.Length - i], node.Value);
            }                       
        }

        public void VerifyScenario(int[] values, int nthElement, int expectedValue)
        {
            Node head = LinkListHelper.CreateLinkList(values);
            var node = FindNthToLastElement.Find(head, nthElement);
            Assert.AreEqual<int>(expectedValue, node.Value);
        }
    }
}
