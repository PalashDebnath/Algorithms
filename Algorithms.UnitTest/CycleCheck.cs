using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class CycleCheckTests
    {
        int[] arrayOne, arrayTwo;

        [SetUp]
        public void Setup()
        {
            arrayOne = new int[] {2, 3, 1, -4, -4, 2}; 
            arrayTwo = new int[] {-1, -2, -3, -7, -17, -27, -18, -541, -8, -7, 7};
        }

        [TestCase]
        public void HasAtFirstPosition()
        {
            bool expected = true;
            bool actual = CycleCheck.HasAtFirstPosition(arrayOne);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void HasAtNthPosition()
        {
            bool expected = false;
            bool actual = CycleCheck.HasAtNthPosition(arrayTwo, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void TotalNumber()
        {
            int expected = 6;
            int actual = CycleCheck.TotalNumber(arrayOne);
            Assert.AreEqual(expected, actual);
        }
    }
}