using System;

namespace Algorithms.Problems
{
    public static class SmallestUnsortedSubarray
    {
        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int[] FindIndicesMethodOne(int[] array)
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
        public static int[] FindIndicesMethodTwo(int[] array)
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
    }
}