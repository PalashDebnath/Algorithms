using System.Collections.Generic;
using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class RecursionTests
    {
        List<object> data;
        [SetUp]
        public void Setup()
        {
            data = new List<object>();
            data.Add(1);
            data.Add(2);
            data.Add(new List<object>() { 3, 4} );
            data.Add(new List<object>(){ 5, new List<object>() { 6, 7 } });
            data.Add(10);
        }

        [TestCase]
        public void GetNthFibonacciUsingRecursion()
        {
            int expected = 8;
            int actual = Fibonacci.GetNthUsingRecursion(7);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void GetNthFibonacciUsingHashTable()
        {
            int expected = 8;
            int actual = Fibonacci.GetNthUsingHashTable(7);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void GetNthFibonacciUsingArray()
        {
            int expected = 8;
            int actual = Fibonacci.GetNthUsingArray(7);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void ProductSum()
        {
            int expected = 115;
            int actual = Product.Sum(data);
            Assert.AreEqual(expected, actual);
        }
    }
}