using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class FindLargestNumbersTests
    {
        int[] array;

        [SetUp]
        public void Setup()
        {
            array = new int[] {-1, -2, -3, -7, -17, -27, -18, -541, -8, -7, 7};
        }

        [TestCase]
        public void FindLargestThreeNumbers()
        {
            int[] expected = new int[] {-2, -1, 7};
            int[] actual = FindlargestNumbers.Three(array);
            Assert.AreEqual(expected, actual);
        }
    }
}