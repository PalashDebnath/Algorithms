using Algorithms.Application;
using NUnit.Framework;
using System.Collections.Generic;

namespace Algorithms.UnitTest
{
    public class BSTTests
    {
        BST tree, treeSum;

        [SetUp]
        public void Setup()
        {
            tree = new BST(100);
            tree.Insert(5).InsertRecursive(502).Insert(5).Insert(2).Insert(15).Insert(22).Insert(57).Insert(60)
            .Insert(2).Insert(3).Insert(1).Insert(55000).Insert(204).Insert(203).Insert(205).Insert(207).Insert(208)
            .Insert(206).Insert(1001).Insert(4500).Insert(-51).Insert(-403);

            treeSum = new BST(10);
            treeSum.Insert(7).Insert(11).InsertRecursive(4).InsertRecursive(5).Insert(8).Insert(9).Insert(2)
            .Insert(1).Insert(17).Insert(15).Insert(22);
        }

        [TestCase]
        public void FindTheClosestValue()
        {
            int expected = -51;
            int actual = tree.FindTheClosestValue(-70);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FindTheClosestValueRecursive()
        {
            int expected = 100;
            int actual = tree.FindTheClosestValueRecursive(100);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BranchSum()
        {
            List<int> expected = new List<int> {24, 26, 34, 53, 60};
            List<int> actual = treeSum.BranchSum();
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Contain()
        {
            bool expected = true;
            bool actual = treeSum.ContainRecursive(22);
            Assert.AreEqual(expected, actual);
        }
    }
}