using Algorithms.Problems;
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
            bool actual = Palindrome.CheckIteratively("abcdcba");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsNotPalindromeCheckUsingTraversal()
        {
            bool expected = false;
            bool actual = Palindrome.CheckIteratively("palash");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsPalindromeCheckUsingRecursive()
        {
            bool expected = true;
            bool actual = Palindrome.CheckRecursively("abcdcba");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IsNotPalindromeCheckUsingRecursive()
        {
            bool expected = false;
            bool actual = Palindrome.CheckRecursively("palash");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Encryptor()
        {
            string expected = "zab";
            string actual = CaesarCypher.Encryptor("xyz", 2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Decryptor()
        {
            string expected = "xyz";
            string actual = CaesarCypher.Decryptor("zab", 2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void LengthOfLongestSubstringWithoutDuplication()
        {
            int expected = 3;
            int actual = LongestSubstringWithoutDuplication.Length("abcabcbb");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void ValueOfLongestSubstringWithoutDuplication()
        {
            string expected = "abc";
            string actual = LongestSubstringWithoutDuplication.Value("abcabcbb");
            Assert.AreEqual(expected, actual);
        }
    }
}