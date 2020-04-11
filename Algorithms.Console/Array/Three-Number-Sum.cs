using System;
using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static class ThreeNumberSum
    {
        //Time Complexity: O(n^2) Sorting the array will take O(nlog(n)) time and to find the sum of three you have two loops, which is O(n^2) 
        //Space complexity: O(n)
        public static List<int[]> UsingSorting(int[] array, int targetSum)
        {
            var results = new List<int[]>();
            Array.Sort(array);

            for(int i = 0; i < array.Length; i++)
            {
                var left = i + 1;
                var right = array.Length - 1;

                while(left < right)
                {
                    var totalSum = array[i] + array[left] + array[right];

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

        //Time Complexity: O(n^3) 
        //Space complexity: O(n)
        public static List<int[]> UsingTraversal(int[] array, int targetSum)
        {
            var results = new List<int[]>();
            Array.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                for(int j = i + 1; j < array.Length; j++)
                {
                    for (int k = j + 1; k < array.Length; k++)
                    {
                        if(array[i] + array[j] + array[k] == targetSum)
                        {
                            results.Add(new int[] { array[i], array[j], array[k] });
                        }
                    }
                }
            }
            return results;
        }
    }
}