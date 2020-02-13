using System.Collections.Generic;
using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class ProductSumTests
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
        public void Sum()
        {
            int expected = 115;
            int actual = ProductSum.Sum(data);
            Assert.AreEqual(expected, actual);
        }

    }
}