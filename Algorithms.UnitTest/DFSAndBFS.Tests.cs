using System.Collections.Generic;
using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class DFSAndBFSTests
    {
        Node nodeChain;
        List<string> output;

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

    }
}