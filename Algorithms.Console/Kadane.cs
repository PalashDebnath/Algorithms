using System;

namespace Algorithms.Application
{
    public class Kadan
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1).
        public static int FindMaximumSumOfSubArray(int[] array)
        {
            int currectSum = array[0];
            int totalSum = array[0];
            for(int i = 1; i < array.Length; i++)
            {
                currectSum = currectSum + array[i] >= array[i] ? currectSum + array[i] : array[i];
                totalSum = totalSum >= currectSum ? totalSum : currectSum;
            }
            return totalSum;
        }
    }
}