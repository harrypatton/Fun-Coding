using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bits;

namespace BitSmallLargeNumberTest {
    [TestClass]
    public class BitSmallLargeNumberTest {

        [TestMethod]
        public void TestMethod1() {
            int value = 0;

            Assert.AreEqual<int>(0, BitSmallLargeNumber.GetLargest(value));
            Assert.AreEqual<int>(0, BitSmallLargeNumber.GetSmallest(value));
        }

        [TestMethod]
        public void TestMethod2() {
            int value = 1;

            Assert.AreEqual<int>(1, BitSmallLargeNumber.GetLargest(value));
            Assert.AreEqual<int>(1, BitSmallLargeNumber.GetSmallest(value));
        }

        [TestMethod]
        public void TestMethod3() {
            int value = 2;

            Assert.AreEqual<int>(2, BitSmallLargeNumber.GetLargest(value));
            Assert.AreEqual<int>(1, BitSmallLargeNumber.GetSmallest(value));
        }

        [TestMethod]
        public void TestMethod4() {
            int value = 84;

            Assert.AreEqual<int>(112, BitSmallLargeNumber.GetLargest(value));
            Assert.AreEqual<int>(7, BitSmallLargeNumber.GetSmallest(value));
        }

        [TestMethod]
        public void TestMethod5() {
            int value = 57;

            Assert.AreEqual<int>(60, BitSmallLargeNumber.GetLargest(value));
            Assert.AreEqual<int>(15, BitSmallLargeNumber.GetSmallest(value));
        }
    }
}
