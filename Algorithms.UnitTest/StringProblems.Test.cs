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
            bool actual = String.CheckPalindroneUsingTraversal("abcdcba");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsNotPalindromeCheckUsingTraversal()
        {
            bool expected = false;
            bool actual = String.CheckPalindroneUsingTraversal("palash");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsPalindromeCheckUsingRecursive()
        {
            bool expected = true;
            bool actual = String.CheckPalindromeUsingRecursion("abcdcba");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsNotPalindromeCheckUsingRecursive()
        {
            bool expected = false;
            bool actual = String.CheckPalindromeUsingRecursion("palash");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Encryptor()
        {
            string expected = "zab";
            string actual = CaesarCipher.Encryptor("xyz", 2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Decryptor()
        {
            string expected = "xyz";
            string actual = CaesarCipher.Decryptor("zab", 2);
            Assert.AreEqual(expected, actual);
        }
    }
}