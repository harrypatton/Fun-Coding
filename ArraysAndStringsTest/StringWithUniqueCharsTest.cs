using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArraysAndStrings;

namespace ArraysAndStringsTest
{
    [TestClass]
    public class StringWithUniqueCharsTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullInput()
        {
            StringWithUnqiueChars.IsStringWithAllUniqueChars(null);
        }

        [TestMethod]
        public void EmptyString()
        {
            bool result = StringWithUnqiueChars.IsStringWithAllUniqueChars(string.Empty);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OneCharString()
        {
            bool result = StringWithUnqiueChars.IsStringWithAllUniqueChars("a");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UniqueCharsString()
        {
            bool result = StringWithUnqiueChars.IsStringWithAllUniqueChars("abc");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NonUniqueCharsString()
        {
            bool result = StringWithUnqiueChars.IsStringWithAllUniqueChars("abca");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LongUniqueCharsString()
        {
            char[] chars = new char[256];

            for (int i = 0; i <chars.Length; i ++)
            {
                chars[i] = (char)i;
            }

            string testString = new string(chars);

            bool result = StringWithUnqiueChars.IsStringWithAllUniqueChars(testString);
            Assert.IsTrue(result);
        }
    }
}
