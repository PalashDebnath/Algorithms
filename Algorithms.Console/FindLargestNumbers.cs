using System;

namespace Algorithms.Application
{
    public class FindlargestNumbers
    {
        public static int[] Three(int[] array)
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