using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkList;

namespace LinkListTest {

    [TestClass]
    public class ReverseListTestTest {

        [TestMethod]
        public void NullTest() {
            Node node = ReverseLink.Reverse(null);
        }

        [TestMethod]
        public void Test1() {
            VerifyScenairo(
                new int[] { 1 },
                new int[] { 1 });
        }

        [TestMethod]
        public void Test2() {
            VerifyScenairo(
                new int[] { 1, 2 },
                new int[] { 2, 1 });
        }

        [TestMethod]
        public void Test3() {
            VerifyScenairo(
                new int[] { 1, 2, 3 },
                new int[] { 3, 2, 1 });
        }

        public void VerifyScenairo(int[] values, int[] expectedValues) {
            Node node = LinkListHelper.CreateLinkList(values);
            node = ReverseLink.Reverse(node);

            Assert.IsTrue(LinkListHelper.IsEqual(node, expectedValues));
        }
    }
}
