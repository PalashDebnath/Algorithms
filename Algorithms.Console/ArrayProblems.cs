using System;
using System.Collections.Generic;

namespace Algorithms.Application
{
    public class Sum
    {
        //Brute force array traversal with two for loop.
        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int[] TwoNumberUsingTraversal(int[] array, int targetSum)
        {
            for(int i = 0; i < array.Length; i++)
            {
                int xNum = array[i];
                for(int j = i + 1; j < array.Length; j++)
                {
                    int yNum = array[j];
                    int totalSum = xNum + yNum;
                    if(totalSum == targetSum)
                    {
                        return new int[] {xNum, yNum};
                    }
                }
            }
            return new int[] {};
        }

        //Using hash table data structure with one loop.
        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static int[] TwoNumberUsingHashtable(int[] array, int targetSum)
        {
            Dictionary<int, bool> xValues = new Dictionary<int, bool>();
            for(int i = 0; i < array.Length; i++)
            {
                int yNum = array[i];
                int xNum = targetSum - yNum;
                if(xValues.ContainsKey(xNum))
                {
                    return new int[] {xNum, yNum};
                }
                else
                {
                    xValues.Add(yNum, true);
                } 
            }
            return new int[] {};
        }

        //Sort the integer array first. After that use two pointer to find the sum out.
        //Time Complexity: sorting array time complexity == O(nlog(n)) and find sum is O(n) ---> O(nlog(n))
        //Space Complexity: O(1)
        public static int[] TwoNumberUsingSorting(int[] array, int targetSum)
        {
            Array.Sort(array);
            int i = 0, j = array.Length - 1; 
            while(i < j)
            {
                int xNum = array[i];
                int yNum = array[j];
                int totalSum = xNum + yNum;
                if(totalSum > targetSum)
                {
                    j = j - 1;
                }
                else if(totalSum < targetSum)
                {
                    i = i + 1;
                }
                else
                {
                    return new int[] {xNum, yNum};
                }
            }
            return new int[] {};
        }
    
        //Time Complexity: O(n^2) Sorting the array will take O(nlog(n)) time and to find the sum of three you have two loops, which is O(n^2) 
        //Space complexity: O(n)
        public static List<int[]> ThreeNumberUsingTraversal(int[] array, int targetSum)
        {
            List<int[]> results = new List<int[]>();
            Array.Sort(array);
            for(int i = 0; i < array.Length; i++)
            {
                int left = i + 1;
                int right = array.Length - 1;
                while(left < right)
                {
                    int totalSum = array[i] + array[left] + array[right];
                    if( totalSum == targetSum)
                    {
                        results.Add(new int[] { array[i], array[left], array[right] });
                        left = left + 1;
                    }
                    else if(totalSum > targetSum)
                    {
                        right = right - 1;
                    }
                    else
                    {
                        left = left + 1;
                    }
                }
            } 
            return results;
        }
    }
    
    public class MoveElement
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int[] ToEnd(int[] array, int toMove)
        {
            int leftPointer = 0, rightPointer = array.Length - 1;
            while(leftPointer < rightPointer)
            {
                if(array[rightPointer] == toMove)
                {
                    rightPointer = rightPointer - 1;
                }
                else if(array[leftPointer] != toMove)
                {
                    leftPointer = leftPointer + 1;
                }
                else
                {
                    int temp = array[rightPointer];
                    array[rightPointer] = array[leftPointer];
                    array[leftPointer] = temp;
                }

            }
            return array;
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int[] ToStart(int[] array, int toMove)
        {
            int leftPointer = 0, rightPointer = array.Length - 1;
            while(leftPointer < rightPointer)
            {
                if(array[leftPointer] == toMove)
                {
                    leftPointer = leftPointer + 1;
                }
                else if(array[rightPointer] != toMove)
                {
                    rightPointer = rightPointer - 1;
                }
                else
                {
                    int temp = array[leftPointer];
                    array[leftPointer] = array[rightPointer];
                    array[rightPointer] = temp;
                }

            }
            return array;
        }
    }

    public class Find
    {
        //Sorting the array each will take O(nlog(n)). And the actual logic to find out the pair is O(n) as you loop through the element and update the pointer 
        //Time Complexity: O(nlog(n) + mlog(m)) --> O(nlog(n)) **n == number of elements in first array and m == number of element in second array
        //Space Complexity: O(1)
        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);
            int leftPointer = 0, rightPointer = 0, smallestDifference = Int32.MaxValue, firstValue = 0, secondValue = 0;
            while(leftPointer < arrayOne.Length && rightPointer < arrayTwo.Length)
            {
                int difference = 0;
                if(arrayOne[leftPointer] == arrayTwo[rightPointer])
                {
                    return new int[] {arrayOne[leftPointer], arrayTwo[rightPointer]};
                }
                else if(arrayOne[leftPointer] > arrayTwo[rightPointer])
                {
                    difference = arrayOne[leftPointer] - arrayTwo[rightPointer];
                    if(difference < smallestDifference)
                    {
                        smallestDifference = difference;
                        firstValue = arrayOne[leftPointer];
                        secondValue = arrayTwo[rightPointer];
                    }
                    rightPointer = rightPointer + 1;
                }
                else
                {
                    difference = arrayTwo[rightPointer] - arrayOne[leftPointer];
                    if(difference < smallestDifference)
                    {
                        smallestDifference = difference;
                        firstValue = arrayOne[leftPointer];
                        secondValue = arrayTwo[rightPointer];
                    }
                    leftPointer = leftPointer + 1;
                }
            }
            return new int[] {firstValue, secondValue};
        }
    }
}