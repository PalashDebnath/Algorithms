using System;

namespace Algorithms.Application
{
    public class Subset
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int MaximumSumOfNoAdjacent(int[] array)
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
    }

    public class Number
    {
        //Time Complexity: O(nd) n --> total number of distinct amount and d --> total number of distinct demon 
        //Space Complexity: O(n) n --> size of the array of ways.
        public static int WaysToMakeChange(int[] denoms, int targetValue)
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
        public static int MinimumCoinsForChange(int[] denoms, int targetValue)
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

    public class LevenshteinDistance
    {
        //Time Complexity: O(mn) where m and n is the length of given strings
        //Space Complexity: O(mn) where m and n is the lenght of given strings.
        public static int NumberOfOperation(string str1, string str2)
        {
            int[,] operations = new int[str2.Length + 1, str1.Length + 1];
            for(int i = 0; i < str2.Length + 1; i++)
            {
                for(int j = 0; j < str1.Length + 1; j++)
                {
                    operations[i,j] = j;
                }
                operations[i,0] = i;
            }

            for(int i = 1; i < str2.Length + 1; i++)
            {
                for(int j = 1; j < str1.Length + 1; j++)
                {
                    //you should decrease the counter as the array length is always 1 position bigger then the string input
                    if(str1[j - 1] == str2[i - 1])
                    {
                        operations[i,j] = operations[i-1,j-1];
                    }
                    else
                    {
                        operations[i,j] = 1 + Math.Min(Math.Min(operations[i,j-1], operations[i-1,j-1]), operations[i-1,j]);
                    }
                }
            }
            return operations[str2.Length, str1.Length];
        }
    }  
}