using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class NthFibonacciTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase]
        public void GetNthFibonacciUsingRecursion()
        {
            int expected = 8;
            int actual = Fibonacci.GetNthFibonacciUsingRecursion(7);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void GetNthFibonacciUsingHashTable()
        {
            int expected = 8;
            int actual = Fibonacci.GetNthFibonacciUsingHashTable(7);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void GetNthFibonacciUsingArray()
        {
            int expected = 8;
            int actual = Fibonacci.GetNthFibonacciUsingArray(7);
            Assert.AreEqual(expected, actual);
        }

    }
}