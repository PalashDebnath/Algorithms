using System;

namespace Algorithms.Application
{
    public class Search
    {
        //Time Complexity: O(log(n))
        //Space Complexity: O(1) 
        public static int IterativeBinarySearch(int[] sourceArray, int targetValue)
        {
            int left, right, middle;
            left = 0;
            right = sourceArray.Length - 1;
            while(left <= right)
            {
                middle = (left + right) / 2;
                if(targetValue == sourceArray[middle])
                {
                    return middle;
                }
                else if(targetValue > sourceArray[middle])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return -1;
        }

        //Time Complexity: O(log(n))
        //Space Complexity: O(log(n)) 
        public static int RecursiveBinarySearch(int[] sourceArray, int targetValue)
        {
            return RecursiveBinarySearch(sourceArray, targetValue, 0, sourceArray.Length - 1);
        }

        private static int RecursiveBinarySearch(int[] sourceArray, int targetValue, int left, int right)
        {
            int middle;
            middle = (left + right) / 2;
            if(left > right)
            {
                return -1;
            }
            if(targetValue == sourceArray[middle])
            {
                return middle;
            }
            else if(targetValue > sourceArray[middle])
            {
                return RecursiveBinarySearch(sourceArray, targetValue, middle + 1, right);
            }
            else
            {
                return RecursiveBinarySearch(sourceArray, targetValue, left, middle - 1);
            }
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int[] ThreeLargestNumbers(int[] array)
        {
            int largest = Int32.MinValue, secondLargest = Int32.MinValue, thirdLargest = Int32.MinValue;
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] >= largest)
                {
                    thirdLargest = secondLargest;
                    secondLargest = largest;
                    largest = array[i];
                }
                else if(array[i] >= secondLargest)
                {
                    thirdLargest = secondLargest;
                    secondLargest = array[i];
                }
                else if(array[i] >= thirdLargest)
                {
                    thirdLargest = array[i];
                }
            }
            return new int[] { thirdLargest, secondLargest, largest};
        }
    }
}