using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArraysAndStrings;

namespace ArraysAndStringsTest
{
    [TestClass]
    public class PermutationMatchTest
    {
        [TestMethod]
        public void NullTest1()
        {
            Assert.IsTrue(PermutationMatch.IsPermutation(null, null));
        }

        [TestMethod]
        public void NullTest2()
        {
            Assert.IsFalse(PermutationMatch.IsPermutation(null, "abc"));
        }

        [TestMethod]
        public void NullTest3()
        {
            Assert.IsFalse(PermutationMatch.IsPermutation("abc", null));
        }

        [TestMethod]
        public void DiffLengthTest()
        {
            Assert.IsFalse(PermutationMatch.IsPermutation("abc", "abcde"));
        }

        [TestMethod]
        public void SingleCharTest()
        {
            Assert.IsTrue(PermutationMatch.IsPermutation("a", "a"));
        }

        [TestMethod]
        public void TwoCharTest1()
        {
            Assert.IsTrue(PermutationMatch.IsPermutation("ab", "ba"));
        }

        [TestMethod]
        public void TwoCharTest2()
        {
            Assert.IsTrue(PermutationMatch.IsPermutation("aa", "aa"));
        }

        [TestMethod]
        public void MatchTest()
        {
            Assert.IsTrue(PermutationMatch.IsPermutation("abdab", "bbaad"));
        }

        [TestMethod]
        public void MismatchTest()
        {
            Assert.IsFalse(PermutationMatch.IsPermutation("abdab", "bbbad"));
        }
    }
}
