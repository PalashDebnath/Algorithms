using Algorithms.Application;
using NUnit.Framework;
using System;

namespace Algorithms.UnitTest
{
    public class TwoNumberSumTests
    {

        [TestCase]
        public void TestCaseFound()
        {
            int[] expected = {-47, 210};
            int[] actual = TwoNumberSum.TwoNumberSumFirst(new int[] {-21, 301, 12, 4, 65, 56, 210, 356, 9, -47}, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
            actual = TwoNumberSum.TwoNumberSumSecond(new int[] {-21, 301, 12, 4, 65, 56, 210, 356, 9, -47}, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
            actual = TwoNumberSum.TwoNumberSumThird(new int[] {-21, 301, 12, 4, 65, 56, 210, 356, 9, -47}, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void TestCaseNotFound()
        {
            int[] expected = {};
            int[] actual = TwoNumberSum.TwoNumberSumFirst(new int[] {3, 5, -4, 8, 11, 1, -1, 6}, 15);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
            actual = TwoNumberSum.TwoNumberSumSecond(new int[] {3, 5, -4, 8, 11, 1, -1, 6}, 15);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
            actual = TwoNumberSum.TwoNumberSumThird(new int[] {3, 5, -4, 8, 11, 1, -1, 6}, 15);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }
    }
}