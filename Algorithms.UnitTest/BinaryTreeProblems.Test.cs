using Algorithms.Application;
using NUnit.Framework;
using System.Collections.Generic;

namespace Algorithms.UnitTest
{
    public class BinaryTreeTests
    {
        BinaryTree treeOne, treeTwo;

        [SetUp]
        public void Setup()
        {
            treeOne = new BinaryTree(1);
            treeOne.left = new BinaryTree(2);
            treeOne.right = new BinaryTree(3);            
            treeOne.left.left = new BinaryTree(4);
            treeOne.left.right = new BinaryTree(5);
            treeOne.left.parent = treeOne;
            treeOne.right.left = new BinaryTree(6);
            treeOne.right.right = new BinaryTree(7);
            treeOne.right.parent = treeOne;
            treeOne.left.left.parent = treeOne.left;
            treeOne.left.right.parent = treeOne.left;
            treeOne.right.left.parent = treeOne.right;
            treeOne.right.right.parent = treeOne.right;

            treeTwo = new BinaryTree(1);
            treeTwo.left = new BinaryTree(-5);
            treeTwo.right = new BinaryTree(3);
            treeTwo.left.left = new BinaryTree(6);
        }

        [TestCase]
        public void MaxPathSum_OnTreeHoldingAllPositiveNodes()
        {
            int expected = 18;
            int actual = BinaryTreeMethods.MaxPathSum(treeOne);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MaxPathSum_OnTreeHoldingPositiveAndNegetiveNodes()
        {
            int expected = 6;
            int actual = BinaryTreeMethods.MaxPathSum(treeTwo);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IterativeInOrderTraversal()
        {
            List<int> expected = new List<int>() {4, 2, 5, 1, 6, 3, 7};
            List<int> actual = new List<int>();
            BinaryTreeMethods.IterativeInOrderTraversal(treeOne, e => { actual.Add(e.value); });
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IterativePreOrderTraversal()
        {
            List<int> expected = new List<int>() {1, 2, 4, 5, 3, 6, 7};
            List<int> actual = new List<int>();
            BinaryTreeMethods.IterativePreOrderTraversal(treeOne, e => { actual.Add(e.value); });
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void IterativePostOrderTraversal()
        {
            List<int> expected = new List<int>() {4, 5, 2, 6, 7, 3, 1};
            List<int> actual = new List<int>();
            BinaryTreeMethods.IterativePostOrderTraversal(treeOne, e => { actual.Add(e.value); });
            Assert.AreEqual(expected, actual);
        }
    }
}