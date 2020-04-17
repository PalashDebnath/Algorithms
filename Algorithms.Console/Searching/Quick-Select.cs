using System;

namespace Algorithms.Problems
{
    public static class QuickSelect
    {
        //Time Complexity: Worst Case O(n^2) | Average Case O(n) | Best Case O(n)
        //Space Complexity: Worst Case O(1)) | Average Case O(1) | Best Case O(1) 
        public static int Find(int[] array, int k)
        {
            int sIndex = 0, eIndex = array.Length - 1, position = k - 1;

            while(true)
            {
                int pivot = array[sIndex];
                int left = sIndex + 1;
                int right = eIndex;
                while (left <= right)
                {
                    if(array[left] >= pivot && array[right] < pivot)
                    {
                        int temp = array[left];
                        array[left] = array[right];
                        array[right] = temp;
                        left += 1;
                        right -= 1;
                    }
                    else
                    {
                        if(array[left] < pivot)
                            left += 1;
                        if(array[right] >= pivot)
                            right -= 1;
                    }
                }
                array[sIndex] = array[right];
                array[right] = pivot;

                if(right == position)
                    return array[right];
                else if(right > position)
                    eIndex = right - 1;
                else
                    sIndex = right + 1;
            }                        
        }

        //Time Complexity: O(nlog(n))
        //Space Complexity: O(1)
        public static int FindUsingSorting(int[] array, int k)
        {
            if(k == 0 || k > array.Length)
                return -1;
            Array.Sort(array);
            return array[k - 1];
        }
    }
}