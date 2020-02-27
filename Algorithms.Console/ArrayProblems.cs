using System;
using System.Collections.Generic;
using System.Linq;

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
    
        public static List<int[]> FourNumberUsingTraversal(int[] array, int targetSum)
        {
            Dictionary<int, List<int[]>> memorize = new Dictionary<int, List<int[]>>();
            List<int[]> output = new List<int[]>();
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = i + 1; j < array.Length; j++)
                {
                    int firstTwo = array[i] + array[j]; 
                    if(memorize.ContainsKey(firstTwo))
                    {
                        memorize[firstTwo].Add(new int[]{array[i], array[j]});
                    }
                    else
                    {
                        memorize.Add(firstTwo, new List<int[]>(){new int[]{array[i], array[j]}});
                    }                        
                }
            }

            foreach(var m in memorize)
            {
                int temp = targetSum - m.Key;
                if(memorize.ContainsKey(temp))
                {
                    CombineListOfInteger(m.Value, memorize[temp], output);
                    memorize.Remove(temp);
                    memorize.Remove(m.Key);
                }
            }                      
            return output;
        }

        private static void CombineListOfInteger(List<int[]> first, List<int[]> second, List<int[]> output)
        {
            foreach(var f in first)
            {
                foreach(var s in second)
                {
                    if(f[0] != s[0] && f[0] != s[1] && f[1] != s[0] && f[1] != s[1])
                    {
                        int[] temp = new int[] {f[0], f[1], s[0], s[1]};
                        Array.Sort(temp);
                        if(!output.Exists(e => e[0] == temp[0] && e[1] == temp[1] && e[2] == temp[2]  && e[3] == temp[3]))
                        {
                            output.Add(temp);
                        }
                    }
                }
            }
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
    
        public static List<int> Zigzag(List<List<int>> array)
        {
            int row = 0, column = 0, height = array.Count - 1, width = array[0].Count - 1;
            bool isDown = true;
            List<int> result = new List<int>();
            while(column >= 0 && column <= width && row >= 0 && row <= height)
            {
                result.Add(array[row][column]);
                if(isDown)
                {
                    if(column == 0 || row == height)
                    {
                        isDown = false;
                        if(row == height)
                        {
                            column++;
                        }
                        else
                        {
                            row++;
                        }
                    }
                    else
                    {
                        row++;
                        column--;
                    }
                }
                else
                {
                    if(row == 0 || column == width)
                    {
                        isDown = true;
                        if(column == width)
                        {
                            row++;
                        }
                        else
                        {
                            column++;
                        }
                    }
                    else
                    {
                        row--;
                        column++;
                    }
                }
            }
            return result;
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

        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int[] SmallestUnSortedSubArrayIndices_MethodOne(int[] array)
        {
            int highest = Int32.MinValue, lowest = Int32.MaxValue;
            bool swap = true;
            while(swap)
            {
                swap = false;
                for(int i = 0; i < array.Length - 1; i++)
                {
                    if(array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        highest = highest < i + 1 ? i + 1 : highest;
                        lowest = lowest > i ? i : lowest;
                        swap = true;
                    }
                }
            }
            return new int[] {lowest == Int32.MaxValue ? -1 : lowest,
                              highest == Int32.MinValue ? -1 : highest};
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int[] SmallestUnSortedSubArrayIndices_MethodTwo(int[] array)
        {
            int highest = Int32.MinValue, lowest = Int32.MaxValue;
            int left = 0, right = array.Length - 1;
            for(int i = 0; i < array.Length - 1; i++)
            {
                if(array[i] > array[i + 1])
                {
                    highest = highest < array[i] ? array[i] : highest;
                    lowest = lowest > array[i + 1] ? array[i + 1] : lowest;
                }
            }
            while(left < array.Length)
            {
                if(array[left] > lowest)
                {
                    break;
                }
                left = left + 1;
            }

            while(right >= 0)
            {
                if(array[right] < highest)
                {
                    break;
                }
                right = right - 1;
            }

            return new int[] {lowest == Int32.MaxValue ? -1 : left,
                              highest == Int32.MinValue ? -1 : right};
        }

        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static int[] LargestRange(int[] array)
        {
            Dictionary<int, bool> memorize = new Dictionary<int, bool>();
            int rangeLength = 0, start = 0, end = 0;
            foreach(int num in array)
            {
                if(!memorize.ContainsKey(num))
                {
                    memorize.Add(num, false);
                }
            }

            foreach(int num in array)
            {
                int left = num - 1, right = num + 1, length = 0;
                while(!memorize[num])
                {
                    if(memorize.ContainsKey(left))
                    {
                        memorize[left] = true;
                        left =  left - 1;
                        length = length + 1;
                    }
                    else if(memorize.ContainsKey(right))
                    {
                        memorize[right] = true;
                        right = right + 1;
                        length = length + 1;
                    }
                    else
                    {
                        memorize[num] = true;
                        length = length + 1;
                    }
                }

                if(rangeLength < length)
                {
                    rangeLength = length;
                    start = left + 1;
                    end = right - 1;
                }
            }
            return new int[] {start, end};
        }
    
        //Time Complexity: O(n^2)
        //Space Complexity: O(n)
        public static int MinimumRewards_MethodOne(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            Array.Fill(rewards, 1);
            for(int i = 0; i < scores.Length; i++)
            {
                int left = i - 1;
                int right = i;
                while(left >= 0 && scores[left] > scores[right] && rewards[left] == rewards[right])
                {
                    rewards[left] =  rewards[right] + 1;
                    left = left - 1;
                    right = right - 1;
                }
                if(left >= 0 && scores[left] < scores[i] && left == i - 1)
                {
                    rewards[i] = rewards[left] + 1;
                }
            }
            return rewards.Sum();
        }

        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static int MinimumRewards_MethodTwo(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            Array.Fill(rewards, 1);
            for(int i = 1; i < scores.Length; i++)
            {
                if(scores[i] > scores[i - 1])
                {
                    rewards[i] = rewards[i - 1] + 1;
                }
            }

            for(int i = scores.Length - 2; i >= 0; i--)
            {
                if(scores[i] > scores[i + 1])
                {
                    rewards[i] = Math.Max(rewards[i], rewards[i + 1] + 1);
                }
            }
            return rewards.Sum();
        }
    }
}