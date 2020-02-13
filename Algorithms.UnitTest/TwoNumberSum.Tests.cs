using Algorithms.Application;
using NUnit.Framework;
using System;

namespace Algorithms.UnitTest
{
    public class TwoNumberSumTests
    {
        int[] arrayOne, arrayTwo;

        [SetUp]
        public void Setup()
        {
            arrayOne = new int[] {-21, 301, 12, 4, 65, 56, 210, 356, 9, -47};
            arrayTwo = new int[] {3, 5, -4, 8, 11, 1, -1, 6}; 
        }

        [TestCase]
        public void FoundByArrayTraversal()
        {
            int[] expected = {-47, 210};
            int[] actual = TwoNumberSum.SumUsingTraversal(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void FoundByUsingHashTable()
        {
            int[] expected = {-47, 210};
            int[] actual = TwoNumberSum.SumUsingHashtable(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void FoundBySorting()
        {
            int[] expected = {-47, 210};
            int[] actual = TwoNumberSum.SumUsingSorting(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void NotFoundArrayTraversal()
        {
            int[] expected = {};
            int[] actual = TwoNumberSum.SumUsingTraversal(arrayTwo, 15);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void NotFoundByUsingHashTable()
        {
            int[] expected = {};
            int[] actual = TwoNumberSum.SumUsingHashtable(arrayTwo, 15);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void NotFoundBySorting()
        {
            int[] expected = {};
            int[] actual = TwoNumberSum.SumUsingSorting(arrayTwo, 15);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }
    }
}