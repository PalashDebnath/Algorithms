using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class BinarySearchTests
    {
        int[] sortedArray;

        [SetUp]
        public void Setup()
        {
            sortedArray = new int[] { -1, 10, 45, 67, 150, 200 };
        }

        [TestCase]
        public void IterativeSearch()
        {
            int expected = 4;
            int actual = BinarySearch.IterativeSearch(sortedArray, 150);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void GetNthFibonacciUsingHashTable()
        {
            int expected = 5;
            int actual = BinarySearch.RecursiveSearch(sortedArray, 200);
            Assert.AreEqual(expected, actual);
        }
    }
}