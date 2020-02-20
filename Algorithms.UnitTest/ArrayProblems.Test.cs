using Algorithms.Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithms.UnitTest
{
    public class ArrayTests
    {
        int[] array, arrayOne, arrayTwo, arrayThree;

        [SetUp]
        public void Setup()
        {
            array = new int[] {2, 1, 2, 2, 2, 3, 4, 2};
            arrayOne = new int[] {-21, 301, 12, 4, 65, 56, 210, 356, 9, -47};
            arrayTwo = new int[] {3, 5, -4, 8, 11, 1, -1, 6};
            arrayThree = new int[] {12, 3, 1, 2, -6, 5, -8, 6}; 
        }

        [TestCase]
        public void SumTwoNumberUsingTraversal()
        {
            int[] expected = {-47, 210};
            int[] actual = Sum.TwoNumberUsingTraversal(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void SumTwoNumberUsingHashtable()
        {
            int[] expected = {-47, 210};
            int[] actual = Sum.TwoNumberUsingHashtable(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void SumTwoNumberUsingSorting()
        {
            int[] expected = {-47, 210};
            int[] actual = Sum.TwoNumberUsingSorting(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void SumThreeNumberUsingTraversal()
        {
            List<int[]> expected = new List<int[]>();
            expected.Add(new int[] { -8, 2, 6 });
            expected.Add(new int[] { -8, 3, 5 });
            expected.Add(new int[] { -6, 1, 5 });
            List<int[]> actual = Sum.ThreeNumberUsingTraversal(arrayThree, 0);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void FindSmallestDifference()
        {
            int[] expected = new int[] {4, 3};
            int[] actual = Find.SmallestDifference(arrayOne, arrayTwo);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MoveSimilarElementToEnd()
        {
            int[] expected = new int[] {4, 1, 3, 2, 2, 2, 2, 2};
            int[] actual = MoveElement.ToEnd(array, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MoveSimilarElementToStart()
        {
            int[] expected = new int[] {2, 2, 2, 2, 2, 3, 4, 1};
            int[] actual = MoveElement.ToStart(array, 2);
            Assert.AreEqual(expected, actual);
        }
    }
}