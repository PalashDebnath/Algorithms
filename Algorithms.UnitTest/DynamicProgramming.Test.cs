using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class DynamicProgrammingTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase]
        public void NumberOfOperationOnDifferentStringInput()
        {
            int expected = 2;
            int actual = LevenshteinDistance.NumberOfOperation("abc", "yabd");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void NumberOfOperationOnSameStringInput()
        {
            int expected = 0;
            int actual = LevenshteinDistance.NumberOfOperation("abc", "abc");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void NumberOfOperationOnEmptyStringInput()
        {
            int expected = 3;
            int actual = LevenshteinDistance.NumberOfOperation("", "abc");
            Assert.AreEqual(expected, actual);
            actual = LevenshteinDistance.NumberOfOperation("abc", "");
            Assert.AreEqual(expected, actual);
        }
    }
}