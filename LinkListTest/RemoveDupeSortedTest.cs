using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkList;

namespace LinkListTest
{
    [TestClass]
    public class RemoveDupeSortedTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTest()
        {
            Node head = null;
            RemoveDupesAndSorted.RemoveDuplications(ref head);
        }

        [TestMethod]
        public void SingleNodeTest()
        {
            int[] testValues = new int[] { 1 };
            int[] expectedValues = new int[] { 1 };
            VerifyScenario(testValues, expectedValues);
        }

        [TestMethod]
        public void Test1()
        {
            int[] testValues = new int[] { 1, 2 };
            int[] expectedValues = new int[] { 1, 2 };
            VerifyScenario(testValues, expectedValues);
        }

        [TestMethod]
        public void Test2()
        {
            int[] testValues = new int[] { 1, 1 };
            int[] expectedValues = new int[] { 1 };
            VerifyScenario(testValues, expectedValues);
        }

        [TestMethod]
        public void Test3()
        {
            int[] testValues = new int[] { 1, 2, 1, 2 };
            int[] expectedValues = new int[] { 1, 2 };
            VerifyScenario(testValues, expectedValues);
        }

        [TestMethod]
        public void Test4()
        {
            int[] testValues = new int[] { 1, 2, 3, 4 };
            int[] expectedValues = new int[] { 1, 2, 3,4 };
            VerifyScenario(testValues, expectedValues);
        }

        [TestMethod]
        public void Test5()
        {
            int[] testValues = new int[] { 1, 2, 2, 3 };
            int[] expectedValues = new int[] { 1, 2, 3 };
            VerifyScenario(testValues, expectedValues);
        }

        [TestMethod]
        public void Test6()
        {
            int[] testValues = new int[] { 4, 3, 2, 1 };
            int[] expectedValues = new int[] { 1, 2, 3, 4 };
            VerifyScenario(testValues, expectedValues);
        }

        [TestMethod]
        public void Test7()
        {
            int[] testValues = new int[] { 2, 1, 2, 1 };
            int[] expectedValues = new int[] { 1, 2 };
            VerifyScenario(testValues, expectedValues);
        }

        [TestMethod]
        public void Test8()
        {
            int[] testValues = new int[] { 3, 2, 2, 1 };
            int[] expectedValues = new int[] { 1, 2, 3 };
            VerifyScenario(testValues, expectedValues);
        }

        [TestMethod]
        public void Test9()
        {
            int[] testValues = new int[] { 1, 1, 1, 1 };
            int[] expectedValues = new int[] { 1 };
            VerifyScenario(testValues, expectedValues);
        }

        public void VerifyScenario(int[] testValues, int[] expectedValues)
        {
            Node head = LinkListHelper.CreateLinkList(testValues);
            RemoveDupesAndSorted.RemoveDuplications(ref head);

            Assert.IsTrue(LinkListHelper.IsEqual(head, expectedValues));
        }
    }
}
