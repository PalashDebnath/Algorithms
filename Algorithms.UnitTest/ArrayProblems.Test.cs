using Algorithms.Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithms.UnitTest
{
    public class ArrayTests
    {
        int[] array, arrayOne, arrayTwo, arrayThree, arrayFour, arrayFive;
        List<List<int>> elements;

        [SetUp]
        public void Setup()
        {
            array = new int[] {2, 1, 2, 2, 2, 3, 4, 2};
            arrayOne = new int[] {-21, 301, 12, 4, 65, 56, 210, 356, 9, -47};
            arrayTwo = new int[] {3, 5, -4, 8, 11, 1, -1, 6};
            arrayThree = new int[] {12, 3, 1, 2, -6, 5, -8, 6};
            arrayFour = new int[] {-10, -3, -5, 2, 15, -7, 28, -6, 12, 8, 11, 5};
            arrayFive = new int[] {8, 4, 2, 1, 3, 6, 7, 9, 5};

            elements = new List<List<int>>();
            elements.Add(new List<int>() {1, 3, 4, 10});
            elements.Add(new List<int>() {2, 5, 9, 11});
            elements.Add(new List<int>() {6, 8, 12, 15});
            elements.Add(new List<int>() {7, 13, 14, 16});
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
        public void SumFourNumberUsingTraversal()
        {
            List<int[]> expected = new List<int[]>();
            expected.Add(new int[] {-10, -3, 5, 28});
            expected.Add(new int[] {-7, -6, 5, 28});
            expected.Add(new int[] {-10, -6, 8, 28});
            expected.Add(new int[] {-7, -3, 2, 28});
            expected.Add(new int[] {-5, 2, 8, 15});          
            expected.Add(new int[] {-5, 2, 11, 12});
            expected.Add(new int[] {-5, 5, 8, 12});
            List<int[]> actual = Sum.FourNumberUsingTraversal(arrayFour, 20);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FindSmallestDifference()
        {
            int[] expected = new int[] {4, 3};
            int[] actual = Find.SmallestDifference(arrayOne, arrayTwo);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FindLargestRange()
        {
            int[] expected = new int[] {1, 3};
            int[] actual = Find.LargestRange(arrayThree);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FindMinimunRewardsMethodOne()
        {
            int expected = 25;
            int actual = Find.MinimumRewards_MethodOne(arrayFive);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FindMinimunRewardsMethodTwo()
        {
            int expected = 25;
            int actual = Find.MinimumRewards_MethodTwo(arrayFive);
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

        [TestCase]
        public void MoveZigzag()
        {

            List<int> expected = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
            List<int> actual = MoveElement.Zigzag(elements);
            Assert.AreEqual(expected, actual);
        }
    }
}