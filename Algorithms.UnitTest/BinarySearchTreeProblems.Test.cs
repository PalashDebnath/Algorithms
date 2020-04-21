using Algorithms.Problems;
using NUnit.Framework;
using System.Collections.Generic;

namespace Algorithms.UnitTest
{
    public class BinarySearchTreeTests
    {
        BinarySearchTree treeOne, treeTwo;

        [SetUp]
        public void Setup()
        {
            treeOne = new BinarySearchTree(100);
            treeOne.IterativeInsert(5).IterativeInsert(502).IterativeInsert(5).IterativeInsert(2).IterativeInsert(15).IterativeInsert(22).IterativeInsert(57).IterativeInsert(60)
            .IterativeInsert(2).IterativeInsert(3).IterativeInsert(1).IterativeInsert(55000).IterativeInsert(204).IterativeInsert(203).IterativeInsert(205).IterativeInsert(207).IterativeInsert(208)
            .IterativeInsert(206).IterativeInsert(1001).IterativeInsert(4500).IterativeInsert(-51).IterativeInsert(-403);

            treeTwo = new BinarySearchTree(10);
            treeTwo.IterativeInsert(7).IterativeInsert(11).IterativeInsert(4).IterativeInsert(5).IterativeInsert(8).IterativeInsert(9).IterativeInsert(2)
            .IterativeInsert(1).IterativeInsert(17).IterativeInsert(15).IterativeInsert(22);
        }

        [TestCase]
        public void IterativeClosestFinder()
        {
            int expected = -51;
            int actual = BST.FindClosestValueIteratively(treeOne, -70);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void RecursiveClosestFinder()
        {
            int expected = 100;
            int actual = BST.FindClosestValueRecursively(treeOne, 100);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void RecursiveContain()
        {
            bool expected = true;
            bool actual = treeTwo.RecursiveContain(22);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IterativeContain()
        {
            bool expected = false;
            bool actual = treeTwo.IterativeContain(23);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IterativeRemove()
        {
            int[] expected = new int[] { 1, 2, 4, 5, 7, 8, 9, 10, 11, 15, 17 };
            BinarySearchTree actual = treeTwo.IterativeRemove(22);
            Assert.AreNotEqual(expected, actual);
        }

        [TestCase]
        public void RecursiveRemove()
        {
            int[] expected = new int[] { 1, 2, 5, 7, 8, 9, 10, 11, 15, 17, 22 };
            BinarySearchTree actual = treeTwo.RecursiveRemove(4);
            Assert.AreNotEqual(expected, actual);
        }

        [TestCase]
        public void ValidateBinarySearchTree()
        {
            bool expected = true;
            bool actual = BST.Validate(treeOne);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void CheckSimilarity()
        {
            bool expected = true;
            bool actual = BST.CheckSimilarity(new List<int>(){10, 15, 8, 12, 94, 81, 5, 2, 11}, new List<int>(){10, 8, 5, 15, 2, 12, 11, 94, 81});
            Assert.AreEqual(expected, actual);
        }
    }
}

