using System;
using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static class TwoNumberSum
    {
        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int[] UsingTraversal(int[] array, int targetSum)
        {
            for(int i = 0; i < array.Length; i++)
            {
                var xNum = array[i];
                for(int j = i + 1; j < array.Length; j++)
                {
                    var yNum = array[j];
                    var totalSum = xNum + yNum;
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
        public static int[] UsingHashtable(int[] array, int targetSum)
        {
            var xValues = new Dictionary<int, bool>();
            for(int i = 0; i < array.Length; i++)
            {
                var yNum = array[i];
                var xNum = targetSum - yNum;
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
        public static int[] UsingSorting(int[] array, int targetSum)
        {
            var i = 0;
            var j = array.Length - 1;

            Array.Sort(array);
            while(i < j)
            {
                var xNum = array[i];
                var yNum = array[j];
                var totalSum = xNum + yNum;
                
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