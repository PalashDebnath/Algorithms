using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class SortingTests
    {
        int[] array;

        [SetUp]
        public void Setup()
        {
            array = new int[] {-1, -2, -3, -7, -17, -27, -18, -541, -8, -7, 7};
        }

        [TestCase]
        public void BubbleSort()
        {
            int[] expected = new int[] {-541, -27, -18, -17, -8, -7, -7, -3, -2, -1, 7};
            int[] actual = Sort.Bubble(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void InsertionSort()
        {
            int[] expected = new int[] {-541, -27, -18, -17, -8, -7, -7, -3, -2, -1, 7};
            int[] actual = Sort.Insertion(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void SelectionSort()
        {
            int[] expected = new int[] {-541, -27, -18, -17, -8, -7, -7, -3, -2, -1, 7};
            int[] actual = Sort.Selection(array);
            Assert.AreEqual(expected, actual);
        }
    }
}