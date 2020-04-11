using System;

namespace Algorithms.Problems
{
    public static class LongestPeak
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int Length(int[] array)
        {
            int position = 1, maxLength = 0;
            while(position < array.Length - 1)
            {
                if (array[position] > array[position - 1] && array[position] > array[position + 1])
                {
                    int left = position - 2, right = position + 2;
                    while (left >= 0 && array[left] < array[left + 1])
                    {
                        left -= 1;
                    }
                    while (right < array.Length && array[right] < array[right - 1])
                    {
                        right += 1;
                    }
                    maxLength = Math.Max(maxLength, (right - left - 1));
                    position = right;
                }
                else
                {
                    position += 1;
                }
            }
            return maxLength;
        }
    }
}