using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArraysAndStrings;

namespace ArraysAndStringsTest
{
    [TestClass]
    public class ReplaceSpaceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTest()
        {
            ReplaceSpaceQuestion.ReplaceSpace(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidLengthTest1()
        {
            char[] str = new char[10];
            ReplaceSpaceQuestion.ReplaceSpace(str, 11);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidLengthTest2()
        {
            char[] str = "a  ".ToCharArray();
            ReplaceSpaceQuestion.ReplaceSpace(str, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidLengthTest3()
        {
            char[] str = "a    ".ToCharArray();
            ReplaceSpaceQuestion.ReplaceSpace(str, 2);
        }

        [TestMethod]
        public void EmptyTest()
        {
            const string TestString = "";
            char[] str = TestString.ToCharArray();
            ReplaceSpaceQuestion.ReplaceSpace(str, TestString.Length);
            Assert.AreEqual<int>(0, str.Length);
        }

        [TestMethod]
        public void NormalTest1()
        {
            const string TestString = "a";
            char[] str = TestString.ToCharArray();
            ReplaceSpaceQuestion.ReplaceSpace(str, TestString.Length);
            Assert.AreEqual<string>(TestString, new string(str));
        }

        [TestMethod]
        public void NormalTest2()
        {
            const string TestString = "a ";
            char[] str = (TestString + "  ").ToCharArray();
            ReplaceSpaceQuestion.ReplaceSpace(str, TestString.Length);
            Assert.AreEqual<string>("a%20", new string(str));
        }

        [TestMethod]
        public void NormalTest3()
        {
            const string TestString = " a";
            char[] str = (TestString + "  ").ToCharArray();
            ReplaceSpaceQuestion.ReplaceSpace(str, TestString.Length);
            Assert.AreEqual<string>("%20a", new string(str));
        }

        [TestMethod]
        public void NormalTest4()
        {
            const string TestString = "  a";
            char[] str = (TestString + "    ").ToCharArray();
            ReplaceSpaceQuestion.ReplaceSpace(str, TestString.Length);
            Assert.AreEqual<string>("%20%20a", new string(str));
        }

        [TestMethod]
        public void NormalTest5()
        {
            const string TestString = "Mr John Smith";
            char[] str = (TestString + "    ").ToCharArray();
            ReplaceSpaceQuestion.ReplaceSpace(str, TestString.Length);
            Assert.AreEqual<string>("Mr%20John%20Smith", new string(str));
        }
    }
}
