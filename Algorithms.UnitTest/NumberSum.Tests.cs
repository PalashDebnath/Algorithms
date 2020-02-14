using Algorithms.Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithms.UnitTest
{
    public class TwoNumberSumTests
    {
        int[] arrayOne, arrayTwo, arrayThree;

        [SetUp]
        public void Setup()
        {
            arrayOne = new int[] {-21, 301, 12, 4, 65, 56, 210, 356, 9, -47};
            arrayTwo = new int[] {3, 5, -4, 8, 11, 1, -1, 6};
            arrayThree = new int[] {12, 3, 1, 2, -6, 5, -8, 6}; 
        }

        [TestCase]
        public void FoundByArrayTraversal()
        {
            int[] expected = {-47, 210};
            int[] actual = NumberSum.SumTwoNumberUsingTraversal(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void FoundByUsingHashTable()
        {
            int[] expected = {-47, 210};
            int[] actual = NumberSum.SumTwoNumberUsingHashtable(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void FoundBySorting()
        {
            int[] expected = {-47, 210};
            int[] actual = NumberSum.SumTwoNumberUsingSorting(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void NotFoundArrayTraversal()
        {
            int[] expected = {};
            int[] actual = NumberSum.SumTwoNumberUsingTraversal(arrayTwo, 15);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void NotFoundByUsingHashTable()
        {
            int[] expected = {};
            int[] actual = NumberSum.SumTwoNumberUsingHashtable(arrayTwo, 15);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void NotFoundBySorting()
        {
            int[] expected = {};
            int[] actual = NumberSum.SumTwoNumberUsingSorting(arrayTwo, 15);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void ThreeNumberSum()
        {
            List<int[]> expected = new List<int[]>();
            expected.Add(new int[] { -8, 2, 6 });
            expected.Add(new int[] { -8, 3, 5 });
            expected.Add(new int[] { -6, 1, 5 });
            List<int[]> actual = NumberSum.SumThreeNumber(arrayThree, 0);
            Assert.AreEqual(actual, expected);
        }
    }
}