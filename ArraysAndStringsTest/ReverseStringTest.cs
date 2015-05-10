using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArraysAndStrings;

namespace ArraysAndStringsTest
{
    [TestClass]
    public class ReverseStringTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullInput()
        {
            ReverseString.Reverse(null);
        }

        [TestMethod]
        public void EmptyString()
        {
            char[] str = new char[0];
            ReverseString.Reverse(str);

            Assert.AreEqual<int>(0, str.Length);
        }

        [TestMethod]
        public void OneCharString()
        {
            char[] str = new char[] { 'a' };
            ReverseString.Reverse(str);

            Assert.AreEqual<string>("a", new string(str));
        }

        [TestMethod]
        public void TwoCharsString()
        {
            char[] str = new char[] { 'a', 'b' };
            ReverseString.Reverse(str);

            Assert.AreEqual<string>("ba", new string(str));
        }

        [TestMethod]
        public void ThreeCharString()
        {
            char[] str = new char[] { 'a', 'b', 'c' };
            ReverseString.Reverse(str);

            Assert.AreEqual<string>("cba", new string(str));
        }

        [TestMethod]
        public void FourCharString()
        {
            char[] str = new char[] { 'a', 'b', 'c', 'a' };
            ReverseString.Reverse(str);

            Assert.AreEqual<string>("acba", new string(str));
        }
    }
}
