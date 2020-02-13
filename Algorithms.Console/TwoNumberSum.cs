using System.Collections.Generic;
using System;

namespace Algorithms.Application
{
    public class TwoNumberSum
    {
        //Brute force array traversal with two for loop.
        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int[] SumUsingTraversal(int[] array, int targetSum)
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
        public static int[] SumUsingHashtable(int[] array, int targetSum)
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
        public static int[] SumUsingSorting(int[] array, int targetSum)
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
    }
}