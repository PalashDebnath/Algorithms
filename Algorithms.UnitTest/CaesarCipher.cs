using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class CaesarCipherTests
    {
        [SetUp]
        public void Setup()
        {

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