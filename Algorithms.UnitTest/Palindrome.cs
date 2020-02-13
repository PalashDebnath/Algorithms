using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class PalindromeTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase]
        public void IsPalindromeCheck()
        {
            bool expected = true;
            bool actual = Palindrome.Check("abcdcba");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsNotPalindromeCheck()
        {
            bool expected = false;
            bool actual = Palindrome.Check("palash");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsPalindromeCheckRecursive()
        {
            bool expected = true;
            bool actual = Palindrome.RecursiveCheck("abcdcba");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsNotPalindromeCheckRecursive()
        {
            bool expected = false;
            bool actual = Palindrome.RecursiveCheck("palash");
            Assert.AreEqual(expected, actual);
        }
    }
}