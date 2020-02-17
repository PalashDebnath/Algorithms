using System.Collections.Generic;
using System;

namespace Algorithms.Application
{
    public class NumberSum
    {
        //Brute force array traversal with two for loop.
        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int[] SumTwoNumberUsingTraversal(int[] array, int targetSum)
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
        public static int[] SumTwoNumberUsingHashtable(int[] array, int targetSum)
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
        public static int[] SumTwoNumberUsingSorting(int[] array, int targetSum)
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
        public static List<int[]> SumThreeNumber(int[] array, int targetSum)
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

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int MaximumSubsetSumOfNoAdjacent(int[] array)
        {
            if(array.Length == 0)
            {
                return 0;
            }
            else if(array.Length == 1)
            {
                return array[0];
            }
            else
            {
                int firstMax = array[0];
                int secondMax = Math.Max(array[1], firstMax);
                for(int i = 2; i < array.Length; i++)
                {
                    int temp = secondMax;
                    secondMax = Math.Max(secondMax, firstMax + array[i]);
                    firstMax = secondMax;
                }
                return secondMax;
            }            
        }

        //Time Complexity: O(nd) n --> total number of distinct amount and d --> total number of distinct demon 
        //Space Complexity: O(n) n --> size of the array of ways.
        public static int NumberOfWaysToMakeChange(int[] denoms, int targetValue)
        {
            int[] ways = new int[targetValue + 1];
            ways[0] = 1;
            foreach(int denom in denoms)
            {
                for(int eachAmount = 0; eachAmount < targetValue + 1; eachAmount++)
                {
                    if(eachAmount >= denom)
                    {
                        ways[eachAmount] = ways[eachAmount] + ways[eachAmount - denom];
                    }
                }
            }
            return ways[targetValue];
        }

        //Time Complexity: O(nd) n --> total number of distinct amount and d --> total number of distinct demon 
        //Space Complexity: O(n) n --> size of the array of ways.
        public static int MinimumNumberOfCoinsForChange(int[] denoms, int targetValue)
        {
            int[] coins = new int[targetValue + 1];
            Array.Fill(coins, Int32.MaxValue);
            coins[0] = 0;
            foreach(int denom in denoms)
            {
                for(int eachAmount = 0; eachAmount < targetValue + 1; eachAmount++)
                {
                    if(eachAmount >= denom)
                    {
                        if(coins[eachAmount - denom] == Int32.MaxValue)
                        {
                            coins[eachAmount] = Math.Min(coins[eachAmount], Int32.MaxValue);
                        }
                        else
                        {
                            coins[eachAmount] = Math.Min(coins[eachAmount], 1 + coins[eachAmount - denom]);
                        }
                    }
                }
            }
            return coins[targetValue] != Int32.MaxValue ? coins[targetValue] : -1;
        }
    }
}