using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArraysAndStrings;

namespace ArraysAndStringsTest
{
    [TestClass]
    public class RotatedStringTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]        
        public void NullTest1()
        {
            RotatedString.IsRotated(null, "ab");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTest2()
        {
            RotatedString.IsRotated("ab", null);
        }

        [TestMethod]
        public void Scenarios()
        {
            Assert.IsTrue(RotatedString.IsRotated("", ""));
            Assert.IsTrue(RotatedString.IsRotated("a", "a"));
            Assert.IsTrue(RotatedString.IsRotated("ab", "ba"));
            Assert.IsTrue(RotatedString.IsRotated("abac", "acab"));
            Assert.IsTrue(RotatedString.IsRotated("abc", "abc"));

            Assert.IsFalse(RotatedString.IsRotated("", "ab"));
            Assert.IsFalse(RotatedString.IsRotated("ab", "bac"));
            Assert.IsFalse(RotatedString.IsRotated("abcd", "acbd"));
        }
    }
}
