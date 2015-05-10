using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkList;

namespace LinkListTest
{
    [TestClass]
    public class PartitionListTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTest()
        {
            PartitionList.DoPartition(null, 0);
        }

        [TestMethod]
        public void ValidTest1()
        {
            int[] values = new int[] { 2, 3, 1, 5, 4 };
            int[] expectedValues = new int[] { 2, 1, 3, 5, 4 };
            VerifyScenario(values, 3, expectedValues);
        }

        [TestMethod]
        public void ValidTest2()
        {
            int[] values = new int[] { 2, 3, 1, 5, 4 };
            int[] expectedValues = new int[] { 2, 3, 1, 4, 5};
            VerifyScenario(values, 5, expectedValues);
        }

        [TestMethod]
        public void ValidTest3()
        {
            int[] values = new int[] { 2, 3, 1, 5, 4 };
            int[] expectedValues = new int[] { 2, 3, 1, 5, 4 };
            VerifyScenario(values, 1, expectedValues);
        }

        [TestMethod]
        public void ValidTest4()
        {
            int[] values = new int[] { 2, 3, 1, 5, 4 };
            int[] expectedValues = new int[] { 2, 3, 1, 5, 4 };
            VerifyScenario(values, 0, expectedValues);
        }

        [TestMethod]
        public void ValidTest5()
        {
            int[] values = new int[] { 2, 3, 1, 5, 4 };
            int[] expectedValues = new int[] { 2, 3, 1, 5, 4 };
            VerifyScenario(values, 6, expectedValues);
        }

        [TestMethod]
        public void ValidTest6()
        {
            int[] values = new int[] { 2, 3, 1, 5, 4 };
            int[] expectedValues = new int[] { 1, 2, 3, 5, 4 };
            VerifyScenario(values, 2, expectedValues);
        }

        public void VerifyScenario(int[] values, int middleValue, int[] expectedValues)
        {
            Node head = LinkListHelper.CreateLinkList(values);
            Node newHead = PartitionList.DoPartition(head, middleValue);

            Assert.IsTrue(LinkListHelper.IsEqual(newHead, expectedValues));
        }
    }
}
