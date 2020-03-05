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
            treeOne.right.left = new BinaryTree(6);
            treeOne.right.right = new BinaryTree(7);

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
    }
}