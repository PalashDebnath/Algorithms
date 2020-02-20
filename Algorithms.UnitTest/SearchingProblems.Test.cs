using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class SearchingTests
    {
        int[] sortedArray, array;

        [SetUp]
        public void Setup()
        {
            sortedArray = new int[] { -1, 10, 45, 67, 150, 200 };
            array = new int[] {-1, -2, -3, -7, -17, -27, -18, -541, -8, -7, 7};
        }

        [TestCase]
        public void IterativeBinarySearch()
        {
            int expected = 4;
            int actual = Search.IterativeBinarySearch(sortedArray, 150);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void RecursiveBinarySearch()
        {
            int expected = 4;
            int actual = Search.RecursiveBinarySearch(sortedArray, 150);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void ThreeLargestNumbers()
        {
            int[] expected = new int[] {-2, -1, 7};
            int[] actual = Search.ThreeLargestNumbers(array);
            Assert.AreEqual(expected, actual);
        }
    }
}