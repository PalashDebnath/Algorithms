using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class MoveElementTests
    {
        int[] array;

        [SetUp]
        public void Setup()
        {
            array = new int[] {2, 1, 2, 2, 2, 3, 4, 2};
        }

        [TestCase]
        public void ToEnd()
        {
            int[] expected = new int[] {4, 1, 3, 2, 2, 2, 2, 2};
            int[] actual = MoveElement.ToEnd(array, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void ToStart()
        {
            int[] expected = new int[] {2, 2, 2, 2, 2, 3, 4, 1};
            int[] actual = MoveElement.ToStart(array, 2);
            Assert.AreEqual(expected, actual);
        }

    }
}