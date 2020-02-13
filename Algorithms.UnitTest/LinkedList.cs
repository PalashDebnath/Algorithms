using Algorithms.Application;
using NUnit.Framework;

namespace Algorithms.UnitTest
{
    public class LinkedListTests
    {
        DoublyLinkedList linkedList;

        [SetUp]
        public void Setup()
        {
            linkedList = new DoublyLinkedList();
        }

        [TestCase]
        public void SetHead()
        {
            bool expected = true;
            linkedList.SetHead(new ListNode<int>(4));
            bool actual = linkedList.ContainNodeWithValue(4);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void SetTail()
        {
            bool expected = true;
            linkedList.SetTail(new ListNode<int>(7));
            bool actual = linkedList.ContainNodeWithValue(7);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void InsertAtPosition()
        {
            bool expected = true;
            linkedList.InsertAtPosition(1, new ListNode<int>(8));
            bool actual = linkedList.ContainNodeWithValue(8);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void InsertBefore()
        {
            bool expected = true;
            SetHead();
            SetTail();
            InsertAtPosition();
            linkedList.InsertBefore(linkedList.head.next, new ListNode<int>(9));
            bool actual = linkedList.ContainNodeWithValue(9);
            Assert.AreEqual(expected, actual);
        }

    }
}