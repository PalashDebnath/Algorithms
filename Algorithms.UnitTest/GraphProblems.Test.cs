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
        Dictionary<char, Member> memberTree;

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

            memberTree = new Dictionary<char, Member>();

            foreach(char member in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                memberTree.Add(member, new Member(member));
            }

            memberTree['A'].AddAsAncestor(new Member[] {
                memberTree['B'],
                memberTree['C'],
                memberTree['D'],
                memberTree['E'],
                memberTree['F']
            });

            memberTree['B'].AddAsAncestor(new Member[] {
                memberTree['G'],
                memberTree['H'],
                memberTree['I']
            });

            memberTree['C'].AddAsAncestor(new Member[] {
                memberTree['J']
            });

            memberTree['D'].AddAsAncestor(new Member[] {
                memberTree['K'],
                memberTree['L']
            });

            memberTree['F'].AddAsAncestor(new Member[] {
                memberTree['M'],
                memberTree['N']
            });

            memberTree['H'].AddAsAncestor(new Member[] {
                memberTree['O'],
                memberTree['P'],
                memberTree['Q'],
                memberTree['R']
            });

            memberTree['K'].AddAsAncestor(new Member[] {
                memberTree['S']
            });

            memberTree['P'].AddAsAncestor(new Member[] {
                memberTree['T'],
                memberTree['U']
            });

            memberTree['R'].AddAsAncestor(new Member[] {
                memberTree['V']
            });

            memberTree['V'].AddAsAncestor(new Member[] {
                memberTree['W'],
                memberTree['X'],
                memberTree['Y']
            });

            memberTree['X'].AddAsAncestor(new Member[] {
                memberTree['Z'] 
            }); 
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
            bool actual = Graph.HasCycleAtFirstPosition(arrayOne);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void HasAtNthPosition()
        {
            bool expected = false;
            bool actual = Graph.HasCycleAtNthPosition(arrayTwo, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void TotalNumber()
        {
            int expected = 6;
            int actual = Graph.TotalNumberOfCycle(arrayOne);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void GetYoungestCommonAncestor()
        {
            Member expected = memberTree['B'];
            Member actual = Member.GetYoungestCommonAncestor(memberTree['Z'], memberTree['B']);
            Assert.AreEqual(expected, actual);
        }
    }
}