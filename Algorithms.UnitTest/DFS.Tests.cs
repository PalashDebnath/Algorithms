using System.Collections.Generic;
using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class DFSTests
    {
        DFSNode nodeChain;
        List<string> output;

        [SetUp]
        public void Setup()
        {
            nodeChain = new DFSNode("A");
            nodeChain.AddDFSNode("B").AddDFSNode("C").AddDFSNode("D");
            nodeChain.children[0].AddDFSNode("E").AddDFSNode("F");
            nodeChain.children[2].AddDFSNode("G").AddDFSNode("H");
            nodeChain.children[0].children[1].AddDFSNode("I").AddDFSNode("J");
            nodeChain.children[2].children[0].AddDFSNode("K");

            output = new List<string>(); 
        }

        [TestCase]
        public void DepthFirstSearch()
        {
            List<string> expected = new List<string>() {"A","B","E","F","I","J","C","D","G","K","H"};
            List<string> actual = nodeChain.DepthFirstSearch(output);
            Assert.AreEqual(expected, actual);
        }

    }
}