using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class SmallestDifferenceTests
    {
        int[] arrayOne, arrayTwo;

        [SetUp]
        public void Setup()
        {
            arrayOne = new int[] {-1, 5, 10, 20, 28, 3};
            arrayTwo = new int[] {26, 134, 135, 15, 17};
        }

        [TestCase]
        public void Find()
        {
            int[] expected = new int[] {28, 26};
            int[] actual = SmallestDifference.Find(arrayOne, arrayTwo);
            Assert.AreEqual(expected, actual);
        }

    }
}