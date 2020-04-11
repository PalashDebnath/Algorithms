using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class StringTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase]
        public void IsPalindromeCheckUsingTraversal()
        {
            bool expected = true;
            bool actual = CString.CheckPalindroneUsingTraversal("abcdcba");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsNotPalindromeCheckUsingTraversal()
        {
            bool expected = false;
            bool actual = CString.CheckPalindroneUsingTraversal("palash");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsPalindromeCheckUsingRecursive()
        {
            bool expected = true;
            bool actual = CString.CheckPalindromeUsingRecursion("abcdcba");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsNotPalindromeCheckUsingRecursive()
        {
            bool expected = false;
            bool actual = CString.CheckPalindromeUsingRecursion("palash");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Encryptor()
        {
            string expected = "zab";
            string actual = CString.Encryptor("xyz", 2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Decryptor()
        {
            string expected = "xyz";
            string actual = CString.Decryptor("zab", 2);
            Assert.AreEqual(expected, actual);
        }
    }
}