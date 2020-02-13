using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class caesarCipherTests
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
    }
}