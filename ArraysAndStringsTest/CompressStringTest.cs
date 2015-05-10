using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArraysAndStrings;

namespace ArraysAndStringsTest
{
    [TestClass]
    public class CompressStringTest
    {
        [TestMethod]        
        public void NullTest()
        {
            string result = CompressString.GetCompressedString(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void EmptyTest()
        {
            string result = CompressString.GetCompressedString(string.Empty);
            Assert.AreEqual<string>(string.Empty, result);
        }

        [TestMethod]
        public void SingleCharTest()
        {
            string input = "a";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>(input, result);
        }

        [TestMethod]
        public void TwoCharsTest1()
        {
            string input = "aa";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>(input, result);
        }

        [TestMethod]
        public void TwoCharsTest2()
        {
            string input = "ab";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>(input, result);
        }

        [TestMethod]
        public void ThreeCharsTest1()
        {
            string input = "abc";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>(input, result);
        }

        [TestMethod]
        public void ThreeCharsTest2()
        {
            string input = "aac";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>(input, result);
        }

        [TestMethod]
        public void ThreeCharsTest3()
        {
            string input = "aaa";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>("a3", result);
        }        

        [TestMethod]
        public void NormalTest1()
        {
            string input = "aabbb";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>("a2b3", result);
        }

        [TestMethod]
        public void NormalTest2()
        {
            string input = "aaabbbaaa";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>("a3b3a3", result);
        }

        [TestMethod]
        public void NormalTest3()
        {
            string input = "aaab";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>(input, result);
        }

        [TestMethod]
        public void NormalTest4()
        {
            string input = "aaaaaaaaaa";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>("a10", result);
        }

        [TestMethod]
        public void NormalTest5()
        {
            string input = "aaaaaaaaaaa";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>("a11", result);
        }

        [TestMethod]
        public void NormalTest6()
        {
            string input = "abcdefghiaaaaaaaaaaaa";
            string result = CompressString.GetCompressedString(input);
            Assert.AreEqual<string>(input, result);
        }
    }
}
