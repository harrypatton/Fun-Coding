using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Search;

namespace UnitTestProject
{
    [TestClass]
    public class BinarySearchTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTest()
        {
            int[] numbers = null;
            BinarySearch.Search(numbers, 10);
        }

        [TestMethod]
        public void SingleElement_ItemFound()
        {
            int[] numbers = new int[] { 10 };
            int index = BinarySearch.Search(numbers, 10);
            Assert.AreEqual<int>(0, index);
        }

        [TestMethod]
        public void SingleElement_ItemNotFound()
        {
            int[] numbers = new int[] { 10 };
            int index = BinarySearch.Search(numbers, 20);
            Assert.AreEqual<int>(-1, index);
        }

        [TestMethod]
        public void TwoElements_ItemFound()
        {
            int[] numbers = new int[] { 10, 11 };
            VerifyAllElements(numbers);
        }        

        [TestMethod]
        public void TwoElements_ItemNotFound()
        {
            int[] numbers = new int[] { 10, 11 };
            int index = BinarySearch.Search(numbers, 20);
            Assert.AreEqual<int>(-1, index);
        }

        [TestMethod]
        public void ThreeElements_ItemFound()
        {
            int[] numbers = new int[] { 10, 11, 12 };
            VerifyAllElements(numbers);
        }

        [TestMethod]
        public void ThreeElements_ItemNotFound()
        {
            int[] numbers = new int[] { 10, 11, 12 };
            int index = BinarySearch.Search(numbers, 20);
            Assert.AreEqual<int>(-1, index);
        }

        [TestMethod]
        public void FourElements_ItemFound()
        {
            int[] numbers = new int[] { 10, 11, 12, 13 };
            VerifyAllElements(numbers);
        }

        [TestMethod]
        public void FourElements_ItemNotFound()
        {
            int[] numbers = new int[] { 10, 11, 13, 15 };
            int index = BinarySearch.Search(numbers, 12);
            Assert.AreEqual<int>(-1, index);
        }

        [TestMethod]
        public void FiveElements_ItemFound()
        {
            int[] numbers = new int[] { 10, 11, 12, 13, 14 };
            VerifyAllElements(numbers);
        }

        [TestMethod]
        public void FiveElements_ItemNotFound1()
        {
            int[] numbers = new int[] { 10, 11, 12, 13, 14 };
            int index = BinarySearch.Search(numbers, 5);
            Assert.AreEqual<int>(-1, index);
        }

        [TestMethod]
        public void FiveElements_ItemNotFound2()
        {
            int[] numbers = new int[] { 10, 11, 12, 16, 20 };
            int index = BinarySearch.Search(numbers, 17);
            Assert.AreEqual<int>(-1, index);
        }

        [TestMethod]
        public void FiveElements_ItemNotFound3()
        {
            int[] numbers = new int[] { 10, 11, 12, 16, 20 };
            int index = BinarySearch.Search(numbers, 26);
            Assert.AreEqual<int>(-1, index);
        }

        private static void VerifyAllElements(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int index = BinarySearch.Search(numbers, numbers[i]);
                Assert.AreEqual<int>(i, index);
            }
        }
    }
}
