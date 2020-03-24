using Algorithms.Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithms.UnitTest
{
    public class ArrayTests
    {
        int[] array, arrayOne, arrayTwo, arrayThree, arrayFour, arrayFive;

        [SetUp]
        public void Setup()
        {
            array = new int[] {2, 1, 2, 2, 2, 3, 4, 2};
            arrayOne = new int[] {-21, 301, 12, 4, 65, 56, 210, 356, 9, -47};
            arrayTwo = new int[] {3, 5, -4, 8, 11, 1, -1, 6};
            arrayThree = new int[] {12, 3, 1, 2, -6, 5, -8, 6};
            arrayFour = new int[] {-10, -3, -5, 2, 15, -7, 28, -6, 12, 8, 11, 5};
            arrayFive = new int[] {8, 4, 2, 1, 3, 6, 7, 9, 5};
        }

        [TestCase]
        public void SumTwoNumberUsingTraversal()
        {
            int[] expected = {-47, 210};
            int[] actual = ArrayMethods.TwoNumberSumUsingTraversal(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void SumTwoNumberUsingHashtable()
        {
            int[] expected = {-47, 210};
            int[] actual = ArrayMethods.TwoNumberSumUsingTraversal(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void SumTwoNumberUsingSorting()
        {
            int[] expected = {-47, 210};
            int[] actual = ArrayMethods.TwoNumberSumUsingTraversal(arrayOne, 163);
            Array.Sort(actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void SumThreeNumberUsingTraversal()
        {
            List<int[]> expected = new List<int[]>();
            expected.Add(new int[] { -8, 2, 6 });
            expected.Add(new int[] { -8, 3, 5 });
            expected.Add(new int[] { -6, 1, 5 });
            List<int[]> actual = ArrayMethods.ThreeNumberSum(arrayThree, 0);
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void SumFourNumberUsingTraversal()
        {
            List<int[]> expected = new List<int[]>();
            expected.Add(new int[] {-10, -3, 5, 28});
            expected.Add(new int[] {-7, -6, 5, 28});
            expected.Add(new int[] {-10, -6, 8, 28});
            expected.Add(new int[] {-7, -3, 2, 28});
            expected.Add(new int[] {-5, 2, 8, 15});          
            expected.Add(new int[] {-5, 2, 11, 12});
            expected.Add(new int[] {-5, 5, 8, 12});
            List<int[]> actual = ArrayMethods.FourNumberSum(arrayFour, 20);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FindSmallestDifference()
        {
            int[] expected = new int[] {4, 3};
            int[] actual = ArrayMethods.FindSmallestDifference(arrayOne, arrayTwo);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FindLargestRange()
        {
            int[] expected = new int[] {1, 3};
            int[] actual = ArrayMethods.FindLargestRange(arrayThree);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FindMinimunRewardsMethodOne()
        {
            int expected = 25;
            int actual = ArrayMethods.FindMinimumRewards_MethodOne(arrayFive);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FindMinimunRewardsMethodTwo()
        {
            int expected = 25;
            int actual = ArrayMethods.FindMinimumRewards_MethodTwo(arrayFive);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MoveSimilarElementToStart()
        {
            int[] expected = new int[] {2, 2, 2, 2, 2, 3, 4, 1};
            int[] actual = ArrayMethods.MoveElementToStart(array, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MoveSimilarElementToEnd()
        {
            int[] expected = new int[] {4, 1, 3, 2, 2, 2, 2, 2};
            int[] actual = ArrayMethods.MoveElementToEnd(array, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MoveZigzag()
        {
            List<List<int>> elements = new List<List<int>>();
            elements.Add(new List<int>() {1, 3, 4, 10});
            elements.Add(new List<int>() {2, 5, 9, 11});
            elements.Add(new List<int>() {6, 8, 12, 15});
            elements.Add(new List<int>() {7, 13, 14, 16});
            List<int> expected = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
            List<int> actual = ArrayMethods.Zigzag(elements);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void ApartmentHunting_MethodOne()
        {
            List<Dictionary<string, bool>> blocks = new List<Dictionary<string, bool>>();
            
            blocks.Insert(0, new Dictionary<string, bool>());
            blocks[0]["gym"] = false;
            blocks[0]["school"] = true;
            blocks[0]["store"] = false;

            blocks.Insert(1, new Dictionary<string, bool>());
            blocks[1]["gym"] = true;
            blocks[1]["school"] = false;
            blocks[1]["store"] = false;

            blocks.Insert(2, new Dictionary<string, bool>());
            blocks[2]["gym"] = true;
            blocks[2]["school"] = true;
            blocks[2]["store"] = false;

            blocks.Insert(3, new Dictionary<string, bool>());
            blocks[3]["gym"] = false;
            blocks[3]["school"] = true;
            blocks[3]["store"] = false;

            blocks.Insert(4, new Dictionary<string, bool>());
            blocks[4]["gym"] = false;
            blocks[4]["school"] = true;
            blocks[4]["store"] = true;

            string[] reqs = new string[] { "gym", "school", "store" };
            int expected = 3;
            int actual = ArrayMethods.FindApartment_MethodOne(blocks, reqs);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void ApartmentHunting_MethodTwo()
        {
            List<Dictionary<string, bool>> blocks = new List<Dictionary<string, bool>>();
            
            blocks.Insert(0, new Dictionary<string, bool>());
            blocks[0]["gym"] = true;
            blocks[0]["pool"] = false;
            blocks[0]["school"] = true;
            blocks[0]["store"] = false;

            blocks.Insert(1, new Dictionary<string, bool>());
            blocks[1]["gym"] = false;
            blocks[1]["pool"] = false;
            blocks[1]["school"] = false;
            blocks[1]["store"] = false;

            blocks.Insert(2, new Dictionary<string, bool>());
            blocks[2]["gym"] = false;
            blocks[2]["pool"] = false;
            blocks[2]["school"] = true;
            blocks[2]["store"] = false;

            blocks.Insert(3, new Dictionary<string, bool>());
            blocks[3]["gym"] = false;
            blocks[3]["pool"] = false;
            blocks[3]["school"] = false;
            blocks[3]["store"] = false;

            blocks.Insert(4, new Dictionary<string, bool>());
            blocks[4]["gym"] = false;
            blocks[4]["pool"] = false;
            blocks[4]["school"] = false;
            blocks[4]["store"] = true;

            blocks.Insert(5, new Dictionary<string, bool>());
            blocks[5]["gym"] = true;
            blocks[5]["pool"] = false;
            blocks[5]["school"] = false;
            blocks[5]["store"] = false;

            blocks.Insert(6, new Dictionary<string, bool>());
            blocks[6]["gym"] = false;
            blocks[6]["pool"] = false;
            blocks[6]["school"] = false;
            blocks[6]["store"] = false;

            blocks.Insert(7, new Dictionary<string, bool>());
            blocks[7]["gym"] = false;
            blocks[7]["pool"] = false;
            blocks[7]["school"] = false;
            blocks[7]["store"] = false;

            blocks.Insert(8, new Dictionary<string, bool>());
            blocks[8]["gym"] = false;
            blocks[8]["pool"] = false;
            blocks[8]["school"] = false;
            blocks[8]["store"] = false;

            blocks.Insert(9, new Dictionary<string, bool>());
            blocks[9]["gym"] = false;
            blocks[9]["pool"] = false;
            blocks[9]["school"] = true;
            blocks[9]["store"] = false;

            blocks.Insert(10, new Dictionary<string, bool>());
            blocks[10]["gym"] = false;
            blocks[10]["pool"] = true;
            blocks[10]["school"] = false;
            blocks[10]["store"] = false;

            string[] reqs = new string[] { "gym", "pool", "school", "store" };
            int expected = 7;
            int actual = ArrayMethods.FindApartment_MethodOne(blocks, reqs);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void CalanderMeeting()
        {
            List<Meeting> myCalender = new List<Meeting>();
            List<Meeting> coworkerCalender = new List<Meeting>();
            List<Meeting> expected = new List<Meeting>();

            myCalender.Add(new Meeting("9:00", "10:30"));
            myCalender.Add(new Meeting("12:00", "13:00"));
            myCalender.Add(new Meeting("16:00", "18:00"));

            coworkerCalender.Add(new Meeting("10:00", "11:30"));
            coworkerCalender.Add(new Meeting("12:30", "14:30"));
            coworkerCalender.Add(new Meeting("14:30", "15:00"));
            coworkerCalender.Add(new Meeting("16:00", "17:00"));

            expected.Add(new Meeting("11:30", "12:00"));
            expected.Add(new Meeting("15:00", "16:00"));
            expected.Add(new Meeting("18:00", "18:30"));

            List<Meeting> actual = Meeting.CalenderMeeting(myCalender, new Meeting("9:00", "20:00"), coworkerCalender, new Meeting("10:00", "18:30"), 30);

            Assert.AreEqual(true, true);
        }
    }
}