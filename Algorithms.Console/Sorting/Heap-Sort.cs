using System;

namespace Algorithms.Problems
{
    public static class Heap
    {
        public static int[] SortAscending(int[] array)
        {
            MaxHeapBuilder(array);
            for (int endIndex = array.Length - 1; endIndex > 0; endIndex--)
            {
                Swap(0, endIndex, array);
                SiftMaxValueAtTheTop(0, endIndex - 1, array);
            }
            return array;
        }

        public static int[] SortDecending(int[] array)
        {
            MinHeapBuilder(array);
            for (int endIndex = array.Length - 1; endIndex > 0; endIndex--)
            {
                Swap(0, endIndex, array);
                SiftMinValueAtTheTop(0, endIndex - 1, array);
            }            
            return array;
        }

        private static void MinHeapBuilder(int[] array)
        {
            int firstParentIndex = (array.Length - 2) / 2;
            int endIndex = array.Length - 1;
            for (int currentIndex = firstParentIndex; currentIndex >= 0; currentIndex--)
            {
                SiftMinValueAtTheTop(currentIndex, endIndex, array);
            }
        }

        private static void MaxHeapBuilder(int[] array)
        {
            int firstParentIndex = (array.Length - 2) / 2;
            int endIndex = array.Length - 1;
            for (int currentIndex = firstParentIndex; currentIndex >= 0; currentIndex--)
            {
                SiftMaxValueAtTheTop(currentIndex, endIndex, array);
            }
        }

        private static void Swap(int sourceIndex, int targetIndex, int[] array)
        {
            int temp = array[sourceIndex];
            array[sourceIndex] = array[targetIndex];
            array[targetIndex] = temp;
        }

        private static void SiftMaxValueAtTheTop(int currentIndex, int endIndex, int[] array)
        {
            int firstChildIndex = currentIndex * 2 + 1;
            while(firstChildIndex <= endIndex)
            {
                int secondChildIndex = currentIndex * 2 + 2 <= endIndex ? currentIndex * 2 + 2 : -1;
                int targetIndex;

                if(secondChildIndex != -1 && array[secondChildIndex] > array[firstChildIndex])
                {
                    targetIndex = secondChildIndex;
                }
                else
                {
                    targetIndex = firstChildIndex;
                }

                if(array[targetIndex] > array[currentIndex])
                {
                    Swap(currentIndex, targetIndex, array);
                    currentIndex = targetIndex;
                    firstChildIndex = currentIndex * 2 + 1;
                }
                else
                {
                    break;
                }
            }
        }

        private static void SiftMinValueAtTheTop(int currentIndex, int endIndex, int[] array)
        {
            int firstChildIndex = currentIndex * 2 + 1;
            while(firstChildIndex <= endIndex)
            {
                int secondChildIndex = currentIndex * 2 + 2 <= endIndex ? currentIndex * 2 + 2 : -1;
                int targetIndex;

                if(secondChildIndex != -1 && array[secondChildIndex] < array[firstChildIndex])
                {
                    targetIndex = secondChildIndex;
                }
                else
                {
                    targetIndex = firstChildIndex;
                }

                if(array[targetIndex] < array[currentIndex])
                {
                    Swap(currentIndex, targetIndex, array);
                    currentIndex = targetIndex;
                    firstChildIndex = currentIndex * 2 + 1;
                }
                else
                {
                    break;
                }
            }
        }
    }
}