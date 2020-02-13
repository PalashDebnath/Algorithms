using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class BubbleSortTests
    {
        int[] array;

        [SetUp]
        public void Setup()
        {
            array = new int[] {-1, -2, -3, -7, -17, -27, -18, -541, -8, -7, 7};
        }

        [TestCase]
        public void Sort()
        {
            int[] expected = new int[] {-541, -27, -18, -17, -8, -7, -7, -3, -2, -1, 7};
            int[] actual = BubbleSort.Sort(array);
            Assert.AreEqual(expected, actual);
        }
    }
}