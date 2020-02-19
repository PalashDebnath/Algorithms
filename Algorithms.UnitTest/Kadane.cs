using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class KadaneTests
    {
        int[] array;
        [SetUp]
        public void Setup()
        {
            array = new int[] {3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4};
        }

        [TestCase]
        public void FindMaximumSumOfSubArray()
        {
            int expected = 19;
            int actual = Kadan.FindMaximumSumOfSubArray(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FindSubArrayOfMaximumSum()
        {
            int[] expected = new int[] {1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1};
            int[] actual = Kadan.FindSubArrayOfMaximumSum(array);
            Assert.AreEqual(expected, actual);
        }
    }
}