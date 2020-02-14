using System;

namespace Algorithms.Application
{
    public class SmallestDifference
    {
        //Sorting the array each will take O(nlog(n)). And the actual logic to find out the pair is O(n) as you loop through the element and update the pointer 
        //Time Complexity: O(nlog(n) + mlog(m)) --> O(nlog(n)) **n == number of elements in first array and m == number of element in second array
        //Space Complexity: O(1)
        public static int[] Find(int[] arrayOne, int[] arrayTwo)
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
    }
}