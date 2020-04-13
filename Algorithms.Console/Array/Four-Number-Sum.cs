using System;
using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static class FourNumberSum
    {
        //Time Complexity: Average Case O(n^2) | Worst Case O(n^3)
        //Space Complexity: Average Case O(n^2) | Worst Case O(n^2)
        public static List<int[]> UsingHashTable(int[] array, int targetSum)
        {
            Dictionary<int, List<int[]>> memorize = new Dictionary<int, List<int[]>>();
            List<int[]> output = new List<int[]>();
            
            for(int i = 1; i < array.Length - 1; i++)
            {
                for(int j = i + 1; j < array.Length; j++)
                {
                    int firstTwo = array[i] + array[j];
                    int secondTwo = targetSum - firstTwo;
                    if(memorize.ContainsKey(secondTwo))
                    {
                        foreach (int[] pair in memorize[secondTwo])
                        {
                            output.Add(new int[]{ pair[0], pair[1], array[i], array[j] });
                        }
                    }                 
                }
                for (int k = 0; k < i; k++)
                {
                    int firstTwo = array[i] + array[k];
                    if(memorize.ContainsKey(firstTwo))
                    {
                        memorize[firstTwo].Add(new int[] { array[i], array[k]});
                    }
                    else
                    {
                        memorize.Add(firstTwo, new List<int[]>() {new int[] { array[i], array[k]}});
                    } 
                }
            }                     
            return output;
        }
    }
}