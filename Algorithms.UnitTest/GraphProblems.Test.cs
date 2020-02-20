using System.Collections.Generic;
using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class GraphTests
    {
        Node nodeChain;
        List<string> output;
        int[] arrayOne, arrayTwo;

        [SetUp]
        public void Setup()
        {
            nodeChain = new Node("A");
            nodeChain.AddNode("B").AddNode("C").AddNode("D");
            nodeChain.children[0].AddNode("E").AddNode("F");
            nodeChain.children[2].AddNode("G").AddNode("H");
            nodeChain.children[0].children[1].AddNode("I").AddNode("J");
            nodeChain.children[2].children[0].AddNode("K");

            output = new List<string>();

            arrayOne = new int[] {2, 3, 1, -4, -4, 2}; 
            arrayTwo = new int[] {-1, -2, -3, -7, -17, -27, -18, -541, -8, -7, 7}; 
        }

        [TestCase]
        public void DepthFirstSearch()
        {
            List<string> expected = new List<string>() {"A","B","E","F","I","J","C","D","G","K","H"};
            List<string> actual = nodeChain.DepthFirstSearch(output);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BreadthFirstSearch()
        {
            List<string> expected = new List<string>() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"};
            List<string> actual = nodeChain.BreadthFirstSearch(output);
            Assert.AreEqual(expected, actual);
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